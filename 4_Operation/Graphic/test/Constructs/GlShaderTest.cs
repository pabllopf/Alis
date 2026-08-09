// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlShaderTest.cs
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
using System.Linq;
using System.Runtime.CompilerServices;
using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    /// <summary>
    ///     Tests for the GlShader class handling individual shader compilation.
    /// </summary>
    public class GlShaderTest
    {
        /// <summary>
        ///     Tests that GlShader class is sealed and cannot be inherited.
        /// </summary>
        [Fact]
        public void GlShader_IsSealed_CannotBeInherited()
        {
            Type shaderType = typeof(GlShader);

            Assert.True(shaderType.IsSealed);
        }

        /// <summary>
        ///     Tests that GlShader class is public.
        /// </summary>
        [Fact]
        public void GlShader_IsPublic_CanBeAccessed()
        {
            Type shaderType = typeof(GlShader);

            Assert.True(shaderType.IsPublic);
        }

        /// <summary>
        ///     Tests that GlShader implements IDisposable interface.
        /// </summary>
        [Fact]
        public void GlShader_ImplementsIDisposable_InterfaceIsCorrect()
        {
            Type shaderType = typeof(GlShader);

            Assert.True(typeof(IDisposable).IsAssignableFrom(shaderType));
        }

        /// <summary>
        ///     Tests that GlShader has destructor for cleanup.
        /// </summary>
        [Fact]
        public void GlShader_HasDestructor_CleanupIsProvided()
        {
            Type shaderType = typeof(GlShader);

            Assert.True(shaderType.IsSealed);
        }

        /// <summary>
        ///     Tests that an uninitialized GlShader instance has ShaderId equal to 0.
        /// </summary>
        [Fact]
        public void GlShader_UninitializedInstance_ShaderIdIsZero()
        {
            object instance = RuntimeHelpers.GetUninitializedObject(typeof(GlShader));
            GlShader shader = (GlShader)instance;

            Assert.Equal(0u, shader.ShaderId);
        }

        /// <summary>
        ///     Tests that Dispose on an uninitialized GlShader does not throw.
        /// </summary>
        [Fact]
        public void GlShader_UninitializedInstance_DisposeDoesNotThrow()
        {
            object instance = RuntimeHelpers.GetUninitializedObject(typeof(GlShader));
            GlShader shader = (GlShader)instance;

            shader.Dispose();
        }

        /// <summary>
        ///     Tests that multiple Dispose calls on an uninitialized GlShader are safe.
        /// </summary>
        [Fact]
        public void GlShader_UninitializedInstance_MultipleDisposeIsSafe()
        {
            object instance = RuntimeHelpers.GetUninitializedObject(typeof(GlShader));
            GlShader shader = (GlShader)instance;

            shader.Dispose();
            shader.Dispose();
            shader.Dispose();
        }

        /// <summary>
        ///     Tests that ShaderLog getter on an uninitialized instance throws because OpenGL is not initialized.
        /// </summary>
        [Fact]
        public void GlShader_UninitializedInstance_ShaderLogThrows()
        {
            object instance = RuntimeHelpers.GetUninitializedObject(typeof(GlShader));
            GlShader shader = (GlShader)instance;

            Assert.Throws<InvalidOperationException>(() => shader.ShaderLog);
        }

        /// <summary>
        ///     Tests that disposing an uninitialized instance then GC-collecting triggers finalizer safely.
        /// </summary>
        [Fact]
        public void GlShader_DisposedInstance_FinalizerDoesNotThrow()
        {
            WeakReference wr;

            void CreateAndDispose()
            {
                object instance = RuntimeHelpers.GetUninitializedObject(typeof(GlShader));
                GlShader shader = (GlShader)instance;
                shader.Dispose();
                wr = new WeakReference(shader);
            }

            CreateAndDispose();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Assert.NotNull(wr);
        }
    }
}