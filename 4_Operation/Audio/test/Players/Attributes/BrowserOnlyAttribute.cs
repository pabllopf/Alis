

using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Xunit;

namespace Alis.Core.Audio.Test.Players.Attributes
{
    /// <summary>
    ///     The browser only attribute class
    /// </summary>
    /// <seealso cref="FactAttribute" />
    [ExcludeFromCodeCoverage]
    public class BrowserOnlyAttribute : FactAttribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BrowserOnlyAttribute" /> class
        /// </summary>
        public BrowserOnlyAttribute()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Create("WEBASSEMBLY")) &&
                !RuntimeInformation.IsOSPlatform(OSPlatform.Create("BROWSER")))
            {
                Skip = "Only running in browser/webassembly mode";
            }
        }
    }
}