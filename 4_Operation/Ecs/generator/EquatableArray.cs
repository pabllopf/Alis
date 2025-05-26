using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Generator
{
    /// <summary>
    /// The equatable array
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct EquatableArray<T> : IEquatable<EquatableArray<T>>, IEnumerable<T>
        where T : IEquatable<T>
    {
        /// <summary>
        /// The items
        /// </summary>
        public readonly T[] Items;
        /// <summary>
        /// Gets the value of the length
        /// </summary>
        public readonly int Length => Items.Length;

        /// <summary>
        /// Initializes a new instance of the <see cref="EquatableArray"/> class
        /// </summary>
        /// <param name="items">The items</param>
        /// <exception cref="ArgumentNullException"></exception>
        public EquatableArray(T[] items)
        {
            if (items is null)
                throw new ArgumentNullException(nameof(items));
            Items = items;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EquatableArray"/> class
        /// </summary>
        /// <param name="len">The len</param>
        public EquatableArray(int len) : this(new T[len]) { }


        public static bool operator ==(EquatableArray<T> a, EquatableArray<T> b)
            => a.Equals(b);
        public static bool operator !=(EquatableArray<T> a, EquatableArray<T> b)
            => !a.Equals(b);
        /// <summary>
        /// Equalses the obj
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <returns>The bool</returns>
        public override bool Equals(object obj)
            => obj is EquatableArray<T> n && n == this;
        /// <summary>
        /// Equalses the other
        /// </summary>
        /// <param name="other">The other</param>
        /// <returns>The bool</returns>
        public bool Equals(EquatableArray<T> other)
        {
            if(other.Items is null)
                return Items is null;

            if (Items is null)
                return false;

            if (Items.Length != other.Items.Length)
                return false;
            Items.AsSpan().SequenceEqual(other.Items);
            return true;
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>The int</returns>
        public override int GetHashCode()
        {
            HashCode hashCode = new();
            foreach (ref var value in Items.AsSpan())
            {
                hashCode.Add(value);
            }
            return hashCode.ToHashCode();
        }

        /// <summary>
        /// Gets the enumerator
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        /// <summary>
        /// Gets the enumerator
        /// </summary>
        /// <returns>An enumerator of t</returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => new EquatableArrayEnumerator(this);
        /// <summary>
        /// Gets the enumerator
        /// </summary>
        /// <returns>The equatable array enumerator</returns>
        public EquatableArrayEnumerator GetEnumerator() => new EquatableArrayEnumerator(this);

        /// <summary>
        /// The equatable array enumerator
        /// </summary>
        public struct EquatableArrayEnumerator : IEnumerator<T>
        {
            /// <summary>
            /// The items
            /// </summary>
            private readonly T[] _items;
            /// <summary>
            /// The index
            /// </summary>
            private int _index;

            /// <summary>
            /// Initializes a new instance of the <see cref="EquatableArrayEnumerator"/> class
            /// </summary>
            /// <param name="equatableArray">The equatable array</param>
            public EquatableArrayEnumerator(EquatableArray<T> equatableArray)
            {
                _index = -1;
                _items = equatableArray.Items;
            }

            /// <summary>
            /// Gets the value of the current
            /// </summary>
            public T Current => _items[_index];
            /// <summary>
            /// Gets the value of the current
            /// </summary>
            object IEnumerator.Current => Current;
            /// <summary>
            /// Moves the next
            /// </summary>
            /// <returns>The bool</returns>
            public bool MoveNext() => ++_index < _items.Length;
            /// <summary>
            /// Resets this instance
            /// </summary>
            public void Reset() => _index = -1;
            /// <summary>
            /// Disposes this instance
            /// </summary>
            public void Dispose() { }
        }

        public static implicit operator ReadOnlySpan<T>(EquatableArray<T> values) => values.Items;
    }
}