// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SfmlFinalizerCoverageTests.cs
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
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test
{
    /// <summary>
    ///     Coverage tests exercising the finalizer and internal constructor paths
    /// </summary>
    public class SfmlFinalizerCoverageTests
    {
        /// <summary>
        /// Tests the texture finalizer runs the non disposing destroy path
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Texture_Finalizer_RunsNonDisposingDestroy()
        {
            string path = Path.Combine(Path.GetDirectoryName(typeof(SfmlFinalizerCoverageTests).Assembly.Location), "..", "..", "..", "Assets", "tile000.bmp");
            CreateTexture(path);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        /// <summary>
        /// Creates the texture and drops it for the finalizer
        /// </summary>
        /// <param name="path">The path</param>
        private static void CreateTexture(string path)
        {
            Texture texture = new Texture(path);
            Assert.NotEqual(IntPtr.Zero, texture.CPointer);
        }

        /// <summary>
        /// Tests the shader finalizer runs the non disposing destroy path
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Shader_Finalizer_RunsNonDisposingDestroy()
        {
            const string frag = "void main(){ gl_FragColor = vec4(1.0, 0.0, 0.0, 1.0); }";
            CreateShader(frag);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        /// <summary>
        /// Creates the shader and drops it for the finalizer
        /// </summary>
        /// <param name="frag">The fragment source</param>
        private static void CreateShader(string frag)
        {
            Shader shader = Shader.FromString(null, null, frag);
            Assert.NotEqual(IntPtr.Zero, shader.CPointer);
        }

        /// <summary>
        /// Tests the current texture type constructor is accessible
        /// </summary>
        [RequireCSfmlSystemFact]
        public void CurrentTextureType_Constructor_IsAccessible()
        {
            Shader.CurrentTextureType current = new Shader.CurrentTextureType();
            Assert.NotNull(current);
        }

        /// <summary>
        /// Tests the internal texture constructor marks the texture as external
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Texture_InternalConstructor_IsExternal()
        {
            Texture texture = new Texture(new IntPtr(1));
            Assert.True(texture.myExternal);
            texture.Dispose();
            Assert.Equal(IntPtr.Zero, texture.CPointer);
        }
    }
}
