

using Alis.Extension.Math.ProceduralDungeon.Models;

namespace Alis.Extension.Math.ProceduralDungeon.Interfaces
{
    /// <summary>
    ///     Factory interface for creating corridors in a dungeon.
    ///     Defines methods for creating different types of corridors that connect rooms.
    /// </summary>
    public interface ICorridorFactory
    {
        /// <summary>
        ///     Creates the first corridor connected to the starting room.
        /// </summary>
        /// <param name="width">The width of the corridor.</param>
        /// <param name="height">The height of the corridor.</param>
        /// <param name="room">The room to connect the corridor to.</param>
        /// <returns>A corridor data instance.</returns>
        CorridorData CreateFirstCorridor(int width, int height, RoomData room);

        /// <summary>
        ///     Creates a standard corridor connected to a room.
        /// </summary>
        /// <param name="width">The width of the corridor.</param>
        /// <param name="height">The height of the corridor.</param>
        /// <param name="room">The room to connect the corridor to.</param>
        /// <returns>A corridor data instance.</returns>
        CorridorData CreateCorridor(int width, int height, RoomData room);
    }
}