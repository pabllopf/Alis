// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastPriorityQueue.cs
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
    ///     The fast priority queue class
    /// </summary>
    public sealed class FastPriorityQueue<T> : IFixedSizePriorityQueue<T, float>
        where T : FastPriorityQueueNode
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
        ///     Instantiate a new Priority Queue
        /// </summary>
        /// <param name="maxNodes">The max nodes ever allowed to be enqueued (going over this will cause undefined behavior)</param>
        public FastPriorityQueue(int maxNodes)
        {
            _numNodes = 0;
            _nodes = new T[maxNodes + 1];
        }

        /// <summary>
        ///     Returns the number of nodes in the queue.
        ///     O(1)
        /// </summary>
        public int Count => _numNodes;

        /// <summary>
        ///     Returns the maximum number of items that can be enqueued at once in this queue.  Once you hit this number (ie. once
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
        ///     Enqueue a node to the priority queue.  Lower values are placed in front. Ties are broken arbitrarily.
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
            CascadeUp(item);
        }

        /// <summary>
        ///     Removes the head of the queue and returns it.
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
        ///     If the node is currently in the queue or belongs to another queue, the result is undefined
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


        /// <summary>
        ///     Cascades the up using the specified node
        /// </summary>
        /// <param name="node">The node</param>
        private void CascadeUp(T node)
        {
            //aka Heapify-up
            int parent;
            if (node.QueueIndex > 1)
            {
                parent = node.QueueIndex >> 1;
                T parentNode = _nodes[parent];
                if (HasHigherOrEqualPriority(parentNode, node))
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
                if (HasHigherOrEqualPriority(parentNode, node))
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
                if (childLeftIndex > _numNodes)
                {
                    break; // If leaf node, we're done
                }

                int childRightIndex = childLeftIndex + 1;
                T childLeft = _nodes[childLeftIndex];
                T childRight = childRightIndex <= _numNodes ? _nodes[childRightIndex] : null;

                int swapIndex = GetSwapIndex(finalQueueIndex, childLeftIndex, childRightIndex, childLeft, childRight);

                if (swapIndex == finalQueueIndex)
                {
                    break; // If no swap needed, we're done
                }

                Swap(finalQueueIndex, swapIndex);
                finalQueueIndex = swapIndex; // Update the index for next iteration
            }

            node.QueueIndex = finalQueueIndex;
            _nodes[finalQueueIndex] = node;
        }

        /// <summary>
        ///     Gets the swap index using the specified final queue index
        /// </summary>
        /// <param name="finalQueueIndex">The final queue index</param>
        /// <param name="childLeftIndex">The child left index</param>
        /// <param name="childRightIndex">The child right index</param>
        /// <param name="childLeft">The child left</param>
        /// <param name="childRight">The child right</param>
        /// <returns>The final queue index</returns>
        private int GetSwapIndex(int finalQueueIndex, int childLeftIndex, int childRightIndex, T childLeft, T childRight)
        {
            bool isLeftHigherPriority = HasHigherPriority(childLeft, _nodes[finalQueueIndex]);
            bool isRightHigherPriority = (childRight != null) && HasHigherPriority(childRight, _nodes[finalQueueIndex]);

            if (isLeftHigherPriority || isRightHigherPriority)
            {
                if (isLeftHigherPriority && isRightHigherPriority)
                {
                    return HasHigherPriority(childLeft, childRight) ? childLeftIndex : childRightIndex;
                }

                return isLeftHigherPriority ? childLeftIndex : childRightIndex;
            }

            return finalQueueIndex;
        }

        /// <summary>
        ///     Swaps the index 1
        /// </summary>
        /// <param name="index1">The index</param>
        /// <param name="index2">The index</param>
        private void Swap(int index1, int index2)
        {
            (_nodes[index1], _nodes[index2]) = (_nodes[index2], _nodes[index1]);
            _nodes[index1].QueueIndex = index1;
            _nodes[index2].QueueIndex = index2;
        }

        /// <summary>
        ///     Returns true if 'higher' has higher priority than 'lower', false otherwise.
        ///     Note that calling HasHigherPriority(node, node) (ie. both arguments the same node) will return false
        /// </summary>
        private bool HasHigherPriority(T higher, T lower) => higher.Priority < lower.Priority;

        /// <summary>
        ///     Returns true if 'higher' has higher priority than 'lower', false otherwise.
        ///     Note that calling HasHigherOrEqualPriority(node, node) (ie. both arguments the same node) will return true
        /// </summary>
        private bool HasHigherOrEqualPriority(T higher, T lower) => higher.Priority <= lower.Priority;


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