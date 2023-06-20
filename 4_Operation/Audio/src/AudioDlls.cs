// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioDlls.cs
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

using System.Collections.Generic;
using System.Runtime.InteropServices;
using Alis.Core.Audio.Properties;

namespace Alis.Core.Audio
{
    /// <summary>
    ///     The audio dlls class
    /// </summary>
    public static class AudioDlls
    {
        /// <summary>
        ///     The osx x64 csfml audio
        /// </summary>
        internal static readonly Dictionary<(OSPlatform Platform, Architecture Arch), byte[]> CsfmlAudioDllBytes = new Dictionary<(OSPlatform Platform, Architecture Arch), byte[]>
        {
            {(OSPlatform.Windows, Architecture.X86), NativeAudio.win_x86_csfml_audio},
            {(OSPlatform.Windows, Architecture.X64), NativeAudio.win_x64_csfml_audio},
            {(OSPlatform.Windows, Architecture.Arm), NativeAudio.win_x86_csfml_audio},
            {(OSPlatform.Windows, Architecture.Arm64), NativeAudio.win_x64_csfml_audio},

            {(OSPlatform.Linux, Architecture.X86), NativeAudio.linux_x86_csfml_audio},
            {(OSPlatform.Linux, Architecture.X64), NativeAudio.linux_x64_csfml_audio},
            {(OSPlatform.Linux, Architecture.Arm), NativeAudio.linux_arm64_csfml_audio},
            {(OSPlatform.Linux, Architecture.Arm64), NativeAudio.linux_arm64_csfml_audio},

            {(OSPlatform.OSX, Architecture.X86), NativeAudio.osx_x64_csfml_audio},
            {(OSPlatform.OSX, Architecture.X64), NativeAudio.osx_x64_csfml_audio},
            {(OSPlatform.OSX, Architecture.Arm), NativeAudio.osx_arm64_csfml_audio},
            {(OSPlatform.OSX, Architecture.Arm64), NativeAudio.osx_arm64_csfml_audio}
        };

        /// <summary>
        ///     The osx arm64 sdl2 mixer
        /// </summary>
        internal static readonly Dictionary<(OSPlatform Platform, Architecture Arch), byte[]> SdlAudioDllBytes = new Dictionary<(OSPlatform Platform, Architecture Arch), byte[]>
        {
            {(OSPlatform.Windows, Architecture.X86), NativeAudio.win_x86_sdl2_mixer},
            {(OSPlatform.Windows, Architecture.X64), NativeAudio.win_x64_sdl2_mixer},
            {(OSPlatform.Windows, Architecture.Arm), NativeAudio.win_x86_sdl2_mixer},
            {(OSPlatform.Windows, Architecture.Arm64), NativeAudio.win_x64_sdl2_mixer},

            {(OSPlatform.Linux, Architecture.X86), NativeAudio.linux_x86_sdl2_mixer},
            {(OSPlatform.Linux, Architecture.X64), NativeAudio.linux_x64_sdl2_mixer},
            {(OSPlatform.Linux, Architecture.Arm), NativeAudio.linux_arm64_sdl2_mixer},
            {(OSPlatform.Linux, Architecture.Arm64), NativeAudio.linux_arm64_sdl2_mixer},

            {(OSPlatform.OSX, Architecture.X86), NativeAudio.osx_x64_sdl2_mixer},
            {(OSPlatform.OSX, Architecture.X64), NativeAudio.osx_x64_sdl2_mixer},
            {(OSPlatform.OSX, Architecture.Arm), NativeAudio.osx_arm64_sdl2_mixer},
            {(OSPlatform.OSX, Architecture.Arm64), NativeAudio.osx_arm64_sdl2_mixer}
        };

        /// <summary>
        ///     The win x64 openal32
        /// </summary>
        internal static readonly Dictionary<(OSPlatform Platform, Architecture Arch), byte[]> OpenalAudioDllBytes = new Dictionary<(OSPlatform Platform, Architecture Arch), byte[]>
        {
            {(OSPlatform.Windows, Architecture.X86), NativeAudio.win_x86_openal32},
            {(OSPlatform.Windows, Architecture.X64), NativeAudio.win_x64_openal32},
            {(OSPlatform.Windows, Architecture.Arm), NativeAudio.win_x86_openal32},
            {(OSPlatform.Windows, Architecture.Arm64), NativeAudio.win_x64_openal32}
        };
    }
}