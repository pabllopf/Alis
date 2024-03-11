// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoReader.cs
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Extension.FFMeg.BaseClasses;
using Alis.Core.Extension.FFMeg.Video.Models;

namespace Alis.Core.Extension.FFMeg.Video
{
    /// <summary>
    ///     The video reader class
    /// </summary>
    /// <seealso cref="MediaReader{Frame,Writer}" />
    /// <seealso cref="IDisposable" />
    public class VideoReader : MediaReader<VideoFrame, MediaWriter<VideoFrame>>, IDisposable
    {
        /// <summary>
        ///     The compiled
        /// </summary>
        private static readonly Regex bitRateSimpleRgx = new Regex(@"\D(\d+?)[bl]e", RegexOptions.Compiled, TimeSpan.FromSeconds(10));

        /// <summary>
        ///     The ffprobe
        /// </summary>
        private readonly string ffmpeg;

        /// <summary>
        ///     The ffprobe
        /// </summary>
        private readonly string ffprobe;

        /// <summary>
        ///     Used for reading metadata and frames from video files.
        /// </summary>
        /// <param name="filename">Video file path</param>
        /// <param name="ffmpegExecutable">Name or path to the ffmpeg executable</param>
        /// <param name="ffprobeExecutable">Name or path to the ffprobe executable</param>
        public VideoReader(string filename, string ffmpegExecutable = "ffmpeg", string ffprobeExecutable = "ffprobe")
        {
            if (!File.Exists(filename)) throw new FileNotFoundException($"File '{filename}' not found!");

            Filename = filename;
            ffmpeg = ffmpegExecutable;
            ffprobe = ffprobeExecutable;
        }

        /// <summary>
        ///     Current frame position within the loaded video file
        /// </summary>
        public long CurrentFrameOffset { get; private set; }

        /// <summary>
        ///     True if metadata loaded successfully
        /// </summary>
        public bool LoadedMetadata { get; private set; }

        /// <summary>
        ///     Video metadata
        /// </summary>
        public VideoMetadata Metadata { get; private set; }

        /// <summary>
        ///     Diposes the DataStream
        /// </summary>
        public void Dispose()
        {
            DataStream?.Dispose();
        }

        /// <summary>
        ///     Load video metadata into memory.
        /// </summary>
        public void LoadMetadata(bool ignoreStreamErrors = false) => LoadMetadataAsync(ignoreStreamErrors).Wait();

        /// <summary>
        ///     Load video metadata into memory.
        /// </summary>
        public async Task LoadMetadataAsync(bool ignoreStreamErrors = false)
        {
            if (LoadedMetadata) throw new InvalidOperationException("Video metadata is already loaded!");
            StreamReader r = new StreamReader(FfMpegWrapper.OpenOutput(ffprobe, $"-i \"{Filename}\" -v quiet -print_format json=c=1 -show_format -show_streams"));

            try
            {
                string metadataJson = await r.ReadToEndAsync();
                VideoMetadata metadata = JsonSerializer.Deserialize<VideoMetadata>(metadataJson);

                try
                {
                    MediaStream videoStream = metadata.Streams.Where(x => x.CodecType.ToLower().Trim() == "video").FirstOrDefault();
                    if (videoStream != null)
                    {
                        metadata.Width = videoStream.Width.Value;
                        metadata.Height = videoStream.Height.Value;
                        metadata.PixelFormat = videoStream.PixFmt;
                        metadata.Codec = videoStream.CodecName;
                        metadata.CodecLongName = videoStream.CodecLongName;

                        metadata.BitRate = videoStream.BitRate == null ? -1 : int.Parse(videoStream.BitRate);

                        metadata.BitDepth = videoStream.BitsPerRawSample == null ? TryParseBitDepth(videoStream.PixFmt) : int.Parse(videoStream.BitsPerRawSample);

                        metadata.Duration = videoStream.Duration == null ? double.Parse(metadata.Format.Duration ?? "0", CultureInfo.InvariantCulture) : double.Parse(videoStream.Duration, CultureInfo.InvariantCulture);

                        metadata.SampleAspectRatio = videoStream.SampleAspectRatio;
                        metadata.AvgFramerate = videoStream.AvgFrameRateNumber;

                        metadata.PredictedFrameCount = (int) (metadata.AvgFramerate * metadata.Duration);
                    }
                }
                catch (Exception ex)
                {
                    // failed to interpret video stream settings
                    if (!ignoreStreamErrors) throw new InvalidDataException("Failed to parse video stream data! " + ex.Message);
                }

                LoadedMetadata = true;
                Metadata = metadata;
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("Failed to interpret ffprobe video metadata output! " + ex.Message);
            }
        }

        /// <summary>
        ///     Load the video and prepare it for reading frames.
        /// </summary>
        public void Load() => Load(0);

        /// <summary>
        ///     Load the video for reading frames and seeks to given offset in seconds.
        /// </summary>
        /// <param name="offsetSeconds">Offset in seconds to which to seek to</param>
        public void Load(double offsetSeconds)
        {
            if (OpenedForReading) throw new InvalidOperationException("Video is already loaded!");
            if (!LoadedMetadata) throw new InvalidOperationException("Please load the video metadata first!");
            if (Metadata.Width == 0 || Metadata.Height == 0) throw new InvalidDataException("Loaded metadata contains errors!");

            // we will be reading video in RGB24 format
            DataStream = FfMpegWrapper.OpenOutput(ffmpeg,
                $"{(offsetSeconds <= 0 ? "" : $"-ss {offsetSeconds.ToString("0.00", CultureInfo.InvariantCulture)}")} -i \"{Filename}\"" +
                " -pix_fmt rgb24 -f rawvideo -");

            OpenedForReading = true;
        }

        /// <summary>
        ///     Loads the next video frame into memory and returns it. This allocates a new frame.
        ///     Returns 'null' when there is no next frame.
        /// </summary>
        public override VideoFrame NextFrame()
        {
            VideoFrame frame = new VideoFrame(Metadata.Width, Metadata.Height);
            return NextFrame(frame);
        }

        /// <summary>
        ///     Loads the next video frame into memory and returns it. This overrides the given frame with no extra allocations.
        ///     Recommended for performance.
        ///     Returns 'null' when there is no next frame.
        /// </summary>
        /// <param name="frame">Existing frame to be overwritten with new frame data.</param>
        public override VideoFrame NextFrame(VideoFrame frame)
        {
            if (!OpenedForReading) throw new InvalidOperationException("Please load the video first!");

            bool success = frame.Load(DataStream);
            if (success) CurrentFrameOffset++;
            return success ? frame : null;
        }

        /// <summary>
        ///     Tries the parse bit depth using the specified pix fmt
        /// </summary>
        /// <param name="pix_fmt">The pix fmt</param>
        /// <returns>The int</returns>
        private int TryParseBitDepth(string pix_fmt)
        {
            Match match = bitRateSimpleRgx.Match(pix_fmt);
            if (match.Success) return int.Parse(match.Groups[1].Value);

            return -1;
        }
    }
}