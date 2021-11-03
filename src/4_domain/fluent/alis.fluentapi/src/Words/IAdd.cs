namespace Alis.FluentApi
{
    /// <summary>
    /// The add interface
    /// </summary>
    public interface IAdd<Builder, Type, Argument>
    {
        /// <summary>
        /// Adds the value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <returns>The builder</returns>
        public Builder Add<T>(Argument value) where T : Type;
    }
}