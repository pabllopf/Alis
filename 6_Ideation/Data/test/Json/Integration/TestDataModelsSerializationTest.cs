// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: TestDataModelsSerializationTest.cs
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
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Data.Test.Json.Models;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json.Integration
{
    /// <summary>
    ///     Comprehensive serialization tests for all test data models.
    ///     Tests round-trip serialization/deserialization for classes and structs.
    /// </summary>
    public class TestDataModelsSerializationTest
    {
        #region PersonClass Tests

        /// <summary>
        /// Tests that serialize person class produces valid json
        /// </summary>
        [Fact]
        public void Serialize_PersonClass_ProducesValidJson()
        {
            // Arrange
            PersonClass person = new PersonClass
            {
                Name = "John Doe",
                Age = 30,
                Email = "john@example.com"
            };

            // Act
            string json = JsonNativeAot.Serialize(person);

            // Assert
            Assert.NotEmpty(json);
            Assert.Contains("John Doe", json);
            Assert.Contains("30", json);
            Assert.Contains("john@example.com", json);
        }

        /// <summary>
        /// Tests that round trip person class preserves all properties
        /// </summary>
        [Fact]
        public void RoundTrip_PersonClass_PreservesAllProperties()
        {
            // Arrange
            PersonClass original = new PersonClass
            {
                Name = "Alice Smith",
                Age = 25,
                Email = "alice@test.com"
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            PersonClass restored = JsonNativeAot.Deserialize<PersonClass>(json);

            // Assert
            Assert.Equal(original.Name, restored.Name);
            Assert.Equal(original.Age, restored.Age);
            Assert.Equal(original.Email, restored.Email);
        }

        /// <summary>
        /// Tests that round trip person class with various values
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="age">The age</param>
        /// <param name="email">The email</param>
        [Theory]
        [InlineData("", 0, "")]
        [InlineData("Test", 1, "test@mail.com")]
        [InlineData("Very Long Name With Spaces", 100, "email@domain.co.uk")]
        public void RoundTrip_PersonClass_WithVariousValues(string name, int age, string email)
        {
            // Arrange
            PersonClass original = new PersonClass { Name = name, Age = age, Email = email };

            // Act
            string json = JsonNativeAot.Serialize(original);
            PersonClass restored = JsonNativeAot.Deserialize<PersonClass>(json);

            // Assert
            Assert.Equal(original.Name, restored.Name);
            Assert.Equal(original.Age, restored.Age);
            Assert.Equal(original.Email, restored.Email);
        }

        #endregion

        #region PersonStruct Tests

        /// <summary>
        /// Tests that serialize person struct produces valid json
        /// </summary>
        [Fact]
        public void Serialize_PersonStruct_ProducesValidJson()
        {
            // Arrange
            PersonStruct person = new PersonStruct
            {
                Name = "Bob Jones",
                Age = 40,
                IsActive = true
            };

            // Act
            string json = JsonNativeAot.Serialize(person);

            // Assert
            Assert.NotEmpty(json);
            Assert.Contains("Bob Jones", json);
            Assert.Contains("40", json);
            Assert.Contains("True", json);
        }

        /// <summary>
        /// Tests that round trip person struct preserves all properties
        /// </summary>
        [Fact]
        public void RoundTrip_PersonStruct_PreservesAllProperties()
        {
            // Arrange
            PersonStruct original = new PersonStruct
            {
                Name = "Carol White",
                Age = 35,
                IsActive = false
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            PersonStruct restored = JsonNativeAot.Deserialize<PersonStruct>(json);

            // Assert
            Assert.Equal(original.Name, restored.Name);
            Assert.Equal(original.Age, restored.Age);
            Assert.Equal(original.IsActive, restored.IsActive);
        }

        /// <summary>
        /// Tests that round trip person struct with different active states
        /// </summary>
        /// <param name="isActive">The is active</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void RoundTrip_PersonStruct_WithDifferentActiveStates(bool isActive)
        {
            // Arrange
            PersonStruct original = new PersonStruct { Name = "Test", Age = 20, IsActive = isActive };

            // Act
            string json = JsonNativeAot.Serialize(original);
            PersonStruct restored = JsonNativeAot.Deserialize<PersonStruct>(json);

            // Assert
            Assert.Equal(original.IsActive, restored.IsActive);
        }

        #endregion

        #region NumericTypesClass Tests

        /// <summary>
        /// Tests that round trip numeric types class preserves all numeric types
        /// </summary>
        [Fact]
        public void RoundTrip_NumericTypesClass_PreservesAllNumericTypes()
        {
            // Arrange
            NumericTypesClass original = new NumericTypesClass
            {
                ByteValue = 255,
                SByteValue = -128,
                ShortValue = -32768,
                UShortValue = 65535,
                IntValue = -2147483648,
                UIntValue = 4294967295,
                LongValue = -9223372036854775808,
                ULongValue = 18446744073709551615,
                FloatValue = 3.14f,
                DoubleValue = 2.718281828,
                DecimalValue = 123.456789m
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            NumericTypesClass restored = JsonNativeAot.Deserialize<NumericTypesClass>(json);

            // Assert
            Assert.Equal(original.ByteValue, restored.ByteValue);
            Assert.Equal(original.SByteValue, restored.SByteValue);
            Assert.Equal(original.ShortValue, restored.ShortValue);
            Assert.Equal(original.UShortValue, restored.UShortValue);
            Assert.Equal(original.IntValue, restored.IntValue);
            Assert.Equal(original.UIntValue, restored.UIntValue);
            Assert.Equal(original.LongValue, restored.LongValue);
            Assert.Equal(original.ULongValue, restored.ULongValue);
            Assert.Equal(original.FloatValue, restored.FloatValue, 5);
            Assert.Equal(original.DoubleValue, restored.DoubleValue, 10);
            Assert.Equal(original.DecimalValue, restored.DecimalValue);
        }

        /// <summary>
        /// Tests that round trip numeric types class with zero values
        /// </summary>
        [Fact]
        public void RoundTrip_NumericTypesClass_WithZeroValues()
        {
            // Arrange
            NumericTypesClass original = new NumericTypesClass();

            // Act
            string json = JsonNativeAot.Serialize(original);
            NumericTypesClass restored = JsonNativeAot.Deserialize<NumericTypesClass>(json);

            // Assert
            Assert.Equal(0, restored.ByteValue);
            Assert.Equal(0, restored.IntValue);
            Assert.Equal(0.0, restored.DoubleValue);
        }

        /// <summary>
        /// Tests that round trip numeric types class with max values
        /// </summary>
        [Fact]
        public void RoundTrip_NumericTypesClass_WithMaxValues()
        {
            // Arrange
            NumericTypesClass original = new NumericTypesClass
            {
                ByteValue = byte.MaxValue,
                ShortValue = short.MaxValue,
                IntValue = int.MaxValue,
                LongValue = long.MaxValue,
                FloatValue = float.MaxValue,
                DoubleValue = double.MaxValue,
                DecimalValue = decimal.MaxValue
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            NumericTypesClass restored = JsonNativeAot.Deserialize<NumericTypesClass>(json);

            // Assert
            Assert.Equal(original.ByteValue, restored.ByteValue);
            Assert.Equal(original.ShortValue, restored.ShortValue);
            Assert.Equal(original.IntValue, restored.IntValue);
        }

        #endregion

        #region NumericTypesStruct Tests

        /// <summary>
        /// Tests that round trip numeric types struct preserves values
        /// </summary>
        [Fact]
        public void RoundTrip_NumericTypesStruct_PreservesValues()
        {
            // Arrange
            NumericTypesStruct original = new NumericTypesStruct
            {
                IntValue = 42,
                DoubleValue = 3.14159,
                FloatValue = 2.71f,
                DecimalValue = 99.99m
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            NumericTypesStruct restored = JsonNativeAot.Deserialize<NumericTypesStruct>(json);

            // Assert
            Assert.Equal(original.IntValue, restored.IntValue);
            Assert.Equal(original.DoubleValue, restored.DoubleValue, 5);
            Assert.Equal(original.FloatValue, restored.FloatValue, 2);
            Assert.Equal(original.DecimalValue, restored.DecimalValue);
        }

        /// <summary>
        /// Tests that round trip numeric types struct with various values
        /// </summary>
        /// <param name="i">The </param>
        /// <param name="d">The </param>
        /// <param name="f">The </param>
        /// <param name="dec">The dec</param>
        [Theory]
        [InlineData(0, 0.0, 0.0f, 0)]
        [InlineData(100, 100.5, 100.5f, 100.50)]
        [InlineData(-50, -50.25, -50.25f, -50.25)]
        public void RoundTrip_NumericTypesStruct_WithVariousValues(int i, double d, float f, double dec)
        {
            // Arrange
            NumericTypesStruct original = new NumericTypesStruct
            {
                IntValue = i,
                DoubleValue = d,
                FloatValue = f,
                DecimalValue = (decimal)dec
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            NumericTypesStruct restored = JsonNativeAot.Deserialize<NumericTypesStruct>(json);

            // Assert
            Assert.Equal(original.IntValue, restored.IntValue);
            Assert.Equal(original.DecimalValue, restored.DecimalValue);
        }

        #endregion

        #region TemporalTypesClass Tests

        /// <summary>
        /// Tests that round trip temporal types class preserves date time and guid
        /// </summary>
        [Fact]
        public void RoundTrip_TemporalTypesClass_PreservesDateTimeAndGuid()
        {
            // Arrange
            DateTime now = DateTime.Now;
            Guid guid1 = Guid.NewGuid();
            Guid guid2 = Guid.NewGuid();
            TemporalTypesClass original = new TemporalTypesClass
            {
                CreatedAt = now,
                UpdatedAt = now.AddDays(1),
                Id = guid1,
                CorrelationId = guid2
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            TemporalTypesClass restored = JsonNativeAot.Deserialize<TemporalTypesClass>(json);

            // Assert
            Assert.Equal(original.CreatedAt.Year, restored.CreatedAt.Year);
            Assert.Equal(original.CreatedAt.Month, restored.CreatedAt.Month);
            Assert.Equal(original.CreatedAt.Day, restored.CreatedAt.Day);
            Assert.Equal(original.Id, restored.Id);
            Assert.Equal(original.CorrelationId, restored.CorrelationId);
        }

        /// <summary>
        /// Tests that round trip temporal types class with empty guid
        /// </summary>
        [Fact]
        public void RoundTrip_TemporalTypesClass_WithEmptyGuid()
        {
            // Arrange
            TemporalTypesClass original = new TemporalTypesClass
            {
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MaxValue,
                Id = Guid.Empty,
                CorrelationId = Guid.Empty
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            TemporalTypesClass restored = JsonNativeAot.Deserialize<TemporalTypesClass>(json);

            // Assert
            Assert.Equal(Guid.Empty, restored.Id);
            Assert.Equal(Guid.Empty, restored.CorrelationId);
        }

        #endregion

        #region TemporalTypesStruct Tests

        /// <summary>
        /// Tests that round trip temporal types struct preserves values
        /// </summary>
        [Fact]
        public void RoundTrip_TemporalTypesStruct_PreservesValues()
        {
            // Arrange
            DateTime timestamp = new DateTime(2023, 6, 15, 10, 30, 45);
            Guid guid = Guid.NewGuid();
            TemporalTypesStruct original = new TemporalTypesStruct
            {
                Timestamp = timestamp,
                Identifier = guid
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            TemporalTypesStruct restored = JsonNativeAot.Deserialize<TemporalTypesStruct>(json);

            // Assert
            Assert.Equal(original.Timestamp.Year, restored.Timestamp.Year);
            Assert.Equal(original.Timestamp.Month, restored.Timestamp.Month);
            Assert.Equal(original.Identifier, restored.Identifier);
        }

        #endregion

        #region EntityWithEnums Tests

        /// <summary>
        /// Tests that round trip entity with enums preserves enum values
        /// </summary>
        [Fact]
        public void RoundTrip_EntityWithEnums_PreservesEnumValues()
        {
            // Arrange
            EntityWithEnums original = new EntityWithEnums
            {
                Name = "Entity1",
                Status = StatusEnum.Active,
                Priority = PriorityEnum.High
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            EntityWithEnums restored = JsonNativeAot.Deserialize<EntityWithEnums>(json);

            // Assert
            Assert.Equal(original.Name, restored.Name);
            Assert.Equal(original.Status, restored.Status);
            Assert.Equal(original.Priority, restored.Priority);
        }

        /// <summary>
        /// Tests that round trip entity with enums with all combinations
        /// </summary>
        /// <param name="status">The status</param>
        /// <param name="priority">The priority</param>
        [Theory]
        [InlineData(StatusEnum.Unknown, PriorityEnum.Low)]
        [InlineData(StatusEnum.Active, PriorityEnum.Normal)]
        [InlineData(StatusEnum.Inactive, PriorityEnum.High)]
        [InlineData(StatusEnum.Pending, PriorityEnum.Critical)]
        [InlineData(StatusEnum.Deleted, PriorityEnum.Low)]
        public void RoundTrip_EntityWithEnums_WithAllCombinations(StatusEnum status, PriorityEnum priority)
        {
            // Arrange
            EntityWithEnums original = new EntityWithEnums
            {
                Name = "Test",
                Status = status,
                Priority = priority
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            EntityWithEnums restored = JsonNativeAot.Deserialize<EntityWithEnums>(json);

            // Assert
            Assert.Equal(original.Status, restored.Status);
            Assert.Equal(original.Priority, restored.Priority);
        }

        #endregion

        #region ConfigStruct Tests

        /// <summary>
        /// Tests that round trip config struct preserves values
        /// </summary>
        [Fact]
        public void RoundTrip_ConfigStruct_PreservesValues()
        {
            // Arrange
            ConfigStruct original = new ConfigStruct
            {
                Status = StatusEnum.Active,
                Priority = PriorityEnum.Critical,
                Value = 100
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            ConfigStruct restored = JsonNativeAot.Deserialize<ConfigStruct>(json);

            // Assert
            Assert.Equal(original.Status, restored.Status);
            Assert.Equal(original.Priority, restored.Priority);
            Assert.Equal(original.Value, restored.Value);
        }

        #endregion

        #region AddressClass and UserWithAddress Tests

        /// <summary>
        /// Tests that round trip address class preserves all fields
        /// </summary>
        [Fact]
        public void RoundTrip_AddressClass_PreservesAllFields()
        {
            // Arrange
            AddressClass original = new AddressClass
            {
                Street = "123 Main St",
                City = "Springfield",
                Country = "USA",
                ZipCode = "12345"
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            AddressClass restored = JsonNativeAot.Deserialize<AddressClass>(json);

            // Assert
            Assert.Equal(original.Street, restored.Street);
            Assert.Equal(original.City, restored.City);
            Assert.Equal(original.Country, restored.Country);
            Assert.Equal(original.ZipCode, restored.ZipCode);
        }

        /// <summary>
        /// Tests that round trip user with address preserves nested object
        /// </summary>
        [Fact]
        public void RoundTrip_UserWithAddress_PreservesNestedObject()
        {
            // Arrange
            UserWithAddress original = new UserWithAddress
            {
                Username = "johndoe",
                UserId = 42,
                Address = new AddressClass
                {
                    Street = "456 Oak Ave",
                    City = "Portland",
                    Country = "USA",
                    ZipCode = "97201"
                }
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            UserWithAddress restored = JsonNativeAot.Deserialize<UserWithAddress>(json);

            // Assert
            Assert.Equal(original.Username, restored.Username);
            Assert.Equal(original.UserId, restored.UserId);
            Assert.NotNull(restored.Address);
            Assert.Equal(original.Address.Street, restored.Address.Street);
            Assert.Equal(original.Address.City, restored.Address.City);
        }

        /// <summary>
        /// Tests that round trip user with address with null address
        /// </summary>
        [Fact]
        public void RoundTrip_UserWithAddress_WithNullAddress()
        {
            // Arrange
            UserWithAddress original = new UserWithAddress
            {
                Username = "testuser",
                UserId = 99,
                Address = null
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            UserWithAddress restored = JsonNativeAot.Deserialize<UserWithAddress>(json);

            // Assert
            Assert.Equal(original.Username, restored.Username);
            Assert.Equal(original.UserId, restored.UserId);
        }

        #endregion

        #region Point2D and Point3D Tests

        /// <summary>
        /// Tests that round trip point 2 d preserves coordinates
        /// </summary>
        [Fact]
        public void RoundTrip_Point2D_PreservesCoordinates()
        {
            // Arrange
            Point2D original = new Point2D(10, 20);

            // Act
            string json = JsonNativeAot.Serialize(original);
            Point2D restored = JsonNativeAot.Deserialize<Point2D>(json);

            // Assert
            Assert.Equal(original.X, restored.X);
            Assert.Equal(original.Y, restored.Y);
        }

        /// <summary>
        /// Tests that round trip point 2 d with various coordinates
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [Theory]
        [InlineData(0, 0)]
        [InlineData(100, -100)]
        [InlineData(-50, 50)]
        [InlineData(int.MaxValue, int.MinValue)]
        public void RoundTrip_Point2D_WithVariousCoordinates(int x, int y)
        {
            // Arrange
            Point2D original = new Point2D(x, y);

            // Act
            string json = JsonNativeAot.Serialize(original);
            Point2D restored = JsonNativeAot.Deserialize<Point2D>(json);

            // Assert
            Assert.Equal(original.X, restored.X);
            Assert.Equal(original.Y, restored.Y);
        }

        /// <summary>
        /// Tests that round trip point 3 d preserves coordinates
        /// </summary>
        [Fact]
        public void RoundTrip_Point3D_PreservesCoordinates()
        {
            // Arrange
            Point3D original = new Point3D(1.5, 2.5, 3.5);

            // Act
            string json = JsonNativeAot.Serialize(original);
            Point3D restored = JsonNativeAot.Deserialize<Point3D>(json);

            // Assert
            Assert.Equal(original.X, restored.X, 5);
            Assert.Equal(original.Y, restored.Y, 5);
            Assert.Equal(original.Z, restored.Z, 5);
        }

        /// <summary>
        /// Tests that round trip point 3 d with various coordinates
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="z">The </param>
        [Theory]
        [InlineData(0.0, 0.0, 0.0)]
        [InlineData(1.1, 2.2, 3.3)]
        [InlineData(-5.5, -6.6, -7.7)]
        public void RoundTrip_Point3D_WithVariousCoordinates(double x, double y, double z)
        {
            // Arrange
            Point3D original = new Point3D(x, y, z);

            // Act
            string json = JsonNativeAot.Serialize(original);
            Point3D restored = JsonNativeAot.Deserialize<Point3D>(json);

            // Assert
            Assert.Equal(original.X, restored.X, 5);
            Assert.Equal(original.Y, restored.Y, 5);
            Assert.Equal(original.Z, restored.Z, 5);
        }

        #endregion

        #region ProductClass and OrderItemStruct Tests

        /// <summary>
        /// Tests that round trip product class preserves all properties
        /// </summary>
        [Fact]
        public void RoundTrip_ProductClass_PreservesAllProperties()
        {
            // Arrange
            ProductClass original = new ProductClass
            {
                ProductId = 101,
                ProductName = "Laptop",
                Price = 999.99m,
                InStock = true,
                AddedDate = new DateTime(2023, 1, 1)
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            ProductClass restored = JsonNativeAot.Deserialize<ProductClass>(json);

            // Assert
            Assert.Equal(original.ProductId, restored.ProductId);
            Assert.Equal(original.ProductName, restored.ProductName);
            Assert.Equal(original.Price, restored.Price);
            Assert.Equal(original.InStock, restored.InStock);
            Assert.Equal(original.AddedDate.Year, restored.AddedDate.Year);
        }

        /// <summary>
        /// Tests that round trip order item struct preserves values
        /// </summary>
        [Fact]
        public void RoundTrip_OrderItemStruct_PreservesValues()
        {
            // Arrange
            OrderItemStruct original = new OrderItemStruct
            {
                ProductId = 202,
                Quantity = 5,
                UnitPrice = 19.99m
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            OrderItemStruct restored = JsonNativeAot.Deserialize<OrderItemStruct>(json);

            // Assert
            Assert.Equal(original.ProductId, restored.ProductId);
            Assert.Equal(original.Quantity, restored.Quantity);
            Assert.Equal(original.UnitPrice, restored.UnitPrice);
        }

        #endregion

        #region AppSettings and DbConnectionStruct Tests

        /// <summary>
        /// Tests that round trip app settings preserves configuration
        /// </summary>
        [Fact]
        public void RoundTrip_AppSettings_PreservesConfiguration()
        {
            // Arrange
            AppSettings original = new AppSettings
            {
                AppName = "TestApp",
                Version = "1.0.0",
                Port = 8080,
                EnableLogging = true,
                EnableDebug = false,
                LogLevel = "Info"
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            AppSettings restored = JsonNativeAot.Deserialize<AppSettings>(json);

            // Assert
            Assert.Equal(original.AppName, restored.AppName);
            Assert.Equal(original.Version, restored.Version);
            Assert.Equal(original.Port, restored.Port);
            Assert.Equal(original.EnableLogging, restored.EnableLogging);
            Assert.Equal(original.EnableDebug, restored.EnableDebug);
            Assert.Equal(original.LogLevel, restored.LogLevel);
        }

        /// <summary>
        /// Tests that round trip db connection struct preserves connection details
        /// </summary>
        [Fact]
        public void RoundTrip_DbConnectionStruct_PreservesConnectionDetails()
        {
            // Arrange
            DbConnectionStruct original = new DbConnectionStruct
            {
                Host = "localhost",
                Port = 5432,
                Database = "testdb",
                Timeout = 30
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            DbConnectionStruct restored = JsonNativeAot.Deserialize<DbConnectionStruct>(json);

            // Assert
            Assert.Equal(original.Host, restored.Host);
            Assert.Equal(original.Port, restored.Port);
            Assert.Equal(original.Database, restored.Database);
            Assert.Equal(original.Timeout, restored.Timeout);
        }

        #endregion

        #region LogEntry and AuditTrailStruct Tests

        /// <summary>
        /// Tests that round trip log entry preserves log data
        /// </summary>
        [Fact]
        public void RoundTrip_LogEntry_PreservesLogData()
        {
            // Arrange
            Guid logId = Guid.NewGuid();
            LogEntry original = new LogEntry
            {
                LogId = logId,
                Timestamp = DateTime.Now,
                Level = "ERROR",
                Message = "An error occurred",
                Source = "TestModule"
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            LogEntry restored = JsonNativeAot.Deserialize<LogEntry>(json);

            // Assert
            Assert.Equal(original.LogId, restored.LogId);
            Assert.Equal(original.Level, restored.Level);
            Assert.Equal(original.Message, restored.Message);
            Assert.Equal(original.Source, restored.Source);
        }

        /// <summary>
        /// Tests that round trip audit trail struct preserves audit data
        /// </summary>
        [Fact]
        public void RoundTrip_AuditTrailStruct_PreservesAuditData()
        {
            // Arrange
            AuditTrailStruct original = new AuditTrailStruct
            {
                Action = "CREATE",
                User = "admin",
                When = DateTime.Now,
                Success = true
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            AuditTrailStruct restored = JsonNativeAot.Deserialize<AuditTrailStruct>(json);

            // Assert
            Assert.Equal(original.Action, restored.Action);
            Assert.Equal(original.User, restored.User);
            Assert.Equal(original.Success, restored.Success);
        }

        #endregion

        #region Minimal Types Tests

        /// <summary>
        /// Tests that round trip minimal class preserves single property
        /// </summary>
        [Fact]
        public void RoundTrip_MinimalClass_PreservesSingleProperty()
        {
            // Arrange
            MinimalClass original = new MinimalClass { Value = "test" };

            // Act
            string json = JsonNativeAot.Serialize(original);
            MinimalClass restored = JsonNativeAot.Deserialize<MinimalClass>(json);

            // Assert
            Assert.Equal(original.Value, restored.Value);
        }

        /// <summary>
        /// Tests that round trip minimal struct preserves single property
        /// </summary>
        [Fact]
        public void RoundTrip_MinimalStruct_PreservesSingleProperty()
        {
            // Arrange
            MinimalStruct original = new MinimalStruct { Value = 42 };

            // Act
            string json = JsonNativeAot.Serialize(original);
            MinimalStruct restored = JsonNativeAot.Deserialize<MinimalStruct>(json);

            // Assert
            Assert.Equal(original.Value, restored.Value);
        }

        /// <summary>
        /// Tests that round trip minimal class with various strings
        /// </summary>
        /// <param name="value">The value</param>
        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("very long string with many characters")]
        public void RoundTrip_MinimalClass_WithVariousStrings(string value)
        {
            // Arrange
            MinimalClass original = new MinimalClass { Value = value };

            // Act
            string json = JsonNativeAot.Serialize(original);
            MinimalClass restored = JsonNativeAot.Deserialize<MinimalClass>(json);

            // Assert
            Assert.Equal(original.Value, restored.Value);
        }

        /// <summary>
        /// Tests that round trip minimal struct with various integers
        /// </summary>
        /// <param name="value">The value</param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        public void RoundTrip_MinimalStruct_WithVariousIntegers(int value)
        {
            // Arrange
            MinimalStruct original = new MinimalStruct { Value = value };

            // Act
            string json = JsonNativeAot.Serialize(original);
            MinimalStruct restored = JsonNativeAot.Deserialize<MinimalStruct>(json);

            // Assert
            Assert.Equal(original.Value, restored.Value);
        }

        #endregion

        #region Collection Types Tests

        /// <summary>
        /// Tests that round trip tags class preserves list of strings
        /// </summary>
        [Fact]
        public void RoundTrip_TagsClass_PreservesListOfStrings()
        {
            // Arrange
            TagsClass original = new TagsClass
            {
                Name = "Article1",
                Tags = new System.Collections.Generic.List<string> { "tech", "programming", "csharp" }
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            TagsClass restored = JsonNativeAot.Deserialize<TagsClass>(json);

            // Assert
            Assert.Equal(original.Name, restored.Name);
            Assert.Equal(original.Tags.Count, restored.Tags.Count);
            Assert.Contains("tech", restored.Tags);
            Assert.Contains("programming", restored.Tags);
            Assert.Contains("csharp", restored.Tags);
        }

        /// <summary>
        /// Tests that round trip scores class preserves list of integers
        /// </summary>
        [Fact]
        public void RoundTrip_ScoresClass_PreservesListOfIntegers()
        {
            // Arrange
            ScoresClass original = new ScoresClass
            {
                PlayerName = "Player1",
                Scores = new System.Collections.Generic.List<int> { 100, 95, 87, 92 }
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            ScoresClass restored = JsonNativeAot.Deserialize<ScoresClass>(json);

            // Assert
            Assert.Equal(original.PlayerName, restored.PlayerName);
            Assert.Equal(original.Scores.Count, restored.Scores.Count);
            Assert.Contains(100, restored.Scores);
            Assert.Contains(95, restored.Scores);
        }

        #endregion
    }
}

