using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl sensorevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlSensorEvent
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
        ///     The which
        /// </summary>
        public int which;

        /// <summary>
        ///     The data
        /// </summary>
        public IntPtr dataPtr;
        
        /// <summary>
        /// Gets or sets the value of the text
        /// </summary>
        public float[] data
        {
            get
            {
                float[] dataBytes = new float[6];
                Buffer.BlockCopy(data, 0, dataBytes, 0, 6);
                return dataBytes;
            }
            set => Marshal.Copy(value, 0, dataPtr, Sdl.SdlTexteditingeventTextSize);
        }
    }
}