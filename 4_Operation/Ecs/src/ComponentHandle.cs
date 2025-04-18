// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentHandle.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Events;
using HashCode = Alis.Core.Aspect.Math.Util.HashCode;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The component handle
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1), SkipLocalsInit]
    public readonly struct ComponentHandle : IEquatable<ComponentHandle>, IDisposable
    {
        /// <summary>
        ///     The index
        /// </summary>
        private readonly int _index;

        /// <summary>
        ///     The component type
        /// </summary>
        private readonly ComponentID _componentType;


        /// <summary>
        ///     Initializes a new instance of the <see cref="ComponentHandle" /> class
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="componentID">The component id</param>
        internal ComponentHandle(int index, ComponentID componentID)
        {
            _index = index;
            _componentType = componentID;
        }

        /// <summary>
        ///     Creates the comp
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="comp">The comp</param>
        /// <returns>The component handle</returns>
        public static ComponentHandle Create<T>(in T comp) => Component<T>.StoreComponent(comp);

        /// <summary>
        ///     Creates the from boxed using the specified type as
        /// </summary>
        /// <param name="typeAs">The type as</param>
        /// <param name="object">The object</param>
        /// <returns>The component handle</returns>
        public static ComponentHandle CreateFromBoxed(ComponentID typeAs, object @object)
        {
            int index = Component.ComponentTable[typeAs.RawIndex].Storage.CreateBoxed(@object);
            return new ComponentHandle(index, typeAs);
        }

        /// <summary>
        ///     Creates the from boxed using the specified object
        /// </summary>
        /// <param name="object">The object</param>
        /// <returns>The component handle</returns>
        public static ComponentHandle CreateFromBoxed(object @object) => CreateFromBoxed(Component.GetComponentID(@object.GetType()), @object);

        /// <summary>
        ///     Gets the value of this component strongly typed.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the component. <see cref="Component{T}.ID" /> should be equal to
        ///     <see cref="ComponentID" />
        /// </typeparam>
        /// <returns>The component value.</returns>
        public T Retrieve<T>()
        {
            if (_componentType != Component<T>.ID)
            {
                throw new InvalidOperationException("Wrong component handle type!");
            }

            return Component<T>.GeneralComponentStorage.Take(_index);
        }

        /// <summary>
        ///     Gets the value of the component represented bu this <see cref="ComponentHandle" />, boxing if needed.
        /// </summary>
        /// <returns>The component value.</returns>
        public object RetrieveBoxed() => Component.ComponentTable[_componentType.RawIndex].Storage.TakeBoxed(_index);

        /// <summary>
        ///     Invokes the component event and consume using the specified entity
        /// </summary>
        /// <param name="gameObject">The entity</param>
        /// <param name="event">The event</param>
        internal void InvokeComponentEventAndConsume(GameObject gameObject, GenericEvent @event)
        {
            Component.ComponentTable[_componentType.RawIndex].Storage.InvokeEventWithAndConsume(@event, gameObject, _index);
        }

        /// <summary>
        ///     Frees the memory associated with this component handle and marks it for reuse.
        /// </summary>
        /// <remarks>
        ///     It is very easy to leak memory by improperly disposing of <see cref="ComponentHandle" /> instances. The handle
        ///     does not check for double disposes.
        /// </remarks>
        public void Dispose() => Component.ComponentTable[_componentType.RawIndex].Storage.Consume(_index);

        /// <summary>
        ///     Checks if a <see cref="ComponentHandle" /> is equal to this handle and so points to the same component.
        /// </summary>
        /// <param name="other">The <see cref="ComponentHandle" /> to compare to.</param>
        /// <returns><see langword="true" /> when they are equal, <see langword="false" /> otherwise.</returns>
        public bool Equals(ComponentHandle other) => (other.ComponentID == ComponentID) && (other.Index == Index);

        /// <summary>
        ///     Checks if an object is equal to this component handle and points to the same component.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <returns><see langword="true" /> when they are equal, <see langword="false" /> otherwise.</returns>
        public override bool Equals(object obj) => obj is ComponentHandle handle && Equals(handle);

        /// <summary>
        ///     Checks if two component handles point to the same component.
        /// </summary>
        /// <param name="left">The first component handle.</param>
        /// <param name="right">The second component handle.</param>
        /// <returns><see langword="true" /> when they are equal, <see langword="false" /> otherwise.</returns>
        public static bool operator ==(ComponentHandle left, ComponentHandle right) => left.Equals(right);

        /// <summary>
        ///     Checks if two component handles do not point to the same component.
        /// </summary>
        /// <param name="left">The first component handle.</param>
        /// <param name="right">The second component handle.</param>
        /// <returns><see langword="true" /> when they are not equal, <see langword="false" /> otherwise.</returns>
        public static bool operator !=(ComponentHandle left, ComponentHandle right) => !left.Equals(right);

        /// <summary>
        ///     The type of component represented by this <see cref="ComponentHandle" />
        /// </summary>
        public Type Type => _componentType.Type;

        /// <summary>
        ///     The <see cref="Ecs.ComponentID" /> of the component represented by this <see cref="ComponentHandle" />
        /// </summary>
        public ComponentID ComponentID => _componentType;

        /// <summary>
        ///     The hashcode.
        /// </summary>
        /// <returns>The hashcode -_-.</returns>
        public override int GetHashCode() => HashCode.Combine(_componentType, _index);

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