

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Alis.Extension.Language.Translator.Abstractions;

namespace Alis.Extension.Language.Translator.Cache
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
        [ExcludeFromCodeCoverage]
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

                Dictionary<string, string> languageDict = cache[languageCode];
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
        [ExcludeFromCodeCoverage]
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
        [ExcludeFromCodeCoverage]
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
        [ExcludeFromCodeCoverage]
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