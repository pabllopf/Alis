

using System.Diagnostics.CodeAnalysis;
using Alis.Extension.Language.Translator.Abstractions;

namespace Alis.Extension.Language.Translator
{
    /// <summary>
    ///     The language class representing a language with code, name and culture information
    /// </summary>
    /// <remarks>
    ///     This class implements the ILanguage interface and provides a concrete implementation
    ///     for managing language metadata including language codes, display names, and culture information.
    /// </remarks>
    public sealed class Lang : ILanguage
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Lang" /> class
        /// </summary>
        [ExcludeFromCodeCoverage]
        public Lang() => IsDefault = false;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Lang" /> class with code and name
        /// </summary>
        /// <param name="code">The language code</param>
        /// <param name="name">The display name</param>
        public Lang(string code, string name)
        {
            Code = code;
            Name = name;
            IsDefault = false;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Lang" /> class with all properties
        /// </summary>
        /// <param name="code">The language code</param>
        /// <param name="name">The display name</param>
        /// <param name="nativeName">The native name of the language</param>
        /// <param name="cultureCode">The culture code</param>
        /// <param name="isDefault">Whether this is the default language</param>
        [ExcludeFromCodeCoverage]
        public Lang(string code, string name, string nativeName, string cultureCode, bool isDefault = false)
        {
            Code = code;
            Name = name;
            NativeName = nativeName;
            CultureCode = cultureCode;
            IsDefault = isDefault;
        }

        /// <summary>
        ///     Gets or sets the display name of the language
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the language code (e.g., 'en', 'es', 'fr')
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the native name of the language (e.g., 'English', 'Español', 'Français')
        /// </summary>
        public string NativeName { get; set; }

        /// <summary>
        ///     Gets or sets the culture code for this language (e.g., 'en-US', 'es-ES')
        /// </summary>
        public string CultureCode { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this is the default language
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        ///     Determines whether the specified language is equal to the current language
        /// </summary>
        /// <param name="other">The language to compare with</param>
        /// <returns>True if the languages are equal; otherwise, false</returns>
        [ExcludeFromCodeCoverage]
        public bool Equals(ILanguage other)
        {
            if (other == null)
            {
                return false;
            }

            return (Code == other.Code) && (Name == other.Name);
        }

        /// <summary>
        ///     Determines whether the specified object is equal to the current language
        /// </summary>
        /// <param name="obj">The object to compare with</param>
        /// <returns>True if the objects are equal; otherwise, false</returns>
        [ExcludeFromCodeCoverage]
        public override bool Equals(object obj)
        {
            if (obj is Lang lang)
            {
                return Equals(lang);
            }

            return false;
        }

        /// <summary>
        ///     Gets the hash code for this language
        /// </summary>
        /// <returns>The hash code</returns>
        [ExcludeFromCodeCoverage]
        public override int GetHashCode()
        {
            unchecked
            {
                return ((Code?.GetHashCode() ?? 0) * 397) ^ (Name?.GetHashCode() ?? 0);
            }
        }

        /// <summary>
        ///     Returns a string representation of the language
        /// </summary>
        /// <returns>A string containing the language code and name</returns>
        [ExcludeFromCodeCoverage]
        public override string ToString() => $"{Code} - {Name}";
    }
}