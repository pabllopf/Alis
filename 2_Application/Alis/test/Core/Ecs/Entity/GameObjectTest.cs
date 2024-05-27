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
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity;
using Alis.Core.Ecs.System;
using Alis.Core.Ecs.System.Manager.Audio;
using Alis.Core.Ecs.System.Manager.Graphic;
using Alis.Core.Ecs.System.Manager.Input;
using Alis.Core.Ecs.System.Manager.Network;
using Alis.Core.Ecs.System.Manager.Physic;
using Alis.Core.Ecs.System.Manager.Scene;
using Alis.Core.Ecs.System.Setting;
using Alis.Test.Builder.Core.Ecs.Entity.GameObject.Sample;
using Xunit;

namespace Alis.Test.Core.Ecs.Entity
{
    /// <summary>
    /// The game object test class
    /// </summary>
    public class GameObjectTest
    {
        /// <summary>
        /// Tests that test game object on enable
        /// </summary>
        [Fact]
        public void Test_GameObject_OnEnable()
        {
            // Arrange
            GameObject gameObject = new GameObject();
            
            // Act
            gameObject.OnEnable();
            
            // Assert
            Assert.True(gameObject.IsEnable);
        }
        
        /// <summary>
        /// Tests that test game object on disable
        /// </summary>
        [Fact]
        public void Test_GameObject_OnDisable()
        {
            // Arrange
            GameObject gameObject = new GameObject();
            gameObject.OnEnable();
            
            // Act
            gameObject.OnDisable();
            
            // Assert
            Assert.False(gameObject.IsEnable);
        }
        
        /// <summary>
        /// Tests that test game object add remove component
        /// </summary>
        [Fact]
        public void Test_GameObject_Add_Remove_Component()
        {
            // Arrange
            GameObject gameObject = new GameObject();
            Sprite component = new Sprite();
            
            // Act
            gameObject.Add(component);
            bool containsAfterAdd = gameObject.Contains<AComponent>();
            gameObject.Remove(component);
            bool containsAfterRemove = gameObject.Contains<AComponent>();
            
            // Assert
            Assert.True(containsAfterAdd);
            Assert.False(containsAfterRemove);
        }
        
        /// <summary>
        /// Tests that test game object set context
        /// </summary>
        [Fact]
        public void Test_GameObject_SetContext()
        {
            // Arrange
            GameObject gameObject = new GameObject();
            
            // Assert
            Assert.NotNull(gameObject.Context);
            Assert.IsType<Context>(gameObject.Context);
        }
        
        /// <summary>
        /// Tests that on init should call on init of components
        /// </summary>
        [Fact]
        public void OnInit_ShouldCallOnInitOfComponents()
        {
            GameObject gameObject = new GameObject();
            Sample2Component sample2Component = new Sample2Component();
            gameObject.Add(sample2Component);
            
            gameObject.OnInit();
        }
        
        /// <summary>
        /// Tests that on awake should call on awake of components
        /// </summary>
        [Fact]
        public void OnAwake_ShouldCallOnAwakeOfComponents()
        {
            GameObject gameObject = new GameObject();
            Sample2Component sample2Component = new Sample2Component();
            gameObject.Add(sample2Component);
            
            gameObject.OnAwake();
        }
        
        /// <summary>
        /// Tests that on start should call on start of components
        /// </summary>
        [Fact]
        public void OnStart_ShouldCallOnStartOfComponents()
        {
            GameObject gameObject = new GameObject();
            Sample2Component sample2Component = new Sample2Component();
            gameObject.Add(sample2Component);
            
            gameObject.OnStart();
        }
        
        /// <summary>
        /// Tests that on update should call on update of components
        /// </summary>
        [Fact]
        public void OnUpdate_ShouldCallOnUpdateOfComponents()
        {
            GameObject gameObject = new GameObject();
            Sample2Component sample2Component = new Sample2Component();
            gameObject.Add(sample2Component);
            
            gameObject.OnUpdate();
        }
        
