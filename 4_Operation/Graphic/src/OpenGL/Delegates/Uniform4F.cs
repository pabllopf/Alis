// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Uniform4F.cs
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
    /// Represents the unmanaged function pointer for the OpenGL glUniform4f command.
    /// Sets a four-component float vector uniform value in a program object.
    /// </summary>
    /// <param name="location">The location of the uniform variable to set.</param>
    /// <param name="value1">The first component (r/x) value.</param>
    /// <param name="value2">The second component (g/y) value.</param>
    /// <param name="value3">The third component (b/z) value.</param>
    /// <param name="value4">The fourth component (a/w) value.</param>
    public delegate void Uniform4F(int location, float value1, float value2, float value3, float value4);
}
