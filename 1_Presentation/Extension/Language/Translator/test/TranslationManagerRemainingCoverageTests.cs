// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TranslationManagerRemainingCoverageTests.cs
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

using Xunit;

namespace Alis.Extension.Language.Translator.Test
{
    /// <summary>
    /// The translation manager remaining coverage tests class
    /// </summary>
    public class TranslationManagerRemainingCoverageTests
    {
        /// <summary>
        /// Tests that translate with fallback containing current language should skip same code
        /// </summary>
        [Fact]
        public void Translate_WithFallbackContainingCurrentLanguage_ShouldSkipSameCode()
        {
            TranslationManager mgr = new TranslationManager();
            mgr.AddLanguage("English", "en");
            mgr.AddLanguage("Spanish", "es");
            mgr.SetLanguage("en");
            mgr.AddTranslation("es", "greeting", "Hola");
            mgr.SetFallbackLanguages("en", "es");

            string result = mgr.Translate("greeting");

            Assert.Equal("Hola", result);
        }

        /// <summary>
        /// Tests that translate with fallback returning null should try next fallback
        /// </summary>
        [Fact]
        public void Translate_WithFallbackReturningNull_ShouldTryNextFallback()
        {
            TranslationManager mgr = new TranslationManager();
            mgr.AddLanguage("English", "en");
            mgr.AddLanguage("French", "fr");
            mgr.AddLanguage("Spanish", "es");
            mgr.SetLanguage("en");
            mgr.AddTranslation("fr", "greeting", "Bonjour");
            mgr.SetFallbackLanguages("es", "fr");

            string result = mgr.Translate("greeting");

            Assert.Equal("Bonjour", result);
        }

        /// <summary>
        /// Tests that set fallback languages with empty array should not throw
        /// </summary>
        [Fact]
        public void SetFallbackLanguages_WithEmptyArray_ShouldNotThrow()
        {
            TranslationManager mgr = new TranslationManager();

            mgr.SetFallbackLanguages();
        }

        /// <summary>
        /// Tests that set fallback languages with mixed valid and invalid codes should filter invalid
        /// </summary>
        [Fact]
        public void SetFallbackLanguages_WithMixedValidAndInvalidCodes_ShouldFilterInvalid()
        {
            TranslationManager mgr = new TranslationManager();
            mgr.AddLanguage("English", "en");
            mgr.AddLanguage("Spanish", "es");
            mgr.SetLanguage("en");
            mgr.AddTranslation("es", "greeting", "Hola");

            mgr.SetFallbackLanguages(null, "", "es", "  ");

            string result = mgr.Translate("greeting");
            Assert.Equal("Hola", result);
        }

        /// <summary>
        /// Tests that add translation with valid language object should add translation
        /// </summary>
        [Fact]
        public void AddTranslation_WithValidLanguageObject_ShouldAddTranslation()
        {
            TranslationManager mgr = new TranslationManager();
            Lang lang = new Lang("en", "English");
            mgr.AddLanguage(lang);
            mgr.SetLanguage(lang);

            mgr.AddTranslation(lang, "key", "value");

            Assert.Equal("value", mgr.Translate("key"));
        }

        /// <summary>
        /// Tests that add language with valid name and code should add language
        /// </summary>
        [Fact]
        public void AddLanguage_WithValidNameAndCode_ShouldAddLanguage()
        {
            TranslationManager mgr = new TranslationManager();

            mgr.AddLanguage("German", "de");

            Assert.NotNull(mgr.GetAvailableLanguages());
            Assert.Contains(mgr.GetAvailableLanguages(), l => l.Code == "de");
        }
    }
}
