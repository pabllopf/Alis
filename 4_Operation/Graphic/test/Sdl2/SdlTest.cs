// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlTest.cs
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
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Core.Graphic.Test.Sdl2
{
    /// <summary>
    /// The sdl test class
    /// </summary>
    public class SdlTest
    {
        /// <summary>
        /// Tests that test init
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
        /// Tests that test get gl compiled version
        /// </summary>
        [Fact]
        public void TestGetGlCompiledVersion()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            
            // Arrange
            const int expectedVersion = Sdl.MajorVersion * 1000 + Sdl.MinorVersion * 100 + Sdl.PatchLevel;

            // Act
            int actualVersion = Sdl.GetGlCompiledVersion();

            // Assert
            Assert.Equal(expectedVersion, actualVersion);
            
            Sdl.Quit();
        }
        
        /// <summary>
        /// Tests that test game controller close
        /// </summary>
        [Fact]
        public void TestGameControllerClose()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            
            // Arrange
            int controllersAvailable = Sdl.NumJoysticks();
            if (controllersAvailable > 1)
            {
                IntPtr controller = Sdl.GameControllerOpen(0);

                // Act
                Sdl.GameControllerClose(controller);
            }
            
            Sdl.Quit();
        }
        
        /// <summary>
        /// Tests that test game controller set led
        /// </summary>
        [Fact]
        public void TestGameControllerSetLed()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            
            // Arrange
            int controllersAvailable = Sdl.NumJoysticks();
            if (controllersAvailable > 1)
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
        /// Tests that test game controller has axis
        /// </summary>
        [Fact]
        public void TestGameControllerHasAxis()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            
            // Arrange
            int controllersAvailable = Sdl.NumJoysticks();
            if (controllersAvailable > 1)
            {
                IntPtr gameController = Sdl.GameControllerOpen(0);

                // Act
                const SdlGameControllerAxis axis = new SdlGameControllerAxis(); // You need to get a valid instance of SdlGameControllerAxis

                // Act
                SdlBool result = Sdl.GameControllerHasAxis(gameController, axis);

                // Assert
                Assert.Equal(SdlBool.SdlTrue, result);
            }
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test game controller has button
        /// </summary>
        [Fact]
        public void TestGameControllerHasButton()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            
            // Arrange
            int controllersAvailable = Sdl.NumJoysticks();
            if (controllersAvailable > 1)
            {
                IntPtr gameController = Sdl.GameControllerOpen(0);

                // Act
                const SdlGameControllerButton button = new SdlGameControllerButton(); // You need to get a valid instance of SdlGameControllerButton

                // Act
                SdlBool result = Sdl.GameControllerHasButton(gameController, button);

                // Assert
                Assert.Equal(SdlBool.SdlTrue, result);
            }
            
            Sdl.Quit();
        }
        /// <summary>
        /// Tests that test audio init
        /// </summary>
        [Fact]
        public void TestAudioInit()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            
            // Arrange
            string name = Sdl.GetAudioDriver(0);

            // Act
            int result = Sdl.AudioInit(name);

            // Assert
            // Here you need to assert that the result is as expected. This will depend on your implementation.
            Assert.Equal(0, result);
            
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test audio quit
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
        /// Tests that test close audio device
        /// </summary>
        [Fact]
        public void TestCloseAudioDevice()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            
            int audioDevices = Sdl.GetNumAudioDevices(0);
            if (audioDevices > 1)
            {
                string nameAudioDevice = Sdl.GetAudioDeviceName(0, 0);
                
                SdlAudioSpec spect = new SdlAudioSpec();
                
                // Arrange
                uint dev = Sdl.SdlOpenAudioDevice(nameAudioDevice, 0, ref spect, out SdlAudioSpec obtained, 0);
                
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
        /// Tests that test get audio device name
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
        /// Tests that test get audio device status
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
        /// Tests that test get audio driver
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
        /// Tests that test get current audio driver
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
        /// Tests that test get num audio devices
        /// </summary>
        [Fact]
        public void TestGetNumAudioDevices()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            
            // Arrange
            const int isCapture = 0; // You need to get a valid instance of int

            // Act
            int result = Sdl.GetNumAudioDevices(isCapture);

            // Assert
            Assert.NotEqual(0, result);
            
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test get num audio drivers
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
        /// Tests that test load wav
        /// </summary>
        [Fact]
        public void TestLoadWav()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            
            // Arrange
            string file = AssetManager.Find("AudioSample.wav");
            SdlAudioSpec spec;
            IntPtr audioBuf;
            uint audioLen = 0;

            // Act
            IntPtr result = Sdl.LoadWav(file, out spec, out audioBuf, out audioLen);

            // Assert
            // Here you need to assert that the result is as expected. This will depend on your implementation.
            Assert.Equal(5954560.0, audioLen);
            Assert.NotEqual(IntPtr.Zero, result);
            Assert.NotEqual(IntPtr.Zero, audioBuf);
            
            Sdl.Quit();
        }
        
        /// <summary>
        /// Tests that test lock audio device
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
        /// Tests that test mix audio
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
        /// Tests that test mix audio format
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
        /// Tests that test open audio
        /// </summary>
        [Fact]
        public void TestOpenAudio()
        {
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            
            // Arrange
            SdlAudioSpec desired = new SdlAudioSpec(); // You need to get a valid instance of SdlAudioSpec
            SdlAudioSpec obtained;

            // Act
            int result = Sdl.SdlOpenAudio(ref desired, out obtained);

            // Assert
            // Here you need to assert that the result is as expected. This will depend on your implementation.
            Assert.Equal(0, result);
            
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test open audio device
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
            SdlAudioSpec obtained;
            int allowedChanges = 0; // You need to get a valid instance of int

            // Act
            uint result = Sdl.SdlOpenAudioDevice(device, isCapture, ref desired, out obtained, allowedChanges);

            // Assert
            // Here you need to assert that the result is as expected. This will depend on your implementation.
            Assert.Equal(0.0, result);
            
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that test pause audio
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
        /// Tests that test pause audio device
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
        /// Tests that test unlock audio device
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
    }
}