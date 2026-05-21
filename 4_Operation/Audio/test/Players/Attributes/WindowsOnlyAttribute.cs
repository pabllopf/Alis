

using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Xunit;

namespace Alis.Core.Audio.Test.Players.Attributes
{
    /// <summary>
    ///     The runnable in debug only attribute class
    /// </summary>
    /// <seealso cref="FactAttribute" />
    [ExcludeFromCodeCoverage]
    public class WindowsOnlyAttribute : FactAttribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="WindowsOnlyAttribute" /> class
        /// </summary>
        public WindowsOnlyAttribute()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Skip = "Only running in windows mode";
            }
        }
    }
}