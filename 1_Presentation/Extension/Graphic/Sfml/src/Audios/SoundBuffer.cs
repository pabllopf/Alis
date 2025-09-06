using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Extension.Graphic.Sfml.Systems;
using LoadingFailedException = Alis.Extension.Graphic.Sfml.Windows.LoadingFailedException;

namespace Alis.Extension.Graphic.Sfml.Audios
{
    
    /// <summary>
    /// Storage for audio samples defining a sound
    /// </summary>
    
    public class SoundBuffer : ObjectBase
    {
        
        /// <summary>
        /// Construct a sound buffer from a file
        /// 
        /// Here is a complete list of all the supported audio formats:
        /// ogg, wav, flac, aiff, au, raw, paf, svx, nist, voc, ircam,
        /// w64, mat4, mat5 pvf, htk, sds, avr, sd2, caf, wve, mpc2k, rf64.
        /// </summary>
        /// <param name="filename">Path of the sound file to load</param>
        /// <exception cref="LoadingFailedException" />
        
        public SoundBuffer(string filename) :
            base(sfSoundBuffer_createFromFile(filename))
        {
            if (CPointer == IntPtr.Zero)
            {
                throw new LoadingFailedException("sound buffer", filename);
            }
        }

        
        /// <summary>
        /// Construct a sound buffer from a custom stream.
        ///
        /// Here is a complete list of all the supported audio formats:
        /// ogg, wav, flac, aiff, au, raw, paf, svx, nist, voc, ircam,
        /// w64, mat4, mat5 pvf, htk, sds, avr, sd2, caf, wve, mpc2k, rf64.
        /// </summary>
        /// <param name="stream">Source stream to read from</param>
        /// <exception cref="LoadingFailedException" />
        
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

        
        /// <summary>
        /// Construct a sound buffer from a file in memory.
        /// 
        /// Here is a complete list of all the supported audio formats:
        /// ogg, wav, flac, aiff, au, raw, paf, svx, nist, voc, ircam,
        /// w64, mat4, mat5 pvf, htk, sds, avr, sd2, caf, wve, mpc2k, rf64.
        /// </summary>
        /// <param name="bytes">Byte array containing the file contents</param>
        /// <exception cref="LoadingFailedException" />
        
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

        
        /// <summary>
        /// Construct a sound buffer from an array of samples
        /// </summary>
        /// <param name="samples">Array of samples</param>
        /// <param name="channelCount">Channel count</param>
        /// <param name="sampleRate">Sample rate</param>
        /// <exception cref="LoadingFailedException" />
        
        public SoundBuffer(short[] samples, uint channelCount, uint sampleRate) :
            base(IntPtr.Zero)
        {
            GCHandle handle = GCHandle.Alloc(samples, GCHandleType.Pinned);
            try
            {
                IntPtr samplesPtr = handle.AddrOfPinnedObject();
                CPointer = sfSoundBuffer_createFromSamples(samplesPtr, (uint)samples.Length, channelCount, sampleRate);
            }
            finally
            {
                handle.Free();
            }
        
            if (CPointer == IntPtr.Zero)
            {
                throw new LoadingFailedException("sound buffer");
            }
        }

        
        /// <summary>
        /// Construct a sound buffer from another sound buffer
        /// </summary>
        /// <param name="copy">Sound buffer to copy</param>
        
        public SoundBuffer(SoundBuffer copy) :
            base(sfSoundBuffer_copy(copy.CPointer))
        {
        }

        
        /// <summary>
        /// Save the sound buffer to an audio file.
        ///
        /// Here is a complete list of all the supported audio formats:
        /// ogg, wav, flac, aiff, au, raw, paf, svx, nist, voc, ircam,
        /// w64, mat4, mat5 pvf, htk, sds, avr, sd2, caf, wve, mpc2k, rf64.
        /// </summary>
        /// <param name="filename">Path of the sound file to write</param>
        /// <returns>True if saving has been successful</returns>
        
        public bool SaveToFile(string filename)
        {
            return sfSoundBuffer_saveToFile(CPointer, filename);
        }

        
        /// <summary>
        /// Sample rate of the sound buffer.
        ///
        /// The sample rate is the number of audio samples played per
        /// second. The higher, the better the quality.
        /// </summary>
        
        public uint SampleRate
        {
            get { return sfSoundBuffer_getSampleRate(CPointer); }
        }

        
        /// <summary>
        /// Number of channels (1 = mono, 2 = stereo)
        /// </summary>
        
        public uint ChannelCount
        {
            get { return sfSoundBuffer_getChannelCount(CPointer); }
        }

        
        /// <summary>
        /// Total duration of the buffer
        /// </summary>
        
