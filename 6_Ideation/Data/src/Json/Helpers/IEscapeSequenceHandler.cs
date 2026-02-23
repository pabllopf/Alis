// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: IEscapeSequenceHandler.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web: https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

namespace Alis.Core.Aspect.Data.Json.Helpers
{
    /// <summary>
    ///     Defines a contract for handling JSON escape sequences.
    /// </summary>
    public interface IEscapeSequenceHandler
    {
        /// <summary>
        ///     Determines if a quote character at the specified position is escaped.
        /// </summary>
        /// <param name="text">The text to check.</param>
        /// <param name="position">The position of the character to check.</param>
        /// <returns>True if the character is escaped; otherwise, false.</returns>
        bool IsEscaped(string text, int position);

        /// <summary>
        ///     Unescapes a JSON string by replacing escape sequences with their actual characters.
        /// </summary>
        /// <param name="escapedString">The escaped string.</param>
        /// <returns>The unescaped string.</returns>
        string Unescape(string escapedString);
    }
}

