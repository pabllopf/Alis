

using System;
using System.Runtime.InteropServices;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im vector test class
    /// </summary>
    public class ImVectorGTest
    {
        /// <summary>
        ///     Tests that size should be initialized correctly
        /// </summary>
        [Fact]
        public void Size_ShouldBeInitializedCorrectly()
        {
            ImVector vector = new ImVector {Size = 10, Capacity = 20, Data = IntPtr.Zero};
            ImVectorG<int> imVectorG = new ImVectorG<int>(vector);

            int size = imVectorG.Size;

            Assert.Equal(10, size);
        }

        /// <summary>
        ///     Tests that capacity should be initialized correctly
        /// </summary>
        [Fact]
        public void Capacity_ShouldBeInitializedCorrectly()
        {
            ImVector vector = new ImVector {Size = 10, Capacity = 20, Data = IntPtr.Zero};
            ImVectorG<int> imVectorG = new ImVectorG<int>(vector);

            int capacity = imVectorG.Capacity;

            Assert.Equal(20, capacity);
        }

        /// <summary>
        ///     Tests that data should be initialized correctly
        /// </summary>
        [Fact]
        public void Data_ShouldBeInitializedCorrectly()
        {
            IntPtr data = new IntPtr(123);
            ImVector vector = new ImVector {Size = 10, Capacity = 20, Data = data};
            ImVectorG<int> imVectorG = new ImVectorG<int>(vector);

            IntPtr result = imVectorG.Data;

            Assert.Equal(data, result);
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
            ImVectorG<int> imVectorG = new ImVectorG<int>(data.Length, data.Length, ptr);

            int result = imVectorG[2];

            Assert.Equal(3, result);

            Marshal.FreeHGlobal(ptr);
        }

        /// <summary>
        ///     Tests that indexer should throw index out of range exception
        /// </summary>
        [Fact]
        public void Indexer_ShouldThrowIndexOutOfRangeException()
        {
            ImVectorG<int> imVectorG = new ImVectorG<int>(10, 20, IntPtr.Zero);

            Assert.Throws<NullReferenceException>(() => imVectorG[10]);
        }
    }
}