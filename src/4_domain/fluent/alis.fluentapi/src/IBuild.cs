namespace Alis.FluentApi
{
    /// <summary>
    /// The build interface
    /// </summary>
    public interface IBuild<Origin>
    {
        /// <summary>
        /// Builds this instance
        /// </summary>
        /// <returns>The origin</returns>
        public Origin Build();
    }
}