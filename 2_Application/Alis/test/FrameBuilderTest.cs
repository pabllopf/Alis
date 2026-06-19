// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FrameBuilderTest.cs
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

using Alis.Builder.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Components.Render;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    /// The frame builder test class
    /// </summary>
    public class FrameBuilderTest
    {
        /// <summary>
        /// Tests that constructor creates builder
        /// </summary>
        [Fact]
        public void Constructor_CreatesBuilder()
        {
            FrameBuilder builder = new FrameBuilder();
            Assert.NotNull(builder);
        }

        /// <summary>
        /// Tests that file sets file name returns builder
        /// </summary>
        [Fact]
        public void File_SetsFileName_ReturnsBuilder()
        {
            FrameBuilder builder = new FrameBuilder();
            FrameBuilder result = builder.File("frames/test.png");
            Assert.Same(builder, result);
        }
    }
}
