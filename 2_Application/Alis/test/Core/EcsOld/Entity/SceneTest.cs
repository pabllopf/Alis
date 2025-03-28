// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneTest.cs
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

using Alis.Core.EcsOld.Entity;
using Alis.Core.EcsOld.System;
using Alis.Core.EcsOld.System.Configuration;
using Alis.Core.EcsOld.System.Manager.Audio;
using Alis.Core.EcsOld.System.Scope;
using Alis.Test.Core.EcsOld.Entity.Sample;
using Xunit;

namespace Alis.Test.Core.EcsOld.Entity
{
    /// <summary>
    ///     The scene test class
    /// </summary>
    public class SceneTest
    {
        /// <summary>
        ///     Tests that test scene on enable
        /// </summary>
        [Fact]
        public void Test_Scene_OnEnable()
        {
            // Arrange
            Scene scene = new Scene();

            // Act
            scene.OnEnable();

            // Assert
            Assert.True(scene.IsEnable);
        }

        /// <summary>
        ///     Tests that test scene on disable
        /// </summary>
        [Fact]
        public void Test_Scene_OnDisable()
        {
            // Arrange
            Scene scene = new Scene();
            scene.OnEnable();

            // Act
            scene.OnDisable();

            // Assert
            Assert.False(scene.IsEnable);
        }

        /// <summary>
        ///     Tests that test context constructor
        /// </summary>
        [Fact]
        public void Test_Context_Constructor()
        {
            // Arrange
            VideoGame videoGame = new VideoGame();
            Setting setting = new Setting();

            // Act
            Context context = new Context(setting);

            // Assert
            Assert.NotNull(context);
            Assert.Equal(setting, context.Setting);
        }

        /// <summary>
        ///     Tests that test context audio manager
        /// </summary>
        [Fact]
        public void Test_Context_AudioManager()
        {
            // Arrange
            VideoGame videoGame = new VideoGame();
            Setting setting = new Setting();
            Context context = new Context(setting);

            // Act
            AudioManager audioManager = context.AudioManager;

            // Assert
            Assert.NotNull(audioManager);
            Assert.IsType<AudioManager>(audioManager);
        }

        /// <summary>
        ///     Tests that test scene on enable v 2
        /// </summary>
        [Fact]
        public void Test_Scene_OnEnable_v2()
        {
            // Arrange
            Scene scene = new Scene();

            // Act
            scene.OnEnable();

            // Assert
            Assert.True(scene.IsEnable);
        }

        /// <summary>
        ///     Tests that test scene on disable v 2
        /// </summary>
        [Fact]
        public void Test_Scene_OnDisable_v2()
        {
            // Arrange
            Scene scene = new Scene();
            scene.OnEnable();

            // Act
            scene.OnDisable();

            // Assert
            Assert.False(scene.IsEnable);
        }

        /// <summary>
        ///     Tests that set context should set context
        /// </summary>
        [Fact]
        public void SetContext_ShouldSetContext()
        {
            Scene scene = new Scene();
            Context context = new Context(new Setting());
            VideoGame videoGame = new VideoGame(context);
            scene.SetContext(videoGame.Context);
            Assert.Equal(context, scene.Context);
        }

        /// <summary>
        ///     Tests that set context should set context in game objects
        /// </summary>
        [Fact]
        public void SetContext_ShouldSetContextInGameObjects()
        {
            Scene scene = new Scene();
            Context context = new Context(new Setting());
            GameObject gameObject = new GameObject();
            VideoGame videoGame = new VideoGame(context);
            scene.Add(gameObject);
            scene.OnProcessPendingChanges();
            scene.SetContext(context);
            Assert.Equal(context.GetType(), gameObject.Context.GetType());
        }

        /// <summary>
        ///     Tests that context set value should change context
        /// </summary>
        [Fact]
        public void Context_SetValue_ShouldChangeContext()
        {
            Scene scene = new Scene();
            Context context = new Context(new Setting());
            VideoGame videoGame = new VideoGame(context);
            scene.SetContext(context);
            Assert.Equal(context.SceneManager.Scenes.Count, scene.Context.SceneManager.Scenes.Count);
        }

