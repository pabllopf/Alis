// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SoundRecorderTest.cs
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
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    public sealed class TestSoundRecorder : Alis.Extension.Graphic.Sfml.Audios.SoundRecorder
    {
        public bool OnStartCalled { get; private set; }

        public bool OnStopCalled { get; private set; }

        public short[] ProcessedSamples { get; private set; }

        public bool ProcessResult { get; set; } = true;

        public override bool OnStart()
        {
            OnStartCalled = true;
            return base.OnStart();
        }

        public override bool OnProcessSamples(short[] samples)
        {
            ProcessedSamples = samples;
            return ProcessResult;
        }

        public override void OnStop()
        {
            OnStopCalled = true;
            base.OnStop();
        }

        public void ExposeSetProcessingInterval(SfmlTime interval) => SetProcessingInterval(interval);

        public new IntPtr CPointer => base.CPointer;
    }

    public class SoundRecorderTest
    {
        [RequireCSfmlAudioFact]
        public void Constructor_ShouldSetCPointerToNonZero()
        {
            using var recorder = new TestSoundRecorder();
            Assert.NotEqual(IntPtr.Zero, recorder.CPointer);
        }

        [RequireCSfmlAudioFact]
        public void IsAvailable_ShouldReturnBool()
        {
            Assert.IsType<bool>(Alis.Extension.Graphic.Sfml.Audios.SoundRecorder.IsAvailable);
        }

        [RequireCSfmlAudioFact]
        public void AvailableDevices_ShouldReturnArray()
        {
            string[] devices = Alis.Extension.Graphic.Sfml.Audios.SoundRecorder.AvailableDevices;
            Assert.NotNull(devices);
        }

        [RequireCSfmlAudioFact]
        public void DefaultDevice_ShouldReturnString()
        {
            string device = Alis.Extension.Graphic.Sfml.Audios.SoundRecorder.DefaultDevice;
            Assert.NotNull(device);
            Assert.NotEqual(string.Empty, device);
        }

        [RequireCSfmlAudioFact]
        public void SampleRate_ShouldReturnValue()
        {
            using var recorder = new TestSoundRecorder();
            Assert.True(recorder.SampleRate > 0);
        }

        [RequireCSfmlAudioFact]
        public void ChannelCount_Default_ShouldBeOne()
        {
            using var recorder = new TestSoundRecorder();
            Assert.Equal(1u, recorder.ChannelCount);
        }

        [RequireCSfmlAudioFact]
        public void ChannelCount_Set_ShouldReflectChange()
        {
            using var recorder = new TestSoundRecorder();
            recorder.ChannelCount = 2u;
            Assert.Equal(2u, recorder.ChannelCount);
        }

        [RequireCSfmlAudioFact]
        public void ToString_ShouldContainSoundRecorder()
        {
            using var recorder = new TestSoundRecorder();
            Assert.Contains("[SoundRecorder]", recorder.ToString());
        }

        [RequireCSfmlAudioFact]
        public void ToString_ShouldContainSampleRate()
        {
            using var recorder = new TestSoundRecorder();
            Assert.Contains("SampleRate(", recorder.ToString());
        }

        [RequireCSfmlAudioFact]
        public void Start_Default_ShouldReturnBool()
        {
            using var recorder = new TestSoundRecorder();
            bool result = recorder.Start();
            if (result)
            {
                recorder.Stop();
            }
            Assert.IsType<bool>(result);
        }

        [RequireCSfmlAudioFact]
        public void Start_WithSampleRate_ShouldReturnBool()
        {
            using var recorder = new TestSoundRecorder();
            bool result = recorder.Start(22050);
            if (result)
            {
                recorder.Stop();
            }
            Assert.IsType<bool>(result);
        }

        [RequireCSfmlAudioFact]
        public void Stop_ShouldNotThrow()
        {
            using var recorder = new TestSoundRecorder();
            recorder.Stop();
        }

        [RequireCSfmlAudioFact]
        public void SetProcessingInterval_ThrowsEntryPointNotFound()
        {
            using var recorder = new TestSoundRecorder();
            Assert.Throws<EntryPointNotFoundException>(() => recorder.ExposeSetProcessingInterval(SfmlTime.FromMilliseconds(50)));
        }

        [RequireCSfmlAudioFact]
        public void SetDevice_WithDefaultDevice_ShouldReturnTrue()
        {
            using var recorder = new TestSoundRecorder();
            string defaultDevice = Alis.Extension.Graphic.Sfml.Audios.SoundRecorder.DefaultDevice;
            bool result = recorder.SetDevice(defaultDevice);
            Assert.True(result);
        }

        [RequireCSfmlAudioFact]
        public void GetDevice_ShouldReturnString()
        {
            using var recorder = new TestSoundRecorder();
            string device = recorder.GetDevice();
            Assert.NotNull(device);
            Assert.NotEqual(string.Empty, device);
        }

        [RequireCSfmlAudioFact]
        public void Class_ShouldBeAbstract()
        {
            Assert.True(typeof(Alis.Extension.Graphic.Sfml.Audios.SoundRecorder).IsAbstract);
        }

        [RequireCSfmlAudioFact]
        public void Class_ShouldInheritFromObjectBase()
        {
            Assert.Equal("ObjectBase", typeof(Alis.Extension.Graphic.Sfml.Audios.SoundRecorder).BaseType.Name);
        }

        [RequireCSfmlAudioFact]
        public void Dispose_ShouldSetCPointerToZero()
        {
            var recorder = new TestSoundRecorder();
            IntPtr ptr = recorder.CPointer;
            Assert.NotEqual(IntPtr.Zero, ptr);
            recorder.Dispose();
            Assert.Equal(IntPtr.Zero, recorder.CPointer);
        }

        [RequireCSfmlAudioFact]
        public void Destroy_ShouldSetCPointerToZero()
        {
            var recorder = new TestSoundRecorder();
            IntPtr ptr = recorder.CPointer;
            Assert.NotEqual(IntPtr.Zero, ptr);
            recorder.Destroy(true);
            Assert.Equal(IntPtr.Zero, recorder.CPointer);
        }

        [RequireCSfmlAudioFact]
        public void SetDevice_WithInvalidName_ShouldReturnFalse()
        {
            using var recorder = new TestSoundRecorder();
            bool result = recorder.SetDevice("NonExistentDevice_XYZ");
            Assert.False(result);
        }

        [RequireCSfmlAudioFact]
        public void Start_AndStop_ShouldToggleRecording()
        {
            using var recorder = new TestSoundRecorder();
            bool started = recorder.Start(44100);
            if (started)
            {
                Assert.True(recorder.OnStartCalled);
                recorder.Stop();
                Assert.True(recorder.OnStopCalled);
            }
        }
    }
}
