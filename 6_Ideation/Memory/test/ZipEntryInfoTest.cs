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
using System.Linq;
using Xunit;

namespace Alis.Core.Aspect.Memory.Test
{
    /// <summary>
    /// The zip entry info test class
    /// </summary>
    public class ZipEntryInfoTest
    {
        /// <summary>
        /// Tests that full name get set works correctly
        /// </summary>
        [Fact]
        public void FullName_GetSet_WorksCorrectly()
        {
            // Arrange
            ZipEntryInfo zipEntryInfo = new ZipEntryInfo();
            string expectedName = "path/to/file.txt";

            // Act
            zipEntryInfo.FullName = expectedName;
            string result = zipEntryInfo.FullName;

            // Assert
            Assert.Equal(expectedName, result);
        }

        /// <summary>
        /// Tests that full name default value is empty string
        /// </summary>
        [Fact]
        public void FullName_DefaultValue_IsEmptyString()
        {
            // Arrange & Act
            ZipEntryInfo zipEntryInfo = new ZipEntryInfo();

            // Assert
            Assert.Equal(string.Empty, zipEntryInfo.FullName);
        }

        /// <summary>
        /// Tests that length get set works correctly
        /// </summary>
        [Fact]
        public void Length_GetSet_WorksCorrectly()
        {
            // Arrange
            ZipEntryInfo zipEntryInfo = new ZipEntryInfo();
            long expectedLength = 1024L;

            // Act
            zipEntryInfo.Length = expectedLength;
            long result = zipEntryInfo.Length;

            // Assert
            Assert.Equal(expectedLength, result);
        }

        /// <summary>
        /// Tests that length with large value works correctly
        /// </summary>
        [Fact]
        public void Length_WithLargeValue_WorksCorrectly()
        {
            // Arrange
            ZipEntryInfo zipEntryInfo = new ZipEntryInfo();
            long expectedLength = long.MaxValue;

            // Act
            zipEntryInfo.Length = expectedLength;
            long result = zipEntryInfo.Length;

            // Assert
            Assert.Equal(expectedLength, result);
        }

        /// <summary>
        /// Tests that last write time utc get set works correctly
        /// </summary>
        [Fact]
        public void LastWriteTimeUtc_GetSet_WorksCorrectly()
        {
            // Arrange
            ZipEntryInfo zipEntryInfo = new ZipEntryInfo();
            DateTimeOffset expectedDateTime = new DateTimeOffset(2023, 5, 15, 10, 30, 45, TimeSpan.Zero);

            // Act
            zipEntryInfo.LastWriteTimeUtc = expectedDateTime;
            DateTimeOffset result = zipEntryInfo.LastWriteTimeUtc;

            // Assert
            Assert.Equal(expectedDateTime, result);
        }

        /// <summary>
        /// Tests that multiple properties set and retrieve all values correct
        /// </summary>
        [Fact]
        public void MultipleProperties_SetAndRetrieve_AllValuesCorrect()
        {
            // Arrange
            ZipEntryInfo zipEntryInfo = new ZipEntryInfo();
            string expectedName = "folder/file.bin";
            long expectedLength = 5120L;
            DateTimeOffset expectedDateTime = new DateTimeOffset(2024, 1, 20, 15, 45, 30, TimeSpan.Zero);

            // Act
            zipEntryInfo.FullName = expectedName;
            zipEntryInfo.Length = expectedLength;
            zipEntryInfo.LastWriteTimeUtc = expectedDateTime;

            // Assert
            Assert.Equal(expectedName, zipEntryInfo.FullName);
            Assert.Equal(expectedLength, zipEntryInfo.Length);
            Assert.Equal(expectedDateTime, zipEntryInfo.LastWriteTimeUtc);
        }

        /// <summary>
        /// Tests that length can be zero
        /// </summary>
        [Fact]
        public void Length_CanBeZero()
        {
            // Arrange
            ZipEntryInfo zipEntryInfo = new ZipEntryInfo();

            // Act
            zipEntryInfo.Length = 0L;

            // Assert
            Assert.Equal(0L, zipEntryInfo.Length);
        }

        /// <summary>
        /// Tests that length can be very large
        /// </summary>
        [Fact]
        public void Length_CanBeVeryLarge()
        {
            // Arrange
            ZipEntryInfo zipEntryInfo = new ZipEntryInfo();
            long largeLength = long.MaxValue - 1;

            // Act
            zipEntryInfo.Length = largeLength;

            // Assert
            Assert.Equal(largeLength, zipEntryInfo.Length);
        }

