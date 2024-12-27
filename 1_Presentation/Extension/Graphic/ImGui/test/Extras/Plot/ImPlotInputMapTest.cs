// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotInputMapTest.cs
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

using System.Diagnostics.CodeAnalysis;
using Alis.Extension.Graphic.ImGui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test.Extras.Plot
{
    /// <summary>
    ///     The im plot input map test class
    /// </summary>
    	 [ExcludeFromCodeCoverage] 
	 public class ImPlotInputMapTest 
    {
        /// <summary>
        ///     Tests that pan should be initialized
        /// </summary>
        [Fact]
        public void Pan_ShouldBeInitialized()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            Assert.Equal(default(ImGuiMouseButton), inputMap.Pan);
        }

        /// <summary>
        ///     Tests that pan mod should be initialized
        /// </summary>
        [Fact]
        public void PanMod_ShouldBeInitialized()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            Assert.Equal(default(ImGui.Extras.Plot.ImGuiModFlags), inputMap.PanMod);
        }

        /// <summary>
        ///     Tests that fit should be initialized
        /// </summary>
        [Fact]
        public void Fit_ShouldBeInitialized()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            Assert.Equal(default(ImGuiMouseButton), inputMap.Fit);
        }

        /// <summary>
        ///     Tests that select should be initialized
        /// </summary>
        [Fact]
        public void Select_ShouldBeInitialized()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            Assert.Equal(default(ImGuiMouseButton), inputMap.Select);
        }

        /// <summary>
        ///     Tests that select cancel should be initialized
        /// </summary>
        [Fact]
        public void SelectCancel_ShouldBeInitialized()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            Assert.Equal(default(ImGuiMouseButton), inputMap.SelectCancel);
        }

        /// <summary>
        ///     Tests that select mod should be initialized
        /// </summary>
        [Fact]
        public void SelectMod_ShouldBeInitialized()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            Assert.Equal(default(ImGui.Extras.Plot.ImGuiModFlags), inputMap.SelectMod);
        }

        /// <summary>
        ///     Tests that select horz mod should be initialized
        /// </summary>
        [Fact]
        public void SelectHorzMod_ShouldBeInitialized()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            Assert.Equal(default(ImGui.Extras.Plot.ImGuiModFlags), inputMap.SelectHorzMod);
        }

        /// <summary>
        ///     Tests that select vert mod should be initialized
        /// </summary>
        [Fact]
        public void SelectVertMod_ShouldBeInitialized()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            Assert.Equal(default(ImGui.Extras.Plot.ImGuiModFlags), inputMap.SelectVertMod);
        }

        /// <summary>
        ///     Tests that menu should be initialized
        /// </summary>
        [Fact]
        public void Menu_ShouldBeInitialized()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            Assert.Equal(default(ImGuiMouseButton), inputMap.Menu);
        }

        /// <summary>
        ///     Tests that override mod should be initialized
        /// </summary>
        [Fact]
        public void OverrideMod_ShouldBeInitialized()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            Assert.Equal(default(ImGui.Extras.Plot.ImGuiModFlags), inputMap.OverrideMod);
        }

        /// <summary>
        ///     Tests that zoom mod should be initialized
        /// </summary>
        [Fact]
        public void ZoomMod_ShouldBeInitialized()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            Assert.Equal(default(ImGui.Extras.Plot.ImGuiModFlags), inputMap.ZoomMod);
        }

        /// <summary>
        ///     Tests that zoom rate should be initialized
        /// </summary>
        [Fact]
        public void ZoomRate_ShouldBeInitialized()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            Assert.Equal(default(float), inputMap.ZoomRate);
        }

        /// <summary>
        ///     Tests that pan should set and get correctly
        /// </summary>
        [Fact]
        public void Pan_Should_SetAndGetCorrectly()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            ImGuiMouseButton value = ImGuiMouseButton.Left;
            inputMap.Pan = value;
            Assert.Equal(value, inputMap.Pan);
        }

        /// <summary>
        ///     Tests that pan mod should set and get correctly
        /// </summary>
        [Fact]
        public void PanMod_Should_SetAndGetCorrectly()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            ImGui.Extras.Plot.ImGuiModFlags value = ImGui.Extras.Plot.ImGuiModFlags.Ctrl;
            inputMap.PanMod = value;
            Assert.Equal(value, inputMap.PanMod);
        }

        /// <summary>
        ///     Tests that fit should set and get correctly
        /// </summary>
        [Fact]
        public void Fit_Should_SetAndGetCorrectly()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            ImGuiMouseButton value = ImGuiMouseButton.Right;
            inputMap.Fit = value;
            Assert.Equal(value, inputMap.Fit);
        }

        /// <summary>
        ///     Tests that select should set and get correctly
        /// </summary>
        [Fact]
        public void Select_Should_SetAndGetCorrectly()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            ImGuiMouseButton value = ImGuiMouseButton.Middle;
            inputMap.Select = value;
            Assert.Equal(value, inputMap.Select);
        }

        /// <summary>
        ///     Tests that select cancel should set and get correctly
        /// </summary>
        [Fact]
        public void SelectCancel_Should_SetAndGetCorrectly()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            ImGuiMouseButton value = ImGuiMouseButton.Left;
            inputMap.SelectCancel = value;
            Assert.Equal(value, inputMap.SelectCancel);
        }

        /// <summary>
        ///     Tests that select mod should set and get correctly
        /// </summary>
        [Fact]
        public void SelectMod_Should_SetAndGetCorrectly()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            ImGui.Extras.Plot.ImGuiModFlags value = ImGui.Extras.Plot.ImGuiModFlags.Shift;
            inputMap.SelectMod = value;
            Assert.Equal(value, inputMap.SelectMod);
        }

        /// <summary>
        ///     Tests that select horz mod should set and get correctly
        /// </summary>
        [Fact]
        public void SelectHorzMod_Should_SetAndGetCorrectly()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            ImGui.Extras.Plot.ImGuiModFlags value = ImGui.Extras.Plot.ImGuiModFlags.Alt;
            inputMap.SelectHorzMod = value;
            Assert.Equal(value, inputMap.SelectHorzMod);
        }

        /// <summary>
        ///     Tests that select vert mod should set and get correctly
        /// </summary>
        [Fact]
        public void SelectVertMod_Should_SetAndGetCorrectly()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            ImGui.Extras.Plot.ImGuiModFlags value = ImGui.Extras.Plot.ImGuiModFlags.Ctrl;
            inputMap.SelectVertMod = value;
            Assert.Equal(value, inputMap.SelectVertMod);
        }

        /// <summary>
        ///     Tests that menu should set and get correctly
        /// </summary>
        [Fact]
        public void Menu_Should_SetAndGetCorrectly()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            ImGuiMouseButton value = ImGuiMouseButton.Right;
            inputMap.Menu = value;
            Assert.Equal(value, inputMap.Menu);
        }

        /// <summary>
        ///     Tests that override mod should set and get correctly
        /// </summary>
        [Fact]
        public void OverrideMod_Should_SetAndGetCorrectly()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            ImGui.Extras.Plot.ImGuiModFlags value = ImGui.Extras.Plot.ImGuiModFlags.Ctrl;
            inputMap.OverrideMod = value;
            Assert.Equal(value, inputMap.OverrideMod);
        }

        /// <summary>
        ///     Tests that zoom mod should set and get correctly
        /// </summary>
        [Fact]
        public void ZoomMod_Should_SetAndGetCorrectly()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            ImGui.Extras.Plot.ImGuiModFlags value = ImGui.Extras.Plot.ImGuiModFlags.Shift;
            inputMap.ZoomMod = value;
            Assert.Equal(value, inputMap.ZoomMod);
        }

        /// <summary>
        ///     Tests that zoom rate should set and get correctly
        /// </summary>
        [Fact]
        public void ZoomRate_Should_SetAndGetCorrectly()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            float value = 1.5f;
            inputMap.ZoomRate = value;
            Assert.Equal(value, inputMap.ZoomRate);
        }
    }
}