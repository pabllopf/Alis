// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ZipCacheEntryTest.cs
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
using Xunit;

namespace Alis.Core.Aspect.Memory.Test
{
    /// <summary>
    /// The zip cache entry test class
    /// </summary>
    public class ZipCacheEntryTest
    {
        /// <summary>
        /// Tests that pack bytes get set works correctly
        /// </summary>
        [Fact]
        public void PackBytes_GetSet_WorksCorrectly()
        {
            // Arrange
            ZipCacheEntry cacheEntry = new ZipCacheEntry();
            byte[] expectedBytes = { 1, 2, 3, 4, 5 };

            // Act
            cacheEntry.PackBytes = expectedBytes;
            byte[] result = cacheEntry.PackBytes;

            // Assert
            Assert.Equal(expectedBytes, result);
        }

        /// <summary>
        /// Tests that pack bytes set to null works correctly
        /// </summary>
        [Fact]
        public void PackBytes_SetToNull_WorksCorrectly()
        {
            // Arrange
            ZipCacheEntry cacheEntry = new ZipCacheEntry();
            byte[] bytes = { 1, 2, 3 };
            cacheEntry.PackBytes = bytes;

            // Act
            cacheEntry.PackBytes = null;

            // Assert
            Assert.Null(cacheEntry.PackBytes);
        }

        /// <summary>
        /// Tests that entries by full name lower is initialized empty dictionary
        /// </summary>
        [Fact]
        public void EntriesByFullNameLower_IsInitialized_EmptyDictionary()
        {
            // Arrange & Act
            ZipCacheEntry cacheEntry = new ZipCacheEntry();

            // Assert
            Assert.NotNull(cacheEntry.EntriesByFullNameLower);
            Assert.IsType<Dictionary<string, ZipEntryInfo>>(cacheEntry.EntriesByFullNameLower);
            Assert.Empty(cacheEntry.EntriesByFullNameLower);
        }

        /// <summary>
        /// Tests that entries by full name lower can add entries
        /// </summary>
        [Fact]
        public void EntriesByFullNameLower_CanAddEntries()
        {
            // Arrange
            ZipCacheEntry cacheEntry = new ZipCacheEntry();
            ZipEntryInfo entryInfo = new ZipEntryInfo { FullName = "test.txt", Length = 100 };
            string key = "test.txt";

            // Act
            cacheEntry.EntriesByFullNameLower[key] = entryInfo;

            // Assert
            Assert.Single(cacheEntry.EntriesByFullNameLower);
            Assert.True(cacheEntry.EntriesByFullNameLower.TryGetValue(key, out ZipEntryInfo retrieved));
            Assert.Equal(entryInfo, retrieved);
        }

        /// <summary>
        /// Tests that entries by full name lower multiple entries all retrievable
        /// </summary>
        [Fact]
        public void EntriesByFullNameLower_MultipleEntries_AllRetrievable()
        {
            // Arrange
            ZipCacheEntry cacheEntry = new ZipCacheEntry();
            ZipEntryInfo entry1 = new ZipEntryInfo { FullName = "file1.txt", Length = 100 };
            ZipEntryInfo entry2 = new ZipEntryInfo { FullName = "file2.txt", Length = 200 };
            ZipEntryInfo entry3 = new ZipEntryInfo { FullName = "file3.txt", Length = 300 };

            // Act
            cacheEntry.EntriesByFullNameLower["file1.txt"] = entry1;
            cacheEntry.EntriesByFullNameLower["file2.txt"] = entry2;
            cacheEntry.EntriesByFullNameLower["file3.txt"] = entry3;

            // Assert
            Assert.Equal(3, cacheEntry.EntriesByFullNameLower.Count);
            Assert.Equal(entry1, cacheEntry.EntriesByFullNameLower["file1.txt"]);
            Assert.Equal(entry2, cacheEntry.EntriesByFullNameLower["file2.txt"]);
            Assert.Equal(entry3, cacheEntry.EntriesByFullNameLower["file3.txt"]);
        }

