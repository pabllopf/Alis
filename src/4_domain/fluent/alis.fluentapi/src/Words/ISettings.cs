namespace Alis.FluentApi
{
    /// <summary>
    /// The settings interface
    /// </summary>
    public interface ISettings<Builder, Argument>
    {
        /// <summary>
        /// Settingses the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The builder</returns>
        public Builder Settings(Argument value);
    }
}