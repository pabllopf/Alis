namespace Alis.Core
{
    /// <summary>
    /// The set interface
    /// </summary>
    public interface ISet<Builder, Type, Argument>
    {
        /// <summary>
        /// Sets the value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <returns>The builder</returns>
        public Builder Set<T>(Argument value) where T : Type;
    }
}