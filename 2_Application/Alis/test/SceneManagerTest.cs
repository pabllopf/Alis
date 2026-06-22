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

using Alis.Core.Ecs;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Manager;
using Alis.Core.Ecs.Systems.Manager.Scene;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    ///     Contains unit tests for the <see cref="SceneManager" /> class.
    /// </summary>
    public class SceneManagerTest
    {
        /// <summary>
        ///     Tests that the constructor creates a SceneManager with the provided context.
        /// </summary>
        [Fact]
        public void Constructor_CreatesSceneManager_WithContext()
        {
            Context context = new Context(new Setting());

            SceneManager sceneManager = new SceneManager(context);

            Assert.NotNull(sceneManager);
            Assert.Same(context, sceneManager.Context);
        }

        /// <summary>
        ///     Tests that SceneManager inherits from AManager.
        /// </summary>
        [Fact]
        public void SceneManager_InheritsFromAManager()
        {
            Context context = new Context(new Setting());
            SceneManager sceneManager = new SceneManager(context);

            Assert.IsAssignableFrom<AManager>(sceneManager);
        }

        /// <summary>
        ///     Tests that SceneManager has a LoadedScenes list.
        /// </summary>
        [Fact]
        public void SceneManager_HasLoadedScenesList()
        {
            Context context = new Context(new Setting());
            SceneManager sceneManager = new SceneManager(context);

            Assert.NotNull(sceneManager.LoadedScenes);
            Assert.Empty(sceneManager.LoadedScenes);
        }

        /// <summary>
        ///     Tests that SceneManager has a CurrentWorld property.
        /// </summary>
        [Fact]
        public void SceneManager_HasCurrentWorldProperty()
        {
            Context context = new Context(new Setting());
            SceneManager sceneManager = new SceneManager(context);

            Assert.Null(sceneManager.CurrentWorld);
        }

        /// <summary>
        ///     Tests that the SceneManager context is set correctly.
        /// </summary>
        [Fact]
        public void SceneManager_Context_IsSetCorrectly()
        {
            Context context = new Context(new Setting());

            SceneManager sceneManager = new SceneManager(context);

            Assert.NotNull(sceneManager.Context);
            Assert.Same(context, sceneManager.Context);
        }

        /// <summary>
        ///     Tests that SceneManager implements IManager interface.
        /// </summary>
        [Fact]
        public void SceneManager_ImplementsIManagerInterface()
        {
            Context context = new Context(new Setting());
            SceneManager sceneManager = new SceneManager(context);

            Assert.IsAssignableFrom<IManager>(sceneManager);
        }

        /// <summary>
        ///     Tests that the SceneManager default state is valid.
        /// </summary>
        [Fact]
        public void SceneManager_DefaultState_IsValid()
        {
            Context context = new Context(new Setting());
            SceneManager sceneManager = new SceneManager(context);

            Assert.NotNull(sceneManager.Id);
            Assert.NotEmpty(sceneManager.Id);
            Assert.NotNull(sceneManager.Name);
            Assert.NotNull(sceneManager.Tag);
            Assert.True(sceneManager.IsEnable);
        }

        /// <summary>
        ///     Tests that SceneManager properties are accessible.
        /// </summary>
        [Fact]
        public void SceneManager_Properties_AreAccessible()
        {
            Context context = new Context(new Setting());

            SceneManager sceneManager = new SceneManager(context);
            sceneManager.Name = "Scene";
            sceneManager.Tag = "SceneTag";
            sceneManager.IsEnable = false;

            Assert.Equal("Scene", sceneManager.Name);
            Assert.Equal("SceneTag", sceneManager.Tag);
            Assert.False(sceneManager.IsEnable);
        }

        /// <summary>
        ///     Tests that the constructor with scenes initializes the list.
        /// </summary>
        [Fact]
        public void Constructor_WithScenes_InitializesList()
        {
            Context context = new Context(new Setting());
            Scene scene1 = new Scene();
            Scene scene2 = new Scene();

            SceneManager sceneManager = new SceneManager(context, scene1, scene2);

            Assert.NotNull(sceneManager.LoadedScenes);
            Assert.Equal(2, sceneManager.LoadedScenes.Count);
            Assert.Same(scene1, sceneManager.LoadedScenes[0]);
            Assert.Same(scene2, sceneManager.LoadedScenes[1]);
            Assert.Same(scene1, sceneManager.CurrentWorld);
        }

        /// <summary>
        ///     Tests that AddScene adds a scene to the LoadedScenes list.
        /// </summary>
        [Fact]
        public void AddScene_AddsSceneToList()
        {
            Context context = new Context(new Setting());
            SceneManager sceneManager = new SceneManager(context);
            Scene newScene = new Scene();

            sceneManager.AddScene(newScene);

            Assert.Single(sceneManager.LoadedScenes);
            Assert.Same(newScene, sceneManager.LoadedScenes[0]);
        }
    }
}
