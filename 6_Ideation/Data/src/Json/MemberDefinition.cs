// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MemberDefinition.cs
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

namespace Alis.Core.Aspect.Data.Json
{
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

                targetValue = JsonSerializer.CreateInstance(target, Type, elementsCount, options, targetValue);
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
                Dictionary<object, object> og = new Dictionary<object, object>
                {
                    ["dictionary"] = dictionary,
                    ["member"] = this
                };

                JsonEventArgs e = new JsonEventArgs(null, value, og, options, key, target)
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
                object targetValue = GetOrCreateInstance(target, dic.Count, options);
                JsonSerializer.Apply(dic, targetValue, options);
                return;
            }

            ListObject lo = JsonSerializer.GetListObject(Type, options, target, value, dictionary, key);
            if (lo != null)
            {
                if (value is IEnumerable enumerable)
                {
                    lo.List = GetOrCreateInstance(target, enumerable is ICollection coll ? coll.Count : 0, options);
                    JsonSerializer.ApplyToListTarget(target, enumerable, lo, options);
                    return;
                }
            }


            object cvalue = JsonSerializer.ChangeType(target, value, Type, options);
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

            Type type = value.GetType();
            if (type != Type)
                return false;

            return JsonSerializer.IsZeroValueType(value);
        }

        /// <summary>
        ///     Determines if a value equals the default value.
        /// </summary>
        /// <param name="value">The value to compare.</param>
        /// <returns>true if both values are equal; false otherwise.</returns>
        public virtual bool EqualsDefaultValue(object value) => JsonSerializer.AreValuesEqual(DefaultValue, value);

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
}