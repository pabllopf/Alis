// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Event.cs
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
using Alis.Extension.Graphic.Sdl2.Enums;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     An SDL event union that overlays all event types at the same memory offset, providing access to the active event via its type field.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct Event
    {
        /// <summary>
        ///     The event type identifier used to distinguish which event subtype is active.
        /// </summary>
        [FieldOffset(0)] public EventType type;


        /// <summary>
        ///     An alias for the type field, provided for F# compatibility.
        /// </summary>
        [FieldOffset(0)] public EventType typeFSharp;


        /// <summary>
        ///     The display event data, active when type is <see cref="EventType.DisplayEvent"/>.
        /// </summary>
        [FieldOffset(0)] public DisplayEvent display;


        /// <summary>
        ///     The window event data, active when type is <see cref="EventType.WindowEvent"/>.
        /// </summary>
        [FieldOffset(0)] public WindowEvent window;


        /// <summary>
        ///     The keyboard event data, active when type is <see cref="EventType.KeyDown"/> or <see cref="EventType.KeyUp"/>.
        /// </summary>
        [FieldOffset(0)] public KeyboardEvent key;


        /// <summary>
        ///     The text editing (IME composition) event data, active when type is <see cref="EventType.TextEditing"/>.
        /// </summary>
        [FieldOffset(0)] public TextEditingEvent edit;


        /// <summary>
        ///     The text input event data, active when type is <see cref="EventType.TextInput"/>.
        /// </summary>
        [FieldOffset(0)] public TextInputEvent text;


        /// <summary>
        ///     The mouse motion event data, active when type is <see cref="EventType.MouseMotion"/>.
        /// </summary>
        [FieldOffset(0)] public MouseMotionEvent motion;


        /// <summary>
        ///     The mouse button event data, active when type is <see cref="EventType.MouseButtonDown"/> or <see cref="EventType.MouseButtonUp"/>.
        /// </summary>
        [FieldOffset(0)] public MouseButtonEvent button;


        /// <summary>
        ///     The mouse wheel event data, active when type is <see cref="EventType.MouseWheel"/>.
        /// </summary>
        [FieldOffset(0)] public MouseWheelEvent wheel;


        /// <summary>
        ///     The joystick axis event data, active when type is <see cref="EventType.JoyAxisMotion"/>.
        /// </summary>
        [FieldOffset(0)] public JoyAxisEvent jAxis;


        /// <summary>
        ///     The joystick trackball event data, active when type is <see cref="EventType.JoyBallMotion"/>.
        /// </summary>
        [FieldOffset(0)] public JoyBallEvent jBall;


        /// <summary>
        ///     The joystick hat (DPad) event data, active when type is <see cref="EventType.JoyHatMotion"/>.
        /// </summary>
        [FieldOffset(0)] public JoyHatEvent jHat;


        /// <summary>
        ///     The joystick button event data, active when type is <see cref="EventType.JoyButtonDown"/> or <see cref="EventType.JoyButtonUp"/>.
        /// </summary>
        [FieldOffset(0)] public JoyButtonEvent jButton;


        /// <summary>
        ///     The joystick device event data, active when type is <see cref="EventType.JoyDeviceAdded"/> or <see cref="EventType.JoyDeviceRemoved"/>.
        /// </summary>
        [FieldOffset(0)] public JoyDeviceEvent jDevice;


        /// <summary>
        ///     The controller axis event data, active when type is <see cref="EventType.ControllerAxisMotion"/>.
        /// </summary>
        [FieldOffset(0)] public ControllerAxisEvent cAxis;


        /// <summary>
        ///     The controller button event data, active when type is <see cref="EventType.ControllerButtonDown"/> or <see cref="EventType.ControllerButtonUp"/>.
        /// </summary>
        [FieldOffset(0)] public ControllerButtonEvent cButton;


        /// <summary>
        ///     The controller device event data, active when type is <see cref="EventType.ControllerDeviceAdded"/>, <see cref="EventType.ControllerDeviceRemoved"/>, or <see cref="EventType.ControllerDeviceRemapped"/>.
        /// </summary>
        [FieldOffset(0)] public ControllerDeviceEvent cDevice;


        /// <summary>
        ///     The controller touchpad event data, active when type is <see cref="EventType.ControllerTouchpadDown"/>, <see cref="EventType.ControllerTouchpadUp"/>, or <see cref="EventType.ControllerTouchpadMotion"/>.
        /// </summary>
        [FieldOffset(0)] public ControllerTouchpadEvent cTouchpad;


        /// <summary>
        ///     The controller sensor event data, active when type is <see cref="EventType.ControllerSensorUpdate"/>.
        /// </summary>
        [FieldOffset(0)] public ControllerSensorEvent cSensor;


        /// <summary>
        ///     The audio device event data, active when type is <see cref="EventType.AudioDeviceAdded"/> or <see cref="EventType.AudioDeviceRemoved"/>.
        /// </summary>
        [FieldOffset(0)] public AudioDeviceEvent aDevice;


        /// <summary>
        ///     The generic sensor event data, active when type is <see cref="EventType.SensorUpdate"/>.
        /// </summary>
        [FieldOffset(0)] public SensorEvent sensor;


        /// <summary>
        ///     The quit event data, active when type is <see cref="EventType.Quit"/>.
        /// </summary>
        [FieldOffset(0)] public QuitEvent quit;


        /// <summary>
        ///     The user-defined event data, active when type is in the SDL_USEREVENT range.
        /// </summary>
        [FieldOffset(0)] public UserEvent user;


        /// <summary>
        ///     The system window manager event data, active when type is <see cref="EventType.SysWMEvent"/>.
        /// </summary>
        [FieldOffset(0)] public SysWmEvent sysWm;


        /// <summary>
        ///     The touch finger event data, active when type is <see cref="EventType.FingerDown"/>, <see cref="EventType.FingerUp"/>, or <see cref="EventType.FingerMotion"/>.
        /// </summary>
        [FieldOffset(0)] public TouchFingerEvent tFinger;


        /// <summary>
        ///     The multi-finger gesture event data, active when type is <see cref="EventType.MultiGesture"/>.
        /// </summary>
        [FieldOffset(0)] public MultiGestureEvent mGesture;


        /// <summary>
        ///     The dollar gesture event data, active when type is <see cref="EventType.DollarGesture"/> or <see cref="EventType.DollarRecord"/>.
        /// </summary>
        [FieldOffset(0)] public DollarGestureEvent dGesture;


        /// <summary>
        ///     The drag-and-drop event data, active when type is <see cref="EventType.DropFile"/>, <see cref="EventType.DropText"/>, or <see cref="EventType.DropComplete"/>.
        /// </summary>
        [FieldOffset(0)] public DropEvent drop;


        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding0;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding1;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding2;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding3;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding4;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding5;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding6;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding7;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding8;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding9;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding10;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding11;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding12;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding13;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding14;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding15;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding16;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding17;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding18;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding19;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding20;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding21;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding22;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding23;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding24;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding25;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding26;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding27;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding28;

        /// <summary>
        ///     Padding byte used to reach the required event structure size for SDL compatibility.
        /// </summary>
        [FieldOffset(0)] private readonly byte padding29;

        /// <summary>
        ///     The padding 30
        /// </summary>
        [FieldOffset(0)] private readonly byte padding30;

        /// <summary>
        ///     The padding 31
        /// </summary>
        [FieldOffset(0)] private readonly byte padding31;

        /// <summary>
        ///     The padding 32
        /// </summary>
        [FieldOffset(0)] private readonly byte padding32;

        /// <summary>
        ///     The padding 33
        /// </summary>
        [FieldOffset(0)] private readonly byte padding33;

        /// <summary>
        ///     The padding 34
        /// </summary>
        [FieldOffset(0)] private readonly byte padding34;

        /// <summary>
        ///     The padding 35
        /// </summary>
        [FieldOffset(0)] private readonly byte padding35;

        /// <summary>
        ///     The padding 36
        /// </summary>
        [FieldOffset(0)] private readonly byte padding36;

        /// <summary>
        ///     The padding 37
        /// </summary>
        [FieldOffset(0)] private readonly byte padding37;

        /// <summary>
        ///     The padding 38
        /// </summary>
        [FieldOffset(0)] private readonly byte padding38;

        /// <summary>
        ///     The padding 39
        /// </summary>
        [FieldOffset(0)] private readonly byte padding39;

        /// <summary>
        ///     The padding 40
        /// </summary>
        [FieldOffset(0)] private readonly byte padding40;

        /// <summary>
        ///     The padding 41
        /// </summary>
        [FieldOffset(0)] private readonly byte padding41;

        /// <summary>
        ///     The padding 42
        /// </summary>
        [FieldOffset(0)] private readonly byte padding42;

        /// <summary>
        ///     The padding 43
        /// </summary>
        [FieldOffset(0)] private readonly byte padding43;

        /// <summary>
        ///     The padding 44
        /// </summary>
        [FieldOffset(0)] private readonly byte padding44;

        /// <summary>
        ///     The padding 45
        /// </summary>
        [FieldOffset(0)] private readonly byte padding45;

        /// <summary>
        ///     The padding 46
        /// </summary>
        [FieldOffset(0)] private readonly byte padding46;

        /// <summary>
        ///     The padding 47
        /// </summary>
        [FieldOffset(0)] private readonly byte padding47;

        /// <summary>
        ///     The padding 48
        /// </summary>
        [FieldOffset(0)] private readonly byte padding48;

        /// <summary>
        ///     The padding 49
        /// </summary>
        [FieldOffset(0)] private readonly byte padding49;

        /// <summary>
        ///     The padding 50
        /// </summary>
        [FieldOffset(0)] private readonly byte padding50;

        /// <summary>
        ///     The padding 51
        /// </summary>
        [FieldOffset(0)] private readonly byte padding51;

        /// <summary>
        ///     The padding 52
        /// </summary>
        [FieldOffset(0)] private readonly byte padding52;

        /// <summary>
        ///     The padding 53
        /// </summary>
        [FieldOffset(0)] private readonly byte padding53;

        /// <summary>
        ///     The padding 54
        /// </summary>
        [FieldOffset(0)] private readonly byte padding54;

        /// <summary>
        ///     The padding 55
        /// </summary>
        [FieldOffset(0)] private readonly byte padding55;
    }
}