using System;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.Backends.Metal;
using static Alis.Core.Graphic.Backends.Metal.ObjectiveCRuntime;

namespace Alis.Core.Graphic.Backends.OpenGL.EAGL
{
    /// <summary>
    /// The caeagl layer
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CAEAGLLayer
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;

        /// <summary>
        /// News
        /// </summary>
        /// <returns>The caeagl layer</returns>
        public static CAEAGLLayer New()
        {
            return MTLUtil.AllocInit<CAEAGLLayer>("CAEAGLLayer");
        }

        /// <summary>
        /// Gets or sets the value of the frame
        /// </summary>
        public CGRect frame
        {
            get => CGRect_objc_msgSend(NativePtr, "frame");
            set => objc_msgSend(NativePtr, "setFrame:", value);
        }

        /// <summary>
        /// Gets or sets the value of the opaque
        /// </summary>
        public Bool8 opaque
        {
            get => bool8_objc_msgSend(NativePtr, "isOpaque");
            set => objc_msgSend(NativePtr, "setOpaque:", value);
        }

        /// <summary>
        /// Removes the from superlayer
        /// </summary>
        public void removeFromSuperlayer() => objc_msgSend(NativePtr, "removeFromSuperlayer");

        /// <summary>
        /// Releases this instance
        /// </summary>
        public void Release() => release(NativePtr);
    }
}