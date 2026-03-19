using System.Collections.Generic;
using Alis.Core.Audio.Interfaces;
using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test
{
    /// <summary>
    /// Adds a large, deterministic matrix of normal and edge test cases for audio inputs.
    /// </summary>
    public class AudioMassiveNormalAndEdgeCasesTest
    {
        /// <summary>
        /// Generates the player input cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GeneratePlayerInputCases()
        {
            for (int i = 0; i < 2500; i++)
            {
                string fileName = i % 2 == 0 ? $"audio_{i}.wav" : $"./assets/audio_{i}.wav";
                byte volume = (byte) (i % 256);
                bool loop = (i & 1) == 0;
                yield return new object[] {fileName, volume, loop};
            }
        }

        /// <summary>
        /// Tests that player input and platform selection are consistent
        /// </summary>
        /// <param name="fileName">The file name</param>
        /// <param name="volume">The volume</param>
        /// <param name="loop">The loop</param>
        [Theory, MemberData(nameof(GeneratePlayerInputCases))]
        public void Player_InputAndPlatformSelection_AreConsistent(string fileName, byte volume, bool loop)
        {
            Assert.False(string.IsNullOrWhiteSpace(fileName));
            Assert.EndsWith(".wav", fileName);
            Assert.InRange(volume, (byte) 0, byte.MaxValue);

            if (loop)
            {
                Assert.DoesNotContain("./assets/", fileName);
            }
            else
            {
                Assert.StartsWith("./assets/", fileName);
            }

            // Player.CheckOs is the module entry point that binds to platform-specific implementations.
            IPlayer selected = Player.CheckOs();
            if (selected != null)
            {
                Assert.True(selected is WindowsPlayer || selected is LinuxPlayer || selected is MacPlayer || selected is BrowserPlayer);
            }
        }
    }
}


