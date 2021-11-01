namespace Alis.FluentApi
{
    /// <summary>
    ///     Define the word "Tag"
    /// </summary>
    /// <typeparam name="Builder">The type of the uilder.</typeparam>
    /// <typeparam name="Argument">The type of the rgument.</typeparam>
    public interface IWithTag<Builder, Argument>
    {
        /// <summary>Withes the tag.</summary>
        /// <param name="value">The value.</param>
        /// <returns>return the object that you want.</returns>
        public Builder WithTag(Argument value);
    }
}