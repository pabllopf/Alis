// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ScoresClass.cs
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

using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Class with list of integers
    /// </summary>
    public class ScoresClass : IJsonSerializable, IJsonDesSerializable<ScoresClass>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ScoresClass" /> class
        /// </summary>
        public ScoresClass() => Scores = new List<int>();

        /// <summary>
        ///     Gets or sets the value of the player name
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        ///     Gets or sets the value of the scores
        /// </summary>
        public List<int> Scores { get; set; }

        /// <summary>
        ///     Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The obj</returns>
        public ScoresClass CreateFromProperties(Dictionary<string, string> properties)
        {
            ScoresClass obj = new ScoresClass();
            if (properties.TryGetValue(nameof(PlayerName), out string name))
            {
                obj.PlayerName = name;
            }

            if (properties.TryGetValue(nameof(Scores), out string scoresJson))
            {
                string[] items = scoresJson.Trim('[', ']').Split(',');
                foreach (string item in items)
                {
                    if (int.TryParse(item.Trim(), out int score))
                    {
                        obj.Scores.Add(score);
                    }
                }
            }

            return obj;
        }

        /// <summary>
        ///     Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(PlayerName), PlayerName);
            string scoresJson = "[" + string.Join(",", Scores) + "]";
            yield return (nameof(Scores), scoresJson);
        }
    }
}