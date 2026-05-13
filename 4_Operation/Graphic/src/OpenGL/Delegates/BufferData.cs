// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BufferData.cs
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
    /// Represents the unmanaged function pointer for the OpenGL glBufferData command.
    /// Creates and initializes a buffer object's data store.
    /// </summary>
    /// <param name="target">The buffer target to which data will be uploaded.</param>
    /// <param name="size">The size of the data store in bytes.</param>
    /// <param name="data">A pointer to the data to be copied into the data store.</param>
    /// <param name="usage">The expected usage pattern of the data store.</param>
    public delegate void BufferData(BufferTarget target, IntPtr size, IntPtr data, BufferUsageHint usage);
}
