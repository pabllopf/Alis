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
        private byte padding0;
        
        [FieldOffset(0)]
        private byte padding1;
        
        [FieldOffset(0)]
        private byte padding2;
        
        [FieldOffset(0)]
        private byte padding3;
        
        [FieldOffset(0)]
        private byte padding4;
        
        [FieldOffset(0)]
        private byte padding5;
        
        [FieldOffset(0)]
        private byte padding6;
        
        [FieldOffset(0)]
        private byte padding7;
        
        [FieldOffset(0)]
        private byte padding8;
        
        [FieldOffset(0)]
        private byte padding9;
        
        [FieldOffset(0)]
        private byte padding10;
        
        [FieldOffset(0)]
        private byte padding11;
        
        [FieldOffset(0)]
        private byte padding12;
        
        [FieldOffset(0)]
        private byte padding13;
        
        [FieldOffset(0)]
        private byte padding14;
        
        [FieldOffset(0)]
        private byte padding15;
        
        [FieldOffset(0)]
        private byte padding16;
        
        [FieldOffset(0)]
        private byte padding17;
        
        [FieldOffset(0)]
        private byte padding18;
        
        [FieldOffset(0)]
        private byte padding19;
        
        [FieldOffset(0)]
        private byte padding20;
        
        [FieldOffset(0)]
        private byte padding21;
        
        [FieldOffset(0)]
        private byte padding22;
        
        [FieldOffset(0)]
        private byte padding23;
        
        [FieldOffset(0)]
        private byte padding24;
        
        [FieldOffset(0)]
        private byte padding25;
        
        [FieldOffset(0)]
        private byte padding26;
        
        [FieldOffset(0)]
        private byte padding27;
        
        [FieldOffset(0)]
        private byte padding28;
        
        [FieldOffset(0)]
        private byte padding29;
        
        [FieldOffset(0)]
        private byte padding30;
        
        [FieldOffset(0)]
        private byte padding31;
        
        [FieldOffset(0)]
        private byte padding32;
        
        [FieldOffset(0)]
        private byte padding33;
        
        [FieldOffset(0)]
        private byte padding34;
        
        [FieldOffset(0)]
        private byte padding35;
        
        [FieldOffset(0)]
        private byte padding36;
        
        [FieldOffset(0)]
        private byte padding37;
        
        [FieldOffset(0)]
        private byte padding38;
        
        [FieldOffset(0)]
        private byte padding39;
        
        [FieldOffset(0)]
        private byte padding40;
        
        [FieldOffset(0)]
        private byte padding41;
        
        [FieldOffset(0)]
        private byte padding42;
        
        [FieldOffset(0)]
        private byte padding43;
        
        [FieldOffset(0)]
        private byte padding44;
        
        [FieldOffset(0)]
        private byte padding45;
        
        [FieldOffset(0)]
        private byte padding46;
        
        [FieldOffset(0)]
        private byte padding47;
        
        [FieldOffset(0)]
        private byte padding48;
        
        [FieldOffset(0)]
        private byte padding49;
        
        [FieldOffset(0)]
        private byte padding50;
        
        [FieldOffset(0)]
        private byte padding51;
        
        [FieldOffset(0)]
        private byte padding52;
        
        [FieldOffset(0)]
        private byte padding53;
        
        [FieldOffset(0)]
        private byte padding54;
        
        [FieldOffset(0)]
        private byte padding55;

        /// <summary>
        /// Gets or sets the value of the padding
        /// </summary>
        public byte[] padding
        {
            get
            {
                byte[] textBytes = new byte[56]
                {
                    padding0,
                    padding1,
                    padding2,
                    padding3,
                    padding4,
                    padding5,
                    padding6,
                    padding7,
                    padding8,
                    padding9,
                    padding10,
                    padding11,
                    padding12,
                    padding13,
                    padding14,
                    padding15,
                    padding16,
                    padding17,
                    padding18,
                    padding19,
                    padding20,
                    padding21,
                    padding22,
                    padding23,
                    padding24,
                    padding25,
                    padding26,
                    padding27,
                    padding28,
                    padding29,
                    padding30,
                    padding31,
                    padding32,
                    padding33,
                    padding34,
                    padding35,
                    padding36,
                    padding37,
                    padding38,
                    padding39,
                    padding40,
                    padding41,
                    padding42,
                    padding43,
                    padding44,
                    padding45,
                    padding46,
                    padding47,
                    padding48,
                    padding49,
                    padding50,
                    padding51,
                    padding52,
                    padding53,
                    padding54,
                    padding55
                };
                return textBytes;
            }
        }
    }
}