using System;
using System.Collections.Generic;
using Frent.Collections;
using Frent.Components;
using Frent.Core.Structures;
using Frent.Updating;
using Frent.Updating.Runners;
using System.Diagnostics.CodeAnalysis;

namespace Frent.Core
{
    /// <summary>
    /// Used to quickly get the component ID of a given type
    /// </summary>
    /// <typeparam name="T">The type of component</typeparam>
    public static class Component<T>
    {
        /// <summary>
        /// The component ID for <typeparamref name="T"/>
        /// </summary>
        public static ComponentID ID => _id;

        /// <summary>
        /// The id
        /// </summary>
        private static readonly ComponentID _id;
        /// <summary>
        /// The runner instance
        /// </summary>
        private static readonly IComponentStorageBaseFactory<T> RunnerInstance;
        /// <summary>
        /// The general component storage
        /// </summary>
        internal static readonly IDTable<T> GeneralComponentStorage;
        /// <summary>
        /// The initer
        /// </summary>
        internal static readonly ComponentDelegates<T>.InitDelegate? Initer;
        /// <summary>
        /// The destroyer
        /// </summary>
        internal static readonly ComponentDelegates<T>.DestroyDelegate? Destroyer;

        /// <summary>
        /// The 
        /// </summary>
        internal static readonly bool IsDestroyable = typeof(T).IsValueType ? default(T) is IDestroyable : typeof(IDestroyable).IsAssignableFrom(typeof(T));

        /// <summary>
        /// Stores the component using the specified component
        /// </summary>
        /// <param name="component">The component</param>
        /// <returns>The component handle</returns>
        public static ComponentHandle StoreComponent(in T component)
        {
            GeneralComponentStorage.Create(out int index) = component;
            return new ComponentHandle(index, _id);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Component{T}"/> class
        /// </summary>
        /// <exception cref="InvalidOperationException">{typeof(T).FullName} is not initalized correctly. (Is the source generator working?)</exception>
        static Component()
        {
            (_id, GeneralComponentStorage, Initer, Destroyer) = Component.GetExistingOrSetupNewComponent<T>();

            if (GenerationServices.UserGeneratedTypeMap.TryGetValue(typeof(T), out (IComponentStorageBaseFactory Factory, int UpdateOrder) type))
            {
                if (type.Factory is IComponentStorageBaseFactory<T> casted)
                {
                    RunnerInstance = casted;
                    return;
                }

                throw new InvalidOperationException($"{typeof(T).FullName} is not initalized correctly. (Is the source generator working?)");
            }

            NoneUpdateRunnerFactory<T>? fac = new NoneUpdateRunnerFactory<T>();
            Component.NoneComponentRunnerTable[typeof(T)] = fac;
            RunnerInstance = fac;
        }

        /// <summary>
        /// Creates the instance using the specified cap
        /// </summary>
        /// <param name="cap">The cap</param>
        /// <returns>A component storage of t</returns>
        internal static ComponentStorage<T> CreateInstance(int cap) => RunnerInstance.CreateStronglyTyped(cap);
    }

    /// <summary>
    /// Used only in source generation
    /// </summary>
    public static class ComponentDelegates<T>
    {
        /// <summary>
        /// Used only in source generation
        /// </summary>
        public delegate void InitDelegate(Entity entity, ref T component);
        /// <summary>
        /// Used only in source generation
        /// </summary>
        public delegate void DestroyDelegate(ref T component);
    }

    /// <summary>
    /// Class for registering components
    /// </summary>
    public static class Component
    {
        /// <summary>
        /// The create
        /// </summary>
        internal static FastStack<ComponentData> ComponentTable = FastStack<ComponentData>.Create(16);

        /// <summary>
        /// The none component runner table
        /// </summary>
        internal static Dictionary<Type, IComponentStorageBaseFactory> NoneComponentRunnerTable = [];

        /// <summary>
        /// The existing component ds
        /// </summary>
        private static Dictionary<Type, ComponentID> ExistingComponentIDs = [];

        /// <summary>
        /// The next component id
        /// </summary>
        private static int NextComponentID = -1;

        /// <summary>
        /// Gets the component factory from type using the specified t
        /// </summary>
        /// <param name="t">The </param>
        /// <returns>The component storage base factory</returns>
        internal static IComponentStorageBaseFactory GetComponentFactoryFromType(Type t)
        {
            if (GenerationServices.UserGeneratedTypeMap.TryGetValue(t, out (IComponentStorageBaseFactory Factory, int UpdateOrder) type))
            {
                return type.Factory;
            }
            if (NoneComponentRunnerTable.TryGetValue(t, out IComponentStorageBaseFactory? t1))
            {
                return t1;
            }

            Throw_ComponentTypeNotInit(t);
            return null!;
        }

        /// <summary>
        /// Register components with this method to be able to use them programmically. Note that components that implement an IComponent interface do not need to be registered
        /// </summary>
        /// <typeparam name="T">The type of component to implement</typeparam>
        public static void RegisterComponent<T>()
        {
            if (!GenerationServices.UserGeneratedTypeMap.ContainsKey(typeof(T)))
                NoneComponentRunnerTable[typeof(T)] = new NoneUpdateRunnerFactory<T>();
        }

