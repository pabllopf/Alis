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

using System.Diagnostics.CodeAnalysis;
using Alis.Core.Ecs.System;
using Alis.Test.Core.Ecs.System.Manager.Samples;
using Xunit;

namespace Alis.Test.Core.Ecs.System.Manager
{
    /// <summary>
    ///     The manager test class
    /// </summary>
    	 [ExcludeFromCodeCoverage] 
	 public class AManagerTest 
    {
        /// <summary>
        ///     Tests that test on enable
        /// </summary>
        [Fact]
        public void Test_OnEnable()
        {
            VideoGame videoGame = new VideoGame();
            MockManager manager = new MockManager(videoGame.Context);
            manager.OnEnable();
        }

        /// <summary>
        ///     Tests that test on init
        /// </summary>
        [Fact]
        public void Test_OnInit()
        {
            VideoGame videoGame = new VideoGame();
            MockManager manager = new MockManager(videoGame.Context);
            manager.OnInit();
        }

        /// <summary>
        ///     Tests that test on awake
        /// </summary>
        [Fact]
        public void Test_OnAwake()
        {
            VideoGame videoGame = new VideoGame();
            MockManager manager = new MockManager(videoGame.Context);
            manager.OnAwake();
        }

        /// <summary>
        ///     Tests that test on start
        /// </summary>
        [Fact]
        public void Test_OnStart()
        {
            VideoGame videoGame = new VideoGame();
            MockManager manager = new MockManager(videoGame.Context);
            manager.OnStart();
        }

        /// <summary>
        ///     Tests that test on before update
        /// </summary>
        [Fact]
        public void Test_OnBeforeUpdate()
        {
            VideoGame videoGame = new VideoGame();
            MockManager manager = new MockManager(videoGame.Context);
            manager.OnBeforeUpdate();
        }

        /// <summary>
        ///     Tests that test on update
        /// </summary>
        [Fact]
        public void Test_OnUpdate()
        {
            VideoGame videoGame = new VideoGame();
            MockManager manager = new MockManager(videoGame.Context);
            manager.OnUpdate();
        }

        /// <summary>
        ///     Tests that test on after update
        /// </summary>
        [Fact]
        public void Test_OnAfterUpdate()
        {
            VideoGame videoGame = new VideoGame();
            MockManager manager = new MockManager(videoGame.Context);
            manager.OnAfterUpdate();
        }

        /// <summary>
        ///     Tests that test on before fixed update
        /// </summary>
        [Fact]
        public void Test_OnBeforeFixedUpdate()
        {
            VideoGame videoGame = new VideoGame();
            MockManager manager = new MockManager(videoGame.Context);
            manager.OnBeforeFixedUpdate();
        }

        /// <summary>
        ///     Tests that test on fixed update
        /// </summary>
        [Fact]
        public void Test_OnFixedUpdate()
        {
            VideoGame videoGame = new VideoGame();
            MockManager manager = new MockManager(videoGame.Context);
            manager.OnFixedUpdate();
        }

        /// <summary>
        ///     Tests that test on after fixed update
        /// </summary>
        [Fact]
        public void Test_OnAfterFixedUpdate()
        {
            VideoGame videoGame = new VideoGame();
            MockManager manager = new MockManager(videoGame.Context);
            manager.OnAfterFixedUpdate();
        }

        /// <summary>
        ///     Tests that test on dispatch events
        /// </summary>
        [Fact]
        public void Test_OnDispatchEvents()
        {
            VideoGame videoGame = new VideoGame();
            MockManager manager = new MockManager(videoGame.Context);
            manager.OnDispatchEvents();
        }

        /// <summary>
        ///     Tests that test on calculate
        /// </summary>
        [Fact]
        public void Test_OnCalculate()
        {
            VideoGame videoGame = new VideoGame();
            MockManager manager = new MockManager(videoGame.Context);
            manager.OnCalculate();
        }

        /// <summary>
        ///     Tests that test on draw
        /// </summary>
        [Fact]
        public void Test_OnDraw()
        {
            VideoGame videoGame = new VideoGame();
            MockManager manager = new MockManager(videoGame.Context);
            manager.OnDraw();
        }

        /// <summary>
        ///     Tests that test on gui
        /// </summary>
        [Fact]
        public void Test_OnGui()
        {
            VideoGame videoGame = new VideoGame();
            MockManager manager = new MockManager(videoGame.Context);
            manager.OnGui();
        }

        /// <summary>
        ///     Tests that test on disable
        /// </summary>
        [Fact]
        public void Test_OnDisable()
        {
            VideoGame videoGame = new VideoGame();
            MockManager manager = new MockManager(videoGame.Context);
            manager.OnDisable();
        }

        /// <summary>
        ///     Tests that test on reset
        /// </summary>
        [Fact]
        public void Test_OnReset()
        {
            VideoGame videoGame = new VideoGame();
            MockManager manager = new MockManager(videoGame.Context);
            manager.OnReset();
        }

        /// <summary>
        ///     Tests that test on stop
        /// </summary>
        [Fact]
        public void Test_OnStop()
        {
            VideoGame videoGame = new VideoGame();
            MockManager manager = new MockManager(videoGame.Context);
            manager.OnStop();
        }

        /// <summary>
        ///     Tests that test on exit
        /// </summary>
        [Fact]
        public void Test_OnExit()
        {
            VideoGame videoGame = new VideoGame();
            MockManager manager = new MockManager(videoGame.Context);
            manager.OnExit();
        }

        /// <summary>
        ///     Tests that test on destroy
        /// </summary>
        [Fact]
        public void Test_OnDestroy()
        {
            VideoGame videoGame = new VideoGame();
            MockManager manager = new MockManager(videoGame.Context);
            manager.OnDestroy();
        }

        /// <summary>
        ///     Tests that is enable property set get returns correct value
        /// </summary>
        [Fact]
        public void IsEnable_PropertySet_GetReturnsCorrectValue()
        {
            VideoGame videoGame = new VideoGame();
            MockManager manager = new MockManager(videoGame.Context);
            manager.IsEnable = true;
            Assert.True(manager.IsEnable);
        }

        /// <summary>
        ///     Tests that name property set get returns correct value
        /// </summary>
        [Fact]
        public void Name_PropertySet_GetReturnsCorrectValue()
        {
            VideoGame videoGame = new VideoGame();
            MockManager manager = new MockManager(videoGame.Context);
            manager.Name = "TestManager";
            Assert.Equal("TestManager", manager.Name);
        }

        /// <summary>
        ///     Tests that id property set get returns correct value
        /// </summary>
        [Fact]
        public void Id_PropertySet_GetReturnsCorrectValue()
        {
            VideoGame videoGame = new VideoGame();
            MockManager manager = new MockManager(videoGame.Context);
            manager.Id = "TestId";
            Assert.Equal("TestId", manager.Id);
        }

        /// <summary>
        ///     Tests that tag property set get returns correct value
        /// </summary>
        [Fact]
        public void Tag_PropertySet_GetReturnsCorrectValue()
        {
            VideoGame videoGame = new VideoGame();
            MockManager manager = new MockManager(videoGame.Context);
            manager.Tag = "TestTag";
            Assert.Equal("TestTag", manager.Tag);
        }
    }
}