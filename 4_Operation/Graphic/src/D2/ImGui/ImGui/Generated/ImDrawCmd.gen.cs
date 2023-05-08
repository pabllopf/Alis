using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    /// <summary>
    /// The im draw cmd
    /// </summary>
    public unsafe partial struct ImDrawCmd
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
        /// <summary>
        /// The idx offset
        /// </summary>
        public uint IdxOffset;
        /// <summary>
        /// The elem count
        /// </summary>
        public uint ElemCount;
        /// <summary>
        /// The user callback
        /// </summary>
        public IntPtr UserCallback;
        /// <summary>
        /// The user callback data
        /// </summary>
        public void* UserCallbackData;
    }
    /// <summary>
    /// The im draw cmd ptr
    /// </summary>
    public unsafe partial struct ImDrawCmdPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImDrawCmd* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImDrawCmdPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImDrawCmdPtr(ImDrawCmd* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImDrawCmdPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        
        public ImDrawCmdPtr(IntPtr nativePtr) => NativePtr = (ImDrawCmd*)nativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawCmdPtr(ImDrawCmd* nativePtr) => new ImDrawCmdPtr(nativePtr);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawCmd* (ImDrawCmdPtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// /
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawCmdPtr(IntPtr nativePtr) => new ImDrawCmdPtr(nativePtr);
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
        /// <summary>
        /// Gets the value of the idx offset
        /// </summary>
        public ref uint IdxOffset => ref Unsafe.AsRef<uint>(&NativePtr->IdxOffset);
        /// <summary>
        /// Gets the value of the elem count
        /// </summary>
        public ref uint ElemCount => ref Unsafe.AsRef<uint>(&NativePtr->ElemCount);
        /// <summary>
        /// Gets the value of the user callback
        /// </summary>
        public ref IntPtr UserCallback => ref Unsafe.AsRef<IntPtr>(&NativePtr->UserCallback);
        /// <summary>
        /// Gets or sets the value of the user callback data
        /// </summary>
        public IntPtr UserCallbackData { get => (IntPtr)NativePtr->UserCallbackData; set => NativePtr->UserCallbackData = (void*)value; }
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImDrawCmd_destroy((ImDrawCmd*)(NativePtr));
        }
        /// <summary>
        /// Gets the tex id
        /// </summary>
        /// <returns>The ret</returns>
        public IntPtr GetTexID()
        {
            IntPtr ret = ImGuiNative.ImDrawCmd_GetTexID((ImDrawCmd*)(NativePtr));
            return ret;
        }
    }
}
