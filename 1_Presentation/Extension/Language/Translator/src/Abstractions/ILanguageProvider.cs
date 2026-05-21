

using System.Collections.Generic;

namespace Alis.Extension.Language.Translator.Abstractions
{
    /// <summary>
    ///     Interface that defines the contract for a language provider
    /// </summary>
    /// <remarks>
    ///     Language providers are responsible for managing available languages
    ///     in the system.
    /// </remarks>
    public interface ILanguageProvider
    {
        /// <summary>
        ///     Gets all available languages
        /// </summary>
        /// <returns>A collection of available languages</returns>
        IReadOnlyList<ILanguage> GetAvailableLanguages();

        /// <summary>
        ///     Adds a new language
        /// </summary>
        /// <param name="language">The language to add</param>
        void AddLanguage(ILanguage language);

        /// <summary>
        ///     Removes a language
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <returns>True if the language was removed; otherwise, false</returns>
        bool RemoveLanguage(string languageCode);

        /// <summary>
        ///     Gets a language by its code
        /// </summary>
        /// <param name="code">The language code</param>
        /// <returns>The language, or null if not found</returns>
        ILanguage GetLanguageByCode(string code);

        /// <summary>
        ///     Determines whether a language with the specified code exists
        /// </summary>
        /// <param name="code">The language code</param>
        /// <returns>True if the language exists; otherwise, false</returns>
        bool LanguageExists(string code);
    }
}