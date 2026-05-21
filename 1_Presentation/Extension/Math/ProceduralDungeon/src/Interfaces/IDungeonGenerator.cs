

using Alis.Extension.Math.ProceduralDungeon.Models;

namespace Alis.Extension.Math.ProceduralDungeon.Interfaces
{
    /// <summary>
    ///     Interface for dungeon generation operations.
    ///     Defines the contract for generating procedural dungeons.
    /// </summary>
    public interface IDungeonGenerator
    {
        /// <summary>
        ///     Generates a complete dungeon with rooms, corridors, and board layout.
        /// </summary>
        /// <returns>A fully generated dungeon instance.</returns>
        DungeonData Generate();
    }
}