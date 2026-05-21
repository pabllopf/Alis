

namespace Alis.Extension.Security
{
    /// <summary>
    ///     The secure float class
    /// </summary>
    public class SecureFloat
    {
        /// <summary>
        ///     The random value
        /// </summary>
        private float _randomValue;

        /// <summary>
        ///     The value
        /// </summary>
        private float _value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SecureFloat" /> class
        /// </summary>
        /// <param name="value">The value</param>
        public SecureFloat(float value = 0.0f) => Value = value;

        /// <summary>
        ///     Gets or sets the value of the value
        /// </summary>
        private float Value
        {
            get => _value - _randomValue;

            set
            {
                unchecked
                {
                    _randomValue = SecureRandom.NextFloat(-1024, 1024);
                    _value = value + _randomValue;
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator SecureFloat(float value) => new SecureFloat(value);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator float(SecureFloat value) => value.Value;

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(SecureFloat a, SecureFloat b) => SecureRandom.Abs(a.Value - b.Value) < 0.01f;

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(SecureFloat a, SecureFloat b) => SecureRandom.Abs(a.Value - b.Value) > 0.01f;

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static SecureFloat operator ++(SecureFloat a)
        {
            a.Value++;
            return a;
        }

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static SecureFloat operator --(SecureFloat a)
        {
            a.Value--;
            return a;
        }

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureFloat operator +(SecureFloat a, SecureFloat b) => new SecureFloat(a.Value + b.Value);

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureFloat operator -(SecureFloat a, SecureFloat b) => new SecureFloat(a.Value - b.Value);

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureFloat operator *(SecureFloat a, SecureFloat b) => new SecureFloat(a.Value * b.Value);

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureFloat operator /(SecureFloat a, SecureFloat b) => new SecureFloat(a.Value / b.Value);

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
        public override bool Equals(object obj) => Value.Equals((obj as SecureFloat).Value);
    }
}