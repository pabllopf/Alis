// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ShaderSourceDel.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  --------------------------------------------------------------------------

namespace Alis.Core.Graphic.OpenGL.Delegates
{
    /// <summary>
    /// Represents the unmanaged function pointer for the OpenGL glShaderSource command.
    /// Sets the source code of a shader object.
    /// </summary>
    /// <param name="shader">The shader object to set source code on.</param>
    /// <param name="count">The number of source strings.</param>
    /// <param name="source">An array of strings containing the shader source code.</param>
    /// <param name="length">An array of lengths for each source string, or null for null-terminated strings.</param>
    public delegate void ShaderSourceDel(uint shader, int count, string[] source, int[] length);
}
