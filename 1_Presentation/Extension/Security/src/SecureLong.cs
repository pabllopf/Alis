

namespace Alis.Extension.Security
{
    /// <summary>
    ///     The secure long class
    /// </summary>
    public class SecureLong
    {
        /// <summary>
        ///     The random value
        /// </summary>
        private long _randomValue;

        /// <summary>
        ///     The value
        /// </summary>
        private long _value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SecureLong" /> class
        /// </summary>
        /// <param name="value">The value</param>
        public SecureLong(long value = 0L) => Value = value;

        /// <summary>
        ///     Gets or sets the value of the value
        /// </summary>
        private long Value
        {
            get
            {
                unchecked
                {
                    return _value - _randomValue;
                }
            }

            set
            {
                unchecked
                {
                    _randomValue = SecureRandom.NextLong();
                    _value = value + _randomValue;
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator SecureLong(long value) => new SecureLong(value);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator long(SecureLong value) => value.Value;

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(SecureLong a, SecureLong b) => a.Value == b.Value;

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(SecureLong a, SecureLong b) => a.Value != b.Value;

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static SecureLong operator ++(SecureLong a)
        {
            a.Value++;
            return a;
        }

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static SecureLong operator --(SecureLong a)
        {
            a.Value--;
            return a;
        }

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureLong operator +(SecureLong a, SecureLong b) => new SecureLong(a.Value + b.Value);

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureLong operator -(SecureLong a, SecureLong b) => new SecureLong(a.Value - b.Value);

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureLong operator *(SecureLong a, SecureLong b) => new SecureLong(a.Value * b.Value);

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureLong operator /(SecureLong a, SecureLong b) => new SecureLong(a.Value / b.Value);

        /// <summary>
        ///     Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString() => Value.ToString();

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>The int</returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        ///     Describes whether this instance equals
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <returns>The bool</returns>
        public override bool Equals(object obj) => Value.Equals((obj as SecureLong).Value);
    }
}