        /// <summary>
        /// Tests that entries by file name lower is initialized empty dictionary
        /// </summary>
        [Fact]
        public void EntriesByFileNameLower_IsInitialized_EmptyDictionary()
        {
            // Arrange & Act
            ZipCacheEntry cacheEntry = new ZipCacheEntry();

            // Assert
            Assert.NotNull(cacheEntry.EntriesByFileNameLower);
            Assert.IsType<Dictionary<string, List<ZipEntryInfo>>>(cacheEntry.EntriesByFileNameLower);
            Assert.Empty(cacheEntry.EntriesByFileNameLower);
        }

        /// <summary>
        /// Tests that entries by file name lower can add entries list
        /// </summary>
        [Fact]
        public void EntriesByFileNameLower_CanAddEntriesList()
        {
            // Arrange
            ZipCacheEntry cacheEntry = new ZipCacheEntry();
            List<ZipEntryInfo> entryList = new List<ZipEntryInfo>
            {
                new ZipEntryInfo { FullName = "folder1/test.txt" },
                new ZipEntryInfo { FullName = "folder2/test.txt" }
            };
            string key = "test.txt";

            // Act
            cacheEntry.EntriesByFileNameLower[key] = entryList;

            // Assert
            Assert.Single(cacheEntry.EntriesByFileNameLower);
            Assert.True(cacheEntry.EntriesByFileNameLower.TryGetValue(key, out List<ZipEntryInfo> retrieved));
            Assert.Equal(2, retrieved.Count);
            Assert.Equal(entryList, retrieved);
        }

        /// <summary>
        /// Tests that entries by file name lower multiple file names all retrievable
        /// </summary>
        [Fact]
        public void EntriesByFileNameLower_MultipleFileNames_AllRetrievable()
        {
            // Arrange
            ZipCacheEntry cacheEntry = new ZipCacheEntry();
            List<ZipEntryInfo> list1 = new List<ZipEntryInfo> { new ZipEntryInfo { FullName = "file.txt" } };
            List<ZipEntryInfo> list2 = new List<ZipEntryInfo> { new ZipEntryInfo { FullName = "file.bin" } };

            // Act
            cacheEntry.EntriesByFileNameLower["file.txt"] = list1;
            cacheEntry.EntriesByFileNameLower["file.bin"] = list2;

            // Assert
            Assert.Equal(2, cacheEntry.EntriesByFileNameLower.Count);
            Assert.Equal(list1, cacheEntry.EntriesByFileNameLower["file.txt"]);
            Assert.Equal(list2, cacheEntry.EntriesByFileNameLower["file.bin"]);
        }

        /// <summary>
        /// Tests that all properties set and retrieve work together
        /// </summary>
        [Fact]
        public void AllProperties_SetAndRetrieve_WorkTogether()
        {
            // Arrange
            ZipCacheEntry cacheEntry = new ZipCacheEntry();
            byte[] expectedBytes = { 80, 75, 3, 4 }; // ZIP signature
            ZipEntryInfo entry1 = new ZipEntryInfo { FullName = "test1.txt", Length = 1024 };
            ZipEntryInfo entry2 = new ZipEntryInfo { FullName = "test2.txt", Length = 2048 };
            List<ZipEntryInfo> list = new List<ZipEntryInfo> { entry1 };

            // Act
            cacheEntry.PackBytes = expectedBytes;
            cacheEntry.EntriesByFullNameLower["test1.txt"] = entry1;
            cacheEntry.EntriesByFullNameLower["test2.txt"] = entry2;
            cacheEntry.EntriesByFileNameLower["test.txt"] = list;

            // Assert
            Assert.Equal(expectedBytes, cacheEntry.PackBytes);
            Assert.Equal(2, cacheEntry.EntriesByFullNameLower.Count);
            Assert.Single(cacheEntry.EntriesByFileNameLower);
            Assert.Equal(entry1, cacheEntry.EntriesByFullNameLower["test1.txt"]);
        }

