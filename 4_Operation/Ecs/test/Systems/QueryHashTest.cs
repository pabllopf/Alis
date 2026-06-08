// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryHashTest.cs
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

using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    ///     The query hash test class
    /// </summary>
    public class QueryHashTest
    {
        /// <summary>
        ///     Tests that new creates a query hash with default state
        /// </summary>
        [Fact]
        public void ShouldCreateDefaultQueryHashWhenNewCalled()
        {
            QueryHash hash = QueryHash.New();

            int result = hash.ToHashCode();

            Assert.Equal(12582917, result);
        }

        /// <summary>
        ///     Tests that add rule changes hash code
        /// </summary>
        [Fact]
        public void ShouldChangeHashCodeWhenRuleAdded()
        {
            QueryHash hash = QueryHash.New();
            Rule rule = Rule.HasComponent(new ComponentId(1));

            QueryHash result = hash.AddRule(rule);

            Assert.NotEqual(12582917, result.ToHashCode());
        }

        /// <summary>
        ///     Tests that add rule returns same instance for chaining
        /// </summary>
        [Fact]
        public void ShouldReturnSameInstanceWhenRuleAddedForChaining()
        {
            QueryHash hash = QueryHash.New();
            Rule rule = Rule.HasComponent(new ComponentId(1));

            QueryHash result = hash.AddRule(rule);

            Assert.Equal(hash.ToHashCode(), result.ToHashCode());
        }

        /// <summary>
        ///     Tests that multiple rules produce different hash than single rule
        /// </summary>
        [Fact]
        public void ShouldProduceDifferentHashCodeWhenMultipleRulesAdded()
        {
            QueryHash hash1 = QueryHash.New();
            QueryHash hash2 = QueryHash.New();
            Rule rule1 = Rule.HasComponent(new ComponentId(1));
            Rule rule2 = Rule.HasComponent(new ComponentId(2));

            hash1.AddRule(rule1);
            hash2.AddRule(rule1);
            hash2.AddRule(rule2);

            Assert.NotEqual(hash1.ToHashCode(), hash2.ToHashCode());
        }

        /// <summary>
        ///     Tests that same rules produce same hash code
        /// </summary>
        [Fact]
        public void ShouldProduceSameHashCodeWhenSameRulesAdded()
        {
            QueryHash hash1 = QueryHash.New();
            QueryHash hash2 = QueryHash.New();
            Rule rule = Rule.HasComponent(new ComponentId(1));

            hash1.AddRule(rule);
            hash2.AddRule(rule);

            Assert.Equal(hash1.ToHashCode(), hash2.ToHashCode());
        }

        /// <summary>
        ///     Tests that new with rules array creates correct hash
        /// </summary>
        [Fact]
        public void ShouldCreateCorrectHashWhenNewWithRulesCalled()
        {
            Rule rule1 = Rule.HasComponent(new ComponentId(1));
            Rule rule2 = Rule.HasComponent(new ComponentId(2));
            FastImmutableArray<Rule>.Builder builder = FastImmutableArray<Rule>.CreateBuilder<Rule>(2);
            builder.Add(rule1);
            builder.Add(rule2);
            FastImmutableArray<Rule> rules = builder.ToImmutable();

            QueryHash hash = QueryHash.New(rules);

            Assert.NotEqual(12582917, hash.ToHashCode());
        }

        /// <summary>
        ///     Tests that new with empty rules returns default hash
        /// </summary>
        [Fact]
        public void ShouldReturnDefaultHashWhenNewWithEmptyRulesCalled()
        {
            FastImmutableArray<Rule> rules = FastImmutableArray<Rule>.Empty;

            QueryHash hash = QueryHash.New(rules);

            Assert.Equal(12582917, hash.ToHashCode());
        }

        /// <summary>
        ///     Tests that include disabled rule produces valid hash
        /// </summary>
        [Fact]
        public void ShouldProduceValidHashCodeWhenIncludeDisabledRuleUsed()
        {
            QueryHash hash = QueryHash.New();

            hash.AddRule(Rule.IncludeDisabledRule);

            Assert.NotEqual(0, hash.ToHashCode());
        }
    }
}
