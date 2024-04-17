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

using System.Collections.Generic;
using Alis.Core.Ecs.Entity.GameObject;
using Alis.Core.Test.Ecs.Entity.GameObject;
using Xunit;

namespace Alis.Core.Test.Ecs.Entity.Scene
{
    /// <summary>
    ///     The scene test class
    /// </summary>
    public class SceneTest
    {
        /// <summary>
        ///     Tests that on fixed update calls on fixed update on each component
        /// </summary>
        [Fact]
        public void OnFixedUpdate_CallsOnFixedUpdateOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            Core.Ecs.Entity.GameObject.AGameObject gameObject1 = new Core.Ecs.Entity.GameObject.AGameObject();
            Core.Ecs.Entity.GameObject.AGameObject gameObject2 = new Core.Ecs.Entity.GameObject.AGameObject();
            scene.Add(gameObject1);
            scene.Add(gameObject2);
            
            // Act
            scene.OnFixedUpdate();
            
            // Assert
            // Here you would assert that the OnFixedUpdate method was called on each GameObject
            Assert.True(gameObject1.IsEnable);
            Assert.True(gameObject2.IsEnable);
            Assert.NotNull(gameObject1.Name);
            Assert.NotNull(gameObject2.Name);
            Assert.NotNull(gameObject1.Id);
            Assert.NotNull(gameObject2.Id);
        }
        
        /// <summary>
        ///     Tests that on dispatch events calls on dispatch events on each component
        /// </summary>
        [Fact]
        public void OnDispatchEvents_CallsOnDispatchEventsOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            GameObjectSample gameObject1 = new GameObjectSample();
            GameObjectSample gameObject2 = new GameObjectSample();
            scene.Add(gameObject1);
            scene.Add(gameObject2);
            
            // Act
            scene.OnDispatchEvents();
            
