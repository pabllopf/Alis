// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoardBuilder.cs
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

using System;
using System.Collections.Generic;
using Alis.Extension.Math.ProceduralDungeon.Interfaces;
using Alis.Extension.Math.ProceduralDungeon.Models;

namespace Alis.Extension.Math.ProceduralDungeon.Services
{
    /// <summary>
    ///     Builder class for constructing dungeon boards.
    ///     Implements the Builder pattern to create complex board structures.
    /// </summary>
    public class BoardBuilder : IBoardBuilder
    {
        /// <summary>
        ///     Creates an empty board with specified dimensions.
        /// </summary>
        /// <param name="width">The width of the board.</param>
        /// <param name="height">The height of the board.</param>
        /// <returns>A 2D array of board squares initialized with Empty type.</returns>
        /// <exception cref="ArgumentException">Thrown when dimensions are invalid.</exception>
        public BoardSquare[,] CreateEmptyBoard(int width, int height)
        {
            if (width <= 0)
                throw new ArgumentException("Width must be greater than 0.", nameof(width));
            
            if (height <= 0)
                throw new ArgumentException("Height must be greater than 0.", nameof(height));

            BoardSquare[,] board = new BoardSquare[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    board[x, y] = new BoardSquare { Type = BoardSquareType.Empty };
                }
            }

            return board;
        }

        /// <summary>
        ///     Places rooms on the board by setting their squares to Floor type.
        /// </summary>
        /// <param name="board">The board to place rooms on.</param>
        /// <param name="rooms">The list of rooms to place.</param>
        /// <exception cref="ArgumentNullException">Thrown when board or rooms is null.</exception>
        public void PlaceRooms(BoardSquare[,] board, IReadOnlyList<RoomData> rooms)
        {
            if (board == null)
                throw new ArgumentNullException(nameof(board));
            
            if (rooms == null)
                throw new ArgumentNullException(nameof(rooms));

            foreach (RoomData room in rooms)
            {
                PlaceRectangularArea(board, room.XPos, room.YPos, room.Width, room.Height);
            }
        }

        /// <summary>
        ///     Places corridors on the board by setting their squares to Floor type.
        /// </summary>
        /// <param name="board">The board to place corridors on.</param>
        /// <param name="corridors">The list of corridors to place.</param>
        /// <exception cref="ArgumentNullException">Thrown when board or corridors is null.</exception>
        public void PlaceCorridors(BoardSquare[,] board, IReadOnlyList<CorridorData> corridors)
        {
            if (board == null)
                throw new ArgumentNullException(nameof(board));
            
            if (corridors == null)
                throw new ArgumentNullException(nameof(corridors));

            foreach (CorridorData corridor in corridors)
            {
                PlaceRectangularArea(board, corridor.XPos, corridor.YPos, corridor.Width, corridor.Height);
            }
        }

