

using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Matrix;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The range ptr accessor test class
    /// </summary>
    public class RangePtrAccessorTest
    {
        /// <summary>
        ///     Tests that data should be initialized correctly
        /// </summary>
        [Fact]
        public void Data_ShouldBeInitializedCorrectly()
        {
            IntPtr data = new IntPtr(123);
            RangePtrAccessor<int> accessor = new RangePtrAccessor<int>(data, 10);

            IntPtr result = accessor.Data;

            Assert.Equal(data, result);
        }

        /// <summary>
        ///     Tests that count should be initialized correctly
        /// </summary>
        [Fact]
        public void Count_ShouldBeInitializedCorrectly()
        {
            RangePtrAccessor<int> accessor = new RangePtrAccessor<int>(new IntPtr(123), 10);

            int result = accessor.Count;

            Assert.Equal(10, result);
        }

        /// <summary>
        ///     Tests that indexer should return correct value
        /// </summary>
        [Fact]
        public void Indexer_ShouldReturnCorrectValue()
        {
            int[] data = {1, 2, 3, 4, 5};
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<int>() * data.Length);
            Marshal.Copy(data, 0, ptr, data.Length);
            RangePtrAccessor<int> accessor = new RangePtrAccessor<int>(ptr, data.Length);

            int result = accessor[2];

            Assert.Equal(3, result);

            Marshal.FreeHGlobal(ptr);
        }

        /// <summary>
        ///     Tests that indexer should throw index out of range exception
        /// </summary>
        [Fact]
        public void Indexer_ShouldThrowIndexOutOfRangeException()
        {
            RangePtrAccessor<int> accessor = new RangePtrAccessor<int>(new IntPtr(123), 10);

            Assert.Throws<CustomIndexOutOfRangeException>(() => accessor[10]);
        }
    }
}