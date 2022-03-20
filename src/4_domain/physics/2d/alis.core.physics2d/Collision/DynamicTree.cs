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
using System.Numerics;
using System.Runtime.CompilerServices;
using Alis.Core.Physics2D.Common;
using Math = System.Math;

namespace Alis.Core.Physics2D.Collision
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal sealed class DynamicTree
    {
        /// <summary>
        /// The free nodes
        /// </summary>
        private Proxy _freeNodes;
        /// <summary>
        /// The nodes
        /// </summary>
        private Node[] _nodes;
        /// <summary>
        /// The root
        /// </summary>
        private Proxy _root;

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicTree"/> class
        /// </summary>
        public DynamicTree()
        {
            _root = Proxy.Free;
            _nodes = new Node[256];

            // Build a linked list for the free list.
            ref Node node = ref _nodes[0];
            int l = Capacity - 1;

            for (int i = 0; i < l; i++, node = ref _nodes[i])
            {
                node.Parent = i + 1;
                node.Height = -1;
            }

            ref Node lastNode = ref _nodes[^1];

            lastNode.Parent = Proxy.Free;
            lastNode.Height = -1;
        }

        /// <summary>
        /// Gets the value of the capacity
        /// </summary>
        public int Capacity => _nodes.Length;

        /// <summary>
        /// Gets the value of the height
        /// </summary>
        public int Height
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _root == Proxy.Free ? 0 : _nodes[_root].Height;
        }

        /// <summary>
        /// Gets or sets the value of the node count
        /// </summary>
        public int NodeCount { get; private set; }

        /// <summary>
        /// Gets the value of the max balance
        /// </summary>
        public int MaxBalance
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                int maxBal = 0;

                for (int i = 0; i < Capacity; ++i)
                {
                    ref Node node = ref _nodes[i];
                    if (node.Height <= 1)
                    {
                        continue;
                    }

                    ref Node child1Node = ref _nodes[node.Child1];
                    ref Node child2Node = ref _nodes[node.Child2];

                    int bal = Math.Abs(child2Node.Height - child1Node.Height);
                    maxBal = Math.Max(maxBal, bal);
                }

                return maxBal;
            }
        }

        /// <summary>
        /// Gets the value of the area ratio
        /// </summary>
        public float AreaRatio
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                if (_root == Proxy.Free)
                {
                    return 0;
                }

                ref Node rootNode = ref _nodes[_root];
                float rootPeri = rootNode.Aabb.GetPerimeter();

                float totalPeri = 0f;

                for (int i = 0; i < Capacity; ++i)
                {
                    ref Node node = ref _nodes[i];
                    if (node.Height < 0)
                    {
                        continue;
                    }

                    totalPeri += node.Aabb.GetPerimeter();
                }

                return totalPeri / rootPeri;
            }
        }


        /// <summary>
        /// Gets the value of the debug allocated nodes enumerable
        /// </summary>
        private IEnumerable<(Proxy, Node)> DebugAllocatedNodesEnumerable
        {
            get
            {
                for (int i = 0; i < _nodes.Length; i++)
                {
                    Node node = _nodes[i];
                    if (!node.IsFree)
                    {
                        yield return (i, node);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the value of the debug allocated nodes
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        private (Proxy, Node)[] DebugAllocatedNodes
        {
            get
            {
                (Proxy, Node)[] data = new (Proxy, Node)[NodeCount];
                int i = 0;
                foreach ((Proxy, Node) x in DebugAllocatedNodesEnumerable)
                {
                    data[i++] = x;
                }

                return data;
            }
        }

        /// <summary>
        /// The aabb extend size
        /// </summary>
        private const float AABBExtendSize = 1f / 32;

        /// <summary>
        /// The aabb multiplier
        /// </summary>
        private const float AABBMultiplier = 2f;

        /// <summary>
        /// Growths the func using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The int</returns>
        private static int GrowthFunc(int x) => x + 256;

        /// <summary>Allocate a node from the pool. Grow the pool if necessary.</summary>
        /// <remarks>
        ///     If allocation occurs, references to <see cref="Node" />s will be invalid.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ref Node AllocateNode(out Proxy proxy)
        {
            // Expand the node pool as needed.
            if (_freeNodes == Proxy.Free)
            {
                // Separate method to aid inlining since this is a cold path.
                Expand();
            }

            // Peel a node off the free list.
            Proxy alloc = _freeNodes;
            ref Node allocNode = ref _nodes[alloc];
            Assert(allocNode.IsFree);
            _freeNodes = allocNode.Parent;
            Assert(_freeNodes == -1 || _nodes[_freeNodes].IsFree);
            allocNode.Parent = Proxy.Free;
            allocNode.Child1 = Proxy.Free;
            allocNode.Child2 = Proxy.Free;
            allocNode.Height = 0;
            ++NodeCount;
            proxy = alloc;
            return ref allocNode;

            void Expand()
            {
                Assert(NodeCount == Capacity);

                // The free list is empty. Rebuild a bigger pool.
                int newNodeCap = GrowthFunc(Capacity);

                if (newNodeCap <= Capacity)
                {
                    throw new InvalidOperationException(
                        "Growth function returned invalid new capacity, must be greater than current capacity.");
                }

                Node[] oldNodes = _nodes;

                _nodes = new Node[newNodeCap];

                Array.Copy(oldNodes, _nodes, NodeCount);

                // Build a linked list for the free list. The parent
                // pointer becomes the "next" pointer.
                int l = _nodes.Length - 1;
                ref Node node = ref _nodes[NodeCount];
                for (int i = NodeCount; i < l; ++i, node = ref _nodes[i])
                {
                    node.Parent = i + 1;
                    node.Height = -1;
                }

                ref Node lastNode = ref _nodes[l];
                lastNode.Parent = Proxy.Free;
                lastNode.Height = -1;
                _freeNodes = NodeCount;
            }
        }

        /// <summary>
        ///     Return a node to the pool.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void FreeNode(Proxy proxy)
        {
            ref Node node = ref _nodes[proxy];
            node.Parent = _freeNodes;
            node.Height = -1;
#if DEBUG_DYNAMIC_TREE
            node.Child1 = Proxy.Free;
            node.Child2 = Proxy.Free;
#endif
            node.UserData = default(object);
            _freeNodes = proxy;
            --NodeCount;
        }

        /// <summary>
        ///     Create a proxy in the tree as a leaf node.
        /// </summary>
        public Proxy CreateProxy(in AABB aabb, object userData)
        {
            ref Node proxy = ref AllocateNode(out Proxy proxyId);

            // Fatten the aabb.
            proxy.Aabb = aabb.Enlarged(AABBExtendSize);
            proxy.Height = 0;
            proxy.Moved = true;
            proxy.UserData = userData;

            InsertLeaf(proxyId);
            return proxyId;
        }

        /// <summary>
        /// Destroys the proxy using the specified proxy
        /// </summary>
        /// <param name="proxy">The proxy</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void DestroyProxy(Proxy proxy)
        {
            Assert(0 <= proxy && proxy < Capacity);
            Assert(_nodes[proxy].IsLeaf);

            RemoveLeaf(proxy);
            FreeNode(proxy);
        }

        /// <summary>
        /// Describes whether this instance move proxy
        /// </summary>
        /// <param name="proxy">The proxy</param>
        /// <param name="aabb">The aabb</param>
        /// <param name="displacement">The displacement</param>
        /// <returns>The bool</returns>
        public bool MoveProxy(Proxy proxy, in AABB aabb, Vector2 displacement)
        {
            Assert(0 <= proxy && proxy < Capacity);

            ref Node leafNode = ref _nodes[proxy];

            Assert(leafNode.IsLeaf);

            // Extend AABB
            Vector2 ext = new Vector2(AABBExtendSize, AABBExtendSize);
            AABB fatAabb = aabb.Enlarged(AABBExtendSize);

            // Predict AABB movement
            Vector2 d = displacement * AABBMultiplier;

            // pls can we make math types mutable this sucks.
            float l = fatAabb.lowerBound.X;
            float b = fatAabb.lowerBound.Y;
            float r = fatAabb.upperBound.X;
            float t = fatAabb.upperBound.Y;

            if (d.X < 0)
            {
                l += d.X;
            }
            else
            {
                r += d.X;
            }

            if (d.Y < 0)
            {
                b += d.Y;
            }
            else
            {
                t += d.Y;
            }

            fatAabb = new AABB(new Vector2(l, b), new Vector2(r, t));

            ref AABB treeAabb = ref leafNode.Aabb;

            if (treeAabb.Contains(aabb))
            {
                // The tree AABB still contains the object, but it might be too large.
                // Perhaps the object was moving fast but has since gone to sleep.
                // The huge AABB is larger than the new fat AABB.
                Vector2 growAmount = new Vector2(4, 4) * ext;
                AABB hugeAabb = new AABB(
                    fatAabb.lowerBound - growAmount,
                    fatAabb.upperBound + growAmount);

                if (hugeAabb.Contains(treeAabb))
                {
                    // The tree AABB contains the object AABB and the tree AABB is
                    // not too large. No tree update needed.
                    return false;
                }

                // Otherwise the tree AABB is huge and needs to be shrunk
            }

            RemoveLeaf(proxy);

            leafNode.Aabb = fatAabb;

            InsertLeaf(proxy);

            leafNode.Moved = true;

            return true;
        }

        /// <summary>
        /// Gets the user data using the specified proxy
        /// </summary>
        /// <param name="proxy">The proxy</param>
        /// <returns>The object</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object GetUserData(Proxy proxy) => _nodes[proxy].UserData;

        /// <summary>
        /// Describes whether this instance was moved
        /// </summary>
        /// <param name="proxy">The proxy</param>
        /// <returns>The bool</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool WasMoved(Proxy proxy) => _nodes[proxy].Moved;

        /// <summary>
        /// Clears the moved using the specified proxy
        /// </summary>
        /// <param name="proxy">The proxy</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ClearMoved(Proxy proxy)
        {
            _nodes[proxy].Moved = false;
        }

        /// <summary>
        /// Gets the fat aabb using the specified proxy
        /// </summary>
        /// <param name="proxy">The proxy</param>
        /// <returns>The aabb</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AABB GetFatAABB(Proxy proxy) => _nodes[proxy].Aabb;

        /// <summary>
        /// Removes the leaf using the specified leaf
        /// </summary>
        /// <param name="leaf">The leaf</param>
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void RemoveLeaf(Proxy leaf)
        {
            if (leaf == _root)
            {
                _root = Proxy.Free;
                return;
            }

            ref Node leafNode = ref _nodes[leaf];
            Assert(leafNode.IsLeaf);
            Proxy parent = leafNode.Parent;
            ref Node parentNode = ref _nodes[parent];
            Proxy grandParent = parentNode.Parent;
            Proxy sibling = parentNode.Child1 == leaf
                ? parentNode.Child2
                : parentNode.Child1;

            ref Node siblingNode = ref _nodes[sibling];

            if (grandParent != Proxy.Free)
            {
                // Destroy parent and connect sibling to grandParent.
                ref Node grandParentNode = ref _nodes[grandParent];
                if (grandParentNode.Child1 == parent)
                {
                    grandParentNode.Child1 = sibling;
                }
                else
                {
                    grandParentNode.Child2 = sibling;
                }

                siblingNode.Parent = grandParent;
                FreeNode(parent);

                // Adjust ancestor bounds.
                Balance(grandParent);
            }
            else
            {
                _root = sibling;
                siblingNode.Parent = Proxy.Free;
                FreeNode(parent);
            }

            Validate();
        }

        /// <summary>
        /// Inserts the leaf using the specified leaf
        /// </summary>
        /// <param name="leaf">The leaf</param>
        private void InsertLeaf(Proxy leaf)
        {
            if (_root == Proxy.Free)
            {
                _root = leaf;
                _nodes[_root].Parent = Proxy.Free;
                return;
            }

            Validate();

            // Find the best sibling for this node
            ref Node leafNode = ref _nodes[leaf];
            ref AABB leafAabb = ref leafNode.Aabb;

            Proxy index = _root;
#if DEBUG
			var loopCount = 0;
#endif
            for (;;)
            {
#if DEBUG
				Assert(loopCount++ < Capacity * 2);
#endif

                ref Node indexNode = ref _nodes[index];
                if (indexNode.IsLeaf)
                {
                    break;
                }

                // assert no loops
                Assert(_nodes[indexNode.Child1].Child1 != index);
                Assert(_nodes[indexNode.Child1].Child2 != index);
                Assert(_nodes[indexNode.Child2].Child1 != index);
                Assert(_nodes[indexNode.Child2].Child2 != index);

                Proxy child1 = indexNode.Child1;
                Proxy child2 = indexNode.Child2;
                ref Node child1Node = ref _nodes[child1];
                ref Node child2Node = ref _nodes[child2];
                ref AABB indexAabb = ref indexNode.Aabb;
                float indexPeri = indexAabb.GetPerimeter();
                AABB combinedAabb = default(AABB);
                combinedAabb = AABB.Combine(indexAabb, leafAabb);
                float combinedPeri = combinedAabb.GetPerimeter();
                // Cost of creating a new parent for this node and the new leaf
                float cost = 2 * combinedPeri;
                // Minimum cost of pushing the leaf further down the tree
                float inheritCost = 2 * (combinedPeri - indexPeri);

                // Cost of descending into child1
                float cost1 = EstimateCost(leafAabb, child1Node) + inheritCost;
                // Cost of descending into child2
                float cost2 = EstimateCost(leafAabb, child2Node) + inheritCost;

                // Descend according to the minimum cost.
                if (cost < cost1 && cost < cost2)
                {
                    break;
                }

                // Descend
                index = cost1 < cost2 ? child1 : child2;
            }

            Proxy sibling = index;

            // Create a new parent.
            ref Node newParentNode = ref AllocateNode(out Proxy newParent);
            ref Node siblingNode = ref _nodes[sibling];

            Proxy oldParent = siblingNode.Parent;

            newParentNode.Parent = oldParent;
            newParentNode.Aabb = AABB.Combine(leafAabb, siblingNode.Aabb);
            newParentNode.Height = 1 + siblingNode.Height;

            ref Node proxyNode = ref _nodes[leaf];
            if (oldParent != Proxy.Free)
            {
                // The sibling was not the root.
                ref Node oldParentNode = ref _nodes[oldParent];

                if (oldParentNode.Child1 == sibling)
                {
                    oldParentNode.Child1 = newParent;
                }
                else
                {
                    oldParentNode.Child2 = newParent;
                }

                newParentNode.Child1 = sibling;
                newParentNode.Child2 = leaf;
                siblingNode.Parent = newParent;
                proxyNode.Parent = newParent;
            }
            else
            {
                // The sibling was the root.
                newParentNode.Child1 = sibling;
                newParentNode.Child2 = leaf;
                siblingNode.Parent = newParent;
                proxyNode.Parent = newParent;
                _root = newParent;
            }

            // Walk back up the tree fixing heights and AABBs
            Balance(proxyNode.Parent);

            Validate();
        }


        /// <summary>
        /// Estimates the cost using the specified base aabb
        /// </summary>
        /// <param name="baseAabb">The base aabb</param>
        /// <param name="node">The node</param>
        /// <returns>The cost</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float EstimateCost(in AABB baseAabb, in Node node)
        {
            float cost = AABB.Combine(baseAabb, node.Aabb).GetPerimeter();

            if (!node.IsLeaf)
            {
                cost -= node.Aabb.GetPerimeter();
            }

            return cost;
        }

        /// <summary>
        /// Balances the index
        /// </summary>
        /// <param name="index">The index</param>
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Balance(Proxy index)
        {
            while (index != Proxy.Free)
            {
                index = BalanceStep(index);

                ref Node indexNode = ref _nodes[index];

                Proxy child1 = indexNode.Child1;
                Proxy child2 = indexNode.Child2;

                Assert(child1 != Proxy.Free);
                Assert(child2 != Proxy.Free);

                ref Node child1Node = ref _nodes[child1];
                ref Node child2Node = ref _nodes[child2];

                indexNode.Height = Math.Max(child1Node.Height, child2Node.Height) + 1;
                indexNode.Aabb = AABB.Combine(child1Node.Aabb, child2Node.Aabb);

                index = indexNode.Parent;
            }

            Validate();
        }

        /// <summary>
        ///     Perform a left or right rotation if node A is imbalanced.
        /// </summary>
        /// <returns>The new root index.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Proxy BalanceStep(Proxy iA)
        {
            ref Node a = ref _nodes[iA];

            if (a.IsLeaf || a.Height < 2)
            {
                return iA;
            }

            Proxy iB = a.Child1;
            Proxy iC = a.Child2;
            Assert(iA != iB);
            Assert(iA != iC);
            Assert(iB != iC);

            ref Node b = ref _nodes[iB];
            ref Node c = ref _nodes[iC];

            int balance = c.Height - b.Height;

            // Rotate C up
            if (balance > 1)
            {
                Proxy iF = c.Child1;
                Proxy iG = c.Child2;
                Assert(iC != iF);
                Assert(iC != iG);
                Assert(iF != iG);

                ref Node f = ref _nodes[iF];
                ref Node g = ref _nodes[iG];

                // A <> C

                // this creates a loop ...
                c.Child1 = iA;
                c.Parent = a.Parent;
                a.Parent = iC;

                if (c.Parent == Proxy.Free)
                {
                    _root = iC;
                }
                else
                {
                    ref Node cParent = ref _nodes[c.Parent];
                    if (cParent.Child1 == iA)
                    {
                        cParent.Child1 = iC;
                    }
                    else
                    {
                        Assert(cParent.Child2 == iA);
                        cParent.Child2 = iC;
                    }
                }

                // Rotate
                if (f.Height > g.Height)
                {
                    c.Child2 = iF;
                    a.Child2 = iG;
                    g.Parent = iA;
                    a.Aabb = AABB.Combine(b.Aabb, g.Aabb);
                    c.Aabb = AABB.Combine(a.Aabb, f.Aabb);

                    a.Height = Math.Max(b.Height, g.Height) + 1;
                    c.Height = Math.Max(a.Height, f.Height) + 1;
                }
                else
                {
                    c.Child2 = iG;
                    a.Child2 = iF;
                    f.Parent = iA;
                    a.Aabb = AABB.Combine(b.Aabb, f.Aabb);
                    c.Aabb = AABB.Combine(a.Aabb, g.Aabb);

                    a.Height = Math.Max(b.Height, f.Height) + 1;
                    c.Height = Math.Max(a.Height, g.Height) + 1;
                }

                return iC;
            }

            // Rotate B up
            if (balance < -1)
            {
                Proxy iD = b.Child1;
                Proxy iE = b.Child2;
                Assert(iB != iD);
                Assert(iB != iE);
                Assert(iD != iE);

                ref Node d = ref _nodes[iD];
                ref Node e = ref _nodes[iE];

                // A <> B

                // this creates a loop ...
                b.Child1 = iA;
                b.Parent = a.Parent;
                a.Parent = iB;

                if (b.Parent == Proxy.Free)
                {
                    _root = iB;
                }
                else
                {
                    ref Node bParent = ref _nodes[b.Parent];
                    if (bParent.Child1 == iA)
                    {
                        bParent.Child1 = iB;
                    }
                    else
                    {
                        Assert(bParent.Child2 == iA);
                        bParent.Child2 = iB;
                    }
                }

                // Rotate
                if (d.Height > e.Height)
                {
                    b.Child2 = iD;
                    a.Child1 = iE;
                    e.Parent = iA;
                    a.Aabb = AABB.Combine(c.Aabb, e.Aabb);
                    b.Aabb = AABB.Combine(a.Aabb, d.Aabb);

                    a.Height = Math.Max(c.Height, e.Height) + 1;
                    b.Height = Math.Max(a.Height, d.Height) + 1;
                }
                else
                {
                    b.Child2 = iE;
                    a.Child1 = iD;
                    d.Parent = iA;
                    a.Aabb = AABB.Combine(c.Aabb, d.Aabb);
                    b.Aabb = AABB.Combine(a.Aabb, e.Aabb);

                    a.Height = Math.Max(c.Height, d.Height) + 1;
                    b.Height = Math.Max(a.Height, e.Height) + 1;
                }

                return iB;
            }

            return iA;
        }

        /// <summary>
        /// Computes the height
        /// </summary>
        /// <returns>The int</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int ComputeHeight()
            => ComputeHeight(_root);

        /// <summary>
        ///     Compute the height of a sub-tree.
        /// </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        private int ComputeHeight(Proxy proxy)
        {
            ref Node node = ref _nodes[proxy];
            if (node.IsLeaf)
            {
                return 0;
            }

            return Math.Max(
                ComputeHeight(node.Child1),
                ComputeHeight(node.Child2)
            ) + 1;
        }

        /// <summary>
        /// Rebuilds the bottom up using the specified free
        /// </summary>
        /// <param name="free">The free</param>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void RebuildBottomUp(int free = 0)
        {
            Proxy[] proxies = new Proxy[NodeCount + free];
            int count = 0;

            // Build array of leaves. Free the rest.
            for (int i = 0; i < Capacity; ++i)
            {
                ref Node node = ref _nodes[i];
                if (node.Height < 0)
                {
                    // free node in pool
                    continue;
                }

                Proxy proxy = i;
                if (node.IsLeaf)
                {
                    node.Parent = Proxy.Free;
                    proxies[count++] = proxy;
                }
                else
                {
                    FreeNode(proxy);
                }
            }

            while (count > 1)
            {
                float minCost = float.MaxValue;

                int iMin = -1;
                int jMin = -1;

                for (int i = 0; i < count; ++i)
                {
                    ref AABB aabbI = ref _nodes[proxies[i]].Aabb;

                    for (int j = i + 1; j < count; ++j)
                    {
                        ref AABB aabbJ = ref _nodes[proxies[j]].Aabb;

                        float cost = AABB.Combine(aabbI, aabbJ).GetPerimeter();

                        if (cost >= minCost)
                        {
                            continue;
                        }

                        iMin = i;
                        jMin = j;
                        minCost = cost;
                    }
                }

                Proxy child1 = proxies[iMin];
                Proxy child2 = proxies[jMin];

                ref Node parentNode = ref AllocateNode(out Proxy parent);
                ref Node child1Node = ref _nodes[child1];
                ref Node child2Node = ref _nodes[child2];

                parentNode.Child1 = child1;
                parentNode.Child2 = child2;
                parentNode.Height = Math.Max(child1Node.Height, child2Node.Height) + 1;
                parentNode.Aabb = AABB.Combine(child1Node.Aabb, child2Node.Aabb);
                parentNode.Parent = Proxy.Free;

                child1Node.Parent = parent;
                child2Node.Parent = parent;

                proxies[jMin] = proxies[count - 1];
                proxies[iMin] = parent;
                --count;
            }

            _root = proxies[0];

            Validate();
        }

        /// <summary>
        /// Shifts the origin using the specified new origin
        /// </summary>
        /// <param name="newOrigin">The new origin</param>
        public void ShiftOrigin(in Vector2 newOrigin)
        {
            for (int i = 0; i < _nodes.Length; i++)
            {
                ref Node node = ref _nodes[i];
                Vector2 lb = node.Aabb.lowerBound;
                Vector2 tr = node.Aabb.upperBound;

                node.Aabb = new AABB(lb - newOrigin, tr - newOrigin);
            }
        }

        /// <summary>
        /// Queries the query callback
        /// </summary>
        /// <param name="queryCallback">The query callback</param>
        /// <param name="aabb">The aabb</param>
        public void Query(Func<int, bool> queryCallback, in AABB aabb)
        {
            using GrowableStack<Proxy> stack = new GrowableStack<Proxy>(stackalloc Proxy[256]);
            stack.Push(_root);

            while (stack._count != 0)
            {
                Proxy nodeId = stack.Pop();
                if (nodeId == Proxy.Free)
                {
                    continue;
                }

                // Skip bounds check with Unsafe.Add().
                Node node = _nodes[nodeId];
                if (node.Aabb.Intersects(aabb))
                {
                    if (node.IsLeaf)
                    {
                        bool proceed = queryCallback(nodeId);
                        if (proceed == false)
                        {
                            return;
                        }
                    }
                    else
                    {
                        stack.Push(node.Child1);
                        stack.Push(node.Child2);
                    }
                }
            }
        }

        /// <summary>
        /// Rays the cast using the specified ray cast callback
        /// </summary>
        /// <param name="RayCastCallback">The ray cast callback</param>
        /// <param name="input">The input</param>
        public void RayCast(Func<RayCastInput, int, float> RayCastCallback, in RayCastInput input)
        {
            Vector2 p1 = input.p1;
            Vector2 p2 = input.p2;
            Vector2 r = p2 - p1;
            //Debug.Assert(r.LengthSquared() > 0.0f);
            r = Vector2.Normalize(r);

            // v is perpendicular to the segment.
            Vector2 v = Vectex.Cross(1.0f, r);
            Vector2 absV = Vector2.Abs(v);

            // Separating axis for segment (Gino, p80).
            // |dot(v, p1 - c)| > dot(|v|, h)

            float maxFraction = input.maxFraction;

            // Build a bounding box for the segment.
            AABB segmentAABB;
            {
                Vector2 t = p1 + maxFraction * (p2 - p1);
                segmentAABB.lowerBound = Vector2.Min(p1, t);
                segmentAABB.upperBound = Vector2.Max(p1, t);
            }

            using GrowableStack<Proxy> stack = new GrowableStack<Proxy>(stackalloc Proxy[256]);
            stack.Push(_root);

            while (stack._count != 0)
            {
                Proxy nodeId = stack.Pop();
                if (nodeId == Proxy.Free)
                {
                    continue;
                }

                // Skip bounds check with Unsafe.Add().
                Node node = _nodes[nodeId];
                if (node.Aabb.Intersects(segmentAABB) == false)
                {
                    continue;
                }

                // Separating axis for segment (Gino, p80).
                // |dot(v, p1 - c)| > dot(|v|, h)
                Vector2 c = node.Aabb.GetCenter();
                Vector2 h = node.Aabb.GetExtents();
                float separation = Math.Abs(Vector2.Dot(v, p1 - c)) - Vector2.Dot(absV, h);

                if (separation > 0)
                {
                    continue;
                }

                if (node.IsLeaf)
                {
                    RayCastInput subInput = input;

                    float value = RayCastCallback(subInput, nodeId);

                    if (value == 0f)
                    {
                        // The client has terminated the ray cast.
                        return;
                    }

                    if (value > 0)
                    {
                        // Update segment bounding box.
                        maxFraction = value;
                        Vector2 t = p1 + (p2 - p1) * maxFraction;
                        segmentAABB = new AABB(
                            Vector2.Min(p1, t),
                            Vector2.Max(p1, t));
                    }
                }
                else
                {
                    stack.Push(node.Child1);
                    stack.Push(node.Child2);
                }
            }
        }

        /// <summary>
        /// Validates this instance
        /// </summary>
        [Conditional("DEBUG")]
        private void Validate()
        {
            Validate(_root);

            int freeCount = 0;
            Proxy freeIndex = _freeNodes;
            while (freeIndex != Proxy.Free)
            {
                Assert(0 <= freeIndex);
                Assert(freeIndex < Capacity);
                freeIndex = _nodes[freeIndex].Parent;
                ++freeCount;
            }

            Assert(Height == ComputeHeight());

            Assert(NodeCount + freeCount == Capacity);
        }

        /// <summary>
        /// Validates the proxy
        /// </summary>
        /// <param name="proxy">The proxy</param>
        [Conditional("DEBUG")]
        private void Validate(Proxy proxy)
        {
            if (proxy == Proxy.Free)
            {
                return;
            }

            ref Node node = ref _nodes[proxy];

            if (proxy == _root)
            {
                Assert(node.Parent == Proxy.Free);
            }

            Proxy child1 = node.Child1;
            Proxy child2 = node.Child2;

            if (node.IsLeaf)
            {
                Assert(child1 == Proxy.Free);
                Assert(child2 == Proxy.Free);
                Assert(node.Height == 0);
                return;
            }

            Assert(0 <= child1);
            Assert(child1 < Capacity);
            Assert(0 <= child2);
            Assert(child2 < Capacity);

            ref Node child1Node = ref _nodes[child1];
            ref Node child2Node = ref _nodes[child2];

            Assert(child1Node.Parent == proxy);
            Assert(child2Node.Parent == proxy);

            int height1 = child1Node.Height;
            int height2 = child2Node.Height;

            int height = 1 + Math.Max(height1, height2);

            Assert(node.Height == height);

            ref AABB aabb = ref node.Aabb;
            Assert(aabb.Contains(child1Node.Aabb));
            Assert(aabb.Contains(child2Node.Aabb));

            Validate(child1);
            Validate(child2);
        }

        /// <summary>
        /// Validates the height using the specified proxy
        /// </summary>
        /// <param name="proxy">The proxy</param>
        [Conditional("DEBUG_DYNAMIC_TREE")]
        private void ValidateHeight(Proxy proxy)
        {
            if (proxy == Proxy.Free)
            {
                return;
            }

            ref Node node = ref _nodes[proxy];

            if (node.IsLeaf)
            {
                Assert(node.Height == 0);
                return;
            }

            Proxy child1 = node.Child1;
            Proxy child2 = node.Child2;
            ref Node child1Node = ref _nodes[child1];
            ref Node child2Node = ref _nodes[child2];

            int height1 = child1Node.Height;
            int height2 = child2Node.Height;

            int height = 1 + Math.Max(height1, height2);

            Assert(node.Height == height);
        }

        /// <summary>
        /// Asserts the assertion
        /// </summary>
        /// <param name="assertion">The assertion</param>
        /// <param name="member">The member</param>
        /// <param name="file">The file</param>
        /// <param name="line">The line</param>
        /// <exception cref="InvalidOperationException"></exception>
        [Conditional("DEBUG"), DebuggerNonUserCode, DebuggerHidden, DebuggerStepThrough,
         MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Assert(bool assertion, [CallerMemberName] string? member = default(string?),
            [CallerFilePath] string? file = default(string?), [CallerLineNumber] int line = default(int))
        {
            if (assertion)
            {
                return;
            }

            string msg = $"Assertion failure in {member} ({file}:{line})";
            Debug.Print(msg);
            Debugger.Break();
            throw new InvalidOperationException(msg);
        }

        /// <summary>
        /// The proxy
        /// </summary>
        internal readonly struct Proxy : IEquatable<Proxy>, IComparable<Proxy>
        {
            /// <summary>
            /// The value
            /// </summary>
            private readonly int _value;

            /// <summary>
            /// The free
            /// </summary>
            public static readonly Proxy Free = -1;

            /// <summary>
            /// Initializes a new instance of the <see cref="Proxy"/> class
            /// </summary>
            /// <param name="v">The </param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Proxy(int v) => _value = v;

            /// <summary>
            /// Describes whether this instance equals
            /// </summary>
            /// <param name="other">The other</param>
            /// <returns>The bool</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Equals(Proxy other)
                => _value == other._value;

            /// <summary>
            /// Compares the to using the specified other
            /// </summary>
            /// <param name="other">The other</param>
            /// <returns>The int</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int CompareTo(Proxy other)
                => _value.CompareTo(other._value);

            /// <summary>
            /// Describes whether this instance equals
            /// </summary>
            /// <param name="obj">The obj</param>
            /// <returns>The bool</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override bool Equals(object? obj)
                => obj is Proxy other && Equals(other);

            /// <summary>
            /// Gets the hash code
            /// </summary>
            /// <returns>The int</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override int GetHashCode() => _value;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator int(Proxy n) => n._value;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Proxy(int v) => new Proxy(v);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Proxy a, Proxy b) => a._value == b._value;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Proxy a, Proxy b) => a._value != b._value;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator >(Proxy a, Proxy b) => a._value > b._value;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator <(Proxy a, Proxy b) => a._value < b._value;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator >=(Proxy a, Proxy b) => a._value >= b._value;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator <=(Proxy a, Proxy b) => a._value <= b._value;

            /// <summary>
            /// Returns the string
            /// </summary>
            /// <returns>The string</returns>
            public override string ToString()
                => _value.ToString();
        }

        /// <summary>
        /// The node
        /// </summary>
        private struct Node
        {
            /// <summary>
            /// The aabb
            /// </summary>
            public AABB Aabb;
            /// <summary>
            /// The parent
            /// </summary>
            public Proxy Parent;
            /// <summary>
            /// The child
            /// </summary>
            public Proxy Child1;
            /// <summary>
            /// The child
            /// </summary>
            public Proxy Child2;

            /// <summary>
            /// The user data
            /// </summary>
            public object UserData;

            /// <summary>
            /// The height
            /// </summary>
            public int Height;
            /// <summary>
            /// The moved
            /// </summary>
            public bool Moved;

            /// <summary>
            /// Gets the value of the is leaf
            /// </summary>
            public bool IsLeaf
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => Child2 == Proxy.Free;
            }

            /// <summary>
            /// Gets the value of the is free
            /// </summary>
            public bool IsFree
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => Height == -1;
            }

            /// <summary>
            /// Returns the string
            /// </summary>
            /// <returns>The string</returns>
            public override string ToString()
                => $@"Parent: {(Parent == Proxy.Free ? "None" : Parent.ToString())}, {
                    (IsLeaf
                        ? Height == 0
                            ? $"Leaf: {UserData}"
                            : $"Leaf (invalid height of {Height}): {UserData}"
                        : IsFree
                            ? "Free"
                            : $"Branch at height {Height}, children: {Child1} and {Child2}")}";
        }
    }
}