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
using Alis.Core.Graphic.Sdl2.Enums;

namespace Alis.Core.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl event
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct Event
    {
        /// <summary>
        ///     The type
        /// </summary>
        [FieldOffset(0)] public EventType type;
        
        /// <summary>
        ///     The type sharp
        /// </summary>
        [FieldOffset(0)] public EventType typeFSharp;
        
        /// <summary>
        ///     The display
        /// </summary>
        [FieldOffset(0)] public DisplayEvent display;
        
        /// <summary>
        ///     The window
        /// </summary>
        [FieldOffset(0)] public WindowEvent window;
        
        /// <summary>
        ///     The key
        /// </summary>
        [FieldOffset(0)] public KeyboardEvent key;
        
        /// <summary>
        ///     The edit
        /// </summary>
        [FieldOffset(0)] public TextEditingEvent edit;
        
        /// <summary>
        ///     The text
        /// </summary>
        [FieldOffset(0)] public TextInputEvent text;
        
        /// <summary>
        ///     The motion
        /// </summary>
        [FieldOffset(0)] public MouseMotionEvent motion;
        
        /// <summary>
        ///     The button
        /// </summary>
        [FieldOffset(0)] public MouseButtonEvent button;
        
        /// <summary>
        ///     The wheel
        /// </summary>
        [FieldOffset(0)] public MouseWheelEvent wheel;
        
        /// <summary>
        ///     The j axis
        /// </summary>
        [FieldOffset(0)] public JoyAxisEvent jAxis;
        
        /// <summary>
        ///     The j ball
        /// </summary>
        [FieldOffset(0)] public JoyBallEvent jBall;
        
        /// <summary>
        ///     The j hat
        /// </summary>
        [FieldOffset(0)] public JoyHatEvent jHat;
        
        /// <summary>
        ///     The j button
        /// </summary>
        [FieldOffset(0)] public JoyButtonEvent jButton;
        
        /// <summary>
        ///     The j device
        /// </summary>
        [FieldOffset(0)] public JoyDeviceEvent jDevice;
        
        /// <summary>
        ///     The c axis
        /// </summary>
        [FieldOffset(0)] public ControllerAxisEvent cAxis;
        
        /// <summary>
        ///     The c button
        /// </summary>
        [FieldOffset(0)] public ControllerButtonEvent cButton;
        
        /// <summary>
        ///     The c device
        /// </summary>
        [FieldOffset(0)] public ControllerDeviceEvent cDevice;
        
        /// <summary>
        ///     The c touchpad
        /// </summary>
        [FieldOffset(0)] public ControllerTouchpadEvent cTouchpad;
        
        /// <summary>
        ///     The c sensor
        /// </summary>
        [FieldOffset(0)] public ControllerSensorEvent cSensor;
        
        /// <summary>
        ///     The audio device
        /// </summary>
        [FieldOffset(0)] public AudioDeviceEvent aDevice;
        
        /// <summary>
        ///     The sensor
        /// </summary>
        [FieldOffset(0)] public SensorEvent sensor;
        
        /// <summary>
        ///     The quit
        /// </summary>
        [FieldOffset(0)] public QuitEvent quit;
        
        /// <summary>
        ///     The user
        /// </summary>
        [FieldOffset(0)] public UserEvent user;
        
        /// <summary>
        ///     The sys wm
        /// </summary>
        [FieldOffset(0)] public SysWmEvent sysWm;
        
        /// <summary>
        ///     The t finger
        /// </summary>
        [FieldOffset(0)] public TouchFingerEvent tFinger;
        
        /// <summary>
        ///     The m gesture
        /// </summary>
        [FieldOffset(0)] public MultiGestureEvent mGesture;
        
        /// <summary>
        ///     The d gesture
        /// </summary>
        [FieldOffset(0)] public DollarGestureEvent dGesture;
        
        /// <summary>
        ///     The drop
        /// </summary>
        [FieldOffset(0)] public DropEvent drop;
        
        /// <summary>
        ///     The padding
        /// </summary>
        [FieldOffset(0)] private readonly byte padding0;
        
        /// <summary>
        ///     The padding
        /// </summary>
        [FieldOffset(0)] private readonly byte padding1;
        
        /// <summary>
        ///     The padding
        /// </summary>
        [FieldOffset(0)] private readonly byte padding2;
        
        /// <summary>
        ///     The padding
        /// </summary>
        [FieldOffset(0)] private readonly byte padding3;
        
        /// <summary>
        ///     The padding
        /// </summary>
        [FieldOffset(0)] private readonly byte padding4;
        
        /// <summary>
        ///     The padding
        /// </summary>
        [FieldOffset(0)] private readonly byte padding5;
        
        /// <summary>
        ///     The padding
        /// </summary>
        [FieldOffset(0)] private readonly byte padding6;
        
        /// <summary>
        ///     The padding
        /// </summary>
        [FieldOffset(0)] private readonly byte padding7;
        
        /// <summary>
        ///     The padding
        /// </summary>
        [FieldOffset(0)] private readonly byte padding8;
        
        /// <summary>
        ///     The padding
        /// </summary>
        [FieldOffset(0)] private readonly byte padding9;
        
        /// <summary>
        ///     The padding 10
        /// </summary>
        [FieldOffset(0)] private readonly byte padding10;
        
        /// <summary>
        ///     The padding 11
        /// </summary>
        [FieldOffset(0)] private readonly byte padding11;
        
        /// <summary>
        ///     The padding 12
        /// </summary>
        [FieldOffset(0)] private readonly byte padding12;
        
        /// <summary>
        ///     The padding 13
        /// </summary>
        [FieldOffset(0)] private readonly byte padding13;
        
        /// <summary>
        ///     The padding 14
        /// </summary>
        [FieldOffset(0)] private readonly byte padding14;
        
        /// <summary>
        ///     The padding 15
        /// </summary>
        [FieldOffset(0)] private readonly byte padding15;
        
        /// <summary>
        ///     The padding 16
        /// </summary>
        [FieldOffset(0)] private readonly byte padding16;
        
        /// <summary>
        ///     The padding 17
        /// </summary>
        [FieldOffset(0)] private readonly byte padding17;
        
        /// <summary>
        ///     The padding 18
        /// </summary>
        [FieldOffset(0)] private readonly byte padding18;
        
        /// <summary>
        ///     The padding 19
        /// </summary>
        [FieldOffset(0)] private readonly byte padding19;
        
        /// <summary>
        ///     The padding 20
        /// </summary>
        [FieldOffset(0)] private readonly byte padding20;
        
        /// <summary>
        ///     The padding 21
        /// </summary>
        [FieldOffset(0)] private readonly byte padding21;
        
        /// <summary>
        ///     The padding 22
        /// </summary>
        [FieldOffset(0)] private readonly byte padding22;
        
        /// <summary>
        ///     The padding 23
        /// </summary>
        [FieldOffset(0)] private readonly byte padding23;
        
        /// <summary>
        ///     The padding 24
        /// </summary>
        [FieldOffset(0)] private readonly byte padding24;
        
        /// <summary>
        ///     The padding 25
        /// </summary>
        [FieldOffset(0)] private readonly byte padding25;
        
        /// <summary>
        ///     The padding 26
        /// </summary>
        [FieldOffset(0)] private readonly byte padding26;
        
        /// <summary>
        ///     The padding 27
        /// </summary>
        [FieldOffset(0)] private readonly byte padding27;
        
        /// <summary>
        ///     The padding 28
        /// </summary>
        [FieldOffset(0)] private readonly byte padding28;
        
        /// <summary>
        ///     The padding 29
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