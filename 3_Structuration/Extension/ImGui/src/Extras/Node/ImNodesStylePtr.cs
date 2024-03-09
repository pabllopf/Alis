// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImNodesStylePtr.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Extension.ImGui.Utils;

namespace Alis.Core.Extension.ImGui.Extras.Node
{
    /// <summary>
    ///     The im nodes style ptr
    /// </summary>
    public unsafe struct ImNodesStylePtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImNodesStyle* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImNodesStylePtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImNodesStylePtr(ImNodesStyle* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImNodesStylePtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImNodesStylePtr(IntPtr nativePtr) => NativePtr = (ImNodesStyle*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImNodesStylePtr(ImNodesStyle* nativePtr) => new ImNodesStylePtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImNodesStyle*(ImNodesStylePtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImNodesStylePtr(IntPtr nativePtr) => new ImNodesStylePtr(nativePtr);

        /// <summary>
        ///     Gets the value of the grid spacing
        /// </summary>
        public ref float GridSpacing => ref Unsafe.AsRef<float>(&NativePtr->GridSpacing);

        /// <summary>
        ///     Gets the value of the node corner rounding
        /// </summary>
        public ref float NodeCornerRounding => ref Unsafe.AsRef<float>(&NativePtr->NodeCornerRounding);

        /// <summary>
        ///     Gets the value of the node padding
        /// </summary>
        public ref Vector2 NodePadding => ref Unsafe.AsRef<Vector2>(&NativePtr->NodePadding);

        /// <summary>
        ///     Gets the value of the node border thickness
        /// </summary>
        public ref float NodeBorderThickness => ref Unsafe.AsRef<float>(&NativePtr->NodeBorderThickness);

        /// <summary>
        ///     Gets the value of the link thickness
        /// </summary>
        public ref float LinkThickness => ref Unsafe.AsRef<float>(&NativePtr->LinkThickness);

        /// <summary>
        ///     Gets the value of the link line segments per length
        /// </summary>
        public ref float LinkLineSegmentsPerLength => ref Unsafe.AsRef<float>(&NativePtr->LinkLineSegmentsPerLength);

        /// <summary>
        ///     Gets the value of the link hover distance
        /// </summary>
        public ref float LinkHoverDistance => ref Unsafe.AsRef<float>(&NativePtr->LinkHoverDistance);

        /// <summary>
        ///     Gets the value of the pin circle radius
        /// </summary>
        public ref float PinCircleRadius => ref Unsafe.AsRef<float>(&NativePtr->PinCircleRadius);

        /// <summary>
        ///     Gets the value of the pin quad side length
        /// </summary>
        public ref float PinQuadSideLength => ref Unsafe.AsRef<float>(&NativePtr->PinQuadSideLength);

        /// <summary>
        ///     Gets the value of the pin triangle side length
        /// </summary>
        public ref float PinTriangleSideLength => ref Unsafe.AsRef<float>(&NativePtr->PinTriangleSideLength);

        /// <summary>
        ///     Gets the value of the pin line thickness
        /// </summary>
        public ref float PinLineThickness => ref Unsafe.AsRef<float>(&NativePtr->PinLineThickness);

        /// <summary>
        ///     Gets the value of the pin hover radius
        /// </summary>
        public ref float PinHoverRadius => ref Unsafe.AsRef<float>(&NativePtr->PinHoverRadius);

        /// <summary>
        ///     Gets the value of the pin offset
        /// </summary>
        public ref float PinOffset => ref Unsafe.AsRef<float>(&NativePtr->PinOffset);

        /// <summary>
        ///     Gets the value of the mini map padding
        /// </summary>
        public ref Vector2 MiniMapPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->MiniMapPadding);

        /// <summary>
        ///     Gets the value of the mini map offset
        /// </summary>
        public ref Vector2 MiniMapOffset => ref Unsafe.AsRef<Vector2>(&NativePtr->MiniMapOffset);

        /// <summary>
        ///     Gets the value of the flags
        /// </summary>
        public ref ImNodesStyleFlags Flags => ref Unsafe.AsRef<ImNodesStyleFlags>(&NativePtr->Flags);

        /// <summary>
        ///     Gets the value of the colors
        /// </summary>
        public RangeAccessor<uint> Colors => new RangeAccessor<uint>(NativePtr->Colors, 29);

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImNodesNative.ImNodesStyle_destroy(NativePtr);
        }
    }
}