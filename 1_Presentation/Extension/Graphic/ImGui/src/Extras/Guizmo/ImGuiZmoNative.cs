// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuizmoNative.cs
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

namespace Alis.Extension.Graphic.ImGui.Extras.GuiZmo
{
    /// <summary>
    ///     The im gui z mo native class
    /// </summary>
    public static class ImGuiZmoNative
    {
        /// <summary>
        /// The native library
        /// </summary>
        private const string NativeLibrary = "cimgui";
        
        /// <summary>
        ///     Ims the guizmo allow axis flip using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        [DllImport(NativeLibrary, EntryPoint = "ImGuizmo_AllowAxisFlip", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InternalAllowAxisFlip(byte value);

        /// <summary>
        ///     Ims the guizmo begin frame
        /// </summary>
        [DllImport(NativeLibrary, EntryPoint = "ImGuizmo_BeginFrame", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InternalBeginFrame();

        /// <summary>
        ///     Ims the guizmo decompose matrix to components using the specified matrix
        /// </summary>
        /// <param name="matrix">The matrix</param>
        /// <param name="translation">The translation</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="scale">The scale</param>
        [DllImport(NativeLibrary, EntryPoint = "ImGuizmo_DecomposeMatrixToComponents", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InternalDecomposeMatrixToComponents(float matrix, float translation, float rotation, float scale);

        /// <summary>
        ///     Ims the guizmo draw cubes using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="projection">The projection</param>
        /// <param name="matrices">The matrices</param>
        /// <param name="matrixCount">The matrix count</param>
        [DllImport(NativeLibrary,EntryPoint = "ImGuizmo_DrawCubes", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InternalDrawCubes(float view, float projection, float matrices, int matrixCount);

        /// <summary>
        ///     Ims the guizmo draw grid using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="projection">The projection</param>
        /// <param name="matrix">The matrix</param>
        /// <param name="gridSize">The grid size</param>
        [DllImport(NativeLibrary, EntryPoint = "ImGuizmo_DrawGrid", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InternalDrawGrid(float view, float projection, float matrix, float gridSize);

        /// <summary>
        ///     Ims the guizmo enable using the specified enable
        /// </summary>
        /// <param name="enable">The enable</param>
        [DllImport(NativeLibrary, EntryPoint = "ImGuizmo_Enable", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InternalEnable(byte enable);

        /// <summary>
        ///     Ims the guizmo is over nil
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(NativeLibrary,EntryPoint = "ImGuizmo_IsOverNil", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte InternalIsOverNil();

        /// <summary>
        ///     Ims the guizmo is over operation using the specified op
        /// </summary>
        /// <param name="op">The op</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibrary, EntryPoint = "ImGuizmo_IsOverOPERATION", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte InternalIsOverOPERATION(Operation op);

        /// <summary>
        ///     Ims the guizmo is using
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(NativeLibrary, EntryPoint = "ImGuizmo_IsUsing", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte InternalIsUsing();

        /// <summary>
        ///     Ims the guizmo manipulate using the specified view
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
        /// <returns>The byte</returns>
        [DllImport(NativeLibrary, EntryPoint = "ImGuizmo_Manipulate", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte InternalManipulate(float view, float projection, Operation operation, Mode mode, float matrix, float deltaMatrix, float snap, float localBounds, float boundsSnap);

        /// <summary>
        ///     Ims the guizmo recompose matrix from components using the specified translation
        /// </summary>
        /// <param name="translation">The translation</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="scale">The scale</param>
        /// <param name="matrix">The matrix</param>
        [DllImport(NativeLibrary, EntryPoint = "ImGuizmo_RecomposeMatrixFromComponents", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InternalRecomposeMatrixFromComponents(float translation, float rotation, float scale, float matrix);

        /// <summary>
        ///     Ims the guizmo set drawlist using the specified drawlist
        /// </summary>
        /// <param name="drawlist">The drawlist</param>
        [DllImport(NativeLibrary, EntryPoint = "ImGuizmo_SetDrawlist", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void InternalSetDrawlist(ImDrawList* drawlist);

        /// <summary>
        ///     Ims the guizmo set gizmo size clip space using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        [DllImport(NativeLibrary, EntryPoint = "ImGuizmo_SetGizmoSizeClipSpace", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InternalSetGizmoSizeClipSpace(float value);

        /// <summary>
        ///     Ims the guizmo set id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        [DllImport(NativeLibrary, EntryPoint = "ImGuizmo_SetID", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InternalSetID(int id);

        /// <summary>
        ///     Ims the guizmo set im gui context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        [DllImport(NativeLibrary, EntryPoint = "ImGuizmo_SetImGuiContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InternalSetImGuiContext(IntPtr ctx);

        /// <summary>
        ///     Ims the guizmo set orthographic using the specified is orthographic
        /// </summary>
        /// <param name="isOrthographic">The is orthographic</param>
        [DllImport(NativeLibrary, EntryPoint = "ImGuizmo_SetOrthographic", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InternalSetOrthographic(byte isOrthographic);

        /// <summary>
        ///     Ims the guizmo set rect using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        [DllImport(NativeLibrary, EntryPoint = "ImGuizmo_SetRect", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InternalSetRect(float x, float y, float width, float height);

        /// <summary>
        ///     Ims the guizmo view manipulate using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="length">The length</param>
        /// <param name="position">The position</param>
        /// <param name="size">The size</param>
        /// <param name="backgroundColor">The background color</param>
        [DllImport(NativeLibrary, EntryPoint = "ImGuizmo_ViewManipulate", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InternalViewManipulate(float view, float length, Vector2 position, Vector2 size, uint backgroundColor);
    }
}