

namespace Alis.Extension.Math.ProceduralDungeon.Interfaces
{
    /// <summary>
    ///     Interface for random number generation.
    ///     Provides abstraction for generating random numbers to improve testability.
    /// </summary>
    public interface IRandomNumberGenerator
    {
        /// <summary>
        ///     Generates a random integer within the specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The exclusive upper bound of the random number returned.</param>
        /// <returns>A random integer between minValue (inclusive) and maxValue (exclusive).</returns>
        int Next(int minValue, int maxValue);

        /// <summary>
        ///     Generates a random integer between 0 and maxValue.
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound of the random number returned.</param>
        /// <returns>A random integer between 0 (inclusive) and maxValue (exclusive).</returns>
        int Next(int maxValue);

        /// <summary>
        ///     Generates a random byte value.
        /// </summary>
        /// <returns>A random byte value.</returns>
        byte NextByte();
    }
}