using System;
using System.IO;
using Alis.Core.Audio.Players;
using Alis.Core.Audio.Test.Players.Attributes;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    /// The browser player constructor error tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class BrowserPlayerConstructorErrorTests : IDisposable
    {
        /// <summary>
        /// The mode file path
        /// </summary>
        private const string ModeFilePath = "/tmp/openal_stub_mode.txt";

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            // Reset to success mode
            try { File.WriteAllText(ModeFilePath, "success"); } catch { }
        }

        /// <summary>
        /// Constructors the when device fails should throw
        /// </summary>
        [BrowserOnly]
        public void Constructor_WhenDeviceFails_ShouldThrow()
        {
            File.WriteAllText(ModeFilePath, "device_fail");
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => new BrowserPlayer());
            Assert.Contains("OpenAL", ex.Message);
        }

        /// <summary>
        /// Constructors the when context fails should throw
        /// </summary>
        [BrowserOnly]
        public void Constructor_WhenContextFails_ShouldThrow()
        {
            File.WriteAllText(ModeFilePath, "context_fail");
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => new BrowserPlayer());
            Assert.Contains("OpenAL", ex.Message);
        }

        /// <summary>
        /// Constructors the when make current fails should throw
        /// </summary>
        [BrowserOnly]
        public void Constructor_WhenMakeCurrentFails_ShouldThrow()
        {
            File.WriteAllText(ModeFilePath, "current_fail");
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => new BrowserPlayer());
            Assert.Contains("OpenAL", ex.Message);
        }
    }
}
