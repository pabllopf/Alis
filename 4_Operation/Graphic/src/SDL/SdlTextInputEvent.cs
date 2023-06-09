using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl textinputevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlTextInputEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
        public SdlEventType type;

        /// <summary>
        ///     The timestamp
        /// </summary>
        public uint timestamp;

        /// <summary>
        ///     The window id
        /// </summary>
        public uint windowID;
        
        /// <summary>
        /// The byte
        /// </summary>
        private byte byte0;
        
        /// <summary>
        /// The byte
        /// </summary>
        private byte byte1;
        
        /// <summary>
        /// The byte
        /// </summary>
        private byte byte2;
        
        /// <summary>
        /// The byte
        /// </summary>
        private byte byte3;

        /// <summary>
        /// The byte
        /// </summary>
        private byte byte4;
        
        /// <summary>
        /// The byte
        /// </summary>
        private byte byte5;
        
        /// <summary>
        /// The byte
        /// </summary>
        private byte byte6;
        
        /// <summary>
        /// The byte
        /// </summary>
        private byte byte7;
        
        /// <summary>
        /// The byte
        /// </summary>
        private byte byte8;
        
        /// <summary>
        /// The byte
        /// </summary>
        private byte byte9;
        
        /// <summary>
        /// The byte 10
        /// </summary>
        private byte byte10;
        
        /// <summary>
        /// The byte 11
        /// </summary>
        private byte byte11;
        
        /// <summary>
        /// The byte 12
        /// </summary>
        private byte byte12;
        
        /// <summary>
        /// The byte 13
        /// </summary>
        private byte byte13;
        
        /// <summary>
        /// The byte 14
        /// </summary>
        private byte byte14;
        
        /// <summary>
        /// The byte 15
        /// </summary>
        private byte byte15;
        
        /// <summary>
        /// The byte 16
        /// </summary>
        private byte byte16;
        
        /// <summary>
        /// The byte 17
        /// </summary>
        private byte byte17;
        
        /// <summary>
        /// The byte 18
        /// </summary>
        private byte byte18;
        
        /// <summary>
        /// The byte 19
        /// </summary>
        private byte byte19;
        
        /// <summary>
        /// The byte 20
        /// </summary>
        private byte byte20;
        
        /// <summary>
        /// The byte 21
        /// </summary>
        private byte byte21;
        
        /// <summary>
        /// The byte 22
        /// </summary>
        private byte byte22;
        
        /// <summary>
        /// The byte 23
        /// </summary>
        private byte byte23;
        
        /// <summary>
        /// The byte 24
        /// </summary>
        private byte byte24;
        
        /// <summary>
        /// The byte 25
        /// </summary>
        private byte byte25;
        
        /// <summary>
        /// The byte 26
        /// </summary>
        private byte byte26;
        
        /// <summary>
        /// The byte 27
        /// </summary>
        private byte byte27;
        
        /// <summary>
        /// The byte 28
        /// </summary>
        private byte byte28;
        
        /// <summary>
        /// The byte 29
        /// </summary>
        private byte byte29;
        
        /// <summary>
        /// The byte 30
        /// </summary>
        private byte byte30;
        
        /// <summary>
        /// The byte 31
        /// </summary>
        private byte byte31;
        
        /// <summary>
        /// Gets or sets the value of the text
        /// </summary>
        public byte[] text
        {
            get
            {
                byte[] textBytes = new byte[32]
                {
                    byte0,
                    byte1,
                    byte2,
                    byte3,
                    byte4,
                    byte5,
                    byte6,
                    byte7,
                    byte8,
                    byte9,
                    byte10,
                    byte11,
                    byte12,
                    byte13,
                    byte14,
                    byte15,
                    byte16,
                    byte17,
                    byte18,
                    byte19,
                    byte20,
                    byte21,
                    byte22,
                    byte23,
                    byte24,
                    byte25,
                    byte26,
                    byte27,
                    byte28,
                    byte29,
                    byte30,
                    byte31,
                };
                
                return textBytes;
            }
        }
    }
}