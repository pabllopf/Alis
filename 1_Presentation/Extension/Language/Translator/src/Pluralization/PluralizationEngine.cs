// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PluralizationEngine.cs
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

namespace Alis.Extension.Language.Translator
{
    /// <summary>
    ///     Default implementation of the pluralization engine
    /// </summary>
    /// <remarks>
    ///     This engine handles pluralization rules for different languages.
    ///     It provides built-in rules for common languages and allows registering custom rules.
    /// </remarks>
    public class PluralizationEngine : IPluralizationEngine
    {
        /// <summary>
        ///     Dictionary of pluralization rules by language code
        /// </summary>
        private readonly Dictionary<string, Func<int, int>> pluralRules = new Dictionary<string, Func<int, int>>();

        /// <summary>
        ///     Dictionary of plural form counts by language code
        /// </summary>
        private readonly Dictionary<string, int> pluralFormCounts = new Dictionary<string, int>();

        /// <summary>
        ///     Initializes a new instance of the <see cref="PluralizationEngine"/> class
        /// </summary>
        public PluralizationEngine()
        {
            InitializeDefaultRules();
        }

        /// <summary>
        ///     Gets the plural form based on the quantity and language
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <param name="quantity">The quantity to determine plural form for</param>
        /// <returns>The plural form index (0 = singular, 1 = plural, etc.)</returns>
        public int GetPluralForm(string languageCode, int quantity)
        {
            if (string.IsNullOrWhiteSpace(languageCode))
            {
                throw new ArgumentException("Language code cannot be null or empty", nameof(languageCode));
            }

            // Default English rule if not found
            if (!pluralRules.ContainsKey(languageCode))
            {
                return quantity == 1 ? 0 : 1;
            }

            return pluralRules[languageCode](quantity);
        }

        /// <summary>
        ///     Registers custom pluralization rules for a language
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <param name="rule">The pluralization rule function</param>
        public void RegisterPluralizationRule(string languageCode, Func<int, int> rule)
        {
            if (string.IsNullOrWhiteSpace(languageCode))
            {
                throw new ArgumentException("Language code cannot be null or empty", nameof(languageCode));
            }

            if (rule == null)
            {
                throw new ArgumentNullException(nameof(rule), "Pluralization rule cannot be null");
            }

            pluralRules[languageCode] = rule;
        }

        /// <summary>
        ///     Gets the number of plural forms for a language
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <returns>The number of plural forms</returns>
        public int GetPluralFormCount(string languageCode)
        {
            if (string.IsNullOrWhiteSpace(languageCode))
            {
                throw new ArgumentException("Language code cannot be null or empty", nameof(languageCode));
            }

            return pluralFormCounts.ContainsKey(languageCode) ? pluralFormCounts[languageCode] : 2;
        }

        /// <summary>
        ///     Initializes the default pluralization rules for common languages
        /// </summary>
        private void InitializeDefaultRules()
        {
            // English, German, Dutch, etc. - 2 forms (singular, plural)
            Func<int, int> englishRule = (int quantity) => quantity == 1 ? 0 : 1;
            RegisterPluralizationRule("en", englishRule);
            pluralFormCounts["en"] = 2;

            // Spanish - 2 forms (singular, plural)
            RegisterPluralizationRule("es", englishRule);
            pluralFormCounts["es"] = 2;

            // French - 2 forms (singular, plural)
            RegisterPluralizationRule("fr", englishRule);
            pluralFormCounts["fr"] = 2;

            // German - 2 forms (singular, plural)
            RegisterPluralizationRule("de", englishRule);
            pluralFormCounts["de"] = 2;

            // Portuguese - 2 forms (singular, plural)
            RegisterPluralizationRule("pt", englishRule);
            pluralFormCounts["pt"] = 2;

            // Italian - 2 forms (singular, plural)
            RegisterPluralizationRule("it", englishRule);
            pluralFormCounts["it"] = 2;

            // Russian - 3 forms (1, 21, 101...), (2-4, 22-24...), (0, 5-20, 25-30...)
            Func<int, int> russianRule = (int quantity) =>
            {
                quantity = Math.Abs(quantity) % 100;
                int tens = quantity % 10;

                if (quantity >= 11 && quantity <= 19)
                {
                    return 2;
                }

                if (tens == 1)
                {
                    return 0;
                }

                if (tens >= 2 && tens <= 4)
                {
                    return 1;
                }

                return 2;
            };
            RegisterPluralizationRule("ru", russianRule);
            pluralFormCounts["ru"] = 3;

            // Polish - 3 forms
            Func<int, int> polishRule = (int quantity) =>
            {
                if (quantity == 1)
                {
                    return 0;
                }

                int tens = Math.Abs(quantity) % 10;
                if (tens >= 2 && tens <= 4)
                {
                    return 1;
                }

                return 2;
            };
            RegisterPluralizationRule("pl", polishRule);
            pluralFormCounts["pl"] = 3;

            // Japanese, Korean, Chinese - 1 form (no pluralization)
            Func<int, int> noPluralizationRule = (int quantity) => 0;
            RegisterPluralizationRule("ja", noPluralizationRule);
            pluralFormCounts["ja"] = 1;

            RegisterPluralizationRule("ko", noPluralizationRule);
            pluralFormCounts["ko"] = 1;

            RegisterPluralizationRule("zh", noPluralizationRule);
            pluralFormCounts["zh"] = 1;
        }
    }
}

