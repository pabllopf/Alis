// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameControllerBindType.cs
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
    ///     The sdl game controller bind type enum
    /// </summary>
    public enum GameControllerBindType
    {
    /// <summary>
    ///     No binding is defined
    /// </summary>
    SdlControllerBindTypeNone,

    /// <summary>
    ///     Binding maps to a button on the controller
    /// </summary>
    SdlControllerBindTypeButton,

    /// <summary>
    ///     Binding maps to an axis on the controller
    /// </summary>
    SdlControllerBindTypeAxis,

    /// <summary>
    ///     Binding maps to a hat (directional pad) position on the controller
    /// </summary>
    SdlControllerBindTypeHat
    }
}