        /// <summary>
        /// Tests that entries by full name lower can update existing entry
        /// </summary>
        [Fact]
        public void EntriesByFullNameLower_CanUpdateExistingEntry()
        {
            // Arrange
            ZipCacheEntry cacheEntry = new ZipCacheEntry();
            ZipEntryInfo entry1 = new ZipEntryInfo { FullName = "file.txt", Length = 100 };
            ZipEntryInfo entry2 = new ZipEntryInfo { FullName = "file.txt", Length = 200 };
            cacheEntry.EntriesByFullNameLower["file.txt"] = entry1;

            // Act
            cacheEntry.EntriesByFullNameLower["file.txt"] = entry2;

            // Assert
            Assert.Single(cacheEntry.EntriesByFullNameLower);
            Assert.Equal(200, cacheEntry.EntriesByFullNameLower["file.txt"].Length);
        }

        /// <summary>
        /// Tests that entries by file name lower can add multiple entries same file
        /// </summary>
        [Fact]
        public void EntriesByFileNameLower_CanAddMultipleEntriesSameFile()
        {
            // Arrange
            ZipCacheEntry cacheEntry = new ZipCacheEntry();
            ZipEntryInfo entry1 = new ZipEntryInfo { FullName = "folder1/file.txt" };
            ZipEntryInfo entry2 = new ZipEntryInfo { FullName = "folder2/file.txt" };
            List<ZipEntryInfo> entryList = new List<ZipEntryInfo> { entry1, entry2 };

            // Act
            cacheEntry.EntriesByFileNameLower["file.txt"] = entryList;
            cacheEntry.EntriesByFileNameLower["file.txt"].Add(new ZipEntryInfo { FullName = "folder3/file.txt" });

            // Assert
            Assert.Equal(3, cacheEntry.EntriesByFileNameLower["file.txt"].Count);
        }

        /// <summary>
        /// Tests that entries by full name lower lookup is case sensitive
        /// </summary>
        [Fact]
        public void EntriesByFullNameLower_LookupIsCaseSensitive()
        {
            // Arrange
            ZipCacheEntry entry = new ZipCacheEntry();
            ZipEntryInfo info = new ZipEntryInfo {FullName = "Test.txt", Length = 100};
            entry.EntriesByFullNameLower["test.txt"] = info;

            // Act
            bool existsLower = entry.EntriesByFullNameLower.ContainsKey("test.txt");
            bool existsUpper = entry.EntriesByFullNameLower.ContainsKey("TEST.TXT");

            // Assert
            Assert.True(existsLower);
            Assert.False(existsUpper);
        }

        /// <summary>
        /// Tests that entries by file name lower can handle empty list
        /// </summary>
        [Fact]
        public void EntriesByFileNameLower_CanHandleEmptyList()
        {
            // Arrange
            ZipCacheEntry entry = new ZipCacheEntry();
            List<ZipEntryInfo> emptyList = new List<ZipEntryInfo>();

            // Act
            entry.EntriesByFileNameLower["empty.txt"] = emptyList;

            // Assert
            Assert.Single(entry.EntriesByFileNameLower);
            Assert.Empty(entry.EntriesByFileNameLower["empty.txt"]);
        }

        /// <summary>
        /// Tests that entries by full name lower can update existing entry value
        /// </summary>
        [Fact]
        public void EntriesByFullNameLower_CanUpdateExistingEntryValue()
        {
            // Arrange
            ZipCacheEntry entry = new ZipCacheEntry();
            ZipEntryInfo info1 = new ZipEntryInfo {FullName = "file.txt", Length = 100};
            ZipEntryInfo info2 = new ZipEntryInfo {FullName = "file.txt", Length = 200};
            entry.EntriesByFullNameLower["file.txt"] = info1;

            // Act
            entry.EntriesByFullNameLower["file.txt"] = info2;

            // Assert
            Assert.Single(entry.EntriesByFullNameLower);
            Assert.Equal(200, entry.EntriesByFullNameLower["file.txt"].Length);
        }

