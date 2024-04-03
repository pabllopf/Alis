// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameTest.cs
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
using Alis.Core.Aspect.Time;
using Alis.Core.Ecs.Entity.GameObject;
using Alis.Core.Ecs.System;
using Alis.Core.Ecs.System.Manager;
using Alis.Core.Test.Ecs.Component;
using Alis.Core.Test.Ecs.System.Manager;
using Xunit;

namespace Alis.Core.Test.Ecs.System
{
    /// <summary>
    ///     The game tests class
    /// </summary>
    public class GameTest
    {
        /// <summary>
        ///     Tests that run should set is running to true
        /// </summary>
        [Fact]
        public void Run_ShouldSetIsRunningToTrue()
        {
            IGame game = new GameSample();
            Assert.True(game.IsRunning);
        }

        /// <summary>
        ///     Tests that managers should be initialized empty
        /// </summary>
        [Fact]
        public void Managers_ShouldBeInitialized_Empty() => Assert.Empty(new GameSample().Managers);

        /// <summary>
        ///     Tests that managers should be initialized not null
        /// </summary>
        [Fact]
        public void Managers_ShouldBeInitialized_NotNull() => Assert.NotNull(new GameSample().Managers);

        /// <summary>
        ///     Tests that add should add manager
        /// </summary>
        [Fact]
        public void Add_ShouldAddManager()
        {
            IGame game = new GameSample();
            IManager manager = new ManagerSample();
            game.Add(manager);
            Assert.Contains(manager, game.Managers);
        }

        /// <summary>
        ///     Tests that remove should remove manager
        /// </summary>
        [Fact]
        public void Remove_ShouldRemoveManager()
        {
            IGame game = new GameSample();
            IManager manager = new ManagerSample();
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
            IGame game = new GameSample();
            IManager manager = new ManagerSample();
            game.Add(manager);
            Assert.Equal(manager, game.Get<ManagerSample>());
        }

        /// <summary>
        ///     Tests that contains should contains manager
        /// </summary>
        [Fact]
        public void Contains_ShouldContainsManager()
        {
            IGame game = new GameSample();
            IManager manager = new ManagerSample();
            game.Add(manager);
            Assert.True(game.Contains<ManagerSample>());
        }

        /// <summary>
        ///     Tests that clear should clear manager
        /// </summary>
        [Fact]
        public void Clear_ShouldClearManager()
        {
            IGame game = new GameSample();
            IManager manager = new ManagerSample();
            game.Add(manager);
            game.Clear<ManagerSample>();
            Assert.DoesNotContain(manager, game.Managers);
        }

        /// <summary>
        ///     Tests that set is running changes value
        /// </summary>
        [Fact]
        public void SetIsRunning_ChangesValue()
        {
            // Arrange
            GameSample game = new GameSample();
            bool newValue = false;

            // Act
            game.IsRunning = newValue;

            // Assert
            Assert.Equal(newValue, game.IsRunning);
        }

        /// <summary>
        ///     Tests that add manager adds manager to list
        /// </summary>
        [Fact]
        public void AddManager_AddsManagerToList()
        {
            // Arrange
            GameSample game = new GameSample();
            IManager manager = new ManagerSample();

            // Act
            game.Add(manager);

            // Assert
            Assert.Contains(manager, game.Managers);
        }

        /// <summary>
        ///     Tests that remove manager removes manager from list
        /// </summary>
        [Fact]
        public void RemoveManager_RemovesManagerFromList()
        {
            // Arrange
            GameSample game = new GameSample();
            IManager manager = new ManagerSample();
            game.Add(manager);

            // Act
            game.Remove(manager);

            // Assert
            Assert.DoesNotContain(manager, game.Managers);
        }

        /// <summary>
        ///     Tests that get manager returns manager from list
        /// </summary>
        [Fact]
        public void GetManager_ReturnsManagerFromList()
        {
            // Arrange
            GameSample game = new GameSample();
            IManager manager = new ManagerSample();
            game.Add(manager);

            // Act
            ManagerSample retrievedManager = game.Get<ManagerSample>();

            // Assert
            Assert.Equal(manager, retrievedManager);
        }

