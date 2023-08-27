using System;
using System.Numerics;
using Alis.Core.Graphic.ImGui.Utils;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im draw data ptr
    /// </summary>
    public unsafe partial struct ImDrawDataPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImDrawData* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImDrawDataPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImDrawDataPtr(ImDrawData* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImDrawDataPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImDrawDataPtr(IntPtr nativePtr) => NativePtr = (ImDrawData*)nativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawDataPtr(ImDrawData* nativePtr) => new ImDrawDataPtr(nativePtr);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawData* (ImDrawDataPtr wrappedPtr) => wrappedPtr.NativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawDataPtr(IntPtr nativePtr) => new ImDrawDataPtr(nativePtr);
        /// <summary>
        /// Gets the value of the valid
        /// </summary>
        public ref bool Valid => ref Unsafe.AsRef<bool>(&NativePtr->Valid);
        /// <summary>
        /// Gets the value of the cmd lists count
        /// </summary>
        public ref int CmdListsCount => ref Unsafe.AsRef<int>(&NativePtr->CmdListsCount);
        /// <summary>
        /// Gets the value of the total idx count
        /// </summary>
        public ref int TotalIdxCount => ref Unsafe.AsRef<int>(&NativePtr->TotalIdxCount);
        /// <summary>
        /// Gets the value of the total vtx count
        /// </summary>
        public ref int TotalVtxCount => ref Unsafe.AsRef<int>(&NativePtr->TotalVtxCount);
        /// <summary>
        /// Gets or sets the value of the cmd lists
        /// </summary>
        public IntPtr CmdLists { get => (IntPtr)NativePtr->CmdLists; set => NativePtr->CmdLists = (ImDrawList**)value; }
        /// <summary>
        /// Gets the value of the display pos
        /// </summary>
        public ref Vector2 DisplayPos => ref Unsafe.AsRef<Vector2>(&NativePtr->DisplayPos);
        /// <summary>
        /// Gets the value of the display size
        /// </summary>
        public ref Vector2 DisplaySize => ref Unsafe.AsRef<Vector2>(&NativePtr->DisplaySize);
        /// <summary>
        /// Gets the value of the framebuffer scale
        /// </summary>
        public ref Vector2 FramebufferScale => ref Unsafe.AsRef<Vector2>(&NativePtr->FramebufferScale);
        /// <summary>
        /// Gets the value of the owner viewport
        /// </summary>
        public ImGuiViewportPtr OwnerViewport => new ImGuiViewportPtr(NativePtr->OwnerViewport);
        /// <summary>
        /// Clears this instance
        /// </summary>
        public void Clear()
        {
            ImGuiNative.ImDrawData_Clear((ImDrawData*)(NativePtr));
        }
        /// <summary>
        /// Des the index all buffers
        /// </summary>
        public void DeIndexAllBuffers()
        {
            ImGuiNative.ImDrawData_DeIndexAllBuffers((ImDrawData*)(NativePtr));
        }
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImDrawData_destroy((ImDrawData*)(NativePtr));
        }
        /// <summary>
        /// Scales the clip rects using the specified fb scale
        /// </summary>
        /// <param name="fb_scale">The fb scale</param>
        public void ScaleClipRects(Vector2 fb_scale)
        {
            ImGuiNative.ImDrawData_ScaleClipRects((ImDrawData*)(NativePtr), fb_scale);
        }
    }
}