using System;
using System.Numerics;

namespace Alis.Core.Graphic.ImGui.ImGui
{
    /// <summary>
    /// The im draw cmd header
    /// </summary>
    public unsafe partial struct ImDrawCmdHeader
    {
        /// <summary>
        /// The clip rect
        /// </summary>
        public Vector4 ClipRect;
        /// <summary>
        /// The texture id
        /// </summary>
        public IntPtr TextureId;
        /// <summary>
        /// The vtx offset
        /// </summary>
        public uint VtxOffset;
    }
    /// <summary>
    /// The im draw cmd header ptr
    /// </summary>
    public unsafe partial struct ImDrawCmdHeaderPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImDrawCmdHeader* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImDrawCmdHeaderPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImDrawCmdHeaderPtr(ImDrawCmdHeader* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImDrawCmdHeaderPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImDrawCmdHeaderPtr(IntPtr nativePtr) => NativePtr = (ImDrawCmdHeader*)nativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawCmdHeaderPtr(ImDrawCmdHeader* nativePtr) => new ImDrawCmdHeaderPtr(nativePtr);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawCmdHeader* (ImDrawCmdHeaderPtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawCmdHeaderPtr(IntPtr nativePtr) => new ImDrawCmdHeaderPtr(nativePtr);
        /// <summary>
        /// Gets the value of the clip rect
        /// </summary>
        public ref Vector4 ClipRect => ref Unsafe.AsRef<Vector4>(&NativePtr->ClipRect);
        /// <summary>
        /// Gets the value of the texture id
        /// </summary>
        public ref IntPtr TextureId => ref Unsafe.AsRef<IntPtr>(&NativePtr->TextureId);
        /// <summary>
        /// Gets the value of the vtx offset
        /// </summary>
        public ref uint VtxOffset => ref Unsafe.AsRef<uint>(&NativePtr->VtxOffset);
    }
}
