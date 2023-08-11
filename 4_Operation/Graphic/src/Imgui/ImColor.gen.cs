using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace ImGuiNET
{
    /// <summary>
    /// The im color
    /// </summary>
    public unsafe partial struct ImColor
    {
        /// <summary>
        /// The value
        /// </summary>
        public Vector4 Value;
    }
    /// <summary>
    /// The im color ptr
    /// </summary>
    public unsafe partial struct ImColorPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImColor* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImColorPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImColorPtr(ImColor* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImColorPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImColorPtr(IntPtr nativePtr) => NativePtr = (ImColor*)nativePtr;
        public static implicit operator ImColorPtr(ImColor* nativePtr) => new ImColorPtr(nativePtr);
        public static implicit operator ImColor* (ImColorPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImColorPtr(IntPtr nativePtr) => new ImColorPtr(nativePtr);
        /// <summary>
        /// Gets the value of the value
        /// </summary>
        public ref Vector4 Value => ref Unsafe.AsRef<Vector4>(&NativePtr->Value);
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImColor_destroy((ImColor*)(NativePtr));
        }
        /// <summary>
        /// Hsvs the h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        /// <returns>The retval</returns>
        public ImColor HSV(float h, float s, float v)
        {
            ImColor __retval;
            float a = 1.0f;
            ImGuiNative.ImColor_HSV(&__retval, h, s, v, a);
            return __retval;
        }
        /// <summary>
        /// Hsvs the h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        /// <param name="a">The </param>
        /// <returns>The retval</returns>
        public ImColor HSV(float h, float s, float v, float a)
        {
            ImColor __retval;
            ImGuiNative.ImColor_HSV(&__retval, h, s, v, a);
            return __retval;
        }
        /// <summary>
        /// Sets the hsv using the specified h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        public void SetHSV(float h, float s, float v)
        {
            float a = 1.0f;
            ImGuiNative.ImColor_SetHSV((ImColor*)(NativePtr), h, s, v, a);
        }
        /// <summary>
        /// Sets the hsv using the specified h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        /// <param name="a">The </param>
        public void SetHSV(float h, float s, float v, float a)
        {
            ImGuiNative.ImColor_SetHSV((ImColor*)(NativePtr), h, s, v, a);
        }
    }
}