        /// <summary>
        /// Tests that on disable should call on disable of components
        /// </summary>
        [Fact]
        public void OnDisable_ShouldCallOnDisableOfComponents()
        {
            GameObject gameObject = new GameObject();
            Sample2Component sample2Component = new Sample2Component();
            gameObject.Add(sample2Component);
            
            gameObject.OnDisable();
        }
        
        /// <summary>
        /// Tests that on reset should call on reset of components
        /// </summary>
        [Fact]
        public void OnReset_ShouldCallOnResetOfComponents()
        {
            GameObject gameObject = new GameObject();
            Sample2Component sample2Component = new Sample2Component();
            gameObject.Add(sample2Component);
            
            gameObject.OnReset();
        }
        
        /// <summary>
        /// Tests that on stop should call on stop of components
        /// </summary>
        [Fact]
        public void OnStop_ShouldCallOnStopOfComponents()
        {
            GameObject gameObject = new GameObject();
            Sample2Component sample2Component = new Sample2Component();
            gameObject.Add(sample2Component);
            
            gameObject.OnStop();
        }
        
        /// <summary>
        /// Tests that on exit should call on exit of components
        /// </summary>
        [Fact]
        public void OnExit_ShouldCallOnExitOfComponents()
        {
            GameObject gameObject = new GameObject();
            Sample2Component sample2Component = new Sample2Component();
            gameObject.Add(sample2Component);
            
            gameObject.OnExit();
        }
        
        /// <summary>
        /// Tests that on destroy should call on destroy of components
        /// </summary>
        [Fact]
        public void OnDestroy_ShouldCallOnDestroyOfComponents()
        {
            GameObject gameObject = new GameObject();
            Sample2Component sample2Component = new Sample2Component();
            gameObject.Add(sample2Component);
            
            gameObject.OnDestroy();
        }
        
        /// <summary>
        /// Tests that set context should set context
        /// </summary>
        [Fact]
        public void SetContext_ShouldSetContext()
        {
            GameObject gameObject = new GameObject();
            Context context = new Context(
                new Settings(),
                new AudioManager(),
                new GraphicManager(),
                new InputManager(),
                new NetworkManager(),
                new PhysicManager(),
                new SceneManager()
            );
            
            Assert.Equal(context, gameObject.Context);
        }
        
        /// <summary>
        /// Tests that on after update should call on after update of components
        /// </summary>
        [Fact]
        public void OnAfterUpdate_ShouldCallOnAfterUpdateOfComponents()
        {
            GameObject gameObject = new GameObject();
            Sample2Component sample2Component = new Sample2Component();
            gameObject.Add(sample2Component);
            
            gameObject.OnAfterUpdate();
        }
        
        /// <summary>
        /// Tests that on before fixed update should call on before fixed update of components
        /// </summary>
        [Fact]
        public void OnBeforeFixedUpdate_ShouldCallOnBeforeFixedUpdateOfComponents()
        {
            GameObject gameObject = new GameObject();
            Sample2Component sample2Component = new Sample2Component();
            gameObject.Add(sample2Component);
            
            gameObject.OnBeforeFixedUpdate();
        }
        
        /// <summary>
        /// Tests that on fixed update should call on fixed update of components
        /// </summary>
        [Fact]
        public void OnFixedUpdate_ShouldCallOnFixedUpdateOfComponents()
        {
            GameObject gameObject = new GameObject();
            Sample2Component sample2Component = new Sample2Component();
            gameObject.Add(sample2Component);
            
            gameObject.OnFixedUpdate();
        }
        
        /// <summary>
        /// Tests that on after fixed update should call on after fixed update of components
        /// </summary>
        [Fact]
        public void OnAfterFixedUpdate_ShouldCallOnAfterFixedUpdateOfComponents()
        {
            GameObject gameObject = new GameObject();
            Sample2Component sample2Component = new Sample2Component();
            gameObject.Add(sample2Component);
            
            gameObject.OnAfterFixedUpdate();
        }
        
