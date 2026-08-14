// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP13ExecutionTests.cs
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
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     Executes the real ImPlot PlotStairs, PlotStairsG and PlotStems wrapper methods of the ImPlotP13 partial
    ///     class against the native cimgui library so that the managed bodies are exercised for line coverage.
    /// </summary>
    public class ImPlotP13ExecutionTests
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
        ///     Executes the byte and ushort PlotStairs wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_Byte_And_Ushort_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                bool opened = ImPlot.BeginPlot("StairsU8Plot", new Alis.Core.Aspect.Math.Vector.Vector2F(400, 300), ImPlotFlags.None);
                Assert.True(opened);
                if (opened)
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    byte u8Xs = 1;
                    byte u8Ys = 2;
                    ImPlot.PlotStairs("u8 a", ref u8Xs, ref u8Ys, 1, ImPlotStairsFlags.None, 0, sizeof(byte));
                    ushort u16Xs = 1;
                    ushort u16Ys = 2;
                    ImPlot.PlotStairs("u16 a", ref u16Xs, ref u16Ys, 1);
                    ImPlot.PlotStairs("u16 b", ref u16Xs, ref u16Ys, 1, ImPlotStairsFlags.None);
                    ImPlot.PlotStairs("u16 c", ref u16Xs, ref u16Ys, 1, ImPlotStairsFlags.None, 0);
                    ImPlot.PlotStairs("u16 d", ref u16Xs, ref u16Ys, 1, ImPlotStairsFlags.None, 0, sizeof(ushort));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the long and ulong PlotStairs wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_Long_And_Ulong_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                bool opened = ImPlot.BeginPlot("Stairs64Plot", new Alis.Core.Aspect.Math.Vector.Vector2F(400, 300), ImPlotFlags.None);
                Assert.True(opened);
                if (opened)
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    long s64Xs = 1;
                    long s64Ys = 2;
                    ImPlot.PlotStairs("s64 a", ref s64Xs, ref s64Ys, 1);
                    ImPlot.PlotStairs("s64 b", ref s64Xs, ref s64Ys, 1, ImPlotStairsFlags.None);
                    ImPlot.PlotStairs("s64 c", ref s64Xs, ref s64Ys, 1, ImPlotStairsFlags.None, 0);
                    ImPlot.PlotStairs("s64 d", ref s64Xs, ref s64Ys, 1, ImPlotStairsFlags.None, 0, sizeof(long));
                    ulong u64Xs = 1;
                    ulong u64Ys = 2;
                    ImPlot.PlotStairs("u64 a", ref u64Xs, ref u64Ys, 1);
                    ImPlot.PlotStairs("u64 b", ref u64Xs, ref u64Ys, 1, ImPlotStairsFlags.None);
                    ImPlot.PlotStairs("u64 c", ref u64Xs, ref u64Ys, 1, ImPlotStairsFlags.None, 0);
                    ImPlot.PlotStairs("u64 d", ref u64Xs, ref u64Ys, 1, ImPlotStairsFlags.None, 0, sizeof(ulong));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the PlotStairsG wrapper overloads with a zero getter and zero count inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairsG_With_Zero_Getter_Executes()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                bool opened = ImPlot.BeginPlot("StairsGPlot", new Alis.Core.Aspect.Math.Vector.Vector2F(400, 300), ImPlotFlags.None);
                Assert.True(opened);
                if (opened)
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotStairsG("stairs g a", IntPtr.Zero, IntPtr.Zero, 0);
                    ImPlot.PlotStairsG("stairs g b", IntPtr.Zero, IntPtr.Zero, 0, ImPlotStairsFlags.None);
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the float PlotStems wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_Float_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                bool opened = ImPlot.BeginPlot("StemsFloatPlot", new Alis.Core.Aspect.Math.Vector.Vector2F(400, 300), ImPlotFlags.None);
                Assert.True(opened);
                if (opened)
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    float[] values = new float[] { 1, 2, 3 };
                    ImPlot.PlotStems("f a", values, 3);
                    ImPlot.PlotStems("f b", values, 3, 0.0);
                    ImPlot.PlotStems("f c", values, 3, 0.0, 1.0);
                    ImPlot.PlotStems("f d", values, 3, 0.0, 1.0, 0.0);
                    ImPlot.PlotStems("f e", values, 3, 0.0, 1.0, 0.0, ImPlotStemsFlags.None);
                    ImPlot.PlotStems("f f", values, 3, 0.0, 1.0, 0.0, ImPlotStemsFlags.None, 0);
                    ImPlot.PlotStems("f g", values, 3, 0.0, 1.0, 0.0, ImPlotStemsFlags.None, 0, sizeof(float));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the double PlotStems wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_Double_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                bool opened = ImPlot.BeginPlot("StemsDoublePlot", new Alis.Core.Aspect.Math.Vector.Vector2F(400, 300), ImPlotFlags.None);
                Assert.True(opened);
                if (opened)
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    double[] values = new double[] { 1, 2, 3 };
                    ImPlot.PlotStems("d a", values, 3);
                    ImPlot.PlotStems("d b", values, 3, 0.0);
                    ImPlot.PlotStems("d c", values, 3, 0.0, 1.0);
                    ImPlot.PlotStems("d d", values, 3, 0.0, 1.0, 0.0);
                    ImPlot.PlotStems("d e", values, 3, 0.0, 1.0, 0.0, ImPlotStemsFlags.None);
                    ImPlot.PlotStems("d f", values, 3, 0.0, 1.0, 0.0, ImPlotStemsFlags.None, 0);
                    ImPlot.PlotStems("d g", values, 3, 0.0, 1.0, 0.0, ImPlotStemsFlags.None, 0, sizeof(double));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the sbyte PlotStems wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_Sbyte_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                bool opened = ImPlot.BeginPlot("StemsS8Plot", new Alis.Core.Aspect.Math.Vector.Vector2F(400, 300), ImPlotFlags.None);
                Assert.True(opened);
                if (opened)
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    sbyte[] values = new sbyte[] { 1, 2, 3 };
                    ImPlot.PlotStems("s8 a", values, 3);
                    ImPlot.PlotStems("s8 b", values, 3, 0.0);
                    ImPlot.PlotStems("s8 c", values, 3, 0.0, 1.0);
                    ImPlot.PlotStems("s8 d", values, 3, 0.0, 1.0, 0.0);
                    ImPlot.PlotStems("s8 e", values, 3, 0.0, 1.0, 0.0, ImPlotStemsFlags.None);
                    ImPlot.PlotStems("s8 f", values, 3, 0.0, 1.0, 0.0, ImPlotStemsFlags.None, 0);
                    ImPlot.PlotStems("s8 g", values, 3, 0.0, 1.0, 0.0, ImPlotStemsFlags.None, 0, sizeof(sbyte));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the byte PlotStems wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_Byte_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                bool opened = ImPlot.BeginPlot("StemsU8Plot", new Alis.Core.Aspect.Math.Vector.Vector2F(400, 300), ImPlotFlags.None);
                Assert.True(opened);
                if (opened)
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    byte[] values = new byte[] { 1, 2, 3 };
                    ImPlot.PlotStems("u8 a", values, 3);
                    ImPlot.PlotStems("u8 b", values, 3, 0.0);
                    ImPlot.PlotStems("u8 c", values, 3, 0.0, 1.0);
                    ImPlot.PlotStems("u8 d", values, 3, 0.0, 1.0, 0.0);
                    ImPlot.PlotStems("u8 e", values, 3, 0.0, 1.0, 0.0, ImPlotStemsFlags.None);
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
