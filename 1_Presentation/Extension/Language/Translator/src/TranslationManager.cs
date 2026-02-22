// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TranslationManager.cs
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
using System.Linq;

namespace Alis.Extension.Language.Translator
{
    /// <summary>
    ///     The translation manager class
    /// </summary>
    /// <remarks>
    ///     This class serves as a facade for the translation system, coordinating
    ///     language management, translation lookup, caching, and pluralization.
    ///     It uses dependency injection to allow for flexible configuration of providers,
    ///     caches, and other services.
    /// </remarks>
    public class TranslationManager
    {
        /// <summary>
        ///     The language provider
        /// </summary>
        private readonly ILanguageProvider languageProvider;

        /// <summary>
        ///     The translation provider
        /// </summary>
        private readonly ITranslationProvider translationProvider;

        /// <summary>
        ///     The translation cache
        /// </summary>
        private readonly ITranslationCache cache;

        /// <summary>
        ///     The pluralization engine
        /// </summary>
        private readonly IPluralizationEngine pluralizationEngine;

        /// <summary>
        ///     List of observers to notify on translation events
        /// </summary>
        private readonly List<ITranslationObserver> observers = new List<ITranslationObserver>();

        /// <summary>
        ///     The lock object for thread-safe operations
        /// </summary>
        private readonly object syncLock = new object();

        /// <summary>
        ///     The current language
        /// </summary>
        private ILanguage currentLanguage;

        /// <summary>
        ///     The fallback language codes (e.g., "en-US" -> ["en-US", "en"])
        /// </summary>
        private readonly List<string> fallbackLanguages = new List<string>();

        /// <summary>
        ///     Gets the current language
        /// </summary>
        public ILanguage Lang
        {
            get => currentLanguage;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TranslationManager"/> class with default providers
        /// </summary>
        public TranslationManager()
            : this(new LanguageProvider(), new MemoryTranslationProvider(), 
                   new MemoryTranslationCache(), new PluralizationEngine())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TranslationManager"/> class with custom providers
        /// </summary>
        /// <param name="languageProvider">The language provider</param>
        /// <param name="translationProvider">The translation provider</param>
        /// <param name="cache">The translation cache</param>
        /// <param name="pluralizationEngine">The pluralization engine</param>
        public TranslationManager(ILanguageProvider languageProvider, 
                                 ITranslationProvider translationProvider,
                                 ITranslationCache cache,
                                 IPluralizationEngine pluralizationEngine)
        {
            this.languageProvider = languageProvider ?? throw new ArgumentNullException(nameof(languageProvider));
            this.translationProvider = translationProvider ?? throw new ArgumentNullException(nameof(translationProvider));
            this.cache = cache ?? throw new ArgumentNullException(nameof(cache));
            this.pluralizationEngine = pluralizationEngine ?? throw new ArgumentNullException(nameof(pluralizationEngine));
        }

        /// <summary>
        ///     Sets the current language using a language object
        /// </summary>
        /// <param name="language">The language to set</param>
        public void SetLanguage(ILanguage language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(nameof(language), "Language cannot be null");
            }

            lock (syncLock)
            {
                try
                {
                    languageProvider.AddLanguage(language);
                }
                catch (InvalidOperationException)
                {
                    // Language already exists, that's fine
                }

                currentLanguage = language;
                NotifyLanguageChanged(language);
            }
        }

        /// <summary>
        ///     Sets the current language using language code
        /// </summary>
        /// <param name="languageCode">The language code (e.g., 'en', 'es')</param>
        public void SetLanguage(string languageCode)
        {
            if (string.IsNullOrWhiteSpace(languageCode))
            {
                throw new ArgumentNullException(nameof(languageCode), "Language code cannot be null or empty");
            }

            lock (syncLock)
            {
                var language = languageProvider.GetLanguageByCode(languageCode);
                
                if (language == null)
                {
                    throw new LanguageNotFound($"Language not found for code: {languageCode}");
                }

                currentLanguage = language;
                NotifyLanguageChanged(language);
            }
        }

