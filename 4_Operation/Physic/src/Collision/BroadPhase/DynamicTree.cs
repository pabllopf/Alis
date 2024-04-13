// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DynamicTree.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.RayCast;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Shared;

namespace Alis.Core.Physic.Collision.BroadPhase
{
    /// <summary>
    ///     A dynamic tree arranges data in a binary tree to accelerate queries such as volume queries and ray casts.
    ///     Leafs are proxies with an AABB. In the tree we expand the proxy AABB by Settings.b2_fatAABBFactor so that the proxy
    ///     AABB is bigger than the client object. This allows the client object to move by small amounts without triggering a
    ///     tree
    ///     update. Nodes are pooled and relocatable, so we use node indices rather than pointers.
    /// </summary>
    public class DynamicTree<T>
    {
        /// <summary>
        ///     The null node
        /// </summary>
        public const int NullNode = -1;
        
        /// <summary>
        ///     The stack
        /// </summary>
        private readonly Stack<int> queryStack = new Stack<int>(256);
        
        /// <summary>
        ///     The stack
        /// </summary>
        private readonly Stack<int> rayCastStack = new Stack<int>(256);
        
        /// <summary>
        ///     The free list
        /// </summary>
        private int freeList;
        
        /// <summary>
        ///     The node capacity
        /// </summary>
        private int nodeCapacity;
        
        /// <summary>
        ///     The node count
        /// </summary>
        private int nodeCount;
        
        /// <summary>
        ///     The nodes
        /// </summary>
        private TreeNode<T>[] nodes;
        
        /// <summary>
        ///     The root
        /// </summary>
        private int root;
        
        /// <summary>Constructing the tree initializes the node pool.</summary>
        public DynamicTree()
        {
            root = NullNode;
            
            nodeCapacity = 16;
            nodeCount = 0;
            nodes = new TreeNode<T>[nodeCapacity];
            
            for (int i = 0; i < nodeCapacity - 1; ++i)
            {
                nodes[i] = new TreeNode<T>
                {
                    ParentOrNext = i + 1,
                    Height = 1
                };
            }
            
            
            nodes[nodeCapacity - 1] = new TreeNode<T>
            {
                ParentOrNext = NullNode,
                Height = 1
            };
            freeList = 0;
        }
        
        /// <summary>Compute the height of the binary tree in O(N) time. Should not be called often.</summary>
        public int Height
        {
            get
            {
                if (root == NullNode)
                {
                    return 0;
                }
                
                return nodes[root].Height;
            }
        }
        
        /// <summary>Get the ratio of the sum of the node areas to the root area.</summary>
        public float AreaRatio
        {
            get
            {
                if (root == NullNode)
                {
                    return 0.0f;
                }
                
                TreeNode<T> treeNode = nodes[root];
                float rootArea = treeNode.Aabb.Perimeter;
                
                float totalArea = 0.0f;
                for (int i = 0; i < nodeCapacity; ++i)
                {
                    TreeNode<T> node = nodes[i];
                    if (node.Height < 0)
                    {
                        continue;
                    }
                    
                    totalArea += node.Aabb.Perimeter;
                }
                
                return totalArea / rootArea;
            }
        }
        
        /// <summary>
        ///     Get the maximum balance of an node in the tree. The balance is the difference in height of the two children of
        ///     a node.
        /// </summary>
        public int Balance
        {
            get
            {
                int maxBalance = 0;
                for (int i = 0; i < nodeCapacity; ++i)
                {
                    TreeNode<T> node = nodes[i];
                    if (node.Height <= 1)
                    {
                        continue;
                    }
                    
                    int child1 = node.Child1;
                    int child2 = node.Child2;
                    int balance = Math.Abs(nodes[child2].Height - nodes[child1].Height);
                    maxBalance = Math.Max(maxBalance, balance);
                }
                
                return maxBalance;
            }
        }
        
        /// <summary>
        ///     Create a proxy in the tree as a leaf node. We return the index of the node instead of a pointer so that we can
        ///     grow the node pool.
        /// </summary>
        /// <param name="aabb">The AABB.</param>
        /// <param name="userData">The user data.</param>
        /// <returns>Index of the created proxy</returns>
        public int CreateProxy(ref Aabb aabb, T userData)
        {
            int proxyId = AllocateNode();
            
            Vector2 r = new Vector2(Settings.AabbExtension, Settings.AabbExtension);
            nodes[proxyId].Aabb.LowerBound = aabb.LowerBound - r;
            nodes[proxyId].Aabb.UpperBound = aabb.UpperBound + r;
            nodes[proxyId].UserData = userData;
            nodes[proxyId].Height = 0;
            nodes[proxyId].Moved = true;
            
            InsertLeaf(proxyId);
            
            return proxyId;
        }
        
