using System;

namespace Alis.Core.Graphic.ImGui.Extras.ImNodes
{
    /// <summary>
    /// The emulate three button mouse
    /// </summary>
    public unsafe partial struct EmulateThreeButtonMouse
    {
        /// <summary>
        /// The modifier
        /// </summary>
        public byte* Modifier;
    }
    /// <summary>
    /// The emulate three button mouse ptr
    /// </summary>
    public unsafe partial struct EmulateThreeButtonMousePtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public EmulateThreeButtonMouse* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="EmulateThreeButtonMousePtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public EmulateThreeButtonMousePtr(EmulateThreeButtonMouse* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="EmulateThreeButtonMousePtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public EmulateThreeButtonMousePtr(IntPtr nativePtr) => NativePtr = (EmulateThreeButtonMouse*)nativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator EmulateThreeButtonMousePtr(EmulateThreeButtonMouse* nativePtr) => new EmulateThreeButtonMousePtr(nativePtr);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator EmulateThreeButtonMouse* (EmulateThreeButtonMousePtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator EmulateThreeButtonMousePtr(IntPtr nativePtr) => new EmulateThreeButtonMousePtr(nativePtr);
        /// <summary>
        /// Gets or sets the value of the modifier
        /// </summary>
        public IntPtr Modifier { get => (IntPtr)NativePtr->Modifier; set => NativePtr->Modifier = (byte*)value; }
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            imnodesNative.EmulateThreeButtonMouse_destroy((EmulateThreeButtonMouse*)(NativePtr));
        }
    }
}
