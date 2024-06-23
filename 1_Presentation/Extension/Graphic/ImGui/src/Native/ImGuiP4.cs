// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP4.cs
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
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.ImGui.Utils;

namespace Alis.Extension.Graphic.ImGui.Native
{
    /// <summary>
    /// The im gui class
    /// </summary>
    public static unsafe partial class ImGui
    {
        /// <summary>
        ///     Tables the setup column using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        public static void TableSetupColumn(string label, ImGuiTableColumnFlags flags)
        {
            ImGuiNative.igTableSetupColumn(Encoding.UTF8.GetBytes(label), flags, 0.0f, 0);
        }
        
        /// <summary>
        ///     Tables the setup column using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <param name="initWidthOrWeight">The init width or weight</param>
        public static void TableSetupColumn(string label, ImGuiTableColumnFlags flags, float initWidthOrWeight)
        {
            ImGuiNative.igTableSetupColumn(Encoding.UTF8.GetBytes(label), flags, initWidthOrWeight, 0);
        }
        
        /// <summary>
        ///     Tables the setup column using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <param name="initWidthOrWeight">The init width or weight</param>
        /// <param name="userId">The user id</param>
        public static void TableSetupColumn(string label, ImGuiTableColumnFlags flags, float initWidthOrWeight, uint userId)
        {
            ImGuiNative.igTableSetupColumn(Encoding.UTF8.GetBytes(label), flags, initWidthOrWeight, userId);
        }
        
        /// <summary>
        ///     Tables the setup scroll freeze using the specified cols
        /// </summary>
        /// <param name="cols">The cols</param>
        /// <param name="rows">The rows</param>
        public static void TableSetupScrollFreeze(int cols, int rows)
        {
            ImGuiNative.igTableSetupScrollFreeze(cols, rows);
        }
        
        /// <summary>
        ///     Texts the fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        public static void Text(string fmt)
        {
            ImGuiNative.igText(Encoding.UTF8.GetBytes(fmt));
        }
        
        /// <summary>
        ///     Texts the colored using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <param name="fmt">The fmt</param>
        public static void TextColored(Vector4 col, string fmt)
        {
            ImGuiNative.igTextColored(col, Encoding.UTF8.GetBytes(fmt));
        }
        
        /// <summary>
        ///     Texts the disabled using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        public static void TextDisabled(string fmt)
        {
            ImGuiNative.igTextDisabled(Encoding.UTF8.GetBytes(fmt));
        }
        
        /// <summary>
        ///     Texts the unformatted using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        public static void TextUnformatted(string text)
        {
            byte[] nativeText = Encoding.UTF8.GetBytes(text);
            ImGuiNative.igTextUnformatted(nativeText, (byte)nativeText.Length);
        }
        
        /// <summary>
        ///     Texts the wrapped using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        public static void TextWrapped(string fmt)
        {
            ImGuiNative.igTextWrapped(Encoding.UTF8.GetBytes(fmt));
        }
        