        public Time Duration
        {
            get { return sfSoundBuffer_getDuration(CPointer); }
        }

        
        /// <summary>
        /// Array of audio samples stored in the buffer.
        ///
        /// The format of the returned samples is 16 bits signed integer
        /// (sf::Int16).
        /// </summary>
        
        public short[] Samples
        {
            get
            {
                short[] samplesArray = new short[sfSoundBuffer_getSampleCount(CPointer)];
                Marshal.Copy(sfSoundBuffer_getSamples(CPointer), samplesArray, 0, samplesArray.Length);
                return samplesArray;
            }
        }

        
        /// <summary>
        /// Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        
        public override string ToString()
        {
            return "[SoundBuffer]" +
                   " SampleRate(" + SampleRate + ")" +
                   " ChannelCount(" + ChannelCount + ")" +
                   " Duration(" + Duration + ")";
        }

        
        /// <summary>
        /// Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        
        public override void Destroy(bool disposing)
        {
            sfSoundBuffer_destroy(CPointer);
        }

        #region Imports
        /// <summary>
        /// Sfs the sound buffer create from file using the specified filename
        /// </summary>
        /// <param name="filename">The filename</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern IntPtr sfSoundBuffer_createFromFile(string filename);

        /// <summary>
        /// Sfs the sound buffer create from stream using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern IntPtr sfSoundBuffer_createFromStream(IntPtr stream);

        /// <summary>
        /// Sfs the sound buffer create from memory using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern IntPtr sfSoundBuffer_createFromMemory(IntPtr data, ulong size);

        /// <summary>
        /// Sfs the sound buffer create from samples using the specified samples
        /// </summary>
        /// <param name="samples">The samples</param>
        /// <param name="sampleCount">The sample count</param>
        /// <param name="channelsCount">The channels count</param>
        /// <param name="sampleRate">The sample rate</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern IntPtr sfSoundBuffer_createFromSamples(short[] samples, uint sampleCount, uint channelsCount, uint sampleRate);
        
        /// <summary>
        /// Sfs the sound buffer create from samples using the specified samples
        /// </summary>
        /// <param name="samples">The samples</param>
        /// <param name="sampleCount">The sample count</param>
        /// <param name="channelsCount">The channels count</param>
        /// <param name="sampleRate">The sample rate</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sfSoundBuffer_createFromSamples"), SuppressUnmanagedCodeSecurity]
        static extern IntPtr sfSoundBuffer_createFromSamples(IntPtr samples, uint sampleCount, uint channelsCount, uint sampleRate);

        /// <summary>
        /// Sfs the sound buffer copy using the specified sound buffer
        /// </summary>
        /// <param name="soundBuffer">The sound buffer</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern IntPtr sfSoundBuffer_copy(IntPtr soundBuffer);

        /// <summary>
        /// Sfs the sound buffer destroy using the specified sound buffer
        /// </summary>
        /// <param name="soundBuffer">The sound buffer</param>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfSoundBuffer_destroy(IntPtr soundBuffer);

        /// <summary>
        /// Sfs the sound buffer save to file using the specified sound buffer
        /// </summary>
        /// <param name="soundBuffer">The sound buffer</param>
        /// <param name="filename">The filename</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern bool sfSoundBuffer_saveToFile(IntPtr soundBuffer, string filename);

        /// <summary>
        /// Sfs the sound buffer get samples using the specified sound buffer
        /// </summary>
        /// <param name="soundBuffer">The sound buffer</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern IntPtr sfSoundBuffer_getSamples(IntPtr soundBuffer);

        /// <summary>
        /// Sfs the sound buffer get sample count using the specified sound buffer
        /// </summary>
        /// <param name="soundBuffer">The sound buffer</param>
        /// <returns>The uint</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern uint sfSoundBuffer_getSampleCount(IntPtr soundBuffer);

        /// <summary>
        /// Sfs the sound buffer get sample rate using the specified sound buffer
        /// </summary>
        /// <param name="soundBuffer">The sound buffer</param>
        /// <returns>The uint</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern uint sfSoundBuffer_getSampleRate(IntPtr soundBuffer);

        /// <summary>
        /// Sfs the sound buffer get channel count using the specified sound buffer
        /// </summary>
        /// <param name="soundBuffer">The sound buffer</param>
        /// <returns>The uint</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern uint sfSoundBuffer_getChannelCount(IntPtr soundBuffer);

        /// <summary>
        /// Sfs the sound buffer get duration using the specified sound buffer
        /// </summary>
        /// <param name="soundBuffer">The sound buffer</param>
        /// <returns>The time</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern Time sfSoundBuffer_getDuration(IntPtr soundBuffer);
        #endregion
    }
}
