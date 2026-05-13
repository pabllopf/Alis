// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ParamType.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  --------------------------------------------------------------------------

namespace Alis.Core.Graphic.OpenGL.Constructs
{
    /// <summary>
    /// Defines the type of a shader program parameter, distinguishing between uniforms and vertex attributes.
    /// </summary>
    public enum ParamType
    {
        /// <summary>The parameter is a uniform variable, constant across all vertices in a draw call.</summary>
        Uniform,

        /// <summary>The parameter is a vertex attribute, varying per vertex.</summary>
        Attribute
    }
}
