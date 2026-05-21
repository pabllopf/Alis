

namespace Alis.Extension.Security
{
    /// <summary>
    ///     The secure byte class
    /// </summary>
    public class SecureByte
    {
        /// <summary>
        ///     The random value
        /// </summary>
        private byte _randomValue;

        /// <summary>
        ///     The value
        /// </summary>
        private byte _value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SecureByte" /> class
        /// </summary>
        /// <param name="value">The value</param>
        public SecureByte(byte value = 0) => Value = value;

        /// <summary>
        ///     Gets or sets the value of the value
        /// </summary>
        private byte Value
        {
            get
            {
                unchecked
                {
                    return (byte) (_value - _randomValue);
                }
            }

            set
            {
                unchecked
                {
                    _randomValue = SecureRandom.NextByte();
                    _value = (byte) (value + _randomValue);
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator SecureByte(byte value) => new SecureByte(value);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator byte(SecureByte value) => value.Value;

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(SecureByte a, SecureByte b) => a.Value == b.Value;

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(SecureByte a, SecureByte b) => a.Value != b.Value;

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static SecureByte operator ++(SecureByte a)
        {
            a.Value++;
            return a;
        }

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static SecureByte operator --(SecureByte a)
        {
            a.Value--;
            return a;
        }

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureByte operator +(SecureByte a, SecureByte b) => new SecureByte((byte) (a.Value + b.Value));

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureByte operator -(SecureByte a, SecureByte b) => new SecureByte((byte) (a.Value - b.Value));


        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureByte operator *(SecureByte a, SecureByte b) => new SecureByte((byte) (a.Value * b.Value));

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureByte operator /(SecureByte a, SecureByte b) => new SecureByte((byte) (a.Value / b.Value));

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
        public override bool Equals(object obj) => Value.Equals(((SecureByte) obj)!.Value);
    }
}