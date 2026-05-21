

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Alis.Extension.Language.Translator.Abstractions;

namespace Alis.Extension.Language.Translator.Pluralization
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
        ///     Dictionary of plural form counts by language code
        /// </summary>
        private readonly Dictionary<string, int> pluralFormCounts = new Dictionary<string, int>();

        /// <summary>
        ///     Dictionary of pluralization rules by language code
        /// </summary>
        private readonly Dictionary<string, Func<int, int>> pluralRules = new Dictionary<string, Func<int, int>>();

        /// <summary>
        ///     Initializes a new instance of the <see cref="PluralizationEngine" /> class
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
        [ExcludeFromCodeCoverage]
        public int GetPluralForm(string languageCode, int quantity)
        {
            if (string.IsNullOrWhiteSpace(languageCode))
            {
                throw new ArgumentException("Language code cannot be null or empty", nameof(languageCode));
            }

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
        [ExcludeFromCodeCoverage]
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
        [ExcludeFromCodeCoverage]
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
        [ExcludeFromCodeCoverage]
        private void InitializeDefaultRules()
        {
            Func<int, int> englishRule = quantity => quantity == 1 ? 0 : 1;
            RegisterPluralizationRule("en", englishRule);
            pluralFormCounts["en"] = 2;

            RegisterPluralizationRule("es", englishRule);
            pluralFormCounts["es"] = 2;

            RegisterPluralizationRule("fr", englishRule);
            pluralFormCounts["fr"] = 2;

            RegisterPluralizationRule("de", englishRule);
            pluralFormCounts["de"] = 2;

            RegisterPluralizationRule("pt", englishRule);
            pluralFormCounts["pt"] = 2;

            RegisterPluralizationRule("it", englishRule);
            pluralFormCounts["it"] = 2;

            Func<int, int> russianRule = quantity =>
            {
                quantity = Math.Abs(quantity) % 100;
                int tens = quantity % 10;

                if ((quantity >= 11) && (quantity <= 19))
                {
                    return 2;
                }

                if (tens == 1)
                {
                    return 0;
                }

                if ((tens >= 2) && (tens <= 4))
                {
                    return 1;
                }

                return 2;
            };
            RegisterPluralizationRule("ru", russianRule);
            pluralFormCounts["ru"] = 3;

            Func<int, int> polishRule = quantity =>
            {
                if (quantity == 1)
                {
                    return 0;
                }

                int tens = Math.Abs(quantity) % 10;
                if ((tens >= 2) && (tens <= 4))
                {
                    return 1;
                }

                return 2;
            };
            RegisterPluralizationRule("pl", polishRule);
            pluralFormCounts["pl"] = 3;

            Func<int, int> noPluralizationRule = quantity => 0;
            RegisterPluralizationRule("ja", noPluralizationRule);
            pluralFormCounts["ja"] = 1;

            RegisterPluralizationRule("ko", noPluralizationRule);
            pluralFormCounts["ko"] = 1;

            RegisterPluralizationRule("zh", noPluralizationRule);
            pluralFormCounts["zh"] = 1;
        }
    }
}