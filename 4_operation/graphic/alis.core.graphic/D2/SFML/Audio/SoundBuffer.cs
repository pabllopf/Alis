// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   SoundBuffer.cs
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
using System.IO;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.D2.SFML.Graphics;

namespace Alis.Core.Graphic.D2.SFML.Audio
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     Storage for audio samples defining a sound
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class SoundBuffer : ObjectBase
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct a sound buffer from a file
        ///     Here is a complete list of all the supported audio formats:
        ///     ogg, wav, flac, aiff, au, raw, paf, svx, nist, voc, ircam,
        ///     w64, mat4, mat5 pvf, htk, sds, avr, sd2, caf, wve, mpc2k, rf64.
        /// </summary>
        /// <param name="filename">Path of the sound file to load</param>
        /// <exception cref="LoadingFailedException" />
        ////////////////////////////////////////////////////////////
        public SoundBuffer(string filename) :
            base(sfSoundBuffer_createFromFile(filename))
        {
            if (CPointer == IntPtr.Zero)
            {
                throw new LoadingFailedException("sound buffer", filename);
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct a sound buffer from a custom stream.
        ///     Here is a complete list of all the supported audio formats:
        ///     ogg, wav, flac, aiff, au, raw, paf, svx, nist, voc, ircam,
        ///     w64, mat4, mat5 pvf, htk, sds, avr, sd2, caf, wve, mpc2k, rf64.
        /// </summary>
        /// <param name="stream">Source stream to read from</param>
        /// <exception cref="LoadingFailedException" />
        ////////////////////////////////////////////////////////////
        public SoundBuffer(Stream stream) :
            base(IntPtr.Zero)
        {
            using (StreamAdaptor adaptor = new StreamAdaptor(stream))
            {
                CPointer = sfSoundBuffer_createFromStream(adaptor.InputStreamPtr);
            }

            if (CPointer == IntPtr.Zero)
            {
                throw new LoadingFailedException("sound buffer");
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct a sound buffer from a file in memory.
        ///     Here is a complete list of all the supported audio formats:
        ///     ogg, wav, flac, aiff, au, raw, paf, svx, nist, voc, ircam,
        ///     w64, mat4, mat5 pvf, htk, sds, avr, sd2, caf, wve, mpc2k, rf64.
        /// </summary>
        /// <param name="bytes">Byte array containing the file contents</param>
        /// <exception cref="LoadingFailedException" />
        ////////////////////////////////////////////////////////////
        public SoundBuffer(byte[] bytes) :
            base(IntPtr.Zero)
        {
            GCHandle pin = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                CPointer = sfSoundBuffer_createFromMemory(pin.AddrOfPinnedObject(), Convert.ToUInt64(bytes.Length));
            }
            finally
            {
                pin.Free();
            }

            if (CPointer == IntPtr.Zero)
            {
                throw new LoadingFailedException("sound buffer");
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct a sound buffer from an array of samples
        /// </summary>
        /// <param name="samples">Array of samples</param>
        /// <param name="channelCount">Channel count</param>
        /// <param name="sampleRate">Sample rate</param>
        /// <exception cref="LoadingFailedException" />
        ////////////////////////////////////////////////////////////
        public SoundBuffer(short[] samples, uint channelCount, uint sampleRate) :
            base(IntPtr.Zero)
        {
            unsafe
            {
                fixed (short* SamplesPtr = samples)
                {
                    CPointer = sfSoundBuffer_createFromSamples(SamplesPtr, (uint) samples.Length, channelCount,
                        sampleRate);
                }
            }

            if (CPointer == IntPtr.Zero)
            {
                throw new LoadingFailedException("sound buffer");
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct a sound buffer from another sound buffer
        /// </summary>
        /// <param name="copy">Sound buffer to copy</param>
        ////////////////////////////////////////////////////////////
        public SoundBuffer(SoundBuffer copy) :
            base(sfSoundBuffer_copy(copy.CPointer))
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Sample rate of the sound buffer.
        ///     The sample rate is the number of audio samples played per
        ///     second. The higher, the better the quality.
        /// </summary>
        ////////////////////////////////////////////////////////////
        public uint SampleRate => sfSoundBuffer_getSampleRate(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Number of channels (1 = mono, 2 = stereo)
        /// </summary>
        ////////////////////////////////////////////////////////////
        public uint ChannelCount => sfSoundBuffer_getChannelCount(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Total duration of the buffer
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Time Duration => sfSoundBuffer_getDuration(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Array of audio samples stored in the buffer.
        ///     The format of the returned samples is 16 bits signed integer
        ///     (sf::Int16).
        /// </summary>
        ////////////////////////////////////////////////////////////
        public short[] Samples
        {
            get
            {
                short[] SamplesArray = new short[sfSoundBuffer_getSampleCount(CPointer)];
                Marshal.Copy(sfSoundBuffer_getSamples(CPointer), SamplesArray, 0, SamplesArray.Length);
                return SamplesArray;
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Save the sound buffer to an audio file.
        ///     Here is a complete list of all the supported audio formats:
        ///     ogg, wav, flac, aiff, au, raw, paf, svx, nist, voc, ircam,
        ///     w64, mat4, mat5 pvf, htk, sds, avr, sd2, caf, wve, mpc2k, rf64.
        /// </summary>
        /// <param name="filename">Path of the sound file to write</param>
        /// <returns>True if saving has been successful</returns>
        ////////////////////////////////////////////////////////////
        public bool SaveToFile(string filename)
        {
            return sfSoundBuffer_saveToFile(CPointer, filename);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString()
        {
            return "[SoundBuffer]" +
                   " SampleRate(" + SampleRate + ")" +
                   " ChannelCount(" + ChannelCount + ")" +
                   " Duration(" + Duration + ")";
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        ////////////////////////////////////////////////////////////
        protected override void Destroy(bool disposing)
        {
            sfSoundBuffer_destroy(CPointer);
        }

        /// <summary>
        ///     Sfs the sound buffer create from file using the specified filename
        /// </summary>
        /// <param name="Filename">The filename</param>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl)]
         [SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfSoundBuffer_createFromFile(string Filename);

        /// <summary>
        ///     Sfs the sound buffer create from stream using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl)]
         [SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfSoundBuffer_createFromStream(IntPtr stream);

        /// <summary>
        ///     Sfs the sound buffer create from memory using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl)]
         [SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfSoundBuffer_createFromMemory(IntPtr data, ulong size);

        /// <summary>
        ///     Sfs the sound buffer create from samples using the specified samples
        /// </summary>
        /// <param name="Samples">The samples</param>
        /// <param name="SampleCount">The sample count</param>
        /// <param name="ChannelsCount">The channels count</param>
        /// <param name="SampleRate">The sample rate</param>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl)]
         [SuppressUnmanagedCodeSecurity]
        private static extern unsafe IntPtr sfSoundBuffer_createFromSamples(short* Samples, uint SampleCount,
            uint ChannelsCount, uint SampleRate);

        /// <summary>
        ///     Sfs the sound buffer copy using the specified sound buffer
        /// </summary>
        /// <param name="SoundBuffer">The sound buffer</param>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl)]
         [SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfSoundBuffer_copy(IntPtr SoundBuffer);

        /// <summary>
        ///     Sfs the sound buffer destroy using the specified sound buffer
        /// </summary>
        /// <param name="SoundBuffer">The sound buffer</param>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl)]
         [SuppressUnmanagedCodeSecurity]
        private static extern void sfSoundBuffer_destroy(IntPtr SoundBuffer);

        /// <summary>
        ///     Describes whether sf sound buffer save to file
        /// </summary>
        /// <param name="SoundBuffer">The sound buffer</param>
        /// <param name="Filename">The filename</param>
        /// <returns>The bool</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl)]
         [SuppressUnmanagedCodeSecurity]
        private static extern bool sfSoundBuffer_saveToFile(IntPtr SoundBuffer, string Filename);

        /// <summary>
        ///     Sfs the sound buffer get samples using the specified sound buffer
        /// </summary>
        /// <param name="SoundBuffer">The sound buffer</param>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl)]
         [SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfSoundBuffer_getSamples(IntPtr SoundBuffer);

        /// <summary>
        ///     Sfs the sound buffer get sample count using the specified sound buffer
        /// </summary>
        /// <param name="SoundBuffer">The sound buffer</param>
        /// <returns>The uint</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl)]
         [SuppressUnmanagedCodeSecurity]
        private static extern uint sfSoundBuffer_getSampleCount(IntPtr SoundBuffer);

        /// <summary>
        ///     Sfs the sound buffer get sample rate using the specified sound buffer
        /// </summary>
        /// <param name="SoundBuffer">The sound buffer</param>
        /// <returns>The uint</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl)]
         [SuppressUnmanagedCodeSecurity]
        private static extern uint sfSoundBuffer_getSampleRate(IntPtr SoundBuffer);

        /// <summary>
        ///     Sfs the sound buffer get channel count using the specified sound buffer
        /// </summary>
        /// <param name="SoundBuffer">The sound buffer</param>
        /// <returns>The uint</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl)]
         [SuppressUnmanagedCodeSecurity]
        private static extern uint sfSoundBuffer_getChannelCount(IntPtr SoundBuffer);

        /// <summary>
        ///     Sfs the sound buffer get duration using the specified sound buffer
        /// </summary>
        /// <param name="SoundBuffer">The sound buffer</param>
        /// <returns>The systems time</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl)]
         [SuppressUnmanagedCodeSecurity]
        private static extern Time sfSoundBuffer_getDuration(IntPtr SoundBuffer);
    }
}