// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DrawableDrawCoverageTests.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Coverage tests for the <see cref="IDrawable.Draw"/> implementations. A stub render target that is neither
    ///     a window nor a render texture exercises the state marshaling performed before the native dispatch.
    /// </summary>
    public class DrawableDrawCoverageTests
    {
        /// <summary>
        ///     Stub render target that is neither a window nor a texture.
        /// </summary>
        private sealed class StubRenderTarget : IRenderTarget
        {
            /// <inheritdoc />
            public Vector2F Size => default;

            /// <inheritdoc />
            public View DefaultView => null;

            /// <inheritdoc />
            public View GetView() => null;

            /// <inheritdoc />
            public void SetView(View view)
            {
            }

            /// <inheritdoc />
            public IntRect GetViewport(View view) => default;

            /// <inheritdoc />
            public Vector2F MapPixelToCoords(Vector2F point) => default;

            /// <inheritdoc />
            public Vector2F MapPixelToCoords(Vector2F point, View view) => default;

            /// <inheritdoc />
            public Vector2F MapCoordsToPixel(Vector2F point) => default;

            /// <inheritdoc />
            public Vector2F MapCoordsToPixel(Vector2F point, View view) => default;

            /// <inheritdoc />
            public void Clear()
            {
            }

            /// <inheritdoc />
            public void Clear(Color color)
            {
            }

            /// <inheritdoc />
            public void Draw(IDrawable drawable)
            {
            }

            /// <inheritdoc />
            public void Draw(IDrawable drawable, RenderStates states)
            {
            }

            /// <inheritdoc />
            public void Draw(Vertex[] vertices, PrimitiveType type)
            {
            }

            /// <inheritdoc />
            public void Draw(Vertex[] vertices, PrimitiveType type, RenderStates states)
            {
            }

            /// <inheritdoc />
            public void Draw(Vertex[] vertices, uint start, uint count, PrimitiveType type)
            {
            }

            /// <inheritdoc />
            public void Draw(Vertex[] vertices, uint start, uint count, PrimitiveType type, RenderStates states)
            {
            }

            /// <inheritdoc />
            public void PushGlStates()
            {
            }

            /// <inheritdoc />
            public void PopGlStates()
            {
            }

            /// <inheritdoc />
            public void ResetGlStates()
            {
            }
        }

        /// <summary>
        /// Tests that drawing a shape to a stub target performs state marshaling without throwing
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Shape_Draw_StubTarget_DoesNotThrow()
        {
            using CircleShape shape = new CircleShape(10.0f);
            StubRenderTarget target = new StubRenderTarget();
            Exception result = Record.Exception(() => shape.Draw(target, new RenderStates()));
            Assert.Null(result);
        }
    }
}