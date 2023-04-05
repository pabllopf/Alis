// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TimeStep.cs
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

namespace Alis.Core.Aspect.Time
{
    /// <summary>This is an internal class.</summary>
    public class TimeStep
    {
        /// <summary>Time step (Delta time)</summary>
        public float DeltaTime;

        /// <summary>dt * inv_dt0</summary>
        public float DeltaTimeRatio;

        /// <summary>Inverse time step (0 if dt == 0).</summary>
        public float InvertedDeltaTime;
        
        /// <summary>
        /// The inverted delta time
        /// </summary>
        public float InvertedDeltaTimeZero;

        /// <summary>
        ///     The position iterations
        /// </summary>
        public int PositionIterations;

        /// <summary>
        ///     The velocity iterations
        /// </summary>
        public int VelocityIterations;

        /// <summary>
        ///     The warm starting
        /// </summary>
        public bool WarmStarting;
    }
}