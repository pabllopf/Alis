namespace Alis.Fluent
{ 
    public interface ICreate<L, T>
    {
        public L Create(T obj);
    }
}