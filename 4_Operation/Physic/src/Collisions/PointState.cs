// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PointState.cs
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

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Indicates the state of a contact point across simulation updates.
    /// </summary>
    /// <remarks>
    ///     Used by the collision detection system to track contact point lifecycle:
    ///     which points are new, which persist, and which have been removed between frames.
    /// </remarks>
    public enum PointState
    {
        /// <summary>
        ///     The contact point does not exist (null/invalid).
        /// </summary>
        Null,

        /// <summary>
        ///     The contact point was newly added in this update.
        /// </summary>
        Add,

        /// <summary>
        ///     The contact point persisted from the previous update.
        /// </summary>
        Persist,

        /// <summary>
        ///     The contact point was removed in this update.
        /// </summary>
        Remove
    }
}