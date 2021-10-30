namespace Alis.FluentApi
{ 
    public interface ICreate<L, T>
    {
        public L Create(T obj);
    }
}