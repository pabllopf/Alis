using System;
using Frent.Collections;
using Frent.Core;
using Frent.Core.Events;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Frent.Updating.Runners;

/// <summary>
/// The component storage class
/// </summary>
/// <seealso cref="ComponentStorageBase"/>
internal abstract partial class ComponentStorage<TComponent> : ComponentStorageBase
{
    //TODO: improve
    /// <summary>
    /// Trims the index
    /// </summary>
    /// <param name="index">The index</param>
    internal override void Trim(int index) => Resize((int)BitOperations.RoundUpToPowerOf2((uint)index));
    //TODO: pool
    /// <summary>
    /// Resizes the buffer using the specified size
    /// </summary>
    /// <param name="size">The size</param>
    internal override void ResizeBuffer(int size) => Resize(size);
    //Note - no unsafe here
    /// <summary>
    /// Sets the at using the specified component
    /// </summary>
    /// <param name="component">The component</param>
    /// <param name="index">The index</param>
    internal override void SetAt(object component, int index) => this[index] = (TComponent)component;
    /// <summary>
    /// Gets the at using the specified index
    /// </summary>
    /// <param name="index">The index</param>
    /// <returns>The object</returns>
    internal override object GetAt(int index) => this[index]!;
    /// <summary>
    /// Invokes the generic action with using the specified action
    /// </summary>
    /// <param name="action">The action</param>
    /// <param name="e">The </param>
    /// <param name="index">The index</param>
    internal override void InvokeGenericActionWith(GenericEvent? action, Entity e, int index) => action?.Invoke(e, ref this[index]);
    /// <summary>
    /// Invokes the generic action with using the specified action
    /// </summary>
    /// <param name="action">The action</param>
    /// <param name="index">The index</param>
    internal override void InvokeGenericActionWith(IGenericAction action, int index) => action?.Invoke(ref this[index]);
    /// <summary>
    /// Gets the value of the component id
    /// </summary>
    internal override ComponentID ComponentID => Component<TComponent>.ID;
    /// <summary>
    /// Pulls the component from and clear using the specified other runner
    /// </summary>
    /// <param name="otherRunner">The other runner</param>
    /// <param name="me">The me</param>
    /// <param name="other">The other</param>
    /// <param name="otherRemoveIndex">The other remove index</param>
    internal override void PullComponentFromAndClear(ComponentStorageBase otherRunner, int me, int other, int otherRemoveIndex)
    {
        ComponentStorage<TComponent> componentRunner = UnsafeExtensions.UnsafeCast<ComponentStorage<TComponent>>(otherRunner);

        // see comment in ComponentStorageBase.PullComponentFromAndClearTryDevirt
        ref var item = ref componentRunner[other];
        this[me] = item;

        ref var downItem = ref componentRunner[otherRemoveIndex];
        item = downItem;

        if (RuntimeHelpers.IsReferenceOrContainsReferences<TComponent>())
        {
            downItem = default;
        }
    }
    /// <summary>
    /// Pulls the component from using the specified storage
    /// </summary>
    /// <param name="storage">The storage</param>
    /// <param name="me">The me</param>
    /// <param name="other">The other</param>
    internal override void PullComponentFrom(IDTable storage, int me, int other)
    {
        ref var item = ref ((IDTable<TComponent>)storage).Buffer[other];
        this[me] = item;

        if (RuntimeHelpers.IsReferenceOrContainsReferences<TComponent>())
            item = default;
    }

    /// <summary>
    /// Deletes the data
    /// </summary>
    /// <param name="data">The data</param>
    internal override void Delete(DeleteComponentData data)
    {
        ref var from = ref this[data.FromIndex];
        Component<TComponent>.Destroyer?.Invoke(ref from);
        this[data.ToIndex] = from;


        if (RuntimeHelpers.IsReferenceOrContainsReferences<TComponent>())
            from = default;
    }

    /// <summary>
    /// Stores the component index
    /// </summary>
    /// <param name="componentIndex">The component index</param>
    /// <returns>The component handle</returns>
    internal override ComponentHandle Store(int componentIndex)
    {
        ref var item = ref this[componentIndex];

        //we can't just copy to stack and run the destroyer on it
        //it is stored
        Component<TComponent>.Destroyer?.Invoke(ref item);

        Component<TComponent>.GeneralComponentStorage.Create(out var stackIndex) = item;
        return new ComponentHandle(stackIndex, Component<TComponent>.ID);
    }
}

#if MANAGED_COMPONENTS || TRUE
/// <summary>
#if MANAGED_COMPONENTS || TRUE
/// The component storage class
#if MANAGED_COMPONENTS || TRUE
/// </summary>
#if MANAGED_COMPONENTS || TRUE
/// <seealso cref="ComponentStorageBase"/>
#if MANAGED_COMPONENTS || TRUE
internal abstract partial class ComponentStorage<TComponent>(int length) : ComponentStorageBase(length == 0 ? [] : new TComponent[length])
{
    /// <summary>
    /// The index
    /// </summary>
    public ref TComponent this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref TypedBuffer.UnsafeArrayIndex(index);
        }
    }

    /// <summary>
    /// Gets the value of the typed buffer
    /// </summary>
    private ref TComponent[] TypedBuffer => ref Unsafe.As<Array, TComponent[]>(ref _buffer);

    /// <summary>
    /// Resizes the size
    /// </summary>
    /// <param name="size">The size</param>
    protected void Resize(int size)
    {
        Array.Resize(ref TypedBuffer, size);
    }

    
    /// <summary>
    /// Converts the span length using the specified length
    /// </summary>
    /// <param name="length">The length</param>
    /// <returns>A span of t component</returns>
    public Span<TComponent> AsSpanLength(int length) => TypedBuffer.AsSpan(0, length);
    /// <summary>
    /// Converts the span
    /// </summary>
    /// <returns>A span of t component</returns>
    public Span<TComponent> AsSpan() => TypedBuffer;


    /// <summary>
    /// Gets the component storage data reference
    /// </summary>
    /// <returns>The ref component</returns>
    public ref TComponent GetComponentStorageDataReference() => ref MemoryMarshal.GetArrayDataReference(TypedBuffer);

    /// <summary>
    /// Disposes this instance
    /// </summary>
    public void Dispose()
    {

    }
}
#else
internal unsafe abstract class ComponentStorage<TComponent> : IDisposable
{

    public ref TComponent this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            if (RuntimeHelpers.IsReferenceOrContainsReferences<TComponent>())
            {
                return ref _managed!.UnsafeArrayIndex(index);
            }

            return ref _nativeArray[index];
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ComponentStorage()
    {
        if (RuntimeHelpers.IsReferenceOrContainsReferences<TComponent>())
        {
            _managed = new TComponent[1];
        }
        else
        {
            _nativeArray = new(1);
        }
    }

    private TComponent[]? _managed;
    private NativeArray<TComponent> _nativeArray;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected void Resize(int size)
    {
        if (RuntimeHelpers.IsReferenceOrContainsReferences<TComponent>())
        {
            Array.Resize(ref _managed, size);
        }
        else
        {
            _nativeArray.Resize(size);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<TComponent> AsSpan() => RuntimeHelpers.IsReferenceOrContainsReferences<TComponent>() ?
        _managed.AsSpan() : _nativeArray.AsSpan();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<TComponent> AsSpan(int length) => RuntimeHelpers.IsReferenceOrContainsReferences<TComponent>() ?
        _managed.AsSpan(0, length) : _nativeArray.AsSpanLen(length);

    public void Dispose()
    {
        _nativeArray.Dispose();
    }
}
#endif