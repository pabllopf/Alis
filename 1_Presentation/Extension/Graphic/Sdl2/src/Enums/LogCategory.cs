// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LogCategory.cs
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

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl log category enum
    /// </summary>
    public enum LogCategory
    {
    /// <summary>
    ///     Log messages from application-level code
    /// </summary>
    SdlLogCategoryApplication,

    /// <summary>
    ///     Log messages for internal SDL error reporting
    /// </summary>
    SdlLogCategoryError,

    /// <summary>
    ///     Log messages for assertion failures
    /// </summary>
    SdlLogCategoryAssert,

    /// <summary>
    ///     Log messages from SDL system-level components
    /// </summary>
    SdlLogCategorySystem,

    /// <summary>
    ///     Log messages from the audio subsystem
    /// </summary>
    SdlLogCategoryAudio,

    /// <summary>
    ///     Log messages from the video subsystem
    /// </summary>
    SdlLogCategoryVideo,

    /// <summary>
    ///     Log messages from the render subsystem
    /// </summary>
    SdlLogCategoryRender,

    /// <summary>
    ///     Log messages from the input subsystem
    /// </summary>
    SdlLogCategoryInput,

    /// <summary>
    ///     Log messages from SDL test utilities
    /// </summary>
    SdlLogCategoryTest,

    /// <summary>
    ///     Reserved for future SDL log categories (slot 1)
    /// </summary>
    SdlLogCategoryReserved1,

    /// <summary>
    ///     Reserved for future SDL log categories (slot 2)
    /// </summary>
    SdlLogCategoryReserved2,

    /// <summary>
    ///     Reserved for future SDL log categories (slot 3)
    /// </summary>
    SdlLogCategoryReserved3,

    /// <summary>
    ///     Reserved for future SDL log categories (slot 4)
    /// </summary>
    SdlLogCategoryReserved4,

    /// <summary>
    ///     Reserved for future SDL log categories (slot 5)
    /// </summary>
    SdlLogCategoryReserved5,

    /// <summary>
    ///     Reserved for future SDL log categories (slot 6)
    /// </summary>
    SdlLogCategoryReserved6,

    /// <summary>
    ///     Reserved for future SDL log categories (slot 7)
    /// </summary>
    SdlLogCategoryReserved7,

    /// <summary>
    ///     Reserved for future SDL log categories (slot 8)
    /// </summary>
    SdlLogCategoryReserved8,

    /// <summary>
    ///     Reserved for future SDL log categories (slot 9)
    /// </summary>
    SdlLogCategoryReserved9,

    /// <summary>
    ///     Reserved for future SDL log categories (slot 10)
    /// </summary>
    SdlLogCategoryReserved10,

    /// <summary>
    ///     Custom user-defined log category (beyond the reserved range)
    /// </summary>
    SdlLogCategoryCustom
    }
}