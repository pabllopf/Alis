// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TOIOutputState.cs
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
    ///     Indicates the result status of a continuous collision time-of-impact computation.
    /// </summary>
    public enum ToiOutputState
    {
        /// <summary>
        ///     The time-of-impact has not been computed yet.
        /// </summary>
        Unknown,

        /// <summary>
        ///     The root-finding algorithm failed to converge within the iteration limit.
        /// </summary>
        Failed,

        /// <summary>
        ///     The shapes are already overlapping at the initial time.
        /// </summary>
        Overlapped,

        /// <summary>
        ///     The shapes are touching (separated within tolerance) at the computed time.
        /// </summary>
        Touching,

        /// <summary>
        ///     The shapes remain separated throughout the entire sweep interval.
        /// </summary>
        Seperated
    }
}