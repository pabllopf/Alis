// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Uniform4Fv.cs
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
    /// Represents the unmanaged function pointer for the OpenGL glUniform4fv command.
    /// Sets an array of four-component float vector uniform values in a program object.
    /// </summary>
    /// <param name="location">The location of the uniform variable to set.</param>
    /// <param name="count">The number of vector elements to set.</param>
    /// <param name="value">An array of float values representing the vectors.</param>
    public delegate void Uniform4Fv(int location, int count, float[] value);
}
