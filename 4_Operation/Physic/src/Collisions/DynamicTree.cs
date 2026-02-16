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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     A dynamic tree arranges data in a binary tree to accelerate
    ///     queries such as volume queries and ray casts. Leafs are proxies
    ///     with an AABB. In the tree we expand the proxy AABB by Settings.b2_fatAABBFactor
    ///     so that the proxy AABB is bigger than the client object. This allows the client
    ///     object to move by small amounts without triggering a tree update.
    ///     Nodes are pooled and relocatable, so we use node indices rather than pointers.
    /// </summary>
    public class DynamicTree<TNode>
    {
        /// <summary>
        ///     The null node
        /// </summary>
        internal const int NullNode = -1;

        /// <summary>
        ///     The stack
        /// </summary>
        private readonly Stack<int> _queryStack = new Stack<int>(256);

        /// <summary>
        ///     The stack
        /// </summary>
        private readonly Stack<int> _raycastStack = new Stack<int>(256);

        /// <summary>
        ///     The free list
        /// </summary>
        private int _freeList;

        /// <summary>
        ///     The node capacity
        /// </summary>
        private int _nodeCapacity;

        /// <summary>
        ///     The node count
        /// </summary>
        private int _nodeCount;

        /// <summary>
        ///     The nodes
        /// </summary>
        private TreeNode<TNode>[] _nodes;

        /// <summary>
        ///     The root
        /// </summary>
        private int _root;

        /// <summary>
        ///     Constructing the tree initializes the node pool.
        /// </summary>
        public DynamicTree()
        {
            _root = NullNode;

            _nodeCapacity = 16;
            _nodeCount = 0;
            _nodes = new TreeNode<TNode>[_nodeCapacity];

            // Build a linked list for the free list.
            for (int i = 0; i < _nodeCapacity - 1; ++i)
            {
                _nodes[i].Next = i + 1;
                _nodes[i].Height = -1;
            }

            // build last node
            _nodes[_nodeCapacity - 1].Next = NullNode;
            _nodes[_nodeCapacity - 1].Height = -1;
            _freeList = 0;
        }

        /// <summary>
        ///     Compute the height of the binary tree in O(N) time. Should not be called often.
        /// </summary>
        public int Height
        {
            get
            {
                if (_root == NullNode)
                {
                    return 0;
                }

                return _nodes[_root].Height;
            }
        }

        /// <summary>
        ///     Get the ratio of the sum of the node areas to the root area.
        /// </summary>
        public float AreaRatio
        {
            get
            {
                if (_root == NullNode)
                {
                    return 0.0f;
                }

                //TreeNode<T>* root = &_nodes[_root];
                float rootArea = _nodes[_root].Aabb.Perimeter;

                float totalArea = 0.0f;
                for (int i = 0; i < _nodeCapacity; ++i)
                {
                    //TreeNode<T>* node = &_nodes[i];
                    if (_nodes[i].Height < 0)
                    {
                        // Free node in pool
                        continue;
                    }

                    totalArea += _nodes[i].Aabb.Perimeter;
                }

                return totalArea / rootArea;
            }
        }

        /// <summary>
        ///     Get the maximum balance of an node in the tree. The balance is the difference
        ///     in height of the two children of a node.
        /// </summary>
        public int MaxBalance
        {
            get
            {
                int maxBalance = 0;
                for (int i = 0; i < _nodeCapacity; ++i)
                {
                    //TreeNode<T>* node = &_nodes[i];
                    if (_nodes[i].Height <= 1)
                    {
                        continue;
                    }

                    int child1 = _nodes[i].Child1;
                    int child2 = _nodes[i].Child2;
                    int balance = Math.Abs(_nodes[child2].Height - _nodes[child1].Height);
                    maxBalance = Math.Max(maxBalance, balance);
                }

                return maxBalance;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="aabb"></param>
        /// <returns></returns>
        public int AddProxy(ref Aabb aabb)
        {
            int proxyId = AllocateNode();

            // Fatten the aabb.
            Vector2F r = new Vector2F(SettingEnv.AabbExtension, SettingEnv.AabbExtension);
            _nodes[proxyId].Aabb.LowerBound = aabb.LowerBound - r;
            _nodes[proxyId].Aabb.UpperBound = aabb.UpperBound + r;
            _nodes[proxyId].Height = 0;

            InsertLeaf(proxyId);

            return proxyId;
        }

        /// <summary>
        ///     OnDestroy a proxy. This asserts if the id is invalid.
        /// </summary>
        /// <param name="proxyId">The proxy id.</param>
        public void RemoveProxy(int proxyId)
        {
            RemoveLeaf(proxyId);
            FreeNode(proxyId);
        }

        /// <summary>
        ///     Move a proxy with a swepted AABB. If the proxy has moved outside of its fattened AABB,
        ///     then the proxy is removed from the tree and re-inserted. Otherwise
        ///     the function returns immediately.
        /// </summary>
        /// <param name="proxyId">The proxy id.</param>
        /// <param name="aabb">The aabb.</param>
        /// <param name="displacement">The displacement.</param>
        /// <returns>true if the proxy was re-inserted.</returns>
        public bool MoveProxy(int proxyId, ref Aabb aabb, Vector2F displacement)
        {
            if (_nodes[proxyId].Aabb.Contains(ref aabb))
            {
                return false;
            }

            RemoveLeaf(proxyId);

            // Extend AABB.
            Aabb b = aabb;
            Vector2F r = new Vector2F(SettingEnv.AabbExtension, SettingEnv.AabbExtension);
            b.LowerBound = b.LowerBound - r;
            b.UpperBound = b.UpperBound + r;

            // Predict AABB displacement.
            Vector2F d = SettingEnv.AabbMultiplier * displacement;

            if (d.X < 0.0f)
            {
                b.LowerBound.X += d.X;
            }
            else
            {
                b.UpperBound.X += d.X;
            }

            if (d.Y < 0.0f)
            {
                b.LowerBound.Y += d.Y;
            }
            else
            {
                b.UpperBound.Y += d.Y;
            }

            _nodes[proxyId].Aabb = b;

            InsertLeaf(proxyId);
            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="proxyId"></param>
        /// <param name="userData"></param>
        public void SetUserData(int proxyId, TNode userData)
        {
            _nodes[proxyId].UserData = userData;
        }

        /// <summary>
        ///     Get proxy user data.
        /// </summary>
        /// <param name="proxyId">The proxy id.</param>
        /// <returns>the proxy user data or 0 if the id is invalid.</returns>
        public TNode GetUserData(int proxyId) => _nodes[proxyId].UserData;

        /// <summary>
        ///     Get the fat AABB for a proxy.
        /// </summary>
        /// <param name="proxyId">The proxy id.</param>
        /// <param name="fatAabb">The fat AABB.</param>
        public void GetFatAabb(int proxyId, out Aabb fatAabb)
        {
            fatAabb = _nodes[proxyId].Aabb;
        }

        /// <summary>
        ///     Get the fat AABB for a proxy.
        /// </summary>
        /// <param name="proxyId">The proxy id.</param>
        /// <returns>The fat AABB.</returns>
        public Aabb GetFatAabb(int proxyId) => _nodes[proxyId].Aabb;

        /// <summary>
        ///     Test overlap of fat AABBs.
        /// </summary>
        /// <param name="proxyIdA">The proxy id A.</param>
        /// <param name="proxyIdB">The proxy id B.</param>
        public bool TestFatAabbOverlap(int proxyIdA, int proxyIdB) => Aabb.TestOverlap(ref _nodes[proxyIdA].Aabb, ref _nodes[proxyIdB].Aabb);

        /// <summary>
        ///     Query an AABB for overlapping proxies. The callback class
        ///     is called for each proxy that overlaps the supplied AABB.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <param name="aabb">The aabb.</param>
        public void Query(BroadPhaseQueryCallback callback, ref Aabb aabb)
        {
            _queryStack.Clear();
            _queryStack.Push(_root);

            while (_queryStack.Count > 0)
            {
                int nodeId = _queryStack.Pop();
                if (nodeId == NullNode)
                {
                    continue;
                }

                //TreeNode<T>* node = &_nodes[nodeId];

                if (Aabb.TestOverlap(ref _nodes[nodeId].Aabb, ref aabb))
                {
                    if (_nodes[nodeId].IsLeaf())
                    {
                        bool proceed = callback(nodeId);
                        if (!proceed)
                        {
                            return;
                        }
                    }
                    else
                    {
                        _queryStack.Push(_nodes[nodeId].Child1);
                        _queryStack.Push(_nodes[nodeId].Child2);
                    }
                }
            }
        }

        /// <summary>
        ///     Ray-cast against the proxies in the tree. This relies on the callback
        ///     to perform a exact ray-cast in the case were the proxy contains a Shape.
        ///     The callback also performs the any collision filtering. This has performance
        ///     roughly equal to k * log(n), where k is the number of collisions and n is the
        ///     number of proxies in the tree.
        /// </summary>
        /// <param name="callback">A callback class that is called for each proxy that is hit by the ray.</param>
        /// <param name="input">The ray-cast input data. The ray extends from p1 to p1 + maxFraction * (p2 - p1).</param>
        public void RayCast(BroadPhaseRayCastCallback callback, ref RayCastInput input)
        {
            Vector2F p1 = input.Point1;
            Vector2F p2 = input.Point2;
            Vector2F r = p2 - p1;
            r.Normalize();

            // v is perpendicular to the segment.
            Vector2F absV = MathUtils.Abs(new Vector2F(-r.Y, r.X)); //FPE: Inlined the 'v' variable

            // Separating axis for segment (Gino, p80).
            // |dot(v, p1 - c)| > dot(|v|, h)

            float maxFraction = input.MaxFraction;

            // Build a bounding box for the segment.
            Aabb segmentAabb = new Aabb();
            {
                Vector2F t = p1 + maxFraction * (p2 - p1);
                Vector2F.Min(ref p1, ref t, out segmentAabb.LowerBound);
                Vector2F.Max(ref p1, ref t, out segmentAabb.UpperBound);
            }

            _raycastStack.Clear();
            _raycastStack.Push(_root);

            while (_raycastStack.Count > 0)
            {
                int nodeId = _raycastStack.Pop();
                if (nodeId == NullNode)
                {
                    continue;
                }

                //TreeNode<T>* node = &_nodes[nodeId];

                if (!Aabb.TestOverlap(ref _nodes[nodeId].Aabb, ref segmentAabb))
                {
                    continue;
                }

                // Separating axis for segment (Gino, p80).
                // |dot(v, p1 - c)| > dot(|v|, h)
                Vector2F c = _nodes[nodeId].Aabb.Center;
                Vector2F h = _nodes[nodeId].Aabb.Extents;
                float separation = Math.Abs(Vector2F.Dot(new Vector2F(-r.Y, r.X), p1 - c)) - Vector2F.Dot(absV, h);
                if (separation > 0.0f)
                {
                    continue;
                }

                if (_nodes[nodeId].IsLeaf())
                {
                    RayCastInput subInput;
                    subInput.Point1 = input.Point1;
                    subInput.Point2 = input.Point2;
                    subInput.MaxFraction = maxFraction;

                    float value = callback(ref subInput, nodeId);

                    if (Math.Abs(value) < MathUtils.Epsilon)
                    {
                        // the client has terminated the raycast.
                        return;
                    }

                    if (value > 0.0f)
                    {
                        // Update segment bounding box.
                        maxFraction = value;
                        Vector2F t = p1 + maxFraction * (p2 - p1);
                        Vector2F.Min(ref p1, ref t, out segmentAabb.LowerBound);
                        Vector2F.Max(ref p1, ref t, out segmentAabb.UpperBound);
                    }
                }
                else
                {
                    _raycastStack.Push(_nodes[nodeId].Child1);
                    _raycastStack.Push(_nodes[nodeId].Child2);
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
            if (_freeList == NullNode)
            {
                // The free list is empty. Rebuild a bigger pool.
                TreeNode<TNode>[] oldNodes = _nodes;
                _nodeCapacity *= 2;
                _nodes = new TreeNode<TNode>[_nodeCapacity];
                Array.Copy(oldNodes, _nodes, _nodeCount);

                // Build a linked list for the free list.
                for (int i = _nodeCount; i < _nodeCapacity - 1; ++i)
                {
                    _nodes[i].Next = i + 1;
                    _nodes[i].Height = -1;
                }

                // build last node
                _nodes[_nodeCapacity - 1].Next = NullNode;
                _nodes[_nodeCapacity - 1].Height = -1;
                _freeList = _nodeCount;
            }

            // Peel a node off the free list.
            int nodeId = _freeList;
            _freeList = _nodes[nodeId].Next;
            // reinitialize node
            _nodes[nodeId].Parent = NullNode;
            _nodes[nodeId].Child1 = NullNode;
            _nodes[nodeId].Child2 = NullNode;
            _nodes[nodeId].Height = 0;
            _nodes[nodeId].UserData = default(TNode);
            ++_nodeCount;
            return nodeId;
        }

        /// <summary>
        ///     Frees the node using the specified node id
        /// </summary>
        /// <param name="nodeId">The node id</param>
        private void FreeNode(int nodeId)
        {
            _nodes[nodeId].Next = _freeList;
            _nodes[nodeId].Height = -1;
            _freeList = nodeId;
            --_nodeCount;
        }

        /// <summary>
        ///     Inserts the leaf using the specified leaf
        /// </summary>
        /// <param name="leaf">The leaf</param>
        private void InsertLeaf(int leaf)
        {
            if (_root == NullNode)
            {
                _root = leaf;
                _nodes[_root].Parent = NullNode;
                return;
            }

            // Find the best sibling for this node
            Aabb leafAabb = _nodes[leaf].Aabb;
            int index = _root;
            while (!_nodes[index].IsLeaf())
            {
                int child1 = _nodes[index].Child1;
                int child2 = _nodes[index].Child2;

                float area = _nodes[index].Aabb.Perimeter;

                Aabb combinedAabb = new Aabb();
                combinedAabb.Combine(ref _nodes[index].Aabb, ref leafAabb);
                float combinedArea = combinedAabb.Perimeter;

                // Cost of creating a new parent for this node and the new leaf
                float cost = 2.0f * combinedArea;

                // Minimum cost of pushing the leaf further down the tree
                float inheritanceCost = 2.0f * (combinedArea - area);

                // Cost of descending into child1
                float cost1;
                if (_nodes[child1].IsLeaf())
                {
                    Aabb aabb = new Aabb();
                    aabb.Combine(ref leafAabb, ref _nodes[child1].Aabb);
                    cost1 = aabb.Perimeter + inheritanceCost;
                }
                else
                {
                    Aabb aabb = new Aabb();
                    aabb.Combine(ref leafAabb, ref _nodes[child1].Aabb);
                    float oldArea = _nodes[child1].Aabb.Perimeter;
                    float newArea = aabb.Perimeter;
                    cost1 = newArea - oldArea + inheritanceCost;
                }

                // Cost of descending into child2
                float cost2;
                if (_nodes[child2].IsLeaf())
                {
                    Aabb aabb = new Aabb();
                    aabb.Combine(ref leafAabb, ref _nodes[child2].Aabb);
                    cost2 = aabb.Perimeter + inheritanceCost;
                }
                else
                {
                    Aabb aabb = new Aabb();
                    aabb.Combine(ref leafAabb, ref _nodes[child2].Aabb);
                    float oldArea = _nodes[child2].Aabb.Perimeter;
                    float newArea = aabb.Perimeter;
                    cost2 = newArea - oldArea + inheritanceCost;
                }

                // Descend according to the minimum cost.
                if ((cost < cost1) && (cost1 < cost2))
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
            int oldParent = _nodes[sibling].Parent;
            int newParent = AllocateNode();
            _nodes[newParent].Parent = oldParent;
            _nodes[newParent].UserData = default(TNode);
            _nodes[newParent].Aabb.Combine(ref leafAabb, ref _nodes[sibling].Aabb);
            _nodes[newParent].Height = _nodes[sibling].Height + 1;

            if (oldParent != NullNode)
            {
                // The sibling was not the root.
                if (_nodes[oldParent].Child1 == sibling)
                {
                    _nodes[oldParent].Child1 = newParent;
                }
                else
                {
                    _nodes[oldParent].Child2 = newParent;
                }

                _nodes[newParent].Child1 = sibling;
                _nodes[newParent].Child2 = leaf;
                _nodes[sibling].Parent = newParent;
                _nodes[leaf].Parent = newParent;
            }
            else
            {
                // The sibling was the root.
                _nodes[newParent].Child1 = sibling;
                _nodes[newParent].Child2 = leaf;
                _nodes[sibling].Parent = newParent;
                _nodes[leaf].Parent = newParent;
                _root = newParent;
            }

            // Walk back up the tree fixing heights and AABBs
            index = _nodes[leaf].Parent;
            while (index != NullNode)
            {
                index = Balance(index);

                int child1 = _nodes[index].Child1;
                int child2 = _nodes[index].Child2;

                _nodes[index].Height = 1 + Math.Max(_nodes[child1].Height, _nodes[child2].Height);
                _nodes[index].Aabb.Combine(ref _nodes[child1].Aabb, ref _nodes[child2].Aabb);

                index = _nodes[index].Parent;
            }

            //Validate();
        }

        /// <summary>
        ///     Removes the leaf using the specified leaf
        /// </summary>
        /// <param name="leaf">The leaf</param>
        private void RemoveLeaf(int leaf)
        {
            if (leaf == _root)
            {
                _root = NullNode;
                return;
            }

            int parent = _nodes[leaf].Parent;
            int grandParent = _nodes[parent].Parent;
            int sibling;
            if (_nodes[parent].Child1 == leaf)
            {
                sibling = _nodes[parent].Child2;
            }
            else
            {
                sibling = _nodes[parent].Child1;
            }

            if (grandParent != NullNode)
            {
                // OnDestroy parent and connect sibling to grandParent.
                if (_nodes[grandParent].Child1 == parent)
                {
                    _nodes[grandParent].Child1 = sibling;
                }
                else
                {
                    _nodes[grandParent].Child2 = sibling;
                }

                _nodes[sibling].Parent = grandParent;
                FreeNode(parent);

                // Adjust ancestor bounds.
                int index = grandParent;
                while (index != NullNode)
                {
                    index = Balance(index);

                    int child1 = _nodes[index].Child1;
                    int child2 = _nodes[index].Child2;

                    _nodes[index].Aabb.Combine(ref _nodes[child1].Aabb, ref _nodes[child2].Aabb);
                    _nodes[index].Height = 1 + Math.Max(_nodes[child1].Height, _nodes[child2].Height);

                    index = _nodes[index].Parent;
                }
            }
            else
            {
                _root = sibling;
                _nodes[sibling].Parent = NullNode;
                FreeNode(parent);
            }

            //Validate();
        }

        /// <summary>
        ///     Perform a left or right rotation if node N is imbalanced.
        /// </summary>
        /// <param name="iN"></param>
        /// <returns>the new root index.</returns>
        private int Balance(int iN)
        {
            //TreeNode<T>* N = &_nodes[iN];
            if (_nodes[iN].IsLeaf() || _nodes[iN].Height < 2)
            {
                return iN;
            }

            int iA = _nodes[iN].Child1;
            int iB = _nodes[iN].Child2;
            //TreeNode<T>* A = &_nodes[iA];
            //TreeNode<T>* B = &_nodes[iB];

            int balance = _nodes[iB].Height - _nodes[iA].Height;

            // Rotate B up
            if (balance > 1)
            {
                int iP = _nodes[iN].Parent;
                int iBa = _nodes[iB].Child1;
                int iBb = _nodes[iB].Child2;
                //TreeNode<T>* P  = &_nodes[iN->Parent];
                //TreeNode<T>* BA = &_nodes[iBA];
                //TreeNode<T>* BB = &_nodes[iBB];
                // Swap N and B
                _nodes[iB].Child1 = iN;
                _nodes[iB].Parent = _nodes[iN].Parent;
                _nodes[iN].Parent = iB;

                // N's old parent should point to B
                if (iP != NullNode)
                {
                    if (_nodes[iP].Child1 == iN)
                    {
                        _nodes[iP].Child1 = iB;
                    }
                    else
                    {
                        _nodes[iP].Child2 = iB;
                    }
                }
                else
                {
                    _root = iB;
                }

                // Rotate
                if (_nodes[iBa].Height > _nodes[iBb].Height)
                {
                    _nodes[iB].Child2 = iBa;
                    _nodes[iN].Child2 = iBb;
                    _nodes[iBb].Parent = iN;
                    _nodes[iN].Aabb.Combine(ref _nodes[iA].Aabb, ref _nodes[iBb].Aabb);
                    _nodes[iB].Aabb.Combine(ref _nodes[iN].Aabb, ref _nodes[iBa].Aabb);

                    _nodes[iN].Height = 1 + Math.Max(_nodes[iA].Height, _nodes[iBb].Height);
                    _nodes[iB].Height = 1 + Math.Max(_nodes[iN].Height, _nodes[iBa].Height);
                }
                else
                {
                    _nodes[iB].Child2 = iBb;
                    _nodes[iN].Child2 = iBa;
                    _nodes[iBa].Parent = iN;
                    _nodes[iN].Aabb.Combine(ref _nodes[iA].Aabb, ref _nodes[iBa].Aabb);
                    _nodes[iB].Aabb.Combine(ref _nodes[iN].Aabb, ref _nodes[iBb].Aabb);

                    _nodes[iN].Height = 1 + Math.Max(_nodes[iA].Height, _nodes[iBa].Height);
                    _nodes[iB].Height = 1 + Math.Max(_nodes[iN].Height, _nodes[iBb].Height);
                }

                return iB;
            }

            // Rotate A up
            if (balance < -1)
            {
                int iP = _nodes[iN].Parent;
                int iAa = _nodes[iA].Child1;
                int iAb = _nodes[iA].Child2;
                //TreeNode<T>* P  = &_nodes[iN->Parent];
                //TreeNode<T>* AA = &_nodes[iAA];
                //TreeNode<T>* AB = &_nodes[iAB];
                // Swap N and A
                _nodes[iA].Child1 = iN;
                _nodes[iA].Parent = _nodes[iN].Parent;
                _nodes[iN].Parent = iA;

                // N's old parent should point to A
                if (iP != NullNode)
                {
                    if (_nodes[iP].Child1 == iN)
                    {
                        _nodes[iP].Child1 = iA;
                    }
                    else
                    {
                        _nodes[iP].Child2 = iA;
                    }
                }
                else
                {
                    _root = iA;
                }

                // Rotate
                if (_nodes[iAa].Height > _nodes[iAb].Height)
                {
                    _nodes[iA].Child2 = iAa;
                    _nodes[iN].Child1 = iAb;
                    _nodes[iAb].Parent = iN;
                    _nodes[iN].Aabb.Combine(ref _nodes[iB].Aabb, ref _nodes[iAb].Aabb);
                    _nodes[iA].Aabb.Combine(ref _nodes[iN].Aabb, ref _nodes[iAa].Aabb);

                    _nodes[iN].Height = 1 + Math.Max(_nodes[iB].Height, _nodes[iAb].Height);
                    _nodes[iA].Height = 1 + Math.Max(_nodes[iN].Height, _nodes[iAa].Height);
                }
                else
                {
                    _nodes[iA].Child2 = iAb;
                    _nodes[iN].Child1 = iAa;
                    _nodes[iAa].Parent = iN;
                    _nodes[iN].Aabb.Combine(ref _nodes[iB].Aabb, ref _nodes[iAa].Aabb);
                    _nodes[iA].Aabb.Combine(ref _nodes[iN].Aabb, ref _nodes[iAb].Aabb);

                    _nodes[iN].Height = 1 + Math.Max(_nodes[iB].Height, _nodes[iAa].Height);
                    _nodes[iA].Height = 1 + Math.Max(_nodes[iN].Height, _nodes[iAb].Height);
                }

                return iA;
            }

            return iN;
        }

        /// <summary>
        ///     Compute the height of a sub-tree.
        /// </summary>
        /// <param name="nodeId">The node id to use as parent.</param>
        /// <returns>The height of the tree.</returns>
        public int ComputeHeight(int nodeId)
        {
            //TreeNode<T>* node = &_nodes[nodeId];

            if (_nodes[nodeId].IsLeaf())
            {
                return 0;
            }

            int height1 = ComputeHeight(_nodes[nodeId].Child1);
            int height2 = ComputeHeight(_nodes[nodeId].Child2);
            return 1 + Math.Max(height1, height2);
        }

        /// <summary>
        ///     Compute the height of the entire tree.
        /// </summary>
        /// <returns>The height of the tree.</returns>
        public int ComputeHeight()
        {
            int height = ComputeHeight(_root);
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

            if (index == _root)
            {
            }

            //TreeNode<T>* node = &_nodes[index];

            int child1 = _nodes[index].Child1;
            int child2 = _nodes[index].Child2;

            if (_nodes[index].IsLeaf())
            {
                return;
            }

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

            //TreeNode<T>* node = &_nodes[index];

            int child1 = _nodes[index].Child1;
            int child2 = _nodes[index].Child2;

            if (_nodes[index].IsLeaf())
            {
                return;
            }

            int height1 = _nodes[child1].Height;
            int height2 = _nodes[child2].Height;
            int height = 1 + Math.Max(height1, height2);
            Aabb aabb = new Aabb();
            aabb.Combine(ref _nodes[child1].Aabb, ref _nodes[child2].Aabb);

            ValidateMetrics(child1);
            ValidateMetrics(child2);
        }

        /// <summary>
        ///     Validate this tree. For testing.
        /// </summary>
        public void Validate()
        {
            ValidateStructure(_root);
            ValidateMetrics(_root);

            int freeCount = 0;
            int freeIndex = _freeList;
            while (freeIndex != NullNode)
            {
                freeIndex = _nodes[freeIndex].Next;
                ++freeCount;
            }
        }

        /// <summary>
        ///     Build an optimal tree. Very expensive. For testing.
        /// </summary>
        public void RebuildBottomUp()
        {
            int[] nodes = new int[_nodeCount];
            int count = 0;

            // Build array of leaves. Free the rest.
            for (int i = 0; i < _nodeCapacity; ++i)
            {
                if (_nodes[i].Height < 0)
                {
                    // free node in pool
                    continue;
                }

                if (_nodes[i].IsLeaf())
                {
                    _nodes[i].Parent = NullNode;
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
                float minCost = SettingEnv.MaxFloat;
                int iMin = -1, jMin = -1;
                for (int i = 0; i < count; ++i)
                {
                    Aabb aabBi = _nodes[nodes[i]].Aabb;

                    for (int j = i + 1; j < count; ++j)
                    {
                        Aabb aabBj = _nodes[nodes[j]].Aabb;
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
                //TreeNode<T>* child1 = &_nodes[index1];
                //TreeNode<T>* child2 = &_nodes[index2];

                int parentIndex = AllocateNode();
                //TreeNode<T>* parent = &_nodes[parentIndex];
                _nodes[parentIndex].Child1 = index1;
                _nodes[parentIndex].Child2 = index2;
                _nodes[parentIndex].Height = 1 + Math.Max(_nodes[index1].Height, _nodes[index2].Height);
                _nodes[parentIndex].Aabb.Combine(ref _nodes[index1].Aabb, ref _nodes[index2].Aabb);
                _nodes[parentIndex].Parent = NullNode;

                _nodes[index1].Parent = parentIndex;
                _nodes[index2].Parent = parentIndex;

                nodes[jMin] = nodes[count - 1];
                nodes[iMin] = parentIndex;
                --count;
            }

            _root = nodes[0];

            Validate();
        }

        /// <summary>
        ///     Shift the origin of the nodes
        /// </summary>
        /// <param name="newOrigin">The displacement to use.</param>
        public void ShiftOrigin(Vector2F newOrigin)
        {
            // Build array of leaves. Free the rest.
            for (int i = 0; i < _nodeCapacity; ++i)
            {
                _nodes[i].Aabb.LowerBound -= newOrigin;
                _nodes[i].Aabb.UpperBound -= newOrigin;
            }
        }
    }
}