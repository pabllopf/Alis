// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Dungeon.cs
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
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Math.ProceduralDungeon
{
    /// <summary>Random dungeon generator.</summary>
    [Serializable]
    public partial class Dungeon
    {
        /// <summary>The board width</summary>
        public const int BoardWidth = 150;

        /// <summary>The board height</summary>
        public const int BoardHeight = 150;

        /// <summary>The number of rooms</summary>
        public const int NumOfRooms = 4;

        /// <summary>The first room width</summary>
        public const int FirstRoomWidth = 8;

        /// <summary>The first room height</summary>
        public const int FirstRoomHeight = 8;

        /// <summary>The room width</summary>
        public const int RoomWidth = 5;

        /// <summary>The room height</summary>
        public const int RoomHeight = 5;

        /// <summary>The boss room width</summary>
        public const int BossRoomWidth = 7;

        /// <summary>The boss room height</summary>
        public const int BossRoomHeight = 7;

        /// <summary>The corridor width</summary>
        public const int CorridorWidth = 4;

        /// <summary>The corridor height</summary>
        public const int CorridorHeight = 4;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dungeon"/> class
        /// </summary>
        public Dungeon()
        {
            Board = new BoardSquare[BoardWidth, BoardHeight];
            
            for (int x = 0; x < BoardWidth; x++)
            {
                for (int y = 0; y < BoardHeight; y++)
                {
                    if (Board[x, y] is null)
                    {
                        Board[x, y] = new BoardSquare { Type = BoardSquareType.Empty };
                    }
                }
            }
            
            Rooms = new List<Room>(NumOfRooms);
            Corridors = new List<Corridor>(NumOfRooms - 1);
        }

        /// <summary>Gets or sets the board.</summary>
        /// <value>The board.</value>
        [JsonNativePropertyName("board")]
        public BoardSquare[,] Board { get; set; }

        /// <summary>Gets or sets the rooms.</summary>
        /// <value>The rooms.</value>
        [JsonNativePropertyName("rooms")]
        public List<Room> Rooms { get; set; } 

        /// <summary>Gets or sets the corridors.</summary>
        /// <value>The corridors.</value>
        [JsonNativePropertyName("corridors")]
        public List<Corridor> Corridors { get; set; }

        /// <summary>Starts this instance.</summary>
        public void Start()
        {
            SetUpRoomsAndCorridors();
            ConfigRoomsAndCorridors();
            CreateBoard();
        }

        /// <summary>Sets up rooms and corridors.</summary>
        public void SetUpRoomsAndCorridors()
        {
            Rooms.AddRange(new Room[NumOfRooms]);
            Corridors.AddRange(new Corridor[Rooms.Count - 1]);

            Rooms[0] = Room.SetUpFirstRoom(BoardWidth / 2, BoardHeight / 2, FirstRoomWidth, FirstRoomHeight);
            Corridors[0] = Corridor.SetUpFirstCorridor(CorridorWidth, CorridorHeight, Rooms[0]);

            for (int index = 1; index < Rooms.Count; index++)
            {
                Rooms[index] = Room.SetUp(RoomWidth, RoomHeight, Corridors[index - 1]);
                if (index < Corridors.Count)
                {
                    Corridors[index] = Corridor.SetUp(CorridorWidth, CorridorHeight, Rooms[index]);
                }
            }

            Corridors[NumOfRooms - 2] = Corridor.SetUp(CorridorWidth, CorridorHeight, Rooms[NumOfRooms - 2]);
            Rooms[NumOfRooms - 1] = Room.SetUp(BossRoomWidth, BossRoomHeight, Corridors[NumOfRooms - 2]);
        }

        /// <summary>Creates the rooms and corridors.</summary>
        public void ConfigRoomsAndCorridors()
        {
            Rooms.ForEach(room =>
            {
                for (int x = room.XPos; x < room.XPos + room.Width; x++)
                {
                    for (int y = room.YPos; y < room.YPos + room.Height; y++)
                    {
                        Board[x, y].Type = BoardSquareType.Floor;
                    }
                }
            });

            Corridors.ForEach(corridor =>
            {
                for (int x = corridor.XPos; x < corridor.XPos + corridor.Width; x++)
                {
                    for (int y = corridor.YPos; y < corridor.YPos + corridor.Height; y++)
                    {
                        Board[x, y].Type = BoardSquareType.Floor;
                    }
                }
            });
        }

        /// <summary>Creates the board.</summary>
        public void CreateBoard()
        {
            for (int x = 0; x < BoardWidth; x++)
            {
                for (int y = 0; y < BoardHeight; y++)
                {
                    Board[x, y].Type = Board[x, y].Type.Equals(BoardSquareType.Floor) && Board[x, y - 1].Type.Equals(BoardSquareType.Empty) ? BoardSquareType.WallDown : Board[x, y].Type;
                    Board[x, y].Type = Board[x, y].Type.Equals(BoardSquareType.Floor) && Board[x - 1, y].Type.Equals(BoardSquareType.Empty) ? BoardSquareType.WallLeft : Board[x, y].Type;
                    Board[x, y].Type = Board[x, y].Type.Equals(BoardSquareType.Floor) && Board[x + 1, y].Type.Equals(BoardSquareType.Empty) ? BoardSquareType.WallRight : Board[x, y].Type;
                    Board[x, y].Type = Board[x, y].Type.Equals(BoardSquareType.Floor) && Board[x, y + 1].Type.Equals(BoardSquareType.Empty) ? BoardSquareType.WallTop : Board[x, y].Type;

                    Board[x, y].Type = !Board[x, y].Type.Equals(BoardSquareType.Empty) && Board[x - 1, y].Type.Equals(BoardSquareType.Empty) && Board[x, y - 1].Type.Equals(BoardSquareType.Empty) ? BoardSquareType.CornerLeftDown : Board[x, y].Type;
                    Board[x, y].Type = !Board[x, y].Type.Equals(BoardSquareType.Empty) && Board[x + 1, y].Type.Equals(BoardSquareType.Empty) && Board[x, y - 1].Type.Equals(BoardSquareType.Empty) ? BoardSquareType.CornerRightDown : Board[x, y].Type;
                    Board[x, y].Type = !Board[x, y].Type.Equals(BoardSquareType.Empty) && Board[x - 1, y].Type.Equals(BoardSquareType.Empty) && Board[x, y + 1].Type.Equals(BoardSquareType.Empty) ? BoardSquareType.CornerLeftUp : Board[x, y].Type;
                    Board[x, y].Type = !Board[x, y].Type.Equals(BoardSquareType.Empty) && Board[x + 1, y].Type.Equals(BoardSquareType.Empty) && Board[x, y + 1].Type.Equals(BoardSquareType.Empty) ? BoardSquareType.CornerRightUp : Board[x, y].Type;

                    Board[x, y].Type = Board[x, y].Type.Equals(BoardSquareType.Floor) && Board[x - 1, y - 1].Type.Equals(BoardSquareType.Empty) ? BoardSquareType.CornerInternalLeftDown : Board[x, y].Type;
                    Board[x, y].Type = Board[x, y].Type.Equals(BoardSquareType.Floor) && Board[x + 1, y - 1].Type.Equals(BoardSquareType.Empty) ? BoardSquareType.CornerInternalRightDown : Board[x, y].Type;
                    Board[x, y].Type = Board[x, y].Type.Equals(BoardSquareType.Floor) && Board[x - 1, y + 1].Type.Equals(BoardSquareType.Empty) ? BoardSquareType.CornerInternalLeftUp : Board[x, y].Type;
                    Board[x, y].Type = Board[x, y].Type.Equals(BoardSquareType.Floor) && Board[x + 1, y + 1].Type.Equals(BoardSquareType.Empty) ? BoardSquareType.CornerInternalRightUp : Board[x, y].Type;
                }
            }
        }
    }
}