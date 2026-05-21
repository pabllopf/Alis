// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowContentsScaleCallback.cs
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

using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Glfw.Structs;

namespace Alis.Extension.Graphic.Glfw
{
    /// <summary>
    ///     This is the function signature for window content scale callback functions.
    /// </summary>
    /// <param name="window">The window whose content scale changed.</param>
    /// <param name="xScale">The new x-axis content scale of the window.</param>
    /// <param name="yScale">The new y-axis content scale of the window.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WindowContentsScaleCallback(Window window, float xScale, float yScale);
}