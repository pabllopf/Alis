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

namespace Alis.Core.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl event type enum
    /// </summary>
    public enum EventType : uint
    {
        /// <summary>
        ///     The sdl first event sdl event type
        /// </summary>
        FirstEvent = 0,
        
        /// <summary>
        ///     The sdl quit sdl event type
        /// </summary>
        Quit = 0x100,
        
        /// <summary>
        ///     The sdl app terminating sdl event type
        /// </summary>
        AppTerminating,
        
        /// <summary>
        ///     The sdl app low memory sdl event type
        /// </summary>
        AppLowMemory,
        
        /// <summary>
        ///     The sdl app will enter background sdl event type
        /// </summary>
        AppWillEnterBackground,
        
        /// <summary>
        ///     The sdl app did enter background sdl event type
        /// </summary>
        AppDidEnterBackground,
        
        /// <summary>
        ///     The sdl app will enter foreground sdl event type
        /// </summary>
        AppWillEnterForeground,
        
        /// <summary>
        ///     The sdl app did enter foreground sdl event type
        /// </summary>
        AppDidEnterForeground,
        
        /// <summary>
        ///     The sdl locale changed sdl event type
        /// </summary>
        LocaleChanged,
        
        /// <summary>
        ///     The sdl display event sdl event type
        /// </summary>
        DisplayEvent = 0x150,
        
        /// <summary>
        ///     The sdl window event sdl event type
        /// </summary>
        WindowEvent = 0x200,
        
        /// <summary>
        ///     The sdl sys wm event sdl event type
        /// </summary>
        SysWmEvent,
        
        /// <summary>
        ///     The sdl keydown sdl event type
        /// </summary>
        Keydown = 0x300,
        
        /// <summary>
        ///     The sdl keyup sdl event type
        /// </summary>
        Keyup,
        
        /// <summary>
        ///     The sdl text editing sdl event type
        /// </summary>
        TextEditing,
        
        /// <summary>
        ///     The sdl text input sdl event type
        /// </summary>
        TextInput,
        
        /// <summary>
        ///     The sdl keymap changed sdl event type
        /// </summary>
        KeymapChanged,
        
        /// <summary>
        ///     The sdl mouse motion sdl event type
        /// </summary>
        MouseMotion = 0x400,
        
        /// <summary>
        ///     The sdl mouse button down sdl event type
        /// </summary>
        MouseButtonDown,
        
        /// <summary>
        ///     The sdl mouse button up sdl event type
        /// </summary>
        MouseButtonUp,
        
        /// <summary>
        ///     The sdl mousewheel sdl event type
        /// </summary>
        Mousewheel,
        
        /// <summary>
        ///     The sdl joy axis motion sdl event type
        /// </summary>
        JoyAxisMotion = 0x600,
        
        /// <summary>
        ///     The sdl joy ball motion sdl event type
        /// </summary>
        JoyBallMotion,
        
        /// <summary>
        ///     The sdl joy hat motion sdl event type
        /// </summary>
        JoyHatMotion,
        
        /// <summary>
        ///     The sdl joy button down sdl event type
        /// </summary>
        JoyButtonDown,
        
        /// <summary>
        ///     The sdl joy button up sdl event type
        /// </summary>
        JoyButtonUp,
        
        /// <summary>
        ///     The sdl joy device added sdl event type
        /// </summary>
        JoyDeviceAdded,
        
        /// <summary>
        ///     The sdl joy device removed sdl event type
        /// </summary>
        JoyDeviceRemoved,
        
        /// <summary>
        ///     The sdl controller axis motion sdl event type
        /// </summary>
        ControllerAxisMotion = 0x650,
        
        /// <summary>
        ///     The sdl controller button down sdl event type
        /// </summary>
        ControllerButtonDown,
        
        /// <summary>
        ///     The sdl controller button up sdl event type
        /// </summary>
        ControllerButtonUp,
        
        /// <summary>
        ///     The sdl controller device added sdl event type
        /// </summary>
        ControllerDeviceAdded,
        
        /// <summary>
        ///     The sdl controller device removed sdl event type
        /// </summary>
        ControllerDeviceRemoved,
        
        /// <summary>
        ///     The sdl controller device remapped sdl event type
        /// </summary>
        ControllerDeviceRemapped,
        
        /// <summary>
        ///     The sdl controller touchpad down sdl event type
        /// </summary>
        ControllerTouchpadDown,
        
        /// <summary>
        ///     The sdl controller touchpad motion sdl event type
        /// </summary>
        ControllerTouchpadMotion,
        
        /// <summary>
        ///     The sdl controller touchpad up sdl event type
        /// </summary>
        ControllerTouchpadUp,
        
        /// <summary>
        ///     The sdl controller sensor update sdl event type
        /// </summary>
        ControllerSensorUpdate,
        
        /// <summary>
        ///     The sdl finger down sdl event type
        /// </summary>
        FingerDown = 0x700,
        
        /// <summary>
        ///     The sdl finger up sdl event type
        /// </summary>
        FingerUp,
        
        /// <summary>
        ///     The sdl finger motion sdl event type
        /// </summary>
        FingerMotion,
        
        /// <summary>
        ///     The sdl dollar gesture sdl event type
        /// </summary>
        DollarGesture = 0x800,
        
        /// <summary>
        ///     The sdl dollar record sdl event type
        /// </summary>
        DollarRecord,
        
        /// <summary>
        ///     The sdl multi gesture sdl event type
        /// </summary>
        MultiGesture,
        
        /// <summary>
        ///     The sdl clip board update sdl event type
        /// </summary>
        ClipBoardUpdate = 0x900,
        
        /// <summary>
        ///     The sdl drop file sdl event type
        /// </summary>
        DropFile = 0x1000,
        
        /// <summary>
        ///     The sdl drop text sdl event type
        /// </summary>
        DropText,
        
        /// <summary>
        ///     The sdl drop begin sdl event type
        /// </summary>
        DropBegin,
        
        /// <summary>
        ///     The sdl drop complete sdl event type
        /// </summary>
        DropComplete,
        
        /// <summary>
        ///     The sdl audio device added sdl event type
        /// </summary>
        AudioDeviceAdded = 0x1100,
        
        /// <summary>
        ///     The sdl audio device removed sdl event type
        /// </summary>
        AudioDeviceRemoved,
        
        /// <summary>
        ///     The sdl sensor update sdl event type
        /// </summary>
        SensorUpdate = 0x1200,
        
        /// <summary>
        ///     The sdl render targets reset sdl event type
        /// </summary>
        RenderTargetsReset = 0x2000,
        
        /// <summary>
        ///     The sdl render device reset sdl event type
        /// </summary>
        RenderDeviceReset,
        
        /// <summary>
        ///     The sdl poll sentinel sdl event type
        /// </summary>
        PollSentinel = 0x7F00,
        
        /// <summary>
        ///     The sdl user event sdl event type
        /// </summary>
        UserEvent = 0x8000,
        
        /// <summary>
        ///     The sdl last event sdl event type
        /// </summary>
        LastEvent = 0xFFFF
    }
}