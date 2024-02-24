// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlTestP1.cs
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
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Math.Shape.Point;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;
using Xunit;
using Version = Alis.Core.Graphic.Sdl2.Structs.Version;

namespace Alis.Core.Graphic.Test.Sdl2
{
    /// <summary>
    ///     The sdl test class
    /// </summary>
    public class SdlTestP1
    {
        /// <summary>
        ///     Tests that test init
        /// </summary>
        [Fact]
        public void TestInit()
        {
            // Arrange
            const Init expected = Init.InitEverything;

            // Act
            int result = Sdl.Init(expected);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get gl compiled version
        /// </summary>
        [Fact]
        public void TestGetGlCompiledVersion()
        {
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            int controllersAvailable = Sdl.NumJoysticks();
            if (controllersAvailable >= 1)
            {
                IntPtr controller = Sdl.GameControllerOpen(0);

                // Act
                int result = Sdl.GameControllerSetLed(controller, 255, 255, 255);

                // Assert
                Assert.True(result >= -1);
            }

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test game controller has axis
        /// </summary>
        [Fact]
        public void TestGameControllerHasAxis()
        {
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            int controllersAvailable = Sdl.NumJoysticks();
            if (controllersAvailable >= 1)
            {
                IntPtr gameController = Sdl.GameControllerOpen(0);

                // Act
                const GameControllerAxis axis = new GameControllerAxis();

                // Act
                bool result = Sdl.GameControllerHasAxis(gameController, axis);

                // Assert
                Assert.True(result);
            }

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test game controller has button
        /// </summary>
        [Fact]
        public void TestGameControllerHasButton()
        {
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            int controllersAvailable = Sdl.NumJoysticks();
            if (controllersAvailable >= 1)
            {
                IntPtr gameController = Sdl.GameControllerOpen(0);

                // Act
                const GameControllerButton button = new GameControllerButton();

                // Act
                bool result = Sdl.GameControllerHasButton(gameController, button);

                // Assert
                Assert.True(result);
            }

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test close audio device
        /// </summary>
        [Fact]
        public void TestCloseAudioDevice()
        {
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            int audioDevices = Sdl.GetNumAudioDevices(0);
            if (audioDevices >= 1)
            {
                string nameAudioDevice = Sdl.GetAudioDeviceName(0, 0);

                AudioSpec spec = new AudioSpec();

                // Arrange
                uint dev = Sdl.SdlOpenAudioDevice(nameAudioDevice, 0, ref spec, out AudioSpec obtained, 0);

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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            int index = 0;
            int isCapture = 0;

            // Act
            string result = Sdl.GetAudioDeviceName(index, isCapture);

            // Assert

            Assert.NotEqual("", result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get audio device status
        /// </summary>
        [Fact]
        public void TestGetAudioDeviceStatus()
        {
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            uint dev = 0;

            // Act
            AudioStatus result = Sdl.GetAudioDeviceStatus(dev);

            // Assert

            Assert.Equal(AudioStatus.SdlAudioStopped, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get audio driver
        /// </summary>
        [Fact]
        public void TestGetAudioDriver()
        {
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            int index = 0;

            // Act
            string result = Sdl.GetAudioDriver(index);

            // Assert

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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            string result = Sdl.GetCurrentAudioDriver();

            // Assert

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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            int gNumAudioDevices = Sdl.GetNumAudioDevices(0);
            if (gNumAudioDevices >= 1)
            {
                // Arrange
                const int isCapture = 0;

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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            int result = Sdl.GetNumAudioDrivers();

            // Assert

            Assert.NotEqual(0, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test load wav
        /// </summary>
        [Fact]
        public void TestLoadWav()
        {
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            string file = AssetManager.Find("AudioSample.wav");

            // Act
            IntPtr result = Sdl.LoadWav(file, out AudioSpec _, out IntPtr audioBuf, out uint audioLen);

            // Assert

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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            const uint dev = 0;

            // Act
            Sdl.LockAudioDevice(dev);

            Assert.Equal(AudioStatus.SdlAudioStopped, Sdl.GetAudioDeviceStatus(dev));

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test mix audio
        /// </summary>
        [Fact]
        public void TestMixAudio()
        {
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            byte[] dst = new byte[10];
            byte[] src = new byte[10];
            uint len = 10;
            int volume = 128;

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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            IntPtr dst = new IntPtr();
            IntPtr src = new IntPtr();
            ushort format = 0;
            uint len = 10;
            int volume = 128;

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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            string device = "dummy";
            int isCapture = 0;
            AudioSpec desired = new AudioSpec();
            int allowedChanges = 0;

            // Act
            uint result = Sdl.SdlOpenAudioDevice(device, isCapture, ref desired, out AudioSpec _, allowedChanges);

            // Assert

            Assert.Equal(0.0, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test pause audio
        /// </summary>
        [Fact]
        public void TestPauseAudio()
        {
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            int pauseOn = 0;

            // Act
            Sdl.SdlPauseAudio(pauseOn);

            // Assert
            Assert.Equal(AudioStatus.SdlAudioStopped, Sdl.GetAudioDeviceStatus(0));

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test pause audio device
        /// </summary>
        [Fact]
        public void TestPauseAudioDevice()
        {
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            uint dev = 0;
            int pauseOn = 0;

            // Act
            Sdl.SdlPauseAudioDevice(dev, pauseOn);

            // Assert
            Assert.Equal(AudioStatus.SdlAudioStopped, Sdl.GetAudioDeviceStatus(dev));

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test unlock audio device
        /// </summary>
        [Fact]
        public void TestUnlockAudioDevice()
        {
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            uint dev = 0;

            // Act
            Sdl.SdlUnlockAudioDevice(dev);

            // Assert
            Assert.Equal(AudioStatus.SdlAudioStopped, Sdl.GetAudioDeviceStatus(dev));

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test fourcc
        /// </summary>
        [Fact]
        public void TestFourcc()
        {
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Version result = Sdl.GetVersion();

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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            const string name = "testName";
            const string value = "testValue";

            // Act
            bool result = Sdl.SetHint(name, value);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that test get hint
        /// </summary>
        [Fact]
        public void TestGetHint()
        {
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Arrange
            const string name = "testName";
            const string value = "testValue";

            // Act
            bool setResult = Sdl.SetHint(name, value);
            Assert.True(setResult);

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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            const string name = "testName";
            const string value = "testValue";

            // Act
            bool result = Sdl.SetHint(name, value);

            // Assert
            Assert.True(result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get hint should return correct value when valid hint is passed
        /// </summary>
        [Fact]
        public void TestGetHint_ShouldReturnCorrectValue_WhenValidHintIsPassed()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            ulong result = Sdl.GetPerformanceFrequency();

            // Assert
            Assert.True(result > 0);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test internal set window position should not throw exception
        /// </summary>
        [Fact]
        public void TestInternalSetWindowPosition_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = new IntPtr();
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);

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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Version result = Sdl.GetVersion();

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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            const string name = "testName";
            const string value = "testValue";

            // Act
            bool result = Sdl.SetHint(name, value);

            // Assert
            Assert.True(result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl get hint should return correct value when valid hint is passed
        /// </summary>
        [Fact]
        public void TestSdlGetHint_ShouldReturnCorrectValue_WhenValidHintIsPassed()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            Init flags = Init.InitEverything;

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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            string name = "TestHint";
            string value = "TestValue";

            // Act
            bool result = Sdl.SetHint(name, value);

            // Assert
            Assert.True(result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test set hint with priority should return expected value
        /// </summary>
        [Fact]
        public void TestSetHintWithPriority_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            string name = "TestHint";
            string value = "TestValue";
            HintPriority priority = HintPriority.SdlHintOverride;

            // Act
            bool result = Sdl.SetHintWithPriority(name, value, priority);

            // Assert
            Assert.True(result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get hint boolean should return expected value
        /// </summary>
        [Fact]
        public void TestGetHintBoolean_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            string name = "TestHint";
            bool defaultValue = false;

            // Act
            bool result = Sdl.GetHintBoolean(name, defaultValue);

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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Version result = Sdl.GetVersion();

            // Assert
            Assert.Equal(new Version(2, 0, 18), result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test window pos undefined display should return expected value
        /// </summary>
        [Fact]
        public void TestWindowPosUndefinedDisplay_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            int x = 10;

            // Act
            int result = Sdl.WindowPosUndefinedDisplay(x);

            // Assert
            Assert.Equal((int) (WindowPos.WindowPosUndefinedMask | (WindowPos) x), result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test window pos is undefined should return expected value
        /// </summary>
        [Fact]
        public void TestWindowPosIsUndefined_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            int x = (int) WindowPos.WindowPosUndefinedMask;

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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            int x = 10;

            // Act
            int result = Sdl.WindowPosCenteredDisplay(x);

            // Assert
            Assert.Equal((int) (WindowPos.WindowPosCenteredMask | (WindowPos) x), result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test window pos is centered should return expected value
        /// </summary>
        [Fact]
        public void TestWindowPosIsCentered_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            int x = (int) WindowPos.WindowPosCenteredMask;

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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            string title = "Test Window";
            int x = 10;
            int y = 10;
            int w = 800;
            int h = 600;

            // CONFIG THE SDL2 AN OPENGL CONFIGURATION
            Sdl.SetAttributeByInt(GlAttr.SdlGlContextFlags, (int) GlContexts.SdlGlContextForwardCompatibleFlag);
            Sdl.SetAttributeByProfile(GlAttr.SdlGlContextProfileMask, GlProfiles.SdlGlContextProfileCore);
            Sdl.SetAttributeByInt(GlAttr.SdlGlContextMajorVersion, 3);
            Sdl.SetAttributeByInt(GlAttr.SdlGlContextMinorVersion, 2);

            Sdl.SetAttributeByProfile(GlAttr.SdlGlContextProfileMask, GlProfiles.SdlGlContextProfileCore);
            Sdl.SetAttributeByInt(GlAttr.SdlGlDoubleBuffer, 1);
            Sdl.SetAttributeByInt(GlAttr.SdlGlDepthSize, 24);
            Sdl.SetAttributeByInt(GlAttr.SdlGlAlphaSize, 8);
            Sdl.SetAttributeByInt(GlAttr.SdlGlStencilSize, 8);

            // Enable vsync
            Sdl.SetSwapInterval(1);

            // create the window which should be able to have a valid OpenGL context and is resizable
            WindowSettings flags = WindowSettings.WindowOpengl | WindowSettings.WindowResizable | WindowSettings.WindowMaximized;

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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            int width = 800;
            int height = 600;

            // CONFIG THE SDL2 AN OPENGL CONFIGURATION
            Sdl.SetAttributeByInt(GlAttr.SdlGlContextFlags, (int) GlContexts.SdlGlContextForwardCompatibleFlag);
            Sdl.SetAttributeByProfile(GlAttr.SdlGlContextProfileMask, GlProfiles.SdlGlContextProfileCore);
            Sdl.SetAttributeByInt(GlAttr.SdlGlContextMajorVersion, 3);
            Sdl.SetAttributeByInt(GlAttr.SdlGlContextMinorVersion, 2);

            Sdl.SetAttributeByProfile(GlAttr.SdlGlContextProfileMask, GlProfiles.SdlGlContextProfileCore);
            Sdl.SetAttributeByInt(GlAttr.SdlGlDoubleBuffer, 1);
            Sdl.SetAttributeByInt(GlAttr.SdlGlDepthSize, 24);
            Sdl.SetAttributeByInt(GlAttr.SdlGlAlphaSize, 8);
            Sdl.SetAttributeByInt(GlAttr.SdlGlStencilSize, 8);

            // Enable vsync
            Sdl.SetSwapInterval(1);

            // create the window which should be able to have a valid OpenGL context and is resizable
            const WindowSettings flags = WindowSettings.WindowOpengl | WindowSettings.WindowResizable | WindowSettings.WindowMaximized;

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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            string title = "Test Window";
            int x = 10;
            int y = 10;
            int w = 800;
            int h = 600;
            WindowSettings flags = WindowSettings.WindowShown;
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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            int displayIndex = 0;
            DisplayMode mode = new DisplayMode();

            // Act
            IntPtr result = Sdl.GetClosestDisplayMode(displayIndex, ref mode, out DisplayMode _);

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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            int displayIndex = 0;

            // Act
            int result = Sdl.GetCurrentDisplayMode(displayIndex, out DisplayMode _);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get current video driver should return expected value
        /// </summary>
        [Fact]
        public void TestGetCurrentVideoDriver_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            int displayIndex = 0;

            // Act
            int result = Sdl.GetDesktopDisplayMode(displayIndex, out DisplayMode _);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get display name should return expected value
        /// </summary>
        [Fact]
        public void TestGetDisplayName_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            int displayIndex = 0;

            // Act
            int result = Sdl.GetDisplayBounds(displayIndex, out RectangleI _);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get display dpi should return expected value
        /// </summary>
        [Fact]
        public void TestGetDisplayDpi_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            int displayIndex = 0;
            int modeIndex = 0;

            // Act
            int result = Sdl.GetDisplayMode(displayIndex, modeIndex, out DisplayMode _);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get display usable bounds should return expected value
        /// </summary>
        [Fact]
        public void TestGetDisplayUsableBounds_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            int displayIndex = 0;

            // Act
            int result = Sdl.GetDisplayUsableBounds(displayIndex, out RectangleI _);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get num display modes should return expected value
        /// </summary>
        [Fact]
        public void TestGetNumDisplayModes_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            string title = "Test Window";
            int x = 10;
            int y = 10;
            int w = 800;
            int h = 600;
            WindowSettings flags = WindowSettings.WindowShown;
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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            string title = "Test Window";
            int x = 10;
            int y = 10;
            int w = 800;
            int h = 600;
            WindowSettings flags = WindowSettings.WindowShown;
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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            string title = "Test Window";
            int x = 10;
            int y = 10;
            int w = 800;
            int h = 600;
            WindowSettings flags = WindowSettings.WindowShown;
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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            const string title = "Test Window";
            const int x = 10;
            const int y = 10;
            const int w = 800;
            const int h = 600;
            const WindowSettings flags = WindowSettings.WindowShown;
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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            string title = "Test Window";
            int x = 10;
            int y = 10;
            int w = 800;
            int h = 600;
            WindowSettings flags = WindowSettings.WindowShown;
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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            string title = "Test Window";
            int x = 10;
            int y = 10;
            int w = 800;
            int h = 600;
            WindowSettings flags = WindowSettings.WindowShown;
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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            string title = "Test Window";
            int x = 10;
            int y = 10;
            int w = 800;
            int h = 600;
            WindowSettings flags = WindowSettings.WindowShown;
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            int index = 0;
            int isCapture = 0;

            // Act
            int result = Sdl.SdlGetAudioDeviceSpec(index, isCapture, out AudioSpec _);

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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            string device = "Test Device";
            int isCapture = 0;
            AudioSpec desired = new AudioSpec();
            int allowedChanges = 0;

            // Act
            uint result = Sdl.SdlOpenAudioDevice(device, isCapture, ref desired, out AudioSpec _, allowedChanges);

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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            ushort x = 1;

            // Act
            bool result = Sdl.SdlAudioIsUnsigned(x);

            // Assert
            Assert.True(result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test sdl mix audio format should not throw exception
        /// </summary>
        [Fact]
        public void TestSdlMixAudioFormat_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr device = IntPtr.Zero;
            int isCapture = 0;
            AudioSpec desired = new AudioSpec();
            int allowedChanges = 0;

            // Act
            uint result = Sdl.OpenAudioDevice(device, isCapture, ref desired, out AudioSpec _, allowedChanges);

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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            int result = Sdl.GetWindowDisplayMode(window, out DisplayMode _);

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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            bool result = Sdl.GetWindowGrab(window);

            // Assert
            Assert.False(result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get window keyboard grab should return expected value
        /// </summary>
        [Fact]
        public void TestGetWindowKeyboardGrab_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            bool result = Sdl.GetWindowKeyboardGrab(window);

            // Assert
            Assert.False(result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get window mouse grab should return expected value
        /// </summary>
        [Fact]
        public void TestGetWindowMouseGrab_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            bool result = Sdl.GetWindowMouseGrab(window);

            // Assert
            Assert.False(result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get window id should return expected value
        /// </summary>
        [Fact]
        public void TestGetWindowId_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            bool result = Sdl.IsTextInputActive();

            // Assert
            Assert.True(result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test stop text input should not throw exception
        /// </summary>
        [Fact]
        public void TestStopTextInput_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            bool result = Sdl.HasScreenKeyboardSupport();

            // Assert
            Assert.False(result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test is screen keyboard shown should return expected value
        /// </summary>
        [Fact]
        public void TestIsScreenKeyboardShown_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            bool result = Sdl.IsScreenKeyboardShown(window);

            // Assert
            Assert.False(result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that test get mouse focus should return expected value
        /// </summary>
        [Fact]
        public void TestGetMouseFocus_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
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
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            uint result = Sdl.GetGlobalMouseStateOutXAndOutY(out int _, out int _);

            // Assert
            Assert.True(Math.Abs(result - -0.0) < 0.1f || Math.Abs(result - 1.0) < 0.1f || Math.Abs(result - 2.0) < 0.1f);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that calculate gamma ramp test
        /// </summary>
        [Fact]
        public void CalculateGammaRampTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            float gamma = 1.0f;
            ushort[] ramp = new ushort[256];
            Sdl.CalculateGammaRamp(gamma, ramp);
            Assert.NotEmpty(ramp);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get pixel format name test
        /// </summary>
        [Fact]
        public void GetPixelFormatNameTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            const uint format = 0;
            string result = Sdl.GetPixelFormatName(format);
            Assert.NotNull(result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render copy ex test
        /// </summary>
        [Fact]
        public void RenderCopyExTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero;
            IntPtr texture = IntPtr.Zero;
            RectangleI srcRect = new RectangleI();
            RectangleF dst = new RectangleF();
            double angle = 0;
            PointF center = new PointF();
            RendererFlips flips = RendererFlips.FlipHorizontal;

            // Act
            int result = Sdl.RenderCopyEx(renderer, texture, ref srcRect, ref dst, angle, ref center, flips);

            // Assert
            Assert.True(result >= -1);
        }

        /// <summary>
        ///     Tests that get window maximum size test
        /// </summary>
        [Fact]
        public void GetWindowMaximumSizeTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            Sdl.GetWindowMaximumSize(window, out int _, out int _);

            // Assert
            // Add your assertions here based on your specific requirements
        }

        /// <summary>
        ///     Tests that get window minimum size test
        /// </summary>
        [Fact]
        public void GetWindowMinimumSizeTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            Sdl.GetWindowMinimumSize(window, out int _, out int _);

            // Assert
            // Add your assertions here based on your specific requirements
        }

        /// <summary>
        ///     Tests that set window opacity test
        /// </summary>
        [Fact]
        public void SetWindowOpacityTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
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
        ///     Tests that get window opacity test
        /// </summary>
        [Fact]
        public void GetWindowOpacityTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            int result = Sdl.GetWindowOpacity(window, out float _);

            // Assert
            Assert.True(result >= -1);
        }

        /// <summary>
        ///     Tests that set window modal for test
        /// </summary>
        [Fact]
        public void SetWindowModalForTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
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
        ///     Tests that set window input focus test
        /// </summary>
        [Fact]
        public void SetWindowInputFocusTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            int result = Sdl.SetWindowInputFocus(window);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get window data test
        /// </summary>
        [Fact]
        public void GetWindowDataTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
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
        ///     Tests that get window display index test
        /// </summary>
        [Fact]
        public void GetWindowDisplayIndexTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            int result = Sdl.GetWindowDisplayIndex(window);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get window flags test
        /// </summary>
        [Fact]
        public void GetWindowFlagsTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            uint result = Sdl.GetWindowFlags(window);

            // Assert
            Assert.Equal(0u, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get window from id test
        /// </summary>
        [Fact]
        public void GetWindowFromIdTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            uint id = 0;

            // Act
            IntPtr result = Sdl.GetWindowFromId(id);

            // Assert
            Assert.Equal(IntPtr.Zero, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get window pixel format test
        /// </summary>
        [Fact]
        public void GetWindowPixelFormatTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            uint result = Sdl.GetWindowPixelFormat(window);

            // Assert
            Assert.Equal(0u, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that start text input test
        /// </summary>
        [Fact]
        public void StartTextInputTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Sdl.StartTextInput();

            // Assert
            Assert.True(Sdl.IsTextInputActive());

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that is text input active test
        /// </summary>
        [Fact]
        public void IsTextInputActiveTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Sdl.IsTextInputActive();

            // Assert
            Assert.True(Sdl.IsTextInputActive());

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that stop text input test
        /// </summary>
        [Fact]
        public void StopTextInputTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Sdl.StopTextInput();

            // Assert
            Assert.False(Sdl.IsTextInputActive());


            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that set text input rect test
        /// </summary>
        [Fact]
        public void SetTextInputRectTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
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
        ///     Tests that has screen keyboard support test
        /// </summary>
        [Fact]
        public void HasScreenKeyboardSupportTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Sdl.HasScreenKeyboardSupport();

            // Assert
            Assert.False(Sdl.HasScreenKeyboardSupport());

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that is screen keyboard shown test
        /// </summary>
        [Fact]
        public void IsScreenKeyboardShownTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            Sdl.IsScreenKeyboardShown(window);

            // Assert
            Assert.False(Sdl.IsScreenKeyboardShown(window));

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get mouse focus test
        /// </summary>
        [Fact]
        public void GetMouseFocusTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            IntPtr result = Sdl.GetMouseFocus();

            // Assert
            Assert.Equal(IntPtr.Zero, result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get mouse state out x and y test
        /// </summary>
        [Fact]
        public void GetMouseStateOutXAndYTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
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
        ///     Tests that get global mouse state out x and out y test
        /// </summary>
        [Fact]
        public void GetGlobalMouseStateOutXAndOutYTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            uint result = Sdl.GetGlobalMouseStateOutXAndOutY(out int _, out int _);

            // Assert
            Assert.True(Math.Abs(result - -0.0) < 0.1f || Math.Abs(result - 1.0) < 0.1f || Math.Abs(result - 2.0) < 0.1f);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get window position test
        /// </summary>
        [Fact]
        public void GetWindowPositionTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
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
        ///     Tests that get window size test
        /// </summary>
        [Fact]
        public void GetWindowSizeTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            Vector2 windowSize = Sdl.GetWindowSize(window);

            // Assert
            Assert.True(windowSize.X >= 0);
            Assert.True(windowSize.Y >= 0);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get window title test
        /// </summary>
        [Fact]
        public void GetWindowTitleTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            string title = Sdl.GetWindowTitle(window);

            // Assert
            Assert.Equal(string.Empty, title);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get window brightness test
        /// </summary>
        [Fact]
        public void GetWindowBrightnessTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            Sdl.GetWindowBrightness(window);

            // Assert
            Assert.Equal(1.0f, Sdl.GetWindowBrightness(window));

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get window display mode test
        /// </summary>
        [Fact]
        public void GetWindowDisplayModeTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            int result = Sdl.GetWindowDisplayMode(window, out DisplayMode _);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get window surface test
        /// </summary>
        [Fact]
        public void GetWindowSurfaceTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            Sdl.GetWindowSurface(window);

            // Assert
            Assert.Equal(IntPtr.Zero, Sdl.GetWindowSurface(window));

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get window grab test
        /// </summary>
        [Fact]
        public void GetWindowGrabTest()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr window = IntPtr.Zero;

            // Act
            Sdl.GetWindowGrab(window);

            // Assert
            Assert.False(Sdl.GetWindowGrab(window));

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that update texture valid params returns expected int
        /// </summary>
        [Fact]
        public void UpdateTexture_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr texture = IntPtr.Zero; // Replace with the desired texture
            IntPtr rect = IntPtr.Zero; // Replace with the desired rectangle
            IntPtr pixels = IntPtr.Zero; // Replace with the desired pixels
            int pitch = 0; // Replace with the desired pitch

            // Act
            int result = Sdl.UpdateTexture(texture, rect, pixels, pitch);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render draw line valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderDrawLine_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the desired renderer
            int x1 = 0; // Replace with the desired x1
            int y1 = 0; // Replace with the desired y1
            int x2 = 0; // Replace with the desired x2
            int y2 = 0; // Replace with the desired y2

            // Act
            int result = Sdl.RenderDrawLine(renderer, x1, y1, x2, y2);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render logical to window valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderLogicalToWindow_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the desired renderer
            float logicalX = 0.0f; // Replace with the desired logicalX
            float logicalY = 0.0f; // Replace with the desired logicalY

            // Act
            Sdl.RenderLogicalToWindow(renderer, logicalX, logicalY, out int windowX, out int windowY);

            // Assert
            Assert.Equal(0, windowX);
            Assert.Equal(0, windowY);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render set v sync valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderSetVSync_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the desired renderer
            int vsync = 0; // Replace with the desired vsync

            // Act
            int result = Sdl.RenderSetVSync(renderer, vsync);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render copy ex f valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderCopyExF_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the desired renderer
            IntPtr texture = IntPtr.Zero; // Replace with the desired texture
            RectangleI srcRect = new RectangleI(); // Replace with the desired source rectangle
            RectangleF dst = new RectangleF(); // Replace with the desired destination rectangle
            double angle = 0.0; // Replace with the desired angle
            IntPtr center = IntPtr.Zero; // Replace with the desired center
            RendererFlips flips = RendererFlips.None; // Replace with the desired flip

            // Act
            int result = Sdl.RenderCopyExF(renderer, texture, ref srcRect, ref dst, angle, center, flips);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render copy ex f v 2 valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderCopyExF_V2_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the desired renderer
            IntPtr texture = IntPtr.Zero; // Replace with the desired texture
            IntPtr srcRect = IntPtr.Zero; // Replace with the desired source rectangle
            IntPtr dstRect = IntPtr.Zero; // Replace with the desired destination rectangle
            double angle = 0.0; // Replace with the desired angle
            PointF center = new PointF(); // Replace with the desired center
            RendererFlips flips = RendererFlips.None; // Replace with the desired flip

            // Act
            int result = Sdl.RenderCopyExF(renderer, texture, srcRect, dstRect, angle, ref center, flips);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render copy ex valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderCopyEx_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(Init.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the actual renderer
            IntPtr texture = IntPtr.Zero; // Replace with the actual texture
            IntPtr srcRect = IntPtr.Zero; // Replace with the actual source rectangle
            IntPtr dstRect = IntPtr.Zero; // Replace with the actual destination rectangle
            double angle = 0; // Replace with the actual angle
            IntPtr center = IntPtr.Zero; // Replace with the actual center
            RendererFlips flips = RendererFlips.None; // Replace with the actual flip

            // Act
            int result = Sdl.RenderCopyEx(renderer, texture, srcRect, dstRect, angle, center, flips);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }
    }
}