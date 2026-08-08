// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SfmlTextTests.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Moq;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The sfml text tests class
    /// </summary>
    public class SfmlTextTests
    {
        /// <summary>
        /// Tests that constructor default sets empty string null font size 30
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_Default_SetsEmptyStringNullFontSize30()
        {
            using SfmlText text = new SfmlText();
            Assert.Equal("", text.DisplayedString);
            Assert.Null(text.Font);
            Assert.Equal(30u, text.CharacterSize);
        }

        /// <summary>
        /// Tests that constructor string and font sets displayed string and font and size 30
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_StringAndFont_SetsDisplayedStringAndFontAndSize30()
        {
            using SfmlText text = new SfmlText("Hello", null);
            Assert.Equal("Hello", text.DisplayedString);
            Assert.Null(text.Font);
            Assert.Equal(30u, text.CharacterSize);
        }

        /// <summary>
        /// Tests that constructor string font size sets all properties
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_StringFontSize_SetsAllProperties()
        {
            using SfmlText text = new SfmlText("Test", null, 42);
            Assert.Equal("Test", text.DisplayedString);
            Assert.Null(text.Font);
            Assert.Equal(42u, text.CharacterSize);
        }

        /// <summary>
        /// Tests that constructor copy copies all properties
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_Copy_CopiesAllProperties()
        {
            using SfmlText original = new SfmlText("Copy", null, 20);
            using SfmlText copy = new SfmlText(original);
            Assert.Equal(original.DisplayedString, copy.DisplayedString);
            Assert.Equal(original.CharacterSize, copy.CharacterSize);
            Assert.Equal(original.Font, copy.Font);
        }

        /// <summary>
        /// Tests that fill color get set returns expected
        /// </summary>
        [RequireCSfmlSystemFact]
        public void FillColor_GetSet_ReturnsExpected()
        {
            using SfmlText text = new SfmlText();
            Color color = new Color(255, 128, 64, 32);
            text.FillColor = color;
            Assert.Equal(color, text.FillColor);
        }

        /// <summary>
        /// Tests that outline color get set returns expected
        /// </summary>
        [RequireCSfmlSystemFact]
        public void OutlineColor_GetSet_ReturnsExpected()
        {
            using SfmlText text = new SfmlText();
            Color color = new Color(10, 20, 30, 40);
            text.OutlineColor = color;
            Assert.Equal(color, text.OutlineColor);
        }

        /// <summary>
        /// Tests that outline thickness get set returns expected
        /// </summary>
        [RequireCSfmlSystemFact]
        public void OutlineThickness_GetSet_ReturnsExpected()
        {
            using SfmlText text = new SfmlText();
            text.OutlineThickness = 2.5f;
            Assert.Equal(2.5f, text.OutlineThickness, 5);
        }

        /// <summary>
        /// Tests that displayed string get set roundtrips
        /// </summary>
        [RequireCSfmlSystemFact]
        public void DisplayedString_GetSet_Roundtrips()
        {
            using SfmlText text = new SfmlText();
            text.DisplayedString = "Hello World";
            Assert.Equal("Hello World", text.DisplayedString);
        }

        /// <summary>
        /// Tests that displayed string get set with unicode chars
        /// </summary>
        [RequireCSfmlSystemFact]
        public void DisplayedString_GetSet_WithUnicodeChars()
        {
            using SfmlText text = new SfmlText();
            text.DisplayedString = "äöüñçé";
            Assert.Equal("äöüñçé", text.DisplayedString);
        }

        /// <summary>
        /// Tests that displayed string get set empty string
        /// </summary>
        [RequireCSfmlSystemFact]
        public void DisplayedString_GetSet_EmptyString()
        {
            using SfmlText text = new SfmlText();
            text.DisplayedString = "";
            Assert.Equal("", text.DisplayedString);
        }

        /// <summary>
        /// Tests that font get set roundtrips
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Font_GetSet_Roundtrips()
        {
            using SfmlText text = new SfmlText();
            Assert.Null(text.Font);
            text.Font = null;
            Assert.Null(text.Font);
        }

        /// <summary>
        /// Tests that character size get set returns expected
        /// </summary>
        [RequireCSfmlSystemFact]
        public void CharacterSize_GetSet_ReturnsExpected()
        {
            using SfmlText text = new SfmlText();
            text.CharacterSize = 64;
            Assert.Equal(64u, text.CharacterSize);
        }

        /// <summary>
        /// Tests that character size get set zero
        /// </summary>
        [RequireCSfmlSystemFact]
        public void CharacterSize_GetSet_Zero()
        {
            using SfmlText text = new SfmlText();
            text.CharacterSize = 0;
            Assert.Equal(0u, text.CharacterSize);
        }

        /// <summary>
        /// Tests that letter spacing get set returns expected
        /// </summary>
        [RequireCSfmlSystemFact]
        public void LetterSpacing_GetSet_ReturnsExpected()
        {
            using SfmlText text = new SfmlText();
            text.LetterSpacing = 1.5f;
            Assert.Equal(1.5f, text.LetterSpacing, 5);
        }

        /// <summary>
        /// Tests that letter spacing get set default
        /// </summary>
        [RequireCSfmlSystemFact]
        public void LetterSpacing_GetSet_Default()
        {
            using SfmlText text = new SfmlText();
            Assert.Equal(1.0f, text.LetterSpacing, 5);
        }

        /// <summary>
        /// Tests that line spacing get set returns expected
        /// </summary>
        [RequireCSfmlSystemFact]
        public void LineSpacing_GetSet_ReturnsExpected()
        {
            using SfmlText text = new SfmlText();
            text.LineSpacing = 2.0f;
            Assert.Equal(2.0f, text.LineSpacing, 5);
        }

        /// <summary>
        /// Tests that line spacing get set default
        /// </summary>
        [RequireCSfmlSystemFact]
        public void LineSpacing_GetSet_Default()
        {
            using SfmlText text = new SfmlText();
            Assert.Equal(1.0f, text.LineSpacing, 5);
        }

        /// <summary>
        /// Tests that style get set returns expected
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Style_GetSet_ReturnsExpected()
        {
            using SfmlText text = new SfmlText();
            text.Style = Styles.Bold | Styles.Italic;
            Assert.Equal(Styles.Bold | Styles.Italic, text.Style);
        }

        /// <summary>
        /// Tests that style get set none
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Style_GetSet_None()
        {
            using SfmlText text = new SfmlText();
            text.Style = Styles.None;
            Assert.Equal(Styles.None, text.Style);
        }

        /// <summary>
        /// Tests that style get set all flags
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Style_GetSet_AllFlags()
        {
            using SfmlText text = new SfmlText();
            Styles all = Styles.Bold | Styles.Italic | Styles.Underlined | Styles.StrikeThrough;
            text.Style = all;
            Assert.Equal(all, text.Style);
        }

        /// <summary>
        /// Tests that to string contains all components
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ToString_ContainsAllComponents()
        {
            using SfmlText text = new SfmlText();
            string str = text.ToString();
            Assert.StartsWith("[Text]", str);
            Assert.Contains("FillColor", str);
            Assert.Contains("OutlineColor", str);
            Assert.Contains("String", str);
            Assert.Contains("Font", str);
            Assert.Contains("CharacterSize", str);
            Assert.Contains("OutlineThickness", str);
            Assert.Contains("Style", str);
        }

        /// <summary>
        /// Tests that draw with mock target does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Draw_WithMockTarget_DoesNotThrow()
        {
            using SfmlText text = new SfmlText("Draw", null);
            Mock<IRenderTarget> mockTarget = new Mock<IRenderTarget>();
            RenderStates states = new RenderStates();
            text.Draw(mockTarget.Object, states);
        }

        /// <summary>
        /// Tests that draw updates transform
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Draw_UpdatesTransform()
        {
            using SfmlText text = new SfmlText("Draw", null);
            text.Position = new Vector2F(10, 20);
            Mock<IRenderTarget> mockTarget = new Mock<IRenderTarget>();
            RenderStates states = new RenderStates();
            text.Draw(mockTarget.Object, states);
        }

        /// <summary>
        /// Tests that destroy sets c pointer to zero
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_SetsCPointerToZero()
        {
            SfmlText text = new SfmlText();
            Assert.NotEqual(System.IntPtr.Zero, text.CPointer);
            text.Destroy(true);
            Assert.Equal(System.IntPtr.Zero, text.CPointer);
        }

        /// <summary>
        /// Tests that dispose calls destroy
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Dispose_CallsDestroy()
        {
            SfmlText text = new SfmlText();
            text.Dispose();
            Assert.Equal(System.IntPtr.Zero, text.CPointer);
        }

        /// <summary>
        /// Tests that constructor default dispose does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_Default_Dispose_DoesNotThrow()
        {
            SfmlText text = new SfmlText();
            text.Dispose();
        }

        /// <summary>
        /// Tests that position and rotation affects transform
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Position_AndRotation_AffectsTransform()
        {
            using SfmlText text = new SfmlText("Test", null);
            text.Position = new Vector2F(100, 200);
            text.Rotation = 45;
            Vector2F pos = text.Position;
            Assert.Equal(100, pos.X);
            Assert.Equal(200, pos.Y);
            Assert.Equal(45, text.Rotation);
        }
    }
}
