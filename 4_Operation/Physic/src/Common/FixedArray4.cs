

using Alis.Core.Aspect.Math.Matrix;

namespace Alis.Core.Physic.Common
{
    /// <summary>
    ///     A fixed-size array of four elements of type T, optimized for performance.
    /// </summary>
    /// <typeparam name="T">The type of elements stored in the array.</typeparam>
    /// <remarks>
    ///     This struct provides a memory-efficient alternative to standard .NET arrays
    ///     for small fixed-size collections. It avoids heap allocations and provides
    ///     bounds-checked access with zero-overhead indexer when possible.
    ///     Ideal for use in performance-critical physics calculations where allocation
    ///     overhead must be minimized. Commonly used for representing 2D homogeneous
    ///     coordinates or quaternions.
    /// </remarks>
    /// <example>
    ///     <code>
    ///     FixedArray4&lt;float&gt; coords = new FixedArray4&lt;float&gt;();
    ///     coords[0] = 1.0f;
    ///     coords[1] = 2.0f;
    ///     coords[2] = 3.0f;
    ///     coords[3] = 4.0f;
    ///     </code>
    /// </example>
    public struct FixedArray4<T>
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
        ///     Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element (must be between 0 and 3).</param>
        /// <value>
        ///     The element at the specified index.
        /// </value>
        /// <returns>The element at the specified index.</returns>
        /// <exception cref="CustomIndexOutOfRangeException">
        ///     Thrown when index is less than 0 or greater than 3.
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
                    default:
                        throw new CustomIndexOutOfRangeException();
                }
            }
        }
    }
}