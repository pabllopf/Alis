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

using System.Runtime.InteropServices;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    ///     Tests for <see cref="With{T}" />, <see cref="Not{T}" />, and <see cref="IncludeDisabled" /> IRuleProvider implementations.
    /// </summary>
    public class IRuleProviderTest
    {
        /// <summary>
        ///     Tests that With returns HasComponent rule
        /// </summary>
        [Fact]
        public void With_ReturnsHasComponentRule()
        {
            With<Position> with = default;
            Rule rule = with.Rule;

            Assert.NotEqual(default(Rule), rule);
        }

        /// <summary>
        ///     Tests that Not returns NotComponent rule
        /// </summary>
        [Fact]
        public void Not_ReturnsNotComponentRule()
        {
            Not<Position> not = default;
            Rule rule = not.Rule;

            Assert.NotEqual(default(Rule), rule);
        }

        /// <summary>
        ///     Tests that IncludeDisabled returns IncludeDisabledRule
        /// </summary>
        [Fact]
        public void IncludeDisabled_ReturnsIncludeDisabledRule()
        {
            IncludeDisabled includeDisabled = default;
            Rule rule = includeDisabled.Rule;

            Assert.Equal(Rule.IncludeDisabledRule, rule);
        }

        /// <summary>
        ///     Tests that With and Not with same type produce different rules
        /// </summary>
        [Fact]
        public void WithAndNot_SameType_ProduceDifferentRules()
        {
            With<Position> with = default;
            Not<Position> not = default;

            Assert.NotEqual(with.Rule, not.Rule);
        }

        /// <summary>
        ///     Tests that With struct has sequential layout
        /// </summary>
        [Fact]
        public void With_HasSequentialLayout()
        {
            StructLayoutAttribute layout = typeof(With<Position>).StructLayoutAttribute;

            Assert.Equal(LayoutKind.Sequential, layout.Value);
        }

        /// <summary>
        ///     Tests that Not struct has sequential layout
        /// </summary>
        [Fact]
        public void Not_HasSequentialLayout()
        {
            StructLayoutAttribute layout = typeof(Not<Position>).StructLayoutAttribute;

            Assert.Equal(LayoutKind.Sequential, layout.Value);
        }

        /// <summary>
        ///     Tests that IncludeDisabled struct has sequential layout
        /// </summary>
        [Fact]
        public void IncludeDisabled_HasSequentialLayout()
        {
            StructLayoutAttribute layout = typeof(IncludeDisabled).StructLayoutAttribute;

            Assert.Equal(LayoutKind.Sequential, layout.Value);
        }

        /// <summary>
        ///     Tests that With struct is value type
        /// </summary>
        [Fact]
        public void With_IsValueType()
        {
            Assert.True(typeof(With<Position>).IsValueType);
        }

        /// <summary>
        ///     Tests that Not struct is value type
        /// </summary>
        [Fact]
        public void Not_IsValueType()
        {
            Assert.True(typeof(Not<Position>).IsValueType);
        }

        /// <summary>
        ///     Tests that IncludeDisabled struct is value type
        /// </summary>
        [Fact]
        public void IncludeDisabled_IsValueType()
        {
            Assert.True(typeof(IncludeDisabled).IsValueType);
        }

        /// <summary>
        ///     Tests that With implements IRuleProvider
        /// </summary>
        [Fact]
        public void With_ImplementsIRuleProvider()
        {
            Assert.True(typeof(IRuleProvider).IsAssignableFrom(typeof(With<Position>)));
        }

        /// <summary>
        ///     Tests that Not implements IRuleProvider
        /// </summary>
        [Fact]
        public void Not_ImplementsIRuleProvider()
        {
            Assert.True(typeof(IRuleProvider).IsAssignableFrom(typeof(Not<Position>)));
        }

        /// <summary>
        ///     Tests that IncludeDisabled implements IRuleProvider
        /// </summary>
        [Fact]
        public void IncludeDisabled_ImplementsIRuleProvider()
        {
            Assert.True(typeof(IRuleProvider).IsAssignableFrom(typeof(IncludeDisabled)));
        }

        /// <summary>
        ///     Tests that With with different types produce different rules
        /// </summary>
        [Fact]
        public void With_DifferentTypes_ProduceDifferentRules()
        {
            With<Position> withPos = default;
            With<Velocity> withVel = default;

            Assert.NotEqual(withPos.Rule, withVel.Rule);
        }

        /// <summary>
        ///     Tests that Not with different types produce different rules
        /// </summary>
        [Fact]
        public void Not_DifferentTypes_ProduceDifferentRules()
        {
            Not<Position> notPos = default;
            Not<Velocity> notVel = default;

            Assert.NotEqual(notPos.Rule, notVel.Rule);
        }

        /// <summary>
        ///     Tests that RuleTypes enum has expected values
        /// </summary>
        [Fact]
        public void RuleTypes_HasExpectedValues()
        {
            Assert.Equal(0, (int)RuleTypes.Have);
            Assert.Equal(1, (int)RuleTypes.DoesNotHave);
        }
    }
}
