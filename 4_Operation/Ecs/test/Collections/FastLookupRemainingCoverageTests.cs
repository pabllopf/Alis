// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastLookupRemainingCoverageTests.cs
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
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    /// The fast lookup remaining coverage tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class FastLookupRemainingCoverageTests : IDisposable
    {
        /// <summary>
        /// The scene
        /// </summary>
        private Scene _scene;

        /// <summary>
        /// Initializes a new instance of the <see cref="FastLookupRemainingCoverageTests"/> class
        /// </summary>
        public FastLookupRemainingCoverageTests()
        {
            _scene = new Scene();
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            _scene?.Dispose();
            _scene = null;
        }

        /// <summary>
        /// Tests that set archetype stores data and advances index
        /// </summary>
        [Fact]
        public void SetArchetype_StoresDataAndAdvancesIndex()
        {
            FastLookup lookup = new FastLookup();
            ushort componentId = 1;
            GameObjectType from = _scene.DefaultArchetype.Id;
            Archetype to = _scene.DefaultArchetype;

            lookup.SetArchetype(componentId, from, to);

            uint expectedKey = FastLookup.GetKey(componentId, from);
            int idx = lookup.LookupIndex(expectedKey);
            Assert.Equal(0, idx);
            Assert.Same(to, lookup.Archetypes[0]);
        }

        /// <summary>
        /// Tests that set archetype multiple calls wraps index around
        /// </summary>
        [Fact]
        public void SetArchetype_MultipleCalls_WrapsIndexAround()
        {
            FastLookup lookup = new FastLookup();
            Archetype to = _scene.DefaultArchetype;
            GameObjectType from = to.Id;

            for (int i = 0; i < 10; i++)
            {
                lookup.SetArchetype((ushort)i, from, to);
            }

            Assert.Equal(2, lookup.index);
        }

        /// <summary>
        /// Tests that find adjacent archetype id cache hit returns stored archetype id
        /// </summary>
        [Fact]
        public void FindAdjacentArchetypeId_CacheHit_ReturnsStoredArchetypeId()
        {
            FastLookup lookup = new FastLookup();
            ushort componentId = 7;
            GameObjectType from = _scene.DefaultArchetype.Id;
            Archetype to = _scene.DefaultArchetype;
            TestTypeId typeId = new TestTypeId(componentId);

            lookup.SetArchetype(componentId, from, to);
            GameObjectType result = lookup.FindAdjacentArchetypeId(typeId, from, _scene, ArchetypeEdgeType.AddComponent);

            Assert.Equal(to.Id.RawIndex, result.RawIndex);
        }

        /// <summary>
        /// Tests that find adjacent archetype id cache miss scene graph hit returns destination id
        /// </summary>
        [Fact]
        public void FindAdjacentArchetypeId_CacheMiss_SceneGraphHit_ReturnsDestinationId()
        {
            FastLookup lookup = new FastLookup();
            ushort componentId = 42;
            TestTypeId typeId = new TestTypeId(componentId);
            GameObjectType from = _scene.DefaultArchetype.Id;

            ArchetypeEdgeKey edgeKey = ArchetypeEdgeKey.Component(new ComponentId(componentId), from, ArchetypeEdgeType.AddComponent);
            _scene.ArchetypeGraphEdges[edgeKey] = _scene.DefaultArchetype;

            GameObjectType result = lookup.FindAdjacentArchetypeId(typeId, from, _scene, ArchetypeEdgeType.AddComponent);

            Assert.Equal(_scene.DefaultArchetype.Id.RawIndex, result.RawIndex);
        }
        

        /// <summary>
        /// The test type id class
        /// </summary>
        /// <seealso cref="ITypeId"/>
        internal sealed class TestTypeId : ITypeId
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="TestTypeId"/> class
            /// </summary>
            /// <param name="value">The value</param>
            public TestTypeId(ushort value) => Value = value;

            /// <summary>
            /// Gets the value of the type
            /// </summary>
            public Type Type => typeof(byte);

            /// <summary>
            /// Gets the value of the value
            /// </summary>
            public ushort Value { get; }
        }
    }
}
