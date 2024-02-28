using CryMediaAPI.Audio;
using CryMediaAPI.Encoding.Builders;
using CryMediaAPI.Resources;
using CryMediaAPI.Video;

using System;
using System.IO;
using System.Threading.Tasks;
using CryMediaAPI.BaseClasses;
using Xunit;

namespace CryMediaAPI.Tests
{
    public class AudioVideoConversionTests
    {
        [Fact]
        public async Task ConversionTest()
        {
            string vpath = Res.GetPath(Res.Video_Mp4);
            string apath = Res.GetPath(Res.Audio_Mp3);
            string opath = "out-test-av-1.mp4";

            try
            {
                using VideoReader vreader = new VideoReader(vpath);
                await vreader.LoadMetadataAsync();
                vreader.Load();

                using AudioReader areader = new AudioReader(apath);
                await areader.LoadMetadataAsync();
                areader.Load();

                // Get video and audio stream metadata
                MediaStream vstream = vreader.Metadata.GetFirstVideoStream();
                MediaStream astream = areader.Metadata.GetFirstAudioStream();

                // Prepare writer (Converting to H.264 + AAC video)
                using (AudioVideoWriter writer = new AudioVideoWriter(opath,
                    vstream.Width.Value,
                    vstream.Height.Value,
                    vstream.AvgFrameRateNumber,
                    astream.Channels.Value,
                    astream.SampleRateNumber, 16,
                    new H264Encoder().Create(),
                    new AACEncoder().Create()))
                {

                    // Open for writing (this starts the FFmpeg process)
                    writer.OpenWrite();

                    // Copy raw data directly from stream to stream
                    Task t2 = areader.DataStream.CopyToAsync(writer.InputDataStreamAudio);
                    Task t1 = vreader.DataStream.CopyToAsync(writer.InputDataStreamVideo);

                    await t1;
                    await t2;
                }

                using VideoReader video = new VideoReader(opath);
                await video.LoadMetadataAsync();

                Assert.True(video.Metadata.Streams.Length == 2);

                vstream = video.Metadata.GetFirstVideoStream();
                astream = video.Metadata.GetFirstAudioStream();

                Assert.True(Math.Abs(vstream.AvgFrameRateNumber - vreader.Metadata.AvgFramerate) < 0.1);
                Assert.True(vstream.Width.Value == vreader.Metadata.Width);
                Assert.True(vstream.Height.Value == vreader.Metadata.Height);

                Assert.True(astream.SampleRateNumber == areader.Metadata.SampleRate);
            }
            finally
            {
                if (File.Exists(opath)) File.Delete(opath);
            }
        }

        [Fact]
        public async Task ConversionStreamTest()
        {
            string vpath = Res.GetPath(Res.Video_Mp4);
            string apath = Res.GetPath(Res.Audio_Mp3);
            string opath = "out-test-av-2.mp4";

            try
            {
                using VideoReader vreader = new VideoReader(vpath);
                await vreader.LoadMetadataAsync();
                vreader.Load();

                using AudioReader areader = new AudioReader(apath);
                await areader.LoadMetadataAsync();
                areader.Load();

                // Get video and audio stream metadata
                MediaStream vstream = vreader.Metadata.GetFirstVideoStream();
                MediaStream astream = areader.Metadata.GetFirstAudioStream();

                H264Encoder encoder = new H264Encoder
                {
                    Format = "flv"
                };

                using (FileStream filestream = File.Create(opath))
                {
                    // Prepare writer (Converting to H.264 + AAC video)
                    using (AudioVideoWriter writer = new AudioVideoWriter(filestream,
                        vstream.Width.Value,
                        vstream.Height.Value,
                        vstream.AvgFrameRateNumber,
                        astream.Channels.Value,
                        astream.SampleRateNumber, 16,
                        encoder.Create(), 
                        new AACEncoder().Create()))
                    {

                        // Open for writing (this starts the FFmpeg process)
                        writer.OpenWrite();

                        // Copy raw data directly from stream to stream
                        Task t2 = areader.DataStream.CopyToAsync(writer.InputDataStreamAudio);
                        Task t1 = vreader.DataStream.CopyToAsync(writer.InputDataStreamVideo);

                        await t1;
                        await t2;
                    }
                }

                using VideoReader video = new VideoReader(opath);
                await video.LoadMetadataAsync();

                Assert.True(video.Metadata.Streams.Length == 2);

                vstream = video.Metadata.GetFirstVideoStream();
                astream = video.Metadata.GetFirstAudioStream();

                Assert.True(Math.Abs(vstream.AvgFrameRateNumber - vreader.Metadata.AvgFramerate) < 0.1);
                Assert.True(Math.Abs(video.Metadata.Duration - vreader.Metadata.Duration) < 0.2);
                Assert.True(vstream.Width.Value == vreader.Metadata.Width);
                Assert.True(vstream.Height.Value == vreader.Metadata.Height);
                Assert.True(astream.SampleRateNumber == areader.Metadata.SampleRate);
            }
            finally
            {
                if (File.Exists(opath)) File.Delete(opath);
            }
        }
    }
}
