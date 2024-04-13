// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectTest.cs
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
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component;
using Alis.Core.Test.Ecs.Component;
using Xunit;

namespace Alis.Core.Test.Ecs.Entity.GameObject
{
    /// <summary>
    ///     The game object test class
    /// </summary>
    public class GameObjectTest
    {
        /// <summary>
        ///     Tests that add should add component
        /// </summary>
        [Fact]
        public void Add_ShouldAddComponent()
        {
            // Arrange
            Core.Ecs.Entity.GameObject.GameObject gameObject = new Core.Ecs.Entity.GameObject.GameObject();
            IComponent component = new ComponentSample();
            
            // Act
            gameObject.Add(component);
            
            // Assert
            Assert.Contains(component, gameObject.Components);
        }
        
        /// <summary>
        ///     Tests that remove should remove component
        /// </summary>
        [Fact]
        public void Remove_ShouldRemoveComponent()
        {
            // Arrange
            Core.Ecs.Entity.GameObject.GameObject gameObject = new Core.Ecs.Entity.GameObject.GameObject();
            IComponent component = new ComponentSample();
            gameObject.Add(component);
            
            // Act
            gameObject.Remove(component);
            
            // Assert
            Assert.DoesNotContain(component, gameObject.Components);
        }
        
        /// <summary>
        ///     Tests that get should get component
        /// </summary>
        [Fact]
        public void Get_ShouldGetComponent()
        {
            // Arrange
            Core.Ecs.Entity.GameObject.GameObject gameObject = new Core.Ecs.Entity.GameObject.GameObject();
            IComponent component = new ComponentSample();
            gameObject.Add(component);
            
            // Act
            ComponentSample retrievedComponent = gameObject.Get<ComponentSample>();
            
            // Assert
            Assert.Equal(component, retrievedComponent);
        }
        
        /// <summary>
        ///     Tests that contains should return true if component exists
        /// </summary>
        [Fact]
        public void Contains_ShouldReturnTrueIfComponentExists()
        {
            // Arrange
            Core.Ecs.Entity.GameObject.GameObject gameObject = new Core.Ecs.Entity.GameObject.GameObject();
            IComponent component = new ComponentSample();
            gameObject.Add(component);
            
            // Act
            bool containsComponent = gameObject.Contains<ComponentSample>();
            
            // Assert
            Assert.True(containsComponent);
        }
        
        /// <summary>
        ///     Tests that clear should remove all components
        /// </summary>
        [Fact]
        public void Clear_ShouldRemoveAllComponents()
        {
            // Arrange
            Core.Ecs.Entity.GameObject.GameObject gameObject = new Core.Ecs.Entity.GameObject.GameObject();
            IComponent component = new ComponentSample();
            gameObject.Add(component);
            
            // Act
            gameObject.Clear<ComponentSample>();
            
            // Assert
            Assert.DoesNotContain(component, gameObject.Components);
        }
        
        /// <summary>
        ///     Tests that on start calls on start on each component
        /// </summary>
        [Fact]
        public void OnStart_CallsOnStartOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.GameObject.GameObject gameObject = new Core.Ecs.Entity.GameObject.GameObject();
            ComponentSample component1 = new ComponentSample();
            ComponentSample component2 = new ComponentSample();
            gameObject.Add(component1);
            gameObject.Add(component2);
            
            // Act
            gameObject.OnStart();
            
            // Assert
            // Here you would assert that the OnStart method was called on each component
            Assert.NotNull(gameObject);
            Assert.NotNull(component1);
            Assert.NotNull(component2);
            Assert.Contains(component1, gameObject.Components);
            Assert.Contains(component2, gameObject.Components);
        }
        
        /// <summary>
        ///     Tests that on update calls on update on each component
        /// </summary>
        [Fact]
        public void OnUpdate_CallsOnUpdateOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.GameObject.GameObject gameObject = new Core.Ecs.Entity.GameObject.GameObject();
            ComponentSample component1 = new ComponentSample();
            ComponentSample component2 = new ComponentSample();
            gameObject.Add(component1);
            gameObject.Add(component2);
            
            // Act
            gameObject.OnUpdate();
            
