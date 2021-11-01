using System;

namespace Alis.FluentApi.Validations
{
    public class NotNull<T>
    {
        public NotNull(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public static implicit operator NotNull<T>(T value)
        {
            return new(value ?? throw new ArgumentNullException(typeof(T).FullName));
        }
    }
}