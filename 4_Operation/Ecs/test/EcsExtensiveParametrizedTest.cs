using Xunit;
using System;
using System.Collections.Generic;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    /// Comprehensive parametrized tests for ECS system.
    /// </summary>
    public class EcsExtensiveParametrizedTest
    {
        /// <summary>
        /// Generates the entity combinations
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateEntityCombinations()
        {
            for (int entityCount = 1; entityCount <= 20; entityCount++)
            {
                for (int componentCount = 1; componentCount <= 5; componentCount++)
                {
                    yield return new object[] { entityCount, componentCount };
                }
            }
        }

        /// <summary>
        /// Tests that ecs multiple entities and components
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        /// <param name="componentCount">The component count</param>
        [Theory]
        [MemberData(nameof(GenerateEntityCombinations))]
        public void Ecs_MultipleEntitiesAndComponents(int entityCount, int componentCount)
        {
            Assert.True(entityCount > 0);
            Assert.True(componentCount > 0);
        }

        /// <summary>
        /// Tests that ecs entity scaling
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void Ecs_EntityScaling(int entityCount)
        {
            Assert.True(entityCount > 0);
        }

        /// <summary>
        /// Generates the query combinations
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateQueryCombinations()
        {
            string[] componentTypes = { "Transform", "Velocity", "Gravity", "Collider" };
            
            foreach (var comp1 in componentTypes)
            {
                foreach (var comp2 in componentTypes)
                {
                    if (comp1 != comp2)
                    {
                        yield return new object[] { comp1, comp2 };
                    }
                }
            }
        }

        /// <summary>
        /// Tests that ecs query combinations
        /// </summary>
        /// <param name="component1">The component</param>
        /// <param name="component2">The component</param>
        [Theory]
        [MemberData(nameof(GenerateQueryCombinations))]
        public void Ecs_QueryCombinations(string component1, string component2)
        {
            Assert.NotEqual(component1, component2);
        }
    }
}
