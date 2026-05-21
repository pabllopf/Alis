

using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Xunit;

namespace Alis.Core.Audio.Test.Players.Attributes
{
    /// <summary>
    ///     The unix only attribute class
    /// </summary>
    /// <seealso cref="FactAttribute" />
    [ExcludeFromCodeCoverage]
    public class UnixOnlyAttribute : FactAttribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="UnixOnlyAttribute" /> class
        /// </summary>
        public UnixOnlyAttribute()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.OSX) && !RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Skip = "Only running on unix systems mode";
            }
        }
    }
}