// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IDrawableTest.cs
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
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The drawable test class
    /// </summary>
    public class IDrawableTest
    {
        /// <summary>
        /// Tests that drawable implements i drawable
        /// </summary>
        [Fact]
        public void Drawable_ImplementsIDrawable()
        {
            TestDrawable drawable = new TestDrawable();
            Assert.IsAssignableFrom<IDrawable>(drawable);
        }

        /// <summary>
        /// Tests that draw calls implementation
        /// </summary>
        [Fact]
        public void Draw_CallsImplementation()
        {
            TestDrawable drawable = new TestDrawable();
            TestRenderTarget target = new TestRenderTarget();
            drawable.Draw(target, new RenderStates());
            Assert.True(drawable.WasDrawn);
        }

        /// <summary>
        /// The test drawable class
        /// </summary>
        /// <seealso cref="IDrawable"/>
        private class TestDrawable : IDrawable
        {
            /// <summary>
            /// Gets or sets the value of the was drawn
            /// </summary>
            public bool WasDrawn { get; private set; }

            /// <summary>
            /// Draws the target
            /// </summary>
            /// <param name="target">The target</param>
            /// <param name="states">The states</param>
            public void Draw(IRenderTarget target, RenderStates states)
            {
                WasDrawn = true;
            }
        }

        /// <summary>
        /// The test render target class
        /// </summary>
        /// <seealso cref="IRenderTarget"/>
        private class TestRenderTarget : IRenderTarget
        {
            /// <summary>
            /// Maps the coords to pixel using the specified point
            /// </summary>
            /// <param name="point">The point</param>
            /// <returns>The vector</returns>
            public Vector2F MapCoordsToPixel(Vector2F point) => default;
            /// <summary>
            /// Maps the coords to pixel using the specified point
            /// </summary>
            /// <param name="point">The point</param>
            /// <param name="view">The view</param>
            /// <returns>The vector</returns>
            public Vector2F MapCoordsToPixel(Vector2F point, View view) => default;
            /// <summary>
            /// Maps the pixel to coords using the specified point
            /// </summary>
            /// <param name="point">The point</param>
            /// <returns>The vector</returns>
            public Vector2F MapPixelToCoords(Vector2F point) => default;
            /// <summary>
            /// Maps the pixel to coords using the specified point
            /// </summary>
            /// <param name="point">The point</param>
            /// <param name="view">The view</param>
            /// <returns>The vector</returns>
            public Vector2F MapPixelToCoords(Vector2F point, View view) => default;
            /// <summary>
            /// Gets the viewport using the specified view
            /// </summary>
            /// <param name="view">The view</param>
            /// <returns>The int rect</returns>
            public IntRect GetViewport(View view) => default;
            /// <summary>
            /// Gets the view
            /// </summary>
            /// <returns>The view</returns>
            public View GetView() => null;
            /// <summary>
            /// Clears this instance
            /// </summary>
            public void Clear() { }
            /// <summary>
            /// Clears the color
            /// </summary>
            /// <param name="color">The color</param>
            public void Clear(Color color) { }
            /// <summary>
            /// Draws the drawable
            /// </summary>
            /// <param name="drawable">The drawable</param>
            public void Draw(IDrawable drawable) { }
            /// <summary>
            /// Draws the drawable
            /// </summary>
            /// <param name="drawable">The drawable</param>
            /// <param name="states">The states</param>
            public void Draw(IDrawable drawable, RenderStates states) { }
            /// <summary>
            /// Draws the vertices
            /// </summary>
            /// <param name="vertices">The vertices</param>
            /// <param name="type">The type</param>
            public void Draw(Vertex[] vertices, PrimitiveType type) { }
            /// <summary>
            /// Draws the vertices
            /// </summary>
            /// <param name="vertices">The vertices</param>
            /// <param name="type">The type</param>
            /// <param name="states">The states</param>
            public void Draw(Vertex[] vertices, PrimitiveType type, RenderStates states) { }
            /// <summary>
            /// Draws the vertices
            /// </summary>
            /// <param name="vertices">The vertices</param>
            /// <param name="start">The start</param>
            /// <param name="count">The count</param>
            /// <param name="type">The type</param>
            public void Draw(Vertex[] vertices, uint start, uint count, PrimitiveType type) { }
            /// <summary>
            /// Draws the vertices
            /// </summary>
            /// <param name="vertices">The vertices</param>
            /// <param name="start">The start</param>
            /// <param name="count">The count</param>
            /// <param name="type">The type</param>
            /// <param name="states">The states</param>
            public void Draw(Vertex[] vertices, uint start, uint count, PrimitiveType type, RenderStates states) { }
            /// <summary>
            /// Pops the gl states
            /// </summary>
            public void PopGlStates() { }
            /// <summary>
            /// Pushes the gl states
            /// </summary>
            public void PushGlStates() { }
            /// <summary>
            /// Resets the gl states
            /// </summary>
            public void ResetGlStates() { }
            /// <summary>
            /// Sets the view using the specified view
            /// </summary>
            /// <param name="view">The view</param>
            public void SetView(View view) { }
            /// <summary>
            /// Gets the value of the size
            /// </summary>
            public Vector2F Size => default;
            /// <summary>
            /// Gets the value of the default view
            /// </summary>
            public View DefaultView => null;
        }
    }
}
