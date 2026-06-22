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

using System;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems.Manager.Scene;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems.Manager.Scene
{
    /// <summary>
    ///     The scene manager test class
    /// </summary>
    public class SceneManagerTest : IDisposable
    {
        private SceneManager _sceneManager;

        public SceneManagerTest()
        {
            Context context = new Context();
            _sceneManager = new SceneManager(context);
        }

        public void Dispose()
        {
            _sceneManager = null;
        }

        /// <summary>
        ///     Tests that constructor initializes the scene manager
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeSceneManager()
        {
            Assert.NotNull(_sceneManager);
        }

        /// <summary>
        ///     Tests that LoadedScenes is not null after construction
        /// </summary>
        [Fact]
        public void LoadedScenes_ShouldNotBeNull()
        {
            Assert.NotNull(_sceneManager.LoadedScenes);
        }

        /// <summary>
        ///     Tests that LoadedScenes is empty after construction
        /// </summary>
        [Fact]
        public void LoadedScenes_Default_ShouldBeEmpty()
        {
            Assert.Empty(_sceneManager.LoadedScenes);
        }

        /// <summary>
        ///     Tests that CurrentWorld is null after construction
        /// </summary>
        [Fact]
        public void CurrentWorld_Default_ShouldBeNull()
        {
            Assert.Null(_sceneManager.CurrentWorld);
        }

        /// <summary>
        ///     Tests that AddScene adds a scene to the loaded scenes list
        /// </summary>
        [Fact]
        public void AddScene_ShouldAddSceneToList()
        {
            Ecs.Scene scene = new Ecs.Scene();

            _sceneManager.AddScene(scene);

            Assert.Single(_sceneManager.LoadedScenes);
        }

        /// <summary>
        ///     Tests that AddScene adds multiple scenes
        /// </summary>
        [Fact]
        public void AddScene_MultipleScenes_ShouldAddAll()
        {
            Ecs.Scene scene1 = new Ecs.Scene();
            Ecs.Scene scene2 = new Ecs.Scene();
            Ecs.Scene scene3 = new Ecs.Scene();

            _sceneManager.AddScene(scene1);
            _sceneManager.AddScene(scene2);
            _sceneManager.AddScene(scene3);

            Assert.Equal(3, _sceneManager.LoadedScenes.Count);
        }

        /// <summary>
        ///     Tests that constructor with scenes initializes them
        /// </summary>
        [Fact]
        public void Constructor_WithScenes_ShouldInitializeThem()
        {
            Ecs.Scene scene1 = new Ecs.Scene();
            Ecs.Scene scene2 = new Ecs.Scene();

            Context context = new Context();
            SceneManager manager = new SceneManager(context, scene1, scene2);

            Assert.Equal(2, manager.LoadedScenes.Count);
        }


        /// <summary>
        ///     Tests that CurrentWorld can be set
        /// </summary>
        [Fact]
        public void CurrentWorld_ShouldBeSettable()
        {
            Ecs.Scene scene = new Ecs.Scene();

            _sceneManager.CurrentWorld = scene;

            Assert.Equal(scene, _sceneManager.CurrentWorld);
        }

        /// <summary>
        ///     Tests that LoadedScenes can be set via internal setter
        /// </summary>
        [Fact]
        public void LoadedScenes_CanBeSet()
        {
            Ecs.Scene scene = new Ecs.Scene();

            _sceneManager.LoadedScenes = new System.Collections.Generic.List<Ecs.Scene> { scene };

            Assert.Single(_sceneManager.LoadedScenes);
        }

        /// <summary>
        ///     Tests that OnSave does not throw (intentionally empty)
        /// </summary>
        [Fact]
        public void OnSave_ShouldNotThrow()
        {
            Assert.NotNull(_sceneManager);

            _sceneManager.OnSave();

            // Should not throw - intentionally empty
        }

        /// <summary>
        ///     Tests that OnUpdate does not throw when CurrentWorld is null
        /// </summary>
        [Fact]
        public void OnUpdate_WhenNoCurrentWorld_ShouldNotThrow()
        {
            Assert.NotNull(_sceneManager);

            // Should not throw even with no current world
            _sceneManager.OnUpdate();
        }

        /// <summary>
        ///     Tests that LoadScene with string does not throw when scene not found
        /// </summary>
        [Fact]
        public void LoadSceneWithString_WhenNotFound_ShouldNotThrow()
        {
            Assert.NotNull(_sceneManager);

            _sceneManager.LoadScene("non-existent");

            // Should not throw - just won't find the scene
        }
    }
}
