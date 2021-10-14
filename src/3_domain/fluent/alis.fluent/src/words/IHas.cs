namespace Alis.Fluent 
{ 
    public interface IHas<L, T>
    {
        public L Has(T obj);
    }
}