using System;
using System.Numerics;

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    /// The im gui size callback data ptr
    /// </summary>
    public unsafe struct ImGuiSizeCallbackDataPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImGuiSizeCallbackData* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiSizeCallbackDataPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiSizeCallbackDataPtr(ImGuiSizeCallbackData* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiSizeCallbackDataPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiSizeCallbackDataPtr(IntPtr nativePtr) => NativePtr = (ImGuiSizeCallbackData*)nativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiSizeCallbackDataPtr(ImGuiSizeCallbackData* nativePtr) => new ImGuiSizeCallbackDataPtr(nativePtr);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiSizeCallbackData* (ImGuiSizeCallbackDataPtr wrappedPtr) => wrappedPtr.NativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiSizeCallbackDataPtr(IntPtr nativePtr) => new ImGuiSizeCallbackDataPtr(nativePtr);
        /// <summary>
        /// Gets or sets the value of the user data
        /// </summary>
        public IntPtr UserData { get => (IntPtr)NativePtr->UserData; set => NativePtr->UserData = (void*)value; }
        /// <summary>
        /// Gets the value of the pos
        /// </summary>
        public ref Vector2 Pos => ref Unsafe.AsRef<Vector2>(&NativePtr->Pos);
        /// <summary>
        /// Gets the value of the current size
        /// </summary>
        public ref Vector2 CurrentSize => ref Unsafe.AsRef<Vector2>(&NativePtr->CurrentSize);
        /// <summary>
        /// Gets the value of the desired size
        /// </summary>
        public ref Vector2 DesiredSize => ref Unsafe.AsRef<Vector2>(&NativePtr->DesiredSize);
    }
}