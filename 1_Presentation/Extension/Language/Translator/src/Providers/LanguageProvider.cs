// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LanguageProvider.cs
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
        public IReadOnlyList<ILanguage> GetAvailableLanguages()
        {
            return languages.AsReadOnly();
        }

        /// <summary>
        ///     Adds a new language
        /// </summary>
        /// <param name="language">The language to add</param>
        /// <exception cref="ArgumentNullException">Thrown when language is null</exception>
        /// <exception cref="InvalidOperationException">Thrown when language with same code already exists</exception>
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
        public bool LanguageExists(string code)
        {
            return GetLanguageByCode(code) != null;
        }
    }
}

