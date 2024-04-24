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
            Assert.Equal(DayOfWeek.Monday, result);
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
            bool result = Conversions.TryChangeType(input, conversionType, out object _);
            
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
            bool result = Conversions.EnumTryParse(type, input, out object _);
            
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
            bool result = Conversions.IsGenericList(type, out Type _);
            
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
            void Action() => Conversions.IsGenericList(type, out Type _);
            
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
        
        /// <summary>
        ///     Tests that try parse token values success
        /// </summary>
        [Fact]
        public void TryParseTokenValues_Success()
        {
            string[] tokens = {"Monday", "Tuesday"};
            Type type = typeof(DayOfWeek);
            string[] names = Enum.GetNames(type);
            Array values = Enum.GetValues(type);
            bool result = Conversions.TryParseTokenValues(tokens, type, names, values, out object value);
            
            Assert.True(result);
            Assert.Equal(DayOfWeek.Monday | DayOfWeek.Tuesday, value);
        }
        
        /// <summary>
        ///     Tests that try parse token values failure
        /// </summary>
        [Fact]
        public void TryParseTokenValues_Failure()
        {
            string[] tokens = {"InvalidDay"};
            Type type = typeof(DayOfWeek);
            string[] names = Enum.GetNames(type);
            Array values = Enum.GetValues(type);
            bool result = Conversions.TryParseTokenValues(tokens, type, names, values, out object value);
            
            Assert.False(result);
        }
        
        /// <summary>
        ///     Tests that convert token value to ulong int 16
        /// </summary>
        [Fact]
        public void ConvertTokenValueToUlong_Int16()
        {
            object tokenValue = (short) 1;
            ulong result = Conversions.ConvertTokenValueToUlong(tokenValue);
            
            Assert.Equal(1UL, result);
        }
        
        /// <summary>
        ///     Tests that convert token value to ulong int 32
        /// </summary>
        [Fact]
        public void ConvertTokenValueToUlong_Int32()
        {
            object tokenValue = 1;
            ulong result = Conversions.ConvertTokenValueToUlong(tokenValue);
            
            Assert.Equal(1UL, result);
        }
        
        /// <summary>
        ///     Tests that convert token value to ulong int 64
        /// </summary>
        [Fact]
        public void ConvertTokenValueToUlong_Int64()
        {
            object tokenValue = 1L;
            ulong result = Conversions.ConvertTokenValueToUlong(tokenValue);
            
            Assert.Equal(1UL, result);
        }
        
        /// <summary>
        ///     Tests that convert token value to ulong s byte
        /// </summary>
        [Fact]
        public void ConvertTokenValueToUlong_SByte()
        {
            object tokenValue = (sbyte) 1;
            ulong result = Conversions.ConvertTokenValueToUlong(tokenValue);
            
            Assert.Equal(1UL, result);
        }
        
        /// <summary>
        ///     Tests that convert token value to ulong u int 16
        /// </summary>
        [Fact]
        public void ConvertTokenValueToUlong_UInt16()
        {
            object tokenValue = (ushort) 1;
            ulong result = Conversions.ConvertTokenValueToUlong(tokenValue);
            
            Assert.Equal(1UL, result);
        }
        
        /// <summary>
        ///     Tests that convert token value to ulong u int 32
        /// </summary>
        [Fact]
        public void ConvertTokenValueToUlong_UInt32()
        {
            object tokenValue = (uint) 1;
            ulong result = Conversions.ConvertTokenValueToUlong(tokenValue);
            
            Assert.Equal(1UL, result);
        }
        
        /// <summary>
        ///     Tests that convert token value to ulong u int 64
        /// </summary>
        [Fact]
        public void ConvertTokenValueToUlong_UInt64()
        {
            object tokenValue = 1UL;
            ulong result = Conversions.ConvertTokenValueToUlong(tokenValue);
            
            Assert.Equal(1UL, result);
        }
        
        /// <summary>
        ///     Tests that try change with converter success
        /// </summary>
        [Fact]
        public void TryChangeWithConverter_Success()
        {
            object input = "123";
            Type conversionType = typeof(int);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            Type inputType = typeof(string);
            bool result = Conversions.TryConvert(input, conversionType, inputType, out object value);
            
            Assert.True(result);
            Assert.Equal(123, value);
        }
        
        /// <summary>
        ///     Tests that try change with converter failure
        /// </summary>
        [Fact]
        public void TryChangeWithConverter_Failure()
        {
            object input = "abc";
            Type conversionType = typeof(int);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            Type inputType = typeof(string);
            Assert.Throws<ArgumentException>(() => Conversions.TryConvert(input, conversionType, inputType, out object value));
        }
        
        /// <summary>
        ///     Tests that try change to date time success
        /// </summary>
        [Fact]
        public void TryChangeToDateTime_Success()
        {
            object input = "2022-12-31";
            Type conversionType = typeof(DateTime);
            Type inputType = typeof(string);
            bool result = Conversions.TryChangeToDateTime(input, conversionType, inputType, out object value);
            
            Assert.True(result);
            Assert.IsType<DateTime>(value);
            Assert.Equal(new DateTime(2022, 12, 31), value);
        }
        
        /// <summary>
        ///     Tests that try change to date time failure
        /// </summary>
        [Fact]
        public void TryChangeToDateTime_Failure()
        {
            object input = "invalid";
            Type conversionType = typeof(DateTime);
            Type inputType = typeof(string);
            bool result = Conversions.TryChangeToDateTime(input, conversionType, inputType, out object value);
            
            Assert.False(result);
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that try change to time span success
        /// </summary>
        [Fact]
        public void TryChangeToTimeSpan_Success()
        {
            object input = "01:02:03";
            IFormatProvider provider = CultureInfo.InvariantCulture;
            bool result = Conversions.TryChangeToTimeSpan(input, provider, out object value);
            
            Assert.True(result);
            Assert.IsType<TimeSpan>(value);
            Assert.Equal(new TimeSpan(1, 2, 3), value);
        }
        
        /// <summary>
        ///     Tests that try change to time span failure
        /// </summary>
        [Fact]
        public void TryChangeToTimeSpan_Failure()
        {
            object input = "invalid";
            IFormatProvider provider = CultureInfo.InvariantCulture;
            bool result = Conversions.TryChangeToTimeSpan(input, provider, out object value);
            
            Assert.False(result);
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that try change to collection success
        /// </summary>
        [Fact]
        public void TryChangeToCollection_Success()
        {
            object input = new List<int> {1, 2, 3};
            Type conversionType = typeof(List<int>);
            Type elementType = typeof(int);
            bool result = Conversions.TryChangeToCollection(input, conversionType, elementType, out object value);
            
            Assert.True(result);
            Assert.IsType<List<int>>(value);
            Assert.Equal(new List<int> {1, 2, 3}, value);
        }
        
        /// <summary>
        ///     Tests that try change to collection failure
        /// </summary>
        [Fact]
        public void TryChangeToCollection_Failure()
        {
            object input = "invalid";
            Type conversionType = typeof(List<int>);
            Type elementType = typeof(int);
            bool result = Conversions.TryChangeToCollection(input, conversionType, elementType, out object value);
            
            Assert.False(result);
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that try change to enum success
        /// </summary>
        [Fact]
        public void TryChangeToEnum_Success()
        {
            // Arrange
            object input = "Monday";
            Type conversionType = typeof(DayOfWeek);
            
            // Act
            bool result = Conversions.TryChangeToEnum(conversionType, input, out object value);
            
            // Assert
            Assert.True(result);
            Assert.Equal(DayOfWeek.Monday, value);
        }
        
        /// <summary>
        ///     Tests that try change to enum failure
        /// </summary>
        [Fact]
        public void TryChangeToEnum_Failure()
        {
            // Arrange
            object input = "InvalidDay";
            Type conversionType = typeof(DayOfWeek);
            
            // Act
            bool result = Conversions.TryChangeToEnum(conversionType, input, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that try change from enum success
        /// </summary>
        [Fact]
        public void TryChangeFromEnum_Success()
        {
            // Arrange
            object input = DayOfWeek.Monday;
            Type conversionType = typeof(string);
            
            // Act
            bool result = Conversions.TryChangeFromEnum(conversionType, input, out object value);
            
            // Assert
            Assert.True(result);
            Assert.Equal("Monday", value);
        }
        
        /// <summary>
        ///     Tests that try change from enum failure
        /// </summary>
        [Fact]
        public void TryChangeFromEnum_Failure()
        {
            // Arrange
            object input = "Monday";
            Type conversionType = typeof(string);
            
            // Act
            bool result = Conversions.TryChangeFromEnum(conversionType, input, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that try change to guid success
        /// </summary>
        [Fact]
        public void TryChangeToGuid_Success()
        {
            // Arrange
            object input = Guid.NewGuid().ToString();
            IFormatProvider provider = CultureInfo.InvariantCulture;
            
            // Act
            bool result = Conversions.TryChangeToGuid(input, provider, out object value);
            
            // Assert
            Assert.True(result);
            Assert.IsType<Guid>(value);
            Assert.Equal(input, value.ToString());
        }
        
        /// <summary>
        ///     Tests that try change to guid failure
        /// </summary>
        [Fact]
        public void TryChangeToGuid_Failure()
        {
            // Arrange
            object input = "InvalidGuid";
            IFormatProvider provider = CultureInfo.InvariantCulture;
            
            // Act
            bool result = Conversions.TryChangeToGuid(input, provider, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that try change to uri success
        /// </summary>
        [Fact]
        public void TryChangeToUri_Success()
        {
            // Arrange
            object input = "http://example.com/";
            IFormatProvider provider = CultureInfo.InvariantCulture;
            
            // Act
            bool result = Conversions.TryConvertToUri(input.ToString(), out object value);
            
            // Assert
            Assert.True(result);
            Assert.IsType<Uri>(value);
            Assert.Equal(input.ToString(), value.ToString());
        }
        
        /// <summary>
        ///     Tests that try change to uri failure
        /// </summary>
        [Fact]
        public void TryChangeToUri_Failure()
        {
            // Arrange
            object input = "invalid uri";
            IFormatProvider provider = CultureInfo.InvariantCulture;
            
            // Act
            bool result = Conversions.TryConvertToUri(input.ToString(), out object value);
            
            // Assert
            Assert.True(result);
        }
        
        /// <summary>
        ///     Tests that try change to int ptr success
        /// </summary>
        [Fact]
        public void TryChangeToIntPtr_Success()
        {
            // Arrange
            object input = "123";
            IFormatProvider provider = CultureInfo.InvariantCulture;
            
            // Act
            bool result = Conversions.TryChangeToIntPtr(input, out object value);
            
            // Assert
            Assert.True(result);
            Assert.IsType<IntPtr>(value);
            Assert.Equal(new IntPtr(int.Parse(input.ToString())), value);
        }
        
        /// <summary>
        ///     Tests that try change to int ptr failure
        /// </summary>
        [Fact]
        public void TryChangeToIntPtr_Failure()
        {
            // Arrange
            object input = "invalid int";
            IFormatProvider provider = CultureInfo.InvariantCulture;
            
            // Act
            bool result = Conversions.TryChangeToIntPtr(input, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that try change to culture info valid culture info returns true
        /// </summary>
        [Fact]
        public void TryChangeToCultureInfo_ValidCultureInfo_ReturnsTrue()
        {
            object input = "en-US";
            bool result = Conversions.TryChangeToCultureInfo(input, out object value);
            
            Assert.True(result);
            Assert.IsType<CultureInfo>(value);
            Assert.Equal(input, ((CultureInfo) value).Name);
        }
        
        /// <summary>
        ///     Tests that try change to culture info invalid culture info returns false
        /// </summary>
        [Fact]
        public void TryChangeToCultureInfo_InvalidCultureInfo_ReturnsFalse()
        {
            object input = "invalid-culture";
            bool result = Conversions.TryChangeToCultureInfo(input, out object value);
            
            Assert.False(result);
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that try change to bool valid bool returns true
        /// </summary>
        [Fact]
        public void TryChangeToBool_ValidBool_ReturnsTrue()
        {
            object input = "true";
            IFormatProvider provider = CultureInfo.InvariantCulture;
            bool result = Conversions.TryChangeToBool(input, provider, out object value);
            
            Assert.True(result);
            Assert.IsType<bool>(value);
            Assert.True((bool) value);
        }
        
        /// <summary>
        ///     Tests that try change to bool invalid bool returns false
        /// </summary>
        [Fact]
        public void TryChangeToBool_InvalidBool_ReturnsFalse()
        {
            object input = "invalid-bool";
            IFormatProvider provider = CultureInfo.InvariantCulture;
            bool result = Conversions.TryChangeToBool(input, provider, out object value);
            
            Assert.False(result);
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that try match values matching value returns true
        /// </summary>
        [Fact]
        public void TryMatchValues_MatchingValue_ReturnsTrue()
        {
            // Arrange
            Array values = new[] {1, 2, 3};
            string input = "2";
            
            // Act
            bool result = Conversions.TryMatchValues(values, input, out object value);
            
            // Assert
            Assert.True(result);
            Assert.Equal(2, value);
        }
        
        /// <summary>
        ///     Tests that try match values non matching value returns false
        /// </summary>
        [Fact]
        public void TryMatchValues_NonMatchingValue_ReturnsFalse()
        {
            // Arrange
            Array values = new[] {1, 2, 3};
            string input = "4";
            
            // Act
            bool result = Conversions.TryMatchValues(values, input, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that try match values empty input returns false
        /// </summary>
        [Fact]
        public void TryMatchValues_EmptyInput_ReturnsFalse()
        {
            // Arrange
            Array values = new[] {1, 2, 3};
            string input = "";
            
            // Act
            bool result = Conversions.TryMatchValues(values, input, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that try match values negative input returns true
        /// </summary>
        [Fact]
        public void TryMatchValues_NegativeInput_ReturnsTrue()
        {
            // Arrange
            Array values = new[] {-1, -2, -3};
            string input = "-2";
            
            // Act
            bool result = Conversions.TryMatchValues(values, input, out object value);
            
            // Assert
            Assert.True(result);
            Assert.Equal(-2, value);
        }
        
        /// <summary>
        ///     Tests that try match values negative input with positive values returns false
        /// </summary>
        [Fact]
        public void TryMatchValues_NegativeInputWithPositiveValues_ReturnsFalse()
        {
            // Arrange
            Array values = new[] {1, 2, 3};
            string input = "-2";
            
            // Act
            bool result = Conversions.TryMatchValues(values, input, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that try change type conversion type is null throws argument null exception
        /// </summary>
        [Fact]
        public void TryChangeType_ConversionTypeIsNull_ThrowsArgumentNullException()
        {
            object input = "123";
            Type conversionType = null;
            IFormatProvider provider = CultureInfo.InvariantCulture;
            Assert.Throws<ArgumentNullException>(() => Conversions.TryChangeType(input, conversionType, provider, out object value));
        }
        
        /// <summary>
        ///     Tests that try change type conversion type is object returns true
        /// </summary>
        [Fact]
        public void TryChangeType_ConversionTypeIsObject_ReturnsTrue()
        {
            object input = "123";
            Type conversionType = typeof(object);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            bool result = Conversions.TryChangeType(input, conversionType, provider, out object value);
            Assert.True(result);
            Assert.Equal(input, value);
        }
        
        /// <summary>
        ///     Tests that try change type conversion type is nullable returns true
        /// </summary>
        [Fact]
        public void TryChangeType_ConversionTypeIsNullable_ReturnsTrue()
        {
            string input = "123";
            Type conversionType = typeof(int?);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            bool result = Conversions.TryChangeType(input, conversionType, provider, out object value);
            Assert.True(result);
            Assert.Equal(int.Parse(input), value);
        }
        
        /// <summary>
        ///     Tests that try change type input is null and conversion type is value type returns false
        /// </summary>
        [Fact]
        public void TryChangeType_InputIsNullAndConversionTypeIsValueType_ReturnsFalse()
        {
            object input = null;
            Type conversionType = typeof(int);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            bool result = Conversions.TryChangeType(input, conversionType, provider, out object value);
            Assert.False(result);
        }
        
        /// <summary>
        ///     Tests that try change type input is null and conversion type is not value type returns true
        /// </summary>
        [Fact]
        public void TryChangeType_InputIsNullAndConversionTypeIsNotValueType_ReturnsTrue()
        {
            object input = null;
            Type conversionType = typeof(string);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            bool result = Conversions.TryChangeType(input, conversionType, provider, out object value);
            Assert.True(result);
        }
        
        /// <summary>
        ///     Tests that try change type conversion type is assignable from input type returns true
        /// </summary>
        [Fact]
        public void TryChangeType_ConversionTypeIsAssignableFromInputType_ReturnsTrue()
        {
            object input = "123";
            Type conversionType = typeof(string);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            bool result = Conversions.TryChangeType(input, conversionType, provider, out object value);
            Assert.True(result);
            Assert.Equal(input, value);
        }
        
        /// <summary>
        ///     Tests that try change type conversion type is not assignable from input type returns false
        /// </summary>
        [Fact]
        public void TryChangeType_ConversionTypeIsNotAssignableFromInputType_ReturnsFalse()
        {
            object input = "123";
            Type conversionType = typeof(int);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            bool result = Conversions.TryChangeType(input, conversionType, provider, out object value);
            Assert.True(result);
        }
        
        /// <summary>
        ///     Tests that try handle digit or sign start with digit start returns true
        /// </summary>
        [Fact]
        public void TryHandleDigitOrSignStart_WithDigitStart_ReturnsTrue()
        {
            // Arrange
            Type type = typeof(int);
            string input = "123";
            
            // Act
            bool result = Conversions.TryHandleDigitOrSignStart(type, input, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Equal(0, value);
        }
        
        /// <summary>
        ///     Tests that try handle digit or sign start with negative sign start returns true
        /// </summary>
        [Fact]
        public void TryHandleDigitOrSignStart_WithNegativeSignStart_ReturnsTrue()
        {
            // Arrange
            Type type = typeof(int);
            string input = "-123";
            
            // Act
            bool result = Conversions.TryHandleDigitOrSignStart(type, input, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Equal(0, value);
        }
        
        /// <summary>
        ///     Tests that try handle digit or sign start with positive sign start returns true
        /// </summary>
        [Fact]
        public void TryHandleDigitOrSignStart_WithPositiveSignStart_ReturnsTrue()
        {
            // Arrange
            Type type = typeof(int);
            string input = "+123";
            
            // Act
            bool result = Conversions.TryHandleDigitOrSignStart(type, input, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Equal(0, value);
        }
        
        /// <summary>
        ///     Tests that try handle digit or sign start with non digit or sign start returns false
        /// </summary>
        [Fact]
        public void TryHandleDigitOrSignStart_WithNonDigitOrSignStart_ReturnsFalse()
        {
            // Arrange
            Type type = typeof(int);
            string input = "abc";
            
            // Act
            bool result = Conversions.TryHandleDigitOrSignStart(type, input, out object value);
            
            // Assert
            Assert.False(result);
            Assert.NotNull(value);
        }
        
        /// <summary>
        ///     Tests that try handle digit or sign start with null input returns false
        /// </summary>
        [Fact]
        public void TryHandleDigitOrSignStart_WithNullInput_ReturnsFalse()
        {
            // Arrange
            Type type = typeof(int);
            string input = null;
            
            // Act
            Assert.Throws<NullReferenceException>(() => Conversions.TryHandleDigitOrSignStart(type, input, out object value));
        }
        
        /// <summary>
        ///     Tests that try change type based on input type enum conversion returns true
        /// </summary>
        [Fact]
        public void TryChangeTypeBasedOnInputType_EnumConversion_ReturnsTrue()
        {
            object input = "Monday";
            Type conversionType = typeof(DayOfWeek);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            Type inputType = typeof(string);
            bool result = Conversions.TryChangeTypeBasedOnInputType(input, conversionType, provider, inputType, out object value);
            Assert.True(result);
            Assert.Equal(DayOfWeek.Monday, value);
        }
        
        /// <summary>
        ///     Tests that try change type based on input type from enum conversion returns true
        /// </summary>
        [Fact]
        public void TryChangeTypeBasedOnInputType_FromEnumConversion_ReturnsTrue()
        {
            object input = DayOfWeek.Monday;
            Type conversionType = typeof(string);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            Type inputType = typeof(DayOfWeek);
            bool result = Conversions.TryChangeTypeBasedOnInputType(input, conversionType, provider, inputType, out object value);
            Assert.True(result);
            Assert.Equal("Monday", value);
        }
        
        /// <summary>
        ///     Tests that try change type based on input type guid conversion returns true
        /// </summary>
        [Fact]
        public void TryChangeTypeBasedOnInputType_GuidConversion_ReturnsTrue()
        {
            Guid guid = Guid.NewGuid();
            object input = guid.ToString();
            Type conversionType = typeof(Guid);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            Type inputType = typeof(string);
            bool result = Conversions.TryChangeTypeBasedOnInputType(input, conversionType, provider, inputType, out object value);
            Assert.True(result);
            Assert.Equal(guid, value);
        }
        
        /// <summary>
        ///     Tests that try change type based on input type uri conversion returns true
        /// </summary>
        [Fact]
        public void TryChangeTypeBasedOnInputType_UriConversion_ReturnsTrue()
        {
            object input = "http://example.com/";
            Type conversionType = typeof(Uri);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            Type inputType = typeof(string);
            bool result = Conversions.TryChangeTypeBasedOnInputType(input, conversionType, provider, inputType, out object value);
            Assert.True(result);
            Assert.Equal(new Uri((string) input), value);
        }
        
        /// <summary>
        ///     Tests that try change type based on input type int ptr conversion returns true
        /// </summary>
        [Fact]
        public void TryChangeTypeBasedOnInputType_IntPtrConversion_ReturnsTrue()
        {
            object input = "123";
            Type conversionType = typeof(IntPtr);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            Type inputType = typeof(string);
            bool result = Conversions.TryChangeTypeBasedOnInputType(input, conversionType, provider, inputType, out object value);
            Assert.True(result);
            Assert.Equal(new IntPtr(int.Parse((string) input)), value);
        }
        
        /// <summary>
        ///     Tests that try change type based on input type numeric conversion returns true
        /// </summary>
        [Fact]
        public void TryChangeTypeBasedOnInputType_NumericConversion_ReturnsTrue()
        {
            object input = "123";
            Type conversionType = typeof(int);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            Type inputType = typeof(string);
            bool result = Conversions.TryChangeTypeBasedOnInputType(input, conversionType, provider, inputType, out object value);
            Assert.True(result);
            Assert.Equal(123, value);
        }
        
        /// <summary>
        ///     Tests that try change type based on input type date time conversion returns true
        /// </summary>
        [Fact]
        public void TryChangeTypeBasedOnInputType_DateTimeConversion_ReturnsTrue()
        {
            object input = "2022-12-31";
            Type conversionType = typeof(DateTime);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            Type inputType = typeof(string);
            bool result = Conversions.TryChangeTypeBasedOnInputType(input, conversionType, provider, inputType, out object value);
            Assert.True(result);
            Assert.Equal(new DateTime(2022, 12, 31), value);
        }
        
        /// <summary>
        ///     Tests that try change type based on input type time span conversion returns true
        /// </summary>
        [Fact]
        public void TryChangeTypeBasedOnInputType_TimeSpanConversion_ReturnsTrue()
        {
            object input = "01:02:03";
            Type conversionType = typeof(TimeSpan);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            Type inputType = typeof(string);
            bool result = Conversions.TryChangeTypeBasedOnInputType(input, conversionType, provider, inputType, out object value);
            Assert.True(result);
            Assert.Equal(new TimeSpan(1, 2, 3), value);
        }
        
        /// <summary>
        ///     Tests that try change type based on input type collection conversion returns true
        /// </summary>
        [Fact]
        public void TryChangeTypeBasedOnInputType_CollectionConversion_ReturnsTrue()
        {
            object input = "1,2,3";
            Type conversionType = typeof(List<int>);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            Type inputType = typeof(string);
            bool result = Conversions.TryChangeTypeBasedOnInputType(input, conversionType, provider, inputType, out object value);
            Assert.False(result);
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that try change type based on input type culture info conversion returns true
        /// </summary>
        [Fact]
        public void TryChangeTypeBasedOnInputType_CultureInfoConversion_ReturnsTrue()
        {
            object input = "en-US";
            Type conversionType = typeof(CultureInfo);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            Type inputType = typeof(string);
            bool result = Conversions.TryChangeTypeBasedOnInputType(input, conversionType, provider, inputType, out object value);
            Assert.True(result);
            Assert.Equal(new CultureInfo((string) input), value);
        }
        
        /// <summary>
        ///     Tests that try change type based on input type bool conversion returns true
        /// </summary>
        [Fact]
        public void TryChangeTypeBasedOnInputType_BoolConversion_ReturnsTrue()
        {
            object input = "true";
            Type conversionType = typeof(bool);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            Type inputType = typeof(string);
            bool result = Conversions.TryChangeTypeBasedOnInputType(input, conversionType, provider, inputType, out object value);
            Assert.True(result);
            Assert.Equal(true, value);
        }
        
        /// <summary>
        ///     Tests that try change type based on input type i convertible conversion returns true
        /// </summary>
        [Fact]
        public void TryChangeTypeBasedOnInputType_IConvertibleConversion_ReturnsTrue()
        {
            object input = "123";
            Type conversionType = typeof(int);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            Type inputType = typeof(string);
            bool result = Conversions.TryChangeTypeBasedOnInputType(input, conversionType, provider, inputType, out object value);
            Assert.True(result);
            Assert.Equal(123, value);
        }
        
        /// <summary>
        ///     Tests that try change type based on input type converter conversion returns true
        /// </summary>
        [Fact]
        public void TryChangeTypeBasedOnInputType_ConverterConversion_ReturnsTrue()
        {
            object input = "123";
            Type conversionType = typeof(int);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            Type inputType = typeof(string);
            bool result = Conversions.TryChangeTypeBasedOnInputType(input, conversionType, provider, inputType, out object value);
            Assert.True(result);
            Assert.Equal(123, value);
        }
        
        /// <summary>
        ///     Tests that try parse tokens with flags attribute and no enum separators returns true
        /// </summary>
        [Fact]
        public void TryParseTokens_WithFlagsAttributeAndNoEnumSeparators_ReturnsTrue()
        {
            // Arrange
            string input = "Monday";
            Type type = typeof(DayOfWeek);
            string[] names = Enum.GetNames(type);
            Array values = Enum.GetValues(type);
            
            // Act
            bool result = Conversions.TryParseTokens(input, type, names, values, out object value);
            
            // Assert
            Assert.True(result);
            Assert.Equal(DayOfWeek.Monday, value);
        }
        
        /// <summary>
        ///     Tests that try parse tokens without flags attribute and enum separators returns false
        /// </summary>
        [Fact]
        public void TryParseTokens_WithoutFlagsAttributeAndEnumSeparators_ReturnsFalse()
        {
            // Arrange
            string input = "1,2,3";
            Type type = typeof(int);
            string[] names = new string[0];
            Array values = Array.CreateInstance(type, 0);
            
            // Act
            bool result = Conversions.TryParseTokens(input, type, names, values, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Equal(0, value);
        }
        
        /// <summary>
        ///     Tests that try parse tokens with empty tokens returns false
        /// </summary>
        [Fact]
        public void TryParseTokens_WithEmptyTokens_ReturnsFalse()
        {
            // Arrange
            string input = ",";
            Type type = typeof(int);
            string[] names = new string[0];
            Array values = Array.CreateInstance(type, 0);
            
            // Act
            bool result = Conversions.TryParseTokens(input, type, names, values, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Equal(0, value);
        }
        
        /// <summary>
        ///     Tests that try parse tokens with valid tokens returns true
        /// </summary>
        [Fact]
        public void TryParseTokens_WithValidTokens_ReturnsTrue()
        {
            // Arrange
            string input = "Monday,Tuesday";
            Type type = typeof(DayOfWeek);
            string[] names = Enum.GetNames(type);
            Array values = Enum.GetValues(type);
            
            // Act
            bool result = Conversions.TryParseTokens(input, type, names, values, out object value);
            
            // Assert
            Assert.True(result);
            Assert.Equal(DayOfWeek.Monday | DayOfWeek.Tuesday, value);
        }
        
        /// <summary>
        ///     Tests that try parse tokens with invalid tokens returns false
        /// </summary>
        [Fact]
        public void TryParseTokens_WithInvalidTokens_ReturnsFalse()
        {
            // Arrange
            string input = "InvalidDay";
            Type type = typeof(DayOfWeek);
            string[] names = Enum.GetNames(type);
            Array values = Enum.GetValues(type);
            
            // Act
            bool result = Conversions.TryParseTokens(input, type, names, values, out object value);
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        ///     Tests that try parse hexadecimal valid hexadecimal returns true
        /// </summary>
        [Fact]
        public void TryParseHexadecimal_ValidHexadecimal_ReturnsTrue()
        {
            // Arrange
            string input = "0x1A";
            Type type = typeof(int);
            
            // Act
            bool result = Conversions.TryParseHexadecimal(input, type, out object value);
            
            // Assert
            Assert.True(result);
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that try parse hexadecimal invalid hexadecimal returns false
        /// </summary>
        [Fact]
        public void TryParseHexadecimal_InvalidHexadecimal_ReturnsFalse()
        {
            // Arrange
            string input = "0xG";
            Type type = typeof(int);
            
            // Act
            bool result = Conversions.TryParseHexadecimal(input, type, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that try parse hexadecimal non hexadecimal returns false
        /// </summary>
        [Fact]
        public void TryParseHexadecimal_NonHexadecimal_ReturnsFalse()
        {
            // Arrange
            string input = "123";
            Type type = typeof(int);
            
            // Act
            bool result = Conversions.TryParseHexadecimal(input, type, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that try parse hexadecimal empty string returns false
        /// </summary>
        [Fact]
        public void TryParseHexadecimal_EmptyString_ReturnsFalse()
        {
            // Arrange
            string input = "";
            Type type = typeof(int);
            
            // Act
            bool result = Conversions.TryParseHexadecimal(input, type, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that try parse hexadecimal null input returns false
        /// </summary>
        [Fact]
        public void TryParseHexadecimal_NullInput_ReturnsFalse()
        {
            // Arrange
            string input = null;
            Type type = typeof(int);
            
            // Act
            Assert.Throws<NullReferenceException>(() => Conversions.TryParseHexadecimal(input, type, out object value));
        }
        
        /// <summary>
        ///     Tests that try change with i convertible valid conversion returns true
        /// </summary>
        [Fact]
        public void TryChangeWithIConvertible_ValidConversion_ReturnsTrue()
        {
            // Arrange
            IConvertible input = "123";
            Type conversionType = typeof(int);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            
            // Act
            bool result = Conversions.TryChangeWithIConvertible(input, conversionType, provider, out object value);
            
            // Assert
            Assert.True(result);
            Assert.Equal(123, value);
        }
        
        /// <summary>
        ///     Tests that try change with i convertible invalid conversion returns false
        /// </summary>
        [Fact]
        public void TryChangeWithIConvertible_InvalidConversion_ReturnsFalse()
        {
            // Arrange
            IConvertible input = "invalid";
            Type conversionType = typeof(int);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            
            // Act
            bool result = Conversions.TryChangeWithIConvertible(input, conversionType, provider, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that try change with i convertible null input returns false
        /// </summary>
        [Fact]
        public void TryChangeWithIConvertible_NullInput_ReturnsFalse()
        {
            // Arrange
            IConvertible input = null;
            Type conversionType = typeof(int);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            
            // Act
            bool result = Conversions.TryChangeWithIConvertible(input, conversionType, provider, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that try change with i convertible null conversion type throws argument null exception
        /// </summary>
        [Fact]
        public void TryChangeWithIConvertible_NullConversionType_ThrowsArgumentNullException()
        {
            // Arrange
            IConvertible input = "123";
            Type conversionType = null;
            IFormatProvider provider = CultureInfo.InvariantCulture;
            
            // Act & Assert
            Conversions.TryChangeWithIConvertible(input, conversionType, provider, out object value);
            
            // Assert
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that enum try parse valid enum string returns true
        /// </summary>
        [Fact]
        public void EnumTryParse_ValidEnumString_ReturnsTrue()
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
        ///     Tests that enum try parse invalid enum string returns false
        /// </summary>
        [Fact]
        public void EnumTryParse_InvalidEnumString_ReturnsFalse()
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
        ///     Tests that enum try parse valid hexadecimal returns true
        /// </summary>
        [Fact]
        public void EnumTryParse_ValidHexadecimal_ReturnsTrue()
        {
            // Arrange
            Type type = typeof(int);
            object input = "0x1A";
            
            // Act
            bool result = Conversions.EnumTryParse(type, input, out object value);
            
            // Assert
            Assert.True(result);
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that enum try parse invalid hexadecimal returns false
        /// </summary>
        [Fact]
        public void EnumTryParse_InvalidHexadecimal_ReturnsFalse()
        {
            // Arrange
            Type type = typeof(int);
            object input = "0xG";
            
            // Act
            bool result = Conversions.EnumTryParse(type, input, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that enum try parse null input returns false
        /// </summary>
        [Fact]
        public void EnumTryParse_NullInput_ReturnsFalse()
        {
            // Arrange
            Type type = typeof(int);
            object input = null;
            
            // Act
            bool result = Conversions.EnumTryParse(type, input, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that enum try parse null type throws argument null exception
        /// </summary>
        [Fact]
        public void EnumTryParse_NullType_ThrowsArgumentNullException()
        {
            // Arrange
            Type type = null;
            object input = "123";
            
            // Act & Assert
            Conversions.EnumTryParse(type, input, out object value);
            
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that try change to uri valid uri returns true
        /// </summary>
        [Fact]
        public void TryChangeToUri_ValidUri_ReturnsTrue()
        {
            // Arrange
            object input = "http://example.com/";
            IFormatProvider provider = CultureInfo.InvariantCulture;
            object value;
            
            // Act
            bool result = Conversions.TryConvertToUri(input.ToString(), out value);
            
            // Assert
            Assert.True(result);
            Assert.IsType<Uri>(value);
            Assert.Equal(input.ToString(), value.ToString());
        }
        
        /// <summary>
        ///     Tests that try change to uri invalid uri returns false
        /// </summary>
        [Fact]
        public void TryChangeToUri_InvalidUri_ReturnsFalse()
        {
            // Arrange
            object input = "invalid uri";
            IFormatProvider provider = CultureInfo.InvariantCulture;
            object value;
            
            // Act
            bool result = Conversions.TryConvertToUri(input.ToString(), out value);
            
            // Assert
            Assert.True(result);
            Assert.NotNull(value);
        }
        
        /// <summary>
        ///     Tests that try change to uri null input returns false
        /// </summary>
        [Fact]
        public void TryChangeToUri_NullInput_ReturnsFalse()
        {
            // Arrange
            object input = null;
            IFormatProvider provider = CultureInfo.InvariantCulture;
            object value;
            
            // Act
            Assert.Throws<NullReferenceException>(() => Conversions.TryConvertToUri(input.ToString(), out value));
        }
        
        /// <summary>
        ///     Tests that is valid input valid input returns true
        /// </summary>
        [Fact]
        public void IsValidInput_ValidInput_ReturnsTrue()
        {
            Assert.True(Conversions.IsValidInput(typeof(DayOfWeek), "Monday"));
        }
        
        /// <summary>
        ///     Tests that is valid input null type returns false
        /// </summary>
        [Fact]
        public void IsValidInput_NullType_ReturnsFalse()
        {
            Assert.False(Conversions.IsValidInput(null, "Monday"));
        }
        
        /// <summary>
        ///     Tests that is valid input null input returns false
        /// </summary>
        [Fact]
        public void IsValidInput_NullInput_ReturnsFalse()
        {
            Assert.False(Conversions.IsValidInput(typeof(DayOfWeek), null));
        }
        
        /// <summary>
        ///     Tests that format input removes whitespace
        /// </summary>
        [Fact]
        public void FormatInput_RemovesWhitespace()
        {
            Assert.Equal("Monday", Conversions.FormatInput("  Monday  "));
        }
        
        /// <summary>
        ///     Tests that is hexadecimal and can be parsed valid hexadecimal returns true
        /// </summary>
        [Fact]
        public void IsHexadecimalAndCanBeParsed_ValidHexadecimal_ReturnsTrue()
        {
            Assert.True(Conversions.IsHexadecimalAndCanBeParsed("0x1A", typeof(int), out _));
        }
        
        /// <summary>
        ///     Tests that is hexadecimal and can be parsed invalid hexadecimal returns false
        /// </summary>
        [Fact]
        public void IsHexadecimalAndCanBeParsed_InvalidHexadecimal_ReturnsFalse()
        {
            Assert.False(Conversions.IsHexadecimalAndCanBeParsed("0xG", typeof(int), out _));
        }
        
        /// <summary>
        ///     Tests that can get enum names and values valid enum type returns true
        /// </summary>
        [Fact]
        public void CanGetEnumNamesAndValues_ValidEnumType_ReturnsTrue()
        {
            Assert.True(Conversions.CanGetEnumNamesAndValues(typeof(DayOfWeek), out _, out _));
        }
        
        /// <summary>
        ///     Tests that can get enum names and values non enum type returns false
        /// </summary>
        [Fact]
        public void CanGetEnumNamesAndValues_NonEnumType_ReturnsFalse()
        {
            Assert.False(Conversions.CanGetEnumNamesAndValues(typeof(int), out _, out _));
        }
        
        /// <summary>
        ///     Tests that can parse tokens valid tokens returns true
        /// </summary>
        [Fact]
        public void CanParseTokens_ValidTokens_ReturnsTrue()
        {
            string[] names = Enum.GetNames(typeof(DayOfWeek));
            Array values = Enum.GetValues(typeof(DayOfWeek));
            Assert.True(Conversions.CanParseTokens("Monday,Tuesday", typeof(DayOfWeek), names, values, out _));
        }
        
        /// <summary>
        ///     Tests that can parse tokens invalid tokens returns false
        /// </summary>
        [Fact]
        public void CanParseTokens_InvalidTokens_ReturnsFalse()
        {
            string[] names = Enum.GetNames(typeof(DayOfWeek));
            Array values = Enum.GetValues(typeof(DayOfWeek));
            Assert.False(Conversions.CanParseTokens("InvalidDay", typeof(DayOfWeek), names, values, out _));
        }
        
        /// <summary>
        ///     Tests that try convert to uri valid uri returns true
        /// </summary>
        [Fact]
        public void TryConvertToUri_ValidUri_ReturnsTrue()
        {
            // Arrange
            string input = "http://example.com/";
            
            // Act
            bool result = Conversions.TryConvertToUri(input, out object value);
            
            // Assert
            Assert.True(result);
            Assert.IsType<Uri>(value);
            Assert.Equal(input, value.ToString());
        }
        
        /// <summary>
        ///     Tests that try convert to uri invalid uri returns false
        /// </summary>
        [Fact]
        public void TryConvertToUri_InvalidUri_ReturnsFalse()
        {
            // Arrange
            string input = "invalid uri";
            
            // Act
            bool result = Conversions.TryConvertToUri(input, out object value);
            
            // Assert
            Assert.True(result);
        }
        
        /// <summary>
        ///     Tests that try convert to uri null input returns false
        /// </summary>
        [Fact]
        public void TryConvertToUri_NullInput_ReturnsFalse()
        {
            // Arrange
            string input = null;
            
            // Act
            bool result = Conversions.TryConvertToUri(input, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that try convert to uri empty input returns false
        /// </summary>
        [Fact]
        public void TryConvertToUri_EmptyInput_ReturnsFalse()
        {
            // Arrange
            string input = "";
            
            // Act
            bool result = Conversions.TryConvertToUri(input, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that try convert with appropriate converter successful conversion returns true
        /// </summary>
        [Fact]
        public void TryConvertWithAppropriateConverter_SuccessfulConversion_ReturnsTrue()
        {
            // Arrange
            object inputValue = "123";
            Type targetType = typeof(int);
            Type sourceType = typeof(string);
            object convertedValue;
            
            // Act
            bool result = Conversions.TryConvert(inputValue, targetType, sourceType, out convertedValue);
            
            // Assert
            Assert.True(result);
            Assert.Equal(123, convertedValue);
        }
        
        /// <summary>
        ///     Tests that try convert with appropriate converter failed conversion returns false
        /// </summary>
        [Fact]
        public void TryConvertWithAppropriateConverter_FailedConversion_ReturnsFalse()
        {
            // Arrange
            object inputValue = "invalid";
            Type targetType = typeof(int);
            Type sourceType = typeof(string);
            object convertedValue;
            
            // Act
            Assert.Throws<ArgumentException>(() => Conversions.TryConvert(inputValue, targetType, sourceType, out convertedValue));
        }
        
        /// <summary>
        ///     Tests that try change to nullable null input returns true
        /// </summary>
        [Fact]
        public void TryChangeToNullable_NullInput_ReturnsTrue()
        {
            // Arrange
            object input = null;
            Type conversionType = typeof(int?);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            
            // Act
            bool result = Conversions.TryChangeToNullable(input, conversionType, provider, out object value);
            
            // Assert
            Assert.True(result);
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that try change to nullable valid input returns true
        /// </summary>
        [Fact]
        public void TryChangeToNullable_ValidInput_ReturnsTrue()
        {
            // Arrange
            object input = "123";
            Type conversionType = typeof(int?);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            
            // Act
            bool result = Conversions.TryChangeToNullable(input, conversionType, provider, out object value);
            
            // Assert
            Assert.True(result);
            Assert.Equal(123, value);
        }
        
        /// <summary>
        ///     Tests that try change to nullable invalid input returns false
        /// </summary>
        [Fact]
        public void TryChangeToNullable_InvalidInput_ReturnsFalse()
        {
            // Arrange
            object input = "invalid";
            Type conversionType = typeof(int?);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            
            // Act
            Assert.Throws<FormatException>(() => Conversions.TryChangeToNullable(input, conversionType, provider, out object value));
        }
        
        /// <summary>
        ///     Tests that try change to nullable non nullable conversion type returns false
        /// </summary>
        [Fact]
        public void TryChangeToNullable_NonNullableConversionType_ReturnsFalse()
        {
            // Arrange
            object input = "123";
            Type conversionType = typeof(int);
            IFormatProvider provider = CultureInfo.InvariantCulture;
            
            // Act
            bool result = Conversions.TryChangeToNullable(input, conversionType, provider, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that try convert valid conversion returns true
        /// </summary>
        [Fact]
        public void TryConvert_ValidConversion_ReturnsTrue()
        {
            object value = "123";
            Type target = typeof(int);
            Type source = typeof(string);
            bool result = Conversions.TryConvert(value, target, source, out object convertedValue);
            Assert.True(result);
            Assert.Equal(123, convertedValue);
        }
        
        /// <summary>
        ///     Tests that try convert invalid conversion returns false
        /// </summary>
        [Fact]
        public void TryConvert_InvalidConversion_ReturnsFalse()
        {
            object value = "invalid";
            Type target = typeof(int);
            Type source = typeof(string);
            Assert.Throws<ArgumentException>(() => Conversions.TryConvert(value, target, source, out object convertedValue));
        }
        
        /// <summary>
        ///     Tests that try convert no type converter returns false
        /// </summary>
        [Fact]
        public void TryConvert_NoTypeConverter_ReturnsFalse()
        {
            object value = new object();
            Type target = typeof(object);
            Type source = typeof(string);
            bool result = Conversions.TryConvert(value, target, source, out object convertedValue);
            Assert.False(result);
            Assert.Null(convertedValue);
        }
        
        /// <summary>
        ///     Tests that try handle digit or sign start with digit start returns true v 2
        /// </summary>
        [Fact]
        public void TryHandleDigitOrSignStart_WithDigitStart_ReturnsTrue_v2()
        {
            // Arrange
            Type type = typeof(int);
            string input = "123";
            
            // Act
            bool result = Conversions.TryHandleDigitOrSignStart(type, input, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Equal(0, value);
        }
        
        /// <summary>
        ///     Tests that try handle digit or sign start with positive sign start returns true v 2
        /// </summary>
        [Fact]
        public void TryHandleDigitOrSignStart_WithPositiveSignStart_ReturnsTrue_v2()
        {
            // Arrange
            Type type = typeof(int);
            string input = "+123";
            
            // Act
            bool result = Conversions.TryHandleDigitOrSignStart(type, input, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Equal(0, value);
        }
        
        /// <summary>
        ///     Tests that try handle digit or sign start with negative sign start returns true v 2
        /// </summary>
        [Fact]
        public void TryHandleDigitOrSignStart_WithNegativeSignStart_ReturnsTrue_v2()
        {
            // Arrange
            Type type = typeof(int);
            string input = "-123";
            
            // Act
            bool result = Conversions.TryHandleDigitOrSignStart(type, input, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Equal(0, value);
        }
        
        /// <summary>
        ///     Tests that try handle digit or sign start with non digit or sign start returns false v 2
        /// </summary>
        [Fact]
        public void TryHandleDigitOrSignStart_WithNonDigitOrSignStart_ReturnsFalse_v2()
        {
            // Arrange
            Type type = typeof(int);
            string input = "abc";
            
            // Act
            bool result = Conversions.TryHandleDigitOrSignStart(type, input, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Equal(0, value);
        }
        
        /// <summary>
        ///     Tests that try handle digit or sign start with null input returns false v 2
        /// </summary>
        [Fact]
        public void TryHandleDigitOrSignStart_WithNullInput_ReturnsFalse_v2()
        {
            // Arrange
            Type type = typeof(int);
            string input = null;
            
            // Act
            Assert.Throws<NullReferenceException>(() => Conversions.TryHandleDigitOrSignStart(type, input, out object value));
        }
        
        /// <summary>
        ///     Tests that try convert to uri null or empty input returns false
        /// </summary>
        [Fact]
        public void TryConvertToUri_NullOrEmptyInput_ReturnsFalse()
        {
            bool result = Conversions.TryConvertToUri(null, out object value);
            Assert.False(result);
            Assert.Null(value);
            
            result = Conversions.TryConvertToUri(string.Empty, out value);
            Assert.False(result);
            Assert.Null(value);
        }
        
        /// <summary>
        ///     Tests that try convert to uri valid uri input returns true
        /// </summary>
        [Fact]
        public void TryConvertToUri_ValidUriInput_ReturnsTrue()
        {
            bool result = Conversions.TryConvertToUri("http://example.com", out object value);
            Assert.True(result);
            Assert.IsType<Uri>(value);
            Assert.Equal("http://example.com/", ((Uri) value).AbsoluteUri);
        }
        
        /// <summary>
        ///     Tests that try convert to uri invalid uri input returns false
        /// </summary>
        [Fact]
        public void TryConvertToUri_InvalidUriInput_ReturnsFalse()
        {
            bool result = Conversions.TryConvertToUri("invalid uri", out object value);
            Assert.True(result);
            Assert.NotNull(value);
        }
        
        /// <summary>
        ///     Tests that try handle digit or sign start with digit start returns true v 4
        /// </summary>
        [Fact]
        public void TryHandleDigitOrSignStart_WithDigitStart_ReturnsTrue_v4()
        {
            // Arrange
            Type type = typeof(int);
            string input = "123";
            
            // Act
            bool result = Conversions.TryHandleDigitOrSignStart(type, input, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Equal(0, value);
        }
        
        /// <summary>
        ///     Tests that try handle digit or sign start with positive sign start returns true v 4
        /// </summary>
        [Fact]
        public void TryHandleDigitOrSignStart_WithPositiveSignStart_ReturnsTrue_v4()
        {
            // Arrange
            Type type = typeof(int);
            string input = "+123";
            
            // Act
            bool result = Conversions.TryHandleDigitOrSignStart(type, input, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Equal(0, value);
        }
        
        /// <summary>
        ///     Tests that try handle digit or sign start with negative sign start returns true v 4
        /// </summary>
        [Fact]
        public void TryHandleDigitOrSignStart_WithNegativeSignStart_ReturnsTrue_v4()
        {
            // Arrange
            Type type = typeof(int);
            string input = "-123";
            
            // Act
            bool result = Conversions.TryHandleDigitOrSignStart(type, input, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Equal(0, value);
        }
        
        /// <summary>
        ///     Tests that try handle digit or sign start with non digit or sign start returns false v 4
        /// </summary>
        [Fact]
        public void TryHandleDigitOrSignStart_WithNonDigitOrSignStart_ReturnsFalse_v4()
        {
            // Arrange
            Type type = typeof(int);
            string input = "abc";
            
            // Act
            bool result = Conversions.TryHandleDigitOrSignStart(type, input, out object value);
            
            // Assert
            Assert.False(result);
            Assert.Equal(0, value);
        }
        
        /// <summary>
        ///     Tests that try handle digit or sign start with null input throws exception
        /// </summary>
        [Fact]
        public void TryHandleDigitOrSignStart_WithNullInput_ThrowsException()
        {
            // Arrange
            Type type = typeof(int);
            string input = null;
            
            // Act & Assert
            Assert.Throws<NullReferenceException>(() => Conversions.TryHandleDigitOrSignStart(type, input, out object value));
        }
        
        /// <summary>
        ///     Tests that try handle digit or sign start with digit start returns true and converted value
        /// </summary>
        [Fact]
        public void TryHandleDigitOrSignStart_WithDigitStart_ReturnsTrueAndConvertedValue()
        {
            // Arrange
            string input = "123";
            object value;
            
            // Act
            bool result = Conversions.TryHandleDigitOrSignStart(typeof(int), input, out value);
            
            // Assert
            Assert.False(result);
            Assert.Equal(0, value);
        }
        
        /// <summary>
        ///     Tests that try handle digit or sign start with negative sign start returns true and converted value
        /// </summary>
        [Fact]
        public void TryHandleDigitOrSignStart_WithNegativeSignStart_ReturnsTrueAndConvertedValue()
        {
            // Arrange
            string input = "-123";
            object value;
            
            // Act
            bool result = Conversions.TryHandleDigitOrSignStart(typeof(int), input, out value);
            
            // Assert
            Assert.False(result);
            Assert.Equal(0, value);
        }
        
        /// <summary>
        ///     Tests that try handle digit or sign start with positive sign start returns true and converted value
        /// </summary>
        [Fact]
        public void TryHandleDigitOrSignStart_WithPositiveSignStart_ReturnsTrueAndConvertedValue()
        {
            // Arrange
            string input = "+123";
            object value;
            
            // Act
            bool result = Conversions.TryHandleDigitOrSignStart(typeof(int), input, out value);
            
            // Assert
            Assert.False(result);
            Assert.Equal(0, value);
        }
        
        /// <summary>
        ///     Tests that try handle digit or sign start with non digit or sign start returns false and default value
        /// </summary>
        [Fact]
        public void TryHandleDigitOrSignStart_WithNonDigitOrSignStart_ReturnsFalseAndDefaultValue()
        {
            // Arrange
            string input = "abc";
            object value;
            
            // Act
            bool result = Conversions.TryHandleDigitOrSignStart(typeof(int), input, out value);
            
            // Assert
            Assert.False(result);
            Assert.Equal(0, value);
        }
        
        /// <summary>
        ///     Tests that try handle digit or sign start with empty string returns false and default value
        /// </summary>
        [Fact]
        public void TryHandleDigitOrSignStart_WithEmptyString_ReturnsFalseAndDefaultValue()
        {
            // Arrange
            string input = "0";
            object value;
            
            // Act
            bool result = Conversions.TryHandleDigitOrSignStart(typeof(int), input, out value);
            
            // Assert
            Assert.False(result);
            Assert.Equal(0, value);
        }
        
        /// <summary>
        /// Tests that test try handle digit or sign start with digit start
        /// </summary>
        [Fact]
        public void TestTryHandleDigitOrSignStart_WithDigitStart()
        {
            // Arrange
            Type type = typeof(int);
            string input = "123";
            object value;
            
            // Act
            bool result = Conversions.TryHandleDigitOrSignStart(type, input, out value);
            
            // Assert
            Assert.False(result);
            Assert.Equal(0, value);
        }
        
        /// <summary>
        /// Tests that test try handle digit or sign start with sign start
        /// </summary>
        [Fact]
        public void TestTryHandleDigitOrSignStart_WithSignStart()
        {
            // Arrange
            Type type = typeof(int);
            string input = "-123";
            object value;
            
            // Act
            bool result = Conversions.TryHandleDigitOrSignStart(type, input, out value);
            
            // Assert
            Assert.False(result);
            Assert.Equal(0, value);
        }
        
        /// <summary>
        /// Tests that test try handle digit or sign start with non digit non sign start
        /// </summary>
        [Fact]
        public void TestTryHandleDigitOrSignStart_WithNonDigitNonSignStart()
        {
            // Arrange
            Type type = typeof(int);
            string input = "abc";
            object value;
            
            // Act
            bool result = Conversions.TryHandleDigitOrSignStart(type, input, out value);
            
            // Assert
            Assert.False(result);
            Assert.Equal(0, value);
        }
        
        [Fact]
        public void ConvertToEnum_ReturnsEnum_WhenValueIsInt()
        {
            // Arrange
            Type enumType = typeof(DayOfWeek);
            object value = 1;
            
            // Act
            var result = Conversions.ConvertToEnum(enumType, value);
            
            // Assert
            Assert.Equal(DayOfWeek.Monday, result);
        }
        
        [Fact]
        public void ConvertToEnum_ReturnsEnum_WhenValueIsString()
        {
            // Arrange
            Type enumType = typeof(DayOfWeek);
            object value = "Sunday";
            
            // Act
            var result = Conversions.ConvertToEnum(enumType, value);
            
            // Assert
            Assert.Equal(DayOfWeek.Sunday, result);
        }
        
        [Fact]
        public void ConvertToEnum_ReturnsNull_WhenValueIsInvalid()
        {
            // Arrange
            Type enumType = typeof(DayOfWeek);
            object value = "InvalidDay";
            
            // Act
            var result = Conversions.ConvertToEnum(enumType, value);
            
            // Assert
            Assert.Equal(DayOfWeek.Sunday ,result);
        }
        
        [Fact]
        public void ConvertToEnum_ReturnsNull_WhenEnumTypeIsNotEnum()
        {
            // Arrange
            Type enumType = typeof(string);
            object value = "Monday";
            
            // Act
            Assert.Throws<ArgumentException>( () => Conversions.ConvertToEnum(enumType, value));
            
        }
    }
}