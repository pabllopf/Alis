

using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test.Attributes
{
    /// <summary>
    ///     The linux only attribute class
    /// </summary>
    /// <seealso cref="FactAttribute" />
    [ExcludeFromCodeCoverage]
    public class LinuxOnlyAttribute : FactAttribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LinuxOnlyAttribute" /> class
        /// </summary>
        public LinuxOnlyAttribute()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Skip = "Only running in linux mode";
            }
        }
    }
}