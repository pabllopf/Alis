// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SoundStream.cs
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
using Alis.Core.Aspect.Base.Attributes;
using Alis.Core.Aspect.Base.Settings;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Audio.SFML
{
    
    /// <summary>
    ///     Abstract base class for streamed audio sources
    /// </summary>
    
    internal abstract class SoundStream : ObjectBase
    {
        /// <summary>
        ///     The my get data callback
        /// </summary>
        private GetDataCallbackType myGetDataCallback;

        /// <summary>
        ///     The my seek callback
        /// </summary>
        private SeekCallbackType mySeekCallback;
        
        /// <summary>
        ///     Default constructor
        /// </summary>
        
        public SoundStream() :
            base(IntPtr.Zero)
        {
        }

        
        /// <summary>
        ///     Sample rate of the stream
        ///     The sample rate is the number of audio samples played per
        ///     second. The higher, the better the quality.
        /// </summary>
        
        public uint SampleRate => sfSoundStream_getSampleRate(CPointer);

        
        /// <summary>
        ///     Number of channels (1 = mono, 2 = stereo)
        /// </summary>
        
        public uint ChannelCount => sfSoundStream_getChannelCount(CPointer);

        
        /// <summary>
        ///     Current status of the sound stream (see SoundStatus enum)
        /// </summary>
        
        public SoundStatus Status => sfSoundStream_getStatus(CPointer);

        
        /// <summary>
        ///     Flag if the music should loop after reaching the end.
        ///     If set, the music will restart from beginning after
        ///     reaching the end and so on, until it is stopped or
        ///     Loop = false is set.
        ///     The default looping state for music is false.
        /// </summary>
        
        public bool Loop
        {
            get => sfSoundStream_getLoop(CPointer);
            set => sfSoundStream_setLoop(CPointer, value);
        }

        
        /// <summary>
        ///     Pitch of the stream.
        ///     The pitch represents the perceived fundamental frequency
        ///     of a sound; thus you can make a sound more acute or grave
        ///     by changing its pitch. A side effect of changing the pitch
        ///     is to modify the playing speed of the sound as well.
        ///     The default value for the pitch is 1.
        /// </summary>
        
        public float Pitch
        {
            get => sfSoundStream_getPitch(CPointer);
            set => sfSoundStream_setPitch(CPointer, value);
        }

        
        /// <summary>
        ///     Volume of the stream.
        ///     The volume is a value between 0 (mute) and 100 (full volume).
        ///     The default value for the volume is 100.
        /// </summary>
        
        public float Volume
        {
            get => sfSoundStream_getVolume(CPointer);
            set => sfSoundStream_setVolume(CPointer, value);
        }

        
        /// <summary>
        ///     3D position of the stream in the audio scene.
        ///     Only sounds with one channel (mono sounds) can be
        ///     spatialized.
        ///     The default position of a sound is (0, 0, 0).
        /// </summary>
        
        public Vector3F Position
        {
            get => sfSoundStream_getPosition(CPointer);
            set => sfSoundStream_setPosition(CPointer, value);
        }

        
        /// <summary>
        ///     Make the stream's position relative to the listener or absolute.
        ///     Making a sound relative to the listener will ensure that it will always
        ///     be played the same way regardless the position of the listener.
        ///     This can be useful for non-spatialized sounds, sounds that are
        ///     produced by the listener, or sounds attached to it.
        ///     The default value is false (position is absolute).
        /// </summary>
        
        public bool RelativeToListener
        {
            get => sfSoundStream_isRelativeToListener(CPointer);
            set => sfSoundStream_setRelativeToListener(CPointer, value);
        }

        
        /// <summary>
        ///     Minimum distance of the music.
        ///     The "minimum distance" of a sound is the maximum
        ///     distance at which it is heard at its maximum volume. Further
        ///     than the minimum distance, it will start to fade out according
        ///     to its attenuation factor. A value of 0 ("inside the head
        ///     of the listener") is an invalid value and is forbidden.
        ///     The default value of the minimum distance is 1.
        /// </summary>
        
        public float MinDistance
        {
            get => sfSoundStream_getMinDistance(CPointer);
            set => sfSoundStream_setMinDistance(CPointer, value);
        }

        
        /// <summary>
        ///     Attenuation factor of the stream.
        ///     The attenuation is a multiplicative factor which makes
        ///     the music more or less loud according to its distance
        ///     from the listener. An attenuation of 0 will produce a
        ///     non-attenuated sound, i.e. its volume will always be the same
        ///     whether it is heard from near or from far. On the other hand,
        ///     an attenuation value such as 100 will make the sound fade out
        ///     very quickly as it gets further from the listener.
        ///     The default value of the attenuation is 1.
        /// </summary>
        
        public float Attenuation
        {
            get => sfSoundStream_getAttenuation(CPointer);
            set => sfSoundStream_setAttenuation(CPointer, value);
        }

        
        /// <summary>
        ///     Current playing position of the stream.
        ///     The playing position can be changed when the music is
        ///     either paused or playing.
        /// </summary>
        
        public Time PlayingOffset
        {
            get => sfSoundStream_getPlayingOffset(CPointer);
            set => sfSoundStream_setPlayingOffset(CPointer, value);
        }

        
        /// <summary>
        ///     Start or resume playing the audio stream.
        ///     This function starts the stream if it was stopped, resumes
        ///     it if it was paused, and restarts it from beginning if it
        ///     was it already playing.
        ///     This function uses its own thread so that it doesn't block
        ///     the rest of the program while the stream is played.
        /// </summary>
        
        public void Play()
        {
            sfSoundStream_play(CPointer);
        }

        
        /// <summary>
        ///     Pause the audio stream.
        ///     This function pauses the stream if it was playing,
        ///     otherwise (stream already paused or stopped) it has no effect.
        /// </summary>
        
        public void Pause()
        {
            sfSoundStream_pause(CPointer);
        }

        
        /// <summary>
        ///     Stop playing the audio stream.
        ///     This function stops the stream if it was playing or paused,
        ///     and does nothing if it was already stopped.
        ///     It also resets the playing position (unlike pause()).
        /// </summary>
        
        public void Stop()
        {
            sfSoundStream_stop(CPointer);
        }

        
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        
        public override string ToString() => "[SoundStream]" +
                                             " SampleRate(" + SampleRate + ")" +
                                             " ChannelCount(" + ChannelCount + ")" +
                                             " Status(" + Status + ")" +
                                             " Loop(" + Loop + ")" +
                                             " Pitch(" + Pitch + ")" +
                                             " Volume(" + Volume + ")" +
                                             " Position(" + Position + ")" +
                                             " RelativeToListener(" + RelativeToListener + ")" +
                                             " MinDistance(" + MinDistance + ")" +
                                             " Attenuation(" + Attenuation + ")" +
                                             " PlayingOffset(" + PlayingOffset + ")";

        
        /// <summary>
        ///     Set the audio stream parameters, you must call it before Play()
        /// </summary>
        /// <param name="channelCount">Number of channels</param>
        /// <param name="sampleRate">Sample rate, in samples per second</param>
        
        protected void Initialize(uint channelCount, uint sampleRate)
        {
            myGetDataCallback = GetData;
            mySeekCallback = Seek;
            CPointer = sfSoundStream_create(myGetDataCallback, mySeekCallback, channelCount, sampleRate, IntPtr.Zero);
        }

        
        /// <summary>
        ///     Virtual function called each time new audio data is needed to feed the stream
        /// </summary>
        /// <param name="samples">Array of samples to fill for the stream</param>
        /// <returns>True to continue playback, false to stop</returns>
        
        protected abstract bool OnGetData(out short[] samples);

        
        /// <summary>
        ///     Virtual function called to seek into the stream
        /// </summary>
        /// <param name="timeOffset">New position</param>
        
        protected abstract void OnSeek(Time timeOffset);

        
        /// <summary>
        ///     Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        
        protected override void Destroy(bool disposing)
        {
            sfSoundStream_destroy(CPointer);
        }

        
        /// <summary>
        /// Called each time new audio data is needed to feed the stream
        /// </summary>
        /// <param name="dataChunk">Data chunk to fill with new audio samples</param>
        /// <param name="userData">User data -- unused</param>
        /// <returns>True to continue playback, false to stop</returns>
        private bool GetData(ref Chunk dataChunk, IntPtr userData)
        {
            if (OnGetData(out short[] dataChunkSamples))
            {
                dataChunk.samples = dataChunkSamples;
                dataChunk.sampleCount = (uint)dataChunkSamples.Length;

                return true;
            }

            return false;
        }
        
        /// <summary>
        ///     Called to seek in the stream
        /// </summary>
        /// <param name="timeOffset">New position</param>
        /// <param name="userData">User data -- unused</param>
        /// <returns>If false is returned, the playback is aborted</returns>
        
        private void Seek(Time timeOffset, IntPtr userData)
        {
            OnSeek(timeOffset);
        }

        /// <summary>
        ///     Sfs the sound stream create using the specified on get data
        /// </summary>
        /// <param name="onGetData">The on get data</param>
        /// <param name="onSeek">The on seek</param>
        /// <param name="channelCount">The channel count</param>
        /// <param name="sampleRate">The sample rate</param>
        /// <param name="userData">The user data</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfSoundStream_create(GetDataCallbackType onGetData, SeekCallbackType onSeek,
            uint channelCount, uint sampleRate, IntPtr userData);

        /// <summary>
        ///     Sfs the sound stream destroy using the specified sound stream stream
        /// </summary>
        /// <param name="soundStreamStream">The sound stream stream</param>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfSoundStream_destroy(IntPtr soundStreamStream);

        /// <summary>
        ///     Sfs the sound stream play using the specified sound stream
        /// </summary>
        /// <param name="soundStream">The sound stream</param>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfSoundStream_play(IntPtr soundStream);

        /// <summary>
        ///     Sfs the sound stream pause using the specified sound stream
        /// </summary>
        /// <param name="soundStream">The sound stream</param>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfSoundStream_pause(IntPtr soundStream);

        /// <summary>
        ///     Sfs the sound stream stop using the specified sound stream
        /// </summary>
        /// <param name="soundStream">The sound stream</param>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfSoundStream_stop(IntPtr soundStream);

        /// <summary>
        ///     Sfs the sound stream get status using the specified sound stream
        /// </summary>
        /// <param name="soundStream">The sound stream</param>
        /// <returns>The sound status</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern SoundStatus sfSoundStream_getStatus(IntPtr soundStream);

        /// <summary>
        ///     Sfs the sound stream get channel count using the specified sound stream
        /// </summary>
        /// <param name="soundStream">The sound stream</param>
        /// <returns>The uint</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern uint sfSoundStream_getChannelCount(IntPtr soundStream);

        /// <summary>
        ///     Sfs the sound stream get sample rate using the specified sound stream
        /// </summary>
        /// <param name="soundStream">The sound stream</param>
        /// <returns>The uint</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern uint sfSoundStream_getSampleRate(IntPtr soundStream);

        /// <summary>
        ///     Sfs the sound stream set loop using the specified sound stream
        /// </summary>
        /// <param name="soundStream">The sound stream</param>
        /// <param name="loop">The loop</param>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfSoundStream_setLoop(IntPtr soundStream, bool loop);

        /// <summary>
        ///     Sfs the sound stream set pitch using the specified sound stream
        /// </summary>
        /// <param name="soundStream">The sound stream</param>
        /// <param name="pitch">The pitch</param>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfSoundStream_setPitch(IntPtr soundStream, float pitch);

        /// <summary>
        ///     Sfs the sound stream set volume using the specified sound stream
        /// </summary>
        /// <param name="soundStream">The sound stream</param>
        /// <param name="volume">The volume</param>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfSoundStream_setVolume(IntPtr soundStream, float volume);

        /// <summary>
        ///     Sfs the sound stream set position using the specified sound stream
        /// </summary>
        /// <param name="soundStream">The sound stream</param>
        /// <param name="position">The position</param>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfSoundStream_setPosition(IntPtr soundStream, Vector3F position);

        /// <summary>
        ///     Sfs the sound stream set relative to listener using the specified sound stream
        /// </summary>
        /// <param name="soundStream">The sound stream</param>
        /// <param name="relative">The relative</param>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfSoundStream_setRelativeToListener(IntPtr soundStream, bool relative);

        /// <summary>
        ///     Sfs the sound stream set min distance using the specified sound stream
        /// </summary>
        /// <param name="soundStream">The sound stream</param>
        /// <param name="minDistance">The min distance</param>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfSoundStream_setMinDistance(IntPtr soundStream, float minDistance);

        /// <summary>
        ///     Sfs the sound stream set attenuation using the specified sound stream
        /// </summary>
        /// <param name="soundStream">The sound stream</param>
        /// <param name="attenuation">The attenuation</param>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfSoundStream_setAttenuation(IntPtr soundStream, float attenuation);

        /// <summary>
        ///     Sfs the sound stream set playing offset using the specified sound stream
        /// </summary>
        /// <param name="soundStream">The sound stream</param>
        /// <param name="timeOffset">The time offset</param>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfSoundStream_setPlayingOffset(IntPtr soundStream, Time timeOffset);

        /// <summary>
        ///     Describes whether sf sound stream get loop
        /// </summary>
        /// <param name="soundStream">The sound stream</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfSoundStream_getLoop(IntPtr soundStream);

        /// <summary>
        ///     Sfs the sound stream get pitch using the specified sound stream
        /// </summary>
        /// <param name="soundStream">The sound stream</param>
        /// <returns>The float</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern float sfSoundStream_getPitch(IntPtr soundStream);

        /// <summary>
        ///     Sfs the sound stream get volume using the specified sound stream
        /// </summary>
        /// <param name="soundStream">The sound stream</param>
        /// <returns>The float</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern float sfSoundStream_getVolume(IntPtr soundStream);

        /// <summary>
        ///     Sfs the sound stream get position using the specified sound stream
        /// </summary>
        /// <param name="soundStream">The sound stream</param>
        /// <returns>The vector 3f</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Vector3F sfSoundStream_getPosition(IntPtr soundStream);

        /// <summary>
        ///     Describes whether sf sound stream is relative to listener
        /// </summary>
        /// <param name="soundStream">The sound stream</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfSoundStream_isRelativeToListener(IntPtr soundStream);

        /// <summary>
        ///     Sfs the sound stream get min distance using the specified sound stream
        /// </summary>
        /// <param name="soundStream">The sound stream</param>
        /// <returns>The float</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern float sfSoundStream_getMinDistance(IntPtr soundStream);

        /// <summary>
        ///     Sfs the sound stream get attenuation using the specified sound stream
        /// </summary>
        /// <param name="soundStream">The sound stream</param>
        /// <returns>The float</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern float sfSoundStream_getAttenuation(IntPtr soundStream);

        /// <summary>
        ///     Sfs the sound stream get playing offset using the specified sound stream
        /// </summary>
        /// <param name="soundStream">The sound stream</param>
        /// <returns>The systems time</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Time sfSoundStream_getPlayingOffset(IntPtr soundStream);

        

        /// <summary>
        ///     The get data callback type
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GetDataCallbackType(ref Chunk dataChunk, IntPtr userData);

        /// <summary>
        ///     The seek callback type
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SeekCallbackType(Time timeOffset, IntPtr userData);
    }
}