        /// <summary>
        ///     Sets the current language using name and code
        /// </summary>
        /// <param name="name">The language name</param>
        /// <param name="code">The language code</param>
        public void SetLanguage(string name, string code)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Language name cannot be null or empty");
            }

            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException(nameof(code), "Language code cannot be null or empty");
            }

            lock (syncLock)
            {
                var existingLanguage = languageProvider.GetLanguageByCode(code);
                ILanguage language;

                if (existingLanguage != null)
                {
                    language = existingLanguage;
                }
                else
                {
                    language = new Lang(code, name);
                    languageProvider.AddLanguage(language);
                }

                currentLanguage = language;
                NotifyLanguageChanged(language);
            }
        }

        /// <summary>
        ///     Adds a new language to the manager
        /// </summary>
        /// <param name="language">The language to add</param>
        public void AddLanguage(ILanguage language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(nameof(language), "Language cannot be null");
            }

            lock (syncLock)
            {
                languageProvider.AddLanguage(language);

                if (currentLanguage == null)
                {
                    currentLanguage = language;
                }
            }
        }

        /// <summary>
        ///     Adds a new language using name and code
        /// </summary>
        /// <param name="name">The language name</param>
        /// <param name="code">The language code</param>
        public void AddLanguage(string name, string code)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Language name cannot be null or empty");
            }

            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException(nameof(code), "Language code cannot be null or empty");
            }

            var language = new Lang(code, name);
            AddLanguage(language);
        }

        /// <summary>
        ///     Translates a key for the current language
        /// </summary>
        /// <param name="key">The translation key</param>
        /// <returns>The translated string</returns>
        public string Translate(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key), "Translation key cannot be null or empty");
            }

            if (currentLanguage == null)
            {
                throw new InvalidOperationException("No language has been set. Call SetLanguage first.");
            }

            return TranslateForLanguage(currentLanguage.Code, key);
        }

        /// <summary>
        ///     Translates a key with a fallback value
        /// </summary>
        /// <param name="key">The translation key</param>
        /// <param name="defaultValue">The default value if translation is not found</param>
        /// <returns>The translated string or the default value</returns>
        public string Translate(string key, string defaultValue)
        {
            try
            {
                return Translate(key);
            }
            catch (TranslationNotFound)
            {
                return defaultValue;
            }
        }

        /// <summary>
        ///     Translates a key with pluralization
        /// </summary>
        /// <param name="key">The translation key</param>
        /// <param name="quantity">The quantity for pluralization</param>
        /// <returns>The translated string in the appropriate plural form</returns>
        public string TranslatePlural(string key, int quantity)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key), "Translation key cannot be null or empty");
            }

            if (currentLanguage == null)
            {
                throw new InvalidOperationException("No language has been set. Call SetLanguage first.");
            }

            int pluralForm = pluralizationEngine.GetPluralForm(currentLanguage.Code, quantity);
            string pluralKey = $"{key}[{pluralForm}]";

            try
            {
                string translated = TranslateForLanguage(currentLanguage.Code, pluralKey);
                return translated.Replace("{count}", quantity.ToString());
            }
            catch (TranslationNotFound)
            {
                // Try the original key
                string translated = TranslateForLanguage(currentLanguage.Code, key);
                return translated.Replace("{count}", quantity.ToString());
            }
        }

        /// <summary>
        ///     Translates a key with parameter substitution
        /// </summary>
        /// <param name="key">The translation key</param>
        /// <param name="parameters">Parameters to substitute (name -> value)</param>
        /// <returns>The translated and substituted string</returns>
        public string Translate(string key, IDictionary<string, object> parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            string translated = Translate(key);

            foreach (var kvp in parameters)
            {
                string placeholder = $"{{{kvp.Key}}}";
                translated = translated.Replace(placeholder, kvp.Value?.ToString() ?? string.Empty);
            }

            return translated;
        }

        /// <summary>
        ///     Adds a translation for a specific language
        /// </summary>
        /// <param name="language">The language</param>
        /// <param name="key">The translation key</param>
        /// <param name="value">The translated text</param>
        public void AddTranslation(ILanguage language, string key, string value)
        {
            if (language == null)
            {
                throw new ArgumentNullException(nameof(language), "Language cannot be null");
            }

            AddTranslation(language.Code, key, value);
        }

        /// <summary>
        ///     Adds a translation using language code
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <param name="key">The translation key</param>
        /// <param name="value">The translated text</param>
        public void AddTranslation(string languageCode, string key, string value)
        {
            if (string.IsNullOrWhiteSpace(languageCode))
            {
                throw new ArgumentNullException(nameof(languageCode), "Language code cannot be null or empty");
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key), "Translation key cannot be null or empty");
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value), "Translation value cannot be null or empty");
            }

            if (!languageProvider.LanguageExists(languageCode))
            {
                throw new LanguageNotFound($"Language not found for code: {languageCode}");
            }

            lock (syncLock)
            {
                translationProvider.SetTranslationAsync(languageCode, key, value).Wait();
                cache.Set(languageCode, key, value);
                NotifyTranslationsUpdated(languageCode);
            }
        }

        /// <summary>
        ///     Removes a translation
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <param name="key">The translation key</param>
        public void RemoveTranslation(string languageCode, string key)
        {
            if (string.IsNullOrWhiteSpace(languageCode) || string.IsNullOrWhiteSpace(key))
            {
                return;
            }

            lock (syncLock)
            {
                translationProvider.RemoveTranslationAsync(languageCode, key).Wait();
                cache.Remove(languageCode, key);
                NotifyTranslationsUpdated(languageCode);
            }
        }

        /// <summary>
        ///     Gets all available languages
        /// </summary>
        /// <returns>A read-only list of available languages</returns>
        public IReadOnlyList<ILanguage> GetAvailableLanguages()
        {
            return languageProvider.GetAvailableLanguages();
        }

        /// <summary>
        ///     Sets up fallback languages for missing translations
        /// </summary>
        /// <param name="fallbackCodes">Language codes to try in order</param>
        public void SetFallbackLanguages(params string[] fallbackCodes)
        {
            if (fallbackCodes == null || fallbackCodes.Length == 0)
            {
                return;
            }

            lock (syncLock)
            {
                fallbackLanguages.Clear();
                fallbackLanguages.AddRange(fallbackCodes.Where(c => !string.IsNullOrWhiteSpace(c)));
            }
        }

        /// <summary>
        ///     Subscribes an observer to translation events
        /// </summary>
        /// <param name="observer">The observer to subscribe</param>
        public void Subscribe(ITranslationObserver observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException(nameof(observer));
            }

            lock (syncLock)
            {
                if (!observers.Contains(observer))
                {
                    observers.Add(observer);
                }
            }
        }

        /// <summary>
        ///     Unsubscribes an observer from translation events
        /// </summary>
        /// <param name="observer">The observer to unsubscribe</param>
        public void Unsubscribe(ITranslationObserver observer)
        {
            if (observer == null)
            {
                return;
            }

            lock (syncLock)
            {
                observers.Remove(observer);
            }
        }

        /// <summary>
        ///     Clears the translation cache
        /// </summary>
        public void ClearCache()
        {
            cache.Clear();
        }

        /// <summary>
        ///     Translates a key for a specific language
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <param name="key">The translation key</param>
        /// <returns>The translated string</returns>
        private string TranslateForLanguage(string languageCode, string key)
        {
            // Check cache first
            if (cache.TryGetTranslation(languageCode, key, out string cachedValue))
            {
                return cachedValue;
            }

            // Try to get from provider
            var translationTask = translationProvider.GetTranslationAsync(languageCode, key);
            translationTask.Wait();
            string value = translationTask.Result;

            if (value != null)
            {
                cache.Set(languageCode, key, value);
                return value;
            }

            // Try fallback languages
            foreach (var fallbackCode in fallbackLanguages)
            {
                if (fallbackCode == languageCode)
                {
                    continue; // Skip the current language
                }

                var fallbackTask = translationProvider.GetTranslationAsync(fallbackCode, key);
                fallbackTask.Wait();
                string fallbackValue = fallbackTask.Result;

                if (fallbackValue != null)
                {
                    return fallbackValue;
                }
            }

            NotifyTranslationNotFound(languageCode, key);
            throw new TranslationNotFound(key);
        }

        /// <summary>
        ///     Notifies observers that the language has changed
        /// </summary>
        /// <param name="language">The newly selected language</param>
        private void NotifyLanguageChanged(ILanguage language)
        {
            var observersCopy = new List<ITranslationObserver>(observers);
            foreach (var observer in observersCopy)
            {
                observer.OnLanguageChanged(language);
            }
        }

        /// <summary>
        ///     Notifies observers that translations have been updated
        /// </summary>
        /// <param name="languageCode">The language code that was updated</param>
        private void NotifyTranslationsUpdated(string languageCode)
        {
            var observersCopy = new List<ITranslationObserver>(observers);
            foreach (var observer in observersCopy)
            {
                observer.OnTranslationsUpdated(languageCode);
            }
        }

        /// <summary>
        ///     Notifies observers that a translation was not found
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <param name="key">The translation key that was not found</param>
        private void NotifyTranslationNotFound(string languageCode, string key)
        {
            var observersCopy = new List<ITranslationObserver>(observers);
            foreach (var observer in observersCopy)
            {
                observer.OnTranslationNotFound(languageCode, key);
            }
        }
    }
}