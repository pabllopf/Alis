

using System;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test
{
    /// <summary>
    ///     The media type test class
    /// </summary>
    /// <seealso cref="MediaType" />
    public class MediaTypeTest
    {
        /// <summary>
        ///     Tests that media type video should have correct value
        /// </summary>
        [Fact]
        public void MediaType_Video_ShouldHaveCorrectValue()
        {
            MediaType mediaType = MediaType.Video;

            Assert.Equal(0, (int) mediaType);
        }

        /// <summary>
        ///     Tests that media type audio should have correct value
        /// </summary>
        [Fact]
        public void MediaType_Audio_ShouldHaveCorrectValue()
        {
            MediaType mediaType = MediaType.Audio;

            Assert.Equal(1, (int) mediaType);
        }

        /// <summary>
        ///     Tests that media type subtitle should have correct value
        /// </summary>
        [Fact]
        public void MediaType_Subtitle_ShouldHaveCorrectValue()
        {
            MediaType mediaType = MediaType.Subtitle;

            Assert.Equal(2, (int) mediaType);
        }

        /// <summary>
        ///     Tests that media type enum should have three values
        /// </summary>
        [Fact]
        public void MediaType_Enum_ShouldHaveThreeValues()
        {
            MediaType[] values = (MediaType[]) Enum.GetValues(typeof(MediaType));

            Assert.Equal(3, values.Length);
        }

        /// <summary>
        ///     Tests that media type enum should contain video audio and subtitle
        /// </summary>
        [Fact]
        public void MediaType_Enum_ShouldContainVideoAudioAndSubtitle()
        {
            bool hasVideo = Enum.IsDefined(typeof(MediaType), MediaType.Video);
            bool hasAudio = Enum.IsDefined(typeof(MediaType), MediaType.Audio);
            bool hasSubtitle = Enum.IsDefined(typeof(MediaType), MediaType.Subtitle);

            Assert.True(hasVideo);
            Assert.True(hasAudio);
            Assert.True(hasSubtitle);
        }

        /// <summary>
        ///     Tests that media type should be convertible to string
        /// </summary>
        [Fact]
        public void MediaType_ShouldBeConvertibleToString()
        {
            MediaType video = MediaType.Video;
            MediaType audio = MediaType.Audio;
            MediaType subtitle = MediaType.Subtitle;

            string videoStr = video.ToString();
            string audioStr = audio.ToString();
            string subtitleStr = subtitle.ToString();

            Assert.Equal("Video", videoStr);
            Assert.Equal("Audio", audioStr);
            Assert.Equal("Subtitle", subtitleStr);
        }

        /// <summary>
        ///     Tests that media type should be parseable from string
        /// </summary>
        [Fact]
        public void MediaType_ShouldBeParseableFromString()
        {
            MediaType video = (MediaType) Enum.Parse(typeof(MediaType), "Video");
            MediaType audio = (MediaType) Enum.Parse(typeof(MediaType), "Audio");
            MediaType subtitle = (MediaType) Enum.Parse(typeof(MediaType), "Subtitle");

            Assert.Equal(MediaType.Video, video);
            Assert.Equal(MediaType.Audio, audio);
            Assert.Equal(MediaType.Subtitle, subtitle);
        }

        /// <summary>
        ///     Tests that media type should support equality comparison
        /// </summary>
        [Fact]
        public void MediaType_ShouldSupportEqualityComparison()
        {
            MediaType video1 = MediaType.Video;
            MediaType video2 = MediaType.Video;
            MediaType audio = MediaType.Audio;

            Assert.Equal(video1, video2);
            Assert.NotEqual(video1, audio);
        }

        /// <summary>
        ///     Tests that media type should be usable in switch statement
        /// </summary>
        [Fact]
        public void MediaType_ShouldBeUsableInSwitchStatement()
        {
            MediaType mediaType = MediaType.Audio;
            string result = string.Empty;

            switch (mediaType)
            {
                case MediaType.Video:
                    result = "Video";
                    break;
                case MediaType.Audio:
                    result = "Audio";
                    break;
                case MediaType.Subtitle:
                    result = "Subtitle";
                    break;
            }

            Assert.Equal("Audio", result);
        }

        /// <summary>
        ///     Tests that media type should have unique values
        /// </summary>
        [Fact]
        public void MediaType_ShouldHaveUniqueValues()
        {
            int videoValue = (int) MediaType.Video;
            int audioValue = (int) MediaType.Audio;
            int subtitleValue = (int) MediaType.Subtitle;

            Assert.NotEqual(videoValue, audioValue);
            Assert.NotEqual(audioValue, subtitleValue);
            Assert.NotEqual(videoValue, subtitleValue);
        }

        /// <summary>
        ///     Tests that media type should be castable to int
        /// </summary>
        [Fact]
        public void MediaType_ShouldBeCastableToInt()
        {
            MediaType mediaType = MediaType.Video;

            int value = (int) mediaType;

            Assert.Equal(0, value);
        }

        /// <summary>
        ///     Tests that media type should be castable from int
        /// </summary>
        [Fact]
        public void MediaType_ShouldBeCastableFromInt()
        {
            int value = 1;

            MediaType mediaType = (MediaType) value;

            Assert.Equal(MediaType.Audio, mediaType);
        }
    }
}