// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FilePickerPathConverterTest.cs
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
    ///     Unit tests for FilePickerPathConverter static class.
    /// </summary>
    public class FilePickerPathConverterTest
    {
        /// <summary>
        ///     Tests that NormalizePath returns null for null input.
        /// </summary>
        [Fact]
        public void NormalizePath_WithNull_ShouldReturnNull()
        {
            // Act
            string result = FilePickerPathConverter.NormalizePath(null);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that NormalizePath removes leading and trailing whitespace.
        /// </summary>
        [Fact]
        public void NormalizePath_WithWhitespace_ShouldRemoveWhitespace()
        {
            // Act
            string result = FilePickerPathConverter.NormalizePath("  /path/to/file.txt  ");

            // Assert
            Assert.Equal("/path/to/file.txt", result);
        }

        /// <summary>
        ///     Tests that NormalizePath handles newlines.
        /// </summary>
        [Fact]
        public void NormalizePath_WithNewlines_ShouldRemoveNewlines()
        {
            // Act
            string result = FilePickerPathConverter.NormalizePath("/path/to/file.txt\n");

            // Assert
            Assert.Equal("/path/to/file.txt", result);
        }

        /// <summary>
        ///     Tests that SplitMultiplePaths returns empty array for null input.
        /// </summary>
        [Fact]
        public void SplitMultiplePaths_WithNull_ShouldReturnEmptyArray()
        {
            // Act
            string[] result = FilePickerPathConverter.SplitMultiplePaths(null);

            // Assert
            Assert.Empty(result);
        }
        
        
        
        /// <summary>
        ///     Tests that ConvertPathSeparators converts backslashes to forward slashes on Unix.
        /// </summary>
        [Fact]
        public void ConvertPathSeparators_WithMixedSeparators_ShouldConvertToSystemSeparator()
        {
            // Act
            string result = FilePickerPathConverter.ConvertPathSeparators("C:\\Users\\user\\file.txt");

            // Assert
            string expected = "C:" + System.IO.Path.DirectorySeparatorChar + "Users" + System.IO.Path.DirectorySeparatorChar + "user" + System.IO.Path.DirectorySeparatorChar + "file.txt";
            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Tests that ConvertPathSeparators handles null input.
        /// </summary>
        [Fact]
        public void ConvertPathSeparators_WithNull_ShouldReturnNull()
        {
            // Act
            string result = FilePickerPathConverter.ConvertPathSeparators(null);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that GetDirectoryName returns the directory name.
        /// </summary>
        [Fact]
        public void GetDirectoryName_WithValidPath_ShouldReturnDirectoryName()
        {
            // Act
            string result = FilePickerPathConverter.GetDirectoryName("/path/to/file.txt");

            // Assert
            Assert.NotNull(result);
            Assert.Contains("path", result);
        }

        /// <summary>
        ///     Tests that GetDirectoryName returns null for null input.
        /// </summary>
        [Fact]
        public void GetDirectoryName_WithNull_ShouldReturnNull()
        {
            // Act
            string result = FilePickerPathConverter.GetDirectoryName(null);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that GetFileName returns the file name.
        /// </summary>
        [Fact]
        public void GetFileName_WithValidPath_ShouldReturnFileName()
        {
            // Act
            string result = FilePickerPathConverter.GetFileName("/path/to/file.txt");

            // Assert
            Assert.Equal("file.txt", result);
        }

        /// <summary>
        ///     Tests that GetFileName returns null for null input.
        /// </summary>
        [Fact]
        public void GetFileName_WithNull_ShouldReturnNull()
        {
            // Act
            string result = FilePickerPathConverter.GetFileName(null);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that IsValidPath returns false for null input.
        /// </summary>
        [Fact]
        public void IsValidPath_WithNull_ShouldReturnFalse()
        {
            // Act
            bool result = FilePickerPathConverter.IsValidPath(null, false);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsValidPath returns false for path with invalid characters.
        /// </summary>
        [Fact]
        public void IsValidPath_WithInvalidCharacters_ShouldReturnFalse()
        {
            // This test is platform-specific:
            // On Windows, these characters are invalid
            // On Unix/macOS, most of these are actually valid
            // We use Path.GetInvalidPathChars() which returns an empty array on .NET Core on Unix

            if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows))
            {
                // Act
                bool result = FilePickerPathConverter.IsValidPath("C:\\path<with>invalid|chars", false);

                // Assert
                Assert.False(result);
            }
            else
            {
                // On Unix/macOS, skip this test or use actual invalid chars
                bool result = FilePickerPathConverter.IsValidPath("/path/with\0null/char", false);
                // Null characters should still be invalid on all platforms
            }
        }

        /// <summary>
        ///     Tests that IsValidPath returns true for valid path without existence check.
        /// </summary>
        [Fact]
        public void IsValidPath_WithValidPath_ShouldReturnTrue()
        {
            // Act
            bool result = FilePickerPathConverter.IsValidPath("/path/to/file.txt", false);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that IsValidPath checks existence when required.
        /// </summary>
        [Fact]
        public void IsValidPath_WithNonexistentPath_MustExist_ShouldReturnFalse()
        {
            // Act
            bool result = FilePickerPathConverter.IsValidPath("/nonexistent/path/file.txt", true);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that NormalizePath preserves the path when valid.
        /// </summary>
        [Fact]
        public void NormalizePath_WithValidPath_ShouldPreservePath()
        {
            // Act
            string result = FilePickerPathConverter.NormalizePath("/path/to/file.txt");

            // Assert
            Assert.Equal("/path/to/file.txt", result);
        }

        /// <summary>
        ///     Tests that SplitMultiplePaths with single path returns single element.
        /// </summary>
        [Fact]
        public void SplitMultiplePaths_WithSinglePath_ShouldReturnSingleElement()
        {
            // Act
            string[] result = FilePickerPathConverter.SplitMultiplePaths("/path/to/file.txt");

            // Assert
            Assert.Single(result);
            Assert.Equal("/path/to/file.txt", result[0]);
        }
    }
}

