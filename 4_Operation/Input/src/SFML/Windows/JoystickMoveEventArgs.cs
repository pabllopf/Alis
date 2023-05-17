// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JoystickMoveEventArgs.cs
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

namespace Alis.Core.Input.SFML.Windows
{
    /// <summary>
    ///     Joystick axis move event parameters
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class JoystickMoveEventArgs : EventArgs
    {
        /// <summary>Joystick axis (see JoyAxis enum)</summary>
        public Axis Axis;

        /// <summary>Index of the joystick which triggered the event</summary>
        public uint JoystickId;

        /// <summary>Current position of the axis</summary>
        public float Position;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the joystick move arguments from a joystick move event
        /// </summary>
        /// <param name="e">Joystick move event</param>
        ////////////////////////////////////////////////////////////
        public JoystickMoveEventArgs(JoystickMoveEvent e)
        {
            JoystickId = e.JoystickId;
            Axis = e.Axis;
            Position = e.Position;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() => "[JoystickMoveEventArgs]" +
                                             " JoystickId(" + JoystickId + ")" +
                                             " Axis(" + Axis + ")" +
                                             " Position(" + Position + ")";
    }
}