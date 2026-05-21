

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Matrix;

namespace Alis.Core.Physic.Common.Decomposition.CDT.Util
{
    /// <summary>
    ///     The fixed bit array
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct FixedBitArray3 : IEnumerable<bool>
    {
        /// <summary>
        ///     The
        /// </summary>
        public bool _0, _1, _2;

        /// <summary>
        ///     The index out of range exception
        /// </summary>
        public bool this[int index]
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
        /// <returns>An enumerator of bool</returns>
        public IEnumerator<bool> GetEnumerator() => Enumerate().GetEnumerator();

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
        public bool Contains(bool value)
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
        public int IndexOf(bool value)
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
            _0 = _1 = _2 = false;
        }

        /// <summary>
        ///     Clears the value
        /// </summary>
        /// <param name="value">The value</param>
        public void Clear(bool value)
        {
            for (int i = 0; i < 3; ++i)
            {
                if (this[i] == value)
                {
                    this[i] = false;
                }
            }
        }

        /// <summary>
        ///     Enumerates this instance
        /// </summary>
        /// <returns>An enumerable of bool</returns>
        internal IEnumerable<bool> Enumerate()
        {
            for (int i = 0; i < 3; ++i)
            {
                yield return this[i];
            }
        }
    }
}