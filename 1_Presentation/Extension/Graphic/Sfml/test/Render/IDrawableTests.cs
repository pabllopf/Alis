// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IDrawableTests.cs
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

using Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     The drawable tests class
    /// </summary>
    public class IDrawableTests
    {
        /// <summary>
        ///     Tests that draw can be called
        /// </summary>
        [Fact]
        public void Draw_CanBeCalled()
        {
            DummyDrawable drawable = new DummyDrawable();
            drawable.Draw(null, default(RenderStates));
            Assert.True(drawable.WasDrawn);
        }

        /// <summary>
        ///     The dummy drawable class
        /// </summary>
        /// <seealso cref="IDrawable" />
        private class DummyDrawable : IDrawable
        {
            /// <summary>
            ///     Gets or sets the value of the was drawn
            /// </summary>
            public bool WasDrawn { get; private set; }

            /// <summary>
            ///     Draws the target
            /// </summary>
            /// <param name="target">The target</param>
            /// <param name="states">The states</param>
            public void Draw(IRenderTarget target, RenderStates states)
            {
                WasDrawn = true;
            }
        }
    }
}