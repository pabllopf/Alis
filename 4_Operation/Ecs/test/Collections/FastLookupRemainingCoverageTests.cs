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
    public class FastLookupRemainingCoverageTests : IDisposable
    {
        private Scene _scene;

        public FastLookupRemainingCoverageTests()
        {
            _scene = new Scene();
        }

        public void Dispose()
        {
            _scene?.Dispose();
            _scene = null;
        }

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

        [Fact]
        public void FindAdjacentArchetypeId_CacheHit_ReturnsStoredArchetypeId()
        {
            FastLookup lookup = new FastLookup();
            ushort componentId = 7;
            GameObjectType from = _scene.DefaultArchetype.Id;
            Archetype to = _scene.DefaultArchetype;
            var typeId = new TestTypeId(componentId);

            lookup.SetArchetype(componentId, from, to);
            GameObjectType result = lookup.FindAdjacentArchetypeId(typeId, from, _scene, ArchetypeEdgeType.AddComponent);

            Assert.Equal(to.Id.RawIndex, result.RawIndex);
        }

        [Fact]
        public void FindAdjacentArchetypeId_CacheMiss_SceneGraphHit_ReturnsDestinationId()
        {
            FastLookup lookup = new FastLookup();
            ushort componentId = 42;
            var typeId = new TestTypeId(componentId);
            GameObjectType from = _scene.DefaultArchetype.Id;

            ArchetypeEdgeKey edgeKey = ArchetypeEdgeKey.Component(new ComponentId(componentId), from, ArchetypeEdgeType.AddComponent);
            _scene.ArchetypeGraphEdges[edgeKey] = _scene.DefaultArchetype;

            GameObjectType result = lookup.FindAdjacentArchetypeId(typeId, from, _scene, ArchetypeEdgeType.AddComponent);

            Assert.Equal(_scene.DefaultArchetype.Id.RawIndex, result.RawIndex);
        }

        private sealed class TestTypeId : ITypeId
        {
            public TestTypeId(ushort value) => Value = value;

            public Type Type => typeof(byte);

            public ushort Value { get; }
        }
    }
}
