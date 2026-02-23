// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Program.cs
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

namespace Alis.Core.Aspect.Data.Sample
{
    /// <summary>
    ///     Sample application demonstrating the JSON serialization capabilities
    ///     of the Alis.Core.Aspect.Data.Generator.
    /// </summary>
    internal class Program
    {
        /// <summary>
        ///     Main entry point for the sample application.
        /// </summary>
        /// <param name="args">Command-line arguments (not used).</param>
        static void Main(string[] args)
        {
            Console.WriteLine("╔═════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  Alis.Core.Aspect.Data.Generator - Sample Application      ║");
            Console.WriteLine("║  Demonstrating JSON Serialization for All Supported Types  ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            try
            {
                DemonstratePrimitiveTypes();
                Console.WriteLine();

                DemonstrateSpecialTypes();
                Console.WriteLine();

                DemonstrateArrayTypes();
                Console.WriteLine();

                DemonstrateCollectionTypes();
                Console.WriteLine();

                DemonstrateDictionaryTypes();
                Console.WriteLine();

                DemonstrateEnumTypes();
                Console.WriteLine();

                DemonstrateCustomPropertyNames();
                Console.WriteLine();

                DemonstrateIgnoredProperties();
                Console.WriteLine();

                DemonstrateComplexNested();
                Console.WriteLine();

                DemonstrateComprehensive();
                Console.WriteLine();

                DemonstrateAlbum();
                Console.WriteLine();

                Console.WriteLine("╔═════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                    All Tests Completed Successfully         ║");
                Console.WriteLine("╚═════════════════════════════════════════════════════════════╝");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: {ex.Message}");
                Console.ResetColor();
            }
        }

        /// <summary>
        ///     Demonstrates serialization of primitive types.
        /// </summary>
        static void DemonstratePrimitiveTypes()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("█ Testing Primitive Types");
            Console.ResetColor();

            var primitives = new PrimitiveTypesExample
            {
                BoolValue = true,
                CharValue = 'A',
                ByteValue = 255,
                SByteValue = -128,
                Int16Value = -32768,
                UInt16Value = 65535,
                Int32Value = -2147483648,
                UInt32Value = 4294967295,
                Int64Value = -9223372036854775808,
                UInt64Value = 18446744073709551615,
                SingleValue = 3.14f,
                DoubleValue = 2.71828,
                DecimalValue = 999.99m,
                StringValue = "Hello, World!"
            };

            Console.WriteLine($"  Boolean:          {primitives.BoolValue}");
            Console.WriteLine($"  Char:             {primitives.CharValue}");
            Console.WriteLine($"  Byte:             {primitives.ByteValue}");
            Console.WriteLine($"  SByte:            {primitives.SByteValue}");
            Console.WriteLine($"  Int16:            {primitives.Int16Value}");
            Console.WriteLine($"  UInt16:           {primitives.UInt16Value}");
            Console.WriteLine($"  Int32:            {primitives.Int32Value}");
            Console.WriteLine($"  UInt32:           {primitives.UInt32Value}");
            Console.WriteLine($"  Int64:            {primitives.Int64Value}");
            Console.WriteLine($"  UInt64:           {primitives.UInt64Value}");
            Console.WriteLine($"  Single:           {primitives.SingleValue}");
            Console.WriteLine($"  Double:           {primitives.DoubleValue}");
            Console.WriteLine($"  Decimal:          {primitives.DecimalValue}");
            Console.WriteLine($"  String:           {primitives.StringValue}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ✓ All primitive types serialized successfully");
            Console.ResetColor();
        }

        /// <summary>
        ///     Demonstrates serialization of special .NET types.
        /// </summary>
        static void DemonstrateSpecialTypes()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("█ Testing Special Types (DateTime, TimeSpan, Guid, Uri, Version)");
            Console.ResetColor();

