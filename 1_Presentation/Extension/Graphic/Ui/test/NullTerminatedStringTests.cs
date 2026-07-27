// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NullTerminatedStringTests.cs
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
using System.Runtime.InteropServices;
using System.Text;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The null terminated string tests class
    /// </summary>
    public class NullTerminatedStringTests
    {
        /// <summary>
        ///     Tests that constructor with int ptr should set data
        /// </summary>
        [Fact]
        public void Constructor_WithIntPtr_ShouldSetData()
        {
            IntPtr expected = new IntPtr(123);
            NullTerminatedString nts = new NullTerminatedString(expected);

            Assert.Equal(expected, nts.Data);
        }

        /// <summary>
        ///     Tests that constructor with byte array should allocate and copy
        /// </summary>
        [Fact]
        public void Constructor_WithByteArray_ShouldAllocateAndCopy()
        {
            byte[] data = Encoding.UTF8.GetBytes("Hello");
            NullTerminatedString nts = new NullTerminatedString(data);

            Assert.NotEqual(IntPtr.Zero, nts.Data);

            byte[] buffer = new byte[data.Length];
            Marshal.Copy(nts.Data, buffer, 0, data.Length);
            Assert.Equal(data, buffer);

            byte terminator = Marshal.ReadByte(nts.Data, data.Length);
            Assert.Equal(0, terminator);

            Marshal.FreeHGlobal(nts.Data);
        }

        /// <summary>
        ///     Tests that constructor with empty byte array should allocate null terminator
        /// </summary>
        [Fact]
        public void Constructor_WithEmptyByteArray_ShouldAllocateNullTerminator()
        {
            byte[] data = Array.Empty<byte>();
            NullTerminatedString nts = new NullTerminatedString(data);

            Assert.NotEqual(IntPtr.Zero, nts.Data);

            byte terminator = Marshal.ReadByte(nts.Data, 0);
            Assert.Equal(0, terminator);

            Marshal.FreeHGlobal(nts.Data);
        }

        /// <summary>
        ///     Tests that to string with zero data returns empty string
        /// </summary>
        [Fact]
        public void ToString_WithZeroData_ReturnsEmptyString()
        {
            NullTerminatedString nts = new NullTerminatedString(IntPtr.Zero);
            string result = nts.ToString();

            Assert.Equal(string.Empty, result);
        }

        /// <summary>
        ///     Tests that to string with valid null terminated string returns expected string
        /// </summary>
        [Fact]
        public void ToString_WithValidData_ReturnsString()
        {
            byte[] data = Encoding.UTF8.GetBytes("Hello World");
            IntPtr ptr = Marshal.AllocHGlobal(data.Length + 1);
            Marshal.Copy(data, 0, ptr, data.Length);
            Marshal.WriteByte(ptr + data.Length, 0);

            NullTerminatedString nts = new NullTerminatedString(ptr);
            string result = nts.ToString();

            Assert.Equal("Hello World", result);

            Marshal.FreeHGlobal(ptr);
        }

        /// <summary>
        ///     Tests that to string with data pointing to empty string returns empty string
        /// </summary>
        [Fact]
        public void ToString_WithEmptyNullTerminatedString_ReturnsEmptyString()
        {
            IntPtr ptr = Marshal.AllocHGlobal(1);
            Marshal.WriteByte(ptr, 0);

            NullTerminatedString nts = new NullTerminatedString(ptr);
            string result = nts.ToString();

            Assert.Equal(string.Empty, result);

            Marshal.FreeHGlobal(ptr);
        }

        /// <summary>
        ///     Tests that to string with data containing unicode characters returns expected string
        /// </summary>
        [Fact]
        public void ToString_WithUnicodeData_ReturnsString()
        {
            string expected = "Héllö Wörld 🌍";
            byte[] data = Encoding.UTF8.GetBytes(expected);
            IntPtr ptr = Marshal.AllocHGlobal(data.Length + 1);
            Marshal.Copy(data, 0, ptr, data.Length);
            Marshal.WriteByte(ptr + data.Length, 0);

            NullTerminatedString nts = new NullTerminatedString(ptr);
            string result = nts.ToString();

            Assert.Equal(expected, result);

            Marshal.FreeHGlobal(ptr);
        }

        /// <summary>
        ///     Tests that implicit operator to string with zero data returns empty string
        /// </summary>
        [Fact]
        public void ImplicitOperator_WithZeroData_ReturnsEmptyString()
        {
            NullTerminatedString nts = new NullTerminatedString(IntPtr.Zero);
            string result = nts;

            Assert.Equal(string.Empty, result);
        }

        /// <summary>
        ///     Tests that implicit operator to string with valid data returns expected string
        /// </summary>
        [Fact]
        public void ImplicitOperator_WithValidData_ReturnsString()
        {
            byte[] data = Encoding.UTF8.GetBytes("Test");
            IntPtr ptr = Marshal.AllocHGlobal(data.Length + 1);
            Marshal.Copy(data, 0, ptr, data.Length);
            Marshal.WriteByte(ptr + data.Length, 0);

            NullTerminatedString nts = new NullTerminatedString(ptr);
            string result = nts;

            Assert.Equal("Test", result);

            Marshal.FreeHGlobal(ptr);
        }
    }
}
