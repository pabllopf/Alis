// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IEscapeSequenceHandler.cs
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

namespace Alis.Core.Aspect.Data.Json.Helpers
{
    /// <summary>
    ///     Defines a contract for handling JSON escape sequences within string values.
    ///     Implementing types provide logic to detect escaped characters (by counting preceding
    ///     backslashes) and to resolve standard JSON escape sequences into their actual characters.
    /// </summary>
    /// <remarks>
    ///     This interface is consumed by the JSON parser (<see cref="IJsonParser" />) to correctly
    ///     interpret quoted strings during parsing. The two responsibilities are:
    ///     (1) Escaped-character detection via <see cref="IsEscaped" /> to distinguish literal quotes
    ///     from escaped quotes inside a string, and (2) unescaping via <see cref="Unescape" /> to
    ///     convert escape sequences into their actual character values after extraction.
    /// </remarks>
    public interface IEscapeSequenceHandler
    {
        /// <summary>
        ///     Determines whether the character at the specified position within the text is escaped
        ///     by an odd number of consecutive preceding backslash characters.
        /// </summary>
        /// <param name="text">The text string to examine. Must not be null.</param>
        /// <param name="position">The zero-based index of the character to inspect for escaping.</param>
        /// <returns>
        ///     <c>true</c> if the character is preceded by an odd number of backslashes (i.e., it is
        ///     escaped); otherwise, <c>false</c>. Implementations should return <c>false</c> for
        ///     out-of-range positions.
        /// </returns>
        bool IsEscaped(string text, int position);

        /// <summary>
        ///     Unescapes a JSON-escaped string by replacing recognized escape sequences
        ///     (e.g., \n, \t, \", \\, \uXXXX) with their actual character representations.
        /// </summary>
        /// <param name="escapedString">The JSON-escaped string to process. Must not be null.</param>
        /// <returns>
        ///     A new string with all escape sequences resolved to their corresponding characters.
        ///     If the input contains no backslash characters, implementations should return the
        ///     original string unchanged.
        /// </returns>
        string Unescape(string escapedString);
    }
}