

using System;
using System.Collections.Generic;
using Alis.Core.Ecs.Systems.Manager.Scene;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    ///     Extended tests for ScenesMap collection operations and persistence behavior
    /// </summary>
    public class ScenesMapExtendedTest
    {
        /// <summary>
        ///     Tests that default constructor creates empty Scenes list
        /// </summary>
        [Fact]
        public void ScenesMap_DefaultConstructor_ShouldCreateEmptyScenesList()
        {
            ScenesMap map = new ScenesMap();

            Assert.NotNull(map.Scenes);
            Assert.Empty(map.Scenes);
        }

        /// <summary>
        ///     Tests that AddScene adds to list
        /// </summary>
        [Fact]
        public void ScenesMap_AddScene_ShouldAddToList()
        {
            ScenesMap map = new ScenesMap();

            map.AddScene(1);

            Assert.Single(map.Scenes);
            Assert.Equal(1, map.Scenes[0]);
        }

        /// <summary>
        ///     Tests that AddScene multiple adds all
        /// </summary>
        [Fact]
        public void ScenesMap_AddSceneMultiple_ShouldAddAllScenes()
        {
            ScenesMap map = new ScenesMap();

            map.AddScene(1);
            map.AddScene(2);
            map.AddScene(3);

            Assert.Equal(3, map.Scenes.Count);
            Assert.Equal(new List<int> {1, 2, 3}, map.Scenes);
        }

        /// <summary>
        ///     Tests that RemoveScene removes existing
        /// </summary>
        [Fact]
        public void ScenesMap_RemoveScene_ExistingScene_ShouldRemove()
        {
            ScenesMap map = new ScenesMap();
            map.AddScene(1);
            map.AddScene(2);
            map.AddScene(3);

            map.RemoveScene(2);

            Assert.Equal(2, map.Scenes.Count);
            Assert.DoesNotContain(2, map.Scenes);
        }

        /// <summary>
        ///     Tests that RemoveScene non-existing doesn't throw
        /// </summary>
        [Fact]
        public void ScenesMap_RemoveScene_NonExisting_ShouldNotThrow()
        {
            ScenesMap map = new ScenesMap();
            map.AddScene(1);

            Exception exception = Record.Exception(() => map.RemoveScene(99));

            Assert.Null(exception);
            Assert.Single(map.Scenes);
        }

        /// <summary>
        ///     Tests that Clear removes all
        /// </summary>
        [Fact]
        public void ScenesMap_Clear_ShouldRemoveAllScenes()
        {
            ScenesMap map = new ScenesMap();
            map.AddScene(1);
            map.AddScene(2);
            map.AddScene(3);

            map.Clear();

            Assert.Empty(map.Scenes);
        }

        /// <summary>
        ///     Tests that Load returns new instance
        /// </summary>
        [Fact]
        public void ScenesMap_Load_ShouldReturnNewInstance()
        {
            ScenesMap map = new ScenesMap();

            ScenesMap loaded = ScenesMap.Load();

            Assert.NotNull(loaded);
            Assert.NotSame(map, loaded);
        }

        /// <summary>
        ///     Tests that Load returns empty scenes
        /// </summary>
        [Fact]
        public void ScenesMap_Load_ShouldReturnEmptyScenes()
        {
            ScenesMap loaded = ScenesMap.Load();

            Assert.Empty(loaded.Scenes);
        }

        /// <summary>
        ///     Tests that Save doesn't throw
        /// </summary>
        [Fact]
        public void ScenesMap_Save_ShouldNotThrow()
        {
            ScenesMap map = new ScenesMap();
            map.AddScene(1);

            Exception exception = Record.Exception(() => map.Save());

            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that Scenes list is mutable
        /// </summary>
        [Fact]
        public void ScenesMap_ScenesList_ShouldBeMutable()
        {
            ScenesMap map = new ScenesMap();

            List<int> newScenes = new List<int> {10, 20, 30};
            map.Scenes = newScenes;

            Assert.Same(newScenes, map.Scenes);
            Assert.Equal(3, map.Scenes.Count);
        }
    }
}
