// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Component.cs
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
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Updating;
using Alis.Core.Ecs.Updating.Runners;

namespace Alis.Core.Ecs.Kernel
{
    /// <summary>
    ///     Non-generic container for per-type component data, used to avoid static fields in generic types (S2743).
    /// </summary>
    internal sealed class ComponentSlot
    {
        /// <summary>
        ///     The component id.
        /// </summary>
        internal ComponentId Id;

        /// <summary>
        ///     Boxed <c>IComponentStorageBaseFactory{T}</c> instance.
        /// </summary>
        internal object RunnerInstance;

        /// <summary>
        ///     The per-type <c>IdTable</c> (base class reference).
        /// </summary>
        internal IdTable GeneralComponentStorage;

        /// <summary>
        ///     The init delegate (boxed to <c>Delegate</c>).
        /// </summary>
        internal Delegate Initer;

        /// <summary>
        ///     The destroy delegate (boxed to <c>Delegate</c>).
        /// </summary>
        internal Delegate Destroyer;

        /// <summary>
        ///     Whether the component type implements <c>IOnDestroy</c>.
        /// </summary>
        internal bool IsDestroyable;
    }

    /// <summary>
    ///     Non-generic registry mapping <c>RuntimeTypeHandle</c> to <c>ComponentSlot</c>.
    ///     Avoids static fields in generic types (S2743) while preserving O(1) per-type lookup.
    /// </summary>
    internal static class ComponentRegistry
    {
        /// <summary>
        ///     The underlying concurrent store.
        /// </summary>
        private static readonly ConcurrentDictionary<RuntimeTypeHandle, ComponentSlot> Store = new();

        /// <summary>
        ///     Gets the slot for <typeparamref name="T"/>, creating it if necessary.
        /// </summary>
        internal static ComponentSlot GetOrCreate<T>() =>
            Store.GetOrAdd(typeof(T).TypeHandle, _ => Component<T>.CreateSlot());

        /// <summary>
        ///     Clears all cached slots. Intended for test cleanup.
        /// </summary>
        internal static void Clear() => Store.Clear();
    }

    /// <summary>
    ///     Used to quickly get the component ID of a given type.
    ///     No static fields — data is held in the non-generic <see cref="ComponentRegistry"/>.
    /// </summary>
    /// <typeparam name="T">The type of component</typeparam>
    public static class Component<T>
    {
        /// <summary>
        ///     Gets the component id for <typeparamref name="T"/>.
        /// </summary>
        public static ComponentId Id => ComponentRegistry.GetOrCreate<T>().Id;

        /// <summary>
        ///     Gets the general component storage for <typeparamref name="T"/>.
        /// </summary>
        internal static IdTable<T> GeneralComponentStorage =>
            (IdTable<T>)ComponentRegistry.GetOrCreate<T>().GeneralComponentStorage!;

        /// <summary>
        ///     Gets the init delegate for <typeparamref name="T"/>.
        /// </summary>
        internal static ComponentDelegates<T>.InitDelegate Initer =>
            (ComponentDelegates<T>.InitDelegate)ComponentRegistry.GetOrCreate<T>().Initer!;

        /// <summary>
        ///     Gets the destroy delegate for <typeparamref name="T"/>.
        /// </summary>
        internal static ComponentDelegates<T>.DestroyDelegate Destroyer =>
            (ComponentDelegates<T>.DestroyDelegate)ComponentRegistry.GetOrCreate<T>().Destroyer!;

        /// <summary>
        ///     Gets whether <typeparamref name="T"/> implements <c>IOnDestroy</c>.
        /// </summary>
        internal static bool IsDestroyable => ComponentRegistry.GetOrCreate<T>().IsDestroyable;

        /// <summary>
        ///     Creates the slot for <typeparamref name="T"/>. Called once per type by <see cref="ComponentRegistry"/>.
        /// </summary>
        internal static ComponentSlot CreateSlot()
        {
            (ComponentId id, IdTable<T> stack, ComponentDelegates<T>.InitDelegate initer,
                ComponentDelegates<T>.DestroyDelegate destroyer) = Component.GetExistingOrSetupNewComponent<T>();

            object runnerInstance;
            if (GenerationServices.UserGeneratedTypeMap.TryGetValue(typeof(T),
                    out (IComponentStorageBaseFactory Factory, int UpdateOrder) type)
                && type.Factory is IComponentStorageBaseFactory<T> casted)
            {
                runnerInstance = casted;
            }
            else
            {
                NoneUpdateRunnerFactory<T> fac = new NoneUpdateRunnerFactory<T>();
                Component.NoneComponentRunnerTable[typeof(T)] = fac;
                runnerInstance = fac;
            }

            bool isDestroyable = typeof(T).IsValueType
                ? default(T) is IOnDestroy
                : typeof(IOnDestroy).IsAssignableFrom(typeof(T));

            return new ComponentSlot
            {
                Id = id,
                RunnerInstance = runnerInstance,
                GeneralComponentStorage = stack,
                Initer = initer,
                Destroyer = destroyer,
                IsDestroyable = isDestroyable
            };
        }

