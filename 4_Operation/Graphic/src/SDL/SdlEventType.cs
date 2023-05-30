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
    ///     The sdl eventtype enum
    /// </summary>
    public enum SdlEventType : uint
    {
        /// <summary>
        ///     The sdl firstevent sdl eventtype
        /// </summary>
        SdlFirstevent = 0,

        /* Application events */
        /// <summary>
        ///     The sdl quit sdl eventtype
        /// </summary>
        SdlQuit = 0x100,

        /* iOS/Android/WinRT app events */
        /// <summary>
        ///     The sdl app terminating sdl eventtype
        /// </summary>
        SdlAppTerminating,

        /// <summary>
        ///     The sdl app lowmemory sdl eventtype
        /// </summary>
        SdlAppLowmemory,

        /// <summary>
        ///     The sdl app willenterbackground sdl eventtype
        /// </summary>
        SdlAppWillenterbackground,

        /// <summary>
        ///     The sdl app didenterbackground sdl eventtype
        /// </summary>
        SdlAppDidenterbackground,

        /// <summary>
        ///     The sdl app willenterforeground sdl eventtype
        /// </summary>
        SdlAppWillenterforeground,

        /// <summary>
        ///     The sdl app didenterforeground sdl eventtype
        /// </summary>
        SdlAppDidenterforeground,

        /* Only available in SDL 2.0.14 or higher. */
        /// <summary>
        ///     The sdl localechanged sdl eventtype
        /// </summary>
        SdlLocalechanged,

        /* Display events */
        /* Only available in SDL 2.0.9 or higher. */
        /// <summary>
        ///     The sdl displayevent sdl eventtype
        /// </summary>
        SdlDisplayevent = 0x150,

        /* Window events */
        /// <summary>
        ///     The sdl windowevent sdl eventtype
        /// </summary>
        SdlWindowevent = 0x200,

        /// <summary>
        ///     The sdl syswmevent sdl eventtype
        /// </summary>
        SdlSyswmevent,

        /* Keyboard events */
        /// <summary>
        ///     The sdl keydown sdl eventtype
        /// </summary>
        SdlKeydown = 0x300,

        /// <summary>
        ///     The sdl keyup sdl eventtype
        /// </summary>
        SdlKeyup,

        /// <summary>
        ///     The sdl textediting sdl eventtype
        /// </summary>
        SdlTextediting,

        /// <summary>
        ///     The sdl textinput sdl eventtype
        /// </summary>
        SdlTextinput,

        /// <summary>
        ///     The sdl keymapchanged sdl eventtype
        /// </summary>
        SdlKeymapchanged,

        /* Mouse events */
        /// <summary>
        ///     The sdl mousemotion sdl eventtype
        /// </summary>
        SdlMousemotion = 0x400,

        /// <summary>
        ///     The sdl mousebuttondown sdl eventtype
        /// </summary>
        SdlMousebuttondown,

        /// <summary>
        ///     The sdl mousebuttonup sdl eventtype
        /// </summary>
        SdlMousebuttonup,

        /// <summary>
        ///     The sdl mousewheel sdl eventtype
        /// </summary>
        SdlMousewheel,

        /* Joystick events */
        /// <summary>
        ///     The sdl joyaxismotion sdl eventtype
        /// </summary>
        SdlJoyaxismotion = 0x600,

        /// <summary>
        ///     The sdl joyballmotion sdl eventtype
        /// </summary>
        SdlJoyballmotion,

        /// <summary>
        ///     The sdl joyhatmotion sdl eventtype
        /// </summary>
        SdlJoyhatmotion,

        /// <summary>
        ///     The sdl joybuttondown sdl eventtype
        /// </summary>
        SdlJoybuttondown,

        /// <summary>
        ///     The sdl joybuttonup sdl eventtype
        /// </summary>
        SdlJoybuttonup,

        /// <summary>
        ///     The sdl joydeviceadded sdl eventtype
        /// </summary>
        SdlJoydeviceadded,

        /// <summary>
        ///     The sdl joydeviceremoved sdl eventtype
        /// </summary>
        SdlJoydeviceremoved,

        /* Game controller events */
        /// <summary>
        ///     The sdl controlleraxismotion sdl eventtype
        /// </summary>
        SdlControlleraxismotion = 0x650,

        /// <summary>
        ///     The sdl controllerbuttondown sdl eventtype
        /// </summary>
        SdlControllerbuttondown,

        /// <summary>
        ///     The sdl controllerbuttonup sdl eventtype
        /// </summary>
        SdlControllerbuttonup,

        /// <summary>
        ///     The sdl controllerdeviceadded sdl eventtype
        /// </summary>
        SdlControllerdeviceadded,

        /// <summary>
        ///     The sdl controllerdeviceremoved sdl eventtype
        /// </summary>
        SdlControllerdeviceremoved,

        /// <summary>
        ///     The sdl controllerdeviceremapped sdl eventtype
        /// </summary>
        SdlControllerdeviceremapped,

        /// <summary>
        ///     The sdl controllertouchpaddown sdl eventtype
        /// </summary>
        SdlControllertouchpaddown, /* Requires >= 2.0.14 */

        /// <summary>
        ///     The sdl controllertouchpadmotion sdl eventtype
        /// </summary>
        SdlControllertouchpadmotion, /* Requires >= 2.0.14 */

        /// <summary>
        ///     The sdl controllertouchpadup sdl eventtype
        /// </summary>
        SdlControllertouchpadup, /* Requires >= 2.0.14 */

        /// <summary>
        ///     The sdl controllersensorupdate sdl eventtype
        /// </summary>
        SdlControllersensorupdate, /* Requires >= 2.0.14 */

        /* Touch events */
        /// <summary>
        ///     The sdl fingerdown sdl eventtype
        /// </summary>
        SdlFingerdown = 0x700,

        /// <summary>
        ///     The sdl fingerup sdl eventtype
        /// </summary>
        SdlFingerup,

        /// <summary>
        ///     The sdl fingermotion sdl eventtype
        /// </summary>
        SdlFingermotion,

        /* Gesture events */
        /// <summary>
        ///     The sdl dollargesture sdl eventtype
        /// </summary>
        SdlDollargesture = 0x800,

        /// <summary>
        ///     The sdl dollarrecord sdl eventtype
        /// </summary>
        SdlDollarrecord,

        /// <summary>
        ///     The sdl multigesture sdl eventtype
        /// </summary>
        SdlMultigesture,

        /* Clipboard events */
        /// <summary>
        ///     The sdl clipboardupdate sdl eventtype
        /// </summary>
        SdlClipboardupdate = 0x900,

        /* Drag and drop events */
        /// <summary>
        ///     The sdl dropfile sdl eventtype
        /// </summary>
        SdlDropfile = 0x1000,

        /* Only available in 2.0.4 or higher. */
        /// <summary>
        ///     The sdl droptext sdl eventtype
        /// </summary>
        SdlDroptext,

        /// <summary>
        ///     The sdl dropbegin sdl eventtype
        /// </summary>
        SdlDropbegin,

        /// <summary>
        ///     The sdl dropcomplete sdl eventtype
        /// </summary>
        SdlDropcomplete,

        /* Audio hotplug events */
        /* Only available in SDL 2.0.4 or higher. */
        /// <summary>
        ///     The sdl audiodeviceadded sdl eventtype
        /// </summary>
        SdlAudiodeviceadded = 0x1100,

        /// <summary>
        ///     The sdl audiodeviceremoved sdl eventtype
        /// </summary>
        SdlAudiodeviceremoved,

        /* Sensor events */
        /* Only available in SDL 2.0.9 or higher. */
        /// <summary>
        ///     The sdl sensorupdate sdl eventtype
        /// </summary>
        SdlSensorupdate = 0x1200,

        /* Render events */
        /* Only available in SDL 2.0.2 or higher. */
        /// <summary>
        ///     The sdl render targets reset sdl eventtype
        /// </summary>
        SdlRenderTargetsReset = 0x2000,

        /* Only available in SDL 2.0.4 or higher. */
        /// <summary>
        ///     The sdl render device reset sdl eventtype
        /// </summary>
        SdlRenderDeviceReset,

        /* Internal events */
        /* Only available in 2.0.18 or higher. */
        /// <summary>
        ///     The sdl pollsentinel sdl eventtype
        /// </summary>
        SdlPollsentinel = 0x7F00,

        /* Events SDL_USEREVENT through SDL_LASTEVENT are for
             * your use, and should be allocated with
             * SDL_RegisterEvents()
             */
        /// <summary>
        ///     The sdl userevent sdl eventtype
        /// </summary>
        SdlUserevent = 0x8000,

        /* The last event, used for bouding arrays. */
        /// <summary>
        ///     The sdl lastevent sdl eventtype
        /// </summary>
        SdlLastevent = 0xFFFF
    }
}