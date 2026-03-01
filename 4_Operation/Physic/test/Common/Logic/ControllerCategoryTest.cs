// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ControllerCategoryTest.cs
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

using Alis.Core.Physic.Common.Logic;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Logic
{
    /// <summary>
    ///     The controller category test class
    /// </summary>
    public class ControllerCategoryTest
    {
        /// <summary>
        ///     Tests that none should have value zero
        /// </summary>
        [Fact]
        public void None_ShouldHaveValueZero()
        {
            Assert.Equal(0x00000000, (int)ControllerCategory.None);
        }

        /// <summary>
        ///     Tests that cat01 should have correct value
        /// </summary>
        [Fact]
        public void Cat01_ShouldHaveCorrectValue()
        {
            Assert.Equal(0x00000001, (int)ControllerCategory.Cat01);
        }

        /// <summary>
        ///     Tests that cat02 should have correct value
        /// </summary>
        [Fact]
        public void Cat02_ShouldHaveCorrectValue()
        {
            Assert.Equal(0x00000002, (int)ControllerCategory.Cat02);
        }

        /// <summary>
        ///     Tests that cat03 should have correct value
        /// </summary>
        [Fact]
        public void Cat03_ShouldHaveCorrectValue()
        {
            Assert.Equal(0x00000004, (int)ControllerCategory.Cat03);
        }

        /// <summary>
        ///     Tests that cat04 should have correct value
        /// </summary>
        [Fact]
        public void Cat04_ShouldHaveCorrectValue()
        {
            Assert.Equal(0x00000008, (int)ControllerCategory.Cat04);
        }

        /// <summary>
        ///     Tests that flags can be combined with bitwise or
        /// </summary>
        [Fact]
        public void Flags_CanBeCombined_WithBitwiseOr()
        {
            ControllerCategory combined = ControllerCategory.Cat01 | ControllerCategory.Cat02;
            
            Assert.Equal(0x00000003, (int)combined);
        }

        /// <summary>
        ///     Tests that flags can be checked with bitwise and
        /// </summary>
        [Fact]
        public void Flags_CanBeChecked_WithBitwiseAnd()
        {
            ControllerCategory combined = ControllerCategory.Cat01 | ControllerCategory.Cat02;
            
            Assert.True((combined & ControllerCategory.Cat01) == ControllerCategory.Cat01);
            Assert.True((combined & ControllerCategory.Cat02) == ControllerCategory.Cat02);
        }
        

        /// <summary>
        ///     Tests that categories should be powers of two
        /// </summary>
        [Fact]
        public void Categories_ShouldBePowersOfTwo()
        {
            Assert.Equal(1, (int)ControllerCategory.Cat01);
            Assert.Equal(2, (int)ControllerCategory.Cat02);
            Assert.Equal(4, (int)ControllerCategory.Cat03);
            Assert.Equal(8, (int)ControllerCategory.Cat04);
            Assert.Equal(16, (int)ControllerCategory.Cat05);
        }

        /// <summary>
        ///     Tests that none combined with any category equals that category
        /// </summary>
        [Fact]
        public void None_CombinedWithAnyCategory_EqualsThatCategory()
        {
            ControllerCategory combined = ControllerCategory.None | ControllerCategory.Cat01;
            
            Assert.Equal(ControllerCategory.Cat01, combined);
        }
    }
}

