// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotStylePtr.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Numerics;
using Alis.Core.Graphic.UI.Utils;

namespace Alis.Core.Graphic.UI.Extras.Plot
{
    /// <summary>
    ///     The im plot style ptr
    /// </summary>
    public unsafe struct ImPlotStylePtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImPlotStyle* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImPlotStylePtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImPlotStylePtr(ImPlotStyle* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImPlotStylePtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImPlotStylePtr(IntPtr nativePtr) => NativePtr = (ImPlotStyle*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImPlotStylePtr(ImPlotStyle* nativePtr) => new ImPlotStylePtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImPlotStyle*(ImPlotStylePtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImPlotStylePtr(IntPtr nativePtr) => new ImPlotStylePtr(nativePtr);

        /// <summary>
        ///     Gets the value of the line weight
        /// </summary>
        public ref float LineWeight => ref Unsafe.AsRef<float>(&NativePtr->LineWeight);

        /// <summary>
        ///     Gets the value of the marker
        /// </summary>
        public ref int Marker => ref Unsafe.AsRef<int>(&NativePtr->Marker);

        /// <summary>
        ///     Gets the value of the marker size
        /// </summary>
        public ref float MarkerSize => ref Unsafe.AsRef<float>(&NativePtr->MarkerSize);

        /// <summary>
        ///     Gets the value of the marker weight
        /// </summary>
        public ref float MarkerWeight => ref Unsafe.AsRef<float>(&NativePtr->MarkerWeight);

        /// <summary>
        ///     Gets the value of the fill alpha
        /// </summary>
        public ref float FillAlpha => ref Unsafe.AsRef<float>(&NativePtr->FillAlpha);

        /// <summary>
        ///     Gets the value of the error bar size
        /// </summary>
        public ref float ErrorBarSize => ref Unsafe.AsRef<float>(&NativePtr->ErrorBarSize);

        /// <summary>
        ///     Gets the value of the error bar weight
        /// </summary>
        public ref float ErrorBarWeight => ref Unsafe.AsRef<float>(&NativePtr->ErrorBarWeight);

        /// <summary>
        ///     Gets the value of the digital bit height
        /// </summary>
        public ref float DigitalBitHeight => ref Unsafe.AsRef<float>(&NativePtr->DigitalBitHeight);

        /// <summary>
        ///     Gets the value of the digital bit gap
        /// </summary>
        public ref float DigitalBitGap => ref Unsafe.AsRef<float>(&NativePtr->DigitalBitGap);

        /// <summary>
        ///     Gets the value of the plot border size
        /// </summary>
        public ref float PlotBorderSize => ref Unsafe.AsRef<float>(&NativePtr->PlotBorderSize);

        /// <summary>
        ///     Gets the value of the minor alpha
        /// </summary>
        public ref float MinorAlpha => ref Unsafe.AsRef<float>(&NativePtr->MinorAlpha);

        /// <summary>
        ///     Gets the value of the major tick len
        /// </summary>
        public ref Vector2 MajorTickLen => ref Unsafe.AsRef<Vector2>(&NativePtr->MajorTickLen);

        /// <summary>
        ///     Gets the value of the minor tick len
        /// </summary>
        public ref Vector2 MinorTickLen => ref Unsafe.AsRef<Vector2>(&NativePtr->MinorTickLen);

        /// <summary>
        ///     Gets the value of the major tick size
        /// </summary>
        public ref Vector2 MajorTickSize => ref Unsafe.AsRef<Vector2>(&NativePtr->MajorTickSize);

        /// <summary>
        ///     Gets the value of the minor tick size
        /// </summary>
        public ref Vector2 MinorTickSize => ref Unsafe.AsRef<Vector2>(&NativePtr->MinorTickSize);

        /// <summary>
        ///     Gets the value of the major grid size
        /// </summary>
        public ref Vector2 MajorGridSize => ref Unsafe.AsRef<Vector2>(&NativePtr->MajorGridSize);

        /// <summary>
        ///     Gets the value of the minor grid size
        /// </summary>
        public ref Vector2 MinorGridSize => ref Unsafe.AsRef<Vector2>(&NativePtr->MinorGridSize);

        /// <summary>
        ///     Gets the value of the plot padding
        /// </summary>
        public ref Vector2 PlotPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->PlotPadding);

        /// <summary>
        ///     Gets the value of the label padding
        /// </summary>
        public ref Vector2 LabelPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->LabelPadding);

        /// <summary>
        ///     Gets the value of the legend padding
        /// </summary>
        public ref Vector2 LegendPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->LegendPadding);

        /// <summary>
        ///     Gets the value of the legend inner padding
        /// </summary>
        public ref Vector2 LegendInnerPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->LegendInnerPadding);

        /// <summary>
        ///     Gets the value of the legend spacing
        /// </summary>
        public ref Vector2 LegendSpacing => ref Unsafe.AsRef<Vector2>(&NativePtr->LegendSpacing);

        /// <summary>
        ///     Gets the value of the mouse pos padding
        /// </summary>
        public ref Vector2 MousePosPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->MousePosPadding);

        /// <summary>
        ///     Gets the value of the annotation padding
        /// </summary>
        public ref Vector2 AnnotationPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->AnnotationPadding);

        /// <summary>
        ///     Gets the value of the fit padding
        /// </summary>
        public ref Vector2 FitPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->FitPadding);

        /// <summary>
        ///     Gets the value of the plot default size
        /// </summary>
        public ref Vector2 PlotDefaultSize => ref Unsafe.AsRef<Vector2>(&NativePtr->PlotDefaultSize);

        /// <summary>
        ///     Gets the value of the plot min size
        /// </summary>
        public ref Vector2 PlotMinSize => ref Unsafe.AsRef<Vector2>(&NativePtr->PlotMinSize);

        /// <summary>
        ///     Gets the value of the colors
        /// </summary>
        public RangeAccessor<Vector4> Colors => new RangeAccessor<Vector4>(&NativePtr->Colors0, 21);

        /// <summary>
        ///     Gets the value of the colormap
        /// </summary>
        public ref ImPlotColormap Colormap => ref Unsafe.AsRef<ImPlotColormap>(&NativePtr->Colormap);

        /// <summary>
        ///     Gets the value of the use local time
        /// </summary>
        public ref bool UseLocalTime => ref Unsafe.AsRef<bool>(&NativePtr->UseLocalTime);

        /// <summary>
        ///     Gets the value of the use iso 8601
        /// </summary>
        public ref bool UseIso8601 => ref Unsafe.AsRef<bool>(&NativePtr->UseIso8601);

        /// <summary>
        ///     Gets the value of the use 24 hour clock
        /// </summary>
        public ref bool Use24HourClock => ref Unsafe.AsRef<bool>(&NativePtr->Use24HourClock);

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImPlotNative.ImPlotStyle_destroy(NativePtr);
        }
    }
}