namespace Alis.FluentApi
{
    /// <summary>
    /// The is interface
    /// </summary>
    public interface IIs<Builder, Type, Argument>
    {
        /// <summary>
        /// Ises the value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <returns>The builder</returns>
        public Builder Is<T>(Argument value) where T : Type;
    }
}