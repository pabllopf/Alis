// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WithTest.cs
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

using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    ///     The with test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="With{T}"/> struct which specifies that a query
    ///     should include entities that have a specific component type.
    /// </remarks>
    public class WithTest
    {
        /// <summary>
        ///     Tests that with implements rule provider
        /// </summary>
        /// <remarks>
        ///     Verifies that With implements IRuleProvider interface.
        /// </remarks>
        [Fact]
        public void With_ImplementsRuleProvider()
        {
            // Arrange & Act
            With<Position> with = default;

            // Assert
            Assert.IsAssignableFrom<IRuleProvider>(with);
        }

        /// <summary>
        ///     Tests that with rule returns has component rule
        /// </summary>
        /// <remarks>
        ///     Validates that With.Rule returns a rule for HasComponent.
        /// </remarks>
        [Fact]
        public void With_RuleReturnsHasComponentRule()
        {
            // Arrange
            With<Position> with = default;

            // Act
            Rule rule = with.Rule;

            // Assert
            Assert.NotEqual(default(Rule), rule);
        }

        /// <summary>
        ///     Tests that with can be used in query
        /// </summary>
        /// <remarks>
        ///     Validates that With can be used in Scene.Query.
        /// </remarks>
        [Fact]
        public void With_CanBeUsedInQuery()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 });

            // Act
            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (RefTuple<Position> _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that with filters entities correctly
        /// </summary>
        /// <remarks>
        ///     Tests that With only includes entities with the specified component.
        /// </remarks>
        [Fact]
        public void With_FiltersEntitiesCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 });
            scene.Create(new Velocity { VX = 1, VY = 1 }); // No Position

            // Act
            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (RefTuple<Position> _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that multiple with filters work together
        /// </summary>
        /// <remarks>
        ///     Validates that multiple With filters can be combined in a query.
        /// </remarks>
        [Fact]
        public void MultipleWithFilters_WorkTogether()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 }, new Velocity { VX = 1, VY = 1 });
            scene.Create(new Position { X = 2, Y = 2 });

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>>();
            int count = 0;
            foreach (RefTuple<Position, Velocity> _ in query.Enumerate<Position, Velocity>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that with default instance has valid rule
        /// </summary>
        /// <remarks>
        ///     Validates that default With instance produces a valid rule.
        /// </remarks>
        [Fact]
        public void With_DefaultInstanceHasValidRule()
        {
            // Arrange
            With<Position> with1 = default;
            With<Position> with2 = new With<Position>();

            // Act
            Rule rule1 = with1.Rule;
            Rule rule2 = with2.Rule;

            // Assert
            Assert.Equal(rule1, rule2);
        }

        /// <summary>
        ///     Tests that with for different types creates different rules
        /// </summary>
        /// <remarks>
        ///     Validates that With for different component types creates different rules.
        /// </remarks>
        [Fact]
        public void With_ForDifferentTypes_CreatesDifferentRules()
        {
            // Arrange
            With<Position> withPos = default;
            With<Velocity> withVel = default;

            // Act
            Rule rulePos = withPos.Rule;
            Rule ruleVel = withVel.Rule;

            // Assert
            Assert.NotEqual(rulePos, ruleVel);
        }
    }
}

