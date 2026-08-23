// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ShaderRemainingCoverageTests.cs
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
using Alis.Core.Aspect.Math.Matrix;
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Remaining coverage tests for the <see cref="Shader"/> class
    /// </summary>
    public class ShaderRemainingCoverageTests
    {
        /// <summary>
        /// The fragment shader source
        /// </summary>
        private const string FragmentSource = "uniform float f;uniform vec2 v2;uniform vec3 v3;uniform vec4 v4;uniform int i;uniform ivec2 i2;uniform ivec3 i3;uniform ivec4 i4;uniform bool b;uniform bvec2 b2;uniform bvec3 b3;uniform bvec4 b4;uniform mat3 m3;uniform mat4 m4;void main(){ gl_FragColor = vec4(f, v2.x, v3.y, v4.w); }";

        /// <summary>
        /// Tests the from string creates a shader
        /// </summary>
        [RequireCSfmlSystemFact]
        public void FromString_CreatesShader()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            Assert.NotEqual(IntPtr.Zero, shader.CPointer);
        }

        /// <summary>
        /// Tests the from string throws on invalid source
        /// </summary>
        [RequireCSfmlSystemFact]
        public void FromString_ThrowsOnInvalidSource()
        {
            Assert.Throws<LoadingFailedException>(() => Shader.FromString(null, null, "invalid shader source"));
        }

        /// <summary>
        /// Tests the from file creates a shader
        /// </summary>
        [RequireCSfmlSystemFact]
        public void FromFile_CreatesShader()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "shader_frag.glsl");
            File.WriteAllText(path, FragmentSource);
            using Shader shader = new Shader(null, null, path);
            Assert.NotEqual(IntPtr.Zero, shader.CPointer);
        }

        /// <summary>
        /// Tests the from file throws on invalid path
        /// </summary>
        [RequireCSfmlSystemFact]
        public void FromFile_ThrowsOnInvalidPath()
        {
            Assert.Throws<LoadingFailedException>(() => new Shader(null, null, "/nonexistent/shader.glsl"));
        }

        /// <summary>
        /// Tests the from stream creates a shader
        /// </summary>
        [RequireCSfmlSystemFact]
        public void FromStream_CreatesShader()
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(FragmentSource);
            using MemoryStream stream = new MemoryStream(bytes);
            using Shader shader = new Shader(null, null, stream);
            Assert.NotEqual(IntPtr.Zero, shader.CPointer);
        }

        /// <summary>
        /// Tests the from stream throws on invalid stream
        /// </summary>
        [RequireCSfmlSystemFact]
        public void FromStream_ThrowsOnInvalidStream()
        {
            using MemoryStream stream = new MemoryStream();
            Assert.Throws<LoadingFailedException>(() => new Shader(null, null, stream));
        }

        /// <summary>
        /// Tests the native handle is readable
        /// </summary>
        [RequireCSfmlSystemFact]
        public void NativeHandle_IsReadable()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            _ = shader.NativeHandle;
        }

        /// <summary>
        /// Tests the is available property is readable
        /// </summary>
        [RequireCSfmlSystemFact]
        public void IsAvailable_IsReadable()
        {
            _ = Shader.IsAvailable;
        }

        /// <summary>
        /// Tests the is geometry available property is readable
        /// </summary>
        [RequireCSfmlSystemFact]
        public void IsGeometryAvailable_IsReadable()
        {
            _ = Shader.IsGeometryAvailable;
        }

        /// <summary>
        /// Tests the set uniform scalar overloads do not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetUniform_Scalars_DoNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            shader.SetUniform("f", 1.0f);
            shader.SetUniform("i", 1);
            shader.SetUniform("b", true);
        }

        /// <summary>
        /// Tests the set uniform vector overloads do not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetUniform_Vectors_DoNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            shader.SetUniform("v2", new Vec2(1, 2));
            shader.SetUniform("v3", new Vec3(1, 2, 3));
            shader.SetUniform("v4", new Vec4(1, 2, 3, 4));
            shader.SetUniform("i2", new Ivec2(1, 2));
            shader.SetUniform("i3", new Ivec3(1, 2, 3));
            shader.SetUniform("i4", new Ivec4(1, 2, 3, 4));
            shader.SetUniform("b2", new Bvec2(true, false));
            shader.SetUniform("b3", new Bvec3(true, false, true));
            shader.SetUniform("b4", new Bvec4(true, false, true, false));
        }

        /// <summary>
        /// Tests the set uniform matrix overloads do not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetUniform_Matrices_DoNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            shader.SetUniform("m3", new Matrix3X3(1, 0, 0, 0, 1, 0, 0, 0, 1));
            shader.SetUniform("m4", Matrix4X4.Identity);
        }

        /// <summary>
        /// Tests the set uniform texture overloads do not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetUniform_Textures_DoNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            using Texture texture = new Texture(Path.Combine(Path.GetDirectoryName(typeof(ShaderRemainingCoverageTests).Assembly.Location), "..", "..", "..", "Assets", "tile000.bmp"));
            shader.SetUniform("tex", texture);
            shader.SetUniform("tex", Shader.CurrentTexture);
        }

        /// <summary>
        /// Tests the set uniform array overloads do not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetUniformArray_DoNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            shader.SetUniformArray("f", new float[] { 1, 2 });
            shader.SetUniformArray("v2", new[] { new Vec2(1, 2) });
            shader.SetUniformArray("v3", new[] { new Vec3(1, 2, 3) });
            shader.SetUniformArray("v4", new[] { new Vec4(1, 2, 3, 4) });
            shader.SetUniformArray("m3", new[] { new Matrix3X3(1, 0, 0, 0, 1, 0, 0, 0, 1) });
            shader.SetUniformArray("m4", new[] { Matrix4X4.Identity });
        }

        /// <summary>
        /// Tests the set parameter throws entry point not found
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetParameter_ThrowsEntryPointNotFound()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            Assert.Throws<EntryPointNotFoundException>(() => shader.SetParameter("f", 1.0f));
        }

        /// <summary>
        /// Tests the bind does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Bind_DoesNotThrow()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            Shader.Bind(shader);
            Shader.Bind(null);
        }

        /// <summary>
        /// Tests the to string returns the shader description
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ToString_ReturnsDescription()
        {
            using Shader shader = Shader.FromString(null, null, FragmentSource);
            Assert.Equal("[Shader]", shader.ToString());
        }

        /// <summary>
        /// Tests the destroy sets the pointer to zero
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_SetsPointerToZero()
        {
            Shader shader = Shader.FromString(null, null, FragmentSource);
            Assert.NotEqual(IntPtr.Zero, shader.CPointer);
            shader.Dispose();
            Assert.Equal(IntPtr.Zero, shader.CPointer);
        }
    }
}
