

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
        ///     Tests that window none is default value
        /// </summary>
        [Fact]
        public void Window_None_IsDefaultValue()
        {
            Window none = Window.None;

            Assert.Equal(default(Window), none);
        }

        /// <summary>
        ///     Tests that window constructor with int ptr creates window
        /// </summary>
        [Fact]
        public void Window_Constructor_WithIntPtr_CreatesWindow()
        {
            IntPtr handle = new IntPtr(12345);

            Window window = new Window(handle);

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Tests that window implicit conversion to int ptr works
        /// </summary>
        [Fact]
        public void Window_ImplicitConversion_ToIntPtr_Works()
        {
            IntPtr handle = new IntPtr(12345);
            Window window = new Window(handle);

            IntPtr result = window;

            Assert.Equal(handle, result);
        }

        /// <summary>
        ///     Tests that window explicit conversion from int ptr works
        /// </summary>
        [Fact]
        public void Window_ExplicitConversion_FromIntPtr_Works()
        {
            IntPtr handle = new IntPtr(12345);

            Window window = (Window) handle;

            IntPtr result = window;
            Assert.Equal(handle, result);
        }

        /// <summary>
        ///     Tests that window to string returns handle string
        /// </summary>
        [Fact]
        public void Window_ToString_ReturnsHandleString()
        {
            IntPtr handle = new IntPtr(12345);
            Window window = new Window(handle);

            string result = window.ToString();

            Assert.Equal(handle.ToString(), result);
        }

        /// <summary>
        ///     Tests that window equals with same window returns true
        /// </summary>
        [Fact]
        public void Window_Equals_WithSameWindow_ReturnsTrue()
        {
            IntPtr handle = new IntPtr(12345);
            Window window1 = new Window(handle);
            Window window2 = new Window(handle);

            bool result = window1.Equals(window2);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that window equals with object returns correct result
        /// </summary>
        [Fact]
        public void Window_Equals_WithObject_ReturnsCorrectResult()
        {
            IntPtr handle = new IntPtr(12345);
            Window window = new Window(handle);
            object obj = new Window(handle);

            bool result = window.Equals(obj);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that window equals with non window object returns false
        /// </summary>
        [Fact]
        public void Window_Equals_WithNonWindowObject_ReturnsFalse()
        {
            Window window = Window.None;
            object obj = new object();

            bool result = window.Equals(obj);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that window get hash code returns same for equal windows
        /// </summary>
        [Fact]
        public void Window_GetHashCode_ReturnsSameForEqualWindows()
        {
            IntPtr handle = new IntPtr(12345);
            Window window1 = new Window(handle);
            Window window2 = new Window(handle);

            int hash1 = window1.GetHashCode();
            int hash2 = window2.GetHashCode();

            Assert.Equal(hash1, hash2);
        }

        /// <summary>
        ///     Tests that window equality operator with same windows returns true
        /// </summary>
        [Fact]
        public void Window_EqualityOperator_WithSameWindows_ReturnsTrue()
        {
            IntPtr handle = new IntPtr(12345);
            Window window1 = new Window(handle);
            Window window2 = new Window(handle);

            bool result = window1 == window2;

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that window inequality operator with different windows returns true
        /// </summary>
        [Fact]
        public void Window_InequalityOperator_WithDifferentWindows_ReturnsTrue()
        {
            Window window1 = new Window(new IntPtr(123));
            Window window2 = new Window(new IntPtr(456));

            bool result = window1 != window2;

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that window equals with i equatable interface works
        /// </summary>
        [Fact]
        public void Window_Equals_WithIEquatableInterface_Works()
        {
            IntPtr handle = new IntPtr(12345);
            Window window1 = new Window(handle);
            IEquatable<Window> window2 = new Window(handle);

            bool result = window1.Equals(window2);

            Assert.True(result);
        }
    }
}