using System;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    /// Contact ids to facilitate warm starting.
    /// </summary>
    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct ContactID
    {
        /// <summary>
        /// The features
        /// </summary>
        [System.Runtime.InteropServices.FieldOffset(0)]
        public Features Features;

        /// <summary>
        /// Used to quickly compare contact ids.
        /// </summary>
        [System.Runtime.InteropServices.FieldOffset(0)]
        public UInt32 Key;
    }
}