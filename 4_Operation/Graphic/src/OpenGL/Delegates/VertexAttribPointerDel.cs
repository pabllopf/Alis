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
//  --------------------------------------------------------------------------

using System;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.OpenGL.Delegates
{
    /// <summary>
    /// Represents the unmanaged function pointer for the OpenGL glVertexAttribPointer command.
    /// Specifies the layout of a generic vertex attribute array for rendering.
    /// </summary>
    /// <param name="index">The index of the generic vertex attribute to configure.</param>
    /// <param name="size">The number of components per vertex attribute (1-4).</param>
    /// <param name="type">The data type of each component.</param>
    /// <param name="normalized">Whether fixed-point data values should be normalized.</param>
    /// <param name="stride">The byte offset between consecutive vertex attributes.</param>
    /// <param name="pointer">A pointer to the first component or an offset into the bound vertex buffer.</param>
    public delegate void VertexAttribPointerDel(uint index, int size, VertexAttribPointerType type, bool normalized, int stride, IntPtr pointer);
}
