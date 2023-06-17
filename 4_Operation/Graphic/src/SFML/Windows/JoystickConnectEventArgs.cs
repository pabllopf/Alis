// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JoystickConnectEventArgs.cs
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

namespace Alis.Core.Graphic.SFML.Windows
{
    /// <summary>
    ///     Joystick connection/disconnection event parameters
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class JoystickConnectEventArgs : EventArgs
    {
        /// <summary>Index of the joystick which triggered the event</summary>
        public readonly uint JoystickId;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the joystick connect arguments from a joystick connect event
        /// </summary>
        /// <param name="e">Joystick button event</param>
        ////////////////////////////////////////////////////////////
        public JoystickConnectEventArgs(JoystickConnectEvent e) => JoystickId = e.JoystickId;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() => "[JoystickConnectEventArgs]" +
                                             " JoystickId(" + JoystickId + ")";
    }
}