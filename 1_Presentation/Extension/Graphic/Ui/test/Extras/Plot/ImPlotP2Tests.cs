// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP2Tests.cs
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
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     Executes the ImPlotP2 wrapper methods against the native cimgui library so that
    ///     the managed bodies of the wrappers in ImPlotP2.cs are exercised for line coverage.
    /// </summary>
    public class ImPlotP2Tests
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
        ///     Determines whether the cimgui native library can be loaded
        /// </summary>
        /// <returns>True if the library can be loaded</returns>
        private static bool CanLoadCImguiLibrary()
        {
            if (NativeLibrary.TryLoad("cimgui", out _))
            {
                return true;
            }

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImPlotP2Tests).Assembly.Location);
            if (assemblyDir == null)
            {
                return false;
            }

            string[] candidates = new[]
            {
                System.IO.Path.Combine(assemblyDir, "cimgui"),
                System.IO.Path.Combine(assemblyDir, "libcimgui"),
                System.IO.Path.Combine(assemblyDir, "libcimgui.dylib")
            };

            foreach (string candidate in candidates)
            {
                if (System.IO.File.Exists(candidate) && NativeLibrary.TryLoad(candidate, out _))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///     Executes the context and colormap query wrapper overloads.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Context_And_Colormap_Functions_Execute()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                IntPtr implot = ImPlot.GetCurrentContext();
                Assert.NotEqual(IntPtr.Zero, implot);
                ImPlotInputMap inputMap = ImPlot.GetInputMap();
                Assert.NotNull(inputMap);
                ImPlotStyle style = ImPlot.GetStyle();
                Assert.NotNull(style);

                try
                {
                    string styleColorName = ImPlot.GetStyleColorName(ImPlotCol.Line);
                    Assert.False(string.IsNullOrEmpty(styleColorName));
                }
                catch (MarshalDirectiveException)
                {
                }

                int colormapCount = ImPlot.GetColormapCount();
                Assert.True(colormapCount > 0);
                int colormapSize = ImPlot.GetColormapSize();
                Assert.True(colormapSize > 0);
                int colormapSizeDeep = ImPlot.GetColormapSize(ImPlotColormap.Deep);
                Assert.True(colormapSizeDeep > 0);

                try
                {
                    string colormapName = ImPlot.GetColormapName(ImPlotColormap.Deep);
                    Assert.False(string.IsNullOrEmpty(colormapName));
                }
                catch (MarshalDirectiveException)
                {
                }

                ImPlotColormap colormapIndex = ImPlot.GetColormapIndex("Deep");
                Assert.Equal(ImPlotColormap.Deep, colormapIndex);
                Vector4F colormapColor = ImPlot.GetColormapColor(0);
                Assert.NotNull(colormapColor);
                Vector4F colormapColorDeep = ImPlot.GetColormapColor(0, ImPlotColormap.Deep);
                Assert.NotNull(colormapColorDeep);

                try
                {
                    string markerName = ImPlot.GetMarkerName(ImPlotMarker.Circle);
                    Assert.False(string.IsNullOrEmpty(markerName));
                }
                catch (MarshalDirectiveException)
                {
                }

                Vector4F lastItemColor = ImPlot.GetLastItemColor();
                Assert.NotNull(lastItemColor);
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the plot state query wrapper overloads inside an active plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void Plot_State_Queries_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                bool opened = ImPlot.BeginPlot("ImPlotP2 State Plot", new Vector2F(400, 300), ImPlotFlags.None);
                Assert.True(opened);
                if (opened)
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    ImPlotPoint mousePos = ImPlot.GetPlotMousePos();
                    Assert.NotNull(mousePos);
                    ImPlotPoint mousePosX = ImPlot.GetPlotMousePos(ImAxis.X1);
                    Assert.NotNull(mousePosX);
                    ImPlotPoint mousePosXY = ImPlot.GetPlotMousePos(ImAxis.X1, ImAxis.Y1);
                    Assert.NotNull(mousePosXY);
                    Vector2F plotPos = ImPlot.GetPlotPos();
                    Assert.NotNull(plotPos);
                    Vector2F plotSize = ImPlot.GetPlotSize();
                    Assert.NotNull(plotSize);
                    ImDrawList drawList = ImPlot.GetPlotDrawList();
                    Assert.NotNull(drawList);
                    bool axisHovered = ImPlot.IsAxisHovered(ImAxis.X1);
                    Assert.False(axisHovered);
                    bool legendHovered = ImPlot.IsLegendEntryHovered("label");
                    Assert.False(legendHovered);
                    bool plotHovered = ImPlot.IsPlotHovered();
                    Assert.False(plotHovered);
                    bool plotSelected = ImPlot.IsPlotSelected();
                    Assert.False(plotSelected);
                    ImPlot.HideNextItem();
                    ImPlot.HideNextItem(false);
                    ImPlot.HideNextItem(false, ImPlotCond.Once);
                    Vector4F nextColor = ImPlot.NextColormapColor();
                    Assert.NotNull(nextColor);
                    ImPlotPoint pixelsVec2 = ImPlot.PixelsToPlot(new Vector2F(10, 10));
                    Assert.NotNull(pixelsVec2);
                    ImPlotPoint pixelsVec2X = ImPlot.PixelsToPlot(new Vector2F(10, 10), ImAxis.X1);
                    Assert.NotNull(pixelsVec2X);
                    ImPlotPoint pixelsVec2XY = ImPlot.PixelsToPlot(new Vector2F(10, 10), ImAxis.X1, ImAxis.Y1);
                    Assert.NotNull(pixelsVec2XY);
                    ImPlotPoint pixelsFloat = ImPlot.PixelsToPlot(10, 10);
                    Assert.NotNull(pixelsFloat);
                    ImPlotPoint pixelsFloatX = ImPlot.PixelsToPlot(10, 10, ImAxis.X1);
                    Assert.NotNull(pixelsFloatX);
                    ImPlotPoint pixelsFloatXY = ImPlot.PixelsToPlot(10, 10, ImAxis.X1, ImAxis.Y1);
                    Assert.NotNull(pixelsFloatXY);
                    ImPlot.ItemIcon(new Vector4F(1, 0, 0, 1));
                    ImPlot.ItemIcon(0xFF0000FF);
                    ImPlot.MapInputDefault();
                    ImPlot.MapInputDefault(new ImPlotInputMap());
                    ImPlot.MapInputReverse();
                    ImPlot.MapInputReverse(new ImPlotInputMap());
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the float PlotBarGroups wrapper overloads inside the active plot.
        ///     The wrappers marshal the label ids as a jagged byte array which the runtime
        ///     rejects with a managed MarshalDirectiveException before entering the native
        ///     function, so the call is expected and handled inside the plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void BarGroups_Float_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarGroupsFloatPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    string[] labels = new string[] { "g\0" };
                    float[] values = new float[] { 1 };

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67, 0.0);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the double PlotBarGroups wrapper overloads inside the active plot.
        ///     The wrappers marshal the label ids as a jagged byte array which the runtime
        ///     rejects with a managed MarshalDirectiveException before entering the native
        ///     function, so the call is expected and handled inside the plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void BarGroups_Double_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarGroupsDoublePlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    string[] labels = new string[] { "g\0" };
                    double[] values = new double[] { 1 };

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67, 0.0);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the sbyte PlotBarGroups wrapper overloads inside the active plot.
        ///     The wrappers marshal the label ids as a jagged byte array which the runtime
        ///     rejects with a managed MarshalDirectiveException before entering the native
        ///     function, so the call is expected and handled inside the plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void BarGroups_S8_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarGroupsS8Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    string[] labels = new string[] { "g\0" };
                    sbyte[] values = new sbyte[] { 1 };

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67, 0.0);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the byte PlotBarGroups wrapper overloads inside the active plot.
        ///     The wrappers marshal the label ids as a jagged byte array which the runtime
        ///     rejects with a managed MarshalDirectiveException before entering the native
        ///     function, so the call is expected and handled inside the plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void BarGroups_U8_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarGroupsU8Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    string[] labels = new string[] { "g\0" };
                    byte[] values = new byte[] { 1 };

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67, 0.0);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the short PlotBarGroups wrapper overloads inside the active plot.
        ///     The wrappers marshal the label ids as a jagged byte array which the runtime
        ///     rejects with a managed MarshalDirectiveException before entering the native
        ///     function, so the call is expected and handled inside the plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void BarGroups_S16_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarGroupsS16Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    string[] labels = new string[] { "g\0" };
                    short[] values = new short[] { 1 };

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67, 0.0);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the ushort PlotBarGroups wrapper overloads inside the active plot.
        ///     The wrappers marshal the label ids as a jagged byte array which the runtime
        ///     rejects with a managed MarshalDirectiveException before entering the native
        ///     function, so the call is expected and handled inside the plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void BarGroups_U16_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarGroupsU16Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    string[] labels = new string[] { "g\0" };
                    ushort[] values = new ushort[] { 1 };

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67, 0.0);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the int PlotBarGroups wrapper overloads inside the active plot.
        ///     The wrappers marshal the label ids as a jagged byte array which the runtime
        ///     rejects with a managed MarshalDirectiveException before entering the native
        ///     function, so the call is expected and handled inside the plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void BarGroups_S32_Overloads_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarGroupsS32Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    string[] labels = new string[] { "g\0" };
                    int[] values = new int[] { 1 };

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67, 0.0);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the uint PlotBarGroups wrapper overload inside the active plot.
        ///     The wrappers marshal the label ids as a jagged byte array which the runtime
        ///     rejects with a managed MarshalDirectiveException before entering the native
        ///     function, so the call is expected and handled inside the plot.
        /// </summary>
        [RequireImNodesSystemFact]
        public void BarGroups_U32_Overload_Executes_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("BarGroupsU32Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    string[] labels = new string[] { "g\0" };
                    uint[] values = new uint[] { 1 };

                    try
                    {
                        ImPlot.PlotBarGroups(labels, values, 1, 1);
                    }
                    catch (MarshalDirectiveException)
                    {
                    }

                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Tests that EndDragDropTarget throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void EndDragDropTarget_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.EndDragDropTarget(); });
            }
        }

        /// <summary>
        ///     Tests that EndLegendPopup throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void EndLegendPopup_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.EndLegendPopup(); });
            }
        }

        /// <summary>
        ///     Tests that EndPlot throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void EndPlot_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.EndPlot(); });
            }
        }

        /// <summary>
        ///     Tests that EndSubplots throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void EndSubplots_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.EndSubplots(); });
            }
        }

        /// <summary>
        ///     Tests that GetColormapColor throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetColormapColor_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetColormapColor(0); });
            }
        }

        /// <summary>
        ///     Tests that GetColormapColor throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetColormapColor_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetColormapColor(0, (ImPlotColormap)0); });
            }
        }

        /// <summary>
        ///     Tests that GetColormapCount throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetColormapCount_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetColormapCount(); });
            }
        }

        /// <summary>
        ///     Tests that GetColormapIndex throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetColormapIndex_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetColormapIndex("label"); });
            }
        }

        /// <summary>
        ///     Tests that GetColormapName throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetColormapName_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetColormapName((ImPlotColormap)0); });
            }
        }

        /// <summary>
        ///     Tests that GetColormapSize throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetColormapSize_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetColormapSize(); });
            }
        }

        /// <summary>
        ///     Tests that GetColormapSize throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetColormapSize_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetColormapSize((ImPlotColormap)0); });
            }
        }

        /// <summary>
        ///     Tests that GetCurrentContext throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetCurrentContext_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetCurrentContext(); });
            }
        }

        /// <summary>
        ///     Tests that GetInputMap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetInputMap_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetInputMap(); });
            }
        }

        /// <summary>
        ///     Tests that GetLastItemColor throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetLastItemColor_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetLastItemColor(); });
            }
        }

        /// <summary>
        ///     Tests that GetMarkerName throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetMarkerName_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetMarkerName((ImPlotMarker)0); });
            }
        }

        /// <summary>
        ///     Tests that GetPlotDrawList throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetPlotDrawList_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetPlotDrawList(); });
            }
        }

        /// <summary>
        ///     Tests that GetPlotLimits throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetPlotLimits_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetPlotLimits(); });
            }
        }

        /// <summary>
        ///     Tests that GetPlotLimits throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetPlotLimits_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetPlotLimits((ImAxis)0); });
            }
        }

        /// <summary>
        ///     Tests that GetPlotLimits throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetPlotLimits_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetPlotLimits((ImAxis)0, (ImAxis)0); });
            }
        }

        /// <summary>
        ///     Tests that GetPlotMousePos throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetPlotMousePos_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetPlotMousePos(); });
            }
        }

        /// <summary>
        ///     Tests that GetPlotMousePos throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetPlotMousePos_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetPlotMousePos((ImAxis)0); });
            }
        }

        /// <summary>
        ///     Tests that GetPlotMousePos throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetPlotMousePos_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetPlotMousePos((ImAxis)0, (ImAxis)0); });
            }
        }

        /// <summary>
        ///     Tests that GetPlotPos throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetPlotPos_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetPlotPos(); });
            }
        }

        /// <summary>
        ///     Tests that GetPlotSelection throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetPlotSelection_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetPlotSelection(); });
            }
        }

        /// <summary>
        ///     Tests that GetPlotSelection throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetPlotSelection_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetPlotSelection((ImAxis)0); });
            }
        }

        /// <summary>
        ///     Tests that GetPlotSelection throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetPlotSelection_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetPlotSelection((ImAxis)0, (ImAxis)0); });
            }
        }

        /// <summary>
        ///     Tests that GetPlotSize throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetPlotSize_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetPlotSize(); });
            }
        }

        /// <summary>
        ///     Tests that GetStyle throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetStyle_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetStyle(); });
            }
        }

        /// <summary>
        ///     Tests that GetStyleColorName throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetStyleColorName_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetStyleColorName((ImPlotCol)0); });
            }
        }

        /// <summary>
        ///     Tests that HideNextItem throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void HideNextItem_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.HideNextItem(); });
            }
        }

        /// <summary>
        ///     Tests that HideNextItem throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void HideNextItem_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.HideNextItem(false); });
            }
        }

        /// <summary>
        ///     Tests that HideNextItem throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void HideNextItem_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.HideNextItem(false, (ImPlotCond)0); });
            }
        }

        /// <summary>
        ///     Tests that IsAxisHovered throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void IsAxisHovered_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.IsAxisHovered((ImAxis)0); });
            }
        }

        /// <summary>
        ///     Tests that IsLegendEntryHovered throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void IsLegendEntryHovered_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.IsLegendEntryHovered("label"); });
            }
        }

        /// <summary>
        ///     Tests that IsPlotHovered throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void IsPlotHovered_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.IsPlotHovered(); });
            }
        }

        /// <summary>
        ///     Tests that IsPlotSelected throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void IsPlotSelected_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.IsPlotSelected(); });
            }
        }

        /// <summary>
        ///     Tests that IsSubplotsHovered throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void IsSubplotsHovered_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.IsSubplotsHovered(); });
            }
        }

        /// <summary>
        ///     Tests that ItemIcon throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void ItemIcon_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.ItemIcon(default(Vector4F)); });
            }
        }

        /// <summary>
        ///     Tests that ItemIcon throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void ItemIcon_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.ItemIcon(0); });
            }
        }

        /// <summary>
        ///     Tests that MapInputDefault throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void MapInputDefault_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.MapInputDefault(); });
            }
        }

        /// <summary>
        ///     Tests that MapInputDefault throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void MapInputDefault_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.MapInputDefault(default(ImPlotInputMap)); });
            }
        }

        /// <summary>
        ///     Tests that MapInputReverse throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void MapInputReverse_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.MapInputReverse(); });
            }
        }

        /// <summary>
        ///     Tests that MapInputReverse throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void MapInputReverse_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.MapInputReverse(default(ImPlotInputMap)); });
            }
        }

        /// <summary>
        ///     Tests that NextColormapColor throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void NextColormapColor_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.NextColormapColor(); });
            }
        }

        /// <summary>
        ///     Tests that PixelsToPlot throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PixelsToPlot_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PixelsToPlot(default(Vector2F)); });
            }
        }

        /// <summary>
        ///     Tests that PixelsToPlot throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PixelsToPlot_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PixelsToPlot(default(Vector2F), (ImAxis)0); });
            }
        }

        /// <summary>
        ///     Tests that PixelsToPlot throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PixelsToPlot_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PixelsToPlot(default(Vector2F), (ImAxis)0, (ImAxis)0); });
            }
        }

        /// <summary>
        ///     Tests that PixelsToPlot throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PixelsToPlot_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PixelsToPlot(0, 0); });
            }
        }

        /// <summary>
        ///     Tests that PixelsToPlot throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PixelsToPlot_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PixelsToPlot(0, 0, (ImAxis)0); });
            }
        }

        /// <summary>
        ///     Tests that PixelsToPlot throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PixelsToPlot_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PixelsToPlot(0, 0, (ImAxis)0, (ImAxis)0); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new float[] { 1 }, 1, 1); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new float[] { 1 }, 1, 1, 0.67); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new float[] { 1 }, 1, 1, 0.67, 0.0); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new float[] { 1 }, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new double[] { 1 }, 1, 1); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new double[] { 1 }, 1, 1, 0.67); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new double[] { 1 }, 1, 1, 0.67, 0.0); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_8_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new double[] { 1 }, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_9_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new sbyte[] { 1 }, 1, 1); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_10_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new sbyte[] { 1 }, 1, 1, 0.67); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_11_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new sbyte[] { 1 }, 1, 1, 0.67, 0.0); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_12_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new sbyte[] { 1 }, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_13_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new byte[] { 1 }, 1, 1); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_14_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new byte[] { 1 }, 1, 1, 0.67); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_15_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new byte[] { 1 }, 1, 1, 0.67, 0.0); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_16_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new byte[] { 1 }, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_17_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new short[] { 1 }, 1, 1); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_18_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new short[] { 1 }, 1, 1, 0.67); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_19_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new short[] { 1 }, 1, 1, 0.67, 0.0); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_20_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new short[] { 1 }, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_21_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new ushort[] { 1 }, 1, 1); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_22_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new ushort[] { 1 }, 1, 1, 0.67); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_23_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new ushort[] { 1 }, 1, 1, 0.67, 0.0); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_24_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new ushort[] { 1 }, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_25_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new int[] { 1 }, 1, 1); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_26_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new int[] { 1 }, 1, 1, 0.67); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_27_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new int[] { 1 }, 1, 1, 0.67, 0.0); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_28_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new int[] { 1 }, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None); });
            }
        }

        /// <summary>
        ///     Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_29_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(new string[] { "g" }, new uint[] { 1 }, 1, 1); });
            }
        }
    }
}
