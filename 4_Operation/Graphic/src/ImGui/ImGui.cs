// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGui.cs
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

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    ///     The im gui class
    /// </summary>
    public static unsafe class ImGui
    {
        /// <summary>
        ///     Accepts the drag drop payload using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The im gui payload ptr</returns>
        public static ImGuiPayloadPtr AcceptDragDropPayload(string type)
        {
            byte* nativeType;
            int typeByteCount = 0;
            if (type != null)
            {
                typeByteCount = Encoding.UTF8.GetByteCount(type);
                if (typeByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeType = Util.Allocate(typeByteCount + 1);
                }
                else
                {
                    byte* nativeTypeStackBytes = stackalloc byte[typeByteCount + 1];
                    nativeType = nativeTypeStackBytes;
                }

                int nativeTypeOffset = Util.GetUtf8(type, nativeType, typeByteCount);
                nativeType[nativeTypeOffset] = 0;
            }
            else
            {
                nativeType = null;
            }

            ImGuiDragDropFlags flags = 0;
            ImGuiPayload* ret = ImGuiNative.igAcceptDragDropPayload(nativeType, flags);
            if (typeByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeType);
            }

            return new ImGuiPayloadPtr(ret);
        }

        /// <summary>
        ///     Accepts the drag drop payload using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="flags">The flags</param>
        /// <returns>The im gui payload ptr</returns>
        public static ImGuiPayloadPtr AcceptDragDropPayload(string type, ImGuiDragDropFlags flags)
        {
            byte* nativeType;
            int typeByteCount = 0;
            if (type != null)
            {
                typeByteCount = Encoding.UTF8.GetByteCount(type);
                if (typeByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeType = Util.Allocate(typeByteCount + 1);
                }
                else
                {
                    byte* nativeTypeStackBytes = stackalloc byte[typeByteCount + 1];
                    nativeType = nativeTypeStackBytes;
                }

                int nativeTypeOffset = Util.GetUtf8(type, nativeType, typeByteCount);
                nativeType[nativeTypeOffset] = 0;
            }
            else
            {
                nativeType = null;
            }

            ImGuiPayload* ret = ImGuiNative.igAcceptDragDropPayload(nativeType, flags);
            if (typeByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeType);
            }

            return new ImGuiPayloadPtr(ret);
        }

        /// <summary>
        ///     Aligns the text to frame padding
        /// </summary>
        public static void AlignTextToFramePadding()
        {
            ImGuiNative.igAlignTextToFramePadding();
        }

        /// <summary>
        ///     Describes whether arrow button
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="dir">The dir</param>
        /// <returns>The bool</returns>
        public static bool ArrowButton(string strId, ImGuiDir dir)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            byte ret = ImGuiNative.igArrowButton(nativeStrId, dir);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The bool</returns>
        public static bool Begin(string name)
        {
            byte* nativeName;
            int nameByteCount = 0;
            if (name != null)
            {
                nameByteCount = Encoding.UTF8.GetByteCount(name);
                if (nameByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeName = Util.Allocate(nameByteCount + 1);
                }
                else
                {
                    byte* nativeNameStackBytes = stackalloc byte[nameByteCount + 1];
                    nativeName = nativeNameStackBytes;
                }

                int nativeNameOffset = Util.GetUtf8(name, nativeName, nameByteCount);
                nativeName[nativeNameOffset] = 0;
            }
            else
            {
                nativeName = null;
            }

            byte* pOpen = null;
            ImGuiWindowFlags flags = 0;
            byte ret = ImGuiNative.igBegin(nativeName, pOpen, flags);
            if (nameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeName);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="pOpen">The open</param>
        /// <returns>The bool</returns>
        public static bool Begin(string name, ref bool pOpen)
        {
            byte* nativeName;
            int nameByteCount = 0;
            if (name != null)
            {
                nameByteCount = Encoding.UTF8.GetByteCount(name);
                if (nameByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeName = Util.Allocate(nameByteCount + 1);
                }
                else
                {
                    byte* nativeNameStackBytes = stackalloc byte[nameByteCount + 1];
                    nativeName = nativeNameStackBytes;
                }

                int nativeNameOffset = Util.GetUtf8(name, nativeName, nameByteCount);
                nativeName[nativeNameOffset] = 0;
            }
            else
            {
                nativeName = null;
            }

            byte nativePOpenVal = pOpen ? (byte) 1 : (byte) 0;
            byte* nativePOpen = &nativePOpenVal;
            ImGuiWindowFlags flags = 0;
            byte ret = ImGuiNative.igBegin(nativeName, nativePOpen, flags);
            if (nameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeName);
            }

            pOpen = nativePOpenVal != 0;
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="pOpen">The open</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool Begin(string name, ref bool pOpen, ImGuiWindowFlags flags)
        {
            byte* nativeName;
            int nameByteCount = 0;
            if (name != null)
            {
                nameByteCount = Encoding.UTF8.GetByteCount(name);
                if (nameByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeName = Util.Allocate(nameByteCount + 1);
                }
                else
                {
                    byte* nativeNameStackBytes = stackalloc byte[nameByteCount + 1];
                    nativeName = nativeNameStackBytes;
                }

                int nativeNameOffset = Util.GetUtf8(name, nativeName, nameByteCount);
                nativeName[nativeNameOffset] = 0;
            }
            else
            {
                nativeName = null;
            }

            byte nativePOpenVal = pOpen ? (byte) 1 : (byte) 0;
            byte* nativePOpen = &nativePOpenVal;
            byte ret = ImGuiNative.igBegin(nativeName, nativePOpen, flags);
            if (nameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeName);
            }

            pOpen = nativePOpenVal != 0;
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin child
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <returns>The bool</returns>
        public static bool BeginChild(string strId)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            Vector2F size = new Vector2F();
            byte border = 0;
            ImGuiWindowFlags flags = 0;
            byte ret = ImGuiNative.igBeginChild_Str(nativeStrId, size, border, flags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin child
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool BeginChild(string strId, Vector2F size)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            byte border = 0;
            ImGuiWindowFlags flags = 0;
            byte ret = ImGuiNative.igBeginChild_Str(nativeStrId, size, border, flags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin child
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="size">The size</param>
        /// <param name="border">The border</param>
        /// <returns>The bool</returns>
        public static bool BeginChild(string strId, Vector2F size, bool border)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            byte nativeBorder = border ? (byte) 1 : (byte) 0;
            ImGuiWindowFlags flags = 0;
            byte ret = ImGuiNative.igBeginChild_Str(nativeStrId, size, nativeBorder, flags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin child
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="size">The size</param>
        /// <param name="border">The border</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginChild(string strId, Vector2F size, bool border, ImGuiWindowFlags flags)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            byte nativeBorder = border ? (byte) 1 : (byte) 0;
            byte ret = ImGuiNative.igBeginChild_Str(nativeStrId, size, nativeBorder, flags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin child
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The bool</returns>
        public static bool BeginChild(uint id)
        {
            Vector2F size = new Vector2F();
            byte border = 0;
            ImGuiWindowFlags flags = 0;
            byte ret = ImGuiNative.igBeginChild_ID(id, size, border, flags);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin child
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool BeginChild(uint id, Vector2F size)
        {
            byte border = 0;
            ImGuiWindowFlags flags = 0;
            byte ret = ImGuiNative.igBeginChild_ID(id, size, border, flags);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin child
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <param name="border">The border</param>
        /// <returns>The bool</returns>
        public static bool BeginChild(uint id, Vector2F size, bool border)
        {
            byte nativeBorder = border ? (byte) 1 : (byte) 0;
            ImGuiWindowFlags flags = 0;
            byte ret = ImGuiNative.igBeginChild_ID(id, size, nativeBorder, flags);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin child
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <param name="border">The border</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginChild(uint id, Vector2F size, bool border, ImGuiWindowFlags flags)
        {
            byte nativeBorder = border ? (byte) 1 : (byte) 0;
            byte ret = ImGuiNative.igBeginChild_ID(id, size, nativeBorder, flags);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin child frame
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool BeginChildFrame(uint id, Vector2F size)
        {
            ImGuiWindowFlags flags = 0;
            byte ret = ImGuiNative.igBeginChildFrame(id, size, flags);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin child frame
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginChildFrame(uint id, Vector2F size, ImGuiWindowFlags flags)
        {
            byte ret = ImGuiNative.igBeginChildFrame(id, size, flags);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin combo
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="previewValue">The preview value</param>
        /// <returns>The bool</returns>
        public static bool BeginCombo(string label, string previewValue)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativePreviewValue;
            int previewValueByteCount = 0;
            if (previewValue != null)
            {
                previewValueByteCount = Encoding.UTF8.GetByteCount(previewValue);
                if (previewValueByteCount > Util.StackAllocationSizeLimit)
                {
                    nativePreviewValue = Util.Allocate(previewValueByteCount + 1);
                }
                else
                {
                    byte* nativePreviewValueStackBytes = stackalloc byte[previewValueByteCount + 1];
                    nativePreviewValue = nativePreviewValueStackBytes;
                }

                int nativePreviewValueOffset = Util.GetUtf8(previewValue, nativePreviewValue, previewValueByteCount);
                nativePreviewValue[nativePreviewValueOffset] = 0;
            }
            else
            {
                nativePreviewValue = null;
            }

            ImGuiComboFlags flags = 0;
            byte ret = ImGuiNative.igBeginCombo(nativeLabel, nativePreviewValue, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            if (previewValueByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativePreviewValue);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin combo
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="previewValue">The preview value</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginCombo(string label, string previewValue, ImGuiComboFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativePreviewValue;
            int previewValueByteCount = 0;
            if (previewValue != null)
            {
                previewValueByteCount = Encoding.UTF8.GetByteCount(previewValue);
                if (previewValueByteCount > Util.StackAllocationSizeLimit)
                {
                    nativePreviewValue = Util.Allocate(previewValueByteCount + 1);
                }
                else
                {
                    byte* nativePreviewValueStackBytes = stackalloc byte[previewValueByteCount + 1];
                    nativePreviewValue = nativePreviewValueStackBytes;
                }

                int nativePreviewValueOffset = Util.GetUtf8(previewValue, nativePreviewValue, previewValueByteCount);
                nativePreviewValue[nativePreviewValueOffset] = 0;
            }
            else
            {
                nativePreviewValue = null;
            }

            byte ret = ImGuiNative.igBeginCombo(nativeLabel, nativePreviewValue, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            if (previewValueByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativePreviewValue);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Begins the disabled
        /// </summary>
        public static void BeginDisabled()
        {
            byte disabled = 1;
            ImGuiNative.igBeginDisabled(disabled);
        }

        /// <summary>
        ///     Begins the disabled using the specified disabled
        /// </summary>
        /// <param name="disabled">The disabled</param>
        public static void BeginDisabled(bool disabled)
        {
            byte nativeDisabled = disabled ? (byte) 1 : (byte) 0;
            ImGuiNative.igBeginDisabled(nativeDisabled);
        }

        /// <summary>
        ///     Describes whether begin drag drop source
        /// </summary>
        /// <returns>The bool</returns>
        public static bool BeginDragDropSource()
        {
            ImGuiDragDropFlags flags = 0;
            byte ret = ImGuiNative.igBeginDragDropSource(flags);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin drag drop source
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginDragDropSource(ImGuiDragDropFlags flags)
        {
            byte ret = ImGuiNative.igBeginDragDropSource(flags);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin drag drop target
        /// </summary>
        /// <returns>The bool</returns>
        public static bool BeginDragDropTarget()
        {
            byte ret = ImGuiNative.igBeginDragDropTarget();
            return ret != 0;
        }

        /// <summary>
        ///     Begins the group
        /// </summary>
        public static void BeginGroup()
        {
            ImGuiNative.igBeginGroup();
        }

        /// <summary>
        ///     Describes whether begin list box
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool BeginListBox(string label)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            Vector2F size = new Vector2F();
            byte ret = ImGuiNative.igBeginListBox(nativeLabel, size);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin list box
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool BeginListBox(string label, Vector2F size)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte ret = ImGuiNative.igBeginListBox(nativeLabel, size);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin main menu bar
        /// </summary>
        /// <returns>The bool</returns>
        public static bool BeginMainMenuBar()
        {
            byte ret = ImGuiNative.igBeginMainMenuBar();
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin menu
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool BeginMenu(string label)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte enabled = 1;
            byte ret = ImGuiNative.igBeginMenu(nativeLabel, enabled);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin menu
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The bool</returns>
        public static bool BeginMenu(string label, bool enabled)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte nativeEnabled = enabled ? (byte) 1 : (byte) 0;
            byte ret = ImGuiNative.igBeginMenu(nativeLabel, nativeEnabled);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin menu bar
        /// </summary>
        /// <returns>The bool</returns>
        public static bool BeginMenuBar()
        {
            byte ret = ImGuiNative.igBeginMenuBar();
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin popup
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <returns>The bool</returns>
        public static bool BeginPopup(string strId)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            ImGuiWindowFlags flags = 0;
            byte ret = ImGuiNative.igBeginPopup(nativeStrId, flags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin popup
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginPopup(string strId, ImGuiWindowFlags flags)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            byte ret = ImGuiNative.igBeginPopup(nativeStrId, flags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin popup context item
        /// </summary>
        /// <returns>The bool</returns>
        public static bool BeginPopupContextItem()
        {
            byte* nativeStrId = null;
            ImGuiPopupFlags popupFlags = (ImGuiPopupFlags) 1;
            byte ret = ImGuiNative.igBeginPopupContextItem(nativeStrId, popupFlags);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin popup context item
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <returns>The bool</returns>
        public static bool BeginPopupContextItem(string strId)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            ImGuiPopupFlags popupFlags = (ImGuiPopupFlags) 1;
            byte ret = ImGuiNative.igBeginPopupContextItem(nativeStrId, popupFlags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin popup context item
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="popupFlags">The popup flags</param>
        /// <returns>The bool</returns>
        public static bool BeginPopupContextItem(string strId, ImGuiPopupFlags popupFlags)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            byte ret = ImGuiNative.igBeginPopupContextItem(nativeStrId, popupFlags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin popup context void
        /// </summary>
        /// <returns>The bool</returns>
        public static bool BeginPopupContextVoid()
        {
            byte* nativeStrId = null;
            ImGuiPopupFlags popupFlags = (ImGuiPopupFlags) 1;
            byte ret = ImGuiNative.igBeginPopupContextVoid(nativeStrId, popupFlags);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin popup context void
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <returns>The bool</returns>
        public static bool BeginPopupContextVoid(string strId)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            ImGuiPopupFlags popupFlags = (ImGuiPopupFlags) 1;
            byte ret = ImGuiNative.igBeginPopupContextVoid(nativeStrId, popupFlags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin popup context void
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="popupFlags">The popup flags</param>
        /// <returns>The bool</returns>
        public static bool BeginPopupContextVoid(string strId, ImGuiPopupFlags popupFlags)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            byte ret = ImGuiNative.igBeginPopupContextVoid(nativeStrId, popupFlags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin popup context window
        /// </summary>
        /// <returns>The bool</returns>
        public static bool BeginPopupContextWindow()
        {
            byte* nativeStrId = null;
            ImGuiPopupFlags popupFlags = (ImGuiPopupFlags) 1;
            byte ret = ImGuiNative.igBeginPopupContextWindow(nativeStrId, popupFlags);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin popup context window
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <returns>The bool</returns>
        public static bool BeginPopupContextWindow(string strId)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            ImGuiPopupFlags popupFlags = (ImGuiPopupFlags) 1;
            byte ret = ImGuiNative.igBeginPopupContextWindow(nativeStrId, popupFlags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin popup context window
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="popupFlags">The popup flags</param>
        /// <returns>The bool</returns>
        public static bool BeginPopupContextWindow(string strId, ImGuiPopupFlags popupFlags)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            byte ret = ImGuiNative.igBeginPopupContextWindow(nativeStrId, popupFlags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin popup modal
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The bool</returns>
        public static bool BeginPopupModal(string name)
        {
            byte* nativeName;
            int nameByteCount = 0;
            if (name != null)
            {
                nameByteCount = Encoding.UTF8.GetByteCount(name);
                if (nameByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeName = Util.Allocate(nameByteCount + 1);
                }
                else
                {
                    byte* nativeNameStackBytes = stackalloc byte[nameByteCount + 1];
                    nativeName = nativeNameStackBytes;
                }

                int nativeNameOffset = Util.GetUtf8(name, nativeName, nameByteCount);
                nativeName[nativeNameOffset] = 0;
            }
            else
            {
                nativeName = null;
            }

            byte* pOpen = null;
            ImGuiWindowFlags flags = 0;
            byte ret = ImGuiNative.igBeginPopupModal(nativeName, pOpen, flags);
            if (nameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeName);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin popup modal
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="pOpen">The open</param>
        /// <returns>The bool</returns>
        public static bool BeginPopupModal(string name, ref bool pOpen)
        {
            byte* nativeName;
            int nameByteCount = 0;
            if (name != null)
            {
                nameByteCount = Encoding.UTF8.GetByteCount(name);
                if (nameByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeName = Util.Allocate(nameByteCount + 1);
                }
                else
                {
                    byte* nativeNameStackBytes = stackalloc byte[nameByteCount + 1];
                    nativeName = nativeNameStackBytes;
                }

                int nativeNameOffset = Util.GetUtf8(name, nativeName, nameByteCount);
                nativeName[nativeNameOffset] = 0;
            }
            else
            {
                nativeName = null;
            }

            byte nativePOpenVal = pOpen ? (byte) 1 : (byte) 0;
            byte* nativePOpen = &nativePOpenVal;
            ImGuiWindowFlags flags = 0;
            byte ret = ImGuiNative.igBeginPopupModal(nativeName, nativePOpen, flags);
            if (nameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeName);
            }

            pOpen = nativePOpenVal != 0;
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin popup modal
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="pOpen">The open</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginPopupModal(string name, ref bool pOpen, ImGuiWindowFlags flags)
        {
            byte* nativeName;
            int nameByteCount = 0;
            if (name != null)
            {
                nameByteCount = Encoding.UTF8.GetByteCount(name);
                if (nameByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeName = Util.Allocate(nameByteCount + 1);
                }
                else
                {
                    byte* nativeNameStackBytes = stackalloc byte[nameByteCount + 1];
                    nativeName = nativeNameStackBytes;
                }

                int nativeNameOffset = Util.GetUtf8(name, nativeName, nameByteCount);
                nativeName[nativeNameOffset] = 0;
            }
            else
            {
                nativeName = null;
            }

            byte nativePOpenVal = pOpen ? (byte) 1 : (byte) 0;
            byte* nativePOpen = &nativePOpenVal;
            byte ret = ImGuiNative.igBeginPopupModal(nativeName, nativePOpen, flags);
            if (nameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeName);
            }

            pOpen = nativePOpenVal != 0;
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin tab bar
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <returns>The bool</returns>
        public static bool BeginTabBar(string strId)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            ImGuiTabBarFlags flags = 0;
            byte ret = ImGuiNative.igBeginTabBar(nativeStrId, flags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin tab bar
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginTabBar(string strId, ImGuiTabBarFlags flags)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            byte ret = ImGuiNative.igBeginTabBar(nativeStrId, flags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin tab item
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool BeginTabItem(string label)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* pOpen = null;
            ImGuiTabItemFlags flags = 0;
            byte ret = ImGuiNative.igBeginTabItem(nativeLabel, pOpen, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin tab item
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="pOpen">The open</param>
        /// <returns>The bool</returns>
        public static bool BeginTabItem(string label, ref bool pOpen)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte nativePOpenVal = pOpen ? (byte) 1 : (byte) 0;
            byte* nativePOpen = &nativePOpenVal;
            ImGuiTabItemFlags flags = 0;
            byte ret = ImGuiNative.igBeginTabItem(nativeLabel, nativePOpen, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            pOpen = nativePOpenVal != 0;
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin tab item
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="pOpen">The open</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginTabItem(string label, ref bool pOpen, ImGuiTabItemFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte nativePOpenVal = pOpen ? (byte) 1 : (byte) 0;
            byte* nativePOpen = &nativePOpenVal;
            byte ret = ImGuiNative.igBeginTabItem(nativeLabel, nativePOpen, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            pOpen = nativePOpenVal != 0;
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin table
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="column">The column</param>
        /// <returns>The bool</returns>
        public static bool BeginTable(string strId, int column)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            ImGuiTableFlags flags = 0;
            Vector2F outerSize = new Vector2F();
            float innerWidth = 0.0f;
            byte ret = ImGuiNative.igBeginTable(nativeStrId, column, flags, outerSize, innerWidth);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin table
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="column">The column</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginTable(string strId, int column, ImGuiTableFlags flags)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            Vector2F outerSize = new Vector2F();
            float innerWidth = 0.0f;
            byte ret = ImGuiNative.igBeginTable(nativeStrId, column, flags, outerSize, innerWidth);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin table
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="column">The column</param>
        /// <param name="flags">The flags</param>
        /// <param name="outerSize">The outer size</param>
        /// <returns>The bool</returns>
        public static bool BeginTable(string strId, int column, ImGuiTableFlags flags, Vector2F outerSize)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            float innerWidth = 0.0f;
            byte ret = ImGuiNative.igBeginTable(nativeStrId, column, flags, outerSize, innerWidth);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin table
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="column">The column</param>
        /// <param name="flags">The flags</param>
        /// <param name="outerSize">The outer size</param>
        /// <param name="innerWidth">The inner width</param>
        /// <returns>The bool</returns>
        public static bool BeginTable(string strId, int column, ImGuiTableFlags flags, Vector2F outerSize, float innerWidth)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            byte ret = ImGuiNative.igBeginTable(nativeStrId, column, flags, outerSize, innerWidth);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether begin tooltip
        /// </summary>
        /// <returns>The bool</returns>
        public static bool BeginTooltip()
        {
            byte ret = ImGuiNative.igBeginTooltip();
            return ret != 0;
        }

        /// <summary>
        ///     Bullets
        /// </summary>
        public static void Bullet()
        {
            ImGuiNative.igBullet();
        }

        /// <summary>
        ///     Bullets the text using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        public static void BulletText(string fmt)
        {
            byte* nativeFmt;
            int fmtByteCount = 0;
            if (fmt != null)
            {
                fmtByteCount = Encoding.UTF8.GetByteCount(fmt);
                if (fmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFmt = Util.Allocate(fmtByteCount + 1);
                }
                else
                {
                    byte* nativeFmtStackBytes = stackalloc byte[fmtByteCount + 1];
                    nativeFmt = nativeFmtStackBytes;
                }

                int nativeFmtOffset = Util.GetUtf8(fmt, nativeFmt, fmtByteCount);
                nativeFmt[nativeFmtOffset] = 0;
            }
            else
            {
                nativeFmt = null;
            }

            ImGuiNative.igBulletText(nativeFmt);
            if (fmtByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFmt);
            }
        }

        /// <summary>
        ///     Describes whether button
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool Button(string label)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            Vector2F size = new Vector2F();
            byte ret = ImGuiNative.igButton(nativeLabel, size);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether button
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool Button(string label, Vector2F size)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte ret = ImGuiNative.igButton(nativeLabel, size);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Calcs the item width
        /// </summary>
        /// <returns>The ret</returns>
        public static float CalcItemWidth()
        {
            float ret = ImGuiNative.igCalcItemWidth();
            return ret;
        }

        /// <summary>
        ///     Describes whether checkbox
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool Checkbox(string label, ref bool v)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte nativeVVal = v ? (byte) 1 : (byte) 0;
            byte* nativeV = &nativeVVal;
            byte ret = ImGuiNative.igCheckbox(nativeLabel, nativeV);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            v = nativeVVal != 0;
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether checkbox flags
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <param name="flagsValue">The flags value</param>
        /// <returns>The bool</returns>
        public static bool CheckboxFlags(string label, ref int flags, int flagsValue)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            fixed (int* nativeFlags = &flags)
            {
                byte ret = ImGuiNative.igCheckboxFlags_IntPtr(nativeLabel, nativeFlags, flagsValue);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether checkbox flags
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <param name="flagsValue">The flags value</param>
        /// <returns>The bool</returns>
        public static bool CheckboxFlags(string label, ref uint flags, uint flagsValue)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            fixed (uint* nativeFlags = &flags)
            {
                byte ret = ImGuiNative.igCheckboxFlags_UintPtr(nativeLabel, nativeFlags, flagsValue);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Closes the current popup
        /// </summary>
        public static void CloseCurrentPopup()
        {
            ImGuiNative.igCloseCurrentPopup();
        }

        /// <summary>
        ///     Describes whether collapsing header
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool CollapsingHeader(string label)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            ImGuiTreeNodeFlags flags = 0;
            byte ret = ImGuiNative.igCollapsingHeader_TreeNodeFlags(nativeLabel, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether collapsing header
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool CollapsingHeader(string label, ImGuiTreeNodeFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte ret = ImGuiNative.igCollapsingHeader_TreeNodeFlags(nativeLabel, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether collapsing header
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="pVisible">The visible</param>
        /// <returns>The bool</returns>
        public static bool CollapsingHeader(string label, ref bool pVisible)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte nativePVisibleVal = pVisible ? (byte) 1 : (byte) 0;
            byte* nativePVisible = &nativePVisibleVal;
            ImGuiTreeNodeFlags flags = 0;
            byte ret = ImGuiNative.igCollapsingHeader_BoolPtr(nativeLabel, nativePVisible, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            pVisible = nativePVisibleVal != 0;
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether collapsing header
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="pVisible">The visible</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool CollapsingHeader(string label, ref bool pVisible, ImGuiTreeNodeFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte nativePVisibleVal = pVisible ? (byte) 1 : (byte) 0;
            byte* nativePVisible = &nativePVisibleVal;
            byte ret = ImGuiNative.igCollapsingHeader_BoolPtr(nativeLabel, nativePVisible, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            pVisible = nativePVisibleVal != 0;
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether color button
        /// </summary>
        /// <param name="descId">The desc id</param>
        /// <param name="col">The col</param>
        /// <returns>The bool</returns>
        public static bool ColorButton(string descId, Vector4F col)
        {
            byte* nativeDescId;
            int descIdByteCount = 0;
            if (descId != null)
            {
                descIdByteCount = Encoding.UTF8.GetByteCount(descId);
                if (descIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeDescId = Util.Allocate(descIdByteCount + 1);
                }
                else
                {
                    byte* nativeDescIdStackBytes = stackalloc byte[descIdByteCount + 1];
                    nativeDescId = nativeDescIdStackBytes;
                }

                int nativeDescIdOffset = Util.GetUtf8(descId, nativeDescId, descIdByteCount);
                nativeDescId[nativeDescIdOffset] = 0;
            }
            else
            {
                nativeDescId = null;
            }

            ImGuiColorEditFlags flags = 0;
            Vector2F size = new Vector2F();
            byte ret = ImGuiNative.igColorButton(nativeDescId, col, flags, size);
            if (descIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeDescId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether color button
        /// </summary>
        /// <param name="descId">The desc id</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool ColorButton(string descId, Vector4F col, ImGuiColorEditFlags flags)
        {
            byte* nativeDescId;
            int descIdByteCount = 0;
            if (descId != null)
            {
                descIdByteCount = Encoding.UTF8.GetByteCount(descId);
                if (descIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeDescId = Util.Allocate(descIdByteCount + 1);
                }
                else
                {
                    byte* nativeDescIdStackBytes = stackalloc byte[descIdByteCount + 1];
                    nativeDescId = nativeDescIdStackBytes;
                }

                int nativeDescIdOffset = Util.GetUtf8(descId, nativeDescId, descIdByteCount);
                nativeDescId[nativeDescIdOffset] = 0;
            }
            else
            {
                nativeDescId = null;
            }

            Vector2F size = new Vector2F();
            byte ret = ImGuiNative.igColorButton(nativeDescId, col, flags, size);
            if (descIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeDescId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether color button
        /// </summary>
        /// <param name="descId">The desc id</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool ColorButton(string descId, Vector4F col, ImGuiColorEditFlags flags, Vector2F size)
        {
            byte* nativeDescId;
            int descIdByteCount = 0;
            if (descId != null)
            {
                descIdByteCount = Encoding.UTF8.GetByteCount(descId);
                if (descIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeDescId = Util.Allocate(descIdByteCount + 1);
                }
                else
                {
                    byte* nativeDescIdStackBytes = stackalloc byte[descIdByteCount + 1];
                    nativeDescId = nativeDescIdStackBytes;
                }

                int nativeDescIdOffset = Util.GetUtf8(descId, nativeDescId, descIdByteCount);
                nativeDescId[nativeDescIdOffset] = 0;
            }
            else
            {
                nativeDescId = null;
            }

            byte ret = ImGuiNative.igColorButton(nativeDescId, col, flags, size);
            if (descIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeDescId);
            }

            return ret != 0;
        }

        /// <summary>
        /// </summary>
        /// <param name="in"></param>
        /// <returns></returns>
        public static uint ColorConvertFloat4ToU32(Vector4F @in)
        {
            uint ret = ImGuiNative.igColorConvertFloat4ToU32(@in);
            return ret;
        }

        /// <summary>
        ///     Colors the convert hs vto rgb using the specified h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        /// <param name="outR">The out</param>
        /// <param name="outG">The out</param>
        /// <param name="outB">The out</param>
        public static void ColorConvertHsVtoRgb(float h, float s, float v, out float outR, out float outG, out float outB)
        {
            fixed (float* nativeOutR = &outR)
            {
                fixed (float* nativeOutG = &outG)
                {
                    fixed (float* nativeOutB = &outB)
                    {
                        ImGuiNative.igColorConvertHSVtoRGB(h, s, v, nativeOutR, nativeOutG, nativeOutB);
                    }
                }
            }
        }

        /// <summary>
        ///     Colors the convert rg bto hsv using the specified r
        /// </summary>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="outH">The out</param>
        /// <param name="outS">The out</param>
        /// <param name="outV">The out</param>
        public static void ColorConvertRgBtoHsv(float r, float g, float b, out float outH, out float outS, out float outV)
        {
            fixed (float* nativeOutH = &outH)
            {
                fixed (float* nativeOutS = &outS)
                {
                    fixed (float* nativeOutV = &outV)
                    {
                        ImGuiNative.igColorConvertRGBtoHSV(r, g, b, nativeOutH, nativeOutS, nativeOutV);
                    }
                }
            }
        }

        /// <summary>
        ///     /
        /// </summary>
        /// <param name="in"></param>
        /// <returns></returns>
        public static Vector4F ColorConvertU32ToFloat4(uint @in)
        {
            Vector4F retval;
            ImGuiNative.igColorConvertU32ToFloat4(&retval, @in);
            return retval;
        }

        /// <summary>
        ///     Describes whether color edit 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <returns>The bool</returns>
        public static bool ColorEdit3(string label, ref Vector3F col)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            ImGuiColorEditFlags flags = 0;
            fixed (Vector3F* nativeCol = &col)
            {
                byte ret = ImGuiNative.igColorEdit3(nativeLabel, nativeCol, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether color edit 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool ColorEdit3(string label, ref Vector3F col, ImGuiColorEditFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            fixed (Vector3F* nativeCol = &col)
            {
                byte ret = ImGuiNative.igColorEdit3(nativeLabel, nativeCol, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether color edit 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <returns>The bool</returns>
        public static bool ColorEdit4(string label, ref Vector4F col)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            ImGuiColorEditFlags flags = 0;
            fixed (Vector4F* nativeCol = &col)
            {
                byte ret = ImGuiNative.igColorEdit4(nativeLabel, nativeCol, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether color edit 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool ColorEdit4(string label, ref Vector4F col, ImGuiColorEditFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            fixed (Vector4F* nativeCol = &col)
            {
                byte ret = ImGuiNative.igColorEdit4(nativeLabel, nativeCol, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether color picker 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <returns>The bool</returns>
        public static bool ColorPicker3(string label, ref Vector3F col)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            ImGuiColorEditFlags flags = 0;
            fixed (Vector3F* nativeCol = &col)
            {
                byte ret = ImGuiNative.igColorPicker3(nativeLabel, nativeCol, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether color picker 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool ColorPicker3(string label, ref Vector3F col, ImGuiColorEditFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            fixed (Vector3F* nativeCol = &col)
            {
                byte ret = ImGuiNative.igColorPicker3(nativeLabel, nativeCol, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether color picker 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <returns>The bool</returns>
        public static bool ColorPicker4(string label, ref Vector4F col)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            ImGuiColorEditFlags flags = 0;
            float* refCol = null;
            fixed (Vector4F* nativeCol = &col)
            {
                byte ret = ImGuiNative.igColorPicker4(nativeLabel, nativeCol, flags, refCol);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether color picker 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool ColorPicker4(string label, ref Vector4F col, ImGuiColorEditFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            float* refCol = null;
            fixed (Vector4F* nativeCol = &col)
            {
                byte ret = ImGuiNative.igColorPicker4(nativeLabel, nativeCol, flags, refCol);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether color picker 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <param name="refCol">The ref col</param>
        /// <returns>The bool</returns>
        public static bool ColorPicker4(string label, ref Vector4F col, ImGuiColorEditFlags flags, ref float refCol)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            fixed (Vector4F* nativeCol = &col)
            {
                fixed (float* nativeRefCol = &refCol)
                {
                    byte ret = ImGuiNative.igColorPicker4(nativeLabel, nativeCol, flags, nativeRefCol);
                    if (labelByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabel);
                    }

                    return ret != 0;
                }
            }
        }

        /// <summary>
        ///     Columnses
        /// </summary>
        public static void Columns()
        {
            int count = 1;
            byte* nativeId = null;
            byte border = 1;
            ImGuiNative.igColumns(count, nativeId, border);
        }

        /// <summary>
        ///     Columnses the count
        /// </summary>
        /// <param name="count">The count</param>
        public static void Columns(int count)
        {
            byte* nativeId = null;
            byte border = 1;
            ImGuiNative.igColumns(count, nativeId, border);
        }

        /// <summary>
        ///     Columnses the count
        /// </summary>
        /// <param name="count">The count</param>
        /// <param name="id">The id</param>
        public static void Columns(int count, string id)
        {
            byte* nativeId;
            int idByteCount = 0;
            if (id != null)
            {
                idByteCount = Encoding.UTF8.GetByteCount(id);
                if (idByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeId = Util.Allocate(idByteCount + 1);
                }
                else
                {
                    byte* nativeIdStackBytes = stackalloc byte[idByteCount + 1];
                    nativeId = nativeIdStackBytes;
                }

                int nativeIdOffset = Util.GetUtf8(id, nativeId, idByteCount);
                nativeId[nativeIdOffset] = 0;
            }
            else
            {
                nativeId = null;
            }

            byte border = 1;
            ImGuiNative.igColumns(count, nativeId, border);
            if (idByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeId);
            }
        }

        /// <summary>
        ///     Columnses the count
        /// </summary>
        /// <param name="count">The count</param>
        /// <param name="id">The id</param>
        /// <param name="border">The border</param>
        public static void Columns(int count, string id, bool border)
        {
            byte* nativeId;
            int idByteCount = 0;
            if (id != null)
            {
                idByteCount = Encoding.UTF8.GetByteCount(id);
                if (idByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeId = Util.Allocate(idByteCount + 1);
                }
                else
                {
                    byte* nativeIdStackBytes = stackalloc byte[idByteCount + 1];
                    nativeId = nativeIdStackBytes;
                }

                int nativeIdOffset = Util.GetUtf8(id, nativeId, idByteCount);
                nativeId[nativeIdOffset] = 0;
            }
            else
            {
                nativeId = null;
            }

            byte nativeBorder = border ? (byte) 1 : (byte) 0;
            ImGuiNative.igColumns(count, nativeId, nativeBorder);
            if (idByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeId);
            }
        }

        /// <summary>
        ///     Describes whether combo
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="currentItem">The current item</param>
        /// <param name="items">The items</param>
        /// <param name="itemsCount">The items count</param>
        /// <returns>The bool</returns>
        public static bool Combo(string label, ref int currentItem, string[] items, int itemsCount)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            int* itemsByteCounts = stackalloc int[items.Length];
            int itemsByteCount = 0;
            for (int i = 0; i < items.Length; i++)
            {
                string s = items[i];
                itemsByteCounts[i] = Encoding.UTF8.GetByteCount(s);
                itemsByteCount += itemsByteCounts[i] + 1;
            }

            byte* nativeItemsData = stackalloc byte[itemsByteCount];
            int offset = 0;
            for (int i = 0; i < items.Length; i++)
            {
                string s = items[i];
                fixed (char* sPtr = s)
                {
                    offset += Encoding.UTF8.GetBytes(sPtr, s.Length, nativeItemsData + offset, itemsByteCounts[i]);
                    nativeItemsData[offset] = 0;
                    offset += 1;
                }
            }

            byte** nativeItems = stackalloc byte*[items.Length];
            offset = 0;
            for (int i = 0; i < items.Length; i++)
            {
                nativeItems[i] = &nativeItemsData[offset];
                offset += itemsByteCounts[i] + 1;
            }

            int popupMaxHeightInItems = -1;
            fixed (int* nativeCurrentItem = &currentItem)
            {
                byte ret = ImGuiNative.igCombo_Str_arr(nativeLabel, nativeCurrentItem, nativeItems, itemsCount, popupMaxHeightInItems);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether combo
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="currentItem">The current item</param>
        /// <param name="items">The items</param>
        /// <param name="itemsCount">The items count</param>
        /// <param name="popupMaxHeightInItems">The popup max height in items</param>
        /// <returns>The bool</returns>
        public static bool Combo(string label, ref int currentItem, string[] items, int itemsCount, int popupMaxHeightInItems)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            int* itemsByteCounts = stackalloc int[items.Length];
            int itemsByteCount = 0;
            for (int i = 0; i < items.Length; i++)
            {
                string s = items[i];
                itemsByteCounts[i] = Encoding.UTF8.GetByteCount(s);
                itemsByteCount += itemsByteCounts[i] + 1;
            }

            byte* nativeItemsData = stackalloc byte[itemsByteCount];
            int offset = 0;
            for (int i = 0; i < items.Length; i++)
            {
                string s = items[i];
                fixed (char* sPtr = s)
                {
                    offset += Encoding.UTF8.GetBytes(sPtr, s.Length, nativeItemsData + offset, itemsByteCounts[i]);
                    nativeItemsData[offset] = 0;
                    offset += 1;
                }
            }

            byte** nativeItems = stackalloc byte*[items.Length];
            offset = 0;
            for (int i = 0; i < items.Length; i++)
            {
                nativeItems[i] = &nativeItemsData[offset];
                offset += itemsByteCounts[i] + 1;
            }

            fixed (int* nativeCurrentItem = &currentItem)
            {
                byte ret = ImGuiNative.igCombo_Str_arr(nativeLabel, nativeCurrentItem, nativeItems, itemsCount, popupMaxHeightInItems);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether combo
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="currentItem">The current item</param>
        /// <param name="itemsSeparatedByZeros">The items separated by zeros</param>
        /// <returns>The bool</returns>
        public static bool Combo(string label, ref int currentItem, string itemsSeparatedByZeros)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeItemsSeparatedByZeros;
            int itemsSeparatedByZerosByteCount = 0;
            if (itemsSeparatedByZeros != null)
            {
                itemsSeparatedByZerosByteCount = Encoding.UTF8.GetByteCount(itemsSeparatedByZeros);
                if (itemsSeparatedByZerosByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeItemsSeparatedByZeros = Util.Allocate(itemsSeparatedByZerosByteCount + 1);
                }
                else
                {
                    byte* nativeItemsSeparatedByZerosStackBytes = stackalloc byte[itemsSeparatedByZerosByteCount + 1];
                    nativeItemsSeparatedByZeros = nativeItemsSeparatedByZerosStackBytes;
                }

                int nativeItemsSeparatedByZerosOffset = Util.GetUtf8(itemsSeparatedByZeros, nativeItemsSeparatedByZeros, itemsSeparatedByZerosByteCount);
                nativeItemsSeparatedByZeros[nativeItemsSeparatedByZerosOffset] = 0;
            }
            else
            {
                nativeItemsSeparatedByZeros = null;
            }

            int popupMaxHeightInItems = -1;
            fixed (int* nativeCurrentItem = &currentItem)
            {
                byte ret = ImGuiNative.igCombo_Str(nativeLabel, nativeCurrentItem, nativeItemsSeparatedByZeros, popupMaxHeightInItems);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (itemsSeparatedByZerosByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeItemsSeparatedByZeros);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether combo
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="currentItem">The current item</param>
        /// <param name="itemsSeparatedByZeros">The items separated by zeros</param>
        /// <param name="popupMaxHeightInItems">The popup max height in items</param>
        /// <returns>The bool</returns>
        public static bool Combo(string label, ref int currentItem, string itemsSeparatedByZeros, int popupMaxHeightInItems)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeItemsSeparatedByZeros;
            int itemsSeparatedByZerosByteCount = 0;
            if (itemsSeparatedByZeros != null)
            {
                itemsSeparatedByZerosByteCount = Encoding.UTF8.GetByteCount(itemsSeparatedByZeros);
                if (itemsSeparatedByZerosByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeItemsSeparatedByZeros = Util.Allocate(itemsSeparatedByZerosByteCount + 1);
                }
                else
                {
                    byte* nativeItemsSeparatedByZerosStackBytes = stackalloc byte[itemsSeparatedByZerosByteCount + 1];
                    nativeItemsSeparatedByZeros = nativeItemsSeparatedByZerosStackBytes;
                }

                int nativeItemsSeparatedByZerosOffset = Util.GetUtf8(itemsSeparatedByZeros, nativeItemsSeparatedByZeros, itemsSeparatedByZerosByteCount);
                nativeItemsSeparatedByZeros[nativeItemsSeparatedByZerosOffset] = 0;
            }
            else
            {
                nativeItemsSeparatedByZeros = null;
            }

            fixed (int* nativeCurrentItem = &currentItem)
            {
                byte ret = ImGuiNative.igCombo_Str(nativeLabel, nativeCurrentItem, nativeItemsSeparatedByZeros, popupMaxHeightInItems);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (itemsSeparatedByZerosByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeItemsSeparatedByZeros);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Creates the context
        /// </summary>
        /// <returns>The ret</returns>
        public static IntPtr CreateContext()
        {
            ImFontAtlas* sharedFontAtlas = null;
            IntPtr ret = ImGuiNative.igCreateContext(sharedFontAtlas);
            return ret;
        }

        /// <summary>
        ///     Creates the context using the specified shared font atlas
        /// </summary>
        /// <param name="sharedFontAtlas">The shared font atlas</param>
        /// <returns>The ret</returns>
        public static IntPtr CreateContext(ImFontAtlasPtr sharedFontAtlas)
        {
            ImFontAtlas* nativeSharedFontAtlas = sharedFontAtlas.NativePtr;
            IntPtr ret = ImGuiNative.igCreateContext(nativeSharedFontAtlas);
            return ret;
        }

        /// <summary>
        ///     Describes whether debug check version and data layout
        /// </summary>
        /// <param name="versionStr">The version str</param>
        /// <param name="szIo">The sz io</param>
        /// <param name="szStyle">The sz style</param>
        /// <param name="szVec2">The sz vec2</param>
        /// <param name="szVec4">The sz vec4</param>
        /// <param name="szDrawvert">The sz drawvert</param>
        /// <param name="szDrawidx">The sz drawidx</param>
        /// <returns>The bool</returns>
        public static bool DebugCheckVersionAndDataLayout(string versionStr, uint szIo, uint szStyle, uint szVec2, uint szVec4, uint szDrawvert, uint szDrawidx)
        {
            byte* nativeVersionStr;
            int versionStrByteCount = 0;
            if (versionStr != null)
            {
                versionStrByteCount = Encoding.UTF8.GetByteCount(versionStr);
                if (versionStrByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeVersionStr = Util.Allocate(versionStrByteCount + 1);
                }
                else
                {
                    byte* nativeVersionStrStackBytes = stackalloc byte[versionStrByteCount + 1];
                    nativeVersionStr = nativeVersionStrStackBytes;
                }

                int nativeVersionStrOffset = Util.GetUtf8(versionStr, nativeVersionStr, versionStrByteCount);
                nativeVersionStr[nativeVersionStrOffset] = 0;
            }
            else
            {
                nativeVersionStr = null;
            }

            byte ret = ImGuiNative.igDebugCheckVersionAndDataLayout(nativeVersionStr, szIo, szStyle, szVec2, szVec4, szDrawvert, szDrawidx);
            if (versionStrByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeVersionStr);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Debugs the text encoding using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        public static void DebugTextEncoding(string text)
        {
            byte* nativeText;
            int textByteCount = 0;
            if (text != null)
            {
                textByteCount = Encoding.UTF8.GetByteCount(text);
                if (textByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeText = Util.Allocate(textByteCount + 1);
                }
                else
                {
                    byte* nativeTextStackBytes = stackalloc byte[textByteCount + 1];
                    nativeText = nativeTextStackBytes;
                }

                int nativeTextOffset = Util.GetUtf8(text, nativeText, textByteCount);
                nativeText[nativeTextOffset] = 0;
            }
            else
            {
                nativeText = null;
            }

            ImGuiNative.igDebugTextEncoding(nativeText);
            if (textByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeText);
            }
        }

        /// <summary>
        ///     Destroys the context
        /// </summary>
        public static void DestroyContext()
        {
            IntPtr ctx = IntPtr.Zero;
            ImGuiNative.igDestroyContext(ctx);
        }

        /// <summary>
        ///     Destroys the context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        public static void DestroyContext(IntPtr ctx)
        {
            ImGuiNative.igDestroyContext(ctx);
        }

        /// <summary>
        ///     Destroys the platform windows
        /// </summary>
        public static void DestroyPlatformWindows()
        {
            ImGuiNative.igDestroyPlatformWindows();
        }

        /// <summary>
        ///     Docks the space using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The ret</returns>
        public static uint DockSpace(uint id)
        {
            Vector2F size = new Vector2F();
            ImGuiDockNodeFlags flags = 0;
            ImGuiWindowClass* windowClass = null;
            uint ret = ImGuiNative.igDockSpace(id, size, flags, windowClass);
            return ret;
        }

        /// <summary>
        ///     Docks the space using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <returns>The ret</returns>
        public static uint DockSpace(uint id, Vector2F size)
        {
            ImGuiDockNodeFlags flags = 0;
            ImGuiWindowClass* windowClass = null;
            uint ret = ImGuiNative.igDockSpace(id, size, flags, windowClass);
            return ret;
        }

        /// <summary>
        ///     Docks the space using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The ret</returns>
        public static uint DockSpace(uint id, Vector2F size, ImGuiDockNodeFlags flags)
        {
            ImGuiWindowClass* windowClass = null;
            uint ret = ImGuiNative.igDockSpace(id, size, flags, windowClass);
            return ret;
        }

        /// <summary>
        ///     Docks the space using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <param name="windowClass">The window class</param>
        /// <returns>The ret</returns>
        public static uint DockSpace(uint id, Vector2F size, ImGuiDockNodeFlags flags, ImGuiWindowClassPtr windowClass)
        {
            ImGuiWindowClass* nativeWindowClass = windowClass.NativePtr;
            uint ret = ImGuiNative.igDockSpace(id, size, flags, nativeWindowClass);
            return ret;
        }

        /// <summary>
        ///     Docks the space over viewport
        /// </summary>
        /// <returns>The ret</returns>
        public static uint DockSpaceOverViewport()
        {
            ImGuiViewport* viewport = null;
            ImGuiDockNodeFlags flags = 0;
            ImGuiWindowClass* windowClass = null;
            uint ret = ImGuiNative.igDockSpaceOverViewport(viewport, flags, windowClass);
            return ret;
        }

        /// <summary>
        ///     Docks the space over viewport using the specified viewport
        /// </summary>
        /// <param name="viewport">The viewport</param>
        /// <returns>The ret</returns>
        public static uint DockSpaceOverViewport(ImGuiViewportPtr viewport)
        {
            ImGuiViewport* nativeViewport = viewport.NativePtr;
            ImGuiDockNodeFlags flags = 0;
            ImGuiWindowClass* windowClass = null;
            uint ret = ImGuiNative.igDockSpaceOverViewport(nativeViewport, flags, windowClass);
            return ret;
        }

        /// <summary>
        ///     Docks the space over viewport using the specified viewport
        /// </summary>
        /// <param name="viewport">The viewport</param>
        /// <param name="flags">The flags</param>
        /// <returns>The ret</returns>
        public static uint DockSpaceOverViewport(ImGuiViewportPtr viewport, ImGuiDockNodeFlags flags)
        {
            ImGuiViewport* nativeViewport = viewport.NativePtr;
            ImGuiWindowClass* windowClass = null;
            uint ret = ImGuiNative.igDockSpaceOverViewport(nativeViewport, flags, windowClass);
            return ret;
        }

        /// <summary>
        ///     Docks the space over viewport using the specified viewport
        /// </summary>
        /// <param name="viewport">The viewport</param>
        /// <param name="flags">The flags</param>
        /// <param name="windowClass">The window class</param>
        /// <returns>The ret</returns>
        public static uint DockSpaceOverViewport(ImGuiViewportPtr viewport, ImGuiDockNodeFlags flags, ImGuiWindowClassPtr windowClass)
        {
            ImGuiViewport* nativeViewport = viewport.NativePtr;
            ImGuiWindowClass* nativeWindowClass = windowClass.NativePtr;
            uint ret = ImGuiNative.igDockSpaceOverViewport(nativeViewport, flags, nativeWindowClass);
            return ret;
        }

        /// <summary>
        ///     Describes whether drag float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool DragFloat(string label, ref float v)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            float vSpeed = 1.0f;
            float vMin = 0.0f;
            float vMax = 0.0f;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (float* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragFloat(string label, ref float v, float vSpeed)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            float vMin = 0.0f;
            float vMax = 0.0f;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (float* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragFloat(string label, ref float v, float vSpeed, float vMin)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            float vMax = 0.0f;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (float* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragFloat(string label, ref float v, float vSpeed, float vMin, float vMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (float* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragFloat(string label, ref float v, float vSpeed, float vMin, float vMax, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiSliderFlags flags = 0;
            fixed (float* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragFloat(string label, ref float v, float vSpeed, float vMin, float vMax, string format, ImGuiSliderFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            fixed (float* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool DragFloat2(string label, ref Vector2F v)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            float vSpeed = 1.0f;
            float vMin = 0.0f;
            float vMax = 0.0f;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (Vector2F* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat2(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragFloat2(string label, ref Vector2F v, float vSpeed)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            float vMin = 0.0f;
            float vMax = 0.0f;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (Vector2F* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat2(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragFloat2(string label, ref Vector2F v, float vSpeed, float vMin)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            float vMax = 0.0f;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (Vector2F* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat2(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragFloat2(string label, ref Vector2F v, float vSpeed, float vMin, float vMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (Vector2F* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat2(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragFloat2(string label, ref Vector2F v, float vSpeed, float vMin, float vMax, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiSliderFlags flags = 0;
            fixed (Vector2F* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat2(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragFloat2(string label, ref Vector2F v, float vSpeed, float vMin, float vMax, string format, ImGuiSliderFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            fixed (Vector2F* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat2(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool DragFloat3(string label, ref Vector3F v)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            float vSpeed = 1.0f;
            float vMin = 0.0f;
            float vMax = 0.0f;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (Vector3F* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat3(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragFloat3(string label, ref Vector3F v, float vSpeed)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            float vMin = 0.0f;
            float vMax = 0.0f;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (Vector3F* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat3(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragFloat3(string label, ref Vector3F v, float vSpeed, float vMin)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            float vMax = 0.0f;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (Vector3F* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat3(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragFloat3(string label, ref Vector3F v, float vSpeed, float vMin, float vMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (Vector3F* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat3(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragFloat3(string label, ref Vector3F v, float vSpeed, float vMin, float vMax, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiSliderFlags flags = 0;
            fixed (Vector3F* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat3(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragFloat3(string label, ref Vector3F v, float vSpeed, float vMin, float vMax, string format, ImGuiSliderFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            fixed (Vector3F* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat3(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool DragFloat4(string label, ref Vector4F v)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            float vSpeed = 1.0f;
            float vMin = 0.0f;
            float vMax = 0.0f;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (Vector4F* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat4(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragFloat4(string label, ref Vector4F v, float vSpeed)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            float vMin = 0.0f;
            float vMax = 0.0f;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (Vector4F* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat4(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragFloat4(string label, ref Vector4F v, float vSpeed, float vMin)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            float vMax = 0.0f;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (Vector4F* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat4(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragFloat4(string label, ref Vector4F v, float vSpeed, float vMin, float vMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (Vector4F* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat4(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragFloat4(string label, ref Vector4F v, float vSpeed, float vMin, float vMax, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiSliderFlags flags = 0;
            fixed (Vector4F* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat4(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragFloat4(string label, ref Vector4F v, float vSpeed, float vMin, float vMax, string format, ImGuiSliderFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            fixed (Vector4F* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat4(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag float range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <returns>The bool</returns>
        public static bool DragFloatRange2(string label, ref float vCurrentMin, ref float vCurrentMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            float vSpeed = 1.0f;
            float vMin = 0.0f;
            float vMax = 0.0f;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            byte* nativeFormatMax = null;
            ImGuiSliderFlags flags = 0;
            fixed (float* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (float* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragFloatRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
                    if (labelByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabel);
                    }

                    if (formatByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeFormat);
                    }

                    return ret != 0;
                }
            }
        }

        /// <summary>
        ///     Describes whether drag float range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragFloatRange2(string label, ref float vCurrentMin, ref float vCurrentMax, float vSpeed)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            float vMin = 0.0f;
            float vMax = 0.0f;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            byte* nativeFormatMax = null;
            ImGuiSliderFlags flags = 0;
            fixed (float* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (float* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragFloatRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
                    if (labelByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabel);
                    }

                    if (formatByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeFormat);
                    }

                    return ret != 0;
                }
            }
        }

        /// <summary>
        ///     Describes whether drag float range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragFloatRange2(string label, ref float vCurrentMin, ref float vCurrentMax, float vSpeed, float vMin)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            float vMax = 0.0f;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            byte* nativeFormatMax = null;
            ImGuiSliderFlags flags = 0;
            fixed (float* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (float* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragFloatRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
                    if (labelByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabel);
                    }

                    if (formatByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeFormat);
                    }

                    return ret != 0;
                }
            }
        }

        /// <summary>
        ///     Describes whether drag float range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragFloatRange2(string label, ref float vCurrentMin, ref float vCurrentMax, float vSpeed, float vMin, float vMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            byte* nativeFormatMax = null;
            ImGuiSliderFlags flags = 0;
            fixed (float* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (float* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragFloatRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
                    if (labelByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabel);
                    }

                    if (formatByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeFormat);
                    }

                    return ret != 0;
                }
            }
        }

        /// <summary>
        ///     Describes whether drag float range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragFloatRange2(string label, ref float vCurrentMin, ref float vCurrentMax, float vSpeed, float vMin, float vMax, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            byte* nativeFormatMax = null;
            ImGuiSliderFlags flags = 0;
            fixed (float* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (float* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragFloatRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
                    if (labelByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabel);
                    }

                    if (formatByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeFormat);
                    }

                    return ret != 0;
                }
            }
        }

        /// <summary>
        ///     Describes whether drag float range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="formatMax">The format max</param>
        /// <returns>The bool</returns>
        public static bool DragFloatRange2(string label, ref float vCurrentMin, ref float vCurrentMax, float vSpeed, float vMin, float vMax, string format, string formatMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            byte* nativeFormatMax;
            int formatMaxByteCount = 0;
            if (formatMax != null)
            {
                formatMaxByteCount = Encoding.UTF8.GetByteCount(formatMax);
                if (formatMaxByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormatMax = Util.Allocate(formatMaxByteCount + 1);
                }
                else
                {
                    byte* nativeFormatMaxStackBytes = stackalloc byte[formatMaxByteCount + 1];
                    nativeFormatMax = nativeFormatMaxStackBytes;
                }

                int nativeFormatMaxOffset = Util.GetUtf8(formatMax, nativeFormatMax, formatMaxByteCount);
                nativeFormatMax[nativeFormatMaxOffset] = 0;
            }
            else
            {
                nativeFormatMax = null;
            }

            ImGuiSliderFlags flags = 0;
            fixed (float* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (float* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragFloatRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
                    if (labelByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabel);
                    }

                    if (formatByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeFormat);
                    }

                    if (formatMaxByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeFormatMax);
                    }

                    return ret != 0;
                }
            }
        }

        /// <summary>
        ///     Describes whether drag float range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="formatMax">The format max</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragFloatRange2(string label, ref float vCurrentMin, ref float vCurrentMax, float vSpeed, float vMin, float vMax, string format, string formatMax, ImGuiSliderFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            byte* nativeFormatMax;
            int formatMaxByteCount = 0;
            if (formatMax != null)
            {
                formatMaxByteCount = Encoding.UTF8.GetByteCount(formatMax);
                if (formatMaxByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormatMax = Util.Allocate(formatMaxByteCount + 1);
                }
                else
                {
                    byte* nativeFormatMaxStackBytes = stackalloc byte[formatMaxByteCount + 1];
                    nativeFormatMax = nativeFormatMaxStackBytes;
                }

                int nativeFormatMaxOffset = Util.GetUtf8(formatMax, nativeFormatMax, formatMaxByteCount);
                nativeFormatMax[nativeFormatMaxOffset] = 0;
            }
            else
            {
                nativeFormatMax = null;
            }

            fixed (float* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (float* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragFloatRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
                    if (labelByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabel);
                    }

                    if (formatByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeFormat);
                    }

                    if (formatMaxByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeFormatMax);
                    }

                    return ret != 0;
                }
            }
        }

        /// <summary>
        ///     Describes whether drag int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool DragInt(string label, ref int v)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            float vSpeed = 1.0f;
            int vMin = 0;
            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragInt(string label, ref int v, float vSpeed)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            int vMin = 0;
            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragInt(string label, ref int v, float vSpeed, int vMin)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragInt(string label, ref int v, float vSpeed, int vMin, int vMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragInt(string label, ref int v, float vSpeed, int vMin, int vMax, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragInt(string label, ref int v, float vSpeed, int vMin, int vMax, string format, ImGuiSliderFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag int 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool DragInt2(string label, ref int v)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            float vSpeed = 1.0f;
            int vMin = 0;
            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt2(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag int 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragInt2(string label, ref int v, float vSpeed)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            int vMin = 0;
            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt2(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag int 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragInt2(string label, ref int v, float vSpeed, int vMin)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt2(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag int 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragInt2(string label, ref int v, float vSpeed, int vMin, int vMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt2(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag int 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragInt2(string label, ref int v, float vSpeed, int vMin, int vMax, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt2(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag int 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragInt2(string label, ref int v, float vSpeed, int vMin, int vMax, string format, ImGuiSliderFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt2(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag int 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool DragInt3(string label, ref int v)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            float vSpeed = 1.0f;
            int vMin = 0;
            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt3(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag int 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragInt3(string label, ref int v, float vSpeed)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            int vMin = 0;
            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt3(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag int 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragInt3(string label, ref int v, float vSpeed, int vMin)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt3(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag int 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragInt3(string label, ref int v, float vSpeed, int vMin, int vMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt3(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag int 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragInt3(string label, ref int v, float vSpeed, int vMin, int vMax, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt3(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag int 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragInt3(string label, ref int v, float vSpeed, int vMin, int vMax, string format, ImGuiSliderFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt3(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag int 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool DragInt4(string label, ref int v)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            float vSpeed = 1.0f;
            int vMin = 0;
            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt4(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag int 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragInt4(string label, ref int v, float vSpeed)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            int vMin = 0;
            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt4(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag int 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragInt4(string label, ref int v, float vSpeed, int vMin)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt4(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag int 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragInt4(string label, ref int v, float vSpeed, int vMin, int vMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt4(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag int 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragInt4(string label, ref int v, float vSpeed, int vMin, int vMax, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt4(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag int 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragInt4(string label, ref int v, float vSpeed, int vMin, int vMax, string format, ImGuiSliderFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt4(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether drag int range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <returns>The bool</returns>
        public static bool DragIntRange2(string label, ref int vCurrentMin, ref int vCurrentMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            float vSpeed = 1.0f;
            int vMin = 0;
            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            byte* nativeFormatMax = null;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (int* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragIntRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
                    if (labelByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabel);
                    }

                    if (formatByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeFormat);
                    }

                    return ret != 0;
                }
            }
        }

        /// <summary>
        ///     Describes whether drag int range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragIntRange2(string label, ref int vCurrentMin, ref int vCurrentMax, float vSpeed)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            int vMin = 0;
            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            byte* nativeFormatMax = null;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (int* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragIntRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
                    if (labelByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabel);
                    }

                    if (formatByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeFormat);
                    }

                    return ret != 0;
                }
            }
        }

        /// <summary>
        ///     Describes whether drag int range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragIntRange2(string label, ref int vCurrentMin, ref int vCurrentMax, float vSpeed, int vMin)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            byte* nativeFormatMax = null;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (int* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragIntRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
                    if (labelByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabel);
                    }

                    if (formatByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeFormat);
                    }

                    return ret != 0;
                }
            }
        }

        /// <summary>
        ///     Describes whether drag int range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragIntRange2(string label, ref int vCurrentMin, ref int vCurrentMax, float vSpeed, int vMin, int vMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            byte* nativeFormatMax = null;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (int* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragIntRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
                    if (labelByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabel);
                    }

                    if (formatByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeFormat);
                    }

                    return ret != 0;
                }
            }
        }

        /// <summary>
        ///     Describes whether drag int range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragIntRange2(string label, ref int vCurrentMin, ref int vCurrentMax, float vSpeed, int vMin, int vMax, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            byte* nativeFormatMax = null;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (int* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragIntRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
                    if (labelByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabel);
                    }

                    if (formatByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeFormat);
                    }

                    return ret != 0;
                }
            }
        }

        /// <summary>
        ///     Describes whether drag int range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="formatMax">The format max</param>
        /// <returns>The bool</returns>
        public static bool DragIntRange2(string label, ref int vCurrentMin, ref int vCurrentMax, float vSpeed, int vMin, int vMax, string format, string formatMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            byte* nativeFormatMax;
            int formatMaxByteCount = 0;
            if (formatMax != null)
            {
                formatMaxByteCount = Encoding.UTF8.GetByteCount(formatMax);
                if (formatMaxByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormatMax = Util.Allocate(formatMaxByteCount + 1);
                }
                else
                {
                    byte* nativeFormatMaxStackBytes = stackalloc byte[formatMaxByteCount + 1];
                    nativeFormatMax = nativeFormatMaxStackBytes;
                }

                int nativeFormatMaxOffset = Util.GetUtf8(formatMax, nativeFormatMax, formatMaxByteCount);
                nativeFormatMax[nativeFormatMaxOffset] = 0;
            }
            else
            {
                nativeFormatMax = null;
            }

            ImGuiSliderFlags flags = 0;
            fixed (int* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (int* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragIntRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
                    if (labelByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabel);
                    }

                    if (formatByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeFormat);
                    }

                    if (formatMaxByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeFormatMax);
                    }

                    return ret != 0;
                }
            }
        }

        /// <summary>
        ///     Describes whether drag int range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="formatMax">The format max</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragIntRange2(string label, ref int vCurrentMin, ref int vCurrentMax, float vSpeed, int vMin, int vMax, string format, string formatMax, ImGuiSliderFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            byte* nativeFormatMax;
            int formatMaxByteCount = 0;
            if (formatMax != null)
            {
                formatMaxByteCount = Encoding.UTF8.GetByteCount(formatMax);
                if (formatMaxByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormatMax = Util.Allocate(formatMaxByteCount + 1);
                }
                else
                {
                    byte* nativeFormatMaxStackBytes = stackalloc byte[formatMaxByteCount + 1];
                    nativeFormatMax = nativeFormatMaxStackBytes;
                }

                int nativeFormatMaxOffset = Util.GetUtf8(formatMax, nativeFormatMax, formatMaxByteCount);
                nativeFormatMax[nativeFormatMaxOffset] = 0;
            }
            else
            {
                nativeFormatMax = null;
            }

            fixed (int* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (int* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragIntRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
                    if (labelByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabel);
                    }

                    if (formatByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeFormat);
                    }

                    if (formatMaxByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeFormatMax);
                    }

                    return ret != 0;
                }
            }
        }

        /// <summary>
        ///     Describes whether drag scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <returns>The bool</returns>
        public static bool DragScalar(string label, ImGuiDataType dataType, IntPtr pData)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            float vSpeed = 1.0f;
            void* pMin = null;
            void* pMax = null;
            byte* nativeFormat = null;
            ImGuiSliderFlags flags = 0;
            byte ret = ImGuiNative.igDragScalar(nativeLabel, dataType, nativePData, vSpeed, pMin, pMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragScalar(string label, ImGuiDataType dataType, IntPtr pData, float vSpeed)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* pMin = null;
            void* pMax = null;
            byte* nativeFormat = null;
            ImGuiSliderFlags flags = 0;
            byte ret = ImGuiNative.igDragScalar(nativeLabel, dataType, nativePData, vSpeed, pMin, pMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="pMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragScalar(string label, ImGuiDataType dataType, IntPtr pData, float vSpeed, IntPtr pMin)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* nativePMin = pMin.ToPointer();
            void* pMax = null;
            byte* nativeFormat = null;
            ImGuiSliderFlags flags = 0;
            byte ret = ImGuiNative.igDragScalar(nativeLabel, dataType, nativePData, vSpeed, nativePMin, pMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragScalar(string label, ImGuiDataType dataType, IntPtr pData, float vSpeed, IntPtr pMin, IntPtr pMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* nativePMin = pMin.ToPointer();
            void* nativePMax = pMax.ToPointer();
            byte* nativeFormat = null;
            ImGuiSliderFlags flags = 0;
            byte ret = ImGuiNative.igDragScalar(nativeLabel, dataType, nativePData, vSpeed, nativePMin, nativePMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragScalar(string label, ImGuiDataType dataType, IntPtr pData, float vSpeed, IntPtr pMin, IntPtr pMax, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* nativePMin = pMin.ToPointer();
            void* nativePMax = pMax.ToPointer();
            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiSliderFlags flags = 0;
            byte ret = ImGuiNative.igDragScalar(nativeLabel, dataType, nativePData, vSpeed, nativePMin, nativePMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFormat);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragScalar(string label, ImGuiDataType dataType, IntPtr pData, float vSpeed, IntPtr pMin, IntPtr pMax, string format, ImGuiSliderFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* nativePMin = pMin.ToPointer();
            void* nativePMax = pMax.ToPointer();
            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            byte ret = ImGuiNative.igDragScalar(nativeLabel, dataType, nativePData, vSpeed, nativePMin, nativePMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFormat);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag scalar n
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="components">The components</param>
        /// <returns>The bool</returns>
        public static bool DragScalarN(string label, ImGuiDataType dataType, IntPtr pData, int components)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            float vSpeed = 1.0f;
            void* pMin = null;
            void* pMax = null;
            byte* nativeFormat = null;
            ImGuiSliderFlags flags = 0;
            byte ret = ImGuiNative.igDragScalarN(nativeLabel, dataType, nativePData, components, vSpeed, pMin, pMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag scalar n
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="components">The components</param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragScalarN(string label, ImGuiDataType dataType, IntPtr pData, int components, float vSpeed)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* pMin = null;
            void* pMax = null;
            byte* nativeFormat = null;
            ImGuiSliderFlags flags = 0;
            byte ret = ImGuiNative.igDragScalarN(nativeLabel, dataType, nativePData, components, vSpeed, pMin, pMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag scalar n
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="components">The components</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="pMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragScalarN(string label, ImGuiDataType dataType, IntPtr pData, int components, float vSpeed, IntPtr pMin)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* nativePMin = pMin.ToPointer();
            void* pMax = null;
            byte* nativeFormat = null;
            ImGuiSliderFlags flags = 0;
            byte ret = ImGuiNative.igDragScalarN(nativeLabel, dataType, nativePData, components, vSpeed, nativePMin, pMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag scalar n
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="components">The components</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragScalarN(string label, ImGuiDataType dataType, IntPtr pData, int components, float vSpeed, IntPtr pMin, IntPtr pMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* nativePMin = pMin.ToPointer();
            void* nativePMax = pMax.ToPointer();
            byte* nativeFormat = null;
            ImGuiSliderFlags flags = 0;
            byte ret = ImGuiNative.igDragScalarN(nativeLabel, dataType, nativePData, components, vSpeed, nativePMin, nativePMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag scalar n
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="components">The components</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragScalarN(string label, ImGuiDataType dataType, IntPtr pData, int components, float vSpeed, IntPtr pMin, IntPtr pMax, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* nativePMin = pMin.ToPointer();
            void* nativePMax = pMax.ToPointer();
            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiSliderFlags flags = 0;
            byte ret = ImGuiNative.igDragScalarN(nativeLabel, dataType, nativePData, components, vSpeed, nativePMin, nativePMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFormat);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag scalar n
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="components">The components</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragScalarN(string label, ImGuiDataType dataType, IntPtr pData, int components, float vSpeed, IntPtr pMin, IntPtr pMax, string format, ImGuiSliderFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* nativePMin = pMin.ToPointer();
            void* nativePMax = pMax.ToPointer();
            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            byte ret = ImGuiNative.igDragScalarN(nativeLabel, dataType, nativePData, components, vSpeed, nativePMin, nativePMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFormat);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Dummies the size
        /// </summary>
        /// <param name="size">The size</param>
        public static void Dummy(Vector2F size)
        {
            ImGuiNative.igDummy(size);
        }

        /// <summary>
        ///     Ends
        /// </summary>
        public static void End()
        {
            ImGuiNative.igEnd();
        }

        /// <summary>
        ///     Ends the child
        /// </summary>
        public static void EndChild()
        {
            ImGuiNative.igEndChild();
        }

        /// <summary>
        ///     Ends the child frame
        /// </summary>
        public static void EndChildFrame()
        {
            ImGuiNative.igEndChildFrame();
        }

        /// <summary>
        ///     Ends the combo
        /// </summary>
        public static void EndCombo()
        {
            ImGuiNative.igEndCombo();
        }

        /// <summary>
        ///     Ends the disabled
        /// </summary>
        public static void EndDisabled()
        {
            ImGuiNative.igEndDisabled();
        }

        /// <summary>
        ///     Ends the drag drop source
        /// </summary>
        public static void EndDragDropSource()
        {
            ImGuiNative.igEndDragDropSource();
        }

        /// <summary>
        ///     Ends the drag drop target
        /// </summary>
        public static void EndDragDropTarget()
        {
            ImGuiNative.igEndDragDropTarget();
        }

        /// <summary>
        ///     Ends the frame
        /// </summary>
        public static void EndFrame()
        {
            ImGuiNative.igEndFrame();
        }

        /// <summary>
        ///     Ends the group
        /// </summary>
        public static void EndGroup()
        {
            ImGuiNative.igEndGroup();
        }

        /// <summary>
        ///     Ends the list box
        /// </summary>
        public static void EndListBox()
        {
            ImGuiNative.igEndListBox();
        }

        /// <summary>
        ///     Ends the main menu bar
        /// </summary>
        public static void EndMainMenuBar()
        {
            ImGuiNative.igEndMainMenuBar();
        }

        /// <summary>
        ///     Ends the menu
        /// </summary>
        public static void EndMenu()
        {
            ImGuiNative.igEndMenu();
        }

        /// <summary>
        ///     Ends the menu bar
        /// </summary>
        public static void EndMenuBar()
        {
            ImGuiNative.igEndMenuBar();
        }

        /// <summary>
        ///     Ends the popup
        /// </summary>
        public static void EndPopup()
        {
            ImGuiNative.igEndPopup();
        }

        /// <summary>
        ///     Ends the tab bar
        /// </summary>
        public static void EndTabBar()
        {
            ImGuiNative.igEndTabBar();
        }

        /// <summary>
        ///     Ends the tab item
        /// </summary>
        public static void EndTabItem()
        {
            ImGuiNative.igEndTabItem();
        }

        /// <summary>
        ///     Ends the table
        /// </summary>
        public static void EndTable()
        {
            ImGuiNative.igEndTable();
        }

        /// <summary>
        ///     Ends the tooltip
        /// </summary>
        public static void EndTooltip()
        {
            ImGuiNative.igEndTooltip();
        }

        /// <summary>
        ///     Finds the viewport by id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The im gui viewport ptr</returns>
        public static ImGuiViewportPtr FindViewportById(uint id)
        {
            ImGuiViewport* ret = ImGuiNative.igFindViewportByID(id);
            return new ImGuiViewportPtr(ret);
        }

        /// <summary>
        ///     Finds the viewport by platform handle using the specified platform handle
        /// </summary>
        /// <param name="platformHandle">The platform handle</param>
        /// <returns>The im gui viewport ptr</returns>
        public static ImGuiViewportPtr FindViewportByPlatformHandle(IntPtr platformHandle)
        {
            void* nativePlatformHandle = platformHandle.ToPointer();
            ImGuiViewport* ret = ImGuiNative.igFindViewportByPlatformHandle(nativePlatformHandle);
            return new ImGuiViewportPtr(ret);
        }

        /// <summary>
        ///     Gets the allocator functions using the specified p alloc func
        /// </summary>
        /// <param name="pAllocFunc">The alloc func</param>
        /// <param name="pFreeFunc">The free func</param>
        /// <param name="pUserData">The user data</param>
        public static void GetAllocatorFunctions(ref IntPtr pAllocFunc, ref IntPtr pFreeFunc, ref void* pUserData)
        {
            fixed (IntPtr* nativePAllocFunc = &pAllocFunc)
            {
                fixed (IntPtr* nativePFreeFunc = &pFreeFunc)
                {
                    fixed (void** nativePUserData = &pUserData)
                    {
                        ImGuiNative.igGetAllocatorFunctions(nativePAllocFunc, nativePFreeFunc, nativePUserData);
                    }
                }
            }
        }

        /// <summary>
        ///     Gets the background draw list
        /// </summary>
        /// <returns>The im draw list ptr</returns>
        public static ImDrawListPtr GetBackgroundDrawList()
        {
            ImDrawList* ret = ImGuiNative.igGetBackgroundDrawList_Nil();
            return new ImDrawListPtr(ret);
        }

        /// <summary>
        ///     Gets the background draw list using the specified viewport
        /// </summary>
        /// <param name="viewport">The viewport</param>
        /// <returns>The im draw list ptr</returns>
        public static ImDrawListPtr GetBackgroundDrawList(ImGuiViewportPtr viewport)
        {
            ImGuiViewport* nativeViewport = viewport.NativePtr;
            ImDrawList* ret = ImGuiNative.igGetBackgroundDrawList_ViewportPtr(nativeViewport);
            return new ImDrawListPtr(ret);
        }

        /// <summary>
        ///     Gets the clipboard text
        /// </summary>
        /// <returns>The string</returns>
        public static string GetClipboardText()
        {
            byte* ret = ImGuiNative.igGetClipboardText();
            return Util.StringFromPtr(ret);
        }

        /// <summary>
        ///     Gets the color u 32 using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <returns>The ret</returns>
        public static uint GetColorU32(ImGuiCol idx)
        {
            float alphaMul = 1.0f;
            uint ret = ImGuiNative.igGetColorU32_Col(idx, alphaMul);
            return ret;
        }

        /// <summary>
        ///     Gets the color u 32 using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="alphaMul">The alpha mul</param>
        /// <returns>The ret</returns>
        public static uint GetColorU32(ImGuiCol idx, float alphaMul)
        {
            uint ret = ImGuiNative.igGetColorU32_Col(idx, alphaMul);
            return ret;
        }

        /// <summary>
        ///     Gets the color u 32 using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <returns>The ret</returns>
        public static uint GetColorU32(Vector4F col)
        {
            uint ret = ImGuiNative.igGetColorU32_Vec4(col);
            return ret;
        }

        /// <summary>
        ///     Gets the color u 32 using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <returns>The ret</returns>
        public static uint GetColorU32(uint col)
        {
            uint ret = ImGuiNative.igGetColorU32_U32(col);
            return ret;
        }

        /// <summary>
        ///     Gets the column index
        /// </summary>
        /// <returns>The ret</returns>
        public static int GetColumnIndex()
        {
            int ret = ImGuiNative.igGetColumnIndex();
            return ret;
        }

        /// <summary>
        ///     Gets the column offset
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetColumnOffset()
        {
            int columnIndex = -1;
            float ret = ImGuiNative.igGetColumnOffset(columnIndex);
            return ret;
        }

        /// <summary>
        ///     Gets the column offset using the specified column index
        /// </summary>
        /// <param name="columnIndex">The column index</param>
        /// <returns>The ret</returns>
        public static float GetColumnOffset(int columnIndex)
        {
            float ret = ImGuiNative.igGetColumnOffset(columnIndex);
            return ret;
        }

        /// <summary>
        ///     Gets the columns count
        /// </summary>
        /// <returns>The ret</returns>
        public static int GetColumnsCount()
        {
            int ret = ImGuiNative.igGetColumnsCount();
            return ret;
        }

        /// <summary>
        ///     Gets the column width
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetColumnWidth()
        {
            int columnIndex = -1;
            float ret = ImGuiNative.igGetColumnWidth(columnIndex);
            return ret;
        }

        /// <summary>
        ///     Gets the column width using the specified column index
        /// </summary>
        /// <param name="columnIndex">The column index</param>
        /// <returns>The ret</returns>
        public static float GetColumnWidth(int columnIndex)
        {
            float ret = ImGuiNative.igGetColumnWidth(columnIndex);
            return ret;
        }

        /// <summary>
        ///     Gets the content region avail
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2F GetContentRegionAvail()
        {
            Vector2F retval;
            ImGuiNative.igGetContentRegionAvail(&retval);
            return retval;
        }

        /// <summary>
        ///     Gets the content region max
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2F GetContentRegionMax()
        {
            Vector2F retval;
            ImGuiNative.igGetContentRegionMax(&retval);
            return retval;
        }

        /// <summary>
        ///     Gets the current context
        /// </summary>
        /// <returns>The ret</returns>
        public static IntPtr GetCurrentContext()
        {
            IntPtr ret = ImGuiNative.igGetCurrentContext();
            return ret;
        }

        /// <summary>
        ///     Gets the cursor pos
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2F GetCursorPos()
        {
            Vector2F retval;
            ImGuiNative.igGetCursorPos(&retval);
            return retval;
        }

        /// <summary>
        ///     Gets the cursor pos x
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetCursorPosX()
        {
            float ret = ImGuiNative.igGetCursorPosX();
            return ret;
        }

        /// <summary>
        ///     Gets the cursor pos y
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetCursorPosY()
        {
            float ret = ImGuiNative.igGetCursorPosY();
            return ret;
        }

        /// <summary>
        ///     Gets the cursor screen pos
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2F GetCursorScreenPos()
        {
            Vector2F retval;
            ImGuiNative.igGetCursorScreenPos(&retval);
            return retval;
        }

        /// <summary>
        ///     Gets the cursor start pos
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2F GetCursorStartPos()
        {
            Vector2F retval;
            ImGuiNative.igGetCursorStartPos(&retval);
            return retval;
        }

        /// <summary>
        ///     Gets the drag drop payload
        /// </summary>
        /// <returns>The im gui payload ptr</returns>
        public static ImGuiPayloadPtr GetDragDropPayload()
        {
            ImGuiPayload* ret = ImGuiNative.igGetDragDropPayload();
            return new ImGuiPayloadPtr(ret);
        }

        /// <summary>
        ///     Gets the draw data
        /// </summary>
        /// <returns>The im draw data ptr</returns>
        public static ImDrawDataPtr GetDrawData()
        {
            ImDrawData* ret = ImGuiNative.igGetDrawData();
            return new ImDrawDataPtr(ret);
        }

        /// <summary>
        ///     Gets the draw list shared data
        /// </summary>
        /// <returns>The ret</returns>
        public static IntPtr GetDrawListSharedData()
        {
            IntPtr ret = ImGuiNative.igGetDrawListSharedData();
            return ret;
        }

        /// <summary>
        ///     Gets the font
        /// </summary>
        /// <returns>The im font ptr</returns>
        public static ImFontPtr GetFont()
        {
            ImFont* ret = ImGuiNative.igGetFont();
            return new ImFontPtr(ret);
        }

        /// <summary>
        ///     Gets the font size
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetFontSize()
        {
            float ret = ImGuiNative.igGetFontSize();
            return ret;
        }

        /// <summary>
        ///     Gets the font tex uv white pixel
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2F GetFontTexUvWhitePixel()
        {
            Vector2F retval;
            ImGuiNative.igGetFontTexUvWhitePixel(&retval);
            return retval;
        }

        /// <summary>
        ///     Gets the foreground draw list
        /// </summary>
        /// <returns>The im draw list ptr</returns>
        public static ImDrawListPtr GetForegroundDrawList()
        {
            ImDrawList* ret = ImGuiNative.igGetForegroundDrawList_Nil();
            return new ImDrawListPtr(ret);
        }

        /// <summary>
        ///     Gets the foreground draw list using the specified viewport
        /// </summary>
        /// <param name="viewport">The viewport</param>
        /// <returns>The im draw list ptr</returns>
        public static ImDrawListPtr GetForegroundDrawList(ImGuiViewportPtr viewport)
        {
            ImGuiViewport* nativeViewport = viewport.NativePtr;
            ImDrawList* ret = ImGuiNative.igGetForegroundDrawList_ViewportPtr(nativeViewport);
            return new ImDrawListPtr(ret);
        }

        /// <summary>
        ///     Gets the frame count
        /// </summary>
        /// <returns>The ret</returns>
        public static int GetFrameCount()
        {
            int ret = ImGuiNative.igGetFrameCount();
            return ret;
        }

        /// <summary>
        ///     Gets the frame height
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetFrameHeight()
        {
            float ret = ImGuiNative.igGetFrameHeight();
            return ret;
        }

        /// <summary>
        ///     Gets the frame height with spacing
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetFrameHeightWithSpacing()
        {
            float ret = ImGuiNative.igGetFrameHeightWithSpacing();
            return ret;
        }

        /// <summary>
        ///     Gets the id using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <returns>The ret</returns>
        public static uint GetId(string strId)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            uint ret = ImGuiNative.igGetID_Str(nativeStrId);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            return ret;
        }

        /// <summary>
        ///     Gets the id using the specified ptr id
        /// </summary>
        /// <param name="ptrId">The ptr id</param>
        /// <returns>The ret</returns>
        public static uint GetId(IntPtr ptrId)
        {
            void* nativePtrId = ptrId.ToPointer();
            uint ret = ImGuiNative.igGetID_Ptr(nativePtrId);
            return ret;
        }

        /// <summary>
        ///     Gets the io
        /// </summary>
        /// <returns>The im gui io ptr</returns>
        public static ImGuiIoPtr GetIo()
        {
            ImGuiIo* ret = ImGuiNative.igGetIO();
            return new ImGuiIoPtr(ret);
        }

        /// <summary>
        ///     Gets the item id
        /// </summary>
        /// <returns>The ret</returns>
        public static uint GetItemId()
        {
            uint ret = ImGuiNative.igGetItemID();
            return ret;
        }

        /// <summary>
        ///     Gets the item rect max
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2F GetItemRectMax()
        {
            Vector2F retval;
            ImGuiNative.igGetItemRectMax(&retval);
            return retval;
        }

        /// <summary>
        ///     Gets the item rect min
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2F GetItemRectMin()
        {
            Vector2F retval;
            ImGuiNative.igGetItemRectMin(&retval);
            return retval;
        }

        /// <summary>
        ///     Gets the item rect size
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2F GetItemRectSize()
        {
            Vector2F retval;
            ImGuiNative.igGetItemRectSize(&retval);
            return retval;
        }

        /// <summary>
        ///     Gets the key index using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The ret</returns>
        public static ImGuiKey GetKeyIndex(ImGuiKey key)
        {
            ImGuiKey ret = ImGuiNative.igGetKeyIndex(key);
            return ret;
        }

        /// <summary>
        ///     Gets the key name using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The string</returns>
        public static string GetKeyName(ImGuiKey key)
        {
            byte* ret = ImGuiNative.igGetKeyName(key);
            return Util.StringFromPtr(ret);
        }

        /// <summary>
        ///     Gets the key pressed amount using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="repeatDelay">The repeat delay</param>
        /// <param name="rate">The rate</param>
        /// <returns>The ret</returns>
        public static int GetKeyPressedAmount(ImGuiKey key, float repeatDelay, float rate)
        {
            int ret = ImGuiNative.igGetKeyPressedAmount(key, repeatDelay, rate);
            return ret;
        }

        /// <summary>
        ///     Gets the main viewport
        /// </summary>
        /// <returns>The im gui viewport ptr</returns>
        public static ImGuiViewportPtr GetMainViewport()
        {
            ImGuiViewport* ret = ImGuiNative.igGetMainViewport();
            return new ImGuiViewportPtr(ret);
        }

        /// <summary>
        ///     Gets the mouse clicked count using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The ret</returns>
        public static int GetMouseClickedCount(ImGuiMouseButton button)
        {
            int ret = ImGuiNative.igGetMouseClickedCount(button);
            return ret;
        }

        /// <summary>
        ///     Gets the mouse cursor
        /// </summary>
        /// <returns>The ret</returns>
        public static ImGuiMouseCursor GetMouseCursor()
        {
            ImGuiMouseCursor ret = ImGuiNative.igGetMouseCursor();
            return ret;
        }

        /// <summary>
        ///     Gets the mouse drag delta
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2F GetMouseDragDelta()
        {
            Vector2F retval;
            ImGuiMouseButton button = 0;
            float lockThreshold = -1.0f;
            ImGuiNative.igGetMouseDragDelta(&retval, button, lockThreshold);
            return retval;
        }

        /// <summary>
        ///     Gets the mouse drag delta using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The retval</returns>
        public static Vector2F GetMouseDragDelta(ImGuiMouseButton button)
        {
            Vector2F retval;
            float lockThreshold = -1.0f;
            ImGuiNative.igGetMouseDragDelta(&retval, button, lockThreshold);
            return retval;
        }

        /// <summary>
        ///     Gets the mouse drag delta using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <param name="lockThreshold">The lock threshold</param>
        /// <returns>The retval</returns>
        public static Vector2F GetMouseDragDelta(ImGuiMouseButton button, float lockThreshold)
        {
            Vector2F retval;
            ImGuiNative.igGetMouseDragDelta(&retval, button, lockThreshold);
            return retval;
        }

        /// <summary>
        ///     Gets the mouse pos
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2F GetMousePos()
        {
            Vector2F retval;
            ImGuiNative.igGetMousePos(&retval);
            return retval;
        }

        /// <summary>
        ///     Gets the mouse pos on opening current popup
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2F GetMousePosOnOpeningCurrentPopup()
        {
            Vector2F retval;
            ImGuiNative.igGetMousePosOnOpeningCurrentPopup(&retval);
            return retval;
        }

        /// <summary>
        ///     Gets the platform io
        /// </summary>
        /// <returns>The im gui platform io ptr</returns>
        public static ImGuiPlatformIoPtr GetPlatformIo()
        {
            ImGuiPlatformIo* ret = ImGuiNative.igGetPlatformIO();
            return new ImGuiPlatformIoPtr(ret);
        }

        /// <summary>
        ///     Gets the scroll max x
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetScrollMaxX()
        {
            float ret = ImGuiNative.igGetScrollMaxX();
            return ret;
        }

        /// <summary>
        ///     Gets the scroll max y
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetScrollMaxY()
        {
            float ret = ImGuiNative.igGetScrollMaxY();
            return ret;
        }

        /// <summary>
        ///     Gets the scroll x
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetScrollX()
        {
            float ret = ImGuiNative.igGetScrollX();
            return ret;
        }

        /// <summary>
        ///     Gets the scroll y
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetScrollY()
        {
            float ret = ImGuiNative.igGetScrollY();
            return ret;
        }

        /// <summary>
        ///     Gets the state storage
        /// </summary>
        /// <returns>The im gui storage ptr</returns>
        public static ImGuiStoragePtr GetStateStorage()
        {
            ImGuiStorage* ret = ImGuiNative.igGetStateStorage();
            return new ImGuiStoragePtr(ret);
        }

        /// <summary>
        ///     Gets the style
        /// </summary>
        /// <returns>The im gui style ptr</returns>
        public static ImGuiStylePtr GetStyle()
        {
            ImGuiStyle* ret = ImGuiNative.igGetStyle();
            return new ImGuiStylePtr(ret);
        }

        /// <summary>
        ///     Gets the style color name using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <returns>The string</returns>
        public static string GetStyleColorName(ImGuiCol idx)
        {
            byte* ret = ImGuiNative.igGetStyleColorName(idx);
            return Util.StringFromPtr(ret);
        }

        /// <summary>
        ///     Gets the style color vec 4 using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <returns>The ret</returns>
        public static Vector4F* GetStyleColorVec4(ImGuiCol idx)
        {
            Vector4F* ret = ImGuiNative.igGetStyleColorVec4(idx);
            return ret;
        }

        /// <summary>
        ///     Gets the text line height
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetTextLineHeight()
        {
            float ret = ImGuiNative.igGetTextLineHeight();
            return ret;
        }

        /// <summary>
        ///     Gets the text line height with spacing
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetTextLineHeightWithSpacing()
        {
            float ret = ImGuiNative.igGetTextLineHeightWithSpacing();
            return ret;
        }

        /// <summary>
        ///     Gets the time
        /// </summary>
        /// <returns>The ret</returns>
        public static double GetTime()
        {
            double ret = ImGuiNative.igGetTime();
            return ret;
        }

        /// <summary>
        ///     Gets the tree node to label spacing
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetTreeNodeToLabelSpacing()
        {
            float ret = ImGuiNative.igGetTreeNodeToLabelSpacing();
            return ret;
        }

        /// <summary>
        ///     Gets the version
        /// </summary>
        /// <returns>The string</returns>
        public static string GetVersion()
        {
            byte* ret = ImGuiNative.igGetVersion();
            return Util.StringFromPtr(ret);
        }

        /// <summary>
        ///     Gets the window content region max
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2F GetWindowContentRegionMax()
        {
            Vector2F retval;
            ImGuiNative.igGetWindowContentRegionMax(&retval);
            return retval;
        }

        /// <summary>
        ///     Gets the window content region min
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2F GetWindowContentRegionMin()
        {
            Vector2F retval;
            ImGuiNative.igGetWindowContentRegionMin(&retval);
            return retval;
        }

        /// <summary>
        ///     Gets the window dock id
        /// </summary>
        /// <returns>The ret</returns>
        public static uint GetWindowDockId()
        {
            uint ret = ImGuiNative.igGetWindowDockID();
            return ret;
        }

        /// <summary>
        ///     Gets the window dpi scale
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetWindowDpiScale()
        {
            float ret = ImGuiNative.igGetWindowDpiScale();
            return ret;
        }

        /// <summary>
        ///     Gets the window draw list
        /// </summary>
        /// <returns>The im draw list ptr</returns>
        public static ImDrawListPtr GetWindowDrawList()
        {
            ImDrawList* ret = ImGuiNative.igGetWindowDrawList();
            return new ImDrawListPtr(ret);
        }

        /// <summary>
        ///     Gets the window height
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetWindowHeight()
        {
            float ret = ImGuiNative.igGetWindowHeight();
            return ret;
        }

        /// <summary>
        ///     Gets the window pos
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2F GetWindowPos()
        {
            Vector2F retval;
            ImGuiNative.igGetWindowPos(&retval);
            return retval;
        }

        /// <summary>
        ///     Gets the window size
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2F GetWindowSize()
        {
            Vector2F retval;
            ImGuiNative.igGetWindowSize(&retval);
            return retval;
        }

        /// <summary>
        ///     Gets the window viewport
        /// </summary>
        /// <returns>The im gui viewport ptr</returns>
        public static ImGuiViewportPtr GetWindowViewport()
        {
            ImGuiViewport* ret = ImGuiNative.igGetWindowViewport();
            return new ImGuiViewportPtr(ret);
        }

        /// <summary>
        ///     Gets the window width
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetWindowWidth()
        {
            float ret = ImGuiNative.igGetWindowWidth();
            return ret;
        }

        /// <summary>
        ///     Images the user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="size">The size</param>
        public static void Image(IntPtr userTextureId, Vector2F size)
        {
            Vector2F uv0 = new Vector2F();
            Vector2F uv1 = new Vector2F(1, 1);
            Vector4F tintCol = new Vector4F(1, 1, 1, 1);
            Vector4F borderCol = new Vector4F();
            ImGuiNative.igImage(userTextureId, size, uv0, uv1, tintCol, borderCol);
        }

        /// <summary>
        ///     Images the user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="size">The size</param>
        /// <param name="uv0">The uv</param>
        public static void Image(IntPtr userTextureId, Vector2F size, Vector2F uv0)
        {
            Vector2F uv1 = new Vector2F(1, 1);
            Vector4F tintCol = new Vector4F(1, 1, 1, 1);
            Vector4F borderCol = new Vector4F();
            ImGuiNative.igImage(userTextureId, size, uv0, uv1, tintCol, borderCol);
        }

        /// <summary>
        ///     Images the user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="size">The size</param>
        /// <param name="uv0">The uv</param>
        /// <param name="uv1">The uv</param>
        public static void Image(IntPtr userTextureId, Vector2F size, Vector2F uv0, Vector2F uv1)
        {
            Vector4F tintCol = new Vector4F(1, 1, 1, 1);
            Vector4F borderCol = new Vector4F();
            ImGuiNative.igImage(userTextureId, size, uv0, uv1, tintCol, borderCol);
        }

        /// <summary>
        ///     Images the user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="size">The size</param>
        /// <param name="uv0">The uv</param>
        /// <param name="uv1">The uv</param>
        /// <param name="tintCol">The tint col</param>
        public static void Image(IntPtr userTextureId, Vector2F size, Vector2F uv0, Vector2F uv1, Vector4F tintCol)
        {
            Vector4F borderCol = new Vector4F();
            ImGuiNative.igImage(userTextureId, size, uv0, uv1, tintCol, borderCol);
        }

        /// <summary>
        ///     Images the user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="size">The size</param>
        /// <param name="uv0">The uv</param>
        /// <param name="uv1">The uv</param>
        /// <param name="tintCol">The tint col</param>
        /// <param name="borderCol">The border col</param>
        public static void Image(IntPtr userTextureId, Vector2F size, Vector2F uv0, Vector2F uv1, Vector4F tintCol, Vector4F borderCol)
        {
            ImGuiNative.igImage(userTextureId, size, uv0, uv1, tintCol, borderCol);
        }

        /// <summary>
        ///     Describes whether image button
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool ImageButton(string strId, IntPtr userTextureId, Vector2F size)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            Vector2F uv0 = new Vector2F();
            Vector2F uv1 = new Vector2F(1, 1);
            Vector4F bgCol = new Vector4F();
            Vector4F tintCol = new Vector4F(1, 1, 1, 1);
            byte ret = ImGuiNative.igImageButton(nativeStrId, userTextureId, size, uv0, uv1, bgCol, tintCol);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether image button
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="size">The size</param>
        /// <param name="uv0">The uv</param>
        /// <returns>The bool</returns>
        public static bool ImageButton(string strId, IntPtr userTextureId, Vector2F size, Vector2F uv0)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            Vector2F uv1 = new Vector2F(1, 1);
            Vector4F bgCol = new Vector4F();
            Vector4F tintCol = new Vector4F(1, 1, 1, 1);
            byte ret = ImGuiNative.igImageButton(nativeStrId, userTextureId, size, uv0, uv1, bgCol, tintCol);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether image button
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="size">The size</param>
        /// <param name="uv0">The uv</param>
        /// <param name="uv1">The uv</param>
        /// <returns>The bool</returns>
        public static bool ImageButton(string strId, IntPtr userTextureId, Vector2F size, Vector2F uv0, Vector2F uv1)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            Vector4F bgCol = new Vector4F();
            Vector4F tintCol = new Vector4F(1, 1, 1, 1);
            byte ret = ImGuiNative.igImageButton(nativeStrId, userTextureId, size, uv0, uv1, bgCol, tintCol);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether image button
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="size">The size</param>
        /// <param name="uv0">The uv</param>
        /// <param name="uv1">The uv</param>
        /// <param name="bgCol">The bg col</param>
        /// <returns>The bool</returns>
        public static bool ImageButton(string strId, IntPtr userTextureId, Vector2F size, Vector2F uv0, Vector2F uv1, Vector4F bgCol)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            Vector4F tintCol = new Vector4F(1, 1, 1, 1);
            byte ret = ImGuiNative.igImageButton(nativeStrId, userTextureId, size, uv0, uv1, bgCol, tintCol);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether image button
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="size">The size</param>
        /// <param name="uv0">The uv</param>
        /// <param name="uv1">The uv</param>
        /// <param name="bgCol">The bg col</param>
        /// <param name="tintCol">The tint col</param>
        /// <returns>The bool</returns>
        public static bool ImageButton(string strId, IntPtr userTextureId, Vector2F size, Vector2F uv0, Vector2F uv1, Vector4F bgCol, Vector4F tintCol)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            byte ret = ImGuiNative.igImageButton(nativeStrId, userTextureId, size, uv0, uv1, bgCol, tintCol);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Indents
        /// </summary>
        public static void Indent()
        {
            float indentW = 0.0f;
            ImGuiNative.igIndent(indentW);
        }

        /// <summary>
        ///     Indents the indent w
        /// </summary>
        /// <param name="indentW">The indent</param>
        public static void Indent(float indentW)
        {
            ImGuiNative.igIndent(indentW);
        }

        /// <summary>
        ///     Describes whether input double
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool InputDouble(string label, ref double v)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            double step = 0.0;
            double stepFast = 0.0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.6f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.6f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiInputTextFlags flags = 0;
            fixed (double* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputDouble(nativeLabel, nativeV, step, stepFast, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether input double
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <returns>The bool</returns>
        public static bool InputDouble(string label, ref double v, double step)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            double stepFast = 0.0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.6f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.6f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiInputTextFlags flags = 0;
            fixed (double* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputDouble(nativeLabel, nativeV, step, stepFast, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether input double
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <param name="stepFast">The step fast</param>
        /// <returns>The bool</returns>
        public static bool InputDouble(string label, ref double v, double step, double stepFast)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.6f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.6f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiInputTextFlags flags = 0;
            fixed (double* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputDouble(nativeLabel, nativeV, step, stepFast, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether input double
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <param name="stepFast">The step fast</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool InputDouble(string label, ref double v, double step, double stepFast, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiInputTextFlags flags = 0;
            fixed (double* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputDouble(nativeLabel, nativeV, step, stepFast, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether input double
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <param name="stepFast">The step fast</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputDouble(string label, ref double v, double step, double stepFast, string format, ImGuiInputTextFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            fixed (double* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputDouble(nativeLabel, nativeV, step, stepFast, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether input float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool InputFloat(string label, ref float v)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            float step = 0.0f;
            float stepFast = 0.0f;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiInputTextFlags flags = 0;
            fixed (float* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputFloat(nativeLabel, nativeV, step, stepFast, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether input float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <returns>The bool</returns>
        public static bool InputFloat(string label, ref float v, float step)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            float stepFast = 0.0f;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiInputTextFlags flags = 0;
            fixed (float* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputFloat(nativeLabel, nativeV, step, stepFast, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether input float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <param name="stepFast">The step fast</param>
        /// <returns>The bool</returns>
        public static bool InputFloat(string label, ref float v, float step, float stepFast)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiInputTextFlags flags = 0;
            fixed (float* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputFloat(nativeLabel, nativeV, step, stepFast, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether input float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <param name="stepFast">The step fast</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool InputFloat(string label, ref float v, float step, float stepFast, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiInputTextFlags flags = 0;
            fixed (float* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputFloat(nativeLabel, nativeV, step, stepFast, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether input float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <param name="stepFast">The step fast</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputFloat(string label, ref float v, float step, float stepFast, string format, ImGuiInputTextFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            fixed (float* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputFloat(nativeLabel, nativeV, step, stepFast, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether input float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool InputFloat2(string label, ref Vector2F v)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiInputTextFlags flags = 0;
            fixed (Vector2F* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputFloat2(nativeLabel, nativeV, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether input float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool InputFloat2(string label, ref Vector2F v, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiInputTextFlags flags = 0;
            fixed (Vector2F* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputFloat2(nativeLabel, nativeV, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether input float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputFloat2(string label, ref Vector2F v, string format, ImGuiInputTextFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            fixed (Vector2F* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputFloat2(nativeLabel, nativeV, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether input float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool InputFloat3(string label, ref Vector3F v)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiInputTextFlags flags = 0;
            fixed (Vector3F* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputFloat3(nativeLabel, nativeV, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether input float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool InputFloat3(string label, ref Vector3F v, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiInputTextFlags flags = 0;
            fixed (Vector3F* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputFloat3(nativeLabel, nativeV, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether input float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputFloat3(string label, ref Vector3F v, string format, ImGuiInputTextFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            fixed (Vector3F* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputFloat3(nativeLabel, nativeV, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether input float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool InputFloat4(string label, ref Vector4F v)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiInputTextFlags flags = 0;
            fixed (Vector4F* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputFloat4(nativeLabel, nativeV, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether input float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool InputFloat4(string label, ref Vector4F v, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiInputTextFlags flags = 0;
            fixed (Vector4F* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputFloat4(nativeLabel, nativeV, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether input float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputFloat4(string label, ref Vector4F v, string format, ImGuiInputTextFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            fixed (Vector4F* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputFloat4(nativeLabel, nativeV, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether input int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool InputInt(string label, ref int v)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            int step = 1;
            int stepFast = 100;
            ImGuiInputTextFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputInt(nativeLabel, nativeV, step, stepFast, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            int stepFast = 100;
            ImGuiInputTextFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputInt(nativeLabel, nativeV, step, stepFast, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            ImGuiInputTextFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputInt(nativeLabel, nativeV, step, stepFast, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputInt(nativeLabel, nativeV, step, stepFast, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether input int 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool InputInt2(string label, ref int v)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            ImGuiInputTextFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputInt2(nativeLabel, nativeV, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputInt2(nativeLabel, nativeV, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether input int 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool InputInt3(string label, ref int v)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            ImGuiInputTextFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputInt3(nativeLabel, nativeV, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputInt3(nativeLabel, nativeV, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether input int 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool InputInt4(string label, ref int v)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            ImGuiInputTextFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputInt4(nativeLabel, nativeV, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igInputInt4(nativeLabel, nativeV, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* pStep = null;
            void* pStepFast = null;
            byte* nativeFormat = null;
            ImGuiInputTextFlags flags = 0;
            byte ret = ImGuiNative.igInputScalar(nativeLabel, dataType, nativePData, pStep, pStepFast, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* nativePStep = pStep.ToPointer();
            void* pStepFast = null;
            byte* nativeFormat = null;
            ImGuiInputTextFlags flags = 0;
            byte ret = ImGuiNative.igInputScalar(nativeLabel, dataType, nativePData, nativePStep, pStepFast, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* nativePStep = pStep.ToPointer();
            void* nativePStepFast = pStepFast.ToPointer();
            byte* nativeFormat = null;
            ImGuiInputTextFlags flags = 0;
            byte ret = ImGuiNative.igInputScalar(nativeLabel, dataType, nativePData, nativePStep, nativePStepFast, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* nativePStep = pStep.ToPointer();
            void* nativePStepFast = pStepFast.ToPointer();
            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiInputTextFlags flags = 0;
            byte ret = ImGuiNative.igInputScalar(nativeLabel, dataType, nativePData, nativePStep, nativePStepFast, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFormat);
            }

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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* nativePStep = pStep.ToPointer();
            void* nativePStepFast = pStepFast.ToPointer();
            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            byte ret = ImGuiNative.igInputScalar(nativeLabel, dataType, nativePData, nativePStep, nativePStepFast, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFormat);
            }

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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* pStep = null;
            void* pStepFast = null;
            byte* nativeFormat = null;
            ImGuiInputTextFlags flags = 0;
            byte ret = ImGuiNative.igInputScalarN(nativeLabel, dataType, nativePData, components, pStep, pStepFast, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* nativePStep = pStep.ToPointer();
            void* pStepFast = null;
            byte* nativeFormat = null;
            ImGuiInputTextFlags flags = 0;
            byte ret = ImGuiNative.igInputScalarN(nativeLabel, dataType, nativePData, components, nativePStep, pStepFast, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* nativePStep = pStep.ToPointer();
            void* nativePStepFast = pStepFast.ToPointer();
            byte* nativeFormat = null;
            ImGuiInputTextFlags flags = 0;
            byte ret = ImGuiNative.igInputScalarN(nativeLabel, dataType, nativePData, components, nativePStep, nativePStepFast, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* nativePStep = pStep.ToPointer();
            void* nativePStepFast = pStepFast.ToPointer();
            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiInputTextFlags flags = 0;
            byte ret = ImGuiNative.igInputScalarN(nativeLabel, dataType, nativePData, components, nativePStep, nativePStepFast, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFormat);
            }

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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* nativePStep = pStep.ToPointer();
            void* nativePStepFast = pStepFast.ToPointer();
            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            byte ret = ImGuiNative.igInputScalarN(nativeLabel, dataType, nativePData, components, nativePStep, nativePStepFast, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFormat);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether invisible button
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool InvisibleButton(string strId, Vector2F size)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            ImGuiButtonFlags flags = 0;
            byte ret = ImGuiNative.igInvisibleButton(nativeStrId, size, flags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether invisible button
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InvisibleButton(string strId, Vector2F size, ImGuiButtonFlags flags)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            byte ret = ImGuiNative.igInvisibleButton(nativeStrId, size, flags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

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
        public static bool IsMouseHoveringRect(Vector2F rMin, Vector2F rMax)
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
        public static bool IsMouseHoveringRect(Vector2F rMin, Vector2F rMax, bool clip)
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
            Vector2F* mousePos = null;
            byte ret = ImGuiNative.igIsMousePosValid(mousePos);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether is mouse pos valid
        /// </summary>
        /// <param name="mousePos">The mouse pos</param>
        /// <returns>The bool</returns>
        public static bool IsMousePosValid(ref Vector2F mousePos)
        {
            fixed (Vector2F* nativeMousePos = &mousePos)
            {
                byte ret = ImGuiNative.igIsMousePosValid(nativeMousePos);
                return ret != 0;
            }
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
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            ImGuiPopupFlags flags = 0;
            byte ret = ImGuiNative.igIsPopupOpen_Str(nativeStrId, flags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

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
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            byte ret = ImGuiNative.igIsPopupOpen_Str(nativeStrId, flags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether is rect visible
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool IsRectVisible(Vector2F size)
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
        public static bool IsRectVisible(Vector2F rectMin, Vector2F rectMax)
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFmt;
            int fmtByteCount = 0;
            if (fmt != null)
            {
                fmtByteCount = Encoding.UTF8.GetByteCount(fmt);
                if (fmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFmt = Util.Allocate(fmtByteCount + 1);
                }
                else
                {
                    byte* nativeFmtStackBytes = stackalloc byte[fmtByteCount + 1];
                    nativeFmt = nativeFmtStackBytes;
                }

                int nativeFmtOffset = Util.GetUtf8(fmt, nativeFmt, fmtByteCount);
                nativeFmt[nativeFmtOffset] = 0;
            }
            else
            {
                nativeFmt = null;
            }

            ImGuiNative.igLabelText(nativeLabel, nativeFmt);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            if (fmtByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFmt);
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            int* itemsByteCounts = stackalloc int[items.Length];
            int itemsByteCount = 0;
            for (int i = 0; i < items.Length; i++)
            {
                string s = items[i];
                itemsByteCounts[i] = Encoding.UTF8.GetByteCount(s);
                itemsByteCount += itemsByteCounts[i] + 1;
            }

            byte* nativeItemsData = stackalloc byte[itemsByteCount];
            int offset = 0;
            for (int i = 0; i < items.Length; i++)
            {
                string s = items[i];
                fixed (char* sPtr = s)
                {
                    offset += Encoding.UTF8.GetBytes(sPtr, s.Length, nativeItemsData + offset, itemsByteCounts[i]);
                    nativeItemsData[offset] = 0;
                    offset += 1;
                }
            }

            byte** nativeItems = stackalloc byte*[items.Length];
            offset = 0;
            for (int i = 0; i < items.Length; i++)
            {
                nativeItems[i] = &nativeItemsData[offset];
                offset += itemsByteCounts[i] + 1;
            }

            int heightInItems = -1;
            fixed (int* nativeCurrentItem = &currentItem)
            {
                byte ret = ImGuiNative.igListBox_Str_arr(nativeLabel, nativeCurrentItem, nativeItems, itemsCount, heightInItems);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            int* itemsByteCounts = stackalloc int[items.Length];
            int itemsByteCount = 0;
            for (int i = 0; i < items.Length; i++)
            {
                string s = items[i];
                itemsByteCounts[i] = Encoding.UTF8.GetByteCount(s);
                itemsByteCount += itemsByteCounts[i] + 1;
            }

            byte* nativeItemsData = stackalloc byte[itemsByteCount];
            int offset = 0;
            for (int i = 0; i < items.Length; i++)
            {
                string s = items[i];
                fixed (char* sPtr = s)
                {
                    offset += Encoding.UTF8.GetBytes(sPtr, s.Length, nativeItemsData + offset, itemsByteCounts[i]);
                    nativeItemsData[offset] = 0;
                    offset += 1;
                }
            }

            byte** nativeItems = stackalloc byte*[items.Length];
            offset = 0;
            for (int i = 0; i < items.Length; i++)
            {
                nativeItems[i] = &nativeItemsData[offset];
                offset += itemsByteCounts[i] + 1;
            }

            fixed (int* nativeCurrentItem = &currentItem)
            {
                byte ret = ImGuiNative.igListBox_Str_arr(nativeLabel, nativeCurrentItem, nativeItems, itemsCount, heightInItems);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Loads the ini settings from disk using the specified ini filename
        /// </summary>
        /// <param name="iniFilename">The ini filename</param>
        public static void LoadIniSettingsFromDisk(string iniFilename)
        {
            byte* nativeIniFilename;
            int iniFilenameByteCount = 0;
            if (iniFilename != null)
            {
                iniFilenameByteCount = Encoding.UTF8.GetByteCount(iniFilename);
                if (iniFilenameByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeIniFilename = Util.Allocate(iniFilenameByteCount + 1);
                }
                else
                {
                    byte* nativeIniFilenameStackBytes = stackalloc byte[iniFilenameByteCount + 1];
                    nativeIniFilename = nativeIniFilenameStackBytes;
                }

                int nativeIniFilenameOffset = Util.GetUtf8(iniFilename, nativeIniFilename, iniFilenameByteCount);
                nativeIniFilename[nativeIniFilenameOffset] = 0;
            }
            else
            {
                nativeIniFilename = null;
            }

            ImGuiNative.igLoadIniSettingsFromDisk(nativeIniFilename);
            if (iniFilenameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeIniFilename);
            }
        }

        /// <summary>
        ///     Loads the ini settings from memory using the specified ini data
        /// </summary>
        /// <param name="iniData">The ini data</param>
        public static void LoadIniSettingsFromMemory(string iniData)
        {
            byte* nativeIniData;
            int iniDataByteCount = 0;
            if (iniData != null)
            {
                iniDataByteCount = Encoding.UTF8.GetByteCount(iniData);
                if (iniDataByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeIniData = Util.Allocate(iniDataByteCount + 1);
                }
                else
                {
                    byte* nativeIniDataStackBytes = stackalloc byte[iniDataByteCount + 1];
                    nativeIniData = nativeIniDataStackBytes;
                }

                int nativeIniDataOffset = Util.GetUtf8(iniData, nativeIniData, iniDataByteCount);
                nativeIniData[nativeIniDataOffset] = 0;
            }
            else
            {
                nativeIniData = null;
            }

            uint iniSize = 0;
            ImGuiNative.igLoadIniSettingsFromMemory(nativeIniData, iniSize);
            if (iniDataByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeIniData);
            }
        }

        /// <summary>
        ///     Loads the ini settings from memory using the specified ini data
        /// </summary>
        /// <param name="iniData">The ini data</param>
        /// <param name="iniSize">The ini size</param>
        public static void LoadIniSettingsFromMemory(string iniData, uint iniSize)
        {
            byte* nativeIniData;
            int iniDataByteCount = 0;
            if (iniData != null)
            {
                iniDataByteCount = Encoding.UTF8.GetByteCount(iniData);
                if (iniDataByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeIniData = Util.Allocate(iniDataByteCount + 1);
                }
                else
                {
                    byte* nativeIniDataStackBytes = stackalloc byte[iniDataByteCount + 1];
                    nativeIniData = nativeIniDataStackBytes;
                }

                int nativeIniDataOffset = Util.GetUtf8(iniData, nativeIniData, iniDataByteCount);
                nativeIniData[nativeIniDataOffset] = 0;
            }
            else
            {
                nativeIniData = null;
            }

            ImGuiNative.igLoadIniSettingsFromMemory(nativeIniData, iniSize);
            if (iniDataByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeIniData);
            }
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
            byte* nativeFmt;
            int fmtByteCount = 0;
            if (fmt != null)
            {
                fmtByteCount = Encoding.UTF8.GetByteCount(fmt);
                if (fmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFmt = Util.Allocate(fmtByteCount + 1);
                }
                else
                {
                    byte* nativeFmtStackBytes = stackalloc byte[fmtByteCount + 1];
                    nativeFmt = nativeFmtStackBytes;
                }

                int nativeFmtOffset = Util.GetUtf8(fmt, nativeFmt, fmtByteCount);
                nativeFmt[nativeFmtOffset] = 0;
            }
            else
            {
                nativeFmt = null;
            }

            ImGuiNative.igLogText(nativeFmt);
            if (fmtByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFmt);
            }
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
            int autoOpenDepth = -1;
            byte* nativeFilename = null;
            ImGuiNative.igLogToFile(autoOpenDepth, nativeFilename);
        }

        /// <summary>
        ///     Logs the to file using the specified auto open depth
        /// </summary>
        /// <param name="autoOpenDepth">The auto open depth</param>
        public static void LogToFile(int autoOpenDepth)
        {
            byte* nativeFilename = null;
            ImGuiNative.igLogToFile(autoOpenDepth, nativeFilename);
        }

        /// <summary>
        ///     Logs the to file using the specified auto open depth
        /// </summary>
        /// <param name="autoOpenDepth">The auto open depth</param>
        /// <param name="filename">The filename</param>
        public static void LogToFile(int autoOpenDepth, string filename)
        {
            byte* nativeFilename;
            int filenameByteCount = 0;
            if (filename != null)
            {
                filenameByteCount = Encoding.UTF8.GetByteCount(filename);
                if (filenameByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFilename = Util.Allocate(filenameByteCount + 1);
                }
                else
                {
                    byte* nativeFilenameStackBytes = stackalloc byte[filenameByteCount + 1];
                    nativeFilename = nativeFilenameStackBytes;
                }

                int nativeFilenameOffset = Util.GetUtf8(filename, nativeFilename, filenameByteCount);
                nativeFilename[nativeFilenameOffset] = 0;
            }
            else
            {
                nativeFilename = null;
            }

            ImGuiNative.igLogToFile(autoOpenDepth, nativeFilename);
            if (filenameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFilename);
            }
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
            void* ret = ImGuiNative.igMemAlloc(size);
            return (IntPtr) ret;
        }

        /// <summary>
        ///     Mems the free using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public static void MemFree(IntPtr ptr)
        {
            void* nativePtr = ptr.ToPointer();
            ImGuiNative.igMemFree(nativePtr);
        }

        /// <summary>
        ///     Describes whether menu item
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool MenuItem(string label)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeShortcut = null;
            byte selected = 0;
            byte enabled = 1;
            byte ret = ImGuiNative.igMenuItem_Bool(nativeLabel, nativeShortcut, selected, enabled);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeShortcut;
            int shortcutByteCount = 0;
            if (shortcut != null)
            {
                shortcutByteCount = Encoding.UTF8.GetByteCount(shortcut);
                if (shortcutByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeShortcut = Util.Allocate(shortcutByteCount + 1);
                }
                else
                {
                    byte* nativeShortcutStackBytes = stackalloc byte[shortcutByteCount + 1];
                    nativeShortcut = nativeShortcutStackBytes;
                }

                int nativeShortcutOffset = Util.GetUtf8(shortcut, nativeShortcut, shortcutByteCount);
                nativeShortcut[nativeShortcutOffset] = 0;
            }
            else
            {
                nativeShortcut = null;
            }

            byte selected = 0;
            byte enabled = 1;
            byte ret = ImGuiNative.igMenuItem_Bool(nativeLabel, nativeShortcut, selected, enabled);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            if (shortcutByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeShortcut);
            }

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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeShortcut;
            int shortcutByteCount = 0;
            if (shortcut != null)
            {
                shortcutByteCount = Encoding.UTF8.GetByteCount(shortcut);
                if (shortcutByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeShortcut = Util.Allocate(shortcutByteCount + 1);
                }
                else
                {
                    byte* nativeShortcutStackBytes = stackalloc byte[shortcutByteCount + 1];
                    nativeShortcut = nativeShortcutStackBytes;
                }

                int nativeShortcutOffset = Util.GetUtf8(shortcut, nativeShortcut, shortcutByteCount);
                nativeShortcut[nativeShortcutOffset] = 0;
            }
            else
            {
                nativeShortcut = null;
            }

            byte nativeSelected = selected ? (byte) 1 : (byte) 0;
            byte enabled = 1;
            byte ret = ImGuiNative.igMenuItem_Bool(nativeLabel, nativeShortcut, nativeSelected, enabled);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            if (shortcutByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeShortcut);
            }

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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeShortcut;
            int shortcutByteCount = 0;
            if (shortcut != null)
            {
                shortcutByteCount = Encoding.UTF8.GetByteCount(shortcut);
                if (shortcutByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeShortcut = Util.Allocate(shortcutByteCount + 1);
                }
                else
                {
                    byte* nativeShortcutStackBytes = stackalloc byte[shortcutByteCount + 1];
                    nativeShortcut = nativeShortcutStackBytes;
                }

                int nativeShortcutOffset = Util.GetUtf8(shortcut, nativeShortcut, shortcutByteCount);
                nativeShortcut[nativeShortcutOffset] = 0;
            }
            else
            {
                nativeShortcut = null;
            }

            byte nativeSelected = selected ? (byte) 1 : (byte) 0;
            byte nativeEnabled = enabled ? (byte) 1 : (byte) 0;
            byte ret = ImGuiNative.igMenuItem_Bool(nativeLabel, nativeShortcut, nativeSelected, nativeEnabled);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            if (shortcutByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeShortcut);
            }

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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeShortcut;
            int shortcutByteCount = 0;
            if (shortcut != null)
            {
                shortcutByteCount = Encoding.UTF8.GetByteCount(shortcut);
                if (shortcutByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeShortcut = Util.Allocate(shortcutByteCount + 1);
                }
                else
                {
                    byte* nativeShortcutStackBytes = stackalloc byte[shortcutByteCount + 1];
                    nativeShortcut = nativeShortcutStackBytes;
                }

                int nativeShortcutOffset = Util.GetUtf8(shortcut, nativeShortcut, shortcutByteCount);
                nativeShortcut[nativeShortcutOffset] = 0;
            }
            else
            {
                nativeShortcut = null;
            }

            byte nativePSelectedVal = pSelected ? (byte) 1 : (byte) 0;
            byte* nativePSelected = &nativePSelectedVal;
            byte enabled = 1;
            byte ret = ImGuiNative.igMenuItem_BoolPtr(nativeLabel, nativeShortcut, nativePSelected, enabled);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            if (shortcutByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeShortcut);
            }

            pSelected = nativePSelectedVal != 0;
            return ret != 0;
        }

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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeShortcut;
            int shortcutByteCount = 0;
            if (shortcut != null)
            {
                shortcutByteCount = Encoding.UTF8.GetByteCount(shortcut);
                if (shortcutByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeShortcut = Util.Allocate(shortcutByteCount + 1);
                }
                else
                {
                    byte* nativeShortcutStackBytes = stackalloc byte[shortcutByteCount + 1];
                    nativeShortcut = nativeShortcutStackBytes;
                }

                int nativeShortcutOffset = Util.GetUtf8(shortcut, nativeShortcut, shortcutByteCount);
                nativeShortcut[nativeShortcutOffset] = 0;
            }
            else
            {
                nativeShortcut = null;
            }

            byte nativePSelectedVal = pSelected ? (byte) 1 : (byte) 0;
            byte* nativePSelected = &nativePSelectedVal;
            byte nativeEnabled = enabled ? (byte) 1 : (byte) 0;
            byte ret = ImGuiNative.igMenuItem_BoolPtr(nativeLabel, nativeShortcut, nativePSelected, nativeEnabled);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            if (shortcutByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeShortcut);
            }

            pSelected = nativePSelectedVal != 0;
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
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            ImGuiPopupFlags popupFlags = 0;
            ImGuiNative.igOpenPopup_Str(nativeStrId, popupFlags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }
        }

        /// <summary>
        ///     Opens the popup using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="popupFlags">The popup flags</param>
        public static void OpenPopup(string strId, ImGuiPopupFlags popupFlags)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            ImGuiNative.igOpenPopup_Str(nativeStrId, popupFlags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }
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
            byte* nativeStrId = null;
            ImGuiPopupFlags popupFlags = (ImGuiPopupFlags) 1;
            ImGuiNative.igOpenPopupOnItemClick(nativeStrId, popupFlags);
        }

        /// <summary>
        ///     Opens the popup on item click using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        public static void OpenPopupOnItemClick(string strId)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            ImGuiPopupFlags popupFlags = (ImGuiPopupFlags) 1;
            ImGuiNative.igOpenPopupOnItemClick(nativeStrId, popupFlags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }
        }

        /// <summary>
        ///     Opens the popup on item click using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="popupFlags">The popup flags</param>
        public static void OpenPopupOnItemClick(string strId, ImGuiPopupFlags popupFlags)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            ImGuiNative.igOpenPopupOnItemClick(nativeStrId, popupFlags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }
        }

        /// <summary>
        ///     Plots the histogram using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        public static void PlotHistogram(string label, ref float values, int valuesCount)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            int valuesOffset = 0;
            byte* nativeOverlayText = null;
            float scaleMin = float.MaxValue;
            float scaleMax = float.MaxValue;
            Vector2F graphSize = new Vector2F();
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotHistogram_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeOverlayText = null;
            float scaleMin = float.MaxValue;
            float scaleMax = float.MaxValue;
            Vector2F graphSize = new Vector2F();
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotHistogram_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeOverlayText;
            int overlayTextByteCount = 0;
            if (overlayText != null)
            {
                overlayTextByteCount = Encoding.UTF8.GetByteCount(overlayText);
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeOverlayText = Util.Allocate(overlayTextByteCount + 1);
                }
                else
                {
                    byte* nativeOverlayTextStackBytes = stackalloc byte[overlayTextByteCount + 1];
                    nativeOverlayText = nativeOverlayTextStackBytes;
                }

                int nativeOverlayTextOffset = Util.GetUtf8(overlayText, nativeOverlayText, overlayTextByteCount);
                nativeOverlayText[nativeOverlayTextOffset] = 0;
            }
            else
            {
                nativeOverlayText = null;
            }

            float scaleMin = float.MaxValue;
            float scaleMax = float.MaxValue;
            Vector2F graphSize = new Vector2F();
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotHistogram_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeOverlayText);
                }
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeOverlayText;
            int overlayTextByteCount = 0;
            if (overlayText != null)
            {
                overlayTextByteCount = Encoding.UTF8.GetByteCount(overlayText);
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeOverlayText = Util.Allocate(overlayTextByteCount + 1);
                }
                else
                {
                    byte* nativeOverlayTextStackBytes = stackalloc byte[overlayTextByteCount + 1];
                    nativeOverlayText = nativeOverlayTextStackBytes;
                }

                int nativeOverlayTextOffset = Util.GetUtf8(overlayText, nativeOverlayText, overlayTextByteCount);
                nativeOverlayText[nativeOverlayTextOffset] = 0;
            }
            else
            {
                nativeOverlayText = null;
            }

            float scaleMax = float.MaxValue;
            Vector2F graphSize = new Vector2F();
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotHistogram_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeOverlayText);
                }
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeOverlayText;
            int overlayTextByteCount = 0;
            if (overlayText != null)
            {
                overlayTextByteCount = Encoding.UTF8.GetByteCount(overlayText);
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeOverlayText = Util.Allocate(overlayTextByteCount + 1);
                }
                else
                {
                    byte* nativeOverlayTextStackBytes = stackalloc byte[overlayTextByteCount + 1];
                    nativeOverlayText = nativeOverlayTextStackBytes;
                }

                int nativeOverlayTextOffset = Util.GetUtf8(overlayText, nativeOverlayText, overlayTextByteCount);
                nativeOverlayText[nativeOverlayTextOffset] = 0;
            }
            else
            {
                nativeOverlayText = null;
            }

            Vector2F graphSize = new Vector2F();
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotHistogram_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeOverlayText);
                }
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeOverlayText;
            int overlayTextByteCount = 0;
            if (overlayText != null)
            {
                overlayTextByteCount = Encoding.UTF8.GetByteCount(overlayText);
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeOverlayText = Util.Allocate(overlayTextByteCount + 1);
                }
                else
                {
                    byte* nativeOverlayTextStackBytes = stackalloc byte[overlayTextByteCount + 1];
                    nativeOverlayText = nativeOverlayTextStackBytes;
                }

                int nativeOverlayTextOffset = Util.GetUtf8(overlayText, nativeOverlayText, overlayTextByteCount);
                nativeOverlayText[nativeOverlayTextOffset] = 0;
            }
            else
            {
                nativeOverlayText = null;
            }

            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotHistogram_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeOverlayText);
                }
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeOverlayText;
            int overlayTextByteCount = 0;
            if (overlayText != null)
            {
                overlayTextByteCount = Encoding.UTF8.GetByteCount(overlayText);
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeOverlayText = Util.Allocate(overlayTextByteCount + 1);
                }
                else
                {
                    byte* nativeOverlayTextStackBytes = stackalloc byte[overlayTextByteCount + 1];
                    nativeOverlayText = nativeOverlayTextStackBytes;
                }

                int nativeOverlayTextOffset = Util.GetUtf8(overlayText, nativeOverlayText, overlayTextByteCount);
                nativeOverlayText[nativeOverlayTextOffset] = 0;
            }
            else
            {
                nativeOverlayText = null;
            }

            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotHistogram_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeOverlayText);
                }
            }
        }

        /// <summary>
        ///     Plots the lines using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        public static void PlotLines(string label, ref float values, int valuesCount)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            int valuesOffset = 0;
            byte* nativeOverlayText = null;
            float scaleMin = float.MaxValue;
            float scaleMax = float.MaxValue;
            Vector2F graphSize = new Vector2F();
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotLines_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeOverlayText = null;
            float scaleMin = float.MaxValue;
            float scaleMax = float.MaxValue;
            Vector2F graphSize = new Vector2F();
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotLines_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeOverlayText;
            int overlayTextByteCount = 0;
            if (overlayText != null)
            {
                overlayTextByteCount = Encoding.UTF8.GetByteCount(overlayText);
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeOverlayText = Util.Allocate(overlayTextByteCount + 1);
                }
                else
                {
                    byte* nativeOverlayTextStackBytes = stackalloc byte[overlayTextByteCount + 1];
                    nativeOverlayText = nativeOverlayTextStackBytes;
                }

                int nativeOverlayTextOffset = Util.GetUtf8(overlayText, nativeOverlayText, overlayTextByteCount);
                nativeOverlayText[nativeOverlayTextOffset] = 0;
            }
            else
            {
                nativeOverlayText = null;
            }

            float scaleMin = float.MaxValue;
            float scaleMax = float.MaxValue;
            Vector2F graphSize = new Vector2F();
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotLines_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeOverlayText);
                }
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeOverlayText;
            int overlayTextByteCount = 0;
            if (overlayText != null)
            {
                overlayTextByteCount = Encoding.UTF8.GetByteCount(overlayText);
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeOverlayText = Util.Allocate(overlayTextByteCount + 1);
                }
                else
                {
                    byte* nativeOverlayTextStackBytes = stackalloc byte[overlayTextByteCount + 1];
                    nativeOverlayText = nativeOverlayTextStackBytes;
                }

                int nativeOverlayTextOffset = Util.GetUtf8(overlayText, nativeOverlayText, overlayTextByteCount);
                nativeOverlayText[nativeOverlayTextOffset] = 0;
            }
            else
            {
                nativeOverlayText = null;
            }

            float scaleMax = float.MaxValue;
            Vector2F graphSize = new Vector2F();
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotLines_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeOverlayText);
                }
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeOverlayText;
            int overlayTextByteCount = 0;
            if (overlayText != null)
            {
                overlayTextByteCount = Encoding.UTF8.GetByteCount(overlayText);
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeOverlayText = Util.Allocate(overlayTextByteCount + 1);
                }
                else
                {
                    byte* nativeOverlayTextStackBytes = stackalloc byte[overlayTextByteCount + 1];
                    nativeOverlayText = nativeOverlayTextStackBytes;
                }

                int nativeOverlayTextOffset = Util.GetUtf8(overlayText, nativeOverlayText, overlayTextByteCount);
                nativeOverlayText[nativeOverlayTextOffset] = 0;
            }
            else
            {
                nativeOverlayText = null;
            }

            Vector2F graphSize = new Vector2F();
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotLines_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeOverlayText);
                }
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeOverlayText;
            int overlayTextByteCount = 0;
            if (overlayText != null)
            {
                overlayTextByteCount = Encoding.UTF8.GetByteCount(overlayText);
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeOverlayText = Util.Allocate(overlayTextByteCount + 1);
                }
                else
                {
                    byte* nativeOverlayTextStackBytes = stackalloc byte[overlayTextByteCount + 1];
                    nativeOverlayText = nativeOverlayTextStackBytes;
                }

                int nativeOverlayTextOffset = Util.GetUtf8(overlayText, nativeOverlayText, overlayTextByteCount);
                nativeOverlayText[nativeOverlayTextOffset] = 0;
            }
            else
            {
                nativeOverlayText = null;
            }

            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotLines_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeOverlayText);
                }
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeOverlayText;
            int overlayTextByteCount = 0;
            if (overlayText != null)
            {
                overlayTextByteCount = Encoding.UTF8.GetByteCount(overlayText);
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeOverlayText = Util.Allocate(overlayTextByteCount + 1);
                }
                else
                {
                    byte* nativeOverlayTextStackBytes = stackalloc byte[overlayTextByteCount + 1];
                    nativeOverlayText = nativeOverlayTextStackBytes;
                }

                int nativeOverlayTextOffset = Util.GetUtf8(overlayText, nativeOverlayText, overlayTextByteCount);
                nativeOverlayText[nativeOverlayTextOffset] = 0;
            }
            else
            {
                nativeOverlayText = null;
            }

            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotLines_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeOverlayText);
                }
            }
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
        ///     Pops the tab stop
        /// </summary>
        public static void PopTabStop()
        {
            ImGuiNative.igPopTabStop();
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
            byte* nativeOverlay = null;
            ImGuiNative.igProgressBar(fraction, sizeArg, nativeOverlay);
        }

        /// <summary>
        ///     Progresses the bar using the specified fraction
        /// </summary>
        /// <param name="fraction">The fraction</param>
        /// <param name="sizeArg">The size arg</param>
        public static void ProgressBar(float fraction, Vector2F sizeArg)
        {
            byte* nativeOverlay = null;
            ImGuiNative.igProgressBar(fraction, sizeArg, nativeOverlay);
        }

        /// <summary>
        ///     Progresses the bar using the specified fraction
        /// </summary>
        /// <param name="fraction">The fraction</param>
        /// <param name="sizeArg">The size arg</param>
        /// <param name="overlay">The overlay</param>
        public static void ProgressBar(float fraction, Vector2F sizeArg, string overlay)
        {
            byte* nativeOverlay;
            int overlayByteCount = 0;
            if (overlay != null)
            {
                overlayByteCount = Encoding.UTF8.GetByteCount(overlay);
                if (overlayByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeOverlay = Util.Allocate(overlayByteCount + 1);
                }
                else
                {
                    byte* nativeOverlayStackBytes = stackalloc byte[overlayByteCount + 1];
                    nativeOverlay = nativeOverlayStackBytes;
                }

                int nativeOverlayOffset = Util.GetUtf8(overlay, nativeOverlay, overlayByteCount);
                nativeOverlay[nativeOverlayOffset] = 0;
            }
            else
            {
                nativeOverlay = null;
            }

            ImGuiNative.igProgressBar(fraction, sizeArg, nativeOverlay);
            if (overlayByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeOverlay);
            }
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
            ImFont* nativeFont = font.NativePtr;
            ImGuiNative.igPushFont(nativeFont);
        }

        /// <summary>
        ///     Pushes the id using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        public static void PushId(string strId)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            ImGuiNative.igPushID_Str(nativeStrId);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }
        }

        /// <summary>
        ///     Pushes the id using the specified ptr id
        /// </summary>
        /// <param name="ptrId">The ptr id</param>
        public static void PushId(IntPtr ptrId)
        {
            void* nativePtrId = ptrId.ToPointer();
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
        ///     Pushes the tab stop using the specified tab stop
        /// </summary>
        /// <param name="tabStop">The tab stop</param>
        public static void PushTabStop(bool tabStop)
        {
            byte nativeTabStop = tabStop ? (byte) 1 : (byte) 0;
            ImGuiNative.igPushTabStop(nativeTabStop);
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte nativeActive = active ? (byte) 1 : (byte) 0;
            byte ret = ImGuiNative.igRadioButton_Bool(nativeLabel, nativeActive);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igRadioButton_IntPtr(nativeLabel, nativeV, vButton);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                return ret != 0;
            }
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
            void* platformRenderArg = null;
            void* rendererRenderArg = null;
            ImGuiNative.igRenderPlatformWindowsDefault(platformRenderArg, rendererRenderArg);
        }

        /// <summary>
        ///     Renders the platform windows default using the specified platform render arg
        /// </summary>
        /// <param name="platformRenderArg">The platform render arg</param>
        public static void RenderPlatformWindowsDefault(IntPtr platformRenderArg)
        {
            void* nativePlatformRenderArg = platformRenderArg.ToPointer();
            void* rendererRenderArg = null;
            ImGuiNative.igRenderPlatformWindowsDefault(nativePlatformRenderArg, rendererRenderArg);
        }

        /// <summary>
        ///     Renders the platform windows default using the specified platform render arg
        /// </summary>
        /// <param name="platformRenderArg">The platform render arg</param>
        /// <param name="rendererRenderArg">The renderer render arg</param>
        public static void RenderPlatformWindowsDefault(IntPtr platformRenderArg, IntPtr rendererRenderArg)
        {
            void* nativePlatformRenderArg = platformRenderArg.ToPointer();
            void* nativeRendererRenderArg = rendererRenderArg.ToPointer();
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
            byte* nativeIniFilename;
            int iniFilenameByteCount = 0;
            if (iniFilename != null)
            {
                iniFilenameByteCount = Encoding.UTF8.GetByteCount(iniFilename);
                if (iniFilenameByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeIniFilename = Util.Allocate(iniFilenameByteCount + 1);
                }
                else
                {
                    byte* nativeIniFilenameStackBytes = stackalloc byte[iniFilenameByteCount + 1];
                    nativeIniFilename = nativeIniFilenameStackBytes;
                }

                int nativeIniFilenameOffset = Util.GetUtf8(iniFilename, nativeIniFilename, iniFilenameByteCount);
                nativeIniFilename[nativeIniFilenameOffset] = 0;
            }
            else
            {
                nativeIniFilename = null;
            }

            ImGuiNative.igSaveIniSettingsToDisk(nativeIniFilename);
            if (iniFilenameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeIniFilename);
            }
        }

        /// <summary>
        ///     Saves the ini settings to memory
        /// </summary>
        /// <returns>The string</returns>
        public static string SaveIniSettingsToMemory()
        {
            uint* outIniSize = null;
            byte* ret = ImGuiNative.igSaveIniSettingsToMemory(outIniSize);
            return Util.StringFromPtr(ret);
        }

        /// <summary>
        ///     Saves the ini settings to memory using the specified out ini size
        /// </summary>
        /// <param name="outIniSize">The out ini size</param>
        /// <returns>The string</returns>
        public static string SaveIniSettingsToMemory(out uint outIniSize)
        {
            fixed (uint* nativeOutIniSize = &outIniSize)
            {
                byte* ret = ImGuiNative.igSaveIniSettingsToMemory(nativeOutIniSize);
                return Util.StringFromPtr(ret);
            }
        }

        /// <summary>
        ///     Describes whether selectable
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool Selectable(string label)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte selected = 0;
            ImGuiSelectableFlags flags = 0;
            Vector2F size = new Vector2F();
            byte ret = ImGuiNative.igSelectable_Bool(nativeLabel, selected, flags, size);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte nativeSelected = selected ? (byte) 1 : (byte) 0;
            ImGuiSelectableFlags flags = 0;
            Vector2F size = new Vector2F();
            byte ret = ImGuiNative.igSelectable_Bool(nativeLabel, nativeSelected, flags, size);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte nativeSelected = selected ? (byte) 1 : (byte) 0;
            Vector2F size = new Vector2F();
            byte ret = ImGuiNative.igSelectable_Bool(nativeLabel, nativeSelected, flags, size);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte nativeSelected = selected ? (byte) 1 : (byte) 0;
            byte ret = ImGuiNative.igSelectable_Bool(nativeLabel, nativeSelected, flags, size);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte nativePSelectedVal = pSelected ? (byte) 1 : (byte) 0;
            byte* nativePSelected = &nativePSelectedVal;
            ImGuiSelectableFlags flags = 0;
            Vector2F size = new Vector2F();
            byte ret = ImGuiNative.igSelectable_BoolPtr(nativeLabel, nativePSelected, flags, size);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            pSelected = nativePSelectedVal != 0;
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte nativePSelectedVal = pSelected ? (byte) 1 : (byte) 0;
            byte* nativePSelected = &nativePSelectedVal;
            Vector2F size = new Vector2F();
            byte ret = ImGuiNative.igSelectable_BoolPtr(nativeLabel, nativePSelected, flags, size);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            pSelected = nativePSelectedVal != 0;
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte nativePSelectedVal = pSelected ? (byte) 1 : (byte) 0;
            byte* nativePSelected = &nativePSelectedVal;
            byte ret = ImGuiNative.igSelectable_BoolPtr(nativeLabel, nativePSelected, flags, size);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            pSelected = nativePSelectedVal != 0;
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
        ///     Separators the text using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        public static void SeparatorText(string label)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            ImGuiNative.igSeparatorText(nativeLabel);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
        }

        /// <summary>
        ///     Sets the allocator functions using the specified alloc func
        /// </summary>
        /// <param name="allocFunc">The alloc func</param>
        /// <param name="freeFunc">The free func</param>
        public static void SetAllocatorFunctions(IntPtr allocFunc, IntPtr freeFunc)
        {
            void* userData = null;
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
            void* nativeUserData = userData.ToPointer();
            ImGuiNative.igSetAllocatorFunctions(allocFunc, freeFunc, nativeUserData);
        }

        /// <summary>
        ///     Sets the clipboard text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        public static void SetClipboardText(string text)
        {
            byte* nativeText;
            int textByteCount = 0;
            if (text != null)
            {
                textByteCount = Encoding.UTF8.GetByteCount(text);
                if (textByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeText = Util.Allocate(textByteCount + 1);
                }
                else
                {
                    byte* nativeTextStackBytes = stackalloc byte[textByteCount + 1];
                    nativeText = nativeTextStackBytes;
                }

                int nativeTextOffset = Util.GetUtf8(text, nativeText, textByteCount);
                nativeText[nativeTextOffset] = 0;
            }
            else
            {
                nativeText = null;
            }

            ImGuiNative.igSetClipboardText(nativeText);
            if (textByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeText);
            }
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
            byte* nativeType;
            int typeByteCount = 0;
            if (type != null)
            {
                typeByteCount = Encoding.UTF8.GetByteCount(type);
                if (typeByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeType = Util.Allocate(typeByteCount + 1);
                }
                else
                {
                    byte* nativeTypeStackBytes = stackalloc byte[typeByteCount + 1];
                    nativeType = nativeTypeStackBytes;
                }

                int nativeTypeOffset = Util.GetUtf8(type, nativeType, typeByteCount);
                nativeType[nativeTypeOffset] = 0;
            }
            else
            {
                nativeType = null;
            }

            void* nativeData = data.ToPointer();
            ImGuiCond cond = 0;
            byte ret = ImGuiNative.igSetDragDropPayload(nativeType, nativeData, sz, cond);
            if (typeByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeType);
            }

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
            byte* nativeType;
            int typeByteCount = 0;
            if (type != null)
            {
                typeByteCount = Encoding.UTF8.GetByteCount(type);
                if (typeByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeType = Util.Allocate(typeByteCount + 1);
                }
                else
                {
                    byte* nativeTypeStackBytes = stackalloc byte[typeByteCount + 1];
                    nativeType = nativeTypeStackBytes;
                }

                int nativeTypeOffset = Util.GetUtf8(type, nativeType, typeByteCount);
                nativeType[nativeTypeOffset] = 0;
            }
            else
            {
                nativeType = null;
            }

            void* nativeData = data.ToPointer();
            byte ret = ImGuiNative.igSetDragDropPayload(nativeType, nativeData, sz, cond);
            if (typeByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeType);
            }

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
        public static void SetNextWindowClass(ImGuiWindowClassPtr windowClass)
        {
            ImGuiWindowClass* nativeWindowClass = windowClass.NativePtr;
            ImGuiNative.igSetNextWindowClass(nativeWindowClass);
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
            void* customCallbackData = null;
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
            void* customCallbackData = null;
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
            void* nativeCustomCallbackData = customCallbackData.ToPointer();
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
        public static void SetStateStorage(ImGuiStoragePtr storage)
        {
            ImGuiStorage* nativeStorage = storage.NativePtr;
            ImGuiNative.igSetStateStorage(nativeStorage);
        }

        /// <summary>
        ///     Sets the tab item closed using the specified tab or docked window label
        /// </summary>
        /// <param name="tabOrDockedWindowLabel">The tab or docked window label</param>
        public static void SetTabItemClosed(string tabOrDockedWindowLabel)
        {
            byte* nativeTabOrDockedWindowLabel;
            int tabOrDockedWindowLabelByteCount = 0;
            if (tabOrDockedWindowLabel != null)
            {
                tabOrDockedWindowLabelByteCount = Encoding.UTF8.GetByteCount(tabOrDockedWindowLabel);
                if (tabOrDockedWindowLabelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeTabOrDockedWindowLabel = Util.Allocate(tabOrDockedWindowLabelByteCount + 1);
                }
                else
                {
                    byte* nativeTabOrDockedWindowLabelStackBytes = stackalloc byte[tabOrDockedWindowLabelByteCount + 1];
                    nativeTabOrDockedWindowLabel = nativeTabOrDockedWindowLabelStackBytes;
                }

                int nativeTabOrDockedWindowLabelOffset = Util.GetUtf8(tabOrDockedWindowLabel, nativeTabOrDockedWindowLabel, tabOrDockedWindowLabelByteCount);
                nativeTabOrDockedWindowLabel[nativeTabOrDockedWindowLabelOffset] = 0;
            }
            else
            {
                nativeTabOrDockedWindowLabel = null;
            }

            ImGuiNative.igSetTabItemClosed(nativeTabOrDockedWindowLabel);
            if (tabOrDockedWindowLabelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeTabOrDockedWindowLabel);
            }
        }

        /// <summary>
        ///     Sets the tooltip using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        public static void SetTooltip(string fmt)
        {
            byte* nativeFmt;
            int fmtByteCount = 0;
            if (fmt != null)
            {
                fmtByteCount = Encoding.UTF8.GetByteCount(fmt);
                if (fmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFmt = Util.Allocate(fmtByteCount + 1);
                }
                else
                {
                    byte* nativeFmtStackBytes = stackalloc byte[fmtByteCount + 1];
                    nativeFmt = nativeFmtStackBytes;
                }

                int nativeFmtOffset = Util.GetUtf8(fmt, nativeFmt, fmtByteCount);
                nativeFmt[nativeFmtOffset] = 0;
            }
            else
            {
                nativeFmt = null;
            }

            ImGuiNative.igSetTooltip(nativeFmt);
            if (fmtByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFmt);
            }
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
            byte* nativeName;
            int nameByteCount = 0;
            if (name != null)
            {
                nameByteCount = Encoding.UTF8.GetByteCount(name);
                if (nameByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeName = Util.Allocate(nameByteCount + 1);
                }
                else
                {
                    byte* nativeNameStackBytes = stackalloc byte[nameByteCount + 1];
                    nativeName = nativeNameStackBytes;
                }

                int nativeNameOffset = Util.GetUtf8(name, nativeName, nameByteCount);
                nativeName[nativeNameOffset] = 0;
            }
            else
            {
                nativeName = null;
            }

            byte nativeCollapsed = collapsed ? (byte) 1 : (byte) 0;
            ImGuiCond cond = 0;
            ImGuiNative.igSetWindowCollapsed_Str(nativeName, nativeCollapsed, cond);
            if (nameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeName);
            }
        }

        /// <summary>
        ///     Sets the window collapsed using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="collapsed">The collapsed</param>
        /// <param name="cond">The cond</param>
        public static void SetWindowCollapsed(string name, bool collapsed, ImGuiCond cond)
        {
            byte* nativeName;
            int nameByteCount = 0;
            if (name != null)
            {
                nameByteCount = Encoding.UTF8.GetByteCount(name);
                if (nameByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeName = Util.Allocate(nameByteCount + 1);
                }
                else
                {
                    byte* nativeNameStackBytes = stackalloc byte[nameByteCount + 1];
                    nativeName = nativeNameStackBytes;
                }

                int nativeNameOffset = Util.GetUtf8(name, nativeName, nameByteCount);
                nativeName[nativeNameOffset] = 0;
            }
            else
            {
                nativeName = null;
            }

            byte nativeCollapsed = collapsed ? (byte) 1 : (byte) 0;
            ImGuiNative.igSetWindowCollapsed_Str(nativeName, nativeCollapsed, cond);
            if (nameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeName);
            }
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
            byte* nativeName;
            int nameByteCount = 0;
            if (name != null)
            {
                nameByteCount = Encoding.UTF8.GetByteCount(name);
                if (nameByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeName = Util.Allocate(nameByteCount + 1);
                }
                else
                {
                    byte* nativeNameStackBytes = stackalloc byte[nameByteCount + 1];
                    nativeName = nativeNameStackBytes;
                }

                int nativeNameOffset = Util.GetUtf8(name, nativeName, nameByteCount);
                nativeName[nativeNameOffset] = 0;
            }
            else
            {
                nativeName = null;
            }

            ImGuiNative.igSetWindowFocus_Str(nativeName);
            if (nameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeName);
            }
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
            byte* nativeName;
            int nameByteCount = 0;
            if (name != null)
            {
                nameByteCount = Encoding.UTF8.GetByteCount(name);
                if (nameByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeName = Util.Allocate(nameByteCount + 1);
                }
                else
                {
                    byte* nativeNameStackBytes = stackalloc byte[nameByteCount + 1];
                    nativeName = nativeNameStackBytes;
                }

                int nativeNameOffset = Util.GetUtf8(name, nativeName, nameByteCount);
                nativeName[nativeNameOffset] = 0;
            }
            else
            {
                nativeName = null;
            }

            ImGuiCond cond = 0;
            ImGuiNative.igSetWindowPos_Str(nativeName, pos, cond);
            if (nameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeName);
            }
        }

        /// <summary>
        ///     Sets the window pos using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="pos">The pos</param>
        /// <param name="cond">The cond</param>
        public static void SetWindowPos(string name, Vector2F pos, ImGuiCond cond)
        {
            byte* nativeName;
            int nameByteCount = 0;
            if (name != null)
            {
                nameByteCount = Encoding.UTF8.GetByteCount(name);
                if (nameByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeName = Util.Allocate(nameByteCount + 1);
                }
                else
                {
                    byte* nativeNameStackBytes = stackalloc byte[nameByteCount + 1];
                    nativeName = nativeNameStackBytes;
                }

                int nativeNameOffset = Util.GetUtf8(name, nativeName, nameByteCount);
                nativeName[nativeNameOffset] = 0;
            }
            else
            {
                nativeName = null;
            }

            ImGuiNative.igSetWindowPos_Str(nativeName, pos, cond);
            if (nameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeName);
            }
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
            byte* nativeName;
            int nameByteCount = 0;
            if (name != null)
            {
                nameByteCount = Encoding.UTF8.GetByteCount(name);
                if (nameByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeName = Util.Allocate(nameByteCount + 1);
                }
                else
                {
                    byte* nativeNameStackBytes = stackalloc byte[nameByteCount + 1];
                    nativeName = nativeNameStackBytes;
                }

                int nativeNameOffset = Util.GetUtf8(name, nativeName, nameByteCount);
                nativeName[nativeNameOffset] = 0;
            }
            else
            {
                nativeName = null;
            }

            ImGuiCond cond = 0;
            ImGuiNative.igSetWindowSize_Str(nativeName, size, cond);
            if (nameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeName);
            }
        }

        /// <summary>
        ///     Sets the window size using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="size">The size</param>
        /// <param name="cond">The cond</param>
        public static void SetWindowSize(string name, Vector2F size, ImGuiCond cond)
        {
            byte* nativeName;
            int nameByteCount = 0;
            if (name != null)
            {
                nameByteCount = Encoding.UTF8.GetByteCount(name);
                if (nameByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeName = Util.Allocate(nameByteCount + 1);
                }
                else
                {
                    byte* nativeNameStackBytes = stackalloc byte[nameByteCount + 1];
                    nativeName = nativeNameStackBytes;
                }

                int nativeNameOffset = Util.GetUtf8(name, nativeName, nameByteCount);
                nativeName[nativeNameOffset] = 0;
            }
            else
            {
                nativeName = null;
            }

            ImGuiNative.igSetWindowSize_Str(nativeName, size, cond);
            if (nameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeName);
            }
        }

        /// <summary>
        ///     Shows the about window
        /// </summary>
        public static void ShowAboutWindow()
        {
            byte* pOpen = null;
            ImGuiNative.igShowAboutWindow(pOpen);
        }

        /// <summary>
        ///     Shows the about window using the specified p open
        /// </summary>
        /// <param name="pOpen">The open</param>
        public static void ShowAboutWindow(ref bool pOpen)
        {
            byte nativePOpenVal = pOpen ? (byte) 1 : (byte) 0;
            byte* nativePOpen = &nativePOpenVal;
            ImGuiNative.igShowAboutWindow(nativePOpen);
            pOpen = nativePOpenVal != 0;
        }

        /// <summary>
        ///     Shows the debug log window
        /// </summary>
        public static void ShowDebugLogWindow()
        {
            byte* pOpen = null;
            ImGuiNative.igShowDebugLogWindow(pOpen);
        }

        /// <summary>
        ///     Shows the debug log window using the specified p open
        /// </summary>
        /// <param name="pOpen">The open</param>
        public static void ShowDebugLogWindow(ref bool pOpen)
        {
            byte nativePOpenVal = pOpen ? (byte) 1 : (byte) 0;
            byte* nativePOpen = &nativePOpenVal;
            ImGuiNative.igShowDebugLogWindow(nativePOpen);
            pOpen = nativePOpenVal != 0;
        }

        /// <summary>
        ///     Shows the demo window
        /// </summary>
        public static void ShowDemoWindow()
        {
            byte* pOpen = null;
            ImGuiNative.igShowDemoWindow(pOpen);
        }

        /// <summary>
        ///     Shows the demo window using the specified p open
        /// </summary>
        /// <param name="pOpen">The open</param>
        public static void ShowDemoWindow(ref bool pOpen)
        {
            byte nativePOpenVal = pOpen ? (byte) 1 : (byte) 0;
            byte* nativePOpen = &nativePOpenVal;
            ImGuiNative.igShowDemoWindow(nativePOpen);
            pOpen = nativePOpenVal != 0;
        }

        /// <summary>
        ///     Shows the font selector using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        public static void ShowFontSelector(string label)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            ImGuiNative.igShowFontSelector(nativeLabel);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
        }

        /// <summary>
        ///     Shows the metrics window
        /// </summary>
        public static void ShowMetricsWindow()
        {
            byte* pOpen = null;
            ImGuiNative.igShowMetricsWindow(pOpen);
        }

        /// <summary>
        ///     Shows the metrics window using the specified p open
        /// </summary>
        /// <param name="pOpen">The open</param>
        public static void ShowMetricsWindow(ref bool pOpen)
        {
            byte nativePOpenVal = pOpen ? (byte) 1 : (byte) 0;
            byte* nativePOpen = &nativePOpenVal;
            ImGuiNative.igShowMetricsWindow(nativePOpen);
            pOpen = nativePOpenVal != 0;
        }

        /// <summary>
        ///     Shows the stack tool window
        /// </summary>
        public static void ShowStackToolWindow()
        {
            byte* pOpen = null;
            ImGuiNative.igShowStackToolWindow(pOpen);
        }

        /// <summary>
        ///     Shows the stack tool window using the specified p open
        /// </summary>
        /// <param name="pOpen">The open</param>
        public static void ShowStackToolWindow(ref bool pOpen)
        {
            byte nativePOpenVal = pOpen ? (byte) 1 : (byte) 0;
            byte* nativePOpen = &nativePOpenVal;
            ImGuiNative.igShowStackToolWindow(nativePOpen);
            pOpen = nativePOpenVal != 0;
        }

        /// <summary>
        ///     Shows the style editor
        /// </summary>
        public static void ShowStyleEditor()
        {
            ImGuiStyle* @ref = null;
            ImGuiNative.igShowStyleEditor(@ref);
        }

        /// <summary>
        /// </summary>
        /// <param name="ref"></param>
        public static void ShowStyleEditor(ImGuiStylePtr @ref)
        {
            ImGuiStyle* nativeRef = @ref.NativePtr;
            ImGuiNative.igShowStyleEditor(nativeRef);
        }

        /// <summary>
        ///     Describes whether show style selector
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool ShowStyleSelector(string label)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte ret = ImGuiNative.igShowStyleSelector(nativeLabel);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Shows the user guide
        /// </summary>
        public static void ShowUserGuide()
        {
            ImGuiNative.igShowUserGuide();
        }

        /// <summary>
        ///     Describes whether slider angle
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vRad">The rad</param>
        /// <returns>The bool</returns>
        public static bool SliderAngle(string label, ref float vRad)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            float vDegreesMin = -360.0f;
            float vDegreesMax = +360.0f;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.0f deg");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.0f deg", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (float* nativeVRad = &vRad)
            {
                byte ret = ImGuiNative.igSliderAngle(nativeLabel, nativeVRad, vDegreesMin, vDegreesMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider angle
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vRad">The rad</param>
        /// <param name="vDegreesMin">The degrees min</param>
        /// <returns>The bool</returns>
        public static bool SliderAngle(string label, ref float vRad, float vDegreesMin)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            float vDegreesMax = +360.0f;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.0f deg");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.0f deg", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (float* nativeVRad = &vRad)
            {
                byte ret = ImGuiNative.igSliderAngle(nativeLabel, nativeVRad, vDegreesMin, vDegreesMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider angle
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vRad">The rad</param>
        /// <param name="vDegreesMin">The degrees min</param>
        /// <param name="vDegreesMax">The degrees max</param>
        /// <returns>The bool</returns>
        public static bool SliderAngle(string label, ref float vRad, float vDegreesMin, float vDegreesMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.0f deg");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.0f deg", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (float* nativeVRad = &vRad)
            {
                byte ret = ImGuiNative.igSliderAngle(nativeLabel, nativeVRad, vDegreesMin, vDegreesMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider angle
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vRad">The rad</param>
        /// <param name="vDegreesMin">The degrees min</param>
        /// <param name="vDegreesMax">The degrees max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SliderAngle(string label, ref float vRad, float vDegreesMin, float vDegreesMax, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiSliderFlags flags = 0;
            fixed (float* nativeVRad = &vRad)
            {
                byte ret = ImGuiNative.igSliderAngle(nativeLabel, nativeVRad, vDegreesMin, vDegreesMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider angle
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vRad">The rad</param>
        /// <param name="vDegreesMin">The degrees min</param>
        /// <param name="vDegreesMax">The degrees max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool SliderAngle(string label, ref float vRad, float vDegreesMin, float vDegreesMax, string format, ImGuiSliderFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            fixed (float* nativeVRad = &vRad)
            {
                byte ret = ImGuiNative.igSliderAngle(nativeLabel, nativeVRad, vDegreesMin, vDegreesMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool SliderFloat(string label, ref float v, float vMin, float vMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (float* nativeV = &v)
            {
                byte ret = ImGuiNative.igSliderFloat(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SliderFloat(string label, ref float v, float vMin, float vMax, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiSliderFlags flags = 0;
            fixed (float* nativeV = &v)
            {
                byte ret = ImGuiNative.igSliderFloat(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool SliderFloat(string label, ref float v, float vMin, float vMax, string format, ImGuiSliderFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            fixed (float* nativeV = &v)
            {
                byte ret = ImGuiNative.igSliderFloat(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool SliderFloat2(string label, ref Vector2F v, float vMin, float vMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (Vector2F* nativeV = &v)
            {
                byte ret = ImGuiNative.igSliderFloat2(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SliderFloat2(string label, ref Vector2F v, float vMin, float vMax, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiSliderFlags flags = 0;
            fixed (Vector2F* nativeV = &v)
            {
                byte ret = ImGuiNative.igSliderFloat2(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool SliderFloat2(string label, ref Vector2F v, float vMin, float vMax, string format, ImGuiSliderFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            fixed (Vector2F* nativeV = &v)
            {
                byte ret = ImGuiNative.igSliderFloat2(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool SliderFloat3(string label, ref Vector3F v, float vMin, float vMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (Vector3F* nativeV = &v)
            {
                byte ret = ImGuiNative.igSliderFloat3(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SliderFloat3(string label, ref Vector3F v, float vMin, float vMax, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiSliderFlags flags = 0;
            fixed (Vector3F* nativeV = &v)
            {
                byte ret = ImGuiNative.igSliderFloat3(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool SliderFloat3(string label, ref Vector3F v, float vMin, float vMax, string format, ImGuiSliderFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            fixed (Vector3F* nativeV = &v)
            {
                byte ret = ImGuiNative.igSliderFloat3(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool SliderFloat4(string label, ref Vector4F v, float vMin, float vMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (Vector4F* nativeV = &v)
            {
                byte ret = ImGuiNative.igSliderFloat4(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SliderFloat4(string label, ref Vector4F v, float vMin, float vMax, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiSliderFlags flags = 0;
            fixed (Vector4F* nativeV = &v)
            {
                byte ret = ImGuiNative.igSliderFloat4(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool SliderFloat4(string label, ref Vector4F v, float vMin, float vMax, string format, ImGuiSliderFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            fixed (Vector4F* nativeV = &v)
            {
                byte ret = ImGuiNative.igSliderFloat4(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool SliderInt(string label, ref int v, int vMin, int vMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igSliderInt(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SliderInt(string label, ref int v, int vMin, int vMax, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igSliderInt(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool SliderInt(string label, ref int v, int vMin, int vMax, string format, ImGuiSliderFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igSliderInt(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider int 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool SliderInt2(string label, ref int v, int vMin, int vMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igSliderInt2(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider int 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SliderInt2(string label, ref int v, int vMin, int vMax, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igSliderInt2(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider int 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool SliderInt2(string label, ref int v, int vMin, int vMax, string format, ImGuiSliderFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igSliderInt2(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider int 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool SliderInt3(string label, ref int v, int vMin, int vMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igSliderInt3(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider int 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SliderInt3(string label, ref int v, int vMin, int vMax, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igSliderInt3(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider int 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool SliderInt3(string label, ref int v, int vMin, int vMax, string format, ImGuiSliderFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igSliderInt3(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider int 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool SliderInt4(string label, ref int v, int vMin, int vMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igSliderInt4(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider int 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SliderInt4(string label, ref int v, int vMin, int vMax, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igSliderInt4(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider int 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool SliderInt4(string label, ref int v, int vMin, int vMax, string format, ImGuiSliderFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igSliderInt4(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether slider scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <returns>The bool</returns>
        public static bool SliderScalar(string label, ImGuiDataType dataType, IntPtr pData, IntPtr pMin, IntPtr pMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* nativePMin = pMin.ToPointer();
            void* nativePMax = pMax.ToPointer();
            byte* nativeFormat = null;
            ImGuiSliderFlags flags = 0;
            byte ret = ImGuiNative.igSliderScalar(nativeLabel, dataType, nativePData, nativePMin, nativePMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether slider scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SliderScalar(string label, ImGuiDataType dataType, IntPtr pData, IntPtr pMin, IntPtr pMax, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* nativePMin = pMin.ToPointer();
            void* nativePMax = pMax.ToPointer();
            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiSliderFlags flags = 0;
            byte ret = ImGuiNative.igSliderScalar(nativeLabel, dataType, nativePData, nativePMin, nativePMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFormat);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether slider scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool SliderScalar(string label, ImGuiDataType dataType, IntPtr pData, IntPtr pMin, IntPtr pMax, string format, ImGuiSliderFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* nativePMin = pMin.ToPointer();
            void* nativePMax = pMax.ToPointer();
            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            byte ret = ImGuiNative.igSliderScalar(nativeLabel, dataType, nativePData, nativePMin, nativePMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFormat);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether slider scalar n
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="components">The components</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <returns>The bool</returns>
        public static bool SliderScalarN(string label, ImGuiDataType dataType, IntPtr pData, int components, IntPtr pMin, IntPtr pMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* nativePMin = pMin.ToPointer();
            void* nativePMax = pMax.ToPointer();
            byte* nativeFormat = null;
            ImGuiSliderFlags flags = 0;
            byte ret = ImGuiNative.igSliderScalarN(nativeLabel, dataType, nativePData, components, nativePMin, nativePMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether slider scalar n
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="components">The components</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SliderScalarN(string label, ImGuiDataType dataType, IntPtr pData, int components, IntPtr pMin, IntPtr pMax, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* nativePMin = pMin.ToPointer();
            void* nativePMax = pMax.ToPointer();
            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiSliderFlags flags = 0;
            byte ret = ImGuiNative.igSliderScalarN(nativeLabel, dataType, nativePData, components, nativePMin, nativePMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFormat);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether slider scalar n
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="components">The components</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool SliderScalarN(string label, ImGuiDataType dataType, IntPtr pData, int components, IntPtr pMin, IntPtr pMax, string format, ImGuiSliderFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* nativePMin = pMin.ToPointer();
            void* nativePMax = pMax.ToPointer();
            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            byte ret = ImGuiNative.igSliderScalarN(nativeLabel, dataType, nativePData, components, nativePMin, nativePMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFormat);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether small button
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool SmallButton(string label)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte ret = ImGuiNative.igSmallButton(nativeLabel);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Spacings
        /// </summary>
        public static void Spacing()
        {
            ImGuiNative.igSpacing();
        }

        /// <summary>
        ///     Styles the colors classic
        /// </summary>
        public static void StyleColorsClassic()
        {
            ImGuiStyle* dst = null;
            ImGuiNative.igStyleColorsClassic(dst);
        }

        /// <summary>
        ///     Styles the colors classic using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        public static void StyleColorsClassic(ImGuiStylePtr dst)
        {
            ImGuiStyle* nativeDst = dst.NativePtr;
            ImGuiNative.igStyleColorsClassic(nativeDst);
        }

        /// <summary>
        ///     Styles the colors dark
        /// </summary>
        public static void StyleColorsDark()
        {
            ImGuiStyle* dst = null;
            ImGuiNative.igStyleColorsDark(dst);
        }

        /// <summary>
        ///     Styles the colors dark using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        public static void StyleColorsDark(ImGuiStylePtr dst)
        {
            ImGuiStyle* nativeDst = dst.NativePtr;
            ImGuiNative.igStyleColorsDark(nativeDst);
        }

        /// <summary>
        ///     Styles the colors light
        /// </summary>
        public static void StyleColorsLight()
        {
            ImGuiStyle* dst = null;
            ImGuiNative.igStyleColorsLight(dst);
        }

        /// <summary>
        ///     Styles the colors light using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        public static void StyleColorsLight(ImGuiStylePtr dst)
        {
            ImGuiStyle* nativeDst = dst.NativePtr;
            ImGuiNative.igStyleColorsLight(nativeDst);
        }

        /// <summary>
        ///     Describes whether tab item button
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool TabItemButton(string label)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            ImGuiTabItemFlags flags = 0;
            byte ret = ImGuiNative.igTabItemButton(nativeLabel, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether tab item button
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool TabItemButton(string label, ImGuiTabItemFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte ret = ImGuiNative.igTabItemButton(nativeLabel, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Tables the get column count
        /// </summary>
        /// <returns>The ret</returns>
        public static int TableGetColumnCount()
        {
            int ret = ImGuiNative.igTableGetColumnCount();
            return ret;
        }

        /// <summary>
        ///     Tables the get column flags
        /// </summary>
        /// <returns>The ret</returns>
        public static ImGuiTableColumnFlags TableGetColumnFlags()
        {
            int columnN = -1;
            ImGuiTableColumnFlags ret = ImGuiNative.igTableGetColumnFlags(columnN);
            return ret;
        }

        /// <summary>
        ///     Tables the get column flags using the specified column n
        /// </summary>
        /// <param name="columnN">The column</param>
        /// <returns>The ret</returns>
        public static ImGuiTableColumnFlags TableGetColumnFlags(int columnN)
        {
            ImGuiTableColumnFlags ret = ImGuiNative.igTableGetColumnFlags(columnN);
            return ret;
        }

        /// <summary>
        ///     Tables the get column index
        /// </summary>
        /// <returns>The ret</returns>
        public static int TableGetColumnIndex()
        {
            int ret = ImGuiNative.igTableGetColumnIndex();
            return ret;
        }

        /// <summary>
        ///     Tables the get column name
        /// </summary>
        /// <returns>The string</returns>
        public static string TableGetColumnName()
        {
            int columnN = -1;
            byte* ret = ImGuiNative.igTableGetColumnName_Int(columnN);
            return Util.StringFromPtr(ret);
        }

        /// <summary>
        ///     Tables the get column name using the specified column n
        /// </summary>
        /// <param name="columnN">The column</param>
        /// <returns>The string</returns>
        public static string TableGetColumnName(int columnN)
        {
            byte* ret = ImGuiNative.igTableGetColumnName_Int(columnN);
            return Util.StringFromPtr(ret);
        }

        /// <summary>
        ///     Tables the get row index
        /// </summary>
        /// <returns>The ret</returns>
        public static int TableGetRowIndex()
        {
            int ret = ImGuiNative.igTableGetRowIndex();
            return ret;
        }

        /// <summary>
        ///     Tables the get sort specs
        /// </summary>
        /// <returns>The im gui table sort specs ptr</returns>
        public static ImGuiTableSortSpecsPtr TableGetSortSpecs()
        {
            ImGuiTableSortSpecs* ret = ImGuiNative.igTableGetSortSpecs();
            return new ImGuiTableSortSpecsPtr(ret);
        }

        /// <summary>
        ///     Tables the header using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        public static void TableHeader(string label)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            ImGuiNative.igTableHeader(nativeLabel);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
        }

        /// <summary>
        ///     Tables the headers row
        /// </summary>
        public static void TableHeadersRow()
        {
            ImGuiNative.igTableHeadersRow();
        }

        /// <summary>
        ///     Describes whether table next column
        /// </summary>
        /// <returns>The bool</returns>
        public static bool TableNextColumn()
        {
            byte ret = ImGuiNative.igTableNextColumn();
            return ret != 0;
        }

        /// <summary>
        ///     Tables the next row
        /// </summary>
        public static void TableNextRow()
        {
            ImGuiTableRowFlags rowFlags = 0;
            float minRowHeight = 0.0f;
            ImGuiNative.igTableNextRow(rowFlags, minRowHeight);
        }

        /// <summary>
        ///     Tables the next row using the specified row flags
        /// </summary>
        /// <param name="rowFlags">The row flags</param>
        public static void TableNextRow(ImGuiTableRowFlags rowFlags)
        {
            float minRowHeight = 0.0f;
            ImGuiNative.igTableNextRow(rowFlags, minRowHeight);
        }

        /// <summary>
        ///     Tables the next row using the specified row flags
        /// </summary>
        /// <param name="rowFlags">The row flags</param>
        /// <param name="minRowHeight">The min row height</param>
        public static void TableNextRow(ImGuiTableRowFlags rowFlags, float minRowHeight)
        {
            ImGuiNative.igTableNextRow(rowFlags, minRowHeight);
        }

        /// <summary>
        ///     Tables the set bg color using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="color">The color</param>
        public static void TableSetBgColor(ImGuiTableBgTarget target, uint color)
        {
            int columnN = -1;
            ImGuiNative.igTableSetBgColor(target, color, columnN);
        }

        /// <summary>
        ///     Tables the set bg color using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="color">The color</param>
        /// <param name="columnN">The column</param>
        public static void TableSetBgColor(ImGuiTableBgTarget target, uint color, int columnN)
        {
            ImGuiNative.igTableSetBgColor(target, color, columnN);
        }

        /// <summary>
        ///     Tables the set column enabled using the specified column n
        /// </summary>
        /// <param name="columnN">The column</param>
        /// <param name="v">The </param>
        public static void TableSetColumnEnabled(int columnN, bool v)
        {
            byte nativeV = v ? (byte) 1 : (byte) 0;
            ImGuiNative.igTableSetColumnEnabled(columnN, nativeV);
        }

        /// <summary>
        ///     Describes whether table set column index
        /// </summary>
        /// <param name="columnN">The column</param>
        /// <returns>The bool</returns>
        public static bool TableSetColumnIndex(int columnN)
        {
            byte ret = ImGuiNative.igTableSetColumnIndex(columnN);
            return ret != 0;
        }

        /// <summary>
        ///     Tables the setup column using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        public static void TableSetupColumn(string label)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            ImGuiTableColumnFlags flags = 0;
            float initWidthOrWeight = 0.0f;
            uint userId = 0;
            ImGuiNative.igTableSetupColumn(nativeLabel, flags, initWidthOrWeight, userId);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
        }

        /// <summary>
        ///     Tables the setup column using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        public static void TableSetupColumn(string label, ImGuiTableColumnFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            float initWidthOrWeight = 0.0f;
            uint userId = 0;
            ImGuiNative.igTableSetupColumn(nativeLabel, flags, initWidthOrWeight, userId);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
        }

        /// <summary>
        ///     Tables the setup column using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <param name="initWidthOrWeight">The init width or weight</param>
        public static void TableSetupColumn(string label, ImGuiTableColumnFlags flags, float initWidthOrWeight)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            uint userId = 0;
            ImGuiNative.igTableSetupColumn(nativeLabel, flags, initWidthOrWeight, userId);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            ImGuiNative.igTableSetupColumn(nativeLabel, flags, initWidthOrWeight, userId);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
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
            byte* nativeFmt;
            int fmtByteCount = 0;
            if (fmt != null)
            {
                fmtByteCount = Encoding.UTF8.GetByteCount(fmt);
                if (fmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFmt = Util.Allocate(fmtByteCount + 1);
                }
                else
                {
                    byte* nativeFmtStackBytes = stackalloc byte[fmtByteCount + 1];
                    nativeFmt = nativeFmtStackBytes;
                }

                int nativeFmtOffset = Util.GetUtf8(fmt, nativeFmt, fmtByteCount);
                nativeFmt[nativeFmtOffset] = 0;
            }
            else
            {
                nativeFmt = null;
            }

            ImGuiNative.igText(nativeFmt);
            if (fmtByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFmt);
            }
        }

        /// <summary>
        ///     Texts the colored using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <param name="fmt">The fmt</param>
        public static void TextColored(Vector4F col, string fmt)
        {
            byte* nativeFmt;
            int fmtByteCount = 0;
            if (fmt != null)
            {
                fmtByteCount = Encoding.UTF8.GetByteCount(fmt);
                if (fmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFmt = Util.Allocate(fmtByteCount + 1);
                }
                else
                {
                    byte* nativeFmtStackBytes = stackalloc byte[fmtByteCount + 1];
                    nativeFmt = nativeFmtStackBytes;
                }

                int nativeFmtOffset = Util.GetUtf8(fmt, nativeFmt, fmtByteCount);
                nativeFmt[nativeFmtOffset] = 0;
            }
            else
            {
                nativeFmt = null;
            }

            ImGuiNative.igTextColored(col, nativeFmt);
            if (fmtByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFmt);
            }
        }

        /// <summary>
        ///     Texts the disabled using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        public static void TextDisabled(string fmt)
        {
            byte* nativeFmt;
            int fmtByteCount = 0;
            if (fmt != null)
            {
                fmtByteCount = Encoding.UTF8.GetByteCount(fmt);
                if (fmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFmt = Util.Allocate(fmtByteCount + 1);
                }
                else
                {
                    byte* nativeFmtStackBytes = stackalloc byte[fmtByteCount + 1];
                    nativeFmt = nativeFmtStackBytes;
                }

                int nativeFmtOffset = Util.GetUtf8(fmt, nativeFmt, fmtByteCount);
                nativeFmt[nativeFmtOffset] = 0;
            }
            else
            {
                nativeFmt = null;
            }

            ImGuiNative.igTextDisabled(nativeFmt);
            if (fmtByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFmt);
            }
        }

        /// <summary>
        ///     Texts the unformatted using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        public static void TextUnformatted(string text)
        {
            byte* nativeText;
            int textByteCount = 0;
            if (text != null)
            {
                textByteCount = Encoding.UTF8.GetByteCount(text);
                if (textByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeText = Util.Allocate(textByteCount + 1);
                }
                else
                {
                    byte* nativeTextStackBytes = stackalloc byte[textByteCount + 1];
                    nativeText = nativeTextStackBytes;
                }

                int nativeTextOffset = Util.GetUtf8(text, nativeText, textByteCount);
                nativeText[nativeTextOffset] = 0;
            }
            else
            {
                nativeText = null;
            }

            byte* nativeTextEnd = null;
            ImGuiNative.igTextUnformatted(nativeText, nativeTextEnd);
            if (textByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeText);
            }
        }

        /// <summary>
        ///     Texts the wrapped using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        public static void TextWrapped(string fmt)
        {
            byte* nativeFmt;
            int fmtByteCount = 0;
            if (fmt != null)
            {
                fmtByteCount = Encoding.UTF8.GetByteCount(fmt);
                if (fmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFmt = Util.Allocate(fmtByteCount + 1);
                }
                else
                {
                    byte* nativeFmtStackBytes = stackalloc byte[fmtByteCount + 1];
                    nativeFmt = nativeFmtStackBytes;
                }

                int nativeFmtOffset = Util.GetUtf8(fmt, nativeFmt, fmtByteCount);
                nativeFmt[nativeFmtOffset] = 0;
            }
            else
            {
                nativeFmt = null;
            }

            ImGuiNative.igTextWrapped(nativeFmt);
            if (fmtByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFmt);
            }
        }

        /// <summary>
        ///     Describes whether tree node
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool TreeNode(string label)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte ret = ImGuiNative.igTreeNode_Str(nativeLabel);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

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
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            byte* nativeFmt;
            int fmtByteCount = 0;
            if (fmt != null)
            {
                fmtByteCount = Encoding.UTF8.GetByteCount(fmt);
                if (fmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFmt = Util.Allocate(fmtByteCount + 1);
                }
                else
                {
                    byte* nativeFmtStackBytes = stackalloc byte[fmtByteCount + 1];
                    nativeFmt = nativeFmtStackBytes;
                }

                int nativeFmtOffset = Util.GetUtf8(fmt, nativeFmt, fmtByteCount);
                nativeFmt[nativeFmtOffset] = 0;
            }
            else
            {
                nativeFmt = null;
            }

            byte ret = ImGuiNative.igTreeNode_StrStr(nativeStrId, nativeFmt);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            if (fmtByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFmt);
            }

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
            void* nativePtrId = ptrId.ToPointer();
            byte* nativeFmt;
            int fmtByteCount = 0;
            if (fmt != null)
            {
                fmtByteCount = Encoding.UTF8.GetByteCount(fmt);
                if (fmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFmt = Util.Allocate(fmtByteCount + 1);
                }
                else
                {
                    byte* nativeFmtStackBytes = stackalloc byte[fmtByteCount + 1];
                    nativeFmt = nativeFmtStackBytes;
                }

                int nativeFmtOffset = Util.GetUtf8(fmt, nativeFmt, fmtByteCount);
                nativeFmt[nativeFmtOffset] = 0;
            }
            else
            {
                nativeFmt = null;
            }

            byte ret = ImGuiNative.igTreeNode_Ptr(nativePtrId, nativeFmt);
            if (fmtByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFmt);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether tree node ex
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool TreeNodeEx(string label)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            ImGuiTreeNodeFlags flags = 0;
            byte ret = ImGuiNative.igTreeNodeEx_Str(nativeLabel, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte ret = ImGuiNative.igTreeNodeEx_Str(nativeLabel, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

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
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            byte* nativeFmt;
            int fmtByteCount = 0;
            if (fmt != null)
            {
                fmtByteCount = Encoding.UTF8.GetByteCount(fmt);
                if (fmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFmt = Util.Allocate(fmtByteCount + 1);
                }
                else
                {
                    byte* nativeFmtStackBytes = stackalloc byte[fmtByteCount + 1];
                    nativeFmt = nativeFmtStackBytes;
                }

                int nativeFmtOffset = Util.GetUtf8(fmt, nativeFmt, fmtByteCount);
                nativeFmt[nativeFmtOffset] = 0;
            }
            else
            {
                nativeFmt = null;
            }

            byte ret = ImGuiNative.igTreeNodeEx_StrStr(nativeStrId, flags, nativeFmt);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }

            if (fmtByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFmt);
            }

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
            void* nativePtrId = ptrId.ToPointer();
            byte* nativeFmt;
            int fmtByteCount = 0;
            if (fmt != null)
            {
                fmtByteCount = Encoding.UTF8.GetByteCount(fmt);
                if (fmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFmt = Util.Allocate(fmtByteCount + 1);
                }
                else
                {
                    byte* nativeFmtStackBytes = stackalloc byte[fmtByteCount + 1];
                    nativeFmt = nativeFmtStackBytes;
                }

                int nativeFmtOffset = Util.GetUtf8(fmt, nativeFmt, fmtByteCount);
                nativeFmt[nativeFmtOffset] = 0;
            }
            else
            {
                nativeFmt = null;
            }

            byte ret = ImGuiNative.igTreeNodeEx_Ptr(nativePtrId, flags, nativeFmt);
            if (fmtByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFmt);
            }

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
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }

                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }

            ImGuiNative.igTreePush_Str(nativeStrId);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }
        }

        /// <summary>
        ///     Trees the push using the specified ptr id
        /// </summary>
        /// <param name="ptrId">The ptr id</param>
        public static void TreePush(IntPtr ptrId)
        {
            void* nativePtrId = ptrId.ToPointer();
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
            byte* nativePrefix;
            int prefixByteCount = 0;
            if (prefix != null)
            {
                prefixByteCount = Encoding.UTF8.GetByteCount(prefix);
                if (prefixByteCount > Util.StackAllocationSizeLimit)
                {
                    nativePrefix = Util.Allocate(prefixByteCount + 1);
                }
                else
                {
                    byte* nativePrefixStackBytes = stackalloc byte[prefixByteCount + 1];
                    nativePrefix = nativePrefixStackBytes;
                }

                int nativePrefixOffset = Util.GetUtf8(prefix, nativePrefix, prefixByteCount);
                nativePrefix[nativePrefixOffset] = 0;
            }
            else
            {
                nativePrefix = null;
            }

            byte nativeB = b ? (byte) 1 : (byte) 0;
            ImGuiNative.igValue_Bool(nativePrefix, nativeB);
            if (prefixByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativePrefix);
            }
        }

        /// <summary>
        ///     Values the prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="v">The </param>
        public static void Value(string prefix, int v)
        {
            byte* nativePrefix;
            int prefixByteCount = 0;
            if (prefix != null)
            {
                prefixByteCount = Encoding.UTF8.GetByteCount(prefix);
                if (prefixByteCount > Util.StackAllocationSizeLimit)
                {
                    nativePrefix = Util.Allocate(prefixByteCount + 1);
                }
                else
                {
                    byte* nativePrefixStackBytes = stackalloc byte[prefixByteCount + 1];
                    nativePrefix = nativePrefixStackBytes;
                }

                int nativePrefixOffset = Util.GetUtf8(prefix, nativePrefix, prefixByteCount);
                nativePrefix[nativePrefixOffset] = 0;
            }
            else
            {
                nativePrefix = null;
            }

            ImGuiNative.igValue_Int(nativePrefix, v);
            if (prefixByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativePrefix);
            }
        }

        /// <summary>
        ///     Values the prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="v">The </param>
        public static void Value(string prefix, uint v)
        {
            byte* nativePrefix;
            int prefixByteCount = 0;
            if (prefix != null)
            {
                prefixByteCount = Encoding.UTF8.GetByteCount(prefix);
                if (prefixByteCount > Util.StackAllocationSizeLimit)
                {
                    nativePrefix = Util.Allocate(prefixByteCount + 1);
                }
                else
                {
                    byte* nativePrefixStackBytes = stackalloc byte[prefixByteCount + 1];
                    nativePrefix = nativePrefixStackBytes;
                }

                int nativePrefixOffset = Util.GetUtf8(prefix, nativePrefix, prefixByteCount);
                nativePrefix[nativePrefixOffset] = 0;
            }
            else
            {
                nativePrefix = null;
            }

            ImGuiNative.igValue_Uint(nativePrefix, v);
            if (prefixByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativePrefix);
            }
        }

        /// <summary>
        ///     Values the prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="v">The </param>
        public static void Value(string prefix, float v)
        {
            byte* nativePrefix;
            int prefixByteCount = 0;
            if (prefix != null)
            {
                prefixByteCount = Encoding.UTF8.GetByteCount(prefix);
                if (prefixByteCount > Util.StackAllocationSizeLimit)
                {
                    nativePrefix = Util.Allocate(prefixByteCount + 1);
                }
                else
                {
                    byte* nativePrefixStackBytes = stackalloc byte[prefixByteCount + 1];
                    nativePrefix = nativePrefixStackBytes;
                }

                int nativePrefixOffset = Util.GetUtf8(prefix, nativePrefix, prefixByteCount);
                nativePrefix[nativePrefixOffset] = 0;
            }
            else
            {
                nativePrefix = null;
            }

            byte* nativeFloatFormat = null;
            ImGuiNative.igValue_Float(nativePrefix, v, nativeFloatFormat);
            if (prefixByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativePrefix);
            }
        }

        /// <summary>
        ///     Values the prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="v">The </param>
        /// <param name="floatFormat">The float format</param>
        public static void Value(string prefix, float v, string floatFormat)
        {
            byte* nativePrefix;
            int prefixByteCount = 0;
            if (prefix != null)
            {
                prefixByteCount = Encoding.UTF8.GetByteCount(prefix);
                if (prefixByteCount > Util.StackAllocationSizeLimit)
                {
                    nativePrefix = Util.Allocate(prefixByteCount + 1);
                }
                else
                {
                    byte* nativePrefixStackBytes = stackalloc byte[prefixByteCount + 1];
                    nativePrefix = nativePrefixStackBytes;
                }

                int nativePrefixOffset = Util.GetUtf8(prefix, nativePrefix, prefixByteCount);
                nativePrefix[nativePrefixOffset] = 0;
            }
            else
            {
                nativePrefix = null;
            }

            byte* nativeFloatFormat;
            int floatFormatByteCount = 0;
            if (floatFormat != null)
            {
                floatFormatByteCount = Encoding.UTF8.GetByteCount(floatFormat);
                if (floatFormatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFloatFormat = Util.Allocate(floatFormatByteCount + 1);
                }
                else
                {
                    byte* nativeFloatFormatStackBytes = stackalloc byte[floatFormatByteCount + 1];
                    nativeFloatFormat = nativeFloatFormatStackBytes;
                }

                int nativeFloatFormatOffset = Util.GetUtf8(floatFormat, nativeFloatFormat, floatFormatByteCount);
                nativeFloatFormat[nativeFloatFormatOffset] = 0;
            }
            else
            {
                nativeFloatFormat = null;
            }

            ImGuiNative.igValue_Float(nativePrefix, v, nativeFloatFormat);
            if (prefixByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativePrefix);
            }

            if (floatFormatByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFloatFormat);
            }
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
        public static bool VSliderFloat(string label, Vector2F size, ref float v, float vMin, float vMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (float* nativeV = &v)
            {
                byte ret = ImGuiNative.igVSliderFloat(nativeLabel, size, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
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
        public static bool VSliderFloat(string label, Vector2F size, ref float v, float vMin, float vMax, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiSliderFlags flags = 0;
            fixed (float* nativeV = &v)
            {
                byte ret = ImGuiNative.igVSliderFloat(nativeLabel, size, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
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
        public static bool VSliderFloat(string label, Vector2F size, ref float v, float vMin, float vMax, string format, ImGuiSliderFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            fixed (float* nativeV = &v)
            {
                byte ret = ImGuiNative.igVSliderFloat(nativeLabel, size, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
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
        public static bool VSliderInt(string label, Vector2F size, ref int v, int vMin, int vMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }

            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igVSliderInt(nativeLabel, size, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
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
        public static bool VSliderInt(string label, Vector2F size, ref int v, int vMin, int vMax, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igVSliderInt(nativeLabel, size, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
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
        public static bool VSliderInt(string label, Vector2F size, ref int v, int vMin, int vMax, string format, ImGuiSliderFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igVSliderInt(nativeLabel, size, nativeV, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }

                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }

                return ret != 0;
            }
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
        public static bool VSliderScalar(string label, Vector2F size, ImGuiDataType dataType, IntPtr pData, IntPtr pMin, IntPtr pMax)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* nativePMin = pMin.ToPointer();
            void* nativePMax = pMax.ToPointer();
            byte* nativeFormat = null;
            ImGuiSliderFlags flags = 0;
            byte ret = ImGuiNative.igVSliderScalar(nativeLabel, size, dataType, nativePData, nativePMin, nativePMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

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
        public static bool VSliderScalar(string label, Vector2F size, ImGuiDataType dataType, IntPtr pData, IntPtr pMin, IntPtr pMax, string format)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* nativePMin = pMin.ToPointer();
            void* nativePMax = pMax.ToPointer();
            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            ImGuiSliderFlags flags = 0;
            byte ret = ImGuiNative.igVSliderScalar(nativeLabel, size, dataType, nativePData, nativePMin, nativePMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFormat);
            }

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
        public static bool VSliderScalar(string label, Vector2F size, ImGuiDataType dataType, IntPtr pData, IntPtr pMin, IntPtr pMax, string format, ImGuiSliderFlags flags)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            void* nativePData = pData.ToPointer();
            void* nativePMin = pMin.ToPointer();
            void* nativePMax = pMax.ToPointer();
            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }

                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }

            byte ret = ImGuiNative.igVSliderScalar(nativeLabel, size, dataType, nativePData, nativePMin, nativePMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFormat);
            }

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
            int utf8LabelByteCount = Encoding.UTF8.GetByteCount(label);
            byte* utf8LabelBytes;
            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                utf8LabelBytes = Util.Allocate(utf8LabelByteCount + 1);
            }
            else
            {
                byte* stackPtr = stackalloc byte[utf8LabelByteCount + 1];
                utf8LabelBytes = stackPtr;
            }

            Util.GetUtf8(label, utf8LabelBytes, utf8LabelByteCount);

            bool ret;
            fixed (byte* bufPtr = buf)
            {
                ret = ImGuiNative.igInputText(utf8LabelBytes, bufPtr, bufSize, flags, callback, userData.ToPointer()) != 0;
            }

            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8LabelBytes);
            }

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
        /// <param name="flags">The flags.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="userData">The user data.</param>
        /// <returns><c>true</c> if the input text; otherwise, <c>false</c>.</returns>
        public static bool InputText(
            string label,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback,
            IntPtr userData)
        {
            // Convert label and input to ANSI strings
            IntPtr labelPtr = Marshal.StringToHGlobalAnsi(label);
            IntPtr inputPtr = Marshal.StringToHGlobalAnsi(input);

            // Convert ANSI strings to UTF-8 bytes
            byte* utf8LabelBytes = (byte*) labelPtr.ToPointer();
            byte* utf8InputBytes = (byte*) inputPtr.ToPointer();

            // Create buffers for modified input
            int inputBufSize = Math.Max((int) maxLength + 1, Encoding.UTF8.GetByteCount(input) + 1);
            byte* modifiedUtf8InputBytes = stackalloc byte[inputBufSize];
            byte* originalUtf8InputBytes = stackalloc byte[inputBufSize];

            // Copy input bytes to the modified input buffer
            Unsafe.CopyBlock(modifiedUtf8InputBytes, utf8InputBytes, (uint) inputBufSize);

            // Call the ImGuiNative method
            byte result = ImGuiNative.igInputText(
                utf8LabelBytes,
                modifiedUtf8InputBytes,
                (uint) inputBufSize,
                flags,
                callback,
                userData.ToPointer());

            // Check if the input was modified and update the input variable accordingly
            if (!Util.AreStringsEqual(originalUtf8InputBytes, inputBufSize, modifiedUtf8InputBytes))
            {
                input = Encoding.UTF8.GetString(modifiedUtf8InputBytes, inputBufSize);
            }

            // Free the memory allocated by Marshal.StringToHGlobalAnsi
            Marshal.FreeHGlobal(labelPtr);
            Marshal.FreeHGlobal(inputPtr);

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
            Vector2F size) => InputTextMultiline(label, ref input, maxLength, size, 0, null, IntPtr.Zero);

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
            Vector2F size,
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
            Vector2F size,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback) => InputTextMultiline(label, ref input, maxLength, size, flags, callback, IntPtr.Zero);

        /// <summary>
        ///     Determines whether the input text is multiline.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="input">The input.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <param name="size">The size.</param>
        /// <param name="flags">The flags.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="userData">The user data.</param>
        /// <returns><c>true</c> if the input text is multiline; otherwise, <c>false</c>.</returns>
        public static bool InputTextMultiline(
            string label,
            ref string input,
            uint maxLength,
            Vector2F size,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback,
            IntPtr userData)
        {
            // Convert label and input to ANSI strings
            IntPtr labelPtr = Marshal.StringToHGlobalAnsi(label);
            IntPtr inputPtr = Marshal.StringToHGlobalAnsi(input);

            // Convert ANSI strings to UTF-8 bytes
            byte* utf8LabelBytes = (byte*) labelPtr.ToPointer();
            byte* utf8InputBytes = (byte*) inputPtr.ToPointer();

            // Create buffers for modified input
            int inputBufSize = Math.Max((int) maxLength + 1, Encoding.UTF8.GetByteCount(input) + 1);
            byte* modifiedUtf8InputBytes = stackalloc byte[inputBufSize];
            byte* originalUtf8InputBytes = stackalloc byte[inputBufSize];

            // Copy input bytes to the modified input buffer
            Unsafe.CopyBlock(modifiedUtf8InputBytes, utf8InputBytes, (uint) inputBufSize);

            // Call the ImGuiNative method
            byte result = ImGuiNative.igInputTextMultiline(
                utf8LabelBytes,
                modifiedUtf8InputBytes,
                (uint) inputBufSize,
                size,
                flags,
                callback,
                userData.ToPointer());

            // Check if the input was modified and update the input variable accordingly
            if (!Util.AreStringsEqual(originalUtf8InputBytes, inputBufSize, modifiedUtf8InputBytes))
            {
                input = Encoding.UTF8.GetString(modifiedUtf8InputBytes, inputBufSize);
            }

            // Free the memory allocated by Marshal.StringToHGlobalAnsi
            Marshal.FreeHGlobal(labelPtr);
            Marshal.FreeHGlobal(inputPtr);

            return result != 0;
        }


        /// <summary>
        ///     Describes whether are byte arrays equal
        /// </summary>
        /// <param name="array1">The array</param>
        /// <param name="array2">The array</param>
        /// <returns>The bool</returns>
        public static bool AreByteArraysEqual(byte[] array1, byte[] array2)
        {
            if ((array1 == null) && (array2 == null))
            {
                return true;
            }

            if (array1 == null || array2 == null || array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
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
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <param name="userData">The user data</param>
        /// <returns>The bool</returns>
        public static bool InputTextWithHint(
            string label,
            string hint,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback,
            IntPtr userData)
        {
            byte* utf8LabelBytes = GetUtf8Bytes(label);
            byte* utf8HintBytes = GetUtf8Bytes(hint);
            byte* utf8InputBytes = GetUtf8Bytes(input, maxLength);

            byte result = ImGuiNative.igInputTextWithHint(
                utf8LabelBytes,
                utf8HintBytes,
                utf8InputBytes,
                maxLength + 1,
                flags,
                callback,
                userData.ToPointer());

            bool hasInputChanged = !AreUtf8StringsEqual(utf8InputBytes, input);
            if (hasInputChanged)
            {
                input = GetStringFromUtf8(utf8InputBytes);
            }

            FreeUtf8Bytes(utf8LabelBytes);
            FreeUtf8Bytes(utf8HintBytes);
            FreeUtf8Bytes(utf8InputBytes);

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
        public static Vector2F CalcTextSize(string text)
            => CalcTextSizeImpl(text);

        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <returns>The vector</returns>
        public static Vector2F CalcTextSize(string text, int start)
            => CalcTextSizeImpl(text, start);

        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The vector</returns>
        public static Vector2F CalcTextSize(string text, float wrapWidth)
            => CalcTextSizeImpl(text, wrapWidth: wrapWidth);

        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <returns>The vector</returns>
        public static Vector2F CalcTextSize(string text, bool hideTextAfterDoubleHash)
            => CalcTextSizeImpl(text, hideTextAfterDoubleHash: hideTextAfterDoubleHash);

        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        /// <returns>The vector</returns>
        public static Vector2F CalcTextSize(string text, int start, int length)
            => CalcTextSizeImpl(text, start, length);

        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <returns>The vector</returns>
        public static Vector2F CalcTextSize(string text, int start, bool hideTextAfterDoubleHash)
            => CalcTextSizeImpl(text, start, hideTextAfterDoubleHash: hideTextAfterDoubleHash);

        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The vector</returns>
        public static Vector2F CalcTextSize(string text, int start, float wrapWidth)
            => CalcTextSizeImpl(text, start, wrapWidth: wrapWidth);

        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The vector</returns>
        public static Vector2F CalcTextSize(string text, bool hideTextAfterDoubleHash, float wrapWidth)
            => CalcTextSizeImpl(text, hideTextAfterDoubleHash: hideTextAfterDoubleHash, wrapWidth: wrapWidth);

        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <returns>The vector</returns>
        public static Vector2F CalcTextSize(string text, int start, int length, bool hideTextAfterDoubleHash)
            => CalcTextSizeImpl(text, start, length, hideTextAfterDoubleHash);

        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The vector</returns>
        public static Vector2F CalcTextSize(string text, int start, int length, float wrapWidth)
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
        public static Vector2F CalcTextSize(string text, int start, int length, bool hideTextAfterDoubleHash, float wrapWidth)
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
        private static Vector2F CalcTextSizeImpl(
            string text,
            int start = 0,
            int? length = null,
            bool hideTextAfterDoubleHash = false,
            float wrapWidth = -1.0f)
        {
            Vector2F ret;
            byte* nativeTextStart = null;
            byte* nativeTextEnd = null;
            int textByteCount = 0;
            if (text != null)
            {
                int textToCopyLen = length.HasValue ? length.Value : text.Length;
                textByteCount = Util.CalcSizeInUtf8(text, start, textToCopyLen);
                if (textByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeTextStart = Util.Allocate(textByteCount + 1);
                }
                else
                {
                    byte* nativeTextStackBytes = stackalloc byte[textByteCount + 1];
                    nativeTextStart = nativeTextStackBytes;
                }

                int nativeTextOffset = Util.GetUtf8(text, start, textToCopyLen, nativeTextStart, textByteCount);
                nativeTextStart[nativeTextOffset] = 0;
                nativeTextEnd = nativeTextStart + nativeTextOffset;
            }

            ImGuiNative.igCalcTextSize(&ret, nativeTextStart, nativeTextEnd, *(byte*) &hideTextAfterDoubleHash, wrapWidth);
            if (textByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeTextStart);
            }

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
            int utf8LabelByteCount = Encoding.UTF8.GetByteCount(label);
            byte* utf8LabelBytes;
            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                utf8LabelBytes = Util.Allocate(utf8LabelByteCount + 1);
            }
            else
            {
                byte* stackPtr = stackalloc byte[utf8LabelByteCount + 1];
                utf8LabelBytes = stackPtr;
            }

            Util.GetUtf8(label, utf8LabelBytes, utf8LabelByteCount);

            bool ret = ImGuiNative.igInputText(utf8LabelBytes, (byte*) buf.ToPointer(), bufSize, flags, callback, userData.ToPointer()) != 0;

            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8LabelBytes);
            }

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
            int utf8NameByteCount = Encoding.UTF8.GetByteCount(name);
            byte* utf8NameBytes;
            if (utf8NameByteCount > Util.StackAllocationSizeLimit)
            {
                utf8NameBytes = Util.Allocate(utf8NameByteCount + 1);
            }
            else
            {
                byte* stackPtr = stackalloc byte[utf8NameByteCount + 1];
                utf8NameBytes = stackPtr;
            }

            Util.GetUtf8(name, utf8NameBytes, utf8NameByteCount);

            byte* pOpen = null;
            byte ret = ImGuiNative.igBegin(utf8NameBytes, pOpen, flags);

            if (utf8NameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8NameBytes);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether menu item
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The bool</returns>
        public static bool MenuItem(string label, bool enabled) => MenuItem(label, string.Empty, false, enabled);
    }
}