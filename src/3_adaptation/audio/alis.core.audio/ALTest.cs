// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ALTest.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading;
using Alis.Core.Audio.AL;
using Alis.Core.Audio.ALC;
using Alis.Core.Audio.Extensions.Creative.EFX;
using Alis.Core.Audio.Extensions.Creative.EFX.Enums;
using Alis.Core.Audio.Extensions.Creative.EnumerateAll;
using Alis.Core.Audio.Extensions.Creative.EnumerateAll.Enums;
using Alis.Core.Audio.Extensions.SOFT.DeviceClock;
using Alis.Core.Audio.Extensions.SOFT.DeviceClock.Enums;
using Alis.Core.Audio.Extensions.SOFT.SourceLatency;
using Alis.Core.Audio.Extensions.SOFT.SourceLatency.Enums;
using Alis.Core.Audio.Mathematics.Vector;

namespace Alis.Core.Audio
{
    internal class ALTest
    {
        public static void Main()
        {
            Console.WriteLine("Hello!");
            IEnumerable<string> devices = ALC.ALC.GetStringList(GetEnumerationStringList.DeviceSpecifier);
            Console.WriteLine($"Devices: {string.Join(", ", devices)}");

            // Get the default device, then go though all devices and select the AL soft device if it exists.
            string deviceName = ALC.ALC.GetString(ALDevice.Null, AlcGetString.DefaultDeviceSpecifier);
            foreach (string d in devices)
            {
                if (d.Contains("OpenAL Soft"))
                {
                    deviceName = d;
                }
            }

            IEnumerable<string> allDevices =
                EnumerateAll.GetStringList(GetEnumerateAllContextStringList.AllDevicesSpecifier);
            Console.WriteLine($"All Devices: {string.Join(", ", allDevices)}");

            ALDevice device = ALC.ALC.OpenDevice(deviceName);
            ALContext context = ALC.ALC.CreateContext(device, (int[]) null);
            ALC.ALC.MakeContextCurrent(context);

            CheckALError("Start");

            ALC.ALC.GetInteger(device, AlcGetInteger.MajorVersion, 1, out int alcMajorVersion);
            ALC.ALC.GetInteger(device, AlcGetInteger.MinorVersion, 1, out int alcMinorVersion);
            string alcExts = ALC.ALC.GetString(device, AlcGetString.Extensions);

            ALContextAttributes attrs = ALC.ALC.GetContextAttributes(device);
            Console.WriteLine($"Attributes: {attrs}");

            string exts = AL.AL.Get(ALGetString.Extensions);
            string rend = AL.AL.Get(ALGetString.Renderer);
            string vend = AL.AL.Get(ALGetString.Vendor);
            string vers = AL.AL.Get(ALGetString.Version);

            Console.WriteLine(
                $"Vendor: {vend}, \nVersion: {vers}, \nRenderer: {rend}, \nExtensions: {exts}, \nALC Version: {alcMajorVersion}.{alcMinorVersion}, \nALC Extensions: {alcExts}");

            Console.WriteLine("Available devices: ");
            IEnumerable<string> list = EnumerateAll.GetStringList(GetEnumerateAllContextStringList.AllDevicesSpecifier);
            foreach (string item in list)
            {
                Console.WriteLine("  " + item);
            }

            Console.WriteLine("Available capture devices: ");
            list = ALC.ALC.GetStringList(GetEnumerationStringList.CaptureDeviceSpecifier);
            foreach (string item in list)
            {
                Console.WriteLine("  " + item);
            }

            int auxSlot = 0;
            if (EFX.IsExtensionPresent(device))
            {
                Console.WriteLine("EFX extension is present!!");
                EFX.GenEffect(out int effect);
                EFX.Effect(effect, EffectInteger.EffectType, (int) EffectType.Reverb);
                EFX.GenAuxiliaryEffectSlot(out auxSlot);
                EFX.AuxiliaryEffectSlot(auxSlot, EffectSlotInteger.Effect, effect);
            }

            // Record a second of data
            CheckALError("Before record");
            short[] recording = new short[44100 * 4];
            ALCaptureDevice captureDevice = ALC.ALC.CaptureOpenDevice(null, 44100, ALFormat.Mono16, 1024);
            {
                ALC.ALC.CaptureStart(captureDevice);

                int current = 0;
                while (current < recording.Length)
                {
                    int samplesAvailable = ALC.ALC.GetAvailableSamples(captureDevice);
                    if (samplesAvailable > 512)
                    {
                        int samplesToRead = Math.Min(samplesAvailable, recording.Length - current);
                        ALC.ALC.CaptureSamples(captureDevice, ref recording[current], samplesToRead);
                        current += samplesToRead;
                    }

                    Thread.Yield();
                }

                ALC.ALC.CaptureStop(captureDevice);
            }
            CheckALError("After record");

            // Playback the recorded data
            CheckALError("Before data");
            AL.AL.GenBuffer(out int alBuffer);
            // short[] sine = new short[44100 * 1];
            // FillSine(sine, 4400, 44100);
            // FillSine(recording, 440, 44100);
            AL.AL.BufferData(alBuffer, ALFormat.Mono16, ref recording[0], recording.Length * 2, 44100);
            CheckALError("After data");

            AL.AL.Listener(ALListenerf.Gain, 0.1f);

            AL.AL.GenSource(out int alSource);
            AL.AL.Source(alSource, ALSourcef.Gain, 1f);
            AL.AL.Source(alSource, ALSourcei.Buffer, alBuffer);
            if (EFX.IsExtensionPresent(device))
            {
                EFX.Source(alSource, EFXSourceInteger3.AuxiliarySendFilter, auxSlot, 0, 0);
            }

            AL.AL.SourcePlay(alSource);

            Console.WriteLine("Before Playing: " + AL.AL.GetErrorString(AL.AL.GetError()));

            if (DeviceClock.IsExtensionPresent(device))
            {
                long[] clockLatency = new long[2];
                DeviceClock.GetInteger(device, GetInteger64.DeviceClock, clockLatency);
                Console.WriteLine("Clock: " + clockLatency[0] + ", Latency: " + clockLatency[1]);
                CheckALError(" ");
            }

            if (SourceLatency.IsExtensionPresent())
            {
                SourceLatency.GetSource(alSource, SourceLatencyVector2d.SecOffsetLatency, out Vector2d values);
                SourceLatency.GetSource(alSource, SourceLatencyVector2i.SampleOffsetLatency, out int values1,
                    out int values2, out long values3);
                Console.WriteLine("Source latency: " + values);
                Console.WriteLine($"Source latency 2: {Convert.ToString(values1, 2)}, {values2}; {values3}");
                CheckALError(" ");
            }

            while (AL.AL.GetSourceState(alSource) == ALSourceState.Playing)
            {
                if (SourceLatency.IsExtensionPresent())
                {
                    SourceLatency.GetSource(alSource, SourceLatencyVector2d.SecOffsetLatency, out Vector2d values);
                    SourceLatency.GetSource(alSource, SourceLatencyVector2i.SampleOffsetLatency, out int values1,
                        out int values2, out long values3);
                    Console.WriteLine("Source latency: " + values);
                    Console.WriteLine($"Source latency 2: {Convert.ToString(values1, 2)}, {values2}; {values3}");
                    CheckALError(" ");
                }

                if (DeviceClock.IsExtensionPresent(device))
                {
                    long[] clockLatency = new long[2];
                    DeviceClock.GetInteger(device, GetInteger64.DeviceClock, 1, clockLatency);
                    Console.WriteLine("Clock: " + clockLatency[0] + ", Latency: " + clockLatency[1]);
                    CheckALError(" ");
                }

                Thread.Sleep(10);
            }

            AL.AL.SourceStop(alSource);

            Console.WriteLine("Goodbye!");

            ALC.ALC.MakeContextCurrent(ALContext.Null);
            ALC.ALC.DestroyContext(context);
            ALC.ALC.CloseDevice(device);
        }

        public static void CheckALError(string str)
        {
            ALError error = AL.AL.GetError();
            if (error != ALError.NoError)
            {
                Console.WriteLine($"ALError at '{str}': {AL.AL.GetErrorString(error)}");
            }
        }

        public static void FillSine(short[] buffer, float frequency, float sampleRate)
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (short) (MathF.Sin(i * frequency * MathF.PI * 2 / sampleRate) * short.MaxValue);
            }
        }
    }
}