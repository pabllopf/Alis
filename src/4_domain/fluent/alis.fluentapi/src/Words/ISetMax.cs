namespace Alis.Core
{
    /// <summary>
    /// The set max interface
    /// </summary>
    public interface ISetMax<Builder, Type, Argument>
    {
        /// <summary>
        /// Sets the max using the specified value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <returns>The builder</returns>
        public Builder SetMax<T>(Argument value) where T : Type;
    }
}