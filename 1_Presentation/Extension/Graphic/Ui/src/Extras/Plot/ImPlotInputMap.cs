// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotInputMap.cs
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

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     Maps mouse buttons and modifier keys to ImPlot interaction commands such as pan, select, and menu.
    /// </summary>
    public struct ImPlotInputMap
    {
        /// <summary>
        ///     Mouse button used for panning the plot view.
        /// </summary>
        public ImGuiMouseButton Pan { get; set; }

        /// <summary>
        ///     Modifier key required while panning.
        /// </summary>
        public ImGuiModFlags PanMod { get; set; }

        /// <summary>
        ///     Mouse button for triggering an auto-fit of the axis range.
        /// </summary>
        public ImGuiMouseButton Fit { get; set; }

        /// <summary>
        ///     Mouse button used for box-select (rectangle selection).
        /// </summary>
        public ImGuiMouseButton Select { get; set; }

        /// <summary>
        ///     Mouse button used to cancel an active selection.
        /// </summary>
        public ImGuiMouseButton SelectCancel { get; set; }

        /// <summary>
        ///     Modifier key required while performing a selection.
        /// </summary>
        public ImGuiModFlags SelectMod { get; set; }

        /// <summary>
        ///     Modifier key to constrain selection to the horizontal axis only.
        /// </summary>
        public ImGuiModFlags SelectHorzMod { get; set; }

        /// <summary>
        ///     Modifier key to constrain selection to the vertical axis only.
        /// </summary>
        public ImGuiModFlags SelectVertMod { get; set; }

        /// <summary>
        ///     Mouse button used to open the plot context menu.
        /// </summary>
        public ImGuiMouseButton Menu { get; set; }

        /// <summary>
        ///     Modifier key to temporarily override the current tool (e.g. force pan mode).
        /// </summary>
        public ImGuiModFlags OverrideMod { get; set; }

        /// <summary>
        ///     Modifier key for zoom-to-fit or zoom gestures.
        /// </summary>
        public ImGuiModFlags ZoomMod { get; set; }

        /// <summary>
        ///     Multiplier controlling the zoom speed.
        /// </summary>
        public float ZoomRate { get; set; }
    }
}