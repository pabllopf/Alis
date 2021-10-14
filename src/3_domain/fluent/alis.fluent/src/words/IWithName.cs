namespace Alis.Fluent
{
    /// <summary>Define the word "Name" </summary>
    /// <typeparam name="Builder">The type of the uilder.</typeparam>
    /// <typeparam name="Argument">The type of the rgument.</typeparam>
    public interface IWithName<Builder, Argument>
    {
        /// <summary>Withes the name.</summary>
        /// <param name="value">The value.</param>
        /// <returns>Return the value that you want.</returns>
        public Builder WithName(Argument value);
    }
}