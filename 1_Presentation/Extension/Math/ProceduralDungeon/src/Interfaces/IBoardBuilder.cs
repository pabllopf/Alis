

using System.Collections.Generic;
using Alis.Extension.Math.ProceduralDungeon.Models;

namespace Alis.Extension.Math.ProceduralDungeon.Interfaces
{
    /// <summary>
    ///     Interface for building dungeon boards.
    ///     Defines the contract for creating and configuring dungeon board layouts.
    /// </summary>
    public interface IBoardBuilder
    {
        /// <summary>
        ///     Creates an empty board with specified dimensions.
        /// </summary>
        /// <param name="width">The width of the board.</param>
        /// <param name="height">The height of the board.</param>
        /// <returns>A 2D array of board squares.</returns>
        internal BoardSquare[,] CreateEmptyBoard(int width, int height);

        /// <summary>
        ///     Places rooms on the board.
        /// </summary>
        /// <param name="board">The board to place rooms on.</param>
        /// <param name="rooms">The list of rooms to place.</param>
        internal void PlaceRooms(BoardSquare[,] board, IReadOnlyList<RoomData> rooms);

        /// <summary>
        ///     Places corridors on the board.
        /// </summary>
        /// <param name="board">The board to place corridors on.</param>
        /// <param name="corridors">The list of corridors to place.</param>
        internal void PlaceCorridors(BoardSquare[,] board, IReadOnlyList<CorridorData> corridors);

        /// <summary>
        ///     Generates walls and corners for the board based on floor layout.
        /// </summary>
        /// <param name="board">The board to generate walls and corners for.</param>
        internal void GenerateWallsAndCorners(BoardSquare[,] board);
    }
}