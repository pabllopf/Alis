using System;
using Alis.Core.Graphic.ImGui.Utils;

namespace Alis.Core.Graphic.Imgui.Extras.ImNodes
{
    /// <summary>
    /// The io ptr
    /// </summary>
    public unsafe struct IoPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public Io* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="IoPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public IoPtr(Io* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="IoPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public IoPtr(IntPtr nativePtr) => NativePtr = (Io*)nativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator IoPtr(Io* nativePtr) => new IoPtr(nativePtr);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator Io* (IoPtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator IoPtr(IntPtr nativePtr) => new IoPtr(nativePtr);
        /// <summary>
        /// Gets the value of the emulate three button mouse
        /// </summary>
        public ref EmulateThreeButtonMouse EmulateThreeButtonMouse => ref Unsafe.AsRef<EmulateThreeButtonMouse>(&NativePtr->EmulateThreeButtonMouse);
        /// <summary>
        /// Gets the value of the link detach with modifier click
        /// </summary>
        public ref LinkDetachWithModifierClick LinkDetachWithModifierClick => ref Unsafe.AsRef<LinkDetachWithModifierClick>(&NativePtr->LinkDetachWithModifierClick);
    }
}