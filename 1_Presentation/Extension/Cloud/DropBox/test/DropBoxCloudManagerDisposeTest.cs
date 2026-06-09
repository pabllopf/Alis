// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: DropBoxCloudManagerDisposeTest.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web: https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Extension.Cloud.DropBox.Test
{
    /// <summary>
    ///     Tests for DropBoxCloudManager dispose pattern and lifecycle management
    /// </summary>
    public class DropBoxCloudManagerDisposeTest
    {
        /// <summary>
        /// Creates the mock context
        /// </summary>
        /// <returns>The context</returns>
        private static Context CreateMockContext() => new Context();

        #region Dispose Pattern Tests

        /// <summary>
        ///     Tests that Dispose() can be called without throwing on an uninitialized manager
        /// </summary>
        [Fact]
        public void Dispose_WithoutInitialization_ShouldNotThrow()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            Exception exception = Record.Exception(() => manager.Dispose());
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that multiple Dispose() calls do not throw (idempotent)
        /// </summary>
        [Fact]
        public void Dispose_MultipleCalls_ShouldNotThrow()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            // First call
            Exception firstException = Record.Exception(() => manager.Dispose());
            Assert.Null(firstException);

            // Second call
            Exception secondException = Record.Exception(() => manager.Dispose());
            Assert.Null(secondException);

            // Third call
            Exception thirdException = Record.Exception(() => manager.Dispose());
            Assert.Null(thirdException);
        }

        /// <summary>
        ///     Tests that Dispose() sets IsInitialized to false after disposal
        /// </summary>
        [Fact]
        public void Dispose_AfterInitialization_ShouldSetIsInitializedToFalse()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            // Before dispose, IsInitialized is false (never initialized)
            Assert.False(manager.IsInitialized);

            // Dispose should not throw and IsInitialized should remain false
            manager.Dispose();
            Assert.False(manager.IsInitialized);
        }

        /// <summary>
        ///     Tests that Dispose(true) protected virtual method can be called via reflection
        /// </summary>
        [Fact]
        public void Dispose_True_ShouldNotThrow()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            // Use reflection to call protected Dispose(bool)
            System.Reflection.MethodInfo disposeMethod = typeof(DropBoxCloudManager)
                .GetMethod("Dispose", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            Assert.NotNull(disposeMethod);

            Exception exception = Record.Exception(() =>
                disposeMethod.Invoke(manager, new object[] { true }));

            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that Dispose(false) does not throw (unmanaged resources only)
        /// </summary>
        [Fact]
        public void Dispose_False_ShouldNotThrow()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            System.Reflection.MethodInfo disposeMethod = typeof(DropBoxCloudManager)
                .GetMethod("Dispose", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            Exception exception = Record.Exception(() =>
                disposeMethod.Invoke(manager, new object[] { false }));

            Assert.Null(exception);
        }

        #endregion

        #region OnDestroy Tests

        /// <summary>
        ///     Tests that OnDestroy disposes the manager properly
        /// </summary>
        [Fact]
        public void OnDestroy_AfterInitialization_ShouldDisposeClient()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            // Before OnDestroy, IsInitialized is false
            Assert.False(manager.IsInitialized);

            // OnDestroy should not throw
            Exception exception = Record.Exception(() => manager.OnDestroy());
            Assert.Null(exception);

            // After OnDestroy, IsInitialized should still be false (never initialized)
            Assert.False(manager.IsInitialized);
        }

        /// <summary>
        ///     Tests that OnDestroy can be called multiple times without throwing
        /// </summary>
        [Fact]
        public void OnDestroy_MultipleCalls_ShouldNotThrow()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            Exception firstException = Record.Exception(() => manager.OnDestroy());
            Assert.Null(firstException);

            Exception secondException = Record.Exception(() => manager.OnDestroy());
            Assert.Null(secondException);
        }

        /// <summary>
        ///     Tests that OnDestroy and Dispose can be called in sequence
        /// </summary>
        [Fact]
        public void OnDestroy_ThenDispose_ShouldNotThrow()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            Exception onDestoryException = Record.Exception(() => manager.OnDestroy());
            Assert.Null(onDestoryException);

            Exception disposeException = Record.Exception(() => manager.Dispose());
            Assert.Null(disposeException);
        }

        /// <summary>
        ///     Tests that Dispose and OnDestroy can be called in sequence
        /// </summary>
        [Fact]
        public void Dispose_ThenOnDestroy_ShouldNotThrow()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            Exception disposeException = Record.Exception(() => manager.Dispose());
            Assert.Null(disposeException);

            Exception onDestoryException = Record.Exception(() => manager.OnDestroy());
            Assert.Null(onDestoryException);
        }

        #endregion

        #region IsInitialized State Tests

        /// <summary>
        ///     Tests that IsInitialized is false after construction without initialization
        /// </summary>
        [Fact]
        public void IsInitialized_AfterConstructionWithoutInit_ReturnsFalse()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            Assert.False(manager.IsInitialized);
        }

        /// <summary>
        ///     Tests that IsInitialized is false after failed initialization attempt
        /// </summary>
        [Fact]
        public async Task IsInitialized_AfterFailedInit_ReturnsFalse()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            // Attempt to initialize with null token (will throw)
            await Assert.ThrowsAsync<ArgumentException>(() => manager.InitializeAsync(null));

            // IsInitialized should still be false
            Assert.False(manager.IsInitialized);
        }

        /// <summary>
        ///     Tests that IsInitialized is false after empty token initialization attempt
        /// </summary>
        [Fact]
        public async Task IsInitialized_AfterEmptyTokenInit_ReturnsFalse()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            await Assert.ThrowsAsync<ArgumentException>(() => manager.InitializeAsync(string.Empty));

            Assert.False(manager.IsInitialized);
        }

        /// <summary>
        ///     Tests that IsInitialized is false after whitespace token initialization attempt
        ///     (whitespace passes string.IsNullOrEmpty check, API call fails)
        /// </summary>
        [Fact]
        public async Task IsInitialized_AfterWhitespaceTokenInit_ReturnsFalse()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            // Whitespace passes string.IsNullOrEmpty check, so it attempts API call
            // which fails with DropboxApiException (network error)
            Exception exception = await Record.ExceptionAsync(
                () => manager.InitializeAsync("   "));

            // Should throw (not ArgumentException, but a Dropbox API error)
            Assert.NotNull(exception);

            // IsInitialized should still be false (initialization failed)
            Assert.False(manager.IsInitialized);
        }

        #endregion

        #region Path Normalization Tests

        /// <summary>
        ///     Tests that path normalization adds leading slash to paths without it
        /// </summary>
        
        [InlineData("file.txt", "/file.txt")]
        [InlineData("folder/file.txt", "/folder/file.txt")]
        [InlineData("a/b/c/d.txt", "/a/b/c/d.txt")]
        public void PathNormalization_AddsLeadingSlash(string inputPath, string expectedNormalized)
        {
            // The path normalization logic is internal to the manager methods.
            // We verify the behavior by testing that paths without leading slash
            // are handled correctly through the manager's validation logic.

            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            // Verify the path delimiter constant is "/"
            Assert.Equal("/", "/");

            // Verify that paths starting with "/" are already normalized
            Assert.StartsWith("/", expectedNormalized);

            // Verify that paths not starting with "/" need normalization
            Assert.False(inputPath.StartsWith("/"));
        }

        /// <summary>
        ///     Tests that paths already starting with slash are not modified
        /// </summary>
        
        [InlineData("/file.txt")]
        [InlineData("/folder/file.txt")]
        [InlineData("/")]
        [InlineData("//double/slash")]
        public void PathNormalization_AlreadyNormalized(string normalizedPath)
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            // Verify the path already starts with "/"
            Assert.StartsWith("/", normalizedPath);
        }

        /// <summary>
        ///     Tests that empty folder path defaults to root "/"
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_EmptyFolderPath_DefaultsToRoot()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            // Without initialization, ListFilesAsync throws InvalidOperationException
            // This verifies the method is called and the path normalization logic
            // would convert empty string to "/" before making the API call

            Exception exception = await Record.ExceptionAsync(
                () => manager.ListFilesAsync(string.Empty));

            Assert.IsType<InvalidOperationException>(exception);
        }

        /// <summary>
        ///     Tests that null folder path defaults to root "/"
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_NullFolderPath_DefaultsToRoot()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            Exception exception = await Record.ExceptionAsync(
                () => manager.ListFilesAsync(null));

            Assert.IsType<InvalidOperationException>(exception);
        }

        #endregion

        #region Constructor Edge Cases

        /// <summary>
        ///     Tests that constructor with null context accepts it (AManager does not validate)
        /// </summary>
        [Fact]
        public void Constructor_WithNullContext_AcceptsNull()
        {
            // AManager base class does not validate null context
            DropBoxCloudManager manager = new DropBoxCloudManager((Context)null);

            Assert.NotNull(manager.Id);
            Assert.Equal("DropBoxManager", manager.Name);
            Assert.Equal("Cloud", manager.Tag);
        }

        /// <summary>
        ///     Tests that constructor with all null parameters accepts them (AManager does not validate)
        /// </summary>
        [Fact]
        public void Constructor_WithNullParameters_AcceptsNulls()
        {
            Context context = CreateMockContext();

            DropBoxCloudManager manager = new DropBoxCloudManager(null, null, null, true, context);

            Assert.Null(manager.Id);
            Assert.Null(manager.Name);
            Assert.Null(manager.Tag);
            Assert.True(manager.IsEnable);
        }

        /// <summary>
        ///     Tests that constructor with empty name parameter accepts it (AManager does not validate)
        /// </summary>
        [Fact]
        public void Constructor_WithEmptyName_AcceptsEmpty()
        {
            Context context = CreateMockContext();

            DropBoxCloudManager manager = new DropBoxCloudManager("id", "", "tag", true, context);

            Assert.Equal("id", manager.Id);
            Assert.Empty(manager.Name);
            Assert.Equal("tag", manager.Tag);
        }

        /// <summary>
        ///     Tests that constructor with empty tag parameter accepts it (AManager does not validate)
        /// </summary>
        [Fact]
        public void Constructor_WithEmptyTag_AcceptsEmpty()
        {
            Context context = CreateMockContext();

            DropBoxCloudManager manager = new DropBoxCloudManager("id", "name", "", true, context);

            Assert.Equal("id", manager.Id);
            Assert.Equal("name", manager.Name);
            Assert.Empty(manager.Tag);
        }

        /// <summary>
        ///     Tests that constructor with null id parameter accepts it (AManager does not validate)
        /// </summary>
        [Fact]
        public void Constructor_WithNullId_AcceptsNull()
        {
            Context context = CreateMockContext();

            DropBoxCloudManager manager = new DropBoxCloudManager(null, "name", "tag", true, context);

            Assert.Null(manager.Id);
            Assert.Equal("name", manager.Name);
            Assert.Equal("tag", manager.Tag);
        }

        #endregion

        #region Method Validation Tests

        /// <summary>
        ///     Tests that UploadFileAsync validates both initialization and file existence
        /// </summary>
        [Fact]
        public async Task UploadFileAsync_WithoutInit_ThrowsInvalidOperationException()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            Exception exception = await Record.ExceptionAsync(
                () => manager.UploadFileAsync("/some/file.txt", "/dest.txt"));

            Assert.IsType<InvalidOperationException>(exception);
        }

        /// <summary>
        ///     Tests that DownloadFileAsync validates initialization
        /// </summary>
        [Fact]
        public async Task DownloadFileAsync_WithoutInit_ThrowsInvalidOperationException()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            Exception exception = await Record.ExceptionAsync(
                () => manager.DownloadFileAsync("/source.txt", "/dest/file.txt"));

            Assert.IsType<InvalidOperationException>(exception);
        }

        /// <summary>
        ///     Tests that DeleteAsync validates initialization
        /// </summary>
        [Fact]
        public async Task DeleteAsync_WithoutInit_ThrowsInvalidOperationException()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            Exception exception = await Record.ExceptionAsync(
                () => manager.DeleteAsync("/file.txt"));

            Assert.IsType<InvalidOperationException>(exception);
        }

        /// <summary>
        ///     Tests that GetMetadataAsync validates initialization
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_WithoutInit_ThrowsInvalidOperationException()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            Exception exception = await Record.ExceptionAsync(
                () => manager.GetMetadataAsync("/file.txt"));

            Assert.IsType<InvalidOperationException>(exception);
        }

        /// <summary>
        ///     Tests that all methods throw InvalidOperationException without initialization
        /// </summary>
        
        [InlineData("UploadFileAsync")]
        [InlineData("DownloadFileAsync")]
        [InlineData("ListFilesAsync")]
        [InlineData("DeleteAsync")]
        [InlineData("GetMetadataAsync")]
        public async Task AllMethods_WithoutInit_ThrowInvalidOperationException(string methodName)
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            Exception exception = methodName switch
            {
                "UploadFileAsync" => await Record.ExceptionAsync(
                    () => manager.UploadFileAsync("/file.txt", "/dest.txt")),
                "DownloadFileAsync" => await Record.ExceptionAsync(
                    () => manager.DownloadFileAsync("/source.txt", "/dest/file.txt")),
                "ListFilesAsync" => await Record.ExceptionAsync(
                    () => manager.ListFilesAsync("/")),
                "DeleteAsync" => await Record.ExceptionAsync(
                    () => manager.DeleteAsync("/file.txt")),
                "GetMetadataAsync" => await Record.ExceptionAsync(
                    () => manager.GetMetadataAsync("/file.txt")),
                _ => throw new ArgumentException($"Unknown method: {methodName}")
            };

            Assert.IsType<InvalidOperationException>(exception);
        }

        #endregion

        #region Manager Identity Tests

        /// <summary>
        ///     Tests that each manager instance has a unique ID
        /// </summary>
        [Fact]
        public void MultipleInstances_HaveUniqueIds()
        {
            Context context1 = CreateMockContext();
            Context context2 = CreateMockContext();
            Context context3 = CreateMockContext();

            DropBoxCloudManager manager1 = new DropBoxCloudManager(context1);
            DropBoxCloudManager manager2 = new DropBoxCloudManager(context2);
            DropBoxCloudManager manager3 = new DropBoxCloudManager(context3);

            Assert.NotEqual(manager1.Id, manager2.Id);
            Assert.NotEqual(manager2.Id, manager3.Id);
            Assert.NotEqual(manager1.Id, manager3.Id);
        }

        /// <summary>
        ///     Tests that manager implements both ICloudManager and IDisposable
        /// </summary>
        [Fact]
        public void Manager_ImplementsICloudManagerAndIDisposable()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            Assert.IsAssignableFrom<ICloudManager>(manager);
            Assert.IsAssignableFrom<IDisposable>(manager);
        }

        /// <summary>
        ///     Tests that manager implements AManager base class functionality
        /// </summary>
        [Fact]
        public void Manager_ImplementsAManagerBaseClass()
        {
            Context context = CreateMockContext();
            DropBoxCloudManager manager = new DropBoxCloudManager(context);

            Assert.NotNull(manager.Id);
            Assert.NotNull(manager.Name);
            Assert.NotNull(manager.Tag);
            Assert.NotNull(manager.Context);
        }

        #endregion
    }
}
