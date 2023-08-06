using System;
using System.Numerics;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.ImGui.Structs;

namespace Alis.Core.Graphic.ImGui.Extras.ImGuizmo
{
    /// <summary>
    /// The im guizmo native class
    /// </summary>
    public static unsafe partial class ImGuizmoNative
    {
        /// <summary>
        /// Ims the guizmo allow axis flip using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuizmo_AllowAxisFlip(byte value);
        /// <summary>
        /// Ims the guizmo begin frame
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuizmo_BeginFrame();
        /// <summary>
        /// Ims the guizmo decompose matrix to components using the specified matrix
        /// </summary>
        /// <param name="matrix">The matrix</param>
        /// <param name="translation">The translation</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="scale">The scale</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuizmo_DecomposeMatrixToComponents(float* matrix, float* translation, float* rotation, float* scale);
        /// <summary>
        /// Ims the guizmo draw cubes using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="projection">The projection</param>
        /// <param name="matrices">The matrices</param>
        /// <param name="matrixCount">The matrix count</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuizmo_DrawCubes(float* view, float* projection, float* matrices, int matrixCount);
        /// <summary>
        /// Ims the guizmo draw grid using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="projection">The projection</param>
        /// <param name="matrix">The matrix</param>
        /// <param name="gridSize">The grid size</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuizmo_DrawGrid(float* view, float* projection, float* matrix, float gridSize);
        /// <summary>
        /// Ims the guizmo enable using the specified enable
        /// </summary>
        /// <param name="enable">The enable</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuizmo_Enable(byte enable);
        /// <summary>
        /// Ims the guizmo is over nil
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImGuizmo_IsOverNil();
        /// <summary>
        /// Ims the guizmo is over operation using the specified op
        /// </summary>
        /// <param name="op">The op</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImGuizmo_IsOverOPERATION(OPERATION op);
        /// <summary>
        /// Ims the guizmo is using
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImGuizmo_IsUsing();
        /// <summary>
        /// Ims the guizmo manipulate using the specified view
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
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImGuizmo_Manipulate(float* view, float* projection, OPERATION operation, MODE mode, float* matrix, float* deltaMatrix, float* snap, float* localBounds, float* boundsSnap);
        /// <summary>
        /// Ims the guizmo recompose matrix from components using the specified translation
        /// </summary>
        /// <param name="translation">The translation</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="scale">The scale</param>
        /// <param name="matrix">The matrix</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuizmo_RecomposeMatrixFromComponents(float* translation, float* rotation, float* scale, float* matrix);
        /// <summary>
        /// Ims the guizmo set drawlist using the specified drawlist
        /// </summary>
        /// <param name="drawlist">The drawlist</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuizmo_SetDrawlist(ImDrawList* drawlist);
        /// <summary>
        /// Ims the guizmo set gizmo size clip space using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuizmo_SetGizmoSizeClipSpace(float value);
        /// <summary>
        /// Ims the guizmo set id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuizmo_SetID(int id);
        /// <summary>
        /// Ims the guizmo set im gui context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuizmo_SetImGuiContext(IntPtr ctx);
        /// <summary>
        /// Ims the guizmo set orthographic using the specified is orthographic
        /// </summary>
        /// <param name="isOrthographic">The is orthographic</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuizmo_SetOrthographic(byte isOrthographic);
        /// <summary>
        /// Ims the guizmo set rect using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuizmo_SetRect(float x, float y, float width, float height);
        /// <summary>
        /// Ims the guizmo view manipulate using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="length">The length</param>
        /// <param name="position">The position</param>
        /// <param name="size">The size</param>
        /// <param name="backgroundColor">The background color</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuizmo_ViewManipulate(float* view, float length, Vector2 position, Vector2 size, uint backgroundColor);
    }
}
