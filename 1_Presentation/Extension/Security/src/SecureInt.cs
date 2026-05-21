

namespace Alis.Extension.Security
{
    /// <summary>
    ///     The secure int class
    /// </summary>
    public class SecureInt
    {
        /// <summary>
        ///     The random value
        /// </summary>
        private int _randomValue;

        /// <summary>
        ///     The value
        /// </summary>
        private int _value;


        /// <summary>
        ///     Initializes a new instance of the <see cref="SecureInt" /> class
        /// </summary>
        /// <param name="value">The value</param>
        public SecureInt(int value = 0) => Value = value;

        /// <summary>
        ///     Gets or sets the value of the value
        /// </summary>
        private int Value
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
                    _randomValue = SecureRandom.NextInt();
                    _value = value + _randomValue;
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator SecureInt(int value) => new SecureInt(value);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator int(SecureInt value) => value.Value;

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(SecureInt a, SecureInt b) => a.Value == b.Value;

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(SecureInt a, SecureInt b) => a.Value != b.Value;

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static SecureInt operator ++(SecureInt a)
        {
            a.Value++;
            return a;
        }

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static SecureInt operator --(SecureInt a)
        {
            a.Value--;
            return a;
        }

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureInt operator +(SecureInt a, SecureInt b) => new SecureInt(a.Value + b.Value);

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureInt operator -(SecureInt a, SecureInt b) => new SecureInt(a.Value - b.Value);

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureInt operator *(SecureInt a, SecureInt b) => new SecureInt(a.Value * b.Value);

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureInt operator /(SecureInt a, SecureInt b) => new SecureInt(a.Value / b.Value);

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
        public override bool Equals(object obj) => Value.Equals((obj as SecureInt).Value);
    }
}