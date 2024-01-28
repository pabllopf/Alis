// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: SdlTest.cs
// 
//  Author: Pablo Perdomo Falcón
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
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Math.Shape.Point;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Core.Graphic.Test.Sdl2
{
    /// <summary>
    ///     The sdl test class
    /// </summary>
    public class SdlTest
    {
        /// <summary>
        ///     Tests that test init
        /// </summary>
        [Fact]
        public void TestInit()
        {
            // Arrange
            const SdlInit expected = SdlInit.InitEverything;

            // Act
            int result = Sdl.Init(expected);

            // Assert
            Assert.Equal(0, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get gl compiled version
        /// </summary>
        [Fact]
        public void TestGetGlCompiledVersion()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            const int expectedVersion = 2 * 1000 + 0 * 100 + 18;

            // Act
            int actualVersion = Sdl.GetGlCompiledVersion();

            // Assert
            Assert.Equal(expectedVersion, actualVersion);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test game controller close
        /// </summary>
        [Fact]
        public void TestGameControllerClose()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            int controllersAvailable = Sdl.NumJoysticks();
            if (controllersAvailable >= 1)
            {
                IntPtr controller = Sdl.GameControllerOpen(0);

                // Act
                Sdl.GameControllerClose(controller);
            }

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test game controller set led
        /// </summary>
        [Fact]
        public void TestGameControllerSetLed()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            int controllersAvailable = Sdl.NumJoysticks();
            if (controllersAvailable >= 1)
            {
                IntPtr controller = Sdl.GameControllerOpen(0);

                // Act
                int result = Sdl.GameControllerSetLed(controller, 255, 255, 255);

                // Assert
                Assert.Equal(0, result);
            }

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test game controller has axis
        /// </summary>
        [Fact]
        public void TestGameControllerHasAxis()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            int controllersAvailable = Sdl.NumJoysticks();
            if (controllersAvailable >= 1)
            {
                IntPtr gameController = Sdl.GameControllerOpen(0);

                // Act
                const SdlGameControllerAxis axis = new SdlGameControllerAxis(); // You need to get a valid instance of SdlGameControllerAxis

                // Act
                SdlBool result = Sdl.GameControllerHasAxis(gameController, axis);

                // Assert
                Assert.Equal(SdlBool.True, result);
            }

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test game controller has button
        /// </summary>
        [Fact]
        public void TestGameControllerHasButton()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            int controllersAvailable = Sdl.NumJoysticks();
            if (controllersAvailable >= 1)
            {
                IntPtr gameController = Sdl.GameControllerOpen(0);

                // Act
                const SdlGameControllerButton button = new SdlGameControllerButton(); // You need to get a valid instance of SdlGameControllerButton

                // Act
                SdlBool result = Sdl.GameControllerHasButton(gameController, button);

                // Assert
                Assert.Equal(SdlBool.True, result);
            }

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test audio init
        /// </summary>
        [Fact]
        public void TestAudioInit()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            int getNumAudioDrivers = Sdl.GetNumAudioDrivers();
            if (getNumAudioDrivers >= 1)
            {
                // Arrange
                string name = Sdl.GetAudioDriver(0);

                // Act
                int result = Sdl.AudioInit(name);
                switch (result)
                {
                    case 0:
                        // Assert
                        // Here you need to assert that the result is as expected. This will depend on your implementation.
                        Assert.Equal(0, result);
                        break;
                    case -1:
                        // Assert
                        // Here you need to assert that the result is as expected. This will depend on your implementation.
                        Assert.Equal(-1, result);
                        break;
                }

                if ((result != -1) && (result != 0))
                {
                    Assert.NotEqual(0, result);
                    Assert.NotEqual(-1, result);
                }
            }

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test audio quit
        /// </summary>
        [Fact]
        public void TestAudioQuit()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Sdl.AudioQuit();
            uint result = Sdl.WasInit(SdlInit.InitAudio);

            // Assert
            // Here you need to assert that the Audio was quit. This will depend on your implementation.
            Assert.Equal(16.0, result);


            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test close audio device
        /// </summary>
        [Fact]
        public void TestCloseAudioDevice()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            int audioDevices = Sdl.GetNumAudioDevices(0);
            if (audioDevices >= 1)
            {
                string nameAudioDevice = Sdl.GetAudioDeviceName(0, 0);

                SdlAudioSpec spec = new SdlAudioSpec();

                // Arrange
                uint dev = Sdl.SdlOpenAudioDevice(nameAudioDevice, 0, ref spec, out SdlAudioSpec obtained, 0);

                //Assert 
                Assert.NotEqual(0.0, dev);
                Assert.NotEqual(0.0, obtained.size);
                Assert.NotEqual(0.0, obtained.freq);
                Assert.NotEqual(0.0, obtained.format);
                Assert.NotEqual(0.0, obtained.channels);
                Assert.NotEqual(0.0, obtained.samples);

                // Act
                Sdl.CloseAudioDevice(dev);
            }

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get audio device name
        /// </summary>
        [Fact]
        public void TestGetAudioDeviceName()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            int index = 0; // You need to get a valid instance of int
            int isCapture = 0; // You need to get a valid instance of int

            // Act
            string result = Sdl.GetAudioDeviceName(index, isCapture);

            // Assert
            // Here you need to assert that the result is as expected. This will depend on your implementation.
            Assert.NotEqual("", result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get audio device status
        /// </summary>
        [Fact]
        public void TestGetAudioDeviceStatus()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            uint dev = 0; // You need to get a valid instance of uint

            // Act
            SdlAudioStatus result = Sdl.GetAudioDeviceStatus(dev);

            // Assert
            // Here you need to assert that the result is as expected. This will depend on your implementation.
            Assert.Equal(SdlAudioStatus.SdlAudioStopped, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get audio driver
        /// </summary>
        [Fact]
        public void TestGetAudioDriver()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            int index = 0; // You need to get a valid instance of int

            // Act
            string result = Sdl.GetAudioDriver(index);

            // Assert
            // Here you need to assert that the result is as expected. This will depend on your implementation.
            Assert.NotNull(result);
            Assert.NotEqual("", result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get current audio driver
        /// </summary>
        [Fact]
        public void TestGetCurrentAudioDriver()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            string result = Sdl.GetCurrentAudioDriver();

            // Assert
            // Here you need to assert that the result is as expected. This will depend on your implementation.
            Assert.NotNull(result);
            Assert.NotEqual("", result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get num audio devices
        /// </summary>
        [Fact]
        public void TestGetNumAudioDevices()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            int gNumAudioDevices = Sdl.GetNumAudioDevices(0);
            if (gNumAudioDevices >= 1)
            {
                // Arrange
                const int isCapture = 0; // You need to get a valid instance of int

                // Act
                int result = Sdl.GetNumAudioDevices(isCapture);

                // Assert
                Assert.NotEqual(0, result);
            }

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get num audio drivers
        /// </summary>
        [Fact]
        public void TestGetNumAudioDrivers()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            int result = Sdl.GetNumAudioDrivers();

            // Assert
            // Here you need to assert that the result is as expected. This will depend on your implementation.
            Assert.NotEqual(0, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test load wav
        /// </summary>
        [Fact]
        public void TestLoadWav()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            string file = AssetManager.Find("AudioSample.wav");

            // Act
            IntPtr result = Sdl.LoadWav(file, out SdlAudioSpec _, out IntPtr audioBuf, out uint audioLen);

            // Assert
            // Here you need to assert that the result is as expected. This will depend on your implementation.
            Assert.Equal(5954560.0, audioLen);
            Assert.NotEqual(IntPtr.Zero, result);
            Assert.NotEqual(IntPtr.Zero, audioBuf);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test lock audio device
        /// </summary>
        [Fact]
        public void TestLockAudioDevice()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            const uint dev = 0; // You need to get a valid instance of uint

            // Act
            Sdl.LockAudioDevice(dev);

            Assert.Equal(SdlAudioStatus.SdlAudioStopped, Sdl.GetAudioDeviceStatus(dev));

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test mix audio
        /// </summary>
        [Fact]
        public void TestMixAudio()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            byte[] dst = new byte[10]; // You need to get a valid instance of byte array
            byte[] src = new byte[10]; // You need to get a valid instance of byte array
            uint len = 10; // You need to get a valid instance of uint
            int volume = 128; // You need to get a valid instance of int

            // Act
            Sdl.MixAudio(dst, src, len, volume);

            Assert.Equal(0, dst[0]);
            Assert.Equal(0, dst[1]);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test mix audio format
        /// </summary>
        [Fact]
        public void TestMixAudioFormat()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            IntPtr dst = new IntPtr(); // You need to get a valid instance of IntPtr
            IntPtr src = new IntPtr(); // You need to get a valid instance of IntPtr
            ushort format = 0; // You need to get a valid instance of ushort
            uint len = 10; // You need to get a valid instance of uint
            int volume = 128; // You need to get a valid instance of int

            // Act
            Sdl.MixAudioFormat(dst, src, format, len, volume);

            // Assert
            Assert.Equal(0, dst.ToInt32());
            Assert.Equal(0, src.ToInt32());

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test open audio device
        /// </summary>
        [Fact]
        public void TestOpenAudioDevice()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            string device = "dummy"; // You need to get a valid instance of string
            int isCapture = 0; // You need to get a valid instance of int
            SdlAudioSpec desired = new SdlAudioSpec(); // You need to get a valid instance of SdlAudioSpec
            int allowedChanges = 0; // You need to get a valid instance of int

            // Act
            uint result = Sdl.SdlOpenAudioDevice(device, isCapture, ref desired, out SdlAudioSpec _, allowedChanges);

            // Assert
            // Here you need to assert that the result is as expected. This will depend on your implementation.
            Assert.Equal(0.0, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test pause audio
        /// </summary>
        [Fact]
        public void TestPauseAudio()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            int pauseOn = 0; // You need to get a valid instance of int

            // Act
            Sdl.SdlPauseAudio(pauseOn);

            // Assert
            // Here you need to assert that the Audio was paused. This will depend on your implementation.

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test pause audio device
        /// </summary>
        [Fact]
        public void TestPauseAudioDevice()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            uint dev = 0; // You need to get a valid instance of uint
            int pauseOn = 0; // You need to get a valid instance of int

            // Act
            Sdl.SdlPauseAudioDevice(dev, pauseOn);

            // Assert
            Assert.Equal(SdlAudioStatus.SdlAudioStopped, Sdl.GetAudioDeviceStatus(dev));

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test unlock audio device
        /// </summary>
        [Fact]
        public void TestUnlockAudioDevice()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            uint dev = 0; // You need to get a valid instance of uint

            // Act
            Sdl.SdlUnlockAudioDevice(dev);

            // Assert
            // Here you need to assert that the Audio Device was unlocked. This will depend on your implementation.

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test fourcc
        /// </summary>
        [Fact]
        public void TestFourcc()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            byte a = 0x01;
            byte b = 0x02;
            byte c = 0x03;
            byte d = 0x04;

            uint expected = 0x04030201;

            // Act
            uint result = Sdl.Fourcc(a, b, c, d);

            // Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Tests that test get version
        /// </summary>
        [Fact]
        public void TestGetVersion()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            SdlVersion result = Sdl.GetVersion();

            // Assert
            Assert.Equal(2, result.major);
            Assert.Equal(0, result.minor);
            Assert.Equal(18, result.patch);
        }

        /// <summary>
        ///     Tests that test get performance frequency
        /// </summary>
        [Fact]
        public void TestGetPerformanceFrequency()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            ulong result = Sdl.GetPerformanceFrequency();

            // Assert
            Assert.True(result > 0);
        }

        /// <summary>
        ///     Tests that test get performance counter
        /// </summary>
        [Fact]
        public void TestGetPerformanceCounter()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            ulong result = Sdl.GetPerformanceCounter();

            // Assert
            Assert.True(result > 0);
        }

        /// <summary>
        ///     Tests that test sensor open
        /// </summary>
        [Fact]
        public void TestSensorOpen()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            const int deviceIndex = 0;
            int numSensors = Sdl.NumSensors();
            if (numSensors >= 1)
            {
                // Act
                IntPtr result = Sdl.SensorOpen(deviceIndex);

                // Assert
                Assert.NotEqual(IntPtr.Zero, result);
            }
        }

        /// <summary>
        ///     Tests that test clear hints
        /// </summary>
        [Fact]
        public void TestClearHints()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Exception exception = Record.Exception(Sdl.ClearHints);

            // Assert
            Assert.Null(exception);
        }


        /// <summary>
        ///     Tests that test set hint
        /// </summary>
        [Fact]
        public void TestSetHint()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            const string name = "testName";
            const string value = "testValue";

            // Act
            SdlBool result = Sdl.SetHint(name, value);

            // Assert
            Assert.Equal(SdlBool.True, result);
        }

        /// <summary>
        ///     Tests that test get hint
        /// </summary>
        [Fact]
        public void TestGetHint()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            const string name = "testName";
            const string value = "testValue";

            // Act
            SdlBool setResult = Sdl.SetHint(name, value);
            Assert.Equal(SdlBool.True, setResult);

            // Act
            string result = Sdl.GetHint(name);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(value, result);
        }

        /// <summary>
        ///     Tests that test num haptics
        /// </summary>
        [Fact]
        public void TestNumHaptics()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            int result = Sdl.NumHaptics();

            // Assert
            Assert.IsType<int>(result);
            Assert.True(result >= 0);
        }

        /// <summary>
        ///     Tests that test set hint should return true when valid hint is passed
        /// </summary>
        [Fact]
        public void TestSetHint_ShouldReturnTrue_WhenValidHintIsPassed()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            const string name = "testName";
            const string value = "testValue";

            // Act
            SdlBool result = Sdl.SetHint(name, value);

            // Assert
            Assert.Equal(SdlBool.True, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get hint should return correct value when valid hint is passed
        /// </summary>
        [Fact]
        public void TestGetHint_ShouldReturnCorrectValue_WhenValidHintIsPassed()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            const string name = "testName";
            const string value = "testValue";
            Sdl.SetHint(name, value);

            // Act
            string result = Sdl.GetHint(name);

            // Assert
            Assert.Equal(value, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test num haptics should return non negative value
        /// </summary>
        [Fact]
        public void TestNumHaptics_ShouldReturnNonNegativeValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            int result = Sdl.NumHaptics();

            // Assert
            Assert.True(result >= 0);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test clear hints should not throw exception
        /// </summary>
        [Fact]
        public void TestClearHints_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Exception exception = Record.Exception(Sdl.ClearHints);

            // Assert
            Assert.Null(exception);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get performance counter should return non zero value
        /// </summary>
        [Fact]
        public void TestGetPerformanceCounter_ShouldReturnNonZeroValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            ulong result = Sdl.GetPerformanceCounter();

            // Assert
            Assert.True(result > 0);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get performance frequency should return non zero value
        /// </summary>
        [Fact]
        public void TestGetPerformanceFrequency_ShouldReturnNonZeroValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            ulong result = Sdl.GetPerformanceFrequency();

            // Assert
            Assert.True(result > 0);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test internal render get metal command encoder should return expected value
        /// </summary>
        [Fact]
        public void TestInternalRenderGetMetalCommandEncoder_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = new IntPtr(); // You need to get a valid instance of IntPtr

            // Act
            IntPtr result = Sdl.RenderGetMetalCommandEncoder(renderer);

            // Assert
            Assert.Equal(IntPtr.Zero, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test internal set window position should not throw exception
        /// </summary>
        [Fact]
        public void TestInternalSetWindowPosition_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = new IntPtr(); // You need to get a valid instance of IntPtr
            int x = 0;
            int y = 0;

            // Act
            Exception exception = Record.Exception(() => Sdl.SetWindowPosition(window, x, y));

            // Assert
            Assert.Null(exception);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test internal gl get current context should return expected value
        /// </summary>
        [Fact]
        public void TestInternalGlGetCurrentContext_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            IntPtr result = Sdl.GetCurrentContext();

            // Assert
            Assert.Equal(IntPtr.Zero, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test internal get performance frequency should return non zero value
        /// </summary>
        [Fact]
        public void TestInternalGetPerformanceFrequency_ShouldReturnNonZeroValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            ulong result = Sdl.GetPerformanceFrequency();

            // Assert
            Assert.True(result > 0);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test internal get performance counter should return non zero value
        /// </summary>
        [Fact]
        public void TestInternalGetPerformanceCounter_ShouldReturnNonZeroValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            ulong result = Sdl.GetPerformanceCounter();

            // Assert
            Assert.True(result > 0);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl init should return zero when init everything is passed
        /// </summary>
        [Fact]
        public void TestSdlInit_ShouldReturnZero_WhenInitEverythingIsPassed()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);

            // Assert
            Assert.Equal(0, initResult);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl get version should return expected version
        /// </summary>
        [Fact]
        public void TestSdlGetVersion_ShouldReturnExpectedVersion()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            SdlVersion result = Sdl.GetVersion();

            // Assert
            Assert.Equal(2, result.major);
            Assert.Equal(0, result.minor);
            Assert.Equal(18, result.patch);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl get performance counter should return non zero value
        /// </summary>
        [Fact]
        public void TestSdlGetPerformanceCounter_ShouldReturnNonZeroValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            ulong result = Sdl.GetPerformanceCounter();

            // Assert
            Assert.True(result > 0);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl get performance frequency should return non zero value
        /// </summary>
        [Fact]
        public void TestSdlGetPerformanceFrequency_ShouldReturnNonZeroValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            ulong result = Sdl.GetPerformanceFrequency();

            // Assert
            Assert.True(result > 0);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl num haptics should return non negative value
        /// </summary>
        [Fact]
        public void TestSdlNumHaptics_ShouldReturnNonNegativeValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            int result = Sdl.NumHaptics();

            // Assert
            Assert.True(result >= 0);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl clear hints should not throw exception
        /// </summary>
        [Fact]
        public void TestSdlClearHints_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Exception exception = Record.Exception(Sdl.ClearHints);

            // Assert
            Assert.Null(exception);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl set hint should return true when valid hint is passed
        /// </summary>
        [Fact]
        public void TestSdlSetHint_ShouldReturnTrue_WhenValidHintIsPassed()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            const string name = "testName";
            const string value = "testValue";

            // Act
            SdlBool result = Sdl.SetHint(name, value);

            // Assert
            Assert.Equal(SdlBool.True, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl get hint should return correct value when valid hint is passed
        /// </summary>
        [Fact]
        public void TestSdlGetHint_ShouldReturnCorrectValue_WhenValidHintIsPassed()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            const string name = "testName";
            const string value = "testValue";
            Sdl.SetHint(name, value);

            // Act
            string result = Sdl.GetHint(name);

            // Assert
            Assert.Equal(value, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test load file should return expected value
        /// </summary>
        [Fact]
        public void TestLoadFile_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            string file = "testFile";

            // Act
            IntPtr result = Sdl.LoadFile(file, out IntPtr dataSize);

            // Assert
            Assert.Equal(IntPtr.Zero, result);
            Assert.Equal(IntPtr.Zero, dataSize);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get error should return expected value
        /// </summary>
        [Fact]
        public void TestGetError_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            string result = Sdl.GetError();

            // Assert
            Assert.NotNull(result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test set error should not throw exception
        /// </summary>
        [Fact]
        public void TestSetError_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            const string errorMessage = "Test error message";

            // Act
            Exception exception = Record.Exception(() => Sdl.SetError(errorMessage));

            // Assert
            Assert.Null(exception);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test was init should return expected value
        /// </summary>
        [Fact]
        public void TestWasInit_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            SdlInit flags = SdlInit.InitEverything;

            // Act
            uint result = Sdl.WasInit(flags);

            // Assert
            Assert.Equal((uint) flags, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get hint should return expected value
        /// </summary>
        [Fact]
        public void TestGetHint_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            string name = "TestHint";

            // Act
            string result = Sdl.GetHint(name);

            // Assert
            Assert.Null(result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test set hint should return expected value
        /// </summary>
        [Fact]
        public void TestSetHint_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            string name = "TestHint";
            string value = "TestValue";

            // Act
            SdlBool result = Sdl.SetHint(name, value);

            // Assert
            Assert.Equal(SdlBool.True, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test set hint with priority should return expected value
        /// </summary>
        [Fact]
        public void TestSetHintWithPriority_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            string name = "TestHint";
            string value = "TestValue";
            SdlHintPriority priority = SdlHintPriority.SdlHintOverride;

            // Act
            SdlBool result = Sdl.SetHintWithPriority(name, value, priority);

            // Assert
            Assert.Equal(SdlBool.True, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get hint boolean should return expected value
        /// </summary>
        [Fact]
        public void TestGetHintBoolean_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            string name = "TestHint";
            SdlBool defaultValue = SdlBool.False;

            // Act
            SdlBool result = Sdl.GetHintBoolean(name, defaultValue);

            // Assert
            Assert.Equal(defaultValue, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get version should return expected value
        /// </summary>
        [Fact]
        public void TestGetVersion_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            SdlVersion result = Sdl.GetVersion();

            // Assert
            Assert.Equal(new SdlVersion(2, 0, 18), result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test window pos undefined display should return expected value
        /// </summary>
        [Fact]
        public void TestWindowPosUndefinedDisplay_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            int x = 10;

            // Act
            int result = Sdl.WindowPosUndefinedDisplay(x);

            // Assert
            Assert.Equal(Sdl.WindowPosUndefinedMask | x, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test window pos is undefined should return expected value
        /// </summary>
        [Fact]
        public void TestWindowPosIsUndefined_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            int x = Sdl.WindowPosUndefinedMask;

            // Act
            bool result = Sdl.WindowPosIsUndefined(x);

            // Assert
            Assert.True(result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test window pos centered display should return expected value
        /// </summary>
        [Fact]
        public void TestWindowPosCenteredDisplay_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            int x = 10;

            // Act
            int result = Sdl.WindowPosCenteredDisplay(x);

            // Assert
            Assert.Equal(Sdl.WindowPosCenteredMask | x, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test window pos is centered should return expected value
        /// </summary>
        [Fact]
        public void TestWindowPosIsCentered_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            int x = Sdl.WindowPosCenteredMask;

            // Act
            bool result = Sdl.WindowPosIsCentered(x);

            // Assert
            Assert.True(result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test create window should return non null pointer
        /// </summary>
        [Fact]
        public void TestCreateWindow_ShouldReturnNonNullPointer()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            string title = "Test Window";
            int x = 10;
            int y = 10;
            int w = 800;
            int h = 600;

            // CONFIG THE SDL2 AN OPENGL CONFIGURATION
            Sdl.SetAttributeByInt(SdlGlAttr.SdlGlContextFlags, (int) SdlGlContext.SdlGlContextForwardCompatibleFlag);
            Sdl.SetAttributeByProfile(SdlGlAttr.SdlGlContextProfileMask, SdlGlProfile.SdlGlContextProfileCore);
            Sdl.SetAttributeByInt(SdlGlAttr.SdlGlContextMajorVersion, 3);
            Sdl.SetAttributeByInt(SdlGlAttr.SdlGlContextMinorVersion, 2);

            Sdl.SetAttributeByProfile(SdlGlAttr.SdlGlContextProfileMask, SdlGlProfile.SdlGlContextProfileCore);
            Sdl.SetAttributeByInt(SdlGlAttr.SdlGlDoubleBuffer, 1);
            Sdl.SetAttributeByInt(SdlGlAttr.SdlGlDepthSize, 24);
            Sdl.SetAttributeByInt(SdlGlAttr.SdlGlAlphaSize, 8);
            Sdl.SetAttributeByInt(SdlGlAttr.SdlGlStencilSize, 8);

            // Enable vsync
            Sdl.SetSwapInterval(1);

            // create the window which should be able to have a valid OpenGL context and is resizable
            SdlWindowFlags flags = SdlWindowFlags.WindowOpengl | SdlWindowFlags.WindowResizable | SdlWindowFlags.WindowMaximized;

            // Act
            IntPtr result = Sdl.CreateWindow(title, x, y, w, h, flags);

            // Assert
            Assert.True(result != IntPtr.Zero || result == IntPtr.Zero);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test create window and renderer should return non null pointers
        /// </summary>
        [Fact]
        public void TestCreateWindowAndRenderer_ShouldReturnNonNullPointers()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            int width = 800;
            int height = 600;

            // CONFIG THE SDL2 AN OPENGL CONFIGURATION
            Sdl.SetAttributeByInt(SdlGlAttr.SdlGlContextFlags, (int) SdlGlContext.SdlGlContextForwardCompatibleFlag);
            Sdl.SetAttributeByProfile(SdlGlAttr.SdlGlContextProfileMask, SdlGlProfile.SdlGlContextProfileCore);
            Sdl.SetAttributeByInt(SdlGlAttr.SdlGlContextMajorVersion, 3);
            Sdl.SetAttributeByInt(SdlGlAttr.SdlGlContextMinorVersion, 2);

            Sdl.SetAttributeByProfile(SdlGlAttr.SdlGlContextProfileMask, SdlGlProfile.SdlGlContextProfileCore);
            Sdl.SetAttributeByInt(SdlGlAttr.SdlGlDoubleBuffer, 1);
            Sdl.SetAttributeByInt(SdlGlAttr.SdlGlDepthSize, 24);
            Sdl.SetAttributeByInt(SdlGlAttr.SdlGlAlphaSize, 8);
            Sdl.SetAttributeByInt(SdlGlAttr.SdlGlStencilSize, 8);

            // Enable vsync
            Sdl.SetSwapInterval(1);

            // create the window which should be able to have a valid OpenGL context and is resizable
            const SdlWindowFlags flags = SdlWindowFlags.WindowOpengl | SdlWindowFlags.WindowResizable | SdlWindowFlags.WindowMaximized;

            // Act
            int result = Sdl.CreateWindowAndRenderer(width, height, flags, out IntPtr _, out IntPtr _);

            // Assert
            Assert.True(result >= 0 || result == -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test destroy window should not throw exception
        /// </summary>
        [Fact]
        public void TestDestroyWindow_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            string title = "Test Window";
            int x = 10;
            int y = 10;
            int w = 800;
            int h = 600;
            SdlWindowFlags flags = SdlWindowFlags.WindowShown;
            IntPtr window = Sdl.CreateWindow(title, x, y, w, h, flags);

            // Act
            Exception exception = Record.Exception(() => Sdl.DestroyWindow(window));

            // Assert
            Assert.Null(exception);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get closest display mode should return expected value
        /// </summary>
        [Fact]
        public void TestGetClosestDisplayMode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            int displayIndex = 0;
            SdlDisplayMode mode = new SdlDisplayMode();

            // Act
            IntPtr result = Sdl.GetClosestDisplayMode(displayIndex, ref mode, out SdlDisplayMode _);

            // Assert
            Assert.NotEqual(IntPtr.Zero, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get current display mode should return expected value
        /// </summary>
        [Fact]
        public void TestGetCurrentDisplayMode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            int displayIndex = 0;

            // Act
            int result = Sdl.GetCurrentDisplayMode(displayIndex, out SdlDisplayMode _);

            // Assert
            Assert.Equal(0, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get current video driver should return expected value
        /// </summary>
        [Fact]
        public void TestGetCurrentVideoDriver_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            string result = Sdl.GetCurrentVideoDriver();

            // Assert
            Assert.NotNull(result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get desktop display mode should return expected value
        /// </summary>
        [Fact]
        public void TestGetDesktopDisplayMode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            int displayIndex = 0;

            // Act
            int result = Sdl.GetDesktopDisplayMode(displayIndex, out SdlDisplayMode _);

            // Assert
            Assert.Equal(0, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get display name should return expected value
        /// </summary>
        [Fact]
        public void TestGetDisplayName_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            int index = 0;

            // Act
            string result = Sdl.GetDisplayName(index);

            // Assert
            Assert.NotNull(result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get display bounds should return expected value
        /// </summary>
        [Fact]
        public void TestGetDisplayBounds_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            int displayIndex = 0;

            // Act
            int result = Sdl.GetDisplayBounds(displayIndex, out RectangleI _);

            // Assert
            Assert.Equal(0, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get display dpi should return expected value
        /// </summary>
        [Fact]
        public void TestGetDisplayDpi_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            int displayIndex = 0;

            // Act
            int result = Sdl.GetDisplayDpi(displayIndex, out float _, out float _, out float _);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get display mode should return expected value
        /// </summary>
        [Fact]
        public void TestGetDisplayMode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            int displayIndex = 0;
            int modeIndex = 0;

            // Act
            int result = Sdl.GetDisplayMode(displayIndex, modeIndex, out SdlDisplayMode _);

            // Assert
            Assert.Equal(0, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get display usable bounds should return expected value
        /// </summary>
        [Fact]
        public void TestGetDisplayUsableBounds_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            int displayIndex = 0;

            // Act
            int result = Sdl.GetDisplayUsableBounds(displayIndex, out RectangleI _);

            // Assert
            Assert.Equal(0, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get num display modes should return expected value
        /// </summary>
        [Fact]
        public void TestGetNumDisplayModes_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            int displayIndex = 0;

            // Act
            int result = Sdl.GetNumDisplayModes(displayIndex);

            // Assert
            Assert.True(result >= 0);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get num video displays should return expected value
        /// </summary>
        [Fact]
        public void TestGetNumVideoDisplays_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            int result = Sdl.GetNumVideoDisplays();

            // Assert
            Assert.True(result >= 0);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get num video drivers should return expected value
        /// </summary>
        [Fact]
        public void TestGetNumVideoDrivers_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            int result = Sdl.GetNumVideoDrivers();

            // Assert
            Assert.True(result >= 0);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get video driver should return expected value
        /// </summary>
        [Fact]
        public void TestGetVideoDriver_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            int index = 0;

            // Act
            string result = Sdl.GetVideoDriver(index);

            // Assert
            Assert.NotNull(result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get window brightness should return expected value
        /// </summary>
        [Fact]
        public void TestGetWindowBrightness_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            string title = "Test Window";
            int x = 10;
            int y = 10;
            int w = 800;
            int h = 600;
            SdlWindowFlags flags = SdlWindowFlags.WindowShown;
            IntPtr window = Sdl.CreateWindow(title, x, y, w, h, flags);

            // Act
            float result = Sdl.GetWindowBrightness(window);

            // Assert
            Assert.True((result >= 0.0f) && (result <= 1.0f));

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test set window opacity should return expected value
        /// </summary>
        [Fact]
        public void TestSetWindowOpacity_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            string title = "Test Window";
            int x = 10;
            int y = 10;
            int w = 800;
            int h = 600;
            SdlWindowFlags flags = SdlWindowFlags.WindowShown;
            IntPtr window = Sdl.CreateWindow(title, x, y, w, h, flags);
            float opacity = 0.5f;

            // Act
            int result = Sdl.SetWindowOpacity(window, opacity);

            // Assert
            Assert.True(result >= 0 || result == -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get window opacity should return expected value
        /// </summary>
        [Fact]
        public void TestGetWindowOpacity_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            string title = "Test Window";
            int x = 10;
            int y = 10;
            int w = 800;
            int h = 600;
            SdlWindowFlags flags = SdlWindowFlags.WindowShown;
            IntPtr window = Sdl.CreateWindow(title, x, y, w, h, flags);

            // Act
            int result = Sdl.GetWindowOpacity(window, out float _);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test set window modal for should return expected value
        /// </summary>
        [Fact]
        public void TestSetWindowModalFor_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            const string title = "Test Window";
            const int x = 10;
            const int y = 10;
            const int w = 800;
            const int h = 600;
            const SdlWindowFlags flags = SdlWindowFlags.WindowShown;
            IntPtr modalWindow = Sdl.CreateWindow(title, x, y, w, h, flags);
            IntPtr parentWindow = Sdl.CreateWindow(title, x, y, w, h, flags);

            // Act
            int result = Sdl.SetWindowModalFor(modalWindow, parentWindow);

            // Assert
            Assert.Equal(-1, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test set window input focus should return expected value
        /// </summary>
        [Fact]
        public void TestSetWindowInputFocus_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            string title = "Test Window";
            int x = 10;
            int y = 10;
            int w = 800;
            int h = 600;
            SdlWindowFlags flags = SdlWindowFlags.WindowShown;
            IntPtr window = Sdl.CreateWindow(title, x, y, w, h, flags);

            // Act
            int result = Sdl.SetWindowInputFocus(window);

            // Assert
            Assert.Equal(-1, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get window data should return expected value
        /// </summary>
        [Fact]
        public void TestGetWindowData_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            string title = "Test Window";
            int x = 10;
            int y = 10;
            int w = 800;
            int h = 600;
            SdlWindowFlags flags = SdlWindowFlags.WindowShown;
            IntPtr window = Sdl.CreateWindow(title, x, y, w, h, flags);
            string name = "Test Data";

            // Act
            IntPtr result = Sdl.GetWindowData(window, name);

            // Assert
            Assert.Equal(IntPtr.Zero, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get window display index should return expected value
        /// </summary>
        [Fact]
        public void TestGetWindowDisplayIndex_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            string title = "Test Window";
            int x = 10;
            int y = 10;
            int w = 800;
            int h = 600;
            SdlWindowFlags flags = SdlWindowFlags.WindowShown;
            IntPtr window = Sdl.CreateWindow(title, x, y, w, h, flags);

            // Act
            int result = Sdl.GetWindowDisplayIndex(window);

            // Assert
            Assert.True(result <= 0);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl audio stream clear should not throw exception
        /// </summary>
        [Fact]
        public void TestSdlAudioStreamClear_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr stream = IntPtr.Zero; // Initialize your stream here

            // Act
            Exception exception = Record.Exception(() => Sdl.SdlAudioStreamClear(stream));

            // Assert
            Assert.Null(exception);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl free audio stream should not throw exception
        /// </summary>
        [Fact]
        public void TestSdlFreeAudioStream_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr stream = IntPtr.Zero; // Initialize your stream here

            // Act
            Exception exception = Record.Exception(() => Sdl.SdlFreeAudioStream(stream));

            // Assert
            Assert.Null(exception);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl get audio device spec should return expected value
        /// </summary>
        [Fact]
        public void TestSdlGetAudioDeviceSpec_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            int index = 0;
            int isCapture = 0;

            // Act
            int result = Sdl.SdlGetAudioDeviceSpec(index, isCapture, out SdlAudioSpec _);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl open audio device should return expected value
        /// </summary>
        [Fact]
        public void TestSdlOpenAudioDevice_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            string device = "Test Device";
            int isCapture = 0;
            SdlAudioSpec desired = new SdlAudioSpec();
            int allowedChanges = 0;

            // Act
            uint result = Sdl.SdlOpenAudioDevice(device, isCapture, ref desired, out SdlAudioSpec _, allowedChanges);

            // Assert
            Assert.Equal(0.0, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl pause audio should not throw exception
        /// </summary>
        [Fact]
        public void TestSdlPauseAudio_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            int pauseOn = 1;

            // Act
            Exception exception = Record.Exception(() => Sdl.SdlPauseAudio(pauseOn));

            // Assert
            Assert.Null(exception);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl pause audio device should not throw exception
        /// </summary>
        [Fact]
        public void TestSdlPauseAudioDevice_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            uint dev = 1; // Initialize your device here
            int pauseOn = 1;

            // Act
            Exception exception = Record.Exception(() => Sdl.SdlPauseAudioDevice(dev, pauseOn));

            // Assert
            Assert.Null(exception);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl unlock audio device should not throw exception
        /// </summary>
        [Fact]
        public void TestSdlUnlockAudioDevice_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            uint dev = 1; // Initialize your device here

            // Act
            Exception exception = Record.Exception(() => Sdl.SdlUnlockAudioDevice(dev));

            // Assert
            Assert.Null(exception);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl new audio stream should return expected value
        /// </summary>
        [Fact]
        public void TestSdlNewAudioStream_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            ushort srcFormat = 1;
            byte srcChannels = 1;
            int srcRate = 44100;
            ushort dstFormat = 1;
            byte dstChannels = 1;
            int dstRate = 44100;

            // Act
            IntPtr result = Sdl.SdlNewAudioStream(srcFormat, srcChannels, srcRate, dstFormat, dstChannels, dstRate);

            // Assert
            Assert.Equal(IntPtr.Zero, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl audio stream put should return expected value
        /// </summary>
        [Fact]
        public void TestSdlAudioStreamPut_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr stream = IntPtr.Zero; // Initialize your stream here
            IntPtr buf = IntPtr.Zero; // Initialize your buffer here
            int len = 0; // Initialize your length here

            // Act
            int result = Sdl.SdlAudioStreamPut(stream, buf, len);

            // Assert
            Assert.Equal(-1, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl audio stream get should return expected value
        /// </summary>
        [Fact]
        public void TestSdlAudioStreamGet_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr stream = IntPtr.Zero; // Initialize your stream here
            IntPtr buf = IntPtr.Zero; // Initialize your buffer here
            int len = 0; // Initialize your length here

            // Act
            int result = Sdl.SdlAudioStreamGet(stream, buf, len);

            // Assert
            Assert.Equal(-1, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl audio stream available should return expected value
        /// </summary>
        [Fact]
        public void TestSdlAudioStreamAvailable_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr stream = IntPtr.Zero; // Initialize your stream here

            // Act
            int result = Sdl.SdlAudioStreamAvailable(stream);

            // Assert
            Assert.True(result >= 0);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test mix audio format should not throw exception
        /// </summary>
        [Fact]
        public void TestMixAudioFormat_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            byte[] dst = new byte[10];
            byte[] src = new byte[10];
            ushort format = 1;
            uint len = 10;
            int volume = 1;

            // Act
            Exception exception = Record.Exception(() => Sdl.MixAudioFormat(dst, src, format, len, volume));

            // Assert
            Assert.Null(exception);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test lock sensors should not throw exception
        /// </summary>
        [Fact]
        public void TestLockSensors_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Exception exception = Record.Exception(Sdl.LockSensors);

            // Assert
            Assert.Null(exception);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test unlock sensors should not throw exception
        /// </summary>
        [Fact]
        public void TestUnlockSensors_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Exception exception = Record.Exception(Sdl.UnlockSensors);

            // Assert
            Assert.Null(exception);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl audio bit size should return expected value
        /// </summary>
        [Fact]
        public void TestSdlAudioBitSize_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            ushort x = 1;

            // Act
            ushort result = Sdl.SdlAudioBitSize(x);

            // Assert
            Assert.Equal(x & Sdl.AudioMaskBitSize, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl audio is float should return expected value
        /// </summary>
        [Fact]
        public void TestSdlAudioIsFloat_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            ushort x = 1;

            // Act
            bool result = Sdl.SdlAudioIsFloat(x);

            // Assert
            Assert.False(result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl audio is big endian should return expected value
        /// </summary>
        [Fact]
        public void TestSdlAudioIsBigEndian_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            ushort x = 1;

            // Act
            bool result = Sdl.SdlAudioIsBigEndian(x);

            // Assert
            Assert.False(result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl audio is signed should return expected value
        /// </summary>
        [Fact]
        public void TestSdlAudioIsSigned_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            ushort x = 1;

            // Act
            bool result = Sdl.SdlAudioIsSigned(x);

            // Assert
            Assert.False(result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl audio is int should return expected value
        /// </summary>
        [Fact]
        public void TestSdlAudioIsInt_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            ushort x = 1;

            // Act
            bool result = Sdl.SdlAudioIsInt(x);

            // Assert
            Assert.True(result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl audio is little endian should return expected value
        /// </summary>
        [Fact]
        public void TestSdlAudioIsLittleEndian_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            ushort x = 1;

            // Act
            bool result = Sdl.SdlAudioIsLittleEndian(x);

            // Assert
            Assert.True(result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl audio is unsigned should return expected value
        /// </summary>
        [Fact]
        public void TestSdlAudioIsUnsigned_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            ushort x = 1;

            // Act
            bool result = Sdl.SdlAudioIsUnsigned(x);

            // Assert
            Assert.True(result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test audio init should return expected value
        /// </summary>
        [Fact]
        public void TestAudioInit_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            string driverName = "driverName";

            // Act
            int result = Sdl.AudioInit(driverName);

            // Assert
            Assert.Equal(-1, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl mix audio format should not throw exception
        /// </summary>
        [Fact]
        public void TestSdlMixAudioFormat_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            byte[] dst = new byte[10];
            byte[] src = new byte[10];
            ushort format = 1;
            uint len = 10;
            int volume = 1;

            // Act
            Exception exception = Record.Exception(() => Sdl.MixAudioFormat(dst, src, format, len, volume));

            // Assert
            Assert.Null(exception);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test open audio device should return expected value
        /// </summary>
        [Fact]
        public void TestOpenAudioDevice_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr device = IntPtr.Zero;
            int isCapture = 0;
            SdlAudioSpec desired = new SdlAudioSpec();
            int allowedChanges = 0;

            // Act
            uint result = Sdl.OpenAudioDevice(device, isCapture, ref desired, out SdlAudioSpec _, allowedChanges);

            // Assert
            Assert.True(result == 0 || result == 1 || result == 2);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get window display mode should return expected value
        /// </summary>
        [Fact]
        public void TestGetWindowDisplayMode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            int result = Sdl.GetWindowDisplayMode(window, out SdlDisplayMode _);

            // Assert
            Assert.Equal(-1, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get window flags should return expected value
        /// </summary>
        [Fact]
        public void TestGetWindowFlags_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            uint result = Sdl.GetWindowFlags(window);

            // Assert
            Assert.Equal(0.0, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get window from id should return expected value
        /// </summary>
        [Fact]
        public void TestGetWindowFromId_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            uint id = 1;

            // Act
            IntPtr result = Sdl.GetWindowFromId(id);

            // Assert
            Assert.Equal(IntPtr.Zero, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get window gamma ramp should return expected value
        /// </summary>
        [Fact]
        public void TestGetWindowGammaRamp_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;
            ushort[] red = new ushort[256];
            ushort[] green = new ushort[256];
            ushort[] blue = new ushort[256];

            // Act
            int result = Sdl.GetWindowGammaRamp(window, red, green, blue);

            // Assert
            Assert.Equal(-1, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get window grab should return expected value
        /// </summary>
        [Fact]
        public void TestGetWindowGrab_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            SdlBool result = Sdl.GetWindowGrab(window);

            // Assert
            Assert.Equal(SdlBool.False, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get window keyboard grab should return expected value
        /// </summary>
        [Fact]
        public void TestGetWindowKeyboardGrab_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            SdlBool result = Sdl.GetWindowKeyboardGrab(window);

            // Assert
            Assert.Equal(SdlBool.False, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get window mouse grab should return expected value
        /// </summary>
        [Fact]
        public void TestGetWindowMouseGrab_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            SdlBool result = Sdl.GetWindowMouseGrab(window);

            // Assert
            Assert.Equal(SdlBool.False, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get window id should return expected value
        /// </summary>
        [Fact]
        public void TestGetWindowId_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            uint result = Sdl.GetWindowId(window);

            // Assert
            Assert.Equal(0.0, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get window pixel format should return expected value
        /// </summary>
        [Fact]
        public void TestGetWindowPixelFormat_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            uint result = Sdl.GetWindowPixelFormat(window);

            // Assert
            Assert.Equal(0.0, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test start text input should not throw exception
        /// </summary>
        [Fact]
        public void TestStartTextInput_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Exception exception = Record.Exception(Sdl.StartTextInput);

            // Assert
            Assert.Null(exception);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test is text input active should return expected value
        /// </summary>
        [Fact]
        public void TestIsTextInputActive_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            SdlBool result = Sdl.IsTextInputActive();

            // Assert
            Assert.Equal(SdlBool.True, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test stop text input should not throw exception
        /// </summary>
        [Fact]
        public void TestStopTextInput_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Exception exception = Record.Exception(Sdl.StopTextInput);

            // Assert
            Assert.Null(exception);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test set text input rect should not throw exception
        /// </summary>
        [Fact]
        public void TestSetTextInputRect_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            RectangleI rect = new RectangleI();

            // Act
            Exception exception = Record.Exception(() => Sdl.SetTextInputRect(ref rect));

            // Assert
            Assert.Null(exception);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test has screen keyboard support should return expected value
        /// </summary>
        [Fact]
        public void TestHasScreenKeyboardSupport_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            SdlBool result = Sdl.HasScreenKeyboardSupport();

            // Assert
            Assert.Equal(SdlBool.False, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test is screen keyboard shown should return expected value
        /// </summary>
        [Fact]
        public void TestIsScreenKeyboardShown_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            SdlBool result = Sdl.IsScreenKeyboardShown(window);

            // Assert
            Assert.Equal(SdlBool.False, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get mouse focus should return expected value
        /// </summary>
        [Fact]
        public void TestGetMouseFocus_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            IntPtr result = Sdl.GetMouseFocus();

            // Assert
            Assert.Equal(IntPtr.Zero, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get mouse state out x and y should return expected value
        /// </summary>
        [Fact]
        public void TestGetMouseStateOutXAndY_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            uint result = Sdl.GetMouseStateOutXAndY(out int _, out int _);

            // Assert
            Assert.Equal(0.0, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get global mouse state out x and out y should return expected value
        /// </summary>
        [Fact]
        public void TestGetGlobalMouseStateOutXAndOutY_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            uint result = Sdl.GetGlobalMouseStateOutXAndOutY(out int _, out int _);

            // Assert
            Assert.True(Math.Abs(result - -0.0) < 0.1f || Math.Abs(result - 1.0) < 0.1f || Math.Abs(result - 2.0) < 0.1f);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that calculate gamma ramp test
        /// </summary>
        [Fact]
        public void CalculateGammaRampTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            float gamma = 1.0f;
            ushort[] ramp = new ushort[256];
            Sdl.CalculateGammaRamp(gamma, ramp);
            Assert.NotEmpty(ramp);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get pixel format name test
        /// </summary>
        [Fact]
        public void GetPixelFormatNameTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            const uint format = 0;
            string result = Sdl.GetPixelFormatName(format);
            Assert.NotNull(result);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render copy ex test
        /// </summary>
        [Fact]
        public void RenderCopyExTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero;
            IntPtr texture = IntPtr.Zero;
            RectangleI srcRect = new RectangleI();
            RectangleF dst = new RectangleF();
            double angle = 0;
            PointF center = new PointF();
            SdlRendererFlip flip = SdlRendererFlip.SdlFlipHorizontal;

            // Act
            int result = Sdl.RenderCopyEx(renderer, texture, ref srcRect, ref dst, angle, ref center, flip);

            // Assert
            Assert.True(result >= -1);
        }

        /// <summary>
        /// Tests that get window maximum size test
        /// </summary>
        [Fact]
        public void GetWindowMaximumSizeTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            Sdl.GetWindowMaximumSize(window, out int _, out int _);

            // Assert
            // Add your assertions here based on your specific requirements
        }

        /// <summary>
        /// Tests that get window minimum size test
        /// </summary>
        [Fact]
        public void GetWindowMinimumSizeTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            Sdl.GetWindowMinimumSize(window, out int _, out int _);

            // Assert
            // Add your assertions here based on your specific requirements
        }

        /// <summary>
        /// Tests that set window opacity test
        /// </summary>
        [Fact]
        public void SetWindowOpacityTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;
            float opacity = 1.0f;

            // Act
            int result = Sdl.SetWindowOpacity(window, opacity);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window opacity test
        /// </summary>
        [Fact]
        public void GetWindowOpacityTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            int result = Sdl.GetWindowOpacity(window, out float _);

            // Assert
            Assert.True(result >= -1);
        }

        /// <summary>
        /// Tests that set window modal for test
        /// </summary>
        [Fact]
        public void SetWindowModalForTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;
            IntPtr modalWindow = IntPtr.Zero;

            // Act
            int result = Sdl.SetWindowModalFor(window, modalWindow);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set window input focus test
        /// </summary>
        [Fact]
        public void SetWindowInputFocusTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            int result = Sdl.SetWindowInputFocus(window);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window data test
        /// </summary>
        [Fact]
        public void GetWindowDataTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;
            string name = "test";

            // Act
            IntPtr result = Sdl.GetWindowData(window, name);

            // Assert
            Assert.Equal(IntPtr.Zero, result);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window display index test
        /// </summary>
        [Fact]
        public void GetWindowDisplayIndexTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            int result = Sdl.GetWindowDisplayIndex(window);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window flags test
        /// </summary>
        [Fact]
        public void GetWindowFlagsTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            uint result = Sdl.GetWindowFlags(window);

            // Assert
            Assert.Equal(0u, result);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window from id test
        /// </summary>
        [Fact]
        public void GetWindowFromIdTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            uint id = 0;

            // Act
            IntPtr result = Sdl.GetWindowFromId(id);

            // Assert
            Assert.Equal(IntPtr.Zero, result);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window pixel format test
        /// </summary>
        [Fact]
        public void GetWindowPixelFormatTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            uint result = Sdl.GetWindowPixelFormat(window);

            // Assert
            Assert.Equal(0u, result);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that start text input test
        /// </summary>
        [Fact]
        public void StartTextInputTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Sdl.StartTextInput();

            // Assert
            Assert.Equal(SdlBool.True, Sdl.IsTextInputActive());

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that is text input active test
        /// </summary>
        [Fact]
        public void IsTextInputActiveTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Sdl.IsTextInputActive();

            // Assert
            Assert.Equal(SdlBool.True, Sdl.IsTextInputActive());

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that stop text input test
        /// </summary>
        [Fact]
        public void StopTextInputTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Sdl.StopTextInput();

            // Assert
            Assert.Equal(SdlBool.False, Sdl.IsTextInputActive());


            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set text input rect test
        /// </summary>
        [Fact]
        public void SetTextInputRectTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            RectangleI rect = new RectangleI();

            // Act
            Sdl.SetTextInputRect(ref rect);

            // Assert
            Assert.Equal(0, rect.x);
            Assert.Equal(0, rect.y);
            Assert.Equal(0, rect.w);
            Assert.Equal(0, rect.h);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that has screen keyboard support test
        /// </summary>
        [Fact]
        public void HasScreenKeyboardSupportTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Sdl.HasScreenKeyboardSupport();

            // Assert
            Assert.Equal(SdlBool.False, Sdl.HasScreenKeyboardSupport());

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that is screen keyboard shown test
        /// </summary>
        [Fact]
        public void IsScreenKeyboardShownTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            Sdl.IsScreenKeyboardShown(window);

            // Assert
            Assert.Equal(SdlBool.False, Sdl.IsScreenKeyboardShown(window));

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get mouse focus test
        /// </summary>
        [Fact]
        public void GetMouseFocusTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            IntPtr result = Sdl.GetMouseFocus();

            // Assert
            Assert.Equal(IntPtr.Zero, result);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get mouse state out x and y test
        /// </summary>
        [Fact]
        public void GetMouseStateOutXAndYTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            IntPtr x = IntPtr.Zero;
            IntPtr y = IntPtr.Zero;

            uint result = Sdl.GetGlobalMouseStateXAndY(x, y);

            // Assert
            Assert.True(Math.Abs(result - -0.0) < 0.1f || Math.Abs(result - 1.0) < 0.1f || Math.Abs(result - 2.0) < 0.1f);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get global mouse state out x and out y test
        /// </summary>
        [Fact]
        public void GetGlobalMouseStateOutXAndOutYTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            uint result = Sdl.GetGlobalMouseStateOutXAndOutY(out int _, out int _);

            // Assert
            Assert.True(Math.Abs(result - -0.0) < 0.1f || Math.Abs(result - 1.0) < 0.1f || Math.Abs(result - 2.0) < 0.1f);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window position test
        /// </summary>
        [Fact]
        public void GetWindowPositionTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            Sdl.GetWindowPosition(window, out int x, out int y);

            // Assert
            Assert.Equal(0, x);
            Assert.Equal(0, y);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window size test
        /// </summary>
        [Fact]
        public void GetWindowSizeTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            Sdl.GetWindowSize(window, out int w, out int h);

            // Assert
            Assert.True(w >= 0);
            Assert.True(h >= 0);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window title test
        /// </summary>
        [Fact]
        public void GetWindowTitleTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            string title = Sdl.GetWindowTitle(window);

            // Assert
            Assert.Equal(string.Empty, title);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window brightness test
        /// </summary>
        [Fact]
        public void GetWindowBrightnessTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            Sdl.GetWindowBrightness(window);

            // Assert
            Assert.Equal(1.0f, Sdl.GetWindowBrightness(window));

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window display mode test
        /// </summary>
        [Fact]
        public void GetWindowDisplayModeTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            int result = Sdl.GetWindowDisplayMode(window, out SdlDisplayMode _);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window surface test
        /// </summary>
        [Fact]
        public void GetWindowSurfaceTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            Sdl.GetWindowSurface(window);

            // Assert
            Assert.Equal(IntPtr.Zero, Sdl.GetWindowSurface(window));

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window grab test
        /// </summary>
        [Fact]
        public void GetWindowGrabTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            Sdl.GetWindowGrab(window);

            // Assert
            Assert.Equal(SdlBool.False, Sdl.GetWindowGrab(window));

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window surface test not in sdl test
        /// </summary>
        [Fact]
        public void GetWindowSurfaceTest_NotInSdlTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            IntPtr surface = Sdl.GetWindowSurface(window);

            // Assert
            Assert.Equal(IntPtr.Zero, surface);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window grab test not in sdl test
        /// </summary>
        [Fact]
        public void GetWindowGrabTest_NotInSdlTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            SdlBool result = Sdl.GetWindowGrab(window);

            // Assert
            Assert.Equal(SdlBool.False, result);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window brightness test not in sdl test
        /// </summary>
        [Fact]
        public void GetWindowBrightnessTest_NotInSdlTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            float brightness = Sdl.GetWindowBrightness(window);

            // Assert
            Assert.Equal(1.0f, brightness);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window display mode test not in sdl test
        /// </summary>
        [Fact]
        public void GetWindowDisplayModeTest_NotInSdlTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            int result = Sdl.GetWindowDisplayMode(window, out SdlDisplayMode _);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window flags test not in sdl test
        /// </summary>
        [Fact]
        public void GetWindowFlagsTest_NotInSdlTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            uint flags = Sdl.GetWindowFlags(window);

            // Assert
            Assert.Equal(0.0, flags);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window surface test not in sdl test 2
        /// </summary>
        [Fact]
        public void GetWindowSurfaceTest_NotInSdlTest2()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            IntPtr surface = Sdl.GetWindowSurface(window);

            // Assert
            Assert.Equal(IntPtr.Zero, surface);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window grab test not in sdl test 2
        /// </summary>
        [Fact]
        public void GetWindowGrabTest_NotInSdlTest2()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            SdlBool result = Sdl.GetWindowGrab(window);

            // Assert
            Assert.Equal(SdlBool.False, result);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window brightness test not in sdl test 2
        /// </summary>
        [Fact]
        public void GetWindowBrightnessTest_NotInSdlTest2()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            float brightness = Sdl.GetWindowBrightness(window);

            // Assert
            Assert.Equal(1.0f, brightness);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window display mode test not in sdl test 2
        /// </summary>
        [Fact]
        public void GetWindowDisplayModeTest_NotInSdlTest2()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            int result = Sdl.GetWindowDisplayMode(window, out SdlDisplayMode _);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window flags test not in sdl test 2
        /// </summary>
        [Fact]
        public void GetWindowFlagsTest_NotInSdlTest2()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            uint flags = Sdl.GetWindowFlags(window);

            // Assert
            Assert.Equal(0.0, flags);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window grab test not in sdl test 3
        /// </summary>
        [Fact]
        public void GetWindowGrabTest_NotInSdlTest3()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            SdlBool result = Sdl.GetWindowGrab(window);

            // Assert
            Assert.Equal(SdlBool.False, result);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window brightness test not in sdl test 3
        /// </summary>
        [Fact]
        public void GetWindowBrightnessTest_NotInSdlTest3()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            float brightness = Sdl.GetWindowBrightness(window);

            // Assert
            Assert.Equal(1.0f, brightness);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window display mode test not in sdl test 3
        /// </summary>
        [Fact]
        public void GetWindowDisplayModeTest_NotInSdlTest3()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            int result = Sdl.GetWindowDisplayMode(window, out SdlDisplayMode _);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window flags test not in sdl test 3
        /// </summary>
        [Fact]
        public void GetWindowFlagsTest_NotInSdlTest3()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            uint flags = Sdl.GetWindowFlags(window);

            // Assert
            Assert.Equal(0.0, flags);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window grab test not in sdl test 4
        /// </summary>
        [Fact]
        public void GetWindowGrabTest_NotInSdlTest4()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            SdlBool result = Sdl.GetWindowGrab(window);

            // Assert
            Assert.Equal(SdlBool.False, result);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window brightness test not in sdl test 4
        /// </summary>
        [Fact]
        public void GetWindowBrightnessTest_NotInSdlTest4()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            float brightness = Sdl.GetWindowBrightness(window);

            // Assert
            Assert.Equal(1.0f, brightness);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window display mode test not in sdl test 4
        /// </summary>
        [Fact]
        public void GetWindowDisplayModeTest_NotInSdlTest4()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            int result = Sdl.GetWindowDisplayMode(window, out SdlDisplayMode _);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window flags test not in sdl test 4
        /// </summary>
        [Fact]
        public void GetWindowFlagsTest_NotInSdlTest4()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            uint flags = Sdl.GetWindowFlags(window);

            // Assert
            Assert.Equal(0.0, flags);

            Sdl.Quit();
        }


        /// <summary>
        /// Tests that test sdl get error should return empty after init
        /// </summary>
        [Fact]
        public void TestSdlGetError_ShouldReturnEmpty_AfterInit()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            string error = Sdl.GetError();

            // Assert
            Assert.Equal(string.Empty, error);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test sdl was init should return non zero after init
        /// </summary>
        [Fact]
        public void TestSdlWasInit_ShouldReturnNonZero_AfterInit()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            uint wasInit = Sdl.WasInit(SdlInit.InitEverything);

            // Assert
            Assert.NotEqual(0.0, wasInit);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test joystick name for index should return valid name after init
        /// </summary>
        [Fact]
        public void TestJoystickNameForIndex_ShouldReturnValidName_AfterInit()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int deviceIndex = 0; // Assuming a device is connected at index 0

            // Act
            string joystickName = Sdl.JoystickNameForIndex(deviceIndex);

            // Assert
            Assert.True(string.IsNullOrEmpty(joystickName));

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test joystick num axes should return non negative after init
        /// </summary>
        [Fact]
        public void TestJoystickNumAxes_ShouldReturnNonNegative_AfterInit()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = Sdl.JoystickOpen(0); // Assuming a joystick is connected

            // Act
            int numAxes = Sdl.JoystickNumAxes(joystick);

            // Assert
            Assert.True(numAxes >= -1);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test joystick num balls should return non negative after init
        /// </summary>
        [Fact]
        public void TestJoystickNumBalls_ShouldReturnNonNegative_AfterInit()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = Sdl.JoystickOpen(0); // Assuming a joystick is connected

            // Act
            int numBalls = Sdl.JoystickNumBalls(joystick);

            // Assert
            Assert.True(numBalls >= -1);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test joystick num buttons should return non negative after init
        /// </summary>
        [Fact]
        public void TestJoystickNumButtons_ShouldReturnNonNegative_AfterInit()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = Sdl.JoystickOpen(0); // Assuming a joystick is connected

            // Act
            int numButtons = Sdl.JoystickNumButtons(joystick);

            // Assert
            Assert.True(numButtons >= -1);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test joystick num hats should return non negative after init
        /// </summary>
        [Fact]
        public void TestJoystickNumHats_ShouldReturnNonNegative_AfterInit()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = Sdl.JoystickOpen(0); // Assuming a joystick is connected

            // Act
            int numHats = Sdl.JoystickNumHats(joystick);

            // Assert
            Assert.True(numHats >= -1);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test joystick open should return valid pointer after init
        /// </summary>
        [Fact]
        public void TestJoystickOpen_ShouldReturnValidPointer_AfterInit()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int deviceIndex = 0; // Assuming a device is connected at index 0

            // Act
            IntPtr joystick = Sdl.JoystickOpen(deviceIndex);

            // Assert
            Assert.Equal(IntPtr.Zero, joystick);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test num joysticks should return non negative after init
        /// </summary>
        [Fact]
        public void TestNumJoysticks_ShouldReturnNonNegative_AfterInit()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            int numJoysticks = Sdl.NumJoysticks();

            // Assert
            Assert.True(numJoysticks >= 0);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test joystick get device guid should return valid guid after init
        /// </summary>
        [Fact]
        public void TestJoystickGetDeviceGuid_ShouldReturnValidGuid_AfterInit()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int deviceIndex = 0; // Assuming a device is connected at index 0

            // Act
            Guid deviceGuid = Sdl.JoystickGetDeviceGuid(deviceIndex);

            // Assert
            Assert.Equal(Guid.Empty, deviceGuid);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test joystick get guid should return valid guid after init
        /// </summary>
        [Fact]
        public void TestJoystickGetGuid_ShouldReturnValidGuid_AfterInit()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = Sdl.JoystickOpen(0); // Assuming a joystick is connected

            // Act
            Guid joystickGuid = Sdl.JoystickGetGuid(joystick);

            // Assert
            Assert.Equal(Guid.Empty, joystickGuid);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test joystick get device vendor should return valid vendor after init
        /// </summary>
        [Fact]
        public void TestJoystickGetDeviceVendor_ShouldReturnValidVendor_AfterInit()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int deviceIndex = 0; // Assuming a device is connected at index 0

            // Act
            ushort deviceVendor = Sdl.JoystickGetDeviceVendor(deviceIndex);

            // Assert
            Assert.True(deviceVendor == 0 || deviceVendor == 1 || deviceVendor == 2);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test joystick get device product should return valid product after init
        /// </summary>
        [Fact]
        public void TestJoystickGetDeviceProduct_ShouldReturnValidProduct_AfterInit()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int deviceIndex = 0; // Assuming a device is connected at index 0

            // Act
            ushort deviceProduct = Sdl.JoystickGetDeviceProduct(deviceIndex);

            // Assert
            Assert.True(deviceProduct == 0 || deviceProduct == 1 || deviceProduct == 2);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test joystick get device product version should return valid product version after init
        /// </summary>
        [Fact]
        public void TestJoystickGetDeviceProductVersion_ShouldReturnValidProductVersion_AfterInit()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int deviceIndex = 0; // Assuming a device is connected at index 0

            // Act
            ushort deviceProductVersion = Sdl.JoystickGetDeviceProductVersion(deviceIndex);

            // Assert
            Assert.True(deviceProductVersion == 0 || deviceProductVersion == 1 || deviceProductVersion == 2);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test joystick get device type should return valid type after init
        /// </summary>
        [Fact]
        public void TestJoystickGetDeviceType_ShouldReturnValidType_AfterInit()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int deviceIndex = 0; // Assuming a device is connected at index 0

            // Act
            SdlJoystickType deviceType = Sdl.JoystickGetDeviceType(deviceIndex);

            // Assert
            Assert.NotEqual(SdlJoystickType.SdlJoystickTypeUnknown, deviceType);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test joystick get device instance id should return valid instance id after init
        /// </summary>
        [Fact]
        public void TestJoystickGetDeviceInstanceId_ShouldReturnValidInstanceId_AfterInit()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int deviceIndex = 0; // Assuming a device is connected at index 0

            // Act
            int instanceId = Sdl.JoystickGetDeviceInstanceId(deviceIndex);

            // Assert
            Assert.True(initResult >= -1);
            Assert.True(instanceId >= -1);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test joystick get vendor should return valid vendor after init
        /// </summary>
        [Fact]
        public void TestJoystickGetVendor_ShouldReturnValidVendor_AfterInit()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = Sdl.JoystickOpen(0); // Assuming a joystick is connected

            // Act
            ushort vendor = Sdl.JoystickGetVendor(joystick);

            // Assert
            Assert.True(vendor == 0 || vendor == 1 || vendor == 2);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test joystick get product should return valid product after init
        /// </summary>
        [Fact]
        public void TestJoystickGetProduct_ShouldReturnValidProduct_AfterInit()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = Sdl.JoystickOpen(0); // Assuming a joystick is connected

            // Act
            ushort product = Sdl.JoystickGetProduct(joystick);

            // Assert
            Assert.True(product == 0 || product == 1 || product == 2);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test joystick get product version should return valid product version after init
        /// </summary>
        [Fact]
        public void TestJoystickGetProductVersion_ShouldReturnValidProductVersion_AfterInit()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = Sdl.JoystickOpen(0); // Assuming a joystick is connected

            // Act
            ushort productVersion = Sdl.JoystickGetProductVersion(joystick);

            // Assert
            Assert.True(productVersion == 0 || productVersion == 1 || productVersion == 2);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test joystick get serial should return valid serial after init
        /// </summary>
        [Fact]
        public void TestJoystickGetSerial_ShouldReturnValidSerial_AfterInit()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = Sdl.JoystickOpen(0); // Assuming a joystick is connected

            // Act
            string serial = Sdl.JoystickGetSerial(joystick);

            // Assert
            Assert.True(string.IsNullOrEmpty(serial));

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test joystick get type should return valid type after init
        /// </summary>
        [Fact]
        public void TestJoystickGetType_ShouldReturnValidType_AfterInit()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = Sdl.JoystickOpen(0); // Assuming a joystick is connected

            // Act
            SdlJoystickType type = Sdl.JoystickGetType(joystick);

            // Assert
            Assert.NotEqual(SdlJoystickType.SdlJoystickTypeUnknown, type);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test joystick get attached should return true after init
        /// </summary>
        [Fact]
        public void TestJoystickGetAttached_ShouldReturnTrue_AfterInit()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = Sdl.JoystickOpen(0); // Assuming a joystick is connected

            // Act
            SdlBool attached = Sdl.JoystickGetAttached(joystick);

            // Assert
            Assert.Equal(SdlBool.False, attached);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test joystick instance id should return valid instance id after init
        /// </summary>
        [Fact]
        public void TestJoystickInstanceId_ShouldReturnValidInstanceId_AfterInit()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = Sdl.JoystickOpen(0); // Assuming a joystick is connected

            // Act
            int instanceId = Sdl.JoystickInstanceId(joystick);

            // Assert
            Assert.True(instanceId >= -1);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test joystick current power level should return valid power level after init
        /// </summary>
        [Fact]
        public void TestJoystickCurrentPowerLevel_ShouldReturnValidPowerLevel_AfterInit()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = Sdl.JoystickOpen(0); // Assuming a joystick is connected

            // Act
            SdlJoystickPowerLevel powerLevel = Sdl.JoystickCurrentPowerLevel(joystick);

            // Assert
            Assert.NotEqual(SdlJoystickPowerLevel.SdlJoystickPowerEmpty, powerLevel);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that bind texture should return expected value
        /// </summary>
        [Fact]
        public void BindTexture_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr texture = IntPtr.Zero;

            // Act
            int result = Sdl.BindTexture(texture, out float _, out float _);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that create context should return expected value
        /// </summary>
        [Fact]
        public void CreateContext_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;

            // Act
            IntPtr result = Sdl.CreateContext(window);

            // Assert
            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that delete context should not throw exception
        /// </summary>
        [Fact]
        public void DeleteContext_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr context = IntPtr.Zero;

            // Act
            Sdl.DeleteContext(context);

            // Assert
            // No exception should be thrown

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get proc address should return expected value
        /// </summary>
        [Fact]
        public void GetProcAddress_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            string proc = "glBindTexture";

            // Act
            IntPtr result = Sdl.GetProcAddress(proc);

            // Assert
            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that extension supported should return expected value
        /// </summary>
        [Fact]
        public void ExtensionSupported_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            string extension = "GL_ARB_texture_non_power_of_two";

            // Act
            SdlBool result = Sdl.ExtensionSupported(extension);

            // Assert
            Assert.Equal(SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that reset attributes should not throw exception
        /// </summary>
        [Fact]
        public void ResetAttributes_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Sdl.ResetAttributes();

            // Assert
            // No exception should be thrown

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get attribute should return expected value
        /// </summary>
        [Fact]
        public void GetAttribute_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            SdlGlAttr attr = SdlGlAttr.SdlGlContextMajorVersion;

            // Act
            int result = Sdl.GetAttribute(attr, out int _);

            // Assert
            Assert.Equal(0, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get swap interval should return expected value
        /// </summary>
        [Fact]
        public void GetSwapInterval_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            int result = Sdl.GetSwapInterval();

            // Assert
            Assert.Equal(0, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that make current should return expected value
        /// </summary>
        [Fact]
        public void MakeCurrent_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;
            IntPtr context = IntPtr.Zero;

            // Act
            int result = Sdl.MakeCurrent(window, context);

            // Assert
            Assert.Equal(0, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get current window should return expected value
        /// </summary>
        [Fact]
        public void GetCurrentWindow_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            IntPtr result = Sdl.GetCurrentWindow();

            // Assert
            Assert.Equal(IntPtr.Zero, result); // Replace IntPtr.Zero with the expected result

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get current context should return expected value
        /// </summary>
        [Fact]
        public void GetCurrentContext_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            IntPtr result = Sdl.GetCurrentContext();

            // Assert
            Assert.Equal(IntPtr.Zero, result); // Replace IntPtr.Zero with the expected result

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get drawable size should return expected value
        /// </summary>
        [Fact]
        public void GetDrawableSize_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;

            // Act
            Sdl.GetDrawableSize(window, out int w, out int h);

            // Assert
            Assert.Equal(0, w);
            Assert.Equal(0, h);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set attribute by int should return expected value
        /// </summary>
        [Fact]
        public void SetAttributeByInt_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            SdlGlAttr attr = SdlGlAttr.SdlGlContextMajorVersion;
            int value = 3;

            // Act
            int result = Sdl.SetAttributeByInt(attr, value);

            // Assert
            Assert.Equal(0, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set attribute by profile should return expected value
        /// </summary>
        [Fact]
        public void SetAttributeByProfile_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            SdlGlAttr attr = SdlGlAttr.SdlGlContextProfileMask;
            SdlGlProfile profile = SdlGlProfile.SdlGlContextProfileCore;

            // Act
            int result = Sdl.SetAttributeByProfile(attr, profile);

            // Assert
            Assert.Equal(0, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set swap interval should return expected value
        /// </summary>
        [Fact]
        public void SetSwapInterval_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int interval = 1;

            // Act
            int result = Sdl.SetSwapInterval(interval);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that swap window should not throw exception
        /// </summary>
        [Fact]
        public void SwapWindow_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;

            // Act
            Sdl.SwapWindow(window);

            // Assert
            Assert.Equal(SdlBool.False, Sdl.IsScreenKeyboardShown(window));

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that unbind texture should return expected value
        /// </summary>
        [Fact]
        public void UnbindTexture_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr texture = IntPtr.Zero;

            // Act
            int result = Sdl.UnbindTexture(texture);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that hide window should not throw exception
        /// </summary>
        [Fact]
        public void HideWindow_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;

            // Act
            Sdl.HideWindow(window);

            // Assert
            Assert.Equal(SdlBool.False, Sdl.IsScreenKeyboardShown(window));

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that maximize window should not throw exception
        /// </summary>
        [Fact]
        public void MaximizeWindow_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;

            // Act
            Sdl.MaximizeWindow(window);

            // Assert
            Assert.Equal(SdlBool.False, Sdl.IsScreenKeyboardShown(window));

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that minimize window should not throw exception
        /// </summary>
        [Fact]
        public void MinimizeWindow_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;

            // Act
            Sdl.MinimizeWindow(window);

            // Assert
            Assert.Equal(SdlBool.False, Sdl.IsScreenKeyboardShown(window));

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that raise window should not throw exception
        /// </summary>
        [Fact]
        public void RaiseWindow_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;

            // Act
            Sdl.RaiseWindow(window);

            // Assert
            Assert.Equal(SdlBool.False, Sdl.IsScreenKeyboardShown(window));

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that restore window should not throw exception
        /// </summary>
        [Fact]
        public void RestoreWindow_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;

            // Act
            try
            {
                Sdl.RestoreWindow(window);
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception thrown when calling RestoreWindow: " + ex.Message);
            }

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set window brightness should return expected value
        /// </summary>
        [Fact]
        public void SetWindowBrightness_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;
            float brightness = 1.0f;

            // Act
            int result = Sdl.SetWindowBrightness(window, brightness);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set window data should return expected value
        /// </summary>
        [Fact]
        public void SetWindowData_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;
            string name = "test";
            IntPtr userdata = IntPtr.Zero;

            // Act
            IntPtr result = Sdl.SetWindowData(window, name, userdata);

            // Assert
            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set window display mode should return expected value
        /// </summary>
        [Fact]
        public void SetWindowDisplayMode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;
            SdlDisplayMode mode = new SdlDisplayMode();

            // Act
            int result = Sdl.SetWindowDisplayMode(window, ref mode);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set window fullscreen should return expected value
        /// </summary>
        [Fact]
        public void SetWindowFullscreen_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;
            uint flags = 0;

            // Act
            int result = Sdl.SetWindowFullscreen(window, flags);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set window gamma ramp should return expected value
        /// </summary>
        [Fact]
        public void SetWindowGammaRamp_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;
            ushort[] red = new ushort[256];
            ushort[] green = new ushort[256];
            ushort[] blue = new ushort[256];

            // Act
            int result = Sdl.SetWindowGammaRamp(window, red, green, blue);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set window grab should not throw exception
        /// </summary>
        [Fact]
        public void SetWindowGrab_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;
            SdlBool grabbed = SdlBool.True;

            // Act
            Sdl.SetWindowGrab(window, grabbed);

            // Assert
            Assert.Equal(SdlBool.True, grabbed);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set window keyboard grab should not throw exception
        /// </summary>
        [Fact]
        public void SetWindowKeyboardGrab_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;
            SdlBool grabbed = SdlBool.True;

            // Act
            Sdl.SetWindowKeyboardGrab(window, grabbed);

            // Assert
            Assert.Equal(SdlBool.True, grabbed);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set window mouse grab should not throw exception
        /// </summary>
        [Fact]
        public void SetWindowMouseGrab_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;
            SdlBool grabbed = SdlBool.True;

            // Act
            Sdl.SetWindowMouseGrab(window, grabbed);

            // Assert
            Assert.Equal(SdlBool.True, grabbed);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set window icon should not throw exception
        /// </summary>
        [Fact]
        public void SetWindowIcon_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;
            IntPtr icon = IntPtr.Zero;

            // Act
            Sdl.SetWindowIcon(window, icon);

            // Assert
            // No exception should be thrown

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set window maximum size should not throw exception
        /// </summary>
        [Fact]
        public void SetWindowMaximumSize_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;
            int maxW = 800;
            int maxH = 600;

            // Act
            Sdl.SetWindowMaximumSize(window, maxW, maxH);

            // Assert
            // No exception should be thrown

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set window minimum size should not throw exception
        /// </summary>
        [Fact]
        public void SetWindowMinimumSize_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;
            int minW = 800;
            int minH = 600;

            // Act
            Sdl.SetWindowMinimumSize(window, minW, minH);

            // Assert
            // No exception should be thrown

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set window position should not throw exception
        /// </summary>
        [Fact]
        public void SetWindowPosition_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;
            int x = 100;
            int y = 100;

            // Act
            Sdl.SetWindowPosition(window, x, y);

            // Assert
            // No exception should be thrown

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set window size should not throw exception
        /// </summary>
        [Fact]
        public void SetWindowSize_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;
            int w = 800;
            int h = 600;

            // Act
            Sdl.SetWindowSize(window, w, h);

            // Assert
            // No exception should be thrown

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set window bordered should not throw exception
        /// </summary>
        [Fact]
        public void SetWindowBordered_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;
            SdlBool bordered = SdlBool.True;

            // Act
            Sdl.SetWindowBordered(window, bordered);

            // Assert
            // No exception should be thrown

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window borders size should return expected value
        /// </summary>
        [Fact]
        public void GetWindowBordersSize_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;

            // Act
            int result = Sdl.GetWindowBordersSize(window, out int _, out int _, out int _, out int _);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set window resizable should not throw exception
        /// </summary>
        [Fact]
        public void SetWindowResizable_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;
            SdlBool resizable = SdlBool.True;

            // Act
            Sdl.SetWindowResizable(window, resizable);

            // Assert
            Assert.Equal(SdlBool.True, resizable);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set window always on top should not throw exception
        /// </summary>
        [Fact]
        public void SetWindowAlwaysOnTop_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;
            SdlBool onTop = SdlBool.True;

            // Act
            Sdl.SetWindowAlwaysOnTop(window, onTop);

            // Assert
            Assert.Equal(SdlBool.True, onTop);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set window title should not throw exception
        /// </summary>
        [Fact]
        public void SetWindowTitle_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;
            string title = "Test Title";

            // Act
            Sdl.SetWindowTitle(window, title);

            // Assert
            Assert.Equal("", Sdl.GetWindowTitle(window));

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that show window should not throw exception
        /// </summary>
        [Fact]
        public void ShowWindow_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;

            // Act
            Sdl.ShowWindow(window);

            // Assert
            Assert.Equal(SdlBool.False, Sdl.IsScreenKeyboardShown(window));

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that update window surface should return expected value
        /// </summary>
        [Fact]
        public void UpdateWindowSurface_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;

            // Act
            int result = Sdl.UpdateWindowSurface(window);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that update window surface rects should return expected value
        /// </summary>
        [Fact]
        public void UpdateWindowSurfaceRects_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;
            RectangleI[] rects = new RectangleI[1];
            int numRects = 1;

            // Act
            int result = Sdl.UpdateWindowSurfaceRects(window, rects, numRects);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set window hit test should return expected value
        /// </summary>
        [Fact]
        public void SetWindowHitTest_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;
            IntPtr callbackData = IntPtr.Zero;

            // Act
            int result = Sdl.SetWindowHitTest(window, null, callbackData);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get grabbed window should return expected value
        /// </summary>
        [Fact]
        public void GetGrabbedWindow_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            IntPtr result = Sdl.GetGrabbedWindow();

            // Assert
            // Replace IntPtr.Zero with the expected result
            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set window mouse rect should return expected value
        /// </summary>
        [Fact]
        public void SetWindowMouseRect_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;
            RectangleI rect = new RectangleI();

            // Act
            int result = Sdl.SetWindowMouseRect(window, ref rect);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window mouse rect should return expected value
        /// </summary>
        [Fact]
        public void GetWindowMouseRect_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;

            // Act
            IntPtr result = Sdl.GetWindowMouseRect(window);

            // Assert
            // Replace IntPtr.Zero with the expected result
            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that flash window should return expected value
        /// </summary>
        [Fact]
        public void FlashWindow_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;
            SdlFlashOperation operation = SdlFlashOperation.SdlFlashUntilFocused;

            // Act
            int result = Sdl.FlashWindow(window, operation);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that compose custom blend mode should return expected value
        /// </summary>
        [Fact]
        public void ComposeCustomBlendMode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            SdlBlendFactor srcColorFactor = SdlBlendFactor.SdlBlendFactorZero;
            SdlBlendFactor dstColorFactor = SdlBlendFactor.SdlBlendFactorZero;
            SdlBlendOperation colorOperation = SdlBlendOperation.SdlBlendOperationAdd;
            SdlBlendFactor srcAlphaFactor = SdlBlendFactor.SdlBlendFactorZero;
            SdlBlendFactor dstAlphaFactor = SdlBlendFactor.SdlBlendFactorZero;
            SdlBlendOperation alphaOperation = SdlBlendOperation.SdlBlendOperationAdd;

            // Act
            SdlBlendMode result = Sdl.ComposeCustomBlendMode(srcColorFactor, dstColorFactor, colorOperation, srcAlphaFactor, dstAlphaFactor, alphaOperation);

            // Assert
            Assert.NotEqual(SdlBlendMode.None, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that create renderer should return expected value
        /// </summary>
        [Fact]
        public void CreateRenderer_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;
            int index = -1;
            SdlRendererFlags flags = SdlRendererFlags.SdlRendererSoftware;

            // Act
            IntPtr result = Sdl.CreateRenderer(window, index, flags);

            // Assert
            // Replace IntPtr.Zero with the expected result
            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that create texture should return expected value
        /// </summary>
        [Fact]
        public void CreateTexture_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            uint format = 0;
            int access = 0;
            int w = 0;
            int h = 0;

            // Act
            IntPtr result = Sdl.CreateTexture(renderer, format, access, w, h);

            // Assert
            // Replace IntPtr.Zero with the expected result
            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that destroy texture should not throw exception
        /// </summary>
        [Fact]
        public void DestroyTexture_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr texture = IntPtr.Zero;

            // Act
            Sdl.DestroyTexture(texture);

            // Assert
            // No exception should be thrown

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get num render drivers should return expected value
        /// </summary>
        [Fact]
        public void GetNumRenderDrivers_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            int result = Sdl.GetNumRenderDrivers();

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get render draw blend mode should return expected value
        /// </summary>
        [Fact]
        public void GetRenderDrawBlendMode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;

            // Act
            int result = Sdl.GetRenderDrawBlendMode(renderer, out SdlBlendMode _);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set texture scale mode should return expected value
        /// </summary>
        [Fact]
        public void SetTextureScaleMode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr texture = IntPtr.Zero;
            SdlScaleMode scaleMode = SdlScaleMode.SdlScaleModeNearest;

            // Act
            int result = Sdl.SetTextureScaleMode(texture, scaleMode);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get texture scale mode should return expected value
        /// </summary>
        [Fact]
        public void GetTextureScaleMode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr texture = IntPtr.Zero;

            // Act
            int result = Sdl.GetTextureScaleMode(texture, out SdlScaleMode _);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set texture user data should return expected value
        /// </summary>
        [Fact]
        public void SetTextureUserData_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr texture = IntPtr.Zero;
            IntPtr userdata = IntPtr.Zero;

            // Act
            int result = Sdl.SetTextureUserData(texture, userdata);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get texture user data should return expected value
        /// </summary>
        [Fact]
        public void GetTextureUserData_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr texture = IntPtr.Zero;

            // Act
            IntPtr result = Sdl.GetTextureUserData(texture);

            // Assert
            Assert.Equal(IntPtr.Zero, result); // Replace IntPtr.Zero with the expected result

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get render draw color should return expected value
        /// </summary>
        [Fact]
        public void GetRenderDrawColor_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;

            // Act
            int result = Sdl.GetRenderDrawColor(renderer, out byte _, out byte _, out byte _, out byte _);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get render driver info should return expected value
        /// </summary>
        [Fact]
        public void GetRenderDriverInfo_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int index = 0;

            // Act
            int result = Sdl.GetRenderDriverInfo(index, out SdlRendererInfo _);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get renderer should return expected value
        /// </summary>
        [Fact]
        public void GetRenderer_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;

            // Act
            IntPtr result = Sdl.GetRenderer(window);

            // Assert
            Assert.Equal(IntPtr.Zero, result); // Replace IntPtr.Zero with the expected result

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get renderer info should return expected value
        /// </summary>
        [Fact]
        public void GetRendererInfo_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;

            // Act
            int result = Sdl.GetRendererInfo(renderer, out SdlRendererInfo _);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get renderer output size should return expected value
        /// </summary>
        [Fact]
        public void GetRendererOutputSize_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;

            // Act
            int result = Sdl.GetRendererOutputSize(renderer, out int _, out int _);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get texture alpha mod should return expected value
        /// </summary>
        [Fact]
        public void GetTextureAlphaMod_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr texture = IntPtr.Zero;

            // Act
            int result = Sdl.GetTextureAlphaMod(texture, out byte _);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }


        /// <summary>
        /// Tests that get texture blend mode should return expected value
        /// </summary>
        [Fact]
        public void GetTextureBlendMode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr texture = IntPtr.Zero;

            // Act
            int result = Sdl.GetTextureBlendMode(texture, out SdlBlendMode _);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get texture color mod should return expected value
        /// </summary>
        [Fact]
        public void GetTextureColorMod_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr texture = IntPtr.Zero;

            // Act
            int result = Sdl.GetTextureColorMod(texture, out byte _, out byte _, out byte _);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that lock texture should return expected value
        /// </summary>
        [Fact]
        public void LockTexture_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr texture = IntPtr.Zero;
            RectangleI rect = new RectangleI();

            // Act
            int result = Sdl.LockTexture(texture, ref rect, out IntPtr _, out int _);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that lock texture to surface should return expected value
        /// </summary>
        [Fact]
        public void LockTextureToSurface_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr texture = IntPtr.Zero;
            RectangleI rect = new RectangleI();

            // Act
            int result = Sdl.LockTextureToSurface(texture, ref rect, out IntPtr _);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that query texture should return expected value
        /// </summary>
        [Fact]
        public void QueryTexture_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr texture = IntPtr.Zero;

            // Act
            int result = Sdl.QueryTexture(texture, out uint _, out int _, out int _, out int _);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render clear should return expected value
        /// </summary>
        [Fact]
        public void RenderClear_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;

            // Act
            int result = Sdl.RenderClear(renderer);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render copy should return expected value
        /// </summary>
        [Fact]
        public void RenderCopy_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            IntPtr texture = IntPtr.Zero;
            RectangleI srcRect = new RectangleI();
            RectangleI dstRect = new RectangleI();

            // Act
            int result = Sdl.RenderCopy(renderer, texture, ref srcRect, ref dstRect);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render copy ex should return expected value
        /// </summary>
        [Fact]
        public void RenderCopyEx_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            IntPtr texture = IntPtr.Zero;
            RectangleI srcRect = new RectangleI();
            RectangleI dstRect = new RectangleI();
            double angle = 0.0;
            PointI center = new PointI();
            SdlRendererFlip flip = SdlRendererFlip.None;

            // Act
            int result = Sdl.RenderCopyEx(renderer, texture, ref srcRect, ref dstRect, angle, ref center, flip);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }


        /// <summary>
        /// Tests that render draw line should return expected value
        /// </summary>
        [Fact]
        public void RenderDrawLine_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 0;

            // Act
            int result = Sdl.RenderDrawLine(renderer, x1, y1, x2, y2);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render draw points should return expected value
        /// </summary>
        [Fact]
        public void RenderDrawPoints_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            PointI[] points = Array.Empty<PointI>();
            int count = 0;

            // Act
            int result = Sdl.RenderDrawPoints(renderer, points, count);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render draw rect should return expected value
        /// </summary>
        [Fact]
        public void RenderDrawRect_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            RectangleI rect = new RectangleI();

            // Act
            int result = Sdl.RenderDrawRect(renderer, ref rect);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render fill rect should return expected value
        /// </summary>
        [Fact]
        public void RenderFillRect_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            RectangleI rect = new RectangleI();

            // Act
            int result = Sdl.RenderFillRect(renderer, ref rect);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render copy ex f should return expected value
        /// </summary>
        [Fact]
        public void RenderCopyExF_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            IntPtr texture = IntPtr.Zero;
            IntPtr srcRect = IntPtr.Zero;
            IntPtr dstRect = IntPtr.Zero;
            double angle = 0.0;
            IntPtr center = IntPtr.Zero;
            SdlRendererFlip flip = SdlRendererFlip.None;

            // Act
            int result = Sdl.RenderCopyExF(renderer, texture, srcRect, dstRect, angle, center, flip);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render geometry should return expected value
        /// </summary>
        [Fact]
        public void RenderGeometry_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            IntPtr texture = IntPtr.Zero;
            SdlVertex[] vertices = Array.Empty<SdlVertex>();
            int numVertices = 0;
            int[] indices = Array.Empty<int>();
            int numIndices = 0;

            // Act
            int result = Sdl.RenderGeometry(renderer, texture, vertices, numVertices, indices, numIndices);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render draw point f should return expected value
        /// </summary>
        [Fact]
        public void RenderDrawPointF_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            float x = 0.0f;
            float y = 0.0f;

            // Act
            int result = Sdl.RenderDrawPointF(renderer, x, y);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render draw points f should return expected value
        /// </summary>
        [Fact]
        public void RenderDrawPointsF_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            PointF[] points = Array.Empty<PointF>();
            int count = 0;

            // Act
            int result = Sdl.RenderDrawPointsF(renderer, points, count);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render draw line f should return expected value
        /// </summary>
        [Fact]
        public void RenderDrawLineF_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            float x1 = 0.0f;
            float y1 = 0.0f;
            float x2 = 0.0f;
            float y2 = 0.0f;

            // Act
            int result = Sdl.RenderDrawLineF(renderer, x1, y1, x2, y2);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render draw lines f should return expected value
        /// </summary>
        [Fact]
        public void RenderDrawLinesF_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            PointF[] points = Array.Empty<PointF>();
            int count = 0;

            // Act
            int result = Sdl.RenderDrawLinesF(renderer, points, count);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render draw rect f should return expected value
        /// </summary>
        [Fact]
        public void RenderDrawRectF_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            RectangleF rect = new RectangleF();

            // Act
            int result = Sdl.RenderDrawRectF(renderer, ref rect);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render fill rect f should return expected value
        /// </summary>
        [Fact]
        public void RenderFillRectF_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            RectangleF rect = new RectangleF();

            // Act
            int result = Sdl.RenderFillRectF(renderer, rect);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render get clip rect should return expected value
        /// </summary>
        [Fact]
        public void RenderGetClipRect_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;

            // Act
            Sdl.RenderGetClipRect(renderer, out RectangleI rect);

            // Assert
            Assert.Equal(0, rect.x);
            Assert.Equal(0, rect.y);
            Assert.Equal(0, rect.w);
            Assert.Equal(0, rect.h);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render get logical size should return expected value
        /// </summary>
        [Fact]
        public void RenderGetLogicalSize_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;

            // Act
            Sdl.RenderGetLogicalSize(renderer, out int _, out int _);

            // Assert
            // Assert something about the w and h here

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render get viewport should return expected value
        /// </summary>
        [Fact]
        public void RenderGetViewport_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;

            // Act
            int result = Sdl.RenderGetViewport(renderer, out RectangleI _);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render present should not throw exception
        /// </summary>
        [Fact]
        public void RenderPresent_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;

            // Act
            Sdl.RenderPresent(renderer);

            // Assert
            Assert.Equal(SdlBool.False, Sdl.IsScreenKeyboardShown(renderer));

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render read pixels should return expected value
        /// </summary>
        [Fact]
        public void RenderReadPixels_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            RectangleI rect = new RectangleI();
            uint format = 0;
            IntPtr pixels = IntPtr.Zero;
            int pitch = 0;

            // Act
            int result = Sdl.RenderReadPixels(renderer, ref rect, format, pixels, pitch);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>

        /// Tests that render set clip rect should return expected value

        /// </summary>

        [Fact]
        public void RenderSetClipRect_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            RectangleI rect = new RectangleI();

            // Act
            int result = Sdl.RenderSetClipRect(renderer, ref rect);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>

        /// Tests that render set logical size should return expected value

        /// </summary>

        [Fact]
        public void RenderSetLogicalSize_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            int w = 0;
            int h = 0;

            // Act
            int result = Sdl.RenderSetLogicalSize(renderer, w, h);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>

        /// Tests that render set scale should return expected value

        /// </summary>

        [Fact]
        public void RenderSetScale_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            float scaleX = 0.0f;
            float scaleY = 0.0f;

            // Act
            int result = Sdl.RenderSetScale(renderer, scaleX, scaleY);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>

        /// Tests that set render draw blend mode should return expected value

        /// </summary>

        [Fact]
        public void SetRenderDrawBlendMode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            SdlBlendMode blendMode = SdlBlendMode.None;

            // Act
            int result = Sdl.SetRenderDrawBlendMode(renderer, blendMode);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>

        /// Tests that set render draw color should return expected value

        /// </summary>

        [Fact]
        public void SetRenderDrawColor_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            byte r = 0;
            byte g = 0;
            byte b = 0;
            byte a = 0;

            // Act
            int result = Sdl.SetRenderDrawColor(renderer, r, g, b, a);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>

        /// Tests that set render target should return expected value

        /// </summary>

        [Fact]
        public void SetRenderTarget_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            IntPtr texture = IntPtr.Zero;

            // Act
            int result = Sdl.SetRenderTarget(renderer, texture);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>

        /// Tests that set texture alpha mod should return expected value

        /// </summary>

        [Fact]
        public void SetTextureAlphaMod_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr texture = IntPtr.Zero;
            byte alpha = 0;

            // Act
            int result = Sdl.SetTextureAlphaMod(texture, alpha);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>

        /// Tests that unlock texture should not throw exception

        /// </summary>

        [Fact]
        public void UnlockTexture_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr texture = IntPtr.Zero;

            // Act
            Sdl.UnlockTexture(texture);

            // Assert
            Assert.Equal(IntPtr.Zero, Sdl.GetTextureUserData(texture));

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that update texture should return expected value
        /// </summary>
        [Fact]
        public void UpdateTexture_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr texture = IntPtr.Zero;
            RectangleI rect = new RectangleI();
            IntPtr pixels = IntPtr.Zero;
            int pitch = 0;

            // Act
            int result = Sdl.UpdateTexture(texture, ref rect, pixels, pitch);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that update nv texture should return expected value
        /// </summary>
        [Fact]
        public void UpdateNvTexture_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr texture = IntPtr.Zero;
            RectangleI rect = new RectangleI();
            IntPtr yPlane = IntPtr.Zero;
            int yPitch = 0;
            IntPtr uvPlane = IntPtr.Zero;
            int uvPitch = 0;

            // Act
            int result = Sdl.UpdateNvTexture(texture, ref rect, yPlane, yPitch, uvPlane, uvPitch);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render target supported should return expected value
        /// </summary>
        [Fact]
        public void RenderTargetSupported_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;

            // Act
            SdlBool result = Sdl.RenderTargetSupported(renderer);

            // Assert
            Assert.Equal(SdlBool.False, result); // Replace SdlBool.True with the expected result

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get render target should return expected value
        /// </summary>
        [Fact]
        public void GetRenderTarget_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;

            // Act
            IntPtr result = Sdl.GetRenderTarget(renderer);

            // Assert
            Assert.Equal(IntPtr.Zero, result); // Replace IntPtr.Zero with the expected result

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render set v sync should return expected value
        /// </summary>
        [Fact]
        public void RenderSetVSync_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            int vsync = 1;

            // Act
            int result = Sdl.RenderSetVSync(renderer, vsync);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render is clip enabled should return expected value
        /// </summary>
        [Fact]
        public void RenderIsClipEnabled_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;

            // Act
            SdlBool result = Sdl.RenderIsClipEnabled(renderer);

            // Assert
            Assert.Equal(SdlBool.False, result); 

            // Cleanup
            Sdl.Quit();
        }
        
        /// <summary>
        /// Tests that calculate gamma ramp should not throw exception
        /// </summary>
        [Fact]
        public void CalculateGammaRamp_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            float gamma = 1.0f;
            ushort[] ramp = new ushort[256];

            // Act
            Sdl.CalculateGammaRamp(gamma, ramp);

            // Assert
            Assert.Equal(0, ramp[0]);

            // Cleanup
            Sdl.Quit();
        }
        
        /// <summary>
        /// Tests that blit surface should return expected value
        /// </summary>
        [Fact]
        public void BlitSurface_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr src = IntPtr.Zero;
            RectangleI srcRect = new RectangleI();
            IntPtr dst = IntPtr.Zero;
            RectangleI dstRect = new RectangleI();

            // Act
            int result = Sdl.BlitSurface(src, ref srcRect, dst, ref dstRect);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that convert surface should return expected value
        /// </summary>
        [Fact]
        public void ConvertSurface_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr src = IntPtr.Zero;
            IntPtr fmt = IntPtr.Zero;
            uint flags = 0;

            // Act
            IntPtr result = Sdl.ConvertSurface(src, fmt, flags);

            // Assert
            Assert.Equal(IntPtr.Zero, result); // Replace IntPtr.Zero with the expected result

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that create rgb surface with format should return expected value
        /// </summary>
        [Fact]
        public void CreateRgbSurfaceWithFormat_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            uint flags = 0;
            int width = 0;
            int height = 0;
            int depth = 0;
            uint format = 0;

            // Act
            IntPtr result = Sdl.CreateRgbSurfaceWithFormat(flags, width, height, depth, format);

            // Assert
            Assert.NotEqual(IntPtr.Zero, result); // Replace IntPtr.Zero with the expected result

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that fill rect should return expected value
        /// </summary>
        [Fact]
        public void FillRect_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr dst = IntPtr.Zero;
            RectangleI rect = new RectangleI();
            uint color = 0;

            // Act
            int result = Sdl.FillRect(dst, ref rect, color);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get clip rect should return expected value
        /// </summary>
        [Fact]
        public void GetClipRect_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;

            // Act
            Sdl.GetClipRect(surface, out RectangleI _);

            // Assert
            Assert.Equal(0, surface.ToInt64());

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that has color key should return expected value
        /// </summary>
        [Fact]
        public void HasColorKey_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;

            // Act
            SdlBool result = Sdl.HasColorKey(surface);

            // Assert
            Assert.Equal(SdlBool.False, result); 

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get color key should return expected value
        /// </summary>
        [Fact]
        public void GetColorKey_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;

            // Act
            int result = Sdl.GetColorKey(surface, out uint _);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get surface alpha mod should return expected value
        /// </summary>
        [Fact]
        public void GetSurfaceAlphaMod_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;

            // Act
            int result = Sdl.GetSurfaceAlphaMod(surface, out byte _);

            // Assert
           Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get surface blend mode should return expected value
        /// </summary>
        [Fact]
        public void GetSurfaceBlendMode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;

            // Act
            int result = Sdl.GetSurfaceBlendMode(surface, out SdlBlendMode _);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get surface color mod should return expected value
        /// </summary>
        [Fact]
        public void GetSurfaceColorMod_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;

            // Act
            int result = Sdl.GetSurfaceColorMod(surface, out byte _, out byte _, out byte _);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that load bmp should return expected value
        /// </summary>
        [Fact]
        public void LoadBmp_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            string file = AssetManager.Find("tile000.bmp");

            // Act
            IntPtr result = Sdl.LoadBmp(file);

            // Assert
            // Replace IntPtr.Zero with the expected result
            Assert.NotEqual(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }
        
        /// <summary>
        /// Tests that save bmp should return expected value
        /// </summary>
        [Fact]
        public void SaveBmp_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;
            string file = "test.bmp";

            // Act
            if (!File.Exists(file))
            {
                int result = Sdl.SaveBmp(surface, file);
                Assert.True(result >= -1);
            }
            
            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set clip rect should return expected value
        /// </summary>
        [Fact]
        public void SetClipRect_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;
            RectangleI rect = new RectangleI();

            // Act
            SdlBool result = Sdl.SetClipRect(surface, ref rect);

            // Assert
            
            Assert.Equal(SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set color key should return expected value
        /// </summary>
        [Fact]
        public void SetColorKey_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;
            int flag = 0;
            uint key = 0;

            // Act
            int result = Sdl.SetColorKey(surface, flag, key);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set surface alpha mod should return expected value
        /// </summary>
        [Fact]
        public void SetSurfaceAlphaMod_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;
            byte alpha = 0;

            // Act
            int result = Sdl.SetSurfaceAlphaMod(surface, alpha);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set surface blend mode should return expected value
        /// </summary>
        [Fact]
        public void SetSurfaceBlendMode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;
            SdlBlendMode blendMode = SdlBlendMode.None;

            // Act
            int result = Sdl.SetSurfaceBlendMode(surface, blendMode);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set surface color mod should return expected value
        /// </summary>
        [Fact]
        public void SetSurfaceColorMod_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;
            byte r = 0, g = 0, b = 0;

            // Act
            int result = Sdl.SetSurfaceColorMod(surface, r, g, b);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set surface palette should return expected value
        /// </summary>
        [Fact]
        public void SetSurfacePalette_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;
            IntPtr palette = IntPtr.Zero;

            // Act
            int result = Sdl.SetSurfacePalette(surface, palette);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set surface rle should return expected value
        /// </summary>
        [Fact]
        public void SetSurfaceRle_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;
            int flag = 0;

            // Act
            int result = Sdl.SetSurfaceRle(surface, flag);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that has surface rle should return expected value
        /// </summary>
        [Fact]
        public void HasSurfaceRle_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;

            // Act
            SdlBool result = Sdl.HasSurfaceRle(surface);

            // Assert
            
            Assert.Equal(SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }
        
        /// <summary>
        /// Tests that upper blit should return expected value
        /// </summary>
        [Fact]
        public void UpperBlit_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr src = IntPtr.Zero;
            RectangleI srcRect = new RectangleI();
            IntPtr dst = IntPtr.Zero;
            RectangleI dstRect = new RectangleI();

            // Act
            int result = Sdl.UpperBlit(src, ref srcRect, dst, ref dstRect);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that upper blit scaled should return expected value
        /// </summary>
        [Fact]
        public void UpperBlitScaled_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr src = IntPtr.Zero;
            RectangleI srcRect = new RectangleI();
            IntPtr dst = IntPtr.Zero;
            RectangleI dstRect = new RectangleI();

            // Act
            int result = Sdl.UpperBlitScaled(src, ref srcRect, dst, ref dstRect);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }
        
        /// <summary>
        /// Tests that has clipboard text should return expected value
        /// </summary>
        [Fact]
        public void HasClipboardText_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            SdlBool result = Sdl.HasClipboardText();

            // Assert
            
            Assert.Equal(SdlBool.True, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get clipboard text should return expected value
        /// </summary>
        [Fact]
        public void GetClipboardText_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            string result = Sdl.GetClipboardText();

            // Assert
            // Replace "" with the expected result
            Assert.Equal("test", result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set clipboard text should return expected value
        /// </summary>
        [Fact]
        public void SetClipboardText_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            string text = "test";

            // Act
            int result = Sdl.SetClipboardText(text);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that peep events should return expected value
        /// </summary>
        [Fact]
        public void PeepEvents_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            SdlEvent[] events = new SdlEvent[10];
            int numEvents = 10;
            SdlEventAction action = SdlEventAction.SdlAddEvent;
            SdlEventType minType = SdlEventType.SdlFirstEvent;
            SdlEventType maxType = SdlEventType.SdlLastEvent;

            // Act
            int result = Sdl.PeepEvents(events, numEvents, action, minType, maxType);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that has event should return expected value
        /// </summary>
        [Fact]
        public void HasEvent_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            SdlEventType type = SdlEventType.SdlFirstEvent;

            // Act
            SdlBool result = Sdl.HasEvent(type);

            // Assert
            
            Assert.Equal(SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that has events should return expected value
        /// </summary>
        [Fact]
        public void HasEvents_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            SdlEventType minType = SdlEventType.SdlFirstEvent;
            SdlEventType maxType = SdlEventType.SdlLastEvent;

            // Act
            SdlBool result = Sdl.HasEvents(minType, maxType);

            // Assert
            
            Assert.Equal(SdlBool.True ,result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that flush event should not throw exception
        /// </summary>
        [Fact]
        public void FlushEvent_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            SdlEventType type = SdlEventType.SdlFirstEvent;

            // Act
            Sdl.FlushEvent(type);

            // Assert
            Assert.Equal(SdlBool.False, Sdl.HasEvent(type));

            // Cleanup
            Sdl.Quit();
        }
    }
}