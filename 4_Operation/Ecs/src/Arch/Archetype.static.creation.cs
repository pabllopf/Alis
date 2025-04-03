// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Archetype_Creation.cs
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
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Memory;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs.Arch
{
      /// <summary>
      /// The archetype class
      /// </summary>
      internal static class Archetype<T1, T2>
  {
      /// <summary>
      /// The id
      /// </summary>
      public static readonly FastImmutableArray<ComponentID> ArchetypeComponentIDs = new FastImmutableArray<ComponentID>(new[]
      {
          Component<T1>.ID,
          Component<T2>.ID
      });
    /// <summary>
    /// The empty
    /// </summary>
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    /// <summary>
    /// Creates the new or get existing archetype using the specified world
    /// </summary>
    /// <param name="world">The world</param>
    /// <returns>The local</returns>
    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex(rawIndex);
      if (local == null)
        local = CreateArchetype(world);
      return local;

      [MethodImpl(MethodImplOptions.NoInlining)]
      static Archetype CreateArchetype(World world)
      {
        ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2>.ArchetypeComponentIDs.Length + 1];
        ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[Archetype<T1, T2>.ID.RawIndex];
        int index1 = arr.UnsafeArrayIndex(Component<T1>.ID.RawIndex) & sbyte.MaxValue;
        components[index1] = Component<T1>.CreateInstance(1);
        createBuffers[index1] = Component<T1>.CreateInstance(0);
        int index2 = arr.UnsafeArrayIndex(Component<T2>.ID.RawIndex) & sbyte.MaxValue;
        components[index2] = Component<T2>.CreateInstance(1);
        createBuffers[index2] = Component<T2>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    /// <summary>
    /// The of component class
    /// </summary>
    internal static class OfComponent<C>
    {
      /// <summary>
      /// The id
      /// </summary>
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2>.ID, Component<C>.ID);
    }
  }
    
    /// <summary>
    /// The archetype class
    /// </summary>
    internal static class Archetype<T1, T2, T3>
  {
   /// <summary>
   /// The id
   /// </summary>
   public static readonly FastImmutableArray<ComponentID> ArchetypeComponentIDs = new FastImmutableArray<ComponentID>(new[]
   {
       Component<T1>.ID,
       Component<T2>.ID,
       Component<T3>.ID
   });
    
    /// <summary>
    /// The empty
    /// </summary>
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    /// <summary>
    /// Creates the new or get existing archetype using the specified world
    /// </summary>
    /// <param name="world">The world</param>
    /// <returns>The local</returns>
    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2, T3>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex(rawIndex);
      if (local == null)
      {
          local = CreateArchetype(world);
      }

      return local;

      [MethodImpl(MethodImplOptions.NoInlining)]
      static Archetype CreateArchetype(World world)
      {
        ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2, T3>.ArchetypeComponentIDs.Length + 1];
        ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[Archetype<T1, T2, T3>.ID.RawIndex];
        int index1 = arr.UnsafeArrayIndex(Component<T1>.ID.RawIndex) & sbyte.MaxValue;
        components[index1] = Component<T1>.CreateInstance(1);
        createBuffers[index1] = Component<T1>.CreateInstance(0);
        int index2 = arr.UnsafeArrayIndex(Component<T2>.ID.RawIndex) & sbyte.MaxValue;
        components[index2] = Component<T2>.CreateInstance(1);
        createBuffers[index2] = Component<T2>.CreateInstance(0);
        int index3 = arr.UnsafeArrayIndex(Component<T3>.ID.RawIndex) & sbyte.MaxValue;
        components[index3] = Component<T3>.CreateInstance(1);
        createBuffers[index3] = Component<T3>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2, T3>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    /// <summary>
    /// The of component class
    /// </summary>
    internal static class OfComponent<TC>
    {
      /// <summary>
      /// The id
      /// </summary>
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3>.ID, Component<TC>.ID);
    }
  }
    
    /// <summary>
    /// The archetype class
    /// </summary>
    internal static class Archetype<T1, T2, T3, T4>
  {
    /// <summary>
    /// The id
    /// </summary>
    public static readonly FastImmutableArray<ComponentID> ArchetypeComponentIDs = new FastImmutableArray<ComponentID>(new[]
    {
      Component<T1>.ID,
      Component<T2>.ID,
      Component<T3>.ID,
      Component<T4>.ID
    });
    
    /// <summary>
    /// The empty
    /// </summary>
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3, T4>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3, T4>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    /// <summary>
    /// Creates the new or get existing archetype using the specified world
    /// </summary>
    /// <param name="world">The world</param>
    /// <returns>The local</returns>
    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2, T3, T4>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex(rawIndex);
      if (local == null)
        local = CreateArchetype(world);
      return local;

      [MethodImpl(MethodImplOptions.NoInlining)]
      static Archetype CreateArchetype(World world)
      {
        ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2, T3, T4>.ArchetypeComponentIDs.Length + 1];
        ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[Archetype<T1, T2, T3, T4>.ID.RawIndex];
        int index1 = arr.UnsafeArrayIndex(Component<T1>.ID.RawIndex) & sbyte.MaxValue;
        components[index1] = Component<T1>.CreateInstance(1);
        createBuffers[index1] = Component<T1>.CreateInstance(0);
        int index2 = arr.UnsafeArrayIndex(Component<T2>.ID.RawIndex) & sbyte.MaxValue;
        components[index2] = Component<T2>.CreateInstance(1);
        createBuffers[index2] = Component<T2>.CreateInstance(0);
        int index3 = arr.UnsafeArrayIndex(Component<T3>.ID.RawIndex) & sbyte.MaxValue;
        components[index3] = Component<T3>.CreateInstance(1);
        createBuffers[index3] = Component<T3>.CreateInstance(0);
        int index4 = arr.UnsafeArrayIndex(Component<T4>.ID.RawIndex) & sbyte.MaxValue;
        components[index4] = Component<T4>.CreateInstance(1);
        createBuffers[index4] = Component<T4>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2, T3, T4>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    /// <summary>
    /// The of component class
    /// </summary>
    internal static class OfComponent<C>
    {
      /// <summary>
      /// The id
      /// </summary>
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4>.ID, Component<C>.ID);
    }
  }
    
      /// <summary>
      /// The archetype class
      /// </summary>
      internal static class Archetype<T1, T2, T3, T4, T5>
  {
    /// <summary>
    /// The id
    /// </summary>
    public static readonly FastImmutableArray<ComponentID> ArchetypeComponentIDs = new FastImmutableArray<ComponentID>(new[]
    {
      Component<T1>.ID,
      Component<T2>.ID,
      Component<T3>.ID,
      Component<T4>.ID,
      Component<T5>.ID
    });
    /// <summary>
    /// The empty
    /// </summary>
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3, T4, T5>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3, T4, T5>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    /// <summary>
    /// Creates the new or get existing archetype using the specified world
    /// </summary>
    /// <param name="world">The world</param>
    /// <returns>The local</returns>
    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2, T3, T4, T5>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex(rawIndex);
      if (local == null)
        local = CreateArchetype(world);
      return local;

      [MethodImpl(MethodImplOptions.NoInlining)]
      static Archetype CreateArchetype(World world)
      {
        ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2, T3, T4, T5>.ArchetypeComponentIDs.Length + 1];
        ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[Archetype<T1, T2, T3, T4, T5>.ID.RawIndex];
        int index1 = arr.UnsafeArrayIndex(Component<T1>.ID.RawIndex) & sbyte.MaxValue;
        components[index1] = Component<T1>.CreateInstance(1);
        createBuffers[index1] = Component<T1>.CreateInstance(0);
        int index2 = arr.UnsafeArrayIndex(Component<T2>.ID.RawIndex) & sbyte.MaxValue;
        components[index2] = Component<T2>.CreateInstance(1);
        createBuffers[index2] = Component<T2>.CreateInstance(0);
        int index3 = arr.UnsafeArrayIndex(Component<T3>.ID.RawIndex) & sbyte.MaxValue;
        components[index3] = Component<T3>.CreateInstance(1);
        createBuffers[index3] = Component<T3>.CreateInstance(0);
        int index4 = arr.UnsafeArrayIndex(Component<T4>.ID.RawIndex) & sbyte.MaxValue;
        components[index4] = Component<T4>.CreateInstance(1);
        createBuffers[index4] = Component<T4>.CreateInstance(0);
        int index5 = arr.UnsafeArrayIndex(Component<T5>.ID.RawIndex) & sbyte.MaxValue;
        components[index5] = Component<T5>.CreateInstance(1);
        createBuffers[index5] = Component<T5>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2, T3, T4, T5>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    /// <summary>
    /// The of component class
    /// </summary>
    internal static class OfComponent<C>
    {
      /// <summary>
      /// The id
      /// </summary>
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5>.ID, Component<C>.ID);
    }
  }
      
        /// <summary>
        /// The archetype class
        /// </summary>
        internal static class Archetype<T1, T2, T3, T4, T5, T6>
  {
    /// <summary>
    /// The id
    /// </summary>
    public static readonly FastImmutableArray<ComponentID> ArchetypeComponentIDs = new FastImmutableArray<ComponentID>(new[]
    {
      Component<T1>.ID,
      Component<T2>.ID,
      Component<T3>.ID,
      Component<T4>.ID,
      Component<T5>.ID,
      Component<T6>.ID
    });
    /// <summary>
    /// The empty
    /// </summary>
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3, T4, T5, T6>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3, T4, T5, T6>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    /// <summary>
    /// Creates the new or get existing archetype using the specified world
    /// </summary>
    /// <param name="world">The world</param>
    /// <returns>The local</returns>
    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2, T3, T4, T5, T6>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex(rawIndex);
      if (local == null)
        local = CreateArchetype(world);
      return local;

      [MethodImpl(MethodImplOptions.NoInlining)]
      static Archetype CreateArchetype(World world)
      {
        ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2, T3, T4, T5, T6>.ArchetypeComponentIDs.Length + 1];
        ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[Archetype<T1, T2, T3, T4, T5, T6>.ID.RawIndex];
        int index1 = arr.UnsafeArrayIndex(Component<T1>.ID.RawIndex) & sbyte.MaxValue;
        components[index1] = Component<T1>.CreateInstance(1);
        createBuffers[index1] = Component<T1>.CreateInstance(0);
        int index2 = arr.UnsafeArrayIndex(Component<T2>.ID.RawIndex) & sbyte.MaxValue;
        components[index2] = Component<T2>.CreateInstance(1);
        createBuffers[index2] = Component<T2>.CreateInstance(0);
        int index3 = arr.UnsafeArrayIndex(Component<T3>.ID.RawIndex) & sbyte.MaxValue;
        components[index3] = Component<T3>.CreateInstance(1);
        createBuffers[index3] = Component<T3>.CreateInstance(0);
        int index4 = arr.UnsafeArrayIndex(Component<T4>.ID.RawIndex) & sbyte.MaxValue;
        components[index4] = Component<T4>.CreateInstance(1);
        createBuffers[index4] = Component<T4>.CreateInstance(0);
        int index5 = arr.UnsafeArrayIndex(Component<T5>.ID.RawIndex) & sbyte.MaxValue;
        components[index5] = Component<T5>.CreateInstance(1);
        createBuffers[index5] = Component<T5>.CreateInstance(0);
        int index6 = arr.UnsafeArrayIndex(Component<T6>.ID.RawIndex) & sbyte.MaxValue;
        components[index6] = Component<T6>.CreateInstance(1);
        createBuffers[index6] = Component<T6>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2, T3, T4, T5, T6>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    /// <summary>
    /// The of component class
    /// </summary>
    internal static class OfComponent<C>
    {
      /// <summary>
      /// The id
      /// </summary>
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5, T6>.ID, Component<C>.ID);
    }
  }
        
          /// <summary>
          /// The archetype class
          /// </summary>
          internal static class Archetype<T1, T2, T3, T4, T5, T6, T7>
  {
    /// <summary>
    /// The id
    /// </summary>
    public static readonly FastImmutableArray<ComponentID> ArchetypeComponentIDs = new FastImmutableArray<ComponentID>(new[]
    {
      Component<T1>.ID,
      Component<T2>.ID,
      Component<T3>.ID,
      Component<T4>.ID,
      Component<T5>.ID,
      Component<T6>.ID,
      Component<T7>.ID
    });
    /// <summary>
    /// The empty
    /// </summary>
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3, T4, T5, T6, T7>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3, T4, T5, T6, T7>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    /// <summary>
    /// Creates the new or get existing archetype using the specified world
    /// </summary>
    /// <param name="world">The world</param>
    /// <returns>The local</returns>
    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2, T3, T4, T5, T6, T7>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex(rawIndex);
      if (local == null)
        local = CreateArchetype(world);
      return local;

      [MethodImpl(MethodImplOptions.NoInlining)]
      static Archetype CreateArchetype(World world)
      {
        ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2, T3, T4, T5, T6, T7>.ArchetypeComponentIDs.Length + 1];
        ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[Archetype<T1, T2, T3, T4, T5, T6, T7>.ID.RawIndex];
        int index1 = arr.UnsafeArrayIndex(Component<T1>.ID.RawIndex) & sbyte.MaxValue;
        components[index1] = Component<T1>.CreateInstance(1);
        createBuffers[index1] = Component<T1>.CreateInstance(0);
        int index2 = arr.UnsafeArrayIndex(Component<T2>.ID.RawIndex) & sbyte.MaxValue;
        components[index2] = Component<T2>.CreateInstance(1);
        createBuffers[index2] = Component<T2>.CreateInstance(0);
        int index3 = arr.UnsafeArrayIndex(Component<T3>.ID.RawIndex) & sbyte.MaxValue;
        components[index3] = Component<T3>.CreateInstance(1);
        createBuffers[index3] = Component<T3>.CreateInstance(0);
        int index4 = arr.UnsafeArrayIndex(Component<T4>.ID.RawIndex) & sbyte.MaxValue;
        components[index4] = Component<T4>.CreateInstance(1);
        createBuffers[index4] = Component<T4>.CreateInstance(0);
        int index5 = arr.UnsafeArrayIndex(Component<T5>.ID.RawIndex) & sbyte.MaxValue;
        components[index5] = Component<T5>.CreateInstance(1);
        createBuffers[index5] = Component<T5>.CreateInstance(0);
        int index6 = arr.UnsafeArrayIndex(Component<T6>.ID.RawIndex) & sbyte.MaxValue;
        components[index6] = Component<T6>.CreateInstance(1);
        createBuffers[index6] = Component<T6>.CreateInstance(0);
        int index7 = arr.UnsafeArrayIndex(Component<T7>.ID.RawIndex) & sbyte.MaxValue;
        components[index7] = Component<T7>.CreateInstance(1);
        createBuffers[index7] = Component<T7>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2, T3, T4, T5, T6, T7>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    /// <summary>
    /// The of component class
    /// </summary>
    internal static class OfComponent<C>
    {
      /// <summary>
      /// The id
      /// </summary>
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5, T6, T7>.ID, Component<C>.ID);
    }
  }
          
            /// <summary>
            /// The archetype class
            /// </summary>
            internal static class Archetype<T1, T2, T3, T4, T5, T6, T7, T8>
  {
    /// <summary>
    /// The id
    /// </summary>
    public static readonly FastImmutableArray<ComponentID> ArchetypeComponentIDs = new FastImmutableArray<ComponentID>(new[]
    {
      Component<T1>.ID,
      Component<T2>.ID,
      Component<T3>.ID,
      Component<T4>.ID,
      Component<T5>.ID,
      Component<T6>.ID,
      Component<T7>.ID,
      Component<T8>.ID
    });
    /// <summary>
    /// The empty
    /// </summary>
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3, T4, T5, T6, T7, T8>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3, T4, T5, T6, T7, T8>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    /// <summary>
    /// Creates the new or get existing archetype using the specified world
    /// </summary>
    /// <param name="world">The world</param>
    /// <returns>The local</returns>
    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2, T3, T4, T5, T6, T7, T8>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex(rawIndex);
      if (local == null)
        local = CreateArchetype(world);
      return local;

      [MethodImpl(MethodImplOptions.NoInlining)]
      static Archetype CreateArchetype(World world)
      {
        ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2, T3, T4, T5, T6, T7, T8>.ArchetypeComponentIDs.Length + 1];
        ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[Archetype<T1, T2, T3, T4, T5, T6, T7, T8>.ID.RawIndex];
        int index1 = arr.UnsafeArrayIndex(Component<T1>.ID.RawIndex) & sbyte.MaxValue;
        components[index1] = Component<T1>.CreateInstance(1);
        createBuffers[index1] = Component<T1>.CreateInstance(0);
        int index2 = arr.UnsafeArrayIndex(Component<T2>.ID.RawIndex) & sbyte.MaxValue;
        components[index2] = Component<T2>.CreateInstance(1);
        createBuffers[index2] = Component<T2>.CreateInstance(0);
        int index3 = arr.UnsafeArrayIndex(Component<T3>.ID.RawIndex) & sbyte.MaxValue;
        components[index3] = Component<T3>.CreateInstance(1);
        createBuffers[index3] = Component<T3>.CreateInstance(0);
        int index4 = arr.UnsafeArrayIndex(Component<T4>.ID.RawIndex) & sbyte.MaxValue;
        components[index4] = Component<T4>.CreateInstance(1);
        createBuffers[index4] = Component<T4>.CreateInstance(0);
        int index5 = arr.UnsafeArrayIndex(Component<T5>.ID.RawIndex) & sbyte.MaxValue;
        components[index5] = Component<T5>.CreateInstance(1);
        createBuffers[index5] = Component<T5>.CreateInstance(0);
        int index6 = arr.UnsafeArrayIndex(Component<T6>.ID.RawIndex) & sbyte.MaxValue;
        components[index6] = Component<T6>.CreateInstance(1);
        createBuffers[index6] = Component<T6>.CreateInstance(0);
        int index7 = arr.UnsafeArrayIndex(Component<T7>.ID.RawIndex) & sbyte.MaxValue;
        components[index7] = Component<T7>.CreateInstance(1);
        createBuffers[index7] = Component<T7>.CreateInstance(0);
        int index8 = arr.UnsafeArrayIndex(Component<T8>.ID.RawIndex) & sbyte.MaxValue;
        components[index8] = Component<T8>.CreateInstance(1);
        createBuffers[index8] = Component<T8>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2, T3, T4, T5, T6, T7, T8>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    /// <summary>
    /// The of component class
    /// </summary>
    internal static class OfComponent<C>
    {
      /// <summary>
      /// The id
      /// </summary>
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8>.ID, Component<C>.ID);
    }
  }
            
              /// <summary>
              /// The archetype class
              /// </summary>
              internal static class Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9>
  {
    /// <summary>
    /// The id
    /// </summary>
    public static readonly FastImmutableArray<ComponentID> ArchetypeComponentIDs = new FastImmutableArray<ComponentID>(new[]
    {
      Component<T1>.ID,
      Component<T2>.ID,
      Component<T3>.ID,
      Component<T4>.ID,
      Component<T5>.ID,
      Component<T6>.ID,
      Component<T7>.ID,
      Component<T8>.ID,
      Component<T9>.ID
    });
    /// <summary>
    /// The empty
    /// </summary>
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    /// <summary>
    /// Creates the new or get existing archetype using the specified world
    /// </summary>
    /// <param name="world">The world</param>
    /// <returns>The local</returns>
    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex(rawIndex);
      if (local == null)
        local = CreateArchetype(world);
      return local;

      [MethodImpl(MethodImplOptions.NoInlining)]
      static Archetype CreateArchetype(World world)
      {
        ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9>.ArchetypeComponentIDs.Length + 1];
        ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9>.ID.RawIndex];
        int index1 = arr.UnsafeArrayIndex(Component<T1>.ID.RawIndex) & sbyte.MaxValue;
        components[index1] = Component<T1>.CreateInstance(1);
        createBuffers[index1] = Component<T1>.CreateInstance(0);
        int index2 = arr.UnsafeArrayIndex(Component<T2>.ID.RawIndex) & sbyte.MaxValue;
        components[index2] = Component<T2>.CreateInstance(1);
        createBuffers[index2] = Component<T2>.CreateInstance(0);
        int index3 = arr.UnsafeArrayIndex(Component<T3>.ID.RawIndex) & sbyte.MaxValue;
        components[index3] = Component<T3>.CreateInstance(1);
        createBuffers[index3] = Component<T3>.CreateInstance(0);
        int index4 = arr.UnsafeArrayIndex(Component<T4>.ID.RawIndex) & sbyte.MaxValue;
        components[index4] = Component<T4>.CreateInstance(1);
        createBuffers[index4] = Component<T4>.CreateInstance(0);
        int index5 = arr.UnsafeArrayIndex(Component<T5>.ID.RawIndex) & sbyte.MaxValue;
        components[index5] = Component<T5>.CreateInstance(1);
        createBuffers[index5] = Component<T5>.CreateInstance(0);
        int index6 = arr.UnsafeArrayIndex(Component<T6>.ID.RawIndex) & sbyte.MaxValue;
        components[index6] = Component<T6>.CreateInstance(1);
        createBuffers[index6] = Component<T6>.CreateInstance(0);
        int index7 = arr.UnsafeArrayIndex(Component<T7>.ID.RawIndex) & sbyte.MaxValue;
        components[index7] = Component<T7>.CreateInstance(1);
        createBuffers[index7] = Component<T7>.CreateInstance(0);
        int index8 = arr.UnsafeArrayIndex(Component<T8>.ID.RawIndex) & sbyte.MaxValue;
        components[index8] = Component<T8>.CreateInstance(1);
        createBuffers[index8] = Component<T8>.CreateInstance(0);
        int index9 = arr.UnsafeArrayIndex(Component<T9>.ID.RawIndex) & sbyte.MaxValue;
        components[index9] = Component<T9>.CreateInstance(1);
        createBuffers[index9] = Component<T9>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    /// <summary>
    /// The of component class
    /// </summary>
    internal static class OfComponent<C>
    {
      /// <summary>
      /// The id
      /// </summary>
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9>.ID, Component<C>.ID);
    }
  }
              
               /// <summary>
               /// The archetype class
               /// </summary>
               internal static class Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
  {
    /// <summary>
    /// The id
    /// </summary>
    public static readonly FastImmutableArray<ComponentID> ArchetypeComponentIDs = new FastImmutableArray<ComponentID>(new[]
    {
      Component<T1>.ID,
      Component<T2>.ID,
      Component<T3>.ID,
      Component<T4>.ID,
      Component<T5>.ID,
      Component<T6>.ID,
      Component<T7>.ID,
      Component<T8>.ID,
      Component<T9>.ID,
      Component<T10>.ID
    });
    /// <summary>
    /// The empty
    /// </summary>
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    /// <summary>
    /// Creates the new or get existing archetype using the specified world
    /// </summary>
    /// <param name="world">The world</param>
    /// <returns>The local</returns>
    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex(rawIndex);
      if (local == null)
        local = CreateArchetype(world);
      return local;

      [MethodImpl(MethodImplOptions.NoInlining)]
      static Archetype CreateArchetype(World world)
      {
        ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.ArchetypeComponentIDs.Length + 1];
        ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.ID.RawIndex];
        int index1 = arr.UnsafeArrayIndex(Component<T1>.ID.RawIndex) & sbyte.MaxValue;
        components[index1] = Component<T1>.CreateInstance(1);
        createBuffers[index1] = Component<T1>.CreateInstance(0);
        int index2 = arr.UnsafeArrayIndex(Component<T2>.ID.RawIndex) & sbyte.MaxValue;
        components[index2] = Component<T2>.CreateInstance(1);
        createBuffers[index2] = Component<T2>.CreateInstance(0);
        int index3 = arr.UnsafeArrayIndex(Component<T3>.ID.RawIndex) & sbyte.MaxValue;
        components[index3] = Component<T3>.CreateInstance(1);
        createBuffers[index3] = Component<T3>.CreateInstance(0);
        int index4 = arr.UnsafeArrayIndex(Component<T4>.ID.RawIndex) & sbyte.MaxValue;
        components[index4] = Component<T4>.CreateInstance(1);
        createBuffers[index4] = Component<T4>.CreateInstance(0);
        int index5 = arr.UnsafeArrayIndex(Component<T5>.ID.RawIndex) & sbyte.MaxValue;
        components[index5] = Component<T5>.CreateInstance(1);
        createBuffers[index5] = Component<T5>.CreateInstance(0);
        int index6 = arr.UnsafeArrayIndex(Component<T6>.ID.RawIndex) & sbyte.MaxValue;
        components[index6] = Component<T6>.CreateInstance(1);
        createBuffers[index6] = Component<T6>.CreateInstance(0);
        int index7 = arr.UnsafeArrayIndex(Component<T7>.ID.RawIndex) & sbyte.MaxValue;
        components[index7] = Component<T7>.CreateInstance(1);
        createBuffers[index7] = Component<T7>.CreateInstance(0);
        int index8 = arr.UnsafeArrayIndex(Component<T8>.ID.RawIndex) & sbyte.MaxValue;
        components[index8] = Component<T8>.CreateInstance(1);
        createBuffers[index8] = Component<T8>.CreateInstance(0);
        int index9 = arr.UnsafeArrayIndex(Component<T9>.ID.RawIndex) & sbyte.MaxValue;
        components[index9] = Component<T9>.CreateInstance(1);
        createBuffers[index9] = Component<T9>.CreateInstance(0);
        int index10 = arr.UnsafeArrayIndex(Component<T10>.ID.RawIndex) & sbyte.MaxValue;
        components[index10] = Component<T10>.CreateInstance(1);
        createBuffers[index10] = Component<T10>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    /// <summary>
    /// The of component class
    /// </summary>
    internal static class OfComponent<C>
    {
      /// <summary>
      /// The id
      /// </summary>
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.ID, Component<C>.ID);
    }
  }
               
                 /// <summary>
                 /// The archetype class
                 /// </summary>
                 internal static class Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
  {
    /// <summary>
    /// The id
    /// </summary>
    public static readonly FastImmutableArray<ComponentID> ArchetypeComponentIDs = new FastImmutableArray<ComponentID>(new[]
    {
      Component<T1>.ID,
      Component<T2>.ID,
      Component<T3>.ID,
      Component<T4>.ID,
      Component<T5>.ID,
      Component<T6>.ID,
      Component<T7>.ID,
      Component<T8>.ID,
      Component<T9>.ID,
      Component<T10>.ID,
      Component<T11>.ID
    });
    /// <summary>
    /// The empty
    /// </summary>
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    /// <summary>
    /// Creates the new or get existing archetype using the specified world
    /// </summary>
    /// <param name="world">The world</param>
    /// <returns>The local</returns>
    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex(rawIndex);
      if (local == null)
        local = CreateArchetype(world);
      return local;

      [MethodImpl(MethodImplOptions.NoInlining)]
      static Archetype CreateArchetype(World world)
      {
        ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.ArchetypeComponentIDs.Length + 1];
        ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.ID.RawIndex];
        int index1 = arr.UnsafeArrayIndex(Component<T1>.ID.RawIndex) & sbyte.MaxValue;
        components[index1] = Component<T1>.CreateInstance(1);
        createBuffers[index1] = Component<T1>.CreateInstance(0);
        int index2 = arr.UnsafeArrayIndex(Component<T2>.ID.RawIndex) & sbyte.MaxValue;
        components[index2] = Component<T2>.CreateInstance(1);
        createBuffers[index2] = Component<T2>.CreateInstance(0);
        int index3 = arr.UnsafeArrayIndex(Component<T3>.ID.RawIndex) & sbyte.MaxValue;
        components[index3] = Component<T3>.CreateInstance(1);
        createBuffers[index3] = Component<T3>.CreateInstance(0);
        int index4 = arr.UnsafeArrayIndex(Component<T4>.ID.RawIndex) & sbyte.MaxValue;
        components[index4] = Component<T4>.CreateInstance(1);
        createBuffers[index4] = Component<T4>.CreateInstance(0);
        int index5 = arr.UnsafeArrayIndex(Component<T5>.ID.RawIndex) & sbyte.MaxValue;
        components[index5] = Component<T5>.CreateInstance(1);
        createBuffers[index5] = Component<T5>.CreateInstance(0);
        int index6 = arr.UnsafeArrayIndex(Component<T6>.ID.RawIndex) & sbyte.MaxValue;
        components[index6] = Component<T6>.CreateInstance(1);
        createBuffers[index6] = Component<T6>.CreateInstance(0);
        int index7 = arr.UnsafeArrayIndex(Component<T7>.ID.RawIndex) & sbyte.MaxValue;
        components[index7] = Component<T7>.CreateInstance(1);
        createBuffers[index7] = Component<T7>.CreateInstance(0);
        int index8 = arr.UnsafeArrayIndex(Component<T8>.ID.RawIndex) & sbyte.MaxValue;
        components[index8] = Component<T8>.CreateInstance(1);
        createBuffers[index8] = Component<T8>.CreateInstance(0);
        int index9 = arr.UnsafeArrayIndex(Component<T9>.ID.RawIndex) & sbyte.MaxValue;
        components[index9] = Component<T9>.CreateInstance(1);
        createBuffers[index9] = Component<T9>.CreateInstance(0);
        int index10 = arr.UnsafeArrayIndex(Component<T10>.ID.RawIndex) & sbyte.MaxValue;
        components[index10] = Component<T10>.CreateInstance(1);
        createBuffers[index10] = Component<T10>.CreateInstance(0);
        int index11 = arr.UnsafeArrayIndex(Component<T11>.ID.RawIndex) & sbyte.MaxValue;
        components[index11] = Component<T11>.CreateInstance(1);
        createBuffers[index11] = Component<T11>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    /// <summary>
    /// The of component class
    /// </summary>
    internal static class OfComponent<C>
    {
      /// <summary>
      /// The id
      /// </summary>
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.ID, Component<C>.ID);
    }
  }
                 
                   /// <summary>
                   /// The archetype class
                   /// </summary>
                   internal static class Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
  {
    /// <summary>
    /// The id
    /// </summary>
    public static readonly FastImmutableArray<ComponentID> ArchetypeComponentIDs = new FastImmutableArray<ComponentID>(new[]
    {
      Component<T1>.ID,
      Component<T2>.ID,
      Component<T3>.ID,
      Component<T4>.ID,
      Component<T5>.ID,
      Component<T6>.ID,
      Component<T7>.ID,
      Component<T8>.ID,
      Component<T9>.ID,
      Component<T10>.ID,
      Component<T11>.ID,
      Component<T12>.ID
    });
    /// <summary>
    /// The empty
    /// </summary>
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    /// <summary>
    /// Creates the new or get existing archetype using the specified world
    /// </summary>
    /// <param name="world">The world</param>
    /// <returns>The local</returns>
    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex(rawIndex);
      if (local == null)
        local = CreateArchetype(world);
      return local;

      [MethodImpl(MethodImplOptions.NoInlining)]
      static Archetype CreateArchetype(World world)
      {
        ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.ArchetypeComponentIDs.Length + 1];
        ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.ID.RawIndex];
        int index1 = arr.UnsafeArrayIndex(Component<T1>.ID.RawIndex) & sbyte.MaxValue;
        components[index1] = Component<T1>.CreateInstance(1);
        createBuffers[index1] = Component<T1>.CreateInstance(0);
        int index2 = arr.UnsafeArrayIndex(Component<T2>.ID.RawIndex) & sbyte.MaxValue;
        components[index2] = Component<T2>.CreateInstance(1);
        createBuffers[index2] = Component<T2>.CreateInstance(0);
        int index3 = arr.UnsafeArrayIndex(Component<T3>.ID.RawIndex) & sbyte.MaxValue;
        components[index3] = Component<T3>.CreateInstance(1);
        createBuffers[index3] = Component<T3>.CreateInstance(0);
        int index4 = arr.UnsafeArrayIndex(Component<T4>.ID.RawIndex) & sbyte.MaxValue;
        components[index4] = Component<T4>.CreateInstance(1);
        createBuffers[index4] = Component<T4>.CreateInstance(0);
        int index5 = arr.UnsafeArrayIndex(Component<T5>.ID.RawIndex) & sbyte.MaxValue;
        components[index5] = Component<T5>.CreateInstance(1);
        createBuffers[index5] = Component<T5>.CreateInstance(0);
        int index6 = arr.UnsafeArrayIndex(Component<T6>.ID.RawIndex) & sbyte.MaxValue;
        components[index6] = Component<T6>.CreateInstance(1);
        createBuffers[index6] = Component<T6>.CreateInstance(0);
        int index7 = arr.UnsafeArrayIndex(Component<T7>.ID.RawIndex) & sbyte.MaxValue;
        components[index7] = Component<T7>.CreateInstance(1);
        createBuffers[index7] = Component<T7>.CreateInstance(0);
        int index8 = arr.UnsafeArrayIndex(Component<T8>.ID.RawIndex) & sbyte.MaxValue;
        components[index8] = Component<T8>.CreateInstance(1);
        createBuffers[index8] = Component<T8>.CreateInstance(0);
        int index9 = arr.UnsafeArrayIndex(Component<T9>.ID.RawIndex) & sbyte.MaxValue;
        components[index9] = Component<T9>.CreateInstance(1);
        createBuffers[index9] = Component<T9>.CreateInstance(0);
        int index10 = arr.UnsafeArrayIndex(Component<T10>.ID.RawIndex) & sbyte.MaxValue;
        components[index10] = Component<T10>.CreateInstance(1);
        createBuffers[index10] = Component<T10>.CreateInstance(0);
        int index11 = arr.UnsafeArrayIndex(Component<T11>.ID.RawIndex) & sbyte.MaxValue;
        components[index11] = Component<T11>.CreateInstance(1);
        createBuffers[index11] = Component<T11>.CreateInstance(0);
        int index12 = arr.UnsafeArrayIndex(Component<T12>.ID.RawIndex) & sbyte.MaxValue;
        components[index12] = Component<T12>.CreateInstance(1);
        createBuffers[index12] = Component<T12>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    /// <summary>
    /// The of component class
    /// </summary>
    internal static class OfComponent<C>
    {
      /// <summary>
      /// The id
      /// </summary>
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.ID, Component<C>.ID);
    }
  }
                   
                    /// <summary>
                    /// The archetype class
                    /// </summary>
                    internal static class Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
  {
    /// <summary>
    /// The id
    /// </summary>
    public static readonly FastImmutableArray<ComponentID> ArchetypeComponentIDs = new FastImmutableArray<ComponentID>(new[]
    {
      Component<T1>.ID,
      Component<T2>.ID,
      Component<T3>.ID,
      Component<T4>.ID,
      Component<T5>.ID,
      Component<T6>.ID,
      Component<T7>.ID,
      Component<T8>.ID,
      Component<T9>.ID,
      Component<T10>.ID,
      Component<T11>.ID,
      Component<T12>.ID,
      Component<T13>.ID
    });
    /// <summary>
    /// The empty
    /// </summary>
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    /// <summary>
    /// Creates the new or get existing archetype using the specified world
    /// </summary>
    /// <param name="world">The world</param>
    /// <returns>The local</returns>
    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex(rawIndex);
      if (local == null)
        local = CreateArchetype(world);
      return local;

      [MethodImpl(MethodImplOptions.NoInlining)]
      static Archetype CreateArchetype(World world)
      {
        ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.ArchetypeComponentIDs.Length + 1];
        ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.ID.RawIndex];
        int index1 = arr.UnsafeArrayIndex(Component<T1>.ID.RawIndex) & sbyte.MaxValue;
        components[index1] = Component<T1>.CreateInstance(1);
        createBuffers[index1] = Component<T1>.CreateInstance(0);
        int index2 = arr.UnsafeArrayIndex(Component<T2>.ID.RawIndex) & sbyte.MaxValue;
        components[index2] = Component<T2>.CreateInstance(1);
        createBuffers[index2] = Component<T2>.CreateInstance(0);
        int index3 = arr.UnsafeArrayIndex(Component<T3>.ID.RawIndex) & sbyte.MaxValue;
        components[index3] = Component<T3>.CreateInstance(1);
        createBuffers[index3] = Component<T3>.CreateInstance(0);
        int index4 = arr.UnsafeArrayIndex(Component<T4>.ID.RawIndex) & sbyte.MaxValue;
        components[index4] = Component<T4>.CreateInstance(1);
        createBuffers[index4] = Component<T4>.CreateInstance(0);
        int index5 = arr.UnsafeArrayIndex(Component<T5>.ID.RawIndex) & sbyte.MaxValue;
        components[index5] = Component<T5>.CreateInstance(1);
        createBuffers[index5] = Component<T5>.CreateInstance(0);
        int index6 = arr.UnsafeArrayIndex(Component<T6>.ID.RawIndex) & sbyte.MaxValue;
        components[index6] = Component<T6>.CreateInstance(1);
        createBuffers[index6] = Component<T6>.CreateInstance(0);
        int index7 = arr.UnsafeArrayIndex(Component<T7>.ID.RawIndex) & sbyte.MaxValue;
        components[index7] = Component<T7>.CreateInstance(1);
        createBuffers[index7] = Component<T7>.CreateInstance(0);
        int index8 = arr.UnsafeArrayIndex(Component<T8>.ID.RawIndex) & sbyte.MaxValue;
        components[index8] = Component<T8>.CreateInstance(1);
        createBuffers[index8] = Component<T8>.CreateInstance(0);
        int index9 = arr.UnsafeArrayIndex(Component<T9>.ID.RawIndex) & sbyte.MaxValue;
        components[index9] = Component<T9>.CreateInstance(1);
        createBuffers[index9] = Component<T9>.CreateInstance(0);
        int index10 = arr.UnsafeArrayIndex(Component<T10>.ID.RawIndex) & sbyte.MaxValue;
        components[index10] = Component<T10>.CreateInstance(1);
        createBuffers[index10] = Component<T10>.CreateInstance(0);
        int index11 = arr.UnsafeArrayIndex(Component<T11>.ID.RawIndex) & sbyte.MaxValue;
        components[index11] = Component<T11>.CreateInstance(1);
        createBuffers[index11] = Component<T11>.CreateInstance(0);
        int index12 = arr.UnsafeArrayIndex(Component<T12>.ID.RawIndex) & sbyte.MaxValue;
        components[index12] = Component<T12>.CreateInstance(1);
        createBuffers[index12] = Component<T12>.CreateInstance(0);
        int index13 = arr.UnsafeArrayIndex(Component<T13>.ID.RawIndex) & sbyte.MaxValue;
        components[index13] = Component<T13>.CreateInstance(1);
        createBuffers[index13] = Component<T13>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    /// <summary>
    /// The of component class
    /// </summary>
    internal static class OfComponent<C>
    {
      /// <summary>
      /// The id
      /// </summary>
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.ID, Component<C>.ID);
    }
  }
                    
                    /// <summary>
                    /// The archetype class
                    /// </summary>
                    internal static class Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
  {
    /// <summary>
    /// The id
    /// </summary>
    public static readonly FastImmutableArray<ComponentID> ArchetypeComponentIDs = new FastImmutableArray<ComponentID>(new[]
    {
      Component<T1>.ID,
      Component<T2>.ID,
      Component<T3>.ID,
      Component<T4>.ID,
      Component<T5>.ID,
      Component<T6>.ID,
      Component<T7>.ID,
      Component<T8>.ID,
      Component<T9>.ID,
      Component<T10>.ID,
      Component<T11>.ID,
      Component<T12>.ID,
      Component<T13>.ID,
      Component<T14>.ID
    });
    /// <summary>
    /// The empty
    /// </summary>
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    /// <summary>
    /// Creates the new or get existing archetype using the specified world
    /// </summary>
    /// <param name="world">The world</param>
    /// <returns>The local</returns>
    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex(rawIndex);
      if (local == null)
        local = CreateArchetype(world);
      return local;

      [MethodImpl(MethodImplOptions.NoInlining)]
      static Archetype CreateArchetype(World world)
      {
        ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.ArchetypeComponentIDs.Length + 1];
        ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.ID.RawIndex];
        int index1 = arr.UnsafeArrayIndex(Component<T1>.ID.RawIndex) & sbyte.MaxValue;
        components[index1] = Component<T1>.CreateInstance(1);
        createBuffers[index1] = Component<T1>.CreateInstance(0);
        int index2 = arr.UnsafeArrayIndex(Component<T2>.ID.RawIndex) & sbyte.MaxValue;
        components[index2] = Component<T2>.CreateInstance(1);
        createBuffers[index2] = Component<T2>.CreateInstance(0);
        int index3 = arr.UnsafeArrayIndex(Component<T3>.ID.RawIndex) & sbyte.MaxValue;
        components[index3] = Component<T3>.CreateInstance(1);
        createBuffers[index3] = Component<T3>.CreateInstance(0);
        int index4 = arr.UnsafeArrayIndex(Component<T4>.ID.RawIndex) & sbyte.MaxValue;
        components[index4] = Component<T4>.CreateInstance(1);
        createBuffers[index4] = Component<T4>.CreateInstance(0);
        int index5 = arr.UnsafeArrayIndex(Component<T5>.ID.RawIndex) & sbyte.MaxValue;
        components[index5] = Component<T5>.CreateInstance(1);
        createBuffers[index5] = Component<T5>.CreateInstance(0);
        int index6 = arr.UnsafeArrayIndex(Component<T6>.ID.RawIndex) & sbyte.MaxValue;
        components[index6] = Component<T6>.CreateInstance(1);
        createBuffers[index6] = Component<T6>.CreateInstance(0);
        int index7 = arr.UnsafeArrayIndex(Component<T7>.ID.RawIndex) & sbyte.MaxValue;
        components[index7] = Component<T7>.CreateInstance(1);
        createBuffers[index7] = Component<T7>.CreateInstance(0);
        int index8 = arr.UnsafeArrayIndex(Component<T8>.ID.RawIndex) & sbyte.MaxValue;
        components[index8] = Component<T8>.CreateInstance(1);
        createBuffers[index8] = Component<T8>.CreateInstance(0);
        int index9 = arr.UnsafeArrayIndex(Component<T9>.ID.RawIndex) & sbyte.MaxValue;
        components[index9] = Component<T9>.CreateInstance(1);
        createBuffers[index9] = Component<T9>.CreateInstance(0);
        int index10 = arr.UnsafeArrayIndex(Component<T10>.ID.RawIndex) & sbyte.MaxValue;
        components[index10] = Component<T10>.CreateInstance(1);
        createBuffers[index10] = Component<T10>.CreateInstance(0);
        int index11 = arr.UnsafeArrayIndex(Component<T11>.ID.RawIndex) & sbyte.MaxValue;
        components[index11] = Component<T11>.CreateInstance(1);
        createBuffers[index11] = Component<T11>.CreateInstance(0);
        int index12 = arr.UnsafeArrayIndex(Component<T12>.ID.RawIndex) & sbyte.MaxValue;
        components[index12] = Component<T12>.CreateInstance(1);
        createBuffers[index12] = Component<T12>.CreateInstance(0);
        int index13 = arr.UnsafeArrayIndex(Component<T13>.ID.RawIndex) & sbyte.MaxValue;
        components[index13] = Component<T13>.CreateInstance(1);
        createBuffers[index13] = Component<T13>.CreateInstance(0);
        int index14 = arr.UnsafeArrayIndex(Component<T14>.ID.RawIndex) & sbyte.MaxValue;
        components[index14] = Component<T14>.CreateInstance(1);
        createBuffers[index14] = Component<T14>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    /// <summary>
    /// The of component class
    /// </summary>
    internal static class OfComponent<C>
    {
      /// <summary>
      /// The id
      /// </summary>
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.ID, Component<C>.ID);
    }
  }
                    
                     /// <summary>
                     /// The archetype class
                     /// </summary>
                     internal static class Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
  {
    /// <summary>
    /// The id
    /// </summary>
    public static readonly FastImmutableArray<ComponentID> ArchetypeComponentIDs = new FastImmutableArray<ComponentID>(new[]
    {
      Component<T1>.ID,
      Component<T2>.ID,
      Component<T3>.ID,
      Component<T4>.ID,
      Component<T5>.ID,
      Component<T6>.ID,
      Component<T7>.ID,
      Component<T8>.ID,
      Component<T9>.ID,
      Component<T10>.ID,
      Component<T11>.ID,
      Component<T12>.ID,
      Component<T13>.ID,
      Component<T14>.ID,
      Component<T15>.ID
    });
    /// <summary>
    /// The empty
    /// </summary>
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    /// <summary>
    /// Creates the new or get existing archetype using the specified world
    /// </summary>
    /// <param name="world">The world</param>
    /// <returns>The local</returns>
    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex(rawIndex);
      if (local == null)
        local = CreateArchetype(world);
      return local;

      [MethodImpl(MethodImplOptions.NoInlining)]
      static Archetype CreateArchetype(World world)
      {
        ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.ArchetypeComponentIDs.Length + 1];
        ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.ID.RawIndex];
        int index1 = arr.UnsafeArrayIndex(Component<T1>.ID.RawIndex) & sbyte.MaxValue;
        components[index1] = Component<T1>.CreateInstance(1);
        createBuffers[index1] = Component<T1>.CreateInstance(0);
        int index2 = arr.UnsafeArrayIndex(Component<T2>.ID.RawIndex) & sbyte.MaxValue;
        components[index2] = Component<T2>.CreateInstance(1);
        createBuffers[index2] = Component<T2>.CreateInstance(0);
        int index3 = arr.UnsafeArrayIndex(Component<T3>.ID.RawIndex) & sbyte.MaxValue;
        components[index3] = Component<T3>.CreateInstance(1);
        createBuffers[index3] = Component<T3>.CreateInstance(0);
        int index4 = arr.UnsafeArrayIndex(Component<T4>.ID.RawIndex) & sbyte.MaxValue;
        components[index4] = Component<T4>.CreateInstance(1);
        createBuffers[index4] = Component<T4>.CreateInstance(0);
        int index5 = arr.UnsafeArrayIndex(Component<T5>.ID.RawIndex) & sbyte.MaxValue;
        components[index5] = Component<T5>.CreateInstance(1);
        createBuffers[index5] = Component<T5>.CreateInstance(0);
        int index6 = arr.UnsafeArrayIndex(Component<T6>.ID.RawIndex) & sbyte.MaxValue;
        components[index6] = Component<T6>.CreateInstance(1);
        createBuffers[index6] = Component<T6>.CreateInstance(0);
        int index7 = arr.UnsafeArrayIndex(Component<T7>.ID.RawIndex) & sbyte.MaxValue;
        components[index7] = Component<T7>.CreateInstance(1);
        createBuffers[index7] = Component<T7>.CreateInstance(0);
        int index8 = arr.UnsafeArrayIndex(Component<T8>.ID.RawIndex) & sbyte.MaxValue;
        components[index8] = Component<T8>.CreateInstance(1);
        createBuffers[index8] = Component<T8>.CreateInstance(0);
        int index9 = arr.UnsafeArrayIndex(Component<T9>.ID.RawIndex) & sbyte.MaxValue;
        components[index9] = Component<T9>.CreateInstance(1);
        createBuffers[index9] = Component<T9>.CreateInstance(0);
        int index10 = arr.UnsafeArrayIndex(Component<T10>.ID.RawIndex) & sbyte.MaxValue;
        components[index10] = Component<T10>.CreateInstance(1);
        createBuffers[index10] = Component<T10>.CreateInstance(0);
        int index11 = arr.UnsafeArrayIndex(Component<T11>.ID.RawIndex) & sbyte.MaxValue;
        components[index11] = Component<T11>.CreateInstance(1);
        createBuffers[index11] = Component<T11>.CreateInstance(0);
        int index12 = arr.UnsafeArrayIndex(Component<T12>.ID.RawIndex) & sbyte.MaxValue;
        components[index12] = Component<T12>.CreateInstance(1);
        createBuffers[index12] = Component<T12>.CreateInstance(0);
        int index13 = arr.UnsafeArrayIndex(Component<T13>.ID.RawIndex) & sbyte.MaxValue;
        components[index13] = Component<T13>.CreateInstance(1);
        createBuffers[index13] = Component<T13>.CreateInstance(0);
        int index14 = arr.UnsafeArrayIndex(Component<T14>.ID.RawIndex) & sbyte.MaxValue;
        components[index14] = Component<T14>.CreateInstance(1);
        createBuffers[index14] = Component<T14>.CreateInstance(0);
        int index15 = arr.UnsafeArrayIndex(Component<T15>.ID.RawIndex) & sbyte.MaxValue;
        components[index15] = Component<T15>.CreateInstance(1);
        createBuffers[index15] = Component<T15>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    /// <summary>
    /// The of component class
    /// </summary>
    internal static class OfComponent<C>
    {
      /// <summary>
      /// The id
      /// </summary>
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.ID, Component<C>.ID);
    }
  }

  /// <summary>
  /// The archetype class
  /// </summary>
  internal static class Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
  {
      /// <summary>
      /// The id
      /// </summary>
      public static readonly FastImmutableArray<ComponentID> ArchetypeComponentIDs = new FastImmutableArray<ComponentID>(new[]
      {
          Component<T1>.ID,
          Component<T2>.ID,
          Component<T3>.ID,
          Component<T4>.ID,
          Component<T5>.ID,
          Component<T6>.ID,
          Component<T7>.ID,
          Component<T8>.ID,
          Component<T9>.ID,
          Component<T10>.ID,
          Component<T11>.ID,
          Component<T12>.ID,
          Component<T13>.ID,
          Component<T14>.ID,
          Component<T15>.ID,
          Component<T16>.ID
      });

      /// <summary>
      /// The empty
      /// </summary>
      public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.ArchetypeComponentIDs),
          new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

      /// <summary>
      /// Creates the new or get existing archetype using the specified world
      /// </summary>
      /// <param name="world">The world</param>
      /// <returns>The local</returns>
      internal static Archetype CreateNewOrGetExistingArchetype(World world)
      {
          ushort rawIndex = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.ID.RawIndex;
          ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex(rawIndex);
          if (local == null)
              local = CreateArchetype(world);
          return local;

          [MethodImpl(MethodImplOptions.NoInlining)]
          static Archetype CreateArchetype(World world)
          {
              ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.ArchetypeComponentIDs.Length + 1];
              ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
              byte[] arr = GlobalWorldTables.ComponentTagLocationTable[Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.ID.RawIndex];
              int index1 = arr.UnsafeArrayIndex(Component<T1>.ID.RawIndex) & sbyte.MaxValue;
              components[index1] = Component<T1>.CreateInstance(1);
              createBuffers[index1] = Component<T1>.CreateInstance(0);
              int index2 = arr.UnsafeArrayIndex(Component<T2>.ID.RawIndex) & sbyte.MaxValue;
              components[index2] = Component<T2>.CreateInstance(1);
              createBuffers[index2] = Component<T2>.CreateInstance(0);
              int index3 = arr.UnsafeArrayIndex(Component<T3>.ID.RawIndex) & sbyte.MaxValue;
              components[index3] = Component<T3>.CreateInstance(1);
              createBuffers[index3] = Component<T3>.CreateInstance(0);
              int index4 = arr.UnsafeArrayIndex(Component<T4>.ID.RawIndex) & sbyte.MaxValue;
              components[index4] = Component<T4>.CreateInstance(1);
              createBuffers[index4] = Component<T4>.CreateInstance(0);
              int index5 = arr.UnsafeArrayIndex(Component<T5>.ID.RawIndex) & sbyte.MaxValue;
              components[index5] = Component<T5>.CreateInstance(1);
              createBuffers[index5] = Component<T5>.CreateInstance(0);
              int index6 = arr.UnsafeArrayIndex(Component<T6>.ID.RawIndex) & sbyte.MaxValue;
              components[index6] = Component<T6>.CreateInstance(1);
              createBuffers[index6] = Component<T6>.CreateInstance(0);
              int index7 = arr.UnsafeArrayIndex(Component<T7>.ID.RawIndex) & sbyte.MaxValue;
              components[index7] = Component<T7>.CreateInstance(1);
              createBuffers[index7] = Component<T7>.CreateInstance(0);
              int index8 = arr.UnsafeArrayIndex(Component<T8>.ID.RawIndex) & sbyte.MaxValue;
              components[index8] = Component<T8>.CreateInstance(1);
              createBuffers[index8] = Component<T8>.CreateInstance(0);
              int index9 = arr.UnsafeArrayIndex(Component<T9>.ID.RawIndex) & sbyte.MaxValue;
              components[index9] = Component<T9>.CreateInstance(1);
              createBuffers[index9] = Component<T9>.CreateInstance(0);
              int index10 = arr.UnsafeArrayIndex(Component<T10>.ID.RawIndex) & sbyte.MaxValue;
              components[index10] = Component<T10>.CreateInstance(1);
              createBuffers[index10] = Component<T10>.CreateInstance(0);
              int index11 = arr.UnsafeArrayIndex(Component<T11>.ID.RawIndex) & sbyte.MaxValue;
              components[index11] = Component<T11>.CreateInstance(1);
              createBuffers[index11] = Component<T11>.CreateInstance(0);
              int index12 = arr.UnsafeArrayIndex(Component<T12>.ID.RawIndex) & sbyte.MaxValue;
              components[index12] = Component<T12>.CreateInstance(1);
              createBuffers[index12] = Component<T12>.CreateInstance(0);
              int index13 = arr.UnsafeArrayIndex(Component<T13>.ID.RawIndex) & sbyte.MaxValue;
              components[index13] = Component<T13>.CreateInstance(1);
              createBuffers[index13] = Component<T13>.CreateInstance(0);
              int index14 = arr.UnsafeArrayIndex(Component<T14>.ID.RawIndex) & sbyte.MaxValue;
              components[index14] = Component<T14>.CreateInstance(1);
              createBuffers[index14] = Component<T14>.CreateInstance(0);
              int index15 = arr.UnsafeArrayIndex(Component<T15>.ID.RawIndex) & sbyte.MaxValue;
              components[index15] = Component<T15>.CreateInstance(1);
              createBuffers[index15] = Component<T15>.CreateInstance(0);
              int index16 = arr.UnsafeArrayIndex(Component<T16>.ID.RawIndex) & sbyte.MaxValue;
              components[index16] = Component<T16>.CreateInstance(1);
              createBuffers[index16] = Component<T16>.CreateInstance(0);
              Archetype archetype = new Archetype(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.ID, components, createBuffers);
              world.ArchetypeAdded(archetype);
              return archetype;
          }
      }

      /// <summary>
      /// The of component class
      /// </summary>
      internal static class OfComponent<C>
      {
          /// <summary>
          /// The id
          /// </summary>
          public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.ID, Component<C>.ID);
      }
  }
}