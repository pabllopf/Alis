

using System;
using Alis.Extension.Graphic.Glfw.Enums;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Enums
{
    /// <summary>
    ///     Tests for CursorMode enum
    /// </summary>
    public class CursorModeEnumTests
    {
        /// <summary>
        ///     Tests that cursor mode normal is defined
        /// </summary>
        [Fact]
        public void CursorMode_Normal_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(CursorMode), CursorMode.Normal);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that cursor mode hidden is defined
        /// </summary>
        [Fact]
        public void CursorMode_Hidden_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(CursorMode), CursorMode.Hidden);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that cursor mode disabled is defined
        /// </summary>
        [Fact]
        public void CursorMode_Disabled_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(CursorMode), CursorMode.Disabled);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that cursor mode can be cast to int
        /// </summary>
        [Fact]
        public void CursorMode_CanBeCastToInt()
        {
            CursorMode mode = CursorMode.Normal;

            int value = (int) mode;

            Assert.True(value >= 0);
        }

        /// <summary>
        ///     Tests that cursor mode all modes are different
        /// </summary>
        [Fact]
        public void CursorMode_AllModes_AreDifferent()
        {
            Assert.NotEqual(CursorMode.Normal, CursorMode.Hidden);
            Assert.NotEqual(CursorMode.Normal, CursorMode.Disabled);
            Assert.NotEqual(CursorMode.Hidden, CursorMode.Disabled);
        }
    }
}