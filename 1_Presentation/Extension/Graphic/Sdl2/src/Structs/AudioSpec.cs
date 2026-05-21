

using System;
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sdl2.Delegates;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl audio spec
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AudioSpec
    {
        /// <summary>
        ///     The freq
        /// </summary>
        public int Freq { get; set; }

        /// <summary>
        ///     The SDL_AudioFormat
        /// </summary>
        public ushort Format { get; set; }

        /// <summary>
        ///     The channels
        /// </summary>
        public byte Channels { get; set; }

        /// <summary>
        ///     The silence
        /// </summary>
        public readonly byte silence;

        /// <summary>
        ///     The samples
        /// </summary>
        public ushort Samples { get; set; }

        /// <summary>
        ///     The size
        /// </summary>
        public readonly uint size;

        /// <summary>
        ///     The callback
        /// </summary>
        public SdlAudioCallback Callback { get; set; }

        /// <summary>
        ///     The userdata
        /// </summary>
        public IntPtr Userdata { get; set; }
    }
}