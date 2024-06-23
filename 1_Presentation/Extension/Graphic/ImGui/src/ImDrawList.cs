// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawList.cs
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

namespace Alis.Extension.Graphic.ImGui
{
    /// <summary>
    ///     The im draw list
    /// </summary>
    public struct ImDrawList
    {
        /// <summary>
        ///     The cmd buffer
        /// </summary>
        public ImVectorG<ImDrawCmd>  CmdBuffer;
        
        /// <summary>
        ///     The idx buffer
        /// </summary>
        public ImVectorG<ushort> IdxBuffer;
        
        /// <summary>
        ///     The vtx buffer
        /// </summary>
        public ImVectorG<ImDrawVert> VtxBuffer;
        
        /// <summary>
        ///     The flags
        /// </summary>
        public ImDrawListFlags Flags;
        
        /// <summary>
        ///     The vtx current idx
        /// </summary>
        public uint VtxCurrentIdx;
        
        /// <summary>
        ///     The data
        /// </summary>
        public IntPtr Data;
        
        /// <summary>
        ///     The owner name
        /// </summary>
        public byte[] OwnerName;
        
        /// <summary>
        ///     The vtx write ptr
        /// </summary>
        public ImDrawVert VtxWritePtr;
        
        /// <summary>
        ///     The idx write ptr
        /// </summary>
        public ushort IdxWritePtr;
        
        /// <summary>
        ///     The clip rect stack
        /// </summary>
        public ImVectorG<Vector4> ClipRectStack;
        
        /// <summary>
        ///     The texture id stack
        /// </summary>
        public ImVectorG<IntPtr> TextureIdStack;
        
        /// <summary>
        ///     The path
        /// </summary>
        public ImVectorG<Vector2> Path;
        
        /// <summary>
        ///     The cmd header
        /// </summary>
        public ImDrawCmdHeader CmdHeader;
        
        /// <summary>
        ///     The splitter
        /// </summary>
        public ImDrawListSplitter Splitter;
        
        /// <summary>
        ///     The fringe scale
        /// </summary>
        public float FringeScale;
        
          /// <summary>
        ///     Calcs the circle auto segment count using the specified radius
        /// </summary>
        /// <param name="radius">The radius</param>
        /// <returns>The ret</returns>
        public int _CalcCircleAutoSegmentCount(float radius)
        {
            int ret = ImGuiNative.ImDrawList__CalcCircleAutoSegmentCount(this, radius);
            return ret;
        }
        
        /// <summary>
        ///     Clears the free memory
        /// </summary>
        public void _ClearFreeMemory()
        {
            ImGuiNative.ImDrawList__ClearFreeMemory(this);
        }
        
        /// <summary>
        ///     Ons the changed clip rect
        /// </summary>
        public void _OnChangedClipRect()
        {
            ImGuiNative.ImDrawList__OnChangedClipRect(this);
        }
        
        /// <summary>
        ///     Ons the changed texture id
        /// </summary>
        public void _OnChangedTextureID()
        {
            ImGuiNative.ImDrawList__OnChangedTextureID(this);
        }
        
        /// <summary>
        ///     Ons the changed vtx offset
        /// </summary>
        public void _OnChangedVtxOffset()
        {
            ImGuiNative.ImDrawList__OnChangedVtxOffset(this);
        }
        
        /// <summary>
        ///     Paths the arc to fast ex using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="aMinSample">The min sample</param>
        /// <param name="aMaxSample">The max sample</param>
        /// <param name="aStep">The step</param>
        public void _PathArcToFastEx(Vector2 center, float radius, int aMinSample, int aMaxSample, int aStep)
        {
            ImGuiNative.ImDrawList__PathArcToFastEx(this, center, radius, aMinSample, aMaxSample, aStep);
        }
        
        /// <summary>
        ///     Paths the arc to n using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="aMin">The min</param>
        /// <param name="aMax">The max</param>
        /// <param name="numSegments">The num segments</param>
        public void _PathArcToN(Vector2 center, float radius, float aMin, float aMax, int numSegments)
        {
            ImGuiNative.ImDrawList__PathArcToN(this, center, radius, aMin, aMax, numSegments);
        }
        
