// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlTestP4.cs
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
    public class SdlTestP4
    {
        /// <summary>
        ///     Tests that get window surface test not in sdl test
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
        ///     Tests that get window grab test not in sdl test
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
        ///     Tests that get window brightness test not in sdl test
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
        ///     Tests that get window display mode test not in sdl test
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
        ///     Tests that get window flags test not in sdl test
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
        ///     Tests that get window surface test not in sdl test 2
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
        ///     Tests that get window grab test not in sdl test 2
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
        ///     Tests that get window brightness test not in sdl test 2
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
        ///     Tests that get window display mode test not in sdl test 2
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
        ///     Tests that get window flags test not in sdl test 2
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
        ///     Tests that get window grab test not in sdl test 3
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
        ///     Tests that get window brightness test not in sdl test 3
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
        ///     Tests that get window display mode test not in sdl test 3
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
        ///     Tests that get window flags test not in sdl test 3
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
        ///     Tests that get window grab test not in sdl test 4
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
        ///     Tests that get window brightness test not in sdl test 4
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
        ///     Tests that get window display mode test not in sdl test 4
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
        ///     Tests that get window flags test not in sdl test 4
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
        ///     Tests that test sdl get error should return empty after init
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
        ///     Tests that test sdl was init should return non zero after init
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
        ///     Tests that test joystick name for index should return valid name after init
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
        ///     Tests that test joystick num axes should return non negative after init
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
        ///     Tests that test joystick num balls should return non negative after init
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
        ///     Tests that test joystick num buttons should return non negative after init
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
        ///     Tests that test joystick num hats should return non negative after init
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
        ///     Tests that test joystick open should return valid pointer after init
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
        ///     Tests that test num joysticks should return non negative after init
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
        ///     Tests that test joystick get device guid should return valid guid after init
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
        ///     Tests that test joystick get guid should return valid guid after init
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
        ///     Tests that test joystick get device vendor should return valid vendor after init
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
        ///     Tests that test joystick get device product should return valid product after init
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
        ///     Tests that test joystick get device product version should return valid product version after init
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
        ///     Tests that test joystick get device type should return valid type after init
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
        ///     Tests that test joystick get device instance id should return valid instance id after init
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
        ///     Tests that test joystick get vendor should return valid vendor after init
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
        ///     Tests that test joystick get product should return valid product after init
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
        ///     Tests that test joystick get product version should return valid product version after init
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
        ///     Tests that test joystick get serial should return valid serial after init
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
        ///     Tests that test joystick get type should return valid type after init
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
        ///     Tests that test joystick get attached should return true after init
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
        ///     Tests that test joystick instance id should return valid instance id after init
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
        ///     Tests that test joystick current power level should return valid power level after init
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
        ///     Tests that bind texture should return expected value
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
        ///     Tests that create context should return expected value
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
        ///     Tests that delete context should not throw exception
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
        ///     Tests that get proc address should return expected value
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
        ///     Tests that extension supported should return expected value
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
        ///     Tests that reset attributes should not throw exception
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
        ///     Tests that get attribute should return expected value
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
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get swap interval should return expected value
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
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that make current should return expected value
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
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get current window should return expected value
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
            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get current context should return expected value
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
            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get drawable size should return expected value
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
        ///     Tests that set attribute by int should return expected value
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
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that set attribute by profile should return expected value
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
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that set swap interval should return expected value
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
        ///     Tests that swap window should not throw exception
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
        ///     Tests that unbind texture should return expected value
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
        ///     Tests that hide window should not throw exception
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
        ///     Tests that maximize window should not throw exception
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
        ///     Tests that minimize window should not throw exception
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
        ///     Tests that raise window should not throw exception
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
        ///     Tests that restore window should not throw exception
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
        ///     Tests that set window brightness should return expected value
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
        ///     Tests that set window data should return expected value
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
        ///     Tests that set window display mode should return expected value
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
        ///     Tests that set window fullscreen should return expected value
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
        ///     Tests that set window gamma ramp should return expected value
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
        ///     Tests that set window grab should not throw exception
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
        ///     Tests that set window keyboard grab should not throw exception
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
        ///     Tests that set window mouse grab should not throw exception
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
        ///     Tests that set window icon should not throw exception
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
        ///     Tests that set window maximum size should not throw exception
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
        ///     Tests that set window minimum size should not throw exception
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
        ///     Tests that set window position should not throw exception
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
        ///     Tests that set window size should not throw exception
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
        ///     Tests that set window bordered should not throw exception
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
        ///     Tests that get window borders size should return expected value
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
        ///     Tests that set window resizable should not throw exception
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
        ///     Tests that set window always on top should not throw exception
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
        ///     Tests that set window title should not throw exception
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
        ///     Tests that show window should not throw exception
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
        ///     Tests that update window surface should return expected value
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
        ///     Tests that update window surface rects should return expected value
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
        ///     Tests that set window hit test should return expected value
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
        ///     Tests that get grabbed window should return expected value
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

            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that set window mouse rect should return expected value
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
        ///     Tests that get window mouse rect should return expected value
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

            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that flash window should return expected value
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
        ///     Tests that compose custom blend mode should return expected value
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
        ///     Tests that create renderer should return expected value
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

            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that create texture should return expected value
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

            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that destroy texture should not throw exception
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
        ///     Tests that get num render drivers should return expected value
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
        ///     Tests that get render draw blend mode should return expected value
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
        ///     Tests that set texture scale mode should return expected value
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
        ///     Tests that get texture scale mode should return expected value
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
        ///     Tests that set texture user data should return expected value
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
        ///     Tests that get texture user data should return expected value
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
            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get render draw color should return expected value
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
        ///     Tests that get render driver info should return expected value
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
        ///     Tests that get renderer should return expected value
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
            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get renderer info should return expected value
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
        ///     Tests that get renderer output size should return expected value
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
        ///     Tests that get texture alpha mod should return expected value
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
        ///     Tests that get texture blend mode should return expected value
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
        ///     Tests that get texture color mod should return expected value
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
        ///     Tests that lock texture should return expected value
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
        ///     Tests that lock texture to surface should return expected value
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
        ///     Tests that query texture should return expected value
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
        ///     Tests that render clear should return expected value
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
        ///     Tests that render copy should return expected value
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
        ///     Tests that render copy ex should return expected value
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
        ///     Tests that render draw line should return expected value
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
        ///     Tests that render draw points should return expected value
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
        ///     Tests that render draw rect should return expected value
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
        ///     Tests that render fill rect should return expected value
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
        ///     Tests that render copy ex f should return expected value
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
        ///     Tests that render geometry should return expected value
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
        ///     Tests that render draw point f should return expected value
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
        ///     Tests that render draw points f should return expected value
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
        ///     Tests that render draw line f should return expected value
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
        ///     Tests that render draw lines f should return expected value
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
        ///     Tests that render draw rect f should return expected value
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
        ///     Tests that render fill rect f should return expected value
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
        ///     Tests that render get clip rect should return expected value
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
        ///     Tests that render get logical size should return expected value
        /// </summary>
        [Fact]
        public void RenderGetLogicalSize_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;

            // Act
            Sdl.RenderGetLogicalSize(renderer, out int w, out int h);

            // Assert
            Assert.Equal(0, w);
            Assert.Equal(0, h);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render get viewport should return expected value
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
        ///     Tests that set texture alpha mod valid params returns expected int
        /// </summary>
        [Fact]
        public void SetTextureAlphaMod_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr texture = IntPtr.Zero; // Replace with the desired texture
            byte alpha = 255; // Replace with the desired alpha

            // Act
            int result = Sdl.SetTextureAlphaMod(texture, alpha);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that set texture blend mode valid params returns expected int
        /// </summary>
        [Fact]
        public void SetTextureBlendMode_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr texture = IntPtr.Zero; // Replace with the desired texture
            SdlBlendMode blendMode = SdlBlendMode.None; // Replace with the desired blend mode

            // Act
            int result = Sdl.SetTextureBlendMode(texture, blendMode);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that set texture color mod valid params returns expected int
        /// </summary>
        [Fact]
        public void SetTextureColorMod_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr texture = IntPtr.Zero; // Replace with the desired texture
            byte r = 255; // Replace with the desired red value
            byte g = 255; // Replace with the desired green value
            byte b = 255; // Replace with the desired blue value

            // Act
            int result = Sdl.SetTextureColorMod(texture, r, g, b);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render draw lines valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderDrawLines_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the desired renderer
            PointI[] points = new PointI[2]; // Replace with the desired points
            int count = points.Length;

            // Act
            int result = Sdl.RenderDrawLines(renderer, points, count);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render draw point valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderDrawPoint_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the desired renderer
            int x = 0; // Replace with the desired x coordinate
            int y = 0; // Replace with the desired y coordinate

            // Act
            int result = Sdl.RenderDrawPoint(renderer, x, y);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render draw rect f valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderDrawRectF_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the desired renderer
            IntPtr rect = IntPtr.Zero; // Replace with the desired rectangle

            // Act
            int result = Sdl.RenderDrawRectF(renderer, rect);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render draw rects f valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderDrawRectsF_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the desired renderer
            RectangleF[] rects = new RectangleF[2]; // Replace with the desired rectangles
            int count = rects.Length;

            // Act
            int result = Sdl.RenderDrawRectsF(renderer, rects, count);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that update texture valid params returns expected int
        /// </summary>
        [Fact]
        public void UpdateTexture_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        ///     Tests that render fill rect f valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderFillRectF_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the desired renderer
            IntPtr rect = IntPtr.Zero; // Replace with the desired rect

            // Act
            int result = Sdl.RenderFillRectF(renderer, rect);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render fill rect f v 2 valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderFillRectF_V2_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the desired renderer
            IntPtr rect = IntPtr.Zero; // Replace with the desired rect

            // Act
            int result = Sdl.RenderFillRectF(renderer, rect);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render copy f valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderCopyF_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the actual renderer
            IntPtr texture = IntPtr.Zero; // Replace with the actual texture
            IntPtr srcRect = IntPtr.Zero; // Replace with the actual source rectangle
            RectangleF dst = new RectangleF(); // Replace with the actual destination rectangle

            // Act
            int result = Sdl.RenderCopyF(renderer, texture, srcRect, ref dst);

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
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the actual renderer
            IntPtr texture = IntPtr.Zero; // Replace with the actual texture
            IntPtr srcRect = IntPtr.Zero; // Replace with the actual source rectangle
            RectangleF dst = new RectangleF(); // Replace with the actual destination rectangle
            double angle = 0.0; // Replace with the actual angle
            PointF center = new PointF(); // Replace with the actual center point
            SdlRendererFlip flip = SdlRendererFlip.None; // Replace with the actual flip value

            // Act
            int result = Sdl.RenderCopyEx(renderer, texture, srcRect, ref dst, angle, ref center, flip);

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
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the actual renderer
            IntPtr texture = IntPtr.Zero; // Replace with the actual texture
            IntPtr srcRect = IntPtr.Zero; // Replace with the actual source rectangle
            RectangleF dst = new RectangleF(); // Replace with the actual destination rectangle
            double angle = 0.0; // Replace with the actual angle
            IntPtr center = IntPtr.Zero; // Replace with the actual center point
            SdlRendererFlip flip = SdlRendererFlip.None; // Replace with the actual flip value

            // Act
            int result = Sdl.RenderCopyExF(renderer, texture, srcRect, ref dst, angle, center, flip);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render copy ex f v 3 valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderCopyExF_v3_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the actual renderer
            IntPtr texture = IntPtr.Zero; // Replace with the actual texture
            RectangleI srcRect = new RectangleI(); // Replace with the actual source rectangle
            IntPtr dstRect = IntPtr.Zero; // Replace with the actual destination rectangle
            double angle = 0.0; // Replace with the actual angle
            IntPtr center = IntPtr.Zero; // Replace with the actual center point
            SdlRendererFlip flip = SdlRendererFlip.None; // Replace with the actual flip value

            // Act
            int result = Sdl.RenderCopyExF(renderer, texture, ref srcRect, dstRect, angle, center, flip);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render copy f v 3 valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderCopyF_v3_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the actual renderer
            IntPtr texture = IntPtr.Zero; // Replace with the actual texture
            RectangleI srcRect = new RectangleI(); // Replace with the actual source rectangle
            IntPtr dstRect = IntPtr.Zero; // Replace with the actual destination rectangle

            // Act
            int result = Sdl.RenderCopyF(renderer, texture, ref srcRect, dstRect);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }
    }
}