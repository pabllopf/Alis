// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: AllTypesExample.cs
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
using System.Collections.Generic;
using System.Linq;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Sample
{
    /// <summary>
    ///     Enumeration sample for testing enum serialization.
    /// </summary>
    public enum StatusType
    {
        /// <summary>
        ///     Active status.
        /// </summary>
        Active,

        /// <summary>
        ///     Inactive status.
        /// </summary>
        Inactive,

        /// <summary>
        ///     Pending status.
        /// </summary>
        Pending,

        /// <summary>
        ///     Completed status.
        /// </summary>
        Completed
    }

    /// <summary>
    ///     Demonstrates serialization of all primitive types supported by the generator.
    /// </summary>
    /// <remarks>
    ///     This sample includes:
    ///     - Boolean, Char, Byte, SByte
    ///     - Int16, UInt16, Int32, UInt32, Int64, UInt64
    ///     - Single, Double, Decimal
    ///     - String
    /// </remarks>
    [Serializable]
    public partial class PrimitiveTypesExample
    {
        /// <summary>
        ///     Gets or sets a boolean value.
        /// </summary>
        public bool BoolValue { get; set; }

        /// <summary>
        ///     Gets or sets a character value.
        /// </summary>
        public char CharValue { get; set; }

        /// <summary>
        ///     Gets or sets a byte value.
        /// </summary>
        public byte ByteValue { get; set; }

        /// <summary>
        ///     Gets or sets a signed byte value.
        /// </summary>
        public sbyte SByteValue { get; set; }

        /// <summary>
        ///     Gets or sets a 16-bit signed integer.
        /// </summary>
        public short Int16Value { get; set; }

        /// <summary>
        ///     Gets or sets a 16-bit unsigned integer.
        /// </summary>
        public ushort UInt16Value { get; set; }

        /// <summary>
        ///     Gets or sets a 32-bit signed integer.
        /// </summary>
        public int Int32Value { get; set; }

        /// <summary>
        ///     Gets or sets a 32-bit unsigned integer.
        /// </summary>
        public uint UInt32Value { get; set; }

        /// <summary>
        ///     Gets or sets a 64-bit signed integer.
        /// </summary>
        public long Int64Value { get; set; }

        /// <summary>
        ///     Gets or sets a 64-bit unsigned integer.
        /// </summary>
        public ulong UInt64Value { get; set; }

        /// <summary>
        ///     Gets or sets a single-precision floating-point value.
        /// </summary>
        public float SingleValue { get; set; }

        /// <summary>
        ///     Gets or sets a double-precision floating-point value.
        /// </summary>
        public double DoubleValue { get; set; }

        /// <summary>
        ///     Gets or sets a decimal value.
        /// </summary>
        public decimal DecimalValue { get; set; }

        /// <summary>
        ///     Gets or sets a string value.
        /// </summary>
        public string StringValue { get; set; }
    }

    /// <summary>
    ///     Demonstrates serialization of special .NET types.
    /// </summary>
    /// <remarks>
    ///     This sample includes:
    ///     - DateTime
    ///     - DateTimeOffset
    ///     - TimeSpan
    ///     - Guid
    ///     - Uri
    ///     - Version
    /// </remarks>
    [Serializable]
    public partial class SpecialTypesExample
    {
        /// <summary>
        ///     Gets or sets a date and time value.
        /// </summary>
        public DateTime DateTimeValue { get; set; }

        /// <summary>
        ///     Gets or sets a date and time with timezone offset.
        /// </summary>
        public DateTimeOffset DateTimeOffsetValue { get; set; }

        /// <summary>
        ///     Gets or sets a time span duration.
        /// </summary>
        public TimeSpan TimeSpanValue { get; set; }

        /// <summary>
        ///     Gets or sets a globally unique identifier.
        /// </summary>
        public Guid GuidValue { get; set; }

        /// <summary>
        ///     Gets or sets a URI.
        /// </summary>
        public Uri UriValue { get; set; }

        /// <summary>
        ///     Gets or sets a version number.
        /// </summary>
        public Version VersionValue { get; set; }
    }

    /// <summary>
    ///     Demonstrates serialization of array types.
    /// </summary>
    /// <remarks>
    ///     This sample includes:
    ///     - Single-dimensional arrays (T[])
    ///     - Two-dimensional arrays (T[,])
    /// </remarks>
    [Serializable]
    public partial class ArrayTypesExample
    {
        /// <summary>
        ///     Gets or sets a one-dimensional array of integers.
        /// </summary>
        public int[] IntArray { get; set; }

        /// <summary>
        ///     Gets or sets a one-dimensional array of strings.
        /// </summary>
        public string[] StringArray { get; set; }

        /// <summary>
        ///     Gets or sets a one-dimensional array of doubles.
        /// </summary>
        public double[] DoubleArray { get; set; }

        /// <summary>
        ///     Gets or sets a two-dimensional array of integers.
        /// </summary>
        public int[,] Int2DArray { get; set; }

        /// <summary>
        ///     Gets or sets a two-dimensional array of strings.
        /// </summary>
        public string[,] String2DArray { get; set; }
    }

    /// <summary>
    ///     Demonstrates serialization of collection types.
    /// </summary>
    /// <remarks>
    ///     This sample includes:
    ///     - List<T>
    ///     - IList<T>
    ///     - ICollection<T>
    ///     - IEnumerable<T>
    /// </remarks>
    [Serializable]
    public partial class CollectionTypesExample
    {
        /// <summary>
        ///     Gets or sets a list of integers.
        /// </summary>
        public List<int> IntList { get; set; }

        /// <summary>
        ///     Gets or sets a list of strings.
        /// </summary>
        public List<string> StringList { get; set; }

        /// <summary>
        ///     Gets or sets a list of decimals.
        /// </summary>
        public List<decimal> DecimalList { get; set; }

        /// <summary>
        ///     Gets or sets a list of booleans.
        /// </summary>
        public List<bool> BoolList { get; set; }
    }

    /// <summary>
    ///     Demonstrates serialization of dictionary types.
    /// </summary>
    /// <remarks>
    ///     This sample includes:
    ///     - Dictionary<string, string>
    ///     - Dictionary<string, int>
    ///     - Dictionary<int, string>
    /// </remarks>
    [Serializable]
    public partial class DictionaryTypesExample
    {
        /// <summary>
        ///     Gets or sets a dictionary with string keys and values.
        /// </summary>
        public Dictionary<string, string> StringDictionary { get; set; }

        /// <summary>
        ///     Gets or sets a dictionary with string keys and integer values.
        /// </summary>
        public Dictionary<string, int> StringIntDictionary { get; set; }

        /// <summary>
        ///     Gets or sets a dictionary with integer keys and string values.
        /// </summary>
        public Dictionary<int, string> IntStringDictionary { get; set; }
    }

    /// <summary>
    ///     Demonstrates serialization with enumerations.
    /// </summary>
    /// <remarks>
    ///     This sample shows how enum values are serialized and deserialized.
    /// </remarks>
    [Serializable]
    public partial class EnumExample
    {
        /// <summary>
        ///     Gets or sets the status of the entity.
        /// </summary>
        public StatusType Status { get; set; }

        /// <summary>
        ///     Gets or sets a list of statuses.
        /// </summary>
        public List<StatusType> StatusList { get; set; }

        /// <summary>
        ///     Gets or sets the name or description.
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    ///     Demonstrates use of custom property names via attributes.
    /// </summary>
    /// <remarks>
    ///     This sample shows how to use [JsonNativePropertyName] attribute
    ///     to specify custom JSON property names.
    /// </remarks>
    [Serializable]
    public partial class CustomPropertyNamesExample
    {
        /// <summary>
        ///     Gets or sets the identifier with custom JSON name.
        /// </summary>
        [JsonNativePropertyName("id")]
        public int Identifier { get; set; }

        /// <summary>
        ///     Gets or sets the display name with custom JSON name.
        /// </summary>
        [JsonNativePropertyName("displayName")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the creation date with custom JSON name.
        /// </summary>
        [JsonNativePropertyName("createdDate")]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        ///     Gets or sets the status with custom JSON name.
        /// </summary>
        [JsonNativePropertyName("currentStatus")]
        public StatusType Status { get; set; }

        /// <summary>
        ///     Gets or sets tags with custom JSON name.
        /// </summary>
        [JsonNativePropertyName("tags")]
        public List<string> Labels { get; set; }
    }

    /// <summary>
    ///     Demonstrates how to ignore properties from serialization.
    /// </summary>
    /// <remarks>
    ///     This sample shows how to use [JsonNativeIgnore] attribute
    ///     to exclude properties from serialization.
    /// </remarks>
    [Serializable]
    public partial class IgnoredPropertiesExample
    {
        /// <summary>
        ///     Gets or sets the identifier (serialized).
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the name (serialized).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets internal notes (NOT serialized).
        /// </summary>
        [JsonNativeIgnore]
        public string InternalNotes { get; set; }

        /// <summary>
        ///     Gets or sets the creation timestamp (serialized).
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        ///     Gets or sets internal flags (NOT serialized).
        /// </summary>
        [JsonNativeIgnore]
        public bool InternalFlag { get; set; }
    }

    /// <summary>
    ///     Demonstrates serialization of nested complex types.
    /// </summary>
    /// <remarks>
    ///     This sample shows how complex types that implement
    ///     IJsonSerializable can be nested and serialized together.
    /// </remarks>
    [Serializable]
    public partial class ComplexNestedExample
    {
        /// <summary>
        ///     Gets or sets the project identifier.
        /// </summary>
        public Guid ProjectId { get; set; }

        /// <summary>
        ///     Gets or sets the project name.
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        ///     Gets or sets the project start date.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        ///     Gets or sets the project duration.
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        ///     Gets or sets the list of team members.
        /// </summary>
        public List<string> TeamMembers { get; set; }

        /// <summary>
        ///     Gets or sets the project metadata as key-value pairs.
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        ///     Gets or sets milestone dates.
        /// </summary>
        public DateTime[] MilestoneDates { get; set; }

        /// <summary>
        ///     Gets or sets the project status.
        /// </summary>
        public StatusType Status { get; set; }

        /// <summary>
        ///     Gets or sets the project budget values.
        /// </summary>
        public decimal[] BudgetAllocation { get; set; }
    }

    /// <summary>
    ///     Comprehensive example showcasing all supported types in a single model.
    /// </summary>
    /// <remarks>
    ///     This example demonstrates the complete feature set of the JSON serialization generator,
    ///     including all primitive types, special types, collections, arrays, enums, and attributes.
    /// </remarks>
    [Serializable]
    public partial class ComprehensiveExample
    {
        /// <summary>
        ///     Gets or sets the unique identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the entity name.
        /// </summary>
        [JsonNativePropertyName("entityName")]
        public string Name { get; set; }

        // Primitive Types
        /// <summary>
        ///     Gets or sets a boolean value (primitive).
        /// </summary>
        public bool BoolProperty { get; set; }

        /// <summary>
        ///     Gets or sets an integer value (primitive).
        /// </summary>
        public int IntProperty { get; set; }

        /// <summary>
        ///     Gets or sets a decimal value (primitive).
        /// </summary>
        public decimal DecimalProperty { get; set; }

        /// <summary>
        ///     Gets or sets a floating-point value (primitive).
        /// </summary>
        public double DoubleProperty { get; set; }

        // Special Types
        /// <summary>
        ///     Gets or sets a date and time value (special type).
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        ///     Gets or sets a date and time with offset (special type).
        /// </summary>
        public DateTimeOffset LastModified { get; set; }

        /// <summary>
        ///     Gets or sets a time duration (special type).
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        ///     Gets or sets a URI (special type).
        /// </summary>
        public Uri Website { get; set; }

        /// <summary>
        ///     Gets or sets a version (special type).
        /// </summary>
        public Version ApiVersion { get; set; }

        // Arrays
        /// <summary>
        ///     Gets or sets a one-dimensional integer array.
        /// </summary>
        public int[] IntArray { get; set; }

        /// <summary>
        ///     Gets or sets a one-dimensional string array.
        /// </summary>
        public string[] StringArray { get; set; }

        /// <summary>
        ///     Gets or sets a two-dimensional decimal array.
        /// </summary>
        public decimal[,] Values2D { get; set; }

        // Collections
        /// <summary>
        ///     Gets or sets a list of strings.
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        ///     Gets or sets a list of integers.
        /// </summary>
        public List<int> Numbers { get; set; }

        // Dictionaries
        /// <summary>
        ///     Gets or sets metadata as a dictionary.
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        ///     Gets or sets statistics as a dictionary.
        /// </summary>
        public Dictionary<string, int> Statistics { get; set; }

        // Enum
        /// <summary>
        ///     Gets or sets the current status.
        /// </summary>
        public StatusType Status { get; set; }

        // Ignored Property
        /// <summary>
        ///     Gets or sets internal notes (NOT serialized).
        /// </summary>
        [JsonNativeIgnore]
        public string InternalNotes { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ComprehensiveExample" /> class.
        /// </summary>
        public ComprehensiveExample()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            LastModified = DateTimeOffset.Now;
            Tags = new List<string>();
            Numbers = new List<int>();
            Metadata = new Dictionary<string, string>();
            Statistics = new Dictionary<string, int>();
        }
    }
}

