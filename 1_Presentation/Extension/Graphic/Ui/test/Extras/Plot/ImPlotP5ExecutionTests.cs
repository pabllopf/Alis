// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP5ExecutionTests.cs
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
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     Executes the ImPlotP5 wrapper methods against the native cimgui library so that
    ///     the managed bodies of the wrappers in ImPlotP5.cs are exercised for line coverage.
    /// </summary>
    public class ImPlotP5ExecutionTests
    {
        /// <summary>
        ///     The image offset of the native GImGui context slot
        /// </summary>
        private const int GImGuiSlot = 0x4597e0;

        /// <summary>
        ///     The image offset of the native GImPlot context slot
        /// </summary>
        private const int GImPlotSlot = 0x459808;

        /// <summary>
        ///     The dyld image count
        /// </summary>
        /// <returns>The int</returns>
        [DllImport("libSystem.dylib", EntryPoint = "_dyld_image_count")]
        private static extern int DyldImageCount();

        /// <summary>
        ///     The dyld get image name
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport("libSystem.dylib", EntryPoint = "_dyld_get_image_name")]
        private static extern IntPtr DyldGetImageName(int index);

        /// <summary>
        ///     The dyld get image header
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport("libSystem.dylib", EntryPoint = "_dyld_get_image_header")]
        private static extern IntPtr DyldGetImageHeader(int index);

        /// <summary>
        ///     Creates an ImGui context, binds an ImPlot context to it and starts a new frame.
        ///     The native cimgui library is loaded twice by the runtime, so the context slots
        ///     of every loaded image are synchronized to keep all native calls consistent.
        /// </summary>
        /// <returns>The imgui context</returns>
        private static IntPtr CreateContexts()
        {
            IntPtr imgui = ImGuiNative.igCreateContext(IntPtr.Zero);
            ImGuiNative.igSetCurrentContext(imgui);
            IntPtr ioPtr = ImGuiNative.igGetIO();
            Marshal.StructureToPtr(1280.0f, IntPtr.Add(ioPtr, 8), false);
            Marshal.StructureToPtr(720.0f, IntPtr.Add(ioPtr, 12), false);
            IntPtr fontsPtr = Marshal.ReadIntPtr(ioPtr, 80);
            ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32(fontsPtr, out IntPtr _, out int _, out int _, out int _);
            IntPtr implot = ImPlot.CreateContext();
            ImPlot.SetImGuiContext(imgui);
            ImPlot.SetCurrentContext(implot);
            SyncContextSlots(imgui, implot);
            ImGuiNative.igNewFrame();
            return imgui;
        }

        /// <summary>
        ///     Ends the active frame, destroys the ImPlot context and the ImGui context.
        /// </summary>
        /// <param name="imgui">The imgui context</param>
        private static void DestroyContexts(IntPtr imgui)
        {
            ImGuiNative.igEndFrame();
            ImPlot.DestroyContext();
            ImGuiNative.igDestroyContext(imgui);
        }

        /// <summary>
        ///     Synchronizes the ImGui and ImPlot context pointers of every loaded cimgui image.
        /// </summary>
        /// <param name="imgui">The imgui context</param>
        /// <param name="implot">The implot context</param>
        private static void SyncContextSlots(IntPtr imgui, IntPtr implot)
        {
            int count = DyldImageCount();

            for (int i = 0; i < count; i++)
            {
                string name = Marshal.PtrToStringAnsi(DyldGetImageName(i));

                if (name != null && name.Contains("cimgui"))
                {
                    IntPtr imageBase = DyldGetImageHeader(i);
                    Marshal.WriteInt64(imageBase + GImGuiSlot, imgui.ToInt64());
                    Marshal.WriteInt64(imageBase + GImPlotSlot, implot.ToInt64());
                }
            }
        }

        /// <summary>
        ///     Executes the sbyte, byte, short and ushort PlotErrorBars pair error wrapper
        ///     overloads inside an active plot with a zero count so that the by-value
        ///     bindings are never dereferenced by the native code.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_S8_U8_S16_U16_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ErrS8P5Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    PlotErrorBarsS8();
                    PlotErrorBarsU8();
                    ImPlot.EndPlot();
                }

                if (ImPlot.BeginPlot("ErrS16P5Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    PlotErrorBarsS16();
                    PlotErrorBarsU16();
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the int, uint, long and ulong PlotErrorBars pair error wrapper
        ///     overloads inside an active plot with a zero count so that the by-value
        ///     bindings are never dereferenced by the native code.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_S32_U32_S64_U64_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ErrS32P5Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    PlotErrorBarsS32();
                    PlotErrorBarsU32();
                    ImPlot.EndPlot();
                }

                if (ImPlot.BeginPlot("ErrS64P5Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    PlotErrorBarsS64();
                    PlotErrorBarsU64();
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the float and double PlotHeatmap wrapper overloads inside an active
        ///     plot with small value grids.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_Float_And_Double_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("HeatF32P5Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    float[] floats = new float[] { 1, 2, 3, 4 };
                    ImPlot.PlotHeatmap("hm f32 a", floats, 2, 2);
                    ImPlot.PlotHeatmap("hm f32 b", floats, 2, 2, 0.0);
                    ImPlot.PlotHeatmap("hm f32 c", floats, 2, 2, 0.0, 4.0);
                    ImPlot.PlotHeatmap("hm f32 d", floats, 2, 2, 0.0, 4.0, "%.1f");
                    ImPlot.PlotHeatmap("hm f32 e", floats, 2, 2, 0.0, 4.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 });
                    ImPlot.PlotHeatmap("hm f32 f", floats, 2, 2, 0.0, 4.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }, new ImPlotPoint { X = 1, Y = 1 });
                    ImPlot.PlotHeatmap("hm f32 g", floats, 2, 2, 0.0, 4.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }, new ImPlotPoint { X = 1, Y = 1 }, ImPlotHeatmapFlags.None);
                    ImPlot.EndPlot();
                }

                if (ImPlot.BeginPlot("HeatF64P5Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    double[] doubles = new double[] { 1, 2, 3, 4 };
                    ImPlot.PlotHeatmap("hm f64 a", doubles, 2, 2);
                    ImPlot.PlotHeatmap("hm f64 b", doubles, 2, 2, 0.0);
                    ImPlot.PlotHeatmap("hm f64 c", doubles, 2, 2, 0.0, 4.0);
                    ImPlot.PlotHeatmap("hm f64 d", doubles, 2, 2, 0.0, 4.0, "%.1f");
                    ImPlot.PlotHeatmap("hm f64 e", doubles, 2, 2, 0.0, 4.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 });
                    ImPlot.PlotHeatmap("hm f64 f", doubles, 2, 2, 0.0, 4.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }, new ImPlotPoint { X = 1, Y = 1 });
                    ImPlot.PlotHeatmap("hm f64 g", doubles, 2, 2, 0.0, 4.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }, new ImPlotPoint { X = 1, Y = 1 }, ImPlotHeatmapFlags.None);
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the sbyte PlotErrorBars pair error wrapper overloads with a zero
        ///     count so that the by-value error binding is never dereferenced by the native
        ///     code.
        /// </summary>
        private static void PlotErrorBarsS8()
        {
            sbyte xs = default;
            sbyte ys = default;
            sbyte neg = default;
            sbyte pos = default;
            ImPlot.PlotErrorBars("err s8 p a", ref xs, ref ys, ref neg, ref pos, 0);
            ImPlot.PlotErrorBars("err s8 p b", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None);
            ImPlot.PlotErrorBars("err s8 p c", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0);
            ImPlot.PlotErrorBars("err s8 p d", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0, sizeof(sbyte));
        }

        /// <summary>
        ///     Executes the byte PlotErrorBars pair error wrapper overloads with a zero
        ///     count so that the by-value error binding is never dereferenced by the native
        ///     code.
        /// </summary>
        private static void PlotErrorBarsU8()
        {
            byte xs = default;
            byte ys = default;
            byte neg = default;
            byte pos = default;
            ImPlot.PlotErrorBars("err u8 p a", ref xs, ref ys, ref neg, ref pos, 0);
            ImPlot.PlotErrorBars("err u8 p b", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None);
            ImPlot.PlotErrorBars("err u8 p c", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0);
            ImPlot.PlotErrorBars("err u8 p d", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0, sizeof(byte));
        }

        /// <summary>
        ///     Executes the short PlotErrorBars pair error wrapper overloads with a zero
        ///     count so that the by-value error binding is never dereferenced by the native
        ///     code.
        /// </summary>
        private static void PlotErrorBarsS16()
        {
            short xs = default;
            short ys = default;
            short neg = default;
            short pos = default;
            ImPlot.PlotErrorBars("err s16 p a", ref xs, ref ys, ref neg, ref pos, 0);
            ImPlot.PlotErrorBars("err s16 p b", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None);
            ImPlot.PlotErrorBars("err s16 p c", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0);
            ImPlot.PlotErrorBars("err s16 p d", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0, sizeof(short));
        }

        /// <summary>
        ///     Executes the ushort PlotErrorBars pair error wrapper overloads with a zero
        ///     count so that the by-value error binding is never dereferenced by the native
        ///     code.
        /// </summary>
        private static void PlotErrorBarsU16()
        {
            ushort xs = default;
            ushort ys = default;
            ushort neg = default;
            ushort pos = default;
            ImPlot.PlotErrorBars("err u16 p a", ref xs, ref ys, ref neg, ref pos, 0);
            ImPlot.PlotErrorBars("err u16 p b", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None);
            ImPlot.PlotErrorBars("err u16 p c", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0);
            ImPlot.PlotErrorBars("err u16 p d", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0, sizeof(ushort));
        }

        /// <summary>
        ///     Executes the int PlotErrorBars pair error wrapper overloads with a zero
        ///     count so that the by-value error binding is never dereferenced by the native
        ///     code.
        /// </summary>
        private static void PlotErrorBarsS32()
        {
            int xs = default;
            int ys = default;
            int neg = default;
            int pos = default;
            ImPlot.PlotErrorBars("err s32 p a", ref xs, ref ys, ref neg, ref pos, 0);
            ImPlot.PlotErrorBars("err s32 p b", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None);
            ImPlot.PlotErrorBars("err s32 p c", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0);
            ImPlot.PlotErrorBars("err s32 p d", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0, sizeof(int));
        }

        /// <summary>
        ///     Executes the uint PlotErrorBars pair error wrapper overloads with a zero
        ///     count so that the by-value error binding is never dereferenced by the native
        ///     code.
        /// </summary>
        private static void PlotErrorBarsU32()
        {
            uint xs = default;
            uint ys = default;
            uint neg = default;
            uint pos = default;
            ImPlot.PlotErrorBars("err u32 p a", ref xs, ref ys, ref neg, ref pos, 0);
            ImPlot.PlotErrorBars("err u32 p b", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None);
            ImPlot.PlotErrorBars("err u32 p c", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0);
            ImPlot.PlotErrorBars("err u32 p d", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0, sizeof(uint));
        }

        /// <summary>
        ///     Executes the long PlotErrorBars pair error wrapper overloads with a zero
        ///     count so that the by-value error binding is never dereferenced by the native
        ///     code.
        /// </summary>
        private static void PlotErrorBarsS64()
        {
            long xs = default;
            long ys = default;
            long neg = default;
            long pos = default;
            ImPlot.PlotErrorBars("err s64 p a", ref xs, ref ys, ref neg, ref pos, 0);
            ImPlot.PlotErrorBars("err s64 p b", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None);
            ImPlot.PlotErrorBars("err s64 p c", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0);
            ImPlot.PlotErrorBars("err s64 p d", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0, sizeof(long));
        }

        /// <summary>
        ///     Executes the ulong PlotErrorBars pair error wrapper overloads with a zero
        ///     count so that the by-value error binding is never dereferenced by the native
        ///     code.
        /// </summary>
        private static void PlotErrorBarsU64()
        {
            ulong xs = default;
            ulong ys = default;
            ulong neg = default;
            ulong pos = default;
            ImPlot.PlotErrorBars("err u64 p a", ref xs, ref ys, ref neg, ref pos, 0);
            ImPlot.PlotErrorBars("err u64 p b", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None);
            ImPlot.PlotErrorBars("err u64 p c", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0);
            ImPlot.PlotErrorBars("err u64 p d", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0, sizeof(ulong));
        }
    }
}
