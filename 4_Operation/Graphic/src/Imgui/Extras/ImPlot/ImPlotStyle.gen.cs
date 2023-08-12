using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui.Extras.ImPlot
{
    /// <summary>
    /// The im plot style
    /// </summary>
    public unsafe partial struct ImPlotStyle
    {
        /// <summary>
        /// The line weight
        /// </summary>
        public float LineWeight;
        /// <summary>
        /// The marker
        /// </summary>
        public int Marker;
        /// <summary>
        /// The marker size
        /// </summary>
        public float MarkerSize;
        /// <summary>
        /// The marker weight
        /// </summary>
        public float MarkerWeight;
        /// <summary>
        /// The fill alpha
        /// </summary>
        public float FillAlpha;
        /// <summary>
        /// The error bar size
        /// </summary>
        public float ErrorBarSize;
        /// <summary>
        /// The error bar weight
        /// </summary>
        public float ErrorBarWeight;
        /// <summary>
        /// The digital bit height
        /// </summary>
        public float DigitalBitHeight;
        /// <summary>
        /// The digital bit gap
        /// </summary>
        public float DigitalBitGap;
        /// <summary>
        /// The plot border size
        /// </summary>
        public float PlotBorderSize;
        /// <summary>
        /// The minor alpha
        /// </summary>
        public float MinorAlpha;
        /// <summary>
        /// The major tick len
        /// </summary>
        public Vector2 MajorTickLen;
        /// <summary>
        /// The minor tick len
        /// </summary>
        public Vector2 MinorTickLen;
        /// <summary>
        /// The major tick size
        /// </summary>
        public Vector2 MajorTickSize;
        /// <summary>
        /// The minor tick size
        /// </summary>
        public Vector2 MinorTickSize;
        /// <summary>
        /// The major grid size
        /// </summary>
        public Vector2 MajorGridSize;
        /// <summary>
        /// The minor grid size
        /// </summary>
        public Vector2 MinorGridSize;
        /// <summary>
        /// The plot padding
        /// </summary>
        public Vector2 PlotPadding;
        /// <summary>
        /// The label padding
        /// </summary>
        public Vector2 LabelPadding;
        /// <summary>
        /// The legend padding
        /// </summary>
        public Vector2 LegendPadding;
        /// <summary>
        /// The legend inner padding
        /// </summary>
        public Vector2 LegendInnerPadding;
        /// <summary>
        /// The legend spacing
        /// </summary>
        public Vector2 LegendSpacing;
        /// <summary>
        /// The mouse pos padding
        /// </summary>
        public Vector2 MousePosPadding;
        /// <summary>
        /// The annotation padding
        /// </summary>
        public Vector2 AnnotationPadding;
        /// <summary>
        /// The fit padding
        /// </summary>
        public Vector2 FitPadding;
        /// <summary>
        /// The plot default size
        /// </summary>
        public Vector2 PlotDefaultSize;
        /// <summary>
        /// The plot min size
        /// </summary>
        public Vector2 PlotMinSize;
        /// <summary>
        /// The colors
        /// </summary>
        public Vector4 Colors_0;
        /// <summary>
        /// The colors
        /// </summary>
        public Vector4 Colors_1;
        /// <summary>
        /// The colors
        /// </summary>
        public Vector4 Colors_2;
        /// <summary>
        /// The colors
        /// </summary>
        public Vector4 Colors_3;
        /// <summary>
        /// The colors
        /// </summary>
        public Vector4 Colors_4;
        /// <summary>
        /// The colors
        /// </summary>
        public Vector4 Colors_5;
        /// <summary>
        /// The colors
        /// </summary>
        public Vector4 Colors_6;
        /// <summary>
        /// The colors
        /// </summary>
        public Vector4 Colors_7;
        /// <summary>
        /// The colors
        /// </summary>
        public Vector4 Colors_8;
        /// <summary>
        /// The colors
        /// </summary>
        public Vector4 Colors_9;
        /// <summary>
        /// The colors 10
        /// </summary>
        public Vector4 Colors_10;
        /// <summary>
        /// The colors 11
        /// </summary>
        public Vector4 Colors_11;
        /// <summary>
        /// The colors 12
        /// </summary>
        public Vector4 Colors_12;
        /// <summary>
        /// The colors 13
        /// </summary>
        public Vector4 Colors_13;
        /// <summary>
        /// The colors 14
        /// </summary>
        public Vector4 Colors_14;
        /// <summary>
        /// The colors 15
        /// </summary>
        public Vector4 Colors_15;
        /// <summary>
        /// The colors 16
        /// </summary>
        public Vector4 Colors_16;
        /// <summary>
        /// The colors 17
        /// </summary>
        public Vector4 Colors_17;
        /// <summary>
        /// The colors 18
        /// </summary>
        public Vector4 Colors_18;
        /// <summary>
        /// The colors 19
        /// </summary>
        public Vector4 Colors_19;
        /// <summary>
        /// The colors 20
        /// </summary>
        public Vector4 Colors_20;
        /// <summary>
        /// The colormap
        /// </summary>
        public ImPlotColormap Colormap;
        /// <summary>
        /// The use local time
        /// </summary>
        public byte UseLocalTime;
        /// <summary>
        /// The use iso 8601
        /// </summary>
        public byte UseISO8601;
        /// <summary>
        /// The use 24 hour clock
        /// </summary>
        public byte Use24HourClock;
    }
    /// <summary>
    /// The im plot style ptr
    /// </summary>
    public unsafe partial struct ImPlotStylePtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImPlotStyle* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImPlotStylePtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImPlotStylePtr(ImPlotStyle* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImPlotStylePtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImPlotStylePtr(IntPtr nativePtr) => NativePtr = (ImPlotStyle*)nativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImPlotStylePtr(ImPlotStyle* nativePtr) => new ImPlotStylePtr(nativePtr);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImPlotStyle* (ImPlotStylePtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImPlotStylePtr(IntPtr nativePtr) => new ImPlotStylePtr(nativePtr);
        /// <summary>
        /// Gets the value of the line weight
        /// </summary>
        public ref float LineWeight => ref Unsafe.AsRef<float>(&NativePtr->LineWeight);
        /// <summary>
        /// Gets the value of the marker
        /// </summary>
        public ref int Marker => ref Unsafe.AsRef<int>(&NativePtr->Marker);
        /// <summary>
        /// Gets the value of the marker size
        /// </summary>
        public ref float MarkerSize => ref Unsafe.AsRef<float>(&NativePtr->MarkerSize);
        /// <summary>
        /// Gets the value of the marker weight
        /// </summary>
        public ref float MarkerWeight => ref Unsafe.AsRef<float>(&NativePtr->MarkerWeight);
        /// <summary>
        /// Gets the value of the fill alpha
        /// </summary>
        public ref float FillAlpha => ref Unsafe.AsRef<float>(&NativePtr->FillAlpha);
        /// <summary>
        /// Gets the value of the error bar size
        /// </summary>
        public ref float ErrorBarSize => ref Unsafe.AsRef<float>(&NativePtr->ErrorBarSize);
        /// <summary>
        /// Gets the value of the error bar weight
        /// </summary>
        public ref float ErrorBarWeight => ref Unsafe.AsRef<float>(&NativePtr->ErrorBarWeight);
        /// <summary>
        /// Gets the value of the digital bit height
        /// </summary>
        public ref float DigitalBitHeight => ref Unsafe.AsRef<float>(&NativePtr->DigitalBitHeight);
        /// <summary>
        /// Gets the value of the digital bit gap
        /// </summary>
        public ref float DigitalBitGap => ref Unsafe.AsRef<float>(&NativePtr->DigitalBitGap);
        /// <summary>
        /// Gets the value of the plot border size
        /// </summary>
        public ref float PlotBorderSize => ref Unsafe.AsRef<float>(&NativePtr->PlotBorderSize);
        /// <summary>
        /// Gets the value of the minor alpha
        /// </summary>
        public ref float MinorAlpha => ref Unsafe.AsRef<float>(&NativePtr->MinorAlpha);
        /// <summary>
        /// Gets the value of the major tick len
        /// </summary>
        public ref Vector2 MajorTickLen => ref Unsafe.AsRef<Vector2>(&NativePtr->MajorTickLen);
        /// <summary>
        /// Gets the value of the minor tick len
        /// </summary>
        public ref Vector2 MinorTickLen => ref Unsafe.AsRef<Vector2>(&NativePtr->MinorTickLen);
        /// <summary>
        /// Gets the value of the major tick size
        /// </summary>
        public ref Vector2 MajorTickSize => ref Unsafe.AsRef<Vector2>(&NativePtr->MajorTickSize);
        /// <summary>
        /// Gets the value of the minor tick size
        /// </summary>
        public ref Vector2 MinorTickSize => ref Unsafe.AsRef<Vector2>(&NativePtr->MinorTickSize);
        /// <summary>
        /// Gets the value of the major grid size
        /// </summary>
        public ref Vector2 MajorGridSize => ref Unsafe.AsRef<Vector2>(&NativePtr->MajorGridSize);
        /// <summary>
        /// Gets the value of the minor grid size
        /// </summary>
        public ref Vector2 MinorGridSize => ref Unsafe.AsRef<Vector2>(&NativePtr->MinorGridSize);
        /// <summary>
        /// Gets the value of the plot padding
        /// </summary>
        public ref Vector2 PlotPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->PlotPadding);
        /// <summary>
        /// Gets the value of the label padding
        /// </summary>
        public ref Vector2 LabelPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->LabelPadding);
        /// <summary>
        /// Gets the value of the legend padding
        /// </summary>
        public ref Vector2 LegendPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->LegendPadding);
        /// <summary>
        /// Gets the value of the legend inner padding
        /// </summary>
        public ref Vector2 LegendInnerPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->LegendInnerPadding);
        /// <summary>
        /// Gets the value of the legend spacing
        /// </summary>
        public ref Vector2 LegendSpacing => ref Unsafe.AsRef<Vector2>(&NativePtr->LegendSpacing);
        /// <summary>
        /// Gets the value of the mouse pos padding
        /// </summary>
        public ref Vector2 MousePosPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->MousePosPadding);
        /// <summary>
        /// Gets the value of the annotation padding
        /// </summary>
        public ref Vector2 AnnotationPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->AnnotationPadding);
        /// <summary>
        /// Gets the value of the fit padding
        /// </summary>
        public ref Vector2 FitPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->FitPadding);
        /// <summary>
        /// Gets the value of the plot default size
        /// </summary>
        public ref Vector2 PlotDefaultSize => ref Unsafe.AsRef<Vector2>(&NativePtr->PlotDefaultSize);
        /// <summary>
        /// Gets the value of the plot min size
        /// </summary>
        public ref Vector2 PlotMinSize => ref Unsafe.AsRef<Vector2>(&NativePtr->PlotMinSize);
        /// <summary>
        /// Gets the value of the colors
        /// </summary>
        public RangeAccessor<Vector4> Colors => new RangeAccessor<Vector4>(&NativePtr->Colors_0, 21);
        /// <summary>
        /// Gets the value of the colormap
        /// </summary>
        public ref ImPlotColormap Colormap => ref Unsafe.AsRef<ImPlotColormap>(&NativePtr->Colormap);
        /// <summary>
        /// Gets the value of the use local time
        /// </summary>
        public ref bool UseLocalTime => ref Unsafe.AsRef<bool>(&NativePtr->UseLocalTime);
        /// <summary>
        /// Gets the value of the use iso 8601
        /// </summary>
        public ref bool UseISO8601 => ref Unsafe.AsRef<bool>(&NativePtr->UseISO8601);
        /// <summary>
        /// Gets the value of the use 24 hour clock
        /// </summary>
        public ref bool Use24HourClock => ref Unsafe.AsRef<bool>(&NativePtr->Use24HourClock);
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImPlotNative.ImPlotStyle_destroy((ImPlotStyle*)(NativePtr));
        }
    }
}