        /// <summary>
        /// Tests that entries by file name lower with nested paths works correctly
        /// </summary>
        [Fact]
        public void EntriesByFileNameLower_WithNestedPaths_WorksCorrectly()
        {
            // Arrange
            ZipCacheEntry entry = new ZipCacheEntry();
            ZipEntryInfo info1 = new ZipEntryInfo {FullName = "a/b/c/file.txt", Length = 100};
            ZipEntryInfo info2 = new ZipEntryInfo {FullName = "x/y/z/file.txt", Length = 200};
            
            List<ZipEntryInfo> list = new List<ZipEntryInfo> {info1, info2};

            // Act
            entry.EntriesByFileNameLower["file.txt"] = list;

            // Assert
            Assert.Single(entry.EntriesByFileNameLower);
            Assert.Equal(2, entry.EntriesByFileNameLower["file.txt"].Count);
            Assert.Contains(info1, entry.EntriesByFileNameLower["file.txt"]);
            Assert.Contains(info2, entry.EntriesByFileNameLower["file.txt"]);
        }

        /// <summary>
        /// Tests that pack bytes can store large arrays
        /// </summary>
        [Fact]
        public void PackBytes_CanStoreLargeArrays()
        {
            // Arrange
            ZipCacheEntry entry = new ZipCacheEntry();
            byte[] largeBytes = new byte[1024 * 1024]; // 1MB
            for (int i = 0; i < largeBytes.Length; i++)
            {
                largeBytes[i] = (byte)(i % 256);
            }

            // Act
            entry.PackBytes = largeBytes;

            // Assert
            Assert.NotNull(entry.PackBytes);
            Assert.Equal(largeBytes.Length, entry.PackBytes.Length);
            Assert.Equal(largeBytes[0], entry.PackBytes[0]);
            Assert.Equal(largeBytes[largeBytes.Length - 1], entry.PackBytes[largeBytes.Length - 1]);
        }

        /// <summary>
        /// Tests that entries by full name lower can remove entries
        /// </summary>
        [Fact]
        public void EntriesByFullNameLower_CanRemoveEntries()
        {
            // Arrange
            ZipCacheEntry entry = new ZipCacheEntry();
            ZipEntryInfo info = new ZipEntryInfo {FullName = "file.txt", Length = 100};
            entry.EntriesByFullNameLower["file.txt"] = info;

            // Act
            bool removed = entry.EntriesByFullNameLower.Remove("file.txt");

            // Assert
            Assert.True(removed);
            Assert.Empty(entry.EntriesByFullNameLower);
        }

        /// <summary>
        /// Tests that entries by file name lower can clear all entries
        /// </summary>
        [Fact]
        public void EntriesByFileNameLower_CanClearAllEntries()
        {
            // Arrange
            ZipCacheEntry entry = new ZipCacheEntry();
            entry.EntriesByFileNameLower["file1.txt"] = new List<ZipEntryInfo> { new ZipEntryInfo() };
            entry.EntriesByFileNameLower["file2.txt"] = new List<ZipEntryInfo> { new ZipEntryInfo() };

            // Act
            entry.EntriesByFileNameLower.Clear();

            // Assert
            Assert.Empty(entry.EntriesByFileNameLower);
        }

        /// <summary>
        /// Tests that zip cache entry with null pack bytes can be created
        /// </summary>
        [Fact]
        public void ZipCacheEntry_WithNullPackBytes_CanBeCreated()
        {
            // Arrange & Act
            ZipCacheEntry entry = new ZipCacheEntry();

            // Assert
            Assert.Null(entry.PackBytes);
            Assert.NotNull(entry.EntriesByFullNameLower);
            Assert.NotNull(entry.EntriesByFileNameLower);
        }
    }
}