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
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    ///     The query hash test class
    /// </summary>
    /// <remarks>
    ///     Tests the QueryHash struct that provides hash code generation for queries.
    ///     This is critical for query caching and performance optimization in the ECS.
    /// </remarks>
    public class QueryHashTest
    {
        /// <summary>
        ///     Tests that QueryHash can be created with default constructor
        /// </summary>
        /// <remarks>
        ///     Validates that QueryHash can be instantiated using default constructor.
        /// </remarks>
        [Fact]
        public void QueryHash_CanBeCreatedWithDefaultConstructor()
        {
            // Act
            QueryHash hash = new QueryHash();

            // Assert
            Assert.NotEqual(0, hash.ToHashCode());
        }

        /// <summary>
        ///     Tests that QueryHash.New() creates a new instance
        /// </summary>
        /// <remarks>
        ///     Validates that the static New() method creates a valid QueryHash instance.
        /// </remarks>
        [Fact]
        public void QueryHash_NewMethod_CreatesInstance()
        {
            // Act
            QueryHash hash = QueryHash.New();

            // Assert
            Assert.NotEqual(0, hash.ToHashCode());
        }

        /// <summary>
        ///     Tests that two new QueryHash instances have the same initial hash
        /// </summary>
        /// <remarks>
        ///     Validates that QueryHash instances start with the same initial state.
        /// </remarks>
        [Fact]
        public void QueryHash_TwoNewInstances_HaveSameInitialHash()
        {
            // Arrange & Act
            QueryHash hash1 = QueryHash.New();
            QueryHash hash2 = QueryHash.New();

            // Assert
            Assert.Equal(hash1.ToHashCode(), hash2.ToHashCode());
        }

        /// <summary>
        ///     Tests that QueryHash default value has valid hash
        /// </summary>
        /// <remarks>
        ///     Validates that default(QueryHash) produces a valid hash code.
        /// </remarks>
        [Fact]
        public void QueryHash_DefaultValue_HasValidHash()
        {
            // Arrange & Act
            QueryHash defaultHash = default;

            // Assert
            Assert.Equal(0, defaultHash.ToHashCode());
        }
    }
}

