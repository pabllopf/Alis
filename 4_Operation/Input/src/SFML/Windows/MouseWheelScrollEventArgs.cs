// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MouseWheelScrollEventArgs.cs
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
    ///     Mouse wheel scroll event parameters
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class MouseWheelScrollEventArgs : EventArgs
    {
        /// <summary>Scroll amount</summary>
        public float Delta;

        /// <summary>Mouse Wheel which triggered the event</summary>
        public Mouse.Wheel Wheel;

        /// <summary>X coordinate of the mouse cursor</summary>
        public int X;

        /// <summary>Y coordinate of the mouse cursor</summary>
        public int Y;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the mouse wheel scroll arguments from a mouse wheel scroll event
        /// </summary>
        /// <param name="e">Mouse wheel scroll event</param>
        ////////////////////////////////////////////////////////////
        public MouseWheelScrollEventArgs(MouseWheelScrollEvent e)
        {
            Delta = e.Delta;
            Wheel = e.Wheel;
            X = e.X;
            Y = e.Y;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() => "[MouseWheelScrollEventArgs]" +
                                             " Wheel(" + Wheel + ")" +
                                             " Delta(" + Delta + ")" +
                                             " X(" + X + ")" +
                                             " Y(" + Y + ")";
    }
}