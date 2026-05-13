// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TexParameteri.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  --------------------------------------------------------------------------

using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.OpenGL.Delegates
{
    /// <summary>
    /// Represents the unmanaged function pointer for the OpenGL glTexParameteri command.
    /// Sets integer texture parameters such as filtering and wrapping modes.
    /// </summary>
    /// <param name="target">The texture target (e.g., Texture2D).</param>
    /// <param name="pname">The texture parameter name to set.</param>
    /// <param name="param">The integer value to set for the parameter.</param>
    public delegate void TexParameteri(TextureTarget target, TextureParameterName pname, TextureParameter param);
}
