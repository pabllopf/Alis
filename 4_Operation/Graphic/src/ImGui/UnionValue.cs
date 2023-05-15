using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    /// The union value
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct UnionValue
    {
        /// <summary>
        /// The value 32
        /// </summary>
        [FieldOffset(0)]
        public int ValueI32;
        /// <summary>
        /// The value 32
        /// </summary>
        [FieldOffset(0)]
        public float ValueF32;
        /// <summary>
        /// The value ptr
        /// </summary>
        [FieldOffset(0)]
        public IntPtr ValuePtr;
    }
}