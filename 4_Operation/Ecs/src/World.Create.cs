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

using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Core;
using Alis.Core.Ecs.Core.Archetype;
using Alis.Core.Ecs.Core.Memory;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    public partial class World
    {
        [SkipLocalsInit]
        public Entity Create<T1, T2, T3>(in T1 comp1, in T2 comp2, in T3 comp3)
        {
            Archetype existingArchetype = Archetype<T1, T2, T3>.CreateNewOrGetExistingArchetype(this);
            Unsafe.NullRef<EntityIdOnly>();
            EntityLocation entityLocation = new EntityLocation();
            int physicalIndex;
            Unsafe.SkipInit<int>(out physicalIndex);
            ComponentStorageBase[] writeStorage;
            ref EntityIdOnly local1 = ref Unsafe.NullRef<EntityIdOnly>();
            if (this.AllowStructualChanges)
            {
                writeStorage = existingArchetype.Components;
                local1 = ref existingArchetype.CreateEntityLocation(EntityFlags.None, out entityLocation);
                physicalIndex = entityLocation.Index;
            }
            else
            {
                local1 = ref existingArchetype.CreateDeferredEntityLocation(this, ref entityLocation, out physicalIndex, out writeStorage);
                entityLocation.Archetype = this.DeferredCreateArchetype;
            }

            (int num, ushort version) = local1 = this.RecycledEntityIds.CanPop() ? this.RecycledEntityIds.Pop() : new EntityIdOnly(this.NextEntityID++, (ushort) 0);
            entityLocation.Version = version;
            this.EntityTable[num] = entityLocation;
            ref T1 local2 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3>.OfComponent<T1>.Index))[physicalIndex];
            local2 = comp1;
            ref T2 local3 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3>.OfComponent<T2>.Index))[physicalIndex];
            local3 = comp2;
            ref T3 local4 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T3>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3>.OfComponent<T3>.Index))[physicalIndex];
            local4 = comp3;
            Entity entity = new Entity(this.ID, version, num);
            ComponentDelegates<T1>.InitDelegate initer1 = Component<T1>.Initer;
            if (initer1 != null)
                initer1(entity, ref local2);
            ComponentDelegates<T2>.InitDelegate initer2 = Component<T2>.Initer;
            if (initer2 != null)
                initer2(entity, ref local3);
            ComponentDelegates<T3>.InitDelegate initer3 = Component<T3>.Initer;
            if (initer3 != null)
                initer3(entity, ref local4);
            this.EntityCreatedEvent.Invoke(entity);
            return entity;
        }
    }
}