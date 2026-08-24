// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawListPtrExecutionTests.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Executes the native-backed wrappers of the ImDrawListPtr struct against the real
    ///     cimgui library. Every test obtains a live window draw list through a real
    ///     NewFrame/Begin cycle and destroys the context in finally.
    /// </summary>
    public class ImDrawListPtrExecutionTests
    {
        /// <summary>
        ///     The no load mode of the dyld dynamic loader
        /// </summary>
        private const int RtlNoLoad = 0x10;

        /// <summary>
        ///     The dyld image count
        /// </summary>
        /// <returns>The int</returns>
        [ExcludeFromCodeCoverage]
        [DllImport("libSystem.dylib", EntryPoint = "_dyld_image_count")]
        private static extern int DyldImageCount();

        /// <summary>
        ///     The dyld get image name
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [ExcludeFromCodeCoverage]
        [DllImport("libSystem.dylib", EntryPoint = "_dyld_get_image_name")]
        private static extern IntPtr DyldGetImageName(int index);

        /// <summary>
        ///     Opens an already loaded dynamic library
        /// </summary>
        /// <param name="path">The image path</param>
        /// <param name="mode">The open mode</param>
        /// <returns>The library handle</returns>
        [ExcludeFromCodeCoverage]
        [DllImport("libSystem.dylib", EntryPoint = "dlopen")]
        private static extern IntPtr DlOpen(string path, int mode);

        /// <summary>
        ///     Resolves the address of an exported symbol inside a loaded library
        /// </summary>
        /// <param name="handle">The library handle</param>
        /// <param name="symbol">The symbol name</param>
        /// <returns>The symbol address</returns>
        [ExcludeFromCodeCoverage]
        [DllImport("libSystem.dylib", EntryPoint = "dlsym")]
        private static extern IntPtr Dlsym(IntPtr handle, string symbol);

        /// <summary>
        ///     Returns information about the loaded image that owns the given address
        /// </summary>
        /// <param name="address">The address to resolve</param>
        /// <param name="info">The image information</param>
        /// <returns>The result</returns>
        [ExcludeFromCodeCoverage]
        [DllImport("libSystem.dylib", EntryPoint = "dladdr")]
        private static extern int DlAddr(IntPtr address, ref DlInfo info);

        /// <summary>
        ///     The image information returned by the dladdr call
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct DlInfo
        {
            /// <summary>
            ///     The file name of the loaded image
            /// </summary>
            public IntPtr FileName;

            /// <summary>
            ///     The base address of the loaded image
            /// </summary>
            public IntPtr Base;

            /// <summary>
            ///     The name of the nearest symbol
            /// </summary>
            public IntPtr SymbolName;

            /// <summary>
            ///     The address of the nearest symbol
            /// </summary>
            public IntPtr SymbolAddress;
        }

        /// <summary>
        ///     Creates a raw ImGui context and binds it as the current context.
        /// </summary>
        /// <returns>The created context pointer</returns>
        private static IntPtr CreateContext()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            ImGuiNative.igSetCurrentContext(ctx);
            return ctx;
        }

        /// <summary>
        ///     Creates an ImGui context ready for a real frame: the native context slot of every
        ///     loaded cimgui image is synchronized, a display size is written into the io struct
        ///     and the font atlas is built so that igNewFrame can run without aborting.
        /// </summary>
        /// <returns>The created context pointer</returns>
        private static IntPtr CreateFramedContext()
        {
            IntPtr ctx = CreateContext();
            SyncContextSlots(ctx);
            IntPtr ioPtr = ImGuiNative.igGetIO();
            Marshal.StructureToPtr(1280.0f, IntPtr.Add(ioPtr, 8), false);
            Marshal.StructureToPtr(720.0f, IntPtr.Add(ioPtr, 12), false);
            IntPtr fontsPtr = Marshal.ReadIntPtr(ioPtr, 80);
            ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32(fontsPtr, out IntPtr _, out int _, out int _, out int _);
            return ctx;
        }

        /// <summary>
        ///     Synchronizes the ImGui context pointer of every loaded cimgui image so that a frame
        ///     started through one image copy is visible to all the other copies. The GImGui slot is
        ///     resolved through the exported symbol of each image instead of a hardcoded offset, which
        ///     varies between the x64 and arm64 slices of the native library. The handle opened with
        ///     RtlNoLoad is never closed because dlclose can unload the image, and the resolved address
        ///     is verified with dladdr before the write so a stale slot can never fault the test host.
        /// </summary>
        /// <param name="imgui">The imgui context</param>
        private static void SyncContextSlots(IntPtr imgui)
        {
            int count = DyldImageCount();

            for (int i = 0; i < count; i++)
            {
                string name = Marshal.PtrToStringAnsi(DyldGetImageName(i));

                if (name != null && name.Contains("cimgui"))
                {
                    IntPtr handle = DlOpen(name, RtlNoLoad);

                    if (handle != IntPtr.Zero)
                    {
                        IntPtr slot = Dlsym(handle, "GImGui");

                        if (slot != IntPtr.Zero && IsLoadedCimgui(slot))
                        {
                            Marshal.WriteIntPtr(slot, imgui);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Verifies that the given address belongs to a currently loaded cimgui image, so that a stale
        ///     symbol address can never trigger an access violation while synchronizing the context slot.
        /// </summary>
        /// <param name="address">The resolved symbol address</param>
        /// <returns>The bool</returns>
        private static bool IsLoadedCimgui(IntPtr address)
        {
            DlInfo info = new DlInfo();

            if (DlAddr(address, ref info) == 0)
            {
                return false;
            }

            string fileName = Marshal.PtrToStringAnsi(info.FileName);
            return fileName != null && fileName.Contains("cimgui");
        }

        /// <summary>
        ///     Opens a framed window and returns the live window draw list.
        /// </summary>
        /// <param name="ctx">The framed context</param>
        /// <param name="windowName">The window name</param>
        /// <returns>The window draw list</returns>
        private static ImDrawListPtr BeginWindow(IntPtr ctx, string windowName)
        {
            ImGuiNative.igNewFrame();
            ImGui.Begin(windowName);
            return ImGui.GetWindowDrawList();
        }

        /// <summary>
        ///     Verifies every shape primitive executes inside a framed window without throwing
        ///     and produces vertices in the window draw list.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DrawPrimitives_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImDrawListPtr drawList = BeginWindow(ctx, "dlp-primitives");
                Vector2F p0 = new Vector2F(10, 10);
                Vector2F p1 = new Vector2F(50, 10);
                Vector2F p2 = new Vector2F(50, 50);
                Vector2F p3 = new Vector2F(10, 50);
                uint col = 0xFFFFFFFF;
                drawList.AddLine(p0, p1, col);
                drawList.AddLine(p0, p1, col, 2.0f);
                drawList.AddRect(p0, p2, col);
                drawList.AddRect(p0, p2, col, 2.0f);
                drawList.AddRect(p0, p2, col, 2.0f, ImDrawFlags.None);
                drawList.AddRect(p0, p2, col, 2.0f, ImDrawFlags.None, 2.0f);
                drawList.AddRectFilled(p0, p2, col);
                drawList.AddRectFilled(p0, p2, col, 2.0f);
                drawList.AddRectFilled(p0, p2, col, 2.0f, ImDrawFlags.None);
                drawList.AddRectFilledMultiColor(p0, p2, col, col, col, col);
                drawList.AddQuad(p0, p1, p2, p3, col);
                drawList.AddQuad(p0, p1, p2, p3, col, 2.0f);
                drawList.AddQuadFilled(p0, p1, p2, p3, col);
                drawList.AddTriangle(p0, p1, p2, col);
                drawList.AddTriangle(p0, p1, p2, col, 2.0f);
                drawList.AddTriangleFilled(p0, p1, p2, col);
                drawList.AddCircle(p0, 8.0f, col);
                drawList.AddCircle(p0, 8.0f, col, 12);
                drawList.AddCircle(p0, 8.0f, col, 12, 2.0f);
                drawList.AddCircleFilled(p0, 8.0f, col);
                drawList.AddCircleFilled(p0, 8.0f, col, 12);
                drawList.AddNgon(p0, 8.0f, col, 6);
                drawList.AddNgon(p0, 8.0f, col, 6, 2.0f);
                drawList.AddNgonFilled(p0, 8.0f, col, 6);
                drawList.AddBezierCubic(p0, p1, p2, p3, col, 1.0f);
                drawList.AddBezierCubic(p0, p1, p2, p3, col, 1.0f, 12);
                drawList.AddBezierQuadratic(p0, p1, p2, col, 1.0f);
                drawList.AddBezierQuadratic(p0, p1, p2, col, 1.0f, 12);
                Assert.True(drawList.VtxBuffer.Size > 0);
                Assert.True(drawList.IdxBuffer.Size > 0);
                Assert.True(drawList.CmdBuffer.Size > 0);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every polyline and convex polygon overload executes inside a framed
        ///     window against a pinned point array.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Polyline_And_ConvexPoly_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImDrawListPtr drawList = BeginWindow(ctx, "dlp-polyline");
                Vector2F[] points = { new Vector2F(10, 10), new Vector2F(40, 10), new Vector2F(40, 40) };
                GCHandle handle = GCHandle.Alloc(points, GCHandleType.Pinned);
                try
                {
                    drawList.AddPolyline(ref points[0], 3, 0xFFFFFFFF, ImDrawFlags.None, 2.0f);
                    drawList.AddConvexPolyFilled(ref points[0], 3, 0xFFFFFFFF);
                }
                finally
                {
                    handle.Free();
                }

                Assert.True(drawList.VtxBuffer.Size > 0);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every image overload executes inside a framed window without throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddImage_AllOverloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImDrawListPtr drawList = BeginWindow(ctx, "dlp-images");
                Vector2F p0 = new Vector2F(10, 10);
                Vector2F p1 = new Vector2F(40, 10);
                Vector2F p2 = new Vector2F(40, 40);
                Vector2F p3 = new Vector2F(10, 40);
                Vector2F uv0 = new Vector2F();
                Vector2F uv1 = new Vector2F(1, 0);
                Vector2F uv2 = new Vector2F(1, 1);
                Vector2F uv3 = new Vector2F(0, 1);
                drawList.AddImage(IntPtr.Zero, p0, p1);
                drawList.AddImage(IntPtr.Zero, p0, p1, uv0);
                drawList.AddImage(IntPtr.Zero, p0, p1, uv0, uv2);
                drawList.AddImage(IntPtr.Zero, p0, p1, uv0, uv2, 0xFFFFFFFF);
                drawList.AddImageQuad(IntPtr.Zero, p0, p1, p2, p3);
                drawList.AddImageQuad(IntPtr.Zero, p0, p1, p2, p3, uv0);
                drawList.AddImageQuad(IntPtr.Zero, p0, p1, p2, p3, uv0, uv1);
                drawList.AddImageQuad(IntPtr.Zero, p0, p1, p2, p3, uv0, uv1, uv2);
                drawList.AddImageQuad(IntPtr.Zero, p0, p1, p2, p3, uv0, uv1, uv2, uv3);
                drawList.AddImageQuad(IntPtr.Zero, p0, p1, p2, p3, uv0, uv1, uv2, uv3, 0xFFFFFFFF);
                drawList.AddImageRounded(IntPtr.Zero, p0, p1, uv0, uv2, 0xFFFFFFFF, 2.0f);
                drawList.AddImageRounded(IntPtr.Zero, p0, p1, uv0, uv2, 0xFFFFFFFF, 2.0f, ImDrawFlags.None);
                Assert.True(drawList.VtxBuffer.Size > 0);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies both AddText overloads execute inside a framed window with a real font.
        ///     The text carries an embedded null terminator so the native scan terminates safely.
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddText_AllOverloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImDrawListPtr drawList = BeginWindow(ctx, "dlp-text");
                Vector2F pos = new Vector2F(20, 20);
                drawList.AddText(pos, 0xFFFFFFFF, "dlp-text\0");
                ImFontPtr font = ImGui.GetFont();
                Assert.NotEqual(IntPtr.Zero, font.NativePtr);
                drawList.AddText(font, 16.0f, pos, 0xFFFFFFFF, "dlp-text-font\0");
                Assert.True(drawList.VtxBuffer.Size > 0);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every path building method executes inside a framed window without
        ///     throwing and populates the native path vector.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PathBuilding_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImDrawListPtr drawList = BeginWindow(ctx, "dlp-path");
                Vector2F center = new Vector2F(50, 50);
                Vector2F p0 = new Vector2F(20, 20);
                Vector2F p1 = new Vector2F(60, 20);
                Vector2F p2 = new Vector2F(60, 60);
                drawList.PathClear();
                drawList.PathLineTo(p0);
                drawList.PathLineTo(p1);
                drawList.PathLineTo(p2);
                drawList.PathArcTo(center, 8.0f, 0.0f, 3.14f);
                drawList.PathArcTo(center, 8.0f, 0.0f, 3.14f, 12);
                drawList.PathArcToFast(center, 8.0f, 0, 6);
                drawList.PathArcToFastEx(center, 8.0f, 0, 6, 1);
                drawList.PathArcToN(center, 8.0f, 0.0f, 3.14f, 8);
                drawList.PathBezierCubicCurveTo(p1, p2, p0);
                drawList.PathBezierCubicCurveTo(p1, p2, p0, 12);
                drawList.PathBezierQuadraticCurveTo(p1, p2);
                drawList.PathBezierQuadraticCurveTo(p1, p2, 12);
                drawList.PathRect(p0, p2);
                drawList.PathRect(p0, p2, 2.0f);
                drawList.PathRect(p0, p2, 2.0f, ImDrawFlags.None);
                Assert.True(drawList.Path.Size > 0);
                drawList.PathFillConvex(0xFFFFFFFF);
                drawList.PathClear();
                drawList.PathLineTo(p0);
                drawList.PathLineTo(p1);
                drawList.PathLineTo(p2);
                drawList.PathStroke(0xFFFFFFFF);
                drawList.PathStroke(0xFFFFFFFF, ImDrawFlags.None);
                drawList.PathStroke(0xFFFFFFFF, ImDrawFlags.None, 2.0f);
                drawList.PathLineToMergeDuplicate(p0);
                Assert.True(drawList.VtxBuffer.Size > 0);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every primitive write method executes inside a framed window after a
        ///     PrimReserve and that the write pointers become valid.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Primitives_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImDrawListPtr drawList = BeginWindow(ctx, "dlp-prim");
                Vector2F p0 = new Vector2F(20, 20);
                Vector2F p1 = new Vector2F(60, 20);
                Vector2F p2 = new Vector2F(60, 60);
                Vector2F p3 = new Vector2F(20, 60);
                Vector2F uv0 = new Vector2F();
                Vector2F uv1 = new Vector2F(1, 0);
                Vector2F uv2 = new Vector2F(1, 1);
                Vector2F uv3 = new Vector2F(0, 1);
                uint col = 0xFFFFFFFF;
                drawList.PrimReserve(6, 4);
                drawList.PrimWriteVtx(p0, uv0, col);
                drawList.PrimWriteVtx(p1, uv1, col);
                drawList.PrimWriteVtx(p2, uv2, col);
                drawList.PrimWriteVtx(p3, uv3, col);
                drawList.PrimWriteIdx(0);
                drawList.PrimWriteIdx(1);
                drawList.PrimWriteIdx(2);
                drawList.PrimRect(p0, p1, col);
                drawList.PrimRectUv(p0, p1, uv0, uv2, col);
                drawList.PrimQuadUv(p0, p1, p2, p3, uv0, uv1, uv2, uv3, col);
                drawList.PrimVtx(p0, uv0, col);
                drawList.PrimUnreserve(2, 1);
                Assert.True(drawList.VtxBuffer.Size > 0);
                Assert.True(drawList.IdxBuffer.Size > 0);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies the channel split, selection and merge cycle executes inside a framed
        ///     window without throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Channels_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImDrawListPtr drawList = BeginWindow(ctx, "dlp-channels");
                Vector2F p0 = new Vector2F(10, 10);
                Vector2F p1 = new Vector2F(40, 40);
                drawList.ChannelsSplit(2);
                drawList.ChannelsSetCurrent(1);
                drawList.AddRectFilled(p0, p1, 0xFFFFFFFF);
                drawList.ChannelsSetCurrent(0);
                drawList.AddRectFilled(p0, p1, 0xFF0000FF);
                drawList.ChannelsMerge();
                Assert.True(drawList.CmdBuffer.Size > 0);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies the clip rect stack round trips through GetClipRectMin and
        ///     GetClipRectMax inside a framed window.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ClipStack_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImDrawListPtr drawList = BeginWindow(ctx, "dlp-clip");
                Vector2F min = new Vector2F(25, 35);
                Vector2F max = new Vector2F(200, 160);
                drawList.PushClipRect(min, max);
                Vector2F peekMin = drawList.GetClipRectMin();
                Vector2F peekMax = drawList.GetClipRectMax();
                Assert.True(float.IsFinite(peekMin.X));
                Assert.True(float.IsFinite(peekMin.Y));
                Assert.True(float.IsFinite(peekMax.X));
                Assert.True(float.IsFinite(peekMax.Y));
                Assert.Equal(min.X, peekMin.X);
                Assert.Equal(min.Y, peekMin.Y);
                Assert.Equal(max.X, peekMax.X);
                Assert.Equal(max.Y, peekMax.Y);
                drawList.PopClipRect();
                drawList.PushClipRect(min, max, true);
                drawList.PopClipRect();
                drawList.PushClipRectFullScreen();
                drawList.PopClipRect();
                drawList.PushTextureId(new IntPtr(0x1234));
                drawList.PopTextureId();
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies the struct state getters read sensible values from the live window draw
        ///     list after primitives have been reserved.
        /// </summary>
        [RequireCImguiSystemFact]
        public void StateGetters_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImDrawListPtr drawList = BeginWindow(ctx, "dlp-state");
                drawList.PrimReserve(3, 3);
                _ = drawList.CmdBuffer;
                _ = drawList.IdxBuffer;
                _ = drawList.VtxBuffer;
                _ = drawList.Flags;
                _ = drawList.VtxCurrentIdx;
                _ = drawList.Data;
                _ = drawList.OwnerName;
                _ = drawList.VtxWritePtr;
                _ = drawList.IdxWritePtr;
                _ = drawList.ClipRectStack;
                _ = drawList.TextureIdStack;
                _ = drawList.Path;
                _ = drawList.CmdHeader;
                _ = drawList.Splitter;
                Assert.True(float.IsFinite(drawList.FringeScale));
                Assert.True(drawList.CmdBuffer.Size > 0);
                Assert.True(drawList.VtxBuffer.Size >= 0);
                Assert.True(drawList.IdxBuffer.Size >= 0);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies the draw command helpers, clone, internal callbacks and reset method
        ///     execute inside a framed window without throwing. ResetForNewFrame is called last
        ///     because the native frame machinery dereferences the cleared path stacks when the
        ///     frame is closed.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DrawCommands_Clone_And_Internal_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImDrawListPtr drawList = BeginWindow(ctx, "dlp-commands");
                Vector2F p0 = new Vector2F(10, 10);
                Vector2F p1 = new Vector2F(60, 60);
                drawList.AddRectFilled(p0, p1, 0xFFFFFFFF);
                drawList.AddDrawCmd();
                drawList.TryMergeDrawCmd();
                drawList.PopUnusedDrawCmd();
                drawList.AddCallback(IntPtr.Zero, IntPtr.Zero);
                Assert.True(drawList._CalcCircleAutoSegmentCount(8.0f) > 0);
                ImDrawListPtr clone = drawList.CloneOutput();
                Assert.NotEqual(IntPtr.Zero, clone.NativePtr);
                drawList.OnChangedClipRect();
                drawList.OnChangedTextureID();
                drawList.OnChangedVtxOffset();
                drawList.ResetForNewFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies ClearFreeMemory releases the buffers of a live window draw list. The
        ///     frame is not closed afterwards because the native frame machinery dereferences
        ///     the freed buffers and would segfault.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ClearFreeMemory_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImDrawListPtr drawList = BeginWindow(ctx, "dlp-clear");
                drawList.AddRectFilled(new Vector2F(10, 10), new Vector2F(60, 60), 0xFFFFFFFF);
                drawList.ClearFreeMemory();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies the constructor from a managed ImDrawList struct allocates and copies a
        ///     native mirror that exposes a non-zero pointer and consistent buffers.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ManagedStructConstructor_Executes()
        {
            IntPtr ctx = CreateContext();
            try
            {
                ImDrawList source = new ImDrawList();
                ImDrawListPtr drawList = new ImDrawListPtr(source);
                Assert.NotEqual(IntPtr.Zero, drawList.NativePtr);
                IntPtr rawPtr = (IntPtr) drawList;
                ImDrawListPtr rebuilt = (ImDrawListPtr) rawPtr;
                Assert.Equal(rawPtr, rebuilt.NativePtr);
                Assert.Equal(0, drawList.VtxBuffer.Size);
                _ = drawList.Flags;
                _ = drawList.CmdBuffer;
                _ = drawList.IdxBuffer;
                _ = drawList.FringeScale;
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }
    }
}