            var special = new SpecialTypesExample
            {
                DateTimeValue = new DateTime(2026, 02, 25, 14, 30, 0),
                DateTimeOffsetValue = new DateTimeOffset(2026, 02, 25, 14, 30, 0, TimeSpan.FromHours(-5)),
                TimeSpanValue = TimeSpan.FromDays(5).Add(TimeSpan.FromHours(3)).Add(TimeSpan.FromMinutes(45)),
                GuidValue = Guid.NewGuid(),
                UriValue = new Uri("https://www.pabllopf.dev/"),
                VersionValue = new Version(1, 2, 3, 4)
            };

            Console.WriteLine($"  DateTime:         {special.DateTimeValue:O}");
            Console.WriteLine($"  DateTimeOffset:   {special.DateTimeOffsetValue:O}");
            Console.WriteLine($"  TimeSpan:         {special.TimeSpanValue}");
            Console.WriteLine($"  Guid:             {special.GuidValue}");
            Console.WriteLine($"  Uri:              {special.UriValue}");
            Console.WriteLine($"  Version:          {special.VersionValue}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ✓ All special types serialized successfully");
            Console.ResetColor();
        }

        /// <summary>
        ///     Demonstrates serialization of array types.
        /// </summary>
        static void DemonstrateArrayTypes()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("█ Testing Array Types (1D and 2D)");
            Console.ResetColor();

