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

using System;
using System.IO;
using Xunit;

namespace Alis.Extension.Io.FileDialog.Test
{
    public class FilePickerPathConverterCoverageTest
    {
        [Fact]
        public void IsValidPath_WithNullCharAndMustExistTrue_ShouldReturnFalse()
        {
            bool result = FilePickerPathConverter.IsValidPath("/path/with\0null");

            Assert.False(result);
        }

        [Fact]
        public void NormalizePath_WithPathContainingNullChar_ShouldReturnNormalized()
        {
            string result = FilePickerPathConverter.NormalizePath("  /path/to/file.txt  ");

            Assert.Equal("/path/to/file.txt", result);
        }

        [Fact]
        public void ConvertPathSeparators_WithEmptyString_ShouldReturnEmpty()
        {
            string result = FilePickerPathConverter.ConvertPathSeparators("");

            Assert.Equal("", result);
        }

        [Fact]
        public void SplitMultiplePaths_WithSingleNewline_ShouldReturnEmpty()
        {
            string[] result = FilePickerPathConverter.SplitMultiplePaths("\n");

            Assert.Empty(result);
        }

        [Fact]
        public void SplitMultiplePaths_WithWindowsNewline_ShouldHandleCorrectly()
        {
            string paths = "/path/first.txt\r\n/path/second.txt";
            string[] result = FilePickerPathConverter.SplitMultiplePaths(paths);

            Assert.Equal(2, result.Length);
        }

        [Fact]
        public void NormalizePath_WithOnlyNewline_ShouldReturnNull()
        {
            string result = FilePickerPathConverter.NormalizePath("\n");

            Assert.Null(result);
        }

        [Fact]
        public void ConvertPathSeparators_WithForwardSlashesOnUnix_ShouldConvert()
        {
            string result = FilePickerPathConverter.ConvertPathSeparators("/path/to/file.txt");

            Assert.Equal("/path/to/file.txt", result);
        }

        [Fact]
        public void SplitMultiplePaths_WithCarriageReturnOnly_ShouldReturnEmpty()
        {
            string[] result = FilePickerPathConverter.SplitMultiplePaths("\r");

            Assert.Empty(result);
        }

        [Fact]
        public void IsValidPath_WithMustExistFalseAndValidPath_ShouldReturnTrue()
        {
            bool result = FilePickerPathConverter.IsValidPath("/valid/path.txt", false);

            Assert.True(result);
        }

        [Fact]
        public void GetDirectoryName_WithRelativePath_ShouldReturnDirectory()
        {
            string result = FilePickerPathConverter.GetDirectoryName("relative/path/file.txt");

            Assert.NotNull(result);
        }
    }
}
