// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FilePickerFilterTest.cs
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

using System;
using Xunit;

namespace Alis.Extension.Io.FileDialog.Test
{
    /// <summary>
    ///     Unit tests for FilePickerFilter class.
    /// </summary>
    public class FilePickerFilterTest
    {
        /// <summary>
        ///     Tests that FilePickerFilter constructor creates instance with valid parameters.
        /// </summary>
        [Fact]
        public void Constructor_WithValidParameters_ShouldCreateInstance()
        {
            // Act
            var filter = new FilePickerFilter("Text Files", "txt", "doc");

            // Assert
            Assert.NotNull(filter);
            Assert.Equal("Text Files", filter.DisplayName);
            Assert.Contains("txt", filter.Extensions);
            Assert.Contains("doc", filter.Extensions);
        }

        /// <summary>
        ///     Tests that FilePickerFilter constructor removes leading dots from extensions.
        /// </summary>
        [Fact]
        public void Constructor_WithDotsInExtensions_ShouldRemoveDots()
        {
            // Act
            var filter = new FilePickerFilter("Text Files", ".txt", ".doc");

            // Assert
            Assert.Equal("txt", filter.Extensions[0]);
            Assert.Equal("doc", filter.Extensions[1]);
        }

        /// <summary>
        ///     Tests that FilePickerFilter constructor throws with null display name.
        /// </summary>
        [Fact]
        public void Constructor_WithNullDisplayName_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FilePickerFilter(null, "txt"));
        }

        /// <summary>
        ///     Tests that FilePickerFilter constructor throws with empty display name.
        /// </summary>
        [Fact]
        public void Constructor_WithEmptyDisplayName_ShouldThrowArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FilePickerFilter("", "txt"));
        }

        /// <summary>
        ///     Tests that FilePickerFilter constructor throws with null extensions.
        /// </summary>
        [Fact]
        public void Constructor_WithNullExtensions_ShouldThrowArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FilePickerFilter("Text Files", null));
        }

        /// <summary>
        ///     Tests that FilePickerFilter constructor throws with empty extensions array.
        /// </summary>
        [Fact]
        public void Constructor_WithEmptyExtensionsArray_ShouldThrowArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FilePickerFilter("Text Files"));
        }

        /// <summary>
        ///     Tests that GetFormattedExtensions returns correct format.
        /// </summary>
        [Fact]
        public void GetFormattedExtensions_ShouldReturnCorrectFormat()
        {
            // Arrange
            var filter = new FilePickerFilter("Text Files", "txt", "doc");

            // Act
            string formatted = filter.GetFormattedExtensions();

            // Assert
            Assert.Equal("*.txt;*.doc", formatted);
        }

        /// <summary>
        ///     Tests that GetUtiFormat returns correct UTI format.
        /// </summary>
        [Fact]
        public void GetUtiFormat_ShouldReturnCorrectFormat()
        {
            // Arrange
            var filter = new FilePickerFilter("Text Files", "txt", "doc");

            // Act
            string utiFormat = filter.GetUtiFormat();

            // Assert
            Assert.Equal("txt,doc", utiFormat);
        }

        /// <summary>
        ///     Tests that FilePickerFilter handles case-insensitive extensions.
        /// </summary>
        [Fact]
        public void Constructor_WithMixedCaseExtensions_ShouldPreserveLowerCase()
        {
            // Act
            var filter = new FilePickerFilter("Text Files", "TXT", "Doc");

            // Assert
            Assert.Equal("TXT", filter.Extensions[0]); // Original case preserved
            Assert.Equal("Doc", filter.Extensions[1]);
        }

        /// <summary>
        ///     Tests that FilePickerFilter with single extension works correctly.
        /// </summary>
        [Fact]
        public void Constructor_WithSingleExtension_ShouldWork()
        {
            // Act
            var filter = new FilePickerFilter("PDF Files", "pdf");

            // Assert
            Assert.Single(filter.Extensions);
            Assert.Equal("pdf", filter.Extensions[0]);
        }

        /// <summary>
        ///     Tests that FilePickerFilter with many extensions works correctly.
        /// </summary>
        [Fact]
        public void Constructor_WithManyExtensions_ShouldWork()
        {
            // Arrange
            var extensions = new[] { "jpg", "png", "gif", "bmp", "ico" };

            // Act
            var filter = new FilePickerFilter("Image Files", extensions);

            // Assert
            Assert.Equal(5, filter.Extensions.Count);
            foreach (var ext in extensions)
            {
                Assert.Contains(ext, filter.Extensions);
            }
        }
    }
}

