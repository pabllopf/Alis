// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ConversionsTest.cs
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

using System;
using System.Collections.Generic;
using System.Globalization;
using Alis.Core.Aspect.Data.Json;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    ///     The conversions test class
    /// </summary>
    public class ConversionsTest
    {
        /// <summary>
        ///     Tests that test conversions change type
        /// </summary>
        [Fact]
        public void TestConversions_ChangeType()
        {
            // Arrange
            string input = "123";
            int defaultValue = 0;
            CultureInfo provider = CultureInfo.InvariantCulture;

            // Act
            int result = Conversions.ChangeType(input, defaultValue, provider);

            // Assert
            Assert.Equal(123, result);
        }

        /// <summary>
        ///     Tests that test conversions try change type success
        /// </summary>
        [Fact]
        public void TestConversions_TryChangeType_Success()
        {
            // Arrange
            string input = "123";

            // Act
            bool result = Conversions.TryChangeType(input, out int value);

            // Assert
            Assert.True(result);
            Assert.Equal(123, value);
        }

        /// <summary>
        ///     Tests that test conversions try change type failure
        /// </summary>
        [Fact]
        public void TestConversions_TryChangeType_Failure()
        {
            // Arrange
            string input = "abc";

            // Act
            bool result = Conversions.TryChangeType(input, out int _);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that test conversions is nullable
        /// </summary>
        [Fact]
        public void TestConversions_IsNullable()
        {
            // Arrange
            Type type = typeof(int?);

            // Act
            bool result = Conversions.IsNullable(type);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that test conversions is really value type
        /// </summary>
        [Fact]
        public void TestConversions_IsReallyValueType()
        {
            // Arrange
            Type type = typeof(int);

            // Act
            bool result = Conversions.IsReallyValueType(type);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that test conversions is generic list
        /// </summary>
        [Fact]
        public void TestConversions_IsGenericList()
        {
            // Arrange
            Type type = typeof(List<int>);

            // Act
            bool result = Conversions.IsGenericList(type, out Type elementType);

            // Assert
            Assert.True(result);
            Assert.Equal(typeof(int), elementType);
        }

        /// <summary>
        ///     Tests that test conversions enum to u int 64
        /// </summary>
        [Fact]
        public void TestConversions_EnumToUInt64()
        {
            // Arrange
            DayOfWeek value = DayOfWeek.Monday;

            // Act
            ulong result = Conversions.EnumToUInt64(value);

            // Assert
            Assert.Equal((ulong) DayOfWeek.Monday, result);
        }

        /// <summary>
        ///     Tests that test conversions string to enum
        /// </summary>
        [Fact]
        public void TestConversions_StringToEnum()
        {
            // Arrange
            Type type = typeof(DayOfWeek);
            string[] names = Enum.GetNames(type);
            Array values = Enum.GetValues(type);
            string input = "Monday";

            // Act
            bool result = Conversions.StringToEnum(type, names, values, input, out object value);

            // Assert
            Assert.True(result);
            Assert.Equal(DayOfWeek.Monday, value);
        }

        /// <summary>
        ///     Tests that test conversions enum to object
        /// </summary>
        [Fact]
        public void TestConversions_EnumToObject()
        {
            // Arrange
            Type enumType = typeof(DayOfWeek);
            string value = "Monday";

            // Act
            object result = Conversions.EnumToObject(enumType, value);

            // Assert
            Assert.Equal(DayOfWeek.Sunday, result);
        }

        /// <summary>
        ///     Tests that test conversions to enum
        /// </summary>
        [Fact]
        public void TestConversions_ToEnum()
        {
            // Arrange
            string text = "Monday";
            Type enumType = typeof(DayOfWeek);

            // Act
            object result = Conversions.ToEnum(text, enumType);

            // Assert
            Assert.Equal(DayOfWeek.Monday, result);
        }

        /// <summary>
        ///     Tests that test conversions enum try parse success
        /// </summary>
        [Fact]
        public void TestConversions_EnumTryParse_Success()
        {
            // Arrange
            Type type = typeof(DayOfWeek);
            string input = "Monday";

            // Act
            bool result = Conversions.EnumTryParse(type, input, out object value);

            // Assert
            Assert.True(result);
            Assert.Equal(DayOfWeek.Monday, value);
        }

        /// <summary>
        ///     Tests that test conversions enum try parse failure
        /// </summary>
        [Fact]
        public void TestConversions_EnumTryParse_Failure()
        {
            // Arrange
            Type type = typeof(DayOfWeek);
            string input = "InvalidDay";

            // Act
            bool result = Conversions.EnumTryParse(type, input, out object _);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that test conversions is valid
        /// </summary>
        [Fact]
        public void TestConversions_IsValid()
        {
            // Arrange
            DateTime dt = DateTime.Now;

            // Act
            bool result = Conversions.IsValid(dt);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that test conversions change type int
        /// </summary>
        [Fact]
        public void TestConversions_ChangeType_Int()
        {
            // Arrange
            string input = "123";
            int defaultValue = 0;
            CultureInfo provider = CultureInfo.InvariantCulture;

            // Act
            int result = Conversions.ChangeType(input, defaultValue, provider);

            // Assert
            Assert.Equal(123, result);
        }

        /// <summary>
        ///     Tests that test conversions change type string
        /// </summary>
        [Fact]
        public void TestConversions_ChangeType_String()
        {
            // Arrange
            int input = 123;
            string defaultValue = "default";
            CultureInfo provider = CultureInfo.InvariantCulture;

            // Act
            string result = Conversions.ChangeType(input, defaultValue, provider);

            // Assert
            Assert.Equal("123", result);
        }

        /// <summary>
        ///     Tests that test conversions try change type int success
        /// </summary>
        [Fact]
        public void TestConversions_TryChangeType_Int_Success()
        {
            // Arrange
            object input = "123";
            Type conversionType = typeof(int);

            // Act
            bool result = Conversions.TryChangeType(input, conversionType, out object value);

            // Assert
            Assert.True(result);
            Assert.Equal(123, value);
        }

        /// <summary>
        ///     Tests that test conversions try change type string success
        /// </summary>
        [Fact]
        public void TestConversions_TryChangeType_String_Success()
        {
            // Arrange
            object input = 123;
            Type conversionType = typeof(string);

            // Act
            bool result = Conversions.TryChangeType(input, conversionType, out object value);

            // Assert
            Assert.True(result);
            Assert.Equal("123", value);
        }

        /// <summary>
        ///     Tests that test conversions v 2 try change type failure
        /// </summary>
        [Fact]
        public void TestConversions_v2_TryChangeType_Failure()
        {
            // Arrange
            object input = "abc";
            Type conversionType = typeof(int);

            // Act
            bool result = Conversions.TryChangeType(input, conversionType, out object value);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that test conversions enum try parse success
        /// </summary>
        [Fact]
        public void TestConversions_v2_EnumTryParse_Success()
        {
            // Arrange
            Type type = typeof(DayOfWeek);
            object input = "Monday";

            // Act
            bool result = Conversions.EnumTryParse(type, input, out object value);

            // Assert
            Assert.True(result);
            Assert.Equal(DayOfWeek.Monday, value);
        }

        /// <summary>
        ///     Tests that test conversions v 2 enum try parse failure
        /// </summary>
        [Fact]
        public void TestConversions_v2_EnumTryParse_Failure()
        {
            // Arrange
            Type type = typeof(DayOfWeek);
            object input = "InvalidDay";

            // Act
            bool result = Conversions.EnumTryParse(type, input, out object value);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that test conversions is generic list true
        /// </summary>
        [Fact]
        public void TestConversions_IsGenericList_True()
        {
            // Arrange
            Type type = typeof(List<int>);

            // Act
            bool result = Conversions.IsGenericList(type, out Type elementType);

            // Assert
            Assert.True(result);
            Assert.Equal(typeof(int), elementType);
        }

        /// <summary>
        ///     Tests that test conversions is generic list false
        /// </summary>
        [Fact]
        public void TestConversions_IsGenericList_False()
        {
            // Arrange
            Type type = typeof(int);

            // Act
            bool result = Conversions.IsGenericList(type, out Type elementType);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that test conversions is really value type true
        /// </summary>
        [Fact]
        public void TestConversions_IsReallyValueType_True()
        {
            // Arrange
            Type type = typeof(int);

            // Act
            bool result = Conversions.IsReallyValueType(type);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that test conversions is really value type false
        /// </summary>
        [Fact]
        public void TestConversions_IsReallyValueType_False()
        {
            // Arrange
            Type type = typeof(int?);

            // Act
            bool result = Conversions.IsReallyValueType(type);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that test conversions v 2 is generic list true
        /// </summary>
        [Fact]
        public void TestConversions_v2_IsGenericList_True()
        {
            // Arrange
            Type type = typeof(List<int>);

            // Act
            bool result = Conversions.IsGenericList(type, out Type elementType);

            // Assert
            Assert.True(result);
            Assert.Equal(typeof(int), elementType);
        }

        /// <summary>
        ///     Tests that test conversions v 2 is generic list false
        /// </summary>
        [Fact]
        public void TestConversions_v2_IsGenericList_False()
        {
            // Arrange
            Type type = typeof(int);

            // Act
            bool result = Conversions.IsGenericList(type, out Type elementType);

            // Assert
            Assert.False(result);
            Assert.Null(elementType);
        }

        /// <summary>
        ///     Tests that test conversions is generic list null type
        /// </summary>
        [Fact]
        public void TestConversions_IsGenericList_NullType()
        {
            // Arrange
            Type type = null;

            // Act
            void Action() => Conversions.IsGenericList(type, out Type elementType);

            // Assert
            Assert.Throws<ArgumentNullException>(Action);
        }

        /// <summary>
        ///     Tests that test conversions to enum success
        /// </summary>
        [Fact]
        public void TestConversions_ToEnum_Success()
        {
            // Arrange
            string input = "Monday";
            Type enumType = typeof(DayOfWeek);

            // Act
            object result = Conversions.ToEnum(input, enumType);

            // Assert
            Assert.Equal(DayOfWeek.Monday, result);
        }

        /// <summary>
        ///     Tests that test conversions to enum failure
        /// </summary>
        [Fact]
        public void TestConversions_ToEnum_Failure()
        {
            // Arrange
            string input = "InvalidDay";
            Type enumType = typeof(DayOfWeek);

            // Act
            object result = Conversions.ToEnum(input, enumType);

            // Assert
            Assert.NotEqual(DayOfWeek.Monday, result);
        }

        /// <summary>
        ///     Tests that test conversions to enum null type
        /// </summary>
        [Fact]
        public void TestConversions_ToEnum_NullType()
        {
            // Arrange
            string input = "Monday";
            Type enumType = null;

            // Act
            void Action() => Conversions.ToEnum(input, enumType);

            // Assert
            Assert.Throws<ArgumentNullException>(Action);
        }

        /// <summary>
        ///     Tests that test conversions v 2 is really value type true
        /// </summary>
        [Fact]
        public void TestConversions_v2_IsReallyValueType_True()
        {
            // Arrange
            Type type = typeof(int);

            // Act
            bool result = Conversions.IsReallyValueType(type);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that test conversions v 2 is really value type false
        /// </summary>
        [Fact]
        public void TestConversions_v2_IsReallyValueType_False()
        {
            // Arrange
            Type type = typeof(int?);

            // Act
            bool result = Conversions.IsReallyValueType(type);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that test conversions is really value type null type
        /// </summary>
        [Fact]
        public void TestConversions_IsReallyValueType_NullType()
        {
            // Arrange
            Type type = null;

            // Act
            void Action() => Conversions.IsReallyValueType(type);

            // Assert
            Assert.Throws<ArgumentNullException>(Action);
        }

        /// <summary>
        ///     Tests that test conversions is nullable true
        /// </summary>
        [Fact]
        public void TestConversions_IsNullable_True()
        {
            // Arrange
            Type type = typeof(int?);

            // Act
            bool result = Conversions.IsNullable(type);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that test conversions is nullable false
        /// </summary>
        [Fact]
        public void TestConversions_IsNullable_False()
        {
            // Arrange
            Type type = typeof(int);

            // Act
            bool result = Conversions.IsNullable(type);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that test conversions is nullable null type
        /// </summary>
        [Fact]
        public void TestConversions_IsNullable_NullType()
        {
            // Arrange
            Type type = null;

            // Act
            void Action() => Conversions.IsNullable(type);

            // Assert
            Assert.Throws<ArgumentNullException>(Action);
        }

        /// <summary>
        ///     Tests that test conversions enum to u int 64 null value
        /// </summary>
        [Fact]
        public void TestConversions_EnumToUInt64_NullValue()
        {
            // Arrange
            object value = null;

            // Act
            void Action() => Conversions.EnumToUInt64(value);

            // Assert
            Assert.Throws<ArgumentNullException>(Action);
        }

        /// <summary>
        ///     Tests that test conversions enum to u int 64 s byte
        /// </summary>
        [Fact]
        public void TestConversions_EnumToUInt64_SByte()
        {
            // Arrange
            object value = (sbyte) 1;

            // Act
            ulong result = Conversions.EnumToUInt64(value);

            // Assert
            Assert.Equal(1UL, result);
        }

        /// <summary>
        ///     Tests that test conversions enum to u int 64 int 16
        /// </summary>
        [Fact]
        public void TestConversions_EnumToUInt64_Int16()
        {
            // Arrange
            object value = (short) 1;

            // Act
            ulong result = Conversions.EnumToUInt64(value);

            // Assert
            Assert.Equal(1UL, result);
        }

        /// <summary>
        ///     Tests that test conversions enum to u int 64 int 32
        /// </summary>
        [Fact]
        public void TestConversions_EnumToUInt64_Int32()
        {
            // Arrange
            object value = 1;

            // Act
            ulong result = Conversions.EnumToUInt64(value);

            // Assert
            Assert.Equal(1UL, result);
        }

        /// <summary>
        ///     Tests that test conversions enum to u int 64 int 64
        /// </summary>
        [Fact]
        public void TestConversions_EnumToUInt64_Int64()
        {
            // Arrange
            object value = 1L;

            // Act
            ulong result = Conversions.EnumToUInt64(value);

            // Assert
            Assert.Equal(1UL, result);
        }

        /// <summary>
        ///     Tests that test conversions enum to u int 64 byte
        /// </summary>
        [Fact]
        public void TestConversions_EnumToUInt64_Byte()
        {
            // Arrange
            object value = (byte) 1;

            // Act
            ulong result = Conversions.EnumToUInt64(value);

            // Assert
            Assert.Equal(1UL, result);
        }

        /// <summary>
        ///     Tests that test conversions enum to u int 64 u int 16
        /// </summary>
        [Fact]
        public void TestConversions_EnumToUInt64_UInt16()
        {
            // Arrange
            object value = (ushort) 1;

            // Act
            ulong result = Conversions.EnumToUInt64(value);

            // Assert
            Assert.Equal(1UL, result);
        }

        /// <summary>
        ///     Tests that test conversions enum to u int 64 u int 32
        /// </summary>
        [Fact]
        public void TestConversions_EnumToUInt64_UInt32()
        {
            // Arrange
            object value = (uint) 1;

            // Act
            ulong result = Conversions.EnumToUInt64(value);

            // Assert
            Assert.Equal(1UL, result);
        }

        /// <summary>
        ///     Tests that test conversions enum to u int 64 u int 64
        /// </summary>
        [Fact]
        public void TestConversions_EnumToUInt64_UInt64()
        {
            // Arrange
            object value = 1UL;

            // Act
            ulong result = Conversions.EnumToUInt64(value);

            // Assert
            Assert.Equal(1UL, result);
        }

        /// <summary>
        ///     Tests that test conversions enum to u int 64 string
        /// </summary>
        [Fact]
        public void TestConversions_EnumToUInt64_String()
        {
            // Arrange
            object value = "1";

            // Act
            ulong result = Conversions.EnumToUInt64(value);

            // Assert
            Assert.Equal(1UL, result);
        }

        /// <summary>
        ///     Tests that test conversions change type int to double success
        /// </summary>
        [Fact]
        public void TestConversions_ChangeType_IntToDouble_Success()
        {
            // Arrange
            object input = 10;
            Type conversionType = typeof(double);

            // Act
            object result = Conversions.ChangeType(input, conversionType: conversionType);

            // Assert
            Assert.IsType<double>(result);
            Assert.Equal(10.0, result);
        }

        /// <summary>
        ///     Tests that test conversions change type string to int success
        /// </summary>
        [Fact]
        public void TestConversions_ChangeType_StringToInt_Success()
        {
            // Arrange
            object input = "10";
            Type conversionType = typeof(int);

            // Act
            object result = Conversions.ChangeType(input, conversionType: conversionType);

            // Assert
            Assert.IsType<int>(result);
            Assert.Equal(10, result);
        }

        /// <summary>
        ///     Tests that test conversions change type string to int failure
        /// </summary>
        [Fact]
        public void TestConversions_ChangeType_StringToInt_Failure()
        {
            // Arrange
            object input = "invalid";
            Type conversionType = typeof(int);

            // Act
            object result = Conversions.ChangeType(input, conversionType, -1);

            // Assert
            Assert.IsType<int>(result);
            Assert.Equal(-1, result);
        }

        /// <summary>
        ///     Tests that test conversions change type null to nullable int success
        /// </summary>
        [Fact]
        public void TestConversions_ChangeType_NullToNullableInt_Success()
        {
            // Arrange
            object input = null;
            Type conversionType = typeof(int?);

            // Act
            object result = Conversions.ChangeType(input, conversionType: conversionType);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that test conversions change type null to non nullable int failure
        /// </summary>
        [Fact]
        public void TestConversions_ChangeType_NullToNonNullableInt_Failure()
        {
            // Arrange
            object input = null;
            Type conversionType = typeof(int);

            // Act
            object result = Conversions.ChangeType(input, conversionType, -1);

            // Assert
            Assert.IsType<int>(result);
            Assert.Equal(-1, result);
        }

        /// <summary>
        ///     Tests that test conversions change type v 2 int to double success
        /// </summary>
        [Fact]
        public void TestConversions_ChangeType_v2_IntToDouble_Success()
        {
            // Arrange
            object input = 10;
            Type conversionType = typeof(double);
            object defaultValue = null;
            IFormatProvider provider = null;

            // Act
            object result = Conversions.ChangeType(input, conversionType, defaultValue, provider);

            // Assert
            Assert.IsType<double>(result);
            Assert.Equal(10.0, (double) result);
        }

        /// <summary>
        ///     Tests that test conversions change type v 2 string to int success
        /// </summary>
        [Fact]
        public void TestConversions_ChangeType_v2_StringToInt_Success()
        {
            // Arrange
            object input = "10";
            Type conversionType = typeof(int);
            object defaultValue = null;
            IFormatProvider provider = null;

            // Act
            object result = Conversions.ChangeType(input, conversionType, defaultValue, provider);

            // Assert
            Assert.IsType<int>(result);
            Assert.Equal(10, (int) result);
        }

        /// <summary>
        ///     Tests that test conversions change type v 2 string to int failure
        /// </summary>
        [Fact]
        public void TestConversions_ChangeType_v2_StringToInt_Failure()
        {
            // Arrange
            object input = "invalid";
            Type conversionType = typeof(int);
            object defaultValue = -1;
            IFormatProvider provider = null;

            // Act
            object result = Conversions.ChangeType(input, conversionType, defaultValue, provider);

            // Assert
            Assert.IsType<int>(result);
            Assert.Equal(-1, (int) result);
        }

        /// <summary>
        ///     Tests that test conversions change type v 2 null to nullable int success
        /// </summary>
        [Fact]
        public void TestConversions_ChangeType_v2_NullToNullableInt_Success()
        {
            // Arrange
            object input = null;
            Type conversionType = typeof(int?);
            object defaultValue = null;
            IFormatProvider provider = null;

            // Act
            object result = Conversions.ChangeType(input, conversionType, defaultValue, provider);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that test conversions change type v 2 null to non nullable int failure
        /// </summary>
        [Fact]
        public void TestConversions_ChangeType_v2_NullToNonNullableInt_Failure()
        {
            // Arrange
            object input = null;
            Type conversionType = typeof(int);
            object defaultValue = -1;
            IFormatProvider provider = null;

            // Act
            object result = Conversions.ChangeType(input, conversionType, defaultValue, provider);

            // Assert
            Assert.IsType<int>(result);
            Assert.Equal(-1, (int) result);
        }
    }
}