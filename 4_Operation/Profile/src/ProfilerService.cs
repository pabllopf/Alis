// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ProfilerService.cs
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

using System.Diagnostics;

namespace Alis.Core.Profile
{
    /// <summary>
    ///     The profiler service class
    /// </summary>
    public class ProfilerService
    {
        /// <summary>
        ///     The profile data
        /// </summary>
        private readonly ProfileData profileData;
        
        /// <summary>
        ///     The profiler
        /// </summary>
        private readonly Profiler profiler;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="ProfilerService" /> class
        /// </summary>
        public ProfilerService()
        {
            profiler = new Profiler();
            profileData = new ProfileData();
        }
        
        /// <summary>
        ///     Starts the profiling
        /// </summary>
        public void StartProfiling()
        {
            profiler.StartProfiling();
            // Start monitoring resources
            profileData.CpuUsage = GetCpuUsage();
            profileData.MemoryUsage = GetMemoryUsage();
        }
        
        /// <summary>
        ///     Stops the profiling
        /// </summary>
        /// <returns>The profile data</returns>
        public ProfileData StopProfiling()
        {
            profiler.StopProfiling();
            // Stop monitoring resources and store the data in profileData
            profileData.CpuUsage = GetCpuUsage();
            profileData.MemoryUsage = GetMemoryUsage();
            return profileData;
        }
        
        /// <summary>
        ///     Gets the cpu usage
        /// </summary>
        /// <returns>The cpu usage</returns>
        private double GetCpuUsage()
        {
            double cpuUsage = Process.GetCurrentProcess().TotalProcessorTime.TotalMilliseconds;
            // This is a placeholder, replace with actual code
            return cpuUsage;
        }
        
        /// <summary>
        ///     Gets the memory usage
        /// </summary>
        /// <returns>The memory usage</returns>
        private long GetMemoryUsage()
        {
            long memoryUsage = Process.GetCurrentProcess().WorkingSet64;
            // This is a placeholder, replace with actual code
            return memoryUsage;
        }
    }
}