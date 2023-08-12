using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im gui storage pair
    /// </summary>
    public struct ImGuiStoragePair
    {
        /// <summary>
        /// The key
        /// </summary>
        public uint Key;
        /// <summary>
        /// The value
        /// </summary>
        public UnionValue Value;
    }

    /// <summary>
    /// The im gui storage pair ptr
    /// </summary>
    public unsafe struct ImGuiStoragePairPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImGuiStoragePair* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiStoragePairPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiStoragePairPtr(ImGuiStoragePair* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiStoragePairPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiStoragePairPtr(IntPtr nativePtr) => NativePtr = (ImGuiStoragePair*)nativePtr;
        public static implicit operator ImGuiStoragePairPtr(ImGuiStoragePair* nativePtr) => new ImGuiStoragePairPtr(nativePtr);
        public static implicit operator ImGuiStoragePair*(ImGuiStoragePairPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiStoragePairPtr(IntPtr nativePtr) => new ImGuiStoragePairPtr(nativePtr);
    }

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
