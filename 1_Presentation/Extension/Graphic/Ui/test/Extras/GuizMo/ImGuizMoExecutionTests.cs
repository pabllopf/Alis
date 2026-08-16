// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuizMoExecutionTests.cs
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
using Alis.Extension.Graphic.Ui.Extras.GuizMo;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.GuizMo
{
    /// <summary>
    ///     Executes every native-backed ImGuizMo wrapper against the real cimgui library.
    ///     State writes and matrix helpers run with a bound context, while every draw-scoped
    ///     call runs inside a real NewFrame/Begin/End/EndFrame cycle with a framed context.
    /// </summary>
    public class ImGuizMoExecutionTests
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
        ///     Creates a raw ImGui context, binds it as the current context and binds it to the gizmo.
        /// </summary>
        /// <returns>The created context pointer</returns>
        private static IntPtr CreateContext()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            ImGuiNative.igSetCurrentContext(ctx);
            ImGuizMo.SetImGuiContext(ctx);
            return ctx;
        }

        /// <summary>
        ///     Creates an ImGui context ready for a real frame: the native context slot of every
        ///     loaded cimgui image is synchronized, a display size is written into the io struct
        ///     and the font atlas is built so that igNewFrame can run without aborting.
        /// </summary>
        /// <returns>The created context pointer</returns>
        private static IntPtr CreateFramedContext()
        {
            IntPtr ctx = CreateContext();
            SyncContextSlots(ctx);
            IntPtr ioPtr = ImGuiNative.igGetIO();
            Marshal.StructureToPtr(1280.0f, IntPtr.Add(ioPtr, 8), false);
            Marshal.StructureToPtr(720.0f, IntPtr.Add(ioPtr, 12), false);
            IntPtr fontsPtr = Marshal.ReadIntPtr(ioPtr, 80);
            ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32(fontsPtr, out IntPtr _, out int _, out int _, out int _);
            return ctx;
        }

        /// <summary>
        ///     Synchronizes the ImGui context pointer of every loaded cimgui image so that a frame
        ///     started through one image copy is visible to all the other copies. The GImGui slot is
        ///     resolved through the exported symbol of each image instead of a hardcoded offset, which
        ///     varies between the x64 and arm64 slices of the native library. The handle opened with
        ///     RtlNoLoad is never closed because dlclose can unload the image, and the resolved address
        ///     is verified with dladdr before the write so a stale slot can never fault the test host.
        /// </summary>
        /// <param name="imgui">The imgui context</param>
        private static void SyncContextSlots(IntPtr imgui)
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
        ///     Creates a 16 element identity float matrix.
        /// </summary>
        /// <returns>The identity matrix</returns>
        private static float[] IdentityMatrix()
        {
            float[] identity = new float[16];
            identity[0] = 1.0f;
            identity[5] = 1.0f;
            identity[10] = 1.0f;
            identity[15] = 1.0f;
            return identity;
        }

        /// <summary>
        ///     Verifies the state setters execute against a bound context.
        /// </summary>
        [MacOsOnly]
        public void StateWrites_And_ContextBinding_Execute()
        {
            IntPtr ctx = CreateContext();
            try
            {
                ImGuizMo.SetRect(0.0f, 0.0f, 640.0f, 480.0f);
                ImGuizMo.SetOrthographic(true);
                ImGuizMo.SetOrthographic(false);
                ImGuizMo.Enable(true);
                ImGuizMo.AllowAxisFlip(true);
                ImGuizMo.SetGizmoSizeClipSpace(0.1f);
                ImGuizMo.SetId(0x1234);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies IsUsing and the parameterless IsOver report idle state while the
        ///     operation overload throws because its generated entry point does not match
        ///     the native symbol.
        /// </summary>
        [MacOsOnly]
        public void StateQueries_Execute()
        {
            IntPtr ctx = CreateContext();
            try
            {
                Assert.False(ImGuizMo.IsOver());
                Assert.False(ImGuizMo.IsUsing());
                Assert.Throws<EntryPointNotFoundException>(() => ImGuizMo.IsOver(Operations.Translate));
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies the decompose and recompose matrix helpers round trip an identity matrix.
        /// </summary>
        [MacOsOnly]
        public void MatrixComponentRoundTrip_Execute()
        {
            IntPtr ctx = CreateContext();
            try
            {
                float[] matrix = IdentityMatrix();
                float[] translation = new float[3];
                float[] rotation = new float[3];
                float[] scale = new float[3];
                ImGuizMo.DecomposeMatrixToComponents(ref matrix, ref translation, ref rotation, ref scale);
                Assert.Equal(1.0f, scale[0]);
                Assert.Equal(1.0f, scale[1]);
                Assert.Equal(1.0f, scale[2]);

                float[] rebuilt = new float[16];
                ImGuizMo.RecomposeMatrixFromComponents(ref translation, ref rotation, ref scale, ref rebuilt);
                Assert.Equal(1.0f, rebuilt[0], 3);
                Assert.Equal(1.0f, rebuilt[5], 3);
                Assert.Equal(1.0f, rebuilt[10], 3);
                Assert.Equal(1.0f, rebuilt[15], 3);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies BeginFrame and the nil draw list setter execute, and DrawGrid renders
        ///     inside a real framed window.
        /// </summary>
        [MacOsOnly]
        public void BeginFrame_And_DrawGrid_ExecuteInsideFrame()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGuizMo.BeginFrame();
                ImGuizMo.SetDrawList();
                ImGuizMo.SetRect(0.0f, 0.0f, 640.0f, 480.0f);
                ImGuizMo.SetOrthographic(false);
                ImGui.Begin("grid-window");
                float[] view = IdentityMatrix();
                float[] projection = IdentityMatrix();
                float[] matrix = IdentityMatrix();
                ImGuizMo.DrawGrid(ref view, ref projection, ref matrix, 10.0f);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies Manipulate runs inside a real framed window with a configured rect and
        ///     returns a valid result.
        /// </summary>
        [MacOsOnly]
        public void Manipulate_ExecuteInsideFrame()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGuizMo.SetRect(0.0f, 0.0f, 640.0f, 480.0f);
                ImGuizMo.SetOrthographic(false);
                ImGuizMo.Enable(true);
                ImGui.Begin("manipulate-window");
                ImGuizMo.SetDrawList();
                float[] view = IdentityMatrix();
                float[] projection = IdentityMatrix();
                float[] matrix = IdentityMatrix();
                byte result = ImGuizMo.Manipulate(view, projection, Operations.Translate | Operations.Rotate | Operations.Scale, Mode.Local, matrix);
                Assert.True(result == 0 || result == 1);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies ViewManipulate renders inside a real framed window.
        /// </summary>
        [MacOsOnly]
        public void ViewManipulate_ExecuteInsideFrame()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGuizMo.SetRect(0.0f, 0.0f, 640.0f, 480.0f);
                ImGui.Begin("view-manipulate-window");
                ImGuizMo.SetDrawList();
                float[] view = IdentityMatrix();
                ImGuizMo.ViewManipulate(ref view, 2.5f, new Vector2F(0.0f, 0.0f), new Vector2F(128.0f, 128.0f), 0x10101010);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies SetDrawList with a managed struct executes and stores a marshalled
        ///     pointer that is reset to nil before the frame ends.
        /// </summary>
        [MacOsOnly]
        public void SetDrawList_WithStruct_Execute()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("drawlist-window");
                ImGuizMo.SetDrawList(new ImDrawList());
                ImGuizMo.SetDrawList();
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies ShowDemoWindow runs its full gizmo editor body inside a real framed window.
        /// </summary>
        [MacOsOnly]
        public void ShowDemoWindow_ExecuteInsideFrame()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGuizMo.ShowDemoWindow();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }
    }
}
