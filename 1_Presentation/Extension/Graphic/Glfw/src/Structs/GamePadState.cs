// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GamePadState.cs
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

using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Glfw.Enums;

namespace Alis.Extension.Graphic.Glfw.Structs
{
    /// <summary>
    ///     Represents the state of a gamepad.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GamePadState
    {
        /// <summary>
        ///     The states
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
        private readonly InputState[] states;

        /// <summary>
        ///     The axes
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        private readonly float[] axes;

        /// <summary>
        ///     Gets the state of the specified <paramref name="button" />.
        /// </summary>
        /// <param name="button">The button to retrieve the state of.</param>
        /// <returns>The button state, either <see cref="InputState.Press" /> or <see cref="InputState.Release" />.</returns>
        public InputState GetButtonState(GamePadButton button) => states[(int) button];

        /// <summary>
        ///     Gets the value of the specified <paramref name="axis" />.
        /// </summary>
        /// <param name="axis">The axis to retrieve the value of.</param>
        /// <returns>The axis value, in the range of <c>-1.0</c> and <c>1.0</c> inclusive.</returns>
        public float GetAxis(GamePadAxis axis) => axes[(int) axis];
    }
}