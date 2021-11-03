namespace Alis.Core
{
    /// <summary>
    /// The name interface
    /// </summary>
    public interface IName<Builder, Argument>
    {
        /// <summary>
        /// Names the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The builder</returns>
        public Builder Name(Argument value);
    }
}