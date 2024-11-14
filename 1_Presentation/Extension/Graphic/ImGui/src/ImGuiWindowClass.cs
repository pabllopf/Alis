// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiWindowClass.cs
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

namespace Alis.Extension.Graphic.ImGui
{
    /// <summary>
    ///     The im gui window
    /// </summary>
    public struct ImGuiWindowClass
    {
        /// <summary>
        ///     The class id
        /// </summary>
        public uint ClassId { get; set; }

        /// <summary>
        ///     The parent viewport id
        /// </summary>
        public uint ParentViewportId { get; set; }

        /// <summary>
        ///     The viewport flags override set
        /// </summary>
        public ImGuiViewportFlags ViewportFlagsOverrideSet { get; set; }

        /// <summary>
        ///     The viewport flags override clear
        /// </summary>
        public ImGuiViewportFlags ViewportFlagsOverrideClear { get; set; }

        /// <summary>
        ///     The tab item flags override set
        /// </summary>
        public ImGuiTabItemFlags TabItemFlagsOverrideSet { get; set; }

        /// <summary>
        ///     The dock node flags override set
        /// </summary>
        public ImGuiDockNodeFlags DockNodeFlagsOverrideSet { get; set; }

        /// <summary>
        ///     The docking always tab bar
        /// </summary>
        public byte DockingAlwaysTabBar { get; set; }

        /// <summary>
        ///     The docking allow unclassed
        /// </summary>
        public byte DockingAllowUnclassed { get; set; }
    }
}