

using System;
using Alis.Extension.Graphic.Glfw.Enums;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Enums
{
    /// <summary>
    ///     Tests for CursorType enum
    /// </summary>
    public class CursorTypeEnumTests
    {
        /// <summary>
        ///     Tests that cursor type arrow is defined
        /// </summary>
        [Fact]
        public void CursorType_Arrow_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(CursorType), CursorType.Arrow));
        }

        /// <summary>
        ///     Tests that cursor type i beam is defined
        /// </summary>
        [Fact]
        public void CursorType_IBeam_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(CursorType), CursorType.Beam));
        }

        /// <summary>
        ///     Tests that cursor type crosshair is defined
        /// </summary>
        [Fact]
        public void CursorType_Crosshair_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(CursorType), CursorType.Crosshair));
        }

        /// <summary>
        ///     Tests that cursor type hand is defined
        /// </summary>
        [Fact]
        public void CursorType_Hand_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(CursorType), CursorType.Hand));
        }

        /// <summary>
        ///     Tests that cursor type can be cast to int
        /// </summary>
        [Fact]
        public void CursorType_CanBeCastToInt()
        {
            CursorType type = CursorType.Arrow;
            int value = (int) type;
            Assert.True(value != 0);
        }
    }
}