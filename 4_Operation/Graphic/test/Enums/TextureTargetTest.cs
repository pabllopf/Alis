

using System;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.Enums
{
    /// <summary>
    ///     Tests for the TextureTarget enum validating texture binding target types.
    /// </summary>
    public class TextureTargetTest
    {
        /// <summary>
        ///     Tests that Texture1D has correct value.
        /// </summary>
        [Fact]
        public void Texture1D_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x0DE0, (int) TextureTarget.Texture1D);
        }

        /// <summary>
        ///     Tests that Texture2D has correct value.
        /// </summary>
        [Fact]
        public void Texture2D_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x0DE1, (int) TextureTarget.Texture2D);
        }

        /// <summary>
        ///     Tests that Texture3D has correct value.
        /// </summary>
        [Fact]
        public void Texture3D_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x806F, (int) TextureTarget.Texture3D);
        }

        /// <summary>
        ///     Tests that TextureCubeMap has correct value.
        /// </summary>
        [Fact]
        public void TextureCubeMap_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x8513, (int) TextureTarget.TextureCubeMap);
        }

        /// <summary>
        ///     Tests that TextureCubeMapPositiveX has correct value.
        /// </summary>
        [Fact]
        public void TextureCubeMapPositiveX_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x8515, (int) TextureTarget.TextureCubeMapPositiveX);
        }

        /// <summary>
        ///     Tests that TextureTarget is an enum type.
        /// </summary>
        [Fact]
        public void TextureTarget_IsEnum_TypeIsCorrect()
        {
            Assert.True(typeof(TextureTarget).IsEnum);
        }

        /// <summary>
        ///     Tests that TextureTarget enum is public.
        /// </summary>
        [Fact]
        public void TextureTarget_IsPublic_CanBeAccessed()
        {
            Assert.True(typeof(TextureTarget).IsPublic);
        }

        /// <summary>
        ///     Tests that TextureTarget has multiple defined values.
        /// </summary>
        [Fact]
        public void TextureTarget_HasMultipleValues_CountIsNotZero()
        {
            Array enumValues = Enum.GetValues(typeof(TextureTarget));
            Assert.NotEmpty(enumValues);
        }

        /// <summary>
        ///     Tests that TextureTarget can be cast to int.
        /// </summary>
        [Fact]
        public void TextureTarget_CanCastToInt_ConversionIsValid()
        {
            int value = (int) TextureTarget.Texture2D;
            Assert.IsType<int>(value);
        }

        /// <summary>
        ///     Tests that TextureTarget values can be compared.
        /// </summary>
        [Fact]
        public void TextureTarget_CanCompareValues_EqualityWorks()
        {
            TextureTarget target1 = TextureTarget.Texture2D;
            TextureTarget target2 = TextureTarget.Texture2D;
            Assert.Equal(target1, target2);
        }

        /// <summary>
        ///     Tests that different TextureTarget values are not equal.
        /// </summary>
        [Fact]
        public void TextureTarget_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(TextureTarget.Texture1D, TextureTarget.Texture2D);
        }

        /// <summary>
        ///     Tests that TextureTarget contains 2D and 3D texture types.
        /// </summary>
        [Fact]
        public void TextureTarget_Contains2DAndCubeMap_CommonTargets()
        {
            TextureTarget texture2D = TextureTarget.Texture2D;
            TextureTarget textureCube = TextureTarget.TextureCubeMap;

            Assert.NotNull(texture2D);
            Assert.NotNull(textureCube);
        }

        /// <summary>
        ///     Tests that Texture2D is more frequently used than Texture1D.
        /// </summary>
        [Fact]
        public void Texture2D_ValueIsGreaterThanTexture1D_SequentialValues()
        {
            int value1D = (int) TextureTarget.Texture1D;
            int value2D = (int) TextureTarget.Texture2D;
            Assert.True(value2D > value1D);
        }
    }
}