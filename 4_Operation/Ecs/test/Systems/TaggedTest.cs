// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TaggedTest.cs
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
    ///     The tagged test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="Tagged{T}"/> struct which specifies that a query
    ///     should only include entities that have a specific tag.
    /// </remarks>
    public class TaggedTest
    {
        /// <summary>
        ///     Tests that tagged implements rule provider
        /// </summary>
        /// <remarks>
        ///     Verifies that Tagged implements IRuleProvider interface.
        /// </remarks>
        [Fact]
        public void Tagged_ImplementsRuleProvider()
        {
            // Arrange & Act
            Tagged<PlayerTag> tagged = default;

            // Assert
            Assert.IsAssignableFrom<IRuleProvider>(tagged);
        }

        /// <summary>
        ///     Tests that tagged rule returns has tag rule
        /// </summary>
        /// <remarks>
        ///     Validates that Tagged.Rule returns a rule for HasTag.
        /// </remarks>
        [Fact]
        public void Tagged_RuleReturnsHasTagRule()
        {
            // Arrange
            Tagged<PlayerTag> tagged = default;

            // Act
            Rule rule = tagged.Rule;

            // Assert
            Assert.NotEqual(default(Rule), rule);
        }

        /// <summary>
        ///     Tests that tagged can be used in query
        /// </summary>
        /// <remarks>
        ///     Validates that Tagged can be used in Scene.Query.
        /// </remarks>
        [Fact]
        public void Tagged_CanBeUsedInQuery()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 1 });
            entity.Tag<PlayerTag>();

            // Act
            Query query = scene.Query<With<Position>, Tagged<PlayerTag>>();
            int count = 0;
            foreach (RefTuple<Position> _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that tagged filters entities correctly
        /// </summary>
        /// <remarks>
        ///     Tests that Tagged only includes entities with the specified tag.
        /// </remarks>
        [Fact]
        public void Tagged_FiltersEntitiesCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject player = scene.Create(new Position { X = 1, Y = 1 });
            player.Tag<PlayerTag>();
            
            GameObject enemy = scene.Create(new Position { X = 2, Y = 2 });
            enemy.Tag<EnemyTag>();

            // Act
            Query query = scene.Query<With<Position>, Tagged<PlayerTag>>();
            int count = 0;
            foreach (RefTuple<Position> _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that multiple tagged filters work together
        /// </summary>
        /// <remarks>
        ///     Validates that multiple Tagged filters can be combined requiring all tags.
        /// </remarks>
        [Fact]
        public void MultipleTaggedFilters_WorkTogether()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 1 });
            entity1.Tag<PlayerTag>();
            entity1.Tag<TagComponent>();

            GameObject entity2 = scene.Create(new Position { X = 2, Y = 2 });
            entity2.Tag<PlayerTag>();

            // Act
            Query query = scene.Query<With<Position>, Tagged<PlayerTag>, Tagged<TagComponent>>();
            int count = 0;
            foreach (RefTuple<Position> _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that tagged with disable tag works
        /// </summary>
        /// <remarks>
        ///     Validates that Tagged can be used with the Disable tag.
        /// </remarks>
        [Fact]
        public void Tagged_WithDisableTag_Works()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject active = scene.Create(new Position { X = 1, Y = 1 });
            
            GameObject disabled = scene.Create(new Position { X = 2, Y = 2 });
            disabled.Tag<Disable>();

            // Act - Query specifically for disabled entities
            Query query = scene.Query<With<Position>, Tagged<Disable>>();
            int count = 0;
            foreach (RefTuple<Position> _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(0, count);
        }

        /// <summary>
        ///     Tests that tagged default instance has valid rule
        /// </summary>
        /// <remarks>
        ///     Validates that default Tagged instance produces a valid rule.
        /// </remarks>
        [Fact]
        public void Tagged_DefaultInstanceHasValidRule()
        {
            // Arrange
            Tagged<PlayerTag> tagged1 = default;
            Tagged<PlayerTag> tagged2 = new Tagged<PlayerTag>();

            // Act
            Rule rule1 = tagged1.Rule;
            Rule rule2 = tagged2.Rule;

            // Assert
            Assert.Equal(rule1, rule2);
        }

        /// <summary>
        ///     Tests that tagged for different types creates different rules
        /// </summary>
        /// <remarks>
        ///     Validates that Tagged for different tag types creates different rules.
        /// </remarks>
        [Fact]
        public void Tagged_ForDifferentTypes_CreatesDifferentRules()
        {
            // Arrange
            Tagged<PlayerTag> taggedPlayer = default;
            Tagged<EnemyTag> taggedEnemy = default;

            // Act
            Rule rulePlayer = taggedPlayer.Rule;
            Rule ruleEnemy = taggedEnemy.Rule;

            // Assert
            Assert.NotEqual(rulePlayer, ruleEnemy);
        }

        /// <summary>
        ///     Tests that tagged works with component queries
        /// </summary>
        /// <remarks>
        ///     Tests that Tagged can be combined with component queries.
        /// </remarks>
        [Fact]
        public void Tagged_WorksWithComponentQueries()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 1 }, new Velocity { VX = 1, VY = 1 });
            entity1.Tag<PlayerTag>();

            GameObject entity2 = scene.Create(new Position { X = 2, Y = 2 }, new Velocity { VX = 2, VY = 2 });

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, Tagged<PlayerTag>>();
            int count = 0;
            foreach (RefTuple<Position, Velocity> _ in query.Enumerate<Position, Velocity>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }
    }
}

