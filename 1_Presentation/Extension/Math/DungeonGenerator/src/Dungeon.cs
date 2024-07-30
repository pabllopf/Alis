//------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Dungeon.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Entity;

namespace Alis.Extension.Math.DungeonGenerator
{
    /// <summary>Random dungeon generator.</summary>
    public class Dungeon 
    {
        /// <summary>The board width</summary>
        public const int BoardWidth = 100;

        /// <summary>The board height</summary>
        public const int BoardHeight = 100;

        /// <summary>The number of rooms</summary>
        public const int NumOfRooms = 5;
        
        /// <summary>The first room width</summary>
        public const int FirstRoomWidth = 10;

        /// <summary>The first room height</summary>
        public const int FirstRoomHeight = 10;

        /// <summary>The room width</summary>
        public const int RoomWidth = 8;

        /// <summary>The room height</summary>
        public const int RoomHeight = 8;

        /// <summary>The boss room width</summary>
        public const int BossRoomWidth = 10;

        /// <summary>The boss room height</summary>
        public const int BossRoomHeight = 10;
        
        /// <summary>The corridor width</summary>
        public const int CorridorWidth = 4;

        /// <summary>The corridor height</summary>
        public const int CorridorHeight = 4;
        
        /// <summary>The board</summary>
        public CellBox[,] board = new CellBox[BoardWidth, BoardHeight];

        /// <summary>The rooms</summary>
        public List<Room> rooms = new List<Room>();

        /// <summary>The corridors</summary>
        public List<Corridor> corridors = new List<Corridor>();

        /// <summary>The master to</summary>
        [JsonPropertyName("MasterTo:")]
        public GameObject masterTo = null;

        /// <summary>The altar</summary>
        [JsonPropertyName("Altar:")]
        public GameObject altar = null;

        /// <summary>The portal</summary>
        [JsonPropertyName("Portal:")]
        public GameObject portal = null;
        
        /// <summary>Gets or sets the board.</summary>
        /// <value>The board.</value>
        public CellBox[,] Board { get => board; set => board = value; }

        /// <summary>Gets or sets the rooms.</summary>
        /// <value>The rooms.</value>
        public List<Room> Rooms { get => rooms; set => rooms = value; }

        /// <summary>Gets or sets the corridors.</summary>
        /// <value>The corridors.</value>
        public List<Corridor> Corridors { get => corridors; set => corridors = value; }

        /// <summary>Gets or sets the altar.</summary>
        /// <value>The altar.</value>
        public GameObject Altar { get => altar; set => altar = value; }

        /// <summary>Gets the random style.</summary>
        /// <value>The random style.</value>
        public Style Style { get; } = new Style();

        /// <summary>Gets or sets the portal.</summary>
        /// <value>The portal.</value>
        public GameObject Portal { get => portal; set => portal = value; }
        
        /// <summary>Gets or sets the master to.</summary>
        /// <value>The master to.</value>
        public GameObject MasterTo { get => masterTo; set => masterTo = value; }
        
        /// <summary>Starts this instance.</summary>
        public void Start()
        {
            SetUpRoomsAndCorridors();

            ConfigInitialRoom();
            ConfigRoomsAndCorridors();

            CreateBoard();
            
            PrintDungeon(Style);
            PrintBoss();
        }

        /// <summary>Sets up rooms and corridors.</summary>
        public void SetUpRoomsAndCorridors()
        {
            masterTo = GameObject
                .Create()
                .Name("Dungeon")
                .Build();

            rooms.AddRange(new Room[NumOfRooms]);
            corridors.AddRange(new Corridor[rooms.Count - 1]);

            rooms[0] = Room.SetUpFirstRoom(BoardWidth / 2, BoardHeight / 2, FirstRoomWidth, FirstRoomHeight);
            corridors[0] = Corridor.SetUpFirstCorridor(CorridorWidth, CorridorHeight, rooms[0]);

            for (int index = 1; index < rooms.Count; index++)
            {
                rooms[index] = Room.SetUp(RoomWidth, RoomHeight, corridors[index - 1]);
                if (index < corridors.Count)
                {
                    corridors[index] = Corridor.SetUp(CorridorWidth, CorridorHeight, rooms[index]);
                }
            }

            corridors[NumOfRooms - 2] = Corridor.SetUp(CorridorWidth, CorridorHeight, rooms[NumOfRooms - 2]);
            rooms[NumOfRooms - 1] = Room.SetUp(BossRoomWidth, BossRoomHeight, corridors[NumOfRooms - 2]);
        }

