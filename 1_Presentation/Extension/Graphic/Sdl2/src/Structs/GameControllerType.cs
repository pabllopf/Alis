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
    ///     Defines the known types of game controllers recognized by SDL.
    /// </summary>
    public enum GameControllerType
    {
        /// <summary>
        ///     An unknown or unrecognized controller type.
        /// </summary>
        ControllerTypeUnknown = 0,

        /// <summary>
        ///     Microsoft Xbox 360 controller.
        /// </summary>
        ControllerTypeXbox360,

        /// <summary>
        ///     Microsoft Xbox One controller.
        /// </summary>
        ControllerTypeXboxOne,

        /// <summary>
        ///     Sony PlayStation 3 controller.
        /// </summary>
        ControllerTypePs3,

        /// <summary>
        ///     Sony PlayStation 4 controller (DualShock 4).
        /// </summary>
        ControllerTypePs4,

        /// <summary>
        ///     Nintendo Switch Pro controller.
        /// </summary>
        ControllerTypeNintendoSwitchPro,

        /// <summary>
        ///     A virtual controller, typically created programmatically.
        /// </summary>
        ControllerTypeVirtual,

        /// <summary>
        ///     Sony PlayStation 5 controller (DualSense).
        /// </summary>
        ControllerTypePs5,

        /// <summary>
        ///     Amazon Luna controller.
        /// </summary>
        ControllerTypeAmazonLuna,

        /// <summary>
        ///     Google Stadia controller.
        /// </summary>
        ControllerTypeGoogleStadia
    }
}