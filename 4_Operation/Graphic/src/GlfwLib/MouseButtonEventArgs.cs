// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MouseButtonEventArgs.cs
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
    ///     Arguments supplied with mouse button events.
    /// </summary>
    /// <seealso cref="EventArgs" />
    public class MouseButtonEventArgs : EventArgs
    {
        

        /// <summary>
        ///     Initializes a new instance of the <see cref="MouseButtonEventArgs" /> class.
        /// </summary>
        /// <param name="button">The mouse button.</param>
        /// <param name="state">The state of the <paramref name="button" />.</param>
        /// <param name="modifiers">The modifier keys.</param>
        public MouseButtonEventArgs(MouseButton button, InputState state, ModifierKeys modifiers)
        {
            Button = button;
            Action = state;
            Modifiers = modifiers;
        }

        

        

        /// <summary>
        ///     Gets the state of the mouse button when the event was raised.
        /// </summary>
        /// <value>
        ///     The action.
        /// </value>
        public InputState Action { get; }

        /// <summary>
        ///     Gets the mouse button that raised the event.
        /// </summary>
        /// <value>
        ///     The button.
        /// </value>
        public MouseButton Button { get; }

        /// <summary>
        ///     Gets the key modifiers present when mouse button was pressed.
        /// </summary>
        /// <value>
        ///     The modifiers.
        /// </value>
        public ModifierKeys Modifiers { get; }

        
    }
}