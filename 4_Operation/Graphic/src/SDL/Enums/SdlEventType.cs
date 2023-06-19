// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlEventType.cs
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

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl event type enum
    /// </summary>
    public enum SdlEventType : uint
    {
        /// <summary>
        ///     The sdl first event sdl event type
        /// </summary>
        SdlFirstEvent = 0,
        
        /// <summary>
        ///     The sdl quit sdl event type
        /// </summary>
        SdlQuit = 0x100,
        
        /// <summary>
        ///     The sdl app terminating sdl event type
        /// </summary>
        SdlAppTerminating,

        /// <summary>
        ///     The sdl app low memory sdl event type
        /// </summary>
        SdlAppLowMemory,

        /// <summary>
        ///     The sdl app will enter background sdl event type
        /// </summary>
        SdlAppWillEnterBackground,

        /// <summary>
        ///     The sdl app did enter background sdl event type
        /// </summary>
        SdlAppDidEnterBackground,

        /// <summary>
        ///     The sdl app will enter foreground sdl event type
        /// </summary>
        SdlAppWillEnterForeground,

        /// <summary>
        ///     The sdl app did enter foreground sdl event type
        /// </summary>
        SdlAppDidEnterForeground,

        /// <summary>
        ///     The sdl locale changed sdl event type
        /// </summary>
        SdlLocaleChanged,
        
        /// <summary>
        ///     The sdl display event sdl event type
        /// </summary>
        SdlDisplayEvent = 0x150,
        
        /// <summary>
        ///     The sdl window event sdl event type
        /// </summary>
        SdlWindowEvent = 0x200,

        /// <summary>
        ///     The sdl sys wm event sdl event type
        /// </summary>
        SdlSysWmEvent,
        
        /// <summary>
        ///     The sdl keydown sdl event type
        /// </summary>
        SdlKeydown = 0x300,

        /// <summary>
        ///     The sdl keyup sdl event type
        /// </summary>
        SdlKeyup,

        /// <summary>
        ///     The sdl text editing sdl event type
        /// </summary>
        SdlTextEditing,

        /// <summary>
        ///     The sdl text input sdl event type
        /// </summary>
        SdlTextInput,

        /// <summary>
        ///     The sdl keymap changed sdl event type
        /// </summary>
        SdlKeymapChanged,
        
        /// <summary>
        ///     The sdl mouse motion sdl event type
        /// </summary>
        SdlMouseMotion = 0x400,

        /// <summary>
        ///     The sdl mouse button down sdl event type
        /// </summary>
        SdlMouseButtonDown,

        /// <summary>
        ///     The sdl mouse button up sdl event type
        /// </summary>
        SdlMouseButtonUp,

        /// <summary>
        ///     The sdl mousewheel sdl event type
        /// </summary>
        SdlMousewheel,
        
        /// <summary>
        ///     The sdl joy axis motion sdl event type
        /// </summary>
        SdlJoyAxisMotion = 0x600,

        /// <summary>
        ///     The sdl joy ball motion sdl event type
        /// </summary>
        SdlJoyBallMotion,

        /// <summary>
        ///     The sdl joy hat motion sdl event type
        /// </summary>
        SdlJoyHatMotion,

        /// <summary>
        ///     The sdl joy button down sdl event type
        /// </summary>
        SdlJoyButtonDown,

        /// <summary>
        ///     The sdl joy button up sdl event type
        /// </summary>
        SdlJoyButtonUp,

        /// <summary>
        ///     The sdl joy device added sdl event type
        /// </summary>
        SdlJoyDeviceAdded,

        /// <summary>
        ///     The sdl joy device removed sdl event type
        /// </summary>
        SdlJoyDeviceRemoved,
        
        /// <summary>
        ///     The sdl controller axis motion sdl event type
        /// </summary>
        SdlControllerAxisMotion = 0x650,

        /// <summary>
        ///     The sdl controller button down sdl event type
        /// </summary>
        SdlControllerButtonDown,

        /// <summary>
        ///     The sdl controller button up sdl event type
        /// </summary>
        SdlControllerButtonUp,

        /// <summary>
        ///     The sdl controller device added sdl event type
        /// </summary>
        SdlControllerDeviceAdded,

        /// <summary>
        ///     The sdl controller device removed sdl event type
        /// </summary>
        SdlControllerDeviceRemoved,

        /// <summary>
        ///     The sdl controller device remapped sdl event type
        /// </summary>
        SdlControllerDeviceRemapped,

        /// <summary>
        ///     The sdl controller touchpad down sdl event type
        /// </summary>
        SdlControllerTouchpadDown, 

        /// <summary>
        ///     The sdl controller touchpad motion sdl event type
        /// </summary>
        SdlControllerTouchpadMotion, 

        /// <summary>
        ///     The sdl controller touchpad up sdl event type
        /// </summary>
        SdlControllerTouchpadUp, 

        /// <summary>
        ///     The sdl controller sensor update sdl event type
        /// </summary>
        SdlControllerSensorUpdate, 
        
        /// <summary>
        ///     The sdl finger down sdl event type
        /// </summary>
        SdlFingerDown = 0x700,

        /// <summary>
        ///     The sdl finger up sdl event type
        /// </summary>
        SdlFingerUp,

        /// <summary>
        ///     The sdl finger motion sdl event type
        /// </summary>
        SdlFingerMotion,

        /// <summary>
        ///     The sdl dollar gesture sdl event type
        /// </summary>
        SdlDollarGesture = 0x800,

        /// <summary>
        ///     The sdl dollar record sdl event type
        /// </summary>
        SdlDollarRecord,

        /// <summary>
        ///     The sdl multi gesture sdl event type
        /// </summary>
        SdlMultiGesture,

        /// <summary>
        ///     The sdl clip board update sdl event type
        /// </summary>
        SdlClipBoardUpdate = 0x900,
        
        /// <summary>
        ///     The sdl drop file sdl event type
        /// </summary>
        SdlDropFile = 0x1000,
        
        /// <summary>
        ///     The sdl drop text sdl event type
        /// </summary>
        SdlDropText,

        /// <summary>
        ///     The sdl drop begin sdl event type
        /// </summary>
        SdlDropBegin,

        /// <summary>
        ///     The sdl drop complete sdl event type
        /// </summary>
        SdlDropComplete,
        
        /// <summary>
        ///     The sdl audio device added sdl event type
        /// </summary>
        SdlAudioDeviceAdded = 0x1100,

        /// <summary>
        ///     The sdl audio device removed sdl event type
        /// </summary>
        SdlAudioDeviceRemoved,
        
        /// <summary>
        ///     The sdl sensor update sdl event type
        /// </summary>
        SdlSensorUpdate = 0x1200,
        
        /// <summary>
        ///     The sdl render targets reset sdl event type
        /// </summary>
        SdlRenderTargetsReset = 0x2000,
        
        /// <summary>
        ///     The sdl render device reset sdl event type
        /// </summary>
        SdlRenderDeviceReset,
        
        /// <summary>
        ///     The sdl poll sentinel sdl event type
        /// </summary>
        SdlPollSentinel = 0x7F00,
        
        /// <summary>
        ///     The sdl user event sdl event type
        /// </summary>
        SdlUserEvent = 0x8000,
        
        /// <summary>
        ///     The sdl last event sdl event type
        /// </summary>
        SdlLastEvent = 0xFFFF
    }
}