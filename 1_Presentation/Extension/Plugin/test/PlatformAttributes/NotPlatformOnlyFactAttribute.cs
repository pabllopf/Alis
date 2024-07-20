using System.Runtime.InteropServices;
using Xunit;

namespace Alis.Extension.Plugin.Test.PlatformAttributes
{
    /// <summary>
    /// The not platform only fact attribute class
    /// </summary>
    /// <seealso cref="FactAttribute"/>
    public class NotPlatformOnlyFactAttribute : FactAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotPlatformOnlyFactAttribute"/> class
        /// </summary>
        public NotPlatformOnlyFactAttribute()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ||
                RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ||
                RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Skip = "This test is only applicable on unsupported platforms";
            }
        }
    }
}