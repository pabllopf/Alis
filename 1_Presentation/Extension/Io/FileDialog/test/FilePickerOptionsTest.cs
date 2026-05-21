

using System;
using Xunit;

namespace Alis.Extension.Io.FileDialog.Test
{
    /// <summary>
    ///     Unit tests for FilePickerOptions class.
    /// </summary>
    public class FilePickerOptionsTest
    {
        /// <summary>
        ///     Tests that FilePickerOptions default constructor creates instance.
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldCreateInstanceWithDefaults()
        {
            FilePickerOptions options = new FilePickerOptions();

            Assert.NotNull(options);
            Assert.Equal("Select a file", options.Title);
            Assert.Null(options.DefaultPath);
            Assert.NotNull(options.Filters);
            Assert.Empty(options.Filters);
            Assert.False(options.AllowMultiple);
            Assert.False(options.AllowDirectories);
            Assert.Equal(FileDialogType.OpenFile, options.DialogType);
        }

        /// <summary>
        ///     Tests that FilePickerOptions constructor with parameters creates instance.
        /// </summary>
        [Fact]
        public void ConstructorWithParameters_ShouldCreateInstance()
        {
            FilePickerOptions options = new FilePickerOptions("Open File");

            Assert.Equal("Open File", options.Title);
            Assert.Equal(FileDialogType.OpenFile, options.DialogType);
        }

        /// <summary>
        ///     Tests that FilePickerOptions constructor throws with null title.
        /// </summary>
        [Fact]
        public void ConstructorWithNullTitle_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new FilePickerOptions(null));
        }

        /// <summary>
        ///     Tests that FilePickerOptions constructor throws with empty title.
        /// </summary>
        [Fact]
        public void ConstructorWithEmptyTitle_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new FilePickerOptions(""));
        }

        /// <summary>
        ///     Tests that WithFilter adds a filter to the options.
        /// </summary>
        [Fact]
        public void WithFilter_ShouldAddFilter()
        {
            FilePickerOptions options = new FilePickerOptions("Test");
            FilePickerFilter filter = new FilePickerFilter("Text Files", "txt");

            options.WithFilter(filter);

            Assert.Single(options.Filters);
            Assert.Equal(filter, options.Filters[0]);
        }

        /// <summary>
        ///     Tests that WithFilter returns the options for fluent API.
        /// </summary>
        [Fact]
        public void WithFilter_ShouldReturnOptions()
        {
            FilePickerOptions options = new FilePickerOptions("Test");
            FilePickerFilter filter = new FilePickerFilter("Text Files", "txt");

            FilePickerOptions result = options.WithFilter(filter);

            Assert.Same(options, result);
        }

        /// <summary>
        ///     Tests that WithFilter throws with null filter.
        /// </summary>
        [Fact]
        public void WithFilter_WithNullFilter_ShouldThrowArgumentNullException()
        {
            FilePickerOptions options = new FilePickerOptions("Test");

            Assert.Throws<ArgumentNullException>(() => options.WithFilter(null));
        }

        /// <summary>
        ///     Tests that WithDefaultPath sets the default path.
        /// </summary>
        [Fact]
        public void WithDefaultPath_ShouldSetPath()
        {
            FilePickerOptions options = new FilePickerOptions("Test");
            string path = "/home/user";

            options.WithDefaultPath(path);

            Assert.Equal(path, options.DefaultPath);
        }

        /// <summary>
        ///     Tests that WithDefaultPath returns options for fluent API.
        /// </summary>
        [Fact]
        public void WithDefaultPath_ShouldReturnOptions()
        {
            FilePickerOptions options = new FilePickerOptions("Test");

            FilePickerOptions result = options.WithDefaultPath("/home/user");

            Assert.Same(options, result);
        }

        /// <summary>
        ///     Tests that WithMultipleSelection enables multiple selection.
        /// </summary>
        [Fact]
        public void WithMultipleSelection_ShouldEnableMultipleSelection()
        {
            FilePickerOptions options = new FilePickerOptions("Test");

            options.WithMultipleSelection();

            Assert.True(options.AllowMultiple);
        }

        /// <summary>
        ///     Tests that WithMultipleSelection returns options for fluent API.
        /// </summary>
        [Fact]
        public void WithMultipleSelection_ShouldReturnOptions()
        {
            FilePickerOptions options = new FilePickerOptions("Test");

            FilePickerOptions result = options.WithMultipleSelection();

            Assert.Same(options, result);
        }

        /// <summary>
        ///     Tests that IsDirectoryDialog returns true for SelectFolder dialog type.
        /// </summary>
        [Fact]
        public void IsDirectoryDialog_WithSelectFolderType_ShouldReturnTrue()
        {
            FilePickerOptions options = new FilePickerOptions("Select", FileDialogType.SelectFolder);

            bool result = options.IsDirectoryDialog();

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that IsDirectoryDialog returns false for OpenFile dialog type.
        /// </summary>
        [Fact]
        public void IsDirectoryDialog_WithOpenFileType_ShouldReturnFalse()
        {
            FilePickerOptions options = new FilePickerOptions("Select");

            bool result = options.IsDirectoryDialog();

            Assert.False(result);
        }

        /// <summary>
        ///     Tests fluent API chaining.
        /// </summary>
        [Fact]
        public void FluentApi_ShouldChainMethodsCalls()
        {
            FilePickerOptions options = new FilePickerOptions("Test")
                .WithDefaultPath("/home/user")
                .WithFilter(new FilePickerFilter("Text Files", "txt"))
                .WithMultipleSelection();

            Assert.Equal("/home/user", options.DefaultPath);
            Assert.Single(options.Filters);
            Assert.True(options.AllowMultiple);
        }
    }
}