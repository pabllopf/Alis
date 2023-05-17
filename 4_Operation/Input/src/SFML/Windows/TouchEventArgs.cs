// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TouchEventArgs.cs
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
    ///     Touch event parameters
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class TouchEventArgs : EventArgs
    {
        /// <summary>Index of the finger in case of multi-touch events</summary>
        public uint Finger;

        /// <summary>X position of the touch, relative to the left of the owner window</summary>
        public int X;

        /// <summary>Y position of the touch, relative to the top of the owner window</summary>
        public int Y;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the touch arguments from a touch event
        /// </summary>
        /// <param name="e">Touch event</param>
        ////////////////////////////////////////////////////////////
        public TouchEventArgs(TouchEvent e)
        {
            Finger = e.Finger;
            X = e.X;
            Y = e.Y;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() => "[TouchEventArgs]" +
                                             " Finger(" + Finger + ")" +
                                             " X(" + X + ")" +
                                             " Y(" + Y + ")";
    }
}