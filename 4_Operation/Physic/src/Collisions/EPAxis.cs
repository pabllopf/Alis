// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EPAxis.cs
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
    ///     Stores the best separating axis found during edge-polygon collision detection.
    /// </summary>
    public struct EpAxis
    {
        /// <summary>
        ///     The index of the edge or vertex on the reference shape giving the maximum separation.
        /// </summary>
        public int Index;

        /// <summary>
        ///     The separation distance along this axis. Negative values indicate penetration.
        /// </summary>
        public float Separation;

        /// <summary>
        ///     Identifies which shape (edge A or edge B) the axis belongs to, or Unknown if not yet computed.
        /// </summary>
        public EpAxisType Type;
    }
}