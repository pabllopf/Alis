// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Profiler.cs
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

namespace Alis.Extension.Profile
{
    /// <summary>
    ///     The profiler class
    /// </summary>
    public class Profiler
    {
        /// <summary>
        ///     The elapsed time
        /// </summary>
        private TimeSpan elapsedTime;
        
        /// <summary>
        ///     The start time
        /// </summary>
        private DateTime startTime;
        
        /// <summary>
        ///     Starts the profiling
        /// </summary>
        public void StartProfiling()
        {
            startTime = DateTime.Now;
        }
        
        /// <summary>
        ///     Stops the profiling
        /// </summary>
        public void StopProfiling()
        {
            elapsedTime = DateTime.Now - startTime;
        }
        
        /// <summary>
        ///     Gets the elapsed time
        /// </summary>
        /// <returns>The elapsed time</returns>
        public TimeSpan GetElapsedTime() => elapsedTime;
    }
}