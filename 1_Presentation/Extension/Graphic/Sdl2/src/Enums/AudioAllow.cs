// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioAllow.cs
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

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The audio allow enum
    /// </summary>
    public enum AudioAllow : uint
    {
    /// <summary>
    ///     Allow the audio device frequency to be changed
    /// </summary>
    AudioAllowFrequencyChange = 0x00000001,

    /// <summary>
    ///     Allow the audio device sample format to be changed
    /// </summary>
    AudioAllowFormatChange = 0x00000002,

    /// <summary>
    ///     Allow the audio device channel count to be changed
    /// </summary>
    AudioAllowChannelsChange = 0x00000004,

    /// <summary>
    ///     Allow the audio device sample buffer size to be changed
    /// </summary>
    AudioAllowSamplesChange = 0x00000008,

    /// <summary>
    ///     Allow any audio device specification parameter to be changed
    /// </summary>
    AudioAllowAnyChange = AudioAllowFrequencyChange | AudioAllowFormatChange | AudioAllowChannelsChange | AudioAllowSamplesChange
    }
}