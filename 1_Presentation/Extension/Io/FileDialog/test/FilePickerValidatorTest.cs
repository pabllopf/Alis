

using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Alis.Extension.Io.FileDialog.Test
{
    /// <summary>
    ///     Unit tests for FilePickerValidator static class.
    /// </summary>
    public class FilePickerValidatorTest
    {
        /// <summary>
        ///     Tests that ValidateOptions throws with null options.
        /// </summary>
        [Fact]
        public void ValidateOptions_WithNull_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => FilePickerValidator.ValidateOptions(null));
        }

        /// <summary>
        ///     Tests that ValidateOptions throws with null title.
        /// </summary>
        [Fact]
        public void ValidateOptions_WithNullTitle_ShouldThrowArgumentException()
        {
            FilePickerOptions options = new FilePickerOptions {Title = null};

            Assert.Throws<ArgumentException>(() => FilePickerValidator.ValidateOptions(options));
        }

        /// <summary>
        ///     Tests that ValidateOptions throws with empty title.
        /// </summary>
        [Fact]
        public void ValidateOptions_WithEmptyTitle_ShouldThrowArgumentException()
        {
            FilePickerOptions options = new FilePickerOptions {Title = ""};

            Assert.Throws<ArgumentException>(() => FilePickerValidator.ValidateOptions(options));
        }

        /// <summary>
        ///     Tests that ValidateOptions throws with invalid default path.
        /// </summary>
        [Fact]
        public void ValidateOptions_WithInvalidDefaultPath_ShouldThrowArgumentException()
        {
            FilePickerOptions options = new FilePickerOptions("Test") {DefaultPath = "/nonexistent/path/that/does/not/exist"};

            Assert.Throws<ArgumentException>(() => FilePickerValidator.ValidateOptions(options));
        }

        /// <summary>
        ///     Tests that ValidateOptions throws when SaveFile allows multiple.
        /// </summary>
        [Fact]
        public void ValidateOptions_WithSaveFileMultiple_ShouldThrowArgumentException()
        {
            FilePickerOptions options = new FilePickerOptions("Save", FileDialogType.SaveFile)
            {
                AllowMultiple = true
            };

            Assert.Throws<ArgumentException>(() => FilePickerValidator.ValidateOptions(options));
        }

        /// <summary>
        ///     Tests that ValidateOptions throws when AllowDirectories is true for non-SelectFolder.
        /// </summary>
        [Fact]
        public void ValidateOptions_WithAllowDirectoriesOnOpenFile_ShouldThrowArgumentException()
        {
            FilePickerOptions options = new FilePickerOptions("Open")
            {
                AllowDirectories = true
            };

            Assert.Throws<ArgumentException>(() => FilePickerValidator.ValidateOptions(options));
        }

        /// <summary>
        ///     Tests that ValidateOptions passes with valid options.
        /// </summary>
        [Fact]
        public void ValidateOptions_WithValidOptions_ShouldNotThrow()
        {
            FilePickerOptions options = new FilePickerOptions("Open File");

            FilePickerValidator.ValidateOptions(options);
        }

        /// <summary>
        ///     Tests that IsValidFilePath returns false for null path.
        /// </summary>
        [Fact]
        public void IsValidFilePath_WithNull_ShouldReturnFalse()
        {
            bool result = FilePickerValidator.IsValidFilePath(null);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsValidFilePath returns false for nonexistent file.
        /// </summary>
        [Fact]
        public void IsValidFilePath_WithNonexistentFile_ShouldReturnFalse()
        {
            bool result = FilePickerValidator.IsValidFilePath("/nonexistent/file/path.txt");

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsValidFilePath returns true for existing file.
        /// </summary>
        [Fact]
        public void IsValidFilePath_WithExistingFile_ShouldReturnTrue()
        {
            string tempFile = Path.GetTempFileName();

            try
            {
                bool result = FilePickerValidator.IsValidFilePath(tempFile);

                Assert.True(result);
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        /// <summary>
        ///     Tests that IsValidDirectoryPath returns false for null path.
        /// </summary>
        [Fact]
        public void IsValidDirectoryPath_WithNull_ShouldReturnFalse()
        {
            bool result = FilePickerValidator.IsValidDirectoryPath(null);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsValidDirectoryPath returns false for nonexistent directory.
        /// </summary>
        [Fact]
        public void IsValidDirectoryPath_WithNonexistentDirectory_ShouldReturnFalse()
        {
            bool result = FilePickerValidator.IsValidDirectoryPath("/nonexistent/directory/path");

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsValidDirectoryPath returns true for existing directory.
        /// </summary>
        [Fact]
        public void IsValidDirectoryPath_WithExistingDirectory_ShouldReturnTrue()
        {
            string tempDir = Path.GetTempPath();

            bool result = FilePickerValidator.IsValidDirectoryPath(tempDir);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that IsFileExtensionAllowed returns true when no filters specified.
        /// </summary>
        [Fact]
        public void IsFileExtensionAllowed_WithNoFilters_ShouldReturnTrue()
        {
            FilePickerOptions options = new FilePickerOptions("Test");

            bool result = FilePickerValidator.IsFileExtensionAllowed("/path/file.txt", options);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that IsFileExtensionAllowed returns true for allowed extension.
        /// </summary>
        [Fact]
        public void IsFileExtensionAllowed_WithAllowedExtension_ShouldReturnTrue()
        {
            FilePickerOptions options = new FilePickerOptions("Test");
            options.WithFilter(new FilePickerFilter("Text Files", "txt", "doc"));

            bool result = FilePickerValidator.IsFileExtensionAllowed("/path/file.txt", options);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that IsFileExtensionAllowed returns false for disallowed extension.
        /// </summary>
        [Fact]
        public void IsFileExtensionAllowed_WithDisallowedExtension_ShouldReturnFalse()
        {
            FilePickerOptions options = new FilePickerOptions("Test");
            options.WithFilter(new FilePickerFilter("Text Files", "txt", "doc"));

            bool result = FilePickerValidator.IsFileExtensionAllowed("/path/file.pdf", options);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsFileExtensionAllowed is case-insensitive.
        /// </summary>
        [Fact]
        public void IsFileExtensionAllowed_IsCaseInsensitive_ShouldReturnTrue()
        {
            FilePickerOptions options = new FilePickerOptions("Test");
            options.WithFilter(new FilePickerFilter("Text Files", "txt"));

            bool result = FilePickerValidator.IsFileExtensionAllowed("/path/file.TXT", options);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that IsResultValid returns true for successful result.
        /// </summary>
        [Fact]
        public void IsResultValid_WithSuccessfulResult_ShouldReturnTrue()
        {
            FilePickerOptions options = new FilePickerOptions("Test");
            string tempFile = Path.GetTempFileName();

            try
            {
                FilePickerResult result = new FilePickerResult(tempFile);

                bool isValid = FilePickerValidator.IsResultValid(result, options);

                Assert.True(isValid);
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        /// <summary>
        ///     Tests that IsResultValid returns true for cancelled result.
        /// </summary>
        [Fact]
        public void IsResultValid_WithCancelledResult_ShouldReturnTrue()
        {
            FilePickerOptions options = new FilePickerOptions("Test");
            FilePickerResult result = FilePickerResult.CreateCancelled();

            bool isValid = FilePickerValidator.IsResultValid(result, options);

            Assert.True(isValid);
        }

        /// <summary>
        ///     Tests that IsResultValid returns false for result with multiple paths when not allowed.
        /// </summary>
        [Fact]
        public void IsResultValid_WithMultiplePathsNotAllowed_ShouldReturnFalse()
        {
            FilePickerOptions options = new FilePickerOptions("Test");
            FilePickerResult result = new FilePickerResult(new List<string> {"/path/one.txt", "/path/two.txt"});

            bool isValid = FilePickerValidator.IsResultValid(result, options);

            Assert.False(isValid);
        }
    }
}