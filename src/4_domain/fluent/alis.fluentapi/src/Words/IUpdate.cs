namespace Alis.FluentApi
{
    public interface IUpdate<L, T>
    {
        public L Update(T obj);
    }
}