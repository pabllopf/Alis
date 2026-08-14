// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP14ExecutionTests.cs
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
    ///     Executes the real ImPlot PlotStems wrapper methods of ImPlotP14.cs against the native cimgui
    ///     library so that the managed bodies of the wrappers are exercised for line coverage.
    /// </summary>
    public class ImPlotP14ExecutionTests
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
        ///     Executes the byte array PlotStems wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_ByteArray_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                byte[] values = { 1, 2, 3 };
                if (ImPlot.BeginPlot("P14 Byte", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotStems("b1", values, 3, 0, 1, 0, ImPlotStemsFlags.None, 0);
                    ImPlot.PlotStems("b2", values, 3, 0, 1, 0, ImPlotStemsFlags.None, 0, 1);
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the short array PlotStems wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_ShortArray_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                short[] values = { 1, 2, 3 };
                if (ImPlot.BeginPlot("P14 Short", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotStems("s1", values, 3);
                    ImPlot.PlotStems("s2", values, 3, 0);
                    ImPlot.PlotStems("s3", values, 3, 0, 1);
                    ImPlot.PlotStems("s4", values, 3, 0, 1, 0);
                    ImPlot.PlotStems("s5", values, 3, 0, 1, 0, ImPlotStemsFlags.None);
                    ImPlot.PlotStems("s6", values, 3, 0, 1, 0, ImPlotStemsFlags.None, 0);
                    ImPlot.PlotStems("s7", values, 3, 0, 1, 0, ImPlotStemsFlags.None, 0, sizeof(short));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ushort array PlotStems wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_UshortArray_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                ushort[] values = { 1, 2, 3 };
                if (ImPlot.BeginPlot("P14 Ushort", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotStems("u1", values, 3);
                    ImPlot.PlotStems("u2", values, 3, 0);
                    ImPlot.PlotStems("u3", values, 3, 0, 1);
                    ImPlot.PlotStems("u4", values, 3, 0, 1, 0);
                    ImPlot.PlotStems("u5", values, 3, 0, 1, 0, ImPlotStemsFlags.None);
                    ImPlot.PlotStems("u6", values, 3, 0, 1, 0, ImPlotStemsFlags.None, 0);
                    ImPlot.PlotStems("u7", values, 3, 0, 1, 0, ImPlotStemsFlags.None, 0, sizeof(ushort));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the int array PlotStems wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_IntArray_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                int[] values = { 1, 2, 3 };
                if (ImPlot.BeginPlot("P14 Int", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotStems("i1", values, 3);
                    ImPlot.PlotStems("i2", values, 3, 0);
                    ImPlot.PlotStems("i3", values, 3, 0, 1);
                    ImPlot.PlotStems("i4", values, 3, 0, 1, 0);
                    ImPlot.PlotStems("i5", values, 3, 0, 1, 0, ImPlotStemsFlags.None);
                    ImPlot.PlotStems("i6", values, 3, 0, 1, 0, ImPlotStemsFlags.None, 0);
                    ImPlot.PlotStems("i7", values, 3, 0, 1, 0, ImPlotStemsFlags.None, 0, sizeof(int));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the uint array PlotStems wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_UintArray_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                uint[] values = { 1, 2, 3 };
                if (ImPlot.BeginPlot("P14 Uint", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotStems("ui1", values, 3);
                    ImPlot.PlotStems("ui2", values, 3, 0);
                    ImPlot.PlotStems("ui3", values, 3, 0, 1);
                    ImPlot.PlotStems("ui4", values, 3, 0, 1, 0);
                    ImPlot.PlotStems("ui5", values, 3, 0, 1, 0, ImPlotStemsFlags.None);
                    ImPlot.PlotStems("ui6", values, 3, 0, 1, 0, ImPlotStemsFlags.None, 0);
                    ImPlot.PlotStems("ui7", values, 3, 0, 1, 0, ImPlotStemsFlags.None, 0, sizeof(uint));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the long array PlotStems wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_LongArray_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                long[] values = { 1, 2, 3 };
                if (ImPlot.BeginPlot("P14 Long", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotStems("l1", values, 3);
                    ImPlot.PlotStems("l2", values, 3, 0);
                    ImPlot.PlotStems("l3", values, 3, 0, 1);
                    ImPlot.PlotStems("l4", values, 3, 0, 1, 0);
                    ImPlot.PlotStems("l5", values, 3, 0, 1, 0, ImPlotStemsFlags.None);
                    ImPlot.PlotStems("l6", values, 3, 0, 1, 0, ImPlotStemsFlags.None, 0);
                    ImPlot.PlotStems("l7", values, 3, 0, 1, 0, ImPlotStemsFlags.None, 0, sizeof(long));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ulong array PlotStems wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_UlongArray_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                ulong[] values = { 1, 2, 3 };
                if (ImPlot.BeginPlot("P14 Ulong", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotStems("ul1", values, 3);
                    ImPlot.PlotStems("ul2", values, 3, 0);
                    ImPlot.PlotStems("ul3", values, 3, 0, 1);
                    ImPlot.PlotStems("ul4", values, 3, 0, 1, 0);
                    ImPlot.PlotStems("ul5", values, 3, 0, 1, 0, ImPlotStemsFlags.None);
                    ImPlot.PlotStems("ul6", values, 3, 0, 1, 0, ImPlotStemsFlags.None, 0);
                    ImPlot.PlotStems("ul7", values, 3, 0, 1, 0, ImPlotStemsFlags.None, 0, sizeof(ulong));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ref float PlotStems wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_FloatRef_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                float xs = 1;
                float ys = 2;
                if (ImPlot.BeginPlot("P14 Float", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotStems("f1", ref xs, ref ys, 1, 0);
                    ImPlot.PlotStems("f2", ref xs, ref ys, 1, 0, ImPlotStemsFlags.None);
                    ImPlot.PlotStems("f3", ref xs, ref ys, 1, 0, ImPlotStemsFlags.None, 0);
                    ImPlot.PlotStems("f4", ref xs, ref ys, 1, 0, ImPlotStemsFlags.None, 0, sizeof(float));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ref double PlotStems wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_DoubleRef_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                double xs = 1;
                double ys = 2;
                if (ImPlot.BeginPlot("P14 Double", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotStems("d1", ref xs, ref ys, 1);
                    ImPlot.PlotStems("d2", ref xs, ref ys, 1, 0);
                    ImPlot.PlotStems("d3", ref xs, ref ys, 1, 0, ImPlotStemsFlags.None);
                    ImPlot.PlotStems("d4", ref xs, ref ys, 1, 0, ImPlotStemsFlags.None, 0);
                    ImPlot.PlotStems("d5", ref xs, ref ys, 1, 0, ImPlotStemsFlags.None, 0, sizeof(double));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ref sbyte PlotStems wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_SByteRef_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                sbyte xs = 1;
                sbyte ys = 2;
                if (ImPlot.BeginPlot("P14 SByte", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotStems("sb1", ref xs, ref ys, 1);
                    ImPlot.PlotStems("sb2", ref xs, ref ys, 1, 0);
                    ImPlot.PlotStems("sb3", ref xs, ref ys, 1, 0, ImPlotStemsFlags.None);
                    ImPlot.PlotStems("sb4", ref xs, ref ys, 1, 0, ImPlotStemsFlags.None, 0);
                    ImPlot.PlotStems("sb5", ref xs, ref ys, 1, 0, ImPlotStemsFlags.None, 0, sizeof(sbyte));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ref byte PlotStems wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_ByteRef_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                byte xs = 1;
                byte ys = 2;
                if (ImPlot.BeginPlot("P14 ByteRef", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotStems("br1", ref xs, ref ys, 1);
                    ImPlot.PlotStems("br2", ref xs, ref ys, 1, 0);
                    ImPlot.PlotStems("br3", ref xs, ref ys, 1, 0, ImPlotStemsFlags.None);
                    ImPlot.PlotStems("br4", ref xs, ref ys, 1, 0, ImPlotStemsFlags.None, 0);
                    ImPlot.PlotStems("br5", ref xs, ref ys, 1, 0, ImPlotStemsFlags.None, 0, sizeof(byte));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ref short PlotStems wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_ShortRef_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                short xs = 1;
                short ys = 2;
                if (ImPlot.BeginPlot("P14 ShortRef", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotStems("sr1", ref xs, ref ys, 1);
                    ImPlot.PlotStems("sr2", ref xs, ref ys, 1, 0);
                    ImPlot.PlotStems("sr3", ref xs, ref ys, 1, 0, ImPlotStemsFlags.None);
                    ImPlot.PlotStems("sr4", ref xs, ref ys, 1, 0, ImPlotStemsFlags.None, 0);
                    ImPlot.PlotStems("sr5", ref xs, ref ys, 1, 0, ImPlotStemsFlags.None, 0, sizeof(short));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ref ushort PlotStems wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_UshortRef_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                ushort xs = 1;
                ushort ys = 2;
                if (ImPlot.BeginPlot("P14 UshortRef", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotStems("ur1", ref xs, ref ys, 1);
                    ImPlot.PlotStems("ur2", ref xs, ref ys, 1, 0);
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
