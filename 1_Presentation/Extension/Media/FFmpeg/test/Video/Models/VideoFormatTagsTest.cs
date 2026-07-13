// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoFormatTagsTest.cs
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

using Alis.Extension.Media.FFmpeg.Video.Models;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video.Models
{
    /// <summary>
    ///     The video format tags test class
    /// </summary>
    /// <seealso cref="VideoFormatTags" />
    public class VideoFormatTagsTest
    {
        /// <summary>
        ///     Tests that video format tags default constructor should initialize empty strings
        /// </summary>
        [Fact]
        public void VideoFormatTags_DefaultConstructor_ShouldInitializeEmptyStrings()
        {
            VideoFormatTags tags = new VideoFormatTags();

            Assert.Equal(string.Empty, tags.MajorBrand);
            Assert.Equal(string.Empty, tags.MinorVersion);
            Assert.Equal(string.Empty, tags.CompatibleBrands);
            Assert.Equal(string.Empty, tags.CreationTime);
            Assert.Equal(string.Empty, tags.Encoder);
        }

        /// <summary>
        ///     Tests that video format tags parameterized constructor should set all properties
        /// </summary>
        [Fact]
        public void VideoFormatTags_ParameterizedConstructor_ShouldSetAllProperties()
        {
            const string majorBrand = "isom";
            const string minorVersion = "512";
            const string compatibleBrands = "isom,iso2,mp41";
            const string creationTime = "2021-01-01T00:00:00.000000Z";
            const string encoder = "Lavf60.0.0";

            VideoFormatTags tags = new VideoFormatTags(majorBrand, minorVersion, compatibleBrands, creationTime, encoder);

            Assert.Equal(majorBrand, tags.MajorBrand);
            Assert.Equal(minorVersion, tags.MinorVersion);
            Assert.Equal(compatibleBrands, tags.CompatibleBrands);
            Assert.Equal(creationTime, tags.CreationTime);
            Assert.Equal(encoder, tags.Encoder);
        }

        /// <summary>
        ///     Tests that video format tags major brand property should be settable
        /// </summary>
        [Fact]
        public void VideoFormatTags_MajorBrandProperty_ShouldBeSettable()
        {
            VideoFormatTags tags = new VideoFormatTags();
            const string majorBrand = "isom";

            tags.MajorBrand = majorBrand;

            Assert.Equal(majorBrand, tags.MajorBrand);
        }

        /// <summary>
        ///     Tests that video format tags minor version property should be settable
        /// </summary>
        [Fact]
        public void VideoFormatTags_MinorVersionProperty_ShouldBeSettable()
        {
            VideoFormatTags tags = new VideoFormatTags();
            const string minorVersion = "512";

            tags.MinorVersion = minorVersion;

            Assert.Equal(minorVersion, tags.MinorVersion);
        }

        /// <summary>
        ///     Tests that video format tags compatible brands property should be settable
        /// </summary>
        [Fact]
        public void VideoFormatTags_CompatibleBrandsProperty_ShouldBeSettable()
        {
            VideoFormatTags tags = new VideoFormatTags();
            const string compatibleBrands = "isom,iso2,mp41";

            tags.CompatibleBrands = compatibleBrands;

            Assert.Equal(compatibleBrands, tags.CompatibleBrands);
        }

        /// <summary>
        ///     Tests that video format tags creation time property should be settable
        /// </summary>
        [Fact]
        public void VideoFormatTags_CreationTimeProperty_ShouldBeSettable()
        {
            VideoFormatTags tags = new VideoFormatTags();
            const string creationTime = "2021-01-01T00:00:00.000000Z";

            tags.CreationTime = creationTime;

            Assert.Equal(creationTime, tags.CreationTime);
        }

        /// <summary>
        ///     Tests that video format tags encoder property should be settable
        /// </summary>
        [Fact]
        public void VideoFormatTags_EncoderProperty_ShouldBeSettable()
        {
            VideoFormatTags tags = new VideoFormatTags();
            const string encoder = "Lavf60.0.0";

            tags.Encoder = encoder;

            Assert.Equal(encoder, tags.Encoder);
        }

        /// <summary>
        ///     Tests that video format tags should support null values
        /// </summary>
        [Fact]
        public void VideoFormatTags_ShouldSupportNullValues()
        {
            VideoFormatTags tags = new VideoFormatTags();

            tags.MajorBrand = null;
            tags.MinorVersion = null;
            tags.CompatibleBrands = null;
            tags.CreationTime = null;
            tags.Encoder = null;

            Assert.Null(tags.MajorBrand);
            Assert.Null(tags.MinorVersion);
            Assert.Null(tags.CompatibleBrands);
            Assert.Null(tags.CreationTime);
            Assert.Null(tags.Encoder);
        }

        /// <summary>
        ///     Tests that video format tags should support initializer syntax
        /// </summary>
        [Fact]
        public void VideoFormatTags_ShouldSupportInitializerSyntax()
        {
            VideoFormatTags tags = new VideoFormatTags
            {
                MajorBrand = "isom",
                MinorVersion = "512",
                CompatibleBrands = "isom,iso2,mp41",
                CreationTime = "2021-01-01T00:00:00.000000Z",
                Encoder = "Lavf60.0.0"
            };

            Assert.Equal("isom", tags.MajorBrand);
            Assert.Equal("512", tags.MinorVersion);
            Assert.Equal("isom,iso2,mp41", tags.CompatibleBrands);
            Assert.Equal("2021-01-01T00:00:00.000000Z", tags.CreationTime);
            Assert.Equal("Lavf60.0.0", tags.Encoder);
        }

        /// <summary>
        ///     Tests that video format tags properties should be mutable
        /// </summary>
        [Fact]
        public void VideoFormatTags_Properties_ShouldBeMutable()
        {
            VideoFormatTags tags = new VideoFormatTags
            {
                MajorBrand = "isom",
                Encoder = "Lavf60.0.0"
            };

            tags.MajorBrand = "mp42";
            tags.Encoder = "Lavf61.0.0";

            Assert.Equal("mp42", tags.MajorBrand);
            Assert.Equal("Lavf61.0.0", tags.Encoder);
        }
    }
}