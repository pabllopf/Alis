using System;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im gui storage pair ptr
    /// </summary>
    public unsafe struct ImGuiStoragePairPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImGuiStoragePair* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiStoragePairPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiStoragePairPtr(ImGuiStoragePair* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiStoragePairPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiStoragePairPtr(IntPtr nativePtr) => NativePtr = (ImGuiStoragePair*)nativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiStoragePairPtr(ImGuiStoragePair* nativePtr) => new ImGuiStoragePairPtr(nativePtr);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiStoragePair*(ImGuiStoragePairPtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiStoragePairPtr(IntPtr nativePtr) => new ImGuiStoragePairPtr(nativePtr);
    }
}