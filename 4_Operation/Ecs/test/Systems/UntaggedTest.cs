// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UntaggedTest.cs
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

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    ///     The untagged test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="Untagged{T}"/> struct which specifies that a query
    ///     should exclude entities that have a specific tag.
    /// </remarks>
    public class UntaggedTest
    {
        /// <summary>
        ///     Tests that untagged implements rule provider
        /// </summary>
        /// <remarks>
        ///     Verifies that Untagged implements IRuleProvider interface.
        /// </remarks>
        [Fact]
        public void Untagged_ImplementsRuleProvider()
        {
            // Arrange & Act
            Untagged<PlayerTag> untagged = default;

            // Assert
            Assert.IsAssignableFrom<IRuleProvider>(untagged);
        }

        /// <summary>
        ///     Tests that untagged rule returns lacks tag rule
        /// </summary>
        /// <remarks>
        ///     Validates that Untagged.Rule returns a rule for LacksTag.
        /// </remarks>
        [Fact]
        public void Untagged_RuleReturnsLacksTagRule()
        {
            // Arrange
            Untagged<PlayerTag> untagged = default;

            // Act
            Rule rule = untagged.Rule;

            // Assert
            Assert.NotEqual(default(Rule), rule);
        }

        /// <summary>
        ///     Tests that untagged can be used in query
        /// </summary>
        /// <remarks>
        ///     Validates that Untagged can be used in Scene.Query.
        /// </remarks>
        [Fact]
        public void Untagged_CanBeUsedInQuery()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 1 });

            // Act
            Query query = scene.Query<With<Position>, Untagged<PlayerTag>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that untagged filters entities correctly
        /// </summary>
        /// <remarks>
        ///     Tests that Untagged excludes entities with the specified tag.
        /// </remarks>
        [Fact]
        public void Untagged_FiltersEntitiesCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject player = scene.Create(new Position { X = 1, Y = 1 });
            player.Tag<PlayerTag>();
            
            GameObject noTag = scene.Create(new Position { X = 2, Y = 2 });

            // Act
            Query query = scene.Query<With<Position>, Untagged<PlayerTag>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that multiple untagged filters work together
        /// </summary>
        /// <remarks>
        ///     Validates that multiple Untagged filters can be combined.
        /// </remarks>
        [Fact]
        public void MultipleUntaggedFilters_WorkTogether()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 1 }); // No tags

            GameObject entity2 = scene.Create(new Position { X = 2, Y = 2 });
            entity2.Tag<PlayerTag>();

            GameObject entity3 = scene.Create(new Position { X = 3, Y = 3 });
            entity3.Tag<EnemyTag>();

            // Act - Untagged PlayerTag AND Untagged EnemyTag
            Query query = scene.Query<With<Position>, Untagged<PlayerTag>, Untagged<EnemyTag>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that untagged combined with tagged works
        /// </summary>
        /// <remarks>
        ///     Tests that Untagged can be combined with Tagged filters.
        /// </remarks>
        [Fact]
        public void Untagged_CombinedWithTagged_Works()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 1 });
            entity1.Tag<PlayerTag>();

            GameObject entity2 = scene.Create(new Position { X = 2, Y = 2 });
            entity2.Tag<PlayerTag>();
            entity2.Tag<EnemyTag>();

            // Act - Tagged PlayerTag but Untagged EnemyTag
            Query query = scene.Query<With<Position>, Tagged<PlayerTag>, Untagged<EnemyTag>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that untagged default instance has valid rule
        /// </summary>
        /// <remarks>
        ///     Validates that default Untagged instance produces a valid rule.
        /// </remarks>
        [Fact]
        public void Untagged_DefaultInstanceHasValidRule()
        {
            // Arrange
            Untagged<PlayerTag> untagged1 = default;
            Untagged<PlayerTag> untagged2 = new Untagged<PlayerTag>();

            // Act
            Rule rule1 = untagged1.Rule;
            Rule rule2 = untagged2.Rule;

            // Assert
            Assert.Equal(rule1, rule2);
        }

        /// <summary>
        ///     Tests that untagged for different types creates different rules
        /// </summary>
        /// <remarks>
        ///     Validates that Untagged for different tag types creates different rules.
        /// </remarks>
        [Fact]
        public void Untagged_ForDifferentTypes_CreatesDifferentRules()
        {
            // Arrange
            Untagged<PlayerTag> untaggedPlayer = default;
            Untagged<EnemyTag> untaggedEnemy = default;

            // Act
            Rule rulePlayer = untaggedPlayer.Rule;
            Rule ruleEnemy = untaggedEnemy.Rule;

            // Assert
            Assert.NotEqual(rulePlayer, ruleEnemy);
        }

        /// <summary>
        ///     Tests that untagged excludes disabled entities
        /// </summary>
        /// <remarks>
        ///     Tests that Untagged can filter out disabled entities.
        /// </remarks>
        [Fact]
        public void Untagged_ExcludesDisabledEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject active = scene.Create(new Position { X = 1, Y = 1 });
            
            GameObject disabled = scene.Create(new Position { X = 2, Y = 2 });
            disabled.Tag<Disable>();

            // Act - Query for entities untagged with Disable
            Query query = scene.Query<With<Position>, Untagged<Disable>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that untagged works with component filters
        /// </summary>
        /// <remarks>
        ///     Validates that Untagged can be combined with component filters.
        /// </remarks>
        [Fact]
        public void Untagged_WorksWithComponentFilters()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 1 }, new Velocity { VX = 1, VY = 1 });

            GameObject entity2 = scene.Create(new Position { X = 2, Y = 2 }, new Velocity { VX = 2, VY = 2 });
            entity2.Tag<PlayerTag>();

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, Untagged<PlayerTag>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }
    }
}

