// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MouseMoveEventArgs.cs
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

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    ///     Mouse move event parameters
    /// </summary>
    public class MouseMoveEventArgs : EventArgs
    {
        /// <summary>
        ///     Gets or sets the X coordinate of the mouse cursor
        /// </summary>
        public int X { get; set; }

        /// <summary>
        ///     Gets or sets the Y coordinate of the mouse cursor
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        ///     Construct the mouse move arguments from a mouse move event
        /// </summary>
        /// <param name="e">Mouse move event</param>
        public MouseMoveEventArgs(MouseMoveEvent e)
        {
            X = e.X;
            Y = e.Y;
        }


        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        public override string ToString() => "[MouseMoveEventArgs]" +
                                             " X(" + X + ")" +
                                             " Y(" + Y + ")";
    }
}