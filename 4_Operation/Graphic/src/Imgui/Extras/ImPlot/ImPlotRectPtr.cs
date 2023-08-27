using System;
using Alis.Core.Graphic.ImGui.Utils;

namespace Alis.Core.Graphic.Imgui.Extras.ImPlot
{
    /// <summary>
    /// The im plot rect ptr
    /// </summary>
    public unsafe struct ImPlotRectPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImPlotRect* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImPlotRectPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImPlotRectPtr(ImPlotRect* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImPlotRectPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImPlotRectPtr(IntPtr nativePtr) => NativePtr = (ImPlotRect*)nativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImPlotRectPtr(ImPlotRect* nativePtr) => new ImPlotRectPtr(nativePtr);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImPlotRect* (ImPlotRectPtr wrappedPtr) => wrappedPtr.NativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImPlotRectPtr(IntPtr nativePtr) => new ImPlotRectPtr(nativePtr);
        /// <summary>
        /// Gets the value of the x
        /// </summary>
        public ref ImPlotRange X => ref Unsafe.AsRef<ImPlotRange>(&NativePtr->X);
        /// <summary>
        /// Gets the value of the y
        /// </summary>
        public ref ImPlotRange Y => ref Unsafe.AsRef<ImPlotRange>(&NativePtr->Y);
        /// <summary>
        /// Clamps the p
        /// </summary>
        /// <param name="p">The </param>
        /// <returns>The retval</returns>
        public ImPlotPoint Clamp(ImPlotPoint p)
        {
            ImPlotPoint retval;
            ImPlotNative.ImPlotRect_Clamp_PlotPoInt(&retval, NativePtr, p);
            return retval;
        }
        /// <summary>
        /// Clamps the x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The retval</returns>
        public ImPlotPoint Clamp(double x, double y)
        {
            ImPlotPoint retval;
            ImPlotNative.ImPlotRect_Clamp_double(&retval, NativePtr, x, y);
            return retval;
        }
        /// <summary>
        /// Describes whether this instance contains
        /// </summary>
        /// <param name="p">The </param>
        /// <returns>The bool</returns>
        public bool Contains(ImPlotPoint p)
        {
            byte ret = ImPlotNative.ImPlotRect_Contains_PlotPoInt(NativePtr, p);
            return ret != 0;
        }
        /// <summary>
        /// Describes whether this instance contains
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The bool</returns>
        public bool Contains(double x, double y)
        {
            byte ret = ImPlotNative.ImPlotRect_Contains_double(NativePtr, x, y);
            return ret != 0;
        }
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImPlotNative.ImPlotRect_destroy(NativePtr);
        }
        /// <summary>
        /// Maxes this instance
        /// </summary>
        /// <returns>The retval</returns>
        public ImPlotPoint Max()
        {
            ImPlotPoint retval;
            ImPlotNative.ImPlotRect_Max(&retval, NativePtr);
            return retval;
        }
        /// <summary>
        /// Mins this instance
        /// </summary>
        /// <returns>The retval</returns>
        public ImPlotPoint Min()
        {
            ImPlotPoint retval;
            ImPlotNative.ImPlotRect_Min(&retval, NativePtr);
            return retval;
        }
        /// <summary>
        /// Sizes this instance
        /// </summary>
        /// <returns>The retval</returns>
        public ImPlotPoint Size()
        {
            ImPlotPoint retval;
            ImPlotNative.ImPlotRect_Size(&retval, NativePtr);
            return retval;
        }
    }
}