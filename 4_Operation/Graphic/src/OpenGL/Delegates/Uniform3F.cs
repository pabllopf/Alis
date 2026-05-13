// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Uniform3F.cs
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
    /// Represents the unmanaged function pointer for the OpenGL glUniform3f command.
    /// Sets a three-component float vector uniform value in a program object.
    /// </summary>
    /// <param name="location">The location of the uniform variable to set.</param>
    /// <param name="value1">The first component (x) value.</param>
    /// <param name="value2">The second component (y) value.</param>
    /// <param name="value3">The third component (z) value.</param>
    public delegate void Uniform3F(int location, float value1, float value2, float value3);
}
