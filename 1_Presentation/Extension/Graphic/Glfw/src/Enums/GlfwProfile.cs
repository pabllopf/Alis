// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlfwProfile.cs
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

namespace Alis.Extension.Graphic.Glfw.Enums
{
    /// <summary>
    ///     Strongly-typed values used for getting/setting window hints.
    ///     <para>If OpenGL ES is requested, this hint is ignored.</para>
    /// </summary>
    public enum GlfwProfile
    {
        /// <summary>
        ///     Indicates no preference on profile.
        ///     <para>If requesting an OpenGL version below 3.2, this profile must be used.</para>
        /// </summary>
        Any = 0x00000000,

        /// <summary>
        ///     Indicates OpenGL Core profile.
        ///     <para>Only if requested OpenGL is greater than 3.2.</para>
        /// </summary>
        Core = 0x00032001,

        /// <summary>
        ///     Indicates OpenGL Compatibility profile.
        ///     <para>Only if requested OpenGL is greater than 3.2.</para>
        /// </summary>
        Compatibility = 0x00032002
    }
}