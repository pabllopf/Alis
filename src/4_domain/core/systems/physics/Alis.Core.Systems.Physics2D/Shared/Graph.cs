// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Graph.cs
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

using System.Collections;
using System.Collections.Generic;
using Alis.Core.Systems.Physics2D.Shared.Contracts;

namespace Alis.Core.Systems.Physics2D.Shared
{
    /// <summary>This graph is a doubly linked circular list. It is circular to avoid branches in Add/Remove methods.</summary>
    public class Graph<T> : IEnumerable<T>
    {
        /// <summary>
        ///     The comparer
        /// </summary>
        private readonly EqualityComparer<T> comparer;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Graph" /> class
        /// </summary>
        public Graph() => comparer = EqualityComparer<T>.Default;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Graph" /> class
        /// </summary>
        /// <param name="comparer">The comparer</param>
        public Graph(EqualityComparer<T> comparer)
        {
            Contract.Requires(comparer != null, "You supplied a null comparer");

            this.comparer = comparer;
        }

        /// <summary>The number of items in the graph</summary>
        public int Count { get; private set; }

        /// <summary>The first node in the graph</summary>
        public GraphNode<T> First { get; private set; }

        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>An enumerator of t</returns>
        public IEnumerator<T> GetEnumerator()
        {
            GraphNode<T> node = First;

            for (int i = 0; i < Count; i++)
            {
                GraphNode<T> node0 = node;
                node = node.Next;
                yield return node0.Item;
            }
        }

        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>Add a value to the graph</summary>
        /// <remarks>Note that this method is O(n) in worst case.</remarks>
        /// <returns>The node that represents the value</returns>
        public GraphNode<T> Add(T value)
        {
            GraphNode<T> result = new GraphNode<T>(value);
            Add(result);
            return result;
        }

        /// <summary>Add a node to the graph</summary>
        /// <remarks>Note that this method is O(1) in worst case.</remarks>
        public void Add(GraphNode<T> node)
        {
            Contract.Requires(node != null, nameof(node) + " must not be null");

            if (First == null)
            {
                node.Next = node;
                node.Prev = node;
                First = node;
                Count++;
            }
            else
            {
                node.Next = First;
                node.Prev = First.Prev;
                First.Prev.Next = node;
                First.Prev = node;
                Count++;
            }
        }

        /// <summary>Check if the specified value is contained within the graph.</summary>
        /// <remarks>Note that this method is O(n) in worst case.</remarks>
        /// <returns>True if it found the value, otherwise false.</returns>
        public bool Contains(T value) => Find(value) != null;

        /// <summary>Finds the specified value</summary>
        /// <remarks>Note that this method is O(n) in worst case.</remarks>
        /// <returns>The graph node that was found if any. Otherwise it returns null.</returns>
        public GraphNode<T> Find(T value)
        {
            GraphNode<T> node = First;

            if (node == null)
            {
                return null;
            }

            if (value != null)
            {
                do
                {
                    if (comparer.Equals(node.Item, value))
                    {
                        return node;
                    }

                    node = node.Next;
                } while (node != First);
            }
            else
            {
                do
                {
                    if (node.Item == null)
                    {
                        return node;
                    }

                    node = node.Next;
                } while (node != First);
            }

            return null;
        }

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear()
        {
            GraphNode<T> node = First;

            for (int i = 0; i < Count; i++)
            {
                GraphNode<T> node0 = node;
                node = node.Next;
                node0.Invalidate();
            }
        }

        /// <summary>Remove the specified value</summary>
        /// <remarks>Note that this method is O(n) in worst case.</remarks>
        /// <returns>True if the value was removed, otherwise false.</returns>
        public bool Remove(T value)
        {
            GraphNode<T> node = Find(value);

            if (node == null)
            {
                return false;
            }

            Remove(node);
            return true;
        }

        /// <summary>Remove the specified node from the graph.</summary>
        /// <remarks>Note that this method is O(1) in worst case.</remarks>
        public void Remove(GraphNode<T> node)
        {
            Contract.Requires(node != null, nameof(node) + " must not be null");
            Contract.Warn(First != null, "You are trying to remove an item from an empty list.");

            //Invalid node
            if (node.Next == null && node.Prev == null)
            {
                return;
            }

            if (node.Next == node)
            {
                First = null;
            }
            else
            {
                node.Next.Prev = node.Prev;
                node.Prev.Next = node.Next;

                if (First == node)
                {
                    First = node.Next;
                }
            }

            node.Invalidate();
            Count--;
        }

        /// <summary>
        ///     Gets the nodes
        /// </summary>
        /// <returns>An enumerable of graph node t</returns>
        public IEnumerable<GraphNode<T>> GetNodes()
        {
            GraphNode<T> node = First;

            for (int i = 0; i < Count; i++)
            {
                GraphNode<T> node0 = node;
                node = node.Next;
                yield return node0;
            }
        }
    }
}