        /// <summary>
        ///     Pops the unused draw cmd
        /// </summary>
        public void _PopUnusedDrawCmd()
        {
            ImGuiNative.ImDrawList__PopUnusedDrawCmd(this);
        }
        
        /// <summary>
        ///     Resets the for new frame
        /// </summary>
        public void _ResetForNewFrame()
        {
            ImGuiNative.ImDrawList__ResetForNewFrame(this);
        }
        
        /// <summary>
        ///     Tries the merge draw cmds
        /// </summary>
        public void _TryMergeDrawCmds()
        {
            ImGuiNative.ImDrawList__TryMergeDrawCmds(this);
        }
        
        /// <summary>
        ///     Adds the bezier cubic using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        public void AddBezierCubic(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, uint col, float thickness)
        {
            int numSegments = 0;
            ImGuiNative.ImDrawList_AddBezierCubic(this, p1, p2, p3, p4, col, thickness, numSegments);
        }
        
        /// <summary>
        ///     Adds the bezier cubic using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        /// <param name="numSegments">The num segments</param>
        public void AddBezierCubic(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, uint col, float thickness, int numSegments)
        {
            ImGuiNative.ImDrawList_AddBezierCubic(this, p1, p2, p3, p4, col, thickness, numSegments);
        }
        
        /// <summary>
        ///     Adds the bezier quadratic using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        public void AddBezierQuadratic(Vector2 p1, Vector2 p2, Vector2 p3, uint col, float thickness)
        {
            int numSegments = 0;
            ImGuiNative.ImDrawList_AddBezierQuadratic(this, p1, p2, p3, col, thickness, numSegments);
        }
        
        /// <summary>
        ///     Adds the bezier quadratic using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        /// <param name="numSegments">The num segments</param>
        public void AddBezierQuadratic(Vector2 p1, Vector2 p2, Vector2 p3, uint col, float thickness, int numSegments)
        {
            ImGuiNative.ImDrawList_AddBezierQuadratic(this, p1, p2, p3, col, thickness, numSegments);
        }
        
        /// <summary>
        ///     Adds the callback using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="callbackData">The callback data</param>
        public void AddCallback(IntPtr callback, IntPtr callbackData)
        {
            IntPtr nativeCallbackData = callbackData;
            ImGuiNative.ImDrawList_AddCallback(this, callback, nativeCallbackData);
        }
        
        /// <summary>
        ///     Adds the circle using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        public void AddCircle(Vector2 center, float radius, uint col)
        {
            int numSegments = 0;
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddCircle(this, center, radius, col, numSegments, thickness);
        }
        
        /// <summary>
        ///     Adds the circle using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="numSegments">The num segments</param>
        public void AddCircle(Vector2 center, float radius, uint col, int numSegments)
        {
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddCircle(this, center, radius, col, numSegments, thickness);
        }
        
        /// <summary>
        ///     Adds the circle using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="numSegments">The num segments</param>
        /// <param name="thickness">The thickness</param>
        public void AddCircle(Vector2 center, float radius, uint col, int numSegments, float thickness)
        {
            ImGuiNative.ImDrawList_AddCircle(this, center, radius, col, numSegments, thickness);
        }
        
        /// <summary>
        ///     Adds the circle filled using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        public void AddCircleFilled(Vector2 center, float radius, uint col)
        {
            int numSegments = 0;
            ImGuiNative.ImDrawList_AddCircleFilled(this, center, radius, col, numSegments);
        }
        
        /// <summary>
        ///     Adds the circle filled using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="numSegments">The num segments</param>
        public void AddCircleFilled(Vector2 center, float radius, uint col, int numSegments)
        {
            ImGuiNative.ImDrawList_AddCircleFilled(this, center, radius, col, numSegments);
        }
        
        /// <summary>
        ///     Adds the convex poly filled using the specified points
        /// </summary>
        /// <param name="points">The points</param>
        /// <param name="numPoints">The num points</param>
        /// <param name="col">The col</param>
        public void AddConvexPolyFilled(ref Vector2 points, int numPoints, uint col)
        {
            ImGuiNative.ImDrawList_AddConvexPolyFilled(this, points, numPoints, col);
        }
        
