

using System;
using System.Runtime.InteropServices;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im vector test class
    /// </summary>
    public class ImVectorTest
    {
        /// <summary>
        ///     Tests that size should be initialized
        /// </summary>
        [Fact]
        public void Size_ShouldBeInitialized()
        {
            ImVector vector = new ImVector();
            Assert.Equal(0, vector.Size);
        }

        /// <summary>
        ///     Tests that capacity should be initialized
        /// </summary>
        [Fact]
        public void Capacity_ShouldBeInitialized()
        {
            ImVector vector = new ImVector();
            Assert.Equal(0, vector.Capacity);
        }

        /// <summary>
        ///     Tests that data should be initialized
        /// </summary>
        [Fact]
        public void Data_ShouldBeInitialized()
        {
            ImVector vector = new ImVector();
            Assert.Equal(IntPtr.Zero, vector.Data);
        }

        /// <summary>
        ///     Tests that constructor should initialize fields
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeFields()
        {
            IntPtr data = new IntPtr(123);
            ImVector vector = new ImVector(10, 20, data);
            Assert.Equal(10, vector.Size);
            Assert.Equal(20, vector.Capacity);
            Assert.Equal(data, vector.Data);
        }

        /// <summary>
        ///     Tests that ref should return correct value
        /// </summary>
        [Fact]
        public void Ref_ShouldReturnCorrectValue()
        {
            IntPtr data = Marshal.AllocHGlobal(4);
            Marshal.WriteInt32(data, 42);
            ImVector vector = new ImVector(1, 1, data);
            Assert.Equal(42, vector.Ref<int>(0));
            Marshal.FreeHGlobal(data);
        }

        /// <summary>
        ///     Tests that address should return correct pointer
        /// </summary>
        [Fact]
        public void Address_ShouldReturnCorrectPointer()
        {
            IntPtr data = new IntPtr(123);
            ImVector vector = new ImVector(1, 1, data);
            Assert.Equal(data, vector.Address<int>(0));
        }
    }
}