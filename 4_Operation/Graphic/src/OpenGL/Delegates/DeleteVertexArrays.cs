// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DeleteVertexArrays.cs
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
    /// Represents the unmanaged function pointer for the OpenGL glDeleteVertexArrays command.
    /// Deletes named vertex array objects (VAOs), freeing their resources.
    /// </summary>
    /// <param name="n">The number of vertex array objects to delete.</param>
    /// <param name="vaos">An array of vertex array object names to delete.</param>
    public delegate void DeleteVertexArrays(int n, uint[] vaos);
}