        /// <summary>
        ///     Adds the draw cmd
        /// </summary>
        public void AddDrawCmd()
        {
            ImGuiNative.ImDrawList_AddDrawCmd(this);
        }
        
        /// <summary>
        ///     Adds the image using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        public void AddImage(IntPtr userTextureId, Vector2 pMin, Vector2 pMax)
        {
            Vector2 uvMin = new Vector2();
            Vector2 uvMax = new Vector2(1, 1);
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImage(this, userTextureId, pMin, pMax, uvMin, uvMax, col);
        }
        
        /// <summary>
        ///     Adds the image using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="uvMin">The uv min</param>
        public void AddImage(IntPtr userTextureId, Vector2 pMin, Vector2 pMax, Vector2 uvMin)
        {
            Vector2 uvMax = new Vector2(1, 1);
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImage(this, userTextureId, pMin, pMax, uvMin, uvMax, col);
        }
        
        /// <summary>
        ///     Adds the image using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="uvMin">The uv min</param>
        /// <param name="uvMax">The uv max</param>
        public void AddImage(IntPtr userTextureId, Vector2 pMin, Vector2 pMax, Vector2 uvMin, Vector2 uvMax)
        {
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImage(this, userTextureId, pMin, pMax, uvMin, uvMax, col);
        }
        
        /// <summary>
        ///     Adds the image using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="uvMin">The uv min</param>
        /// <param name="uvMax">The uv max</param>
        /// <param name="col">The col</param>
        public void AddImage(IntPtr userTextureId, Vector2 pMin, Vector2 pMax, Vector2 uvMin, Vector2 uvMax, uint col)
        {
            ImGuiNative.ImDrawList_AddImage(this, userTextureId, pMin, pMax, uvMin, uvMax, col);
        }
        
