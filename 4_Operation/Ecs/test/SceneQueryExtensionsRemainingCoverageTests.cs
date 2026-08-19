// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneQueryExtensionsRemainingCoverageTests.cs
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

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Remaining coverage tests for <see cref="SceneQueryExtensions"/> extension methods.
    /// </summary>
    public class SceneQueryExtensionsRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that Query&lt;T&gt; with a single rule returns a non-null query.
        /// </summary>
        [Fact]
        public void Query_SingleRule_ReturnsNonNullQuery()
        {
            using (Scene scene = new Scene())
            {
                Query result = scene.Query<With<Position>>();

                Assert.NotNull(result);
            }
        }

        /// <summary>
        ///     Tests that Query&lt;T1, T2&gt; with two rules returns a non-null query.
        /// </summary>
        [Fact]
        public void Query_TwoRules_ReturnsNonNullQuery()
        {
            using (Scene scene = new Scene())
            {
                Query result = scene.Query<With<Position>, With<Velocity>>();

                Assert.NotNull(result);
            }
        }

        /// <summary>
        ///     Tests that Query&lt;T1, T2, T3&gt; with three rules returns a non-null query.
        /// </summary>
        [Fact]
        public void Query_ThreeRules_ReturnsNonNullQuery()
        {
            using (Scene scene = new Scene())
            {
                Query result = scene.Query<With<Position>, With<Velocity>, With<Health>>();

                Assert.NotNull(result);
            }
        }

        /// <summary>
        ///     Tests that query caching returns the same instance for the same type combination.
        /// </summary>
        [Fact]
        public void Query_Cached_ReturnsSameInstance()
        {
            using (Scene scene = new Scene())
            {
                Query first = scene.Query<With<Position>>();
                Query second = scene.Query<With<Position>>();

                Assert.Same(first, second);
            }
        }

        /// <summary>
        ///     Tests that Query with <see cref="IncludeDisabled"/> returns a non-null query.
        /// </summary>
        [Fact]
        public void Query_IncludeDisabled_ReturnsNonNullQuery()
        {
            using (Scene scene = new Scene())
            {
                Query result = scene.Query<IncludeDisabled>();

                Assert.NotNull(result);
            }
        }

        /// <summary>
        ///     Tests that Query with <see cref="Not{T}"/> rule returns a non-null query.
        /// </summary>
        [Fact]
        public void Query_NotRule_ReturnsNonNullQuery()
        {
            using (Scene scene = new Scene())
            {
                Query result = scene.Query<Not<Position>>();

                Assert.NotNull(result);
            }
        }

        /// <summary>
        ///     Tests that Query with mixed <see cref="With{T}"/>, <see cref="Not{T}"/>, and <see cref="IncludeDisabled"/> rules returns a non-null query.
        /// </summary>
        [Fact]
        public void Query_MixedRules_ReturnsNonNullQuery()
        {
            using (Scene scene = new Scene())
            {
                Query result = scene.Query<With<Position>, Not<Velocity>, IncludeDisabled>();

                Assert.NotNull(result);
            }
        }

        /// <summary>
        ///     Tests that queries with different type combinations are cached independently.
        /// </summary>
        [Fact]
        public void Query_DifferentTypeCombinations_AreCachedIndependently()
        {
            using (Scene scene = new Scene())
            {
                Query single = scene.Query<With<Position>>();
                Query pair = scene.Query<With<Position>, With<Velocity>>();

                Assert.NotSame(single, pair);
            }
        }

        /// <summary>
        ///     Tests that Query with eight rules (maximum arity) returns a non-null query.
        /// </summary>
        [Fact]
        public void Query_EightRules_ReturnsNonNullQuery()
        {
            using (Scene scene = new Scene())
            {
                Query result = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<EnemyTag>, With<PlayerTag>, With<TagComponent>>();

                Assert.NotNull(result);
            }
        }

        /// <summary>
        ///     Tests that Query with two rules caches the query instance.
        /// </summary>
        [Fact]
        public void Query_TwoRules_CachesQueryInstance()
        {
            using (Scene scene = new Scene())
            {
                Query first = scene.Query<With<Position>, With<Velocity>>();
                Query second = scene.Query<With<Position>, With<Velocity>>();

                Assert.Same(first, second);
            }
        }

        /// <summary>
        ///     Tests that Query with three rules caches the query instance.
        /// </summary>
        [Fact]
        public void Query_ThreeRules_CachesQueryInstance()
        {
            using (Scene scene = new Scene())
            {
                Query first = scene.Query<With<Position>, With<Velocity>, With<Health>>();
                Query second = scene.Query<With<Position>, With<Velocity>, With<Health>>();

                Assert.Same(first, second);
            }
        }

        /// <summary>
        ///     Tests that Query with four rules caches the query instance.
        /// </summary>
        [Fact]
        public void Query_FourRules_CachesQueryInstance()
        {
            using (Scene scene = new Scene())
            {
                Query first = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>>();
                Query second = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>>();

                Assert.Same(first, second);
            }
        }

        /// <summary>
        ///     Tests that Query with five rules caches the query instance.
        /// </summary>
        [Fact]
        public void Query_FiveRules_CachesQueryInstance()
        {
            using (Scene scene = new Scene())
            {
                Query first = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>>();
                Query second = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>>();

                Assert.Same(first, second);
            }
        }

        /// <summary>
        ///     Tests that Query with six rules caches the query instance.
        /// </summary>
        [Fact]
        public void Query_SixRules_CachesQueryInstance()
        {
            using (Scene scene = new Scene())
            {
                Query first = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<EnemyTag>>();
                Query second = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<EnemyTag>>();

                Assert.Same(first, second);
            }
        }

        /// <summary>
        ///     Tests that Query with seven rules caches the query instance.
        /// </summary>
        [Fact]
        public void Query_SevenRules_CachesQueryInstance()
        {
            using (Scene scene = new Scene())
            {
                Query first = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<EnemyTag>, With<PlayerTag>>();
                Query second = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<EnemyTag>, With<PlayerTag>>();

                Assert.Same(first, second);
            }
        }

        /// <summary>
        ///     Tests that Query with eight rules caches the query instance.
        /// </summary>
        [Fact]
        public void Query_EightRules_CachesQueryInstance()
        {
            using (Scene scene = new Scene())
            {
                Query first = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<EnemyTag>, With<PlayerTag>, With<TagComponent>>();
                Query second = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<EnemyTag>, With<PlayerTag>, With<TagComponent>>();

                Assert.Same(first, second);
            }
        }
    }
}
