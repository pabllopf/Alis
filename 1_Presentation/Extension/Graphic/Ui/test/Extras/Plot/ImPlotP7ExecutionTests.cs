// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP7ExecutionTests.cs
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
    ///     Executes the real ImPlot PlotScatter wrapper overloads of ImPlotP7.cs against the native
    ///     cimgui library so that the managed bodies of the wrappers are exercised for line coverage.
    /// </summary>
    public class ImPlotP7ExecutionTests
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
        ///     Executes the byte array and short array PlotScatter overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_ByteArray_And_ShortArray_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P7ByteShort", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotScatter("u8 arr", new byte[] { 1, 2, 3 }, 3, 1.0, 0.0, ImPlotScatterFlags.None, 0, sizeof(byte));
                    ImPlot.PlotScatter("s16 a", new short[] { 1, 2, 3 }, 3);
                    ImPlot.PlotScatter("s16 b", new short[] { 1, 2, 3 }, 3, 1.0);
                    ImPlot.PlotScatter("s16 c", new short[] { 1, 2, 3 }, 3, 1.0, 0.0);
                    ImPlot.PlotScatter("s16 d", new short[] { 1, 2, 3 }, 3, 1.0, 0.0, ImPlotScatterFlags.None);
                    ImPlot.PlotScatter("s16 e", new short[] { 1, 2, 3 }, 3, 1.0, 0.0, ImPlotScatterFlags.None, 0);
                    ImPlot.PlotScatter("s16 f", new short[] { 1, 2, 3 }, 3, 1.0, 0.0, ImPlotScatterFlags.None, 0, sizeof(short));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ushort array PlotScatter overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_UshortArray_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P7Ushort", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotScatter("u16 a", new ushort[] { 1, 2, 3 }, 3);
                    ImPlot.PlotScatter("u16 b", new ushort[] { 1, 2, 3 }, 3, 1.0);
                    ImPlot.PlotScatter("u16 c", new ushort[] { 1, 2, 3 }, 3, 1.0, 0.0);
                    ImPlot.PlotScatter("u16 d", new ushort[] { 1, 2, 3 }, 3, 1.0, 0.0, ImPlotScatterFlags.None);
                    ImPlot.PlotScatter("u16 e", new ushort[] { 1, 2, 3 }, 3, 1.0, 0.0, ImPlotScatterFlags.None, 0);
                    ImPlot.PlotScatter("u16 f", new ushort[] { 1, 2, 3 }, 3, 1.0, 0.0, ImPlotScatterFlags.None, 0, sizeof(ushort));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the int array PlotScatter overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_IntArray_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P7Int", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotScatter("s32 a", new int[] { 1, 2, 3 }, 3);
                    ImPlot.PlotScatter("s32 b", new int[] { 1, 2, 3 }, 3, 1.0);
                    ImPlot.PlotScatter("s32 c", new int[] { 1, 2, 3 }, 3, 1.0, 0.0);
                    ImPlot.PlotScatter("s32 d", new int[] { 1, 2, 3 }, 3, 1.0, 0.0, ImPlotScatterFlags.None);
                    ImPlot.PlotScatter("s32 e", new int[] { 1, 2, 3 }, 3, 1.0, 0.0, ImPlotScatterFlags.None, 0);
                    ImPlot.PlotScatter("s32 f", new int[] { 1, 2, 3 }, 3, 1.0, 0.0, ImPlotScatterFlags.None, 0, sizeof(int));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the uint array PlotScatter overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_UintArray_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P7Uint", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotScatter("u32 a", new uint[] { 1, 2, 3 }, 3);
                    ImPlot.PlotScatter("u32 b", new uint[] { 1, 2, 3 }, 3, 1.0);
                    ImPlot.PlotScatter("u32 c", new uint[] { 1, 2, 3 }, 3, 1.0, 0.0);
                    ImPlot.PlotScatter("u32 d", new uint[] { 1, 2, 3 }, 3, 1.0, 0.0, ImPlotScatterFlags.None);
                    ImPlot.PlotScatter("u32 e", new uint[] { 1, 2, 3 }, 3, 1.0, 0.0, ImPlotScatterFlags.None, 0);
                    ImPlot.PlotScatter("u32 f", new uint[] { 1, 2, 3 }, 3, 1.0, 0.0, ImPlotScatterFlags.None, 0, sizeof(uint));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the long array PlotScatter overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_LongArray_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P7Long", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotScatter("s64 a", new long[] { 1, 2, 3 }, 3);
                    ImPlot.PlotScatter("s64 b", new long[] { 1, 2, 3 }, 3, 1.0);
                    ImPlot.PlotScatter("s64 c", new long[] { 1, 2, 3 }, 3, 1.0, 0.0);
                    ImPlot.PlotScatter("s64 d", new long[] { 1, 2, 3 }, 3, 1.0, 0.0, ImPlotScatterFlags.None);
                    ImPlot.PlotScatter("s64 e", new long[] { 1, 2, 3 }, 3, 1.0, 0.0, ImPlotScatterFlags.None, 0);
                    ImPlot.PlotScatter("s64 f", new long[] { 1, 2, 3 }, 3, 1.0, 0.0, ImPlotScatterFlags.None, 0, sizeof(long));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ulong array PlotScatter overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_UlongArray_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P7Ulong", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotScatter("u64 a", new ulong[] { 1, 2, 3 }, 3);
                    ImPlot.PlotScatter("u64 b", new ulong[] { 1, 2, 3 }, 3, 1.0);
                    ImPlot.PlotScatter("u64 c", new ulong[] { 1, 2, 3 }, 3, 1.0, 0.0);
                    ImPlot.PlotScatter("u64 d", new ulong[] { 1, 2, 3 }, 3, 1.0, 0.0, ImPlotScatterFlags.None);
                    ImPlot.PlotScatter("u64 e", new ulong[] { 1, 2, 3 }, 3, 1.0, 0.0, ImPlotScatterFlags.None, 0);
                    ImPlot.PlotScatter("u64 f", new ulong[] { 1, 2, 3 }, 3, 1.0, 0.0, ImPlotScatterFlags.None, 0, sizeof(ulong));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ref float and ref double PlotScatter overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_Float_And_Double_Ref_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P7FloatDouble", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    float floatXs = default;
                    float floatYs = default;
                    ImPlot.PlotScatter("f a", ref floatXs, ref floatYs, 1);
                    ImPlot.PlotScatter("f b", ref floatXs, ref floatYs, 1, ImPlotScatterFlags.None);
                    ImPlot.PlotScatter("f c", ref floatXs, ref floatYs, 1, ImPlotScatterFlags.None, 0);
                    ImPlot.PlotScatter("f d", ref floatXs, ref floatYs, 1, ImPlotScatterFlags.None, 0, sizeof(float));
                    double doubleXs = default;
                    double doubleYs = default;
                    ImPlot.PlotScatter("d a", ref doubleXs, ref doubleYs, 1);
                    ImPlot.PlotScatter("d b", ref doubleXs, ref doubleYs, 1, ImPlotScatterFlags.None);
                    ImPlot.PlotScatter("d c", ref doubleXs, ref doubleYs, 1, ImPlotScatterFlags.None, 0);
                    ImPlot.PlotScatter("d d", ref doubleXs, ref doubleYs, 1, ImPlotScatterFlags.None, 0, sizeof(double));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ref sbyte and ref byte PlotScatter overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_Sbyte_And_Byte_Ref_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P7SbyteByte", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    sbyte sbyteXs = default;
                    sbyte sbyteYs = default;
                    ImPlot.PlotScatter("s8 a", ref sbyteXs, ref sbyteYs, 1);
                    ImPlot.PlotScatter("s8 b", ref sbyteXs, ref sbyteYs, 1, ImPlotScatterFlags.None);
                    ImPlot.PlotScatter("s8 c", ref sbyteXs, ref sbyteYs, 1, ImPlotScatterFlags.None, 0);
                    ImPlot.PlotScatter("s8 d", ref sbyteXs, ref sbyteYs, 1, ImPlotScatterFlags.None, 0, sizeof(sbyte));
                    byte byteXs = default;
                    byte byteYs = default;
                    ImPlot.PlotScatter("u8 a", ref byteXs, ref byteYs, 1);
                    ImPlot.PlotScatter("u8 b", ref byteXs, ref byteYs, 1, ImPlotScatterFlags.None);
                    ImPlot.PlotScatter("u8 c", ref byteXs, ref byteYs, 1, ImPlotScatterFlags.None, 0);
                    ImPlot.PlotScatter("u8 d", ref byteXs, ref byteYs, 1, ImPlotScatterFlags.None, 0, sizeof(byte));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ref short PlotScatter overload inside an active plot in isolation.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_Short_Ref_Overload_Executes()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P7Short", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    short shortXs = default;
                    short shortYs = default;
                    ImPlot.PlotScatter("s16 r", ref shortXs, ref shortYs, 1);
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
