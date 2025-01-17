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
using Alis.Core.Aspect.Logging;

namespace Alis.Extension.Math.DungeonGenerator.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main
        /// </summary>
        public static void Main()
        {
            Logger.Log("Starting dungeon generation");
            Dungeon dungeon = new Dungeon();
            dungeon.Start();

            // print the dungeon into the console
            BoardSquare[,] map = dungeon.Board;
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    if (map[x, y] == BoardSquare.Floor)
                    {
                        Console.Write(" ");
                        continue;
                    }

                    if (map[x, y] == BoardSquare.WallTop)
                    {
                        Console.Write("─");
                        continue;
                    }

                    if (map[x, y] == BoardSquare.WallDown)
                    {
                        Console.Write("─");
                        continue;
                    }

                    if (map[x, y] == BoardSquare.WallLeft)
                    {
                        Console.Write("│");
                        continue;
                    }

                    if (map[x, y] == BoardSquare.WallRight)
                    {
                        Console.Write("│");
                        continue;
                    }

                    if (map[x, y] == BoardSquare.CornerLeftUp)
                    {
                        Console.Write("└");
                        continue;
                    }

                    if (map[x, y] == BoardSquare.CornerRightUp)
                    {
                        Console.Write("┘");
                        continue;
                    }

                    if (map[x, y] == BoardSquare.CornerLeftDown)
                    {
                        Console.Write("┌");
                        continue;
                    }

                    if (map[x, y] == BoardSquare.CornerRightDown)
                    {
                        Console.Write("┐");
                        continue;
                    }

                    if (map[x, y] == BoardSquare.CornerInternalLeftDown)
                    {
                        Console.Write("┘");
                        continue;
                    }

                    if (map[x, y] == BoardSquare.CornerInternalLeftUp)
                    {
                        Console.Write("┐");
                        continue;
                    }

                    if (map[x, y] == BoardSquare.CornerInternalRightDown)
                    {
                        Console.Write("└");
                        continue;
                    }

                    if (map[x, y] == BoardSquare.CornerInternalRightUp)
                    {
                        Console.Write("┌");
                        continue;
                    }

                    Console.Write("█");
                }

                Logger.Info();
            }

            Logger.Log("Dungeon generated");
        }
    }
}