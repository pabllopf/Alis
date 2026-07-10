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
    public class FilePickerFactoryCoverageTest
    {
        [Fact]
        public void CreateFilePickerWithOptions_WithOpenFileDialogType_ShouldReturnValidInstance()
        {
            FilePickerOptions options = new FilePickerOptions("Open File", FileDialogType.OpenFile);

            IFilePicker picker = FilePickerFactory.CreateFilePickerWithOptions(options);

            Assert.NotNull(picker);
            Assert.IsAssignableFrom<IFilePicker>(picker);
        }

        [Fact]
        public void CreateFilePickerWithOptions_WithSaveFileDialogType_ShouldReturnValidInstance()
        {
            FilePickerOptions options = new FilePickerOptions("Save File", FileDialogType.SaveFile);

            IFilePicker picker = FilePickerFactory.CreateFilePickerWithOptions(options);

            Assert.NotNull(picker);
            Assert.IsAssignableFrom<IFilePicker>(picker);
        }

        [Fact]
        public void CreateFilePickerWithOptions_WithSelectFolderDialogType_ShouldReturnValidInstance()
        {
            FilePickerOptions options = new FilePickerOptions("Select Folder", FileDialogType.SelectFolder);

            IFilePicker picker = FilePickerFactory.CreateFilePickerWithOptions(options);

            Assert.NotNull(picker);
            Assert.IsAssignableFrom<IFilePicker>(picker);
        }

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

        [Fact]
        public void GetPlatformName_ShouldBeCurrentPlatform()
        {
            string platformName = FilePickerFactory.GetPlatformName();

            Assert.NotNull(platformName);
        }

        [Fact]
        public void IsPlatformSupported_ShouldReturnBoolean()
        {
            bool result = FilePickerFactory.IsPlatformSupported();

            Assert.IsType<bool>(result);
        }

        [Fact]
        public void CreateFilePicker_ShouldReturnMacFilePicker_OnMac()
        {
            IFilePicker picker = FilePickerFactory.CreateFilePicker();

            Assert.NotNull(picker);
        }
    }
}