        /// <summary>
        ///     Adds the image quad using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        public void AddImageQuad(IntPtr userTextureId, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4)
        {
            Vector2 uv1 = new Vector2();
            Vector2 uv2 = new Vector2(1, 0);
            Vector2 uv3 = new Vector2(1, 1);
            Vector2 uv4 = new Vector2(0, 1);
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImageQuad(this, userTextureId, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
        }
        
        /// <summary>
        ///     Adds the image quad using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="uv1">The uv</param>
        public void AddImageQuad(IntPtr userTextureId, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, Vector2 uv1)
        {
            Vector2 uv2 = new Vector2(1, 0);
            Vector2 uv3 = new Vector2(1, 1);
            Vector2 uv4 = new Vector2(0, 1);
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImageQuad(this, userTextureId, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
        }
        
        /// <summary>
        ///     Adds the image quad using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="uv1">The uv</param>
        /// <param name="uv2">The uv</param>
        public void AddImageQuad(IntPtr userTextureId, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, Vector2 uv1, Vector2 uv2)
        {
            Vector2 uv3 = new Vector2(1, 1);
            Vector2 uv4 = new Vector2(0, 1);
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImageQuad(this, userTextureId, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
        }
        
        /// <summary>
        ///     Adds the image quad using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="uv1">The uv</param>
        /// <param name="uv2">The uv</param>
        /// <param name="uv3">The uv</param>
        public void AddImageQuad(IntPtr userTextureId, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, Vector2 uv1, Vector2 uv2, Vector2 uv3)
        {
            Vector2 uv4 = new Vector2(0, 1);
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImageQuad(this, userTextureId, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
        }
        
        /// <summary>
        ///     Adds the image quad using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="uv1">The uv</param>
        /// <param name="uv2">The uv</param>
        /// <param name="uv3">The uv</param>
        /// <param name="uv4">The uv</param>
        public void AddImageQuad(IntPtr userTextureId, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, Vector2 uv1, Vector2 uv2, Vector2 uv3, Vector2 uv4)
        {
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImageQuad(this, userTextureId, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
        }
        
        /// <summary>
        ///     Adds the image quad using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="uv1">The uv</param>
        /// <param name="uv2">The uv</param>
        /// <param name="uv3">The uv</param>
        /// <param name="uv4">The uv</param>
        /// <param name="col">The col</param>
        public void AddImageQuad(IntPtr userTextureId, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, Vector2 uv1, Vector2 uv2, Vector2 uv3, Vector2 uv4, uint col)
        {
            ImGuiNative.ImDrawList_AddImageQuad(this, userTextureId, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
        }
        
        /// <summary>
        ///     Adds the image rounded using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="uvMin">The uv min</param>
        /// <param name="uvMax">The uv max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        public void AddImageRounded(IntPtr userTextureId, Vector2 pMin, Vector2 pMax, Vector2 uvMin, Vector2 uvMax, uint col, float rounding)
        {
            ImDrawFlags flags = 0;
            ImGuiNative.ImDrawList_AddImageRounded(this, userTextureId, pMin, pMax, uvMin, uvMax, col, rounding, flags);
        }
        
        /// <summary>
        ///     Adds the image rounded using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="uvMin">The uv min</param>
        /// <param name="uvMax">The uv max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        public void AddImageRounded(IntPtr userTextureId, Vector2 pMin, Vector2 pMax, Vector2 uvMin, Vector2 uvMax, uint col, float rounding, ImDrawFlags flags)
        {
            ImGuiNative.ImDrawList_AddImageRounded(this, userTextureId, pMin, pMax, uvMin, uvMax, col, rounding, flags);
        }
        
        /// <summary>
        ///     Adds the line using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="col">The col</param>
        public void AddLine(Vector2 p1, Vector2 p2, uint col)
        {
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddLine(this, p1, p2, col, thickness);
        }
        
        /// <summary>
        ///     Adds the line using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        public void AddLine(Vector2 p1, Vector2 p2, uint col, float thickness)
        {
            ImGuiNative.ImDrawList_AddLine(this, p1, p2, col, thickness);
        }
        
        /// <summary>
        ///     Adds the ngon using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="numSegments">The num segments</param>
        public void AddNgon(Vector2 center, float radius, uint col, int numSegments)
        {
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddNgon(this, center, radius, col, numSegments, thickness);
        }
        
        /// <summary>
        ///     Adds the ngon using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="numSegments">The num segments</param>
        /// <param name="thickness">The thickness</param>
        public void AddNgon(Vector2 center, float radius, uint col, int numSegments, float thickness)
        {
            ImGuiNative.ImDrawList_AddNgon(this, center, radius, col, numSegments, thickness);
        }
        
        /// <summary>
        ///     Adds the ngon filled using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="numSegments">The num segments</param>
        public void AddNgonFilled(Vector2 center, float radius, uint col, int numSegments)
        {
            ImGuiNative.ImDrawList_AddNgonFilled(this, center, radius, col, numSegments);
        }
        
        /// <summary>
        ///     Adds the polyline using the specified points
        /// </summary>
        /// <param name="points">The points</param>
        /// <param name="numPoints">The num points</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <param name="thickness">The thickness</param>
        public void AddPolyline(ref Vector2 points, int numPoints, uint col, ImDrawFlags flags, float thickness)
        {
            ImGuiNative.ImDrawList_AddPolyline(this, points, numPoints, col, flags, thickness);
        }
        
        /// <summary>
        ///     Adds the quad using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="col">The col</param>
        public void AddQuad(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, uint col)
        {
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddQuad(this, p1, p2, p3, p4, col, thickness);
        }
        
        /// <summary>
        ///     Adds the quad using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        public void AddQuad(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, uint col, float thickness)
        {
            ImGuiNative.ImDrawList_AddQuad(this, p1, p2, p3, p4, col, thickness);
        }
        
        /// <summary>
        ///     Adds the quad filled using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="col">The col</param>
        public void AddQuadFilled(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, uint col)
        {
            ImGuiNative.ImDrawList_AddQuadFilled(this, p1, p2, p3, p4, col);
        }
        
        /// <summary>
        ///     Adds the rect using the specified p min
        /// </summary>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="col">The col</param>
        public void AddRect(Vector2 pMin, Vector2 pMax, uint col)
        {
            float rounding = 0.0f;
            ImDrawFlags flags = 0;
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddRect(this, pMin, pMax, col, rounding, flags, thickness);
        }
        
        /// <summary>
        ///     Adds the rect using the specified p min
        /// </summary>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        public void AddRect(Vector2 pMin, Vector2 pMax, uint col, float rounding)
        {
            ImDrawFlags flags = 0;
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddRect(this, pMin, pMax, col, rounding, flags, thickness);
        }
        
        /// <summary>
        ///     Adds the rect using the specified p min
        /// </summary>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        public void AddRect(Vector2 pMin, Vector2 pMax, uint col, float rounding, ImDrawFlags flags)
        {
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddRect(this, pMin, pMax, col, rounding, flags, thickness);
        }
        
        /// <summary>
        ///     Adds the rect using the specified p min
        /// </summary>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        /// <param name="thickness">The thickness</param>
        public void AddRect(Vector2 pMin, Vector2 pMax, uint col, float rounding, ImDrawFlags flags, float thickness)
        {
            ImGuiNative.ImDrawList_AddRect(this, pMin, pMax, col, rounding, flags, thickness);
        }
        
        /// <summary>
        ///     Adds the rect filled using the specified p min
        /// </summary>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="col">The col</param>
        public void AddRectFilled(Vector2 pMin, Vector2 pMax, uint col)
        {
            float rounding = 0.0f;
            ImDrawFlags flags = 0;
            ImGuiNative.ImDrawList_AddRectFilled(this, pMin, pMax, col, rounding, flags);
        }
        
        /// <summary>
        ///     Adds the rect filled using the specified p min
        /// </summary>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        public void AddRectFilled(Vector2 pMin, Vector2 pMax, uint col, float rounding)
        {
            ImDrawFlags flags = 0;
            ImGuiNative.ImDrawList_AddRectFilled(this, pMin, pMax, col, rounding, flags);
        }
        
        /// <summary>
        ///     Adds the rect filled using the specified p min
        /// </summary>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        public void AddRectFilled(Vector2 pMin, Vector2 pMax, uint col, float rounding, ImDrawFlags flags)
        {
            ImGuiNative.ImDrawList_AddRectFilled(this, pMin, pMax, col, rounding, flags);
        }
        
        /// <summary>
        ///     Adds the rect filled multi color using the specified p min
        /// </summary>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="colUprLeft">The col upr left</param>
        /// <param name="colUprRight">The col upr right</param>
        /// <param name="colBotRight">The col bot right</param>
        /// <param name="colBotLeft">The col bot left</param>
        public void AddRectFilledMultiColor(Vector2 pMin, Vector2 pMax, uint colUprLeft, uint colUprRight, uint colBotRight, uint colBotLeft)
        {
            ImGuiNative.ImDrawList_AddRectFilledMultiColor(this, pMin, pMax, colUprLeft, colUprRight, colBotRight, colBotLeft);
        }
        
        /// <summary>
        ///     Adds the triangle using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="col">The col</param>
        public void AddTriangle(Vector2 p1, Vector2 p2, Vector2 p3, uint col)
        {
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddTriangle(this, p1, p2, p3, col, thickness);
        }
        
        /// <summary>
        ///     Adds the triangle using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        public void AddTriangle(Vector2 p1, Vector2 p2, Vector2 p3, uint col, float thickness)
        {
            ImGuiNative.ImDrawList_AddTriangle(this, p1, p2, p3, col, thickness);
        }
        
        /// <summary>
        ///     Adds the triangle filled using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="col">The col</param>
        public void AddTriangleFilled(Vector2 p1, Vector2 p2, Vector2 p3, uint col)
        {
            ImGuiNative.ImDrawList_AddTriangleFilled(this, p1, p2, p3, col);
        }
        
        /// <summary>
        ///     Channelses the merge
        /// </summary>
        public void ChannelsMerge()
        {
            ImGuiNative.ImDrawList_ChannelsMerge(this);
        }
        
        /// <summary>
        ///     Channelses the set current using the specified n
        /// </summary>
        /// <param name="n">The </param>
        public void ChannelsSetCurrent(int n)
        {
            ImGuiNative.ImDrawList_ChannelsSetCurrent(this, n);
        }
        
        /// <summary>
        ///     Channelses the split using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        public void ChannelsSplit(int count)
        {
            ImGuiNative.ImDrawList_ChannelsSplit(this, count);
        }
        
        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImDrawList_destroy(this);
        }
        
        /// <summary>
        ///     Gets the clip rect max
        /// </summary>
        /// <returns>The retval</returns>
        public Vector2 GetClipRectMax()
        {
            Vector2 retval;
            ImGuiNative.ImDrawList_GetClipRectMax(out retval, this);
            return retval;
        }
        
        /// <summary>
        ///     Gets the clip rect min
        /// </summary>
        /// <returns>The retval</returns>
        public Vector2 GetClipRectMin()
        {
            Vector2 retval;
            ImGuiNative.ImDrawList_GetClipRectMin(out retval, this);
            return retval;
        }
        
        /// <summary>
        ///     Paths the arc to using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="aMin">The min</param>
        /// <param name="aMax">The max</param>
        public void PathArcTo(Vector2 center, float radius, float aMin, float aMax)
        {
            int numSegments = 0;
            ImGuiNative.ImDrawList_PathArcTo(this, center, radius, aMin, aMax, numSegments);
        }
        
        /// <summary>
        ///     Paths the arc to using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="aMin">The min</param>
        /// <param name="aMax">The max</param>
        /// <param name="numSegments">The num segments</param>
        public void PathArcTo(Vector2 center, float radius, float aMin, float aMax, int numSegments)
        {
            ImGuiNative.ImDrawList_PathArcTo(this, center, radius, aMin, aMax, numSegments);
        }
        
        /// <summary>
        ///     Paths the arc to fast using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="aMinOf12">The min of 12</param>
        /// <param name="aMaxOf12">The max of 12</param>
        public void PathArcToFast(Vector2 center, float radius, int aMinOf12, int aMaxOf12)
        {
            ImGuiNative.ImDrawList_PathArcToFast(this, center, radius, aMinOf12, aMaxOf12);
        }
        
        /// <summary>
        ///     Paths the bezier cubic curve to using the specified p 2
        /// </summary>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        public void PathBezierCubicCurveTo(Vector2 p2, Vector2 p3, Vector2 p4)
        {
            int numSegments = 0;
            ImGuiNative.ImDrawList_PathBezierCubicCurveTo(this, p2, p3, p4, numSegments);
        }
        
        /// <summary>
        ///     Paths the bezier cubic curve to using the specified p 2
        /// </summary>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="numSegments">The num segments</param>
        public void PathBezierCubicCurveTo(Vector2 p2, Vector2 p3, Vector2 p4, int numSegments)
        {
            ImGuiNative.ImDrawList_PathBezierCubicCurveTo(this, p2, p3, p4, numSegments);
        }
        
        /// <summary>
        ///     Paths the bezier quadratic curve to using the specified p 2
        /// </summary>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        public void PathBezierQuadraticCurveTo(Vector2 p2, Vector2 p3)
        {
            int numSegments = 0;
            ImGuiNative.ImDrawList_PathBezierQuadraticCurveTo(this, p2, p3, numSegments);
        }
        
        /// <summary>
        ///     Paths the bezier quadratic curve to using the specified p 2
        /// </summary>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="numSegments">The num segments</param>
        public void PathBezierQuadraticCurveTo(Vector2 p2, Vector2 p3, int numSegments)
        {
            ImGuiNative.ImDrawList_PathBezierQuadraticCurveTo(this, p2, p3, numSegments);
        }
        
        /// <summary>
        ///     Paths the clear
        /// </summary>
        public void PathClear()
        {
            ImGuiNative.ImDrawList_PathClear(this);
        }
        
        /// <summary>
        ///     Paths the fill convex using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        public void PathFillConvex(uint col)
        {
            ImGuiNative.ImDrawList_PathFillConvex(this, col);
        }
        
        /// <summary>
        ///     Paths the line to using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        public void PathLineTo(Vector2 pos)
        {
            ImGuiNative.ImDrawList_PathLineTo(this, pos);
        }
        
        /// <summary>
        ///     Paths the line to merge duplicate using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        public void PathLineToMergeDuplicate(Vector2 pos)
        {
            ImGuiNative.ImDrawList_PathLineToMergeDuplicate(this, pos);
        }
        
        /// <summary>
        ///     Paths the rect using the specified rect min
        /// </summary>
        /// <param name="rectMin">The rect min</param>
        /// <param name="rectMax">The rect max</param>
        public void PathRect(Vector2 rectMin, Vector2 rectMax)
        {
            float rounding = 0.0f;
            ImDrawFlags flags = 0;
            ImGuiNative.ImDrawList_PathRect(this, rectMin, rectMax, rounding, flags);
        }
        
        /// <summary>
        ///     Paths the rect using the specified rect min
        /// </summary>
        /// <param name="rectMin">The rect min</param>
        /// <param name="rectMax">The rect max</param>
        /// <param name="rounding">The rounding</param>
        public void PathRect(Vector2 rectMin, Vector2 rectMax, float rounding)
        {
            ImDrawFlags flags = 0;
            ImGuiNative.ImDrawList_PathRect(this, rectMin, rectMax, rounding, flags);
        }
        
        /// <summary>
        ///     Paths the rect using the specified rect min
        /// </summary>
        /// <param name="rectMin">The rect min</param>
        /// <param name="rectMax">The rect max</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        public void PathRect(Vector2 rectMin, Vector2 rectMax, float rounding, ImDrawFlags flags)
        {
            ImGuiNative.ImDrawList_PathRect(this, rectMin, rectMax, rounding, flags);
        }
        
        /// <summary>
        ///     Paths the stroke using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        public void PathStroke(uint col)
        {
            ImDrawFlags flags = 0;
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_PathStroke(this, col, flags, thickness);
        }
        
        /// <summary>
        ///     Paths the stroke using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        public void PathStroke(uint col, ImDrawFlags flags)
        {
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_PathStroke(this, col, flags, thickness);
        }
        
        /// <summary>
        ///     Paths the stroke using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <param name="thickness">The thickness</param>
        public void PathStroke(uint col, ImDrawFlags flags, float thickness)
        {
            ImGuiNative.ImDrawList_PathStroke(this, col, flags, thickness);
        }
        
        /// <summary>
        ///     Pops the clip rect
        /// </summary>
        public void PopClipRect()
        {
            ImGuiNative.ImDrawList_PopClipRect(this);
        }
        
        /// <summary>
        ///     Pops the texture id
        /// </summary>
        public void PopTextureId()
        {
            ImGuiNative.ImDrawList_PopTextureID(this);
        }
        
        /// <summary>
        ///     Prims the quad uv using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <param name="uvA">The uv</param>
        /// <param name="uvB">The uv</param>
        /// <param name="uvC">The uv</param>
        /// <param name="uvD">The uv</param>
        /// <param name="col">The col</param>
        public void PrimQuadUv(Vector2 a, Vector2 b, Vector2 c, Vector2 d, Vector2 uvA, Vector2 uvB, Vector2 uvC, Vector2 uvD, uint col)
        {
            ImGuiNative.ImDrawList_PrimQuadUV(this, a, b, c, d, uvA, uvB, uvC, uvD, col);
        }
        
        /// <summary>
        ///     Prims the rect using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="col">The col</param>
        public void PrimRect(Vector2 a, Vector2 b, uint col)
        {
            ImGuiNative.ImDrawList_PrimRect(this, a, b, col);
        }
        
        /// <summary>
        ///     Prims the rect uv using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="uvA">The uv</param>
        /// <param name="uvB">The uv</param>
        /// <param name="col">The col</param>
        public void PrimRectUv(Vector2 a, Vector2 b, Vector2 uvA, Vector2 uvB, uint col)
        {
            ImGuiNative.ImDrawList_PrimRectUV(this, a, b, uvA, uvB, col);
        }
        
        /// <summary>
        ///     Prims the reserve using the specified idx count
        /// </summary>
        /// <param name="idxCount">The idx count</param>
        /// <param name="vtxCount">The vtx count</param>
        public void PrimReserve(int idxCount, int vtxCount)
        {
            ImGuiNative.ImDrawList_PrimReserve(this, idxCount, vtxCount);
        }
        
        /// <summary>
        ///     Prims the unreserve using the specified idx count
        /// </summary>
        /// <param name="idxCount">The idx count</param>
        /// <param name="vtxCount">The vtx count</param>
        public void PrimUnreserve(int idxCount, int vtxCount)
        {
            ImGuiNative.ImDrawList_PrimUnreserve(this, idxCount, vtxCount);
        }
        
        /// <summary>
        ///     Prims the vtx using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="uv">The uv</param>
        /// <param name="col">The col</param>
        public void PrimVtx(Vector2 pos, Vector2 uv, uint col)
        {
            ImGuiNative.ImDrawList_PrimVtx(this, pos, uv, col);
        }
        
        /// <summary>
        ///     Prims the write idx using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        public void PrimWriteIdx(ushort idx)
        {
            ImGuiNative.ImDrawList_PrimWriteIdx(this, idx);
        }
        
        /// <summary>
        ///     Prims the write vtx using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="uv">The uv</param>
        /// <param name="col">The col</param>
        public void PrimWriteVtx(Vector2 pos, Vector2 uv, uint col)
        {
            ImGuiNative.ImDrawList_PrimWriteVtx(this, pos, uv, col);
        }
        
        /// <summary>
        ///     Pushes the clip rect using the specified clip rect min
        /// </summary>
        /// <param name="clipRectMin">The clip rect min</param>
        /// <param name="clipRectMax">The clip rect max</param>
        public void PushClipRect(Vector2 clipRectMin, Vector2 clipRectMax)
        {
            byte intersectWithCurrentClipRect = 0;
            ImGuiNative.ImDrawList_PushClipRect(this, clipRectMin, clipRectMax, intersectWithCurrentClipRect);
        }
        
        /// <summary>
        ///     Pushes the clip rect using the specified clip rect min
        /// </summary>
        /// <param name="clipRectMin">The clip rect min</param>
        /// <param name="clipRectMax">The clip rect max</param>
        /// <param name="intersectWithCurrentClipRect">The intersect with current clip rect</param>
        public void PushClipRect(Vector2 clipRectMin, Vector2 clipRectMax, bool intersectWithCurrentClipRect)
        {
            byte nativeIntersectWithCurrentClipRect = intersectWithCurrentClipRect ? (byte) 1 : (byte) 0;
            ImGuiNative.ImDrawList_PushClipRect(this, clipRectMin, clipRectMax, nativeIntersectWithCurrentClipRect);
        }
        
        /// <summary>
        ///     Pushes the clip rect full screen
        /// </summary>
        public void PushClipRectFullScreen()
        {
            ImGuiNative.ImDrawList_PushClipRectFullScreen(this);
        }
        
        /// <summary>
        ///     Pushes the texture id using the specified texture id
        /// </summary>
        /// <param name="textureId">The texture id</param>
        public void PushTextureId(IntPtr textureId)
        {
            ImGuiNative.ImDrawList_PushTextureID(this, textureId);
        }
        
        /// <summary>
        ///     Adds the text using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="col">The col</param>
        /// <param name="textBegin">The text begin</param>
        public void AddText(Vector2 pos, uint col, string textBegin)
        {
            ImGuiNative.ImDrawList_AddText_Vec2(this, pos, col, Encoding.UTF8.GetBytes(textBegin), null);
        }
        
        /// <summary>
        ///     Adds the text using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="fontSize">The font size</param>
        /// <param name="pos">The pos</param>
        /// <param name="col">The col</param>
        /// <param name="textBegin">The text begin</param>
        public void AddText(ImFont font, float fontSize, Vector2 pos, uint col, string textBegin)
        {
            ImGuiNative.ImDrawList_AddText_FontPtr(this, ref font, fontSize, pos, col, Encoding.UTF8.GetBytes(textBegin), null, 0.0f, new Vector4());
        }
    }
}