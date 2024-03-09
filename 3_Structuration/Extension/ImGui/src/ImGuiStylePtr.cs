// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiStylePtr.cs
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

namespace Alis.Core.Extension.ImGui
{
    /// <summary>
    ///     The im gui style ptr
    /// </summary>
    public unsafe struct ImGuiStylePtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImGuiStyle* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiStylePtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiStylePtr(ImGuiStyle* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiStylePtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiStylePtr(IntPtr nativePtr) => NativePtr = (ImGuiStyle*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiStylePtr(ImGuiStyle* nativePtr) => new ImGuiStylePtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiStyle*(ImGuiStylePtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiStylePtr(IntPtr nativePtr) => new ImGuiStylePtr(nativePtr);

        /// <summary>
        ///     Gets the value of the alpha
        /// </summary>
        public ref float Alpha => ref Unsafe.AsRef<float>(&NativePtr->Alpha);

        /// <summary>
        ///     Gets the value of the disabled alpha
        /// </summary>
        public ref float DisabledAlpha => ref Unsafe.AsRef<float>(&NativePtr->DisabledAlpha);

        /// <summary>
        ///     Gets the value of the window padding
        /// </summary>
        public ref Vector2 WindowPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->WindowPadding);

        /// <summary>
        ///     Gets the value of the window rounding
        /// </summary>
        public ref float WindowRounding => ref Unsafe.AsRef<float>(&NativePtr->WindowRounding);

        /// <summary>
        ///     Gets the value of the window border size
        /// </summary>
        public ref float WindowBorderSize => ref Unsafe.AsRef<float>(&NativePtr->WindowBorderSize);

        /// <summary>
        ///     Gets the value of the window min size
        /// </summary>
        public ref Vector2 WindowMinSize => ref Unsafe.AsRef<Vector2>(&NativePtr->WindowMinSize);

        /// <summary>
        ///     Gets the value of the window title align
        /// </summary>
        public ref Vector2 WindowTitleAlign => ref Unsafe.AsRef<Vector2>(&NativePtr->WindowTitleAlign);

        /// <summary>
        ///     Gets the value of the window menu button position
        /// </summary>
        public ref ImGuiDir WindowMenuButtonPosition => ref Unsafe.AsRef<ImGuiDir>(&NativePtr->WindowMenuButtonPosition);

        /// <summary>
        ///     Gets the value of the child rounding
        /// </summary>
        public ref float ChildRounding => ref Unsafe.AsRef<float>(&NativePtr->ChildRounding);

        /// <summary>
        ///     Gets the value of the child border size
        /// </summary>
        public ref float ChildBorderSize => ref Unsafe.AsRef<float>(&NativePtr->ChildBorderSize);

        /// <summary>
        ///     Gets the value of the popup rounding
        /// </summary>
        public ref float PopupRounding => ref Unsafe.AsRef<float>(&NativePtr->PopupRounding);

        /// <summary>
        ///     Gets the value of the popup border size
        /// </summary>
        public ref float PopupBorderSize => ref Unsafe.AsRef<float>(&NativePtr->PopupBorderSize);

        /// <summary>
        ///     Gets the value of the frame padding
        /// </summary>
        public ref Vector2 FramePadding => ref Unsafe.AsRef<Vector2>(&NativePtr->FramePadding);

        /// <summary>
        ///     Gets the value of the frame rounding
        /// </summary>
        public ref float FrameRounding => ref Unsafe.AsRef<float>(&NativePtr->FrameRounding);

        /// <summary>
        ///     Gets the value of the frame border size
        /// </summary>
        public ref float FrameBorderSize => ref Unsafe.AsRef<float>(&NativePtr->FrameBorderSize);

        /// <summary>
        ///     Gets the value of the item spacing
        /// </summary>
        public ref Vector2 ItemSpacing => ref Unsafe.AsRef<Vector2>(&NativePtr->ItemSpacing);

        /// <summary>
        ///     Gets the value of the item inner spacing
        /// </summary>
        public ref Vector2 ItemInnerSpacing => ref Unsafe.AsRef<Vector2>(&NativePtr->ItemInnerSpacing);

        /// <summary>
        ///     Gets the value of the cell padding
        /// </summary>
        public ref Vector2 CellPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->CellPadding);

        /// <summary>
        ///     Gets the value of the touch extra padding
        /// </summary>
        public ref Vector2 TouchExtraPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->TouchExtraPadding);

        /// <summary>
        ///     Gets the value of the indent spacing
        /// </summary>
        public ref float IndentSpacing => ref Unsafe.AsRef<float>(&NativePtr->IndentSpacing);

