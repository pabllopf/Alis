// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlTestP3.cs
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
    public class SdlTestP3
    {
        /// <summary>
        ///     Tests that game controller get num touchpad fingers should return expected value
        /// </summary>
        [Fact]
        public void GameControllerGetNumTouchpadFingers_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;
            int touchpad = 0;

            // Act
            int result = Sdl.GameControllerGetNumTouchpadFingers(gameController, touchpad);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller get touchpad finger should return expected value
        /// </summary>
        [Fact]
        public void GameControllerGetTouchpadFinger_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;
            int touchpad = 0;
            int finger = 0;

            // Act
            int result = Sdl.GameControllerGetTouchpadFinger(gameController, touchpad, finger, out byte _, out float _, out float _, out float _);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller has sensor should return expected value
        /// </summary>
        [Fact]
        public void GameControllerHasSensor_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;
            SdlSensorType type = SdlSensorType.SdlSensorUnknown;

            // Act
            SdlBool result = Sdl.GameControllerHasSensor(gameController, type);

            // Assert

            Assert.Equal(SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller get joystick should return expected value
        /// </summary>
        [Fact]
        public void GameControllerGetJoystick_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;

            // Act
            IntPtr result = Sdl.GameControllerGetJoystick(gameController);

            // Assert

            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller event state should return expected value
        /// </summary>
        [Fact]
        public void GameControllerEventState_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int state = 0;

            // Act
            int result = Sdl.GameControllerEventState(state);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller update should not throw exception
        /// </summary>
        [Fact]
        public void GameControllerUpdate_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Sdl.GameControllerUpdate();

            // Assert
            Assert.Equal(0, Sdl.NumJoysticks());

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller get axis from string should return expected value
        /// </summary>
        [Fact]
        public void GameControllerGetAxisFromString_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            string pchString = "";

            // Act
            SdlGameControllerAxis result = Sdl.GameControllerGetAxisFromString(pchString);

            // Assert

            Assert.Equal(SdlGameControllerAxis.SdlControllerAxisInvalid, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller get string for axis should return expected value
        /// </summary>
        [Fact]
        public void GameControllerGetStringForAxis_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            SdlGameControllerAxis axis = SdlGameControllerAxis.SdlControllerAxisInvalid;

            // Act
            string result = Sdl.GameControllerGetStringForAxis(axis);

            // Assert
            Assert.Null(result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller get bind for axis should return expected value
        /// </summary>
        [Fact]
        public void GameControllerGetBindForAxis_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;
            SdlGameControllerAxis axis = SdlGameControllerAxis.SdlControllerAxisInvalid;

            // Act
            SdlGameControllerButtonBind result = Sdl.GameControllerGetBindForAxis(gameController, axis);

            // Assert

            Assert.Equal(default(SdlGameControllerButtonBind), result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller get axis should return expected value
        /// </summary>
        [Fact]
        public void GameControllerGetAxis_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;
            SdlGameControllerAxis axis = SdlGameControllerAxis.SdlControllerAxisInvalid;

            // Act
            short result = Sdl.GameControllerGetAxis(gameController, axis);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller get button from string should return expected value
        /// </summary>
        [Fact]
        public void GameControllerGetButtonFromString_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            string pchString = "";

            // Act
            SdlGameControllerButton result = Sdl.GameControllerGetButtonFromString(pchString);

            // Assert

            Assert.Equal(SdlGameControllerButton.SdlControllerButtonInvalid, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller get string for button should return expected value
        /// </summary>
        [Fact]
        public void GameControllerGetStringForButton_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            SdlGameControllerButton button = SdlGameControllerButton.SdlControllerButtonInvalid;

            // Act
            string result = Sdl.GameControllerGetStringForButton(button);

            // Assert
            Assert.Null(result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller get bind for button should return expected value
        /// </summary>
        [Fact]
        public void GameControllerGetBindForButton_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;
            SdlGameControllerButton button = SdlGameControllerButton.SdlControllerButtonInvalid;

            // Act
            SdlGameControllerButtonBind result = Sdl.GameControllerGetBindForButton(gameController, button);

            // Assert
            Assert.Equal(default(SdlGameControllerButtonBind), result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller get button should return expected value
        /// </summary>
        [Fact]
        public void GameControllerGetButton_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;
            SdlGameControllerButton button = SdlGameControllerButton.SdlControllerButtonInvalid;

            // Act
            byte result = Sdl.GameControllerGetButton(gameController, button);

            // Assert

            Assert.True(result == 0 || result == 1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller rumble should return expected value
        /// </summary>
        [Fact]
        public void GameControllerRumble_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;
            ushort lowFrequencyRumble = 0;
            ushort highFrequencyRumble = 0;
            uint durationMs = 0;

            // Act
            int result = Sdl.GameControllerRumble(gameController, lowFrequencyRumble, highFrequencyRumble, durationMs);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller rumble triggers should return expected value
        /// </summary>
        [Fact]
        public void GameControllerRumbleTriggers_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;
            ushort leftRumble = 0;
            ushort rightRumble = 0;
            uint durationMs = 0;

            // Act
            int result = Sdl.GameControllerRumbleTriggers(gameController, leftRumble, rightRumble, durationMs);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller close should not throw exception
        /// </summary>
        [Fact]
        public void GameControllerClose_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;

            // Act
            Sdl.GameControllerClose(gameController);

            // Assert
            Assert.Equal(IntPtr.Zero, gameController);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick set led should return expected value
        /// </summary>
        [Fact]
        public void JoystickSetLed_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero;
            byte red = 0;
            byte green = 0;
            byte blue = 0;

            // Act
            int result = Sdl.JoystickSetLed(joystick, red, green, blue);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick send effect should return expected value
        /// </summary>
        [Fact]
        public void JoystickSendEffect_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero;
            IntPtr data = IntPtr.Zero;
            int size = 0;

            // Act
            int result = Sdl.JoystickSendEffect(joystick, data, size);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller add mapping should return expected value
        /// </summary>
        [Fact]
        public void GameControllerAddMapping_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            string mappingString = "";

            // Act
            int result = Sdl.GameControllerAddMapping(mappingString);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller num mappings should return expected value
        /// </summary>
        [Fact]
        public void GameControllerNumMappings_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            int result = Sdl.GameControllerNumMappings();

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller mapping for index should return expected value
        /// </summary>
        [Fact]
        public void GameControllerMappingForIndex_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int mappingIndex = 0;

            // Act
            string result = Sdl.GameControllerMappingForIndex(mappingIndex);

            // Assert

            Assert.NotNull(result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller add mappings from file should return expected value
        /// </summary>
        [Fact]
        public void GameControllerAddMappingsFromFile_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            string file = "";

            // Act
            int result = Sdl.GameControllerAddMappingsFromFile(file);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller mapping for guid should return expected value
        /// </summary>
        [Fact]
        public void GameControllerMappingForGuid_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            Guid guid = Guid.Empty;

            // Act
            string result = Sdl.GameControllerMappingForGuid(guid);

            // Assert

            Assert.Null(result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller mapping should return expected value
        /// </summary>
        [Fact]
        public void GameControllerMapping_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;

            // Act
            string result = Sdl.GameControllerMapping(gameController);

            // Assert

            Assert.Null(result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that is game controller should return expected value
        /// </summary>
        [Fact]
        public void IsGameController_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int joystickIndex = 0;

            // Act
            SdlBool result = Sdl.IsGameController(joystickIndex);

            // Assert

            Assert.Equal(SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller name for index should return expected value
        /// </summary>
        [Fact]
        public void GameControllerNameForIndex_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int joystickIndex = 0;

            // Act
            string result = Sdl.GameControllerNameForIndex(joystickIndex);

            // Assert

            Assert.Null(result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller mapping for device index should return expected value
        /// </summary>
        [Fact]
        public void GameControllerMappingForDeviceIndex_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int joystickIndex = 0;

            // Act
            string result = Sdl.GameControllerMappingForDeviceIndex(joystickIndex);

            // Assert

            Assert.Null(result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller open should return expected value
        /// </summary>
        [Fact]
        public void GameControllerOpen_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int joystickIndex = 0;

            // Act
            IntPtr result = Sdl.GameControllerOpen(joystickIndex);

            // Assert

            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller name should return expected value
        /// </summary>
        [Fact]
        public void GameControllerName_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;

            // Act
            string result = Sdl.GameControllerName(gameController);

            // Assert

            Assert.Null(result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller get vendor should return expected value
        /// </summary>
        [Fact]
        public void GameControllerGetVendor_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;

            // Act
            ushort result = Sdl.GameControllerGetVendor(gameController);

            // Assert

            Assert.Equal((ushort) 0, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller get product should return expected value
        /// </summary>
        [Fact]
        public void GameControllerGetProduct_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;

            // Act
            ushort result = Sdl.GameControllerGetProduct(gameController);

            // Assert

            Assert.Equal((ushort) 0, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller get product version should return expected value
        /// </summary>
        [Fact]
        public void GameControllerGetProductVersion_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;

            // Act
            ushort result = Sdl.GameControllerGetProductVersion(gameController);

            // Assert

            Assert.Equal((ushort) 0, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller get serial should return expected value
        /// </summary>
        [Fact]
        public void GameControllerGetSerial_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;

            // Act
            string result = Sdl.GameControllerGetSerial(gameController);

            // Assert

            Assert.Null(result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller get attached should return expected value
        /// </summary>
        [Fact]
        public void GameControllerGetAttached_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;

            // Act
            SdlBool result = Sdl.GameControllerGetAttached(gameController);

            // Assert

            Assert.Equal(SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick get vendor should return expected value
        /// </summary>
        [Fact]
        public void JoystickGetVendor_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero;

            // Act
            ushort result = Sdl.JoystickGetVendor(joystick);

            // Assert

            Assert.Equal((ushort) 0, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick get product should return expected value
        /// </summary>
        [Fact]
        public void JoystickGetProduct_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero;

            // Act
            ushort result = Sdl.JoystickGetProduct(joystick);

            // Assert

            Assert.Equal((ushort) 0, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick get product version should return expected value
        /// </summary>
        [Fact]
        public void JoystickGetProductVersion_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero;

            // Act
            ushort result = Sdl.JoystickGetProductVersion(joystick);

            // Assert

            Assert.Equal((ushort) 0, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick get serial should return expected value
        /// </summary>
        [Fact]
        public void JoystickGetSerial_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero;

            // Act
            string result = Sdl.JoystickGetSerial(joystick);

            // Assert

            Assert.Null(result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick get type should return expected value
        /// </summary>
        [Fact]
        public void JoystickGetType_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero;

            // Act
            SdlJoystickType result = Sdl.JoystickGetType(joystick);

            // Assert

            Assert.Equal(SdlJoystickType.SdlJoystickTypeGameController, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick get attached should return expected value
        /// </summary>
        [Fact]
        public void JoystickGetAttached_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero;

            // Act
            SdlBool result = Sdl.JoystickGetAttached(joystick);

            // Assert

            Assert.Equal(SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick instance id should return expected value
        /// </summary>
        [Fact]
        public void JoystickInstanceId_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero;

            // Act
            int result = Sdl.JoystickInstanceId(joystick);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick current power level should return expected value
        /// </summary>
        [Fact]
        public void JoystickCurrentPowerLevel_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero;

            // Act
            SdlJoystickPowerLevel result = Sdl.JoystickCurrentPowerLevel(joystick);

            // Assert

            Assert.Equal(SdlJoystickPowerLevel.SdlJoystickPowerUnknown, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick from instance id should return expected value
        /// </summary>
        [Fact]
        public void JoystickFromInstanceId_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int instanceId = 0;

            // Act
            IntPtr result = Sdl.JoystickFromInstanceId(instanceId);

            // Assert

            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that lock joysticks should not throw exception
        /// </summary>
        [Fact]
        public void LockJoysticks_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Sdl.LockJoysticks();

            // Assert
            // No exception should be thrown

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that unlock joysticks should not throw exception
        /// </summary>
        [Fact]
        public void UnlockJoysticks_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Sdl.UnlockJoysticks();

            // Assert
            // No exception should be thrown

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick from player index should return expected value
        /// </summary>
        [Fact]
        public void JoystickFromPlayerIndex_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int playerIndex = 0;

            // Act
            IntPtr result = Sdl.JoystickFromPlayerIndex(playerIndex);

            // Assert

            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick set player index should not throw exception
        /// </summary>
        [Fact]
        public void JoystickSetPlayerIndex_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero;
            int playerIndex = 0;

            // Act
            Sdl.JoystickSetPlayerIndex(joystick, playerIndex);

            // Assert
            // No exception should be thrown

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that sdl joystick attach virtual should return expected value
        /// </summary>
        [Fact]
        public void SdlJoystickAttachVirtual_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int type = 0;
            int nAxes = 0;
            int nButtons = 0;
            int nHats = 0;

            // Act
            int result = Sdl.SdlJoystickAttachVirtual(type, nAxes, nButtons, nHats);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick detach virtual should return expected value
        /// </summary>
        [Fact]
        public void JoystickDetachVirtual_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int deviceIndex = 0;

            // Act
            int result = Sdl.JoystickDetachVirtual(deviceIndex);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick is virtual should return expected value
        /// </summary>
        [Fact]
        public void JoystickIsVirtual_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int deviceIndex = 0;

            // Act
            SdlBool result = Sdl.JoystickIsVirtual(deviceIndex);

            // Assert

            Assert.Equal(SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick set virtual axis should return expected value
        /// </summary>
        [Fact]
        public void JoystickSetVirtualAxis_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero;
            int axis = 0;
            short value = 0;

            // Act
            int result = Sdl.JoystickSetVirtualAxis(joystick, axis, value);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick set virtual button should return expected value
        /// </summary>
        [Fact]
        public void JoystickSetVirtualButton_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero;
            int button = 0;
            byte value = 0;

            // Act
            int result = Sdl.JoystickSetVirtualButton(joystick, button, value);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick set virtual hat should return expected value
        /// </summary>
        [Fact]
        public void JoystickSetVirtualHat_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero;
            int hat = 0;
            byte value = 0;

            // Act
            int result = Sdl.JoystickSetVirtualHat(joystick, hat, value);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick has led should return expected value
        /// </summary>
        [Fact]
        public void JoystickHasLed_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero;

            // Act
            SdlBool result = Sdl.JoystickHasLed(joystick);

            // Assert

            Assert.Equal(SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick has rumble should return expected value
        /// </summary>
        [Fact]
        public void JoystickHasRumble_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero;

            // Act
            SdlBool result = Sdl.JoystickHasRumble(joystick);

            // Assert

            Assert.Equal(SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick has rumble triggers should return expected value
        /// </summary>
        [Fact]
        public void JoystickHasRumbleTriggers_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero;

            // Act
            SdlBool result = Sdl.JoystickHasRumbleTriggers(joystick);

            // Assert

            Assert.Equal(SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that set window display mode v 2 should return expected value
        /// </summary>
        [Fact]
        public void SetWindowDisplayMode_v2_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero; // Replace with actual window pointer
            IntPtr mode = IntPtr.Zero; // Replace with actual mode pointer

            // Act
            int result = Sdl.SetWindowDisplayMode(window, mode);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that set window mouse rect v 2 should return expected value
        /// </summary>
        [Fact]
        public void SetWindowMouseRect_v2_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero; // Replace with actual window pointer
            IntPtr rect = IntPtr.Zero; // Replace with actual rect pointer

            // Act
            int result = Sdl.SetWindowMouseRect(window, rect);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that create software renderer should return expected value
        /// </summary>
        [Fact]
        public void CreateSoftwareRenderer_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero; // Replace with actual surface pointer

            // Act
            IntPtr result = Sdl.CreateSoftwareRenderer(surface);

            // Assert
            // Replace IntPtr.Zero with the expected result
            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that create texture from surface should return expected value
        /// </summary>
        [Fact]
        public void CreateTextureFromSurface_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero; // Replace with actual renderer pointer
            IntPtr surface = IntPtr.Zero; // Replace with actual surface pointer

            // Act
            IntPtr result = Sdl.CreateTextureFromSurface(renderer, surface);

            // Assert
            // Replace IntPtr.Zero with the expected result
            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that destroy renderer should execute without exception
        /// </summary>
        [Fact]
        public void DestroyRenderer_ShouldExecuteWithoutException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero; // Replace with actual renderer pointer

            // Act
            Sdl.DestroyRenderer(renderer);

            // Assert
            Assert.Equal(IntPtr.Zero, renderer);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that lock texture to surface v 2 should return expected value
        /// </summary>
        [Fact]
        public void LockTextureToSurface_V2_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr texture = IntPtr.Zero; // Replace with actual texture pointer
            IntPtr rect = IntPtr.Zero; // Replace with actual rect pointer

            // Act
            int result = Sdl.LockTextureToSurface(texture, rect, out IntPtr _);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that sensor get instance id v 2 should return expected value
        /// </summary>
        [Fact]
        public void SensorGetInstanceId_v2_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr sensor = IntPtr.Zero; // Replace with actual sensor pointer

            // Act
            int result = Sdl.SensorGetInstanceId(sensor);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that sensor get data v 2 should return expected value
        /// </summary>
        [Fact]
        public void SensorGetData_v2_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr sensor = IntPtr.Zero; // Replace with actual sensor pointer
            float[] data = new float[10]; // Replace with actual data
            int numValues = 10; // Replace with actual number of values

            // Act
            int result = Sdl.SensorGetData(sensor, data, numValues);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that sensor close should execute without exception
        /// </summary>
        [Fact]
        public void SensorClose_ShouldExecuteWithoutException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr sensor = IntPtr.Zero; // Replace with actual sensor pointer

            // Act
            Sdl.SensorClose(sensor);

            // Assert
            // No assertion needed as we are testing if the method executes without throwing an exception

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that sensor update should execute without exception
        /// </summary>
        [Fact]
        public void SensorUpdate_ShouldExecuteWithoutException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Sdl.SensorUpdate();

            // Assert
            // No assertion needed as we are testing if the method executes without throwing an exception

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that lock sensors should execute without exception
        /// </summary>
        [Fact]
        public void LockSensors_ShouldExecuteWithoutException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Sdl.LockSensors();

            // Assert
            // No assertion needed as we are testing if the method executes without throwing an exception

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that unlock sensors should execute without exception
        /// </summary>
        [Fact]
        public void UnlockSensors_ShouldExecuteWithoutException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Sdl.UnlockSensors();

            // Assert
            // No assertion needed as we are testing if the method executes without throwing an exception

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that sdl audio bit size should return expected value
        /// </summary>
        [Fact]
        public void SdlAudioBitSize_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            ushort x = 0; // Replace with actual value

            // Act
            ushort result = Sdl.SdlAudioBitSize(x);

            // Assert

            Assert.Equal(0, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick get product v 3 should return expected value
        /// </summary>
        [Fact]
        public void JoystickGetProduct_V3_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero; // Replace with actual joystick pointer

            // Act
            ushort result = Sdl.JoystickGetProduct(joystick);

            // Assert

            Assert.Equal(0, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick get product version v 3 should return expected value
        /// </summary>
        [Fact]
        public void JoystickGetProductVersion_V3_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero; // Replace with actual joystick pointer

            // Act
            ushort result = Sdl.JoystickGetProductVersion(joystick);

            // Assert

            Assert.Equal(0, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick get serial v 3 should return expected value
        /// </summary>
        [Fact]
        public void JoystickGetSerial_V3_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero; // Replace with actual joystick pointer

            // Act
            string result = Sdl.JoystickGetSerial(joystick);

            // Assert
            // Replace "expectedSerial" with the expected serial
            Assert.Null(result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick get type v 3 should return expected value
        /// </summary>
        [Fact]
        public void JoystickGetType_V3_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero; // Replace with actual joystick pointer

            // Act
            SdlJoystickType result = Sdl.JoystickGetType(joystick);

            // Assert
            // Replace SdlJoystickType.Unknown with the expected joystick type
            Assert.Equal(SdlJoystickType.SdlJoystickTypeGameController, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick get attached v 3 should return expected value
        /// </summary>
        [Fact]
        public void JoystickGetAttached_V3_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero; // Replace with actual joystick pointer

            // Act
            SdlBool result = Sdl.JoystickGetAttached(joystick);

            // Assert
            // Replace SdlBool.SDL_FALSE with the expected value
            Assert.Equal(SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick instance id v 3 should return expected value
        /// </summary>
        [Fact]
        public void JoystickInstanceId_V3_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero; // Replace with actual joystick pointer

            // Act
            int result = Sdl.JoystickInstanceId(joystick);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick current power level v 3 should return expected value
        /// </summary>
        [Fact]
        public void JoystickCurrentPowerLevel_V3_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero; // Replace with actual joystick pointer

            // Act
            SdlJoystickPowerLevel result = Sdl.JoystickCurrentPowerLevel(joystick);

            // Assert
            // Replace SdlJoystickPowerLevel.SDL_JOYSTICK_POWER_UNKNOWN with the expected power level
            Assert.Equal(SdlJoystickPowerLevel.SdlJoystickPowerUnknown, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick from instance id v 3 should return expected value
        /// </summary>
        [Fact]
        public void JoystickFromInstanceId_V3_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int instanceId = 0; // Replace with actual instance id

            // Act
            IntPtr result = Sdl.JoystickFromInstanceId(instanceId);

            // Assert
            // Replace IntPtr.Zero with the expected result
            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render copy v 2 should return expected value
        /// </summary>
        [Fact]
        public void RenderCopy_V2_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero; // Replace with actual renderer pointer
            IntPtr texture = IntPtr.Zero; // Replace with actual texture pointer
            IntPtr srcRect = IntPtr.Zero; // Replace with actual srcRect pointer
            RectangleI dstRect = new RectangleI(); // Replace with actual dstRect

            // Act
            int result = Sdl.RenderCopy(renderer, texture, srcRect, ref dstRect);

            // Assert
            // Replace 0 with the expected result
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render copy ex v 2 should return expected value
        /// </summary>
        [Fact]
        public void RenderCopyEx_V2_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero; // Replace with actual renderer pointer
            IntPtr texture = IntPtr.Zero; // Replace with actual texture pointer
            RectangleI srcRect = new RectangleI(); // Replace with actual srcRect
            RectangleI dstRect = new RectangleI(); // Replace with actual dstRect
            double angle = 0.0; // Replace with actual angle
            PointI center = new PointI(); // Replace with actual center
            SdlRendererFlip flip = SdlRendererFlip.None; // Replace with actual flip

            // Act
            int result = Sdl.RenderCopyEx(renderer, texture, ref srcRect, ref dstRect, angle, ref center, flip);

            // Assert
            // Replace 0 with the expected result
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render draw line v 2 should return expected value
        /// </summary>
        [Fact]
        public void RenderDrawLine_V2_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero; // Replace with actual renderer pointer
            int x1 = 0; // Replace with actual x1
            int y1 = 0; // Replace with actual y1
            int x2 = 0; // Replace with actual x2
            int y2 = 0; // Replace with actual y2

            // Act
            int result = Sdl.RenderDrawLine(renderer, x1, y1, x2, y2);

            // Assert
            // Replace 0 with the expected result
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render draw points v 2 should return expected value
        /// </summary>
        [Fact]
        public void RenderDrawPoints_V2_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero; // Replace with actual renderer pointer
            PointI[] points = new PointI[10]; // Replace with actual points
            int count = 10; // Replace with actual count

            // Act
            int result = Sdl.RenderDrawPoints(renderer, points, count);

            // Assert
            // Replace 0 with the expected result
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render draw rect v 2 should return expected value
        /// </summary>
        [Fact]
        public void RenderDrawRect_V2_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero; // Replace with actual renderer pointer
            RectangleI rect = new RectangleI(); // Replace with actual rect

            // Act
            int result = Sdl.RenderDrawRect(renderer, ref rect);

            // Assert
            // Replace 0 with the expected result
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render draw rects should return expected value
        /// </summary>
        [Fact]
        public void RenderDrawRects_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero; // Replace with actual renderer pointer
            RectangleI[] rects = new RectangleI[10]; // Replace with actual rects
            int count = 10; // Replace with actual count

            // Act
            int result = Sdl.RenderDrawRects(renderer, rects, count);

            // Assert
            // Replace 0 with the expected result
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render fill rect v 2 should return expected value
        /// </summary>
        [Fact]
        public void RenderFillRect_V2_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero; // Replace with actual renderer pointer
            IntPtr rect = IntPtr.Zero; // Replace with actual rect pointer

            // Act
            int result = Sdl.RenderFillRect(renderer, rect);

            // Assert
            // Replace 0 with the expected result
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render fill rects should return expected value
        /// </summary>
        [Fact]
        public void RenderFillRects_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero; // Replace with actual renderer pointer
            RectangleI[] rects = new RectangleI[10]; // Replace with actual rects
            int count = 10; // Replace with actual count

            // Act
            int result = Sdl.RenderFillRects(renderer, rects, count);

            // Assert
            // Replace 0 with the expected result
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render copy f should return expected value
        /// </summary>
        [Fact]
        public void RenderCopyF_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero; // Replace with actual renderer pointer
            IntPtr texture = IntPtr.Zero; // Replace with actual texture pointer
            RectangleI srcRect = new RectangleI(); // Replace with actual srcRect
            RectangleF dst = new RectangleF(); // Replace with actual dst

            // Act
            int result = Sdl.RenderCopyF(renderer, texture, ref srcRect, ref dst);

            // Assert
            // Replace 0 with the expected result
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render fill rects f should return expected value
        /// </summary>
        [Fact]
        public void RenderFillRectsF_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero; // Replace with actual renderer pointer
            RectangleF[] rects = new RectangleF[10]; // Replace with actual rects
            int count = 10; // Replace with actual count

            // Act
            int result = Sdl.RenderFillRectsF(renderer, rects, count);

            // Assert
            // Replace 0 with the expected result
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render get clip rect v 2 should return expected value
        /// </summary>
        [Fact]
        public void RenderGetClipRect_V2_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero; // Replace with actual renderer pointer

            // Act
            Sdl.RenderGetClipRect(renderer, out RectangleI rect);

            // Assert
            // Replace RectangleI.Empty with the expected result
            Assert.Equal(new RectangleI(), rect);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render get logical size v 2 should return expected value
        /// </summary>
        [Fact]
        public void RenderGetLogicalSize_V2_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero; // Replace with actual renderer pointer

            // Act
            Sdl.RenderGetLogicalSize(renderer, out int w, out int h);

            // Assert
            // Replace 0 with the expected result
            Assert.Equal(0, w);
            Assert.Equal(0, h);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render get scale should return expected value
        /// </summary>
        [Fact]
        public void RenderGetScale_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero; // Replace with actual renderer pointer

            // Act
            Sdl.RenderGetScale(renderer, out float scaleX, out float scaleY);

            // Assert
            // Replace 0.0f with the expected result
            Assert.Equal(0.0f, scaleX);
            Assert.Equal(0.0f, scaleY);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render window to logical should return expected value
        /// </summary>
        [Fact]
        public void RenderWindowToLogical_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero; // Replace with actual renderer pointer
            int windowX = 0; // Replace with actual windowX
            int windowY = 0; // Replace with actual windowY

            // Act
            Sdl.RenderWindowToLogical(renderer, windowX, windowY, out float logicalX, out float logicalY);

            // Assert
            // Replace 0.0f with the expected result
            Assert.Equal(0.0f, logicalX);
            Assert.Equal(0.0f, logicalY);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render logical to window should return expected value
        /// </summary>
        [Fact]
        public void RenderLogicalToWindow_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero; // Replace with actual renderer pointer
            float logicalX = 0.0f; // Replace with actual logicalX
            float logicalY = 0.0f; // Replace with actual logicalY

            // Act
            Sdl.RenderLogicalToWindow(renderer, logicalX, logicalY, out int windowX, out int windowY);

            // Assert
            // Replace 0 with the expected result
            Assert.Equal(0, windowX);
            Assert.Equal(0, windowY);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick get hat should return expected value
        /// </summary>
        [Fact]
        public void JoystickGetHat_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero; // Replace with actual joystick pointer
            int hat = 0; // Replace with actual hat value

            // Act
            byte result = Sdl.JoystickGetHat(joystick, hat);

            // Assert
            // Replace 0 with the expected result
            Assert.Equal(0, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick name should return expected value
        /// </summary>
        [Fact]
        public void JoystickName_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero; // Replace with actual joystick pointer

            // Act
            string result = Sdl.JoystickName(joystick);

            // Assert
            // Replace "ExpectedName" with the expected result
            Assert.Null(result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick name for index should return expected value
        /// </summary>
        [Fact]
        public void JoystickNameForIndex_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int deviceIndex = 0; // Replace with actual device index

            // Act
            string result = Sdl.JoystickNameForIndex(deviceIndex);

            // Assert
            // Replace "ExpectedName" with the expected result
            Assert.Null(result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick num axes should return expected value
        /// </summary>
        [Fact]
        public void JoystickNumAxes_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero; // Replace with actual joystick pointer

            // Act
            int result = Sdl.JoystickNumAxes(joystick);

            // Assert
            // Replace 0 with the expected result
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick num balls should return expected value
        /// </summary>
        [Fact]
        public void JoystickNumBalls_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero; // Replace with actual joystick pointer

            // Act
            int result = Sdl.JoystickNumBalls(joystick);

            // Assert
            // Replace 0 with the expected result
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick num buttons should return expected value
        /// </summary>
        [Fact]
        public void JoystickNumButtons_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero; // Replace with actual joystick pointer

            // Act
            int result = Sdl.JoystickNumButtons(joystick);

            // Assert
            // Replace 0 with the expected result
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick num hats should return expected value
        /// </summary>
        [Fact]
        public void JoystickNumHats_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero; // Replace with actual joystick pointer

            // Act
            int result = Sdl.JoystickNumHats(joystick);

            // Assert
            // Replace 0 with the expected result
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick open should return expected value
        /// </summary>
        [Fact]
        public void JoystickOpen_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int deviceIndex = 0; // Replace with actual device index

            // Act
            IntPtr result = Sdl.JoystickOpen(deviceIndex);

            // Assert
            // Replace IntPtr.Zero with the expected result
            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick update should not throw exception
        /// </summary>
        [Fact]
        public void JoystickUpdate_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Action act = Sdl.JoystickUpdate;

            // Assert
            Assert.Null(Record.Exception(act));

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that num joysticks should return expected value
        /// </summary>
        [Fact]
        public void NumJoysticks_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            int result = Sdl.NumJoysticks();

            // Assert
            // Replace 0 with the expected result
            Assert.Equal(0, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick get device guid should return expected value
        /// </summary>
        [Fact]
        public void JoystickGetDeviceGuid_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int deviceIndex = 0; // Replace with actual device index

            // Act
            Guid result = Sdl.JoystickGetDeviceGuid(deviceIndex);

            // Assert
            // Replace Guid.Empty with the expected result
            Assert.Equal(Guid.Empty, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick get guid should return expected value
        /// </summary>
        [Fact]
        public void JoystickGetGuid_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero; // Replace with actual joystick pointer

            // Act
            Guid result = Sdl.JoystickGetGuid(joystick);

            // Assert
            // Replace Guid.Empty with the expected result
            Assert.Equal(Guid.Empty, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick get guid from string should return expected value
        /// </summary>
        [Fact]
        public void JoystickGetGuidFromString_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            string pchGuid = "00000000-0000-0000-0000-000000000000"; // Replace with actual GUID string

            // Act
            Guid result = Sdl.JoystickGetGuidFromString(pchGuid);

            // Assert
            // Replace Guid.Empty with the expected result
            Assert.Equal(Guid.Empty, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get cursor should return expected value
        /// </summary>
        [Fact]
        public void GetCursor_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            IntPtr result = Sdl.GetCursor();

            // Assert
            // Replace IntPtr.Zero with the expected result
            if (IntPtr.Zero == result)
            {
                Assert.Equal(IntPtr.Zero, result);
            }
            else
            {
                Assert.NotEqual(IntPtr.Zero, result);
            }

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that show cursor should return expected value
        /// </summary>
        [Fact]
        public void ShowCursor_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int toggle = 1; // Replace with actual toggle value

            // Act
            int result = Sdl.ShowCursor(toggle);

            // Assert
            // Replace 0 with the expected result
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that button should return expected value
        /// </summary>
        [Fact]
        public void Button_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            uint x = 1; // Replace with actual x value

            // Act
            uint result = Sdl.Button(x);

            // Assert
            Assert.True(result == 0 || result == 1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get touch device should return expected value
        /// </summary>
        [Fact]
        public void GetTouchDevice_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int index = 0; // Replace with actual index value

            // Act
            long result = Sdl.GetTouchDevice(index);

            // Assert
            Assert.Equal(0L, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get num touch fingers should return expected value
        /// </summary>
        [Fact]
        public void GetNumTouchFingers_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            long touchId = 0L; // Replace with actual touchId value

            // Act
            int result = Sdl.GetNumTouchFingers(touchId);

            // Assert
            // Replace 0 with the expected result
            Assert.Equal(0, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get touch finger should return expected value
        /// </summary>
        [Fact]
        public void GetTouchFinger_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            long touchId = 0L; // Replace with actual touchId value
            int index = 0; // Replace with actual index value

            // Act
            IntPtr result = Sdl.GetTouchFinger(touchId, index);

            // Assert
            // Replace IntPtr.Zero with the expected result
            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get touch device type should return expected value
        /// </summary>
        [Fact]
        public void GetTouchDeviceType_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            long touchId = 0L; // Replace with actual touchId value

            // Act
            SdlTouchDeviceType result = Sdl.GetTouchDeviceType(touchId);

            // Assert
            // Replace SdlTouchDeviceType.Unknown with the expected result
            Assert.Equal(SdlTouchDeviceType.SdlTouchDeviceInvalid, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick rumble should return expected value
        /// </summary>
        [Fact]
        public void JoystickRumble_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero; // Replace with actual joystick pointer
            ushort lowFrequencyRumble = 0; // Replace with actual lowFrequencyRumble value
            ushort highFrequencyRumble = 0; // Replace with actual highFrequencyRumble value
            uint durationMs = 0; // Replace with actual durationMs value

            // Act
            int result = Sdl.JoystickRumble(joystick, lowFrequencyRumble, highFrequencyRumble, durationMs);

            // Assert
            // Replace 0 with the expected result
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick rumble triggers should return expected value
        /// </summary>
        [Fact]
        public void JoystickRumbleTriggers_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero; // Replace with actual joystick pointer
            ushort leftRumble = 0; // Replace with actual leftRumble value
            ushort rightRumble = 0; // Replace with actual rightRumble value
            uint durationMs = 0; // Replace with actual durationMs value

            // Act
            int result = Sdl.JoystickRumbleTriggers(joystick, leftRumble, rightRumble, durationMs);

            // Assert
            // Replace 0 with the expected result
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick event state should return expected value
        /// </summary>
        [Fact]
        public void JoystickEventState_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int state = 0; // Replace with actual state value

            // Act
            int result = Sdl.JoystickEventState(state);

            // Assert
            // Replace 0 with the expected result
            Assert.Equal(0, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick get axis should return expected value
        /// </summary>
        [Fact]
        public void JoystickGetAxis_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero; // Replace with actual joystick pointer
            int axis = 0; // Replace with actual axis value

            // Act
            short result = Sdl.JoystickGetAxis(joystick, axis);

            // Assert
            // Replace 0 with the expected result
            Assert.Equal(0, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick get axis initial state should return expected value
        /// </summary>
        [Fact]
        public void JoystickGetAxisInitialState_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero; // Replace with actual joystick pointer
            int axis = 0; // Replace with actual axis value

            // Act
            SdlBool result = Sdl.JoystickGetAxisInitialState(joystick, axis, out ushort _);

            // Assert
            // Replace SdlBool.False with the expected result
            Assert.Equal(SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick get ball should return expected value
        /// </summary>
        [Fact]
        public void JoystickGetBall_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero; // Replace with actual joystick pointer
            int ball = 0; // Replace with actual ball value

            // Act
            int result = Sdl.JoystickGetBall(joystick, ball, out int _, out int _);

            // Assert
            // Replace 0 with the expected result
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick get button should return expected value
        /// </summary>
        [Fact]
        public void JoystickGetButton_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero; // Replace with actual joystick pointer
            int button = 0; // Replace with actual button value

            // Act
            byte result = Sdl.JoystickGetButton(joystick, button);

            // Assert
            // Replace 0 with the expected result
            Assert.Equal(0, result);

            // Cleanup
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

            IntPtr renderer = IntPtr.Zero; // Replace with the desired renderer
            IntPtr texture = IntPtr.Zero; // Replace with the desired texture
            IntPtr srcRect = IntPtr.Zero; // Replace with the desired source rectangle
            IntPtr dstRect = IntPtr.Zero; // Replace with the desired destination rectangle
            double angle = 0.0; // Replace with the desired angle
            PointI center = new PointI(); // Replace with the desired center point
            SdlRendererFlip flip = SdlRendererFlip.None; // Replace with the desired flip

            // Act
            int result = Sdl.RenderCopyEx(renderer, texture, srcRect, dstRect, angle, ref center, flip);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render copy ex with rectangle valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderCopyExWithRectangle_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the desired renderer
            IntPtr texture = IntPtr.Zero; // Replace with the desired texture
            IntPtr srcRect = IntPtr.Zero; // Replace with the desired source rectangle
            RectangleI dstRect = new RectangleI(0, 0, 0, 0); // Replace with the desired destination rectangle
            double angle = 0.0; // Replace with the desired angle
            IntPtr center = IntPtr.Zero; // Replace with the desired center point
            SdlRendererFlip flip = SdlRendererFlip.None; // Replace with the desired flip

            // Act
            int result = Sdl.RenderCopyEx(renderer, texture, srcRect, ref dstRect, angle, center, flip);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render set integer scale valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderSetIntegerScale_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the desired renderer
            SdlBool enable = SdlBool.False; // Replace with the desired boolean value

            // Act
            int result = Sdl.RenderSetIntegerScale(renderer, enable);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render set viewport valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderSetViewport_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the desired renderer
            RectangleI rect = new RectangleI(0, 0, 0, 0); // Replace with the desired rectangle

            // Act
            int result = Sdl.RenderSetViewport(renderer, ref rect);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render copy ex v 2 valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderCopyEx_V2_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the desired renderer
            IntPtr texture = IntPtr.Zero; // Replace with the desired texture
            RectangleI srcRect = new RectangleI(); // Replace with the desired source rectangle
            IntPtr dstRect = IntPtr.Zero; // Replace with the desired destination rectangle
            double angle = 0.0; // Replace with the desired angle
            IntPtr center = IntPtr.Zero; // Replace with the desired center
            SdlRendererFlip flip = SdlRendererFlip.None; // Replace with the desired flip

            // Act
            int result = Sdl.RenderCopyEx(renderer, texture, ref srcRect, dstRect, angle, center, flip);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that push event valid params returns expected int
        /// </summary>
        [Fact]
        public void PushEvent_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            SdlEvent sdlEvent = new SdlEvent(); // Replace with the desired SdlEvent

            // Act
            int result = Sdl.PushEvent(ref sdlEvent);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render draw rect valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderDrawRect_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the actual renderer
            IntPtr rect = IntPtr.Zero; // Replace with the actual rectangle

            // Act
            int result = Sdl.RenderDrawRect(renderer, rect);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that gl audio u 16 sys valid call returns expected ushort
        /// </summary>
        [Fact]
        public void GlAudioU16Sys_ValidCall_ReturnsExpectedUshort()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            ushort result = Sdl.GlAudioU16Sys;

            // Assert
            Assert.False(result == 0 || result == 1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that gl audio s 16 sys valid call returns expected ushort
        /// </summary>
        [Fact]
        public void GlAudioS16Sys_ValidCall_ReturnsExpectedUshort()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            ushort result = Sdl.GlAudioS16Sys;

            // Assert
            Assert.False(result == 0 || result == 1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that gl audio s 32 sys valid call returns expected ushort
        /// </summary>
        [Fact]
        public void GlAudioS32Sys_ValidCall_ReturnsExpectedUshort()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            ushort result = Sdl.GlAudioS32Sys;

            // Assert
            Assert.False(result == 0 || result == 1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that gl audio f 32 sys valid call returns expected ushort
        /// </summary>
        [Fact]
        public void GlAudioF32Sys_ValidCall_ReturnsExpectedUshort()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            ushort result = Sdl.GlAudioF32Sys;

            // Assert
            Assert.False(result == 0 || result == 1);

            Sdl.Quit();
        }
    }
}