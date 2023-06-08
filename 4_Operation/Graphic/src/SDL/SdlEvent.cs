using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl event
    /// </summary>
    public struct SdlEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
         public SdlEventType type;

        /// <summary>
        ///     The type sharp
        /// </summary>
         public SdlEventType typeFSharp;

        /// <summary>
        ///     The display
        /// </summary>
         public SdlDisplayEvent display;

        /// <summary>
        ///     The window
        /// </summary>
         public SdlWindowEvent window;

        /// <summary>
        ///     The key
        /// </summary>
         public SdlKeyboardEvent key;

        /// <summary>
        ///     The edit
        /// </summary>
         public SdlTextEditingEvent edit;

        /// <summary>
        ///     The text
        /// </summary>
         public SdlTextInputEvent text;

        /// <summary>
        ///     The motion
        /// </summary>
         public SdlMouseMotionEvent motion;

        /// <summary>
        ///     The button
        /// </summary>
         public SdlMouseButtonEvent button;

        /// <summary>
        ///     The wheel
        /// </summary>
         public SdlMouseWheelEvent wheel;

        /// <summary>
        ///     The jaxis
        /// </summary>
         public SdlJoyAxisEvent jaxis;

        /// <summary>
        ///     The jball
        /// </summary>
         public SdlJoyBallEvent jball;

        /// <summary>
        ///     The jhat
        /// </summary>
         public SdlJoyHatEvent jhat;

        /// <summary>
        ///     The jbutton
        /// </summary>
         public SdlJoyButtonEvent jbutton;

        /// <summary>
        ///     The jdevice
        /// </summary>
         public SdlJoyDeviceEvent jdevice;

        /// <summary>
        ///     The caxis
        /// </summary>
         public SdlControllerAxisEvent caxis;

        /// <summary>
        ///     The cbutton
        /// </summary>
         public SdlControllerButtonEvent cbutton;

        /// <summary>
        ///     The cdevice
        /// </summary>
         public SdlControllerDeviceEvent cdevice;

        /// <summary>
        ///     The ctouchpad
        /// </summary>
         public SdlControllerTouchpadEvent ctouchpad;

        /// <summary>
        ///     The csensor
        /// </summary>
         public SdlControllerSensorEvent csensor;

        /// <summary>
        ///     The adevice
        /// </summary>
         public SdlAudioDeviceEvent adevice;

        /// <summary>
        ///     The sensor
        /// </summary>
         public SdlSensorEvent sensor;

        /// <summary>
        ///     The quit
        /// </summary>
         public SdlQuitEvent quit;

        /// <summary>
        ///     The user
        /// </summary>
         public SdlUserEvent user;

        /// <summary>
        ///     The syswm
        /// </summary>
         public SdlSysWmEvent syswm;

        /// <summary>
        ///     The tfinger
        /// </summary>
         public SdlTouchFingerEvent tfinger;

        /// <summary>
        ///     The mgesture
        /// </summary>
         public SdlMultiGestureEvent mgesture;

        /// <summary>
        ///     The dgesture
        /// </summary>
         public SdlDollarGestureEvent dgesture;

        /// <summary>
        ///     The drop
        /// </summary>
         public SdlDropEvent drop;
    }
}