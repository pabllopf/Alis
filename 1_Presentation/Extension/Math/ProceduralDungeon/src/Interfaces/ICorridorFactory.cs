// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ICorridorFactory.cs
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

