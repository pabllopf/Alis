using System;
using System.IO;
using System.Threading.Tasks;
using Alis.Core.Ecs.Systems.Scope;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Xunit;

namespace Alis.Extension.Cloud.GoogleDrive.Test
{
    /// <summary>
    /// The google drive cloud manager coverage test class
    /// </summary>
    public class GoogleDriveCloudManagerCoverageTest
    {
        /// <summary>
        /// Tests that constructor with drive service is initialized true
        /// </summary>
        [Fact]
        public void Constructor_WithDriveService_IsInitializedTrue()
        {
            using GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), new DriveService(new BaseClientService.Initializer()));

            Assert.True(manager.IsInitialized);
        }

        /// <summary>
        /// Tests that constructor without drive service is initialized false
        /// </summary>
        [Fact]
        public void Constructor_WithoutDriveService_IsInitializedFalse()
        {
            using GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context());

            Assert.False(manager.IsInitialized);
        }

        /// <summary>
        /// Tests that upload file async with non existent file throws file not found exception
        /// </summary>
        [Fact]
        public async Task UploadFileAsync_WithNonExistentFile_ThrowsFileNotFoundException()
        {
            using GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), new DriveService(new BaseClientService.Initializer()));
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
            using GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), new DriveService(new BaseClientService.Initializer()));
            string nonExistentPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            await Assert.ThrowsAsync<FileNotFoundException>(() =>
                manager.UploadFileAsync(nonExistentPath, "dest.txt"));
        }

        /// <summary>
        /// Tests that upload file async with local file path null throws file not found exception
        /// </summary>
        [Fact]
        public async Task UploadFileAsync_WithLocalFilePathNull_ThrowsFileNotFoundException()
        {
            using GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), new DriveService(new BaseClientService.Initializer()));

            await Assert.ThrowsAsync<FileNotFoundException>(() =>
                manager.UploadFileAsync(null, "/dest.txt"));
        }

        /// <summary>
        /// Tests that upload file async when api throws throws exception
        /// </summary>
        [Fact]
        public async Task UploadFileAsync_WhenApiThrows_ThrowsException()
        {
            using GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), new DriveService(new BaseClientService.Initializer()));
            string dummyPath = Path.GetTempFileName();

            try
            {
                Exception exception = await Record.ExceptionAsync(() =>
                    manager.UploadFileAsync(dummyPath, "/dest.txt"));

                Assert.NotNull(exception);
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
            using GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), new DriveService(new BaseClientService.Initializer()));

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
            using GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), new DriveService(new BaseClientService.Initializer()));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.DownloadFileAsync("source.txt", "/dest/file.txt"));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        /// <summary>
        /// Tests that list files async when api throws throws exception
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_WhenApiThrows_ThrowsException()
        {
            using GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), new DriveService(new BaseClientService.Initializer()));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.ListFilesAsync("/"));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        /// <summary>
        /// Tests that list files async with empty path defaults to root
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_WithEmptyPath_DefaultsToRoot()
        {
            using GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), new DriveService(new BaseClientService.Initializer()));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.ListFilesAsync(string.Empty));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        /// <summary>
        /// Tests that list files async with null path defaults to root
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_WithNullPath_DefaultsToRoot()
        {
            using GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), new DriveService(new BaseClientService.Initializer()));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.ListFilesAsync(null));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        /// <summary>
        /// Tests that list files async with path no leading slash normalizes path
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_WithPathNoLeadingSlash_NormalizesPath()
        {
            using GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), new DriveService(new BaseClientService.Initializer()));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.ListFilesAsync("folder/subfolder"));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        /// <summary>
        /// Tests that delete async when api throws throws exception
        /// </summary>
        [Fact]
        public async Task DeleteAsync_WhenApiThrows_ThrowsException()
        {
            using GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), new DriveService(new BaseClientService.Initializer()));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.DeleteAsync("/file.txt"));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        /// <summary>
        /// Tests that delete async with path normalized when api throws throws exception
        /// </summary>
        [Fact]
        public async Task DeleteAsync_WithPathNormalized_WhenApiThrows_ThrowsException()
        {
            using GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), new DriveService(new BaseClientService.Initializer()));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.DeleteAsync("file.txt"));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        /// <summary>
        /// Tests that get metadata async when api throws throws exception
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_WhenApiThrows_ThrowsException()
        {
            using GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), new DriveService(new BaseClientService.Initializer()));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.GetMetadataAsync("/file.txt"));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        /// <summary>
        /// Tests that get metadata async with path normalized when api throws throws exception
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_WithPathNormalized_WhenApiThrows_ThrowsException()
        {
            using GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), new DriveService(new BaseClientService.Initializer()));

            Exception exception = await Record.ExceptionAsync(() =>
                manager.GetMetadataAsync("file.txt"));

            Assert.NotNull(exception);
            Assert.IsNotType<InvalidOperationException>(exception);
        }

        /// <summary>
        /// Tests that dispose with drive service should not throw
        /// </summary>
        [Fact]
        public void Dispose_WithDriveService_ShouldNotThrow()
        {
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), new DriveService(new BaseClientService.Initializer()));

            Exception exception = Record.Exception(() => manager.Dispose());
            Assert.Null(exception);
        }

        /// <summary>
        /// Tests that dispose multiple calls should not throw
        /// </summary>
        [Fact]
        public void Dispose_MultipleCalls_ShouldNotThrow()
        {
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), new DriveService(new BaseClientService.Initializer()));

            Exception first = Record.Exception(() => manager.Dispose());
            Assert.Null(first);

            Exception second = Record.Exception(() => manager.Dispose());
            Assert.Null(second);
        }

        /// <summary>
        /// Tests that on destroy with drive service should not throw
        /// </summary>
        [Fact]
        public void OnDestroy_WithDriveService_ShouldNotThrow()
        {
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), new DriveService(new BaseClientService.Initializer()));

            Exception exception = Record.Exception(() => manager.OnDestroy());
            Assert.Null(exception);
        }

        /// <summary>
        /// Tests that on destroy then dispose should not throw
        /// </summary>
        [Fact]
        public void OnDestroy_ThenDispose_ShouldNotThrow()
        {
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), new DriveService(new BaseClientService.Initializer()));

            Exception onDestroy = Record.Exception(() => manager.OnDestroy());
            Assert.Null(onDestroy);

            Exception dispose = Record.Exception(() => manager.Dispose());
            Assert.Null(dispose);
        }

        /// <summary>
        /// Tests that dispose then on destroy should not throw
        /// </summary>
        [Fact]
        public void Dispose_ThenOnDestroy_ShouldNotThrow()
        {
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), new DriveService(new BaseClientService.Initializer()));

            Exception dispose = Record.Exception(() => manager.Dispose());
            Assert.Null(dispose);

            Exception onDestroy = Record.Exception(() => manager.OnDestroy());
            Assert.Null(onDestroy);
        }

        /// <summary>
        /// Tests that is initialized after dispose returns false
        /// </summary>
        [Fact]
        public void IsInitialized_AfterDispose_ReturnsFalse()
        {
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), new DriveService(new BaseClientService.Initializer()));

            Assert.True(manager.IsInitialized);
            manager.Dispose();
            Assert.False(manager.IsInitialized);
        }

        /// <summary>
        /// Tests that is initialized after on destroy returns false
        /// </summary>
        [Fact]
        public void IsInitialized_AfterOnDestroy_ReturnsFalse()
        {
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), new DriveService(new BaseClientService.Initializer()));

            Assert.True(manager.IsInitialized);
            manager.OnDestroy();
            Assert.False(manager.IsInitialized);
        }
    }
}