        /// <summary>Destroy a proxy. This asserts if the id is invalid.</summary>
        /// <param name="proxyId">The proxy id.</param>
        public void DestroyProxy(int proxyId)
        {
            RemoveLeaf(proxyId);
            FreeNode(proxyId);
        }
        
        /// <summary>
        ///     Move a proxy with a AABB. If the proxy has moved outside of its fattened AABB, then the proxy is
        ///     removed from the tree and re-inserted. Otherwise the function returns immediately.
        /// </summary>
        /// <param name="proxyId">The proxy id.</param>
        /// <param name="aabb">The AABB.</param>
        /// <param name="displacement">The displacement.</param>
        /// <returns>true if the proxy was re-inserted.</returns>
        public bool MoveProxy(int proxyId, ref Aabb aabb, Vector2 displacement)
        {
            Aabb fatAabb = new Aabb();
            Vector2 r = new Vector2(Settings.AabbExtension, Settings.AabbExtension);
            fatAabb.LowerBound = aabb.LowerBound - r;
            fatAabb.UpperBound = aabb.UpperBound + r;
            
            Vector2 d = Settings.AabbMultiplier * displacement;
            
            if (d.X < 0.0f)
            {
                fatAabb.LowerBound = new Vector2(fatAabb.LowerBound.X + d.X, fatAabb.LowerBound.Y);
            }
            else
            {
                fatAabb.UpperBound = new Vector2(fatAabb.UpperBound.X + d.X, fatAabb.UpperBound.Y);
            }
            
            if (d.Y < 0.0f)
            {
                fatAabb.LowerBound = new Vector2(fatAabb.LowerBound.X, fatAabb.LowerBound.Y + d.Y);
            }
            else
            {
                fatAabb.UpperBound = new Vector2(fatAabb.UpperBound.X, fatAabb.UpperBound.Y + d.Y);
            }
            
            Aabb treeAabb = nodes[proxyId].Aabb;
            if (treeAabb.Contains(ref aabb))
            {
                Aabb hugeAabb = new Aabb
                {
                    LowerBound = fatAabb.LowerBound - 4.0f * r,
                    UpperBound = fatAabb.UpperBound + 4.0f * r
                };
                
                if (hugeAabb.Contains(ref treeAabb))
                {
                    return false;
                }
            }
            
            RemoveLeaf(proxyId);
            
            nodes[proxyId].Aabb = fatAabb;
            
            InsertLeaf(proxyId);
            
            nodes[proxyId].Moved = true;
            
            return true;
        }
        
        /// <summary>
        ///     Describes whether this instance was moved
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        /// <returns>The bool</returns>
        public bool WasMoved(int proxyId) => nodes[proxyId].Moved;
        
        /// <summary>
        ///     Clears the moved using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        public void ClearMoved(int proxyId) => nodes[proxyId].Moved = false;
        
        /// <summary>
        ///     Gets the user data using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        /// <returns>The</returns>
        public T GetUserData(int proxyId) => nodes[proxyId].UserData;
        
        /// <summary>Get the fat AABB for a proxy.</summary>
        /// <param name="proxyId">The proxy id.</param>
        /// <param name="fatAabb">The fat AABB.</param>
        public void GetFatAabb(int proxyId, out Aabb fatAabb) => fatAabb = nodes[proxyId].Aabb;
        