        /// <summary>
        ///     Describes whether tree node
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool TreeNode(string label)
        {
            byte ret = ImGuiNative.igTreeNode_Str(Encoding.UTF8.GetBytes(label));
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether tree node
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="fmt">The fmt</param>
        /// <returns>The bool</returns>
        public static bool TreeNode(string strId, string fmt)
        {
            byte ret = ImGuiNative.igTreeNode_StrStr(Encoding.UTF8.GetBytes(strId), Encoding.UTF8.GetBytes(fmt));
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether tree node
        /// </summary>
        /// <param name="ptrId">The ptr id</param>
        /// <param name="fmt">The fmt</param>
        /// <returns>The bool</returns>
        public static bool TreeNode(IntPtr ptrId, string fmt)
        {
            byte ret = ImGuiNative.igTreeNode_Ptr( ptrId, Encoding.UTF8.GetBytes(fmt));
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether tree node ex
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool TreeNodeEx(string label)
        {
            byte ret = ImGuiNative.igTreeNodeEx_Str(Encoding.UTF8.GetBytes(label), 0);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether tree node ex
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool TreeNodeEx(string label, ImGuiTreeNodeFlags flags)
        {
            byte ret = ImGuiNative.igTreeNodeEx_Str(Encoding.UTF8.GetBytes(label), flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether tree node ex
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="flags">The flags</param>
        /// <param name="fmt">The fmt</param>
        /// <returns>The bool</returns>
        public static bool TreeNodeEx(string strId, ImGuiTreeNodeFlags flags, string fmt)
        {
            byte ret = ImGuiNative.igTreeNodeEx_StrStr(Encoding.UTF8.GetBytes(strId), flags, Encoding.UTF8.GetBytes(fmt));
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether tree node ex
        /// </summary>
        /// <param name="ptrId">The ptr id</param>
        /// <param name="flags">The flags</param>
        /// <param name="fmt">The fmt</param>
        /// <returns>The bool</returns>
        public static bool TreeNodeEx(IntPtr ptrId, ImGuiTreeNodeFlags flags, string fmt)
        {
            byte ret = ImGuiNative.igTreeNodeEx_Ptr( ptrId, flags, Encoding.UTF8.GetBytes(fmt));
            return ret != 0;
        }
        
        /// <summary>
        ///     Trees the pop
        /// </summary>
        public static void TreePop()
        {
            ImGuiNative.igTreePop();
        }
        
        /// <summary>
        ///     Trees the push using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        public static void TreePush(string strId)
        {
            ImGuiNative.igTreePush_Str(Encoding.UTF8.GetBytes(strId));
        }
        
        /// <summary>
        ///     Trees the push using the specified ptr id
        /// </summary>
        /// <param name="ptrId">The ptr id</param>
        public static void TreePush(IntPtr ptrId)
        {
            IntPtr nativePtrId = ptrId;
            ImGuiNative.igTreePush_Ptr(nativePtrId);
        }
        
        /// <summary>
        ///     Unindents
        /// </summary>
        public static void Unindent()
        {
            float indentW = 0.0f;
            ImGuiNative.igUnindent(indentW);
        }
        
        /// <summary>
        ///     Unindents the indent w
        /// </summary>
        /// <param name="indentW">The indent</param>
        public static void Unindent(float indentW)
        {
            ImGuiNative.igUnindent(indentW);
        }
        
        /// <summary>
        ///     Updates the platform windows
        /// </summary>
        public static void UpdatePlatformWindows()
        {
            ImGuiNative.igUpdatePlatformWindows();
        }
        
        /// <summary>
        ///     Values the prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="b">The </param>
        public static void Value(string prefix, bool b)
        {
            ImGuiNative.igValue_Bool(Encoding.UTF8.GetBytes(prefix), b);
        }
        
        /// <summary>
        ///     Values the prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="v">The </param>
        public static void Value(string prefix, int v)
        {
            ImGuiNative.igValue_Int(Encoding.UTF8.GetBytes(prefix), v);
        }
        
        /// <summary>
        ///     Values the prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="v">The </param>
        public static void Value(string prefix, uint v)
        {
            ImGuiNative.igValue_Uint(Encoding.UTF8.GetBytes(prefix), v);
        }
        
        /// <summary>
        ///     Values the prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="v">The </param>
        public static void Value(string prefix, float v)
        {
            ImGuiNative.igValue_Float(Encoding.UTF8.GetBytes(prefix), v, Encoding.UTF8.GetBytes("%.6f"));
        }
        
        /// <summary>
        ///     Values the prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="v">The </param>
        /// <param name="floatFormat">The float format</param>
        public static void Value(string prefix, float v, string floatFormat)
        {
            ImGuiNative.igValue_Float(Encoding.UTF8.GetBytes(prefix), v, Encoding.UTF8.GetBytes(floatFormat));
        }
        
        /// <summary>
        ///     Describes whether v slider float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool VSliderFloat(string label, Vector2 size, ref float v, float vMin, float vMax)
        {
            byte ret = ImGuiNative.igVSliderFloat(Encoding.UTF8.GetBytes(label), size, ref v, vMin, vMax, null, 0);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether v slider float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool VSliderFloat(string label, Vector2 size, ref float v, float vMin, float vMax, string format)
        {
            byte ret = ImGuiNative.igVSliderFloat(Encoding.UTF8.GetBytes(label), size, ref v, vMin, vMax, Encoding.UTF8.GetBytes(format), 0);
            
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether v slider float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool VSliderFloat(string label, Vector2 size, ref float v, float vMin, float vMax, string format, ImGuiSliderFlags flags)
        {
            byte ret = ImGuiNative.igVSliderFloat(Encoding.UTF8.GetBytes(label), size, ref v, vMin, vMax, Encoding.UTF8.GetBytes(format), flags);
            
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether v slider int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool VSliderInt(string label, Vector2 size, ref int v, int vMin, int vMax)
        {
            byte ret = ImGuiNative.igVSliderInt(Encoding.UTF8.GetBytes(label), size, ref v, vMin, vMax, null, 0);
                
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether v slider int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool VSliderInt(string label, Vector2 size, ref int v, int vMin, int vMax, string format)
        {
            byte ret = ImGuiNative.igVSliderInt(Encoding.UTF8.GetBytes(label), size, ref v, vMin, vMax, Encoding.UTF8.GetBytes(format), 0);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether v slider int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool VSliderInt(string label, Vector2 size, ref int v, int vMin, int vMax, string format, ImGuiSliderFlags flags)
        {
            byte ret = ImGuiNative.igVSliderInt(Encoding.UTF8.GetBytes(label), size, ref v, vMin, vMax, Encoding.UTF8.GetBytes(format), flags);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether v slider scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <returns>The bool</returns>
        public static bool VSliderScalar(string label, Vector2 size, ImGuiDataType dataType, IntPtr pData, IntPtr pMin, IntPtr pMax)
        {
            byte ret = ImGuiNative.igVSliderScalar(Encoding.UTF8.GetBytes(label), size, dataType, pData, pMin, pMax, null, 0);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether v slider scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool VSliderScalar(string label, Vector2 size, ImGuiDataType dataType, IntPtr pData, IntPtr pMin, IntPtr pMax, string format)
        {
            byte ret = ImGuiNative.igVSliderScalar(Encoding.UTF8.GetBytes(label), size, dataType, pData, pMin, pMax, Encoding.UTF8.GetBytes(format), 0);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether v slider scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool VSliderScalar(string label, Vector2 size, ImGuiDataType dataType, IntPtr pData, IntPtr pMin, IntPtr pMax, string format, ImGuiSliderFlags flags)
        {
            byte ret = ImGuiNative.igVSliderScalar(Encoding.UTF8.GetBytes(label), size, dataType, pData, pMin, pMax, Encoding.UTF8.GetBytes(format), flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            byte[] buf,
            uint bufSize)
            => InputText(label, buf, bufSize, 0, null, IntPtr.Zero);
        
        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            byte[] buf,
            uint bufSize,
            ImGuiInputTextFlags flags)
            => InputText(label, buf, bufSize, flags, null, IntPtr.Zero);
        
        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            byte[] buf,
            uint bufSize,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback)
            => InputText(label, buf, bufSize, flags, callback, IntPtr.Zero);
        
        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <param name="userData">The user data</param>
        /// <returns>The ret</returns>
        public static bool InputText(
            string label,
            byte[] buf,
            uint bufSize,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback,
            IntPtr userData)
        {
            bool ret = ImGuiNative.igInputText(
                Encoding.UTF8.GetBytes(label),
                IntPtr.Zero, 
                bufSize,
                flags,
                callback,
                userData) != 0;
            
            return ret;
        }
        
        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            ref string input,
            uint maxLength) => InputText(label, ref input, maxLength, 0, null, IntPtr.Zero);
        
        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags) => InputText(label, ref input, maxLength, flags, null, IntPtr.Zero);
        
        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback) => InputText(label, ref input, maxLength, flags, callback, IntPtr.Zero);
        
        /// <summary>
        ///     Determines whether the input text.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="input">The input.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <param name="flag">The flags.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="userData">The user data.</param>
        /// <returns><c>true</c> if the input text; otherwise, <c>false</c>.</returns>
        public static bool InputText(
            string label,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flag,
            ImGuiInputTextCallback callback,
            IntPtr userData)
        {
            byte result = ImGuiNative.igInputText(
                Encoding.UTF8.GetBytes(label),
                IntPtr.Zero,
                maxLength,
                flag,
                callback,
                userData);
            
            return result != 0;
        }
        
        
        /// <summary>
        ///     Describes whether input text multiline
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool InputTextMultiline(
            string label,
            ref string input,
            uint maxLength,
            Vector2 size) => InputTextMultiline(label, ref input, maxLength, size, 0, null, IntPtr.Zero);
        
        /// <summary>
        ///     Describes whether input text multiline
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputTextMultiline(
            string label,
            ref string input,
            uint maxLength,
            Vector2 size,
            ImGuiInputTextFlags flags) => InputTextMultiline(label, ref input, maxLength, size, flags, null, IntPtr.Zero);
        
        /// <summary>
        ///     Describes whether input text multiline
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <returns>The bool</returns>
        public static bool InputTextMultiline(
            string label,
            ref string input,
            uint maxLength,
            Vector2 size,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback) => InputTextMultiline(label, ref input, maxLength, size, flags, callback, IntPtr.Zero);
        
        /// <summary>
        ///     Determines whether the input text is multiline.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="input">The input.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <param name="size">The size.</param>
        /// <param name="flag">The flags.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="userData">The user data.</param>
        /// <returns><c>true</c> if the input text is multiline; otherwise, <c>false</c>.</returns>
        public static bool InputTextMultiline(
            string label,
            ref string input,
            uint maxLength,
            Vector2 size,
            ImGuiInputTextFlags flag,
            ImGuiInputTextCallback callback,
            IntPtr userData)
        {
            byte result = ImGuiNative.igInputTextMultiline(
                Encoding.UTF8.GetBytes(label),
                Encoding.UTF8.GetBytes(input),
                maxLength,
                size,
                flag,
                callback,
                userData);
            return result != 0;
        }
        
        
        /// <summary>
        ///     Describes whether input text with hint
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="hint">The hint</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <returns>The bool</returns>
        public static bool InputTextWithHint(
            string label,
            string hint,
            ref string input,
            uint maxLength) => InputTextWithHint(label, hint, ref input, maxLength, 0, null, IntPtr.Zero);
        
        /// <summary>
        ///     Describes whether input text with hint
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="hint">The hint</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputTextWithHint(
            string label,
            string hint,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags) => InputTextWithHint(label, hint, ref input, maxLength, flags, null, IntPtr.Zero);
        
        /// <summary>
        ///     Describes whether input text with hint
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="hint">The hint</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <returns>The bool</returns>
        public static bool InputTextWithHint(
            string label,
            string hint,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback) => InputTextWithHint(label, hint, ref input, maxLength, flags, callback, IntPtr.Zero);
        
        /// <summary>
        ///     Describes whether input text with hint
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="hint">The hint</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="flag">The flags</param>
        /// <param name="callback">The callback</param>
        /// <param name="userData">The user data</param>
        /// <returns>The bool</returns>
        public static bool InputTextWithHint(
            string label,
            string hint,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flag,
            ImGuiInputTextCallback callback,
            IntPtr userData)
        {
            byte result = ImGuiNative.igInputTextWithHint(
                Encoding.UTF8.GetBytes(label),
                Encoding.UTF8.GetBytes(hint),
                Encoding.UTF8.GetBytes(input),
                maxLength,
                flag,
                callback,
                userData);
            return result != 0;
        }
        
        /// <summary>
        ///     Gets the utf 8 bytes using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The utf bytes</returns>
        private static byte* GetUtf8Bytes(string text)
        {
            int byteCount = Encoding.UTF8.GetByteCount(text);
            byte* utf8Bytes = (byte*) Marshal.AllocHGlobal(byteCount + 1);
            Util.GetUtf8(text, utf8Bytes, byteCount);
            utf8Bytes[byteCount] = 0; // Null-terminate the string
            return utf8Bytes;
        }
        
        
        /// <summary>
        ///     Gets the utf 8 bytes using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="maxLength">The max length</param>
        /// <returns>The utf bytes</returns>
        private static byte* GetUtf8Bytes(string text, uint maxLength)
        {
            int byteCount = Encoding.UTF8.GetByteCount(text);
            int inputBufSize = Math.Max((int) maxLength + 1, byteCount + 1);
            byte[] utf8BytesArray = new byte[inputBufSize];
            
            fixed (byte* utf8Bytes = utf8BytesArray)
            {
                Util.GetUtf8(text, utf8Bytes, inputBufSize);
                Unsafe.InitBlockUnaligned(utf8Bytes, 0, (uint) inputBufSize);
                
                byte* result = (byte*) Marshal.AllocHGlobal(inputBufSize);
                Buffer.MemoryCopy(utf8Bytes, result, inputBufSize, inputBufSize);
                
                return result;
            }
        }
        
        
        /// <summary>
        ///     Describes whether are utf 8 strings equal
        /// </summary>
        /// <param name="utf8Bytes">The utf bytes</param>
        /// <param name="text">The text</param>
        /// <returns>The bool</returns>
        private static bool AreUtf8StringsEqual(byte* utf8Bytes, string text)
        {
            int byteCount = Encoding.UTF8.GetByteCount(text);
            return Util.AreStringsEqual(utf8Bytes, byteCount, utf8Bytes);
        }
        
        /// <summary>
        ///     Gets the string from utf 8 using the specified utf 8 bytes
        /// </summary>
        /// <param name="utf8Bytes">The utf bytes</param>
        /// <returns>The string</returns>
        private static string GetStringFromUtf8(byte* utf8Bytes) => Util.StringFromPtr(utf8Bytes);
        
        /// <summary>
        ///     Frees the utf 8 bytes using the specified utf 8 bytes
        /// </summary>
        /// <param name="utf8Bytes">The utf bytes</param>
        private static void FreeUtf8Bytes(byte* utf8Bytes)
        {
            int allocatedSize = GetUtf8BytesLength(utf8Bytes);
            if (allocatedSize > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8Bytes);
            }
        }
        
        /// <summary>
        ///     Gets the utf 8 bytes length using the specified utf 8 bytes
        /// </summary>
        /// <param name="utf8Bytes">The utf bytes</param>
        /// <returns>The length</returns>
        private static int GetUtf8BytesLength(byte* utf8Bytes)
        {
            if (utf8Bytes == null)
            {
                return 0;
            }
            
            int length = 0;
            while (*(utf8Bytes + length) != 0)
            {
                length++;
            }
            
            return length;
        }
        
        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text)
            => CalcTextSizeImpl(text);
        
        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, int start)
            => CalcTextSizeImpl(text, start);
        
        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, float wrapWidth)
            => CalcTextSizeImpl(text, wrapWidth: wrapWidth);
        
        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, bool hideTextAfterDoubleHash)
            => CalcTextSizeImpl(text, hideTextAfterDoubleHash: hideTextAfterDoubleHash);
        
        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, int start, int length)
            => CalcTextSizeImpl(text, start, length);
        
        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, int start, bool hideTextAfterDoubleHash)
            => CalcTextSizeImpl(text, start, hideTextAfterDoubleHash: hideTextAfterDoubleHash);
        
        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, int start, float wrapWidth)
            => CalcTextSizeImpl(text, start, wrapWidth: wrapWidth);
        
        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, bool hideTextAfterDoubleHash, float wrapWidth)
            => CalcTextSizeImpl(text, hideTextAfterDoubleHash: hideTextAfterDoubleHash, wrapWidth: wrapWidth);
        
        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, int start, int length, bool hideTextAfterDoubleHash)
            => CalcTextSizeImpl(text, start, length, hideTextAfterDoubleHash);
        
        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, int start, int length, float wrapWidth)
            => CalcTextSizeImpl(text, start, length, wrapWidth: wrapWidth);
        
        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, int start, int length, bool hideTextAfterDoubleHash, float wrapWidth)
            => CalcTextSizeImpl(text, start, length, hideTextAfterDoubleHash, wrapWidth);
        
