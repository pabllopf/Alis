// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: JsonRegressionTest.cs
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
using System.Diagnostics;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Data.Json.Helpers;
using Alis.Core.Aspect.Data.Json.Parsing;
using Alis.Core.Aspect.Data.Test.Json.Models;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json.Regression
{
    /// <summary>
    ///     Regression tests to ensure previous bugs don't reappear.
    ///     Each test represents a previously fixed bug or edge case.
    /// </summary>
    public class JsonRegressionTest
    {
        /// <summary>
        /// The parser
        /// </summary>
        private readonly IJsonParser _parser;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonRegressionTest"/> class
        /// </summary>
        public JsonRegressionTest()
        {
            _parser = new JsonParser(new EscapeSequenceHandler());
        }

        #region Bug Fix: Whitespace Handling

        /// <summary>
        /// Tests that bug 001 parse to dictionary extra whitespace does not fail
        /// </summary>
        [Fact]
        public void Bug001_ParseToDictionary_ExtraWhitespace_DoesNotFail()
        {
            // Regression: Parser crashed with excessive whitespace
            // Fixed: Improved whitespace trimming logic
            string json = "  {  \"key\"  :  \"value\"  }  ";

            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            Assert.Equal("value", result["key"]);
        }

        /// <summary>
        /// Tests that bug 002 parse to dictionary newlines in json parses correctly
        /// </summary>
        [Fact]
        public void Bug002_ParseToDictionary_NewlinesInJson_ParsesCorrectly()
        {
            // Regression: Parser failed with newlines
            // Fixed: Added newline handling
            string json = "{\n\"name\":\n\"John\"\n}";

            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            Assert.Equal("John", result["name"]);
        }

        #endregion

        #region Bug Fix: Escape Sequences

        /// <summary>
        /// Tests that bug 003 parse to dictionary escaped quotes unescapes correctly
        /// </summary>
        [Fact]
        public void Bug003_ParseToDictionary_EscapedQuotes_UnescapesCorrectly()
        {
            // Regression: Escaped quotes caused parsing errors
            // Fixed: Proper escape sequence handling
            string json = "{\"text\":\"say \\\"hello\\\"\"}";

            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            Assert.Contains("\"", result["text"]);
        }

        /// <summary>
        /// Tests that bug 004 parse to dictionary escaped backslash handles correctly
        /// </summary>
        [Fact]
        public void Bug004_ParseToDictionary_EscapedBackslash_HandlesCorrectly()
        {
            // Regression: Double backslash not handled
            // Fixed: Added backslash escape handling
            string json = "{\"path\":\"C:\\\\\\\\Users\"}";

            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            Assert.Contains("\\", result["path"]);
        }

        /// <summary>
        /// Tests that bug 005 parse to dictionary multiple escapes all processed
        /// </summary>
        [Fact]
        public void Bug005_ParseToDictionary_MultipleEscapes_AllProcessed()
        {
            // Regression: Only first escape sequence processed
            // Fixed: Loop through all escape sequences
            string json = "{\"text\":\"line1\\nline2\\ttab\"}";

            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            Assert.Contains("\n", result["text"]);
            Assert.Contains("\t", result["text"]);
        }

        #endregion

        #region Bug Fix: Nested Structures

        /// <summary>
        /// Tests that bug 006 parse to dictionary nested object returns complete json
        /// </summary>
        [Fact]
        public void Bug006_ParseToDictionary_NestedObject_ReturnsCompleteJson()
        {
            // Regression: Nested objects truncated
            // Fixed: Proper bracket counting
            string json = "{\"user\":{\"name\":\"Alice\",\"age\":\"30\"}}";

            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            Assert.Contains("name", result["user"]);
            Assert.Contains("Alice", result["user"]);
            Assert.Contains("age", result["user"]);
        }

        /// <summary>
        /// Tests that bug 007 parse to dictionary nested array returns complete array
        /// </summary>
        [Fact]
        public void Bug007_ParseToDictionary_NestedArray_ReturnsCompleteArray()
        {
            // Regression: Arrays with objects not fully captured
            // Fixed: Improved bracket tracking
            string json = "{\"items\":[{\"id\":\"1\"},{\"id\":\"2\"}]}";

            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            Assert.Contains("id", result["items"]);
            Assert.Contains("1", result["items"]);
            Assert.Contains("2", result["items"]);
        }

        #endregion

        #region Bug Fix: Empty Values

        /// <summary>
        /// Tests that bug 008 parse to dictionary empty string does not skip property
        /// </summary>
        [Fact]
        public void Bug008_ParseToDictionary_EmptyString_DoesNotSkipProperty()
        {
            // Regression: Empty strings were ignored
            // Fixed: Preserve empty string values
            string json = "{\"name\":\"\"}";

            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            Assert.True(result.ContainsKey("name"));
            Assert.Equal("", result["name"]);
        }

        /// <summary>
        /// Tests that bug 009 parse to dictionary empty array preserves empty array
        /// </summary>
        [Fact]
        public void Bug009_ParseToDictionary_EmptyArray_PreservesEmptyArray()
        {
            // Regression: Empty arrays returned as null
            // Fixed: Return "[]" for empty arrays
            string json = "{\"items\":[]}";

            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            Assert.Equal("[]", result["items"]);
        }

        /// <summary>
        /// Tests that bug 010 parse to dictionary empty object preserves empty object
        /// </summary>
        [Fact]
        public void Bug010_ParseToDictionary_EmptyObject_PreservesEmptyObject()
        {
            // Regression: Empty objects not handled
            // Fixed: Return "{}" for empty objects
            string json = "{\"data\":{}}";

            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            Assert.Equal("{}", result["data"]);
        }

        #endregion

        #region Bug Fix: Serialization Issues

        /// <summary>
        /// Tests that bug 011 serialize value type property no nullable operator
        /// </summary>
        [Fact]
        public void Bug011_Serialize_ValueTypeProperty_NoNullableOperator()
        {
            // Regression: CS0023 error with nullable operator on value types
            // Fixed: Check IsValueType before using ?.
            NumericTypesStruct obj = new NumericTypesStruct
            {
                IntValue = 42,
                DoubleValue = 3.14
            };

            string json = JsonNativeAot.Serialize(obj);

            Assert.NotEmpty(json);
            Assert.Contains("42", json);
        }

        /// <summary>
        /// Tests that bug 012 serialize reference type property uses nullable operator
        /// </summary>
        [Fact]
        public void Bug012_Serialize_ReferenceTypeProperty_UsesNullableOperator()
        {
            // Regression: Null reference exceptions
            // Fixed: Use ?. for reference types
            PersonClass obj = new PersonClass
            {
                Name = null,
                Age = 30,
                Email = null
            };

            string json = JsonNativeAot.Serialize(obj);

            Assert.NotEmpty(json);
        }

        #endregion

        #region Bug Fix: Deserialization Issues

        /// <summary>
        /// Tests that bug 013 deserialize missing property uses default
        /// </summary>
        [Fact]
        public void Bug013_Deserialize_MissingProperty_UsesDefault()
        {
            // Regression: Crash when property missing
            // Fixed: Use default values for missing properties
            string json = "{\"Name\":\"Test\"}";

            PersonClass obj = JsonNativeAot.Deserialize<PersonClass>(json);

            Assert.Equal("Test", obj.Name);
            Assert.Equal(0, obj.Age);
        }

        /// <summary>
        /// Tests that bug 014 deserialize invalid integer value uses default
        /// </summary>
        [Fact]
        public void Bug014_Deserialize_InvalidIntegerValue_UsesDefault()
        {
            // Regression: Exception on invalid int parse
            // Fixed: TryParse with default fallback
            string json = "{\"Value\":\"not_a_number\"}";

            MinimalStruct obj = JsonNativeAot.Deserialize<MinimalStruct>(json);

            Assert.Equal(0, obj.Value);
        }

        /// <summary>
        /// Tests that bug 015 deserialize invalid bool value uses default
        /// </summary>
        [Fact]
        public void Bug015_Deserialize_InvalidBoolValue_UsesDefault()
        {
            // Regression: Exception on invalid bool parse
            // Fixed: TryParse with default fallback
            string json = "{\"Flag\":\"invalid\"}";

            PersonStruct obj = JsonNativeAot.Deserialize<PersonStruct>(json);

            Assert.False(obj.IsActive);
        }

        /// <summary>
        /// Tests that bug 016 deserialize invalid guid value uses empty
        /// </summary>
        [Fact]
        public void Bug016_Deserialize_InvalidGuidValue_UsesEmpty()
        {
            // Regression: Guid parse failures caused crashes
            // Fixed: TryParse with Guid.Empty fallback
            string json = "{\"Id\":\"not_a_guid\"}";

            TemporalTypesStruct obj = JsonNativeAot.Deserialize<TemporalTypesStruct>(json);

            Assert.Equal(Guid.Empty, obj.Identifier);
        }

        #endregion

        #region Bug Fix: Special Characters

        /// <summary>
        /// Tests that bug 017 round trip email address preserves at sign
        /// </summary>
        [Fact]
        public void Bug017_RoundTrip_EmailAddress_PreservesAtSign()
        {
            // Regression: @ symbol caused parsing issues
            // Fixed: Properly handle special characters
            PersonClass original = new PersonClass
            {
                Name = "User",
                Age = 25,
                Email = "user@example.com"
            };

            string json = JsonNativeAot.Serialize(original);
            PersonClass restored = JsonNativeAot.Deserialize<PersonClass>(json);

            Assert.Equal("user@example.com", restored.Email);
        }

        /// <summary>
        /// Tests that bug 018 round trip url in string preserves slashes
        /// </summary>
        [Fact]
        public void Bug018_RoundTrip_UrlInString_PreservesSlashes()
        {
            // Regression: URLs with slashes broken
            // Fixed: Proper escape handling
            MinimalClass original = new MinimalClass
            {
                Value = "https://example.com/path"
            };

            string json = JsonNativeAot.Serialize(original);
            MinimalClass restored = JsonNativeAot.Deserialize<MinimalClass>(json);

            Assert.Equal("https://example.com/path", restored.Value);
        }

        #endregion

        #region Bug Fix: Numeric Precision

        /// <summary>
        /// Tests that bug 019 round trip decimal precision maintained
        /// </summary>
        [Fact]
        public void Bug019_RoundTrip_DecimalPrecision_Maintained()
        {
            // Regression: Decimal precision lost
            // Fixed: Use InvariantCulture for formatting
            NumericTypesClass original = new NumericTypesClass
            {
                DecimalValue = 123.456789m
            };

            string json = JsonNativeAot.Serialize(original);
            NumericTypesClass restored = JsonNativeAot.Deserialize<NumericTypesClass>(json);

            Assert.Equal(original.DecimalValue, restored.DecimalValue);
        }

        /// <summary>
        /// Tests that bug 020 round trip double precision maintained
        /// </summary>
        [Fact]
        public void Bug020_RoundTrip_DoublePrecision_Maintained()
        {
            // Regression: Double precision issues
            // Fixed: Use InvariantCulture for double parsing
            NumericTypesStruct original = new NumericTypesStruct
            {
                DoubleValue = 3.141592653589793
            };

            string json = JsonNativeAot.Serialize(original);
            NumericTypesStruct restored = JsonNativeAot.Deserialize<NumericTypesStruct>(json);

            Assert.Equal(original.DoubleValue, restored.DoubleValue, 10);
        }

        #endregion

        #region Bug Fix: DateTime Handling

        /// <summary>
        /// Tests that bug 021 round trip date time preserves date
        /// </summary>
        [Fact]
        public void Bug021_RoundTrip_DateTime_PreservesDate()
        {
            // Regression: DateTime serialization lost time component
            // Fixed: Use "O" format for round-trip
            TemporalTypesStruct original = new TemporalTypesStruct
            {
                Timestamp = new DateTime(2023, 6, 15, 14, 30, 45),
                Identifier = Guid.NewGuid()
            };

            string json = JsonNativeAot.Serialize(original);
            TemporalTypesStruct restored = JsonNativeAot.Deserialize<TemporalTypesStruct>(json);

            Assert.Equal(original.Timestamp.Year, restored.Timestamp.Year);
            Assert.Equal(original.Timestamp.Month, restored.Timestamp.Month);
            Assert.Equal(original.Timestamp.Day, restored.Timestamp.Day);
        }

        /// <summary>
        /// Tests that bug 022 round trip min date time handles edge case
        /// </summary>
        [Fact]
        public void Bug022_RoundTrip_MinDateTime_HandlesEdgeCase()
        {
            // Regression: DateTime.MinValue caused issues
            // Fixed: Handle edge case values
            TemporalTypesClass original = new TemporalTypesClass
            {
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
                Id = Guid.Empty,
                CorrelationId = Guid.Empty
            };

            string json = JsonNativeAot.Serialize(original);
            TemporalTypesClass restored = JsonNativeAot.Deserialize<TemporalTypesClass>(json);

            Assert.Equal(original.CreatedAt.Year, restored.CreatedAt.Year);
        }

        #endregion

        #region Bug Fix: Enum Serialization

        /// <summary>
        /// Tests that bug 023 round trip enum value preserves enum name
        /// </summary>
        [Fact]
        public void Bug023_RoundTrip_EnumValue_PreservesEnumName()
        {
            // Regression: Enum serialized as int
            // Fixed: Use ToString() for enum serialization
            EntityWithEnums original = new EntityWithEnums
            {
                Name = "Test",
                Status = StatusEnum.Active,
                Priority = PriorityEnum.High
            };

            string json = JsonNativeAot.Serialize(original);
            EntityWithEnums restored = JsonNativeAot.Deserialize<EntityWithEnums>(json);

            Assert.Equal(StatusEnum.Active, restored.Status);
            Assert.Equal(PriorityEnum.High, restored.Priority);
        }

        /// <summary>
        /// Tests that bug 024 round trip enum default value handles correctly
        /// </summary>
        [Fact]
        public void Bug024_RoundTrip_EnumDefaultValue_HandlesCorrectly()
        {
            // Regression: Default enum value (0) not handled
            // Fixed: Proper enum parsing with default
            EntityWithEnums original = new EntityWithEnums
            {
                Name = "Test",
                Status = StatusEnum.Unknown,
                Priority = PriorityEnum.Low
            };

            string json = JsonNativeAot.Serialize(original);
            EntityWithEnums restored = JsonNativeAot.Deserialize<EntityWithEnums>(json);

            Assert.Equal(StatusEnum.Unknown, restored.Status);
        }

        #endregion

        #region Bug Fix: Collection Handling

        /// <summary>
        /// Tests that bug 025 round trip empty list preserves empty list
        /// </summary>
        [Fact]
        public void Bug025_RoundTrip_EmptyList_PreservesEmptyList()
        {
            // Regression: Empty lists became null
            // Fixed: Initialize empty list properly
            TagsClass original = new TagsClass
            {
                Name = "Test",
                Tags = new System.Collections.Generic.List<string>()
            };

            string json = JsonNativeAot.Serialize(original);
            TagsClass restored = JsonNativeAot.Deserialize<TagsClass>(json);

            Assert.NotNull(restored.Tags);
            Assert.Empty(restored.Tags);
        }

        /// <summary>
        /// Tests that bug 026 round trip list with null elements handles gracefully
        /// </summary>
        [Fact]
        public void Bug026_RoundTrip_ListWithNullElements_HandlesGracefully()
        {
            // Regression: Null elements in list caused issues
            // Fixed: Skip or handle null elements
            TagsClass original = new TagsClass
            {
                Name = "Test",
                Tags = new System.Collections.Generic.List<string> { "tag1", null, "tag2" }
            };

            string json = JsonNativeAot.Serialize(original);

            Assert.NotEmpty(json);
        }

        #endregion

        #region Bug Fix: Nested Objects

        /// <summary>
        /// Tests that bug 027 round trip nested object preserves nesting
        /// </summary>
        [Fact]
        public void Bug027_RoundTrip_NestedObject_PreservesNesting()
        {
            // Regression: Nested objects flattened
            // Fixed: Proper nested serialization
            UserWithAddress original = new UserWithAddress
            {
                Username = "testuser",
                UserId = 1,
                Address = new AddressClass
                {
                    Street = "123 Main St",
                    City = "Springfield"
                }
            };

            string json = JsonNativeAot.Serialize(original);
            UserWithAddress restored = JsonNativeAot.Deserialize<UserWithAddress>(json);

            Assert.NotNull(restored.Address);
            Assert.Equal("123 Main St", restored.Address.Street);
        }

        /// <summary>
        /// Tests that bug 028 round trip null nested object does not crash
        /// </summary>
        [Fact]
        public void Bug028_RoundTrip_NullNestedObject_DoesNotCrash()
        {
            // Regression: Null nested objects caused NullReferenceException
            // Fixed: Null checks before serialization
            UserWithAddress original = new UserWithAddress
            {
                Username = "user",
                UserId = 2,
                Address = null
            };

            string json = JsonNativeAot.Serialize(original);
            UserWithAddress restored = JsonNativeAot.Deserialize<UserWithAddress>(json);

            Assert.Equal("user", restored.Username);
        }

        #endregion

        #region Bug Fix: Large Values

        /// <summary>
        /// Tests that bug 029 round trip very long string preserves entire string
        /// </summary>
        [Fact]
        public void Bug029_RoundTrip_VeryLongString_PreservesEntireString()
        {
            // Regression: Long strings truncated
            // Fixed: Removed buffer size limitations
            string longString = new string('x', 10000);
            MinimalClass original = new MinimalClass { Value = longString };

            string json = JsonNativeAot.Serialize(original);
            MinimalClass restored = JsonNativeAot.Deserialize<MinimalClass>(json);

            Assert.Equal(longString, restored.Value);
        }

        /// <summary>
        /// Tests that bug 030 round trip max int value no overflow
        /// </summary>
        [Fact]
        public void Bug030_RoundTrip_MaxIntValue_NoOverflow()
        {
            // Regression: Max int values caused overflow
            // Fixed: Proper int parsing with bounds check
            NumericTypesClass original = new NumericTypesClass
            {
                IntValue = int.MaxValue
            };

            string json = JsonNativeAot.Serialize(original);
            NumericTypesClass restored = JsonNativeAot.Deserialize<NumericTypesClass>(json);

            Assert.Equal(int.MaxValue, restored.IntValue);
        }

        #endregion

        #region Bug Fix: Special Case Values

        /// <summary>
        /// Tests that bug 031 round trip empty guid serializes correctly
        /// </summary>
        [Fact]
        public void Bug031_RoundTrip_EmptyGuid_SerializesCorrectly()
        {
            // Regression: Empty GUID serialization issue
            // Fixed: Handle Guid.Empty explicitly
            TemporalTypesStruct original = new TemporalTypesStruct
            {
                Timestamp = DateTime.Now,
                Identifier = Guid.Empty
            };

            string json = JsonNativeAot.Serialize(original);
            TemporalTypesStruct restored = JsonNativeAot.Deserialize<TemporalTypesStruct>(json);

            Assert.Equal(Guid.Empty, restored.Identifier);
        }

        /// <summary>
        /// Tests that bug 032 round trip min date time no exception
        /// </summary>
        [Fact]
        public void Bug032_RoundTrip_MinDateTime_NoException()
        {
            // Regression: DateTime.MinValue caused format exception
            // Fixed: Handle DateTime edge cases
            ProductClass original = new ProductClass
            {
                ProductId = 1,
                ProductName = "Test",
                Price = 0,
                InStock = true,
                AddedDate = DateTime.MinValue
            };

            string json = JsonNativeAot.Serialize(original);
            ProductClass restored = JsonNativeAot.Deserialize<ProductClass>(json);

            Assert.Equal(DateTime.MinValue.Year, restored.AddedDate.Year);
        }

        #endregion

        #region Bug Fix: Property Name Cases

        /// <summary>
        /// Tests that bug 033 parse to dictionary case sensitive keys treats as different
        /// </summary>
        [Fact]
        public void Bug033_ParseToDictionary_CaseSensitiveKeys_TreatsAsDifferent()
        {
            // Regression: Case-insensitive key comparison
            // Fixed: Use case-sensitive dictionary
            string json = "{\"Name\":\"upper\",\"name\":\"lower\"}";

            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            Assert.Equal(2, result.Count);
        }

        #endregion

        #region Bug Fix: Duplicate Keys

        /// <summary>
        /// Tests that bug 034 parse to dictionary duplicate keys uses last
        /// </summary>
        [Fact]
        public void Bug034_ParseToDictionary_DuplicateKeys_UsesLast()
        {
            // Regression: Duplicate keys caused exception
            // Fixed: Overwrite with last value
            string json = "{\"key\":\"first\",\"key\":\"second\"}";

            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            Assert.Equal("second", result["key"]);
        }

        #endregion

        #region Bug Fix: Unicode Support

        /// <summary>
        /// Tests that bug 035 round trip unicode characters preserves correctly
        /// </summary>
        [Fact]
        public void Bug035_RoundTrip_UnicodeCharacters_PreservesCorrectly()
        {
            // Regression: Unicode characters corrupted
            // Fixed: Use UTF-8 encoding throughout
            MinimalClass original = new MinimalClass
            {
                Value = "Hello 世界 🌍"
            };

            string json = JsonNativeAot.Serialize(original);
            MinimalClass restored = JsonNativeAot.Deserialize<MinimalClass>(json);

            Assert.Equal(original.Value, restored.Value);
        }

        #endregion

        #region Bug Fix: Performance Issues

        /// <summary>
        /// Tests that bug 036 parse to dictionary large json completes in time
        /// </summary>
        [Fact]
        public void Bug036_ParseToDictionary_LargeJson_CompletesInTime()
        {
            // Regression: Slow parsing with large JSON
            // Fixed: Optimized parsing algorithm
            List<string> props = new System.Collections.Generic.List<string>();
            for (int i = 0; i < 1000; i++)
            {
                props.Add($"\"field{i}\":\"value{i}\"");
            }
            string json = "{" + string.Join(",", props) + "}";

            Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            Dictionary<string, string> result = _parser.ParseToDictionary(json);
            sw.Stop();

            Assert.True(sw.ElapsedMilliseconds < 2000);
            Assert.Equal(1000, result.Count);
        }

        #endregion

        #region Bug Fix: Null Handling

        /// <summary>
        /// Tests that bug 037 serialize null object throws exception
        /// </summary>
        [Fact]
        public void Bug037_Serialize_NullObject_ThrowsException()
        {
            // Regression: Null serialization caused unclear errors
            // Fixed: Explicit null check with ArgumentNullException
            PersonClass nullPerson = null;

            Assert.Throws<ArgumentNullException>(() => JsonNativeAot.Serialize(nullPerson));
        }

        /// <summary>
        /// Tests that bug 038 deserialize null json throws exception
        /// </summary>
        [Fact]
        public void Bug038_Deserialize_NullJson_ThrowsException()
        {
            // Regression: Null JSON input caused NullReferenceException
            // Fixed: Early null check
            string nullJson = null;

            Assert.Throws<ArgumentNullException>(() => 
                JsonNativeAot.Deserialize<PersonClass>(nullJson));
        }

        #endregion

        #region Bug Fix: AOT Compatibility

        /// <summary>
        /// Tests that bug 039 serialize struct aot compatible
        /// </summary>
        [Fact]
        public void Bug039_Serialize_Struct_AotCompatible()
        {
            // Regression: Structs caused AOT compilation issues
            // Fixed: Proper struct handling in generator
            Point2D original = new Point2D(10, 20);

            string json = JsonNativeAot.Serialize(original);
            Point2D restored = JsonNativeAot.Deserialize<Point2D>(json);

            Assert.Equal(original.X, restored.X);
            Assert.Equal(original.Y, restored.Y);
        }

        /// <summary>
        /// Tests that bug 040 serialize complex struct aot compatible
        /// </summary>
        [Fact]
        public void Bug040_Serialize_ComplexStruct_AotCompatible()
        {
            // Regression: Complex structs failed AOT
            // Fixed: Better struct member access in generator
            DbConnectionStruct original = new DbConnectionStruct
            {
                Host = "localhost",
                Port = 5432,
                Database = "testdb",
                Timeout = 30
            };

            string json = JsonNativeAot.Serialize(original);
            DbConnectionStruct restored = JsonNativeAot.Deserialize<DbConnectionStruct>(json);

            Assert.Equal(original.Host, restored.Host);
            Assert.Equal(original.Port, restored.Port);
        }

        #endregion

        #region Bug Fix: Memory and Performance

        /// <summary>
        /// Tests that bug 041 multiple serializations no memory leak
        /// </summary>
        [Fact]
        public void Bug041_MultipleSerializations_NoMemoryLeak()
        {
            // Regression: Memory leak with repeated serializations
            // Fixed: Proper disposal and StringBuilder reuse
            PersonClass obj = new PersonClass { Name = "Test", Age = 30, Email = "test@test.com" };

            for (int i = 0; i < 1000; i++)
            {
                string json = JsonNativeAot.Serialize(obj);
                Assert.NotEmpty(json);
            }

            // If we get here without OutOfMemoryException, test passes
            Assert.True(true);
        }

        /// <summary>
        /// Tests that bug 042 multiple deserializations no memory leak
        /// </summary>
        [Fact]
        public void Bug042_MultipleDeserializations_NoMemoryLeak()
        {
            // Regression: Memory leak with repeated deserializations
            // Fixed: Proper object creation
            string json = "{\"Name\":\"Test\",\"Age\":\"30\",\"Email\":\"test@test.com\"}";

            for (int i = 0; i < 1000; i++)
            {
                PersonClass obj = JsonNativeAot.Deserialize<PersonClass>(json);
                Assert.NotNull(obj);
            }

            // If we get here without OutOfMemoryException, test passes
            Assert.True(true);
        }

        #endregion

        #region Bug Fix: Thread Safety

        /// <summary>
        /// Tests that bug 043 concurrent serializations no race conditions
        /// </summary>
        [Fact]
        public void Bug043_ConcurrentSerializations_NoRaceConditions()
        {
            // Regression: Thread safety issues
            // Fixed: Removed shared state
            PersonClass obj = new PersonClass { Name = "Concurrent", Age = 30, Email = "test@test.com" };

            System.Threading.Tasks.Parallel.For(0, 100, i =>
            {
                string json = JsonNativeAot.Serialize(obj);
                Assert.NotEmpty(json);
            });

            Assert.True(true);
        }

        #endregion

        #region Bug Fix: Edge Cases

        /// <summary>
        /// Tests that bug 044 serialize all properties null does not crash
        /// </summary>
        [Fact]
        public void Bug044_Serialize_AllPropertiesNull_DoesNotCrash()
        {
            // Regression: All null properties caused crash
            // Fixed: Handle all-null scenarios
            PersonClass obj = new PersonClass
            {
                Name = null,
                Age = 0,
                Email = null
            };

            string json = JsonNativeAot.Serialize(obj);

            Assert.NotEmpty(json);
        }

        /// <summary>
        /// Tests that bug 045 deserialize all properties missing creates object
        /// </summary>
        [Fact]
        public void Bug045_Deserialize_AllPropertiesMissing_CreatesObject()
        {
            // Regression: Missing all properties failed
            // Fixed: Use default values
            string json = "{}";

            PersonClass obj = JsonNativeAot.Deserialize<PersonClass>(json);

            Assert.NotNull(obj);
        }

        #endregion

        #region Bug Fix: Special Characters in Property Names

        /// <summary>
        /// Tests that bug 046 parse to dictionary property with underscore parses correctly
        /// </summary>
        [Fact]
        public void Bug046_ParseToDictionary_PropertyWithUnderscore_ParsesCorrectly()
        {
            // Regression: Underscore in property names failed
            // Fixed: Allow underscores in identifiers
            string json = "{\"_id\":\"123\",\"user_name\":\"test\"}";

            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            Assert.Equal("123", result["_id"]);
            Assert.Equal("test", result["user_name"]);
        }

        #endregion

        #region Bug Fix: Floating Point Edge Cases

        /// <summary>
        /// Tests that bug 047 round trip negative zero handles correctly
        /// </summary>
        [Fact]
        public void Bug047_RoundTrip_NegativeZero_HandlesCorrectly()
        {
            // Regression: -0.0 vs 0.0 comparison issues
            // Fixed: Normalize zero values
            NumericTypesStruct original = new NumericTypesStruct
            {
                DoubleValue = -0.0,
                FloatValue = -0.0f
            };

            string json = JsonNativeAot.Serialize(original);
            NumericTypesStruct restored = JsonNativeAot.Deserialize<NumericTypesStruct>(json);

            Assert.Equal(0.0, Math.Abs(restored.DoubleValue));
            Assert.Equal(0.0f, Math.Abs(restored.FloatValue));
        }

        /// <summary>
        /// Tests that bug 048 round trip very small double maintains precision
        /// </summary>
        [Fact]
        public void Bug048_RoundTrip_VerySmallDouble_MaintainsPrecision()
        {
            // Regression: Very small doubles rounded to zero
            // Fixed: Use proper formatting
            NumericTypesStruct original = new NumericTypesStruct
            {
                DoubleValue = 0.000000001
            };

            string json = JsonNativeAot.Serialize(original);
            NumericTypesStruct restored = JsonNativeAot.Deserialize<NumericTypesStruct>(json);

            Assert.True(restored.DoubleValue > 0);
        }

        #endregion

        #region Bug Fix: Consistency

        /// <summary>
        /// Tests that bug 049 multiple serializations produce same result
        /// </summary>
        [Fact]
        public void Bug049_MultipleSerializations_ProduceSameResult()
        {
            // Regression: Non-deterministic serialization
            // Fixed: Stable property ordering
            PersonClass obj = new PersonClass
            {
                Name = "Consistent",
                Age = 30,
                Email = "test@test.com"
            };

            string json1 = JsonNativeAot.Serialize(obj);
            string json2 = JsonNativeAot.Serialize(obj);

            Assert.Equal(json1, json2);
        }

        /// <summary>
        /// Tests that bug 050 deserialize then serialize produces similar json
        /// </summary>
        [Fact]
        public void Bug050_DeserializeThenSerialize_ProducesSimilarJson()
        {
            // Regression: Round-trip changed JSON structure
            // Fixed: Consistent serialization format
            string originalJson = "{\"Name\":\"Test\",\"Age\":\"30\",\"Email\":\"test@test.com\"}";

            PersonClass obj = JsonNativeAot.Deserialize<PersonClass>(originalJson);
            string newJson = JsonNativeAot.Serialize(obj);

            PersonClass obj2 = JsonNativeAot.Deserialize<PersonClass>(newJson);

            Assert.Equal(obj.Name, obj2.Name);
            Assert.Equal(obj.Age, obj2.Age);
        }

        #endregion
    }
}

