// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP7.cs
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
using System.Text;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui class
    /// </summary>
    public static partial class ImGui
    {
        /// <summary>
        ///     Describes whether menu item
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="shortcut">The shortcut</param>
        /// <param name="pSelected">The selected</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The bool</returns>
        public static bool MenuItem(string label, string shortcut, ref bool pSelected, bool enabled)
        {
            byte ret = ImGuiNative.igMenuItem_BoolPtr(Encoding.UTF8.GetBytes(label), Encoding.UTF8.GetBytes(shortcut), pSelected, enabled);
            return ret != 0;
        }

        /// <summary>
        ///     News the frame
        /// </summary>
        public static void NewFrame()
        {
            ImGuiNative.igNewFrame();
        }

        /// <summary>
        ///     News the line
        /// </summary>
        public static void NewLine()
        {
            ImGuiNative.igNewLine();
        }

        /// <summary>
        ///     Nexts the column
        /// </summary>
        public static void NextColumn()
        {
            ImGuiNative.igNextColumn();
        }

        /// <summary>
        ///     Opens the popup using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        public static void OpenPopup(string strId)
        {
            ImGuiNative.igOpenPopup_Str(Encoding.UTF8.GetBytes(strId), 0);
        }

        /// <summary>
        ///     Opens the popup using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="popupFlags">The popup flags</param>
        public static void OpenPopup(string strId, ImGuiPopupFlags popupFlags)
        {
            ImGuiNative.igOpenPopup_Str(Encoding.UTF8.GetBytes(strId), popupFlags);
        }

        /// <summary>
        ///     Opens the popup using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        public static void OpenPopup(uint id)
        {
            ImGuiPopupFlags popupFlags = 0;
            ImGuiNative.igOpenPopup_ID(id, popupFlags);
        }

        /// <summary>
        ///     Opens the popup using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="popupFlags">The popup flags</param>
        public static void OpenPopup(uint id, ImGuiPopupFlags popupFlags)
        {
            ImGuiNative.igOpenPopup_ID(id, popupFlags);
        }

        /// <summary>
        ///     Opens the popup on item click
        /// </summary>
        public static void OpenPopupOnItemClick()
        {
            ImGuiPopupFlags popupFlags = (ImGuiPopupFlags) 1;
            ImGuiNative.igOpenPopupOnItemClick(Encoding.UTF8.GetBytes(""), popupFlags);
        }

        /// <summary>
        ///     Opens the popup on item click using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        public static void OpenPopupOnItemClick(string strId)
        {
            ImGuiNative.igOpenPopupOnItemClick(Encoding.UTF8.GetBytes(strId), 0);
        }

        /// <summary>
        ///     Opens the popup on item click using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="popupFlags">The popup flags</param>
        public static void OpenPopupOnItemClick(string strId, ImGuiPopupFlags popupFlags)
        {
            ImGuiNative.igOpenPopupOnItemClick(Encoding.UTF8.GetBytes(strId), popupFlags);
        }

        /// <summary>
        ///     Plots the histogram using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        public static void PlotHistogram(string label, ref float values, int valuesCount)
        {
            ImGuiNative.igPlotHistogram_FloatPtr(Encoding.UTF8.GetBytes(label), values, valuesCount, 0, null, float.MaxValue, float.MaxValue, new Vector2F(), sizeof(float));
        }

        /// <summary>
        ///     Plots the histogram using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        /// <param name="valuesOffset">The values offset</param>
        public static void PlotHistogram(string label, ref float values, int valuesCount, int valuesOffset)
        {
            ImGuiNative.igPlotHistogram_FloatPtr(Encoding.UTF8.GetBytes(label), values, valuesCount, valuesOffset, null, float.MaxValue, float.MaxValue, new Vector2F(), sizeof(float));
        }

        /// <summary>
        ///     Plots the histogram using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        /// <param name="valuesOffset">The values offset</param>
        /// <param name="overlayText">The overlay text</param>
        public static void PlotHistogram(string label, ref float values, int valuesCount, int valuesOffset, string overlayText)
        {
            ImGuiNative.igPlotHistogram_FloatPtr(Encoding.UTF8.GetBytes(label), values, valuesCount, valuesOffset, Encoding.UTF8.GetBytes(overlayText), float.MaxValue, float.MaxValue, new Vector2F(), sizeof(float));
        }

        /// <summary>
        ///     Plots the histogram using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        /// <param name="valuesOffset">The values offset</param>
        /// <param name="overlayText">The overlay text</param>
        /// <param name="scaleMin">The scale min</param>
        public static void PlotHistogram(string label, ref float values, int valuesCount, int valuesOffset, string overlayText, float scaleMin)
        {
            ImGuiNative.igPlotHistogram_FloatPtr(Encoding.UTF8.GetBytes(label), values, valuesCount, valuesOffset, Encoding.UTF8.GetBytes(overlayText), scaleMin, float.MaxValue, new Vector2F(), sizeof(float));
        }

        /// <summary>
        ///     Plots the histogram using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        /// <param name="valuesOffset">The values offset</param>
        /// <param name="overlayText">The overlay text</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        public static void PlotHistogram(string label, ref float values, int valuesCount, int valuesOffset, string overlayText, float scaleMin, float scaleMax)
        {
            ImGuiNative.igPlotHistogram_FloatPtr(Encoding.UTF8.GetBytes(label), values, valuesCount, valuesOffset, Encoding.UTF8.GetBytes(overlayText), scaleMin, scaleMax, new Vector2F(), sizeof(float));
        }

        /// <summary>
        ///     Plots the histogram using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        /// <param name="valuesOffset">The values offset</param>
        /// <param name="overlayText">The overlay text</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="graphSize">The graph size</param>
        public static void PlotHistogram(string label, ref float values, int valuesCount, int valuesOffset, string overlayText, float scaleMin, float scaleMax, Vector2F graphSize)
        {
            ImGuiNative.igPlotHistogram_FloatPtr(Encoding.UTF8.GetBytes(label), values, valuesCount, valuesOffset, Encoding.UTF8.GetBytes(overlayText), scaleMin, scaleMax, graphSize, sizeof(float));
        }

        /// <summary>
        ///     Plots the histogram using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        /// <param name="valuesOffset">The values offset</param>
        /// <param name="overlayText">The overlay text</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="graphSize">The graph size</param>
        /// <param name="stride">The stride</param>
        public static void PlotHistogram(string label, ref float values, int valuesCount, int valuesOffset, string overlayText, float scaleMin, float scaleMax, Vector2F graphSize, int stride)
        {
            ImGuiNative.igPlotHistogram_FloatPtr(Encoding.UTF8.GetBytes(label), values, valuesCount, valuesOffset, Encoding.UTF8.GetBytes(overlayText), scaleMin, scaleMax, graphSize, stride);
        }

        /// <summary>
        ///     Plots the lines using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        public static void PlotLines(string label, ref float values, int valuesCount)
        {
            ImGuiNative.igPlotLines_FloatPtr(Encoding.UTF8.GetBytes(label), values, valuesCount, 0, null, float.MaxValue, float.MaxValue, new Vector2F(), sizeof(float));
        }

        /// <summary>
        ///     Plots the lines using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        /// <param name="valuesOffset">The values offset</param>
        public static void PlotLines(string label, ref float values, int valuesCount, int valuesOffset)
        {
            ImGuiNative.igPlotLines_FloatPtr(Encoding.UTF8.GetBytes(label), values, valuesCount, valuesOffset, null, float.MaxValue, float.MaxValue, new Vector2F(), sizeof(float));
        }

        /// <summary>
        ///     Plots the lines using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        /// <param name="valuesOffset">The values offset</param>
        /// <param name="overlayText">The overlay text</param>
        public static void PlotLines(string label, ref float values, int valuesCount, int valuesOffset, string overlayText)
        {
            ImGuiNative.igPlotLines_FloatPtr(Encoding.UTF8.GetBytes(label), values, valuesCount, valuesOffset, Encoding.UTF8.GetBytes(overlayText), float.MaxValue, float.MaxValue, new Vector2F(), sizeof(float));
        }

        /// <summary>
        ///     Plots the lines using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        /// <param name="valuesOffset">The values offset</param>
        /// <param name="overlayText">The overlay text</param>
        /// <param name="scaleMin">The scale min</param>
        public static void PlotLines(string label, ref float values, int valuesCount, int valuesOffset, string overlayText, float scaleMin)
        {
            ImGuiNative.igPlotLines_FloatPtr(Encoding.UTF8.GetBytes(label), values, valuesCount, valuesOffset, Encoding.UTF8.GetBytes(overlayText), scaleMin, float.MaxValue, new Vector2F(), sizeof(float));
        }

        /// <summary>
        ///     Plots the lines using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        /// <param name="valuesOffset">The values offset</param>
        /// <param name="overlayText">The overlay text</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        public static void PlotLines(string label, ref float values, int valuesCount, int valuesOffset, string overlayText, float scaleMin, float scaleMax)
        {
            ImGuiNative.igPlotLines_FloatPtr(Encoding.UTF8.GetBytes(label), values, valuesCount, valuesOffset, Encoding.UTF8.GetBytes(overlayText), scaleMin, scaleMax, new Vector2F(), sizeof(float));
        }

        /// <summary>
        ///     Plots the lines using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        /// <param name="valuesOffset">The values offset</param>
        /// <param name="overlayText">The overlay text</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="graphSize">The graph size</param>
        public static void PlotLines(string label, ref float values, int valuesCount, int valuesOffset, string overlayText, float scaleMin, float scaleMax, Vector2F graphSize)
        {
            ImGuiNative.igPlotLines_FloatPtr(Encoding.UTF8.GetBytes(label), values, valuesCount, valuesOffset, Encoding.UTF8.GetBytes(overlayText), scaleMin, scaleMax, graphSize, sizeof(float));
        }

        /// <summary>
        ///     Plots the lines using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        /// <param name="valuesOffset">The values offset</param>
        /// <param name="overlayText">The overlay text</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="graphSize">The graph size</param>
        /// <param name="stride">The stride</param>
        public static void PlotLines(string label, ref float values, int valuesCount, int valuesOffset, string overlayText, float scaleMin, float scaleMax, Vector2F graphSize, int stride)
        {
            ImGuiNative.igPlotLines_FloatPtr(Encoding.UTF8.GetBytes(label), values, valuesCount, valuesOffset, Encoding.UTF8.GetBytes(overlayText), scaleMin, scaleMax, graphSize, stride);
        }

        /// <summary>
        ///     Pops the allow keyboard focus
        /// </summary>
        public static void PopAllowKeyboardFocus()
        {
            ImGuiNative.igPopAllowKeyboardFocus();
        }

        /// <summary>
        ///     Pops the button repeat
        /// </summary>
        public static void PopButtonRepeat()
        {
            ImGuiNative.igPopButtonRepeat();
        }

        /// <summary>
        ///     Pops the clip rect
        /// </summary>
        public static void PopClipRect()
        {
            ImGuiNative.igPopClipRect();
        }

        /// <summary>
        ///     Pops the font
        /// </summary>
        public static void PopFont()
        {
            ImGuiNative.igPopFont();
        }

        /// <summary>
        ///     Pops the id
        /// </summary>
        public static void PopId()
        {
            ImGuiNative.igPopID();
        }

        /// <summary>
        ///     Pops the item width
        /// </summary>
        public static void PopItemWidth()
        {
            ImGuiNative.igPopItemWidth();
        }

        /// <summary>
        ///     Pops the style color
        /// </summary>
        public static void PopStyleColor()
        {
            int count = 1;
            ImGuiNative.igPopStyleColor(count);
        }

        /// <summary>
        ///     Pops the style color using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        public static void PopStyleColor(int count)
        {
            ImGuiNative.igPopStyleColor(count);
        }

        /// <summary>
        ///     Pops the style var
        /// </summary>
        public static void PopStyleVar()
        {
            int count = 1;
            ImGuiNative.igPopStyleVar(count);
        }

        /// <summary>
        ///     Pops the style var using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        public static void PopStyleVar(int count)
        {
            ImGuiNative.igPopStyleVar(count);
        }

        /// <summary>
        ///     Pops the text wrap pos
        /// </summary>
        public static void PopTextWrapPos()
        {
            ImGuiNative.igPopTextWrapPos();
        }

        /// <summary>
        ///     Progresses the bar using the specified fraction
        /// </summary>
        /// <param name="fraction">The fraction</param>
        public static void ProgressBar(float fraction)
        {
            Vector2F sizeArg = new Vector2F(-float.MinValue, 0.0f);
            ImGuiNative.igProgressBar(fraction, sizeArg, null);
        }

        /// <summary>
        ///     Progresses the bar using the specified fraction
        /// </summary>
        /// <param name="fraction">The fraction</param>
        /// <param name="sizeArg">The size arg</param>
        public static void ProgressBar(float fraction, Vector2F sizeArg)
        {
            ImGuiNative.igProgressBar(fraction, sizeArg, null);
        }

        /// <summary>
        ///     Progresses the bar using the specified fraction
        /// </summary>
        /// <param name="fraction">The fraction</param>
        /// <param name="sizeArg">The size arg</param>
        /// <param name="overlay">The overlay</param>
        public static void ProgressBar(float fraction, Vector2F sizeArg, string overlay)
        {
            ImGuiNative.igProgressBar(fraction, sizeArg, Encoding.UTF8.GetBytes(overlay));
        }

        /// <summary>
        ///     Pushes the allow keyboard focus using the specified allow keyboard focus
        /// </summary>
        /// <param name="allowKeyboardFocus">The allow keyboard focus</param>
        public static void PushAllowKeyboardFocus(bool allowKeyboardFocus)
        {
            byte nativeAllowKeyboardFocus = allowKeyboardFocus ? (byte) 1 : (byte) 0;
            ImGuiNative.igPushAllowKeyboardFocus(nativeAllowKeyboardFocus);
        }

        /// <summary>
        ///     Pushes the button repeat using the specified repeat
        /// </summary>
        /// <param name="repeat">The repeat</param>
        public static void PushButtonRepeat(bool repeat)
        {
            byte nativeRepeat = repeat ? (byte) 1 : (byte) 0;
            ImGuiNative.igPushButtonRepeat(nativeRepeat);
        }

        /// <summary>
        ///     Pushes the clip rect using the specified clip rect min
        /// </summary>
        /// <param name="clipRectMin">The clip rect min</param>
        /// <param name="clipRectMax">The clip rect max</param>
        /// <param name="intersectWithCurrentClipRect">The intersect with current clip rect</param>
        public static void PushClipRect(Vector2F clipRectMin, Vector2F clipRectMax, bool intersectWithCurrentClipRect)
        {
            byte nativeIntersectWithCurrentClipRect = intersectWithCurrentClipRect ? (byte) 1 : (byte) 0;
            ImGuiNative.igPushClipRect(clipRectMin, clipRectMax, nativeIntersectWithCurrentClipRect);
        }

        /// <summary>
        ///     Pushes the font using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        public static void PushFont(ImFontPtr font)
        {
            ImGuiNative.igPushFont(font.NativePtr);
        }

        /// <summary>
        ///     Pushes the id using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        public static void PushId(string strId)
        {
            ImGuiNative.igPushID_Str(Encoding.UTF8.GetBytes(strId));
        }

        /// <summary>
        ///     Pushes the id using the specified ptr id
        /// </summary>
        /// <param name="ptrId">The ptr id</param>
        public static void PushId(IntPtr ptrId)
        {
            IntPtr nativePtrId = ptrId;
            ImGuiNative.igPushID_Ptr(nativePtrId);
        }

        /// <summary>
        ///     Pushes the id using the specified int id
        /// </summary>
        /// <param name="intId">The int id</param>
        public static void PushId(int intId)
        {
            ImGuiNative.igPushID_Int(intId);
        }

        /// <summary>
        ///     Pushes the item width using the specified item width
        /// </summary>
        /// <param name="itemWidth">The item width</param>
        public static void PushItemWidth(float itemWidth)
        {
            ImGuiNative.igPushItemWidth(itemWidth);
        }

        /// <summary>
        ///     Pushes the style color using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="col">The col</param>
        public static void PushStyleColor(ImGuiCol idx, uint col)
        {
            ImGuiNative.igPushStyleColor_U32(idx, col);
        }

        /// <summary>
        ///     Pushes the style color using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="col">The col</param>
        public static void PushStyleColor(ImGuiCol idx, Vector4F col)
        {
            ImGuiNative.igPushStyleColor_Vec4(idx, col);
        }

        /// <summary>
        ///     Pushes the style var using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="val">The val</param>
        public static void PushStyleVar(ImGuiStyleVar idx, float val)
        {
            ImGuiNative.igPushStyleVar_Float(idx, val);
        }

        /// <summary>
        ///     Pushes the style var using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="val">The val</param>
        public static void PushStyleVar(ImGuiStyleVar idx, Vector2F val)
        {
            ImGuiNative.igPushStyleVar_Vec2(idx, val);
        }

        /// <summary>
        ///     Pushes the text wrap pos
        /// </summary>
        public static void PushTextWrapPos()
        {
            float wrapLocalPosX = 0.0f;
            ImGuiNative.igPushTextWrapPos(wrapLocalPosX);
        }

        /// <summary>
        ///     Pushes the text wrap pos using the specified wrap local pos x
        /// </summary>
        /// <param name="wrapLocalPosX">The wrap local pos</param>
        public static void PushTextWrapPos(float wrapLocalPosX)
        {
            ImGuiNative.igPushTextWrapPos(wrapLocalPosX);
        }

        /// <summary>
        ///     Describes whether radio button
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="active">The active</param>
        /// <returns>The bool</returns>
        public static bool RadioButton(string label, bool active)
        {
            byte ret = ImGuiNative.igRadioButton_Bool(Encoding.UTF8.GetBytes(label), active);

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether radio button
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vButton">The button</param>
        /// <returns>The bool</returns>
        public static bool RadioButton(string label, ref int v, int vButton)
        {
            byte ret = ImGuiNative.igRadioButton_IntPtr(Encoding.UTF8.GetBytes(label), ref v, vButton);

            return ret != 0;
        }

        /// <summary>
        ///     Renders
        /// </summary>
        public static void Render()
        {
            ImGuiNative.igRender();
        }

        /// <summary>
        ///     Renders the platform windows default
        /// </summary>
        public static void RenderPlatformWindowsDefault()
        {
            IntPtr platformRenderArg = IntPtr.Zero;
            IntPtr rendererRenderArg = IntPtr.Zero;
            ImGuiNative.igRenderPlatformWindowsDefault(platformRenderArg, rendererRenderArg);
        }

        /// <summary>
        ///     Renders the platform windows default using the specified platform render arg
        /// </summary>
        /// <param name="platformRenderArg">The platform render arg</param>
        public static void RenderPlatformWindowsDefault(IntPtr platformRenderArg)
        {
            IntPtr nativePlatformRenderArg = platformRenderArg;
            IntPtr rendererRenderArg = IntPtr.Zero;
            ImGuiNative.igRenderPlatformWindowsDefault(nativePlatformRenderArg, rendererRenderArg);
        }

        /// <summary>
        ///     Renders the platform windows default using the specified platform render arg
        /// </summary>
        /// <param name="platformRenderArg">The platform render arg</param>
        /// <param name="rendererRenderArg">The renderer render arg</param>
        public static void RenderPlatformWindowsDefault(IntPtr platformRenderArg, IntPtr rendererRenderArg)
        {
            IntPtr nativePlatformRenderArg = platformRenderArg;
            IntPtr nativeRendererRenderArg = rendererRenderArg;
            ImGuiNative.igRenderPlatformWindowsDefault(nativePlatformRenderArg, nativeRendererRenderArg);
        }

        /// <summary>
        ///     Resets the mouse drag delta
        /// </summary>
        public static void ResetMouseDragDelta()
        {
            ImGuiMouseButton button = 0;
            ImGuiNative.igResetMouseDragDelta(button);
        }

        /// <summary>
        ///     Resets the mouse drag delta using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        public static void ResetMouseDragDelta(ImGuiMouseButton button)
        {
            ImGuiNative.igResetMouseDragDelta(button);
        }

        /// <summary>
        ///     Sames the line
        /// </summary>
        public static void SameLine()
        {
            float offsetFromStartX = 0.0f;
            float spacing = -1.0f;
            ImGuiNative.igSameLine(offsetFromStartX, spacing);
        }

        /// <summary>
        ///     Sames the line using the specified offset from start x
        /// </summary>
        /// <param name="offsetFromStartX">The offset from start</param>
        public static void SameLine(float offsetFromStartX)
        {
            float spacing = -1.0f;
            ImGuiNative.igSameLine(offsetFromStartX, spacing);
        }

        /// <summary>
        ///     Sames the line using the specified offset from start x
        /// </summary>
        /// <param name="offsetFromStartX">The offset from start</param>
        /// <param name="spacing">The spacing</param>
        public static void SameLine(float offsetFromStartX, float spacing)
        {
            ImGuiNative.igSameLine(offsetFromStartX, spacing);
        }

        /// <summary>
        ///     Saves the ini settings to disk using the specified ini filename
        /// </summary>
        /// <param name="iniFilename">The ini filename</param>
        public static void SaveIniSettingsToDisk(string iniFilename)
        {
            ImGuiNative.igSaveIniSettingsToDisk(Encoding.UTF8.GetBytes(iniFilename));
        }

        /// <summary>
        ///     Saves the ini settings to memory
        /// </summary>
        /// <returns>The string</returns>
        public static string SaveIniSettingsToMemory() => Encoding.UTF8.GetString(ImGuiNative.igSaveIniSettingsToMemory(out _));

        /// <summary>
        ///     Saves the ini settings to memory using the specified out ini size
        /// </summary>
        /// <param name="outIniSize">The out ini size</param>
        /// <returns>The string</returns>
        public static string SaveIniSettingsToMemory(out uint outIniSize) => Encoding.UTF8.GetString(ImGuiNative.igSaveIniSettingsToMemory(out outIniSize));

        /// <summary>
        ///     Describes whether selectable
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool Selectable(string label)
        {
            byte ret = ImGuiNative.igSelectable_Bool(Encoding.UTF8.GetBytes(label), false, 0, new Vector2F());

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether selectable
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="selected">The selected</param>
        /// <returns>The bool</returns>
        public static bool Selectable(string label, bool selected)
        {
            byte ret = ImGuiNative.igSelectable_Bool(Encoding.UTF8.GetBytes(label), selected, 0, new Vector2F());
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether selectable
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="selected">The selected</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool Selectable(string label, bool selected, ImGuiSelectableFlags flags)
        {
            byte ret = ImGuiNative.igSelectable_Bool(Encoding.UTF8.GetBytes(label), selected, flags, new Vector2F());
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether selectable
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="selected">The selected</param>
        /// <param name="flags">The flags</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool Selectable(string label, bool selected, ImGuiSelectableFlags flags, Vector2F size)
        {
            byte ret = ImGuiNative.igSelectable_Bool(Encoding.UTF8.GetBytes(label), selected, flags, size);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether selectable
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="pSelected">The selected</param>
        /// <returns>The bool</returns>
        public static bool Selectable(string label, ref bool pSelected)
        {
            byte ret = ImGuiNative.igSelectable_BoolPtr(Encoding.UTF8.GetBytes(label), pSelected, 0, new Vector2F());
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether selectable
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="pSelected">The selected</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool Selectable(string label, ref bool pSelected, ImGuiSelectableFlags flags)
        {
            byte ret = ImGuiNative.igSelectable_BoolPtr(Encoding.UTF8.GetBytes(label), pSelected, flags, new Vector2F());
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether selectable
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="pSelected">The selected</param>
        /// <param name="flags">The flags</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool Selectable(string label, ref bool pSelected, ImGuiSelectableFlags flags, Vector2F size)
        {
            byte ret = ImGuiNative.igSelectable_BoolPtr(Encoding.UTF8.GetBytes(label), pSelected, flags, size);
            return ret != 0;
        }

        /// <summary>
        ///     Separators
        /// </summary>
        public static void Separator()
        {
            ImGuiNative.igSeparator();
        }

        /// <summary>
        ///     Sets the allocator functions using the specified alloc func
        /// </summary>
        /// <param name="allocFunc">The alloc func</param>
        /// <param name="freeFunc">The free func</param>
        public static void SetAllocatorFunctions(IntPtr allocFunc, IntPtr freeFunc)
        {
            IntPtr userData = IntPtr.Zero;
            ImGuiNative.igSetAllocatorFunctions(allocFunc, freeFunc, userData);
        }

        /// <summary>
        ///     Sets the allocator functions using the specified alloc func
        /// </summary>
        /// <param name="allocFunc">The alloc func</param>
        /// <param name="freeFunc">The free func</param>
        /// <param name="userData">The user data</param>
        public static void SetAllocatorFunctions(IntPtr allocFunc, IntPtr freeFunc, IntPtr userData)
        {
            IntPtr nativeUserData = userData;
            ImGuiNative.igSetAllocatorFunctions(allocFunc, freeFunc, nativeUserData);
        }

        /// <summary>
        ///     Sets the clipboard text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        public static void SetClipboardText(string text)
        {
            ImGuiNative.igSetClipboardText(Encoding.UTF8.GetBytes(text));
        }

        /// <summary>
        ///     Sets the color edit options using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        public static void SetColorEditOptions(ImGuiColorEditFlags flags)
        {
            ImGuiNative.igSetColorEditOptions(flags);
        }

        /// <summary>
        ///     Sets the column offset using the specified column index
        /// </summary>
        /// <param name="columnIndex">The column index</param>
        /// <param name="offsetX">The offset</param>
        public static void SetColumnOffset(int columnIndex, float offsetX)
        {
            ImGuiNative.igSetColumnOffset(columnIndex, offsetX);
        }

        /// <summary>
        ///     Sets the column width using the specified column index
        /// </summary>
        /// <param name="columnIndex">The column index</param>
        /// <param name="width">The width</param>
        public static void SetColumnWidth(int columnIndex, float width)
        {
            ImGuiNative.igSetColumnWidth(columnIndex, width);
        }

        /// <summary>
        ///     Sets the current context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        public static void SetCurrentContext(IntPtr ctx)
        {
            ImGuiNative.igSetCurrentContext(ctx);
        }

        /// <summary>
        ///     Sets the cursor pos using the specified local pos
        /// </summary>
        /// <param name="localPos">The local pos</param>
        public static void SetCursorPos(Vector2F localPos)
        {
            ImGuiNative.igSetCursorPos(localPos);
        }

        /// <summary>
        ///     Sets the cursor pos x using the specified local x
        /// </summary>
        /// <param name="localX">The local</param>
        public static void SetCursorPosX(float localX)
        {
            ImGuiNative.igSetCursorPosX(localX);
        }

        /// <summary>
        ///     Sets the cursor pos y using the specified local y
        /// </summary>
        /// <param name="localY">The local</param>
        public static void SetCursorPosY(float localY)
        {
            ImGuiNative.igSetCursorPosY(localY);
        }

        /// <summary>
        ///     Sets the cursor screen pos using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        public static void SetCursorScreenPos(Vector2F pos)
        {
            ImGuiNative.igSetCursorScreenPos(pos);
        }

        /// <summary>
        ///     Describes whether set drag drop payload
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="data">The data</param>
        /// <param name="sz">The sz</param>
        /// <returns>The bool</returns>
        public static bool SetDragDropPayload(string type, IntPtr data, uint sz)
        {
            byte ret = ImGuiNative.igSetDragDropPayload(Encoding.UTF8.GetBytes(type), data, sz, ImGuiCond.None);

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether set drag drop payload
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="data">The data</param>
        /// <param name="sz">The sz</param>
        /// <param name="cond">The cond</param>
        /// <returns>The bool</returns>
        public static bool SetDragDropPayload(string type, IntPtr data, uint sz, ImGuiCond cond)
        {
            byte ret = ImGuiNative.igSetDragDropPayload(Encoding.UTF8.GetBytes(type), data, sz, cond);
            return ret != 0;
        }

        /// <summary>
        ///     Sets the item allow overlap
        /// </summary>
        public static void SetItemAllowOverlap()
        {
            ImGuiNative.igSetItemAllowOverlap();
        }

        /// <summary>
        ///     Sets the item default focus
        /// </summary>
        public static void SetItemDefaultFocus()
        {
            ImGuiNative.igSetItemDefaultFocus();
        }

        /// <summary>
        ///     Sets the keyboard focus here
        /// </summary>
        public static void SetKeyboardFocusHere()
        {
            int offset = 0;
            ImGuiNative.igSetKeyboardFocusHere(offset);
        }

        /// <summary>
        ///     Sets the keyboard focus here using the specified offset
        /// </summary>
        /// <param name="offset">The offset</param>
        public static void SetKeyboardFocusHere(int offset)
        {
            ImGuiNative.igSetKeyboardFocusHere(offset);
        }

        /// <summary>
        ///     Sets the mouse cursor using the specified cursor type
        /// </summary>
        /// <param name="cursorType">The cursor type</param>
        public static void SetMouseCursor(ImGuiMouseCursor cursorType)
        {
            ImGuiNative.igSetMouseCursor(cursorType);
        }

        /// <summary>
        ///     Sets the next frame want capture keyboard using the specified want capture keyboard
        /// </summary>
        /// <param name="wantCaptureKeyboard">The want capture keyboard</param>
        public static void SetNextFrameWantCaptureKeyboard(bool wantCaptureKeyboard)
        {
            byte nativeWantCaptureKeyboard = wantCaptureKeyboard ? (byte) 1 : (byte) 0;
            ImGuiNative.igSetNextFrameWantCaptureKeyboard(nativeWantCaptureKeyboard);
        }

        /// <summary>
        ///     Sets the next frame want capture mouse using the specified want capture mouse
        /// </summary>
        /// <param name="wantCaptureMouse">The want capture mouse</param>
        public static void SetNextFrameWantCaptureMouse(bool wantCaptureMouse)
        {
            byte nativeWantCaptureMouse = wantCaptureMouse ? (byte) 1 : (byte) 0;
            ImGuiNative.igSetNextFrameWantCaptureMouse(nativeWantCaptureMouse);
        }

        /// <summary>
        ///     Sets the next item open using the specified is open
        /// </summary>
        /// <param name="isOpen">The is open</param>
        public static void SetNextItemOpen(bool isOpen)
        {
            byte nativeIsOpen = isOpen ? (byte) 1 : (byte) 0;
            ImGuiCond cond = 0;
            ImGuiNative.igSetNextItemOpen(nativeIsOpen, cond);
        }

        /// <summary>
        ///     Sets the next item open using the specified is open
        /// </summary>
        /// <param name="isOpen">The is open</param>
        /// <param name="cond">The cond</param>
        public static void SetNextItemOpen(bool isOpen, ImGuiCond cond)
        {
            byte nativeIsOpen = isOpen ? (byte) 1 : (byte) 0;
            ImGuiNative.igSetNextItemOpen(nativeIsOpen, cond);
        }

        /// <summary>
        ///     Sets the next item width using the specified item width
        /// </summary>
        /// <param name="itemWidth">The item width</param>
        public static void SetNextItemWidth(float itemWidth)
        {
            ImGuiNative.igSetNextItemWidth(itemWidth);
        }

        /// <summary>
        ///     Sets the next window bg alpha using the specified alpha
        /// </summary>
        /// <param name="alpha">The alpha</param>
        public static void SetNextWindowBgAlpha(float alpha)
        {
            ImGuiNative.igSetNextWindowBgAlpha(alpha);
        }

        /// <summary>
        ///     Sets the next window using the specified window class
        /// </summary>
        /// <param name="windowClass">The window class</param>
        public static void SetNextWindowClass(ImGuiWindowClass windowClass)
        {
            ImGuiNative.igSetNextWindowClass(windowClass);
        }

        /// <summary>
        ///     Sets the next window collapsed using the specified collapsed
        /// </summary>
        /// <param name="collapsed">The collapsed</param>
        public static void SetNextWindowCollapsed(bool collapsed)
        {
            byte nativeCollapsed = collapsed ? (byte) 1 : (byte) 0;
            ImGuiCond cond = 0;
            ImGuiNative.igSetNextWindowCollapsed(nativeCollapsed, cond);
        }

        /// <summary>
        ///     Sets the next window collapsed using the specified collapsed
        /// </summary>
        /// <param name="collapsed">The collapsed</param>
        /// <param name="cond">The cond</param>
        public static void SetNextWindowCollapsed(bool collapsed, ImGuiCond cond)
        {
            byte nativeCollapsed = collapsed ? (byte) 1 : (byte) 0;
            ImGuiNative.igSetNextWindowCollapsed(nativeCollapsed, cond);
        }

        /// <summary>
        ///     Sets the next window content size using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        public static void SetNextWindowContentSize(Vector2F size)
        {
            ImGuiNative.igSetNextWindowContentSize(size);
        }

        /// <summary>
        ///     Sets the next window dock id using the specified dock id
        /// </summary>
        /// <param name="dockId">The dock id</param>
        public static void SetNextWindowDockId(uint dockId)
        {
            ImGuiCond cond = 0;
            ImGuiNative.igSetNextWindowDockID(dockId, cond);
        }

        /// <summary>
        ///     Sets the next window dock id using the specified dock id
        /// </summary>
        /// <param name="dockId">The dock id</param>
        /// <param name="cond">The cond</param>
        public static void SetNextWindowDockId(uint dockId, ImGuiCond cond)
        {
            ImGuiNative.igSetNextWindowDockID(dockId, cond);
        }

        /// <summary>
        ///     Sets the next window focus
        /// </summary>
        public static void SetNextWindowFocus()
        {
            ImGuiNative.igSetNextWindowFocus();
        }

        /// <summary>
        ///     Sets the next window pos using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        public static void SetNextWindowPos(Vector2F pos)
        {
            ImGuiCond cond = 0;
            Vector2F pivot = new Vector2F();
            ImGuiNative.igSetNextWindowPos(pos, cond, pivot);
        }

        /// <summary>
        ///     Sets the next window pos using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="cond">The cond</param>
        public static void SetNextWindowPos(Vector2F pos, ImGuiCond cond)
        {
            Vector2F pivot = new Vector2F();
            ImGuiNative.igSetNextWindowPos(pos, cond, pivot);
        }

        /// <summary>
        ///     Sets the next window pos using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="cond">The cond</param>
        /// <param name="pivot">The pivot</param>
        public static void SetNextWindowPos(Vector2F pos, ImGuiCond cond, Vector2F pivot)
        {
            ImGuiNative.igSetNextWindowPos(pos, cond, pivot);
        }

        /// <summary>
        ///     Sets the next window scroll using the specified scroll
        /// </summary>
        /// <param name="scroll">The scroll</param>
        public static void SetNextWindowScroll(Vector2F scroll)
        {
            ImGuiNative.igSetNextWindowScroll(scroll);
        }

        /// <summary>
        ///     Sets the next window size using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        public static void SetNextWindowSize(Vector2F size)
        {
            ImGuiCond cond = 0;
            ImGuiNative.igSetNextWindowSize(size, cond);
        }

        /// <summary>
        ///     Sets the next window size using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        /// <param name="cond">The cond</param>
        public static void SetNextWindowSize(Vector2F size, ImGuiCond cond)
        {
            ImGuiNative.igSetNextWindowSize(size, cond);
        }

        /// <summary>
        ///     Sets the next window size constraints using the specified size min
        /// </summary>
        /// <param name="sizeMin">The size min</param>
        /// <param name="sizeMax">The size max</param>
        public static void SetNextWindowSizeConstraints(Vector2F sizeMin, Vector2F sizeMax)
        {
            ImGuiSizeCallback customCallback = null;
            IntPtr customCallbackData = IntPtr.Zero;
            ImGuiNative.igSetNextWindowSizeConstraints(sizeMin, sizeMax, customCallback, customCallbackData);
        }

        /// <summary>
        ///     Sets the next window size constraints using the specified size min
        /// </summary>
        /// <param name="sizeMin">The size min</param>
        /// <param name="sizeMax">The size max</param>
        /// <param name="customCallback">The custom callback</param>
        public static void SetNextWindowSizeConstraints(Vector2F sizeMin, Vector2F sizeMax, ImGuiSizeCallback customCallback)
        {
            IntPtr customCallbackData = IntPtr.Zero;
            ImGuiNative.igSetNextWindowSizeConstraints(sizeMin, sizeMax, customCallback, customCallbackData);
        }

        /// <summary>
        ///     Sets the next window size constraints using the specified size min
        /// </summary>
        /// <param name="sizeMin">The size min</param>
        /// <param name="sizeMax">The size max</param>
        /// <param name="customCallback">The custom callback</param>
        /// <param name="customCallbackData">The custom callback data</param>
        public static void SetNextWindowSizeConstraints(Vector2F sizeMin, Vector2F sizeMax, ImGuiSizeCallback customCallback, IntPtr customCallbackData)
        {
            IntPtr nativeCustomCallbackData = customCallbackData;
            ImGuiNative.igSetNextWindowSizeConstraints(sizeMin, sizeMax, customCallback, nativeCustomCallbackData);
        }

        /// <summary>
        ///     Sets the next window viewport using the specified viewport id
        /// </summary>
        /// <param name="viewportId">The viewport id</param>
        public static void SetNextWindowViewport(uint viewportId)
        {
            ImGuiNative.igSetNextWindowViewport(viewportId);
        }

        /// <summary>
        ///     Sets the scroll from pos x using the specified local x
        /// </summary>
        /// <param name="localX">The local</param>
        public static void SetScrollFromPosX(float localX)
        {
            float centerXRatio = 0.5f;
            ImGuiNative.igSetScrollFromPosX_Float(localX, centerXRatio);
        }

        /// <summary>
        ///     Sets the scroll from pos x using the specified local x
        /// </summary>
        /// <param name="localX">The local</param>
        /// <param name="centerXRatio">The center ratio</param>
        public static void SetScrollFromPosX(float localX, float centerXRatio)
        {
            ImGuiNative.igSetScrollFromPosX_Float(localX, centerXRatio);
        }

        /// <summary>
        ///     Sets the scroll from pos y using the specified local y
        /// </summary>
        /// <param name="localY">The local</param>
        public static void SetScrollFromPosY(float localY)
        {
            float centerYRatio = 0.5f;
            ImGuiNative.igSetScrollFromPosY_Float(localY, centerYRatio);
        }

        /// <summary>
        ///     Sets the scroll from pos y using the specified local y
        /// </summary>
        /// <param name="localY">The local</param>
        /// <param name="centerYRatio">The center ratio</param>
        public static void SetScrollFromPosY(float localY, float centerYRatio)
        {
            ImGuiNative.igSetScrollFromPosY_Float(localY, centerYRatio);
        }

        /// <summary>
        ///     Sets the scroll here x
        /// </summary>
        public static void SetScrollHereX()
        {
            float centerXRatio = 0.5f;
            ImGuiNative.igSetScrollHereX(centerXRatio);
        }

        /// <summary>
        ///     Sets the scroll here x using the specified center x ratio
        /// </summary>
        /// <param name="centerXRatio">The center ratio</param>
        public static void SetScrollHereX(float centerXRatio)
        {
            ImGuiNative.igSetScrollHereX(centerXRatio);
        }

        /// <summary>
        ///     Sets the scroll here y
        /// </summary>
        public static void SetScrollHereY()
        {
            float centerYRatio = 0.5f;
            ImGuiNative.igSetScrollHereY(centerYRatio);
        }

        /// <summary>
        ///     Sets the scroll here y using the specified center y ratio
        /// </summary>
        /// <param name="centerYRatio">The center ratio</param>
        public static void SetScrollHereY(float centerYRatio)
        {
            ImGuiNative.igSetScrollHereY(centerYRatio);
        }

        /// <summary>
        ///     Sets the scroll x using the specified scroll x
        /// </summary>
        /// <param name="scrollX">The scroll</param>
        public static void SetScrollX(float scrollX)
        {
            ImGuiNative.igSetScrollX_Float(scrollX);
        }

        /// <summary>
        ///     Sets the scroll y using the specified scroll y
        /// </summary>
        /// <param name="scrollY">The scroll</param>
        public static void SetScrollY(float scrollY)
        {
            ImGuiNative.igSetScrollY_Float(scrollY);
        }

        /// <summary>
        ///     Sets the state storage using the specified storage
        /// </summary>
        /// <param name="storage">The storage</param>
        public static void SetStateStorage(ImGuiStorage storage)
        {
            ImGuiNative.igSetStateStorage(storage);
        }

        /// <summary>
        ///     Sets the tab item closed using the specified tab or docked window label
        /// </summary>
        /// <param name="tabOrDockedWindowLabel">The tab or docked window label</param>
        public static void SetTabItemClosed(string tabOrDockedWindowLabel)
        {
            ImGuiNative.igSetTabItemClosed(Encoding.UTF8.GetBytes(tabOrDockedWindowLabel));
        }

        /// <summary>
        ///     Sets the tooltip using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        public static void SetTooltip(string fmt)
        {
            ImGuiNative.igSetTooltip(Encoding.UTF8.GetBytes(fmt));
        }

        /// <summary>
        ///     Sets the window collapsed using the specified collapsed
        /// </summary>
        /// <param name="collapsed">The collapsed</param>
        public static void SetWindowCollapsed(bool collapsed)
        {
            byte nativeCollapsed = collapsed ? (byte) 1 : (byte) 0;
            ImGuiCond cond = 0;
            ImGuiNative.igSetWindowCollapsed_Bool(nativeCollapsed, cond);
        }

        /// <summary>
        ///     Sets the window collapsed using the specified collapsed
        /// </summary>
        /// <param name="collapsed">The collapsed</param>
        /// <param name="cond">The cond</param>
        public static void SetWindowCollapsed(bool collapsed, ImGuiCond cond)
        {
            byte nativeCollapsed = collapsed ? (byte) 1 : (byte) 0;
            ImGuiNative.igSetWindowCollapsed_Bool(nativeCollapsed, cond);
        }

        /// <summary>
        ///     Sets the window collapsed using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="collapsed">The collapsed</param>
        public static void SetWindowCollapsed(string name, bool collapsed)
        {
            ImGuiNative.igSetWindowCollapsed_Str(Encoding.UTF8.GetBytes(name), collapsed, ImGuiCond.None);
        }

        /// <summary>
        ///     Sets the window collapsed using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="collapsed">The collapsed</param>
        /// <param name="cond">The cond</param>
        public static void SetWindowCollapsed(string name, bool collapsed, ImGuiCond cond)
        {
            ImGuiNative.igSetWindowCollapsed_Str(Encoding.UTF8.GetBytes(name), collapsed, cond);
        }

        /// <summary>
        ///     Sets the window focus
        /// </summary>
        public static void SetWindowFocus()
        {
            ImGuiNative.igSetWindowFocus_Nil();
        }

        /// <summary>
        ///     Sets the window focus using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        public static void SetWindowFocus(string name)
        {
            ImGuiNative.igSetWindowFocus_Str(Encoding.UTF8.GetBytes(name));
        }

        /// <summary>
        ///     Sets the window font scale using the specified scale
        /// </summary>
        /// <param name="scale">The scale</param>
        public static void SetWindowFontScale(float scale)
        {
            ImGuiNative.igSetWindowFontScale(scale);
        }

        /// <summary>
        ///     Sets the window pos using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        public static void SetWindowPos(Vector2F pos)
        {
            ImGuiCond cond = 0;
            ImGuiNative.igSetWindowPos_Vec2(pos, cond);
        }

        /// <summary>
        ///     Sets the window pos using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="cond">The cond</param>
        public static void SetWindowPos(Vector2F pos, ImGuiCond cond)
        {
            ImGuiNative.igSetWindowPos_Vec2(pos, cond);
        }

        /// <summary>
        ///     Sets the window pos using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="pos">The pos</param>
        public static void SetWindowPos(string name, Vector2F pos)
        {
            ImGuiNative.igSetWindowPos_Str(Encoding.UTF8.GetBytes(name), pos, ImGuiCond.None);
        }

        /// <summary>
        ///     Sets the window pos using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="pos">The pos</param>
        /// <param name="cond">The cond</param>
        public static void SetWindowPos(string name, Vector2F pos, ImGuiCond cond)
        {
            ImGuiNative.igSetWindowPos_Str(Encoding.UTF8.GetBytes(name), pos, cond);
        }

        /// <summary>
        ///     Sets the window size using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        public static void SetWindowSize(Vector2F size)
        {
            ImGuiCond cond = 0;
            ImGuiNative.igSetWindowSize_Vec2(size, cond);
        }

        /// <summary>
        ///     Sets the window size using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        /// <param name="cond">The cond</param>
        public static void SetWindowSize(Vector2F size, ImGuiCond cond)
        {
            ImGuiNative.igSetWindowSize_Vec2(size, cond);
        }

        /// <summary>
        ///     Sets the window size using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="size">The size</param>
        public static void SetWindowSize(string name, Vector2F size)
        {
            ImGuiNative.igSetWindowSize_Str(Encoding.UTF8.GetBytes(name), size, ImGuiCond.None);
        }

        /// <summary>
        ///     Sets the window size using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="size">The size</param>
        /// <param name="cond">The cond</param>
        public static void SetWindowSize(string name, Vector2F size, ImGuiCond cond)
        {
            ImGuiNative.igSetWindowSize_Str(Encoding.UTF8.GetBytes(name), size, cond);
        }
    }
}