        /// <summary>
        ///     Use ComponentHandle.Create instead.
        /// </summary>
        public static ComponentHandle StoreComponent(in T component)
        {
            ComponentSlot slot = ComponentRegistry.GetOrCreate<T>();
            IdTable<T> storage = (IdTable<T>)slot.GeneralComponentStorage!;
            storage.Create(out int index) = component;
            return new ComponentHandle(index, slot.Id);
        }

        /// <summary>
        ///     Creates the instance using the specified cap
        /// </summary>
        /// <param name="cap">The cap</param>
        /// <returns>A component storage of t</returns>
        internal static ComponentStorage<T> CreateInstance(int cap)
        {
            object runner = ComponentRegistry.GetOrCreate<T>().RunnerInstance;
            return Unsafe.As<IComponentStorageBaseFactory<T>>(runner).CreateStronglyTyped(cap);
        }
    }

    /// <summary>
    ///     Class for registering components
    /// </summary>
    public static class Component
    {
        /// <summary>
        ///     The backing field for <see cref="ComponentTable"/>
        /// </summary>
        private static FastestStack<ComponentData> _componentTable = FastestStack<ComponentData>.Create(16);

        /// <summary>
        ///     The create
        /// </summary>
        internal static FastestStack<ComponentData> ComponentTable => _componentTable;

        /// <summary>
        ///     The none component runner table
        /// </summary>
        internal static readonly Dictionary<Type, IComponentStorageBaseFactory> NoneComponentRunnerTable = [];

        /// <summary>
        ///     The existing component ds
        /// </summary>
        private static readonly Dictionary<Type, ComponentId> _existingComponentIDs = [];

        /// <summary>
        ///     The next component id
        /// </summary>
        private static int _nextComponentId = -1;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Component" /> class
        /// </summary>
        static Component()
        {
            GetComponentId(typeof(void));
        }

        /// <summary>
        ///     Gets the component factory from type using the specified t
        /// </summary>
        /// <param name="t">The </param>
        /// <returns>The component storage base factory</returns>
        internal static IComponentStorageBaseFactory GetComponentFactoryFromType(Type t)
        {
            if (GenerationServices.UserGeneratedTypeMap.TryGetValue(t,
                    out (IComponentStorageBaseFactory Factory, int UpdateOrder) type))
            {
                return type.Factory;
            }

            if (NoneComponentRunnerTable.TryGetValue(t, out IComponentStorageBaseFactory t1))
            {
                return t1;
            }

            Throw_ComponentTypeNotInit(t);
            return null!;
        }

        /// <summary>
        ///     Register components with this method to be able to use them programmically. Note that components that implement an
        ///     IComponent interface do not need to be registered
        /// </summary>
        /// <typeparam name="T">The type of component to implement</typeparam>
        public static void RegisterComponent<T>()
        {
            if (!GenerationServices.UserGeneratedTypeMap.ContainsKey(typeof(T)))
            {
                NoneComponentRunnerTable[typeof(T)] = new NoneUpdateRunnerFactory<T>();
            }
        }