        /// <summary>
        ///     Gets the value of the columns min spacing
        /// </summary>
        public ref float ColumnsMinSpacing => ref Unsafe.AsRef<float>(&NativePtr->ColumnsMinSpacing);

        /// <summary>
        ///     Gets the value of the scrollbar size
        /// </summary>
        public ref float ScrollbarSize => ref Unsafe.AsRef<float>(&NativePtr->ScrollbarSize);

        /// <summary>
        ///     Gets the value of the scrollbar rounding
        /// </summary>
        public ref float ScrollbarRounding => ref Unsafe.AsRef<float>(&NativePtr->ScrollbarRounding);

        /// <summary>
        ///     Gets the value of the grab min size
        /// </summary>
        public ref float GrabMinSize => ref Unsafe.AsRef<float>(&NativePtr->GrabMinSize);

        /// <summary>
        ///     Gets the value of the grab rounding
        /// </summary>
        public ref float GrabRounding => ref Unsafe.AsRef<float>(&NativePtr->GrabRounding);

        /// <summary>
        ///     Gets the value of the log slider deadzone
        /// </summary>
        public ref float LogSliderDeadzone => ref Unsafe.AsRef<float>(&NativePtr->LogSliderDeadzone);

        /// <summary>
        ///     Gets the value of the tab rounding
        /// </summary>
        public ref float TabRounding => ref Unsafe.AsRef<float>(&NativePtr->TabRounding);

        /// <summary>
        ///     Gets the value of the tab border size
        /// </summary>
        public ref float TabBorderSize => ref Unsafe.AsRef<float>(&NativePtr->TabBorderSize);

        /// <summary>
        ///     Gets the value of the tab min width for close button
        /// </summary>
        public ref float TabMinWidthForCloseButton => ref Unsafe.AsRef<float>(&NativePtr->TabMinWidthForCloseButton);

        /// <summary>
        ///     Gets the value of the color button position
        /// </summary>
        public ref ImGuiDir ColorButtonPosition => ref Unsafe.AsRef<ImGuiDir>(&NativePtr->ColorButtonPosition);

        /// <summary>
        ///     Gets the value of the button text align
        /// </summary>
        public ref Vector2 ButtonTextAlign => ref Unsafe.AsRef<Vector2>(&NativePtr->ButtonTextAlign);

        /// <summary>
        ///     Gets the value of the selectable text align
        /// </summary>
        public ref Vector2 SelectableTextAlign => ref Unsafe.AsRef<Vector2>(&NativePtr->SelectableTextAlign);

        /// <summary>
        ///     Gets the value of the display window padding
        /// </summary>
        public ref Vector2 DisplayWindowPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->DisplayWindowPadding);

        /// <summary>
        ///     Gets the value of the display safe area padding
        /// </summary>
        public ref Vector2 DisplaySafeAreaPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->DisplaySafeAreaPadding);

        /// <summary>
        ///     Gets the value of the mouse cursor scale
        /// </summary>
        public ref float MouseCursorScale => ref Unsafe.AsRef<float>(&NativePtr->MouseCursorScale);

        /// <summary>
        ///     Gets the value of the anti aliased lines
        /// </summary>
        public ref bool AntiAliasedLines => ref Unsafe.AsRef<bool>(&NativePtr->AntiAliasedLines);

        /// <summary>
        ///     Gets the value of the anti aliased lines use tex
        /// </summary>
        public ref bool AntiAliasedLinesUseTex => ref Unsafe.AsRef<bool>(&NativePtr->AntiAliasedLinesUseTex);

        /// <summary>
        ///     Gets the value of the anti aliased fill
        /// </summary>
        public ref bool AntiAliasedFill => ref Unsafe.AsRef<bool>(&NativePtr->AntiAliasedFill);

        /// <summary>
        ///     Gets the value of the curve tessellation tol
        /// </summary>
        public ref float CurveTessellationTol => ref Unsafe.AsRef<float>(&NativePtr->CurveTessellationTol);

        /// <summary>
        ///     Gets the value of the circle tessellation max error
        /// </summary>
        public ref float CircleTessellationMaxError => ref Unsafe.AsRef<float>(&NativePtr->CircleTessellationMaxError);

        /// <summary>
        ///     Gets the value of the colors
        /// </summary>
        public RangeAccessor<Vector4> Colors => new RangeAccessor<Vector4>(&NativePtr->Colors0, 55);

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiStyle_destroy(NativePtr);
        }

        /// <summary>
        ///     Scales the all sizes using the specified scale factor
        /// </summary>
        /// <param name="scaleFactor">The scale factor</param>
        public void ScaleAllSizes(float scaleFactor)
        {
            ImGuiNative.ImGuiStyle_ScaleAllSizes(NativePtr, scaleFactor);
        }
    }
}