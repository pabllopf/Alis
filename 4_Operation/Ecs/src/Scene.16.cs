using System;
using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetype;
using Alis.Core.Ecs.Redifinition;
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
        public GameObject Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(in T1 comp1,
            in T2 comp2, in T3 comp3, in T4 comp4, in T5 comp5, in T6 comp6, in T7 comp7, in T8 comp8, in T9 comp9,
            in T10 comp10, in T11 comp11, in T12 comp12, in T13 comp13, in T14 comp14, in T15 comp15, in T16 comp16)
        {
            WorldArchetypeTableItem archetypes =
                Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
                    .CreateNewOrGetExistingArchetypes(this);

            ref GameObjectIdOnly entity = ref Unsafe.NullRef<GameObjectIdOnly>();
            GameObjectLocation eloc = default;

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
            ref T1 ref1 = ref  Unsafe.As<ComponentStorage<T1>>(
                components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
                    .OfComponent<T1>.Index))[eloc.Index];
            ref1 = comp1;
            ref T2 ref2 = ref  Unsafe.As<ComponentStorage<T2>>(
                components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
                    .OfComponent<T2>.Index))[eloc.Index];
            ref2 = comp2;
            ref T3 ref3 = ref  Unsafe.As<ComponentStorage<T3>>(
                components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
                    .OfComponent<T3>.Index))[eloc.Index];
            ref3 = comp3;
            ref T4 ref4 = ref  Unsafe.As<ComponentStorage<T4>>(
                components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
                    .OfComponent<T4>.Index))[eloc.Index];
            ref4 = comp4;
            ref T5 ref5 = ref  Unsafe.As<ComponentStorage<T5>>(
                components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
                    .OfComponent<T5>.Index))[eloc.Index];
            ref5 = comp5;
            ref T6 ref6 = ref  Unsafe.As<ComponentStorage<T6>>(
                components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
                    .OfComponent<T6>.Index))[eloc.Index];
            ref6 = comp6;
            ref T7 ref7 = ref  Unsafe.As<ComponentStorage<T7>>(
                components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
                    .OfComponent<T7>.Index))[eloc.Index];
            ref7 = comp7;
            ref T8 ref8 = ref  Unsafe.As<ComponentStorage<T8>>(
                components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
                    .OfComponent<T8>.Index))[eloc.Index];
            ref8 = comp8;
            ref T9 ref9 = ref  Unsafe.As<ComponentStorage<T9>>(
                components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
                    .OfComponent<T9>.Index))[eloc.Index];
            ref9 = comp9;
            ref T10 ref10 = ref  Unsafe.As<ComponentStorage<T10>>(
                components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
                    .OfComponent<T10>.Index))[eloc.Index];
            ref10 = comp10;
            ref T11 ref11 = ref  Unsafe.As<ComponentStorage<T11>>(
                components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
                    .OfComponent<T11>.Index))[eloc.Index];
            ref11 = comp11;
            ref T12 ref12 = ref  Unsafe.As<ComponentStorage<T12>>(
                components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
                    .OfComponent<T12>.Index))[eloc.Index];
            ref12 = comp12;
            ref T13 ref13 = ref  Unsafe.As<ComponentStorage<T13>>(
                components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
                    .OfComponent<T13>.Index))[eloc.Index];
            ref13 = comp13;
            ref T14 ref14 = ref  Unsafe.As<ComponentStorage<T14>>(
                components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
                    .OfComponent<T14>.Index))[eloc.Index];
            ref14 = comp14;
            ref T15 ref15 = ref  Unsafe.As<ComponentStorage<T15>>(
                components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
                    .OfComponent<T15>.Index))[eloc.Index];
            ref15 = comp15;
            ref T16 ref16 = ref  Unsafe.As<ComponentStorage<T16>>(
                components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
                    .OfComponent<T16>.Index))[eloc.Index];
            ref16 = comp16;


            GameObject concreteGameObject = new GameObject(Id, version, id);

            Component<T1>.Initer?.Invoke(concreteGameObject, ref ref1);
            Component<T2>.Initer?.Invoke(concreteGameObject, ref ref2);
            Component<T3>.Initer?.Invoke(concreteGameObject, ref ref3);
            Component<T4>.Initer?.Invoke(concreteGameObject, ref ref4);
            Component<T5>.Initer?.Invoke(concreteGameObject, ref ref5);
            Component<T6>.Initer?.Invoke(concreteGameObject, ref ref6);
            Component<T7>.Initer?.Invoke(concreteGameObject, ref ref7);
            Component<T8>.Initer?.Invoke(concreteGameObject, ref ref8);
            Component<T9>.Initer?.Invoke(concreteGameObject, ref ref9);
            Component<T10>.Initer?.Invoke(concreteGameObject, ref ref10);
            Component<T11>.Initer?.Invoke(concreteGameObject, ref ref11);
            Component<T12>.Initer?.Invoke(concreteGameObject, ref ref12);
            Component<T13>.Initer?.Invoke(concreteGameObject, ref ref13);
            Component<T14>.Initer?.Invoke(concreteGameObject, ref ref14);
            Component<T15>.Initer?.Invoke(concreteGameObject, ref ref15);
            Component<T16>.Initer?.Invoke(concreteGameObject, ref ref16);

            EntityCreatedEvent.Invoke(concreteGameObject);

            return concreteGameObject;
        }


        /// <summary>
        /// Creates the many using the specified count
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <typeparam name="T7">The </typeparam>
        /// <typeparam name="T8">The </typeparam>
        /// <typeparam name="T9">The </typeparam>
        /// <typeparam name="T10">The 10</typeparam>
        /// <typeparam name="T11">The 11</typeparam>
        /// <typeparam name="T12">The 12</typeparam>
        /// <typeparam name="T13">The 13</typeparam>
        /// <typeparam name="T14">The 14</typeparam>
        /// <typeparam name="T15">The 15</typeparam>
        /// <typeparam name="T16">The 16</typeparam>
        /// <param name="count">The count</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>A chunk tuple of t 1 and t 2 and t 3 and t 4 and t 5 and t 6 and t 7 and t 8 and t 9 and t 10 and t 11 and t 12 and t 13 and t 14 and t 15 and t 16</returns>
        public ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> CreateMany<T1, T2, T3, T4,
            T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(int count)
        {
            if ((uint)count == 0) throw new ArgumentOutOfRangeException(nameof(count));

            WorldArchetypeTableItem archetype =
                Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
                    .CreateNewOrGetExistingArchetypes(this);
            int entityCount = archetype.Archetype.EntityCount;

            EntityTable.EnsureCapacity(EntityCount + count);

            Span<GameObjectIdOnly> entityLocations = archetype.Archetype.CreateEntityLocations(count, this);

            if (EntityCreatedEvent.HasListeners)
                foreach (ref GameObjectIdOnly entityId in entityLocations)
                    EntityCreatedEvent.Invoke(entityId.ToEntity(this));

            return new ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
            {
                Entities = new GameObjectEnumerator.EntityEnumerable(this, entityLocations),
                Span1 = archetype.Archetype.GetComponentSpan<T1>().Slice(entityCount, count),
                Span2 = archetype.Archetype.GetComponentSpan<T2>().Slice(entityCount, count),
                Span3 = archetype.Archetype.GetComponentSpan<T3>().Slice(entityCount, count),
                Span4 = archetype.Archetype.GetComponentSpan<T4>().Slice(entityCount, count),
                Span5 = archetype.Archetype.GetComponentSpan<T5>().Slice(entityCount, count),
                Span6 = archetype.Archetype.GetComponentSpan<T6>().Slice(entityCount, count),
                Span7 = archetype.Archetype.GetComponentSpan<T7>().Slice(entityCount, count),
                Span8 = archetype.Archetype.GetComponentSpan<T8>().Slice(entityCount, count),
                Span9 = archetype.Archetype.GetComponentSpan<T9>().Slice(entityCount, count),
                Span10 = archetype.Archetype.GetComponentSpan<T10>().Slice(entityCount, count),
                Span11 = archetype.Archetype.GetComponentSpan<T11>().Slice(entityCount, count),
                Span12 = archetype.Archetype.GetComponentSpan<T12>().Slice(entityCount, count),
                Span13 = archetype.Archetype.GetComponentSpan<T13>().Slice(entityCount, count),
                Span14 = archetype.Archetype.GetComponentSpan<T14>().Slice(entityCount, count),
                Span15 = archetype.Archetype.GetComponentSpan<T15>().Slice(entityCount, count),
                Span16 = archetype.Archetype.GetComponentSpan<T16>().Slice(entityCount, count)
            };
        }
    }
}