// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiColorEditFlag.cs
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
    ///     The im gui color edit flags enum
    /// </summary>
    [Flags]
    public enum ImGuiColorEditFlag
    {
        /// <summary>
        ///     The none im gui color edit flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The no alpha im gui color edit flags
        /// </summary>
        NoAlpha = 2,

        /// <summary>
        ///     The no picker im gui color edit flags
        /// </summary>
        NoPicker = 4,

        /// <summary>
        ///     The no options im gui color edit flags
        /// </summary>
        NoOptions = 8,

        /// <summary>
        ///     The no small preview im gui color edit flags
        /// </summary>
        NoSmallPreview = 16,

        /// <summary>
        ///     The no inputs im gui color edit flags
        /// </summary>
        NoInputs = 32,

        /// <summary>
        ///     The no tooltip im gui color edit flags
        /// </summary>
        NoTooltip = 64,

        /// <summary>
        ///     The no label im gui color edit flags
        /// </summary>
        NoLabel = 128,

        /// <summary>
        ///     The no side preview im gui color edit flags
        /// </summary>
        NoSidePreview = 256,

        /// <summary>
        ///     The no drag drop im gui color edit flags
        /// </summary>
        NoDragDrop = 512,

        /// <summary>
        ///     The no border im gui color edit flags
        /// </summary>
        NoBorder = 1024,

        /// <summary>
        ///     The alpha bar im gui color edit flags
        /// </summary>
        AlphaBar = 65536,

        /// <summary>
        ///     The alpha preview im gui color edit flags
        /// </summary>
        AlphaPreview = 131072,

        /// <summary>
        ///     The alpha preview half im gui color edit flags
        /// </summary>
        AlphaPreviewHalf = 262144,

        /// <summary>
        ///     The hdr im gui color edit flags
        /// </summary>
        Hdr = 524288,

        /// <summary>
        ///     The display rgb im gui color edit flags
        /// </summary>
        DisplayRgb = 1048576,

        /// <summary>
        ///     The display hsv im gui color edit flags
        /// </summary>
        DisplayHsv = 2097152,

        /// <summary>
        ///     The display hex im gui color edit flags
        /// </summary>
        DisplayHex = 4194304,

        /// <summary>
        ///     The uint im gui color edit flags
        /// </summary>
        Uint8 = 8388608,

        /// <summary>
        ///     The float im gui color edit flags
        /// </summary>
        Float = 16777216,

        /// <summary>
        ///     The picker hue bar im gui color edit flags
        /// </summary>
        PickerHueBar = 33554432,

        /// <summary>
        ///     The picker hue wheel im gui color edit flags
        /// </summary>
        PickerHueWheel = 67108864,

        /// <summary>
        ///     The input rgb im gui color edit flags
        /// </summary>
        InputRgb = 134217728,

        /// <summary>
        ///     The input hsv im gui color edit flags
        /// </summary>
        InputHsv = 268435456,

        /// <summary>
        ///     The default options im gui color edit flags
        /// </summary>
        DefaultOptions = 177209344,

        /// <summary>
        ///     The display mask im gui color edit flags
        /// </summary>
        DisplayMask = 7340032,

        /// <summary>
        ///     The data type mask im gui color edit flags
        /// </summary>
        DataTypeMask = 25165824,

        /// <summary>
        ///     The picker mask im gui color edit flags
        /// </summary>
        PickerMask = 100663296,

        /// <summary>
        ///     The input mask im gui color edit flags
        /// </summary>
        InputMask = 402653184
    }
}