        /// <summary>
        ///     Tests that contains manager returns true if manager in list
        /// </summary>
        [Fact]
        public void ContainsManager_ReturnsTrueIfManagerInList()
        {
            // Arrange
            GameSample game = new GameSample();
            IManager manager = new ManagerSample();
            game.Add(manager);

            // Act
            bool containsManager = game.Contains<ManagerSample>();

            // Assert
            Assert.True(containsManager);
        }

        /// <summary>
        ///     Tests that clear manager removes all instances of manager from list
        /// </summary>
        [Fact]
        public void ClearManager_RemovesAllInstancesOfManagerFromList()
        {
            // Arrange
            GameSample game = new GameSample();
            IManager manager = new ManagerSample();
            game.Add(manager);

            // Act
            game.Clear<ManagerSample>();

            // Assert
            Assert.DoesNotContain(manager, game.Managers);
        }

        /// <summary>
        ///     Tests that set adds component to managers
        /// </summary>
        [Fact]
        public void Set_AddsComponentToManagers()
        {
            // Arrange
            GameSample game = new GameSample();
            IManager manager = new ManagerSample();

            // Act
            game.Set(manager);

            // Assert
            Assert.Contains(manager, game.Managers);
        }

        /// <summary>
        ///     Tests that set replaces existing component
        /// </summary>
        [Fact]
        public void Set_ReplacesExistingComponent()
        {
            // Arrange
            GameSample game = new GameSample();
            IManager manager1 = new ManagerSample();
            IManager manager2 = new ManagerSample();
            game.Set(manager1);

            // Act
            game.Set(manager2);

            // Assert
            Assert.DoesNotContain(manager1, game.Managers);
            Assert.Contains(manager2, game.Managers);
        }

        /// <summary>
        ///     Tests that set adds new manager when no existing manager of same type
        /// </summary>
        [Fact]
        public void Set_AddsNewManager_WhenNoExistingManagerOfSameType()
        {
            // Arrange
            GameSample game = new GameSample();
            IManager manager = new ManagerSample();

            // Act
            game.Set(manager);

            // Assert
            Assert.Contains(manager, game.Managers);
        }

        /// <summary>
        ///     Tests that set replaces existing manager when manager of same type exists
        /// </summary>
        [Fact]
        public void Set_ReplacesExistingManager_WhenManagerOfSameTypeExists()
        {
            // Arrange
            GameSample game = new GameSample();
            IManager manager1 = new ManagerSample();
            IManager manager2 = new ManagerSample();
            game.Add(manager1);

            // Act
            game.Set(manager2);

            // Assert
            Assert.DoesNotContain(manager1, game.Managers);
            Assert.Contains(manager2, game.Managers);
        }

        /// <summary>
        ///     Tests that set keeps other managers unchanged
        /// </summary>
        [Fact]
        public void Set_KeepsOtherManagersUnchanged()
        {
            // Arrange
            GameSample game = new GameSample();
            IManager manager1 = new ManagerSample();
            IManager manager2 = new ManagerSample();
            IManager manager3 = new ManagerSample();
            game.Add(manager1);
            game.Add(manager2);

            // Act
            game.Set(manager3);

            // Assert
            Assert.DoesNotContain(manager1, game.Managers);
            Assert.Contains(manager2, game.Managers);
        }

        /// <summary>
        ///     Tests that get is running returns correct value
        /// </summary>
        [Fact]
        public void GetIsRunning_ReturnsCorrectValue()
        {
            // Arrange
            GameSample game = new GameSample();
            bool expectedValue = true;
            game.IsRunning = expectedValue;

            // Act
            bool actualValue = game.IsRunning;

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }

        /// <summary>
        ///     Tests that get managers returns correct value
        /// </summary>
        [Fact]
        public void GetManagers_ReturnsCorrectValue()
        {
            // Arrange
            GameSample game = new GameSample();
            IManager manager = new ManagerSample();
            game.Add(manager);

            // Act
            List<IManager> actualManagers = game.Managers;

            // Assert
            Assert.Contains(manager, actualManagers);
        }

