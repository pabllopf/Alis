// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TypeDef.cs
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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     The type def class
    /// </summary>
    internal sealed class TypeDef
    {
        /// <summary>
        ///     The type def
        /// </summary>
        private static readonly Dictionary<string, TypeDef> Defs = new Dictionary<string, TypeDef>();

        /// <summary>
        ///     The key value type
        /// </summary>
        private static readonly Dictionary<Type, KeyValueType> KeyType = new Dictionary<Type, KeyValueType>();

        /// <summary>
        ///     The lock
        /// </summary>
        private static readonly object LockField = new object();

        /// <summary>
        ///     The member definition
        /// </summary>
        private readonly List<MemberDefinition> _deserializationMembers;

        /// <summary>
        ///     The member definition
        /// </summary>
        private readonly List<MemberDefinition> _serializationMembers;

        /// <summary>
        ///     The type
        /// </summary>
        private readonly Type _type;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TypeDef" /> class
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="options">The options</param>
        internal TypeDef(Type type, JsonOptions options)
        {
            _type = type;
            IEnumerable<MemberDefinition> members = options.SerializationOptions.HasFlag(JsonSerializationOptions.UseReflection) ? EnumerateDefinitionsUsingReflection(true, type, options) : EnumerateDefinitionsUsingTypeDescriptors(true, type, options);

            _serializationMembers = new List<MemberDefinition>(options.FinalizeSerializationMembers(type, members));

            members = options.SerializationOptions.HasFlag(JsonSerializationOptions.UseReflection) ? EnumerateDefinitionsUsingReflection(false, type, options) : EnumerateDefinitionsUsingTypeDescriptors(false, type, options);

            _deserializationMembers = new List<MemberDefinition>(options.FinalizeDeserializationMembers(type, members));
        }

        /// <summary>
        ///     Gets the deserialization member using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The member definition</returns>
        internal MemberDefinition GetDeserializationMember(string key) => key == null ? null : _deserializationMembers.FirstOrDefault(def => string.Compare(def.WireName, key, StringComparison.OrdinalIgnoreCase) == 0);

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
            MemberDefinition member = GetDeserializationMember(key);
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
            bool first = true;
            foreach (MemberDefinition member in _serializationMembers)
            {
                bool nameChanged;
                string name;
                object value;
                (first, nameChanged, name, value) = HandleWriteNamedValueObjectCallback(writer, component, objectGraph, options, member, first);

                if (ShouldSkipValue(options, member, value))
                    continue;

                if (!first)
                {
                    writer.Write(',');
                }
                else
                {
                    first = false;
                }

                WriteMemberValue(writer, options, member, nameChanged, name, value, objectGraph);
            }
        }

        /// <summary>
        ///     Handles the write named value object callback using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="component">The component</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        /// <param name="member">The member</param>
        /// <param name="first">The first</param>
        /// <returns>The bool bool string object</returns>
        private (bool, bool, string, object) HandleWriteNamedValueObjectCallback(TextWriter writer, object component, IDictionary<object, object> objectGraph, JsonOptions options, MemberDefinition member, bool first)
        {
            bool nameChanged = false;
            string name = member.WireName;
            object value = member.Accessor.Get(component);
            if (options.WriteNamedValueObjectCallback != null)
            {
                JsonEventArgs e = new JsonEventArgs(writer, value, objectGraph, options, name, component)
                {
                    EventType = JsonEventType.WriteNamedValueObject,
                    First = first
                };
                options.WriteNamedValueObjectCallback(e);
                first = e.First;
                if (e.Handled)
                    return (first, false, name, value);

                nameChanged = name != e.Name;
                name = e.Name;
                value = e.Value;
            }

            return (first, nameChanged, name, value);
        }

        /// <summary>
        ///     Describes whether this instance should skip value
        /// </summary>
        /// <param name="options">The options</param>
        /// <param name="member">The member</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        private bool ShouldSkipValue(JsonOptions options, MemberDefinition member, object value)
        {
            if (options.SerializationOptions.HasFlag(JsonSerializationOptions.SkipNullPropertyValues))
            {
                if (value == null)
                    return true;
            }

            if (options.SerializationOptions.HasFlag(JsonSerializationOptions.SkipZeroValueTypes))
            {
                if (member.IsZeroValue(value))
                    return true;
            }

            if (options.SerializationOptions.HasFlag(JsonSerializationOptions.SkipNullDateTimeValues))
            {
                if (member.IsNullDateTimeValue(value))
                    return true;
            }

            bool skipDefaultValues = options.SerializationOptions.HasFlag(JsonSerializationOptions.SkipDefaultValues);
            if (skipDefaultValues && member.HasDefaultValue)
            {
                if (member.EqualsDefaultValue(value))
                    return true;
            }

            return false;
        }

        /// <summary>
        ///     Writes the member value using the specified writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="options">The options</param>
        /// <param name="member">The member</param>
        /// <param name="nameChanged">The name changed</param>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="objectGraph">The object graph</param>
        private void WriteMemberValue(TextWriter writer, JsonOptions options, MemberDefinition member, bool nameChanged, string name, object value, IDictionary<object, object> objectGraph)
        {
            if (nameChanged)
            {
                JsonSerializer.WriteNameValue(writer, name, value, objectGraph, options);
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
                JsonSerializer.WriteValue(writer, value, objectGraph, options);
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
        internal static string GetKey(Type type, JsonOptions options) => type.AssemblyQualifiedName + '\0' + options.GetCacheKey();

        /// <summary>
        ///     Unlock the get using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="options">The options</param>
        /// <returns>The ta</returns>
        internal static TypeDef UnlockedGet(Type type, JsonOptions options)
        {
            string key = GetKey(type, options);
            if (!Defs.TryGetValue(key, out TypeDef ta))
            {
                ta = new TypeDef(type, options);
                Defs.Add(key, ta);
            }

            return ta;
        }

        /// <summary>
        ///     Locks the action
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="action">The action</param>
        /// <param name="state">The state</param>
        public static void LockMethod<T>(Action<T> action, T state)
        {
            lock (LockField)
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
            lock (LockField)
            {
                TypeDef ta = UnlockedGet(type, options);
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
            lock (LockField)
            {
                TypeDef ta = UnlockedGet(type, options);
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
            lock (LockField)
            {
                TypeDef ta = UnlockedGet(type, options);
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
            lock (LockField)
            {
                TypeDef ta = UnlockedGet(type, options);
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
            lock (LockField)
            {
                TypeDef ta = UnlockedGet(type, options);
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
            lock (LockField)
            {
                TypeDef ta = UnlockedGet(type, options);
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
            lock (LockField)
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
            lock (LockField)
            {
                if (!KeyType.TryGetValue(type, out KeyValueType kv))
                {
                    kv = new KeyValueType();
                    JsonSerializer.InternalIsKeyValuePairEnumerable(type, out kv.KeyType, out kv.ValueType);
                    KeyType.Add(type, kv);
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
        [ExcludeFromCodeCoverage]
        internal static IEnumerable<MemberDefinition> EnumerateDefinitionsUsingReflection(bool serialization, Type type, JsonOptions options)
        {
            foreach (var member in HandlePropertySerialization(serialization, type, options))
            {
                yield return member;
            }

            if (options.SerializationOptions.HasFlag(JsonSerializationOptions.SerializeFields))
            {
                foreach (var member in HandleFieldSerialization(serialization, type, options))
                {
                    yield return member;
                }
            }
        }

        /// <summary>
        /// Handles the property serialization using the specified serialization
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="type">The type</param>
        /// <param name="options">The options</param>
        /// <returns>An enumerable of member definition</returns>
        private static IEnumerable<MemberDefinition> HandlePropertySerialization(bool serialization, Type type, JsonOptions options)
        {
            foreach (PropertyInfo info in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (ShouldSkipProperty(serialization, info, options))
                    continue;

                yield return CreateMemberDefinition(serialization, info, options);
            }
        }

        /// <summary>
        /// Describes whether should skip property
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="info">The info</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        private static bool ShouldSkipProperty(bool serialization, PropertyInfo info, JsonOptions options)
        {
            if (CheckJsonAttribute(serialization, info, options) ||
                CheckXmlIgnoreAttribute(info, options) ||
                CheckScriptIgnore(info, options) ||
                CheckSerialization(serialization, info))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Describes whether check json attribute
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="info">The info</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        private static bool CheckJsonAttribute(bool serialization, PropertyInfo info, JsonOptions options)
        {
            if (options.SerializationOptions.HasFlag(JsonSerializationOptions.UseJsonAttribute))
            {
                JsonAttribute ja = JsonSerializer.GetJsonAttribute(info);
                if (ja != null)
                {
                    switch (serialization)
                    {
                        case true when ja.IgnoreWhenSerializing:
                        case false when ja.IgnoreWhenDeserializing:
                            return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Describes whether check xml ignore attribute
        /// </summary>
        /// <param name="info">The info</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        private static bool CheckXmlIgnoreAttribute(PropertyInfo info, JsonOptions options)
        {
            if (options.SerializationOptions.HasFlag(JsonSerializationOptions.UseXmlIgnore))
            {
                if (info.IsDefined(typeof(XmlIgnoreAttribute), true))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Describes whether check script ignore
        /// </summary>
        /// <param name="info">The info</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        private static bool CheckScriptIgnore(PropertyInfo info, JsonOptions options)
        {
            if (options.SerializationOptions.HasFlag(JsonSerializationOptions.UseScriptIgnore))
            {
                if (JsonSerializer.HasScriptIgnore(info))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Describes whether check serialization
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="info">The info</param>
        /// <returns>The bool</returns>
        private static bool CheckSerialization(bool serialization, PropertyInfo info)
        {
            if (serialization)
            {
                if (!info.CanRead)
                    return true;

                MethodInfo getMethod = info.GetGetMethod();
                if (getMethod == null || getMethod.GetParameters().Length > 0)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Creates the member definition using the specified serialization
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="info">The info</param>
        /// <param name="options">The options</param>
        /// <returns>The ma</returns>
        private static MemberDefinition CreateMemberDefinition(bool serialization, PropertyInfo info, JsonOptions options)
        {
            string name = JsonSerializer.GetObjectName(info, info.Name);

            MemberDefinition ma = new MemberDefinition
            {
                Type = info.PropertyType,
                Name = info.Name
            };
            if (serialization)
            {
                ma.WireName = name;
                ma.EscapedWireName = JsonSerializer.EscapeString(name);
            }
            else
            {
                ma.WireName = name;
            }

            ma.HasDefaultValue = JsonSerializer.TryGetObjectDefaultValue(info, out object defaultValue);
            ma.DefaultValue = defaultValue;
            ma.Accessor = (IMemberAccessor) Activator.CreateInstance(typeof(PropertyInfoAccessor<,>).MakeGenericType(info.DeclaringType, info.PropertyType), info);

            return ma;
        }

        /// <summary>
        /// Handles the field serialization using the specified serialization
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="type">The type</param>
        /// <param name="options">The options</param>
        /// <returns>An enumerable of member definition</returns>
        private static IEnumerable<MemberDefinition> HandleFieldSerialization(bool serialization, Type type, JsonOptions options)
        {
            foreach (FieldInfo info in type.GetFields(BindingFlags.Public | BindingFlags.Instance))
            {
                if (ShouldSkipField(serialization, info, options))
                    continue;

                yield return CreateMemberDefinition(serialization, info, options);
            }
        }

        /// <summary>
        /// Describes whether should skip field
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="info">The info</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        private static bool ShouldSkipField(bool serialization, FieldInfo info, JsonOptions options)
        {
            if (options.SerializationOptions.HasFlag(JsonSerializationOptions.UseJsonAttribute))
            {
                JsonAttribute ja = JsonSerializer.GetJsonAttribute(info);
                if (ja != null)
                {
                    switch (serialization)
                    {
                        case true when ja.IgnoreWhenSerializing:
                        case false when ja.IgnoreWhenDeserializing:
                            return true;
                    }
                }
            }

            if (options.SerializationOptions.HasFlag(JsonSerializationOptions.UseXmlIgnore))
            {
                if (info.IsDefined(typeof(XmlIgnoreAttribute), true))
                    return true;
            }

            if (options.SerializationOptions.HasFlag(JsonSerializationOptions.UseScriptIgnore))
            {
                if (JsonSerializer.HasScriptIgnore(info))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Creates the member definition using the specified serialization
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="info">The info</param>
        /// <param name="options">The options</param>
        /// <returns>The ma</returns>
        private static MemberDefinition CreateMemberDefinition(bool serialization, FieldInfo info, JsonOptions options)
        {
            string name = JsonSerializer.GetObjectName(info, info.Name);

            MemberDefinition ma = new MemberDefinition
            {
                Type = info.FieldType,
                Name = info.Name
            };
            if (serialization)
            {
                ma.WireName = name;
                ma.EscapedWireName = JsonSerializer.EscapeString(name);
            }
            else
            {
                ma.WireName = name;
            }

            ma.HasDefaultValue = JsonSerializer.TryGetObjectDefaultValue(info, out object defaultValue);
            ma.DefaultValue = defaultValue;
            ma.Accessor = (IMemberAccessor) Activator.CreateInstance(typeof(FieldInfoAccessor), info);

            return ma;
        }

        /// <summary>
        /// Enumerates the definitions using type descriptors using the specified serialization
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="type">The type</param>
        /// <param name="options">The options</param>
        /// <returns>An enumerable of member definition</returns>
        [ExcludeFromCodeCoverage]
        private static IEnumerable<MemberDefinition> EnumerateDefinitionsUsingTypeDescriptors(bool serialization, Type type, JsonOptions options)
        {
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(type).Cast<PropertyDescriptor>())
            {
                if (ShouldSkipDescriptor(serialization, descriptor, options))
                    continue;

                yield return CreateMemberDefinition(serialization, descriptor, options);
            }
        }

        /// <summary>
        /// Describes whether should skip descriptor
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="descriptor">The descriptor</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        private static bool ShouldSkipDescriptor(bool serialization, PropertyDescriptor descriptor, JsonOptions options)
        {
            if (CheckJsonAttribute(serialization, descriptor, options) ||
                CheckXmlIgnoreAttribute(descriptor, options) ||
                CheckScriptIgnore(descriptor, options) ||
                CheckSkipGetOnly(descriptor, options))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Describes whether check json attribute
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="descriptor">The descriptor</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        private static bool CheckJsonAttribute(bool serialization, PropertyDescriptor descriptor, JsonOptions options)
        {
            if (options.SerializationOptions.HasFlag(JsonSerializationOptions.UseJsonAttribute))
            {
                JsonAttribute ja = descriptor.GetAttribute<JsonAttribute>();
                if (ja != null)
                {
                    if (serialization && ja.IgnoreWhenSerializing)
                        return true;

                    if (!serialization && ja.IgnoreWhenDeserializing)
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Describes whether check xml ignore attribute
        /// </summary>
        /// <param name="descriptor">The descriptor</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        private static bool CheckXmlIgnoreAttribute(PropertyDescriptor descriptor, JsonOptions options)
        {
            if (options.SerializationOptions.HasFlag(JsonSerializationOptions.UseXmlIgnore))
            {
                if (descriptor.GetAttribute<XmlIgnoreAttribute>() != null)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Describes whether check script ignore
        /// </summary>
        /// <param name="descriptor">The descriptor</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        private static bool CheckScriptIgnore(PropertyDescriptor descriptor, JsonOptions options)
        {
            if (options.SerializationOptions.HasFlag(JsonSerializationOptions.UseScriptIgnore))
            {
                if (JsonSerializer.HasScriptIgnore(descriptor))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Describes whether check skip get only
        /// </summary>
        /// <param name="descriptor">The descriptor</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        private static bool CheckSkipGetOnly(PropertyDescriptor descriptor, JsonOptions options)
        {
            if (options.SerializationOptions.HasFlag(JsonSerializationOptions.SkipGetOnly) && descriptor.IsReadOnly)
                return true;

            return false;
        }

        /// <summary>
        /// Creates the member definition using the specified serialization
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="descriptor">The descriptor</param>
        /// <param name="options">The options</param>
        /// <returns>The ma</returns>
        private static MemberDefinition CreateMemberDefinition(bool serialization, PropertyDescriptor descriptor, JsonOptions options)
        {
            string name = JsonSerializer.GetObjectName(descriptor, descriptor.Name);

            MemberDefinition ma = new MemberDefinition
            {
                Type = descriptor.PropertyType,
                Name = descriptor.Name
            };
            if (serialization)
            {
                ma.WireName = name;
                ma.EscapedWireName = JsonSerializer.EscapeString(name);
            }
            else
            {
                ma.WireName = name;
            }

            ma.HasDefaultValue = JsonSerializer.TryGetObjectDefaultValue(descriptor, out object defaultValue);
            ma.DefaultValue = defaultValue;
            ma.Accessor = (IMemberAccessor) Activator.CreateInstance(typeof(PropertyDescriptorAccessor), descriptor);

            return ma;
        }
    }
}