// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP21ExecutionTests.cs
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
    ///     Executes the real ImPlot PlotShaded wrapper overloads of the ImPlotP21 partial class against the native
    ///     cimgui library so that the managed bodies are exercised for line coverage.
    /// </summary>
    public class ImPlotP21ExecutionTests
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
        ///     Executes the sbyte pair PlotShaded wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_S8_Pair_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P21S8", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    sbyte xs = default;
                    sbyte ys = default;
                    ImPlot.PlotShaded("s8 a", ref xs, ref ys, 1);
                    ImPlot.PlotShaded("s8 b", ref xs, ref ys, 1, 0.0);
                    ImPlot.PlotShaded("s8 c", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None);
                    ImPlot.PlotShaded("s8 d", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None, 0);
                    ImPlot.PlotShaded("s8 e", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None, 0, sizeof(sbyte));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the byte pair PlotShaded wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_U8_Pair_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P21U8", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    byte xs = default;
                    byte ys = default;
                    ImPlot.PlotShaded("u8 a", ref xs, ref ys, 1);
                    ImPlot.PlotShaded("u8 b", ref xs, ref ys, 1, 0.0);
                    ImPlot.PlotShaded("u8 c", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None);
                    ImPlot.PlotShaded("u8 d", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None, 0);
                    ImPlot.PlotShaded("u8 e", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None, 0, sizeof(byte));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the short pair PlotShaded wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_S16_Pair_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P21S16", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    short xs = default;
                    short ys = default;
                    ImPlot.PlotShaded("s16 a", ref xs, ref ys, 1);
                    ImPlot.PlotShaded("s16 b", ref xs, ref ys, 1, 0.0);
                    ImPlot.PlotShaded("s16 c", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None);
                    ImPlot.PlotShaded("s16 d", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None, 0);
                    ImPlot.PlotShaded("s16 e", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None, 0, sizeof(short));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ushort pair PlotShaded wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_U16_Pair_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P21U16", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ushort xs = default;
                    ushort ys = default;
                    ImPlot.PlotShaded("u16 a", ref xs, ref ys, 1);
                    ImPlot.PlotShaded("u16 b", ref xs, ref ys, 1, 0.0);
                    ImPlot.PlotShaded("u16 c", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None);
                    ImPlot.PlotShaded("u16 d", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None, 0);
                    ImPlot.PlotShaded("u16 e", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None, 0, sizeof(ushort));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the int pair PlotShaded wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_S32_Pair_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P21S32", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    int xs = default;
                    int ys = default;
                    ImPlot.PlotShaded("s32 a", ref xs, ref ys, 1);
                    ImPlot.PlotShaded("s32 b", ref xs, ref ys, 1, 0.0);
                    ImPlot.PlotShaded("s32 c", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None);
                    ImPlot.PlotShaded("s32 d", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None, 0);
                    ImPlot.PlotShaded("s32 e", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None, 0, sizeof(int));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the uint pair PlotShaded wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_U32_Pair_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P21U32", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    uint xs = default;
                    uint ys = default;
                    ImPlot.PlotShaded("u32 a", ref xs, ref ys, 1);
                    ImPlot.PlotShaded("u32 b", ref xs, ref ys, 1, 0.0);
                    ImPlot.PlotShaded("u32 c", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None);
                    ImPlot.PlotShaded("u32 d", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None, 0);
                    ImPlot.PlotShaded("u32 e", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None, 0, sizeof(uint));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the long pair PlotShaded wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_S64_Pair_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P21S64", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    long xs = default;
                    long ys = default;
                    ImPlot.PlotShaded("s64 a", ref xs, ref ys, 1);
                    ImPlot.PlotShaded("s64 b", ref xs, ref ys, 1, 0.0);
                    ImPlot.PlotShaded("s64 c", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None);
                    ImPlot.PlotShaded("s64 d", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None, 0);
                    ImPlot.PlotShaded("s64 e", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None, 0, sizeof(long));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ulong pair PlotShaded wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_U64_Pair_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P21U64", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ulong xs = default;
                    ulong ys = default;
                    ImPlot.PlotShaded("u64 a", ref xs, ref ys, 1);
                    ImPlot.PlotShaded("u64 b", ref xs, ref ys, 1, 0.0);
                    ImPlot.PlotShaded("u64 c", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None);
                    ImPlot.PlotShaded("u64 d", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None, 0);
                    ImPlot.PlotShaded("u64 e", ref xs, ref ys, 1, 0.0, ImPlotShadedFlags.None, 0, sizeof(ulong));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the float triple PlotShaded wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_Float_Triple_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P21Float", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    float xs = default;
                    float ys1 = default;
                    float ys2 = default;
                    ImPlot.PlotShaded("flt a", ref xs, ref ys1, ref ys2, 1);
                    ImPlot.PlotShaded("flt b", ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None);
                    ImPlot.PlotShaded("flt c", ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None, 0);
                    ImPlot.PlotShaded("flt d", ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None, 0, sizeof(float));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the double triple PlotShaded wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_Double_Triple_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P21Double", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    double xs = default;
                    double ys1 = default;
                    double ys2 = default;
                    ImPlot.PlotShaded("dbl a", ref xs, ref ys1, ref ys2, 1);
                    ImPlot.PlotShaded("dbl b", ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None);
                    ImPlot.PlotShaded("dbl c", ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None, 0);
                    ImPlot.PlotShaded("dbl d", ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None, 0, sizeof(double));
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the sbyte triple PlotShaded wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_S8_Triple_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("P21S8Triple", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    sbyte xs = default;
                    sbyte ys1 = default;
                    sbyte ys2 = default;
                    ImPlot.PlotShaded("s8t a", ref xs, ref ys1, ref ys2, 1);
                    ImPlot.PlotShaded("s8t b", ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None);
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
