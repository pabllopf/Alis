// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NeighborCache.cs
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
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Redifinition;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The neighbor cache core class
    /// </summary>
    internal static class NeighborCacheCore
    {
        /// <summary>
        ///     Modifies the components
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FastImmutableArray<ComponentId> Modify(
            FastImmutableArray<ComponentId> components,
            ReadOnlySpan<ComponentId> ids,
            bool add)
            => add
                ? MemoryHelpers.Concat(components, ids)
                : MemoryHelpers.Remove(components, ids);

        /// <summary>
        ///     Modifies the single using the specified components
        /// </summary>
        /// <param name="components">The components</param>
        /// <param name="id">The id</param>
        /// <param name="add">The add</param>
        /// <returns>A fast immutable array of component id</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FastImmutableArray<ComponentId> ModifySingle(
            FastImmutableArray<ComponentId> components,
            ComponentId id,
            bool add)
            => add
                ? MemoryHelpers.Concat(components, id)
                : MemoryHelpers.Remove(components, id);
    }

    /// <summary>
    ///     Non-generic registry for <c>ArchetypeNeighborCache</c> values keyed by closed generic type handle.
    ///     Avoids S2743 (static fields in generic types) by storing all caches in a flat array.
    /// </summary>
    internal static class NeighborCacheRegistry
    {
        private static readonly ConcurrentDictionary<RuntimeTypeHandle, int> Indices = new();
        private static ArchetypeNeighborCache[] Caches = new ArchetypeNeighborCache[256];
        private static int Count;
        private static readonly object ResizeLock = new();

        /// <summary>
        ///     Gets or creates the <c>ArchetypeNeighborCache</c> for the given closed generic type handle.
        ///     Returns a <see cref="ref"/> to the cache, allowing mutation via <c>TraverseThroughCacheOrCreate</c>.
        /// </summary>
        internal static ref ArchetypeNeighborCache GetOrCreate(RuntimeTypeHandle handle)
        {
            int index = Indices.GetOrAdd(handle, _ =>
            {
                int idx = Interlocked.Increment(ref Count) - 1;
                if (idx >= Caches.Length)
                {
                    lock (ResizeLock)
                    {
                        if (idx >= Caches.Length)
                        {
                            Array.Resize(ref Caches, Caches.Length * 2);
                        }
                    }
                }
                return idx;
            });
            return ref Caches[index];
        }
    }

    // ---------------------------------------------------------------------------

    /// <summary>
    ///     The neighbor cache component ids class
    /// </summary>
    internal static class NeighborCacheComponentIds<T1, T2>
    {
        /// <summary>
        ///     The id
        /// </summary>
        internal static readonly ComponentId[] Values = [Component<T1>.Id, Component<T2>.Id];
    }

    /// <summary>
    ///     The neighbor cache component ids class
    /// </summary>
    internal static class NeighborCacheComponentIds<T1, T2, T3>
    {
        /// <summary>
        ///     The id
        /// </summary>
        internal static readonly ComponentId[] Values = [Component<T1>.Id, Component<T2>.Id, Component<T3>.Id];
    }

    /// <summary>
    ///     The neighbor cache component ids class
    /// </summary>
    internal static class NeighborCacheComponentIds<T1, T2, T3, T4>
    {
        /// <summary>
        ///     The id
        /// </summary>
        internal static readonly ComponentId[] Values =
            [Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id];
    }

    /// <summary>
    ///     The neighbor cache component ids class
    /// </summary>
    internal static class NeighborCacheComponentIds<T1, T2, T3, T4, T5>
    {
        /// <summary>
        ///     The id
        /// </summary>
        internal static readonly ComponentId[] Values =
            [Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id, Component<T5>.Id];
    }

    /// <summary>
    ///     The neighbor cache component ids class
    /// </summary>
    internal static class NeighborCacheComponentIds<T1, T2, T3, T4, T5, T6>
    {
        /// <summary>
        ///     The id
        /// </summary>
        internal static readonly ComponentId[] Values =
        [
            Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id, Component<T5>.Id,
            Component<T6>.Id
        ];
    }

    /// <summary>
    ///     The neighbor cache component ids class
    /// </summary>
    internal static class NeighborCacheComponentIds<T1, T2, T3, T4, T5, T6, T7>
    {
        /// <summary>
        ///     The id
        /// </summary>
        internal static readonly ComponentId[] Values =
        [
            Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id, Component<T5>.Id,
            Component<T6>.Id, Component<T7>.Id
        ];
    }

    /// <summary>
    ///     The neighbor cache component ids class
    /// </summary>
    internal static class NeighborCacheComponentIds<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        /// <summary>
        ///     The id
        /// </summary>
        internal static readonly ComponentId[] Values =
        [
            Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id, Component<T5>.Id,
            Component<T6>.Id, Component<T7>.Id, Component<T8>.Id
        ];
    }

    // ---------------------------------------------------------------------------


    /// <summary>Add-edge neighbor cache for arity 1.</summary>
    internal static class NeighborCacheAdd<T1>
    {
        /// <summary>Returns a mutable reference to the cache for this closed generic type.</summary>
        internal static ref ArchetypeNeighborCache GetRef() =>
            ref NeighborCacheRegistry.GetOrCreate(typeof(NeighborCacheAdd<T1>).TypeHandle);
    }

    /// <summary>Remove-edge neighbor cache for arity 1.</summary>
    internal static class NeighborCacheRemove<T1>
    {
        /// <summary>Returns a mutable reference to the cache for this closed generic type.</summary>
        internal static ref ArchetypeNeighborCache GetRef() =>
            ref NeighborCacheRegistry.GetOrCreate(typeof(NeighborCacheRemove<T1>).TypeHandle);
    }

    /// <summary>Add-edge neighbor cache for arity 2.</summary>
    internal static class NeighborCacheAdd<T1, T2>
    {
        /// <summary>Returns a mutable reference to the cache for this closed generic type.</summary>
        internal static ref ArchetypeNeighborCache GetRef() =>
            ref NeighborCacheRegistry.GetOrCreate(typeof(NeighborCacheAdd<T1, T2>).TypeHandle);
    }

    /// <summary>Remove-edge neighbor cache for arity 2.</summary>
    internal static class NeighborCacheRemove<T1, T2>
    {
        /// <summary>Returns a mutable reference to the cache for this closed generic type.</summary>
        internal static ref ArchetypeNeighborCache GetRef() =>
            ref NeighborCacheRegistry.GetOrCreate(typeof(NeighborCacheRemove<T1, T2>).TypeHandle);
    }

    /// <summary>Add-edge neighbor cache for arity 3.</summary>
    internal static class NeighborCacheAdd<T1, T2, T3>
    {
        /// <summary>Returns a mutable reference to the cache for this closed generic type.</summary>
        internal static ref ArchetypeNeighborCache GetRef() =>
            ref NeighborCacheRegistry.GetOrCreate(typeof(NeighborCacheAdd<T1, T2, T3>).TypeHandle);
    }

    /// <summary>Remove-edge neighbor cache for arity 3.</summary>
    internal static class NeighborCacheRemove<T1, T2, T3>
    {
        /// <summary>Returns a mutable reference to the cache for this closed generic type.</summary>
        internal static ref ArchetypeNeighborCache GetRef() =>
            ref NeighborCacheRegistry.GetOrCreate(typeof(NeighborCacheRemove<T1, T2, T3>).TypeHandle);
    }

    /// <summary>Add-edge neighbor cache for arity 4.</summary>
    internal static class NeighborCacheAdd<T1, T2, T3, T4>
    {
        /// <summary>Returns a mutable reference to the cache for this closed generic type.</summary>
        internal static ref ArchetypeNeighborCache GetRef() =>
            ref NeighborCacheRegistry.GetOrCreate(typeof(NeighborCacheAdd<T1, T2, T3, T4>).TypeHandle);
    }

    /// <summary>Remove-edge neighbor cache for arity 4.</summary>
    internal static class NeighborCacheRemove<T1, T2, T3, T4>
    {
        /// <summary>Returns a mutable reference to the cache for this closed generic type.</summary>
        internal static ref ArchetypeNeighborCache GetRef() =>
            ref NeighborCacheRegistry.GetOrCreate(typeof(NeighborCacheRemove<T1, T2, T3, T4>).TypeHandle);
    }

    /// <summary>Add-edge neighbor cache for arity 5.</summary>
    internal static class NeighborCacheAdd<T1, T2, T3, T4, T5>
    {
        /// <summary>Returns a mutable reference to the cache for this closed generic type.</summary>
        internal static ref ArchetypeNeighborCache GetRef() =>
            ref NeighborCacheRegistry.GetOrCreate(typeof(NeighborCacheAdd<T1, T2, T3, T4, T5>).TypeHandle);
    }

    /// <summary>Remove-edge neighbor cache for arity 5.</summary>
    internal static class NeighborCacheRemove<T1, T2, T3, T4, T5>
    {
        /// <summary>Returns a mutable reference to the cache for this closed generic type.</summary>
        internal static ref ArchetypeNeighborCache GetRef() =>
            ref NeighborCacheRegistry.GetOrCreate(typeof(NeighborCacheRemove<T1, T2, T3, T4, T5>).TypeHandle);
    }

    /// <summary>Add-edge neighbor cache for arity 6.</summary>
    internal static class NeighborCacheAdd<T1, T2, T3, T4, T5, T6>
    {
        /// <summary>Returns a mutable reference to the cache for this closed generic type.</summary>
        internal static ref ArchetypeNeighborCache GetRef() =>
            ref NeighborCacheRegistry.GetOrCreate(typeof(NeighborCacheAdd<T1, T2, T3, T4, T5, T6>).TypeHandle);
    }

    /// <summary>Remove-edge neighbor cache for arity 6.</summary>
    internal static class NeighborCacheRemove<T1, T2, T3, T4, T5, T6>
    {
        /// <summary>Returns a mutable reference to the cache for this closed generic type.</summary>
        internal static ref ArchetypeNeighborCache GetRef() =>
            ref NeighborCacheRegistry.GetOrCreate(typeof(NeighborCacheRemove<T1, T2, T3, T4, T5, T6>).TypeHandle);
    }

    /// <summary>Add-edge neighbor cache for arity 7.</summary>
    internal static class NeighborCacheAdd<T1, T2, T3, T4, T5, T6, T7>
    {
        /// <summary>Returns a mutable reference to the cache for this closed generic type.</summary>
        internal static ref ArchetypeNeighborCache GetRef() =>
            ref NeighborCacheRegistry.GetOrCreate(typeof(NeighborCacheAdd<T1, T2, T3, T4, T5, T6, T7>).TypeHandle);
    }

    /// <summary>Remove-edge neighbor cache for arity 7.</summary>
    internal static class NeighborCacheRemove<T1, T2, T3, T4, T5, T6, T7>
    {
        /// <summary>Returns a mutable reference to the cache for this closed generic type.</summary>
        internal static ref ArchetypeNeighborCache GetRef() =>
            ref NeighborCacheRegistry.GetOrCreate(typeof(NeighborCacheRemove<T1, T2, T3, T4, T5, T6, T7>).TypeHandle);
    }

    /// <summary>Add-edge neighbor cache for arity 8.</summary>
    internal static class NeighborCacheAdd<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        /// <summary>Returns a mutable reference to the cache for this closed generic type.</summary>
        internal static ref ArchetypeNeighborCache GetRef() =>
            ref NeighborCacheRegistry.GetOrCreate(typeof(NeighborCacheAdd<T1, T2, T3, T4, T5, T6, T7, T8>).TypeHandle);
    }

    /// <summary>Remove-edge neighbor cache for arity 8.</summary>
    internal static class NeighborCacheRemove<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        /// <summary>Returns a mutable reference to the cache for this closed generic type.</summary>
        internal static ref ArchetypeNeighborCache GetRef() =>
            ref NeighborCacheRegistry.GetOrCreate(typeof(NeighborCacheRemove<T1, T2, T3, T4, T5, T6, T7, T8>).TypeHandle);
    }

    // ---------------------------------------------------------------------------

    /// <summary>The neighbor cache (arity 8).</summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NeighborCache<T1, T2, T3, T4, T5, T6, T7, T8> : IArchetypeGraphEdge
    {
        /// <summary>Modifies the components using the specified components.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ModifyComponents(ref FastImmutableArray<ComponentId> components, bool add)
            => components = NeighborCacheCore.Modify(components, NeighborCacheComponentIds<T1, T2, T3, T4, T5, T6, T7, T8>.Values, add);
    }

    /// <summary>The neighbor cache (arity 7).</summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NeighborCache<T1, T2, T3, T4, T5, T6, T7> : IArchetypeGraphEdge
    {
        /// <summary>Modifies the components using the specified components.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ModifyComponents(ref FastImmutableArray<ComponentId> components, bool add)
            => components = NeighborCacheCore.Modify(components, NeighborCacheComponentIds<T1, T2, T3, T4, T5, T6, T7>.Values, add);
    }

    /// <summary>The neighbor cache (arity 6).</summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NeighborCache<T1, T2, T3, T4, T5, T6> : IArchetypeGraphEdge
    {
        /// <summary>Modifies the components using the specified components.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ModifyComponents(ref FastImmutableArray<ComponentId> components, bool add)
            => components = NeighborCacheCore.Modify(components, NeighborCacheComponentIds<T1, T2, T3, T4, T5, T6>.Values, add);
    }

    /// <summary>The neighbor cache (arity 5).</summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NeighborCache<T1, T2, T3, T4, T5> : IArchetypeGraphEdge
    {
        /// <summary>Modifies the components using the specified components.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ModifyComponents(ref FastImmutableArray<ComponentId> components, bool add)
            => components = NeighborCacheCore.Modify(components, NeighborCacheComponentIds<T1, T2, T3, T4, T5>.Values, add);
    }

    /// <summary>The neighbor cache (arity 4).</summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NeighborCache<T1, T2, T3, T4> : IArchetypeGraphEdge
    {
        /// <summary>Modifies the components using the specified components.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ModifyComponents(ref FastImmutableArray<ComponentId> components, bool add)
            => components = NeighborCacheCore.Modify(components, NeighborCacheComponentIds<T1, T2, T3, T4>.Values, add);
    }

    /// <summary>The neighbor cache (arity 3).</summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NeighborCache<T1, T2, T3> : IArchetypeGraphEdge
    {
        /// <summary>Modifies the components using the specified components.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ModifyComponents(ref FastImmutableArray<ComponentId> components, bool add)
            => components = NeighborCacheCore.Modify(components, NeighborCacheComponentIds<T1, T2, T3>.Values, add);
    }

    /// <summary>The neighbor cache (arity 2).</summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NeighborCache<T1, T2> : IArchetypeGraphEdge
    {
        /// <summary>Modifies the components using the specified components.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ModifyComponents(ref FastImmutableArray<ComponentId> components, bool add)
            => components = NeighborCacheCore.Modify(components, NeighborCacheComponentIds<T1, T2>.Values, add);
    }

    /// <summary>The neighbor cache (arity 1).</summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NeighborCache<T> : IArchetypeGraphEdge
    {
        /// <summary>Modifies the components using the specified components.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ModifyComponents(ref FastImmutableArray<ComponentId> components, bool add)
            => components = NeighborCacheCore.ModifySingle(components, Component<T>.Id, add);
    }
}