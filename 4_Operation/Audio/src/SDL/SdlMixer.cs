// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlMixer.cs
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
    public static class SdlMixer
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SdlMixer" /> class
        /// </summary>
        static SdlMixer()
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

        /// <summary>
        ///     The native lib name
        /// </summary>
        internal const string NativeLibName = "sdl2_mixer";

        /// <summary>
        ///     The sdl init timer
        /// </summary>
        public const uint SdlInitTimer = 0x00000001;

        /// <summary>
        ///     The sdl init audio
        /// </summary>
        public const uint SdlInitAudio = 0x00000010;

        /// <summary>
        ///     The sdl init video
        /// </summary>
        public const uint SdlInitVideo = 0x00000020;

        /// <summary>
        ///     The sdl init joystick
        /// </summary>
        public const uint SdlInitJoystick = 0x00000200;

        /// <summary>
        ///     The sdl init haptic
        /// </summary>
        public const uint SdlInitHaptic = 0x00001000;

        /// <summary>
        ///     The sdl init gamecontroller
        /// </summary>
        public const uint SdlInitGamecontroller = 0x00002000;

        /// <summary>
        ///     The sdl init events
        /// </summary>
        public const uint SdlInitEvents = 0x00004000;

        /// <summary>
        ///     The sdl init sensor
        /// </summary>
        public const uint SdlInitSensor = 0x00008000;

        /// <summary>
        ///     The sdl init noparachute
        /// </summary>
        public const uint SdlInitNoparachute = 0x00100000;

        /// <summary>
        ///     The sdl init sensor
        /// </summary>
        public const uint SdlInitEverything = SdlInitTimer | SdlInitAudio | SdlInitVideo |
                                              SdlInitEvents | SdlInitJoystick | SdlInitHaptic |
                                              SdlInitGamecontroller | SdlInitSensor;

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

        /// <summary>
        ///     The mix channels
        /// </summary>
        public const int MixChannels = 8;

        /// <summary>
        ///     The audio u8
        /// </summary>
        public const ushort AudioU8 = 0x0008;

        /// <summary>
        ///     The audio s8
        /// </summary>
        public const ushort AudioS8 = 0x8008;

        /// <summary>
        ///     The audio u16lsb
        /// </summary>
        public const ushort AudioU16Lsb = 0x0010;

        /// <summary>
        ///     The audio s16lsb
        /// </summary>
        public const ushort AudioS16Lsb = 0x8010;

        /// <summary>
        ///     The audio u16msb
        /// </summary>
        public const ushort AudioU16Msb = 0x1010;

        /// <summary>
        ///     The audio s16msb
        /// </summary>
        public const ushort AudioS16Msb = 0x9010;

        /// <summary>
        ///     The audio u16lsb
        /// </summary>
        public const ushort AudioU16 = AudioU16Lsb;

        /// <summary>
        ///     The audio s16lsb
        /// </summary>
        public const ushort AudioS16 = AudioS16Lsb;

        /// <summary>
        ///     The audio s32lsb
        /// </summary>
        public const ushort AudioS32Lsb = 0x8020;

        /// <summary>
        ///     The audio s32msb
        /// </summary>
        public const ushort AudioS32Msb = 0x9020;

        /// <summary>
        ///     The audio s32lsb
        /// </summary>
        public const ushort AudioS32 = AudioS32Lsb;

        /// <summary>
        ///     The audio f32lsb
        /// </summary>
        public const ushort AudioF32Lsb = 0x8120;

        /// <summary>
        ///     The audio f32msb
        /// </summary>
        public const ushort AudioF32Msb = 0x9120;

        /// <summary>
        ///     The audio f32lsb
        /// </summary>
        public const ushort AudioF32 = AudioF32Lsb;

        /// <summary>
        ///     The sdl audio allow frequency change
        /// </summary>
        public const uint SdlAudioAllowFrequencyChange = 0x00000001;

        /// <summary>
        ///     The sdl audio allow format change
        /// </summary>
        public const uint SdlAudioAllowFormatChange = 0x00000002;

        /// <summary>
        ///     The sdl audio allow channels change
        /// </summary>
        public const uint SdlAudioAllowChannelsChange = 0x00000004;

        /// <summary>
        ///     The sdl audio allow samples change
        /// </summary>
        public const uint SdlAudioAllowSamplesChange = 0x00000008;

        /// <summary>
        ///     The sdl audio allow samples change
        /// </summary>
        public const uint SdlAudioAllowAnyChange = SdlAudioAllowFrequencyChange |
                                                   SdlAudioAllowFormatChange |
                                                   SdlAudioAllowChannelsChange |
                                                   SdlAudioAllowSamplesChange;

        /// <summary>
        ///     The sdl mix maxvolume
        /// </summary>
        public const int SdlMixMaxvolume = 128;

        /// <summary>
        ///     The mix default frequency
        /// </summary>
        public static readonly int MixDefaultFrequency = 44100;

        /// <summary>
        ///     The audio s16msb
        /// </summary>
        public static readonly ushort MixDefaultFormat =
            BitConverter.IsLittleEndian ? AudioS16Lsb : AudioS16Msb;

        /// <summary>
        ///     The mix default channels
        /// </summary>
        public static readonly int MixDefaultChannels = 2;

        /// <summary>
        ///     The mix max volume
        /// </summary>
        public static readonly byte MixMaxVolume = 128;

        /// <summary>
        ///     The audio u16msb
        /// </summary>
        public static readonly ushort AudioU16Sys =
            BitConverter.IsLittleEndian ? AudioU16Lsb : AudioU16Msb;

        /// <summary>
        ///     The audio s16msb
        /// </summary>
        public static readonly ushort AudioS16Sys =
            BitConverter.IsLittleEndian ? AudioS16Lsb : AudioS16Msb;

        /// <summary>
        ///     The audio s32msb
        /// </summary>
        public static readonly ushort AudioS32Sys =
            BitConverter.IsLittleEndian ? AudioS32Lsb : AudioS32Msb;

        /// <summary>
        ///     The audio f32msb
        /// </summary>
        public static readonly ushort AudioF32Sys =
            BitConverter.IsLittleEndian ? AudioF32Lsb : AudioF32Msb;


        /// <summary>
        ///     Sdls the mixer version using the specified x
        /// </summary>
        /// <param name="x">The </param>
        public static void SDL_MIXER_VERSION(out SdlVersion x)
        {
            x.major = SdlMixerMajorVersion;
            x.minor = SdlMixerMinorVersion;
            x.patch = SdlMixerPatchlevel;
        }

        /// <summary>
        ///     Mixes the linked version
        /// </summary>
        /// <returns>The result</returns>
        public static SdlVersion MIX_Linked_Version()
        {
            SdlVersion result;
            IntPtr resultPtr = SdlMixerExtern.INTERNAL_MIX_Linked_Version();
            result = (SdlVersion) Marshal.PtrToStructure(
                resultPtr,
                typeof(SdlVersion)
            );
            return result;
        }

        /// <summary>
        ///     Internals the sdl rw from file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RWFromFile", CallingConvention = CallingConvention.Cdecl)]
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
            byte* utf8File = Utf8EncodeHeap(file);
            IntPtr handle = INTERNAL_Mix_LoadMUS(
                utf8File
            );
            Marshal.FreeHGlobal((IntPtr) utf8File);
            return handle;
        }

        /// <summary>
        ///     Mixes the get chunk decoder using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        public static string Mix_GetChunkDecoder(int index) => UTF8_ToManaged(SdlMixerExtern.INTERNAL_Mix_GetChunkDecoder(index)
        );

        /// <summary>
        ///     Mixes the get music decoder using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        public static string Mix_GetMusicDecoder(int index) => UTF8_ToManaged(SdlMixerExtern.INTERNAL_Mix_GetMusicDecoder(index)
        );

        /// <summary>
        ///     Mixes the get music title using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The string</returns>
        public static string Mix_GetMusicTitle(IntPtr music) => UTF8_ToManaged(SdlMixerExtern.INTERNAL_Mix_GetMusicTitle(music)
        );

        /// <summary>
        ///     Mixes the get music title tag using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The string</returns>
        public static string Mix_GetMusicTitleTag(IntPtr music) => UTF8_ToManaged(
            SdlMixerExtern.INTERNAL_Mix_GetMusicTitleTag(music)
        );

        /// <summary>
        ///     Mixes the get music album tag using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The string</returns>
        public static string Mix_GetMusicAlbumTag(IntPtr music) => UTF8_ToManaged(SdlMixerExtern.INTERNAL_Mix_GetMusicAlbumTag(music)
        );

        /// <summary>
        ///     Mixes the get music copyright tag using the specified music
        /// </summary>
        /// <param name="music">The music</param>
        /// <returns>The string</returns>
        public static string Mix_GetMusicCopyrightTag(IntPtr music) => UTF8_ToManaged(SdlMixerExtern.INTERNAL_Mix_GetMusicCopyrightTag(music)
        );

        /* IntPtr refers to a void* */

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
            => SdlMixerExtern.Mix_PlayChannelTimed(channel, chunk, loops, -1);

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
            => SdlMixerExtern.Mix_FadeInChannelTimed(channel, chunk, loops, ms, -1);

        /// <summary>
        ///     Mixes the set music cmd using the specified command
        /// </summary>
        /// <param name="command">The command</param>
        /// <returns>The result</returns>
        public static unsafe int Mix_SetMusicCMD(string command)
        {
            byte* utf8Cmd = Utf8EncodeHeap(command);
            int result = SdlMixerExtern.INTERNAL_Mix_SetMusicCMD(
                utf8Cmd
            );
            Marshal.FreeHGlobal((IntPtr) utf8Cmd);
            return result;
        }

        /// <summary>
        ///     Mixes the set sound fonts using the specified paths
        /// </summary>
        /// <param name="paths">The paths</param>
        /// <returns>The result</returns>
        public static unsafe int Mix_SetSoundFonts(string paths)
        {
            byte* utf8Paths = Utf8EncodeHeap(paths);
            int result = SdlMixerExtern.INTERNAL_Mix_SetSoundFonts(
                utf8Paths
            );
            Marshal.FreeHGlobal((IntPtr) utf8Paths);
            return result;
        }

        /// <summary>
        ///     Mixes the get sound fonts
        /// </summary>
        /// <returns>The string</returns>
        public static string Mix_GetSoundFonts() => UTF8_ToManaged(SdlMixerExtern.INTERNAL_Mix_GetSoundFonts()
        );

        /* Only available in 2.0.5 or later. */

        /* Only available in 2.0.5 or later. */

        /// <summary>
        ///     Mixes the get timidity cfg
        /// </summary>
        /// <returns>The string</returns>
        public static string Mix_GetTimidityCfg() => UTF8_ToManaged(SdlMixerExtern.INTERNAL_Mix_GetTimidityCfg()
        );

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
            SdlMixerExtern.SDL_ClearError();
        }

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
                SdlMixerExtern.SDL_free(s);
            }

            return result;
        }

        /// <summary>
        ///     Sdls the get error
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_GetError() => UTF8_ToManaged(SdlMixerExtern.INTERNAL_SDL_GetError());

        /// <summary>
        ///     Sdls the set error using the specified fmt and arglist
        /// </summary>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        public static unsafe void SDL_SetError(string fmtAndArglist)
        {
            int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
            byte* utf8FmtAndArglist = stackalloc byte[utf8FmtAndArglistBufSize];
            SdlMixerExtern.INTERNAL_SDL_SetError(
                Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
            );
        }

        /// <summary>
        ///     Mixes the load wav using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        public static IntPtr Mix_LoadWAV(string file)
        {
            IntPtr rwops = SDL_RWFromFile(file, "rb");
            return SdlMixerExtern.Mix_LoadWAV_RW(rwops, 1);
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
    }
}