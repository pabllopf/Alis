using Alis.Extension.Media.FFmpeg.BaseClasses;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.BaseClasses
{
    public class MediaStreamAllPropertiesCoverageTests
    {
        [Fact] public void Index_ShouldBeSettable() { var s = new MediaStream { Index = 1 }; Assert.Equal(1, s.Index); }
        [Fact] public void CodecName_ShouldBeSettable() { var s = new MediaStream { CodecName = "h264" }; Assert.Equal("h264", s.CodecName); }
        [Fact] public void CodecLongName_ShouldBeSettable() { var s = new MediaStream { CodecLongName = "H.264" }; Assert.Equal("H.264", s.CodecLongName); }
        [Fact] public void CodecType_ShouldBeSettable() { var s = new MediaStream { CodecType = "video" }; Assert.Equal("video", s.CodecType); }
        [Fact] public void CodecTimeBase_ShouldBeSettable() { var s = new MediaStream { CodecTimeBase = "1/50" }; Assert.Equal("1/50", s.CodecTimeBase); }
        [Fact] public void CodecTagString_ShouldBeSettable() { var s = new MediaStream { CodecTagString = "avc1" }; Assert.Equal("avc1", s.CodecTagString); }
        [Fact] public void CodecTag_ShouldBeSettable() { var s = new MediaStream { CodecTag = "0x0000" }; Assert.Equal("0x0000", s.CodecTag); }
        [Fact] public void Width_ShouldBeSettable() { var s = new MediaStream { Width = 1920 }; Assert.Equal(1920, s.Width); }
        [Fact] public void Height_ShouldBeSettable() { var s = new MediaStream { Height = 1080 }; Assert.Equal(1080, s.Height); }
        [Fact] public void CodedWidth_ShouldBeSettable() { var s = new MediaStream { CodedWidth = 1920 }; Assert.Equal(1920, s.CodedWidth); }
        [Fact] public void CodedHeight_ShouldBeSettable() { var s = new MediaStream { CodedHeight = 1080 }; Assert.Equal(1080, s.CodedHeight); }
        [Fact] public void HasBFrames_ShouldBeSettable() { var s = new MediaStream { HasBFrames = 2 }; Assert.Equal(2, s.HasBFrames); }
        [Fact] public void SampleAspectRatio_ShouldBeSettable() { var s = new MediaStream { SampleAspectRatio = "1:1" }; Assert.Equal("1:1", s.SampleAspectRatio); }
        [Fact] public void DisplayAspectRatio_ShouldBeSettable() { var s = new MediaStream { DisplayAspectRatio = "16:9" }; Assert.Equal("16:9", s.DisplayAspectRatio); }
        [Fact] public void PixFmt_ShouldBeSettable() { var s = new MediaStream { PixFmt = "yuv420p" }; Assert.Equal("yuv420p", s.PixFmt); }
        [Fact] public void ColorRange_ShouldBeSettable() { var s = new MediaStream { ColorRange = "tv" }; Assert.Equal("tv", s.ColorRange); }
        [Fact] public void ColorSpace_ShouldBeSettable() { var s = new MediaStream { ColorSpace = "bt709" }; Assert.Equal("bt709", s.ColorSpace); }
        [Fact] public void ColorTransfer_ShouldBeSettable() { var s = new MediaStream { ColorTransfer = "bt709" }; Assert.Equal("bt709", s.ColorTransfer); }
        [Fact] public void ColorPrimaries_ShouldBeSettable() { var s = new MediaStream { ColorPrimaries = "bt709" }; Assert.Equal("bt709", s.ColorPrimaries); }
        [Fact] public void ChromaLocation_ShouldBeSettable() { var s = new MediaStream { ChromaLocati = "left" }; Assert.Equal("left", s.ChromaLocati); }
        [Fact] public void Refs_ShouldBeSettable() { var s = new MediaStream { Refs = 3 }; Assert.Equal(3, s.Refs); }
        [Fact] public void IsAvc_ShouldBeSettable() { var s = new MediaStream { IsAvc = "true" }; Assert.Equal("true", s.IsAvc); }
        [Fact] public void NalLengthSize_ShouldBeSettable() { var s = new MediaStream { NalLengthSize = "4" }; Assert.Equal("4", s.NalLengthSize); }
        [Fact] public void RFrameRate_ShouldBeSettable() { var s = new MediaStream { RFrameRate = "30/1" }; Assert.Equal("30/1", s.RFrameRate); }
        [Fact] public void AvgFrameRate_ShouldBeSettable() { var s = new MediaStream { AvgFrameRate = "30/1" }; Assert.Equal("30/1", s.AvgFrameRate); }
        [Fact] public void TimeBase_ShouldBeSettable() { var s = new MediaStream { TimeBase = "1/50" }; Assert.Equal("1/50", s.TimeBase); }
        [Fact] public void StartPts_ShouldBeSettable() { var s = new MediaStream { StartPts = 0 }; Assert.Equal(0, s.StartPts); }
        [Fact] public void StartTime_ShouldBeSettable() { var s = new MediaStream { StartTime = "0.000" }; Assert.Equal("0.000", s.StartTime); }
        [Fact] public void DurationTs_ShouldBeSettable() { var s = new MediaStream { DurationTs = 1000 }; Assert.Equal(1000, s.DurationTs); }
        [Fact] public void Duration_ShouldBeSettable() { var s = new MediaStream { Duration = "10.0" }; Assert.Equal("10.0", s.Duration); }
        [Fact] public void BitRate_ShouldBeSettable() { var s = new MediaStream { BitRate = "128000" }; Assert.Equal("128000", s.BitRate); }
        [Fact] public void BitsPerRawSample_ShouldBeSettable() { var s = new MediaStream { BitsPerRawSample = "8" }; Assert.Equal("8", s.BitsPerRawSample); }
        [Fact] public void NbFrames_ShouldBeSettable() { var s = new MediaStream { NbFrames = "300" }; Assert.Equal("300", s.NbFrames); }
        [Fact] public void NumFrames_ShouldBeSettable() { var s = new MediaStream { NumFrames = "300" }; Assert.Equal("300", s.NumFrames); }
        [Fact] public void SampleFmt_ShouldBeSettable() { var s = new MediaStream { SampleFmt = "fltp" }; Assert.Equal("fltp", s.SampleFmt); }
        [Fact] public void SampleRateNumber_ShouldBeSettable() { var s = new MediaStream { SampleRateNumber = 44100 }; Assert.Equal(44100, s.SampleRateNumber); }
        [Fact] public void Channels_ShouldBeSettable() { var s = new MediaStream { Channels = 2 }; Assert.Equal(2, s.Channels); }
        [Fact] public void ChannelLayout_ShouldBeSettable() { var s = new MediaStream { ChannelLayout = "stereo" }; Assert.Equal("stereo", s.ChannelLayout); }
        [Fact] public void BitsPerSample_ShouldBeSettable() { var s = new MediaStream { BitsPerSample = 16 }; Assert.Equal(16, s.BitsPerSample); }
        [Fact] public void MaxBitRate_ShouldBeSettable() { var s = new MediaStream { MaxBitRate = "320000" }; Assert.Equal("320000", s.MaxBitRate); }
        [Fact] public void Profile_ShouldBeSettable() { var s = new MediaStream { Profile = "High" }; Assert.Equal("High", s.Profile); }
        [Fact] public void Level_ShouldBeSettable() { var s = new MediaStream { Level = 51 }; Assert.Equal(51, s.Level); }
        [Fact] public void AvgFrameRateNumber_Default_Zero() { var s = new MediaStream(); Assert.Equal(0.0, s.AvgFrameRateNumber); }
        [Fact] public void AvgFrameRateNumber_ShouldBeSettable() { var s = new MediaStream { AvgFrameRateNumber = 29.97 }; Assert.Equal(29.97, s.AvgFrameRateNumber); }
    }
}
