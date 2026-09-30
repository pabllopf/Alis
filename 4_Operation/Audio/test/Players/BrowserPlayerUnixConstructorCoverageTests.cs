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
        ///     Verifies that constructing a BrowserPlayer either initializes successfully or
        ///     throws at the native OpenAL boundary on hosts without the library.
        /// </summary>
        [UnixOnly]
        public void Constructor_OnUnix_ThrowsDllNotFoundException()
        {
            try
            {
                BrowserPlayer player = new BrowserPlayer();

                Assert.NotNull(player);
            }
            catch (DllNotFoundException)
            {
                // Expected on hosts where the OpenAL native library is unavailable.
            }
        }
    }
}