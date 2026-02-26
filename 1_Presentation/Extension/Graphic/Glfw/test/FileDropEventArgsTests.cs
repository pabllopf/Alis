// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FileDropEventArgsTests.cs
// 
//  Author:GitHub Copilot
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

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for FileDropEventArgs class
    /// </summary>
    public class FileDropEventArgsTests
    {
        /// <summary>
        /// Tests that constructor with valid filenames sets property
        /// </summary>
        [Fact]
        public void Constructor_WithValidFilenames_SetsProperty()
        {
            // Arrange
            string[] filenames = new[] { "file1.txt", "file2.png", "file3.jpg" };

            // Act
            FileDropEventArgs args = new FileDropEventArgs(filenames);

            // Assert
            Assert.Equal(filenames, args.Filenames);
        }

        /// <summary>
        /// Tests that filenames property returns correct array
        /// </summary>
        [Fact]
        public void Filenames_Property_ReturnsCorrectArray()
        {
            // Arrange
            string[] expectedFilenames = new[] { "document.pdf" };
            FileDropEventArgs args = new FileDropEventArgs(expectedFilenames);

            // Act
            string[] result = args.Filenames;

            // Assert
            Assert.Equal(expectedFilenames, result);
        }

        /// <summary>
        /// Tests that constructor with empty array sets property
        /// </summary>
        [Fact]
        public void Constructor_WithEmptyArray_SetsProperty()
        {
            // Arrange
            string[] filenames = new string[0];

            // Act
            FileDropEventArgs args = new FileDropEventArgs(filenames);

            // Assert
            Assert.Empty(args.Filenames);
        }

        /// <summary>
        /// Tests that constructor with single file sets property
        /// </summary>
        [Fact]
        public void Constructor_WithSingleFile_SetsProperty()
        {
            // Arrange
            string[] filenames = new[] { "single_file.txt" };

            // Act
            FileDropEventArgs args = new FileDropEventArgs(filenames);

            // Assert
            Assert.Single(args.Filenames);
            Assert.Equal("single_file.txt", args.Filenames[0]);
        }

        /// <summary>
        /// Tests that constructor with multiple files preserves order
        /// </summary>
        [Fact]
        public void Constructor_WithMultipleFiles_PreservesOrder()
        {
            // Arrange
            string[] filenames = new[] { "first.txt", "second.png", "third.jpg" };

            // Act
            FileDropEventArgs args = new FileDropEventArgs(filenames);

            // Assert
            Assert.Equal(3, args.Filenames.Length);
            Assert.Equal("first.txt", args.Filenames[0]);
            Assert.Equal("second.png", args.Filenames[1]);
            Assert.Equal("third.jpg", args.Filenames[2]);
        }

        /// <summary>
        /// Tests that constructor with paths containing spaces sets property
        /// </summary>
        [Fact]
        public void Constructor_WithPathsContainingSpaces_SetsProperty()
        {
            // Arrange
            string[] filenames = new[] { "my document.txt", "another file.png" };

            // Act
            FileDropEventArgs args = new FileDropEventArgs(filenames);

            // Assert
            Assert.Equal(filenames, args.Filenames);
        }

        /// <summary>
        /// Tests that constructor with absolute paths sets property
        /// </summary>
        [Fact]
        public void Constructor_WithAbsolutePaths_SetsProperty()
        {
            // Arrange
            string[] filenames = new[] { "/usr/local/bin/file.txt", "C:\\Users\\file.txt" };

            // Act
            FileDropEventArgs args = new FileDropEventArgs(filenames);

            // Assert
            Assert.Equal(filenames, args.Filenames);
        }
    }
}

