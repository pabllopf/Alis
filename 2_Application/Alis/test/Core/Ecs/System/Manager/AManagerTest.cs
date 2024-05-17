// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AManagerTest.cs
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

using Xunit;

namespace Alis.Test.Core.Ecs.System.Manager
{
    /// <summary>
    /// The manager test class
    /// </summary>
    public class AManagerTest
    {
        /// <summary>
        /// Tests that test on enable
        /// </summary>
        [Fact]
        public void Test_OnEnable()
        {
            MockManager manager = new MockManager();
            manager.OnEnable();
            // Asserts would go here
        }
        
        /// <summary>
        /// Tests that test on init
        /// </summary>
        [Fact]
        public void Test_OnInit()
        {
            MockManager manager = new MockManager();
            manager.OnInit();
            // Asserts would go here
        }
        
        /// <summary>
        /// Tests that test on awake
        /// </summary>
        [Fact]
        public void Test_OnAwake()
        {
            MockManager manager = new MockManager();
            manager.OnAwake();
            // Asserts would go here
        }
        
        /// <summary>
        /// Tests that test on start
        /// </summary>
        [Fact]
        public void Test_OnStart()
        {
            MockManager manager = new MockManager();
            manager.OnStart();
            // Asserts would go here
        }
        
        /// <summary>
        /// Tests that test on before update
        /// </summary>
        [Fact]
        public void Test_OnBeforeUpdate()
        {
            MockManager manager = new MockManager();
            manager.OnBeforeUpdate();
            // Asserts would go here
        }
        
        /// <summary>
        /// Tests that test on update
        /// </summary>
        [Fact]
        public void Test_OnUpdate()
        {
            MockManager manager = new MockManager();
            manager.OnUpdate();
            // Asserts would go here
        }
        
        /// <summary>
        /// Tests that test on after update
        /// </summary>
        [Fact]
        public void Test_OnAfterUpdate()
        {
            MockManager manager = new MockManager();
            manager.OnAfterUpdate();
            // Asserts would go here
        }
        
        /// <summary>
        /// Tests that test on before fixed update
        /// </summary>
        [Fact]
        public void Test_OnBeforeFixedUpdate()
        {
            MockManager manager = new MockManager();
            manager.OnBeforeFixedUpdate();
            // Asserts would go here
        }
        
        /// <summary>
        /// Tests that test on fixed update
        /// </summary>
        [Fact]
        public void Test_OnFixedUpdate()
        {
            MockManager manager = new MockManager();
            manager.OnFixedUpdate();
            // Asserts would go here
        }
        
        /// <summary>
        /// Tests that test on after fixed update
        /// </summary>
        [Fact]
        public void Test_OnAfterFixedUpdate()
        {
            MockManager manager = new MockManager();
            manager.OnAfterFixedUpdate();
            // Asserts would go here
        }
        
        /// <summary>
        /// Tests that test on dispatch events
        /// </summary>
        [Fact]
        public void Test_OnDispatchEvents()
        {
            MockManager manager = new MockManager();
            manager.OnDispatchEvents();
            // Asserts would go here
        }
        
        /// <summary>
        /// Tests that test on calculate
        /// </summary>
        [Fact]
        public void Test_OnCalculate()
        {
            MockManager manager = new MockManager();
            manager.OnCalculate();
            // Asserts would go here
        }
        
        /// <summary>
        /// Tests that test on draw
        /// </summary>
        [Fact]
        public void Test_OnDraw()
        {
            MockManager manager = new MockManager();
            manager.OnDraw();
            // Asserts would go here
        }
        
        /// <summary>
        /// Tests that test on gui
        /// </summary>
        [Fact]
        public void Test_OnGui()
        {
            MockManager manager = new MockManager();
            manager.OnGui();
            // Asserts would go here
        }
        
        /// <summary>
        /// Tests that test on disable
        /// </summary>
        [Fact]
        public void Test_OnDisable()
        {
            MockManager manager = new MockManager();
            manager.OnDisable();
            // Asserts would go here
        }
        
        /// <summary>
        /// Tests that test on reset
        /// </summary>
        [Fact]
        public void Test_OnReset()
        {
            MockManager manager = new MockManager();
            manager.OnReset();
            // Asserts would go here
        }
        
        /// <summary>
        /// Tests that test on stop
        /// </summary>
        [Fact]
        public void Test_OnStop()
        {
            MockManager manager = new MockManager();
            manager.OnStop();
            // Asserts would go here
        }
        
        /// <summary>
        /// Tests that test on exit
        /// </summary>
        [Fact]
        public void Test_OnExit()
        {
            MockManager manager = new MockManager();
            manager.OnExit();
            // Asserts would go here
        }
        
        /// <summary>
        /// Tests that test on destroy
        /// </summary>
        [Fact]
        public void Test_OnDestroy()
        {
            MockManager manager = new MockManager();
            manager.OnDestroy();
            // Asserts would go here
        }
    }
}