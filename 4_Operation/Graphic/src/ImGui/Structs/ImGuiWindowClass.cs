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

using Alis.Core.Graphic.ImGui.Enums;

namespace Alis.Core.Graphic.ImGui.Structs
{
    /// <summary>
    ///     The im gui window
    /// </summary>
    public struct ImGuiWindowClass
    {
        /// <summary>
        ///     The class id
        /// </summary>
        public uint ClassId;

        /// <summary>
        ///     The parent viewport id
        /// </summary>
        public uint ParentViewportId;

        /// <summary>
        ///     The viewport flags override set
        /// </summary>
        public ImGuiViewports ViewportsOverrideSet;

        /// <summary>
        ///     The viewport flags override clear
        /// </summary>
        public ImGuiViewports ViewportsOverrideClear;

        /// <summary>
        ///     The tab item flags override set
        /// </summary>
        public ImGuiTabItems TabItemsOverrideSet;

        /// <summary>
        ///     The dock node flags override set
        /// </summary>
        public ImGuiDockNodes DockNodesOverrideSet;

        /// <summary>
        ///     The docking always tab bar
        /// </summary>
        public byte DockingAlwaysTabBar;

        /// <summary>
        ///     The docking allow unclassed
        /// </summary>
        public byte DockingAllowUnclassed;
    }
}