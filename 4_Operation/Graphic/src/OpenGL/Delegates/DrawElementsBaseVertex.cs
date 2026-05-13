// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DrawElementsBaseVertex.cs
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
    /// Represents the unmanaged function pointer for the OpenGL glDrawElementsBaseVertex command.
    /// Renders primitives from array data with a per-element offset applied to each indexed vertex.
    /// </summary>
    /// <param name="mode">The type of primitive to render.</param>
    /// <param name="count">The number of elements to render.</param>
    /// <param name="type">The data type of the index values.</param>
    /// <param name="indices">A pointer to the index data or offset into the element array buffer.</param>
    /// <param name="basevertex">A constant offset added to each element's index before fetching vertices.</param>
    public delegate void DrawElementsBaseVertex(PrimitiveType mode, int count, DrawElementsType type, IntPtr indices, int basevertex);
}
