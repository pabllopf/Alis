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

using System.Collections.Generic;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Time;
using Alis.Core.Physic.Dynamics.Solver;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Solver
{
    /// <summary>
    ///     The solver data test class
    /// </summary>
    public class SolverDataTest
    {
        /// <summary>
        ///     Tests that solver data properties test
        /// </summary>
        [Fact]
        public void SolverDataPropertiesTest()
        {
            // Arrange
            SolverData solverData = new SolverData();
            
            // Act
            TimeStep timeStep = new TimeStep();
            solverData.Step = timeStep;
            
            List<Position> positions = new List<Position>();
            solverData.Positions = positions;
            
            List<Velocity> velocities = new List<Velocity>();
            solverData.Velocities = velocities;
            
            // Assert
            Assert.Equal(timeStep, solverData.Step);
            Assert.Equal(positions, solverData.Positions);
            Assert.Equal(velocities, solverData.Velocities);
        }
    }
}