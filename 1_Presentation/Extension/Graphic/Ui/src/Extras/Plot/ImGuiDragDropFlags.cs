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

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     Flags to control drag-and-drop behaviour within ImPlot contexts.
    /// </summary>
    [Flags]
    public enum ImGuiDragDropFlags
    {
        /// <summary>
        ///     No special behaviour.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Disable the default tooltip shown while dragging from a source.
        /// </summary>
        SourceNoPreviewTooltip = 1,

        /// <summary>
        ///     Do not disable the hover state of the source item while dragging.
        /// </summary>
        SourceNoDisableHover = 2,

        /// <summary>
        ///     Disable the hold-to-open-others behaviour for the source.
        /// </summary>
        SourceNoHoldToOpenOthers = 4,

        /// <summary>
        ///     Allow the source to have a null ID (anonymous drag source).
        /// </summary>
        SourceAllowNullId = 8,

        /// <summary>
        ///     Mark the drag payload as originating from an external source.
        /// </summary>
        SourceExtern = 16,

        /// <summary>
        ///     Automatically expire the drag payload after the drag ends.
        /// </summary>
        SourceAutoExpirePayload = 32,

        /// <summary>
        ///     Accept the payload before it is delivered (preview accept).
        /// </summary>
        AcceptBeforeDelivery = 1024,

        /// <summary>
        ///     Suppress the default highlight rectangle on the accept target.
        /// </summary>
        AcceptNoDrawDefaultRect = 2048,

        /// <summary>
        ///     Disable the preview tooltip shown on the target side.
        /// </summary>
        AcceptNoPreviewTooltip = 4096,

        /// <summary>
        ///     Combination of AcceptBeforeDelivery and AcceptNoDrawDefaultRect for peek-only acceptance.
        /// </summary>
        AcceptPeekOnly = 3072
    }
}