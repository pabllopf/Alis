// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UnixPlayerBaseGetAudioDurationCoverageTests.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.IO;
using System.Threading.Tasks;
using Alis.Core.Audio.Players;
using Alis.Core.Audio.Test.Players.Attributes;
using Alis.Core.Audio.Test.Players.Samples;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    ///     The unix player base get audio duration coverage tests class
    /// </summary>
    public class UnixPlayerBaseGetAudioDurationCoverageTests
    {
        /// <summary>
        ///     Creates a valid wav file on disk
        /// </summary>
        /// <param name="path">The path</param>
        private static void CreateValidWavFile(string path)
        {
            using FileStream fs = new FileStream(path, FileMode.Create);
            using BinaryWriter writer = new BinaryWriter(fs);
            int sampleRate = 44100;
            short channels = 1;
            short bitsPerSample = 16;
            int dataSize = sampleRate * channels * (bitsPerSample / 8);
            int blockAlign = channels * bitsPerSample / 8;
            int byteRate = sampleRate * blockAlign;
            int totalSize = 36 + dataSize;

            writer.Write(System.Text.Encoding.ASCII.GetBytes("RIFF"));
            writer.Write(totalSize);
            writer.Write(System.Text.Encoding.ASCII.GetBytes("WAVE"));
            writer.Write(System.Text.Encoding.ASCII.GetBytes("fmt "));
            writer.Write(16);
            writer.Write((short)1);
            writer.Write(channels);
            writer.Write(sampleRate);
            writer.Write(byteRate);
            writer.Write((short)blockAlign);
            writer.Write(bitsPerSample);
            writer.Write(System.Text.Encoding.ASCII.GetBytes("data"));
            writer.Write(dataSize);
            writer.Write(new byte[dataSize]);
        }

        /// <summary>
        ///     Tests that play loop with loop true calls get audio duration and runs background loop
        /// </summary>
        [UnixOnly]
        public async Task PlayLoop_WithLoopTrue_AndRealWavFile_ExecutesGetAudioDuration()
        {
            TestUnixPlayer player = new TestUnixPlayer();
            string tempFile = Path.GetTempFileName() + ".wav";
            try
            {
                CreateValidWavFile(tempFile);
                Assert.True(File.Exists(tempFile));

                await player.PlayLoop(tempFile, true);
                Assert.True(player.Playing);

                await Task.Delay(300);

                await player.Stop();
                Assert.False(player.Playing);
            }
            finally
            {
                await player.Stop();
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }
    }
}
