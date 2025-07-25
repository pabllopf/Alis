// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawListPtr.cs
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

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im draw list ptr
    /// </summary>
    public readonly struct ImDrawListPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public IntPtr NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImDrawListPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImDrawListPtr(IntPtr nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImDrawListPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImDrawListPtr(ImDrawList nativePtr)
        {
            NativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImDrawList>());
            Marshal.StructureToPtr(nativePtr, NativePtr, false);
        }

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator IntPtr(ImDrawListPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawListPtr(IntPtr nativePtr) => new ImDrawListPtr(nativePtr);

        /// <summary>
        ///     Gets the value of the cmd buffer
        /// </summary>
        public ImVectorG<ImDrawCmd> CmdBuffer => new ImVectorG<ImDrawCmd>(Marshal.PtrToStructure<ImDrawList>(NativePtr).CmdBuffer);

        /// <summary>
        ///     Gets the value of the idx buffer
        /// </summary>
        public ImVectorG<ushort> IdxBuffer => new ImVectorG<ushort>(Marshal.PtrToStructure<ImDrawList>(NativePtr).IdxBuffer);

        /// <summary>
        ///     Gets the value of the vtx buffer
        /// </summary>
        public ImVectorG<ImDrawVert> VtxBuffer => new ImVectorG<ImDrawVert>(Marshal.PtrToStructure<ImDrawList>(NativePtr).VtxBuffer);

        /// <summary>
        ///     Gets the value of the flags
        /// </summary>
        public ImDrawListFlags Flags => Marshal.PtrToStructure<ImDrawList>(NativePtr).Flags;

        /// <summary>
        ///     Gets the value of the  vtxcurrentidx
        /// </summary>
        public uint VtxCurrentIdx => Marshal.PtrToStructure<ImDrawList>(NativePtr).VtxCurrentIdx;

        /// <summary>
        ///     Gets the value of the  data
        /// </summary>
        public IntPtr Data => Marshal.PtrToStructure<ImDrawList>(NativePtr).Data;

        /// <summary>
        ///     Gets the value of the  ownername
        /// </summary>
        public NullTerminatedString OwnerName => new NullTerminatedString(Marshal.PtrToStructure<ImDrawList>(NativePtr).OwnerName);

        /// <summary>
        ///     Gets the value of the vtx write ptr
        /// </summary>
        public ImDrawVert VtxWritePtr => Marshal.PtrToStructure<ImDrawVert>(Marshal.PtrToStructure<ImDrawList>(NativePtr).VtxWritePtr);

        /// <summary>
        ///     Gets or sets the value of the  idxwriteptr
        /// </summary>
        public IntPtr IdxWritePtr => Marshal.PtrToStructure<ImDrawList>(NativePtr).IdxWritePtr;

        /// <summary>
        ///     Gets the value of the  cliprectstack
        /// </summary>
        public ImVectorG<Vector4F> ClipRectStack => new ImVectorG<Vector4F>(Marshal.PtrToStructure<ImDrawList>(NativePtr).ClipRectStack);

        /// <summary>
        ///     Gets the value of the  textureidstack
        /// </summary>
        public ImVectorG<IntPtr> TextureIdStack => new ImVectorG<IntPtr>(Marshal.PtrToStructure<ImDrawList>(NativePtr).TextureIdStack);

        /// <summary>
        ///     Gets the value of the  path
        /// </summary>
        public ImVectorG<Vector2F> Path => new ImVectorG<Vector2F>(Marshal.PtrToStructure<ImDrawList>(NativePtr).Path);

        /// <summary>
        ///     Gets the value of the  cmdheader
        /// </summary>
        public ImDrawCmdHeader CmdHeader => Marshal.PtrToStructure<ImDrawList>(NativePtr).CmdHeader;

        /// <summary>
        ///     Gets the value of the  splitter
        /// </summary>
        public ImDrawListSplitter Splitter => Marshal.PtrToStructure<ImDrawList>(NativePtr).Splitter;

        /// <summary>
        ///     Gets the value of the  fringescale
        /// </summary>
        public float FringeScale => Marshal.PtrToStructure<ImDrawList>(NativePtr).FringeScale;

        /// <summary>
        ///     Calcs the circle auto segment count using the specified radius
        /// </summary>
        /// <param name="radius">The radius</param>
        /// <returns>The ret</returns>
        public int _CalcCircleAutoSegmentCount(float radius)
        {
            int ret = ImGuiNative.ImDrawList__CalcCircleAutoSegmentCount(NativePtr, radius);
            return ret;
        }

        /// <summary>
        ///     Clears the free memory
        /// </summary>
        public void ClearFreeMemory() => ImGuiNative.ImDrawList__ClearFreeMemory(NativePtr);

        /// <summary>
        ///     Ons the changed clip rect
        /// </summary>
        public void OnChangedClipRect() => ImGuiNative.ImDrawList__OnChangedClipRect(NativePtr);

        /// <summary>
        ///     Ons the changed texture id
        /// </summary>
        public void OnChangedTextureID() => ImGuiNative.ImDrawList__OnChangedTextureID(NativePtr);

        /// <summary>
        ///     Ons the changed vtx offset
        /// </summary>
        public void OnChangedVtxOffset() => ImGuiNative.ImDrawList__OnChangedVtxOffset(NativePtr);

        /// <summary>
        ///     Paths the arc to fast ex using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="aMinSample">The min sample</param>
        /// <param name="aMaxSample">The max sample</param>
        /// <param name="aStep">The step</param>
        public void PathArcToFastEx(Vector2F center, float radius, int aMinSample, int aMaxSample, int aStep) => ImGuiNative.ImDrawList__PathArcToFastEx(NativePtr, center, radius, aMinSample, aMaxSample, aStep);

        /// <summary>
        ///     Paths the arc to n using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="aMin">The min</param>
        /// <param name="aMax">The max</param>
        /// <param name="numSegments">The num segments</param>
        public void PathArcToN(Vector2F center, float radius, float aMin, float aMax, int numSegments) => ImGuiNative.ImDrawList__PathArcToN(NativePtr, center, radius, aMin, aMax, numSegments);

        /// <summary>
        ///     Pops the unused draw cmd
        /// </summary>
        public void PopUnusedDrawCmd() => ImGuiNative.ImDrawList__PopUnusedDrawCmd(NativePtr);

        /// <summary>
        ///     Resets the for new frame
        /// </summary>
        public void ResetForNewFrame() => ImGuiNative.ImDrawList__ResetForNewFrame(NativePtr);

        /// <summary>
        ///     Tries the merge draw cmds
        /// </summary>
        public void TryMergeDrawCmd() => ImGuiNative.ImDrawList__TryMergeDrawCmds(NativePtr);

        /// <summary>
        ///     Adds the bezier cubic using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        public void AddBezierCubic(Vector2F p1, Vector2F p2, Vector2F p3, Vector2F p4, uint col, float thickness) => ImGuiNative.ImDrawList_AddBezierCubic(NativePtr, p1, p2, p3, p4, col, thickness, 0);

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
        public void AddBezierCubic(Vector2F p1, Vector2F p2, Vector2F p3, Vector2F p4, uint col, float thickness, int numSegments) => ImGuiNative.ImDrawList_AddBezierCubic(NativePtr, p1, p2, p3, p4, col, thickness, numSegments);

        /// <summary>
        ///     Adds the bezier quadratic using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        public void AddBezierQuadratic(Vector2F p1, Vector2F p2, Vector2F p3, uint col, float thickness) => ImGuiNative.ImDrawList_AddBezierQuadratic(NativePtr, p1, p2, p3, col, thickness, 0);

        /// <summary>
        ///     Adds the bezier quadratic using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        /// <param name="numSegments">The num segments</param>
        public void AddBezierQuadratic(Vector2F p1, Vector2F p2, Vector2F p3, uint col, float thickness, int numSegments) => ImGuiNative.ImDrawList_AddBezierQuadratic(NativePtr, p1, p2, p3, col, thickness, numSegments);

        /// <summary>
        ///     Adds the callback using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="callbackData">The callback data</param>
        public void AddCallback(IntPtr callback, IntPtr callbackData)
        {
            IntPtr nativeCallbackData = callbackData;
            ImGuiNative.ImDrawList_AddCallback(NativePtr, callback, nativeCallbackData);
        }

        /// <summary>
        ///     Adds the circle using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        public void AddCircle(Vector2F center, float radius, uint col)
        {
            int numSegments = 0;
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddCircle(NativePtr, center, radius, col, numSegments, thickness);
        }

        /// <summary>
        ///     Adds the circle using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="numSegments">The num segments</param>
        public void AddCircle(Vector2F center, float radius, uint col, int numSegments)
        {
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddCircle(NativePtr, center, radius, col, numSegments, thickness);
        }

        /// <summary>
        ///     Adds the circle using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="numSegments">The num segments</param>
        /// <param name="thickness">The thickness</param>
        public void AddCircle(Vector2F center, float radius, uint col, int numSegments, float thickness)
        {
            ImGuiNative.ImDrawList_AddCircle(NativePtr, center, radius, col, numSegments, thickness);
        }

        /// <summary>
        ///     Adds the circle filled using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        public void AddCircleFilled(Vector2F center, float radius, uint col)
        {
            int numSegments = 0;
            ImGuiNative.ImDrawList_AddCircleFilled(NativePtr, center, radius, col, numSegments);
        }

        /// <summary>
        ///     Adds the circle filled using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="numSegments">The num segments</param>
        public void AddCircleFilled(Vector2F center, float radius, uint col, int numSegments)
        {
            ImGuiNative.ImDrawList_AddCircleFilled(NativePtr, center, radius, col, numSegments);
        }

        /// <summary>
        ///     Adds the convex poly filled using the specified points
        /// </summary>
        /// <param name="points">The points</param>
        /// <param name="numPoints">The num points</param>
        /// <param name="col">The col</param>
        public void AddConvexPolyFilled(ref Vector2F points, int numPoints, uint col)
        {
            ImGuiNative.ImDrawList_AddConvexPolyFilled(NativePtr, ref points, numPoints, col);
        }

        /// <summary>
        ///     Adds the draw cmd
        /// </summary>
        public void AddDrawCmd()
        {
            ImGuiNative.ImDrawList_AddDrawCmd(NativePtr);
        }

        /// <summary>
        ///     Adds the image using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        public void AddImage(IntPtr userTextureId, Vector2F pMin, Vector2F pMax)
        {
            Vector2F uvMin = new Vector2F();
            Vector2F uvMax = new Vector2F(1, 1);
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImage(NativePtr, userTextureId, pMin, pMax, uvMin, uvMax, col);
        }

        /// <summary>
        ///     Adds the image using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="uvMin">The uv min</param>
        public void AddImage(IntPtr userTextureId, Vector2F pMin, Vector2F pMax, Vector2F uvMin)
        {
            Vector2F uvMax = new Vector2F(1, 1);
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImage(NativePtr, userTextureId, pMin, pMax, uvMin, uvMax, col);
        }

        /// <summary>
        ///     Adds the image using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="uvMin">The uv min</param>
        /// <param name="uvMax">The uv max</param>
        public void AddImage(IntPtr userTextureId, Vector2F pMin, Vector2F pMax, Vector2F uvMin, Vector2F uvMax)
        {
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImage(NativePtr, userTextureId, pMin, pMax, uvMin, uvMax, col);
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
        public void AddImage(IntPtr userTextureId, Vector2F pMin, Vector2F pMax, Vector2F uvMin, Vector2F uvMax, uint col)
        {
            ImGuiNative.ImDrawList_AddImage(NativePtr, userTextureId, pMin, pMax, uvMin, uvMax, col);
        }

        /// <summary>
        ///     Adds the image quad using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        public void AddImageQuad(IntPtr userTextureId, Vector2F p1, Vector2F p2, Vector2F p3, Vector2F p4)
        {
            Vector2F uv1 = new Vector2F();
            Vector2F uv2 = new Vector2F(1, 0);
            Vector2F uv3 = new Vector2F(1, 1);
            Vector2F uv4 = new Vector2F(0, 1);
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImageQuad(NativePtr, userTextureId, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
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
        public void AddImageQuad(IntPtr userTextureId, Vector2F p1, Vector2F p2, Vector2F p3, Vector2F p4, Vector2F uv1)
        {
            Vector2F uv2 = new Vector2F(1, 0);
            Vector2F uv3 = new Vector2F(1, 1);
            Vector2F uv4 = new Vector2F(0, 1);
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImageQuad(NativePtr, userTextureId, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
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
        public void AddImageQuad(IntPtr userTextureId, Vector2F p1, Vector2F p2, Vector2F p3, Vector2F p4, Vector2F uv1, Vector2F uv2)
        {
            Vector2F uv3 = new Vector2F(1, 1);
            Vector2F uv4 = new Vector2F(0, 1);
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImageQuad(NativePtr, userTextureId, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
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
        public void AddImageQuad(IntPtr userTextureId, Vector2F p1, Vector2F p2, Vector2F p3, Vector2F p4, Vector2F uv1, Vector2F uv2, Vector2F uv3)
        {
            Vector2F uv4 = new Vector2F(0, 1);
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImageQuad(NativePtr, userTextureId, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
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
        public void AddImageQuad(IntPtr userTextureId, Vector2F p1, Vector2F p2, Vector2F p3, Vector2F p4, Vector2F uv1, Vector2F uv2, Vector2F uv3, Vector2F uv4)
        {
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImageQuad(NativePtr, userTextureId, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
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
        public void AddImageQuad(IntPtr userTextureId, Vector2F p1, Vector2F p2, Vector2F p3, Vector2F p4, Vector2F uv1, Vector2F uv2, Vector2F uv3, Vector2F uv4, uint col)
        {
            ImGuiNative.ImDrawList_AddImageQuad(NativePtr, userTextureId, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
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
        public void AddImageRounded(IntPtr userTextureId, Vector2F pMin, Vector2F pMax, Vector2F uvMin, Vector2F uvMax, uint col, float rounding)
        {
            ImDrawFlags flags = 0;
            ImGuiNative.ImDrawList_AddImageRounded(NativePtr, userTextureId, pMin, pMax, uvMin, uvMax, col, rounding, flags);
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
        public void AddImageRounded(IntPtr userTextureId, Vector2F pMin, Vector2F pMax, Vector2F uvMin, Vector2F uvMax, uint col, float rounding, ImDrawFlags flags)
        {
            ImGuiNative.ImDrawList_AddImageRounded(NativePtr, userTextureId, pMin, pMax, uvMin, uvMax, col, rounding, flags);
        }

        /// <summary>
        ///     Adds the line using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="col">The col</param>
        public void AddLine(Vector2F p1, Vector2F p2, uint col)
        {
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddLine(NativePtr, p1, p2, col, thickness);
        }

        /// <summary>
        ///     Adds the line using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        public void AddLine(Vector2F p1, Vector2F p2, uint col, float thickness)
        {
            ImGuiNative.ImDrawList_AddLine(NativePtr, p1, p2, col, thickness);
        }

        /// <summary>
        ///     Adds the ngon using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="numSegments">The num segments</param>
        public void AddNgon(Vector2F center, float radius, uint col, int numSegments)
        {
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddNgon(NativePtr, center, radius, col, numSegments, thickness);
        }

        /// <summary>
        ///     Adds the ngon using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="numSegments">The num segments</param>
        /// <param name="thickness">The thickness</param>
        public void AddNgon(Vector2F center, float radius, uint col, int numSegments, float thickness)
        {
            ImGuiNative.ImDrawList_AddNgon(NativePtr, center, radius, col, numSegments, thickness);
        }

        /// <summary>
        ///     Adds the ngon filled using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="numSegments">The num segments</param>
        public void AddNgonFilled(Vector2F center, float radius, uint col, int numSegments)
        {
            ImGuiNative.ImDrawList_AddNgonFilled(NativePtr, center, radius, col, numSegments);
        }

        /// <summary>
        ///     Adds the polyline using the specified points
        /// </summary>
        /// <param name="points">The points</param>
        /// <param name="numPoints">The num points</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <param name="thickness">The thickness</param>
        public void AddPolyline(ref Vector2F points, int numPoints, uint col, ImDrawFlags flags, float thickness)
        {
            ImGuiNative.ImDrawList_AddPolyline(NativePtr, ref points, numPoints, col, flags, thickness);
        }

        /// <summary>
        ///     Adds the quad using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="col">The col</param>
        public void AddQuad(Vector2F p1, Vector2F p2, Vector2F p3, Vector2F p4, uint col)
        {
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddQuad(NativePtr, p1, p2, p3, p4, col, thickness);
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
        public void AddQuad(Vector2F p1, Vector2F p2, Vector2F p3, Vector2F p4, uint col, float thickness)
        {
            ImGuiNative.ImDrawList_AddQuad(NativePtr, p1, p2, p3, p4, col, thickness);
        }

        /// <summary>
        ///     Adds the quad filled using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="col">The col</param>
        public void AddQuadFilled(Vector2F p1, Vector2F p2, Vector2F p3, Vector2F p4, uint col)
        {
            ImGuiNative.ImDrawList_AddQuadFilled(NativePtr, p1, p2, p3, p4, col);
        }

        /// <summary>
        ///     Adds the rect using the specified p min
        /// </summary>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="col">The col</param>
        public void AddRect(Vector2F pMin, Vector2F pMax, uint col)
        {
            float rounding = 0.0f;
            ImDrawFlags flags = 0;
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddRect(NativePtr, pMin, pMax, col, rounding, flags, thickness);
        }

        /// <summary>
        ///     Adds the rect using the specified p min
        /// </summary>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        public void AddRect(Vector2F pMin, Vector2F pMax, uint col, float rounding)
        {
            ImDrawFlags flags = 0;
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddRect(NativePtr, pMin, pMax, col, rounding, flags, thickness);
        }

        /// <summary>
        ///     Adds the rect using the specified p min
        /// </summary>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        public void AddRect(Vector2F pMin, Vector2F pMax, uint col, float rounding, ImDrawFlags flags)
        {
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddRect(NativePtr, pMin, pMax, col, rounding, flags, thickness);
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
        public void AddRect(Vector2F pMin, Vector2F pMax, uint col, float rounding, ImDrawFlags flags, float thickness)
        {
            ImGuiNative.ImDrawList_AddRect(NativePtr, pMin, pMax, col, rounding, flags, thickness);
        }

        /// <summary>
        ///     Adds the rect filled using the specified p min
        /// </summary>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="col">The col</param>
        public void AddRectFilled(Vector2F pMin, Vector2F pMax, uint col)
        {
            float rounding = 0.0f;
            ImDrawFlags flags = 0;
            ImGuiNative.ImDrawList_AddRectFilled(NativePtr, pMin, pMax, col, rounding, flags);
        }

        /// <summary>
        ///     Adds the rect filled using the specified p min
        /// </summary>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        public void AddRectFilled(Vector2F pMin, Vector2F pMax, uint col, float rounding)
        {
            ImDrawFlags flags = 0;
            ImGuiNative.ImDrawList_AddRectFilled(NativePtr, pMin, pMax, col, rounding, flags);
        }

        /// <summary>
        ///     Adds the rect filled using the specified p min
        /// </summary>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        public void AddRectFilled(Vector2F pMin, Vector2F pMax, uint col, float rounding, ImDrawFlags flags)
        {
            ImGuiNative.ImDrawList_AddRectFilled(NativePtr, pMin, pMax, col, rounding, flags);
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
        public void AddRectFilledMultiColor(Vector2F pMin, Vector2F pMax, uint colUprLeft, uint colUprRight, uint colBotRight, uint colBotLeft)
        {
            ImGuiNative.ImDrawList_AddRectFilledMultiColor(NativePtr, pMin, pMax, colUprLeft, colUprRight, colBotRight, colBotLeft);
        }

        /// <summary>
        ///     Adds the triangle using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="col">The col</param>
        public void AddTriangle(Vector2F p1, Vector2F p2, Vector2F p3, uint col)
        {
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddTriangle(NativePtr, p1, p2, p3, col, thickness);
        }

        /// <summary>
        ///     Adds the triangle using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        public void AddTriangle(Vector2F p1, Vector2F p2, Vector2F p3, uint col, float thickness)
        {
            ImGuiNative.ImDrawList_AddTriangle(NativePtr, p1, p2, p3, col, thickness);
        }

        /// <summary>
        ///     Adds the triangle filled using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="col">The col</param>
        public void AddTriangleFilled(Vector2F p1, Vector2F p2, Vector2F p3, uint col)
        {
            ImGuiNative.ImDrawList_AddTriangleFilled(NativePtr, p1, p2, p3, col);
        }

        /// <summary>
        ///     Channelses the merge
        /// </summary>
        public void ChannelsMerge()
        {
            ImGuiNative.ImDrawList_ChannelsMerge(NativePtr);
        }

        /// <summary>
        ///     Channelses the set current using the specified n
        /// </summary>
        /// <param name="n">The </param>
        public void ChannelsSetCurrent(int n)
        {
            ImGuiNative.ImDrawList_ChannelsSetCurrent(NativePtr, n);
        }

        /// <summary>
        ///     Channelses the split using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        public void ChannelsSplit(int count)
        {
            ImGuiNative.ImDrawList_ChannelsSplit(NativePtr, count);
        }

        /// <summary>
        ///     Clones the output
        /// </summary>
        /// <returns>The im draw list ptr</returns>
        public ImDrawListPtr CloneOutput() => new ImDrawListPtr(ImGuiNative.ImDrawList_CloneOutput(NativePtr));

        /// <summary>
        ///     Gets the clip rect max
        /// </summary>
        /// <returns>The retval</returns>
        public Vector2F GetClipRectMax()
        {
            ImGuiNative.ImDrawList_GetClipRectMax(out Vector2F retval, NativePtr);
            return retval;
        }

        /// <summary>
        ///     Gets the clip rect min
        /// </summary>
        /// <returns>The retval</returns>
        public Vector2F GetClipRectMin()
        {
            ImGuiNative.ImDrawList_GetClipRectMin(out Vector2F retval, NativePtr);
            return retval;
        }

        /// <summary>
        ///     Paths the arc to using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="aMin">The min</param>
        /// <param name="aMax">The max</param>
        public void PathArcTo(Vector2F center, float radius, float aMin, float aMax)
        {
            int numSegments = 0;
            ImGuiNative.ImDrawList_PathArcTo(NativePtr, center, radius, aMin, aMax, numSegments);
        }

        /// <summary>
        ///     Paths the arc to using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="aMin">The min</param>
        /// <param name="aMax">The max</param>
        /// <param name="numSegments">The num segments</param>
        public void PathArcTo(Vector2F center, float radius, float aMin, float aMax, int numSegments)
        {
            ImGuiNative.ImDrawList_PathArcTo(NativePtr, center, radius, aMin, aMax, numSegments);
        }

        /// <summary>
        ///     Paths the arc to fast using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="aMinOf12">The min of 12</param>
        /// <param name="aMaxOf12">The max of 12</param>
        public void PathArcToFast(Vector2F center, float radius, int aMinOf12, int aMaxOf12)
        {
            ImGuiNative.ImDrawList_PathArcToFast(NativePtr, center, radius, aMinOf12, aMaxOf12);
        }

        /// <summary>
        ///     Paths the bezier cubic curve to using the specified p 2
        /// </summary>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        public void PathBezierCubicCurveTo(Vector2F p2, Vector2F p3, Vector2F p4)
        {
            int numSegments = 0;
            ImGuiNative.ImDrawList_PathBezierCubicCurveTo(NativePtr, p2, p3, p4, numSegments);
        }

        /// <summary>
        ///     Paths the bezier cubic curve to using the specified p 2
        /// </summary>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="numSegments">The num segments</param>
        public void PathBezierCubicCurveTo(Vector2F p2, Vector2F p3, Vector2F p4, int numSegments)
        {
            ImGuiNative.ImDrawList_PathBezierCubicCurveTo(NativePtr, p2, p3, p4, numSegments);
        }

        /// <summary>
        ///     Paths the bezier quadratic curve to using the specified p 2
        /// </summary>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        public void PathBezierQuadraticCurveTo(Vector2F p2, Vector2F p3)
        {
            int numSegments = 0;
            ImGuiNative.ImDrawList_PathBezierQuadraticCurveTo(NativePtr, p2, p3, numSegments);
        }

        /// <summary>
        ///     Paths the bezier quadratic curve to using the specified p 2
        /// </summary>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="numSegments">The num segments</param>
        public void PathBezierQuadraticCurveTo(Vector2F p2, Vector2F p3, int numSegments)
        {
            ImGuiNative.ImDrawList_PathBezierQuadraticCurveTo(NativePtr, p2, p3, numSegments);
        }

        /// <summary>
        ///     Paths the clear
        /// </summary>
        public void PathClear()
        {
            ImGuiNative.ImDrawList_PathClear(NativePtr);
        }

        /// <summary>
        ///     Paths the fill convex using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        public void PathFillConvex(uint col)
        {
            ImGuiNative.ImDrawList_PathFillConvex(NativePtr, col);
        }

        /// <summary>
        ///     Paths the line to using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        public void PathLineTo(Vector2F pos)
        {
            ImGuiNative.ImDrawList_PathLineTo(NativePtr, pos);
        }

        /// <summary>
        ///     Paths the line to merge duplicate using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        public void PathLineToMergeDuplicate(Vector2F pos)
        {
            ImGuiNative.ImDrawList_PathLineToMergeDuplicate(NativePtr, pos);
        }

        /// <summary>
        ///     Paths the rect using the specified rect min
        /// </summary>
        /// <param name="rectMin">The rect min</param>
        /// <param name="rectMax">The rect max</param>
        public void PathRect(Vector2F rectMin, Vector2F rectMax)
        {
            float rounding = 0.0f;
            ImDrawFlags flags = 0;
            ImGuiNative.ImDrawList_PathRect(NativePtr, rectMin, rectMax, rounding, flags);
        }

        /// <summary>
        ///     Paths the rect using the specified rect min
        /// </summary>
        /// <param name="rectMin">The rect min</param>
        /// <param name="rectMax">The rect max</param>
        /// <param name="rounding">The rounding</param>
        public void PathRect(Vector2F rectMin, Vector2F rectMax, float rounding)
        {
            ImDrawFlags flags = 0;
            ImGuiNative.ImDrawList_PathRect(NativePtr, rectMin, rectMax, rounding, flags);
        }

        /// <summary>
        ///     Paths the rect using the specified rect min
        /// </summary>
        /// <param name="rectMin">The rect min</param>
        /// <param name="rectMax">The rect max</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        public void PathRect(Vector2F rectMin, Vector2F rectMax, float rounding, ImDrawFlags flags)
        {
            ImGuiNative.ImDrawList_PathRect(NativePtr, rectMin, rectMax, rounding, flags);
        }

        /// <summary>
        ///     Paths the stroke using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        public void PathStroke(uint col)
        {
            ImDrawFlags flags = 0;
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_PathStroke(NativePtr, col, flags, thickness);
        }

        /// <summary>
        ///     Paths the stroke using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        public void PathStroke(uint col, ImDrawFlags flags)
        {
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_PathStroke(NativePtr, col, flags, thickness);
        }

        /// <summary>
        ///     Paths the stroke using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <param name="thickness">The thickness</param>
        public void PathStroke(uint col, ImDrawFlags flags, float thickness)
        {
            ImGuiNative.ImDrawList_PathStroke(NativePtr, col, flags, thickness);
        }

        /// <summary>
        ///     Pops the clip rect
        /// </summary>
        public void PopClipRect()
        {
            ImGuiNative.ImDrawList_PopClipRect(NativePtr);
        }

        /// <summary>
        ///     Pops the texture id
        /// </summary>
        public void PopTextureId()
        {
            ImGuiNative.ImDrawList_PopTextureID(NativePtr);
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
        public void PrimQuadUv(Vector2F a, Vector2F b, Vector2F c, Vector2F d, Vector2F uvA, Vector2F uvB, Vector2F uvC, Vector2F uvD, uint col)
        {
            ImGuiNative.ImDrawList_PrimQuadUV(NativePtr, a, b, c, d, uvA, uvB, uvC, uvD, col);
        }

        /// <summary>
        ///     Prims the rect using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="col">The col</param>
        public void PrimRect(Vector2F a, Vector2F b, uint col)
        {
            ImGuiNative.ImDrawList_PrimRect(NativePtr, a, b, col);
        }

        /// <summary>
        ///     Prims the rect uv using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="uvA">The uv</param>
        /// <param name="uvB">The uv</param>
        /// <param name="col">The col</param>
        public void PrimRectUv(Vector2F a, Vector2F b, Vector2F uvA, Vector2F uvB, uint col)
        {
            ImGuiNative.ImDrawList_PrimRectUV(NativePtr, a, b, uvA, uvB, col);
        }

        /// <summary>
        ///     Prims the reserve using the specified idx count
        /// </summary>
        /// <param name="idxCount">The idx count</param>
        /// <param name="vtxCount">The vtx count</param>
        public void PrimReserve(int idxCount, int vtxCount)
        {
            ImGuiNative.ImDrawList_PrimReserve(NativePtr, idxCount, vtxCount);
        }

        /// <summary>
        ///     Prims the unreserve using the specified idx count
        /// </summary>
        /// <param name="idxCount">The idx count</param>
        /// <param name="vtxCount">The vtx count</param>
        public void PrimUnreserve(int idxCount, int vtxCount)
        {
            ImGuiNative.ImDrawList_PrimUnreserve(NativePtr, idxCount, vtxCount);
        }

        /// <summary>
        ///     Prims the vtx using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="uv">The uv</param>
        /// <param name="col">The col</param>
        public void PrimVtx(Vector2F pos, Vector2F uv, uint col)
        {
            ImGuiNative.ImDrawList_PrimVtx(NativePtr, pos, uv, col);
        }

        /// <summary>
        ///     Prims the write idx using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        public void PrimWriteIdx(ushort idx)
        {
            ImGuiNative.ImDrawList_PrimWriteIdx(NativePtr, idx);
        }

        /// <summary>
        ///     Prims the write vtx using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="uv">The uv</param>
        /// <param name="col">The col</param>
        public void PrimWriteVtx(Vector2F pos, Vector2F uv, uint col)
        {
            ImGuiNative.ImDrawList_PrimWriteVtx(NativePtr, pos, uv, col);
        }

        /// <summary>
        ///     Pushes the clip rect using the specified clip rect min
        /// </summary>
        /// <param name="clipRectMin">The clip rect min</param>
        /// <param name="clipRectMax">The clip rect max</param>
        public void PushClipRect(Vector2F clipRectMin, Vector2F clipRectMax)
        {
            byte intersectWithCurrentClipRect = 0;
            ImGuiNative.ImDrawList_PushClipRect(NativePtr, clipRectMin, clipRectMax, intersectWithCurrentClipRect);
        }

        /// <summary>
        ///     Pushes the clip rect using the specified clip rect min
        /// </summary>
        /// <param name="clipRectMin">The clip rect min</param>
        /// <param name="clipRectMax">The clip rect max</param>
        /// <param name="intersectWithCurrentClipRect">The intersect with current clip rect</param>
        public void PushClipRect(Vector2F clipRectMin, Vector2F clipRectMax, bool intersectWithCurrentClipRect)
        {
            byte nativeIntersectWithCurrentClipRect = intersectWithCurrentClipRect ? (byte) 1 : (byte) 0;
            ImGuiNative.ImDrawList_PushClipRect(NativePtr, clipRectMin, clipRectMax, nativeIntersectWithCurrentClipRect);
        }

        /// <summary>
        ///     Pushes the clip rect full screen
        /// </summary>
        public void PushClipRectFullScreen()
        {
            ImGuiNative.ImDrawList_PushClipRectFullScreen(NativePtr);
        }

        /// <summary>
        ///     Pushes the texture id using the specified texture id
        /// </summary>
        /// <param name="textureId">The texture id</param>
        public void PushTextureId(IntPtr textureId)
        {
            ImGuiNative.ImDrawList_PushTextureID(NativePtr, textureId);
        }

        /// <summary>
        ///     Adds the text using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="col">The col</param>
        /// <param name="textBegin">The text begin</param>
        public void AddText(Vector2F pos, uint col, string textBegin)
        {
            ImGuiNative.ImDrawList_AddText_Vec2(NativePtr, pos, col, Encoding.UTF8.GetBytes(textBegin), null);
        }

        /// <summary>
        ///     Adds the text using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="fontSize">The font size</param>
        /// <param name="pos">The pos</param>
        /// <param name="col">The col</param>
        /// <param name="textBegin">The text begin</param>
        public void AddText(ImFontPtr font, float fontSize, Vector2F pos, uint col, string textBegin)
        {
            ImGuiNative.ImDrawList_AddText_FontPtr(NativePtr, font.NativePtr, fontSize, pos, col, Encoding.UTF8.GetBytes(textBegin), null, 0.0f, new Vector4F());
        }
    }
}