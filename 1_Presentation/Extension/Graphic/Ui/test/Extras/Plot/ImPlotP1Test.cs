// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP1Test.cs
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
using System.Linq;
using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Extras.Plot;

// Type alias to disambiguate between Alis.Extension.Graphic.Ui.ImGuiDragDropFlags and Alis.Extension.Graphic.Ui.Extras.Plot.ImGuiDragDropFlags
using DragDropFlags = Alis.Extension.Graphic.Ui.Extras.Plot.ImGuiDragDropFlags;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     Provides focused unit coverage for API members implemented in <c>ImPlotP1.cs</c>.
    /// </summary>
    public class ImPlotP1Test
    {
        /// <summary>
        /// Tests that add colormap vec 4 ptr should return im plot colormap
        /// </summary>
        [Fact]
        public void AddColormap_Vec4Ptr_ShouldReturnImPlotColormap()
        {
            MethodInfo method = GetPublicStaticMethod("AddColormap", new[] { typeof(string), typeof(Vector4F).MakeByRefType(), typeof(int) });

            Assert.NotNull(method);
            Assert.Equal(typeof(ImPlotColormap), method.ReturnType);
        }

        /// <summary>
        /// Tests that add colormap vec 4 ptr with qual should return im plot colormap
        /// </summary>
        [Fact]
        public void AddColormap_Vec4Ptr_WithQual_ShouldReturnImPlotColormap()
        {
            MethodInfo method = GetPublicStaticMethod("AddColormap", new[] { typeof(string), typeof(Vector4F).MakeByRefType(), typeof(int), typeof(bool) });

            Assert.NotNull(method);
            Assert.Equal(typeof(ImPlotColormap), method.ReturnType);
        }

        /// <summary>
        /// Tests that add colormap u 32 ptr should return im plot colormap
        /// </summary>
        [Fact]
        public void AddColormap_U32Ptr_ShouldReturnImPlotColormap()
        {
            MethodInfo method = GetPublicStaticMethod("AddColormap", new[] { typeof(string), typeof(uint).MakeByRefType(), typeof(int) });

            Assert.NotNull(method);
            Assert.Equal(typeof(ImPlotColormap), method.ReturnType);
        }

        /// <summary>
        /// Tests that add colormap u 32 ptr with qual should return im plot colormap
        /// </summary>
        [Fact]
        public void AddColormap_U32Ptr_WithQual_ShouldReturnImPlotColormap()
        {
            MethodInfo method = GetPublicStaticMethod("AddColormap", new[] { typeof(string), typeof(uint).MakeByRefType(), typeof(int), typeof(bool) });

            Assert.NotNull(method);
            Assert.Equal(typeof(ImPlotColormap), method.ReturnType);
        }

        /// <summary>
        /// Tests that annotation bool should be void
        /// </summary>
        [Fact]
        public void Annotation_Bool_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("Annotation", new[] { typeof(double), typeof(double), typeof(Vector4F), typeof(Vector2F), typeof(bool) });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that annotation bool round should be void
        /// </summary>
        [Fact]
        public void Annotation_BoolRound_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("Annotation", new[] { typeof(double), typeof(double), typeof(Vector4F), typeof(Vector2F), typeof(bool), typeof(bool) });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that annotation str should be void
        /// </summary>
        [Fact]
        public void Annotation_Str_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("Annotation", new[] { typeof(double), typeof(double), typeof(Vector4F), typeof(Vector2F), typeof(bool), typeof(string) });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that begin aligned plots default should return bool
        /// </summary>
        [Fact]
        public void BeginAlignedPlots_Default_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("BeginAlignedPlots", new[] { typeof(string) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that begin aligned plots with vertical should return bool
        /// </summary>
        [Fact]
        public void BeginAlignedPlots_WithVertical_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("BeginAlignedPlots", new[] { typeof(string), typeof(bool) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that begin drag drop source axis default should return bool
        /// </summary>
        [Fact]
        public void BeginDragDropSourceAxis_Default_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("BeginDragDropSourceAxis", new[] { typeof(ImAxis) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that begin drag drop source axis with flags should return bool
        /// </summary>
        [Fact]
        public void BeginDragDropSourceAxis_WithFlags_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("BeginDragDropSourceAxis", new[] { typeof(ImAxis), typeof(DragDropFlags) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that begin drag drop source item default should return bool
        /// </summary>
        [Fact]
        public void BeginDragDropSourceItem_Default_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("BeginDragDropSourceItem", new[] { typeof(string) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that begin drag drop source item with flags should return bool
        /// </summary>
        [Fact]
        public void BeginDragDropSourceItem_WithFlags_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("BeginDragDropSourceItem", new[] { typeof(string), typeof(DragDropFlags) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that begin drag drop source plot default should return bool
        /// </summary>
        [Fact]
        public void BeginDragDropSourcePlot_Default_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("BeginDragDropSourcePlot", Type.EmptyTypes);

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that begin drag drop source plot with flags should return bool
        /// </summary>
        [Fact]
        public void BeginDragDropSourcePlot_WithFlags_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("BeginDragDropSourcePlot", new[] { typeof(DragDropFlags) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that begin drag drop target axis should return bool
        /// </summary>
        [Fact]
        public void BeginDragDropTargetAxis_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("BeginDragDropTargetAxis", new[] { typeof(ImAxis) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that begin drag drop target legend should return bool
        /// </summary>
        [Fact]
        public void BeginDragDropTargetLegend_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("BeginDragDropTargetLegend", Type.EmptyTypes);

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that begin drag drop target plot should return bool
        /// </summary>
        [Fact]
        public void BeginDragDropTargetPlot_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("BeginDragDropTargetPlot", Type.EmptyTypes);

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that begin legend popup default should return bool
        /// </summary>
        [Fact]
        public void BeginLegendPopup_Default_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("BeginLegendPopup", new[] { typeof(string) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that begin legend popup with mouse button should return bool
        /// </summary>
        [Fact]
        public void BeginLegendPopup_WithMouseButton_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("BeginLegendPopup", new[] { typeof(string), typeof(ImGuiMouseButton) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that begin plot default should return bool
        /// </summary>
        [Fact]
        public void BeginPlot_Default_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("BeginPlot", new[] { typeof(string) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that begin plot with size should return bool
        /// </summary>
        [Fact]
        public void BeginPlot_WithSize_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("BeginPlot", new[] { typeof(string), typeof(Vector2F) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that begin plot with size and flags should return bool
        /// </summary>
        [Fact]
        public void BeginPlot_WithSizeAndFlags_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("BeginPlot", new[] { typeof(string), typeof(Vector2F), typeof(ImPlotFlags) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that begin subplots default should return bool
        /// </summary>
        [Fact]
        public void BeginSubplots_Default_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("BeginSubplots", new[] { typeof(string), typeof(int), typeof(int), typeof(Vector2F) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that begin subplots with flags should return bool
        /// </summary>
        [Fact]
        public void BeginSubplots_WithFlags_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("BeginSubplots", new[] { typeof(string), typeof(int), typeof(int), typeof(Vector2F), typeof(ImPlotSubplotFlags) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that begin subplots with flags and row ratios should return bool
        /// </summary>
        [Fact]
        public void BeginSubplots_WithFlagsAndRowRatios_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("BeginSubplots", new[] { typeof(string), typeof(int), typeof(int), typeof(Vector2F), typeof(ImPlotSubplotFlags), typeof(float).MakeByRefType() });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that begin subplots with flags and both ratios should return bool
        /// </summary>
        [Fact]
        public void BeginSubplots_WithFlagsAndBothRatios_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("BeginSubplots", new[] { typeof(string), typeof(int), typeof(int), typeof(Vector2F), typeof(ImPlotSubplotFlags), typeof(float).MakeByRefType(), typeof(float).MakeByRefType() });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that bust color cache default should be void
        /// </summary>
        [Fact]
        public void BustColorCache_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("BustColorCache", Type.EmptyTypes);

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that bust color cache with plot title should be void
        /// </summary>
        [Fact]
        public void BustColorCache_WithPlotTitle_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("BustColorCache", new[] { typeof(string) });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that cancel plot selection should be void
        /// </summary>
        [Fact]
        public void CancelPlotSelection_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("CancelPlotSelection", Type.EmptyTypes);

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that colormap button default should return bool
        /// </summary>
        [Fact]
        public void ColormapButton_Default_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("ColormapButton", new[] { typeof(string) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that colormap button with size should return bool
        /// </summary>
        [Fact]
        public void ColormapButton_WithSize_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("ColormapButton", new[] { typeof(string), typeof(Vector2F) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that colormap button with size and cmap should return bool
        /// </summary>
        [Fact]
        public void ColormapButton_WithSizeAndCmap_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("ColormapButton", new[] { typeof(string), typeof(Vector2F), typeof(ImPlotColormap) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that colormap icon should be void
        /// </summary>
        [Fact]
        public void ColormapIcon_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("ColormapIcon", new[] { typeof(ImPlotColormap) });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that colormap scale default should be void
        /// </summary>
        [Fact]
        public void ColormapScale_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("ColormapScale", new[] { typeof(string), typeof(double), typeof(double) });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that colormap scale with size should be void
        /// </summary>
        [Fact]
        public void ColormapScale_WithSize_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("ColormapScale", new[] { typeof(string), typeof(double), typeof(double), typeof(Vector2F) });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that colormap scale with size and format should be void
        /// </summary>
        [Fact]
        public void ColormapScale_WithSizeAndFormat_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("ColormapScale", new[] { typeof(string), typeof(double), typeof(double), typeof(Vector2F), typeof(string) });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that colormap scale with size format flags should be void
        /// </summary>
        [Fact]
        public void ColormapScale_WithSizeFormatFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("ColormapScale", new[] { typeof(string), typeof(double), typeof(double), typeof(Vector2F), typeof(string), typeof(ImPlotColormapScaleFlags) });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that colormap scale with all params should be void
        /// </summary>
        [Fact]
        public void ColormapScale_WithAllParams_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("ColormapScale", new[] { typeof(string), typeof(double), typeof(double), typeof(Vector2F), typeof(string), typeof(ImPlotColormapScaleFlags), typeof(ImPlotColormap) });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that colormap slider default should return bool
        /// </summary>
        [Fact]
        public void ColormapSlider_Default_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("ColormapSlider", new[] { typeof(string), typeof(float).MakeByRefType() });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that colormap slider with out should return bool
        /// </summary>
        [Fact]
        public void ColormapSlider_WithOut_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("ColormapSlider", new[] { typeof(string), typeof(float).MakeByRefType(), typeof(Vector4F).MakeByRefType() });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that colormap slider with out and format should return bool
        /// </summary>
        [Fact]
        public void ColormapSlider_WithOutAndFormat_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("ColormapSlider", new[] { typeof(string), typeof(float).MakeByRefType(), typeof(Vector4F).MakeByRefType(), typeof(string) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that colormap slider with out format cmap should return bool
        /// </summary>
        [Fact]
        public void ColormapSlider_WithOutFormatCmap_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("ColormapSlider", new[] { typeof(string), typeof(float).MakeByRefType(), typeof(Vector4F).MakeByRefType(), typeof(string), typeof(ImPlotColormap) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that create context should return int ptr
        /// </summary>
        [Fact]
        public void CreateContext_ShouldReturnIntPtr()
        {
            MethodInfo method = GetPublicStaticMethod("CreateContext", Type.EmptyTypes);

            Assert.NotNull(method);
            Assert.Equal(typeof(IntPtr), method.ReturnType);
        }

        /// <summary>
        /// Tests that destroy context default should be void
        /// </summary>
        [Fact]
        public void DestroyContext_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("DestroyContext", Type.EmptyTypes);

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that destroy context with ctx should be void
        /// </summary>
        [Fact]
        public void DestroyContext_WithCtx_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("DestroyContext", new[] { typeof(IntPtr) });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that drag line x default should return bool
        /// </summary>
        [Fact]
        public void DragLineX_Default_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("DragLineX", new[] { typeof(int), typeof(double).MakeByRefType(), typeof(Vector4F) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that drag line x with thickness should return bool
        /// </summary>
        [Fact]
        public void DragLineX_WithThickness_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("DragLineX", new[] { typeof(int), typeof(double).MakeByRefType(), typeof(Vector4F), typeof(float) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that drag line x with thickness and flags should return bool
        /// </summary>
        [Fact]
        public void DragLineX_WithThicknessAndFlags_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("DragLineX", new[] { typeof(int), typeof(double).MakeByRefType(), typeof(Vector4F), typeof(float), typeof(ImPlotDragToolFlags) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that drag line y default should return bool
        /// </summary>
        [Fact]
        public void DragLineY_Default_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("DragLineY", new[] { typeof(int), typeof(double).MakeByRefType(), typeof(Vector4F) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that drag line y with thickness should return bool
        /// </summary>
        [Fact]
        public void DragLineY_WithThickness_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("DragLineY", new[] { typeof(int), typeof(double).MakeByRefType(), typeof(Vector4F), typeof(float) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that drag line y with thickness and flags should return bool
        /// </summary>
        [Fact]
        public void DragLineY_WithThicknessAndFlags_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("DragLineY", new[] { typeof(int), typeof(double).MakeByRefType(), typeof(Vector4F), typeof(float), typeof(ImPlotDragToolFlags) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that drag point default should return bool
        /// </summary>
        [Fact]
        public void DragPoint_Default_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("DragPoint", new[] { typeof(int), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(Vector4F) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that drag point with size should return bool
        /// </summary>
        [Fact]
        public void DragPoint_WithSize_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("DragPoint", new[] { typeof(int), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(Vector4F), typeof(float) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that drag point with size and flags should return bool
        /// </summary>
        [Fact]
        public void DragPoint_WithSizeAndFlags_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("DragPoint", new[] { typeof(int), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(Vector4F), typeof(float), typeof(ImPlotDragToolFlags) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that drag rect default should return bool
        /// </summary>
        [Fact]
        public void DragRect_Default_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("DragRect", new[] { typeof(int), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(Vector4F) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that drag rect with flags should return bool
        /// </summary>
        [Fact]
        public void DragRect_WithFlags_ShouldReturnBool()
        {
            MethodInfo method = GetPublicStaticMethod("DragRect", new[] { typeof(int), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(Vector4F), typeof(ImPlotDragToolFlags) });

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that end aligned plots should be void
        /// </summary>
        [Fact]
        public void EndAlignedPlots_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("EndAlignedPlots", Type.EmptyTypes);

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that end drag drop source should be void
        /// </summary>
        [Fact]
        public void EndDragDropSource_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("EndDragDropSource", Type.EmptyTypes);

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that add colormap should expose expected overload count
        /// </summary>
        [Fact]
        public void AddColormap_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("AddColormap");

            Assert.True(overloads.Length >= 4);
        }

        /// <summary>
        /// Tests that add colormap should expose vec 4 ptr and u 32 ptr families
        /// </summary>
        [Fact]
        public void AddColormap_ShouldExposeVec4PtrAndU32PtrFamilies()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("AddColormap");

            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(Vector4F)));
            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(uint)));
        }

        /// <summary>
        /// Tests that annotation should expose expected overload count
        /// </summary>
        [Fact]
        public void Annotation_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("Annotation");

            Assert.True(overloads.Length >= 3);
        }

        /// <summary>
        /// Tests that annotation should exclude overloads with bool and string
        /// </summary>
        [Fact]
        public void Annotation_ShouldExcludeOverloadsWithBoolAndString()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("Annotation");

            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType == typeof(bool)));
            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType == typeof(string)));
        }

        /// <summary>
        /// Tests that begin aligned plots should expose expected overload count
        /// </summary>
        [Fact]
        public void BeginAlignedPlots_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("BeginAlignedPlots");

            Assert.True(overloads.Length >= 2);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
            Assert.Contains(overloads, method => method.GetParameters().Length == 2);
        }

        /// <summary>
        /// Tests that begin drag drop source axis should expose expected overload count
        /// </summary>
        [Fact]
        public void BeginDragDropSourceAxis_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("BeginDragDropSourceAxis");

            Assert.True(overloads.Length >= 2);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
            Assert.Contains(overloads, method => method.GetParameters().Length == 2);
        }

        /// <summary>
        /// Tests that begin drag drop source item should expose expected overload count
        /// </summary>
        [Fact]
        public void BeginDragDropSourceItem_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("BeginDragDropSourceItem");

            Assert.True(overloads.Length >= 2);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
            Assert.Contains(overloads, method => method.GetParameters().Length == 2);
        }

        /// <summary>
        /// Tests that begin drag drop source plot should expose expected overload count
        /// </summary>
        [Fact]
        public void BeginDragDropSourcePlot_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("BeginDragDropSourcePlot");

            Assert.True(overloads.Length >= 2);
            Assert.Contains(overloads, method => method.GetParameters().Length == 0);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
        }

        /// <summary>
        /// Tests that begin drag drop target methods should expose expected overloads
        /// </summary>
        [Fact]
        public void BeginDragDropTargetMethods_ShouldExposeExpectedOverloads()
        {
            Assert.NotNull(GetPublicStaticMethod("BeginDragDropTargetAxis", new[] { typeof(ImAxis) }));
            Assert.NotNull(GetPublicStaticMethod("BeginDragDropTargetLegend", Type.EmptyTypes));
            Assert.NotNull(GetPublicStaticMethod("BeginDragDropTargetPlot", Type.EmptyTypes));
        }

        /// <summary>
        /// Tests that begin legend popup should expose expected overload count
        /// </summary>
        [Fact]
        public void BeginLegendPopup_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("BeginLegendPopup");

            Assert.True(overloads.Length >= 2);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
            Assert.Contains(overloads, method => method.GetParameters().Length == 2);
        }

        /// <summary>
        /// Tests that begin plot should expose expected overload count
        /// </summary>
        [Fact]
        public void BeginPlot_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("BeginPlot");

            Assert.True(overloads.Length >= 3);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
            Assert.Contains(overloads, method => method.GetParameters().Length == 2);
            Assert.Contains(overloads, method => method.GetParameters().Length == 3);
        }

        /// <summary>
        /// Tests that begin plot should accept string and vector 2 f and flags
        /// </summary>
        [Fact]
        public void BeginPlot_ShouldAcceptStringAndVector2FAndFlags()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("BeginPlot");

            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType == typeof(string)));
            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType == typeof(Vector2F)));
            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType == typeof(ImPlotFlags)));
        }

        /// <summary>
        /// Tests that begin subplots should expose expected overload count
        /// </summary>
        [Fact]
        public void BeginSubplots_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("BeginSubplots");

            Assert.True(overloads.Length >= 4);
            Assert.Contains(overloads, method => method.GetParameters().Length == 4);
            Assert.Contains(overloads, method => method.GetParameters().Length == 5);
            Assert.Contains(overloads, method => method.GetParameters().Length == 6);
            Assert.Contains(overloads, method => method.GetParameters().Length == 7);
        }

        /// <summary>
        /// Tests that begin subplots should accept by ref ratios
        /// </summary>
        [Fact]
        public void BeginSubplots_ShouldAcceptByRefRatios()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("BeginSubplots");

            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(float)));
        }

        /// <summary>
        /// Tests that bust color cache should expose expected overload count
        /// </summary>
        [Fact]
        public void BustColorCache_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("BustColorCache");

            Assert.True(overloads.Length >= 2);
            Assert.Contains(overloads, method => method.GetParameters().Length == 0);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
        }

        /// <summary>
        /// Tests that colormap button should expose expected overload count
        /// </summary>
        [Fact]
        public void ColormapButton_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("ColormapButton");

            Assert.True(overloads.Length >= 3);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
            Assert.Contains(overloads, method => method.GetParameters().Length == 2);
            Assert.Contains(overloads, method => method.GetParameters().Length == 3);
        }

        /// <summary>
        /// Tests that colormap scale should expose expected overload count
        /// </summary>
        [Fact]
        public void ColormapScale_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("ColormapScale");

            Assert.True(overloads.Length >= 5);
        }

        /// <summary>
        /// Tests that colormap scale should accept format and flags and cmap
        /// </summary>
        [Fact]
        public void ColormapScale_ShouldAcceptFormatAndFlagsAndCmap()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("ColormapScale");

            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType == typeof(string)));
            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType == typeof(ImPlotColormapScaleFlags)));
            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType == typeof(ImPlotColormap)));
        }

        /// <summary>
        /// Tests that colormap slider should expose expected overload count
        /// </summary>
        [Fact]
        public void ColormapSlider_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("ColormapSlider");

            Assert.True(overloads.Length >= 4);
        }

        /// <summary>
        /// Tests that colormap slider should accept by ref float and out vec 4 and format and cmap
        /// </summary>
        [Fact]
        public void ColormapSlider_ShouldAcceptByRefFloatAndOutVec4AndFormatAndCmap()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("ColormapSlider");

            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(float)));
            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(Vector4F)));
            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType == typeof(string)));
            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType == typeof(ImPlotColormap)));
        }

        /// <summary>
        /// Tests that destroy context should expose expected overload count
        /// </summary>
        [Fact]
        public void DestroyContext_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("DestroyContext");

            Assert.True(overloads.Length >= 2);
            Assert.Contains(overloads, method => method.GetParameters().Length == 0);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
        }

        /// <summary>
        /// Tests that drag line x should expose expected overload count
        /// </summary>
        [Fact]
        public void DragLineX_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("DragLineX");

            Assert.True(overloads.Length >= 3);
            Assert.Contains(overloads, method => method.GetParameters().Length == 3);
            Assert.Contains(overloads, method => method.GetParameters().Length == 4);
            Assert.Contains(overloads, method => method.GetParameters().Length == 5);
        }

        /// <summary>
        /// Tests that drag line x should accept by ref double and vec 4 and thickness and flags
        /// </summary>
        [Fact]
        public void DragLineX_ShouldAcceptByRefDoubleAndVec4AndThicknessAndFlags()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("DragLineX");

            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(double)));
            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType == typeof(Vector4F)));
            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType == typeof(float)));
            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType == typeof(ImPlotDragToolFlags)));
        }

        /// <summary>
        /// Tests that drag line y should expose expected overload count
        /// </summary>
        [Fact]
        public void DragLineY_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("DragLineY");

            Assert.True(overloads.Length >= 3);
            Assert.Contains(overloads, method => method.GetParameters().Length == 3);
            Assert.Contains(overloads, method => method.GetParameters().Length == 4);
            Assert.Contains(overloads, method => method.GetParameters().Length == 5);
        }

        /// <summary>
        /// Tests that drag point should expose expected overload count
        /// </summary>
        [Fact]
        public void DragPoint_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("DragPoint");

            Assert.True(overloads.Length >= 3);
            Assert.Contains(overloads, method => method.GetParameters().Length == 4);
            Assert.Contains(overloads, method => method.GetParameters().Length == 5);
            Assert.Contains(overloads, method => method.GetParameters().Length == 6);
        }

        /// <summary>
        /// Tests that drag rect should expose expected overload count
        /// </summary>
        [Fact]
        public void DragRect_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("DragRect");

            Assert.True(overloads.Length >= 2);
            Assert.Contains(overloads, method => method.GetParameters().Length == 6);
            Assert.Contains(overloads, method => method.GetParameters().Length == 7);
        }

        /// <summary>
        /// Tests that drag rect should accept by ref doubles and vec 4 and flags
        /// </summary>
        [Fact]
        public void DragRect_ShouldAcceptByRefDoublesAndVec4AndFlags()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("DragRect");

            Assert.Contains(overloads, method => method.GetParameters().Count(p => p.ParameterType.IsByRef) >= 4);
            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType == typeof(Vector4F)));
            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType == typeof(ImPlotDragToolFlags)));
        }

        /// <summary>
        /// Tests that void no parameter methods should exist
        /// </summary>
        [Fact]
        public void VoidNoParameterMethods_ShouldExist()
        {
            Assert.NotNull(GetPublicStaticMethod("CancelPlotSelection", Type.EmptyTypes));
            Assert.NotNull(GetPublicStaticMethod("EndAlignedPlots", Type.EmptyTypes));
            Assert.NotNull(GetPublicStaticMethod("EndDragDropSource", Type.EmptyTypes));
            Assert.NotNull(GetPublicStaticMethod("ColormapIcon", new[] { typeof(ImPlotColormap) }));
        }

        /// <summary>
        /// Tests that create context should be public static method
        /// </summary>
        [Fact]
        public void CreateContext_ShouldBePublicStaticMethod()
        {
            MethodInfo method = GetPublicStaticMethod("CreateContext", Type.EmptyTypes);

            Assert.NotNull(method);
            Assert.Equal(typeof(IntPtr), method.ReturnType);
            Assert.Empty(method.GetParameters());
        }

        /// <summary>
        /// Gets the public static method using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="parameterTypes">The parameter types</param>
        /// <returns>The method info</returns>
        private static MethodInfo GetPublicStaticMethod(string name, Type[] parameterTypes)
        {
            return typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .FirstOrDefault(method =>
                {
                    if (method.Name != name)
                    {
                        return false;
                    }
                    ParameterInfo[] parameters = method.GetParameters();
                    if (parameters.Length != parameterTypes.Length)
                    {
                        return false;
                    }
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        if (parameters[i].ParameterType != parameterTypes[i])
                        {
                            return false;
                        }
                    }
                    return true;
                });
        }

        /// <summary>
        /// Gets the public static methods using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The method info array</returns>
        private static MethodInfo[] GetPublicStaticMethods(string name)
        {
            return typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(method => method.Name == name)
                .ToArray();
        }

        /// <summary>
        /// Gets the public static method using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The method info</returns>
        private static MethodInfo GetPublicStaticMethod(string name)
        {
            return typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .FirstOrDefault(method => method.Name == name);
        }
    }
}
