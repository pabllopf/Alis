// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EcsStressTest.cs
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

using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The ECS stress test class
    /// </summary>
    /// <remarks>
    ///     Stress tests for the ECS system to validate performance and stability
    ///     under heavy loads. Tests include large entity counts, many archetypes,
    ///     and intensive operations.
    /// </remarks>
    public class EcsStressTest
    {

        /// <summary>
        ///     Tests rapid component addition and removal cycles
        /// </summary>
        /// <remarks>
        ///     Validates that frequent structural changes don't corrupt
        ///     entity state or cause performance issues.
        /// </remarks>
        [Fact]
        public void EcsStress_RapidComponentCyclesDoNotCorrupt()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            // Act - Rapidly add and remove components
            for (int cycle = 0; cycle < 100; cycle++)
            {
                entity.Add(new Position());
                entity.Add(new Velocity());
                entity.Add(new Health());
                entity.Remove<Health>();
                entity.Remove<Velocity>();
                entity.Remove<Position>();
            }

            // Assert
            Assert.False(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
        }
    }
}

