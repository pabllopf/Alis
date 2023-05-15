using System;

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    /// The im gui once upon frame ptr
    /// </summary>
    public unsafe struct ImGuiOnceUponAFramePtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImGuiOnceUponAFrame* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiOnceUponAFramePtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiOnceUponAFramePtr(ImGuiOnceUponAFrame* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiOnceUponAFramePtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiOnceUponAFramePtr(IntPtr nativePtr) => NativePtr = (ImGuiOnceUponAFrame*)nativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiOnceUponAFramePtr(ImGuiOnceUponAFrame* nativePtr) => new ImGuiOnceUponAFramePtr(nativePtr);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiOnceUponAFrame* (ImGuiOnceUponAFramePtr wrappedPtr) => wrappedPtr.NativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiOnceUponAFramePtr(IntPtr nativePtr) => new ImGuiOnceUponAFramePtr(nativePtr);
        /// <summary>
        /// Gets the value of the ref frame
        /// </summary>
        public ref int RefFrame => ref Unsafe.AsRef<int>(&NativePtr->RefFrame);
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiOnceUponAFrame_destroy((ImGuiOnceUponAFrame*)(NativePtr));
        }
    }
}