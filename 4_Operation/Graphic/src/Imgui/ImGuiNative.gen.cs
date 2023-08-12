using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im gui native class
    /// </summary>
    public static unsafe partial class ImGuiNative
    {
        /// <summary>
        /// Igs the accept drag drop payload using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="flags">The flags</param>
        /// <returns>The im gui payload</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiPayload* igAcceptDragDropPayload(byte* type, ImGuiDragDropFlags flags);
        /// <summary>
        /// Igs the align text to frame padding
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igAlignTextToFramePadding();
        /// <summary>
        /// Igs the arrow button using the specified str id
        /// </summary>
        /// <param name="str_id">The str id</param>
        /// <param name="dir">The dir</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igArrowButton(byte* str_id, ImGuiDir dir);
        /// <summary>
        /// Igs the begin using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="p_open">The open</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igBegin(byte* name, byte* p_open, ImGuiWindowFlags flags);
        /// <summary>
        /// Igs the begin child str using the specified str id
        /// </summary>
        /// <param name="str_id">The str id</param>
        /// <param name="size">The size</param>
        /// <param name="border">The border</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igBeginChild_Str(byte* str_id, Vector2 size, byte border, ImGuiWindowFlags flags);
        /// <summary>
        /// Igs the begin child id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <param name="border">The border</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igBeginChild_ID(uint id, Vector2 size, byte border, ImGuiWindowFlags flags);
        /// <summary>
        /// Igs the begin child frame using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igBeginChildFrame(uint id, Vector2 size, ImGuiWindowFlags flags);
        /// <summary>
        /// Igs the begin combo using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="preview_value">The preview value</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igBeginCombo(byte* label, byte* preview_value, ImGuiComboFlags flags);
        /// <summary>
        /// Igs the begin disabled using the specified disabled
        /// </summary>
        /// <param name="disabled">The disabled</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igBeginDisabled(byte disabled);
        /// <summary>
        /// Igs the begin drag drop source using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igBeginDragDropSource(ImGuiDragDropFlags flags);
        /// <summary>
        /// Igs the begin drag drop target
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igBeginDragDropTarget();
        /// <summary>
        /// Igs the begin group
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igBeginGroup();
        /// <summary>
        /// Igs the begin list box using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igBeginListBox(byte* label, Vector2 size);
        /// <summary>
        /// Igs the begin main menu bar
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igBeginMainMenuBar();
        /// <summary>
        /// Igs the begin menu using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igBeginMenu(byte* label, byte enabled);
        /// <summary>
        /// Igs the begin menu bar
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igBeginMenuBar();
        /// <summary>
        /// Igs the begin popup using the specified str id
        /// </summary>
        /// <param name="str_id">The str id</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igBeginPopup(byte* str_id, ImGuiWindowFlags flags);
        /// <summary>
        /// Igs the begin popup context item using the specified str id
        /// </summary>
        /// <param name="str_id">The str id</param>
        /// <param name="popup_flags">The popup flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igBeginPopupContextItem(byte* str_id, ImGuiPopupFlags popup_flags);
        /// <summary>
        /// Igs the begin popup context void using the specified str id
        /// </summary>
        /// <param name="str_id">The str id</param>
        /// <param name="popup_flags">The popup flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igBeginPopupContextVoid(byte* str_id, ImGuiPopupFlags popup_flags);
        /// <summary>
        /// Igs the begin popup context window using the specified str id
        /// </summary>
        /// <param name="str_id">The str id</param>
        /// <param name="popup_flags">The popup flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igBeginPopupContextWindow(byte* str_id, ImGuiPopupFlags popup_flags);
        /// <summary>
        /// Igs the begin popup modal using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="p_open">The open</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igBeginPopupModal(byte* name, byte* p_open, ImGuiWindowFlags flags);
        /// <summary>
        /// Igs the begin tab bar using the specified str id
        /// </summary>
        /// <param name="str_id">The str id</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igBeginTabBar(byte* str_id, ImGuiTabBarFlags flags);
        /// <summary>
        /// Igs the begin tab item using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="p_open">The open</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igBeginTabItem(byte* label, byte* p_open, ImGuiTabItemFlags flags);
        /// <summary>
        /// Igs the begin table using the specified str id
        /// </summary>
        /// <param name="str_id">The str id</param>
        /// <param name="column">The column</param>
        /// <param name="flags">The flags</param>
        /// <param name="outer_size">The outer size</param>
        /// <param name="inner_width">The inner width</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igBeginTable(byte* str_id, int column, ImGuiTableFlags flags, Vector2 outer_size, float inner_width);
        /// <summary>
        /// Igs the begin tooltip
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igBeginTooltip();
        /// <summary>
        /// Igs the bullet
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igBullet();
        /// <summary>
        /// Igs the bullet text using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igBulletText(byte* fmt);
        /// <summary>
        /// Igs the button using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igButton(byte* label, Vector2 size);
        /// <summary>
        /// Igs the calc item width
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern float igCalcItemWidth();
        /// <summary>
        /// Igs the calc text size using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="text">The text</param>
        /// <param name="text_end">The text end</param>
        /// <param name="hide_text_after_double_hash">The hide text after double hash</param>
        /// <param name="wrap_width">The wrap width</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igCalcTextSize(Vector2* pOut, byte* text, byte* text_end, byte hide_text_after_double_hash, float wrap_width);
        /// <summary>
        /// Igs the checkbox using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igCheckbox(byte* label, byte* v);
        /// <summary>
        /// Igs the checkbox flags int ptr using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <param name="flags_value">The flags value</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igCheckboxFlags_IntPtr(byte* label, int* flags, int flags_value);
        /// <summary>
        /// Igs the checkbox flags uint ptr using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <param name="flags_value">The flags value</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igCheckboxFlags_UintPtr(byte* label, uint* flags, uint flags_value);
        /// <summary>
        /// Igs the close current popup
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igCloseCurrentPopup();
        /// <summary>
        /// Igs the collapsing header tree node flags using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igCollapsingHeader_TreeNodeFlags(byte* label, ImGuiTreeNodeFlags flags);
        /// <summary>
        /// Igs the collapsing header bool ptr using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="p_visible">The visible</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igCollapsingHeader_BoolPtr(byte* label, byte* p_visible, ImGuiTreeNodeFlags flags);
        /// <summary>
        /// Igs the color button using the specified desc id
        /// </summary>
        /// <param name="desc_id">The desc id</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <param name="size">The size</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igColorButton(byte* desc_id, Vector4 col, ImGuiColorEditFlags flags, Vector2 size);
        /// <summary>
        /// Igs the color convert float 4 to u 32 using the specified in
        /// </summary>
        /// <param name="in">The in</param>
        /// <returns>The uint</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint igColorConvertFloat4ToU32(Vector4 @in);
        /// <summary>
        /// Igs the color convert hs vto rgb using the specified h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        /// <param name="out_r">The out</param>
        /// <param name="out_g">The out</param>
        /// <param name="out_b">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igColorConvertHSVtoRGB(float h, float s, float v, float* out_r, float* out_g, float* out_b);
        /// <summary>
        /// Igs the color convert rg bto hsv using the specified r
        /// </summary>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="out_h">The out</param>
        /// <param name="out_s">The out</param>
        /// <param name="out_v">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igColorConvertRGBtoHSV(float r, float g, float b, float* out_h, float* out_s, float* out_v);
        /// <summary>
        /// Igs the color convert u 32 to float 4 using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="in">The in</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igColorConvertU32ToFloat4(Vector4* pOut, uint @in);
        /// <summary>
        /// Igs the color edit 3 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igColorEdit3(byte* label, Vector3* col, ImGuiColorEditFlags flags);
        /// <summary>
        /// Igs the color edit 4 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igColorEdit4(byte* label, Vector4* col, ImGuiColorEditFlags flags);
        /// <summary>
        /// Igs the color picker 3 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igColorPicker3(byte* label, Vector3* col, ImGuiColorEditFlags flags);
        /// <summary>
        /// Igs the color picker 4 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <param name="ref_col">The ref col</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igColorPicker4(byte* label, Vector4* col, ImGuiColorEditFlags flags, float* ref_col);
        /// <summary>
        /// Igs the columns using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        /// <param name="id">The id</param>
        /// <param name="border">The border</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igColumns(int count, byte* id, byte border);
        /// <summary>
        /// Igs the combo str arr using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="current_item">The current item</param>
        /// <param name="items">The items</param>
        /// <param name="items_count">The items count</param>
        /// <param name="popup_max_height_in_items">The popup max height in items</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igCombo_Str_arr(byte* label, int* current_item, byte** items, int items_count, int popup_max_height_in_items);
        /// <summary>
        /// Igs the combo str using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="current_item">The current item</param>
        /// <param name="items_separated_by_zeros">The items separated by zeros</param>
        /// <param name="popup_max_height_in_items">The popup max height in items</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igCombo_Str(byte* label, int* current_item, byte* items_separated_by_zeros, int popup_max_height_in_items);
        /// <summary>
        /// Igs the create context using the specified shared font atlas
        /// </summary>
        /// <param name="shared_font_atlas">The shared font atlas</param>
        /// <returns>The int ptr</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr igCreateContext(ImFontAtlas* shared_font_atlas);
        /// <summary>
        /// Igs the debug check version and data layout using the specified version str
        /// </summary>
        /// <param name="version_str">The version str</param>
        /// <param name="sz_io">The sz io</param>
        /// <param name="sz_style">The sz style</param>
        /// <param name="sz_vec2">The sz vec2</param>
        /// <param name="sz_vec4">The sz vec4</param>
        /// <param name="sz_drawvert">The sz drawvert</param>
        /// <param name="sz_drawidx">The sz drawidx</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igDebugCheckVersionAndDataLayout(byte* version_str, uint sz_io, uint sz_style, uint sz_vec2, uint sz_vec4, uint sz_drawvert, uint sz_drawidx);
        /// <summary>
        /// Igs the debug text encoding using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igDebugTextEncoding(byte* text);
        /// <summary>
        /// Igs the destroy context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igDestroyContext(IntPtr ctx);
        /// <summary>
        /// Igs the destroy platform windows
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igDestroyPlatformWindows();
        /// <summary>
        /// Igs the dock space using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <param name="window_class">The window class</param>
        /// <returns>The uint</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint igDockSpace(uint id, Vector2 size, ImGuiDockNodeFlags flags, ImGuiWindowClass* window_class);
        /// <summary>
        /// Igs the dock space over viewport using the specified viewport
        /// </summary>
        /// <param name="viewport">The viewport</param>
        /// <param name="flags">The flags</param>
        /// <param name="window_class">The window class</param>
        /// <returns>The uint</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint igDockSpaceOverViewport(ImGuiViewport* viewport, ImGuiDockNodeFlags flags, ImGuiWindowClass* window_class);
        /// <summary>
        /// Igs the drag float using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="v_speed">The speed</param>
        /// <param name="v_min">The min</param>
        /// <param name="v_max">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igDragFloat(byte* label, float* v, float v_speed, float v_min, float v_max, byte* format, ImGuiSliderFlags flags);
        /// <summary>
        /// Igs the drag float 2 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="v_speed">The speed</param>
        /// <param name="v_min">The min</param>
        /// <param name="v_max">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igDragFloat2(byte* label, Vector2* v, float v_speed, float v_min, float v_max, byte* format, ImGuiSliderFlags flags);
        /// <summary>
        /// Igs the drag float 3 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="v_speed">The speed</param>
        /// <param name="v_min">The min</param>
        /// <param name="v_max">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igDragFloat3(byte* label, Vector3* v, float v_speed, float v_min, float v_max, byte* format, ImGuiSliderFlags flags);
        /// <summary>
        /// Igs the drag float 4 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="v_speed">The speed</param>
        /// <param name="v_min">The min</param>
        /// <param name="v_max">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igDragFloat4(byte* label, Vector4* v, float v_speed, float v_min, float v_max, byte* format, ImGuiSliderFlags flags);
        /// <summary>
        /// Igs the drag float range 2 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v_current_min">The current min</param>
        /// <param name="v_current_max">The current max</param>
        /// <param name="v_speed">The speed</param>
        /// <param name="v_min">The min</param>
        /// <param name="v_max">The max</param>
        /// <param name="format">The format</param>
        /// <param name="format_max">The format max</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igDragFloatRange2(byte* label, float* v_current_min, float* v_current_max, float v_speed, float v_min, float v_max, byte* format, byte* format_max, ImGuiSliderFlags flags);
        /// <summary>
        /// Igs the drag int using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="v_speed">The speed</param>
        /// <param name="v_min">The min</param>
        /// <param name="v_max">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igDragInt(byte* label, int* v, float v_speed, int v_min, int v_max, byte* format, ImGuiSliderFlags flags);
        /// <summary>
        /// Igs the drag int 2 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="v_speed">The speed</param>
        /// <param name="v_min">The min</param>
        /// <param name="v_max">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igDragInt2(byte* label, int* v, float v_speed, int v_min, int v_max, byte* format, ImGuiSliderFlags flags);
        /// <summary>
        /// Igs the drag int 3 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="v_speed">The speed</param>
        /// <param name="v_min">The min</param>
        /// <param name="v_max">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igDragInt3(byte* label, int* v, float v_speed, int v_min, int v_max, byte* format, ImGuiSliderFlags flags);
        /// <summary>
        /// Igs the drag int 4 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="v_speed">The speed</param>
        /// <param name="v_min">The min</param>
        /// <param name="v_max">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igDragInt4(byte* label, int* v, float v_speed, int v_min, int v_max, byte* format, ImGuiSliderFlags flags);
        /// <summary>
        /// Igs the drag int range 2 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v_current_min">The current min</param>
        /// <param name="v_current_max">The current max</param>
        /// <param name="v_speed">The speed</param>
        /// <param name="v_min">The min</param>
        /// <param name="v_max">The max</param>
        /// <param name="format">The format</param>
        /// <param name="format_max">The format max</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igDragIntRange2(byte* label, int* v_current_min, int* v_current_max, float v_speed, int v_min, int v_max, byte* format, byte* format_max, ImGuiSliderFlags flags);
        /// <summary>
        /// Igs the drag scalar using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="data_type">The data type</param>
        /// <param name="p_data">The data</param>
        /// <param name="v_speed">The speed</param>
        /// <param name="p_min">The min</param>
        /// <param name="p_max">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igDragScalar(byte* label, ImGuiDataType data_type, void* p_data, float v_speed, void* p_min, void* p_max, byte* format, ImGuiSliderFlags flags);
        /// <summary>
        /// Igs the drag scalar n using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="data_type">The data type</param>
        /// <param name="p_data">The data</param>
        /// <param name="components">The components</param>
        /// <param name="v_speed">The speed</param>
        /// <param name="p_min">The min</param>
        /// <param name="p_max">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igDragScalarN(byte* label, ImGuiDataType data_type, void* p_data, int components, float v_speed, void* p_min, void* p_max, byte* format, ImGuiSliderFlags flags);
        /// <summary>
        /// Igs the dummy using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igDummy(Vector2 size);
        /// <summary>
        /// Igs the end
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igEnd();
        /// <summary>
        /// Igs the end child
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igEndChild();
        /// <summary>
        /// Igs the end child frame
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igEndChildFrame();
        /// <summary>
        /// Igs the end combo
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igEndCombo();
        /// <summary>
        /// Igs the end disabled
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igEndDisabled();
        /// <summary>
        /// Igs the end drag drop source
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igEndDragDropSource();
        /// <summary>
        /// Igs the end drag drop target
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igEndDragDropTarget();
        /// <summary>
        /// Igs the end frame
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igEndFrame();
        /// <summary>
        /// Igs the end group
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igEndGroup();
        /// <summary>
        /// Igs the end list box
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igEndListBox();
        /// <summary>
        /// Igs the end main menu bar
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igEndMainMenuBar();
        /// <summary>
        /// Igs the end menu
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igEndMenu();
        /// <summary>
        /// Igs the end menu bar
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igEndMenuBar();
        /// <summary>
        /// Igs the end popup
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igEndPopup();
        /// <summary>
        /// Igs the end tab bar
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igEndTabBar();
        /// <summary>
        /// Igs the end tab item
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igEndTabItem();
        /// <summary>
        /// Igs the end table
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igEndTable();
        /// <summary>
        /// Igs the end tooltip
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igEndTooltip();
        /// <summary>
        /// Igs the find viewport by id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The im gui viewport</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiViewport* igFindViewportByID(uint id);
        /// <summary>
        /// Igs the find viewport by platform handle using the specified platform handle
        /// </summary>
        /// <param name="platform_handle">The platform handle</param>
        /// <returns>The im gui viewport</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiViewport* igFindViewportByPlatformHandle(void* platform_handle);
        /// <summary>
        /// Igs the get allocator functions using the specified p alloc func
        /// </summary>
        /// <param name="p_alloc_func">The alloc func</param>
        /// <param name="p_free_func">The free func</param>
        /// <param name="p_user_data">The user data</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igGetAllocatorFunctions(IntPtr* p_alloc_func, IntPtr* p_free_func, void** p_user_data);
        /// <summary>
        /// Igs the get background draw list nil
        /// </summary>
        /// <returns>The im draw list</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImDrawList* igGetBackgroundDrawList_Nil();
        /// <summary>
        /// Igs the get background draw list viewport ptr using the specified viewport
        /// </summary>
        /// <param name="viewport">The viewport</param>
        /// <returns>The im draw list</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImDrawList* igGetBackgroundDrawList_ViewportPtr(ImGuiViewport* viewport);
        /// <summary>
        /// Igs the get clipboard text
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* igGetClipboardText();
        /// <summary>
        /// Igs the get color u 32 col using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="alpha_mul">The alpha mul</param>
        /// <returns>The uint</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint igGetColorU32_Col(ImGuiCol idx, float alpha_mul);
        /// <summary>
        /// Igs the get color u 32 vec 4 using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <returns>The uint</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint igGetColorU32_Vec4(Vector4 col);
        /// <summary>
        /// Igs the get color u 32 u 32 using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <returns>The uint</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint igGetColorU32_U32(uint col);
        /// <summary>
        /// Igs the get column index
        /// </summary>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern int igGetColumnIndex();
        /// <summary>
        /// Igs the get column offset using the specified column index
        /// </summary>
        /// <param name="column_index">The column index</param>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern float igGetColumnOffset(int column_index);
        /// <summary>
        /// Igs the get columns count
        /// </summary>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern int igGetColumnsCount();
        /// <summary>
        /// Igs the get column width using the specified column index
        /// </summary>
        /// <param name="column_index">The column index</param>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern float igGetColumnWidth(int column_index);
        /// <summary>
        /// Igs the get content region avail using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igGetContentRegionAvail(Vector2* pOut);
        /// <summary>
        /// Igs the get content region max using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igGetContentRegionMax(Vector2* pOut);
        /// <summary>
        /// Igs the get current context
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr igGetCurrentContext();
        /// <summary>
        /// Igs the get cursor pos using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igGetCursorPos(Vector2* pOut);
        /// <summary>
        /// Igs the get cursor pos x
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern float igGetCursorPosX();
        /// <summary>
        /// Igs the get cursor pos y
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern float igGetCursorPosY();
        /// <summary>
        /// Igs the get cursor screen pos using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igGetCursorScreenPos(Vector2* pOut);
        /// <summary>
        /// Igs the get cursor start pos using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igGetCursorStartPos(Vector2* pOut);
        /// <summary>
        /// Igs the get drag drop payload
        /// </summary>
        /// <returns>The im gui payload</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiPayload* igGetDragDropPayload();
        /// <summary>
        /// Igs the get draw data
        /// </summary>
        /// <returns>The im draw data</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImDrawData* igGetDrawData();
        /// <summary>
        /// Igs the get draw list shared data
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr igGetDrawListSharedData();
        /// <summary>
        /// Igs the get font
        /// </summary>
        /// <returns>The im font</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImFont* igGetFont();
        /// <summary>
        /// Igs the get font size
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern float igGetFontSize();
        /// <summary>
        /// Igs the get font tex uv white pixel using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igGetFontTexUvWhitePixel(Vector2* pOut);
        /// <summary>
        /// Igs the get foreground draw list nil
        /// </summary>
        /// <returns>The im draw list</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImDrawList* igGetForegroundDrawList_Nil();
        /// <summary>
        /// Igs the get foreground draw list viewport ptr using the specified viewport
        /// </summary>
        /// <param name="viewport">The viewport</param>
        /// <returns>The im draw list</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImDrawList* igGetForegroundDrawList_ViewportPtr(ImGuiViewport* viewport);
        /// <summary>
        /// Igs the get frame count
        /// </summary>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern int igGetFrameCount();
        /// <summary>
        /// Igs the get frame height
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern float igGetFrameHeight();
        /// <summary>
        /// Igs the get frame height with spacing
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern float igGetFrameHeightWithSpacing();
        /// <summary>
        /// Igs the get id str using the specified str id
        /// </summary>
        /// <param name="str_id">The str id</param>
        /// <returns>The uint</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint igGetID_Str(byte* str_id);
        /// <summary>
        /// Igs the get id str str using the specified str id begin
        /// </summary>
        /// <param name="str_id_begin">The str id begin</param>
        /// <param name="str_id_end">The str id end</param>
        /// <returns>The uint</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint igGetID_StrStr(byte* str_id_begin, byte* str_id_end);
        /// <summary>
        /// Igs the get id ptr using the specified ptr id
        /// </summary>
        /// <param name="ptr_id">The ptr id</param>
        /// <returns>The uint</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint igGetID_Ptr(void* ptr_id);
        /// <summary>
        /// Igs the get io
        /// </summary>
        /// <returns>The im gui io</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiIO* igGetIO();
        /// <summary>
        /// Igs the get item rect max using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igGetItemRectMax(Vector2* pOut);
        /// <summary>
        /// Igs the get item rect min using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igGetItemRectMin(Vector2* pOut);
        /// <summary>
        /// Igs the get item rect size using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igGetItemRectSize(Vector2* pOut);
        /// <summary>
        /// Igs the get key index using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The im gui key</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiKey igGetKeyIndex(ImGuiKey key);
        /// <summary>
        /// Igs the get key name using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* igGetKeyName(ImGuiKey key);
        /// <summary>
        /// Igs the get key pressed amount using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="repeat_delay">The repeat delay</param>
        /// <param name="rate">The rate</param>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern int igGetKeyPressedAmount(ImGuiKey key, float repeat_delay, float rate);
        /// <summary>
        /// Igs the get main viewport
        /// </summary>
        /// <returns>The im gui viewport</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiViewport* igGetMainViewport();
        /// <summary>
        /// Igs the get mouse clicked count using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern int igGetMouseClickedCount(ImGuiMouseButton button);
        /// <summary>
        /// Igs the get mouse cursor
        /// </summary>
        /// <returns>The im gui mouse cursor</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiMouseCursor igGetMouseCursor();
        /// <summary>
        /// Igs the get mouse drag delta using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="button">The button</param>
        /// <param name="lock_threshold">The lock threshold</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igGetMouseDragDelta(Vector2* pOut, ImGuiMouseButton button, float lock_threshold);
        /// <summary>
        /// Igs the get mouse pos using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igGetMousePos(Vector2* pOut);
        /// <summary>
        /// Igs the get mouse pos on opening current popup using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igGetMousePosOnOpeningCurrentPopup(Vector2* pOut);
        /// <summary>
        /// Igs the get platform io
        /// </summary>
        /// <returns>The im gui platform io</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiPlatformIO* igGetPlatformIO();
        /// <summary>
        /// Igs the get scroll max x
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern float igGetScrollMaxX();
        /// <summary>
        /// Igs the get scroll max y
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern float igGetScrollMaxY();
        /// <summary>
        /// Igs the get scroll x
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern float igGetScrollX();
        /// <summary>
        /// Igs the get scroll y
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern float igGetScrollY();
        /// <summary>
        /// Igs the get state storage
        /// </summary>
        /// <returns>The im gui storage</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiStorage* igGetStateStorage();
        /// <summary>
        /// Igs the get style
        /// </summary>
        /// <returns>The im gui style</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiStyle* igGetStyle();
        /// <summary>
        /// Igs the get style color name using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* igGetStyleColorName(ImGuiCol idx);
        /// <summary>
        /// Igs the get style color vec 4 using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <returns>The vector</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector4* igGetStyleColorVec4(ImGuiCol idx);
        /// <summary>
        /// Igs the get text line height
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern float igGetTextLineHeight();
        /// <summary>
        /// Igs the get text line height with spacing
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern float igGetTextLineHeightWithSpacing();
        /// <summary>
        /// Igs the get time
        /// </summary>
        /// <returns>The double</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern double igGetTime();
        /// <summary>
        /// Igs the get tree node to label spacing
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern float igGetTreeNodeToLabelSpacing();
        /// <summary>
        /// Igs the get version
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* igGetVersion();
        /// <summary>
        /// Igs the get window content region max using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igGetWindowContentRegionMax(Vector2* pOut);
        /// <summary>
        /// Igs the get window content region min using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igGetWindowContentRegionMin(Vector2* pOut);
        /// <summary>
        /// Igs the get window dock id
        /// </summary>
        /// <returns>The uint</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint igGetWindowDockID();
        /// <summary>
        /// Igs the get window dpi scale
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern float igGetWindowDpiScale();
        /// <summary>
        /// Igs the get window draw list
        /// </summary>
        /// <returns>The im draw list</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImDrawList* igGetWindowDrawList();
        /// <summary>
        /// Igs the get window height
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern float igGetWindowHeight();
        /// <summary>
        /// Igs the get window pos using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igGetWindowPos(Vector2* pOut);
        /// <summary>
        /// Igs the get window size using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igGetWindowSize(Vector2* pOut);
        /// <summary>
        /// Igs the get window viewport
        /// </summary>
        /// <returns>The im gui viewport</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiViewport* igGetWindowViewport();
        /// <summary>
        /// Igs the get window width
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern float igGetWindowWidth();
        /// <summary>
        /// Igs the image using the specified user texture id
        /// </summary>
        /// <param name="user_texture_id">The user texture id</param>
        /// <param name="size">The size</param>
        /// <param name="uv0">The uv</param>
        /// <param name="uv1">The uv</param>
        /// <param name="tint_col">The tint col</param>
        /// <param name="border_col">The border col</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igImage(IntPtr user_texture_id, Vector2 size, Vector2 uv0, Vector2 uv1, Vector4 tint_col, Vector4 border_col);
        /// <summary>
        /// Igs the image button using the specified str id
        /// </summary>
        /// <param name="str_id">The str id</param>
        /// <param name="user_texture_id">The user texture id</param>
        /// <param name="size">The size</param>
        /// <param name="uv0">The uv</param>
        /// <param name="uv1">The uv</param>
        /// <param name="bg_col">The bg col</param>
        /// <param name="tint_col">The tint col</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igImageButton(byte* str_id, IntPtr user_texture_id, Vector2 size, Vector2 uv0, Vector2 uv1, Vector4 bg_col, Vector4 tint_col);
        /// <summary>
        /// Igs the indent using the specified indent w
        /// </summary>
        /// <param name="indent_w">The indent</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igIndent(float indent_w);
        /// <summary>
        /// Igs the input double using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <param name="step_fast">The step fast</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igInputDouble(byte* label, double* v, double step, double step_fast, byte* format, ImGuiInputTextFlags flags);
        /// <summary>
        /// Igs the input float using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <param name="step_fast">The step fast</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igInputFloat(byte* label, float* v, float step, float step_fast, byte* format, ImGuiInputTextFlags flags);
        /// <summary>
        /// Igs the input float 2 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igInputFloat2(byte* label, Vector2* v, byte* format, ImGuiInputTextFlags flags);
        /// <summary>
        /// Igs the input float 3 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igInputFloat3(byte* label, Vector3* v, byte* format, ImGuiInputTextFlags flags);
        /// <summary>
        /// Igs the input float 4 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igInputFloat4(byte* label, Vector4* v, byte* format, ImGuiInputTextFlags flags);
        /// <summary>
        /// Igs the input int using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <param name="step_fast">The step fast</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igInputInt(byte* label, int* v, int step, int step_fast, ImGuiInputTextFlags flags);
        /// <summary>
        /// Igs the input int 2 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igInputInt2(byte* label, int* v, ImGuiInputTextFlags flags);
        /// <summary>
        /// Igs the input int 3 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igInputInt3(byte* label, int* v, ImGuiInputTextFlags flags);
        /// <summary>
        /// Igs the input int 4 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igInputInt4(byte* label, int* v, ImGuiInputTextFlags flags);
        /// <summary>
        /// Igs the input scalar using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="data_type">The data type</param>
        /// <param name="p_data">The data</param>
        /// <param name="p_step">The step</param>
        /// <param name="p_step_fast">The step fast</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igInputScalar(byte* label, ImGuiDataType data_type, void* p_data, void* p_step, void* p_step_fast, byte* format, ImGuiInputTextFlags flags);
        /// <summary>
        /// Igs the input scalar n using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="data_type">The data type</param>
        /// <param name="p_data">The data</param>
        /// <param name="components">The components</param>
        /// <param name="p_step">The step</param>
        /// <param name="p_step_fast">The step fast</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igInputScalarN(byte* label, ImGuiDataType data_type, void* p_data, int components, void* p_step, void* p_step_fast, byte* format, ImGuiInputTextFlags flags);
        /// <summary>
        /// Igs the input text using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="buf_size">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <param name="user_data">The user data</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igInputText(byte* label, byte* buf, uint buf_size, ImGuiInputTextFlags flags, ImGuiInputTextCallback callback, void* user_data);
        /// <summary>
        /// Igs the input text multiline using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="buf_size">The buf size</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <param name="user_data">The user data</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igInputTextMultiline(byte* label, byte* buf, uint buf_size, Vector2 size, ImGuiInputTextFlags flags, ImGuiInputTextCallback callback, void* user_data);
        /// <summary>
        /// Igs the input text with hint using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="hint">The hint</param>
        /// <param name="buf">The buf</param>
        /// <param name="buf_size">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <param name="user_data">The user data</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igInputTextWithHint(byte* label, byte* hint, byte* buf, uint buf_size, ImGuiInputTextFlags flags, ImGuiInputTextCallback callback, void* user_data);
        /// <summary>
        /// Igs the invisible button using the specified str id
        /// </summary>
        /// <param name="str_id">The str id</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igInvisibleButton(byte* str_id, Vector2 size, ImGuiButtonFlags flags);
        /// <summary>
        /// Igs the is any item active
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsAnyItemActive();
        /// <summary>
        /// Igs the is any item focused
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsAnyItemFocused();
        /// <summary>
        /// Igs the is any item hovered
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsAnyItemHovered();
        /// <summary>
        /// Igs the is any mouse down
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsAnyMouseDown();
        /// <summary>
        /// Igs the is item activated
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsItemActivated();
        /// <summary>
        /// Igs the is item active
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsItemActive();
        /// <summary>
        /// Igs the is item clicked using the specified mouse button
        /// </summary>
        /// <param name="mouse_button">The mouse button</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsItemClicked(ImGuiMouseButton mouse_button);
        /// <summary>
        /// Igs the is item deactivated
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsItemDeactivated();
        /// <summary>
        /// Igs the is item deactivated after edit
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsItemDeactivatedAfterEdit();
        /// <summary>
        /// Igs the is item edited
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsItemEdited();
        /// <summary>
        /// Igs the is item focused
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsItemFocused();
        /// <summary>
        /// Igs the is item hovered using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsItemHovered(ImGuiHoveredFlags flags);
        /// <summary>
        /// Igs the is item toggled open
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsItemToggledOpen();
        /// <summary>
        /// Igs the is item visible
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsItemVisible();
        /// <summary>
        /// Igs the is key down nil using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsKeyDown_Nil(ImGuiKey key);
        /// <summary>
        /// Igs the is key pressed bool using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="repeat">The repeat</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsKeyPressed_Bool(ImGuiKey key, byte repeat);
        /// <summary>
        /// Igs the is key released nil using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsKeyReleased_Nil(ImGuiKey key);
        /// <summary>
        /// Igs the is mouse clicked bool using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <param name="repeat">The repeat</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsMouseClicked_Bool(ImGuiMouseButton button, byte repeat);
        /// <summary>
        /// Igs the is mouse double clicked using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsMouseDoubleClicked(ImGuiMouseButton button);
        /// <summary>
        /// Igs the is mouse down nil using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsMouseDown_Nil(ImGuiMouseButton button);
        /// <summary>
        /// Igs the is mouse dragging using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <param name="lock_threshold">The lock threshold</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsMouseDragging(ImGuiMouseButton button, float lock_threshold);
        /// <summary>
        /// Igs the is mouse hovering rect using the specified r min
        /// </summary>
        /// <param name="r_min">The min</param>
        /// <param name="r_max">The max</param>
        /// <param name="clip">The clip</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsMouseHoveringRect(Vector2 r_min, Vector2 r_max, byte clip);
        /// <summary>
        /// Igs the is mouse pos valid using the specified mouse pos
        /// </summary>
        /// <param name="mouse_pos">The mouse pos</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsMousePosValid(Vector2* mouse_pos);
        /// <summary>
        /// Igs the is mouse released nil using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsMouseReleased_Nil(ImGuiMouseButton button);
        /// <summary>
        /// Igs the is popup open str using the specified str id
        /// </summary>
        /// <param name="str_id">The str id</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsPopupOpen_Str(byte* str_id, ImGuiPopupFlags flags);
        /// <summary>
        /// Igs the is rect visible nil using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsRectVisible_Nil(Vector2 size);
        /// <summary>
        /// Igs the is rect visible vec 2 using the specified rect min
        /// </summary>
        /// <param name="rect_min">The rect min</param>
        /// <param name="rect_max">The rect max</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsRectVisible_Vec2(Vector2 rect_min, Vector2 rect_max);
        /// <summary>
        /// Igs the is window appearing
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsWindowAppearing();
        /// <summary>
        /// Igs the is window collapsed
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsWindowCollapsed();
        /// <summary>
        /// Igs the is window docked
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsWindowDocked();
        /// <summary>
        /// Igs the is window focused using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsWindowFocused(ImGuiFocusedFlags flags);
        /// <summary>
        /// Igs the is window hovered using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igIsWindowHovered(ImGuiHoveredFlags flags);
        /// <summary>
        /// Igs the label text using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="fmt">The fmt</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igLabelText(byte* label, byte* fmt);
        /// <summary>
        /// Igs the list box str arr using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="current_item">The current item</param>
        /// <param name="items">The items</param>
        /// <param name="items_count">The items count</param>
        /// <param name="height_in_items">The height in items</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igListBox_Str_arr(byte* label, int* current_item, byte** items, int items_count, int height_in_items);
        /// <summary>
        /// Igs the load ini settings from disk using the specified ini filename
        /// </summary>
        /// <param name="ini_filename">The ini filename</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igLoadIniSettingsFromDisk(byte* ini_filename);
        /// <summary>
        /// Igs the load ini settings from memory using the specified ini data
        /// </summary>
        /// <param name="ini_data">The ini data</param>
        /// <param name="ini_size">The ini size</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igLoadIniSettingsFromMemory(byte* ini_data, uint ini_size);
        /// <summary>
        /// Igs the log buttons
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igLogButtons();
        /// <summary>
        /// Igs the log finish
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igLogFinish();
        /// <summary>
        /// Igs the log text using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igLogText(byte* fmt);
        /// <summary>
        /// Igs the log to clipboard using the specified auto open depth
        /// </summary>
        /// <param name="auto_open_depth">The auto open depth</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igLogToClipboard(int auto_open_depth);
        /// <summary>
        /// Igs the log to file using the specified auto open depth
        /// </summary>
        /// <param name="auto_open_depth">The auto open depth</param>
        /// <param name="filename">The filename</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igLogToFile(int auto_open_depth, byte* filename);
        /// <summary>
        /// Igs the log to tty using the specified auto open depth
        /// </summary>
        /// <param name="auto_open_depth">The auto open depth</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igLogToTTY(int auto_open_depth);
        /// <summary>
        /// Igs the mem alloc using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>The void</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* igMemAlloc(uint size);
        /// <summary>
        /// Igs the mem free using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igMemFree(void* ptr);
        /// <summary>
        /// Igs the menu item bool using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="shortcut">The shortcut</param>
        /// <param name="selected">The selected</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igMenuItem_Bool(byte* label, byte* shortcut, byte selected, byte enabled);
        /// <summary>
        /// Igs the menu item bool ptr using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="shortcut">The shortcut</param>
        /// <param name="p_selected">The selected</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igMenuItem_BoolPtr(byte* label, byte* shortcut, byte* p_selected, byte enabled);
        /// <summary>
        /// Igs the new frame
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igNewFrame();
        /// <summary>
        /// Igs the new line
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igNewLine();
        /// <summary>
        /// Igs the next column
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igNextColumn();
        /// <summary>
        /// Igs the open popup str using the specified str id
        /// </summary>
        /// <param name="str_id">The str id</param>
        /// <param name="popup_flags">The popup flags</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igOpenPopup_Str(byte* str_id, ImGuiPopupFlags popup_flags);
        /// <summary>
        /// Igs the open popup id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="popup_flags">The popup flags</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igOpenPopup_ID(uint id, ImGuiPopupFlags popup_flags);
        /// <summary>
        /// Igs the open popup on item click using the specified str id
        /// </summary>
        /// <param name="str_id">The str id</param>
        /// <param name="popup_flags">The popup flags</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igOpenPopupOnItemClick(byte* str_id, ImGuiPopupFlags popup_flags);
        /// <summary>
        /// Igs the plot histogram float ptr using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="values_count">The values count</param>
        /// <param name="values_offset">The values offset</param>
        /// <param name="overlay_text">The overlay text</param>
        /// <param name="scale_min">The scale min</param>
        /// <param name="scale_max">The scale max</param>
        /// <param name="graph_size">The graph size</param>
        /// <param name="stride">The stride</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igPlotHistogram_FloatPtr(byte* label, float* values, int values_count, int values_offset, byte* overlay_text, float scale_min, float scale_max, Vector2 graph_size, int stride);
        /// <summary>
        /// Igs the plot lines float ptr using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="values_count">The values count</param>
        /// <param name="values_offset">The values offset</param>
        /// <param name="overlay_text">The overlay text</param>
        /// <param name="scale_min">The scale min</param>
        /// <param name="scale_max">The scale max</param>
        /// <param name="graph_size">The graph size</param>
        /// <param name="stride">The stride</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igPlotLines_FloatPtr(byte* label, float* values, int values_count, int values_offset, byte* overlay_text, float scale_min, float scale_max, Vector2 graph_size, int stride);
        /// <summary>
        /// Igs the pop allow keyboard focus
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igPopAllowKeyboardFocus();
        /// <summary>
        /// Igs the pop button repeat
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igPopButtonRepeat();
        /// <summary>
        /// Igs the pop clip rect
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igPopClipRect();
        /// <summary>
        /// Igs the pop font
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igPopFont();
        /// <summary>
        /// Igs the pop id
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igPopID();
        /// <summary>
        /// Igs the pop item width
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igPopItemWidth();
        /// <summary>
        /// Igs the pop style color using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igPopStyleColor(int count);
        /// <summary>
        /// Igs the pop style var using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igPopStyleVar(int count);
        /// <summary>
        /// Igs the pop text wrap pos
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igPopTextWrapPos();
        /// <summary>
        /// Igs the progress bar using the specified fraction
        /// </summary>
        /// <param name="fraction">The fraction</param>
        /// <param name="size_arg">The size arg</param>
        /// <param name="overlay">The overlay</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igProgressBar(float fraction, Vector2 size_arg, byte* overlay);
        /// <summary>
        /// Igs the push allow keyboard focus using the specified allow keyboard focus
        /// </summary>
        /// <param name="allow_keyboard_focus">The allow keyboard focus</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igPushAllowKeyboardFocus(byte allow_keyboard_focus);
        /// <summary>
        /// Igs the push button repeat using the specified repeat
        /// </summary>
        /// <param name="repeat">The repeat</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igPushButtonRepeat(byte repeat);
        /// <summary>
        /// Igs the push clip rect using the specified clip rect min
        /// </summary>
        /// <param name="clip_rect_min">The clip rect min</param>
        /// <param name="clip_rect_max">The clip rect max</param>
        /// <param name="intersect_with_current_clip_rect">The intersect with current clip rect</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igPushClipRect(Vector2 clip_rect_min, Vector2 clip_rect_max, byte intersect_with_current_clip_rect);
        /// <summary>
        /// Igs the push font using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igPushFont(ImFont* font);
        /// <summary>
        /// Igs the push id str using the specified str id
        /// </summary>
        /// <param name="str_id">The str id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igPushID_Str(byte* str_id);
        /// <summary>
        /// Igs the push id str str using the specified str id begin
        /// </summary>
        /// <param name="str_id_begin">The str id begin</param>
        /// <param name="str_id_end">The str id end</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igPushID_StrStr(byte* str_id_begin, byte* str_id_end);
        /// <summary>
        /// Igs the push id ptr using the specified ptr id
        /// </summary>
        /// <param name="ptr_id">The ptr id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igPushID_Ptr(void* ptr_id);
        /// <summary>
        /// Igs the push id int using the specified int id
        /// </summary>
        /// <param name="int_id">The int id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igPushID_Int(int int_id);
        /// <summary>
        /// Igs the push item width using the specified item width
        /// </summary>
        /// <param name="item_width">The item width</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igPushItemWidth(float item_width);
        /// <summary>
        /// Igs the push style color u 32 using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="col">The col</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igPushStyleColor_U32(ImGuiCol idx, uint col);
        /// <summary>
        /// Igs the push style color vec 4 using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="col">The col</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igPushStyleColor_Vec4(ImGuiCol idx, Vector4 col);
        /// <summary>
        /// Igs the push style var float using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="val">The val</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igPushStyleVar_Float(ImGuiStyleVar idx, float val);
        /// <summary>
        /// Igs the push style var vec 2 using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="val">The val</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igPushStyleVar_Vec2(ImGuiStyleVar idx, Vector2 val);
        /// <summary>
        /// Igs the push text wrap pos using the specified wrap local pos x
        /// </summary>
        /// <param name="wrap_local_pos_x">The wrap local pos</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igPushTextWrapPos(float wrap_local_pos_x);
        /// <summary>
        /// Igs the radio button bool using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="active">The active</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igRadioButton_Bool(byte* label, byte active);
        /// <summary>
        /// Igs the radio button int ptr using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="v_button">The button</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igRadioButton_IntPtr(byte* label, int* v, int v_button);
        /// <summary>
        /// Igs the render
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igRender();
        /// <summary>
        /// Igs the render platform windows default using the specified platform render arg
        /// </summary>
        /// <param name="platform_render_arg">The platform render arg</param>
        /// <param name="renderer_render_arg">The renderer render arg</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igRenderPlatformWindowsDefault(void* platform_render_arg, void* renderer_render_arg);
        /// <summary>
        /// Igs the reset mouse drag delta using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igResetMouseDragDelta(ImGuiMouseButton button);
        /// <summary>
        /// Igs the same line using the specified offset from start x
        /// </summary>
        /// <param name="offset_from_start_x">The offset from start</param>
        /// <param name="spacing">The spacing</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSameLine(float offset_from_start_x, float spacing);
        /// <summary>
        /// Igs the save ini settings to disk using the specified ini filename
        /// </summary>
        /// <param name="ini_filename">The ini filename</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSaveIniSettingsToDisk(byte* ini_filename);
        /// <summary>
        /// Igs the save ini settings to memory using the specified out ini size
        /// </summary>
        /// <param name="out_ini_size">The out ini size</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* igSaveIniSettingsToMemory(uint* out_ini_size);
        /// <summary>
        /// Igs the selectable bool using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="selected">The selected</param>
        /// <param name="flags">The flags</param>
        /// <param name="size">The size</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igSelectable_Bool(byte* label, byte selected, ImGuiSelectableFlags flags, Vector2 size);
        /// <summary>
        /// Igs the selectable bool ptr using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="p_selected">The selected</param>
        /// <param name="flags">The flags</param>
        /// <param name="size">The size</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igSelectable_BoolPtr(byte* label, byte* p_selected, ImGuiSelectableFlags flags, Vector2 size);
        /// <summary>
        /// Igs the separator
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSeparator();
        /// <summary>
        /// Igs the set allocator functions using the specified alloc func
        /// </summary>
        /// <param name="alloc_func">The alloc func</param>
        /// <param name="free_func">The free func</param>
        /// <param name="user_data">The user data</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetAllocatorFunctions(IntPtr alloc_func, IntPtr free_func, void* user_data);
        /// <summary>
        /// Igs the set clipboard text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetClipboardText(byte* text);
        /// <summary>
        /// Igs the set color edit options using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetColorEditOptions(ImGuiColorEditFlags flags);
        /// <summary>
        /// Igs the set column offset using the specified column index
        /// </summary>
        /// <param name="column_index">The column index</param>
        /// <param name="offset_x">The offset</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetColumnOffset(int column_index, float offset_x);
        /// <summary>
        /// Igs the set column width using the specified column index
        /// </summary>
        /// <param name="column_index">The column index</param>
        /// <param name="width">The width</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetColumnWidth(int column_index, float width);
        /// <summary>
        /// Igs the set current context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetCurrentContext(IntPtr ctx);
        /// <summary>
        /// Igs the set cursor pos using the specified local pos
        /// </summary>
        /// <param name="local_pos">The local pos</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetCursorPos(Vector2 local_pos);
        /// <summary>
        /// Igs the set cursor pos x using the specified local x
        /// </summary>
        /// <param name="local_x">The local</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetCursorPosX(float local_x);
        /// <summary>
        /// Igs the set cursor pos y using the specified local y
        /// </summary>
        /// <param name="local_y">The local</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetCursorPosY(float local_y);
        /// <summary>
        /// Igs the set cursor screen pos using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetCursorScreenPos(Vector2 pos);
        /// <summary>
        /// Igs the set drag drop payload using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="data">The data</param>
        /// <param name="sz">The sz</param>
        /// <param name="cond">The cond</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igSetDragDropPayload(byte* type, void* data, uint sz, ImGuiCond cond);
        /// <summary>
        /// Igs the set item allow overlap
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetItemAllowOverlap();
        /// <summary>
        /// Igs the set item default focus
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetItemDefaultFocus();
        /// <summary>
        /// Igs the set keyboard focus here using the specified offset
        /// </summary>
        /// <param name="offset">The offset</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetKeyboardFocusHere(int offset);
        /// <summary>
        /// Igs the set mouse cursor using the specified cursor type
        /// </summary>
        /// <param name="cursor_type">The cursor type</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetMouseCursor(ImGuiMouseCursor cursor_type);
        /// <summary>
        /// Igs the set next frame want capture keyboard using the specified want capture keyboard
        /// </summary>
        /// <param name="want_capture_keyboard">The want capture keyboard</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetNextFrameWantCaptureKeyboard(byte want_capture_keyboard);
        /// <summary>
        /// Igs the set next frame want capture mouse using the specified want capture mouse
        /// </summary>
        /// <param name="want_capture_mouse">The want capture mouse</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetNextFrameWantCaptureMouse(byte want_capture_mouse);
        /// <summary>
        /// Igs the set next item open using the specified is open
        /// </summary>
        /// <param name="is_open">The is open</param>
        /// <param name="cond">The cond</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetNextItemOpen(byte is_open, ImGuiCond cond);
        /// <summary>
        /// Igs the set next item width using the specified item width
        /// </summary>
        /// <param name="item_width">The item width</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetNextItemWidth(float item_width);
        /// <summary>
        /// Igs the set next window bg alpha using the specified alpha
        /// </summary>
        /// <param name="alpha">The alpha</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetNextWindowBgAlpha(float alpha);
        /// <summary>
        /// Igs the set next window using the specified window class
        /// </summary>
        /// <param name="window_class">The window class</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetNextWindowClass(ImGuiWindowClass* window_class);
        /// <summary>
        /// Igs the set next window collapsed using the specified collapsed
        /// </summary>
        /// <param name="collapsed">The collapsed</param>
        /// <param name="cond">The cond</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetNextWindowCollapsed(byte collapsed, ImGuiCond cond);
        /// <summary>
        /// Igs the set next window content size using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetNextWindowContentSize(Vector2 size);
        /// <summary>
        /// Igs the set next window dock id using the specified dock id
        /// </summary>
        /// <param name="dock_id">The dock id</param>
        /// <param name="cond">The cond</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetNextWindowDockID(uint dock_id, ImGuiCond cond);
        /// <summary>
        /// Igs the set next window focus
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetNextWindowFocus();
        /// <summary>
        /// Igs the set next window pos using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="cond">The cond</param>
        /// <param name="pivot">The pivot</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetNextWindowPos(Vector2 pos, ImGuiCond cond, Vector2 pivot);
        /// <summary>
        /// Igs the set next window scroll using the specified scroll
        /// </summary>
        /// <param name="scroll">The scroll</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetNextWindowScroll(Vector2 scroll);
        /// <summary>
        /// Igs the set next window size using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        /// <param name="cond">The cond</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetNextWindowSize(Vector2 size, ImGuiCond cond);
        /// <summary>
        /// Igs the set next window size constraints using the specified size min
        /// </summary>
        /// <param name="size_min">The size min</param>
        /// <param name="size_max">The size max</param>
        /// <param name="custom_callback">The custom callback</param>
        /// <param name="custom_callback_data">The custom callback data</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetNextWindowSizeConstraints(Vector2 size_min, Vector2 size_max, ImGuiSizeCallback custom_callback, void* custom_callback_data);
        /// <summary>
        /// Igs the set next window viewport using the specified viewport id
        /// </summary>
        /// <param name="viewport_id">The viewport id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetNextWindowViewport(uint viewport_id);
        /// <summary>
        /// Igs the set scroll from pos x float using the specified local x
        /// </summary>
        /// <param name="local_x">The local</param>
        /// <param name="center_x_ratio">The center ratio</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetScrollFromPosX_Float(float local_x, float center_x_ratio);
        /// <summary>
        /// Igs the set scroll from pos y float using the specified local y
        /// </summary>
        /// <param name="local_y">The local</param>
        /// <param name="center_y_ratio">The center ratio</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetScrollFromPosY_Float(float local_y, float center_y_ratio);
        /// <summary>
        /// Igs the set scroll here x using the specified center x ratio
        /// </summary>
        /// <param name="center_x_ratio">The center ratio</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetScrollHereX(float center_x_ratio);
        /// <summary>
        /// Igs the set scroll here y using the specified center y ratio
        /// </summary>
        /// <param name="center_y_ratio">The center ratio</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetScrollHereY(float center_y_ratio);
        /// <summary>
        /// Igs the set scroll x float using the specified scroll x
        /// </summary>
        /// <param name="scroll_x">The scroll</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetScrollX_Float(float scroll_x);
        /// <summary>
        /// Igs the set scroll y float using the specified scroll y
        /// </summary>
        /// <param name="scroll_y">The scroll</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetScrollY_Float(float scroll_y);
        /// <summary>
        /// Igs the set state storage using the specified storage
        /// </summary>
        /// <param name="storage">The storage</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetStateStorage(ImGuiStorage* storage);
        /// <summary>
        /// Igs the set tab item closed using the specified tab or docked window label
        /// </summary>
        /// <param name="tab_or_docked_window_label">The tab or docked window label</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetTabItemClosed(byte* tab_or_docked_window_label);
        /// <summary>
        /// Igs the set tooltip using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetTooltip(byte* fmt);
        /// <summary>
        /// Igs the set window collapsed bool using the specified collapsed
        /// </summary>
        /// <param name="collapsed">The collapsed</param>
        /// <param name="cond">The cond</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetWindowCollapsed_Bool(byte collapsed, ImGuiCond cond);
        /// <summary>
        /// Igs the set window collapsed str using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="collapsed">The collapsed</param>
        /// <param name="cond">The cond</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetWindowCollapsed_Str(byte* name, byte collapsed, ImGuiCond cond);
        /// <summary>
        /// Igs the set window focus nil
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetWindowFocus_Nil();
        /// <summary>
        /// Igs the set window focus str using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetWindowFocus_Str(byte* name);
        /// <summary>
        /// Igs the set window font scale using the specified scale
        /// </summary>
        /// <param name="scale">The scale</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetWindowFontScale(float scale);
        /// <summary>
        /// Igs the set window pos vec 2 using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="cond">The cond</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetWindowPos_Vec2(Vector2 pos, ImGuiCond cond);
        /// <summary>
        /// Igs the set window pos str using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="pos">The pos</param>
        /// <param name="cond">The cond</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetWindowPos_Str(byte* name, Vector2 pos, ImGuiCond cond);
        /// <summary>
        /// Igs the set window size vec 2 using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        /// <param name="cond">The cond</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetWindowSize_Vec2(Vector2 size, ImGuiCond cond);
        /// <summary>
        /// Igs the set window size str using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="size">The size</param>
        /// <param name="cond">The cond</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSetWindowSize_Str(byte* name, Vector2 size, ImGuiCond cond);
        /// <summary>
        /// Igs the show about window using the specified p open
        /// </summary>
        /// <param name="p_open">The open</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igShowAboutWindow(byte* p_open);
        /// <summary>
        /// Igs the show debug log window using the specified p open
        /// </summary>
        /// <param name="p_open">The open</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igShowDebugLogWindow(byte* p_open);
        /// <summary>
        /// Igs the show demo window using the specified p open
        /// </summary>
        /// <param name="p_open">The open</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igShowDemoWindow(byte* p_open);
        /// <summary>
        /// Igs the show font selector using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igShowFontSelector(byte* label);
        /// <summary>
        /// Igs the show metrics window using the specified p open
        /// </summary>
        /// <param name="p_open">The open</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igShowMetricsWindow(byte* p_open);
        /// <summary>
        /// Igs the show stack tool window using the specified p open
        /// </summary>
        /// <param name="p_open">The open</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igShowStackToolWindow(byte* p_open);
        /// <summary>
        /// Igs the show style editor using the specified ref
        /// </summary>
        /// <param name="ref">The ref</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igShowStyleEditor(ImGuiStyle* @ref);
        /// <summary>
        /// Igs the show style selector using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igShowStyleSelector(byte* label);
        /// <summary>
        /// Igs the show user guide
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igShowUserGuide();
        /// <summary>
        /// Igs the slider angle using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v_rad">The rad</param>
        /// <param name="v_degrees_min">The degrees min</param>
        /// <param name="v_degrees_max">The degrees max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igSliderAngle(byte* label, float* v_rad, float v_degrees_min, float v_degrees_max, byte* format, ImGuiSliderFlags flags);
        /// <summary>
        /// Igs the slider float using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="v_min">The min</param>
        /// <param name="v_max">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igSliderFloat(byte* label, float* v, float v_min, float v_max, byte* format, ImGuiSliderFlags flags);
        /// <summary>
        /// Igs the slider float 2 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="v_min">The min</param>
        /// <param name="v_max">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igSliderFloat2(byte* label, Vector2* v, float v_min, float v_max, byte* format, ImGuiSliderFlags flags);
        /// <summary>
        /// Igs the slider float 3 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="v_min">The min</param>
        /// <param name="v_max">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igSliderFloat3(byte* label, Vector3* v, float v_min, float v_max, byte* format, ImGuiSliderFlags flags);
        /// <summary>
        /// Igs the slider float 4 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="v_min">The min</param>
        /// <param name="v_max">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igSliderFloat4(byte* label, Vector4* v, float v_min, float v_max, byte* format, ImGuiSliderFlags flags);
        /// <summary>
        /// Igs the slider int using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="v_min">The min</param>
        /// <param name="v_max">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igSliderInt(byte* label, int* v, int v_min, int v_max, byte* format, ImGuiSliderFlags flags);
        /// <summary>
        /// Igs the slider int 2 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="v_min">The min</param>
        /// <param name="v_max">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igSliderInt2(byte* label, int* v, int v_min, int v_max, byte* format, ImGuiSliderFlags flags);
        /// <summary>
        /// Igs the slider int 3 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="v_min">The min</param>
        /// <param name="v_max">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igSliderInt3(byte* label, int* v, int v_min, int v_max, byte* format, ImGuiSliderFlags flags);
        /// <summary>
        /// Igs the slider int 4 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="v_min">The min</param>
        /// <param name="v_max">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igSliderInt4(byte* label, int* v, int v_min, int v_max, byte* format, ImGuiSliderFlags flags);
        /// <summary>
        /// Igs the slider scalar using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="data_type">The data type</param>
        /// <param name="p_data">The data</param>
        /// <param name="p_min">The min</param>
        /// <param name="p_max">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igSliderScalar(byte* label, ImGuiDataType data_type, void* p_data, void* p_min, void* p_max, byte* format, ImGuiSliderFlags flags);
        /// <summary>
        /// Igs the slider scalar n using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="data_type">The data type</param>
        /// <param name="p_data">The data</param>
        /// <param name="components">The components</param>
        /// <param name="p_min">The min</param>
        /// <param name="p_max">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igSliderScalarN(byte* label, ImGuiDataType data_type, void* p_data, int components, void* p_min, void* p_max, byte* format, ImGuiSliderFlags flags);
        /// <summary>
        /// Igs the small button using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igSmallButton(byte* label);
        /// <summary>
        /// Igs the spacing
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igSpacing();
        /// <summary>
        /// Igs the style colors classic using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igStyleColorsClassic(ImGuiStyle* dst);
        /// <summary>
        /// Igs the style colors dark using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igStyleColorsDark(ImGuiStyle* dst);
        /// <summary>
        /// Igs the style colors light using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igStyleColorsLight(ImGuiStyle* dst);
        /// <summary>
        /// Igs the tab item button using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igTabItemButton(byte* label, ImGuiTabItemFlags flags);
        /// <summary>
        /// Igs the table get column count
        /// </summary>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern int igTableGetColumnCount();
        /// <summary>
        /// Igs the table get column flags using the specified column n
        /// </summary>
        /// <param name="column_n">The column</param>
        /// <returns>The im gui table column flags</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiTableColumnFlags igTableGetColumnFlags(int column_n);
        /// <summary>
        /// Igs the table get column index
        /// </summary>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern int igTableGetColumnIndex();
        /// <summary>
        /// Igs the table get column name int using the specified column n
        /// </summary>
        /// <param name="column_n">The column</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* igTableGetColumnName_Int(int column_n);
        /// <summary>
        /// Igs the table get row index
        /// </summary>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern int igTableGetRowIndex();
        /// <summary>
        /// Igs the table get sort specs
        /// </summary>
        /// <returns>The im gui table sort specs</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiTableSortSpecs* igTableGetSortSpecs();
        /// <summary>
        /// Igs the table header using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igTableHeader(byte* label);
        /// <summary>
        /// Igs the table headers row
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igTableHeadersRow();
        /// <summary>
        /// Igs the table next column
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igTableNextColumn();
        /// <summary>
        /// Igs the table next row using the specified row flags
        /// </summary>
        /// <param name="row_flags">The row flags</param>
        /// <param name="min_row_height">The min row height</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igTableNextRow(ImGuiTableRowFlags row_flags, float min_row_height);
        /// <summary>
        /// Igs the table set bg color using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="color">The color</param>
        /// <param name="column_n">The column</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igTableSetBgColor(ImGuiTableBgTarget target, uint color, int column_n);
        /// <summary>
        /// Igs the table set column enabled using the specified column n
        /// </summary>
        /// <param name="column_n">The column</param>
        /// <param name="v">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igTableSetColumnEnabled(int column_n, byte v);
        /// <summary>
        /// Igs the table set column index using the specified column n
        /// </summary>
        /// <param name="column_n">The column</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igTableSetColumnIndex(int column_n);
        /// <summary>
        /// Igs the table setup column using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <param name="init_width_or_weight">The init width or weight</param>
        /// <param name="user_id">The user id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igTableSetupColumn(byte* label, ImGuiTableColumnFlags flags, float init_width_or_weight, uint user_id);
        /// <summary>
        /// Igs the table setup scroll freeze using the specified cols
        /// </summary>
        /// <param name="cols">The cols</param>
        /// <param name="rows">The rows</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igTableSetupScrollFreeze(int cols, int rows);
        /// <summary>
        /// Igs the text using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igText(byte* fmt);
        /// <summary>
        /// Igs the text colored using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <param name="fmt">The fmt</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igTextColored(Vector4 col, byte* fmt);
        /// <summary>
        /// Igs the text disabled using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igTextDisabled(byte* fmt);
        /// <summary>
        /// Igs the text unformatted using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="text_end">The text end</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igTextUnformatted(byte* text, byte* text_end);
        /// <summary>
        /// Igs the text wrapped using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igTextWrapped(byte* fmt);
        /// <summary>
        /// Igs the tree node str using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igTreeNode_Str(byte* label);
        /// <summary>
        /// Igs the tree node str str using the specified str id
        /// </summary>
        /// <param name="str_id">The str id</param>
        /// <param name="fmt">The fmt</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igTreeNode_StrStr(byte* str_id, byte* fmt);
        /// <summary>
        /// Igs the tree node ptr using the specified ptr id
        /// </summary>
        /// <param name="ptr_id">The ptr id</param>
        /// <param name="fmt">The fmt</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igTreeNode_Ptr(void* ptr_id, byte* fmt);
        /// <summary>
        /// Igs the tree node ex str using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igTreeNodeEx_Str(byte* label, ImGuiTreeNodeFlags flags);
        /// <summary>
        /// Igs the tree node ex str str using the specified str id
        /// </summary>
        /// <param name="str_id">The str id</param>
        /// <param name="flags">The flags</param>
        /// <param name="fmt">The fmt</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igTreeNodeEx_StrStr(byte* str_id, ImGuiTreeNodeFlags flags, byte* fmt);
        /// <summary>
        /// Igs the tree node ex ptr using the specified ptr id
        /// </summary>
        /// <param name="ptr_id">The ptr id</param>
        /// <param name="flags">The flags</param>
        /// <param name="fmt">The fmt</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igTreeNodeEx_Ptr(void* ptr_id, ImGuiTreeNodeFlags flags, byte* fmt);
        /// <summary>
        /// Igs the tree pop
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igTreePop();
        /// <summary>
        /// Igs the tree push str using the specified str id
        /// </summary>
        /// <param name="str_id">The str id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igTreePush_Str(byte* str_id);
        /// <summary>
        /// Igs the tree push ptr using the specified ptr id
        /// </summary>
        /// <param name="ptr_id">The ptr id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igTreePush_Ptr(void* ptr_id);
        /// <summary>
        /// Igs the unindent using the specified indent w
        /// </summary>
        /// <param name="indent_w">The indent</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igUnindent(float indent_w);
        /// <summary>
        /// Igs the update platform windows
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igUpdatePlatformWindows();
        /// <summary>
        /// Igs the value bool using the specified prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="b">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igValue_Bool(byte* prefix, byte b);
        /// <summary>
        /// Igs the value int using the specified prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="v">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igValue_Int(byte* prefix, int v);
        /// <summary>
        /// Igs the value uint using the specified prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="v">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igValue_Uint(byte* prefix, uint v);
        /// <summary>
        /// Igs the value float using the specified prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="v">The </param>
        /// <param name="float_format">The float format</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void igValue_Float(byte* prefix, float v, byte* float_format);
        /// <summary>
        /// Igs the v slider float using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="v">The </param>
        /// <param name="v_min">The min</param>
        /// <param name="v_max">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igVSliderFloat(byte* label, Vector2 size, float* v, float v_min, float v_max, byte* format, ImGuiSliderFlags flags);
        /// <summary>
        /// Igs the v slider int using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="v">The </param>
        /// <param name="v_min">The min</param>
        /// <param name="v_max">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igVSliderInt(byte* label, Vector2 size, int* v, int v_min, int v_max, byte* format, ImGuiSliderFlags flags);
        /// <summary>
        /// Igs the v slider scalar using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="data_type">The data type</param>
        /// <param name="p_data">The data</param>
        /// <param name="p_min">The min</param>
        /// <param name="p_max">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte igVSliderScalar(byte* label, Vector2 size, ImGuiDataType data_type, void* p_data, void* p_min, void* p_max, byte* format, ImGuiSliderFlags flags);
        /// <summary>
        /// Ims the color destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImColor_destroy(ImColor* self);
        /// <summary>
        /// Ims the color hsv using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        /// <param name="a">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImColor_HSV(ImColor* pOut, float h, float s, float v, float a);
        /// <summary>
        /// Ims the color im color nil
        /// </summary>
        /// <returns>The im color</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImColor* ImColor_ImColor_Nil();
        /// <summary>
        /// Ims the color im color float using the specified r
        /// </summary>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The im color</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImColor* ImColor_ImColor_Float(float r, float g, float b, float a);
        /// <summary>
        /// Ims the color im color vec 4 using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <returns>The im color</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImColor* ImColor_ImColor_Vec4(Vector4 col);
        /// <summary>
        /// Ims the color im color int using the specified r
        /// </summary>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The im color</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImColor* ImColor_ImColor_Int(int r, int g, int b, int a);
        /// <summary>
        /// Ims the color im color u 32 using the specified rgba
        /// </summary>
        /// <param name="rgba">The rgba</param>
        /// <returns>The im color</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImColor* ImColor_ImColor_U32(uint rgba);
        /// <summary>
        /// Ims the color set hsv using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        /// <param name="a">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImColor_SetHSV(ImColor* self, float h, float s, float v, float a);
        /// <summary>
        /// Ims the draw cmd destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawCmd_destroy(ImDrawCmd* self);
        /// <summary>
        /// Ims the draw cmd get tex id using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The int ptr</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ImDrawCmd_GetTexID(ImDrawCmd* self);
        /// <summary>
        /// Ims the draw cmd im draw cmd
        /// </summary>
        /// <returns>The im draw cmd</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImDrawCmd* ImDrawCmd_ImDrawCmd();
        /// <summary>
        /// Ims the draw data clear using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawData_Clear(ImDrawData* self);
        /// <summary>
        /// Ims the draw data de index all buffers using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawData_DeIndexAllBuffers(ImDrawData* self);
        /// <summary>
        /// Ims the draw data destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawData_destroy(ImDrawData* self);
        /// <summary>
        /// Ims the draw data im draw data
        /// </summary>
        /// <returns>The im draw data</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImDrawData* ImDrawData_ImDrawData();
        /// <summary>
        /// Ims the draw data scale clip rects using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="fb_scale">The fb scale</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawData_ScaleClipRects(ImDrawData* self, Vector2 fb_scale);
        /// <summary>
        /// Ims the draw list calc circle auto segment count using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="radius">The radius</param>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ImDrawList__CalcCircleAutoSegmentCount(ImDrawList* self, float radius);
        /// <summary>
        /// Ims the draw list clear free memory using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList__ClearFreeMemory(ImDrawList* self);
        /// <summary>
        /// Ims the draw list on changed clip rect using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList__OnChangedClipRect(ImDrawList* self);
        /// <summary>
        /// Ims the draw list on changed texture id using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList__OnChangedTextureID(ImDrawList* self);
        /// <summary>
        /// Ims the draw list on changed vtx offset using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList__OnChangedVtxOffset(ImDrawList* self);
        /// <summary>
        /// Ims the draw list path arc to fast ex using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="a_min_sample">The min sample</param>
        /// <param name="a_max_sample">The max sample</param>
        /// <param name="a_step">The step</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList__PathArcToFastEx(ImDrawList* self, Vector2 center, float radius, int a_min_sample, int a_max_sample, int a_step);
        /// <summary>
        /// Ims the draw list path arc to n using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="a_min">The min</param>
        /// <param name="a_max">The max</param>
        /// <param name="num_segments">The num segments</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList__PathArcToN(ImDrawList* self, Vector2 center, float radius, float a_min, float a_max, int num_segments);
        /// <summary>
        /// Ims the draw list pop unused draw cmd using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList__PopUnusedDrawCmd(ImDrawList* self);
        /// <summary>
        /// Ims the draw list reset for new frame using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList__ResetForNewFrame(ImDrawList* self);
        /// <summary>
        /// Ims the draw list try merge draw cmds using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList__TryMergeDrawCmds(ImDrawList* self);
        /// <summary>
        /// Ims the draw list add bezier cubic using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        /// <param name="num_segments">The num segments</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_AddBezierCubic(ImDrawList* self, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, uint col, float thickness, int num_segments);
        /// <summary>
        /// Ims the draw list add bezier quadratic using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        /// <param name="num_segments">The num segments</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_AddBezierQuadratic(ImDrawList* self, Vector2 p1, Vector2 p2, Vector2 p3, uint col, float thickness, int num_segments);
        /// <summary>
        /// Ims the draw list add callback using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="callback">The callback</param>
        /// <param name="callback_data">The callback data</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_AddCallback(ImDrawList* self, IntPtr callback, void* callback_data);
        /// <summary>
        /// Ims the draw list add circle using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="num_segments">The num segments</param>
        /// <param name="thickness">The thickness</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_AddCircle(ImDrawList* self, Vector2 center, float radius, uint col, int num_segments, float thickness);
        /// <summary>
        /// Ims the draw list add circle filled using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="num_segments">The num segments</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_AddCircleFilled(ImDrawList* self, Vector2 center, float radius, uint col, int num_segments);
        /// <summary>
        /// Ims the draw list add convex poly filled using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="points">The points</param>
        /// <param name="num_points">The num points</param>
        /// <param name="col">The col</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_AddConvexPolyFilled(ImDrawList* self, Vector2* points, int num_points, uint col);
        /// <summary>
        /// Ims the draw list add draw cmd using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_AddDrawCmd(ImDrawList* self);
        /// <summary>
        /// Ims the draw list add image using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="user_texture_id">The user texture id</param>
        /// <param name="p_min">The min</param>
        /// <param name="p_max">The max</param>
        /// <param name="uv_min">The uv min</param>
        /// <param name="uv_max">The uv max</param>
        /// <param name="col">The col</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_AddImage(ImDrawList* self, IntPtr user_texture_id, Vector2 p_min, Vector2 p_max, Vector2 uv_min, Vector2 uv_max, uint col);
        /// <summary>
        /// Ims the draw list add image quad using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="user_texture_id">The user texture id</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="uv1">The uv</param>
        /// <param name="uv2">The uv</param>
        /// <param name="uv3">The uv</param>
        /// <param name="uv4">The uv</param>
        /// <param name="col">The col</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_AddImageQuad(ImDrawList* self, IntPtr user_texture_id, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, Vector2 uv1, Vector2 uv2, Vector2 uv3, Vector2 uv4, uint col);
        /// <summary>
        /// Ims the draw list add image rounded using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="user_texture_id">The user texture id</param>
        /// <param name="p_min">The min</param>
        /// <param name="p_max">The max</param>
        /// <param name="uv_min">The uv min</param>
        /// <param name="uv_max">The uv max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_AddImageRounded(ImDrawList* self, IntPtr user_texture_id, Vector2 p_min, Vector2 p_max, Vector2 uv_min, Vector2 uv_max, uint col, float rounding, ImDrawFlags flags);
        /// <summary>
        /// Ims the draw list add line using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_AddLine(ImDrawList* self, Vector2 p1, Vector2 p2, uint col, float thickness);
        /// <summary>
        /// Ims the draw list add ngon using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="num_segments">The num segments</param>
        /// <param name="thickness">The thickness</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_AddNgon(ImDrawList* self, Vector2 center, float radius, uint col, int num_segments, float thickness);
        /// <summary>
        /// Ims the draw list add ngon filled using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="num_segments">The num segments</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_AddNgonFilled(ImDrawList* self, Vector2 center, float radius, uint col, int num_segments);
        /// <summary>
        /// Ims the draw list add polyline using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="points">The points</param>
        /// <param name="num_points">The num points</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <param name="thickness">The thickness</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_AddPolyline(ImDrawList* self, Vector2* points, int num_points, uint col, ImDrawFlags flags, float thickness);
        /// <summary>
        /// Ims the draw list add quad using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_AddQuad(ImDrawList* self, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, uint col, float thickness);
        /// <summary>
        /// Ims the draw list add quad filled using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="col">The col</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_AddQuadFilled(ImDrawList* self, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, uint col);
        /// <summary>
        /// Ims the draw list add rect using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p_min">The min</param>
        /// <param name="p_max">The max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        /// <param name="thickness">The thickness</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_AddRect(ImDrawList* self, Vector2 p_min, Vector2 p_max, uint col, float rounding, ImDrawFlags flags, float thickness);
        /// <summary>
        /// Ims the draw list add rect filled using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p_min">The min</param>
        /// <param name="p_max">The max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_AddRectFilled(ImDrawList* self, Vector2 p_min, Vector2 p_max, uint col, float rounding, ImDrawFlags flags);
        /// <summary>
        /// Ims the draw list add rect filled multi color using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p_min">The min</param>
        /// <param name="p_max">The max</param>
        /// <param name="col_upr_left">The col upr left</param>
        /// <param name="col_upr_right">The col upr right</param>
        /// <param name="col_bot_right">The col bot right</param>
        /// <param name="col_bot_left">The col bot left</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_AddRectFilledMultiColor(ImDrawList* self, Vector2 p_min, Vector2 p_max, uint col_upr_left, uint col_upr_right, uint col_bot_right, uint col_bot_left);
        /// <summary>
        /// Ims the draw list add text vec 2 using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        /// <param name="col">The col</param>
        /// <param name="text_begin">The text begin</param>
        /// <param name="text_end">The text end</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_AddText_Vec2(ImDrawList* self, Vector2 pos, uint col, byte* text_begin, byte* text_end);
        /// <summary>
        /// Ims the draw list add text font ptr using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="font">The font</param>
        /// <param name="font_size">The font size</param>
        /// <param name="pos">The pos</param>
        /// <param name="col">The col</param>
        /// <param name="text_begin">The text begin</param>
        /// <param name="text_end">The text end</param>
        /// <param name="wrap_width">The wrap width</param>
        /// <param name="cpu_fine_clip_rect">The cpu fine clip rect</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_AddText_FontPtr(ImDrawList* self, ImFont* font, float font_size, Vector2 pos, uint col, byte* text_begin, byte* text_end, float wrap_width, Vector4* cpu_fine_clip_rect);
        /// <summary>
        /// Ims the draw list add triangle using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_AddTriangle(ImDrawList* self, Vector2 p1, Vector2 p2, Vector2 p3, uint col, float thickness);
        /// <summary>
        /// Ims the draw list add triangle filled using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="col">The col</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_AddTriangleFilled(ImDrawList* self, Vector2 p1, Vector2 p2, Vector2 p3, uint col);
        /// <summary>
        /// Ims the draw list channels merge using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_ChannelsMerge(ImDrawList* self);
        /// <summary>
        /// Ims the draw list channels set current using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="n">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_ChannelsSetCurrent(ImDrawList* self, int n);
        /// <summary>
        /// Ims the draw list channels split using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="count">The count</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_ChannelsSplit(ImDrawList* self, int count);
        /// <summary>
        /// Ims the draw list clone output using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The im draw list</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImDrawList* ImDrawList_CloneOutput(ImDrawList* self);
        /// <summary>
        /// Ims the draw list destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_destroy(ImDrawList* self);
        /// <summary>
        /// Ims the draw list get clip rect max using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_GetClipRectMax(Vector2* pOut, ImDrawList* self);
        /// <summary>
        /// Ims the draw list get clip rect min using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_GetClipRectMin(Vector2* pOut, ImDrawList* self);
        /// <summary>
        /// Ims the draw list im draw list using the specified shared data
        /// </summary>
        /// <param name="shared_data">The shared data</param>
        /// <returns>The im draw list</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImDrawList* ImDrawList_ImDrawList(IntPtr shared_data);
        /// <summary>
        /// Ims the draw list path arc to using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="a_min">The min</param>
        /// <param name="a_max">The max</param>
        /// <param name="num_segments">The num segments</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_PathArcTo(ImDrawList* self, Vector2 center, float radius, float a_min, float a_max, int num_segments);
        /// <summary>
        /// Ims the draw list path arc to fast using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="a_min_of_12">The min of 12</param>
        /// <param name="a_max_of_12">The max of 12</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_PathArcToFast(ImDrawList* self, Vector2 center, float radius, int a_min_of_12, int a_max_of_12);
        /// <summary>
        /// Ims the draw list path bezier cubic curve to using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="num_segments">The num segments</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_PathBezierCubicCurveTo(ImDrawList* self, Vector2 p2, Vector2 p3, Vector2 p4, int num_segments);
        /// <summary>
        /// Ims the draw list path bezier quadratic curve to using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="num_segments">The num segments</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_PathBezierQuadraticCurveTo(ImDrawList* self, Vector2 p2, Vector2 p3, int num_segments);
        /// <summary>
        /// Ims the draw list path clear using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_PathClear(ImDrawList* self);
        /// <summary>
        /// Ims the draw list path fill convex using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="col">The col</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_PathFillConvex(ImDrawList* self, uint col);
        /// <summary>
        /// Ims the draw list path line to using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_PathLineTo(ImDrawList* self, Vector2 pos);
        /// <summary>
        /// Ims the draw list path line to merge duplicate using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_PathLineToMergeDuplicate(ImDrawList* self, Vector2 pos);
        /// <summary>
        /// Ims the draw list path rect using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="rect_min">The rect min</param>
        /// <param name="rect_max">The rect max</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_PathRect(ImDrawList* self, Vector2 rect_min, Vector2 rect_max, float rounding, ImDrawFlags flags);
        /// <summary>
        /// Ims the draw list path stroke using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <param name="thickness">The thickness</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_PathStroke(ImDrawList* self, uint col, ImDrawFlags flags, float thickness);
        /// <summary>
        /// Ims the draw list pop clip rect using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_PopClipRect(ImDrawList* self);
        /// <summary>
        /// Ims the draw list pop texture id using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_PopTextureID(ImDrawList* self);
        /// <summary>
        /// Ims the draw list prim quad uv using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <param name="uv_a">The uv</param>
        /// <param name="uv_b">The uv</param>
        /// <param name="uv_c">The uv</param>
        /// <param name="uv_d">The uv</param>
        /// <param name="col">The col</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_PrimQuadUV(ImDrawList* self, Vector2 a, Vector2 b, Vector2 c, Vector2 d, Vector2 uv_a, Vector2 uv_b, Vector2 uv_c, Vector2 uv_d, uint col);
        /// <summary>
        /// Ims the draw list prim rect using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="col">The col</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_PrimRect(ImDrawList* self, Vector2 a, Vector2 b, uint col);
        /// <summary>
        /// Ims the draw list prim rect uv using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="uv_a">The uv</param>
        /// <param name="uv_b">The uv</param>
        /// <param name="col">The col</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_PrimRectUV(ImDrawList* self, Vector2 a, Vector2 b, Vector2 uv_a, Vector2 uv_b, uint col);
        /// <summary>
        /// Ims the draw list prim reserve using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="idx_count">The idx count</param>
        /// <param name="vtx_count">The vtx count</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_PrimReserve(ImDrawList* self, int idx_count, int vtx_count);
        /// <summary>
        /// Ims the draw list prim unreserve using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="idx_count">The idx count</param>
        /// <param name="vtx_count">The vtx count</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_PrimUnreserve(ImDrawList* self, int idx_count, int vtx_count);
        /// <summary>
        /// Ims the draw list prim vtx using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        /// <param name="uv">The uv</param>
        /// <param name="col">The col</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_PrimVtx(ImDrawList* self, Vector2 pos, Vector2 uv, uint col);
        /// <summary>
        /// Ims the draw list prim write idx using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="idx">The idx</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_PrimWriteIdx(ImDrawList* self, ushort idx);
        /// <summary>
        /// Ims the draw list prim write vtx using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        /// <param name="uv">The uv</param>
        /// <param name="col">The col</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_PrimWriteVtx(ImDrawList* self, Vector2 pos, Vector2 uv, uint col);
        /// <summary>
        /// Ims the draw list push clip rect using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="clip_rect_min">The clip rect min</param>
        /// <param name="clip_rect_max">The clip rect max</param>
        /// <param name="intersect_with_current_clip_rect">The intersect with current clip rect</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_PushClipRect(ImDrawList* self, Vector2 clip_rect_min, Vector2 clip_rect_max, byte intersect_with_current_clip_rect);
        /// <summary>
        /// Ims the draw list push clip rect full screen using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_PushClipRectFullScreen(ImDrawList* self);
        /// <summary>
        /// Ims the draw list push texture id using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="texture_id">The texture id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawList_PushTextureID(ImDrawList* self, IntPtr texture_id);
        /// <summary>
        /// Ims the draw list splitter clear using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawListSplitter_Clear(ImDrawListSplitter* self);
        /// <summary>
        /// Ims the draw list splitter clear free memory using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawListSplitter_ClearFreeMemory(ImDrawListSplitter* self);
        /// <summary>
        /// Ims the draw list splitter destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawListSplitter_destroy(ImDrawListSplitter* self);
        /// <summary>
        /// Ims the draw list splitter im draw list splitter
        /// </summary>
        /// <returns>The im draw list splitter</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImDrawListSplitter* ImDrawListSplitter_ImDrawListSplitter();
        /// <summary>
        /// Ims the draw list splitter merge using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="draw_list">The draw list</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawListSplitter_Merge(ImDrawListSplitter* self, ImDrawList* draw_list);
        /// <summary>
        /// Ims the draw list splitter set current channel using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="draw_list">The draw list</param>
        /// <param name="channel_idx">The channel idx</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawListSplitter_SetCurrentChannel(ImDrawListSplitter* self, ImDrawList* draw_list, int channel_idx);
        /// <summary>
        /// Ims the draw list splitter split using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="draw_list">The draw list</param>
        /// <param name="count">The count</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImDrawListSplitter_Split(ImDrawListSplitter* self, ImDrawList* draw_list, int count);
        /// <summary>
        /// Ims the font add glyph using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="src_cfg">The src cfg</param>
        /// <param name="c">The </param>
        /// <param name="x0">The </param>
        /// <param name="y0">The </param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="u0">The </param>
        /// <param name="v0">The </param>
        /// <param name="u1">The </param>
        /// <param name="v1">The </param>
        /// <param name="advance_x">The advance</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFont_AddGlyph(ImFont* self, ImFontConfig* src_cfg, ushort c, float x0, float y0, float x1, float y1, float u0, float v0, float u1, float v1, float advance_x);
        /// <summary>
        /// Ims the font add remap char using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="overwrite_dst">The overwrite dst</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFont_AddRemapChar(ImFont* self, ushort dst, ushort src, byte overwrite_dst);
        /// <summary>
        /// Ims the font build lookup table using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFont_BuildLookupTable(ImFont* self);
        /// <summary>
        /// Ims the font calc text size a using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="self">The self</param>
        /// <param name="size">The size</param>
        /// <param name="max_width">The max width</param>
        /// <param name="wrap_width">The wrap width</param>
        /// <param name="text_begin">The text begin</param>
        /// <param name="text_end">The text end</param>
        /// <param name="remaining">The remaining</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFont_CalcTextSizeA(Vector2* pOut, ImFont* self, float size, float max_width, float wrap_width, byte* text_begin, byte* text_end, byte** remaining);
        /// <summary>
        /// Ims the font calc word wrap position a using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="scale">The scale</param>
        /// <param name="text">The text</param>
        /// <param name="text_end">The text end</param>
        /// <param name="wrap_width">The wrap width</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* ImFont_CalcWordWrapPositionA(ImFont* self, float scale, byte* text, byte* text_end, float wrap_width);
        /// <summary>
        /// Ims the font clear output data using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFont_ClearOutputData(ImFont* self);
        /// <summary>
        /// Ims the font destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFont_destroy(ImFont* self);
        /// <summary>
        /// Ims the font find glyph using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="c">The </param>
        /// <returns>The im font glyph</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImFontGlyph* ImFont_FindGlyph(ImFont* self, ushort c);
        /// <summary>
        /// Ims the font find glyph no fallback using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="c">The </param>
        /// <returns>The im font glyph</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImFontGlyph* ImFont_FindGlyphNoFallback(ImFont* self, ushort c);
        /// <summary>
        /// Ims the font get char advance using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="c">The </param>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern float ImFont_GetCharAdvance(ImFont* self, ushort c);
        /// <summary>
        /// Ims the font get debug name using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* ImFont_GetDebugName(ImFont* self);
        /// <summary>
        /// Ims the font grow index using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="new_size">The new size</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFont_GrowIndex(ImFont* self, int new_size);
        /// <summary>
        /// Ims the font im font
        /// </summary>
        /// <returns>The im font</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImFont* ImFont_ImFont();
        /// <summary>
        /// Ims the font is glyph range unused using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="c_begin">The begin</param>
        /// <param name="c_last">The last</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImFont_IsGlyphRangeUnused(ImFont* self, uint c_begin, uint c_last);
        /// <summary>
        /// Ims the font is loaded using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImFont_IsLoaded(ImFont* self);
        /// <summary>
        /// Ims the font render char using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="draw_list">The draw list</param>
        /// <param name="size">The size</param>
        /// <param name="pos">The pos</param>
        /// <param name="col">The col</param>
        /// <param name="c">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFont_RenderChar(ImFont* self, ImDrawList* draw_list, float size, Vector2 pos, uint col, ushort c);
        /// <summary>
        /// Ims the font render text using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="draw_list">The draw list</param>
        /// <param name="size">The size</param>
        /// <param name="pos">The pos</param>
        /// <param name="col">The col</param>
        /// <param name="clip_rect">The clip rect</param>
        /// <param name="text_begin">The text begin</param>
        /// <param name="text_end">The text end</param>
        /// <param name="wrap_width">The wrap width</param>
        /// <param name="cpu_fine_clip">The cpu fine clip</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFont_RenderText(ImFont* self, ImDrawList* draw_list, float size, Vector2 pos, uint col, Vector4 clip_rect, byte* text_begin, byte* text_end, float wrap_width, byte cpu_fine_clip);
        /// <summary>
        /// Ims the font set glyph visible using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="c">The </param>
        /// <param name="visible">The visible</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFont_SetGlyphVisible(ImFont* self, ushort c, byte visible);
        /// <summary>
        /// Ims the font atlas add custom rect font glyph using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="font">The font</param>
        /// <param name="id">The id</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="advance_x">The advance</param>
        /// <param name="offset">The offset</param>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ImFontAtlas_AddCustomRectFontGlyph(ImFontAtlas* self, ImFont* font, ushort id, int width, int height, float advance_x, Vector2 offset);
        /// <summary>
        /// Ims the font atlas add custom rect regular using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ImFontAtlas_AddCustomRectRegular(ImFontAtlas* self, int width, int height);
        /// <summary>
        /// Ims the font atlas add font using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="font_cfg">The font cfg</param>
        /// <returns>The im font</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImFont* ImFontAtlas_AddFont(ImFontAtlas* self, ImFontConfig* font_cfg);
        /// <summary>
        /// Ims the font atlas add font default using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="font_cfg">The font cfg</param>
        /// <returns>The im font</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImFont* ImFontAtlas_AddFontDefault(ImFontAtlas* self, ImFontConfig* font_cfg);
        /// <summary>
        /// Ims the font atlas add font from file ttf using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="filename">The filename</param>
        /// <param name="size_pixels">The size pixels</param>
        /// <param name="font_cfg">The font cfg</param>
        /// <param name="glyph_ranges">The glyph ranges</param>
        /// <returns>The im font</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImFont* ImFontAtlas_AddFontFromFileTTF(ImFontAtlas* self, byte* filename, float size_pixels, ImFontConfig* font_cfg, ushort* glyph_ranges);
        /// <summary>
        /// Ims the font atlas add font from memory compressed base 85 ttf using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="compressed_font_data_base85">The compressed font data base85</param>
        /// <param name="size_pixels">The size pixels</param>
        /// <param name="font_cfg">The font cfg</param>
        /// <param name="glyph_ranges">The glyph ranges</param>
        /// <returns>The im font</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImFont* ImFontAtlas_AddFontFromMemoryCompressedBase85TTF(ImFontAtlas* self, byte* compressed_font_data_base85, float size_pixels, ImFontConfig* font_cfg, ushort* glyph_ranges);
        /// <summary>
        /// Ims the font atlas add font from memory compressed ttf using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="compressed_font_data">The compressed font data</param>
        /// <param name="compressed_font_size">The compressed font size</param>
        /// <param name="size_pixels">The size pixels</param>
        /// <param name="font_cfg">The font cfg</param>
        /// <param name="glyph_ranges">The glyph ranges</param>
        /// <returns>The im font</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImFont* ImFontAtlas_AddFontFromMemoryCompressedTTF(ImFontAtlas* self, void* compressed_font_data, int compressed_font_size, float size_pixels, ImFontConfig* font_cfg, ushort* glyph_ranges);
        /// <summary>
        /// Ims the font atlas add font from memory ttf using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="font_data">The font data</param>
        /// <param name="font_size">The font size</param>
        /// <param name="size_pixels">The size pixels</param>
        /// <param name="font_cfg">The font cfg</param>
        /// <param name="glyph_ranges">The glyph ranges</param>
        /// <returns>The im font</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImFont* ImFontAtlas_AddFontFromMemoryTTF(ImFontAtlas* self, void* font_data, int font_size, float size_pixels, ImFontConfig* font_cfg, ushort* glyph_ranges);
        /// <summary>
        /// Ims the font atlas build using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImFontAtlas_Build(ImFontAtlas* self);
        /// <summary>
        /// Ims the font atlas calc custom rect uv using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="rect">The rect</param>
        /// <param name="out_uv_min">The out uv min</param>
        /// <param name="out_uv_max">The out uv max</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFontAtlas_CalcCustomRectUV(ImFontAtlas* self, ImFontAtlasCustomRect* rect, Vector2* out_uv_min, Vector2* out_uv_max);
        /// <summary>
        /// Ims the font atlas clear using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFontAtlas_Clear(ImFontAtlas* self);
        /// <summary>
        /// Ims the font atlas clear fonts using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFontAtlas_ClearFonts(ImFontAtlas* self);
        /// <summary>
        /// Ims the font atlas clear input data using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFontAtlas_ClearInputData(ImFontAtlas* self);
        /// <summary>
        /// Ims the font atlas clear tex data using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFontAtlas_ClearTexData(ImFontAtlas* self);
        /// <summary>
        /// Ims the font atlas destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFontAtlas_destroy(ImFontAtlas* self);
        /// <summary>
        /// Ims the font atlas get custom rect by index using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="index">The index</param>
        /// <returns>The im font atlas custom rect</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImFontAtlasCustomRect* ImFontAtlas_GetCustomRectByIndex(ImFontAtlas* self, int index);
        /// <summary>
        /// Ims the font atlas get glyph ranges chinese full using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The ushort</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort* ImFontAtlas_GetGlyphRangesChineseFull(ImFontAtlas* self);
        /// <summary>
        /// Ims the font atlas get glyph ranges chinese simplified common using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The ushort</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort* ImFontAtlas_GetGlyphRangesChineseSimplifiedCommon(ImFontAtlas* self);
        /// <summary>
        /// Ims the font atlas get glyph ranges cyrillic using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The ushort</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort* ImFontAtlas_GetGlyphRangesCyrillic(ImFontAtlas* self);
        /// <summary>
        /// Ims the font atlas get glyph ranges default using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The ushort</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort* ImFontAtlas_GetGlyphRangesDefault(ImFontAtlas* self);
        /// <summary>
        /// Ims the font atlas get glyph ranges greek using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The ushort</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort* ImFontAtlas_GetGlyphRangesGreek(ImFontAtlas* self);
        /// <summary>
        /// Ims the font atlas get glyph ranges japanese using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The ushort</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort* ImFontAtlas_GetGlyphRangesJapanese(ImFontAtlas* self);
        /// <summary>
        /// Ims the font atlas get glyph ranges korean using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The ushort</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort* ImFontAtlas_GetGlyphRangesKorean(ImFontAtlas* self);
        /// <summary>
        /// Ims the font atlas get glyph ranges thai using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The ushort</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort* ImFontAtlas_GetGlyphRangesThai(ImFontAtlas* self);
        /// <summary>
        /// Ims the font atlas get glyph ranges vietnamese using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The ushort</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort* ImFontAtlas_GetGlyphRangesVietnamese(ImFontAtlas* self);
        /// <summary>
        /// Ims the font atlas get mouse cursor tex data using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="cursor">The cursor</param>
        /// <param name="out_offset">The out offset</param>
        /// <param name="out_size">The out size</param>
        /// <param name="out_uv_border">The out uv border</param>
        /// <param name="out_uv_fill">The out uv fill</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImFontAtlas_GetMouseCursorTexData(ImFontAtlas* self, ImGuiMouseCursor cursor, Vector2* out_offset, Vector2* out_size, Vector2* out_uv_border, Vector2* out_uv_fill);
        /// <summary>
        /// Ims the font atlas get tex data as alpha 8 using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="out_pixels">The out pixels</param>
        /// <param name="out_width">The out width</param>
        /// <param name="out_height">The out height</param>
        /// <param name="out_bytes_per_pixel">The out bytes per pixel</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFontAtlas_GetTexDataAsAlpha8(ImFontAtlas* self, byte** out_pixels, int* out_width, int* out_height, int* out_bytes_per_pixel);
        /// <summary>
        /// Ims the font atlas get tex data as alpha 8 using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="out_pixels">The out pixels</param>
        /// <param name="out_width">The out width</param>
        /// <param name="out_height">The out height</param>
        /// <param name="out_bytes_per_pixel">The out bytes per pixel</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFontAtlas_GetTexDataAsAlpha8(ImFontAtlas* self, IntPtr* out_pixels, int* out_width, int* out_height, int* out_bytes_per_pixel);
        /// <summary>
        /// Ims the font atlas get tex data as rgba 32 using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="out_pixels">The out pixels</param>
        /// <param name="out_width">The out width</param>
        /// <param name="out_height">The out height</param>
        /// <param name="out_bytes_per_pixel">The out bytes per pixel</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFontAtlas_GetTexDataAsRGBA32(ImFontAtlas* self, byte** out_pixels, int* out_width, int* out_height, int* out_bytes_per_pixel);
        /// <summary>
        /// Ims the font atlas get tex data as rgba 32 using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="out_pixels">The out pixels</param>
        /// <param name="out_width">The out width</param>
        /// <param name="out_height">The out height</param>
        /// <param name="out_bytes_per_pixel">The out bytes per pixel</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFontAtlas_GetTexDataAsRGBA32(ImFontAtlas* self, IntPtr* out_pixels, int* out_width, int* out_height, int* out_bytes_per_pixel);
        /// <summary>
        /// Ims the font atlas im font atlas
        /// </summary>
        /// <returns>The im font atlas</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImFontAtlas* ImFontAtlas_ImFontAtlas();
        /// <summary>
        /// Ims the font atlas is built using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImFontAtlas_IsBuilt(ImFontAtlas* self);
        /// <summary>
        /// Ims the font atlas set tex id using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="id">The id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFontAtlas_SetTexID(ImFontAtlas* self, IntPtr id);
        /// <summary>
        /// Ims the font atlas custom rect destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFontAtlasCustomRect_destroy(ImFontAtlasCustomRect* self);
        /// <summary>
        /// Ims the font atlas custom rect im font atlas custom rect
        /// </summary>
        /// <returns>The im font atlas custom rect</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImFontAtlasCustomRect* ImFontAtlasCustomRect_ImFontAtlasCustomRect();
        /// <summary>
        /// Ims the font atlas custom rect is packed using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImFontAtlasCustomRect_IsPacked(ImFontAtlasCustomRect* self);
        /// <summary>
        /// Ims the font config destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFontConfig_destroy(ImFontConfig* self);
        /// <summary>
        /// Ims the font config im font config
        /// </summary>
        /// <returns>The im font config</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImFontConfig* ImFontConfig_ImFontConfig();
        /// <summary>
        /// Ims the font glyph ranges builder add char using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="c">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFontGlyphRangesBuilder_AddChar(ImFontGlyphRangesBuilder* self, ushort c);
        /// <summary>
        /// Ims the font glyph ranges builder add ranges using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="ranges">The ranges</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFontGlyphRangesBuilder_AddRanges(ImFontGlyphRangesBuilder* self, ushort* ranges);
        /// <summary>
        /// Ims the font glyph ranges builder add text using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="text">The text</param>
        /// <param name="text_end">The text end</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFontGlyphRangesBuilder_AddText(ImFontGlyphRangesBuilder* self, byte* text, byte* text_end);
        /// <summary>
        /// Ims the font glyph ranges builder build ranges using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="out_ranges">The out ranges</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFontGlyphRangesBuilder_BuildRanges(ImFontGlyphRangesBuilder* self, ImVector* out_ranges);
        /// <summary>
        /// Ims the font glyph ranges builder clear using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFontGlyphRangesBuilder_Clear(ImFontGlyphRangesBuilder* self);
        /// <summary>
        /// Ims the font glyph ranges builder destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFontGlyphRangesBuilder_destroy(ImFontGlyphRangesBuilder* self);
        /// <summary>
        /// Ims the font glyph ranges builder get bit using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="n">The </param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImFontGlyphRangesBuilder_GetBit(ImFontGlyphRangesBuilder* self, uint n);
        /// <summary>
        /// Ims the font glyph ranges builder im font glyph ranges builder
        /// </summary>
        /// <returns>The im font glyph ranges builder</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImFontGlyphRangesBuilder* ImFontGlyphRangesBuilder_ImFontGlyphRangesBuilder();
        /// <summary>
        /// Ims the font glyph ranges builder set bit using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="n">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImFontGlyphRangesBuilder_SetBit(ImFontGlyphRangesBuilder* self, uint n);
        /// <summary>
        /// Ims the gui input text callback data clear selection using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiInputTextCallbackData_ClearSelection(ImGuiInputTextCallbackData* self);
        /// <summary>
        /// Ims the gui input text callback data delete chars using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        /// <param name="bytes_count">The bytes count</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiInputTextCallbackData_DeleteChars(ImGuiInputTextCallbackData* self, int pos, int bytes_count);
        /// <summary>
        /// Ims the gui input text callback data destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiInputTextCallbackData_destroy(ImGuiInputTextCallbackData* self);
        /// <summary>
        /// Ims the gui input text callback data has selection using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImGuiInputTextCallbackData_HasSelection(ImGuiInputTextCallbackData* self);
        /// <summary>
        /// Ims the gui input text callback data im gui input text callback data
        /// </summary>
        /// <returns>The im gui input text callback data</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiInputTextCallbackData* ImGuiInputTextCallbackData_ImGuiInputTextCallbackData();
        /// <summary>
        /// Ims the gui input text callback data insert chars using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        /// <param name="text">The text</param>
        /// <param name="text_end">The text end</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiInputTextCallbackData_InsertChars(ImGuiInputTextCallbackData* self, int pos, byte* text, byte* text_end);
        /// <summary>
        /// Ims the gui input text callback data select all using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiInputTextCallbackData_SelectAll(ImGuiInputTextCallbackData* self);
        /// <summary>
        /// Ims the gui io add focus event using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="focused">The focused</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiIO_AddFocusEvent(ImGuiIO* self, byte focused);
        /// <summary>
        /// Ims the gui io add input character using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="c">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiIO_AddInputCharacter(ImGuiIO* self, uint c);
        /// <summary>
        /// Ims the gui io add input characters utf 8 using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="str">The str</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiIO_AddInputCharactersUTF8(ImGuiIO* self, byte* str);
        /// <summary>
        /// Ims the gui io add input character utf 16 using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="c">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiIO_AddInputCharacterUTF16(ImGuiIO* self, ushort c);
        /// <summary>
        /// Ims the gui io add key analog event using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="down">The down</param>
        /// <param name="v">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiIO_AddKeyAnalogEvent(ImGuiIO* self, ImGuiKey key, byte down, float v);
        /// <summary>
        /// Ims the gui io add key event using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="down">The down</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiIO_AddKeyEvent(ImGuiIO* self, ImGuiKey key, byte down);
        /// <summary>
        /// Ims the gui io add mouse button event using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="button">The button</param>
        /// <param name="down">The down</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiIO_AddMouseButtonEvent(ImGuiIO* self, int button, byte down);
        /// <summary>
        /// Ims the gui io add mouse pos event using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiIO_AddMousePosEvent(ImGuiIO* self, float x, float y);
        /// <summary>
        /// Ims the gui io add mouse viewport event using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="id">The id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiIO_AddMouseViewportEvent(ImGuiIO* self, uint id);
        /// <summary>
        /// Ims the gui io add mouse wheel event using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="wh_x">The wh</param>
        /// <param name="wh_y">The wh</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiIO_AddMouseWheelEvent(ImGuiIO* self, float wh_x, float wh_y);
        /// <summary>
        /// Ims the gui io clear input characters using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiIO_ClearInputCharacters(ImGuiIO* self);
        /// <summary>
        /// Ims the gui io clear input keys using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiIO_ClearInputKeys(ImGuiIO* self);
        /// <summary>
        /// Ims the gui io destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiIO_destroy(ImGuiIO* self);
        /// <summary>
        /// Ims the gui io im gui io
        /// </summary>
        /// <returns>The im gui io</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiIO* ImGuiIO_ImGuiIO();
        /// <summary>
        /// Ims the gui io set app accepting events using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="accepting_events">The accepting events</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiIO_SetAppAcceptingEvents(ImGuiIO* self, byte accepting_events);
        /// <summary>
        /// Ims the gui io set key event native data using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="native_keycode">The native keycode</param>
        /// <param name="native_scancode">The native scancode</param>
        /// <param name="native_legacy_index">The native legacy index</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiIO_SetKeyEventNativeData(ImGuiIO* self, ImGuiKey key, int native_keycode, int native_scancode, int native_legacy_index);
        /// <summary>
        /// Ims the gui list clipper begin using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="items_count">The items count</param>
        /// <param name="items_height">The items height</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiListClipper_Begin(ImGuiListClipper* self, int items_count, float items_height);
        /// <summary>
        /// Ims the gui list clipper destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiListClipper_destroy(ImGuiListClipper* self);
        /// <summary>
        /// Ims the gui list clipper end using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiListClipper_End(ImGuiListClipper* self);
        /// <summary>
        /// Ims the gui list clipper force display range by indices using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="item_min">The item min</param>
        /// <param name="item_max">The item max</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiListClipper_ForceDisplayRangeByIndices(ImGuiListClipper* self, int item_min, int item_max);
        /// <summary>
        /// Ims the gui list clipper im gui list clipper
        /// </summary>
        /// <returns>The im gui list clipper</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiListClipper* ImGuiListClipper_ImGuiListClipper();
        /// <summary>
        /// Ims the gui list clipper step using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImGuiListClipper_Step(ImGuiListClipper* self);
        /// <summary>
        /// Ims the gui once upon a frame destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiOnceUponAFrame_destroy(ImGuiOnceUponAFrame* self);
        /// <summary>
        /// Ims the gui once upon a frame im gui once upon a frame
        /// </summary>
        /// <returns>The im gui once upon frame</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiOnceUponAFrame* ImGuiOnceUponAFrame_ImGuiOnceUponAFrame();
        /// <summary>
        /// Ims the gui payload clear using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiPayload_Clear(ImGuiPayload* self);
        /// <summary>
        /// Ims the gui payload destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiPayload_destroy(ImGuiPayload* self);
        /// <summary>
        /// Ims the gui payload im gui payload
        /// </summary>
        /// <returns>The im gui payload</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiPayload* ImGuiPayload_ImGuiPayload();
        /// <summary>
        /// Ims the gui payload is data type using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="type">The type</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImGuiPayload_IsDataType(ImGuiPayload* self, byte* type);
        /// <summary>
        /// Ims the gui payload is delivery using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImGuiPayload_IsDelivery(ImGuiPayload* self);
        /// <summary>
        /// Ims the gui payload is preview using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImGuiPayload_IsPreview(ImGuiPayload* self);
        /// <summary>
        /// Ims the gui platform ime data destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiPlatformImeData_destroy(ImGuiPlatformImeData* self);
        /// <summary>
        /// Ims the gui platform ime data im gui platform ime data
        /// </summary>
        /// <returns>The im gui platform ime data</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiPlatformImeData* ImGuiPlatformImeData_ImGuiPlatformImeData();
        /// <summary>
        /// Ims the gui platform io destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiPlatformIO_destroy(ImGuiPlatformIO* self);
        /// <summary>
        /// Ims the gui platform io im gui platform io
        /// </summary>
        /// <returns>The im gui platform io</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiPlatformIO* ImGuiPlatformIO_ImGuiPlatformIO();
        /// <summary>
        /// Ims the gui platform monitor destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiPlatformMonitor_destroy(ImGuiPlatformMonitor* self);
        /// <summary>
        /// Ims the gui platform monitor im gui platform monitor
        /// </summary>
        /// <returns>The im gui platform monitor</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiPlatformMonitor* ImGuiPlatformMonitor_ImGuiPlatformMonitor();
        /// <summary>
        /// Ims the gui storage build sort by key using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiStorage_BuildSortByKey(ImGuiStorage* self);
        /// <summary>
        /// Ims the gui storage clear using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiStorage_Clear(ImGuiStorage* self);
        /// <summary>
        /// Ims the gui storage get bool using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="default_val">The default val</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImGuiStorage_GetBool(ImGuiStorage* self, uint key, byte default_val);
        /// <summary>
        /// Ims the gui storage get bool ref using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="default_val">The default val</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* ImGuiStorage_GetBoolRef(ImGuiStorage* self, uint key, byte default_val);
        /// <summary>
        /// Ims the gui storage get float using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="default_val">The default val</param>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern float ImGuiStorage_GetFloat(ImGuiStorage* self, uint key, float default_val);
        /// <summary>
        /// Ims the gui storage get float ref using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="default_val">The default val</param>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern float* ImGuiStorage_GetFloatRef(ImGuiStorage* self, uint key, float default_val);
        /// <summary>
        /// Ims the gui storage get int using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="default_val">The default val</param>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ImGuiStorage_GetInt(ImGuiStorage* self, uint key, int default_val);
        /// <summary>
        /// Ims the gui storage get int ref using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="default_val">The default val</param>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern int* ImGuiStorage_GetIntRef(ImGuiStorage* self, uint key, int default_val);
        /// <summary>
        /// Ims the gui storage get void ptr using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <returns>The void</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* ImGuiStorage_GetVoidPtr(ImGuiStorage* self, uint key);
        /// <summary>
        /// Ims the gui storage get void ptr ref using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="default_val">The default val</param>
        /// <returns>The void</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void** ImGuiStorage_GetVoidPtrRef(ImGuiStorage* self, uint key, void* default_val);
        /// <summary>
        /// Ims the gui storage set all int using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="val">The val</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiStorage_SetAllInt(ImGuiStorage* self, int val);
        /// <summary>
        /// Ims the gui storage set bool using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="val">The val</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiStorage_SetBool(ImGuiStorage* self, uint key, byte val);
        /// <summary>
        /// Ims the gui storage set float using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="val">The val</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiStorage_SetFloat(ImGuiStorage* self, uint key, float val);
        /// <summary>
        /// Ims the gui storage set int using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="val">The val</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiStorage_SetInt(ImGuiStorage* self, uint key, int val);
        /// <summary>
        /// Ims the gui storage set void ptr using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="val">The val</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiStorage_SetVoidPtr(ImGuiStorage* self, uint key, void* val);
        /// <summary>
        /// Ims the gui storage pair destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiStoragePair_destroy(ImGuiStoragePair* self);
        /// <summary>
        /// Ims the gui storage pair im gui storage pair int using the specified  key
        /// </summary>
        /// <param name="_key">The key</param>
        /// <param name="_val_i">The val</param>
        /// <returns>The im gui storage pair</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiStoragePair* ImGuiStoragePair_ImGuiStoragePair_Int(uint _key, int _val_i);
        /// <summary>
        /// Ims the gui storage pair im gui storage pair float using the specified  key
        /// </summary>
        /// <param name="_key">The key</param>
        /// <param name="_val_f">The val</param>
        /// <returns>The im gui storage pair</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiStoragePair* ImGuiStoragePair_ImGuiStoragePair_Float(uint _key, float _val_f);
        /// <summary>
        /// Ims the gui storage pair im gui storage pair ptr using the specified  key
        /// </summary>
        /// <param name="_key">The key</param>
        /// <param name="_val_p">The val</param>
        /// <returns>The im gui storage pair</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiStoragePair* ImGuiStoragePair_ImGuiStoragePair_Ptr(uint _key, void* _val_p);
        /// <summary>
        /// Ims the gui style destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiStyle_destroy(ImGuiStyle* self);
        /// <summary>
        /// Ims the gui style im gui style
        /// </summary>
        /// <returns>The im gui style</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiStyle* ImGuiStyle_ImGuiStyle();
        /// <summary>
        /// Ims the gui style scale all sizes using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="scale_factor">The scale factor</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiStyle_ScaleAllSizes(ImGuiStyle* self, float scale_factor);
        /// <summary>
        /// Ims the gui table column sort specs destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiTableColumnSortSpecs_destroy(ImGuiTableColumnSortSpecs* self);
        /// <summary>
        /// Ims the gui table column sort specs im gui table column sort specs
        /// </summary>
        /// <returns>The im gui table column sort specs</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiTableColumnSortSpecs* ImGuiTableColumnSortSpecs_ImGuiTableColumnSortSpecs();
        /// <summary>
        /// Ims the gui table sort specs destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiTableSortSpecs_destroy(ImGuiTableSortSpecs* self);
        /// <summary>
        /// Ims the gui table sort specs im gui table sort specs
        /// </summary>
        /// <returns>The im gui table sort specs</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiTableSortSpecs* ImGuiTableSortSpecs_ImGuiTableSortSpecs();
        /// <summary>
        /// Ims the gui text buffer append using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="str">The str</param>
        /// <param name="str_end">The str end</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiTextBuffer_append(ImGuiTextBuffer* self, byte* str, byte* str_end);
        /// <summary>
        /// Ims the gui text buffer appendf using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="fmt">The fmt</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiTextBuffer_appendf(ImGuiTextBuffer* self, byte* fmt);
        /// <summary>
        /// Ims the gui text buffer begin using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* ImGuiTextBuffer_begin(ImGuiTextBuffer* self);
        /// <summary>
        /// Ims the gui text buffer c str using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* ImGuiTextBuffer_c_str(ImGuiTextBuffer* self);
        /// <summary>
        /// Ims the gui text buffer clear using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiTextBuffer_clear(ImGuiTextBuffer* self);
        /// <summary>
        /// Ims the gui text buffer destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiTextBuffer_destroy(ImGuiTextBuffer* self);
        /// <summary>
        /// Ims the gui text buffer empty using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImGuiTextBuffer_empty(ImGuiTextBuffer* self);
        /// <summary>
        /// Ims the gui text buffer end using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* ImGuiTextBuffer_end(ImGuiTextBuffer* self);
        /// <summary>
        /// Ims the gui text buffer im gui text buffer
        /// </summary>
        /// <returns>The im gui text buffer</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiTextBuffer* ImGuiTextBuffer_ImGuiTextBuffer();
        /// <summary>
        /// Ims the gui text buffer reserve using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="capacity">The capacity</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiTextBuffer_reserve(ImGuiTextBuffer* self, int capacity);
        /// <summary>
        /// Ims the gui text buffer size using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ImGuiTextBuffer_size(ImGuiTextBuffer* self);
        /// <summary>
        /// Ims the gui text filter build using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiTextFilter_Build(ImGuiTextFilter* self);
        /// <summary>
        /// Ims the gui text filter clear using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiTextFilter_Clear(ImGuiTextFilter* self);
        /// <summary>
        /// Ims the gui text filter destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiTextFilter_destroy(ImGuiTextFilter* self);
        /// <summary>
        /// Ims the gui text filter draw using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="label">The label</param>
        /// <param name="width">The width</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImGuiTextFilter_Draw(ImGuiTextFilter* self, byte* label, float width);
        /// <summary>
        /// Ims the gui text filter im gui text filter using the specified default filter
        /// </summary>
        /// <param name="default_filter">The default filter</param>
        /// <returns>The im gui text filter</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiTextFilter* ImGuiTextFilter_ImGuiTextFilter(byte* default_filter);
        /// <summary>
        /// Ims the gui text filter is active using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImGuiTextFilter_IsActive(ImGuiTextFilter* self);
        /// <summary>
        /// Ims the gui text filter pass filter using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="text">The text</param>
        /// <param name="text_end">The text end</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImGuiTextFilter_PassFilter(ImGuiTextFilter* self, byte* text, byte* text_end);
        /// <summary>
        /// Ims the gui text range destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiTextRange_destroy(ImGuiTextRange* self);
        /// <summary>
        /// Ims the gui text range empty using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImGuiTextRange_empty(ImGuiTextRange* self);
        /// <summary>
        /// Ims the gui text range im gui text range nil
        /// </summary>
        /// <returns>The im gui text range</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiTextRange* ImGuiTextRange_ImGuiTextRange_Nil();
        /// <summary>
        /// Ims the gui text range im gui text range str using the specified  b
        /// </summary>
        /// <param name="_b">The </param>
        /// <param name="_e">The </param>
        /// <returns>The im gui text range</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiTextRange* ImGuiTextRange_ImGuiTextRange_Str(byte* _b, byte* _e);
        /// <summary>
        /// Ims the gui text range split using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="separator">The separator</param>
        /// <param name="out">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiTextRange_split(ImGuiTextRange* self, byte separator, ImVector* @out);
        /// <summary>
        /// Ims the gui viewport destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiViewport_destroy(ImGuiViewport* self);
        /// <summary>
        /// Ims the gui viewport get center using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiViewport_GetCenter(Vector2* pOut, ImGuiViewport* self);
        /// <summary>
        /// Ims the gui viewport get work center using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiViewport_GetWorkCenter(Vector2* pOut, ImGuiViewport* self);
        /// <summary>
        /// Ims the gui viewport im gui viewport
        /// </summary>
        /// <returns>The im gui viewport</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiViewport* ImGuiViewport_ImGuiViewport();
        /// <summary>
        /// Ims the gui window class destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiWindowClass_destroy(ImGuiWindowClass* self);
        /// <summary>
        /// Ims the gui window class im gui window
        /// </summary>
        /// <returns>The im gui window class</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImGuiWindowClass* ImGuiWindowClass_ImGuiWindowClass();
        /// <summary>
        /// Ims the vec 2 destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImVec2_destroy(Vector2* self);
        /// <summary>
        /// Ims the vec 2 im vec 2 nil
        /// </summary>
        /// <returns>The vector</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2* ImVec2_ImVec2_Nil();
        /// <summary>
        /// Ims the vec 2 im vec 2 float using the specified  x
        /// </summary>
        /// <param name="_x">The </param>
        /// <param name="_y">The </param>
        /// <returns>The vector</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2* ImVec2_ImVec2_Float(float _x, float _y);
        /// <summary>
        /// Ims the vec 4 destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImVec4_destroy(Vector4* self);
        /// <summary>
        /// Ims the vec 4 im vec 4 nil
        /// </summary>
        /// <returns>The vector</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector4* ImVec4_ImVec4_Nil();
        /// <summary>
        /// Ims the vec 4 im vec 4 float using the specified  x
        /// </summary>
        /// <param name="_x">The </param>
        /// <param name="_y">The </param>
        /// <param name="_z">The </param>
        /// <param name="_w">The </param>
        /// <returns>The vector</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector4* ImVec4_ImVec4_Float(float _x, float _y, float _z, float _w);
    }
}
