// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ShaderExecutionTests.cs
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
using System.IO;
using System.Text;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Windows;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Execution tests for the <see cref="Shader"/> class that run the
    ///     wrappers against the native CSFML library
    /// </summary>
    public class ShaderExecutionTests
    {
        /// <summary>
        ///     The fragment shader source
        /// </summary>
        private const string FragmentSource = "uniform float f;uniform vec2 v2;uniform vec3 v3;uniform vec4 v4;uniform int i;uniform ivec2 i2;uniform ivec3 i3;uniform ivec4 i4;uniform bool b;uniform bvec2 b2;uniform bvec3 b3;uniform bvec4 b4;uniform mat3 m3;uniform mat4 m4;void main(){ gl_FragColor = vec4(f, v2.x, v3.y, v4.w); }";

        /// <summary>
        ///     Tests the shader from string with a valid fragment source
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void FromString_ValidFragmentSource_ReturnsShader()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            Assert.NotNull(shader);
            Assert.NotEqual(IntPtr.Zero, shader.CPointer);
        }

        /// <summary>
        ///     Tests the shader from string throws on invalid source
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void FromString_InvalidSource_Throws()
        {
            Assert.Throws<LoadingFailedException>(() => Shader.FromString(null, null, "this is not a shader"));
        }

        /// <summary>
        ///     Tests the shader from string with a vertex and a fragment source
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void FromString_VertexAndFragment_ReturnsShader()
        {
            using Shader shader = Shader.FromString("void main() { gl_Position = gl_Vertex; }", null, FragmentSource);
            Assert.NotEqual(IntPtr.Zero, shader.CPointer);
        }

        /// <summary>
        ///     Tests the constructor from file throws on a nonexistent path
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Constructor_FromFile_NonexistentPath_Throws()
        {
            Assert.Throws<LoadingFailedException>(() => new Shader(null, null, "/nonexistent/shader.glsl"));
        }

        /// <summary>
        ///     Tests the constructor from stream with a valid fragment stream
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Constructor_FromStream_ValidFragment_ReturnsShader()
        {
            byte[] bytes = Encoding.UTF8.GetBytes(FragmentSource);
            using MemoryStream stream = new MemoryStream(bytes);
            using Shader shader = new Shader(null, null, stream);
            Assert.NotEqual(IntPtr.Zero, shader.CPointer);
        }

        /// <summary>
        ///     Tests the constructor from stream throws on an empty stream
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Constructor_FromStream_EmptyStream_Throws()
        {
            using MemoryStream stream = new MemoryStream();
            Assert.Throws<LoadingFailedException>(() => new Shader(null, null, stream));
        }

        /// <summary>
        ///     Tests the constructor from a zero pointer
        /// </summary>
        [Fact]
        public void Constructor_FromPointer_ZeroPointer()
        {
            using Shader shader = new Shader(IntPtr.Zero);
            Assert.Equal(IntPtr.Zero, shader.CPointer);
        }

        /// <summary>
        ///     Tests the is available property returns without throwing
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void IsAvailable_ReturnsWithoutThrowing()
        {
            bool available = Shader.IsAvailable;
            Assert.IsType<bool>(available);
        }

        /// <summary>
        ///     Tests the is geometry available property returns without throwing
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void IsGeometryAvailable_ReturnsWithoutThrowing()
        {
            bool available = Shader.IsGeometryAvailable;
            Assert.IsType<bool>(available);
        }

        /// <summary>
        ///     Tests the current texture static field is null
        /// </summary>
        [Fact]
        public void CurrentTexture_IsNull()
        {
            Assert.Null(Shader.CurrentTexture);
        }

        /// <summary>
        ///     Tests the current texture type constructor
        /// </summary>
        [Fact]
        public void CurrentTextureType_Constructor_ReturnsInstance()
        {
            Shader.CurrentTextureType current = new Shader.CurrentTextureType();
            Assert.NotNull(current);
        }

        /// <summary>
        ///     Tests the native handle is readable on a real shader
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void NativeHandle_OnRealShader_ReturnsValue()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            uint handle = shader.NativeHandle;
            Assert.IsType<uint>(handle);
        }

        /// <summary>
        ///     Tests the set uniform float overload
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetUniform_Float_DoesNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            shader.SetUniform("f", 1.5f);
        }

        /// <summary>
        ///     Tests the set uniform vec2 overload
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetUniform_Vec2_DoesNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            shader.SetUniform("v2", new Vec2(1.0f, 2.0f));
        }

        /// <summary>
        ///     Tests the set uniform vec3 overload
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetUniform_Vec3_DoesNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            shader.SetUniform("v3", new Vec3(1.0f, 2.0f, 3.0f));
        }

        /// <summary>
        ///     Tests the set uniform vec4 overload
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetUniform_Vec4_DoesNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            shader.SetUniform("v4", new Vec4(1.0f, 2.0f, 3.0f, 4.0f));
        }

        /// <summary>
        ///     Tests the set uniform int overload
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetUniform_Int_DoesNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            shader.SetUniform("i", 7);
        }

        /// <summary>
        ///     Tests the set uniform ivec2 overload
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetUniform_Ivec2_DoesNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            shader.SetUniform("i2", new Ivec2(1, 2));
        }

        /// <summary>
        ///     Tests the set uniform ivec3 overload
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetUniform_Ivec3_DoesNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            shader.SetUniform("i3", new Ivec3(1, 2, 3));
        }

        /// <summary>
        ///     Tests the set uniform ivec4 overload
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetUniform_Ivec4_DoesNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            shader.SetUniform("i4", new Ivec4(1, 2, 3, 4));
        }

        /// <summary>
        ///     Tests the set uniform bool overload
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetUniform_Bool_DoesNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            shader.SetUniform("b", true);
        }

        /// <summary>
        ///     Tests the set uniform bvec2 overload
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetUniform_Bvec2_DoesNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            shader.SetUniform("b2", new Bvec2(true, false));
        }

        /// <summary>
        ///     Tests the set uniform bvec3 overload
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetUniform_Bvec3_DoesNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            shader.SetUniform("b3", new Bvec3(true, false, true));
        }

        /// <summary>
        ///     Tests the set uniform bvec4 overload
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetUniform_Bvec4_DoesNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            shader.SetUniform("b4", new Bvec4(true, false, true, false));
        }

        /// <summary>
        ///     Tests the set uniform mat3 overload
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetUniform_Mat3_DoesNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            shader.SetUniform("m3", new Matrix3X3(1.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 0.0f, 1.0f));
        }

        /// <summary>
        ///     Tests the set uniform mat4 overload
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetUniform_Mat4_DoesNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            shader.SetUniform("m4", Matrix4X4.Identity);
        }

        /// <summary>
        ///     Tests the set uniform texture overload with a real texture
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetUniform_Texture_DoesNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            using Texture texture = new Texture(Path.Combine(Path.GetDirectoryName(typeof(ShaderExecutionTests).Assembly.Location), "..", "..", "..", "Assets", "tile000.bmp"));
            shader.SetUniform("tex", texture);
        }

        /// <summary>
        ///     Tests the set uniform current texture overload
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetUniform_CurrentTexture_DoesNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            shader.SetUniform("tex", Shader.CurrentTexture);
        }

        /// <summary>
        ///     Tests the set uniform array float overload
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetUniformArray_Float_DoesNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            shader.SetUniformArray("f", new float[] { 1.0f, 2.0f, 3.0f });
        }

        /// <summary>
        ///     Tests the set uniform array vec2 overload
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetUniformArray_Vec2_DoesNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            shader.SetUniformArray("v2", new[] { new Vec2(1.0f, 2.0f), new Vec2(3.0f, 4.0f) });
        }

        /// <summary>
        ///     Tests the set uniform array vec3 overload
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetUniformArray_Vec3_DoesNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            shader.SetUniformArray("v3", new[] { new Vec3(1.0f, 2.0f, 3.0f) });
        }

        /// <summary>
        ///     Tests the set uniform array vec4 overload
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetUniformArray_Vec4_DoesNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            shader.SetUniformArray("v4", new[] { new Vec4(1.0f, 2.0f, 3.0f, 4.0f) });
        }

        /// <summary>
        ///     Tests the set uniform array mat3 overload
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetUniformArray_Mat3_DoesNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            shader.SetUniformArray("m3", new[] { new Matrix3X3(1.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 0.0f, 1.0f) });
        }

        /// <summary>
        ///     Tests the set uniform array mat4 overload
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetUniformArray_Mat4_DoesNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            shader.SetUniformArray("m4", new[] { Matrix4X4.Identity });
        }

        /// <summary>
        ///     Tests the set parameter float overload throws entry point not found
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetParameter_Float_ThrowsEntryPointNotFound()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            Assert.Throws<EntryPointNotFoundException>(() => shader.SetParameter("f", 1.0f));
        }

        /// <summary>
        ///     Tests the set parameter float2 overload throws entry point not found
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetParameter_Float2_ThrowsEntryPointNotFound()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            Assert.Throws<EntryPointNotFoundException>(() => shader.SetParameter("v", 1.0f, 2.0f));
        }

        /// <summary>
        ///     Tests the set parameter float3 overload throws entry point not found
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetParameter_Float3_ThrowsEntryPointNotFound()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            Assert.Throws<EntryPointNotFoundException>(() => shader.SetParameter("v", 1.0f, 2.0f, 3.0f));
        }

        /// <summary>
        ///     Tests the set parameter float4 overload throws entry point not found
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetParameter_Float4_ThrowsEntryPointNotFound()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            Assert.Throws<EntryPointNotFoundException>(() => shader.SetParameter("v", 1.0f, 2.0f, 3.0f, 4.0f));
        }

        /// <summary>
        ///     Tests the set parameter vector2f overload throws entry point not found
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetParameter_Vector2F_ThrowsEntryPointNotFound()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            Assert.Throws<EntryPointNotFoundException>(() => shader.SetParameter("v", new Vector2F(1.0f, 2.0f)));
        }

        /// <summary>
        ///     Tests the set parameter color overload throws entry point not found
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetParameter_Color_ThrowsEntryPointNotFound()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            Assert.Throws<EntryPointNotFoundException>(() => shader.SetParameter("c", new Color(255, 0, 0)));
        }

        /// <summary>
        ///     Tests the set parameter transform overload throws entry point not found
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetParameter_Transform_ThrowsEntryPointNotFound()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            Transform transform = new Transform(1.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 0.0f, 1.0f);
            Assert.Throws<EntryPointNotFoundException>(() => shader.SetParameter("t", transform));
        }

        /// <summary>
        ///     Tests the set parameter texture overload throws entry point not found
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetParameter_Texture_ThrowsEntryPointNotFound()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            using Texture texture = new Texture(Path.Combine(Path.GetDirectoryName(typeof(ShaderExecutionTests).Assembly.Location), "..", "..", "..", "Assets", "tile000.bmp"));
            Assert.Throws<EntryPointNotFoundException>(() => shader.SetParameter("tex", texture));
        }

        /// <summary>
        ///     Tests the set parameter current texture overload throws entry point not found
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void SetParameter_CurrentTexture_ThrowsEntryPointNotFound()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            Assert.Throws<EntryPointNotFoundException>(() => shader.SetParameter("tex", Shader.CurrentTexture));
        }

        /// <summary>
        ///     Tests the bind with a shader and with null
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Bind_ShaderAndNull_DoesNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            Shader.Bind(shader);
            Shader.Bind(null);
        }

        /// <summary>
        ///     Tests the to string returns the shader description
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void ToString_ReturnsDescription()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            Assert.Equal("[Shader]", shader.ToString());
        }

        /// <summary>
        ///     Tests the dispose sets the pointer to zero
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Dispose_SetsPointerToZero()
        {
            Shader shader = Shader.FromString(null, null, FragmentSource);
            Assert.NotEqual(IntPtr.Zero, shader.CPointer);
            shader.Dispose();
            Assert.Equal(IntPtr.Zero, shader.CPointer);
        }

        /// <summary>
        ///     Tests that the dispose of a zero pointer shader does not throw
        /// </summary>
        [Fact]
        public void Dispose_ZeroPointer_DoesNotThrow()
        {
            using Shader shader = new Shader(IntPtr.Zero);
            shader.Dispose();
        }
    }
}