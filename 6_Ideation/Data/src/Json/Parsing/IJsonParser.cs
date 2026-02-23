// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: IJsonParser.cs
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

using System.Collections.Generic;

namespace Alis.Core.Aspect.Data.Json.Parsing
{
    /// <summary>
    ///     Defines a contract for parsing JSON strings into a dictionary of properties.
    /// </summary>
    public interface IJsonParser
    {
        /// <summary>
        ///     Parses a JSON string into a dictionary of property names and their string values.
        /// </summary>
        /// <param name="json">The JSON string to parse.</param>
        /// <returns>A dictionary containing property names as keys and their string representations as values.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when json is null.</exception>
        Dictionary<string, string> ParseToDictionary(string json);
    }
}

