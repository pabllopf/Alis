using CryMediaAPI.Audio;
using CryMediaAPI.Encoding;
using CryMediaAPI.Encoding.Builders;
using CryMediaAPI.Resources;

using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

using Xunit;

namespace CryMediaAPI.Tests
{
    public class AudioConversionTests
    {
        [Fact]
        public async Task FFmpegWrapperProgressTest()
        {
            string path = Res.GetPath(Res.Audio_Ogg);
            string opath = "out-test.mp3";

            double lastval = -1;

            try
            {
                AudioReader audio = new AudioReader(path);

                await audio.LoadMetadataAsync();
                double dur = audio.Metadata.Duration;
                audio.Dispose();

                Assert.True(Math.Abs(dur - 1.515102) < 0.01);

                Process p = FFmpegWrapper.ExecuteCommand("ffmpeg", $"-i \"{path}\" \"{opath}\"");
                Progress<double> progress = FFmpegWrapper.RegisterProgressTracker(p, dur);
                progress.ProgressChanged += (s, prg) => lastval = prg;             
                p.WaitForExit();

                await Task.Delay(300);

                Assert.True(lastval > 50 && lastval <= 100);

                audio = new AudioReader(opath);

                await audio.LoadMetadataAsync();

                Assert.True(audio.Metadata.Channels == 2);
                Assert.True(audio.Metadata.Streams.Length == 1);
                Assert.True(Math.Abs(audio.Metadata.Duration - 1.515102) < 0.2);

                audio.Dispose();
            }
            finally
            {
                if (File.Exists(opath)) File.Delete(opath);
            }
        }

        [Fact]
        public async Task ConversionTest()
        {
            string path = Res.GetPath(Res.Audio_Ogg);
            string opath = "out-test-2.mp3";

            try
            {
                using AudioReader reader = new AudioReader(path);
                await reader.LoadMetadataAsync();

                using (AudioWriter writer = new AudioWriter(opath, 
                    reader.Metadata.Channels, 
                    reader.Metadata.SampleRate, 16,
                    new MP3Encoder().Create()))
                {
                    writer.OpenWrite();

                    reader.Load();

                    await reader.CopyToAsync(writer);
                }

                using AudioReader audio = new AudioReader(opath);
                await audio.LoadMetadataAsync();

                Assert.True(audio.Metadata.Format.FormatName == "mp3");
                Assert.True(audio.Metadata.Channels == 2);
                Assert.True(audio.Metadata.Streams.Length == 1);
                Assert.True(Math.Abs(audio.Metadata.Duration - 1.515102) < 0.2);              
            }
            finally
            {
                if (File.Exists(opath)) File.Delete(opath);
            }
        }

        [Fact]
        public async Task ConversionStreamTest()
        {
            string path = Res.GetPath(Res.Audio_Mp3);
            string opath = "out-test-v-2.aac";

            try
            {
                using AudioReader reader = new AudioReader(path);
                await reader.LoadMetadataAsync();

                AACEncoder encoder = new AACEncoder
                {
                    Format = "flv"
                };

                using (FileStream filestream = File.Create(opath))
                {
                    using (AudioWriter writer = new AudioWriter(filestream,
                       reader.Metadata.Channels,
                       reader.Metadata.SampleRate, 16,
                       encoder.Create()))
                    {
                        writer.OpenWrite();

                        reader.Load();

                        await reader.CopyToAsync(writer);
                    }                 
                }

                using AudioReader audio = new AudioReader(opath);
                await audio.LoadMetadataAsync();

                Assert.True(audio.Metadata.Format.FormatName == "flv");
                Assert.True(audio.Metadata.Channels == 2);
                Assert.True(audio.Metadata.Streams.Length == 1);
                Assert.True(Math.Abs(audio.Metadata.Duration - 1.515102) < 0.2);
            }
            finally
            {
                if (File.Exists(opath)) File.Delete(opath);
            }
        }
    }
}
