

using Alis.Core.Aspect.Math.Matrix;

namespace Alis.Core.Physic.Common
{
    /// <summary>
    ///     A fixed-size array of eight elements of type T, optimized for performance.
    /// </summary>
    /// <typeparam name="T">The type of elements stored in the array.</typeparam>
    /// <remarks>
    ///     This struct provides a memory-efficient alternative to standard .NET arrays
    ///     for small fixed-size collections. It avoids heap allocations and provides
    ///     bounds-checked access with zero-overhead indexer when possible.
    ///     Ideal for use in performance-critical physics calculations where allocation
    ///     overhead must be minimized. Commonly used for representing matrix columns
    ///     or larger contact manifolds.
    /// </remarks>
    /// <example>
    ///     <code>
    ///     FixedArray8&lt;ContactPoint&gt; manifold = new FixedArray8&lt;ContactPoint&gt;();
    ///     for (int i = 0; i &lt; 8; i++)
    ///     {
    ///         manifold[i] = new ContactPoint();
    ///     }
    ///     </code>
    /// </example>
    public struct FixedArray8<T>
    {
        /// <summary>
        ///     The first element at index 0.
        /// </summary>
        internal T _value0;

        /// <summary>
        ///     The second element at index 1.
        /// </summary>
        internal T _value1;

        /// <summary>
        ///     The third element at index 2.
        /// </summary>
        internal T _value2;

        /// <summary>
        ///     The fourth element at index 3.
        /// </summary>
        internal T _value3;

        /// <summary>
        ///     The fifth element at index 4.
        /// </summary>
        internal T _value4;

        /// <summary>
        ///     The sixth element at index 5.
        /// </summary>
        internal T _value5;

        /// <summary>
        ///     The seventh element at index 6.
        /// </summary>
        internal T _value6;

        /// <summary>
        ///     The eighth element at index 7.
        /// </summary>
        private T _value7;

        /// <summary>
        ///     Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element (must be between 0 and 7).</param>
        /// <value>
        ///     The element at the specified index.
        /// </value>
        /// <returns>The element at the specified index.</returns>
        /// <exception cref="CustomIndexOutOfRangeException">
        ///     Thrown when index is less than 0 or greater than 7.
        /// </exception>
        public T this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return _value0;
                    case 1:
                        return _value1;
                    case 2:
                        return _value2;
                    case 3:
                        return _value3;
                    case 4:
                        return _value4;
                    case 5:
                        return _value5;
                    case 6:
                        return _value6;
                    case 7:
                        return _value7;
                    default:
                        throw new CustomIndexOutOfRangeException();
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        _value0 = value;
                        break;
                    case 1:
                        _value1 = value;
                        break;
                    case 2:
                        _value2 = value;
                        break;
                    case 3:
                        _value3 = value;
                        break;
                    case 4:
                        _value4 = value;
                        break;
                    case 5:
                        _value5 = value;
                        break;
                    case 6:
                        _value6 = value;
                        break;
                    case 7:
                        _value7 = value;
                        break;
                    default:
                        throw new CustomIndexOutOfRangeException();
                }
            }
        }
    }
}