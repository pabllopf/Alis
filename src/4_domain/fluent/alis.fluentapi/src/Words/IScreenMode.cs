namespace Alis.FluentApi
{
    /// <summary>
    /// The screen mode interface
    /// </summary>
    public interface IScreenMode<Builder, Argument>
    {
        /// <summary>
        /// Screens the mode using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The builder</returns>
        public Builder ScreenMode(Argument value);
    }
}