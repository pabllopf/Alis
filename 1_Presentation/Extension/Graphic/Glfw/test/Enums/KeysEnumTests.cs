

using System;
using Alis.Extension.Graphic.Glfw.Enums;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Enums
{
    /// <summary>
    ///     Tests for Keys enum
    /// </summary>
    public class KeysEnumTests
    {
        /// <summary>
        ///     Tests that keys unknown has correct value
        /// </summary>
        [Fact]
        public void Keys_Unknown_HasCorrectValue()
        {
            Assert.Equal(-1, (int) Keys.Unknown);
        }

        /// <summary>
        ///     Tests that keys space has correct value
        /// </summary>
        [Fact]
        public void Keys_Space_HasCorrectValue()
        {
            Assert.Equal(32, (int) Keys.Space);
        }

        /// <summary>
        ///     Tests that keys a is defined
        /// </summary>
        [Fact]
        public void Keys_A_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(Keys), Keys.A);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that keys escape is defined
        /// </summary>
        [Fact]
        public void Keys_Escape_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(Keys), Keys.Escape);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that keys enter is defined
        /// </summary>
        [Fact]
        public void Keys_Enter_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(Keys), Keys.Enter);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that keys can be cast to int
        /// </summary>
        [Fact]
        public void Keys_CanBeCastToInt()
        {
            Keys key = Keys.A;

            int value = (int) key;

            Assert.True(value > 0);
        }

        /// <summary>
        ///     Tests that keys can be cast from int
        /// </summary>
        [Fact]
        public void Keys_CanBeCastFromInt()
        {
            int value = 32;

            Keys key = (Keys) value;

            Assert.Equal(Keys.Space, key);
        }

        /// <summary>
        ///     Tests that keys all alpha keys are defined
        /// </summary>
        [Fact]
        public void Keys_AllAlphaKeys_AreDefined()
        {
            Assert.True(Enum.IsDefined(typeof(Keys), Keys.A));
            Assert.True(Enum.IsDefined(typeof(Keys), Keys.Z));
        }

        /// <summary>
        ///     Tests that keys all numeric keys are defined
        /// </summary>
        [Fact]
        public void Keys_AllNumericKeys_AreDefined()
        {
            Assert.True(Enum.IsDefined(typeof(Keys), Keys.Alpha0));
            Assert.True(Enum.IsDefined(typeof(Keys), Keys.Alpha9));
        }

        /// <summary>
        ///     Tests that keys function keys are defined
        /// </summary>
        [Fact]
        public void Keys_FunctionKeys_AreDefined()
        {
            Assert.True(Enum.IsDefined(typeof(Keys), Keys.F1));
            Assert.True(Enum.IsDefined(typeof(Keys), Keys.F12));
        }
    }
}