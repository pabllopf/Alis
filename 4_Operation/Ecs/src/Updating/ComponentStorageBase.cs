// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentStorageBase.cs
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
using System.Threading;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Core;
using Alis.Core.Ecs.Core.Archetype;
using Alis.Core.Ecs.Core.Events;


namespace Alis.Core.Ecs.Updating
{
    /// <summary>
    ///     The component storage base class
    /// </summary>
    internal abstract class ComponentStorageBase(Array initalBuffer)
    {
        /// <summary>
        ///     The inital buffer
        /// </summary>
        protected Array _buffer = initalBuffer;

        /// <summary>
        ///     Gets the value of the buffer
        /// </summary>
        public Array Buffer => _buffer;

        /// <summary>
        ///     Gets the value of the component id
        /// </summary>
        internal abstract ComponentID ComponentID { get; }

        /// <summary>
        ///     Runs the world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="b">The </param>
        internal abstract void Run(World world, Archetype b);

        /// <summary>
        ///     Multithreadeds the run using the specified countdown
        /// </summary>
        /// <param name="countdown">The countdown</param>
        /// <param name="world">The world</param>
        /// <param name="b">The </param>
        internal abstract void MultithreadedRun(CountdownEvent countdown, World world, Archetype b);

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
        internal abstract void PullComponentFromAndClear(ComponentStorageBase otherRunner, int me, int other, int otherRemove);

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
        /// <param name="entity">The entity</param>
        /// <param name="index">The index</param>
        internal abstract void InvokeGenericActionWith(GenericEvent action, Entity entity, int index);

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
        internal void PullComponentFromAndClearTryDevirt(ComponentStorageBase otherRunner, int me, int other, int otherRemove)
        {
            //if (Toggle.EnableDevirt && ElementSize != -1 &&
            //        Versioning.MemoryMarshalNonGenericGetArrayDataReferenceSupported)
            //{
            //    //benchmarked to be slower
            //    //TODO: speed up devirtualized impl?
            //
            //    Debug.Assert(GetType() == otherRunner.GetType());
            //
            //    ref byte meRef = ref MemoryMarshal.GetArrayDataReference(Buffer);
            //    ref byte fromRef = ref MemoryMarshal.GetArrayDataReference(otherRunner.Buffer);
            //
            //    nint nsize = ElementSize;
            //    
            //    ref byte item = ref Unsafe.Add(ref fromRef, other * nsize);
            //    ref byte down = ref Unsafe.Add(ref fromRef, otherRemove * nsize);
            //    ref byte dest = ref Unsafe.Add(ref meRef, me * nsize);
            //
            //    // x == item, - == empty
            //    // to buffer   |   from buffer
            //    // x           |   x
            //    // x           |   x <- item
            //    // x           |   x
            //    // - <- dest   |   x <- down
            //    // -           |   -
            //
            //    //item -> dest
            //    //Unsafe.CopyBlockUnaligned(ref dest, ref item, size);
            //    //down -> item
            //    //Unsafe.CopyBlockUnaligned(ref item, ref down, size);
            //
            //    switch (ElementSize)
            //    {
            //        case 2:
            //            CopyBlock<Block2>(ref dest, ref item);
            //            CopyBlock<Block2>(ref item, ref down);
            //            return;
            //        case 4:
            //            CopyBlock<Block4>(ref dest, ref item);
            //            CopyBlock<Block4>(ref item, ref down);
            //            return;
            //        case 8:
            //            CopyBlock<Block8>(ref dest, ref item);
            //            CopyBlock<Block8>(ref item, ref down);
            //            return;
            //        case 16:
            //            CopyBlock<Block16>(ref dest, ref item);
            //            CopyBlock<Block16>(ref item, ref down);
            //            return;
            //    }
            //    //no need to clear as no gc references
            //
            //    FrentExceptions.Throw_InvalidOperationException("This should be unreachable!");
            //}

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
            {
                return -1;
            }

            int size = Unsafe.SizeOf<T>();

            if ((size & (size - 1)) != 0)
            {
                //is not power of two
                return -1;
            }

            if (size > 16 || size < 2)
            {
                //we have block sizes 2, 4, 8, 16
                return -1;
            }

            return size;
        }
    }
}