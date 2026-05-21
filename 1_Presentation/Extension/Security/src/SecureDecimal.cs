

using System.Globalization;

namespace Alis.Extension.Security
{
    /// <summary>
    ///     The secure decimal class
    /// </summary>
    public class SecureDecimal
    {
        /// <summary>
        ///     The random value
        /// </summary>
        private decimal _randomValue;

        /// <summary>
        ///     The value
        /// </summary>
        private decimal _value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SecureDecimal" /> class
        /// </summary>
        /// <param name="value">The value</param>
        public SecureDecimal(decimal value = 0.0m) => Value = value;

        /// <summary>
        ///     Gets or sets the value of the value
        /// </summary>
        private decimal Value
        {
            get => _value - _randomValue;

            set
            {
                unchecked
                {
                    _randomValue = SecureRandom.NextDecimal(-1024, 1024);
                    _value = value + _randomValue;
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator SecureDecimal(decimal value) => new SecureDecimal(value);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator decimal(SecureDecimal value) => value.Value;

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(SecureDecimal a, SecureDecimal b) => a.Value == b.Value;

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(SecureDecimal a, SecureDecimal b) => a.Value != b.Value;

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static SecureDecimal operator ++(SecureDecimal a)
        {
            a.Value++;
            return a;
        }

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static SecureDecimal operator --(SecureDecimal a)
        {
            a.Value--;
            return a;
        }

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureDecimal operator +(SecureDecimal a, SecureDecimal b) => new SecureDecimal(a.Value + b.Value);


        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureDecimal operator -(SecureDecimal a, SecureDecimal b) => new SecureDecimal(a.Value - b.Value);

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureDecimal operator *(SecureDecimal a, SecureDecimal b) => new SecureDecimal(a.Value * b.Value);

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureDecimal operator /(SecureDecimal a, SecureDecimal b) => new SecureDecimal(a.Value / b.Value);

        /// <summary>
        ///     Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);

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
        public override bool Equals(object obj) => Value.Equals((obj as SecureDecimal).Value);
    }
}