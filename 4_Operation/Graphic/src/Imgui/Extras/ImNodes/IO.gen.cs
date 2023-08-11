using System;
using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.ImGui.Extras.ImNodes
{
    /// <summary>
    /// The io
    /// </summary>
    public unsafe partial struct IO
    {
        /// <summary>
        /// The emulate three button mouse
        /// </summary>
        public EmulateThreeButtonMouse emulate_three_button_mouse;
        /// <summary>
        /// The link detach with modifier click
        /// </summary>
        public LinkDetachWithModifierClick link_detach_with_modifier_click;
    }
    /// <summary>
    /// The io ptr
    /// </summary>
    public unsafe partial struct IOPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public IO* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="IOPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public IOPtr(IO* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="IOPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public IOPtr(IntPtr nativePtr) => NativePtr = (IO*)nativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator IOPtr(IO* nativePtr) => new IOPtr(nativePtr);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator IO* (IOPtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator IOPtr(IntPtr nativePtr) => new IOPtr(nativePtr);
        /// <summary>
        /// Gets the value of the emulate three button mouse
        /// </summary>
        public ref EmulateThreeButtonMouse emulate_three_button_mouse => ref Unsafe.AsRef<EmulateThreeButtonMouse>(&NativePtr->emulate_three_button_mouse);
        /// <summary>
        /// Gets the value of the link detach with modifier click
        /// </summary>
        public ref LinkDetachWithModifierClick link_detach_with_modifier_click => ref Unsafe.AsRef<LinkDetachWithModifierClick>(&NativePtr->link_detach_with_modifier_click);
    }
}
