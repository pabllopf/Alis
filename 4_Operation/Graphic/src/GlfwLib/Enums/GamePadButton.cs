// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GamePadButton.cs
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


namespace Alis.Core.Graphic.GlfwLib.Enums
{
    /// <summary>
    ///     Represents gamepad buttons.
    ///     <para>
    ///         Duplicate values convenience for providing naming conventions for common gamepads (PlayStation,
    ///         X-Box, etc).
    ///     </para>
    /// </summary>
    public enum GamePadButton : byte
    {
        /// <summary>
        ///     The  game pad button
        /// </summary>
        A = 0,

        /// <summary>
        ///     The  game pad button
        /// </summary>
        B = 1,

        /// <summary>
        ///     The  game pad button
        /// </summary>
        X = 2,

        /// <summary>
        ///     The  game pad button
        /// </summary>
        Y = 3,

        /// <summary>
        ///     The left bumper game pad button
        /// </summary>
        LeftBumper = 4,

        /// <summary>
        ///     The right bumper game pad button
        /// </summary>
        RightBumper = 5,

        /// <summary>
        ///     The back game pad button
        /// </summary>
        Back = 6,

        /// <summary>
        ///     The start game pad button
        /// </summary>
        Start = 7,

        /// <summary>
        ///     The guide game pad button
        /// </summary>
        Guide = 8,

        /// <summary>
        ///     The left thumb game pad button
        /// </summary>
        LeftThumb = 9,

        /// <summary>
        ///     The right thumb game pad button
        /// </summary>
        RightThumb = 10,

        /// <summary>
        ///     The dpad up game pad button
        /// </summary>
        DpadUp = 11,

        /// <summary>
        ///     The dpad right game pad button
        /// </summary>
        DpadRight = 12,

        /// <summary>
        ///     The dpad down game pad button
        /// </summary>
        DpadDown = 13,

        /// <summary>
        ///     The dpad left game pad button
        /// </summary>
        DpadLeft = 14,

        /// <summary>
        ///     The cross game pad button
        /// </summary>
        Cross = A,

        /// <summary>
        ///     The circle game pad button
        /// </summary>
        Circle = B,

        /// <summary>
        ///     The square game pad button
        /// </summary>
        Square = X,

        /// <summary>
        ///     The triangle game pad button
        /// </summary>
        Triangle = Y
    }
}