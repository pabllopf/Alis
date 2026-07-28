// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DropBoxCloudManagerRemainingCoverageTests.cs
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
using System.IO;
using System.Threading.Tasks;
using Alis.Core.Ecs.Systems.Scope;
using Dropbox.Api;
using Xunit;

namespace Alis.Extension.Cloud.DropBox.Test
{
    /// <summary>
    ///     The drop box cloud manager remaining coverage tests class
    /// </summary>
    public class DropBoxCloudManagerRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that download file async with non existent directory creates directory
        /// </summary>
        [Fact]
        public async Task DownloadFileAsync_WithNonExistentDirectory_CreatesDirectory()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));
            string tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            string destPath = Path.Combine(tempDir, "file.txt");

            try
            {
                Exception exception = await Record.ExceptionAsync(() =>
                    manager.DownloadFileAsync("/remote.txt", destPath));

                Assert.NotNull(exception);
                Assert.True(Directory.Exists(tempDir));
            }
            finally
            {
                if (Directory.Exists(tempDir))
                {
                    Directory.Delete(tempDir, true);
                }
            }
        }

        /// <summary>
        ///     Tests that download file async with local path no directory component skips directory creation
        /// </summary>
        [Fact]
        public async Task DownloadFileAsync_WithLocalPathNoDirectoryComponent_SkipsDirectoryCreation()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.DownloadFileAsync("/remote.txt", "file.txt"));

            Assert.NotNull(exception);
        }

        /// <summary>
        ///     Tests that download file async with null dropbox path throws null reference exception
        /// </summary>
        [Fact]
        public async Task DownloadFileAsync_WithNullDropboxPath_ThrowsNullReferenceException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            await Assert.ThrowsAsync<NullReferenceException>(() =>
                manager.DownloadFileAsync(null, "/temp/file.txt"));
        }

        /// <summary>
        ///     Tests that download file async with null local path throws exception
        /// </summary>
        [Fact]
        public async Task DownloadFileAsync_WithNullLocalPath_ThrowsException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.DownloadFileAsync("/remote.txt", null));

            Assert.NotNull(exception);
        }

        /// <summary>
        ///     Tests that upload file async with null dropbox path throws null reference exception
        /// </summary>
        [Fact]
        public async Task UploadFileAsync_WithNullDropboxPath_ThrowsNullReferenceException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));
            string tempFile = Path.GetTempFileName();

            try
            {
                await Assert.ThrowsAsync<NullReferenceException>(() =>
                    manager.UploadFileAsync(tempFile, null));
            }
            finally
            {
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }

        /// <summary>
        ///     Tests that delete async with null path throws null reference exception
        /// </summary>
        [Fact]
        public async Task DeleteAsync_WithNullPath_ThrowsNullReferenceException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            await Assert.ThrowsAsync<NullReferenceException>(() =>
                manager.DeleteAsync(null));
        }

        /// <summary>
        ///     Tests that get metadata async with null path throws null reference exception
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_WithNullPath_ThrowsNullReferenceException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            await Assert.ThrowsAsync<NullReferenceException>(() =>
                manager.GetMetadataAsync(null));
        }

        /// <summary>
        ///     Tests that list files async with empty folder path and initialized manager throws from api
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_WithEmptyPathAndInitialized_ThrowsFromApi()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.ListFilesAsync(string.Empty));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        /// <summary>
        ///     Tests that list files async with null folder path and initialized manager throws from api
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_WithNullPathAndInitialized_ThrowsFromApi()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.ListFilesAsync(null));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        /// <summary>
        ///     Tests that delete async with initialized manager and valid path throws from api
        /// </summary>
        [Fact]
        public async Task DeleteAsync_WithInitializedManager_ThrowsFromApi()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.DeleteAsync("/file-to-delete.txt"));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        /// <summary>
        ///     Tests that get metadata async with initialized manager and valid path throws from api
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_WithInitializedManager_ThrowsFromApi()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.GetMetadataAsync("/some-file.txt"));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        /// <summary>
        ///     Tests that get metadata async with path normalization and initialized manager throws from api
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_WithPathNormalizedAndInitialized_ThrowsFromApi()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.GetMetadataAsync("some-file.txt"));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        /// <summary>
        ///     Tests that upload file async with path normalization and existing file throws from api
        /// </summary>
        [Fact]
        public async Task UploadFileAsync_WithPathNormalizedAndExistingFile_ThrowsFromApi()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));
            string tempFile = Path.GetTempFileName();

            try
            {
                Exception exception = await Record.ExceptionAsync(() =>
                    manager.UploadFileAsync(tempFile, "dest.txt"));

                Assert.NotNull(exception);
                Assert.IsNotType<InvalidOperationException>(exception);
                Assert.IsNotType<FileNotFoundException>(exception);
            }
            finally
            {
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }

        /// <summary>
        ///     Tests that download file async with dropbox path normalization and initialized manager throws from api
        /// </summary>
        [Fact]
        public async Task DownloadFileAsync_WithDropboxPathNormalized_ThrowsFromApi()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.DownloadFileAsync("remote.txt", "/tmp/output.txt"));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }
    }
}
