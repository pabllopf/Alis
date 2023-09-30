// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlWindowEventId.cs
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

namespace Alis.Core.Graphic.SDL.Enums
{
    /// <summary>
    ///     The sdl windoweventid enum
    /// </summary>
    public enum SdlWindowEventId : byte
    {
        /// <summary>
        ///     The sdl windowevent none sdl windoweventid
        /// </summary>
        SdlWindoweventNone,

        /// <summary>
        ///     The sdl windowevent shown sdl windoweventid
        /// </summary>
        SdlWindoweventShown,

        /// <summary>
        ///     The sdl windowevent hidden sdl windoweventid
        /// </summary>
        SdlWindoweventHidden,

        /// <summary>
        ///     The sdl windowevent exposed sdl windoweventid
        /// </summary>
        SdlWindoweventExposed,

        /// <summary>
        ///     The sdl windowevent moved sdl windoweventid
        /// </summary>
        SdlWindoweventMoved,

        /// <summary>
        ///     The sdl windowevent resized sdl windoweventid
        /// </summary>
        SdlWindoweventResized,

        /// <summary>
        ///     The sdl windowevent size changed sdl windoweventid
        /// </summary>
        SdlWindoweventSizeChanged,

        /// <summary>
        ///     The sdl windowevent minimized sdl windoweventid
        /// </summary>
        SdlWindoweventMinimized,

        /// <summary>
        ///     The sdl windowevent maximized sdl windoweventid
        /// </summary>
        SdlWindoweventMaximized,

        /// <summary>
        ///     The sdl windowevent restored sdl windoweventid
        /// </summary>
        SdlWindoweventRestored,

        /// <summary>
        ///     The sdl windowevent enter sdl windoweventid
        /// </summary>
        SdlWindoweventEnter,

        /// <summary>
        ///     The sdl windowevent leave sdl windoweventid
        /// </summary>
        SdlWindoweventLeave,

        /// <summary>
        ///     The sdl windowevent focus gained sdl windoweventid
        /// </summary>
        SdlWindoweventFocusGained,

        /// <summary>
        ///     The sdl windowevent focus lost sdl windoweventid
        /// </summary>
        SdlWindoweventFocusLost,

        /// <summary>
        ///     The sdl windowevent close sdl windoweventid
        /// </summary>
        SdlWindoweventClose,


        /// <summary>
        ///     The sdl windowevent take focus sdl windoweventid
        /// </summary>
        SdlWindoweventTakeFocus,

        /// <summary>
        ///     The sdl windowevent hit test sdl windoweventid
        /// </summary>
        SdlWindoweventHitTest,


        /// <summary>
        ///     The sdl windowevent iccprof changed sdl windoweventid
        /// </summary>
        SdlWindoweventIccprofChanged,

        /// <summary>
        ///     The sdl windowevent display changed sdl windoweventid
        /// </summary>
        SdlWindoweventDisplayChanged
    }
}