        /// <summary>
        ///     Tests that id get set should get and set id
        /// </summary>
        [Fact]
        public void Id_GetSet_ShouldGetAndSetId()
        {
            Scene scene = new Scene();
            string expectedId = "1";

            scene.Id = expectedId;

            Assert.Equal(expectedId, scene.Id);
        }

        /// <summary>
        ///     Tests that tag get set should get and set tag
        /// </summary>
        [Fact]
        public void Tag_GetSet_ShouldGetAndSetTag()
        {
            Scene scene = new Scene();
            string expectedTag = "TestTag";

            scene.Tag = expectedTag;

            Assert.Equal(expectedTag, scene.Tag);
        }

        /// <summary>
        ///     Tests that clear should clear game objects
        /// </summary>
        [Fact]
        public void Clear_ShouldClearGameObjects()
        {
            Scene scene = new Scene();
            GameObject gameObject1 = new GameObject();
            GameObject gameObject2 = new GameObject();
            scene.Add(gameObject1);
            scene.Add(gameObject2);

            scene.Clear();

            Assert.False(scene.Contains<GameObject>());
        }

        /// <summary>
        ///     Tests that on init calls on init on all game objects
        /// </summary>
        [Fact]
        public void OnInit_CallsOnInitOnAllGameObjects()
        {
            Scene scene = new Scene();
            MockGameObject mockGameObject1 = new MockGameObject();
            MockGameObject mockGameObject2 = new MockGameObject();
            scene.GameObjects.Add(mockGameObject1);
            scene.GameObjects.Add(mockGameObject2);

            scene.OnInit();
        }

        /// <summary>
        ///     Tests that on awake calls on awake on all game objects
        /// </summary>
        [Fact]
        public void OnAwake_CallsOnAwakeOnAllGameObjects()
        {
            Scene scene = new Scene();
            MockGameObject mockGameObject1 = new MockGameObject();
            MockGameObject mockGameObject2 = new MockGameObject();
            scene.GameObjects.Add(mockGameObject1);
            scene.GameObjects.Add(mockGameObject2);

            scene.OnAwake();
        }

        /// <summary>
        ///     Tests that on reset calls on reset on all game objects
        /// </summary>
        [Fact]
        public void OnReset_CallsOnResetOnAllGameObjects()
        {
            Scene scene = new Scene();
            MockGameObject mockGameObject1 = new MockGameObject();
            MockGameObject mockGameObject2 = new MockGameObject();
            scene.GameObjects.Add(mockGameObject1);
            scene.GameObjects.Add(mockGameObject2);

            scene.OnReset();
        }

        /// <summary>
        ///     Tests that on stop calls on stop on all game objects
        /// </summary>
        [Fact]
        public void OnStop_CallsOnStopOnAllGameObjects()
        {
            Scene scene = new Scene();
            MockGameObject mockGameObject1 = new MockGameObject();
            MockGameObject mockGameObject2 = new MockGameObject();
            scene.GameObjects.Add(mockGameObject1);
            scene.GameObjects.Add(mockGameObject2);

            scene.OnStop();
        }

        /// <summary>
        ///     Tests that on exit calls on exit on all game objects
        /// </summary>
        [Fact]
        public void OnExit_CallsOnExitOnAllGameObjects()
        {
            Scene scene = new Scene();
            MockGameObject mockGameObject1 = new MockGameObject();
            MockGameObject mockGameObject2 = new MockGameObject();
            scene.GameObjects.Add(mockGameObject1);
            scene.GameObjects.Add(mockGameObject2);

            scene.OnExit();
        }

        /// <summary>
        ///     Tests that on destroy calls on destroy on all game objects
        /// </summary>
        [Fact]
        public void OnDestroy_CallsOnDestroyOnAllGameObjects()
        {
            Scene scene = new Scene();
            MockGameObject mockGameObject1 = new MockGameObject();
            MockGameObject mockGameObject2 = new MockGameObject();
            scene.GameObjects.Add(mockGameObject1);
            scene.GameObjects.Add(mockGameObject2);

            scene.OnDestroy();
        }
    }
}