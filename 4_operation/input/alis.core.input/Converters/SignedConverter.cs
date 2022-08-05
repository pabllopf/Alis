// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   SignedConverter.cs
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

namespace Alis.Core.Input.Converters
{
    /// <summary>
    ///     Class SignedConverter converts control values to a property value between -1 and 1, centred on 0. This class cannot
    ///     be inherited.
    ///     Implements the <see cref="ControlConverter{T}" />.
    /// </summary>
    /// <seealso cref="ControlConverter{T}" />
    /// <seealso cref="RangeConverter" />
    public sealed class SignedConverter : RangeConverter
    {
        /// <summary>
        ///     The singleton instance of the converter.
        /// </summary>
        public static readonly SignedConverter Instance = new SignedConverter();

        /// <summary>
        ///     Initializes a new instance of the <see cref="SignedConverter" /> class
        /// </summary>
        private SignedConverter() : base(-1D, 1D)
        {
        }
    }
}