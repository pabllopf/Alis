

using System;

namespace Alis.Extension.Network.Sample.ConsoleGame.Client
{
    /// <summary>
    ///     Movement system for validating movements
    /// </summary>
    public class MoveSystem
    {
        /// <summary>
        ///     Validates if a move is legal
        /// </summary>
        /// <param name="x">The x coordinate</param>
        /// <param name="y">The y coordinate</param>
        /// <returns>True if the move is valid</returns>
        public static bool IsValidMove(int x, int y) => (x >= 0) && (x < Arena.Width) && (y >= 0) && (y < Arena.Height);

        /// <summary>
        ///     Gets distance between two points
        /// </summary>
        /// <param name="x1">The x1 coordinate</param>
        /// <param name="y1">The y1 coordinate</param>
        /// <param name="x2">The x2 coordinate</param>
        /// <param name="y2">The y2 coordinate</param>
        /// <returns>The distance</returns>
        public static float GetDistance(int x1, int y1, int x2, int y2) => (float) Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
    }
}