using System;
using System.Runtime.CompilerServices;
using Alis.Core.Graphic.ImGui.Utils;

namespace Alis.Core.Graphic.Imgui.Extras.ImPlot
{
    /// <summary>
    /// The im plot range
    /// </summary>
    public unsafe partial struct ImPlotRange
    {
        /// <summary>
        /// The min
        /// </summary>
        public double Min;
        /// <summary>
        /// The max
        /// </summary>
        public double Max;
    }
    /// <summary>
    /// The im plot range ptr
    /// </summary>
    public unsafe partial struct ImPlotRangePtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImPlotRange* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImPlotRangePtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImPlotRangePtr(ImPlotRange* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImPlotRangePtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImPlotRangePtr(IntPtr nativePtr) => NativePtr = (ImPlotRange*)nativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImPlotRangePtr(ImPlotRange* nativePtr) => new ImPlotRangePtr(nativePtr);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImPlotRange* (ImPlotRangePtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImPlotRangePtr(IntPtr nativePtr) => new ImPlotRangePtr(nativePtr);
        /// <summary>
        /// Gets the value of the min
        /// </summary>
        public ref double Min => ref Unsafe.AsRef<double>(&NativePtr->Min);
        /// <summary>
        /// Gets the value of the max
        /// </summary>
        public ref double Max => ref Unsafe.AsRef<double>(&NativePtr->Max);
        /// <summary>
        /// Clamps the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The ret</returns>
        public double Clamp(double value)
        {
            double ret = ImPlotNative.ImPlotRange_Clamp((ImPlotRange*)(NativePtr), value);
            return ret;
        }
        /// <summary>
        /// Describes whether this instance contains
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        public bool Contains(double value)
        {
            byte ret = ImPlotNative.ImPlotRange_Contains((ImPlotRange*)(NativePtr), value);
            return ret != 0;
        }
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImPlotNative.ImPlotRange_destroy((ImPlotRange*)(NativePtr));
        }
        /// <summary>
        /// Sizes this instance
        /// </summary>
        /// <returns>The ret</returns>
        public double Size()
        {
            double ret = ImPlotNative.ImPlotRange_Size((ImPlotRange*)(NativePtr));
            return ret;
        }
    }
}
