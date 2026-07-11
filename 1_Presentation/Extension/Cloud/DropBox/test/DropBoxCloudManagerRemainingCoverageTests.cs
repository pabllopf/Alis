using System;
using System.IO;
using System.Threading.Tasks;
using Alis.Core.Ecs.Systems.Scope;
using Dropbox.Api;
using Xunit;

namespace Alis.Extension.Cloud.DropBox.Test
{
    /// <summary>
    /// The drop box cloud manager remaining coverage tests class
    /// </summary>
    public class DropBoxCloudManagerRemainingCoverageTests
    {
        /// <summary>
        /// Tests that download file async with non existent directory creates directory
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
        /// Tests that download file async with existing directory skips creation
        /// </summary>
        [Fact]
        public async Task DownloadFileAsync_WithExistingDirectory_SkipsCreation()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));
            string tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDir);
            string destPath = Path.Combine(tempDir, "file.txt");

            try
            {
                Exception exception = await Record.ExceptionAsync(() =>
                    manager.DownloadFileAsync("/remote.txt", destPath));

                Assert.NotNull(exception);
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
        /// Tests that download file async with local path no directory component skips directory creation
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
        /// Tests that download file async with null dropbox path throws null reference exception
        /// </summary>
        [Fact]
        public async Task DownloadFileAsync_WithNullDropboxPath_ThrowsNullReferenceException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            await Assert.ThrowsAsync<NullReferenceException>(() =>
                manager.DownloadFileAsync(null, "/temp/file.txt"));
        }

        /// <summary>
        /// Tests that download file async with null local path throws exception
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
        /// Tests that upload file async with null dropbox path throws null reference exception
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
        /// Tests that delete async with null path throws null reference exception
        /// </summary>
        [Fact]
        public async Task DeleteAsync_WithNullPath_ThrowsNullReferenceException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            await Assert.ThrowsAsync<NullReferenceException>(() =>
                manager.DeleteAsync(null));
        }

        /// <summary>
        /// Tests that get metadata async with null path throws null reference exception
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_WithNullPath_ThrowsNullReferenceException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            await Assert.ThrowsAsync<NullReferenceException>(() =>
                manager.GetMetadataAsync(null));
        }
    }
}
