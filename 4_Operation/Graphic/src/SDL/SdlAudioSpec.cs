using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl audiospec
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlAudioSpec
    {
        /// <summary>
        ///     The freq
        /// </summary>
        public int freq;

        /// <summary>
        ///     The format
        /// </summary>
        public ushort format; // SDL_AudioFormat

        /// <summary>
        ///     The channels
        /// </summary>
        public byte channels;

        /// <summary>
        ///     The silence
        /// </summary>
        public byte silence;

        /// <summary>
        ///     The samples
        /// </summary>
        public ushort samples;

        /// <summary>
        ///     The size
        /// </summary>
        public uint size;

        /// <summary>
        ///     The callback
        /// </summary>
        public Sdl.SdlAudioCallback callback;

        /// <summary>
        ///     The userdata
        /// </summary>
        public IntPtr userdata; // void*
    }
}