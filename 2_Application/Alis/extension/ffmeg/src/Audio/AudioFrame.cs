using System;
using System.IO;
using Alis.Extension.FFMeg.BaseClasses;

namespace Alis.Extension.FFMeg.Audio
{
    /// <summary>
    /// Audio frame containing multiple audio samples in signed PCM format with given bit depth.
    /// </summary>
    public class AudioFrame : IDisposable, IMediaFrame
    {     
        /// <summary>
        /// The offset
        /// </summary>
        int size, offset = 0;

        /// <summary>
        /// Number of channels
        /// </summary>
        public int Channels { get; }
        /// <summary>
        /// Number of audio samples this frame can contain
        /// </summary>
        public int SampleCount { get; }
        /// <summary>
        /// Bit depth (Bytes per sample)
        /// </summary>
        public int BytesPerSample { get; }
        /// <summary>
        /// Number of loaded audio samples when calling Load()
        /// </summary>
        public int LoadedSamples { get; private set; }


        /// <summary>
        /// The frame buffer
        /// </summary>
        byte[] frameBuffer;
        /// <summary>
        /// Raw audio data in signed PCM format
        /// </summary>
        public byte[] RawData { get; private set; }

        /// <summary>
        /// Creates an empty audio frame with fixed sample count and given bit depth using signed PCM format.
        /// </summary>
        /// <param name="channels">Number of channels</param>
        /// <param name="sampleCount">Number of samples to store within this frame</param>
        /// <param name="bitDepth">Bits per sample (16, 24 or 32)</param>
        public AudioFrame(int channels, int sampleCount = 1024, int bitDepth = 16)
    {
        if (bitDepth != 16 && bitDepth != 24 && bitDepth != 32) throw new InvalidOperationException("Acceptable bit depths are 16, 24 and 32");
        if (channels <= 0) throw new InvalidDataException("Channel count has to be bigger than 0!");
        if (sampleCount <= 0) throw new InvalidDataException("Sample count has to be bigger than 0!");

        Channels = channels;
        SampleCount = sampleCount;
        BytesPerSample = bitDepth / 8;
        size = sampleCount * channels * BytesPerSample;

        frameBuffer = new byte[size];
        RawData = frameBuffer;
    }

        /// <summary>
        /// Loads audio samples from stream.
        /// </summary>
        /// <param name="str">Stream containing raw audio samples in signed PCM format</param>
        public bool Load(Stream str)
    {
        offset = 0;

        while (offset < size)
        {
            int r = str.Read(frameBuffer, offset, size - offset);
            if (r <= 0)
            {
                if (offset == 0) return false;
                else break;
            }

            offset += r;
        }

        LoadedSamples = offset / (BytesPerSample * Channels);

        // Adjust RawData length when changed
        if (RawData.Length != offset)
        {
            byte[] newRawData = new byte[offset];
            Array.Copy(frameBuffer, 0, newRawData, 0, offset);
            RawData = newRawData;
        }

        return true;
    }

        /// <summary>
        /// Returns part of array that contains the sample value
        /// </summary>
        /// <param name="index">Sample index</param>
        /// <param name="channel">Channel index</param>
        public byte[] GetSample(int index, int channel)
        {
            int i = (index * Channels + channel) * BytesPerSample;
            byte[] sample = new byte[BytesPerSample];
            Array.Copy(RawData, i, sample, 0, BytesPerSample);
            return sample;
        }

        /// <summary>
        /// Clears the frame buffer
        /// </summary>
        public void Dispose()
    {
        frameBuffer = null;        
    }
    }
}
