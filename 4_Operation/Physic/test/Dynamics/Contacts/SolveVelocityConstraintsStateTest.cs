// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SolveVelocityConstraintsStateTest.cs
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
using System.Reflection;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    ///     The solve velocity constraints state test class
    /// </summary>
    public class SolveVelocityConstraintsStateTest
    {
        /// <summary>
        /// Tests that get should create new state when queue is empty
        /// </summary>
        [Fact]
        public void Get_ShouldCreateNewStateWhenQueueIsEmpty()
        {
            ContactSolver contactSolver = new ContactSolver();

            object state = SolveVelocityConstraintsState.Get(contactSolver, 0, 5);

            Assert.NotNull(state);
            SolveVelocityConstraintsState casted = (SolveVelocityConstraintsState)state;
            Assert.Equal(contactSolver, casted.ContactSolver);
            Assert.Equal(0, casted.Start);
            Assert.Equal(5, casted.End);
        }

        /// <summary>
        /// Tests that get should set correct start and end values
        /// </summary>
        [Fact]
        public void Get_ShouldSetCorrectStartAndEndValues()
        {
            ContactSolver contactSolver = new ContactSolver();

            object state = SolveVelocityConstraintsState.Get(contactSolver, 3, 8);

            SolveVelocityConstraintsState casted = (SolveVelocityConstraintsState)state;
            Assert.Equal(3, casted.Start);
            Assert.Equal(8, casted.End);
        }

        /// <summary>
        /// Tests that get should set contact solver correctly
        /// </summary>
        [Fact]
        public void Get_ShouldSetContactSolverCorrectly()
        {
            ContactSolver contactSolver = new ContactSolver();

            object state = SolveVelocityConstraintsState.Get(contactSolver, 0, 10);

            SolveVelocityConstraintsState casted = (SolveVelocityConstraintsState)state;
            Assert.Equal(contactSolver, casted.ContactSolver);
        }

        /// <summary>
        /// Tests that return should add state back to queue
        /// </summary>
        [Fact]
        public void Return_ShouldAddStateBackToQueue()
        {
            ContactSolver contactSolver = new ContactSolver();

            object state1 = SolveVelocityConstraintsState.Get(contactSolver, 0, 5);
            SolveVelocityConstraintsState.Return(state1);

            object state2 = SolveVelocityConstraintsState.Get(contactSolver, 5, 10);
            SolveVelocityConstraintsState casted2 = (SolveVelocityConstraintsState)state2;

            Assert.NotNull(casted2);
        }

        /// <summary>
        /// Tests that return should restore state properties
        /// </summary>
        [Fact]
        public void Return_ShouldRestoreStateProperties()
        {
            ContactSolver contactSolver = new ContactSolver();

            object state1 = SolveVelocityConstraintsState.Get(contactSolver, 2, 7);
            SolveVelocityConstraintsState.Return(state1);

            object state2 = SolveVelocityConstraintsState.Get(contactSolver, 5, 10);
            SolveVelocityConstraintsState casted2 = (SolveVelocityConstraintsState)state2;

            Assert.NotNull(casted2);
        }

        /// <summary>
        /// Tests that multiple get calls should reuse pooled states
        /// </summary>
        [Fact]
        public void MultipleGetCalls_ShouldReusePooledStates()
        {
            ContactSolver contactSolver1 = new ContactSolver();
            ContactSolver contactSolver2 = new ContactSolver();

            object state1 = SolveVelocityConstraintsState.Get(contactSolver1, 0, 5);
            SolveVelocityConstraintsState.Return(state1);

            object state2 = SolveVelocityConstraintsState.Get(contactSolver2, 5, 10);
            SolveVelocityConstraintsState casted2 = (SolveVelocityConstraintsState)state2;

            Assert.NotNull(casted2);
            Assert.Equal(contactSolver2, casted2.ContactSolver);
        }

        /// <summary>
        /// Tests that return should allow state reuse multiple times
        /// </summary>
        [Fact]
        public void Return_ShouldAllowStateReuseMultipleTimes()
        {
            ContactSolver contactSolver = new ContactSolver();

            object state1 = SolveVelocityConstraintsState.Get(contactSolver, 0, 5);
            SolveVelocityConstraintsState.Return(state1);

            object state2 = SolveVelocityConstraintsState.Get(contactSolver, 5, 10);
            SolveVelocityConstraintsState casted2 = (SolveVelocityConstraintsState)state2;

            Assert.NotNull(casted2);
        }

        /// <summary>
        /// Tests that get should handle zero start and end values
        /// </summary>
        [Fact]
        public void Get_ShouldHandleZeroStartAndEndValues()
        {
            ContactSolver contactSolver = new ContactSolver();

            object state = SolveVelocityConstraintsState.Get(contactSolver, 0, 0);

            SolveVelocityConstraintsState casted = (SolveVelocityConstraintsState)state;
            Assert.Equal(0, casted.Start);
            Assert.Equal(0, casted.End);
        }

        /// <summary>
        /// Tests that get should handle large start and end values
        /// </summary>
        [Fact]
        public void Get_ShouldHandleLargeStartAndEndValues()
        {
            ContactSolver contactSolver = new ContactSolver();

            object state = SolveVelocityConstraintsState.Get(contactSolver, 50, 100);

            SolveVelocityConstraintsState casted = (SolveVelocityConstraintsState)state;
            Assert.Equal(50, casted.Start);
            Assert.Equal(100, casted.End);
        }

        /// <summary>
        /// Tests that get should handle same start and end values
        /// </summary>
        [Fact]
        public void Get_ShouldHandleSameStartAndEndValues()
        {
            ContactSolver contactSolver = new ContactSolver();

            object state = SolveVelocityConstraintsState.Get(contactSolver, 5, 5);

            SolveVelocityConstraintsState casted = (SolveVelocityConstraintsState)state;
            Assert.Equal(5, casted.Start);
            Assert.Equal(5, casted.End);
        }

        /// <summary>
        /// Tests that state should be internal
        /// </summary>
        [Fact]
        public void State_ShouldBeInternalClass()
        {
            Type stateType = typeof(SolveVelocityConstraintsState);

            Assert.False(stateType.IsPublic);
            Assert.True(stateType.IsSealed);
        }

        /// <summary>
        /// Tests that state should have private constructor
        /// </summary>
        [Fact]
        public void State_ShouldHavePrivateConstructor()
        {
            Type stateType = typeof(SolveVelocityConstraintsState);
            ConstructorInfo[] constructors = stateType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.NotEmpty(constructors);
        }

        /// <summary>
        /// Tests that get should handle multiple contact solvers
        /// </summary>
        [Fact]
        public void Get_ShouldHandleMultipleContactSolvers()
        {
            ContactSolver contactSolver1 = new ContactSolver();
            ContactSolver contactSolver2 = new ContactSolver();
            ContactSolver contactSolver3 = new ContactSolver();

            object state1 = SolveVelocityConstraintsState.Get(contactSolver1, 0, 5);
            SolveVelocityConstraintsState.Return(state1);

            object state2 = SolveVelocityConstraintsState.Get(contactSolver2, 5, 10);
            object state3 = SolveVelocityConstraintsState.Get(contactSolver3, 10, 15);

            SolveVelocityConstraintsState casted2 = (SolveVelocityConstraintsState)state2;
            SolveVelocityConstraintsState casted3 = (SolveVelocityConstraintsState)state3;

            Assert.Equal(contactSolver2, casted2.ContactSolver);
            Assert.Equal(contactSolver3, casted3.ContactSolver);
        }

        /// <summary>
        /// Tests that return should work with different state configurations
        /// </summary>
        [Fact]
        public void Return_ShouldWorkWithDifferentStateConfigurations()
        {
            ContactSolver contactSolver = new ContactSolver();

            object state1 = SolveVelocityConstraintsState.Get(contactSolver, 0, 3);
            object state2 = SolveVelocityConstraintsState.Get(contactSolver, 3, 6);
            object state3 = SolveVelocityConstraintsState.Get(contactSolver, 6, 9);

            SolveVelocityConstraintsState.Return(state1);
            SolveVelocityConstraintsState.Return(state2);
            SolveVelocityConstraintsState.Return(state3);

            object state4 = SolveVelocityConstraintsState.Get(contactSolver, 0, 9);
            SolveVelocityConstraintsState casted4 = (SolveVelocityConstraintsState)state4;

            Assert.NotNull(casted4);
        }

        /// <summary>
        /// Tests that state properties should be set correctly after get
        /// </summary>
        [Fact]
        public void StateProperties_ShouldBeSetCorrectlyAfterGet()
        {
            ContactSolver contactSolver = new ContactSolver();

            object state = SolveVelocityConstraintsState.Get(contactSolver, 10, 20);
            SolveVelocityConstraintsState casted = (SolveVelocityConstraintsState)state;

            Assert.Equal(10, casted.Start);
            Assert.Equal(20, casted.End);
        }

        /// <summary>
        /// Tests that state should support repeated get and return cycles
        /// </summary>
        [Fact]
        public void State_ShouldSupportRepeatedGetAndReturnCycles()
        {
            ContactSolver contactSolver = new ContactSolver();

            for (int i = 0; i < 10; i++)
            {
                object state = SolveVelocityConstraintsState.Get(contactSolver, i, i + 1);
                SolveVelocityConstraintsState.Return(state);
            }

            object finalState = SolveVelocityConstraintsState.Get(contactSolver, 0, 10);
            SolveVelocityConstraintsState casted = (SolveVelocityConstraintsState)finalState;

            Assert.NotNull(casted);
        }
    }
}
