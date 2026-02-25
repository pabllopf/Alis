// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
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
using Alis.Extension.Math.ProceduralDungeon;
using Alis.Extension.Math.ProceduralDungeon.Helpers;
using Alis.Extension.Math.ProceduralDungeon.Models;

namespace Sample
{
    /// <summary>
    ///     Sample program demonstrating procedural dungeon generation.
    /// </summary>
    internal class Program
    {
        /// <summary>
        ///     Main entry point for the sample application.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        private static void Main(string[] args)
        {
            Console.WriteLine("=== Procedural Dungeon Generator 2D - Sample ===\n");

            // Example 1: Generate a dungeon with default configuration
            Console.WriteLine("Example 1: Default Configuration");
            Console.WriteLine("----------------------------------");
            GenerateDefaultDungeon();
            Console.WriteLine();

            // Example 2: Generate a dungeon with custom configuration
            Console.WriteLine("Example 2: Custom Configuration");
            Console.WriteLine("----------------------------------");
            GenerateCustomDungeon();
            Console.WriteLine();

            // Example 3: Generate multiple dungeons
            Console.WriteLine("Example 3: Multiple Dungeons");
            Console.WriteLine("----------------------------------");
            GenerateMultipleDungeons(3);
            Console.WriteLine();

            // Example 4: Visualize a dungeon
            Console.WriteLine("Example 4: Dungeon Visualization");
            Console.WriteLine("----------------------------------");
            VisualizeDungeon();
            Console.WriteLine();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        ///     Generates a dungeon with default configuration.
        /// </summary>
        private static void GenerateDefaultDungeon()
        {
            // Create dungeon with default settings using 'using' statement for proper disposal
            using Dungeon dungeon = new Dungeon();
            
            // Generate the dungeon
            DungeonData data = dungeon.Generate();
            
            // Display information
            Console.WriteLine($"Board Size: {data.Width}x{data.Height}");
            Console.WriteLine($"Total Rooms: {data.Rooms.Count}");
            Console.WriteLine($"Total Corridors: {data.Corridors.Count}");
            
            // Display room information
            Console.WriteLine("\nRooms:");
            for (int i = 0; i < data.Rooms.Count; i++)
            {
                RoomData room = data.Rooms[i];
                string roomType = room.IsBossRoom ? "Boss Room" : $"Room {i + 1}";
                Console.WriteLine($"  {roomType}: Position({room.XPos}, {room.YPos}), " +
                                $"Size({room.Width}x{room.Height}), " +
                                $"Direction: {room.Direction}");
            }
        }

        /// <summary>
        ///     Generates a dungeon with custom configuration.
        /// </summary>
        private static void GenerateCustomDungeon()
        {
            // Create custom configuration
            DungeonConfiguration config = new DungeonConfiguration
            {
                BoardWidth = 200,
                BoardHeight = 200,
                NumberOfRooms = 8,
                FirstRoomWidth = 10,
                FirstRoomHeight = 10,
                RoomWidth = 6,
                RoomHeight = 6,
                BossRoomWidth = 12,
                BossRoomHeight = 12,
                CorridorWidth = 5,
                CorridorHeight = 5
            };

            // Create dungeon with custom configuration using 'using' statement
            using Dungeon dungeon = new Dungeon(config);
            
            // Generate the dungeon
            DungeonData data = dungeon.Generate();
            
            // Display information
            Console.WriteLine($"Board Size: {data.Width}x{data.Height}");
            Console.WriteLine($"Total Rooms: {data.Rooms.Count}");
            Console.WriteLine($"Total Corridors: {data.Corridors.Count}");
            
            // Count different square types using helper methods
            int floorCount = 0;
            int wallCount = 0;
            int cornerCount = 0;
            
            for (int x = 0; x < data.Width; x++)
            {
                for (int y = 0; y < data.Height; y++)
                {
                    BoardSquareType type = data.Board[x, y].Type;
                    if (BoardSquareTypeHelper.IsWalkable(type))
                        floorCount++;
                    else if (BoardSquareTypeHelper.IsWall(type))
                        wallCount++;
                    else if (BoardSquareTypeHelper.IsCorner(type))
                        cornerCount++;
                }
            }
            
            Console.WriteLine($"\nBoard Statistics:");
            Console.WriteLine($"  Floor Tiles: {floorCount}");
            Console.WriteLine($"  Wall Tiles: {wallCount}");
            Console.WriteLine($"  Corner Tiles: {cornerCount}");
        }

        /// <summary>
        ///     Generates multiple dungeons.
        /// </summary>
        /// <param name="count">The number of dungeons to generate.</param>
        private static void GenerateMultipleDungeons(int count)
        {
            Console.WriteLine($"Generating {count} dungeons...\n");
            
            // Use a single dungeon instance for multiple generations
            using Dungeon dungeon = new Dungeon();
            
            for (int i = 0; i < count; i++)
            {
                DungeonData data = dungeon.Generate();
                
                Console.WriteLine($"Dungeon {i + 1}:");
                Console.WriteLine($"  Size: {data.Width}x{data.Height}");
                Console.WriteLine($"  Rooms: {data.Rooms.Count}");
                Console.WriteLine($"  Corridors: {data.Corridors.Count}");
                Console.WriteLine();
            }
        }

        
        /// <summary>
        ///     Visualizes a dungeon in the console.
        /// </summary>
        private static void VisualizeDungeon()
        {
            // Create a smaller dungeon for visualization
            DungeonConfiguration config = new DungeonConfiguration
            {
                BoardWidth = 50,
                BoardHeight = 30,
                NumberOfRooms = 3,
                FirstRoomWidth = 6,
                FirstRoomHeight = 6,
                RoomWidth = 4,
                RoomHeight = 4,
                BossRoomWidth = 5,
                BossRoomHeight = 5,
                CorridorWidth = 3,
                CorridorHeight = 3
            };

            using Dungeon dungeon = new Dungeon(config);
            DungeonData data = dungeon.Generate();
            
            Console.WriteLine($"Dungeon Map ({data.Width}x{data.Height}):");
            Console.WriteLine();
            
            // Find min and max bounds to display only relevant area
            int minX = data.Width, maxX = 0, minY = data.Height, maxY = 0;
            for (int x = 0; x < data.Width; x++)
            {
                for (int y = 0; y < data.Height; y++)
                {
                    if (data.Board[x, y].Type != BoardSquareType.Empty)
                    {
                        minX = System.Math.Min(minX, x);
                        maxX = System.Math.Max(maxX, x);
                        minY = System.Math.Min(minY, y);
                        maxY = System.Math.Max(maxY, y);
                    }
                }
            }
            
            // Add padding
            minX = System.Math.Max(0, minX - 2);
            maxX = System.Math.Min(data.Width - 1, maxX + 2);
            minY = System.Math.Max(0, minY - 2);
            maxY = System.Math.Min(data.Height - 1, maxY + 2);
            
            // Display the dungeon
            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    char symbol = GetSymbolForSquare(data.Board[x, y].Type);
                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
            
            Console.WriteLine("\nLegend:");
            Console.WriteLine("  . = Empty");
            Console.WriteLine("  # = Wall");
            Console.WriteLine("  + = Corner");
            Console.WriteLine("    = Floor");
        }

        /// <summary>
        ///     Gets the console character symbol for a board square type.
        /// </summary>
        /// <param name="type">The board square type.</param>
        /// <returns>A character representing the square type.</returns>
        private static char GetSymbolForSquare(BoardSquareType type)
        {
            return BoardSquareTypeHelper.GetDisplayCharacter(type);
        }
    }
}

