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
using System.Numerics;

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    ///     The im draw list ptr
    /// </summary>
    public unsafe partial struct ImDrawListPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImDrawList* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImDrawListPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImDrawListPtr(ImDrawList* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImDrawListPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImDrawListPtr(IntPtr nativePtr) => NativePtr = (ImDrawList*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawListPtr(ImDrawList* nativePtr) => new ImDrawListPtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawList*(ImDrawListPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawListPtr(IntPtr nativePtr) => new ImDrawListPtr(nativePtr);

        /// <summary>
        ///     Gets the value of the cmd buffer
        /// </summary>
        public ImPtrVector<ImDrawCmdPtr> CmdBuffer => new ImPtrVector<ImDrawCmdPtr>(NativePtr->CmdBuffer, Unsafe.SizeOf<ImDrawCmd>());

        /// <summary>
        ///     Gets the value of the idx buffer
        /// </summary>
        public ImVector<ushort> IdxBuffer => new ImVector<ushort>(NativePtr->IdxBuffer);

        /// <summary>
        ///     Gets the value of the vtx buffer
        /// </summary>
        public ImPtrVector<ImDrawVertPtr> VtxBuffer => new ImPtrVector<ImDrawVertPtr>(NativePtr->VtxBuffer, Unsafe.SizeOf<ImDrawVert>());

        /// <summary>
        ///     Gets the value of the flags
        /// </summary>
        public ref ImDrawListFlags Flags => ref Unsafe.AsRef<ImDrawListFlags>(&NativePtr->Flags);

        /// <summary>
        ///     Gets the value of the  vtxcurrentidx
        /// </summary>
        public ref uint _VtxCurrentIdx => ref Unsafe.AsRef<uint>(&NativePtr->_VtxCurrentIdx);

        /// <summary>
        ///     Gets the value of the  data
        /// </summary>
        public ref IntPtr _Data => ref Unsafe.AsRef<IntPtr>(&NativePtr->_Data);

        /// <summary>
        ///     Gets the value of the  ownername
        /// </summary>
        public NullTerminatedString _OwnerName => new NullTerminatedString(NativePtr->_OwnerName);

        /// <summary>
        ///     Gets the value of the  vtxwriteptr
        /// </summary>
        public ImDrawVertPtr _VtxWritePtr => new ImDrawVertPtr(NativePtr->_VtxWritePtr);

        /// <summary>
        ///     Gets or sets the value of the  idxwriteptr
        /// </summary>
        public IntPtr _IdxWritePtr
        {
            get => (IntPtr) NativePtr->_IdxWritePtr;
            set => NativePtr->_IdxWritePtr = (ushort*) value;
        }

        /// <summary>
        ///     Gets the value of the  cliprectstack
        /// </summary>
        public ImVector<Vector4> _ClipRectStack => new ImVector<Vector4>(NativePtr->_ClipRectStack);

        /// <summary>
        ///     Gets the value of the  textureidstack
        /// </summary>
        public ImVector<IntPtr> _TextureIdStack => new ImVector<IntPtr>(NativePtr->_TextureIdStack);

        /// <summary>
        ///     Gets the value of the  path
        /// </summary>
        public ImVector<Vector2> _Path => new ImVector<Vector2>(NativePtr->_Path);

        /// <summary>
        ///     Gets the value of the  cmdheader
        /// </summary>
        public ref ImDrawCmdHeader _CmdHeader => ref Unsafe.AsRef<ImDrawCmdHeader>(&NativePtr->_CmdHeader);

        /// <summary>
        ///     Gets the value of the  splitter
        /// </summary>
        public ref ImDrawListSplitter _Splitter => ref Unsafe.AsRef<ImDrawListSplitter>(&NativePtr->_Splitter);

        /// <summary>
        ///     Gets the value of the  fringescale
        /// </summary>
        public ref float _FringeScale => ref Unsafe.AsRef<float>(&NativePtr->_FringeScale);

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
        public void _ClearFreeMemory()
        {
            ImGuiNative.ImDrawList__ClearFreeMemory(NativePtr);
        }

        /// <summary>
        ///     Ons the changed clip rect
        /// </summary>
        public void _OnChangedClipRect()
        {
            ImGuiNative.ImDrawList__OnChangedClipRect(NativePtr);
        }

        /// <summary>
        ///     Ons the changed texture id
        /// </summary>
        public void _OnChangedTextureID()
        {
            ImGuiNative.ImDrawList__OnChangedTextureID(NativePtr);
        }

        /// <summary>
        ///     Ons the changed vtx offset
        /// </summary>
        public void _OnChangedVtxOffset()
        {
            ImGuiNative.ImDrawList__OnChangedVtxOffset(NativePtr);
        }

        /// <summary>
        ///     Paths the arc to fast ex using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="a_min_sample">The min sample</param>
        /// <param name="a_max_sample">The max sample</param>
        /// <param name="a_step">The step</param>
        public void _PathArcToFastEx(Vector2 center, float radius, int a_min_sample, int a_max_sample, int a_step)
        {
            ImGuiNative.ImDrawList__PathArcToFastEx(NativePtr, center, radius, a_min_sample, a_max_sample, a_step);
        }

        /// <summary>
        ///     Paths the arc to n using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="a_min">The min</param>
        /// <param name="a_max">The max</param>
        /// <param name="num_segments">The num segments</param>
        public void _PathArcToN(Vector2 center, float radius, float a_min, float a_max, int num_segments)
        {
            ImGuiNative.ImDrawList__PathArcToN(NativePtr, center, radius, a_min, a_max, num_segments);
        }

        /// <summary>
        ///     Pops the unused draw cmd
        /// </summary>
        public void _PopUnusedDrawCmd()
        {
            ImGuiNative.ImDrawList__PopUnusedDrawCmd(NativePtr);
        }

        /// <summary>
        ///     Resets the for new frame
        /// </summary>
        public void _ResetForNewFrame()
        {
            ImGuiNative.ImDrawList__ResetForNewFrame(NativePtr);
        }

        /// <summary>
        ///     Tries the merge draw cmds
        /// </summary>
        public void _TryMergeDrawCmds()
        {
            ImGuiNative.ImDrawList__TryMergeDrawCmds(NativePtr);
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
            int num_segments = 0;
            ImGuiNative.ImDrawList_AddBezierCubic(NativePtr, p1, p2, p3, p4, col, thickness, num_segments);
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
        /// <param name="num_segments">The num segments</param>
        public void AddBezierCubic(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, uint col, float thickness, int num_segments)
        {
            ImGuiNative.ImDrawList_AddBezierCubic(NativePtr, p1, p2, p3, p4, col, thickness, num_segments);
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
            int num_segments = 0;
            ImGuiNative.ImDrawList_AddBezierQuadratic(NativePtr, p1, p2, p3, col, thickness, num_segments);
        }

        /// <summary>
        ///     Adds the bezier quadratic using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        /// <param name="num_segments">The num segments</param>
        public void AddBezierQuadratic(Vector2 p1, Vector2 p2, Vector2 p3, uint col, float thickness, int num_segments)
        {
            ImGuiNative.ImDrawList_AddBezierQuadratic(NativePtr, p1, p2, p3, col, thickness, num_segments);
        }

        /// <summary>
        ///     Adds the callback using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="callback_data">The callback data</param>
        public void AddCallback(IntPtr callback, IntPtr callback_data)
        {
            void* native_callback_data = callback_data.ToPointer();
            ImGuiNative.ImDrawList_AddCallback(NativePtr, callback, native_callback_data);
        }

        /// <summary>
        ///     Adds the circle using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        public void AddCircle(Vector2 center, float radius, uint col)
        {
            int num_segments = 0;
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddCircle(NativePtr, center, radius, col, num_segments, thickness);
        }

        /// <summary>
        ///     Adds the circle using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="num_segments">The num segments</param>
        public void AddCircle(Vector2 center, float radius, uint col, int num_segments)
        {
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddCircle(NativePtr, center, radius, col, num_segments, thickness);
        }

        /// <summary>
        ///     Adds the circle using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="num_segments">The num segments</param>
        /// <param name="thickness">The thickness</param>
        public void AddCircle(Vector2 center, float radius, uint col, int num_segments, float thickness)
        {
            ImGuiNative.ImDrawList_AddCircle(NativePtr, center, radius, col, num_segments, thickness);
        }

        /// <summary>
        ///     Adds the circle filled using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        public void AddCircleFilled(Vector2 center, float radius, uint col)
        {
            int num_segments = 0;
            ImGuiNative.ImDrawList_AddCircleFilled(NativePtr, center, radius, col, num_segments);
        }

        /// <summary>
        ///     Adds the circle filled using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="num_segments">The num segments</param>
        public void AddCircleFilled(Vector2 center, float radius, uint col, int num_segments)
        {
            ImGuiNative.ImDrawList_AddCircleFilled(NativePtr, center, radius, col, num_segments);
        }

        /// <summary>
        ///     Adds the convex poly filled using the specified points
        /// </summary>
        /// <param name="points">The points</param>
        /// <param name="num_points">The num points</param>
        /// <param name="col">The col</param>
        public void AddConvexPolyFilled(ref Vector2 points, int num_points, uint col)
        {
            fixed (Vector2* native_points = &points)
            {
                ImGuiNative.ImDrawList_AddConvexPolyFilled(NativePtr, native_points, num_points, col);
            }
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
        /// <param name="user_texture_id">The user texture id</param>
        /// <param name="p_min">The min</param>
        /// <param name="p_max">The max</param>
        public void AddImage(IntPtr user_texture_id, Vector2 p_min, Vector2 p_max)
        {
            Vector2 uv_min = new Vector2();
            Vector2 uv_max = new Vector2(1, 1);
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImage(NativePtr, user_texture_id, p_min, p_max, uv_min, uv_max, col);
        }

        /// <summary>
        ///     Adds the image using the specified user texture id
        /// </summary>
        /// <param name="user_texture_id">The user texture id</param>
        /// <param name="p_min">The min</param>
        /// <param name="p_max">The max</param>
        /// <param name="uv_min">The uv min</param>
        public void AddImage(IntPtr user_texture_id, Vector2 p_min, Vector2 p_max, Vector2 uv_min)
        {
            Vector2 uv_max = new Vector2(1, 1);
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImage(NativePtr, user_texture_id, p_min, p_max, uv_min, uv_max, col);
        }

        /// <summary>
        ///     Adds the image using the specified user texture id
        /// </summary>
        /// <param name="user_texture_id">The user texture id</param>
        /// <param name="p_min">The min</param>
        /// <param name="p_max">The max</param>
        /// <param name="uv_min">The uv min</param>
        /// <param name="uv_max">The uv max</param>
        public void AddImage(IntPtr user_texture_id, Vector2 p_min, Vector2 p_max, Vector2 uv_min, Vector2 uv_max)
        {
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImage(NativePtr, user_texture_id, p_min, p_max, uv_min, uv_max, col);
        }

        /// <summary>
        ///     Adds the image using the specified user texture id
        /// </summary>
        /// <param name="user_texture_id">The user texture id</param>
        /// <param name="p_min">The min</param>
        /// <param name="p_max">The max</param>
        /// <param name="uv_min">The uv min</param>
        /// <param name="uv_max">The uv max</param>
        /// <param name="col">The col</param>
        public void AddImage(IntPtr user_texture_id, Vector2 p_min, Vector2 p_max, Vector2 uv_min, Vector2 uv_max, uint col)
        {
            ImGuiNative.ImDrawList_AddImage(NativePtr, user_texture_id, p_min, p_max, uv_min, uv_max, col);
        }

        /// <summary>
        ///     Adds the image quad using the specified user texture id
        /// </summary>
        /// <param name="user_texture_id">The user texture id</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        public void AddImageQuad(IntPtr user_texture_id, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4)
        {
            Vector2 uv1 = new Vector2();
            Vector2 uv2 = new Vector2(1, 0);
            Vector2 uv3 = new Vector2(1, 1);
            Vector2 uv4 = new Vector2(0, 1);
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImageQuad(NativePtr, user_texture_id, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
        }

        /// <summary>
        ///     Adds the image quad using the specified user texture id
        /// </summary>
        /// <param name="user_texture_id">The user texture id</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="uv1">The uv</param>
        public void AddImageQuad(IntPtr user_texture_id, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, Vector2 uv1)
        {
            Vector2 uv2 = new Vector2(1, 0);
            Vector2 uv3 = new Vector2(1, 1);
            Vector2 uv4 = new Vector2(0, 1);
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImageQuad(NativePtr, user_texture_id, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
        }

        /// <summary>
        ///     Adds the image quad using the specified user texture id
        /// </summary>
        /// <param name="user_texture_id">The user texture id</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="uv1">The uv</param>
        /// <param name="uv2">The uv</param>
        public void AddImageQuad(IntPtr user_texture_id, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, Vector2 uv1, Vector2 uv2)
        {
            Vector2 uv3 = new Vector2(1, 1);
            Vector2 uv4 = new Vector2(0, 1);
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImageQuad(NativePtr, user_texture_id, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
        }

        /// <summary>
        ///     Adds the image quad using the specified user texture id
        /// </summary>
        /// <param name="user_texture_id">The user texture id</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="uv1">The uv</param>
        /// <param name="uv2">The uv</param>
        /// <param name="uv3">The uv</param>
        public void AddImageQuad(IntPtr user_texture_id, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, Vector2 uv1, Vector2 uv2, Vector2 uv3)
        {
            Vector2 uv4 = new Vector2(0, 1);
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImageQuad(NativePtr, user_texture_id, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
        }

        /// <summary>
        ///     Adds the image quad using the specified user texture id
        /// </summary>
        /// <param name="user_texture_id">The user texture id</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="uv1">The uv</param>
        /// <param name="uv2">The uv</param>
        /// <param name="uv3">The uv</param>
        /// <param name="uv4">The uv</param>
        public void AddImageQuad(IntPtr user_texture_id, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, Vector2 uv1, Vector2 uv2, Vector2 uv3, Vector2 uv4)
        {
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImageQuad(NativePtr, user_texture_id, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
        }

        /// <summary>
        ///     Adds the image quad using the specified user texture id
        /// </summary>
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
        public void AddImageQuad(IntPtr user_texture_id, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, Vector2 uv1, Vector2 uv2, Vector2 uv3, Vector2 uv4, uint col)
        {
            ImGuiNative.ImDrawList_AddImageQuad(NativePtr, user_texture_id, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
        }

        /// <summary>
        ///     Adds the image rounded using the specified user texture id
        /// </summary>
        /// <param name="user_texture_id">The user texture id</param>
        /// <param name="p_min">The min</param>
        /// <param name="p_max">The max</param>
        /// <param name="uv_min">The uv min</param>
        /// <param name="uv_max">The uv max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        public void AddImageRounded(IntPtr user_texture_id, Vector2 p_min, Vector2 p_max, Vector2 uv_min, Vector2 uv_max, uint col, float rounding)
        {
            ImDrawFlags flags = 0;
            ImGuiNative.ImDrawList_AddImageRounded(NativePtr, user_texture_id, p_min, p_max, uv_min, uv_max, col, rounding, flags);
        }

        /// <summary>
        ///     Adds the image rounded using the specified user texture id
        /// </summary>
        /// <param name="user_texture_id">The user texture id</param>
        /// <param name="p_min">The min</param>
        /// <param name="p_max">The max</param>
        /// <param name="uv_min">The uv min</param>
        /// <param name="uv_max">The uv max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        public void AddImageRounded(IntPtr user_texture_id, Vector2 p_min, Vector2 p_max, Vector2 uv_min, Vector2 uv_max, uint col, float rounding, ImDrawFlags flags)
        {
            ImGuiNative.ImDrawList_AddImageRounded(NativePtr, user_texture_id, p_min, p_max, uv_min, uv_max, col, rounding, flags);
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
            ImGuiNative.ImDrawList_AddLine(NativePtr, p1, p2, col, thickness);
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
            ImGuiNative.ImDrawList_AddLine(NativePtr, p1, p2, col, thickness);
        }

        /// <summary>
        ///     Adds the ngon using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="num_segments">The num segments</param>
        public void AddNgon(Vector2 center, float radius, uint col, int num_segments)
        {
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddNgon(NativePtr, center, radius, col, num_segments, thickness);
        }

        /// <summary>
        ///     Adds the ngon using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="num_segments">The num segments</param>
        /// <param name="thickness">The thickness</param>
        public void AddNgon(Vector2 center, float radius, uint col, int num_segments, float thickness)
        {
            ImGuiNative.ImDrawList_AddNgon(NativePtr, center, radius, col, num_segments, thickness);
        }

        /// <summary>
        ///     Adds the ngon filled using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="num_segments">The num segments</param>
        public void AddNgonFilled(Vector2 center, float radius, uint col, int num_segments)
        {
            ImGuiNative.ImDrawList_AddNgonFilled(NativePtr, center, radius, col, num_segments);
        }

        /// <summary>
        ///     Adds the polyline using the specified points
        /// </summary>
        /// <param name="points">The points</param>
        /// <param name="num_points">The num points</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <param name="thickness">The thickness</param>
        public void AddPolyline(ref Vector2 points, int num_points, uint col, ImDrawFlags flags, float thickness)
        {
            fixed (Vector2* native_points = &points)
            {
                ImGuiNative.ImDrawList_AddPolyline(NativePtr, native_points, num_points, col, flags, thickness);
            }
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
        public void AddQuad(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, uint col, float thickness)
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
        public void AddQuadFilled(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, uint col)
        {
            ImGuiNative.ImDrawList_AddQuadFilled(NativePtr, p1, p2, p3, p4, col);
        }

        /// <summary>
        ///     Adds the rect using the specified p min
        /// </summary>
        /// <param name="p_min">The min</param>
        /// <param name="p_max">The max</param>
        /// <param name="col">The col</param>
        public void AddRect(Vector2 p_min, Vector2 p_max, uint col)
        {
            float rounding = 0.0f;
            ImDrawFlags flags = 0;
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddRect(NativePtr, p_min, p_max, col, rounding, flags, thickness);
        }

        /// <summary>
        ///     Adds the rect using the specified p min
        /// </summary>
        /// <param name="p_min">The min</param>
        /// <param name="p_max">The max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        public void AddRect(Vector2 p_min, Vector2 p_max, uint col, float rounding)
        {
            ImDrawFlags flags = 0;
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddRect(NativePtr, p_min, p_max, col, rounding, flags, thickness);
        }

        /// <summary>
        ///     Adds the rect using the specified p min
        /// </summary>
        /// <param name="p_min">The min</param>
        /// <param name="p_max">The max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        public void AddRect(Vector2 p_min, Vector2 p_max, uint col, float rounding, ImDrawFlags flags)
        {
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddRect(NativePtr, p_min, p_max, col, rounding, flags, thickness);
        }

        /// <summary>
        ///     Adds the rect using the specified p min
        /// </summary>
        /// <param name="p_min">The min</param>
        /// <param name="p_max">The max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        /// <param name="thickness">The thickness</param>
        public void AddRect(Vector2 p_min, Vector2 p_max, uint col, float rounding, ImDrawFlags flags, float thickness)
        {
            ImGuiNative.ImDrawList_AddRect(NativePtr, p_min, p_max, col, rounding, flags, thickness);
        }

        /// <summary>
        ///     Adds the rect filled using the specified p min
        /// </summary>
        /// <param name="p_min">The min</param>
        /// <param name="p_max">The max</param>
        /// <param name="col">The col</param>
        public void AddRectFilled(Vector2 p_min, Vector2 p_max, uint col)
        {
            float rounding = 0.0f;
            ImDrawFlags flags = 0;
            ImGuiNative.ImDrawList_AddRectFilled(NativePtr, p_min, p_max, col, rounding, flags);
        }

        /// <summary>
        ///     Adds the rect filled using the specified p min
        /// </summary>
        /// <param name="p_min">The min</param>
        /// <param name="p_max">The max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        public void AddRectFilled(Vector2 p_min, Vector2 p_max, uint col, float rounding)
        {
            ImDrawFlags flags = 0;
            ImGuiNative.ImDrawList_AddRectFilled(NativePtr, p_min, p_max, col, rounding, flags);
        }

        /// <summary>
        ///     Adds the rect filled using the specified p min
        /// </summary>
        /// <param name="p_min">The min</param>
        /// <param name="p_max">The max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        public void AddRectFilled(Vector2 p_min, Vector2 p_max, uint col, float rounding, ImDrawFlags flags)
        {
            ImGuiNative.ImDrawList_AddRectFilled(NativePtr, p_min, p_max, col, rounding, flags);
        }

        /// <summary>
        ///     Adds the rect filled multi color using the specified p min
        /// </summary>
        /// <param name="p_min">The min</param>
        /// <param name="p_max">The max</param>
        /// <param name="col_upr_left">The col upr left</param>
        /// <param name="col_upr_right">The col upr right</param>
        /// <param name="col_bot_right">The col bot right</param>
        /// <param name="col_bot_left">The col bot left</param>
        public void AddRectFilledMultiColor(Vector2 p_min, Vector2 p_max, uint col_upr_left, uint col_upr_right, uint col_bot_right, uint col_bot_left)
        {
            ImGuiNative.ImDrawList_AddRectFilledMultiColor(NativePtr, p_min, p_max, col_upr_left, col_upr_right, col_bot_right, col_bot_left);
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
        public void AddTriangle(Vector2 p1, Vector2 p2, Vector2 p3, uint col, float thickness)
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
        public void AddTriangleFilled(Vector2 p1, Vector2 p2, Vector2 p3, uint col)
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
        public ImDrawListPtr CloneOutput()
        {
            ImDrawList* ret = ImGuiNative.ImDrawList_CloneOutput(NativePtr);
            return new ImDrawListPtr(ret);
        }

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImDrawList_destroy(NativePtr);
        }

        /// <summary>
        ///     Gets the clip rect max
        /// </summary>
        /// <returns>The retval</returns>
        public Vector2 GetClipRectMax()
        {
            Vector2 __retval;
            ImGuiNative.ImDrawList_GetClipRectMax(&__retval, NativePtr);
            return __retval;
        }

        /// <summary>
        ///     Gets the clip rect min
        /// </summary>
        /// <returns>The retval</returns>
        public Vector2 GetClipRectMin()
        {
            Vector2 __retval;
            ImGuiNative.ImDrawList_GetClipRectMin(&__retval, NativePtr);
            return __retval;
        }

        /// <summary>
        ///     Paths the arc to using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="a_min">The min</param>
        /// <param name="a_max">The max</param>
        public void PathArcTo(Vector2 center, float radius, float a_min, float a_max)
        {
            int num_segments = 0;
            ImGuiNative.ImDrawList_PathArcTo(NativePtr, center, radius, a_min, a_max, num_segments);
        }

        /// <summary>
        ///     Paths the arc to using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="a_min">The min</param>
        /// <param name="a_max">The max</param>
        /// <param name="num_segments">The num segments</param>
        public void PathArcTo(Vector2 center, float radius, float a_min, float a_max, int num_segments)
        {
            ImGuiNative.ImDrawList_PathArcTo(NativePtr, center, radius, a_min, a_max, num_segments);
        }

        /// <summary>
        ///     Paths the arc to fast using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="a_min_of_12">The min of 12</param>
        /// <param name="a_max_of_12">The max of 12</param>
        public void PathArcToFast(Vector2 center, float radius, int a_min_of_12, int a_max_of_12)
        {
            ImGuiNative.ImDrawList_PathArcToFast(NativePtr, center, radius, a_min_of_12, a_max_of_12);
        }

        /// <summary>
        ///     Paths the bezier cubic curve to using the specified p 2
        /// </summary>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        public void PathBezierCubicCurveTo(Vector2 p2, Vector2 p3, Vector2 p4)
        {
            int num_segments = 0;
            ImGuiNative.ImDrawList_PathBezierCubicCurveTo(NativePtr, p2, p3, p4, num_segments);
        }

        /// <summary>
        ///     Paths the bezier cubic curve to using the specified p 2
        /// </summary>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="num_segments">The num segments</param>
        public void PathBezierCubicCurveTo(Vector2 p2, Vector2 p3, Vector2 p4, int num_segments)
        {
            ImGuiNative.ImDrawList_PathBezierCubicCurveTo(NativePtr, p2, p3, p4, num_segments);
        }

        /// <summary>
        ///     Paths the bezier quadratic curve to using the specified p 2
        /// </summary>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        public void PathBezierQuadraticCurveTo(Vector2 p2, Vector2 p3)
        {
            int num_segments = 0;
            ImGuiNative.ImDrawList_PathBezierQuadraticCurveTo(NativePtr, p2, p3, num_segments);
        }

        /// <summary>
        ///     Paths the bezier quadratic curve to using the specified p 2
        /// </summary>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="num_segments">The num segments</param>
        public void PathBezierQuadraticCurveTo(Vector2 p2, Vector2 p3, int num_segments)
        {
            ImGuiNative.ImDrawList_PathBezierQuadraticCurveTo(NativePtr, p2, p3, num_segments);
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
        public void PathLineTo(Vector2 pos)
        {
            ImGuiNative.ImDrawList_PathLineTo(NativePtr, pos);
        }

        /// <summary>
        ///     Paths the line to merge duplicate using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        public void PathLineToMergeDuplicate(Vector2 pos)
        {
            ImGuiNative.ImDrawList_PathLineToMergeDuplicate(NativePtr, pos);
        }

        /// <summary>
        ///     Paths the rect using the specified rect min
        /// </summary>
        /// <param name="rect_min">The rect min</param>
        /// <param name="rect_max">The rect max</param>
        public void PathRect(Vector2 rect_min, Vector2 rect_max)
        {
            float rounding = 0.0f;
            ImDrawFlags flags = 0;
            ImGuiNative.ImDrawList_PathRect(NativePtr, rect_min, rect_max, rounding, flags);
        }

        /// <summary>
        ///     Paths the rect using the specified rect min
        /// </summary>
        /// <param name="rect_min">The rect min</param>
        /// <param name="rect_max">The rect max</param>
        /// <param name="rounding">The rounding</param>
        public void PathRect(Vector2 rect_min, Vector2 rect_max, float rounding)
        {
            ImDrawFlags flags = 0;
            ImGuiNative.ImDrawList_PathRect(NativePtr, rect_min, rect_max, rounding, flags);
        }

        /// <summary>
        ///     Paths the rect using the specified rect min
        /// </summary>
        /// <param name="rect_min">The rect min</param>
        /// <param name="rect_max">The rect max</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        public void PathRect(Vector2 rect_min, Vector2 rect_max, float rounding, ImDrawFlags flags)
        {
            ImGuiNative.ImDrawList_PathRect(NativePtr, rect_min, rect_max, rounding, flags);
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
        public void PopTextureID()
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
        /// <param name="uv_a">The uv</param>
        /// <param name="uv_b">The uv</param>
        /// <param name="uv_c">The uv</param>
        /// <param name="uv_d">The uv</param>
        /// <param name="col">The col</param>
        public void PrimQuadUV(Vector2 a, Vector2 b, Vector2 c, Vector2 d, Vector2 uv_a, Vector2 uv_b, Vector2 uv_c, Vector2 uv_d, uint col)
        {
            ImGuiNative.ImDrawList_PrimQuadUV(NativePtr, a, b, c, d, uv_a, uv_b, uv_c, uv_d, col);
        }

        /// <summary>
        ///     Prims the rect using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="col">The col</param>
        public void PrimRect(Vector2 a, Vector2 b, uint col)
        {
            ImGuiNative.ImDrawList_PrimRect(NativePtr, a, b, col);
        }

        /// <summary>
        ///     Prims the rect uv using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="uv_a">The uv</param>
        /// <param name="uv_b">The uv</param>
        /// <param name="col">The col</param>
        public void PrimRectUV(Vector2 a, Vector2 b, Vector2 uv_a, Vector2 uv_b, uint col)
        {
            ImGuiNative.ImDrawList_PrimRectUV(NativePtr, a, b, uv_a, uv_b, col);
        }

        /// <summary>
        ///     Prims the reserve using the specified idx count
        /// </summary>
        /// <param name="idx_count">The idx count</param>
        /// <param name="vtx_count">The vtx count</param>
        public void PrimReserve(int idx_count, int vtx_count)
        {
            ImGuiNative.ImDrawList_PrimReserve(NativePtr, idx_count, vtx_count);
        }

        /// <summary>
        ///     Prims the unreserve using the specified idx count
        /// </summary>
        /// <param name="idx_count">The idx count</param>
        /// <param name="vtx_count">The vtx count</param>
        public void PrimUnreserve(int idx_count, int vtx_count)
        {
            ImGuiNative.ImDrawList_PrimUnreserve(NativePtr, idx_count, vtx_count);
        }

        /// <summary>
        ///     Prims the vtx using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="uv">The uv</param>
        /// <param name="col">The col</param>
        public void PrimVtx(Vector2 pos, Vector2 uv, uint col)
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
        public void PrimWriteVtx(Vector2 pos, Vector2 uv, uint col)
        {
            ImGuiNative.ImDrawList_PrimWriteVtx(NativePtr, pos, uv, col);
        }

        /// <summary>
        ///     Pushes the clip rect using the specified clip rect min
        /// </summary>
        /// <param name="clip_rect_min">The clip rect min</param>
        /// <param name="clip_rect_max">The clip rect max</param>
        public void PushClipRect(Vector2 clip_rect_min, Vector2 clip_rect_max)
        {
            byte intersect_with_current_clip_rect = 0;
            ImGuiNative.ImDrawList_PushClipRect(NativePtr, clip_rect_min, clip_rect_max, intersect_with_current_clip_rect);
        }

        /// <summary>
        ///     Pushes the clip rect using the specified clip rect min
        /// </summary>
        /// <param name="clip_rect_min">The clip rect min</param>
        /// <param name="clip_rect_max">The clip rect max</param>
        /// <param name="intersect_with_current_clip_rect">The intersect with current clip rect</param>
        public void PushClipRect(Vector2 clip_rect_min, Vector2 clip_rect_max, bool intersect_with_current_clip_rect)
        {
            byte native_intersect_with_current_clip_rect = intersect_with_current_clip_rect ? (byte) 1 : (byte) 0;
            ImGuiNative.ImDrawList_PushClipRect(NativePtr, clip_rect_min, clip_rect_max, native_intersect_with_current_clip_rect);
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
        /// <param name="texture_id">The texture id</param>
        public void PushTextureID(IntPtr texture_id)
        {
            ImGuiNative.ImDrawList_PushTextureID(NativePtr, texture_id);
        }
    }
}