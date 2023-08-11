using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    /// <summary>
    /// The im draw vert
    /// </summary>
    public unsafe partial struct ImDrawVert
    {
        /// <summary>
        /// The pos
        /// </summary>
        public Vector2 pos;
        /// <summary>
        /// The uv
        /// </summary>
        public Vector2 uv;
        /// <summary>
        /// The col
        /// </summary>
        public uint col;
    }
    /// <summary>
    /// The im draw vert ptr
    /// </summary>
    public unsafe partial struct ImDrawVertPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImDrawVert* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImDrawVertPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImDrawVertPtr(ImDrawVert* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImDrawVertPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImDrawVertPtr(IntPtr nativePtr) => NativePtr = (ImDrawVert*)nativePtr;
        public static implicit operator ImDrawVertPtr(ImDrawVert* nativePtr) => new ImDrawVertPtr(nativePtr);
        public static implicit operator ImDrawVert* (ImDrawVertPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImDrawVertPtr(IntPtr nativePtr) => new ImDrawVertPtr(nativePtr);
        /// <summary>
        /// Gets the value of the pos
        /// </summary>
        public ref Vector2 pos => ref Unsafe.AsRef<Vector2>(&NativePtr->pos);
        /// <summary>
        /// Gets the value of the uv
        /// </summary>
        public ref Vector2 uv => ref Unsafe.AsRef<Vector2>(&NativePtr->uv);
        /// <summary>
        /// Gets the value of the col
        /// </summary>
        public ref uint col => ref Unsafe.AsRef<uint>(&NativePtr->col);
    }
}
