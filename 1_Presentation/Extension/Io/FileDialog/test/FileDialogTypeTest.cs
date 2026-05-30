// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FileDialogTypeTest.cs
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
using System.Linq;
using Xunit;

namespace Alis.Extension.Io.FileDialog.Test
{
    /// <summary>
    ///     Unit tests for FileDialogType enum.
    /// </summary>
    public class FileDialogTypeTest
    {
        /// <summary>
        ///     Tests that FileDialogType.OpenFile has value 0.
        /// </summary>
        [Fact]
        public void OpenFile_ShouldHaveValueZero()
        {
            Assert.Equal(0, (int)FileDialogType.OpenFile);
        }

        /// <summary>
        ///     Tests that FileDialogType.SaveFile has value 1.
        /// </summary>
        [Fact]
        public void SaveFile_ShouldHaveValueOne()
        {
            Assert.Equal(1, (int)FileDialogType.SaveFile);
        }

        /// <summary>
        ///     Tests that FileDialogType.SelectFolder has value 2.
        /// </summary>
        [Fact]
        public void SelectFolder_ShouldHaveValueTwo()
        {
            Assert.Equal(2, (int)FileDialogType.SelectFolder);
        }

        /// <summary>
        ///     Tests that FileDialogType has exactly 3 values.
        /// </summary>
        [Fact]
        public void FileDialogType_ShouldHaveThreeValues()
        {
            int count = Enum.GetValues(typeof(FileDialogType)).Cast<FileDialogType>().Count();

            Assert.Equal(3, count);
        }

        /// <summary>
        ///     Tests that all FileDialogType values are distinct.
        /// </summary>
        [Fact]
        public void FileDialogType_AllValues_ShouldBeDistinct()
        {
            FileDialogType[] values = Enum.GetValues(typeof(FileDialogType)).Cast<FileDialogType>().ToArray();

            Assert.Equal(3, values.Distinct().Count());
        }

        /// <summary>
        ///     Tests that FileDialogType can be cast from int.
        /// </summary>
        [Fact]
        public void FileDialogType_CastFromInt_ShouldWork()
        {
            FileDialogType open = (FileDialogType)0;
            FileDialogType save = (FileDialogType)1;
            FileDialogType folder = (FileDialogType)2;

            Assert.Equal(FileDialogType.OpenFile, open);
            Assert.Equal(FileDialogType.SaveFile, save);
            Assert.Equal(FileDialogType.SelectFolder, folder);
        }

        /// <summary>
        ///     Tests that FileDialogType.ToString returns the name.
        /// </summary>
        [Fact]
        public void FileDialogType_ToString_ShouldReturnName()
        {
            Assert.Equal("OpenFile", FileDialogType.OpenFile.ToString());
            Assert.Equal("SaveFile", FileDialogType.SaveFile.ToString());
            Assert.Equal("SelectFolder", FileDialogType.SelectFolder.ToString());
        }

        /// <summary>
        ///     Tests that FileDialogType.Parse works correctly.
        /// </summary>
        [Fact]
        public void FileDialogType_Parse_ShouldReturnCorrectValue()
        {
#if NET8_0_OR_GREATER
            FileDialogType parsed = Enum.Parse<FileDialogType>("OpenFile");
#else
            FileDialogType parsed = (FileDialogType)Enum.Parse(typeof(FileDialogType), "OpenFile");
#endif

            Assert.Equal(FileDialogType.OpenFile, parsed);
        }

        /// <summary>
        ///     Tests that FileDialogType.Parse is case-insensitive.
        /// </summary>
        [Fact]
        public void FileDialogType_Parse_ShouldBeCaseInsensitive()
        {
#if NET8_0_OR_GREATER
            FileDialogType parsed = Enum.Parse<FileDialogType>("openfile", ignoreCase: true);
#else
            FileDialogType parsed = (FileDialogType)Enum.Parse(typeof(FileDialogType), "openfile", ignoreCase: true);
#endif

            Assert.Equal(FileDialogType.OpenFile, parsed);
        }

        /// <summary>
        ///     Tests that FileDialogType.Parse throws for invalid value.
        /// </summary>
        [Fact]
        public void FileDialogType_Parse_WithInvalidValue_ShouldThrowArgumentException()
        {
#if NET8_0_OR_GREATER
            Assert.Throws<ArgumentException>(() => Enum.Parse<FileDialogType>("InvalidValue"));
#else
            Assert.Throws<ArgumentException>(() => (FileDialogType)Enum.Parse(typeof(FileDialogType), "InvalidValue"));
#endif
        }

        /// <summary>
        ///     Tests that FileDialogType default value is OpenFile (0).
        /// </summary>
        [Fact]
        public void FileDialogType_DefaultValue_ShouldBeOpenFile()
        {
            FileDialogType defaultType = default;

            Assert.Equal(FileDialogType.OpenFile, defaultType);
        }

        /// <summary>
        ///     Tests that FileDialogType values can be used in switch.
        /// </summary>
        [Fact]
        public void FileDialogType_SwitchExpression_ShouldHandleAllCases()
        {
            FileDialogType[] values = Enum.GetValues(typeof(FileDialogType)).Cast<FileDialogType>().ToArray();
            string[] results = values.Select(v => v switch
            {
                FileDialogType.OpenFile => "open",
                FileDialogType.SaveFile => "save",
                FileDialogType.SelectFolder => "folder",
                _ => throw new InvalidOperationException()
            }).ToArray();

            Assert.Equal(3, results.Length);
            Assert.Contains("open", results);
            Assert.Contains("save", results);
            Assert.Contains("folder", results);
        }
    }
}
