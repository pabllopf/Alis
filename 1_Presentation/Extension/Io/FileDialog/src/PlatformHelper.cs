using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Io.FileDialog
{
    /// <summary>
    /// The platform helper class
    /// </summary>
    internal static class PlatformHelper
    {
        /// <summary>
        /// Gets or sets the value of the is os platform
        /// </summary>
        internal static Func<OSPlatform, bool> IsOSPlatform { get; set; } = RuntimeInformation.IsOSPlatform;
    }
}
