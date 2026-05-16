// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InitSettings.cs
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

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl init enum
    /// </summary>
    [Flags]
    public enum InitSettings : uint
    {
    /// <summary>
    ///     Initialize the SDL timer subsystem
    /// </summary>
    InitTimer = 0x00000001,

    /// <summary>
    ///     Initialize the SDL audio subsystem
    /// </summary>
    InitAudio = 0x00000010,

    /// <summary>
    ///     Initialize the SDL video subsystem
    /// </summary>
    InitVideo = 0x00000020,

    /// <summary>
    ///     Initialize the SDL joystick subsystem
    /// </summary>
    InitJoystick = 0x00000200,

    /// <summary>
    ///     Initialize the SDL haptic (force feedback) subsystem
    /// </summary>
    InitHaptic = 0x00001000,

    /// <summary>
    ///     Initialize the SDL game controller subsystem
    /// </summary>
    InitGameController = 0x00002000,

    /// <summary>
    ///     Initialize the SDL events subsystem
    /// </summary>
    InitEvents = 0x00004000,

    /// <summary>
    ///     Initialize the SDL sensor subsystem
    /// </summary>
    InitSensor = 0x00008000,

    /// <summary>
    ///     Initialize all available SDL subsystems at once
    /// </summary>
    InitEverything = InitTimer | InitAudio | InitVideo | InitJoystick | InitHaptic | InitGameController | InitEvents | InitSensor
    }
}