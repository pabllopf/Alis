// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameWindow.cs
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
using Alis.Extension.Graphic.Glfw.Structs;

namespace Alis.Extension.Graphic.Glfw
{
    /// <inheritdoc cref="NativeWindow" />
    
    public class GameWindow : NativeWindow
    {
        /// <inheritdoc cref="NativeWindow()" />
        
        public GameWindow()
        {
        }

        /// <inheritdoc cref="NativeWindow(int, int, string)" />
        
        public GameWindow(int width, int height, string title) : base(width, height, title)
        {
        }

        /// <inheritdoc cref="NativeWindow(int, int, string, Monitor, Window)" />
        
        public GameWindow(int width, int height, string title, Monitor monitor, Window share) : base(width, height,
            title, monitor, share)
        {
        }
    }
}