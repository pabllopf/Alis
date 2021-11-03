namespace Alis.FluentApi
{
    /// <summary>
    /// The create interface
    /// </summary>
    public interface ICreate<L, T>
    {
        /// <summary>
        /// Creates the obj
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <returns>The</returns>
        public L Create(T obj);
    }
}