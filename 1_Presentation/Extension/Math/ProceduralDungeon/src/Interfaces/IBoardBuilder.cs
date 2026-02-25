// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IBoardBuilder.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

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
        BoardSquare[,] CreateEmptyBoard(int width, int height);
        
        /// <summary>
        ///     Places rooms on the board.
        /// </summary>
        /// <param name="board">The board to place rooms on.</param>
        /// <param name="rooms">The list of rooms to place.</param>
        void PlaceRooms(BoardSquare[,] board, IReadOnlyList<RoomData> rooms);
        
        /// <summary>
        ///     Places corridors on the board.
        /// </summary>
        /// <param name="board">The board to place corridors on.</param>
        /// <param name="corridors">The list of corridors to place.</param>
        void PlaceCorridors(BoardSquare[,] board, IReadOnlyList<CorridorData> corridors);
        
        /// <summary>
        ///     Generates walls and corners for the board based on floor layout.
        /// </summary>
        /// <param name="board">The board to generate walls and corners for.</param>
        void GenerateWallsAndCorners(BoardSquare[,] board);
    }
}

