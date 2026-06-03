// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: UtilTests.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web: https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;
using System.Text;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for the internal Util class, specifically PtrToStringUTF8
    /// </summary>
    public class UtilTests
    {
        // Use NativeWindow type to get the source assembly (not the test assembly)
        private static readonly Type UtilType = typeof(NativeWindow).Assembly.GetType("Alis.Extension.Graphic.Glfw.Util");
        private static readonly System.Reflection.MethodInfo PtrToStringUTF8 = UtilType.GetMethod(
            "PtrToStringUTF8", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);

        private static string CallPtrToStringUTF8(IntPtr ptr)
        {
            return (string)PtrToStringUTF8.Invoke(null, new object[] { ptr });
        }
        /// <summary>
        ///     Tests that PtrToStringUTF8 correctly reads a null-terminated UTF-8 string from a pointer
        /// </summary>
        [Fact]
        public void PtrToStringUTF8_ValidString_ReturnsCorrectValue()
        {
            // Arrange
            string testString = "Hello, GLFW!";
            byte[] bytes = Encoding.UTF8.GetBytes(testString);
            IntPtr ptr = Marshal.AllocHGlobal(bytes.Length + 1);

            try
            {
                Marshal.Copy(bytes, 0, ptr, bytes.Length);
                Marshal.WriteByte(ptr, bytes.Length, 0); // Null terminator


                string result = CallPtrToStringUTF8(ptr);

                // Assert
                Assert.Equal(testString, result);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        ///     Tests that PtrToStringUTF8 returns empty string for IntPtr.Zero
        /// </summary>
        [Fact]
        public void PtrToStringUTF8_NullPointer_ReturnsEmptyString()
        {
            // Arrange

            // Act
            string result = CallPtrToStringUTF8(IntPtr.Zero);

            // Assert
            Assert.Equal("", result);
        }

        /// <summary>
        ///     Tests that PtrToStringUTF8 correctly reads an empty string (null terminator at position 0)
        /// </summary>
        [Fact]
        public void PtrToStringUTF8_EmptyString_ReturnsEmptyString()
        {
            // Arrange
            IntPtr ptr = Marshal.AllocHGlobal(1);

            try
            {
                Marshal.WriteByte(ptr, 0, 0); // Null terminator at position 0


                // Act
                string result = CallPtrToStringUTF8(ptr);

                // Assert
                Assert.Equal("", result);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        ///     Tests that PtrToStringUTF8 correctly handles multi-byte UTF-8 characters (emojis, accented chars)
        /// </summary>
        [Fact]
        public void PtrToStringUTF8_MultiByteUTF8_ReturnsCorrectValue()
        {
            // Arrange
            string testString = "Héllo Wörld! 🎮";
            byte[] bytes = Encoding.UTF8.GetBytes(testString);
            IntPtr ptr = Marshal.AllocHGlobal(bytes.Length + 1);

            try
            {
                Marshal.Copy(bytes, 0, ptr, bytes.Length);
                Marshal.WriteByte(ptr, bytes.Length, 0); // Null terminator


                // Act
                string result = CallPtrToStringUTF8(ptr);

                // Assert
                Assert.Equal(testString, result);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        ///     Tests that PtrToStringUTF8 correctly handles long strings
        /// </summary>
        [Fact]
        public void PtrToStringUTF8_LongString_ReturnsCorrectValue()
        {
            // Arrange
            string testString = new string('A', 10000);
            byte[] bytes = Encoding.UTF8.GetBytes(testString);
            IntPtr ptr = Marshal.AllocHGlobal(bytes.Length + 1);

            try
            {
                Marshal.Copy(bytes, 0, ptr, bytes.Length);
                Marshal.WriteByte(ptr, bytes.Length, 0); // Null terminator


                // Act
                string result = CallPtrToStringUTF8(ptr);

                // Assert
                Assert.Equal(testString, result);
                Assert.Equal(10000, result.Length);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        ///     Tests that PtrToStringUTF8 correctly handles special characters
        /// </summary>
        
        [InlineData("\n", "newline")]
        [InlineData("\t", "tab")]
        [InlineData("\r", "carriage return")]
        [InlineData(" ", "space")]
        public void PtrToStringUTF8_SpecialCharacters_ReturnsCorrectValue(string testString, string description)
        {
            // Arrange
            byte[] bytes = Encoding.UTF8.GetBytes(testString);
            IntPtr ptr = Marshal.AllocHGlobal(bytes.Length + 1);

            try
            {
                Marshal.Copy(bytes, 0, ptr, bytes.Length);
                Marshal.WriteByte(ptr, bytes.Length, 0); // Null terminator


                // Act
                string result = CallPtrToStringUTF8(ptr);

                // Assert
                Assert.Equal(testString, result);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        ///     Tests that PtrToStringUTF8 correctly handles Unicode code points beyond BMP
        /// </summary>
        [Fact]
        public void PtrToStringUTF8_SurrogatePairs_ReturnsCorrectValue()
        {
            // Arrange - Test with a surrogate pair (emoji outside BMP)
            string testString = "🎮🕹️🎯";
            byte[] bytes = Encoding.UTF8.GetBytes(testString);
            IntPtr ptr = Marshal.AllocHGlobal(bytes.Length + 1);

            try
            {
                Marshal.Copy(bytes, 0, ptr, bytes.Length);
                Marshal.WriteByte(ptr, bytes.Length, 0); // Null terminator


                // Act
                string result = CallPtrToStringUTF8(ptr);

                // Assert
                Assert.Equal(testString, result);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        ///     Tests that the Util class is internal and static
        /// </summary>
        [Fact]
        public void Util_Class_IsInternalAndStatic()
        {
            // Arrange & Act
            Type utilType = typeof(NativeWindow).Assembly.GetType("Alis.Extension.Graphic.Glfw.Util");

            // Assert
            Assert.NotNull(utilType);
            Assert.True(utilType.IsAbstract); // internal class in C# compiles to abstract sealed
            Assert.True(utilType.IsSealed);
        }

        /// <summary>
        ///     Tests that PtrToStringUTF8 handles CJK characters correctly
        /// </summary>
        [Fact]
        public void PtrToStringUTF8_CJKCharacters_ReturnsCorrectValue()
        {
            // Arrange
            string testString = "こんにちは世界"; // Japanese: "Hello, World"
            byte[] bytes = Encoding.UTF8.GetBytes(testString);
            IntPtr ptr = Marshal.AllocHGlobal(bytes.Length + 1);

            try
            {
                Marshal.Copy(bytes, 0, ptr, bytes.Length);
                Marshal.WriteByte(ptr, bytes.Length, 0); // Null terminator


                // Act
                string result = CallPtrToStringUTF8(ptr);

                // Assert
                Assert.Equal(testString, result);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        ///     Tests that PtrToStringUTF8 handles Cyrillic characters correctly
        /// </summary>
        [Fact]
        public void PtrToStringUTF8_CyrillicCharacters_ReturnsCorrectValue()
        {
            // Arrange
            string testString = "Привет мир"; // Russian: "Hello, World"
            byte[] bytes = Encoding.UTF8.GetBytes(testString);
            IntPtr ptr = Marshal.AllocHGlobal(bytes.Length + 1);

            try
            {
                Marshal.Copy(bytes, 0, ptr, bytes.Length);
                Marshal.WriteByte(ptr, bytes.Length, 0); // Null terminator


                // Act
                string result = CallPtrToStringUTF8(ptr);

                // Assert
                Assert.Equal(testString, result);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        ///     Tests that PtrToStringUTF8 handles Arabic characters correctly
        /// </summary>
        [Fact]
        public void PtrToStringUTF8_ArabicCharacters_ReturnsCorrectValue()
        {
            // Arrange
            string testString = "مرحبا بالعالم"; // Arabic: "Hello, World"
            byte[] bytes = Encoding.UTF8.GetBytes(testString);
            IntPtr ptr = Marshal.AllocHGlobal(bytes.Length + 1);

            try
            {
                Marshal.Copy(bytes, 0, ptr, bytes.Length);
                Marshal.WriteByte(ptr, bytes.Length, 0); // Null terminator


                // Act
                string result = CallPtrToStringUTF8(ptr);

                // Assert
                Assert.Equal(testString, result);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
    }
}
