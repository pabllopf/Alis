// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MemoryTranslationCache.cs
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

namespace Alis.Extension.Language.Translator
{
    /// <summary>
    ///     In-memory implementation of the translation cache
    /// </summary>
    /// <remarks>
    ///     This cache stores translations in memory using nested dictionaries.
    ///     It is suitable for small to medium-sized applications with a limited number of translations.
    /// </remarks>
    public class MemoryTranslationCache : ITranslationCache
    {
        /// <summary>
        ///     The cache dictionary structure: {languageCode -> {key -> value}}
        /// </summary>
        private readonly Dictionary<string, Dictionary<string, string>> cache =
            new Dictionary<string, Dictionary<string, string>>();

        /// <summary>
        ///     The lock object for thread-safe operations
        /// </summary>
        private readonly object syncLock = new object();

        /// <summary>
        ///     Gets a translation from the cache
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <param name="key">The translation key</param>
        /// <param name="value">The cached translation, or null if not found</param>
        /// <returns>True if the translation was found in cache; otherwise, false</returns>
        public bool TryGetTranslation(string languageCode, string key, out string value)
        {
            value = null;

            if (string.IsNullOrWhiteSpace(languageCode) || string.IsNullOrWhiteSpace(key))
            {
                return false;
            }

            lock (syncLock)
            {
                if (!cache.ContainsKey(languageCode))
                {
                    return false;
                }

                var languageDict = cache[languageCode];
                if (languageDict.ContainsKey(key))
                {
                    value = languageDict[key];
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        ///     Adds or updates a translation in the cache
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <param name="key">The translation key</param>
        /// <param name="value">The translated text</param>
        public void Set(string languageCode, string key, string value)
        {
            if (string.IsNullOrWhiteSpace(languageCode) || string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Language code and key cannot be null or empty");
            }

            lock (syncLock)
            {
                if (!cache.ContainsKey(languageCode))
                {
                    cache[languageCode] = new Dictionary<string, string>();
                }

                cache[languageCode][key] = value ?? string.Empty;
            }
        }

        /// <summary>
        ///     Removes a translation from the cache
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <param name="key">The translation key</param>
        /// <returns>True if the translation was removed; otherwise, false</returns>
        public bool Remove(string languageCode, string key)
        {
            if (string.IsNullOrWhiteSpace(languageCode) || string.IsNullOrWhiteSpace(key))
            {
                return false;
            }

            lock (syncLock)
            {
                if (!cache.ContainsKey(languageCode))
                {
                    return false;
                }

                return cache[languageCode].Remove(key);
            }
        }

        /// <summary>
        ///     Invalidates all cache entries for a specific language
        /// </summary>
        /// <param name="languageCode">The language code</param>
        public void InvalidateLanguage(string languageCode)
        {
            if (string.IsNullOrWhiteSpace(languageCode))
            {
                return;
            }

            lock (syncLock)
            {
                if (cache.ContainsKey(languageCode))
                {
                    cache[languageCode].Clear();
                }
            }
        }

        /// <summary>
        ///     Clears all cached translations
        /// </summary>
        public void Clear()
        {
            lock (syncLock)
            {
                cache.Clear();
            }
        }
    }
}

