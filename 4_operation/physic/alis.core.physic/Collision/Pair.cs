using System;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    /// The pair class
    /// </summary>
    public class Pair
    {
        /// <summary>
        /// The pair status enum
        /// </summary>
        [Flags]
        public enum PairStatus
        {
            /// <summary>
            /// The pair buffered pair status
            /// </summary>
            PairBuffered = 0x0001,
            /// <summary>
            /// The pair removed pair status
            /// </summary>
            PairRemoved = 0x0002,
            /// <summary>
            /// The pair final pair status
            /// </summary>
            PairFinal = 0x0004
        }

        /// <summary>
        /// Sets the buffered
        /// </summary>
        public void SetBuffered() { Status |= PairStatus.PairBuffered; }
        /// <summary>
        /// Clears the buffered
        /// </summary>
        public void ClearBuffered() { Status &= ~PairStatus.PairBuffered; }
        /// <summary>
        /// Describes whether this instance is buffered
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsBuffered() { return (Status & PairStatus.PairBuffered) == PairStatus.PairBuffered; }

        /// <summary>
        /// Sets the removed
        /// </summary>
        public void SetRemoved() { Status |= PairStatus.PairRemoved; }
        /// <summary>
        /// Clears the removed
        /// </summary>
        public void ClearRemoved() { Status &= ~PairStatus.PairRemoved; }
        /// <summary>
        /// Describes whether this instance is removed
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsRemoved() { return (Status & PairStatus.PairRemoved) == PairStatus.PairRemoved; }

        /// <summary>
        /// Sets the final
        /// </summary>
        public void SetFinal() { Status |= PairStatus.PairFinal; }
        /// <summary>
        /// Describes whether this instance is final
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsFinal() { return (Status & PairStatus.PairFinal) == PairStatus.PairFinal; }

        /// <summary>
        /// The user data
        /// </summary>
        public object UserData;
        /// <summary>
        /// The proxy id
        /// </summary>
        public ushort ProxyId1;
        /// <summary>
        /// The proxy id
        /// </summary>
        public ushort ProxyId2;
        /// <summary>
        /// The next
        /// </summary>
        public ushort Next;
        /// <summary>
        /// The status
        /// </summary>
        public PairStatus Status;
    }
}