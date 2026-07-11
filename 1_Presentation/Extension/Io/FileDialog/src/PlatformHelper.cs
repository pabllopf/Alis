using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Io.FileDialog
{
    internal static class PlatformHelper
    {
        internal static Func<OSPlatform, bool> IsOSPlatform { get; set; } = RuntimeInformation.IsOSPlatform;
    }
}
