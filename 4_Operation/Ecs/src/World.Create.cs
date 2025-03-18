// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:World.Create.cs
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
using System.Runtime.CompilerServices;
using Frent.Core;
using Frent.Systems;
using Frent.Updating;
using Frent.Updating.Runners;

namespace Frent
{
    //it just so happens Archetype and Create both end with "e"
    /// <summary>
    ///     The world class
    /// </summary>
    partial class World
    {
        /// <summary>
        ///     Creates an <see cref="Entity" /> with the given component(s)
        /// </summary>
        /// <returns>An <see cref="Entity" /> that can be used to acsess the component data</returns>
        [Frent.SkipLocalsInit]
        public Entity Create<T>(in T comp)
        {
            Archetype archetype = Archetype<T>.CreateNewOrGetExistingArchetype(this);

            ref EntityIDOnly entity = ref Unsafe.NullRef<EntityIDOnly>();
            EntityLocation eloc = default;

            ComponentStorageBase[] components;
            Unsafe.SkipInit(out int index);
            MemoryHelpers.Poison(ref index);

            if (AllowStructualChanges)
            {
                components = archetype.Components;
                entity = ref archetype.CreateEntityLocation(EntityFlags.None, out eloc);
                index = eloc.Index;
            }
            else
            {
                entity = ref archetype.CreateDeferredEntityLocation(this, ref eloc, out index, out components);
                eloc.Archetype = DeferredCreateArchetype;
            }

            //manually inlined from World.CreateEntityFromLocation
            //The jit likes to inline the outer create function and not inline
            //the inner functions - benchmarked to improve perf by 10-20%
            (int id, ushort version) = entity = RecycledEntityIds.CanPop() ? RecycledEntityIds.PopUnsafe() : new(NextEntityID++, 0);
            eloc.Version = version;
            EntityTable[id] = eloc;

            //1x array lookup per component
            ref T ref1 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T>>(components.UnsafeArrayIndex(Archetype<T>.OfComponent<T>.Index))[index];
            ref1 = comp;

            Entity concreteEntity = new Entity(ID, version, id);

            Component<T>.Initer?.Invoke(concreteEntity, ref ref1);
            EntityCreatedEvent.Invoke(concreteEntity);

            return concreteEntity;
        }

        /// <summary>
        ///     Creates a large amount of entities quickly
        /// </summary>
        /// <param name="count">The number of entities to create</param>
        /// <returns>The entities created and their component spans</returns>
        public ChunkTuple<T> CreateMany<T>(int count)
        {
            if (count < 0)
                FrentExceptions.Throw_ArgumentOutOfRangeException("Must create at least 1 entity!");

            Archetype archetype = Archetype<T>.CreateNewOrGetExistingArchetype(this);
            int initalEntityCount = archetype.EntityCount;

            EntityTable.EnsureCapacity(EntityCount + count);

            Span<EntityIDOnly> entities = archetype.CreateEntityLocations(count, this);

            if (EntityCreatedEvent.HasListeners)
            {
                foreach (EntityIDOnly entity in entities)
                    EntityCreatedEvent.Invoke(entity.ToEntity(this));
            }

            ChunkTuple<T> chunks = new ChunkTuple<T>
            {
                Entities = new EntityEnumerator.EntityEnumerable(this, entities),
                Span = archetype.GetComponentSpan<T>()[initalEntityCount..]
            };

            return chunks;
        }
    }
}