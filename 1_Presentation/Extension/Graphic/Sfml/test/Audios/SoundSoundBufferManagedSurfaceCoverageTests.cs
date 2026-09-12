// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:SoundSoundBufferManagedSurfaceCoverageTests.cs
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
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    /// <summary>
    ///     Probes and covers the managed surface of <see cref="SoundBuffer" /> and <see cref="Sound" /> through
    ///     real native objects built from sample data, avoiding on-disk fixtures.
    /// </summary>
    public class SoundSoundBufferManagedSurfaceCoverageTests
    {
        /// <summary>
        ///     Builds a one second mono buffer of known samples.
        /// </summary>
        /// <returns>The sound buffer built from 44100 sine-ish samples</returns>
        private static SoundBuffer BuildBuffer()
        {
            short[] samples = new short[44100];
            for (int i = 0; i < samples.Length; i++)
            {
                samples[i] = (short) ((i % 100) - 50);
            }

            return new SoundBuffer(samples, 1, 44100);
        }

        /// <summary>
        ///     Tests that a buffer built from samples exposes the given metadata.
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBuffer_WhenBuiltFromSamples_ReportsMetadata()
        {
            SoundBuffer buffer = BuildBuffer();

            Assert.Equal(44100u, buffer.SampleRate);
            Assert.Equal(1u, buffer.ChannelCount);
        }

        /// <summary>
        ///     Tests that samples round-trip through the native buffer.
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBuffer_WhenBuiltFromSamples_RoundTripsSamples()
        {
            SoundBuffer buffer = BuildBuffer();

            short[] samples = buffer.Samples;

            Assert.Equal(44100, samples.Length);
            Assert.Equal(-50, samples[0]);
            Assert.Equal(49, samples[44100 - 1]);
        }

        /// <summary>
        ///     Tests that the duration of a one second buffer is about one second.
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBuffer_WhenBuiltFromOneSecondSamples_DurationNearOneSecond()
        {
            SoundBuffer buffer = BuildBuffer();

            SfmlTime duration = buffer.Duration;

            Assert.True(duration.AsSeconds() >= 0.99f && duration.AsSeconds() <= 1.01f);
        }

        /// <summary>
        ///     Tests that a buffer built from memory bytes works and reports metadata.
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBuffer_WhenBuiltFromMemory_RoundsTrip()
        {
            SoundBuffer original = BuildBuffer();
            short[] samples = original.Samples;

            byte[] data = new byte[samples.Length * 2];
            for (int i = 0; i < samples.Length; i++)
            {
                data[i * 2] = (byte) (samples[i] & 0xFF);
                data[i * 2 + 1] = (byte) (((int) samples[i] >> 8) & 0xFF);
            }

            SoundBuffer buffer = null;
            try
            {
                buffer = new SoundBuffer(data);

                Assert.Equal(1u, buffer.ChannelCount);
            }
            finally
            {
                original?.Destroy(true);
                original?.Dispose();
            }
        }

        /// <summary>
        ///     Tests that a copied buffer shares the same metadata.
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBuffer_WhenCopied_SharesMetadata()
        {
            SoundBuffer original = BuildBuffer();

            SoundBuffer copy = new SoundBuffer(original);

            Assert.Equal(original.SampleRate, copy.SampleRate);
            Assert.Equal(original.ChannelCount, copy.ChannelCount);

            copy.Destroy(true);
            original.Destroy(true);
        }

        /// <summary>
        ///     Tests that a sound attached to a buffer reports its initial status and property round-trips.
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Sound_WhenAttachedToBuffer_RoundTripsProperties()
        {
            SoundBuffer buffer = BuildBuffer();
            Sound sound = new Sound(buffer);

            try
            {
                Assert.Equal(SoundStatus.Stopped, sound.Status);

                sound.Loop = true;
                Assert.True(sound.Loop);
                sound.Loop = false;
                Assert.False(sound.Loop);

                sound.Pitch = 2f;
                Assert.Equal(2f, sound.Pitch);

                sound.Volume = 50f;
                Assert.Equal(50f, sound.Volume);

                sound.PlayingOffset = SfmlTime.FromMilliseconds(123);
                Assert.Equal(123000L, sound.PlayingOffset.AsMicroseconds());

                sound.Position = new Alis.Core.Aspect.Math.Vector.Vector3F(1f, 2f, 3f);
                Alis.Core.Aspect.Math.Vector.Vector3F pos = sound.Position;
                Assert.Equal(1f, pos.X);
                Assert.Equal(2f, pos.Y);
                Assert.Equal(3f, pos.Z);
            }
            finally
            {
                sound.Destroy(true);
                buffer.Destroy(true);
            }
        }

        /// <summary>
        ///     Tests that play, pause and stop transitions are reflected in the status.
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Sound_WhenPlayPauseStop_StatusTransitions()
        {
            SoundBuffer buffer = BuildBuffer();
            Sound sound = new Sound(buffer);

            try
            {
                sound.Play();
                SoundStatus afterPlay = sound.Status;
                Assert.NotEqual(SoundStatus.Stopped, afterPlay);

                sound.Pause();
                Assert.Equal(SoundStatus.Paused, sound.Status);

                sound.Stop();
                Assert.Equal(SoundStatus.Stopped, sound.Status);
            }
            finally
            {
                sound.Destroy(true);
                buffer.Destroy(true);
            }
        }

        /// <summary>
        ///     Tests that the default sound supports a null buffer and reports stopped status.
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Sound_WhenDefaultConstructed_AcceptsThenClearsBuffer()
        {
            Sound sound = new Sound
            {
                SoundBuffer = BuildBuffer()
            };

            try
            {
                Assert.NotNull(sound.SoundBuffer);
                Assert.Equal(SoundStatus.Stopped, sound.Status);

                sound.SoundBuffer = null;
                Assert.Null(sound.SoundBuffer);
                Assert.Equal(SoundStatus.Stopped, sound.Status);
            }
            finally
            {
                sound.Destroy(true);
            }
        }

        /// <summary>
        ///     Tests that a sound copied from another sound carries the buffer reference.
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Sound_WhenCopied_HasSourceBuffer()
        {
            SoundBuffer buffer = BuildBuffer();
            Sound original = new Sound(buffer);

            Sound copy = new Sound(original);

            try
            {
                Assert.Same(buffer, copy.SoundBuffer);
                Assert.Equal(original.Status, copy.Status);
            }
            finally
            {
                copy.Destroy(true);
                original.Destroy(true);
                buffer.Destroy(true);
            }
        }

        /// <summary>
        ///     Tests that saving a buffer to a wav file succeeds and the file exists.
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBuffer_WhenSavedToFile_CreatesFile()
        {
            SoundBuffer buffer = BuildBuffer();
            string path = Path.Combine(Path.GetTempPath(), "alis-sfml-test-" + Guid.NewGuid().ToString("N") + ".wav");

            try
            {
                bool saved = buffer.SaveToFile(path);

                Assert.True(saved);
                Assert.True(File.Exists(path));
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                buffer.Destroy(true);
            }
        }
    }
}
