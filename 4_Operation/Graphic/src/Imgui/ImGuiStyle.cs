using System.Numerics;
using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im gui style
    /// </summary>
    public struct ImGuiStyle
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
}
