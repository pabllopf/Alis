// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryHashCoverageTest.cs
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
    ///     Coverage tests for <see cref="QueryHash" /> struct
    /// </summary>
    public class QueryHashCoverageTest
    {
        /// <summary>
        ///     Tests that New returns a QueryHash with the default initial state.
        /// </summary>
        [Fact]
        public void New_DefaultState()
        {
            QueryHash hash = QueryHash.New();

            int result = hash.ToHashCode();

            Assert.Equal(12582917, result);
        }

        /// <summary>
        ///     Tests that New with an empty array returns the default hash value.
        /// </summary>
        [Fact]
        public void New_EmptyArray_ReturnsDefaultHash()
        {
            FastImmutableArray<Rule> rules = FastImmutableArray<Rule>.Empty;

            QueryHash hash = QueryHash.New(rules);

            Assert.Equal(12582917, hash.ToHashCode());
        }

        /// <summary>
        ///     Tests that New with a single rule produces the correct hash.
        /// </summary>
        [Fact]
        public void New_SingleRule_ProducesCorrectHash()
        {
            FastImmutableArray<Rule>.Builder builder = FastImmutableArray<Rule>.CreateBuilder<Rule>(1);
            builder.Add(Rule.IncludeDisabledRule);
            FastImmutableArray<Rule> rules = builder.ToImmutable();

            QueryHash hash = QueryHash.New(rules);

            int expected = 12582917 * Rule.IncludeDisabledRule.GetHashCode();
            Assert.Equal(expected, hash.ToHashCode());
        }

        /// <summary>
        ///     Tests that New with multiple rules produces the correct combined hash.
        /// </summary>
        [Fact]
        public void New_MultipleRules_ProducesCorrectCombinedHash()
        {
            Rule rule1 = Rule.HasComponent(new ComponentId(1));
            Rule rule2 = Rule.HasComponent(new ComponentId(2));
            FastImmutableArray<Rule>.Builder builder = FastImmutableArray<Rule>.CreateBuilder<Rule>(2);
            builder.Add(rule1);
            builder.Add(rule2);
            FastImmutableArray<Rule> rules = builder.ToImmutable();

            QueryHash hash = QueryHash.New(rules);

            int expected = 12582917 * rule1.GetHashCode() * rule2.GetHashCode();
            Assert.Equal(expected, hash.ToHashCode());
        }

        /// <summary>
        ///     Tests that AddRule modifies the internal state.
        /// </summary>
        [Fact]
        public void AddRule_ModifiesState()
        {
            QueryHash hash = QueryHash.New();

            hash.AddRule(Rule.IncludeDisabledRule);

            Assert.NotEqual(12582917, hash.ToHashCode());
        }

        /// <summary>
        ///     Tests that AddRule returns the same instance for method chaining.
        /// </summary>
        [Fact]
        public void AddRule_ReturnsSameInstance_ForChaining()
        {
            QueryHash hash = QueryHash.New();

            QueryHash result = hash.AddRule(Rule.IncludeDisabledRule);

            Assert.Equal(hash.ToHashCode(), result.ToHashCode());
        }

        /// <summary>
        ///     Tests that AddRule supports fluent chaining.
        /// </summary>
        [Fact]
        public void AddRule_SupportsChaining()
        {
            Rule rule1 = Rule.HasComponent(new ComponentId(1));
            Rule rule2 = Rule.HasComponent(new ComponentId(2));

            QueryHash result = QueryHash.New()
                .AddRule(rule1)
                .AddRule(rule2);

            int expected = 12582917 * rule1.GetHashCode() * rule2.GetHashCode();
            Assert.Equal(expected, result.ToHashCode());
        }

        /// <summary>
        ///     Tests that ToHashCode returns the current accumulated state.
        /// </summary>
        [Fact]
        public void ToHashCode_ReturnsAccumulatedState()
        {
            QueryHash hash = QueryHash.New();
            Rule rule = Rule.IncludeDisabledRule;

            hash.AddRule(rule);

            int result = hash.ToHashCode();
            int expected = 12582917 * rule.GetHashCode();
            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Tests that a default struct instance has state 0, different from New().
        /// </summary>
        [Fact]
        public void DefaultStruct_StateIsZero_DifferentFromNew()
        {
            QueryHash defaultHash = default;
            QueryHash newHash = QueryHash.New();

            Assert.Equal(0, defaultHash.ToHashCode());
            Assert.NotEqual(defaultHash.ToHashCode(), newHash.ToHashCode());
        }

        /// <summary>
        ///     Tests that New with the same rules produces identical hash codes.
        /// </summary>
        [Fact]
        public void SameRules_ProduceSameHash()
        {
            Rule rule1 = Rule.HasComponent(new ComponentId(1));
            Rule rule2 = Rule.HasComponent(new ComponentId(2));
            FastImmutableArray<Rule>.Builder builder1 = FastImmutableArray<Rule>.CreateBuilder<Rule>(2);
            builder1.Add(rule1);
            builder1.Add(rule2);
            FastImmutableArray<Rule>.Builder builder2 = FastImmutableArray<Rule>.CreateBuilder<Rule>(2);
            builder2.Add(rule1);
            builder2.Add(rule2);

            QueryHash hash1 = QueryHash.New(builder1.ToImmutable());
            QueryHash hash2 = QueryHash.New(builder2.ToImmutable());

            Assert.Equal(hash1.ToHashCode(), hash2.ToHashCode());
        }

        /// <summary>
        ///     Tests that adding the same rule via New and via AddRule produces the same hash.
        /// </summary>
        [Fact]
        public void NewWithRules_Equals_ManualAddRule()
        {
            Rule rule = Rule.IncludeDisabledRule;
            FastImmutableArray<Rule>.Builder builder = FastImmutableArray<Rule>.CreateBuilder<Rule>(1);
            builder.Add(rule);
            FastImmutableArray<Rule> rules = builder.ToImmutable();

            QueryHash fromNew = QueryHash.New(rules);
            QueryHash manual = QueryHash.New().AddRule(rule);

            Assert.Equal(fromNew.ToHashCode(), manual.ToHashCode());
        }
    }
}
