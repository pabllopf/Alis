namespace Alis.FluentApi
{
    /// <summary>Define the word 'With' </summary>
    /// <typeparam name="Builder">The type of the uilder.</typeparam>
    /// <typeparam name="Argument">The type of the rgument.</typeparam>
    public interface IWith<Builder, Type, Argument>
    {
        /// <summary>Withes the specified value.</summary>
        /// <param name="value">The value.</param>
        /// <returns>Return that you want.</returns>
        public Builder With<T>(Argument value) where T : Type;
    }
}