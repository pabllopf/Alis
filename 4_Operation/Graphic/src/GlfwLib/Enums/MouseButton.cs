// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MouseButton.cs
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
    ///     Strongly-typed enumeration describing mouse buttons.
    /// </summary>
    public enum MouseButton
    {
        /// <summary>
        ///     Mouse button 1.
        ///     <para>Same as <see cref="Left" />.</para>
        /// </summary>
        Button1 = 0,

        /// <summary>
        ///     Mouse button 2.
        ///     <para>Same as <see cref="Right" />.</para>
        /// </summary>
        Button2 = 1,

        /// <summary>
        ///     Mouse button 3.
        ///     <para>Same as <see cref="Middle" />.</para>
        /// </summary>
        Button3 = 2,

        /// <summary>
        ///     Mouse button 4.
        /// </summary>
        Button4 = 3,

        /// <summary>
        ///     Mouse button 4.
        /// </summary>
        Button5 = 4,

        /// <summary>
        ///     Mouse button 5.
        /// </summary>
        Button6 = 5,

        /// <summary>
        ///     Mouse button 6.
        /// </summary>
        Button7 = 6,

        /// <summary>
        ///     Mouse button 7.
        /// </summary>
        Button8 = 7,

        /// <summary>
        ///     The left mouse button.
        ///     <para>Same as <see cref="Button1" />.</para>
        /// </summary>
        Left = Button1,

        /// <summary>
        ///     The right mouse button.
        ///     <para>Same as <see cref="Button2" />.</para>
        /// </summary>
        Right = Button2,

        /// <summary>
        ///     The middle mouse button.
        ///     <para>Same as <see cref="Button3" />.</para>
        /// </summary>
        Middle = Button3
    }
}