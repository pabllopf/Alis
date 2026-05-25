// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CategoryTest.cs
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
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The category test class
    /// </summary>
    public class CategoryTest
    {
        /// <summary>
        ///     Tests that none enum value should be zero
        /// </summary>
        [Fact]
        public void NoneEnumValue_ShouldBeZero()
        {
            Categories category = Categories.None;

            Assert.Equal(Categories.None, category);
            Assert.Equal(0x00000000, (int) category);
        }

        /// <summary>
        ///     Tests that cat1 enum value should be defined
        /// </summary>
        [Fact]
        public void Cat1EnumValue_ShouldBeDefined()
        {
            Categories category = Categories.Cat1;

            Assert.Equal(0x00000001, (int) category);
        }

        /// <summary>
        ///     Tests that cat2 enum value should be defined
        /// </summary>
        [Fact]
        public void Cat2EnumValue_ShouldBeDefined()
        {
            Categories category = Categories.Cat2;

            Assert.Equal(0x00000002, (int) category);
        }

        /// <summary>
        ///     Tests that cat31 enum value should be defined
        /// </summary>
        [Fact]
        public void Cat31EnumValue_ShouldBeDefined()
        {
            Categories category = Categories.Cat31;

            Assert.Equal(Categories.Cat31, category);
        }

        /// <summary>
        ///     Tests that all enum value should be max value
        /// </summary>
        [Fact]
        public void AllEnumValue_ShouldBeMaxValue()
        {
            Categories category = Categories.All;

            Assert.Equal(Categories.All, category);
            Assert.Equal(int.MaxValue, (int) category);
        }

        /// <summary>
        ///     Tests that category should support bitwise or operation
        /// </summary>
        [Fact]
        public void Category_ShouldSupportBitwiseOrOperation()
        {
            Categories combined = Categories.Cat1 | Categories.Cat2;

            Assert.Equal(0x00000003, (int) combined);
        }

        /// <summary>
        ///     Tests that category should support bitwise and operation
        /// </summary>
        [Fact]
        public void Category_ShouldSupportBitwiseAndOperation()
        {
            Categories combined = Categories.Cat1 | Categories.Cat2;
            Categories result = combined & Categories.Cat1;

            Assert.Equal(Categories.Cat1, result);
        }

        /// <summary>
        ///     Tests that category should support bitwise xor operation
        /// </summary>
        [Fact]
        public void Category_ShouldSupportBitwiseXorOperation()
        {
            Categories combined = Categories.Cat1 | Categories.Cat2;
            Categories result = combined ^ Categories.Cat1;

            Assert.Equal(Categories.Cat2, result);
        }

        /// <summary>
        ///     Tests that category should support multiple flags
        /// </summary>
        [Fact]
        public void Category_ShouldSupportMultipleFlags()
        {
            Categories multi = Categories.Cat1 | Categories.Cat5 | Categories.Cat10;

            Assert.True((multi & Categories.Cat1) != 0);
            Assert.True((multi & Categories.Cat5) != 0);
            Assert.True((multi & Categories.Cat10) != 0);
            Assert.False((multi & Categories.Cat2) != 0);
        }

        /// <summary>
        ///     Tests that category should support has flag check
        /// </summary>
        [Fact]
        public void Category_ShouldSupportHasFlagCheck()
        {
            Categories multi = Categories.Cat1 | Categories.Cat2;

            Assert.True(multi.HasFlag(Categories.Cat1));
            Assert.True(multi.HasFlag(Categories.Cat2));
            Assert.False(multi.HasFlag(Categories.Cat3));
        }

        /// <summary>
        ///     Tests that all category should contain all other categories
        /// </summary>
        [Fact]
        public void AllCategory_ShouldContainAllOtherCategories()
        {
            Categories all = Categories.All;

            Assert.True(all.HasFlag(Categories.Cat1));
            Assert.True(all.HasFlag(Categories.Cat15));
            Assert.True(all.HasFlag(Categories.Cat31));
        }

        /// <summary>
        ///     Tests that category should be flags enum
        /// </summary>
        [Fact]
        public void Category_ShouldBeFlagsEnum()
        {
            object[] attributes = typeof(Categories).GetCustomAttributes(typeof(FlagsAttribute), false);

            Assert.NotEmpty(attributes);
        }

        /// <summary>
        ///     Tests that category should support bitwise negation
        /// </summary>
        [Fact]
        public void Category_ShouldSupportBitwiseNegation()
        {
            Categories cat = Categories.Cat1;
            Categories inverted = ~cat;

            Assert.False(inverted.HasFlag(Categories.Cat1));
        }
    }
}