using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Kernel.Memory;

namespace Alis.Core.Ecs.Updating
{
    /// <summary>
    ///     The component storage class
    /// </summary>
    /// <seealso cref="ComponentStorageBase" />
    public abstract partial class ComponentStorage<TComponent> : ComponentStorageBase
    {
        /// <summary>
        ///     Gets the value of the component id
        /// </summary>
        internal override ComponentId ComponentId => Component<TComponent>.Id;


        /// <summary>
        ///     Trims the index
        /// </summary>
        /// <param name="index">The index</param>
        internal override void Trim(int index)
        {
            Resize((int)BitOperations.RoundUpToPowerOf2((uint)index));
        }


        /// <summary>
        ///     Resizes the buffer using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        internal override void ResizeBuffer(int size)
        {
            Resize(size);
        }

        //Note - no unsafe here
        /// <summary>
        ///     Sets the at using the specified component
        /// </summary>
        /// <param name="component">The component</param>
        /// <param name="index">The index</param>
        internal override void SetAt(object component, int index)
        {
            this[index] = (TComponent)component;
        }

        /// <summary>
        ///     Gets the at using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The object</returns>
        internal override object GetAt(int index)
        {
            return this[index]!;
        }

        /// <summary>
        ///     Invokes the generic action with using the specified action
        /// </summary>
        /// <param name="action">The action</param>
        /// <param name="e">The </param>
        /// <param name="index">The index</param>
        internal override void InvokeGenericActionWith(GenericEvent action, GameObject e, int index)
        {
            action?.Invoke(e, ref this[index]);
        }

        /// <summary>
        ///     Invokes the generic action with using the specified action
        /// </summary>
        /// <param name="action">The action</param>
        /// <param name="index">The index</param>
        internal override void InvokeGenericActionWith(IGenericAction action, int index)
        {
            action?.Invoke(ref this[index]);
        }

        /// <summary>
        ///     Pulls the component from and clear using the specified other runner
        /// </summary>
        /// <param name="otherRunner">The other runner</param>
        /// <param name="me">The me</param>
        /// <param name="other">The other</param>
        /// <param name="otherRemoveIndex">The other remove index</param>
        internal override void PullComponentFromAndClear(ComponentStorageBase otherRunner, int me, int other,
            int otherRemoveIndex)
        {
            ComponentStorage<TComponent> componentRunner =
                UnsafeExtensions.UnsafeCast<ComponentStorage<TComponent>>(otherRunner);

            // see comment in ComponentStorageBase.PullComponentFromAndClearTryDevirt
            ref TComponent item = ref componentRunner[other];
            this[me] = item;

            ref TComponent downItem = ref componentRunner[otherRemoveIndex];
            item = downItem;

            if (RuntimeHelpers.IsReferenceOrContainsReferences<TComponent>()) downItem = default;
        }

        /// <summary>
        ///     Pulls the component from using the specified storage
        /// </summary>
        /// <param name="storage">The storage</param>
        /// <param name="me">The me</param>
        /// <param name="other">The other</param>
        internal override void PullComponentFrom(IdTable storage, int me, int other)
        {
            ref TComponent item = ref ((IdTable<TComponent>)storage).Buffer[other];
            this[me] = item;

            if (RuntimeHelpers.IsReferenceOrContainsReferences<TComponent>())
                item = default;
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
                from = default;
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
            return new ComponentHandle(stackIndex, Component<TComponent>.Id);
        }
    }
    
    /// <summary>
    ///     The component storage class
    /// </summary>
    /// <seealso cref="ComponentStorageBase" />
    public abstract partial class ComponentStorage<TComponent>(int length)
        : ComponentStorageBase(length == 0 ? [] : new TComponent[length])
    {
        /// <summary>
        ///     The index
        /// </summary>
        public ref TComponent this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref TypedBuffer.UnsafeArrayIndex(index);
        }

        /// <summary>
        ///     Gets the value of the typed buffer
        /// </summary>
        private ref TComponent[] TypedBuffer => ref Unsafe.As<Array, TComponent[]>(ref Buffer);

        /// <summary>
        ///     Resizes the size
        /// </summary>
        /// <param name="size">The size</param>
        protected void Resize(int size)
        {
            Array.Resize(ref TypedBuffer, size);
        }


#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
        public Span<TComponent> AsSpanLength(int length)
        {
            return TypedBuffer.AsSpan(0, length);
        }

        public Span<TComponent> AsSpan()
        {
            return TypedBuffer;
        }
        
          /// <summary>
          ///     Obtiene la referencia de datos de almacenamiento del componente
          /// </summary>
          /// <returns>La referencia al componente</returns>
          public ref TComponent GetComponentStorageDataReference()
          {
              return ref TypedBuffer[0];
          }
#else
    /// <summary>
    /// Converts the span length using the specified length
    /// </summary>
    /// <param name="length">The length</param>
    /// <returns>A span of t component</returns>
    public Span<TComponent> AsSpanLength(int length) => MemoryMarshal.CreateSpan(ref MemoryMarshal.GetArrayDataReference(TypedBuffer), length);

    /// <summary>
    /// Converts the span
    /// </summary>
    /// <returns>A span of t component</returns>
    public Span<TComponent> AsSpan() => MemoryMarshal.CreateSpan(ref MemoryMarshal.GetArrayDataReference(TypedBuffer), TypedBuffer.Length);
        
/// <summary>
        ///     Gets the component storage data reference
        /// </summary>
        /// <returns>The ref component</returns>
        public ref TComponent GetComponentStorageDataReference()
        {
            return ref MemoryMarshal.GetArrayDataReference(TypedBuffer);
        }
#endif

     

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
        }
    }
}