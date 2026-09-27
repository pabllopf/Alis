using System;
using System.IO;
using Alis.Core.Audio.Players;
using Alis.Core.Audio.Test.Players.Attributes;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    ///     Exercises the WindowsPlayer Play/PlayLoop setup path when the file exists and the
    ///     winmm native library is unavailable (non-Windows hosts). The native call throws
    ///     DllNotFoundException after the managed setup lines have executed.
    /// </summary>
    public class WindowsPlayerUnixExistingFileCoverageTests : IDisposable
    {
        /// <summary>
        ///     The temp wav path used by the playback tests
        /// </summary>
        private readonly string _tempWav;

        /// <summary>
        ///     Initializes a new instance of the <see cref="WindowsPlayerUnixExistingFileCoverageTests"/> class
        /// </summary>
        public WindowsPlayerUnixExistingFileCoverageTests()
        {
            _tempWav = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".wav");
            File.WriteAllText(_tempWav, "test");
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (File.Exists(_tempWav))
            {
                File.Delete(_tempWav);
            }
        }
    }
}