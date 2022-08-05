// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ControlConverter.cs
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
using System.Globalization;

namespace Alis.Core.Input.Converters
{
    /// <summary>
    ///     Class ControlConverter.
    ///     Implements the <see cref="TypeConverter" />
    ///     Used to conveniently create control converters.
    /// </summary>
    /// <typeparam name="T">The type of control property.</typeparam>
    /// <seealso cref="TypeConverter" />
    public abstract class ControlConverter<T> : TypeConverter
    {
        /// <inheritdoc />
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(double) || base.CanConvertFrom(context, sourceType);
        }

        /// <inheritdoc />
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return value is double dv
                ? Convert(culture, dv)
                : base.ConvertFrom(context, culture, value);
        }

        /// <summary>
        ///     Converts the value to the specified type
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="value">The value.</param>
        /// <returns>The value.</returns>
        public virtual T Convert(CultureInfo culture, double value)
        {
            return base.ConvertFrom(null, culture, value) is T v ? v : default;
        }
    }
}