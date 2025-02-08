// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StringName.cs
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
    ///     The string name enum
    /// </summary>
    public enum StringName
    {
        /// <summary>
        ///     The vendor string name
        /// </summary>
        Vendor = 0x1F00,

        /// <summary>
        ///     The renderer string name
        /// </summary>
        Renderer = 0x1F01,

        /// <summary>
        ///     The version string name
        /// </summary>
        Version = 0x1F02,

        /// <summary>
        ///     The extensions string name
        /// </summary>
        Extensions = 0x1F03,

        /// <summary>
        ///     The shading language version string name
        /// </summary>
        ShadingLanguageVersion = 0x8B8C
    }
}