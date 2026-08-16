// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP3ExecutionTests.cs
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
    ///     Executes the ImPlotP3 wrapper methods against the native cimgui library so that
    ///     the managed bodies of the wrappers in ImPlotP3.cs are exercised for line coverage.
    /// </summary>
    public class ImPlotP3ExecutionTests
    {
        /// <summary>
        ///     The no load mode of the dyld dynamic loader
        /// </summary>
        private const int RtlNoLoad = 0x10;

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
        ///     Opens an already loaded dynamic library
        /// </summary>
        /// <param name="path">The image path</param>
        /// <param name="mode">The open mode</param>
        /// <returns>The library handle</returns>
        [DllImport("libSystem.dylib", EntryPoint = "dlopen")]
        private static extern IntPtr DlOpen(string path, int mode);

        /// <summary>
        ///     Resolves the address of an exported symbol inside a loaded library
        /// </summary>
        /// <param name="handle">The library handle</param>
        /// <param name="symbol">The symbol name</param>
        /// <returns>The symbol address</returns>
        [DllImport("libSystem.dylib", EntryPoint = "dlsym")]
        private static extern IntPtr Dlsym(IntPtr handle, string symbol);

        /// <summary>
        ///     Returns information about the loaded image that owns the given address
        /// </summary>
        /// <param name="address">The address to resolve</param>
        /// <param name="info">The image information</param>
        /// <returns>The result</returns>
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
        ///     Executes the float and double PlotErrorBars single error wrapper overloads,
        ///     together with the sbyte and ushort single error overloads.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_Float_Double_S8_U16_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ErrF32Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    PlotErrorBarsFloat();
                    PlotErrorBarsDouble();
                    ImPlot.EndPlot();
                }

                if (ImPlot.BeginPlot("ErrS8Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    PlotErrorBarsS8();
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
        ///     Executes the long and ulong PlotErrorBars single error wrapper overloads,
        ///     together with the float and double pair error overloads.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_S64_U64_FloatPair_DoublePair_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ErrS64Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    PlotErrorBarsS64();
                    PlotErrorBarsU64();
                    ImPlot.EndPlot();
                }

                if (ImPlot.BeginPlot("ErrF32PairPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    PlotErrorBarsFloatPair();
                    PlotErrorBarsDoublePair();
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the byte and short PlotErrorBars single error wrapper overloads.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_U8_S16_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ErrU8Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    PlotErrorBarsU8();
                    ImPlot.EndPlot();
                }

                if (ImPlot.BeginPlot("ErrS16Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    PlotErrorBarsS16();
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the int and uint PlotErrorBars single error wrapper overloads.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_S32_U32_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ErrS32Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    PlotErrorBarsS32();
                    ImPlot.EndPlot();
                }

                if (ImPlot.BeginPlot("ErrU32Plot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    PlotErrorBarsU32();
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the sbyte PlotErrorBars pair error wrapper overload.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_S8_Pair_Execute_Inside_Plot()
        {
            IntPtr imgui = CreateContexts();
            try
            {
                if (ImPlot.BeginPlot("ErrS8PairPlot", new Vector2F(400, 300), ImPlotFlags.None))
                {
                    ImPlot.SetupAxes("x", "y");
                    ImPlot.SetupFinish();
                    PlotErrorBarsS8Pair();
                    ImPlot.EndPlot();
                }
            }
            finally
            {
                DestroyContexts(imgui);
            }
        }

        /// <summary>
        ///     Executes the float PlotErrorBars single error wrapper overloads with a zero
        ///     count so that the by-value error binding is never dereferenced by the native code.
        /// </summary>
        private static void PlotErrorBarsFloat()
        {
            float xs = default;
            float ys = default;
            float err = default;
            ImPlot.PlotErrorBars("err f32 a", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0);
            ImPlot.PlotErrorBars("err f32 b", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0, sizeof(float));
        }

        /// <summary>
        ///     Executes the double PlotErrorBars single error wrapper overloads with a zero
        ///     count so that the by-value error binding is never dereferenced by the native code.
        /// </summary>
        private static void PlotErrorBarsDouble()
        {
            double xs = default;
            double ys = default;
            double err = default;
            ImPlot.PlotErrorBars("err f64 a", ref xs, ref ys, ref err, 0);
            ImPlot.PlotErrorBars("err f64 b", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None);
            ImPlot.PlotErrorBars("err f64 c", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0);
            ImPlot.PlotErrorBars("err f64 d", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0, sizeof(double));
        }

        /// <summary>
        ///     Executes the sbyte PlotErrorBars single error wrapper overloads with a zero
        ///     count so that the by-value error binding is never dereferenced by the native code.
        /// </summary>
        private static void PlotErrorBarsS8()
        {
            sbyte xs = default;
            sbyte ys = default;
            sbyte err = default;
            ImPlot.PlotErrorBars("err s8 a", ref xs, ref ys, ref err, 0);
            ImPlot.PlotErrorBars("err s8 b", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None);
            ImPlot.PlotErrorBars("err s8 c", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0);
            ImPlot.PlotErrorBars("err s8 d", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0, sizeof(sbyte));
        }

        /// <summary>
        ///     Executes the byte PlotErrorBars single error wrapper overloads with a zero
        ///     count so that the by-value data bindings are never dereferenced by the native code.
        /// </summary>
        private static void PlotErrorBarsU8()
        {
            byte xs = default;
            byte ys = default;
            byte err = default;
            ImPlot.PlotErrorBars("err u8 a", ref xs, ref ys, ref err, 0);
            ImPlot.PlotErrorBars("err u8 b", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None);
            ImPlot.PlotErrorBars("err u8 c", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0);
            ImPlot.PlotErrorBars("err u8 d", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0, sizeof(byte));
        }

        /// <summary>
        ///     Executes the short PlotErrorBars single error wrapper overloads with a zero
        ///     count so that the by-value data bindings are never dereferenced by the native code.
        /// </summary>
        private static void PlotErrorBarsS16()
        {
            short xs = default;
            short ys = default;
            short err = default;
            ImPlot.PlotErrorBars("err s16 a", ref xs, ref ys, ref err, 0);
            ImPlot.PlotErrorBars("err s16 b", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None);
            ImPlot.PlotErrorBars("err s16 c", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0);
            ImPlot.PlotErrorBars("err s16 d", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0, sizeof(short));
        }

        /// <summary>
        ///     Executes the ushort PlotErrorBars single error wrapper overloads with a zero
        ///     count so that the by-value error binding is never dereferenced by the native code.
        /// </summary>
        private static void PlotErrorBarsU16()
        {
            ushort xs = default;
            ushort ys = default;
            ushort err = default;
            ImPlot.PlotErrorBars("err u16 a", ref xs, ref ys, ref err, 0);
            ImPlot.PlotErrorBars("err u16 b", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None);
            ImPlot.PlotErrorBars("err u16 c", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0);
            ImPlot.PlotErrorBars("err u16 d", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0, sizeof(ushort));
        }

        /// <summary>
        ///     Executes the int PlotErrorBars single error wrapper overloads with a zero
        ///     count so that the by-value data bindings are never dereferenced by the native code.
        /// </summary>
        private static void PlotErrorBarsS32()
        {
            int xs = default;
            int ys = default;
            int err = default;
            ImPlot.PlotErrorBars("err s32 a", ref xs, ref ys, ref err, 0);
            ImPlot.PlotErrorBars("err s32 b", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None);
            ImPlot.PlotErrorBars("err s32 c", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0);
            ImPlot.PlotErrorBars("err s32 d", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0, sizeof(int));
        }

        /// <summary>
        ///     Executes the uint PlotErrorBars single error wrapper overloads with a zero
        ///     count so that the by-value data bindings are never dereferenced by the native code.
        /// </summary>
        private static void PlotErrorBarsU32()
        {
            uint xs = default;
            uint ys = default;
            uint err = default;
            ImPlot.PlotErrorBars("err u32 a", ref xs, ref ys, ref err, 0);
            ImPlot.PlotErrorBars("err u32 b", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None);
            ImPlot.PlotErrorBars("err u32 c", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0);
            ImPlot.PlotErrorBars("err u32 d", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0, sizeof(uint));
        }

        /// <summary>
        ///     Executes the long PlotErrorBars single error wrapper overloads with a zero
        ///     count so that the by-value error binding is never dereferenced by the native code.
        /// </summary>
        private static void PlotErrorBarsS64()
        {
            long xs = default;
            long ys = default;
            long err = default;
            ImPlot.PlotErrorBars("err s64 a", ref xs, ref ys, ref err, 0);
            ImPlot.PlotErrorBars("err s64 b", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None);
            ImPlot.PlotErrorBars("err s64 c", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0);
            ImPlot.PlotErrorBars("err s64 d", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0, sizeof(long));
        }

        /// <summary>
        ///     Executes the ulong PlotErrorBars single error wrapper overloads with a zero
        ///     count so that the by-value error binding is never dereferenced by the native code.
        /// </summary>
        private static void PlotErrorBarsU64()
        {
            ulong xs = default;
            ulong ys = default;
            ulong err = default;
            ImPlot.PlotErrorBars("err u64 a", ref xs, ref ys, ref err, 0);
            ImPlot.PlotErrorBars("err u64 b", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None);
            ImPlot.PlotErrorBars("err u64 c", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0);
            ImPlot.PlotErrorBars("err u64 d", ref xs, ref ys, ref err, 0, ImPlotErrorBarsFlags.None, 0, sizeof(ulong));
        }

        /// <summary>
        ///     Executes the float PlotErrorBars pair error wrapper overloads with a zero
        ///     count so that the by-value error bindings are never dereferenced by the native code.
        /// </summary>
        private static void PlotErrorBarsFloatPair()
        {
            float xs = default;
            float ys = default;
            float neg = default;
            float pos = default;
            ImPlot.PlotErrorBars("err f32 p a", ref xs, ref ys, ref neg, ref pos, 0);
            ImPlot.PlotErrorBars("err f32 p b", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None);
            ImPlot.PlotErrorBars("err f32 p c", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0);
            ImPlot.PlotErrorBars("err f32 p d", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0, 0);
        }

        /// <summary>
        ///     Executes the double PlotErrorBars pair error wrapper overloads with a zero
        ///     count so that the by-value error bindings are never dereferenced by the native code.
        /// </summary>
        private static void PlotErrorBarsDoublePair()
        {
            double xs = default;
            double ys = default;
            double neg = default;
            double pos = default;
            ImPlot.PlotErrorBars("err f64 p a", ref xs, ref ys, ref neg, ref pos, 0);
            ImPlot.PlotErrorBars("err f64 p b", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None);
            ImPlot.PlotErrorBars("err f64 p c", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0);
            ImPlot.PlotErrorBars("err f64 p d", ref xs, ref ys, ref neg, ref pos, 0, ImPlotErrorBarsFlags.None, 0, 0);
        }

        /// <summary>
        ///     Executes the sbyte PlotErrorBars pair error wrapper overload with a zero
        ///     count so that the by-value error bindings are never dereferenced by the native code.
        /// </summary>
        private static void PlotErrorBarsS8Pair()
        {
            sbyte xs = default;
            sbyte ys = default;
            sbyte neg = default;
            sbyte pos = default;
            ImPlot.PlotErrorBars("err s8 p a", ref xs, ref ys, ref neg, ref pos, 0);
        }
    }
}
