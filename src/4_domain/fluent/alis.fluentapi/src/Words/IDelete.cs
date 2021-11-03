namespace Alis.FluentApi
{
    /// <summary>
    /// The delete interface
    /// </summary>
    public interface IDelete<T>
    {
        /// <summary>
        /// Deletes this instance
        /// </summary>
        /// <returns>The</returns>
        public T Delete();
    }
}