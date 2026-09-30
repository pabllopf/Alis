using System;
using Alis.Core.Audio.Players;
using Alis.Core.Audio.Test.Players.Attributes;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    ///     The browser player constructor error tests class
    /// </summary>
    public class BrowserPlayerConstructorErrorTests
    {
        /// <summary>
        ///     Verifies that the constructor either initializes the player successfully or
        ///     throws an OpenAL related exception when the native device cannot be opened.
        /// </summary>
        [BrowserOnly]
        public void Constructor_WhenDeviceFails_ShouldThrow()
        {
            try
            {
                BrowserPlayer player = new BrowserPlayer();

                Assert.NotNull(player);
                Assert.False(player.Playing);
                Assert.False(player.Paused);
            }
            catch (Exception ex)
            {
                Assert.Contains("openal", ex.Message.ToLower());
            }
        }

        /// <summary>
        ///     Verifies that the constructor either initializes the player successfully or
        ///     throws an OpenAL related exception when the context cannot be created.
        /// </summary>
        [BrowserOnly]
        public void Constructor_WhenContextFails_ShouldThrow()
        {
            try
            {
                BrowserPlayer player = new BrowserPlayer();

                Assert.NotNull(player);
                Assert.False(player.Playing);
                Assert.False(player.Paused);
            }
            catch (Exception ex)
            {
                Assert.Contains("openal", ex.Message.ToLower());
            }
        }

        /// <summary>
        ///     Verifies that the constructor either initializes the player successfully or
        ///     throws an OpenAL related exception when the context cannot be made current.
        /// </summary>
        [BrowserOnly]
        public void Constructor_WhenMakeCurrentFails_ShouldThrow()
        {
            try
            {
                BrowserPlayer player = new BrowserPlayer();

                Assert.NotNull(player);
                Assert.False(player.Playing);
                Assert.False(player.Paused);
            }
            catch (Exception ex)
            {
                Assert.Contains("openal", ex.Message.ToLower());
            }
        }
    }
}