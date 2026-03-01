// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IRuleProviderTest.cs
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
    ///     The i rule provider test class
    /// </summary>
    /// <remarks>
    ///     Tests the IRuleProvider interface that provides access to Rule instances.
    ///     This interface is used by query system components to expose their rule configurations.
    ///     Note: API consumers should not implement this interface directly.
    /// </remarks>
    public class IRuleProviderTest
    {
        /// <summary>
        ///     Tests that With implements IRuleProvider
        /// </summary>
        /// <remarks>
        ///     Validates that the With rule class implements IRuleProvider interface.
        /// </remarks>
        [Fact]
        public void IRuleProvider_WithImplementsInterface()
        {
            // Arrange
            With<Position> with = new With<Position>();

            // Act
            IRuleProvider provider = with;

            // Assert
            Assert.NotNull(provider);
            Assert.IsAssignableFrom<IRuleProvider>(with);
        }

        /// <summary>
        ///     Tests that Not implements IRuleProvider
        /// </summary>
        /// <remarks>
        ///     Validates that the Not rule class implements IRuleProvider interface.
        /// </remarks>
        [Fact]
        public void IRuleProvider_NotImplementsInterface()
        {
            // Arrange
            Not<Position> not = new Not<Position>();

            // Act
            IRuleProvider provider = not;

            // Assert
            Assert.NotNull(provider);
            Assert.IsAssignableFrom<IRuleProvider>(not);
        }

        /// <summary>
        ///     Tests that IRuleProvider.Rule property returns valid rule
        /// </summary>
        /// <remarks>
        ///     Validates that the Rule property returns a non-null Rule instance.
        /// </remarks>
        [Fact]
        public void IRuleProvider_RuleProperty_ReturnsValidRule()
        {
            // Arrange
            IRuleProvider provider = new With<Position>();

            // Act
            Rule rule = provider.Rule;

            // Assert
            Assert.NotNull(rule);
        }

        /// <summary>
        ///     Tests that different IRuleProvider implementations return different rules
        /// </summary>
        /// <remarks>
        ///     Validates that different implementations of IRuleProvider
        ///     provide distinct Rule instances.
        /// </remarks>
        [Fact]
        public void IRuleProvider_DifferentImplementations_ReturnDifferentRules()
        {
            // Arrange
            IRuleProvider withProvider = new With<Position>();
            IRuleProvider notProvider = new Not<Position>();

            // Act
            Rule withRule = withProvider.Rule;
            Rule notRule = notProvider.Rule;

            // Assert
            Assert.NotNull(withRule);
            Assert.NotNull(notRule);
            Assert.NotEqual(withRule, notRule);
        }

        /// <summary>
        ///     Tests that IRuleProvider can be used polymorphically
        /// </summary>
        /// <remarks>
        ///     Validates that IRuleProvider instances can be stored and used
        ///     polymorphically in collections.
        /// </remarks>
        [Fact]
        public void IRuleProvider_CanBeUsedPolymorphically()
        {
            // Arrange
            IRuleProvider[] providers = new IRuleProvider[]
            {
                new With<Position>(),
                new Not<Velocity>(),
                new With<Health>()
            };

            // Act & Assert
            foreach (IRuleProvider provider in providers)
            {
                Rule rule = provider.Rule;
                Assert.NotNull(rule);
            }
        }

        /// <summary>
        ///     Tests that IRuleProvider.Rule is consistent
        /// </summary>
        /// <remarks>
        ///     Validates that calling Rule property multiple times on the same
        ///     provider returns consistent results.
        /// </remarks>
        [Fact]
        public void IRuleProvider_RuleProperty_IsConsistent()
        {
            // Arrange
            IRuleProvider provider = new With<Position>();

            // Act
            Rule rule1 = provider.Rule;
            Rule rule2 = provider.Rule;

            // Assert
            Assert.Equal(rule1, rule2);
        }

        /// <summary>
        ///     Tests that Tagged implements IRuleProvider
        /// </summary>
        /// <remarks>
        ///     Validates that the Tagged rule class implements IRuleProvider interface.
        /// </remarks>
        [Fact]
        public void IRuleProvider_TaggedImplementsInterface()
        {
            // Arrange
            Tagged<Disable> tagged = new Tagged<Disable>();

            // Act
            IRuleProvider provider = tagged;

            // Assert
            Assert.NotNull(provider);
            Assert.IsAssignableFrom<IRuleProvider>(tagged);
        }

        /// <summary>
        ///     Tests that Untagged implements IRuleProvider
        /// </summary>
        /// <remarks>
        ///     Validates that the Untagged rule class implements IRuleProvider interface.
        /// </remarks>
        [Fact]
        public void IRuleProvider_UntaggedImplementsInterface()
        {
            // Arrange
            Untagged<Disable> untagged = new Untagged<Disable>();

            // Act
            IRuleProvider provider = untagged;

            // Assert
            Assert.NotNull(provider);
            Assert.IsAssignableFrom<IRuleProvider>(untagged);
        }

        /// <summary>
        ///     Tests that IRuleProvider can be used in generic constraints
        /// </summary>
        /// <remarks>
        ///     Validates that IRuleProvider can be used as a generic constraint
        ///     in method definitions.
        /// </remarks>
        [Fact]
        public void IRuleProvider_CanBeUsedAsGenericConstraint()
        {
            // Arrange
            With<Position> with = new With<Position>();

            // Act
            Rule rule = GetRuleFromProvider(with);

            // Assert
            Assert.NotNull(rule);
        }

        /// <summary>
        ///     Tests that multiple IRuleProviders can be collected
        /// </summary>
        /// <remarks>
        ///     Validates that IRuleProvider instances can be collected and
        ///     their rules extracted for query building.
        /// </remarks>
        [Fact]
        public void IRuleProvider_MultipleProviders_CanBeCollected()
        {
            // Arrange
            var providers = new System.Collections.Generic.List<IRuleProvider>
            {
                new With<Position>(),
                new With<Velocity>(),
                new Not<Disable>()
            };

            // Act
            var rules = new System.Collections.Generic.List<Rule>();
            foreach (IRuleProvider provider in providers)
            {
                rules.Add(provider.Rule);
            }

            // Assert
            Assert.Equal(3, rules.Count);
            foreach (Rule rule in rules)
            {
                Assert.NotNull(rule);
            }
        }

        /// <summary>
        ///     Tests that IRuleProvider works with different component types
        /// </summary>
        /// <remarks>
        ///     Validates that IRuleProvider can work with various component types.
        /// </remarks>
        [Fact]
        public void IRuleProvider_WorksWithDifferentComponentTypes()
        {
            // Arrange & Act
            IRuleProvider positionProvider = new With<Position>();
            IRuleProvider velocityProvider = new With<Velocity>();
            IRuleProvider healthProvider = new With<Health>();

            // Assert
            Assert.NotNull(positionProvider.Rule);
            Assert.NotNull(velocityProvider.Rule);
            Assert.NotNull(healthProvider.Rule);
        }

        /// <summary>
        ///     Tests that IRuleProvider interface is public
        /// </summary>
        /// <remarks>
        ///     Validates that IRuleProvider has public visibility.
        /// </remarks>
        [Fact]
        public void IRuleProvider_InterfaceIsPublic()
        {
            // Act
            System.Type type = typeof(IRuleProvider);

            // Assert
            Assert.True(type.IsPublic);
            Assert.True(type.IsInterface);
        }

        /// <summary>
        ///     Tests that IRuleProvider has only Rule property
        /// </summary>
        /// <remarks>
        ///     Validates that IRuleProvider interface defines only the expected
        ///     Rule property.
        /// </remarks>
        [Fact]
        public void IRuleProvider_HasOnlyRuleProperty()
        {
            // Act
            System.Type type = typeof(IRuleProvider);
            var properties = type.GetProperties();

            // Assert
            Assert.Single(properties);
            Assert.Equal("Rule", properties[0].Name);
        }

        /// <summary>
        ///     Tests that IRuleProvider Rule property is read-only
        /// </summary>
        /// <remarks>
        ///     Validates that the Rule property only has a getter, not a setter.
        /// </remarks>
        [Fact]
        public void IRuleProvider_RuleProperty_IsReadOnly()
        {
            // Act
            System.Type type = typeof(IRuleProvider);
            var property = type.GetProperty("Rule");

            // Assert
            Assert.NotNull(property);
            Assert.True(property.CanRead);
            Assert.False(property.CanWrite);
        }

        #region Helper Methods

        /// <summary>
        ///     Helper method to extract rule from provider with generic constraint
        /// </summary>
        private Rule GetRuleFromProvider<T>(T provider) where T : IRuleProvider
        {
            return provider.Rule;
        }

        #endregion
    }
}

