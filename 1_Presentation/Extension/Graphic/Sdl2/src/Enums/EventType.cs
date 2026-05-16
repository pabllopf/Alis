// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventType.cs
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
    ///     The sdl event type enum
    /// </summary>
    public enum EventType : uint
    {
    /// <summary>
    ///     Unused and unclassified event type marker (value is 0)
    /// </summary>
    FirstEvent = 0,

    /// <summary>
    ///     User requested the application to quit
    /// </summary>
    Quit = 0x100,

    /// <summary>
    ///     The application is being terminated by the OS
    /// </summary>
    AppTerminating,

    /// <summary>
    ///     The application is running low on memory
    /// </summary>
    AppLowMemory,

    /// <summary>
    ///     The application will enter the background
    /// </summary>
    AppWillEnterBackground,

    /// <summary>
    ///     The application has entered the background
    /// </summary>
    AppDidEnterBackground,

    /// <summary>
    ///     The application will enter the foreground
    /// </summary>
    AppWillEnterForeground,

    /// <summary>
    ///     The application has entered the foreground
    /// </summary>
    AppDidEnterForeground,

    /// <summary>
    ///     The system locale has changed
    /// </summary>
    LocaleChanged,

    /// <summary>
    ///     A display-related event has occurred
    /// </summary>
    DisplayEvent = 0x150,

    /// <summary>
    ///     A window-related event has occurred
    /// </summary>
    WindowEvent = 0x200,

    /// <summary>
    ///     A system-specific window manager event has occurred
    /// </summary>
    SysWmEvent,

    /// <summary>
    ///     A keyboard key was pressed
    /// </summary>
    Keydown = 0x300,

    /// <summary>
    ///     A keyboard key was released
    /// </summary>
    Keyup,

    /// <summary>
    ///     Keyboard text editing composition is in progress
    /// </summary>
    TextEditing,

    /// <summary>
    ///     Keyboard text input has been entered
    /// </summary>
    TextInput,

    /// <summary>
    ///     The keyboard layout or key mapping has changed
    /// </summary>
    KeymapChanged,

    /// <summary>
    ///     The mouse was moved
    /// </summary>
    MouseMotion = 0x400,

    /// <summary>
    ///     A mouse button was pressed
    /// </summary>
    MouseButtonDown,

    /// <summary>
    ///     A mouse button was released
    /// </summary>
    MouseButtonUp,

    /// <summary>
    ///     The mouse wheel was scrolled
    /// </summary>
    Mousewheel,

    /// <summary>
    ///     A joystick axis changed position
    /// </summary>
    JoyAxisMotion = 0x600,

    /// <summary>
    ///     A joystick trackball was moved
    /// </summary>
    JoyBallMotion,

    /// <summary>
    ///     A joystick hat position changed
    /// </summary>
    JoyHatMotion,

    /// <summary>
    ///     A joystick button was pressed
    /// </summary>
    JoyButtonDown,

    /// <summary>
    ///     A joystick button was released
    /// </summary>
    JoyButtonUp,

    /// <summary>
    ///     A joystick device was connected
    /// </summary>
    JoyDeviceAdded,

    /// <summary>
    ///     A joystick device was disconnected
    /// </summary>
    JoyDeviceRemoved,

    /// <summary>
    ///     A game controller axis changed position
    /// </summary>
    ControllerAxisMotion = 0x650,

    /// <summary>
    ///     A game controller button was pressed
    /// </summary>
    ControllerButtonDown,

    /// <summary>
    ///     A game controller button was released
    /// </summary>
    ControllerButtonUp,

    /// <summary>
    ///     A game controller device was connected
    /// </summary>
    ControllerDeviceAdded,

    /// <summary>
    ///     A game controller device was disconnected
    /// </summary>
    ControllerDeviceRemoved,

    /// <summary>
    ///     A game controller device mapping was updated
    /// </summary>
    ControllerDeviceRemapped,

    /// <summary>
    ///     A touchpad press occurred on a game controller
    /// </summary>
    ControllerTouchpadDown,

    /// <summary>
    ///     A touchpad motion occurred on a game controller
    /// </summary>
    ControllerTouchpadMotion,

    /// <summary>
    ///     A touchpad release occurred on a game controller
    /// </summary>
    ControllerTouchpadUp,

    /// <summary>
    ///     A game controller sensor was updated
    /// </summary>
    ControllerSensorUpdate,

    /// <summary>
    ///     A finger touched the touchscreen
    /// </summary>
    FingerDown = 0x700,

    /// <summary>
    ///     A finger lifted from the touchscreen
    /// </summary>
    FingerUp,

    /// <summary>
    ///     A finger moved across the touchscreen
    /// </summary>
    FingerMotion,

    /// <summary>
    ///     A dollar gesture was detected
    /// </summary>
    DollarGesture = 0x800,

    /// <summary>
    ///     A dollar gesture recording is complete
    /// </summary>
    DollarRecord,

    /// <summary>
    ///     A multi-finger gesture was detected
    /// </summary>
    MultiGesture,

    /// <summary>
    ///     The system clipboard content was updated
    /// </summary>
    ClipBoardUpdate = 0x900,

    /// <summary>
    ///     A file was dropped onto the application window
    /// </summary>
    DropFile = 0x1000,

    /// <summary>
    ///     Text was dropped onto the application window
    /// </summary>
    DropText,

    /// <summary>
    ///     A drag-and-drop operation has begun
    /// </summary>
    DropBegin,

    /// <summary>
    ///     A drag-and-drop operation has completed
    /// </summary>
    DropComplete,

    /// <summary>
    ///     An audio device was connected
    /// </summary>
    AudioDeviceAdded = 0x1100,

    /// <summary>
    ///     An audio device was disconnected
    /// </summary>
    AudioDeviceRemoved,

    /// <summary>
    ///     A sensor state was updated
    /// </summary>
    SensorUpdate = 0x1200,

    /// <summary>
    ///     The render targets have been reset and need re-creation
    /// </summary>
    RenderTargetsReset = 0x2000,

    /// <summary>
    ///     The rendering device has been reset and needs re-creation
    /// </summary>
    RenderDeviceReset,

    /// <summary>
    ///     Internal sentinel used to signal the end of polling
    /// </summary>
    PollSentinel = 0x7F00,

    /// <summary>
    ///     Custom user-defined event (range starts here)
    /// </summary>
    UserEvent = 0x8000,

    /// <summary>
    ///     Last valid event type in the enumeration (value is 0xFFFF)
    /// </summary>
    LastEvent = 0xFFFF
    }
}