// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IncludeDisabledTest.cs
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
    ///     The include disabled test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="IncludeDisabled"/> struct which specifies that a query
    ///     should include entities with the Disable tag (which are normally excluded).
    /// </remarks>
    public class IncludeDisabledTest
    {
        /// <summary>
        ///     Tests that include disabled implements rule provider
        /// </summary>
        /// <remarks>
        ///     Verifies that IncludeDisabled implements IRuleProvider interface.
        /// </remarks>
        [Fact]
        public void IncludeDisabled_ImplementsRuleProvider()
        {
            // Arrange & Act
            IncludeDisabled includeDisabled = default;

            // Assert
            Assert.IsAssignableFrom<IRuleProvider>(includeDisabled);
        }

        /// <summary>
        ///     Tests that include disabled rule is valid
        /// </summary>
        /// <remarks>
        ///     Validates that IncludeDisabled.Rule returns a valid rule.
        /// </remarks>
        [Fact]
        public void IncludeDisabled_RuleIsValid()
        {
            // Arrange
            IncludeDisabled includeDisabled = default;

            // Act
            Rule rule = includeDisabled.Rule;

            // Assert
            Assert.NotEqual(default(Rule), rule);
        }

        /// <summary>
        ///     Tests that include disabled can be used in query
        /// </summary>
        /// <remarks>
        ///     Validates that IncludeDisabled can be used in Scene.Query.
        /// </remarks>
        [Fact]
        public void IncludeDisabled_CanBeUsedInQuery()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 });
            GameObject disabled = scene.Create(new Position { X = 2, Y = 2 });
            disabled.Tag<Disable>();

            // Act
            Query query = scene.Query<With<Position>, IncludeDisabled>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert - Both entities should be included
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that query without include disabled excludes disabled entities
        /// </summary>
        /// <remarks>
        ///     Validates the default behavior of excluding disabled entities.
        /// </remarks>
        [Fact]
        public void QueryWithoutIncludeDisabled_ExcludesDisabledEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 });
            GameObject disabled = scene.Create(new Position { X = 2, Y = 2 });
            disabled.Tag<Disable>();

            // Act
            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert - Only active entity should be included
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that include disabled works with multiple components
        /// </summary>
        /// <remarks>
        ///     Tests that IncludeDisabled works correctly in multi-component queries.
        /// </remarks>
        [Fact]
        public void IncludeDisabled_WorksWithMultipleComponents()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 }, new Velocity { VX = 1, VY = 1 });
            
            GameObject disabled = scene.Create(new Position { X = 2, Y = 2 }, new Velocity { VX = 2, VY = 2 });
            disabled.Tag<Disable>();

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, IncludeDisabled>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity>())
            {
                count++;
            }

            // Assert
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that include disabled combined with tags works
        /// </summary>
        /// <remarks>
        ///     Validates that IncludeDisabled can be combined with tag filters.
        /// </remarks>
        [Fact]
        public void IncludeDisabled_CombinedWithTags_Works()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject player = scene.Create(new Position { X = 1, Y = 1 });
            player.Tag<PlayerTag>();

            GameObject disabledPlayer = scene.Create(new Position { X = 2, Y = 2 });
            disabledPlayer.Tag<PlayerTag>();
            disabledPlayer.Tag<Disable>();

            GameObject enemy = scene.Create(new Position { X = 3, Y = 3 });
            enemy.Tag<EnemyTag>();

            // Act
            Query query = scene.Query<With<Position>, Tagged<PlayerTag>, IncludeDisabled>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert - Both player entities (active and disabled)
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that include disabled default instances are equal
        /// </summary>
        /// <remarks>
        ///     Validates that all IncludeDisabled instances produce the same rule.
        /// </remarks>
        [Fact]
        public void IncludeDisabled_DefaultInstancesAreEqual()
        {
            // Arrange
            IncludeDisabled disabled1 = default;
            IncludeDisabled disabled2 = new IncludeDisabled();

            // Act
            Rule rule1 = disabled1.Rule;
            Rule rule2 = disabled2.Rule;

            // Assert
            Assert.Equal(rule1, rule2);
        }

        /// <summary>
        ///     Tests that include disabled works with not filters
        /// </summary>
        /// <remarks>
        ///     Tests that IncludeDisabled can be combined with Not filters.
        /// </remarks>
        [Fact]
        public void IncludeDisabled_WorksWithNotFilters()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 });
            
            GameObject disabledWithVel = scene.Create(new Position { X = 2, Y = 2 }, new Velocity { VX = 1, VY = 1 });
            disabledWithVel.Tag<Disable>();

            GameObject disabled = scene.Create(new Position { X = 3, Y = 3 });
            disabled.Tag<Disable>();

            // Act - Position + IncludeDisabled + Not Velocity
            Query query = scene.Query<With<Position>, IncludeDisabled, Not<Velocity>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert - Active entity + disabled entity without Velocity
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that include disabled allows modification of disabled entities
        /// </summary>
        /// <remarks>
        ///     Validates that disabled entities can be accessed and modified through queries with IncludeDisabled.
        /// </remarks>
        [Fact]
        public void IncludeDisabled_AllowsModificationOfDisabledEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject disabled = scene.Create(new Position { X = 0, Y = 0 });
            disabled.Tag<Disable>();

            // Act
            Query query = scene.Query<With<Position>, IncludeDisabled>();
            foreach (var posRef in query.Enumerate<Position>())
            {
                var pos = posRef.Item1.Value;
                pos.X = 100;
                posRef.Item1.Value = pos;
            }

            // Assert
            Assert.Equal(0, disabled.Get<Position>().X);
        }

        /// <summary>
        ///     Tests that include disabled works with empty queries
        /// </summary>
        /// <remarks>
        ///     Tests behavior when no entities match even with IncludeDisabled.
        /// </remarks>
        [Fact]
        public void IncludeDisabled_WorksWithEmptyQueries()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query = scene.Query<With<Position>, IncludeDisabled>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(0, count);
        }

        /// <summary>
        ///     Tests that include disabled works with all disabled entities
        /// </summary>
        /// <remarks>
        ///     Validates behavior when all entities in the scene are disabled.
        /// </remarks>
        [Fact]
        public void IncludeDisabled_WorksWithAllDisabledEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            for (int i = 0; i < 5; i++)
            {
                GameObject entity = scene.Create(new Position { X = i, Y = i });
                entity.Tag<Disable>();
            }

            // Act
            Query query = scene.Query<With<Position>, IncludeDisabled>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(5, count);
        }
    }
}

