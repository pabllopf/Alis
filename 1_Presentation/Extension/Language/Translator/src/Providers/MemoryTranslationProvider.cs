// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MemoryTranslationProvider.cs
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
using System.Threading.Tasks;

namespace Alis.Extension.Language.Translator
{
    /// <summary>
    ///     In-memory implementation of the translation provider
    /// </summary>
    /// <remarks>
    ///     This provider stores translations in memory using nested dictionaries.
    ///     It is suitable for applications where translations are predefined and don't change frequently.
    /// </remarks>
    public class MemoryTranslationProvider : ITranslationProvider
    {
        /// <summary>
        ///     The translations storage: {languageCode -> {key -> value}}
        /// </summary>
        private readonly Dictionary<string, Dictionary<string, string>> translations =
            new Dictionary<string, Dictionary<string, string>>();

        /// <summary>
        ///     The lock object for thread-safe operations
        /// </summary>
        private readonly object syncLock = new object();

        /// <summary>
        ///     Gets the name of this provider
        /// </summary>
        public string Name => "MemoryTranslationProvider";

        /// <summary>
        ///     Loads all translations from the source
        /// </summary>
        /// <returns>A dictionary mapping language codes to their translations</returns>
        public Task<Dictionary<string, Dictionary<string, string>>> LoadTranslationsAsync()
        {
            lock (syncLock)
            {
                var copy = new Dictionary<string, Dictionary<string, string>>();
                foreach (var kvp in translations)
                {
                    copy[kvp.Key] = new Dictionary<string, string>(kvp.Value);
                }

                return Task.FromResult(copy);
            }
        }

        /// <summary>
        ///     Saves the translations to the source
        /// </summary>
        /// <param name="translationsDictionary">The translations to save</param>
        /// <returns>A task representing the asynchronous operation</returns>
        public Task SaveTranslationsAsync(Dictionary<string, Dictionary<string, string>> translationsDictionary)
        {
            if (translationsDictionary == null)
            {
                throw new ArgumentNullException(nameof(translationsDictionary));
            }

            lock (syncLock)
            {
                translations.Clear();
                foreach (var kvp in translationsDictionary)
                {
                    if (kvp.Value != null)
                    {
                        translations[kvp.Key] = new Dictionary<string, string>(kvp.Value);
                    }
                }
            }

            return Task.CompletedTask;
        }

        /// <summary>
        ///     Gets a translation for a specific key and language code
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <param name="key">The translation key</param>
        /// <returns>The translated text, or null if not found</returns>
        public Task<string> GetTranslationAsync(string languageCode, string key)
        {
            if (string.IsNullOrWhiteSpace(languageCode) || string.IsNullOrWhiteSpace(key))
            {
                return Task.FromResult<string>(null);
            }

            lock (syncLock)
            {
                if (translations.ContainsKey(languageCode) && translations[languageCode].ContainsKey(key))
                {
                    return Task.FromResult(translations[languageCode][key]);
                }

                return Task.FromResult<string>(null);
            }
        }

        /// <summary>
        ///     Adds or updates a translation
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <param name="key">The translation key</param>
        /// <param name="value">The translated text</param>
        /// <returns>A task representing the asynchronous operation</returns>
        public Task SetTranslationAsync(string languageCode, string key, string value)
        {
            if (string.IsNullOrWhiteSpace(languageCode) || string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Language code and key cannot be null or empty");
            }

            lock (syncLock)
            {
                if (!translations.ContainsKey(languageCode))
                {
                    translations[languageCode] = new Dictionary<string, string>();
                }

                translations[languageCode][key] = value ?? string.Empty;
            }

            return Task.CompletedTask;
        }

        /// <summary>
        ///     Removes a translation
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <param name="key">The translation key</param>
        /// <returns>A task representing the asynchronous operation</returns>
        public Task RemoveTranslationAsync(string languageCode, string key)
        {
            if (string.IsNullOrWhiteSpace(languageCode) || string.IsNullOrWhiteSpace(key))
            {
                return Task.CompletedTask;
            }

            lock (syncLock)
            {
                if (translations.ContainsKey(languageCode))
                {
                    translations[languageCode].Remove(key);
                }
            }

            return Task.CompletedTask;
        }

        /// <summary>
        ///     Gets all translation keys for a specific language
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <returns>A list of translation keys</returns>
        public Task<IEnumerable<string>> GetKeysAsync(string languageCode)
        {
            if (string.IsNullOrWhiteSpace(languageCode))
            {
                return Task.FromResult(Enumerable.Empty<string>());
            }

            lock (syncLock)
            {
                if (!translations.ContainsKey(languageCode))
                {
                    return Task.FromResult(Enumerable.Empty<string>());
                }

                var keys = translations[languageCode].Keys.ToList();
                return Task.FromResult<IEnumerable<string>>(keys);
            }
        }
    }
}

