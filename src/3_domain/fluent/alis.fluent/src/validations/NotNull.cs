namespace Alis.FluentApi 
{ 
    public class NotNull<T>
    {
        public NotNull(T value) => Value = value;

        public T Value { get; set; }

        public static implicit operator NotNull<T>(T value) => new(value ?? throw new System.ArgumentNullException(typeof(T).FullName));
    }
}
