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
        internal static readonly Dictionary<string, TypeDef> Defs = new Dictionary<string, TypeDef>();
        
        /// <summary>
        ///     The key value type
        /// </summary>
        internal static readonly Dictionary<Type, KeyValueType> KeyType = new Dictionary<Type, KeyValueType>();
        
        /// <summary>
        ///     The lock
        /// </summary>
        internal static readonly object LockField = new object();
        
        /// <summary>
        ///     The member definition
        /// </summary>
        internal readonly List<MemberDefinition> _deserializationMembers;
        
        /// <summary>
        ///     The member definition
        /// </summary>
        internal readonly List<MemberDefinition> _serializationMembers;
        
        /// <summary>
        ///     The type
        /// </summary>
        internal readonly Type _type;
        
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
        ///     Compares the wire name with the specified key.
        /// </summary>
        /// <param name="def">The member definition</param>
        /// <param name="key">The key</param>
        /// <returns>True if the wire name matches the key, false otherwise</returns>
        internal static bool CompareWireName(MemberDefinition def, string key)
        {
            return string.Compare(def.WireName, key, StringComparison.OrdinalIgnoreCase) == 0;
        }
        
        /// <summary>
        ///     Finds the deserialization member using the specified key.
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The member definition</returns>
        internal MemberDefinition FindDeserializationMember(string key)
        {
            return _deserializationMembers.FirstOrDefault(def => CompareWireName(def, key));
        }

        /// <summary>
        ///     Gets the deserialization member using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The member definition</returns>
        internal MemberDefinition GetDeserializationMember(string key)
        {
            return key == null ? null : FindDeserializationMember(key);
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
            MemberDefinition member = GetDeserializationMember(key);
            member?.ApplyEntry(dictionary, target, key, value, options);
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
                {
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
                
                WriteMemberValue(writer, options, member, nameChanged, name, value, objectGraph);
            }
        }
        
        /// <summary>
        ///     Gets the member value and name.
        /// </summary>
        /// <param name="member">The member</param>
        /// <param name="component">The component</param>
        /// <returns>The bool, string and object</returns>
        internal static (bool, string, object) GetMemberValueAndName(MemberDefinition member, object component)
        {
            bool nameChanged = false;
            string name = member.WireName;
            object value = member.Accessor.Get(component);

            return (nameChanged, name, value);
        }

        /// <summary>
        ///     Invokes the callback if present.
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="component">The component</param>
        /// <param name="objectGraph">The object graph</param>
        /// <param name="options">The options</param>
        /// <param name="first">The first</param>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <returns>The JsonEventArgs</returns>
        internal static JsonEventArgs InvokeCallback(TextWriter writer, object component, IDictionary<object, object> objectGraph, JsonOptions options, bool first, string name, object value)
        {
            if (options.WriteNamedValueObjectCallback == null)
            {
                return null;
            }
            
            JsonEventArgs e = new JsonEventArgs(writer, value, objectGraph, options, name, component)
            {
                EventType = JsonEventType.WriteNamedValueObject,
                First = first
            };
            options.WriteNamedValueObjectCallback(e);
            return e;
        }

/// <summary>
///     Handles the event and returns updated values.
/// </summary>
/// <param name="e">The JsonEventArgs</param>
/// <param name="first">The first</param>
/// <param name="name">The name</param>
/// <param name="value">The value</param>
/// <returns>The bool, bool, string and object</returns>
internal static (bool, bool, string, object) HandleEvent(JsonEventArgs e, bool first, string name, object value)
{
    if (e != null)
    {
        first = e.First;
        if (e.Handled)
        {
            return (first, false, name, value);
        }

        bool nameChanged = name != e.Name;
        name = e.Name;
        value = e.Value;
        return (first, nameChanged, name, value);
    }

    return (first, false, name, value);
}