            // Assert
            // Here you would assert that the OnDispatchEvents method was called on each GameObject
            Assert.True(gameObject1.IsEnable);
            Assert.True(gameObject2.IsEnable);
            Assert.NotNull(gameObject1.Name);
            Assert.NotNull(gameObject2.Name);
            Assert.NotNull(gameObject1.Id);
            Assert.NotNull(gameObject2.Id);
        }
        
        /// <summary>
        ///     Tests that on calculate calls on calculate on each component
        /// </summary>
        [Fact]
        public void OnCalculate_CallsOnCalculateOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            GameObjectSample gameObject1 = new GameObjectSample();
            GameObjectSample gameObject2 = new GameObjectSample();
            scene.Add(gameObject1);
            scene.Add(gameObject2);
            
            // Act
            scene.OnCalculate();
            
            // Assert
            // Here you would assert that the OnCalculate method was called on each GameObject
            Assert.True(gameObject1.IsEnable);
            Assert.True(gameObject2.IsEnable);
            Assert.NotNull(gameObject1.Name);
            Assert.NotNull(gameObject2.Name);
            Assert.NotNull(gameObject1.Id);
            Assert.NotNull(gameObject2.Id);
        }
        
        /// <summary>
        ///     Tests that on draw calls on draw on each component
        /// </summary>
        [Fact]
        public void OnDraw_CallsOnDrawOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            GameObjectSample gameObject1 = new GameObjectSample();
            GameObjectSample gameObject2 = new GameObjectSample();
            scene.Add(gameObject1);
            scene.Add(gameObject2);
            
            // Act
            scene.OnDraw();
            
            // Assert
            // Here you would assert that the OnDraw method was called on each GameObject
            Assert.True(gameObject1.IsEnable);
            Assert.True(gameObject2.IsEnable);
            Assert.NotNull(gameObject1.Name);
            Assert.NotNull(gameObject2.Name);
            Assert.NotNull(gameObject1.Id);
            Assert.NotNull(gameObject2.Id);
        }
        
        /// <summary>
        ///     Tests that on gui calls on gui on each component
        /// </summary>
        [Fact]
        public void OnGui_CallsOnGuiOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            GameObjectSample gameObject1 = new GameObjectSample();
            GameObjectSample gameObject2 = new GameObjectSample();
            scene.Add(gameObject1);
            scene.Add(gameObject2);
            
            // Act
            scene.OnGui();
            
            // Assert
            // Here you would assert that the OnGui method was called on each GameObject
            Assert.True(gameObject1.IsEnable);
            Assert.True(gameObject2.IsEnable);
            Assert.NotNull(gameObject1.Name);
            Assert.NotNull(gameObject2.Name);
            Assert.NotNull(gameObject1.Id);
            Assert.NotNull(gameObject2.Id);
        }
        
        /// <summary>
        ///     Tests that on reset calls on reset on each component
        /// </summary>
        [Fact]
        public void OnReset_CallsOnResetOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            GameObjectSample gameObject1 = new GameObjectSample();
            GameObjectSample gameObject2 = new GameObjectSample();
            scene.Add(gameObject1);
            scene.Add(gameObject2);
            
            // Act
            scene.OnReset();
            
            // Assert
            // Here you would assert that the OnReset method was called on each GameObject
            Assert.True(gameObject1.IsEnable);
            Assert.True(gameObject2.IsEnable);
            Assert.NotNull(gameObject1.Name);
            Assert.NotNull(gameObject2.Name);
            Assert.NotNull(gameObject1.Id);
            Assert.NotNull(gameObject2.Id);
        }
        
        /// <summary>
        ///     Tests that on stop calls on stop on each component
        /// </summary>
        [Fact]
        public void OnStop_CallsOnStopOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            GameObjectSample gameObject1 = new GameObjectSample();
            GameObjectSample gameObject2 = new GameObjectSample();
            scene.Add(gameObject1);
            scene.Add(gameObject2);
            
            // Act
            scene.OnStop();
            
            // Assert
            // Here you would assert that the OnStop method was called on each GameObject
            Assert.True(gameObject1.IsEnable);
            Assert.True(gameObject2.IsEnable);
            Assert.NotNull(gameObject1.Name);
            Assert.NotNull(gameObject2.Name);
            Assert.NotNull(gameObject1.Id);
            Assert.NotNull(gameObject2.Id);
        }
        
        /// <summary>
        ///     Tests that on exit calls on exit on each component
        /// </summary>
        [Fact]
        public void OnExit_CallsOnExitOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            GameObjectSample gameObject1 = new GameObjectSample();
            GameObjectSample gameObject2 = new GameObjectSample();
            scene.Add(gameObject1);
            scene.Add(gameObject2);
            
            // Act
            scene.OnExit();
            
            // Assert
            // Here you would assert that the OnExit method was called on each GameObject
            Assert.True(gameObject1.IsEnable);
            Assert.True(gameObject2.IsEnable);
            Assert.NotNull(gameObject1.Name);
            Assert.NotNull(gameObject2.Name);
            Assert.NotNull(gameObject1.Id);
            Assert.NotNull(gameObject2.Id);
        }
        
        /// <summary>
        ///     Tests that on destroy calls on destroy on each component
        /// </summary>
        [Fact]
        public void OnDestroy_CallsOnDestroyOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            GameObjectSample gameObject1 = new GameObjectSample();
            GameObjectSample gameObject2 = new GameObjectSample();
            scene.Add(gameObject1);
            scene.Add(gameObject2);
            
            // Act
            scene.OnDestroy();
            
            // Assert
            // Here you would assert that the OnDestroy method was called on each GameObject
            Assert.True(gameObject1.IsEnable);
            Assert.True(gameObject2.IsEnable);
            Assert.NotNull(gameObject1.Name);
            Assert.NotNull(gameObject2.Name);
            Assert.NotNull(gameObject1.Id);
            Assert.NotNull(gameObject2.Id);
        }
        
        /// <summary>
        ///     Tests that on enable calls on enable on each component
        /// </summary>
        [Fact]
        public void OnEnable_CallsOnEnableOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            GameObjectSample gameObject1 = new GameObjectSample();
            GameObjectSample gameObject2 = new GameObjectSample();
            scene.Add(gameObject1);
            scene.Add(gameObject2);
            
            // Act
            scene.OnEnable();
            
            // Assert
            // Here you would assert that the OnEnable method was called on each GameObject
            Assert.True(gameObject1.IsEnable);
            Assert.True(gameObject2.IsEnable);
            Assert.NotNull(gameObject1.Name);
            Assert.NotNull(gameObject2.Name);
            Assert.NotNull(gameObject1.Id);
            Assert.NotNull(gameObject2.Id);
        }
        
        /// <summary>
        ///     Tests that on init calls on init on each component
        /// </summary>
        [Fact]
        public void OnInit_CallsOnInitOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            GameObjectSample gameObject1 = new GameObjectSample();
            GameObjectSample gameObject2 = new GameObjectSample();
            scene.Add(gameObject1);
            scene.Add(gameObject2);
            
            // Act
            scene.OnInit();
            
            // Assert
            // Here you would assert that the OnInit method was called on each GameObject
            Assert.True(gameObject1.IsEnable);
            Assert.True(gameObject2.IsEnable);
            Assert.NotNull(gameObject1.Name);
            Assert.NotNull(gameObject2.Name);
            Assert.NotNull(gameObject1.Id);
            Assert.NotNull(gameObject2.Id);
        }
        
        /// <summary>
        ///     Tests that on awake calls on awake on each component
        /// </summary>
        [Fact]
        public void OnAwake_CallsOnAwakeOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            GameObjectSample gameObject1 = new GameObjectSample();
            GameObjectSample gameObject2 = new GameObjectSample();
            scene.Add(gameObject1);
            scene.Add(gameObject2);
            
            // Act
            scene.OnAwake();
            
            // Assert
            // Here you would assert that the OnAwake method was called on each GameObject
            Assert.True(gameObject1.IsEnable);
            Assert.True(gameObject2.IsEnable);
            Assert.NotNull(gameObject1.Name);
            Assert.NotNull(gameObject2.Name);
            Assert.NotNull(gameObject1.Id);
            Assert.NotNull(gameObject2.Id);
        }
        
        /// <summary>
        ///     Tests that on start calls on start on each component
        /// </summary>
        [Fact]
        public void OnStart_CallsOnStartOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            GameObjectSample gameObject1 = new GameObjectSample();
            GameObjectSample gameObject2 = new GameObjectSample();
            scene.Add(gameObject1);
            scene.Add(gameObject2);
            
            // Act
            scene.OnStart();
            
            // Assert
            // Here you would assert that the OnStart method was called on each GameObject
            Assert.True(gameObject1.IsEnable);
            Assert.True(gameObject2.IsEnable);
            Assert.NotNull(gameObject1.Name);
            Assert.NotNull(gameObject2.Name);
            Assert.NotNull(gameObject1.Id);
            Assert.NotNull(gameObject2.Id);
        }
        
        /// <summary>
        ///     Tests that on before update calls on before update on each component
        /// </summary>
        [Fact]
        public void OnBeforeUpdate_CallsOnBeforeUpdateOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            GameObjectSample gameObject1 = new GameObjectSample();
            GameObjectSample gameObject2 = new GameObjectSample();
            scene.Add(gameObject1);
            scene.Add(gameObject2);
            
            // Act
            scene.OnBeforeUpdate();
            
            // Assert
            // Here you would assert that the OnBeforeUpdate method was called on each GameObject
            Assert.True(gameObject1.IsEnable);
            Assert.True(gameObject2.IsEnable);
            Assert.NotNull(gameObject1.Name);
            Assert.NotNull(gameObject2.Name);
            Assert.NotNull(gameObject1.Id);
            Assert.NotNull(gameObject2.Id);
        }
        
        /// <summary>
        ///     Tests that on update calls on update on each component
        /// </summary>
        [Fact]
        public void OnUpdate_CallsOnUpdateOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            GameObjectSample gameObject1 = new GameObjectSample();
            GameObjectSample gameObject2 = new GameObjectSample();
            scene.Add(gameObject1);
            scene.Add(gameObject2);
            
            // Act
            scene.OnUpdate();
            
            // Assert
            // Here you would assert that the OnUpdate method was called on each GameObject
            Assert.True(gameObject1.IsEnable);
            Assert.True(gameObject2.IsEnable);
            Assert.NotNull(gameObject1.Name);
            Assert.NotNull(gameObject2.Name);
            Assert.NotNull(gameObject1.Id);
            Assert.NotNull(gameObject2.Id);
        }
        
        /// <summary>
        ///     Tests that on after update calls on after update on each component
        /// </summary>
        [Fact]
        public void OnAfterUpdate_CallsOnAfterUpdateOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            GameObjectSample gameObject1 = new GameObjectSample();
            GameObjectSample gameObject2 = new GameObjectSample();
            scene.Add(gameObject1);
            scene.Add(gameObject2);
            
            // Act
            scene.OnAfterUpdate();
            
            // Assert
            // Here you would assert that the OnAfterUpdate method was called on each GameObject
            Assert.True(gameObject1.IsEnable);
            Assert.True(gameObject2.IsEnable);
            Assert.NotNull(gameObject1.Name);
            Assert.NotNull(gameObject2.Name);
            Assert.NotNull(gameObject1.Id);
            Assert.NotNull(gameObject2.Id);
        }
        
        /// <summary>
        ///     Tests that on before fixed update calls on before fixed update on each component
        /// </summary>
        [Fact]
        public void OnBeforeFixedUpdate_CallsOnBeforeFixedUpdateOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            GameObjectSample gameObject1 = new GameObjectSample();
            GameObjectSample gameObject2 = new GameObjectSample();
            scene.Add(gameObject1);
            scene.Add(gameObject2);
            
            // Act
            scene.OnBeforeFixedUpdate();
            
            // Assert
            // Here you would assert that the OnBeforeFixedUpdate method was called on each GameObject
            Assert.True(gameObject1.IsEnable);
            Assert.True(gameObject2.IsEnable);
            Assert.NotNull(gameObject1.Name);
            Assert.NotNull(gameObject2.Name);
            Assert.NotNull(gameObject1.Id);
            Assert.NotNull(gameObject2.Id);
        }
        
        /// <summary>
        ///     Tests that on after fixed update calls on after fixed update on each component
        /// </summary>
        [Fact]
        public void OnAfterFixedUpdate_CallsOnAfterFixedUpdateOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            GameObjectSample gameObject1 = new GameObjectSample();
            GameObjectSample gameObject2 = new GameObjectSample();
            scene.Add(gameObject1);
            scene.Add(gameObject2);
            
            // Act
            scene.OnAfterFixedUpdate();
            
            // Assert
            // Here you would assert that the OnAfterFixedUpdate method was called on each GameObject
            Assert.True(gameObject1.IsEnable);
            Assert.True(gameObject2.IsEnable);
            Assert.NotNull(gameObject1.Name);
            Assert.NotNull(gameObject2.Name);
            Assert.NotNull(gameObject1.Id);
            Assert.NotNull(gameObject2.Id);
        }
        
        /// <summary>
        ///     Tests that on dispatch events v 2 calls on dispatch events on each component
        /// </summary>
        [Fact]
        public void OnDispatchEvents_v2_CallsOnDispatchEventsOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            GameObjectSample gameObject1 = new GameObjectSample();
            GameObjectSample gameObject2 = new GameObjectSample();
            scene.Add(gameObject1);
            scene.Add(gameObject2);
            
            // Act
            scene.OnDispatchEvents();
            
            // Assert
            // Here you would assert that the OnDispatchEvents method was called on each GameObject
            Assert.True(gameObject1.IsEnable);
            Assert.True(gameObject2.IsEnable);
            Assert.NotNull(gameObject1.Name);
            Assert.NotNull(gameObject2.Name);
            Assert.NotNull(gameObject1.Id);
            Assert.NotNull(gameObject2.Id);
        }
        
        /// <summary>
        ///     Tests that on calculate v 2 calls on calculate on each component
        /// </summary>
        [Fact]
        public void OnCalculate_v2_CallsOnCalculateOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            GameObjectSample gameObject1 = new GameObjectSample();
            GameObjectSample gameObject2 = new GameObjectSample();
            scene.Add(gameObject1);
            scene.Add(gameObject2);
            
            // Act
            scene.OnCalculate();
            
            // Assert
            // Here you would assert that the OnCalculate method was called on each GameObject
            Assert.True(gameObject1.IsEnable);
            Assert.True(gameObject2.IsEnable);
            Assert.NotNull(gameObject1.Name);
            Assert.NotNull(gameObject2.Name);
            Assert.NotNull(gameObject1.Id);
            Assert.NotNull(gameObject2.Id);
        }
        
        /// <summary>
        ///     Tests that remove removes game object from scene
        /// </summary>
        [Fact]
        public void Remove_RemovesGameObjectFromScene()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            GameObjectSample gameObject = new GameObjectSample();
            scene.Add(gameObject);
            
            // Act
            scene.Remove(gameObject);
            
            // Assert
            // Here you would assert that the GameObject was removed from the Scene
            Assert.DoesNotContain(gameObject, scene.GameObjects);
        }
        
        /// <summary>
        ///     Tests that get returns game object from scene
        /// </summary>
        [Fact]
        public void Get_ReturnsGameObjectFromScene()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            GameObjectSample gameObject = new GameObjectSample();
            scene.Add(gameObject);
            
            // Act
            GameObjectSample result = scene.Get<GameObjectSample>();
            
            // Assert
            // Here you would assert that the Get method returned the correct GameObject
            Assert.Equal(gameObject, result);
        }
        
        /// <summary>
        ///     Tests that contains returns true when game object is in scene
        /// </summary>
        [Fact]
        public void Contains_ReturnsTrueWhenGameObjectIsInScene()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            GameObjectSample gameObject = new GameObjectSample();
            scene.Add(gameObject);
            
            // Act
            bool result = scene.Contains<GameObjectSample>();
            
            // Assert
            // Here you would assert that the Contains method returned true
            Assert.True(result);
        }
        
        /// <summary>
        ///     Tests that clear removes all game objects from scene
        /// </summary>
        [Fact]
        public void Clear_RemovesAllGameObjectsFromScene()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            GameObjectSample gameObject1 = new GameObjectSample();
            GameObjectSample gameObject2 = new GameObjectSample();
            scene.Add(gameObject1);
            scene.Add(gameObject2);
            
            // Act
            scene.Clear<GameObjectSample>();
            
            // Assert
            // Here you would assert that the Clear method removed all GameObjects from the Scene
            Assert.Empty(scene.GameObjects);
        }
        
        /// <summary>
        ///     Tests that is enable get set property works
        /// </summary>
        [Fact]
        public void IsEnable_GetSetPropertyWorks()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene
            {
                // Act
                IsEnable = false
            };
            
            // Assert
            Assert.False(scene.IsEnable);
        }
        
        /// <summary>
        ///     Tests that name get set property works
        /// </summary>
        [Fact]
        public void Name_GetSetPropertyWorks()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene
            {
                // Act
                Name = "TestScene"
            };
            
            // Assert
            Assert.Equal("TestScene", scene.Name);
        }
        
        /// <summary>
        ///     Tests that id get set property works
        /// </summary>
        [Fact]
        public void Id_GetSetPropertyWorks()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene
            {
                // Act
                Id = "123"
            };
            
            // Assert
            Assert.Equal("123", scene.Id);
        }
        
        /// <summary>
        ///     Tests that tag get set property works
        /// </summary>
        [Fact]
        public void Tag_GetSetPropertyWorks()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene
            {
                // Act
                Tag = "TestTag"
            };
            
            // Assert
            Assert.Equal("TestTag", scene.Tag);
        }
        
        /// <summary>
        ///     Tests that on disable calls on disable on each component
        /// </summary>
        [Fact]
        public void OnDisable_CallsOnDisableOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            GameObjectSample gameObject1 = new GameObjectSample();
            GameObjectSample gameObject2 = new GameObjectSample();
            scene.Add(gameObject1);
            scene.Add(gameObject2);
            
            // Act
            scene.OnDisable();
            
            // Assert
            // Here you would assert that the OnDisable method was called on each GameObject
            Assert.True(gameObject1.IsEnable);
            Assert.True(gameObject2.IsEnable);
            Assert.NotNull(gameObject1.Name);
            Assert.NotNull(gameObject2.Name);
            Assert.NotNull(gameObject1.Id);
            Assert.NotNull(gameObject2.Id);
        }
        
        /// <summary>
        ///     Tests that game objects get set property works
        /// </summary>
        [Fact]
        public void GameObjects_GetSetPropertyWorks()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            List<IGameObject> gameObjectList = new List<IGameObject>
            {
                new GameObjectSample(),
                new GameObjectSample()
            };
            
            // Act
            scene.GameObjects = gameObjectList;
            
            // Assert
            Assert.Equal(gameObjectList, scene.GameObjects);
        }
        
        /// <summary>
        ///     Tests that game objects add game object to list
        /// </summary>
        [Fact]
        public void GameObjects_AddGameObjectToList()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            GameObjectSample gameObject = new GameObjectSample();
            
            // Act
            scene.GameObjects.Add(gameObject);
            
            // Assert
            Assert.Contains(gameObject, scene.GameObjects);
        }
        
        /// <summary>
        ///     Tests that game objects remove game object from list
        /// </summary>
        [Fact]
        public void GameObjects_RemoveGameObjectFromList()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            GameObjectSample gameObject = new GameObjectSample();
            scene.GameObjects.Add(gameObject);
            
            // Act
            scene.GameObjects.Remove(gameObject);
            
            // Assert
            Assert.DoesNotContain(gameObject, scene.GameObjects);
        }
        
        /// <summary>
        ///     Tests that game objects clear list
        /// </summary>
        [Fact]
        public void GameObjects_ClearList()
        {
            // Arrange
            Core.Ecs.Entity.Scene.AScene scene = new Core.Ecs.Entity.Scene.AScene();
            scene.GameObjects.Add(new GameObjectSample());
            scene.GameObjects.Add(new GameObjectSample());
            
            // Act
            scene.GameObjects.Clear();
            
            // Assert
            Assert.Empty(scene.GameObjects);
        }
    }
}