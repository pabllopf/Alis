using System;
using Alis.Core.Graphic.ImGui.Utils;

namespace ImPlotNET
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
        public static implicit operator ImPlotPointPtr(ImPlotPoint* nativePtr) => new ImPlotPointPtr(nativePtr);
        public static implicit operator ImPlotPoint* (ImPlotPointPtr wrappedPtr) => wrappedPtr.NativePtr;
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
