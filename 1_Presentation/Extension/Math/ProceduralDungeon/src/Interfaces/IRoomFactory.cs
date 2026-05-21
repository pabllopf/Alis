

using Alis.Extension.Math.ProceduralDungeon.Models;

namespace Alis.Extension.Math.ProceduralDungeon.Interfaces
{
    /// <summary>
    ///     Factory interface for creating rooms in a dungeon.
    ///     Defines methods for creating different types of rooms.
    /// </summary>
    public interface IRoomFactory
    {
        /// <summary>
        ///     Creates the first room of the dungeon at a central position.
        /// </summary>
        /// <param name="xPos">The x position of the room.</param>
        /// <param name="yPos">The y position of the room.</param>
        /// <param name="width">The width of the room.</param>
        /// <param name="height">The height of the room.</param>
        /// <returns>A room data instance.</returns>
        RoomData CreateFirstRoom(int xPos, int yPos, int width, int height);

        /// <summary>
        ///     Creates a standard room connected to a corridor.
        /// </summary>
        /// <param name="width">The width of the room.</param>
        /// <param name="height">The height of the room.</param>
        /// <param name="corridor">The corridor to connect the room to.</param>
        /// <returns>A room data instance.</returns>
        RoomData CreateRoom(int width, int height, CorridorData corridor);

        /// <summary>
        ///     Creates a boss room connected to a corridor.
        /// </summary>
        /// <param name="width">The width of the boss room.</param>
        /// <param name="height">The height of the boss room.</param>
        /// <param name="corridor">The corridor to connect the boss room to.</param>
        /// <returns>A room data instance.</returns>
        RoomData CreateBossRoom(int width, int height, CorridorData corridor);
    }
}