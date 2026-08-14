// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP12ExecutionTests.cs
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

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     Executes the real ImPlot PlotHistogram and PlotHistogram2D wrapper methods of ImPlotP12.cs
    ///     against the native cimgui library so that the managed bodies of the wrappers are exercised
    ///     for line coverage.
    /// </summary>
    public class ImPlotP12ExecutionTests
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
        ///     Executes the byte array PlotHistogram wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_ByteArray_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                byte[] values = { 1, 2, 3 };
                if (ImPlot.BeginPlot("P12 Hist Byte", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotHistogram("b1", values, 3, 2, 1.0, new ImPlotRange());
                    ImPlot.PlotHistogram("b2", values, 3, 2, 1.0, new ImPlotRange(), ImPlotHistogramFlags.None);
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the short array PlotHistogram wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_ShortArray_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                short[] values = { 1, 2, 3 };
                if (ImPlot.BeginPlot("P12 Hist Short", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotHistogram("s1", values, 3);
                    ImPlot.PlotHistogram("s2", values, 3, 2);
                    ImPlot.PlotHistogram("s3", values, 3, 2, 1.0);
                    ImPlot.PlotHistogram("s4", values, 3, 2, 1.0, new ImPlotRange());
                    ImPlot.PlotHistogram("s5", values, 3, 2, 1.0, new ImPlotRange(), ImPlotHistogramFlags.None);
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ushort array PlotHistogram wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_UshortArray_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                ushort[] values = { 1, 2, 3 };
                if (ImPlot.BeginPlot("P12 Hist Ushort", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotHistogram("u1", values, 3);
                    ImPlot.PlotHistogram("u2", values, 3, 2);
                    ImPlot.PlotHistogram("u3", values, 3, 2, 1.0);
                    ImPlot.PlotHistogram("u4", values, 3, 2, 1.0, new ImPlotRange());
                    ImPlot.PlotHistogram("u5", values, 3, 2, 1.0, new ImPlotRange(), ImPlotHistogramFlags.None);
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the int array PlotHistogram wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_IntArray_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                int[] values = { 1, 2, 3 };
                if (ImPlot.BeginPlot("P12 Hist Int", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotHistogram("i1", values, 3);
                    ImPlot.PlotHistogram("i2", values, 3, 2);
                    ImPlot.PlotHistogram("i3", values, 3, 2, 1.0);
                    ImPlot.PlotHistogram("i4", values, 3, 2, 1.0, new ImPlotRange());
                    ImPlot.PlotHistogram("i5", values, 3, 2, 1.0, new ImPlotRange(), ImPlotHistogramFlags.None);
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the uint array PlotHistogram wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_UintArray_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                uint[] values = { 1, 2, 3 };
                if (ImPlot.BeginPlot("P12 Hist Uint", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotHistogram("ui1", values, 3);
                    ImPlot.PlotHistogram("ui2", values, 3, 2);
                    ImPlot.PlotHistogram("ui3", values, 3, 2, 1.0);
                    ImPlot.PlotHistogram("ui4", values, 3, 2, 1.0, new ImPlotRange());
                    ImPlot.PlotHistogram("ui5", values, 3, 2, 1.0, new ImPlotRange(), ImPlotHistogramFlags.None);
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the long array PlotHistogram wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_LongArray_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                long[] values = { 1, 2, 3 };
                if (ImPlot.BeginPlot("P12 Hist Long", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotHistogram("l1", values, 3);
                    ImPlot.PlotHistogram("l2", values, 3, 2);
                    ImPlot.PlotHistogram("l3", values, 3, 2, 1.0);
                    ImPlot.PlotHistogram("l4", values, 3, 2, 1.0, new ImPlotRange());
                    ImPlot.PlotHistogram("l5", values, 3, 2, 1.0, new ImPlotRange(), ImPlotHistogramFlags.None);
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ulong array PlotHistogram wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_UlongArray_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                ulong[] values = { 1, 2, 3 };
                if (ImPlot.BeginPlot("P12 Hist Ulong", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotHistogram("ul1", values, 3);
                    ImPlot.PlotHistogram("ul2", values, 3, 2);
                    ImPlot.PlotHistogram("ul3", values, 3, 2, 1.0);
                    ImPlot.PlotHistogram("ul4", values, 3, 2, 1.0, new ImPlotRange());
                    ImPlot.PlotHistogram("ul5", values, 3, 2, 1.0, new ImPlotRange(), ImPlotHistogramFlags.None);
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ref float PlotHistogram2D wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram2D_FloatRef_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                float xs = 1;
                float ys = 2;
                if (ImPlot.BeginPlot("P12 Hist2D Float", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotHistogram2D("f1", ref xs, ref ys, 1);
                    ImPlot.PlotHistogram2D("f2", ref xs, ref ys, 1, 1);
                    ImPlot.PlotHistogram2D("f3", ref xs, ref ys, 1, 1, 1);
                    ImPlot.PlotHistogram2D("f4", ref xs, ref ys, 1, 1, 1, new ImPlotRect());
                    ImPlot.PlotHistogram2D("f5", ref xs, ref ys, 1, 1, 1, new ImPlotRect(), ImPlotHistogramFlags.None);
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ref double PlotHistogram2D wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram2D_DoubleRef_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                double xs = 1;
                double ys = 2;
                if (ImPlot.BeginPlot("P12 Hist2D Double", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotHistogram2D("d1", ref xs, ref ys, 1);
                    ImPlot.PlotHistogram2D("d2", ref xs, ref ys, 1, 1);
                    ImPlot.PlotHistogram2D("d3", ref xs, ref ys, 1, 1, 1);
                    ImPlot.PlotHistogram2D("d4", ref xs, ref ys, 1, 1, 1, new ImPlotRect());
                    ImPlot.PlotHistogram2D("d5", ref xs, ref ys, 1, 1, 1, new ImPlotRect(), ImPlotHistogramFlags.None);
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ref sbyte PlotHistogram2D wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram2D_SByteRef_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                sbyte xs = 1;
                sbyte ys = 2;
                if (ImPlot.BeginPlot("P12 Hist2D SByte", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotHistogram2D("sb1", ref xs, ref ys, 1);
                    ImPlot.PlotHistogram2D("sb2", ref xs, ref ys, 1, 1);
                    ImPlot.PlotHistogram2D("sb3", ref xs, ref ys, 1, 1, 1);
                    ImPlot.PlotHistogram2D("sb4", ref xs, ref ys, 1, 1, 1, new ImPlotRect());
                    ImPlot.PlotHistogram2D("sb5", ref xs, ref ys, 1, 1, 1, new ImPlotRect(), ImPlotHistogramFlags.None);
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ref byte PlotHistogram2D wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram2D_ByteRef_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                byte xs = 1;
                byte ys = 2;
                if (ImPlot.BeginPlot("P12 Hist2D Byte", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotHistogram2D("br1", ref xs, ref ys, 1);
                    ImPlot.PlotHistogram2D("br2", ref xs, ref ys, 1, 1);
                    ImPlot.PlotHistogram2D("br3", ref xs, ref ys, 1, 1, 1);
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
