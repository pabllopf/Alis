namespace Alis.FluentApi
{
    public interface IBuilder<T>
    {
        public static T Builder() => (T) System.Activator.CreateInstance(typeof(T), true);
    }
}