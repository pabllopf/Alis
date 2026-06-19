// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CameraBuilderTest.cs
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
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    /// The camera builder test class
    /// </summary>
    public class CameraBuilderTest
    {
        /// <summary>
        /// Tests that constructor with context creates builder
        /// </summary>
        [Fact]
        public void Constructor_WithContext_CreatesBuilder()
        {
            Context context = new Context();
            CameraBuilder builder = new CameraBuilder(context);
            Assert.NotNull(builder);
        }

        /// <summary>
        /// Tests that build returns camera instance
        /// </summary>
        [Fact]
        public void Build_ReturnsCameraInstance()
        {
            Context context = new Context();
            CameraBuilder builder = new CameraBuilder(context);
            Camera camera = builder.Build();
            Assert.NotNull(camera);
        }

        /// <summary>
        /// Tests that resolution sets resolution returns builder
        /// </summary>
        [Fact]
        public void Resolution_SetsResolution_ReturnsBuilder()
        {
            Context context = new Context();
            CameraBuilder builder = new CameraBuilder(context);
            CameraBuilder result = builder.Resolution(800, 600);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that position sets position returns builder
        /// </summary>
        [Fact]
        public void Position_SetsPosition_ReturnsBuilder()
        {
            Context context = new Context();
            CameraBuilder builder = new CameraBuilder(context);
            CameraBuilder result = builder.Position(10.5f, 20.3f);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that background color sets color returns builder
        /// </summary>
        [Fact]
        public void BackgroundColor_SetsColor_ReturnsBuilder()
        {
            Context context = new Context();
            CameraBuilder builder = new CameraBuilder(context);
            CameraBuilder result = builder.BackgroundColor(Color.Blue);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that chaining all properties creates camera
        /// </summary>
        [Fact]
        public void ChainingAllProperties_CreatesCamera()
        {
            Context context = new Context();
            CameraBuilder builder = new CameraBuilder(context);
            Camera camera = builder
                .Resolution(1920, 1080)
                .Position(0f, 0f)
                .BackgroundColor(Color.Black)
                .Build();
            Assert.NotNull(camera);
        }
    }
}
