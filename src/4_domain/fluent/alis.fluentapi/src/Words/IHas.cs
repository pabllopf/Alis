namespace Alis.FluentApi
{
    public interface IHas<L, T>
    {
        public L Has(T obj);
    }
}