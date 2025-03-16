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
using System.Drawing;

namespace Alis.Core.Graphic.GlfwLib
{
    /// <summary>
    ///     Arguments supplied with mouse movement events.
    /// </summary>
    /// <seealso cref="EventArgs" />
    public class MouseMoveEventArgs : EventArgs
    {
        

        /// <summary>
        ///     Initializes a new instance of the <see cref="MouseMoveEventArgs" /> class.
        /// </summary>
        /// <param name="x">
        ///     The cursor x-coordinate, relative to the left edge of the client area, or the amount of movement on
        ///     x-axis if this is scroll event.
        /// </param>
        /// <param name="y">
        ///     The cursor y-coordinate, relative to the left edge of the client area, or the amount of movement on
        ///     y-axis if this is scroll event.
        /// </param>
        public MouseMoveEventArgs(double x, double y)
        {
            X = x;
            Y = y;
        }

        

        

        /// <summary>
        ///     Gets the position of the mouse, relative to the screen.
        /// </summary>
        /// <value>
        ///     The position.
        /// </value>
        public Point Position => new Point(Convert.ToInt32(X), Convert.ToInt32(Y));

        /// <summary>
        ///     Gets the cursor x-coordinate, relative to the left edge of the client area, or the amount of movement on
        ///     x-axis if this is scroll event.
        /// </summary>
        /// <value>
        ///     The location on the x-axis.
        /// </value>
        public double X { get; }

        /// <summary>
        ///     Gets the cursor y-coordinate, relative to the left edge of the client area, or the amount of movement on
        ///     y-axis if this is scroll event.
        /// </summary>
        /// <value>
        ///     The location on the y-axis.
        /// </value>
        public double Y { get; }

        
    }
}