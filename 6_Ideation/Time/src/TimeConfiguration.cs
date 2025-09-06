// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TimeConfiguration.cs
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

using System.Runtime.InteropServices;

namespace Alis.Core.Aspect.Time
{
    /// <summary>
    ///     The time class
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TimeConfiguration(
        float fixedTimeStep,
        float maximumAllowedTimeStep,
        float timeScale)
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TimeConfiguration" /> class
        /// </summary>
        public TimeConfiguration() : this(0.016f, 0.25f, 1.0f)
        {
        }

        /// <summary>
        ///     Gets the value of the fixed time step
        /// </summary>
        public readonly float FixedTimeStep = fixedTimeStep;

        /// <summary>
        ///     Gets the value of the maximum allowed time step
        /// </summary>
        public readonly float MaximumAllowedTimeStep = maximumAllowedTimeStep;

        /// <summary>
        ///     Gets the value of the time scale
        /// </summary>
        public readonly float TimeScale = timeScale;
    }
}