// license header
using Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    public class SfmlTextTest
    {
        [Fact]
        public void SfmlText_IsAssignableFromTransformable()
        {
            Assert.True(typeof(Transformable).IsAssignableFrom(typeof(SfmlText)));
        }

        [Fact]
        public void SfmlText_ImplementsIDrawable()
        {
            Assert.True(typeof(IDrawable).IsAssignableFrom(typeof(SfmlText)));
        }

        [Fact]
        public void FillColor_OutlineColor_Properties_Exist()
        {
            Assert.NotNull(typeof(SfmlText).GetProperty("FillColor"));
            Assert.NotNull(typeof(SfmlText).GetProperty("OutlineColor"));
        }

        [Fact]
        public void OutlineThickness_DisplayedString_Properties_Exist()
        {
            Assert.NotNull(typeof(SfmlText).GetProperty("OutlineThickness"));
            Assert.NotNull(typeof(SfmlText).GetProperty("DisplayedString"));
        }

        [Fact]
        public void Font_CharacterSize_Properties_Exist()
        {
            Assert.NotNull(typeof(SfmlText).GetProperty("Font"));
            Assert.NotNull(typeof(SfmlText).GetProperty("CharacterSize"));
        }

        [Fact]
        public void LetterSpacing_LineSpacing_Properties_Exist()
        {
            Assert.NotNull(typeof(SfmlText).GetProperty("LetterSpacing"));
            Assert.NotNull(typeof(SfmlText).GetProperty("LineSpacing"));
        }

        [Fact]
        public void Style_Property_Exists()
        {
            Assert.NotNull(typeof(SfmlText).GetProperty("Style"));
        }

        [Fact]
        public void FindCharacterPos_GetLocalBounds_GetGlobalBounds_Methods_Exist()
        {
            Assert.NotNull(typeof(SfmlText).GetMethod("FindCharacterPos"));
            Assert.NotNull(typeof(SfmlText).GetMethod("GetLocalBounds"));
            Assert.NotNull(typeof(SfmlText).GetMethod("GetGlobalBounds"));
        }
    }
}
