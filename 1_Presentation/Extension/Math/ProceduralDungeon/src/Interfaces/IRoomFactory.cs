// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IRoomFactory.cs
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

