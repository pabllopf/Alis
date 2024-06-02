// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP1.cs
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

namespace Alis.Extension.Graphic.ImGui.Extras.Plot.Native
{
    /// <summary>
    /// The im plot class
    /// </summary>
    public static unsafe partial class ImPlot
    {
        /// <summary>
        ///     Adds the colormap using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="cols">The cols</param>
        /// <param name="size">The size</param>
        /// <returns>The im plot colormap</returns>
        public static ImPlotColormap AddColormap(string name, ref Vector4 cols, int size)
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
            
            byte qual = 1;
            fixed (Vector4* nativeCols = &cols)
            {
                ImPlotColormap ret = ImPlotNative.ImPlot_AddColormap_Vec4Ptr(nativeName, nativeCols, size, qual);
                if (nameByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeName);
                }
                
                return ret;
            }
        }
        
        /// <summary>
        ///     Adds the colormap using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="cols">The cols</param>
        /// <param name="size">The size</param>
        /// <param name="qual">The qual</param>
        /// <returns>The im plot colormap</returns>
        public static ImPlotColormap AddColormap(string name, ref Vector4 cols, int size, bool qual)
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
            
            byte nativeQual = qual ? (byte) 1 : (byte) 0;
            fixed (Vector4* nativeCols = &cols)
            {
                ImPlotColormap ret = ImPlotNative.ImPlot_AddColormap_Vec4Ptr(nativeName, nativeCols, size, nativeQual);
                if (nameByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeName);
                }
                
                return ret;
            }
        }
        
        /// <summary>
        ///     Adds the colormap using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="cols">The cols</param>
        /// <param name="size">The size</param>
        /// <returns>The im plot colormap</returns>
        public static ImPlotColormap AddColormap(string name, ref uint cols, int size)
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
            
            byte qual = 1;
            fixed (uint* nativeCols = &cols)
            {
                ImPlotColormap ret = ImPlotNative.ImPlot_AddColormap_U32Ptr(nativeName, nativeCols, size, qual);
                if (nameByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeName);
                }
                
                return ret;
            }
        }
        
        /// <summary>
        ///     Adds the colormap using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="cols">The cols</param>
        /// <param name="size">The size</param>
        /// <param name="qual">The qual</param>
        /// <returns>The im plot colormap</returns>
        public static ImPlotColormap AddColormap(string name, ref uint cols, int size, bool qual)
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
            
            byte nativeQual = qual ? (byte) 1 : (byte) 0;
            fixed (uint* nativeCols = &cols)
            {
                ImPlotColormap ret = ImPlotNative.ImPlot_AddColormap_U32Ptr(nativeName, nativeCols, size, nativeQual);
                if (nameByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeName);
                }
                
                return ret;
            }
        }
        
        /// <summary>
        ///     Annotations the x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        /// <param name="pixOffset">The pix offset</param>
        /// <param name="clamp">The clamp</param>
        public static void Annotation(double x, double y, Vector4 col, Vector2 pixOffset, bool clamp)
        {
            byte nativeClamp = clamp ? (byte) 1 : (byte) 0;
            byte round = 0;
            ImPlotNative.ImPlot_Annotation_Bool(x, y, col, pixOffset, nativeClamp, round);
        }
        
        /// <summary>
        ///     Annotations the x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        /// <param name="pixOffset">The pix offset</param>
        /// <param name="clamp">The clamp</param>
        /// <param name="round">The round</param>
        public static void Annotation(double x, double y, Vector4 col, Vector2 pixOffset, bool clamp, bool round)
        {
            byte nativeClamp = clamp ? (byte) 1 : (byte) 0;
            byte nativeRound = round ? (byte) 1 : (byte) 0;
            ImPlotNative.ImPlot_Annotation_Bool(x, y, col, pixOffset, nativeClamp, nativeRound);
        }
        
        /// <summary>
        ///     Annotations the x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        /// <param name="pixOffset">The pix offset</param>
        /// <param name="clamp">The clamp</param>
        /// <param name="fmt">The fmt</param>
        public static void Annotation(double x, double y, Vector4 col, Vector2 pixOffset, bool clamp, string fmt)
        {
            byte nativeClamp = clamp ? (byte) 1 : (byte) 0;
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
            
            ImPlotNative.ImPlot_Annotation_Str(x, y, col, pixOffset, nativeClamp, nativeFmt);
            if (fmtByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFmt);
            }
        }
        
        /// <summary>
        ///     Describes whether begin aligned plots
        /// </summary>
        /// <param name="groupId">The group id</param>
        /// <returns>The bool</returns>
        public static bool BeginAlignedPlots(string groupId)
        {
            byte* nativeGroupId;
            int groupIdByteCount = 0;
            if (groupId != null)
            {
                groupIdByteCount = Encoding.UTF8.GetByteCount(groupId);
                if (groupIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeGroupId = Util.Allocate(groupIdByteCount + 1);
                }
                else
                {
                    byte* nativeGroupIdStackBytes = stackalloc byte[groupIdByteCount + 1];
                    nativeGroupId = nativeGroupIdStackBytes;
                }
                
                int nativeGroupIdOffset = Util.GetUtf8(groupId, nativeGroupId, groupIdByteCount);
                nativeGroupId[nativeGroupIdOffset] = 0;
            }
            else
            {
                nativeGroupId = null;
            }
            
            byte vertical = 1;
            byte ret = ImPlotNative.ImPlot_BeginAlignedPlots(nativeGroupId, vertical);
            if (groupIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeGroupId);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin aligned plots
        /// </summary>
        /// <param name="groupId">The group id</param>
        /// <param name="vertical">The vertical</param>
        /// <returns>The bool</returns>
        public static bool BeginAlignedPlots(string groupId, bool vertical)
        {
            byte* nativeGroupId;
            int groupIdByteCount = 0;
            if (groupId != null)
            {
                groupIdByteCount = Encoding.UTF8.GetByteCount(groupId);
                if (groupIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeGroupId = Util.Allocate(groupIdByteCount + 1);
                }
                else
                {
                    byte* nativeGroupIdStackBytes = stackalloc byte[groupIdByteCount + 1];
                    nativeGroupId = nativeGroupIdStackBytes;
                }
                
                int nativeGroupIdOffset = Util.GetUtf8(groupId, nativeGroupId, groupIdByteCount);
                nativeGroupId[nativeGroupIdOffset] = 0;
            }
            else
            {
                nativeGroupId = null;
            }
            
            byte nativeVertical = vertical ? (byte) 1 : (byte) 0;
            byte ret = ImPlotNative.ImPlot_BeginAlignedPlots(nativeGroupId, nativeVertical);
            if (groupIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeGroupId);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin drag drop source axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <returns>The bool</returns>
        public static bool BeginDragDropSourceAxis(ImAxis axis)
        {
            ImGuiDragDropFlags flags = 0;
            byte ret = ImPlotNative.ImPlot_BeginDragDropSourceAxis(axis, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin drag drop source axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginDragDropSourceAxis(ImAxis axis, ImGuiDragDropFlags flags)
        {
            byte ret = ImPlotNative.ImPlot_BeginDragDropSourceAxis(axis, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin drag drop source item
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <returns>The bool</returns>
        public static bool BeginDragDropSourceItem(string labelId)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImGuiDragDropFlags flags = 0;
            byte ret = ImPlotNative.ImPlot_BeginDragDropSourceItem(nativeLabelId, flags);
            if (labelIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabelId);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin drag drop source item
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginDragDropSourceItem(string labelId, ImGuiDragDropFlags flags)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            byte ret = ImPlotNative.ImPlot_BeginDragDropSourceItem(nativeLabelId, flags);
            if (labelIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabelId);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin drag drop source plot
        /// </summary>
        /// <returns>The bool</returns>
        public static bool BeginDragDropSourcePlot()
        {
            ImGuiDragDropFlags flags = 0;
            byte ret = ImPlotNative.ImPlot_BeginDragDropSourcePlot(flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin drag drop source plot
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginDragDropSourcePlot(ImGuiDragDropFlags flags)
        {
            byte ret = ImPlotNative.ImPlot_BeginDragDropSourcePlot(flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin drag drop target axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <returns>The bool</returns>
        public static bool BeginDragDropTargetAxis(ImAxis axis)
        {
            byte ret = ImPlotNative.ImPlot_BeginDragDropTargetAxis(axis);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin drag drop target legend
        /// </summary>
        /// <returns>The bool</returns>
        public static bool BeginDragDropTargetLegend()
        {
            byte ret = ImPlotNative.ImPlot_BeginDragDropTargetLegend();
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin drag drop target plot
        /// </summary>
        /// <returns>The bool</returns>
        public static bool BeginDragDropTargetPlot()
        {
            byte ret = ImPlotNative.ImPlot_BeginDragDropTargetPlot();
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin legend popup
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <returns>The bool</returns>
        public static bool BeginLegendPopup(string labelId)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImGuiMouseButton mouseButton = (ImGuiMouseButton) 1;
            byte ret = ImPlotNative.ImPlot_BeginLegendPopup(nativeLabelId, mouseButton);
            if (labelIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabelId);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin legend popup
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="mouseButton">The mouse button</param>
        /// <returns>The bool</returns>
        public static bool BeginLegendPopup(string labelId, ImGuiMouseButton mouseButton)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            byte ret = ImPlotNative.ImPlot_BeginLegendPopup(nativeLabelId, mouseButton);
            if (labelIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabelId);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin plot
        /// </summary>
        /// <param name="titleId">The title id</param>
        /// <returns>The bool</returns>
        public static bool BeginPlot(string titleId)
        {
            byte* nativeTitleId;
            int titleIdByteCount = 0;
            if (titleId != null)
            {
                titleIdByteCount = Encoding.UTF8.GetByteCount(titleId);
                if (titleIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeTitleId = Util.Allocate(titleIdByteCount + 1);
                }
                else
                {
                    byte* nativeTitleIdStackBytes = stackalloc byte[titleIdByteCount + 1];
                    nativeTitleId = nativeTitleIdStackBytes;
                }
                
                int nativeTitleIdOffset = Util.GetUtf8(titleId, nativeTitleId, titleIdByteCount);
                nativeTitleId[nativeTitleIdOffset] = 0;
            }
            else
            {
                nativeTitleId = null;
            }
            
            Vector2 size = new Vector2(-1, 0);
            ImPlotFlags flags = 0;
            byte ret = ImPlotNative.ImPlot_BeginPlot(nativeTitleId, size, flags);
            if (titleIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeTitleId);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin plot
        /// </summary>
        /// <param name="titleId">The title id</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool BeginPlot(string titleId, Vector2 size)
        {
            byte* nativeTitleId;
            int titleIdByteCount = 0;
            if (titleId != null)
            {
                titleIdByteCount = Encoding.UTF8.GetByteCount(titleId);
                if (titleIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeTitleId = Util.Allocate(titleIdByteCount + 1);
                }
                else
                {
                    byte* nativeTitleIdStackBytes = stackalloc byte[titleIdByteCount + 1];
                    nativeTitleId = nativeTitleIdStackBytes;
                }
                
                int nativeTitleIdOffset = Util.GetUtf8(titleId, nativeTitleId, titleIdByteCount);
                nativeTitleId[nativeTitleIdOffset] = 0;
            }
            else
            {
                nativeTitleId = null;
            }
            
            ImPlotFlags flags = 0;
            byte ret = ImPlotNative.ImPlot_BeginPlot(nativeTitleId, size, flags);
            if (titleIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeTitleId);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin plot
        /// </summary>
        /// <param name="titleId">The title id</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginPlot(string titleId, Vector2 size, ImPlotFlags flags)
        {
            byte* nativeTitleId;
            int titleIdByteCount = 0;
            if (titleId != null)
            {
                titleIdByteCount = Encoding.UTF8.GetByteCount(titleId);
                if (titleIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeTitleId = Util.Allocate(titleIdByteCount + 1);
                }
                else
                {
                    byte* nativeTitleIdStackBytes = stackalloc byte[titleIdByteCount + 1];
                    nativeTitleId = nativeTitleIdStackBytes;
                }
                
                int nativeTitleIdOffset = Util.GetUtf8(titleId, nativeTitleId, titleIdByteCount);
                nativeTitleId[nativeTitleIdOffset] = 0;
            }
            else
            {
                nativeTitleId = null;
            }
            
            byte ret = ImPlotNative.ImPlot_BeginPlot(nativeTitleId, size, flags);
            if (titleIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeTitleId);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin subplots
        /// </summary>
        /// <param name="titleId">The title id</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool BeginSubplots(string titleId, int rows, int cols, Vector2 size)
        {
            byte* nativeTitleId;
            int titleIdByteCount = 0;
            if (titleId != null)
            {
                titleIdByteCount = Encoding.UTF8.GetByteCount(titleId);
                if (titleIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeTitleId = Util.Allocate(titleIdByteCount + 1);
                }
                else
                {
                    byte* nativeTitleIdStackBytes = stackalloc byte[titleIdByteCount + 1];
                    nativeTitleId = nativeTitleIdStackBytes;
                }
                
                int nativeTitleIdOffset = Util.GetUtf8(titleId, nativeTitleId, titleIdByteCount);
                nativeTitleId[nativeTitleIdOffset] = 0;
            }
            else
            {
                nativeTitleId = null;
            }
            
            ImPlotSubplotFlags flags = 0;
            float* rowRatios = null;
            float* colRatios = null;
            byte ret = ImPlotNative.ImPlot_BeginSubplots(nativeTitleId, rows, cols, size, flags, rowRatios, colRatios);
            if (titleIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeTitleId);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin subplots
        /// </summary>
        /// <param name="titleId">The title id</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginSubplots(string titleId, int rows, int cols, Vector2 size, ImPlotSubplotFlags flags)
        {
            byte* nativeTitleId;
            int titleIdByteCount = 0;
            if (titleId != null)
            {
                titleIdByteCount = Encoding.UTF8.GetByteCount(titleId);
                if (titleIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeTitleId = Util.Allocate(titleIdByteCount + 1);
                }
                else
                {
                    byte* nativeTitleIdStackBytes = stackalloc byte[titleIdByteCount + 1];
                    nativeTitleId = nativeTitleIdStackBytes;
                }
                
                int nativeTitleIdOffset = Util.GetUtf8(titleId, nativeTitleId, titleIdByteCount);
                nativeTitleId[nativeTitleIdOffset] = 0;
            }
            else
            {
                nativeTitleId = null;
            }
            
            float* rowRatios = null;
            float* colRatios = null;
            byte ret = ImPlotNative.ImPlot_BeginSubplots(nativeTitleId, rows, cols, size, flags, rowRatios, colRatios);
            if (titleIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeTitleId);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin subplots
        /// </summary>
        /// <param name="titleId">The title id</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <param name="rowRatios">The row ratios</param>
        /// <returns>The bool</returns>
        public static bool BeginSubplots(string titleId, int rows, int cols, Vector2 size, ImPlotSubplotFlags flags, ref float rowRatios)
        {
            byte* nativeTitleId;
            int titleIdByteCount = 0;
            if (titleId != null)
            {
                titleIdByteCount = Encoding.UTF8.GetByteCount(titleId);
                if (titleIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeTitleId = Util.Allocate(titleIdByteCount + 1);
                }
                else
                {
                    byte* nativeTitleIdStackBytes = stackalloc byte[titleIdByteCount + 1];
                    nativeTitleId = nativeTitleIdStackBytes;
                }
                
                int nativeTitleIdOffset = Util.GetUtf8(titleId, nativeTitleId, titleIdByteCount);
                nativeTitleId[nativeTitleIdOffset] = 0;
            }
            else
            {
                nativeTitleId = null;
            }
            
            float* colRatios = null;
            fixed (float* nativeRowRatios = &rowRatios)
            {
                byte ret = ImPlotNative.ImPlot_BeginSubplots(nativeTitleId, rows, cols, size, flags, nativeRowRatios, colRatios);
                if (titleIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeTitleId);
                }
                
                return ret != 0;
            }
        }
        
        /// <summary>
        ///     Describes whether begin subplots
        /// </summary>
        /// <param name="titleId">The title id</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <param name="rowRatios">The row ratios</param>
        /// <param name="colRatios">The col ratios</param>
        /// <returns>The bool</returns>
        public static bool BeginSubplots(string titleId, int rows, int cols, Vector2 size, ImPlotSubplotFlags flags, ref float rowRatios, ref float colRatios)
        {
            byte* nativeTitleId;
            int titleIdByteCount = 0;
            if (titleId != null)
            {
                titleIdByteCount = Encoding.UTF8.GetByteCount(titleId);
                if (titleIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeTitleId = Util.Allocate(titleIdByteCount + 1);
                }
                else
                {
                    byte* nativeTitleIdStackBytes = stackalloc byte[titleIdByteCount + 1];
                    nativeTitleId = nativeTitleIdStackBytes;
                }
                
                int nativeTitleIdOffset = Util.GetUtf8(titleId, nativeTitleId, titleIdByteCount);
                nativeTitleId[nativeTitleIdOffset] = 0;
            }
            else
            {
                nativeTitleId = null;
            }
            
            fixed (float* nativeRowRatios = &rowRatios)
            {
                fixed (float* nativeColRatios = &colRatios)
                {
                    byte ret = ImPlotNative.ImPlot_BeginSubplots(nativeTitleId, rows, cols, size, flags, nativeRowRatios, nativeColRatios);
                    if (titleIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeTitleId);
                    }
                    
                    return ret != 0;
                }
            }
        }
        
        /// <summary>
        ///     Busts the color cache
        /// </summary>
        public static void BustColorCache()
        {
            byte* nativePlotTitleId = null;
            ImPlotNative.ImPlot_BustColorCache(nativePlotTitleId);
        }
        
        /// <summary>
        ///     Busts the color cache using the specified plot title id
        /// </summary>
        /// <param name="plotTitleId">The plot title id</param>
        public static void BustColorCache(string plotTitleId)
        {
            byte* nativePlotTitleId;
            int plotTitleIdByteCount = 0;
            if (plotTitleId != null)
            {
                plotTitleIdByteCount = Encoding.UTF8.GetByteCount(plotTitleId);
                if (plotTitleIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativePlotTitleId = Util.Allocate(plotTitleIdByteCount + 1);
                }
                else
                {
                    byte* nativePlotTitleIdStackBytes = stackalloc byte[plotTitleIdByteCount + 1];
                    nativePlotTitleId = nativePlotTitleIdStackBytes;
                }
                
                int nativePlotTitleIdOffset = Util.GetUtf8(plotTitleId, nativePlotTitleId, plotTitleIdByteCount);
                nativePlotTitleId[nativePlotTitleIdOffset] = 0;
            }
            else
            {
                nativePlotTitleId = null;
            }
            
            ImPlotNative.ImPlot_BustColorCache(nativePlotTitleId);
            if (plotTitleIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativePlotTitleId);
            }
        }
        
        /// <summary>
        ///     Cancels the plot selection
        /// </summary>
        public static void CancelPlotSelection()
        {
            ImPlotNative.ImPlot_CancelPlotSelection();
        }
        
        /// <summary>
        ///     Describes whether colormap button
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool ColormapButton(string label)
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
            
            Vector2 size = new Vector2();
            ImPlotColormap cmap = (ImPlotColormap) (-1);
            byte ret = ImPlotNative.ImPlot_ColormapButton(nativeLabel, size, cmap);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether colormap button
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool ColormapButton(string label, Vector2 size)
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
            
            ImPlotColormap cmap = (ImPlotColormap) (-1);
            byte ret = ImPlotNative.ImPlot_ColormapButton(nativeLabel, size, cmap);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether colormap button
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="cmap">The cmap</param>
        /// <returns>The bool</returns>
        public static bool ColormapButton(string label, Vector2 size, ImPlotColormap cmap)
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
            
            byte ret = ImPlotNative.ImPlot_ColormapButton(nativeLabel, size, cmap);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Colormaps the icon using the specified cmap
        /// </summary>
        /// <param name="cmap">The cmap</param>
        public static void ColormapIcon(ImPlotColormap cmap)
        {
            ImPlotNative.ImPlot_ColormapIcon(cmap);
        }
        
        /// <summary>
        ///     Colormaps the scale using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        public static void ColormapScale(string label, double scaleMin, double scaleMax)
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
            
            Vector2 size = new Vector2();
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%g");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }
            
            int nativeFormatOffset = Util.GetUtf8("%g", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImPlotColormapScaleFlags flags = 0;
            ImPlotColormap cmap = (ImPlotColormap) (-1);
            ImPlotNative.ImPlot_ColormapScale(nativeLabel, scaleMin, scaleMax, size, nativeFormat, flags, cmap);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFormat);
            }
        }
        
        /// <summary>
        ///     Colormaps the scale using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="size">The size</param>
        public static void ColormapScale(string label, double scaleMin, double scaleMax, Vector2 size)
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
            formatByteCount = Encoding.UTF8.GetByteCount("%g");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }
            
            int nativeFormatOffset = Util.GetUtf8("%g", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImPlotColormapScaleFlags flags = 0;
            ImPlotColormap cmap = (ImPlotColormap) (-1);
            ImPlotNative.ImPlot_ColormapScale(nativeLabel, scaleMin, scaleMax, size, nativeFormat, flags, cmap);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFormat);
            }
        }
        
        /// <summary>
        ///     Colormaps the scale using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="size">The size</param>
        /// <param name="format">The format</param>
        public static void ColormapScale(string label, double scaleMin, double scaleMax, Vector2 size, string format)
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
            
            ImPlotColormapScaleFlags flags = 0;
            ImPlotColormap cmap = (ImPlotColormap) (-1);
            ImPlotNative.ImPlot_ColormapScale(nativeLabel, scaleMin, scaleMax, size, nativeFormat, flags, cmap);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFormat);
            }
        }
        
        /// <summary>
        ///     Colormaps the scale using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="size">The size</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        public static void ColormapScale(string label, double scaleMin, double scaleMax, Vector2 size, string format, ImPlotColormapScaleFlags flags)
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
            
            ImPlotColormap cmap = (ImPlotColormap) (-1);
            ImPlotNative.ImPlot_ColormapScale(nativeLabel, scaleMin, scaleMax, size, nativeFormat, flags, cmap);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFormat);
            }
        }
        
        /// <summary>
        ///     Colormaps the scale using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="size">The size</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <param name="cmap">The cmap</param>
        public static void ColormapScale(string label, double scaleMin, double scaleMax, Vector2 size, string format, ImPlotColormapScaleFlags flags, ImPlotColormap cmap)
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
            
            ImPlotNative.ImPlot_ColormapScale(nativeLabel, scaleMin, scaleMax, size, nativeFormat, flags, cmap);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFormat);
            }
        }
        
        /// <summary>
        ///     Describes whether colormap slider
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="t">The </param>
        /// <returns>The bool</returns>
        public static bool ColormapSlider(string label, ref float t)
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
            
            Vector4* @out = null;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }
            
            int nativeFormatOffset = Util.GetUtf8("", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImPlotColormap cmap = (ImPlotColormap) (-1);
            fixed (float* nativeT = &t)
            {
                byte ret = ImPlotNative.ImPlot_ColormapSlider(nativeLabel, nativeT, @out, nativeFormat, cmap);
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
        ///     Describes whether colormap slider
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="t">The </param>
        /// <param name="out">The out</param>
        /// <returns>The bool</returns>
        public static bool ColormapSlider(string label, ref float t, out Vector4 @out)
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
            formatByteCount = Encoding.UTF8.GetByteCount("");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }
            
            int nativeFormatOffset = Util.GetUtf8("", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImPlotColormap cmap = (ImPlotColormap) (-1);
            fixed (float* nativeT = &t)
            {
                fixed (Vector4* nativeOut = &@out)
                {
                    byte ret = ImPlotNative.ImPlot_ColormapSlider(nativeLabel, nativeT, nativeOut, nativeFormat, cmap);
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
        ///     Describes whether colormap slider
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="t">The </param>
        /// <param name="out">The out</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool ColormapSlider(string label, ref float t, out Vector4 @out, string format)
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
            
            ImPlotColormap cmap = (ImPlotColormap) (-1);
            fixed (float* nativeT = &t)
            {
                fixed (Vector4* nativeOut = &@out)
                {
                    byte ret = ImPlotNative.ImPlot_ColormapSlider(nativeLabel, nativeT, nativeOut, nativeFormat, cmap);
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
        ///     Describes whether colormap slider
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="t">The </param>
        /// <param name="out">The out</param>
        /// <param name="format">The format</param>
        /// <param name="cmap">The cmap</param>
        /// <returns>The bool</returns>
        public static bool ColormapSlider(string label, ref float t, out Vector4 @out, string format, ImPlotColormap cmap)
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
            
            fixed (float* nativeT = &t)
            {
                fixed (Vector4* nativeOut = &@out)
                {
                    byte ret = ImPlotNative.ImPlot_ColormapSlider(nativeLabel, nativeT, nativeOut, nativeFormat, cmap);
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
        ///     Creates the context
        /// </summary>
        /// <returns>The ret</returns>
        public static IntPtr CreateContext()
        {
            IntPtr ret = ImPlotNative.ImPlot_CreateContext();
            return ret;
        }
        
        /// <summary>
        ///     Destroys the context
        /// </summary>
        public static void DestroyContext()
        {
            IntPtr ctx = IntPtr.Zero;
            ImPlotNative.ImPlot_DestroyContext(ctx);
        }
        
        /// <summary>
        ///     Destroys the context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        public static void DestroyContext(IntPtr ctx)
        {
            ImPlotNative.ImPlot_DestroyContext(ctx);
        }
        
        /// <summary>
        ///     Describes whether drag line x
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="x">The </param>
        /// <param name="col">The col</param>
        /// <returns>The bool</returns>
        public static bool DragLineX(int id, ref double x, Vector4 col)
        {
            float thickness = 1;
            ImPlotDragToolFlags flags = 0;
            fixed (double* nativeX = &x)
            {
                byte ret = ImPlotNative.ImPlot_DragLineX(id, nativeX, col, thickness, flags);
                return ret != 0;
            }
        }
        
        /// <summary>
        ///     Describes whether drag line x
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="x">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        /// <returns>The bool</returns>
        public static bool DragLineX(int id, ref double x, Vector4 col, float thickness)
        {
            ImPlotDragToolFlags flags = 0;
            fixed (double* nativeX = &x)
            {
                byte ret = ImPlotNative.ImPlot_DragLineX(id, nativeX, col, thickness, flags);
                return ret != 0;
            }
        }
        
        /// <summary>
        ///     Describes whether drag line x
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="x">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragLineX(int id, ref double x, Vector4 col, float thickness, ImPlotDragToolFlags flags)
        {
            fixed (double* nativeX = &x)
            {
                byte ret = ImPlotNative.ImPlot_DragLineX(id, nativeX, col, thickness, flags);
                return ret != 0;
            }
        }
        
        /// <summary>
        ///     Describes whether drag line y
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        /// <returns>The bool</returns>
        public static bool DragLineY(int id, ref double y, Vector4 col)
        {
            float thickness = 1;
            ImPlotDragToolFlags flags = 0;
            fixed (double* nativeY = &y)
            {
                byte ret = ImPlotNative.ImPlot_DragLineY(id, nativeY, col, thickness, flags);
                return ret != 0;
            }
        }
        
        /// <summary>
        ///     Describes whether drag line y
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        /// <returns>The bool</returns>
        public static bool DragLineY(int id, ref double y, Vector4 col, float thickness)
        {
            ImPlotDragToolFlags flags = 0;
            fixed (double* nativeY = &y)
            {
                byte ret = ImPlotNative.ImPlot_DragLineY(id, nativeY, col, thickness, flags);
                return ret != 0;
            }
        }
        
        /// <summary>
        ///     Describes whether drag line y
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragLineY(int id, ref double y, Vector4 col, float thickness, ImPlotDragToolFlags flags)
        {
            fixed (double* nativeY = &y)
            {
                byte ret = ImPlotNative.ImPlot_DragLineY(id, nativeY, col, thickness, flags);
                return ret != 0;
            }
        }
        
        /// <summary>
        ///     Describes whether drag point
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        /// <returns>The bool</returns>
        public static bool DragPoint(int id, ref double x, ref double y, Vector4 col)
        {
            float size = 4;
            ImPlotDragToolFlags flags = 0;
            fixed (double* nativeX = &x)
            {
                fixed (double* nativeY = &y)
                {
                    byte ret = ImPlotNative.ImPlot_DragPoint(id, nativeX, nativeY, col, size, flags);
                    return ret != 0;
                }
            }
        }
        
        /// <summary>
        ///     Describes whether drag point
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool DragPoint(int id, ref double x, ref double y, Vector4 col, float size)
        {
            ImPlotDragToolFlags flags = 0;
            fixed (double* nativeX = &x)
            {
                fixed (double* nativeY = &y)
                {
                    byte ret = ImPlotNative.ImPlot_DragPoint(id, nativeX, nativeY, col, size, flags);
                    return ret != 0;
                }
            }
        }
        
        /// <summary>
        ///     Describes whether drag point
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragPoint(int id, ref double x, ref double y, Vector4 col, float size, ImPlotDragToolFlags flags)
        {
            fixed (double* nativeX = &x)
            {
                fixed (double* nativeY = &y)
                {
                    byte ret = ImPlotNative.ImPlot_DragPoint(id, nativeX, nativeY, col, size, flags);
                    return ret != 0;
                }
            }
        }
        
        /// <summary>
        ///     Describes whether drag rect
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <param name="col">The col</param>
        /// <returns>The bool</returns>
        public static bool DragRect(int id, ref double x1, ref double y1, ref double x2, ref double y2, Vector4 col)
        {
            ImPlotDragToolFlags flags = 0;
            fixed (double* nativeX1 = &x1)
            {
                fixed (double* nativeY1 = &y1)
                {
                    fixed (double* nativeX2 = &x2)
                    {
                        fixed (double* nativeY2 = &y2)
                        {
                            byte ret = ImPlotNative.ImPlot_DragRect(id, nativeX1, nativeY1, nativeX2, nativeY2, col, flags);
                            return ret != 0;
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Describes whether drag rect
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragRect(int id, ref double x1, ref double y1, ref double x2, ref double y2, Vector4 col, ImPlotDragToolFlags flags)
        {
            fixed (double* nativeX1 = &x1)
            {
                fixed (double* nativeY1 = &y1)
                {
                    fixed (double* nativeX2 = &x2)
                    {
                        fixed (double* nativeY2 = &y2)
                        {
                            byte ret = ImPlotNative.ImPlot_DragRect(id, nativeX1, nativeY1, nativeX2, nativeY2, col, flags);
                            return ret != 0;
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Ends the aligned plots
        /// </summary>
        public static void EndAlignedPlots()
        {
            ImPlotNative.ImPlot_EndAlignedPlots();
        }
        
        /// <summary>
        ///     Ends the drag drop source
        /// </summary>
        public static void EndDragDropSource()
        {
            ImPlotNative.ImPlot_EndDragDropSource();
        }
        
    }
}