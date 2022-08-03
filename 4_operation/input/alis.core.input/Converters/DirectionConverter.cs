// Licensed under the Apache License, Version 2.0 (the "License").
// See the LICENSE file in the project root for more information.

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