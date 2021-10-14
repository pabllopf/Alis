namespace Alis.Fluent
{
    public interface IUpdate<L, T>
    {
        public L Update(T obj);
    }
}