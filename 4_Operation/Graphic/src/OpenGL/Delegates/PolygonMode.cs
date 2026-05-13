// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PolygonMode.cs
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
    /// Represents the unmanaged function pointer for the OpenGL glPolygonMode command.
    /// Sets the polygon rasterization mode for the specified face.
    /// </summary>
    /// <param name="face">The face(s) to apply the mode to (e.g., Front, Back, FrontAndBack).</param>
    /// <param name="mode">The rasterization mode (e.g., Point, Line, Fill).</param>
    public delegate void PolygonMode(MaterialFace face, PolygonModeEnum mode);
}
