// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuizMo.cs
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
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.ImGui.Extras.GuizMo
{
    /// <summary>
    ///     The im guizmo class
    /// </summary>
    public static class ImGuizMo
    {
        /// <summary>
        ///     Allows the axis flip using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        public static void AllowAxisFlip(bool value)
        {
            byte nativeValue = value ? (byte) 1 : (byte) 0;
            ImGuiZmoNative.InternalAllowAxisFlip(nativeValue);
        }

        /// <summary>
        ///     Begins the frame
        /// </summary>
        public static void BeginFrame()
        {
            ImGuiZmoNative.InternalBeginFrame();
        }

        /// <summary>
        ///     Decomposes the matrix to components using the specified matrix
        /// </summary>
        /// <param name="matrix">The matrix</param>
        /// <param name="translation">The translation</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="scale">The scale</param>
        public static void DecomposeMatrixToComponents(ref float[] matrix, ref float[] translation, ref  float[] rotation, ref  float[] scale)
        {
            ImGuiZmoNative.InternalDecomposeMatrixToComponents(matrix, translation, rotation, scale);
        }

        /// <summary>
        ///     Draws the cubes using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="projection">The projection</param>
        /// <param name="matrices">The matrices</param>
        /// <param name="matrixCount">The matrix count</param>
        public static void DrawCubes(ref float view, ref float projection, ref float matrices, int matrixCount)
        {
            ImGuiZmoNative.InternalDrawCubes(view, projection, matrices, matrixCount);
        }

        /// <summary>
        ///     Draws the grid using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="projection">The projection</param>
        /// <param name="matrix">The matrix</param>
        /// <param name="gridSize">The grid size</param>
        public static void DrawGrid(ref float[] view, ref float[] projection, ref float[] matrix, float gridSize)
        {
            ImGuiZmoNative.InternalDrawGrid(view, projection, matrix, gridSize);
        }

        /// <summary>
        ///     Enables the enable
        /// </summary>
        /// <param name="enable">To enable</param>
        public static void Enable(bool enable)
        {
            byte nativeEnable = enable ? (byte) 1 : (byte) 0;
            ImGuiZmoNative.InternalEnable(nativeEnable);
        }

        /// <summary>
        ///     Describes whether is over
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsOver()
        {
            byte ret = ImGuiZmoNative.InternalIsOverNil();
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether is over
        /// </summary>
        /// <param name="op">The op</param>
        /// <returns>The bool</returns>
        public static bool IsOver(Operation op)
        {
            byte ret = ImGuiZmoNative.InternalIsOverOPERATION(op);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether is using
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsUsing()
        {
            byte ret = ImGuiZmoNative.InternalIsUsing();
            return ret != 0;
        }
        
        /// <summary>
        /// Manipulates the view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="projection">The projection</param>
        /// <param name="operation">The operation</param>
        /// <param name="mode">The mode</param>
        /// <param name="matrix">The matrix</param>
        /// <returns>The byte</returns>
        public static byte Manipulate(float[] view, float[] projection, Operation operation, Mode mode, float[] matrix)
        {
            GCHandle viewHandle = GCHandle.Alloc(view, GCHandleType.Pinned);
            GCHandle projectionHandle = GCHandle.Alloc(projection, GCHandleType.Pinned);
            GCHandle matrixHandle = GCHandle.Alloc(matrix, GCHandleType.Pinned);
            try
            {
                IntPtr viewPtr = viewHandle.AddrOfPinnedObject();
                IntPtr projectionPtr = projectionHandle.AddrOfPinnedObject();
                IntPtr matrixPtr = matrixHandle.AddrOfPinnedObject();

                return ImGuiZmoNative.InternalManipulate(viewPtr, projectionPtr, operation, mode, matrixPtr, new IntPtr(), new IntPtr(), new IntPtr(), new IntPtr());
            }
            finally
            {
                if (viewHandle.IsAllocated) viewHandle.Free();
                if (projectionHandle.IsAllocated) projectionHandle.Free();
                if (matrixHandle.IsAllocated) matrixHandle.Free();
            }
        }

        /// <summary>
        ///     Recomposes the matrix from components using the specified translation
        /// </summary>
        /// <param name="translation">The translation</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="scale">The scale</param>
        /// <param name="matrix">The matrix</param>
        public static void RecomposeMatrixFromComponents(ref float[] translation, ref float[] rotation, ref float[] scale, ref float[] matrix)
        {
            ImGuiZmoNative.InternalRecomposeMatrixFromComponents( translation,  rotation,  scale,  matrix);
        }

        /// <summary>
        ///     Sets the draw list
        /// </summary>
        public static void SetDrawList()
        {
            ImGuiZmoNative.InternalSetDrawlist(new IntPtr());
        }

        /// <summary>
        ///     Sets the drawlist using the specified drawlist
        /// </summary>
        /// <param name="drawList">The draw list</param>
        public static void SetDrawList(ImDrawList drawList)
        {
            IntPtr drawListPtr = Marshal.AllocHGlobal(Marshal.SizeOf(drawList));
            Marshal.StructureToPtr(drawList, drawListPtr, false);
            ImGuiZmoNative.InternalSetDrawlist(drawListPtr);
        }

        
        /// <summary>
        ///     Sets the gizmo size clip space using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        public static void SetGizmoSizeClipSpace(float value)
        {
            ImGuiZmoNative.InternalSetGizmoSizeClipSpace(value);
        }

        /// <summary>
        ///     Sets the id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        public static void SetId(int id)
        {
            ImGuiZmoNative.InternalSetID(id);
        }

        /// <summary>
        ///     Sets the im gui context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        public static void SetImGuiContext(IntPtr ctx)
        {
            ImGuiZmoNative.InternalSetImGuiContext(ctx);
        }

        /// <summary>
        ///     Sets the orthographic using the specified is orthographic
        /// </summary>
        /// <param name="isOrthographic">The is orthographic</param>
        public static void SetOrthographic(bool isOrthographic)
        {
            byte nativeIsOrthographic = isOrthographic ? (byte) 1 : (byte) 0;
            ImGuiZmoNative.InternalSetOrthographic(nativeIsOrthographic);
        }

        /// <summary>
        ///     Sets the rect using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public static void SetRect(float x, float y, float width, float height)
        {
            ImGuiZmoNative.InternalSetRect(x, y, width, height);
        }

        /// <summary>
        ///     Views to manipulate using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="length">The length</param>
        /// <param name="position">The position</param>
        /// <param name="size">The size</param>
        /// <param name="backgroundColor">The background color</param>
        public static void ViewManipulate(ref float[] view, float length, Vector2 position, Vector2 size, uint backgroundColor)
        {
            ImGuiZmoNative.ImGuizmo_ViewManipulate(view, length, position, size, backgroundColor);
        }
    }
}