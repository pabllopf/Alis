// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotInputMapTests.cs
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

using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     The im plot input map tests class
    /// </summary>
    public class ImPlotInputMapTests
    {
        /// <summary>
        ///     Tests that default values are all zero
        /// </summary>
        [Fact]
        public void Default_Should_SetAllPropertiesToDefaultValues()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();

            Assert.Equal(default(ImGuiMouseButton), inputMap.Pan);
            Assert.Equal(default(Ui.Extras.Plot.ImGuiModFlags), inputMap.PanMod);
            Assert.Equal(default(ImGuiMouseButton), inputMap.Fit);
            Assert.Equal(default(ImGuiMouseButton), inputMap.Select);
            Assert.Equal(default(ImGuiMouseButton), inputMap.SelectCancel);
            Assert.Equal(default(Ui.Extras.Plot.ImGuiModFlags), inputMap.SelectMod);
            Assert.Equal(default(Ui.Extras.Plot.ImGuiModFlags), inputMap.SelectHorzMod);
            Assert.Equal(default(Ui.Extras.Plot.ImGuiModFlags), inputMap.SelectVertMod);
            Assert.Equal(default(ImGuiMouseButton), inputMap.Menu);
            Assert.Equal(default(Ui.Extras.Plot.ImGuiModFlags), inputMap.OverrideMod);
            Assert.Equal(default(Ui.Extras.Plot.ImGuiModFlags), inputMap.ZoomMod);
            Assert.Equal(default(float), inputMap.ZoomRate, 5);
        }

        /// <summary>
        ///     Tests that pan can be set and retrieved
        /// </summary>
        [Fact]
        public void Pan_Should_SetAndGetCorrectly()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            const ImGuiMouseButton value = ImGuiMouseButton.Left;
            inputMap.Pan = value;
            Assert.Equal(value, inputMap.Pan);
        }

        /// <summary>
        ///     Tests that pan mod can be set and retrieved
        /// </summary>
        [Fact]
        public void PanMod_Should_SetAndGetCorrectly()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            const Ui.Extras.Plot.ImGuiModFlags value = Ui.Extras.Plot.ImGuiModFlags.Ctrl;
            inputMap.PanMod = value;
            Assert.Equal(value, inputMap.PanMod);
        }

        /// <summary>
        ///     Tests that fit can be set and retrieved
        /// </summary>
        [Fact]
        public void Fit_Should_SetAndGetCorrectly()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            const ImGuiMouseButton value = ImGuiMouseButton.Right;
            inputMap.Fit = value;
            Assert.Equal(value, inputMap.Fit);
        }

        /// <summary>
        ///     Tests that select can be set and retrieved
        /// </summary>
        [Fact]
        public void Select_Should_SetAndGetCorrectly()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            const ImGuiMouseButton value = ImGuiMouseButton.Middle;
            inputMap.Select = value;
            Assert.Equal(value, inputMap.Select);
        }

        /// <summary>
        ///     Tests that select cancel can be set and retrieved
        /// </summary>
        [Fact]
        public void SelectCancel_Should_SetAndGetCorrectly()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            const ImGuiMouseButton value = ImGuiMouseButton.Count;
            inputMap.SelectCancel = value;
            Assert.Equal(value, inputMap.SelectCancel);
        }

        /// <summary>
        ///     Tests that select mod can be set and retrieved
        /// </summary>
        [Fact]
        public void SelectMod_Should_SetAndGetCorrectly()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            const Ui.Extras.Plot.ImGuiModFlags value = Ui.Extras.Plot.ImGuiModFlags.Shift;
            inputMap.SelectMod = value;
            Assert.Equal(value, inputMap.SelectMod);
        }

        /// <summary>
        ///     Tests that select horz mod can be set and retrieved
        /// </summary>
        [Fact]
        public void SelectHorzMod_Should_SetAndGetCorrectly()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            const Ui.Extras.Plot.ImGuiModFlags value = Ui.Extras.Plot.ImGuiModFlags.Alt;
            inputMap.SelectHorzMod = value;
            Assert.Equal(value, inputMap.SelectHorzMod);
        }

        /// <summary>
        ///     Tests that select vert mod can be set and retrieved
        /// </summary>
        [Fact]
        public void SelectVertMod_Should_SetAndGetCorrectly()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            const Ui.Extras.Plot.ImGuiModFlags value = Ui.Extras.Plot.ImGuiModFlags.Super;
            inputMap.SelectVertMod = value;
            Assert.Equal(value, inputMap.SelectVertMod);
        }

        /// <summary>
        ///     Tests that menu can be set and retrieved
        /// </summary>
        [Fact]
        public void Menu_Should_SetAndGetCorrectly()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            const ImGuiMouseButton value = ImGuiMouseButton.Left;
            inputMap.Menu = value;
            Assert.Equal(value, inputMap.Menu);
        }

        /// <summary>
        ///     Tests that override mod can be set and retrieved
        /// </summary>
        [Fact]
        public void OverrideMod_Should_SetAndGetCorrectly()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            const Ui.Extras.Plot.ImGuiModFlags value = Ui.Extras.Plot.ImGuiModFlags.Ctrl | Ui.Extras.Plot.ImGuiModFlags.Shift;
            inputMap.OverrideMod = value;
            Assert.Equal(value, inputMap.OverrideMod);
        }

        /// <summary>
        ///     Tests that zoom mod can be set and retrieved
        /// </summary>
        [Fact]
        public void ZoomMod_Should_SetAndGetCorrectly()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            const Ui.Extras.Plot.ImGuiModFlags value = Ui.Extras.Plot.ImGuiModFlags.None;
            inputMap.ZoomMod = value;
            Assert.Equal(value, inputMap.ZoomMod);
        }

        /// <summary>
        ///     Tests that zoom rate can be set and retrieved
        /// </summary>
        [Fact]
        public void ZoomRate_Should_SetAndGetCorrectly()
        {
            ImPlotInputMap inputMap = new ImPlotInputMap();
            const float value = 1.5f;
            inputMap.ZoomRate = value;
            Assert.Equal(value, inputMap.ZoomRate);
        }

        /// <summary>
        ///     Tests that struct is a value type
        /// </summary>
        [Fact]
        public void ImPlotInputMap_Should_BeValueType()
        {
            ImPlotInputMap first = new ImPlotInputMap { Pan = ImGuiMouseButton.Left, ZoomRate = 2.0f };
            ImPlotInputMap second = first;
            second.Pan = ImGuiMouseButton.Right;
            Assert.Equal(ImGuiMouseButton.Left, first.Pan);
            Assert.Equal(ImGuiMouseButton.Right, second.Pan);
        }
    }
}
