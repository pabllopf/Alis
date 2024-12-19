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

using System;
using Alis.Builder.Core.Ecs.Component.Render;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity;
using Alis.Core.Ecs.System;
using Xunit;

namespace Alis.Test.Core.Ecs.Component.Render
{
    /// <summary>
    ///     The camera test class
    /// </summary>
    public class CameraTest
    {
        /// <summary>
        ///     Tests that builder when called returns camera builder
        /// </summary>
        [Fact]
        public void Builder_WhenCalled_ReturnsCameraBuilder()
        {
            Camera camera = new Camera();
            CameraBuilder result = camera.Builder();
            Assert.IsType<CameraBuilder>(result);
        }

        /// <summary>
        ///     Tests that on start initializes correctly
        /// </summary>
        [Fact]
        public void OnStart_InitializesCorrectly()
        {
            VideoGame videoGame = new VideoGame();
            Camera camera = new Camera();
            GameObject gameObject = new GameObject();
            gameObject.SetContext(videoGame.Context);
            camera.Attach(gameObject);
            camera.OnStart();
        }

        /// <summary>
        ///     Tests that on update updates viewport position
        /// </summary>
        [Fact]
        public void OnUpdate_UpdatesViewportPosition()
        {
            VideoGame videoGame = new VideoGame();
            Camera camera = new Camera();
            GameObject gameObject = new GameObject();
            gameObject.SetContext(videoGame.Context);
            camera.Attach(gameObject);
            camera.OnStart();
            camera.OnUpdate();
            Assert.Equal(0, camera.Viewport.X);
            Assert.Equal(0, camera.Viewport.Y);
        }

        /// <summary>
        ///     Tests that on exit detaches from graphic manager
        /// </summary>
        [Fact]
        public void OnExit_DetachesFromGraphicManager()
        {
            VideoGame videoGame = new VideoGame();
            Camera camera = new Camera();
            GameObject gameObject = new GameObject();
            gameObject.SetContext(videoGame.Context);
            camera.Attach(gameObject);
            camera.OnStart();
            camera.OnExit();
        }

        /// <summary>
        ///     Tests that resolution property set get returns correct value
        /// </summary>
        [Fact]
        public void Resolution_PropertySet_GetReturnsCorrectValue()
        {
            Camera camera = new Camera();
            camera.Resolution = new Vector2F(800, 600);
            Assert.Equal(new Vector2F(800, 600), camera.Resolution);
        }

        /// <summary>
        ///     Tests that background color property set get returns correct value
        /// </summary>
        [Fact]
        public void BackgroundColor_PropertySet_GetReturnsCorrectValue()
        {
            Camera camera = new Camera();
            camera.BackgroundColor = Color.Black;
            Assert.Equal(Color.Black, camera.BackgroundColor);
        }

        /// <summary>
        ///     Tests that camera border property set get returns correct value
        /// </summary>
        [Fact]
        public void CameraBorder_PropertySet_GetReturnsCorrectValue()
        {
            Camera camera = new Camera();
            camera.CameraBorder = 1f;
            Assert.Equal(1f, camera.CameraBorder);
        }

        /// <summary>
        ///     Tests that texture target property set get returns correct value
        /// </summary>
        [Fact]
        public void TextureTarget_PropertySet_GetReturnsCorrectValue()
        {
            Camera camera = new Camera();
            IntPtr textureTarget = new IntPtr(123);
            camera.TextureTarget = textureTarget;
            Assert.Equal(textureTarget, camera.TextureTarget);
        }
    }
}