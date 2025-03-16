// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CharEventArgs.cs
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
using Alis.Core.Graphic.GlfwLib.Enums;

namespace Alis.Core.Graphic.GlfwLib
{
    /// <summary>
    ///     Arguments supplied with char input events.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class CharEventArgs : EventArgs
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CharEventArgs" /> class.
        /// </summary>
        /// <param name="codePoint">A UTF-32 code point.</param>
        /// <param name="mods">The modifier keys present.</param>
        public CharEventArgs(uint codePoint, ModifierKeys mods)
        {
            CodePoint = codePoint;
            ModifierKeys = mods;
        }


        /// <summary>
        ///     Gets the Unicode character for the code point.
        /// </summary>
        /// <value>
        ///     The character.
        /// </value>
        public string Char => char.ConvertFromUtf32(unchecked((int) CodePoint));

        /// <summary>
        ///     Gets the platform independent code point.
        ///     <para>This value can be treated as a UTF-32 code point.</para>
        /// </summary>
        /// <value>
        ///     The code point.
        /// </value>
        public uint CodePoint { get; }

        /// <summary>
        ///     Gets the modifier keys.
        /// </summary>
        /// <value>
        ///     The modifier keys.
        /// </value>
        public ModifierKeys ModifierKeys { get; }
    }
}