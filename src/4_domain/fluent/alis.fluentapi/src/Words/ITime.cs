namespace Alis.FluentApi
{
    /// <summary>
    /// The time interface
    /// </summary>
    public interface ITime<Builder, Argument>
    {
        /// <summary>
        /// Times the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The builder</returns>
        public Builder Time(Argument value);
    }
}