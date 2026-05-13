// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Color4f.cs
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
    /// Represents the unmanaged function pointer for the legacy OpenGL glColor4f command.
    /// Sets the current RGBA color in immediate mode.
    /// </summary>
    /// <param name="red">The red component (range 0.0 to 1.0).</param>
    /// <param name="green">The green component (range 0.0 to 1.0).</param>
    /// <param name="blue">The blue component (range 0.0 to 1.0).</param>
    /// <param name="alpha">The alpha component (range 0.0 to 1.0).</param>
    public delegate void Color4F(float red, float green, float blue, float alpha);
}
