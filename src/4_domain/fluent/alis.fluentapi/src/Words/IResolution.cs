namespace Alis.Core
{
    /// <summary>
    /// The resolution interface
    /// </summary>
    public interface IResolution<Builder, Argument1, Argument2>
    {
        /// <summary>
        /// Resolutions the x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The builder</returns>
        public Builder Resolution(Argument1 x, Argument2 y);
    }
}