// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FilePickerValidatorTest.cs
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
using System.IO;
using Xunit;

namespace Alis.Extension.Io.FileDialog.Test
{
    /// <summary>
    ///     Unit tests for FilePickerValidator static class.
    /// </summary>
    public class FilePickerValidatorTest
    {
        /// <summary>
        ///     Tests that ValidateOptions throws with null options.
        /// </summary>
        [Fact]
        public void ValidateOptions_WithNull_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => FilePickerValidator.ValidateOptions(null));
        }

        /// <summary>
        ///     Tests that ValidateOptions throws with null title.
        /// </summary>
        [Fact]
        public void ValidateOptions_WithNullTitle_ShouldThrowArgumentException()
        {
            // Arrange
            FilePickerOptions options = new FilePickerOptions { Title = null };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => FilePickerValidator.ValidateOptions(options));
        }

        /// <summary>
        ///     Tests that ValidateOptions throws with empty title.
        /// </summary>
        [Fact]
        public void ValidateOptions_WithEmptyTitle_ShouldThrowArgumentException()
        {
            // Arrange
            FilePickerOptions options = new FilePickerOptions { Title = "" };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => FilePickerValidator.ValidateOptions(options));
        }

        /// <summary>
        ///     Tests that ValidateOptions throws with invalid default path.
        /// </summary>
        [Fact]
        public void ValidateOptions_WithInvalidDefaultPath_ShouldThrowArgumentException()
        {
            // Arrange
            FilePickerOptions options = new FilePickerOptions("Test") { DefaultPath = "/nonexistent/path/that/does/not/exist" };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => FilePickerValidator.ValidateOptions(options));
        }

        /// <summary>
        ///     Tests that ValidateOptions throws when SaveFile allows multiple.
        /// </summary>
        [Fact]
        public void ValidateOptions_WithSaveFileMultiple_ShouldThrowArgumentException()
        {
            // Arrange
            FilePickerOptions options = new FilePickerOptions("Save", FileDialogType.SaveFile)
            {
                AllowMultiple = true
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => FilePickerValidator.ValidateOptions(options));
        }

        /// <summary>
        ///     Tests that ValidateOptions throws when AllowDirectories is true for non-SelectFolder.
        /// </summary>
        [Fact]
        public void ValidateOptions_WithAllowDirectoriesOnOpenFile_ShouldThrowArgumentException()
        {
            // Arrange
            FilePickerOptions options = new FilePickerOptions("Open", FileDialogType.OpenFile)
            {
                AllowDirectories = true
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => FilePickerValidator.ValidateOptions(options));
        }

        /// <summary>
        ///     Tests that ValidateOptions passes with valid options.
        /// </summary>
        [Fact]
        public void ValidateOptions_WithValidOptions_ShouldNotThrow()
        {
            // Arrange
            FilePickerOptions options = new FilePickerOptions("Open File");

            // Act & Assert - Should not throw
            FilePickerValidator.ValidateOptions(options);
        }

        /// <summary>
        ///     Tests that IsValidFilePath returns false for null path.
        /// </summary>
        [Fact]
        public void IsValidFilePath_WithNull_ShouldReturnFalse()
        {
            // Act
            bool result = FilePickerValidator.IsValidFilePath(null);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsValidFilePath returns false for nonexistent file.
        /// </summary>
        [Fact]
        public void IsValidFilePath_WithNonexistentFile_ShouldReturnFalse()
        {
            // Act
            bool result = FilePickerValidator.IsValidFilePath("/nonexistent/file/path.txt");

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsValidFilePath returns true for existing file.
        /// </summary>
        [Fact]
        public void IsValidFilePath_WithExistingFile_ShouldReturnTrue()
        {
            // Arrange
            string tempFile = Path.GetTempFileName();

            try
            {
                // Act
                bool result = FilePickerValidator.IsValidFilePath(tempFile);

                // Assert
                Assert.True(result);
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        /// <summary>
        ///     Tests that IsValidDirectoryPath returns false for null path.
        /// </summary>
        [Fact]
        public void IsValidDirectoryPath_WithNull_ShouldReturnFalse()
        {
            // Act
            bool result = FilePickerValidator.IsValidDirectoryPath(null);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsValidDirectoryPath returns false for nonexistent directory.
        /// </summary>
        [Fact]
        public void IsValidDirectoryPath_WithNonexistentDirectory_ShouldReturnFalse()
        {
            // Act
            bool result = FilePickerValidator.IsValidDirectoryPath("/nonexistent/directory/path");

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsValidDirectoryPath returns true for existing directory.
        /// </summary>
        [Fact]
        public void IsValidDirectoryPath_WithExistingDirectory_ShouldReturnTrue()
        {
            // Arrange
            string tempDir = Path.GetTempPath();

            // Act
            bool result = FilePickerValidator.IsValidDirectoryPath(tempDir);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that IsFileExtensionAllowed returns true when no filters specified.
        /// </summary>
        [Fact]
        public void IsFileExtensionAllowed_WithNoFilters_ShouldReturnTrue()
        {
            // Arrange
            FilePickerOptions options = new FilePickerOptions("Test");

            // Act
            bool result = FilePickerValidator.IsFileExtensionAllowed("/path/file.txt", options);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that IsFileExtensionAllowed returns true for allowed extension.
        /// </summary>
        [Fact]
        public void IsFileExtensionAllowed_WithAllowedExtension_ShouldReturnTrue()
        {
            // Arrange
            FilePickerOptions options = new FilePickerOptions("Test");
            options.WithFilter(new FilePickerFilter("Text Files", "txt", "doc"));

            // Act
            bool result = FilePickerValidator.IsFileExtensionAllowed("/path/file.txt", options);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that IsFileExtensionAllowed returns false for disallowed extension.
        /// </summary>
        [Fact]
        public void IsFileExtensionAllowed_WithDisallowedExtension_ShouldReturnFalse()
        {
            // Arrange
            FilePickerOptions options = new FilePickerOptions("Test");
            options.WithFilter(new FilePickerFilter("Text Files", "txt", "doc"));

            // Act
            bool result = FilePickerValidator.IsFileExtensionAllowed("/path/file.pdf", options);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsFileExtensionAllowed is case-insensitive.
        /// </summary>
        [Fact]
        public void IsFileExtensionAllowed_IsCaseInsensitive_ShouldReturnTrue()
        {
            // Arrange
            FilePickerOptions options = new FilePickerOptions("Test");
            options.WithFilter(new FilePickerFilter("Text Files", "txt"));

            // Act
            bool result = FilePickerValidator.IsFileExtensionAllowed("/path/file.TXT", options);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that IsResultValid returns true for successful result.
        /// </summary>
        [Fact]
        public void IsResultValid_WithSuccessfulResult_ShouldReturnTrue()
        {
            // Arrange
            FilePickerOptions options = new FilePickerOptions("Test");
            string tempFile = Path.GetTempFileName();

            try
            {
                FilePickerResult result = new FilePickerResult(tempFile);

                // Act
                bool isValid = FilePickerValidator.IsResultValid(result, options);

                // Assert
                Assert.True(isValid);
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        /// <summary>
        ///     Tests that IsResultValid returns true for cancelled result.
        /// </summary>
        [Fact]
        public void IsResultValid_WithCancelledResult_ShouldReturnTrue()
        {
            // Arrange
            FilePickerOptions options = new FilePickerOptions("Test");
            FilePickerResult result = FilePickerResult.CreateCancelled();

            // Act
            bool isValid = FilePickerValidator.IsResultValid(result, options);

            // Assert
            Assert.True(isValid);
        }

        /// <summary>
        ///     Tests that IsResultValid returns false for result with multiple paths when not allowed.
        /// </summary>
        [Fact]
        public void IsResultValid_WithMultiplePathsNotAllowed_ShouldReturnFalse()
        {
            // Arrange
            FilePickerOptions options = new FilePickerOptions("Test");
            FilePickerResult result = new FilePickerResult(new List<string> { "/path/one.txt", "/path/two.txt" });

            // Act
            bool isValid = FilePickerValidator.IsResultValid(result, options);

            // Assert
            Assert.False(isValid);
        }
    }
}

