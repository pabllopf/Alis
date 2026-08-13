// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP19ExecutionTests.cs
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
    ///     Executes the ImPlotP19 wrapper methods (PlotStairs overloads for byte, short,
    ///     ushort, int, uint, long and ulong arrays plus float, double, sbyte and byte
    ///     reference pairs) against the native cimgui library so that the managed bodies
    ///     of the wrappers in ImPlotP19.cs are exercised for line coverage.
    /// </summary>
    public class ImPlotP19ExecutionTests
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
        ///     Executes the byte array PlotStairs wrapper overloads inside the active plot.
        /// </summary>
        [MacOsOnly]
        public void PlotStairs_ByteArray_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                byte[] values = new byte[] { 1, 2, 3 };
                if (ImPlot.BeginPlot("P19 Stairs Byte", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotStairs("u8 a", values, 3, 1.0, 0.0, ImPlotStairsFlags.None);
                    ImPlot.PlotStairs("u8 b", values, 3, 1.0, 0.0, ImPlotStairsFlags.None, 0);
                    ImPlot.PlotStairs("u8 c", values, 3, 1.0, 0.0, ImPlotStairsFlags.None, 0, sizeof(byte));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the short array PlotStairs wrapper overloads inside the active plot.
        /// </summary>
        [MacOsOnly]
        public void PlotStairs_ShortArray_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                short[] values = new short[] { 1, 2, 3 };
                if (ImPlot.BeginPlot("P19 Stairs Short", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotStairs("s16 a", values, 3);
                    ImPlot.PlotStairs("s16 b", values, 3, 1.0);
                    ImPlot.PlotStairs("s16 c", values, 3, 1.0, 0.0);
                    ImPlot.PlotStairs("s16 d", values, 3, 1.0, 0.0, ImPlotStairsFlags.None);
                    ImPlot.PlotStairs("s16 e", values, 3, 1.0, 0.0, ImPlotStairsFlags.None, 0);
                    ImPlot.PlotStairs("s16 f", values, 3, 1.0, 0.0, ImPlotStairsFlags.None, 0, sizeof(short));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ushort array PlotStairs wrapper overloads inside the active plot.
        /// </summary>
        [MacOsOnly]
        public void PlotStairs_UshortArray_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                ushort[] values = new ushort[] { 1, 2, 3 };
                if (ImPlot.BeginPlot("P19 Stairs Ushort", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotStairs("u16 a", values, 3);
                    ImPlot.PlotStairs("u16 b", values, 3, 1.0);
                    ImPlot.PlotStairs("u16 c", values, 3, 1.0, 0.0);
                    ImPlot.PlotStairs("u16 d", values, 3, 1.0, 0.0, ImPlotStairsFlags.None);
                    ImPlot.PlotStairs("u16 e", values, 3, 1.0, 0.0, ImPlotStairsFlags.None, 0);
                    ImPlot.PlotStairs("u16 f", values, 3, 1.0, 0.0, ImPlotStairsFlags.None, 0, sizeof(ushort));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the int array PlotStairs wrapper overloads inside the active plot.
        /// </summary>
        [MacOsOnly]
        public void PlotStairs_IntArray_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                int[] values = new int[] { 1, 2, 3 };
                if (ImPlot.BeginPlot("P19 Stairs Int", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotStairs("s32 a", values, 3);
                    ImPlot.PlotStairs("s32 b", values, 3, 1.0);
                    ImPlot.PlotStairs("s32 c", values, 3, 1.0, 0.0);
                    ImPlot.PlotStairs("s32 d", values, 3, 1.0, 0.0, ImPlotStairsFlags.None);
                    ImPlot.PlotStairs("s32 e", values, 3, 1.0, 0.0, ImPlotStairsFlags.None, 0);
                    ImPlot.PlotStairs("s32 f", values, 3, 1.0, 0.0, ImPlotStairsFlags.None, 0, sizeof(int));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the uint array PlotStairs wrapper overloads inside the active plot.
        /// </summary>
        [MacOsOnly]
        public void PlotStairs_UintArray_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                uint[] values = new uint[] { 1, 2, 3 };
                if (ImPlot.BeginPlot("P19 Stairs Uint", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotStairs("u32 a", values, 3);
                    ImPlot.PlotStairs("u32 b", values, 3, 1.0);
                    ImPlot.PlotStairs("u32 c", values, 3, 1.0, 0.0);
                    ImPlot.PlotStairs("u32 d", values, 3, 1.0, 0.0, ImPlotStairsFlags.None);
                    ImPlot.PlotStairs("u32 e", values, 3, 1.0, 0.0, ImPlotStairsFlags.None, 0);
                    ImPlot.PlotStairs("u32 f", values, 3, 1.0, 0.0, ImPlotStairsFlags.None, 0, sizeof(uint));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the long array PlotStairs wrapper overloads inside the active plot.
        /// </summary>
        [MacOsOnly]
        public void PlotStairs_LongArray_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                long[] values = new long[] { 1, 2, 3 };
                if (ImPlot.BeginPlot("P19 Stairs Long", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotStairs("s64 a", values, 3);
                    ImPlot.PlotStairs("s64 b", values, 3, 1.0);
                    ImPlot.PlotStairs("s64 c", values, 3, 1.0, 0.0);
                    ImPlot.PlotStairs("s64 d", values, 3, 1.0, 0.0, ImPlotStairsFlags.None);
                    ImPlot.PlotStairs("s64 e", values, 3, 1.0, 0.0, ImPlotStairsFlags.None, 0);
                    ImPlot.PlotStairs("s64 f", values, 3, 1.0, 0.0, ImPlotStairsFlags.None, 0, sizeof(long));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ulong array PlotStairs wrapper overloads inside the active plot.
        /// </summary>
        [MacOsOnly]
        public void PlotStairs_UlongArray_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                ulong[] values = new ulong[] { 1, 2, 3 };
                if (ImPlot.BeginPlot("P19 Stairs Ulong", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotStairs("u64 a", values, 3);
                    ImPlot.PlotStairs("u64 b", values, 3, 1.0);
                    ImPlot.PlotStairs("u64 c", values, 3, 1.0, 0.0);
                    ImPlot.PlotStairs("u64 d", values, 3, 1.0, 0.0, ImPlotStairsFlags.None);
                    ImPlot.PlotStairs("u64 e", values, 3, 1.0, 0.0, ImPlotStairsFlags.None, 0);
                    ImPlot.PlotStairs("u64 f", values, 3, 1.0, 0.0, ImPlotStairsFlags.None, 0, sizeof(ulong));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the float reference PlotStairs wrapper overloads inside the active plot.
        /// </summary>
        [MacOsOnly]
        public void PlotStairs_FloatRef_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                float xs = default;
                float ys = default;
                if (ImPlot.BeginPlot("P19 Stairs Float", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotStairs("f a", ref xs, ref ys, 1);
                    ImPlot.PlotStairs("f b", ref xs, ref ys, 1, ImPlotStairsFlags.None);
                    ImPlot.PlotStairs("f c", ref xs, ref ys, 1, ImPlotStairsFlags.None, 0);
                    ImPlot.PlotStairs("f d", ref xs, ref ys, 1, ImPlotStairsFlags.None, 0, sizeof(float));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the double reference PlotStairs wrapper overloads inside the active plot.
        /// </summary>
        [MacOsOnly]
        public void PlotStairs_DoubleRef_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                double xs = default;
                double ys = default;
                if (ImPlot.BeginPlot("P19 Stairs Double", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotStairs("d a", ref xs, ref ys, 1);
                    ImPlot.PlotStairs("d b", ref xs, ref ys, 1, ImPlotStairsFlags.None);
                    ImPlot.PlotStairs("d c", ref xs, ref ys, 1, ImPlotStairsFlags.None, 0);
                    ImPlot.PlotStairs("d d", ref xs, ref ys, 1, ImPlotStairsFlags.None, 0, sizeof(double));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the sbyte reference PlotStairs wrapper overloads inside the active plot.
        /// </summary>
        [MacOsOnly]
        public void PlotStairs_SbyteRef_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                sbyte xs = default;
                sbyte ys = default;
                if (ImPlot.BeginPlot("P19 Stairs Sbyte", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotStairs("s8 a", ref xs, ref ys, 1);
                    ImPlot.PlotStairs("s8 b", ref xs, ref ys, 1, ImPlotStairsFlags.None);
                    ImPlot.PlotStairs("s8 c", ref xs, ref ys, 1, ImPlotStairsFlags.None, 0);
                    ImPlot.PlotStairs("s8 d", ref xs, ref ys, 1, ImPlotStairsFlags.None, 0, sizeof(sbyte));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the byte reference PlotStairs wrapper overloads inside the active plot.
        /// </summary>
        [MacOsOnly]
        public void PlotStairs_ByteRef_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                byte xs = default;
                byte ys = default;
                if (ImPlot.BeginPlot("P19 Stairs ByteRef", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlot.PlotStairs("u8r a", ref xs, ref ys, 1);
                    ImPlot.PlotStairs("u8r b", ref xs, ref ys, 1, ImPlotStairsFlags.None);
                    ImPlot.PlotStairs("u8r c", ref xs, ref ys, 1, ImPlotStairsFlags.None, 0);
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
