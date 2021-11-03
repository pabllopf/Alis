namespace Alis.FluentApi
{
    /// <summary>
    /// The update interface
    /// </summary>
    public interface IUpdate<L, T>
    {
        /// <summary>
        /// Updates the obj
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <returns>The</returns>
        public L Update(T obj);
    }
}