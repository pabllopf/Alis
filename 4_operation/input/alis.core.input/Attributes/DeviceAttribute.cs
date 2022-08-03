// Licensed under the Apache License, Version 2.0 (the "License").
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Alis.Core.Input.Controllers;

namespace Alis.Core.Input.Attributes
{
    /// <summary>
    ///     Class DeviceAttribute. This class cannot be inherited.
    ///     Attribute that can optionally be added to a <seealso cref="Controller" /> descendent to limit the
    ///     <seealso cref="Device">Devices</seealso>
    ///     that can be matched by the controller.
    /// </summary>
    /// <seealso cref="Controller" />
    /// <seealso cref="Device" />
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class DeviceAttribute : Attribute
    {
        /// <summary>
        ///     The release number regex
        /// </summary>
        private Regex _releaseNumberRegex;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DeviceAttribute" /> class.
        /// </summary>
        /// <param name="usages">The usages, all of which must match.</param>
        public DeviceAttribute(params object[] usages)
        {
            Usages = usages.OfType<Enum>().Select(Usage.Get).ToArray();
        }

        /// <summary>
        ///     Gets a list of valid usages, of which the device must match all.
        /// </summary>
        /// <remarks>If alternative usages are to be supported, then multiple attributes can be added.</remarks>
        public IReadOnlyList<Usage> Usages { get; }

        /// <summary>
        ///     Gets or sets an optional Product ID; 0 if any ID is valid.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        ///     Gets or sets an optional <see cref="Regex" /> to match a <see cref="Version" />; otherwise <see langword="null" />.
        /// </summary>
        public string ReleaseNumberRegex { get; set; }

        /// <summary>
        ///     Describes whether this instance matches
        /// </summary>
        /// <param name="device">The device</param>
        /// <returns>The bool</returns>
        internal bool Matches(Device device)
        {
            if ((ProductId > 0 && device.ProductId != ProductId) ||
                !Usages.All(usage => device.Usages.Contains(usage)))
            {
                return false;
            }

            var releaseNumberRegex = _releaseNumberRegex;
            if (releaseNumberRegex is null)
            {
                if (string.IsNullOrWhiteSpace(ReleaseNumberRegex))
                {
                    // No regex to match.
                    return true;
                }

                releaseNumberRegex = new Regex(ReleaseNumberRegex, RegexOptions.Compiled);
                _releaseNumberRegex = releaseNumberRegex;
            }

            return releaseNumberRegex.IsMatch(device.ReleaseNumber.ToString());
        }
    }
}