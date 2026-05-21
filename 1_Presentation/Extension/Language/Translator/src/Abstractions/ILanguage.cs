

using System;

namespace Alis.Extension.Language.Translator.Abstractions
{
    /// <summary>
    ///     Interface that defines the contract for a language
    /// </summary>
    public interface ILanguage : IEquatable<ILanguage>
    {
        /// <summary>
        ///     Gets the name of the language
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     Gets the language code (e.g., 'en', 'es', 'fr')
        /// </summary>
        string Code { get; }

        /// <summary>
        ///     Gets the native name of the language (e.g., 'English', 'Español', 'Français')
        /// </summary>
        string NativeName { get; }

        /// <summary>
        ///     Gets the culture information for this language (e.g., 'en-US', 'es-ES')
        /// </summary>
        string CultureCode { get; }

        /// <summary>
        ///     Gets a value indicating whether this language is the default language
        /// </summary>
        bool IsDefault { get; }
    }
}