// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sdl.SdlEvent.cs
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

using System.Runtime.InteropServices;

namespace Alis.Core.Input.SDL2
{
    /// <summary>
        ///     The sdl event
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public unsafe struct SdlEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            [FieldOffset(0)] public SdlEventType type;

            /// <summary>
            ///     The type sharp
            /// </summary>
            [FieldOffset(0)] public SdlEventType typeFSharp;

            /// <summary>
            ///     The display
            /// </summary>
            [FieldOffset(0)] public SdlDisplayEvent display;

            /// <summary>
            ///     The window
            /// </summary>
            [FieldOffset(0)] public SdlWindowEvent window;

            /// <summary>
            ///     The key
            /// </summary>
            [FieldOffset(0)] public SdlKeyboardEvent key;

            /// <summary>
            ///     The edit
            /// </summary>
            [FieldOffset(0)] public SdlTextEditingEvent edit;

            /// <summary>
            ///     The edit ext
            /// </summary>
            [FieldOffset(0)] public SdlTextEditingExtEvent editExt;

            /// <summary>
            ///     The text
            /// </summary>
            [FieldOffset(0)] public SdlTextInputEvent text;

            /// <summary>
            ///     The motion
            /// </summary>
            [FieldOffset(0)] public SdlMouseMotionEvent motion;

            /// <summary>
            ///     The button
            /// </summary>
            [FieldOffset(0)] public SdlMouseButtonEvent button;

            /// <summary>
            ///     The wheel
            /// </summary>
            [FieldOffset(0)] public SdlMouseWheelEvent wheel;

            /// <summary>
            ///     The jaxis
            /// </summary>
            [FieldOffset(0)] public SdlJoyAxisEvent jaxis;

            /// <summary>
            ///     The jball
            /// </summary>
            [FieldOffset(0)] public SdlJoyBallEvent jball;

            /// <summary>
            ///     The jhat
            /// </summary>
            [FieldOffset(0)] public SdlJoyHatEvent jhat;

            /// <summary>
            ///     The jbutton
            /// </summary>
            [FieldOffset(0)] public SdlJoyButtonEvent jbutton;

            /// <summary>
            ///     The jdevice
            /// </summary>
            [FieldOffset(0)] public SdlJoyDeviceEvent jdevice;

            /// <summary>
            ///     The caxis
            /// </summary>
            [FieldOffset(0)] public SdlControllerAxisEvent caxis;

            /// <summary>
            ///     The cbutton
            /// </summary>
            [FieldOffset(0)] public SdlControllerButtonEvent cbutton;

            /// <summary>
            ///     The cdevice
            /// </summary>
            [FieldOffset(0)] public SdlControllerDeviceEvent cdevice;

            /// <summary>
            ///     The ctouchpad
            /// </summary>
            [FieldOffset(0)] public SdlControllerTouchpadEvent ctouchpad;

            /// <summary>
            ///     The csensor
            /// </summary>
            [FieldOffset(0)] public SdlControllerSensorEvent csensor;

            /// <summary>
            ///     The adevice
            /// </summary>
            [FieldOffset(0)] public SdlAudioDeviceEvent adevice;

            /// <summary>
            ///     The sensor
            /// </summary>
            [FieldOffset(0)] public SdlSensorEvent sensor;

            /// <summary>
            ///     The quit
            /// </summary>
            [FieldOffset(0)] public SdlQuitEvent quit;

            /// <summary>
            ///     The user
            /// </summary>
            [FieldOffset(0)] public SdlUserEvent user;

            /// <summary>
            ///     The syswm
            /// </summary>
            [FieldOffset(0)] public SdlSysWmEvent syswm;

            /// <summary>
            ///     The tfinger
            /// </summary>
            [FieldOffset(0)] public SdlTouchFingerEvent tfinger;

            /// <summary>
            ///     The mgesture
            /// </summary>
            [FieldOffset(0)] public SdlMultiGestureEvent mgesture;

            /// <summary>
            ///     The dgesture
            /// </summary>
            [FieldOffset(0)] public SdlDollarGestureEvent dgesture;

            /// <summary>
            ///     The drop
            /// </summary>
            [FieldOffset(0)] public SdlDropEvent drop;

            /// <summary>
            ///     The padding
            /// </summary>
            [FieldOffset(0)] private fixed byte padding[56];
        }
    }
