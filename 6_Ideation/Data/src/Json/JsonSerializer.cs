// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JsonSerializer.cs
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
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     A utility class to serialize and deserialize JSON.
    /// </summary>
    public static class JsonSerializer
    {
        /// <summary>
        ///     The null
        /// </summary>
        private const string Null = "null";

        /// <summary>
        ///     The true
        /// </summary>
        private const string True = "true";

        /// <summary>
        ///     The false
        /// </summary>
        private const string False = "false";

        /// <summary>
        ///     The zero arg
        /// </summary>
        private const string ZeroArg = "{0}";

        /// <summary>
        ///     The date start js
        /// </summary>
        private const string DateStartJs = "new Date(";

        /// <summary>
        ///     The date end js
        /// </summary>
        private const string DateEndJs = ")";

        /// <summary>
        ///     The date start
        /// </summary>
        private const string DateStart = @"""\/Date(";

        /// <summary>
        ///     The date start
        /// </summary>
        private const string DateStart2 = @"/Date(";

        /// <summary>
        ///     The date end
        /// </summary>
        private const string DateEnd = @")\/""";

        /// <summary>
        ///     The date end
        /// </summary>
        private const string DateEnd2 = @")/";

        /// <summary>
        ///     The round trip format
        /// </summary>
        private const string RoundTripFormat = "R";

        /// <summary>
        ///     The enum format
        /// </summary>
        private const string EnumFormat = "D";

        /// <summary>
        ///     The format
        /// </summary>
        private const string X4Format = "{0:X4}";

        /// <summary>
        ///     The format
        /// </summary>
        private const string D2Format = "D2";

        /// <summary>
        ///     The script ignore
        /// </summary>
        private const string ScriptIgnore = "ScriptIgnore";

        /// <summary>
        ///     The serialization type token
        /// </summary>
        private const string SerializationTypeToken = "__type";

        /// <summary>
        ///     The date formats utc
        /// </summary>
        private static readonly string[] DateFormatsUtc = {@"yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'", "yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'", "yyyy'-'MM'-'dd'T'HH':'mm'Z'", "yyyyMMdd'T'HH':'mm':'ss'Z'"};

        /// <summary>
        ///     The utc
        /// </summary>
        private static readonly DateTime MinDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        ///     The ticks
        /// </summary>
        private static readonly long MinDateTimeTicks = MinDateTime.Ticks;

        /// <summary>
        ///     The formatter converter
        /// </summary>
        private static readonly FormatterConverter DefaultFormatterConverter = new FormatterConverter();

        /// <summary>
        ///     Serializes the specified object. Supports anonymous and dynamic types.
        /// </summary>
        /// <param name="value">The object to serialize.</param>
        /// <param name="options">Options to use for serialization.</param>
        /// <returns>
        ///     A JSON representation of the serialized object.
        /// </returns>
        public static string Serialize(object value, JsonOptions options = null)
        {
            using StringWriter writer = new StringWriter();
            Serialize(writer, value, options);
            return writer.ToString();
        }

        /// <summary>
        ///     Serializes the specified object to the specified TextWriter. Supports anonymous and dynamic types.
        /// </summary>
        /// <param name="writer">The output writer. May not be null.</param>
        /// <param name="value">The object to serialize.</param>
        /// <param name="options">Options to use for serialization.</param>
        private static void Serialize(TextWriter writer, object value, JsonOptions options = null)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            options = options ?? new JsonOptions();
            IDictionary<object, object> objectGraph = options.FinalObjectGraph;
            SetOptions(objectGraph, options);

            string jsonp = options.JsonPCallback.Nullify();
            if (jsonp != null)
            {
                writer.Write(options.JsonPCallback);
                writer.Write('(');
            }

            WriteValue(writer, value, objectGraph, options);
            if (jsonp != null)
            {
                writer.Write(')');
                writer.Write(';');
            }
        }

        /// <summary>
        ///     Deserializes an object from the specified text.
        /// </summary>
        /// <param name="text">The text text.</param>
        /// <param name="targetType">The required target type.</param>
        /// <param name="options">Options to use for deserialization.</param>
        /// <returns>
        ///     An instance of an object representing the input data.
        /// </returns>
        public static object Deserialize(string text, Type targetType = null, JsonOptions options = null)
        {
            if (text == null)
            {
                if (targetType == null)
                    return null;

                return !targetType.IsValueType ? null : CreateInstance(null, targetType, 0, options, null);
            }

            using StringReader reader = new StringReader(text);
            return Deserialize(reader, targetType, options);
        }

        /// <summary>
        ///     Deserializes an object from the specified TextReader.
        /// </summary>
        /// <typeparam name="T">The target type.</typeparam>
        /// <param name="reader">The input reader. May not be null.</param>
        /// <param name="options">Options to use for deserialization.</param>
        /// <returns>
        ///     An instance of an object representing the input data.
        /// </returns>
        public static T Deserialize<T>(TextReader reader, JsonOptions options = null) => (T) Deserialize(reader, typeof(T), options);

        /// <summary>
        ///     Deserializes an object from the specified TextReader.
        /// </summary>
        /// <typeparam name="T">The target type.</typeparam>
        /// <param name="text">The text to deserialize.</param>
        /// <param name="options">Options to use for deserialization.</param>
        /// <returns>
        ///     An instance of an object representing the input data.
        /// </returns>
        public static T Deserialize<T>(string text, JsonOptions options = null) => (T) Deserialize(text, typeof(T), options);

        /// <summary>
        ///     Deserializes an object from the specified TextReader.
        /// </summary>
        /// <param name="reader">The input reader. May not be null.</param>
        /// <param name="targetType">The required target type.</param>
        /// <param name="options">Options to use for deserialization.</param>
        /// <returns>
        ///     An instance of an object representing the input data.
        /// </returns>
        private static object Deserialize(TextReader reader, Type targetType = null, JsonOptions options = null)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            options = options ?? new JsonOptions();
            if (targetType == null || targetType == typeof(object))
                return ReadValue(reader, options);

            object value = ReadValue(reader, options);
            if (value == null)
            {
                return targetType.IsValueType ? CreateInstance(null, targetType, 0, options, null) : null;
            }

            return ChangeType(null, value, targetType, options);
        }

        /// <summary>
        ///     Deserializes data from the specified text and populates a specified object instance.
        /// </summary>
        /// <param name="text">The text to deserialize.</param>
        /// <param name="target">The object instance to populate.</param>
        /// <param name="options">Options to use for deserialization.</param>
        public static void DeserializeToTarget(string text, object target, JsonOptions options = null)
        {
            if (text == null)
                return;

            using StringReader reader = new StringReader(text);
            DeserializeToTarget(reader, target, options);
        }

        /// <summary>
        ///     Deserializes data from the specified TextReader and populates a specified object instance.
        /// </summary>
        /// <param name="reader">The input reader. May not be null.</param>
        /// <param name="target">The object instance to populate.</param>
        /// <param name="options">Options to use for deserialization.</param>
        private static void DeserializeToTarget(TextReader reader, object target, JsonOptions options = null)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if (target == null)
                throw new ArgumentNullException(nameof(target));

            object value = ReadValue(reader, options);
            Apply(value, target, options);
        }

        /// <summary>
        ///     Applies the content of an array or dictionary to a target object.
        /// </summary>
        /// <param name="input">The input object.</param>
        /// <param name="target">The target object.</param>
        /// <param name="options">Options to use.</param>
        private static void Apply(object input, object target, JsonOptions options = null)
        {
            options ??= new JsonOptions();
            if (target is Array {IsReadOnly: false} array)
            {
                Apply(input as IEnumerable, array, options);
                return;
            }

            if (input is IDictionary dic)
            {
                Apply(dic, target, options);
                return;
            }

            if (target != null)
            {
                ListObject lo = GetListObject(target.GetType(), options, target, input, null, null);
                if (lo != null)
                {
                    lo.List = target;
                    ApplyToListTarget(target, input as IEnumerable, lo, options);
                }
            }
        }

        /// <summary>
        ///     Creates the instance using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="type">The type</param>
        /// <param name="elementsCount">The elements count</param>
        /// <param name="options">The options</param>
        /// <param name="value">The value</param>
        /// <returns>The object</returns>
        internal static object CreateInstance(object target, Type type, int elementsCount, JsonOptions options, object value)
        {
            try
            {
                if (options.CreateInstanceCallback != null)
                {
                    Dictionary<object, object> og = new Dictionary<object, object>
                    {
                        ["elementsCount"] = elementsCount,
                        ["value"] = value
                    };

                    JsonEventArgs e = new JsonEventArgs(null, type, og, options, null, target)
                    {
                        EventType = JsonEventType.CreateInstance
                    };
                    options.CreateInstanceCallback(e);
                    if (e.Handled)
                        return e.Value;
                }

                if (type.IsArray)
                {
                    Type elementType = type.GetElementType();
                    if (elementType != null)
                    {
                        return Array.CreateInstance(elementType, elementsCount);
                    }
                }

                return Activator.CreateInstance(type);
            }
            catch (Exception e)
            {
                HandleException(new JsonException("JSO0001: JSON error detected. Cannot create an instance of the '" + type.Name + "' type.", e), options);
                return null;
            }
        }

        /// <summary>
        ///     Gets the list object using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="options">The options</param>
        /// <param name="target">The target</param>
        /// <param name="value">The value</param>
        /// <param name="dictionary">The dictionary</param>
        /// <param name="key">The key</param>
        /// <returns>The list object</returns>
        internal static ListObject GetListObject(Type type, JsonOptions options, object target, object value, IDictionary dictionary, string key)
        {
            if (options.GetListObjectCallback != null)
            {
                Dictionary<object, object> og = new Dictionary<object, object>
                {
                    ["dictionary"] = dictionary,
                    ["type"] = type
                };

                JsonEventArgs e = new JsonEventArgs(null, value, og, options, key, target)
                {
                    EventType = JsonEventType.GetListObject
                };
                options.GetListObjectCallback(e);
                if (e.Handled)
                {
                    og.TryGetValue("type", out object outType);
                    return outType as ListObject;
                }
            }

            if (type == typeof(byte[]))
                return null;

            if (typeof(IList).IsAssignableFrom(type))
                return new CustomListObject(); // also handles arrays

            if (type.IsGenericType)
            {
                if (type.GetGenericTypeDefinition() == typeof(ICollection<>))
                    return (ListObject) Activator.CreateInstance(typeof(CollectionTObject<>).MakeGenericType(type.GetGenericArguments()[0]));
            }

            return (from iFace in type.GetInterfaces() where iFace.IsGenericType where iFace.GetGenericTypeDefinition() == typeof(ICollection<>) select (ListObject) Activator.CreateInstance(typeof(CollectionTObject<>).MakeGenericType(iFace.GetGenericArguments()[0]))).FirstOrDefault();
        }

        /// <summary>
        ///     Applies the to list target using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="input">The input</param>
        /// <param name="list">The list</param>
        /// <param name="options">The options</param>
        internal static void ApplyToListTarget(object target, IEnumerable input, ListObject list, JsonOptions options)
        {
            if (list.List == null)
                return;

            if (list.Context != null)
            {
                list.Context["action"] = "init";
                list.Context["target"] = target;
                list.Context["input"] = input;
                list.Context["options"] = options;
            }

            if (input != null)
            {
                Array array = list.List as Array;
                int max = 0;
                int i = 0;
                if (array != null)
                {
                    i = array.GetLowerBound(0);
                    max = array.GetUpperBound(0);
                }

                Type itemType = GetItemType(list.List.GetType());
                foreach (object value in input)
                {
                    if (array != null)
                    {
                        if (i - 1 == max)
                            break;

                        array.SetValue(ChangeType(target, value, itemType, options), i++);
                    }
                    else
                    {
                        object cValue = ChangeType(target, value, itemType, options);
                        if (list.Context != null)
                        {
                            list.Context["action"] = "add";
                            list.Context["itemType"] = itemType;
                            list.Context["value"] = value;
                            list.Context["cvalue"] = cValue;

                            if (!list.Context.TryGetValue("cvalue", out object newCValue))
                                continue;

                            cValue = newCValue;
                        }

                        list.Add(cValue, options);
                    }
                }
            }
            else
            {
                if (list.Context != null)
                {
                    list.Context["action"] = "clear";
                }

                list.Clear();
            }

            if (list.Context != null)
            {
                list.Context.Clear();
            }
        }

        /// <summary>
        ///     Applies the input
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="target">The target</param>
        /// <param name="options">The options</param>
        private static void Apply(IEnumerable input, Array target, JsonOptions options)
        {
            if (!(target is {Rank: 1}))
                return;

            Type elementType = target.GetType().GetElementType();
            int i = 0;
            if (input != null)
            {
                foreach (object value in input)
                {
                    target.SetValue(ChangeType(target, value, elementType, options), i++);
                }
            }
            else
            {
                Array.Clear(target, 0, target.Length);
            }
        }

        /// <summary>
        ///     Describes whether are values equal
        /// </summary>
        /// <param name="o1">The </param>
        /// <param name="o2">The </param>
        /// <returns>The bool</returns>
        internal static bool AreValuesEqual(object o1, object o2)
        {
            if (ReferenceEquals(o1, o2))
                return true;

            return o1 != null && o1.Equals(o2);
        }

        /// <summary>
        ///     Describes whether try get object default value
        /// </summary>
        /// <param name="att">The att</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        private static bool TryGetObjectDefaultValue(Attribute att, out object value)
        {
            switch (att)
            {
                case JsonAttribute {HasDefaultValue: true} jsa:
                    value = jsa.DefaultValue;
                    return true;
                case DefaultValueAttribute dva:
                    value = dva.Value;
                    return true;
                default:
                    value = null;
                    return false;
            }
        }

        /// <summary>
        ///     Gets the object name using the specified att
        /// </summary>
        /// <param name="att">The att</param>
        /// <returns>The string</returns>
        private static string GetObjectName(Attribute att)
        {
            return att switch
            {
                JsonAttribute jsa when !string.IsNullOrEmpty(jsa.Name) => jsa.Name,
                XmlAttributeAttribute xaa when !string.IsNullOrEmpty(xaa.AttributeName) => xaa.AttributeName,
                XmlElementAttribute xea when !string.IsNullOrEmpty(xea.ElementName) => xea.ElementName,
                _ => null
            };
        }

        /// <summary>
        ///     Describes whether try get object default value
        /// </summary>
        /// <param name="mi">The mi</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool TryGetObjectDefaultValue(MemberInfo mi, out object value)
        {
            object[] objects = mi.GetCustomAttributes(true);
            foreach (Attribute att in objects.Cast<Attribute>())
            {
                if (TryGetObjectDefaultValue(att, out value))
                    return true;
            }

            value = null;
            return false;
        }

        /// <summary>
        ///     Gets the object name using the specified mi
        /// </summary>
        /// <param name="mi">The mi</param>
        /// <param name="defaultName">The default name</param>
        /// <returns>The default name</returns>
        internal static string GetObjectName(MemberInfo mi, string defaultName)
        {
            object[] objects = mi.GetCustomAttributes(true);
            foreach (Attribute att in objects.Cast<Attribute>())
            {
                string name = GetObjectName(att);
                if (name != null)
                    return name;
            }

            return defaultName;
        }

        /// <summary>
        ///     Describes whether try get object default value
        /// </summary>
        /// <param name="pd">The pd</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool TryGetObjectDefaultValue(PropertyDescriptor pd, out object value)
        {
            foreach (Attribute att in pd.Attributes.Cast<Attribute>())
            {
                if (TryGetObjectDefaultValue(att, out value))
                    return true;
            }

            value = null;
            return false;
        }

        /// <summary>
        ///     Gets the object name using the specified pd
        /// </summary>
        /// <param name="pd">The pd</param>
        /// <param name="defaultName">The default name</param>
        /// <returns>The default name</returns>
        internal static string GetObjectName(PropertyDescriptor pd, string defaultName)
        {
            foreach (Attribute att in pd.Attributes.Cast<Attribute>())
            {
                string name = GetObjectName(att);
                if (name != null)
                    return name;
            }

            return defaultName;
        }

        /// <summary>
        ///     Describes whether has script ignore
        /// </summary>
        /// <param name="pd">The pd</param>
        /// <returns>The bool</returns>
        internal static bool HasScriptIgnore(PropertyDescriptor pd)
        {
            return pd.Attributes.Cast<object>().Any(att => att.GetType().Name.StartsWith(ScriptIgnore));
        }

        /// <summary>
        ///     Describes whether has script ignore
        /// </summary>
        /// <param name="mi">The mi</param>
        /// <returns>The bool</returns>
        internal static bool HasScriptIgnore(MemberInfo mi)
        {
            object[] objs = mi.GetCustomAttributes(true);
            if (objs.Length == 0)
                return false;

            foreach (object obj in objs)
            {
                if (!(obj is Attribute att))
                    continue;

                if (att.GetType().Name.StartsWith(ScriptIgnore))
                    return true;
            }

            return false;
        }

        /// <summary>
        ///     Applies the dictionary
        /// </summary>
        /// <param name="dictionary">The dictionary</param>
        /// <param name="target">The target</param>
        /// <param name="options">The options</param>
        internal static void Apply(IDictionary dictionary, object target, JsonOptions options)
        {
            if (dictionary == null || target == null)
                return;

            if (target is IDictionary dicTarget)
            {
                Type itemType = GetItemType(dicTarget.GetType());
                foreach (DictionaryEntry entry in dictionary)
                {
                    if (entry.Key == null)
                        continue;

                    if (itemType == typeof(object))
                    {
                        dicTarget[entry.Key] = entry.Value;
                    }
                    else
                    {
                        dicTarget[entry.Key] = ChangeType(target, entry.Value, itemType, options);
                    }
                }

                return;
            }

            TypeDef def = TypeDef.Get(target.GetType(), options);

            foreach (DictionaryEntry entry in dictionary)
            {
                if (entry.Key == null)
                    continue;

                string entryKey = string.Format(CultureInfo.InvariantCulture, "{0}", entry.Key);
                object entryValue = entry.Value;
                if (options.MapEntryCallback != null)
                {
                    Dictionary<object, object> og = new Dictionary<object, object>
                    {
                        ["dictionary"] = dictionary
                    };

                    JsonEventArgs e = new JsonEventArgs(null, entryValue, og, options, entryKey, target)
                    {
                        EventType = JsonEventType.MapEntry
                    };
                    options.MapEntryCallback(e);
                    if (e.Handled)
                        continue;

                    entryKey = e.Name;
                    entryValue = e.Value;
                }

                def.ApplyEntry(dictionary, target, entryKey, entryValue, options);
            }
        }

        /// <summary>
        ///     Gets the json attribute using the specified pi
        /// </summary>
        /// <param name="pi">The pi</param>
        /// <returns>The json attribute</returns>
        internal static JsonAttribute GetJsonAttribute(MemberInfo pi)
        {
            object[] objs = pi.GetCustomAttributes(true);
            if (objs.Length == 0)
                return null;

            foreach (object obj in objs)
            {
                if (!(obj is Attribute att))
                    continue;

                if (att is JsonAttribute xAtt)
                    return xAtt;
            }

            return null;
        }

        /// <summary>
        ///     Gets the type of elements in a collection type.
        /// </summary>
        /// <param name="collectionType">The collection type.</param>
        /// <returns>The element type or typeof(object) if it was not determined.</returns>
        private static Type GetItemType(Type collectionType)
        {
            if (collectionType == null)
                throw new ArgumentNullException(nameof(collectionType));

            foreach (Type iFace in collectionType.GetInterfaces())
            {
                if (!iFace.IsGenericType)
                    continue;

                if (iFace.GetGenericTypeDefinition() == typeof(IDictionary<,>))
                    return iFace.GetGenericArguments()[1];

                if (iFace.GetGenericTypeDefinition() == typeof(IList<>))
                    return iFace.GetGenericArguments()[0];

                if (iFace.GetGenericTypeDefinition() == typeof(ICollection<>))
                    return iFace.GetGenericArguments()[0];

                if (iFace.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                    return iFace.GetGenericArguments()[0];
            }

            return typeof(object);
        }

        /// <summary>
        ///     Returns a System.Object with a specified type and whose value is equivalent to a specified input object.
        ///     If an error occurs, a computed default value of the target type will be returned.
        /// </summary>
        /// <param name="value">The input object. May be null.</param>
        /// <param name="conversionType">The target type. May not be null.</param>
        /// <param name="options">The options to use.</param>
        /// <returns>
        ///     An object of the target type whose value is equivalent to input value.
        /// </returns>
        public static object ChangeType(object value, Type conversionType, JsonOptions options) => ChangeType(null, value, conversionType, options);

        /// <summary>
        ///     Returns a System.Object with a specified type and whose value is equivalent to a specified input object.
        ///     If an error occurs, a computed default value of the target type will be returned.
        /// </summary>
        /// <param name="target">The target. May be null.</param>
        /// <param name="value">The input object. May be null.</param>
        /// <param name="conversionType">The target type. May not be null.</param>
        /// <param name="options">The options to use.</param>
        /// <returns>
        ///     An object of the target type whose value is equivalent to input value.
        /// </returns>
        public static object ChangeType(object target, object value, Type conversionType, JsonOptions options = null)
        {
            if (conversionType == null)
                throw new ArgumentNullException(nameof(conversionType));

            if (conversionType == typeof(object))
                return value;

            options = options ?? new JsonOptions();
            if (!(value is string))
            {
                if (conversionType.IsArray)
                {
                    if (value is IEnumerable en)
                    {
                        Type elementType = conversionType.GetElementType();
                        List<object> list = new List<object>();
                        foreach (object obj in en)
                        {
                            list.Add(ChangeType(target, obj, elementType, options));
                        }

                        if (elementType != null)
                        {
                            Array array = Array.CreateInstance(elementType, list.Count);
                            Array.Copy(list.ToArray(), array, list.Count);

                            return array;
                        }
                    }
                }

                ListObject lo = GetListObject(conversionType, options, target, value, null, null);
                if (lo != null)
                {
                    if (value is IEnumerable en)
                    {
                        lo.List = CreateInstance(target, conversionType, en is ICollection coll ? coll.Count : 0, options, value);
                        ApplyToListTarget(target, en, lo, options);
                        return lo.List;
                    }
                }
            }

            if (value is IDictionary dic)
            {
                object instance = CreateInstance(target, conversionType, 0, options, value);
                if (instance != null)
                {
                    Apply(dic, instance, options);
                }

                return instance;
            }

            if ((conversionType == typeof(byte[])) && value is string str)
            {
                if (options.SerializationOptions.HasFlag(JsonSerializationOptions.ByteArrayAsBase64))
                {
                    try
                    {
                        return Convert.FromBase64String(str);
                    }
                    catch (Exception e)
                    {
                        HandleException(new JsonException("JSO0013: JSON deserialization error with a base64 array as string.", e), options);
                        return null;
                    }
                }
            }

            if (conversionType == typeof(DateTime))
            {
                if (value is DateTime)
                    return value;

                string sValue = string.Format(CultureInfo.InvariantCulture, "{0}", value);
                if (!string.IsNullOrEmpty(sValue))
                {
                    if (TryParseDateTime(sValue, options.DateTimeStyles, out DateTime dt))
                        return dt;
                }
            }

            if (conversionType == typeof(TimeSpan))
            {
                string sValue = string.Format(CultureInfo.InvariantCulture, "{0}", value);
                if (!string.IsNullOrEmpty(sValue))
                {
                    if (long.TryParse(sValue, out long ticks))
                        return new TimeSpan(ticks);
                }
            }

            return Conversions.ChangeType(value, conversionType, null, null);
        }

        /// <summary>
        ///     Reads the array using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <returns>The object array</returns>
        private static object[] ReadArray(TextReader reader, JsonOptions options)
        {
            if (!ReadWhitespaces(reader))
                return null;

            reader.Read();
            List<object> list = new List<object>();
            do
            {
                object value = ReadValue(reader, options, true, out bool arrayEnd);
                if (!Convert.IsDBNull(value))
                {
                    list.Add(value);
                }

                if (arrayEnd)
                    return list.ToArray();

                if (reader.Peek() < 0)
                {
                    HandleException(GetExpectedCharacterException(GetPosition(reader), ']'), options);
                    return list.ToArray();
                }
            } while (true);
        }

        /// <summary>
        ///     Gets the expected character exception using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="c">The </param>
        /// <returns>The json exception</returns>
        private static JsonException GetExpectedCharacterException(long pos, char c)
        {
            return pos < 0 ? new JsonException("JSO0002: JSON deserialization error detected. Expecting '" + c + "' character.") : new JsonException("JSO0003: JSON deserialization error detected at position " + pos + ". Expecting '" + c + "' character.");
        }

        /// <summary>
        ///     Gets the unexpected character exception using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="c">The </param>
        /// <returns>The json exception</returns>
        private static JsonException GetUnexpectedCharacterException(long pos, char c)
        {
            return pos < 0 ? new JsonException("JSO0004: JSON deserialization error detected. Unexpected '" + c + "' character.") : new JsonException("JSO0005: JSON deserialization error detected at position " + pos + ". Unexpected '" + c + "' character.");
        }

        /// <summary>
        ///     Gets the expected hex character exception using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <returns>The json exception</returns>
        private static JsonException GetExpectedHexCharacterException(long pos)
        {
            return pos < 0 ? new JsonException("JSO0006: JSON deserialization error detected. Expecting hexadecimal character.") : new JsonException("JSO0007: JSON deserialization error detected at position " + pos + ". Expecting hexadecimal character.");
        }

        /// <summary>
        ///     Gets the type exception using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="typeName">The type name</param>
        /// <param name="inner">The inner</param>
        /// <returns>The json exception</returns>
        private static JsonException GetTypeException(long pos, string typeName, Exception inner)
        {
            return pos < 0 ? new JsonException("JSO0010: JSON deserialization error detected for '" + typeName + "' type.", inner) : new JsonException("JSO0011: JSON deserialization error detected for '" + typeName + "' type at position " + pos + ".", inner);
        }

        /// <summary>
        ///     Gets the eof exception using the specified c
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The json exception</returns>
        private static JsonException GetEofException(char c) => new JsonException("JSO0012: JSON deserialization error detected at end of text. Expecting '" + c + "' character.");

        /// <summary>
        ///     Gets the position using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <returns>The long</returns>
        private static long GetPosition(TextReader reader)
        {
            switch (reader)
            {
                case null:
                    return -1;
                case StreamReader sr:
                    try
                    {
                        return sr.BaseStream.Position;
                    }
                    catch
                    {
                        return -1;
                    }

                case StringReader str:
                {
                    FieldInfo fi = typeof(StringReader).GetField("_pos", BindingFlags.Instance | BindingFlags.NonPublic);
                    if (fi != null)
                        return (int) fi.GetValue(str);
                    break;
                }
            }

            return -1;
        }

        /// <summary>
        ///     Reads the dictionary using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <returns>A dictionary of string and object</returns>
        private static Dictionary<string, object> ReadDictionary(TextReader reader, JsonOptions options)
        {
            if (!ReadWhitespaces(reader))
                return null;

            reader.Read();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            do
            {
                int i = reader.Peek();
                if (i < 0)
                {
                    HandleException(GetEofException('}'), options);
                    return dictionary;
                }

                char c = (char) reader.Read();
                switch (c)
                {
                    case '}':
                        return dictionary;

                    case '"':
                        string text = ReadString(reader, options);
                        if (!ReadWhitespaces(reader))
                        {
                            HandleException(GetExpectedCharacterException(GetPosition(reader), ':'), options);
                            return dictionary;
                        }

                        c = (char) reader.Peek();
                        if (c != ':')
                        {
                            HandleException(GetExpectedCharacterException(GetPosition(reader), ':'), options);
                            return dictionary;
                        }

                        reader.Read();
                        dictionary[text] = ReadValue(reader, options);
                        break;

                    case ',':
                        break;

                    case '\r':
                    case '\n':
                    case '\t':
                    case ' ':
                        break;

                    default:
                        HandleException(GetUnexpectedCharacterException(GetPosition(reader), c), options);
                        return dictionary;
                }
            } while (true);
        }

        /// <summary>
        ///     Reads the string using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <returns>The string</returns>
        private static string ReadString(TextReader reader, JsonOptions options)
        {
            StringBuilder sb = new StringBuilder();
            do
            {
                int i = reader.Peek();
                if (i < 0)
                {
                    HandleException(GetEofException('"'), options);
                    return null;
                }

                char c = (char) reader.Read();
                if (c == '"')
                    break;

                if (c == '\\')
                {
                    i = reader.Peek();
                    if (i < 0)
                    {
                        HandleException(GetEofException('"'), options);
                        return null;
                    }

                    char next = (char) reader.Read();
                    switch (next)
                    {
                        case 'b':
                            sb.Append('\b');
                            break;

                        case 't':
                            sb.Append('\t');
                            break;

                        case 'n':
                            sb.Append('\n');
                            break;

                        case 'f':
                            sb.Append('\f');
                            break;

                        case 'r':
                            sb.Append('\r');
                            break;

                        case '/':
                        case '\\':
                        case '"':
                            sb.Append(next);
                            break;

                        case 'u': // unicode
                            ushort us = ReadX4(reader, options);
                            sb.Append((char) us);
                            break;

                        default:
                            sb.Append(c);
                            sb.Append(next);
                            break;
                    }
                }
                else
                {
                    sb.Append(c);
                }
            } while (true);

            return sb.ToString();
        }

        /// <summary>
        ///     Reads the serializable using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <param name="typeName">The type name</param>
        /// <param name="values">The values</param>
        /// <returns>The serializable</returns>
        private static ISerializable ReadSerializable(TextReader reader, JsonOptions options, string typeName, Dictionary<string, object> values)
        {
            Type type;
            try
            {
                type = Type.GetType(typeName, true);
            }
            catch (Exception e)
            {
                HandleException(GetTypeException(GetPosition(reader), typeName, e), options);
                return null;
            }

            ConstructorInfo ctor = type.GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new[] {typeof(SerializationInfo), typeof(StreamingContext)}, null);
            SerializationInfo info = new SerializationInfo(type, DefaultFormatterConverter);

            foreach (KeyValuePair<string, object> kvp in values)
            {
                info.AddValue(kvp.Key, kvp.Value);
            }

            StreamingContext ctx = new StreamingContext(StreamingContextStates.Remoting, null);
            try
            {
                return (ISerializable) ctor?.Invoke(new object[] {info, ctx});
            }
            catch (Exception e)
            {
                HandleException(GetTypeException(GetPosition(reader), typeName, e), options);
                return null;
            }
        }

        /// <summary>
        ///     Reads the value using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <returns>The object</returns>
        private static object ReadValue(TextReader reader, JsonOptions options) => ReadValue(reader, options, false, out bool _);

        /// <summary>
        ///     Reads the value using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <param name="arrayMode">The array mode</param>
        /// <param name="arrayEnd">The array end</param>
        /// <returns>The object</returns>
        private static object ReadValue(TextReader reader, JsonOptions options, bool arrayMode, out bool arrayEnd)
        {
            arrayEnd = false;
            // 1st chance type is determined by format
            int i;
            do
            {
                i = reader.Peek();
                if (i < 0)
                    return null;

                if (i == 10 || i == 13 || i == 9 || i == 32)
                {
                    reader.Read();
                }
                else
                    break;
            } while (true);

            char c = (char) i;
            if (c == '"')
            {
                reader.Read();
                string s = ReadString(reader, options);
                if (options.SerializationOptions.HasFlag(JsonSerializationOptions.AutoParseDateTime))
                {
                    if (TryParseDateTime(s, options.DateTimeStyles, out DateTime dt))
                        return dt;
                }

                return s;
            }

            if (c == '{')
            {
                Dictionary<string, object> dic = ReadDictionary(reader, options);
                if (options.SerializationOptions.HasFlag(JsonSerializationOptions.UseISerializable))
                {
                    if (dic.TryGetValue(SerializationTypeToken, out object o))
                    {
                        string typeName = string.Format(CultureInfo.InvariantCulture, "{0}", o);
                        if (!string.IsNullOrEmpty(typeName))
                        {
                            dic.Remove(SerializationTypeToken);
                            return ReadSerializable(reader, options, typeName, dic);
                        }
                    }
                }

                return dic;
            }

            if (c == '[')
                return ReadArray(reader, options);

            if (c == 'n')
                return ReadNew(reader, options, out arrayEnd);

            // handles the null/true/false cases
            if (char.IsLetterOrDigit(c) || c == '.' || c == '-' || c == '+')
                return ReadNumberOrLiteral(reader, options, out arrayEnd);

            if (arrayMode && (c == ']'))
            {
                reader.Read();
                arrayEnd = true;
                return DBNull.Value; // marks array end
            }

            if (arrayMode && (c == ','))
            {
                reader.Read();
                return DBNull.Value; // marks array end
            }

            HandleException(GetUnexpectedCharacterException(GetPosition(reader), c), options);
            return null;
        }

        /// <summary>
        ///     Reads the new using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <param name="arrayEnd">The array end</param>
        /// <returns>The object</returns>
        private static object ReadNew(TextReader reader, JsonOptions options, out bool arrayEnd)
        {
            arrayEnd = false;
            StringBuilder sb = new StringBuilder();
            do
            {
                int i = reader.Peek();
                if (i < 0)
                    break;

                if ((char) i == '}')
                    break;

                char c = (char) reader.Read();
                if (c == ',')
                    break;

                if (c == ']')
                {
                    arrayEnd = true;
                    break;
                }

                sb.Append(c);
            } while (true);

            string text = sb.ToString();
            if (string.Compare(Null, text.Trim(), StringComparison.OrdinalIgnoreCase) == 0)
                return null;

            if (text.StartsWith(DateStartJs) && text.EndsWith(DateEndJs))
            {
                if (long.TryParse(text.Substring(DateStartJs.Length, text.Length - DateStartJs.Length - DateEndJs.Length), out long l))
                    return new DateTime(l * 10000 + MinDateTimeTicks, DateTimeKind.Utc);
            }

            HandleException(GetUnexpectedCharacterException(GetPosition(reader), text[0]), options);
            return null;
        }

        /// <summary>
        ///     Reads the number or literal using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <param name="arrayEnd">The array end</param>
        /// <returns>The object</returns>
        private static object ReadNumberOrLiteral(TextReader reader, JsonOptions options, out bool arrayEnd)
        {
            arrayEnd = false;
            StringBuilder sb = new StringBuilder();
            do
            {
                int i = reader.Peek();
                if (i < 0)
                    break;

                if ((char) i == '}')
                    break;

                char c = (char) reader.Read();
                if (char.IsWhiteSpace(c) || c == ',')
                    break;

                if (c == ']')
                {
                    arrayEnd = true;
                    break;
                }

                sb.Append(c);
            } while (true);

            string text = sb.ToString();
            if (string.Compare(Null, text, StringComparison.OrdinalIgnoreCase) == 0)
                return null;

            if (string.Compare(True, text, StringComparison.OrdinalIgnoreCase) == 0)
                return true;

            if (string.Compare(False, text, StringComparison.OrdinalIgnoreCase) == 0)
                return false;

            if (text.LastIndexOf("e", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                if (double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out double d))
                    return d;
            }
            else
            {
                if (text.IndexOf(".", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    if (decimal.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal de))
                        return de;
                }
                else
                {
                    if (int.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out int i))
                        return i;

                    if (long.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out long l))
                        return l;

                    if (decimal.TryParse(text, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal de))
                        return de;
                }
            }

            HandleException(GetUnexpectedCharacterException(GetPosition(reader), text[0]), options);
            return null;
        }

        /// <summary>
        ///     Converts the JSON string representation of a date time to its DateTime equivalent.
        /// </summary>
        /// <param name="text">The input text.</param>
        /// <returns>A DateTime value if the text was converted successfully; otherwise, null.</returns>
        public static DateTime? TryParseDateTime(string text)
        {
            if (!TryParseDateTime(text, out DateTime dt))
                return null;

            return dt;
        }

        /// <summary>
        ///     Converts the JSON string representation of a date time to its DateTime equivalent.
        /// </summary>
        /// <param name="text">The input text.</param>
        /// <param name="styles">The styles to use.</param>
        /// <returns>A DateTime value if the text was converted successfully; otherwise, null.</returns>
        public static DateTime? TryParseDateTime(string text, DateTimeStyles styles)
        {
            if (!TryParseDateTime(text, styles, out DateTime dt))
                return null;

            return dt;
        }

        /// <summary>
        ///     Converts the JSON string representation of a date time to its DateTime equivalent.
        /// </summary>
        /// <param name="text">The input text.</param>
        /// <param name="dt">When this method returns, contains the DateTime equivalent.</param>
        /// <returns>true if the text was converted successfully; otherwise, false.</returns>
        private static bool TryParseDateTime(string text, out DateTime dt) => TryParseDateTime(text, JsonOptions.DefaultDateTimeStyles, out dt);

        /// <summary>
        ///     Converts the JSON string representation of a date time to its DateTime equivalent.
        /// </summary>
        /// <param name="text">The input text.</param>
        /// <param name="styles">The styles to use.</param>
        /// <param name="dt">When this method returns, contains the DateTime equivalent.</param>
        /// <returns>
        ///     true if the text was converted successfully; otherwise, false.
        /// </returns>
        private static bool TryParseDateTime(string text, DateTimeStyles styles, out DateTime dt)
        {
            dt = DateTime.MinValue;
            if (text == null)
                return false;

            if (text.Length > 2)
            {
                if ((text[0] == '"') && (text[text.Length - 1] == '"'))
                {
                    using StringReader reader = new StringReader(text);
                    reader.Read(); // skip "
                    JsonOptions options = new JsonOptions
                    {
                        ThrowExceptions = false
                    };
                    text = ReadString(reader, options);
                }
            }

            if (text.EndsWith("Z", StringComparison.OrdinalIgnoreCase))
            {
                if (DateTime.TryParseExact(text, DateFormatsUtc, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out dt))
                    return true;
            }

            int offsetHours = 0;
            int offsetMinutes = 0;
            DateTimeKind kind = DateTimeKind.Utc;
            const int len = 19;

            // s format length is 19, as in '2012-02-21T17:07:14'
            // so we can do quick checks
            // this portion of code is needed because we assume UTC and the default DateTime parse behavior is not that (even with AssumeUniversal)
            if ((text.Length >= len) &&
                (text[4] == '-') &&
                (text[7] == '-') &&
                (text[10] == 'T' || text[10] == 't') &&
                (text[13] == ':') &&
                (text[16] == ':'))
            {
                if (DateTime.TryParseExact(text, "o", null, DateTimeStyles.AssumeUniversal, out dt))
                    return true;

                int tz = text.Substring(len).IndexOfAny(new[] {'+', '-'});
                string text2 = text;
                if (tz >= 0)
                {
                    tz += len;
                    string offset = text.Substring(tz + 1).Trim();
                    if (int.TryParse(offset, out int i))
                    {
                        kind = DateTimeKind.Local;
                        offsetHours = i / 100;
                        offsetMinutes = i % 100;
                        if (text[tz] == '-')
                        {
                            offsetHours = -offsetHours;
                            offsetMinutes = -offsetMinutes;
                        }

                        text2 = text.Substring(0, tz);
                    }
                }

                if (tz >= 0)
                {
                    if (DateTime.TryParseExact(text2, "s", null, DateTimeStyles.AssumeLocal, out dt))
                    {
                        if (offsetHours != 0)
                        {
                            dt = dt.AddHours(offsetHours);
                        }

                        if (offsetMinutes != 0)
                        {
                            dt = dt.AddMinutes(offsetMinutes);
                        }

                        return true;
                    }
                }
                else
                {
                    if (DateTime.TryParseExact(text, "s", null, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out dt))
                        return true;
                }
            }

            // 01234567890123456
            // 20150525T15:50:00
            if ((text.Length == 17))
            {
                if ((text[8] == 'T' || text[8] == 't') && (text[11] == ':') && (text[14] == ':'))
                {
                    _ = int.TryParse(text.Substring(0, 4), out int year);
                    _ = int.TryParse(text.Substring(4, 2), out int month);
                    _ = int.TryParse(text.Substring(6, 2), out int day);
                    _ = int.TryParse(text.Substring(9, 2), out int hour);
                    _ = int.TryParse(text.Substring(12, 2), out int minute);
                    _ = int.TryParse(text.Substring(15, 2), out int second);
                    if ((month > 0) && (month < 13) &&
                        (day > 0) && (day < 32) &&
                        (year >= 0) &&
                        (hour >= 0) && (hour < 24) &&
                        (minute >= 0) && (minute < 60) &&
                        (second >= 0) && (second < 60))
                    {
                        try
                        {
                            dt = new DateTime(year, month, day, hour, minute, second);
                            return true;
                        }
                        catch
                        {
                            // do nothing
                        }
                    }
                }
            }

            // read this http://weblogs.asp.net/bleroy/archive/2008/01/18/dates-and-json.aspx
            string ticks = null;
            if (text.StartsWith(DateStartJs) && text.EndsWith(DateEndJs))
            {
                ticks = text.Substring(DateStartJs.Length, text.Length - DateStartJs.Length - DateEndJs.Length).Trim();
            }
            else if (text.StartsWith(DateStart2, StringComparison.OrdinalIgnoreCase) && text.EndsWith(DateEnd2, StringComparison.OrdinalIgnoreCase))
            {
                ticks = text.Substring(DateStart2.Length, text.Length - DateEnd2.Length - DateStart2.Length).Trim();
            }

            if (!string.IsNullOrEmpty(ticks))
            {
                int startIndex = ticks[0] == '-' || ticks[0] == '+' ? 1 : 0;
                int pos = ticks.IndexOfAny(new[] {'+', '-'}, startIndex);
                if (pos >= 0)
                {
                    bool neg = ticks[pos] == '-';
                    string offset = ticks.Substring(pos + 1).Trim();
                    ticks = ticks.Substring(0, pos).Trim();
                    if (int.TryParse(offset, out int i))
                    {
                        kind = DateTimeKind.Local;
                        offsetHours = i / 100;
                        offsetMinutes = i % 100;
                        if (neg)
                        {
                            offsetHours = -offsetHours;
                            offsetMinutes = -offsetMinutes;
                        }
                    }
                }

                if (long.TryParse(ticks, NumberStyles.Number, CultureInfo.InvariantCulture, out long l))
                {
                    dt = new DateTime(l * 10000 + MinDateTimeTicks, kind);
                    if (offsetHours != 0)
                    {
                        dt = dt.AddHours(offsetHours);
                    }

                    if (offsetMinutes != 0)
                    {
                        dt = dt.AddMinutes(offsetMinutes);
                    }

                    return true;
                }
            }

            // don't parse pure timespan style XX:YY:ZZ
            if ((text.Length == 8) && (text[2] == ':') && (text[5] == ':'))
            {
                dt = DateTime.MinValue;
                return false;
            }

            return DateTime.TryParse(text, null, styles, out dt);
        }

        /// <summary>
        ///     Handles the exception using the specified ex
        /// </summary>
        /// <param name="ex">The ex</param>
        /// <param name="options">The options</param>
        internal static void HandleException(Exception ex, JsonOptions options)
        {
            if (options is {ThrowExceptions: false})
            {
                options.AddException(ex);
                return;
            }

            throw ex;
        }

        /// <summary>
        ///     Gets the hex value using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="c">The </param>
        /// <param name="options">The options</param>
        /// <returns>The byte</returns>
        private static byte GetHexValue(TextReader reader, char c, JsonOptions options)
        {
            c = char.ToLower(c);
            if (c < '0')
            {
                HandleException(GetExpectedHexCharacterException(GetPosition(reader)), options);
                return 0;
            }

            if (c <= '9')
                return (byte) (c - '0');

            if (c < 'a')
            {
                HandleException(GetExpectedHexCharacterException(GetPosition(reader)), options);
                return 0;
            }

            if (c <= 'f')
                return (byte) (c - 'a' + 10);

            HandleException(GetExpectedHexCharacterException(GetPosition(reader)), options);
            return 0;
        }

        /// <summary>
        ///     Reads the x 4 using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <returns>The ushort</returns>
        private static ushort ReadX4(TextReader reader, JsonOptions options)
        {
            int u = 0;
            for (int i = 0; i < 4; i++)
            {
                u *= 16;
                if (reader.Peek() < 0)
                {
                    HandleException(new JsonException("JSO0008: JSON deserialization error detected at end of stream. Expecting hexadecimal character."), options);
                    return 0;
                }

                u += GetHexValue(reader, (char) reader.Read(), options);
            }

            return (ushort) u;
        }

        /// <summary>
        ///     Describes whether read whitespaces
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <returns>The bool</returns>
        private static bool ReadWhitespaces(TextReader reader) => ReadWhile(reader, char.IsWhiteSpace);

        /// <summary>
        ///     Describes whether read while
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="cont">The cont</param>
        /// <returns>The bool</returns>
        private static bool ReadWhile(TextReader reader, Predicate<char> cont)
        {
            do
            {
                int i = reader.Peek();
                if (i < 0)
                    return false;

                if (!cont((char) i))
                    return true;

                reader.Read();
            } while (true);
        }

        /// <summary>
        ///     Writes a value to a JSON writer.
        /// </summary>
        /// <param name="writer">The writer. May not be null.</param>
        /// <param name="value">The value to writer.</param>
        /// <param name="objectGraph">A graph of objects to track cyclic serialization.</param>
        /// <param name="options">The options to use.</param>
        public static void WriteValue(TextWriter writer, object value, IDictionary<object, object> objectGraph, JsonOptions options = null)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            options = options ?? new JsonOptions();
            objectGraph = objectGraph ?? options.FinalObjectGraph;
            SetOptions(objectGraph, options);

            if (options.WriteValueCallback != null)
            {
                JsonEventArgs e = new JsonEventArgs(writer, value, objectGraph, options)
                {
                    EventType = JsonEventType.WriteValue
                };
                options.WriteValueCallback(e);
                if (e.Handled)
                    return;
            }

            if (value == null || Convert.IsDBNull(value))
            {
                writer.Write(Null);
                return;
            }

            if (value is string s)
            {
                WriteString(writer, s);
                return;
            }

            if (value is bool b)
            {
                writer.Write(b ? True : False);
                return;
            }

            if (value is float f)
            {
                if (float.IsInfinity(f) || float.IsNaN(f))
                {
                    writer.Write(Null);
                    return;
                }

                writer.Write(f.ToString(RoundTripFormat, CultureInfo.InvariantCulture));
                return;
            }

            if (value is double d)
            {
                if (double.IsInfinity(d) || double.IsNaN(d))
                {
                    writer.Write(Null);
                    return;
                }

                writer.Write(d.ToString(RoundTripFormat, CultureInfo.InvariantCulture));
                return;
            }

            if (value is char c)
            {
                if (c == '\0')
                {
                    writer.Write(Null);
                    return;
                }

                WriteString(writer, c.ToString());
                return;
            }

            if (value is Enum @enum)
            {
                if (options.SerializationOptions.HasFlag(JsonSerializationOptions.EnumAsText))
                {
                    WriteString(writer, value.ToString());
                }
                else
                {
                    writer.Write(@enum.ToString(EnumFormat));
                }

                return;
            }

            if (value is TimeSpan ts)
            {
                if (options.SerializationOptions.HasFlag(JsonSerializationOptions.TimeSpanAsText))
                {
                    WriteString(writer, ts.ToString("g", CultureInfo.InvariantCulture));
                }
                else
                {
                    writer.Write(ts.Ticks);
                }

                return;
            }

            if (value is DateTimeOffset dto)
            {
                if (options.SerializationOptions.HasFlag(JsonSerializationOptions.DateFormatJs))
                {
                    writer.Write(DateStartJs);
                    writer.Write((dto.ToUniversalTime().Ticks - MinDateTimeTicks) / 10000);
                    writer.Write(DateEndJs);
                }
                else if (options.SerializationOptions.HasFlag(JsonSerializationOptions.DateTimeOffsetFormatCustom) && !string.IsNullOrEmpty(options.DateTimeOffsetFormat))
                {
                    WriteString(writer, dto.ToUniversalTime().ToString(options.DateTimeOffsetFormat));
                }
                else if (options.SerializationOptions.HasFlag(JsonSerializationOptions.DateFormatIso8601))
                {
                    WriteString(writer, dto.ToUniversalTime().ToString("s"));
                }
                else if (options.SerializationOptions.HasFlag(JsonSerializationOptions.DateFormatRoundtripUtc))
                {
                    WriteString(writer, dto.ToUniversalTime().ToString("o"));
                }
                else
                {
                    writer.Write(DateStart);
                    writer.Write((dto.ToUniversalTime().Ticks - MinDateTimeTicks) / 10000);
                    writer.Write(DateEnd);
                }

                return;
            }
            // read this http://weblogs.asp.net/bleroy/archive/2008/01/18/dates-and-json.aspx

            if (value is DateTime dt)
            {
                if (options.SerializationOptions.HasFlag(JsonSerializationOptions.DateFormatJs))
                {
                    writer.Write(DateStartJs);
                    writer.Write((dt.ToUniversalTime().Ticks - MinDateTimeTicks) / 10000);
                    writer.Write(DateEndJs);
                }
                else if (options.SerializationOptions.HasFlag(JsonSerializationOptions.DateFormatCustom) && !string.IsNullOrEmpty(options.DateTimeFormat))
                {
                    WriteString(writer, dt.ToUniversalTime().ToString(options.DateTimeFormat));
                }
                else if (options.SerializationOptions.HasFlag(JsonSerializationOptions.DateFormatIso8601))
                {
                    writer.Write('"');
                    writer.Write(EscapeString(dt.ToUniversalTime().ToString("s")), options);
                    AppendTimeZoneUtcOffset(writer, dt);
                    writer.Write('"');
                }
                else if (options.SerializationOptions.HasFlag(JsonSerializationOptions.DateFormatRoundtripUtc))
                {
                    WriteString(writer, dt.ToUniversalTime().ToString("o"));
                }
                else
                {
                    writer.Write(DateStart);
                    writer.Write((dt.ToUniversalTime().Ticks - MinDateTimeTicks) / 10000);
                    AppendTimeZoneUtcOffset(writer, dt);
                    writer.Write(DateEnd);
                }

                return;
            }

            if (value is int || value is uint || value is short || value is ushort ||
                value is long || value is ulong || value is byte || value is sbyte ||
                value is decimal)
            {
                writer.Write(string.Format(CultureInfo.InvariantCulture, ZeroArg, value));
                return;
            }

            if (value is Guid guid)
            {
                WriteUnescapedString(writer, options.GuidFormat != null ? guid.ToString(options.GuidFormat) : guid.ToString());

                return;
            }

            Uri uri = value as Uri;
            if (uri != null)
            {
                WriteString(writer, uri.GetComponents(UriComponents.SerializationInfoString, UriFormat.UriEscaped));
                return;
            }

            if (value is Array array)
            {
                WriteArray(writer, array, objectGraph, options);
                return;
            }

            if (objectGraph.ContainsKey(value))
            {
                if (options.SerializationOptions.HasFlag(JsonSerializationOptions.ContinueOnCycle))
                {
                    writer.Write(Null);
                    return;
                }

                HandleException(new JsonException("JSO0009: Cyclic JSON serialization detected."), options);
                return;
            }

            objectGraph.Add(value, null);
            options.SerializationLevel++;

            if (value is IDictionary dictionary)
            {
                WriteDictionary(writer, dictionary, objectGraph, options);
                options.SerializationLevel--;
                return;
            }

            // ExpandoObject falls here
            if (TypeDef.IsKeyValuePairEnumerable(value.GetType(), out Type _, out Type _))
            {
                WriteDictionary(writer, new KeyValueTypeDictionary(value), objectGraph, options);
                options.SerializationLevel--;
                return;
            }

            if (value is IEnumerable enumerable)
            {
                WriteEnumerable(writer, enumerable, objectGraph, options);
                options.SerializationLevel--;
                return;
            }

            if (options.SerializationOptions.HasFlag(JsonSerializationOptions.StreamsAsBase64))
            {
                if (value is Stream stream)
                {
                    WriteBase64Stream(writer, stream, objectGraph, options);
                    options.SerializationLevel--;
                    return;
                }
            }

            WriteObject(writer, value, objectGraph, options);
            options.SerializationLevel--;
        }

        /// <summary>
        ///     Writes a stream to a JSON writer.
        /// </summary>
        /// <param name="writer">The writer. May not be null.</param>
        /// <param name="stream">The stream. May not be null.</param>
        /// <param name="objectGraph">The object graph.</param>
        /// <param name="options">The options to use.</param>
        /// <returns>The number of written bytes.</returns>
        private static long WriteBase64Stream(TextWriter writer, Stream stream, IDictionary<object, object> objectGraph, JsonOptions options = null)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            options = options ?? new JsonOptions();
            objectGraph = objectGraph ?? options.FinalObjectGraph;
            SetOptions(objectGraph, options);

            long total = 0L;
            switch (writer)
            {
                case StreamWriter sw:
                    sw.Flush();
                    return WriteBase64Stream(stream, sw.BaseStream, options);
                case IndentedTextWriter {InnerWriter: { }} itw:
                    itw.Flush();
                    return WriteBase64Stream(itw.InnerWriter, stream, objectGraph, options);
            }

            using MemoryStream ms = new MemoryStream();
            byte[] bytes = new byte[options.FinalStreamingBufferChunkSize];
            do
            {
                int read = stream.Read(bytes, 0, bytes.Length);
                if (read == 0)
                    break;

                ms.Write(bytes, 0, read);
                total += read;
            } while (true);

            writer.Write('"');
            writer.Write(Convert.ToBase64String(ms.ToArray()));
            writer.Write('"');
            return total;
        }

        /// <summary>
        ///     Sets the options using the specified obj
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <param name="options">The options</param>
        private static void SetOptions(object obj, JsonOptions options)
        {
            if (obj is IOptionsHolder holder)
            {
                holder.Options = options;
            }
        }

        /// <summary>
        ///     Writes the base 64 stream using the specified input stream
        /// </summary>
        /// <param name="inputStream">The input stream</param>
        /// <param name="outputStream">The output stream</param>
        /// <param name="options">The options</param>
        /// <returns>The total</returns>
        private static long WriteBase64Stream(Stream inputStream, Stream outputStream, JsonOptions options)
        {
            outputStream.WriteByte((byte) '"');
            // don't dispose this stream or it will dispose the outputStream as well
            CryptoStream b64 = new CryptoStream(outputStream, new ToBase64Transform(), CryptoStreamMode.Write);
            long total = 0L;
            byte[] bytes = new byte[options.FinalStreamingBufferChunkSize];
            do
            {
                int read = inputStream.Read(bytes, 0, bytes.Length);
                if (read == 0)
                    break;

                b64.Write(bytes, 0, read);
                total += read;
            } while (true);

            b64.FlushFinalBlock();
            b64.Flush();
            outputStream.WriteByte((byte) '"');
            return total;
        }

        /// <summary>
        ///     Describes whether internal is key value pair enumerable
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="keyType">The key type</param>
        /// <param name="valueType">The value type</param>
        /// <returns>The bool</returns>
        internal static bool InternalIsKeyValuePairEnumerable(Type type, out Type keyType, out Type valueType)
        {
            keyType = null;
            valueType = null;
            foreach (Type t in type.GetInterfaces())
            {
                if (t.IsGenericType)
                {
                    if (typeof(IEnumerable<>).IsAssignableFrom(t.GetGenericTypeDefinition()))
                    {
                        Type[] args = t.GetGenericArguments();
                        if (args.Length == 1)
                        {
                            Type kvp = args[0];
                            if (kvp.IsGenericType && typeof(KeyValuePair<,>).IsAssignableFrom(kvp.GetGenericTypeDefinition()))
                            {
                                Type[] kvpArgs = kvp.GetGenericArguments();
                                if (kvpArgs.Length == 2)
                                {
                                    keyType = kvpArgs[0];
                                    valueType = kvpArgs[1];
                                    return true;
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        ///     Appends the time zone utc offset using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="dt">The dt</param>
        private static void AppendTimeZoneUtcOffset(TextWriter writer, DateTime dt)
        {
            if (dt.Kind != DateTimeKind.Utc)
            {
                TimeSpan offset = TimeZoneInfo.Local.GetUtcOffset(dt);
                writer.Write(offset.Ticks >= 0 ? '+' : '-');
                writer.Write(Abs(offset.Hours).ToString(D2Format));
                writer.Write(Abs(offset.Minutes).ToString(D2Format));
            }
        }

        /// <summary>
        ///     Abs the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The float</returns>
        private static float Abs(float value) => value < 0f ? -value : value;

        /// <summary>
        ///     Writes an enumerable to a JSON writer.
        /// </summary>
        /// <param name="writer">The writer. May not be null.</param>
        /// <param name="array">The array. May not be null.</param>
        /// <param name="objectGraph">The object graph.</param>
        /// <param name="options">The options to use.</param>
        private static void WriteArray(TextWriter writer, Array array, IDictionary<object, object> objectGraph, JsonOptions options = null)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            if (array == null)
                throw new ArgumentNullException(nameof(array));

            options = options ?? new JsonOptions();
            objectGraph = objectGraph ?? options.FinalObjectGraph;
            SetOptions(objectGraph, options);

            if (options.SerializationOptions.HasFlag(JsonSerializationOptions.ByteArrayAsBase64))
            {
                if (array is byte[] bytes)
                {
                    using MemoryStream ms = new MemoryStream(bytes);
                    ms.Position = 0;
                    WriteBase64Stream(writer, ms, objectGraph, options);

                    return;
                }
            }
            
            WriteArray(writer, array, objectGraph, options, Array.Empty<int>());
        }

        /// <summary>
        ///     Writes the array using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="array">The array</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        /// <param name="indices">The indices</param>
        private static void WriteArray(TextWriter writer, Array array, IDictionary<object, object> objectGraph, JsonOptions options, int[] indices)
        {
            int[] newIndices = new int[indices.Length + 1];
            for (int i = 0; i < indices.Length; i++)
            {
                newIndices[i] = indices[i];
            }

            writer.Write('[');
            for (int i = 0; i < array.GetLength(indices.Length); i++)
            {
                if (i > 0)
                {
                    writer.Write(',');
                }

                newIndices[indices.Length] = i;

                if (array.Rank == newIndices.Length)
                {
                    WriteValue(writer, array.GetValue(newIndices), objectGraph, options);
                }
                else
                {
                    WriteArray(writer, array, objectGraph, options, newIndices);
                }
            }

            writer.Write(']');
        }

        /// <summary>
        ///     Writes an enumerable to a JSON writer.
        /// </summary>
        /// <param name="writer">The writer. May not be null.</param>
        /// <param name="enumerable">The enumerable. May not be null.</param>
        /// <param name="objectGraph">The object graph.</param>
        /// <param name="options">The options to use.</param>
        private static void WriteEnumerable(TextWriter writer, IEnumerable enumerable, IDictionary<object, object> objectGraph, JsonOptions options = null)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));

            options = options ?? new JsonOptions();
            objectGraph = objectGraph ?? options.FinalObjectGraph;
            SetOptions(objectGraph, options);

            writer.Write('[');
            bool first = true;
            foreach (object value in enumerable)
            {
                if (!first)
                {
                    writer.Write(',');
                }
                else
                {
                    first = false;
                }

                WriteValue(writer, value, objectGraph, options);
            }

            writer.Write(']');
        }

        /// <summary>
        ///     Writes a dictionary to a JSON writer.
        /// </summary>
        /// <param name="writer">The writer. May not be null.</param>
        /// <param name="dictionary">The dictionary. May not be null.</param>
        /// <param name="objectGraph">The object graph.</param>
        /// <param name="options">The options to use.</param>
        private static void WriteDictionary(TextWriter writer, IDictionary dictionary, IDictionary<object, object> objectGraph, JsonOptions options = null)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            if (dictionary == null)
                throw new ArgumentNullException(nameof(dictionary));

            options = options ?? new JsonOptions();
            objectGraph = objectGraph ?? options.FinalObjectGraph;
            SetOptions(objectGraph, options);

            writer.Write('{');
            bool first = true;
            foreach (DictionaryEntry entry in dictionary)
            {
                if (entry.Key == null)
                    continue;

                string entryKey = string.Format(CultureInfo.InvariantCulture, "{0}", entry.Key);
                if (!first)
                {
                    writer.Write(',');
                }
                else
                {
                    first = false;
                }

                if (options.SerializationOptions.HasFlag(JsonSerializationOptions.WriteKeysWithoutQuotes))
                {
                    writer.Write(EscapeString(entryKey));
                }
                else
                {
                    WriteString(writer, entryKey);
                }

                writer.Write(':');
                WriteValue(writer, entry.Value, objectGraph, options);
            }

            writer.Write('}');
        }

        /// <summary>
        ///     Writes the serializable using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="serializable">The serializable</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        private static void WriteSerializable(TextWriter writer, ISerializable serializable, IDictionary<object, object> objectGraph, JsonOptions options)
        {
            SerializationInfo info = new SerializationInfo(serializable.GetType(), DefaultFormatterConverter);
            StreamingContext ctx = new StreamingContext(StreamingContextStates.Remoting, null);
            serializable.GetObjectData(info, ctx);
            info.AddValue(SerializationTypeToken, serializable.GetType().AssemblyQualifiedName);

            bool first = true;
            foreach (SerializationEntry entry in info)
            {
                if (!first)
                {
                    writer.Write(',');
                }
                else
                {
                    first = false;
                }

                if (options.SerializationOptions.HasFlag(JsonSerializationOptions.WriteKeysWithoutQuotes))
                {
                    writer.Write(EscapeString(entry.Name));
                }
                else
                {
                    WriteString(writer, entry.Name);
                }

                writer.Write(':');
                WriteValue(writer, entry.Value, objectGraph, options);
            }
        }

        /// <summary>
        ///     Describes whether force serializable
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <returns>The bool</returns>
        private static bool ForceSerializable(object obj) => obj is Exception;

        /// <summary>
        ///     Writes an object to the JSON writer.
        /// </summary>
        /// <param name="writer">The writer. May not be null.</param>
        /// <param name="value">The object to serialize. May not be null.</param>
        /// <param name="objectGraph">The object graph.</param>
        /// <param name="options">The options to use.</param>
        private static void WriteObject(TextWriter writer, object value, IDictionary<object, object> objectGraph, JsonOptions options = null)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            options = options ?? new JsonOptions();
            objectGraph = objectGraph ?? options.FinalObjectGraph;
            SetOptions(objectGraph, options);

            ISerializable serializable = null;
            bool useISerializable = options.SerializationOptions.HasFlag(JsonSerializationOptions.UseISerializable) || ForceSerializable(value);
            if (useISerializable)
            {
                serializable = value as ISerializable;
            }

            writer.Write('{');

            if (options.BeforeWriteObjectCallback != null)
            {
                JsonEventArgs e = new JsonEventArgs(writer, value, objectGraph, options)
                {
                    EventType = JsonEventType.BeforeWriteObject
                };
                options.BeforeWriteObjectCallback(e);
                if (e.Handled)
                    return;
            }

            Type type = value.GetType();
            if (serializable != null)
            {
                WriteSerializable(writer, serializable, objectGraph, options);
            }
            else
            {
                TypeDef def = TypeDef.Get(type, options);
                def.WriteValues(writer, value, objectGraph, options);
            }

            if (options.AfterWriteObjectCallback != null)
            {
                JsonEventArgs e = new JsonEventArgs(writer, value, objectGraph, options)
                {
                    EventType = JsonEventType.AfterWriteObject
                };
                options.AfterWriteObjectCallback(e);
            }

            writer.Write('}');
        }

        /// <summary>
        ///     Determines whether the specified value is a value type and is equal to zero.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>true if the specified value is a value type and is equal to zero; false otherwise.</returns>
        public static bool IsZeroValueType(object value)
        {
            if (value == null)
                return false;

            Type type = value.GetType();
            if (!type.IsValueType)
                return false;

            return value.Equals(Activator.CreateInstance(type));
        }

        /// <summary>
        ///     Writes a name/value pair to a JSON writer.
        /// </summary>
        /// <param name="writer">The input writer. May not be null.</param>
        /// <param name="name">The name. null values will be converted to empty values.</param>
        /// <param name="value">The value.</param>
        /// <param name="objectGraph">The object graph.</param>
        /// <param name="options">The options to use.</param>
        public static void WriteNameValue(TextWriter writer, string name, object value, IDictionary<object, object> objectGraph, JsonOptions options = null)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            name = name ?? string.Empty;
            options = options ?? new JsonOptions();
            objectGraph = objectGraph ?? options.FinalObjectGraph;
            SetOptions(objectGraph, options);

            if (options.SerializationOptions.HasFlag(JsonSerializationOptions.WriteKeysWithoutQuotes))
            {
                writer.Write(EscapeString(name));
            }
            else
            {
                WriteString(writer, name);
            }

            writer.Write(':');
            WriteValue(writer, value, objectGraph, options);
        }

        /// <summary>
        ///     Writes a string to a JSON writer.
        /// </summary>
        /// <param name="writer">The input writer. May not be null.</param>
        /// <param name="text">The text.</param>
        private static void WriteString(TextWriter writer, string text)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            if (text == null)
            {
                writer.Write(Null);
                return;
            }

            writer.Write('"');
            writer.Write(EscapeString(text));
            writer.Write('"');
        }

        /// <summary>
        ///     Writes a string to a JSON writer.
        /// </summary>
        /// <param name="writer">The input writer. May not be null.</param>
        /// <param name="text">The text.</param>
        private static void WriteUnescapedString(TextWriter writer, string text)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            if (text == null)
            {
                writer.Write(Null);
                return;
            }

            writer.Write('"');
            writer.Write(text);
            writer.Write('"');
        }

        /// <summary>
        ///     Appends the char as unicode using the specified sb
        /// </summary>
        /// <param name="sb">The sb</param>
        /// <param name="c">The </param>
        private static void AppendCharAsUnicode(StringBuilder sb, char c)
        {
            sb.Append('\\');
            sb.Append('u');
            sb.AppendFormat(CultureInfo.InvariantCulture, X4Format, (ushort) c);
        }

        /// <summary>
        ///     Serializes an object with format. Note this is more for debugging purposes as it's not designed to be fast.
        /// </summary>
        /// <param name="value">The JSON object. May be null.</param>
        /// <param name="options">The options to use. May be null.</param>
        /// <returns>A string containing the formatted object.</returns>
        public static string SerializeFormatted(object value, JsonOptions options = null)
        {
            using StringWriter sw = new StringWriter();
            SerializeFormatted(sw, value, options);
            return sw.ToString();
        }

        /// <summary>
        ///     Serializes an object with format. Note this is more for debugging purposes as it's not designed to be fast.
        /// </summary>
        /// <param name="writer">The output writer. May not be null.</param>
        /// <param name="value">The JSON object. May be null.</param>
        /// <param name="options">The options to use. May be null.</param>
        private static void SerializeFormatted(TextWriter writer, object value, JsonOptions options = null)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            options = options ?? new JsonOptions();
            string serialized = Serialize(value, options);
            object deserialized = Deserialize(serialized, typeof(object), options);
            WriteFormatted(writer, deserialized, options);
        }

        /// <summary>
        ///     Writes a JSON deserialized object formatted.
        /// </summary>
        /// <param name="jsonObject">The JSON object. May be null.</param>
        /// <param name="options">The options to use. May be null.</param>
        /// <returns>A string containing the formatted object.</returns>
        public static string WriteFormatted(object jsonObject, JsonOptions options = null)
        {
            using StringWriter sw = new StringWriter();
            WriteFormatted(sw, jsonObject, options);
            return sw.ToString();
        }

        /// <summary>
        ///     Writes a JSON deserialized object formatted.
        /// </summary>
        /// <param name="writer">The output writer. May not be null.</param>
        /// <param name="jsonObject">The JSON object. May be null.</param>
        /// <param name="options">The options to use. May be null.</param>
        private static void WriteFormatted(TextWriter writer, object jsonObject, JsonOptions options = null)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            options = options ?? new JsonOptions();
            IndentedTextWriter itw = new IndentedTextWriter(writer, options.FormattingTab);
            WriteFormatted(itw, jsonObject, options);
        }

        /// <summary>
        ///     Writes the formatted using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="jsonObject">The json object</param>
        /// <param name="options">The options</param>
        private static void WriteFormatted(IndentedTextWriter writer, object jsonObject, JsonOptions options)
        {
            switch (jsonObject)
            {
                case DictionaryEntry entry:
                {
                    string entryKey = string.Format(CultureInfo.InvariantCulture, "{0}", entry.Key);
                    if (options.SerializationOptions.HasFlag(JsonSerializationOptions.WriteKeysWithoutQuotes))
                    {
                        writer.Write(entryKey);
                        writer.Write(": ");
                    }
                    else
                    {
                        writer.Write('"');
                        writer.Write(entryKey);
                        writer.Write("\": ");
                    }

                    writer.Indent++;
                    WriteFormatted(writer, entry.Value, options);
                    writer.Indent--;
                    return;
                }
                case IDictionary dictionary:
                {
                    writer.WriteLine('{');
                    bool first = true;
                    writer.Indent++;
                    foreach (DictionaryEntry entry2 in dictionary)
                    {
                        if (!first)
                        {
                            writer.WriteLine(',');
                        }
                        else
                        {
                            first = false;
                        }

                        WriteFormatted(writer, entry2, options);
                    }

                    writer.Indent--;
                    writer.WriteLine();
                    writer.Write('}');
                    return;
                }
                case string s:
                    WriteString(writer, s);
                    return;
                case IEnumerable enumerable:
                {
                    writer.WriteLine('[');
                    bool first = true;
                    writer.Indent++;
                    foreach (object obj in enumerable)
                    {
                        if (!first)
                        {
                            writer.WriteLine(',');
                        }
                        else
                        {
                            first = false;
                        }

                        WriteFormatted(writer, obj, options);
                    }

                    writer.Indent--;
                    writer.WriteLine();
                    writer.Write(']');
                    return;
                }
                default:
                    WriteValue(writer, jsonObject, null, options);
                    break;
            }
        }

        /// <summary>
        ///     Escapes a string using JSON representation.
        /// </summary>
        /// <param name="value">The string to escape.</param>
        /// <returns>A JSON-escaped string.</returns>
        public static string EscapeString(string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            StringBuilder builder = new StringBuilder();
            int startIndex = 0;
            int count = 0;
            for (int i = 0; i < value.Length; i++)
            {
                char c = value[i];
                if (c == '\r' ||
                    c == '\t' ||
                    c == '"' ||
                    c == '\'' ||
                    c == '<' ||
                    c == '>' ||
                    c == '\\' ||
                    c == '\n' ||
                    c == '\b' ||
                    c == '\f' ||
                    c < ' ')
                {
                    if (count > 0)
                    {
                        builder.Append(value, startIndex, count);
                    }

                    startIndex = i + 1;
                    count = 0;
                }

                switch (c)
                {
                    case '<':
                    case '>':
                    case '\'':
                        AppendCharAsUnicode(builder, c);
                        continue;

                    case '\\':
                        builder.Append(@"\\");
                        continue;

                    case '\b':
                        builder.Append(@"\b");
                        continue;

                    case '\t':
                        builder.Append(@"\t");
                        continue;

                    case '\n':
                        builder.Append(@"\n");
                        continue;

                    case '\f':
                        builder.Append(@"\f");
                        continue;

                    case '\r':
                        builder.Append(@"\r");
                        continue;

                    case '"':
                        builder.Append("\\\"");
                        continue;
                }

                if (c < ' ')
                {
                    AppendCharAsUnicode(builder, c);
                }
                else
                {
                    count++;
                }
            }

            if (count > 0)
            {
                builder.Append(value, startIndex, count);
            }

            return builder.ToString();
        }

        /// <summary>
        ///     Gets a nullified string value from a dictionary by its path.
        ///     This is useful to get a string value from the object that the untyped Deserialize method returns which is often of
        ///     IDictionary&lt;string, object&gt; type.
        /// </summary>
        /// <param name="dictionary">The input dictionary.</param>
        /// <param name="path">The path, composed of dictionary keys separated by a . character. May not be null.</param>
        /// <returns>
        ///     The nullified string value or null if not found.
        /// </returns>
        public static string GetNullifiedStringValueByPath(this IDictionary<string, object> dictionary, string path)
        {
            if (dictionary == null)
                return null;

            if (!TryGetValueByPath(dictionary, path, out object obj))
                return null;

            return Conversions.ChangeType<string>(obj).Nullify();
        }

        /// <summary>
        ///     Gets a value from a dictionary by its path.
        ///     This is useful to get a value from the object that the untyped Deserialize method returns which is often of
        ///     IDictionary&lt;string, object&gt; type.
        /// </summary>
        /// <typeparam name="T">The final type to which to convert the retrieved value.</typeparam>
        /// <param name="dictionary">The input dictionary.</param>
        /// <param name="path">The path, composed of dictionary keys separated by a . character. May not be null.</param>
        /// <param name="value">The value to retrieve.</param>
        /// <returns>
        ///     true if the value parameter was retrieved successfully; otherwise, false.
        /// </returns>
        public static bool TryGetValueByPath<T>(this IDictionary<string, object> dictionary, string path, out T value)
        {
            if (dictionary == null)
            {
                value = default(T);
                return false;
            }

            if (!TryGetValueByPath(dictionary, path, out object obj))
            {
                value = default(T);
                return false;
            }

            return Conversions.TryChangeType(obj, out value);
        }

        /// <summary>
        ///     Gets a value from a dictionary by its path.
        ///     This is useful to get a value from the object that the untyped Deserialize method returns which is often of
        ///     IDictionary&lt;string, object&gt; type.
        /// </summary>
        /// <param name="dictionary">The input dictionary.</param>
        /// <param name="path">The path, composed of dictionary keys separated by a . character. May not be null.</param>
        /// <param name="value">The value to retrieve.</param>
        /// <returns>
        ///     true if the value parameter was retrieved successfully; otherwise, false.
        /// </returns>
        private static bool TryGetValueByPath(this IDictionary<string, object> dictionary, string path, out object value)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            value = null;
            if (dictionary == null)
                return false;

            string[] segments = path.Split('.');
            IDictionary<string, object> current = dictionary;
            for (int i = 0; i < segments.Length; i++)
            {
                string segment = segments[i].Nullify();
                if (segment == null)
                    return false;

                if (!current.TryGetValue(segment, out object newElement))
                    return false;

                // last?
                if (i == segments.Length - 1)
                {
                    value = newElement;
                    return true;
                }

                current = newElement as IDictionary<string, object>;
                if (current == null)
                    break;
            }

            return false;
        }

        /// <summary>
        ///     Gets the attribute using the specified descriptor
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="descriptor">The descriptor</param>
        /// <returns>The</returns>
        internal static T GetAttribute<T>(this PropertyDescriptor descriptor) where T : Attribute => GetAttribute<T>(descriptor.Attributes);

        /// <summary>
        ///     Gets the attribute using the specified attributes
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="attributes">The attributes</param>
        /// <returns>The</returns>
        private static T GetAttribute<T>(this AttributeCollection attributes) where T : Attribute
        {
            foreach (object att in attributes)
            {
                if (att is T attribute)
                    return attribute;
            }

            return null;
        }

        /// <summary>
        ///     Describes whether equals ignore case
        /// </summary>
        /// <param name="str">The str</param>
        /// <param name="text">The text</param>
        /// <param name="trim">The trim</param>
        /// <returns>The bool</returns>
        internal static bool EqualsIgnoreCase(this string str, string text, bool trim = false)
        {
            if (trim)
            {
                str = str.Nullify();
                text = text.Nullify();
            }

            if (str == null)
                return text == null;

            if (text == null)
                return false;

            if (str.Length != text.Length)
                return false;

            return string.Compare(str, text, StringComparison.OrdinalIgnoreCase) == 0;
        }

        /// <summary>
        ///     Nullifies the str
        /// </summary>
        /// <param name="str">The str</param>
        /// <returns>The string</returns>
        internal static string Nullify(this string str)
        {
            if (str == null)
                return null;

            if (string.IsNullOrWhiteSpace(str))
                return null;

            string t = str.Trim();
            return t.Length == 0 ? null : t;
        }
    }
}