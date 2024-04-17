// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameTests.cs
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
using Alis.Core.Aspect.Logging;
using Alis.Core.Ecs.System.Manager;
using Xunit;

namespace Alis.Core.Ecs.Test.System
{
    /// <summary>
    ///     The game tests class
    /// </summary>
    public class GameTests
    {
        /// <summary>
        ///     Tests that run should set is running to true
        /// </summary>
        [Fact]
        public void Run_ShouldSetIsRunningToTrue()
        {
            IGame game = new GameTest();
            game.Run();
            Assert.True(game.IsRunning);
        }
        
        /// <summary>
        ///     Tests that managers should be initialized empty
        /// </summary>
        [Fact]
        public void Managers_ShouldBeInitialized_Empty() => Assert.Empty(new GameTest().Managers);
        
        /// <summary>
        ///     Tests that managers should be initialized not null
        /// </summary>
        [Fact]
        public void Managers_ShouldBeInitialized_NotNull() => Assert.NotNull(new GameTest().Managers);
        
        /// <summary>
        ///     Tests that add should add manager
        /// </summary>
        [Fact]
        public void Add_ShouldAddManager()
        {
            IGame game = new GameTest();
            IManager manager = new ManagerTest();
            game.Add(manager);
            Assert.Contains(manager, game.Managers);
        }
        
        /// <summary>
        ///     Tests that remove should remove manager
        /// </summary>
        [Fact]
        public void Remove_ShouldRemoveManager()
        {
            IGame game = new GameTest();
            IManager manager = new ManagerTest();
            game.Add(manager);
            game.Remove(manager);
            Assert.DoesNotContain(manager, game.Managers);
        }
        
        /// <summary>
        ///     Tests that get should get manager
        /// </summary>
        [Fact]
        public void Get_ShouldGetManager()
        {
            IGame game = new GameTest();
            IManager manager = new ManagerTest();
            game.Add(manager);
            Assert.Equal(manager, game.Get<ManagerTest>());
        }
        
        /// <summary>
        ///     Tests that contains should contains manager
        /// </summary>
        [Fact]
        public void Contains_ShouldContainsManager()
        {
            IGame game = new GameTest();
            IManager manager = new ManagerTest();
            game.Add(manager);
            Assert.True(game.Contains<ManagerTest>());
        }
        
        /// <summary>
        ///     Tests that clear should clear manager
        /// </summary>
        [Fact]
        public void Clear_ShouldClearManager()
        {
            IGame game = new GameTest();
            IManager manager = new ManagerTest();
            game.Add(manager);
            game.Clear<ManagerTest>();
            Assert.DoesNotContain(manager, game.Managers);
        }
        
        /// <summary>
        ///     The manager test class
        /// </summary>
        /// <seealso cref="IManager" />
        private class ManagerTest : IManager
        {
            /// <summary>
            ///     Gets or sets the value of the is enable
            /// </summary>
            public bool IsEnable { get; set; }
            
            /// <summary>
            ///     Gets or sets the value of the name
            /// </summary>
            public string Name { get; set; }
            
            /// <summary>
            ///     Gets or sets the value of the id
            /// </summary>
            public string Id { get; set; }
            
            /// <summary>
            ///     Gets or sets the value of the tag
            /// </summary>
            public string Tag { get; set; }
            
            /// <summary>
            ///     Ons the enable
            /// </summary>
            /// <exception cref="NotImplementedException"></exception>
            public void OnEnable()
            {
                Logger.Trace();
            }
            
            /// <summary>
            ///     Ons the init
            /// </summary>
            /// <exception cref="NotImplementedException"></exception>
            public void OnInit()
            {
                Logger.Trace();
            }
            
            /// <summary>
            ///     Ons the awake
            /// </summary>
            /// <exception cref="NotImplementedException"></exception>
            public void OnAwake()
            {
                Logger.Trace();
            }
            
            /// <summary>
            ///     Ons the start
            /// </summary>
            /// <exception cref="NotImplementedException"></exception>
            public void OnStart()
            {
                Logger.Trace();
            }
            
            /// <summary>
            ///     Ons the before update
            /// </summary>
            /// <exception cref="NotImplementedException"></exception>
            public void OnBeforeUpdate()
            {
                Logger.Trace();
            }
            
            /// <summary>
            ///     Ons the update
            /// </summary>
            /// <exception cref="NotImplementedException"></exception>
            public void OnUpdate()
            {
                Logger.Trace();
            }
            
            /// <summary>
            ///     Ons the after update
            /// </summary>
            /// <exception cref="NotImplementedException"></exception>
            public void OnAfterUpdate()
            {
                Logger.Trace();
            }
            
            /// <summary>
            ///     Ons the before fixed update
            /// </summary>
            /// <exception cref="NotImplementedException"></exception>
            public void OnBeforeFixedUpdate()
            {
                Logger.Trace();
            }
            
            /// <summary>
            ///     Ons the fixed update
            /// </summary>
            /// <exception cref="NotImplementedException"></exception>
            public void OnFixedUpdate()
            {
                Logger.Trace();
            }
            
            /// <summary>
            ///     Ons the after fixed update
            /// </summary>
            /// <exception cref="NotImplementedException"></exception>
            public void OnAfterFixedUpdate()
            {
                Logger.Trace();
            }
            
            /// <summary>
            ///     Ons the dispatch events
            /// </summary>
            /// <exception cref="NotImplementedException"></exception>
            public void OnDispatchEvents()
            {
                Logger.Trace();
            }
            
            /// <summary>
            ///     Ons the calculate
            /// </summary>
            /// <exception cref="NotImplementedException"></exception>
            public void OnCalculate()
            {
                Logger.Trace();
            }
            
            /// <summary>
            ///     Ons the draw
            /// </summary>
            /// <exception cref="NotImplementedException"></exception>
            public void OnDraw()
            {
                Logger.Trace();
            }
            
            /// <summary>
            ///     Ons the gui
            /// </summary>
            /// <exception cref="NotImplementedException"></exception>
            public void OnGui()
            {
                Logger.Trace();
            }
            
            /// <summary>
            ///     Ons the disable
            /// </summary>
            /// <exception cref="NotImplementedException"></exception>
            public void OnDisable()
            {
                Logger.Trace();
            }
            
            /// <summary>
            ///     Ons the reset
            /// </summary>
            /// <exception cref="NotImplementedException"></exception>
            public void OnReset()
            {
                Logger.Trace();
            }
            
            /// <summary>
            ///     Ons the stop
            /// </summary>
            /// <exception cref="NotImplementedException"></exception>
            public void OnStop()
            {
                Logger.Trace();
            }
            
            /// <summary>
            ///     Ons the exit
            /// </summary>
            /// <exception cref="NotImplementedException"></exception>
            public void OnExit()
            {
                Logger.Trace();
            }
            
            /// <summary>
            ///     Ons the destroy
            /// </summary>
            /// <exception cref="NotImplementedException"></exception>
            public void OnDestroy()
            {
                Logger.Trace();
            }
        }
    }
}