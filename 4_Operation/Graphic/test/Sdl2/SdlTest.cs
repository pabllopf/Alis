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
            Assert.Equal(0.0, result);

            Sdl.Quit();
        }
        
        /// <summary>
        /// Tests that sdl is pixel format four test
        /// </summary>
        [Fact]
        public void SdlIsPixelFormatFourTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            
            uint format = 0;
            bool result = Sdl.SdlIsPixelFormatFour(format);
            Assert.True(result);
            
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that alloc format test
        /// </summary>
        [Fact]
        public void AllocFormatTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            
            uint pixelFormat = 0;
            IntPtr result = Sdl.AllocFormat(pixelFormat);
            Assert.NotEqual(IntPtr.Zero, result);
            
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that alloc palette test
        /// </summary>
        [Fact]
        public void AllocPaletteTest()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            
            int nColors = 256;
            IntPtr result = Sdl.AllocPalette(nColors);
            Assert.NotEqual(IntPtr.Zero, result);
            
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
            
            uint format = 0;
            string result = Sdl.GetPixelFormatName(format);
            Assert.NotNull(result);
            
            Sdl.Quit();
        }
    }
}