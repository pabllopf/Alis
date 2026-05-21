

using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Physic.Common;
using Xunit;

namespace Alis.Core.Physic.Test.Common
{
    /// <summary>
    ///     The fixed array 2 test class
    /// </summary>
    public class FixedArray2Test
    {
        /// <summary>
        ///     Tests that indexer get should return correct value
        /// </summary>
        [Fact]
        public void Indexer_Get_ShouldReturnCorrectValue()
        {
            FixedArray2<int> array = new FixedArray2<int>();
            array[0] = 10;
            array[1] = 20;

            Assert.Equal(10, array[0]);
            Assert.Equal(20, array[1]);
        }

        /// <summary>
        ///     Tests that indexer set should update value
        /// </summary>
        [Fact]
        public void Indexer_Set_ShouldUpdateValue()
        {
            FixedArray2<int> array = new FixedArray2<int>();

            array[0] = 100;
            array[1] = 200;

            Assert.Equal(100, array[0]);
            Assert.Equal(200, array[1]);
        }

        /// <summary>
        ///     Tests that indexer with invalid index should throw exception
        /// </summary>
        [Fact]
        public void Indexer_WithInvalidIndex_ShouldThrowException()
        {
            FixedArray2<int> array = new FixedArray2<int>();

            Assert.Throws<CustomIndexOutOfRangeException>(() => array[2]);
        }

        /// <summary>
        ///     Tests that indexer set with invalid index should throw exception
        /// </summary>
        [Fact]
        public void Indexer_SetWithInvalidIndex_ShouldThrowException()
        {
            FixedArray2<int> array = new FixedArray2<int>();

            Assert.Throws<CustomIndexOutOfRangeException>(() => array[2] = 100);
        }

        /// <summary>
        ///     Tests that indexer with negative index should throw exception
        /// </summary>
        [Fact]
        public void Indexer_WithNegativeIndex_ShouldThrowException()
        {
            FixedArray2<int> array = new FixedArray2<int>();

            Assert.Throws<CustomIndexOutOfRangeException>(() => array[-1]);
        }

        /// <summary>
        ///     Tests that indexer with float values should work
        /// </summary>
        [Fact]
        public void Indexer_WithFloatValues_ShouldWork()
        {
            FixedArray2<float> array = new FixedArray2<float>();
            array[0] = 1.5f;
            array[1] = 2.5f;

            Assert.Equal(1.5f, array[0]);
            Assert.Equal(2.5f, array[1]);
        }

        /// <summary>
        ///     Tests that indexer with string values should work
        /// </summary>
        [Fact]
        public void Indexer_WithStringValues_ShouldWork()
        {
            FixedArray2<string> array = new FixedArray2<string>();
            array[0] = "First";
            array[1] = "Second";

            Assert.Equal("First", array[0]);
            Assert.Equal("Second", array[1]);
        }

        /// <summary>
        ///     Tests that default values should be default for type
        /// </summary>
        [Fact]
        public void DefaultValues_ShouldBeDefaultForType()
        {
            FixedArray2<int> array = new FixedArray2<int>();

            Assert.Equal(0, array[0]);
            Assert.Equal(0, array[1]);
        }

        /// <summary>
        ///     Tests that multiple sets should update correctly
        /// </summary>
        [Fact]
        public void MultipleSets_ShouldUpdateCorrectly()
        {
            FixedArray2<int> array = new FixedArray2<int>();

            array[0] = 10;
            array[0] = 20;
            array[1] = 30;

            Assert.Equal(20, array[0]);
            Assert.Equal(30, array[1]);
        }
    }
}