/// <summary>
///     Handles the callback if present.
/// </summary>
/// <param name="writer">The writer</param>
/// <param name="component">The component</param>
/// <param name="objectGraph">The object graph</param>
/// <param name="options">The options</param>
/// <param name="first">The first</param>
/// <param name="nameChanged">The name changed</param>
/// <param name="name">The name</param>
/// <param name="value">The value</param>
/// <returns>The bool, bool, string and object</returns>
internal static (bool, bool, string, object) HandleCallback(TextWriter writer, object component, IDictionary<object, object> objectGraph, JsonOptions options, bool first, bool nameChanged, string name, object value)
{
    JsonEventArgs e = InvokeCallback(writer, component, objectGraph, options, first, name, value);
    return HandleEvent(e, first, name, value);
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
        /// <returns>The bool, bool, string and object</returns>
        internal static (bool, bool, string, object) HandleWriteNamedValueObjectCallback(TextWriter writer, object component, IDictionary<object, object> objectGraph, JsonOptions options, MemberDefinition member, bool first)
        {
            var (nameChanged, name, value) = GetMemberValueAndName(member, component);
            return HandleCallback(writer, component, objectGraph, options, first, nameChanged, name, value);
        }
        
        /// <summary>
        /// Describes whether this instance should skip value
        /// </summary>
        /// <param name="options">The options</param>
        /// <param name="member">The member</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal bool ShouldSkipValue(JsonOptions options, MemberDefinition member, object value)
        {
            return ShouldSkipNullPropertyValues(options, value) ||
                   ShouldSkipZeroValueTypes(options, member, value) ||
                   ShouldSkipNullDateTimeValues(options, member, value) ||
                   ShouldSkipDefaultValues(options, member, value);
        }

        /// <summary>
        /// Describes whether this instance should skip null property values
        /// </summary>
        /// <param name="options">The options</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal bool ShouldSkipNullPropertyValues(JsonOptions options, object value)
        {
            return options.SerializationOptions.HasFlag(JsonSerializationOptions.SkipNullPropertyValues) && value == null;
        }

        /// <summary>
        /// Describes whether this instance should skip zero value types
        /// </summary>
        /// <param name="options">The options</param>
        /// <param name="member">The member</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal bool ShouldSkipZeroValueTypes(JsonOptions options, MemberDefinition member, object value)
        {
            return options.SerializationOptions.HasFlag(JsonSerializationOptions.SkipZeroValueTypes) && member.IsZeroValue(value);
        }

        /// <summary>
        /// Describes whether this instance should skip null date time values
        /// </summary>
        /// <param name="options">The options</param>
        /// <param name="member">The member</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal bool ShouldSkipNullDateTimeValues(JsonOptions options, MemberDefinition member, object value)
        {
            return options.SerializationOptions.HasFlag(JsonSerializationOptions.SkipNullDateTimeValues) && member.IsNullDateTimeValue(value);
        }

        /// <summary>
        /// Describes whether this instance should skip default values
        /// </summary>
        /// <param name="options">The options</param>
        /// <param name="member">The member</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        internal bool ShouldSkipDefaultValues(JsonOptions options, MemberDefinition member, object value)
        {
            return options.SerializationOptions.HasFlag(JsonSerializationOptions.SkipDefaultValues) && member.HasDefaultValue && member.EqualsDefaultValue(value);
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
        internal void WriteMemberValue(TextWriter writer, JsonOptions options, MemberDefinition member, bool nameChanged, string name, object value, IDictionary<object, object> objectGraph)
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
        ///     Enumerates the property definitions using reflection.
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="type">The type</param>
        /// <param name="options">The options</param>
        /// <returns>An enumerable of member definition</returns>
        internal static IEnumerable<MemberDefinition> EnumeratePropertyDefinitions(bool serialization, Type type, JsonOptions options)
        {
            return HandlePropertySerialization(serialization, type, options);
        }

        /// <summary>
        ///     Enumerates the field definitions using reflection if SerializeFields option is enabled.
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="type">The type</param>
        /// <param name="options">The options</param>
        /// <returns>An enumerable of member definition</returns>
        internal static IEnumerable<MemberDefinition> EnumerateFieldDefinitions(bool serialization, Type type, JsonOptions options)
        {
            if (options.SerializationOptions.HasFlag(JsonSerializationOptions.SerializeFields))
            {
                return HandleFieldSerialization(serialization, type, options);
            }
            return Enumerable.Empty<MemberDefinition>();
        }

        /// <summary>
        ///     Enumerates the definitions using reflection.
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="type">The type</param>
        /// <param name="options">The options</param>
        /// <returns>An enumerable of member definition</returns>
        internal static IEnumerable<MemberDefinition> EnumerateDefinitionsUsingReflection(bool serialization, Type type, JsonOptions options)
        {
            return EnumeratePropertyDefinitions(serialization, type, options)
                .Concat(EnumerateFieldDefinitions(serialization, type, options));
        }
                
        /// <summary>
        ///     Gets the properties from the specified type.
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>An enumerable of PropertyInfo</returns>
        internal static IEnumerable<PropertyInfo> GetPropertiesFromType(Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        /// <summary>
        ///     Creates member definitions from the specified properties.
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="properties">The properties</param>
        /// <param name="options">The options</param>
        /// <returns>An enumerable of member definition</returns>
        internal static IEnumerable<MemberDefinition> CreateMemberDefinitionsFromProperties(bool serialization, IEnumerable<PropertyInfo> properties, JsonOptions options)
        {
            foreach (PropertyInfo info in properties)
            {
                if (ShouldSkipProperty(serialization, info, options))
                {
                    continue;
                }
                
                yield return CreateMemberDefinition(serialization, info);
            }
        }

        /// <summary>
        ///     Handles the property serialization using the specified serialization
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="type">The type</param>
        /// <param name="options">The options</param>
        /// <returns>An enumerable of member definition</returns>
        internal static IEnumerable<MemberDefinition> HandlePropertySerialization(bool serialization, Type type, JsonOptions options)
        {
            if (type == null)
            {
                return Enumerable.Empty<MemberDefinition>();
            }
            
            IEnumerable<PropertyInfo> properties = GetPropertiesFromType(type);
            return CreateMemberDefinitionsFromProperties(serialization, properties, options);
        }
                
        /// <summary>
        ///     Describes whether should skip property
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="info">The info</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        internal static bool ShouldSkipProperty(bool serialization, PropertyInfo info, JsonOptions options)
        {
            return CheckJsonAttribute(serialization, info, options) ||
                   CheckXmlIgnoreAttribute(info, options) ||
                   CheckScriptIgnore(info, options) ||
                   CheckSerialization(serialization, info);
        }
        
        /// <summary>
        /// Describes whether check json attribute
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="info">The info</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        internal static bool CheckJsonAttribute(bool serialization, PropertyInfo info, JsonOptions options)
        {
            if (!IsUsingJsonAttribute(options))
            {
                return false;
            }
            
            JsonPropertyNameAttribute ja = JsonSerializer.GetJsonAttribute(info);
            return ja != null && ShouldIgnoreAttribute(serialization, ja);
        }
        
        /// <summary>
        /// Describes whether is using json attribute
        /// </summary>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        internal static bool IsUsingJsonAttribute(JsonOptions options)
        {
            return options.SerializationOptions.HasFlag(JsonSerializationOptions.UseJsonAttribute);
        }
        
        /// <summary>
        /// Describes whether should ignore attribute
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="attribute">The attribute</param>
        /// <returns>The bool</returns>
        internal static bool ShouldIgnoreAttribute(bool serialization, JsonPropertyNameAttribute attribute)
        {
            return (serialization && attribute.IgnoreWhenSerializing) || (!serialization && attribute.IgnoreWhenDeserializing);
        }
        
        /// <summary>
        ///     Describes whether check xml ignore attribute
        /// </summary>
        /// <param name="info">The info</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        internal static bool CheckXmlIgnoreAttribute(PropertyInfo info, JsonOptions options) => options.SerializationOptions.HasFlag(JsonSerializationOptions.UseXmlIgnore) && info.IsDefined(typeof(XmlIgnoreAttribute), true);
        
        /// <summary>
        ///     Describes whether check script ignore
        /// </summary>
        /// <param name="info">The info</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        internal static bool CheckScriptIgnore(PropertyInfo info, JsonOptions options)
        {
            if (options.SerializationOptions.HasFlag(JsonSerializationOptions.UseScriptIgnore))
            {
                if (JsonSerializer.HasScriptIgnore(info))
                {
                    return true;
                }
            }
            
            return false;
        }
        
        /// <summary>
        ///     Describes whether check serialization
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="info">The info</param>
        /// <returns>The bool</returns>
        internal static bool CheckSerialization(bool serialization, PropertyInfo info)
        {
            return serialization && (!info.CanRead || info.GetGetMethod() == null || info.GetGetMethod().GetParameters().Length > 0);
        }
        
        /// <summary>
        ///     Creates the member definition using the specified serialization
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="info">The info</param>
        /// <returns>The ma</returns>
        internal static MemberDefinition CreateMemberDefinition(bool serialization, PropertyInfo info)
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
        ///     Gets the fields from the specified type.
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>An enumerable of FieldInfo</returns>
        internal static IEnumerable<FieldInfo> GetFieldsFromType(Type type)
        {
            return type.GetFields(BindingFlags.Public | BindingFlags.Instance);
        }

        /// <summary>
        ///     Creates a member definition for the specified field.
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="field">The field</param>
        /// <param name="options">The options</param>
        /// <returns>A member definition</returns>
        internal static MemberDefinition CreateMemberDefinitionForField(bool serialization, FieldInfo field, JsonOptions options)
        {
            if (ShouldSkipField(serialization, field, options))
            {
                return null;
            }

            return CreateMemberDefinition(serialization, field);
        }

        /// <summary>
        ///     Checks if a member definition should be created for the specified field.
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="field">The field</param>
        /// <param name="options">The options</param>
        /// <returns>True if a member definition should be created, false otherwise</returns>
        internal static bool ShouldCreateMemberDefinitionForField(bool serialization, FieldInfo field, JsonOptions options)
        {
            MemberDefinition memberDefinition = CreateMemberDefinitionForField(serialization, field, options);
            return memberDefinition != null;
        }

        /// <summary>
        ///     Creates a member definition for the specified field if applicable.
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="field">The field</param>
        /// <param name="options">The options</param>
        /// <returns>A member definition if one should be created, null otherwise</returns>
        internal static MemberDefinition CreateMemberDefinitionIfApplicable(bool serialization, FieldInfo field, JsonOptions options)
        {
            if (ShouldCreateMemberDefinitionForField(serialization, field, options))
            {
                return CreateMemberDefinitionForField(serialization, field, options);
            }

            return null;
        }

        /// <summary>
        ///     Creates member definitions from the specified fields.
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="fields">The fields</param>
        /// <param name="options">The options</param>
        /// <returns>An enumerable of member definition</returns>
        internal static IEnumerable<MemberDefinition> CreateMemberDefinitions(bool serialization, IEnumerable<FieldInfo> fields, JsonOptions options)
        {
            foreach (FieldInfo field in fields)
            {
                MemberDefinition memberDefinition = CreateMemberDefinitionIfApplicable(serialization, field, options);
                if (memberDefinition != null)
                {
                    yield return memberDefinition;
                }
            }
        }

        /// <summary>
        ///     Handles the field serialization using the specified serialization
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="type">The type</param>
        /// <param name="options">The options</param>
        /// <returns>An enumerable of member definition</returns>
        internal static IEnumerable<MemberDefinition> HandleFieldSerialization(bool serialization, Type type, JsonOptions options)
        {
            if (type == null)
            {
                return Enumerable.Empty<MemberDefinition>();
            }

            IEnumerable<FieldInfo> fields = GetFieldsFromType(type);
            return CreateMemberDefinitions(serialization, fields, options);
        }
        
        /// <summary>
        ///     Determines whether to skip the field during serialization/deserialization.
        /// </summary>
        /// <param name="serialization">Indicates whether serialization is being performed.</param>
        /// <param name="info">The field information.</param>
        /// <param name="options">The JSON options.</param>
        /// <returns>True if the field should be skipped, false otherwise.</returns>
        internal static bool ShouldSkipField(bool serialization, FieldInfo info, JsonOptions options)
        {
            return ShouldSkipDueToJsonAttribute(serialization, info, options) ||
                   ShouldSkipDueToXmlIgnoreAttribute(info, options) ||
                   ShouldSkipDueToScriptIgnoreAttribute(info, options);
        }
        
      /// <summary>
///     Describes whether should skip due to json attribute
/// </summary>
/// <param name="serialization">The serialization</param>
/// <param name="info">The info</param>
/// <param name="options">The options</param>
/// <returns>The bool</returns>
internal static bool ShouldSkipDueToJsonAttribute(bool serialization, FieldInfo info, JsonOptions options)
{
    JsonPropertyNameAttribute jsonAttribute = JsonSerializer.GetJsonAttribute(info);
    return options.SerializationOptions.HasFlag(JsonSerializationOptions.UseJsonAttribute) &&
           jsonAttribute != null &&
           (serialization ? jsonAttribute.IgnoreWhenSerializing : jsonAttribute.IgnoreWhenDeserializing);
}
        
        /// <summary>
        ///     Describes whether should skip due to xml ignore attribute
        /// </summary>
        /// <param name="info">The info</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        internal static bool ShouldSkipDueToXmlIgnoreAttribute(FieldInfo info, JsonOptions options) => options.SerializationOptions.HasFlag(JsonSerializationOptions.UseXmlIgnore) &&
                                                                                                      info.IsDefined(typeof(XmlIgnoreAttribute), true);
        
        /// <summary>
        ///     Describes whether should skip due to script ignore attribute
        /// </summary>
        /// <param name="info">The info</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        internal static bool ShouldSkipDueToScriptIgnoreAttribute(FieldInfo info, JsonOptions options) => options.SerializationOptions.HasFlag(JsonSerializationOptions.UseScriptIgnore) &&
                                                                                                         JsonSerializer.HasScriptIgnore(info);
        
        /// <summary>
        ///     Creates the member definition using the specified serialization
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="info">The info</param>
        /// <returns>The ma</returns>
        internal static MemberDefinition CreateMemberDefinition(bool serialization, FieldInfo info)
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
        ///     Gets the properties from the specified type using TypeDescriptor.
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>An enumerable of PropertyDescriptor</returns>
        internal static IEnumerable<PropertyDescriptor> GetPropertiesFromTypeDescriptor(Type type)
        {
            return TypeDescriptor.GetProperties(type).Cast<PropertyDescriptor>();
        }

        /// <summary>
        ///     Creates member definitions from the specified property descriptors.
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="descriptors">The property descriptors</param>
        /// <param name="options">The options</param>
        /// <returns>An enumerable of member definition</returns>
        internal static IEnumerable<MemberDefinition> CreateMemberDefinitionsFromDescriptors(bool serialization, IEnumerable<PropertyDescriptor> descriptors, JsonOptions options)
        {
            foreach (PropertyDescriptor descriptor in descriptors)
            {
                if (ShouldSkipDescriptor(serialization, descriptor, options))
                {
                    continue;
                }

                yield return CreateMemberDefinition(serialization, descriptor);
            }
        }

        /// <summary>
        ///     Enumerates the definitions using type descriptors using the specified serialization
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="type">The type</param>
        /// <param name="options">The options</param>
        /// <returns>An enumerable of member definition</returns>
        internal static IEnumerable<MemberDefinition> EnumerateDefinitionsUsingTypeDescriptors(bool serialization, Type type, JsonOptions options)
        {
            var descriptors = GetPropertiesFromTypeDescriptor(type);
            return CreateMemberDefinitionsFromDescriptors(serialization, descriptors, options);
        }
        
        /// <summary>
        ///     Describes whether should skip descriptor
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="descriptor">The descriptor</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        internal static bool ShouldSkipDescriptor(bool serialization, PropertyDescriptor descriptor, JsonOptions options)
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
        ///     Describes whether check json attribute
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="descriptor">The descriptor</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        internal static bool CheckJsonAttribute(bool serialization, PropertyDescriptor descriptor, JsonOptions options)
        {
            JsonPropertyNameAttribute ja = descriptor.GetAttribute<JsonPropertyNameAttribute>();
            return options.SerializationOptions.HasFlag(JsonSerializationOptions.UseJsonAttribute) &&
                   ja != null &&
                   (serialization ? ja.IgnoreWhenSerializing : ja.IgnoreWhenDeserializing);
        }
        
        /// <summary>
        ///     Describes whether check xml ignore attribute
        /// </summary>
        /// <param name="descriptor">The descriptor</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        internal static bool CheckXmlIgnoreAttribute(PropertyDescriptor descriptor, JsonOptions options)
        {
            if (options.SerializationOptions.HasFlag(JsonSerializationOptions.UseXmlIgnore))
            {
                if (descriptor.GetAttribute<XmlIgnoreAttribute>() != null)
                {
                    return true;
                }
            }
            
            return false;
        }
        
        /// <summary>
        ///     Describes whether check script ignore
        /// </summary>
        /// <param name="descriptor">The descriptor</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        internal static bool CheckScriptIgnore(PropertyDescriptor descriptor, JsonOptions options) => options.SerializationOptions.HasFlag(JsonSerializationOptions.UseScriptIgnore) && JsonSerializer.HasScriptIgnore(descriptor);
        
        /// <summary>
        ///     Describes whether check skip get only
        /// </summary>
        /// <param name="descriptor">The descriptor</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        internal static bool CheckSkipGetOnly(PropertyDescriptor descriptor, JsonOptions options) => options.SerializationOptions.HasFlag(JsonSerializationOptions.SkipGetOnly) && descriptor.IsReadOnly;
        
        /// <summary>
        ///     Creates the member definition using the specified serialization
        /// </summary>
        /// <param name="serialization">The serialization</param>
        /// <param name="descriptor">The descriptor</param>
        /// <returns>The ma</returns>
        internal static MemberDefinition CreateMemberDefinition(bool serialization, PropertyDescriptor descriptor)
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