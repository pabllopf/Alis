// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   SoundRecorder.cs
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
using System.Runtime.InteropServices;
using System.Security;
using Alis.Core.Graphics2D.Systems;

namespace Alis.Core.Graphics2D.Audio
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     Base class intended for capturing sound data
    /// </summary>
    ////////////////////////////////////////////////////////////
    public abstract class SoundRecorder : ObjectBase
    {
        /// <summary>
        ///     The my process callback
        /// </summary>
        private readonly ProcessCallback myProcessCallback;

        /// <summary>
        ///     The my start callback
        /// </summary>
        private readonly StartCallback myStartCallback;

        /// <summary>
        ///     The my stop callback
        /// </summary>
        private readonly StopCallback myStopCallback;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Default constructor
        /// </summary>
        ////////////////////////////////////////////////////////////
        public SoundRecorder() :
            base(IntPtr.Zero)
        {
            myStartCallback = OnStart;
            myProcessCallback = ProcessSamples;
            myStopCallback = OnStop;

            CPointer = sfSoundRecorder_create(myStartCallback, myProcessCallback, myStopCallback, IntPtr.Zero);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Sample rate of the sound recorder.
        /// </summary>
        /// <remarks>
        ///     The sample rate defines the number of audio samples
        ///     captured per second. The higher, the better the quality
        ///     (for example, 44100 samples/sec is CD quality).
        /// </remarks>
        ////////////////////////////////////////////////////////////
        public uint SampleRate => sfSoundRecorder_getSampleRate(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get/Set the channel count of the audio capture device
        /// </summary>
        /// <remarks>
        ///     This method allows you to specify the number of channels
        ///     used for recording. Currently only 16-bit mono (1) and
        ///     16-bit stereo (2) are supported.
        /// </remarks>
        ////////////////////////////////////////////////////////////
        public uint ChannelCount
        {
            get => sfSoundRecorder_getChannelCount(CPointer);
            set => sfSoundRecorder_setChannelCount(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Check if the system supports audio capture.
        /// </summary>
        /// <remarks>
        ///     This function should always be called before using
        ///     the audio capture features. If it returns false, then
        ///     any attempt to use the SoundRecorder or one of its derived
        ///     classes will fail.
        /// </remarks>
        ////////////////////////////////////////////////////////////
        public static bool IsAvailable => sfSoundRecorder_isAvailable();

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get the list of the names of all available audio capture devices
        /// </summary>
        ////////////////////////////////////////////////////////////
        public static string[] AvailableDevices
        {
            get
            {
                unsafe
                {
                    uint Count;
                    IntPtr* DevicesPtr = sfSoundRecorder_getAvailableDevices(out Count);
                    string[] Devices = new string[Count];
                    for (uint i = 0; i < Count; ++i)
                    {
                        Devices[i] = Marshal.PtrToStringAnsi(DevicesPtr[i]);
                    }

                    return Devices;
                }
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get the name of the default audio capture device
        /// </summary>
        ////////////////////////////////////////////////////////////
        public static string DefaultDevice => Marshal.PtrToStringAnsi(sfSoundRecorder_getDefaultDevice());

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Start the capture using the default sample rate (44100 Hz).
        ///     Please note that only one capture can happen at the same time.
        /// </summary>
        ////////////////////////////////////////////////////////////
        public bool Start() => Start(44100);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Start the capture.
        ///     The sampleRate parameter defines the number of audio samples
        ///     captured per second. The higher, the better the quality
        ///     (for example, 44100 samples/sec is CD quality).
        ///     This function uses its own thread so that it doesn't block
        ///     the rest of the program while the capture runs.
        ///     Please note that only one capture can happen at the same time.
        /// </summary>
        /// <param name="sampleRate"> Sound frequency; the more samples, the higher the quality (44100 by default = CD quality)</param>
        ////////////////////////////////////////////////////////////
        public bool Start(uint sampleRate) => sfSoundRecorder_start(CPointer, sampleRate);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Stop the capture
        /// </summary>
        ////////////////////////////////////////////////////////////
        public void Stop()
        {
            sfSoundRecorder_stop(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() => "[SoundRecorder]" + " SampleRate(" + SampleRate + ")";

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Start capturing audio data.
        ///     This virtual function may be overridden by a derived class
        ///     if something has to be done every time a new capture
        ///     starts. If not, this function can be ignored; the default
        ///     implementation does nothing.
        /// </summary>
        /// <returns>False to abort recording audio data, true to continue</returns>
        ////////////////////////////////////////////////////////////
        protected virtual bool OnStart() =>
            // Does nothing by default
            true;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Process a new chunk of recorded samples.
        ///     This virtual function is called every time a new chunk of
        ///     recorded data is available. The derived class can then do
        ///     whatever it wants with it (storing it, playing it, sending
        ///     it over the network, etc.).
        /// </summary>
        /// <param name="samples">Array of samples to process</param>
        /// <returns>False to stop recording audio data, true to continue</returns>
        ////////////////////////////////////////////////////////////
        protected abstract bool OnProcessSamples(short[] samples);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Stop capturing audio data.
        ///     This virtual function may be overridden by a derived class
        ///     if something has to be done every time the capture
        ///     ends. If not, this function can be ignored; the default
        ///     implementation does nothing.
        /// </summary>
        ////////////////////////////////////////////////////////////
        protected virtual void OnStop()
        {
            // Does nothing by default
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     The processing interval controls the period
        ///     between calls to the onProcessSamples function. You may
        ///     want to use a small interval if you want to process the
        ///     recorded data in real time, for example.
        ///     Note: this is only a hint, the actual period may vary.
        ///     So don't rely on this parameter to implement precise timing.
        ///     The default processing interval is 100 ms.
        /// </summary>
        ////////////////////////////////////////////////////////////
        protected void SetProcessingInterval(Systems.Time interval)
        {
            sfSoundRecorder_setProcessingInterval(CPointer, interval);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Set the audio capture device
        /// </summary>
        /// <param name="Name">The name of the audio capture device</param>
        /// <returns>True, if it was able to set the requested device</returns>
        ////////////////////////////////////////////////////////////
        public bool SetDevice(string Name) => sfSoundRecorder_setDevice(CPointer, Name);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get the name of the current audio capture device
        /// </summary>
        /// <returns>The name of the current audio capture device</returns>
        ////////////////////////////////////////////////////////////
        public string GetDevice() => Marshal.PtrToStringAnsi(sfSoundRecorder_getDevice(CPointer));

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        ////////////////////////////////////////////////////////////
        protected override void Destroy(bool disposing)
        {
            sfSoundRecorder_destroy(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Function called directly by the C library ; convert
        ///     arguments and forward them to the internal virtual function
        /// </summary>
        /// <param name="samples">Pointer to the array of samples</param>
        /// <param name="nbSamples">Number of samples in the array</param>
        /// <param name="userData">User data -- unused</param>
        /// <returns>False to stop recording audio data, true to continue</returns>
        ////////////////////////////////////////////////////////////
        private bool ProcessSamples(IntPtr samples, uint nbSamples, IntPtr userData)
        {
            short[] samplesArray = new short[nbSamples];
            Marshal.Copy(samples, samplesArray, 0, samplesArray.Length);

            return OnProcessSamples(samplesArray);
        }

        /// <summary>
        ///     The start callback
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool StartCallback();

        /// <summary>
        ///     The process callback
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool ProcessCallback(IntPtr samples, uint nbSamples, IntPtr userData);

        /// <summary>
        ///     The stop callback
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void StopCallback();

        #region Imports

        /// <summary>
        ///     Sfs the sound recorder create using the specified on start
        /// </summary>
        /// <param name="OnStart">The on start</param>
        /// <param name="OnProcess">The on process</param>
        /// <param name="OnStop">The on stop</param>
        /// <param name="UserData">The user data</param>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfSoundRecorder_create(StartCallback OnStart, ProcessCallback OnProcess,
            StopCallback OnStop, IntPtr UserData);

        /// <summary>
        ///     Sfs the sound recorder destroy using the specified sound recorder
        /// </summary>
        /// <param name="SoundRecorder">The sound recorder</param>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfSoundRecorder_destroy(IntPtr SoundRecorder);

        /// <summary>
        ///     Describes whether sf sound recorder start
        /// </summary>
        /// <param name="SoundRecorder">The sound recorder</param>
        /// <param name="SampleRate">The sample rate</param>
        /// <returns>The bool</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfSoundRecorder_start(IntPtr SoundRecorder, uint SampleRate);

        /// <summary>
        ///     Sfs the sound recorder stop using the specified sound recorder
        /// </summary>
        /// <param name="SoundRecorder">The sound recorder</param>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfSoundRecorder_stop(IntPtr SoundRecorder);

        /// <summary>
        ///     Sfs the sound recorder get sample rate using the specified sound recorder
        /// </summary>
        /// <param name="SoundRecorder">The sound recorder</param>
        /// <returns>The uint</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern uint sfSoundRecorder_getSampleRate(IntPtr SoundRecorder);

        /// <summary>
        ///     Describes whether sf sound recorder is available
        /// </summary>
        /// <returns>The bool</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfSoundRecorder_isAvailable();

        /// <summary>
        ///     Sfs the sound recorder set processing interval using the specified sound recorder
        /// </summary>
        /// <param name="SoundRecorder">The sound recorder</param>
        /// <param name="Interval">The interval</param>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfSoundRecorder_setProcessingInterval(IntPtr SoundRecorder, Systems.Time Interval);

        /// <summary>
        ///     Sfs the sound recorder get available devices using the specified count
        /// </summary>
        /// <param name="Count">The count</param>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern unsafe IntPtr* sfSoundRecorder_getAvailableDevices(out uint Count);

        /// <summary>
        ///     Sfs the sound recorder get default device
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfSoundRecorder_getDefaultDevice();

        /// <summary>
        ///     Describes whether sf sound recorder set device
        /// </summary>
        /// <param name="SoundRecorder">The sound recorder</param>
        /// <param name="Name">The name</param>
        /// <returns>The bool</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfSoundRecorder_setDevice(IntPtr SoundRecorder, string Name);

        /// <summary>
        ///     Sfs the sound recorder get device using the specified sound recorder
        /// </summary>
        /// <param name="SoundRecorder">The sound recorder</param>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfSoundRecorder_getDevice(IntPtr SoundRecorder);

        /// <summary>
        ///     Sfs the sound recorder set channel count using the specified sound recorder
        /// </summary>
        /// <param name="SoundRecorder">The sound recorder</param>
        /// <param name="channelCount">The channel count</param>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfSoundRecorder_setChannelCount(IntPtr SoundRecorder, uint channelCount);

        /// <summary>
        ///     Sfs the sound recorder get channel count using the specified sound recorder
        /// </summary>
        /// <param name="SoundRecorder">The sound recorder</param>
        /// <returns>The uint</returns>
        [DllImport(CSFML.audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern uint sfSoundRecorder_getChannelCount(IntPtr SoundRecorder);

        #endregion
    }
}