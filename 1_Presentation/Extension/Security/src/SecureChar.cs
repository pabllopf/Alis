

namespace Alis.Extension.Security
{
    /// <summary>
    ///     The secure char class
    /// </summary>
    public class SecureChar
    {
        /// <summary>
        ///     The random value
        /// </summary>
        private char _randomValue;

        /// <summary>
        ///     The value
        /// </summary>
        private char _value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SecureChar" /> class
        /// </summary>
        /// <param name="value">The value</param>
        public SecureChar(char value = '\x0000') => Value = value;

        /// <summary>
        ///     Gets or sets the value of the value
        /// </summary>
        private char Value
        {
            get
            {
                unchecked
                {
                    return (char) (_value - _randomValue);
                }
            }

            set
            {
                unchecked
                {
                    _randomValue = SecureRandom.NextChar();
                    _value = (char) (value + _randomValue);
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator SecureChar(char value) => new SecureChar(value);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator char(SecureChar value) => value.Value;

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(SecureChar a, SecureChar b) => a.Value == b.Value;

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(SecureChar a, SecureChar b) => a.Value != b.Value;

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureChar operator +(SecureChar a, SecureChar b) => new SecureChar((char) (a.Value + b.Value));

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureChar operator -(SecureChar a, SecureChar b) => new SecureChar((char) (a.Value - b.Value));

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureChar operator *(SecureChar a, SecureChar b) => new SecureChar((char) (a.Value * b.Value));

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureChar operator /(SecureChar a, SecureChar b) => new SecureChar((char) (a.Value / b.Value));

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
        public override bool Equals(object obj) => Value.Equals((obj as SecureChar).Value);
    }
}