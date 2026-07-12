using System;
using System.IO;
using System.Threading.Tasks;
using Alis.Core.Ecs.Systems.Scope;
using Dropbox.Api;
using Xunit;

namespace Alis.Extension.Cloud.DropBox.Test
{
    /// <summary>
    /// Final coverage tests for DropBoxCloudManager
    /// </summary>
    public class DropBoxCloudManagerFinalCoverageTests
    {
        /// <summary>
        /// Tests that list files async with initialized client and normal path calls api
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_WithInitializedClientAndNormalPath_CallsApi()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.ListFilesAsync("/test-folder"));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        /// <summary>
        /// Tests that list files async with initialized client and path needing normalization calls api
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_WithInitializedClientAndPathNeedsNormalization_CallsApi()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.ListFilesAsync("test-folder"));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        /// <summary>
        /// Tests that list files async with initialized client and recursive true calls api
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_WithInitializedClientAndRecursive_CallsApi()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.ListFilesAsync("/test-folder", true));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        /// <summary>
        /// Tests that delete async with initialized client and normal path calls api
        /// </summary>
        [Fact]
        public async Task DeleteAsync_WithInitializedClientAndNormalPath_CallsApi()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.DeleteAsync("/test-file.txt"));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        /// <summary>
        /// Tests that delete async with initialized client and path needing normalization calls api
        /// </summary>
        [Fact]
        public async Task DeleteAsync_WithInitializedClientAndPathNeedsNormalization_CallsApi()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.DeleteAsync("test-file.txt"));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        /// <summary>
        /// Tests that get metadata async with initialized client and normal path calls api
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_WithInitializedClientAndNormalPath_CallsApi()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.GetMetadataAsync("/test-file.txt"));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        /// <summary>
        /// Tests that get metadata async with initialized client and path needing normalization calls api
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_WithInitializedClientAndPathNeedsNormalization_CallsApi()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.GetMetadataAsync("test-file.txt"));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        /// <summary>
        /// Tests that upload file async with initialized client and path needing normalization normalizes path
        /// </summary>
        [Fact]
        public async Task UploadFileAsync_WithInitializedClientAndPathNeedsNormalization_NormalizesPath()
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
        /// Tests that upload file async with initialized client and existing file reaches api
        /// </summary>
        [Fact]
        public async Task UploadFileAsync_WithInitializedClientAndExistingFile_ReachesApi()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));
            string tempFile = Path.GetTempFileName();

            try
            {
                Exception exception = await Record.ExceptionAsync(() =>
                    manager.UploadFileAsync(tempFile, "/dest.txt"));

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
    }
}
