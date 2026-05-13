// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GetShaderInfoLogDel.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  --------------------------------------------------------------------------

using System.Text;

namespace Alis.Core.Graphic.OpenGL.Delegates
{
    /// <summary>
    /// Represents the unmanaged function pointer for the OpenGL glGetShaderInfoLog command.
    /// Returns the information log for a shader object.
    /// </summary>
    /// <param name="shader">The shader object to query.</param>
    /// <param name="bufSize">The maximum size of the info log buffer.</param>
    /// <param name="length">Returns the actual length of the info log.</param>
    /// <param name="infoLog">The buffer that receives the info log string.</param>
    public delegate void GetShaderInfoLogDel(uint shader, int bufSize, int[] length, StringBuilder infoLog);
}
