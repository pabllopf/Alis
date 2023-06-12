// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlMixerExtern.cs
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

namespace Alis.Core.Audio.SDL
{
    /// <summary>
    ///     The sdl mixer extern class
    /// </summary>
    public static class SdlMixerExtern
    {
        /// <summary>
        ///     Internals the mix get music title using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlMixer.NativeLibName, EntryPoint = "Mix_GetMusicTitle", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr INTERNAL_Mix_GetMusicTitle(IntPtr music);

        /// <summary>
        ///     Internals the mix get music artist tag using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlMixer.NativeLibName, EntryPoint = "Mix_GetMusicArtistTag", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr INTERNAL_Mix_GetMusicArtistTag(IntPtr music);

        /// <summary>
        ///     Internals the mix get music album tag using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlMixer.NativeLibName, EntryPoint = "Mix_GetMusicAlbumTag", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr INTERNAL_Mix_GetMusicAlbumTag(IntPtr music);

        /// <summary>
        ///     Internals the mix get music copyright tag using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlMixer.NativeLibName, EntryPoint = "Mix_GetMusicCopyrightTag", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr INTERNAL_Mix_GetMusicCopyrightTag(IntPtr music);

        /// <summary>
        ///     Mixes the hook music using the specified mix func
        /// </summary>
        /// <param name="mixFunc">The mix func</param>
        /// <param name="arg">The arg</param>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Mix_HookMusic(
            MixFuncDelegate mixFunc,
            IntPtr arg // void*
        );

