// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NullTerminatedStringTest.cs
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
        ///     Tests that implicit conversion should return correct string
        /// </summary>
        [Fact]
        public void ImplicitConversion_Should_ReturnCorrectString()
        {
            byte[] byteArray = {87, 111, 114, 108, 100}; // "CurrentWorld"
            NullTerminatedString nts = new NullTerminatedString(byteArray);
            string result = nts;
            Assert.Equal("CurrentWorld", result);
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