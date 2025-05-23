using System;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Alis.Core.Aspect.Memory.Collections;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Core.Memory;
using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs.Core.Archetype
{
    /// <summary>
    ///     The archetype class
    /// </summary>
    public partial class Archetype
    {
        /// <summary>
        ///     Gets the value of the id
        /// </summary>
        internal ArchetypeID Id => _archetypeId;

        /// <summary>
        ///     Gets the value of the archetype type array
        /// </summary>
        internal FastImmutableArray<ComponentId> ArchetypeTypeArray => _archetypeId.Types;

        /// <summary>
        ///     Gets the value of the archetype tag array
        /// </summary>
        internal FastImmutableArray<TagId> ArchetypeTagArray => _archetypeId.Tags;

        /// <summary>
        ///     Gets the value of the debugger display string
        /// </summary>
        internal string DebuggerDisplayString =>
            $"Archetype Count: {EntityCount} Types: {string.Join(", ", ArchetypeTypeArray.Select(t => t.Type.Name))} Tags: {string.Join(", ", ArchetypeTagArray.Select(t => t.Type.Name))}";

        /// <summary>
        ///     Gets the value of the gameObject count
        /// </summary>
        internal int EntityCount => NextComponentIndex;

        /// <summary>
        ///     Gets the value of the data
        /// </summary>
        internal Fields Data => new Fields
        {
            Map = ComponentTagTable,
            Components = Components
        };

        /// <summary>
        ///     Gets the component span
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>A span of t</returns>
        internal Span<T> GetComponentSpan<T>()
        {
            ComponentStorageBase[] components = Components;
            int index = GetComponentIndex<T>();
            if (index == 0) throw new ComponentNotFoundException(typeof(T));
            return UnsafeExtensions.UnsafeCast<ComponentStorage<T>>(components.UnsafeArrayIndex(index))
                .AsSpanLength(NextComponentIndex);
        }

        /// <summary>
        ///     Gets the component data reference
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The ref</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal ref T GetComponentDataReference<T>()
        {
            int index = GetComponentIndex<T>();
            return ref UnsafeExtensions.UnsafeCast<ComponentStorage<T>>(Components.UnsafeArrayIndex(index))
                .GetComponentStorageDataReference();
        }


        /// <summary>
        ///     Creates the gameObject location using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <param name="gameObjectLocation">The gameObject location</param>
        /// <returns>The ref gameObject id only</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal ref GameObjectIdOnly CreateEntityLocation(GameObjectFlags flags, out GameObjectLocation gameObjectLocation)
        {
            if (_entities.Length == NextComponentIndex)
                Resize(_entities.Length * 2);

            gameObjectLocation.Archetype = this;
            gameObjectLocation.Index = NextComponentIndex;
            gameObjectLocation.Flags = flags;
            Unsafe.SkipInit(out gameObjectLocation.Version);
            //poison prolly isnt needed since archetype forces clear anyways
            MemoryHelpers.Poison(ref gameObjectLocation.Version);

            return ref _entities.UnsafeArrayIndex(NextComponentIndex++);
        }

        /// <summary>
        ///     Note! GameObject location version is not set!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal ref GameObjectIdOnly CreateDeferredEntityLocation(Scene scene, Archetype deferredCreationArchetype,
            scoped ref GameObjectLocation gameObjectLocation, out ComponentStorageBase[] writeStorage)
        {
            if (deferredCreationArchetype.DeferredEntityCount == 0)
                scene.DeferredCreationArchetypes.Push(new(this, deferredCreationArchetype, EntityCount));

            int futureSlot = NextComponentIndex + deferredCreationArchetype.DeferredEntityCount++;

            if (futureSlot < _entities.Length)
            {
                //hot path: we have space and can directly place into existing array
                writeStorage = Components;
                gameObjectLocation.Index = futureSlot;
                gameObjectLocation.Archetype = this;
                return ref _entities.UnsafeArrayIndex(futureSlot);
            }

            return ref CreateDeferredEntityLocationTempBuffers(deferredCreationArchetype, futureSlot, ref gameObjectLocation,
                out writeStorage);
        }

        // Only to be called by CreateDeferredEntityLocation
        // Allow the jit to inline that method more easily
        /// <summary>
        ///     Creates the deferred gameObject location temp buffers using the specified deferred creation archetype
        /// </summary>
        /// <param name="deferredCreationArchetype">The deferred creation archetype</param>
        /// <param name="futureSlot">The future slot</param>
        /// <param name="gameObjectLocation">The gameObject location</param>
        /// <param name="writeStorage">The write storage</param>
        /// <returns>The ref gameObject id only</returns>
        private ref GameObjectIdOnly CreateDeferredEntityLocationTempBuffers(Archetype deferredCreationArchetype,
            int futureSlot, scoped ref GameObjectLocation gameObjectLocation, out ComponentStorageBase[] writeStorage)
        {
            //we need to place into temp buffers
            gameObjectLocation.Index = futureSlot - _entities.Length;
            gameObjectLocation.Archetype = deferredCreationArchetype;


            if (gameObjectLocation.Index >= deferredCreationArchetype._entities.Length)
                deferredCreationArchetype.ResizeCreateComponentBuffers();

            writeStorage = deferredCreationArchetype.Components;

            return ref deferredCreationArchetype._entities.UnsafeArrayIndex(gameObjectLocation.Index);
        }

        /// <summary>
        ///     Resolves the deferred gameObject creations using the specified scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="deferredCreationArchetype">The deferred creation archetype</param>
        internal void ResolveDeferredEntityCreations(Scene scene, Archetype deferredCreationArchetype)
        {
            int deltaFromMaxDeferredInPlace =
                -(_entities.Length - (NextComponentIndex + deferredCreationArchetype.DeferredEntityCount));
            int previousComponentCount = NextComponentIndex;

            if (!(deltaFromMaxDeferredInPlace <= 0))
            {
                //components overflowed into temp storage

                int oldEntitiesLen = _entities.Length;
                int totalCapacityRequired = previousComponentCount + deferredCreationArchetype.DeferredEntityCount;

                //we should always have to resize here - after all, no space is left
                Resize((int)BitOperations.RoundUpToPowerOf2((uint)totalCapacityRequired));
                ComponentStorageBase[] destination = Components;
                ComponentStorageBase[] source = deferredCreationArchetype.Components;
                for (int i = 1; i < destination.Length; i++)
                    Array.Copy(source[i].Buffer, 0, destination[i].Buffer, oldEntitiesLen, deltaFromMaxDeferredInPlace);
                Array.Copy(deferredCreationArchetype._entities, 0, _entities, oldEntitiesLen, deltaFromMaxDeferredInPlace);
            }

            NextComponentIndex += deferredCreationArchetype.DeferredEntityCount;

            GameObjectIdOnly[] entities = _entities;
            GameObjectLocation[] table = scene.EntityTable._buffer;
            for (int i = previousComponentCount; i < entities.Length && i < NextComponentIndex; i++)
            {
                ref GameObjectLocation gameObjectLocationToResolve = ref table.UnsafeArrayIndex(entities[i].ID);
                gameObjectLocationToResolve.Archetype = this;
                gameObjectLocationToResolve.Index = i;
            }

            deferredCreationArchetype.DeferredEntityCount = 0;
        }

        /// <summary>
        ///     Creates the gameObject locations using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        /// <param name="scene">The scene</param>
        /// <returns>The gameObject span</returns>
        internal Span<GameObjectIdOnly> CreateEntityLocations(int count, Scene scene)
        {
            int newLen = NextComponentIndex + count;
            EnsureCapacity(newLen);

            Span<GameObjectIdOnly> entitySpan = _entities.AsSpan(NextComponentIndex, count);

            int componentIndex = NextComponentIndex;
            ref FastestStack<GameObjectIdOnly> recycled = ref scene.RecycledEntityIds;
            for (int i = 0; i < entitySpan.Length; i++)
            {
                ref GameObjectIdOnly archetypeEntity = ref entitySpan[i];

                archetypeEntity = recycled.CanPop() ? recycled.Pop() : new GameObjectIdOnly(scene.NextEntityId++, 0);

                ref GameObjectLocation lookup = ref scene.EntityTable.UnsafeIndexNoResize(archetypeEntity.ID);

                lookup.Version = archetypeEntity.Version;
                lookup.Archetype = this;
                lookup.Index = componentIndex++;
                lookup.Flags = GameObjectFlags.None;
            }

            NextComponentIndex = componentIndex;

            return entitySpan;
        }

        /// <summary>
        ///     Resizes the new len
        /// </summary>
        /// <param name="newLen">The new len</param>
        private void Resize(int newLen)
        {
            Array.Resize(ref _entities, newLen);
            ComponentStorageBase[] runners = Components;
            for (int i = 1; i < runners.Length; i++)
                runners[i].ResizeBuffer(newLen);
        }

        /// <summary>
        ///     Resizes the create component buffers
        /// </summary>
        private void ResizeCreateComponentBuffers()
        {
#if DEBUG
#endif
            int newLen = checked(Math.Max(1, _entities.Length) * 2);
            //we only need to resize the EntityIDOnly array when future total gameObject count is greater than capacity
            Array.Resize(ref _entities, newLen);
            ComponentStorageBase[] runners = Components;
            for (int i = 1; i < runners.Length; i++)
                runners[i].ResizeBuffer(newLen);
        }

        /// <summary>
        ///     Ensures the capacity using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        public void EnsureCapacity(int count)
        {
            if (_entities.Length >= count) return;

            FastestArrayPool<GameObjectIdOnly>.ResizeArrayFromPool(ref _entities, count);
            ComponentStorageBase[] runners = Components;
            for (int i = 1; i < runners.Length; i++) runners[i].ResizeBuffer(count);
        }

        /// <summary>
        ///     This method doesn't modify component storages
        /// </summary>
        internal GameObjectIdOnly DeleteEntityFromStorage(int index, out int deletedIndex)
        {
            deletedIndex = --NextComponentIndex;
            return _entities.UnsafeArrayIndex(index) = _entities.UnsafeArrayIndex(NextComponentIndex);
        }

        /// <summary>
        ///     Deletes the gameObject using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The gameObject id only</returns>
        internal GameObjectIdOnly DeleteEntity(int index)
        {
            NextComponentIndex--;





            DeleteComponentData args = new(index, NextComponentIndex);

            ref ComponentStorageBase first = ref MemoryMarshal.GetArrayDataReference(Components);

            switch (Components.Length)
            {
                case 1: goto end;
                case 2: goto len2;
                case 3: goto len3;
                case 4: goto len4;
                case 5: goto len5;
                case 6: goto len6;
                case 7: goto len7;
                case 8: goto len8;
                case 9: goto len9;
                default: goto @long;
            }

            @long:
            ComponentStorageBase[] comps = Components;
            for (int i = 9; i < comps.Length; i++) comps[i].Delete(args);


            len9:
            Unsafe.Add(ref first, 8).Delete(args);
            len8:
            Unsafe.Add(ref first, 7).Delete(args);
            len7:
            Unsafe.Add(ref first, 6).Delete(args);
            len6:
            Unsafe.Add(ref first, 5).Delete(args);
            len5:
            Unsafe.Add(ref first, 4).Delete(args);
            len4:
            Unsafe.Add(ref first, 3).Delete(args);
            len3:
            Unsafe.Add(ref first, 2).Delete(args);
            len2:
            Unsafe.Add(ref first, 1).Delete(args);



            end:

            return _entities.UnsafeArrayIndex(args.ToIndex) = _entities.UnsafeArrayIndex(args.FromIndex);
        }

        /// <summary>
        ///     Updates the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        internal void Update(Scene scene)
        {
            if (NextComponentIndex == 0)
                return;
            ComponentStorageBase[] comprunners = Components;
            for (int i = 1; i < comprunners.Length; i++)
                comprunners[i].Run(scene, this);
        }

        /// <summary>
        ///     Updates the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        internal void Update(Scene scene, int start, int length)
        {
            if (NextComponentIndex == 0)
                return;
            ComponentStorageBase[] comprunners = Components;
            for (int i = 1; i < comprunners.Length; i++)
                comprunners[i].Run(scene, this, start, length);
        }

        /// <summary>
        ///     Releases the arrays
        /// </summary>
        internal void ReleaseArrays()
        {
            _entities = [];
            ComponentStorageBase[] comprunners = Components;
            for (int i = 1; i < comprunners.Length; i++)
                comprunners[i].Trim(0);
        }

        /// <summary>
        ///     Gets the component index
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The int</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal int GetComponentIndex<T>()
        {
            ushort index = Component<T>.Id.RawIndex;
            return ComponentTagTable.UnsafeArrayIndex(index) & GlobalWorldTables.IndexBits;
        }

        /// <summary>
        ///     Gets the component index using the specified component
        /// </summary>
        /// <param name="component">The component</param>
        /// <returns>The int</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal int GetComponentIndex(ComponentId component)
        {
            return ComponentTagTable.UnsafeArrayIndex(component.RawIndex) & GlobalWorldTables.IndexBits;
        }

        /// <summary>
        ///     Hases the tag
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The bool</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal bool HasTag<T>()
        {
            ushort index = Tag<T>.Id.RawValue;
            return ComponentTagTable.UnsafeArrayIndex(index) << 7 != 0;
        }

        /// <summary>
        ///     Hases the tag using the specified tag id
        /// </summary>
        /// <param name="tagId">The tag id</param>
        /// <returns>The bool</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal bool HasTag(TagId tagId)
        {
            return ComponentTagTable.UnsafeArrayIndex(tagId.RawValue) << 7 != 0;
        }

        /// <summary>
        ///     Gets the gameObject span
        /// </summary>
        /// <returns>A span of gameObject id only</returns>
        internal Span<GameObjectIdOnly> GetEntitySpan()
        {
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
            return _entities.AsSpan(0, NextComponentIndex);
#else
        return MemoryMarshal.CreateSpan(ref MemoryMarshal.GetArrayDataReference(_entities), NextComponentIndex);
#endif
        }

        /// <summary>
        ///     Gets the gameObject data reference
        /// </summary>
        /// <returns>The ref gameObject id only</returns>
        internal ref GameObjectIdOnly GetEntityDataReference()
        {
            return ref MemoryMarshal.GetArrayDataReference(_entities);
        }

        /// <summary>
        ///     The fields
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        
        public struct Fields
        {
            /// <summary>
            ///     The map
            /// </summary>
            internal byte[] Map;

            /// <summary>
            ///     The components
            /// </summary>
            internal ComponentStorageBase[] Components;

            /// <summary>
            ///     Gets the component data reference
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <returns>The ref</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal ref T GetComponentDataReference<T>()
            {
                int index = Map.UnsafeArrayIndex(Component<T>.Id.RawIndex);
                return ref UnsafeExtensions.UnsafeCast<ComponentStorage<T>>(Components.UnsafeArrayIndex(index))
                    .GetComponentStorageDataReference();
            }
        }
    }
}