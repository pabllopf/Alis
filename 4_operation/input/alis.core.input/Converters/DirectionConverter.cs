// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   DirectionConverter.cs
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
using System.Globalization;

namespace Alis.Core.Input.Converters
{
    /// <summary>
    ///     Class DirectionConverter converts control values to a <see cref="Direction" />. This class cannot be inherited.
    ///     Implements the <see cref="ControlConverter{T}" />.
    /// </summary>
    /// <seealso cref="ControlConverter{T}" />
    /// <seealso cref="Direction" />
    public sealed class DirectionConverter : ControlConverter<Direction>
    {
        /// <summary>
        ///     The singleton instance of the converter.
        /// </summary>
        public static readonly DirectionConverter Instance = new DirectionConverter();

        /// <summary>
        ///     Initializes a new instance of the <see cref="DirectionConverter" /> class
        /// </summary>
        private DirectionConverter()
        {
        }

        /// <summary>
        ///     Converts the culture
        /// </summary>
        /// <param name="culture">The culture</param>
        /// <param name="value">The value</param>
        /// <returns>The direction</returns>
        public override Direction Convert(CultureInfo culture, double value)
        {
            return double.IsNaN(value)
                ? Direction.NotPressed
                : (Direction)Math.Clamp((int)Math.Round(value * 7.0), 0, 7);
        }
    }
}