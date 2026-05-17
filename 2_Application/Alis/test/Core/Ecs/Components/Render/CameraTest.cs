// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CameraTest.cs
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

using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Render
{
    /// <summary>
    ///     Tests for the Camera component struct
    /// </summary>
    public class CameraTest
    {
        /// <summary>
        ///     Tests that the constructor creates a Camera with default values
        /// </summary>
        [Fact]
        public void Camera_Constructor_ShouldCreateWithDefaultValues()
        {
            Context context = new Context();
            Vector2F position = new Vector2F(0f, 0f);
            Vector2F resolution = new Vector2F(800f, 600f);

            Camera camera = new Camera(context, position, resolution);

            Assert.Equal(position, camera.Position);
            Assert.Equal(resolution, camera.Resolution);
        }

        /// <summary>
        ///     Tests that the Position property is gettable and settable
        /// </summary>
        [Fact]
        public void Camera_PositionProperty_ShouldBeGetAndSettable()
        {
            Context context = new Context();
            Vector2F position = new Vector2F(0f, 0f);
            Vector2F resolution = new Vector2F(800f, 600f);

            Camera camera = new Camera(context, position, resolution);
            Vector2F newPosition = new Vector2F(10f, 20f);

            camera.Position = newPosition;
            Assert.Equal(newPosition, camera.Position);
        }

        /// <summary>
        ///     Tests that the Resolution property is gettable and settable
        /// </summary>
        [Fact]
        public void Camera_ResolutionProperty_ShouldBeGetAndSettable()
        {
            Context context = new Context();
            Vector2F position = new Vector2F(0f, 0f);
            Vector2F resolution = new Vector2F(800f, 600f);

            Camera camera = new Camera(context, position, resolution);
            Vector2F newResolution = new Vector2F(1920f, 1080f);

            camera.Resolution = newResolution;
            Assert.Equal(newResolution, camera.Resolution);
        }
        
        /// <summary>
        ///     Tests that Camera implements ICamera interface
        /// </summary>
        [Fact]
        public void Camera_ShouldImplementICameraInterface()
        {
            Context context = new Context();
            Vector2F position = new Vector2F(0f, 0f);
            Vector2F resolution = new Vector2F(800f, 600f);

            Camera camera = new Camera(context, position, resolution);

            Assert.IsAssignableFrom<ICamera>(camera);
        }

        /// <summary>
        ///     Tests that Position can be modified after construction
        /// </summary>
        [Fact]
        public void Camera_Position_ShouldBeModifiableAfterConstruction()
        {
            Context context = new Context();
            Vector2F position = new Vector2F(0f, 0f);
            Vector2F resolution = new Vector2F(800f, 600f);

            Camera camera = new Camera(context, position, resolution);
            Assert.Equal(0f, camera.Position.X);

            camera.Position = new Vector2F(100f, 200f);
            Assert.Equal(100f, camera.Position.X);
            Assert.Equal(200f, camera.Position.Y);
        }

        /// <summary>
        ///     Tests that Resolution can be set to various values
        /// </summary>
        [Theory]
        [InlineData(640f, 480f)]
        [InlineData(1920f, 1080f)]
        [InlineData(3840f, 2160f)]
        [InlineData(1f, 1f)]
        public void Camera_Resolution_ShouldAcceptVariousValues(float width, float height)
        {
            Context context = new Context();
            Vector2F position = new Vector2F(0f, 0f);
            Vector2F resolution = new Vector2F(800f, 600f);

            Camera camera = new Camera(context, position, resolution);
            Vector2F newResolution = new Vector2F(width, height);

            camera.Resolution = newResolution;
            Assert.Equal(width, camera.Resolution.X);
            Assert.Equal(height, camera.Resolution.Y);
        }

        /// <summary>
        ///     Tests that Camera is not null after construction
        /// </summary>
        [Fact]
        public void Camera_ShouldNotBeNullAfterConstruction()
        {
            Context context = new Context();
            Vector2F position = new Vector2F(0f, 0f);
            Vector2F resolution = new Vector2F(800f, 600f);

            Camera camera = new Camera(context, position, resolution);

            Assert.NotNull(camera);
        }

        /// <summary>
        ///     Tests that Camera properties are independent of each other
        /// </summary>
        [Fact]
        public void Camera_Properties_ShouldBeIndependent()
        {
            Context context = new Context();
            Vector2F position = new Vector2F(0f, 0f);
            Vector2F resolution = new Vector2F(800f, 600f);

            Camera camera = new Camera(context, position, resolution);

            camera.Position = new Vector2F(10f, 20f);
            Assert.Equal(800f, camera.Resolution.X);
            Assert.Equal(600f, camera.Resolution.Y);

            camera.Resolution = new Vector2F(1920f, 1080f);
            Assert.Equal(10f, camera.Position.X);
            Assert.Equal(20f, camera.Position.Y);
        }
    }
}
