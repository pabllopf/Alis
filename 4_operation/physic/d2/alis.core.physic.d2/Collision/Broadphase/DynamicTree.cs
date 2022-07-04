// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   DynamicTree.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Alis.Core.Physic.D2.Collision.RayCast;
using Alis.Core.Physic.D2.Config;
using Alis.Core.Physic.D2.Shared;
using Alis.Core.Physic.D2.Utilities;

namespace Alis.Core.Physic.D2.Collision.Broadphase
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
        private readonly Stack<int> raycastStack = new Stack<int>(256);

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

            // Build a linked list for the free list.
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
                if (this.root == NullNode)
                {
                    return 0.0f;
                }

                TreeNode<T> root = nodes[this.root];
                float rootArea = root.Aabb.Perimeter;

                float totalArea = 0.0f;
                for (int i = 0; i < nodeCapacity; ++i)
                {
                    TreeNode<T> node = nodes[i];
                    if (node.Height < 0)
                    {
                        // Free node in pool
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
        public int MaxBalance
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

                    Debug.Assert(!node.IsLeaf());

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

            // Fatten the AABB.
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
            Debug.Assert(0 <= proxyId && proxyId < nodeCapacity);
            Debug.Assert(nodes[proxyId].IsLeaf());

            RemoveLeaf(proxyId);
            FreeNode(proxyId);
        }

        /// <summary>
        ///     Move a proxy with a swepted AABB. If the proxy has moved outside of its fattened AABB, then the proxy is
        ///     removed from the tree and re-inserted. Otherwise the function returns immediately.
        /// </summary>
        /// <param name="proxyId">The proxy id.</param>
        /// <param name="aabb">The AABB.</param>
        /// <param name="displacement">The displacement.</param>
        /// <returns>true if the proxy was re-inserted.</returns>
        public bool MoveProxy(int proxyId, ref Aabb aabb, Vector2 displacement)
        {
            Debug.Assert(0 <= proxyId && proxyId < nodeCapacity);

            Debug.Assert(nodes[proxyId].IsLeaf());

            // Extend AABB
            Aabb fatAabb = new Aabb();
            Vector2 r = new Vector2(Settings.AabbExtension, Settings.AabbExtension);
            fatAabb.LowerBound = aabb.LowerBound - r;
            fatAabb.UpperBound = aabb.UpperBound + r;

            // Predict AABB movement
            Vector2 d = Settings.AabbMultiplier * displacement;

            if (d.X < 0.0f)
            {
                fatAabb.LowerBound.X += d.X;
            }
            else
            {
                fatAabb.UpperBound.X += d.X;
            }

            if (d.Y < 0.0f)
            {
                fatAabb.LowerBound.Y += d.Y;
            }
            else
            {
                fatAabb.UpperBound.Y += d.Y;
            }

            Aabb treeAabb = nodes[proxyId].Aabb;
            if (treeAabb.Contains(ref aabb))
            {
                // The tree AABB still contains the object, but it might be too large.
                // Perhaps the object was moving fast but has since gone to sleep.
                // The huge AABB is larger than the new fat AABB.
                Aabb hugeAabb = new Aabb
                {
                    LowerBound = fatAabb.LowerBound - 4.0f * r,
                    UpperBound = fatAabb.UpperBound + 4.0f * r
                };

                if (hugeAabb.Contains(ref treeAabb))
                {
                    // The tree AABB contains the object AABB and the tree AABB is
                    // not too large. No tree update needed.
                    return false;
                }

                // Otherwise the tree AABB is huge and needs to be shrunk
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
        public bool WasMoved(int proxyId)
        {
            Debug.Assert(0 <= proxyId && proxyId < nodeCapacity);
            return nodes[proxyId].Moved;
        }

        /// <summary>
        ///     Clears the moved using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        public void ClearMoved(int proxyId)
        {
            Debug.Assert(0 <= proxyId && proxyId < nodeCapacity);
            nodes[proxyId].Moved = false;
        }

        /// <summary>Get proxy user data.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proxyId">The proxy id.</param>
        /// <returns>the proxy user data or 0 if the id is invalid.</returns>
        public T GetUserData(int proxyId)
        {
            Debug.Assert(0 <= proxyId && proxyId < nodeCapacity);
            return nodes[proxyId].UserData;
        }

        /// <summary>Get the fat AABB for a proxy.</summary>
        /// <param name="proxyId">The proxy id.</param>
        /// <param name="fatAabb">The fat AABB.</param>
        public void GetFatAabb(int proxyId, out Aabb fatAabb)
        {
            Debug.Assert(0 <= proxyId && proxyId < nodeCapacity);
            fatAabb = nodes[proxyId].Aabb;
        }

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
        ///     Ray-cast against the proxies in the tree. This relies on the callback to perform a exact ray-cast in the case
        ///     were the proxy contains a Shape. The callback also performs the any collision filtering. This has performance
        ///     roughly
        ///     equal to k * log(n), where k is the number of collisions and n is the number of proxies in the tree.
        /// </summary>
        /// <param name="callback">A callback class that is called for each proxy that is hit by the ray.</param>
        /// <param name="input">The ray-cast input data. The ray extends from p1 to p1 + maxFraction * (p2 - p1).</param>
        public void RayCast(Func<RayCastInput, int, float> callback, ref RayCastInput input)
        {
            Vector2 p1 = input.Point1;
            Vector2 p2 = input.Point2;
            Vector2 r = p2 - p1;
            Debug.Assert(r.LengthSquared() > 0.0f);
            r = Vector2.Normalize(r);

            // v is perpendicular to the segment.
            Vector2 absV = MathUtils.Abs(new Vector2(-r.Y, r.X)); //Velcro: Inlined the 'v' variable

            // Separating axis for segment (Gino, p80).
            // |dot(v, p1 - c)| > dot(|v|, h)

            float maxFraction = input.MaxFraction;

            // Build a bounding box for the segment.
            Aabb segmentAabb = new Aabb();
            {
                Vector2 t = p1 + maxFraction * (p2 - p1);
                segmentAabb.LowerBound = Vector2.Min(p1, t);
                segmentAabb.UpperBound = Vector2.Max(p1, t);
            }

            raycastStack.Clear();
            raycastStack.Push(root);

            while (raycastStack.Count > 0)
            {
                int nodeId = raycastStack.Pop();
                if (nodeId == NullNode)
                {
                    continue;
                }

                TreeNode<T> node = nodes[nodeId];

                if (!Aabb.TestOverlap(ref node.Aabb, ref segmentAabb))
                {
                    continue;
                }

                // Separating axis for segment (Gino, p80).
                // |dot(v, p1 - c)| > dot(|v|, h)
                Vector2 c = node.Aabb.Center;
                Vector2 h = node.Aabb.Extents;
                float separation = Math.Abs(Vector2.Dot(new Vector2(-r.Y, r.X), p1 - c)) - Vector2.Dot(absV, h);
                if (separation > 0.0f)
                {
                    continue;
                }

                if (node.IsLeaf())
                {
                    RayCastInput subInput;
                    subInput.Point1 = input.Point1;
                    subInput.Point2 = input.Point2;
                    subInput.MaxFraction = maxFraction;

                    float value = callback(subInput, nodeId);

                    if (value == 0.0f)
                    {
                        // the client has terminated the raycast.
                        return;
                    }

                    if (value > 0.0f)
                    {
                        // Update segment bounding box.
                        maxFraction = value;
                        Vector2 t = p1 + maxFraction * (p2 - p1);
                        segmentAabb.LowerBound = Vector2.Min(p1, t);
                        segmentAabb.UpperBound = Vector2.Max(p1, t);
                    }
                }
                else
                {
                    raycastStack.Push(node.Child1);
                    raycastStack.Push(node.Child2);
                }
            }
        }

        /// <summary>
        ///     Allocates the node
        /// </summary>
        /// <returns>The node id</returns>
        private int AllocateNode()
        {
            // Expand the node pool as needed.
            if (freeList == NullNode)
            {
                Debug.Assert(nodeCount == nodeCapacity);

                // The free list is empty. Rebuild a bigger pool.
                TreeNode<T>[] oldNodes = nodes;
                nodeCapacity *= 2;
                nodes = new TreeNode<T>[nodeCapacity];
                Array.Copy(oldNodes, nodes, nodeCount);

                // Build a linked list for the free list. The parent
                // pointer becomes the "next" pointer.
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

            // Peel a node off the free list.
            int nodeId = freeList;
            freeList = nodes[nodeId].ParentOrNext;
            nodes[nodeId].ParentOrNext = NullNode;
            nodes[nodeId].Child1 = NullNode;
            nodes[nodeId].Child2 = NullNode;
            nodes[nodeId].Height = 0;
            nodes[nodeId].UserData = default(T?);
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
            Debug.Assert(0 <= nodeId && nodeId < nodeCapacity);
            Debug.Assert(0 < nodeCount);
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
                root = leaf;
                nodes[root].ParentOrNext = NullNode;
                return;
            }

            // Find the best sibling for this node
            Aabb leafAabb = nodes[leaf].Aabb;
            int index = root;
            while (!nodes[index].IsLeaf())
            {
                int child1 = nodes[index].Child1;
                int child2 = nodes[index].Child2;

                float area = nodes[index].Aabb.Perimeter;

                Aabb combinedAabb = new Aabb();
                combinedAabb.Combine(ref nodes[index].Aabb, ref leafAabb);
                float combinedArea = combinedAabb.Perimeter;

                // Cost of creating a new parent for this node and the new leaf
                float cost = 2.0f * combinedArea;

                // Minimum cost of pushing the leaf further down the tree
                float inheritanceCost = 2.0f * (combinedArea - area);

                // Cost of descending into child1
                float cost1;
                if (nodes[child1].IsLeaf())
                {
                    Aabb aabb = new Aabb();
                    aabb.Combine(ref leafAabb, ref nodes[child1].Aabb);
                    cost1 = aabb.Perimeter + inheritanceCost;
                }
                else
                {
                    Aabb aabb = new Aabb();
                    aabb.Combine(ref leafAabb, ref nodes[child1].Aabb);
                    float oldArea = nodes[child1].Aabb.Perimeter;
                    float newArea = aabb.Perimeter;
                    cost1 = newArea - oldArea + inheritanceCost;
                }

                // Cost of descending into child2
                float cost2;
                if (nodes[child2].IsLeaf())
                {
                    Aabb aabb = new Aabb();
                    aabb.Combine(ref leafAabb, ref nodes[child2].Aabb);
                    cost2 = aabb.Perimeter + inheritanceCost;
                }
                else
                {
                    Aabb aabb = new Aabb();
                    aabb.Combine(ref leafAabb, ref nodes[child2].Aabb);
                    float oldArea = nodes[child2].Aabb.Perimeter;
                    float newArea = aabb.Perimeter;
                    cost2 = newArea - oldArea + inheritanceCost;
                }

                // Descend according to the minimum cost.
                if (cost < cost1 && cost1 < cost2)
                {
                    break;
                }

                // Descend
                if (cost1 < cost2)
                {
                    index = child1;
                }
                else
                {
                    index = child2;
                }
            }

            int sibling = index;

            // Create a new parent.
            int oldParent = nodes[sibling].ParentOrNext;
            int newParent = AllocateNode();
            nodes[newParent].ParentOrNext = oldParent;
            nodes[newParent].UserData = default(T?);
            nodes[newParent].Aabb.Combine(ref leafAabb, ref nodes[sibling].Aabb);
            nodes[newParent].Height = nodes[sibling].Height + 1;

            if (oldParent != NullNode)
            {
                // The sibling was not the root.
                if (nodes[oldParent].Child1 == sibling)
                {
                    nodes[oldParent].Child1 = newParent;
                }
                else
                {
                    nodes[oldParent].Child2 = newParent;
                }

                nodes[newParent].Child1 = sibling;
                nodes[newParent].Child2 = leaf;
                nodes[sibling].ParentOrNext = newParent;
                nodes[leaf].ParentOrNext = newParent;
            }
            else
            {
                // The sibling was the root.
                nodes[newParent].Child1 = sibling;
                nodes[newParent].Child2 = leaf;
                nodes[sibling].ParentOrNext = newParent;
                nodes[leaf].ParentOrNext = newParent;
                root = newParent;
            }

            // Walk back up the tree fixing heights and AABBs
            index = nodes[leaf].ParentOrNext;
            while (index != NullNode)
            {
                index = Balance(index);

                int child1 = nodes[index].Child1;
                int child2 = nodes[index].Child2;

                Debug.Assert(child1 != NullNode);
                Debug.Assert(child2 != NullNode);

                nodes[index].Height = 1 + Math.Max(nodes[child1].Height, nodes[child2].Height);
                nodes[index].Aabb.Combine(ref nodes[child1].Aabb, ref nodes[child2].Aabb);

                index = nodes[index].ParentOrNext;
            }

            //Validate();
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
            int sibling;
            if (nodes[parent].Child1 == leaf)
            {
                sibling = nodes[parent].Child2;
            }
            else
            {
                sibling = nodes[parent].Child1;
            }

            if (grandParent != NullNode)
            {
                // Destroy parent and connect sibling to grandParent.
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

                // Adjust ancestor bounds.
                int index = grandParent;
                while (index != NullNode)
                {
                    index = Balance(index);

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

            //Validate();
        }

        /// <summary>Perform a left or right rotation if node A is imbalanced.</summary>
        /// <param name="iA"></param>
        /// <returns>the new root index.</returns>
        private int Balance(int iA)
        {
            Debug.Assert(iA != NullNode);

            TreeNode<T> a = nodes[iA];
            if (a.IsLeaf() || a.Height < 2)
            {
                return iA;
            }

            int iB = a.Child1;
            int iC = a.Child2;
            Debug.Assert(0 <= iB && iB < nodeCapacity);
            Debug.Assert(0 <= iC && iC < nodeCapacity);

            TreeNode<T> b = nodes[iB];
            TreeNode<T> c = nodes[iC];

            int balance = c.Height - b.Height;

            // Rotate C up
            if (balance > 1)
            {
                int iF = c.Child1;
                int iG = c.Child2;
                TreeNode<T> f = nodes[iF];
                TreeNode<T> g = nodes[iG];
                Debug.Assert(0 <= iF && iF < nodeCapacity);
                Debug.Assert(0 <= iG && iG < nodeCapacity);

                // Swap A and C
                c.Child1 = iA;
                c.ParentOrNext = a.ParentOrNext;
                a.ParentOrNext = iC;

                // A's old parent should point to C
                if (c.ParentOrNext != NullNode)
                {
                    if (nodes[c.ParentOrNext].Child1 == iA)
                    {
                        nodes[c.ParentOrNext].Child1 = iC;
                    }
                    else
                    {
                        Debug.Assert(nodes[c.ParentOrNext].Child2 == iA);
                        nodes[c.ParentOrNext].Child2 = iC;
                    }
                }
                else
                {
                    root = iC;
                }

                // Rotate
                if (f.Height > g.Height)
                {
                    c.Child2 = iF;
                    a.Child2 = iG;
                    g.ParentOrNext = iA;
                    a.Aabb.Combine(ref b.Aabb, ref g.Aabb);
                    c.Aabb.Combine(ref a.Aabb, ref f.Aabb);

                    a.Height = 1 + Math.Max(b.Height, g.Height);
                    c.Height = 1 + Math.Max(a.Height, f.Height);
                }
                else
                {
                    c.Child2 = iG;
                    a.Child2 = iF;
                    f.ParentOrNext = iA;
                    a.Aabb.Combine(ref b.Aabb, ref f.Aabb);
                    c.Aabb.Combine(ref a.Aabb, ref g.Aabb);

                    a.Height = 1 + Math.Max(b.Height, f.Height);
                    c.Height = 1 + Math.Max(a.Height, g.Height);
                }

                return iC;
            }

            // Rotate B up
            if (balance < -1)
            {
                int iD = b.Child1;
                int iE = b.Child2;
                TreeNode<T> d = nodes[iD];
                TreeNode<T> e = nodes[iE];
                Debug.Assert(0 <= iD && iD < nodeCapacity);
                Debug.Assert(0 <= iE && iE < nodeCapacity);

                // Swap A and B
                b.Child1 = iA;
                b.ParentOrNext = a.ParentOrNext;
                a.ParentOrNext = iB;

                // A's old parent should point to B
                if (b.ParentOrNext != NullNode)
                {
                    if (nodes[b.ParentOrNext].Child1 == iA)
                    {
                        nodes[b.ParentOrNext].Child1 = iB;
                    }
                    else
                    {
                        Debug.Assert(nodes[b.ParentOrNext].Child2 == iA);
                        nodes[b.ParentOrNext].Child2 = iB;
                    }
                }
                else
                {
                    root = iB;
                }

                // Rotate
                if (d.Height > e.Height)
                {
                    b.Child2 = iD;
                    a.Child1 = iE;
                    e.ParentOrNext = iA;
                    a.Aabb.Combine(ref c.Aabb, ref e.Aabb);
                    b.Aabb.Combine(ref a.Aabb, ref d.Aabb);

                    a.Height = 1 + Math.Max(c.Height, e.Height);
                    b.Height = 1 + Math.Max(a.Height, d.Height);
                }
                else
                {
                    b.Child2 = iE;
                    a.Child1 = iD;
                    d.ParentOrNext = iA;
                    a.Aabb.Combine(ref c.Aabb, ref d.Aabb);
                    b.Aabb.Combine(ref a.Aabb, ref e.Aabb);

                    a.Height = 1 + Math.Max(c.Height, d.Height);
                    b.Height = 1 + Math.Max(a.Height, e.Height);
                }

                return iB;
            }

            return iA;
        }

        /// <summary>Compute the height of a sub-tree.</summary>
        /// <param name="nodeId">The node id to use as parent.</param>
        /// <returns>The height of the tree.</returns>
        public int ComputeHeight(int nodeId)
        {
            Debug.Assert(0 <= nodeId && nodeId < nodeCapacity);
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

        /// <summary>
        ///     Validates the structure using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        public void ValidateStructure(int index)
        {
            if (index == NullNode)
            {
                return;
            }

            if (index == root)
            {
                Debug.Assert(nodes[index].ParentOrNext == NullNode);
            }

            TreeNode<T> node = nodes[index];

            int child1 = node.Child1;
            int child2 = node.Child2;

            if (node.IsLeaf())
            {
                Debug.Assert(child1 == NullNode);
                Debug.Assert(child2 == NullNode);
                Debug.Assert(node.Height == 0);
                return;
            }

            Debug.Assert(0 <= child1 && child1 < nodeCapacity);
            Debug.Assert(0 <= child2 && child2 < nodeCapacity);

            Debug.Assert(nodes[child1].ParentOrNext == index);
            Debug.Assert(nodes[child2].ParentOrNext == index);

            ValidateStructure(child1);
            ValidateStructure(child2);
        }

        /// <summary>
        ///     Validates the metrics using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        public void ValidateMetrics(int index)
        {
            if (index == NullNode)
            {
                return;
            }

            TreeNode<T> node = nodes[index];

            int child1 = node.Child1;
            int child2 = node.Child2;

            if (node.IsLeaf())
            {
                Debug.Assert(child1 == NullNode);
                Debug.Assert(child2 == NullNode);
                Debug.Assert(node.Height == 0);
                return;
            }

            Debug.Assert(0 <= child1 && child1 < nodeCapacity);
            Debug.Assert(0 <= child2 && child2 < nodeCapacity);

            int height1 = nodes[child1].Height;
            int height2 = nodes[child2].Height;
            int height = 1 + Math.Max(height1, height2);
            Debug.Assert(node.Height == height);

            Aabb aabb = new Aabb();
            aabb.Combine(ref nodes[child1].Aabb, ref nodes[child2].Aabb);

            Debug.Assert(aabb.LowerBound == node.Aabb.LowerBound);
            Debug.Assert(aabb.UpperBound == node.Aabb.UpperBound);

            ValidateMetrics(child1);
            ValidateMetrics(child2);
        }

        /// <summary>Validate this tree. For testing.</summary>
        public void Validate()
        {
            ValidateStructure(root);
            ValidateMetrics(root);

            int freeCount = 0;
            int freeIndex = freeList;
            while (freeIndex != NullNode)
            {
                Debug.Assert(0 <= freeIndex && freeIndex < nodeCapacity);
                freeIndex = nodes[freeIndex].ParentOrNext;
                ++freeCount;
            }

            Debug.Assert(Height == ComputeHeight());

            Debug.Assert(nodeCount + freeCount == nodeCapacity);
        }

        /// <summary>Build an optimal tree. Very expensive. For testing.</summary>
        public void RebuildBottomUp()
        {
            int[] nodes = new int[nodeCount];
            int count = 0;

            // Build array of leaves. Free the rest.
            for (int i = 0; i < nodeCapacity; ++i)
            {
                if (this.nodes[i].Height < 0)
                {
                    // free node in pool
                    continue;
                }

                if (this.nodes[i].IsLeaf())
                {
                    this.nodes[i].ParentOrNext = NullNode;
                    nodes[count] = i;
                    ++count;
                }
                else
                {
                    FreeNode(i);
                }
            }

            while (count > 1)
            {
                float minCost = MathConstants.MaxFloat;
                int iMin = -1, jMin = -1;
                for (int i = 0; i < count; ++i)
                {
                    Aabb aabBi = this.nodes[nodes[i]].Aabb;

                    for (int j = i + 1; j < count; ++j)
                    {
                        Aabb aabBj = this.nodes[nodes[j]].Aabb;
                        Aabb b = new Aabb();
                        b.Combine(ref aabBi, ref aabBj);
                        float cost = b.Perimeter;
                        if (cost < minCost)
                        {
                            iMin = i;
                            jMin = j;
                            minCost = cost;
                        }
                    }
                }

                int index1 = nodes[iMin];
                int index2 = nodes[jMin];
                TreeNode<T> child1 = this.nodes[index1];
                TreeNode<T> child2 = this.nodes[index2];

                int parentIndex = AllocateNode();
                TreeNode<T> parent = this.nodes[parentIndex];
                parent.Child1 = index1;
                parent.Child2 = index2;
                parent.Height = 1 + Math.Max(child1.Height, child2.Height);
                parent.Aabb.Combine(ref child1.Aabb, ref child2.Aabb);
                parent.ParentOrNext = NullNode;

                child1.ParentOrNext = parentIndex;
                child2.ParentOrNext = parentIndex;

                nodes[jMin] = nodes[count - 1];
                nodes[iMin] = parentIndex;
                --count;
            }

            root = nodes[0];

            Validate();
        }

        /// <summary>Shift the origin of the nodes</summary>
        /// <param name="newOrigin">The displacement to use.</param>
        public void ShiftOrigin(ref Vector2 newOrigin)
        {
            // Build array of leaves. Free the rest.
            for (int i = 0; i < nodeCapacity; ++i)
            {
                nodes[i].Aabb.LowerBound -= newOrigin;
                nodes[i].Aabb.UpperBound -= newOrigin;
            }
        }
    }
}