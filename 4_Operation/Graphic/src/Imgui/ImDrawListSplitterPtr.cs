using System;
using Alis.Core.Graphic.ImGui.Utils;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im draw list splitter ptr
    /// </summary>
    public unsafe struct ImDrawListSplitterPtr
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
        public ref int Current => ref Unsafe.AsRef<int>(&NativePtr->Current);
        /// <summary>
        /// Gets the value of the  count
        /// </summary>
        public ref int Count => ref Unsafe.AsRef<int>(&NativePtr->Count);
        /// <summary>
        /// Gets the value of the  channels
        /// </summary>
        public ImPtrVector<ImDrawChannelPtr> Channels => new ImPtrVector<ImDrawChannelPtr>(NativePtr->Channels, Unsafe.SizeOf<ImDrawChannel>());
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
        /// <param name="drawList">The draw list</param>
        public void Merge(ImDrawListPtr drawList)
        {
            ImDrawList* nativeDrawList = drawList.NativePtr;
            ImGuiNative.ImDrawListSplitter_Merge((ImDrawListSplitter*)(NativePtr), nativeDrawList);
        }
        /// <summary>
        /// Sets the current channel using the specified draw list
        /// </summary>
        /// <param name="drawList">The draw list</param>
        /// <param name="channelIdx">The channel idx</param>
        public void SetCurrentChannel(ImDrawListPtr drawList, int channelIdx)
        {
            ImDrawList* nativeDrawList = drawList.NativePtr;
            ImGuiNative.ImDrawListSplitter_SetCurrentChannel((ImDrawListSplitter*)(NativePtr), nativeDrawList, channelIdx);
        }
        /// <summary>
        /// Splits the draw list
        /// </summary>
        /// <param name="drawList">The draw list</param>
        /// <param name="count">The count</param>
        public void Split(ImDrawListPtr drawList, int count)
        {
            ImDrawList* nativeDrawList = drawList.NativePtr;
            ImGuiNative.ImDrawListSplitter_Split((ImDrawListSplitter*)(NativePtr), nativeDrawList, count);
        }
    }
}