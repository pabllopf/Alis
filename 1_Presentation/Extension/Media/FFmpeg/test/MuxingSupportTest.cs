

using System;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test
{
    /// <summary>
    ///     The muxing support test class
    /// </summary>
    /// <seealso cref="MuxingSupport" />
    public class MuxingSupportTest
    {
        /// <summary>
        ///     Tests that muxing support mux demux should have correct value
        /// </summary>
        [Fact]
        public void MuxingSupport_MuxDemux_ShouldHaveCorrectValue()
        {
            MuxingSupport support = MuxingSupport.MuxDemux;

            Assert.Equal(0, (int) support);
        }

        /// <summary>
        ///     Tests that muxing support mux should have correct value
        /// </summary>
        [Fact]
        public void MuxingSupport_Mux_ShouldHaveCorrectValue()
        {
            MuxingSupport support = MuxingSupport.Mux;

            Assert.Equal(1, (int) support);
        }

        /// <summary>
        ///     Tests that muxing support demux should have correct value
        /// </summary>
        [Fact]
        public void MuxingSupport_Demux_ShouldHaveCorrectValue()
        {
            MuxingSupport support = MuxingSupport.Demux;

            Assert.Equal(2, (int) support);
        }

        /// <summary>
        ///     Tests that muxing support enum should have three values
        /// </summary>
        [Fact]
        public void MuxingSupport_Enum_ShouldHaveThreeValues()
        {
            MuxingSupport[] values = (MuxingSupport[]) Enum.GetValues(typeof(MuxingSupport));

            Assert.Equal(3, values.Length);
        }

        /// <summary>
        ///     Tests that muxing support should be convertible to string
        /// </summary>
        [Fact]
        public void MuxingSupport_ShouldBeConvertibleToString()
        {
            MuxingSupport muxDemux = MuxingSupport.MuxDemux;
            MuxingSupport mux = MuxingSupport.Mux;
            MuxingSupport demux = MuxingSupport.Demux;

            string muxDemuxStr = muxDemux.ToString();
            string muxStr = mux.ToString();
            string demuxStr = demux.ToString();

            Assert.Equal("MuxDemux", muxDemuxStr);
            Assert.Equal("Mux", muxStr);
            Assert.Equal("Demux", demuxStr);
        }

        /// <summary>
        ///     Tests that muxing support should be parseable from string
        /// </summary>
        [Fact]
        public void MuxingSupport_ShouldBeParseableFromString()
        {
            MuxingSupport muxDemux = (MuxingSupport) Enum.Parse(typeof(MuxingSupport), "MuxDemux");
            MuxingSupport mux = (MuxingSupport) Enum.Parse(typeof(MuxingSupport), "Mux");
            MuxingSupport demux = (MuxingSupport) Enum.Parse(typeof(MuxingSupport), "Demux");

            Assert.Equal(MuxingSupport.MuxDemux, muxDemux);
            Assert.Equal(MuxingSupport.Mux, mux);
            Assert.Equal(MuxingSupport.Demux, demux);
        }

        /// <summary>
        ///     Tests that muxing support should support equality comparison
        /// </summary>
        [Fact]
        public void MuxingSupport_ShouldSupportEqualityComparison()
        {
            MuxingSupport mux1 = MuxingSupport.Mux;
            MuxingSupport mux2 = MuxingSupport.Mux;
            MuxingSupport demux = MuxingSupport.Demux;

            Assert.Equal(mux1, mux2);
            Assert.NotEqual(mux1, demux);
        }

        /// <summary>
        ///     Tests that muxing support should be usable in switch statement
        /// </summary>
        [Fact]
        public void MuxingSupport_ShouldBeUsableInSwitchStatement()
        {
            MuxingSupport support = MuxingSupport.Mux;
            string result = string.Empty;

            switch (support)
            {
                case MuxingSupport.MuxDemux:
                    result = "MuxDemux";
                    break;
                case MuxingSupport.Mux:
                    result = "Mux";
                    break;
                case MuxingSupport.Demux:
                    result = "Demux";
                    break;
            }

            Assert.Equal("Mux", result);
        }

        /// <summary>
        ///     Tests that muxing support should have unique values
        /// </summary>
        [Fact]
        public void MuxingSupport_ShouldHaveUniqueValues()
        {
            int muxDemuxValue = (int) MuxingSupport.MuxDemux;
            int muxValue = (int) MuxingSupport.Mux;
            int demuxValue = (int) MuxingSupport.Demux;

            Assert.NotEqual(muxDemuxValue, muxValue);
            Assert.NotEqual(muxValue, demuxValue);
            Assert.NotEqual(muxDemuxValue, demuxValue);
        }

        /// <summary>
        ///     Tests that muxing support should be castable to int
        /// </summary>
        [Fact]
        public void MuxingSupport_ShouldBeCastableToInt()
        {
            MuxingSupport support = MuxingSupport.Demux;

            int value = (int) support;

            Assert.Equal(2, value);
        }

        /// <summary>
        ///     Tests that muxing support should be castable from int
        /// </summary>
        [Fact]
        public void MuxingSupport_ShouldBeCastableFromInt()
        {
            int value = 1;

            // Act
            MuxingSupport support = (MuxingSupport) value;

            // Assert
            Assert.Equal(MuxingSupport.Mux, support);
        }

        /// <summary>
        ///     Tests that muxing support all values should be defined
        /// </summary>
        [Fact]
        public void MuxingSupport_AllValues_ShouldBeDefined()
        {
            // Arrange & Act & Assert
            Assert.True(Enum.IsDefined(typeof(MuxingSupport), MuxingSupport.MuxDemux));
            Assert.True(Enum.IsDefined(typeof(MuxingSupport), MuxingSupport.Mux));
            Assert.True(Enum.IsDefined(typeof(MuxingSupport), MuxingSupport.Demux));
        }
    }
}