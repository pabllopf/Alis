// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StablePriorityQueue.cs
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
using System.Collections;
using System.Collections.Generic;

namespace Alis.Extension.Math.HighSpeedPriorityQueue
{
    /// <summary>
    ///     A copy of FastPriorityQueue which is also stable - that is, when two nodes are enqueued with the same priority,
    ///     they
    ///     are always dequeued in the same order.
    ///     See https://github.com/BlueRaja/High-Speed-Priority-Queue-for-C-Sharp/wiki/Getting-Started for more information
    /// </summary>
    /// <typeparam name="T">The values in the queue.  Must extend the StablePriorityQueueNode class</typeparam>
    public sealed class StablePriorityQueue<T> : IFixedSizePriorityQueue<T, float>
        where T : StablePriorityQueueNode
    {
        /// <summary>
        ///     The nodes
        /// </summary>
        private T[] _nodes;

        /// <summary>
        ///     The num nodes
        /// </summary>
        private int _numNodes;

        /// <summary>
        ///     The num nodes ever enqueued
        /// </summary>
        private long _numNodesEverEnqueued;

        /// <summary>
        ///     Instantiate a new Priority Queue
        /// </summary>
        /// <param name="maxNodes">The max nodes ever allowed to be enqueued (going over this will cause undefined behavior)</param>
        public StablePriorityQueue(int maxNodes)
        {
            _numNodes = 0;
            _nodes = new T[maxNodes + 1];
            _numNodesEverEnqueued = 0;
        }

        /// <summary>
        ///     Returns the number of nodes in the queue.
        ///     O(1)
        /// </summary>
        public int Count => _numNodes;

        /// <summary>
        ///     Returns the maximum number of items that can be enqueued at once in this queue.  Once you hit this number ( once
        ///     Count == MaxSize),
        ///     attempting to enqueue another item will cause undefined behavior.  O(1)
        /// </summary>
        public int MaxSize => _nodes.Length - 1;

        /// <summary>
        ///     Removes every node from the queue.
        ///     O(n) (So, don't do this often!)
        /// </summary>
        public void Clear()
        {
            Array.Clear(_nodes, 1, _numNodes);
            _numNodes = 0;
        }

        /// <summary>
        ///     Returns (in O(1)!) whether the given node is in the queue.
        ///     If node is or has been previously added to another queue, the result is undefined unless oldQueue.ResetNode(node)
        ///     has been called
        ///     O(1)
        /// </summary>
        public bool Contains(T item) => _nodes[item.QueueIndex] == item;

        /// <summary>
        ///     Enqueue a node to the priority queue.  Lower values are placed in front. Ties are broken by first-in-first-out.
        ///     If the queue is full, the result is undefined.
        ///     If the node is already enqueued, the result is undefined.
        ///     If node is or has been previously added to another queue, the result is undefined unless oldQueue.ResetNode(node)
        ///     has been called
        ///     O(log n)
        /// </summary>
        public void Enqueue(T item, float priority)
        {
            item.Priority = priority;
            _numNodes++;
            _nodes[_numNodes] = item;
            item.QueueIndex = _numNodes;
            item.InsertionIndex = _numNodesEverEnqueued++;
            CascadeUp(item);
        }

        /// <summary>
        ///     Removes the head of the queue (node with minimum priority; ties are broken by order of insertion), and returns it.
        ///     If queue is empty, result is undefined
        ///     O(log n)
        /// </summary>
        public T Dequeue()
        {
            T returnMe = _nodes[1];
            //If the node is already the last node, we can remove it immediately
            if (_numNodes == 1)
            {
                _nodes[1] = null;
                _numNodes = 0;
                return returnMe;
            }

            //Swap the node with the last node
            T formerLastNode = _nodes[_numNodes];
            _nodes[1] = formerLastNode;
            formerLastNode.QueueIndex = 1;
            _nodes[_numNodes] = null;
            _numNodes--;

            //Now bubble formerLastNode (which is no longer the last node) down
            CascadeDown(formerLastNode);
            return returnMe;
        }

        /// <summary>
        ///     Resize the queue so it can accept more nodes.  All currently enqueued nodes are remain.
        ///     Attempting to decrease the queue size to a size too small to hold the existing nodes results in undefined behavior
        ///     O(n)
        /// </summary>
        public void Resize(int maxNodes)
        {
            T[] newArray = new T[maxNodes + 1];
            int highestIndexToCopy = System.Math.Min(maxNodes, _numNodes);
            Array.Copy(_nodes, newArray, highestIndexToCopy + 1);
            _nodes = newArray;
        }

        /// <summary>
        ///     Returns the head of the queue, without removing it (use Dequeue() for that).
        ///     If the queue is empty, behavior is undefined.
        ///     O(1)
        /// </summary>
        public T First => _nodes[1];

        /// <summary>
        ///     This method must be called on a node every time its priority changes while it is in the queue.
        ///     <b>Forgetting to call this method will result in a corrupted queue!</b>
        ///     Calling this method on a node not in the queue results in undefined behavior
        ///     O(log n)
        /// </summary>
        public void UpdatePriority(T item, float priority)
        {
            item.Priority = priority;
            OnNodeUpdated(item);
        }

        /// <summary>
        ///     Removes a node from the queue.  The node does not need to be the head of the queue.
        ///     If the node is not in the queue, the result is undefined.  If unsure, check Contains() first
        ///     O(log n)
        /// </summary>
        public void Remove(T item)
        {
            //If the node is already the last node, we can remove it immediately
            if (item.QueueIndex == _numNodes)
            {
                _nodes[_numNodes] = null;
                _numNodes--;
                return;
            }

            //Swap the node with the last node
            T formerLastNode = _nodes[_numNodes];
            _nodes[item.QueueIndex] = formerLastNode;
            formerLastNode.QueueIndex = item.QueueIndex;
            _nodes[_numNodes] = null;
            _numNodes--;

            //Now bubble formerLastNode (which is no longer the last node) up or down as appropriate
            OnNodeUpdated(formerLastNode);
        }

        /// <summary>
        ///     By default, nodes that have been previously added to one queue cannot be added to another queue.
        ///     If you need to do this, please call originalQueue.ResetNode(node) before attempting to add it in the new queue
        /// </summary>
        public void ResetNode(T node)
        {
            node.QueueIndex = 0;
        }


        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>An enumerator of t</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 1; i <= _numNodes; i++)
            {
                yield return _nodes[i];
            }
        }

        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        //Performance appears to be slightly better when this is NOT inlined o_O
        /// <summary>
        ///     Cascades the up using the specified node
        /// </summary>
        /// <param name="node">The node</param>
        private void CascadeUp(T node)
        {
            int parent;
            if (node.QueueIndex > 1)
            {
                parent = node.QueueIndex >> 1;
                T parentNode = _nodes[parent];
                if (HasHigherPriority(parentNode, node))
                {
                    return;
                }

                //Node has lower priority value, so move parent down the heap to make room
                _nodes[node.QueueIndex] = parentNode;
                parentNode.QueueIndex = node.QueueIndex;

                node.QueueIndex = parent;
            }
            else
            {
                return;
            }

            while (parent > 1)
            {
                parent >>= 1;
                T parentNode = _nodes[parent];
                if (HasHigherPriority(parentNode, node))
                {
                    break;
                }

                //Node has lower priority value, so move parent down the heap to make room
                _nodes[node.QueueIndex] = parentNode;
                parentNode.QueueIndex = node.QueueIndex;

                node.QueueIndex = parent;
            }

            _nodes[node.QueueIndex] = node;
        }

        /// <summary>
        ///     Cascades the down using the specified node
        /// </summary>
        /// <param name="node">The node</param>
        private void CascadeDown(T node)
        {
            int finalQueueIndex = node.QueueIndex;

            while (true)
            {
                int childLeftIndex = 2 * finalQueueIndex;
                if (IsLeafNode(childLeftIndex))
                {
                    break;
                }

                int childRightIndex = childLeftIndex + 1;
                T childLeft = _nodes[childLeftIndex];
                T childRight = childRightIndex <= _numNodes ? _nodes[childRightIndex] : null;

                int higherPriorityChildIndex = GetHigherPriorityChildIndex(childLeft, childRight, childLeftIndex, childRightIndex);
                T higherPriorityChild = _nodes[higherPriorityChildIndex];

                if (HasHigherPriority(node, higherPriorityChild))
                {
                    break;
                }

                Swap(node, higherPriorityChild, finalQueueIndex, higherPriorityChildIndex);
                finalQueueIndex = higherPriorityChildIndex;
            }

            node.QueueIndex = finalQueueIndex;
            _nodes[finalQueueIndex] = node;
        }

        /// <summary>
        ///     Describes whether this instance is leaf node
        /// </summary>
        /// <param name="childIndex">The child index</param>
        /// <returns>The bool</returns>
        private bool IsLeafNode(int childIndex) => childIndex > _numNodes;

        /// <summary>
        ///     Gets the higher priority child index using the specified child left
        /// </summary>
        /// <param name="childLeft">The child left</param>
        /// <param name="childRight">The child right</param>
        /// <param name="childLeftIndex">The child left index</param>
        /// <param name="childRightIndex">The child right index</param>
        /// <returns>The int</returns>
        private int GetHigherPriorityChildIndex(T childLeft, T childRight, int childLeftIndex, int childRightIndex)
        {
            if (childRight == null)
            {
                return childLeftIndex;
            }

            return HasHigherPriority(childLeft, childRight) ? childLeftIndex : childRightIndex;
        }

        /// <summary>
        ///     Swaps the node
        /// </summary>
        /// <param name="node">The node</param>
        /// <param name="child">The child</param>
        /// <param name="nodeIndex">The node index</param>
        /// <param name="childIndex">The child index</param>
        private void Swap(T node, T child, int nodeIndex, int childIndex)
        {
            _nodes[nodeIndex] = child;
            child.QueueIndex = nodeIndex;
            _nodes[childIndex] = node;
            node.QueueIndex = childIndex;
        }

        /// <summary>
        ///     Returns true if 'higher' has higher priority than 'lower', false otherwise.
        ///     Note that calling HasHigherPriority(node, node) ( both arguments the same node) will return false
        /// </summary>
        private bool HasHigherPriority(T higher, T lower) => higher.Priority < lower.Priority ||
                                                             ((System.Math.Abs(higher.Priority - lower.Priority) < 0.01F) && (higher.InsertionIndex < lower.InsertionIndex));

        /// <summary>
        ///     Ons the node updated using the specified node
        /// </summary>
        /// <param name="node">The node</param>
        private void OnNodeUpdated(T node)
        {
            //Bubble the updated node up or down as appropriate
            int parentIndex = node.QueueIndex >> 1;

            if ((parentIndex > 0) && HasHigherPriority(node, _nodes[parentIndex]))
            {
                CascadeUp(node);
            }
            else
            {
                //Note that CascadeDown will be called if parentNode == node (that is, node is the root)
                CascadeDown(node);
            }
        }

        /// <summary>
        ///     <b>Should not be called in production code.</b>
        ///     Checks to make sure the queue is still in a valid state.  Used for testing/debugging the queue.
        /// </summary>
        public bool IsValidQueue()
        {
            for (int i = 1; i < _nodes.Length; i++)
            {
                if (_nodes[i] != null)
                {
                    int childLeftIndex = 2 * i;
                    if ((childLeftIndex < _nodes.Length) && (_nodes[childLeftIndex] != null) && HasHigherPriority(_nodes[childLeftIndex], _nodes[i]))
                    {
                        return false;
                    }

                    int childRightIndex = childLeftIndex + 1;
                    if ((childRightIndex < _nodes.Length) && (_nodes[childRightIndex] != null) && HasHigherPriority(_nodes[childRightIndex], _nodes[i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}