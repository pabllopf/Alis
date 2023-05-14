using System;
using System.Runtime.CompilerServices;
using Unsafe = Alis.Core.Graphic.ImGui.ImGui.UnsafeCode.Unsafe;

namespace ImGuiNET
{
    /// <summary>
    /// The im draw list splitter
    /// </summary>
    public unsafe partial struct ImDrawListSplitter
    {
        /// <summary>
        /// The current
        /// </summary>
        public int _Current;
        /// <summary>
        /// The count
        /// </summary>
        public int _Count;
        /// <summary>
        /// The channels
        /// </summary>
        public ImVector _Channels;
    }
    /// <summary>
    /// The im draw list splitter ptr
    /// </summary>
    public unsafe partial struct ImDrawListSplitterPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImDrawListSplitter* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImDrawListSplitterPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImDrawListSplitterPtr(ImDrawListSplitter* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImDrawListSplitterPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImDrawListSplitterPtr(IntPtr nativePtr) => NativePtr = (ImDrawListSplitter*)nativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawListSplitterPtr(ImDrawListSplitter* nativePtr) => new ImDrawListSplitterPtr(nativePtr);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawListSplitter* (ImDrawListSplitterPtr wrappedPtr) => wrappedPtr.NativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawListSplitterPtr(IntPtr nativePtr) => new ImDrawListSplitterPtr(nativePtr);
        /// <summary>
        /// Gets the value of the  current
        /// </summary>
        public ref int _Current => ref Unsafe.AsRef<int>(&NativePtr->_Current);
        /// <summary>
        /// Gets the value of the  count
        /// </summary>
        public ref int _Count => ref Unsafe.AsRef<int>(&NativePtr->_Count);
        /// <summary>
        /// Gets the value of the  channels
        /// </summary>
        public ImPtrVector<ImDrawChannelPtr> _Channels => new ImPtrVector<ImDrawChannelPtr>(NativePtr->_Channels, Unsafe.SizeOf<ImDrawChannel>());
        /// <summary>
        /// Clears this instance
        /// </summary>
        public void Clear()
        {
            ImGuiNative.ImDrawListSplitter_Clear((ImDrawListSplitter*)(NativePtr));
        }
        /// <summary>
        /// Clears the free memory
        /// </summary>
        public void ClearFreeMemory()
        {
            ImGuiNative.ImDrawListSplitter_ClearFreeMemory((ImDrawListSplitter*)(NativePtr));
        }
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImDrawListSplitter_destroy((ImDrawListSplitter*)(NativePtr));
        }
        /// <summary>
        /// Merges the draw list
        /// </summary>
        /// <param name="draw_list">The draw list</param>
        public void Merge(ImDrawListPtr draw_list)
        {
            ImDrawList* native_draw_list = draw_list.NativePtr;
            ImGuiNative.ImDrawListSplitter_Merge((ImDrawListSplitter*)(NativePtr), native_draw_list);
        }
        /// <summary>
        /// Sets the current channel using the specified draw list
        /// </summary>
        /// <param name="draw_list">The draw list</param>
        /// <param name="channel_idx">The channel idx</param>
        public void SetCurrentChannel(ImDrawListPtr draw_list, int channel_idx)
        {
            ImDrawList* native_draw_list = draw_list.NativePtr;
            ImGuiNative.ImDrawListSplitter_SetCurrentChannel((ImDrawListSplitter*)(NativePtr), native_draw_list, channel_idx);
        }
        /// <summary>
        /// Splits the draw list
        /// </summary>
        /// <param name="draw_list">The draw list</param>
        /// <param name="count">The count</param>
        public void Split(ImDrawListPtr draw_list, int count)
        {
            ImDrawList* native_draw_list = draw_list.NativePtr;
            ImGuiNative.ImDrawListSplitter_Split((ImDrawListSplitter*)(NativePtr), native_draw_list, count);
        }
    }
}
