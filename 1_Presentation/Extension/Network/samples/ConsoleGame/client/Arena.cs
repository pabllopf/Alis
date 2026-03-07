using System.Collections.Generic;

namespace Alis.Extension.Network.Sample.ConsoleGame.Client
{
    /// <summary>
    /// Arena data
    /// </summary>
    public class Arena
    {
        /// <summary>
        /// The width
        /// </summary>
        public const int Width = 40;
        /// <summary>
        /// The height
        /// </summary>
        public const int Height = 25;
        
        /// <summary>
        /// Gets the grid occupancy
        /// </summary>
        public Dictionary<(int, int), string> OccupancyMap { get; } = new Dictionary<(int, int), string>();
    }
}