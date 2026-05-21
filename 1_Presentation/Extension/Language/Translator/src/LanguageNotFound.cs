

using System;
using System.Diagnostics.CodeAnalysis;

namespace Alis.Extension.Language.Translator
{
    /// <summary>
    ///     The language not found class
    /// </summary>
    /// <seealso cref="Exception" />
    [ExcludeFromCodeCoverage]
    public class LanguageNotFound : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LanguageNotFound" /> class
        /// </summary>
        /// <param name="message">The message</param>
        public LanguageNotFound(string message) : base(message)
        {
        }
    }
}