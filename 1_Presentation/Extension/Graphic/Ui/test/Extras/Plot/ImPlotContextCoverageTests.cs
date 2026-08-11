// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotContextCoverageTests.cs
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
    ///     Invokes the context, colormap and style accessors of the ImPlot wrapper.
    ///     All covered calls operate on the ImPlot context directly and do not need
    ///     an ImGui frame.
    /// </summary>
    public class ImPlotContextCoverageTests
    {
        /// <summary>
        ///     Creates an ImGui context and an ImPlot context bound to it.
        /// </summary>
        private static IntPtr CreateContexts()
        {
            IntPtr imgui = ImGuiNative.igCreateContext(IntPtr.Zero);
            ImGuiNative.igSetCurrentContext(imgui);
            IntPtr implot = ImPlot.CreateContext();
            ImPlot.SetImGuiContext(imgui);
            ImPlot.SetCurrentContext(implot);
            return imgui;
        }

        /// <summary>
        ///     Destroys the active ImPlot context and the ImGui context.
        /// </summary>
        /// <param name="implot">The implot context</param>
        /// <param name="imgui">The imgui context</param>
        private static void DestroyContexts(IntPtr implot, IntPtr imgui)
        {
            ImPlot.DestroyContext(implot);
            ImGuiNative.igDestroyContext(imgui);
        }

        /// <summary>
        ///     Verifies CreateContext returns a non-zero context pointer.
        /// </summary>
        [RequireCImguiSystemFact]
        public void CreateContext_ReturnsValidPointer()
        {
            IntPtr imgui = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(imgui);
                IntPtr implot = ImPlot.CreateContext();
                Assert.NotEqual(IntPtr.Zero, implot);
                ImPlot.DestroyContext(implot);
            }
            finally
            {
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies SetCurrentContext and GetCurrentContext round trip.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetCurrentContext_And_GetCurrentContext_RoundTrip()
        {
            IntPtr imgui = CreateContexts();
            IntPtr implot = ImPlot.GetCurrentContext();
            try
            {
                Assert.NotEqual(IntPtr.Zero, implot);
                ImPlot.SetCurrentContext(implot);
                Assert.Equal(implot, ImPlot.GetCurrentContext());
            }
            finally
            {
                DestroyContexts(implot, imgui);
            }
        }

        /// <summary>
        ///     Verifies SetImGuiContext executes.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetImGuiContext_Executes()
        {
            IntPtr imgui = CreateContexts();
            IntPtr implot = ImPlot.GetCurrentContext();
            try
            {
                ImPlot.SetImGuiContext(imgui);
            }
            finally
            {
                DestroyContexts(implot, imgui);
            }
        }

        /// <summary>
        ///     Verifies DestroyContext without arguments executes without crashing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DestroyContext_WithoutArguments_Executes()
        {
            IntPtr imgui = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(imgui);
                IntPtr implot = ImPlot.CreateContext();
                ImPlot.SetCurrentContext(implot);
                ImPlot.DestroyContext();
            }
            finally
            {
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies GetColormapCount returns the built-in colormap count.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetColormapCount_ReturnsPositiveCount()
        {
            IntPtr imgui = CreateContexts();
            IntPtr implot = ImPlot.GetCurrentContext();
            try
            {
                Assert.True(ImPlot.GetColormapCount() > 0);
            }
            finally
            {
                DestroyContexts(implot, imgui);
            }
        }

        /// <summary>
        ///     Verifies GetColormapIndex resolves a known colormap name.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetColormapIndex_ResolvesKnownName()
        {
            IntPtr imgui = CreateContexts();
            IntPtr implot = ImPlot.GetCurrentContext();
            try
            {
                ImPlotColormap colormap = ImPlot.GetColormapIndex("Deep");
                Assert.True(colormap >= 0);
            }
            finally
            {
                DestroyContexts(implot, imgui);
            }
        }

        /// <summary>
        ///     Verifies GetColormapSize overloads return sizes.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetColormapSize_AllOverloads_ReturnSizes()
        {
            IntPtr imgui = CreateContexts();
            IntPtr implot = ImPlot.GetCurrentContext();
            try
            {
                Assert.True(ImPlot.GetColormapSize() > 0);
                Assert.True(ImPlot.GetColormapSize(ImPlotColormap.Deep) > 0);
            }
            finally
            {
                DestroyContexts(implot, imgui);
            }
        }

        /// <summary>
        ///     Verifies GetColormapColor overloads return colors.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetColormapColor_AllOverloads_ReturnColors()
        {
            IntPtr imgui = CreateContexts();
            IntPtr implot = ImPlot.GetCurrentContext();
            try
            {
                _ = ImPlot.GetColormapColor(1);
                _ = ImPlot.GetColormapColor(1, ImPlotColormap.Deep);
            }
            finally
            {
                DestroyContexts(implot, imgui);
            }
        }

        /// <summary>
        ///     Verifies GetColormapName throws because the generated wrapper cannot
        ///     marshal the native const char return value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetColormapName_ThrowsMarshalDirectiveException()
        {
            IntPtr imgui = CreateContexts();
            IntPtr implot = ImPlot.GetCurrentContext();
            try
            {
                Assert.Throws<MarshalDirectiveException>(() => ImPlot.GetColormapName(ImPlotColormap.Deep));
            }
            finally
            {
                DestroyContexts(implot, imgui);
            }
        }

        /// <summary>
        ///     Verifies GetMarkerName throws because the generated wrapper cannot
        ///     marshal the native const char return value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetMarkerName_ThrowsMarshalDirectiveException()
        {
            IntPtr imgui = CreateContexts();
            IntPtr implot = ImPlot.GetCurrentContext();
            try
            {
                Assert.Throws<MarshalDirectiveException>(() => ImPlot.GetMarkerName(ImPlotMarker.Circle));
            }
            finally
            {
                DestroyContexts(implot, imgui);
            }
        }

        /// <summary>
        ///     Verifies GetStyleColorName throws because the generated wrapper cannot
        ///     marshal the native const char return value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetStyleColorName_ThrowsMarshalDirectiveException()
        {
            IntPtr imgui = CreateContexts();
            IntPtr implot = ImPlot.GetCurrentContext();
            try
            {
                Assert.Throws<MarshalDirectiveException>(() => ImPlot.GetStyleColorName(ImPlotCol.Line));
            }
            finally
            {
                DestroyContexts(implot, imgui);
            }
        }

        /// <summary>
        ///     Verifies GetInputMap and GetStyle return structs by value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetInputMap_And_GetStyle_ReturnStructs()
        {
            IntPtr imgui = CreateContexts();
            IntPtr implot = ImPlot.GetCurrentContext();
            try
            {
                _ = ImPlot.GetInputMap();
                _ = ImPlot.GetStyle();
            }
            finally
            {
                DestroyContexts(implot, imgui);
            }
        }

        /// <summary>
        ///     Verifies PushStyleColor and PopStyleColor overloads execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PushStyleColor_And_PopStyleColor_Execute()
        {
            IntPtr imgui = CreateContexts();
            IntPtr implot = ImPlot.GetCurrentContext();
            try
            {
                ImPlot.PushStyleColor(ImPlotCol.Line, 0xFF0000FF);
                ImPlot.PopStyleColor();
                ImPlot.PushStyleColor(ImPlotCol.Line, new Alis.Core.Aspect.Math.Vector.Vector4F(1, 0, 0, 1));
                ImPlot.PopStyleColor(1);
            }
            finally
            {
                DestroyContexts(implot, imgui);
            }
        }
    }
}
