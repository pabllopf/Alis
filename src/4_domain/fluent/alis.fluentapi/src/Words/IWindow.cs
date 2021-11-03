namespace Alis.FluentApi
{
    /// <summary>
    /// The window interface
    /// </summary>
    public interface IWindow<Builder, Argument>
    {
        /// <summary>
        /// Windows the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The builder</returns>
        public Builder Window(Argument value);
    }
}