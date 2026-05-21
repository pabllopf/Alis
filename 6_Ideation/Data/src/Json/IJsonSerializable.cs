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
using System.Diagnostics.CodeAnalysis;

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     Defines a contract for objects that can provide their serializable properties for
    ///     conversion into JSON format. Implementing types define which properties are included
    ///     in JSON output and how their values are represented as strings.
    /// </summary>
    /// <remarks>
    ///     Types implementing this interface can provide their own serialization logic by defining
    ///     which properties should be included and how their values should be represented.
    ///     This is the serialization counterpart to <see cref="IJsonDesSerializable{T}" />.
    ///     <para>
    ///     Usage Pattern:
    ///     Classes should implement this interface to support JSON serialization through the
    ///     <see cref="JsonNativeAot.Serialize{T}" /> method.
    ///     Note: For complete bidirectional serialization support, also implement
    ///     <see cref="IJsonDesSerializable{T}" /> to enable deserialization.
    ///     </para>
    /// </remarks>
    public interface IJsonSerializable
    {
        /// <summary>
        ///     Returns an enumerable collection of property name-value string tuples that represent
        ///     the serializable state of this instance. Each tuple consists of a property name and
        ///     its string representation.
        /// </summary>
        /// <returns>
        ///     An enumerable of tuples where each tuple contains:
        ///     - <c>PropertyName</c>: The JSON key (without surrounding quotes).
        ///     - <c>Value</c>: The string representation of the property value.
        ///     Primitive values should be plain strings; complex values (objects or arrays)
        ///     should be returned as raw JSON strings.
        ///     Returns an empty enumeration if there are no properties to serialize.
        /// </returns>
        /// <remarks>
        ///     Implementation Guide:
        ///     - Use <c>yield return</c> for each property: <c>(propertyName, stringValue)</c>
        ///     - Primitive values should be converted to strings (e.g., <c>number.ToString()</c>)
        ///     - Complex values (objects/arrays) should return raw JSON strings
        ///     - Null or empty values are allowed and will be handled by the serializer (null values are skipped)
        ///     - Time Complexity: Should be O(n) where n is the number of properties.
        ///     <para>
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
        ///     </para>
        /// </remarks>
        [ExcludeFromCodeCoverage]
        IEnumerable<(string PropertyName, string Value)> GetSerializableProperties();
    }
}