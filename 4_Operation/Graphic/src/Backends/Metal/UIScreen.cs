using System;
using static Alis.Core.Graphic.Backends.Metal.ObjectiveCRuntime;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The ui screen
    /// </summary>
    public unsafe struct UIScreen
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="UIScreen"/> class
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public UIScreen(IntPtr ptr)
        {
            NativePtr = ptr;
        }

        /// <summary>
        /// Gets the value of the native scale
        /// </summary>
        public CGFloat nativeScale => CGFloat_objc_msgSend(NativePtr, "nativeScale");

        /// <summary>
        /// Gets the value of the main screen
        /// </summary>
        public static UIScreen mainScreen
            => objc_msgSend<UIScreen>(new ObjCClass(nameof(UIScreen)), "mainScreen");
    }
}