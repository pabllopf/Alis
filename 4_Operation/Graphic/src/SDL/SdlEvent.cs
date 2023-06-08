using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl event
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct SdlEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
        [FieldOffset(0)] 
        public SdlEventType type;

        /// <summary>
        ///     The type sharp
        /// </summary>
        [FieldOffset(0)] 
        public SdlEventType typeFSharp;

        /// <summary>
        ///     The display
        /// </summary>
        [FieldOffset(0)] 
        public SdlDisplayEvent display;

        /// <summary>
        ///     The window
        /// </summary>
        [FieldOffset(0)] 
        public SdlWindowEvent window;

        /// <summary>
        ///     The key
        /// </summary>
        [FieldOffset(0)] 
        public SdlKeyboardEvent key;

        /// <summary>
        ///     The edit
        /// </summary>
        [FieldOffset(0)] 
        public SdlTextEditingEvent edit;

        /// <summary>
        ///     The text
        /// </summary>
        [FieldOffset(0)] 
        public SdlTextInputEvent text;

        /// <summary>
        ///     The motion
        /// </summary>
        [FieldOffset(0)] 
        public SdlMouseMotionEvent motion;

        /// <summary>
        ///     The button
        /// </summary>
        [FieldOffset(0)] 
        public SdlMouseButtonEvent button;

        /// <summary>
        ///     The wheel
        /// </summary>
        [FieldOffset(0)] 
        public SdlMouseWheelEvent wheel;

        /// <summary>
        ///     The jaxis
        /// </summary>
        [FieldOffset(0)] 
        public SdlJoyAxisEvent jaxis;

        /// <summary>
        ///     The jball
        /// </summary>
        [FieldOffset(0)] 
        public SdlJoyBallEvent jball;

        /// <summary>
        ///     The jhat
        /// </summary>
        [FieldOffset(0)] 
        public SdlJoyHatEvent jhat;

        /// <summary>
        ///     The jbutton
        /// </summary>
        [FieldOffset(0)]
        public SdlJoyButtonEvent jbutton;

        /// <summary>
        ///     The jdevice
        /// </summary>
        [FieldOffset(0)] 
        public SdlJoyDeviceEvent jdevice;

        /// <summary>
        ///     The caxis
        /// </summary>
        [FieldOffset(0)] 
        public SdlControllerAxisEvent caxis;

        /// <summary>
        ///     The cbutton
        /// </summary>
        [FieldOffset(0)] 
        public SdlControllerButtonEvent cbutton;

        /// <summary>
        ///     The cdevice
        /// </summary>
        [FieldOffset(0)] 
        public SdlControllerDeviceEvent cdevice;

        /// <summary>
        ///     The ctouchpad
        /// </summary>
        [FieldOffset(0)] 
        public SdlControllerTouchpadEvent ctouchpad;

        /// <summary>
        ///     The csensor
        /// </summary>
        [FieldOffset(0)] 
        public SdlControllerSensorEvent csensor;

        /// <summary>
        ///     The adevice
        /// </summary>
        [FieldOffset(0)] 
        public SdlAudioDeviceEvent adevice;

        /// <summary>
        ///     The sensor
        /// </summary>
        [FieldOffset(0)] 
        public SdlSensorEvent sensor;

        /// <summary>
        ///     The quit
        /// </summary>
        [FieldOffset(0)] 
        public SdlQuitEvent quit;

        /// <summary>
        ///     The user
        /// </summary>
        [FieldOffset(0)] 
        public SdlUserEvent user;

        /// <summary>
        ///     The syswm
        /// </summary>
        [FieldOffset(0)] 
        public SdlSysWmEvent syswm;

        /// <summary>
        ///     The tfinger
        /// </summary>
        [FieldOffset(0)] 
        public SdlTouchFingerEvent tfinger;

        /// <summary>
        ///     The mgesture
        /// </summary>
        [FieldOffset(0)] 
        public SdlMultiGestureEvent mgesture;

        /// <summary>
        ///     The dgesture
        /// </summary>
        [FieldOffset(0)] 
        public SdlDollarGestureEvent dgesture;

        /// <summary>
        ///     The drop
        /// </summary>
        [FieldOffset(0)] 
        public SdlDropEvent drop;

        /// <summary>
        ///     The padding
        /// </summary>
        [FieldOffset(0)]
        private IntPtr paddingPtr;

        /// <summary>
        /// Gets or sets the value of the padding
        /// </summary>
        public byte[] padding
        {
            get
            {
                byte[] textBytes = new byte[56];
                Marshal.Copy(paddingPtr, textBytes, 0, 56);
                return textBytes;
            }
            set => Marshal.Copy(value, 0, paddingPtr, 56);
        }
    }
}