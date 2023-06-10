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
        
        /// <summary>
        /// The padding
        /// </summary>
        [FieldOffset(0)]
        private byte padding1;
        
        /// <summary>
        /// The padding
        /// </summary>
        [FieldOffset(0)]
        private byte padding2;
        
        /// <summary>
        /// The padding
        /// </summary>
        [FieldOffset(0)]
        private byte padding3;
        
        /// <summary>
        /// The padding
        /// </summary>
        [FieldOffset(0)]
        private byte padding4;
        
        /// <summary>
        /// The padding
        /// </summary>
        [FieldOffset(0)]
        private byte padding5;
        
        /// <summary>
        /// The padding
        /// </summary>
        [FieldOffset(0)]
        private byte padding6;
        
        /// <summary>
        /// The padding
        /// </summary>
        [FieldOffset(0)]
        private byte padding7;
        
        /// <summary>
        /// The padding
        /// </summary>
        [FieldOffset(0)]
        private byte padding8;
        
        /// <summary>
        /// The padding
        /// </summary>
        [FieldOffset(0)]
        private byte padding9;
        
        /// <summary>
        /// The padding 10
        /// </summary>
        [FieldOffset(0)]
        private byte padding10;
        
        /// <summary>
        /// The padding 11
        /// </summary>
        [FieldOffset(0)]
        private byte padding11;
        
        /// <summary>
        /// The padding 12
        /// </summary>
        [FieldOffset(0)]
        private byte padding12;
        
        /// <summary>
        /// The padding 13
        /// </summary>
        [FieldOffset(0)]
        private byte padding13;
        
        /// <summary>
        /// The padding 14
        /// </summary>
        [FieldOffset(0)]
        private byte padding14;
        
        /// <summary>
        /// The padding 15
        /// </summary>
        [FieldOffset(0)]
        private byte padding15;
        
        /// <summary>
        /// The padding 16
        /// </summary>
        [FieldOffset(0)]
        private byte padding16;
        
        /// <summary>
        /// The padding 17
        /// </summary>
        [FieldOffset(0)]
        private byte padding17;
        
        /// <summary>
        /// The padding 18
        /// </summary>
        [FieldOffset(0)]
        private byte padding18;
        
        /// <summary>
        /// The padding 19
        /// </summary>
        [FieldOffset(0)]
        private byte padding19;
        
        /// <summary>
        /// The padding 20
        /// </summary>
        [FieldOffset(0)]
        private byte padding20;
        
        /// <summary>
        /// The padding 21
        /// </summary>
        [FieldOffset(0)]
        private byte padding21;
        
        /// <summary>
        /// The padding 22
        /// </summary>
        [FieldOffset(0)]
        private byte padding22;
        
        /// <summary>
        /// The padding 23
        /// </summary>
        [FieldOffset(0)]
        private byte padding23;
        
        /// <summary>
        /// The padding 24
        /// </summary>
        [FieldOffset(0)]
        private byte padding24;
        
        /// <summary>
        /// The padding 25
        /// </summary>
        [FieldOffset(0)]
        private byte padding25;
        
        /// <summary>
        /// The padding 26
        /// </summary>
        [FieldOffset(0)]
        private byte padding26;
        
        /// <summary>
        /// The padding 27
        /// </summary>
        [FieldOffset(0)]
        private byte padding27;
        
        /// <summary>
        /// The padding 28
        /// </summary>
        [FieldOffset(0)]
        private byte padding28;
        
        /// <summary>
        /// The padding 29
        /// </summary>
        [FieldOffset(0)]
        private byte padding29;
        
        /// <summary>
        /// The padding 30
        /// </summary>
        [FieldOffset(0)]
        private byte padding30;
        
        /// <summary>
        /// The padding 31
        /// </summary>
        [FieldOffset(0)]
        private byte padding31;
        
        /// <summary>
        /// The padding 32
        /// </summary>
        [FieldOffset(0)]
        private byte padding32;
        
        /// <summary>
        /// The padding 33
        /// </summary>
        [FieldOffset(0)]
        private byte padding33;
        
        /// <summary>
        /// The padding 34
        /// </summary>
        [FieldOffset(0)]
        private byte padding34;
        
        /// <summary>
        /// The padding 35
        /// </summary>
        [FieldOffset(0)]
        private byte padding35;
        
        /// <summary>
        /// The padding 36
        /// </summary>
        [FieldOffset(0)]
        private byte padding36;
        
        /// <summary>
        /// The padding 37
        /// </summary>
        [FieldOffset(0)]
        private byte padding37;
        
        /// <summary>
        /// The padding 38
        /// </summary>
        [FieldOffset(0)]
        private byte padding38;
        
        /// <summary>
        /// The padding 39
        /// </summary>
        [FieldOffset(0)]
        private byte padding39;
        
        /// <summary>
        /// The padding 40
        /// </summary>
        [FieldOffset(0)]
        private byte padding40;
        
        /// <summary>
        /// The padding 41
        /// </summary>
        [FieldOffset(0)]
        private byte padding41;
        
        /// <summary>
        /// The padding 42
        /// </summary>
        [FieldOffset(0)]
        private byte padding42;
        
        /// <summary>
        /// The padding 43
        /// </summary>
        [FieldOffset(0)]
        private byte padding43;
        
        /// <summary>
        /// The padding 44
        /// </summary>
        [FieldOffset(0)]
        private byte padding44;
        
        /// <summary>
        /// The padding 45
        /// </summary>
        [FieldOffset(0)]
        private byte padding45;
        
        /// <summary>
        /// The padding 46
        /// </summary>
        [FieldOffset(0)]
        private byte padding46;
        
        /// <summary>
        /// The padding 47
        /// </summary>
        [FieldOffset(0)]
        private byte padding47;
        
        /// <summary>
        /// The padding 48
        /// </summary>
        [FieldOffset(0)]
        private byte padding48;
        
        /// <summary>
        /// The padding 49
        /// </summary>
        [FieldOffset(0)]
        private byte padding49;
        
        /// <summary>
        /// The padding 50
        /// </summary>
        [FieldOffset(0)]
        private byte padding50;
        
        /// <summary>
        /// The padding 51
        /// </summary>
        [FieldOffset(0)]
        private byte padding51;
        
        /// <summary>
        /// The padding 52
        /// </summary>
        [FieldOffset(0)]
        private byte padding52;
        
        /// <summary>
        /// The padding 53
        /// </summary>
        [FieldOffset(0)]
        private byte padding53;
        
        /// <summary>
        /// The padding 54
        /// </summary>
        [FieldOffset(0)]
        private byte padding54;
        
        /// <summary>
        /// The padding 55
        /// </summary>
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