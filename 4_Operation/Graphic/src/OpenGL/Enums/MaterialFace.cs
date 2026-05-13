// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MaterialFace.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

namespace Alis.Core.Graphic.OpenGL.Enums
{
    /// <summary>
    /// Defines which face(s) of a polygon are affected by material and lighting operations.
    /// Used with glMaterial and glLightModel functions to specify front, back, or both faces.
    /// </summary>
    public enum MaterialFace : uint
    {
        /// <summary>Front face of polygons (GL_FRONT = 0x0404).</summary>
        Front = 0x0404,

        /// <summary>Back face of polygons (GL_BACK = 0x0405).</summary>
        Back = 0x0405,

        /// <summary>Both front and back faces of polygons (GL_FRONT_AND_BACK = 0x0408).</summary>
        FrontAndBack = 0x0408
    }
}
