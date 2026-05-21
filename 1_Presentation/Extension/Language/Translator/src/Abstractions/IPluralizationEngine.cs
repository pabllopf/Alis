

using System;

namespace Alis.Extension.Language.Translator.Abstractions
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