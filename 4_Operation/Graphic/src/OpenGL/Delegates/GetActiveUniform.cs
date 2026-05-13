// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GetActiveUniform.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  --------------------------------------------------------------------------

using System.Text;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.OpenGL.Delegates
{
    /// <summary>
    /// Represents the unmanaged function pointer for the OpenGL glGetActiveUniform command.
    /// Returns information about an active uniform variable in a program object.
    /// </summary>
    /// <param name="program">The program object being queried.</param>
    /// <param name="index">The index of the active uniform to query.</param>
    /// <param name="bufSize">The maximum number of characters to store in the name buffer.</param>
    /// <param name="length">Returns the actual length of the uniform name.</param>
    /// <param name="size">Returns the size of the uniform.</param>
    /// <param name="type">Returns the data type of the uniform.</param>
    /// <param name="name">Returns the name of the uniform.</param>
    public delegate void GetActiveUniform(uint program, uint index, int bufSize, int[] length, int[] size, ActiveUniformType[] type, StringBuilder name);
}
