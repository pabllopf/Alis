// Licensed under the Apache License, Version 2.0 (the "License").
// See the LICENSE file in the project root for more information.

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
        /// Initializes a new instance of the <see cref="BooleanConverter"/> class
        /// </summary>
        private BooleanConverter()
        {
        }

        /// <inheritdoc />
        public override bool Convert(CultureInfo culture, double value) => !double.IsNaN(value) && value > 0.5D;
    }
}
