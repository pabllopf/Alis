namespace Alis.FluentApi
{
    public interface IManager<Builder, Type, Argument>
    {
        /// <summary>Withes the specified value.</summary>
        /// <param name="value">The value.</param>
        /// <returns>Return that you want.</returns>
        public Builder Manager<T>(Argument value) where T : Type;
    }
}