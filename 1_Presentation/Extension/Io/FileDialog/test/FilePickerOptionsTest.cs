// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FilePickerOptionsTest.cs
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
    ///     Unit tests for FilePickerOptions class.
    /// </summary>
    public class FilePickerOptionsTest
    {
        /// <summary>
        ///     Tests that FilePickerOptions default constructor creates instance.
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldCreateInstanceWithDefaults()
        {
            // Act
            var options = new FilePickerOptions();

            // Assert
            Assert.NotNull(options);
            Assert.Equal("Select a file", options.Title);
            Assert.Null(options.DefaultPath);
            Assert.NotNull(options.Filters);
            Assert.Empty(options.Filters);
            Assert.False(options.AllowMultiple);
            Assert.False(options.AllowDirectories);
            Assert.Equal(FileDialogType.OpenFile, options.DialogType);
        }

        /// <summary>
        ///     Tests that FilePickerOptions constructor with parameters creates instance.
        /// </summary>
        [Fact]
        public void ConstructorWithParameters_ShouldCreateInstance()
        {
            // Act
            var options = new FilePickerOptions("Open File", FileDialogType.OpenFile);

            // Assert
            Assert.Equal("Open File", options.Title);
            Assert.Equal(FileDialogType.OpenFile, options.DialogType);
        }

        /// <summary>
        ///     Tests that FilePickerOptions constructor throws with null title.
        /// </summary>
        [Fact]
        public void ConstructorWithNullTitle_ShouldThrowArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FilePickerOptions(null, FileDialogType.OpenFile));
        }

        /// <summary>
        ///     Tests that FilePickerOptions constructor throws with empty title.
        /// </summary>
        [Fact]
        public void ConstructorWithEmptyTitle_ShouldThrowArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FilePickerOptions("", FileDialogType.OpenFile));
        }

        /// <summary>
        ///     Tests that WithFilter adds a filter to the options.
        /// </summary>
        [Fact]
        public void WithFilter_ShouldAddFilter()
        {
            // Arrange
            var options = new FilePickerOptions("Test");
            var filter = new FilePickerFilter("Text Files", "txt");

            // Act
            options.WithFilter(filter);

            // Assert
            Assert.Single(options.Filters);
            Assert.Equal(filter, options.Filters[0]);
        }

        /// <summary>
        ///     Tests that WithFilter returns the options for fluent API.
        /// </summary>
        [Fact]
        public void WithFilter_ShouldReturnOptions()
        {
            // Arrange
            var options = new FilePickerOptions("Test");
            var filter = new FilePickerFilter("Text Files", "txt");

            // Act
            var result = options.WithFilter(filter);

            // Assert
            Assert.Same(options, result);
        }

        /// <summary>
        ///     Tests that WithFilter throws with null filter.
        /// </summary>
        [Fact]
        public void WithFilter_WithNullFilter_ShouldThrowArgumentNullException()
        {
            // Arrange
            var options = new FilePickerOptions("Test");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => options.WithFilter(null));
        }

        /// <summary>
        ///     Tests that WithDefaultPath sets the default path.
        /// </summary>
        [Fact]
        public void WithDefaultPath_ShouldSetPath()
        {
            // Arrange
            var options = new FilePickerOptions("Test");
            string path = "/home/user";

            // Act
            options.WithDefaultPath(path);

            // Assert
            Assert.Equal(path, options.DefaultPath);
        }

        /// <summary>
        ///     Tests that WithDefaultPath returns options for fluent API.
        /// </summary>
        [Fact]
        public void WithDefaultPath_ShouldReturnOptions()
        {
            // Arrange
            var options = new FilePickerOptions("Test");

            // Act
            var result = options.WithDefaultPath("/home/user");

            // Assert
            Assert.Same(options, result);
        }

        /// <summary>
        ///     Tests that WithMultipleSelection enables multiple selection.
        /// </summary>
        [Fact]
        public void WithMultipleSelection_ShouldEnableMultipleSelection()
        {
            // Arrange
            var options = new FilePickerOptions("Test");

            // Act
            options.WithMultipleSelection();

            // Assert
            Assert.True(options.AllowMultiple);
        }

        /// <summary>
        ///     Tests that WithMultipleSelection returns options for fluent API.
        /// </summary>
        [Fact]
        public void WithMultipleSelection_ShouldReturnOptions()
        {
            // Arrange
            var options = new FilePickerOptions("Test");

            // Act
            var result = options.WithMultipleSelection();

            // Assert
            Assert.Same(options, result);
        }

        /// <summary>
        ///     Tests that IsDirectoryDialog returns true for SelectFolder dialog type.
        /// </summary>
        [Fact]
        public void IsDirectoryDialog_WithSelectFolderType_ShouldReturnTrue()
        {
            // Arrange
            var options = new FilePickerOptions("Select", FileDialogType.SelectFolder);

            // Act
            bool result = options.IsDirectoryDialog();

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that IsDirectoryDialog returns false for OpenFile dialog type.
        /// </summary>
        [Fact]
        public void IsDirectoryDialog_WithOpenFileType_ShouldReturnFalse()
        {
            // Arrange
            var options = new FilePickerOptions("Select", FileDialogType.OpenFile);

            // Act
            bool result = options.IsDirectoryDialog();

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests fluent API chaining.
        /// </summary>
        [Fact]
        public void FluentApi_ShouldChainMethodsCalls()
        {
            // Act
            var options = new FilePickerOptions("Test")
                .WithDefaultPath("/home/user")
                .WithFilter(new FilePickerFilter("Text Files", "txt"))
                .WithMultipleSelection();

            // Assert
            Assert.Equal("/home/user", options.DefaultPath);
            Assert.Single(options.Filters);
            Assert.True(options.AllowMultiple);
        }
    }
}

