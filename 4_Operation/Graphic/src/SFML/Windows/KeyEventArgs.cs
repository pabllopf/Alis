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

namespace Alis.Core.Graphic.D2.SFML.Windows
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     Keyboard event parameters
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class KeyEventArgs : EventArgs
    {
        /// <summary>Is the Alt modifier pressed?</summary>
        public bool Alt;

        /// <summary>Code of the key (see KeyCode enum)</summary>
        public Key Code;

        /// <summary>Is the Control modifier pressed?</summary>
        public bool Control;

        /// <summary>Is the Shift modifier pressed?</summary>
        public bool Shift;

        /// <summary>Is the System modifier pressed?</summary>
        public bool System;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the key arguments from a key event
        /// </summary>
        /// <param name="e">Key event</param>
        ////////////////////////////////////////////////////////////
        public KeyEventArgs(KeyEvent e)
        {
            Code = e.Code;
            Alt = e.Alt != 0;
            Control = e.Control != 0;
            Shift = e.Shift != 0;
            System = e.System != 0;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() => "[KeyEventArgs]" +
                                             " Code(" + Code + ")" +
                                             " Alt(" + Alt + ")" +
                                             " Control(" + Control + ")" +
                                             " Shift(" + Shift + ")" +
                                             " System(" + System + ")";
    }

    ////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////
}