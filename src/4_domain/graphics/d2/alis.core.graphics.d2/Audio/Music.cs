// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Music.cs
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
using System.Security;
using Alis.Core.Graphics2D.Systems;
using Alis.Exceptions;

namespace Alis.Core.Graphics2D.Audio
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     Streamed music played from an audio file
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class Music : ObjectBase
    {
        /// <summary>
        ///     The my stream
        /// </summary>
        private readonly StreamAdaptor myStream;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Constructs a music from an audio file
        /// </summary>
        /// <param name="filename">Path of the music file to open</param>
        ////////////////////////////////////////////////////////////
        public Music(string filename) :
            base(sfMusic_createFromFile(filename))
        {
            if (CPointer == IntPtr.Zero)
            {
                throw new LoadingFailedException("music", filename);
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Constructs a music from a custom stream
        /// </summary>
        /// <param name="stream">Source stream to read from</param>
        ////////////////////////////////////////////////////////////
        public Music(Stream stream) :
            base(IntPtr.Zero)
        {
            myStream = new StreamAdaptor(stream);
            CPointer = sfMusic_createFromStream(myStream.InputStreamPtr);

            if (CPointer == IntPtr.Zero)
            {
                throw new LoadingFailedException("music");
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Constructs a music from an audio file in memory
        /// </summary>
        /// <param name="bytes">Byte array containing the file contents</param>
        /// <exception cref="LoadingFailedException" />
        ////////////////////////////////////////////////////////////
        public Music(byte[] bytes) :
            base(IntPtr.Zero)
        {
            GCHandle pin = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                CPointer = sfMusic_createFromMemory(pin.AddrOfPinnedObject(), Convert.ToUInt64(bytes.Length));
            }
            finally
            {
                pin.Free();
            }

            if (CPointer == IntPtr.Zero)
            {
                throw new LoadingFailedException("music");
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Sample rate of the music.
        ///     The sample rate is the number of audio samples played per
        ///     second. The higher, the better the quality.
        /// </summary>
        ////////////////////////////////////////////////////////////
        public uint SampleRate => sfMusic_getSampleRate(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Number of channels (1 = mono, 2 = stereo)
        /// </summary>
        ////////////////////////////////////////////////////////////
        public uint ChannelCount => sfMusic_getChannelCount(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Current status of the music (see SoundStatus enum)
        /// </summary>
        ////////////////////////////////////////////////////////////
        public SoundStatus Status => sfMusic_getStatus(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Total duration of the music
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Systems.Time Duration => sfMusic_getDuration(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Flag if the music should loop after reaching the end.
        ///     If set, the music will restart from beginning after
        ///     reaching the end and so on, until it is stopped or
        ///     Loop = false is set.
        ///     The default looping state for music is false.
        /// </summary>
        ////////////////////////////////////////////////////////////
        public bool Loop
        {
            get => sfMusic_getLoop(CPointer);
            set => sfMusic_setLoop(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Pitch of the music.
        ///     The pitch represents the perceived fundamental frequency
        ///     of a sound; thus you can make a sound more acute or grave
        ///     by changing its pitch. A side effect of changing the pitch
        ///     is to modify the playing speed of the sound as well.
        ///     The default value for the pitch is 1.
        /// </summary>
        ////////////////////////////////////////////////////////////
        public float Pitch
        {
            get => sfMusic_getPitch(CPointer);
            set => sfMusic_setPitch(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Volume of the music.
        ///     The volume is a value between 0 (mute) and 100 (full volume).
        ///     The default value for the volume is 100.
        /// </summary>
        ////////////////////////////////////////////////////////////
        public float Volume
        {
            get => sfMusic_getVolume(CPointer);
            set => sfMusic_setVolume(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     3D position of the music in the audio scene.
        ///     Only sounds with one channel (mono sounds) can be
        ///     spatialized.
        ///     The default position of a sound is (0, 0, 0).
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Vector3f Position
        {
            get => sfMusic_getPosition(CPointer);
            set => sfMusic_setPosition(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Make the music's position relative to the listener or absolute.
        ///     Making a sound relative to the listener will ensure that it will always
        ///     be played the same way regardless the position of the listener.
        ///     This can be useful for non-spatialized sounds, sounds that are
        ///     produced by the listener, or sounds attached to it.
        ///     The default value is false (position is absolute).
        /// </summary>
        ////////////////////////////////////////////////////////////
        public bool RelativeToListener
        {
            get => sfMusic_isRelativeToListener(CPointer);
            set => sfMusic_setRelativeToListener(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Minimum distance of the music.
        ///     The "minimum distance" of a sound is the maximum
        ///     distance at which it is heard at its maximum volume. Further
        ///     than the minimum distance, it will start to fade out according
        ///     to its attenuation factor. A value of 0 ("inside the head
        ///     of the listener") is an invalid value and is forbidden.
        ///     The default value of the minimum distance is 1.
        /// </summary>
        ////////////////////////////////////////////////////////////
        public float MinDistance
        {
            get => sfMusic_getMinDistance(CPointer);
            set => sfMusic_setMinDistance(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Attenuation factor of the music.
        ///     The attenuation is a multiplicative factor which makes
        ///     the music more or less loud according to its distance
        ///     from the listener. An attenuation of 0 will produce a
        ///     non-attenuated sound, i.e. its volume will always be the same
        ///     whether it is heard from near or from far. On the other hand,
        ///     an attenuation value such as 100 will make the sound fade out
        ///     very quickly as it gets further from the listener.
        ///     The default value of the attenuation is 1.
        /// </summary>
        ////////////////////////////////////////////////////////////
        public float Attenuation
        {
            get => sfMusic_getAttenuation(CPointer);
            set => sfMusic_setAttenuation(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Current playing position of the music.
        ///     The playing position can be changed when the music is
        ///     either paused or playing.
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Systems.Time PlayingOffset
        {
            get => sfMusic_getPlayingOffset(CPointer);
            set => sfMusic_setPlayingOffset(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Current loop points of the music.
        ///     Since setting performs some adjustments on the
        ///     provided values and rounds them to internal samples, getting this
        ///     value later is not guaranteed to return the same times passed
        ///     into it. However, it is guaranteed to return times that will map
        ///     to the valid internal samples of this Music if they are later
        ///     set again.
        /// </summary>
        ////////////////////////////////////////////////////////////
        public TimeSpan LoopPoints
        {
            get => sfMusic_getLoopPoints(CPointer);
            set => sfMusic_setLoopPoints(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Start or resume playing the audio stream.
        ///     This function starts the stream if it was stopped, resumes
        ///     it if it was paused, and restarts it from beginning if it
        ///     was it already playing.
        ///     This function uses its own thread so that it doesn't block
        ///     the rest of the program while the stream is played.
        /// </summary>
        ////////////////////////////////////////////////////////////
        public void Play()
        {
            sfMusic_play(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Pause the audio stream.
        ///     This function pauses the stream if it was playing,
        ///     otherwise (stream already paused or stopped) it has no effect.
        /// </summary>
        ////////////////////////////////////////////////////////////
        public void Pause()
        {
            sfMusic_pause(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Stop playing the audio stream.
        ///     This function stops the stream if it was playing or paused,
        ///     and does nothing if it was already stopped.
        ///     It also resets the playing position (unlike Pause()).
        /// </summary>
        ////////////////////////////////////////////////////////////
        public void Stop()
        {
            sfMusic_stop(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() =>
            "[Music]" +
            " SampleRate(" + SampleRate + ")" +
            " ChannelCount(" + ChannelCount + ")" +
            " Status(" + Status + ")" +
            " Duration(" + Duration + ")" +
            " Loop(" + Loop + ")" +
            " Pitch(" + Pitch + ")" +
            " Volume(" + Volume + ")" +
            " Position(" + Position + ")" +
            " RelativeToListener(" + RelativeToListener + ")" +
            " MinDistance(" + MinDistance + ")" +
            " Attenuation(" + Attenuation + ")" +
            " PlayingOffset(" + PlayingOffset + ")" +
            " LoopPoints(" + LoopPoints + ")";

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        ////////////////////////////////////////////////////////////
        protected override void Destroy(bool disposing)
        {
            if (disposing)
            {
                if (myStream != null)
                {
                    myStream.Dispose();
                }
            }

            sfMusic_destroy(CPointer);
        }

        /// <summary>
        ///     The time span
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct TimeSpan
        {
            /// <summary>
            ///     The offset
            /// </summary>
            private readonly Systems.Time offset;

            /// <summary>
            ///     The length
            /// </summary>
            private readonly Systems.Time length;
        }

        #region Imports

        /// <summary>
        ///     Sfs the music create from file using the specified filename
        /// </summary>
        /// <param name="Filename">The filename</param>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfMusic_createFromFile(string Filename);

        /// <summary>
        ///     Sfs the music create from stream using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfMusic_createFromStream(IntPtr stream);

        /// <summary>
        ///     Sfs the music create from memory using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfMusic_createFromMemory(IntPtr data, ulong size);

        /// <summary>
        ///     Sfs the music destroy using the specified music stream
        /// </summary>
        /// <param name="MusicStream">The music stream</param>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfMusic_destroy(IntPtr MusicStream);

        /// <summary>
        ///     Sfs the music play using the specified music
        /// </summary>
        /// <param name="Music">The music</param>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfMusic_play(IntPtr Music);

        /// <summary>
        ///     Sfs the music pause using the specified music
        /// </summary>
        /// <param name="Music">The music</param>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfMusic_pause(IntPtr Music);

        /// <summary>
        ///     Sfs the music stop using the specified music
        /// </summary>
        /// <param name="Music">The music</param>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfMusic_stop(IntPtr Music);

        /// <summary>
        ///     Sfs the music get status using the specified music
        /// </summary>
        /// <param name="Music">The music</param>
        /// <returns>The sound status</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern SoundStatus sfMusic_getStatus(IntPtr Music);

        /// <summary>
        ///     Sfs the music get duration using the specified music
        /// </summary>
        /// <param name="Music">The music</param>
        /// <returns>The systems time</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Systems.Time sfMusic_getDuration(IntPtr Music);

        /// <summary>
        ///     Sfs the music get loop points using the specified music
        /// </summary>
        /// <param name="Music">The music</param>
        /// <returns>The time span</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern TimeSpan sfMusic_getLoopPoints(IntPtr Music);

        /// <summary>
        ///     Sfs the music set loop points using the specified music
        /// </summary>
        /// <param name="Music">The music</param>
        /// <param name="timePoints">The time points</param>
        /// <returns>The time span</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern TimeSpan sfMusic_setLoopPoints(IntPtr Music, TimeSpan timePoints);

        /// <summary>
        ///     Sfs the music get channel count using the specified music
        /// </summary>
        /// <param name="Music">The music</param>
        /// <returns>The uint</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern uint sfMusic_getChannelCount(IntPtr Music);

        /// <summary>
        ///     Sfs the music get sample rate using the specified music
        /// </summary>
        /// <param name="Music">The music</param>
        /// <returns>The uint</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern uint sfMusic_getSampleRate(IntPtr Music);

        /// <summary>
        ///     Sfs the music set pitch using the specified music
        /// </summary>
        /// <param name="Music">The music</param>
        /// <param name="Pitch">The pitch</param>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfMusic_setPitch(IntPtr Music, float Pitch);

        /// <summary>
        ///     Sfs the music set loop using the specified music
        /// </summary>
        /// <param name="Music">The music</param>
        /// <param name="Loop">The loop</param>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfMusic_setLoop(IntPtr Music, bool Loop);

        /// <summary>
        ///     Sfs the music set volume using the specified music
        /// </summary>
        /// <param name="Music">The music</param>
        /// <param name="Volume">The volume</param>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfMusic_setVolume(IntPtr Music, float Volume);

        /// <summary>
        ///     Sfs the music set position using the specified music
        /// </summary>
        /// <param name="Music">The music</param>
        /// <param name="position">The position</param>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfMusic_setPosition(IntPtr Music, Vector3f position);

        /// <summary>
        ///     Sfs the music set relative to listener using the specified music
        /// </summary>
        /// <param name="Music">The music</param>
        /// <param name="Relative">The relative</param>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfMusic_setRelativeToListener(IntPtr Music, bool Relative);

        /// <summary>
        ///     Sfs the music set min distance using the specified music
        /// </summary>
        /// <param name="Music">The music</param>
        /// <param name="MinDistance">The min distance</param>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfMusic_setMinDistance(IntPtr Music, float MinDistance);

        /// <summary>
        ///     Sfs the music set attenuation using the specified music
        /// </summary>
        /// <param name="Music">The music</param>
        /// <param name="Attenuation">The attenuation</param>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfMusic_setAttenuation(IntPtr Music, float Attenuation);

        /// <summary>
        ///     Sfs the music set playing offset using the specified music
        /// </summary>
        /// <param name="Music">The music</param>
        /// <param name="TimeOffset">The time offset</param>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfMusic_setPlayingOffset(IntPtr Music, Systems.Time TimeOffset);

        /// <summary>
        ///     Describes whether sf music get loop
        /// </summary>
        /// <param name="Music">The music</param>
        /// <returns>The bool</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfMusic_getLoop(IntPtr Music);

        /// <summary>
        ///     Sfs the music get pitch using the specified music
        /// </summary>
        /// <param name="Music">The music</param>
        /// <returns>The float</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern float sfMusic_getPitch(IntPtr Music);

        /// <summary>
        ///     Sfs the music get volume using the specified music
        /// </summary>
        /// <param name="Music">The music</param>
        /// <returns>The float</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern float sfMusic_getVolume(IntPtr Music);

        /// <summary>
        ///     Sfs the music get position using the specified music
        /// </summary>
        /// <param name="Music">The music</param>
        /// <returns>The vector 3f</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Vector3f sfMusic_getPosition(IntPtr Music);

        /// <summary>
        ///     Describes whether sf music is relative to listener
        /// </summary>
        /// <param name="Music">The music</param>
        /// <returns>The bool</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfMusic_isRelativeToListener(IntPtr Music);

        /// <summary>
        ///     Sfs the music get min distance using the specified music
        /// </summary>
        /// <param name="Music">The music</param>
        /// <returns>The float</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern float sfMusic_getMinDistance(IntPtr Music);

        /// <summary>
        ///     Sfs the music get attenuation using the specified music
        /// </summary>
        /// <param name="Music">The music</param>
        /// <returns>The float</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern float sfMusic_getAttenuation(IntPtr Music);

        /// <summary>
        ///     Sfs the music get playing offset using the specified music
        /// </summary>
        /// <param name="Music">The music</param>
        /// <returns>The systems time</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Systems.Time sfMusic_getPlayingOffset(IntPtr Music);

        #endregion
    }
}