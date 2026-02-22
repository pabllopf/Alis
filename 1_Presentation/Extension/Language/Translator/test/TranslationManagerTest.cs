// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TranslationManagerTest.cs
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

using System;
using System.Collections.Generic;
using Xunit;

namespace Alis.Extension.Language.Translator.Test
{
    /// <summary>
    ///     The translation manager test class
    /// </summary>
    public class TranslationManagerTest
    {
        /// <summary>
        ///     Tests that SetLanguage with valid language should set current language
        /// </summary>
        [Fact]
        public void SetLanguage_WithValidLanguage_ShouldSetCurrentLanguage()
        {
            // Arrange
            var translationManager = new TranslationManager();
            var lang = new Lang("en", "English");

            // Act
            translationManager.SetLanguage(lang);

            // Assert
            Assert.Equal(lang, translationManager.Lang);
        }

        /// <summary>
        ///     Tests that SetLanguage with null language should throw exception
        /// </summary>
        [Fact]
        public void SetLanguage_WithNullLanguage_ShouldThrowException()
        {
            // Arrange
            var translationManager = new TranslationManager();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => translationManager.SetLanguage((ILanguage)null));
        }

        /// <summary>
        ///     Tests that SetLanguage with name and code should set language
        /// </summary>
        [Fact]
        public void SetLanguage_WithNameAndCode_ShouldSetLanguage()
        {
            // Arrange
            var translationManager = new TranslationManager();

            // Act
            translationManager.SetLanguage("English", "en");

            // Assert
            Assert.NotNull(translationManager.Lang);
            Assert.Equal("en", translationManager.Lang.Code);
            Assert.Equal("English", translationManager.Lang.Name);
        }

        /// <summary>
        ///     Tests that AddLanguage with valid language should add language
        /// </summary>
        [Fact]
        public void AddLanguage_WithValidLanguage_ShouldAddLanguage()
        {
            // Arrange
            var translationManager = new TranslationManager();
            var lang = new Lang("es", "Spanish");

            // Act
            translationManager.AddLanguage(lang);

            // Assert
            Assert.Contains(lang, translationManager.GetAvailableLanguages());
        }

