using System;

namespace Alis.Core.Physic.Common
{
    /// <summary>
    /// The fixed array
    /// </summary>
    public struct FixedArray3<T>
    {
        /// <summary>
        /// The value
        /// </summary>
        private T _value0;
        /// <summary>
        /// The value
        /// </summary>
        private T _value1;
        /// <summary>
        /// The value
        /// </summary>
        private T _value2;

        /// <summary>
        /// The index out of range exception
        /// </summary>
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
                    default:
                        throw new IndexOutOfRangeException();
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
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }
    }
}