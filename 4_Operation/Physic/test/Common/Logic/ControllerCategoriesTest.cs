// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ControllerCategoriesTest.cs
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
using Alis.Core.Physic.Common.Logic;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Logic
{
    /// <summary>
    ///     The controller categories test class
    /// </summary>
    public class ControllerCategoriesTest
    {
        /// <summary>
        /// Tests that none value should be zero
        /// </summary>
        [Fact]
        public void NoneValue_ShouldBeZero()
        {
            Assert.Equal(0x00000000, (int)ControllerCategories.None);
        }

        /// <summary>
        /// Tests that cat 01 value should be 0x 00000001
        /// </summary>
        [Fact]
        public void Cat01Value_ShouldBe0x00000001()
        {
            Assert.Equal(0x00000001, (int)ControllerCategories.Cat01);
        }

        /// <summary>
        /// Tests that cat 02 value should be 0x 00000002
        /// </summary>
        [Fact]
        public void Cat02Value_ShouldBe0x00000002()
        {
            Assert.Equal(0x00000002, (int)ControllerCategories.Cat02);
        }

        /// <summary>
        /// Tests that cat 31 value should be 0x 40000000
        /// </summary>
        [Fact]
        public void Cat31Value_ShouldBe0x40000000()
        {
            Assert.Equal(0x40000000, (int)ControllerCategories.Cat31);
        }

        /// <summary>
        /// Tests that all value should be int max value
        /// </summary>
        [Fact]
        public void AllValue_ShouldBeIntMaxValue()
        {
            Assert.Equal(int.MaxValue, (int)ControllerCategories.All);
        }

        /// <summary>
        /// Tests that controller categories should support bitwise or
        /// </summary>
        [Fact]
        public void ControllerCategories_ShouldSupportBitwiseOr()
        {
            ControllerCategories combined = ControllerCategories.Cat01 | ControllerCategories.Cat02;

            Assert.Equal(0x00000003, (int)combined);
        }

        /// <summary>
        /// Tests that controller categories should support bitwise and
        /// </summary>
        [Fact]
        public void ControllerCategories_ShouldSupportBitwiseAnd()
        {
            ControllerCategories combined = ControllerCategories.Cat01 | ControllerCategories.Cat02 | ControllerCategories.Cat03;
            ControllerCategories result = combined & ControllerCategories.Cat01;

            Assert.Equal(ControllerCategories.Cat01, result);
        }

        /// <summary>
        /// Tests that controller categories should support bitwise xor
        /// </summary>
        [Fact]
        public void ControllerCategories_ShouldSupportBitwiseXor()
        {
            ControllerCategories combined = ControllerCategories.Cat01 | ControllerCategories.Cat02;
            ControllerCategories result = combined ^ ControllerCategories.Cat01;

            Assert.Equal(ControllerCategories.Cat02, result);
        }

        /// <summary>
        /// Tests that controller categories should support bitwise negation
        /// </summary>
        [Fact]
        public void ControllerCategories_ShouldSupportBitwiseNegation()
        {
            ControllerCategories cat = ControllerCategories.Cat01;
            ControllerCategories inverted = ~cat;

            Assert.False(inverted.HasFlag(ControllerCategories.Cat01));
        }

        /// <summary>
        /// Tests that controller categories should support has flag
        /// </summary>
        [Fact]
        public void ControllerCategories_ShouldSupportHasFlag()
        {
            ControllerCategories multi = ControllerCategories.Cat01 | ControllerCategories.Cat02 | ControllerCategories.Cat03;

            Assert.True(multi.HasFlag(ControllerCategories.Cat01));
            Assert.True(multi.HasFlag(ControllerCategories.Cat02));
            Assert.True(multi.HasFlag(ControllerCategories.Cat03));
            Assert.False(multi.HasFlag(ControllerCategories.Cat04));
        }

        /// <summary>
        /// Tests that all category should contain all categories
        /// </summary>
        [Fact]
        public void AllCategory_ShouldContainAllCategories()
        {
            Assert.True(ControllerCategories.All.HasFlag(ControllerCategories.Cat01));
            Assert.True(ControllerCategories.All.HasFlag(ControllerCategories.Cat15));
            Assert.True(ControllerCategories.All.HasFlag(ControllerCategories.Cat31));
        }

        /// <summary>
        /// Tests that controller categories should be flags enum
        /// </summary>
        [Fact]
        public void ControllerCategories_ShouldBeFlagsEnum()
        {
            object[] attributes = typeof(ControllerCategories).GetCustomAttributes(typeof(FlagsAttribute), false);

            Assert.NotEmpty(attributes);
        }

        /// <summary>
        /// Tests that controller categories should support multiple flags
        /// </summary>
        [Fact]
        public void ControllerCategories_ShouldSupportMultipleFlags()
        {
            ControllerCategories multi = ControllerCategories.Cat01 | ControllerCategories.Cat05 | ControllerCategories.Cat10 | ControllerCategories.Cat20;

            Assert.True((multi & ControllerCategories.Cat01) != 0);
            Assert.True((multi & ControllerCategories.Cat05) != 0);
            Assert.True((multi & ControllerCategories.Cat10) != 0);
            Assert.True((multi & ControllerCategories.Cat20) != 0);
            Assert.False((multi & ControllerCategories.Cat02) != 0);
        }

        /// <summary>
        /// Tests that controller categories should support equality check
        /// </summary>
        [Fact]
        public void ControllerCategories_ShouldSupportEqualityCheck()
        {
            ControllerCategories cat1 = ControllerCategories.Cat01;
            ControllerCategories cat2 = ControllerCategories.Cat01;

            Assert.Equal(cat1, cat2);
            Assert.True(cat1 == cat2);
        }

        /// <summary>
        /// Tests that controller categories should support inequality check
        /// </summary>
        [Fact]
        public void ControllerCategories_ShouldSupportInequalityCheck()
        {
            ControllerCategories cat1 = ControllerCategories.Cat01;
            ControllerCategories cat2 = ControllerCategories.Cat02;

            Assert.NotEqual(cat1, cat2);
            Assert.True(cat1 != cat2);
        }

        /// <summary>
        /// Tests that controller categories should convert to int
        /// </summary>
        [Fact]
        public void ControllerCategories_ShouldConvertToInt()
        {
            ControllerCategories cat = ControllerCategories.Cat05;
            int value = (int)cat;

            Assert.Equal(0x00000010, value);
        }

        /// <summary>
        /// Tests that controller categories should convert from int
        /// </summary>
        [Fact]
        public void ControllerCategories_ShouldConvertFromInt()
        {
            ControllerCategories cat = (ControllerCategories)0x00000008;

            Assert.Equal(ControllerCategories.Cat04, cat);
        }

        /// <summary>
        /// Tests that controller categories should have all 31 categories
        /// </summary>
        [Fact]
        public void ControllerCategories_ShouldHaveAll31Categories()
        {
            for (int i = 1; i <= 31; i++)
            {
                ControllerCategories cat = (ControllerCategories)(1 << (i - 1));
                Assert.NotEqual(ControllerCategories.None, cat);
            }
        }

        /// <summary>
        /// Tests that controller categories should support complex combination
        /// </summary>
        [Fact]
        public void ControllerCategories_ShouldSupportComplexCombination()
        {
            ControllerCategories complex = ControllerCategories.Cat01 | ControllerCategories.Cat03 | ControllerCategories.Cat05 |
                                           ControllerCategories.Cat07 | ControllerCategories.Cat09 | ControllerCategories.Cat11;

            Assert.True(complex.HasFlag(ControllerCategories.Cat01));
            Assert.True(complex.HasFlag(ControllerCategories.Cat03));
            Assert.True(complex.HasFlag(ControllerCategories.Cat05));
            Assert.True(complex.HasFlag(ControllerCategories.Cat07));
            Assert.True(complex.HasFlag(ControllerCategories.Cat09));
            Assert.True(complex.HasFlag(ControllerCategories.Cat11));
        }

        /// <summary>
        /// Tests that controller categories should support remove flag
        /// </summary>
        [Fact]
        public void ControllerCategories_ShouldSupportRemoveFlag()
        {
            ControllerCategories multi = ControllerCategories.Cat01 | ControllerCategories.Cat02 | ControllerCategories.Cat03;
            ControllerCategories withoutCat02 = multi & ~ControllerCategories.Cat02;

            Assert.False(withoutCat02.HasFlag(ControllerCategories.Cat02));
            Assert.True(withoutCat02.HasFlag(ControllerCategories.Cat01));
            Assert.True(withoutCat02.HasFlag(ControllerCategories.Cat03));
        }
    }
}