        /// <summary>
        ///     Gets the existing or setup new component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <exception cref="InvalidOperationException">Exceeded maximum unique component type count of 65535</exception>
        /// <returns>
        ///     A component id component id and id table of t stack and component delegates t init delegate initer and
        ///     component delegates t destroy delegate destroyer
        /// </returns>
        internal static (ComponentId ComponentID, IdTable<T> Stack, ComponentDelegates<T>.InitDelegate Initer,
            ComponentDelegates<T>.DestroyDelegate Destroyer) GetExistingOrSetupNewComponent<T>()
        {
            lock (GlobalWorldTables.BufferChangeLock)
            {
                Type type = typeof(T);
                if (_existingComponentIDs.TryGetValue(type, out ComponentId value))
                {
                    return (value, (IdTable<T>) ComponentTable[value.RawIndex].Storage,
                        (ComponentDelegates<T>.InitDelegate) ComponentTable[value.RawIndex].Initer,
                        (ComponentDelegates<T>.DestroyDelegate) ComponentTable[value.RawIndex].Destroyer);
                }

                int nextIdInt = ++_nextComponentId;

                if (nextIdInt == ushort.MaxValue)
                {
                    throw new InvalidOperationException("Exceeded maximum unique component type count of 65535");
                }

                ComponentId id = new ComponentId((ushort) nextIdInt);
                _existingComponentIDs[type] = id;

                GlobalWorldTables.GrowComponentTagTableIfNeeded(id.RawIndex);

                ComponentDelegates<T>.InitDelegate initDelegate =
                    (ComponentDelegates<T>.InitDelegate) (GenerationServices.TypeIniters.TryGetValue(type, out Delegate v)
                        ? v
                        : null);
                ComponentDelegates<T>.DestroyDelegate destroyDelegate =
                    (ComponentDelegates<T>.DestroyDelegate) (GenerationServices.TypeDestroyers.TryGetValue(type,
                        out Delegate v2)
                        ? v2
                        : null);

                IdTable<T> stack = new IdTable<T>();
                ComponentTable.Push(new ComponentData(type, stack,
                    GenerationServices.TypeIniters.TryGetValue(type, out Delegate _) ? initDelegate : null,
                    GenerationServices.TypeDestroyers.TryGetValue(type, out Delegate _) ? destroyDelegate : null));

                return (id, stack, initDelegate, destroyDelegate);
            }
        }

        /// <summary>
        ///     Gets the component ID of a type
        /// </summary>
        /// <param name="t">The type to get the component ID of</param>
        /// <returns>The component ID</returns>
        public static ComponentId GetComponentId(Type t)
        {
            lock (GlobalWorldTables.BufferChangeLock)
            {
                if (_existingComponentIDs.TryGetValue(t, out ComponentId value))
                {
                    return value;
                }

                int nextIdInt = ++_nextComponentId;

                if (nextIdInt == ushort.MaxValue)
                {
                    throw new InvalidOperationException("Exceeded maximum unique component type count of 65535");
                }

                ComponentId id = new ComponentId((ushort) nextIdInt);
                _existingComponentIDs[t] = id;

                GlobalWorldTables.GrowComponentTagTableIfNeeded(id.RawIndex);

                ComponentTable.Push(new ComponentData(t, GetComponentTable(t),
                    GenerationServices.TypeIniters.TryGetValue(t, out Delegate v) ? v : null,
                    GenerationServices.TypeDestroyers.TryGetValue(t, out Delegate d) ? d : null));

                return id;
            }
        }

        /// <summary>
        ///     Gets the component table using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The id table</returns>
        private static IdTable GetComponentTable(Type type)
        {
            if (NoneComponentRunnerTable.TryGetValue(type, out IComponentStorageBaseFactory fac))
            {
                return fac.CreateStack();
            }

            if (GenerationServices.UserGeneratedTypeMap.TryGetValue(type,
                    out (IComponentStorageBaseFactory Factory, int UpdateOrder) data))
            {
                return data.Factory.CreateStack();
            }

            if (type == typeof(void))
            {
                return null!;
            }

            Throw_ComponentTypeNotInit(type);
            return null!;
        }


        /// <summary>
        ///     Throws the component type not init using the specified t
        /// </summary>
        /// <param name="t">The </param>
        /// <exception cref="InvalidOperationException">
        ///     {t.FullName} is not initalized. (Did you initalize T with
        ///     Component.RegisterComponent&lt;T&gt;()?)
        /// </exception>
        /// <exception cref="InvalidOperationException">{t.FullName} is not initalized. (Is the source generator working?)</exception>
        private static void Throw_ComponentTypeNotInit(Type t)
        {
            if (typeof(IComponentBase).IsAssignableFrom(t))
            {
                throw new InvalidOperationException($"{t.FullName} is not initalized. (Is the source generator working?)");
            }

            throw new InvalidOperationException(
                $"{t.FullName} is not initalized. (Did you initalize T with Component.RegisterComponent<T>()?)");
        }

        /// <summary>
        ///     Resets the for tests
        /// </summary>
        internal static void ResetForTests()
        {
            lock (GlobalWorldTables.BufferChangeLock)
            {
                NoneComponentRunnerTable.Clear();
                _existingComponentIDs.Clear();
                _nextComponentId = -1;
                _componentTable = FastestStack<ComponentData>.Create(16);
                ComponentRegistry.Clear();
                GetComponentId(typeof(void));
            }
        }
    }
}