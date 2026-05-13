// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ClearColor.cs
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
    /// Represents the unmanaged function pointer for the OpenGL glClearColor command.
    /// Specifies the red, green, blue, and alpha values used when clearing the color buffer.
    /// </summary>
    /// <param name="red">The red component of the clear color (range 0.0 to 1.0).</param>
    /// <param name="green">The green component of the clear color (range 0.0 to 1.0).</param>
    /// <param name="blue">The blue component of the clear color (range 0.0 to 1.0).</param>
    /// <param name="alpha">The alpha component of the clear color (range 0.0 to 1.0).</param>
    public delegate void ClearColor(float red, float green, float blue, float alpha);
}