        /// <summary>
        ///     Tests that AddLanguage with null language should throw exception
        /// </summary>
        [Fact]
        public void AddLanguage_WithNullLanguage_ShouldThrowException()
        {
            // Arrange
            var translationManager = new TranslationManager();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => translationManager.AddLanguage((ILanguage)null));
        }

        /// <summary>
        ///     Tests that AddTranslation should add translation for current language
        /// </summary>
        [Fact]
        public void AddTranslation_ShouldAddTranslationForCurrentLanguage()
        {
            // Arrange
            var translationManager = new TranslationManager();
            translationManager.SetLanguage("English", "en");

            // Act
            translationManager.AddTranslation("en", "greeting", "Hello");

            // Assert
            Assert.Equal("Hello", translationManager.Translate("greeting"));
        }

        /// <summary>
        ///     Tests that Translate should throw exception when no language is set
        /// </summary>
        [Fact]
        public void Translate_WithoutLanguageSet_ShouldThrowException()
        {
            // Arrange
            var translationManager = new TranslationManager();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => translationManager.Translate("greeting"));
        }

        /// <summary>
        ///     Tests that Translate should return default value if translation not found
        /// </summary>
        [Fact]
        public void Translate_WithDefaultValue_ShouldReturnDefaultValue()
        {
            // Arrange
            var translationManager = new TranslationManager();
            translationManager.SetLanguage("English", "en");

            // Act
            string result = translationManager.Translate("nonexistent", "Default Value");

            // Assert
            Assert.Equal("Default Value", result);
        }

        /// <summary>
        ///     Tests that Translate should throw TranslationNotFound when translation doesn't exist
        /// </summary>
        [Fact]
        public void Translate_WithNonExistentKey_ShouldThrowTranslationNotFound()
        {
            // Arrange
            var translationManager = new TranslationManager();
            translationManager.SetLanguage("English", "en");

            // Act & Assert
            Assert.Throws<TranslationNotFound>(() => translationManager.Translate("nonexistent"));
        }

        /// <summary>
        ///     Tests that TranslatePlural returns singular form for quantity 1
        /// </summary>
        [Fact]
        public void TranslatePlural_WithOne_ShouldReturnSingularForm()
        {
            // Arrange
            var translationManager = new TranslationManager();
            translationManager.SetLanguage("English", "en");
            translationManager.AddTranslation("en", "item[0]", "1 item");
            translationManager.AddTranslation("en", "item[1]", "{count} items");

            // Act
            string result = translationManager.TranslatePlural("item", 1);

            // Assert
            Assert.Equal("1 item", result);
        }

        /// <summary>
        ///     Tests that TranslatePlural returns plural form for quantity > 1
        /// </summary>
        [Fact]
        public void TranslatePlural_WithMultiple_ShouldReturnPluralForm()
        {
            // Arrange
            var translationManager = new TranslationManager();
            translationManager.SetLanguage("English", "en");
            translationManager.AddTranslation("en", "item[0]", "1 item");
            translationManager.AddTranslation("en", "item[1]", "{count} items");

            // Act
            string result = translationManager.TranslatePlural("item", 5);

            // Assert
            Assert.Equal($"{5} items", result);
        }

        /// <summary>
        ///     Tests that Translate with parameters should substitute parameters
        /// </summary>
        [Fact]
        public void Translate_WithParameters_ShouldSubstituteParameters()
        {
            // Arrange
            var translationManager = new TranslationManager();
            translationManager.SetLanguage("English", "en");
            translationManager.AddTranslation("en", "greeting", "Hello {name}!");
            var parameters = new Dictionary<string, object> { { "name", "John" } };

            // Act
            string result = translationManager.Translate("greeting", parameters);

            // Assert
            Assert.Equal("Hello John!", result);
        }

        /// <summary>
        ///     Tests that RemoveTranslation removes translation successfully
        /// </summary>
        [Fact]
        public void RemoveTranslation_ShouldRemoveTranslation()
        {
            // Arrange
            var translationManager = new TranslationManager();
            translationManager.SetLanguage("English", "en");
            translationManager.AddTranslation("en", "greeting", "Hello");

            // Act
            translationManager.RemoveTranslation("en", "greeting");

            // Assert
            Assert.Throws<TranslationNotFound>(() => translationManager.Translate("greeting"));
        }

        /// <summary>
        ///     Tests that GetAvailableLanguages returns all added languages
        /// </summary>
        [Fact]
        public void GetAvailableLanguages_ShouldReturnAllAddedLanguages()
        {
            // Arrange
            var translationManager = new TranslationManager();
            var english = new Lang("en", "English");
            var spanish = new Lang("es", "Spanish");

            // Act
            translationManager.AddLanguage(english);
            translationManager.AddLanguage(spanish);
            var languages = translationManager.GetAvailableLanguages();

            // Assert
            Assert.Equal(2, languages.Count);
            Assert.Contains(english, languages);
            Assert.Contains(spanish, languages);
        }

        /// <summary>
        ///     Tests that SetFallbackLanguages should use fallback language when translation not found
        /// </summary>
        [Fact]
        public void SetFallbackLanguages_ShouldUseFallbackLanguage()
        {
            // Arrange
            var translationManager = new TranslationManager();
            translationManager.AddLanguage("English", "en");
            translationManager.AddLanguage("Spanish", "es");
            translationManager.SetLanguage("es");
            translationManager.AddTranslation("en", "greeting", "Hello");
            translationManager.SetFallbackLanguages("en");

            // Act
            string result = translationManager.Translate("greeting");

            // Assert
            Assert.Equal("Hello", result);
        }

        /// <summary>
        ///     Tests that ClearCache should clear the cache
        /// </summary>
        [Fact]
        public void ClearCache_ShouldClearCache()
        {
            // Arrange
            var translationManager = new TranslationManager();
            translationManager.SetLanguage("English", "en");
            translationManager.AddTranslation("en", "greeting", "Hello");

            // Act
            translationManager.Translate("greeting"); // Cache the translation
            translationManager.ClearCache();
            string result = translationManager.Translate("greeting");

            // Assert
            Assert.Equal("Hello", result);
        }

        /// <summary>
        ///     Tests that Subscribe should add observer
        /// </summary>
        [Fact]
        public void Subscribe_ShouldAddObserver()
        {
            // Arrange
            var translationManager = new TranslationManager();
            var observer = new TestTranslationObserver();

            // Act
            translationManager.Subscribe(observer);
            translationManager.SetLanguage("English", "en");

            // Assert
            Assert.True(observer.LanguageChangedCalled);
        }

        /// <summary>
        ///     Tests that Unsubscribe should remove observer
        /// </summary>
        [Fact]
        public void Unsubscribe_ShouldRemoveObserver()
        {
            // Arrange
            var translationManager = new TranslationManager();
            var observer = new TestTranslationObserver();
            translationManager.Subscribe(observer);

            // Act
            translationManager.Unsubscribe(observer);
            translationManager.SetLanguage("English", "en");

            // Assert
            Assert.False(observer.LanguageChangedCalled);
        }

        /// <summary>
        ///     Tests that observer is notified when translation is not found
        /// </summary>
        [Fact]
        public void Translate_WithObserver_ShouldNotifyWhenTranslationNotFound()
        {
            // Arrange
            var translationManager = new TranslationManager();
            var observer = new TestTranslationObserver();
            translationManager.Subscribe(observer);
            translationManager.SetLanguage("English", "en");

            // Act
            try
            {
                translationManager.Translate("nonexistent");
            }
            catch (TranslationNotFound)
            {
                // Expected
            }

            // Assert
            Assert.True(observer.TranslationNotFoundCalled);
        }

        /// <summary>
        ///     Test helper class for observing translation events
        /// </summary>
        private class TestTranslationObserver : ITranslationObserver
        {
            /// <summary>
            /// Gets or sets the value of the language changed called
            /// </summary>
            public bool LanguageChangedCalled { get; set; }
            /// <summary>
            /// Gets or sets the value of the translations updated called
            /// </summary>
            public bool TranslationsUpdatedCalled { get; set; }
            /// <summary>
            /// Gets or sets the value of the translation not found called
            /// </summary>
            public bool TranslationNotFoundCalled { get; set; }

            /// <summary>
            /// Ons the language changed using the specified language
            /// </summary>
            /// <param name="language">The language</param>
            public void OnLanguageChanged(ILanguage language)
            {
                LanguageChangedCalled = true;
            }

            /// <summary>
            /// Ons the translations updated using the specified language code
            /// </summary>
            /// <param name="languageCode">The language code</param>
            public void OnTranslationsUpdated(string languageCode)
            {
                TranslationsUpdatedCalled = true;
            }

            /// <summary>
            /// Ons the translation not found using the specified language code
            /// </summary>
            /// <param name="languageCode">The language code</param>
            /// <param name="key">The key</param>
            public void OnTranslationNotFound(string languageCode, string key)
            {
                TranslationNotFoundCalled = true;
            }
        }
    }
}