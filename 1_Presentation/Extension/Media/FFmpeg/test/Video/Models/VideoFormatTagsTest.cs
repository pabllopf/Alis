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
        ///     Tests that video format tags constructor should create instance
        /// </summary>
        [Fact]
        public void VideoFormatTags_Constructor_ShouldCreateInstance()
        {
            // Arrange & Act
            VideoFormatTags tags = new VideoFormatTags();

            // Assert
            Assert.NotNull(tags);
        }

        /// <summary>
        ///     Tests that video format tags creation time property should be settable
        /// </summary>
        [Fact]
        public void VideoFormatTags_CreationTimeProperty_ShouldBeSettable()
        {
            // Arrange
            VideoFormatTags tags = new VideoFormatTags();
            string creationTime = "2021-01-01T00:00:00.000000Z";

            // Act
            tags.CreationTime = creationTime;

            // Assert
            Assert.Equal(creationTime, tags.CreationTime);
        }
    }
}