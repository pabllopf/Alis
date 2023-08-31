// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiDragDropFlags.cs
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

namespace Alis.Core.Graphic.UI.Extras.Plot
{
    /// <summary>
    ///     The im gui drag drop flags enum
    /// </summary>
    [Flags]
    public enum ImGuiDragDropFlags
    {
        /// <summary>
        ///     The none im gui drag drop flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The source no preview tooltip im gui drag drop flags
        /// </summary>
        SourceNoPreviewTooltip = 1,

        /// <summary>
        ///     The source no disable hover im gui drag drop flags
        /// </summary>
        SourceNoDisableHover = 2,

        /// <summary>
        ///     The source no hold to open others im gui drag drop flags
        /// </summary>
        SourceNoHoldToOpenOthers = 4,

        /// <summary>
        ///     The source allow null id im gui drag drop flags
        /// </summary>
        SourceAllowNullId = 8,

        /// <summary>
        ///     The source extern im gui drag drop flags
        /// </summary>
        SourceExtern = 16,

        /// <summary>
        ///     The source auto expire payload im gui drag drop flags
        /// </summary>
        SourceAutoExpirePayload = 32,

        /// <summary>
        ///     The accept before delivery im gui drag drop flags
        /// </summary>
        AcceptBeforeDelivery = 1024,

        /// <summary>
        ///     The accept no draw default rect im gui drag drop flags
        /// </summary>
        AcceptNoDrawDefaultRect = 2048,

        /// <summary>
        ///     The accept no preview tooltip im gui drag drop flags
        /// </summary>
        AcceptNoPreviewTooltip = 4096,

        /// <summary>
        ///     The accept peek only im gui drag drop flags
        /// </summary>
        AcceptPeekOnly = 3072
    }
}