

using System;
using System.Collections.Generic;
using Alis.Extension.Language.Translator.Abstractions;
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

            Assert.Throws<TranslationNotFound>(() => translationManager.Translate("nonexistent"));
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

            Assert.Throws<TranslationNotFound>(() => translationManager.Translate("greeting"));
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
            catch (TranslationNotFound)
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
    }
}