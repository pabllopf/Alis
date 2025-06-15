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

using System.Collections.Generic;

namespace Alis.Extension.Math.ProceduralDungeon
{
    /// <summary>Random dungeon generator.</summary>
    public class Dungeon
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

        /// <summary>Gets or sets the board.</summary>
        /// <value>The board.</value>
        public BoardSquare[,] Board { get; } = new BoardSquare[BoardWidth, BoardHeight];

        /// <summary>Gets or sets the rooms.</summary>
        /// <value>The rooms.</value>
        public List<Room> Rooms { get; } = new List<Room>();

        /// <summary>Gets or sets the corridors.</summary>
        /// <value>The corridors.</value>
        public List<Corridor> Corridors { get; } = new List<Corridor>();

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
                        Board[x, y] = BoardSquare.Floor;
                    }
                }
            });

            Corridors.ForEach(corridor =>
            {
                for (int x = corridor.XPos; x < corridor.XPos + corridor.Width; x++)
                {
                    for (int y = corridor.YPos; y < corridor.YPos + corridor.Height; y++)
                    {
                        Board[x, y] = BoardSquare.Floor;
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
                    Board[x, y] = Board[x, y].Equals(BoardSquare.Floor) && Board[x, y - 1].Equals(BoardSquare.Empty) ? BoardSquare.WallDown : Board[x, y];
                    Board[x, y] = Board[x, y].Equals(BoardSquare.Floor) && Board[x - 1, y].Equals(BoardSquare.Empty) ? BoardSquare.WallLeft : Board[x, y];
                    Board[x, y] = Board[x, y].Equals(BoardSquare.Floor) && Board[x + 1, y].Equals(BoardSquare.Empty) ? BoardSquare.WallRight : Board[x, y];
                    Board[x, y] = Board[x, y].Equals(BoardSquare.Floor) && Board[x, y + 1].Equals(BoardSquare.Empty) ? BoardSquare.WallTop : Board[x, y];

                    Board[x, y] = !Board[x, y].Equals(BoardSquare.Empty) && Board[x - 1, y].Equals(BoardSquare.Empty) && Board[x, y - 1].Equals(BoardSquare.Empty) ? BoardSquare.CornerLeftDown : Board[x, y];
                    Board[x, y] = !Board[x, y].Equals(BoardSquare.Empty) && Board[x + 1, y].Equals(BoardSquare.Empty) && Board[x, y - 1].Equals(BoardSquare.Empty) ? BoardSquare.CornerRightDown : Board[x, y];
                    Board[x, y] = !Board[x, y].Equals(BoardSquare.Empty) && Board[x - 1, y].Equals(BoardSquare.Empty) && Board[x, y + 1].Equals(BoardSquare.Empty) ? BoardSquare.CornerLeftUp : Board[x, y];
                    Board[x, y] = !Board[x, y].Equals(BoardSquare.Empty) && Board[x + 1, y].Equals(BoardSquare.Empty) && Board[x, y + 1].Equals(BoardSquare.Empty) ? BoardSquare.CornerRightUp : Board[x, y];

                    Board[x, y] = Board[x, y].Equals(BoardSquare.Floor) && Board[x - 1, y - 1].Equals(BoardSquare.Empty) ? BoardSquare.CornerInternalLeftDown : Board[x, y];
                    Board[x, y] = Board[x, y].Equals(BoardSquare.Floor) && Board[x + 1, y - 1].Equals(BoardSquare.Empty) ? BoardSquare.CornerInternalRightDown : Board[x, y];
                    Board[x, y] = Board[x, y].Equals(BoardSquare.Floor) && Board[x - 1, y + 1].Equals(BoardSquare.Empty) ? BoardSquare.CornerInternalLeftUp : Board[x, y];
                    Board[x, y] = Board[x, y].Equals(BoardSquare.Floor) && Board[x + 1, y + 1].Equals(BoardSquare.Empty) ? BoardSquare.CornerInternalRightUp : Board[x, y];
                }
            }
        }
    }
}