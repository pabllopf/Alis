// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ILanguageProvider.cs
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

using System.Collections.Generic;

namespace Alis.Extension.Language.Translator
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

