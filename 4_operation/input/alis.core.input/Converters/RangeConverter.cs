// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RangeConverter.cs
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
using System.Globalization;

namespace Alis.Core.Input.Converters
{
    /// <summary>
    ///     Class RangeConverter converts control values to a range. This class cannot be inherited.
    ///     Implements the <see cref="ControlConverter{T}" />.
    /// </summary>
    /// <seealso cref="ControlConverter{T}" />
    public class RangeConverter : ControlConverter<double>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RangeConverter" /> class.
        /// </summary>
        /// <param name="outputMinimum">The minimum.</param>
        /// <param name="outputMaximum">The maximum.</param>
        /// <param name="inputMinimum">The input minimum.</param>
        /// <param name="inputMaximum">The input maximum.</param>
        /// <exception cref="ArgumentOutOfRangeException">outputMaximum</exception>
        public RangeConverter(
            double outputMinimum,
            double outputMaximum,
            double inputMinimum = 0D,
            double inputMaximum = 1D)
        {
            if (inputMaximum < 0D)
            {
                inputMinimum = 0D;
            }
            else if (inputMinimum > 1D)
            {
                inputMinimum = 1D;
            }

            if (inputMaximum < 0D)
            {
                inputMaximum = 0D;
            }
            else if (inputMaximum > 1D)
            {
                inputMaximum = 1D;
            }

            if (inputMaximum < inputMinimum)
            {
                // Flip both input and output ranges so input range always has min<max.
                double swap = inputMinimum;
                inputMinimum = inputMaximum;
                inputMaximum = swap;

                swap = outputMinimum;
                outputMinimum = outputMaximum;
                outputMaximum = swap;
            }

            InputMinimum = inputMinimum;
            InputMaximum = inputMaximum;
            InputRange = inputMaximum - inputMinimum;

            OutputMinimum = outputMinimum;
            OutputMaximum = outputMaximum;
            OutputRange = outputMaximum - outputMinimum;
        }

        /// <summary>
        ///     Gets the input minimum.
        /// </summary>
        /// <value>The input minimum.</value>
        public double InputMinimum { get; }

        /// <summary>
        ///     Gets the input maximum.
        /// </summary>
        /// <value>The input maximum.</value>
        public double InputMaximum { get; }

        /// <summary>
        ///     Gets the input range.
        /// </summary>
        /// <value>The input range.</value>
        public double InputRange { get; }

        /// <summary>
        ///     Gets the output minimum.
        /// </summary>
        /// <value>The output minimum.</value>
        public double OutputMinimum { get; }

        /// <summary>
        ///     Gets the output maximum.
        /// </summary>
        /// <value>The output maximum.</value>
        public double OutputMaximum { get; }

        /// <summary>
        ///     Gets the output range.
        /// </summary>
        /// <value>The output range.</value>
        public double OutputRange { get; }

        /// <inheritdoc />
        public override double Convert(CultureInfo culture, double value)
        {
            if (double.IsNaN(value))
            {
                return double.NaN;
            }

            if (value <= InputMinimum)
            {
                return OutputMinimum;
            }

            if (value >= InputMaximum)
            {
                return OutputMaximum;
            }

            return OutputMinimum + (value - InputMinimum) / InputRange * OutputRange;
        }
    }
}