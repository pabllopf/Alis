using System;
using System.IO;
using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    public class BrowserPlayerConstructorErrorTests : IDisposable
    {
        private const string ModeFilePath = "/tmp/openal_stub_mode.txt";

        public void Dispose()
        {
            // Reset to success mode
            try { File.WriteAllText(ModeFilePath, "success"); } catch { }
        }

        [Fact]
        public void Constructor_WhenDeviceFails_ShouldThrow()
        {
            File.WriteAllText(ModeFilePath, "device_fail");
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => new BrowserPlayer());
            Assert.Contains("OpenAL", ex.Message);
        }

        [Fact]
        public void Constructor_WhenContextFails_ShouldThrow()
        {
            File.WriteAllText(ModeFilePath, "context_fail");
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => new BrowserPlayer());
            Assert.Contains("OpenAL", ex.Message);
        }

        [Fact]
        public void Constructor_WhenMakeCurrentFails_ShouldThrow()
        {
            File.WriteAllText(ModeFilePath, "current_fail");
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => new BrowserPlayer());
            Assert.Contains("OpenAL", ex.Message);
        }
    }
}
