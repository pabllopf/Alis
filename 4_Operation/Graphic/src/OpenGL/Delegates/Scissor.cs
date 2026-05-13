// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Scissor.cs
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
    /// Represents the unmanaged function pointer for the OpenGL glScissor command.
    /// Defines the scissor rectangle that constrains rendering to a sub-region of the viewport.
    /// </summary>
    /// <param name="x">The x-coordinate of the lower-left corner of the scissor rectangle.</param>
    /// <param name="y">The y-coordinate of the lower-left corner of the scissor rectangle.</param>
    /// <param name="width">The width of the scissor rectangle.</param>
    /// <param name="height">The height of the scissor rectangle.</param>
    public delegate void Scissor(int x, int y, int width, int height);
}
