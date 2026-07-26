// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SoundTest.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Audios;
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    public class SoundTest
    {
        private static readonly string AssetsDir;

        static SoundTest()
        {
            string assemblyDir = Path.GetDirectoryName(typeof(SoundTest).Assembly.Location);
            AssetsDir = Path.GetFullPath(Path.Combine(assemblyDir, "..", "..", "..", "Assets"));
        }

        private static string AudioSamplePath => Path.Combine(AssetsDir, "AudioSample.wav");

        [RequireCSfmlAudioFact]
        public void Type_ShouldBeAccessible()
        {
            Assert.NotNull(typeof(Sound));
        }

        [RequireCSfmlAudioFact]
        public void ShouldImplementIDisposable()
        {
            Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(Sound)));
        }

        [RequireCSfmlAudioFact]
        public void ShouldInheritFromObjectBase()
        {
            Assert.Equal("ObjectBase", typeof(Sound).BaseType.Name);
        }

        [RequireCSfmlAudioFact]
        public void Namespace_ShouldBeCorrect()
        {
            Assert.Equal("Alis.Extension.Graphic.Sfml.Audios", typeof(Sound).Namespace);
        }

        [RequireCSfmlAudioFact]
        public void IsPublic()
        {
            Assert.True(typeof(Sound).IsPublic);
        }

        [RequireCSfmlAudioFact]
        public void DefaultConstructor_ShouldCreateInstance()
        {
            using Sound sound = new Sound();
            Assert.NotNull(sound);
        }

        [RequireCSfmlAudioFact]
        public void DefaultConstructor_ShouldSetCPointerToNonZero()
        {
            using Sound sound = new Sound();
            Assert.NotEqual(IntPtr.Zero, sound.CPointer);
        }

        [RequireCSfmlAudioFact]
        public void Constructor_WithSoundBuffer_ShouldCreateInstance()
        {
            using SoundBuffer buffer = new SoundBuffer(AudioSamplePath);
            using Sound sound = new Sound(buffer);
            Assert.NotNull(sound);
            Assert.NotEqual(IntPtr.Zero, sound.CPointer);
        }

        [RequireCSfmlAudioFact]
        public void CopyConstructor_ShouldCreateInstance()
        {
            using SoundBuffer buffer = new SoundBuffer(AudioSamplePath);
            using Sound original = new Sound(buffer);
            using Sound copy = new Sound(original);
            Assert.NotNull(copy);
            Assert.NotEqual(IntPtr.Zero, copy.CPointer);
        }

        [RequireCSfmlAudioFact]
        public void CopyConstructor_ShouldCopySoundBuffer()
        {
            using SoundBuffer buffer = new SoundBuffer(AudioSamplePath);
            using Sound original = new Sound(buffer);
            using Sound copy = new Sound(original);
            Assert.NotNull(copy.SoundBuffer);
        }

        [RequireCSfmlAudioFact]
        public void SoundBuffer_Get_ShouldReturnSetBuffer()
        {
            using SoundBuffer buffer = new SoundBuffer(AudioSamplePath);
            using Sound sound = new Sound();
            sound.SoundBuffer = buffer;
            Assert.NotNull(sound.SoundBuffer);
        }

        [RequireCSfmlAudioFact]
        public void SoundBuffer_Default_ShouldBeNull()
        {
            using Sound sound = new Sound();
            Assert.Null(sound.SoundBuffer);
        }

        [RequireCSfmlAudioFact]
        public void Status_Default_ShouldBeStopped()
        {
            using Sound sound = new Sound();
            Assert.Equal(SoundStatus.Stopped, sound.Status);
        }

        [RequireCSfmlAudioFact]
        public void Loop_Default_ShouldBeFalse()
        {
            using Sound sound = new Sound();
            Assert.False(sound.Loop);
        }

        [RequireCSfmlAudioFact]
        public void Loop_Set_ShouldReflectChange()
        {
            using Sound sound = new Sound();
            sound.Loop = true;
            Assert.True(sound.Loop);
            sound.Loop = false;
            Assert.False(sound.Loop);
        }

        [RequireCSfmlAudioFact]
        public void Pitch_Default_ShouldBeOne()
        {
            using Sound sound = new Sound();
            Assert.Equal(1.0f, sound.Pitch);
        }

        [RequireCSfmlAudioFact]
        public void Pitch_Set_ShouldReflectChange()
        {
            using Sound sound = new Sound();
            sound.Pitch = 2.0f;
            Assert.Equal(2.0f, sound.Pitch);
            sound.Pitch = 0.5f;
            Assert.Equal(0.5f, sound.Pitch);
        }

        [RequireCSfmlAudioFact]
        public void Volume_Default_ShouldBe100()
        {
            using Sound sound = new Sound();
            Assert.Equal(100.0f, sound.Volume);
        }

        [RequireCSfmlAudioFact]
        public void Volume_Set_ShouldReflectChange()
        {
            using Sound sound = new Sound();
            sound.Volume = 50.0f;
            Assert.Equal(50.0f, sound.Volume);
            sound.Volume = 0.0f;
            Assert.Equal(0.0f, sound.Volume);
        }

        [RequireCSfmlAudioFact]
        public void PlayingOffset_Get_ShouldWork()
        {
            using Sound sound = new Sound();
            _ = sound.PlayingOffset;
        }

        [RequireCSfmlAudioFact]
        public void PlayingOffset_Set_ShouldWork()
        {
            using Sound sound = new Sound();
            sound.PlayingOffset = SfmlTime.Zero;
        }

        [RequireCSfmlAudioFact]
        public void Position_Default_ShouldBeZero()
        {
            using Sound sound = new Sound();
            Vector3F pos = sound.Position;
            Assert.Equal(0.0f, pos.X);
            Assert.Equal(0.0f, pos.Y);
            Assert.Equal(0.0f, pos.Z);
        }

        [RequireCSfmlAudioFact]
        public void Position_Set_ShouldReflectChange()
        {
            using Sound sound = new Sound();
            Vector3F expected = new Vector3F(10.0f, 20.0f, 30.0f);
            sound.Position = expected;
            Vector3F actual = sound.Position;
            Assert.Equal(expected.X, actual.X);
            Assert.Equal(expected.Y, actual.Y);
            Assert.Equal(expected.Z, actual.Z);
        }

        [RequireCSfmlAudioFact]
        public void RelativeToListener_Default_ShouldBeFalse()
        {
            using Sound sound = new Sound();
            Assert.False(sound.RelativeToListener);
        }

        [RequireCSfmlAudioFact]
        public void RelativeToListener_Set_ShouldReflectChange()
        {
            using Sound sound = new Sound();
            sound.RelativeToListener = true;
            Assert.True(sound.RelativeToListener);
            sound.RelativeToListener = false;
            Assert.False(sound.RelativeToListener);
        }

        [RequireCSfmlAudioFact]
        public void MinDistance_Default_ShouldBeOne()
        {
            using Sound sound = new Sound();
            Assert.Equal(1.0f, sound.MinDistance);
        }

        [RequireCSfmlAudioFact]
        public void MinDistance_Set_ShouldReflectChange()
        {
            using Sound sound = new Sound();
            sound.MinDistance = 5.0f;
            Assert.Equal(5.0f, sound.MinDistance);
        }

        [RequireCSfmlAudioFact]
        public void Attenuation_Default_ShouldBeOne()
        {
            using Sound sound = new Sound();
            Assert.Equal(1.0f, sound.Attenuation);
        }

        [RequireCSfmlAudioFact]
        public void Attenuation_Set_ShouldReflectChange()
        {
            using Sound sound = new Sound();
            sound.Attenuation = 0.5f;
            Assert.Equal(0.5f, sound.Attenuation);
        }

        [RequireCSfmlAudioFact]
        public void Play_ShouldChangeStatusToPlaying()
        {
            using SoundBuffer buffer = new SoundBuffer(AudioSamplePath);
            using Sound sound = new Sound(buffer);
            sound.Play();
            Assert.Equal(SoundStatus.Playing, sound.Status);
            sound.Stop();
        }

        [RequireCSfmlAudioFact]
        public void Play_AndPause_ShouldChangeStatusToPaused()
        {
            using SoundBuffer buffer = new SoundBuffer(AudioSamplePath);
            using Sound sound = new Sound(buffer);
            sound.Play();
            sound.Pause();
            Assert.Equal(SoundStatus.Paused, sound.Status);
            sound.Stop();
        }

        [RequireCSfmlAudioFact]
        public void Stop_ShouldChangeStatusToStopped()
        {
            using SoundBuffer buffer = new SoundBuffer(AudioSamplePath);
            using Sound sound = new Sound(buffer);
            sound.Play();
            sound.Stop();
            Assert.Equal(SoundStatus.Stopped, sound.Status);
        }

        [RequireCSfmlAudioFact]
        public void ToString_ShouldContainSoundPrefix()
        {
            using Sound sound = new Sound();
            string result = sound.ToString();
            Assert.Contains("[Sound]", result);
        }

        [RequireCSfmlAudioFact]
        public void ToString_ShouldContainStatus()
        {
            using Sound sound = new Sound();
            string result = sound.ToString();
            Assert.Contains("Status(", result);
        }

        [RequireCSfmlAudioFact]
        public void ToString_ShouldContainLoop()
        {
            using Sound sound = new Sound();
            string result = sound.ToString();
            Assert.Contains("Loop(", result);
        }

        [RequireCSfmlAudioFact]
        public void ToString_ShouldContainPitch()
        {
            using Sound sound = new Sound();
            string result = sound.ToString();
            Assert.Contains("Pitch(", result);
        }

        [RequireCSfmlAudioFact]
        public void ToString_ShouldContainVolume()
        {
            using Sound sound = new Sound();
            string result = sound.ToString();
            Assert.Contains("Volume(", result);
        }

        [RequireCSfmlAudioFact]
        public void ToString_ShouldContainPosition()
        {
            using Sound sound = new Sound();
            string result = sound.ToString();
            Assert.Contains("Position(", result);
        }

        [RequireCSfmlAudioFact]
        public void ToString_ShouldContainRelativeToListener()
        {
            using Sound sound = new Sound();
            string result = sound.ToString();
            Assert.Contains("RelativeToListener(", result);
        }

        [RequireCSfmlAudioFact]
        public void ToString_ShouldContainMinDistance()
        {
            using Sound sound = new Sound();
            string result = sound.ToString();
            Assert.Contains("MinDistance(", result);
        }

        [RequireCSfmlAudioFact]
        public void ToString_ShouldContainAttenuation()
        {
            using Sound sound = new Sound();
            string result = sound.ToString();
            Assert.Contains("Attenuation(", result);
        }

        [RequireCSfmlAudioFact]
        public void ToString_ShouldContainPlayingOffset()
        {
            using Sound sound = new Sound();
            string result = sound.ToString();
            Assert.Contains("PlayingOffset(", result);
        }

        [RequireCSfmlAudioFact]
        public void ToString_ShouldContainSoundBuffer()
        {
            using Sound sound = new Sound();
            string result = sound.ToString();
            Assert.Contains("SoundBuffer(", result);
        }

        [RequireCSfmlAudioFact]
        public void Dispose_ShouldSetCPointerToZero()
        {
            Sound sound = new Sound();
            IntPtr ptr = sound.CPointer;
            Assert.NotEqual(IntPtr.Zero, ptr);
            sound.Dispose();
            Assert.Equal(IntPtr.Zero, sound.CPointer);
        }

        [RequireCSfmlAudioFact]
        public void Destroy_ShouldSetCPointerToZero()
        {
            Sound sound = new Sound();
            IntPtr ptr = sound.CPointer;
            Assert.NotEqual(IntPtr.Zero, ptr);
            sound.Destroy(true);
            Assert.Equal(IntPtr.Zero, sound.CPointer);
        }

        [RequireCSfmlAudioFact]
        public void Play_WithoutBuffer_ShouldNotThrow()
        {
            using Sound sound = new Sound();
            sound.Play();
        }

        [RequireCSfmlAudioFact]
        public void Pause_WithoutPlaying_ShouldNotThrow()
        {
            using Sound sound = new Sound();
            sound.Pause();
        }

        [RequireCSfmlAudioFact]
        public void Stop_WithoutPlaying_ShouldNotThrow()
        {
            using Sound sound = new Sound();
            sound.Stop();
        }

        [RequireCSfmlAudioFact]
        public void Loop_WithBufferAndPlay_ShouldNotThrow()
        {
            using SoundBuffer buffer = new SoundBuffer(AudioSamplePath);
            using Sound sound = new Sound(buffer);
            sound.Loop = true;
            sound.Play();
            Assert.Equal(SoundStatus.Playing, sound.Status);
            sound.Stop();
        }
    }
}
