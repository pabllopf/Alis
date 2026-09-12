// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:VertexArrayDrawExecutionTests.cs
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
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Test;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Verifies the <see cref="VertexArray.Draw(IRenderTarget, RenderStates)" /> native
    ///     dispatch against a real render window. Tests are harmless no-ops when the SFML
    /// </summary>
    public class VertexArrayDrawExecutionTests
    {
        /// <summary>
        ///     Tests that drawing to a real render window executes the native draw call.
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
                using VertexArray vertexArray = new VertexArray(PrimitiveType.Triangles);
                vertexArray.Append(new Vertex(new Vector2F(1f, 1f)));
                vertexArray.Append(new Vertex(new Vector2F(10f, 1f)));
                vertexArray.Append(new Vertex(new Vector2F(5f, 10f)));

                vertexArray.Draw(renderWindow, new RenderStates());
                Assert.Equal(3u, vertexArray.VertexCount);
            }
            finally
            {
                SfmlTestBootstrap.DestroyExtraNativeWindow(nativeWindow);
            }
        }
    }
}
