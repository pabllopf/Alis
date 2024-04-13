// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotRangePtr.cs
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
using Alis.Extension.Graphic.ImGui.Utils;

namespace Alis.Extension.Graphic.ImGui.Extras.Plot
{
    /// <summary>
    ///     The im plot range ptr
    /// </summary>
    public readonly unsafe struct ImPlotRangePtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImPlotRange* NativePtr { get; }
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="ImPlotRangePtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImPlotRangePtr(ImPlotRange* nativePtr) => NativePtr = nativePtr;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="ImPlotRangePtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImPlotRangePtr(IntPtr nativePtr) => NativePtr = (ImPlotRange*) nativePtr;
        
        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImPlotRangePtr(ImPlotRange* nativePtr) => new ImPlotRangePtr(nativePtr);
        
        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImPlotRange*(ImPlotRangePtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImPlotRangePtr(IntPtr nativePtr) => new ImPlotRangePtr(nativePtr);
        
        /// <summary>
        ///     Gets the value of the min
        /// </summary>
        public ref double Min => ref Unsafe.AsRef<double>(&NativePtr->Min);
        
        /// <summary>
        ///     Gets the value of the max
        /// </summary>
        public ref double Max => ref Unsafe.AsRef<double>(&NativePtr->Max);
        
        /// <summary>
        ///     Clamps the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The ret</returns>
        public double Clamp(double value)
        {
            double ret = ImPlotNative.ImPlotRange_Clamp(NativePtr, value);
            return ret;
        }
        
        /// <summary>
        ///     Describes whether this instance contains
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        public bool Contains(double value)
        {
            byte ret = ImPlotNative.ImPlotRange_Contains(NativePtr, value);
            return ret != 0;
        }
        
        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImPlotNative.ImPlotRange_destroy(NativePtr);
        }
        
        /// <summary>
        ///     Sizes this instance
        /// </summary>
        /// <returns>The ret</returns>
        public double Size()
        {
            double ret = ImPlotNative.ImPlotRange_Size(NativePtr);
            return ret;
        }
    }
}