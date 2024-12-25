// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ProfileDataTest.cs
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

using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Alis.Extension.Profile.Test
{
    /// <summary>
    ///     The profile data test class
    /// </summary>
    	  
	 public class ProfileDataTest 
    {
        /// <summary>
        ///     Tests that memory usage set and get returns correct value
        /// </summary>
        [Fact]
        public void MemoryUsage_SetAndGet_ReturnsCorrectValue()
        {
            ProfileData profileData = new ProfileData();
            long expectedMemoryUsage = 1024;

            profileData.MemoryUsage = expectedMemoryUsage;

            Assert.Equal(expectedMemoryUsage, profileData.MemoryUsage);
        }

        /// <summary>
        ///     Tests that cpu usage set and get returns correct value
        /// </summary>
        [Fact]
        public void CpuUsage_SetAndGet_ReturnsCorrectValue()
        {
            ProfileData profileData = new ProfileData();
            double expectedCpuUsage = 3.14;

            profileData.CpuUsage = expectedCpuUsage;

            Assert.Equal(expectedCpuUsage, profileData.CpuUsage);
        }
    }
}