        /// <summary>
        /// Gets the existing or setup new component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <exception cref="InvalidOperationException">Exceeded maximum unique component type count of 65535</exception>
        /// <returns>A component id component id and id table of t stack and component delegates t init delegate initer and component delegates t destroy delegate destroyer</returns>
        internal static (ComponentID ComponentID, IDTable<T> Stack, ComponentDelegates<T>.InitDelegate? Initer, ComponentDelegates<T>.DestroyDelegate? Destroyer) GetExistingOrSetupNewComponent<T>()
        {
            lock (GlobalWorldTables.BufferChangeLock)
            {
                Type? type = typeof(T);
                if (ExistingComponentIDs.TryGetValue(type, out ComponentID value))
                {
                    return (value, (IDTable<T>)ComponentTable[value.RawIndex].Storage, (ComponentDelegates<T>.InitDelegate?)ComponentTable[value.RawIndex].Initer, (ComponentDelegates<T>.DestroyDelegate?)ComponentTable[value.RawIndex].Destroyer);
                }

                int nextIDInt = ++NextComponentID;

                if (nextIDInt == ushort.MaxValue)
                    throw new InvalidOperationException($"Exceeded maximum unique component type count of 65535");

                ComponentID id = new ComponentID((ushort)nextIDInt);
                ExistingComponentIDs[type] = id;

                GlobalWorldTables.GrowComponentTagTableIfNeeded(id.RawIndex);

                ComponentDelegates<T>.InitDelegate? initDelegate = (ComponentDelegates<T>.InitDelegate?)(GenerationServices.TypeIniters.TryGetValue(type, out Delegate? v) ? v : null);
                ComponentDelegates<T>.DestroyDelegate? destroyDelegate = (ComponentDelegates<T>.DestroyDelegate?)(GenerationServices.TypeDestroyers.TryGetValue(type, out Delegate? v2) ? v2 : null);

                IDTable<T> stack = new IDTable<T>();
                ComponentTable.Push(new ComponentData(type, stack,
                    GenerationServices.TypeIniters.TryGetValue(type, out Delegate? v1) ? initDelegate : null,
                    GenerationServices.TypeDestroyers.TryGetValue(type, out Delegate? d) ? destroyDelegate : null));

                return (id, stack, initDelegate, destroyDelegate);
            }
        }

        /// <summary>
        /// Gets the component ID of a type
        /// </summary>
        /// <param name="t">The type to get the component ID of</param>
        /// <returns>The component ID</returns>
        public static ComponentID GetComponentID(Type t)
        {
            lock (GlobalWorldTables.BufferChangeLock)
            {
                if (ExistingComponentIDs.TryGetValue(t, out ComponentID value))
                {
                    return value;
                }

                int nextIDInt = ++NextComponentID;

                if (nextIDInt == ushort.MaxValue)
                    throw new InvalidOperationException($"Exceeded maximum unique component type count of 65535");

                ComponentID id = new ComponentID((ushort)nextIDInt);
                ExistingComponentIDs[t] = id;

                GlobalWorldTables.GrowComponentTagTableIfNeeded(id.RawIndex);

                ComponentTable.Push(new ComponentData(t, GetComponentTable(t),
                    GenerationServices.TypeIniters.TryGetValue(t, out Delegate? v) ? v : null,
                    GenerationServices.TypeDestroyers.TryGetValue(t, out Delegate? d) ? d : null));

                return id;
            }
        }

        /// <summary>
        /// Gets the component table using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The id table</returns>
        private static IDTable GetComponentTable(Type type)
        {
            if (NoneComponentRunnerTable.TryGetValue(type, out IComponentStorageBaseFactory? fac))
                return (IDTable)fac.CreateStack();
            if (GenerationServices.UserGeneratedTypeMap.TryGetValue(type, out (IComponentStorageBaseFactory Factory, int UpdateOrder) data))
                return (IDTable)data.Factory.CreateStack();
            if (type == typeof(void))
                return null!;
            Throw_ComponentTypeNotInit(type);
            return null!;
        }

    
        /// <summary>
        /// Throws the component type not init using the specified t
        /// </summary>
        /// <param name="t">The </param>
        /// <exception cref="InvalidOperationException">{t.FullName} is not initalized. (Did you initalize T with Component.RegisterComponent&lt;T&gt;()?)</exception>
        /// <exception cref="InvalidOperationException">{t.FullName} is not initalized. (Is the source generator working?)</exception>
        private static void Throw_ComponentTypeNotInit(Type t)
        {
            if (typeof(IComponentBase).IsAssignableFrom(t))
            {
                throw new InvalidOperationException($"{t.FullName} is not initalized. (Is the source generator working?)");
            }
            else
            {
                throw new InvalidOperationException($"{t.FullName} is not initalized. (Did you initalize T with Component.RegisterComponent<T>()?)");
            }
        }

        //initalize default(ComponentID) to point to void
        /// <summary>
        /// Initializes a new instance of the <see cref="Component"/> class
        /// </summary>
        static Component() => GetComponentID(typeof(void));
    }
}