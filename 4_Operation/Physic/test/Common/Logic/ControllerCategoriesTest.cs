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

        /// <summary>
        ///     Tests that Cat06 enum value is correctly defined as 0x00000020.
        /// </summary>
        [Fact]
        public void Cat06Value_ShouldBe0x00000020()
        {
            Assert.Equal(0x00000020, (int)ControllerCategories.Cat06);
        }

        /// <summary>
        ///     Tests that Cat08 enum value is correctly defined as 0x00000080.
        /// </summary>
        [Fact]
        public void Cat08Value_ShouldBe0x00000080()
        {
            Assert.Equal(0x00000080, (int)ControllerCategories.Cat08);
        }

        /// <summary>
        ///     Tests that Cat30 enum value is correctly defined as 0x20000000.
        /// </summary>
        [Fact]
        public void Cat30Value_ShouldBe0x20000000()
        {
            Assert.Equal(0x20000000, (int)ControllerCategories.Cat30);
        }

        /// <summary>
        ///     Tests that Cat03 enum value is correctly defined as 0x00000004.
        /// </summary>
        [Fact]
        public void Cat03Value_ShouldBe0x00000004()
        {
            Assert.Equal(0x00000004, (int)ControllerCategories.Cat03);
        }

        /// <summary>
        ///     Tests that Cat04 enum value is correctly defined as 0x00000008.
        /// </summary>
        [Fact]
        public void Cat04Value_ShouldBe0x00000008()
        {
            Assert.Equal(0x00000008, (int)ControllerCategories.Cat04);
        }

        /// <summary>
        ///     Tests that Cat05 enum value is correctly defined as 0x00000010.
        /// </summary>
        [Fact]
        public void Cat05Value_ShouldBe0x00000010()
        {
            Assert.Equal(0x00000010, (int)ControllerCategories.Cat05);
        }

        /// <summary>
        ///     Tests that Cat07 enum value is correctly defined as 0x00000040.
        /// </summary>
        [Fact]
        public void Cat07Value_ShouldBe0x00000040()
        {
            Assert.Equal(0x00000040, (int)ControllerCategories.Cat07);
        }

        /// <summary>
        ///     Tests that Cat09 enum value is correctly defined as 0x00000100.
        /// </summary>
        [Fact]
        public void Cat09Value_ShouldBe0x00000100()
        {
            Assert.Equal(0x00000100, (int)ControllerCategories.Cat09);
        }

        /// <summary>
        ///     Tests that Cat10 enum value is correctly defined as 0x00000200.
        /// </summary>
        [Fact]
        public void Cat10Value_ShouldBe0x00000200()
        {
            Assert.Equal(0x00000200, (int)ControllerCategories.Cat10);
        }

        /// <summary>
        ///     Tests that Cat11 enum value is correctly defined as 0x00000400.
        /// </summary>
        [Fact]
        public void Cat11Value_ShouldBe0x00000400()
        {
            Assert.Equal(0x00000400, (int)ControllerCategories.Cat11);
        }

        /// <summary>
        ///     Tests that Cat12 enum value is correctly defined as 0x00000800.
        /// </summary>
        [Fact]
        public void Cat12Value_ShouldBe0x00000800()
        {
            Assert.Equal(0x00000800, (int)ControllerCategories.Cat12);
        }

        /// <summary>
        ///     Tests that Cat13 enum value is correctly defined as 0x00001000.
        /// </summary>
        [Fact]
        public void Cat13Value_ShouldBe0x00001000()
        {
            Assert.Equal(0x00001000, (int)ControllerCategories.Cat13);
        }

        /// <summary>
        ///     Tests that Cat14 enum value is correctly defined as 0x00002000.
        /// </summary>
        [Fact]
        public void Cat14Value_ShouldBe0x00002000()
        {
            Assert.Equal(0x00002000, (int)ControllerCategories.Cat14);
        }

        /// <summary>
        ///     Tests that Cat15 enum value is correctly defined as 0x00004000.
        /// </summary>
        [Fact]
        public void Cat15Value_ShouldBe0x00004000()
        {
            Assert.Equal(0x00004000, (int)ControllerCategories.Cat15);
        }

        /// <summary>
        ///     Tests that Cat16 enum value is correctly defined as 0x00008000.
        /// </summary>
        [Fact]
        public void Cat16Value_ShouldBe0x00008000()
        {
            Assert.Equal(0x00008000, (int)ControllerCategories.Cat16);
        }

        /// <summary>
        ///     Tests that Cat17 enum value is correctly defined as 0x00010000.
        /// </summary>
        [Fact]
        public void Cat17Value_ShouldBe0x00010000()
        {
            Assert.Equal(0x00010000, (int)ControllerCategories.Cat17);
        }

        /// <summary>
        ///     Tests that Cat18 enum value is correctly defined as 0x00020000.
        /// </summary>
        [Fact]
        public void Cat18Value_ShouldBe0x00020000()
        {
            Assert.Equal(0x00020000, (int)ControllerCategories.Cat18);
        }

        /// <summary>
        ///     Tests that Cat19 enum value is correctly defined as 0x00040000.
        /// </summary>
        [Fact]
        public void Cat19Value_ShouldBe0x00040000()
        {
            Assert.Equal(0x00040000, (int)ControllerCategories.Cat19);
        }

        /// <summary>
        ///     Tests that Cat20 enum value is correctly defined as 0x00080000.
        /// </summary>
        [Fact]
        public void Cat20Value_ShouldBe0x00080000()
        {
            Assert.Equal(0x00080000, (int)ControllerCategories.Cat20);
        }

        /// <summary>
        ///     Tests that Cat21 enum value is correctly defined as 0x00100000.
        /// </summary>
        [Fact]
        public void Cat21Value_ShouldBe0x00100000()
        {
            Assert.Equal(0x00100000, (int)ControllerCategories.Cat21);
        }

        /// <summary>
        ///     Tests that Cat22 enum value is correctly defined as 0x00200000.
        /// </summary>
        [Fact]
        public void Cat22Value_ShouldBe0x00200000()
        {
            Assert.Equal(0x00200000, (int)ControllerCategories.Cat22);
        }

        /// <summary>
        ///     Tests that Cat23 enum value is correctly defined as 0x00400000.
        /// </summary>
        [Fact]
        public void Cat23Value_ShouldBe0x00400000()
        {
            Assert.Equal(0x00400000, (int)ControllerCategories.Cat23);
        }

        /// <summary>
        ///     Tests that Cat24 enum value is correctly defined as 0x00800000.
        /// </summary>
        [Fact]
        public void Cat24Value_ShouldBe0x00800000()
        {
            Assert.Equal(0x00800000, (int)ControllerCategories.Cat24);
        }

        /// <summary>
        ///     Tests that Cat25 enum value is correctly defined as 0x01000000.
        /// </summary>
        [Fact]
        public void Cat25Value_ShouldBe0x01000000()
        {
            Assert.Equal(0x01000000, (int)ControllerCategories.Cat25);
        }

        /// <summary>
        ///     Tests that Cat26 enum value is correctly defined as 0x02000000.
        /// </summary>
        [Fact]
        public void Cat26Value_ShouldBe0x02000000()
        {
            Assert.Equal(0x02000000, (int)ControllerCategories.Cat26);
        }

        /// <summary>
        ///     Tests that Cat27 enum value is correctly defined as 0x04000000.
        /// </summary>
        [Fact]
        public void Cat27Value_ShouldBe0x04000000()
        {
            Assert.Equal(0x04000000, (int)ControllerCategories.Cat27);
        }

        /// <summary>
        ///     Tests that Cat28 enum value is correctly defined as 0x08000000.
        /// </summary>
        [Fact]
        public void Cat28Value_ShouldBe0x08000000()
        {
            Assert.Equal(0x08000000, (int)ControllerCategories.Cat28);
        }

        /// <summary>
        ///     Tests that Cat29 enum value is correctly defined as 0x10000000.
        /// </summary>
        [Fact]
        public void Cat29Value_ShouldBe0x10000000()
        {
            Assert.Equal(0x10000000, (int)ControllerCategories.Cat29);
        }
    }
}
