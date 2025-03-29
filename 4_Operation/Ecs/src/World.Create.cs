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

using System;
using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Core;
using Alis.Core.Ecs.Core.Archetype;
using Alis.Core.Ecs.Core.Memory;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    public partial class World
    {
             [SkipLocalsInit]
    public Entity Create<T1, T2>(in T1 comp1, in T2 comp2)
    {
      Archetype existingArchetype = Archetype<T1, T2>.CreateNewOrGetExistingArchetype(this);
      
      EntityLocation entityLocation = new EntityLocation();
      Unsafe.SkipInit<int>(out int physicalIndex);
      ComponentStorageBase[] writeStorage;
      // ISSUE: variable of a reference type
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
      ref T1 local2 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2>.OfComponent<T1>.Index))[physicalIndex];
      local2 = comp1;
      ref T2 local3 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2>.OfComponent<T2>.Index))[physicalIndex];
      local3 = comp2;
      Entity entity = new Entity(this.ID, version, num);
      ComponentDelegates<T1>.InitDelegate initer1 = Component<T1>.Initer;
      if (initer1 != null)
        initer1(entity, ref local2);
      ComponentDelegates<T2>.InitDelegate initer2 = Component<T2>.Initer;
      if (initer2 != null)
        initer2(entity, ref local3);
      this.EntityCreatedEvent.Invoke(entity);
      return entity;
    }

    /// <summary>Creates a large amount of entities quickly</summary>
    /// <param name="count">The number of entities to create</param>
    /// <returns>The entities created and their component spans</returns>
    public ChunkTuple<T1, T2> CreateMany<T1, T2>(int count)
    {
      if (count < 0)
        FrentExceptions.Throw_ArgumentOutOfRangeException("Must create at least 1 entity!");
      Archetype existingArchetype = Archetype<T1, T2>.CreateNewOrGetExistingArchetype(this);
      int entityCount = existingArchetype.EntityCount;
      this.EntityTable.EnsureCapacity(this.EntityCount + count);
      Span<EntityIdOnly> entityLocations = existingArchetype.CreateEntityLocations(count, this);
      if (this.EntityCreatedEvent.HasListeners)
      {
        Span<EntityIdOnly> span = entityLocations;
        for (int index = 0; index < span.Length; ++index)
          this.EntityCreatedEvent.Invoke(span[index].ToEntity(this));
      }
      ChunkTuple<T1, T2> many = new ChunkTuple<T1, T2>();
      many.Entities = new EntityEnumerator.EntityEnumerable(this, entityLocations);
      ref ChunkTuple<T1, T2> local1 = ref many;
      Span<T1> componentSpan1 = existingArchetype.GetComponentSpan<T1>();
      ref Span<T1> local2 = ref componentSpan1;
      int start1 = entityCount;
      Span<T1> span1 = local2.Slice(start1, local2.Length - start1);
      local1.Span1 = span1;
      ref ChunkTuple<T1, T2> local3 = ref many;
      Span<T2> componentSpan2 = existingArchetype.GetComponentSpan<T2>();
      ref Span<T2> local4 = ref componentSpan2;
      int start2 = entityCount;
      Span<T2> span2 = local4.Slice(start2, local4.Length - start2);
      local3.Span2 = span2;
      return many;
    }

    /// <summary>
    /// Creates an <see cref="T:Frent.Entity" /> with the given component(s)
    /// </summary>
    /// <returns>An <see cref="T:Frent.Entity" /> that can be used to acsess the component data</returns>
    [SkipLocalsInit]
    public Entity Create<T1, T2, T3>(in T1 comp1, in T2 comp2, in T3 comp3)
    {
      Archetype existingArchetype = Archetype<T1, T2, T3>.CreateNewOrGetExistingArchetype(this);
      
      EntityLocation entityLocation = new EntityLocation();
      Unsafe.SkipInit<int>(out int physicalIndex);
      ComponentStorageBase[] writeStorage;
      // ISSUE: variable of a reference type
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

    /// <summary>Creates a large amount of entities quickly</summary>
    /// <param name="count">The number of entities to create</param>
    /// <returns>The entities created and their component spans</returns>
    public ChunkTuple<T1, T2, T3> CreateMany<T1, T2, T3>(int count)
    {
      if (count < 0)
        FrentExceptions.Throw_ArgumentOutOfRangeException("Must create at least 1 entity!");
      Archetype existingArchetype = Archetype<T1, T2, T3>.CreateNewOrGetExistingArchetype(this);
      int entityCount = existingArchetype.EntityCount;
      this.EntityTable.EnsureCapacity(this.EntityCount + count);
      Span<EntityIdOnly> entityLocations = existingArchetype.CreateEntityLocations(count, this);
      if (this.EntityCreatedEvent.HasListeners)
      {
        Span<EntityIdOnly> span = entityLocations;
        for (int index = 0; index < span.Length; ++index)
          this.EntityCreatedEvent.Invoke(span[index].ToEntity(this));
      }
      ChunkTuple<T1, T2, T3> many = new ChunkTuple<T1, T2, T3>();
      many.Entities = new EntityEnumerator.EntityEnumerable(this, entityLocations);
      ref ChunkTuple<T1, T2, T3> local1 = ref many;
      Span<T1> componentSpan1 = existingArchetype.GetComponentSpan<T1>();
      ref Span<T1> local2 = ref componentSpan1;
      int start1 = entityCount;
      Span<T1> span1 = local2.Slice(start1, local2.Length - start1);
      local1.Span1 = span1;
      ref ChunkTuple<T1, T2, T3> local3 = ref many;
      Span<T2> componentSpan2 = existingArchetype.GetComponentSpan<T2>();
      ref Span<T2> local4 = ref componentSpan2;
      int start2 = entityCount;
      Span<T2> span2 = local4.Slice(start2, local4.Length - start2);
      local3.Span2 = span2;
      ref ChunkTuple<T1, T2, T3> local5 = ref many;
      Span<T3> componentSpan3 = existingArchetype.GetComponentSpan<T3>();
      ref Span<T3> local6 = ref componentSpan3;
      int start3 = entityCount;
      Span<T3> span3 = local6.Slice(start3, local6.Length - start3);
      local5.Span3 = span3;
      return many;
    }
    
        
        
        [SkipLocalsInit]
    public Entity Create<T1, T2, T3, T4>(in T1 comp1, in T2 comp2, in T3 comp3, in T4 comp4)
    {
      Archetype existingArchetype = Archetype<T1, T2, T3, T4>.CreateNewOrGetExistingArchetype(this);
      
      EntityLocation entityLocation = new EntityLocation();
      Unsafe.SkipInit<int>(out int physicalIndex);
      ComponentStorageBase[] writeStorage;
      // ISSUE: variable of a reference type
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
      ref T1 local2 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4>.OfComponent<T1>.Index))[physicalIndex];
      local2 = comp1;
      ref T2 local3 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4>.OfComponent<T2>.Index))[physicalIndex];
      local3 = comp2;
      ref T3 local4 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T3>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4>.OfComponent<T3>.Index))[physicalIndex];
      local4 = comp3;
      ref T4 local5 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T4>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4>.OfComponent<T4>.Index))[physicalIndex];
      local5 = comp4;
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
      ComponentDelegates<T4>.InitDelegate initer4 = Component<T4>.Initer;
      if (initer4 != null)
        initer4(entity, ref local5);
      this.EntityCreatedEvent.Invoke(entity);
      return entity;
    }

    /// <summary>Creates a large amount of entities quickly</summary>
    /// <param name="count">The number of entities to create</param>
    /// <returns>The entities created and their component spans</returns>
    public ChunkTuple<T1, T2, T3, T4> CreateMany<T1, T2, T3, T4>(int count)
    {
      if (count < 0)
        FrentExceptions.Throw_ArgumentOutOfRangeException("Must create at least 1 entity!");
      Archetype existingArchetype = Archetype<T1, T2, T3, T4>.CreateNewOrGetExistingArchetype(this);
      int entityCount = existingArchetype.EntityCount;
      this.EntityTable.EnsureCapacity(this.EntityCount + count);
      Span<EntityIdOnly> entityLocations = existingArchetype.CreateEntityLocations(count, this);
      if (this.EntityCreatedEvent.HasListeners)
      {
        Span<EntityIdOnly> span = entityLocations;
        for (int index = 0; index < span.Length; ++index)
          this.EntityCreatedEvent.Invoke(span[index].ToEntity(this));
      }
      ChunkTuple<T1, T2, T3, T4> many = new ChunkTuple<T1, T2, T3, T4>();
      many.Entities = new EntityEnumerator.EntityEnumerable(this, entityLocations);
      ref ChunkTuple<T1, T2, T3, T4> local1 = ref many;
      Span<T1> componentSpan1 = existingArchetype.GetComponentSpan<T1>();
      ref Span<T1> local2 = ref componentSpan1;
      int start1 = entityCount;
      Span<T1> span1 = local2.Slice(start1, local2.Length - start1);
      local1.Span1 = span1;
      ref ChunkTuple<T1, T2, T3, T4> local3 = ref many;
      Span<T2> componentSpan2 = existingArchetype.GetComponentSpan<T2>();
      ref Span<T2> local4 = ref componentSpan2;
      int start2 = entityCount;
      Span<T2> span2 = local4.Slice(start2, local4.Length - start2);
      local3.Span2 = span2;
      ref ChunkTuple<T1, T2, T3, T4> local5 = ref many;
      Span<T3> componentSpan3 = existingArchetype.GetComponentSpan<T3>();
      ref Span<T3> local6 = ref componentSpan3;
      int start3 = entityCount;
      Span<T3> span3 = local6.Slice(start3, local6.Length - start3);
      local5.Span3 = span3;
      ref ChunkTuple<T1, T2, T3, T4> local7 = ref many;
      Span<T4> componentSpan4 = existingArchetype.GetComponentSpan<T4>();
      ref Span<T4> local8 = ref componentSpan4;
      int start4 = entityCount;
      Span<T4> span4 = local8.Slice(start4, local8.Length - start4);
      local7.Span4 = span4;
      return many;
    }

    /// <summary>
    /// Creates an <see cref="T:Frent.Entity" /> with the given component(s)
    /// </summary>
    /// <returns>An <see cref="T:Frent.Entity" /> that can be used to acsess the component data</returns>
    [SkipLocalsInit]
    public Entity Create<T1, T2, T3, T4, T5>(
      in T1 comp1,
      in T2 comp2,
      in T3 comp3,
      in T4 comp4,
      in T5 comp5)
    {
      Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5>.CreateNewOrGetExistingArchetype(this);
      
      EntityLocation entityLocation = new EntityLocation();
      Unsafe.SkipInit<int>(out int physicalIndex);
      ComponentStorageBase[] writeStorage;
      // ISSUE: variable of a reference type
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
      ref T1 local2 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5>.OfComponent<T1>.Index))[physicalIndex];
      local2 = comp1;
      ref T2 local3 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5>.OfComponent<T2>.Index))[physicalIndex];
      local3 = comp2;
      ref T3 local4 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T3>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5>.OfComponent<T3>.Index))[physicalIndex];
      local4 = comp3;
      ref T4 local5 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T4>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5>.OfComponent<T4>.Index))[physicalIndex];
      local5 = comp4;
      ref T5 local6 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T5>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5>.OfComponent<T5>.Index))[physicalIndex];
      local6 = comp5;
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
      ComponentDelegates<T4>.InitDelegate initer4 = Component<T4>.Initer;
      if (initer4 != null)
        initer4(entity, ref local5);
      ComponentDelegates<T5>.InitDelegate initer5 = Component<T5>.Initer;
      if (initer5 != null)
        initer5(entity, ref local6);
      this.EntityCreatedEvent.Invoke(entity);
      return entity;
    }

    /// <summary>Creates a large amount of entities quickly</summary>
    /// <param name="count">The number of entities to create</param>
    /// <returns>The entities created and their component spans</returns>
    public ChunkTuple<T1, T2, T3, T4, T5> CreateMany<T1, T2, T3, T4, T5>(int count)
    {
      if (count < 0)
        FrentExceptions.Throw_ArgumentOutOfRangeException("Must create at least 1 entity!");
      Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5>.CreateNewOrGetExistingArchetype(this);
      int entityCount = existingArchetype.EntityCount;
      this.EntityTable.EnsureCapacity(this.EntityCount + count);
      Span<EntityIdOnly> entityLocations = existingArchetype.CreateEntityLocations(count, this);
      if (this.EntityCreatedEvent.HasListeners)
      {
        Span<EntityIdOnly> span = entityLocations;
        for (int index = 0; index < span.Length; ++index)
          this.EntityCreatedEvent.Invoke(span[index].ToEntity(this));
      }
      ChunkTuple<T1, T2, T3, T4, T5> many = new ChunkTuple<T1, T2, T3, T4, T5>();
      many.Entities = new EntityEnumerator.EntityEnumerable(this, entityLocations);
      ref ChunkTuple<T1, T2, T3, T4, T5> local1 = ref many;
      Span<T1> componentSpan1 = existingArchetype.GetComponentSpan<T1>();
      ref Span<T1> local2 = ref componentSpan1;
      int start1 = entityCount;
      Span<T1> span1 = local2.Slice(start1, local2.Length - start1);
      local1.Span1 = span1;
      ref ChunkTuple<T1, T2, T3, T4, T5> local3 = ref many;
      Span<T2> componentSpan2 = existingArchetype.GetComponentSpan<T2>();
      ref Span<T2> local4 = ref componentSpan2;
      int start2 = entityCount;
      Span<T2> span2 = local4.Slice(start2, local4.Length - start2);
      local3.Span2 = span2;
      ref ChunkTuple<T1, T2, T3, T4, T5> local5 = ref many;
      Span<T3> componentSpan3 = existingArchetype.GetComponentSpan<T3>();
      ref Span<T3> local6 = ref componentSpan3;
      int start3 = entityCount;
      Span<T3> span3 = local6.Slice(start3, local6.Length - start3);
      local5.Span3 = span3;
      ref ChunkTuple<T1, T2, T3, T4, T5> local7 = ref many;
      Span<T4> componentSpan4 = existingArchetype.GetComponentSpan<T4>();
      ref Span<T4> local8 = ref componentSpan4;
      int start4 = entityCount;
      Span<T4> span4 = local8.Slice(start4, local8.Length - start4);
      local7.Span4 = span4;
      ref ChunkTuple<T1, T2, T3, T4, T5> local9 = ref many;
      Span<T5> componentSpan5 = existingArchetype.GetComponentSpan<T5>();
      ref Span<T5> local10 = ref componentSpan5;
      int start5 = entityCount;
      Span<T5> span5 = local10.Slice(start5, local10.Length - start5);
      local9.Span5 = span5;
      return many;
    }

    /// <summary>
    /// Creates an <see cref="T:Frent.Entity" /> with the given component(s)
    /// </summary>
    /// <returns>An <see cref="T:Frent.Entity" /> that can be used to acsess the component data</returns>
    [SkipLocalsInit]
    public Entity Create<T1, T2, T3, T4, T5, T6>(
      in T1 comp1,
      in T2 comp2,
      in T3 comp3,
      in T4 comp4,
      in T5 comp5,
      in T6 comp6)
    {
      Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6>.CreateNewOrGetExistingArchetype(this);
      
      EntityLocation entityLocation = new EntityLocation();
      Unsafe.SkipInit<int>(out int physicalIndex);
      ComponentStorageBase[] writeStorage;
      // ISSUE: variable of a reference type
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
      ref T1 local2 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6>.OfComponent<T1>.Index))[physicalIndex];
      local2 = comp1;
      ref T2 local3 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6>.OfComponent<T2>.Index))[physicalIndex];
      local3 = comp2;
      ref T3 local4 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T3>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6>.OfComponent<T3>.Index))[physicalIndex];
      local4 = comp3;
      ref T4 local5 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T4>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6>.OfComponent<T4>.Index))[physicalIndex];
      local5 = comp4;
      ref T5 local6 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T5>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6>.OfComponent<T5>.Index))[physicalIndex];
      local6 = comp5;
      ref T6 local7 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T6>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6>.OfComponent<T6>.Index))[physicalIndex];
      local7 = comp6;
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
      ComponentDelegates<T4>.InitDelegate initer4 = Component<T4>.Initer;
      if (initer4 != null)
        initer4(entity, ref local5);
      ComponentDelegates<T5>.InitDelegate initer5 = Component<T5>.Initer;
      if (initer5 != null)
        initer5(entity, ref local6);
      ComponentDelegates<T6>.InitDelegate initer6 = Component<T6>.Initer;
      if (initer6 != null)
        initer6(entity, ref local7);
      this.EntityCreatedEvent.Invoke(entity);
      return entity;
    }

    /// <summary>Creates a large amount of entities quickly</summary>
    /// <param name="count">The number of entities to create</param>
    /// <returns>The entities created and their component spans</returns>
    public ChunkTuple<T1, T2, T3, T4, T5, T6> CreateMany<T1, T2, T3, T4, T5, T6>(int count)
    {
      if (count < 0)
        FrentExceptions.Throw_ArgumentOutOfRangeException("Must create at least 1 entity!");
      Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6>.CreateNewOrGetExistingArchetype(this);
      int entityCount = existingArchetype.EntityCount;
      this.EntityTable.EnsureCapacity(this.EntityCount + count);
      Span<EntityIdOnly> entityLocations = existingArchetype.CreateEntityLocations(count, this);
      if (this.EntityCreatedEvent.HasListeners)
      {
        Span<EntityIdOnly> span = entityLocations;
        for (int index = 0; index < span.Length; ++index)
          this.EntityCreatedEvent.Invoke(span[index].ToEntity(this));
      }
      ChunkTuple<T1, T2, T3, T4, T5, T6> many = new ChunkTuple<T1, T2, T3, T4, T5, T6>();
      many.Entities = new EntityEnumerator.EntityEnumerable(this, entityLocations);
      ref ChunkTuple<T1, T2, T3, T4, T5, T6> local1 = ref many;
      Span<T1> componentSpan1 = existingArchetype.GetComponentSpan<T1>();
      ref Span<T1> local2 = ref componentSpan1;
      int start1 = entityCount;
      Span<T1> span1 = local2.Slice(start1, local2.Length - start1);
      local1.Span1 = span1;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6> local3 = ref many;
      Span<T2> componentSpan2 = existingArchetype.GetComponentSpan<T2>();
      ref Span<T2> local4 = ref componentSpan2;
      int start2 = entityCount;
      Span<T2> span2 = local4.Slice(start2, local4.Length - start2);
      local3.Span2 = span2;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6> local5 = ref many;
      Span<T3> componentSpan3 = existingArchetype.GetComponentSpan<T3>();
      ref Span<T3> local6 = ref componentSpan3;
      int start3 = entityCount;
      Span<T3> span3 = local6.Slice(start3, local6.Length - start3);
      local5.Span3 = span3;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6> local7 = ref many;
      Span<T4> componentSpan4 = existingArchetype.GetComponentSpan<T4>();
      ref Span<T4> local8 = ref componentSpan4;
      int start4 = entityCount;
      Span<T4> span4 = local8.Slice(start4, local8.Length - start4);
      local7.Span4 = span4;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6> local9 = ref many;
      Span<T5> componentSpan5 = existingArchetype.GetComponentSpan<T5>();
      ref Span<T5> local10 = ref componentSpan5;
      int start5 = entityCount;
      Span<T5> span5 = local10.Slice(start5, local10.Length - start5);
      local9.Span5 = span5;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6> local11 = ref many;
      Span<T6> componentSpan6 = existingArchetype.GetComponentSpan<T6>();
      ref Span<T6> local12 = ref componentSpan6;
      int start6 = entityCount;
      Span<T6> span6 = local12.Slice(start6, local12.Length - start6);
      local11.Span6 = span6;
      return many;
    }

    /// <summary>
    /// Creates an <see cref="T:Frent.Entity" /> with the given component(s)
    /// </summary>
    /// <returns>An <see cref="T:Frent.Entity" /> that can be used to acsess the component data</returns>
    [SkipLocalsInit]
    public Entity Create<T1, T2, T3, T4, T5, T6, T7>(
      in T1 comp1,
      in T2 comp2,
      in T3 comp3,
      in T4 comp4,
      in T5 comp5,
      in T6 comp6,
      in T7 comp7)
    {
      Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6, T7>.CreateNewOrGetExistingArchetype(this);
      
      EntityLocation entityLocation = new EntityLocation();
      Unsafe.SkipInit<int>(out int physicalIndex);
      ComponentStorageBase[] writeStorage;
      // ISSUE: variable of a reference type
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
      ref T1 local2 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7>.OfComponent<T1>.Index))[physicalIndex];
      local2 = comp1;
      ref T2 local3 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7>.OfComponent<T2>.Index))[physicalIndex];
      local3 = comp2;
      ref T3 local4 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T3>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7>.OfComponent<T3>.Index))[physicalIndex];
      local4 = comp3;
      ref T4 local5 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T4>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7>.OfComponent<T4>.Index))[physicalIndex];
      local5 = comp4;
      ref T5 local6 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T5>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7>.OfComponent<T5>.Index))[physicalIndex];
      local6 = comp5;
      ref T6 local7 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T6>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7>.OfComponent<T6>.Index))[physicalIndex];
      local7 = comp6;
      ref T7 local8 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T7>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7>.OfComponent<T7>.Index))[physicalIndex];
      local8 = comp7;
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
      ComponentDelegates<T4>.InitDelegate initer4 = Component<T4>.Initer;
      if (initer4 != null)
        initer4(entity, ref local5);
      ComponentDelegates<T5>.InitDelegate initer5 = Component<T5>.Initer;
      if (initer5 != null)
        initer5(entity, ref local6);
      ComponentDelegates<T6>.InitDelegate initer6 = Component<T6>.Initer;
      if (initer6 != null)
        initer6(entity, ref local7);
      ComponentDelegates<T7>.InitDelegate initer7 = Component<T7>.Initer;
      if (initer7 != null)
        initer7(entity, ref local8);
      this.EntityCreatedEvent.Invoke(entity);
      return entity;
    }

    /// <summary>Creates a large amount of entities quickly</summary>
    /// <param name="count">The number of entities to create</param>
    /// <returns>The entities created and their component spans</returns>
    public ChunkTuple<T1, T2, T3, T4, T5, T6, T7> CreateMany<T1, T2, T3, T4, T5, T6, T7>(int count)
    {
      if (count < 0)
        FrentExceptions.Throw_ArgumentOutOfRangeException("Must create at least 1 entity!");
      Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6, T7>.CreateNewOrGetExistingArchetype(this);
      int entityCount = existingArchetype.EntityCount;
      this.EntityTable.EnsureCapacity(this.EntityCount + count);
      Span<EntityIdOnly> entityLocations = existingArchetype.CreateEntityLocations(count, this);
      if (this.EntityCreatedEvent.HasListeners)
      {
        Span<EntityIdOnly> span = entityLocations;
        for (int index = 0; index < span.Length; ++index)
          this.EntityCreatedEvent.Invoke(span[index].ToEntity(this));
      }
      ChunkTuple<T1, T2, T3, T4, T5, T6, T7> many = new ChunkTuple<T1, T2, T3, T4, T5, T6, T7>();
      many.Entities = new EntityEnumerator.EntityEnumerable(this, entityLocations);
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7> local1 = ref many;
      Span<T1> componentSpan1 = existingArchetype.GetComponentSpan<T1>();
      ref Span<T1> local2 = ref componentSpan1;
      int start1 = entityCount;
      Span<T1> span1 = local2.Slice(start1, local2.Length - start1);
      local1.Span1 = span1;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7> local3 = ref many;
      Span<T2> componentSpan2 = existingArchetype.GetComponentSpan<T2>();
      ref Span<T2> local4 = ref componentSpan2;
      int start2 = entityCount;
      Span<T2> span2 = local4.Slice(start2, local4.Length - start2);
      local3.Span2 = span2;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7> local5 = ref many;
      Span<T3> componentSpan3 = existingArchetype.GetComponentSpan<T3>();
      ref Span<T3> local6 = ref componentSpan3;
      int start3 = entityCount;
      Span<T3> span3 = local6.Slice(start3, local6.Length - start3);
      local5.Span3 = span3;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7> local7 = ref many;
      Span<T4> componentSpan4 = existingArchetype.GetComponentSpan<T4>();
      ref Span<T4> local8 = ref componentSpan4;
      int start4 = entityCount;
      Span<T4> span4 = local8.Slice(start4, local8.Length - start4);
      local7.Span4 = span4;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7> local9 = ref many;
      Span<T5> componentSpan5 = existingArchetype.GetComponentSpan<T5>();
      ref Span<T5> local10 = ref componentSpan5;
      int start5 = entityCount;
      Span<T5> span5 = local10.Slice(start5, local10.Length - start5);
      local9.Span5 = span5;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7> local11 = ref many;
      Span<T6> componentSpan6 = existingArchetype.GetComponentSpan<T6>();
      ref Span<T6> local12 = ref componentSpan6;
      int start6 = entityCount;
      Span<T6> span6 = local12.Slice(start6, local12.Length - start6);
      local11.Span6 = span6;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7> local13 = ref many;
      Span<T7> componentSpan7 = existingArchetype.GetComponentSpan<T7>();
      ref Span<T7> local14 = ref componentSpan7;
      int start7 = entityCount;
      Span<T7> span7 = local14.Slice(start7, local14.Length - start7);
      local13.Span7 = span7;
      return many;
    }

    /// <summary>
    /// Creates an <see cref="T:Frent.Entity" /> with the given component(s)
    /// </summary>
    /// <returns>An <see cref="T:Frent.Entity" /> that can be used to acsess the component data</returns>
    [SkipLocalsInit]
    public Entity Create<T1, T2, T3, T4, T5, T6, T7, T8>(
      in T1 comp1,
      in T2 comp2,
      in T3 comp3,
      in T4 comp4,
      in T5 comp5,
      in T6 comp6,
      in T7 comp7,
      in T8 comp8)
    {
      Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6, T7, T8>.CreateNewOrGetExistingArchetype(this);
      
      EntityLocation entityLocation = new EntityLocation();
      Unsafe.SkipInit<int>(out int physicalIndex);
      ComponentStorageBase[] writeStorage;
      // ISSUE: variable of a reference type
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
      ref T1 local2 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8>.OfComponent<T1>.Index))[physicalIndex];
      local2 = comp1;
      ref T2 local3 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8>.OfComponent<T2>.Index))[physicalIndex];
      local3 = comp2;
      ref T3 local4 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T3>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8>.OfComponent<T3>.Index))[physicalIndex];
      local4 = comp3;
      ref T4 local5 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T4>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8>.OfComponent<T4>.Index))[physicalIndex];
      local5 = comp4;
      ref T5 local6 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T5>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8>.OfComponent<T5>.Index))[physicalIndex];
      local6 = comp5;
      ref T6 local7 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T6>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8>.OfComponent<T6>.Index))[physicalIndex];
      local7 = comp6;
      ref T7 local8 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T7>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8>.OfComponent<T7>.Index))[physicalIndex];
      local8 = comp7;
      ref T8 local9 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T8>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8>.OfComponent<T8>.Index))[physicalIndex];
      local9 = comp8;
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
      ComponentDelegates<T4>.InitDelegate initer4 = Component<T4>.Initer;
      if (initer4 != null)
        initer4(entity, ref local5);
      ComponentDelegates<T5>.InitDelegate initer5 = Component<T5>.Initer;
      if (initer5 != null)
        initer5(entity, ref local6);
      ComponentDelegates<T6>.InitDelegate initer6 = Component<T6>.Initer;
      if (initer6 != null)
        initer6(entity, ref local7);
      ComponentDelegates<T7>.InitDelegate initer7 = Component<T7>.Initer;
      if (initer7 != null)
        initer7(entity, ref local8);
      ComponentDelegates<T8>.InitDelegate initer8 = Component<T8>.Initer;
      if (initer8 != null)
        initer8(entity, ref local9);
      this.EntityCreatedEvent.Invoke(entity);
      return entity;
    }

    /// <summary>Creates a large amount of entities quickly</summary>
    /// <param name="count">The number of entities to create</param>
    /// <returns>The entities created and their component spans</returns>
    public ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8> CreateMany<T1, T2, T3, T4, T5, T6, T7, T8>(
      int count)
    {
      if (count < 0)
        FrentExceptions.Throw_ArgumentOutOfRangeException("Must create at least 1 entity!");
      Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6, T7, T8>.CreateNewOrGetExistingArchetype(this);
      int entityCount = existingArchetype.EntityCount;
      this.EntityTable.EnsureCapacity(this.EntityCount + count);
      Span<EntityIdOnly> entityLocations = existingArchetype.CreateEntityLocations(count, this);
      if (this.EntityCreatedEvent.HasListeners)
      {
        Span<EntityIdOnly> span = entityLocations;
        for (int index = 0; index < span.Length; ++index)
          this.EntityCreatedEvent.Invoke(span[index].ToEntity(this));
      }
      ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8> many = new ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8>();
      many.Entities = new EntityEnumerator.EntityEnumerable(this, entityLocations);
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8> local1 = ref many;
      Span<T1> componentSpan1 = existingArchetype.GetComponentSpan<T1>();
      ref Span<T1> local2 = ref componentSpan1;
      int start1 = entityCount;
      Span<T1> span1 = local2.Slice(start1, local2.Length - start1);
      local1.Span1 = span1;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8> local3 = ref many;
      Span<T2> componentSpan2 = existingArchetype.GetComponentSpan<T2>();
      ref Span<T2> local4 = ref componentSpan2;
      int start2 = entityCount;
      Span<T2> span2 = local4.Slice(start2, local4.Length - start2);
      local3.Span2 = span2;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8> local5 = ref many;
      Span<T3> componentSpan3 = existingArchetype.GetComponentSpan<T3>();
      ref Span<T3> local6 = ref componentSpan3;
      int start3 = entityCount;
      Span<T3> span3 = local6.Slice(start3, local6.Length - start3);
      local5.Span3 = span3;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8> local7 = ref many;
      Span<T4> componentSpan4 = existingArchetype.GetComponentSpan<T4>();
      ref Span<T4> local8 = ref componentSpan4;
      int start4 = entityCount;
      Span<T4> span4 = local8.Slice(start4, local8.Length - start4);
      local7.Span4 = span4;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8> local9 = ref many;
      Span<T5> componentSpan5 = existingArchetype.GetComponentSpan<T5>();
      ref Span<T5> local10 = ref componentSpan5;
      int start5 = entityCount;
      Span<T5> span5 = local10.Slice(start5, local10.Length - start5);
      local9.Span5 = span5;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8> local11 = ref many;
      Span<T6> componentSpan6 = existingArchetype.GetComponentSpan<T6>();
      ref Span<T6> local12 = ref componentSpan6;
      int start6 = entityCount;
      Span<T6> span6 = local12.Slice(start6, local12.Length - start6);
      local11.Span6 = span6;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8> local13 = ref many;
      Span<T7> componentSpan7 = existingArchetype.GetComponentSpan<T7>();
      ref Span<T7> local14 = ref componentSpan7;
      int start7 = entityCount;
      Span<T7> span7 = local14.Slice(start7, local14.Length - start7);
      local13.Span7 = span7;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8> local15 = ref many;
      Span<T8> componentSpan8 = existingArchetype.GetComponentSpan<T8>();
      ref Span<T8> local16 = ref componentSpan8;
      int start8 = entityCount;
      Span<T8> span8 = local16.Slice(start8, local16.Length - start8);
      local15.Span8 = span8;
      return many;
    }

    /// <summary>
    /// Creates an <see cref="T:Frent.Entity" /> with the given component(s)
    /// </summary>
    /// <returns>An <see cref="T:Frent.Entity" /> that can be used to acsess the component data</returns>
    [SkipLocalsInit]
    public Entity Create<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
      in T1 comp1,
      in T2 comp2,
      in T3 comp3,
      in T4 comp4,
      in T5 comp5,
      in T6 comp6,
      in T7 comp7,
      in T8 comp8,
      in T9 comp9)
    {
      Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9>.CreateNewOrGetExistingArchetype(this);
      
      EntityLocation entityLocation = new EntityLocation();
      Unsafe.SkipInit<int>(out int physicalIndex);
      ComponentStorageBase[] writeStorage;
      // ISSUE: variable of a reference type
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
      ref T1 local2 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9>.OfComponent<T1>.Index))[physicalIndex];
      local2 = comp1;
      ref T2 local3 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9>.OfComponent<T2>.Index))[physicalIndex];
      local3 = comp2;
      ref T3 local4 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T3>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9>.OfComponent<T3>.Index))[physicalIndex];
      local4 = comp3;
      ref T4 local5 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T4>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9>.OfComponent<T4>.Index))[physicalIndex];
      local5 = comp4;
      ref T5 local6 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T5>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9>.OfComponent<T5>.Index))[physicalIndex];
      local6 = comp5;
      ref T6 local7 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T6>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9>.OfComponent<T6>.Index))[physicalIndex];
      local7 = comp6;
      ref T7 local8 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T7>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9>.OfComponent<T7>.Index))[physicalIndex];
      local8 = comp7;
      ref T8 local9 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T8>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9>.OfComponent<T8>.Index))[physicalIndex];
      local9 = comp8;
      ref T9 local10 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T9>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9>.OfComponent<T9>.Index))[physicalIndex];
      local10 = comp9;
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
      ComponentDelegates<T4>.InitDelegate initer4 = Component<T4>.Initer;
      if (initer4 != null)
        initer4(entity, ref local5);
      ComponentDelegates<T5>.InitDelegate initer5 = Component<T5>.Initer;
      if (initer5 != null)
        initer5(entity, ref local6);
      ComponentDelegates<T6>.InitDelegate initer6 = Component<T6>.Initer;
      if (initer6 != null)
        initer6(entity, ref local7);
      ComponentDelegates<T7>.InitDelegate initer7 = Component<T7>.Initer;
      if (initer7 != null)
        initer7(entity, ref local8);
      ComponentDelegates<T8>.InitDelegate initer8 = Component<T8>.Initer;
      if (initer8 != null)
        initer8(entity, ref local9);
      ComponentDelegates<T9>.InitDelegate initer9 = Component<T9>.Initer;
      if (initer9 != null)
        initer9(entity, ref local10);
      this.EntityCreatedEvent.Invoke(entity);
      return entity;
    }

    /// <summary>Creates a large amount of entities quickly</summary>
    /// <param name="count">The number of entities to create</param>
    /// <returns>The entities created and their component spans</returns>
    public ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateMany<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
      int count)
    {
      if (count < 0)
        FrentExceptions.Throw_ArgumentOutOfRangeException("Must create at least 1 entity!");
      Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9>.CreateNewOrGetExistingArchetype(this);
      int entityCount = existingArchetype.EntityCount;
      this.EntityTable.EnsureCapacity(this.EntityCount + count);
      Span<EntityIdOnly> entityLocations = existingArchetype.CreateEntityLocations(count, this);
      if (this.EntityCreatedEvent.HasListeners)
      {
        Span<EntityIdOnly> span = entityLocations;
        for (int index = 0; index < span.Length; ++index)
          this.EntityCreatedEvent.Invoke(span[index].ToEntity(this));
      }
      ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> many = new ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>();
      many.Entities = new EntityEnumerator.EntityEnumerable(this, entityLocations);
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> local1 = ref many;
      Span<T1> componentSpan1 = existingArchetype.GetComponentSpan<T1>();
      ref Span<T1> local2 = ref componentSpan1;
      int start1 = entityCount;
      Span<T1> span1 = local2.Slice(start1, local2.Length - start1);
      local1.Span1 = span1;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> local3 = ref many;
      Span<T2> componentSpan2 = existingArchetype.GetComponentSpan<T2>();
      ref Span<T2> local4 = ref componentSpan2;
      int start2 = entityCount;
      Span<T2> span2 = local4.Slice(start2, local4.Length - start2);
      local3.Span2 = span2;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> local5 = ref many;
      Span<T3> componentSpan3 = existingArchetype.GetComponentSpan<T3>();
      ref Span<T3> local6 = ref componentSpan3;
      int start3 = entityCount;
      Span<T3> span3 = local6.Slice(start3, local6.Length - start3);
      local5.Span3 = span3;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> local7 = ref many;
      Span<T4> componentSpan4 = existingArchetype.GetComponentSpan<T4>();
      ref Span<T4> local8 = ref componentSpan4;
      int start4 = entityCount;
      Span<T4> span4 = local8.Slice(start4, local8.Length - start4);
      local7.Span4 = span4;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> local9 = ref many;
      Span<T5> componentSpan5 = existingArchetype.GetComponentSpan<T5>();
      ref Span<T5> local10 = ref componentSpan5;
      int start5 = entityCount;
      Span<T5> span5 = local10.Slice(start5, local10.Length - start5);
      local9.Span5 = span5;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> local11 = ref many;
      Span<T6> componentSpan6 = existingArchetype.GetComponentSpan<T6>();
      ref Span<T6> local12 = ref componentSpan6;
      int start6 = entityCount;
      Span<T6> span6 = local12.Slice(start6, local12.Length - start6);
      local11.Span6 = span6;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> local13 = ref many;
      Span<T7> componentSpan7 = existingArchetype.GetComponentSpan<T7>();
      ref Span<T7> local14 = ref componentSpan7;
      int start7 = entityCount;
      Span<T7> span7 = local14.Slice(start7, local14.Length - start7);
      local13.Span7 = span7;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> local15 = ref many;
      Span<T8> componentSpan8 = existingArchetype.GetComponentSpan<T8>();
      ref Span<T8> local16 = ref componentSpan8;
      int start8 = entityCount;
      Span<T8> span8 = local16.Slice(start8, local16.Length - start8);
      local15.Span8 = span8;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> local17 = ref many;
      Span<T9> componentSpan9 = existingArchetype.GetComponentSpan<T9>();
      ref Span<T9> local18 = ref componentSpan9;
      int start9 = entityCount;
      Span<T9> span9 = local18.Slice(start9, local18.Length - start9);
      local17.Span9 = span9;
      return many;
    }

    /// <summary>
    /// Creates an <see cref="T:Frent.Entity" /> with the given component(s)
    /// </summary>
    /// <returns>An <see cref="T:Frent.Entity" /> that can be used to acsess the component data</returns>
    [SkipLocalsInit]
    public Entity Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
      in T1 comp1,
      in T2 comp2,
      in T3 comp3,
      in T4 comp4,
      in T5 comp5,
      in T6 comp6,
      in T7 comp7,
      in T8 comp8,
      in T9 comp9,
      in T10 comp10)
    {
      Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.CreateNewOrGetExistingArchetype(this);
      
      EntityLocation entityLocation = new EntityLocation();
      Unsafe.SkipInit<int>(out int physicalIndex);
      ComponentStorageBase[] writeStorage;
      // ISSUE: variable of a reference type
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
      ref T1 local2 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.OfComponent<T1>.Index))[physicalIndex];
      local2 = comp1;
      ref T2 local3 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.OfComponent<T2>.Index))[physicalIndex];
      local3 = comp2;
      ref T3 local4 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T3>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.OfComponent<T3>.Index))[physicalIndex];
      local4 = comp3;
      ref T4 local5 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T4>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.OfComponent<T4>.Index))[physicalIndex];
      local5 = comp4;
      ref T5 local6 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T5>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.OfComponent<T5>.Index))[physicalIndex];
      local6 = comp5;
      ref T6 local7 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T6>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.OfComponent<T6>.Index))[physicalIndex];
      local7 = comp6;
      ref T7 local8 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T7>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.OfComponent<T7>.Index))[physicalIndex];
      local8 = comp7;
      ref T8 local9 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T8>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.OfComponent<T8>.Index))[physicalIndex];
      local9 = comp8;
      ref T9 local10 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T9>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.OfComponent<T9>.Index))[physicalIndex];
      local10 = comp9;
      ref T10 local11 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T10>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.OfComponent<T10>.Index))[physicalIndex];
      local11 = comp10;
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
      ComponentDelegates<T4>.InitDelegate initer4 = Component<T4>.Initer;
      if (initer4 != null)
        initer4(entity, ref local5);
      ComponentDelegates<T5>.InitDelegate initer5 = Component<T5>.Initer;
      if (initer5 != null)
        initer5(entity, ref local6);
      ComponentDelegates<T6>.InitDelegate initer6 = Component<T6>.Initer;
      if (initer6 != null)
        initer6(entity, ref local7);
      ComponentDelegates<T7>.InitDelegate initer7 = Component<T7>.Initer;
      if (initer7 != null)
        initer7(entity, ref local8);
      ComponentDelegates<T8>.InitDelegate initer8 = Component<T8>.Initer;
      if (initer8 != null)
        initer8(entity, ref local9);
      ComponentDelegates<T9>.InitDelegate initer9 = Component<T9>.Initer;
      if (initer9 != null)
        initer9(entity, ref local10);
      ComponentDelegates<T10>.InitDelegate initer10 = Component<T10>.Initer;
      if (initer10 != null)
        initer10(entity, ref local11);
      this.EntityCreatedEvent.Invoke(entity);
      return entity;
    }

    /// <summary>Creates a large amount of entities quickly</summary>
    /// <param name="count">The number of entities to create</param>
    /// <returns>The entities created and their component spans</returns>
    public ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> CreateMany<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
      int count)
    {
      if (count < 0)
        FrentExceptions.Throw_ArgumentOutOfRangeException("Must create at least 1 entity!");
      Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.CreateNewOrGetExistingArchetype(this);
      int entityCount = existingArchetype.EntityCount;
      this.EntityTable.EnsureCapacity(this.EntityCount + count);
      Span<EntityIdOnly> entityLocations = existingArchetype.CreateEntityLocations(count, this);
      if (this.EntityCreatedEvent.HasListeners)
      {
        Span<EntityIdOnly> span = entityLocations;
        for (int index = 0; index < span.Length; ++index)
          this.EntityCreatedEvent.Invoke(span[index].ToEntity(this));
      }
      ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> many = new ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>();
      many.Entities = new EntityEnumerator.EntityEnumerable(this, entityLocations);
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> local1 = ref many;
      Span<T1> componentSpan1 = existingArchetype.GetComponentSpan<T1>();
      ref Span<T1> local2 = ref componentSpan1;
      int start1 = entityCount;
      Span<T1> span1 = local2.Slice(start1, local2.Length - start1);
      local1.Span1 = span1;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> local3 = ref many;
      Span<T2> componentSpan2 = existingArchetype.GetComponentSpan<T2>();
      ref Span<T2> local4 = ref componentSpan2;
      int start2 = entityCount;
      Span<T2> span2 = local4.Slice(start2, local4.Length - start2);
      local3.Span2 = span2;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> local5 = ref many;
      Span<T3> componentSpan3 = existingArchetype.GetComponentSpan<T3>();
      ref Span<T3> local6 = ref componentSpan3;
      int start3 = entityCount;
      Span<T3> span3 = local6.Slice(start3, local6.Length - start3);
      local5.Span3 = span3;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> local7 = ref many;
      Span<T4> componentSpan4 = existingArchetype.GetComponentSpan<T4>();
      ref Span<T4> local8 = ref componentSpan4;
      int start4 = entityCount;
      Span<T4> span4 = local8.Slice(start4, local8.Length - start4);
      local7.Span4 = span4;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> local9 = ref many;
      Span<T5> componentSpan5 = existingArchetype.GetComponentSpan<T5>();
      ref Span<T5> local10 = ref componentSpan5;
      int start5 = entityCount;
      Span<T5> span5 = local10.Slice(start5, local10.Length - start5);
      local9.Span5 = span5;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> local11 = ref many;
      Span<T6> componentSpan6 = existingArchetype.GetComponentSpan<T6>();
      ref Span<T6> local12 = ref componentSpan6;
      int start6 = entityCount;
      Span<T6> span6 = local12.Slice(start6, local12.Length - start6);
      local11.Span6 = span6;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> local13 = ref many;
      Span<T7> componentSpan7 = existingArchetype.GetComponentSpan<T7>();
      ref Span<T7> local14 = ref componentSpan7;
      int start7 = entityCount;
      Span<T7> span7 = local14.Slice(start7, local14.Length - start7);
      local13.Span7 = span7;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> local15 = ref many;
      Span<T8> componentSpan8 = existingArchetype.GetComponentSpan<T8>();
      ref Span<T8> local16 = ref componentSpan8;
      int start8 = entityCount;
      Span<T8> span8 = local16.Slice(start8, local16.Length - start8);
      local15.Span8 = span8;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> local17 = ref many;
      Span<T9> componentSpan9 = existingArchetype.GetComponentSpan<T9>();
      ref Span<T9> local18 = ref componentSpan9;
      int start9 = entityCount;
      Span<T9> span9 = local18.Slice(start9, local18.Length - start9);
      local17.Span9 = span9;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> local19 = ref many;
      Span<T10> componentSpan10 = existingArchetype.GetComponentSpan<T10>();
      ref Span<T10> local20 = ref componentSpan10;
      int start10 = entityCount;
      Span<T10> span10 = local20.Slice(start10, local20.Length - start10);
      local19.Span10 = span10;
      return many;
    }

    /// <summary>
    /// Creates an <see cref="T:Frent.Entity" /> with the given component(s)
    /// </summary>
    /// <returns>An <see cref="T:Frent.Entity" /> that can be used to acsess the component data</returns>
    [SkipLocalsInit]
    public Entity Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
      in T1 comp1,
      in T2 comp2,
      in T3 comp3,
      in T4 comp4,
      in T5 comp5,
      in T6 comp6,
      in T7 comp7,
      in T8 comp8,
      in T9 comp9,
      in T10 comp10,
      in T11 comp11)
    {
      Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.CreateNewOrGetExistingArchetype(this);
      
      EntityLocation entityLocation = new EntityLocation();
      Unsafe.SkipInit<int>(out int physicalIndex);
      ComponentStorageBase[] writeStorage;
      // ISSUE: variable of a reference type
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
      ref T1 local2 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.OfComponent<T1>.Index))[physicalIndex];
      local2 = comp1;
      ref T2 local3 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.OfComponent<T2>.Index))[physicalIndex];
      local3 = comp2;
      ref T3 local4 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T3>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.OfComponent<T3>.Index))[physicalIndex];
      local4 = comp3;
      ref T4 local5 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T4>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.OfComponent<T4>.Index))[physicalIndex];
      local5 = comp4;
      ref T5 local6 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T5>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.OfComponent<T5>.Index))[physicalIndex];
      local6 = comp5;
      ref T6 local7 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T6>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.OfComponent<T6>.Index))[physicalIndex];
      local7 = comp6;
      ref T7 local8 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T7>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.OfComponent<T7>.Index))[physicalIndex];
      local8 = comp7;
      ref T8 local9 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T8>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.OfComponent<T8>.Index))[physicalIndex];
      local9 = comp8;
      ref T9 local10 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T9>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.OfComponent<T9>.Index))[physicalIndex];
      local10 = comp9;
      ref T10 local11 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T10>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.OfComponent<T10>.Index))[physicalIndex];
      local11 = comp10;
      ref T11 local12 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T11>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.OfComponent<T11>.Index))[physicalIndex];
      local12 = comp11;
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
      ComponentDelegates<T4>.InitDelegate initer4 = Component<T4>.Initer;
      if (initer4 != null)
        initer4(entity, ref local5);
      ComponentDelegates<T5>.InitDelegate initer5 = Component<T5>.Initer;
      if (initer5 != null)
        initer5(entity, ref local6);
      ComponentDelegates<T6>.InitDelegate initer6 = Component<T6>.Initer;
      if (initer6 != null)
        initer6(entity, ref local7);
      ComponentDelegates<T7>.InitDelegate initer7 = Component<T7>.Initer;
      if (initer7 != null)
        initer7(entity, ref local8);
      ComponentDelegates<T8>.InitDelegate initer8 = Component<T8>.Initer;
      if (initer8 != null)
        initer8(entity, ref local9);
      ComponentDelegates<T9>.InitDelegate initer9 = Component<T9>.Initer;
      if (initer9 != null)
        initer9(entity, ref local10);
      ComponentDelegates<T10>.InitDelegate initer10 = Component<T10>.Initer;
      if (initer10 != null)
        initer10(entity, ref local11);
      ComponentDelegates<T11>.InitDelegate initer11 = Component<T11>.Initer;
      if (initer11 != null)
        initer11(entity, ref local12);
      this.EntityCreatedEvent.Invoke(entity);
      return entity;
    }

    /// <summary>Creates a large amount of entities quickly</summary>
    /// <param name="count">The number of entities to create</param>
    /// <returns>The entities created and their component spans</returns>
    public ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> CreateMany<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
      int count)
    {
      if (count < 0)
        FrentExceptions.Throw_ArgumentOutOfRangeException("Must create at least 1 entity!");
      Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.CreateNewOrGetExistingArchetype(this);
      int entityCount = existingArchetype.EntityCount;
      this.EntityTable.EnsureCapacity(this.EntityCount + count);
      Span<EntityIdOnly> entityLocations = existingArchetype.CreateEntityLocations(count, this);
      if (this.EntityCreatedEvent.HasListeners)
      {
        Span<EntityIdOnly> span = entityLocations;
        for (int index = 0; index < span.Length; ++index)
          this.EntityCreatedEvent.Invoke(span[index].ToEntity(this));
      }
      ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> many = new ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>();
      many.Entities = new EntityEnumerator.EntityEnumerable(this, entityLocations);
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> local1 = ref many;
      Span<T1> componentSpan1 = existingArchetype.GetComponentSpan<T1>();
      ref Span<T1> local2 = ref componentSpan1;
      int start1 = entityCount;
      Span<T1> span1 = local2.Slice(start1, local2.Length - start1);
      local1.Span1 = span1;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> local3 = ref many;
      Span<T2> componentSpan2 = existingArchetype.GetComponentSpan<T2>();
      ref Span<T2> local4 = ref componentSpan2;
      int start2 = entityCount;
      Span<T2> span2 = local4.Slice(start2, local4.Length - start2);
      local3.Span2 = span2;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> local5 = ref many;
      Span<T3> componentSpan3 = existingArchetype.GetComponentSpan<T3>();
      ref Span<T3> local6 = ref componentSpan3;
      int start3 = entityCount;
      Span<T3> span3 = local6.Slice(start3, local6.Length - start3);
      local5.Span3 = span3;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> local7 = ref many;
      Span<T4> componentSpan4 = existingArchetype.GetComponentSpan<T4>();
      ref Span<T4> local8 = ref componentSpan4;
      int start4 = entityCount;
      Span<T4> span4 = local8.Slice(start4, local8.Length - start4);
      local7.Span4 = span4;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> local9 = ref many;
      Span<T5> componentSpan5 = existingArchetype.GetComponentSpan<T5>();
      ref Span<T5> local10 = ref componentSpan5;
      int start5 = entityCount;
      Span<T5> span5 = local10.Slice(start5, local10.Length - start5);
      local9.Span5 = span5;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> local11 = ref many;
      Span<T6> componentSpan6 = existingArchetype.GetComponentSpan<T6>();
      ref Span<T6> local12 = ref componentSpan6;
      int start6 = entityCount;
      Span<T6> span6 = local12.Slice(start6, local12.Length - start6);
      local11.Span6 = span6;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> local13 = ref many;
      Span<T7> componentSpan7 = existingArchetype.GetComponentSpan<T7>();
      ref Span<T7> local14 = ref componentSpan7;
      int start7 = entityCount;
      Span<T7> span7 = local14.Slice(start7, local14.Length - start7);
      local13.Span7 = span7;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> local15 = ref many;
      Span<T8> componentSpan8 = existingArchetype.GetComponentSpan<T8>();
      ref Span<T8> local16 = ref componentSpan8;
      int start8 = entityCount;
      Span<T8> span8 = local16.Slice(start8, local16.Length - start8);
      local15.Span8 = span8;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> local17 = ref many;
      Span<T9> componentSpan9 = existingArchetype.GetComponentSpan<T9>();
      ref Span<T9> local18 = ref componentSpan9;
      int start9 = entityCount;
      Span<T9> span9 = local18.Slice(start9, local18.Length - start9);
      local17.Span9 = span9;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> local19 = ref many;
      Span<T10> componentSpan10 = existingArchetype.GetComponentSpan<T10>();
      ref Span<T10> local20 = ref componentSpan10;
      int start10 = entityCount;
      Span<T10> span10 = local20.Slice(start10, local20.Length - start10);
      local19.Span10 = span10;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> local21 = ref many;
      Span<T11> componentSpan11 = existingArchetype.GetComponentSpan<T11>();
      ref Span<T11> local22 = ref componentSpan11;
      int start11 = entityCount;
      Span<T11> span11 = local22.Slice(start11, local22.Length - start11);
      local21.Span11 = span11;
      return many;
    }

    /// <summary>
    /// Creates an <see cref="T:Frent.Entity" /> with the given component(s)
    /// </summary>
    /// <returns>An <see cref="T:Frent.Entity" /> that can be used to acsess the component data</returns>
    [SkipLocalsInit]
    public Entity Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
      in T1 comp1,
      in T2 comp2,
      in T3 comp3,
      in T4 comp4,
      in T5 comp5,
      in T6 comp6,
      in T7 comp7,
      in T8 comp8,
      in T9 comp9,
      in T10 comp10,
      in T11 comp11,
      in T12 comp12)
    {
      Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.CreateNewOrGetExistingArchetype(this);
      
      EntityLocation entityLocation = new EntityLocation();
      Unsafe.SkipInit<int>(out int physicalIndex);
      ComponentStorageBase[] writeStorage;
      // ISSUE: variable of a reference type
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
      ref T1 local2 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.OfComponent<T1>.Index))[physicalIndex];
      local2 = comp1;
      ref T2 local3 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.OfComponent<T2>.Index))[physicalIndex];
      local3 = comp2;
      ref T3 local4 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T3>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.OfComponent<T3>.Index))[physicalIndex];
      local4 = comp3;
      ref T4 local5 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T4>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.OfComponent<T4>.Index))[physicalIndex];
      local5 = comp4;
      ref T5 local6 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T5>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.OfComponent<T5>.Index))[physicalIndex];
      local6 = comp5;
      ref T6 local7 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T6>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.OfComponent<T6>.Index))[physicalIndex];
      local7 = comp6;
      ref T7 local8 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T7>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.OfComponent<T7>.Index))[physicalIndex];
      local8 = comp7;
      ref T8 local9 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T8>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.OfComponent<T8>.Index))[physicalIndex];
      local9 = comp8;
      ref T9 local10 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T9>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.OfComponent<T9>.Index))[physicalIndex];
      local10 = comp9;
      ref T10 local11 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T10>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.OfComponent<T10>.Index))[physicalIndex];
      local11 = comp10;
      ref T11 local12 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T11>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.OfComponent<T11>.Index))[physicalIndex];
      local12 = comp11;
      ref T12 local13 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T12>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.OfComponent<T12>.Index))[physicalIndex];
      local13 = comp12;
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
      ComponentDelegates<T4>.InitDelegate initer4 = Component<T4>.Initer;
      if (initer4 != null)
        initer4(entity, ref local5);
      ComponentDelegates<T5>.InitDelegate initer5 = Component<T5>.Initer;
      if (initer5 != null)
        initer5(entity, ref local6);
      ComponentDelegates<T6>.InitDelegate initer6 = Component<T6>.Initer;
      if (initer6 != null)
        initer6(entity, ref local7);
      ComponentDelegates<T7>.InitDelegate initer7 = Component<T7>.Initer;
      if (initer7 != null)
        initer7(entity, ref local8);
      ComponentDelegates<T8>.InitDelegate initer8 = Component<T8>.Initer;
      if (initer8 != null)
        initer8(entity, ref local9);
      ComponentDelegates<T9>.InitDelegate initer9 = Component<T9>.Initer;
      if (initer9 != null)
        initer9(entity, ref local10);
      ComponentDelegates<T10>.InitDelegate initer10 = Component<T10>.Initer;
      if (initer10 != null)
        initer10(entity, ref local11);
      ComponentDelegates<T11>.InitDelegate initer11 = Component<T11>.Initer;
      if (initer11 != null)
        initer11(entity, ref local12);
      ComponentDelegates<T12>.InitDelegate initer12 = Component<T12>.Initer;
      if (initer12 != null)
        initer12(entity, ref local13);
      this.EntityCreatedEvent.Invoke(entity);
      return entity;
    }

    /// <summary>Creates a large amount of entities quickly</summary>
    /// <param name="count">The number of entities to create</param>
    /// <returns>The entities created and their component spans</returns>
    public ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> CreateMany<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
      int count)
    {
      if (count < 0)
        FrentExceptions.Throw_ArgumentOutOfRangeException("Must create at least 1 entity!");
      Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.CreateNewOrGetExistingArchetype(this);
      int entityCount = existingArchetype.EntityCount;
      this.EntityTable.EnsureCapacity(this.EntityCount + count);
      Span<EntityIdOnly> entityLocations = existingArchetype.CreateEntityLocations(count, this);
      if (this.EntityCreatedEvent.HasListeners)
      {
        Span<EntityIdOnly> span = entityLocations;
        for (int index = 0; index < span.Length; ++index)
          this.EntityCreatedEvent.Invoke(span[index].ToEntity(this));
      }
      ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> many = new ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>();
      many.Entities = new EntityEnumerator.EntityEnumerable(this, entityLocations);
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> local1 = ref many;
      Span<T1> componentSpan1 = existingArchetype.GetComponentSpan<T1>();
      ref Span<T1> local2 = ref componentSpan1;
      int start1 = entityCount;
      Span<T1> span1 = local2.Slice(start1, local2.Length - start1);
      local1.Span1 = span1;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> local3 = ref many;
      Span<T2> componentSpan2 = existingArchetype.GetComponentSpan<T2>();
      ref Span<T2> local4 = ref componentSpan2;
      int start2 = entityCount;
      Span<T2> span2 = local4.Slice(start2, local4.Length - start2);
      local3.Span2 = span2;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> local5 = ref many;
      Span<T3> componentSpan3 = existingArchetype.GetComponentSpan<T3>();
      ref Span<T3> local6 = ref componentSpan3;
      int start3 = entityCount;
      Span<T3> span3 = local6.Slice(start3, local6.Length - start3);
      local5.Span3 = span3;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> local7 = ref many;
      Span<T4> componentSpan4 = existingArchetype.GetComponentSpan<T4>();
      ref Span<T4> local8 = ref componentSpan4;
      int start4 = entityCount;
      Span<T4> span4 = local8.Slice(start4, local8.Length - start4);
      local7.Span4 = span4;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> local9 = ref many;
      Span<T5> componentSpan5 = existingArchetype.GetComponentSpan<T5>();
      ref Span<T5> local10 = ref componentSpan5;
      int start5 = entityCount;
      Span<T5> span5 = local10.Slice(start5, local10.Length - start5);
      local9.Span5 = span5;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> local11 = ref many;
      Span<T6> componentSpan6 = existingArchetype.GetComponentSpan<T6>();
      ref Span<T6> local12 = ref componentSpan6;
      int start6 = entityCount;
      Span<T6> span6 = local12.Slice(start6, local12.Length - start6);
      local11.Span6 = span6;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> local13 = ref many;
      Span<T7> componentSpan7 = existingArchetype.GetComponentSpan<T7>();
      ref Span<T7> local14 = ref componentSpan7;
      int start7 = entityCount;
      Span<T7> span7 = local14.Slice(start7, local14.Length - start7);
      local13.Span7 = span7;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> local15 = ref many;
      Span<T8> componentSpan8 = existingArchetype.GetComponentSpan<T8>();
      ref Span<T8> local16 = ref componentSpan8;
      int start8 = entityCount;
      Span<T8> span8 = local16.Slice(start8, local16.Length - start8);
      local15.Span8 = span8;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> local17 = ref many;
      Span<T9> componentSpan9 = existingArchetype.GetComponentSpan<T9>();
      ref Span<T9> local18 = ref componentSpan9;
      int start9 = entityCount;
      Span<T9> span9 = local18.Slice(start9, local18.Length - start9);
      local17.Span9 = span9;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> local19 = ref many;
      Span<T10> componentSpan10 = existingArchetype.GetComponentSpan<T10>();
      ref Span<T10> local20 = ref componentSpan10;
      int start10 = entityCount;
      Span<T10> span10 = local20.Slice(start10, local20.Length - start10);
      local19.Span10 = span10;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> local21 = ref many;
      Span<T11> componentSpan11 = existingArchetype.GetComponentSpan<T11>();
      ref Span<T11> local22 = ref componentSpan11;
      int start11 = entityCount;
      Span<T11> span11 = local22.Slice(start11, local22.Length - start11);
      local21.Span11 = span11;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> local23 = ref many;
      Span<T12> componentSpan12 = existingArchetype.GetComponentSpan<T12>();
      ref Span<T12> local24 = ref componentSpan12;
      int start12 = entityCount;
      Span<T12> span12 = local24.Slice(start12, local24.Length - start12);
      local23.Span12 = span12;
      return many;
    }

    /// <summary>
    /// Creates an <see cref="T:Frent.Entity" /> with the given component(s)
    /// </summary>
    /// <returns>An <see cref="T:Frent.Entity" /> that can be used to acsess the component data</returns>
    [SkipLocalsInit]
    public Entity Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
      in T1 comp1,
      in T2 comp2,
      in T3 comp3,
      in T4 comp4,
      in T5 comp5,
      in T6 comp6,
      in T7 comp7,
      in T8 comp8,
      in T9 comp9,
      in T10 comp10,
      in T11 comp11,
      in T12 comp12,
      in T13 comp13)
    {
      Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.CreateNewOrGetExistingArchetype(this);
      
      EntityLocation entityLocation = new EntityLocation();
      Unsafe.SkipInit<int>(out int physicalIndex);
      ComponentStorageBase[] writeStorage;
      // ISSUE: variable of a reference type
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
      ref T1 local2 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.OfComponent<T1>.Index))[physicalIndex];
      local2 = comp1;
      ref T2 local3 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.OfComponent<T2>.Index))[physicalIndex];
      local3 = comp2;
      ref T3 local4 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T3>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.OfComponent<T3>.Index))[physicalIndex];
      local4 = comp3;
      ref T4 local5 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T4>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.OfComponent<T4>.Index))[physicalIndex];
      local5 = comp4;
      ref T5 local6 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T5>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.OfComponent<T5>.Index))[physicalIndex];
      local6 = comp5;
      ref T6 local7 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T6>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.OfComponent<T6>.Index))[physicalIndex];
      local7 = comp6;
      ref T7 local8 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T7>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.OfComponent<T7>.Index))[physicalIndex];
      local8 = comp7;
      ref T8 local9 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T8>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.OfComponent<T8>.Index))[physicalIndex];
      local9 = comp8;
      ref T9 local10 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T9>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.OfComponent<T9>.Index))[physicalIndex];
      local10 = comp9;
      ref T10 local11 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T10>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.OfComponent<T10>.Index))[physicalIndex];
      local11 = comp10;
      ref T11 local12 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T11>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.OfComponent<T11>.Index))[physicalIndex];
      local12 = comp11;
      ref T12 local13 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T12>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.OfComponent<T12>.Index))[physicalIndex];
      local13 = comp12;
      ref T13 local14 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T13>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.OfComponent<T13>.Index))[physicalIndex];
      local14 = comp13;
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
      ComponentDelegates<T4>.InitDelegate initer4 = Component<T4>.Initer;
      if (initer4 != null)
        initer4(entity, ref local5);
      ComponentDelegates<T5>.InitDelegate initer5 = Component<T5>.Initer;
      if (initer5 != null)
        initer5(entity, ref local6);
      ComponentDelegates<T6>.InitDelegate initer6 = Component<T6>.Initer;
      if (initer6 != null)
        initer6(entity, ref local7);
      ComponentDelegates<T7>.InitDelegate initer7 = Component<T7>.Initer;
      if (initer7 != null)
        initer7(entity, ref local8);
      ComponentDelegates<T8>.InitDelegate initer8 = Component<T8>.Initer;
      if (initer8 != null)
        initer8(entity, ref local9);
      ComponentDelegates<T9>.InitDelegate initer9 = Component<T9>.Initer;
      if (initer9 != null)
        initer9(entity, ref local10);
      ComponentDelegates<T10>.InitDelegate initer10 = Component<T10>.Initer;
      if (initer10 != null)
        initer10(entity, ref local11);
      ComponentDelegates<T11>.InitDelegate initer11 = Component<T11>.Initer;
      if (initer11 != null)
        initer11(entity, ref local12);
      ComponentDelegates<T12>.InitDelegate initer12 = Component<T12>.Initer;
      if (initer12 != null)
        initer12(entity, ref local13);
      ComponentDelegates<T13>.InitDelegate initer13 = Component<T13>.Initer;
      if (initer13 != null)
        initer13(entity, ref local14);
      this.EntityCreatedEvent.Invoke(entity);
      return entity;
    }

    /// <summary>Creates a large amount of entities quickly</summary>
    /// <param name="count">The number of entities to create</param>
    /// <returns>The entities created and their component spans</returns>
    public ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> CreateMany<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
      int count)
    {
      if (count < 0)
        FrentExceptions.Throw_ArgumentOutOfRangeException("Must create at least 1 entity!");
      Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.CreateNewOrGetExistingArchetype(this);
      int entityCount = existingArchetype.EntityCount;
      this.EntityTable.EnsureCapacity(this.EntityCount + count);
      Span<EntityIdOnly> entityLocations = existingArchetype.CreateEntityLocations(count, this);
      if (this.EntityCreatedEvent.HasListeners)
      {
        Span<EntityIdOnly> span = entityLocations;
        for (int index = 0; index < span.Length; ++index)
          this.EntityCreatedEvent.Invoke(span[index].ToEntity(this));
      }
      ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> many = new ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>();
      many.Entities = new EntityEnumerator.EntityEnumerable(this, entityLocations);
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> local1 = ref many;
      Span<T1> componentSpan1 = existingArchetype.GetComponentSpan<T1>();
      ref Span<T1> local2 = ref componentSpan1;
      int start1 = entityCount;
      Span<T1> span1 = local2.Slice(start1, local2.Length - start1);
      local1.Span1 = span1;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> local3 = ref many;
      Span<T2> componentSpan2 = existingArchetype.GetComponentSpan<T2>();
      ref Span<T2> local4 = ref componentSpan2;
      int start2 = entityCount;
      Span<T2> span2 = local4.Slice(start2, local4.Length - start2);
      local3.Span2 = span2;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> local5 = ref many;
      Span<T3> componentSpan3 = existingArchetype.GetComponentSpan<T3>();
      ref Span<T3> local6 = ref componentSpan3;
      int start3 = entityCount;
      Span<T3> span3 = local6.Slice(start3, local6.Length - start3);
      local5.Span3 = span3;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> local7 = ref many;
      Span<T4> componentSpan4 = existingArchetype.GetComponentSpan<T4>();
      ref Span<T4> local8 = ref componentSpan4;
      int start4 = entityCount;
      Span<T4> span4 = local8.Slice(start4, local8.Length - start4);
      local7.Span4 = span4;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> local9 = ref many;
      Span<T5> componentSpan5 = existingArchetype.GetComponentSpan<T5>();
      ref Span<T5> local10 = ref componentSpan5;
      int start5 = entityCount;
      Span<T5> span5 = local10.Slice(start5, local10.Length - start5);
      local9.Span5 = span5;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> local11 = ref many;
      Span<T6> componentSpan6 = existingArchetype.GetComponentSpan<T6>();
      ref Span<T6> local12 = ref componentSpan6;
      int start6 = entityCount;
      Span<T6> span6 = local12.Slice(start6, local12.Length - start6);
      local11.Span6 = span6;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> local13 = ref many;
      Span<T7> componentSpan7 = existingArchetype.GetComponentSpan<T7>();
      ref Span<T7> local14 = ref componentSpan7;
      int start7 = entityCount;
      Span<T7> span7 = local14.Slice(start7, local14.Length - start7);
      local13.Span7 = span7;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> local15 = ref many;
      Span<T8> componentSpan8 = existingArchetype.GetComponentSpan<T8>();
      ref Span<T8> local16 = ref componentSpan8;
      int start8 = entityCount;
      Span<T8> span8 = local16.Slice(start8, local16.Length - start8);
      local15.Span8 = span8;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> local17 = ref many;
      Span<T9> componentSpan9 = existingArchetype.GetComponentSpan<T9>();
      ref Span<T9> local18 = ref componentSpan9;
      int start9 = entityCount;
      Span<T9> span9 = local18.Slice(start9, local18.Length - start9);
      local17.Span9 = span9;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> local19 = ref many;
      Span<T10> componentSpan10 = existingArchetype.GetComponentSpan<T10>();
      ref Span<T10> local20 = ref componentSpan10;
      int start10 = entityCount;
      Span<T10> span10 = local20.Slice(start10, local20.Length - start10);
      local19.Span10 = span10;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> local21 = ref many;
      Span<T11> componentSpan11 = existingArchetype.GetComponentSpan<T11>();
      ref Span<T11> local22 = ref componentSpan11;
      int start11 = entityCount;
      Span<T11> span11 = local22.Slice(start11, local22.Length - start11);
      local21.Span11 = span11;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> local23 = ref many;
      Span<T12> componentSpan12 = existingArchetype.GetComponentSpan<T12>();
      ref Span<T12> local24 = ref componentSpan12;
      int start12 = entityCount;
      Span<T12> span12 = local24.Slice(start12, local24.Length - start12);
      local23.Span12 = span12;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> local25 = ref many;
      Span<T13> componentSpan13 = existingArchetype.GetComponentSpan<T13>();
      ref Span<T13> local26 = ref componentSpan13;
      int start13 = entityCount;
      Span<T13> span13 = local26.Slice(start13, local26.Length - start13);
      local25.Span13 = span13;
      return many;
    }

    /// <summary>
    /// Creates an <see cref="T:Frent.Entity" /> with the given component(s)
    /// </summary>
    /// <returns>An <see cref="T:Frent.Entity" /> that can be used to acsess the component data</returns>
    [SkipLocalsInit]
    public Entity Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
      in T1 comp1,
      in T2 comp2,
      in T3 comp3,
      in T4 comp4,
      in T5 comp5,
      in T6 comp6,
      in T7 comp7,
      in T8 comp8,
      in T9 comp9,
      in T10 comp10,
      in T11 comp11,
      in T12 comp12,
      in T13 comp13,
      in T14 comp14)
    {
      Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.CreateNewOrGetExistingArchetype(this);
      
      EntityLocation entityLocation = new EntityLocation();
      Unsafe.SkipInit<int>(out int physicalIndex);
      ComponentStorageBase[] writeStorage;
      // ISSUE: variable of a reference type
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
      ref T1 local2 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T1>.Index))[physicalIndex];
      local2 = comp1;
      ref T2 local3 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T2>.Index))[physicalIndex];
      local3 = comp2;
      ref T3 local4 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T3>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T3>.Index))[physicalIndex];
      local4 = comp3;
      ref T4 local5 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T4>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T4>.Index))[physicalIndex];
      local5 = comp4;
      ref T5 local6 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T5>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T5>.Index))[physicalIndex];
      local6 = comp5;
      ref T6 local7 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T6>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T6>.Index))[physicalIndex];
      local7 = comp6;
      ref T7 local8 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T7>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T7>.Index))[physicalIndex];
      local8 = comp7;
      ref T8 local9 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T8>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T8>.Index))[physicalIndex];
      local9 = comp8;
      ref T9 local10 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T9>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T9>.Index))[physicalIndex];
      local10 = comp9;
      ref T10 local11 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T10>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T10>.Index))[physicalIndex];
      local11 = comp10;
      ref T11 local12 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T11>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T11>.Index))[physicalIndex];
      local12 = comp11;
      ref T12 local13 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T12>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T12>.Index))[physicalIndex];
      local13 = comp12;
      ref T13 local14 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T13>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T13>.Index))[physicalIndex];
      local14 = comp13;
      ref T14 local15 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T14>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T14>.Index))[physicalIndex];
      local15 = comp14;
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
      ComponentDelegates<T4>.InitDelegate initer4 = Component<T4>.Initer;
      if (initer4 != null)
        initer4(entity, ref local5);
      ComponentDelegates<T5>.InitDelegate initer5 = Component<T5>.Initer;
      if (initer5 != null)
        initer5(entity, ref local6);
      ComponentDelegates<T6>.InitDelegate initer6 = Component<T6>.Initer;
      if (initer6 != null)
        initer6(entity, ref local7);
      ComponentDelegates<T7>.InitDelegate initer7 = Component<T7>.Initer;
      if (initer7 != null)
        initer7(entity, ref local8);
      ComponentDelegates<T8>.InitDelegate initer8 = Component<T8>.Initer;
      if (initer8 != null)
        initer8(entity, ref local9);
      ComponentDelegates<T9>.InitDelegate initer9 = Component<T9>.Initer;
      if (initer9 != null)
        initer9(entity, ref local10);
      ComponentDelegates<T10>.InitDelegate initer10 = Component<T10>.Initer;
      if (initer10 != null)
        initer10(entity, ref local11);
      ComponentDelegates<T11>.InitDelegate initer11 = Component<T11>.Initer;
      if (initer11 != null)
        initer11(entity, ref local12);
      ComponentDelegates<T12>.InitDelegate initer12 = Component<T12>.Initer;
      if (initer12 != null)
        initer12(entity, ref local13);
      ComponentDelegates<T13>.InitDelegate initer13 = Component<T13>.Initer;
      if (initer13 != null)
        initer13(entity, ref local14);
      ComponentDelegates<T14>.InitDelegate initer14 = Component<T14>.Initer;
      if (initer14 != null)
        initer14(entity, ref local15);
      this.EntityCreatedEvent.Invoke(entity);
      return entity;
    }

    /// <summary>Creates a large amount of entities quickly</summary>
    /// <param name="count">The number of entities to create</param>
    /// <returns>The entities created and their component spans</returns>
    public ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> CreateMany<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
      int count)
    {
      if (count < 0)
        FrentExceptions.Throw_ArgumentOutOfRangeException("Must create at least 1 entity!");
      Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.CreateNewOrGetExistingArchetype(this);
      int entityCount = existingArchetype.EntityCount;
      this.EntityTable.EnsureCapacity(this.EntityCount + count);
      Span<EntityIdOnly> entityLocations = existingArchetype.CreateEntityLocations(count, this);
      if (this.EntityCreatedEvent.HasListeners)
      {
        Span<EntityIdOnly> span = entityLocations;
        for (int index = 0; index < span.Length; ++index)
          this.EntityCreatedEvent.Invoke(span[index].ToEntity(this));
      }
      ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> many = new ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>();
      many.Entities = new EntityEnumerator.EntityEnumerable(this, entityLocations);
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local1 = ref many;
      Span<T1> componentSpan1 = existingArchetype.GetComponentSpan<T1>();
      ref Span<T1> local2 = ref componentSpan1;
      int start1 = entityCount;
      Span<T1> span1 = local2.Slice(start1, local2.Length - start1);
      local1.Span1 = span1;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local3 = ref many;
      Span<T2> componentSpan2 = existingArchetype.GetComponentSpan<T2>();
      ref Span<T2> local4 = ref componentSpan2;
      int start2 = entityCount;
      Span<T2> span2 = local4.Slice(start2, local4.Length - start2);
      local3.Span2 = span2;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local5 = ref many;
      Span<T3> componentSpan3 = existingArchetype.GetComponentSpan<T3>();
      ref Span<T3> local6 = ref componentSpan3;
      int start3 = entityCount;
      Span<T3> span3 = local6.Slice(start3, local6.Length - start3);
      local5.Span3 = span3;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local7 = ref many;
      Span<T4> componentSpan4 = existingArchetype.GetComponentSpan<T4>();
      ref Span<T4> local8 = ref componentSpan4;
      int start4 = entityCount;
      Span<T4> span4 = local8.Slice(start4, local8.Length - start4);
      local7.Span4 = span4;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local9 = ref many;
      Span<T5> componentSpan5 = existingArchetype.GetComponentSpan<T5>();
      ref Span<T5> local10 = ref componentSpan5;
      int start5 = entityCount;
      Span<T5> span5 = local10.Slice(start5, local10.Length - start5);
      local9.Span5 = span5;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local11 = ref many;
      Span<T6> componentSpan6 = existingArchetype.GetComponentSpan<T6>();
      ref Span<T6> local12 = ref componentSpan6;
      int start6 = entityCount;
      Span<T6> span6 = local12.Slice(start6, local12.Length - start6);
      local11.Span6 = span6;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local13 = ref many;
      Span<T7> componentSpan7 = existingArchetype.GetComponentSpan<T7>();
      ref Span<T7> local14 = ref componentSpan7;
      int start7 = entityCount;
      Span<T7> span7 = local14.Slice(start7, local14.Length - start7);
      local13.Span7 = span7;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local15 = ref many;
      Span<T8> componentSpan8 = existingArchetype.GetComponentSpan<T8>();
      ref Span<T8> local16 = ref componentSpan8;
      int start8 = entityCount;
      Span<T8> span8 = local16.Slice(start8, local16.Length - start8);
      local15.Span8 = span8;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local17 = ref many;
      Span<T9> componentSpan9 = existingArchetype.GetComponentSpan<T9>();
      ref Span<T9> local18 = ref componentSpan9;
      int start9 = entityCount;
      Span<T9> span9 = local18.Slice(start9, local18.Length - start9);
      local17.Span9 = span9;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local19 = ref many;
      Span<T10> componentSpan10 = existingArchetype.GetComponentSpan<T10>();
      ref Span<T10> local20 = ref componentSpan10;
      int start10 = entityCount;
      Span<T10> span10 = local20.Slice(start10, local20.Length - start10);
      local19.Span10 = span10;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local21 = ref many;
      Span<T11> componentSpan11 = existingArchetype.GetComponentSpan<T11>();
      ref Span<T11> local22 = ref componentSpan11;
      int start11 = entityCount;
      Span<T11> span11 = local22.Slice(start11, local22.Length - start11);
      local21.Span11 = span11;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local23 = ref many;
      Span<T12> componentSpan12 = existingArchetype.GetComponentSpan<T12>();
      ref Span<T12> local24 = ref componentSpan12;
      int start12 = entityCount;
      Span<T12> span12 = local24.Slice(start12, local24.Length - start12);
      local23.Span12 = span12;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local25 = ref many;
      Span<T13> componentSpan13 = existingArchetype.GetComponentSpan<T13>();
      ref Span<T13> local26 = ref componentSpan13;
      int start13 = entityCount;
      Span<T13> span13 = local26.Slice(start13, local26.Length - start13);
      local25.Span13 = span13;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local27 = ref many;
      Span<T14> componentSpan14 = existingArchetype.GetComponentSpan<T14>();
      ref Span<T14> local28 = ref componentSpan14;
      int start14 = entityCount;
      Span<T14> span14 = local28.Slice(start14, local28.Length - start14);
      local27.Span14 = span14;
      return many;
    }

    /// <summary>
    /// Creates an <see cref="T:Frent.Entity" /> with the given component(s)
    /// </summary>
    /// <returns>An <see cref="T:Frent.Entity" /> that can be used to acsess the component data</returns>
    [SkipLocalsInit]
    public Entity Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
      in T1 comp1,
      in T2 comp2,
      in T3 comp3,
      in T4 comp4,
      in T5 comp5,
      in T6 comp6,
      in T7 comp7,
      in T8 comp8,
      in T9 comp9,
      in T10 comp10,
      in T11 comp11,
      in T12 comp12,
      in T13 comp13,
      in T14 comp14,
      in T15 comp15)
    {
      Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.CreateNewOrGetExistingArchetype(this);
      
      EntityLocation entityLocation = new EntityLocation();
      Unsafe.SkipInit<int>(out int physicalIndex);
      ComponentStorageBase[] writeStorage;
      // ISSUE: variable of a reference type
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
      ref T1 local2 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.OfComponent<T1>.Index))[physicalIndex];
      local2 = comp1;
      ref T2 local3 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.OfComponent<T2>.Index))[physicalIndex];
      local3 = comp2;
      ref T3 local4 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T3>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.OfComponent<T3>.Index))[physicalIndex];
      local4 = comp3;
      ref T4 local5 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T4>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.OfComponent<T4>.Index))[physicalIndex];
      local5 = comp4;
      ref T5 local6 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T5>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.OfComponent<T5>.Index))[physicalIndex];
      local6 = comp5;
      ref T6 local7 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T6>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.OfComponent<T6>.Index))[physicalIndex];
      local7 = comp6;
      ref T7 local8 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T7>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.OfComponent<T7>.Index))[physicalIndex];
      local8 = comp7;
      ref T8 local9 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T8>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.OfComponent<T8>.Index))[physicalIndex];
      local9 = comp8;
      ref T9 local10 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T9>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.OfComponent<T9>.Index))[physicalIndex];
      local10 = comp9;
      ref T10 local11 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T10>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.OfComponent<T10>.Index))[physicalIndex];
      local11 = comp10;
      ref T11 local12 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T11>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.OfComponent<T11>.Index))[physicalIndex];
      local12 = comp11;
      ref T12 local13 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T12>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.OfComponent<T12>.Index))[physicalIndex];
      local13 = comp12;
      ref T13 local14 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T13>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.OfComponent<T13>.Index))[physicalIndex];
      local14 = comp13;
      ref T14 local15 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T14>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.OfComponent<T14>.Index))[physicalIndex];
      local15 = comp14;
      ref T15 local16 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T15>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.OfComponent<T15>.Index))[physicalIndex];
      local16 = comp15;
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
      ComponentDelegates<T4>.InitDelegate initer4 = Component<T4>.Initer;
      if (initer4 != null)
        initer4(entity, ref local5);
      ComponentDelegates<T5>.InitDelegate initer5 = Component<T5>.Initer;
      if (initer5 != null)
        initer5(entity, ref local6);
      ComponentDelegates<T6>.InitDelegate initer6 = Component<T6>.Initer;
      if (initer6 != null)
        initer6(entity, ref local7);
      ComponentDelegates<T7>.InitDelegate initer7 = Component<T7>.Initer;
      if (initer7 != null)
        initer7(entity, ref local8);
      ComponentDelegates<T8>.InitDelegate initer8 = Component<T8>.Initer;
      if (initer8 != null)
        initer8(entity, ref local9);
      ComponentDelegates<T9>.InitDelegate initer9 = Component<T9>.Initer;
      if (initer9 != null)
        initer9(entity, ref local10);
      ComponentDelegates<T10>.InitDelegate initer10 = Component<T10>.Initer;
      if (initer10 != null)
        initer10(entity, ref local11);
      ComponentDelegates<T11>.InitDelegate initer11 = Component<T11>.Initer;
      if (initer11 != null)
        initer11(entity, ref local12);
      ComponentDelegates<T12>.InitDelegate initer12 = Component<T12>.Initer;
      if (initer12 != null)
        initer12(entity, ref local13);
      ComponentDelegates<T13>.InitDelegate initer13 = Component<T13>.Initer;
      if (initer13 != null)
        initer13(entity, ref local14);
      ComponentDelegates<T14>.InitDelegate initer14 = Component<T14>.Initer;
      if (initer14 != null)
        initer14(entity, ref local15);
      ComponentDelegates<T15>.InitDelegate initer15 = Component<T15>.Initer;
      if (initer15 != null)
        initer15(entity, ref local16);
      this.EntityCreatedEvent.Invoke(entity);
      return entity;
    }

    /// <summary>Creates a large amount of entities quickly</summary>
    /// <param name="count">The number of entities to create</param>
    /// <returns>The entities created and their component spans</returns>
    public ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> CreateMany<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
      int count)
    {
      if (count < 0)
        FrentExceptions.Throw_ArgumentOutOfRangeException("Must create at least 1 entity!");
      Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.CreateNewOrGetExistingArchetype(this);
      int entityCount = existingArchetype.EntityCount;
      this.EntityTable.EnsureCapacity(this.EntityCount + count);
      Span<EntityIdOnly> entityLocations = existingArchetype.CreateEntityLocations(count, this);
      if (this.EntityCreatedEvent.HasListeners)
      {
        Span<EntityIdOnly> span = entityLocations;
        for (int index = 0; index < span.Length; ++index)
          this.EntityCreatedEvent.Invoke(span[index].ToEntity(this));
      }
      ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> many = new ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>();
      many.Entities = new EntityEnumerator.EntityEnumerable(this, entityLocations);
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> local1 = ref many;
      Span<T1> componentSpan1 = existingArchetype.GetComponentSpan<T1>();
      ref Span<T1> local2 = ref componentSpan1;
      int start1 = entityCount;
      Span<T1> span1 = local2.Slice(start1, local2.Length - start1);
      local1.Span1 = span1;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> local3 = ref many;
      Span<T2> componentSpan2 = existingArchetype.GetComponentSpan<T2>();
      ref Span<T2> local4 = ref componentSpan2;
      int start2 = entityCount;
      Span<T2> span2 = local4.Slice(start2, local4.Length - start2);
      local3.Span2 = span2;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> local5 = ref many;
      Span<T3> componentSpan3 = existingArchetype.GetComponentSpan<T3>();
      ref Span<T3> local6 = ref componentSpan3;
      int start3 = entityCount;
      Span<T3> span3 = local6.Slice(start3, local6.Length - start3);
      local5.Span3 = span3;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> local7 = ref many;
      Span<T4> componentSpan4 = existingArchetype.GetComponentSpan<T4>();
      ref Span<T4> local8 = ref componentSpan4;
      int start4 = entityCount;
      Span<T4> span4 = local8.Slice(start4, local8.Length - start4);
      local7.Span4 = span4;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> local9 = ref many;
      Span<T5> componentSpan5 = existingArchetype.GetComponentSpan<T5>();
      ref Span<T5> local10 = ref componentSpan5;
      int start5 = entityCount;
      Span<T5> span5 = local10.Slice(start5, local10.Length - start5);
      local9.Span5 = span5;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> local11 = ref many;
      Span<T6> componentSpan6 = existingArchetype.GetComponentSpan<T6>();
      ref Span<T6> local12 = ref componentSpan6;
      int start6 = entityCount;
      Span<T6> span6 = local12.Slice(start6, local12.Length - start6);
      local11.Span6 = span6;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> local13 = ref many;
      Span<T7> componentSpan7 = existingArchetype.GetComponentSpan<T7>();
      ref Span<T7> local14 = ref componentSpan7;
      int start7 = entityCount;
      Span<T7> span7 = local14.Slice(start7, local14.Length - start7);
      local13.Span7 = span7;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> local15 = ref many;
      Span<T8> componentSpan8 = existingArchetype.GetComponentSpan<T8>();
      ref Span<T8> local16 = ref componentSpan8;
      int start8 = entityCount;
      Span<T8> span8 = local16.Slice(start8, local16.Length - start8);
      local15.Span8 = span8;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> local17 = ref many;
      Span<T9> componentSpan9 = existingArchetype.GetComponentSpan<T9>();
      ref Span<T9> local18 = ref componentSpan9;
      int start9 = entityCount;
      Span<T9> span9 = local18.Slice(start9, local18.Length - start9);
      local17.Span9 = span9;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> local19 = ref many;
      Span<T10> componentSpan10 = existingArchetype.GetComponentSpan<T10>();
      ref Span<T10> local20 = ref componentSpan10;
      int start10 = entityCount;
      Span<T10> span10 = local20.Slice(start10, local20.Length - start10);
      local19.Span10 = span10;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> local21 = ref many;
      Span<T11> componentSpan11 = existingArchetype.GetComponentSpan<T11>();
      ref Span<T11> local22 = ref componentSpan11;
      int start11 = entityCount;
      Span<T11> span11 = local22.Slice(start11, local22.Length - start11);
      local21.Span11 = span11;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> local23 = ref many;
      Span<T12> componentSpan12 = existingArchetype.GetComponentSpan<T12>();
      ref Span<T12> local24 = ref componentSpan12;
      int start12 = entityCount;
      Span<T12> span12 = local24.Slice(start12, local24.Length - start12);
      local23.Span12 = span12;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> local25 = ref many;
      Span<T13> componentSpan13 = existingArchetype.GetComponentSpan<T13>();
      ref Span<T13> local26 = ref componentSpan13;
      int start13 = entityCount;
      Span<T13> span13 = local26.Slice(start13, local26.Length - start13);
      local25.Span13 = span13;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> local27 = ref many;
      Span<T14> componentSpan14 = existingArchetype.GetComponentSpan<T14>();
      ref Span<T14> local28 = ref componentSpan14;
      int start14 = entityCount;
      Span<T14> span14 = local28.Slice(start14, local28.Length - start14);
      local27.Span14 = span14;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> local29 = ref many;
      Span<T15> componentSpan15 = existingArchetype.GetComponentSpan<T15>();
      ref Span<T15> local30 = ref componentSpan15;
      int start15 = entityCount;
      Span<T15> span15 = local30.Slice(start15, local30.Length - start15);
      local29.Span15 = span15;
      return many;
    }

    /// <summary>
    /// Creates an <see cref="T:Frent.Entity" /> with the given component(s)
    /// </summary>
    /// <returns>An <see cref="T:Frent.Entity" /> that can be used to acsess the component data</returns>
    [SkipLocalsInit]
    public Entity Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
      in T1 comp1,
      in T2 comp2,
      in T3 comp3,
      in T4 comp4,
      in T5 comp5,
      in T6 comp6,
      in T7 comp7,
      in T8 comp8,
      in T9 comp9,
      in T10 comp10,
      in T11 comp11,
      in T12 comp12,
      in T13 comp13,
      in T14 comp14,
      in T15 comp15,
      in T16 comp16)
    {
      Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.CreateNewOrGetExistingArchetype(this);
      
      EntityLocation entityLocation = new EntityLocation();
      Unsafe.SkipInit<int>(out int physicalIndex);
      ComponentStorageBase[] writeStorage;
      // ISSUE: variable of a reference type
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
      ref T1 local2 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T1>.Index))[physicalIndex];
      local2 = comp1;
      ref T2 local3 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T2>.Index))[physicalIndex];
      local3 = comp2;
      ref T3 local4 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T3>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T3>.Index))[physicalIndex];
      local4 = comp3;
      ref T4 local5 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T4>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T4>.Index))[physicalIndex];
      local5 = comp4;
      ref T5 local6 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T5>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T5>.Index))[physicalIndex];
      local6 = comp5;
      ref T6 local7 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T6>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T6>.Index))[physicalIndex];
      local7 = comp6;
      ref T7 local8 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T7>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T7>.Index))[physicalIndex];
      local8 = comp7;
      ref T8 local9 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T8>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T8>.Index))[physicalIndex];
      local9 = comp8;
      ref T9 local10 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T9>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T9>.Index))[physicalIndex];
      local10 = comp9;
      ref T10 local11 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T10>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T10>.Index))[physicalIndex];
      local11 = comp10;
      ref T11 local12 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T11>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T11>.Index))[physicalIndex];
      local12 = comp11;
      ref T12 local13 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T12>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T12>.Index))[physicalIndex];
      local13 = comp12;
      ref T13 local14 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T13>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T13>.Index))[physicalIndex];
      local14 = comp13;
      ref T14 local15 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T14>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T14>.Index))[physicalIndex];
      local15 = comp14;
      ref T15 local16 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T15>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T15>.Index))[physicalIndex];
      local16 = comp15;
      ref T16 local17 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T16>>((object) writeStorage.UnsafeArrayIndex<ComponentStorageBase>(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T16>.Index))[physicalIndex];
      local17 = comp16;
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
      ComponentDelegates<T4>.InitDelegate initer4 = Component<T4>.Initer;
      if (initer4 != null)
        initer4(entity, ref local5);
      ComponentDelegates<T5>.InitDelegate initer5 = Component<T5>.Initer;
      if (initer5 != null)
        initer5(entity, ref local6);
      ComponentDelegates<T6>.InitDelegate initer6 = Component<T6>.Initer;
      if (initer6 != null)
        initer6(entity, ref local7);
      ComponentDelegates<T7>.InitDelegate initer7 = Component<T7>.Initer;
      if (initer7 != null)
        initer7(entity, ref local8);
      ComponentDelegates<T8>.InitDelegate initer8 = Component<T8>.Initer;
      if (initer8 != null)
        initer8(entity, ref local9);
      ComponentDelegates<T9>.InitDelegate initer9 = Component<T9>.Initer;
      if (initer9 != null)
        initer9(entity, ref local10);
      ComponentDelegates<T10>.InitDelegate initer10 = Component<T10>.Initer;
      if (initer10 != null)
        initer10(entity, ref local11);
      ComponentDelegates<T11>.InitDelegate initer11 = Component<T11>.Initer;
      if (initer11 != null)
        initer11(entity, ref local12);
      ComponentDelegates<T12>.InitDelegate initer12 = Component<T12>.Initer;
      if (initer12 != null)
        initer12(entity, ref local13);
      ComponentDelegates<T13>.InitDelegate initer13 = Component<T13>.Initer;
      if (initer13 != null)
        initer13(entity, ref local14);
      ComponentDelegates<T14>.InitDelegate initer14 = Component<T14>.Initer;
      if (initer14 != null)
        initer14(entity, ref local15);
      ComponentDelegates<T15>.InitDelegate initer15 = Component<T15>.Initer;
      if (initer15 != null)
        initer15(entity, ref local16);
      ComponentDelegates<T16>.InitDelegate initer16 = Component<T16>.Initer;
      if (initer16 != null)
        initer16(entity, ref local17);
      this.EntityCreatedEvent.Invoke(entity);
      return entity;
    }

    /// <summary>Creates a large amount of entities quickly</summary>
    /// <param name="count">The number of entities to create</param>
    /// <returns>The entities created and their component spans</returns>
    public ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> CreateMany<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
      int count)
    {
      if (count < 0)
        FrentExceptions.Throw_ArgumentOutOfRangeException("Must create at least 1 entity!");
      Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.CreateNewOrGetExistingArchetype(this);
      int entityCount = existingArchetype.EntityCount;
      this.EntityTable.EnsureCapacity(this.EntityCount + count);
      Span<EntityIdOnly> entityLocations = existingArchetype.CreateEntityLocations(count, this);
      if (this.EntityCreatedEvent.HasListeners)
      {
        Span<EntityIdOnly> span = entityLocations;
        for (int index = 0; index < span.Length; ++index)
          this.EntityCreatedEvent.Invoke(span[index].ToEntity(this));
      }
      ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> many = new ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>();
      many.Entities = new EntityEnumerator.EntityEnumerable(this, entityLocations);
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> local1 = ref many;
      Span<T1> componentSpan1 = existingArchetype.GetComponentSpan<T1>();
      ref Span<T1> local2 = ref componentSpan1;
      int start1 = entityCount;
      Span<T1> span1 = local2.Slice(start1, local2.Length - start1);
      local1.Span1 = span1;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> local3 = ref many;
      Span<T2> componentSpan2 = existingArchetype.GetComponentSpan<T2>();
      ref Span<T2> local4 = ref componentSpan2;
      int start2 = entityCount;
      Span<T2> span2 = local4.Slice(start2, local4.Length - start2);
      local3.Span2 = span2;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> local5 = ref many;
      Span<T3> componentSpan3 = existingArchetype.GetComponentSpan<T3>();
      ref Span<T3> local6 = ref componentSpan3;
      int start3 = entityCount;
      Span<T3> span3 = local6.Slice(start3, local6.Length - start3);
      local5.Span3 = span3;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> local7 = ref many;
      Span<T4> componentSpan4 = existingArchetype.GetComponentSpan<T4>();
      ref Span<T4> local8 = ref componentSpan4;
      int start4 = entityCount;
      Span<T4> span4 = local8.Slice(start4, local8.Length - start4);
      local7.Span4 = span4;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> local9 = ref many;
      Span<T5> componentSpan5 = existingArchetype.GetComponentSpan<T5>();
      ref Span<T5> local10 = ref componentSpan5;
      int start5 = entityCount;
      Span<T5> span5 = local10.Slice(start5, local10.Length - start5);
      local9.Span5 = span5;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> local11 = ref many;
      Span<T6> componentSpan6 = existingArchetype.GetComponentSpan<T6>();
      ref Span<T6> local12 = ref componentSpan6;
      int start6 = entityCount;
      Span<T6> span6 = local12.Slice(start6, local12.Length - start6);
      local11.Span6 = span6;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> local13 = ref many;
      Span<T7> componentSpan7 = existingArchetype.GetComponentSpan<T7>();
      ref Span<T7> local14 = ref componentSpan7;
      int start7 = entityCount;
      Span<T7> span7 = local14.Slice(start7, local14.Length - start7);
      local13.Span7 = span7;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> local15 = ref many;
      Span<T8> componentSpan8 = existingArchetype.GetComponentSpan<T8>();
      ref Span<T8> local16 = ref componentSpan8;
      int start8 = entityCount;
      Span<T8> span8 = local16.Slice(start8, local16.Length - start8);
      local15.Span8 = span8;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> local17 = ref many;
      Span<T9> componentSpan9 = existingArchetype.GetComponentSpan<T9>();
      ref Span<T9> local18 = ref componentSpan9;
      int start9 = entityCount;
      Span<T9> span9 = local18.Slice(start9, local18.Length - start9);
      local17.Span9 = span9;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> local19 = ref many;
      Span<T10> componentSpan10 = existingArchetype.GetComponentSpan<T10>();
      ref Span<T10> local20 = ref componentSpan10;
      int start10 = entityCount;
      Span<T10> span10 = local20.Slice(start10, local20.Length - start10);
      local19.Span10 = span10;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> local21 = ref many;
      Span<T11> componentSpan11 = existingArchetype.GetComponentSpan<T11>();
      ref Span<T11> local22 = ref componentSpan11;
      int start11 = entityCount;
      Span<T11> span11 = local22.Slice(start11, local22.Length - start11);
      local21.Span11 = span11;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> local23 = ref many;
      Span<T12> componentSpan12 = existingArchetype.GetComponentSpan<T12>();
      ref Span<T12> local24 = ref componentSpan12;
      int start12 = entityCount;
      Span<T12> span12 = local24.Slice(start12, local24.Length - start12);
      local23.Span12 = span12;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> local25 = ref many;
      Span<T13> componentSpan13 = existingArchetype.GetComponentSpan<T13>();
      ref Span<T13> local26 = ref componentSpan13;
      int start13 = entityCount;
      Span<T13> span13 = local26.Slice(start13, local26.Length - start13);
      local25.Span13 = span13;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> local27 = ref many;
      Span<T14> componentSpan14 = existingArchetype.GetComponentSpan<T14>();
      ref Span<T14> local28 = ref componentSpan14;
      int start14 = entityCount;
      Span<T14> span14 = local28.Slice(start14, local28.Length - start14);
      local27.Span14 = span14;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> local29 = ref many;
      Span<T15> componentSpan15 = existingArchetype.GetComponentSpan<T15>();
      ref Span<T15> local30 = ref componentSpan15;
      int start15 = entityCount;
      Span<T15> span15 = local30.Slice(start15, local30.Length - start15);
      local29.Span15 = span15;
      ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> local31 = ref many;
      Span<T16> componentSpan16 = existingArchetype.GetComponentSpan<T16>();
      ref Span<T16> local32 = ref componentSpan16;
      int start16 = entityCount;
      Span<T16> span16 = local32.Slice(start16, local32.Length - start16);
      local31.Span16 = span16;
      return many;
    }
    }
}