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

using System.IO;
using System.Runtime.InteropServices;
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
            string result = FilePickerPathConverter.NormalizePath(null);

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that NormalizePath removes leading and trailing whitespace.
        /// </summary>
        [Fact]
        public void NormalizePath_WithWhitespace_ShouldRemoveWhitespace()
        {
            string result = FilePickerPathConverter.NormalizePath("  /path/to/file.txt  ");

            Assert.Equal("/path/to/file.txt", result);
        }

        /// <summary>
        ///     Tests that NormalizePath handles newlines.
        /// </summary>
        [Fact]
        public void NormalizePath_WithNewlines_ShouldRemoveNewlines()
        {
            string result = FilePickerPathConverter.NormalizePath("/path/to/file.txt\n");

            Assert.Equal("/path/to/file.txt", result);
        }

        /// <summary>
        ///     Tests that SplitMultiplePaths returns empty array for null input.
        /// </summary>
        [Fact]
        public void SplitMultiplePaths_WithNull_ShouldReturnEmptyArray()
        {
            string[] result = FilePickerPathConverter.SplitMultiplePaths(null);

            Assert.Empty(result);
        }


        /// <summary>
        ///     Tests that ConvertPathSeparators converts backslashes to forward slashes on Unix.
        /// </summary>
        [Fact]
        public void ConvertPathSeparators_WithMixedSeparators_ShouldConvertToSystemSeparator()
        {
            string result = FilePickerPathConverter.ConvertPathSeparators("C:\\Users\\user\\file.txt");

            string expected = "C:" + Path.DirectorySeparatorChar + "Users" + Path.DirectorySeparatorChar + "user" + Path.DirectorySeparatorChar + "file.txt";
            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Tests that ConvertPathSeparators handles null input.
        /// </summary>
        [Fact]
        public void ConvertPathSeparators_WithNull_ShouldReturnNull()
        {
            string result = FilePickerPathConverter.ConvertPathSeparators(null);

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that GetDirectoryName returns the directory name.
        /// </summary>
        [Fact]
        public void GetDirectoryName_WithValidPath_ShouldReturnDirectoryName()
        {
            string result = FilePickerPathConverter.GetDirectoryName("/path/to/file.txt");

            Assert.NotNull(result);
            Assert.Contains("path", result);
        }

        /// <summary>
        ///     Tests that GetDirectoryName returns null for null input.
        /// </summary>
        [Fact]
        public void GetDirectoryName_WithNull_ShouldReturnNull()
        {
            string result = FilePickerPathConverter.GetDirectoryName(null);

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that GetFileName returns the file name.
        /// </summary>
        [Fact]
        public void GetFileName_WithValidPath_ShouldReturnFileName()
        {
            string result = FilePickerPathConverter.GetFileName("/path/to/file.txt");

            Assert.Equal("file.txt", result);
        }

        /// <summary>
        ///     Tests that GetFileName returns null for null input.
        /// </summary>
        [Fact]
        public void GetFileName_WithNull_ShouldReturnNull()
        {
            string result = FilePickerPathConverter.GetFileName(null);

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that IsValidPath returns false for null input.
        /// </summary>
        [Fact]
        public void IsValidPath_WithNull_ShouldReturnFalse()
        {
            bool result = FilePickerPathConverter.IsValidPath(null, false);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsValidPath returns false for path with invalid characters.
        /// </summary>
        [Fact]
        public void IsValidPath_WithInvalidCharacters_ShouldReturnFalse()
        {
            // We use Path.GetInvalidPathChars() which returns an empty array on .NET Core on Unix

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                bool result = FilePickerPathConverter.IsValidPath("C:\\path<with>invalid|chars", false);

                Assert.False(result);
            }
            else
            {
                bool result = FilePickerPathConverter.IsValidPath("/path/with\0null/char", false);
            }
        }

        /// <summary>
        ///     Tests that IsValidPath returns true for valid path without existence check.
        /// </summary>
        [Fact]
        public void IsValidPath_WithValidPath_ShouldReturnTrue()
        {
            bool result = FilePickerPathConverter.IsValidPath("/path/to/file.txt", false);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that IsValidPath checks existence when required.
        /// </summary>
        [Fact]
        public void IsValidPath_WithNonexistentPath_MustExist_ShouldReturnFalse()
        {
            bool result = FilePickerPathConverter.IsValidPath("/nonexistent/path/file.txt");

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that NormalizePath preserves the path when valid.
        /// </summary>
        [Fact]
        public void NormalizePath_WithValidPath_ShouldPreservePath()
        {
            string result = FilePickerPathConverter.NormalizePath("/path/to/file.txt");

            Assert.Equal("/path/to/file.txt", result);
        }

        /// <summary>
        ///     Tests that SplitMultiplePaths with single path returns single element.
        /// </summary>
        [Fact]
        public void SplitMultiplePaths_WithSinglePath_ShouldReturnSingleElement()
        {
            string[] result = FilePickerPathConverter.SplitMultiplePaths("/path/to/file.txt");

            Assert.Single(result);
            Assert.Equal("/path/to/file.txt", result[0]);
        }

        /// <summary>
        ///     Tests that NormalizePath returns null for whitespace-only input.
        /// </summary>
        [Fact]
        public void NormalizePath_WithOnlyWhitespace_ShouldReturnNull()
        {
            string result = FilePickerPathConverter.NormalizePath("   ");

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that SplitMultiplePaths handles multiple paths separated by newline.
        /// </summary>
        [Fact]
        public void SplitMultiplePaths_WithMultiplePaths_ShouldReturnMultipleElements()
        {
            string paths = "/path/to/first.txt" + System.Environment.NewLine + "/path/to/second.txt";
            string[] result = FilePickerPathConverter.SplitMultiplePaths(paths);

            Assert.Equal(2, result.Length);
            Assert.Equal("/path/to/first.txt", result[0]);
            Assert.Equal("/path/to/second.txt", result[1]);
        }

        /// <summary>
        ///     Tests that SplitMultiplePaths filters empty entries.
        /// </summary>
        [Fact]
        public void SplitMultiplePaths_WithMixedContent_ShouldFilterEmpty()
        {
            string paths = "/path/to/first.txt" + System.Environment.NewLine + System.Environment.NewLine + "/path/to/second.txt";
            string[] result = FilePickerPathConverter.SplitMultiplePaths(paths);

            Assert.Equal(2, result.Length);
        }

        /// <summary>
        ///     Tests that ConvertPathSeparators preserves whitespace-only input.
        /// </summary>
        [Fact]
        public void ConvertPathSeparators_WithWhitespace_ShouldReturnOriginal()
        {
            string result = FilePickerPathConverter.ConvertPathSeparators("   ");

            Assert.Equal("   ", result);
        }

        /// <summary>
        ///     Tests that GetDirectoryName returns null for whitespace input.
        /// </summary>
        [Fact]
        public void GetDirectoryName_WithWhitespace_ShouldReturnNull()
        {
            string result = FilePickerPathConverter.GetDirectoryName("   ");

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that GetFileName returns null for whitespace input.
        /// </summary>
        [Fact]
        public void GetFileName_WithWhitespace_ShouldReturnNull()
        {
            string result = FilePickerPathConverter.GetFileName("   ");

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that IsValidPath returns false for whitespace input when not checking existence.
        /// </summary>
        [Fact]
        public void IsValidPath_WithOnlyWhitespace_NotMustExist_ShouldReturnFalse()
        {
            bool result = FilePickerPathConverter.IsValidPath("   ", false);

            Assert.False(result);
        }
    }
}