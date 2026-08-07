// license header
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The sfml text test class
    /// </summary>
    public class SfmlTextTest
    {
        /// <summary>
        /// Tests that sfml text is assignable from transformable
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SfmlText_IsAssignableFromTransformable()
        {
            Assert.True(typeof(Transformable).IsAssignableFrom(typeof(SfmlText)));
        }

        /// <summary>
        /// Tests that sfml text implements i drawable
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SfmlText_ImplementsIDrawable()
        {
            Assert.True(typeof(IDrawable).IsAssignableFrom(typeof(SfmlText)));
        }

        /// <summary>
        /// Tests that fill color outline color properties exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void FillColor_OutlineColor_Properties_Exist()
        {
            Assert.NotNull(typeof(SfmlText).GetProperty("FillColor"));
            Assert.NotNull(typeof(SfmlText).GetProperty("OutlineColor"));
        }

        /// <summary>
        /// Tests that outline thickness displayed string properties exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void OutlineThickness_DisplayedString_Properties_Exist()
        {
            Assert.NotNull(typeof(SfmlText).GetProperty("OutlineThickness"));
            Assert.NotNull(typeof(SfmlText).GetProperty("DisplayedString"));
        }

        /// <summary>
        /// Tests that font character size properties exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Font_CharacterSize_Properties_Exist()
        {
            Assert.NotNull(typeof(SfmlText).GetProperty("Font"));
            Assert.NotNull(typeof(SfmlText).GetProperty("CharacterSize"));
        }

        /// <summary>
        /// Tests that letter spacing line spacing properties exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void LetterSpacing_LineSpacing_Properties_Exist()
        {
            Assert.NotNull(typeof(SfmlText).GetProperty("LetterSpacing"));
            Assert.NotNull(typeof(SfmlText).GetProperty("LineSpacing"));
        }

        /// <summary>
        /// Tests that style property exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Style_Property_Exists()
        {
            Assert.NotNull(typeof(SfmlText).GetProperty("Style"));
        }

        /// <summary>
        /// Tests that find character pos get local bounds get global bounds methods exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void FindCharacterPos_GetLocalBounds_GetGlobalBounds_Methods_Exist()
        {
            Assert.NotNull(typeof(SfmlText).GetMethod("FindCharacterPos"));
            Assert.NotNull(typeof(SfmlText).GetMethod("GetLocalBounds"));
            Assert.NotNull(typeof(SfmlText).GetMethod("GetGlobalBounds"));
        }
    }
}
