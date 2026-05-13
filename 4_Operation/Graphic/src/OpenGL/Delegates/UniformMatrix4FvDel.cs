// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UniformMatrix4FvDel.cs
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
    /// Represents the unmanaged function pointer for the OpenGL glUniformMatrix4fv command.
    /// Sets a 4x4 float matrix uniform value or an array of matrices in a program object.
    /// </summary>
    /// <param name="location">The location of the uniform variable to set.</param>
    /// <param name="count">The number of matrices to set.</param>
    /// <param name="transpose">Whether to transpose the matrix values (false for column-major).</param>
    /// <param name="value">An array of float values representing the matrix/matrices.</param>
    public delegate void UniformMatrix4FvDel(int location, int count, bool transpose, float[] value);
}
