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
using Alis.Extension.Language.Translator.Abstractions;
using Alis.Extension.Language.Translator.Cache;
using Alis.Extension.Language.Translator.Pluralization;
using Alis.Extension.Language.Translator.Providers;
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
            TranslationManager translationManager = new TranslationManager();
            Lang lang = new Lang("en", "English");

            translationManager.SetLanguage(lang);

            Assert.Equal(lang, translationManager.Lang);
        }

        /// <summary>
        ///     Tests that SetLanguage with null language should throw exception
        /// </summary>
        [Fact]
        public void SetLanguage_WithNullLanguage_ShouldThrowException()
        {
            TranslationManager translationManager = new TranslationManager();

            Assert.Throws<ArgumentNullException>(() => translationManager.SetLanguage((ILanguage) null));
        }

        /// <summary>
        ///     Tests that SetLanguage with name and code should set language
        /// </summary>
        [Fact]
        public void SetLanguage_WithNameAndCode_ShouldSetLanguage()
        {
            TranslationManager translationManager = new TranslationManager();

            translationManager.SetLanguage("English", "en");

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
            TranslationManager translationManager = new TranslationManager();
            Lang lang = new Lang("es", "Spanish");

            translationManager.AddLanguage(lang);

            Assert.Contains(lang, translationManager.GetAvailableLanguages());
        }

        /// <summary>
        ///     Tests that AddLanguage with null language should throw exception
        /// </summary>
        [Fact]
        public void AddLanguage_WithNullLanguage_ShouldThrowException()
        {
            TranslationManager translationManager = new TranslationManager();

            Assert.Throws<ArgumentNullException>(() => translationManager.AddLanguage(null));
        }

        /// <summary>
        ///     Tests that AddTranslation should add translation for current language
        /// </summary>
        [Fact]
        public void AddTranslation_ShouldAddTranslationForCurrentLanguage()
        {
            TranslationManager translationManager = new TranslationManager();
            translationManager.SetLanguage("English", "en");

            translationManager.AddTranslation("en", "greeting", "Hello");

            Assert.Equal("Hello", translationManager.Translate("greeting"));
        }

        /// <summary>
        ///     Tests that Translate should throw exception when no language is set
        /// </summary>
        [Fact]
        public void Translate_WithoutLanguageSet_ShouldThrowException()
        {
            TranslationManager translationManager = new TranslationManager();

            Assert.Throws<InvalidOperationException>(() => translationManager.Translate("greeting"));
        }

        /// <summary>
        ///     Tests that Translate should return default value if translation not found
        /// </summary>
        [Fact]
        public void Translate_WithDefaultValue_ShouldReturnDefaultValue()
        {
            TranslationManager translationManager = new TranslationManager();
            translationManager.SetLanguage("English", "en");

            string result = translationManager.Translate("nonexistent", "Default Value");

            Assert.Equal("Default Value", result);
        }

        /// <summary>
        ///     Tests that Translate should throw TranslationNotFound when translation doesn't exist
        /// </summary>
        [Fact]
        public void Translate_WithNonExistentKey_ShouldThrowTranslationNotFound()
        {
            TranslationManager translationManager = new TranslationManager();
            translationManager.SetLanguage("English", "en");

            Assert.Throws<TranslationNotFoundException>(() => translationManager.Translate("nonexistent"));
        }

        /// <summary>
        ///     Tests that TranslatePlural returns singular form for quantity 1
        /// </summary>
        [Fact]
        public void TranslatePlural_WithOne_ShouldReturnSingularForm()
        {
            TranslationManager translationManager = new TranslationManager();
            translationManager.SetLanguage("English", "en");
            translationManager.AddTranslation("en", "item[0]", "1 item");
            translationManager.AddTranslation("en", "item[1]", "{count} items");

            string result = translationManager.TranslatePlural("item", 1);

            Assert.Equal("1 item", result);
        }

        /// <summary>
        ///     Tests that TranslatePlural returns plural form for quantity > 1
        /// </summary>
        [Fact]
        public void TranslatePlural_WithMultiple_ShouldReturnPluralForm()
        {
            TranslationManager translationManager = new TranslationManager();
            translationManager.SetLanguage("English", "en");
            translationManager.AddTranslation("en", "item[0]", "1 item");
            translationManager.AddTranslation("en", "item[1]", "{count} items");

            string result = translationManager.TranslatePlural("item", 5);

            Assert.Equal($"{5} items", result);
        }

        /// <summary>
        ///     Tests that Translate with parameters should substitute parameters
        /// </summary>
        [Fact]
        public void Translate_WithParameters_ShouldSubstituteParameters()
        {
            TranslationManager translationManager = new TranslationManager();
            translationManager.SetLanguage("English", "en");
            translationManager.AddTranslation("en", "greeting", "Hello {name}!");
            Dictionary<string, object> parameters = new Dictionary<string, object> {{"name", "John"}};

            string result = translationManager.Translate("greeting", parameters);

            Assert.Equal("Hello John!", result);
        }

        /// <summary>
        ///     Tests that RemoveTranslation removes translation successfully
        /// </summary>
        [Fact]
        public void RemoveTranslation_ShouldRemoveTranslation()
        {
            TranslationManager translationManager = new TranslationManager();
            translationManager.SetLanguage("English", "en");
            translationManager.AddTranslation("en", "greeting", "Hello");

            translationManager.RemoveTranslation("en", "greeting");

            Assert.Throws<TranslationNotFoundException>(() => translationManager.Translate("greeting"));
        }

        /// <summary>
        ///     Tests that GetAvailableLanguages returns all added languages
        /// </summary>
        [Fact]
        public void GetAvailableLanguages_ShouldReturnAllAddedLanguages()
        {
            TranslationManager translationManager = new TranslationManager();
            Lang english = new Lang("en", "English");
            Lang spanish = new Lang("es", "Spanish");

            translationManager.AddLanguage(english);
            translationManager.AddLanguage(spanish);
            IReadOnlyList<ILanguage> languages = translationManager.GetAvailableLanguages();

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
            TranslationManager translationManager = new TranslationManager();
            translationManager.AddLanguage("English", "en");
            translationManager.AddLanguage("Spanish", "es");
            translationManager.SetLanguage("es");
            translationManager.AddTranslation("en", "greeting", "Hello");
            translationManager.SetFallbackLanguages("en");

            string result = translationManager.Translate("greeting");

            Assert.Equal("Hello", result);
        }

        /// <summary>
        ///     Tests that ClearCache should clear the cache
        /// </summary>
        [Fact]
        public void ClearCache_ShouldClearCache()
        {
            TranslationManager translationManager = new TranslationManager();
            translationManager.SetLanguage("English", "en");
            translationManager.AddTranslation("en", "greeting", "Hello");

            translationManager.Translate("greeting"); // Cache the translation
            translationManager.ClearCache();
            string result = translationManager.Translate("greeting");

            Assert.Equal("Hello", result);
        }

        /// <summary>
        ///     Tests that Subscribe should add observer
        /// </summary>
        [Fact]
        public void Subscribe_ShouldAddObserver()
        {
            TranslationManager translationManager = new TranslationManager();
            TestTranslationObserver observer = new TestTranslationObserver();

            translationManager.Subscribe(observer);
            translationManager.SetLanguage("English", "en");

            Assert.True(observer.LanguageChangedCalled);
        }

        /// <summary>
        ///     Tests that Unsubscribe should remove observer
        /// </summary>
        [Fact]
        public void Unsubscribe_ShouldRemoveObserver()
        {
            TranslationManager translationManager = new TranslationManager();
            TestTranslationObserver observer = new TestTranslationObserver();
            translationManager.Subscribe(observer);

            translationManager.Unsubscribe(observer);
            translationManager.SetLanguage("English", "en");

            Assert.False(observer.LanguageChangedCalled);
        }

        /// <summary>
        ///     Tests that observer is notified when translation is not found
        /// </summary>
        [Fact]
        public void Translate_WithObserver_ShouldNotifyWhenTranslationNotFound()
        {
            TranslationManager translationManager = new TranslationManager();
            TestTranslationObserver observer = new TestTranslationObserver();
            translationManager.Subscribe(observer);
            translationManager.SetLanguage("English", "en");

            try
            {
                translationManager.Translate("nonexistent");
            }
            catch (TranslationNotFoundException)
            {
            }

            Assert.True(observer.TranslationNotFoundCalled);
        }

        /// <summary>
        ///     Test helper class for observing translation events
        /// </summary>
        private class TestTranslationObserver : ITranslationObserver
        {
            /// <summary>
            ///     Gets or sets the value of the language changed called
            /// </summary>
            public bool LanguageChangedCalled { get; set; }

            /// <summary>
            ///     Gets or sets the value of the translations updated called
            /// </summary>
            public bool TranslationsUpdatedCalled { get; set; }

            /// <summary>
            ///     Gets or sets the value of the translation not found called
            /// </summary>
            public bool TranslationNotFoundCalled { get; set; }

            /// <summary>
            ///     Ons the language changed using the specified language
            /// </summary>
            /// <param name="language">The language</param>
            public void OnLanguageChanged(ILanguage language)
            {
                LanguageChangedCalled = true;
            }

            /// <summary>
            ///     Ons the translations updated using the specified language code
            /// </summary>
            /// <param name="languageCode">The language code</param>
            public void OnTranslationsUpdated(string languageCode)
            {
                TranslationsUpdatedCalled = true;
            }

            /// <summary>
            ///     Ons the translation not found using the specified language code
            /// </summary>
            /// <param name="languageCode">The language code</param>
            /// <param name="key">The key</param>
            public void OnTranslationNotFound(string languageCode, string key)
            {
                TranslationNotFoundCalled = true;
            }
        }
        /// <summary>
        ///     Tests that constructor with null language provider throws
        /// </summary>
        [Fact]
        public void Constructor_WithNullLanguageProvider_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new TranslationManager(null, new MemoryTranslationProvider(), new MemoryTranslationCache(), new PluralizationEngine()));
        }

        /// <summary>
        ///     Tests that constructor with null translation provider throws
        /// </summary>
        [Fact]
        public void Constructor_WithNullTranslationProvider_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new TranslationManager(new LanguageProvider(), null, new MemoryTranslationCache(), new PluralizationEngine()));
        }

        /// <summary>
        ///     Tests that constructor with null cache throws
        /// </summary>
        [Fact]
        public void Constructor_WithNullCache_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new TranslationManager(new LanguageProvider(), new MemoryTranslationProvider(), null, new PluralizationEngine()));
        }

        /// <summary>
        ///     Tests that constructor with null pluralization engine throws
        /// </summary>
        [Fact]
        public void Constructor_WithNullPluralizationEngine_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new TranslationManager(new LanguageProvider(), new MemoryTranslationProvider(), new MemoryTranslationCache(), null));
        }

        /// <summary>
        ///     Tests SetLanguage with null code throws
        /// </summary>
        [Fact]
        public void SetLanguage_WithNullCode_ShouldThrowException()
        {
            TranslationManager translationManager = new TranslationManager();

            Assert.Throws<ArgumentNullException>(() => translationManager.SetLanguage((string)null));
        }

        /// <summary>
        ///     Tests SetLanguage with invalid code throws LanguageNotFoundException
        /// </summary>
        [Fact]
        public void SetLanguage_WithInvalidCode_ShouldThrowLanguageNotFoundException()
        {
            TranslationManager translationManager = new TranslationManager();

            Assert.Throws<LanguageNotFoundException>(() => translationManager.SetLanguage("zz"));
        }

        /// <summary>
        ///     Tests SetLanguage with name and code null name throws
        /// </summary>
        [Fact]
        public void SetLanguage_WithNullName_ShouldThrowException()
        {
            TranslationManager translationManager = new TranslationManager();

            Assert.Throws<ArgumentNullException>(() => translationManager.SetLanguage(null, "en"));
        }

        /// <summary>
        ///     Tests SetLanguage with name and code null code throws
        /// </summary>
        [Fact]
        public void SetLanguage_WithNullCode_ShouldThrowException2()
        {
            TranslationManager translationManager = new TranslationManager();

            Assert.Throws<ArgumentNullException>(() => translationManager.SetLanguage("English", null));
        }

        /// <summary>
        ///     Tests SetLanguage with name and code for existing language reuses it
        /// </summary>
        [Fact]
        public void SetLanguage_WithExistingCode_ShouldReuseExistingLanguage()
        {
            TranslationManager translationManager = new TranslationManager();
            translationManager.AddLanguage("English", "en");

            translationManager.SetLanguage("English", "en");

            Assert.NotNull(translationManager.Lang);
            Assert.Equal("en", translationManager.Lang.Code);
        }

        /// <summary>
        ///     Tests AddLanguage sets current language when none is set
        /// </summary>
        [Fact]
        public void AddLanguage_WithoutCurrentLanguage_ShouldSetAsCurrent()
        {
            TranslationManager translationManager = new TranslationManager();
            Lang lang = new Lang("es", "Spanish");

            translationManager.AddLanguage(lang);

            Assert.Equal(lang, translationManager.Lang);
        }

        /// <summary>
        ///     Tests AddLanguage with null name throws
        /// </summary>
        [Fact]
        public void AddLanguage_WithNullName_ShouldThrowException()
        {
            TranslationManager translationManager = new TranslationManager();

            Assert.Throws<ArgumentNullException>(() => translationManager.AddLanguage(null, "en"));
        }

        /// <summary>
        ///     Tests AddLanguage with null code throws
        /// </summary>
        [Fact]
        public void AddLanguage_WithNullCode_ShouldThrowException()
        {
            TranslationManager translationManager = new TranslationManager();

            Assert.Throws<ArgumentNullException>(() => translationManager.AddLanguage("English", null));
        }

        /// <summary>
        ///     Tests SetLanguage with duplicate add catches InvalidOperationException
        /// </summary>
        [Fact]
        public void SetLanguage_WithDuplicateAdd_ShouldNotThrow()
        {
            TranslationManager translationManager = new TranslationManager();
            Lang lang = new Lang("en", "English");

            translationManager.SetLanguage(lang);
            translationManager.SetLanguage(lang);

            Assert.Equal(lang, translationManager.Lang);
        }

        /// <summary>
        ///     Tests Translate with null key throws
        /// </summary>
        [Fact]
        public void Translate_WithNullKey_ShouldThrowException()
        {
            TranslationManager translationManager = new TranslationManager();

            Assert.Throws<ArgumentNullException>(() => translationManager.Translate((string)null));
        }

        /// <summary>
        ///     Tests Translate with parameters null throws
        /// </summary>
        [Fact]
        public void Translate_WithNullParameters_ShouldThrowException()
        {
            TranslationManager translationManager = new TranslationManager();

            Assert.Throws<ArgumentNullException>(() => translationManager.Translate("key", (IDictionary<string, object>)null));
        }

        /// <summary>
        ///     Tests Translate with parameters including null value
        /// </summary>
        [Fact]
        public void Translate_WithNullParameterValue_ShouldSubstituteWithEmptyString()
        {
            TranslationManager translationManager = new TranslationManager();
            translationManager.SetLanguage("English", "en");
            translationManager.AddTranslation("en", "greeting", "Hello {name}!");
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "name", null } };

            string result = translationManager.Translate("greeting", parameters);

            Assert.Equal("Hello !", result);
        }

        /// <summary>
        ///     Tests TranslatePlural with null key throws
        /// </summary>
        [Fact]
        public void TranslatePlural_WithNullKey_ShouldThrowException()
        {
            TranslationManager translationManager = new TranslationManager();
            translationManager.SetLanguage("English", "en");

            Assert.Throws<ArgumentNullException>(() => translationManager.TranslatePlural(null, 1));
        }

        /// <summary>
        ///     Tests TranslatePlural without language throws
        /// </summary>
        [Fact]
        public void TranslatePlural_WithoutLanguage_ShouldThrowException()
        {
            TranslationManager translationManager = new TranslationManager();

            Assert.Throws<InvalidOperationException>(() => translationManager.TranslatePlural("item", 1));
        }

        /// <summary>
        ///     Tests TranslatePlural falls back to base key when plural form not found
        /// </summary>
        [Fact]
        public void TranslatePlural_WhenPluralFormNotFound_ShouldFallBackToBaseKey()
        {
            TranslationManager translationManager = new TranslationManager();
            translationManager.SetLanguage("English", "en");
            translationManager.AddTranslation("en", "item", "{count} items");

            string result = translationManager.TranslatePlural("item", 5);

            Assert.Equal("5 items", result);
        }

        /// <summary>
        ///     Tests AddTranslation with null language throws
        /// </summary>
        [Fact]
        public void AddTranslation_WithNullLanguage_ShouldThrowException()
        {
            TranslationManager translationManager = new TranslationManager();

            Assert.Throws<ArgumentNullException>(() => translationManager.AddTranslation((ILanguage)null, "key", "value"));
        }

        /// <summary>
        ///     Tests AddTranslation with null language code throws
        /// </summary>
        [Fact]
        public void AddTranslation_WithNullLanguageCode_ShouldThrowException()
        {
            TranslationManager translationManager = new TranslationManager();

            Assert.Throws<ArgumentNullException>(() => translationManager.AddTranslation((string)null, "key", "value"));
        }

        /// <summary>
        ///     Tests AddTranslation with null key throws
        /// </summary>
        [Fact]
        public void AddTranslation_WithNullKey_ShouldThrowException()
        {
            TranslationManager translationManager = new TranslationManager();

            Assert.Throws<ArgumentNullException>(() => translationManager.AddTranslation("en", null, "value"));
        }

        /// <summary>
        ///     Tests AddTranslation with null value throws
        /// </summary>
        [Fact]
        public void AddTranslation_WithNullValue_ShouldThrowException()
        {
            TranslationManager translationManager = new TranslationManager();

            Assert.Throws<ArgumentNullException>(() => translationManager.AddTranslation("en", "key", null));
        }

        /// <summary>
        ///     Tests that AddTranslation with non-existent language throws
        /// </summary>
        [Fact]
        public void AddTranslation_WithNonExistentLanguage_ShouldThrowLanguageNotFoundException()
        {
            TranslationManager translationManager = new TranslationManager();

            Assert.Throws<LanguageNotFoundException>(() => translationManager.AddTranslation("zz", "key", "value"));
        }

        /// <summary>
        ///     Tests RemoveTranslation with null language code does nothing
        /// </summary>
        [Fact]
        public void RemoveTranslation_WithNullLanguageCode_ShouldNotThrow()
        {
            TranslationManager translationManager = new TranslationManager();

            translationManager.RemoveTranslation(null, "key");
        }

        /// <summary>
        ///     Tests RemoveTranslation with null key does nothing
        /// </summary>
        [Fact]
        public void RemoveTranslation_WithNullKey_ShouldNotThrow()
        {
            TranslationManager translationManager = new TranslationManager();

            translationManager.RemoveTranslation("en", null);
        }

        /// <summary>
        ///     Tests Subscribe with null observer throws
        /// </summary>
        [Fact]
        public void Subscribe_WithNullObserver_ShouldThrowException()
        {
            TranslationManager translationManager = new TranslationManager();

            Assert.Throws<ArgumentNullException>(() => translationManager.Subscribe(null));
        }

        /// <summary>
        ///     Tests Subscribe with duplicate observer does not add twice
        /// </summary>
        [Fact]
        public void Subscribe_WithDuplicateObserver_ShouldNotAddTwice()
        {
            TranslationManager translationManager = new TranslationManager();
            TestTranslationObserver observer = new TestTranslationObserver();

            translationManager.Subscribe(observer);
            translationManager.Subscribe(observer);
            translationManager.SetLanguage("English", "en");

            Assert.True(observer.LanguageChangedCalled);
        }

        /// <summary>
        ///     Tests Unsubscribe with null observer does nothing
        /// </summary>
        [Fact]
        public void Unsubscribe_WithNullObserver_ShouldNotThrow()
        {
            TranslationManager translationManager = new TranslationManager();

            translationManager.Unsubscribe(null);
        }

        /// <summary>
        ///     Tests that SetFallbackLanguages with null codes does nothing
        /// </summary>
        [Fact]
        public void SetFallbackLanguages_WithNullCodes_ShouldNotThrow()
        {
            TranslationManager translationManager = new TranslationManager();

            translationManager.SetFallbackLanguages(null);
        }

        /// <summary>
        ///     Tests that observer is notified when translations are updated
        /// </summary>
        [Fact]
        public void AddTranslation_WithObserver_ShouldNotifyTranslationsUpdated()
        {
            TranslationManager translationManager = new TranslationManager();
            TestTranslationObserver observer = new TestTranslationObserver();
            translationManager.Subscribe(observer);
            translationManager.SetLanguage("English", "en");

            translationManager.AddTranslation("en", "greeting", "Hello");

            Assert.True(observer.TranslationsUpdatedCalled);
        }

        /// <summary>
        ///     Tests that ClearCache does not throw
        /// </summary>
        [Fact]
        public void ClearCache_ShouldNotThrow()
        {
            TranslationManager translationManager = new TranslationManager();

            translationManager.ClearCache();
        }

        /// <summary>
        ///     Tests that GetAvailableLanguages returns empty initially
        /// </summary>
        [Fact]
        public void GetAvailableLanguages_Initially_ShouldBeEmpty()
        {
            TranslationManager translationManager = new TranslationManager();

            IReadOnlyList<ILanguage> languages = translationManager.GetAvailableLanguages();

            Assert.Empty(languages);
        }

        /// <summary>
        ///     Tests that TranslatePlural with count substitution works
        /// </summary>
        [Fact]
        public void TranslatePlural_WithKeyWithoutBrackets_ShouldSubstituteCount()
        {
            TranslationManager translationManager = new TranslationManager();
            translationManager.SetLanguage("English", "en");
            translationManager.AddTranslation("en", "items", "{count} items");

            string result = translationManager.TranslatePlural("items", 3);

            Assert.Equal("3 items", result);
        }
    }
}