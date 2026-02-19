// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ZipEntryInfoTest.cs
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

namespace Alis.Core.Aspect.Memory.Test
{
    public class ZipEntryInfoTest
    {
        [Fact]
        public void FullName_GetSet_WorksCorrectly()
        {
            // Arrange
            var zipEntryInfo = new ZipEntryInfo();
            string expectedName = "path/to/file.txt";

            // Act
            zipEntryInfo.FullName = expectedName;
            var result = zipEntryInfo.FullName;

            // Assert
            Assert.Equal(expectedName, result);
        }

        [Fact]
        public void FullName_DefaultValue_IsEmptyString()
        {
            // Arrange & Act
            var zipEntryInfo = new ZipEntryInfo();

            // Assert
            Assert.Equal(string.Empty, zipEntryInfo.FullName);
        }

        [Fact]
        public void Length_GetSet_WorksCorrectly()
        {
            // Arrange
            var zipEntryInfo = new ZipEntryInfo();
            long expectedLength = 1024L;

            // Act
            zipEntryInfo.Length = expectedLength;
            var result = zipEntryInfo.Length;

            // Assert
            Assert.Equal(expectedLength, result);
        }

        [Fact]
        public void Length_WithLargeValue_WorksCorrectly()
        {
            // Arrange
            var zipEntryInfo = new ZipEntryInfo();
            long expectedLength = long.MaxValue;

            // Act
            zipEntryInfo.Length = expectedLength;
            var result = zipEntryInfo.Length;

            // Assert
            Assert.Equal(expectedLength, result);
        }

        [Fact]
        public void LastWriteTimeUtc_GetSet_WorksCorrectly()
        {
            // Arrange
            var zipEntryInfo = new ZipEntryInfo();
            var expectedDateTime = new DateTimeOffset(2023, 5, 15, 10, 30, 45, TimeSpan.Zero);

            // Act
            zipEntryInfo.LastWriteTimeUtc = expectedDateTime;
            var result = zipEntryInfo.LastWriteTimeUtc;

            // Assert
            Assert.Equal(expectedDateTime, result);
        }

        [Fact]
        public void MultipleProperties_SetAndRetrieve_AllValuesCorrect()
        {
            // Arrange
            var zipEntryInfo = new ZipEntryInfo();
            string expectedName = "folder/file.bin";
            long expectedLength = 5120L;
            var expectedDateTime = new DateTimeOffset(2024, 1, 20, 15, 45, 30, TimeSpan.Zero);

            // Act
            zipEntryInfo.FullName = expectedName;
            zipEntryInfo.Length = expectedLength;
            zipEntryInfo.LastWriteTimeUtc = expectedDateTime;

            // Assert
            Assert.Equal(expectedName, zipEntryInfo.FullName);
            Assert.Equal(expectedLength, zipEntryInfo.Length);
            Assert.Equal(expectedDateTime, zipEntryInfo.LastWriteTimeUtc);
        }
    }
}