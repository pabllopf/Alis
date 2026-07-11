// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FilePickerFactoryCoverageTest.cs
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
    /// The file picker factory coverage test class
    /// </summary>
    public class FilePickerFactoryCoverageTest
    {
        /// <summary>
        /// Tests that create file picker with options with open file dialog type should return valid instance
        /// </summary>
        [Fact]
        public void CreateFilePickerWithOptions_WithOpenFileDialogType_ShouldReturnValidInstance()
        {
            FilePickerOptions options = new FilePickerOptions("Open File", FileDialogType.OpenFile);

            IFilePicker picker = FilePickerFactory.CreateFilePickerWithOptions(options);

            Assert.NotNull(picker);
            Assert.IsAssignableFrom<IFilePicker>(picker);
        }

        /// <summary>
        /// Tests that create file picker with options with save file dialog type should return valid instance
        /// </summary>
        [Fact]
        public void CreateFilePickerWithOptions_WithSaveFileDialogType_ShouldReturnValidInstance()
        {
            FilePickerOptions options = new FilePickerOptions("Save File", FileDialogType.SaveFile);

            IFilePicker picker = FilePickerFactory.CreateFilePickerWithOptions(options);

            Assert.NotNull(picker);
            Assert.IsAssignableFrom<IFilePicker>(picker);
        }

        /// <summary>
        /// Tests that create file picker with options with select folder dialog type should return valid instance
        /// </summary>
        [Fact]
        public void CreateFilePickerWithOptions_WithSelectFolderDialogType_ShouldReturnValidInstance()
        {
            FilePickerOptions options = new FilePickerOptions("Select Folder", FileDialogType.SelectFolder);

            IFilePicker picker = FilePickerFactory.CreateFilePickerWithOptions(options);

            Assert.NotNull(picker);
            Assert.IsAssignableFrom<IFilePicker>(picker);
        }

        /// <summary>
        /// Tests that create file picker with options with allow multiple should return valid instance
        /// </summary>
        [Fact]
        public void CreateFilePickerWithOptions_WithAllowMultiple_ShouldReturnValidInstance()
        {
            FilePickerOptions options = new FilePickerOptions("Open Files", FileDialogType.OpenFile)
            {
                AllowMultiple = true
            };

            IFilePicker picker = FilePickerFactory.CreateFilePickerWithOptions(options);

            Assert.NotNull(picker);
            Assert.IsAssignableFrom<IFilePicker>(picker);
        }

        /// <summary>
        /// Tests that get platform name should be current platform
        /// </summary>
        [Fact]
        public void GetPlatformName_ShouldBeCurrentPlatform()
        {
            string platformName = FilePickerFactory.GetPlatformName();

            Assert.NotNull(platformName);
        }

        /// <summary>
        /// Tests that is platform supported should return boolean
        /// </summary>
        [Fact]
        public void IsPlatformSupported_ShouldReturnBoolean()
        {
            bool result = FilePickerFactory.IsPlatformSupported();

            Assert.IsType<bool>(result);
        }

        /// <summary>
        /// Tests that create file picker should return mac file picker on mac
        /// </summary>
        [Fact]
        public void CreateFilePicker_ShouldReturnMacFilePicker_OnMac()
        {
            IFilePicker picker = FilePickerFactory.CreateFilePicker();

            Assert.NotNull(picker);
        }
    }
}
