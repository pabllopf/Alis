// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PlatformInfoTest.cs
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
using Alis.Core.Aspect.Base.Dll;
using Alis.Core.Aspect.Math.Util;
using Xunit;

namespace Alis.Core.Aspect.Base.Test.Dll
{
    /// <summary>
    ///     The platform info test class
    /// </summary>
    public class PlatformInfoTest
    {
        /// <summary>
        ///     Tests that test platform info constructor
        /// </summary>
        [Fact]
        public void TestPlatformInfo_Constructor()
        {
            OSPlatform platform = OSPlatform.Windows;
            Architecture arch = Architecture.X64;

            PlatformInfo platformInfo = new PlatformInfo(platform, arch);

            Assert.Equal(platform, platformInfo.Platform);
            Assert.Equal(arch, platformInfo.Arch);
        }

        /// <summary>
        ///     Tests that test platform info equals
        /// </summary>
        [Fact]
        public void TestPlatformInfo_Equals()
        {
            OSPlatform platform = OSPlatform.Windows;
            Architecture arch = Architecture.X64;

            PlatformInfo platformInfo1 = new PlatformInfo(platform, arch);
            PlatformInfo platformInfo2 = new PlatformInfo(platform, arch);

            Assert.True(platformInfo1.Equals(platformInfo2));
        }

        /// <summary>
        ///     Tests that test platform info not equals
        /// </summary>
        [Fact]
        public void TestPlatformInfo_NotEquals()
        {
            OSPlatform platform1 = OSPlatform.Windows;
            Architecture arch1 = Architecture.X64;

            OSPlatform platform2 = OSPlatform.Linux;
            Architecture arch2 = Architecture.X86;

            PlatformInfo platformInfo1 = new PlatformInfo(platform1, arch1);
            PlatformInfo platformInfo2 = new PlatformInfo(platform2, arch2);

            Assert.False(platformInfo1.Equals(platformInfo2));
        }

        /// <summary>
        ///     Tests that test platform info get hash code
        /// </summary>
        [Fact]
        public void TestPlatformInfo_GetHashCode()
        {
            OSPlatform platform = OSPlatform.Windows;
            Architecture arch = Architecture.X64;

            PlatformInfo platformInfo = new PlatformInfo(platform, arch);
            int expectedHashCode = HashCode.Combine(platform, arch);

            Assert.Equal(expectedHashCode, platformInfo.GetHashCode());
        }

        /// <summary>
        ///     Tests that test equals with equal platform info
        /// </summary>
        [Fact]
        public void TestEquals_WithEqualPlatformInfo()
        {
            OSPlatform platform = OSPlatform.Windows;
            Architecture arch = Architecture.X64;

            PlatformInfo platformInfo1 = new PlatformInfo(platform, arch);
            PlatformInfo platformInfo2 = new PlatformInfo(platform, arch);

            Assert.True(platformInfo1.Equals(platformInfo2));
        }

        /// <summary>
        ///     Tests that test equals with different platform info
        /// </summary>
        [Fact]
        public void TestEquals_WithDifferentPlatformInfo()
        {
            OSPlatform platform1 = OSPlatform.Windows;
            Architecture arch1 = Architecture.X64;

            OSPlatform platform2 = OSPlatform.Linux;
            Architecture arch2 = Architecture.X86;

            PlatformInfo platformInfo1 = new PlatformInfo(platform1, arch1);
            PlatformInfo platformInfo2 = new PlatformInfo(platform2, arch2);

            Assert.False(platformInfo1.Equals(platformInfo2));
        }

        /// <summary>
        ///     Tests that test equals with non platform info object
        /// </summary>
        [Fact]
        public void TestEquals_WithNonPlatformInfoObject()
        {
            OSPlatform platform = OSPlatform.Windows;
            Architecture arch = Architecture.X64;

            PlatformInfo platformInfo = new PlatformInfo(platform, arch);
            object nonPlatformInfoObject = new object();

            Assert.False(platformInfo.Equals(nonPlatformInfoObject));
        }
    }
}