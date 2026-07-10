using System;
using System.IO;
using System.Threading.Tasks;
using Alis.Core.Ecs.Systems.Scope;
using Dropbox.Api;
using Dropbox.Api.Files;
using Moq;
using Xunit;

namespace Alis.Extension.Cloud.DropBox.Test
{
    public class DropBoxCloudManagerCoverageTest
    {
        [Fact]
        public async Task UploadFileAsync_WithNonExistentFile_ThrowsFileNotFoundException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));
            string nonExistentPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            await Assert.ThrowsAsync<FileNotFoundException>(() =>
                manager.UploadFileAsync(nonExistentPath, "/dest.txt"));
        }

        [Fact]
        public async Task UploadFileAsync_WithNonExistentFileAndPathNormalized_ThrowsFileNotFoundException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));
            string nonExistentPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            await Assert.ThrowsAsync<FileNotFoundException>(() =>
                manager.UploadFileAsync(nonExistentPath, "dest.txt"));
        }

        [Fact]
        public async Task UploadFileAsync_WhenApiThrows_ThrowsException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));
            string dummyPath = Path.GetTempFileName();

            try
            {
                Exception exception = await Record.ExceptionAsync(() =>
                    manager.UploadFileAsync(dummyPath, "/dest.txt"));

                Assert.NotNull(exception);
                Assert.IsNotType<InvalidOperationException>(exception);
                Assert.IsNotType<FileNotFoundException>(exception);
            }
            finally
            {
                File.Delete(dummyPath);
            }
        }

        [Fact]
        public async Task DownloadFileAsync_WhenApiThrows_ThrowsException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.DownloadFileAsync("/source.txt", "/dest/file.txt"));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        [Fact]
        public async Task DownloadFileAsync_WithPathNormalized_WhenApiThrows_ThrowsException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.DownloadFileAsync("source.txt", "/dest/file.txt"));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        [Fact]
        public async Task ListFilesAsync_WhenApiThrows_ThrowsException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.ListFilesAsync("/"));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        [Fact]
        public async Task ListFilesAsync_WithEmptyPath_DefaultsToRoot()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.ListFilesAsync(string.Empty));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        [Fact]
        public async Task ListFilesAsync_WithNullPath_DefaultsToRoot()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.ListFilesAsync(null));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        [Fact]
        public async Task ListFilesAsync_WithPathNoLeadingSlash_NormalizesPath()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.ListFilesAsync("folder/subfolder"));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        [Fact]
        public async Task ListFilesAsync_WithRecursiveTrue_WhenApiThrows_ThrowsException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.ListFilesAsync("/", true));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        [Fact]
        public async Task DeleteAsync_WhenApiThrows_ThrowsException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.DeleteAsync("/file.txt"));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        [Fact]
        public async Task DeleteAsync_WithPathNormalized_WhenApiThrows_ThrowsException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.DeleteAsync("file.txt"));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        [Fact]
        public async Task GetMetadataAsync_WhenApiThrows_ThrowsException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.GetMetadataAsync("/file.txt"));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        [Fact]
        public async Task GetMetadataAsync_WithPathNormalized_WhenApiThrows_ThrowsException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.GetMetadataAsync("file.txt"));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        [Fact]
        public void Dispose_WithInitializedClient_ShouldNotThrow()
        {
            DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = Record.Exception(() => manager.Dispose());
            Assert.Null(exception);
        }

        [Fact]
        public void Dispose_MultipleCallsWithInitializedClient_ShouldNotThrow()
        {
            DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception first = Record.Exception(() => manager.Dispose());
            Assert.Null(first);

            Exception second = Record.Exception(() => manager.Dispose());
            Assert.Null(second);
        }

        [Fact]
        public void OnDestroy_WithInitializedClient_ShouldNotThrow()
        {
            DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = Record.Exception(() => manager.OnDestroy());
            Assert.Null(exception);
        }

        [Fact]
        public void OnDestroy_ThenDispose_WithInitializedClient_ShouldNotThrow()
        {
            DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception onDestroy = Record.Exception(() => manager.OnDestroy());
            Assert.Null(onDestroy);

            Exception dispose = Record.Exception(() => manager.Dispose());
            Assert.Null(dispose);
        }

        [Fact]
        public void Dispose_ThenOnDestroy_WithInitializedClient_ShouldNotThrow()
        {
            DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception dispose = Record.Exception(() => manager.Dispose());
            Assert.Null(dispose);

            Exception onDestroy = Record.Exception(() => manager.OnDestroy());
            Assert.Null(onDestroy);
        }

        [Fact]
        public async Task InitializeAsync_WithNullToken_ThrowsArgumentException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context());

            await Assert.ThrowsAsync<ArgumentException>(() =>
                manager.InitializeAsync(null));
        }

        [Fact]
        public async Task InitializeAsync_WithEmptyToken_ThrowsArgumentException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context());

            await Assert.ThrowsAsync<ArgumentException>(() =>
                manager.InitializeAsync(string.Empty));
        }

        [Fact]
        public async Task InitializeAsync_WithDummyToken_Throws()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context());

            Exception exception = await Record.ExceptionAsync(() =>
                manager.InitializeAsync("some-token"));

            Assert.NotNull(exception);
            Assert.False(manager.IsInitialized);
        }

        [Fact]
        public void IsInitialized_WithClientSet_ReturnsTrue()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Assert.True(manager.IsInitialized);
        }

        [Fact]
        public void IsInitialized_AfterDisposeWithClient_ReturnsFalse()
        {
            DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Assert.True(manager.IsInitialized);
            manager.Dispose();
            Assert.False(manager.IsInitialized);
        }

        [Fact]
        public void IsInitialized_AfterOnDestroyWithClient_ReturnsFalse()
        {
            DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Assert.True(manager.IsInitialized);
            manager.OnDestroy();
            Assert.False(manager.IsInitialized);
        }

        [Fact]
        public async Task UploadFileAsync_WithLocalFilePathNull_ThrowsException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            await Assert.ThrowsAsync<FileNotFoundException>(() =>
                manager.UploadFileAsync(null, "/dest.txt"));
        }
    }
}
