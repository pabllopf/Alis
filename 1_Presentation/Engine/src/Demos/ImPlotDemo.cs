// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotDemo.cs
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


using System.Diagnostics;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Extras.Plot;

namespace Alis.App.Engine.Demos
{
    /// <summary>
    ///     The im plot demo class
    /// </summary>
    /// <seealso cref="IDemo" />
    public class ImPlotDemo : IDemo
    {
        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public void Start()
        {
        }

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            DefaultDemo();
            SimplePlot();
        }

        /// <summary>
        ///     Defaults the demo
        /// </summary>
        [Conditional("DEBUG")]
        private void DefaultDemo()
        {
            ImPlot.ShowDemoWindow();
        }

        /// <summary>
        ///     Simples the plot
        /// </summary>
        [Conditional("DEBUG")]
        private void SimplePlot()
        {
            // Show simple plot of bars plot demo
            ImGui.Begin("Simple plot");
            ImGui.Text("Demonstrating a basic bar plot with horizontal and vertical bars.");
            float[] data = new float[10] {3, 2, 4, 4, 5, 6, 6, 8, 9, 10};
            float[] lineData = new float[10] {3, 2, 4, 4, 5, 6, 6, 8, 9, 10};
            if (ImPlot.BeginPlot("Bar Plot"))
            {
                ImPlot.PlotBars("Horizontal", data, 10, 0.7, 1, ImPlotBarsFlags.None);
                ImPlot.PlotLine("Vertical", lineData, 10, 1, 1, ImPlotLineFlags.None, 0);
                ImPlot.EndPlot();
            }

            ImGui.End();
        }
    }
}