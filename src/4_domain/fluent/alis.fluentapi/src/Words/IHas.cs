namespace Alis.FluentApi
{
    /// <summary>
    /// The has interface
    /// </summary>
    public interface IHas<L, T>
    {
        /// <summary>
        /// Hases the obj
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <returns>The</returns>
        public L Has(T obj);
    }
}