// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ProfilerServiceTest.cs
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

using Xunit;

namespace Alis.Extension.Profile.Test
{
    /// <summary>
    ///     The profiler service test class
    /// </summary>
    public class ProfilerServiceTest
    {
        /// <summary>
        ///     Tests that start profiling initializes cpu and memory usage
        /// </summary>
        [Fact]
        public void StartProfiling_InitializesCpuAndMemoryUsage()
        {
            ProfilerService profilerService = new ProfilerService();
            profilerService.StartProfiling();
            Assert.True(profilerService.GetProfileData().CpuUsage > 0);
            Assert.True(profilerService.GetProfileData().MemoryUsage > 0);
        }

        /// <summary>
        ///     Tests that stop profiling returns profile data with cpu and memory usage
        /// </summary>
        [Fact]
        public void StopProfiling_ReturnsProfileDataWithCpuAndMemoryUsage()
        {
            ProfilerService profilerService = new ProfilerService();
            profilerService.StartProfiling();
            ProfileData profileData = profilerService.StopProfiling();
            Assert.NotNull(profileData);
            Assert.True(profileData.CpuUsage > 0);
            Assert.True(profileData.MemoryUsage > 0);
        }

        /// <summary>
        ///     Tests that get cpu usage returns positive value
        /// </summary>
        [Fact]
        public void GetCpuUsage_ReturnsPositiveValue()
        {
            ProfilerService profilerService = new ProfilerService();
            profilerService.StartProfiling();
            double cpuUsage = profilerService.GetCpuUsage();
            Assert.True(cpuUsage > 0);
        }

        /// <summary>
        ///     Tests that get memory usage returns positive value
        /// </summary>
        [Fact]
        public void GetMemoryUsage_ReturnsPositiveValue()
        {
            ProfilerService profilerService = new ProfilerService();
            profilerService.StartProfiling();
            long memoryUsage = profilerService.GetMemoryUsage();
            Assert.True(memoryUsage > 0);
        }
    }
}