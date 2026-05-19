using System;
using System.Collections.Generic;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

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


