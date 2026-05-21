

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
            Category category = Category.None;

            Assert.Equal(Category.None, category);
            Assert.Equal(0x00000000, (int) category);
        }

        /// <summary>
        ///     Tests that cat1 enum value should be defined
        /// </summary>
        [Fact]
        public void Cat1EnumValue_ShouldBeDefined()
        {
            Category category = Category.Cat1;

            Assert.Equal(0x00000001, (int) category);
        }

        /// <summary>
        ///     Tests that cat2 enum value should be defined
        /// </summary>
        [Fact]
        public void Cat2EnumValue_ShouldBeDefined()
        {
            Category category = Category.Cat2;

            Assert.Equal(0x00000002, (int) category);
        }

        /// <summary>
        ///     Tests that cat31 enum value should be defined
        /// </summary>
        [Fact]
        public void Cat31EnumValue_ShouldBeDefined()
        {
            Category category = Category.Cat31;

            Assert.Equal(Category.Cat31, category);
        }

        /// <summary>
        ///     Tests that all enum value should be max value
        /// </summary>
        [Fact]
        public void AllEnumValue_ShouldBeMaxValue()
        {
            Category category = Category.All;

            Assert.Equal(Category.All, category);
            Assert.Equal(int.MaxValue, (int) category);
        }

        /// <summary>
        ///     Tests that category should support bitwise or operation
        /// </summary>
        [Fact]
        public void Category_ShouldSupportBitwiseOrOperation()
        {
            Category combined = Category.Cat1 | Category.Cat2;

            Assert.Equal(0x00000003, (int) combined);
        }

        /// <summary>
        ///     Tests that category should support bitwise and operation
        /// </summary>
        [Fact]
        public void Category_ShouldSupportBitwiseAndOperation()
        {
            Category combined = Category.Cat1 | Category.Cat2;
            Category result = combined & Category.Cat1;

            Assert.Equal(Category.Cat1, result);
        }

        /// <summary>
        ///     Tests that category should support bitwise xor operation
        /// </summary>
        [Fact]
        public void Category_ShouldSupportBitwiseXorOperation()
        {
            Category combined = Category.Cat1 | Category.Cat2;
            Category result = combined ^ Category.Cat1;

            Assert.Equal(Category.Cat2, result);
        }

        /// <summary>
        ///     Tests that category should support multiple flags
        /// </summary>
        [Fact]
        public void Category_ShouldSupportMultipleFlags()
        {
            Category multi = Category.Cat1 | Category.Cat5 | Category.Cat10;

            Assert.True((multi & Category.Cat1) != 0);
            Assert.True((multi & Category.Cat5) != 0);
            Assert.True((multi & Category.Cat10) != 0);
            Assert.False((multi & Category.Cat2) != 0);
        }

        /// <summary>
        ///     Tests that category should support has flag check
        /// </summary>
        [Fact]
        public void Category_ShouldSupportHasFlagCheck()
        {
            Category multi = Category.Cat1 | Category.Cat2;

            Assert.True(multi.HasFlag(Category.Cat1));
            Assert.True(multi.HasFlag(Category.Cat2));
            Assert.False(multi.HasFlag(Category.Cat3));
        }

        /// <summary>
        ///     Tests that all category should contain all other categories
        /// </summary>
        [Fact]
        public void AllCategory_ShouldContainAllOtherCategories()
        {
            Category all = Category.All;

            Assert.True(all.HasFlag(Category.Cat1));
            Assert.True(all.HasFlag(Category.Cat15));
            Assert.True(all.HasFlag(Category.Cat31));
        }

        /// <summary>
        ///     Tests that category should be flags enum
        /// </summary>
        [Fact]
        public void Category_ShouldBeFlagsEnum()
        {
            object[] attributes = typeof(Category).GetCustomAttributes(typeof(FlagsAttribute), false);

            Assert.NotEmpty(attributes);
        }

        /// <summary>
        ///     Tests that category should support bitwise negation
        /// </summary>
        [Fact]
        public void Category_ShouldSupportBitwiseNegation()
        {
            Category cat = Category.Cat1;
            Category inverted = ~cat;

            Assert.False(inverted.HasFlag(Category.Cat1));
        }
    }
}