        /// <summary>
        ///     Tests that get manager returns correct manager
        /// </summary>
        [Fact]
        public void GetManager_ReturnsCorrectManager()
        {
            // Arrange
            GameSample game = new GameSample();
            IManager manager = new ManagerSample();
            game.Add(manager);

            // Act
            ManagerSample actualManager = game.Get<ManagerSample>();

            // Assert
            Assert.Equal(manager, actualManager);
        }

        /// <summary>
        ///     Tests that contains manager returns correct value
        /// </summary>
        [Fact]
        public void ContainsManager_ReturnsCorrectValue()
        {
            // Arrange
            GameSample game = new GameSample();
            IManager manager = new ManagerSample();
            game.Add(manager);

            // Act
            bool containsManager = game.Contains<ManagerSample>();

            // Assert
            Assert.True(containsManager);
        }

        /// <summary>
        ///     Tests that on init calls on init on each component
        /// </summary>
        [Fact]
        public void OnInit_CallsOnInitOnEachComponent()
        {
            // Arrange
            GameObject gameObject = new GameObject();
            ComponentSample component1 = new ComponentSample();
            ComponentSample component2 = new ComponentSample();
            gameObject.Add(component1);
            gameObject.Add(component2);

            // Act
            gameObject.OnInit();

            // Assert
            // Here you would assert that the OnInit method was called on each component
            // This will depend on the implementation of your ComponentSample class
        }

        /// <summary>
        ///     Tests that on awake calls on awake on each component
        /// </summary>
        [Fact]
        public void OnAwake_CallsOnAwakeOnEachComponent()
        {
            // Arrange
            GameObject gameObject = new GameObject();
            ComponentSample component1 = new ComponentSample();
            ComponentSample component2 = new ComponentSample();
            gameObject.Add(component1);
            gameObject.Add(component2);

            // Act
            gameObject.OnAwake();

            // Assert
            // Here you would assert that the OnAwake method was called on each component
            // This will depend on the implementation of your ComponentSample class
        }

        /// <summary>
        ///     Tests that on start calls on start on each component
        /// </summary>
        [Fact]
        public void OnStart_CallsOnStartOnEachComponent()
        {
            // Arrange
            GameObject gameObject = new GameObject();
            ComponentSample component1 = new ComponentSample();
            ComponentSample component2 = new ComponentSample();
            gameObject.Add(component1);
            gameObject.Add(component2);

            // Act
            gameObject.OnStart();

            // Assert
            // Here you would assert that the OnStart method was called on each component
            // This will depend on the implementation of your ComponentSample class
        }

        /// <summary>
        ///     Tests that on before update calls on before update on each component
        /// </summary>
        [Fact]
        public void OnBeforeUpdate_CallsOnBeforeUpdateOnEachComponent()
        {
            // Arrange
            GameObject gameObject = new GameObject();
            ComponentSample component1 = new ComponentSample();
            ComponentSample component2 = new ComponentSample();
            gameObject.Add(component1);
            gameObject.Add(component2);

            // Act
            gameObject.OnBeforeUpdate();

            // Assert
            // Here you would assert that the OnBeforeUpdate method was called on each component
            // This will depend on the implementation of your ComponentSample class
        }

        /// <summary>
        ///     Tests that is running get set property works
        /// </summary>
        [Fact]
        public void IsRunning_GetSetPropertyWorks()
        {
            // Arrange
            GameSample game = new GameSample
            {
                // Act
                IsRunning = false
            };

            // Assert
            Assert.False(game.IsRunning);
        }

        /// <summary>
        ///     Tests that time manager get property works
        /// </summary>
        [Fact]
        public void TimeManager_GetPropertyWorks()
        {
            // Arrange
            GameSample game = new GameSample();

            // Act
            TimeManager timeManager = Game.TimeManager;

            // Assert
            Assert.NotNull(timeManager);
        }
    }
}