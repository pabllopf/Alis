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
        internal const string Null = "null";
        
        /// <summary>
        ///     The true
        /// </summary>
        internal const string True = "true";
        
        /// <summary>
        ///     The false
        /// </summary>
        internal const string False = "false";
        
        /// <summary>
        ///     The zero arg
        /// </summary>
        internal const string ZeroArg = "{0}";
        
        /// <summary>
        ///     The date start js
        /// </summary>
        internal const string DateStartJs = "new Date(";
        
        /// <summary>
        ///     The date end js
        /// </summary>
        internal const string DateEndJs = ")";
        
        /// <summary>
        ///     The date start
        /// </summary>
        internal const string DateStart = @"""\/Date(";
        
        /// <summary>
        ///     The date start
        /// </summary>
        internal const string DateStart2 = @"/Date(";
        
        /// <summary>
        ///     The date end
        /// </summary>
        internal const string DateEnd = @")\/""";
        
        /// <summary>
        ///     The date end
        /// </summary>
        internal const string DateEnd2 = @")/";
        
        /// <summary>
        ///     The round trip format
        /// </summary>
        internal const string RoundTripFormat = "R";
        
        /// <summary>
        ///     The enum format
        /// </summary>
        internal const string EnumFormat = "D";
        
        /// <summary>
        ///     The format
        /// </summary>
        internal const string X4Format = "{0:X4}";
        
        /// <summary>
        ///     The format
        /// </summary>
        internal const string D2Format = "D2";
        
        /// <summary>
        ///     The script ignore
        /// </summary>
        internal const string ScriptIgnore = "ScriptIgnore";
        
        /// <summary>
        ///     The serialization type token
        /// </summary>
        internal const string SerializationTypeToken = "__type";
        
        /// <summary>
        ///     The date formats utc
        /// </summary>
        internal static readonly string[] DateFormatsUtc = {@"yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'", "yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'", "yyyy'-'MM'-'dd'T'HH':'mm'Z'", "yyyyMMdd'T'HH':'mm':'ss'Z'"};
        
        /// <summary>
        ///     The utc
        /// </summary>
        internal static readonly DateTime MinDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        
        /// <summary>
        ///     The ticks
        /// </summary>
        internal static readonly long MinDateTimeTicks = MinDateTime.Ticks;
        
        /// <summary>
        ///     The formatter converter
        /// </summary>
        internal static readonly FormatterConverter DefaultFormatterConverter = new FormatterConverter();
        
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
        internal static void Serialize(TextWriter writer, object value, JsonOptions options = null)
        {
            ValidateWriter(writer);
            
            options = options ?? new JsonOptions();
            PrepareOptions(options);
            
            WriteJsonPStart(writer, options);
            WriteValue(writer, value, options.FinalObjectGraph, options);
            WriteJsonPEnd(writer, options);
        }
        
        /// <summary>
        ///     Validates the writer using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <exception cref="ArgumentNullException"></exception>
        internal static void ValidateWriter(TextWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }
        }
        
        /// <summary>
        ///     Prepares the options using the specified options
        /// </summary>
        /// <param name="options">The options</param>
        internal static void PrepareOptions(JsonOptions options)
        {
            IDictionary<object, object> objectGraph = options.FinalObjectGraph;
            SetOptions(objectGraph, options);
        }
        
        /// <summary>
        ///     Writes the json p start using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="options">The options</param>
        internal static void WriteJsonPStart(TextWriter writer, JsonOptions options)
        {
            string jsonp = options.JsonPCallback.Nullify();
            if (jsonp != null)
            {
                writer.Write(options.JsonPCallback);
                writer.Write('(');
            }
        }
        
        /// <summary>
        ///     Writes the json p end using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="options">The options</param>
        internal static void WriteJsonPEnd(TextWriter writer, JsonOptions options)
        {
            string jsonp = options.JsonPCallback.Nullify();
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
                {
                    return null;
                }
                
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
        /// Deserializes the reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="targetType">The target type</param>
        /// <param name="options">The options</param>
        /// <returns>The object</returns>
        internal static object Deserialize(TextReader reader, Type targetType = null, JsonOptions options = null)
        {
            ValidateReader(reader);
            options = InitOptions(options);
            
            if (IsTargetTypeNullOrObject(targetType))
            {
                return ReadValue(reader, options);
            }
            
            object value = ReadValue(reader, options);
            return ConvertToTargetType(value, targetType, options);
        }
        
        /// <summary>
        /// Validates the reader using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <exception cref="ArgumentNullException"></exception>
        internal static void ValidateReader(TextReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }
        }
        
        /// <summary>
        /// Inits the options using the specified options
        /// </summary>
        /// <param name="options">The options</param>
        /// <returns>The json options</returns>
        internal static JsonOptions InitOptions(JsonOptions options)
        {
            return options ?? new JsonOptions();
        }
        
        /// <summary>
        /// Describes whether is target type null or object
        /// </summary>
        /// <param name="targetType">The target type</param>
        /// <returns>The bool</returns>
        internal static bool IsTargetTypeNullOrObject(Type targetType)
        {
            return targetType == null || targetType == typeof(object);
        }
        
        /// <summary>
        /// Converts the to target type using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="targetType">The target type</param>
        /// <param name="options">The options</param>
        /// <returns>The object</returns>
        internal static object ConvertToTargetType(object value, Type targetType, JsonOptions options)
        {
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
            {
                return;
            }
            
            using StringReader reader = new StringReader(text);
            DeserializeToTarget(reader, target, options);
        }
        
        /// <summary>
        ///     Deserializes data from the specified TextReader and populates a specified object instance.
        /// </summary>
        /// <param name="reader">The input reader. May not be null.</param>
        /// <param name="target">The object instance to populate.</param>
        /// <param name="options">Options to use for deserialization.</param>
        internal static void DeserializeToTarget(TextReader reader, object target, JsonOptions options = null)
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }
            
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }
            
            object value = ReadValue(reader, options);
            Apply(value, target, options);
        }
        
        /// <summary>
        ///     Applies the input
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="target">The target</param>
        /// <param name="options">The options</param>
        internal static void Apply(object input, object target, JsonOptions options = null)
        {
            options ??= new JsonOptions();
            
            if (target is Array array)
            {
                ApplyToArray(input, array, options);
            }
            else if (input is IDictionary dic)
            {
                ApplyToDictionary(dic, target, options);
            }
            else
            {
                ApplyToList(input, target, options);
            }
        }
        
        /// <summary>
        ///     Applies the to array using the specified input
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="array">The array</param>
        /// <param name="options">The options</param>
        internal static void ApplyToArray(object input, Array array, JsonOptions options)
        {
            if (!array.IsReadOnly)
            {
                ApplyToTargetArray(input as IEnumerable, array, options);
            }
        }
        
        /// <summary>
        ///     Applies the to dictionary using the specified dic
        /// </summary>
        /// <param name="dic">The dic</param>
        /// <param name="target">The target</param>
        /// <param name="options">The options</param>
        internal static void ApplyToDictionary(IDictionary dic, object target, JsonOptions options)
        {
            ApplyToTargetDictionary(dic, target, options);
        }
        
        /// <summary>
        ///     Applies the to list using the specified input
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="target">The target</param>
        /// <param name="options">The options</param>
        internal static void ApplyToList(object input, object target, JsonOptions options)
        {
            if (target != null)
            {
                ApplyToListTarget(input as IEnumerable, target, options);
            }
        }
        
        /// <summary>
        ///     Applies the to target array using the specified input
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="target">The target</param>
        /// <param name="options">The options</param>
        internal static void ApplyToTargetArray(IEnumerable input, Array target, JsonOptions options)
        {
            Apply(input, target, options);
        }
        
        /// <summary>
        ///     Applies the to target dictionary using the specified input
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="target">The target</param>
        /// <param name="options">The options</param>
        internal static void ApplyToTargetDictionary(IDictionary input, object target, JsonOptions options)
        {
            Apply(input, target, options);
        }
        
        /// <summary>
        ///     Applies the to list target using the specified input
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="target">The target</param>
        /// <param name="options">The options</param>
        internal static void ApplyToListTarget(IEnumerable input, object target, JsonOptions options)
        {
            ListObject listObject = GetListObject(target.GetType(), options, target, input, null, null);
            if (listObject != null)
            {
                listObject.List = target;
                ApplyToListTarget(target, input, listObject, options);
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
                object instance = InvokeCreateInstanceCallback(target, type, elementsCount, options, value);
                if (instance != null)
                {
                    return instance;
                }
                
                if (type.IsArray)
                {
                    return CreateArrayInstance(type, elementsCount);
                }
                
                return Activator.CreateInstance(type);
            }
            catch (Exception e)
            {
                return HandleCreationException(type, e, options);
            }
        }
        
        /// <summary>
        ///     Invokes the create instance callback using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="type">The type</param>
        /// <param name="elementsCount">The elements count</param>
        /// <param name="options">The options</param>
        /// <param name="value">The value</param>
        /// <returns>The object</returns>
        internal static object InvokeCreateInstanceCallback(object target, Type type, int elementsCount, JsonOptions options, object value)
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
                {
                    return e.Value;
                }
            }
            
            return null;
        }
        
        /// <summary>
        ///     Creates the array instance using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="elementsCount">The elements count</param>
        /// <returns>The array</returns>
        internal static Array CreateArrayInstance(Type type, int elementsCount)
        {
            Type elementType = type.GetElementType();
            return elementType != null ? Array.CreateInstance(elementType, elementsCount) : null;
        }
        
        /// <summary>
        ///     Handles the creation exception using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="e">The </param>
        /// <param name="options">The options</param>
        /// <returns>The object</returns>
        internal static object HandleCreationException(Type type, Exception e, JsonOptions options)
        {
            HandleException(new JsonException($"JSOM0001: JSON error detected. Cannot create an instance of the '{type.Name}' type.", e), options);
            return null;
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
                JsonEventArgs eventArgs = CreateJsonEventArgs(type, dictionary, value, options, key, target);
                options.GetListObjectCallback(eventArgs);
                if (eventArgs.Handled)
                {
                    return eventArgs.Value as ListObject;
                }
            }
            
            if (type == typeof(byte[]))
            {
                return null;
            }
            
            if (typeof(IList).IsAssignableFrom(type))
            {
                return new CustomListObject();
            }
            
            if (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(ICollection<>)))
            {
                return CreateGenericListObject(type);
            }
            
            return CreateListObjectFromInterfaces(type);
        }
        
        /// <summary>
        ///     Creates the json event args using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="dictionary">The dictionary</param>
        /// <param name="value">The value</param>
        /// <param name="options">The options</param>
        /// <param name="key">The key</param>
        /// <param name="target">The target</param>
        /// <returns>The event args</returns>
        internal static JsonEventArgs CreateJsonEventArgs(Type type, IDictionary dictionary, object value, JsonOptions options, string key, object target)
        {
            JsonEventArgs eventArgs = new JsonEventArgs(null, value, new Dictionary<object, object> {["dictionary"] = dictionary, ["type"] = type}, options, key, target)
            {
                EventType = JsonEventType.GetListObject
            };
            
            return eventArgs;
        }
        
        /// <summary>
        ///     Creates the generic list object using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The list object</returns>
        internal static ListObject CreateGenericListObject(Type type)
        {
            Type genericType = type.GetGenericArguments()[0];
            Type listObjectType = typeof(CollectionTObject<>).MakeGenericType(genericType);
            
            return (ListObject) Activator.CreateInstance(listObjectType);
        }
        
        /// <summary>
        ///     Creates the list object from interfaces using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The list object</returns>
        internal static ListObject CreateListObjectFromInterfaces(Type type)
        {
            foreach (Type iFace in type.GetInterfaces())
            {
                if (iFace.IsGenericType && (iFace.GetGenericTypeDefinition() == typeof(ICollection<>)))
                {
                    return CreateGenericListObject(iFace);
                }
            }
            
            return null;
        }
        
        /// <summary>
        ///     Applies the input to the list target using the specified target.
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="input">The input</param>
        /// <param name="list">The list</param>
        /// <param name="options">The options</param>
        internal static void ApplyToListTarget(object target, IEnumerable input, ListObject list, JsonOptions options)
        {
            if (list.List == null)
            {
                return;
            }
            
            InitializeListContext(list, target, input, options);
            ProcessInputBasedOnCondition(target, input, list, options);
            ClearContextIfNotNull(list);
        }
        
        /// <summary>
        ///     Processes the input based on condition using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="input">The input</param>
        /// <param name="list">The list</param>
        /// <param name="options">The options</param>
        internal static void ProcessInputBasedOnCondition(object target, IEnumerable input, ListObject list, JsonOptions options)
        {
            if (input != null)
            {
                ProcessInput(target, input, list, options);
            }
            else
            {
                ClearList(list);
            }
        }
        
        /// <summary>
        ///     Clears the context if not null using the specified list
        /// </summary>
        /// <param name="list">The list</param>
        internal static void ClearContextIfNotNull(ListObject list) => list.Context?.Clear();
        
        /// <summary>
        ///     Initializes the list context using the specified list
        /// </summary>
        /// <param name="list">The list</param>
        /// <param name="target">The target</param>
        /// <param name="input">The input</param>
        /// <param name="options">The options</param>
        internal static void InitializeListContext(ListObject list, object target, IEnumerable input, JsonOptions options)
        {
            if (list.Context != null)
            {
                list.Context["action"] = "init";
                list.Context["target"] = target;
                list.Context["input"] = input;
                list.Context["options"] = options;
            }
        }
        
        /// <summary>
        ///     Processes the input using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="input">The input</param>
        /// <param name="list">The list</param>
        /// <param name="options">The options</param>
        internal static void ProcessInput(object target, IEnumerable input, ListObject list, JsonOptions options)
        {
            Array array = list.List as Array;
            Type itemType = GetItemType(list.List.GetType());
            
            if (array != null)
            {
                ProcessArrayInput(target, input, array, itemType, options);
            }
            else
            {
                ProcessListInput(target, input, list, itemType, options);
            }
        }
        
        /// <summary>
        ///     Processes the array input using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="input">The input</param>
        /// <param name="array">The array</param>
        /// <param name="itemType">The item type</param>
        /// <param name="options">The options</param>
        internal static void ProcessArrayInput(object target, IEnumerable input, Array array, Type itemType, JsonOptions options)
        {
            int maxIndex = array.GetUpperBound(0);
            int currentIndex = array.GetLowerBound(0);
            
            foreach (object value in input)
            {
                if (currentIndex - 1 == maxIndex)
                {
                    break;
                }
                
                object convertedValue = ChangeType(target, value, itemType, options);
                array.SetValue(convertedValue, currentIndex++);
            }
        }
        
        /// <summary>
        ///     Processes the list input using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="input">The input</param>
        /// <param name="list">The list</param>
        /// <param name="itemType">The item type</param>
        /// <param name="options">The options</param>
        internal static void ProcessListInput(object target, IEnumerable input, ListObject list, Type itemType, JsonOptions options)
        {
            foreach (object value in input)
            {
                object convertedValue = ChangeType(target, value, itemType, options);
                convertedValue = UpdateValueBasedOnContext(list, itemType, value, convertedValue);
                list.Add(convertedValue, options);
            }
        }
        
        /// <summary>
        ///     Updates the value based on context using the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="itemType">The item type.</param>
        /// <param name="value">The value.</param>
        /// <param name="convertedValue">The converted value.</param>
        /// <returns>The updated value.</returns>
        internal static object UpdateValueBasedOnContext(ListObject list, Type itemType, object value, object convertedValue)
        {
            if (list.Context == null)
            {
                return convertedValue;
            }
            
            UpdateContextIfNeeded(list, itemType, value, convertedValue);
            
            return GetUpdatedValue(list, convertedValue);
        }
        
        /// <summary>
        ///     Updates the context if needed using the specified list
        /// </summary>
        /// <param name="list">The list</param>
        /// <param name="itemType">The item type</param>
        /// <param name="value">The value</param>
        /// <param name="convertedValue">The converted value</param>
        internal static void UpdateContextIfNeeded(ListObject list, Type itemType, object value, object convertedValue)
        {
            if (list.Context != null)
            {
                UpdateContext(list, itemType, value, convertedValue);
            }
        }
        
        /// <summary>
        ///     Gets the updated value using the specified list
        /// </summary>
        /// <param name="list">The list</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The object</returns>
        internal static object GetUpdatedValue(ListObject list, object defaultValue) => list.Context.TryGetValue("cvalue", out object updatedValue) ? updatedValue : defaultValue;
        
        /// <summary>
        ///     Updates the context using the specified list
        /// </summary>
        /// <param name="list">The list</param>
        /// <param name="itemType">The item type</param>
        /// <param name="value">The value</param>
        /// <param name="convertedValue">The converted value</param>
        internal static void UpdateContext(ListObject list, Type itemType, object value, object convertedValue)
        {
            list.Context["action"] = "add";
            list.Context["itemType"] = itemType;
            list.Context["value"] = value;
            list.Context["cvalue"] = convertedValue;
        }
        
        /// <summary>
        ///     Clears the list using the specified list
        /// </summary>
        /// <param name="list">The list</param>
        internal static void ClearList(ListObject list)
        {
            if (list.Context != null)
            {
                list.Context["action"] = "clear";
            }
            
            list.Clear();
        }
        
        /// <summary>
        ///     Applies the input
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="target">The target</param>
        /// <param name="options">The options</param>
        internal static void Apply(IEnumerable input, Array target, JsonOptions options)
        {
            if (!IsValidTarget(target))
            {
                return;
            }
            
            Type elementType = target.GetType().GetElementType();
            HandleInput(input, target, elementType, options);
        }
        
        /// <summary>
        /// Describes whether is valid target
        /// </summary>
        /// <param name="target">The target</param>
        /// <returns>The bool</returns>
        private static bool IsValidTarget(Array target)
        {
            return target is {Rank: 1};
        }
        
        /// <summary>
        /// Handles the input using the specified input
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="target">The target</param>
        /// <param name="elementType">The element type</param>
        /// <param name="options">The options</param>
        private static void HandleInput(IEnumerable input, Array target, Type elementType, JsonOptions options)
        {
            if (input != null)
            {
                SetValuesInTarget(input, target, elementType, options);
            }
            else
            {
                Array.Clear(target, 0, target.Length);
            }
        }
        
        /// <summary>
        /// Sets the values in target using the specified input
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="target">The target</param>
        /// <param name="elementType">The element type</param>
        /// <param name="options">The options</param>
        private static void SetValuesInTarget(IEnumerable input, Array target, Type elementType, JsonOptions options)
        {
            int i = 0;
            foreach (object value in input)
            {
                target.SetValue(ChangeType(target, value, elementType, options), i++);
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
            {
                return true;
            }
            
            return (o1 != null) && o1.Equals(o2);
        }
        
        /// <summary>
        ///     Describes whether try get object default value
        /// </summary>
        /// <param name="att">The att</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool TryGetObjectDefaultValue(Attribute att, out object value)
        {
            switch (att)
            {
                case JsonPropertyNameAttribute {HasDefaultValue: true} jsa:
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
        internal static string GetObjectName(Attribute att)
        {
            return att switch
            {
                JsonPropertyNameAttribute jsonPropertyNameAttribute when !string.IsNullOrEmpty(jsonPropertyNameAttribute.Name) => jsonPropertyNameAttribute.Name,
                XmlAttributeAttribute xmlAttributeAttribute when !string.IsNullOrEmpty(xmlAttributeAttribute.AttributeName) => xmlAttributeAttribute.AttributeName,
                XmlElementAttribute xmlElementAttribute when !string.IsNullOrEmpty(xmlElementAttribute.ElementName) => xmlElementAttribute.ElementName,
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
                {
                    return true;
                }
            }
            
            value = null;
            return false;
        }
        
        /// <summary>
        ///     Gets the object name using the specified member info
        /// </summary>
        /// <param name="memberInfo">The member info</param>
        /// <param name="defaultName">The default name</param>
        /// <returns>The object name if found, otherwise the default name</returns>
        internal static string GetObjectName(MemberInfo memberInfo, string defaultName)
        {
            IEnumerable<Attribute> attributes = memberInfo.GetCustomAttributes(true).OfType<Attribute>();
            
            foreach (Attribute attribute in attributes)
            {
                string name = GetObjectName(attribute);
                if (!string.IsNullOrEmpty(name))
                {
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
        internal static bool TryGetObjectDefaultValue(PropertyDescriptor pd, out object value)
        {
            foreach (Attribute att in pd.Attributes.Cast<Attribute>())
            {
                if (TryGetObjectDefaultValue(att, out value))
                {
                    return true;
                }
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
                {
                    return name;
                }
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
        ///     Checks if the member has a ScriptIgnore attribute
        /// </summary>
        /// <param name="member">The member to check</param>
        /// <returns>True if the member has a ScriptIgnore attribute, false otherwise</returns>
        internal static bool HasScriptIgnore(MemberInfo member)
        {
            object[] attributes = member.GetCustomAttributes(true);
            
            return attributes.OfType<Attribute>().Any(attribute => attribute.GetType().Name.StartsWith(ScriptIgnore));
        }
        
        //
        /// <summary>
        ///     Applies the dictionary
        /// </summary>
        /// <param name="dictionary">The dictionary</param>
        /// <param name="target">The target</param>
        /// <param name="options">The options</param>
        internal static void Apply(IDictionary dictionary, object target, JsonOptions options)
        {
            if (dictionary == null || target == null)
            {
                return;
            }
            
            if (target is IDictionary dicTarget)
            {
                ApplyToDictionaryTarget(dicTarget, dictionary, options);
            }
            else
            {
                ApplyToNonDictionaryTarget(target, dictionary, options);
            }
        }
        
        /// <summary>
        ///     Applies the values from the source dictionary to the target dictionary.
        /// </summary>
        /// <param name="targetDictionary">The target dictionary to which values are applied</param>
        /// <param name="sourceDictionary">The source dictionary from which values are taken</param>
        /// <param name="options">The JsonOptions used for type conversion</param>
        internal static void ApplyToDictionaryTarget(IDictionary targetDictionary, IDictionary sourceDictionary, JsonOptions options)
        {
            Type itemType = GetItemType(targetDictionary.GetType());
            
            foreach (DictionaryEntry entry in sourceDictionary)
            {
                if (entry.Key == null)
                {
                    continue;
                }
                
                object value = itemType == typeof(object) ? entry.Value : ChangeType(targetDictionary, entry.Value, itemType, options);
                targetDictionary[entry.Key] = value;
            }
        }
        
        /// <summary>
        ///     Applies the to non dictionary target using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="dictionary">The dictionary</param>
        /// <param name="options">The options</param>
        internal static void ApplyToNonDictionaryTarget(object target, IDictionary dictionary, JsonOptions options)
        {
            TypeDef typeDefinition = TypeDef.Get(target.GetType(), options);
            
            foreach (DictionaryEntry entry in dictionary)
            {
                ProcessDictionaryEntry(target, dictionary, options, typeDefinition, entry);
            }
        }
        
        /// <summary>
        ///     Processes the dictionary entry using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="dictionary">The dictionary</param>
        /// <param name="options">The options</param>
        /// <param name="typeDefinition">The type definition</param>
        /// <param name="entry">The entry</param>
        internal static void ProcessDictionaryEntry(object target, IDictionary dictionary, JsonOptions options, TypeDef typeDefinition, DictionaryEntry entry)
        {
            if (entry.Key == null)
            {
                return;
            }
            
            string entryKey = entry.Key.ToString();
            object entryValue = entry.Value;
            
            ProcessMapEntryCallback(options, dictionary, ref entryKey, ref entryValue, target);
            
            typeDefinition.ApplyEntry(dictionary, target, entryKey, entryValue, options);
        }
        
        /// <summary>
        ///     Processes the map entry callback using the specified options
        /// </summary>
        /// <param name="options">The options</param>
        /// <param name="dictionary">The dictionary</param>
        /// <param name="entryKey">The entry key</param>
        /// <param name="entryValue">The entry value</param>
        /// <param name="target">The target</param>
        internal static void ProcessMapEntryCallback(JsonOptions options, IDictionary dictionary, ref string entryKey, ref object entryValue, object target)
        {
            if (options.MapEntryCallback == null)
            {
                return;
            }
            
            Dictionary<object, object> originalValues = new Dictionary<object, object>
            {
                ["dictionary"] = dictionary
            };
            
            JsonEventArgs eventArgs = new JsonEventArgs(null, entryValue, originalValues, options, entryKey, target)
            {
                EventType = JsonEventType.MapEntry
            };
            
            options.MapEntryCallback(eventArgs);
            
            if (eventArgs.Handled)
            {
                return;
            }
            
            entryKey = eventArgs.Name;
            entryValue = eventArgs.Value;
        }
        
        /// <summary>
        ///     Gets the json attribute using the specified pi
        /// </summary>
        /// <param name="pi">The pi</param>
        /// <returns>The json attribute</returns>
        internal static JsonPropertyNameAttribute GetJsonAttribute(MemberInfo pi)
        {
            object[] attributes = pi.GetCustomAttributes(true);
            
            foreach (object attribute in attributes)
            {
                if (attribute is JsonPropertyNameAttribute jsonAttribute)
                {
                    return jsonAttribute;
                }
            }
            
            return null;
        }
        
        /// <summary>
        ///     Gets the type of elements in a collection type.
        /// </summary>
        /// <param name="collectionType">The collection type.</param>
        /// <returns>The element type or typeof(object) if it was not determined.</returns>
        internal static Type GetItemType(Type collectionType)
        {
            if (collectionType == null)
            {
                throw new ArgumentNullException(nameof(collectionType));
            }
            
            Type[] genericInterfaces = collectionType.GetInterfaces()
                .Where(i => i.IsGenericType)
                .ToArray();
            
            Type[] genericDefinitions =
            {
                typeof(IDictionary<,>),
                typeof(IList<>),
                typeof(ICollection<>),
                typeof(IEnumerable<>)
            };
            
            foreach (Type definition in genericDefinitions)
            {
                Type foundInterface = genericInterfaces
                    .FirstOrDefault(i => i.GetGenericTypeDefinition() == definition);
                
                if (foundInterface != null)
                {
                    return GetGenericArgument(foundInterface, definition);
                }
            }
            
            return typeof(object);
        }
        
        /// <summary>
        ///     Gets the generic argument using the specified found interface
        /// </summary>
        /// <param name="foundInterface">The found interface</param>
        /// <param name="definition">The definition</param>
        /// <returns>The type</returns>
        internal static Type GetGenericArgument(Type foundInterface, Type definition) => definition == typeof(IDictionary<,>)
            ? foundInterface.GetGenericArguments()[1]
            : foundInterface.GetGenericArguments()[0];
        
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
        public static object ChangeType(object value, Type conversionType, JsonOptions options)
        {
            if (value == null)
            {
                if (!conversionType.IsValueType || (conversionType.IsGenericType && (conversionType.GetGenericTypeDefinition() == typeof(Nullable<>))))
                {
                    return null;
                }
            }
            
            return ChangeType(null, value, conversionType, options);
        }
        
        /// <summary>
        ///     Changes the type using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="value">The value</param>
        /// <param name="conversionType">The conversion type</param>
        /// <param name="options">The options</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>The object</returns>
        public static object ChangeType(object target, object value, Type conversionType, JsonOptions options = null)
        {
            if (conversionType == null)
            {
                throw new ArgumentNullException(nameof(conversionType));
            }
            
            if (conversionType == typeof(object) || value == null)
            {
                return HandleNullValue(conversionType, value);
            }
            
            options ??= new JsonOptions();
            
            if (value is IDictionary dic)
            {
                return HandleDictionary(target, conversionType, dic, options);
            }
            
            if (value is string strValue)
            {
                return HandleStringValue(conversionType, strValue, options);
            }
            
            return HandleNonString(target, value, conversionType, options);
        }
        
        /// <summary>
        ///     Handles the null value using the specified conversion type
        /// </summary>
        /// <param name="conversionType">The conversion type</param>
        /// <param name="value">The value</param>
        /// <returns>The object</returns>
        internal static object HandleNullValue(Type conversionType, object value) => conversionType == typeof(object) ? value : Activator.CreateInstance(conversionType);
        
        /// <summary>
        ///     Handles the string value using the specified conversion type
        /// </summary>
        /// <param name="conversionType">The conversion type</param>
        /// <param name="value">The value</param>
        /// <param name="options">The options</param>
        /// <returns>The object</returns>
        internal static object HandleStringValue(Type conversionType, string value, JsonOptions options)
        {
            if (conversionType == typeof(byte[]))
            {
                return HandleByteArray(value, options);
            }
            
            if (conversionType == typeof(DateTime))
            {
                return HandleDateTime(value, options);
            }
            
            if (conversionType == typeof(TimeSpan))
            {
                return HandleTimeSpan(value);
            }
            
            return Conversions.ChangeType(value, conversionType, null, null);
        }
        
        /// <summary>
        ///     Handles the dictionary using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="conversionType">The conversion type</param>
        /// <param name="dic">The dic</param>
        /// <param name="options">The options</param>
        /// <returns>The instance</returns>
        internal static object HandleDictionary(object target, Type conversionType, IDictionary dic, JsonOptions options)
        {
            object instance = CreateInstance(target, conversionType, 0, options, dic);
            if (instance != null)
            {
                Apply(dic, instance, options);
            }
            
            return instance;
        }
        
        /// <summary>
        ///     Handles the non string using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="value">The value</param>
        /// <param name="conversionType">The conversion type</param>
        /// <param name="options">The options</param>
        /// <returns>The value</returns>
        internal static object HandleNonString(object target, object value, Type conversionType, JsonOptions options)
        {
            if (conversionType.IsArray && value is IEnumerable en)
            {
                return HandleArray(target, en, conversionType, options);
            }
            
            ListObject lo = GetListObject(conversionType, options, target, value, null, null);
            if ((lo != null) && value is IEnumerable en2)
            {
                return HandleListObject(target, en2, lo, conversionType, value, options);
            }
            
            return value;
        }
        
        /// <summary>
        ///     Handles the array using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="en">The en</param>
        /// <param name="conversionType">The conversion type</param>
        /// <param name="options">The options</param>
        /// <returns>The object</returns>
        internal static object HandleArray(object target, IEnumerable en, Type conversionType, JsonOptions options)
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
            
            return null;
        }
        
        /// <summary>
        ///     Handles the list object using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="en">The en</param>
        /// <param name="lo">The lo</param>
        /// <param name="conversionType">The conversion type</param>
        /// <param name="value">The value</param>
        /// <param name="options">The options</param>
        /// <returns>The object</returns>
        internal static object HandleListObject(object target, IEnumerable en, ListObject lo, Type conversionType, object value, JsonOptions options)
        {
            lo.List = CreateInstance(target, conversionType, en is ICollection coll ? coll.Count : 0, options, value);
            ApplyToListTarget(target, en, lo, options);
            return lo.List;
        }
        
        /// <summary>
        ///     Handles the byte array using the specified string.
        /// </summary>
        /// <param name="base64String">The base64 string.</param>
        /// <param name="options">The JSON options.</param>
        /// <returns>The byte array if the string can be converted, otherwise the original string.</returns>
        internal static object HandleByteArray(string base64String, JsonOptions options)
        {
            if (!options.SerializationOptions.HasFlag(JsonSerializationOptions.ByteArrayAsBase64))
            {
                return base64String;
            }
            
            try
            {
                return Convert.FromBase64String(base64String);
            }
            catch (Exception e)
            {
                HandleException(new JsonException("JSO0013: JSON deserialization error with a base64 array as string.", e), options);
                return null;
            }
        }
        
        /// <summary>
        ///     Handles the date time using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="options">The options</param>
        /// <returns>The value</returns>
        internal static object HandleDateTime(object value, JsonOptions options)
        {
            if (value is DateTime)
            {
                return value;
            }
            
            string sValue = string.Format(CultureInfo.InvariantCulture, "{0}", value);
            if (!string.IsNullOrEmpty(sValue))
            {
                if (TryParseDateTime(sValue, options.DateTimeStyles, out DateTime dt))
                {
                    return dt;
                }
            }
            
            return value;
        }
        
        /// <summary>
        ///     Handles the time span using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The value</returns>
        internal static object HandleTimeSpan(object value)
        {
            string sValue = string.Format(CultureInfo.InvariantCulture, "{0}", value);
            if (!string.IsNullOrEmpty(sValue))
            {
                if (long.TryParse(sValue, out long ticks))
                {
                    return new TimeSpan(ticks);
                }
            }
            
            return value;
        }
        
        /// <summary>
        ///     Reads the array using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <returns>The object array</returns>
        internal static object[] ReadArray(TextReader reader, JsonOptions options)
        {
            if (!ReadWhitespaces(reader))
            {
                return null;
            }
            
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
                {
                    return list.ToArray();
                }
                
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
        internal static JsonException GetExpectedCharacterException(long pos, char c) => pos < 0 ? new JsonException("JSO0002: JSON deserialization error detected. Expecting '" + c + "' character.") : new JsonException("JSO0003: JSON deserialization error detected at position " + pos + ". Expecting '" + c + "' character.");
        
        /// <summary>
        ///     Gets the unexpected character exception using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="c">The </param>
        /// <returns>The json exception</returns>
        internal static JsonException GetUnexpectedCharacterException(long pos, char c) => pos < 0 ? new JsonException("JSO0004: JSON deserialization error detected. Unexpected '" + c + "' character.") : new JsonException("JSO0005: JSON deserialization error detected at position " + pos + ". Unexpected '" + c + "' character.");
        
        /// <summary>
        ///     Gets the expected hex character exception using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <returns>The json exception</returns>
        internal static JsonException GetExpectedHexCharacterException(long pos) => pos < 0 ? new JsonException("JSO0006: JSON deserialization error detected. Expecting hexadecimal character.") : new JsonException("JSO0007: JSON deserialization error detected at position " + pos + ". Expecting hexadecimal character.");
        
        /// <summary>
        ///     Gets the type exception using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="typeName">The type name</param>
        /// <param name="inner">The inner</param>
        /// <returns>The json exception</returns>
        internal static JsonException GetTypeException(long pos, string typeName, Exception inner) => pos < 0 ? new JsonException("JSO0010: JSON deserialization error detected for '" + typeName + "' type.", inner) : new JsonException("JSO0011: JSON deserialization error detected for '" + typeName + "' type at position " + pos + ".", inner);
        
        /// <summary>
        ///     Gets the eof exception using the specified c
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The json exception</returns>
        internal static JsonException GetEofException(char c) => new JsonException("JSO0012: JSON deserialization error detected at end of text. Expecting '" + c + "' character.");
        
        //// <summary>
        ///     Gets the position using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <returns>The long</returns>
        internal static long GetPosition(TextReader reader)
        {
            if (reader == null)
            {
                return -1;
            }
            
            return GetPositionBasedOnReaderType(reader);
        }
        
        /// <summary>
        /// Gets the position based on reader type using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <returns>The long</returns>
        private static long GetPositionBasedOnReaderType(TextReader reader)
        {
            if (reader is StreamReader sr)
            {
                return GetStreamReaderPosition(sr);
            }
            
            if (reader is StringReader str)
            {
                return GetStringReaderPosition(str);
            }
            
            return -1;
        }
        
        /// <summary>
        ///     Gets the stream reader position using the specified sr
        /// </summary>
        /// <param name="sr">The sr</param>
        /// <returns>The long</returns>
        internal static long GetStreamReaderPosition(StreamReader sr)
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
        
        /// <summary>
        ///     Gets the string reader position using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        /// <returns>The long</returns>
        internal static long GetStringReaderPosition(StringReader str)
        {
            FieldInfo fi = typeof(StringReader).GetField("_pos", BindingFlags.Instance | BindingFlags.NonPublic);
            return fi != null ? (int) fi.GetValue(str) : -1;
        }
        
        /// <summary>
        /// Reads the dictionary using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <returns>The dictionary</returns>
        internal static Dictionary<string, object> ReadDictionary(TextReader reader, JsonOptions options)
        {
            if (!ReadWhitespaces(reader))
            {
                return null;
            }
            
            reader.Read();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            
            while (reader.Peek() >= 0)
            {
                char c = (char) reader.Read();
                
                if (c == '}')
                {
                    return dictionary;
                }
                
                ProcessCharacter(c, reader, options, dictionary);
            }
            
            HandleException(GetEofException('}'), options);
            return dictionary;
        }
        
        /// <summary>
        /// Processes the character using the specified c
        /// </summary>
        /// <param name="c">The </param>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <param name="dictionary">The dictionary</param>
        internal static void ProcessCharacter(char c, TextReader reader, JsonOptions options, Dictionary<string, object> dictionary)
        {
            switch (c)
            {
                case '"':
                    ProcessString(reader, options, dictionary);
                    break;
                case ',':
                    break;
                case ' ':
                    break;
                default:
                {
                    if (!char.IsWhiteSpace(c))
                    {
                        HandleException(GetUnexpectedCharacterException(GetPosition(reader), c), options);
                    }
                    
                    break;
                }
            }
        }
        
        /// <summary>
        ///     Processes the string using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <param name="dictionary">The dictionary</param>
        internal static void ProcessString(TextReader reader, JsonOptions options, Dictionary<string, object> dictionary)
        {
            string key = ReadString(reader, options);
            
            if (!ReadWhitespaces(reader) || reader.Peek() != ':')
            {
                HandleException(GetExpectedCharacterException(GetPosition(reader), ':'), options);
                return;
            }
            
            reader.Read();
            dictionary[key] = ReadValue(reader, options);
        }
        
        /// <summary>
        /// Reads the string using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <returns>The string</returns>
        internal static string ReadString(TextReader reader, JsonOptions options)
        {
            StringBuilder result = new StringBuilder();
            while (true)
            {
                int peekedChar = PeekCharacter(reader, options);
                if (peekedChar < 0)
                {
                    return null;
                }
                
                char currentChar = (char) reader.Read();
                if (currentChar == '"')
                {
                    break;
                }
                
                ProcessCharacter(reader, result, options, currentChar);
            }
            
            return result.ToString();
        }
        
        /// <summary>
        /// Peeks the character using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <returns>The peeked char</returns>
        internal static int PeekCharacter(TextReader reader, JsonOptions options)
        {
            int peekedChar = reader.Peek();
            if (peekedChar < 0)
            {
                HandleException(GetEofException('"'), options);
            }
            
            return peekedChar;
        }
        
        /// <summary>
        /// Processes the character using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="result">The result</param>
        /// <param name="options">The options</param>
        /// <param name="currentChar">The current char</param>
        internal static void ProcessCharacter(TextReader reader, StringBuilder result, JsonOptions options, char currentChar)
        {
            if (currentChar == '\\')
            {
                HandleEscapeCharacter(reader, result, options);
            }
            else
            {
                result.Append(currentChar);
            }
        }
        
        /// <summary>
        ///     Handles the escape character using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="result">The result</param>
        /// <param name="options">The options</param>
        internal static void HandleEscapeCharacter(TextReader reader, StringBuilder result, JsonOptions options)
        {
            int peekedChar = reader.Peek();
            if (peekedChar < 0)
            {
                HandleException(GetEofException('"'), options);
                return;
            }
            
            char nextChar = (char) reader.Read();
            AppendEscapedCharacter(result, nextChar, reader, options);
        }
        
        /// <summary>
        /// Appends the escaped character using the specified result
        /// </summary>
        /// <param name="result">The result</param>
        /// <param name="nextChar">The next char</param>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        internal static void AppendEscapedCharacter(StringBuilder result, char nextChar, TextReader reader, JsonOptions options)
        {
            if (IsSpecialCharacter(nextChar))
            {
                AppendSpecialCharacter(result, nextChar);
            }
            else if (IsEscapeCharacter(nextChar))
            {
                result.Append(nextChar);
            }
            else if (IsUnicodeCharacter(nextChar))
            {
                AppendUnicodeCharacter(result, reader, options);
            }
            else
            {
                AppendDefaultCharacter(result, nextChar);
            }
        }
        
        /// <summary>
        /// Describes whether is special character
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The bool</returns>
        internal static bool IsSpecialCharacter(char c)
        {
            return c == 'b' || c == 't' || c == 'n' || c == 'f' || c == 'r';
        }
        
        /// <summary>
        /// Appends the special character using the specified result
        /// </summary>
        /// <param name="result">The result</param>
        /// <param name="c">The </param>
        internal static void AppendSpecialCharacter(StringBuilder result, char c)
        {
            switch (c)
            {
                case 'b':
                    result.Append('\b');
                    break;
                case 't':
                    result.Append('\t');
                    break;
                case 'n':
                    result.Append('\n');
                    break;
                case 'f':
                    result.Append('\f');
                    break;
                case 'r':
                    result.Append('\r');
                    break;
            }
        }
        
        /// <summary>
        /// Describes whether is escape character
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The bool</returns>
        internal static bool IsEscapeCharacter(char c)
        {
            return c == '/' || c == '\\' || c == '"';
        }
        
        /// <summary>
        /// Describes whether is unicode character
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The bool</returns>
        internal static bool IsUnicodeCharacter(char c)
        {
            return c == 'u';
        }
        
        /// <summary>
        /// Appends the default character using the specified result
        /// </summary>
        /// <param name="result">The result</param>
        /// <param name="c">The </param>
        internal static void AppendDefaultCharacter(StringBuilder result, char c)
        {
            result.Append('\\');
            result.Append(c);
        }
        
        /// <summary>
        ///     Appends the unicode character using the specified result
        /// </summary>
        /// <param name="result">The result</param>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        internal static void AppendUnicodeCharacter(StringBuilder result, TextReader reader, JsonOptions options)
        {
            ushort unicodeChar = ReadX4(reader, options);
            result.Append((char) unicodeChar);
        }
        
        /// <summary>
        /// Reads the serializable using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <param name="typeName">The type name</param>
        /// <param name="values">The values</param>
        /// <returns>The serializable</returns>
        internal static ISerializable ReadSerializable(TextReader reader, JsonOptions options, string typeName, Dictionary<string, object> values)
        {
            Type type = GetTypeFromName(reader, typeName, options);
            if (type == null) return null;
            
            return CreateSerializableObject(type, values, options);
        }
        
        /// <summary>
        /// Creates the serializable object using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="values">The values</param>
        /// <param name="options">The options</param>
        /// <returns>The serializable</returns>
        internal static ISerializable CreateSerializableObject(Type type, Dictionary<string, object> values, JsonOptions options)
        {
            SerializationInfo info = CreateSerializationInfo(type, values);
            return InvokeConstructor(type, info, options);
        }
        
        /// <summary>
        ///     Gets the type from name using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="typeName">The type name</param>
        /// <param name="options">The options</param>
        /// <returns>The type</returns>
        internal static Type GetTypeFromName(TextReader reader, string typeName, JsonOptions options)
        {
            try
            {
                return Type.GetType(typeName, true);
            }
            catch (Exception e)
            {
                HandleException(GetTypeException(GetPosition(reader), typeName, e), options);
                return null;
            }
        }
        
        /// <summary>
        ///     Creates the serialization info using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="values">The values</param>
        /// <returns>The info</returns>
        internal static SerializationInfo CreateSerializationInfo(Type type, Dictionary<string, object> values)
        {
            SerializationInfo info = new SerializationInfo(type, DefaultFormatterConverter);
            foreach (KeyValuePair<string, object> kvp in values)
            {
                info.AddValue(kvp.Key, kvp.Value);
            }
            
            return info;
        }
        
        /// <summary>
        ///     Invokes the constructor using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="info">The info</param>
        /// <param name="options">The options</param>
        /// <exception cref="InvalidOperationException">No suitable constructor found for type {type.FullName}</exception>
        /// <returns>The serializable</returns>
        internal static ISerializable InvokeConstructor(Type type, SerializationInfo info, JsonOptions options)
        {
            ConstructorInfo constructor = GetDesiredConstructor(type);
            if (constructor == null)
            {
                throw new InvalidOperationException($"No suitable constructor found for type {type.FullName}");
            }
            
            StreamingContext context = new StreamingContext(StreamingContextStates.Remoting);
            return InvokeConstructor(constructor, info, context);
        }
        
        /// <summary>
        ///     Gets the desired constructor using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The constructor info</returns>
        internal static ConstructorInfo GetDesiredConstructor(Type type)
        {
            return type.GetConstructor(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                new[] {typeof(SerializationInfo), typeof(StreamingContext)},
                null);
        }
        
        /// <summary>
        ///     Invokes the constructor using the specified constructor
        /// </summary>
        /// <param name="constructor">The constructor</param>
        /// <param name="info">The info</param>
        /// <param name="context">The context</param>
        /// <returns>The serializable</returns>
        internal static ISerializable InvokeConstructor(ConstructorInfo constructor, SerializationInfo info, StreamingContext context)
        {
            return (ISerializable) constructor.Invoke(new object[] {info, context});
        }
        
        /// <summary>
        ///     Reads the value using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <returns>The object</returns>
        internal static object ReadValue(TextReader reader, JsonOptions options) => ReadValue(reader, options, false, out bool _);
        
        /// <summary>
        ///     Reads the value using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <param name="arrayMode">The array mode</param>
        /// <param name="arrayEnd">The array end</param>
        /// <returns>The object</returns>
        internal static object ReadValue(TextReader reader, JsonOptions options, bool arrayMode, out bool arrayEnd)
        {
            arrayEnd = false;
            SkipWhitespace(reader);
            
            char c = (char) reader.Peek();
            if (c == '"')
            {
                return ReadStringValue(reader, options);
            }
            
            if (c == '{')
            {
                return ReadDictionaryValue(reader, options);
            }
            
            if (c == '[')
            {
                return ReadArrayValue(reader, options);
            }
            
            if (c == 'n')
            {
                return ReadNewValue(reader, options, out arrayEnd);
            }
            
            if (char.IsLetterOrDigit(c) || c == '.' || c == '-' || c == '+')
            {
                return ReadNumberOrLiteralValue(reader, options, out arrayEnd);
            }
            
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
        ///     Skips the whitespace using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        internal static void SkipWhitespace(TextReader reader)
        {
            int i;
            do
            {
                i = reader.Peek();
                if (i < 0)
                {
                    return;
                }
                
                if (i == 10 || i == 13 || i == 9 || i == 32)
                {
                    reader.Read();
                }
                else
                {
                    break;
                }
            } while (true);
        }
        
        /// <summary>
        ///     Reads the string value using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <returns>The </returns>
        internal static string ReadStringValue(TextReader reader, JsonOptions options)
        {
            reader.Read();
            string s = ReadString(reader, options);
            if (options.SerializationOptions.HasFlag(JsonSerializationOptions.AutoParseDateTime))
            {
                if (TryParseDateTime(s, options.DateTimeStyles, out DateTime dt))
                {
                    return dt.ToString(CultureInfo.CurrentCulture);
                }
            }
            
            return s;
        }
        
        /// <summary>
        /// Reads the dictionary value using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <returns>The dic</returns>
        internal static Dictionary<string, object> ReadDictionaryValue(TextReader reader, JsonOptions options)
        {
            Dictionary<string, object> dic = ReadDictionary(reader, options);
            ProcessSerializationOptions(dic, options);
            return dic;
        }
        
        /// <summary>
        /// Processes the serialization options using the specified dic
        /// </summary>
        /// <param name="dic">The dic</param>
        /// <param name="options">The options</param>
        internal static void ProcessSerializationOptions(Dictionary<string, object> dic, JsonOptions options)
        {
            if (options.SerializationOptions.HasFlag(JsonSerializationOptions.UseISerializable))
            {
                ProcessTypeName(dic);
            }
        }
        
        /// <summary>
        /// Processes the type name using the specified dictionary.
        /// </summary>
        /// <param name="dic">The dictionary.</param>
        internal static void ProcessTypeName(Dictionary<string, object> dic)
        {
            if (!dic.TryGetValue(SerializationTypeToken, out object o))
            {
                return;
            }
            
            FormatAndSetTypeName(dic, o);
        }
        
        /// <summary>
        /// Formats the type name and sets it in the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary.</param>
        /// <param name="o">The object containing the type name.</param>
        internal static void FormatAndSetTypeName(Dictionary<string, object> dic, object o)
        {
            string typeName = FormatTypeName(o);
            if (string.IsNullOrEmpty(typeName))
            {
                return;
            }
            
            dic.Remove(SerializationTypeToken);
            dic[SerializationTypeToken] = typeName;
        }
        
        /// <summary>
        /// Formats the type name using the specified o
        /// </summary>
        /// <param name="o">The </param>
        /// <returns>The string</returns>
        internal static string FormatTypeName(object o)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}", o);
        }
        
        /// <summary>
        ///     Reads the array value using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <returns>The object array</returns>
        internal static object[] ReadArrayValue(TextReader reader, JsonOptions options) => ReadArray(reader, options);
        
        /// <summary>
        ///     Reads the new value using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <param name="arrayEnd">The array end</param>
        /// <returns>The object</returns>
        internal static object ReadNewValue(TextReader reader, JsonOptions options, out bool arrayEnd) => ReadNew(reader, options, out arrayEnd);
        
        /// <summary>
        ///     Reads the number or literal value using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <param name="arrayEnd">The array end</param>
        /// <returns>The object</returns>
        internal static object ReadNumberOrLiteralValue(TextReader reader, JsonOptions options, out bool arrayEnd) => ReadNumberOrLiteral(reader, options, out arrayEnd);
        
        /// <summary>
        /// Reads the new using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <param name="arrayEnd">The array end</param>
        /// <returns>The object</returns>
        internal static object ReadNew(TextReader reader, JsonOptions options, out bool arrayEnd)
        {
            arrayEnd = false;
            string text = ReadUntilEndCondition(reader, out arrayEnd);
            
            if (IsTextNull(text))
            {
                return null;
            }
            
            return HandleTextProcessing(text, reader, options);
        }
        
        /// <summary>
        /// Handles the text processing using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <returns>The object</returns>
        internal static object HandleTextProcessing(string text, TextReader reader, JsonOptions options)
        {
            if (IsTextDateTime(text, out long ticks))
            {
                return ConvertTicksToDateTime(ticks);
            }
            
            HandleException(GetUnexpectedCharacterException(GetPosition(reader), text[0]), options);
            return null;
        }
        
        /// <summary>
        ///     Reads the until end condition using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="arrayEnd">The array end</param>
        /// <returns>The string</returns>
        internal static string ReadUntilEndCondition(TextReader reader, out bool arrayEnd)
        {
            arrayEnd = false;
            StringBuilder sb = new StringBuilder();
            
            while (true)
            {
                int peekedChar = reader.Peek();
                
                if (peekedChar < 0 || (char) peekedChar == '}' || (char) peekedChar == ',')
                {
                    break;
                }
                
                char readChar = (char) reader.Read();
                if (readChar == ']')
                {
                    arrayEnd = true;
                    break;
                }
                
                sb.Append(readChar);
            }
            
            return sb.ToString();
        }
        
        /// <summary>
        ///     Describes whether is text null
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The bool</returns>
        internal static bool IsTextNull(string text) => string.Compare(Null, text.Trim(), StringComparison.OrdinalIgnoreCase) == 0;
        
        /// <summary>
        ///     Describes whether is text date time
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="ticks">The ticks</param>
        /// <returns>The bool</returns>
        /// <summary>
        ///     Determines whether the provided text represents a DateTime.
        /// </summary>
        /// <param name="text">The text to check.</param>
        /// <param name="ticks">The parsed ticks from the DateTime if it is valid.</param>
        /// <returns>True if the text represents a DateTime, otherwise false.</returns>
        internal static bool IsTextDateTime(string text, out long ticks)
        {
            const string dateStartJsLocal = "/Date(";
            const string dateEndJsLocal = ")/";
            
            bool startsWithDateStart = text.StartsWith(dateStartJsLocal);
            bool endsWithDateEnd = text.EndsWith(dateEndJsLocal);
            
            if (startsWithDateStart && endsWithDateEnd)
            {
                string ticksText = text.Substring(dateStartJsLocal.Length, text.Length - dateStartJsLocal.Length - dateEndJsLocal.Length);
                return long.TryParse(ticksText, out ticks);
            }
            
            ticks = 0;
            return false;
        }
        
        /// <summary>
        ///     Converts the ticks to date time using the specified ticks
        /// </summary>
        /// <param name="ticks">The ticks</param>
        /// <returns>The date time</returns>
        internal static DateTime ConvertTicksToDateTime(long ticks) => new DateTime(ticks * 10000 + MinDateTimeTicks, DateTimeKind.Utc);
        
        /// <summary>
        ///     Reads the number or literal using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <param name="arrayEnd">The array end</param>
        /// <returns>The object</returns>
        internal static object ReadNumberOrLiteral(TextReader reader, JsonOptions options, out bool arrayEnd)
        {
            arrayEnd = false;
            string text = ReadCharacters(reader, out arrayEnd);
            
            return IsLiteral(text) ? HandleLiteral(text) : ParseNumber(text, options, reader);
        }
        
        /// <summary>
        ///     Reads the characters using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="arrayEnd">The array end</param>
        /// <returns>The string</returns>
        internal static string ReadCharacters(TextReader reader, out bool arrayEnd)
        {
            arrayEnd = false;
            StringBuilder sb = new StringBuilder();
            do
            {
                int i = reader.Peek();
                if (i < 0 || (char) i == '}')
                {
                    break;
                }
                
                char c = (char) reader.Read();
                if (char.IsWhiteSpace(c) || c == ',')
                {
                    break;
                }
                
                if (c == ']')
                {
                    arrayEnd = true;
                    break;
                }
                
                sb.Append(c);
            } while (true);
            
            return sb.ToString();
        }
        
        /// <summary>
        ///     Describes whether is literal
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The bool</returns>
        internal static bool IsLiteral(string text) => string.Compare(Null, text, StringComparison.OrdinalIgnoreCase) == 0 ||
                                                       string.Compare(True, text, StringComparison.OrdinalIgnoreCase) == 0 ||
                                                       string.Compare(False, text, StringComparison.OrdinalIgnoreCase) == 0;
        
        /// <summary>
        ///     Handles the literal using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The object</returns>
        internal static object HandleLiteral(string text)
        {
            if (string.Compare(Null, text, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return null;
            }
            
            if (string.Compare(True, text, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return true;
            }
            
            if (string.Compare(False, text, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return false;
            }
            
            return null;
        }
        
        /// <summary>
        ///     Parses the number using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="options">The options</param>
        /// <param name="reader">The reader</param>
        /// <returns>The object</returns>
        internal static object ParseNumber(string text, JsonOptions options, TextReader reader)
        {
            if (text.LastIndexOf("e", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return HandleECase(text);
            }
            
            if (text.IndexOf(".", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return HandleDotCase(text);
            }
            
            return HandleDefaultCase(text, reader, options);
        }
        
        /// <summary>
        ///     Handles the e case using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The object</returns>
        internal static object HandleECase(string text)
        {
            if (double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out double d))
            {
                return d;
            }
            
            return null;
        }
        
        /// <summary>
        ///     Handles the dot case using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The object</returns>
        internal static object HandleDotCase(string text)
        {
            if (decimal.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal de))
            {
                return de;
            }
            
            return null;
        }
        
        /// <summary>
        ///     Handles the default case using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <returns>The object</returns>
        internal static object HandleDefaultCase(string text, TextReader reader, JsonOptions options)
        {
            if (int.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out int i))
            {
                return i;
            }
            
            if (long.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out long l))
            {
                return l;
            }
            
            if (decimal.TryParse(text, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal de))
            {
                return de;
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
            {
                return null;
            }
            
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
            {
                return null;
            }
            
            return dt;
        }
        
        /// <summary>
        ///     Converts the JSON string representation of a date time to its DateTime equivalent.
        /// </summary>
        /// <param name="text">The input text.</param>
        /// <param name="dt">When this method returns, contains the DateTime equivalent.</param>
        /// <returns>true if the text was converted successfully; otherwise, false.</returns>
        internal static bool TryParseDateTime(string text, out DateTime dt) => TryParseDateTime(text, JsonOptions.DefaultDateTimeStyles, out dt);
        
        /// <summary>
        ///     Describes whether try parse date time
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="styles">The styles</param>
        /// <param name="dt">The dt</param>
        /// <returns>The bool</returns>
        internal static bool TryParseDateTime(string text, DateTimeStyles styles, out DateTime dt)
        {
            dt = DateTime.MinValue;
            
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
            
            text = RemoveQuotesFromText(text);
            
            return TryParseDateTimeWithEndZ(text, out dt)
                   || TryParseDateTimeWithSpecificFormat(text, out dt)
                   || TryParseDateTimeWithTicks(text, out dt)
                   || TryParseDateTimeWithStandardFormat(text, styles, out dt);
        }
        
        
        /// <summary>
        ///     Describes whether try parse date time with standard format
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="styles">The styles</param>
        /// <param name="dt">The dt</param>
        /// <returns>The bool</returns>
        internal static bool TryParseDateTimeWithStandardFormat(string text, DateTimeStyles styles, out DateTime dt)
        {
            if (IsTimeSpanStyle(text))
            {
                dt = DateTime.MinValue;
                return false;
            }
            
            return DateTime.TryParse(text, null, styles, out dt);
        }
        
        /// <summary>
        ///     Describes whether is time span style
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The bool</returns>
        internal static bool IsTimeSpanStyle(string text) => (text.Length == 8) && (text[2] == ':') && (text[5] == ':');
        
        /// <summary>
        ///     Removes the quotes from text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The text</returns>
        internal static string RemoveQuotesFromText(string text)
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
            
            return text;
        }
        
        /// <summary>
        ///     Describes whether try parse date time with end z
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="dt">The dt</param>
        /// <returns>The bool</returns>
        internal static bool TryParseDateTimeWithEndZ(string text, out DateTime dt)
        {
            if (text.EndsWith("Z", StringComparison.OrdinalIgnoreCase))
            {
                if (DateTime.TryParseExact(text, DateFormatsUtc, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out dt))
                {
                    return true;
                }
            }
            
            dt = DateTime.MinValue;
            return false;
        }
        
        /// <summary>
        ///     Tries to parse a date time with a specific format.
        /// </summary>
        /// <param name="text">The text to parse.</param>
        /// <param name="dt">The parsed DateTime if successful.</param>
        /// <returns>True if parsing was successful, false otherwise.</returns>
        internal static bool TryParseDateTimeWithSpecificFormat(string text, out DateTime dt)
        {
            if (!IsDateTimeFormatValid(text))
            {
                dt = DateTime.MinValue;
                return false;
            }
            
            if (TryParseExactDateTime(text, out dt))
            {
                return true;
            }
            
            int timeZoneIndex = FindTimeZoneIndex(text);
            if (timeZoneIndex < 0)
            {
                return TryParseDateTimeWithOffset(text, timeZoneIndex, 0, 0, out dt);
            }
            
            CalculateOffset(text, timeZoneIndex, out int offsetHours, out int offsetMinutes);
            string textWithoutTimeZone = text.Substring(0, timeZoneIndex);
            return TryParseDateTimeWithOffset(textWithoutTimeZone, timeZoneIndex, offsetHours, offsetMinutes, out dt);
        }
        
        /// <summary>
        ///     Describes whether is date time format valid
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The bool</returns>
        internal static bool IsDateTimeFormatValid(string text) => (text.Length >= 19) &&
                                                                   (text[4] == '-') &&
                                                                   (text[7] == '-') &&
                                                                   (text[10] == 'T' || text[10] == 't');
        
        /// <summary>
        ///     Describes whether try parse exact date time
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="dt">The dt</param>
        /// <returns>The bool</returns>
        internal static bool TryParseExactDateTime(string text, out DateTime dt) => DateTime.TryParseExact(text, "o", null, DateTimeStyles.AssumeUniversal, out dt);
        
        /// <summary>
        ///     Finds the time zone index using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The int</returns>
        internal static int FindTimeZoneIndex(string text)
        {
            return text.IndexOfAny(new[] {'+', '-'}, 19);
        }
        
        /// <summary>
        ///     Calculates the offset using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="tz">The tz</param>
        /// <param name="offsetHours">The offset hours</param>
        /// <param name="offsetMinutes">The offset minutes</param>
        internal static void CalculateOffset(string text, int tz, out int offsetHours, out int offsetMinutes)
        {
            string offset = text.Substring(tz + 1).Trim();
            if (int.TryParse(offset, out int i))
            {
                offsetHours = i / 100;
                offsetMinutes = i % 100;
                if (text[tz] == '-')
                {
                    offsetHours = -offsetHours;
                    offsetMinutes = -offsetMinutes;
                }
            }
            else
            {
                offsetHours = 0;
                offsetMinutes = 0;
            }
        }
        
        /// <summary>
        ///     Describes whether try parse date time with offset
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="tz">The tz</param>
        /// <param name="offsetHours">The offset hours</param>
        /// <param name="offsetMinutes">The offset minutes</param>
        /// <param name="dt">The dt</param>
        /// <returns>The bool</returns>
        internal static bool TryParseDateTimeWithOffset(string text, int tz, int offsetHours, int offsetMinutes, out DateTime dt)
        {
            if (tz >= 0)
            {
                if (DateTime.TryParseExact(text, "s", null, DateTimeStyles.AssumeLocal, out dt))
                {
                    dt = dt.AddHours(offsetHours);
                    dt = dt.AddMinutes(offsetMinutes);
                    return true;
                }
            }
            else
            {
                if (DateTime.TryParseExact(text, "s", null, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out dt))
                {
                    return true;
                }
            }
            
            return false;
        }
        
        /// <summary>
        ///     Describes whether try parse date time with ticks
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="dt">The dt</param>
        /// <returns>The bool</returns>
        internal static bool TryParseDateTimeWithTicks(string text, out DateTime dt)
        {
            string ticks = ExtractTicks(text);
            int offsetHours, offsetMinutes;
            ExtractOffset(ticks, out ticks, out offsetHours, out offsetMinutes);
            return TryParseTicks(ticks, offsetHours, offsetMinutes, out dt);
        }
        
        /// <summary>
        ///     Extracts the ticks using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The string</returns>
        internal static string ExtractTicks(string text)
        {
            if (text.StartsWith(DateStartJs) && text.EndsWith(DateEndJs))
            {
                return text.Substring(DateStartJs.Length, text.Length - DateStartJs.Length - DateEndJs.Length).Trim();
            }
            
            if (text.StartsWith(DateStart2, StringComparison.OrdinalIgnoreCase) && text.EndsWith(DateEnd2, StringComparison.OrdinalIgnoreCase))
            {
                return text.Substring(DateStart2.Length, text.Length - DateEnd2.Length - DateStart2.Length).Trim();
            }
            
            return null;
        }
        
        /// <summary>
        ///     Extracts the offset using the specified ticks
        /// </summary>
        /// <param name="ticks">The ticks</param>
        /// <param name="updatedTicks">The updated ticks</param>
        /// <param name="offsetHours">The offset hours</param>
        /// <param name="offsetMinutes">The offset minutes</param>
        internal static void ExtractOffset(string ticks, out string updatedTicks, out int offsetHours, out int offsetMinutes)
        {
            offsetHours = 0;
            offsetMinutes = 0;
            updatedTicks = ticks;
            
            if (!string.IsNullOrEmpty(ticks))
            {
                int startIndex = GetStartIndex(ticks);
                int pos = GetOffsetSignPosition(ticks, startIndex);
                if (pos >= 0)
                {
                    CalculateOffset(ticks, pos, out updatedTicks, out offsetHours, out offsetMinutes);
                }
            }
        }
        
        /// <summary>
        ///     Gets the start index using the specified ticks
        /// </summary>
        /// <param name="ticks">The ticks</param>
        /// <returns>The int</returns>
        internal static int GetStartIndex(string ticks) => ticks[0] == '-' || ticks[0] == '+' ? 1 : 0;
        
        /// <summary>
        ///     Gets the offset sign position using the specified ticks
        /// </summary>
        /// <param name="ticks">The ticks</param>
        /// <param name="startIndex">The start index</param>
        /// <returns>The int</returns>
        internal static int GetOffsetSignPosition(string ticks, int startIndex)
        {
            return ticks.IndexOfAny(new[] {'+', '-'}, startIndex);
        }
        
        /// <summary>
        ///     Calculates the offset using the specified ticks
        /// </summary>
        /// <param name="ticks">The ticks</param>
        /// <param name="pos">The pos</param>
        /// <param name="updatedTicks">The updated ticks</param>
        /// <param name="offsetHours">The offset hours</param>
        /// <param name="offsetMinutes">The offset minutes</param>
        internal static void CalculateOffset(string ticks, int pos, out string updatedTicks, out int offsetHours, out int offsetMinutes)
        {
            bool isNegative = IsNegative(ticks, pos);
            updatedTicks = GetUpdatedTicks(ticks, pos);
            string offsetString = GetOffsetString(ticks, pos);
            
            if (!TryParseOffset(offsetString, out int offsetValue))
            {
                offsetHours = 0;
                offsetMinutes = 0;
                return;
            }
            
            (offsetHours, offsetMinutes) = CalculateHoursAndMinutes(offsetValue);
            
            if (isNegative)
            {
                InvertOffset(ref offsetHours, ref offsetMinutes);
            }
        }
        
        /// <summary>
        ///     Describes whether is negative
        /// </summary>
        /// <param name="ticks">The ticks</param>
        /// <param name="pos">The pos</param>
        /// <returns>The bool</returns>
        internal static bool IsNegative(string ticks, int pos) => ticks[pos] == '-';
        
        /// <summary>
        ///     Gets the updated ticks using the specified ticks
        /// </summary>
        /// <param name="ticks">The ticks</param>
        /// <param name="pos">The pos</param>
        /// <returns>The string</returns>
        internal static string GetUpdatedTicks(string ticks, int pos) => ticks.Substring(0, pos).Trim();
        
        /// <summary>
        ///     Gets the offset string using the specified ticks
        /// </summary>
        /// <param name="ticks">The ticks</param>
        /// <param name="pos">The pos</param>
        /// <returns>The string</returns>
        internal static string GetOffsetString(string ticks, int pos) => ticks.Substring(pos + 1).Trim();
        
        /// <summary>
        ///     Describes whether try parse offset
        /// </summary>
        /// <param name="offsetString">The offset string</param>
        /// <param name="offsetValue">The offset value</param>
        /// <returns>The bool</returns>
        internal static bool TryParseOffset(string offsetString, out int offsetValue) => int.TryParse(offsetString, out offsetValue);
        
        /// <summary>
        ///     Inverts the offset using the specified offset hours
        /// </summary>
        /// <param name="offsetHours">The offset hours</param>
        /// <param name="offsetMinutes">The offset minutes</param>
        internal static void InvertOffset(ref int offsetHours, ref int offsetMinutes)
        {
            offsetHours = -offsetHours;
            offsetMinutes = -offsetMinutes;
        }
        
        /// <summary>
        ///     Calculates the hours and minutes using the specified offset value
        /// </summary>
        /// <param name="offsetValue">The offset value</param>
        /// <returns>The int int</returns>
        internal static (int, int) CalculateHoursAndMinutes(int offsetValue)
        {
            int hours = offsetValue / 100;
            int minutes = offsetValue % 100;
            return (hours, minutes);
        }
        
        /// <summary>
        /// Describes whether try parse ticks
        /// </summary>
        /// <param name="ticks">The ticks</param>
        /// <param name="offsetHours">The offset hours</param>
        /// <param name="offsetMinutes">The offset minutes</param>
        /// <param name="dt">The dt</param>
        /// <returns>The bool</returns>
        internal static bool TryParseTicks(string ticks, int offsetHours, int offsetMinutes, out DateTime dt)
        {
            if (IsValidTicks(ticks, out long l))
            {
                dt = CalculateDateTime(l, offsetHours, offsetMinutes);
                return true;
            }
            
            dt = DateTime.MinValue;
            return false;
        }
        
        /// <summary>
        /// Describes whether is valid ticks
        /// </summary>
        /// <param name="ticks">The ticks</param>
        /// <param name="l">The </param>
        /// <returns>The bool</returns>
        internal static bool IsValidTicks(string ticks, out long l)
        {
            l = 0;
            return !string.IsNullOrEmpty(ticks) && long.TryParse(ticks, NumberStyles.Number, CultureInfo.InvariantCulture, out l);
        }
        
        /// <summary>
        /// Calculates the date time using the specified l
        /// </summary>
        /// <param name="l">The </param>
        /// <param name="offsetHours">The offset hours</param>
        /// <param name="offsetMinutes">The offset minutes</param>
        /// <returns>The dt</returns>
        internal static DateTime CalculateDateTime(long l, int offsetHours, int offsetMinutes)
        {
            DateTime dt = new DateTime(l * 10000 + MinDateTimeTicks, DateTimeKind.Local);
            dt = AddOffsetHours(dt, offsetHours);
            dt = AddOffsetMinutes(dt, offsetMinutes);
            return dt;
        }
        
        /// <summary>
        /// Adds the offset hours using the specified dt
        /// </summary>
        /// <param name="dt">The dt</param>
        /// <param name="offsetHours">The offset hours</param>
        /// <returns>The dt</returns>
        internal static DateTime AddOffsetHours(DateTime dt, int offsetHours)
        {
            if (offsetHours != 0)
            {
                dt = dt.AddHours(offsetHours);
            }
            
            return dt;
        }
        
        /// <summary>
        /// Adds the offset minutes using the specified dt
        /// </summary>
        /// <param name="dt">The dt</param>
        /// <param name="offsetMinutes">The offset minutes</param>
        /// <returns>The dt</returns>
        internal static DateTime AddOffsetMinutes(DateTime dt, int offsetMinutes)
        {
            if (offsetMinutes != 0)
            {
                dt = dt.AddMinutes(offsetMinutes);
            }
            
            return dt;
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
        /// <param name="c">The character to convert</param>
        /// <param name="options">The options</param>
        /// <returns>The byte</returns>
        internal static byte GetHexValue(TextReader reader, char c, JsonOptions options)
        {
            c = char.ToLower(c);
            
            if (!IsHexCharacter(c))
            {
                HandleException(GetExpectedHexCharacterException(GetPosition(reader)), options);
                return 0;
            }
            
            return ConvertHexCharacterToByte(c);
        }
        
        /// <summary>
        ///     Describes whether is hex character
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The bool</returns>
        internal static bool IsHexCharacter(char c) => ((c >= '0') && (c <= '9')) || ((c >= 'a') && (c <= 'f'));
        
        /// <summary>
        ///     Converts the hex character to byte using the specified c
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The byte</returns>
        internal static byte ConvertHexCharacterToByte(char c) => c <= '9' ? (byte) (c - '0') : (byte) (c - 'a' + 10);
        
        /// <summary>
        ///     Reads the x 4 using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="options">The options</param>
        /// <returns>The ushort</returns>
        internal static ushort ReadX4(TextReader reader, JsonOptions options)
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
        internal static bool ReadWhitespaces(TextReader reader) => ReadWhile(reader, char.IsWhiteSpace);
        
        /// <summary>
        /// Describes whether read while
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="cont">The cont</param>
        /// <returns>The bool</returns>
        internal static bool ReadWhile(TextReader reader, Predicate<char> cont)
        {
            while (CanReadCharacter(reader))
            {
                char nextChar = PeekCharacter(reader);
                if (!cont(nextChar))
                {
                    return true;
                }
                
                reader.Read();
            }
            
            return false;
        }
        
        /// <summary>
        /// Describes whether can read character
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <returns>The bool</returns>
        internal static bool CanReadCharacter(TextReader reader)
        {
            return reader.Peek() >= 0;
        }
        
        /// <summary>
        /// Peeks the character using the specified reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <returns>The char</returns>
        internal static char PeekCharacter(TextReader reader)
        {
            return (char) reader.Peek();
        }
        
        /// <summary>
        ///     Writes the value using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void WriteValue(TextWriter writer, object value, IDictionary<object, object> objectGraph, JsonOptions options = null)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }
            
            options ??= new JsonOptions();
            objectGraph ??= options.FinalObjectGraph;
            SetOptions(objectGraph, options);
            
            HandleWriteValueCallback(options, writer, value, objectGraph);
            
            // Add objectGraph as the fourth argument to the HandleSpecialCases method
            if (HandleSpecialCases(writer, value, objectGraph, options))
            {
                return;
            }
            
            HandleObjectGraph(writer, value, objectGraph, options);
        }
        
        /// <summary>
        ///     Handles the write value callback using the specified options
        /// </summary>
        /// <param name="options">The options</param>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <param name="objectGraph">The object graph</param>
        internal static void HandleWriteValueCallback(JsonOptions options, TextWriter writer, object value, IDictionary<object, object> objectGraph)
        {
            if (options.WriteValueCallback == null)
            {
                return;
            }
            
            JsonEventArgs eventArgs = CreateJsonEventArgs(writer, value, objectGraph, options);
            options.WriteValueCallback(eventArgs);
        }
        
        /// <summary>
        ///     Creates the json event args using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        /// <returns>The json event args</returns>
        internal static JsonEventArgs CreateJsonEventArgs(TextWriter writer, object value, IDictionary<object, object> objectGraph, JsonOptions options) => new JsonEventArgs(writer, value, objectGraph, options)
        {
            EventType = JsonEventType.WriteValue
        };
        
        /// <summary>
        ///     Describes whether handle special cases
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        internal static bool HandleSpecialCases(TextWriter writer, object value, IDictionary<object, object> objectGraph, JsonOptions options)
        {
            return HandleNullValue(writer, value) ||
                   HandleStringValue(writer, value) ||
                   HandleBoolValue(writer, value) ||
                   HandleFloatDoubleValue(writer, value) ||
                   HandleCharValue(writer, value) ||
                   HandleEnumValue(writer, value, options) ||
                   HandleTimeSpanValue(writer, value, options) ||
                   HandleDateTimeOffsetValue(writer, value, options) ||
                   HandleDateTimeValue(writer, value, options) ||
                   HandleNumericValue(writer, value) ||
                   HandleGuidValue(writer, value, options) ||
                   HandleUriValue(writer, value) ||
                   HandleArrayValue(writer, value, objectGraph, options);
        }
        
        /// <summary>
        ///     Handles the object graph using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        internal static void HandleObjectGraph(TextWriter writer, object value, IDictionary<object, object> objectGraph, JsonOptions options)
        {
            try
            {
                if (objectGraph.ContainsKey(value))
                {
                    HandleObjectGraphCycle(writer, value, options);
                }
                else
                {
                    objectGraph.Add(value, null);
                    options.SerializationLevel++;
                    
                    if (!HandleIDictionaryValue(writer, value, objectGraph, options) &&
                        !HandleIEnumerableValue(writer, value, objectGraph, options) &&
                        !HandleStreamValue(writer, value, objectGraph, options))
                    {
                        WriteObject(writer, value, objectGraph, options);
                    }
                }
            }
            finally
            {
                options.SerializationLevel--;
            }
        }
        
        /// <summary>
        ///     Handles the object graph cycle using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <param name="options">The options</param>
        internal static void HandleObjectGraphCycle(TextWriter writer, object value, JsonOptions options)
        {
            if (options.SerializationOptions.HasFlag(JsonSerializationOptions.ContinueOnCycle))
            {
                writer.Write(Null);
            }
            else
            {
                HandleException(new JsonException("JSO0009: Cyclic JSON serialization detected."), options);
            }
        }
        
        /// <summary>
        ///     Describes whether handle null value
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool HandleNullValue(TextWriter writer, object value)
        {
            if (value == null || Convert.IsDBNull(value))
            {
                writer.Write("null");
                return true;
            }
            
            return false;
        }
        
        /// <summary>
        ///     Describes whether handle string value
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool HandleStringValue(TextWriter writer, object value)
        {
            if (value is string s)
            {
                writer.Write($"\"{s}\"");
                return true;
            }
            
            return false;
        }
        
        /// <summary>
        ///     Describes whether handle bool value
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool HandleBoolValue(TextWriter writer, object value)
        {
            if (value is bool b)
            {
                writer.Write(b ? "true" : "false");
                return true;
            }
            
            return false;
        }
        
        /// <summary>
        ///     Describes whether handle float double value
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool HandleFloatDoubleValue(TextWriter writer, object value)
        {
            if (value is float f)
            {
                writer.Write(f.ToString(CultureInfo.InvariantCulture));
                return true;
            }
            
            if (value is double d)
            {
                writer.Write(d.ToString(CultureInfo.InvariantCulture));
                return true;
            }
            
            return false;
        }
        
        /// <summary>
        ///     Describes whether handle char value
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool HandleCharValue(TextWriter writer, object value)
        {
            if (value is char c)
            {
                writer.Write($"\"{c}\"");
                return true;
            }
            
            return false;
        }
        
        /// <summary>
        ///     Describes whether handle enum value
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        internal static bool HandleEnumValue(TextWriter writer, object value, JsonOptions options)
        {
            if (value is Enum e)
            {
                writer.Write(options.SerializationOptions.HasFlag(JsonSerializationOptions.EnumAsText) ? $"\"{e}\"" : Convert.ToInt32(e).ToString());
                return true;
            }
            
            return false;
        }
        
        /// <summary>
        ///     Describes whether handle time span value
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        internal static bool HandleTimeSpanValue(TextWriter writer, object value, JsonOptions options)
        {
            if (value is TimeSpan ts)
            {
                if (options.SerializationOptions.HasFlag(JsonSerializationOptions.TimeSpanAsText))
                {
                    writer.Write($"\"{ts:dd\\:hh\\:mm\\:ss\\.fff}\"");
                }
                else
                {
                    writer.Write(ts.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));
                }
                
                return true;
            }
            
            return false;
        }
        
        /// <summary>
        ///     Describes whether handle date time offset value
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        internal static bool HandleDateTimeOffsetValue(TextWriter writer, object value, JsonOptions options)
        {
            if (value is DateTimeOffset dto)
            {
                writer.Write($"\"{dto.ToString("o")}\"");
                return true;
            }
            
            return false;
        }
        
        /// <summary>
        ///     Describes whether handle date time value
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        internal static bool HandleDateTimeValue(TextWriter writer, object value, JsonOptions options)
        {
            if (value is DateTime dt)
            {
                writer.Write($"\"{dt.ToString("o")}\"");
                return true;
            }
            
            return false;
        }
        
        /// <summary>
        ///     Describes whether handle numeric value
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool HandleNumericValue(TextWriter writer, object value)
        {
            if (value is IConvertible ic)
            {
                writer.Write(ic.ToString(CultureInfo.InvariantCulture));
                return true;
            }
            
            return false;
        }
        
        /// <summary>
        ///     Describes whether handle guid value
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        internal static bool HandleGuidValue(TextWriter writer, object value, JsonOptions options)
        {
            if (value is Guid g)
            {
                writer.Write($"\"{g.ToString()}\"");
                return true;
            }
            
            return false;
        }
        
        /// <summary>
        ///     Describes whether handle uri value
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool HandleUriValue(TextWriter writer, object value)
        {
            if (value is Uri uri)
            {
                writer.Write($"\"{uri}\"");
                return true;
            }
            
            return false;
        }
        
        /// <summary>
        ///     Describes whether handle array value
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        internal static bool HandleArrayValue(TextWriter writer, object value, IDictionary<object, object> objectGraph, JsonOptions options)
        {
            if (value is Array array)
            {
                writer.Write("[");
                for (int i = 0; i < array.Length; i++)
                {
                    if (i > 0)
                    {
                        writer.Write(",");
                    }
                    
                    WriteValue(writer, array.GetValue(i), objectGraph, options);
                }
                
                writer.Write("]");
                return true;
            }
            
            return false;
        }
        
        /// <summary>
        ///     Describes whether handle i dictionary value
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        internal static bool HandleIDictionaryValue(TextWriter writer, object value, IDictionary<object, object> objectGraph, JsonOptions options)
        {
            if (value is IDictionary dictionary)
            {
                writer.Write("{");
                bool first = true;
                foreach (DictionaryEntry entry in dictionary)
                {
                    if (!first)
                    {
                        writer.Write(",");
                    }
                    
                    first = false;
                    writer.Write($"\"{entry.Key}\":");
                    WriteValue(writer, entry.Value, objectGraph, options);
                }
                
                writer.Write("}");
                return true;
            }
            
            return false;
        }
        
        /// <summary>
        ///     Describes whether handle i enumerable value
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        internal static bool HandleIEnumerableValue(TextWriter writer, object value, IDictionary<object, object> objectGraph, JsonOptions options)
        {
            if (value is IEnumerable enumerable)
            {
                writer.Write("[");
                bool first = true;
                foreach (object item in enumerable)
                {
                    if (!first)
                    {
                        writer.Write(",");
                    }
                    
                    first = false;
                    WriteValue(writer, item, objectGraph, options);
                }
                
                writer.Write("]");
                return true;
            }
            
            return false;
        }
        
        /// <summary>
        ///     Describes whether handle stream value
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        internal static bool HandleStreamValue(TextWriter writer, object value, IDictionary<object, object> objectGraph, JsonOptions options)
        {
            if (value is Stream stream)
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                writer.Write(Convert.ToBase64String(buffer));
                return true;
            }
            
            return false;
        }
        
        /// <summary>
        /// Writes the base 64 stream using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="stream">The stream</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        /// <returns>The total</returns>
        internal static long WriteBase64Stream(TextWriter writer, Stream stream, IDictionary<object, object> objectGraph, JsonOptions options = null)
        {
            ValidateWriterAndStream(writer, stream);
            InitializeOptionsAndObjectGraph(options, objectGraph);
            
            long total = HandleWriterCases(writer, stream, objectGraph, options);
            
            WriteStreamToWriter(writer, stream, options, ref total);
            
            return total;
        }
        
        /// <summary>
        /// Validates the writer and stream using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="stream">The stream</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        internal static void ValidateWriterAndStream(TextWriter writer, Stream stream)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }
            
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
        }
        
        /// <summary>
        /// Initializes the options and object graph using the specified options
        /// </summary>
        /// <param name="options">The options</param>
        /// <param name="objectGraph">The object graph</param>
        internal static void InitializeOptionsAndObjectGraph(JsonOptions options, IDictionary<object, object> objectGraph)
        {
            options ??= new JsonOptions();
            objectGraph ??= options.FinalObjectGraph;
            SetOptions(objectGraph, options);
        }
        
        /// <summary>
        /// Handles the writer cases using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="stream">The stream</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        /// <returns>The total</returns>
        internal static long HandleWriterCases(TextWriter writer, Stream stream, IDictionary<object, object> objectGraph, JsonOptions options)
        {
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
            
            return total;
        }
        
        /// <summary>
        /// Writes the stream to writer using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="stream">The stream</param>
        /// <param name="options">The options</param>
        /// <param name="total">The total</param>
        internal static void WriteStreamToWriter(TextWriter writer, Stream stream, JsonOptions options, ref long total)
        {
            using MemoryStream ms = new MemoryStream();
            byte[] bytes = new byte[options.FinalStreamingBufferChunkSize];
            do
            {
                int read = stream.Read(bytes, 0, bytes.Length);
                if (read == 0)
                {
                    break;
                }
                
                ms.Write(bytes, 0, read);
                total += read;
            } while (true);
            
            writer.Write('"');
            writer.Write(Convert.ToBase64String(ms.ToArray()));
            writer.Write('"');
        }
        
        /// <summary>
        ///     Sets the options using the specified obj
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <param name="options">The options</param>
        internal static void SetOptions(object obj, JsonOptions options)
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
        internal static long WriteBase64Stream(Stream inputStream, Stream outputStream, JsonOptions options)
        {
            outputStream.WriteByte((byte) '"');
            CryptoStream b64 = new CryptoStream(outputStream, new ToBase64Transform(), CryptoStreamMode.Write);
            long total = 0L;
            byte[] bytes = new byte[options.FinalStreamingBufferChunkSize];
            do
            {
                int read = inputStream.Read(bytes, 0, bytes.Length);
                if (read == 0)
                {
                    break;
                }
                
                b64.Write(bytes, 0, read);
                total += read;
            } while (true);
            
            b64.FlushFinalBlock();
            b64.Flush();
            outputStream.WriteByte((byte) '"');
            return total;
        }
        
        /// <summary>
        /// Describes whether internal is key value pair enumerable
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
                if (IsGenericEnumerable(t, out keyType, out valueType))
                {
                    return true;
                }
            }
            
            return false;
        }
        
        /// <summary>
        /// Describes whether is generic enumerable
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="keyType">The key type</param>
        /// <param name="valueType">The value type</param>
        /// <returns>The bool</returns>
        internal static bool IsGenericEnumerable(Type type, out Type keyType, out Type valueType)
        {
            keyType = null;
            valueType = null;
            
            if (type.IsGenericType && typeof(IEnumerable<>).IsAssignableFrom(type.GetGenericTypeDefinition()))
            {
                return IsKeyValuePair(type, out keyType, out valueType);
            }
            
            return false;
        }
        
        /// <summary>
        /// Describes whether is key value pair
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="keyType">The key type</param>
        /// <param name="valueType">The value type</param>
        /// <returns>The bool</returns>
        internal static bool IsKeyValuePair(Type type, out Type keyType, out Type valueType)
        {
            Type[] args = type.GetGenericArguments();
            
            if (args.Length == 1 && args[0].IsGenericType && args[0].GetGenericTypeDefinition() == typeof(KeyValuePair<,>))
            {
                keyType = args[0].GetGenericArguments()[0];
                valueType = args[0].GetGenericArguments()[1];
                return true;
            }
            
            keyType = null;
            valueType = null;
            return false;
        }
        
        /// <summary>
        ///     Appends the time zone utc offset using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="dt">The dt</param>
        internal static void AppendTimeZoneUtcOffset(TextWriter writer, DateTime dt)
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
        internal static float Abs(float value) => value < 0f ? -value : value;
        
        /// <summary>
        /// Writes the array using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="array">The array</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        internal static void WriteArray(TextWriter writer, Array array, IDictionary<object, object> objectGraph, JsonOptions options = null)
        {
            ValidateWriterAndArray(writer, array);
            
            options ??= new JsonOptions();
            objectGraph ??= options.FinalObjectGraph;
            SetOptions(objectGraph, options);
            
            if (IsByteArrayAsBase64(options, array))
            {
                WriteBase64Stream(writer, array as byte[], objectGraph, options);
                return;
            }
            
            WriteArray(writer, array, objectGraph, options, Array.Empty<int>());
        }
        
        /// <summary>
        /// Validates the writer and array using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="array">The array</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        internal static void ValidateWriterAndArray(TextWriter writer, Array array)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }
            
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
        }
        
        /// <summary>
        /// Describes whether is byte array as base 64
        /// </summary>
        /// <param name="options">The options</param>
        /// <param name="array">The array</param>
        /// <returns>The bool</returns>
        internal static bool IsByteArrayAsBase64(JsonOptions options, Array array)
        {
            return options.SerializationOptions.HasFlag(JsonSerializationOptions.ByteArrayAsBase64) && array is byte[];
        }
        
        /// <summary>
        /// Writes the base 64 stream using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="bytes">The bytes</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        internal static void WriteBase64Stream(TextWriter writer, byte[] bytes, IDictionary<object, object> objectGraph, JsonOptions options)
        {
            using MemoryStream ms = new MemoryStream(bytes);
            ms.Position = 0;
            WriteBase64Stream(writer, ms, objectGraph, options);
        }
        
        /// <summary>
        /// Writes the array using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="array">The array</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        /// <param name="indices">The indices</param>
        internal static void WriteArray(TextWriter writer, Array array, IDictionary<object, object> objectGraph, JsonOptions options, int[] indices)
        {
            int[] newIndices = CreateNewIndices(indices);
            
            writer.Write('[');
            WriteArrayElements(writer, array, objectGraph, options, indices, newIndices);
            writer.Write(']');
        }
        
        /// <summary>
        /// Creates the new indices using the specified indices
        /// </summary>
        /// <param name="indices">The indices</param>
        /// <returns>The new indices</returns>
        internal static int[] CreateNewIndices(int[] indices)
        {
            int[] newIndices = new int[indices.Length + 1];
            for (int i = 0; i < indices.Length; i++)
            {
                newIndices[i] = indices[i];
            }
            
            return newIndices;
        }
        
        /// <summary>
        /// Writes the array elements using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="array">The array</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        /// <param name="indices">The indices</param>
        /// <param name="newIndices">The new indices</param>
        internal static void WriteArrayElements(TextWriter writer, Array array, IDictionary<object, object> objectGraph, JsonOptions options, int[] indices, int[] newIndices)
        {
            for (int i = 0; i < array.GetLength(indices.Length); i++)
            {
                WriteArrayElementSeparator(writer, i);
                newIndices[indices.Length] = i;
                WriteArrayElement(writer, array, objectGraph, options, newIndices);
            }
        }
        
        /// <summary>
        /// Writes the array element separator using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="i">The </param>
        internal static void WriteArrayElementSeparator(TextWriter writer, int i)
        {
            if (i > 0)
            {
                writer.Write(',');
            }
        }
        
        /// <summary>
        /// Writes the array element using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="array">The array</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        /// <param name="newIndices">The new indices</param>
        internal static void WriteArrayElement(TextWriter writer, Array array, IDictionary<object, object> objectGraph, JsonOptions options, int[] newIndices)
        {
            if (array.Rank == newIndices.Length)
            {
                WriteValue(writer, array.GetValue(newIndices), objectGraph, options);
            }
            else
            {
                WriteArray(writer, array, objectGraph, options, newIndices);
            }
        }
        
        /// <summary>
        /// Writes the enumerable using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="enumerable">The enumerable</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        internal static void WriteEnumerable(TextWriter writer, IEnumerable enumerable, IDictionary<object, object> objectGraph, JsonOptions options = null)
        {
            ValidateWriterAndEnumerable(writer, enumerable);
            
            options = InitializeOptions(options);
            objectGraph = InitializeObjectGraph(objectGraph, options);
            
            WriteEnumerableValues(writer, enumerable, objectGraph, options);
        }
        
        /// <summary>
        /// Validates the writer and enumerable using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="enumerable">The enumerable</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        internal static void ValidateWriterAndEnumerable(TextWriter writer, IEnumerable enumerable)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }
            
            if (enumerable == null)
            {
                throw new ArgumentNullException(nameof(enumerable));
            }
        }
        
        /// <summary>
        /// Initializes the options using the specified options
        /// </summary>
        /// <param name="options">The options</param>
        /// <returns>The json options</returns>
        internal static JsonOptions InitializeOptions(JsonOptions options)
        {
            return options ??= new JsonOptions();
        }
        
        /// <summary>
        /// Initializes the object graph using the specified object graph
        /// </summary>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        /// <returns>A dictionary of object and object</returns>
        internal static IDictionary<object, object> InitializeObjectGraph(IDictionary<object, object> objectGraph, JsonOptions options)
        {
            return objectGraph ??= options.FinalObjectGraph;
        }
        
        /// <summary>
        /// Writes the enumerable values using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="enumerable">The enumerable</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        internal static void WriteEnumerableValues(TextWriter writer, IEnumerable enumerable, IDictionary<object, object> objectGraph, JsonOptions options)
        {
            writer.Write('[');
            bool first = true;
            foreach (object value in enumerable)
            {
                WriteValueWithSeparator(writer, value, ref first, objectGraph, options);
            }
            
            writer.Write(']');
        }
        
        /// <summary>
        /// Writes the value with separator using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <param name="first">The first</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        internal static void WriteValueWithSeparator(TextWriter writer, object value, ref bool first, IDictionary<object, object> objectGraph, JsonOptions options)
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
        
        /// <summary>
        /// Writes the dictionary using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="dictionary">The dictionary</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        internal static void WriteDictionary(TextWriter writer, IDictionary dictionary, IDictionary<object, object> objectGraph, JsonOptions options = null)
        {
            ValidateWriterAndDictionary(writer, dictionary);
            
            options = SetOption(objectGraph, options);
            
            writer.Write('{');
            WriteDictionaryEntries(writer, dictionary, objectGraph, options);
            writer.Write('}');
        }
        
        /// <summary>
        /// Validates the writer and dictionary using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="dictionary">The dictionary</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        internal static void ValidateWriterAndDictionary(TextWriter writer, IDictionary dictionary)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }
            
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }
        }
        
        /// <summary>
        /// Sets the option using the specified object graph
        /// </summary>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        /// <returns>The options</returns>
        internal static JsonOptions SetOption(IDictionary<object, object> objectGraph, JsonOptions options)
        {
            options ??= new JsonOptions();
            objectGraph ??= options.FinalObjectGraph;
            SetOptions(objectGraph, options);
            return options;
        }
        
        /// <summary>
        /// Writes the dictionary entries using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="dictionary">The dictionary</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        internal static void WriteDictionaryEntries(TextWriter writer, IDictionary dictionary, IDictionary<object, object> objectGraph, JsonOptions options)
        {
            bool first = true;
            foreach (DictionaryEntry entry in dictionary)
            {
                if (entry.Key == null)
                {
                    continue;
                }
                
                WriteDictionaryEntry(writer, entry, ref first, objectGraph, options);
            }
        }
        
        /// <summary>
        /// Writes the dictionary entry using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="entry">The entry</param>
        /// <param name="first">The first</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        internal static void WriteDictionaryEntry(TextWriter writer, DictionaryEntry entry, ref bool first, IDictionary<object, object> objectGraph, JsonOptions options)
        {
            string entryKey = string.Format(CultureInfo.InvariantCulture, "{0}", entry.Key);
            if (!first)
            {
                writer.Write(',');
            }
            else
            {
                first = false;
            }
            
            WriteDictionaryKey(writer, entryKey, options);
            writer.Write(':');
            WriteValue(writer, entry.Value, objectGraph, options);
        }
        
        /// <summary>
        /// Writes the dictionary key using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="key">The key</param>
        /// <param name="options">The options</param>
        internal static void WriteDictionaryKey(TextWriter writer, string key, JsonOptions options)
        {
            if (options.SerializationOptions.HasFlag(JsonSerializationOptions.WriteKeysWithoutQuotes))
            {
                writer.Write(EscapeString(key));
            }
            else
            {
                WriteString(writer, key);
            }
        }
        
        /// <summary>
        /// Writes the serializable using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="serializable">The serializable</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        internal static void WriteSerializable(TextWriter writer, ISerializable serializable, IDictionary<object, object> objectGraph, JsonOptions options)
        {
            SerializationInfo info = GetSerializationInfo(serializable);
            WriteEntries(writer, info, objectGraph, options);
        }
        
        /// <summary>
        /// Gets the serialization info using the specified serializable
        /// </summary>
        /// <param name="serializable">The serializable</param>
        /// <returns>The info</returns>
        internal static SerializationInfo GetSerializationInfo(ISerializable serializable)
        {
            SerializationInfo info = new SerializationInfo(serializable.GetType(), DefaultFormatterConverter);
            StreamingContext ctx = new StreamingContext(StreamingContextStates.Remoting, null);
            serializable.GetObjectData(info, ctx);
            info.AddValue(SerializationTypeToken, serializable.GetType().AssemblyQualifiedName);
            return info;
        }
        
        /// <summary>
        /// Writes the entries using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="info">The info</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        internal static void WriteEntries(TextWriter writer, SerializationInfo info, IDictionary<object, object> objectGraph, JsonOptions options)
        {
            bool first = true;
            foreach (SerializationEntry entry in info)
            {
                WriteEntry(writer, entry, ref first, objectGraph, options);
            }
        }
        
        /// <summary>
        /// Writes the entry using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="entry">The entry</param>
        /// <param name="first">The first</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        internal static void WriteEntry(TextWriter writer, SerializationEntry entry, ref bool first, IDictionary<object, object> objectGraph, JsonOptions options)
        {
            WriteCommaIfNeeded(writer, ref first);
            WriteEntryName(writer, entry, options);
            writer.Write(':');
            WriteValue(writer, entry.Value, objectGraph, options);
        }
        
        /// <summary>
        /// Writes the comma if needed using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="first">The first</param>
        internal static void WriteCommaIfNeeded(TextWriter writer, ref bool first)
        {
            if (!first)
            {
                writer.Write(',');
            }
            else
            {
                first = false;
            }
        }
        
        /// <summary>
        /// Writes the entry name using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="entry">The entry</param>
        /// <param name="options">The options</param>
        internal static void WriteEntryName(TextWriter writer, SerializationEntry entry, JsonOptions options)
        {
            if (options.SerializationOptions.HasFlag(JsonSerializationOptions.WriteKeysWithoutQuotes))
            {
                writer.Write(EscapeString(entry.Name));
            }
            else
            {
                WriteString(writer, entry.Name);
            }
        }
        
        /// <summary>
        ///     Describes whether force serializable
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <returns>The bool</returns>
        internal static bool ForceSerializable(object obj) => obj is Exception;
        
        /// <summary>
        ///     Writes the object using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        internal static void WriteObject(TextWriter writer, object value, IDictionary<object, object> objectGraph, JsonOptions options = null)
        {
            CheckAndSetOptions(writer, value, ref objectGraph, ref options);
            
            writer.Write('{');
            
            HandleBeforeWriteObjectCallback(writer, value, objectGraph, options);
            
            WriteSerializableOrValues(writer, value, objectGraph, options);
            
            HandleAfterWriteObjectCallback(writer, value, objectGraph, options);
            
            writer.Write('}');
        }
        
        /// <summary>
        ///     Checks the and set options using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        internal static void CheckAndSetOptions(TextWriter writer, object value, ref IDictionary<object, object> objectGraph, ref JsonOptions options)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }
            
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            
            options ??= new JsonOptions();
            objectGraph ??= options.FinalObjectGraph;
            SetOptions(objectGraph, options);
        }
        
        /// <summary>
        ///     Handles the before write object callback using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        internal static void HandleBeforeWriteObjectCallback(TextWriter writer, object value, IDictionary<object, object> objectGraph, JsonOptions options)
        {
            if (options.BeforeWriteObjectCallback == null)
            {
                return;
            }
            
            JsonEventArgs eventArgs = new JsonEventArgs(writer, value, objectGraph, options)
            {
                EventType = JsonEventType.BeforeWriteObject
            };
            
            options.BeforeWriteObjectCallback(eventArgs);
        }
        
        /// <summary>
        ///     Writes the serializable or values using the specified writer.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="value">The value.</param>
        /// <param name="objectGraph">The object graph.</param>
        /// <param name="options">The options.</param>
        internal static void WriteSerializableOrValues(TextWriter writer, object value, IDictionary<object, object> objectGraph, JsonOptions options)
        {
            // Determine if the value should be treated as ISerializable
            bool useISerializable = options.SerializationOptions.HasFlag(JsonSerializationOptions.UseISerializable) || ForceSerializable(value);
            
            // If the value is ISerializable, write it as such
            if (useISerializable && value is ISerializable serializable)
            {
                WriteSerializable(writer, serializable, objectGraph, options);
            }
            else
            {
                // Otherwise, get the type definition and write the values
                TypeDef typeDefinition = TypeDef.Get(value.GetType(), options);
                typeDefinition.WriteValues(writer, value, objectGraph, options);
            }
        }
        
        /// <summary>
        /// Handles the after write object callback using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        internal static void HandleAfterWriteObjectCallback(TextWriter writer, object value, IDictionary<object, object> objectGraph, JsonOptions options)
        {
            if (IsCallbackAvailable(options))
            {
                JsonEventArgs eventArgs = CreateJsonEventArgsAfterWriteObject(writer, value, objectGraph, options);
                InvokeCallback(options, eventArgs);
            }
        }
        
        /// <summary>
        /// Describes whether is callback available
        /// </summary>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        internal static bool IsCallbackAvailable(JsonOptions options)
        {
            return options.AfterWriteObjectCallback != null;
        }
        
        /// <summary>
        /// Creates the json event args after write object using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        /// <returns>The json event args</returns>
        internal static JsonEventArgs CreateJsonEventArgsAfterWriteObject(TextWriter writer, object value, IDictionary<object, object> objectGraph, JsonOptions options)
        {
            return new JsonEventArgs(writer, value, objectGraph, options)
            {
                EventType = JsonEventType.AfterWriteObject
            };
        }
        
        /// <summary>
        /// Invokes the callback using the specified options
        /// </summary>
        /// <param name="options">The options</param>
        /// <param name="eventArgs">The event args</param>
        internal static void InvokeCallback(JsonOptions options, JsonEventArgs eventArgs)
        {
            options.AfterWriteObjectCallback(eventArgs);
        }
        
        /// <summary>
        ///     Determines whether the specified value is a value type and is equal to zero.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>true if the specified value is a value type and is equal to zero; false otherwise.</returns>
        public static bool IsZeroValueType(object value)
        {
            if (value == null)
            {
                return false;
            }
            
            Type type = value.GetType();
            return type.IsValueType && value.Equals(Activator.CreateInstance(type));
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
            {
                throw new ArgumentNullException(nameof(writer));
            }
            
            name ??= string.Empty;
            options ??= new JsonOptions();
            objectGraph ??= options.FinalObjectGraph;
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
        internal static void WriteString(TextWriter writer, string text)
        {
            ValidateWriter(writer);
            WriteText(writer, text);
        }
        
        
        /// <summary>
        ///     Writes the text using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="text">The text</param>
        internal static void WriteText(TextWriter writer, string text)
        {
            if (text == null)
            {
                writer.Write(Null);
            }
            else
            {
                WriteEscapedString(writer, text);
            }
        }
        
        /// <summary>
        ///     Writes the escaped string using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="text">The text</param>
        internal static void WriteEscapedString(TextWriter writer, string text)
        {
            writer.Write('"');
            writer.Write(EscapeString(text));
            writer.Write('"');
        }
        
        /// <summary>
        ///     Writes a string to a JSON writer.
        /// </summary>
        /// <param name="writer">The input writer. May not be null.</param>
        /// <param name="text">The text.</param>
        internal static void WriteUnescapedString(TextWriter writer, string text)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }
            
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
        internal static void AppendCharAsUnicode(StringBuilder sb, char c)
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
        internal static void SerializeFormatted(TextWriter writer, object value, JsonOptions options = null)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }
            
            options ??= new JsonOptions();
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
        internal static void WriteFormatted(TextWriter writer, object jsonObject, JsonOptions options = null)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }
            
            options ??= new JsonOptions();
            IndentedTextWriter itw = new IndentedTextWriter(writer, options.FormattingTab);
            WriteFormatted(itw, jsonObject, options);
        }
        
        /// <summary>
        ///     Writes the formatted using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="jsonObject">The json object</param>
        /// <param name="options">The options</param>
        internal static void WriteFormatted(IndentedTextWriter writer, object jsonObject, JsonOptions options)
        {
            switch (jsonObject)
            {
                case DictionaryEntry entry:
                    WriteDictionaryEntry(writer, entry, options);
                    return;
                case IDictionary dictionary:
                    WriteDictionary(writer, dictionary, options);
                    return;
                case string s:
                    WriteString(writer, s);
                    return;
                case IEnumerable enumerable:
                    WriteEnumerable(writer, enumerable, options);
                    return;
                default:
                    WriteValue(writer, jsonObject, null, options);
                    break;
            }
        }
        
        /// <summary>
        ///     Writes the dictionary entry using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="entry">The entry</param>
        /// <param name="options">The options</param>
        internal static void WriteDictionaryEntry(IndentedTextWriter writer, DictionaryEntry entry, JsonOptions options)
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
        }
        
        //// <summary>
        /// Writes the dictionary using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="dictionary">The dictionary</param>
        /// <param name="options">The options</param>
        internal static void WriteDictionary(IndentedTextWriter writer, IDictionary dictionary, JsonOptions options)
        {
            writer.WriteLine('{');
            writer.Indent++;
            
            bool isFirstEntry = true;
            foreach (DictionaryEntry entry in dictionary)
            {
                if (!isFirstEntry)
                {
                    writer.WriteLine(',');
                }
                
                WriteFormatted(writer, entry, options);
                isFirstEntry = false;
            }
            
            writer.Indent--;
            writer.WriteLine('}');
        }
        
        /// <summary>
        ///     Writes the enumerable using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="enumerable">The enumerable</param>
        /// <param name="options">The options</param>
        internal static void WriteEnumerable(IndentedTextWriter writer, IEnumerable enumerable, JsonOptions options)
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
        }
        
        /// <summary>
        ///     Escapes the string using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The string</returns>
        public static string EscapeString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            
            StringBuilder builder = new StringBuilder();
            int startIndex = 0;
            int count = 0;
            
            for (int i = 0; i < value.Length; i++)
            {
                char c = value[i];
                if (NeedsEscaping(c))
                {
                    if (count > 0)
                    {
                        builder.Append(value, startIndex, count);
                    }
                    
                    builder.Append(GetEscapedString(c));
                    startIndex = i + 1;
                    count = 0;
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
        ///     Describes whether needs escaping
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The bool</returns>
        internal static bool NeedsEscaping(char c) => c == '\r' || c == '\t' || c == '"' || c == '\'' || c == '<' || c == '>' || c == '\\' || c == '\n' || c == '\b' || c == '\f' || c < ' ';
        
        /// <summary>
        ///     Gets the escaped string using the specified c
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The string</returns>
        internal static string GetEscapedString(char c)
        {
            Dictionary<char, string> escapeMapping = new Dictionary<char, string>
            {
                {'<', @"\u003C"},
                {'>', @"\u003E"},
                {'\'', @"\u0027"},
                {'\\', @"\\"},
                {'\b', @"\b"},
                {'\t', @"\t"},
                {'\n', @"\n"},
                {'\f', @"\f"},
                {'\r', @"\r"},
                {'"', "\\\""}
            };
            
            return escapeMapping.ContainsKey(c) ? escapeMapping[c] : $"\\u{(int) c:X4}";
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
            {
                return null;
            }
            
            if (!TryGetValueByPath(dictionary, path, out object obj))
            {
                return null;
            }
            
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
            if (IsDictionaryNull(dictionary))
            {
                value = default(T);
                return false;
            }
            
            if (!TryGetValue(dictionary, path, out object obj))
            {
                value = default(T);
                return false;
            }
            
            return Conversions.TryChangeType(obj, out value);
        }
        
        /// <summary>
        /// Describes whether is dictionary null
        /// </summary>
        /// <param name="dictionary">The dictionary</param>
        /// <returns>The bool</returns>
        internal static bool IsDictionaryNull(IDictionary<string, object> dictionary)
        {
            return dictionary == null;
        }
        
        /// <summary>
        /// Describes whether try get value
        /// </summary>
        /// <param name="dictionary">The dictionary</param>
        /// <param name="path">The path</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool TryGetValue(IDictionary<string, object> dictionary, string path, out object value)
        {
            return TryGetValueByPath(dictionary, path, out value);
        }
        
        /// <summary>
        /// Describes whether try get value by path
        /// </summary>
        /// <param name="dictionary">The dictionary</param>
        /// <param name="path">The path</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool TryGetValueByPath(this IDictionary<string, object> dictionary, string path, out object value)
        {
            value = null;
            
            if (IsInvalidPathOrDictionary(path, dictionary))
            {
                return false;
            }
            
            return TryGetNestedValue(dictionary, path.Split('.'), out value);
        }
        
        /// <summary>
        /// Describes whether is invalid path or dictionary
        /// </summary>
        /// <param name="path">The path</param>
        /// <param name="dictionary">The dictionary</param>
        /// <returns>The bool</returns>
        internal static bool IsInvalidPathOrDictionary(string path, IDictionary<string, object> dictionary)
        {
            return string.IsNullOrEmpty(path) || dictionary == null;
        }
        
        /// <summary>
        /// Describes whether try get nested value
        /// </summary>
        /// <param name="dictionary">The dictionary</param>
        /// <param name="pathSegments">The path segments</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal static bool TryGetNestedValue(IDictionary<string, object> dictionary, string[] pathSegments, out object value)
        {
            IDictionary<string, object> currentDictionary = dictionary;
            value = null;
            
            foreach (string segment in pathSegments)
            {
                if (!TryGetElement(currentDictionary, segment, out object element))
                {
                    return false;
                }
                
                if (IsElementDictionary(element))
                {
                    currentDictionary = (IDictionary<string, object>) element;
                }
                else
                {
                    value = element;
                    return true;
                }
            }
            
            return false;
        }
        
        /// <summary>
        /// Describes whether try get element
        /// </summary>
        /// <param name="dictionary">The dictionary</param>
        /// <param name="key">The key</param>
        /// <param name="element">The element</param>
        /// <returns>The bool</returns>
        internal static bool TryGetElement(IDictionary<string, object> dictionary, string key, out object element)
        {
            return dictionary.TryGetValue(key, out element);
        }
        
        /// <summary>
        /// Describes whether is element dictionary
        /// </summary>
        /// <param name="element">The element</param>
        /// <returns>The bool</returns>
        internal static bool IsElementDictionary(object element)
        {
            return element is IDictionary<string, object>;
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
        internal static T GetAttribute<T>(this AttributeCollection attributes) where T : Attribute
        {
            foreach (object att in attributes)
            {
                if (att is T attribute)
                {
                    return attribute;
                }
            }
            
            return null;
        }
        
        /// <summary>
        ///     Determines if two strings are equal, ignoring case.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="target">The target string to compare with the source string.</param>
        /// <param name="trim">Indicates whether to trim the strings before comparison.</param>
        /// <returns>True if the strings are equal (ignoring case), false otherwise.</returns>
        internal static bool EqualsIgnoreCase(this string source, string target, bool trim = false)
        {
            if (trim)
            {
                source = source?.Trim();
                target = target?.Trim();
            }
            
            if (source == null)
            {
                return target == null;
            }
            
            return string.Equals(source, target, StringComparison.OrdinalIgnoreCase);
        }
        
        /// <summary>
        ///     Nullifies the str
        /// </summary>
        /// <param name="str">The str</param>
        /// <returns>The string</returns>
        internal static string Nullify(this string str)
        {
            if (str == null)
            {
                return null;
            }
            
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }
            
            string t = str.Trim();
            return t.Length == 0 ? null : t;
        }
    }
}