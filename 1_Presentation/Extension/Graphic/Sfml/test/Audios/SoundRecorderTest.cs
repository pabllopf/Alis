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
    /// <summary>
    /// The test sound recorder class
    /// </summary>
    /// <seealso cref="Alis.Extension.Graphic.Sfml.Audios.SoundRecorder"/>
    public sealed class TestSoundRecorder : Alis.Extension.Graphic.Sfml.Audios.SoundRecorder
    {
        /// <summary>
        /// Gets or sets the value of the on start called
        /// </summary>
        public bool OnStartCalled { get; private set; }

        /// <summary>
        /// Gets or sets the value of the on stop called
        /// </summary>
        public bool OnStopCalled { get; private set; }

        /// <summary>
        /// Gets or sets the value of the processed samples
        /// </summary>
        public short[] ProcessedSamples { get; private set; }

        /// <summary>
        /// Gets or sets the value of the process result
        /// </summary>
        public bool ProcessResult { get; set; } = true;

        /// <summary>
        /// Ons the start
        /// </summary>
        /// <returns>The bool</returns>
        public override bool OnStart()
        {
            OnStartCalled = true;
            return base.OnStart();
        }

        /// <summary>
        /// Ons the process samples using the specified samples
        /// </summary>
        /// <param name="samples">The samples</param>
        /// <returns>The process result</returns>
        public override bool OnProcessSamples(short[] samples)
        {
            ProcessedSamples = samples;
            return ProcessResult;
        }

        /// <summary>
        /// Ons the stop
        /// </summary>
        public override void OnStop()
        {
            OnStopCalled = true;
            base.OnStop();
        }

        /// <summary>
        /// Exposes the set processing interval using the specified interval
        /// </summary>
        /// <param name="interval">The interval</param>
        public void ExposeSetProcessingInterval(SfmlTime interval) => SetProcessingInterval(interval);

        /// <summary>
        /// Gets the value of the c pointer
        /// </summary>
        public new IntPtr CPointer => base.CPointer;
    }

    /// <summary>
    /// The sound recorder test class
    /// </summary>
    public class SoundRecorderTest
    {
        /// <summary>
        /// Constructors the should set c pointer to non zero
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Constructor_ShouldSetCPointerToNonZero()
        {
            using var recorder = new TestSoundRecorder();
            Assert.NotEqual(IntPtr.Zero, recorder.CPointer);
        }

        /// <summary>
        /// Ises the available should return bool
        /// </summary>
        [RequireCSfmlAudioFact]
        public void IsAvailable_ShouldReturnBool()
        {
            Assert.IsType<bool>(Alis.Extension.Graphic.Sfml.Audios.SoundRecorder.IsAvailable);
        }

        /// <summary>
        /// Availables the devices should return array
        /// </summary>
        [RequireCSfmlAudioFact]
        public void AvailableDevices_ShouldReturnArray()
        {
            string[] devices = Alis.Extension.Graphic.Sfml.Audios.SoundRecorder.AvailableDevices;
            Assert.NotNull(devices);
        }

        /// <summary>
        /// Defaults the device should return string
        /// </summary>
        [RequireCSfmlAudioFact]
        public void DefaultDevice_ShouldReturnString()
        {
            string device = Alis.Extension.Graphic.Sfml.Audios.SoundRecorder.DefaultDevice;
            Assert.NotNull(device);
            Assert.NotEqual(string.Empty, device);
        }

        /// <summary>
        /// Samples the rate should return value
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SampleRate_ShouldReturnValue()
        {
            using var recorder = new TestSoundRecorder();
            Assert.True(recorder.SampleRate > 0);
        }

        /// <summary>
        /// Channels the count default should be one
        /// </summary>
        [RequireCSfmlAudioFact]
        public void ChannelCount_Default_ShouldBeOne()
        {
            using var recorder = new TestSoundRecorder();
            Assert.Equal(1u, recorder.ChannelCount);
        }

        /// <summary>
        /// Channels the count set should reflect change
        /// </summary>
        [RequireCSfmlAudioFact]
        public void ChannelCount_Set_ShouldReflectChange()
        {
            using var recorder = new TestSoundRecorder();
            recorder.ChannelCount = 2u;
            Assert.Equal(2u, recorder.ChannelCount);
        }

        /// <summary>
        /// Returns the string should contain sound recorder
        /// </summary>
        [RequireCSfmlAudioFact]
        public void ToString_ShouldContainSoundRecorder()
        {
            using var recorder = new TestSoundRecorder();
            Assert.Contains("[SoundRecorder]", recorder.ToString());
        }

        /// <summary>
        /// Returns the string should contain sample rate
        /// </summary>
        [RequireCSfmlAudioFact]
        public void ToString_ShouldContainSampleRate()
        {
            using var recorder = new TestSoundRecorder();
            Assert.Contains("SampleRate(", recorder.ToString());
        }

        /// <summary>
        /// Starts the default should return bool
        /// </summary>
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

        /// <summary>
        /// Starts the with sample rate should return bool
        /// </summary>
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

        /// <summary>
        /// Stops the should not throw
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Stop_ShouldNotThrow()
        {
            using var recorder = new TestSoundRecorder();
            recorder.Stop();
        }

        /// <summary>
        /// Sets the processing interval throws entry point not found
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SetProcessingInterval_ThrowsEntryPointNotFound()
        {
            using var recorder = new TestSoundRecorder();
            Assert.Throws<EntryPointNotFoundException>(() => recorder.ExposeSetProcessingInterval(SfmlTime.FromMilliseconds(50)));
        }

        /// <summary>
        /// Sets the device with default device should return true
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SetDevice_WithDefaultDevice_ShouldReturnTrue()
        {
            using var recorder = new TestSoundRecorder();
            string defaultDevice = Alis.Extension.Graphic.Sfml.Audios.SoundRecorder.DefaultDevice;
            bool result = recorder.SetDevice(defaultDevice);
            Assert.True(result);
        }

        /// <summary>
        /// Gets the device should return string
        /// </summary>
        [RequireCSfmlAudioFact]
        public void GetDevice_ShouldReturnString()
        {
            using var recorder = new TestSoundRecorder();
            string device = recorder.GetDevice();
            Assert.NotNull(device);
            Assert.NotEqual(string.Empty, device);
        }

        /// <summary>
        /// Classes the should be abstract
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Class_ShouldBeAbstract()
        {
            Assert.True(typeof(Alis.Extension.Graphic.Sfml.Audios.SoundRecorder).IsAbstract);
        }

        /// <summary>
        /// Classes the should inherit from object base
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Class_ShouldInheritFromObjectBase()
        {
            Assert.Equal("ObjectBase", typeof(Alis.Extension.Graphic.Sfml.Audios.SoundRecorder).BaseType.Name);
        }

        /// <summary>
        /// Disposes the should set c pointer to zero
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Dispose_ShouldSetCPointerToZero()
        {
            var recorder = new TestSoundRecorder();
            IntPtr ptr = recorder.CPointer;
            Assert.NotEqual(IntPtr.Zero, ptr);
            recorder.Dispose();
            Assert.Equal(IntPtr.Zero, recorder.CPointer);
        }

        /// <summary>
        /// Destroys the should set c pointer to zero
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Destroy_ShouldSetCPointerToZero()
        {
            var recorder = new TestSoundRecorder();
            IntPtr ptr = recorder.CPointer;
            Assert.NotEqual(IntPtr.Zero, ptr);
            recorder.Destroy(true);
            Assert.Equal(IntPtr.Zero, recorder.CPointer);
        }

        /// <summary>
        /// Sets the device with invalid name should return false
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SetDevice_WithInvalidName_ShouldReturnFalse()
        {
            using var recorder = new TestSoundRecorder();
            bool result = recorder.SetDevice("NonExistentDevice_XYZ");
            Assert.False(result);
        }

        /// <summary>
        /// Starts the and stop should toggle recording
        /// </summary>
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
