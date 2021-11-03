namespace Alis.FluentApi
{
    /// <summary>
    /// The where interface
    /// </summary>
    public interface IWhere<Builder, Argument>
    {
        /// <summary>Wheres the specified value.</summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///     <br />
        /// </returns>
        public Builder Where(Argument value);
    }
}