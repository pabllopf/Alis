using System;
using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetype;
using Alis.Core.Ecs.Kernel.Events;

namespace Alis.Core.Ecs.Updating
{
    /// <summary>
    ///     The component storage base class
    /// </summary>
    public abstract class ComponentStorageBase(Array initalBuffer)
    {
        /// <summary>
        ///     The inital buffer
        /// </summary>
        public Array Buffer = initalBuffer;

        /// <summary>
        ///     Gets the value of the component id
        /// </summary>
        internal abstract ComponentId ComponentId { get; }

        /// <summary>
        ///     Runs the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="b">The </param>
        internal abstract void Run(Scene scene, Archetype b);

        /// <summary>
        ///     Runs the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="b">The </param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        internal abstract void Run(Scene scene, Archetype b, int start, int length);
        
        /// <summary>
        ///     Deletes the delete component data
        /// </summary>
        /// <param name="deleteComponentData">The delete component data</param>
        internal abstract void Delete(DeleteComponentData deleteComponentData);

        /// <summary>
        ///     Trims the chunk index
        /// </summary>
        /// <param name="chunkIndex">The chunk index</param>
        internal abstract void Trim(int chunkIndex);

        /// <summary>
        ///     Resizes the buffer using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        internal abstract void ResizeBuffer(int size);

        /// <summary>
        ///     Pulls the component from and clear using the specified other runner
        /// </summary>
        /// <param name="otherRunner">The other runner</param>
        /// <param name="me">The me</param>
        /// <param name="other">The other</param>
        /// <param name="otherRemove">The other remove</param>
        internal abstract void PullComponentFromAndClear(ComponentStorageBase otherRunner, int me, int other,
            int otherRemove);

        /// <summary>
        ///     Pulls the component from using the specified storage
        /// </summary>
        /// <param name="storage">The storage</param>
        /// <param name="me">The me</param>
        /// <param name="other">The other</param>
        internal abstract void PullComponentFrom(IdTable storage, int me, int other);

        /// <summary>
        ///     Invokes the generic action with using the specified action
        /// </summary>
        /// <param name="action">The action</param>
        /// <param name="gameObject">The gameObject</param>
        /// <param name="index">The index</param>
        internal abstract void InvokeGenericActionWith(GenericEvent action, GameObject gameObject, int index);

        /// <summary>
        ///     Invokes the generic action with using the specified action
        /// </summary>
        /// <param name="action">The action</param>
        /// <param name="index">The index</param>
        internal abstract void InvokeGenericActionWith(IGenericAction action, int index);

        /// <summary>
        ///     Stores the index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The component handle</returns>
        internal abstract ComponentHandle Store(int index);

        /// <summary>
        ///     Sets the at using the specified component
        /// </summary>
        /// <param name="component">The component</param>
        /// <param name="index">The index</param>
        internal abstract void SetAt(object component, int index);

        /// <summary>
        ///     Gets the at using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The object</returns>
        internal abstract object GetAt(int index);


        /// <summary>
        ///     Implementation should mirror
        ///     <see cref="ComponentStorage{T}.PullComponentFromAndClear(ComponentStorageBase, int, int, int)" />
        /// </summary>
        internal void PullComponentFromAndClearTryDevirt(ComponentStorageBase otherRunner, int me, int other,
            int otherRemove)
        {
            PullComponentFromAndClear(otherRunner, me, other, otherRemove);
        }

        /// <summary>
        ///     Gets the component size
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The size</returns>
        internal static int GetComponentSize<T>()
        {
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
                return -1;
            int size = Unsafe.SizeOf<T>();

            if ((size & (size - 1)) != 0)
                //is not power of two
                return -1;

            if (size > 16 || size < 2)
                //we have block sizes 2, 4, 8, 16
                return -1;

            return size;
        }
    }
}