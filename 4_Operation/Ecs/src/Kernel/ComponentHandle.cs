using System;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel.Events;
using HashCode = Alis.Core.Aspect.Math.HashCode;

namespace Alis.Core.Ecs.Kernel
{
    /// <summary>
    ///     A handle to a component of any type. Useful to avoid boxing.
    /// </summary>
    /// <remarks>Must be disposed. The handle must also not be used afterwards.</remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    
    public readonly struct ComponentHandle : IEquatable<ComponentHandle>, IDisposable
    {
        /// <summary>
        ///     Gets the value of the debugger display string
        /// </summary>
        internal string DebuggerDisplayString => RetrieveBoxed()?.ToString() ?? "null";

        /// <summary>
        ///     The index
        /// </summary>
        private readonly int _index;

        /// <summary>
        ///     The component type
        /// </summary>
        private readonly ComponentId _componentType;


        /// <summary>
        ///     Initializes a new instance of the <see cref="ComponentHandle" /> class
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="componentId">The component id</param>
        internal ComponentHandle(int index, ComponentId componentId)
        {
            _index = index;
            _componentType = componentId;
        }

        /// <summary>
        ///     Creates a new <see cref="ComponentHandle" /> from a component.
        /// </summary>
        /// <typeparam name="T">The type of component to store.</typeparam>
        /// <param name="comp">The component to store.</param>
        /// <returns>A <see cref="ComponentHandle" /> instance that can be used to retrieve <paramref name="comp" />.</returns>
        public static ComponentHandle Create<T>(in T comp)
        {
            Component<T>.GeneralComponentStorage.Create(out int index) = comp;
            return new ComponentHandle(index, Component<T>.Id);
        }

        /// <summary>
        ///     Creates a new <see cref="ComponentHandle" /> from a potentially boxed component.
        /// </summary>
        /// <param name="typeAs">The type to store the component as.</param>
        /// <param name="object">The potentially boxed component to store.</param>
        /// <exception cref="InvalidCastException"><paramref name="object" /> is not of <paramref name="typeAs.Type" /></exception>
        /// <returns>A <see cref="ComponentHandle" /> instance that can be used to retrieve <paramref name="object" />.</returns>
        public static ComponentHandle CreateFromBoxed(ComponentId typeAs, object @object)
        {
            int index = Component.ComponentTable[typeAs.RawIndex].Storage.CreateBoxed(@object);
            return new ComponentHandle(index, typeAs);
        }

        /// <summary>
        ///     Creates a new <see cref="ComponentHandle" /> from a potentially boxed component.
        /// </summary>
        /// <param name="object">The potentially boxed component to store.</param>
        /// <returns>A <see cref="ComponentHandle" /> instance that can be used to retrieve <paramref name="object" />.</returns>
        public static ComponentHandle CreateFromBoxed(object @object)
        {
            return CreateFromBoxed(Component.GetComponentId(@object.GetType()), @object);
        }

        /// <summary>
        ///     Gets the value of this component strongly typed.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the component. <see cref="Component{T}.Id" /> should be equal to
        ///     <see cref="ComponentId" />
        /// </typeparam>
        /// <returns>The component value.</returns>
        public T Retrieve<T>()
        {
            if (_componentType != Component<T>.Id)
                throw new InvalidOperationException("Wrong component handle type!");
            return Component<T>.GeneralComponentStorage.Take(_index);
        }

        /// <summary>
        ///     Gets the value of the component represented bu this <see cref="ComponentHandle" />, boxing if needed.
        /// </summary>
        /// <returns>The component value.</returns>
        public object RetrieveBoxed()
        {
            return Component.ComponentTable[_componentType.RawIndex].Storage.TakeBoxed(_index);
        }

        /// <summary>
        ///     Invokes the component event and consume using the specified gameObject
        /// </summary>
        /// <param name="gameObject">The gameObject</param>
        /// <param name="e">The event</param>
        internal void InvokeComponentEventAndConsume(GameObject gameObject, GenericEvent e)
        {
            Component.ComponentTable[_componentType.RawIndex].Storage.InvokeEventWithAndConsume(e, gameObject, _index);
        }

        /// <summary>
        ///     Frees the memory associated with this component handle and marks it for reuse.
        /// </summary>
        /// <remarks>
        ///     It is very easy to leak memory by improperly disposing of <see cref="ComponentHandle" /> instances. The handle
        ///     does not check for double disposes.
        /// </remarks>
        public void Dispose()
        {
            Component.ComponentTable[_componentType.RawIndex].Storage.Consume(_index);
        }

        /// <summary>
        ///     Checks if a <see cref="ComponentHandle" /> is equal to this handle and so points to the same component.
        /// </summary>
        /// <param name="other">The <see cref="ComponentHandle" /> to compare to.</param>
        /// <returns><see langword="true" /> when they are equal, <see langword="false" /> otherwise.</returns>
        public bool Equals(ComponentHandle other)
        {
            return other.ComponentId == ComponentId && other.Index == Index;
        }

        /// <summary>
        ///     Checks if an object is equal to this component handle and points to the same component.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <returns><see langword="true" /> when they are equal, <see langword="false" /> otherwise.</returns>
        public override bool Equals(object obj)
        {
            return obj is ComponentHandle handle && Equals(handle);
        }

        /// <summary>
        ///     Checks if two component handles point to the same component.
        /// </summary>
        /// <param name="left">The first component handle.</param>
        /// <param name="right">The second component handle.</param>
        /// <returns><see langword="true" /> when they are equal, <see langword="false" /> otherwise.</returns>
        public static bool operator ==(ComponentHandle left, ComponentHandle right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///     Checks if two component handles do not point to the same component.
        /// </summary>
        /// <param name="left">The first component handle.</param>
        /// <param name="right">The second component handle.</param>
        /// <returns><see langword="true" /> when they are not equal, <see langword="false" /> otherwise.</returns>
        public static bool operator !=(ComponentHandle left, ComponentHandle right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        ///     The type of component represented by this <see cref="ComponentHandle" />.
        /// </summary>
        public Type Type => _componentType.Type;

        /// <summary>
        ///     The <see cref="Kernel.ComponentId" /> of the component represented by this <see cref="ComponentHandle" />.
        /// </summary>
        public ComponentId ComponentId => _componentType;

        /// <summary>
        ///     The hashcode.
        /// </summary>
        /// <returns>The hashcode -_-.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(_componentType, _index);
        }

        /// <summary>
        ///     Gets the value of the index
        /// </summary>
        internal int Index => _index;

        /// <summary>
        ///     Gets the value of the parent table
        /// </summary>
        internal IdTable ParentTable => Component.ComponentTable[_componentType.RawIndex].Storage;
    }
}