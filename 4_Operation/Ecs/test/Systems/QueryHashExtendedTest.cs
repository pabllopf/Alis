// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryHashExtendedTest.cs
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

using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    ///     Extended tests for <see cref="QueryHash" /> struct
    /// </summary>
    public class QueryHashExtendedTest
    {
        /// <summary>
        ///     Tests that query hash struct is value type
        /// </summary>
        [Fact]
        public void QueryHash_IsValueType()
        {
            Type type = typeof(QueryHash);

            Assert.True(type.IsValueType);
        }

        /// <summary>
        ///     Tests that query hash has sequential struct layout
        /// </summary>
        [Fact]
        public void QueryHash_HasSequentialStructLayout()
        {
            StructLayoutAttribute layout = typeof(QueryHash).StructLayoutAttribute;

            Assert.Equal(LayoutKind.Sequential, layout.Value);
        }

        /// <summary>
        ///     Tests that new creates query hash with default state
        /// </summary>
        [Fact]
        public void New_CreatesQueryHashWithDefaultState()
        {
            QueryHash hash = QueryHash.New();

            Assert.Equal(12582917, hash.ToHashCode());
        }

        /// <summary>
        ///     Tests that add rule with has component changes hash
        /// </summary>
        [Fact]
        public void AddRule_WithHasComponent_ChangesHash()
        {
            QueryHash hash = QueryHash.New();
            Rule rule = Rule.HasComponent(Component<Position>.Id);

            QueryHash result = hash.AddRule(rule);

            Assert.NotEqual(12582917, result.ToHashCode());
        }

        /// <summary>
        ///     Tests that add rule with not component changes hash
        /// </summary>
        [Fact]
        public void AddRule_WithNotComponent_ChangesHash()
        {
            QueryHash hash = QueryHash.New();
            Rule rule = Rule.NotComponent(Component<Position>.Id);

            QueryHash result = hash.AddRule(rule);

            Assert.NotEqual(12582917, result.ToHashCode());
        }

        /// <summary>
        ///     Tests that different rules produce different hashes
        /// </summary>
        [Fact]
        public void DifferentRules_ProduceDifferentHashes()
        {
            QueryHash hash1 = QueryHash.New();
            QueryHash hash2 = QueryHash.New();

            hash1.AddRule(Rule.HasComponent(Component<Position>.Id));
            hash2.AddRule(Rule.HasComponent(Component<Velocity>.Id));

            Assert.NotEqual(hash1.ToHashCode(), hash2.ToHashCode());
        }

        /// <summary>
        ///     Tests that same rules in same order produce same hash
        /// </summary>
        [Fact]
        public void SameRulesInSameOrder_ProduceSameHash()
        {
            QueryHash hash1 = QueryHash.New();
            QueryHash hash2 = QueryHash.New();

            hash1.AddRule(Rule.HasComponent(Component<Position>.Id));
            hash1.AddRule(Rule.HasComponent(Component<Velocity>.Id));

            hash2.AddRule(Rule.HasComponent(Component<Position>.Id));
            hash2.AddRule(Rule.HasComponent(Component<Velocity>.Id));

            Assert.Equal(hash1.ToHashCode(), hash2.ToHashCode());
        }

        /// <summary>
        ///     Tests that rules with different component counts produce different hash
        /// </summary>
        [Fact]
        public void DifferentComponentCounts_ProduceDifferentHash()
        {
            QueryHash hash1 = QueryHash.New();
            QueryHash hash2 = QueryHash.New();

            hash1.AddRule(Rule.HasComponent(Component<Position>.Id));

            hash2.AddRule(Rule.HasComponent(Component<Position>.Id));
            hash2.AddRule(Rule.HasComponent(Component<Velocity>.Id));

            Assert.NotEqual(hash1.ToHashCode(), hash2.ToHashCode());
        }

        /// <summary>
        ///     Tests that new with empty rules returns default hash
        /// </summary>
        [Fact]
        public void NewWithEmptyRules_ReturnsDefaultHash()
        {
            FastImmutableArray<Rule> rules = FastImmutableArray<Rule>.Empty;

            QueryHash hash = QueryHash.New(rules);

            Assert.Equal(12582917, hash.ToHashCode());
        }

        /// <summary>
        ///     Tests that default query hash is not equal to new query hash
        /// </summary>
        [Fact]
        public void DefaultQueryHash_IsNotEqualToNewQueryHash()
        {
            QueryHash defaultHash = default(QueryHash);
            QueryHash newHash = QueryHash.New();

            Assert.NotEqual(defaultHash.ToHashCode(), newHash.ToHashCode());
        }

        /// <summary>
        ///     Tests that add rule can be chained
        /// </summary>
        [Fact]
        public void AddRule_CanBeChained()
        {
            QueryHash hash = QueryHash.New();

            QueryHash result = hash
                .AddRule(Rule.HasComponent(Component<Position>.Id))
                .AddRule(Rule.HasComponent(Component<Velocity>.Id));

            Assert.NotEqual(12582917, result.ToHashCode());
        }

        /// <summary>
        ///     Tests that query hash can be copied
        /// </summary>
        [Fact]
        public void QueryHash_CanBeCopied()
        {
            QueryHash original = QueryHash.New();
            original.AddRule(Rule.HasComponent(Component<Position>.Id));

            QueryHash copy = original;

            Assert.Equal(original.ToHashCode(), copy.ToHashCode());
        }

        /// <summary>
        ///     Tests that include disabled rule produces consistent hash
        /// </summary>
        [Fact]
        public void IncludeDisabledRule_ProducesConsistentHash()
        {
            QueryHash hash1 = QueryHash.New();
            QueryHash hash2 = QueryHash.New();

            hash1.AddRule(Rule.IncludeDisabledRule);
            hash2.AddRule(Rule.IncludeDisabledRule);

            Assert.Equal(hash1.ToHashCode(), hash2.ToHashCode());
        }
    }
}
