// Licensed under the Apache License, Version 2.0 (the "License").
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using Alis.Core.Input.Controllers;
using DevDecoder.HIDDevices;

namespace Alis.Core.Input.Attributes
{
    /// <summary>
    ///     Class ControlAttribute. This class cannot be inherited.
    ///     Attribute that should be added to properties on a <seealso cref="Controller" /> to indicate
    ///     that they should be bound to a <seealso cref="Control" />.
    /// </summary>
    /// <seealso cref="Controller" />
    /// <seealso cref="Control" />
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public sealed class ControlAttribute : Attribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ControlAttribute" /> class.
        /// </summary>
        /// <param name="usages">The usages.</param>
        public ControlAttribute(params object[] usages)
        {
            Usages = usages.OfType<Enum>().Select(Usage.Get).ToArray();
        }

        /// <summary>
        ///     Gets or sets the weight, a higher weight will increase the scoring of controls matching this attribute,
        ///     increasing their preference when selection when attaching to the associated property.
        /// </summary>
        /// <value>The weight.</value>
        public byte Weight { get; set; } = 1;

        /// <summary>
        ///     Gets a list of valid usages, of which the device must match all.
        /// </summary>
        /// <remarks>
        ///     If alternative usages are to be supported, then multiple attributes can be added.  When combined
        ///     with the <see cref="Weight" /> of each attribute, it allows for fine control of <seealso cref="Control" />
        ///     matching.
        /// </remarks>
        public IReadOnlyList<Usage> Usages { get; }

        /// <summary>
        ///     Describes whether this instance matches
        /// </summary>
        /// <param name="control">The control</param>
        /// <returns>The bool</returns>
        internal bool Matches(Control control)
        {
            return Usages.All(usage => control.Usages.Contains(usage));
        }
    }
}