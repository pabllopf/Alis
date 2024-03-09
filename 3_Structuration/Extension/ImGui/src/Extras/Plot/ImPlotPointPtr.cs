// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotPointPtr.cs
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
using Alis.Core.Extension.ImGui.Utils;

namespace Alis.Core.Extension.ImGui.Extras.Plot
{
    /// <summary>
    ///     The im plot point ptr
    /// </summary>
    public unsafe struct ImPlotPointPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImPlotPoint* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImPlotPointPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImPlotPointPtr(ImPlotPoint* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImPlotPointPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImPlotPointPtr(IntPtr nativePtr) => NativePtr = (ImPlotPoint*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImPlotPointPtr(ImPlotPoint* nativePtr) => new ImPlotPointPtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImPlotPoint*(ImPlotPointPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImPlotPointPtr(IntPtr nativePtr) => new ImPlotPointPtr(nativePtr);

        /// <summary>
        ///     Gets the value of the x
        /// </summary>
        public ref double X => ref Unsafe.AsRef<double>(&NativePtr->X);

        /// <summary>
        ///     Gets the value of the y
        /// </summary>
        public ref double Y => ref Unsafe.AsRef<double>(&NativePtr->Y);

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImPlotNative.ImPlotPoint_destroy(NativePtr);
        }
    }
}