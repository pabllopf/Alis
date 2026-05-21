

using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Glfw.Structs
{
    /// <summary>
    ///     Used internally for marshalling
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct GammaRampInternal
    {
        /// <summary>
        ///     The red
        /// </summary>
        public readonly IntPtr Red;

        /// <summary>
        ///     The green
        /// </summary>
        public readonly IntPtr Green;

        /// <summary>
        ///     The blue
        /// </summary>
        public readonly IntPtr Blue;

        /// <summary>
        ///     The size
        /// </summary>
        public readonly int Size;
        /// <summary>
        ///     Explicitly converts to GammaRamp.
        /// </summary>

        public static explicit operator GammaRamp(GammaRampInternal ramp)
        {
            int offset = 0;
            ushort[] red = new ushort[ramp.Size];
            ushort[] green = new ushort[ramp.Size];
            ushort[] blue = new ushort[ramp.Size];
            for (int i = 0; i < ramp.Size; i++, offset += sizeof(ushort))
            {
                red[i] = unchecked((ushort) Marshal.ReadInt16(ramp.Red, offset));
                green[i] = unchecked((ushort) Marshal.ReadInt16(ramp.Green, offset));
                blue[i] = unchecked((ushort) Marshal.ReadInt16(ramp.Blue, offset));
            }

            return new GammaRamp(red, green, blue);
        }
    }
}