// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityUpdate.2.cs
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
using System.Runtime.InteropServices;
using System.Threading;
using Alis.Core.Ecs.Arch;
using Alis.Core.Ecs.Operations;

namespace Alis.Core.Ecs.Updating.Runners
{
    /// <summary>
    /// The entity update class
    /// </summary>
    /// <seealso cref="ComponentStorage{TComp}"/>
    internal class EntityUpdate<TComp, TArg1, TArg2>(int capacity) : ComponentStorage<TComp>(capacity)
        where TComp : IEntityComponent<TArg1, TArg2>
    {
        [SkipLocalsInit]
        internal override void Run(Scene scene, Archetype b)
        {
            ref EntityIdOnly entityIds = ref b.GetEntityDataReference();
            ref TComp comp = ref GetComponentStorageDataReference();
            ref TArg1 arg1 = ref b.GetComponentDataReference<TArg1>();
            ref TArg2 arg2 = ref b.GetComponentDataReference<TArg2>();
        
            GameObject gameObject = scene.DefaultWorldGameObject;
            int size = b.EntityCount;
        
        #if NET7_0_OR_GREATER
            // Use MemoryMarshal.CreateSpan for efficient span creation
            Span<EntityIdOnly> entitySpan = MemoryMarshal.CreateSpan(ref entityIds, size);
            Span<TComp> compSpan = MemoryMarshal.CreateSpan(ref comp, size);
            Span<TArg1> arg1Span = MemoryMarshal.CreateSpan(ref arg1, size);
            Span<TArg2> arg2Span = MemoryMarshal.CreateSpan(ref arg2, size);
        
            for (int i = size - 1; i >= 0; i--)
            {
                ref var currentEntity = ref entitySpan[i];
                ref var currentComp = ref compSpan[i];
                ref var currentArg1 = ref arg1Span[i];
                ref var currentArg2 = ref arg2Span[i];
        
                currentEntity.SetEntity(ref gameObject);
                currentComp.Update(gameObject, ref currentArg1, ref currentArg2);
            }
        #else
            // Fallback for older .NET versions
            for (int i = size - 1; i >= 0; i--)
            {
                entityIds.SetEntity(ref gameObject);
                comp.Update(gameObject, ref arg1, ref arg2);
        
                entityIds = ref Unsafe.Add(ref entityIds, 1);
                comp = ref Unsafe.Add(ref comp, 1);
                arg1 = ref Unsafe.Add(ref arg1, 1);
                arg2 = ref Unsafe.Add(ref arg2, 1);
            }
        #endif
        }

        
    }
}