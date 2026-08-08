using Alis.Extension.Media.FFmpeg.BaseClasses;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.BaseClasses
{
    /// <summary>
    /// The media stream additional coverage tests class
    /// </summary>
    public class MediaStreamAdditionalCoverageTests
    {
        /// <summary>
        /// Tests that codec time base should be settable
        /// </summary>
        [RequireFfmpegFact] public void CodecTimeBase_ShouldBeSettable()
        {
            MediaStream s = new MediaStream { CodecTimeBase = "1/50" };
            Assert.Equal("1/50", s.CodecTimeBase);
        }

        /// <summary>
        /// Tests that codec tag string should be settable
        /// </summary>
        [RequireFfmpegFact] public void CodecTagString_ShouldBeSettable()
        {
            MediaStream s = new MediaStream { CodecTagString = "avc1" };
            Assert.Equal("avc1", s.CodecTagString);
        }

        /// <summary>
        /// Tests that codec tag should be settable
        /// </summary>
        [RequireFfmpegFact] public void CodecTag_ShouldBeSettable()
        {
            MediaStream s = new MediaStream { CodecTag = "0x31637661" };
            Assert.Equal("0x31637661", s.CodecTag);
        }

        /// <summary>
        /// Tests that coded width should be settable
        /// </summary>
        [RequireFfmpegFact] public void CodedWidth_ShouldBeSettable()
        {
            MediaStream s = new MediaStream { CodedWidth = 1920 };
            Assert.Equal(1920, s.CodedWidth);
        }

        /// <summary>
        /// Tests that coded height should be settable
        /// </summary>
        [RequireFfmpegFact] public void CodedHeight_ShouldBeSettable()
        {
            MediaStream s = new MediaStream { CodedHeight = 1080 };
            Assert.Equal(1080, s.CodedHeight);
        }

        /// <summary>
        /// Tests that has b frames should be settable
        /// </summary>
        [RequireFfmpegFact] public void HasBFrames_ShouldBeSettable()
        {
            MediaStream s = new MediaStream { HasBFrames = 2 };
            Assert.Equal(2, s.HasBFrames);
        }

        /// <summary>
        /// Tests that sample aspect ratio should be settable
        /// </summary>
        [RequireFfmpegFact] public void SampleAspectRatio_ShouldBeSettable()
        {
            MediaStream s = new MediaStream { SampleAspectRatio = "1:1" };
            Assert.Equal("1:1", s.SampleAspectRatio);
        }

        /// <summary>
        /// Tests that display aspect ratio should be settable
        /// </summary>
        [RequireFfmpegFact] public void DisplayAspectRatio_ShouldBeSettable()
        {
            MediaStream s = new MediaStream { DisplayAspectRatio = "16:9" };
            Assert.Equal("16:9", s.DisplayAspectRatio);
        }

        /// <summary>
        /// Tests that color range should be settable
        /// </summary>
        [RequireFfmpegFact] public void ColorRange_ShouldBeSettable()
        {
            MediaStream s = new MediaStream { ColorRange = "tv" };
            Assert.Equal("tv", s.ColorRange);
        }

        /// <summary>
        /// Tests that color space should be settable
        /// </summary>
        [RequireFfmpegFact] public void ColorSpace_ShouldBeSettable()
        {
            MediaStream s = new MediaStream { ColorSpace = "bt709" };
            Assert.Equal("bt709", s.ColorSpace);
        }

        /// <summary>
        /// Tests that color transfer should be settable
        /// </summary>
        [RequireFfmpegFact] public void ColorTransfer_ShouldBeSettable()
        {
            MediaStream s = new MediaStream { ColorTransfer = "bt709" };
            Assert.Equal("bt709", s.ColorTransfer);
        }

        /// <summary>
        /// Tests that color primaries should be settable
        /// </summary>
        [RequireFfmpegFact] public void ColorPrimaries_ShouldBeSettable()
        {
            MediaStream s = new MediaStream { ColorPrimaries = "bt709" };
            Assert.Equal("bt709", s.ColorPrimaries);
        }

        /// <summary>
        /// Tests that chroma location should be settable
        /// </summary>
        [RequireFfmpegFact] public void ChromaLocation_ShouldBeSettable()
        {
            MediaStream s = new MediaStream { ChromaLocation = "left" };
            Assert.Equal("left", s.ChromaLocation);
        }

        /// <summary>
        /// Tests that refs should be settable
        /// </summary>
        [RequireFfmpegFact] public void Refs_ShouldBeSettable()
        {
            MediaStream s = new MediaStream { Refs = 4 };
            Assert.Equal(4, s.Refs);
        }

        /// <summary>
        /// Tests that nal length size should be settable
        /// </summary>
        [RequireFfmpegFact] public void NalLengthSize_ShouldBeSettable()
        {
            MediaStream s = new MediaStream { NalLengthSize = "4" };
            Assert.Equal("4", s.NalLengthSize);
        }

        /// <summary>
        /// Tests that r frame rate should be settable
        /// </summary>
        [RequireFfmpegFact] public void RFrameRate_ShouldBeSettable()
        {
            MediaStream s = new MediaStream { RFrameRate = "30/1" };
            Assert.Equal("30/1", s.RFrameRate);
        }

        /// <summary>
        /// Tests that time base should be settable
        /// </summary>
        [RequireFfmpegFact] public void TimeBase_ShouldBeSettable()
        {
            MediaStream s = new MediaStream { TimeBase = "1/90000" };
            Assert.Equal("1/90000", s.TimeBase);
        }

        /// <summary>
        /// Tests that start pts should be settable
        /// </summary>
        [RequireFfmpegFact] public void StartPts_ShouldBeSettable()
        {
            MediaStream s = new MediaStream { StartPts = 0 };
            Assert.Equal(0, s.StartPts);
        }

        /// <summary>
        /// Tests that start time should be settable
        /// </summary>
        [RequireFfmpegFact] public void StartTime_ShouldBeSettable()
        {
            MediaStream s = new MediaStream { StartTime = "0.000000" };
            Assert.Equal("0.000000", s.StartTime);
        }

        /// <summary>
        /// Tests that duration ts should be settable
        /// </summary>
        [RequireFfmpegFact] public void DurationTs_ShouldBeSettable()
        {
            MediaStream s = new MediaStream { DurationTs = 1024 };
            Assert.Equal(1024, s.DurationTs);
        }

        /// <summary>
        /// Tests that nb frames should be settable
        /// </summary>
        [RequireFfmpegFact] public void NbFrames_ShouldBeSettable()
        {
            MediaStream s = new MediaStream { NbFrames = "300" };
            Assert.Equal("300", s.NbFrames);
        }

        /// <summary>
        /// Tests that max bit rate should be settable
        /// </summary>
        [RequireFfmpegFact] public void MaxBitRate_ShouldBeSettable()
        {
            MediaStream s = new MediaStream { MaxBitRate = "8000000" };
            Assert.Equal("8000000", s.MaxBitRate);
        }

        /// <summary>
        /// Tests that sample fmt should be settable
        /// </summary>
        [RequireFfmpegFact] public void SampleFmt_ShouldBeSettable()
        {
            MediaStream s = new MediaStream { SampleFmt = "s16" };
            Assert.Equal("s16", s.SampleFmt);
        }

        /// <summary>
        /// Tests that channel layout should be settable
        /// </summary>
        [RequireFfmpegFact] public void ChannelLayout_ShouldBeSettable()
        {
            MediaStream s = new MediaStream { ChannelLayout = "stereo" };
            Assert.Equal("stereo", s.ChannelLayout);
        }

        /// <summary>
        /// Tests that bits per sample should be settable
        /// </summary>
        [RequireFfmpegFact] public void BitsPerSample_ShouldBeSettable()
        {
            MediaStream s = new MediaStream { BitsPerSample = 16 };
            Assert.Equal(16, s.BitsPerSample);
        }
    }
}
