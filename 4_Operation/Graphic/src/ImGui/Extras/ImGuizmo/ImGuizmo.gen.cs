using System;
using System.Numerics;
using Alis.Core.Graphic.ImGui.Structs;

namespace ImGuizmoNET
{
    /// <summary>
    /// The im guizmo class
    /// </summary>
    public static unsafe partial class ImGuizmo
    {
        /// <summary>
        /// Allows the axis flip using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        public static void AllowAxisFlip(bool value)
        {
            byte native_value = value ? (byte)1 : (byte)0;
            ImGuizmoNative.ImGuizmo_AllowAxisFlip(native_value);
        }
        /// <summary>
        /// Begins the frame
        /// </summary>
        public static void BeginFrame()
        {
            ImGuizmoNative.ImGuizmo_BeginFrame();
        }
        /// <summary>
        /// Decomposes the matrix to components using the specified matrix
        /// </summary>
        /// <param name="matrix">The matrix</param>
        /// <param name="translation">The translation</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="scale">The scale</param>
        public static void DecomposeMatrixToComponents(ref float matrix, ref float translation, ref float rotation, ref float scale)
        {
            fixed (float* native_matrix = &matrix)
            {
                fixed (float* native_translation = &translation)
                {
                    fixed (float* native_rotation = &rotation)
                    {
                        fixed (float* native_scale = &scale)
                        {
                            ImGuizmoNative.ImGuizmo_DecomposeMatrixToComponents(native_matrix, native_translation, native_rotation, native_scale);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Draws the cubes using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="projection">The projection</param>
        /// <param name="matrices">The matrices</param>
        /// <param name="matrixCount">The matrix count</param>
        public static void DrawCubes(ref float view, ref float projection, ref float matrices, int matrixCount)
        {
            fixed (float* native_view = &view)
            {
                fixed (float* native_projection = &projection)
                {
                    fixed (float* native_matrices = &matrices)
                    {
                        ImGuizmoNative.ImGuizmo_DrawCubes(native_view, native_projection, native_matrices, matrixCount);
                    }
                }
            }
        }
        /// <summary>
        /// Draws the grid using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="projection">The projection</param>
        /// <param name="matrix">The matrix</param>
        /// <param name="gridSize">The grid size</param>
        public static void DrawGrid(ref float view, ref float projection, ref float matrix, float gridSize)
        {
            fixed (float* native_view = &view)
            {
                fixed (float* native_projection = &projection)
                {
                    fixed (float* native_matrix = &matrix)
                    {
                        ImGuizmoNative.ImGuizmo_DrawGrid(native_view, native_projection, native_matrix, gridSize);
                    }
                }
            }
        }
        /// <summary>
        /// Enables the enable
        /// </summary>
        /// <param name="enable">The enable</param>
        public static void Enable(bool enable)
        {
            byte native_enable = enable ? (byte)1 : (byte)0;
            ImGuizmoNative.ImGuizmo_Enable(native_enable);
        }
        /// <summary>
        /// Describes whether is over
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsOver()
        {
            byte ret = ImGuizmoNative.ImGuizmo_IsOverNil();
            return ret != 0;
        }
        /// <summary>
        /// Describes whether is over
        /// </summary>
        /// <param name="op">The op</param>
        /// <returns>The bool</returns>
        public static bool IsOver(OPERATION op)
        {
            byte ret = ImGuizmoNative.ImGuizmo_IsOverOPERATION(op);
            return ret != 0;
        }
        /// <summary>
        /// Describes whether is using
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsUsing()
        {
            byte ret = ImGuizmoNative.ImGuizmo_IsUsing();
            return ret != 0;
        }
        /// <summary>
        /// Describes whether manipulate
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="projection">The projection</param>
        /// <param name="operation">The operation</param>
        /// <param name="mode">The mode</param>
        /// <param name="matrix">The matrix</param>
        /// <returns>The bool</returns>
        public static bool Manipulate(ref float view, ref float projection, OPERATION operation, MODE mode, ref float matrix)
        {
            float* deltaMatrix = null;
            float* snap = null;
            float* localBounds = null;
            float* boundsSnap = null;
            fixed (float* native_view = &view)
            {
                fixed (float* native_projection = &projection)
                {
                    fixed (float* native_matrix = &matrix)
                    {
                        byte ret = ImGuizmoNative.ImGuizmo_Manipulate(native_view, native_projection, operation, mode, native_matrix, deltaMatrix, snap, localBounds, boundsSnap);
                        return ret != 0;
                    }
                }
            }
        }
        /// <summary>
        /// Describes whether manipulate
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="projection">The projection</param>
        /// <param name="operation">The operation</param>
        /// <param name="mode">The mode</param>
        /// <param name="matrix">The matrix</param>
        /// <param name="deltaMatrix">The delta matrix</param>
        /// <returns>The bool</returns>
        public static bool Manipulate(ref float view, ref float projection, OPERATION operation, MODE mode, ref float matrix, ref float deltaMatrix)
        {
            float* snap = null;
            float* localBounds = null;
            float* boundsSnap = null;
            fixed (float* native_view = &view)
            {
                fixed (float* native_projection = &projection)
                {
                    fixed (float* native_matrix = &matrix)
                    {
                        fixed (float* native_deltaMatrix = &deltaMatrix)
                        {
                            byte ret = ImGuizmoNative.ImGuizmo_Manipulate(native_view, native_projection, operation, mode, native_matrix, native_deltaMatrix, snap, localBounds, boundsSnap);
                            return ret != 0;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Describes whether manipulate
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="projection">The projection</param>
        /// <param name="operation">The operation</param>
        /// <param name="mode">The mode</param>
        /// <param name="matrix">The matrix</param>
        /// <param name="deltaMatrix">The delta matrix</param>
        /// <param name="snap">The snap</param>
        /// <returns>The bool</returns>
        public static bool Manipulate(ref float view, ref float projection, OPERATION operation, MODE mode, ref float matrix, ref float deltaMatrix, ref float snap)
        {
            float* localBounds = null;
            float* boundsSnap = null;
            fixed (float* native_view = &view)
            {
                fixed (float* native_projection = &projection)
                {
                    fixed (float* native_matrix = &matrix)
                    {
                        fixed (float* native_deltaMatrix = &deltaMatrix)
                        {
                            fixed (float* native_snap = &snap)
                            {
                                byte ret = ImGuizmoNative.ImGuizmo_Manipulate(native_view, native_projection, operation, mode, native_matrix, native_deltaMatrix, native_snap, localBounds, boundsSnap);
                                return ret != 0;
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Describes whether manipulate
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
        public static bool Manipulate(ref float view, ref float projection, OPERATION operation, MODE mode, ref float matrix, ref float deltaMatrix, ref float snap, ref float localBounds)
        {
            float* boundsSnap = null;
            fixed (float* native_view = &view)
            {
                fixed (float* native_projection = &projection)
                {
                    fixed (float* native_matrix = &matrix)
                    {
                        fixed (float* native_deltaMatrix = &deltaMatrix)
                        {
                            fixed (float* native_snap = &snap)
                            {
                                fixed (float* native_localBounds = &localBounds)
                                {
                                    byte ret = ImGuizmoNative.ImGuizmo_Manipulate(native_view, native_projection, operation, mode, native_matrix, native_deltaMatrix, native_snap, native_localBounds, boundsSnap);
                                    return ret != 0;
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Describes whether manipulate
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
        public static bool Manipulate(ref float view, ref float projection, OPERATION operation, MODE mode, ref float matrix, ref float deltaMatrix, ref float snap, ref float localBounds, ref float boundsSnap)
        {
            fixed (float* native_view = &view)
            {
                fixed (float* native_projection = &projection)
                {
                    fixed (float* native_matrix = &matrix)
                    {
                        fixed (float* native_deltaMatrix = &deltaMatrix)
                        {
                            fixed (float* native_snap = &snap)
                            {
                                fixed (float* native_localBounds = &localBounds)
                                {
                                    fixed (float* native_boundsSnap = &boundsSnap)
                                    {
                                        byte ret = ImGuizmoNative.ImGuizmo_Manipulate(native_view, native_projection, operation, mode, native_matrix, native_deltaMatrix, native_snap, native_localBounds, native_boundsSnap);
                                        return ret != 0;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Recomposes the matrix from components using the specified translation
        /// </summary>
        /// <param name="translation">The translation</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="scale">The scale</param>
        /// <param name="matrix">The matrix</param>
        public static void RecomposeMatrixFromComponents(ref float translation, ref float rotation, ref float scale, ref float matrix)
        {
            fixed (float* native_translation = &translation)
            {
                fixed (float* native_rotation = &rotation)
                {
                    fixed (float* native_scale = &scale)
                    {
                        fixed (float* native_matrix = &matrix)
                        {
                            ImGuizmoNative.ImGuizmo_RecomposeMatrixFromComponents(native_translation, native_rotation, native_scale, native_matrix);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Sets the drawlist
        /// </summary>
        public static void SetDrawlist()
        {
            ImDrawList* drawlist = null;
            ImGuizmoNative.ImGuizmo_SetDrawlist(drawlist);
        }
        /// <summary>
        /// Sets the drawlist using the specified drawlist
        /// </summary>
        /// <param name="drawlist">The drawlist</param>
        public static void SetDrawlist(ImDrawListPtr drawlist)
        {
            ImDrawList* native_drawlist = drawlist.NativePtr;
            ImGuizmoNative.ImGuizmo_SetDrawlist(native_drawlist);
        }
        /// <summary>
        /// Sets the gizmo size clip space using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        public static void SetGizmoSizeClipSpace(float value)
        {
            ImGuizmoNative.ImGuizmo_SetGizmoSizeClipSpace(value);
        }
        /// <summary>
        /// Sets the id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        public static void SetID(int id)
        {
            ImGuizmoNative.ImGuizmo_SetID(id);
        }
        /// <summary>
        /// Sets the im gui context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        public static void SetImGuiContext(IntPtr ctx)
        {
            ImGuizmoNative.ImGuizmo_SetImGuiContext(ctx);
        }
        /// <summary>
        /// Sets the orthographic using the specified is orthographic
        /// </summary>
        /// <param name="isOrthographic">The is orthographic</param>
        public static void SetOrthographic(bool isOrthographic)
        {
            byte native_isOrthographic = isOrthographic ? (byte)1 : (byte)0;
            ImGuizmoNative.ImGuizmo_SetOrthographic(native_isOrthographic);
        }
        /// <summary>
        /// Sets the rect using the specified x
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
        /// Views the manipulate using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="length">The length</param>
        /// <param name="position">The position</param>
        /// <param name="size">The size</param>
        /// <param name="backgroundColor">The background color</param>
        public static void ViewManipulate(ref float view, float length, Vector2 position, Vector2 size, uint backgroundColor)
        {
            fixed (float* native_view = &view)
            {
                ImGuizmoNative.ImGuizmo_ViewManipulate(native_view, length, position, size, backgroundColor);
            }
        }
    }
}
