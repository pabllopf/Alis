// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MusicExecutionTests.cs
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

using System;
using System.IO;
using Alis.Extension.Graphic.Sfml.Audios;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    /// <summary>
    /// Execution coverage tests for the music class
    /// </summary>
    public class MusicExecutionTests
    {
        /// <summary>
        /// The assets dir
        /// </summary>
        private static readonly string AssetsDir;

        /// <summary>
        /// Initializes a new instance of the <see cref="MusicExecutionTests"/> class
        /// </summary>
        static MusicExecutionTests()
        {
            string assemblyDir = Path.GetDirectoryName(typeof(MusicExecutionTests).Assembly.Location);
            AssetsDir = Path.GetFullPath(Path.Combine(assemblyDir, "..", "..", "..", "Assets"));
        }

        /// <summary>
        /// Gets the value of the audio sample path
        /// </summary>
        private static string AudioSamplePath => Path.Combine(AssetsDir, "AudioSample.wav");

        /// <summary>
        /// Tests the to string does not crash or throws entry point not found on the loop symbol
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_ToString_Probe_DoesNotCrashOrThrowsEntryPointNotFound()
        {
            Music music = null;
            try
            {
                music = new Music(AudioSamplePath);
                Exception exception = Record.Exception(() => _ = music.ToString());
                Assert.True(exception == null || exception is EntryPointNotFoundException);
            }
            finally
            {
                music?.Dispose();
            }
        }

        /// <summary>
        /// Tests the loop setter does not crash or throws entry point not found on the set loop symbol
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Loop_Set_Probe_DoesNotCrashOrThrowsEntryPointNotFound()
        {
            Music music = null;
            try
            {
                music = new Music(AudioSamplePath);
                Exception exception = Record.Exception(() => music.Loop = true);
                Assert.True(exception == null || exception is EntryPointNotFoundException);
            }
            finally
            {
                music?.Dispose();
            }
        }

        /// <summary>
        /// Tests the sample rate getter does not throw
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_SampleRate_Getter_DoesNotThrow()
        {
            Music music = null;
            try
            {
                music = new Music(AudioSamplePath);
                _ = music.SampleRate;
            }
            finally
            {
                music?.Dispose();
            }
        }

        /// <summary>
        /// Tests the channel count getter does not throw
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_ChannelCount_Getter_DoesNotThrow()
        {
            Music music = null;
            try
            {
                music = new Music(AudioSamplePath);
                _ = music.ChannelCount;
            }
            finally
            {
                music?.Dispose();
            }
        }

        /// <summary>
        /// Tests the status getter does not throw
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Status_Getter_DoesNotThrow()
        {
            Music music = null;
            try
            {
                music = new Music(AudioSamplePath);
                _ = music.Status;
            }
            finally
            {
                music?.Dispose();
            }
        }

        /// <summary>
        /// Tests the duration getter does not throw
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Duration_Getter_DoesNotThrow()
        {
            Music music = null;
            try
            {
                music = new Music(AudioSamplePath);
                _ = music.Duration;
            }
            finally
            {
                music?.Dispose();
            }
        }

        /// <summary>
        /// Tests the pitch getter does not throw
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Pitch_Getter_DoesNotThrow()
        {
            Music music = null;
            try
            {
                music = new Music(AudioSamplePath);
                _ = music.Pitch;
            }
            finally
            {
                music?.Dispose();
            }
        }

        /// <summary>
        /// Tests the volume getter does not throw
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Volume_Getter_DoesNotThrow()
        {
            Music music = null;
            try
            {
                music = new Music(AudioSamplePath);
                _ = music.Volume;
            }
            finally
            {
                music?.Dispose();
            }
        }

        /// <summary>
        /// Tests the position getter does not throw
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Position_Getter_DoesNotThrow()
        {
            Music music = null;
            try
            {
                music = new Music(AudioSamplePath);
                _ = music.Position;
            }
            finally
            {
                music?.Dispose();
            }
        }

        /// <summary>
        /// Tests the relative to listener getter does not throw
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_RelativeToListener_Getter_DoesNotThrow()
        {
            Music music = null;
            try
            {
                music = new Music(AudioSamplePath);
                _ = music.RelativeToListener;
            }
            finally
            {
                music?.Dispose();
            }
        }

        /// <summary>
        /// Tests the min distance getter does not throw
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_MinDistance_Getter_DoesNotThrow()
        {
            Music music = null;
            try
            {
                music = new Music(AudioSamplePath);
                _ = music.MinDistance;
            }
            finally
            {
                music?.Dispose();
            }
        }

        /// <summary>
        /// Tests the attenuation getter does not throw
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Attenuation_Getter_DoesNotThrow()
        {
            Music music = null;
            try
            {
                music = new Music(AudioSamplePath);
                _ = music.Attenuation;
            }
            finally
            {
                music?.Dispose();
            }
        }

        /// <summary>
        /// Tests the playing offset getter does not throw
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_PlayingOffset_Getter_DoesNotThrow()
        {
            Music music = null;
            try
            {
                music = new Music(AudioSamplePath);
                _ = music.PlayingOffset;
            }
            finally
            {
                music?.Dispose();
            }
        }

        /// <summary>
        /// Tests the loop points getter does not throw
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_LoopPoints_Getter_DoesNotThrow()
        {
            Music music = null;
            try
            {
                music = new Music(AudioSamplePath);
                _ = music.LoopPoints;
            }
            finally
            {
                music?.Dispose();
            }
        }
    }
}
