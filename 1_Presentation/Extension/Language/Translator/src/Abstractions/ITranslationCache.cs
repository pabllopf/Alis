

namespace Alis.Extension.Language.Translator.Abstractions
{
    /// <summary>
    ///     Interface that defines the contract for a translation cache
    /// </summary>
    /// <remarks>
    ///     Translation caches improve performance by storing frequently accessed
    ///     translations in memory.
    /// </remarks>
    public interface ITranslationCache
    {
        /// <summary>
        ///     Gets a translation from the cache
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <param name="key">The translation key</param>
        /// <param name="value">The cached translation, or null if not found</param>
        /// <returns>True if the translation was found in cache; otherwise, false</returns>
        bool TryGetTranslation(string languageCode, string key, out string value);

        /// <summary>
        ///     Adds or updates a translation in the cache
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <param name="key">The translation key</param>
        /// <param name="value">The translated text</param>
        void Set(string languageCode, string key, string value);

        /// <summary>
        ///     Removes a translation from the cache
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <param name="key">The translation key</param>
        /// <returns>True if the translation was removed; otherwise, false</returns>
        bool Remove(string languageCode, string key);

        /// <summary>
        ///     Invalidates all cache entries for a specific language
        /// </summary>
        /// <param name="languageCode">The language code</param>
        void InvalidateLanguage(string languageCode);

        /// <summary>
        ///     Clears all cached translations
        /// </summary>
        void Clear();
    }
}