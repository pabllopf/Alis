// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DrawElements.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.OpenGL
{
    /// <summary>
    /// Represents the unmanaged function pointer for the OpenGL glDrawElements command.
    /// Renders primitives from array data using index values stored in a bound element array buffer.
    /// </summary>
    /// <param name="mode">The type of primitive to render (e.g., Triangles, Lines, Points).</param>
    /// <param name="count">The number of elements to render.</param>
    /// <param name="type">The data type of the index values in the element array buffer.</param>
    /// <param name="indices">A pointer to the index data, or an offset into the bound element array buffer.</param>
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void DrawElements(PrimitiveType mode, int count, DrawElementsType type, IntPtr indices);
}
