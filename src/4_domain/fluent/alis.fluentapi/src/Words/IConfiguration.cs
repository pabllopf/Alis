namespace Alis.FluentApi
{
    /// <summary>
    /// The configuration interface
    /// </summary>
    public interface IConfiguration<Builder, Argument>
    {
        /// <summary>
        /// Configurations the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The builder</returns>
        public Builder Configuration(Argument value);
    }
}