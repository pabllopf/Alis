// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ShaderDeterministicCoverageTests.cs
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
using Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test
{
    /// <summary>
    ///     The shader deterministic coverage tests class
    /// </summary>
    public class ShaderDeterministicCoverageTests
    {
        /// <summary>
        ///     Tests that a shader can be constructed from an arbitrary native pointer without native work
        /// </summary>
        [Fact]
        public void Shader_IntPtr_Ctor_DoesNotThrow()
        {
            Shader shader = new Shader(IntPtr.Zero);
            Assert.NotNull(shader);
        }

        /// <summary>
        ///     Tests that set uniform array with a null float array throws argument null exception before any native call
        /// </summary>
        [Fact]
        public void SetUniformArray_NullFloatArray_Throws_NullArray()
        {
            Shader shader = new Shader(IntPtr.Zero);
            Assert.Throws<NullReferenceException>((Action)(() => shader.SetUniformArray("g", (float[])null)));
        }

        /// <summary>
        ///     Tests that set uniform array with a null vec2 array throws argument null exception before any native call
        /// </summary>
        [Fact]
        public void SetUniformArray_NullVec2Array_Throws_NullArray()
        {
            Shader shader = new Shader(IntPtr.Zero);
            Assert.Throws<NullReferenceException>((Action)(() => shader.SetUniformArray("g", (Vec2[])null)));
        }

        /// <summary>
        ///     Tests that set uniform array with a null vec3 array throws argument null exception before any native call
        /// </summary>
        [Fact]
        public void SetUniformArray_NullVec3Array_Throws_NullArray()
        {
            Shader shader = new Shader(IntPtr.Zero);
            Assert.Throws<NullReferenceException>((Action)(() => shader.SetUniformArray("g", (Vec3[])null)));
        }

        /// <summary>
        ///     Tests that set uniform array with a null vec4 array throws argument null exception before any native call
        /// </summary>
        [Fact]
        public void SetUniformArray_NullVec4Array_Throws_NullArray()
        {
            Shader shader = new Shader(IntPtr.Zero);
            Assert.Throws<NullReferenceException>((Action)(() => shader.SetUniformArray("g", (Vec4[])null)));
        }

        /// <summary>
        ///     Tests that set uniform array with a null matrix3x3 array throws argument null exception before any native call
        /// </summary>
        [Fact]
        public void SetUniformArray_NullMatrix3X3Array_Throws_NullArray()
        {
            Shader shader = new Shader(IntPtr.Zero);
            Assert.Throws<NullReferenceException>((Action)(() => shader.SetUniformArray("g", (Alis.Core.Aspect.Math.Matrix.Matrix3X3[])null)));
        }

        /// <summary>
        ///     Tests that set uniform array with a null matrix4x4 array throws argument null exception before any native call
        /// </summary>
        [Fact]
        public void SetUniformArray_NullMatrix4X4Array_Throws_NullArray()
        {
            Shader shader = new Shader(IntPtr.Zero);
            Assert.Throws<NullReferenceException>((Action)(() => shader.SetUniformArray("g", (Alis.Core.Aspect.Math.Matrix.Matrix4X4[])null)));
        }

        /// <summary>
        ///     Tests the current texture type constructor is accessible without native work
        /// </summary>
        [Fact]
        public void CurrentTextureType_Ctor_IsAccessible()
        {
            Shader.CurrentTextureType current = new Shader.CurrentTextureType();
            Assert.NotNull(current);
        }

        /// <summary>
        ///     Tests the to string returns the shader marker
        /// </summary>
        [Fact]
        public void ToString_ReturnsShaderMarker()
        {
            Shader shader = new Shader(IntPtr.Zero);
            Assert.Equal("[Shader]", shader.ToString());
        }
    }
}