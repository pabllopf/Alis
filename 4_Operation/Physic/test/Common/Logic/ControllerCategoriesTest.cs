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
        [Fact]
        public void NoneValue_ShouldBeZero()
        {
            Assert.Equal(0x00000000, (int)ControllerCategories.None);
        }

        [Fact]
        public void Cat01Value_ShouldBe0x00000001()
        {
            Assert.Equal(0x00000001, (int)ControllerCategories.Cat01);
        }

        [Fact]
        public void Cat02Value_ShouldBe0x00000002()
        {
            Assert.Equal(0x00000002, (int)ControllerCategories.Cat02);
        }

        [Fact]
        public void Cat31Value_ShouldBe0x40000000()
        {
            Assert.Equal(0x40000000, (int)ControllerCategories.Cat31);
        }

        [Fact]
        public void AllValue_ShouldBeIntMaxValue()
        {
            Assert.Equal(int.MaxValue, (int)ControllerCategories.All);
        }

        [Fact]
        public void ControllerCategories_ShouldSupportBitwiseOr()
        {
            ControllerCategories combined = ControllerCategories.Cat01 | ControllerCategories.Cat02;

            Assert.Equal(0x00000003, (int)combined);
        }

        [Fact]
        public void ControllerCategories_ShouldSupportBitwiseAnd()
        {
            ControllerCategories combined = ControllerCategories.Cat01 | ControllerCategories.Cat02 | ControllerCategories.Cat03;
            ControllerCategories result = combined & ControllerCategories.Cat01;

            Assert.Equal(ControllerCategories.Cat01, result);
        }

        [Fact]
        public void ControllerCategories_ShouldSupportBitwiseXor()
        {
            ControllerCategories combined = ControllerCategories.Cat01 | ControllerCategories.Cat02;
            ControllerCategories result = combined ^ ControllerCategories.Cat01;

            Assert.Equal(ControllerCategories.Cat02, result);
        }

        [Fact]
        public void ControllerCategories_ShouldSupportBitwiseNegation()
        {
            ControllerCategories cat = ControllerCategories.Cat01;
            ControllerCategories inverted = ~cat;

            Assert.False(inverted.HasFlag(ControllerCategories.Cat01));
        }

        [Fact]
        public void ControllerCategories_ShouldSupportHasFlag()
        {
            ControllerCategories multi = ControllerCategories.Cat01 | ControllerCategories.Cat02 | ControllerCategories.Cat03;

            Assert.True(multi.HasFlag(ControllerCategories.Cat01));
            Assert.True(multi.HasFlag(ControllerCategories.Cat02));
            Assert.True(multi.HasFlag(ControllerCategories.Cat03));
            Assert.False(multi.HasFlag(ControllerCategories.Cat04));
        }

        [Fact]
        public void AllCategory_ShouldContainAllCategories()
        {
            Assert.True(ControllerCategories.All.HasFlag(ControllerCategories.Cat01));
            Assert.True(ControllerCategories.All.HasFlag(ControllerCategories.Cat15));
            Assert.True(ControllerCategories.All.HasFlag(ControllerCategories.Cat31));
        }

        [Fact]
        public void ControllerCategories_ShouldBeFlagsEnum()
        {
            object[] attributes = typeof(ControllerCategories).GetCustomAttributes(typeof(FlagsAttribute), false);

            Assert.NotEmpty(attributes);
        }

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

        [Fact]
        public void ControllerCategories_ShouldSupportEqualityCheck()
        {
            ControllerCategories cat1 = ControllerCategories.Cat01;
            ControllerCategories cat2 = ControllerCategories.Cat01;

            Assert.Equal(cat1, cat2);
            Assert.True(cat1 == cat2);
        }

        [Fact]
        public void ControllerCategories_ShouldSupportInequalityCheck()
        {
            ControllerCategories cat1 = ControllerCategories.Cat01;
            ControllerCategories cat2 = ControllerCategories.Cat02;

            Assert.NotEqual(cat1, cat2);
            Assert.True(cat1 != cat2);
        }

        [Fact]
        public void ControllerCategories_ShouldConvertToInt()
        {
            ControllerCategories cat = ControllerCategories.Cat05;
            int value = (int)cat;

            Assert.Equal(0x00000010, value);
        }

        [Fact]
        public void ControllerCategories_ShouldConvertFromInt()
        {
            ControllerCategories cat = (ControllerCategories)0x00000008;

            Assert.Equal(ControllerCategories.Cat04, cat);
        }

        [Fact]
        public void ControllerCategories_ShouldHaveAll31Categories()
        {
            for (int i = 1; i <= 31; i++)
            {
                ControllerCategories cat = (ControllerCategories)(1 << (i - 1));
                Assert.NotEqual(ControllerCategories.None, cat);
            }
        }

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
