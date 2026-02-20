// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ITranslationProvider.cs
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
using System.Threading.Tasks;

namespace Alis.Extension.Language.Translator
{
    /// <summary>
    ///     Interface that defines the contract for a translation provider
    /// </summary>
    /// <remarks>
    ///     Translation providers are responsible for loading and managing translations
    ///     from various sources such as files, databases, or remote services.
    /// </remarks>
    public interface ITranslationProvider
    {
        /// <summary>
        ///     Gets the name of this provider
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     Loads all translations from the source
        /// </summary>
        /// <returns>A dictionary mapping language codes to their translations</returns>
        Task<Dictionary<string, Dictionary<string, string>>> LoadTranslationsAsync();

        /// <summary>
        ///     Saves the translations to the source
        /// </summary>
        /// <param name="translations">The translations to save</param>
        /// <returns>A task representing the asynchronous operation</returns>
        Task SaveTranslationsAsync(Dictionary<string, Dictionary<string, string>> translations);

        /// <summary>
        ///     Gets a translation for a specific key and language code
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <param name="key">The translation key</param>
        /// <returns>The translated text, or null if not found</returns>
        Task<string> GetTranslationAsync(string languageCode, string key);

        /// <summary>
        ///     Adds or updates a translation
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <param name="key">The translation key</param>
        /// <param name="value">The translated text</param>
        /// <returns>A task representing the asynchronous operation</returns>
        Task SetTranslationAsync(string languageCode, string key, string value);

        /// <summary>
        ///     Removes a translation
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <param name="key">The translation key</param>
        /// <returns>A task representing the asynchronous operation</returns>
        Task RemoveTranslationAsync(string languageCode, string key);

        /// <summary>
        ///     Gets all translation keys for a specific language
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <returns>A list of translation keys</returns>
        Task<IEnumerable<string>> GetKeysAsync(string languageCode);
    }
}

