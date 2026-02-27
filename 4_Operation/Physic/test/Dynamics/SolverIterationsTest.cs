// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SolverIterationsTest.cs
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
    ///     The solver iterations test class
    /// </summary>
    public class SolverIterationsTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with default values
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithDefaultValues()
        {
            SolverIterations iterations = new SolverIterations();
            
            Assert.Equal(0, iterations.VelocityIterations);
            Assert.Equal(0, iterations.PositionIterations);
            Assert.Equal(0, iterations.ToiVelocityIterations);
            Assert.Equal(0, iterations.ToiPositionIterations);
        }

        /// <summary>
        ///     Tests that velocity iterations should set and get correctly
        /// </summary>
        [Fact]
        public void VelocityIterations_ShouldSetAndGetCorrectly()
        {
            SolverIterations iterations = new SolverIterations
            {
                VelocityIterations = 8
            };
            
            Assert.Equal(8, iterations.VelocityIterations);
        }

        /// <summary>
        ///     Tests that position iterations should set and get correctly
        /// </summary>
        [Fact]
        public void PositionIterations_ShouldSetAndGetCorrectly()
        {
            SolverIterations iterations = new SolverIterations
            {
                PositionIterations = 3
            };
            
            Assert.Equal(3, iterations.PositionIterations);
        }

        /// <summary>
        ///     Tests that toi velocity iterations should set and get correctly
        /// </summary>
        [Fact]
        public void ToiVelocityIterations_ShouldSetAndGetCorrectly()
        {
            SolverIterations iterations = new SolverIterations
            {
                ToiVelocityIterations = 10
            };
            
            Assert.Equal(10, iterations.ToiVelocityIterations);
        }

        /// <summary>
        ///     Tests that toi position iterations should set and get correctly
        /// </summary>
        [Fact]
        public void ToiPositionIterations_ShouldSetAndGetCorrectly()
        {
            SolverIterations iterations = new SolverIterations
            {
                ToiPositionIterations = 20
            };
            
            Assert.Equal(20, iterations.ToiPositionIterations);
        }

        /// <summary>
        ///     Tests that all properties should set correctly
        /// </summary>
        [Fact]
        public void AllProperties_ShouldSetCorrectly()
        {
            SolverIterations iterations = new SolverIterations
            {
                VelocityIterations = 8,
                PositionIterations = 3,
                ToiVelocityIterations = 10,
                ToiPositionIterations = 20
            };
            
            Assert.Equal(8, iterations.VelocityIterations);
            Assert.Equal(3, iterations.PositionIterations);
            Assert.Equal(10, iterations.ToiVelocityIterations);
            Assert.Equal(20, iterations.ToiPositionIterations);
        }

        /// <summary>
        ///     Tests that iterations with negative values should work
        /// </summary>
        [Fact]
        public void Iterations_WithNegativeValues_ShouldWork()
        {
            SolverIterations iterations = new SolverIterations
            {
                VelocityIterations = -1,
                PositionIterations = -1
            };
            
            Assert.Equal(-1, iterations.VelocityIterations);
            Assert.Equal(-1, iterations.PositionIterations);
        }

        /// <summary>
        ///     Tests that iterations with zero should work
        /// </summary>
        [Fact]
        public void Iterations_WithZero_ShouldWork()
        {
            SolverIterations iterations = new SolverIterations
            {
                VelocityIterations = 0,
                PositionIterations = 0,
                ToiVelocityIterations = 0,
                ToiPositionIterations = 0
            };
            
            Assert.Equal(0, iterations.VelocityIterations);
            Assert.Equal(0, iterations.PositionIterations);
            Assert.Equal(0, iterations.ToiVelocityIterations);
            Assert.Equal(0, iterations.ToiPositionIterations);
        }
    }
}

