// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Scene.2.cs
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
using Alis.Core.Ecs.Arch;
using Alis.Core.Ecs.Marshalling;
using Alis.Core.Ecs.Operations;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    /// <summary>
    /// The scene class
    /// </summary>
    partial class Scene
    {
        /// <summary>
        ///     Creates the comp 1
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <param name="comp1">The comp</param>
        /// <param name="comp2">The comp</param>
        /// <returns>The entity</returns>
        [SkipLocalsInit]
        public GameObject Create<T1, T2>(in T1 comp1, in T2 comp2)
        {
            Archetype existingArchetype = Archetype<T1, T2>.CreateNewOrGetExistingArchetype(this);

            EntityLocation entityLocation = new EntityLocation();
            Unsafe.SkipInit(out int physicalIndex);
            ComponentStorageBase[] writeStorage;

            ref EntityIdOnly local1 = ref Unsafe.NullRef<EntityIdOnly>();
            if (AllowStructualChanges)
            {
                writeStorage = existingArchetype.Components;
                local1 = ref existingArchetype.CreateEntityLocation(EntityFlags.None, out entityLocation);
                physicalIndex = entityLocation.Index;
            }
            else
            {
                local1 = ref existingArchetype.CreateDeferredEntityLocation(this, ref entityLocation, out physicalIndex, out writeStorage);
                entityLocation.Archetype = DeferredCreateArchetype;
            }

            (int num, ushort version) = local1 = RecycledEntityIds.CanPop() ? RecycledEntityIds.Pop() : new EntityIdOnly(NextEntityID++, 0);
            entityLocation.Version = version;
            EntityTable[num] = entityLocation;
            ref T1 local2 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2>.OfComponent<T1>.Index))[physicalIndex];
            local2 = comp1;
            ref T2 local3 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2>.OfComponent<T2>.Index))[physicalIndex];
            local3 = comp2;
            GameObject gameObject = new GameObject(ID, version, num);
            ComponentDelegates<T1>.InitDelegate initer1 = Component<T1>.Initer;
            initer1?.Invoke(gameObject, ref local2);

            ComponentDelegates<T2>.InitDelegate initer2 = Component<T2>.Initer;
            initer2?.Invoke(gameObject, ref local3);

            EntityCreatedEvent.Invoke(gameObject);
            return gameObject;
        }

        [SkipLocalsInit]
        public ChunkTuple<T1, T2> CreateMany<T1, T2>(int count)
        {
            if ((uint) count == 0) 
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            Archetype archetype =  Archetype<T1, T2>.CreateNewOrGetExistingArchetype(this);
            int entityCount = archetype.EntityCount;

            EntityTable.EnsureCapacity(EntityCount + count);
            
            Span<EntityIdOnly> entityLocations = archetype.CreateEntityLocations(count, this);
            
            if (EntityCreatedEvent.HasListeners)
            {
                foreach (ref EntityIdOnly entityId in entityLocations)
                {
                    EntityCreatedEvent.Invoke(entityId.ToEntity(this));
                }
            }
            
            return new ChunkTuple<T1, T2>
            {
                Entities = new EntityEnumerator.EntityEnumerable(this, entityLocations),
                Span1 = archetype.GetComponentSpan<T1>().Slice(entityCount, count),
                Span2 = archetype.GetComponentSpan<T2>().Slice(entityCount, count)
            };
        }
    }
}