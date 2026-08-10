// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CategoriesRemainingCoverageTests.cs
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

using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The categories remaining coverage tests class
    /// </summary>
    public class CategoriesRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that none has value zero
        /// </summary>
        [Fact]
        public void None_HasValueZero()
        {
            Assert.Equal(0, (int) Categories.None);
        }

        /// <summary>
        ///     Tests that cat values are powers of two
        /// </summary>
        [Fact]
        public void CatValues_ArePowersOfTwo()
        {
            Assert.Equal(1, (int) Categories.Cat1);
            Assert.Equal(2, (int) Categories.Cat2);
            Assert.Equal(4, (int) Categories.Cat3);
            Assert.Equal(8, (int) Categories.Cat4);
            Assert.Equal(16, (int) Categories.Cat5);
            Assert.Equal(32, (int) Categories.Cat6);
            Assert.Equal(64, (int) Categories.Cat7);
            Assert.Equal(128, (int) Categories.Cat8);
            Assert.Equal(256, (int) Categories.Cat9);
            Assert.Equal(512, (int) Categories.Cat10);
            Assert.Equal(1024, (int) Categories.Cat11);
            Assert.Equal(2048, (int) Categories.Cat12);
            Assert.Equal(4096, (int) Categories.Cat13);
            Assert.Equal(8192, (int) Categories.Cat14);
            Assert.Equal(16384, (int) Categories.Cat15);
            Assert.Equal(32768, (int) Categories.Cat16);
            Assert.Equal(65536, (int) Categories.Cat17);
            Assert.Equal(131072, (int) Categories.Cat18);
            Assert.Equal(262144, (int) Categories.Cat19);
            Assert.Equal(524288, (int) Categories.Cat20);
            Assert.Equal(1048576, (int) Categories.Cat21);
            Assert.Equal(2097152, (int) Categories.Cat22);
            Assert.Equal(4194304, (int) Categories.Cat23);
            Assert.Equal(8388608, (int) Categories.Cat24);
            Assert.Equal(16777216, (int) Categories.Cat25);
            Assert.Equal(33554432, (int) Categories.Cat26);
            Assert.Equal(67108864, (int) Categories.Cat27);
            Assert.Equal(134217728, (int) Categories.Cat28);
            Assert.Equal(268435456, (int) Categories.Cat29);
            Assert.Equal(536870912, (int) Categories.Cat30);
            Assert.Equal(1073741824, (int) Categories.Cat31);
        }

        /// <summary>
        ///     Tests that all has max int value
        /// </summary>
        [Fact]
        public void All_HasMaxIntValue()
        {
            Assert.Equal(int.MaxValue, (int) Categories.All);
        }

        /// <summary>
        ///     Tests that flags combine correctly
        /// </summary>
        [Fact]
        public void Flags_CombineCorrectly()
        {
            Categories combined = Categories.Cat1 | Categories.Cat2 | Categories.Cat3;

            Assert.True((combined & Categories.Cat1) != 0);
            Assert.True((combined & Categories.Cat2) != 0);
            Assert.True((combined & Categories.Cat3) != 0);
            Assert.False((combined & Categories.Cat4) != 0);
        }
    }
}
