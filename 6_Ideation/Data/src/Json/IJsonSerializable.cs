// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IJsonSerializable.cs
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
    ///     Defines a contract for objects that can be serialized to JSON format.
    /// </summary>
    /// <remarks>
    ///     Types implementing this interface can provide their own serialization logic by defining
    ///     which properties should be included and how their values should be represented.
    ///     
    ///     Usage Pattern:
    ///     Classes should implement this interface to support JSON serialization through the
    ///     JsonNativeAot.Serialize&lt;T&gt; method.
    ///     
    ///     Note: For complete bidirectional serialization support, also implement
    ///     IJsonDesSerializable&lt;T&gt; to enable deserialization.
    /// </remarks>
    public interface IJsonSerializable
    {
        /// <summary>
        ///     Gets the serializable properties of this instance.
        /// </summary>
        /// <returns>
        ///     An enumerable of tuples containing property names and their string representations.
        ///     Property names should not include quotes; values may be primitives or raw JSON.
        /// </returns>
        /// <remarks>
        ///     Implementation Guide:
        ///     - Use yield return for each property: (propertyName, stringValue)
        ///     - Primitive values should be converted to strings (e.g., number.ToString())
        ///     - Complex values (objects/arrays) should return raw JSON strings
        ///     - Null or empty values are allowed and will be handled by the serializer
        ///     
        ///     Time Complexity: Should be O(n) where n is the number of properties.
        ///     
        ///     Example:
        ///     <code>
        ///     public class Person : IJsonSerializable
        ///     {
        ///         public string Name { get; set; }
        ///         public int Age { get; set; }
        ///         public List&lt;string&gt; Tags { get; set; }
        ///         
        ///         public IEnumerable&lt;(string PropertyName, string Value)&gt; GetSerializableProperties()
        ///         {
        ///             yield return ("Name", Name);
        ///             yield return ("Age", Age.ToString());
        ///             yield return ("Tags", "[\"tag1\",\"tag2\"]");
        ///         }
        ///     }
        ///     </code>
        /// </remarks>
        IEnumerable<(string PropertyName, string Value)> GetSerializableProperties();
    }
}