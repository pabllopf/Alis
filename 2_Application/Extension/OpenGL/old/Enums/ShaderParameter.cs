// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ShaderParameter.cs
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

namespace Alis.Extension.OpenGL.Enums
{
    /// <summary>
    ///     The shader parameter enum
    /// </summary>
    public enum ShaderParameter
    {
        /// <summary>
        ///     The shader type shader parameter
        /// </summary>
        ShaderType = 0x8B4F,

        /// <summary>
        ///     The delete status shader parameter
        /// </summary>
        DeleteStatus = 0x8B80,

        /// <summary>
        ///     The compile status shader parameter
        /// </summary>
        CompileStatus = 0x8B81,

        /// <summary>
        ///     The info log length shader parameter
        /// </summary>
        InfoLogLength = 0x8B84,

        /// <summary>
        ///     The shader source length shader parameter
        /// </summary>
        ShaderSourceLength = 0x8B88
    }
}