        /// <summary>
        ///     Mixes the set post mix using the specified mix func
        /// </summary>
        /// <param name="mixFunc">The mix func</param>
        /// <param name="arg">The arg</param>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Mix_SetPostMix(
            MixFuncDelegate mixFunc,
            IntPtr arg // void*
        );

        /// <summary>
        ///     Mixes the hook music finished using the specified music finished
        /// </summary>
        /// <param name="musicFinished">The music finished</param>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Mix_HookMusicFinished(
            MusicFinishedDelegate musicFinished
        );

        /// <summary>
        ///     Mixes the get music hook data
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr Mix_GetMusicHookData();

        /// <summary>
        ///     Mixes the channel finished using the specified channel finished
        /// </summary>
        /// <param name="channelFinished">The channel finished</param>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Mix_ChannelFinished(
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
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_RegisterEffect(
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
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_UnregisterEffect(
            int channel,
            MixEffectFuncT f
        );

        /// <summary>
        ///     Mixes the unregister all effects using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_UnregisterAllEffects(int channel);

        /// <summary>
        ///     Mixes the set panning using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_SetPanning(
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
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_SetPosition(
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
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_SetDistance(int channel, byte distance);

        /// <summary>
        ///     Mixes the set reverse stereo using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_SetReverseStereo(int channel, int flip);

        /// <summary>
        ///     Mixes the reserve channels using the specified num
        /// </summary>
        /// <param name="num">The num</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_ReserveChannels(int num);

        /// <summary>
        ///     Mixes the group channel using the specified which
        /// </summary>
        /// <param name="which">The which</param>
        /// <param name="tag">The tag</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_GroupChannel(int which, int tag);

        /// <summary>
        ///     Mixes the group channels using the specified from
        /// </summary>
        /// <param name="from">The from</param>
        /// <param name="to">The to</param>
        /// <param name="tag">The tag</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_GroupChannels(int from, int to, int tag);

        /// <summary>
        ///     Mixes the group available using the specified tag
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_GroupAvailable(int tag);

        /// <summary>
        ///     Mixes the group count using the specified tag
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_GroupCount(int tag);

        /// <summary>
        ///     Mixes the group oldest using the specified tag
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_GroupOldest(int tag);

        /// <summary>
        ///     Mixes the group newer using the specified tag
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_GroupNewer(int tag);

        /// <summary>
        ///     Sdls the get error msg using the specified errstr
        /// </summary>
        /// <param name="errstr">The errstr</param>
        /// <param name="maxlength">The maxlength</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr SDL_GetErrorMsg(IntPtr errstr, int maxlength);

        /// <summary>
        ///     Internals the sdl set error using the specified fmt and arglist
        /// </summary>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        [DllImport(SdlMixer.NativeLibName, EntryPoint = "SDL_SetError", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void INTERNAL_SDL_SetError(byte[] fmtAndArglist);

        /// <summary>
        ///     Internals the sdl get error
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(SdlMixer.NativeLibName, EntryPoint = "SDL_GetError", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr INTERNAL_SDL_GetError();

        /// <summary>
        ///     Sdls the free using the specified memblock
        /// </summary>
        /// <param name="memblock">The memblock</param>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SDL_free(IntPtr memblock);

        /// <summary>
        ///     Sdls the clear error
        /// </summary>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SDL_ClearError();

        /// <summary>
        ///     Mixes the close audio
        /// </summary>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Mix_CloseAudio();

        /// <summary>
        ///     Mixes the get chunk using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr Mix_GetChunk(int channel);

        /// <summary>
        ///     Sdls the init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SDL_Init(uint flags);

        /// <summary>
        ///     Sdls the init sub system using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SDL_InitSubSystem(uint flags);

        /// <summary>
        ///     Sdls the quit
        /// </summary>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SDL_Quit();

        /// <summary>
        ///     Mixes the init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_Init(MixInitFlags flags);

        /// <summary>
        ///     Mixes the quit
        /// </summary>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Mix_Quit();

        /// <summary>
        ///     Mixes the open audio using the specified frequency
        /// </summary>
        /// <param name="frequency">The frequency</param>
        /// <param name="format">The format</param>
        /// <param name="channels">The channels</param>
        /// <param name="chunksize">The chunksize</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_OpenAudio(
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
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_AllocateChannels(int numchans);

        /// <summary>
        ///     Mixes the query spec using the specified frequency
        /// </summary>
        /// <param name="frequency">The frequency</param>
        /// <param name="format">The format</param>
        /// <param name="channels">The channels</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_QuerySpec(
            out int frequency,
            out ushort format,
            out int channels
        );

        /// <summary>
        ///     Mixes the load wav rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr Mix_LoadWAV_RW(
            IntPtr src,
            int freesrc
        );

        /// <summary>
        ///     Mixes the each sound font using the specified function
        /// </summary>
        /// <param name="function">The function</param>
        /// <param name="data">The data</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_EachSoundFont(
            SoundFontDelegate function,
            IntPtr data // void*
        );

        /// <summary>
        ///     Mixes the set timidity cfg using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_SetTimidityCfg(
            [In, MarshalAs(UnmanagedType.LPStr)] string path
        );

        /// <summary>
        ///     Internals the mix get timidity cfg
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(SdlMixer.NativeLibName, EntryPoint = "Mix_GetTimidityCfg", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr INTERNAL_Mix_GetTimidityCfg();

        /// <summary>
        ///     Internals the mix get sound fonts
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(SdlMixer.NativeLibName, EntryPoint = "Mix_GetSoundFonts", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr INTERNAL_Mix_GetSoundFonts();

        /// <summary>
        ///     Mixes the get synchro value
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_GetSynchroValue();

        /// <summary>
        ///     Internals the mix set sound fonts using the specified paths
        /// </summary>
        /// <param name="paths">The paths</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, EntryPoint = "Mix_SetSoundFonts", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int INTERNAL_Mix_SetSoundFonts(
            byte[] paths
        );

        /// <summary>
        ///     Mixes the set synchro value using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_SetSynchroValue(int value);

        /// <summary>
        ///     Mixes the fade in channel timed using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <param name="chunk">The chunk</param>
        /// <param name="loops">The loops</param>
        /// <param name="ms">The ms</param>
        /// <param name="ticks">The ticks</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_FadeInChannelTimed(
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
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_Volume(int channel, int volume);

        /// <summary>
        ///     Mixes the volume chunk using the specified chunk
        /// </summary>
        /// <param name="chunk">The chunk</param>
        /// <param name="volume">The volume</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_VolumeChunk(
            IntPtr chunk,
            int volume
        );

        /// <summary>
        ///     Mixes the volume music using the specified volume
        /// </summary>
        /// <param name="volume">The volume</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_VolumeMusic(int volume);

        /// <summary>
        ///     Mixes the get volume music stream using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_GetVolumeMusicStream(IntPtr music);

        /// <summary>
        ///     Mixes the halt channel using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_HaltChannel(int channel);

        /// <summary>
        ///     Mixes the halt group using the specified tag
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_HaltGroup(int tag);

        /// <summary>
        ///     Mixes the halt music
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_HaltMusic();

        /// <summary>
        ///     Mixes the expire channel using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <param name="ticks">The ticks</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_ExpireChannel(int channel, int ticks);

        /// <summary>
        ///     Mixes the fade out channel using the specified which
        /// </summary>
        /// <param name="which">The which</param>
        /// <param name="ms">The ms</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_FadeOutChannel(int which, int ms);

        /// <summary>
        ///     Mixes the fade out group using the specified tag
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <param name="ms">The ms</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_FadeOutGroup(int tag, int ms);

        /// <summary>
        ///     Mixes the fade out music using the specified ms
        /// </summary>
        /// <param name="ms">The ms</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_FadeOutMusic(int ms);

        /// <summary>
        ///     Mixes the fading music
        /// </summary>
        /// <returns>The mix fading</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern MixFading Mix_FadingMusic();

        /// <summary>
        ///     Mixes the fading channel using the specified which
        /// </summary>
        /// <param name="which">The which</param>
        /// <returns>The mix fading</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern MixFading Mix_FadingChannel(int which);

        /// <summary>
        ///     Mixes the pause using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Mix_Pause(int channel);

        /// <summary>
        ///     Mixes the resume using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Mix_Resume(int channel);

        /// <summary>
        ///     Mixes the paused using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_Paused(int channel);

        /// <summary>
        ///     Mixes the pause music
        /// </summary>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Mix_PauseMusic();

        /// <summary>
        ///     Mixes the resume music
        /// </summary>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Mix_ResumeMusic();

        /// <summary>
        ///     Mixes the rewind music
        /// </summary>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Mix_RewindMusic();

        /// <summary>
        ///     Mixes the paused music
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_PausedMusic();

        /// <summary>
        ///     Mixes the set music position using the specified position
        /// </summary>
        /// <param name="position">The position</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_SetMusicPosition(double position);

        /// <summary>
        ///     Mixes the get music position using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The double</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double Mix_GetMusicPosition(IntPtr music);

        /// <summary>
        ///     Mixes the music duration using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The double</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double Mix_MusicDuration(IntPtr music);

        /// <summary>
        ///     Mixes the get music loop start time using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The double</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double Mix_GetMusicLoopStartTime(IntPtr music);

        /// <summary>
        ///     Mixes the get music loop end time using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The double</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double Mix_GetMusicLoopEndTime(IntPtr music);

        /// <summary>
        ///     Mixes the get music loop length time using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The double</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double Mix_GetMusicLoopLengthTime(IntPtr music);

        /// <summary>
        ///     Mixes the playing using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_Playing(int channel);

        /// <summary>
        ///     Mixes the playing music
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_PlayingMusic();

        /// <summary>
        ///     Internals the mix set music cmd using the specified command
        /// </summary>
        /// <param name="command">The command</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, EntryPoint = "Mix_SetMusicCMD", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int INTERNAL_Mix_SetMusicCMD(
            byte[] command
        );

        /// <summary>
        ///     Mixes the play channel timed using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <param name="chunk">The chunk</param>
        /// <param name="loops">The loops</param>
        /// <param name="ticks">The ticks</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_PlayChannelTimed(
            int channel,
            IntPtr chunk,
            int loops,
            int ticks
        );

        /// <summary>
        ///     Mixes the play music using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <param name="loops">The loops</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_PlayMusic(IntPtr music, int loops);

        /// <summary>
        ///     Mixes the fade in music using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <param name="loops">The loops</param>
        /// <param name="ms">The ms</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_FadeInMusic(
            IntPtr music,
            int loops,
            int ms
        );

        /// <summary>
        ///     Mixes the fade in music pos using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <param name="loops">The loops</param>
        /// <param name="ms">The ms</param>
        /// <param name="position">The position</param>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_FadeInMusicPos(
            IntPtr music,
            int loops,
            int ms,
            double position
        );

        /// <summary>
        ///     Mixes the get music type using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The mix music type</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern MixMusicType Mix_GetMusicType(IntPtr music);

        /// <summary>
        ///     Internals the mix get music title tag using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlMixer.NativeLibName, EntryPoint = "Mix_GetMusicTitleTag", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr INTERNAL_Mix_GetMusicTitleTag(IntPtr music);

        /// <summary>
        ///     Mixes the get music artist tag using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The string</returns>
        internal static string Mix_GetMusicArtistTag(IntPtr music) => SdlMixer.UTF8_ToManaged(INTERNAL_Mix_GetMusicArtistTag(music)
        );

        /// <summary>
        ///     Mixes the get num music decoders
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_GetNumMusicDecoders();

        /// <summary>
        ///     Internals the mix get music decoder using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlMixer.NativeLibName, EntryPoint = "Mix_GetMusicDecoder", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr INTERNAL_Mix_GetMusicDecoder(int index);

        /// <summary>
        ///     Mixes the quick load wav using the specified mem
        /// </summary>
        /// <param name="mem">The mem</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr Mix_QuickLoad_WAV(
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1)]
            byte[] mem
        );

        /// <summary>
        ///     Mixes the quick load raw using the specified mem
        /// </summary>
        /// <param name="mem">The mem</param>
        /// <param name="len">The len</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr Mix_QuickLoad_RAW(
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)]
            byte[] mem,
            uint len
        );

        /// <summary>
        ///     Mixes the free chunk using the specified chunk
        /// </summary>
        /// <param name="chunk">The chunk</param>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Mix_FreeChunk(IntPtr chunk);

        /// <summary>
        ///     Mixes the free music using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Mix_FreeMusic(IntPtr music);

        /// <summary>
        ///     Mixes the get num chunk decoders
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(SdlMixer.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Mix_GetNumChunkDecoders();

        /// <summary>
        ///     Internals the mix get chunk decoder using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlMixer.NativeLibName, EntryPoint = "Mix_GetChunkDecoder", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr INTERNAL_Mix_GetChunkDecoder(int index);

        /// <summary>
        ///     Internals the mix linked version
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(SdlMixer.NativeLibName, EntryPoint = "MIX_Linked_Version", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr INTERNAL_MIX_Linked_Version();
    }
}