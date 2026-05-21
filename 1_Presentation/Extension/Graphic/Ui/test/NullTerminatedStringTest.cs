

using System;
using System.Text;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The null terminated string test class
    /// </summary>
    public class NullTerminatedStringTest
    {
        /// <summary>
        ///     Tests that data should set and get correctly with int ptr
        /// </summary>
        [Fact]
        public void Data_Should_SetAndGetCorrectly_WithIntPtr()
        {
            IntPtr data = new IntPtr(123);
            NullTerminatedString nts = new NullTerminatedString(data);
            Assert.Equal(data, nts.Data);
        }

        /// <summary>
        ///     Tests that data should set and get correctly with byte array
        /// </summary>
        [Fact]
        public void Data_Should_SetAndGetCorrectly_WithByteArray()
        {
            byte[] byteArray = {65, 66, 67}; // "ABC"
            NullTerminatedString nts = new NullTerminatedString(byteArray);
            string expectedString = "ABC";
            Assert.Equal(expectedString, nts.ToString());
        }

        /// <summary>
        ///     Tests that to string should return empty string when data is null
        /// </summary>
        [Fact]
        public void ToString_Should_ReturnEmptyString_WhenDataIsNull()
        {
            NullTerminatedString nts = new NullTerminatedString(IntPtr.Zero);
            Assert.Equal(string.Empty, nts.ToString());
        }

        /// <summary>
        ///     Tests that to string should return correct string
        /// </summary>
        [Fact]
        public void ToString_Should_ReturnCorrectString()
        {
            byte[] byteArray = {72, 101, 108, 108, 111}; // "Hello"
            NullTerminatedString nts = new NullTerminatedString(byteArray);
            Assert.Equal("Hello", nts.ToString());
        }

        /// <summary>
        ///     Tests that to string data is null returns empty string
        /// </summary>
        [Fact]
        public void ToString_DataIsNull_ReturnsEmptyString()
        {
            NullTerminatedString nts = new NullTerminatedString(IntPtr.Zero);
            Assert.Equal(string.Empty, nts.ToString());
        }

        /// <summary>
        ///     Tests that to string data is empty returns empty string
        /// </summary>
        [Fact]
        public void ToString_DataIsEmpty_ReturnsEmptyString()
        {
            byte[] data = {0};
            NullTerminatedString nts = new NullTerminatedString(data);
            Assert.Equal(string.Empty, nts.ToString());
        }

        /// <summary>
        ///     Tests that to string data is not empty returns string
        /// </summary>
        [Fact]
        public void ToString_DataIsNotEmpty_ReturnsString()
        {
            byte[] data = Encoding.UTF8.GetBytes("test");
            NullTerminatedString nts = new NullTerminatedString(data);
            Assert.Equal("test", nts.ToString());
        }

        /// <summary>
        ///     Tests that to string data has null terminator returns string
        /// </summary>
        [Fact]
        public void ToString_DataHasNullTerminator_ReturnsString()
        {
            byte[] data = Encoding.UTF8.GetBytes("test\0more");
            NullTerminatedString nts = new NullTerminatedString(data);
            Assert.Equal("test", nts.ToString());
        }

        /// <summary>
        ///     Tests that to string data has multiple null terminators returns string up to first null
        /// </summary>
        [Fact]
        public void ToString_DataHasMultipleNullTerminators_ReturnsStringUpToFirstNull()
        {
            byte[] data = Encoding.UTF8.GetBytes("test\0more\0data");
            NullTerminatedString nts = new NullTerminatedString(data);
            Assert.Equal("test", nts.ToString());
        }
    }
}