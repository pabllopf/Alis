// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameControllerType.cs
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

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl game controller type enum
    /// </summary>
    public enum GameControllerType
    {
        /// <summary>
        ///     The sdl controller type unknown sdl game controller type
        /// </summary>
        ControllerTypeUnknown = 0,

        /// <summary>
        ///     The sdl controller type xbox360 sdl game controller type
        /// </summary>
        ControllerTypeXbox360,

        /// <summary>
        ///     The sdl controller type xbox one sdl game controller type
        /// </summary>
        ControllerTypeXboxOne,

        /// <summary>
        ///     The sdl controller type ps3 sdl game controller type
        /// </summary>
        ControllerTypePs3,

        /// <summary>
        ///     The sdl controller type ps4 sdl game controller type
        /// </summary>
        ControllerTypePs4,

        /// <summary>
        ///     The sdl controller type nintendo switch pro sdl game controller type
        /// </summary>
        ControllerTypeNintendoSwitchPro,

        /// <summary>
        ///     The sdl controller type virtual sdl game controller type
        /// </summary>
        ControllerTypeVirtual,

        /// <summary>
        ///     The sdl controller type ps5 sdl game controller type
        /// </summary>
        ControllerTypePs5,

        /// <summary>
        ///     The sdl controller type amazon luna sdl game controller type
        /// </summary>
        ControllerTypeAmazonLuna,

        /// <summary>
        ///     The sdl controller type google stadia sdl game controller type
        /// </summary>
        ControllerTypeGoogleStadia
    }
}