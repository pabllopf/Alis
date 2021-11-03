namespace Alis.FluentApi
{
    /// <summary>
    /// The general interface
    /// </summary>
    public interface IGeneral<Builder, Argument>
    {
        /// <summary>
        /// Generals the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The builder</returns>
        public Builder General(Argument value);
    }
}