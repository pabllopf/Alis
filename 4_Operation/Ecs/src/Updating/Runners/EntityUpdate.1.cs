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
using Alis.Core.Aspect.Fluent;
using Alis.Core.Ecs.Arch;
using Alis.Core.Ecs.Operations;

namespace Alis.Core.Ecs.Updating.Runners
{
    /// <summary>
    ///     The entity update class
    /// </summary>
    /// <seealso cref="ComponentStorage{TComp}" />
    internal class EntityUpdate<TComp, TArg>(int capacity) : ComponentStorage<TComp>(capacity)
        where TComp : IEntityComponent<TArg>
    {
        [SkipLocalsInit]
        internal override void Run(Scene scene, Archetype b)
        {
            ref EntityIdOnly entityIds = ref b.GetEntityDataReference();
            ref TComp comp = ref GetComponentStorageDataReference();
            ref TArg arg = ref b.GetComponentDataReference<TArg>();
        
            GameObject gameObject = scene.DefaultWorldGameObject;
            int size = b.EntityCount;
        
        #if NET7_0_OR_GREATER
            // Use MemoryMarshal.CreateSpan for efficient span creation
            Span<EntityIdOnly> entitySpan = MemoryMarshal.CreateSpan(ref entityIds, size);
            Span<TComp> compSpan = MemoryMarshal.CreateSpan(ref comp, size);
            Span<TArg> argSpan = MemoryMarshal.CreateSpan(ref arg, size);
        
            for (int i = size - 1; i >= 0; i--)
            {
                ref var currentEntity = ref entitySpan[i];
                ref var currentComp = ref compSpan[i];
                ref var currentArg = ref argSpan[i];
        
                currentEntity.SetEntity(ref gameObject);
                currentComp.Update(gameObject, ref currentArg);
            }
        #else
            // Fallback for older .NET versions
            for (int i = size - 1; i >= 0; i--)
            {
                entityIds.SetEntity(ref gameObject);
                comp.Update(gameObject, ref arg);
        
                entityIds = ref Unsafe.Add(ref entityIds, 1);
                comp = ref Unsafe.Add(ref comp, 1);
                arg = ref Unsafe.Add(ref arg, 1);
            }
        #endif
        }
    }
}