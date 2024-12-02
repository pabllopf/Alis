// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneManagerTest.cs
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

using Alis.Core.Ecs.System;
using Alis.Core.Ecs.System.Manager.Scene;
using Xunit;

namespace Alis.Test.Core.Ecs.System.Manager.Scene
{
    /// <summary>
    ///     The scene manager test class
    /// </summary>
    public class SceneManagerTest
    {
        /// <summary>
        ///     Tests that on enable valid input
        /// </summary>
        [Fact]
        public void OnEnable_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            SceneManager sceneManager = new SceneManager(videoGame.Context);
            sceneManager.OnEnable();
        }

        /// <summary>
        ///     Tests that on init valid input
        /// </summary>
        [Fact]
        public void OnInit_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            SceneManager sceneManager = new SceneManager(videoGame.Context);
            sceneManager.OnInit();
        }

        /// <summary>
        ///     Tests that on awake valid input
        /// </summary>
        [Fact]
        public void OnAwake_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            SceneManager sceneManager = new SceneManager(videoGame.Context);
            sceneManager.OnAwake();
        }

        /// <summary>
        ///     Tests that on start valid input
        /// </summary>
        [Fact]
        public void OnStart_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            SceneManager sceneManager = new SceneManager(videoGame.Context);
            sceneManager.OnStart();
        }

        /// <summary>
        ///     Tests that on before update valid input
        /// </summary>
        [Fact]
        public void OnBeforeUpdate_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            SceneManager sceneManager = new SceneManager(videoGame.Context);
            sceneManager.OnBeforeUpdate();
        }

        /// <summary>
        ///     Tests that on update valid input
        /// </summary>
        [Fact]
        public void OnUpdate_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            SceneManager sceneManager = new SceneManager(videoGame.Context);
            sceneManager.OnUpdate();
        }

        /// <summary>
        ///     Tests that on after update valid input
        /// </summary>
        [Fact]
        public void OnAfterUpdate_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            SceneManager sceneManager = new SceneManager(videoGame.Context);
            sceneManager.OnAfterUpdate();
        }

        /// <summary>
        ///     Tests that on before fixed update valid input
        /// </summary>
        [Fact]
        public void OnBeforeFixedUpdate_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            SceneManager sceneManager = new SceneManager(videoGame.Context);
            sceneManager.OnBeforeFixedUpdate();
        }

        /// <summary>
        ///     Tests that on fixed update valid input
        /// </summary>
        [Fact]
        public void OnFixedUpdate_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            SceneManager sceneManager = new SceneManager(videoGame.Context);
            sceneManager.OnFixedUpdate();
        }

        /// <summary>
        ///     Tests that on after fixed update valid input
        /// </summary>
        [Fact]
        public void OnAfterFixedUpdate_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            SceneManager sceneManager = new SceneManager(videoGame.Context);
            sceneManager.OnAfterFixedUpdate();
        }

        /// <summary>
        ///     Tests that on dispatch events valid input
        /// </summary>
        [Fact]
        public void OnDispatchEvents_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            SceneManager sceneManager = new SceneManager(videoGame.Context);
            sceneManager.OnDispatchEvents();
        }

        /// <summary>
        ///     Tests that on calculate valid input
        /// </summary>
        [Fact]
        public void OnCalculate_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            SceneManager sceneManager = new SceneManager(videoGame.Context);
            sceneManager.OnCalculate();
        }

        /// <summary>
        ///     Tests that on draw valid input
        /// </summary>
        [Fact]
        public void OnDraw_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            SceneManager sceneManager = new SceneManager(videoGame.Context);
            sceneManager.OnDraw();
        }

        /// <summary>
        ///     Tests that on gui valid input
        /// </summary>
        [Fact]
        public void OnGui_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            SceneManager sceneManager = new SceneManager(videoGame.Context);
            sceneManager.OnGui();
        }

        /// <summary>
        ///     Tests that on disable valid input
        /// </summary>
        [Fact]
        public void OnDisable_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            SceneManager sceneManager = new SceneManager(videoGame.Context);
            sceneManager.OnDisable();
        }

        /// <summary>
        ///     Tests that on reset valid input
        /// </summary>
        [Fact]
        public void OnReset_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            SceneManager sceneManager = new SceneManager(videoGame.Context);
            sceneManager.OnReset();
        }

        /// <summary>
        ///     Tests that on stop valid input
        /// </summary>
        [Fact]
        public void OnStop_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            SceneManager sceneManager = new SceneManager(videoGame.Context);
            sceneManager.OnStop();
        }

        /// <summary>
        ///     Tests that on exit valid input
        /// </summary>
        [Fact]
        public void OnExit_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            SceneManager sceneManager = new SceneManager(videoGame.Context);
            sceneManager.OnExit();
        }

        /// <summary>
        ///     Tests that on destroy valid input
        /// </summary>
        [Fact]
        public void OnDestroy_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            SceneManager sceneManager = new SceneManager(videoGame.Context);
            sceneManager.OnDestroy();
        }

        /// <summary>
        ///     Tests that remove valid input removes scene
        /// </summary>
        [Fact]
        public void Remove_ValidInput_RemovesScene()
        {
            VideoGame videoGame = new VideoGame();
            SceneManager sceneManager = new SceneManager(videoGame.Context);
            Alis.Core.Ecs.Entity.Scene scene = new Alis.Core.Ecs.Entity.Scene();
            sceneManager.Scenes.Add(scene);
            sceneManager.Remove(scene);
            Assert.DoesNotContain(scene, sceneManager.Scenes);
        }

        /// <summary>
        ///     Tests that get valid input returns scene
        /// </summary>
        [Fact]
        public void Get_ValidInput_ReturnsScene()
        {
            VideoGame videoGame = new VideoGame();
            SceneManager sceneManager = new SceneManager(videoGame.Context);
            Alis.Core.Ecs.Entity.Scene scene = new Alis.Core.Ecs.Entity.Scene();
            sceneManager.Scenes.Add(scene);
            Alis.Core.Ecs.Entity.Scene result = sceneManager.Get<Alis.Core.Ecs.Entity.Scene>();
            Assert.Equal(scene, result);
        }

        /// <summary>
        ///     Tests that contains valid input returns true
        /// </summary>
        [Fact]
        public void Contains_ValidInput_ReturnsTrue()
        {
            VideoGame videoGame = new VideoGame();
            SceneManager sceneManager = new SceneManager(videoGame.Context);
            Alis.Core.Ecs.Entity.Scene scene = new Alis.Core.Ecs.Entity.Scene();
            sceneManager.Scenes.Add(scene);
            bool result = sceneManager.Contains<Alis.Core.Ecs.Entity.Scene>();
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that clear valid input clears scenes
        /// </summary>
        [Fact]
        public void Clear_ValidInput_ClearsScenes()
        {
            VideoGame videoGame = new VideoGame();
            SceneManager sceneManager = new SceneManager(videoGame.Context);
            Alis.Core.Ecs.Entity.Scene scene = new Alis.Core.Ecs.Entity.Scene();
            sceneManager.Scenes.Add(scene);
            sceneManager.Clear<Alis.Core.Ecs.Entity.Scene>();
            Assert.Empty(sceneManager.Scenes);
        }
        

        /// <summary>
        ///     Tests that reload scene valid scene sets current scene
        /// </summary>
        [Fact]
        public void ReloadScene_ValidScene_SetsCurrentScene()
        {
            VideoGame videoGame = new VideoGame();
            SceneManager sceneManager = new SceneManager(videoGame.Context);
            Alis.Core.Ecs.Entity.Scene scene = new Alis.Core.Ecs.Entity.Scene();
            sceneManager.ReloadScene(scene);
            Assert.Equal(scene, sceneManager.CurrentScene);
        }
    }
}