

using System;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The union value test class
    /// </summary>
    public class UnionValueTest
    {
        /// <summary>
        ///     Tests that value i 32 should be initialized correctly
        /// </summary>
        [Fact]
        public void ValueI32_ShouldBeInitializedCorrectly()
        {
            UnionValue unionValue = new UnionValue {ValueI32 = 42};

            int value = unionValue.ValueI32;

            Assert.Equal(42, value);
        }

        /// <summary>
        ///     Tests that value f 32 should be initialized correctly
        /// </summary>
        [Fact]
        public void ValueF32_ShouldBeInitializedCorrectly()
        {
            UnionValue unionValue = new UnionValue {ValueF32 = 42.0f};

            float value = unionValue.ValueF32;

            Assert.Equal(42.0f, value);
        }

        /// <summary>
        ///     Tests that value ptr should be initialized correctly
        /// </summary>
        [Fact]
        public void ValuePtr_ShouldBeInitializedCorrectly()
        {
            IntPtr ptr = new IntPtr(42);
            UnionValue unionValue = new UnionValue {ValuePtr = ptr};

            IntPtr value = unionValue.ValuePtr;

            Assert.Equal(ptr, value);
        }

        /// <summary>
        ///     Tests that value i 32 should overwrite value f 32
        /// </summary>
        [Fact]
        public void ValueI32_ShouldOverwriteValueF32()
        {
            UnionValue unionValue = new UnionValue {ValueF32 = 42.0f};

            unionValue.ValueI32 = 42;

            Assert.Equal(42, unionValue.ValueI32);
            Assert.NotEqual(42.0f, unionValue.ValueF32);
        }

        /// <summary>
        ///     Tests that value f 32 should overwrite value i 32
        /// </summary>
        [Fact]
        public void ValueF32_ShouldOverwriteValueI32()
        {
            UnionValue unionValue = new UnionValue {ValueI32 = 42};

            unionValue.ValueF32 = 42.0f;

            Assert.Equal(42.0f, unionValue.ValueF32);
            Assert.NotEqual(42, unionValue.ValueI32);
        }

        /// <summary>
        ///     Tests that value ptr should overwrite value i 32
        /// </summary>
        [Fact]
        public void ValuePtr_ShouldOverwriteValueI32()
        {
            UnionValue unionValue = new UnionValue {ValueI32 = 42};
            IntPtr ptr = new IntPtr(42);

            unionValue.ValuePtr = ptr;

            Assert.Equal(ptr, unionValue.ValuePtr);
            Assert.Equal(42, unionValue.ValueI32);
        }
    }
}