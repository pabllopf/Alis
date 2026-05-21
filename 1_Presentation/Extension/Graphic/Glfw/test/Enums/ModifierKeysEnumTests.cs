

using System;
using Alis.Extension.Graphic.Glfw.Enums;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Enums
{
    /// <summary>
    ///     Tests for ModifierKeys enum
    /// </summary>
    public class ModifierKeysEnumTests
    {
        /// <summary>
        ///     Tests that modifier keys none is defined
        /// </summary>
        [Fact]
        public void ModifierKeys_None_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(ModifierKeys), ModifierKeys.None);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that modifier keys shift is defined
        /// </summary>
        [Fact]
        public void ModifierKeys_Shift_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(ModifierKeys), ModifierKeys.Shift);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that modifier keys control is defined
        /// </summary>
        [Fact]
        public void ModifierKeys_Control_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(ModifierKeys), ModifierKeys.Control);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that modifier keys alt is defined
        /// </summary>
        [Fact]
        public void ModifierKeys_Alt_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(ModifierKeys), ModifierKeys.Alt);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that modifier keys super is defined
        /// </summary>
        [Fact]
        public void ModifierKeys_Super_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(ModifierKeys), ModifierKeys.Super);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that modifier keys can be combined with bitwise or
        /// </summary>
        [Fact]
        public void ModifierKeys_CanBeCombinedWithBitwiseOr()
        {
            ModifierKeys combined = ModifierKeys.Shift | ModifierKeys.Control;

            Assert.NotEqual(ModifierKeys.None, combined);
            Assert.True((combined & ModifierKeys.Shift) == ModifierKeys.Shift);
            Assert.True((combined & ModifierKeys.Control) == ModifierKeys.Control);
        }

        /// <summary>
        ///     Tests that modifier keys can be checked with bitwise and
        /// </summary>
        [Fact]
        public void ModifierKeys_CanBeCheckedWithBitwiseAnd()
        {
            ModifierKeys modifiers = ModifierKeys.Shift | ModifierKeys.Control;

            bool hasShift = (modifiers & ModifierKeys.Shift) == ModifierKeys.Shift;
            bool hasAlt = (modifiers & ModifierKeys.Alt) == ModifierKeys.Alt;

            Assert.True(hasShift);
            Assert.False(hasAlt);
        }

        /// <summary>
        ///     Tests that modifier keys none has zero value
        /// </summary>
        [Fact]
        public void ModifierKeys_None_HasZeroValue()
        {
            Assert.Equal(0, (int) ModifierKeys.None);
        }

        /// <summary>
        ///     Tests that modifier keys can be cast to int
        /// </summary>
        [Fact]
        public void ModifierKeys_CanBeCastToInt()
        {
            ModifierKeys modifier = ModifierKeys.Shift;

            int value = (int) modifier;

            Assert.True(value > 0);
        }

        /// <summary>
        ///     Tests that modifier keys all modifiers are different
        /// </summary>
        [Fact]
        public void ModifierKeys_AllModifiers_AreDifferent()
        {
            Assert.NotEqual(ModifierKeys.Shift, ModifierKeys.Control);
            Assert.NotEqual(ModifierKeys.Shift, ModifierKeys.Alt);
            Assert.NotEqual(ModifierKeys.Control, ModifierKeys.Alt);
        }
    }
}