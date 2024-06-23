// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP6.cs
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
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.ImGui.Native
{
    /// <summary>
    /// The im gui class
    /// </summary>
    public static unsafe partial class ImGui
    {
        
        
        /// <summary>
        ///     Describes whether input float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool InputFloat4(string label, ref Vector4 v, string format)
        {
            byte ret = ImGuiNative.igInputFloat4(Encoding.UTF8.GetBytes(label), ref v, Encoding.UTF8.GetBytes(format), ImGuiInputTextFlags.None);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputFloat4(string label, ref Vector4 v, string format, ImGuiInputTextFlags flags)
        {
            byte ret = ImGuiNative.igInputFloat4(Encoding.UTF8.GetBytes(label), ref v, Encoding.UTF8.GetBytes(format), flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool InputInt(string label, ref int v)
        {
            byte ret = ImGuiNative.igInputInt(Encoding.UTF8.GetBytes(label), ref v, 1, 100, ImGuiInputTextFlags.None);
                
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <returns>The bool</returns>
        public static bool InputInt(string label, ref int v, int step)
        {
            byte ret = ImGuiNative.igInputInt(Encoding.UTF8.GetBytes(label), ref v, step, 100, ImGuiInputTextFlags.None);
                
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <param name="stepFast">The step fast</param>
        /// <returns>The bool</returns>
        public static bool InputInt(string label, ref int v, int step, int stepFast)
        {
            byte ret = ImGuiNative.igInputInt(Encoding.UTF8.GetBytes(label), ref v, step, stepFast, ImGuiInputTextFlags.None);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <param name="stepFast">The step fast</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputInt(string label, ref int v, int step, int stepFast, ImGuiInputTextFlags flags)
        {
            byte ret = ImGuiNative.igInputInt(Encoding.UTF8.GetBytes(label), ref v, step, stepFast, flags);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input int 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool InputInt2(string label, ref int v)
        {
            byte ret = ImGuiNative.igInputInt2(Encoding.UTF8.GetBytes(label), ref v, ImGuiInputTextFlags.None);
                
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input int 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputInt2(string label, ref int v, ImGuiInputTextFlags flags)
        {
            byte ret = ImGuiNative.igInputInt2(Encoding.UTF8.GetBytes(label), ref v, flags);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input int 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool InputInt3(string label, ref int v)
        {
            byte ret = ImGuiNative.igInputInt3(Encoding.UTF8.GetBytes(label), ref v, ImGuiInputTextFlags.None);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input int 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputInt3(string label, ref int v, ImGuiInputTextFlags flags)
        {
            byte ret = ImGuiNative.igInputInt3(Encoding.UTF8.GetBytes(label), ref v, flags);
                
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input int 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool InputInt4(string label, ref int v)
        {
            byte ret = ImGuiNative.igInputInt4(Encoding.UTF8.GetBytes(label), ref v, ImGuiInputTextFlags.None);
                
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input int 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputInt4(string label, ref int v, ImGuiInputTextFlags flags)
        {
            byte ret = ImGuiNative.igInputInt4(Encoding.UTF8.GetBytes(label), ref v, flags);
                
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <returns>The bool</returns>
        public static bool InputScalar(string label, ImGuiDataType dataType, IntPtr pData)
        {
            byte ret = ImGuiNative.igInputScalar(Encoding.UTF8.GetBytes(label), dataType, pData, IntPtr.Zero, IntPtr.Zero, null, ImGuiInputTextFlags.None);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="pStep">The step</param>
        /// <returns>The bool</returns>
        public static bool InputScalar(string label, ImGuiDataType dataType, IntPtr pData, IntPtr pStep)
        {
            byte ret = ImGuiNative.igInputScalar(Encoding.UTF8.GetBytes(label), dataType, pData, pStep, IntPtr.Zero, null, ImGuiInputTextFlags.None);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="pStep">The step</param>
        /// <param name="pStepFast">The step fast</param>
        /// <returns>The bool</returns>
        public static bool InputScalar(string label, ImGuiDataType dataType, IntPtr pData, IntPtr pStep, IntPtr pStepFast)
        {
            byte ret = ImGuiNative.igInputScalar(Encoding.UTF8.GetBytes(label), dataType, pData, pStep, pStepFast, null, ImGuiInputTextFlags.None);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="pStep">The step</param>
        /// <param name="pStepFast">The step fast</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool InputScalar(string label, ImGuiDataType dataType, IntPtr pData, IntPtr pStep, IntPtr pStepFast, string format)
        {
            byte ret = ImGuiNative.igInputScalar(Encoding.UTF8.GetBytes(label), dataType, pData, pStep, pStepFast, Encoding.UTF8.GetBytes(format), ImGuiInputTextFlags.None);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="pStep">The step</param>
        /// <param name="pStepFast">The step fast</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputScalar(string label, ImGuiDataType dataType, IntPtr pData, IntPtr pStep, IntPtr pStepFast, string format, ImGuiInputTextFlags flags)
        {
            byte ret = ImGuiNative.igInputScalar(Encoding.UTF8.GetBytes(label), dataType, pData, pStep, pStepFast, Encoding.UTF8.GetBytes(format), flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input scalar n
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="components">The components</param>
        /// <returns>The bool</returns>
        public static bool InputScalarN(string label, ImGuiDataType dataType, IntPtr pData, int components)
        {
            byte ret = ImGuiNative.igInputScalarN(Encoding.UTF8.GetBytes(label), dataType, pData, components, IntPtr.Zero, IntPtr.Zero, null, ImGuiInputTextFlags.None);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input scalar n
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="components">The components</param>
        /// <param name="pStep">The step</param>
        /// <returns>The bool</returns>
        public static bool InputScalarN(string label, ImGuiDataType dataType, IntPtr pData, int components, IntPtr pStep)
        {
            byte ret = ImGuiNative.igInputScalarN(Encoding.UTF8.GetBytes(label), dataType, pData, components, pStep, IntPtr.Zero, null, ImGuiInputTextFlags.None);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input scalar n
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="components">The components</param>
        /// <param name="pStep">The step</param>
        /// <param name="pStepFast">The step fast</param>
        /// <returns>The bool</returns>
        public static bool InputScalarN(string label, ImGuiDataType dataType, IntPtr pData, int components, IntPtr pStep, IntPtr pStepFast)
        {
            byte ret = ImGuiNative.igInputScalarN(Encoding.UTF8.GetBytes(label), dataType, pData, components, pStep, pStepFast, null, ImGuiInputTextFlags.None);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input scalar n
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="components">The components</param>
        /// <param name="pStep">The step</param>
        /// <param name="pStepFast">The step fast</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool InputScalarN(string label, ImGuiDataType dataType, IntPtr pData, int components, IntPtr pStep, IntPtr pStepFast, string format)
        {
            byte ret = ImGuiNative.igInputScalarN(Encoding.UTF8.GetBytes(label), dataType, pData, components, pStep, pStepFast, Encoding.UTF8.GetBytes(format), ImGuiInputTextFlags.None);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input scalar n
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="components">The components</param>
        /// <param name="pStep">The step</param>
        /// <param name="pStepFast">The step fast</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputScalarN(string label, ImGuiDataType dataType, IntPtr pData, int components, IntPtr pStep, IntPtr pStepFast, string format, ImGuiInputTextFlags flags)
        {
            byte ret = ImGuiNative.igInputScalarN(Encoding.UTF8.GetBytes(label), dataType, pData, components, pStep, pStepFast, Encoding.UTF8.GetBytes(format), flags);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether invisible button
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool InvisibleButton(string strId, Vector2 size)
        {
            byte ret = ImGuiNative.igInvisibleButton(Encoding.UTF8.GetBytes(strId), size, ImGuiButtonFlags.None);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether invisible button
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InvisibleButton(string strId, Vector2 size, ImGuiButtonFlags flags)
        {
            byte ret = ImGuiNative.igInvisibleButton(Encoding.UTF8.GetBytes(strId), size, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is any item active
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsAnyItemActive()
        {
            byte ret = ImGuiNative.igIsAnyItemActive();
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is any item focused
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsAnyItemFocused()
        {
            byte ret = ImGuiNative.igIsAnyItemFocused();
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is any item hovered
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsAnyItemHovered()
        {
            byte ret = ImGuiNative.igIsAnyItemHovered();
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is any mouse down
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsAnyMouseDown()
        {
            byte ret = ImGuiNative.igIsAnyMouseDown();
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is item activated
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsItemActivated()
        {
            byte ret = ImGuiNative.igIsItemActivated();
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is item active
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsItemActive()
        {
            byte ret = ImGuiNative.igIsItemActive();
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is item clicked
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsItemClicked()
        {
            ImGuiMouseButton mouseButton = 0;
            byte ret = ImGuiNative.igIsItemClicked(mouseButton);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is item clicked
        /// </summary>
        /// <param name="mouseButton">The mouse button</param>
        /// <returns>The bool</returns>
        public static bool IsItemClicked(ImGuiMouseButton mouseButton)
        {
            byte ret = ImGuiNative.igIsItemClicked(mouseButton);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is item deactivated
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsItemDeactivated()
        {
            byte ret = ImGuiNative.igIsItemDeactivated();
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is item deactivated after edit
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsItemDeactivatedAfterEdit()
        {
            byte ret = ImGuiNative.igIsItemDeactivatedAfterEdit();
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is item edited
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsItemEdited()
        {
            byte ret = ImGuiNative.igIsItemEdited();
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is item focused
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsItemFocused()
        {
            byte ret = ImGuiNative.igIsItemFocused();
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is item hovered
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsItemHovered()
        {
            ImGuiHoveredFlags flags = 0;
            byte ret = ImGuiNative.igIsItemHovered(flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is item hovered
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool IsItemHovered(ImGuiHoveredFlags flags)
        {
            byte ret = ImGuiNative.igIsItemHovered(flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is item toggled open
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsItemToggledOpen()
        {
            byte ret = ImGuiNative.igIsItemToggledOpen();
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is item visible
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsItemVisible()
        {
            byte ret = ImGuiNative.igIsItemVisible();
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is key down
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The bool</returns>
        public static bool IsKeyDown(ImGuiKey key)
        {
            byte ret = ImGuiNative.igIsKeyDown_Nil(key);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is key pressed
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The bool</returns>
        public static bool IsKeyPressed(ImGuiKey key)
        {
            byte repeat = 1;
            byte ret = ImGuiNative.igIsKeyPressed_Bool(key, repeat);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is key pressed
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="repeat">The repeat</param>
        /// <returns>The bool</returns>
        public static bool IsKeyPressed(ImGuiKey key, bool repeat)
        {
            byte nativeRepeat = repeat ? (byte) 1 : (byte) 0;
            byte ret = ImGuiNative.igIsKeyPressed_Bool(key, nativeRepeat);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is key released
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The bool</returns>
        public static bool IsKeyReleased(ImGuiKey key)
        {
            byte ret = ImGuiNative.igIsKeyReleased_Nil(key);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is mouse clicked
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The bool</returns>
        public static bool IsMouseClicked(ImGuiMouseButton button)
        {
            byte repeat = 0;
            byte ret = ImGuiNative.igIsMouseClicked_Bool(button, repeat);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is mouse clicked
        /// </summary>
        /// <param name="button">The button</param>
        /// <param name="repeat">The repeat</param>
        /// <returns>The bool</returns>
        public static bool IsMouseClicked(ImGuiMouseButton button, bool repeat)
        {
            byte nativeRepeat = repeat ? (byte) 1 : (byte) 0;
            byte ret = ImGuiNative.igIsMouseClicked_Bool(button, nativeRepeat);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is mouse double clicked
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The bool</returns>
        public static bool IsMouseDoubleClicked(ImGuiMouseButton button)
        {
            byte ret = ImGuiNative.igIsMouseDoubleClicked(button);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is mouse down
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The bool</returns>
        public static bool IsMouseDown(ImGuiMouseButton button)
        {
            byte ret = ImGuiNative.igIsMouseDown_Nil(button);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is mouse dragging
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The bool</returns>
        public static bool IsMouseDragging(ImGuiMouseButton button)
        {
            float lockThreshold = -1.0f;
            byte ret = ImGuiNative.igIsMouseDragging(button, lockThreshold);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is mouse dragging
        /// </summary>
        /// <param name="button">The button</param>
        /// <param name="lockThreshold">The lock threshold</param>
        /// <returns>The bool</returns>
        public static bool IsMouseDragging(ImGuiMouseButton button, float lockThreshold)
        {
            byte ret = ImGuiNative.igIsMouseDragging(button, lockThreshold);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is mouse hovering rect
        /// </summary>
        /// <param name="rMin">The min</param>
        /// <param name="rMax">The max</param>
        /// <returns>The bool</returns>
        public static bool IsMouseHoveringRect(Vector2 rMin, Vector2 rMax)
        {
            byte clip = 1;
            byte ret = ImGuiNative.igIsMouseHoveringRect(rMin, rMax, clip);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is mouse hovering rect
        /// </summary>
        /// <param name="rMin">The min</param>
        /// <param name="rMax">The max</param>
        /// <param name="clip">The clip</param>
        /// <returns>The bool</returns>
        public static bool IsMouseHoveringRect(Vector2 rMin, Vector2 rMax, bool clip)
        {
            byte nativeClip = clip ? (byte) 1 : (byte) 0;
            byte ret = ImGuiNative.igIsMouseHoveringRect(rMin, rMax, nativeClip);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is mouse pos valid
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsMousePosValid()
        {
            byte ret = ImGuiNative.igIsMousePosValid(new Vector2());
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is mouse pos valid
        /// </summary>
        /// <param name="mousePos">The mouse pos</param>
        /// <returns>The bool</returns>
        public static bool IsMousePosValid(ref Vector2 mousePos)
        {
            byte ret = ImGuiNative.igIsMousePosValid(mousePos);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is mouse released
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The bool</returns>
        public static bool IsMouseReleased(ImGuiMouseButton button)
        {
            byte ret = ImGuiNative.igIsMouseReleased_Nil(button);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is popup open
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <returns>The bool</returns>
        public static bool IsPopupOpen(string strId)
        {
            byte ret = ImGuiNative.igIsPopupOpen_Str(Encoding.UTF8.GetBytes(strId), ImGuiPopupFlags.None);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is popup open
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool IsPopupOpen(string strId, ImGuiPopupFlags flags)
        {
            byte ret = ImGuiNative.igIsPopupOpen_Str(Encoding.UTF8.GetBytes(strId), flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is rect visible
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool IsRectVisible(Vector2 size)
        {
            byte ret = ImGuiNative.igIsRectVisible_Nil(size);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is rect visible
        /// </summary>
        /// <param name="rectMin">The rect min</param>
        /// <param name="rectMax">The rect max</param>
        /// <returns>The bool</returns>
        public static bool IsRectVisible(Vector2 rectMin, Vector2 rectMax)
        {
            byte ret = ImGuiNative.igIsRectVisible_Vec2(rectMin, rectMax);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is window appearing
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsWindowAppearing()
        {
            byte ret = ImGuiNative.igIsWindowAppearing();
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is window collapsed
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsWindowCollapsed()
        {
            byte ret = ImGuiNative.igIsWindowCollapsed();
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is window docked
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsWindowDocked()
        {
            byte ret = ImGuiNative.igIsWindowDocked();
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is window focused
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsWindowFocused()
        {
            ImGuiFocusedFlags flags = 0;
            byte ret = ImGuiNative.igIsWindowFocused(flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is window focused
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool IsWindowFocused(ImGuiFocusedFlags flags)
        {
            byte ret = ImGuiNative.igIsWindowFocused(flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is window hovered
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsWindowHovered()
        {
            ImGuiHoveredFlags flags = 0;
            byte ret = ImGuiNative.igIsWindowHovered(flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is window hovered
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool IsWindowHovered(ImGuiHoveredFlags flags)
        {
            byte ret = ImGuiNative.igIsWindowHovered(flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Labels the text using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="fmt">The fmt</param>
        public static void LabelText(string label, string fmt)
        {
            ImGuiNative.igLabelText(Encoding.UTF8.GetBytes(label), Encoding.UTF8.GetBytes(fmt));
        }
        
        /// <summary>
        ///     Describes whether list box
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="currentItem">The current item</param>
        /// <param name="items">The items</param>
        /// <param name="itemsCount">The items count</param>
        /// <returns>The bool</returns>
        public static bool ListBox(string label, ref int currentItem, string[] items, int itemsCount)
        {
            byte[][] itemsNative = new byte[items.Length][];
            for (int i = 0; i < itemsNative.Length; i++)
            {
                itemsNative[i] = Encoding.UTF8.GetBytes(items[i]);
            }
            
            byte ret = ImGuiNative.igListBox_Str_arr(Encoding.UTF8.GetBytes(label), ref currentItem, itemsNative, itemsCount, -1);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether list box
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="currentItem">The current item</param>
        /// <param name="items">The items</param>
        /// <param name="itemsCount">The items count</param>
        /// <param name="heightInItems">The height in items</param>
        /// <returns>The bool</returns>
        public static bool ListBox(string label, ref int currentItem, string[] items, int itemsCount, int heightInItems)
        {
            byte[][] itemsNative = new byte[items.Length][];
            for (int i = 0; i < itemsNative.Length; i++)
            {
                itemsNative[i] = Encoding.UTF8.GetBytes(items[i]);
            }
            
            byte ret = ImGuiNative.igListBox_Str_arr(Encoding.UTF8.GetBytes(label), ref currentItem, itemsNative, itemsCount, heightInItems);
                
                return ret != 0;
            
        }
        
        /// <summary>
        ///     Loads the ini settings from disk using the specified ini filename
        /// </summary>
        /// <param name="iniFilename">The ini filename</param>
        public static void LoadIniSettingsFromDisk(string iniFilename)
        {
            ImGuiNative.igLoadIniSettingsFromDisk(Encoding.UTF8.GetBytes(iniFilename));
        }
        
        /// <summary>
        ///     Loads the ini settings from memory using the specified ini data
        /// </summary>
        /// <param name="iniData">The ini data</param>
        public static void LoadIniSettingsFromMemory(string iniData)
        {
            ImGuiNative.igLoadIniSettingsFromMemory(Encoding.UTF8.GetBytes(iniData), (uint) Encoding.UTF8.GetByteCount(iniData));
        }
        
        /// <summary>
        ///     Loads the ini settings from memory using the specified ini data
        /// </summary>
        /// <param name="iniData">The ini data</param>
        /// <param name="iniSize">The ini size</param>
        public static void LoadIniSettingsFromMemory(string iniData, uint iniSize)
        {
            ImGuiNative.igLoadIniSettingsFromMemory(Encoding.UTF8.GetBytes(iniData), iniSize);
        }
        
        /// <summary>
        ///     Logs the buttons
        /// </summary>
        public static void LogButtons()
        {
            ImGuiNative.igLogButtons();
        }
        
        /// <summary>
        ///     Logs the finish
        /// </summary>
        public static void LogFinish()
        {
            ImGuiNative.igLogFinish();
        }
        
        /// <summary>
        ///     Logs the text using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        public static void LogText(string fmt)
        {
            ImGuiNative.igLogText(Encoding.UTF8.GetBytes(fmt));
        }
        
        /// <summary>
        ///     Logs the to clipboard
        /// </summary>
        public static void LogToClipboard()
        {
            int autoOpenDepth = -1;
            ImGuiNative.igLogToClipboard(autoOpenDepth);
        }
        
        /// <summary>
        ///     Logs the to clipboard using the specified auto open depth
        /// </summary>
        /// <param name="autoOpenDepth">The auto open depth</param>
        public static void LogToClipboard(int autoOpenDepth)
        {
            ImGuiNative.igLogToClipboard(autoOpenDepth);
        }
        
        /// <summary>
        ///     Logs the to file
        /// </summary>
        public static void LogToFile()
        {
            ImGuiNative.igLogToFile(-1, null);
        }
        
        /// <summary>
        ///     Logs the to file using the specified auto open depth
        /// </summary>
        /// <param name="autoOpenDepth">The auto open depth</param>
        public static void LogToFile(int autoOpenDepth)
        {
            ImGuiNative.igLogToFile(autoOpenDepth, null);
            
        }
        
        /// <summary>
        ///     Logs the to file using the specified auto open depth
        /// </summary>
        /// <param name="autoOpenDepth">The auto open depth</param>
        /// <param name="filename">The filename</param>
        public static void LogToFile(int autoOpenDepth, string filename)
        {
            ImGuiNative.igLogToFile(autoOpenDepth, Encoding.UTF8.GetBytes(filename));
        }
        
        /// <summary>
        ///     Logs the to tty
        /// </summary>
        public static void LogToTty()
        {
            int autoOpenDepth = -1;
            ImGuiNative.igLogToTTY(autoOpenDepth);
        }
        
        /// <summary>
        ///     Logs the to tty using the specified auto open depth
        /// </summary>
        /// <param name="autoOpenDepth">The auto open depth</param>
        public static void LogToTty(int autoOpenDepth)
        {
            ImGuiNative.igLogToTTY(autoOpenDepth);
        }
        
        /// <summary>
        ///     Mems the alloc using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        public static IntPtr MemAlloc(uint size)
        {
            IntPtr ret = ImGuiNative.igMemAlloc(size);
            return ret;
        }
        
        /// <summary>
        ///     Mems the free using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public static void MemFree(IntPtr ptr)
        {
            IntPtr nativePtr = ptr;
            ImGuiNative.igMemFree(nativePtr);
        }
        
        /// <summary>
        ///     Describes whether menu item
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool MenuItem(string label)
        {
            byte ret = ImGuiNative.igMenuItem_Bool(Encoding.UTF8.GetBytes(label), null, 0, 1);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether menu item
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="shortcut">The shortcut</param>
        /// <returns>The bool</returns>
        public static bool MenuItem(string label, string shortcut)
        {
            byte ret = ImGuiNative.igMenuItem_Bool(Encoding.UTF8.GetBytes(label), Encoding.UTF8.GetBytes(shortcut), 0, 1);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether menu item
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="shortcut">The shortcut</param>
        /// <param name="selected">The selected</param>
        /// <returns>The bool</returns>
        public static bool MenuItem(string label, string shortcut, bool selected)
        {
            byte ret = ImGuiNative.igMenuItem_Bool(Encoding.UTF8.GetBytes(label), Encoding.UTF8.GetBytes(shortcut), selected ? (byte) 1 : (byte) 0, 1);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether menu item
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="shortcut">The shortcut</param>
        /// <param name="selected">The selected</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The bool</returns>
        public static bool MenuItem(string label, string shortcut, bool selected, bool enabled)
        {
            byte ret = ImGuiNative.igMenuItem_Bool(Encoding.UTF8.GetBytes(label), Encoding.UTF8.GetBytes(shortcut), selected ? (byte) 1 : (byte) 0, enabled ? (byte) 1 : (byte) 0);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether menu item
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="shortcut">The shortcut</param>
        /// <param name="pSelected">The selected</param>
        /// <returns>The bool</returns>
        public static bool MenuItem(string label, string shortcut, ref bool pSelected)
        {
            byte ret = ImGuiNative.igMenuItem_BoolPtr(Encoding.UTF8.GetBytes(label), Encoding.UTF8.GetBytes(shortcut),  pSelected, true);
            return ret != 0;
        }
    }
}