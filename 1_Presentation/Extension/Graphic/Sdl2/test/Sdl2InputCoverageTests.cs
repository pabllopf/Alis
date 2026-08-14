// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sdl2InputCoverageTests.cs
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
using Alis.Extension.Graphic.Sdl2.Enums;
using Alis.Extension.Graphic.Sdl2.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Coverage tests for joystick, game controller and haptic methods
    /// </summary>
    public class Sdl2InputCoverageTests
    {
        /// <summary>
        ///     Tests that joystick query functions do not crash without devices
        /// </summary>
        [RequireSdl2Fact]
        public void JoystickQueries_DoNotCrash()
        {
            Sdl.NumJoysticks();
            Sdl.JoystickUpdate();
            Sdl.JoystickEventState(0);
            Sdl.JoystickEventState(1);
            Sdl.JoystickNameForIndex(0);
            Sdl.JoystickGetDeviceGuid(0);
            Sdl.JoystickGetGuidString(Guid.Empty, new byte[64], 64);
            Sdl.JoystickGetGuidFromString("03000000123456780000000000000000");
            Sdl.JoystickGetDeviceVendor(0);
            Sdl.JoystickGetDeviceProduct(0);
            Sdl.JoystickGetDeviceProductVersion(0);
            Sdl.JoystickGetDeviceType(0);
            Sdl.JoystickGetDeviceInstanceId(0);
            Sdl.LockJoysticks();
            Sdl.UnlockJoysticks();
            IntPtr joystick = Sdl.JoystickOpen(0);
            if (joystick != IntPtr.Zero)
            {
                Sdl.JoystickName(joystick);
                Sdl.JoystickGetAttached(joystick);
                Sdl.JoystickInstanceId(joystick);
                Sdl.JoystickNumAxes(joystick);
                Sdl.JoystickNumBalls(joystick);
                Sdl.JoystickNumButtons(joystick);
                Sdl.JoystickNumHats(joystick);
                Sdl.JoystickGetAxis(joystick, 0);
                ushort state;
                Sdl.JoystickGetAxisInitialState(joystick, 0, out state);
                int dx;
                int dy;
                Sdl.JoystickGetBall(joystick, 0, out dx, out dy);
                Sdl.JoystickGetButton(joystick, 0);
                Sdl.JoystickGetHat(joystick, 0);
                Sdl.JoystickGetVendor(joystick);
                Sdl.JoystickGetProduct(joystick);
                Sdl.JoystickGetProductVersion(joystick);
                Sdl.JoystickGetType(joystick);
                Sdl.JoystickGetGuid(joystick);
                Sdl.JoystickCurrentPowerLevel(joystick);
                int instanceId = Sdl.JoystickInstanceId(joystick);
                Sdl.JoystickFromInstanceId(instanceId);
                Sdl.JoystickRumble(joystick, 0, 0, 0);
                Sdl.JoystickClose(joystick);
            }
        }

        /// <summary>
        ///     Tests that game controller query functions do not crash without devices
        /// </summary>
        [RequireSdl2Fact]
        public void GameControllerQueries_DoNotCrash()
        {
            Sdl.GameControllerAddMapping("03000000123456780000000000000000,coverage,a:b0,b:b1,x:b2,y:b3");
            Sdl.GameControllerNumMappings();
            Sdl.GameControllerMappingForIndex(0);
            Sdl.GameControllerAddMappingsFromFile("nonexistent_mappings.txt");
            Sdl.GameControllerMappingForGuid(Guid.Empty);
            Sdl.GameControllerMapping(IntPtr.Zero);
            Sdl.IsGameController(0);
            Sdl.GameControllerNameForIndex(0);
            Sdl.GameControllerMappingForDeviceIndex(0);
            IntPtr controller = Sdl.GameControllerOpen(0);
            if (controller != IntPtr.Zero)
            {
                Sdl.GameControllerName(controller);
                Sdl.GameControllerGetVendor(controller);
                Sdl.GameControllerGetProduct(controller);
                Sdl.GameControllerGetProductVersion(controller);
                Sdl.GameControllerGetAttached(controller);
                Sdl.GameControllerGetJoystick(controller);
                Sdl.GameControllerGetBindForAxis(controller, GameControllerAxis.SdlControllerAxisLeftX);
                Sdl.GameControllerGetAxis(controller, GameControllerAxis.SdlControllerAxisLeftX);
                Sdl.GameControllerGetBindForButton(controller, GameControllerButton.SdlControllerButtonA);
                Sdl.GameControllerGetButton(controller, GameControllerButton.SdlControllerButtonA);
                Sdl.GameControllerRumble(controller, 0, 0, 0);
                Sdl.GameControllerClose(controller);
            }
            Sdl.GameControllerEventState(0);
            Sdl.GameControllerUpdate();
            Sdl.GameControllerGetAxisFromString("leftx");
            Sdl.GameControllerGetStringForAxis(GameControllerAxis.SdlControllerAxisLeftX);
            Sdl.GameControllerGetButtonFromString("a");
            Sdl.GameControllerGetStringForButton(GameControllerButton.SdlControllerButtonA);
            Sdl.GameControllerFromInstanceId(0);
        }

        /// <summary>
        ///     Tests that haptic query functions do not crash
        /// </summary>
        [RequireSdl2Fact]
        public void HapticQueries_DoNotCrash()
        {
            Sdl.NumHaptics();
            Sdl.MouseIsHaptic();
            Sdl.JoystickIsHaptic(IntPtr.Zero);
        }

        /// <summary>
        ///     Tests that joystick functions accept null pointers
        /// </summary>
        [RequireSdl2Fact]
        public void JoystickFunctions_WithNull_DoNotCrash()
        {
            Sdl.JoystickRumble(IntPtr.Zero, 0, 0, 0);
            Sdl.JoystickClose(IntPtr.Zero);
            Sdl.JoystickGetAxis(IntPtr.Zero, 0);
            ushort state;
            Sdl.JoystickGetAxisInitialState(IntPtr.Zero, 0, out state);
            int dx;
            int dy;
            Sdl.JoystickGetBall(IntPtr.Zero, 0, out dx, out dy);
            Sdl.JoystickGetButton(IntPtr.Zero, 0);
            Sdl.JoystickGetHat(IntPtr.Zero, 0);
            Sdl.JoystickName(IntPtr.Zero);
            Sdl.JoystickNumAxes(IntPtr.Zero);
            Sdl.JoystickNumBalls(IntPtr.Zero);
            Sdl.JoystickNumButtons(IntPtr.Zero);
            Sdl.JoystickNumHats(IntPtr.Zero);
            Sdl.JoystickGetGuid(IntPtr.Zero);
            Sdl.JoystickGetVendor(IntPtr.Zero);
            Sdl.JoystickGetProduct(IntPtr.Zero);
            Sdl.JoystickGetProductVersion(IntPtr.Zero);
            Sdl.JoystickGetType(IntPtr.Zero);
            Sdl.JoystickGetAttached(IntPtr.Zero);
            Sdl.JoystickInstanceId(IntPtr.Zero);
            Sdl.JoystickCurrentPowerLevel(IntPtr.Zero);
            Sdl.JoystickFromInstanceId(0);
        }

        /// <summary>
        ///     Tests that game controller functions accept null pointers
        /// </summary>
        [RequireSdl2Fact]
        public void GameControllerFunctions_WithNull_DoNotCrash()
        {
            Sdl.GameControllerName(IntPtr.Zero);
            Sdl.GameControllerGetVendor(IntPtr.Zero);
            Sdl.GameControllerGetProduct(IntPtr.Zero);
            Sdl.GameControllerGetProductVersion(IntPtr.Zero);
            Sdl.GameControllerGetAttached(IntPtr.Zero);
            Sdl.GameControllerGetJoystick(IntPtr.Zero);
            Sdl.GameControllerGetBindForAxis(IntPtr.Zero, GameControllerAxis.SdlControllerAxisLeftX);
            Sdl.GameControllerGetAxis(IntPtr.Zero, GameControllerAxis.SdlControllerAxisLeftX);
            Sdl.GameControllerGetBindForButton(IntPtr.Zero, GameControllerButton.SdlControllerButtonA);
            Sdl.GameControllerGetButton(IntPtr.Zero, GameControllerButton.SdlControllerButtonA);
            Sdl.GameControllerRumble(IntPtr.Zero, 0, 0, 0);
            Sdl.GameControllerClose(IntPtr.Zero);
        }
    }
}
