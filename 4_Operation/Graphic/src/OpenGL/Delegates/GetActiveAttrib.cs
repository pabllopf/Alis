// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GetActiveAttrib.cs
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
    /// Represents the unmanaged function pointer for the OpenGL glGetActiveAttrib command.
    /// Returns information about an active vertex attribute variable in a program object.
    /// </summary>
    /// <param name="program">The program object being queried.</param>
    /// <param name="index">The index of the active attribute to query.</param>
    /// <param name="bufSize">The maximum number of characters to store in the name buffer.</param>
    /// <param name="length">Returns the actual length of the attribute name.</param>
    /// <param name="size">Returns the size of the attribute.</param>
    /// <param name="type">Returns the data type of the attribute.</param>
    /// <param name="name">Returns the name of the attribute.</param>
    public delegate void GetActiveAttrib(uint program, uint index, int bufSize, int[] length, int[] size, ActiveAttribType[] type, StringBuilder name);
}
