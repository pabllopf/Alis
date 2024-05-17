// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AComponent.cs
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

using Alis.Core.Ecs.Component;
using Alis.Test.Core.Ecs.Component.Sample;
using Xunit;

namespace Alis.Test.Core.Ecs.Component
{
    /// <summary>
    /// The component test class
    /// </summary>
    public class AComponentTest
    {
        /// <summary>
        /// Tests that on enable valid input
        /// </summary>
        [Fact]
        public void OnEnable_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnEnable();
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that on init valid input
        /// </summary>
        [Fact]
        public void OnInit_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnInit();
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that on awake valid input
        /// </summary>
        [Fact]
        public void OnAwake_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnAwake();
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that on start valid input
        /// </summary>
        [Fact]
        public void OnStart_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnStart();
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that on before update valid input
        /// </summary>
        [Fact]
        public void OnBeforeUpdate_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnBeforeUpdate();
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that on update valid input
        /// </summary>
        [Fact]
        public void OnUpdate_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnUpdate();
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that on after update valid input
        /// </summary>
        [Fact]
        public void OnAfterUpdate_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnAfterUpdate();
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that on before fixed update valid input
        /// </summary>
        [Fact]
        public void OnBeforeFixedUpdate_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnBeforeFixedUpdate();
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that on fixed update valid input
        /// </summary>
        [Fact]
        public void OnFixedUpdate_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnFixedUpdate();
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that on after fixed update valid input
        /// </summary>
        [Fact]
        public void OnAfterFixedUpdate_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnAfterFixedUpdate();
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that on dispatch events valid input
        /// </summary>
        [Fact]
        public void OnDispatchEvents_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnDispatchEvents();
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that on calculate valid input
        /// </summary>
        [Fact]
        public void OnCalculate_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnCalculate();
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that on draw valid input
        /// </summary>
        [Fact]
        public void OnDraw_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnDraw();
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that on gui valid input
        /// </summary>
        [Fact]
        public void OnGui_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnGui();
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that on disable valid input
        /// </summary>
        [Fact]
        public void OnDisable_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnDisable();
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that on reset valid input
        /// </summary>
        [Fact]
        public void OnReset_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnReset();
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that on stop valid input
        /// </summary>
        [Fact]
        public void OnStop_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnStop();
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that on exit valid input
        /// </summary>
        [Fact]
        public void OnExit_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnExit();
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that on destroy valid input
        /// </summary>
        [Fact]
        public void OnDestroy_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnDestroy();
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
    }
}