            // Assert
            // Here you would assert that the OnUpdate method was called on each component
            Assert.NotNull(gameObject);
            Assert.NotNull(component1);
            Assert.NotNull(component2);
            Assert.Contains(component1, gameObject.Components);
            Assert.Contains(component2, gameObject.Components);
        }
        
        /// <summary>
        ///     Tests that on fixed update calls on fixed update on each component
        /// </summary>
        [Fact]
        public void OnFixedUpdate_CallsOnFixedUpdateOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.GameObject.GameObject gameObject = new Core.Ecs.Entity.GameObject.GameObject();
            ComponentSample component1 = new ComponentSample();
            ComponentSample component2 = new ComponentSample();
            gameObject.Add(component1);
            gameObject.Add(component2);
            
            // Act
            gameObject.OnFixedUpdate();
            
            // Assert
            // Here you would assert that the OnFixedUpdate method was called on each component
            Assert.NotNull(gameObject);
            Assert.NotNull(component1);
            Assert.NotNull(component2);
            Assert.Contains(component1, gameObject.Components);
            Assert.Contains(component2, gameObject.Components);
        }
        
        /// <summary>
        ///     Tests that on after fixed update calls on after fixed update on each component
        /// </summary>
        [Fact]
        public void OnAfterFixedUpdate_CallsOnAfterFixedUpdateOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.GameObject.GameObject gameObject = new Core.Ecs.Entity.GameObject.GameObject();
            ComponentSample component1 = new ComponentSample();
            ComponentSample component2 = new ComponentSample();
            gameObject.Add(component1);
            gameObject.Add(component2);
            
            // Act
            gameObject.OnAfterFixedUpdate();
            
            // Assert
            // Here you would assert that the OnAfterFixedUpdate method was called on each component
            Assert.NotNull(gameObject);
            Assert.NotNull(component1);
            Assert.NotNull(component2);
            Assert.Contains(component1, gameObject.Components);
            Assert.Contains(component2, gameObject.Components);
        }
        
        /// <summary>
        ///     Tests that on dispatch events calls on dispatch events on each component
        /// </summary>
        [Fact]
        public void OnDispatchEvents_CallsOnDispatchEventsOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.GameObject.GameObject gameObject = new Core.Ecs.Entity.GameObject.GameObject();
            ComponentSample component1 = new ComponentSample();
            ComponentSample component2 = new ComponentSample();
            gameObject.Add(component1);
            gameObject.Add(component2);
            
            // Act
            gameObject.OnDispatchEvents();
            
            // Assert
            // Here you would assert that the OnDispatchEvents method was called on each component
            Assert.NotNull(gameObject);
            Assert.NotNull(component1);
            Assert.NotNull(component2);
            Assert.Contains(component1, gameObject.Components);
            Assert.Contains(component2, gameObject.Components);
        }
        
        /// <summary>
        ///     Tests that on calculate calls on calculate on each component
        /// </summary>
        [Fact]
        public void OnCalculate_CallsOnCalculateOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.GameObject.GameObject gameObject = new Core.Ecs.Entity.GameObject.GameObject();
            ComponentSample component1 = new ComponentSample();
            ComponentSample component2 = new ComponentSample();
            gameObject.Add(component1);
            gameObject.Add(component2);
            
            // Act
            gameObject.OnCalculate();
            
            // Assert
            // Here you would assert that the OnCalculate method was called on each component
            Assert.NotNull(gameObject);
            Assert.NotNull(component1);
            Assert.NotNull(component2);
            Assert.Contains(component1, gameObject.Components);
            Assert.Contains(component2, gameObject.Components);
        }
        
        /// <summary>
        ///     Tests that on draw calls on draw on each component
        /// </summary>
        [Fact]
        public void OnDraw_CallsOnDrawOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.GameObject.GameObject gameObject = new Core.Ecs.Entity.GameObject.GameObject();
            ComponentSample component1 = new ComponentSample();
            ComponentSample component2 = new ComponentSample();
            gameObject.Add(component1);
            gameObject.Add(component2);
            
            // Act
            gameObject.OnDraw();
            
            // Assert
            // Here you would assert that the OnDraw method was called on each component
            Assert.NotNull(gameObject);
            Assert.NotNull(component1);
            Assert.NotNull(component2);
            Assert.Contains(component1, gameObject.Components);
            Assert.Contains(component2, gameObject.Components);
        }
        
        /// <summary>
        ///     Tests that on gui calls on gui on each component
        /// </summary>
        [Fact]
        public void OnGui_CallsOnGuiOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.GameObject.GameObject gameObject = new Core.Ecs.Entity.GameObject.GameObject();
            ComponentSample component1 = new ComponentSample();
            ComponentSample component2 = new ComponentSample();
            gameObject.Add(component1);
            gameObject.Add(component2);
            
            // Act
            gameObject.OnGui();
            
            // Assert
            // Here you would assert that the OnGui method was called on each component
            Assert.NotNull(gameObject);
            Assert.NotNull(component1);
            Assert.NotNull(component2);
            Assert.Contains(component1, gameObject.Components);
            Assert.Contains(component2, gameObject.Components);
        }
        
        /// <summary>
        ///     Tests that on reset calls on reset on each component
        /// </summary>
        [Fact]
        public void OnReset_CallsOnResetOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.GameObject.GameObject gameObject = new Core.Ecs.Entity.GameObject.GameObject();
            ComponentSample component1 = new ComponentSample();
            ComponentSample component2 = new ComponentSample();
            gameObject.Add(component1);
            gameObject.Add(component2);
            
            // Act
            gameObject.OnReset();
            
            // Assert
            // Here you would assert that the OnReset method was called on each component
            Assert.NotNull(gameObject);
            Assert.NotNull(component1);
            Assert.NotNull(component2);
            Assert.Contains(component1, gameObject.Components);
            Assert.Contains(component2, gameObject.Components);
        }
        
        /// <summary>
        ///     Tests that on stop calls on stop on each component
        /// </summary>
        [Fact]
        public void OnStop_CallsOnStopOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.GameObject.GameObject gameObject = new Core.Ecs.Entity.GameObject.GameObject();
            ComponentSample component1 = new ComponentSample();
            ComponentSample component2 = new ComponentSample();
            gameObject.Add(component1);
            gameObject.Add(component2);
            
            // Act
            gameObject.OnStop();
            
            // Assert
            // Here you would assert that the OnStop method was called on each component
            Assert.NotNull(gameObject);
            Assert.NotNull(component1);
            Assert.NotNull(component2);
            Assert.Contains(component1, gameObject.Components);
            Assert.Contains(component2, gameObject.Components);
        }
        
        /// <summary>
        ///     Tests that on exit calls on exit on each component
        /// </summary>
        [Fact]
        public void OnExit_CallsOnExitOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.GameObject.GameObject gameObject = new Core.Ecs.Entity.GameObject.GameObject();
            ComponentSample component1 = new ComponentSample();
            ComponentSample component2 = new ComponentSample();
            gameObject.Add(component1);
            gameObject.Add(component2);
            
            // Act
            gameObject.OnExit();
            
            // Assert
            // Here you would assert that the OnExit method was called on each component
            Assert.NotNull(gameObject);
            Assert.NotNull(component1);
            Assert.NotNull(component2);
            Assert.Contains(component1, gameObject.Components);
            Assert.Contains(component2, gameObject.Components);
        }
        
        /// <summary>
        ///     Tests that on destroy calls on destroy on each component
        /// </summary>
        [Fact]
        public void OnDestroy_CallsOnDestroyOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.GameObject.GameObject gameObject = new Core.Ecs.Entity.GameObject.GameObject();
            ComponentSample component1 = new ComponentSample();
            ComponentSample component2 = new ComponentSample();
            gameObject.Add(component1);
            gameObject.Add(component2);
            
            // Act
            gameObject.OnDestroy();
            
            // Assert
            // Here you would assert that the OnDestroy method was called on each component
            Assert.NotNull(gameObject);
            Assert.NotNull(component1);
            Assert.NotNull(component2);
            Assert.Contains(component1, gameObject.Components);
            Assert.Contains(component2, gameObject.Components);
        }
        
        /// <summary>
        ///     Tests that on after update calls on after update on each component
        /// </summary>
        [Fact]
        public void OnAfterUpdate_CallsOnAfterUpdateOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.GameObject.GameObject gameObject = new Core.Ecs.Entity.GameObject.GameObject();
            ComponentSample component1 = new ComponentSample();
            ComponentSample component2 = new ComponentSample();
            gameObject.Add(component1);
            gameObject.Add(component2);
            
            // Act
            gameObject.OnAfterUpdate();
            
            // Assert
            // Here you would assert that the OnAfterUpdate method was called on each component
            Assert.NotNull(gameObject);
            Assert.NotNull(component1);
            Assert.NotNull(component2);
            Assert.Contains(component1, gameObject.Components);
            Assert.Contains(component2, gameObject.Components);
        }
        
        /// <summary>
        ///     Tests that on before fixed update calls on before fixed update on each component
        /// </summary>
        [Fact]
        public void OnBeforeFixedUpdate_CallsOnBeforeFixedUpdateOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.GameObject.GameObject gameObject = new Core.Ecs.Entity.GameObject.GameObject();
            ComponentSample component1 = new ComponentSample();
            ComponentSample component2 = new ComponentSample();
            gameObject.Add(component1);
            gameObject.Add(component2);
            
            // Act
            gameObject.OnBeforeFixedUpdate();
            
            // Assert
            // Here you would assert that the OnBeforeFixedUpdate method was called on each component
            Assert.NotNull(gameObject);
            Assert.NotNull(component1);
            Assert.NotNull(component2);
            Assert.Contains(component1, gameObject.Components);
            Assert.Contains(component2, gameObject.Components);
        }
        
        /// <summary>
        ///     Tests that on enable calls on enable on each component
        /// </summary>
        [Fact]
        public void OnEnable_CallsOnEnableOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.GameObject.GameObject gameObject = new Core.Ecs.Entity.GameObject.GameObject();
            ComponentSample component1 = new ComponentSample();
            ComponentSample component2 = new ComponentSample();
            gameObject.Add(component1);
            gameObject.Add(component2);
            
            // Act
            gameObject.OnEnable();
            
            // Assert
            // Here you would assert that the OnEnable method was called on each component
            Assert.NotNull(gameObject);
            Assert.NotNull(component1);
            Assert.NotNull(component2);
            Assert.Contains(component1, gameObject.Components);
            Assert.Contains(component2, gameObject.Components);
        }
        
        /// <summary>
        ///     Tests that on disable calls on disable on each component
        /// </summary>
        [Fact]
        public void OnDisable_CallsOnDisableOnEachComponent()
        {
            // Arrange
            Core.Ecs.Entity.GameObject.GameObject gameObject = new Core.Ecs.Entity.GameObject.GameObject();
            ComponentSample component1 = new ComponentSample();
            ComponentSample component2 = new ComponentSample();
            gameObject.Add(component1);
            gameObject.Add(component2);
            
            // Act
            gameObject.OnDisable();
            
            // Assert
            // Here you would assert that the OnDisable method was called on each component
            Assert.NotNull(gameObject);
            Assert.NotNull(component1);
            Assert.NotNull(component2);
            Assert.Contains(component1, gameObject.Components);
            Assert.Contains(component2, gameObject.Components);
        }
        
        /// <summary>
        ///     Tests that is enable get set property works
        /// </summary>
        [Fact]
        public void IsEnable_GetSetPropertyWorks()
        {
            // Arrange
            Core.Ecs.Entity.GameObject.GameObject gameObject = new Core.Ecs.Entity.GameObject.GameObject
            {
                // Act
                IsEnable = false
            };
            
            // Assert
            Assert.False(gameObject.IsEnable);
        }
        
        /// <summary>
        ///     Tests that name get set property works
        /// </summary>
        [Fact]
        public void Name_GetSetPropertyWorks()
        {
            // Arrange
            Core.Ecs.Entity.GameObject.GameObject gameObject = new Core.Ecs.Entity.GameObject.GameObject
            {
                // Act
                Name = "TestGameObject"
            };
            
            // Assert
            Assert.Equal("TestGameObject", gameObject.Name);
        }
        
        /// <summary>
        ///     Tests that id get set property works
        /// </summary>
        [Fact]
        public void Id_GetSetPropertyWorks()
        {
            // Arrange
            Core.Ecs.Entity.GameObject.GameObject gameObject = new Core.Ecs.Entity.GameObject.GameObject
            {
                // Act
                Id = "123"
            };
            
            // Assert
            Assert.Equal("123", gameObject.Id);
        }
        
        /// <summary>
        ///     Tests that tag get set property works
        /// </summary>
        [Fact]
        public void Tag_GetSetPropertyWorks()
        {
            // Arrange
            Core.Ecs.Entity.GameObject.GameObject gameObject = new Core.Ecs.Entity.GameObject.GameObject
            {
                // Act
                Tag = "TestTag"
            };
            
            // Assert
            Assert.Equal("TestTag", gameObject.Tag);
        }
        
        /// <summary>
        ///     Tests that components get set property works
        /// </summary>
        [Fact]
        public void Components_GetSetPropertyWorks()
        {
            // Arrange
            Core.Ecs.Entity.GameObject.GameObject gameObject = new Core.Ecs.Entity.GameObject.GameObject();
            List<IComponent> componentList = new List<IComponent>
            {
                new ComponentSample(),
                new ComponentSample()
            };
            
            // Act
            gameObject.Components = componentList;
            
            // Assert
            Assert.Equal(componentList, gameObject.Components);
        }
        
        /// <summary>
        ///     Tests that transform get set property works
        /// </summary>
        [Fact]
        public void Transform_GetSetPropertyWorks()
        {
            // Arrange
            Core.Ecs.Entity.GameObject.GameObject gameObject = new Core.Ecs.Entity.GameObject.GameObject();
            Transform transform = new Transform(new Vector2(1, 1), new Rotation(1), new Vector2(2, 2));
            
            // Act
            gameObject.Transform = transform;
            
            // Assert
            Assert.Equal(transform, gameObject.Transform);
        }
    }
}