        /// <summary>
        /// Tests that on dispatch events should call on dispatch events of components
        /// </summary>
        [Fact]
        public void OnDispatchEvents_ShouldCallOnDispatchEventsOfComponents()
        {
            GameObject gameObject = new GameObject();
            Sample2Component sample2Component = new Sample2Component();
            gameObject.Add(sample2Component);
            
            gameObject.OnDispatchEvents();
        }
        
        /// <summary>
        /// Tests that on calculate should call on calculate of components
        /// </summary>
        [Fact]
        public void OnCalculate_ShouldCallOnCalculateOfComponents()
        {
            GameObject gameObject = new GameObject();
            Sample2Component sample2Component = new Sample2Component();
            gameObject.Add(sample2Component);
            
            gameObject.OnCalculate();
        }
        
        /// <summary>
        /// Tests that on draw should call on draw of components
        /// </summary>
        [Fact]
        public void OnDraw_ShouldCallOnDrawOfComponents()
        {
            GameObject gameObject = new GameObject();
            Sample2Component sample2Component = new Sample2Component();
            gameObject.Add(sample2Component);
            
            gameObject.OnDraw();
        }
        
        /// <summary>
        /// Tests that on gui should call on gui of components
        /// </summary>
        [Fact]
        public void OnGui_ShouldCallOnGuiOfComponents()
        {
            GameObject gameObject = new GameObject();
            Sample2Component sample2Component = new Sample2Component();
            gameObject.Add(sample2Component);
            
            gameObject.OnGui();
        }
        
        /// <summary>
        /// Tests that clear should clear components
        /// </summary>
        [Fact]
        public void Clear_ShouldClearComponents()
        {
            GameObject gameObject = new GameObject();
            Sample2Component sample2Component1 = new Sample2Component();
            Sample2Component sample2Component2 = new Sample2Component();
            gameObject.Add(sample2Component1);
            gameObject.Add(sample2Component2);
            
            gameObject.Clear<Sample2Component>();
            
            Assert.False(gameObject.Contains<Sample2Component>());
        }
        
        /// <summary>
        /// Tests that get should return correct component
        /// </summary>
        [Fact]
        public void Get_ShouldReturnCorrectComponent()
        {
            GameObject gameObject = new GameObject();
            Sample2Component sample2Component = new Sample2Component();
            gameObject.Add(sample2Component);
            
            Sample2Component result = gameObject.Get<Sample2Component>();
            
            Assert.NotNull(result);
            Assert.IsType<Sample2Component>(result);
            Assert.Equal(sample2Component, result);
        }
        
        /// <summary>
        /// Tests that on before update should call on before update of components
        /// </summary>
        [Fact]
        public void OnBeforeUpdate_ShouldCallOnBeforeUpdateOfComponents()
        {
            GameObject gameObject = new GameObject();
            Sample2Component sample2Component = new Sample2Component();
            gameObject.Add(sample2Component);
            
            gameObject.OnBeforeUpdate();
        }
        
        /// <summary>
        /// Tests that id set value should change value
        /// </summary>
        [Fact]
        public void Id_SetValue_ShouldChangeValue()
        {
            GameObject gameObject = new GameObject();
            Assert.Equal("0", gameObject.Id);
            
            gameObject.Id = "1";
            Assert.Equal("1", gameObject.Id);
        }
        
        /// <summary>
        /// Tests that components set value should change value
        /// </summary>
        [Fact]
        public void Components_SetValue_ShouldChangeValue()
        {
            GameObject gameObject = new GameObject();
            Assert.Empty(gameObject.Components);
            
            List<AComponent> componentList = new List<AComponent> {new Sample2Component()};
            gameObject.Components = componentList;
            Assert.Equal(componentList, gameObject.Components);
        }
    }
}