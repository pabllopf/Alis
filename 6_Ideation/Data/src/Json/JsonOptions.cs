// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: JsonOptions.cs
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
using System.Collections.Generic;
using System.Globalization;

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     Define options for JSON.
    /// </summary>
    public class JsonOptions
    {
        /// <summary>
        ///     The allow white spaces
        /// </summary>
        internal static DateTimeStyles _defaultDateTimeStyles = DateTimeStyles.AssumeUniversal | DateTimeStyles.AllowInnerWhite | DateTimeStyles.AllowLeadingWhite | DateTimeStyles.AllowTrailingWhite | DateTimeStyles.AllowWhiteSpaces;

        /// <summary>
        ///     The exception
        /// </summary>
        private readonly List<Exception> _exceptions = new List<Exception>();

        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonOptions" /> class.
        /// </summary>
        public JsonOptions()
        {
            SerializationOptions = JsonSerializationOptions.Default;
            ThrowExceptions = true;
            DateTimeStyles = _defaultDateTimeStyles;
            FormattingTab = " ";
            StreamingBufferChunkSize = ushort.MaxValue;
            MaximumExceptionsCount = 100;
        }

        /// <summary>
        ///     Gets a value indicating the current serialization level.
        /// </summary>
        /// <value>
        ///     The current serialization level.
        /// </value>
        public int SerializationLevel { get; internal set; }

        /// <summary>
        ///     Gets or sets a value indicating whether exceptions can be thrown during serialization or deserialization.
        ///     If this is set to false, exceptions will be stored in the Exceptions collection.
        ///     However, if the number of exceptions is equal to or higher than MaximumExceptionsCount, an exception will be
        ///     thrown.
        /// </summary>
        /// <value>
        ///     <c>true</c> if exceptions can be thrown on serialization or deserialization; otherwise, <c>false</c>.
        /// </value>
        public virtual bool ThrowExceptions { get; set; }

        /// <summary>
        ///     Gets or sets the maximum exceptions count.
        /// </summary>
        /// <value>
        ///     The maximum exceptions count.
        /// </value>
        public virtual int MaximumExceptionsCount { get; set; }

        /// <summary>
        ///     Gets or sets the JSONP callback. It will be added as wrapper around the result.
        ///     Check this article for more: http://en.wikipedia.org/wiki/JSONP
        /// </summary>
        /// <value>
        ///     The JSONP callback name.
        /// </value>
        public virtual string JsonPCallback { get; set; }

        /// <summary>
        ///     Gets or sets the guid format.
        /// </summary>
        /// <value>
        ///     The guid format.
        /// </value>
        public virtual string GuidFormat { get; set; }

        /// <summary>
        ///     Gets or sets the date time format.
        /// </summary>
        /// <value>
        ///     The date time format.
        /// </value>
        public virtual string DateTimeFormat { get; set; }

        /// <summary>
        ///     Gets or sets the date time offset format.
        /// </summary>
        /// <value>
        ///     The date time offset format.
        /// </value>
        public virtual string DateTimeOffsetFormat { get; set; }

        /// <summary>
        ///     Gets or sets the date time styles.
        /// </summary>
        /// <value>
        ///     The date time styles.
        /// </value>
        public virtual DateTimeStyles DateTimeStyles { get; set; }

        /// <summary>
        ///     Gets or sets the size of the streaming buffer chunk. Minimum value is 512.
        /// </summary>
        /// <value>
        ///     The size of the streaming buffer chunk.
        /// </value>
        public virtual int StreamingBufferChunkSize { get; set; }

        /// <summary>
        ///     Gets or sets the formatting tab string.
        /// </summary>
        /// <value>
        ///     The formatting tab.
        /// </value>
        public virtual string FormattingTab { get; set; }

        /// <summary>
        ///     Gets the deseralization exceptions. Will be empty if ThrowExceptions is set to false.
        /// </summary>
        /// <value>
        ///     The list of deseralization exceptions.
        /// </value>
#pragma warning disable CA1819 // Properties should not return arrays
        public virtual Exception[] Exceptions => _exceptions.ToArray();
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        ///     Gets or sets the serialization options.
        /// </summary>
        /// <value>The serialization options.</value>
        public virtual JsonSerializationOptions SerializationOptions { get; set; }

        /// <summary>
        ///     Gets or sets a write value callback.
        /// </summary>
        /// <value>The callback.</value>
        public virtual JsonCallback WriteValueCallback { get; set; }

        /// <summary>
        ///     Gets or sets a callback that is called before an object (not a value) is serialized.
        /// </summary>
        /// <value>The callback.</value>
        public virtual JsonCallback BeforeWriteObjectCallback { get; set; }

        /// <summary>
        ///     Gets or sets a callback that is called before an object (not a value) is serialized.
        /// </summary>
        /// <value>The callback.</value>
        public virtual JsonCallback AfterWriteObjectCallback { get; set; }

        /// <summary>
        ///     Gets or sets a callback that is called before an object field or property is serialized.
        /// </summary>
        /// <value>The callback.</value>
        public virtual JsonCallback WriteNamedValueObjectCallback { get; set; }

        /// <summary>
        ///     Gets or sets a callback that is called before an instance of an object is created.
        /// </summary>
        /// <value>The callback.</value>
        public virtual JsonCallback CreateInstanceCallback { get; set; }

        /// <summary>
        ///     Gets or sets a callback that is called during deserialization, before a dictionary entry is mapped to a target
        ///     object.
        /// </summary>
        /// <value>The callback.</value>
        public virtual JsonCallback MapEntryCallback { get; set; }

        /// <summary>
        ///     Gets or sets a callback that is called during deserialization, before a dictionary entry is applied to a target
        ///     object.
        /// </summary>
        /// <value>The callback.</value>
        public virtual JsonCallback ApplyEntryCallback { get; set; }

        /// <summary>
        ///     Gets or sets a callback that is called during deserialization, to deserialize a list object.
        /// </summary>
        /// <value>The callback.</value>
        public virtual JsonCallback GetListObjectCallback { get; set; }

        /// <summary>
        ///     Gets or sets a utility class that will store an object graph to avoid serialization cycles.
        ///     If null, a Dictionary&lt;object, object&gt; using an object reference comparer will be used.
        /// </summary>
        /// <value>The object graph instance.</value>
        public virtual IDictionary<object, object> ObjectGraph { get; set; }

        /// <summary>
        ///     Gets the value of the final streaming buffer chunk size
        /// </summary>
        internal int FinalStreamingBufferChunkSize => Max(512, StreamingBufferChunkSize);

        /// <summary>
        /// Maxes the val 1
        /// </summary>
        /// <param name="val1">The val</param>
        /// <param name="val2">The val</param>
        /// <returns>The int</returns>
        public int Max(int val1, int val2)
        {
            return (val1 >= val2) ? val1 : val2;
        }

        /// <summary>
        ///     Gets the value of the final object graph
        /// </summary>
        internal IDictionary<object, object> FinalObjectGraph => ObjectGraph ?? new Dictionary<object, object>(JsonSerializer.ReferenceComparer.Instance);

        /// <summary>
        ///     Finalizes the serialization members from an initial setup of members.
        /// </summary>
        /// <param name="type">The input type. May not be null.</param>
        /// <param name="members">The members. May not be null.</param>
        /// <returns>A non-null list of members.</returns>
        public virtual IEnumerable<JsonSerializer.MemberDefinition> FinalizeSerializationMembers(Type type, IEnumerable<JsonSerializer.MemberDefinition> members) => members;

        /// <summary>
        ///     Finalizes the deserialization members from an initial setup of members.
        /// </summary>
        /// <param name="type">The input type. May not be null.</param>
        /// <param name="members">The members. May not be null.</param>
        /// <returns>A non-null list of members.</returns>
        public virtual IEnumerable<JsonSerializer.MemberDefinition> FinalizeDeserializationMembers(Type type, IEnumerable<JsonSerializer.MemberDefinition> members) => members;

        /// <summary>
        ///     Adds an exception to the list of exceptions.
        /// </summary>
        /// <param name="error">The exception to add.</param>
        public virtual void AddException(Exception error)
        {
            if (error == null)
                throw new ArgumentNullException(nameof(error));

            if (_exceptions.Count >= MaximumExceptionsCount)
                throw new JsonException("JSO0015: Two many JSON errors detected (" + _exceptions.Count + ").", error);

            _exceptions.Add(error);
        }

        /// <summary>
        ///     Clones this instance.
        /// </summary>
        /// <returns>A newly created insance of this class with all values copied.</returns>
        public virtual JsonOptions Clone()
        {
            var clone = new JsonOptions
            {
                AfterWriteObjectCallback = AfterWriteObjectCallback,
                ApplyEntryCallback = ApplyEntryCallback,
                BeforeWriteObjectCallback = BeforeWriteObjectCallback,
                CreateInstanceCallback = CreateInstanceCallback,
                DateTimeFormat = DateTimeFormat,
                DateTimeOffsetFormat = DateTimeOffsetFormat,
                DateTimeStyles = DateTimeStyles
            };
            clone._exceptions.AddRange(_exceptions);
            clone.FormattingTab = FormattingTab;
            clone.GetListObjectCallback = GetListObjectCallback;
            clone.GuidFormat = GuidFormat;
            clone.MapEntryCallback = MapEntryCallback;
            clone.MaximumExceptionsCount = MaximumExceptionsCount;
            clone.SerializationOptions = SerializationOptions;
            clone.StreamingBufferChunkSize = StreamingBufferChunkSize;
            clone.ThrowExceptions = ThrowExceptions;
            clone.WriteNamedValueObjectCallback = WriteNamedValueObjectCallback;
            clone.WriteValueCallback = WriteValueCallback;
            return clone;
        }

        /// <summary>
        ///     Gets a key that can be used for type cache.
        /// </summary>
        /// <returns>A cache key.</returns>
        public virtual string GetCacheKey() => ((int) SerializationOptions).ToString();
    }
}