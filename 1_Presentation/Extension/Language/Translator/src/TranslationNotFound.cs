

using System;

namespace Alis.Extension.Language.Translator
{
    /// <summary>
    ///     The translation not found class
    /// </summary>
    /// <seealso cref="Exception" />
    public class TranslationNotFound : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TranslationNotFound" /> class
        /// </summary>
        /// <param name="key">The key</param>
        public TranslationNotFound(string key) : base($"Translation not found for key: {key}")
        {
        }
    }
}