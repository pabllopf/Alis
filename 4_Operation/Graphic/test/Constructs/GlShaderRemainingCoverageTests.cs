// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlShaderRemainingCoverageTests.cs
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
using System.Reflection;
using System.Runtime.CompilerServices;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Constructs;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    /// <summary>
    ///     The gl shader remaining coverage tests class
    /// </summary>
    public class GlShaderRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that release unmanaged resources with shader id throws when gl not initialized
        /// </summary>
        [Fact]
        public void ReleaseUnmanagedResources_WithShaderId_ThrowsWhenGlNotInitialized()
        {
            Gl.Initialize(null);
            GlShader shader = CreateFakeShader(1u);

            Assert.Throws<InvalidOperationException>(() => shader.ReleaseUnmanagedResources());
        }

        /// <summary>
        ///     Tests that finalizer with shader id does not throw when gl not initialized
        /// </summary>
        [Fact]
        public void Finalizer_WithShaderId_DoesNotThrowWhenGlNotInitialized()
        {
            Gl.Initialize(null);

            CreateFinalizableShader();

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        /// <summary>
        ///     Creates the fake shader using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The gl shader</returns>
        private static GlShader CreateFakeShader(uint id)
        {
            GlShader shader = (GlShader)RuntimeHelpers.GetUninitializedObject(typeof(GlShader));
            typeof(GlShader).GetProperty("ShaderId").GetSetMethod(true).Invoke(shader, new object[] { id });
            return shader;
        }

        /// <summary>
        ///     Creates the finalizable shader
        /// </summary>
        private static void CreateFinalizableShader()
        {
            GlShader shader = CreateFakeShader(1u);
        }
    }
}
