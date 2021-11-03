namespace Alis.FluentApi
{
    /// <summary>
    /// The manager of interface
    /// </summary>
    public interface IManagerOf<Builder, Type, Argument>
    {
        /// <summary>
        /// Managers the of using the specified value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <returns>The builder</returns>
        public Builder ManagerOf<T>(Argument value) where T : Type;
    }
}