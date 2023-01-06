// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SDL2_mixer.cs
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

using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Input.SDL2
{
    /// <summary>
    ///     The sdl mixer class
    /// </summary>
    public static class SdlMixer
    {
        /// <summary>
        ///     The channel finished delegate
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ChannelFinishedDelegate(int channel);

        /// <summary>
        ///     The mix effectdone
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void MixEffectDoneT(
            int chan,
            IntPtr udata // void*
        );

        /// <summary>
        ///     The mix effectfunc
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void MixEffectFuncT(
            int chan,
            IntPtr stream, // void*
            int len,
            IntPtr udata // void*
        );

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
        ///     The music finished delegate
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void MusicFinishedDelegate();

        /// <summary>
        ///     The sound font delegate
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int SoundFontDelegate(
            IntPtr a, // const char*
            IntPtr b // void*
        );

        /* Used by DllImport to load the native library. */
        /// <summary>
        ///     The native lib name
        /// </summary>
        private const string NativeLibName = "SDL2_mixer";


        /* Similar to the headers, this is the version we're expecting to be
         * running with. You will likely want to check this somewhere in your
         * program!
         */
        /// <summary>
        ///     The sdl mixer major version
        /// </summary>
        public const int SdlMixerMajorVersion = 2;

        /// <summary>
        ///     The sdl mixer minor version
        /// </summary>
        public const int SdlMixerMinorVersion = 0;

        /// <summary>
        ///     The sdl mixer patchlevel
        /// </summary>
        public const int SdlMixerPatchlevel = 5;

        /* In C, you can redefine this value before including SDL_mixer.h.
         * We're not going to allow this in SDL2#, since the value of this
         * variable is persistent and not dependent on preprocessor ordering.
         */
        /// <summary>
        ///     The mix channels
        /// </summary>
        public const int MixChannels = 8;

        /// <summary>
        ///     The mix default frequency
        /// </summary>
        public static readonly int MixDefaultFrequency = 44100;

        /// <summary>
        ///     The audio s16msb
        /// </summary>
        public static readonly ushort MixDefaultFormat =
            BitConverter.IsLittleEndian ? Sdl.AudioS16Lsb : Sdl.AudioS16Msb;

        /// <summary>
        ///     The mix default channels
        /// </summary>
        public static readonly int MixDefaultChannels = 2;

        /// <summary>
        ///     The mix max volume
        /// </summary>
        public static readonly byte MixMaxVolume = 128;

        /// <summary>
        ///     Sdls the mixer version using the specified x
        /// </summary>
        /// <param name="x">The </param>
        public static void SDL_MIXER_VERSION(out Sdl.SdlVersion x)
        {
            x.major = SdlMixerMajorVersion;
            x.minor = SdlMixerMinorVersion;
            x.patch = SdlMixerPatchlevel;
        }

        /// <summary>
        ///     Internals the mix linked version
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "MIX_Linked_Version", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_MIX_Linked_Version();

        /// <summary>
        ///     Mixes the linked version
        /// </summary>
        /// <returns>The result</returns>
        public static Sdl.SdlVersion MIX_Linked_Version()
        {
            Sdl.SdlVersion result;
            IntPtr resultPtr = INTERNAL_MIX_Linked_Version();
            result = (Sdl.SdlVersion) Marshal.PtrToStructure(
                resultPtr,
                typeof(Sdl.SdlVersion)
            );
            return result;
        }

        /// <summary>
        ///     Mixes the init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_Init(MixInitFlags flags);

        /// <summary>
        ///     Mixes the quit
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_Quit();

        /// <summary>
        ///     Mixes the open audio using the specified frequency
        /// </summary>
        /// <param name="frequency">The frequency</param>
        /// <param name="format">The format</param>
        /// <param name="channels">The channels</param>
        /// <param name="chunksize">The chunksize</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_AllocateChannels(int numchans);

        /// <summary>
        ///     Mixes the query spec using the specified frequency
        /// </summary>
        /// <param name="frequency">The frequency</param>
        /// <param name="format">The format</param>
        /// <param name="channels">The channels</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
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
            IntPtr rwops = Sdl.SDL_RWFromFile(file, "rb");
            return Mix_LoadWAV_RW(rwops, 1);
        }

        /* IntPtr refers to a Mix_Music* */
        /// <summary>
        ///     Internals the mix load mus using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "Mix_LoadMUS", CallingConvention = CallingConvention.Cdecl)]
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
            byte* utf8File = Sdl.Utf8EncodeHeap(file);
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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_FreeChunk(IntPtr chunk);

        /* music refers to a Mix_Music* */
        /// <summary>
        ///     Mixes the free music using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_FreeMusic(IntPtr music);

        /// <summary>
        ///     Mixes the get num chunk decoders
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GetNumChunkDecoders();

        /// <summary>
        ///     Internals the mix get chunk decoder using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "Mix_GetChunkDecoder", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_Mix_GetChunkDecoder(int index);

        /// <summary>
        ///     Mixes the get chunk decoder using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        public static string Mix_GetChunkDecoder(int index) => Sdl.UTF8_ToManaged(
            INTERNAL_Mix_GetChunkDecoder(index)
        );

        /// <summary>
        ///     Mixes the get num music decoders
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GetNumMusicDecoders();

        /// <summary>
        ///     Internals the mix get music decoder using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "Mix_GetMusicDecoder", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_Mix_GetMusicDecoder(int index);

        /// <summary>
        ///     Mixes the get music decoder using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        public static string Mix_GetMusicDecoder(int index) => Sdl.UTF8_ToManaged(
            INTERNAL_Mix_GetMusicDecoder(index)
        );

        /* music refers to a Mix_Music* */
        /// <summary>
        ///     Mixes the get music type using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The mix music type</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern MixMusicType Mix_GetMusicType(IntPtr music);

        /* music refers to a Mix_Music*
         * Only available in 2.0.5 or higher.
         */
        /// <summary>
        ///     Internals the mix get music title using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "Mix_GetMusicTitle", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr INTERNAL_Mix_GetMusicTitle(IntPtr music);

        /// <summary>
        ///     Mixes the get music title using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The string</returns>
        public static string Mix_GetMusicTitle(IntPtr music) => Sdl.UTF8_ToManaged(
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
        [DllImport(NativeLibName, EntryPoint = "Mix_GetMusicTitleTag", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr INTERNAL_Mix_GetMusicTitleTag(IntPtr music);

        /// <summary>
        ///     Mixes the get music title tag using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The string</returns>
        public static string Mix_GetMusicTitleTag(IntPtr music) => Sdl.UTF8_ToManaged(
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
        [DllImport(NativeLibName, EntryPoint = "Mix_GetMusicArtistTag", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr INTERNAL_Mix_GetMusicArtistTag(IntPtr music);

        /// <summary>
        ///     Mixes the get music artist tag using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The string</returns>
        public static string Mix_GetMusicArtistTag(IntPtr music) => Sdl.UTF8_ToManaged(
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
        [DllImport(NativeLibName, EntryPoint = "Mix_GetMusicAlbumTag", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr INTERNAL_Mix_GetMusicAlbumTag(IntPtr music);

        /// <summary>
        ///     Mixes the get music album tag using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The string</returns>
        public static string Mix_GetMusicAlbumTag(IntPtr music) => Sdl.UTF8_ToManaged(
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
        [DllImport(NativeLibName, EntryPoint = "Mix_GetMusicCopyrightTag", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr INTERNAL_Mix_GetMusicCopyrightTag(IntPtr music);

        /// <summary>
        ///     Mixes the get music copyright tag using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The string</returns>
        public static string Mix_GetMusicCopyrightTag(IntPtr music) => Sdl.UTF8_ToManaged(
            INTERNAL_Mix_GetMusicCopyrightTag(music)
        );

        /// <summary>
        ///     Mixes the set post mix using the specified mix func
        /// </summary>
        /// <param name="mixFunc">The mix func</param>
        /// <param name="arg">The arg</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_SetPostMix(
            MixFuncDelegate mixFunc,
            IntPtr arg // void*
        );

        /// <summary>
        ///     Mixes the hook music using the specified mix func
        /// </summary>
        /// <param name="mixFunc">The mix func</param>
        /// <param name="arg">The arg</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_HookMusic(
            MixFuncDelegate mixFunc,
            IntPtr arg // void*
        );

        /// <summary>
        ///     Mixes the hook music finished using the specified music finished
        /// </summary>
        /// <param name="musicFinished">The music finished</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_HookMusicFinished(
            MusicFinishedDelegate musicFinished
        );

        /* IntPtr refers to a void* */
        /// <summary>
        ///     Mixes the get music hook data
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Mix_GetMusicHookData();

        /// <summary>
        ///     Mixes the channel finished using the specified channel finished
        /// </summary>
        /// <param name="channelFinished">The channel finished</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_ChannelFinished(
            ChannelFinishedDelegate channelFinished
        );

        /// <summary>
        ///     Mixes the register effect using the specified chan
        /// </summary>
        /// <param name="chan">The chan</param>
        /// <param name="f">The </param>
        /// <param name="d">The </param>
        /// <param name="arg">The arg</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_RegisterEffect(
            int chan,
            MixEffectFuncT f,
            MixEffectDoneT d,
            IntPtr arg // void*
        );

        /// <summary>
        ///     Mixes the unregister effect using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <param name="f">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_UnregisterEffect(
            int channel,
            MixEffectFuncT f
        );

        /// <summary>
        ///     Mixes the unregister all effects using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_UnregisterAllEffects(int channel);

        /// <summary>
        ///     Mixes the set panning using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_SetDistance(int channel, byte distance);

        /// <summary>
        ///     Mixes the set reverse stereo using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_SetReverseStereo(int channel, int flip);

        /// <summary>
        ///     Mixes the reserve channels using the specified num
        /// </summary>
        /// <param name="num">The num</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_ReserveChannels(int num);

        /// <summary>
        ///     Mixes the group channel using the specified which
        /// </summary>
        /// <param name="which">The which</param>
        /// <param name="tag">The tag</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GroupChannel(int which, int tag);

        /// <summary>
        ///     Mixes the group channels using the specified from
        /// </summary>
        /// <param name="from">The from</param>
        /// <param name="to">The to</param>
        /// <param name="tag">The tag</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GroupChannels(int from, int to, int tag);

        /// <summary>
        ///     Mixes the group available using the specified tag
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GroupAvailable(int tag);

        /// <summary>
        ///     Mixes the group count using the specified tag
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GroupCount(int tag);

        /// <summary>
        ///     Mixes the group oldest using the specified tag
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GroupOldest(int tag);

        /// <summary>
        ///     Mixes the group newer using the specified tag
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_PlayMusic(IntPtr music, int loops);

        /* music refers to a Mix_Music* */
        /// <summary>
        ///     Mixes the fade in music using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <param name="loops">The loops</param>
        /// <param name="ms">The ms</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_Volume(int channel, int volume);

        /* chunk refers to a Mix_Chunk* */
        /// <summary>
        ///     Mixes the volume chunk using the specified chunk
        /// </summary>
        /// <param name="chunk">The chunk</param>
        /// <param name="volume">The volume</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_VolumeChunk(
            IntPtr chunk,
            int volume
        );

        /// <summary>
        ///     Mixes the volume music using the specified volume
        /// </summary>
        /// <param name="volume">The volume</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_VolumeMusic(int volume);

        /* music refers to a Mix_Music*
         * Only available in 2.0.5 or higher.
         */
        /// <summary>
        ///     Mixes the get volume music stream using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GetVolumeMusicStream(IntPtr music);

        /// <summary>
        ///     Mixes the halt channel using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_HaltChannel(int channel);

        /// <summary>
        ///     Mixes the halt group using the specified tag
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_HaltGroup(int tag);

        /// <summary>
        ///     Mixes the halt music
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_HaltMusic();

        /// <summary>
        ///     Mixes the expire channel using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <param name="ticks">The ticks</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_ExpireChannel(int channel, int ticks);

        /// <summary>
        ///     Mixes the fade out channel using the specified which
        /// </summary>
        /// <param name="which">The which</param>
        /// <param name="ms">The ms</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_FadeOutChannel(int which, int ms);

        /// <summary>
        ///     Mixes the fade out group using the specified tag
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <param name="ms">The ms</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_FadeOutGroup(int tag, int ms);

        /// <summary>
        ///     Mixes the fade out music using the specified ms
        /// </summary>
        /// <param name="ms">The ms</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_FadeOutMusic(int ms);

        /// <summary>
        ///     Mixes the fading music
        /// </summary>
        /// <returns>The mix fading</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern MixFading Mix_FadingMusic();

        /// <summary>
        ///     Mixes the fading channel using the specified which
        /// </summary>
        /// <param name="which">The which</param>
        /// <returns>The mix fading</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern MixFading Mix_FadingChannel(int which);

        /// <summary>
        ///     Mixes the pause using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_Pause(int channel);

        /// <summary>
        ///     Mixes the resume using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_Resume(int channel);

        /// <summary>
        ///     Mixes the paused using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_Paused(int channel);

        /// <summary>
        ///     Mixes the pause music
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_PauseMusic();

        /// <summary>
        ///     Mixes the resume music
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_ResumeMusic();

        /// <summary>
        ///     Mixes the rewind music
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_RewindMusic();

        /// <summary>
        ///     Mixes the paused music
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_PausedMusic();

        /// <summary>
        ///     Mixes the set music position using the specified position
        /// </summary>
        /// <param name="position">The position</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_SetMusicPosition(double position);

        /* music refers to a Mix_Music*
         * Only available in 2.0.5 or higher.
         */
        /// <summary>
        ///     Mixes the get music position using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The double</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double Mix_GetMusicPosition(IntPtr music);

        /* music refers to a Mix_Music*
         * Only available in 2.0.5 or higher.
         */
        /// <summary>
        ///     Mixes the music duration using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The double</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double Mix_MusicDuration(IntPtr music);

        /* music refers to a Mix_Music*
         * Only available in 2.0.5 or higher.
         */
        /// <summary>
        ///     Mixes the get music loop start time using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The double</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double Mix_GetMusicLoopStartTime(IntPtr music);

        /* music refers to a Mix_Music*
         * Only available in 2.0.5 or higher.
         */
        /// <summary>
        ///     Mixes the get music loop end time using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The double</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double Mix_GetMusicLoopEndTime(IntPtr music);

        /* music refers to a Mix_Music*
         * Only available in 2.0.5 or higher.
         */
        /// <summary>
        ///     Mixes the get music loop length time using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The double</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double Mix_GetMusicLoopLengthTime(IntPtr music);

        /// <summary>
        ///     Mixes the playing using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_Playing(int channel);

        /// <summary>
        ///     Mixes the playing music
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_PlayingMusic();

        /// <summary>
        ///     Internals the mix set music cmd using the specified command
        /// </summary>
        /// <param name="command">The command</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "Mix_SetMusicCMD", CallingConvention = CallingConvention.Cdecl)]
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
            byte* utf8Cmd = Sdl.Utf8EncodeHeap(command);
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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_SetSynchroValue(int value);

        /// <summary>
        ///     Mixes the get synchro value
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GetSynchroValue();

        /// <summary>
        ///     Internals the mix set sound fonts using the specified paths
        /// </summary>
        /// <param name="paths">The paths</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "Mix_SetSoundFonts", CallingConvention = CallingConvention.Cdecl)]
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
            byte* utf8Paths = Sdl.Utf8EncodeHeap(paths);
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
        [DllImport(NativeLibName, EntryPoint = "Mix_GetSoundFonts", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_Mix_GetSoundFonts();

        /// <summary>
        ///     Mixes the get sound fonts
        /// </summary>
        /// <returns>The string</returns>
        public static string Mix_GetSoundFonts() => Sdl.UTF8_ToManaged(
            INTERNAL_Mix_GetSoundFonts()
        );

        /// <summary>
        ///     Mixes the each sound font using the specified function
        /// </summary>
        /// <param name="function">The function</param>
        /// <param name="data">The data</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_SetTimidityCfg(
            [In, MarshalAs(UnmanagedType.LPStr)] string path
        );

        /* Only available in 2.0.5 or later. */
        /// <summary>
        ///     Internals the mix get timidity cfg
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "Mix_GetTimidityCfg", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr INTERNAL_Mix_GetTimidityCfg();

        /// <summary>
        ///     Mixes the get timidity cfg
        /// </summary>
        /// <returns>The string</returns>
        public static string Mix_GetTimidityCfg() => Sdl.UTF8_ToManaged(
            INTERNAL_Mix_GetTimidityCfg()
        );

        /* IntPtr refers to a Mix_Chunk* */
        /// <summary>
        ///     Mixes the get chunk using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Mix_GetChunk(int channel);

        /// <summary>
        ///     Mixes the close audio
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_CloseAudio();

        /// <summary>
        ///     Mixes the get error
        /// </summary>
        /// <returns>The string</returns>
        public static string Mix_GetError() => Sdl.SDL_GetError();

        /// <summary>
        ///     Mixes the set error using the specified fmt and arglist
        /// </summary>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        public static void Mix_SetError(string fmtAndArglist)
        {
            Sdl.SDL_SetError(fmtAndArglist);
        }

        /// <summary>
        ///     Mixes the clear error
        /// </summary>
        public static void Mix_ClearError()
        {
            Sdl.SDL_ClearError();
        }

        /// <summary>
        ///     The mix chunk
        /// </summary>
        public struct MixChunk
        {
            /// <summary>
            ///     The allocated
            /// </summary>
            public int Allocated;

            /// <summary>
            ///     The abuf
            /// </summary>
            public IntPtr Abuf; /* Uint8* */

            /// <summary>
            ///     The alen
            /// </summary>
            public uint Alen;

            /// <summary>
            ///     The volume
            /// </summary>
            public byte Volume;
        }
    }
}