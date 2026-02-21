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
    public class ZipCacheEntryTest
    {
        [Fact]
        public void PackBytes_GetSet_WorksCorrectly()
        {
            // Arrange
            var cacheEntry = new ZipCacheEntry();
            byte[] expectedBytes = { 1, 2, 3, 4, 5 };

            // Act
            cacheEntry.PackBytes = expectedBytes;
            var result = cacheEntry.PackBytes;

            // Assert
            Assert.Equal(expectedBytes, result);
        }

        [Fact]
        public void PackBytes_SetToNull_WorksCorrectly()
        {
            // Arrange
            var cacheEntry = new ZipCacheEntry();
            byte[] bytes = { 1, 2, 3 };
            cacheEntry.PackBytes = bytes;

            // Act
            cacheEntry.PackBytes = null;

            // Assert
            Assert.Null(cacheEntry.PackBytes);
        }

        [Fact]
        public void EntriesByFullNameLower_IsInitialized_EmptyDictionary()
        {
            // Arrange & Act
            var cacheEntry = new ZipCacheEntry();

            // Assert
            Assert.NotNull(cacheEntry.EntriesByFullNameLower);
            Assert.IsType<Dictionary<string, ZipEntryInfo>>(cacheEntry.EntriesByFullNameLower);
            Assert.Empty(cacheEntry.EntriesByFullNameLower);
        }

        [Fact]
        public void EntriesByFullNameLower_CanAddEntries()
        {
            // Arrange
            var cacheEntry = new ZipCacheEntry();
            var entryInfo = new ZipEntryInfo { FullName = "test.txt", Length = 100 };
            string key = "test.txt";

            // Act
            cacheEntry.EntriesByFullNameLower[key] = entryInfo;

            // Assert
            Assert.Single(cacheEntry.EntriesByFullNameLower);
            Assert.True(cacheEntry.EntriesByFullNameLower.TryGetValue(key, out var retrieved));
            Assert.Equal(entryInfo, retrieved);
        }

        [Fact]
        public void EntriesByFullNameLower_MultipleEntries_AllRetrievable()
        {
            // Arrange
            var cacheEntry = new ZipCacheEntry();
            var entry1 = new ZipEntryInfo { FullName = "file1.txt", Length = 100 };
            var entry2 = new ZipEntryInfo { FullName = "file2.txt", Length = 200 };
            var entry3 = new ZipEntryInfo { FullName = "file3.txt", Length = 300 };

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

        [Fact]
        public void EntriesByFileNameLower_IsInitialized_EmptyDictionary()
        {
            // Arrange & Act
            var cacheEntry = new ZipCacheEntry();

            // Assert
            Assert.NotNull(cacheEntry.EntriesByFileNameLower);
            Assert.IsType<Dictionary<string, List<ZipEntryInfo>>>(cacheEntry.EntriesByFileNameLower);
            Assert.Empty(cacheEntry.EntriesByFileNameLower);
        }

        [Fact]
        public void EntriesByFileNameLower_CanAddEntriesList()
        {
            // Arrange
            var cacheEntry = new ZipCacheEntry();
            var entryList = new List<ZipEntryInfo>
            {
                new ZipEntryInfo { FullName = "folder1/test.txt" },
                new ZipEntryInfo { FullName = "folder2/test.txt" }
            };
            string key = "test.txt";

            // Act
            cacheEntry.EntriesByFileNameLower[key] = entryList;

            // Assert
            Assert.Single(cacheEntry.EntriesByFileNameLower);
            Assert.True(cacheEntry.EntriesByFileNameLower.TryGetValue(key, out var retrieved));
            Assert.Equal(2, retrieved.Count);
            Assert.Equal(entryList, retrieved);
        }

        [Fact]
        public void EntriesByFileNameLower_MultipleFileNames_AllRetrievable()
        {
            // Arrange
            var cacheEntry = new ZipCacheEntry();
            var list1 = new List<ZipEntryInfo> { new ZipEntryInfo { FullName = "file.txt" } };
            var list2 = new List<ZipEntryInfo> { new ZipEntryInfo { FullName = "file.bin" } };

            // Act
            cacheEntry.EntriesByFileNameLower["file.txt"] = list1;
            cacheEntry.EntriesByFileNameLower["file.bin"] = list2;

            // Assert
            Assert.Equal(2, cacheEntry.EntriesByFileNameLower.Count);
            Assert.Equal(list1, cacheEntry.EntriesByFileNameLower["file.txt"]);
            Assert.Equal(list2, cacheEntry.EntriesByFileNameLower["file.bin"]);
        }

        [Fact]
        public void AllProperties_SetAndRetrieve_WorkTogether()
        {
            // Arrange
            var cacheEntry = new ZipCacheEntry();
            byte[] expectedBytes = { 80, 75, 3, 4 }; // ZIP signature
            var entry1 = new ZipEntryInfo { FullName = "test1.txt", Length = 1024 };
            var entry2 = new ZipEntryInfo { FullName = "test2.txt", Length = 2048 };
            var list = new List<ZipEntryInfo> { entry1 };

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

        [Fact]
        public void EntriesByFullNameLower_CanUpdateExistingEntry()
        {
            // Arrange
            var cacheEntry = new ZipCacheEntry();
            var entry1 = new ZipEntryInfo { FullName = "file.txt", Length = 100 };
            var entry2 = new ZipEntryInfo { FullName = "file.txt", Length = 200 };
            cacheEntry.EntriesByFullNameLower["file.txt"] = entry1;

            // Act
            cacheEntry.EntriesByFullNameLower["file.txt"] = entry2;

            // Assert
            Assert.Single(cacheEntry.EntriesByFullNameLower);
            Assert.Equal(200, cacheEntry.EntriesByFullNameLower["file.txt"].Length);
        }

        [Fact]
        public void EntriesByFileNameLower_CanAddMultipleEntriesSameFile()
        {
            // Arrange
            var cacheEntry = new ZipCacheEntry();
            var entry1 = new ZipEntryInfo { FullName = "folder1/file.txt" };
            var entry2 = new ZipEntryInfo { FullName = "folder2/file.txt" };
            var entryList = new List<ZipEntryInfo> { entry1, entry2 };

            // Act
            cacheEntry.EntriesByFileNameLower["file.txt"] = entryList;
            cacheEntry.EntriesByFileNameLower["file.txt"].Add(new ZipEntryInfo { FullName = "folder3/file.txt" });

            // Assert
            Assert.Equal(3, cacheEntry.EntriesByFileNameLower["file.txt"].Count);
        }
    }
}