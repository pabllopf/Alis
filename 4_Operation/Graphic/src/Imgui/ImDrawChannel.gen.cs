using System;
using System.Runtime.CompilerServices;
using Alis.Core.Graphic.ImGui.Utils;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im draw channel
    /// </summary>
    public unsafe struct ImDrawChannel
    {
        /// <summary>
        /// The cmd buffer
        /// </summary>
        public ImVector _CmdBuffer;
        /// <summary>
        /// The idx buffer
        /// </summary>
        public ImVector _IdxBuffer;
    }
    /// <summary>
    /// The im draw channel ptr
    /// </summary>
    public unsafe struct ImDrawChannelPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImDrawChannel* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImDrawChannelPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImDrawChannelPtr(ImDrawChannel* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImDrawChannelPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImDrawChannelPtr(IntPtr nativePtr) => NativePtr = (ImDrawChannel*)nativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawChannelPtr(ImDrawChannel* nativePtr) => new ImDrawChannelPtr(nativePtr);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawChannel* (ImDrawChannelPtr wrappedPtr) => wrappedPtr.NativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawChannelPtr(IntPtr nativePtr) => new ImDrawChannelPtr(nativePtr);
        /// <summary>
        /// Gets the value of the  cmdbuffer
        /// </summary>
        public ImPtrVector<ImDrawCmdPtr> _CmdBuffer => new ImPtrVector<ImDrawCmdPtr>(NativePtr->_CmdBuffer, Unsafe.SizeOf<ImDrawCmd>());
        /// <summary>
        /// Gets the value of the  idxbuffer
        /// </summary>
        public ImVector<ushort> _IdxBuffer => new ImVector<ushort>(NativePtr->_IdxBuffer);
    }
}
