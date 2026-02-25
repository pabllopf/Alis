// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: EscapeSequenceHandler.cs
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

using System;
using System.Globalization;
using System.Text;

namespace Alis.Core.Aspect.Data.Json.Helpers
{
    /// <summary>
    ///     Handles JSON escape sequences in strings.
    /// </summary>
    public sealed class EscapeSequenceHandler : IEscapeSequenceHandler
    {
        /// <summary>
        ///     Determines if a character at the specified position is escaped.
        /// </summary>
        /// <param name="text">The text to check.</param>
        /// <param name="position">The position of the character to check.</param>
        /// <returns>True if the character is escaped; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Thrown when text is null.</exception>
        public bool IsEscaped(string text, int position)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (position < 0 || position >= text.Length)
            {
                return false;
            }

            int backslashCount = 0;
            int checkPosition = position - 1;

            while (checkPosition >= 0 && text[checkPosition] == '\\')
            {
                backslashCount++;
                checkPosition--;
            }

            return backslashCount % 2 == 1;
        }

        /// <summary>
        ///     Unescapes a JSON string by replacing escape sequences with their actual characters.
        /// </summary>
        /// <param name="escapedString">The escaped string.</param>
        /// <returns>The unescaped string.</returns>
        /// <exception cref="ArgumentNullException">Thrown when escapedString is null.</exception>
        public string Unescape(string escapedString)
        {
            if (escapedString == null)
            {
                throw new ArgumentNullException(nameof(escapedString));
            }

            if (!escapedString.Contains("\\"))
            {
                return escapedString;
            }

            StringBuilder result = new StringBuilder(escapedString.Length);

            for (int i = 0; i < escapedString.Length; i++)
            {
                if (escapedString[i] == '\\' && i + 1 < escapedString.Length)
                {
                    char nextChar = escapedString[i + 1];

                    switch (nextChar)
                    {
                        case '"':
                            result.Append('"');
                            i++;
                            break;
                        case '\\':
                            result.Append('\\');
                            i++;
                            break;
                        case '/':
                            result.Append('/');
                            i++;
                            break;
                        case 'b':
                            result.Append('\b');
                            i++;
                            break;
                        case 'f':
                            result.Append('\f');
                            i++;
                            break;
                        case 'n':
                            result.Append('\n');
                            i++;
                            break;
                        case 'r':
                            result.Append('\r');
                            i++;
                            break;
                        case 't':
                            result.Append('\t');
                            i++;
                            break;
                        case 'u':
                            if (i + 5 < escapedString.Length)
                            {
                                string hexCode = escapedString.Substring(i + 2, 4);
                                if (int.TryParse(hexCode, NumberStyles.HexNumber, null, out int codePoint))
                                {
                                    result.Append((char)codePoint);
                                    i += 5;
                                }
                                else
                                {
                                    result.Append(nextChar);
                                    i++;
                                }
                            }
                            else
                            {
                                result.Append(nextChar);
                                i++;
                            }

                            break;
                        default:
                            result.Append(nextChar);
                            i++;
                            break;
                    }
                }
                else
                {
                    result.Append(escapedString[i]);
                }
            }

            return result.ToString();
        }
    }
}

