using System.Runtime.InteropServices;
using Xunit;

namespace Alis.Extension.Plugin.Test.PlatformAttributes
{
    /// <summary>
    /// The linux only fact attribute class
    /// </summary>
    /// <seealso cref="FactAttribute"/>
    internal class LinuxOnlyFactAttribute : FactAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinuxOnlyFactAttribute"/> class
        /// </summary>
        public LinuxOnlyFactAttribute()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux) && !new PluginManager().IsRunningOnAndroid())
            {
                Skip = "This test is only applicable on Linux";
            }
        }
    }
}