namespace Alis.Core
{
    /// <summary>
    /// The author interface
    /// </summary>
    public interface IAuthor<Builder, Argument>
    {
        /// <summary>
        /// Authors the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The builder</returns>
        public Builder Author(Argument value);
    }
}