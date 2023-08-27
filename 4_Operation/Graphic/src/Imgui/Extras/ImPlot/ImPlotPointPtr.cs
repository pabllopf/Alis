using System;
using Alis.Core.Graphic.ImGui.Utils;

namespace Alis.Core.Graphic.Imgui.Extras.ImPlot
{
    /// <summary>
    /// The im plot point ptr
    /// </summary>
    public unsafe struct ImPlotPointPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImPlotPoint* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImPlotPointPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImPlotPointPtr(ImPlotPoint* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImPlotPointPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImPlotPointPtr(IntPtr nativePtr) => NativePtr = (ImPlotPoint*)nativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImPlotPointPtr(ImPlotPoint* nativePtr) => new ImPlotPointPtr(nativePtr);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImPlotPoint* (ImPlotPointPtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImPlotPointPtr(IntPtr nativePtr) => new ImPlotPointPtr(nativePtr);
        /// <summary>
        /// Gets the value of the x
        /// </summary>
        public ref double X => ref Unsafe.AsRef<double>(&NativePtr->X);
        /// <summary>
        /// Gets the value of the y
        /// </summary>
        public ref double Y => ref Unsafe.AsRef<double>(&NativePtr->Y);
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImPlotNative.ImPlotPoint_destroy((ImPlotPoint*)(NativePtr));
        }
    }
}