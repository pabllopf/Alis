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
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

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
        private static readonly char[] EnumSeparators = {',', ';', '+', '|', ' '};

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
        public static T ChangeType<T>(object input, T defaultValue = default(T), IFormatProvider provider = null)
        {
            return !TryChangeType(input, provider, out T value) ? defaultValue : value;
        }

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
        private static bool TryChangeType<T>(object input, IFormatProvider provider, out T value)
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
                    return def;

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
        [ExcludeFromCodeCoverage]
        private static bool TryChangeType(object input, Type conversionType, IFormatProvider provider, out object value)
        {
            if (conversionType == null)
                throw new ArgumentNullException(nameof(conversionType));

            if (conversionType == typeof(object))
            {
                value = input;
                return true;
            }

            if (IsNullable(conversionType))
            {
                if (input == null)
                {
                    value = null;
                    return true;
                }

                Type type = conversionType.GetGenericArguments()[0];
                if (TryChangeType(input, type, provider, out object vtValue))
                {
                    Type nt = typeof(Nullable<>).MakeGenericType(type);
                    value = Activator.CreateInstance(nt, vtValue);
                    return true;
                }

                value = null;
                return false;
            }

            value = IsReallyValueType(conversionType) ? Activator.CreateInstance(conversionType) : null;
            if (input == null)
                return !IsReallyValueType(conversionType);

            Type inputType = input.GetType();
            if (conversionType.IsAssignableFrom(inputType))
            {
                value = input;
                return true;
            }

            if (conversionType.IsEnum)
                return EnumTryParse(conversionType, input, out value);

            if (inputType.IsEnum)
            {
                TypeCode tc = Type.GetTypeCode(inputType);
                if (conversionType == typeof(int))
                {
                    switch (tc)
                    {
                        case TypeCode.Int32:
                            value = (int) input;
                            return true;

                        case TypeCode.Int16:
                            value = (int) (short) input;
                            return true;

                        case TypeCode.Int64:
                            value = (int) (long) input;
                            return true;

                        case TypeCode.UInt32:
                            value = (int) (uint) input;
                            return true;

                        case TypeCode.UInt16:
                            value = (int) (ushort) input;
                            return true;

                        case TypeCode.UInt64:
                            value = (int) (ulong) input;
                            return true;

                        case TypeCode.Byte:
                            value = (int) (byte) input;
                            return true;

                        case TypeCode.SByte:
                            value = (int) (sbyte) input;
                            return true;
                    }

                    return false;
                }

                if (conversionType == typeof(short))
                {
                    switch (tc)
                    {
                        case TypeCode.Int32:
                            value = (short) (int) input;
                            return true;

                        case TypeCode.Int16:
                            value = (short) input;
                            return true;

                        case TypeCode.Int64:
                            value = (short) (long) input;
                            return true;

                        case TypeCode.UInt32:
                            value = (short) (uint) input;
                            return true;

                        case TypeCode.UInt16:
                            value = (short) (ushort) input;
                            return true;

                        case TypeCode.UInt64:
                            value = (short) (ulong) input;
                            return true;

                        case TypeCode.Byte:
                            value = (short) (byte) input;
                            return true;

                        case TypeCode.SByte:
                            value = (short) (sbyte) input;
                            return true;
                    }

                    return false;
                }

                if (conversionType == typeof(long))
                {
                    switch (tc)
                    {
                        case TypeCode.Int32:
                            value = (long) (int) input;
                            return true;

                        case TypeCode.Int16:
                            value = (long) (short) input;
                            return true;

                        case TypeCode.Int64:
                            value = (long) input;
                            return true;

                        case TypeCode.UInt32:
                            value = (long) (uint) input;
                            return true;

                        case TypeCode.UInt16:
                            value = (long) (ushort) input;
                            return true;

                        case TypeCode.UInt64:
                            value = (long) (ulong) input;
                            return true;

                        case TypeCode.Byte:
                            value = (long) (byte) input;
                            return true;

                        case TypeCode.SByte:
                            value = (long) (sbyte) input;
                            return true;
                    }

                    return false;
                }

                if (conversionType == typeof(uint))
                {
                    switch (tc)
                    {
                        case TypeCode.Int32:
                            value = (uint) (int) input;
                            return true;

                        case TypeCode.Int16:
                            value = (uint) (short) input;
                            return true;

                        case TypeCode.Int64:
                            value = (uint) (long) input;
                            return true;

                        case TypeCode.UInt32:
                            value = (uint) input;
                            return true;

                        case TypeCode.UInt16:
                            value = (uint) (ushort) input;
                            return true;

                        case TypeCode.UInt64:
                            value = (uint) (ulong) input;
                            return true;

                        case TypeCode.Byte:
                            value = (uint) (byte) input;
                            return true;

                        case TypeCode.SByte:
                            value = (uint) (sbyte) input;
                            return true;
                    }

                    return false;
                }

                if (conversionType == typeof(ushort))
                {
                    switch (tc)
                    {
                        case TypeCode.Int32:
                            value = (ushort) (int) input;
                            return true;

                        case TypeCode.Int16:
                            value = (ushort) (short) input;
                            return true;

                        case TypeCode.Int64:
                            value = (ushort) (long) input;
                            return true;

                        case TypeCode.UInt32:
                            value = (ushort) (uint) input;
                            return true;

                        case TypeCode.UInt16:
                            value = (ushort) input;
                            return true;

                        case TypeCode.UInt64:
                            value = (ushort) (ulong) input;
                            return true;

                        case TypeCode.Byte:
                            value = (ushort) (byte) input;
                            return true;

                        case TypeCode.SByte:
                            value = (ushort) (sbyte) input;
                            return true;
                    }

                    return false;
                }

                if (conversionType == typeof(ulong))
                {
                    switch (tc)
                    {
                        case TypeCode.Int32:
                            value = (ulong) (int) input;
                            return true;

                        case TypeCode.Int16:
                            value = (ulong) (short) input;
                            return true;

                        case TypeCode.Int64:
                            value = (ulong) (long) input;
                            return true;

                        case TypeCode.UInt32:
                            value = (ulong) (uint) input;
                            return true;

                        case TypeCode.UInt16:
                            value = (ulong) (ushort) input;
                            return true;

                        case TypeCode.UInt64:
                            value = (ulong) input;
                            return true;

                        case TypeCode.Byte:
                            value = (ulong) (byte) input;
                            return true;

                        case TypeCode.SByte:
                            value = (ulong) (sbyte) input;
                            return true;
                    }

                    return false;
                }

                if (conversionType == typeof(byte))
                {
                    switch (tc)
                    {
                        case TypeCode.Int32:
                            value = (byte) (int) input;
                            return true;

                        case TypeCode.Int16:
                            value = (byte) (short) input;
                            return true;

                        case TypeCode.Int64:
                            value = (byte) (long) input;
                            return true;

                        case TypeCode.UInt32:
                            value = (byte) (uint) input;
                            return true;

                        case TypeCode.UInt16:
                            value = (byte) (ushort) input;
                            return true;

                        case TypeCode.UInt64:
                            value = (byte) (ulong) input;
                            return true;

                        case TypeCode.Byte:
                            value = (byte) input;
                            return true;

                        case TypeCode.SByte:
                            value = (byte) (sbyte) input;
                            return true;
                    }

                    return false;
                }

                if (conversionType == typeof(sbyte))
                {
                    switch (tc)
                    {
                        case TypeCode.Int32:
                            value = (sbyte) (int) input;
                            return true;

                        case TypeCode.Int16:
                            value = (sbyte) (short) input;
                            return true;

                        case TypeCode.Int64:
                            value = (sbyte) (long) input;
                            return true;

                        case TypeCode.UInt32:
                            value = (sbyte) (uint) input;
                            return true;

                        case TypeCode.UInt16:
                            value = (sbyte) (ushort) input;
                            return true;

                        case TypeCode.UInt64:
                            value = (sbyte) (ulong) input;
                            return true;

                        case TypeCode.Byte:
                            value = (sbyte) (byte) input;
                            return true;

                        case TypeCode.SByte:
                            value = (sbyte) input;
                            return true;
                    }

                    return false;
                }
            }

            if (conversionType == typeof(Guid))
            {
                string sValue = string.Format(provider, "{0}", input).Nullify();
                if ((sValue != null) && Guid.TryParse(sValue, out Guid guid))
                {
                    value = guid;
                    return true;
                }

                return false;
            }

            if (conversionType == typeof(Uri))
            {
                string sValue = string.Format(provider, "{0}", input).Nullify();
                if ((sValue != null) && Uri.TryCreate(sValue, UriKind.RelativeOrAbsolute, out Uri uri))
                {
                    value = uri;
                    return true;
                }

                return false;
            }

            if (conversionType == typeof(IntPtr))
            {
                if (IntPtr.Size == 8)
                {
                    if (TryChangeType(input, provider, out long l))
                    {
                        value = new IntPtr(l);
                        return true;
                    }
                }
                else if (TryChangeType(input, provider, out int i))
                {
                    value = new IntPtr(i);
                    return true;
                }

                return false;
            }

            if (conversionType == typeof(int))
            {
                if (inputType == typeof(uint))
                {
                    value = unchecked((int) (uint) input);
                    return true;
                }

                if (inputType == typeof(ulong))
                {
                    value = unchecked((int) (ulong) input);
                    return true;
                }

                if (inputType == typeof(ushort))
                {
                    value = (int) (ushort) input;
                    return true;
                }

                if (inputType == typeof(byte))
                {
                    value = (int) (byte) input;
                    return true;
                }
            }

            if (conversionType == typeof(long))
            {
                if (inputType == typeof(uint))
                {
                    value = (long) (uint) input;
                    return true;
                }

                if (inputType == typeof(ulong))
                {
                    value = unchecked((long) (ulong) input);
                    return true;
                }

                if (inputType == typeof(ushort))
                {
                    value = (long) (ushort) input;
                    return true;
                }

                if (inputType == typeof(byte))
                {
                    value = (long) (byte) input;
                    return true;
                }

                if (inputType == typeof(TimeSpan))
                {
                    value = ((TimeSpan) input).Ticks;
                    return true;
                }
            }

            if (conversionType == typeof(short))
            {
                if (inputType == typeof(uint))
                {
                    value = unchecked((short) (uint) input);
                    return true;
                }

                if (inputType == typeof(ulong))
                {
                    value = unchecked((short) (ulong) input);
                    return true;
                }

                if (inputType == typeof(ushort))
                {
                    value = unchecked((short) (ushort) input);
                    return true;
                }

                if (inputType == typeof(byte))
                {
                    value = (short) (byte) input;
                    return true;
                }
            }

            if (conversionType == typeof(sbyte))
            {
                if (inputType == typeof(uint))
                {
                    value = unchecked((sbyte) (uint) input);
                    return true;
                }

                if (inputType == typeof(ulong))
                {
                    value = unchecked((sbyte) (ulong) input);
                    return true;
                }

                if (inputType == typeof(ushort))
                {
                    value = unchecked((sbyte) (ushort) input);
                    return true;
                }

                if (inputType == typeof(byte))
                {
                    value = unchecked((sbyte) (byte) input);
                    return true;
                }
            }

            if (conversionType == typeof(uint))
            {
                if (inputType == typeof(int))
                {
                    value = unchecked((uint) (int) input);
                    return true;
                }

                if (inputType == typeof(long))
                {
                    value = unchecked((uint) (long) input);
                    return true;
                }

                if (inputType == typeof(short))
                {
                    value = unchecked((uint) (short) input);
                    return true;
                }

                if (inputType == typeof(sbyte))
                {
                    value = unchecked((uint) (sbyte) input);
                    return true;
                }
            }

            if (conversionType == typeof(ulong))
            {
                if (inputType == typeof(int))
                {
                    value = unchecked((ulong) (int) input);
                    return true;
                }

                if (inputType == typeof(long))
                {
                    value = unchecked((ulong) (long) input);
                    return true;
                }

                if (inputType == typeof(short))
                {
                    value = unchecked((ulong) (short) input);
                    return true;
                }

                if (inputType == typeof(sbyte))
                {
                    value = unchecked((ulong) (sbyte) input);
                    return true;
                }
            }

            if (conversionType == typeof(ushort))
            {
                if (inputType == typeof(int))
                {
                    value = unchecked((ushort) (int) input);
                    return true;
                }

                if (inputType == typeof(long))
                {
                    value = unchecked((ushort) (long) input);
                    return true;
                }

                if (inputType == typeof(short))
                {
                    value = unchecked((ushort) (short) input);
                    return true;
                }

                if (inputType == typeof(sbyte))
                {
                    value = unchecked((ushort) (sbyte) input);
                    return true;
                }
            }

            if (conversionType == typeof(byte))
            {
                if (inputType == typeof(int))
                {
                    value = unchecked((byte) (int) input);
                    return true;
                }

                if (inputType == typeof(long))
                {
                    value = unchecked((byte) (long) input);
                    return true;
                }

                if (inputType == typeof(short))
                {
                    value = unchecked((byte) (short) input);
                    return true;
                }

                if (inputType == typeof(sbyte))
                {
                    value = unchecked((byte) (sbyte) input);
                    return true;
                }
            }

            if (conversionType == typeof(DateTime))
            {
                if (inputType == typeof(long))
                {
                    value = new DateTime((long) input, DateTimeKind.Utc);
                    return true;
                }

                if (inputType == typeof(DateTimeOffset))
                {
                    value = ((DateTimeOffset) input).DateTime;
                    return true;
                }
            }

            if (conversionType == typeof(DateTimeOffset))
            {
                if (inputType == typeof(long))
                {
                    value = new DateTimeOffset(new DateTime((long) input, DateTimeKind.Utc));
                    return true;
                }

                if (inputType == typeof(DateTime))
                {
                    DateTime dt = (DateTime) input;
                    if (IsValid(dt))
                    {
                        value = new DateTimeOffset((DateTime) input);
                        return true;
                    }
                }
            }

            if (conversionType == typeof(TimeSpan))
            {
                if (inputType == typeof(long))
                {
                    value = new TimeSpan((long) input);
                    return true;
                }

                if (inputType == typeof(DateTime))
                {
                    if (value != null)
                    {
                        value = ((DateTime) value).TimeOfDay;
                    }

                    return true;
                }

                if (inputType == typeof(DateTimeOffset))
                {
                    if (value != null)
                    {
                        value = ((DateTimeOffset) value).TimeOfDay;
                    }

                    return true;
                }

                if (TryChangeType(input, provider, out string sv) && TimeSpan.TryParse(sv, provider, out TimeSpan ts))
                {
                    value = ts;
                    return true;
                }
            }

            bool isGenericList = IsGenericList(conversionType, out Type elementType);
            if (conversionType.IsArray || isGenericList)
            {
                if (input is IEnumerable enumerable)
                {
                    if (!isGenericList)
                    {
                        elementType = conversionType.GetElementType();
                    }

                    IList list = (IList) Activator.CreateInstance(typeof(List<>).MakeGenericType(elementType));
                    int count = 0;
                    foreach (object obj in enumerable)
                    {
                        count++;
                        if (TryChangeType(obj, elementType, provider, out object element))
                        {
                            list.Add(element);
                        }
                    }

                    // at least one was converted
                    if ((count > 0) && (list.Count > 0))
                    {
                        value = isGenericList ? list : list.GetType().GetMethod(nameof(List<object>.ToArray))?.Invoke(list, null);

                        return true;
                    }
                }
            }

            if (conversionType == typeof(CultureInfo) || conversionType == typeof(IFormatProvider))
            {
                try
                {
                    if (input is int lcid)
                    {
                        value = CultureInfo.GetCultureInfo(lcid);
                        return true;
                    }

                    string si = input.ToString();
                    if (si != null)
                    {
                        if (int.TryParse(si, out lcid))
                        {
                            value = CultureInfo.GetCultureInfo(lcid);
                            return true;
                        }

                        value = CultureInfo.GetCultureInfo(si);
                        return true;
                    }
                }
                catch
                {
                    // do nothing, wrong culture, etc.
                }

                return false;
            }

            if (conversionType == typeof(bool))
            {
                switch (input)
                {
                    case true:
                        value = true;
                        return true;
                    case false:
                        value = false;
                        return true;
                }

                string sValue = string.Format(provider, "{0}", input).Nullify();
                if (sValue == null)
                    return false;

                if (bool.TryParse(sValue, out bool b))
                {
                    value = b;
                    return true;
                }

                if (sValue.EqualsIgnoreCase("y") || sValue.EqualsIgnoreCase("yes"))
                {
                    value = true;
                    return true;
                }

                if (sValue.EqualsIgnoreCase("n") || sValue.EqualsIgnoreCase("no"))
                {
                    value = false;
                    return true;
                }

                if (TryChangeType(input, out long bl))
                {
                    value = bl != 0;
                    return true;
                }

                return false;
            }

            // in general, nothing is convertible to anything but one of these, IConvertible is 100% stupid thing
            bool IsWellKnownConvertible() => conversionType == typeof(short) || conversionType == typeof(int) ||
                                             conversionType == typeof(string) || conversionType == typeof(byte) ||
                                             conversionType == typeof(char) || conversionType == typeof(DateTime) ||
                                             conversionType == typeof(DBNull) || conversionType == typeof(decimal) ||
                                             conversionType == typeof(double) || conversionType.IsEnum ||
                                             conversionType == typeof(short) || conversionType == typeof(int) ||
                                             conversionType == typeof(long) || conversionType == typeof(sbyte) ||
                                             conversionType == typeof(bool) || conversionType == typeof(float) ||
                                             conversionType == typeof(ushort) || conversionType == typeof(uint) ||
                                             conversionType == typeof(ulong);

            if (IsWellKnownConvertible() && input is IConvertible convertible)
            {
                try
                {
                    value = convertible.ToType(conversionType, provider);
                    if (value is DateTime dt && !IsValid(dt))
                        return false;

                    return true;
                }
                catch
                {
                    // continue;
                }
            }

            TypeConverter inputConverter = TypeDescriptor.GetConverter(input);
            if (inputConverter.CanConvertTo(conversionType))
                try
                {
                    value = inputConverter.ConvertTo(null, provider as CultureInfo, input, conversionType);
                    return true;
                }
                catch
                {
                    // continue;
                }

            TypeConverter converter = TypeDescriptor.GetConverter(conversionType);
            if (converter != null)
            {
                if (converter.CanConvertTo(conversionType))
                {
                    try
                    {
                        value = converter.ConvertTo(null, provider as CultureInfo, input, conversionType);
                        return true;
                    }
                    catch
                    {
                        // continue;
                    }
                }

                if (converter.CanConvertFrom(inputType))
                {
                    try
                    {
                        value = converter.ConvertFrom(null, provider as CultureInfo, input);
                        return true;
                    }
                    catch
                    {
                        // continue;
                    }
                }
            }

            if (conversionType == typeof(string))
            {
                value = string.Format(provider, "{0}", input);
                return true;
            }

            return false;
        }

        /// <summary>
        ///     Enums the to u int 64 using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>The ulong</returns>
        internal static ulong EnumToUInt64(object value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

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
        ///     Describes whether string to enum
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="names">The names</param>
        /// <param name="values">The values</param>
        /// <param name="input">The input</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        [ExcludeFromCodeCoverage]
        internal static bool StringToEnum(Type type, string[] names, Array values, string input, out object value)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].EqualsIgnoreCase(input))
                {
                    value = values.GetValue(i);
                    return true;
                }
            }

            for (int i = 0; i < values.GetLength(0); i++)
            {
                object valueI = values.GetValue(i);
                if ((input.Length > 0) && (input[0] == '-'))
                {
                    long ul = (long) EnumToUInt64(valueI);
                    if (ul.ToString().EqualsIgnoreCase(input))
                    {
                        value = valueI;
                        return true;
                    }
                }
                else
                {
                    ulong ul = EnumToUInt64(valueI);
                    if (ul.ToString().EqualsIgnoreCase(input))
                    {
                        value = valueI;
                        return true;
                    }
                }
            }

            if (char.IsDigit(input[0]) || input[0] == '-' || input[0] == '+')
            {
                object obj = EnumToObject(type, input);
                if (obj == null)
                {
                    value = Activator.CreateInstance(type);
                    return false;
                }

                value = obj;
                return true;
            }

            value = Activator.CreateInstance(type);
            return false;
        }

        /// <summary>
        ///     Enums the to object using the specified enum type
        /// </summary>
        /// <param name="enumType">The enum type</param>
        /// <param name="value">The value</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException">null </exception>
        /// <exception cref="ArgumentException">null </exception>
        /// <returns>The object</returns>
        [ExcludeFromCodeCoverage]
        internal static object EnumToObject(Type enumType, object value)
        {
            if (enumType == null)
                throw new ArgumentNullException(nameof(enumType));

            if (!enumType.IsEnum)
                throw new ArgumentException(null, nameof(enumType));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            Type underlyingType = Enum.GetUnderlyingType(enumType);
            if (underlyingType == typeof(long))
                return Enum.ToObject(enumType, ChangeType<long>(value));

            if (underlyingType == typeof(ulong))
                return Enum.ToObject(enumType, ChangeType<ulong>(value));

            if (underlyingType == typeof(int))
                return Enum.ToObject(enumType, ChangeType<int>(value));

            if (underlyingType == typeof(uint))
                return Enum.ToObject(enumType, ChangeType<uint>(value));

            if (underlyingType == typeof(short))
                return Enum.ToObject(enumType, ChangeType<short>(value));

            if (underlyingType == typeof(ushort))
                return Enum.ToObject(enumType, ChangeType<ushort>(value));

            if (underlyingType == typeof(byte))
                return Enum.ToObject(enumType, ChangeType<byte>(value));

            if (underlyingType == typeof(sbyte))
                return Enum.ToObject(enumType, ChangeType<sbyte>(value));

            throw new ArgumentException(null, nameof(enumType));
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
                throw new ArgumentNullException(nameof(enumType));

            EnumTryParse(enumType, text, out object value);
            return value;
        }

        // Enum.TryParse is not supported by all .NET versions the same way
        /// <summary>
        ///     Describes whether enum try parse
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="input">The input</param>
        /// <param name="value">The value</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException">null </exception>
        /// <returns>The bool</returns>
        [ExcludeFromCodeCoverage]
        internal static bool EnumTryParse(Type type, object input, out object value)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (!type.IsEnum)
                throw new ArgumentException(null, nameof(type));

            if (input == null)
            {
                value = Activator.CreateInstance(type);
                return false;
            }

            string stringInput = string.Format(CultureInfo.InvariantCulture, "{0}", input);
            stringInput = stringInput.Nullify();
            if (stringInput == null)
            {
                value = Activator.CreateInstance(type);
                return false;
            }

            if (stringInput.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            {
                if (ulong.TryParse(stringInput.Substring(2), NumberStyles.HexNumber, null, out ulong ulx))
                {
                    value = ToEnum(ulx.ToString(CultureInfo.InvariantCulture), type);
                    return true;
                }
            }

            string[] names = Enum.GetNames(type);
            if (names.Length == 0)
            {
                value = Activator.CreateInstance(type);
                return false;
            }

            Array values = Enum.GetValues(type);
            // some enums like System.CodeDom.MemberAttributes *are* flags but are not declared with Flags...
            if (!type.IsDefined(typeof(FlagsAttribute), true) && (stringInput.IndexOfAny(EnumSeparators) < 0))
                return StringToEnum(type, names, values, stringInput, out value);

            // multi value enum
            string[] tokens = stringInput.Split(EnumSeparators, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length == 0)
            {
                value = Activator.CreateInstance(type);
                return false;
            }

            ulong ul = 0;
            foreach (string tok in tokens)
            {
                string token = tok.Nullify(); // NOTE: we don't consider empty tokens as errors
                if (token == null)
                    continue;

                if (!StringToEnum(type, names, values, token, out object tokenValue))
                {
                    value = Activator.CreateInstance(type);
                    return false;
                }

                ulong tokenUl;
#pragma warning disable IDE0010 // Add missing cases
#pragma warning disable IDE0066 // Convert switch statement to expression
                switch (Convert.GetTypeCode(tokenValue))
#pragma warning restore IDE0066 // Convert switch statement to expression
#pragma warning restore IDE0010 // Add missing cases
                {
                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                    case TypeCode.SByte:
                        tokenUl = (ulong) Convert.ToInt64(tokenValue, CultureInfo.InvariantCulture);
                        break;

                    default:
                        tokenUl = Convert.ToUInt64(tokenValue, CultureInfo.InvariantCulture);
                        break;
                }

                ul |= tokenUl;
            }

            value = Enum.ToObject(type, ul);
            return true;
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
                throw new ArgumentNullException(nameof(type));

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
                throw new ArgumentNullException(nameof(type));

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
                throw new ArgumentNullException(nameof(type));

            return type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
    }
}