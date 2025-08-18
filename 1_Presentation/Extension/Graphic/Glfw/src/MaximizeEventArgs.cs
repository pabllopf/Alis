// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MaximizeEventArgs.cs
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

namespace Alis.Extension.Graphic.Glfw
{
    /// <summary>
    ///     Arguments supplied with maximize events.
    /// </summary>
    public class MaximizeEventArgs : EventArgs
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MaximizeEventArgs" /> class.
        /// </summary>
        /// <param name="maximized"><c>true</c> it maximized, otherwise <c>false</c>.</param>
        public MaximizeEventArgs(bool maximized) => IsMaximized = maximized;

        /// <summary>
        ///     Gets value indicating if window was maximized, or being restored.
        /// </summary>
        public bool IsMaximized { get; }
    }
}