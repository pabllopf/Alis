// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FilePickerFactoryTest.cs
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
    ///     Unit tests for FilePickerFactory class.
    /// </summary>
    public class FilePickerFactoryTest
    {
        /// <summary>
        ///     Tests that CreateFilePicker returns a valid IFilePicker instance.
        /// </summary>
        [Fact]
        public void CreateFilePicker_ShouldReturnValidInstance()
        {
            IFilePicker picker = FilePickerFactory.CreateFilePicker();

            Assert.NotNull(picker);
            Assert.IsAssignableFrom<IFilePicker>(picker);
        }

        /// <summary>
        ///     Tests that CreateFilePicker returns the correct implementation for Windows.
        /// </summary>
        [Fact]
        public void CreateFilePicker_OnWindows_ShouldReturnWindowsFilePicker()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                IFilePicker picker = FilePickerFactory.CreateFilePicker();

                Assert.IsType<WindowsFilePicker>(picker);
            }
        }

        /// <summary>
        ///     Tests that CreateFilePicker returns the correct implementation for macOS.
        /// </summary>
        [Fact]
        public void CreateFilePicker_OnMac_ShouldReturnMacFilePicker()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                IFilePicker picker = FilePickerFactory.CreateFilePicker();

                Assert.IsType<MacFilePicker>(picker);
            }
        }

        /// <summary>
        ///     Tests that CreateFilePicker returns the correct implementation for Linux.
        /// </summary>
        [Fact]
        public void CreateFilePicker_OnLinux_ShouldReturnLinuxFilePicker()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                IFilePicker picker = FilePickerFactory.CreateFilePicker();

                Assert.IsType<LinuxFilePicker>(picker);
            }
        }

        /// <summary>
        ///     Tests that CreateFilePickerWithOptions validates options before creating.
        /// </summary>
        [Fact]
        public void CreateFilePickerWithOptions_WithNullOptions_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => FilePickerFactory.CreateFilePickerWithOptions(null));
        }

        /// <summary>
        ///     Tests that CreateFilePickerWithOptions validates empty title.
        /// </summary>
        [Fact]
        public void CreateFilePickerWithOptions_WithEmptyTitle_ShouldThrowArgumentException()
        {
            FilePickerOptions options = new FilePickerOptions {Title = ""};

            Assert.Throws<ArgumentException>(() => FilePickerFactory.CreateFilePickerWithOptions(options));
        }

        /// <summary>
        ///     Tests that CreateFilePickerWithOptions returns valid instance.
        /// </summary>
        [Fact]
        public void CreateFilePickerWithOptions_WithValidOptions_ShouldReturnValidInstance()
        {
            FilePickerOptions options = new FilePickerOptions("Test Title");

            IFilePicker picker = FilePickerFactory.CreateFilePickerWithOptions(options);

            Assert.NotNull(picker);
            Assert.IsAssignableFrom<IFilePicker>(picker);
        }

        /// <summary>
        ///     Tests that GetPlatformName returns a non-empty string.
        /// </summary>
        [Fact]
        public void GetPlatformName_ShouldReturnNonEmptyString()
        {
            string platformName = FilePickerFactory.GetPlatformName();

            Assert.NotNull(platformName);
            Assert.NotEmpty(platformName);
            Assert.True(platformName is "Windows" or "macOS" or "Linux" or "Unknown");
        }

        /// <summary>
        ///     Tests that IsPlatformSupported returns true for known platforms.
        /// </summary>
        [Fact]
        public void IsPlatformSupported_ShouldReturnTrueForKnownPlatforms()
        {
            bool isSupported = FilePickerFactory.IsPlatformSupported();

            Assert.True(isSupported);
        }

        /// <summary>
        ///     Tests that GetPlatformName matches the current platform.
        /// </summary>
        [Fact]
        public void GetPlatformName_ShouldMatchCurrentPlatform()
        {
            string platformName = FilePickerFactory.GetPlatformName();
            string expectedPlatform = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "Windows"
                : RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? "macOS"
                : RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? "Linux"
                : "Unknown";

            Assert.Equal(expectedPlatform, platformName);
        }
    }
}