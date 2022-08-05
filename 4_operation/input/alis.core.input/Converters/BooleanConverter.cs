// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   BooleanConverter.cs
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

using System.Globalization;

namespace Alis.Core.Input.Converters
{
    /// <summary>
    ///     Class BooleanConverter converts control values to a boolean. This class cannot be inherited.
    ///     Implements <see cref="ControlConverter{T}" />.
    /// </summary>
    public sealed class BooleanConverter : ControlConverter<bool>
    {
        /// <summary>
        ///     The singleton instance of the converter.
        /// </summary>
        public static readonly BooleanConverter Instance = new BooleanConverter();

        /// <summary>
        ///     Initializes a new instance of the <see cref="BooleanConverter" /> class
        /// </summary>
        private BooleanConverter()
        {
        }

        /// <inheritdoc />
        public override bool Convert(CultureInfo culture, double value)
        {
            return !double.IsNaN(value) && value > 0.5D;
        }
    }
}