// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiListClipperPtr.cs
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

namespace Alis.Core.Graphic.ImGui.Structs
{
    /// <summary>
    ///     The im gui list clipper ptr
    /// </summary>
    public unsafe struct ImGuiListClipperPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImGuiListClipper* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiListClipperPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiListClipperPtr(ImGuiListClipper* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiListClipperPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiListClipperPtr(IntPtr nativePtr) => NativePtr = (ImGuiListClipper*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiListClipperPtr(ImGuiListClipper* nativePtr) => new ImGuiListClipperPtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiListClipper*(ImGuiListClipperPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiListClipperPtr(IntPtr nativePtr) => new ImGuiListClipperPtr(nativePtr);

        /// <summary>
        ///     Gets the value of the ctx
        /// </summary>
        public ref IntPtr Ctx => ref Unsafe.AsRef<IntPtr>(&NativePtr->Ctx);

        /// <summary>
        ///     Gets the value of the display start
        /// </summary>
        public ref int DisplayStart => ref Unsafe.AsRef<int>(&NativePtr->DisplayStart);

        /// <summary>
        ///     Gets the value of the display end
        /// </summary>
        public ref int DisplayEnd => ref Unsafe.AsRef<int>(&NativePtr->DisplayEnd);

        /// <summary>
        ///     Gets the value of the items count
        /// </summary>
        public ref int ItemsCount => ref Unsafe.AsRef<int>(&NativePtr->ItemsCount);

        /// <summary>
        ///     Gets the value of the items height
        /// </summary>
        public ref float ItemsHeight => ref Unsafe.AsRef<float>(&NativePtr->ItemsHeight);

        /// <summary>
        ///     Gets the value of the start pos y
        /// </summary>
        public ref float StartPosY => ref Unsafe.AsRef<float>(&NativePtr->StartPosY);

        /// <summary>
        ///     Gets or sets the value of the temp data
        /// </summary>
        public IntPtr TempData
        {
            get => (IntPtr) NativePtr->TempData;
            set => NativePtr->TempData = (void*) value;
        }

        /// <summary>
        ///     Begins the items count
        /// </summary>
        /// <param name="itemsCount">The items count</param>
        public void Begin(int itemsCount)
        {
            float itemsHeight = -1.0f;
            ImGuiNative.ImGuiListClipper_Begin(NativePtr, itemsCount, itemsHeight);
        }

        /// <summary>
        ///     Begins the items count
        /// </summary>
        /// <param name="itemsCount">The items count</param>
        /// <param name="itemsHeight">The items height</param>
        public void Begin(int itemsCount, float itemsHeight)
        {
            ImGuiNative.ImGuiListClipper_Begin(NativePtr, itemsCount, itemsHeight);
        }

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiListClipper_destroy(NativePtr);
        }

        /// <summary>
        ///     Ends this instance
        /// </summary>
        public void End()
        {
            ImGuiNative.ImGuiListClipper_End(NativePtr);
        }

        /// <summary>
        ///     Forces the display range by indices using the specified item min
        /// </summary>
        /// <param name="itemMin">The item min</param>
        /// <param name="itemMax">The item max</param>
        public void ForceDisplayRangeByIndices(int itemMin, int itemMax)
        {
            ImGuiNative.ImGuiListClipper_ForceDisplayRangeByIndices(NativePtr, itemMin, itemMax);
        }

        /// <summary>
        ///     Describes whether this instance step
        /// </summary>
        /// <returns>The bool</returns>
        public bool Step()
        {
            byte ret = ImGuiNative.ImGuiListClipper_Step(NativePtr);
            return ret != 0;
        }
    }
}