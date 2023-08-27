using System;
using System.Numerics;
using Alis.Core.Graphic.ImGui.Utils;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im color ptr
    /// </summary>
    public unsafe struct ImColorPtr
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImColorPtr(ImColor* nativePtr) => new ImColorPtr(nativePtr);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImColor* (ImColorPtr wrappedPtr) => wrappedPtr.NativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
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
        public ImColor Hsv(float h, float s, float v)
        {
            ImColor retval;
            float a = 1.0f;
            ImGuiNative.ImColor_HSV(&retval, h, s, v, a);
            return retval;
        }
        /// <summary>
        /// Hsvs the h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        /// <param name="a">The </param>
        /// <returns>The retval</returns>
        public ImColor Hsv(float h, float s, float v, float a)
        {
            ImColor retval;
            ImGuiNative.ImColor_HSV(&retval, h, s, v, a);
            return retval;
        }
        /// <summary>
        /// Sets the hsv using the specified h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        public void SetHsv(float h, float s, float v)
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
        public void SetHsv(float h, float s, float v, float a)
        {
            ImGuiNative.ImColor_SetHSV((ImColor*)(NativePtr), h, s, v, a);
        }
    }
}