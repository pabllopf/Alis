// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeyEventArgs.cs
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
using Alis.Core.Aspect.Data;
using Alis.Core.Aspect.Data.Mapping;
using Alis.Extension.Graphic.Glfw.Enums;

namespace Alis.Extension.Graphic.Glfw
{
    /// <summary>
    ///     Arguments supplied with keyboard events.
    /// </summary>
    /// <seealso cref="EventArgs" />
    public class KeyEventArgs : EventArgs
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="KeyEventArgs" /> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="scanCode">The platform scan code of the key.</param>
        /// <param name="state">The state of the key.</param>
        /// <param name="mods">The modifier keys.</param>
        public KeyEventArgs(Keys key, int scanCode, InputState state, ModifierKeys mods)
        {
            Key = key;
            ScanCode = scanCode;
            State = state;
            Modifiers = mods;
        }


        /// <summary>
        ///     Gets the key whose state change raised the event.
        /// </summary>
        /// <value>
        ///     The key.
        /// </value>
        public Keys Key { get; }

        /// <summary>
        ///     Gets the modifier keys at the time of the event.
        /// </summary>
        /// <value>
        ///     The modifiers.
        /// </value>
        public ModifierKeys Modifiers { get; }

        /// <summary>
        ///     Gets the platform scan code for the key.
        /// </summary>
        /// <value>
        ///     The scan code.
        /// </value>
        public int ScanCode { get; }

        /// <summary>
        ///     Gets the state of the key.
        /// </summary>
        /// <value>
        ///     The state.
        /// </value>
        public InputState State { get; }
    }
}