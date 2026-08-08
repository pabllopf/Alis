// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MusicTest.cs
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
    /// The music test class
    /// </summary>
    public class MusicTest
    {
        /// <summary>
        /// The assets dir
        /// </summary>
        private static readonly string AssetsDir;

        /// <summary>
        /// Initializes a new instance of the <see cref="MusicTest"/> class
        /// </summary>
        static MusicTest()
        {
            string assemblyDir = Path.GetDirectoryName(typeof(MusicTest).Assembly.Location);
            AssetsDir = Path.GetFullPath(Path.Combine(assemblyDir, "..", "..", "..", "Assets"));
        }

        /// <summary>
        /// Gets the value of the audio sample path
        /// </summary>
        private static string AudioSamplePath => Path.Combine(AssetsDir, "AudioSample.wav");

        /// <summary>
        /// Musics the type should be accessible
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Type_ShouldBeAccessible() =>
            Assert.NotNull(typeof(Music));

        /// <summary>
        /// Musics the should implement i disposable
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_ShouldImplementIDisposable() =>
            Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(Music)));

        /// <summary>
        /// Musics the should inherit from object base
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_ShouldInheritFromObjectBase() =>
            Assert.Equal("ObjectBase", typeof(Music).BaseType.Name);

        /// <summary>
        /// Musics the namespace should be correct
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Namespace_ShouldBeCorrect() =>
            Assert.Equal("Alis.Extension.Graphic.Sfml.Audios", typeof(Music).Namespace);

        /// <summary>
        /// Musics the constructor from file should create instance
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Constructor_FromFile_ShouldCreateInstance()
        {
            using Music music = new Music(AudioSamplePath);
            Assert.NotEqual(IntPtr.Zero, music.CPointer);
        }

        /// <summary>
        /// Musics the constructor from file should throw on invalid path
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Constructor_FromFile_ShouldThrowOnInvalidPath() =>
            _ = Assert.Throws<Alis.Extension.Graphic.Sfml.Windows.LoadingFailedException>(() => new Music("/nonexistent/file.wav"));

        /// <summary>
        /// Musics the constructor from bytes should create instance
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Constructor_FromBytes_ShouldCreateInstance()
        {
            byte[] bytes = File.ReadAllBytes(AudioSamplePath);
            using Music music = new Music(bytes);
            Assert.NotEqual(IntPtr.Zero, music.CPointer);
        }

        /// <summary>
        /// Musics the constructor from bytes should throw on empty
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Constructor_FromBytes_ShouldThrowOnEmpty() =>
            _ = Assert.Throws<Alis.Extension.Graphic.Sfml.Windows.LoadingFailedException>(() => new Music(Array.Empty<byte>()));

        /// <summary>
        /// Musics the constructor from stream should create instance
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Constructor_FromStream_ShouldCreateInstance()
        {
            byte[] bytes = File.ReadAllBytes(AudioSamplePath);
            using MemoryStream stream = new MemoryStream(bytes);
            using Music music = new Music(stream);
            Assert.NotEqual(IntPtr.Zero, music.CPointer);
        }

        /// <summary>
        /// Musics the constructor from stream should throw on empty
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Constructor_FromStream_ShouldThrowOnEmpty()
        {
            using MemoryStream stream = new MemoryStream();
            _ = Assert.Throws<Alis.Extension.Graphic.Sfml.Windows.LoadingFailedException>(() => new Music(stream));
        }

        /// <summary>
        /// Musics the sample rate should be greater than zero
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_SampleRate_ShouldBeGreaterThanZero()
        {
            using Music music = new Music(AudioSamplePath);
            Assert.True(music.SampleRate > 0);
        }

        /// <summary>
        /// Musics the channel count should be greater than zero
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_ChannelCount_ShouldBeGreaterThanZero()
        {
            using Music music = new Music(AudioSamplePath);
            Assert.True(music.ChannelCount > 0);
        }

        /// <summary>
        /// Musics the status initially should be stopped
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Status_Initially_ShouldBeStopped()
        {
            using Music music = new Music(AudioSamplePath);
            Assert.Equal(SoundStatus.Stopped, music.Status);
        }

        /// <summary>
        /// Musics the duration should be positive
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Duration_ShouldBePositive()
        {
            using Music music = new Music(AudioSamplePath);
            Assert.True(music.Duration.AsMicroseconds() > 0);
        }

        /// <summary>
        /// Musics the pitch default should be one
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Pitch_Default_ShouldBeOne()
        {
            using Music music = new Music(AudioSamplePath);
            Assert.Equal(1.0f, music.Pitch, 5);
        }

        /// <summary>
        /// Musics the pitch set should reflect change
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Pitch_Set_ShouldReflectChange()
        {
            using Music music = new Music(AudioSamplePath);
            music.Pitch = 2.0f;
            Assert.Equal(2.0f, music.Pitch, 5);
        }

        /// <summary>
        /// Musics the volume default should be 100
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Volume_Default_ShouldBe100()
        {
            using Music music = new Music(AudioSamplePath);
            Assert.Equal(100.0f, music.Volume, 5);
        }

        /// <summary>
        /// Musics the volume set should reflect change
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Volume_Set_ShouldReflectChange()
        {
            using Music music = new Music(AudioSamplePath);
            music.Volume = 50.0f;
            Assert.Equal(50.0f, music.Volume, 5);
        }

        /// <summary>
        /// Musics the min distance default should be one
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_MinDistance_Default_ShouldBeOne()
        {
            using Music music = new Music(AudioSamplePath);
            Assert.Equal(1.0f, music.MinDistance, 5);
        }

        /// <summary>
        /// Musics the min distance set should reflect change
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_MinDistance_Set_ShouldReflectChange()
        {
            using Music music = new Music(AudioSamplePath);
            music.MinDistance = 5.0f;
            Assert.Equal(5.0f, music.MinDistance, 5);
        }

        /// <summary>
        /// Musics the attenuation default should be one
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Attenuation_Default_ShouldBeOne()
        {
            using Music music = new Music(AudioSamplePath);
            Assert.Equal(1.0f, music.Attenuation, 5);
        }

        /// <summary>
        /// Musics the attenuation set should reflect change
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Attenuation_Set_ShouldReflectChange()
        {
            using Music music = new Music(AudioSamplePath);
            music.Attenuation = 0.5f;
            Assert.Equal(0.5f, music.Attenuation, 5);
        }

        /// <summary>
        /// Musics the relative to listener default should be false
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_RelativeToListener_Default_ShouldBeFalse()
        {
            using Music music = new Music(AudioSamplePath);
            Assert.False(music.RelativeToListener);
        }

        /// <summary>
        /// Musics the relative to listener set should reflect change
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_RelativeToListener_Set_ShouldReflectChange()
        {
            using Music music = new Music(AudioSamplePath);
            music.RelativeToListener = true;
            Assert.True(music.RelativeToListener);
            music.RelativeToListener = false;
            Assert.False(music.RelativeToListener);
        }

        /// <summary>
        /// Musics the playing offset get should work
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_PlayingOffset_Get_ShouldWork()
        {
            using Music music = new Music(AudioSamplePath);
            _ = music.PlayingOffset;
        }

        /// <summary>
        /// Musics the playing offset set should work
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_PlayingOffset_Set_ShouldWork()
        {
            using Music music = new Music(AudioSamplePath);
            music.PlayingOffset = SfmlTime.Zero;
            _ = music.PlayingOffset;
        }

        /// <summary>
        /// Musics the play should change status to playing
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Play_ShouldChangeStatusToPlaying()
        {
            using Music music = new Music(AudioSamplePath);
            music.Play();
            Assert.Equal(SoundStatus.Playing, music.Status);
            music.Stop();
        }

        /// <summary>
        /// Musics the play and pause should change status to paused
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_PlayAndPause_ShouldChangeStatusToPaused()
        {
            using Music music = new Music(AudioSamplePath);
            music.Play();
            music.Pause();
            Assert.Equal(SoundStatus.Paused, music.Status);
            music.Stop();
        }

        /// <summary>
        /// Musics the stop should change status to stopped
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Stop_ShouldChangeStatusToStopped()
        {
            using Music music = new Music(AudioSamplePath);
            music.Play();
            music.Stop();
            Assert.Equal(SoundStatus.Stopped, music.Status);
        }

        /// <summary>
        /// Musics the dispose should set c pointer to zero
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Dispose_ShouldSetCPointerToZero()
        {
            Music music = new Music(AudioSamplePath);
            IntPtr ptr = music.CPointer;
            Assert.NotEqual(IntPtr.Zero, ptr);
            music.Dispose();
            Assert.Equal(IntPtr.Zero, music.CPointer);
        }

        /// <summary>
        /// Musics the from file and from bytes should have same properties
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_FromFileAndFromBytes_ShouldHaveSameProperties()
        {
            byte[] bytes = File.ReadAllBytes(AudioSamplePath);
            using Music fileMusic = new Music(AudioSamplePath);
            using Music bytesMusic = new Music(bytes);
            Assert.Equal(fileMusic.SampleRate, bytesMusic.SampleRate);
            Assert.Equal(fileMusic.ChannelCount, bytesMusic.ChannelCount);
        }

        /// <summary>
        /// Musics the loop points get should work
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_LoopPoints_Get_ShouldWork()
        {
            using Music music = new Music(AudioSamplePath);
            _ = music.LoopPoints;
        }

        /// <summary>
        /// Musics the time span struct should be accessible
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_TimeSpan_Struct_ShouldBeAccessible()
        {
            Type timeSpanType = typeof(Music.TimeSpan);
            Assert.True(timeSpanType.IsValueType);
        }
    }
}
