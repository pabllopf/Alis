// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ITranslationCache.cs
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

namespace Alis.Extension.Language.Translator
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

