// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VertexAttribPointerDel.cs
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

namespace Alis.Core.Graphic.OpenGL.Delegates
{
    /// <summary>
    ///     Defines an array of generic vertex attribute data, specifying the layout of vertex data in a buffer
    /// </summary>
    /// <param name="index">Specifies the index of the generic vertex attribute to configure</param>
    /// <param name="size">Specifies the number of components per attribute</param>
    /// <param name="type">Specifies the data type of each component</param>
    /// <param name="normalized">Specifies whether fixed-point values should be normalized</param>
    /// <param name="stride">Specifies the byte offset between consecutive attribute values</param>
    /// <param name="pointer">Specifies the offset to the first component of the attribute</param>
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void VertexAttribPointerDel(uint index, int size, VertexAttribPointerType type, bool normalized, int stride, IntPtr pointer);
}