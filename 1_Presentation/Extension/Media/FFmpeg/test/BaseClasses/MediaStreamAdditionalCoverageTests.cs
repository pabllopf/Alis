using Alis.Extension.Media.FFmpeg.BaseClasses;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.BaseClasses
{
    public class MediaStreamAdditionalCoverageTests
    {
        [Fact] public void CodecTimeBase_ShouldBeSettable()
        {
            var s = new MediaStream { CodecTimeBase = "1/50" };
            Assert.Equal("1/50", s.CodecTimeBase);
        }

        [Fact] public void CodecTagString_ShouldBeSettable()
        {
            var s = new MediaStream { CodecTagString = "avc1" };
            Assert.Equal("avc1", s.CodecTagString);
        }

        [Fact] public void CodecTag_ShouldBeSettable()
        {
            var s = new MediaStream { CodecTag = "0x31637661" };
            Assert.Equal("0x31637661", s.CodecTag);
        }

        [Fact] public void CodedWidth_ShouldBeSettable()
        {
            var s = new MediaStream { CodedWidth = 1920 };
            Assert.Equal(1920, s.CodedWidth);
        }

        [Fact] public void CodedHeight_ShouldBeSettable()
        {
            var s = new MediaStream { CodedHeight = 1080 };
            Assert.Equal(1080, s.CodedHeight);
        }

        [Fact] public void HasBFrames_ShouldBeSettable()
        {
            var s = new MediaStream { HasBFrames = 2 };
            Assert.Equal(2, s.HasBFrames);
        }

        [Fact] public void SampleAspectRatio_ShouldBeSettable()
        {
            var s = new MediaStream { SampleAspectRatio = "1:1" };
            Assert.Equal("1:1", s.SampleAspectRatio);
        }

        [Fact] public void DisplayAspectRatio_ShouldBeSettable()
        {
            var s = new MediaStream { DisplayAspectRatio = "16:9" };
            Assert.Equal("16:9", s.DisplayAspectRatio);
        }

        [Fact] public void ColorRange_ShouldBeSettable()
        {
            var s = new MediaStream { ColorRange = "tv" };
            Assert.Equal("tv", s.ColorRange);
        }

        [Fact] public void ColorSpace_ShouldBeSettable()
        {
            var s = new MediaStream { ColorSpace = "bt709" };
            Assert.Equal("bt709", s.ColorSpace);
        }

        [Fact] public void ColorTransfer_ShouldBeSettable()
        {
            var s = new MediaStream { ColorTransfer = "bt709" };
            Assert.Equal("bt709", s.ColorTransfer);
        }

        [Fact] public void ColorPrimaries_ShouldBeSettable()
        {
            var s = new MediaStream { ColorPrimaries = "bt709" };
            Assert.Equal("bt709", s.ColorPrimaries);
        }

        [Fact] public void ChromaLocation_ShouldBeSettable()
        {
            var s = new MediaStream { ChromaLocation = "left" };
            Assert.Equal("left", s.ChromaLocation);
        }

        [Fact] public void Refs_ShouldBeSettable()
        {
            var s = new MediaStream { Refs = 4 };
            Assert.Equal(4, s.Refs);
        }

        [Fact] public void NalLengthSize_ShouldBeSettable()
        {
            var s = new MediaStream { NalLengthSize = "4" };
            Assert.Equal("4", s.NalLengthSize);
        }

        [Fact] public void RFrameRate_ShouldBeSettable()
        {
            var s = new MediaStream { RFrameRate = "30/1" };
            Assert.Equal("30/1", s.RFrameRate);
        }

        [Fact] public void TimeBase_ShouldBeSettable()
        {
            var s = new MediaStream { TimeBase = "1/90000" };
            Assert.Equal("1/90000", s.TimeBase);
        }

        [Fact] public void StartPts_ShouldBeSettable()
        {
            var s = new MediaStream { StartPts = 0 };
            Assert.Equal(0, s.StartPts);
        }

        [Fact] public void StartTime_ShouldBeSettable()
        {
            var s = new MediaStream { StartTime = "0.000000" };
            Assert.Equal("0.000000", s.StartTime);
        }

        [Fact] public void DurationTs_ShouldBeSettable()
        {
            var s = new MediaStream { DurationTs = 1024 };
            Assert.Equal(1024, s.DurationTs);
        }

        [Fact] public void NbFrames_ShouldBeSettable()
        {
            var s = new MediaStream { NbFrames = "300" };
            Assert.Equal("300", s.NbFrames);
        }

        [Fact] public void MaxBitRate_ShouldBeSettable()
        {
            var s = new MediaStream { MaxBitRate = "8000000" };
            Assert.Equal("8000000", s.MaxBitRate);
        }

        [Fact] public void SampleFmt_ShouldBeSettable()
        {
            var s = new MediaStream { SampleFmt = "s16" };
            Assert.Equal("s16", s.SampleFmt);
        }

        [Fact] public void ChannelLayout_ShouldBeSettable()
        {
            var s = new MediaStream { ChannelLayout = "stereo" };
            Assert.Equal("stereo", s.ChannelLayout);
        }

        [Fact] public void BitsPerSample_ShouldBeSettable()
        {
            var s = new MediaStream { BitsPerSample = 16 };
            Assert.Equal(16, s.BitsPerSample);
        }
    }
}
