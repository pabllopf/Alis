// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Clock.cs
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
using System.Diagnostics;

namespace Alis.Core.Aspect.Time
{
    /// <summary>
    ///     The clock class
    /// </summary>
    public class Clock
    {
        /// <summary>
        ///     The stopwatch
        /// </summary>
        private readonly Stopwatch stopwatch = new Stopwatch();

        /// <summary>
        ///     Gets the value of the elapsed
        /// </summary>
        public TimeSpan Elapsed => stopwatch.Elapsed;

        /// <summary>
        ///     Gets the value of the elapsed milliseconds
        /// </summary>
        public long ElapsedMilliseconds => stopwatch.ElapsedMilliseconds;

        /// <summary>
        ///     Gets the value of the elapsed ticks
        /// </summary>
        public long ElapsedTicks => stopwatch.ElapsedTicks;

        /// <summary>
        ///     Gets the value of the elapsed seconds
        /// </summary>
        public double ElapsedSeconds => stopwatch.Elapsed.TotalSeconds;

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public void Start() => stopwatch.Start();

        /// <summary>
        ///     Stops this instance
        /// </summary>
        public void Stop() => stopwatch.Stop();

        /// <summary>
        ///     Resets this instance
        /// </summary>
        public void Reset() => stopwatch.Reset();
    }
}