        /// <summary>
        ///     Query an AABB for overlapping proxies. The callback class is called for each proxy that overlaps the supplied
        ///     AABB.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <param name="aabb">The AABB.</param>
        public void Query(Func<int, bool> callback, ref Aabb aabb)
        {
            queryStack.Clear();
            queryStack.Push(root);
            
            while (queryStack.Count > 0)
            {
                int nodeId = queryStack.Pop();
                if (nodeId == NullNode)
                {
                    continue;
                }
                
                TreeNode<T> node = nodes[nodeId];
                
                if (Aabb.TestOverlap(ref node.Aabb, ref aabb))
                {
                    if (node.IsLeaf())
                    {
                        bool proceed = callback(nodeId);
                        if (!proceed)
                        {
                            return;
                        }
                    }
                    else
                    {
                        queryStack.Push(node.Child1);
                        queryStack.Push(node.Child2);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Ray-cast against the proxies in the tree. This relies on the callback to perform an exact ray-cast in the case
        ///     where the proxy contains a Shape. The callback also performs any collision filtering. This has performance
        ///     roughly equal to k * log(n), where k is the number of collisions and n is the number of proxies in the tree.
        /// </summary>
        /// <param name="callback">A callback class that is called for each proxy that is hit by the ray.</param>
        /// <param name="input">The ray-cast input data. The ray extends from p1 to p1 + maxFraction * (p2 - p1).</param>
        public void RayCast(Func<RayCastInput, int, float> callback, ref RayCastInput input)
        {
            Vector2 p1 = input.Point1;
            Vector2 p2 = input.Point2;
            Vector2 r = CalculateNormalizedRayDirection(p1, p2);
            CalculateAbsVector(r);
            float maxFraction = input.Fraction;
            Aabb segmentAabb = CalculateSegmentAabb(p1, p2, maxFraction);
            
            rayCastStack.Clear();
            rayCastStack.Push(root);
            
            while (rayCastStack.Count > 0)
            {
                int nodeId = rayCastStack.Pop();
                if (nodeId == NullNode)
                {
                    continue;
                }
                
                TreeNode<T> node = nodes[nodeId];
                
                if (!IsAabbOverlap(node.Aabb, segmentAabb))
                {
                    continue;
                }
                
                if (IsSeparationValid(r, p1, node.Aabb))
                {
                    if (node.IsLeaf())
                    {
                        maxFraction = HandleLeafNode(callback, input, maxFraction, nodeId);
                        if (maxFraction == 0.0f)
                        {
                            return;
                        }
                    }
                    else
                    {
                        rayCastStack.Push(node.Child1);
                        rayCastStack.Push(node.Child2);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Calculates the normalized ray direction using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <returns>The vector</returns>
        private Vector2 CalculateNormalizedRayDirection(Vector2 p1, Vector2 p2)
        {
            Vector2 r = p2 - p1;
            return Vector2.Normalize(r);
        }
        
        /// <summary>
        ///     Calculates the abs vector using the specified vector
        /// </summary>
        /// <param name="vector">The vector</param>
        /// <returns>The vector</returns>
        private Vector2 CalculateAbsVector(Vector2 vector) => new Vector2(MathUtils.Abs(-vector.Y), MathUtils.Abs(vector.X));
        
        /// <summary>
        ///     Calculates the segment aabb using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="maxFraction">The max fraction</param>
        /// <returns>The aabb</returns>
        private Aabb CalculateSegmentAabb(Vector2 p1, Vector2 p2, float maxFraction)
        {
            Vector2 t = p1 + maxFraction * (p2 - p1);
            return new Aabb
            {
                LowerBound = Vector2.Min(p1, t),
                UpperBound = Vector2.Max(p1, t)
            };
        }
        
        /// <summary>
        ///     Describes whether this instance is aabb overlap
        /// </summary>
        /// <param name="aabb1">The aabb</param>
        /// <param name="aabb2">The aabb</param>
        /// <returns>The bool</returns>
        private bool IsAabbOverlap(Aabb aabb1, Aabb aabb2) => Aabb.TestOverlap(ref aabb1, ref aabb2);
        
        /// <summary>
        ///     Describes whether this instance is separation valid
        /// </summary>
        /// <param name="r">The </param>
        /// <param name="p1">The </param>
        /// <param name="aabb">The aabb</param>
        /// <returns>The bool</returns>
        private bool IsSeparationValid(Vector2 r, Vector2 p1, Aabb aabb)
        {
            Vector2 c = aabb.Center;
            Vector2 h = aabb.Extents;
            float separation = Math.Abs(Vector2.Dot(new Vector2(-r.Y, r.X), p1 - c)) - Vector2.Dot(CalculateAbsVector(r), h);
            return separation <= 0.0f;
        }
        
        /// <summary>
        ///     Handles the leaf node using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="input">The input</param>
        /// <param name="maxFraction">The max fraction</param>
        /// <param name="nodeId">The node id</param>
        /// <returns>The max fraction</returns>
        private float HandleLeafNode(Func<RayCastInput, int, float> callback, RayCastInput input, float maxFraction, int nodeId)
        {
            RayCastInput subInput = new RayCastInput
            {
                Point1 = input.Point1,
                Point2 = input.Point2,
                Fraction = maxFraction
            };
            
            float value = callback(subInput, nodeId);
            
            if (value > 0.0f)
            {
                maxFraction = value;
            }
            
            return maxFraction;
        }
        
        
        /// <summary>
        ///     Allocates the node
        /// </summary>
        /// <returns>The node id</returns>
        private int AllocateNode()
        {
            if (freeList == NullNode)
            {
                TreeNode<T>[] oldNodes = nodes;
                nodeCapacity *= 2;
                nodes = new TreeNode<T>[nodeCapacity];
                Array.Copy(oldNodes, nodes, nodeCount);
                
                for (int i = nodeCount; i < nodeCapacity - 1; ++i)
                {
                    nodes[i] = new TreeNode<T>
                    {
                        ParentOrNext = i + 1,
                        Height = -1
                    };
                }
                
                nodes[nodeCapacity - 1] = new TreeNode<T>
                {
                    ParentOrNext = NullNode,
                    Height = -1
                };
                freeList = nodeCount;
            }
            
            int nodeId = freeList;
            freeList = nodes[nodeId].ParentOrNext;
            nodes[nodeId].ParentOrNext = NullNode;
            nodes[nodeId].Child1 = NullNode;
            nodes[nodeId].Child2 = NullNode;
            nodes[nodeId].Height = 0;
            nodes[nodeId].UserData = default(T);
            nodes[nodeId].Moved = false;
            ++nodeCount;
            return nodeId;
        }
        
        /// <summary>
        ///     Frees the node using the specified node id
        /// </summary>
        /// <param name="nodeId">The node id</param>
        private void FreeNode(int nodeId)
        {
            nodes[nodeId].ParentOrNext = freeList;
            nodes[nodeId].Height = -1;
            freeList = nodeId;
            --nodeCount;
        }
        
        /// <summary>
        ///     Inserts the leaf using the specified leaf
        /// </summary>
        /// <param name="leaf">The leaf</param>
        private void InsertLeaf(int leaf)
        {
            if (root == NullNode)
            {
                SetRootLeaf(leaf);
                return;
            }
            
            Aabb leafAabb = nodes[leaf].Aabb;
            int index = FindInsertionIndex(leafAabb);
            
            CreateNewParentForLeaf(leaf, index, leafAabb);
            
            BalanceTreeFromLeafToRoot(leaf);
        }
        
        /// <summary>
        ///     Sets the root leaf using the specified leaf
        /// </summary>
        /// <param name="leaf">The leaf</param>
        private void SetRootLeaf(int leaf)
        {
            root = leaf;
            nodes[root].ParentOrNext = NullNode;
        }
        
        /// <summary>
        ///     Finds the insertion index using the specified leaf aabb
        /// </summary>
        /// <param name="leafAabb">The leaf aabb</param>
        /// <returns>The index</returns>
        private int FindInsertionIndex(Aabb leafAabb)
        {
            int index = root;
            while (!nodes[index].IsLeaf())
            {
                index = FindBestFitChild(index, leafAabb);
            }
            
            return index;
        }
        
        /// <summary>
        ///     Finds the best fit child using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="leafAabb">The leaf aabb</param>
        /// <returns>The int</returns>
        private int FindBestFitChild(int index, Aabb leafAabb)
        {
            int child1 = nodes[index].Child1;
            int child2 = nodes[index].Child2;
            
            float cost1 = CalculateCost(leafAabb, child1);
            float cost2 = CalculateCost(leafAabb, child2);
            
            return cost1 < cost2 ? child1 : child2;
        }
        
        /// <summary>
        ///     Calculates the cost using the specified leaf aabb
        /// </summary>
        /// <param name="leafAabb">The leaf aabb</param>
        /// <param name="childIndex">The child index</param>
        /// <returns>The float</returns>
        private float CalculateCost(Aabb leafAabb, int childIndex)
        {
            if (nodes[childIndex].IsLeaf())
            {
                Aabb aabb = new Aabb();
                aabb.Combine(ref leafAabb, ref nodes[childIndex].Aabb);
                return aabb.Perimeter;
            }
            else
            {
                Aabb aabb = new Aabb();
                aabb.Combine(ref leafAabb, ref nodes[childIndex].Aabb);
                float oldArea = nodes[childIndex].Aabb.Perimeter;
                float newArea = aabb.Perimeter;
                return newArea - oldArea;
            }
        }
        
        /// <summary>
        ///     Creates the new parent for leaf using the specified leaf
        /// </summary>
        /// <param name="leaf">The leaf</param>
        /// <param name="index">The index</param>
        /// <param name="leafAabb">The leaf aabb</param>
        private void CreateNewParentForLeaf(int leaf, int index, Aabb leafAabb)
        {
            int sibling = index;
            int oldParent = nodes[sibling].ParentOrNext;
            int newParent = AllocateNode();
            nodes[newParent].ParentOrNext = oldParent;
            nodes[newParent].UserData = default(T);
            nodes[newParent].Aabb.Combine(ref leafAabb, ref nodes[sibling].Aabb);
            nodes[newParent].Height = nodes[sibling].Height + 1;
            
            if (oldParent != NullNode)
            {
                ReplaceChild(oldParent, sibling, newParent);
                nodes[newParent].Child1 = sibling;
                nodes[newParent].Child2 = leaf;
                nodes[sibling].ParentOrNext = newParent;
                nodes[leaf].ParentOrNext = newParent;
            }
            else
            {
                nodes[newParent].Child1 = sibling;
                nodes[newParent].Child2 = leaf;
                nodes[sibling].ParentOrNext = newParent;
                nodes[leaf].ParentOrNext = newParent;
                root = newParent;
            }
        }
        
        /// <summary>
        ///     Replaces the child using the specified parent index
        /// </summary>
        /// <param name="parentIndex">The parent index</param>
        /// <param name="oldChild">The old child</param>
        /// <param name="newChild">The new child</param>
        private void ReplaceChild(int parentIndex, int oldChild, int newChild)
        {
            if (nodes[parentIndex].Child1 == oldChild)
            {
                nodes[parentIndex].Child1 = newChild;
            }
            else
            {
                nodes[parentIndex].Child2 = newChild;
            }
        }
        
        /// <summary>
        ///     Balances the tree from leaf to root using the specified leaf
        /// </summary>
        /// <param name="leaf">The leaf</param>
        private void BalanceTreeFromLeafToRoot(int leaf)
        {
            int index = nodes[leaf].ParentOrNext;
            while (index != NullNode)
            {
                index = BalanceTo(index);
                
                int child1 = nodes[index].Child1;
                int child2 = nodes[index].Child2;
                
                nodes[index].Height = 1 + Math.Max(nodes[child1].Height, nodes[child2].Height);
                nodes[index].Aabb.Combine(ref nodes[child1].Aabb, ref nodes[child2].Aabb);
                
                index = nodes[index].ParentOrNext;
            }
        }
        
        /// <summary>
        ///     Removes the leaf using the specified leaf
        /// </summary>
        /// <param name="leaf">The leaf</param>
        private void RemoveLeaf(int leaf)
        {
            if (leaf == root)
            {
                root = NullNode;
                return;
            }
            
            int parent = nodes[leaf].ParentOrNext;
            int grandParent = nodes[parent].ParentOrNext;
            int sibling = nodes[parent].Child1 == leaf ? nodes[parent].Child2 : nodes[parent].Child1;
            
            if (grandParent != NullNode)
            {
                if (nodes[grandParent].Child1 == parent)
                {
                    nodes[grandParent].Child1 = sibling;
                }
                else
                {
                    nodes[grandParent].Child2 = sibling;
                }
                
                nodes[sibling].ParentOrNext = grandParent;
                FreeNode(parent);
                
                int index = grandParent;
                while (index != NullNode)
                {
                    index = BalanceTo(index);
                    
                    int child1 = nodes[index].Child1;
                    int child2 = nodes[index].Child2;
                    
                    nodes[index].Aabb.Combine(ref nodes[child1].Aabb, ref nodes[child2].Aabb);
                    nodes[index].Height = 1 + Math.Max(nodes[child1].Height, nodes[child2].Height);
                    
                    index = nodes[index].ParentOrNext;
                }
            }
            else
            {
                root = sibling;
                nodes[sibling].ParentOrNext = NullNode;
                FreeNode(parent);
            }
        }
        
        /// <summary>
        ///     Balances the to using the specified i a
        /// </summary>
        /// <param name="iA">The </param>
        /// <returns>The </returns>
        private int BalanceTo(int iA)
        {
            TreeNode<T> a = nodes[iA];
            if (a.IsLeaf() || a.Height < 2)
            {
                return iA;
            }
            
            int iB = a.Child1;
            int iC = a.Child2;
            
            TreeNode<T> b = nodes[iB];
            TreeNode<T> c = nodes[iC];
            
            int balance = c.Height - b.Height;
            
            if (balance > 1)
            {
                return BalanceRight(iA, a, iC, c);
            }
            
            if (balance < -1)
            {
                return BalanceLeft(iA, a, iB, b);
            }
            
            return iA;
        }
        
        /// <summary>
        ///     Balances the right using the specified i a
        /// </summary>
        /// <param name="iA">The </param>
        /// <param name="a">The </param>
        /// <param name="iC">The </param>
        /// <param name="c">The </param>
        /// <returns>The int</returns>
        private int BalanceRight(int iA, TreeNode<T> a, int iC, TreeNode<T> c)
        {
            int iF = c.Child1;
            int iG = c.Child2;
            TreeNode<T> f = nodes[iF];
            TreeNode<T> g = nodes[iG];
            
            c.Child1 = iA;
            c.ParentOrNext = a.ParentOrNext;
            a.ParentOrNext = iC;
            
            UpdateParent(iA, iC, c.ParentOrNext);
            
            if (f.Height > g.Height)
            {
                return BalanceRightCase1(iA, a, iC, c, iF, f, iG, g);
            }
            
            return BalanceRightCase2(iA, a, iC, c, iF, f, iG, g);
        }
        
        /// <summary>
        ///     Balances the left using the specified i a
        /// </summary>
        /// <param name="iA">The </param>
        /// <param name="a">The </param>
        /// <param name="iB">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        private int BalanceLeft(int iA, TreeNode<T> a, int iB, TreeNode<T> b)
        {
            int iD = b.Child1;
            int iE = b.Child2;
            TreeNode<T> d = nodes[iD];
            TreeNode<T> e = nodes[iE];
            
            b.Child1 = iA;
            b.ParentOrNext = a.ParentOrNext;
            a.ParentOrNext = iB;
            
            UpdateParent(iA, iB, b.ParentOrNext);
            
            if (d.Height > e.Height)
            {
                return BalanceLeftCase1(iA, a, iB, b, iD, d, iE, e);
            }
            
            return BalanceLeftCase2(iA, a, iB, b, iD, d, iE, e);
        }
        
        /// <summary>
        ///     Updates the parent using the specified old child
        /// </summary>
        /// <param name="oldChild">The old child</param>
        /// <param name="newChild">The new child</param>
        /// <param name="parent">The parent</param>
        private void UpdateParent(int oldChild, int newChild, int parent)
        {
            if (parent != NullNode)
            {
                if (nodes[parent].Child1 == oldChild)
                {
                    nodes[parent].Child1 = newChild;
                }
                else
                {
                    nodes[parent].Child2 = newChild;
                }
            }
            else
            {
                root = newChild;
            }
        }
        
        /// <summary>
        ///     Balances the right case 1 using the specified i a
        /// </summary>
        /// <param name="iA">The </param>
        /// <param name="a">The </param>
        /// <param name="iC">The </param>
        /// <param name="c">The </param>
        /// <param name="iF">The </param>
        /// <param name="f">The </param>
        /// <param name="iG">The </param>
        /// <param name="g">The </param>
        /// <returns>The </returns>
        private int BalanceRightCase1(int iA, TreeNode<T> a, int iC, TreeNode<T> c, int iF, TreeNode<T> f, int iG, TreeNode<T> g)
        {
            c.Child2 = iF;
            a.Child2 = iG;
            g.ParentOrNext = iA;
            a.Aabb.Combine(ref nodes[a.Child1].Aabb, ref g.Aabb);
            c.Aabb.Combine(ref a.Aabb, ref f.Aabb);
            
            a.Height = 1 + Math.Max(nodes[a.Child1].Height, g.Height);
            c.Height = 1 + Math.Max(a.Height, f.Height);
            
            return iC;
        }
        
        /// <summary>
        ///     Balances the right case 2 using the specified i a
        /// </summary>
        /// <param name="iA">The </param>
        /// <param name="a">The </param>
        /// <param name="iC">The </param>
        /// <param name="c">The </param>
        /// <param name="iF">The </param>
        /// <param name="f">The </param>
        /// <param name="iG">The </param>
        /// <param name="g">The </param>
        /// <returns>The </returns>
        private int BalanceRightCase2(int iA, TreeNode<T> a, int iC, TreeNode<T> c, int iF, TreeNode<T> f, int iG, TreeNode<T> g)
        {
            c.Child2 = iG;
            a.Child2 = iF;
            f.ParentOrNext = iA;
            a.Aabb.Combine(ref nodes[a.Child1].Aabb, ref f.Aabb);
            c.Aabb.Combine(ref a.Aabb, ref g.Aabb);
            
            a.Height = 1 + Math.Max(nodes[a.Child1].Height, f.Height);
            c.Height = 1 + Math.Max(a.Height, g.Height);
            
            return iC;
        }
        
        /// <summary>
        ///     Balances the left case 1 using the specified i a
        /// </summary>
        /// <param name="iA">The </param>
        /// <param name="a">The </param>
        /// <param name="iB">The </param>
        /// <param name="b">The </param>
        /// <param name="iD">The </param>
        /// <param name="d">The </param>
        /// <param name="iE">The </param>
        /// <param name="e">The </param>
        /// <returns>The </returns>
        private int BalanceLeftCase1(int iA, TreeNode<T> a, int iB, TreeNode<T> b, int iD, TreeNode<T> d, int iE, TreeNode<T> e)
        {
            b.Child2 = iD;
            a.Child1 = iE;
            e.ParentOrNext = iA;
            a.Aabb.Combine(ref nodes[a.Child2].Aabb, ref e.Aabb);
            b.Aabb.Combine(ref a.Aabb, ref d.Aabb);
            
            a.Height = 1 + Math.Max(nodes[a.Child2].Height, e.Height);
            b.Height = 1 + Math.Max(a.Height, d.Height);
            
            return iB;
        }
        
        /// <summary>
        ///     Balances the left case 2 using the specified i a
        /// </summary>
        /// <param name="iA">The </param>
        /// <param name="a">The </param>
        /// <param name="iB">The </param>
        /// <param name="b">The </param>
        /// <param name="iD">The </param>
        /// <param name="d">The </param>
        /// <param name="iE">The </param>
        /// <param name="e">The </param>
        /// <returns>The </returns>
        private int BalanceLeftCase2(int iA, TreeNode<T> a, int iB, TreeNode<T> b, int iD, TreeNode<T> d, int iE, TreeNode<T> e)
        {
            b.Child2 = iE;
            a.Child1 = iD;
            d.ParentOrNext = iA;
            a.Aabb.Combine(ref nodes[a.Child2].Aabb, ref d.Aabb);
            b.Aabb.Combine(ref a.Aabb, ref e.Aabb);
            
            a.Height = 1 + Math.Max(nodes[a.Child2].Height, d.Height);
            b.Height = 1 + Math.Max(a.Height, e.Height);
            
            return iB;
        }
        
        /// <summary>Compute the height of a sub-tree.</summary>
        /// <param name="nodeId">The node id to use as parent.</param>
        /// <returns>The height of the tree.</returns>
        private int ComputeHeight(int nodeId)
        {
            TreeNode<T> node = nodes[nodeId];
            
            if (node.IsLeaf())
            {
                return 0;
            }
            
            int height1 = ComputeHeight(node.Child1);
            int height2 = ComputeHeight(node.Child2);
            return 1 + Math.Max(height1, height2);
        }
        
        /// <summary>Compute the height of the entire tree.</summary>
        /// <returns>The height of the tree.</returns>
        public int ComputeHeight()
        {
            int height = ComputeHeight(root);
            return height;
        }
        
        /// <summary>Shift the origin of the nodes</summary>
        /// <param name="newOrigin">The displacement to use.</param>
        public void ShiftOrigin(ref Vector2 newOrigin)
        {
            for (int i = 0; i < nodeCapacity; ++i)
            {
                nodes[i].Aabb.LowerBound -= newOrigin;
                nodes[i].Aabb.UpperBound -= newOrigin;
            }
        }
    }
}