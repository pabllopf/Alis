namespace Alis.Core
{
    public interface IUpdate<L, T>
    {
        public L Update(T obj);
    }
}