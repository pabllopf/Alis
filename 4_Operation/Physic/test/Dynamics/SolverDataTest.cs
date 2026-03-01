// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SolverDataTest.cs
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

using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The solver data test class
    /// </summary>
    public class SolverDataTest
    {
        /// <summary>
        ///     Tests that default constructor should initialize with default values
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeWithDefaultValues()
        {
            SolverData data = new SolverData();
            
            Assert.Equal(default(TimeStep), data.Step);
            Assert.Null(data.Positions);
            Assert.Null(data.Velocities);
            Assert.Null(data.Locks);
        }

        /// <summary>
        ///     Tests that step property should set and get correctly
        /// </summary>
        [Fact]
        public void StepProperty_ShouldSetAndGetCorrectly()
        {
            TimeStep timeStep = new TimeStep
            {
                Dt = 0.016f
            };
            
            SolverData data = new SolverData
            {
                Step = timeStep
            };
            
            Assert.Equal(0.016f, data.Step.Dt);
        }

        /// <summary>
        ///     Tests that positions property should set and get correctly
        /// </summary>
        [Fact]
        public void PositionsProperty_ShouldSetAndGetCorrectly()
        {
            SolverPosition[] positions = new SolverPosition[5];
            SolverData data = new SolverData
            {
                Positions = positions
            };
            
            Assert.NotNull(data.Positions);
            Assert.Equal(5, data.Positions.Length);
        }

        /// <summary>
        ///     Tests that velocities property should set and get correctly
        /// </summary>
        [Fact]
        public void VelocitiesProperty_ShouldSetAndGetCorrectly()
        {
            SolverVelocity[] velocities = new SolverVelocity[10];
            SolverData data = new SolverData
            {
                Velocities = velocities
            };
            
            Assert.NotNull(data.Velocities);
            Assert.Equal(10, data.Velocities.Length);
        }

        /// <summary>
        ///     Tests that locks property should set and get correctly
        /// </summary>
        [Fact]
        public void LocksProperty_ShouldSetAndGetCorrectly()
        {
            int[] locks = new int[3];
            SolverData data = new SolverData
            {
                Locks = locks
            };
            
            Assert.NotNull(data.Locks);
            Assert.Equal(3, data.Locks.Length);
        }

        /// <summary>
        ///     Tests that solver data should handle empty arrays
        /// </summary>
        [Fact]
        public void SolverData_ShouldHandleEmptyArrays()
        {
            SolverData data = new SolverData
            {
                Positions = new SolverPosition[0],
                Velocities = new SolverVelocity[0],
                Locks = new int[0]
            };
            
            Assert.NotNull(data.Positions);
            Assert.NotNull(data.Velocities);
            Assert.NotNull(data.Locks);
            Assert.Empty(data.Positions);
            Assert.Empty(data.Velocities);
            Assert.Empty(data.Locks);
        }

        /// <summary>
        ///     Tests that solver data should be value type
        /// </summary>
        [Fact]
        public void SolverData_ShouldBeValueType()
        {
            SolverData data1 = new SolverData();
            SolverData data2 = data1;
            
            data2.Locks = new int[1];
            
            Assert.Null(data1.Locks);
            Assert.NotNull(data2.Locks);
        }

        /// <summary>
        ///     Tests that solver data should handle all properties together
        /// </summary>
        [Fact]
        public void SolverData_ShouldHandleAllPropertiesTogether()
        {
            TimeStep step = new TimeStep { Dt = 0.033f };
            SolverPosition[] positions = new SolverPosition[2];
            SolverVelocity[] velocities = new SolverVelocity[2];
            int[] locks = new int[2];
            
            SolverData data = new SolverData
            {
                Step = step,
                Positions = positions,
                Velocities = velocities,
                Locks = locks
            };
            
            Assert.Equal(0.033f, data.Step.Dt);
            Assert.Equal(2, data.Positions.Length);
            Assert.Equal(2, data.Velocities.Length);
            Assert.Equal(2, data.Locks.Length);
        }
    }
}

