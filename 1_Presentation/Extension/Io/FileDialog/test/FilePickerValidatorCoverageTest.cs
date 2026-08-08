// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FilePickerValidatorCoverageTest.cs
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

using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Alis.Extension.Io.FileDialog.Test
{
    /// <summary>
    /// The file picker validator coverage test class
    /// </summary>
    public class FilePickerValidatorCoverageTest
    {
        /// <summary>
        /// Tests that is result valid with allow multiple and multiple paths should return true
        /// </summary>
        [Fact]
        public void IsResultValid_WithAllowMultipleAndMultiplePaths_ShouldReturnTrue()
        {
            FilePickerOptions options = new FilePickerOptions("Open Files", FileDialogType.OpenFile)
            {
                AllowMultiple = true
            };
            string tempFile1 = Path.GetTempFileName();
            string tempFile2 = Path.GetTempFileName();

            try
            {
                FilePickerResult result = new FilePickerResult(new List<string> { tempFile1, tempFile2 });

                bool isValid = FilePickerValidator.IsResultValid(result, options);

                Assert.True(isValid);
            }
            finally
            {
                File.Delete(tempFile1);
                File.Delete(tempFile2);
            }
        }

        /// <summary>
        /// Tests that is result valid with successful result and non existent path should return false
        /// </summary>
        [Fact]
        public void IsResultValid_WithSuccessfulResultAndNonExistentPath_ShouldReturnFalse()
        {
            FilePickerOptions options = new FilePickerOptions("Open");
            FilePickerResult result = new FilePickerResult("/nonexistent/path/xyz/file.txt");

            bool isValid = FilePickerValidator.IsResultValid(result, options);

            Assert.False(isValid);
        }

        /// <summary>
        /// Tests that is result valid with select folder and non existent path should return false
        /// </summary>
        [Fact]
        public void IsResultValid_WithSelectFolderAndNonExistentPath_ShouldReturnFalse()
        {
            FilePickerOptions options = new FilePickerOptions("Select", FileDialogType.SelectFolder);
            FilePickerResult result = new FilePickerResult("/nonexistent/folder/path");

            bool isValid = FilePickerValidator.IsResultValid(result, options);

            Assert.False(isValid);
        }

        /// <summary>
        /// Tests that is file extension allowed with path having no extension and no filters should return true
        /// </summary>
        [Fact]
        public void IsFileExtensionAllowed_WithPathHavingNoExtensionAndNoFilters_ShouldReturnTrue()
        {
            FilePickerOptions options = new FilePickerOptions("Test");

            bool result = FilePickerValidator.IsFileExtensionAllowed("/path/README", options);

            Assert.True(result);
        }

        /// <summary>
        /// Tests that is result valid with error result should return true
        /// </summary>
        [Fact]
        public void IsResultValid_WithErrorResult_ShouldReturnTrue()
        {
            FilePickerOptions options = new FilePickerOptions("Test");
            FilePickerResult result = FilePickerResult.CreateError("An error occurred");

            bool isValid = FilePickerValidator.IsResultValid(result, options);

            Assert.True(isValid);
        }

        /// <summary>
        /// Tests that validate options with select folder and valid path should not throw
        /// </summary>
        [Fact]
        public void ValidateOptions_WithSelectFolderAndValidPath_ShouldNotThrow()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDir);

            try
            {
                FilePickerOptions options = new FilePickerOptions("Select", FileDialogType.SelectFolder)
                {
                    DefaultPath = tempDir
                };

                FilePickerValidator.ValidateOptions(options);
            }
            finally
            {
                Directory.Delete(tempDir);
            }
        }

        /// <summary>
        /// Tests that is valid directory path with long path should not throw
        /// </summary>
        [Fact]
        public void IsValidDirectoryPath_WithLongPath_ShouldNotThrow()
        {
            string longPath = new string('a', 100) + "/dir";
            bool result = FilePickerValidator.IsValidDirectoryPath(longPath);

            Assert.False(result);
        }

        /// <summary>
        /// Tests that is valid file path with empty path should return false
        /// </summary>
        [Fact]
        public void IsValidFilePath_WithEmptyPath_ShouldReturnFalse()
        {
            bool result = FilePickerValidator.IsValidFilePath("");

            Assert.False(result);
        }

        /// <summary>
        /// Tests that is file extension allowed with options having null filters should return true
        /// </summary>
        [Fact]
        public void IsFileExtensionAllowed_WithOptionsHavingNullFilters_ShouldReturnTrue()
        {
            FilePickerOptions options = new FilePickerOptions("Test");

            bool result = FilePickerValidator.IsFileExtensionAllowed("file.txt", options);

            Assert.True(result);
        }
    }
}
