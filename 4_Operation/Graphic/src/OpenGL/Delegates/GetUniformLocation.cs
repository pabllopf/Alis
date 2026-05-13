// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GetUniformLocation.cs
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
    /// Represents the unmanaged function pointer for the OpenGL glGetUniformLocation command.
    /// Returns the location of a uniform variable in a program object.
    /// </summary>
    /// <param name="program">The program object containing the uniform.</param>
    /// <param name="name">The name of the uniform variable.</param>
    /// <returns>The location (int) of the uniform, or -1 if not found.</returns>
    public delegate int GetUniformLocation(uint program, string name);
}
