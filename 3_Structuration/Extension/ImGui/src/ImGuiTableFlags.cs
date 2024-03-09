// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTableFlags.cs
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

namespace Alis.Core.Extension.ImGui
{
    /// <summary>
    ///     The im gui table flags enum
    /// </summary>
    [Flags]
    public enum ImGuiTableFlags
    {
        /// <summary>
        ///     The none im gui table flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The resizable im gui table flags
        /// </summary>
        Resizable = 1,

        /// <summary>
        ///     The reorderable im gui table flags
        /// </summary>
        Reorderable = 2,

        /// <summary>
        ///     The hideable im gui table flags
        /// </summary>
        Hideable = 4,

        /// <summary>
        ///     The sortable im gui table flags
        /// </summary>
        Sortable = 8,

        /// <summary>
        ///     The no saved settings im gui table flags
        /// </summary>
        NoSavedSettings = 16,

        /// <summary>
        ///     The context menu in body im gui table flags
        /// </summary>
        ContextMenuInBody = 32,

        /// <summary>
        ///     The row bg im gui table flags
        /// </summary>
        RowBg = 64,

        /// <summary>
        ///     The borders inner im gui table flags
        /// </summary>
        BordersInnerH = 128,

        /// <summary>
        ///     The borders outer im gui table flags
        /// </summary>
        BordersOuterH = 256,

        /// <summary>
        ///     The borders inner im gui table flags
        /// </summary>
        BordersInnerV = 512,

        /// <summary>
        ///     The borders outer im gui table flags
        /// </summary>
        BordersOuterV = 1024,

        /// <summary>
        ///     The borders im gui table flags
        /// </summary>
        BordersH = 384,

        /// <summary>
        ///     The borders im gui table flags
        /// </summary>
        BordersV = 1536,

        /// <summary>
        ///     The borders inner im gui table flags
        /// </summary>
        BordersInner = 640,

        /// <summary>
        ///     The borders outer im gui table flags
        /// </summary>
        BordersOuter = 1280,

        /// <summary>
        ///     The borders im gui table flags
        /// </summary>
        Borders = 1920,

        /// <summary>
        ///     The no borders in body im gui table flags
        /// </summary>
        NoBordersInBody = 2048,

        /// <summary>
        ///     The no borders in body until resize im gui table flags
        /// </summary>
        NoBordersInBodyUntilResize = 4096,

        /// <summary>
        ///     The sizing fixed fit im gui table flags
        /// </summary>
        SizingFixedFit = 8192,

        /// <summary>
        ///     The sizing fixed same im gui table flags
        /// </summary>
        SizingFixedSame = 16384,

        /// <summary>
        ///     The sizing stretch prop im gui table flags
        /// </summary>
        SizingStretchProp = 24576,

        /// <summary>
        ///     The sizing stretch same im gui table flags
        /// </summary>
        SizingStretchSame = 32768,

        /// <summary>
        ///     The no host extend im gui table flags
        /// </summary>
        NoHostExtendX = 65536,

        /// <summary>
        ///     The no host extend im gui table flags
        /// </summary>
        NoHostExtendY = 131072,

        /// <summary>
        ///     The no keep columns visible im gui table flags
        /// </summary>
        NoKeepColumnsVisible = 262144,

        /// <summary>
        ///     The precise widths im gui table flags
        /// </summary>
        PreciseWidths = 524288,

        /// <summary>
        ///     The no clip im gui table flags
        /// </summary>
        NoClip = 1048576,

        /// <summary>
        ///     The pad outer im gui table flags
        /// </summary>
        PadOuterX = 2097152,

        /// <summary>
        ///     The no pad outer im gui table flags
        /// </summary>
        NoPadOuterX = 4194304,

        /// <summary>
        ///     The no pad inner im gui table flags
        /// </summary>
        NoPadInnerX = 8388608,

        /// <summary>
        ///     The scroll im gui table flags
        /// </summary>
        ScrollX = 16777216,

        /// <summary>
        ///     The scroll im gui table flags
        /// </summary>
        ScrollY = 33554432,

        /// <summary>
        ///     The sort multi im gui table flags
        /// </summary>
        SortMulti = 67108864,

        /// <summary>
        ///     The sort tristate im gui table flags
        /// </summary>
        SortTristate = 134217728,

        /// <summary>
        ///     The sizing mask im gui table flags
        /// </summary>
        SizingMask = 57344
    }
}