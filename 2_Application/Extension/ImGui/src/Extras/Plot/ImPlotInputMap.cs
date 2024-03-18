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

namespace Alis.Extension.ImGui.Extras.Plot
{
    /// <summary>
    ///     The im plot input map
    /// </summary>
    public struct ImPlotInputMap
    {
        /// <summary>
        ///     The pan
        /// </summary>
        public ImGuiMouseButton Pan;

        /// <summary>
        ///     The pan mod
        /// </summary>
        public ImGuiModFlags PanMod;

        /// <summary>
        ///     The fit
        /// </summary>
        public ImGuiMouseButton Fit;

        /// <summary>
        ///     The select
        /// </summary>
        public ImGuiMouseButton Select;

        /// <summary>
        ///     The select cancel
        /// </summary>
        public ImGuiMouseButton SelectCancel;

        /// <summary>
        ///     The select mod
        /// </summary>
        public ImGuiModFlags SelectMod;

        /// <summary>
        ///     The select horz mod
        /// </summary>
        public ImGuiModFlags SelectHorzMod;

        /// <summary>
        ///     The select vert mod
        /// </summary>
        public ImGuiModFlags SelectVertMod;

        /// <summary>
        ///     The menu
        /// </summary>
        public ImGuiMouseButton Menu;

        /// <summary>
        ///     The override mod
        /// </summary>
        public ImGuiModFlags OverrideMod;

        /// <summary>
        ///     The zoom mod
        /// </summary>
        public ImGuiModFlags ZoomMod;

        /// <summary>
        ///     The zoom rate
        /// </summary>
        public float ZoomRate;
    }
}