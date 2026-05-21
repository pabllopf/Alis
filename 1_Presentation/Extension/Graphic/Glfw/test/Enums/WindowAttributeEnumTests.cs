

using System;
using Alis.Extension.Graphic.Glfw.Enums;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Enums
{
    /// <summary>
    ///     Tests for WindowAttribute enum
    /// </summary>
    public class WindowAttributeEnumTests
    {
        /// <summary>
        ///     Tests that window attribute focused is defined
        /// </summary>
        [Fact]
        public void WindowAttribute_Focused_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(WindowAttribute), WindowAttribute.Focused);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that window attribute resizable is defined
        /// </summary>
        [Fact]
        public void WindowAttribute_Resizable_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(WindowAttribute), WindowAttribute.Resizable);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that window attribute visible is defined
        /// </summary>
        [Fact]
        public void WindowAttribute_Visible_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(WindowAttribute), WindowAttribute.Visible);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that window attribute decorated is defined
        /// </summary>
        [Fact]
        public void WindowAttribute_Decorated_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(WindowAttribute), WindowAttribute.Decorated);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that window attribute auto iconify is defined
        /// </summary>
        [Fact]
        public void WindowAttribute_AutoIconify_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(WindowAttribute), WindowAttribute.AutoIconify);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that window attribute floating is defined
        /// </summary>
        [Fact]
        public void WindowAttribute_Floating_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(WindowAttribute), WindowAttribute.Floating);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that window attribute maximized is defined
        /// </summary>
        [Fact]
        public void WindowAttribute_Maximized_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(WindowAttribute), WindowAttribute.Maximized);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that window attribute can be cast to int
        /// </summary>
        [Fact]
        public void WindowAttribute_CanBeCastToInt()
        {
            WindowAttribute attribute = WindowAttribute.Visible;

            int value = (int) attribute;

            Assert.True(value != 0);
        }

        /// <summary>
        ///     Tests that window attribute can be cast from int
        /// </summary>
        [Fact]
        public void WindowAttribute_CanBeCastFromInt()
        {
            int value = (int) WindowAttribute.Visible;

            WindowAttribute attribute = (WindowAttribute) value;

            Assert.Equal(WindowAttribute.Visible, attribute);
        }
    }
}