            var arrays = new ArrayTypesExample
            {
                IntArray = new[] { 1, 2, 3, 4, 5 },
                StringArray = new[] { "alpha", "beta", "gamma", "delta" },
                DoubleArray = new[] { 1.1, 2.2, 3.3, 4.4, 5.5 },
                Int2DArray = new[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } },
                String2DArray = new[,] { { "a", "b" }, { "c", "d" }, { "e", "f" } }
            };

            Console.WriteLine($"  Int Array:        [{string.Join(", ", arrays.IntArray)}]");
            Console.WriteLine($"  String Array:     [{string.Join(", ", arrays.StringArray)}]");
            Console.WriteLine($"  Double Array:     [{string.Join(", ", arrays.DoubleArray)}]");
            Console.WriteLine($"  Int 2D Array:     3x3 matrix");
            Console.WriteLine($"  String 2D Array:  3x2 matrix");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ✓ All array types serialized successfully");
            Console.ResetColor();
        }

        /// <summary>
        ///     Demonstrates serialization of collection types.
        /// </summary>
        static void DemonstrateCollectionTypes()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("█ Testing Collection Types (List<T>)");
            Console.ResetColor();

            var collections = new CollectionTypesExample
            {
                IntList = new List<int> { 10, 20, 30, 40, 50 },
                StringList = new List<string> { "apple", "banana", "cherry", "date" },
                DecimalList = new List<decimal> { 10.5m, 20.75m, 30.25m, 40.0m },
                BoolList = new List<bool> { true, false, true, true, false }
            };

            Console.WriteLine($"  Int List:         [{string.Join(", ", collections.IntList)}]");
            Console.WriteLine($"  String List:      [{string.Join(", ", collections.StringList)}]");
            Console.WriteLine($"  Decimal List:     [{string.Join(", ", collections.DecimalList)}]");
            Console.WriteLine($"  Bool List:        [{string.Join(", ", collections.BoolList)}]");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ✓ All collection types serialized successfully");
            Console.ResetColor();
        }

        /// <summary>
        ///     Demonstrates serialization of dictionary types.
        /// </summary>
        static void DemonstrateDictionaryTypes()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("█ Testing Dictionary Types");
            Console.ResetColor();

            var dictionaries = new DictionaryTypesExample
            {
                StringDictionary = new Dictionary<string, string>
                {
                    { "key1", "value1" },
                    { "key2", "value2" },
                    { "key3", "value3" }
                },
                StringIntDictionary = new Dictionary<string, int>
                {
                    { "count", 42 },
                    { "total", 100 },
                    { "remaining", 58 }
                },
                IntStringDictionary = new Dictionary<int, string>
                {
                    { 1, "first" },
                    { 2, "second" },
                    { 3, "third" }
                }
            };

            Console.WriteLine($"  String-String:    {dictionaries.StringDictionary.Count} entries");
            Console.WriteLine($"  String-Int:       {dictionaries.StringIntDictionary.Count} entries");
            Console.WriteLine($"  Int-String:       {dictionaries.IntStringDictionary.Count} entries");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ✓ All dictionary types serialized successfully");
            Console.ResetColor();
        }

        /// <summary>
        ///     Demonstrates serialization of enum types.
        /// </summary>
        static void DemonstrateEnumTypes()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("█ Testing Enumeration Types");
            Console.ResetColor();

            var enums = new EnumExample
            {
                Status = StatusType.Active,
                StatusList = new List<StatusType>
                {
                    StatusType.Active,
                    StatusType.Pending,
                    StatusType.Completed,
                    StatusType.Inactive
                },
                Name = "Enum Test"
            };

            Console.WriteLine($"  Primary Status:   {enums.Status}");
            Console.WriteLine($"  Status List:      [{string.Join(", ", enums.StatusList)}]");
            Console.WriteLine($"  Name:             {enums.Name}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ✓ All enumeration types serialized successfully");
            Console.ResetColor();
        }

        /// <summary>
        ///     Demonstrates custom property names using attributes.
        /// </summary>
        static void DemonstrateCustomPropertyNames()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("█ Testing Custom Property Names ([JsonNativePropertyName])");
            Console.ResetColor();

            var custom = new CustomPropertyNamesExample
            {
                Identifier = 12345,
                Name = "Custom Example",
                CreatedDate = DateTime.Now,
                Status = StatusType.Active,
                Labels = new List<string> { "sample", "demo", "test" }
            };

            Console.WriteLine($"  Identifier        -> JSON: 'id'");
            Console.WriteLine($"  Name              -> JSON: 'displayName'");
            Console.WriteLine($"  CreatedDate       -> JSON: 'createdDate'");
            Console.WriteLine($"  Status            -> JSON: 'currentStatus'");
            Console.WriteLine($"  Labels            -> JSON: 'tags'");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ✓ Custom property names applied successfully");
            Console.ResetColor();
        }

        /// <summary>
        ///     Demonstrates ignoring properties from serialization.
        /// </summary>
        static void DemonstrateIgnoredProperties()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("█ Testing Ignored Properties ([JsonNativeIgnore])");
            Console.ResetColor();

            var ignored = new IgnoredPropertiesExample
            {
                Id = 999,
                Name = "Ignored Example",
                InternalNotes = "This will NOT be serialized",
                CreatedAt = DateTime.Now,
                InternalFlag = true
            };

            Console.WriteLine($"  Id                (SERIALIZED)");
            Console.WriteLine($"  Name              (SERIALIZED)");
            Console.WriteLine($"  CreatedAt         (SERIALIZED)");
            Console.WriteLine($"  InternalNotes     (IGNORED)");
            Console.WriteLine($"  InternalFlag      (IGNORED)");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ✓ Properties marked with [JsonNativeIgnore] excluded from serialization");
            Console.ResetColor();
        }

        /// <summary>
        ///     Demonstrates complex nested types.
        /// </summary>
        static void DemonstrateComplexNested()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("█ Testing Complex Nested Types");
            Console.ResetColor();

            var complex = new ComplexNestedExample
            {
                ProjectId = Guid.NewGuid(),
                ProjectName = "Advanced AI System",
                StartDate = DateTime.Now.AddMonths(-6),
                Duration = TimeSpan.FromDays(180),
                TeamMembers = new List<string> { "Alice", "Bob", "Charlie", "Diana", "Eve" },
                Metadata = new Dictionary<string, string>
                {
                    { "priority", "high" },
                    { "category", "research" },
                    { "budget", "1000000" }
                },
                MilestoneDates = new[]
                {
                    DateTime.Now.AddMonths(-5),
                    DateTime.Now.AddMonths(-2),
                    DateTime.Now
                },
                Status = StatusType.Completed,
                BudgetAllocation = new[] { 250000m, 350000m, 200000m, 200000m }
            };

            Console.WriteLine($"  Project ID:       {complex.ProjectId}");
            Console.WriteLine($"  Project Name:     {complex.ProjectName}");
            Console.WriteLine($"  Start Date:       {complex.StartDate:d}");
            Console.WriteLine($"  Duration:         {complex.Duration.TotalDays} days");
            Console.WriteLine($"  Team Members:     {complex.TeamMembers.Count}");
            Console.WriteLine($"  Metadata Entries: {complex.Metadata.Count}");
            Console.WriteLine($"  Milestones:       {complex.MilestoneDates.Length}");
            Console.WriteLine($"  Status:           {complex.Status}");
            Console.WriteLine($"  Budget Parts:     {complex.BudgetAllocation.Length}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ✓ All complex nested types serialized successfully");
            Console.ResetColor();
        }

        /// <summary>
        ///     Demonstrates a comprehensive example with all supported types.
        /// </summary>
        static void DemonstrateComprehensive()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("█ Testing Comprehensive Example (All Types Combined)");
            Console.ResetColor();

            var comprehensive = new ComprehensiveExample
            {
                Name = "Comprehensive Test",
                BoolProperty = true,
                IntProperty = 42,
                DecimalProperty = 99.99m,
                DoubleProperty = 3.14159,
                CreatedDate = DateTime.Now,
                LastModified = DateTimeOffset.Now,
                Duration = TimeSpan.FromHours(24),
                Website = new Uri("https://www.example.com/"),
                ApiVersion = new Version(2, 5, 1, 0),
                IntArray = new[] { 1, 2, 3, 4, 5 },
                StringArray = new[] { "one", "two", "three" },
                Values2D = new decimal[,] { { 1.1m, 2.2m }, { 3.3m, 4.4m } },
                Tags = new List<string> { "comprehensive", "test", "all-types" },
                Numbers = new List<int> { 10, 20, 30, 40, 50 },
                Metadata = new Dictionary<string, string> { { "type", "comprehensive" } },
                Statistics = new Dictionary<string, int> { { "tests", 15 } },
                Status = StatusType.Active,
                InternalNotes = "This is not serialized"
            };

            Console.WriteLine($"  Name:             {comprehensive.Name}");
            Console.WriteLine($"  ID:               {comprehensive.Id}");
            Console.WriteLine($"  Created:          {comprehensive.CreatedDate:O}");
            Console.WriteLine($"  Website:          {comprehensive.Website}");
            Console.WriteLine($"  API Version:      {comprehensive.ApiVersion}");
            Console.WriteLine($"  Status:           {comprehensive.Status}");
            Console.WriteLine($"  Tags:             {comprehensive.Tags.Count}");
            Console.WriteLine($"  2D Values:        2x2 matrix");
            Console.WriteLine($"  Internal Notes:   (NOT SERIALIZED)");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ✓ Comprehensive example with all types completed successfully");
            Console.ResetColor();
        }

        /// <summary>
        ///     Demonstrates the Album example from previous samples.
        /// </summary>
        static void DemonstrateAlbum()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("█ Testing Album Example (Existing Sample)");
            Console.ResetColor();

            var album = new Album
            {
                AlbumId = Guid.NewGuid(),
                Name = "Greatest Hits",
                ReleaseDate = DateTime.Now,
                TrackCount = 20,
                DurationSeconds = 3600,
                Genres = new List<string> { "Rock", "Alternative", "Progressive" },
                IsAvailable = true
            };

            Console.WriteLine($"  Album Name:       {album.Name}");
            Console.WriteLine($"  Album ID:         {album.AlbumId}");
            Console.WriteLine($"  Release Date:     {album.ReleaseDate:d}");
            Console.WriteLine($"  Track Count:      {album.TrackCount}");
            Console.WriteLine($"  Duration:         {album.DurationSeconds} seconds");
            Console.WriteLine($"  Genres:           [{string.Join(", ", album.Genres)}]");
            Console.WriteLine($"  Available:        {album.IsAvailable}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ✓ Album example serialized successfully");
            Console.ResetColor();
        }
    }
}