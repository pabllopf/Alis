using System;
using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.ImGui.Extras.ImPlot
{
    /// <summary>
    /// The im plot point
    /// </summary>
    public unsafe partial struct ImPlotPoint
    {
        /// <summary>
        /// The 
        /// </summary>
        public double x;
        /// <summary>
        /// The 
        /// </summary>
        public double y;
    }
    /// <summary>
    /// The im plot point ptr
    /// </summary>
    public unsafe partial struct ImPlotPointPtr
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
        public ref double x => ref Unsafe.AsRef<double>(&NativePtr->x);
        /// <summary>
        /// Gets the value of the y
        /// </summary>
        public ref double y => ref Unsafe.AsRef<double>(&NativePtr->y);
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImPlotNative.ImPlotPoint_destroy((ImPlotPoint*)(NativePtr));
        }
    }
}
