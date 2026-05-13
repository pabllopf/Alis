// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GetString.cs
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
    /// Represents the unmanaged function pointer for the OpenGL glGetString command.
    /// Returns a string describing the current OpenGL connection.
    /// </summary>
    /// <param name="name">The symbolic constant identifying the string to return.</param>
    /// <returns>A pointer to the null-terminated string in OpenGL's internal memory.</returns>
    public delegate IntPtr GetString(StringName name);
}
