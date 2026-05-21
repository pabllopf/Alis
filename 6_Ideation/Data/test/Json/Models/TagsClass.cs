// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TagsClass.cs
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
using System.Linq;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Class with list of strings
    /// </summary>
    public class TagsClass : IJsonSerializable, IJsonDesSerializable<TagsClass>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TagsClass" /> class
        /// </summary>
        public TagsClass() => Tags = new List<string>();

        /// <summary>
        ///     Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the value of the tags
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        ///     Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The obj</returns>
        public TagsClass CreateFromProperties(Dictionary<string, string> properties)
        {
            TagsClass obj = new TagsClass();
            if (properties.TryGetValue(nameof(Name), out string name))
            {
                obj.Name = name;
            }

            if (properties.TryGetValue(nameof(Tags), out string tagsJson))
            {
                string[] items = tagsJson.Trim('[', ']').Split(',');
                foreach (string item in items)
                {
                    string tag = item.Trim().Trim('"');
                    if (!string.IsNullOrEmpty(tag))
                    {
                        obj.Tags.Add(tag);
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
            yield return (nameof(Name), Name);
            string tagsJson = "[" + string.Join(",", Tags.Select(t => $"\"{t}\"")) + "]";
            yield return (nameof(Tags), tagsJson);
        }
    }
}