// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentStorage.cs
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
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Core;
using Alis.Core.Ecs.Core.Events;
using Alis.Core.Ecs.Core.Memory;

namespace Alis.Core.Ecs.Updating
{
    /// <summary>
    ///     The component storage class
    /// </summary>
    /// <seealso cref="ComponentStorageBase" />
    internal abstract partial class ComponentStorage<TComponent> : ComponentStorageBase
    {
        /// <summary>
        ///     Gets the value of the component id
        /// </summary>
        internal override ComponentID ComponentID => Component<TComponent>.ID;

        //TODO: improve
        /// <summary>
        ///     Trims the index
        /// </summary>
        /// <param name="index">The index</param>
        internal override void Trim(int index) => Resize((int) BitOperations.RoundUpToPowerOf2((uint) index));

        //TODO: pool
        /// <summary>
        ///     Resizes the buffer using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        internal override void ResizeBuffer(int size) => Resize(size);

        //Note - no unsafe here
        /// <summary>
        ///     Sets the at using the specified component
        /// </summary>
        /// <param name="component">The component</param>
        /// <param name="index">The index</param>
        internal override void SetAt(object component, int index) => this[index] = (TComponent) component;

        /// <summary>
        ///     Gets the at using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The object</returns>
        internal override object GetAt(int index) => this[index]!;

        /// <summary>
        ///     Invokes the generic action with using the specified action
        /// </summary>
        /// <param name="action">The action</param>
        /// <param name="e">The </param>
        /// <param name="index">The index</param>
        internal override void InvokeGenericActionWith(GenericEvent action, Entity e, int index) => action?.Invoke(e, ref this[index]);

        /// <summary>
        ///     Invokes the generic action with using the specified action
        /// </summary>
        /// <param name="action">The action</param>
        /// <param name="index">The index</param>
        internal override void InvokeGenericActionWith(IGenericAction action, int index) => action?.Invoke(ref this[index]);

        /// <summary>
        ///     Pulls the component from and clear using the specified other runner
        /// </summary>
        /// <param name="otherRunner">The other runner</param>
        /// <param name="me">The me</param>
        /// <param name="other">The other</param>
        /// <param name="otherRemoveIndex">The other remove index</param>
        internal override void PullComponentFromAndClear(ComponentStorageBase otherRunner, int me, int other, int otherRemoveIndex)
        {
            ComponentStorage<TComponent> componentRunner = UnsafeExtensions.UnsafeCast<ComponentStorage<TComponent>>(otherRunner);

            // see comment in ComponentStorageBase.PullComponentFromAndClearTryDevirt
            ref TComponent item = ref componentRunner[other];
            this[me] = item;

            ref TComponent downItem = ref componentRunner[otherRemoveIndex];
            item = downItem;

            if (RuntimeHelpers.IsReferenceOrContainsReferences<TComponent>())
            {
                downItem = default(TComponent);
            }
        }

        /// <summary>
        ///     Pulls the component from using the specified storage
        /// </summary>
        /// <param name="storage">The storage</param>
        /// <param name="me">The me</param>
        /// <param name="other">The other</param>
        internal override void PullComponentFrom(IdTable storage, int me, int other)
        {
            ref TComponent item = ref ((IdTable<TComponent>) storage).Buffer[other];
            this[me] = item;

            if (RuntimeHelpers.IsReferenceOrContainsReferences<TComponent>())
            {
                item = default(TComponent);
            }
        }

        /// <summary>
        ///     Deletes the data
        /// </summary>
        /// <param name="data">The data</param>
        internal override void Delete(DeleteComponentData data)
        {
            ref TComponent from = ref this[data.FromIndex];
            Component<TComponent>.Destroyer?.Invoke(ref from);
            this[data.ToIndex] = from;


            if (RuntimeHelpers.IsReferenceOrContainsReferences<TComponent>())
            {
                from = default(TComponent);
            }
        }

        /// <summary>
        ///     Stores the component index
        /// </summary>
        /// <param name="componentIndex">The component index</param>
        /// <returns>The component handle</returns>
        internal override ComponentHandle Store(int componentIndex)
        {
            ref TComponent item = ref this[componentIndex];

            //we can't just copy to stack and run the destroyer on it
            //it is stored
            Component<TComponent>.Destroyer?.Invoke(ref item);

            Component<TComponent>.GeneralComponentStorage.Create(out int stackIndex) = item;
            return new ComponentHandle(stackIndex, Component<TComponent>.ID);
        }
    }
    
    /// <summary>
    ///     The component storage class
    /// </summary>
    /// <seealso cref="ComponentStorageBase" />
    internal abstract partial class ComponentStorage<TComponent>(int length) : ComponentStorageBase(length == 0 ? [] : new TComponent[length])
    {
        /// <summary>
        ///     The index
        /// </summary>
        public ref TComponent this[int index]
        {
            
            get => ref TypedBuffer.UnsafeArrayIndex(index);
        }

        /// <summary>
        ///     Gets the value of the typed buffer
        /// </summary>
        private ref TComponent[] TypedBuffer => ref Unsafe.As<Array, TComponent[]>(ref _buffer);

        /// <summary>
        ///     Resizes the size
        /// </summary>
        /// <param name="size">The size</param>
        protected void Resize(int size)
        {
            Array.Resize(ref TypedBuffer, size);
        }


#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && !NET6_0_OR_GREATER
        public Span<TComponent> AsSpanLength(int length) => TypedBuffer.AsSpan(0, length);
        public Span<TComponent> AsSpan() => TypedBuffer;
#else
        /// <summary>
        /// Converts the span length using the specified length
        /// </summary>
        /// <param name="length">The length</param>
        /// <returns>A span of t component</returns>
        public Span<TComponent> AsSpanLength(int length) => System.Runtime.InteropServices.MemoryMarshal.CreateSpan(ref System.Runtime.InteropServices.MemoryMarshal.GetArrayDataReference(TypedBuffer), length);

        /// <summary>
        /// Converts the span
        /// </summary>
        /// <returns>A span of t component</returns>
        public Span<TComponent> AsSpan() => System.Runtime.InteropServices.MemoryMarshal.CreateSpan(ref System.Runtime.InteropServices.MemoryMarshal.GetArrayDataReference(TypedBuffer), TypedBuffer.Length);
#endif

        /// <summary>
        ///     Gets the component storage data reference
        /// </summary>
        /// <returns>The ref component</returns>
        public ref TComponent GetComponentStorageDataReference() => ref MemoryMarshal.GetArrayDataReference(TypedBuffer);

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
        }
    }
}