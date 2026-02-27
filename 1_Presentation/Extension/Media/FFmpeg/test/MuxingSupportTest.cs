// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MuxingSupportTest.cs
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
            // Arrange & Act
            MuxingSupport support = MuxingSupport.MuxDemux;

            // Assert
            Assert.Equal(0, (int)support);
        }

        /// <summary>
        ///     Tests that muxing support mux should have correct value
        /// </summary>
        [Fact]
        public void MuxingSupport_Mux_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            MuxingSupport support = MuxingSupport.Mux;

            // Assert
            Assert.Equal(1, (int)support);
        }

        /// <summary>
        ///     Tests that muxing support demux should have correct value
        /// </summary>
        [Fact]
        public void MuxingSupport_Demux_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            MuxingSupport support = MuxingSupport.Demux;

            // Assert
            Assert.Equal(2, (int)support);
        }

        /// <summary>
        ///     Tests that muxing support enum should have three values
        /// </summary>
        [Fact]
        public void MuxingSupport_Enum_ShouldHaveThreeValues()
        {
            // Arrange & Act
            MuxingSupport[] values = (MuxingSupport[])System.Enum.GetValues(typeof(MuxingSupport));

            // Assert
            Assert.Equal(3, values.Length);
        }

        /// <summary>
        ///     Tests that muxing support should be convertible to string
        /// </summary>
        [Fact]
        public void MuxingSupport_ShouldBeConvertibleToString()
        {
            // Arrange
            MuxingSupport muxDemux = MuxingSupport.MuxDemux;
            MuxingSupport mux = MuxingSupport.Mux;
            MuxingSupport demux = MuxingSupport.Demux;

            // Act
            string muxDemuxStr = muxDemux.ToString();
            string muxStr = mux.ToString();
            string demuxStr = demux.ToString();

            // Assert
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
            // Arrange & Act
            MuxingSupport muxDemux = (MuxingSupport)System.Enum.Parse(typeof(MuxingSupport), "MuxDemux");
            MuxingSupport mux = (MuxingSupport)System.Enum.Parse(typeof(MuxingSupport), "Mux");
            MuxingSupport demux = (MuxingSupport)System.Enum.Parse(typeof(MuxingSupport), "Demux");

            // Assert
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
            // Arrange
            MuxingSupport mux1 = MuxingSupport.Mux;
            MuxingSupport mux2 = MuxingSupport.Mux;
            MuxingSupport demux = MuxingSupport.Demux;

            // Act & Assert
            Assert.Equal(mux1, mux2);
            Assert.NotEqual(mux1, demux);
        }

        /// <summary>
        ///     Tests that muxing support should be usable in switch statement
        /// </summary>
        [Fact]
        public void MuxingSupport_ShouldBeUsableInSwitchStatement()
        {
            // Arrange
            MuxingSupport support = MuxingSupport.Mux;
            string result = string.Empty;

            // Act
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

            // Assert
            Assert.Equal("Mux", result);
        }

        /// <summary>
        ///     Tests that muxing support should have unique values
        /// </summary>
        [Fact]
        public void MuxingSupport_ShouldHaveUniqueValues()
        {
            // Arrange
            int muxDemuxValue = (int)MuxingSupport.MuxDemux;
            int muxValue = (int)MuxingSupport.Mux;
            int demuxValue = (int)MuxingSupport.Demux;

            // Act & Assert
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
            // Arrange
            MuxingSupport support = MuxingSupport.Demux;

            // Act
            int value = (int)support;

            // Assert
            Assert.Equal(2, value);
        }

        /// <summary>
        ///     Tests that muxing support should be castable from int
        /// </summary>
        [Fact]
        public void MuxingSupport_ShouldBeCastableFromInt()
        {
            // Arrange
            int value = 1;

            // Act
            MuxingSupport support = (MuxingSupport)value;

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
            Assert.True(System.Enum.IsDefined(typeof(MuxingSupport), MuxingSupport.MuxDemux));
            Assert.True(System.Enum.IsDefined(typeof(MuxingSupport), MuxingSupport.Mux));
            Assert.True(System.Enum.IsDefined(typeof(MuxingSupport), MuxingSupport.Demux));
        }
    }
}

