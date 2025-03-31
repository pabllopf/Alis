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
using Alis.Core.Ecs.Core.Memory;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs.Core.Archetype
{
      internal static class Archetype<T1, T2>
  {
      public static readonly FastImmutableArray<ComponentID> ArchetypeComponentIDs = new FastImmutableArray<ComponentID>(new[]
      {
          Component<T1>.ID,
          Component<T2>.ID
      });
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex<Archetype>(rawIndex);
      if (local == null)
        local = CreateArchetype(world);
      return local;

      [MethodImpl(MethodImplOptions.NoInlining)]
      static Archetype CreateArchetype(World world)
      {
        ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2>.ArchetypeComponentIDs.Length + 1];
        ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[(int) Archetype<T1, T2>.ID.RawIndex];
        int index1 = (int) arr.UnsafeArrayIndex<byte>(Component<T1>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(1);
        createBuffers[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(0);
        int index2 = (int) arr.UnsafeArrayIndex<byte>(Component<T2>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(1);
        createBuffers[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    internal static class OfComponent<C>
    {
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2>.ID, Component<C>.ID);
    }
  }
    
    internal static class Archetype<T1, T2, T3>
  {
   public static readonly FastImmutableArray<ComponentID> ArchetypeComponentIDs = new FastImmutableArray<ComponentID>(new[]
   {
       Component<T1>.ID,
       Component<T2>.ID,
       Component<T3>.ID
   });
    
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2, T3>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex<Archetype>(rawIndex);
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
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[(int) Archetype<T1, T2, T3>.ID.RawIndex];
        int index1 = (int) arr.UnsafeArrayIndex<byte>(Component<T1>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(1);
        createBuffers[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(0);
        int index2 = (int) arr.UnsafeArrayIndex<byte>(Component<T2>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(1);
        createBuffers[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(0);
        int index3 = (int) arr.UnsafeArrayIndex<byte>(Component<T3>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(1);
        createBuffers[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2, T3>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    internal static class OfComponent<TC>
    {
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3>.ID, Component<TC>.ID);
    }
  }
    
    internal static class Archetype<T1, T2, T3, T4>
  {
    public static readonly FastImmutableArray<ComponentID> ArchetypeComponentIDs = new FastImmutableArray<ComponentID>(new[]
    {
      Component<T1>.ID,
      Component<T2>.ID,
      Component<T3>.ID,
      Component<T4>.ID
    });
    
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3, T4>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3, T4>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2, T3, T4>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex<Archetype>(rawIndex);
      if (local == null)
        local = CreateArchetype(world);
      return local;

      [MethodImpl(MethodImplOptions.NoInlining)]
      static Archetype CreateArchetype(World world)
      {
        ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2, T3, T4>.ArchetypeComponentIDs.Length + 1];
        ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[(int) Archetype<T1, T2, T3, T4>.ID.RawIndex];
        int index1 = (int) arr.UnsafeArrayIndex<byte>(Component<T1>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(1);
        createBuffers[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(0);
        int index2 = (int) arr.UnsafeArrayIndex<byte>(Component<T2>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(1);
        createBuffers[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(0);
        int index3 = (int) arr.UnsafeArrayIndex<byte>(Component<T3>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(1);
        createBuffers[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(0);
        int index4 = (int) arr.UnsafeArrayIndex<byte>(Component<T4>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index4] = (ComponentStorageBase) Component<T4>.CreateInstance(1);
        createBuffers[index4] = (ComponentStorageBase) Component<T4>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2, T3, T4>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    internal static class OfComponent<C>
    {
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4>.ID, Component<C>.ID);
    }
  }
    
      internal static class Archetype<T1, T2, T3, T4, T5>
  {
    public static readonly FastImmutableArray<ComponentID> ArchetypeComponentIDs = new FastImmutableArray<ComponentID>(new[]
    {
      Component<T1>.ID,
      Component<T2>.ID,
      Component<T3>.ID,
      Component<T4>.ID,
      Component<T5>.ID
    });
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3, T4, T5>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3, T4, T5>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2, T3, T4, T5>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex<Archetype>(rawIndex);
      if (local == null)
        local = CreateArchetype(world);
      return local;

      [MethodImpl(MethodImplOptions.NoInlining)]
      static Archetype CreateArchetype(World world)
      {
        ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2, T3, T4, T5>.ArchetypeComponentIDs.Length + 1];
        ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[(int) Archetype<T1, T2, T3, T4, T5>.ID.RawIndex];
        int index1 = (int) arr.UnsafeArrayIndex<byte>(Component<T1>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(1);
        createBuffers[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(0);
        int index2 = (int) arr.UnsafeArrayIndex<byte>(Component<T2>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(1);
        createBuffers[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(0);
        int index3 = (int) arr.UnsafeArrayIndex<byte>(Component<T3>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(1);
        createBuffers[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(0);
        int index4 = (int) arr.UnsafeArrayIndex<byte>(Component<T4>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index4] = (ComponentStorageBase) Component<T4>.CreateInstance(1);
        createBuffers[index4] = (ComponentStorageBase) Component<T4>.CreateInstance(0);
        int index5 = (int) arr.UnsafeArrayIndex<byte>(Component<T5>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index5] = (ComponentStorageBase) Component<T5>.CreateInstance(1);
        createBuffers[index5] = (ComponentStorageBase) Component<T5>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2, T3, T4, T5>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    internal static class OfComponent<C>
    {
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5>.ID, Component<C>.ID);
    }
  }
      
        internal static class Archetype<T1, T2, T3, T4, T5, T6>
  {
    public static readonly FastImmutableArray<ComponentID> ArchetypeComponentIDs = new FastImmutableArray<ComponentID>(new[]
    {
      Component<T1>.ID,
      Component<T2>.ID,
      Component<T3>.ID,
      Component<T4>.ID,
      Component<T5>.ID,
      Component<T6>.ID
    });
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3, T4, T5, T6>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3, T4, T5, T6>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2, T3, T4, T5, T6>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex<Archetype>(rawIndex);
      if (local == null)
        local = CreateArchetype(world);
      return local;

      [MethodImpl(MethodImplOptions.NoInlining)]
      static Archetype CreateArchetype(World world)
      {
        ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2, T3, T4, T5, T6>.ArchetypeComponentIDs.Length + 1];
        ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[(int) Archetype<T1, T2, T3, T4, T5, T6>.ID.RawIndex];
        int index1 = (int) arr.UnsafeArrayIndex<byte>(Component<T1>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(1);
        createBuffers[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(0);
        int index2 = (int) arr.UnsafeArrayIndex<byte>(Component<T2>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(1);
        createBuffers[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(0);
        int index3 = (int) arr.UnsafeArrayIndex<byte>(Component<T3>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(1);
        createBuffers[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(0);
        int index4 = (int) arr.UnsafeArrayIndex<byte>(Component<T4>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index4] = (ComponentStorageBase) Component<T4>.CreateInstance(1);
        createBuffers[index4] = (ComponentStorageBase) Component<T4>.CreateInstance(0);
        int index5 = (int) arr.UnsafeArrayIndex<byte>(Component<T5>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index5] = (ComponentStorageBase) Component<T5>.CreateInstance(1);
        createBuffers[index5] = (ComponentStorageBase) Component<T5>.CreateInstance(0);
        int index6 = (int) arr.UnsafeArrayIndex<byte>(Component<T6>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index6] = (ComponentStorageBase) Component<T6>.CreateInstance(1);
        createBuffers[index6] = (ComponentStorageBase) Component<T6>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2, T3, T4, T5, T6>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    internal static class OfComponent<C>
    {
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5, T6>.ID, Component<C>.ID);
    }
  }
        
          internal static class Archetype<T1, T2, T3, T4, T5, T6, T7>
  {
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
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3, T4, T5, T6, T7>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3, T4, T5, T6, T7>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2, T3, T4, T5, T6, T7>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex<Archetype>(rawIndex);
      if (local == null)
        local = CreateArchetype(world);
      return local;

      [MethodImpl(MethodImplOptions.NoInlining)]
      static Archetype CreateArchetype(World world)
      {
        ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2, T3, T4, T5, T6, T7>.ArchetypeComponentIDs.Length + 1];
        ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[(int) Archetype<T1, T2, T3, T4, T5, T6, T7>.ID.RawIndex];
        int index1 = (int) arr.UnsafeArrayIndex<byte>(Component<T1>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(1);
        createBuffers[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(0);
        int index2 = (int) arr.UnsafeArrayIndex<byte>(Component<T2>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(1);
        createBuffers[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(0);
        int index3 = (int) arr.UnsafeArrayIndex<byte>(Component<T3>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(1);
        createBuffers[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(0);
        int index4 = (int) arr.UnsafeArrayIndex<byte>(Component<T4>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index4] = (ComponentStorageBase) Component<T4>.CreateInstance(1);
        createBuffers[index4] = (ComponentStorageBase) Component<T4>.CreateInstance(0);
        int index5 = (int) arr.UnsafeArrayIndex<byte>(Component<T5>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index5] = (ComponentStorageBase) Component<T5>.CreateInstance(1);
        createBuffers[index5] = (ComponentStorageBase) Component<T5>.CreateInstance(0);
        int index6 = (int) arr.UnsafeArrayIndex<byte>(Component<T6>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index6] = (ComponentStorageBase) Component<T6>.CreateInstance(1);
        createBuffers[index6] = (ComponentStorageBase) Component<T6>.CreateInstance(0);
        int index7 = (int) arr.UnsafeArrayIndex<byte>(Component<T7>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index7] = (ComponentStorageBase) Component<T7>.CreateInstance(1);
        createBuffers[index7] = (ComponentStorageBase) Component<T7>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2, T3, T4, T5, T6, T7>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    internal static class OfComponent<C>
    {
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5, T6, T7>.ID, Component<C>.ID);
    }
  }
          
            internal static class Archetype<T1, T2, T3, T4, T5, T6, T7, T8>
  {
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
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3, T4, T5, T6, T7, T8>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3, T4, T5, T6, T7, T8>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2, T3, T4, T5, T6, T7, T8>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex<Archetype>(rawIndex);
      if (local == null)
        local = CreateArchetype(world);
      return local;

      [MethodImpl(MethodImplOptions.NoInlining)]
      static Archetype CreateArchetype(World world)
      {
        ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2, T3, T4, T5, T6, T7, T8>.ArchetypeComponentIDs.Length + 1];
        ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[(int) Archetype<T1, T2, T3, T4, T5, T6, T7, T8>.ID.RawIndex];
        int index1 = (int) arr.UnsafeArrayIndex<byte>(Component<T1>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(1);
        createBuffers[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(0);
        int index2 = (int) arr.UnsafeArrayIndex<byte>(Component<T2>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(1);
        createBuffers[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(0);
        int index3 = (int) arr.UnsafeArrayIndex<byte>(Component<T3>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(1);
        createBuffers[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(0);
        int index4 = (int) arr.UnsafeArrayIndex<byte>(Component<T4>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index4] = (ComponentStorageBase) Component<T4>.CreateInstance(1);
        createBuffers[index4] = (ComponentStorageBase) Component<T4>.CreateInstance(0);
        int index5 = (int) arr.UnsafeArrayIndex<byte>(Component<T5>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index5] = (ComponentStorageBase) Component<T5>.CreateInstance(1);
        createBuffers[index5] = (ComponentStorageBase) Component<T5>.CreateInstance(0);
        int index6 = (int) arr.UnsafeArrayIndex<byte>(Component<T6>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index6] = (ComponentStorageBase) Component<T6>.CreateInstance(1);
        createBuffers[index6] = (ComponentStorageBase) Component<T6>.CreateInstance(0);
        int index7 = (int) arr.UnsafeArrayIndex<byte>(Component<T7>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index7] = (ComponentStorageBase) Component<T7>.CreateInstance(1);
        createBuffers[index7] = (ComponentStorageBase) Component<T7>.CreateInstance(0);
        int index8 = (int) arr.UnsafeArrayIndex<byte>(Component<T8>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index8] = (ComponentStorageBase) Component<T8>.CreateInstance(1);
        createBuffers[index8] = (ComponentStorageBase) Component<T8>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2, T3, T4, T5, T6, T7, T8>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    internal static class OfComponent<C>
    {
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8>.ID, Component<C>.ID);
    }
  }
            
              internal static class Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9>
  {
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
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex<Archetype>(rawIndex);
      if (local == null)
        local = CreateArchetype(world);
      return local;

      [MethodImpl(MethodImplOptions.NoInlining)]
      static Archetype CreateArchetype(World world)
      {
        ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9>.ArchetypeComponentIDs.Length + 1];
        ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[(int) Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9>.ID.RawIndex];
        int index1 = (int) arr.UnsafeArrayIndex<byte>(Component<T1>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(1);
        createBuffers[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(0);
        int index2 = (int) arr.UnsafeArrayIndex<byte>(Component<T2>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(1);
        createBuffers[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(0);
        int index3 = (int) arr.UnsafeArrayIndex<byte>(Component<T3>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(1);
        createBuffers[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(0);
        int index4 = (int) arr.UnsafeArrayIndex<byte>(Component<T4>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index4] = (ComponentStorageBase) Component<T4>.CreateInstance(1);
        createBuffers[index4] = (ComponentStorageBase) Component<T4>.CreateInstance(0);
        int index5 = (int) arr.UnsafeArrayIndex<byte>(Component<T5>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index5] = (ComponentStorageBase) Component<T5>.CreateInstance(1);
        createBuffers[index5] = (ComponentStorageBase) Component<T5>.CreateInstance(0);
        int index6 = (int) arr.UnsafeArrayIndex<byte>(Component<T6>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index6] = (ComponentStorageBase) Component<T6>.CreateInstance(1);
        createBuffers[index6] = (ComponentStorageBase) Component<T6>.CreateInstance(0);
        int index7 = (int) arr.UnsafeArrayIndex<byte>(Component<T7>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index7] = (ComponentStorageBase) Component<T7>.CreateInstance(1);
        createBuffers[index7] = (ComponentStorageBase) Component<T7>.CreateInstance(0);
        int index8 = (int) arr.UnsafeArrayIndex<byte>(Component<T8>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index8] = (ComponentStorageBase) Component<T8>.CreateInstance(1);
        createBuffers[index8] = (ComponentStorageBase) Component<T8>.CreateInstance(0);
        int index9 = (int) arr.UnsafeArrayIndex<byte>(Component<T9>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index9] = (ComponentStorageBase) Component<T9>.CreateInstance(1);
        createBuffers[index9] = (ComponentStorageBase) Component<T9>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    internal static class OfComponent<C>
    {
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9>.ID, Component<C>.ID);
    }
  }
              
               internal static class Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
  {
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
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex<Archetype>(rawIndex);
      if (local == null)
        local = CreateArchetype(world);
      return local;

      [MethodImpl(MethodImplOptions.NoInlining)]
      static Archetype CreateArchetype(World world)
      {
        ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.ArchetypeComponentIDs.Length + 1];
        ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[(int) Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.ID.RawIndex];
        int index1 = (int) arr.UnsafeArrayIndex<byte>(Component<T1>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(1);
        createBuffers[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(0);
        int index2 = (int) arr.UnsafeArrayIndex<byte>(Component<T2>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(1);
        createBuffers[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(0);
        int index3 = (int) arr.UnsafeArrayIndex<byte>(Component<T3>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(1);
        createBuffers[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(0);
        int index4 = (int) arr.UnsafeArrayIndex<byte>(Component<T4>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index4] = (ComponentStorageBase) Component<T4>.CreateInstance(1);
        createBuffers[index4] = (ComponentStorageBase) Component<T4>.CreateInstance(0);
        int index5 = (int) arr.UnsafeArrayIndex<byte>(Component<T5>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index5] = (ComponentStorageBase) Component<T5>.CreateInstance(1);
        createBuffers[index5] = (ComponentStorageBase) Component<T5>.CreateInstance(0);
        int index6 = (int) arr.UnsafeArrayIndex<byte>(Component<T6>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index6] = (ComponentStorageBase) Component<T6>.CreateInstance(1);
        createBuffers[index6] = (ComponentStorageBase) Component<T6>.CreateInstance(0);
        int index7 = (int) arr.UnsafeArrayIndex<byte>(Component<T7>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index7] = (ComponentStorageBase) Component<T7>.CreateInstance(1);
        createBuffers[index7] = (ComponentStorageBase) Component<T7>.CreateInstance(0);
        int index8 = (int) arr.UnsafeArrayIndex<byte>(Component<T8>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index8] = (ComponentStorageBase) Component<T8>.CreateInstance(1);
        createBuffers[index8] = (ComponentStorageBase) Component<T8>.CreateInstance(0);
        int index9 = (int) arr.UnsafeArrayIndex<byte>(Component<T9>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index9] = (ComponentStorageBase) Component<T9>.CreateInstance(1);
        createBuffers[index9] = (ComponentStorageBase) Component<T9>.CreateInstance(0);
        int index10 = (int) arr.UnsafeArrayIndex<byte>(Component<T10>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index10] = (ComponentStorageBase) Component<T10>.CreateInstance(1);
        createBuffers[index10] = (ComponentStorageBase) Component<T10>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    internal static class OfComponent<C>
    {
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.ID, Component<C>.ID);
    }
  }
               
                 internal static class Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
  {
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
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex<Archetype>(rawIndex);
      if (local == null)
        local = CreateArchetype(world);
      return local;

      [MethodImpl(MethodImplOptions.NoInlining)]
      static Archetype CreateArchetype(World world)
      {
        ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.ArchetypeComponentIDs.Length + 1];
        ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[(int) Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.ID.RawIndex];
        int index1 = (int) arr.UnsafeArrayIndex<byte>(Component<T1>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(1);
        createBuffers[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(0);
        int index2 = (int) arr.UnsafeArrayIndex<byte>(Component<T2>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(1);
        createBuffers[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(0);
        int index3 = (int) arr.UnsafeArrayIndex<byte>(Component<T3>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(1);
        createBuffers[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(0);
        int index4 = (int) arr.UnsafeArrayIndex<byte>(Component<T4>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index4] = (ComponentStorageBase) Component<T4>.CreateInstance(1);
        createBuffers[index4] = (ComponentStorageBase) Component<T4>.CreateInstance(0);
        int index5 = (int) arr.UnsafeArrayIndex<byte>(Component<T5>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index5] = (ComponentStorageBase) Component<T5>.CreateInstance(1);
        createBuffers[index5] = (ComponentStorageBase) Component<T5>.CreateInstance(0);
        int index6 = (int) arr.UnsafeArrayIndex<byte>(Component<T6>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index6] = (ComponentStorageBase) Component<T6>.CreateInstance(1);
        createBuffers[index6] = (ComponentStorageBase) Component<T6>.CreateInstance(0);
        int index7 = (int) arr.UnsafeArrayIndex<byte>(Component<T7>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index7] = (ComponentStorageBase) Component<T7>.CreateInstance(1);
        createBuffers[index7] = (ComponentStorageBase) Component<T7>.CreateInstance(0);
        int index8 = (int) arr.UnsafeArrayIndex<byte>(Component<T8>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index8] = (ComponentStorageBase) Component<T8>.CreateInstance(1);
        createBuffers[index8] = (ComponentStorageBase) Component<T8>.CreateInstance(0);
        int index9 = (int) arr.UnsafeArrayIndex<byte>(Component<T9>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index9] = (ComponentStorageBase) Component<T9>.CreateInstance(1);
        createBuffers[index9] = (ComponentStorageBase) Component<T9>.CreateInstance(0);
        int index10 = (int) arr.UnsafeArrayIndex<byte>(Component<T10>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index10] = (ComponentStorageBase) Component<T10>.CreateInstance(1);
        createBuffers[index10] = (ComponentStorageBase) Component<T10>.CreateInstance(0);
        int index11 = (int) arr.UnsafeArrayIndex<byte>(Component<T11>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index11] = (ComponentStorageBase) Component<T11>.CreateInstance(1);
        createBuffers[index11] = (ComponentStorageBase) Component<T11>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    internal static class OfComponent<C>
    {
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.ID, Component<C>.ID);
    }
  }
                 
                   internal static class Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
  {
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
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex<Archetype>(rawIndex);
      if (local == null)
        local = CreateArchetype(world);
      return local;

      [MethodImpl(MethodImplOptions.NoInlining)]
      static Archetype CreateArchetype(World world)
      {
        ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.ArchetypeComponentIDs.Length + 1];
        ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[(int) Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.ID.RawIndex];
        int index1 = (int) arr.UnsafeArrayIndex<byte>(Component<T1>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(1);
        createBuffers[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(0);
        int index2 = (int) arr.UnsafeArrayIndex<byte>(Component<T2>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(1);
        createBuffers[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(0);
        int index3 = (int) arr.UnsafeArrayIndex<byte>(Component<T3>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(1);
        createBuffers[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(0);
        int index4 = (int) arr.UnsafeArrayIndex<byte>(Component<T4>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index4] = (ComponentStorageBase) Component<T4>.CreateInstance(1);
        createBuffers[index4] = (ComponentStorageBase) Component<T4>.CreateInstance(0);
        int index5 = (int) arr.UnsafeArrayIndex<byte>(Component<T5>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index5] = (ComponentStorageBase) Component<T5>.CreateInstance(1);
        createBuffers[index5] = (ComponentStorageBase) Component<T5>.CreateInstance(0);
        int index6 = (int) arr.UnsafeArrayIndex<byte>(Component<T6>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index6] = (ComponentStorageBase) Component<T6>.CreateInstance(1);
        createBuffers[index6] = (ComponentStorageBase) Component<T6>.CreateInstance(0);
        int index7 = (int) arr.UnsafeArrayIndex<byte>(Component<T7>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index7] = (ComponentStorageBase) Component<T7>.CreateInstance(1);
        createBuffers[index7] = (ComponentStorageBase) Component<T7>.CreateInstance(0);
        int index8 = (int) arr.UnsafeArrayIndex<byte>(Component<T8>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index8] = (ComponentStorageBase) Component<T8>.CreateInstance(1);
        createBuffers[index8] = (ComponentStorageBase) Component<T8>.CreateInstance(0);
        int index9 = (int) arr.UnsafeArrayIndex<byte>(Component<T9>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index9] = (ComponentStorageBase) Component<T9>.CreateInstance(1);
        createBuffers[index9] = (ComponentStorageBase) Component<T9>.CreateInstance(0);
        int index10 = (int) arr.UnsafeArrayIndex<byte>(Component<T10>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index10] = (ComponentStorageBase) Component<T10>.CreateInstance(1);
        createBuffers[index10] = (ComponentStorageBase) Component<T10>.CreateInstance(0);
        int index11 = (int) arr.UnsafeArrayIndex<byte>(Component<T11>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index11] = (ComponentStorageBase) Component<T11>.CreateInstance(1);
        createBuffers[index11] = (ComponentStorageBase) Component<T11>.CreateInstance(0);
        int index12 = (int) arr.UnsafeArrayIndex<byte>(Component<T12>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index12] = (ComponentStorageBase) Component<T12>.CreateInstance(1);
        createBuffers[index12] = (ComponentStorageBase) Component<T12>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    internal static class OfComponent<C>
    {
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.ID, Component<C>.ID);
    }
  }
                   
                    internal static class Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
  {
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
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex<Archetype>(rawIndex);
      if (local == null)
        local = CreateArchetype(world);
      return local;

      [MethodImpl(MethodImplOptions.NoInlining)]
      static Archetype CreateArchetype(World world)
      {
        ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.ArchetypeComponentIDs.Length + 1];
        ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[(int) Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.ID.RawIndex];
        int index1 = (int) arr.UnsafeArrayIndex<byte>(Component<T1>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(1);
        createBuffers[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(0);
        int index2 = (int) arr.UnsafeArrayIndex<byte>(Component<T2>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(1);
        createBuffers[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(0);
        int index3 = (int) arr.UnsafeArrayIndex<byte>(Component<T3>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(1);
        createBuffers[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(0);
        int index4 = (int) arr.UnsafeArrayIndex<byte>(Component<T4>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index4] = (ComponentStorageBase) Component<T4>.CreateInstance(1);
        createBuffers[index4] = (ComponentStorageBase) Component<T4>.CreateInstance(0);
        int index5 = (int) arr.UnsafeArrayIndex<byte>(Component<T5>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index5] = (ComponentStorageBase) Component<T5>.CreateInstance(1);
        createBuffers[index5] = (ComponentStorageBase) Component<T5>.CreateInstance(0);
        int index6 = (int) arr.UnsafeArrayIndex<byte>(Component<T6>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index6] = (ComponentStorageBase) Component<T6>.CreateInstance(1);
        createBuffers[index6] = (ComponentStorageBase) Component<T6>.CreateInstance(0);
        int index7 = (int) arr.UnsafeArrayIndex<byte>(Component<T7>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index7] = (ComponentStorageBase) Component<T7>.CreateInstance(1);
        createBuffers[index7] = (ComponentStorageBase) Component<T7>.CreateInstance(0);
        int index8 = (int) arr.UnsafeArrayIndex<byte>(Component<T8>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index8] = (ComponentStorageBase) Component<T8>.CreateInstance(1);
        createBuffers[index8] = (ComponentStorageBase) Component<T8>.CreateInstance(0);
        int index9 = (int) arr.UnsafeArrayIndex<byte>(Component<T9>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index9] = (ComponentStorageBase) Component<T9>.CreateInstance(1);
        createBuffers[index9] = (ComponentStorageBase) Component<T9>.CreateInstance(0);
        int index10 = (int) arr.UnsafeArrayIndex<byte>(Component<T10>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index10] = (ComponentStorageBase) Component<T10>.CreateInstance(1);
        createBuffers[index10] = (ComponentStorageBase) Component<T10>.CreateInstance(0);
        int index11 = (int) arr.UnsafeArrayIndex<byte>(Component<T11>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index11] = (ComponentStorageBase) Component<T11>.CreateInstance(1);
        createBuffers[index11] = (ComponentStorageBase) Component<T11>.CreateInstance(0);
        int index12 = (int) arr.UnsafeArrayIndex<byte>(Component<T12>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index12] = (ComponentStorageBase) Component<T12>.CreateInstance(1);
        createBuffers[index12] = (ComponentStorageBase) Component<T12>.CreateInstance(0);
        int index13 = (int) arr.UnsafeArrayIndex<byte>(Component<T13>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index13] = (ComponentStorageBase) Component<T13>.CreateInstance(1);
        createBuffers[index13] = (ComponentStorageBase) Component<T13>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    internal static class OfComponent<C>
    {
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.ID, Component<C>.ID);
    }
  }
                    
                    internal static class Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
  {
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
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex<Archetype>(rawIndex);
      if (local == null)
        local = CreateArchetype(world);
      return local;

      [MethodImpl(MethodImplOptions.NoInlining)]
      static Archetype CreateArchetype(World world)
      {
        ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.ArchetypeComponentIDs.Length + 1];
        ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[(int) Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.ID.RawIndex];
        int index1 = (int) arr.UnsafeArrayIndex<byte>(Component<T1>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(1);
        createBuffers[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(0);
        int index2 = (int) arr.UnsafeArrayIndex<byte>(Component<T2>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(1);
        createBuffers[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(0);
        int index3 = (int) arr.UnsafeArrayIndex<byte>(Component<T3>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(1);
        createBuffers[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(0);
        int index4 = (int) arr.UnsafeArrayIndex<byte>(Component<T4>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index4] = (ComponentStorageBase) Component<T4>.CreateInstance(1);
        createBuffers[index4] = (ComponentStorageBase) Component<T4>.CreateInstance(0);
        int index5 = (int) arr.UnsafeArrayIndex<byte>(Component<T5>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index5] = (ComponentStorageBase) Component<T5>.CreateInstance(1);
        createBuffers[index5] = (ComponentStorageBase) Component<T5>.CreateInstance(0);
        int index6 = (int) arr.UnsafeArrayIndex<byte>(Component<T6>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index6] = (ComponentStorageBase) Component<T6>.CreateInstance(1);
        createBuffers[index6] = (ComponentStorageBase) Component<T6>.CreateInstance(0);
        int index7 = (int) arr.UnsafeArrayIndex<byte>(Component<T7>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index7] = (ComponentStorageBase) Component<T7>.CreateInstance(1);
        createBuffers[index7] = (ComponentStorageBase) Component<T7>.CreateInstance(0);
        int index8 = (int) arr.UnsafeArrayIndex<byte>(Component<T8>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index8] = (ComponentStorageBase) Component<T8>.CreateInstance(1);
        createBuffers[index8] = (ComponentStorageBase) Component<T8>.CreateInstance(0);
        int index9 = (int) arr.UnsafeArrayIndex<byte>(Component<T9>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index9] = (ComponentStorageBase) Component<T9>.CreateInstance(1);
        createBuffers[index9] = (ComponentStorageBase) Component<T9>.CreateInstance(0);
        int index10 = (int) arr.UnsafeArrayIndex<byte>(Component<T10>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index10] = (ComponentStorageBase) Component<T10>.CreateInstance(1);
        createBuffers[index10] = (ComponentStorageBase) Component<T10>.CreateInstance(0);
        int index11 = (int) arr.UnsafeArrayIndex<byte>(Component<T11>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index11] = (ComponentStorageBase) Component<T11>.CreateInstance(1);
        createBuffers[index11] = (ComponentStorageBase) Component<T11>.CreateInstance(0);
        int index12 = (int) arr.UnsafeArrayIndex<byte>(Component<T12>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index12] = (ComponentStorageBase) Component<T12>.CreateInstance(1);
        createBuffers[index12] = (ComponentStorageBase) Component<T12>.CreateInstance(0);
        int index13 = (int) arr.UnsafeArrayIndex<byte>(Component<T13>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index13] = (ComponentStorageBase) Component<T13>.CreateInstance(1);
        createBuffers[index13] = (ComponentStorageBase) Component<T13>.CreateInstance(0);
        int index14 = (int) arr.UnsafeArrayIndex<byte>(Component<T14>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index14] = (ComponentStorageBase) Component<T14>.CreateInstance(1);
        createBuffers[index14] = (ComponentStorageBase) Component<T14>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    internal static class OfComponent<C>
    {
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.ID, Component<C>.ID);
    }
  }
                    
                     internal static class Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
  {
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
    public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.ArchetypeComponentIDs), new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

    internal static Archetype CreateNewOrGetExistingArchetype(World world)
    {
      ushort rawIndex = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.ID.RawIndex;
      ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex<Archetype>(rawIndex);
      if (local == null)
        local = CreateArchetype(world);
      return local;

      [MethodImpl(MethodImplOptions.NoInlining)]
      static Archetype CreateArchetype(World world)
      {
        ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.ArchetypeComponentIDs.Length + 1];
        ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
        byte[] arr = GlobalWorldTables.ComponentTagLocationTable[(int) Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.ID.RawIndex];
        int index1 = (int) arr.UnsafeArrayIndex<byte>(Component<T1>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(1);
        createBuffers[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(0);
        int index2 = (int) arr.UnsafeArrayIndex<byte>(Component<T2>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(1);
        createBuffers[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(0);
        int index3 = (int) arr.UnsafeArrayIndex<byte>(Component<T3>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(1);
        createBuffers[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(0);
        int index4 = (int) arr.UnsafeArrayIndex<byte>(Component<T4>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index4] = (ComponentStorageBase) Component<T4>.CreateInstance(1);
        createBuffers[index4] = (ComponentStorageBase) Component<T4>.CreateInstance(0);
        int index5 = (int) arr.UnsafeArrayIndex<byte>(Component<T5>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index5] = (ComponentStorageBase) Component<T5>.CreateInstance(1);
        createBuffers[index5] = (ComponentStorageBase) Component<T5>.CreateInstance(0);
        int index6 = (int) arr.UnsafeArrayIndex<byte>(Component<T6>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index6] = (ComponentStorageBase) Component<T6>.CreateInstance(1);
        createBuffers[index6] = (ComponentStorageBase) Component<T6>.CreateInstance(0);
        int index7 = (int) arr.UnsafeArrayIndex<byte>(Component<T7>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index7] = (ComponentStorageBase) Component<T7>.CreateInstance(1);
        createBuffers[index7] = (ComponentStorageBase) Component<T7>.CreateInstance(0);
        int index8 = (int) arr.UnsafeArrayIndex<byte>(Component<T8>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index8] = (ComponentStorageBase) Component<T8>.CreateInstance(1);
        createBuffers[index8] = (ComponentStorageBase) Component<T8>.CreateInstance(0);
        int index9 = (int) arr.UnsafeArrayIndex<byte>(Component<T9>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index9] = (ComponentStorageBase) Component<T9>.CreateInstance(1);
        createBuffers[index9] = (ComponentStorageBase) Component<T9>.CreateInstance(0);
        int index10 = (int) arr.UnsafeArrayIndex<byte>(Component<T10>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index10] = (ComponentStorageBase) Component<T10>.CreateInstance(1);
        createBuffers[index10] = (ComponentStorageBase) Component<T10>.CreateInstance(0);
        int index11 = (int) arr.UnsafeArrayIndex<byte>(Component<T11>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index11] = (ComponentStorageBase) Component<T11>.CreateInstance(1);
        createBuffers[index11] = (ComponentStorageBase) Component<T11>.CreateInstance(0);
        int index12 = (int) arr.UnsafeArrayIndex<byte>(Component<T12>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index12] = (ComponentStorageBase) Component<T12>.CreateInstance(1);
        createBuffers[index12] = (ComponentStorageBase) Component<T12>.CreateInstance(0);
        int index13 = (int) arr.UnsafeArrayIndex<byte>(Component<T13>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index13] = (ComponentStorageBase) Component<T13>.CreateInstance(1);
        createBuffers[index13] = (ComponentStorageBase) Component<T13>.CreateInstance(0);
        int index14 = (int) arr.UnsafeArrayIndex<byte>(Component<T14>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index14] = (ComponentStorageBase) Component<T14>.CreateInstance(1);
        createBuffers[index14] = (ComponentStorageBase) Component<T14>.CreateInstance(0);
        int index15 = (int) arr.UnsafeArrayIndex<byte>(Component<T15>.ID.RawIndex) & (int) sbyte.MaxValue;
        components[index15] = (ComponentStorageBase) Component<T15>.CreateInstance(1);
        createBuffers[index15] = (ComponentStorageBase) Component<T15>.CreateInstance(0);
        Archetype archetype = new Archetype(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.ID, components, createBuffers);
        world.ArchetypeAdded(archetype);
        return archetype;
      }
    }

    internal static class OfComponent<C>
    {
      public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.ID, Component<C>.ID);
    }
  }

  internal static class Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
  {
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

      public static readonly EntityType ID = Archetype.GetArchetypeID(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.ArchetypeComponentIDs.AsSpan(), new ReadOnlySpan<TagId>(), new FastImmutableArray<ComponentID>?(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.ArchetypeComponentIDs),
          new FastImmutableArray<TagId>?(FastImmutableArray<TagId>.Empty));

      internal static Archetype CreateNewOrGetExistingArchetype(World world)
      {
          ushort rawIndex = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.ID.RawIndex;
          ref Archetype local = ref world.WorldArchetypeTable.UnsafeArrayIndex<Archetype>(rawIndex);
          if (local == null)
              local = CreateArchetype(world);
          return local;

          [MethodImpl(MethodImplOptions.NoInlining)]
          static Archetype CreateArchetype(World world)
          {
              ComponentStorageBase[] components = new ComponentStorageBase[Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.ArchetypeComponentIDs.Length + 1];
              ComponentStorageBase[] createBuffers = new ComponentStorageBase[components.Length];
              byte[] arr = GlobalWorldTables.ComponentTagLocationTable[(int) Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.ID.RawIndex];
              int index1 = (int) arr.UnsafeArrayIndex<byte>(Component<T1>.ID.RawIndex) & (int) sbyte.MaxValue;
              components[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(1);
              createBuffers[index1] = (ComponentStorageBase) Component<T1>.CreateInstance(0);
              int index2 = (int) arr.UnsafeArrayIndex<byte>(Component<T2>.ID.RawIndex) & (int) sbyte.MaxValue;
              components[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(1);
              createBuffers[index2] = (ComponentStorageBase) Component<T2>.CreateInstance(0);
              int index3 = (int) arr.UnsafeArrayIndex<byte>(Component<T3>.ID.RawIndex) & (int) sbyte.MaxValue;
              components[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(1);
              createBuffers[index3] = (ComponentStorageBase) Component<T3>.CreateInstance(0);
              int index4 = (int) arr.UnsafeArrayIndex<byte>(Component<T4>.ID.RawIndex) & (int) sbyte.MaxValue;
              components[index4] = (ComponentStorageBase) Component<T4>.CreateInstance(1);
              createBuffers[index4] = (ComponentStorageBase) Component<T4>.CreateInstance(0);
              int index5 = (int) arr.UnsafeArrayIndex<byte>(Component<T5>.ID.RawIndex) & (int) sbyte.MaxValue;
              components[index5] = (ComponentStorageBase) Component<T5>.CreateInstance(1);
              createBuffers[index5] = (ComponentStorageBase) Component<T5>.CreateInstance(0);
              int index6 = (int) arr.UnsafeArrayIndex<byte>(Component<T6>.ID.RawIndex) & (int) sbyte.MaxValue;
              components[index6] = (ComponentStorageBase) Component<T6>.CreateInstance(1);
              createBuffers[index6] = (ComponentStorageBase) Component<T6>.CreateInstance(0);
              int index7 = (int) arr.UnsafeArrayIndex<byte>(Component<T7>.ID.RawIndex) & (int) sbyte.MaxValue;
              components[index7] = (ComponentStorageBase) Component<T7>.CreateInstance(1);
              createBuffers[index7] = (ComponentStorageBase) Component<T7>.CreateInstance(0);
              int index8 = (int) arr.UnsafeArrayIndex<byte>(Component<T8>.ID.RawIndex) & (int) sbyte.MaxValue;
              components[index8] = (ComponentStorageBase) Component<T8>.CreateInstance(1);
              createBuffers[index8] = (ComponentStorageBase) Component<T8>.CreateInstance(0);
              int index9 = (int) arr.UnsafeArrayIndex<byte>(Component<T9>.ID.RawIndex) & (int) sbyte.MaxValue;
              components[index9] = (ComponentStorageBase) Component<T9>.CreateInstance(1);
              createBuffers[index9] = (ComponentStorageBase) Component<T9>.CreateInstance(0);
              int index10 = (int) arr.UnsafeArrayIndex<byte>(Component<T10>.ID.RawIndex) & (int) sbyte.MaxValue;
              components[index10] = (ComponentStorageBase) Component<T10>.CreateInstance(1);
              createBuffers[index10] = (ComponentStorageBase) Component<T10>.CreateInstance(0);
              int index11 = (int) arr.UnsafeArrayIndex<byte>(Component<T11>.ID.RawIndex) & (int) sbyte.MaxValue;
              components[index11] = (ComponentStorageBase) Component<T11>.CreateInstance(1);
              createBuffers[index11] = (ComponentStorageBase) Component<T11>.CreateInstance(0);
              int index12 = (int) arr.UnsafeArrayIndex<byte>(Component<T12>.ID.RawIndex) & (int) sbyte.MaxValue;
              components[index12] = (ComponentStorageBase) Component<T12>.CreateInstance(1);
              createBuffers[index12] = (ComponentStorageBase) Component<T12>.CreateInstance(0);
              int index13 = (int) arr.UnsafeArrayIndex<byte>(Component<T13>.ID.RawIndex) & (int) sbyte.MaxValue;
              components[index13] = (ComponentStorageBase) Component<T13>.CreateInstance(1);
              createBuffers[index13] = (ComponentStorageBase) Component<T13>.CreateInstance(0);
              int index14 = (int) arr.UnsafeArrayIndex<byte>(Component<T14>.ID.RawIndex) & (int) sbyte.MaxValue;
              components[index14] = (ComponentStorageBase) Component<T14>.CreateInstance(1);
              createBuffers[index14] = (ComponentStorageBase) Component<T14>.CreateInstance(0);
              int index15 = (int) arr.UnsafeArrayIndex<byte>(Component<T15>.ID.RawIndex) & (int) sbyte.MaxValue;
              components[index15] = (ComponentStorageBase) Component<T15>.CreateInstance(1);
              createBuffers[index15] = (ComponentStorageBase) Component<T15>.CreateInstance(0);
              int index16 = (int) arr.UnsafeArrayIndex<byte>(Component<T16>.ID.RawIndex) & (int) sbyte.MaxValue;
              components[index16] = (ComponentStorageBase) Component<T16>.CreateInstance(1);
              createBuffers[index16] = (ComponentStorageBase) Component<T16>.CreateInstance(0);
              Archetype archetype = new Archetype(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.ID, components, createBuffers);
              world.ArchetypeAdded(archetype);
              return archetype;
          }
      }

      internal static class OfComponent<C>
      {
          public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.ID, Component<C>.ID);
      }
  }
}