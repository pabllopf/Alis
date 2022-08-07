// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ControlValue.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics;
using DevDecoder.HIDDevices;

namespace Alis.Core.Input.Controllers
{
    /// <summary>
    ///     Struct ControlValue holds the latest value of a <see cref="Input.Control" /> for a
    ///     <seealso cref="Controller" />.
    /// </summary>
    /// <seealso cref="Controller" />
    /// <seealso cref="Input.Control" />
    /// <seealso cref="ControlChange" />
    /// <seealso cref="IEquatable{T}" />
    public readonly struct ControlValue : IEquatable<ControlValue>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ControlValue" /> class
        /// </summary>
        /// <param name="change">The change</param>
        /// <param name="info">The info</param>
        /// <param name="value">The value</param>
        internal ControlValue(ControlChange change, ControlInfo info, object value)
        {
            Debug.Assert(ReferenceEquals(change.Control, info.Control));
            Change = change;
            Info = info;
            Value = value;
        }

        /// <summary>
        ///     Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public Type Type => Info.Type;

        /// <summary>
        ///     Gets the name of the property.
        /// </summary>
        /// <value>The name of the property.</value>
        public string PropertyName => Info.PropertyName;

        /// <summary>
        ///     Gets the control.
        /// </summary>
        /// <value>The control.</value>
        public Control Control => Info.Control;

        /// <summary>
        ///     Gets the timestamp.
        /// </summary>
        /// <value>The timestamp.</value>
        public long Timestamp => Change.Timestamp;

        /// <summary>
        ///     Gets the elapsed.
        /// </summary>
        /// <value>The elapsed.</value>
        public TimeSpan Elapsed => Change.Elapsed;

        /// <summary>
        ///     Gets the converter.
        /// </summary>
        /// <value>The converter.</value>
        public TypeConverter Converter => Info.Converter;

        /// <summary>
        ///     Gets the change.
        /// </summary>
        /// <value>The change.</value>
        public ControlChange Change { get; }

        /// <summary>
        ///     Gets the control information.
        /// </summary>
        /// <value>The control information.</value>
        public ControlInfo Info { get; }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public object Value { get; }

        /// <inheritdoc />
        public bool Equals(ControlValue other)
        {
            return Change.Equals(other.Change) && Info.Equals(other.Info) && Equals(Value, other.Value);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is ControlValue other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return HashCode.Combine(Change, Info, Value);
        }

        /// <summary>
        ///     Implements the == operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(ControlValue left, ControlValue right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///     Implements the != operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(ControlValue left, ControlValue right)
        {
            return !left.Equals(right);
        }
    }
}