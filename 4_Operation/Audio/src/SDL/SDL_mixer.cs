// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SDL_mixer.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

#region Using Statements

using System;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Base.Dll;
using Alis.Core.Audio.Properties;

#endregion

namespace Alis.Core.Audio.SDL
{
    /// <summary>
    ///     The sdl mixer class
    /// </summary>
    public static class SDL_mixer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SDL_mixer"/> class
        /// </summary>
        static SDL_mixer()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                switch (RuntimeInformation.ProcessArchitecture)
                {
                    case Architecture.Arm64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2_mixer.dylib", NativeAudio.osx_arm64_sdl2_mixer);
                        break;
                    case Architecture.X64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2_mixer.dylib", NativeAudio.osx_x64_sdl2_mixer);
                        break;
                }
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                switch (RuntimeInformation.ProcessArchitecture)
                {
                    case Architecture.Arm64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2_mixer.dll", NativeAudio.win_x64_sdl2_mixer);
                        break;
                    case Architecture.X86:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2_mixer.dll", NativeAudio.win_x86_sdl2_mixer);
                        break;
                    case Architecture.X64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2_mixer.dll", NativeAudio.win_x64_sdl2_mixer);
                        break;
                }
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                switch (RuntimeInformation.ProcessArchitecture)
                {
                    case Architecture.Arm64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2_mixer.so", NativeAudio.linux_arm64_sdl2_mixer);
                        break;
                    case Architecture.X64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2_mixer.so", NativeAudio.linux_x64_sdl2_mixer);
                        break;
                }
            }
        }

        #region SDL2# Variables

        /* Used by DllImport to load the native library. */
        /// <summary>
        ///     The native lib name
        /// </summary>
        private const string nativeLibName = "sdl2_mixer";

        #endregion

        #region SDL
        
        /// <summary>
        ///     The sdl init timer
        /// </summary>
        public const uint SDL_INIT_TIMER = 0x00000001;

        /// <summary>
        ///     The sdl init audio
        /// </summary>
        public const uint SDL_INIT_AUDIO = 0x00000010;

        /// <summary>
        ///     The sdl init video
        /// </summary>
        public const uint SDL_INIT_VIDEO = 0x00000020;

        /// <summary>
        ///     The sdl init joystick
        /// </summary>
        public const uint SDL_INIT_JOYSTICK = 0x00000200;

        /// <summary>
        ///     The sdl init haptic
        /// </summary>
        public const uint SDL_INIT_HAPTIC = 0x00001000;

        /// <summary>
        ///     The sdl init gamecontroller
        /// </summary>
        public const uint SDL_INIT_GAMECONTROLLER = 0x00002000;

        /// <summary>
        ///     The sdl init events
        /// </summary>
        public const uint SDL_INIT_EVENTS = 0x00004000;

        /// <summary>
        ///     The sdl init sensor
        /// </summary>
        public const uint SDL_INIT_SENSOR = 0x00008000;

        /// <summary>
        ///     The sdl init noparachute
        /// </summary>
        public const uint SDL_INIT_NOPARACHUTE = 0x00100000;

        /// <summary>
        ///     The sdl init sensor
        /// </summary>
        public const uint SDL_INIT_EVERYTHING = SDL_INIT_TIMER | SDL_INIT_AUDIO | SDL_INIT_VIDEO |
                                                SDL_INIT_EVENTS | SDL_INIT_JOYSTICK | SDL_INIT_HAPTIC |
                                                SDL_INIT_GAMECONTROLLER | SDL_INIT_SENSOR;

        /// <summary>
        ///     Sdls the init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_Init(uint flags);

        /// <summary>
        ///     Sdls the init sub system using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_InitSubSystem(uint flags);

        /// <summary>
        ///     Sdls the quit
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Quit();

        #endregion

        #region SDL_mixer.h

        /* Similar to the headers, this is the version we're expecting to be
         * running with. You will likely want to check this somewhere in your
         * program!
         */
        /// <summary>
        ///     The sdl mixer major version
        /// </summary>
        public const int SDL_MIXER_MAJOR_VERSION = 2;

        /// <summary>
        ///     The sdl mixer minor version
        /// </summary>
        public const int SDL_MIXER_MINOR_VERSION = 0;

        /// <summary>
        ///     The sdl mixer patchlevel
        /// </summary>
        public const int SDL_MIXER_PATCHLEVEL = 5;

        /* In C, you can redefine this value before including SDL_mixer.h.
         * We're not going to allow this in SDL2#, since the value of this
         * variable is persistent and not dependent on preprocessor ordering.
         */
        /// <summary>
        ///     The mix channels
        /// </summary>
        public const int MIX_CHANNELS = 8;

        /// <summary>
        ///     The mix default frequency
        /// </summary>
        public static readonly int MIX_DEFAULT_FREQUENCY = 44100;

        /// <summary>
        ///     The audio s16msb
        /// </summary>
        public static readonly ushort MIX_DEFAULT_FORMAT =
            BitConverter.IsLittleEndian ? AUDIO_S16LSB : AUDIO_S16MSB;

        /// <summary>
        ///     The mix default channels
        /// </summary>
        public static readonly int MIX_DEFAULT_CHANNELS = 2;

        /// <summary>
        ///     The mix max volume
        /// </summary>
        public static readonly byte MIX_MAX_VOLUME = 128;

        /// <summary>
        ///     The audio u8
        /// </summary>
        public const ushort AUDIO_U8 = 0x0008;

        /// <summary>
        ///     The audio s8
        /// </summary>
        public const ushort AUDIO_S8 = 0x8008;

        /// <summary>
        ///     The audio u16lsb
        /// </summary>
        public const ushort AUDIO_U16LSB = 0x0010;

        /// <summary>
        ///     The audio s16lsb
        /// </summary>
        public const ushort AUDIO_S16LSB = 0x8010;

        /// <summary>
        ///     The audio u16msb
        /// </summary>
        public const ushort AUDIO_U16MSB = 0x1010;

        /// <summary>
        ///     The audio s16msb
        /// </summary>
        public const ushort AUDIO_S16MSB = 0x9010;

        /// <summary>
        ///     The audio u16lsb
        /// </summary>
        public const ushort AUDIO_U16 = AUDIO_U16LSB;

        /// <summary>
        ///     The audio s16lsb
        /// </summary>
        public const ushort AUDIO_S16 = AUDIO_S16LSB;

        /// <summary>
        ///     The audio s32lsb
        /// </summary>
        public const ushort AUDIO_S32LSB = 0x8020;

        /// <summary>
        ///     The audio s32msb
        /// </summary>
        public const ushort AUDIO_S32MSB = 0x9020;

        /// <summary>
        ///     The audio s32lsb
        /// </summary>
        public const ushort AUDIO_S32 = AUDIO_S32LSB;

        /// <summary>
        ///     The audio f32lsb
        /// </summary>
        public const ushort AUDIO_F32LSB = 0x8120;

        /// <summary>
        ///     The audio f32msb
        /// </summary>
        public const ushort AUDIO_F32MSB = 0x9120;

        /// <summary>
        ///     The audio f32lsb
        /// </summary>
        public const ushort AUDIO_F32 = AUDIO_F32LSB;

        /// <summary>
        ///     The audio u16msb
        /// </summary>
        public static readonly ushort AUDIO_U16SYS =
            BitConverter.IsLittleEndian ? AUDIO_U16LSB : AUDIO_U16MSB;

        /// <summary>
        ///     The audio s16msb
        /// </summary>
        public static readonly ushort AUDIO_S16SYS =
            BitConverter.IsLittleEndian ? AUDIO_S16LSB : AUDIO_S16MSB;

        /// <summary>
        ///     The audio s32msb
        /// </summary>
        public static readonly ushort AUDIO_S32SYS =
            BitConverter.IsLittleEndian ? AUDIO_S32LSB : AUDIO_S32MSB;

        /// <summary>
        ///     The audio f32msb
        /// </summary>
        public static readonly ushort AUDIO_F32SYS =
            BitConverter.IsLittleEndian ? AUDIO_F32LSB : AUDIO_F32MSB;

        /// <summary>
        ///     The sdl audio allow frequency change
        /// </summary>
        public const uint SDL_AUDIO_ALLOW_FREQUENCY_CHANGE = 0x00000001;

        /// <summary>
        ///     The sdl audio allow format change
        /// </summary>
        public const uint SDL_AUDIO_ALLOW_FORMAT_CHANGE = 0x00000002;

        /// <summary>
        ///     The sdl audio allow channels change
        /// </summary>
        public const uint SDL_AUDIO_ALLOW_CHANNELS_CHANGE = 0x00000004;

        /// <summary>
        ///     The sdl audio allow samples change
        /// </summary>
        public const uint SDL_AUDIO_ALLOW_SAMPLES_CHANGE = 0x00000008;

        /// <summary>
        ///     The sdl audio allow samples change
        /// </summary>
        public const uint SDL_AUDIO_ALLOW_ANY_CHANGE = SDL_AUDIO_ALLOW_FREQUENCY_CHANGE |
                                                       SDL_AUDIO_ALLOW_FORMAT_CHANGE |
                                                       SDL_AUDIO_ALLOW_CHANNELS_CHANGE |
                                                       SDL_AUDIO_ALLOW_SAMPLES_CHANGE;

        /// <summary>
        ///     The sdl mix maxvolume
        /// </summary>
        public const int SDL_MIX_MAXVOLUME = 128;


        /// <summary>
        ///     The mix func delegate
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void MixFuncDelegate(
            IntPtr udata, // void*
            IntPtr stream, // Uint8*
            int len
        );

        /// <summary>
        ///     The mix effectfunc
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void Mix_EffectFunc_t(
            int chan,
            IntPtr stream, // void*
            int len,
            IntPtr udata // void*
        );

        /// <summary>
        ///     The mix effectdone
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void Mix_EffectDone_t(
            int chan,
            IntPtr udata // void*
        );

        /// <summary>
        ///     The music finished delegate
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void MusicFinishedDelegate();

        /// <summary>
        ///     The channel finished delegate
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ChannelFinishedDelegate(int channel);

        /// <summary>
        ///     The sound font delegate
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int SoundFontDelegate(
            IntPtr a, // const char*
            IntPtr b // void*
        );

        /// <summary>
        ///     Sdls the mixer version using the specified x
        /// </summary>
        /// <param name="X">The </param>
        public static void SDL_MIXER_VERSION(out SDL_version X)
        {
            X.major = SDL_MIXER_MAJOR_VERSION;
            X.minor = SDL_MIXER_MINOR_VERSION;
            X.patch = SDL_MIXER_PATCHLEVEL;
        }

        /// <summary>
        ///     Internals the mix linked version
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, EntryPoint = "MIX_Linked_Version", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_MIX_Linked_Version();

        /// <summary>
        ///     Mixes the linked version
        /// </summary>
        /// <returns>The result</returns>
        public static SDL_version MIX_Linked_Version()
        {
            SDL_version result;
            IntPtr result_ptr = INTERNAL_MIX_Linked_Version();
            result = (SDL_version) Marshal.PtrToStructure(
                result_ptr,
                typeof(SDL_version)
            );
            return result;
        }


        /// <summary>
        ///     Mixes the init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_Init(MIX_InitFlags flags);

        /// <summary>
        ///     Mixes the quit
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_Quit();

        /// <summary>
        ///     Mixes the open audio using the specified frequency
        /// </summary>
        /// <param name="frequency">The frequency</param>
        /// <param name="format">The format</param>
        /// <param name="channels">The channels</param>
        /// <param name="chunksize">The chunksize</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_OpenAudio(
            int frequency,
            ushort format,
            int channels,
            int chunksize
        );

        /// <summary>
        ///     Mixes the allocate channels using the specified numchans
        /// </summary>
        /// <param name="numchans">The numchans</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_AllocateChannels(int numchans);

        /// <summary>
        ///     Mixes the query spec using the specified frequency
        /// </summary>
        /// <param name="frequency">The frequency</param>
        /// <param name="format">The format</param>
        /// <param name="channels">The channels</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_QuerySpec(
            out int frequency,
            out ushort format,
            out int channels
        );

        /* src refers to an SDL_RWops*, IntPtr to a Mix_Chunk* */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        /// <summary>
        ///     Mixes the load wav rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Mix_LoadWAV_RW(
            IntPtr src,
            int freesrc
        );

        /* IntPtr refers to a Mix_Chunk* */
        /* This is an RWops macro in the C header. */
        /// <summary>
        ///     Mixes the load wav using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        public static IntPtr Mix_LoadWAV(string file)
        {
            IntPtr rwops = SDL_RWFromFile(file, "rb");
            return Mix_LoadWAV_RW(rwops, 1);
        }
        
        /// <summary>
        ///     Sdls the rw from file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="mode">The mode</param>
        /// <returns>The rw ops</returns>
        public static unsafe IntPtr SDL_RWFromFile(
            string file,
            string mode
        )
        {
            byte* utf8File = Utf8EncodeHeap(file);
            byte* utf8Mode = Utf8EncodeHeap(mode);
            IntPtr rwOps = INTERNAL_SDL_RWFromFile(
                utf8File,
                utf8Mode
            );
            Marshal.FreeHGlobal((IntPtr) utf8Mode);
            Marshal.FreeHGlobal((IntPtr) utf8File);
            return rwOps;
        }
        
        /// <summary>
        ///     Internals the sdl rw from file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, EntryPoint = "SDL_RWFromFile", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe IntPtr INTERNAL_SDL_RWFromFile(
            byte* file,
            byte* mode
        );

        /* IntPtr refers to a Mix_Music* */
        /// <summary>
        ///     Internals the mix load mus using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, EntryPoint = "Mix_LoadMUS", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe IntPtr INTERNAL_Mix_LoadMUS(
            byte* file
        );

        /// <summary>
        ///     Mixes the load mus using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The handle</returns>
        public static unsafe IntPtr Mix_LoadMUS(string file)
        {
            byte* utf8File = Utf8EncodeHeap(file);
            IntPtr handle = INTERNAL_Mix_LoadMUS(
                utf8File
            );
            Marshal.FreeHGlobal((IntPtr) utf8File);
            return handle;
        }

        /* IntPtr refers to a Mix_Chunk* */
        /// <summary>
        ///     Mixes the quick load wav using the specified mem
        /// </summary>
        /// <param name="mem">The mem</param>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Mix_QuickLoad_WAV(
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1)]
            byte[] mem
        );

        /* IntPtr refers to a Mix_Chunk* */
        /// <summary>
        ///     Mixes the quick load raw using the specified mem
        /// </summary>
        /// <param name="mem">The mem</param>
        /// <param name="len">The len</param>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Mix_QuickLoad_RAW(
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)]
            byte[] mem,
            uint len
        );

        /* chunk refers to a Mix_Chunk* */
        /// <summary>
        ///     Mixes the free chunk using the specified chunk
        /// </summary>
        /// <param name="chunk">The chunk</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_FreeChunk(IntPtr chunk);

        /* music refers to a Mix_Music* */
        /// <summary>
        ///     Mixes the free music using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_FreeMusic(IntPtr music);

        /// <summary>
        ///     Mixes the get num chunk decoders
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GetNumChunkDecoders();

        /// <summary>
        ///     Internals the mix get chunk decoder using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, EntryPoint = "Mix_GetChunkDecoder", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_Mix_GetChunkDecoder(int index);

        /// <summary>
        ///     Mixes the get chunk decoder using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        public static string Mix_GetChunkDecoder(int index) =>UTF8_ToManaged(
            INTERNAL_Mix_GetChunkDecoder(index)
        );

        /// <summary>
        ///     Mixes the get num music decoders
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GetNumMusicDecoders();

        /// <summary>
        ///     Internals the mix get music decoder using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, EntryPoint = "Mix_GetMusicDecoder", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_Mix_GetMusicDecoder(int index);

        /// <summary>
        ///     Mixes the get music decoder using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        public static string Mix_GetMusicDecoder(int index) => UTF8_ToManaged(
            INTERNAL_Mix_GetMusicDecoder(index)
        );

        /* music refers to a Mix_Music* */
        /// <summary>
        ///     Mixes the get music type using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The mix music type</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mix_MusicType Mix_GetMusicType(IntPtr music);

        /* music refers to a Mix_Music*
         * Only available in 2.0.5 or higher.
         */
        /// <summary>
        ///     Internals the mix get music title using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, EntryPoint = "Mix_GetMusicTitle", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr INTERNAL_Mix_GetMusicTitle(IntPtr music);

        /// <summary>
        ///     Mixes the get music title using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The string</returns>
        public static string Mix_GetMusicTitle(IntPtr music) => UTF8_ToManaged(
            INTERNAL_Mix_GetMusicTitle(music)
        );

        /* music refers to a Mix_Music*
         * Only available in 2.0.5 or higher.
         */
        /// <summary>
        ///     Internals the mix get music title tag using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, EntryPoint = "Mix_GetMusicTitleTag", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr INTERNAL_Mix_GetMusicTitleTag(IntPtr music);

        /// <summary>
        ///     Mixes the get music title tag using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The string</returns>
        public static string Mix_GetMusicTitleTag(IntPtr music) => UTF8_ToManaged(
            INTERNAL_Mix_GetMusicTitleTag(music)
        );

        /* music refers to a Mix_Music*
         * Only available in 2.0.5 or higher.
         */
        /// <summary>
        ///     Internals the mix get music artist tag using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, EntryPoint = "Mix_GetMusicArtistTag", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr INTERNAL_Mix_GetMusicArtistTag(IntPtr music);

        /// <summary>
        ///     Mixes the get music artist tag using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The string</returns>
        public static string Mix_GetMusicArtistTag(IntPtr music) => UTF8_ToManaged(
            INTERNAL_Mix_GetMusicArtistTag(music)
        );

        /* music refers to a Mix_Music*
         * Only available in 2.0.5 or higher.
         */
        /// <summary>
        ///     Internals the mix get music album tag using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, EntryPoint = "Mix_GetMusicAlbumTag", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr INTERNAL_Mix_GetMusicAlbumTag(IntPtr music);

        /// <summary>
        ///     Mixes the get music album tag using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The string</returns>
        public static string Mix_GetMusicAlbumTag(IntPtr music) => UTF8_ToManaged(
            INTERNAL_Mix_GetMusicAlbumTag(music)
        );

        /* music refers to a Mix_Music*
         * Only available in 2.0.5 or higher.
         */
        /// <summary>
        ///     Internals the mix get music copyright tag using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, EntryPoint = "Mix_GetMusicCopyrightTag", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr INTERNAL_Mix_GetMusicCopyrightTag(IntPtr music);

        /// <summary>
        ///     Mixes the get music copyright tag using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The string</returns>
        public static string Mix_GetMusicCopyrightTag(IntPtr music) => UTF8_ToManaged(
            INTERNAL_Mix_GetMusicCopyrightTag(music)
        );

        /// <summary>
        ///     Mixes the set post mix using the specified mix func
        /// </summary>
        /// <param name="mix_func">The mix func</param>
        /// <param name="arg">The arg</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_SetPostMix(
            MixFuncDelegate mix_func,
            IntPtr arg // void*
        );

        /// <summary>
        ///     Mixes the hook music using the specified mix func
        /// </summary>
        /// <param name="mix_func">The mix func</param>
        /// <param name="arg">The arg</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_HookMusic(
            MixFuncDelegate mix_func,
            IntPtr arg // void*
        );

        /// <summary>
        ///     Mixes the hook music finished using the specified music finished
        /// </summary>
        /// <param name="music_finished">The music finished</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_HookMusicFinished(
            MusicFinishedDelegate music_finished
        );

        /* IntPtr refers to a void* */
        /// <summary>
        ///     Mixes the get music hook data
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Mix_GetMusicHookData();

        /// <summary>
        ///     Mixes the channel finished using the specified channel finished
        /// </summary>
        /// <param name="channel_finished">The channel finished</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_ChannelFinished(
            ChannelFinishedDelegate channel_finished
        );

        /// <summary>
        ///     Mixes the register effect using the specified chan
        /// </summary>
        /// <param name="chan">The chan</param>
        /// <param name="f">The </param>
        /// <param name="d">The </param>
        /// <param name="arg">The arg</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_RegisterEffect(
            int chan,
            Mix_EffectFunc_t f,
            Mix_EffectDone_t d,
            IntPtr arg // void*
        );

        /// <summary>
        ///     Mixes the unregister effect using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <param name="f">The </param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_UnregisterEffect(
            int channel,
            Mix_EffectFunc_t f
        );

        /// <summary>
        ///     Mixes the unregister all effects using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_UnregisterAllEffects(int channel);

        /// <summary>
        ///     Mixes the set panning using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_SetPanning(
            int channel,
            byte left,
            byte right
        );

        /// <summary>
        ///     Mixes the set position using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <param name="angle">The angle</param>
        /// <param name="distance">The distance</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_SetPosition(
            int channel,
            short angle,
            byte distance
        );

        /// <summary>
        ///     Mixes the set distance using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <param name="distance">The distance</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_SetDistance(int channel, byte distance);

        /// <summary>
        ///     Mixes the set reverse stereo using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_SetReverseStereo(int channel, int flip);

        /// <summary>
        ///     Mixes the reserve channels using the specified num
        /// </summary>
        /// <param name="num">The num</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_ReserveChannels(int num);

        /// <summary>
        ///     Mixes the group channel using the specified which
        /// </summary>
        /// <param name="which">The which</param>
        /// <param name="tag">The tag</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GroupChannel(int which, int tag);

        /// <summary>
        ///     Mixes the group channels using the specified from
        /// </summary>
        /// <param name="from">The from</param>
        /// <param name="to">The to</param>
        /// <param name="tag">The tag</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GroupChannels(int from, int to, int tag);

        /// <summary>
        ///     Mixes the group available using the specified tag
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GroupAvailable(int tag);

        /// <summary>
        ///     Mixes the group count using the specified tag
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GroupCount(int tag);

        /// <summary>
        ///     Mixes the group oldest using the specified tag
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GroupOldest(int tag);

        /// <summary>
        ///     Mixes the group newer using the specified tag
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GroupNewer(int tag);

        /* chunk refers to a Mix_Chunk* */
        /// <summary>
        ///     Mixes the play channel using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <param name="chunk">The chunk</param>
        /// <param name="loops">The loops</param>
        /// <returns>The int</returns>
        public static int Mix_PlayChannel(
            int channel,
            IntPtr chunk,
            int loops
        )
            => Mix_PlayChannelTimed(channel, chunk, loops, -1);

        /* chunk refers to a Mix_Chunk* */
        /// <summary>
        ///     Mixes the play channel timed using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <param name="chunk">The chunk</param>
        /// <param name="loops">The loops</param>
        /// <param name="ticks">The ticks</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_PlayChannelTimed(
            int channel,
            IntPtr chunk,
            int loops,
            int ticks
        );

        /* music refers to a Mix_Music* */
        /// <summary>
        ///     Mixes the play music using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <param name="loops">The loops</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_PlayMusic(IntPtr music, int loops);

        /* music refers to a Mix_Music* */
        /// <summary>
        ///     Mixes the fade in music using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <param name="loops">The loops</param>
        /// <param name="ms">The ms</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_FadeInMusic(
            IntPtr music,
            int loops,
            int ms
        );

        /* music refers to a Mix_Music* */
        /// <summary>
        ///     Mixes the fade in music pos using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <param name="loops">The loops</param>
        /// <param name="ms">The ms</param>
        /// <param name="position">The position</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_FadeInMusicPos(
            IntPtr music,
            int loops,
            int ms,
            double position
        );

        /* chunk refers to a Mix_Chunk* */
        /// <summary>
        ///     Mixes the fade in channel using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <param name="chunk">The chunk</param>
        /// <param name="loops">The loops</param>
        /// <param name="ms">The ms</param>
        /// <returns>The int</returns>
        public static int Mix_FadeInChannel(
            int channel,
            IntPtr chunk,
            int loops,
            int ms
        )
            => Mix_FadeInChannelTimed(channel, chunk, loops, ms, -1);

        /* chunk refers to a Mix_Chunk* */
        /// <summary>
        ///     Mixes the fade in channel timed using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <param name="chunk">The chunk</param>
        /// <param name="loops">The loops</param>
        /// <param name="ms">The ms</param>
        /// <param name="ticks">The ticks</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_FadeInChannelTimed(
            int channel,
            IntPtr chunk,
            int loops,
            int ms,
            int ticks
        );

        /// <summary>
        ///     Mixes the volume using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <param name="volume">The volume</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_Volume(int channel, int volume);

        /* chunk refers to a Mix_Chunk* */
        /// <summary>
        ///     Mixes the volume chunk using the specified chunk
        /// </summary>
        /// <param name="chunk">The chunk</param>
        /// <param name="volume">The volume</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_VolumeChunk(
            IntPtr chunk,
            int volume
        );

        /// <summary>
        ///     Mixes the volume music using the specified volume
        /// </summary>
        /// <param name="volume">The volume</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_VolumeMusic(int volume);

        /* music refers to a Mix_Music*
         * Only available in 2.0.5 or higher.
         */
        /// <summary>
        ///     Mixes the get volume music stream using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GetVolumeMusicStream(IntPtr music);

        /// <summary>
        ///     Mixes the halt channel using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_HaltChannel(int channel);

        /// <summary>
        ///     Mixes the halt group using the specified tag
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_HaltGroup(int tag);

        /// <summary>
        ///     Mixes the halt music
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_HaltMusic();

        /// <summary>
        ///     Mixes the expire channel using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <param name="ticks">The ticks</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_ExpireChannel(int channel, int ticks);

        /// <summary>
        ///     Mixes the fade out channel using the specified which
        /// </summary>
        /// <param name="which">The which</param>
        /// <param name="ms">The ms</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_FadeOutChannel(int which, int ms);

        /// <summary>
        ///     Mixes the fade out group using the specified tag
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <param name="ms">The ms</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_FadeOutGroup(int tag, int ms);

        /// <summary>
        ///     Mixes the fade out music using the specified ms
        /// </summary>
        /// <param name="ms">The ms</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_FadeOutMusic(int ms);

        /// <summary>
        ///     Mixes the fading music
        /// </summary>
        /// <returns>The mix fading</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mix_Fading Mix_FadingMusic();

        /// <summary>
        ///     Mixes the fading channel using the specified which
        /// </summary>
        /// <param name="which">The which</param>
        /// <returns>The mix fading</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mix_Fading Mix_FadingChannel(int which);

        /// <summary>
        ///     Mixes the pause using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_Pause(int channel);

        /// <summary>
        ///     Mixes the resume using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_Resume(int channel);

        /// <summary>
        ///     Mixes the paused using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_Paused(int channel);

        /// <summary>
        ///     Mixes the pause music
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_PauseMusic();

        /// <summary>
        ///     Mixes the resume music
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_ResumeMusic();

        /// <summary>
        ///     Mixes the rewind music
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_RewindMusic();

        /// <summary>
        ///     Mixes the paused music
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_PausedMusic();

        /// <summary>
        ///     Mixes the set music position using the specified position
        /// </summary>
        /// <param name="position">The position</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_SetMusicPosition(double position);

        /* music refers to a Mix_Music*
         * Only available in 2.0.5 or higher.
         */
        /// <summary>
        ///     Mixes the get music position using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The double</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double Mix_GetMusicPosition(IntPtr music);

        /* music refers to a Mix_Music*
         * Only available in 2.0.5 or higher.
         */
        /// <summary>
        ///     Mixes the music duration using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The double</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double Mix_MusicDuration(IntPtr music);

        /* music refers to a Mix_Music*
         * Only available in 2.0.5 or higher.
         */
        /// <summary>
        ///     Mixes the get music loop start time using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The double</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double Mix_GetMusicLoopStartTime(IntPtr music);

        /* music refers to a Mix_Music*
         * Only available in 2.0.5 or higher.
         */
        /// <summary>
        ///     Mixes the get music loop end time using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The double</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double Mix_GetMusicLoopEndTime(IntPtr music);

        /* music refers to a Mix_Music*
         * Only available in 2.0.5 or higher.
         */
        /// <summary>
        ///     Mixes the get music loop length time using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The double</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double Mix_GetMusicLoopLengthTime(IntPtr music);

        /// <summary>
        ///     Mixes the playing using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_Playing(int channel);

        /// <summary>
        ///     Mixes the playing music
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_PlayingMusic();

        /// <summary>
        ///     Internals the mix set music cmd using the specified command
        /// </summary>
        /// <param name="command">The command</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, EntryPoint = "Mix_SetMusicCMD", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int INTERNAL_Mix_SetMusicCMD(
            byte* command
        );

        /// <summary>
        ///     Mixes the set music cmd using the specified command
        /// </summary>
        /// <param name="command">The command</param>
        /// <returns>The result</returns>
        public static unsafe int Mix_SetMusicCMD(string command)
        {
            byte* utf8Cmd = Utf8EncodeHeap(command);
            int result = INTERNAL_Mix_SetMusicCMD(
                utf8Cmd
            );
            Marshal.FreeHGlobal((IntPtr) utf8Cmd);
            return result;
        }

        /// <summary>
        ///     Mixes the set synchro value using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_SetSynchroValue(int value);

        /// <summary>
        ///     Mixes the get synchro value
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GetSynchroValue();

        /// <summary>
        ///     Internals the mix set sound fonts using the specified paths
        /// </summary>
        /// <param name="paths">The paths</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, EntryPoint = "Mix_SetSoundFonts", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int INTERNAL_Mix_SetSoundFonts(
            byte* paths
        );

        /// <summary>
        ///     Mixes the set sound fonts using the specified paths
        /// </summary>
        /// <param name="paths">The paths</param>
        /// <returns>The result</returns>
        public static unsafe int Mix_SetSoundFonts(string paths)
        {
            byte* utf8Paths = Utf8EncodeHeap(paths);
            int result = INTERNAL_Mix_SetSoundFonts(
                utf8Paths
            );
            Marshal.FreeHGlobal((IntPtr) utf8Paths);
            return result;
        }

        /// <summary>
        ///     Internals the mix get sound fonts
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, EntryPoint = "Mix_GetSoundFonts", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_Mix_GetSoundFonts();

        /// <summary>
        ///     Mixes the get sound fonts
        /// </summary>
        /// <returns>The string</returns>
        public static string Mix_GetSoundFonts() => UTF8_ToManaged(
            INTERNAL_Mix_GetSoundFonts()
        );

        /// <summary>
        ///     Mixes the each sound font using the specified function
        /// </summary>
        /// <param name="function">The function</param>
        /// <param name="data">The data</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_EachSoundFont(
            SoundFontDelegate function,
            IntPtr data // void*
        );

        /* Only available in 2.0.5 or later. */
        /// <summary>
        ///     Mixes the set timidity cfg using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_SetTimidityCfg(
            [In, MarshalAs(UnmanagedType.LPStr)] string path
        );

        /* Only available in 2.0.5 or later. */
        /// <summary>
        ///     Internals the mix get timidity cfg
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, EntryPoint = "Mix_GetTimidityCfg", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr INTERNAL_Mix_GetTimidityCfg();

        /// <summary>
        ///     Mixes the get timidity cfg
        /// </summary>
        /// <returns>The string</returns>
        public static string Mix_GetTimidityCfg() => UTF8_ToManaged(
            INTERNAL_Mix_GetTimidityCfg()
        );

        /* IntPtr refers to a Mix_Chunk* */
        /// <summary>
        ///     Mixes the get chunk using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Mix_GetChunk(int channel);

        /// <summary>
        ///     Mixes the close audio
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_CloseAudio();

        /// <summary>
        ///     Mixes the get error
        /// </summary>
        /// <returns>The string</returns>
        public static string Mix_GetError() => SDL_GetError();

        /// <summary>
        ///     Mixes the set error using the specified fmt and arglist
        /// </summary>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        public static void Mix_SetError(string fmtAndArglist)
        {
            SDL_SetError(fmtAndArglist);
        }

        /// <summary>
        ///     Mixes the clear error
        /// </summary>
        public static void Mix_ClearError()
        {
            SDL_ClearError();
        }

        #endregion
        
        #region UTF8 Marshaling

        /* Used for stack allocated string marshaling. */
        /// <summary>
        ///     Utfs the 8 size using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        /// <returns>The int</returns>
        internal static int Utf8Size(string str)
        {
            if (str == null)
            {
                return 0;
            }

            return str.Length * 4 + 1;
        }

        /// <summary>
        ///     Utfs the 8 encode using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        /// <param name="buffer">The buffer</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <returns>The buffer</returns>
        internal static unsafe byte* Utf8Encode(string str, byte* buffer, int bufferSize)
        {
            if (str == null)
            {
                return (byte*) 0;
            }

            fixed (char* strPtr = str)
            {
                Encoding.UTF8.GetBytes(strPtr, str.Length + 1, buffer, bufferSize);
            }

            return buffer;
        }

        /* Used for heap allocated string marshaling.
         * Returned byte* must be free'd with FreeHGlobal.
         */
        /// <summary>
        ///     Utfs the 8 encode heap using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        /// <returns>The buffer</returns>
        internal static unsafe byte* Utf8EncodeHeap(string str)
        {
            if (str == null)
            {
                return (byte*) 0;
            }

            int bufferSize = Utf8Size(str);
            byte* buffer = (byte*) Marshal.AllocHGlobal(bufferSize);
            fixed (char* strPtr = str)
            {
                Encoding.UTF8.GetBytes(strPtr, str.Length + 1, buffer, bufferSize);
            }

            return buffer;
        }

        /* This is public because SDL_DropEvent needs it! */
        /// <summary>
        ///     Utfs the 8 to managed using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="freePtr">The free ptr</param>
        /// <returns>The result</returns>
        public static unsafe string UTF8_ToManaged(IntPtr s, bool freePtr = false)
        {
            if (s == IntPtr.Zero)
            {
                return null;
            }

            /* We get to do strlen ourselves! */
            byte* ptr = (byte*) s;
            while (*ptr != 0)
            {
                ptr++;
            }

            /* TODO: This #ifdef is only here because the equivalent
             * .NET 2.0 constructor appears to be less efficient?
             * Here's the pretty version, maybe steal this instead:
             *
            string result = new string(
                (sbyte*) s, // Also, why sbyte???
                0,
                (int) (ptr - (byte*) s),
                System.Text.Encoding.UTF8
            );
             * See the CoreCLR source for more info.
             * -flibit
             */
#if NETSTANDARD2_0
			/* Modern C# lets you just send the byte*, nice! */
			string result = System.Text.Encoding.UTF8.GetString(
				(byte*) s,
				(int) (ptr - (byte*) s)
			);
#else
            /* Old C# requires an extra memcpy, bleh! */
            int len = (int) (ptr - (byte*) s);
            if (len == 0)
            {
                return string.Empty;
            }

            char* chars = stackalloc char[len];
            int strLen = Encoding.UTF8.GetChars((byte*) s, len, chars, len);
            string result = new string(chars, 0, strLen);
#endif

            /* Some SDL functions will malloc, we have to free! */
            if (freePtr)
            {
                SDL_free(s);
            }

            return result;
        }
        
        /// <summary>
        ///     Sdls the free using the specified memblock
        /// </summary>
        /// <param name="memblock">The memblock</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SDL_free(IntPtr memblock);

        #endregion
        
        
         #region SDL_error.h

        /// <summary>
        ///     Sdls the clear error
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_ClearError();

        /// <summary>
        ///     Internals the sdl get error
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, EntryPoint = "SDL_GetError", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetError();

        /// <summary>
        ///     Sdls the get error
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_GetError() => UTF8_ToManaged(INTERNAL_SDL_GetError());

        /* Use string.Format for arglists */
        /// <summary>
        ///     Internals the sdl set error using the specified fmt and arglist
        /// </summary>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        [DllImport(nativeLibName, EntryPoint = "SDL_SetError", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void INTERNAL_SDL_SetError(byte* fmtAndArglist);

        /// <summary>
        ///     Sdls the set error using the specified fmt and arglist
        /// </summary>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        public static unsafe void SDL_SetError(string fmtAndArglist)
        {
            int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
            byte* utf8FmtAndArglist = stackalloc byte[utf8FmtAndArglistBufSize];
            INTERNAL_SDL_SetError(
                Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
            );
        }

        /* IntPtr refers to a char*.
         * Only available in 2.0.14 or higher.
         */
        /// <summary>
        ///     Sdls the get error msg using the specified errstr
        /// </summary>
        /// <param name="errstr">The errstr</param>
        /// <param name="maxlength">The maxlength</param>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetErrorMsg(IntPtr errstr, int maxlength);

        #endregion
    }
}