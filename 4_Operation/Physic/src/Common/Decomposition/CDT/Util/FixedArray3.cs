

using System.Collections;
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Matrix;

namespace Alis.Core.Physic.Common.Decomposition.CDT.Util
{
    /// <summary>
    ///     The fixed array
    /// </summary>
    internal struct FixedArray3<T> : IEnumerable<T> where T : class
    {
        /// <summary>
        ///     The
        /// </summary>
        public T _0, _1, _2;

        /// <summary>
        ///     The index out of range exception
        /// </summary>
        public T this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return _0;
                    case 1:
                        return _1;
                    case 2:
                        return _2;
                    default:
                        throw new CustomIndexOutOfRangeException();
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        _0 = value;
                        break;
                    case 1:
                        _1 = value;
                        break;
                    case 2:
                        _2 = value;
                        break;
                    default:
                        throw new CustomIndexOutOfRangeException();
                }
            }
        }


        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>An enumerator of t</returns>
        public IEnumerator<T> GetEnumerator() => Enumerate().GetEnumerator();

        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        /// <summary>
        ///     Describes whether this instance contains
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        public bool Contains(T value)
        {
            for (int i = 0; i < 3; ++i)
            {
                if (this[i] == value)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///     Indexes the of using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        public int IndexOf(T value)
        {
            for (int i = 0; i < 3; ++i)
            {
                if (this[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear()
        {
            _0 = _1 = _2 = null;
        }

        /// <summary>
        ///     Clears the value
        /// </summary>
        /// <param name="value">The value</param>
        public void Clear(T value)
        {
            for (int i = 0; i < 3; ++i)
            {
                if (this[i] == value)
                {
                    this[i] = null;
                }
            }
        }

        /// <summary>
        ///     Enumerates this instance
        /// </summary>
        /// <returns>An enumerable of t</returns>
        internal IEnumerable<T> Enumerate()
        {
            for (int i = 0; i < 3; ++i)
            {
                yield return this[i];
            }
        }
    }
}