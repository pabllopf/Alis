using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Unsafe = Alis.Core.Graphic.ImGui.ImGui.UnsafeCode.Unsafe;

namespace ImGuiNET
{
    /// <summary>
    /// The im gui style
    /// </summary>
    public unsafe partial struct ImGuiStyle
    {
        /// <summary>
        /// The alpha
        /// </summary>
        public float Alpha;
        /// <summary>
        /// The disabled alpha
        /// </summary>
        public float DisabledAlpha;
        /// <summary>
        /// The window padding
        /// </summary>
        public Vector2 WindowPadding;
        /// <summary>
        /// The window rounding
        /// </summary>
        public float WindowRounding;
        /// <summary>
        /// The window border size
        /// </summary>
        public float WindowBorderSize;
        /// <summary>
        /// The window min size
        /// </summary>
        public Vector2 WindowMinSize;
        /// <summary>
        /// The window title align
        /// </summary>
        public Vector2 WindowTitleAlign;
        /// <summary>
        /// The window menu button position
        /// </summary>
        public ImGuiDir WindowMenuButtonPosition;
        /// <summary>
        /// The child rounding
        /// </summary>
        public float ChildRounding;
        /// <summary>
        /// The child border size
        /// </summary>
        public float ChildBorderSize;
        /// <summary>
        /// The popup rounding
        /// </summary>
        public float PopupRounding;
        /// <summary>
        /// The popup border size
        /// </summary>
        public float PopupBorderSize;
        /// <summary>
        /// The frame padding
        /// </summary>
        public Vector2 FramePadding;
        /// <summary>
        /// The frame rounding
        /// </summary>
        public float FrameRounding;
        /// <summary>
        /// The frame border size
        /// </summary>
        public float FrameBorderSize;
        /// <summary>
        /// The item spacing
        /// </summary>
        public Vector2 ItemSpacing;
        /// <summary>
        /// The item inner spacing
        /// </summary>
        public Vector2 ItemInnerSpacing;
        /// <summary>
        /// The cell padding
        /// </summary>
        public Vector2 CellPadding;
        /// <summary>
        /// The touch extra padding
        /// </summary>
        public Vector2 TouchExtraPadding;
        /// <summary>
        /// The indent spacing
        /// </summary>
        public float IndentSpacing;
        /// <summary>
        /// The columns min spacing
        /// </summary>
        public float ColumnsMinSpacing;
        /// <summary>
        /// The scrollbar size
        /// </summary>
        public float ScrollbarSize;
        /// <summary>
        /// The scrollbar rounding
        /// </summary>
        public float ScrollbarRounding;
        /// <summary>
        /// The grab min size
        /// </summary>
        public float GrabMinSize;
        /// <summary>
        /// The grab rounding
        /// </summary>
        public float GrabRounding;
        /// <summary>
        /// The log slider deadzone
        /// </summary>
        public float LogSliderDeadzone;
        /// <summary>
        /// The tab rounding
        /// </summary>
        public float TabRounding;
        /// <summary>
        /// The tab border size
        /// </summary>
        public float TabBorderSize;
        /// <summary>
        /// The tab min width for close button
        /// </summary>
        public float TabMinWidthForCloseButton;
        /// <summary>
        /// The color button position
        /// </summary>
        public ImGuiDir ColorButtonPosition;
        /// <summary>
        /// The button text align
        /// </summary>
        public Vector2 ButtonTextAlign;
        /// <summary>
        /// The selectable text align
        /// </summary>
        public Vector2 SelectableTextAlign;
        /// <summary>
        /// The separator text border size
        /// </summary>
        public float SeparatorTextBorderSize;
        /// <summary>
        /// The separator text align
        /// </summary>
        public Vector2 SeparatorTextAlign;
        /// <summary>
        /// The separator text padding
        /// </summary>
        public Vector2 SeparatorTextPadding;
        /// <summary>
        /// The display window padding
        /// </summary>
        public Vector2 DisplayWindowPadding;
        /// <summary>
        /// The display safe area padding
        /// </summary>
        public Vector2 DisplaySafeAreaPadding;
        /// <summary>
        /// The mouse cursor scale
        /// </summary>
        public float MouseCursorScale;
        /// <summary>
        /// The anti aliased lines
        /// </summary>
        public byte AntiAliasedLines;
        /// <summary>
        /// The anti aliased lines use tex
        /// </summary>
        public byte AntiAliasedLinesUseTex;
        /// <summary>
        /// The anti aliased fill
        /// </summary>
        public byte AntiAliasedFill;
        /// <summary>
        /// The curve tessellation tol
        /// </summary>
        public float CurveTessellationTol;
        /// <summary>
        /// The circle tessellation max error
        /// </summary>
        public float CircleTessellationMaxError;
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
        /// The colors 21
        /// </summary>
        public Vector4 Colors_21;
        /// <summary>
        /// The colors 22
        /// </summary>
        public Vector4 Colors_22;
        /// <summary>
        /// The colors 23
        /// </summary>
        public Vector4 Colors_23;
        /// <summary>
        /// The colors 24
        /// </summary>
        public Vector4 Colors_24;
        /// <summary>
        /// The colors 25
        /// </summary>
        public Vector4 Colors_25;
        /// <summary>
        /// The colors 26
        /// </summary>
        public Vector4 Colors_26;
        /// <summary>
        /// The colors 27
        /// </summary>
        public Vector4 Colors_27;
        /// <summary>
        /// The colors 28
        /// </summary>
        public Vector4 Colors_28;
        /// <summary>
        /// The colors 29
        /// </summary>
        public Vector4 Colors_29;
        /// <summary>
        /// The colors 30
        /// </summary>
        public Vector4 Colors_30;
        /// <summary>
        /// The colors 31
        /// </summary>
        public Vector4 Colors_31;
        /// <summary>
        /// The colors 32
        /// </summary>
        public Vector4 Colors_32;
        /// <summary>
        /// The colors 33
        /// </summary>
        public Vector4 Colors_33;
        /// <summary>
        /// The colors 34
        /// </summary>
        public Vector4 Colors_34;
        /// <summary>
        /// The colors 35
        /// </summary>
        public Vector4 Colors_35;
        /// <summary>
        /// The colors 36
        /// </summary>
        public Vector4 Colors_36;
        /// <summary>
        /// The colors 37
        /// </summary>
        public Vector4 Colors_37;
        /// <summary>
        /// The colors 38
        /// </summary>
        public Vector4 Colors_38;
        /// <summary>
        /// The colors 39
        /// </summary>
        public Vector4 Colors_39;
        /// <summary>
        /// The colors 40
        /// </summary>
        public Vector4 Colors_40;
        /// <summary>
        /// The colors 41
        /// </summary>
        public Vector4 Colors_41;
        /// <summary>
        /// The colors 42
        /// </summary>
        public Vector4 Colors_42;
        /// <summary>
        /// The colors 43
        /// </summary>
        public Vector4 Colors_43;
        /// <summary>
        /// The colors 44
        /// </summary>
        public Vector4 Colors_44;
        /// <summary>
        /// The colors 45
        /// </summary>
        public Vector4 Colors_45;
        /// <summary>
        /// The colors 46
        /// </summary>
        public Vector4 Colors_46;
        /// <summary>
        /// The colors 47
        /// </summary>
        public Vector4 Colors_47;
        /// <summary>
        /// The colors 48
        /// </summary>
        public Vector4 Colors_48;
        /// <summary>
        /// The colors 49
        /// </summary>
        public Vector4 Colors_49;
        /// <summary>
        /// The colors 50
        /// </summary>
        public Vector4 Colors_50;
        /// <summary>
        /// The colors 51
        /// </summary>
        public Vector4 Colors_51;
        /// <summary>
        /// The colors 52
        /// </summary>
        public Vector4 Colors_52;
        /// <summary>
        /// The colors 53
        /// </summary>
        public Vector4 Colors_53;
        /// <summary>
        /// The colors 54
        /// </summary>
        public Vector4 Colors_54;
    }
    /// <summary>
    /// The im gui style ptr
    /// </summary>
    public unsafe partial struct ImGuiStylePtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImGuiStyle* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiStylePtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiStylePtr(ImGuiStyle* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiStylePtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiStylePtr(IntPtr nativePtr) => NativePtr = (ImGuiStyle*)nativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiStylePtr(ImGuiStyle* nativePtr) => new ImGuiStylePtr(nativePtr);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiStyle* (ImGuiStylePtr wrappedPtr) => wrappedPtr.NativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiStylePtr(IntPtr nativePtr) => new ImGuiStylePtr(nativePtr);
        /// <summary>
        /// Gets the value of the alpha
        /// </summary>
        public ref float Alpha => ref Unsafe.AsRef<float>(&NativePtr->Alpha);
        /// <summary>
        /// Gets the value of the disabled alpha
        /// </summary>
        public ref float DisabledAlpha => ref Unsafe.AsRef<float>(&NativePtr->DisabledAlpha);
        /// <summary>
        /// Gets the value of the window padding
        /// </summary>
        public ref Vector2 WindowPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->WindowPadding);
        /// <summary>
        /// Gets the value of the window rounding
        /// </summary>
        public ref float WindowRounding => ref Unsafe.AsRef<float>(&NativePtr->WindowRounding);
        /// <summary>
        /// Gets the value of the window border size
        /// </summary>
        public ref float WindowBorderSize => ref Unsafe.AsRef<float>(&NativePtr->WindowBorderSize);
        /// <summary>
        /// Gets the value of the window min size
        /// </summary>
        public ref Vector2 WindowMinSize => ref Unsafe.AsRef<Vector2>(&NativePtr->WindowMinSize);
        /// <summary>
        /// Gets the value of the window title align
        /// </summary>
        public ref Vector2 WindowTitleAlign => ref Unsafe.AsRef<Vector2>(&NativePtr->WindowTitleAlign);
        /// <summary>
        /// Gets the value of the window menu button position
        /// </summary>
        public ref ImGuiDir WindowMenuButtonPosition => ref Unsafe.AsRef<ImGuiDir>(&NativePtr->WindowMenuButtonPosition);
        /// <summary>
        /// Gets the value of the child rounding
        /// </summary>
        public ref float ChildRounding => ref Unsafe.AsRef<float>(&NativePtr->ChildRounding);
        /// <summary>
        /// Gets the value of the child border size
        /// </summary>
        public ref float ChildBorderSize => ref Unsafe.AsRef<float>(&NativePtr->ChildBorderSize);
        /// <summary>
        /// Gets the value of the popup rounding
        /// </summary>
        public ref float PopupRounding => ref Unsafe.AsRef<float>(&NativePtr->PopupRounding);
        /// <summary>
        /// Gets the value of the popup border size
        /// </summary>
        public ref float PopupBorderSize => ref Unsafe.AsRef<float>(&NativePtr->PopupBorderSize);
        /// <summary>
        /// Gets the value of the frame padding
        /// </summary>
        public ref Vector2 FramePadding => ref Unsafe.AsRef<Vector2>(&NativePtr->FramePadding);
        /// <summary>
        /// Gets the value of the frame rounding
        /// </summary>
        public ref float FrameRounding => ref Unsafe.AsRef<float>(&NativePtr->FrameRounding);
        /// <summary>
        /// Gets the value of the frame border size
        /// </summary>
        public ref float FrameBorderSize => ref Unsafe.AsRef<float>(&NativePtr->FrameBorderSize);
        /// <summary>
        /// Gets the value of the item spacing
        /// </summary>
        public ref Vector2 ItemSpacing => ref Unsafe.AsRef<Vector2>(&NativePtr->ItemSpacing);
        /// <summary>
        /// Gets the value of the item inner spacing
        /// </summary>
        public ref Vector2 ItemInnerSpacing => ref Unsafe.AsRef<Vector2>(&NativePtr->ItemInnerSpacing);
        /// <summary>
        /// Gets the value of the cell padding
        /// </summary>
        public ref Vector2 CellPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->CellPadding);
        /// <summary>
        /// Gets the value of the touch extra padding
        /// </summary>
        public ref Vector2 TouchExtraPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->TouchExtraPadding);
        /// <summary>
        /// Gets the value of the indent spacing
        /// </summary>
        public ref float IndentSpacing => ref Unsafe.AsRef<float>(&NativePtr->IndentSpacing);
        /// <summary>
        /// Gets the value of the columns min spacing
        /// </summary>
        public ref float ColumnsMinSpacing => ref Unsafe.AsRef<float>(&NativePtr->ColumnsMinSpacing);
        /// <summary>
        /// Gets the value of the scrollbar size
        /// </summary>
        public ref float ScrollbarSize => ref Unsafe.AsRef<float>(&NativePtr->ScrollbarSize);
        /// <summary>
        /// Gets the value of the scrollbar rounding
        /// </summary>
        public ref float ScrollbarRounding => ref Unsafe.AsRef<float>(&NativePtr->ScrollbarRounding);
        /// <summary>
        /// Gets the value of the grab min size
        /// </summary>
        public ref float GrabMinSize => ref Unsafe.AsRef<float>(&NativePtr->GrabMinSize);
        /// <summary>
        /// Gets the value of the grab rounding
        /// </summary>
        public ref float GrabRounding => ref Unsafe.AsRef<float>(&NativePtr->GrabRounding);
        /// <summary>
        /// Gets the value of the log slider deadzone
        /// </summary>
        public ref float LogSliderDeadzone => ref Unsafe.AsRef<float>(&NativePtr->LogSliderDeadzone);
        /// <summary>
        /// Gets the value of the tab rounding
        /// </summary>
        public ref float TabRounding => ref Unsafe.AsRef<float>(&NativePtr->TabRounding);
        /// <summary>
        /// Gets the value of the tab border size
        /// </summary>
        public ref float TabBorderSize => ref Unsafe.AsRef<float>(&NativePtr->TabBorderSize);
        /// <summary>
        /// Gets the value of the tab min width for close button
        /// </summary>
        public ref float TabMinWidthForCloseButton => ref Unsafe.AsRef<float>(&NativePtr->TabMinWidthForCloseButton);
        /// <summary>
        /// Gets the value of the color button position
        /// </summary>
        public ref ImGuiDir ColorButtonPosition => ref Unsafe.AsRef<ImGuiDir>(&NativePtr->ColorButtonPosition);
        /// <summary>
        /// Gets the value of the button text align
        /// </summary>
        public ref Vector2 ButtonTextAlign => ref Unsafe.AsRef<Vector2>(&NativePtr->ButtonTextAlign);
        /// <summary>
        /// Gets the value of the selectable text align
        /// </summary>
        public ref Vector2 SelectableTextAlign => ref Unsafe.AsRef<Vector2>(&NativePtr->SelectableTextAlign);
        /// <summary>
        /// Gets the value of the separator text border size
        /// </summary>
        public ref float SeparatorTextBorderSize => ref Unsafe.AsRef<float>(&NativePtr->SeparatorTextBorderSize);
        /// <summary>
        /// Gets the value of the separator text align
        /// </summary>
        public ref Vector2 SeparatorTextAlign => ref Unsafe.AsRef<Vector2>(&NativePtr->SeparatorTextAlign);
        /// <summary>
        /// Gets the value of the separator text padding
        /// </summary>
        public ref Vector2 SeparatorTextPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->SeparatorTextPadding);
        /// <summary>
        /// Gets the value of the display window padding
        /// </summary>
        public ref Vector2 DisplayWindowPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->DisplayWindowPadding);
        /// <summary>
        /// Gets the value of the display safe area padding
        /// </summary>
        public ref Vector2 DisplaySafeAreaPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->DisplaySafeAreaPadding);
        /// <summary>
        /// Gets the value of the mouse cursor scale
        /// </summary>
        public ref float MouseCursorScale => ref Unsafe.AsRef<float>(&NativePtr->MouseCursorScale);
        /// <summary>
        /// Gets the value of the anti aliased lines
        /// </summary>
        public ref bool AntiAliasedLines => ref Unsafe.AsRef<bool>(&NativePtr->AntiAliasedLines);
        /// <summary>
        /// Gets the value of the anti aliased lines use tex
        /// </summary>
        public ref bool AntiAliasedLinesUseTex => ref Unsafe.AsRef<bool>(&NativePtr->AntiAliasedLinesUseTex);
        /// <summary>
        /// Gets the value of the anti aliased fill
        /// </summary>
        public ref bool AntiAliasedFill => ref Unsafe.AsRef<bool>(&NativePtr->AntiAliasedFill);
        /// <summary>
        /// Gets the value of the curve tessellation tol
        /// </summary>
        public ref float CurveTessellationTol => ref Unsafe.AsRef<float>(&NativePtr->CurveTessellationTol);
        /// <summary>
        /// Gets the value of the circle tessellation max error
        /// </summary>
        public ref float CircleTessellationMaxError => ref Unsafe.AsRef<float>(&NativePtr->CircleTessellationMaxError);
        /// <summary>
        /// Gets the value of the colors
        /// </summary>
        public RangeAccessor<Vector4> Colors => new RangeAccessor<Vector4>(&NativePtr->Colors_0, 55);
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiStyle_destroy((ImGuiStyle*)(NativePtr));
        }
        /// <summary>
        /// Scales the all sizes using the specified scale factor
        /// </summary>
        /// <param name="scale_factor">The scale factor</param>
        public void ScaleAllSizes(float scale_factor)
        {
            ImGuiNative.ImGuiStyle_ScaleAllSizes((ImGuiStyle*)(NativePtr), scale_factor);
        }
    }
}
