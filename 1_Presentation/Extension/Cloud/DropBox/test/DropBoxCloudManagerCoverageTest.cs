using System;
using System.IO;
using System.Threading.Tasks;
using Alis.Core.Ecs.Systems.Scope;
using Dropbox.Api;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace Alis.Extension.Cloud.DropBox.Test
{
    
    /// <summary>
    /// The drop box cloud manager coverage test class
    /// </summary>
    public class DropBoxCloudManagerCoverageTest
    {
        /// <summary>
        /// Tests that upload file async with non existent file throws file not found exception
        /// </summary>
        [Fact]
        public async Task UploadFileAsync_WithNonExistentFile_ThrowsFileNotFoundException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));
            string nonExistentPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            await Assert.ThrowsAsync<FileNotFoundException>(() =>
                manager.UploadFileAsync(nonExistentPath, "/dest.txt"));
        }

        /// <summary>
        /// Tests that upload file async with non existent file and path normalized throws file not found exception
        /// </summary>
        [Fact]
        public async Task UploadFileAsync_WithNonExistentFileAndPathNormalized_ThrowsFileNotFoundException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));
            string nonExistentPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            await Assert.ThrowsAsync<FileNotFoundException>(() =>
                manager.UploadFileAsync(nonExistentPath, "dest.txt"));
        }

        /// <summary>
        /// Tests that upload file async when api throws throws exception
        /// </summary>
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

        /// <summary>
        /// Tests that download file async when api throws throws exception
        /// </summary>
        [Fact]
        public async Task DownloadFileAsync_WhenApiThrows_ThrowsException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.DownloadFileAsync("/source.txt", "/dest/file.txt"));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        /// <summary>
        /// Tests that download file async with path normalized when api throws throws exception
        /// </summary>
        [Fact]
        public async Task DownloadFileAsync_WithPathNormalized_WhenApiThrows_ThrowsException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.DownloadFileAsync("source.txt", "/dest/file.txt"));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }
        
        /// <summary>
        /// Tests that dispose with initialized client should not throw
        /// </summary>
        [Fact]
        public void Dispose_WithInitializedClient_ShouldNotThrow()
        {
            DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = Record.Exception(() => manager.Dispose());
            Assert.Null(exception);
        }

        /// <summary>
        /// Tests that dispose multiple calls with initialized client should not throw
        /// </summary>
        [Fact]
        public void Dispose_MultipleCallsWithInitializedClient_ShouldNotThrow()
        {
            DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception first = Record.Exception(() => manager.Dispose());
            Assert.Null(first);

            Exception second = Record.Exception(() => manager.Dispose());
            Assert.Null(second);
        }

        /// <summary>
        /// Tests that on destroy with initialized client should not throw
        /// </summary>
        [Fact]
        public void OnDestroy_WithInitializedClient_ShouldNotThrow()
        {
            DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception exception = Record.Exception(() => manager.OnDestroy());
            Assert.Null(exception);
        }

        /// <summary>
        /// Tests that on destroy then dispose with initialized client should not throw
        /// </summary>
        [Fact]
        public void OnDestroy_ThenDispose_WithInitializedClient_ShouldNotThrow()
        {
            DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception onDestroy = Record.Exception(() => manager.OnDestroy());
            Assert.Null(onDestroy);

            Exception dispose = Record.Exception(() => manager.Dispose());
            Assert.Null(dispose);
        }

        /// <summary>
        /// Tests that dispose then on destroy with initialized client should not throw
        /// </summary>
        [Fact]
        public void Dispose_ThenOnDestroy_WithInitializedClient_ShouldNotThrow()
        {
            DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Exception dispose = Record.Exception(() => manager.Dispose());
            Assert.Null(dispose);

            Exception onDestroy = Record.Exception(() => manager.OnDestroy());
            Assert.Null(onDestroy);
        }

        /// <summary>
        /// Tests that initialize async with null token throws argument exception
        /// </summary>
        [Fact]
        public async Task InitializeAsync_WithNullToken_ThrowsArgumentException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context());

            await Assert.ThrowsAsync<ArgumentException>(() =>
                manager.InitializeAsync(null));
        }

        /// <summary>
        /// Tests that initialize async with empty token throws argument exception
        /// </summary>
        [Fact]
        public async Task InitializeAsync_WithEmptyToken_ThrowsArgumentException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context());

            await Assert.ThrowsAsync<ArgumentException>(() =>
                manager.InitializeAsync(string.Empty));
        }

        /// <summary>
        /// Tests that is initialized with client set returns true
        /// </summary>
        [Fact]
        public void IsInitialized_WithClientSet_ReturnsTrue()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Assert.True(manager.IsInitialized);
        }

        /// <summary>
        /// Tests that is initialized after dispose with client returns false
        /// </summary>
        [Fact]
        public void IsInitialized_AfterDisposeWithClient_ReturnsFalse()
        {
            DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Assert.True(manager.IsInitialized);
            manager.Dispose();
            Assert.False(manager.IsInitialized);
        }

        /// <summary>
        /// Tests that is initialized after on destroy with client returns false
        /// </summary>
        [Fact]
        public void IsInitialized_AfterOnDestroyWithClient_ReturnsFalse()
        {
            DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            Assert.True(manager.IsInitialized);
            manager.OnDestroy();
            Assert.False(manager.IsInitialized);
        }

        /// <summary>
        /// Tests that upload file async with local file path null throws exception
        /// </summary>
        [Fact]
        public async Task UploadFileAsync_WithLocalFilePathNull_ThrowsException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            await Assert.ThrowsAsync<FileNotFoundException>(() =>
                manager.UploadFileAsync(null, "/dest.txt"));
        }
    }
}
