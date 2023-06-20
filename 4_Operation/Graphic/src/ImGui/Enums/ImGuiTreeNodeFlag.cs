// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTreeNodeFlag.cs
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

namespace Alis.Core.Graphic.ImGui.Enums
{
    /// <summary>
    ///     The im gui tree node flags enum
    /// </summary>
    [Flags]
    public enum ImGuiTreeNodeFlag
    {
        /// <summary>
        ///     The none im gui tree node flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The selected im gui tree node flags
        /// </summary>
        Selected = 1,

        /// <summary>
        ///     The framed im gui tree node flags
        /// </summary>
        Framed = 2,

        /// <summary>
        ///     The allow item overlap im gui tree node flags
        /// </summary>
        AllowItemOverlap = 4,

        /// <summary>
        ///     The no tree push on open im gui tree node flags
        /// </summary>
        NoTreePushOnOpen = 8,

        /// <summary>
        ///     The no auto open on log im gui tree node flags
        /// </summary>
        NoAutoOpenOnLog = 16,

        /// <summary>
        ///     The default open im gui tree node flags
        /// </summary>
        DefaultOpen = 32,

        /// <summary>
        ///     The open on double click im gui tree node flags
        /// </summary>
        OpenOnDoubleClick = 64,

        /// <summary>
        ///     The open on arrow im gui tree node flags
        /// </summary>
        OpenOnArrow = 128,

        /// <summary>
        ///     The leaf im gui tree node flags
        /// </summary>
        Leaf = 256,

        /// <summary>
        ///     The bullet im gui tree node flags
        /// </summary>
        Bullet = 512,

        /// <summary>
        ///     The frame padding im gui tree node flags
        /// </summary>
        FramePadding = 1024,

        /// <summary>
        ///     The span avail width im gui tree node flags
        /// </summary>
        SpanAvailWidth = 2048,

        /// <summary>
        ///     The span full width im gui tree node flags
        /// </summary>
        SpanFullWidth = 4096,

        /// <summary>
        ///     The nav left jumps back here im gui tree node flags
        /// </summary>
        NavLeftJumpsBackHere = 8192,

        /// <summary>
        ///     The collapsing header im gui tree node flags
        /// </summary>
        CollapsingHeader = 26
    }
}