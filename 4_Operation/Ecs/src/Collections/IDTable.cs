using System;
using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Core.Events;

namespace Alis.Core.Ecs.Collections
{
    /// <summary>
    ///     The id table class
    /// </summary>
    public abstract class IdTable : IDisposable
    {
        /// <summary>
        ///     The has gc references
        /// </summary>
        private readonly bool _hasGcReferences;

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
        protected FastestStack<int> Recycled;

        /// <summary>
        ///     Initializes a new instance of the <see cref="IdTable" /> class
        /// </summary>
        /// <param name="empty">The empty</param>
        /// <param name="gcRefs">The gc refs</param>
        protected IdTable(Array empty, bool gcRefs)
        {
            Buffer = empty;
            _hasGcReferences = gcRefs;
            Recycled = new FastestStack<int>(2);
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
                    Double();
            }

            SetValue(toStore, index);

            return index;
        }

        /// <summary>
        ///     Gets the value boxed using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The object</returns>
        public object GetValueBoxed(int index)
        {
            return GetValue(index);
        }

        /// <summary>
        ///     Takes the boxed using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The object</returns>
        public object TakeBoxed(int index)
        {
            return GetValue(index);
        }

        /// <summary>
        ///     Consumes the index
        /// </summary>
        /// <param name="index">The index</param>
        public void Consume(int index)
        {
            Recycled.Push(index);
            if (_hasGcReferences) ClearValue(index);
        }

        /// <summary>
        ///     Invokes the event with and consume using the specified generic event
        /// </summary>
        /// <param name="genericEvent">The generic event</param>
        /// <param name="gameObject">The gameObject</param>
        /// <param name="index">The index</param>
        public abstract void InvokeEventWithAndConsume(GenericEvent genericEvent, GameObject gameObject, int index);

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

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            Recycled.Dispose();
        }
    }

    /// <summary>
    ///     The id table class
    /// </summary>
    /// <seealso cref="IdTable" />
    public class IdTable<T> : IdTable
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="IdTableww{T}" /> class
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
                    Double();
            }

            return ref Buffer[index];
        }

        /// <summary>
        ///     Invokes the event with and consume using the specified generic event
        /// </summary>
        /// <param name="genericEvent">The generic event</param>
        /// <param name="gameObject">The gameObject</param>
        /// <param name="index">The index</param>
        public override void InvokeEventWithAndConsume(GenericEvent genericEvent, GameObject gameObject, int index)
        {
            genericEvent?.Invoke(gameObject, ref Buffer[index]);
            Recycled.Push(index);
        }

        /// <summary>
        ///     Takes the index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        public ref T Take(int index)
        {
            return ref Buffer[index];
        }

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
        protected override object GetValue(int index)
        {
            return Buffer[index]!;
        }

        /// <summary>
        ///     Sets the value using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="index">The index</param>
        protected override void SetValue(object value, int index)
        {
            Buffer[index] = (T)value;
        }

        /// <summary>
        ///     Clears the value using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        protected override void ClearValue(int index)
        {
            Buffer[index] = default!;
        }
    }
}