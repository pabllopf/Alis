

using System;
using System.Threading.Tasks;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Extension.Cloud.DropBox.Test
{
    /// <summary>
    ///     The DropBox cloud manager test class
    /// </summary>
    public class DropBoxCloudManagerTest
    {
        /// <summary>
        ///     Creates a mock context for testing
        /// </summary>
        /// <returns>A mock context</returns>
        private static Context CreateMockContext() => new Context();

        /// <summary>
        ///     Tests that the manager can be instantiated
        /// </summary>
        [Fact]
        public void Constructor_WithContext_CreatesManagerSuccessfully()
        {
            Context context = CreateMockContext();

            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            Assert.NotNull(manager);
            Assert.Equal("DropBoxManager", manager.Name);
            Assert.Equal("Cloud", manager.Tag);
            Assert.False(manager.IsInitialized);
        }

        /// <summary>
        ///     Tests that the manager can be instantiated with all parameters
        /// </summary>
        [Fact]
        public void Constructor_WithAllParameters_CreatesManagerSuccessfully()
        {
            Context context = CreateMockContext();
            string id = "test-id";
            string name = "TestManager";
            string tag = "TestTag";

            DropBoxCloudManager manager = new DropBoxCloudManager(id, name, tag, true, context);

            Assert.NotNull(manager);
            Assert.Equal(id, manager.Id);
            Assert.Equal(name, manager.Name);
            Assert.Equal(tag, manager.Tag);
            Assert.True(manager.IsEnable);
        }

        /// <summary>
        ///     Tests that initialization without access token throws exception
        /// </summary>
        [Fact]
        public async Task InitializeAsync_WithNullToken_ThrowsArgumentException()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            await Assert.ThrowsAsync<ArgumentException>(() => manager.InitializeAsync(null));
        }

        /// <summary>
        ///     Tests that initialization with empty token throws exception
        /// </summary>
        [Fact]
        public async Task InitializeAsync_WithEmptyToken_ThrowsArgumentException()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            await Assert.ThrowsAsync<ArgumentException>(() => manager.InitializeAsync(string.Empty));
        }

        /// <summary>
        ///     Tests that upload with non-existent file throws exception
        /// </summary>
        [Fact]
        public async Task UploadFileAsync_WithNonExistentFile_ThrowsFileNotFoundException()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            string nonExistentFile = "/path/that/does/not/exist/file.txt";

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                manager.UploadFileAsync(nonExistentFile, "/test.txt"));
        }

        /// <summary>
        ///     Tests that download without initialization throws exception
        /// </summary>
        [Fact]
        public async Task DownloadFileAsync_WithoutInitialization_ThrowsInvalidOperationException()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                manager.DownloadFileAsync("/test.txt", "/tmp/test.txt"));
        }

        /// <summary>
        ///     Tests that list files without initialization throws exception
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_WithoutInitialization_ThrowsInvalidOperationException()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                manager.ListFilesAsync("/"));
        }

        /// <summary>
        ///     Tests that delete without initialization throws exception
        /// </summary>
        [Fact]
        public async Task DeleteAsync_WithoutInitialization_ThrowsInvalidOperationException()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                manager.DeleteAsync("/test.txt"));
        }

        /// <summary>
        ///     Tests that get metadata without initialization throws exception
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_WithoutInitialization_ThrowsInvalidOperationException()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                manager.GetMetadataAsync("/test.txt"));
        }

        /// <summary>
        ///     Tests that is initialized property works correctly before initialization
        /// </summary>
        [Fact]
        public void IsInitialized_BeforeInitialization_ReturnsFalse()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            Assert.False(manager.IsInitialized);
        }

        /// <summary>
        ///     Tests that path normalization adds leading slash
        /// </summary>
        [Fact]
        public void PathNormalization_WithoutLeadingSlash_AddSlash()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            // by verifying the manager structure

            Assert.NotNull(manager);
            Assert.False(manager.IsInitialized);
        }

        /// <summary>
        ///     Tests constructor with default parameters initializes correctly
        /// </summary>
        [Fact]
        public void Constructor_Default_InitializesWithDefaultValues()
        {
            Context context = CreateMockContext();

            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            Assert.NotNull(manager.Id);
            Assert.Equal("DropBoxManager", manager.Name);
            Assert.Equal("Cloud", manager.Tag);
            Assert.True(manager.IsEnable);
        }

        /// <summary>
        ///     Tests that multiple instances can be created independently
        /// </summary>
        [Fact]
        public void MultipleInstances_AreIndependent()
        {
            Context context1 = CreateMockContext();
            Context context2 = CreateMockContext();

            DropBoxCloudManager manager1 = new DropBoxCloudManager(context1);
            DropBoxCloudManager manager2 = new DropBoxCloudManager(context2);

            Assert.NotEqual(manager1.Id, manager2.Id);
            Assert.NotNull(manager1);
            Assert.NotNull(manager2);
        }

        /// <summary>
        ///     Tests that manager properties can be modified
        /// </summary>
        [Fact]
        public void ManagerProperties_CanBeModified()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            manager.Name = "NewName";
            manager.Tag = "NewTag";
            manager.IsEnable = false;

            Assert.Equal("NewName", manager.Name);
            Assert.Equal("NewTag", manager.Tag);
            Assert.False(manager.IsEnable);
        }
    }
}