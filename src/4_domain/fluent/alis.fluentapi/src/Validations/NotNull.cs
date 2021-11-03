using System;

namespace Alis.FluentApi.Validations
{
    /// <summary>
    /// The not null class
    /// </summary>
    public class NotNull<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotNull"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public NotNull(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets or sets the value of the value
        /// </summary>
        public T Value { get; set; }

        public static implicit operator NotNull<T>(T value)
        {
            return new(value ?? throw new ArgumentNullException(typeof(T).FullName));
        }
    }
}