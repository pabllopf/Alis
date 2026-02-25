// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: ComplexIntegrationTest.cs
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
using System.IO;
using System.Linq;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Data.Test.Json.Models;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json.Integration
{
    /// <summary>
    ///     Complex integration tests covering end-to-end scenarios.
    ///     Tests real-world use cases and complex data flows.
    /// </summary>
    public class ComplexIntegrationTest
    {
        #region Multi-Level Nesting Tests

        [Fact]
        public void Integration_ThreeLevelNesting_SerializesAndDeserializes()
        {
            // Arrange
            var original = new UserWithAddress
            {
                Username = "user123",
                UserId = 456,
                Address = new AddressClass
                {
                    Street = "123 Main St",
                    City = "Springfield",
                    Country = "USA",
                    ZipCode = "12345"
                }
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            var restored = JsonNativeAot.Deserialize<UserWithAddress>(json);

            // Assert
            Assert.Equal(original.Username, restored.Username);
            Assert.Equal(original.UserId, restored.UserId);
            Assert.NotNull(restored.Address);
            Assert.Equal(original.Address.Street, restored.Address.Street);
            Assert.Equal(original.Address.City, restored.Address.City);
            Assert.Equal(original.Address.Country, restored.Address.Country);
        }

        #endregion

        #region Collection of Complex Objects Tests

        [Fact]
        public void Integration_ListOfComplexObjects_SerializesCompletely()
        {
            // Arrange
            var products = new List<ProductClass>
            {
                new ProductClass { ProductId = 1, ProductName = "Laptop", Price = 999.99m, InStock = true, AddedDate = DateTime.Now },
                new ProductClass { ProductId = 2, ProductName = "Mouse", Price = 29.99m, InStock = true, AddedDate = DateTime.Now },
                new ProductClass { ProductId = 3, ProductName = "Keyboard", Price = 79.99m, InStock = false, AddedDate = DateTime.Now }
            };

            // Act - Serialize each individually
            var jsonList = products.Select(p => JsonNativeAot.Serialize(p)).ToList();

            // Assert
            Assert.Equal(3, jsonList.Count);
            foreach (var json in jsonList)
            {
                Assert.NotEmpty(json);
                Assert.Contains("ProductId", json);
                Assert.Contains("ProductName", json);
            }
        }

        #endregion

        #region Mixed Type Scenarios

        [Fact]
        public void Integration_MixedValueAndReferenceTypes_AllPreserved()
        {
            // Arrange
            var person = new PersonClass
            {
                Name = "Alice",
                Age = 30,
                Email = "alice@example.com"
            };

            var point = new Point2D(100, 200);

            var product = new ProductClass
            {
                ProductId = 42,
                ProductName = "Widget",
                Price = 19.99m,
                InStock = true,
                AddedDate = new DateTime(2023, 6, 15)
            };

            // Act
            string personJson = JsonNativeAot.Serialize(person);
            string pointJson = JsonNativeAot.Serialize(point);
            string productJson = JsonNativeAot.Serialize(product);

            var restoredPerson = JsonNativeAot.Deserialize<PersonClass>(personJson);
            var restoredPoint = JsonNativeAot.Deserialize<Point2D>(pointJson);
            var restoredProduct = JsonNativeAot.Deserialize<ProductClass>(productJson);

            // Assert
            Assert.Equal(person.Name, restoredPerson.Name);
            Assert.Equal(point.X, restoredPoint.X);
            Assert.Equal(product.ProductName, restoredProduct.ProductName);
        }

        #endregion

        #region File Operations Integration

        [Fact]
        public void Integration_SerializeToFile_AndReadBack_Successful()
        {
            // Arrange
            var settings = new AppSettings
            {
                AppName = "TestApp",
                Version = "1.0.0",
                Port = 8080,
                EnableLogging = true,
                EnableDebug = false,
                LogLevel = "Info"
            };

            string fileName = $"test_settings_{Guid.NewGuid()}";
            string path = "TestData";

            try
            {
                // Act
                JsonNativeAot.SerializeToFile(settings, fileName, path);
                var restored = JsonNativeAot.DeserializeFromFile<AppSettings>(fileName, path);

                // Assert
                Assert.Equal(settings.AppName, restored.AppName);
                Assert.Equal(settings.Version, restored.Version);
                Assert.Equal(settings.Port, restored.Port);
                Assert.Equal(settings.EnableLogging, restored.EnableLogging);
            }
            finally
            {
                // Cleanup
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), path, $"{fileName}.json");
                if (File.Exists(fullPath))
                    File.Delete(fullPath);
                var dir = Path.Combine(Directory.GetCurrentDirectory(), path);
                if (Directory.Exists(dir) && !Directory.GetFiles(dir).Any())
                    Directory.Delete(dir);
            }
        }

        [Fact]
        public void Integration_MultipleFileOperations_NoInterference()
        {
            // Arrange
            var person = new PersonClass { Name = "File Test Person", Age = 25, Email = "test@file.com" };
            var product = new ProductClass { ProductId = 999, ProductName = "File Test Product", Price = 99.99m, InStock = true, AddedDate = DateTime.Now };

            string fileName1 = $"test_person_{Guid.NewGuid()}";
            string fileName2 = $"test_product_{Guid.NewGuid()}";
            string path = "TestData";

            try
            {
                // Act
                JsonNativeAot.SerializeToFile(person, fileName1, path);
                JsonNativeAot.SerializeToFile(product, fileName2, path);

                var restoredPerson = JsonNativeAot.DeserializeFromFile<PersonClass>(fileName1, path);
                var restoredProduct = JsonNativeAot.DeserializeFromFile<ProductClass>(fileName2, path);

                // Assert
                Assert.Equal(person.Name, restoredPerson.Name);
                Assert.Equal(product.ProductName, restoredProduct.ProductName);
            }
            finally
            {
                // Cleanup
                var dir = Path.Combine(Directory.GetCurrentDirectory(), path);
                var file1 = Path.Combine(dir, $"{fileName1}.json");
                var file2 = Path.Combine(dir, $"{fileName2}.json");
                if (File.Exists(file1)) File.Delete(file1);
                if (File.Exists(file2)) File.Delete(file2);
                if (Directory.Exists(dir) && !Directory.GetFiles(dir).Any())
                    Directory.Delete(dir);
            }
        }

        #endregion

        #region Stress Tests

        [Fact]
        public void Integration_SerializeDeserialize1000Times_NoErrors()
        {
            // Arrange
            var original = new PersonClass
            {
                Name = "Stress Test",
                Age = 30,
                Email = "stress@test.com"
            };

            // Act & Assert
            for (int i = 0; i < 1000; i++)
            {
                string json = JsonNativeAot.Serialize(original);
                var restored = JsonNativeAot.Deserialize<PersonClass>(json);

                Assert.Equal(original.Name, restored.Name);
                Assert.Equal(original.Age, restored.Age);
            }
        }

        [Fact]
        public void Integration_ParallelSerialization_ThreadSafe()
        {
            // Arrange
            var objects = Enumerable.Range(0, 100).Select(i => new PersonClass
            {
                Name = $"Person{i}",
                Age = i,
                Email = $"person{i}@test.com"
            }).ToList();

            // Act
            var results = new System.Collections.Concurrent.ConcurrentBag<bool>();

            System.Threading.Tasks.Parallel.ForEach(objects, obj =>
            {
                try
                {
                    string json = JsonNativeAot.Serialize(obj);
                    var restored = JsonNativeAot.Deserialize<PersonClass>(json);
                    results.Add(restored.Name == obj.Name);
                }
                catch
                {
                    results.Add(false);
                }
            });

            // Assert
            Assert.All(results, r => Assert.True(r));
            Assert.Equal(100, results.Count);
        }

        #endregion

        #region Complex Data Structures

        [Fact]
        public void Integration_ComplexStruct_WithMultipleTypes()
        {
            // Arrange
            var config = new ConfigStruct
            {
                Status = StatusEnum.Active,
                Priority = PriorityEnum.Critical,
                Value = 12345
            };

            // Act
            string json = JsonNativeAot.Serialize(config);
            var restored = JsonNativeAot.Deserialize<ConfigStruct>(json);

            // Assert
            Assert.Equal(config.Status, restored.Status);
            Assert.Equal(config.Priority, restored.Priority);
            Assert.Equal(config.Value, restored.Value);
        }

        [Fact]
        public void Integration_NumericTypesClass_AllTypesRoundTrip()
        {
            // Arrange
            var original = new NumericTypesClass
            {
                ByteValue = 255,
                SByteValue = -128,
                ShortValue = -32768,
                UShortValue = 65535,
                IntValue = -2147483648,
                UIntValue = 4294967295,
                LongValue = long.MinValue,
                ULongValue = ulong.MaxValue,
                FloatValue = 3.14f,
                DoubleValue = 2.718281828,
                DecimalValue = 123.456789m
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            var restored = JsonNativeAot.Deserialize<NumericTypesClass>(json);

            // Assert
            Assert.Equal(original.ByteValue, restored.ByteValue);
            Assert.Equal(original.IntValue, restored.IntValue);
            Assert.Equal(original.LongValue, restored.LongValue);
            Assert.Equal(original.FloatValue, restored.FloatValue, 5);
            Assert.Equal(original.DecimalValue, restored.DecimalValue);
        }

        #endregion

        #region Edge Case Collections

        [Fact]
        public void Integration_EmptyCollections_HandleGracefully()
        {
            // Arrange
            var tags = new TagsClass
            {
                Name = "EmptyTest",
                Tags = new List<string>()
            };

            var scores = new ScoresClass
            {
                PlayerName = "Player1",
                Scores = new List<int>()
            };

            // Act
            string tagsJson = JsonNativeAot.Serialize(tags);
            string scoresJson = JsonNativeAot.Serialize(scores);

            var restoredTags = JsonNativeAot.Deserialize<TagsClass>(tagsJson);
            var restoredScores = JsonNativeAot.Deserialize<ScoresClass>(scoresJson);

            // Assert
            Assert.NotNull(restoredTags.Tags);
            Assert.Empty(restoredTags.Tags);
            Assert.NotNull(restoredScores.Scores);
            Assert.Empty(restoredScores.Scores);
        }

        [Fact]
        public void Integration_LargeCollections_HandledEfficiently()
        {
            // Arrange
            var tags = new TagsClass
            {
                Name = "LargeList",
                Tags = Enumerable.Range(0, 1000).Select(i => $"tag{i}").ToList()
            };

            // Act
            var sw = System.Diagnostics.Stopwatch.StartNew();
            string json = JsonNativeAot.Serialize(tags);
            var restored = JsonNativeAot.Deserialize<TagsClass>(json);
            sw.Stop();

            // Assert
            Assert.Equal(1000, restored.Tags.Count);
            Assert.True(sw.ElapsedMilliseconds < 1000, "Should complete within 1 second");
        }

        #endregion

        #region Temporal Data Tests

        [Fact]
        public void Integration_MultipleDateTimeFormats_HandleCorrectly()
        {
            // Arrange
            var timestamps = new[]
            {
                DateTime.Now,
                DateTime.Today,
                DateTime.UtcNow,
                new DateTime(2023, 1, 1, 0, 0, 0),
                new DateTime(2023, 12, 31, 23, 59, 59)
            };

            // Act & Assert
            foreach (var timestamp in timestamps)
            {
                var original = new TemporalTypesStruct
                {
                    Timestamp = timestamp,
                    Identifier = Guid.NewGuid()
                };

                string json = JsonNativeAot.Serialize(original);
                var restored = JsonNativeAot.Deserialize<TemporalTypesStruct>(json);

                Assert.Equal(original.Timestamp.Year, restored.Timestamp.Year);
                Assert.Equal(original.Timestamp.Month, restored.Timestamp.Month);
                Assert.Equal(original.Timestamp.Day, restored.Timestamp.Day);
            }
        }

        [Fact]
        public void Integration_MultipleGuids_AllUnique()
        {
            // Arrange
            var guids = Enumerable.Range(0, 100).Select(_ => new TemporalTypesStruct
            {
                Timestamp = DateTime.Now,
                Identifier = Guid.NewGuid()
            }).ToList();

            // Act
            var jsonList = guids.Select(g => JsonNativeAot.Serialize(g)).ToList();
            var restored = jsonList.Select(json => JsonNativeAot.Deserialize<TemporalTypesStruct>(json)).ToList();

            // Assert
            var uniqueGuids = restored.Select(r => r.Identifier).Distinct().Count();
            Assert.Equal(100, uniqueGuids);
        }

        #endregion

        #region Audit and Logging Integration

        [Fact]
        public void Integration_AuditTrail_CompleteWorkflow()
        {
            // Arrange
            var audits = new[]
            {
                new AuditTrailStruct { Action = "CREATE", User = "admin", When = DateTime.Now, Success = true },
                new AuditTrailStruct { Action = "UPDATE", User = "user1", When = DateTime.Now.AddMinutes(5), Success = true },
                new AuditTrailStruct { Action = "DELETE", User = "admin", When = DateTime.Now.AddMinutes(10), Success = false }
            };

            // Act
            var jsonAudits = audits.Select(a => JsonNativeAot.Serialize(a)).ToList();
            var restored = jsonAudits.Select(json => JsonNativeAot.Deserialize<AuditTrailStruct>(json)).ToList();

            // Assert
            Assert.Equal(3, restored.Count);
            Assert.Equal("CREATE", restored[0].Action);
            Assert.Equal("UPDATE", restored[1].Action);
            Assert.Equal("DELETE", restored[2].Action);
            Assert.True(restored[0].Success);
            Assert.False(restored[2].Success);
        }

        [Fact]
        public void Integration_LogEntries_WithDifferentLevels()
        {
            // Arrange
            var logs = new[]
            {
                new LogEntry { LogId = Guid.NewGuid(), Timestamp = DateTime.Now, Level = "DEBUG", Message = "Debug message", Source = "App" },
                new LogEntry { LogId = Guid.NewGuid(), Timestamp = DateTime.Now, Level = "INFO", Message = "Info message", Source = "Service" },
                new LogEntry { LogId = Guid.NewGuid(), Timestamp = DateTime.Now, Level = "ERROR", Message = "Error occurred", Source = "Database" }
            };

            // Act
            var jsonLogs = logs.Select(l => JsonNativeAot.Serialize(l)).ToList();
            var restored = jsonLogs.Select(json => JsonNativeAot.Deserialize<LogEntry>(json)).ToList();

            // Assert
            Assert.Equal(3, restored.Count);
            Assert.Contains(restored, l => l.Level == "DEBUG");
            Assert.Contains(restored, l => l.Level == "INFO");
            Assert.Contains(restored, l => l.Level == "ERROR");
        }

        #endregion

        #region Configuration Scenarios

        [Fact]
        public void Integration_AppSettings_CompleteConfiguration()
        {
            // Arrange
            var settings = new AppSettings
            {
                AppName = "MyApplication",
                Version = "2.1.0",
                Port = 8443,
                EnableLogging = true,
                EnableDebug = true,
                LogLevel = "Trace"
            };

            // Act
            string json = JsonNativeAot.Serialize(settings);
            var restored = JsonNativeAot.Deserialize<AppSettings>(json);

            // Assert
            Assert.Equal(settings.AppName, restored.AppName);
            Assert.Equal(settings.Version, restored.Version);
            Assert.Equal(settings.Port, restored.Port);
            Assert.Equal(settings.EnableLogging, restored.EnableLogging);
            Assert.Equal(settings.EnableDebug, restored.EnableDebug);
            Assert.Equal(settings.LogLevel, restored.LogLevel);
        }

        [Fact]
        public void Integration_DatabaseConnection_MultipleConnections()
        {
            // Arrange
            var connections = new[]
            {
                new DbConnectionStruct { Host = "localhost", Port = 5432, Database = "maindb", Timeout = 30 },
                new DbConnectionStruct { Host = "remote.server.com", Port = 3306, Database = "backupdb", Timeout = 60 },
                new DbConnectionStruct { Host = "127.0.0.1", Port = 27017, Database = "mongodb", Timeout = 45 }
            };

            // Act
            var jsons = connections.Select(c => JsonNativeAot.Serialize(c)).ToList();
            var restored = jsons.Select(json => JsonNativeAot.Deserialize<DbConnectionStruct>(json)).ToList();

            // Assert
            Assert.Equal(3, restored.Count);
            Assert.Equal("localhost", restored[0].Host);
            Assert.Equal(5432, restored[0].Port);
            Assert.Equal("remote.server.com", restored[1].Host);
            Assert.Equal(3306, restored[1].Port);
        }

        #endregion

        #region Point and Coordinate Tests

        [Fact]
        public void Integration_Point2D_MultipleCoordinates()
        {
            // Arrange
            var points = new[]
            {
                new Point2D(0, 0),
                new Point2D(100, 200),
                new Point2D(-50, -75),
                new Point2D(int.MaxValue, int.MinValue)
            };

            // Act
            var jsons = points.Select(p => JsonNativeAot.Serialize(p)).ToList();
            var restored = jsons.Select(json => JsonNativeAot.Deserialize<Point2D>(json)).ToList();

            // Assert
            for (int i = 0; i < points.Length; i++)
            {
                Assert.Equal(points[i].X, restored[i].X);
                Assert.Equal(points[i].Y, restored[i].Y);
            }
        }

        [Fact]
        public void Integration_Point3D_WithDecimals()
        {
            // Arrange
            var points = new[]
            {
                new Point3D(0.0, 0.0, 0.0),
                new Point3D(1.5, 2.5, 3.5),
                new Point3D(-10.123, 20.456, -30.789),
                new Point3D(100.1, 200.2, 300.3)
            };

            // Act
            var jsons = points.Select(p => JsonNativeAot.Serialize(p)).ToList();
            var restored = jsons.Select(json => JsonNativeAot.Deserialize<Point3D>(json)).ToList();

            // Assert
            for (int i = 0; i < points.Length; i++)
            {
                Assert.Equal(points[i].X, restored[i].X, 5);
                Assert.Equal(points[i].Y, restored[i].Y, 5);
                Assert.Equal(points[i].Z, restored[i].Z, 5);
            }
        }

        #endregion

        #region Product and Order Integration

        [Fact]
        public void Integration_ProductCatalog_MultipleProducts()
        {
            // Arrange
            var products = new[]
            {
                new ProductClass { ProductId = 1, ProductName = "Laptop", Price = 1299.99m, InStock = true, AddedDate = DateTime.Now },
                new ProductClass { ProductId = 2, ProductName = "Mouse", Price = 29.99m, InStock = true, AddedDate = DateTime.Now.AddDays(-1) },
                new ProductClass { ProductId = 3, ProductName = "Monitor", Price = 399.99m, InStock = false, AddedDate = DateTime.Now.AddDays(-2) },
                new ProductClass { ProductId = 4, ProductName = "Keyboard", Price = 79.99m, InStock = true, AddedDate = DateTime.Now.AddDays(-3) }
            };

            // Act
            var jsons = products.Select(p => JsonNativeAot.Serialize(p)).ToList();
            var restored = jsons.Select(json => JsonNativeAot.Deserialize<ProductClass>(json)).ToList();

            // Assert
            Assert.Equal(4, restored.Count);
            Assert.All(restored, p => Assert.NotNull(p.ProductName));
            Assert.Contains(restored, p => p.InStock == false);
        }

        [Fact]
        public void Integration_OrderItems_CompleteOrder()
        {
            // Arrange
            var orderItems = new[]
            {
                new OrderItemStruct { ProductId = 101, Quantity = 2, UnitPrice = 19.99m },
                new OrderItemStruct { ProductId = 102, Quantity = 1, UnitPrice = 49.99m },
                new OrderItemStruct { ProductId = 103, Quantity = 5, UnitPrice = 9.99m }
            };

            // Act
            var jsons = orderItems.Select(item => JsonNativeAot.Serialize(item)).ToList();
            var restored = jsons.Select(json => JsonNativeAot.Deserialize<OrderItemStruct>(json)).ToList();

            // Calculate totals
            decimal originalTotal = orderItems.Sum(item => item.Quantity * item.UnitPrice);
            decimal restoredTotal = restored.Sum(item => item.Quantity * item.UnitPrice);

            // Assert
            Assert.Equal(3, restored.Count);
            Assert.Equal(originalTotal, restoredTotal);
        }

        #endregion

        #region Performance Benchmarks

        [Fact]
        public void Integration_PerformanceBenchmark_SimpleType()
        {
            // Arrange
            var obj = new MinimalClass { Value = "Performance Test" };
            const int iterations = 10000;

            // Act
            var sw = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                string json = JsonNativeAot.Serialize(obj);
                var restored = JsonNativeAot.Deserialize<MinimalClass>(json);
            }
            sw.Stop();

            // Assert
            double avgMs = sw.ElapsedMilliseconds / (double)iterations;
            Assert.True(avgMs < 1.0, $"Average time per iteration: {avgMs}ms (should be < 1ms)");
        }

        [Fact]
        public void Integration_PerformanceBenchmark_ComplexType()
        {
            // Arrange
            var obj = new ProductClass
            {
                ProductId = 999,
                ProductName = "Performance Test Product",
                Price = 99.99m,
                InStock = true,
                AddedDate = DateTime.Now
            };
            const int iterations = 5000;

            // Act
            var sw = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                string json = JsonNativeAot.Serialize(obj);
                var restored = JsonNativeAot.Deserialize<ProductClass>(json);
            }
            sw.Stop();

            // Assert
            double avgMs = sw.ElapsedMilliseconds / (double)iterations;
            Assert.True(avgMs < 2.0, $"Average time per iteration: {avgMs}ms (should be < 2ms)");
        }

        #endregion
    }
}

