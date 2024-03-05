using System;
using System.Threading.Tasks;
using Alis.Core.Extension.FFMeg.Audio;
using Alis.Core.Extension.FFMeg.Test.Assets;
using Xunit;

namespace Alis.Core.Extension.FFMeg.Test
{
    /// <summary>
    /// The audio metadata tests class
    /// </summary>
    public class AudioMetadataTests
    {
        /// <summary>
        /// Tests that load metadata mp 3
        /// </summary>
        [Fact]
        public async Task LoadMetadataMp3()  
        {
            AudioReader audio = new AudioReader(Res.GetPath(Res.Audio_Mp3));

            await audio.LoadMetadataAsync();

            Assert.True(audio.Metadata.Codec == "mp3");
            Assert.True(audio.Metadata.BitRate == 128000);
            Assert.True(audio.Metadata.SampleFormat == "fltp");
            Assert.True(audio.Metadata.SampleRate == 44100);
            Assert.True(audio.Metadata.Channels == 2);
            Assert.True(audio.Metadata.Streams.Length == 1);
            Assert.True(Math.Abs(audio.Metadata.Duration - 1.549187) < 0.01);
        }

        /// <summary>
        /// Tests that load metadata ogg
        /// </summary>
        [Fact]
        public async Task LoadMetadataOgg()
        {
            AudioReader audio = new AudioReader(Res.GetPath(Res.Audio_Ogg));

            await audio.LoadMetadataAsync();

            Assert.True(audio.Metadata.Codec == "vorbis");
            Assert.True(audio.Metadata.BitRate == 48000);
            Assert.True(audio.Metadata.SampleFormat == "fltp");
            Assert.True(audio.Metadata.SampleRate == 11025);
            Assert.True(audio.Metadata.Channels == 2);
            Assert.True(audio.Metadata.Streams.Length == 1);
            Assert.True(Math.Abs(audio.Metadata.Duration - 1.515102) < 0.01);
        }
    }
}
