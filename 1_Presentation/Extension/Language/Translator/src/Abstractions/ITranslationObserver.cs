// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ITranslationObserver.cs
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
    ///     Interface that defines the contract for observing translation events
    /// </summary>
    /// <remarks>
    ///     Observers are notified when important translation events occur,
    ///     such as language changes or translation updates.
    /// </remarks>
    public interface ITranslationObserver
    {
        /// <summary>
        ///     Called when the current language has changed
        /// </summary>
        /// <param name="language">The newly selected language</param>
        void OnLanguageChanged(ILanguage language);

        /// <summary>
        ///     Called when translations have been updated
        /// </summary>
        /// <param name="languageCode">The language code that was updated</param>
        void OnTranslationsUpdated(string languageCode);

        /// <summary>
        ///     Called when a translation is requested but not found
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <param name="key">The translation key that was not found</param>
        void OnTranslationNotFound(string languageCode, string key);
    }
}

