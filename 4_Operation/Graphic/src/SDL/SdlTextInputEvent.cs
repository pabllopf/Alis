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
        ///     The sdl texteditingevent text size
        /// </summary>
        private IntPtr textPtr;
        
        /// <summary>
        /// Gets or sets the value of the text
        /// </summary>
        public byte[] text
        {
            get
            {
                byte[] textBytes = new byte[Sdl.SdlTexteditingeventTextSize];
                Marshal.Copy(textPtr, textBytes, 0, Sdl.SdlTexteditingeventTextSize);
                return textBytes;
            }
            set => Marshal.Copy(value, 0, textPtr, Sdl.SdlTexteditingeventTextSize);
        }
    }
}