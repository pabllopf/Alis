// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Scene.7.cs
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
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    //it just so happens Archetype and Create both end with "e"
    /// <summary>
    ///     The scene class
    /// </summary>
    partial class Scene
    {
        /// <summary>
        ///     Creates an <see cref="GameObject" /> with the given component(s)
        /// </summary>
        /// <returns>An <see cref="GameObject" /> that can be used to acsess the component data</returns>
        public GameObject Create<T1, T2, T3, T4, T5, T6, T7>(in T1 comp1, in T2 comp2, in T3 comp3, in T4 comp4, in T5 comp5,
            in T6 comp6, in T7 comp7)
        {
            WorldArchetypeTableItem archetypes =
                Archetype<T1, T2, T3, T4, T5, T6, T7>.CreateNewOrGetExistingArchetypes(this);

            ref GameObjectIdOnly entity = ref Unsafe.NullRef<GameObjectIdOnly>();
            GameObjectLocation eloc = default(GameObjectLocation);

            ComponentStorageBase[] components;

            if (AllowStructualChanges)
            {
                components = archetypes.Archetype.Components;
                entity = ref archetypes.Archetype.CreateEntityLocation(GameObjectFlags.None, out eloc);
            }
            else
            {
                // we don't need to manually set flags, they are already zeroed
                entity = ref archetypes.Archetype.CreateDeferredEntityLocation(this, archetypes.DeferredCreationArchetype,
                    ref eloc, out components);
            }

            //manually inlined from Scene.CreateEntityFromLocation
            //The jit likes to inline the outer create function and not inline
            //the inner functions - benchmarked to improve perf by 10-20%
            (int id, ushort version) =
                entity = RecycledEntityIds.CanPop() ? RecycledEntityIds.Pop() : new(NextEntityId++, 0);
            eloc.Version = version;
            EntityTable[id] = eloc;

            //1x array lookup per component
            ref T1 ref1 =
                ref Unsafe.As<ComponentStorage<T1>>(
                    Unsafe.Add(ref components[0], Archetype<T1, T2, T3, T4, T5, T6, T7>.OfComponent<T1>.Index))[eloc.Index];
            ref1 = comp1;
            ref T2 ref2 =
                ref Unsafe.As<ComponentStorage<T2>>(
                    Unsafe.Add(ref components[0], Archetype<T1, T2, T3, T4, T5, T6, T7>.OfComponent<T2>.Index))[eloc.Index];
            ref2 = comp2;
            ref T3 ref3 =
                ref Unsafe.As<ComponentStorage<T3>>(
                    Unsafe.Add(ref components[0], Archetype<T1, T2, T3, T4, T5, T6, T7>.OfComponent<T3>.Index))[eloc.Index];
            ref3 = comp3;
            ref T4 ref4 =
                ref Unsafe.As<ComponentStorage<T4>>(
                    Unsafe.Add(ref components[0], Archetype<T1, T2, T3, T4, T5, T6, T7>.OfComponent<T4>.Index))[eloc.Index];
            ref4 = comp4;
            ref T5 ref5 =
                ref Unsafe.As<ComponentStorage<T5>>(
                    Unsafe.Add(ref components[0], Archetype<T1, T2, T3, T4, T5, T6, T7>.OfComponent<T5>.Index))[eloc.Index];
            ref5 = comp5;
            ref T6 ref6 =
                ref Unsafe.As<ComponentStorage<T6>>(
                    Unsafe.Add(ref components[0], Archetype<T1, T2, T3, T4, T5, T6, T7>.OfComponent<T6>.Index))[eloc.Index];
            ref6 = comp6;
            ref T7 ref7 =
                ref Unsafe.As<ComponentStorage<T7>>(
                    Unsafe.Add(ref components[0], Archetype<T1, T2, T3, T4, T5, T6, T7>.OfComponent<T7>.Index))[eloc.Index];
            ref7 = comp7;


            GameObject concreteGameObject = new GameObject(Id, version, id);

            Component<T1>.Initer?.Invoke(concreteGameObject, ref ref1);
            Component<T2>.Initer?.Invoke(concreteGameObject, ref ref2);
            Component<T3>.Initer?.Invoke(concreteGameObject, ref ref3);
            Component<T4>.Initer?.Invoke(concreteGameObject, ref ref4);
            Component<T5>.Initer?.Invoke(concreteGameObject, ref ref5);
            Component<T6>.Initer?.Invoke(concreteGameObject, ref ref6);
            Component<T7>.Initer?.Invoke(concreteGameObject, ref ref7);

            EntityCreatedEvent.Invoke(concreteGameObject);

            return concreteGameObject;
        }


        /// <summary>
        ///     Creates the many using the specified count
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <typeparam name="T7">The </typeparam>
        /// <param name="count">The count</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>A chunk tuple of t 1 and t 2 and t 3 and t 4 and t 5 and t 6 and t 7</returns>
        public ChunkTuple<T1, T2, T3, T4, T5, T6, T7> CreateMany<T1, T2, T3, T4, T5, T6, T7>(int count)
        {
            if ((uint) count == 0) // Efficient validation for non-positive values
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            WorldArchetypeTableItem archetype =
                Archetype<T1, T2, T3, T4, T5, T6, T7>.CreateNewOrGetExistingArchetypes(this);
            int entityCount = archetype.Archetype.EntityCount;

            EntityTable.EnsureCapacity(EntityCount + count);

            // Create gameObject locations directly in a Span
            Span<GameObjectIdOnly> entityLocations = archetype.Archetype.CreateEntityLocations(count, this);

            // Invoke events if listeners are present
            if (EntityCreatedEvent.HasListeners)
            {
                foreach (ref GameObjectIdOnly entityId in entityLocations)
                {
                    EntityCreatedEvent.Invoke(entityId.ToEntity(this));
                }
            }

            // Return the result with calculated spans
            return new ChunkTuple<T1, T2, T3, T4, T5, T6, T7>
            {
                Entities = new GameObjectEnumerator.EntityEnumerable(this, entityLocations),
                Span1 = archetype.Archetype.GetComponentSpan<T1>().Slice(entityCount, count),
                Span2 = archetype.Archetype.GetComponentSpan<T2>().Slice(entityCount, count),
                Span3 = archetype.Archetype.GetComponentSpan<T3>().Slice(entityCount, count),
                Span4 = archetype.Archetype.GetComponentSpan<T4>().Slice(entityCount, count),
                Span5 = archetype.Archetype.GetComponentSpan<T5>().Slice(entityCount, count),
                Span6 = archetype.Archetype.GetComponentSpan<T6>().Slice(entityCount, count),
                Span7 = archetype.Archetype.GetComponentSpan<T7>().Slice(entityCount, count)
            };
        }
    }
}