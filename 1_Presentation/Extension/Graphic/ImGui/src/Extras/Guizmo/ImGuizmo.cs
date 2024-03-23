// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuizmo.cs
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
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.ImGui.Extras.Guizmo
{
    /// <summary>
    ///     The im guizmo class
    /// </summary>
    public static unsafe class ImGuizmo
    {
        /// <summary>
        ///     Allows the axis flip using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        public static void AllowAxisFlip(bool value)
        {
            byte nativeValue = value ? (byte) 1 : (byte) 0;
            ImGuizmoNative.ImGuizmo_AllowAxisFlip(nativeValue);
        }

        /// <summary>
        ///     Begins the frame
        /// </summary>
        public static void BeginFrame()
        {
            ImGuizmoNative.ImGuizmo_BeginFrame();
        }

        /// <summary>
        ///     Decomposes the matrix to components using the specified matrix
        /// </summary>
        /// <param name="matrix">The matrix</param>
        /// <param name="translation">The translation</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="scale">The scale</param>
        public static void DecomposeMatrixToComponents(ref float matrix, ref float translation, ref float rotation, ref float scale)
        {
            ImGuizmoNative.ImGuizmo_DecomposeMatrixToComponents(matrix, translation, rotation, scale);
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
            ImGuizmoNative.ImGuizmo_DrawCubes(view, projection, matrices, matrixCount);
        }

        /// <summary>
        ///     Draws the grid using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="projection">The projection</param>
        /// <param name="matrix">The matrix</param>
        /// <param name="gridSize">The grid size</param>
        public static void DrawGrid(ref float view, ref float projection, ref float matrix, float gridSize)
        {
            ImGuizmoNative.ImGuizmo_DrawGrid(view, projection, matrix, gridSize);
        }

        /// <summary>
        ///     Enables the enable
        /// </summary>
        /// <param name="enable">The enable</param>
        public static void Enable(bool enable)
        {
            byte nativeEnable = enable ? (byte) 1 : (byte) 0;
            ImGuizmoNative.ImGuizmo_Enable(nativeEnable);
        }

        /// <summary>
        ///     Describes whether is over
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsOver()
        {
            byte ret = ImGuizmoNative.ImGuizmo_IsOverNil();
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether is over
        /// </summary>
        /// <param name="op">The op</param>
        /// <returns>The bool</returns>
        public static bool IsOver(Operation op)
        {
            byte ret = ImGuizmoNative.ImGuizmo_IsOverOPERATION(op);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether is using
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsUsing()
        {
            byte ret = ImGuizmoNative.ImGuizmo_IsUsing();
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether manipulate
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="projection">The projection</param>
        /// <param name="operation">The operation</param>
        /// <param name="mode">The mode</param>
        /// <param name="matrix">The matrix</param>
        /// <returns>The bool</returns>
        public static bool Manipulate(ref float view, ref float projection, Operation operation, Mode mode, ref float matrix)
        {
            float deltaMatrix = 0;
            float snap = 0;
            float localBounds = 0;
            float boundsSnap = 0;
            
            byte ret = ImGuizmoNative.ImGuizmo_Manipulate(view, projection, operation, mode, matrix, deltaMatrix, snap, localBounds, boundsSnap);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether manipulate
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="projection">The projection</param>
        /// <param name="operation">The operation</param>
        /// <param name="mode">The mode</param>
        /// <param name="matrix">The matrix</param>
        /// <param name="deltaMatrix">The delta matrix</param>
        /// <returns>The bool</returns>
        public static bool Manipulate(ref float view, ref float projection, Operation operation, Mode mode, ref float matrix, ref float deltaMatrix)
        {
            float snap = 0;
            float localBounds = 0;
            float boundsSnap = 0;
            
            byte ret = ImGuizmoNative.ImGuizmo_Manipulate(view, projection, operation, mode, matrix, deltaMatrix, snap, localBounds, boundsSnap);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether manipulate
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="projection">The projection</param>
        /// <param name="operation">The operation</param>
        /// <param name="mode">The mode</param>
        /// <param name="matrix">The matrix</param>
        /// <param name="deltaMatrix">The delta matrix</param>
        /// <param name="snap">The snap</param>
        /// <returns>The bool</returns>
        public static bool Manipulate(ref float view, ref float projection, Operation operation, Mode mode, ref float matrix, ref float deltaMatrix, ref float snap)
        {
            float localBounds = 0;
            float boundsSnap = 0;
            byte ret = ImGuizmoNative.ImGuizmo_Manipulate(view, projection, operation, mode, matrix, deltaMatrix, snap, localBounds, boundsSnap);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether manipulate
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="projection">The projection</param>
        /// <param name="operation">The operation</param>
        /// <param name="mode">The mode</param>
        /// <param name="matrix">The matrix</param>
        /// <param name="deltaMatrix">The delta matrix</param>
        /// <param name="snap">The snap</param>
        /// <param name="localBounds">The local bounds</param>
        /// <returns>The bool</returns>
        public static bool Manipulate(ref float view, ref float projection, Operation operation, Mode mode, ref float matrix, ref float deltaMatrix, ref float snap, ref float localBounds)
        {
            float boundsSnap = 0;
            byte ret = ImGuizmoNative.ImGuizmo_Manipulate(view, projection, operation, mode, matrix, deltaMatrix, snap, localBounds, boundsSnap);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether manipulate
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="projection">The projection</param>
        /// <param name="operation">The operation</param>
        /// <param name="mode">The mode</param>
        /// <param name="matrix">The matrix</param>
        /// <param name="deltaMatrix">The delta matrix</param>
        /// <param name="snap">The snap</param>
        /// <param name="localBounds">The local bounds</param>
        /// <param name="boundsSnap">The bounds snap</param>
        /// <returns>The bool</returns>
        public static bool Manipulate(ref float view, ref float projection, Operation operation, Mode mode, ref float matrix, ref float deltaMatrix, ref float snap, ref float localBounds, ref float boundsSnap)
        {
            byte ret = ImGuizmoNative.ImGuizmo_Manipulate(view, projection, operation, mode, matrix, deltaMatrix, snap, localBounds, boundsSnap);
            return ret != 0;
        }

        /// <summary>
        ///     Recomposes the matrix from components using the specified translation
        /// </summary>
        /// <param name="translation">The translation</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="scale">The scale</param>
        /// <param name="matrix">The matrix</param>
        public static void RecomposeMatrixFromComponents(ref float translation, ref float rotation, ref float scale, ref float matrix)
        {
            ImGuizmoNative.ImGuizmo_RecomposeMatrixFromComponents(translation, rotation, scale, matrix);
        }

        /// <summary>
        ///     Sets the drawlist
        /// </summary>
        public static void SetDrawlist()
        {
            ImDrawList* drawlist = null;
            ImGuizmoNative.ImGuizmo_SetDrawlist(drawlist);
        }

        /// <summary>
        ///     Sets the drawlist using the specified drawlist
        /// </summary>
        /// <param name="drawlist">The drawlist</param>
        public static void SetDrawlist(ImDrawListPtr drawlist)
        {
            ImDrawList* nativeDrawlist = drawlist.NativePtr;
            ImGuizmoNative.ImGuizmo_SetDrawlist(nativeDrawlist);
        }

        /// <summary>
        ///     Sets the gizmo size clip space using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        public static void SetGizmoSizeClipSpace(float value)
        {
            ImGuizmoNative.ImGuizmo_SetGizmoSizeClipSpace(value);
        }

        /// <summary>
        ///     Sets the id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        public static void SetId(int id)
        {
            ImGuizmoNative.ImGuizmo_SetID(id);
        }

        /// <summary>
        ///     Sets the im gui context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        public static void SetImGuiContext(IntPtr ctx)
        {
            ImGuizmoNative.ImGuizmo_SetImGuiContext(ctx);
        }

        /// <summary>
        ///     Sets the orthographic using the specified is orthographic
        /// </summary>
        /// <param name="isOrthographic">The is orthographic</param>
        public static void SetOrthographic(bool isOrthographic)
        {
            byte nativeIsOrthographic = isOrthographic ? (byte) 1 : (byte) 0;
            ImGuizmoNative.ImGuizmo_SetOrthographic(nativeIsOrthographic);
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
            ImGuizmoNative.ImGuizmo_SetRect(x, y, width, height);
        }

        /// <summary>
        ///     Views the manipulate using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="length">The length</param>
        /// <param name="position">The position</param>
        /// <param name="size">The size</param>
        /// <param name="backgroundColor">The background color</param>
        public static void ViewManipulate(ref float view, float length, Vector2 position, Vector2 size, uint backgroundColor)
        {
            ImGuizmoNative.ImGuizmo_ViewManipulate(view, length, position, size, backgroundColor);
        }
    }
}