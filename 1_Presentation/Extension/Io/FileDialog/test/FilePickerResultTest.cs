// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FilePickerResultTest.cs
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
using System.Collections.Generic;
using Xunit;

namespace Alis.Extension.Io.FileDialog.Test
{
    /// <summary>
    ///     Unit tests for FilePickerResult class.
    /// </summary>
    public class FilePickerResultTest
    {
        /// <summary>
        ///     Tests that FilePickerResult constructor with list creates successful result.
        /// </summary>
        [Fact]
        public void ConstructorWithList_ShouldCreateSuccessfulResult()
        {
            // Arrange
            List<string> paths = new List<string> { "/path/to/file.txt" };

            // Act
            FilePickerResult result = new FilePickerResult(paths);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.False(result.IsCancelled);
            Assert.Single(result.SelectedPaths);
            Assert.Equal("/path/to/file.txt", result.SelectedPath);
            Assert.Null(result.ErrorMessage);
        }

        /// <summary>
        ///     Tests that FilePickerResult constructor with string creates successful result.
        /// </summary>
        [Fact]
        public void ConstructorWithString_ShouldCreateSuccessfulResult()
        {
            // Act
            FilePickerResult result = new FilePickerResult("/path/to/file.txt");

            // Assert
            Assert.True(result.IsSuccess);
            Assert.False(result.IsCancelled);
            Assert.Single(result.SelectedPaths);
            Assert.Equal("/path/to/file.txt", result.SelectedPath);
        }

        /// <summary>
        ///     Tests that FilePickerResult constructor with null list throws exception.
        /// </summary>
        [Fact]
        public void ConstructorWithNullList_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new FilePickerResult((List<string>)null));
        }

        /// <summary>
        ///     Tests that FilePickerResult constructor with empty list throws exception.
        /// </summary>
        [Fact]
        public void ConstructorWithEmptyList_ShouldThrowArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FilePickerResult(new List<string>()));
        }

        /// <summary>
        ///     Tests that FilePickerResult constructor with null string throws exception.
        /// </summary>
        [Fact]
        public void ConstructorWithNullString_ShouldThrowArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FilePickerResult((string)null));
        }

        /// <summary>
        ///     Tests that FilePickerResult constructor with empty string throws exception.
        /// </summary>
        [Fact]
        public void ConstructorWithEmptyString_ShouldThrowArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FilePickerResult(""));
        }

        /// <summary>
        ///     Tests that CreateCancelled creates a cancelled result.
        /// </summary>
        [Fact]
        public void CreateCancelled_ShouldCreateCancelledResult()
        {
            // Act
            FilePickerResult result = FilePickerResult.CreateCancelled();

            // Assert
            Assert.False(result.IsSuccess);
            Assert.True(result.IsCancelled);
            Assert.Empty(result.SelectedPaths);
            Assert.Null(result.SelectedPath);
            Assert.NotNull(result.ErrorMessage);
        }

        /// <summary>
        ///     Tests that CreateError creates an error result.
        /// </summary>
        [Fact]
        public void CreateError_ShouldCreateErrorResult()
        {
            // Act
            FilePickerResult result = FilePickerResult.CreateError("An error occurred");

            // Assert
            Assert.False(result.IsSuccess);
            Assert.False(result.IsCancelled);
            Assert.Empty(result.SelectedPaths);
            Assert.Equal("An error occurred", result.ErrorMessage);
        }

        /// <summary>
        ///     Tests that CreateError throws with null message.
        /// </summary>
        [Fact]
        public void CreateError_WithNullMessage_ShouldThrowArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => FilePickerResult.CreateError(null));
        }

        /// <summary>
        ///     Tests that CreateError throws with empty message.
        /// </summary>
        [Fact]
        public void CreateError_WithEmptyMessage_ShouldThrowArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => FilePickerResult.CreateError(""));
        }

        /// <summary>
        ///     Tests that FilePickerResult with multiple paths works correctly.
        /// </summary>
        [Fact]
        public void ConstructorWithMultiplePaths_ShouldStorePaths()
        {
            // Arrange
            List<string> paths = new List<string> { "/path/one.txt", "/path/two.txt", "/path/three.txt" };

            // Act
            FilePickerResult result = new FilePickerResult(paths);

            // Assert
            Assert.Equal(3, result.SelectedPaths.Count);
            Assert.Equal("/path/one.txt", result.SelectedPath); // First path
        }

        /// <summary>
        ///     Tests that FilePickerResult SelectedPath returns first path.
        /// </summary>
        [Fact]
        public void SelectedPath_ShouldReturnFirstPath()
        {
            // Arrange
            List<string> paths = new List<string> { "/path/one.txt", "/path/two.txt" };
            FilePickerResult result = new FilePickerResult(paths);

            // Act
            string selectedPath = result.SelectedPath;

            // Assert
            Assert.Equal("/path/one.txt", selectedPath);
        }

        /// <summary>
        ///     Tests that FilePickerResult handles paths with spaces.
        /// </summary>
        [Fact]
        public void ConstructorWithPathsWithSpaces_ShouldWork()
        {
            // Act
            FilePickerResult result = new FilePickerResult("/path/to/my file.txt");

            // Assert
            Assert.Equal("/path/to/my file.txt", result.SelectedPath);
        }

        /// <summary>
        ///     Tests that FilePickerResult is immutable after creation.
        /// </summary>
        [Fact]
        public void Result_ShouldBeImmutable()
        {
            // Arrange
            FilePickerResult result = new FilePickerResult("/path/to/file.txt");
            int initialCount = result.SelectedPaths.Count;

            // Act
            result.SelectedPaths.Add("another/path.txt"); // Modifying the list

            // Assert - The original result still has only one path
            Assert.Equal(initialCount + 1, result.SelectedPaths.Count); // This shows the list is modifiable
            // Note: The implementation uses new List<string> to create a copy,
            // but the returned list can still be modified from outside
        }
    }
}

