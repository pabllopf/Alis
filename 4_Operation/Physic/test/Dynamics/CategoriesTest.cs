// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CategoriesTest.cs
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
    ///     The categories test class
    /// </summary>
    public class CategoriesTest
    {
        /// <summary>
        ///     Tests that none enum value should be zero
        /// </summary>
        [Fact]
        public void NoneValue_ShouldBeZero()
        {
            Assert.Equal(0x00000000, (int) Categories.None);
        }

        /// <summary>
        ///     Tests that Cat1 enum value should be 0x00000001
        /// </summary>
        [Fact]
        public void Cat1Value_ShouldBe0x00000001()
        {
            Assert.Equal(0x00000001, (int) Categories.Cat1);
        }

        /// <summary>
        ///     Tests that Cat2 enum value should be 0x00000002
        /// </summary>
        [Fact]
        public void Cat2Value_ShouldBe0x00000002()
        {
            Assert.Equal(0x00000002, (int) Categories.Cat2);
        }

        /// <summary>
        ///     Tests that Cat31 enum value should be 0x40000000
        /// </summary>
        [Fact]
        public void Cat31Value_ShouldBe0x40000000()
        {
            Assert.Equal(0x40000000, (int) Categories.Cat31);
        }

        /// <summary>
        ///     Tests that All enum value should be int.MaxValue
        /// </summary>
        [Fact]
        public void AllValue_ShouldBeIntMaxValue()
        {
            Assert.Equal(int.MaxValue, (int) Categories.All);
        }

        /// <summary>
        ///     Tests that categories should support bitwise or operation
        /// </summary>
        [Fact]
        public void Categories_ShouldSupportBitwiseOr()
        {
            Categories combined = Categories.Cat1 | Categories.Cat2;

            Assert.Equal(0x00000003, (int) combined);
        }

        /// <summary>
        ///     Tests that categories should support bitwise and operation
        /// </summary>
        [Fact]
        public void Categories_ShouldSupportBitwiseAnd()
        {
            Categories combined = Categories.Cat1 | Categories.Cat2 | Categories.Cat3;
            Categories result = combined & Categories.Cat1;

            Assert.Equal(Categories.Cat1, result);
        }

        /// <summary>
        ///     Tests that categories should support bitwise xor operation
        /// </summary>
        [Fact]
        public void Categories_ShouldSupportBitwiseXor()
        {
            Categories combined = Categories.Cat1 | Categories.Cat2;
            Categories result = combined ^ Categories.Cat1;

            Assert.Equal(Categories.Cat2, result);
        }

        /// <summary>
        ///     Tests that categories should support bitwise negation
        /// </summary>
        [Fact]
        public void Categories_ShouldSupportBitwiseNegation()
        {
            Categories cat = Categories.Cat1;
            Categories inverted = ~cat;

            Assert.False(inverted.HasFlag(Categories.Cat1));
        }

        /// <summary>
        ///     Tests that categories should support HasFlag method
        /// </summary>
        [Fact]
        public void Categories_ShouldSupportHasFlag()
        {
            Categories multi = Categories.Cat1 | Categories.Cat2 | Categories.Cat3;

            Assert.True(multi.HasFlag(Categories.Cat1));
            Assert.True(multi.HasFlag(Categories.Cat2));
            Assert.True(multi.HasFlag(Categories.Cat3));
            Assert.False(multi.HasFlag(Categories.Cat4));
        }

        /// <summary>
        ///     Tests that All category should contain all other categories
        /// </summary>
        [Fact]
        public void AllCategory_ShouldContainAllCategories()
        {
            Assert.True(Categories.All.HasFlag(Categories.Cat1));
            Assert.True(Categories.All.HasFlag(Categories.Cat15));
            Assert.True(Categories.All.HasFlag(Categories.Cat31));
        }

        /// <summary>
        ///     Tests that categories should be flags enum
        /// </summary>
        [Fact]
        public void Categories_ShouldBeFlagsEnum()
        {
            object[] attributes = typeof(Categories).GetCustomAttributes(typeof(FlagsAttribute), false);

            Assert.NotEmpty(attributes);
        }

        /// <summary>
        ///     Tests that categories should support multiple flags combination
        /// </summary>
        [Fact]
        public void Categories_ShouldSupportMultipleFlags()
        {
            Categories multi = Categories.Cat1 | Categories.Cat5 | Categories.Cat10 | Categories.Cat20;

            Assert.True((multi & Categories.Cat1) != 0);
            Assert.True((multi & Categories.Cat5) != 0);
            Assert.True((multi & Categories.Cat10) != 0);
            Assert.True((multi & Categories.Cat20) != 0);
            Assert.False((multi & Categories.Cat2) != 0);
        }

        /// <summary>
        ///     Tests that categories should support equality check
        /// </summary>
        [Fact]
        public void Categories_ShouldSupportEqualityCheck()
        {
            Categories cat1 = Categories.Cat1;
            Categories cat2 = Categories.Cat1;

            Assert.Equal(cat1, cat2);
            Assert.True(cat1 == cat2);
        }

        /// <summary>
        ///     Tests that categories should support inequality check
        /// </summary>
        [Fact]
        public void Categories_ShouldSupportInequalityCheck()
        {
            Categories cat1 = Categories.Cat1;
            Categories cat2 = Categories.Cat2;

            Assert.NotEqual(cat1, cat2);
            Assert.True(cat1 != cat2);
        }

        /// <summary>
        ///     Tests that categories should support conversion to int
        /// </summary>
        [Fact]
        public void Categories_ShouldConvertToInt()
        {
            Categories cat = Categories.Cat5;
            int value = (int) cat;

            Assert.Equal(0x00000010, value);
        }

        /// <summary>
        ///     Tests that categories should support conversion from int
        /// </summary>
        [Fact]
        public void Categories_ShouldConvertFromInt()
        {
            Categories cat = (Categories) 0x00000008;

            Assert.Equal(Categories.Cat4, cat);
        }

        /// <summary>
        ///     Tests that categories should support all 31 category flags
        /// </summary>
        [Fact]
        public void Categories_ShouldHaveAll31Categories()
        {
            for (int i = 1; i <= 31; i++)
            {
                Categories cat = (Categories) (1 << (i - 1));
                Assert.NotEqual(Categories.None, cat);
            }
        }

        /// <summary>
        ///     Tests that categories should support complex combination
        /// </summary>
        [Fact]
        public void Categories_ShouldSupportComplexCombination()
        {
            Categories complex = Categories.Cat1 | Categories.Cat3 | Categories.Cat5 | 
                                Categories.Cat7 | Categories.Cat9 | Categories.Cat11;

            Assert.True(complex.HasFlag(Categories.Cat1));
            Assert.True(complex.HasFlag(Categories.Cat3));
            Assert.True(complex.HasFlag(Categories.Cat5));
            Assert.True(complex.HasFlag(Categories.Cat7));
            Assert.True(complex.HasFlag(Categories.Cat9));
            Assert.True(complex.HasFlag(Categories.Cat11));
        }

        /// <summary>
        ///     Tests that categories should support removing flag with and not
        /// </summary>
        [Fact]
        public void Categories_ShouldSupportRemoveFlag()
        {
            Categories multi = Categories.Cat1 | Categories.Cat2 | Categories.Cat3;
            Categories withoutCat2 = multi & ~Categories.Cat2;

            Assert.False(withoutCat2.HasFlag(Categories.Cat2));
            Assert.True(withoutCat2.HasFlag(Categories.Cat1));
            Assert.True(withoutCat2.HasFlag(Categories.Cat3));
        }
    }
}
