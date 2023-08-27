// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotInputMapPtr.cs
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
using Alis.Core.Graphic.ImGui.Utils;

namespace Alis.Core.Graphic.Imgui.Extras.ImPlot
{
    /// <summary>
    ///     The im plot input map ptr
    /// </summary>
    public unsafe struct ImPlotInputMapPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImPlotInputMap* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImPlotInputMapPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImPlotInputMapPtr(ImPlotInputMap* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImPlotInputMapPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImPlotInputMapPtr(IntPtr nativePtr) => NativePtr = (ImPlotInputMap*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImPlotInputMapPtr(ImPlotInputMap* nativePtr) => new ImPlotInputMapPtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImPlotInputMap*(ImPlotInputMapPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImPlotInputMapPtr(IntPtr nativePtr) => new ImPlotInputMapPtr(nativePtr);

        /// <summary>
        ///     Gets the value of the pan
        /// </summary>
        public ref ImGuiMouseButton Pan => ref Unsafe.AsRef<ImGuiMouseButton>(&NativePtr->Pan);

        /// <summary>
        ///     Gets the value of the pan mod
        /// </summary>
        public ref ImGuiModFlags PanMod => ref Unsafe.AsRef<ImGuiModFlags>(&NativePtr->PanMod);

        /// <summary>
        ///     Gets the value of the fit
        /// </summary>
        public ref ImGuiMouseButton Fit => ref Unsafe.AsRef<ImGuiMouseButton>(&NativePtr->Fit);

        /// <summary>
        ///     Gets the value of the select
        /// </summary>
        public ref ImGuiMouseButton Select => ref Unsafe.AsRef<ImGuiMouseButton>(&NativePtr->Select);

        /// <summary>
        ///     Gets the value of the select cancel
        /// </summary>
        public ref ImGuiMouseButton SelectCancel => ref Unsafe.AsRef<ImGuiMouseButton>(&NativePtr->SelectCancel);

        /// <summary>
        ///     Gets the value of the select mod
        /// </summary>
        public ref ImGuiModFlags SelectMod => ref Unsafe.AsRef<ImGuiModFlags>(&NativePtr->SelectMod);

        /// <summary>
        ///     Gets the value of the select horz mod
        /// </summary>
        public ref ImGuiModFlags SelectHorzMod => ref Unsafe.AsRef<ImGuiModFlags>(&NativePtr->SelectHorzMod);

        /// <summary>
        ///     Gets the value of the select vert mod
        /// </summary>
        public ref ImGuiModFlags SelectVertMod => ref Unsafe.AsRef<ImGuiModFlags>(&NativePtr->SelectVertMod);

        /// <summary>
        ///     Gets the value of the menu
        /// </summary>
        public ref ImGuiMouseButton Menu => ref Unsafe.AsRef<ImGuiMouseButton>(&NativePtr->Menu);

        /// <summary>
        ///     Gets the value of the override mod
        /// </summary>
        public ref ImGuiModFlags OverrideMod => ref Unsafe.AsRef<ImGuiModFlags>(&NativePtr->OverrideMod);

        /// <summary>
        ///     Gets the value of the zoom mod
        /// </summary>
        public ref ImGuiModFlags ZoomMod => ref Unsafe.AsRef<ImGuiModFlags>(&NativePtr->ZoomMod);

        /// <summary>
        ///     Gets the value of the zoom rate
        /// </summary>
        public ref float ZoomRate => ref Unsafe.AsRef<float>(&NativePtr->ZoomRate);

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImPlotNative.ImPlotInputMap_destroy(NativePtr);
        }
    }
}