        /// <summary>Creates the rooms and corridors.</summary>
        public void ConfigRoomsAndCorridors()
        {
            rooms.ForEach(room =>
            {
                for (int x = room.XPos; x < room.XPos + room.Width; x++)
                {
                    for (int y = room.YPos; y < room.YPos + room.Height; y++)
                    {
                        board[x, y] = CellBox.Floor;
                    }
                }
            });

            corridors.ForEach(corridor =>
            {
                for (int x = corridor.XPos; x < corridor.XPos + corridor.Width; x++)
                {
                    for (int y = corridor.YPos; y < corridor.YPos + corridor.Height; y++)
                    {
                        board[x, y] = CellBox.Floor;
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
                    board[x, y] = (board[x, y].Equals(CellBox.Floor) && board[x, y - 1].Equals(CellBox.Empty)) ? CellBox.WallDown : board[x, y];
                    board[x, y] = (board[x, y].Equals(CellBox.Floor) && board[x - 1, y].Equals(CellBox.Empty)) ? CellBox.WallLeft : board[x, y];
                    board[x, y] = (board[x, y].Equals(CellBox.Floor) && board[x + 1, y].Equals(CellBox.Empty)) ? CellBox.WallRight : board[x, y];
                    board[x, y] = (board[x, y].Equals(CellBox.Floor) && board[x, y + 1].Equals(CellBox.Empty)) ? CellBox.WallTop : board[x, y];

                    board[x, y] = (!board[x, y].Equals(CellBox.Empty) && board[x - 1, y].Equals(CellBox.Empty) && board[x, y - 1].Equals(CellBox.Empty)) ? CellBox.CornerLeftDown : board[x, y];
                    board[x, y] = (!board[x, y].Equals(CellBox.Empty) && board[x + 1, y].Equals(CellBox.Empty) && board[x, y - 1].Equals(CellBox.Empty)) ? CellBox.CornerRightDown : board[x, y];
                    board[x, y] = (!board[x, y].Equals(CellBox.Empty) && board[x - 1, y].Equals(CellBox.Empty) && board[x, y + 1].Equals(CellBox.Empty)) ? CellBox.CornerLeftUp : board[x, y];
                    board[x, y] = (!board[x, y].Equals(CellBox.Empty) && board[x + 1, y].Equals(CellBox.Empty) && board[x, y + 1].Equals(CellBox.Empty)) ? CellBox.CornerRightUp : board[x, y];

                    board[x, y] = (board[x, y].Equals(CellBox.Floor) && board[x - 1, y - 1].Equals(CellBox.Empty)) ? CellBox.CornerInternalLeftDown : board[x, y];
                    board[x, y] = (board[x, y].Equals(CellBox.Floor) && board[x + 1, y - 1].Equals(CellBox.Empty)) ? CellBox.CornerInternalRightDown : board[x, y];
                    board[x, y] = (board[x, y].Equals(CellBox.Floor) && board[x - 1, y + 1].Equals(CellBox.Empty)) ? CellBox.CornerInternalLeftUp : board[x, y];
                    board[x, y] = (board[x, y].Equals(CellBox.Floor) && board[x + 1, y + 1].Equals(CellBox.Empty)) ? CellBox.CornerInternalRightUp : board[x, y];
                }
            }
        }

        /// <summary>Configurations the initial room.</summary>
        public void ConfigInitialRoom()
        {
            Vector2 center = new Vector2((BoardWidth / 2) + (FirstRoomWidth / 2), (BoardHeight / 2) + (FirstRoomHeight / 2));

            GameObject altarTop = GameObject.Create()
                .Name("Altar Top")
                .Transform(transform => transform
                    .Position(center + new Vector2(1.5f, 1.5f))
                    .Build())
                .Build();
            
            GameObject altarDown = GameObject.Create()
                .Name("Altar Down")
                .Transform(transform => transform
                    .Position(center + new Vector2(-1.5f, -1.5f))
                    .Build())
                .Build();
            
            GameObject altarLeft = GameObject.Create()
                .Name("Altar Left")
                .Transform(transform => transform
                    .Position(center + new Vector2(-1.5f, 1.5f))
                    .Build())
                .Build();
            
            GameObject altarRight = GameObject.Create()
                .Name("Altar Right")
                .Transform(transform => transform
                    .Position(center + new Vector2(1.5f, -1.5f))
                    .Build())
                .Build();
        }

        /// <summary>Prints the dungeon.</summary>
        /// <param name="style">The style.</param>
        public void PrintDungeon(Style style)
        {
            for (int x = 0; x < BoardWidth; x++)
            {
                for (int y = 0; y < BoardHeight; y++)
                {
                    if (board[x, y] != CellBox.Empty)
                    {
                        GameObject obj =  GameObject.Create()
                            .Name(board[x, y].ToString())
                            .Transform(transform => transform
                                .Position(new Vector2(x, y))
                                .Build())
                            .Build();
                    }
                }
            }

            PrintDecoration(style);
            PrintEnemys(style);
        }

        
        /// <summary>Prints the decoration.</summary>
        /// <param name="style">The style.</param>
        public void PrintDecoration(Style style)
        {
            style.Decorations
                .FindAll(deco => (deco.MinToSpawn != 0 && deco.MaxToSpawn != 0 && deco.TypeCellBoxToSpawn != CellBox.Empty))
                .ForEach(deco =>
                {
                    int quantity = new Random().Next(deco.MinToSpawn, deco.MaxToSpawn);
                    GameObject master = GameObject.Create()
                        .Name(deco.Prefab.Name + " (" + quantity + ")")
                        .Build();

                    while (quantity > 0)
                    {
                        for (int x = 0; x < BoardWidth; x++)
                        {
                            for (int y = 0; y < BoardHeight; y++)
                            {
                                if (board[x, y] != CellBox.Empty)
                                {
                                    if (board[x, y] == deco.TypeCellBoxToSpawn && new Random().Next(0, 1000) == 1)
                                    {
                                        board[x, y] = CellBox.Empty;
                                        quantity--;
                                        
                                        GameObject obj = GameObject.Create()
                                            .Name(deco.Prefab.Name + " (" + quantity + ")")
                                            .Transform(transform => transform
                                                .Position(new Vector2(x, y))
                                                .Build())
                                            .Build();
                                    }
                                }
                            }
                        }
                    }
                });
        }

        /// <summary>
        /// Prints the enemys using the specified style
        /// </summary>
        /// <param name="style">The style</param>
        public void PrintEnemys(Style style) 
        {
            style.Enemys
                .FindAll(deco => (deco.MinToSpawn != 0 && deco.MaxToSpawn != 0 && deco.TypeCellBoxToSpawn != CellBox.Empty))
                .ForEach(deco =>
                {
                    int quantity = new Random().Next(deco.MinToSpawn, deco.MaxToSpawn);
                    GameObject master = GameObject.Create()
                        .Name(deco.Prefab.Name + " (" + quantity + ")")
                        .Build();

                    while (quantity > 0)
                    {
                        for (int x = 0; x < BoardWidth; x++)
                        {
                            for (int y = 0; y < BoardHeight; y++)
                            {
                                if (board[x, y] != CellBox.Empty)
                                {
                                    if (board[x, y] == deco.TypeCellBoxToSpawn && new Random().Next(0, 1000) == 1)
                                    {
                                        board[x, y] = CellBox.Empty;
                                        quantity--;
                                        
                                        GameObject obj = GameObject.Create()
                                            .Name(deco.Prefab.Name + " (" + quantity + ")")
                                            .Transform(transform => transform
                                                .Position(new Vector2(x, y))
                                                .Build())
                                            .Build();
                                    }
                                }
                            }
                        }
                    }
                });
        }

        /// <summary>
        /// Prints the boss
        /// </summary>
        public void PrintBoss() 
        {
            Vector2 posToSpawn = new Vector2(rooms[NumOfRooms - 1].XPos + rooms[NumOfRooms - 1].Width/2, rooms[NumOfRooms - 1].YPos + rooms[NumOfRooms - 1].Height/2);
            GameObject master = GameObject.Create()
                .Name("Boss")
                .Build();
            
            GameObject obj = GameObject.Create()
                .Name("Boss")
                .Transform(transform => transform
                    .Position(posToSpawn)
                    .Build())
                .Build();
        }
    }
}