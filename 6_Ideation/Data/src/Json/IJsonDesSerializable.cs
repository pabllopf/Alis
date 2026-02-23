// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IJsonDesSerializable.cs
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

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     Defines a contract for objects that can be deserialized from JSON format.
    /// </summary>
    /// <typeparam name="T">The type being deserialized.</typeparam>
    /// <remarks>
    ///     Types implementing this interface can reconstruct themselves from a property dictionary
    ///     created by the JSON parser.
    ///     
    ///     Usage Pattern:
    ///     Classes should implement this interface to support JSON deserialization through the
    ///     JsonNativeAot.Deserialize&lt;T&gt; method. For complete bidirectional support,
    ///     also implement IJsonSerializable.
    ///     
    ///     The class must have a parameterless constructor as required by the generic constraint.
    /// </remarks>
    public interface IJsonDesSerializable<out T>
    {
        /// <summary>
        ///     Creates an instance of type T populated with data from the provided properties.
        /// </summary>
        /// <param name="properties">A dictionary containing property names and their string values.</param>
        /// <returns>A fully initialized instance of type T.</returns>
        /// <remarks>
        ///     Implementation Guide:
        ///     - Create a new instance and populate its properties from the dictionary
        ///     - Use TryGetValue to safely access properties (they may be missing or null)
        ///     - Handle type conversions (string to int, bool, DateTime, etc.)
        ///     - Provide sensible defaults for missing properties
        ///     - Complex properties will be returned as raw JSON strings from the parser
        ///     
        ///     Time Complexity: Should be O(n) where n is the number of properties.
        ///     
        ///     Example:
        ///     <code>
        ///     public class Person : IJsonSerializable, IJsonDesSerializable&lt;Person&gt;
        ///     {
        ///         public string Name { get; set; }
        ///         public int Age { get; set; }
        ///         
        ///         public Person CreateFromProperties(Dictionary&lt;string, string&gt; properties)
        ///         {
        ///             var person = new Person();
        ///             
        ///             if (properties.TryGetValue("Name", out var name))
        ///                 person.Name = name;
        ///             
        ///             if (properties.TryGetValue("Age", out var age) && int.TryParse(age, out var ageValue))
        ///                 person.Age = ageValue;
        ///             
        ///             return person;
        ///         }
        ///     }
        ///     </code>
        /// </remarks>
        /// <exception cref="System.ArgumentException">May be thrown if properties are invalid.</exception>
        T CreateFromProperties(Dictionary<string, string> properties);
    }
}