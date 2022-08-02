// Licensed under the Apache License, Version 2.0 (the "License").
// See the LICENSE file in the project root for more information.

namespace Alis.Core.Input.Converters
{
    /// <summary>
    ///     Class LeftTriggerConverter converts control values for trigger properties. This class cannot be inherited.
    ///     Implements the <see cref="ControlConverter{T}" />.
    /// </summary>
    /// <seealso cref="ControlConverter{T}" />
    /// <seealso cref="RangeConverter" />
    public sealed class LeftTriggerConverter : RangeConverter
    {
        /// <summary>
        ///     The singleton instance of the converter.
        /// </summary>
        public static readonly LeftTriggerConverter Instance = new LeftTriggerConverter();

        /// <summary>
        /// Initializes a new instance of the <see cref="LeftTriggerConverter"/> class
        /// </summary>
        private LeftTriggerConverter() : base(0D, 1D, 0.5D)
        {
        }
    }
}
