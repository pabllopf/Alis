// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioReader.cs
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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Alis.Core.Aspect.Data.Json;
using Alis.Extension.Encode.FFMeg.Audio.Models;
using Alis.Extension.Encode.FFMeg.BaseClasses;

namespace Alis.Extension.Encode.FFMeg.Audio
{
    /// <summary>
    ///     The audio reader class
    /// </summary>
    /// <seealso cref="MediaReader{Frame,Writer}" />
    /// <seealso cref="IDisposable" />
    public class AudioReader : MediaReader<AudioFrame, AudioWriter>, IDisposable
    {
        /// <summary>
        ///     The ffprobe
        /// </summary>
        private readonly string ffmpeg;

        /// <summary>
        ///     The ffprobe
        /// </summary>
        private readonly string ffprobe;

        /// <summary>
        ///     The loaded bit depth
        /// </summary>
        private int loadedBitDepth = 16;

        /// <summary>
        ///     Used for reading metadata and frames from audio files.
        /// </summary>
        /// <param name="filename">Audio file path</param>
        /// <param name="ffmpegExecutable">Name or path to the ffmpeg executable</param>
        /// <param name="ffprobeExecutable">Name or path to the ffprobe executable</param>
        public AudioReader(string filename, string ffmpegExecutable = "ffmpeg", string ffprobeExecutable = "ffprobe")
        {
            if (!File.Exists(filename)) throw new FileNotFoundException($"File '{filename}' not found!");

            Filename = filename;
            ffmpeg = ffmpegExecutable;
            ffprobe = ffprobeExecutable;
        }

        /// <summary>
        ///     Current sample position within the loaded audio file
        /// </summary>
        public long CurrentSampleOffset { get; private set; }

        /// <summary>
        ///     True if metadata loaded successfully
        /// </summary>
        public bool MetadataLoaded { get; private set; }

        /// <summary>
        ///     Audio metadata
        /// </summary>
        public AudioMetadata Metadata { get; private set; }

        /// <summary>
        ///     Diposes the DataStream
        /// </summary>
        public void Dispose()
        {
            DataStream?.Dispose();
        }

        /// <summary>
        ///     Load audio metadata into memory.
        /// </summary>
        public void LoadMetadata(bool ignoreStreamErrors = false) => LoadMetadataAsync(ignoreStreamErrors).Wait();

        /// <summary>
        ///     Load audio metadata into memory.
        /// </summary>
        public async Task LoadMetadataAsync(bool ignoreStreamErrors = false)
        {
            if (MetadataLoaded) throw new InvalidOperationException("Video metadata is already loaded!");
            StreamReader r = new StreamReader(FfMpegWrapper.OpenOutput(ffprobe, $"-i \"{Filename}\" -v quiet -print_format json=c=1 -show_format -show_streams"));

            try
            {
                string json = await r.ReadToEndAsync();
                AudioMetadata metadata = JsonSerializer.Deserialize<AudioMetadata>(json);

                try
                {
                    MediaStream audioStream = metadata.Streams.Where(x => x.CodecType.ToLower().Trim() == "audio").FirstOrDefault();
                    if (audioStream != null)
                    {
                        metadata.Channels = audioStream.Channels.Value;
                        metadata.Codec = audioStream.CodecName;
                        metadata.CodecLongName = audioStream.CodecLongName;
                        metadata.SampleFormat = audioStream.SampleFmt;

                        metadata.SampleRate = audioStream.SampleRateNumber;

                        metadata.Duration = audioStream.Duration == null ? double.Parse(metadata.Format.Duration ?? "-1", CultureInfo.InvariantCulture) : double.Parse(audioStream.Duration, CultureInfo.InvariantCulture);

                        metadata.BitRate = audioStream.BitRate == null ? -1 : int.Parse(audioStream.BitRate);

                        metadata.BitDepth = audioStream.BitsPerSample.Value;
                        metadata.PredictedSampleCount = (int) Math.Round(metadata.Duration * metadata.SampleRate);

                        if (metadata.BitDepth == 0)
                        {
                            // try to parse it from format
                            if (metadata.SampleFormat.Contains("64")) metadata.BitDepth = 64;
                            else if (metadata.SampleFormat.Contains("32")) metadata.BitDepth = 32;
                            else if (metadata.SampleFormat.Contains("24")) metadata.BitDepth = 24;
                            else if (metadata.SampleFormat.Contains("16")) metadata.BitDepth = 16;
                            else if (metadata.SampleFormat.Contains("8")) metadata.BitDepth = 8;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // failed to interpret video stream settings
                    if (!ignoreStreamErrors) throw new InvalidDataException("Failed to parse audio stream data! " + ex.Message);
                }

                MetadataLoaded = true;
                Metadata = metadata;
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("Failed to interpret ffprobe audio metadata output! " + ex.Message);
            }
        }

        /// <summary>
        ///     Load the audio and prepare it for reading frames.
        /// </summary>
        /// <param name="bitDepth">frame bit rate in which the audio will be processed (16, 24, 32)</param>
        public void Load(int bitDepth = 16)
        {
            if ((bitDepth != 16) && (bitDepth != 24) && (bitDepth != 32)) throw new InvalidOperationException("Acceptable bit depths are 16, 24 and 32");
            if (OpenedForReading) throw new InvalidOperationException("Audio is already loaded!");
            if (!MetadataLoaded) throw new InvalidOperationException("Please load the audio metadata first!");

            // we will be reading audio in S16LE format (for best accuracy, could use S32LE)
            DataStream = FfMpegWrapper.OpenOutput(ffmpeg, $"-i \"{Filename}\" -f s{bitDepth}le -");
            loadedBitDepth = bitDepth;
            OpenedForReading = true;
        }

        /// <summary>
        ///     Loads the next audio frame into memory and returns it. This allocates a new frame.
        ///     Returns 'null' when there is no next frame.
        /// </summary>
        /// <returns></returns>
        public override AudioFrame NextFrame() => NextFrame(1024);

        /// <summary>
        ///     Loads the next audio frame into memory and returns it. This allocates a new frame.
        ///     Returns 'null' when there is no next frame.
        /// </summary>
        /// <param name="samples">Number of samples to read in a frame</param>
        public AudioFrame NextFrame(int samples)
        {
            AudioFrame frame = new AudioFrame(Metadata.Channels, samples, loadedBitDepth);
            return NextFrame(frame);
        }

        /// <summary>
        ///     Loads the next audio frame into memory and returns it. This allocates a new frame.
        ///     Returns 'null' when there is no next frame.
        /// </summary>
        /// <param name="frame">Existing frame to be overwritten with new frame data.</param>
        public override AudioFrame NextFrame(AudioFrame frame)
        {
            if (!OpenedForReading) throw new InvalidOperationException("Please load the audio first!");

            bool success = frame.Load(DataStream);
            if (success) CurrentSampleOffset += frame.LoadedSamples;
            return success ? frame : null;
        }
    }
}