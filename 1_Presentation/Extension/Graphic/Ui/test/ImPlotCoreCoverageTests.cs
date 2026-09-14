// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotCoreCoverageTests.cs
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
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Extras.Plot.Test
{
    /// <summary>
    ///     Raises ImPlot.cs line coverage: null-label tests marshal every string wrapper body
    ///     headless, native tests exercise the pure P/Invoke wrappers against the real cimgui
    ///     library inside a fresh context and an active plot frame.
    /// </summary>
    public class ImPlotCoreCoverageTests
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
        ///     Synchronizes the ImGui and ImPlot context pointers of every loaded cimgui image. Both
        ///     slots are resolved through the exported symbol of each image instead of hardcoded
        ///     offsets, which vary between the x64 and arm64 slices of the native library. The handle
        ///     opened with RtlNoLoad is never closed because dlclose can unload the image, and every
        ///     resolved address is verified with dladdr before the write so a stale slot can never
        ///     fault the test host.
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
                    IntPtr handle = DlOpen(name, RtlNoLoad);

                    if (handle != IntPtr.Zero)
                    {
                        IntPtr slot = Dlsym(handle, "GImGui");

                        if (slot != IntPtr.Zero && IsLoadedCimgui(slot))
                        {
                            Marshal.WriteIntPtr(slot, imgui);
                        }

                        slot = Dlsym(handle, "GImPlot");

                        if (slot != IntPtr.Zero && IsLoadedCimgui(slot))
                        {
                            Marshal.WriteIntPtr(slot, implot);
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
        ///     Verifies the ushort PlotStems wrapper overloads throw on a null label.
        /// </summary>
        [Fact]
        public void PlotStems_U16_0_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort xs = 1;
            ushort ys = 2;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None)));
        }

        /// <summary>
        ///     Verifies the ushort PlotStems offset overload throws on a null label.
        /// </summary>
        [Fact]
        public void PlotStems_U16_1_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort xs = 1;
            ushort ys = 2;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None, 0)));
        }

        /// <summary>
        ///     Verifies the ushort PlotStems offset stride overload throws on a null label.
        /// </summary>
        [Fact]
        public void PlotStems_U16_2_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort xs = 1;
            ushort ys = 2;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None, 0, sizeof(ushort))));
        }

        /// <summary>
        ///     Verifies the int PlotStems base overload throws on a null label.
        /// </summary>
        [Fact]
        public void PlotStems_S32_0_NullLabel_ShouldThrowArgumentNullException()
        {
            int xs = 1;
            int ys = 2;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, ref xs, ref ys, 1)));
        }

        /// <summary>
        ///     Verifies the int PlotStems ref overload throws on a null label.
        /// </summary>
        [Fact]
        public void PlotStems_S32_1_NullLabel_ShouldThrowArgumentNullException()
        {
            int xs = 1;
            int ys = 2;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, ref xs, ref ys, 1, 0.0)));
        }

        /// <summary>
        ///     Verifies the int PlotStems flags overload throws on a null label.
        /// </summary>
        [Fact]
        public void PlotStems_S32_2_NullLabel_ShouldThrowArgumentNullException()
        {
            int xs = 1;
            int ys = 2;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None)));
        }

        /// <summary>
        ///     Verifies the int PlotStems flags offset overload throws on a null label.
        /// </summary>
        [Fact]
        public void PlotStems_S32_3_NullLabel_ShouldThrowArgumentNullException()
        {
            int xs = 1;
            int ys = 2;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None, 0)));
        }

        /// <summary>
        ///     Verifies the int PlotStems full overload throws on a null label.
        /// </summary>
        [Fact]
        public void PlotStems_S32_4_NullLabel_ShouldThrowArgumentNullException()
        {
            int xs = 1;
            int ys = 2;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None, 0, sizeof(int))));
        }

        /// <summary>
        ///     Verifies the uint PlotStems base overload throws on a null label.
        /// </summary>
        [Fact]
        public void PlotStems_U32_0_NullLabel_ShouldThrowArgumentNullException()
        {
            uint xs = 1;
            uint ys = 2;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, ref xs, ref ys, 1)));
        }

        /// <summary>
        ///     Verifies the uint PlotStems ref overload throws on a null label.
        /// </summary>
        [Fact]
        public void PlotStems_U32_1_NullLabel_ShouldThrowArgumentNullException()
        {
            uint xs = 1;
            uint ys = 2;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, ref xs, ref ys, 1, 0.0)));
        }

        /// <summary>
        ///     Verifies the uint PlotStems flags overload throws on a null label.
        /// </summary>
        [Fact]
        public void PlotStems_U32_2_NullLabel_ShouldThrowArgumentNullException()
        {
            uint xs = 1;
            uint ys = 2;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None)));
        }

        /// <summary>
        ///     Verifies the uint PlotStems flags offset overload throws on a null label.
        /// </summary>
        [Fact]
        public void PlotStems_U32_3_NullLabel_ShouldThrowArgumentNullException()
        {
            uint xs = 1;
            uint ys = 2;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None, 0)));
        }

        /// <summary>
        ///     Verifies the uint PlotStems full overload throws on a null label.
        /// </summary>
        [Fact]
        public void PlotStems_U32_4_NullLabel_ShouldThrowArgumentNullException()
        {
            uint xs = 1;
            uint ys = 2;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None, 0, sizeof(uint))));
        }

        /// <summary>
        ///     Verifies the long PlotStems base overload throws on a null label.
        /// </summary>
        [Fact]
        public void PlotStems_S64_0_NullLabel_ShouldThrowArgumentNullException()
        {
            long xs = 1;
            long ys = 2;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, ref xs, ref ys, 1)));
        }

        /// <summary>
        ///     Verifies the long PlotStems ref overload throws on a null label.
        /// </summary>
        [Fact]
        public void PlotStems_S64_1_NullLabel_ShouldThrowArgumentNullException()
        {
            long xs = 1;
            long ys = 2;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, ref xs, ref ys, 1, 0.0)));
        }

        /// <summary>
        ///     Verifies the long PlotStems flags overload throws on a null label.
        /// </summary>
        [Fact]
        public void PlotStems_S64_2_NullLabel_ShouldThrowArgumentNullException()
        {
            long xs = 1;
            long ys = 2;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None)));
        }

        /// <summary>
        ///     Verifies the long PlotStems flags offset overload throws on a null label.
        /// </summary>
        [Fact]
        public void PlotStems_S64_3_NullLabel_ShouldThrowArgumentNullException()
        {
            long xs = 1;
            long ys = 2;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None, 0)));
        }

        /// <summary>
        ///     Verifies the long PlotStems full overload throws on a null label.
        /// </summary>
        [Fact]
        public void PlotStems_S64_4_NullLabel_ShouldThrowArgumentNullException()
        {
            long xs = 1;
            long ys = 2;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None, 0, sizeof(long))));
        }

        /// <summary>
        ///     Verifies the ulong PlotStems base overload throws on a null label.
        /// </summary>
        [Fact]
        public void PlotStems_U64_0_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong xs = 1;
            ulong ys = 2;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, ref xs, ref ys, 1)));
        }

        /// <summary>
        ///     Verifies the ulong PlotStems ref overload throws on a null label.
        /// </summary>
        [Fact]
        public void PlotStems_U64_1_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong xs = 1;
            ulong ys = 2;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, ref xs, ref ys, 1, 0.0)));
        }

        /// <summary>
        ///     Verifies the ulong PlotStems flags overload throws on a null label.
        /// </summary>
        [Fact]
        public void PlotStems_U64_2_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong xs = 1;
            ulong ys = 2;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None)));
        }

        /// <summary>
        ///     Verifies the ulong PlotStems flags offset overload throws on a null label.
        /// </summary>
        [Fact]
        public void PlotStems_U64_3_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong xs = 1;
            ulong ys = 2;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None, 0)));
        }

        /// <summary>
        ///     Verifies the ulong PlotStems full overload throws on a null label.
        /// </summary>
        [Fact]
        public void PlotStems_U64_4_NullLabel_ShouldThrowArgumentNullException()
        {
            ulong xs = 1;
            ulong ys = 2;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems((string)null, ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None, 0, sizeof(ulong))));
        }

        /// <summary>
        ///     Verifies PlotText without offset throws on a null text.
        /// </summary>
        [Fact]
        public void PlotText_0_NullText_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotText((string)null, 0.5, 0.5)));
        }

        /// <summary>
        ///     Verifies PlotText with an offset throws on a null text.
        /// </summary>
        [Fact]
        public void PlotText_1_NullText_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotText((string)null, 0.5, 0.5, new Vector2F(4, 4))));
        }

        /// <summary>
        ///     Verifies PlotText with an offset and flags throws on a null text.
        /// </summary>
        [Fact]
        public void PlotText_2_NullText_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotText((string)null, 0.5, 0.5, new Vector2F(4, 4), ImPlotTextFlags.None)));
        }

        /// <summary>
        ///     Verifies PushColormap by name throws on a null name.
        /// </summary>
        [Fact]
        public void PushColormap_NullName_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PushColormap((string)null)));
        }

        /// <summary>
        ///     Verifies SetupAxes without flags throws on a null label.
        /// </summary>
        [Fact]
        public void SetupAxes_0_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.SetupAxes((string)null, "y")));
        }

        /// <summary>
        ///     Verifies SetupAxes with x flags throws on a null label.
        /// </summary>
        [Fact]
        public void SetupAxes_1_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.SetupAxes((string)null, "y", ImPlotAxisFlags.None)));
        }

        /// <summary>
        ///     Verifies SetupAxes with both flags throws on a null label.
        /// </summary>
        [Fact]
        public void SetupAxes_2_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.SetupAxes((string)null, "y", ImPlotAxisFlags.None, ImPlotAxisFlags.None)));
        }

        /// <summary>
        ///     Verifies SetupAxis with a label throws on a null label.
        /// </summary>
        [Fact]
        public void SetupAxis_Label_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.SetupAxis(ImAxis.X1, (string)null)));
        }

        /// <summary>
        ///     Verifies SetupAxis with a label and flags throws on a null label.
        /// </summary>
        [Fact]
        public void SetupAxis_Label_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.SetupAxis(ImAxis.X1, (string)null, ImPlotAxisFlags.None)));
        }

        /// <summary>
        ///     Verifies SetupAxisFormat throws on a null format.
        /// </summary>
        [Fact]
        public void SetupAxisFormat_NullFormat_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.SetupAxisFormat(ImAxis.X1, (string)null)));
        }

        /// <summary>
        ///     Verifies ShowColormapSelector throws on a null label.
        /// </summary>
        [Fact]
        public void ShowColormapSelector_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.ShowColormapSelector((string)null)));
        }

        /// <summary>
        ///     Verifies ShowInputMapSelector throws on a null label.
        /// </summary>
        [Fact]
        public void ShowInputMapSelector_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.ShowInputMapSelector((string)null)));
        }

        /// <summary>
        ///     Verifies ShowStyleSelector throws on a null label.
        /// </summary>
        [Fact]
        public void ShowStyleSelector_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.ShowStyleSelector((string)null)));
        }

        /// <summary>
        ///     Verifies TagX with a format throws on a null format.
        /// </summary>
        [Fact]
        public void TagX_Format_NullFormat_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.TagX(0.5, new Vector4F(1, 0, 0, 1), (string)null)));
        }

        /// <summary>
        ///     Verifies TagY with a format throws on a null format.
        /// </summary>
        [Fact]
        public void TagY_Format_NullFormat_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.TagY(0.5, new Vector4F(1, 0, 0, 1), (string)null)));
        }

        /// <summary>
        ///     Executes the style color, style var, colormap and next style wrapper overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Style_And_NextStyle_Functions_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                ImPlot.StyleColorsAuto();
                ImPlot.StyleColorsAuto(new ImPlotStyle());
                ImPlot.StyleColorsLight();
                ImPlot.StyleColorsLight(new ImPlotStyle());
                ImPlot.StyleColorsDark();
                ImPlot.StyleColorsDark(new ImPlotStyle());
                ImPlot.StyleColorsClassic();
                ImPlot.StyleColorsClassic(new ImPlotStyle());
                ImPlot.PushStyleColor(ImPlotCol.Line, 0xFF0000FFu);
                ImPlot.PopStyleColor();
                ImPlot.PushStyleColor(ImPlotCol.Line, new Vector4F(1, 0, 0, 1));
                ImPlot.PopStyleColor(1);
                ImPlot.PushStyleVar(ImPlotStyleVar.LineWeight, 2.0f);
                ImPlot.PushStyleVar(ImPlotStyleVar.LineWeight, 2);
                ImPlot.PushStyleVar(ImPlotStyleVar.PlotPadding, new Vector2F(4, 4));
                ImPlot.PopStyleVar();
                ImPlot.PopStyleVar(2);
                ImPlot.PushColormap(ImPlotColormap.Deep);
                ImPlot.PopColormap();
                ImPlot.PushColormap("Deep");
                ImPlot.PopColormap(1);
                _ = ImPlot.SampleColormap(0.5f);
                _ = ImPlot.SampleColormap(0.5f, ImPlotColormap.Deep);
                ImPlot.SetNextLineStyle();
                ImPlot.SetNextLineStyle(new Vector4F(1, 0, 0, 1));
                ImPlot.SetNextLineStyle(new Vector4F(1, 0, 0, 1), 2.0f);
                ImPlot.SetNextFillStyle();
                ImPlot.SetNextFillStyle(new Vector4F(1, 0, 0, 1));
                ImPlot.SetNextFillStyle(new Vector4F(1, 0, 0, 1), 0.5f);
                ImPlot.SetNextMarkerStyle();
                ImPlot.SetNextMarkerStyle(ImPlotMarker.Circle);
                ImPlot.SetNextMarkerStyle(ImPlotMarker.Circle, 4.0f);
                ImPlot.SetNextMarkerStyle(ImPlotMarker.Circle, 4.0f, new Vector4F(1, 0, 0, 1));
                ImPlot.SetNextMarkerStyle(ImPlotMarker.Circle, 4.0f, new Vector4F(1, 0, 0, 1), 1.0f);
                ImPlot.SetNextMarkerStyle(ImPlotMarker.Circle, 4.0f, new Vector4F(1, 0, 0, 1), 1.0f, new Vector4F(0, 0, 0, 1));
                ImPlot.SetNextErrorBarStyle();
                ImPlot.SetNextErrorBarStyle(new Vector4F(1, 0, 0, 1));
                ImPlot.SetNextErrorBarStyle(new Vector4F(1, 0, 0, 1), 2.0f);
                ImPlot.SetNextErrorBarStyle(new Vector4F(1, 0, 0, 1), 2.0f, 1.0f);
                ImPlot.ShowUserGuide();
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the next axes and next axis limit wrapper overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetNextAxes_And_Axis_Limits_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                ImPlot.SetNextAxesLimits(0, 1, 0, 1);
                ImPlot.SetNextAxesLimits(0, 1, 0, 1, ImPlotCond.Always);
                ImPlot.SetNextAxesToFit();
                ImPlot.SetNextAxisLimits(ImAxis.X1, 0, 1);
                ImPlot.SetNextAxisLimits(ImAxis.X1, 0, 1, ImPlotCond.Always);
                ImPlot.SetNextAxisToFit(ImAxis.X1);
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the plot frame setup, axis, tag, draw and selector wrappers inside an active plot.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotFrame_Setup_And_Draw_Functions_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("CorePlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("X Axis", "Y Axis");
                    ImPlot.SetupAxes("X Axis", "Y Axis", ImPlotAxisFlags.None);
                    ImPlot.SetupAxes("X Axis", "Y Axis", ImPlotAxisFlags.None, ImPlotAxisFlags.None);
                    ImPlot.SetupAxesLimits(0, 1, 0, 1);
                    ImPlot.SetupAxesLimits(0, 1, 0, 1, ImPlotCond.Always);
                    ImPlot.SetupAxis(ImAxis.X1);
                    ImPlot.SetupAxis(ImAxis.Y1, "Y");
                    ImPlot.SetupAxis(ImAxis.Y1, "Y", ImPlotAxisFlags.None);
                    ImPlot.SetupAxisLimits(ImAxis.X1, 0, 1);
                    ImPlot.SetupAxisLimits(ImAxis.X1, 0, 1, ImPlotCond.Always);
                    ImPlot.SetupAxisLimitsConstraints(ImAxis.X1, -10, 10);
                    ImPlot.SetupAxisFormat(ImAxis.X1, "%.2f");
                    ImPlot.SetupAxisScale(ImAxis.X1, ImPlotScale.Linear);
                    ImPlot.SetupAxisZoomConstraints(ImAxis.X1, 0.01, 100.0);
                    ImPlot.SetupLegend(ImPlotLocation.NorthWest);
                    ImPlot.SetupLegend(ImPlotLocation.NorthWest, ImPlotLegendFlags.None);
                    ImPlot.SetupMouseText(ImPlotLocation.SouthEast);
                    ImPlot.SetupMouseText(ImPlotLocation.SouthEast, ImPlotMouseTextFlags.None);
                    ImPlot.SetupFinish();
                    ImPlot.SetAxes(ImAxis.X1, ImAxis.Y1);
                    ImPlot.SetAxis(ImAxis.X1);
                    ImPlot.TagX(0.5, new Vector4F(1, 0, 0, 1));
                    ImPlot.TagX(0.5, new Vector4F(1, 0, 0, 1), true);
                    ImPlot.TagX(0.5, new Vector4F(1, 0, 0, 1), false);
                    ImPlot.TagY(0.5, new Vector4F(1, 0, 0, 1));
                    ImPlot.TagY(0.5, new Vector4F(1, 0, 0, 1), true);
                    ImPlot.TagY(0.5, new Vector4F(1, 0, 0, 1), false);
                    ImPlot.PlotText("Text", 0.5, 0.5);
                    ImPlot.PlotText("Text", 0.5, 0.5, new Vector2F(4, 4));
                    ImPlot.PlotText("Text", 0.5, 0.5, new Vector2F(4, 4), ImPlotTextFlags.None);
                    PlotStemsU16();
                    PlotStemsS64();
                    PlotStemsU64();
                    ImPlot.PushPlotClipRect();
                    ImPlot.PopPlotClipRect();
                    ImPlot.PushPlotClipRect(2.0f);
                    ImPlot.PopPlotClipRect();
                    ImPlot.ShowStyleEditor();
                    ImPlot.ShowStyleEditor(new ImPlotStyle());
                    _ = ImPlot.ShowStyleSelector("Style Selector");
                    _ = ImPlot.ShowColormapSelector("Colormap");
                    _ = ImPlot.ShowInputMapSelector("Input Map");
                    ImPlot.ShowMetricsWindow();
                    bool metricsOpen = true;
                    ImPlot.ShowMetricsWindow(ref metricsOpen);
                    bool metricsClosed = false;
                    ImPlot.ShowMetricsWindow(ref metricsClosed);
                    ImPlot.ShowDemoWindow();
                    bool demoOpen = true;
                    ImPlot.ShowDemoWindow(ref demoOpen);
                    bool demoClosed = false;
                    ImPlot.ShowDemoWindow(ref demoClosed);
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the PlotToPixels wrapper overloads inside an active plot.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotToPixels_AllOverloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("PixelPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlotPoint point = new ImPlotPoint { X = 0.5, Y = 0.5 };
                    _ = ImPlot.PlotToPixels(point);
                    _ = ImPlot.PlotToPixels(point, ImAxis.X1);
                    _ = ImPlot.PlotToPixels(point, ImAxis.X1, ImAxis.Y1);
                    _ = ImPlot.PlotToPixels(0.5, 0.5);
                    _ = ImPlot.PlotToPixels(0.5, 0.5, ImAxis.X1);
                    _ = ImPlot.PlotToPixels(0.5, 0.5, ImAxis.X1, ImAxis.Y1);
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the SetupAxisFormat and SetupAxisScale callback overloads inside an active plot.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetupAxisFormat_And_Scale_Callback_Overloads_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("FormatPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupAxisFormat(ImAxis.X1, IntPtr.Zero);
                    ImPlot.SetupAxisFormat(ImAxis.X1, IntPtr.Zero, IntPtr.Zero);
                    ImPlot.SetupAxisScale(ImAxis.X1, IntPtr.Zero, IntPtr.Zero);
                    ImPlot.SetupAxisScale(ImAxis.X1, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
                    ImPlot.SetupFinish();
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the next axis links wrapper inside an active plot.
        /// </summary>
        [RequireCImguiSystemFact]
        public void NextAxisLinks_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                double linkMin = 0.0;
                double linkMax = 1.0;
                ImPlot.SetNextAxisLinks(ImAxis.X1, ref linkMin, ref linkMax);
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the axis ticks array wrapper overloads inside an active plot. Every overload
        ///     throws a deterministic MarshalDirectiveException because the native signature declares
        ///     nested byte arrays, which the marshaller rejects before entering the native library.
        /// </summary>
        [RequireCImguiSystemFact]
        public void AxisTicks_Array_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("TickPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    double[] values = { 0.0, 0.5, 1.0 };
                    Assert.Throws<MarshalDirectiveException>((Action)(() => ImPlot.SetupAxisTicks(ImAxis.X1, values, 3)));
                    Assert.Throws<MarshalDirectiveException>((Action)(() => ImPlot.SetupAxisTicks(ImAxis.X1, values, 3, new string[] { })));
                    Assert.Throws<MarshalDirectiveException>((Action)(() => ImPlot.SetupAxisTicks(ImAxis.X1, values, 3, new string[] { }, true)));
                    ImPlot.SetupFinish();
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the axis ticks range wrapper overloads inside an active plot. Every overload
        ///     throws a deterministic MarshalDirectiveException because the native signature declares
        ///     nested byte arrays, which the marshaller rejects before entering the native library.
        /// </summary>
        [RequireCImguiSystemFact]
        public void AxisTicks_Range_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("TickPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    Assert.Throws<MarshalDirectiveException>((Action)(() => ImPlot.SetupAxisTicks(ImAxis.X1, 0, 1, 3)));
                    Assert.Throws<MarshalDirectiveException>((Action)(() => ImPlot.SetupAxisTicks(ImAxis.X1, 0, 1, 3, new string[] { })));
                    Assert.Throws<MarshalDirectiveException>((Action)(() => ImPlot.SetupAxisTicks(ImAxis.X1, 0, 1, 3, new string[] { }, true)));
                    ImPlot.SetupFinish();
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ushort PlotStems wrapper overloads inside an active plot.
        /// </summary>
        private static void PlotStemsU16()
        {
            ushort xs = 1;
            ushort ys = 2;
            ImPlot.PlotStems("u16 a", ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None);
            ImPlot.PlotStems("u16 b", ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None, 0);
            ImPlot.PlotStems("u16 c", ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None, 0, sizeof(ushort));
        }

        /// <summary>
        ///     Executes the long PlotStems wrapper overloads inside an active plot.
        /// </summary>
        private static void PlotStemsS64()
        {
            long xs = 1;
            long ys = 2;
            ImPlot.PlotStems("s64 a", ref xs, ref ys, 1);
            ImPlot.PlotStems("s64 b", ref xs, ref ys, 1, 0.0);
            ImPlot.PlotStems("s64 c", ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None);
            ImPlot.PlotStems("s64 d", ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None, 0);
            ImPlot.PlotStems("s64 e", ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None, 0, sizeof(long));
        }

        /// <summary>
        ///     Executes the ulong PlotStems wrapper overloads inside an active plot.
        /// </summary>
        private static void PlotStemsU64()
        {
            ulong xs = 1;
            ulong ys = 2;
            ImPlot.PlotStems("u64 a", ref xs, ref ys, 1);
            ImPlot.PlotStems("u64 b", ref xs, ref ys, 1, 0.0);
            ImPlot.PlotStems("u64 c", ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None);
            ImPlot.PlotStems("u64 d", ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None, 0);
            ImPlot.PlotStems("u64 e", ref xs, ref ys, 1, 0.0, ImPlotStemsFlags.None, 0, sizeof(ulong));
        }
    }
}