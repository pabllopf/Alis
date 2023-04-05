// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlLogCategory.cs
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

namespace Alis.Core.Input.SDL2
{
    /// <summary>
    ///     The sdl logcategory enum
    /// </summary>
    public enum SdlLogCategory
    {
        /// <summary>
        ///     The sdl log category application sdl logcategory
        /// </summary>
        SdlLogCategoryApplication,

        /// <summary>
        ///     The sdl log category error sdl logcategory
        /// </summary>
        SdlLogCategoryError,

        /// <summary>
        ///     The sdl log category assert sdl logcategory
        /// </summary>
        SdlLogCategoryAssert,

        /// <summary>
        ///     The sdl log category system sdl logcategory
        /// </summary>
        SdlLogCategorySystem,

        /// <summary>
        ///     The sdl log category audio sdl logcategory
        /// </summary>
        SdlLogCategoryAudio,

        /// <summary>
        ///     The sdl log category video sdl logcategory
        /// </summary>
        SdlLogCategoryVideo,

        /// <summary>
        ///     The sdl log category render sdl logcategory
        /// </summary>
        SdlLogCategoryRender,

        /// <summary>
        ///     The sdl log category input sdl logcategory
        /// </summary>
        SdlLogCategoryInput,

        /// <summary>
        ///     The sdl log category test sdl logcategory
        /// </summary>
        SdlLogCategoryTest,

        /* Reserved for future SDL library use */
        /// <summary>
        ///     The sdl log category reserved1 sdl logcategory
        /// </summary>
        SdlLogCategoryReserved1,

        /// <summary>
        ///     The sdl log category reserved2 sdl logcategory
        /// </summary>
        SdlLogCategoryReserved2,

        /// <summary>
        ///     The sdl log category reserved3 sdl logcategory
        /// </summary>
        SdlLogCategoryReserved3,

        /// <summary>
        ///     The sdl log category reserved4 sdl logcategory
        /// </summary>
        SdlLogCategoryReserved4,

        /// <summary>
        ///     The sdl log category reserved5 sdl logcategory
        /// </summary>
        SdlLogCategoryReserved5,

        /// <summary>
        ///     The sdl log category reserved6 sdl logcategory
        /// </summary>
        SdlLogCategoryReserved6,

        /// <summary>
        ///     The sdl log category reserved7 sdl logcategory
        /// </summary>
        SdlLogCategoryReserved7,

        /// <summary>
        ///     The sdl log category reserved8 sdl logcategory
        /// </summary>
        SdlLogCategoryReserved8,

        /// <summary>
        ///     The sdl log category reserved9 sdl logcategory
        /// </summary>
        SdlLogCategoryReserved9,

        /// <summary>
        ///     The sdl log category reserved10 sdl logcategory
        /// </summary>
        SdlLogCategoryReserved10,

        /* Beyond this point is reserved for application use, e.g.
        enum {
            MYAPP_CATEGORY_AWESOME1 = SDL_LOG_CATEGORY_CUSTOM,
            MYAPP_CATEGORY_AWESOME2,
            MYAPP_CATEGORY_AWESOME3,
            ...
        };
        */
        /// <summary>
        ///     The sdl log category custom sdl logcategory
        /// </summary>
        SdlLogCategoryCustom
    }
}