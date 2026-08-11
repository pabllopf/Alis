// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sdl2AudioCoverageTests.cs
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
using Alis.Extension.Graphic.Sdl2.Enums;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Coverage tests for audio device, stream and mixing methods
    /// </summary>
    public class Sdl2AudioCoverageTests
    {
        /// <summary>
        ///     Tests that audio device functions work after audio initialization
        /// </summary>
        [Fact]
        public void AudioDeviceFunctions_Work()
        {
            Sdl.Init(InitSettings.InitAudio);
            Sdl.GetAudioDeviceName(0, 0);
            Sdl.GetAudioDeviceStatus(0);
            Sdl.CloseAudioDevice(0);
            Sdl.SdlPauseAudio(1);
            Sdl.SdlPauseAudio(0);
            Sdl.SdlPauseAudioDevice(0, 1);
            Sdl.SdlUnlockAudioDevice(0);
            Sdl.LockAudioDevice(0);
            byte[] mix = new byte[64];
            Sdl.MixAudio(mix, mix, 64, 128);
            Sdl.MixAudioFormat(IntPtr.Zero, IntPtr.Zero, Sdl.GlAudioS16Sys, 0, 128);
            Sdl.MixAudioFormat(mix, mix, Sdl.GlAudioS16Sys, 64, 128);
            AudioSpec desired = new AudioSpec
            {
                Freq = 44100,
                Format = Sdl.GlAudioS16Sys,
                Channels = 2,
                Samples = 4096,
                Callback = null,
                Userdata = IntPtr.Zero
            };
            AudioSpec obtained;
            uint device = Sdl.OpenAudioDevice(IntPtr.Zero, 0, ref desired, out obtained, 0);
            Sdl.SdlOpenAudioDevice("", 0, ref desired, out obtained, 0);
            if (device != 0)
            {
                Sdl.LockAudioDevice(device);
                Sdl.SdlPauseAudioDevice(device, 1);
                Sdl.SdlUnlockAudioDevice(device);
                Sdl.CloseAudioDevice(device);
            }
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that audio stream functions work without audio initialization
        /// </summary>
        [Fact]
        public void AudioStreamFunctions_Work()
        {
            IntPtr stream = Sdl.SdlNewAudioStream(Sdl.GlAudioS16Sys, 2, 44100, Sdl.GlAudioS16Sys, 2, 44100);
            if (stream != IntPtr.Zero)
            {
                Sdl.SdlAudioStreamAvailable(stream);
                Sdl.SdlAudioStreamPut(stream, IntPtr.Zero, 0);
                Sdl.SdlAudioStreamGet(stream, IntPtr.Zero, 0);
                Sdl.SdlAudioStreamClear(stream);
                Sdl.SdlFreeAudioStream(stream);
            }
        }

        /// <summary>
        ///     Tests that a wav file can be loaded and audio queued
        /// </summary>
        [Fact]
        public void LoadWav_AndQueueAudio_Work()
        {
            string file = Sdl2TestAssets.Find("AudioSample.wav");
            if (file == null)
            {
                return;
            }
            IntPtr spec = Sdl.LoadWav(file, out AudioSpec audioSpec, out IntPtr audioBuf, out uint audioLen);
            Assert.NotEqual(IntPtr.Zero, spec);
            Assert.True(audioLen > 0);
            Sdl.QueueAudio(0, new byte[8], 8);
        }
    }
}
