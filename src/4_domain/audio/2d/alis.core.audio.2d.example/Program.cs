// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Program.cs
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
using System.Diagnostics;
using System.IO;
using System.Threading;
using Alis.Core.Audio;
using Alis.Core.Audio.AL;
using Alis.Core.Audio.ALC;
using Alis.Core.Audio.Extensions.Creative.EnumerateAll;
using Alis.Core.Audio.Extensions.Creative.EnumerateAll.Enums;

namespace Examples
{
    /// <summary>
    /// The playback class
    /// </summary>
    public class Playback
    {
        /// <summary>
        /// The combine
        /// </summary>
        private static readonly string filename = Path.Combine(Path.Combine("Assets"), "menu.wav");

        // Loads a wave/riff audio file.
        /// <summary>
        /// Loads the wave using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="channels">The channels</param>
        /// <param name="bits">The bits</param>
        /// <param name="rate">The rate</param>
        /// <exception cref="NotSupportedException">Specified stream is not a wave file.</exception>
        /// <exception cref="NotSupportedException">Specified stream is not a wave file.</exception>
        /// <exception cref="NotSupportedException">Specified wave file is not supported. fmt header not found.</exception>
        /// <exception cref="ArgumentNullException">stream</exception>
        /// <returns>The byte array</returns>
        public static byte[] LoadWave(Stream stream, out int channels, out int bits, out int rate)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            using (BinaryReader reader = new BinaryReader(stream))
            {
                // RIFF header
                string signature = new string(reader.ReadChars(4));
                if (signature != "RIFF")
                {
                    throw new NotSupportedException("Specified stream is not a wave file.");
                }

                int riff_chunck_size = reader.ReadInt32();

                string format = new string(reader.ReadChars(4));
                if (format != "WAVE")
                {
                    throw new NotSupportedException("Specified stream is not a wave file.");
                }

                // WAVE header
                string format_signature = new string(reader.ReadChars(4));
                if (format_signature != "fmt ")
                {
                    throw new NotSupportedException("Specified wave file is not supported. fmt header not found.");
                }

                int format_chunk_size = reader.ReadInt32();
                int audio_format = reader.ReadInt16();
                int num_channels = reader.ReadInt16();
                int sample_rate = reader.ReadInt32();
                int byte_rate = reader.ReadInt32();
                int block_align = reader.ReadInt16();
                int bits_per_sample = reader.ReadInt16();

                string data_signature = new string(reader.ReadChars(4));
                //if (data_signature != "data")
                //throw new NotSupportedException("Specified wave file is not supported. data data_signature ");

                int data_chunk_size = reader.ReadInt32();

                channels = num_channels;
                bits = bits_per_sample;
                rate = sample_rate;

                return reader.ReadBytes((int) reader.BaseStream.Length);
            }
        }

        /// <summary>
        /// Gets the sound format using the specified channels
        /// </summary>
        /// <param name="channels">The channels</param>
        /// <param name="bits">The bits</param>
        /// <exception cref="NotSupportedException">The specified sound format is not supported.</exception>
        /// <returns>The al format</returns>
        public static ALFormat GetSoundFormat(int channels, int bits)
        {
            switch (channels)
            {
                case 1: return bits == 8 ? ALFormat.Mono8 : ALFormat.Mono16;
                case 2: return bits == 8 ? ALFormat.Stereo8 : ALFormat.Stereo16;
                default: throw new NotSupportedException("The specified sound format is not supported.");
            }
        }

        /// <summary>
        /// Main
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Hello!");
            IEnumerable<string> devices = ALC.GetStringList(GetEnumerationStringList.DeviceSpecifier);
            Console.WriteLine($"Devices: {string.Join(", ", devices)}");

            // Get the default device, then go though all devices and select the AL soft device if it exists.
            string deviceName = ALC.GetString(ALDevice.Null, AlcGetString.DefaultDeviceSpecifier);
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

            ALDevice device = ALC.OpenDevice(deviceName);
            ALContext context = ALC.CreateContext(device, (int[]) null);
            ALC.MakeContextCurrent(context);

            ALC.GetInteger(device, AlcGetInteger.MajorVersion, 1, out int alcMajorVersion);
            ALC.GetInteger(device, AlcGetInteger.MinorVersion, 1, out int alcMinorVersion);
            string alcExts = ALC.GetString(device, AlcGetString.Extensions);

            ALContextAttributes attrs = ALC.GetContextAttributes(device);
            Console.WriteLine($"Attributes: {attrs}");

            string exts = AL.Get(ALGetString.Extensions);
            string rend = AL.Get(ALGetString.Renderer);
            string vend = AL.Get(ALGetString.Vendor);
            string vers = AL.Get(ALGetString.Version);

            Console.WriteLine(
                $"Vendor: {vend}, \nVersion: {vers}, \nRenderer: {rend}, \nExtensions: {exts}, \nALC Version: {alcMajorVersion}.{alcMinorVersion}, \nALC Extensions: {alcExts}");


            Console.WriteLine("Available devices: ");
            IEnumerable<string> list = EnumerateAll.GetStringList(GetEnumerateAllContextStringList.AllDevicesSpecifier);
            foreach (string item in list)
            {
                Console.WriteLine("  " + item);
            }

            Console.WriteLine("Available capture devices: ");
            list = ALC.GetStringList(GetEnumerationStringList.CaptureDeviceSpecifier);
            foreach (string item in list)
            {
                Console.WriteLine("  " + item);
            }

            Console.WriteLine("LOAD FILE:" + filename);

            int buffer = AL.GenBuffer();
            int source = AL.GenSource();
            int state;

            int channels, bits_per_sample, sample_rate;
            byte[] sound_data = LoadWave(File.Open(filename, FileMode.Open), out channels, out bits_per_sample,
                out sample_rate);
            AL.BufferData(buffer, GetSoundFormat(channels, bits_per_sample), sound_data, sound_data.Length,
                sample_rate);

            AL.Source(source, ALSourcei.Buffer, buffer);
            AL.SourcePlay(source);

            Trace.Write("Playing");

            // Query the source to find out when it stops playing.
            do
            {
                Thread.Sleep(250);
                Trace.Write(".");
                AL.GetSource(source, ALGetSourcei.SourceState, out state);
            } while ((ALSourceState) state == ALSourceState.Playing);

            Trace.WriteLine("");

            AL.SourceStop(source);
            AL.DeleteSource(source);
            AL.DeleteBuffer(buffer);


            ALC.MakeContextCurrent(ALContext.Null);
            ALC.DestroyContext(context);
            ALC.CloseDevice(device);

            Console.WriteLine("Goodbye!");
        }
    }
}