// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Lang.cs
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

namespace Alis.Extension.Language.Translator
{
    /// <summary>
    ///     The language class representing a language with code, name and culture information
    /// </summary>
    /// <remarks>
    ///     This class implements the ILanguage interface and provides a concrete implementation
    ///     for managing language metadata including language codes, display names, and culture information.
    /// </remarks>
    public class Lang : ILanguage
    {
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
        ///     Initializes a new instance of the <see cref="Lang"/> class
        /// </summary>
        public Lang()
        {
            IsDefault = false;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Lang"/> class with code and name
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
        ///     Initializes a new instance of the <see cref="Lang"/> class with all properties
        /// </summary>
        /// <param name="code">The language code</param>
        /// <param name="name">The display name</param>
        /// <param name="nativeName">The native name of the language</param>
        /// <param name="cultureCode">The culture code</param>
        /// <param name="isDefault">Whether this is the default language</param>
        public Lang(string code, string name, string nativeName, string cultureCode, bool isDefault = false)
        {
            Code = code;
            Name = name;
            NativeName = nativeName;
            CultureCode = cultureCode;
            IsDefault = isDefault;
        }

        /// <summary>
        ///     Determines whether the specified language is equal to the current language
        /// </summary>
        /// <param name="other">The language to compare with</param>
        /// <returns>True if the languages are equal; otherwise, false</returns>
        public bool Equals(ILanguage other)
        {
            if (other == null)
            {
                return false;
            }

            return Code == other.Code && Name == other.Name;
        }

        /// <summary>
        ///     Determines whether the specified object is equal to the current language
        /// </summary>
        /// <param name="obj">The object to compare with</param>
        /// <returns>True if the objects are equal; otherwise, false</returns>
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
        public override string ToString()
        {
            return $"{Code} - {Name}";
        }
    }
}