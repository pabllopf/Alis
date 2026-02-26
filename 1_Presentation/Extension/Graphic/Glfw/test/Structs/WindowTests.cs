// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowTests.cs
// 
//  Author:GitHub Copilot
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
using Alis.Extension.Graphic.Glfw.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Structs
{
    /// <summary>
    ///     Tests for Window structure
    /// </summary>
    public class WindowTests
    {
        /// <summary>
        /// Tests that window none is default value
        /// </summary>
        [Fact]
        public void Window_None_IsDefaultValue()
        {
            // Arrange & Act
            Window none = Window.None;

            // Assert
            Assert.Equal(default(Window), none);
        }

        /// <summary>
        /// Tests that window constructor with int ptr creates window
        /// </summary>
        [Fact]
        public void Window_Constructor_WithIntPtr_CreatesWindow()
        {
            // Arrange
            IntPtr handle = new IntPtr(12345);

            // Act
            Window window = new Window(handle);

            // Assert - Window is created without exceptions
            Assert.NotNull(window);
        }

        /// <summary>
        /// Tests that window implicit conversion to int ptr works
        /// </summary>
        [Fact]
        public void Window_ImplicitConversion_ToIntPtr_Works()
        {
            // Arrange
            IntPtr handle = new IntPtr(12345);
            Window window = new Window(handle);

            // Act
            IntPtr result = window;

            // Assert
            Assert.Equal(handle, result);
        }

        /// <summary>
        /// Tests that window explicit conversion from int ptr works
        /// </summary>
        [Fact]
        public void Window_ExplicitConversion_FromIntPtr_Works()
        {
            // Arrange
            IntPtr handle = new IntPtr(12345);

            // Act
            Window window = (Window)handle;

            // Assert
            IntPtr result = window;
            Assert.Equal(handle, result);
        }

        /// <summary>
        /// Tests that window to string returns handle string
        /// </summary>
        [Fact]
        public void Window_ToString_ReturnsHandleString()
        {
            // Arrange
            IntPtr handle = new IntPtr(12345);
            Window window = new Window(handle);

            // Act
            string result = window.ToString();

            // Assert
            Assert.Equal(handle.ToString(), result);
        }

        /// <summary>
        /// Tests that window equals with same window returns true
        /// </summary>
        [Fact]
        public void Window_Equals_WithSameWindow_ReturnsTrue()
        {
            // Arrange
            IntPtr handle = new IntPtr(12345);
            Window window1 = new Window(handle);
            Window window2 = new Window(handle);

            // Act
            bool result = window1.Equals(window2);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Tests that window equals with object returns correct result
        /// </summary>
        [Fact]
        public void Window_Equals_WithObject_ReturnsCorrectResult()
        {
            // Arrange
            IntPtr handle = new IntPtr(12345);
            Window window = new Window(handle);
            object obj = new Window(handle);

            // Act
            bool result = window.Equals(obj);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Tests that window equals with non window object returns false
        /// </summary>
        [Fact]
        public void Window_Equals_WithNonWindowObject_ReturnsFalse()
        {
            // Arrange
            Window window = Window.None;
            object obj = new object();

            // Act
            bool result = window.Equals(obj);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        /// Tests that window get hash code returns same for equal windows
        /// </summary>
        [Fact]
        public void Window_GetHashCode_ReturnsSameForEqualWindows()
        {
            // Arrange
            IntPtr handle = new IntPtr(12345);
            Window window1 = new Window(handle);
            Window window2 = new Window(handle);

            // Act
            int hash1 = window1.GetHashCode();
            int hash2 = window2.GetHashCode();

            // Assert
            Assert.Equal(hash1, hash2);
        }

        /// <summary>
        /// Tests that window equality operator with same windows returns true
        /// </summary>
        [Fact]
        public void Window_EqualityOperator_WithSameWindows_ReturnsTrue()
        {
            // Arrange
            IntPtr handle = new IntPtr(12345);
            Window window1 = new Window(handle);
            Window window2 = new Window(handle);

            // Act
            bool result = window1 == window2;

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Tests that window inequality operator with different windows returns true
        /// </summary>
        [Fact]
        public void Window_InequalityOperator_WithDifferentWindows_ReturnsTrue()
        {
            // Arrange
            Window window1 = new Window(new IntPtr(123));
            Window window2 = new Window(new IntPtr(456));

            // Act
            bool result = window1 != window2;

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Tests that window equals with i equatable interface works
        /// </summary>
        [Fact]
        public void Window_Equals_WithIEquatableInterface_Works()
        {
            // Arrange
            IntPtr handle = new IntPtr(12345);
            Window window1 = new Window(handle);
            IEquatable<Window> window2 = new Window(handle);

            // Act
            bool result = window1.Equals(window2);

            // Assert
            Assert.True(result);
        }
    }
}

