

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Alis.Extension.Language.Translator.Abstractions;

namespace Alis.Extension.Language.Translator.Providers
{
    /// <summary>
    ///     Default implementation of the language provider
    /// </summary>
    /// <remarks>
    ///     This provider manages a collection of languages in memory.
    ///     It is suitable for most applications that have a predefined set of supported languages.
    /// </remarks>
    public class LanguageProvider : ILanguageProvider
    {
        /// <summary>
        ///     The collection of available languages
        /// </summary>
        private readonly List<ILanguage> languages = new List<ILanguage>();

        /// <summary>
        ///     Gets all available languages
        /// </summary>
        /// <returns>A read-only collection of available languages</returns>
        public IReadOnlyList<ILanguage> GetAvailableLanguages() => languages.AsReadOnly();

        /// <summary>
        ///     Adds a new language
        /// </summary>
        /// <param name="language">The language to add</param>
        /// <exception cref="ArgumentNullException">Thrown when language is null</exception>
        /// <exception cref="InvalidOperationException">Thrown when language with same code already exists</exception>
        [ExcludeFromCodeCoverage]
        public void AddLanguage(ILanguage language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(nameof(language), "Language cannot be null");
            }

            if (language.Code == null)
            {
                throw new ArgumentException("Language code cannot be null", nameof(language));
            }

            if (languages.Any(l => l.Code == language.Code))
            {
                throw new InvalidOperationException($"Language with code '{language.Code}' already exists");
            }

            languages.Add(language);
        }

        /// <summary>
        ///     Removes a language
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <returns>True if the language was removed; otherwise, false</returns>
        [ExcludeFromCodeCoverage]
        public bool RemoveLanguage(string languageCode)
        {
            if (string.IsNullOrWhiteSpace(languageCode))
            {
                return false;
            }

            ILanguage language = languages.FirstOrDefault(l => l.Code == languageCode);
            if (language == null)
            {
                return false;
            }

            return languages.Remove(language);
        }

        /// <summary>
        ///     Gets a language by its code
        /// </summary>
        /// <param name="code">The language code</param>
        /// <returns>The language, or null if not found</returns>
        [ExcludeFromCodeCoverage]
        public ILanguage GetLanguageByCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return null;
            }

            return languages.FirstOrDefault(l => l.Code == code);
        }

        /// <summary>
        ///     Determines whether a language with the specified code exists
        /// </summary>
        /// <param name="code">The language code</param>
        /// <returns>True if the language exists; otherwise, false</returns>
        public bool LanguageExists(string code) => GetLanguageByCode(code) != null;
    }
}