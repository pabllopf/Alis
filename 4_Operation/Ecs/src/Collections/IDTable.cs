// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IDTable.cs
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
using Alis.Core.Ecs.Events;

namespace Alis.Core.Ecs.Collections
{
    /// <summary>
    ///     The id table class
    /// </summary>
    internal abstract class IdTable
    {
        /// <summary>
        ///     The has gc references
        /// </summary>
        private readonly bool hasGcReferences;

        /// <summary>
        ///     The buffer
        /// </summary>
        protected Array Buffer;

        /// <summary>
        ///     The next index
        /// </summary>
        protected int NextIndex;

        /// <summary>
        ///     The recycled
        /// </summary>
        protected FastStack<int> Recycled;

        /// <summary>
        ///     Initializes a new instance of the <see cref="IdTable" /> class
        /// </summary>
        /// <param name="empty">The empty</param>
        /// <param name="gcRefs">The gc refs</param>
        public IdTable(Array empty, bool gcRefs)
        {
            Buffer = empty;
            hasGcReferences = gcRefs;
            Recycled = new FastStack<int>(2);
        }

        /// <summary>
        ///     Creates the boxed using the specified to store
        /// </summary>
        /// <param name="toStore">The to store</param>
        /// <returns>The index</returns>
        public int CreateBoxed(object toStore)
        {
            int index;
            if (Recycled.CanPop())
            {
                index = Recycled.Pop();
            }
            else
            {
                index = NextIndex++;
                if (index == Buffer.Length)
                {
                    Double();
                }
            }

            SetValue(toStore, index);

            return index;
        }

        /// <summary>
        ///     Gets the value boxed using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The object</returns>
        public object GetValueBoxed(int index) => GetValue(index);

        /// <summary>
        ///     Takes the boxed using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The object</returns>
        public object TakeBoxed(int index)
        {
            Recycled.Push(index);
            return GetValue(index);
        }

        /// <summary>
        ///     Consumes the index
        /// </summary>
        /// <param name="index">The index</param>
        public void Consume(int index)
        {
            Recycled.Push(index);
            if (hasGcReferences)
            {
                ClearValue(index);
            }
        }

        /// <summary>
        ///     Invokes the event with and consume using the specified generic event
        /// </summary>
        /// <param name="genericEvent">The generic event</param>
        /// <param name="entity">The entity</param>
        /// <param name="index">The index</param>
        public abstract void InvokeEventWithAndConsume(GenericEvent genericEvent, Entity entity, int index);

        /// <summary>
        ///     Sets the value using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="index">The index</param>
        protected abstract void SetValue(object value, int index);

        /// <summary>
        ///     Clears the value using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        protected abstract void ClearValue(int index);

        /// <summary>
        ///     Gets the value using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The object</returns>
        protected abstract object GetValue(int index);

        /// <summary>
        ///     Doubles this instance
        /// </summary>
        protected abstract void Double();
    }

    /// <summary>
    ///     The id table class
    /// </summary>
    /// <seealso cref="IdTable" />
    internal class IdTable<T> : IdTable
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="IdTable{T}" /> class
        /// </summary>
        public IdTable() : base(Array.Empty<T>(), RuntimeHelpers.IsReferenceOrContainsReferences<T>())
        {
        }

        /// <summary>
        ///     Gets the value of the buffer
        /// </summary>
        public new ref T[] Buffer => ref Unsafe.As<Array, T[]>(ref base.Buffer);

        /// <summary>
        ///     Creates the index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        public ref T Create(out int index)
        {
            if (Recycled.CanPop())
            {
                index = Recycled.Pop();
            }
            else
            {
                index = NextIndex++;
                if (index == base.Buffer.Length)
                {
                    Double();
                }
            }

            return ref Buffer[index];
        }

        /// <summary>
        ///     Invokes the event with and consume using the specified generic event
        /// </summary>
        /// <param name="genericEvent">The generic event</param>
        /// <param name="entity">The entity</param>
        /// <param name="index">The index</param>
        public override void InvokeEventWithAndConsume(GenericEvent genericEvent, Entity entity, int index)
        {
            genericEvent?.Invoke(entity, ref Buffer[index]);
            Recycled.Push(index);
        }

        /// <summary>
        ///     Takes the index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        public ref T Take(int index) => ref Buffer[index];

        /// <summary>
        ///     Doubles this instance
        /// </summary>
        protected override void Double()
        {
            Array.Resize(ref Buffer, Math.Max(Buffer.Length << 1, 1));
        }

        /// <summary>
        ///     Gets the value using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The object</returns>
        protected override object GetValue(int index) => Buffer[index]!;

        /// <summary>
        ///     Sets the value using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="index">The index</param>
        protected override void SetValue(object value, int index) => Buffer[index] = (T) value;

        /// <summary>
        ///     Clears the value using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        protected override void ClearValue(int index) => Buffer[index] = default(T)!;
    }
}