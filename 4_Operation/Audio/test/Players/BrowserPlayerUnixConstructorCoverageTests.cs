using System;
using Alis.Core.Audio.Players;
using Alis.Core.Audio.Test.Players.Attributes;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    ///     Exercises the BrowserPlayer constructor entry on hosts where the win32
    ///     "openal32" native library is unavailable, so the first OpenAL interop call
    ///     fails at the DllImport boundary.
    /// </summary>
    public class BrowserPlayerUnixConstructorCoverageTests
    {
        /// <summary>
        ///     Verifies that constructing a BrowserPlayer on a Unix host throws at the
        ///     native OpenAL boundary.
        /// </summary>
        [UnixOnly]
        public void Constructor_OnUnix_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => new BrowserPlayer());
        }
    }
}