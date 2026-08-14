// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP22ExecutionTests.cs
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
    ///     Executes the ImPlotP22 wrapper methods (PlotLine overloads for short, ushort,
    ///     int, uint, long and ulong arrays plus float, double, sbyte, byte, short and
    ///     ushort reference pairs) against the native cimgui library so that the managed
    ///     bodies of the wrappers in ImPlotP22.cs are exercised for line coverage.
    /// </summary>
    public class ImPlotP22ExecutionTests
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
        ///     Executes the short array PlotLine wrapper overload inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotLine_ShortArray_Full_Overload_Executes_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                short[] values = new short[] { 1, 2, 3 };
                if (ImPlot.BeginPlot("P22 ShortArray", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotLine("s16 full", values, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, sizeof(short));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ushort array PlotLine wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotLine_UshortArray_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                ushort[] values = new ushort[] { 1, 2, 3 };
                if (ImPlot.BeginPlot("P22 UshortArray", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotLine("u16 a", values, 3);
                    ImPlot.PlotLine("u16 b", values, 3, 1.0);
                    ImPlot.PlotLine("u16 c", values, 3, 1.0, 0.0);
                    ImPlot.PlotLine("u16 d", values, 3, 1.0, 0.0, ImPlotLineFlags.None);
                    ImPlot.PlotLine("u16 e", values, 3, 1.0, 0.0, ImPlotLineFlags.None, 0);
                    ImPlot.PlotLine("u16 f", values, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, sizeof(ushort));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the int array PlotLine wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotLine_IntArray_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                int[] values = new int[] { 1, 2, 3 };
                if (ImPlot.BeginPlot("P22 IntArray", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotLine("s32 a", values, 3);
                    ImPlot.PlotLine("s32 b", values, 3, 1.0);
                    ImPlot.PlotLine("s32 c", values, 3, 1.0, 0.0);
                    ImPlot.PlotLine("s32 d", values, 3, 1.0, 0.0, ImPlotLineFlags.None);
                    ImPlot.PlotLine("s32 e", values, 3, 1.0, 0.0, ImPlotLineFlags.None, 0);
                    ImPlot.PlotLine("s32 f", values, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, sizeof(int));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the uint array PlotLine wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotLine_UintArray_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                uint[] values = new uint[] { 1, 2, 3 };
                if (ImPlot.BeginPlot("P22 UintArray", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotLine("u32 a", values, 3);
                    ImPlot.PlotLine("u32 b", values, 3, 1.0);
                    ImPlot.PlotLine("u32 c", values, 3, 1.0, 0.0);
                    ImPlot.PlotLine("u32 d", values, 3, 1.0, 0.0, ImPlotLineFlags.None);
                    ImPlot.PlotLine("u32 e", values, 3, 1.0, 0.0, ImPlotLineFlags.None, 0);
                    ImPlot.PlotLine("u32 f", values, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, sizeof(uint));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the long array PlotLine wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotLine_LongArray_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                long[] values = new long[] { 1, 2, 3 };
                if (ImPlot.BeginPlot("P22 LongArray", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotLine("s64 a", values, 3);
                    ImPlot.PlotLine("s64 b", values, 3, 1.0);
                    ImPlot.PlotLine("s64 c", values, 3, 1.0, 0.0);
                    ImPlot.PlotLine("s64 d", values, 3, 1.0, 0.0, ImPlotLineFlags.None);
                    ImPlot.PlotLine("s64 e", values, 3, 1.0, 0.0, ImPlotLineFlags.None, 0);
                    ImPlot.PlotLine("s64 f", values, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, sizeof(long));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ulong array PlotLine wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotLine_UlongArray_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                ulong[] values = new ulong[] { 1, 2, 3 };
                if (ImPlot.BeginPlot("P22 UlongArray", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotLine("u64 a", values, 3);
                    ImPlot.PlotLine("u64 b", values, 3, 1.0);
                    ImPlot.PlotLine("u64 c", values, 3, 1.0, 0.0);
                    ImPlot.PlotLine("u64 d", values, 3, 1.0, 0.0, ImPlotLineFlags.None);
                    ImPlot.PlotLine("u64 e", values, 3, 1.0, 0.0, ImPlotLineFlags.None, 0);
                    ImPlot.PlotLine("u64 f", values, 3, 1.0, 0.0, ImPlotLineFlags.None, 0, sizeof(ulong));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the float reference PlotLine wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotLine_FloatRef_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                float xs = 1;
                float ys = 2;
                if (ImPlot.BeginPlot("P22 FloatRef", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotLine("f a", ref xs, ref ys, 1);
                    ImPlot.PlotLine("f b", ref xs, ref ys, 1, ImPlotLineFlags.None);
                    ImPlot.PlotLine("f c", ref xs, ref ys, 1, ImPlotLineFlags.None, 0);
                    ImPlot.PlotLine("f d", ref xs, ref ys, 1, ImPlotLineFlags.None, 0, sizeof(float));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the double reference PlotLine wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotLine_DoubleRef_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                double xs = 1;
                double ys = 2;
                if (ImPlot.BeginPlot("P22 DoubleRef", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotLine("d a", ref xs, ref ys, 1);
                    ImPlot.PlotLine("d b", ref xs, ref ys, 1, ImPlotLineFlags.None);
                    ImPlot.PlotLine("d c", ref xs, ref ys, 1, ImPlotLineFlags.None, 0);
                    ImPlot.PlotLine("d d", ref xs, ref ys, 1, ImPlotLineFlags.None, 0, sizeof(double));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the sbyte reference PlotLine wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotLine_SbyteRef_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                sbyte xs = 1;
                sbyte ys = 2;
                if (ImPlot.BeginPlot("P22 SbyteRef", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotLine("s8 a", ref xs, ref ys, 1);
                    ImPlot.PlotLine("s8 b", ref xs, ref ys, 1, ImPlotLineFlags.None);
                    ImPlot.PlotLine("s8 c", ref xs, ref ys, 1, ImPlotLineFlags.None, 0);
                    ImPlot.PlotLine("s8 d", ref xs, ref ys, 1, ImPlotLineFlags.None, 0, sizeof(sbyte));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the byte reference PlotLine wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotLine_ByteRef_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                byte xs = 1;
                byte ys = 2;
                if (ImPlot.BeginPlot("P22 ByteRef", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotLine("u8 a", ref xs, ref ys, 1);
                    ImPlot.PlotLine("u8 b", ref xs, ref ys, 1, ImPlotLineFlags.None);
                    ImPlot.PlotLine("u8 c", ref xs, ref ys, 1, ImPlotLineFlags.None, 0);
                    ImPlot.PlotLine("u8 d", ref xs, ref ys, 1, ImPlotLineFlags.None, 0, sizeof(byte));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ushort reference PlotLine wrapper overloads inside the active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotLine_UshortRef_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                ushort xs = 1;
                ushort ys = 2;
                if (ImPlot.BeginPlot("P22 UshortRef", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotLine("u16r a", ref xs, ref ys, 1);
                    ImPlot.PlotLine("u16r b", ref xs, ref ys, 1, ImPlotLineFlags.None);
                    ImPlot.PlotLine("u16r c", ref xs, ref ys, 1, ImPlotLineFlags.None, 0);
                    ImPlot.PlotLine("u16r d", ref xs, ref ys, 1, ImPlotLineFlags.None, 0, sizeof(ushort));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }
    }
}
