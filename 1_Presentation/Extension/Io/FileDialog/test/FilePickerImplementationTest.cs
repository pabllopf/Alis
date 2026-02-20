// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FilePickerImplementationTest.cs
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
using System.Runtime.InteropServices;
using Xunit;

namespace Alis.Extension.Io.FileDialog.Test
{
    /// <summary>
    ///     Unit tests for FilePicker implementations (Windows, Mac, Linux).
    /// </summary>
    public class FilePickerImplementationTest
    {
        /// <summary>
        ///     Tests that WindowsFilePicker implements IFilePicker.
        /// </summary>
        [Fact]
        public void WindowsFilePicker_ShouldImplementIFilePicker()
        {
            // Act
            var picker = new WindowsFilePicker();

            // Assert
            Assert.IsAssignableFrom<IFilePicker>(picker);
        }

        /// <summary>
        ///     Tests that MacFilePicker implements IFilePicker.
        /// </summary>
        [Fact]
        public void MacFilePicker_ShouldImplementIFilePicker()
        {
            // Act
            var picker = new MacFilePicker();

            // Assert
            Assert.IsAssignableFrom<IFilePicker>(picker);
        }

        /// <summary>
        ///     Tests that LinuxFilePicker implements IFilePicker.
        /// </summary>
        [Fact]
        public void LinuxFilePicker_ShouldImplementIFilePicker()
        {
            // Act
            var picker = new LinuxFilePicker();

            // Assert
            Assert.IsAssignableFrom<IFilePicker>(picker);
        }

        /// <summary>
        ///     Tests that WindowsFilePicker.PickFile validates options.
        /// </summary>
        [Fact]
        public void WindowsFilePicker_PickFile_WithInvalidOptions_ShouldReturnError()
        {
            // Arrange
            var picker = new WindowsFilePicker();
            var options = new FilePickerOptions { Title = "" }; // Invalid: empty title

            // Act
            var result = picker.PickFile(options);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

        /// <summary>
        ///     Tests that MacFilePicker.PickFile validates options.
        /// </summary>
        [Fact]
        public void MacFilePicker_PickFile_WithInvalidOptions_ShouldReturnError()
        {
            // Arrange
            var picker = new MacFilePicker();
            var options = new FilePickerOptions { Title = "" }; // Invalid: empty title

            // Act
            var result = picker.PickFile(options);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

        /// <summary>
        ///     Tests that LinuxFilePicker.PickFile validates options.
        /// </summary>
        [Fact]
        public void LinuxFilePicker_PickFile_WithInvalidOptions_ShouldReturnError()
        {
            // Arrange
            var picker = new LinuxFilePicker();
            var options = new FilePickerOptions { Title = "" }; // Invalid: empty title

            // Act
            var result = picker.PickFile(options);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

        /// <summary>
        ///     Tests that WindowsFilePicker.PickFolder validates options.
        /// </summary>
        [Fact]
        public void WindowsFilePicker_PickFolder_WithInvalidOptions_ShouldReturnError()
        {
            // Arrange
            var picker = new WindowsFilePicker();
            var options = new FilePickerOptions { Title = "" }; // Invalid: empty title

            // Act
            var result = picker.PickFolder(options);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

        /// <summary>
        ///     Tests that MacFilePicker.PickFolder validates options.
        /// </summary>
        [Fact]
        public void MacFilePicker_PickFolder_WithInvalidOptions_ShouldReturnError()
        {
            // Arrange
            var picker = new MacFilePicker();
            var options = new FilePickerOptions { Title = "" }; // Invalid: empty title

            // Act
            var result = picker.PickFolder(options);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

        /// <summary>
        ///     Tests that LinuxFilePicker.PickFolder validates options.
        /// </summary>
        [Fact]
        public void LinuxFilePicker_PickFolder_WithInvalidOptions_ShouldReturnError()
        {
            // Arrange
            var picker = new LinuxFilePicker();
            var options = new FilePickerOptions { Title = "" }; // Invalid: empty title

            // Act
            var result = picker.PickFolder(options);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

        /// <summary>
        ///     Tests that WindowsFilePicker.PickFiles validates options.
        /// </summary>
        [Fact]
        public void WindowsFilePicker_PickFiles_WithInvalidOptions_ShouldReturnError()
        {
            // Arrange
            var picker = new WindowsFilePicker();
            var invalidOptions = new FilePickerOptions("Save", FileDialogType.SaveFile)
            {
                AllowMultiple = true // Invalid: SaveFile cannot allow multiple
            };

            // Act
            var result = picker.PickFiles(invalidOptions);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

        /// <summary>
        ///     Tests that MacFilePicker.PickFiles validates options.
        /// </summary>
        [Fact]
        public void MacFilePicker_PickFiles_WithInvalidOptions_ShouldReturnError()
        {
            // Arrange
            var picker = new MacFilePicker();
            var invalidOptions = new FilePickerOptions("Save", FileDialogType.SaveFile)
            {
                AllowMultiple = true // Invalid: SaveFile cannot allow multiple
            };

            // Act
            var result = picker.PickFiles(invalidOptions);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

        /// <summary>
        ///     Tests that LinuxFilePicker.PickFiles validates options.
        /// </summary>
        [Fact]
        public void LinuxFilePicker_PickFiles_WithInvalidOptions_ShouldReturnError()
        {
            // Arrange
            var picker = new LinuxFilePicker();
            var invalidOptions = new FilePickerOptions("Save", FileDialogType.SaveFile)
            {
                AllowMultiple = true // Invalid: SaveFile cannot allow multiple
            };

            // Act
            var result = picker.PickFiles(invalidOptions);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

        /// <summary>
        ///     Tests that all pickers return non-null FilePickerResult from PickFile.
        /// </summary>
        [Fact]
        public void AllPickers_PickFile_ShouldReturnNonNullResult()
        {
            // Arrange
            var options = new FilePickerOptions("Test");
            var pickers = new IFilePicker[] { new WindowsFilePicker(), new MacFilePicker(), new LinuxFilePicker() };

            // Act & Assert
            foreach (var picker in pickers)
            {
                var result = picker.PickFile(options);
                Assert.NotNull(result);
            }
        }

        /// <summary>
        ///     Tests that all pickers return non-null FilePickerResult from PickFiles.
        /// </summary>
        [Fact]
        public void AllPickers_PickFiles_ShouldReturnNonNullResult()
        {
            // Arrange
            var options = new FilePickerOptions("Test");
            var pickers = new IFilePicker[] { new WindowsFilePicker(), new MacFilePicker(), new LinuxFilePicker() };

            // Act & Assert
            foreach (var picker in pickers)
            {
                var result = picker.PickFiles(options);
                Assert.NotNull(result);
            }
        }

        /// <summary>
        ///     Tests that all pickers return non-null FilePickerResult from PickFolder.
        /// </summary>
        [Fact]
        public void AllPickers_PickFolder_ShouldReturnNonNullResult()
        {
            // Arrange
            var options = new FilePickerOptions("Test", FileDialogType.SelectFolder);
            var pickers = new IFilePicker[] { new WindowsFilePicker(), new MacFilePicker(), new LinuxFilePicker() };

            // Act & Assert
            foreach (var picker in pickers)
            {
                var result = picker.PickFolder(options);
                Assert.NotNull(result);
            }
        }
    }
}

