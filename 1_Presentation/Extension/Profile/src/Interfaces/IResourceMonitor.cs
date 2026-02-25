// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IResourceMonitor.cs
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

namespace Alis.Extension.Profile.Interfaces
{
    /// <summary>
    ///     Defines the contract for monitoring system resources such as CPU and memory usage.
    ///     Implementations of this interface provide platform-specific or custom strategies
    ///     for measuring resource consumption during profiling operations.
    /// </summary>
    public interface IResourceMonitor
    {
        /// <summary>
        ///     Measures the current CPU usage of the process.
        /// </summary>
        /// <returns>
        ///     A <see cref="double" /> representing the CPU usage as a percentage (0-100)
        ///     or in milliseconds depending on the implementation strategy.
        /// </returns>
        double GetCpuUsage();

        /// <summary>
        ///     Measures the current memory usage of the process.
        /// </summary>
        /// <returns>
        ///     A <see cref="long" /> representing the memory usage in bytes.
        /// </returns>
        long GetMemoryUsage();

        /// <summary>
        ///     Gets the total number of garbage collections that have occurred
        ///     for all generations since the process started.
        /// </summary>
        /// <returns>
        ///     An <see cref="int" /> representing the total garbage collection count.
        /// </returns>
        int GetGarbageCollectionCount();

        /// <summary>
        ///     Gets the total number of threads currently active in the process.
        /// </summary>
        /// <returns>
        ///     An <see cref="int" /> representing the thread count.
        /// </returns>
        int GetThreadCount();
    }
}

