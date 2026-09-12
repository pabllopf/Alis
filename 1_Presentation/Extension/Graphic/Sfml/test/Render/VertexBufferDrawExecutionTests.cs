// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:VertexBufferDrawExecutionTests.cs
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

using Alis.Core.Aspect.Math.Vector;
using System;
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Test;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Verifies the <see cref="VertexBuffer.Draw(IRenderTarget, RenderStates)" /> native
    ///     dispatch against a real render window.
    /// </summary>
    public class VertexBufferDrawExecutionTests
    {
        /// <summary>
        ///     Tests that drawing a vertex buffer to a real render window executes the native draw call.
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Draw_ToRenderWindow_ExecutesNativeDraw()
        {
            IntPtr nativeWindow = SfmlTestBootstrap.CreateExtraNativeWindow();
            try
            {
                IntPtr handle = SfmlTestBootstrap.GetExtraNativeHandle(nativeWindow);
                Assert.NotEqual(IntPtr.Zero, handle);

                using RenderWindow renderWindow = new RenderWindow(handle, new ContextSettings(0, 0));
                using VertexBuffer vertexBuffer = new VertexBuffer(1u, PrimitiveType.Triangles, VertexBuffer.UsageSpecifier.Stream);
                bool updated = vertexBuffer.Update(new Vertex[] { new Vertex(new Vector2F(1f, 1f)) }, 0u);
                Assert.True(updated);
                Assert.Equal(1u, vertexBuffer.VertexCount);

                vertexBuffer.Draw(renderWindow, new RenderStates());
            }
            finally
            {
                NativeWindowFactory.DestroyExtraNativeWindow(nativeWindow);
            }
        }
    }
}
