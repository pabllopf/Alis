using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im gui platform ime data
    /// </summary>
    public unsafe partial struct ImGuiPlatformImeData
    {
        /// <summary>
        /// The want visible
        /// </summary>
        public byte WantVisible;
        /// <summary>
        /// The input pos
        /// </summary>
        public Vector2 InputPos;
        /// <summary>
        /// The input line height
        /// </summary>
        public float InputLineHeight;
    }
    /// <summary>
    /// The im gui platform ime data ptr
    /// </summary>
    public unsafe partial struct ImGuiPlatformImeDataPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImGuiPlatformImeData* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiPlatformImeDataPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiPlatformImeDataPtr(ImGuiPlatformImeData* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiPlatformImeDataPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiPlatformImeDataPtr(IntPtr nativePtr) => NativePtr = (ImGuiPlatformImeData*)nativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiPlatformImeDataPtr(ImGuiPlatformImeData* nativePtr) => new ImGuiPlatformImeDataPtr(nativePtr);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiPlatformImeData* (ImGuiPlatformImeDataPtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiPlatformImeDataPtr(IntPtr nativePtr) => new ImGuiPlatformImeDataPtr(nativePtr);
        /// <summary>
        /// Gets the value of the want visible
        /// </summary>
        public ref bool WantVisible => ref Unsafe.AsRef<bool>(&NativePtr->WantVisible);
        /// <summary>
        /// Gets the value of the input pos
        /// </summary>
        public ref Vector2 InputPos => ref Unsafe.AsRef<Vector2>(&NativePtr->InputPos);
        /// <summary>
        /// Gets the value of the input line height
        /// </summary>
        public ref float InputLineHeight => ref Unsafe.AsRef<float>(&NativePtr->InputLineHeight);
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiPlatformImeData_destroy((ImGuiPlatformImeData*)(NativePtr));
        }
    }
}