        /// <summary>
        ///     Calcs the text size impl using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The ret</returns>
        private static Vector2 CalcTextSizeImpl(
            string text,
            int start = 0,
            int? length = null,
            bool hideTextAfterDoubleHash = false,
            float wrapWidth = -1.0f)
        {
            ImGuiNative.igCalcTextSize(out Vector2 ret, Encoding.UTF8.GetBytes(text), (byte)text.Length, hideTextAfterDoubleHash, wrapWidth);
            return ret;
        }
        
        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            IntPtr buf,
            uint bufSize)
            => InputText(label, buf, bufSize, 0, null, IntPtr.Zero);
        
        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            IntPtr buf,
            uint bufSize,
            ImGuiInputTextFlags flags)
            => InputText(label, buf, bufSize, flags, null, IntPtr.Zero);
        
        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            IntPtr buf,
            uint bufSize,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback)
            => InputText(label, buf, bufSize, flags, callback, IntPtr.Zero);
        
        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <param name="userData">The user data</param>
        /// <returns>The ret</returns>
        public static bool InputText(
            string label,
            IntPtr buf,
            uint bufSize,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback,
            IntPtr userData)
        {
            bool ret = ImGuiNative.igInputText(
                Encoding.UTF8.GetBytes(label),
                buf,
                bufSize,
                flags,
                callback,
                userData) != 0;
            
            return ret;
        }
        
        /// <summary>
        ///     Describes whether begin
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool Begin(string name, ImGuiWindowFlags flags)
        {
            byte ret = ImGuiNative.igBegin(Encoding.UTF8.GetBytes(name), true, flags);
            
            return ret != 0;
        }
        
        
}
}