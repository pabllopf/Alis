// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LangTest.cs
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

using Alis.Extension.Language.Translator.Abstractions;
using Xunit;

namespace Alis.Extension.Language.Translator.Test
{
    public class LangTest
    {
        [Fact]
        public void Constructor_Default_SetsIsDefaultFalse()
        {
            Lang lang = new Lang();

            Assert.False(lang.IsDefault);
        }

        [Fact]
        public void Constructor_CodeAndName_SetsProperties()
        {
            Lang lang = new Lang("en", "English");

            Assert.Equal("en", lang.Code);
            Assert.Equal("English", lang.Name);
            Assert.False(lang.IsDefault);
        }

        [Fact]
        public void Constructor_Full_SetsAllProperties()
        {
            Lang lang = new Lang("es", "Spanish", "Español", "es-ES", true);

            Assert.Equal("es", lang.Code);
            Assert.Equal("Spanish", lang.Name);
            Assert.Equal("Español", lang.NativeName);
            Assert.Equal("es-ES", lang.CultureCode);
            Assert.True(lang.IsDefault);
        }

        [Fact]
        public void Constructor_Full_DefaultFalseByDefault()
        {
            Lang lang = new Lang("fr", "French", "Français", "fr-FR");

            Assert.False(lang.IsDefault);
        }

        [Fact]
        public void Properties_CanBeSetAndRead()
        {
            Lang lang = new Lang();

            lang.Code = "de";
            lang.Name = "German";
            lang.NativeName = "Deutsch";
            lang.CultureCode = "de-DE";
            lang.IsDefault = true;

            Assert.Equal("de", lang.Code);
            Assert.Equal("German", lang.Name);
            Assert.Equal("Deutsch", lang.NativeName);
            Assert.Equal("de-DE", lang.CultureCode);
            Assert.True(lang.IsDefault);
        }

        [Fact]
        public void Equals_SameValues_ReturnsTrue()
        {
            Lang a = new Lang("en", "English");
            Lang b = new Lang("en", "English");

            Assert.True(a.Equals(b));
        }

        [Fact]
        public void Equals_DifferentCode_ReturnsFalse()
        {
            Lang a = new Lang("en", "English");
            Lang b = new Lang("es", "English");

            Assert.False(a.Equals(b));
        }

        [Fact]
        public void Equals_DifferentName_ReturnsFalse()
        {
            Lang a = new Lang("en", "English");
            Lang b = new Lang("en", "Inglés");

            Assert.False(a.Equals(b));
        }

        [Fact]
        public void Equals_Null_ReturnsFalse()
        {
            Lang lang = new Lang("en", "English");

            Assert.False(lang.Equals(default(ILanguage)));
        }

        [Fact]
        public void Equals_Object_SameValues_ReturnsTrue()
        {
            Lang a = new Lang("en", "English");
            object b = new Lang("en", "English");

            Assert.True(a.Equals(b));
        }

        [Fact]
        public void Equals_Object_Null_ReturnsFalse()
        {
            Lang lang = new Lang("en", "English");

            Assert.False(lang.Equals((object)null));
        }

        [Fact]
        public void Equals_Object_WrongType_ReturnsFalse()
        {
            Lang lang = new Lang("en", "English");

            Assert.False(lang.Equals("not a lang"));
        }

        [Fact]
        public void GetHashCode_SameValues_ReturnsSame()
        {
            Lang a = new Lang("en", "English");
            Lang b = new Lang("en", "English");

            Assert.Equal(a.GetHashCode(), b.GetHashCode());
        }

        [Fact]
        public void GetHashCode_DifferentValues_ReturnsDifferent()
        {
            Lang a = new Lang("en", "English");
            Lang b = new Lang("es", "Spanish");

            Assert.NotEqual(a.GetHashCode(), b.GetHashCode());
        }

        [Fact]
        public void GetHashCode_NullCodeAndName_DoesNotThrow()
        {
            Lang lang = new Lang();

            int hash = lang.GetHashCode();

            Assert.Equal(0, hash);
        }

        [Fact]
        public void ToString_ReturnsFormatted()
        {
            Lang lang = new Lang("en", "English");

            string result = lang.ToString();

            Assert.Equal("en - English", result);
        }

        [Fact]
        public void Equals_SameReference_ReturnsTrue()
        {
            Lang lang = new Lang("en", "English");

            Assert.True(lang.Equals(lang));
        }
    }
}
