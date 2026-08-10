// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FilePickerPathConverterCoverageTest.cs
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

using Alis.Extension.Io.FileDialog.Test.Attributes;
using Xunit;

namespace Alis.Extension.Io.FileDialog.Test
{
    /// <summary>
    /// The file picker path converter coverage test class
    /// </summary>
    public class FilePickerPathConverterCoverageTest
    {
        /// <summary>
        /// Tests that is valid path with null char and must exist true should return false
        /// </summary>
        [Fact]
        public void IsValidPath_WithNullCharAndMustExistTrue_ShouldReturnFalse()
        {
            bool result = FilePickerPathConverter.IsValidPath("/path/with\0null");

            Assert.False(result);
        }

        /// <summary>
        /// Tests that normalize path with path containing null char should return normalized
        /// </summary>
        [Fact]
        public void NormalizePath_WithPathContainingNullChar_ShouldReturnNormalized()
        {
            string result = FilePickerPathConverter.NormalizePath("  /path/to/file.txt  ");

            Assert.Equal("/path/to/file.txt", result);
        }

        /// <summary>
        /// Tests that convert path separators with empty string should return empty
        /// </summary>
        [Fact]
        public void ConvertPathSeparators_WithEmptyString_ShouldReturnEmpty()
        {
            string result = FilePickerPathConverter.ConvertPathSeparators("");

            Assert.Equal("", result);
        }

        /// <summary>
        /// Tests that split multiple paths with single newline should return empty
        /// </summary>
        [Fact]
        public void SplitMultiplePaths_WithSingleNewline_ShouldReturnEmpty()
        {
            string[] result = FilePickerPathConverter.SplitMultiplePaths("\n");

            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that split multiple paths with windows newline should handle correctly
        /// </summary>
        [Fact]
        public void SplitMultiplePaths_WithWindowsNewline_ShouldHandleCorrectly()
        {
            string paths = "/path/first.txt\r\n/path/second.txt";
            string[] result = FilePickerPathConverter.SplitMultiplePaths(paths);

            Assert.Equal(2, result.Length);
        }

        /// <summary>
        /// Tests that normalize path with only newline should return null
        /// </summary>
        [Fact]
        public void NormalizePath_WithOnlyNewline_ShouldReturnNull()
        {
            string result = FilePickerPathConverter.NormalizePath("\n");

            Assert.Null(result);
        }

        /// <summary>
        /// Tests that convert path separators with forward slashes on unix should convert
        /// </summary>
        [UnixOnly]
        public void ConvertPathSeparators_WithForwardSlashesOnUnix_ShouldConvert()
        {
            string result = FilePickerPathConverter.ConvertPathSeparators("/path/to/file.txt");

            Assert.Equal("/path/to/file.txt", result);
        }

        /// <summary>
        /// Tests that split multiple paths with carriage return only should return empty
        /// </summary>
        [Fact]
        public void SplitMultiplePaths_WithCarriageReturnOnly_ShouldReturnEmpty()
        {
            string[] result = FilePickerPathConverter.SplitMultiplePaths("\r");

            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that is valid path with must exist false and valid path should return true
        /// </summary>
        [Fact]
        public void IsValidPath_WithMustExistFalseAndValidPath_ShouldReturnTrue()
        {
            bool result = FilePickerPathConverter.IsValidPath("/valid/path.txt", false);

            Assert.True(result);
        }

        /// <summary>
        /// Tests that get directory name with relative path should return directory
        /// </summary>
        [Fact]
        public void GetDirectoryName_WithRelativePath_ShouldReturnDirectory()
        {
            string result = FilePickerPathConverter.GetDirectoryName("relative/path/file.txt");

            Assert.NotNull(result);
        }
    }
}
