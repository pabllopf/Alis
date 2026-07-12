// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeEdgeKeyRemainingCoverageTests.cs
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
    ///     The archetype edge key remaining coverage tests class
    /// </summary>
    public class ArchetypeEdgeKeyRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that component static factory sets fields correctly
        /// </summary>
        [Fact]
        public void Component_StaticFactory_SetsFields()
        {
            ComponentId componentId = new ComponentId((ushort)5);
            GameObjectType from = default(GameObjectType);
            ArchetypeEdgeType edgeType = ArchetypeEdgeType.AddComponent;

            ArchetypeEdgeKey key = ArchetypeEdgeKey.Component(componentId, from, edgeType);

            Assert.Equal((ushort)5, key.ComponentID.RawIndex);
            Assert.Equal(ArchetypeEdgeType.AddComponent, key.EdgeType);
        }

        /// <summary>
        ///     Tests that component static factory with remove component sets edge type
        /// </summary>
        [Fact]
        public void Component_StaticFactory_WithRemoveComponent_SetsEdgeType()
        {
            ComponentId componentId = new ComponentId((ushort)9);
            GameObjectType from = default(GameObjectType);

            ArchetypeEdgeKey key = ArchetypeEdgeKey.Component(componentId, from, ArchetypeEdgeType.RemoveComponent);

            Assert.Equal(ArchetypeEdgeType.RemoveComponent, key.EdgeType);
        }

        /// <summary>
        ///     Tests that equals returns true for same packed values
        /// </summary>
        [Fact]
        public void Equals_SamePackedValues_ReturnsTrue()
        {
            ComponentId componentId = new ComponentId((ushort)3);
            GameObjectType from = default(GameObjectType);

            ArchetypeEdgeKey a = ArchetypeEdgeKey.Component(componentId, from, ArchetypeEdgeType.AddComponent);
            ArchetypeEdgeKey b = ArchetypeEdgeKey.Component(componentId, from, ArchetypeEdgeType.AddComponent);

            Assert.True(a.Equals(b));
        }

        /// <summary>
        ///     Tests that equals returns false for different packed values
        /// </summary>
        [Fact]
        public void Equals_DifferentPackedValues_ReturnsFalse()
        {
            GameObjectType from = default(GameObjectType);

            ArchetypeEdgeKey a = ArchetypeEdgeKey.Component(new ComponentId((ushort)1), from, ArchetypeEdgeType.AddComponent);
            ArchetypeEdgeKey b = ArchetypeEdgeKey.Component(new ComponentId((ushort)2), from, ArchetypeEdgeType.AddComponent);

            Assert.False(a.Equals(b));
        }

        /// <summary>
        ///     Tests that equals with object returns true for same key
        /// </summary>
        [Fact]
        public void Equals_Object_SameKey_ReturnsTrue()
        {
            ComponentId componentId = new ComponentId((ushort)4);
            GameObjectType from = default(GameObjectType);

            ArchetypeEdgeKey key = ArchetypeEdgeKey.Component(componentId, from, ArchetypeEdgeType.AddTag);
            object other = ArchetypeEdgeKey.Component(componentId, from, ArchetypeEdgeType.AddTag);

            Assert.True(key.Equals(other));
        }

        /// <summary>
        ///     Tests that equals with object returns false for different type
        /// </summary>
        [Fact]
        public void Equals_Object_DifferentType_ReturnsFalse()
        {
            ComponentId componentId = new ComponentId((ushort)4);
            GameObjectType from = default(GameObjectType);

            ArchetypeEdgeKey key = ArchetypeEdgeKey.Component(componentId, from, ArchetypeEdgeType.RemoveTag);

            Assert.False(key.Equals("not a key"));
        }

        /// <summary>
        ///     Tests that get hash code returns same hash for same values
        /// </summary>
        [Fact]
        public void GetHashCode_SameValues_ReturnsSameHash()
        {
            ComponentId componentId = new ComponentId((ushort)7);
            GameObjectType from = default(GameObjectType);

            ArchetypeEdgeKey a = ArchetypeEdgeKey.Component(componentId, from, ArchetypeEdgeType.AddComponent);
            ArchetypeEdgeKey b = ArchetypeEdgeKey.Component(componentId, from, ArchetypeEdgeType.AddComponent);

            Assert.Equal(a.GetHashCode(), b.GetHashCode());
        }

        /// <summary>
        ///     Tests that get hash code returns different hash for different values
        /// </summary>
        [Fact]
        public void GetHashCode_DifferentValues_ReturnsDifferentHash()
        {
            GameObjectType from = default(GameObjectType);

            ArchetypeEdgeKey a = ArchetypeEdgeKey.Component(new ComponentId((ushort)1), from, ArchetypeEdgeType.AddComponent);
            ArchetypeEdgeKey b = ArchetypeEdgeKey.Component(new ComponentId((ushort)2), from, ArchetypeEdgeType.AddComponent);

            Assert.NotEqual(a.GetHashCode(), b.GetHashCode());
        }
    }
}