        /// <summary>
        /// Tests that last write time utc can be set to past date
        /// </summary>
        [Fact]
        public void LastWriteTimeUtc_CanBeSetToPastDate()
        {
            // Arrange
            ZipEntryInfo zipEntryInfo = new ZipEntryInfo();
            DateTimeOffset pastDate = new DateTimeOffset(1990, 5, 15, 10, 30, 0, TimeSpan.Zero);

            // Act
            zipEntryInfo.LastWriteTimeUtc = pastDate;

            // Assert
            Assert.Equal(pastDate, zipEntryInfo.LastWriteTimeUtc);
        }

        /// <summary>
        /// Tests that last write time utc can be set to future date
        /// </summary>
        [Fact]
        public void LastWriteTimeUtc_CanBeSetToFutureDate()
        {
            // Arrange
            ZipEntryInfo zipEntryInfo = new ZipEntryInfo();
            DateTimeOffset futureDate = new DateTimeOffset(2030, 12, 31, 23, 59, 59, TimeSpan.Zero);

            // Act
            zipEntryInfo.LastWriteTimeUtc = futureDate;

            // Assert
            Assert.Equal(futureDate, zipEntryInfo.LastWriteTimeUtc);
        }

        /// <summary>
        /// Tests that full name with special characters can be set
        /// </summary>
        [Fact]
        public void FullName_WithSpecialCharacters_CanBeSet()
        {
            // Arrange
            ZipEntryInfo zipEntryInfo = new ZipEntryInfo();
            string specialName = "folder/special-file_v1.0.txt";

            // Act
            zipEntryInfo.FullName = specialName;

            // Assert
            Assert.Equal(specialName, zipEntryInfo.FullName);
        }

        /// <summary>
        /// Tests that full name with backslashes can be set
        /// </summary>
        [Fact]
        public void FullName_WithBackslashes_CanBeSet()
        {
            // Arrange
            ZipEntryInfo zipEntryInfo = new ZipEntryInfo();
            string nameWithBackslashes = "folder\\subfolder\\file.txt";

            // Act
            zipEntryInfo.FullName = nameWithBackslashes;

            // Assert
            Assert.Equal(nameWithBackslashes, zipEntryInfo.FullName);
        }

        /// <summary>
        /// Tests that full name with very long path can be set
        /// </summary>
        [Fact]
        public void FullName_WithVeryLongPath_CanBeSet()
        {
            // Arrange
            ZipEntryInfo zipEntryInfo = new ZipEntryInfo();
            string longPath = string.Join("/", Enumerable.Repeat("folder", 50)) + "/file.txt";

            // Act
            zipEntryInfo.FullName = longPath;

            // Assert
            Assert.Equal(longPath, zipEntryInfo.FullName);
        }

        /// <summary>
        /// Tests that all properties can be null or default
        /// </summary>
        [Fact]
        public void AllProperties_CanBeNullOrDefault()
        {
            // Arrange & Act
            ZipEntryInfo zipEntryInfo = new ZipEntryInfo();

            // Assert
            Assert.NotNull(zipEntryInfo.FullName);
            Assert.Equal(0L, zipEntryInfo.Length);
            Assert.Equal(default(DateTimeOffset), zipEntryInfo.LastWriteTimeUtc);
        }

        /// <summary>
        /// Tests that multiple instances can have different values
        /// </summary>
        [Fact]
        public void MultipleInstances_CanHaveDifferentValues()
        {
            // Arrange
            ZipEntryInfo info1 = new ZipEntryInfo
            {
                FullName = "file1.txt",
                Length = 100L,
                LastWriteTimeUtc = DateTimeOffset.UtcNow
            };

            ZipEntryInfo info2 = new ZipEntryInfo
            {
                FullName = "file2.txt",
                Length = 200L,
                LastWriteTimeUtc = DateTimeOffset.UtcNow.AddDays(-1)
            };

            // Assert
            Assert.NotEqual(info1.FullName, info2.FullName);
            Assert.NotEqual(info1.Length, info2.Length);
            Assert.NotEqual(info1.LastWriteTimeUtc, info2.LastWriteTimeUtc);
        }

        /// <summary>
        /// Tests that full name with unicode characters can be set
        /// </summary>
        [Fact]
        public void FullName_WithUnicodeCharacters_CanBeSet()
        {
            // Arrange
            ZipEntryInfo zipEntryInfo = new ZipEntryInfo();
            string unicodeName = "文件/archivo/файл.txt";

            // Act
            zipEntryInfo.FullName = unicodeName;

            // Assert
            Assert.Equal(unicodeName, zipEntryInfo.FullName);
        }
    }
}