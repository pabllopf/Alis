// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeEdgeKeyTest.cs
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
using Alis.Core.Ecs.Kernel.Archetypes;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Archetypes
{
    /// <summary>
    ///     The archetype edge key test class
    /// </summary>
    public class ArchetypeEdgeKeyTest
    {
        /// <summary>
        ///     Tests that component factory method creates valid key
        /// </summary>
        [Fact]
        public void ShouldCreateValidKeyWhenComponentFactoryCalled()
        {
            ComponentId componentId = new ComponentId(1);
            GameObjectType from = new GameObjectType(10);
            ArchetypeEdgeType edgeType = ArchetypeEdgeType.AddComponent;

            ArchetypeEdgeKey key = ArchetypeEdgeKey.Component(componentId, from, edgeType);

            Assert.Equal(componentId, key.ComponentID);
            Assert.Equal(from, key.ArchetypeFrom);
            Assert.Equal(edgeType, key.EdgeType);
        }

        /// <summary>
        ///     Tests that equal keys are considered equal
        /// </summary>
        [Fact]
        public void ShouldReturnTrueWhenKeysAreEqual()
        {
            ComponentId componentId = new ComponentId(1);
            GameObjectType from = new GameObjectType(10);
            ArchetypeEdgeType edgeType = ArchetypeEdgeType.AddComponent;

            ArchetypeEdgeKey key1 = ArchetypeEdgeKey.Component(componentId, from, edgeType);
            ArchetypeEdgeKey key2 = ArchetypeEdgeKey.Component(componentId, from, edgeType);

            Assert.True(key1.Equals(key2));
        }

        /// <summary>
        ///     Tests that different keys are not considered equal
        /// </summary>
        [Fact]
        public void ShouldReturnFalseWhenKeysAreDifferent()
        {
            ComponentId componentId1 = new ComponentId(1);
            ComponentId componentId2 = new ComponentId(2);
            GameObjectType from = new GameObjectType(10);
            ArchetypeEdgeType edgeType = ArchetypeEdgeType.AddComponent;

            ArchetypeEdgeKey key1 = ArchetypeEdgeKey.Component(componentId1, from, edgeType);
            ArchetypeEdgeKey key2 = ArchetypeEdgeKey.Component(componentId2, from, edgeType);

            Assert.False(key1.Equals(key2));
        }

        /// <summary>
        ///     Tests that equal keys produce same hash code
        /// </summary>
        [Fact]
        public void ShouldProduceSameHashCodeWhenKeysAreEqual()
        {
            ComponentId componentId = new ComponentId(1);
            GameObjectType from = new GameObjectType(10);
            ArchetypeEdgeType edgeType = ArchetypeEdgeType.AddComponent;

            ArchetypeEdgeKey key1 = ArchetypeEdgeKey.Component(componentId, from, edgeType);
            ArchetypeEdgeKey key2 = ArchetypeEdgeKey.Component(componentId, from, edgeType);

            Assert.Equal(key1.GetHashCode(), key2.GetHashCode());
        }

        /// <summary>
        ///     Tests that equals with object returns true for same key
        /// </summary>
        [Fact]
        public void ShouldReturnTrueWhenEqualsWithObjectForSameKey()
        {
            ComponentId componentId = new ComponentId(1);
            GameObjectType from = new GameObjectType(10);
            ArchetypeEdgeType edgeType = ArchetypeEdgeType.AddComponent;

            ArchetypeEdgeKey key = ArchetypeEdgeKey.Component(componentId, from, edgeType);
            object obj = ArchetypeEdgeKey.Component(componentId, from, edgeType);

            Assert.True(key.Equals(obj));
        }

        /// <summary>
        ///     Tests that equals with object returns false for non-key
        /// </summary>
        [Fact]
        public void ShouldReturnFalseWhenEqualsWithObjectForNonKey()
        {
            ComponentId componentId = new ComponentId(1);
            GameObjectType from = new GameObjectType(10);
            ArchetypeEdgeType edgeType = ArchetypeEdgeType.AddComponent;

            ArchetypeEdgeKey key = ArchetypeEdgeKey.Component(componentId, from, edgeType);

            Assert.False(key.Equals("not a key"));
        }

        /// <summary>
        ///     Tests that different keys are not considered equal
        /// </summary>
        [Fact]
        public void ShouldReturnTrueWhenEqualsForEqualKeys()
        {
            ComponentId componentId = new ComponentId(1);
            GameObjectType from = new GameObjectType(10);
            ArchetypeEdgeType edgeType = ArchetypeEdgeType.AddComponent;

            ArchetypeEdgeKey key1 = ArchetypeEdgeKey.Component(componentId, from, edgeType);
            ArchetypeEdgeKey key2 = ArchetypeEdgeKey.Component(componentId, from, edgeType);

            Assert.True(key1.Equals(key2));
        }

        /// <summary>
        ///     Tests that not equals returns true for different keys
        /// </summary>
        [Fact]
        public void ShouldReturnTrueWhenNotEqualsForDifferentKeys()
        {
            ComponentId componentId1 = new ComponentId(1);
            ComponentId componentId2 = new ComponentId(2);
            GameObjectType from = new GameObjectType(10);
            ArchetypeEdgeType edgeType = ArchetypeEdgeType.AddComponent;

            ArchetypeEdgeKey key1 = ArchetypeEdgeKey.Component(componentId1, from, edgeType);
            ArchetypeEdgeKey key2 = ArchetypeEdgeKey.Component(componentId2, from, edgeType);

            Assert.False(key1.Equals(key2));
        }

        /// <summary>
        ///     Tests that different edge types produce different keys
        /// </summary>
        [Fact]
        public void ShouldReturnFalseWhenEdgeTypesAreDifferent()
        {
            ComponentId componentId = new ComponentId(1);
            GameObjectType from = new GameObjectType(10);

            ArchetypeEdgeKey key1 = ArchetypeEdgeKey.Component(componentId, from, ArchetypeEdgeType.AddComponent);
            ArchetypeEdgeKey key2 = ArchetypeEdgeKey.Component(componentId, from, ArchetypeEdgeType.RemoveComponent);

            Assert.False(key1.Equals(key2));
        }

        /// <summary>
        ///     Tests that different from types produce different keys
        /// </summary>
        [Fact]
        public void ShouldReturnFalseWhenFromTypesAreDifferent()
        {
            ComponentId componentId = new ComponentId(1);
            GameObjectType from1 = new GameObjectType(10);
            GameObjectType from2 = new GameObjectType(20);
            ArchetypeEdgeType edgeType = ArchetypeEdgeType.AddComponent;

            ArchetypeEdgeKey key1 = ArchetypeEdgeKey.Component(componentId, from1, edgeType);
            ArchetypeEdgeKey key2 = ArchetypeEdgeKey.Component(componentId, from2, edgeType);

            Assert.False(key1.Equals(key2));
        }
    }
}
