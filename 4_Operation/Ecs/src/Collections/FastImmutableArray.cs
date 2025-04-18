// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastImmutableArray.cs
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
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Alis.Core.Ecs.Collections
{
    /// <summary>
    ///     A readonly array with O(1) indexable lookup time.
    /// </summary>
    /// <typeparam name="T">The type of element stored by the array.</typeparam>
    /// <devremarks>
    ///     This type has a documented contract of being exactly one reference-type field in size.
    ///     Our own <see cref="System.Collections.Immutable.ImmutableInterlocked" /> class depends on it, as well as others
    ///     externally.
    ///     IMPORTANT NOTICE FOR MAINTAINERS AND REVIEWERS:
    ///     This type should be thread-safe. As a struct, it cannot protect its own fields
    ///     from being changed from one thread while its members are executing on other threads
    ///     because structs can change *in place* simply by reassigning the field containing
    ///     this struct. Therefore it is extremely important that
    ///     ** Every member should only dereference <c>this</c> ONCE. **
    ///     If a member needs to reference the array field, that counts as a dereference of <c>this</c>.
    ///     Calling other instance members (properties or methods) also counts as dereferencing <c>this</c>.
    ///     Any member that needs to use <c>this</c> more than once must instead
    ///     assign <c>this</c> to a local variable and use that for the rest of the code instead.
    ///     This effectively copies the one field in the struct to a local variable so that
    ///     it is insulated from other threads.
    /// </devremarks>
    public partial struct FastImmutableArray<T> : IEnumerable<T>, IEquatable<FastImmutableArray<T>>, IFastImmutableArray
    {
        /// <summary>
        ///     An empty (initialized) instance of <see cref="FastImmutableArray{T}" />.
        /// </summary>
        public static readonly FastImmutableArray<T> Empty = new FastImmutableArray<T>(new T[0]);

        /// <summary>
        ///     The backing field for this instance. References to this value should never be shared with outside code.
        /// </summary>
        /// <remarks>
        ///     This would be private, but we make it internal so that our own extension methods can access it.
        /// </remarks>
        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        internal readonly T[] array;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FastImmutableArray{T}" /> struct
        ///     *without making a defensive copy*.
        /// </summary>
        /// <param name="items">The array to use. May be null for "default" arrays.</param>
        internal FastImmutableArray(T[] items) => array = items;

        #region Operators

        /// <summary>
        ///     Checks equality between two instances.
        /// </summary>
        /// <param name="left">The instance to the left of the operator.</param>
        /// <param name="right">The instance to the right of the operator.</param>
        /// <returns><c>true</c> if the values' underlying arrays are reference equal; <c>false</c> otherwise.</returns>
        public static bool operator ==(FastImmutableArray<T> left, FastImmutableArray<T> right) => left.Equals(right);

        /// <summary>
        ///     Checks inequality between two instances.
        /// </summary>
        /// <param name="left">The instance to the left of the operator.</param>
        /// <param name="right">The instance to the right of the operator.</param>
        /// <returns><c>true</c> if the values' underlying arrays are reference not equal; <c>false</c> otherwise.</returns>
        public static bool operator !=(FastImmutableArray<T> left, FastImmutableArray<T> right) => !left.Equals(right);

        /// <summary>
        ///     Checks equality between two instances.
        /// </summary>
        /// <param name="left">The instance to the left of the operator.</param>
        /// <param name="right">The instance to the right of the operator.</param>
        /// <returns><c>true</c> if the values' underlying arrays are reference equal; <c>false</c> otherwise.</returns>
        public static bool operator ==(FastImmutableArray<T>? left, FastImmutableArray<T>? right) => left.GetValueOrDefault().Equals(right.GetValueOrDefault());

        /// <summary>
        ///     Checks inequality between two instances.
        /// </summary>
        /// <param name="left">The instance to the left of the operator.</param>
        /// <param name="right">The instance to the right of the operator.</param>
        /// <returns><c>true</c> if the values' underlying arrays are reference not equal; <c>false</c> otherwise.</returns>
        public static bool operator !=(FastImmutableArray<T>? left, FastImmutableArray<T>? right) => !left.GetValueOrDefault().Equals(right.GetValueOrDefault());

        #endregion

        /// <summary>
        ///     Gets the element at the specified index in the read-only list.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get.</param>
        /// <returns>The element at the specified index in the read-only list.</returns>
        public T this[int index] =>
            // We intentionally do not check this.array != null, and throw NullReferenceException
            // if this is called while uninitialized.
            // The reason for this is perf.
            // Length and the indexer must be absolutely trivially implemented for the JIT optimization
            // of removing array bounds checking to work.
            array![index];

        /// <summary>
        ///     Gets a read-only reference to the element at the specified index in the read-only list.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get a reference to.</param>
        /// <returns>A read-only reference to the element at the specified index in the read-only list.</returns>
        public ref readonly T ItemRef(int index) =>
            // We intentionally do not check this.array != null, and throw NullReferenceException
            // if this is called while uninitialized.
            // The reason for this is perf.
            // Length and the indexer must be absolutely trivially implemented for the JIT optimization
            // of removing array bounds checking to work.
            ref array![index];

        /// <summary>
        ///     Gets a value indicating whether this collection is empty.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool IsEmpty => array!.Length == 0;

        /// <summary>
        ///     Gets the number of elements in the array.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public int Length =>
            // We intentionally do not check this.array != null, and throw NullReferenceException
            // if this is called while uninitialized.
            // The reason for this is perf.
            // Length and the indexer must be absolutely trivially implemented for the JIT optimization
            // of removing array bounds checking to work.
            array!.Length;

        /// <summary>
        ///     Gets a value indicating whether this struct was initialized without an actual array instance.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool IsDefault => array == null;

        /// <summary>
        ///     Gets a value indicating whether this struct is empty or uninitialized.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool IsDefaultOrEmpty
        {
            get
            {
                FastImmutableArray<T> self = this;
                return self.array == null || self.array.Length == 0;
            }
        }

        /// <summary>
        ///     Gets an untyped reference to the array.
        /// </summary>
        Array IFastImmutableArray.Array => array;

        /// <summary>
        ///     Gets the string to display in the debugger watches window for this instance.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay
        {
            get
            {
                FastImmutableArray<T> self = this;
                return self.IsDefault ? "Uninitialized" : $"Length = {self.Length}";
            }
        }

        /// <summary>
        ///     Copies the contents of this array to the specified array.
        /// </summary>
        /// <param name="destination">The array to copy to.</param>
        public void CopyTo(T[] destination)
        {
            FastImmutableArray<T> self = this;
            self.ThrowNullRefIfNotInitialized();
            Array.Copy(self.array!, destination, self.Length);
        }

        /// <summary>
        ///     Copies the contents of this array to the specified array.
        /// </summary>
        /// <param name="destination">The array to copy to.</param>
        /// <param name="destinationIndex">The index into the destination array to which the first copied element is written.</param>
        public void CopyTo(T[] destination, int destinationIndex)
        {
            FastImmutableArray<T> self = this;
            self.ThrowNullRefIfNotInitialized();
            Array.Copy(self.array!, 0, destination, destinationIndex, self.Length);
        }

        /// <summary>
        ///     Copies the contents of this array to the specified array.
        /// </summary>
        /// <param name="sourceIndex">The index into this collection of the first element to copy.</param>
        /// <param name="destination">The array to copy to.</param>
        /// <param name="destinationIndex">The index into the destination array to which the first copied element is written.</param>
        /// <param name="length">The number of elements to copy.</param>
        public void CopyTo(int sourceIndex, T[] destination, int destinationIndex, int length)
        {
            FastImmutableArray<T> self = this;
            self.ThrowNullRefIfNotInitialized();
            Array.Copy(self.array!, sourceIndex, destination, destinationIndex, length);
        }

        /// <summary>
        ///     Returns an enumerator for the contents of the array.
        /// </summary>
        /// <returns>An enumerator.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Enumerator GetEnumerator()
        {
            FastImmutableArray<T> self = this;
            self.ThrowNullRefIfNotInitialized();
            return new Enumerator(self.array!);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            FastImmutableArray<T> self = this;
            return self.array == null ? 0 : self.array.GetHashCode();
        }

        /// <summary>
        ///     Determines whether the specified <see cref="object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj is IFastImmutableArray other && (array == other.Array);

        /// <summary>
        ///     Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///     true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        public bool Equals(FastImmutableArray<T> other) => array == other.array;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FastImmutableArray{T}" /> struct based on the contents
        ///     of an existing instance, allowing a covariant static cast to efficiently reuse the existing array.
        /// </summary>
        /// <param name="items">The array to initialize the array with. No copy is made.</param>
        /// <remarks>
        ///     Covariant upcasts from this method may be reversed by calling the
        ///     <see cref="FastImmutableArray{T}.As{TOther}" />  or <see cref="FastImmutableArray{T}.CastArray{TOther}" />method.
        /// </remarks>
        public static FastImmutableArray<T> CastUp<TDerived>(FastImmutableArray<TDerived> items)
            where TDerived : class?, T
        {
            return new FastImmutableArray<T>(items.array);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FastImmutableArray{T}" /> struct by casting the underlying
        ///     array to an array of type
        ///     <typeparam name="TOther" />
        ///     .
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown if the cast is illegal.</exception>
        public FastImmutableArray<TOther> CastArray<TOther>() where TOther : class?
        {
            return new FastImmutableArray<TOther>((TOther[]) (object) array!);
        }

        /// <summary>
        ///     Creates an immutable array for this array, cast to a different element type.
        /// </summary>
        /// <typeparam name="TOther">The type of array element to return.</typeparam>
        /// <returns>
        ///     A struct typed for the base element type. If the cast fails, an instance
        ///     is returned whose <see cref="IsDefault" /> property returns <c>true</c>.
        /// </returns>
        /// <remarks>
        ///     Arrays of derived elements types can be cast to arrays of base element types
        ///     without reallocating the array.
        ///     These upcasts can be reversed via this same method, casting an array of base
        ///     element types to their derived types. However, downcasting is only successful
        ///     when it reverses a prior upcasting operation.
        /// </remarks>
        public FastImmutableArray<TOther> As<TOther>() where TOther : class?
        {
            return new FastImmutableArray<TOther>(array as TOther[]);
        }

        /// <summary>
        ///     Returns an enumerator for the contents of the array.
        /// </summary>
        /// <returns>An enumerator.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the <see cref="IsDefault" /> property returns true.</exception>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            FastImmutableArray<T> self = this;
            self.ThrowInvalidOperationIfNotInitialized();
            return EnumeratorObject.Create(self.array!);
        }

        /// <summary>
        ///     Returns an enumerator for the contents of the array.
        /// </summary>
        /// <returns>An enumerator.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the <see cref="IsDefault" /> property returns true.</exception>
        IEnumerator IEnumerable.GetEnumerator()
        {
            FastImmutableArray<T> self = this;
            self.ThrowInvalidOperationIfNotInitialized();
            return EnumeratorObject.Create(self.array!);
        }

        /// <summary>
        ///     Throws a null reference exception if the array field is null.
        /// </summary>
        internal void ThrowNullRefIfNotInitialized()
        {
            // Force NullReferenceException if array is null by touching its Length.
            // This way of checking has a nice property of requiring very little code
            // and not having any conditions/branches.
            // In a faulting scenario we are relying on hardware to generate the fault.
            // And in the non-faulting scenario (most common) the check is virtually free since
            // if we are going to do anything with the array, we will need Length anyways
            // so touching it, and potentially causing a cache miss, is not going to be an
            // extra expense.
            _ = array!.Length;
        }

        /// <summary>
        ///     Throws an <see cref="InvalidOperationException" /> if the <see cref="array" /> field is null, i.e. the
        ///     <see cref="IsDefault" /> property returns true.  The
        ///     <see cref="InvalidOperationException" /> message specifies that the operation cannot be performed
        ///     on a default instance of <see cref="FastImmutableArray{T}" />.
        ///     This is intended for explicitly implemented interface method and property implementations.
        /// </summary>
        private void ThrowInvalidOperationIfNotInitialized()
        {
            if (IsDefault)
            {
                throw new InvalidOperationException("Operation cannot be performed on a default instance of FastImmutableArray<T>.");
            }
        }

        /// <summary>
        ///     An array enumerator.
        /// </summary>
        /// <remarks>
        ///     It is important that this enumerator does NOT implement <see cref="IDisposable" />.
        ///     We want the iterator to inline when we do foreach and to not result in
        ///     a try/finally frame in the client.
        /// </remarks>
        public struct Enumerator
        {
            /// <summary>
            ///     The array being enumerated.
            /// </summary>
            private readonly T[] _array;

            /// <summary>
            ///     The currently enumerated position.
            /// </summary>
            /// <value>
            ///     -1 before the first call to <see cref="MoveNext" />.
            ///     >= this.array.Length after <see cref="MoveNext" /> returns false.
            /// </value>
            private int _index;

            /// <summary>
            ///     Initializes a new instance of the <see cref="Enumerator" /> struct.
            /// </summary>
            /// <param name="array">The array to enumerate.</param>
            internal Enumerator(T[] array)
            {
                _array = array;
                _index = -1;
            }

            /// <summary>
            ///     Gets the currently enumerated value.
            /// </summary>
            public T Current =>
                // PERF: no need to do a range check, we already did in MoveNext.
                // if user did not call MoveNext or ignored its result (incorrect use)
                // they will still get an exception from the array access range check.
                _array[_index];

            /// <summary>
            ///     Advances to the next value to be enumerated.
            /// </summary>
            /// <returns><c>true</c> if another item exists in the array; <c>false</c> otherwise.</returns>
            public bool MoveNext() => ++_index < _array.Length;
        }

        /// <summary>
        ///     An array enumerator that implements <see cref="IEnumerator{T}" /> pattern (including <see cref="IDisposable" />).
        /// </summary>
        private sealed class EnumeratorObject : IEnumerator<T>
        {
            /// <summary>
            ///     A shareable singleton for enumerating empty arrays.
            /// </summary>
            private static readonly IEnumerator<T> s_EmptyEnumerator =
                new EnumeratorObject(Empty.array!);

            /// <summary>
            ///     The array being enumerated.
            /// </summary>
            private readonly T[] _array;

            /// <summary>
            ///     The currently enumerated position.
            /// </summary>
            /// <value>
            ///     -1 before the first call to <see cref="MoveNext" />.
            ///     this.array.Length - 1 after MoveNext returns false.
            /// </value>
            private int _index;

            /// <summary>
            ///     Initializes a new instance of the <see cref="Enumerator" /> class.
            /// </summary>
            private EnumeratorObject(T[] array)
            {
                _index = -1;
                _array = array;
            }

            /// <summary>
            ///     Gets the currently enumerated value.
            /// </summary>
            public T Current
            {
                get
                {
                    // this.index >= 0 && this.index < this.array.Length
                    // unsigned compare performs the range check above in one compare
                    if (unchecked((uint) _index) < (uint) _array.Length)
                    {
                        return _array[_index];
                    }

                    // Before first or after last MoveNext.
                    throw new InvalidOperationException();
                }
            }

            /// <summary>
            ///     Gets the currently enumerated value.
            /// </summary>
            object IEnumerator.Current => Current;

            /// <summary>
            ///     If another item exists in the array, advances to the next value to be enumerated.
            /// </summary>
            /// <returns><c>true</c> if another item exists in the array; <c>false</c> otherwise.</returns>
            public bool MoveNext()
            {
                int newIndex = _index + 1;
                int length = _array.Length;

                // unsigned math is used to prevent false positive if index + 1 overflows.
                if ((uint) newIndex <= (uint) length)
                {
                    _index = newIndex;
                    return (uint) newIndex < (uint) length;
                }

                return false;
            }

            /// <summary>
            ///     Resets enumeration to the start of the array.
            /// </summary>
            void IEnumerator.Reset()
            {
                _index = -1;
            }

            /// <summary>
            ///     Disposes this enumerator.
            /// </summary>
            /// <remarks>
            ///     Currently has no action.
            /// </remarks>
            public void Dispose()
            {
                // we do not have any native or disposable resources.
                // nothing to do here.
            }

            /// <summary>
            ///     Creates an enumerator for the specified array.
            /// </summary>
            internal static IEnumerator<T> Create(T[] array)
            {
                if (array.Length != 0)
                {
                    return new EnumeratorObject(array);
                }

                return s_EmptyEnumerator;
            }
        }
    }
}