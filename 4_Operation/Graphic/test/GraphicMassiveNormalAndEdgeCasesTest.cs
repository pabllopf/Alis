// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GraphicMassiveNormalAndEdgeCasesTest.cs
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

using System;
using System.Collections.Generic;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.Test
{
    /// <summary>
    /// Adds a large matrix of enum-focused cases to validate normal and out-of-range values.
    /// </summary>
    public class GraphicMassiveNormalAndEdgeCasesTest
    {
        /// <summary>
        /// Generates the open gl enum cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateOpenGlEnumCases()
        {
            string[] enumNames = {"BeginMode", "BufferTarget", "TextureTarget", "ShaderType", "PixelFormat"};
            for (int value = -250; value < 250; value++)
            {
                foreach (string enumName in enumNames)
                {
                    yield return new object[] {enumName, value};
                }
            }
        }

        /// <summary>
        /// Gets the enum type using the specified enum name
        /// </summary>
        /// <param name="enumName">The enum name</param>
        /// <exception cref="ArgumentOutOfRangeException">null</exception>
        /// <returns>The type</returns>
        private static Type GetEnumType(string enumName)
        {
            return enumName switch
            {
                "BeginMode" => typeof(BeginMode),
                "BufferTarget" => typeof(BufferTarget),
                "TextureTarget" => typeof(TextureTarget),
                "ShaderType" => typeof(ShaderType),
                "PixelFormat" => typeof(PixelFormat),
                _ => throw new ArgumentOutOfRangeException(nameof(enumName), enumName, null)
            };
        }

        /// <summary>
        /// Boxes the enum name
        /// </summary>
        /// <param name="enumName">The enum name</param>
        /// <param name="rawValue">The raw value</param>
        /// <exception cref="ArgumentOutOfRangeException">null</exception>
        /// <returns>The enum</returns>
        private static Enum Box(string enumName, int rawValue)
        {
            return enumName switch
            {
                "BeginMode" => (BeginMode) rawValue,
                "BufferTarget" => (BufferTarget) rawValue,
                "TextureTarget" => (TextureTarget) rawValue,
                "ShaderType" => (ShaderType) rawValue,
                "PixelFormat" => (PixelFormat) rawValue,
                _ => throw new ArgumentOutOfRangeException(nameof(enumName), enumName, null)
            };
        }
    }
}


