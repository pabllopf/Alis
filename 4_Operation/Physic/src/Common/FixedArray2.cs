

using Alis.Core.Aspect.Math.Matrix;

namespace Alis.Core.Physic.Common
{
    /// <summary>
    ///     A fixed-size array of two elements of type T, optimized for performance.
    /// </summary>
    /// <typeparam name="T">The type of elements stored in the array.</typeparam>
    /// <remarks>
    ///     This struct provides a memory-efficient alternative to standard .NET arrays
    ///     for small fixed-size collections. It avoids heap allocations and provides
    ///     bounds-checked access with zero-overhead indexer when possible.
    ///     Ideal for use in performance-critical physics calculations where allocation
    ///     overhead must be minimized.
    /// </remarks>
    /// <example>
    ///     <code>
    ///     FixedArray2&lt;int&gt; pair = new FixedArray2&lt;int&gt;();
    ///     pair[0] = 10;
    ///     pair[1] = 20;
    ///     int first = pair[0]; // Returns 10
    ///     </code>
    /// </example>
    public struct FixedArray2<T>
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
        ///     Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element (must be 0 or 1).</param>
        /// <value>
        ///     The element at the specified index.
        /// </value>
        /// <returns>The element at the specified index.</returns>
        /// <exception cref="CustomIndexOutOfRangeException">
        ///     Thrown when index is less than 0 or greater than 1.
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
                    default:
                        throw new CustomIndexOutOfRangeException();
                }
            }
        }
    }
}