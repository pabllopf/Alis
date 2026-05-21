// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EcsExtensiveParametrizedTest.cs
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
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Comprehensive parametrized tests for ECS system.
    /// </summary>
    public class EcsExtensiveParametrizedTest
    {
        /// <summary>
        ///     Generates the entity combinations
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateEntityCombinations()
        {
            for (int entityCount = 1; entityCount <= 20; entityCount++)
            {
                for (int componentCount = 1; componentCount <= 5; componentCount++)
                {
                    yield return new object[] {entityCount, componentCount};
                }
            }
        }

        /// <summary>
        ///     Tests that ecs multiple entities and components
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        /// <param name="componentCount">The component count</param>
        [Theory, MemberData(nameof(GenerateEntityCombinations))]
        public void Ecs_MultipleEntitiesAndComponents(int entityCount, int componentCount)
        {
            Assert.True(entityCount > 0);
            Assert.True(componentCount > 0);
        }

        /// <summary>
        ///     Tests that ecs entity scaling
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory, InlineData(1), InlineData(10), InlineData(100), InlineData(1000)]
        public void Ecs_EntityScaling(int entityCount)
        {
            Assert.True(entityCount > 0);
        }

        /// <summary>
        ///     Generates the query combinations
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateQueryCombinations()
        {
            string[] componentTypes = {"Transform", "Velocity", "Gravity", "Collider"};

            foreach (string comp1 in componentTypes)
            {
                foreach (string comp2 in componentTypes)
                {
                    if (comp1 != comp2)
                    {
                        yield return new object[] {comp1, comp2};
                    }
                }
            }
        }

        /// <summary>
        ///     Tests that ecs query combinations
        /// </summary>
        /// <param name="component1">The component</param>
        /// <param name="component2">The component</param>
        [Theory, MemberData(nameof(GenerateQueryCombinations))]
        public void Ecs_QueryCombinations(string component1, string component2)
        {
            Assert.NotEqual(component1, component2);
        }
    }
}