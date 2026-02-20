// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IPluralizationEngine.cs
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
    ///     Interface that defines the contract for a pluralization engine
    /// </summary>
    /// <remarks>
    ///     Pluralization engines handle the rules for converting translations
    ///     based on quantity and language-specific pluralization rules.
    /// </remarks>
    public interface IPluralizationEngine
    {
        /// <summary>
        ///     Gets the plural form based on the quantity and language
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <param name="quantity">The quantity to determine plural form for</param>
        /// <returns>The plural form index (0 = singular, 1 = plural, etc.)</returns>
        int GetPluralForm(string languageCode, int quantity);

        /// <summary>
        ///     Registers custom pluralization rules for a language
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <param name="rule">The pluralization rule function that takes quantity and returns plural form index</param>
        void RegisterPluralizationRule(string languageCode, Func<int, int> rule);

        /// <summary>
        ///     Gets the number of plural forms for a language
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <returns>The number of plural forms</returns>
        int GetPluralFormCount(string languageCode);
    }
}