        /// <summary>
        ///     Generates walls and corners for the board based on the floor layout.
        ///     Uses a multi-pass algorithm to detect and set appropriate wall and corner types.
        /// </summary>
        /// <param name="board">The board to generate walls and corners for.</param>
        /// <exception cref="ArgumentNullException">Thrown when board is null.</exception>
        public void GenerateWallsAndCorners(BoardSquare[,] board)
        {
            if (board == null)
                throw new ArgumentNullException(nameof(board));

            int width = board.GetLength(0);
            int height = board.GetLength(1);

            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    // Generate walls
                    GenerateWalls(board, x, y);
                    
                    // Generate outer corners
                    GenerateOuterCorners(board, x, y);
                    
                    // Generate inner corners
                    GenerateInnerCorners(board, x, y);
                }
            }
        }

        /// <summary>
        ///     Places a rectangular area on the board by setting squares to Floor type.
        /// </summary>
        /// <param name="board">The board to place the area on.</param>
        /// <param name="xPos">The x position of the area.</param>
        /// <param name="yPos">The y position of the area.</param>
        /// <param name="width">The width of the area.</param>
        /// <param name="height">The height of the area.</param>
        private void PlaceRectangularArea(BoardSquare[,] board, int xPos, int yPos, int width, int height)
        {
            int boardWidth = board.GetLength(0);
            int boardHeight = board.GetLength(1);

            for (int x = xPos; x < xPos + width && x < boardWidth; x++)
            {
                for (int y = yPos; y < yPos + height && y < boardHeight; y++)
                {
                    if (x >= 0 && y >= 0)
                    {
                        board[x, y].Type = BoardSquareType.Floor;
                    }
                }
            }
        }

        /// <summary>
        ///     Generates walls around floor tiles.
        /// </summary>
        /// <param name="board">The board to generate walls on.</param>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <remarks>
        ///     This method checks all four cardinal directions (up, down, left, right)
        ///     and places walls where floor tiles are adjacent to empty spaces.
        /// </remarks>
        private void GenerateWalls(BoardSquare[,] board, int x, int y)
        {
            if (board[x, y].Type != BoardSquareType.Floor)
                return;

            // Check and set walls in all four directions
            // Priority: Down -> Left -> Right -> Top (to ensure consistent results)
            if (board[x, y - 1].Type == BoardSquareType.Empty)
            {
                board[x, y].Type = BoardSquareType.WallDown;
            }
            else if (board[x - 1, y].Type == BoardSquareType.Empty)
            {
                board[x, y].Type = BoardSquareType.WallLeft;
            }
            else if (board[x + 1, y].Type == BoardSquareType.Empty)
            {
                board[x, y].Type = BoardSquareType.WallRight;
            }
            else if (board[x, y + 1].Type == BoardSquareType.Empty)
            {
                board[x, y].Type = BoardSquareType.WallTop;
            }
        }

        /// <summary>
        ///     Generates outer corners for non-empty tiles adjacent to empty spaces.
        /// </summary>
        /// <param name="board">The board to generate corners on.</param>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <remarks>
        ///     Outer corners are placed where a tile meets two empty spaces at perpendicular directions.
        ///     Priority: LeftDown -> RightDown -> LeftUp -> RightUp (to ensure deterministic results).
        /// </remarks>
        private void GenerateOuterCorners(BoardSquare[,] board, int x, int y)
        {
            if (board[x, y].Type == BoardSquareType.Empty)
                return;

            // Check and set outer corners with priority order
            if (board[x - 1, y].Type == BoardSquareType.Empty && board[x, y - 1].Type == BoardSquareType.Empty)
            {
                board[x, y].Type = BoardSquareType.CornerLeftDown;
            }
            else if (board[x + 1, y].Type == BoardSquareType.Empty && board[x, y - 1].Type == BoardSquareType.Empty)
            {
                board[x, y].Type = BoardSquareType.CornerRightDown;
            }
            else if (board[x - 1, y].Type == BoardSquareType.Empty && board[x, y + 1].Type == BoardSquareType.Empty)
            {
                board[x, y].Type = BoardSquareType.CornerLeftUp;
            }
            else if (board[x + 1, y].Type == BoardSquareType.Empty && board[x, y + 1].Type == BoardSquareType.Empty)
            {
                board[x, y].Type = BoardSquareType.CornerRightUp;
            }
        }

        /// <summary>
        ///     Generates inner corners for floor tiles with diagonal empty spaces.
        /// </summary>
        /// <param name="board">The board to generate corners on.</param>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <remarks>
        ///     Inner corners are placed where a floor tile has an empty space diagonally adjacent,
        ///     typically creating concave corners in the dungeon layout.
        ///     Priority: InternalLeftDown -> InternalRightDown -> InternalLeftUp -> InternalRightUp.
        /// </remarks>
        private void GenerateInnerCorners(BoardSquare[,] board, int x, int y)
        {
            if (board[x, y].Type != BoardSquareType.Floor)
                return;

            // Check and set inner corners with priority order
            if (board[x - 1, y - 1].Type == BoardSquareType.Empty)
            {
                board[x, y].Type = BoardSquareType.CornerInternalLeftDown;
            }
            else if (board[x + 1, y - 1].Type == BoardSquareType.Empty)
            {
                board[x, y].Type = BoardSquareType.CornerInternalRightDown;
            }
            else if (board[x - 1, y + 1].Type == BoardSquareType.Empty)
            {
                board[x, y].Type = BoardSquareType.CornerInternalLeftUp;
            }
            else if (board[x + 1, y + 1].Type == BoardSquareType.Empty)
            {
                board[x, y].Type = BoardSquareType.CornerInternalRightUp;
            }
        }
    }
}

