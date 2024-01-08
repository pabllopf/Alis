// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: JsonEventArgs.cs
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
using System.IO;

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     Provides data for a JSON event.
    /// </summary>
    public class JsonEventArgs : EventArgs
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonEventArgs" /> class.
        /// </summary>
        /// <param name="writer">The writer currently in use.</param>
        /// <param name="value">The value on the stack.</param>
        /// <param name="objectGraph">The current serialization object graph.</param>
        /// <param name="options">The options currently in use.</param>
        public JsonEventArgs(TextWriter writer, object value, IDictionary<object, object> objectGraph, JsonOptions options)
            : this(writer, value, objectGraph, options, null, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonEventArgs" /> class.
        /// </summary>
        /// <param name="writer">The writer currently in use.</param>
        /// <param name="value">The value on the stack.</param>
        /// <param name="objectGraph">The current serialization object graph.</param>
        /// <param name="options">The options currently in use.</param>
        /// <param name="name">The field or property name.</param>
        /// <param name="component">The component holding the value.</param>
        public JsonEventArgs(TextWriter writer, object value, IDictionary<object, object> objectGraph, JsonOptions options, string name, object component)
        {
            Options = options;
            Writer = writer;
            ObjectGraph = objectGraph;
            Value = value;
            Name = name;
            Component = component;
        }

        /// <summary>
        ///     Gets the options currently in use.
        /// </summary>
        /// <value>The options.</value>
        public JsonOptions Options { get; }

        /// <summary>
        ///     Gets the writer currently in use.
        /// </summary>
        /// <value>The writer.</value>
        public TextWriter Writer { get; }

        /// <summary>
        ///     Gets the current serialization object graph.
        /// </summary>
        /// <value>The object graph.</value>
        public IDictionary<object, object> ObjectGraph { get; }

        /// <summary>
        ///     Gets the component holding the value. May be null.
        /// </summary>
        /// <value>The component.</value>
        public virtual object Component { get; }

        /// <summary>
        ///     Gets or sets the type of the event.
        /// </summary>
        /// <value>
        ///     The type of the event.
        /// </value>
        public virtual JsonEventType EventType { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="JsonEventArgs" /> is handled.
        ///     An handled object can be skipped, not written to the stream. If the object is written, First must be set to false,
        ///     otherwise it must not be changed.
        /// </summary>
        /// <value><c>true</c> if handled; otherwise, <c>false</c>.</value>
        public virtual bool Handled { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the object being handled is first in the list.
        ///     If the object is handled and written to the stream, this must be set to false after the stream is written.
        ///     If the object is skipped, it must not be changed.
        /// </summary>
        /// <value><c>true</c> if this is the first object; otherwise, <c>false</c>.</value>
        public virtual bool First { get; set; }

        /// <summary>
        ///     Gets or sets the value on the stack.
        /// </summary>
        /// <value>The value.</value>
        public virtual object Value { get; set; }

        /// <summary>
        ///     Gets or sets the name on the stack. The Name can be a property or field name when serializing objects. May be null.
        /// </summary>
        /// <value>The value.</value>
        public virtual string Name { get; set; }
    }
}