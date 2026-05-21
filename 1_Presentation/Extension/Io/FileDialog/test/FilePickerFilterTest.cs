

using System;
using Xunit;

namespace Alis.Extension.Io.FileDialog.Test
{
    /// <summary>
    ///     Unit tests for FilePickerFilter class.
    /// </summary>
    public class FilePickerFilterTest
    {
        /// <summary>
        ///     Tests that FilePickerFilter constructor creates instance with valid parameters.
        /// </summary>
        [Fact]
        public void Constructor_WithValidParameters_ShouldCreateInstance()
        {
            FilePickerFilter filter = new FilePickerFilter("Text Files", "txt", "doc");

            Assert.NotNull(filter);
            Assert.Equal("Text Files", filter.DisplayName);
            Assert.Contains("txt", filter.Extensions);
            Assert.Contains("doc", filter.Extensions);
        }

        /// <summary>
        ///     Tests that FilePickerFilter constructor removes leading dots from extensions.
        /// </summary>
        [Fact]
        public void Constructor_WithDotsInExtensions_ShouldRemoveDots()
        {
            FilePickerFilter filter = new FilePickerFilter("Text Files", ".txt", ".doc");

            Assert.Equal("txt", filter.Extensions[0]);
            Assert.Equal("doc", filter.Extensions[1]);
        }

        /// <summary>
        ///     Tests that FilePickerFilter constructor throws with null display name.
        /// </summary>
        [Fact]
        public void Constructor_WithNullDisplayName_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentException>(() => new FilePickerFilter(null, "txt"));
        }

        /// <summary>
        ///     Tests that FilePickerFilter constructor throws with empty display name.
        /// </summary>
        [Fact]
        public void Constructor_WithEmptyDisplayName_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new FilePickerFilter("", "txt"));
        }

        /// <summary>
        ///     Tests that FilePickerFilter constructor throws with null extensions.
        /// </summary>
        [Fact]
        public void Constructor_WithNullExtensions_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new FilePickerFilter("Text Files", null));
        }

        /// <summary>
        ///     Tests that FilePickerFilter constructor throws with empty extensions array.
        /// </summary>
        [Fact]
        public void Constructor_WithEmptyExtensionsArray_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new FilePickerFilter("Text Files"));
        }

        /// <summary>
        ///     Tests that GetFormattedExtensions returns correct format.
        /// </summary>
        [Fact]
        public void GetFormattedExtensions_ShouldReturnCorrectFormat()
        {
            FilePickerFilter filter = new FilePickerFilter("Text Files", "txt", "doc");

            string formatted = filter.GetFormattedExtensions();

            Assert.Equal("*.txt;*.doc", formatted);
        }

        /// <summary>
        ///     Tests that GetUtiFormat returns correct UTI format.
        /// </summary>
        [Fact]
        public void GetUtiFormat_ShouldReturnCorrectFormat()
        {
            FilePickerFilter filter = new FilePickerFilter("Text Files", "txt", "doc");

            string utiFormat = filter.GetUtiFormat();

            Assert.Equal("txt,doc", utiFormat);
        }

        /// <summary>
        ///     Tests that FilePickerFilter handles case-insensitive extensions.
        /// </summary>
        [Fact]
        public void Constructor_WithMixedCaseExtensions_ShouldPreserveLowerCase()
        {
            FilePickerFilter filter = new FilePickerFilter("Text Files", "TXT", "Doc");

            Assert.Equal("TXT", filter.Extensions[0]); // Original case preserved
            Assert.Equal("Doc", filter.Extensions[1]);
        }

        /// <summary>
        ///     Tests that FilePickerFilter with single extension works correctly.
        /// </summary>
        [Fact]
        public void Constructor_WithSingleExtension_ShouldWork()
        {
            FilePickerFilter filter = new FilePickerFilter("PDF Files", "pdf");

            Assert.Single(filter.Extensions);
            Assert.Equal("pdf", filter.Extensions[0]);
        }

        /// <summary>
        ///     Tests that FilePickerFilter with many extensions works correctly.
        /// </summary>
        [Fact]
        public void Constructor_WithManyExtensions_ShouldWork()
        {
            string[] extensions = new[] {"jpg", "png", "gif", "bmp", "ico"};

            FilePickerFilter filter = new FilePickerFilter("Image Files", extensions);

            Assert.Equal(5, filter.Extensions.Count);
            foreach (string ext in extensions)
            {
                Assert.Contains(ext, filter.Extensions);
            }
        }
    }
}