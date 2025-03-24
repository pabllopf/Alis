// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Conversions.cs
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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     The conversions class
    /// </summary>
    internal static class Conversions
    {
        /// <summary>
        ///     The enum separators
        /// </summary>
        internal static readonly char[] EnumSeparators = {',', ';', '+', '|', ' '};

        /// <summary>
        ///     Describes whether is valid
        /// </summary>
        /// <param name="dt">The dt</param>
        /// <returns>The bool</returns>
        internal static bool IsValid(DateTime dt) => (dt != DateTime.MinValue) && (dt != DateTime.MaxValue) && (dt.Kind != DateTimeKind.Unspecified);

        /// <summary>
        ///     Changes the type using the specified input
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="input">The input</param>
        /// <param name="defaultValue">The default value</param>
        /// <param name="provider">The provider</param>
        /// <returns>The value</returns>
        public static T ChangeType<T>(object input, T defaultValue = default(T), IFormatProvider provider = null) => !TryChangeType(input, provider, out T value) ? defaultValue : value;

        /// <summary>
        ///     Describes whether try change type
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="input">The input</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        public static bool TryChangeType<T>(object input, out T value) => TryChangeType(input, null, out value);

        /// <summary>
        ///     Describes whether try change type
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="input">The input</param>
        /// <param name="provider">The provider</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool TryChangeType<T>(object input, IFormatProvider provider, out T value)
        {
            if (!TryChangeType(input, typeof(T), provider, out object tValue))
            {
                value = default(T);
                return false;
            }

            value = (T) tValue;
            return true;
        }

        /// <summary>
        ///     Changes the type using the specified input
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="conversionType">The conversion type</param>
        /// <param name="defaultValue">The default value</param>
        /// <param name="provider">The provider</param>
        /// <returns>The value</returns>
        public static object ChangeType(object input, Type conversionType, object defaultValue = null, IFormatProvider provider = null)
        {
            if (!TryChangeType(input, conversionType, provider, out object value))
            {
                if (TryChangeType(defaultValue, conversionType, provider, out object def))
                {
                    return def;
                }

                return IsReallyValueType(conversionType) ? Activator.CreateInstance(conversionType) : null;
            }

            return value;
        }

        /// <summary>
        ///     Describes whether try change type
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="conversionType">The conversion type</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        public static bool TryChangeType(object input, Type conversionType, out object value) => TryChangeType(input, conversionType, null, out value);


        /// <summary>
        ///     Describes whether try change type
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="conversionType">The conversion type</param>
        /// <param name="provider">The provider</param>
        /// <param name="value">The value</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>The bool</returns>
        internal static bool TryChangeType(object input, Type conversionType, IFormatProvider provider, out object value)
        {
            if (conversionType == null)
            {
                throw new ArgumentNullException(nameof(conversionType));
            }

            if (conversionType == typeof(object))
            {
                value = input;
                return true;
            }

            if (IsNullable(conversionType))
            {
                return TryChangeToNullable(input, conversionType, provider, out value);
            }

            value = IsReallyValueType(conversionType) ? Activator.CreateInstance(conversionType) : null;
            if (input == null)
            {
                return !IsReallyValueType(conversionType);
            }

            Type inputType = input.GetType();
            if (conversionType.IsAssignableFrom(inputType))
            {
                value = input;
                return true;
            }

            return TryChangeTypeBasedOnInputType(input, conversionType, provider, inputType, out value);
        }

        /// <summary>
        ///     Describes whether try change type based on input type
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="conversionType">The conversion type</param>
        /// <param name="provider">The provider</param>
        /// <param name="inputType">The input type</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool TryChangeTypeBasedOnInputType(object input, Type conversionType, IFormatProvider provider, Type inputType, out object value)
        {
            if (conversionType.IsEnum)
            {
                return TryChangeToEnum(conversionType, input, out value);
            }

            if (inputType.IsEnum)
            {
                return TryChangeFromEnum(conversionType, input, out value);
            }

            return TryChangeBasedOnConversionType(input, conversionType, provider, inputType, out value);
        }

        /// <summary>
        ///     Describes whether try change based on conversion type
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="conversionType">The conversion type</param>
        /// <param name="provider">The provider</param>
        /// <param name="inputType">The input type</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool TryChangeBasedOnConversionType(object input, Type conversionType, IFormatProvider provider, Type inputType, out object value)
        {
            if (conversionType == typeof(Guid))
            {
                return TryChangeToGuid(input, provider, out value);
            }

            if (conversionType == typeof(Uri))
            {
                return TryConvertToUri(input.ToString(), out value);
            }

            if (conversionType == typeof(IntPtr))
            {
                return TryChangeToIntPtr(input, out value);
            }

            if (IsNumericType(conversionType))
            {
                return TryChangeToNumeric(input, conversionType, out value);
            }

            if (IsDateTimeType(conversionType))
            {
                return TryChangeToDateTime(input, conversionType, inputType, out value);
            }

            if (conversionType == typeof(TimeSpan))
            {
                return TryChangeToTimeSpan(input, provider, out value);
            }

            return TryChangeBasedOnOtherTypes(input, conversionType, provider, inputType, out value);
        }

        /// <summary>
        ///     Describes whether try change based on other types
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="conversionType">The conversion type</param>
        /// <param name="provider">The provider</param>
        /// <param name="inputType">The input type</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool TryChangeBasedOnOtherTypes(object input, Type conversionType, IFormatProvider provider, Type inputType, out object value)
        {
            if (IsArrayOrGenericList(conversionType, out Type elementType))
            {
                return TryChangeToCollection(input, conversionType, elementType, out value);
            }

            if (IsCultureInfoOrFormatProvider(conversionType))
            {
                return TryChangeToCultureInfo(input, out value);
            }

            if (IsBool(conversionType))
            {
                return TryChangeToBool(input, provider, out value);
            }

            if (IsConvertible(input, out IConvertible convertible))
            {
                return TryChangeWithIConvertible(convertible, conversionType, provider, out value);
            }

            return TryConvert(input, conversionType, inputType, out value);
        }

        /// <summary>
        ///     Describes whether is array or generic list
        /// </summary>
        /// <param name="conversionType">The conversion type</param>
        /// <param name="elementType">The element type</param>
        /// <returns>The bool</returns>
        internal static bool IsArrayOrGenericList(Type conversionType, out Type elementType)
        {
            elementType = null;
            return conversionType.IsArray || IsGenericList(conversionType, out elementType);
        }

        /// <summary>
        ///     Describes whether is culture info or format provider
        /// </summary>
        /// <param name="conversionType">The conversion type</param>
        /// <returns>The bool</returns>
        internal static bool IsCultureInfoOrFormatProvider(Type conversionType) => conversionType == typeof(CultureInfo) || conversionType == typeof(IFormatProvider);

        /// <summary>
        ///     Describes whether is bool
        /// </summary>
        /// <param name="conversionType">The conversion type</param>
        /// <returns>The bool</returns>
        internal static bool IsBool(Type conversionType) => conversionType == typeof(bool);

        /// <summary>
        ///     Describes whether is convertible
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="convertible">The convertible</param>
        /// <returns>The bool</returns>
        internal static bool IsConvertible(object input, out IConvertible convertible)
        {
            convertible = input as IConvertible;
            return convertible != null;
        }

        /// <summary>
        ///     Describes whether is numeric type
        /// </summary>
        /// <param name="conversionType">The conversion type</param>
        /// <returns>The bool</returns>
        internal static bool IsNumericType(Type conversionType) => conversionType == typeof(int) || conversionType == typeof(long) || conversionType == typeof(short) || conversionType == typeof(sbyte) || conversionType == typeof(uint) || conversionType == typeof(ulong) || conversionType == typeof(ushort) || conversionType == typeof(byte);

        /// <summary>
        ///     Describes whether is date time type
        /// </summary>
        /// <param name="conversionType">The conversion type</param>
        /// <returns>The bool</returns>
        internal static bool IsDateTimeType(Type conversionType) => conversionType == typeof(DateTime) || conversionType == typeof(DateTimeOffset);

        /// <summary>
        ///     Attempts to convert the input to a nullable type.
        /// </summary>
        /// <param name="input">The input to convert.</param>
        /// <param name="conversionType">The type to convert to.</param>
        /// <param name="provider">The format provider to use for conversion.</param>
        /// <param name="value">The converted value.</param>
        /// <returns>True if the conversion was successful, otherwise false.</returns>
        internal static bool TryChangeToNullable(object input, Type conversionType, IFormatProvider provider, out object value)
        {
            value = null;

            if (input == null)
            {
                return true;
            }

            Type nullableUnderlyingType = Nullable.GetUnderlyingType(conversionType);
            if (nullableUnderlyingType != null)
            {
                value = Convert.ChangeType(input, nullableUnderlyingType, provider);
                return true;
            }

            return false;
        }

        /// <summary>
        ///     Describes whether try change to enum
        /// </summary>
        /// <param name="conversionType">The conversion type</param>
        /// <param name="input">The input</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool TryChangeToEnum(Type conversionType, object input, out object value)
        {
            if (Enum.IsDefined(conversionType, input))
            {
                value = Enum.Parse(conversionType, input.ToString());
                return true;
            }

            value = null;
            return false;
        }

        /// <summary>
        ///     Describes whether try change from enum
        /// </summary>
        /// <param name="conversionType">The conversion type</param>
        /// <param name="input">The input</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool TryChangeFromEnum(Type conversionType, object input, out object value)
        {
            if (input is Enum)
            {
                value = Convert.ChangeType(input, conversionType);
                return true;
            }

            value = null;
            return false;
        }

        /// <summary>
        ///     Describes whether try change to guid
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="provider">The provider</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool TryChangeToGuid(object input, IFormatProvider provider, out object value)
        {
            if (Guid.TryParse(input.ToString(), out Guid guid))
            {
                value = guid;
                return true;
            }

            value = null;
            return false;
        }

        /// <summary>
        ///     Describes whether try convert to uri
        /// </summary>
        /// <param name="inputString">The input string</param>
        /// <param name="result">The result</param>
        /// <returns>The is uri created</returns>
        internal static bool TryConvertToUri(string inputString, out object result)
        {
            result = null;

            if (string.IsNullOrEmpty(inputString))
            {
                return false;
            }

            bool isUriCreated = Uri.TryCreate(inputString, UriKind.RelativeOrAbsolute, out Uri uri);

            if (isUriCreated)
            {
                result = uri;
            }

            return isUriCreated;
        }

        /// <summary>
        ///     Describes whether try change to int ptr
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool TryChangeToIntPtr(object input, out object value)
        {
            if (int.TryParse(input.ToString(), out int intResult))
            {
                value = new IntPtr(intResult);
                return true;
            }

            value = null;
            return false;
        }

        /// <summary>
        ///     Describes whether try change to numeric
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="conversionType">The conversion type</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool TryChangeToNumeric(object input, Type conversionType, out object value)
        {
            try
            {
                value = Convert.ChangeType(input, conversionType);
            }
            catch (Exception)
            {
                value = null;
                return false;
            }

            return true;
        }

        /// <summary>
        ///     Describes whether try change to date time
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="conversionType">The conversion type</param>
        /// <param name="inputType">The input type</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool TryChangeToDateTime(object input, Type conversionType, Type inputType, out object value)
        {
            if (DateTime.TryParse(input.ToString(), out DateTime dateTime))
            {
                value = dateTime;
                return true;
            }

            value = null;
            return false;
        }

        /// <summary>
        ///     Describes whether try change to time span
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="provider">The provider</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool TryChangeToTimeSpan(object input, IFormatProvider provider, out object value)
        {
            if (TimeSpan.TryParse(input.ToString(), out TimeSpan timeSpan))
            {
                value = timeSpan;
                return true;
            }

            value = null;
            return false;
        }

        /// <summary>
        ///     Describes whether try change to collection
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="conversionType">The conversion type</param>
        /// <param name="elementType">The element type</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool TryChangeToCollection(object input, Type conversionType, Type elementType, out object value)
        {
            if (input is IList list)
            {
                IList result = (IList) Activator.CreateInstance(conversionType);
                foreach (object item in list)
                {
                    result.Add(Convert.ChangeType(item, elementType));
                }

                value = result;
                return true;
            }

            value = null;
            return false;
        }

        /// <summary>
        ///     Describes whether try change to culture info
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool TryChangeToCultureInfo(object input, out object value)
        {
            if (CultureInfo.GetCultures(CultureTypes.AllCultures).Any(c => c.Name == input.ToString()))
            {
                value = new CultureInfo(input.ToString());
                return true;
            }

            value = null;
            return false;
        }

        /// <summary>
        ///     Describes whether try change to bool
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="provider">The provider</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool TryChangeToBool(object input, IFormatProvider provider, out object value)
        {
            if (bool.TryParse(input.ToString(), out bool boolValue))
            {
                value = boolValue;
                return true;
            }

            value = null;
            return false;
        }

        /// <summary>
        ///     Describes whether try change with i convertible
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="conversionType">The conversion type</param>
        /// <param name="provider">The provider</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool TryChangeWithIConvertible(IConvertible input, Type conversionType, IFormatProvider provider, out object value)
        {
            try
            {
                value = input.ToType(conversionType, provider);
                return true;
            }
            catch
            {
                value = null;
                return false;
            }
        }

        /// <summary>
        ///     Tries to convert the input value to the target type.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="target">The target type to convert to.</param>
        /// <param name="source">The source type of the value.</param>
        /// <param name="result">The result of the conversion.</param>
        /// <returns>True if the conversion was successful, false otherwise.</returns>
        internal static bool TryConvert(object value, Type target, Type source, out object result)
        {
            TypeConverter converter = GetConverter(target);

            if (converter.CanConvertFrom(source))
            {
                result = converter.ConvertFrom(value);
                return true;
            }

            result = null;
            return false;
        }

        /// <summary>
        ///     Gets the type converter for the specified type.
        /// </summary>
        /// <param name="type">The type to get the converter for.</param>
        /// <returns>The type converter for the specified type.</returns>
        internal static TypeConverter GetConverter(Type type) => TypeDescriptor.GetConverter(type);

        /// <summary>
        ///     Enums the to u int 64 using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>The ulong</returns>
        internal static ulong EnumToUInt64(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            TypeCode typeCode = Convert.GetTypeCode(value);
            switch (typeCode)
            {
                case TypeCode.SByte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                    return (ulong) Convert.ToInt64(value, CultureInfo.InvariantCulture);

                case TypeCode.Byte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return Convert.ToUInt64(value, CultureInfo.InvariantCulture);

                //case TypeCode.String:
                case TypeCode.Boolean:
                case TypeCode.Char:
                case TypeCode.DateTime:
                case TypeCode.DBNull:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Empty:
                case TypeCode.Object:
                case TypeCode.Single:
                case TypeCode.String:
                default:
                    return ChangeType<ulong>(value, 0, CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        ///     Tries to convert a string to an enum value.
        /// </summary>
        /// <param name="type">The type of the enum.</param>
        /// <param name="names">The names of the enum values.</param>
        /// <param name="values">The values of the enum.</param>
        /// <param name="input">The input string to convert.</param>
        /// <param name="value">
        ///     The converted enum value if the conversion is successful, otherwise the default value of the enum
        ///     type.
        /// </param>
        /// <returns>True if the conversion is successful, otherwise false.</returns>
        internal static bool TryStringToEnum(Type type, string[] names, Array values, string input, out object value)
        {
            if (TryMatchNames(names, values, input, out value) ||
                TryMatchValues(values, input, out value) ||
                TryHandleDigitOrSignStart(type, input, out value))
            {
                return true;
            }

            value = Activator.CreateInstance(type);
            return false;
        }

        /// <summary>
        ///     Describes whether try match names
        /// </summary>
        /// <param name="names">The names</param>
        /// <param name="values">The values</param>
        /// <param name="input">The input</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool TryMatchNames(string[] names, Array values, string input, out object value)
        {
            int size = names.Length;
            for (int i = 0; i < size; i++)
            {
                if (names[i].EqualsIgnoreCase(input))
                {
                    value = values.GetValue(i);
                    return true;
                }
            }

            value = null;
            return false;
        }

        /// <summary>
        ///     Describes whether try match values
        /// </summary>
        /// <param name="values">The values</param>
        /// <param name="input">The input</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool TryMatchValues(Array values, string input, out object value)
        {
            for (int i = 0; i < values.GetLength(0); i++)
            {
                object valueI = values.GetValue(i);
                if (IsInputNegative(input))
                {
                    if (MatchNegativeInput(input, valueI))
                    {
                        value = valueI;
                        return true;
                    }
                }
                else
                {
                    if (MatchPositiveInput(input, valueI))
                    {
                        value = valueI;
                        return true;
                    }
                }
            }

            value = null;
            return false;
        }

        /// <summary>
        ///     Describes whether is input negative
        /// </summary>
        /// <param name="input">The input</param>
        /// <returns>The bool</returns>
        internal static bool IsInputNegative(string input) => (input.Length > 0) && (input[0] == '-');

        /// <summary>
        ///     Describes whether match negative input
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="valueI">The value</param>
        /// <returns>The bool</returns>
        internal static bool MatchNegativeInput(string input, object valueI)
        {
            long ul = (long) EnumToUInt64(valueI);
            return ul.ToString().EqualsIgnoreCase(input);
        }

        /// <summary>
        ///     Describes whether match positive input
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="valueI">The value</param>
        /// <returns>The bool</returns>
        internal static bool MatchPositiveInput(string input, object valueI)
        {
            ulong ul = EnumToUInt64(valueI);
            return ul.ToString().EqualsIgnoreCase(input);
        }

        /// <summary>
        ///     Describes whether try handle digit or sign start
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="input">The input</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool TryHandleDigitOrSignStart(Type type, string input, out object value)
        {
            if (!StartsWithDigitOrSign(input))
            {
                value = CreateInstance(type);
                return false;
            }

            return TryConvertToEnumAndAssignValue(type, input, out value);
        }

        /// <summary>
        ///     Tries to convert the input to an enum and assign it to the value.
        /// </summary>
        /// <param name="type">The type to convert to.</param>
        /// <param name="input">The input to convert.</param>
        /// <param name="value">The output value.</param>
        /// <returns>True if the conversion was successful, false otherwise.</returns>
        internal static bool TryConvertToEnumAndAssignValue(Type type, string input, out object value)
        {
            value = ConvertToEnum(type, input);
            if (value == null)
            {
                value = CreateInstance(type);
                return false;
            }

            return true;
        }

        /// <summary>
        ///     Describes whether starts with digit or sign
        /// </summary>
        /// <param name="input">The input</param>
        /// <returns>The bool</returns>
        internal static bool StartsWithDigitOrSign(string input) => char.IsDigit(input[0]) || input[0] == '-' || input[0] == '+';

        /// <summary>
        ///     Creates the instance using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The object</returns>
        internal static object CreateInstance(Type type) => Activator.CreateInstance(type);

        /// <summary>
        ///     Converts the to enum using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="input">The input</param>
        /// <returns>The object</returns>
        internal static object ConvertToEnum(Type type, string input) => EnumToObject(type, input);

        /// <summary>
        ///     Enums the to object using the specified enum type
        /// </summary>
        /// <param name="enumType">The enum type</param>
        /// <param name="value">The value</param>
        /// <returns>The object</returns>
        internal static object EnumToObject(Type enumType, object value)
        {
            if (IsInvalid(enumType, value))
            {
                return null;
            }

            if (value is string stringValue)
            {
                return ParseEnum(enumType, stringValue);
            }

            return ConvertToEnum(enumType, value);
        }

        /// <summary>
        ///     Describes whether is invalid
        /// </summary>
        /// <param name="enumType">The enum type</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool IsInvalid(Type enumType, object value) => enumType == null || value == null || !enumType.IsEnum;

        /// <summary>
        ///     Parses the enum using the specified enum type
        /// </summary>
        /// <param name="enumType">The enum type</param>
        /// <param name="stringValue">The string value</param>
        /// <returns>The object</returns>
        internal static object ParseEnum(Type enumType, string stringValue) => Enum.Parse(enumType, stringValue);

        /// <summary>
        ///     Converts the to enum using the specified enum type
        /// </summary>
        /// <param name="enumType">The enum type</param>
        /// <param name="value">The value</param>
        /// <returns>The object</returns>
        internal static object ConvertToEnum(Type enumType, object value)
        {
            return Type.GetTypeCode(Enum.GetUnderlyingType(enumType)) switch
            {
                TypeCode.Int32 => Enum.ToObject(enumType, ChangeType<int>(value)),
                TypeCode.UInt32 => Enum.ToObject(enumType, ChangeType<uint>(value)),
                TypeCode.Int64 => Enum.ToObject(enumType, ChangeType<long>(value)),
                TypeCode.UInt64 => Enum.ToObject(enumType, ChangeType<ulong>(value)),
                TypeCode.Int16 => Enum.ToObject(enumType, ChangeType<short>(value)),
                TypeCode.UInt16 => Enum.ToObject(enumType, ChangeType<ushort>(value)),
                TypeCode.Byte => Enum.ToObject(enumType, ChangeType<byte>(value)),
                _ => null
            };
        }

        /// <summary>
        ///     Returns the enum using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="enumType">The enum type</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>The value</returns>
        internal static object ToEnum(string text, Type enumType)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException(nameof(enumType));
            }

            EnumTryParse(enumType, text, out object value);
            return value;
        }


        /// <summary>
        ///     Describes whether enum try parse
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="input">The input</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool EnumTryParse(Type type, object input, out object value)
        {
            if (!IsValidInput(type, input))
            {
                value = null;
                return false;
            }

            string stringInput = FormatInput(input);

            if (IsHexadecimalAndCanBeParsed(stringInput, type, out value))
            {
                return true;
            }

            if (!CanGetEnumNamesAndValues(type, out string[] names, out Array values))
            {
                value = null;
                return false;
            }

            return CanParseTokens(stringInput, type, names, values, out value);
        }

        /// <summary>
        ///     Describes whether is valid input
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="input">The input</param>
        /// <returns>The bool</returns>
        internal static bool IsValidInput(Type type, object input) => (type != null) && (input != null);


        /// <summary>
        ///     Describes whether is hexadecimal and can be parsed
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="type">The type</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool IsHexadecimalAndCanBeParsed(string input, Type type, out object value)
        {
            value = null;
            return input.StartsWith("0x") && TryParseHexadecimal(input, type, out value);
        }

        /// <summary>
        ///     Describes whether can get enum names and values
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="names">The names</param>
        /// <param name="values">The values</param>
        /// <returns>The bool</returns>
        internal static bool CanGetEnumNamesAndValues(Type type, out string[] names, out Array values)
        {
            names = new string[] { };
            values = null;
            return type.IsEnum && TryGetEnumNamesAndValues(type, out names, out values);
        }

        /// <summary>
        ///     Describes whether can parse tokens
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="type">The type</param>
        /// <param name="names">The names</param>
        /// <param name="values">The values</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool CanParseTokens(string input, Type type, string[] names, Array values, out object value) => TryParseTokens(input, type, names, values, out value);

        /// <summary>
        ///     Formats the input using the specified input
        /// </summary>
        /// <param name="input">The input</param>
        /// <returns>The string</returns>
        internal static string FormatInput(object input) => string.Format(CultureInfo.InvariantCulture, "{0}", input).Nullify();

        /// <summary>
        ///     Describes whether try parse hexadecimal
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="type">The type</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool TryParseHexadecimal(string input, Type type, out object value)
        {
            if (input.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            {
                if (ulong.TryParse(input.Substring(2), NumberStyles.HexNumber, null, out ulong ulx))
                {
                    value = ToEnum(ulx.ToString(CultureInfo.InvariantCulture), type);
                    return true;
                }
            }

            value = null;
            return false;
        }

        /// <summary>
        ///     Describes whether try get enum names and values
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="names">The names</param>
        /// <param name="values">The values</param>
        /// <returns>The bool</returns>
        internal static bool TryGetEnumNamesAndValues(Type type, out string[] names, out Array values)
        {
            names = Enum.GetNames(type);
            values = Enum.GetValues(type);

            return names.Length != 0;
        }

        /// <summary>
        ///     Describes whether try parse tokens
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="type">The type</param>
        /// <param name="names">The names</param>
        /// <param name="values">The values</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool TryParseTokens(string input, Type type, string[] names, Array values, out object value)
        {
            if (!type.IsDefined(typeof(FlagsAttribute), true) && (input.IndexOfAny(EnumSeparators) < 0))
            {
                return TryStringToEnum(type, names, values, input, out value);
            }

            string[] tokens = input.Split(EnumSeparators, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length == 0)
            {
                value = Activator.CreateInstance(type);
                return false;
            }

            return TryParseTokenValues(tokens, type, names, values, out value);
        }

        /// <summary>
        ///     Describes whether try parse token values
        /// </summary>
        /// <param name="tokens">The tokens</param>
        /// <param name="type">The type</param>
        /// <param name="names">The names</param>
        /// <param name="values">The values</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool TryParseTokenValues(string[] tokens, Type type, string[] names, Array values, out object value)
        {
            ulong parsedValue = 0;

            foreach (string token in tokens)
            {
                if (!TryParseToken(token, type, names, values, out object tokenValue))
                {
                    value = Activator.CreateInstance(type);
                    return false;
                }

                parsedValue |= ConvertTokenValueToUlong(tokenValue);
            }

            value = Enum.ToObject(type, parsedValue);
            return true;
        }

        /// <summary>
        ///     Describes whether try parse token
        /// </summary>
        /// <param name="token">The token</param>
        /// <param name="type">The type</param>
        /// <param name="names">The names</param>
        /// <param name="values">The values</param>
        /// <param name="tokenValue">The token value</param>
        /// <returns>The bool</returns>
        internal static bool TryParseToken(string token, Type type, string[] names, Array values, out object tokenValue)
        {
            string sanitizedToken = SanitizeToken(token);

            if (IsTokenNull(sanitizedToken))
            {
                tokenValue = null;
                return false;
            }

            return TryConvertTokenToEnumValue(type, names, values, sanitizedToken, out tokenValue);
        }

        /// <summary>
        ///     Sanitizes the token using the specified token
        /// </summary>
        /// <param name="token">The token</param>
        /// <returns>The string</returns>
        internal static string SanitizeToken(string token) => token.Nullify();

        /// <summary>
        ///     Describes whether is token null
        /// </summary>
        /// <param name="sanitizedToken">The sanitized token</param>
        /// <returns>The bool</returns>
        internal static bool IsTokenNull(string sanitizedToken) => sanitizedToken == null;

        /// <summary>
        ///     Describes whether try convert token to enum value
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="names">The names</param>
        /// <param name="values">The values</param>
        /// <param name="token">The token</param>
        /// <param name="tokenValue">The token value</param>
        /// <returns>The bool</returns>
        internal static bool TryConvertTokenToEnumValue(Type type, string[] names, Array values, string token, out object tokenValue) => TryStringToEnum(type, names, values, token, out tokenValue);

        /// <summary>
        ///     Converts the token value to ulong using the specified token value
        /// </summary>
        /// <param name="tokenValue">The token value</param>
        /// <returns>The ulong</returns>
        internal static ulong ConvertTokenValueToUlong(object tokenValue)
        {
            switch (Convert.GetTypeCode(tokenValue))
            {
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                    return (ulong) Convert.ToInt64(tokenValue, CultureInfo.InvariantCulture);

                default:
                    return Convert.ToUInt64(tokenValue, CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        ///     Describes whether is generic list
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="elementType">The element type</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>The bool</returns>
        internal static bool IsGenericList(Type type, out Type elementType)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(List<>)))
            {
                elementType = type.GetGenericArguments()[0];
                return true;
            }

            elementType = null;
            return false;
        }

        /// <summary>
        ///     Describes whether is really value type
        /// </summary>
        /// <param name="type">The type</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>The bool</returns>
        internal static bool IsReallyValueType(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return type.IsValueType && !IsNullable(type);
        }

        /// <summary>
        ///     Describes whether is nullable
        /// </summary>
        /// <param name="type">The type</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>The bool</returns>
        internal static bool IsNullable(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
    }
}