// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: JsonSerializer.cs
// 
//  Author: Pablo Perdomo Falcón
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
using System.Runtime.CompilerServices;
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
        private const string _null = "null";

        /// <summary>
        ///     The true
        /// </summary>
        private const string _true = "true";

        /// <summary>
        ///     The false
        /// </summary>
        private const string _false = "false";

        /// <summary>
        ///     The zero arg
        /// </summary>
        private const string _zeroArg = "{0}";

        /// <summary>
        ///     The date start js
        /// </summary>
        private const string _dateStartJs = "new Date(";

        /// <summary>
        ///     The date end js
        /// </summary>
        private const string _dateEndJs = ")";

        /// <summary>
        ///     The date start
        /// </summary>
        private const string _dateStart = @"""\/Date(";

        /// <summary>
        ///     The date start
        /// </summary>
        private const string _dateStart2 = @"/Date(";

        /// <summary>
        ///     The date end
        /// </summary>
        private const string _dateEnd = @")\/""";

        /// <summary>
        ///     The date end
        /// </summary>
        private const string _dateEnd2 = @")/";

        /// <summary>
        ///     The round trip format
        /// </summary>
        private const string _roundTripFormat = "R";

        /// <summary>
        ///     The enum format
        /// </summary>
        private const string _enumFormat = "D";

        /// <summary>
        ///     The format
        /// </summary>
        private const string _x4Format = "{0:X4}";

        /// <summary>
        ///     The format
        /// </summary>
        private const string _d2Format = "D2";

        /// <summary>
        ///     The script ignore
        /// </summary>
        private const string _scriptIgnore = "ScriptIgnore";

        /// <summary>
        ///     The serialization type token
        /// </summary>
        private const string _serializationTypeToken = "__type";

        /// <summary>
        ///     The date formats utc
        /// </summary>
        private static readonly string[] _dateFormatsUtc = {"yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'", "yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'", "yyyy'-'MM'-'dd'T'HH':'mm'Z'", "yyyyMMdd'T'HH':'mm':'ss'Z'"};

        /// <summary>
        ///     The utc
        /// </summary>
        private static readonly DateTime _minDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        ///     The ticks
        /// </summary>
        private static readonly long _minDateTimeTicks = _minDateTime.Ticks;

        /// <summary>
        ///     The formatter converter
        /// </summary>
        private static readonly FormatterConverter _defaultFormatterConverter = new FormatterConverter();

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
            using (var writer = new StringWriter())
            {
                Serialize(writer, value, options);
                return writer.ToString();
            }
        }

        /// <summary>
        ///     Serializes the specified object to the specified TextWriter. Supports anonymous and dynamic types.
        /// </summary>
        /// <param name="writer">The output writer. May not be null.</param>
        /// <param name="value">The object to serialize.</param>
        /// <param name="options">Options to use for serialization.</param>
        public static void Serialize(TextWriter writer, object value, JsonOptions options = null)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            options = options ?? new JsonOptions();
            var objectGraph = options.FinalObjectGraph;
            SetOptions(objectGraph, options);

            var jsonp = options.JsonPCallback.Nullify();
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

                if (!targetType.IsValueType)
                    return null;

                return CreateInstance(null, targetType, 0, options, text);
            }

            using (var reader = new StringReader(text))
            {
                return Deserialize(reader, targetType, options);
            }
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
        public static object Deserialize(TextReader reader, Type targetType = null, JsonOptions options = null)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            options = options ?? new JsonOptions();
            if (targetType == null || targetType == typeof(object))
                return ReadValue(reader, options);

            var value = ReadValue(reader, options);
            if (value == null)
            {
                if (targetType.IsValueType)
                    return CreateInstance(null, targetType, 0, options, value);

                return null;
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

            using (var reader = new StringReader(text))
            {
                DeserializeToTarget(reader, target, options);
            }
        }

        /// <summary>
        ///     Deserializes data from the specified TextReader and populates a specified object instance.
        /// </summary>
        /// <param name="reader">The input reader. May not be null.</param>
        /// <param name="target">The object instance to populate.</param>
        /// <param name="options">Options to use for deserialization.</param>
        public static void DeserializeToTarget(TextReader reader, object target, JsonOptions options = null)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if (target == null)
                throw new ArgumentNullException(nameof(target));

            var value = ReadValue(reader, options);
            Apply(value, target, options);
        }

        /// <summary>
        ///     Applies the content of an array or dictionary to a target object.
        /// </summary>
        /// <param name="input">The input object.</param>
        /// <param name="target">The target object.</param>
        /// <param name="options">Options to use.</param>
        public static void Apply(object input, object target, JsonOptions options = null)
        {
            options = options ?? new JsonOptions();
            if (target is Array array && !array.IsReadOnly)
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
                var lo = GetListObject(target.GetType(), options, target, input, null, null);
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
        private static object CreateInstance(object target, Type type, int elementsCount, JsonOptions options, object value)
        {
            try
            {
                if (options.CreateInstanceCallback != null)
                {
                    var og = new Dictionary<object, object>
                    {
                        ["elementsCount"] = elementsCount,
                        ["value"] = value
                    };

                    var e = new JsonEventArgs(null, type, og, options, null, target)
                    {
                        EventType = JsonEventType.CreateInstance
                    };
                    options.CreateInstanceCallback(e);
                    if (e.Handled)
                        return e.Value;
                }

                if (type.IsArray)
                {
                    var elementType = type.GetElementType();
                    return Array.CreateInstance(elementType, elementsCount);
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
        private static ListObject GetListObject(Type type, JsonOptions options, object target, object value, IDictionary dictionary, string key)
        {
            if (options.GetListObjectCallback != null)
            {
                var og = new Dictionary<object, object>
                {
                    ["dictionary"] = dictionary,
                    ["type"] = type
                };

                var e = new JsonEventArgs(null, value, og, options, key, target)
                {
                    EventType = JsonEventType.GetListObject
                };
                options.GetListObjectCallback(e);
                if (e.Handled)
                {
                    og.TryGetValue("type", out var outType);
                    return outType as ListObject;
                }
            }

            if (type == typeof(byte[]))
                return null;

            if (typeof(IList).IsAssignableFrom(type))
                return new IListObject(); // also handles arrays

            if (type.IsGenericType)
            {
                if (type.GetGenericTypeDefinition() == typeof(ICollection<>))
                    return (ListObject) Activator.CreateInstance(typeof(ICollectionTObject<>).MakeGenericType(type.GetGenericArguments()[0]));
            }

            foreach (var iface in type.GetInterfaces())
            {
                if (!iface.IsGenericType)
                    continue;

                if (iface.GetGenericTypeDefinition() == typeof(ICollection<>))
                    return (ListObject) Activator.CreateInstance(typeof(ICollectionTObject<>).MakeGenericType(iface.GetGenericArguments()[0]));
            }

            return null;
        }

        /// <summary>
        ///     Applies the to list target using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="input">The input</param>
        /// <param name="list">The list</param>
        /// <param name="options">The options</param>
        private static void ApplyToListTarget(object target, IEnumerable input, ListObject list, JsonOptions options)
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
                var array = list.List as Array;
                var max = 0;
                var i = 0;
                if (array != null)
                {
                    i = array.GetLowerBound(0);
                    max = array.GetUpperBound(0);
                }

                var itemType = GetItemType(list.List.GetType());
                foreach (var value in input)
                {
                    if (array != null)
                    {
                        if (i - 1 == max)
                            break;

                        array.SetValue(ChangeType(target, value, itemType, options), i++);
                    }
                    else
                    {
                        var cvalue = ChangeType(target, value, itemType, options);
                        if (list.Context != null)
                        {
                            list.Context["action"] = "add";
                            list.Context["itemType"] = itemType;
                            list.Context["value"] = value;
                            list.Context["cvalue"] = cvalue;

                            if (!list.Context.TryGetValue("cvalue", out var newcvalue))
                                continue;

                            cvalue = newcvalue;
                        }

                        list.Add(cvalue, options);
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
            if (target == null || target.Rank != 1)
                return;

            var elementType = target.GetType().GetElementType();
            var i = 0;
            if (input != null)
            {
                foreach (var value in input)
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
        private static bool AreValuesEqual(object o1, object o2)
        {
            if (ReferenceEquals(o1, o2))
                return true;

            if (o1 == null)
                return o2 == null;

            return o1.Equals(o2);
        }

        /// <summary>
        ///     Describes whether try get object default value
        /// </summary>
        /// <param name="att">The att</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        private static bool TryGetObjectDefaultValue(Attribute att, out object value)
        {
            if (att is JsonAttribute jsa && jsa.HasDefaultValue)
            {
                value = jsa.DefaultValue;
                return true;
            }

            if (att is DefaultValueAttribute dva)
            {
                value = dva.Value;
                return true;
            }

            value = null;
            return false;
        }

        /// <summary>
        ///     Gets the object name using the specified att
        /// </summary>
        /// <param name="att">The att</param>
        /// <returns>The string</returns>
        private static string GetObjectName(Attribute att)
        {
            if (att is JsonAttribute jsa && !string.IsNullOrEmpty(jsa.Name))
                return jsa.Name;

            if (att is XmlAttributeAttribute xaa && !string.IsNullOrEmpty(xaa.AttributeName))
                return xaa.AttributeName;

            if (att is XmlElementAttribute xea && !string.IsNullOrEmpty(xea.ElementName))
                return xea.ElementName;

            return null;
        }

        /// <summary>
        ///     Describes whether try get object default value
        /// </summary>
        /// <param name="mi">The mi</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        private static bool TryGetObjectDefaultValue(MemberInfo mi, out object value)
        {
            var atts = mi.GetCustomAttributes(true);
            if (atts != null)
            {
                foreach (var att in atts.Cast<Attribute>())
                {
                    if (TryGetObjectDefaultValue(att, out value))
                        return true;
                }
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
        private static string GetObjectName(MemberInfo mi, string defaultName)
        {
            var atts = mi.GetCustomAttributes(true);
            if (atts != null)
            {
                foreach (var att in atts.Cast<Attribute>())
                {
                    var name = GetObjectName(att);
                    if (name != null)
                        return name;
                }
            }

            return defaultName;
        }

        /// <summary>
        ///     Describes whether try get object default value
        /// </summary>
        /// <param name="pd">The pd</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        private static bool TryGetObjectDefaultValue(PropertyDescriptor pd, out object value)
        {
            foreach (var att in pd.Attributes.Cast<Attribute>())
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
        private static string GetObjectName(PropertyDescriptor pd, string defaultName)
        {
            foreach (var att in pd.Attributes.Cast<Attribute>())
            {
                var name = GetObjectName(att);
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
        private static bool HasScriptIgnore(PropertyDescriptor pd)
        {
            if (pd.Attributes == null)
                return false;

            foreach (var att in pd.Attributes)
            {
                if (att.GetType().Name == null)
                    continue;

                if (att.GetType().Name.StartsWith(_scriptIgnore))
                    return true;
            }

            return false;
        }

        /// <summary>
        ///     Describes whether has script ignore
        /// </summary>
        /// <param name="mi">The mi</param>
        /// <returns>The bool</returns>
        private static bool HasScriptIgnore(MemberInfo mi)
        {
            var atts = mi.GetCustomAttributes(true);
            if (atts == null || atts.Length == 0)
                return false;

            foreach (var obj in atts)
            {
#pragma warning disable IDE0083 // Use pattern matching
                if (!(obj is Attribute att))
#pragma warning restore IDE0083 // Use pattern matching
                    continue;

                if (att.GetType().Name == null)
                    continue;

                if (att.GetType().Name.StartsWith(_scriptIgnore))
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
        private static void Apply(IDictionary dictionary, object target, JsonOptions options)
        {
            if (dictionary == null || target == null)
                return;

            if (target is IDictionary dicTarget)
            {
                var itemType = GetItemType(dicTarget.GetType());
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

            var def = TypeDef.Get(target.GetType(), options);

            foreach (DictionaryEntry entry in dictionary)
            {
                if (entry.Key == null)
                    continue;

                var entryKey = string.Format(CultureInfo.InvariantCulture, "{0}", entry.Key);
                var entryValue = entry.Value;
                if (options.MapEntryCallback != null)
                {
                    var og = new Dictionary<object, object>
                    {
                        ["dictionary"] = dictionary
                    };

                    var e = new JsonEventArgs(null, entryValue, og, options, entryKey, target)
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
        private static JsonAttribute GetJsonAttribute(MemberInfo pi)
        {
            var atts = pi.GetCustomAttributes(true);
            if (atts == null || atts.Length == 0)
                return null;

            foreach (var obj in atts)
            {
#pragma warning disable IDE0083 // Use pattern matching
                if (!(obj is Attribute att))
#pragma warning restore IDE0083 // Use pattern matching
                    continue;

                if (att is JsonAttribute xatt)
                    return xatt;
            }

            return null;
        }

        /// <summary>
        ///     Gets the type of elements in a collection type.
        /// </summary>
        /// <param name="collectionType">The collection type.</param>
        /// <returns>The element type or typeof(object) if it was not determined.</returns>
        public static Type GetItemType(Type collectionType)
        {
            if (collectionType == null)
                throw new ArgumentNullException(nameof(collectionType));

            foreach (var iface in collectionType.GetInterfaces())
            {
                if (!iface.IsGenericType)
                    continue;

                if (iface.GetGenericTypeDefinition() == typeof(IDictionary<,>))
                    return iface.GetGenericArguments()[1];

                if (iface.GetGenericTypeDefinition() == typeof(IList<>))
                    return iface.GetGenericArguments()[0];

                if (iface.GetGenericTypeDefinition() == typeof(ICollection<>))
                    return iface.GetGenericArguments()[0];

                if (iface.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                    return iface.GetGenericArguments()[0];
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
                        var elementType = conversionType.GetElementType();
                        var list = new List<object>();
                        foreach (var obj in en)
                        {
                            list.Add(ChangeType(target, obj, elementType, options));
                        }

                        var array = Array.CreateInstance(elementType, list.Count);
                        if (array != null)
                        {
                            Array.Copy(list.ToArray(), array, list.Count);
                        }

                        return array;
                    }
                }

                var lo = GetListObject(conversionType, options, target, value, null, null);
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
                var instance = CreateInstance(target, conversionType, 0, options, value);
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

                var svalue = string.Format(CultureInfo.InvariantCulture, "{0}", value);
                if (!string.IsNullOrEmpty(svalue))
                {
                    if (TryParseDateTime(svalue, options.DateTimeStyles, out var dt))
                        return dt;
                }
            }

            if (conversionType == typeof(TimeSpan))
            {
                var svalue = string.Format(CultureInfo.InvariantCulture, "{0}", value);
                if (!string.IsNullOrEmpty(svalue))
                {
                    if (long.TryParse(svalue, out var ticks))
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
            var list = new List<object>();
            do
            {
                var value = ReadValue(reader, options, true, out var arrayEnd);
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
            if (pos < 0)
                return new JsonException("JSO0002: JSON deserialization error detected. Expecting '" + c + "' character.");
            ;

            return new JsonException("JSO0003: JSON deserialization error detected at position " + pos + ". Expecting '" + c + "' character.");
        }

        /// <summary>
        ///     Gets the unexpected character exception using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="c">The </param>
        /// <returns>The json exception</returns>
        private static JsonException GetUnexpectedCharacterException(long pos, char c)
        {
            if (pos < 0)
                return new JsonException("JSO0004: JSON deserialization error detected. Unexpected '" + c + "' character.");
            ;

            return new JsonException("JSO0005: JSON deserialization error detected at position " + pos + ". Unexpected '" + c + "' character.");
        }

        /// <summary>
        ///     Gets the expected hexa character exception using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <returns>The json exception</returns>
        private static JsonException GetExpectedHexaCharacterException(long pos)
        {
            if (pos < 0)
                return new JsonException("JSO0006: JSON deserialization error detected. Expecting hexadecimal character.");
            ;

            return new JsonException("JSO0007: JSON deserialization error detected at position " + pos + ". Expecting hexadecimal character.");
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
            if (pos < 0)
                return new JsonException("JSO0010: JSON deserialization error detected for '" + typeName + "' type.", inner);

            return new JsonException("JSO0011: JSON deserialization error detected for '" + typeName + "' type at position " + pos + ".", inner);
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
            if (reader == null)
                return -1;

            if (reader is StreamReader sr && (sr.BaseStream != null))
            {
                try
                {
                    return sr.BaseStream.Position;
                }
                catch
                {
                    return -1;
                }
            }

            if (reader is StringReader str)
            {
                var fi = typeof(StringReader).GetField("_pos", BindingFlags.Instance | BindingFlags.NonPublic);
                if (fi != null)
                    return (int) fi.GetValue(str);
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
            var dictionary = new Dictionary<string, object>();
            do
            {
                var i = reader.Peek();
                if (i < 0)
                {
                    HandleException(GetEofException('}'), options);
                    return dictionary;
                }

                var c = (char) reader.Read();
                switch (c)
                {
                    case '}':
                        return dictionary;

                    case '"':
                        var text = ReadString(reader, options);
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
            var sb = new StringBuilder();
            do
            {
                var i = reader.Peek();
                if (i < 0)
                {
                    HandleException(GetEofException('"'), options);
                    return null;
                }

                var c = (char) reader.Read();
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

                    var next = (char) reader.Read();
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
                            var us = ReadX4(reader, options);
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

            var ctor = type.GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new[] {typeof(SerializationInfo), typeof(StreamingContext)}, null);
            var info = new SerializationInfo(type, _defaultFormatterConverter);

            foreach (var kvp in values)
            {
                info.AddValue(kvp.Key, kvp.Value);
            }

            var ctx = new StreamingContext(StreamingContextStates.Remoting, null);
            try
            {
                return (ISerializable) ctor.Invoke(new object[] {info, ctx});
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
        private static object ReadValue(TextReader reader, JsonOptions options) => ReadValue(reader, options, false, out var _);

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

            var c = (char) i;
            if (c == '"')
            {
                reader.Read();
                var s = ReadString(reader, options);
                if (options.SerializationOptions.HasFlag(JsonSerializationOptions.AutoParseDateTime))
                {
                    if (TryParseDateTime(s, options.DateTimeStyles, out var dt))
                        return dt;
                }

                return s;
            }

            if (c == '{')
            {
                var dic = ReadDictionary(reader, options);
                if (options.SerializationOptions.HasFlag(JsonSerializationOptions.UseISerializable))
                {
                    if (dic.TryGetValue(_serializationTypeToken, out var o))
                    {
                        var typeName = string.Format(CultureInfo.InvariantCulture, "{0}", o);
                        if (!string.IsNullOrEmpty(typeName))
                        {
                            dic.Remove(_serializationTypeToken);
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
            var sb = new StringBuilder();
            do
            {
                var i = reader.Peek();
                if (i < 0)
                    break;

                if ((char) i == '}')
                    break;

                var c = (char) reader.Read();
                if (c == ',')
                    break;

                if (c == ']')
                {
                    arrayEnd = true;
                    break;
                }

                sb.Append(c);
            } while (true);

            var text = sb.ToString();
            if (string.Compare(_null, text.Trim(), StringComparison.OrdinalIgnoreCase) == 0)
                return null;

            if (text.StartsWith(_dateStartJs) && text.EndsWith(_dateEndJs))
            {
                if (long.TryParse(text.Substring(_dateStartJs.Length, text.Length - _dateStartJs.Length - _dateEndJs.Length), out var l))
                    return new DateTime(l * 10000 + _minDateTimeTicks, DateTimeKind.Utc);
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
            var sb = new StringBuilder();
            do
            {
                var i = reader.Peek();
                if (i < 0)
                    break;

                if ((char) i == '}')
                    break;

                var c = (char) reader.Read();
                if (char.IsWhiteSpace(c) || c == ',')
                    break;

                if (c == ']')
                {
                    arrayEnd = true;
                    break;
                }

                sb.Append(c);
            } while (true);

            var text = sb.ToString();
            if (string.Compare(_null, text, StringComparison.OrdinalIgnoreCase) == 0)
                return null;

            if (string.Compare(_true, text, StringComparison.OrdinalIgnoreCase) == 0)
                return true;

            if (string.Compare(_false, text, StringComparison.OrdinalIgnoreCase) == 0)
                return false;

            if (text.LastIndexOf("e", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                if (double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out var d))
                    return d;
            }
            else
            {
                if (text.IndexOf(".", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    if (decimal.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out var de))
                        return de;
                }
                else
                {
                    if (int.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out var i))
                        return i;

                    if (long.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out var l))
                        return l;

                    if (decimal.TryParse(text, NumberStyles.Number, CultureInfo.InvariantCulture, out var de))
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
            if (!TryParseDateTime(text, out var dt))
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
            if (!TryParseDateTime(text, styles, out var dt))
                return null;

            return dt;
        }

        /// <summary>
        ///     Converts the JSON string representation of a date time to its DateTime equivalent.
        /// </summary>
        /// <param name="text">The input text.</param>
        /// <param name="dt">When this method returns, contains the DateTime equivalent.</param>
        /// <returns>true if the text was converted successfully; otherwise, false.</returns>
        public static bool TryParseDateTime(string text, out DateTime dt) => TryParseDateTime(text, JsonOptions._defaultDateTimeStyles, out dt);

        /// <summary>
        ///     Converts the JSON string representation of a date time to its DateTime equivalent.
        /// </summary>
        /// <param name="text">The input text.</param>
        /// <param name="styles">The styles to use.</param>
        /// <param name="dt">When this method returns, contains the DateTime equivalent.</param>
        /// <returns>
        ///     true if the text was converted successfully; otherwise, false.
        /// </returns>
        public static bool TryParseDateTime(string text, DateTimeStyles styles, out DateTime dt)
        {
            dt = DateTime.MinValue;
            if (text == null)
                return false;

            if (text.Length > 2)
            {
                if ((text[0] == '"') && (text[text.Length - 1] == '"'))
                {
                    using (var reader = new StringReader(text))
                    {
                        reader.Read(); // skip "
                        var options = new JsonOptions
                        {
                            ThrowExceptions = false
                        };
                        text = ReadString(reader, options);
                    }
                }
            }

            if (text.EndsWith("Z", StringComparison.OrdinalIgnoreCase))
            {
                if (DateTime.TryParseExact(text, _dateFormatsUtc, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out dt))
                    return true;
            }

            var offsetHours = 0;
            var offsetMinutes = 0;
            var kind = DateTimeKind.Utc;
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

                var tz = text.Substring(len).IndexOfAny(new[] {'+', '-'});
                var text2 = text;
                if (tz >= 0)
                {
                    tz += len;
                    var offset = text.Substring(tz + 1).Trim();
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
            if ((text != null) && (text.Length == 17))
            {
                if ((text[8] == 'T' || text[8] == 't') && (text[11] == ':') && (text[14] == ':'))
                {
                    _ = int.TryParse(text.Substring(0, 4), out var year);
                    _ = int.TryParse(text.Substring(4, 2), out var month);
                    _ = int.TryParse(text.Substring(6, 2), out var day);
                    _ = int.TryParse(text.Substring(9, 2), out var hour);
                    _ = int.TryParse(text.Substring(12, 2), out var minute);
                    _ = int.TryParse(text.Substring(15, 2), out var second);
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
            if (text.StartsWith(_dateStartJs) && text.EndsWith(_dateEndJs))
            {
                ticks = text.Substring(_dateStartJs.Length, text.Length - _dateStartJs.Length - _dateEndJs.Length).Trim();
            }
            else if (text.StartsWith(_dateStart2, StringComparison.OrdinalIgnoreCase) && text.EndsWith(_dateEnd2, StringComparison.OrdinalIgnoreCase))
            {
                ticks = text.Substring(_dateStart2.Length, text.Length - _dateEnd2.Length - _dateStart2.Length).Trim();
            }

            if (!string.IsNullOrEmpty(ticks))
            {
                var startIndex = ticks[0] == '-' || ticks[0] == '+' ? 1 : 0;
                var pos = ticks.IndexOfAny(new[] {'+', '-'}, startIndex);
                if (pos >= 0)
                {
                    var neg = ticks[pos] == '-';
                    var offset = ticks.Substring(pos + 1).Trim();
                    ticks = ticks.Substring(0, pos).Trim();
                    if (int.TryParse(offset, out var i))
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

                if (long.TryParse(ticks, NumberStyles.Number, CultureInfo.InvariantCulture, out var l))
                {
                    dt = new DateTime(l * 10000 + _minDateTimeTicks, kind);
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
        private static void HandleException(Exception ex, JsonOptions options)
        {
            if ((options != null) && !options.ThrowExceptions)
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
                HandleException(GetExpectedHexaCharacterException(GetPosition(reader)), options);
                return 0;
            }

            if (c <= '9')
                return (byte) (c - '0');

            if (c < 'a')
            {
                HandleException(GetExpectedHexaCharacterException(GetPosition(reader)), options);
                return 0;
            }

            if (c <= 'f')
                return (byte) (c - 'a' + 10);

            HandleException(GetExpectedHexaCharacterException(GetPosition(reader)), options);
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
            var u = 0;
            for (var i = 0; i < 4; i++)
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
                var i = reader.Peek();
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
                var e = new JsonEventArgs(writer, value, objectGraph, options)
                {
                    EventType = JsonEventType.WriteValue
                };
                options.WriteValueCallback(e);
                if (e.Handled)
                    return;
            }

            if (value == null || Convert.IsDBNull(value))
            {
                writer.Write(_null);
                return;
            }

            if (value is string s)
            {
                WriteString(writer, s);
                return;
            }

            if (value is bool b)
            {
                writer.Write(b ? _true : _false);
                return;
            }

            if (value is float f)
            {
                if (float.IsInfinity(f) || float.IsNaN(f))
                {
                    writer.Write(_null);
                    return;
                }

                writer.Write(f.ToString(_roundTripFormat, CultureInfo.InvariantCulture));
                return;
            }

            if (value is double d)
            {
                if (double.IsInfinity(d) || double.IsNaN(d))
                {
                    writer.Write(_null);
                    return;
                }

                writer.Write(d.ToString(_roundTripFormat, CultureInfo.InvariantCulture));
                return;
            }

            if (value is char c)
            {
                if (c == '\0')
                {
                    writer.Write(_null);
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
                    writer.Write(@enum.ToString(_enumFormat));
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
                    writer.Write(_dateStartJs);
                    writer.Write((dto.ToUniversalTime().Ticks - _minDateTimeTicks) / 10000);
                    writer.Write(_dateEndJs);
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
                    writer.Write(_dateStart);
                    writer.Write((dto.ToUniversalTime().Ticks - _minDateTimeTicks) / 10000);
                    writer.Write(_dateEnd);
                }

                return;
            }
            // read this http://weblogs.asp.net/bleroy/archive/2008/01/18/dates-and-json.aspx

            if (value is DateTime dt)
            {
                if (options.SerializationOptions.HasFlag(JsonSerializationOptions.DateFormatJs))
                {
                    writer.Write(_dateStartJs);
                    writer.Write((dt.ToUniversalTime().Ticks - _minDateTimeTicks) / 10000);
                    writer.Write(_dateEndJs);
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
                    writer.Write(_dateStart);
                    writer.Write((dt.ToUniversalTime().Ticks - _minDateTimeTicks) / 10000);
                    AppendTimeZoneUtcOffset(writer, dt);
                    writer.Write(_dateEnd);
                }

                return;
            }

            if (value is int || value is uint || value is short || value is ushort ||
                value is long || value is ulong || value is byte || value is sbyte ||
                value is decimal)
            {
                writer.Write(string.Format(CultureInfo.InvariantCulture, _zeroArg, value));
                return;
            }

            if (value is Guid guid)
            {
                if (options.GuidFormat != null)
                {
                    WriteUnescapedString(writer, guid.ToString(options.GuidFormat));
                }
                else
                {
                    WriteUnescapedString(writer, guid.ToString());
                }

                return;
            }

            var uri = value as Uri;
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
                    writer.Write(_null);
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
            if (TypeDef.IsKeyValuePairEnumerable(value.GetType(), out var _, out var _))
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
        public static long WriteBase64Stream(TextWriter writer, Stream stream, IDictionary<object, object> objectGraph, JsonOptions options = null)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            options = options ?? new JsonOptions();
            objectGraph = objectGraph ?? options.FinalObjectGraph;
            SetOptions(objectGraph, options);

            var total = 0L;
            if (writer is StreamWriter sw && (sw.BaseStream != null))
            {
                sw.Flush();
                return WriteBase64Stream(stream, sw.BaseStream, options);
            }

            if (writer is IndentedTextWriter itw && (itw.InnerWriter != null))
            {
                itw.Flush();
                return WriteBase64Stream(itw.InnerWriter, stream, objectGraph, options);
            }

            using (var ms = new MemoryStream())
            {
                var bytes = new byte[options.FinalStreamingBufferChunkSize];
                do
                {
                    var read = stream.Read(bytes, 0, bytes.Length);
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
            var b64 = new CryptoStream(outputStream, new ToBase64Transform(), CryptoStreamMode.Write);
            var total = 0L;
            var bytes = new byte[options.FinalStreamingBufferChunkSize];
            do
            {
                var read = inputStream.Read(bytes, 0, bytes.Length);
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
        private static bool InternalIsKeyValuePairEnumerable(Type type, out Type keyType, out Type valueType)
        {
            keyType = null;
            valueType = null;
            foreach (var t in type.GetInterfaces())
            {
                if (t.IsGenericType)
                {
                    if (typeof(IEnumerable<>).IsAssignableFrom(t.GetGenericTypeDefinition()))
                    {
                        var args = t.GetGenericArguments();
                        if (args.Length == 1)
                        {
                            var kvp = args[0];
                            if (kvp.IsGenericType && typeof(KeyValuePair<,>).IsAssignableFrom(kvp.GetGenericTypeDefinition()))
                            {
                                var kvpArgs = kvp.GetGenericArguments();
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
                var offset = TimeZoneInfo.Local.GetUtcOffset(dt);
                writer.Write(offset.Ticks >= 0 ? '+' : '-');
                writer.Write(Abs(offset.Hours).ToString(_d2Format));
                writer.Write(Abs(offset.Minutes).ToString(_d2Format));
            }
        }

        /// <summary>
        ///     Abses the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The float</returns>
        public static float Abs(float value) => value < 0f ? -value : value;

        /// <summary>
        ///     Writes an enumerable to a JSON writer.
        /// </summary>
        /// <param name="writer">The writer. May not be null.</param>
        /// <param name="array">The array. May not be null.</param>
        /// <param name="objectGraph">The object graph.</param>
        /// <param name="options">The options to use.</param>
        public static void WriteArray(TextWriter writer, Array array, IDictionary<object, object> objectGraph, JsonOptions options = null)
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
                    using (var ms = new MemoryStream(bytes))
                    {
                        ms.Position = 0;
                        WriteBase64Stream(writer, ms, objectGraph, options);
                    }

                    return;
                }
            }

#pragma warning disable CA1825 // Avoid zero-length array allocations
            WriteArray(writer, array, objectGraph, options, new int[0]);
#pragma warning restore CA1825 // Avoid zero-length array allocations
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
            var newIndices = new int[indices.Length + 1];
            for (var i = 0; i < indices.Length; i++)
            {
                newIndices[i] = indices[i];
            }

            writer.Write('[');
            for (var i = 0; i < array.GetLength(indices.Length); i++)
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
        public static void WriteEnumerable(TextWriter writer, IEnumerable enumerable, IDictionary<object, object> objectGraph, JsonOptions options = null)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));

            options = options ?? new JsonOptions();
            objectGraph = objectGraph ?? options.FinalObjectGraph;
            SetOptions(objectGraph, options);

            writer.Write('[');
            var first = true;
            foreach (var value in enumerable)
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
        public static void WriteDictionary(TextWriter writer, IDictionary dictionary, IDictionary<object, object> objectGraph, JsonOptions options = null)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            if (dictionary == null)
                throw new ArgumentNullException(nameof(dictionary));

            options = options ?? new JsonOptions();
            objectGraph = objectGraph ?? options.FinalObjectGraph;
            SetOptions(objectGraph, options);

            writer.Write('{');
            var first = true;
            foreach (DictionaryEntry entry in dictionary)
            {
                if (entry.Key == null)
                    continue;

                var entryKey = string.Format(CultureInfo.InvariantCulture, "{0}", entry.Key);
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
            var info = new SerializationInfo(serializable.GetType(), _defaultFormatterConverter);
            var ctx = new StreamingContext(StreamingContextStates.Remoting, null);
            serializable.GetObjectData(info, ctx);
            info.AddValue(_serializationTypeToken, serializable.GetType().AssemblyQualifiedName);

            var first = true;
            foreach (var entry in info)
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
        public static void WriteObject(TextWriter writer, object value, IDictionary<object, object> objectGraph, JsonOptions options = null)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            options = options ?? new JsonOptions();
            objectGraph = objectGraph ?? options.FinalObjectGraph;
            SetOptions(objectGraph, options);

            ISerializable serializable = null;
            var useISerializable = options.SerializationOptions.HasFlag(JsonSerializationOptions.UseISerializable) || ForceSerializable(value);
            if (useISerializable)
            {
                serializable = value as ISerializable;
            }

            writer.Write('{');

            if (options.BeforeWriteObjectCallback != null)
            {
                var e = new JsonEventArgs(writer, value, objectGraph, options)
                {
                    EventType = JsonEventType.BeforeWriteObject
                };
                options.BeforeWriteObjectCallback(e);
                if (e.Handled)
                    return;
            }

            var type = value.GetType();
            if (serializable != null)
            {
                WriteSerializable(writer, serializable, objectGraph, options);
            }
            else
            {
                var def = TypeDef.Get(type, options);
                def.WriteValues(writer, value, objectGraph, options);
            }

            if (options.AfterWriteObjectCallback != null)
            {
                var e = new JsonEventArgs(writer, value, objectGraph, options)
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

            var type = value.GetType();
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
        public static void WriteString(TextWriter writer, string text)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            if (text == null)
            {
                writer.Write(_null);
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
        public static void WriteUnescapedString(TextWriter writer, string text)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            if (text == null)
            {
                writer.Write(_null);
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
            sb.AppendFormat(CultureInfo.InvariantCulture, _x4Format, (ushort) c);
        }

        /// <summary>
        ///     Serializes an object with format. Note this is more for debugging purposes as it's not designed to be fast.
        /// </summary>
        /// <param name="value">The JSON object. May be null.</param>
        /// <param name="options">The options to use. May be null.</param>
        /// <returns>A string containing the formatted object.</returns>
        public static string SerializeFormatted(object value, JsonOptions options = null)
        {
            using (var sw = new StringWriter())
            {
                SerializeFormatted(sw, value, options);
                return sw.ToString();
            }
        }

        /// <summary>
        ///     Serializes an object with format. Note this is more for debugging purposes as it's not designed to be fast.
        /// </summary>
        /// <param name="writer">The output writer. May not be null.</param>
        /// <param name="value">The JSON object. May be null.</param>
        /// <param name="options">The options to use. May be null.</param>
        public static void SerializeFormatted(TextWriter writer, object value, JsonOptions options = null)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            options = options ?? new JsonOptions();
            var serialized = Serialize(value, options);
            var deserialized = Deserialize(serialized, typeof(object), options);
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
            using (var sw = new StringWriter())
            {
                WriteFormatted(sw, jsonObject, options);
                return sw.ToString();
            }
        }

        /// <summary>
        ///     Writes a JSON deserialized object formatted.
        /// </summary>
        /// <param name="writer">The output writer. May not be null.</param>
        /// <param name="jsonObject">The JSON object. May be null.</param>
        /// <param name="options">The options to use. May be null.</param>
        public static void WriteFormatted(TextWriter writer, object jsonObject, JsonOptions options = null)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            options = options ?? new JsonOptions();
            var itw = new IndentedTextWriter(writer, options.FormattingTab);
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
            if (jsonObject is DictionaryEntry entry)
            {
                var entryKey = string.Format(CultureInfo.InvariantCulture, "{0}", entry.Key);
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

            if (jsonObject is IDictionary dictionary)
            {
                writer.WriteLine('{');
                var first = true;
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

            if (jsonObject is string s)
            {
                WriteString(writer, s);
                return;
            }

            if (jsonObject is IEnumerable enumerable)
            {
                writer.WriteLine('[');
                var first = true;
                writer.Indent++;
                foreach (var obj in enumerable)
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

            WriteValue(writer, jsonObject, null, options);
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
            var startIndex = 0;
            var count = 0;
            for (var i = 0; i < value.Length; i++)
            {
                var c = value[i];
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
        public static bool TryGetValueByPath(this IDictionary<string, object> dictionary, string path, out object value)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            value = null;
            if (dictionary == null)
                return false;

            var segments = path.Split('.');
            var current = dictionary;
            for (var i = 0; i < segments.Length; i++)
            {
                var segment = segments[i].Nullify();
                if (segment == null)
                    return false;

                if (!current.TryGetValue(segment, out var newElement))
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
        private static T GetAttribute<T>(this PropertyDescriptor descriptor) where T : Attribute => GetAttribute<T>(descriptor.Attributes);

        /// <summary>
        ///     Gets the attribute using the specified attributes
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="attributes">The attributes</param>
        /// <returns>The</returns>
        private static T GetAttribute<T>(this AttributeCollection attributes) where T : Attribute
        {
            foreach (var att in attributes)
            {
                if (typeof(T).IsAssignableFrom(att.GetType()))
                    return (T) att;
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
        private static bool EqualsIgnoreCase(this string str, string text, bool trim = false)
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
        private static string Nullify(this string str)
        {
            if (str == null)
                return null;

            if (string.IsNullOrWhiteSpace(str))
                return null;

            var t = str.Trim();
            return t.Length == 0 ? null : t;
        }

        /// <summary>
        ///     Defines an object that handles list deserialization.
        /// </summary>
        public abstract class ListObject
        {
            /// <summary>
            ///     Gets or sets the list object.
            /// </summary>
            /// <value>
            ///     The list.
            /// </value>
            public virtual object List { get; set; }

            /// <summary>
            ///     Gets the current context.
            /// </summary>
            /// <value>
            ///     The context. May be null.
            /// </value>
            public virtual IDictionary<string, object> Context => null;

            /// <summary>
            ///     Clears the list object.
            /// </summary>
            public abstract void Clear();

            /// <summary>
            ///     Adds a value to the list object.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="options">The options.</param>
            public abstract void Add(object value, JsonOptions options = null);
        }

        /// <summary>
        ///     Defines an interface for setting or getting options.
        /// </summary>
        public interface IOptionsHolder
        {
            /// <summary>
            ///     Gets or sets the options.
            /// </summary>
            /// <value>The options.</value>
            JsonOptions Options { get; set; }
        }

        /// <summary>
        ///     Defines an interface for quick access to a type member.
        /// </summary>
        public interface IMemberAccessor
        {
            /// <summary>
            ///     Gets a component value.
            /// </summary>
            /// <param name="component">The component.</param>
            /// <returns>The value.</returns>
            object Get(object component);

            /// <summary>
            ///     Sets a component's value.
            /// </summary>
            /// <param name="component">The component.</param>
            /// <param name="value">The value to set.</param>
            void Set(object component, object value);
        }

        /// <summary>
        ///     Defines a type's member.
        /// </summary>
        public class MemberDefinition
        {
            /// <summary>
            ///     The accessor
            /// </summary>
            private IMemberAccessor _accessor;

            /// <summary>
            ///     The escaped wire name
            /// </summary>
            private string _escapedWireName;

            /// <summary>
            ///     The name
            /// </summary>
            private string _name;

            /// <summary>
            ///     The type
            /// </summary>
            private Type _type;

            /// <summary>
            ///     The wire name
            /// </summary>
            private string _wireName;

            /// <summary>
            ///     Gets or sets the member name.
            /// </summary>
            /// <value>
            ///     The name.
            /// </value>
            public virtual string Name
            {
                get => _name;
                set
                {
                    if (string.IsNullOrEmpty(value))
                        throw new ArgumentException(null, nameof(value));

                    _name = value;
                }
            }

            /// <summary>
            ///     Gets or sets the name used for serialization and deserialiation.
            /// </summary>
            /// <value>
            ///     The name used during serialization and deserialization.
            /// </value>
            public virtual string WireName
            {
                get => _wireName;
                set
                {
                    if (string.IsNullOrEmpty(value))
                        throw new ArgumentException(null, nameof(value));

                    _wireName = value;
                }
            }

            /// <summary>
            ///     Gets or sets the escaped name used during serialization and deserialiation.
            /// </summary>
            /// <value>
            ///     The escaped name used during serialization and deserialiation.
            /// </value>
            public virtual string EscapedWireName
            {
                get => _escapedWireName;
                set
                {
                    if (string.IsNullOrEmpty(value))
                        throw new ArgumentException(null, nameof(value));

                    _escapedWireName = value;
                }
            }

            /// <summary>
            ///     Gets or sets a value indicating whether this instance has default value.
            /// </summary>
            /// <value>
            ///     <c>true</c> if this instance has default value; otherwise, <c>false</c>.
            /// </value>
            public virtual bool HasDefaultValue { get; set; }

            /// <summary>
            ///     Gets or sets the default value.
            /// </summary>
            /// <value>
            ///     The default value.
            /// </value>
            public virtual object DefaultValue { get; set; }

            /// <summary>
            ///     Gets or sets the accessor.
            /// </summary>
            /// <value>
            ///     The accessor.
            /// </value>
            public virtual IMemberAccessor Accessor
            {
                get => _accessor;
                set => _accessor = value ?? throw new ArgumentNullException(nameof(value));
            }

            /// <summary>
            ///     Gets or sets the member type.
            /// </summary>
            /// <value>
            ///     The type.
            /// </value>
            public virtual Type Type
            {
                get => _type;
                set => _type = value ?? throw new ArgumentNullException(nameof(value));
            }

            /// <summary>
            ///     Returns a <see cref="string" /> that represents this instance.
            /// </summary>
            /// <returns>
            ///     A <see cref="string" /> that represents this instance.
            /// </returns>
            public override string ToString() => Name;

            /// <summary>
            ///     Gets or creates a member instance.
            /// </summary>
            /// <param name="target">The target.</param>
            /// <param name="elementsCount">The elements count.</param>
            /// <param name="options">The options.</param>
            /// <returns>A new or existing instance.</returns>
            public virtual object GetOrCreateInstance(object target, int elementsCount, JsonOptions options = null)
            {
                object targetValue;
                if (options.SerializationOptions.HasFlag(JsonSerializationOptions.ContinueOnValueError))
                {
                    try
                    {
                        targetValue = Accessor.Get(target);
                    }
                    catch
                    {
                        return null;
                    }
                }
                else
                {
                    targetValue = Accessor.Get(target);
                }

                // sufficient array?
                if (targetValue == null || (targetValue is Array array && (array.GetLength(0) < elementsCount)))
                {
                    if (Type.IsInterface)
                        return null;

                    targetValue = CreateInstance(target, Type, elementsCount, options, targetValue);
                    if (targetValue != null)
                    {
                        Accessor.Set(target, targetValue);
                    }
                }

                return targetValue;
            }

            /// <summary>
            ///     Applies the dictionary entry to this member.
            /// </summary>
            /// <param name="dictionary">The input dictionary.</param>
            /// <param name="target">The target object.</param>
            /// <param name="key">The entry key.</param>
            /// <param name="value">The entry value.</param>
            /// <param name="options">The options.</param>
            public virtual void ApplyEntry(IDictionary dictionary, object target, string key, object value, JsonOptions options = null)
            {
                if (options.ApplyEntryCallback != null)
                {
                    var og = new Dictionary<object, object>
                    {
                        ["dictionary"] = dictionary,
                        ["member"] = this
                    };

                    var e = new JsonEventArgs(null, value, og, options, key, target)
                    {
                        EventType = JsonEventType.ApplyEntry
                    };
                    options.ApplyEntryCallback(e);
                    if (e.Handled)
                        return;

                    value = e.Value;
                }

                if (value is IDictionary dic)
                {
                    var targetValue = GetOrCreateInstance(target, dic.Count, options);
                    Apply(dic, targetValue, options);
                    return;
                }

                var lo = GetListObject(Type, options, target, value, dictionary, key);
                if (lo != null)
                {
                    if (value is IEnumerable enumerable)
                    {
                        lo.List = GetOrCreateInstance(target, enumerable is ICollection coll ? coll.Count : 0, options);
                        ApplyToListTarget(target, enumerable, lo, options);
                        return;
                    }
                }


                var cvalue = ChangeType(target, value, Type, options);
                Accessor.Set(target, cvalue);
            }

            /// <summary>
            ///     Determines whether the specified value is equal to the zero value for its type.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <returns>true if the specified value is equal to the zero value.</returns>
            public virtual bool IsNullDateTimeValue(object value) => value == null || DateTime.MinValue.Equals(value);

            /// <summary>
            ///     Determines whether the specified value is equal to the zero value for its type.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <returns>true if the specified value is equal to the zero value.</returns>
            public virtual bool IsZeroValue(object value)
            {
                if (value == null)
                    return false;

                var type = value.GetType();
                if (type != Type)
                    return false;

                return IsZeroValueType(value);
            }

            /// <summary>
            ///     Determines if a value equals the default value.
            /// </summary>
            /// <param name="value">The value to compare.</param>
            /// <returns>true if both values are equal; false otherwise.</returns>
            public virtual bool EqualsDefaultValue(object value) => AreValuesEqual(DefaultValue, value);

            /// <summary>
            ///     Removes a deserialization member.
            /// </summary>
            /// <param name="type">The type. May not be null.</param>
            /// <param name="options">The options. May be null.</param>
            /// <param name="member">The member. May not be null.</param>
            /// <returns>true if item is successfully removed; otherwise, false.</returns>
            public static bool RemoveDeserializationMember(Type type, JsonOptions options, MemberDefinition member)
            {
                if (type == null)
                    throw new ArgumentNullException(nameof(type));

                if (member == null)
                    throw new ArgumentNullException(nameof(member));

                options = options ?? new JsonOptions();
                return TypeDef.RemoveDeserializationMember(type, options, member);
            }

            /// <summary>
            ///     Removes a serialization member.
            /// </summary>
            /// <param name="type">The type. May not be null.</param>
            /// <param name="options">The options. May be null.</param>
            /// <param name="member">The member. May not be null.</param>
            /// <returns>true if item is successfully removed; otherwise, false.</returns>
            public static bool RemoveSerializationMember(Type type, JsonOptions options, MemberDefinition member)
            {
                if (type == null)
                    throw new ArgumentNullException(nameof(type));

                if (member == null)
                    throw new ArgumentNullException(nameof(member));

                options = options ?? new JsonOptions();
                return TypeDef.RemoveSerializationMember(type, options, member);
            }

            /// <summary>
            ///     Adds a deserialization member.
            /// </summary>
            /// <param name="type">The type. May not be null.</param>
            /// <param name="options">The options. May be null.</param>
            /// <param name="member">The member. May not be null.</param>
            /// <returns>true if item is successfully added; otherwise, false.</returns>
            public static void AddDeserializationMember(Type type, JsonOptions options, MemberDefinition member)
            {
                if (type == null)
                    throw new ArgumentNullException(nameof(type));

                if (member == null)
                    throw new ArgumentNullException(nameof(member));

                options = options ?? new JsonOptions();
                TypeDef.AddDeserializationMember(type, options, member);
            }

            /// <summary>
            ///     Adds a serialization member.
            /// </summary>
            /// <param name="type">The type. May not be null.</param>
            /// <param name="options">The options. May be null.</param>
            /// <param name="member">The member. May not be null.</param>
            /// <returns>true if item is successfully added; otherwise, false.</returns>
            public static void AddSerializationMember(Type type, JsonOptions options, MemberDefinition member)
            {
                if (type == null)
                    throw new ArgumentNullException(nameof(type));

                if (member == null)
                    throw new ArgumentNullException(nameof(member));

                options = options ?? new JsonOptions();
                TypeDef.AddSerializationMember(type, options, member);
            }

            /// <summary>
            ///     Gets the serialization members for a given type.
            /// </summary>
            /// <param name="type">The type. May not be null.</param>
            /// <param name="options">The options. May be null.</param>
            /// <returns>A list of serialization members.</returns>
            public static MemberDefinition[] GetSerializationMembers(Type type, JsonOptions options = null)
            {
                if (type == null)
                    throw new ArgumentNullException(nameof(type));

                options = options ?? new JsonOptions();
                return TypeDef.GetSerializationMembers(type, options);
            }

            /// <summary>
            ///     Gets the deserialization members for a given type.
            /// </summary>
            /// <param name="type">The type. May not be null.</param>
            /// <param name="options">The options. May be null.</param>
            /// <returns>A list of deserialization members.</returns>
            public static MemberDefinition[] GetDeserializationMembers(Type type, JsonOptions options = null)
            {
                if (type == null)
                    throw new ArgumentNullException(nameof(type));

                options = options ?? new JsonOptions();
                return TypeDef.GetDeserializationMembers(type, options);
            }

            /// <summary>
            ///     Run a specified action, using the member definition lock.
            /// </summary>
            /// <typeparam name="T">The action input type.</typeparam>
            /// <param name="action">The action. May not be null.</param>
            /// <param name="state">The state. May be null.</param>
            public static void UsingLock<T>(Action<T> action, T state)
            {
                if (action == null)
                    throw new ArgumentNullException(nameof(action));

                TypeDef.Lock(action, state);
            }
        }

        /// <summary>
        ///     The key value type enumerator class
        /// </summary>
        /// <seealso cref="IDictionaryEnumerator" />
        private sealed class KeyValueTypeEnumerator : IDictionaryEnumerator
        {
            /// <summary>
            ///     The enumerator
            /// </summary>
            private readonly IEnumerator _enumerator;

            /// <summary>
            ///     The key prop
            /// </summary>
            private PropertyInfo _keyProp;

            /// <summary>
            ///     The value prop
            /// </summary>
            private PropertyInfo _valueProp;

            /// <summary>
            ///     Initializes a new instance of the <see cref="KeyValueTypeEnumerator" /> class
            /// </summary>
            /// <param name="value">The value</param>
            public KeyValueTypeEnumerator(object value) => _enumerator = ((IEnumerable) value).GetEnumerator();

            /// <summary>
            ///     Gets the value of the entry
            /// </summary>
            public DictionaryEntry Entry
            {
                get
                {
                    if (_keyProp == null)
                    {
                        _keyProp = _enumerator.Current.GetType().GetProperty("Key");
                        _valueProp = _enumerator.Current.GetType().GetProperty("Value");
                    }

                    return new DictionaryEntry(_keyProp.GetValue(_enumerator.Current, null), _valueProp.GetValue(_enumerator.Current, null));
                }
            }

            /// <summary>
            ///     Gets the value of the key
            /// </summary>
            public object Key => Entry.Key;

            /// <summary>
            ///     Gets the value of the value
            /// </summary>
            public object Value => Entry.Value;

            /// <summary>
            ///     Gets the value of the current
            /// </summary>
            public object Current => Entry;

            /// <summary>
            ///     Describes whether this instance move next
            /// </summary>
            /// <returns>The bool</returns>
            public bool MoveNext() => _enumerator.MoveNext();

            /// <summary>
            ///     Resets this instance
            /// </summary>
            public void Reset() => _enumerator.Reset();
        }

        /// <summary>
        ///     The key value type dictionary class
        /// </summary>
        /// <seealso cref="IDictionary" />
        private sealed class KeyValueTypeDictionary : IDictionary
        {
            /// <summary>
            ///     The enumerator
            /// </summary>
            private readonly KeyValueTypeEnumerator _enumerator;

            /// <summary>
            ///     Initializes a new instance of the <see cref="KeyValueTypeDictionary" /> class
            /// </summary>
            /// <param name="value">The value</param>
            public KeyValueTypeDictionary(object value) => _enumerator = new KeyValueTypeEnumerator(value);

            /// <summary>
            ///     Gets the value of the count
            /// </summary>
            public int Count => throw new NotSupportedException();

            /// <summary>
            ///     Gets the value of the is synchronized
            /// </summary>
            public bool IsSynchronized => throw new NotSupportedException();

            /// <summary>
            ///     Gets the value of the sync root
            /// </summary>
            public object SyncRoot => throw new NotSupportedException();

            /// <summary>
            ///     Gets the value of the is fixed size
            /// </summary>
            public bool IsFixedSize => throw new NotSupportedException();

            /// <summary>
            ///     Gets the value of the is read only
            /// </summary>
            public bool IsReadOnly => throw new NotSupportedException();

            /// <summary>
            ///     Gets the value of the keys
            /// </summary>
            public ICollection Keys => throw new NotSupportedException();

            /// <summary>
            ///     Gets the value of the values
            /// </summary>
            public ICollection Values => throw new NotSupportedException();

            /// <summary>
            ///     The not supported exception
            /// </summary>
            public object this[object key]
            {
                get => throw new NotSupportedException();
                set => throw new NotSupportedException();
            }

            /// <summary>
            ///     Adds the key
            /// </summary>
            /// <param name="key">The key</param>
            /// <param name="value">The value</param>
            public void Add(object key, object value) => throw new NotSupportedException();

            /// <summary>
            ///     Clears this instance
            /// </summary>
            public void Clear() => throw new NotSupportedException();

            /// <summary>
            ///     Describes whether this instance contains
            /// </summary>
            /// <param name="key">The key</param>
            /// <returns>The bool</returns>
            public bool Contains(object key) => throw new NotSupportedException();

            /// <summary>
            ///     Gets the enumerator
            /// </summary>
            /// <returns>The dictionary enumerator</returns>
            public IDictionaryEnumerator GetEnumerator() => _enumerator;

            /// <summary>
            ///     Removes the key
            /// </summary>
            /// <param name="key">The key</param>
            public void Remove(object key) => throw new NotSupportedException();

            /// <summary>
            ///     Copies the to using the specified array
            /// </summary>
            /// <param name="array">The array</param>
            /// <param name="index">The index</param>
            public void CopyTo(Array array, int index) => throw new NotSupportedException();

            /// <summary>
            ///     Gets the enumerator
            /// </summary>
            /// <returns>The enumerator</returns>
            IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
        }

        /// <summary>
        ///     The key value type class
        /// </summary>
        private sealed class KeyValueType
        {
            /// <summary>
            ///     The key type
            /// </summary>
            public Type KeyType;

            /// <summary>
            ///     The value type
            /// </summary>
            public Type ValueType;
        }

        /// <summary>
        ///     The type def class
        /// </summary>
        private sealed class TypeDef
        {
            /// <summary>
            ///     The type def
            /// </summary>
            private static readonly Dictionary<string, TypeDef> _defs = new Dictionary<string, TypeDef>();

            /// <summary>
            ///     The key value type
            /// </summary>
            private static readonly Dictionary<Type, KeyValueType> _iskvpe = new Dictionary<Type, KeyValueType>();

            /// <summary>
            ///     The lock
            /// </summary>
            private static readonly object _lock = new object();

            /// <summary>
            ///     The member definition
            /// </summary>
            private readonly List<MemberDefinition> _deserializationMembers = new List<MemberDefinition>();

            /// <summary>
            ///     The member definition
            /// </summary>
            private readonly List<MemberDefinition> _serializationMembers = new List<MemberDefinition>();

            /// <summary>
            ///     The type
            /// </summary>
            private readonly Type _type;

            /// <summary>
            ///     Initializes a new instance of the <see cref="TypeDef" /> class
            /// </summary>
            /// <param name="type">The type</param>
            /// <param name="options">The options</param>
            private TypeDef(Type type, JsonOptions options)
            {
                _type = type;
                IEnumerable<MemberDefinition> members;
                if (options.SerializationOptions.HasFlag(JsonSerializationOptions.UseReflection))
                {
                    members = EnumerateDefinitionsUsingReflection(true, type, options);
                }
                else
                {
                    members = EnumerateDefinitionsUsingTypeDescriptors(true, type, options);
                }

                _serializationMembers = new List<MemberDefinition>(options.FinalizeSerializationMembers(type, members));

                if (options.SerializationOptions.HasFlag(JsonSerializationOptions.UseReflection))
                {
                    members = EnumerateDefinitionsUsingReflection(false, type, options);
                }
                else
                {
                    members = EnumerateDefinitionsUsingTypeDescriptors(false, type, options);
                }

                _deserializationMembers = new List<MemberDefinition>(options.FinalizeDeserializationMembers(type, members));
            }

            /// <summary>
            ///     Gets the deserialization member using the specified key
            /// </summary>
            /// <param name="key">The key</param>
            /// <returns>The member definition</returns>
            private MemberDefinition GetDeserializationMember(string key)
            {
                if (key == null)
                    return null;

                foreach (var def in _deserializationMembers)
                {
                    if (string.Compare(def.WireName, key, StringComparison.OrdinalIgnoreCase) == 0)
                        return def;
                }

                return null;
            }

            /// <summary>
            ///     Applies the entry using the specified dictionary
            /// </summary>
            /// <param name="dictionary">The dictionary</param>
            /// <param name="target">The target</param>
            /// <param name="key">The key</param>
            /// <param name="value">The value</param>
            /// <param name="options">The options</param>
            public void ApplyEntry(IDictionary dictionary, object target, string key, object value, JsonOptions options)
            {
                var member = GetDeserializationMember(key);
                if (member == null)
                    return;

                member.ApplyEntry(dictionary, target, key, value, options);
            }

            /// <summary>
            ///     Writes the values using the specified writer
            /// </summary>
            /// <param name="writer">The writer</param>
            /// <param name="component">The component</param>
            /// <param name="objectGraph">The object graph</param>
            /// <param name="options">The options</param>
            public void WriteValues(TextWriter writer, object component, IDictionary<object, object> objectGraph, JsonOptions options)
            {
                var first = true;
                foreach (var member in _serializationMembers)
                {
                    var nameChanged = false;
                    var name = member.WireName;
                    var value = member.Accessor.Get(component);
                    if (options.WriteNamedValueObjectCallback != null)
                    {
                        var e = new JsonEventArgs(writer, value, objectGraph, options, name, component)
                        {
                            EventType = JsonEventType.WriteNamedValueObject,
                            First = first
                        };
                        options.WriteNamedValueObjectCallback(e);
                        first = e.First;
                        if (e.Handled)
                            continue;

                        nameChanged = name != e.Name;
                        name = e.Name;
                        value = e.Value;
                    }

                    if (options.SerializationOptions.HasFlag(JsonSerializationOptions.SkipNullPropertyValues))
                    {
                        if (value == null)
                            continue;
                    }

                    if (options.SerializationOptions.HasFlag(JsonSerializationOptions.SkipZeroValueTypes))
                    {
                        if (member.IsZeroValue(value))
                            continue;
                    }

                    if (options.SerializationOptions.HasFlag(JsonSerializationOptions.SkipNullDateTimeValues))
                    {
                        if (member.IsNullDateTimeValue(value))
                            continue;
                    }

                    var skipDefaultValues = options.SerializationOptions.HasFlag(JsonSerializationOptions.SkipDefaultValues);
                    if (skipDefaultValues && member.HasDefaultValue)
                    {
                        if (member.EqualsDefaultValue(value))
                            continue;
                    }

                    if (!first)
                    {
                        writer.Write(',');
                    }
                    else
                    {
                        first = false;
                    }

                    if (nameChanged)
                    {
                        WriteNameValue(writer, name, value, objectGraph, options);
                    }
                    else
                    {
                        if (options.SerializationOptions.HasFlag(JsonSerializationOptions.WriteKeysWithoutQuotes))
                        {
                            writer.Write(member.EscapedWireName);
                        }
                        else
                        {
                            writer.Write('"');
                            writer.Write(member.EscapedWireName);
                            writer.Write('"');
                        }

                        writer.Write(':');
                        WriteValue(writer, value, objectGraph, options);
                    }
                }
            }

            /// <summary>
            ///     Returns the string
            /// </summary>
            /// <returns>The string</returns>
            public override string ToString() => _type.AssemblyQualifiedName;

            /// <summary>
            ///     Gets the key using the specified type
            /// </summary>
            /// <param name="type">The type</param>
            /// <param name="options">The options</param>
            /// <returns>The string</returns>
            private static string GetKey(Type type, JsonOptions options) => type.AssemblyQualifiedName + '\0' + options.GetCacheKey();

            /// <summary>
            ///     Unlockeds the get using the specified type
            /// </summary>
            /// <param name="type">The type</param>
            /// <param name="options">The options</param>
            /// <returns>The ta</returns>
            private static TypeDef UnlockedGet(Type type, JsonOptions options)
            {
                var key = GetKey(type, options);
                if (!_defs.TryGetValue(key, out var ta))
                {
                    ta = new TypeDef(type, options);
                    _defs.Add(key, ta);
                }

                return ta;
            }

            /// <summary>
            ///     Locks the action
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <param name="action">The action</param>
            /// <param name="state">The state</param>
            public static void Lock<T>(Action<T> action, T state)
            {
                lock (_lock)
                {
                    action(state);
                }
            }

            /// <summary>
            ///     Describes whether remove deserialization member
            /// </summary>
            /// <param name="type">The type</param>
            /// <param name="options">The options</param>
            /// <param name="member">The member</param>
            /// <returns>The bool</returns>
            public static bool RemoveDeserializationMember(Type type, JsonOptions options, MemberDefinition member)
            {
                lock (_lock)
                {
                    var ta = UnlockedGet(type, options);
                    return ta._deserializationMembers.Remove(member);
                }
            }

            /// <summary>
            ///     Describes whether remove serialization member
            /// </summary>
            /// <param name="type">The type</param>
            /// <param name="options">The options</param>
            /// <param name="member">The member</param>
            /// <returns>The bool</returns>
            public static bool RemoveSerializationMember(Type type, JsonOptions options, MemberDefinition member)
            {
                lock (_lock)
                {
                    var ta = UnlockedGet(type, options);
                    return ta._serializationMembers.Remove(member);
                }
            }

            /// <summary>
            ///     Adds the deserialization member using the specified type
            /// </summary>
            /// <param name="type">The type</param>
            /// <param name="options">The options</param>
            /// <param name="member">The member</param>
            public static void AddDeserializationMember(Type type, JsonOptions options, MemberDefinition member)
            {
                lock (_lock)
                {
                    var ta = UnlockedGet(type, options);
                    ta._deserializationMembers.Add(member);
                }
            }

            /// <summary>
            ///     Adds the serialization member using the specified type
            /// </summary>
            /// <param name="type">The type</param>
            /// <param name="options">The options</param>
            /// <param name="member">The member</param>
            public static void AddSerializationMember(Type type, JsonOptions options, MemberDefinition member)
            {
                lock (_lock)
                {
                    var ta = UnlockedGet(type, options);
                    ta._serializationMembers.Add(member);
                }
            }

            /// <summary>
            ///     Gets the deserialization members using the specified type
            /// </summary>
            /// <param name="type">The type</param>
            /// <param name="options">The options</param>
            /// <returns>The member definition array</returns>
            public static MemberDefinition[] GetDeserializationMembers(Type type, JsonOptions options)
            {
                lock (_lock)
                {
                    var ta = UnlockedGet(type, options);
                    return ta._deserializationMembers.ToArray();
                }
            }

            /// <summary>
            ///     Gets the serialization members using the specified type
            /// </summary>
            /// <param name="type">The type</param>
            /// <param name="options">The options</param>
            /// <returns>The member definition array</returns>
            public static MemberDefinition[] GetSerializationMembers(Type type, JsonOptions options)
            {
                lock (_lock)
                {
                    var ta = UnlockedGet(type, options);
                    return ta._serializationMembers.ToArray();
                }
            }

            /// <summary>
            ///     Gets the type
            /// </summary>
            /// <param name="type">The type</param>
            /// <param name="options">The options</param>
            /// <returns>The type def</returns>
            public static TypeDef Get(Type type, JsonOptions options)
            {
                lock (_lock)
                {
                    return UnlockedGet(type, options);
                }
            }

            /// <summary>
            ///     Describes whether is key value pair enumerable
            /// </summary>
            /// <param name="type">The type</param>
            /// <param name="keyType">The key type</param>
            /// <param name="valueType">The value type</param>
            /// <returns>The bool</returns>
            public static bool IsKeyValuePairEnumerable(Type type, out Type keyType, out Type valueType)
            {
                lock (_lock)
                {
                    if (!_iskvpe.TryGetValue(type, out var kv))
                    {
                        kv = new KeyValueType();
                        InternalIsKeyValuePairEnumerable(type, out kv.KeyType, out kv.ValueType);
                        _iskvpe.Add(type, kv);
                    }

                    keyType = kv.KeyType;
                    valueType = kv.ValueType;
                    return kv.KeyType != null;
                }
            }

            /// <summary>
            ///     Enumerates the definitions using reflection using the specified serialization
            /// </summary>
            /// <param name="serialization">The serialization</param>
            /// <param name="type">The type</param>
            /// <param name="options">The options</param>
            /// <returns>An enumerable of member definition</returns>
            private static IEnumerable<MemberDefinition> EnumerateDefinitionsUsingReflection(bool serialization, Type type, JsonOptions options)
            {
                foreach (var info in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (options.SerializationOptions.HasFlag(JsonSerializationOptions.UseJsonAttribute))
                    {
                        var ja = GetJsonAttribute(info);
                        if (ja != null)
                        {
                            if (serialization && ja.IgnoreWhenSerializing)
                                continue;

                            if (!serialization && ja.IgnoreWhenDeserializing)
                                continue;
                        }
                    }

                    if (options.SerializationOptions.HasFlag(JsonSerializationOptions.UseXmlIgnore))
                    {
                        if (info.IsDefined(typeof(XmlIgnoreAttribute), true))
                            continue;
                    }

                    if (options.SerializationOptions.HasFlag(JsonSerializationOptions.UseScriptIgnore))
                    {
                        if (HasScriptIgnore(info))
                            continue;
                    }

                    if (serialization)
                    {
                        if (!info.CanRead)
                            continue;

                        var getMethod = info.GetGetMethod();
                        if (getMethod == null || getMethod.GetParameters().Length > 0)
                            continue;
                    }
                    // else we don't test the set method, as some properties can still be deserialized (collections)

                    var name = GetObjectName(info, info.Name);

                    var ma = new MemberDefinition
                    {
                        Type = info.PropertyType,
                        Name = info.Name
                    };
                    if (serialization)
                    {
                        ma.WireName = name;
                        ma.EscapedWireName = EscapeString(name);
                    }
                    else
                    {
                        ma.WireName = name;
                    }

                    ma.HasDefaultValue = TryGetObjectDefaultValue(info, out var defaultValue);
                    ma.DefaultValue = defaultValue;
                    ma.Accessor = (IMemberAccessor) Activator.CreateInstance(typeof(PropertyInfoAccessor<,>).MakeGenericType(info.DeclaringType, info.PropertyType), info);
                    yield return ma;
                }

                if (options.SerializationOptions.HasFlag(JsonSerializationOptions.SerializeFields))
                {
                    foreach (var info in type.GetFields(BindingFlags.Public | BindingFlags.Instance))
                    {
                        if (options.SerializationOptions.HasFlag(JsonSerializationOptions.UseJsonAttribute))
                        {
                            var ja = GetJsonAttribute(info);
                            if (ja != null)
                            {
                                if (serialization && ja.IgnoreWhenSerializing)
                                    continue;

                                if (!serialization && ja.IgnoreWhenDeserializing)
                                    continue;
                            }
                        }

                        if (options.SerializationOptions.HasFlag(JsonSerializationOptions.UseXmlIgnore))
                        {
                            if (info.IsDefined(typeof(XmlIgnoreAttribute), true))
                                continue;
                        }

                        if (options.SerializationOptions.HasFlag(JsonSerializationOptions.UseScriptIgnore))
                        {
                            if (HasScriptIgnore(info))
                                continue;
                        }

                        var name = GetObjectName(info, info.Name);

                        var ma = new MemberDefinition
                        {
                            Type = info.FieldType,
                            Name = info.Name
                        };
                        if (serialization)
                        {
                            ma.WireName = name;
                            ma.EscapedWireName = EscapeString(name);
                        }
                        else
                        {
                            ma.WireName = name;
                        }

                        ma.HasDefaultValue = TryGetObjectDefaultValue(info, out var defaultValue);
                        ma.DefaultValue = defaultValue;
                        ma.Accessor = (IMemberAccessor) Activator.CreateInstance(typeof(FieldInfoAccessor), info);
                        yield return ma;
                    }
                }
            }

            /// <summary>
            ///     Enumerates the definitions using type descriptors using the specified serialization
            /// </summary>
            /// <param name="serialization">The serialization</param>
            /// <param name="type">The type</param>
            /// <param name="options">The options</param>
            /// <returns>An enumerable of member definition</returns>
            private static IEnumerable<MemberDefinition> EnumerateDefinitionsUsingTypeDescriptors(bool serialization, Type type, JsonOptions options)
            {
                foreach (var descriptor in TypeDescriptor.GetProperties(type).Cast<PropertyDescriptor>())
                {
                    if (options.SerializationOptions.HasFlag(JsonSerializationOptions.UseJsonAttribute))
                    {
                        var ja = descriptor.GetAttribute<JsonAttribute>();
                        if (ja != null)
                        {
                            if (serialization && ja.IgnoreWhenSerializing)
                                continue;

                            if (!serialization && ja.IgnoreWhenDeserializing)
                                continue;
                        }
                    }

                    if (options.SerializationOptions.HasFlag(JsonSerializationOptions.UseXmlIgnore))
                    {
                        if (descriptor.GetAttribute<XmlIgnoreAttribute>() != null)
                            continue;
                    }

                    if (options.SerializationOptions.HasFlag(JsonSerializationOptions.UseScriptIgnore))
                    {
                        if (HasScriptIgnore(descriptor))
                            continue;
                    }

                    if (options.SerializationOptions.HasFlag(JsonSerializationOptions.SkipGetOnly) && descriptor.IsReadOnly)
                        continue;

                    var name = GetObjectName(descriptor, descriptor.Name);

                    var ma = new MemberDefinition
                    {
                        Type = descriptor.PropertyType,
                        Name = descriptor.Name
                    };
                    if (serialization)
                    {
                        ma.WireName = name;
                        ma.EscapedWireName = EscapeString(name);
                    }
                    else
                    {
                        ma.WireName = name;
                    }

                    ma.HasDefaultValue = TryGetObjectDefaultValue(descriptor, out var defaultValue);
                    ma.DefaultValue = defaultValue;
                    ma.Accessor = (IMemberAccessor) Activator.CreateInstance(typeof(PropertyDescriptorAccessor), descriptor);
                    yield return ma;
                }
            }
        }

        /// <summary>
        ///     A utility class to compare object by their reference.
        /// </summary>
        public sealed class ReferenceComparer : IEqualityComparer<object>
        {
            /// <summary>
            ///     Gets the instance of the ReferenceComparer class.
            /// </summary>
            public static readonly ReferenceComparer Instance = new ReferenceComparer();

            /// <summary>
            ///     Initializes a new instance of the <see cref="ReferenceComparer" /> class
            /// </summary>
            private ReferenceComparer()
            {
            }

            /// <summary>
            ///     Describes whether this instance equals
            /// </summary>
            /// <param name="x">The </param>
            /// <param name="y">The </param>
            /// <returns>The bool</returns>
            bool IEqualityComparer<object>.Equals(object x, object y) => ReferenceEquals(x, y);

            /// <summary>
            ///     Gets the hash code using the specified obj
            /// </summary>
            /// <param name="obj">The obj</param>
            /// <returns>The int</returns>
            int IEqualityComparer<object>.GetHashCode(object obj) => RuntimeHelpers.GetHashCode(obj);
        }

        /// <summary>
        ///     The collection object class
        /// </summary>
        /// <seealso cref="ListObject" />
        private sealed class ICollectionTObject<T> : ListObject
        {
            /// <summary>
            ///     The coll
            /// </summary>
            private ICollection<T> _coll;

            /// <summary>
            ///     Gets or sets the value of the list
            /// </summary>
            public override object List
            {
                get => base.List;
                set
                {
                    base.List = value;
                    _coll = (ICollection<T>) value;
                }
            }

            /// <summary>
            ///     Clears this instance
            /// </summary>
            public override void Clear() => _coll.Clear();

            /// <summary>
            ///     Adds the value
            /// </summary>
            /// <param name="value">The value</param>
            /// <param name="options">The options</param>
            public override void Add(object value, JsonOptions options = null)
            {
                if ((value == null) && typeof(T).IsValueType)
                {
                    HandleException(new JsonException("JSO0014: JSON error detected. Cannot add null to a collection of '" + typeof(T) + "' elements."), options);
                }

                _coll.Add((T) value);
            }
        }

        /// <summary>
        ///     The list object class
        /// </summary>
        /// <seealso cref="ListObject" />
        private sealed class IListObject : ListObject
        {
            /// <summary>
            ///     The list
            /// </summary>
            private IList _list;

            /// <summary>
            ///     Gets or sets the value of the list
            /// </summary>
            public override object List
            {
                get => base.List;
                set
                {
                    base.List = value;
                    _list = (IList) value;
                }
            }

            /// <summary>
            ///     Clears this instance
            /// </summary>
            public override void Clear() => _list.Clear();

            /// <summary>
            ///     Adds the value
            /// </summary>
            /// <param name="value">The value</param>
            /// <param name="options">The options</param>
            public override void Add(object value, JsonOptions options = null) => _list.Add(value);
        }

        /// <summary>
        ///     The field info accessor class
        /// </summary>
        /// <seealso cref="IMemberAccessor" />
        private sealed class FieldInfoAccessor : IMemberAccessor
        {
            /// <summary>
            ///     The fi
            /// </summary>
            private readonly FieldInfo _fi;

            /// <summary>
            ///     Initializes a new instance of the <see cref="FieldInfoAccessor" /> class
            /// </summary>
            /// <param name="fi">The fi</param>
            public FieldInfoAccessor(FieldInfo fi) => _fi = fi;

            /// <summary>
            ///     Gets the component
            /// </summary>
            /// <param name="component">The component</param>
            /// <returns>The object</returns>
            public object Get(object component) => _fi.GetValue(component);

            /// <summary>
            ///     Sets the component
            /// </summary>
            /// <param name="component">The component</param>
            /// <param name="value">The value</param>
            public void Set(object component, object value) => _fi.SetValue(component, value);
        }

        /// <summary>
        ///     The property descriptor accessor class
        /// </summary>
        /// <seealso cref="IMemberAccessor" />
        private sealed class PropertyDescriptorAccessor : IMemberAccessor
        {
            /// <summary>
            ///     The pd
            /// </summary>
            private readonly PropertyDescriptor _pd;

            /// <summary>
            ///     Initializes a new instance of the <see cref="PropertyDescriptorAccessor" /> class
            /// </summary>
            /// <param name="pd">The pd</param>
            public PropertyDescriptorAccessor(PropertyDescriptor pd) => _pd = pd;

            /// <summary>
            ///     Gets the component
            /// </summary>
            /// <param name="component">The component</param>
            /// <returns>The object</returns>
            public object Get(object component) => _pd.GetValue(component);

            /// <summary>
            ///     Sets the component
            /// </summary>
            /// <param name="component">The component</param>
            /// <param name="value">The value</param>
            public void Set(object component, object value)
            {
                if (_pd.IsReadOnly)
                    return;

                _pd.SetValue(component, value);
            }
        }

        // note: Funcs & Action<T> needs .NET 4+
        /// <summary>
        ///     The func
        /// </summary>
        private delegate TResult JFunc<T, TResult>(T arg);

        /// <summary>
        ///     The action
        /// </summary>
        private delegate void JAction<T1, T2>(T1 arg1, T2 arg2);

        /// <summary>
        ///     The property info accessor class
        /// </summary>
        /// <seealso cref="IMemberAccessor" />
        private sealed class PropertyInfoAccessor<TComponent, TMember> : IMemberAccessor
        {
            /// <summary>
            ///     The get
            /// </summary>
            private readonly JFunc<TComponent, TMember> _get;

            /// <summary>
            ///     The set
            /// </summary>
            private readonly JAction<TComponent, TMember> _set;

            /// <summary>
            ///     Initializes a new instance of the <see cref="PropertyInfoAccessor" /> class
            /// </summary>
            /// <param name="pi">The pi</param>
            public PropertyInfoAccessor(PropertyInfo pi)
            {
                var get = pi.GetGetMethod();
                if (get != null)
                {
                    _get = (JFunc<TComponent, TMember>) Delegate.CreateDelegate(typeof(JFunc<TComponent, TMember>), get);
                }

                var set = pi.GetSetMethod();
                if (set != null)
                {
                    _set = (JAction<TComponent, TMember>) Delegate.CreateDelegate(typeof(JAction<TComponent, TMember>), set);
                }
            }

            /// <summary>
            ///     Gets the component
            /// </summary>
            /// <param name="component">The component</param>
            /// <returns>The object</returns>
            public object Get(object component)
            {
                if (_get == null)
                    return null;

                return _get((TComponent) component);
            }

            /// <summary>
            ///     Sets the component
            /// </summary>
            /// <param name="component">The component</param>
            /// <param name="value">The value</param>
            public void Set(object component, object value)
            {
                if (_set == null)
                    return;

                _set((TComponent) component, (TMember) value);
            }
        }

        /// <summary>
        ///     The conversions class
        /// </summary>
        private static class Conversions
        {
            /// <summary>
            ///     The enum separators
            /// </summary>
            private static readonly char[] _enumSeparators = {',', ';', '+', '|', ' '};

            /// <summary>
            ///     The date formats utc
            /// </summary>
            private static readonly string[] _dateFormatsUtc = {"yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'", "yyyy'-'MM'-'dd'T'HH':'mm'Z'", "yyyyMMdd'T'HH':'mm':'ss'Z'"};

            /// <summary>
            ///     Describes whether is valid
            /// </summary>
            /// <param name="dt">The dt</param>
            /// <returns>The bool</returns>
            private static bool IsValid(DateTime dt) => (dt != DateTime.MinValue) && (dt != DateTime.MaxValue) && (dt.Kind != DateTimeKind.Unspecified);

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
                if (!TryChangeType(input, provider, out T value))
                    return defaultValue;

                return value;
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
            public static bool TryChangeType<T>(object input, IFormatProvider provider, out T value)
            {
                if (!TryChangeType(input, typeof(T), provider, out var tvalue))
                {
                    value = default(T);
                    return false;
                }

                value = (T) tvalue;
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
                if (!TryChangeType(input, conversionType, provider, out var value))
                {
                    if (TryChangeType(defaultValue, conversionType, provider, out var def))
                        return def;

                    if (IsReallyValueType(conversionType))
                        return Activator.CreateInstance(conversionType);

                    return null;
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
            public static bool TryChangeType(object input, Type conversionType, IFormatProvider provider, out object value)
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

                    var type = conversionType.GetGenericArguments()[0];
                    if (TryChangeType(input, type, provider, out var vtValue))
                    {
                        var nt = typeof(Nullable<>).MakeGenericType(type);
                        value = Activator.CreateInstance(nt, vtValue);
                        return true;
                    }

                    value = null;
                    return false;
                }

                value = IsReallyValueType(conversionType) ? Activator.CreateInstance(conversionType) : null;
                if (input == null)
                    return !IsReallyValueType(conversionType);

                var inputType = input.GetType();
                if (conversionType.IsAssignableFrom(inputType))
                {
                    value = input;
                    return true;
                }

                if (conversionType.IsEnum)
                    return EnumTryParse(conversionType, input, out value);

                if (inputType.IsEnum)
                {
                    var tc = Type.GetTypeCode(inputType);
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
                    var svalue = string.Format(provider, "{0}", input).Nullify();
                    if ((svalue != null) && Guid.TryParse(svalue, out var guid))
                    {
                        value = guid;
                        return true;
                    }

                    return false;
                }

                if (conversionType == typeof(Uri))
                {
                    var svalue = string.Format(provider, "{0}", input).Nullify();
                    if ((svalue != null) && Uri.TryCreate(svalue, UriKind.RelativeOrAbsolute, out var uri))
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
                        var dt = (DateTime) input;
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
                        value = ((DateTime) value).TimeOfDay;
                        return true;
                    }

                    if (inputType == typeof(DateTimeOffset))
                    {
                        value = ((DateTimeOffset) value).TimeOfDay;
                        return true;
                    }

                    if (TryChangeType(input, provider, out string sv) && TimeSpan.TryParse(sv, provider, out var ts))
                    {
                        value = ts;
                        return true;
                    }
                }

                var isGenericList = IsGenericList(conversionType, out var elementType);
                if (conversionType.IsArray || isGenericList)
                {
                    if (input is IEnumerable enumerable)
                    {
                        if (!isGenericList)
                        {
                            elementType = conversionType.GetElementType();
                        }

                        var list = (IList) Activator.CreateInstance(typeof(List<>).MakeGenericType(elementType));
                        var count = 0;
                        foreach (var obj in enumerable)
                        {
                            count++;
                            if (TryChangeType(obj, elementType, provider, out var element))
                            {
                                list.Add(element);
                            }
                        }

                        // at least one was converted
                        if ((count > 0) && (list.Count > 0))
                        {
                            if (isGenericList)
                            {
                                value = list;
                            }
                            else
                            {
                                value = list.GetType().GetMethod(nameof(List<object>.ToArray)).Invoke(list, null);
                            }

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

                        var si = input?.ToString();
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
                    if (true.Equals(input))
                    {
                        value = true;
                        return true;
                    }

                    if (false.Equals(input))
                    {
                        value = false;
                        return true;
                    }

                    var svalue = string.Format(provider, "{0}", input).Nullify();
                    if (svalue == null)
                        return false;

                    if (bool.TryParse(svalue, out var b))
                    {
                        value = b;
                        return true;
                    }

                    if (svalue.EqualsIgnoreCase("y") || svalue.EqualsIgnoreCase("yes"))
                    {
                        value = true;
                        return true;
                    }

                    if (svalue.EqualsIgnoreCase("n") || svalue.EqualsIgnoreCase("no"))
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
                bool isWellKnownConvertible() => conversionType == typeof(short) || conversionType == typeof(int) ||
                                                 conversionType == typeof(string) || conversionType == typeof(byte) ||
                                                 conversionType == typeof(char) || conversionType == typeof(DateTime) ||
                                                 conversionType == typeof(DBNull) || conversionType == typeof(decimal) ||
                                                 conversionType == typeof(double) || conversionType.IsEnum ||
                                                 conversionType == typeof(short) || conversionType == typeof(int) ||
                                                 conversionType == typeof(long) || conversionType == typeof(sbyte) ||
                                                 conversionType == typeof(bool) || conversionType == typeof(float) ||
                                                 conversionType == typeof(ushort) || conversionType == typeof(uint) ||
                                                 conversionType == typeof(ulong);

                if (isWellKnownConvertible() && input is IConvertible convertible)
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

                if (input != null)
                {
                    var inputConverter = TypeDescriptor.GetConverter(input);
                    if (inputConverter != null)
                    {
                        if (inputConverter.CanConvertTo(conversionType))
                        {
                            try
                            {
                                value = inputConverter.ConvertTo(null, provider as CultureInfo, input, conversionType);
                                return true;
                            }
                            catch
                            {
                                // continue;
                            }
                        }
                    }
                }

                var converter = TypeDescriptor.GetConverter(conversionType);
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
            public static ulong EnumToUInt64(object value)
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                var typeCode = Convert.GetTypeCode(value);
#pragma warning disable IDE0010 // Add missing cases
#pragma warning disable IDE0066 // Convert switch statement to expression
                switch (typeCode)
#pragma warning restore IDE0066 // Convert switch statement to expression
#pragma warning restore IDE0010 // Add missing cases
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
            private static bool StringToEnum(Type type, string[] names, Array values, string input, out object value)
            {
                for (var i = 0; i < names.Length; i++)
                {
                    if (names[i].EqualsIgnoreCase(input))
                    {
                        value = values.GetValue(i);
                        return true;
                    }
                }

                for (var i = 0; i < values.GetLength(0); i++)
                {
                    var valuei = values.GetValue(i);
                    if ((input.Length > 0) && (input[0] == '-'))
                    {
                        var ul = (long) EnumToUInt64(valuei);
                        if (ul.ToString().EqualsIgnoreCase(input))
                        {
                            value = valuei;
                            return true;
                        }
                    }
                    else
                    {
                        var ul = EnumToUInt64(valuei);
                        if (ul.ToString().EqualsIgnoreCase(input))
                        {
                            value = valuei;
                            return true;
                        }
                    }
                }

                if (char.IsDigit(input[0]) || input[0] == '-' || input[0] == '+')
                {
                    var obj = EnumToObject(type, input);
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
            public static object EnumToObject(Type enumType, object value)
            {
                if (enumType == null)
                    throw new ArgumentNullException(nameof(enumType));

                if (!enumType.IsEnum)
                    throw new ArgumentException(null, nameof(enumType));

                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                var underlyingType = Enum.GetUnderlyingType(enumType);
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
            public static object ToEnum(string text, Type enumType)
            {
                if (enumType == null)
                    throw new ArgumentNullException(nameof(enumType));

                EnumTryParse(enumType, text, out var value);
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
            public static bool EnumTryParse(Type type, object input, out object value)
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

                var stringInput = string.Format(CultureInfo.InvariantCulture, "{0}", input);
                stringInput = stringInput.Nullify();
                if (stringInput == null)
                {
                    value = Activator.CreateInstance(type);
                    return false;
                }

                if (stringInput.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                {
                    if (ulong.TryParse(stringInput.Substring(2), NumberStyles.HexNumber, null, out var ulx))
                    {
                        value = ToEnum(ulx.ToString(CultureInfo.InvariantCulture), type);
                        return true;
                    }
                }

                var names = Enum.GetNames(type);
                if (names.Length == 0)
                {
                    value = Activator.CreateInstance(type);
                    return false;
                }

                var values = Enum.GetValues(type);
                // some enums like System.CodeDom.MemberAttributes *are* flags but are not declared with Flags...
                if (!type.IsDefined(typeof(FlagsAttribute), true) && (stringInput.IndexOfAny(_enumSeparators) < 0))
                    return StringToEnum(type, names, values, stringInput, out value);

                // multi value enum
                var tokens = stringInput.Split(_enumSeparators, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 0)
                {
                    value = Activator.CreateInstance(type);
                    return false;
                }

                ulong ul = 0;
                foreach (var tok in tokens)
                {
                    var token = tok.Nullify(); // NOTE: we don't consider empty tokens as errors
                    if (token == null)
                        continue;

                    if (!StringToEnum(type, names, values, token, out var tokenValue))
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
            public static bool IsGenericList(Type type, out Type elementType)
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
            private static bool IsReallyValueType(Type type)
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
            public static bool IsNullable(Type type)
            {
                if (type == null)
                    throw new ArgumentNullException(nameof(type));

                return type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(Nullable<>));
            }
        }
    }
}