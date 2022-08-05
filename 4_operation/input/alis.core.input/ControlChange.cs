// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ControlChange.cs
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
using System.Diagnostics;
using System.Threading;
using DevDecoder.HIDDevices;
using HidSharp.Reports;

namespace Alis.Core.Input
{
    /// <summary>
    ///     Struct ControlChange
    ///     Implements the <see cref="IEquatable{T}" /> interface.
    ///     Used to record a change in a <see cref="Control">Control's</see> value.
    /// </summary>
    /// <seealso cref="Control" />
    /// <seealso cref="IEquatable{T}" />
    public readonly struct ControlChange : IEquatable<ControlChange>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ControlChange" /> class
        /// </summary>
        /// <param name="control">The control</param>
        /// <param name="value">The value</param>
        internal ControlChange(Control control, (DataValue value, long timestamp) value) : this()
        {
            Control = control;
            PreviousValue = double.NaN;
            Value = Control.Normalise(value.value.GetLogicalValue());
            Timestamp = value.timestamp;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ControlChange" /> class
        /// </summary>
        /// <param name="control">The control</param>
        /// <param name="previousValue">The previous value</param>
        /// <param name="value">The value</param>
        /// <param name="timestamp">The timestamp</param>
        private ControlChange(Control control, double previousValue, double value, long timestamp) : this()
        {
            Control = control;
            PreviousValue = previousValue;
            Value = value;
            Timestamp = timestamp;
        }

        /// <summary>
        ///     Gets the control.
        /// </summary>
        /// <value>The control.</value>
        public Control Control { get; }

        /// <summary>
        ///     Gets the previous value.
        /// </summary>
        /// <value>The previous value.</value>
        public double PreviousValue { get; }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public double Value { get; }

        /// <summary>
        ///     Gets the timestamp.
        /// </summary>
        /// <value>The timestamp.</value>
        public long Timestamp { get; }

        /// <summary>
        ///     Gets the elapsed time since the change occurred.
        /// </summary>
        /// <value>The elapsed time.</value>
        public TimeSpan Elapsed => Timestamp < 0
            ? Timeout.InfiniteTimeSpan
            : TimeSpan.FromSeconds(
                (double)(Stopwatch.GetTimestamp() - Timestamp) / Stopwatch.Frequency);

        /// <summary>
        ///     Updates the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The control change</returns>
        internal ControlChange? Update((DataValue value, long timestamp) value)
        {
            var normalisedValue = Control.Normalise(value.value.GetLogicalValue());
            return normalisedValue.Equals(Value)
                ? (ControlChange?)null
                : new ControlChange(Control, Value, normalisedValue, value.timestamp);
        }

        /// <inheritdoc />
        public bool Equals(ControlChange other)
        {
            return ReferenceEquals(Control, other.Control) &&
                   PreviousValue.Equals(other.PreviousValue) &&
                   Value.Equals(other.Value);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is ControlChange other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return HashCode.Combine(Control, PreviousValue, Value);
        }

        /// <summary>
        ///     Implements the == operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(ControlChange left, ControlChange right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///     Implements the != operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(ControlChange left, ControlChange right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        ///     Performs an implicit conversion from <see cref="ControlChange" /> to <see cref="System.Double" />.
        /// </summary>
        /// <param name="change">The change.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator double(ControlChange change)
        {
            return change.Value;
        }

        /// <summary>
        ///     Creates a change that simulates the current value having changed from <seealso cref="double.NaN" />.
        /// </summary>
        /// <returns></returns>
        internal ControlChange Reset()
        {
            return new ControlChange(Control, double.NaN, Value, Timestamp);
        }
    }
}