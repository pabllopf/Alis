using System;
using System.Collections.Generic;
using Xunit;

namespace Alis.Extension.Io.FileDialog.Test
{
    /// <summary>
    /// The windows file picker test class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class WindowsFilePickerTest : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowsFilePickerTest"/> class
        /// </summary>
        public WindowsFilePickerTest()
        {
            FilePickerExecutor.CommandExistsOverride = null;
            FilePickerExecutor.ExecuteCommandOverride = null;
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            FilePickerExecutor.CommandExistsOverride = null;
            FilePickerExecutor.ExecuteCommandOverride = null;
        }
        /// <summary>
        /// Tests that escape script string null returns null
        /// </summary>
        [Fact]
        public void EscapeScriptString_Null_ReturnsNull()
        {
            Assert.Null(WindowsFilePicker.EscapeScriptString(null));
        }

        /// <summary>
        /// Tests that escape script string empty returns empty
        /// </summary>
        [Fact]
        public void EscapeScriptString_Empty_ReturnsEmpty()
        {
            Assert.Equal(string.Empty, WindowsFilePicker.EscapeScriptString(string.Empty));
        }

        /// <summary>
        /// Tests that escape script string with single quote returns escaped
        /// </summary>
        [Fact]
        public void EscapeScriptString_WithSingleQuote_ReturnsEscaped()
        {
            string result = WindowsFilePicker.EscapeScriptString("it's");
            Assert.Equal("it''s", result);
        }

        /// <summary>
        /// Tests that escape script string with double quote returns escaped
        /// </summary>
        [Fact]
        public void EscapeScriptString_WithDoubleQuote_ReturnsEscaped()
        {
            string result = WindowsFilePicker.EscapeScriptString("say \"hi\"");
            Assert.Equal("say `\"hi`\"", result);
        }

        /// <summary>
        /// Tests that escape script string with dollar sign returns escaped
        /// </summary>
        [Fact]
        public void EscapeScriptString_WithDollarSign_ReturnsEscaped()
        {
            string result = WindowsFilePicker.EscapeScriptString("$var");
            Assert.Equal("`$var", result);
        }

        /// <summary>
        /// Tests that escape script string without special chars returns same
        /// </summary>
        [Fact]
        public void EscapeScriptString_WithoutSpecialChars_ReturnsSame()
        {
            string result = WindowsFilePicker.EscapeScriptString("hello.txt");
            Assert.Equal("hello.txt", result);
        }

        /// <summary>
        /// Tests that build filter string with null returns all files
        /// </summary>
        [Fact]
        public void BuildFilterString_WithNull_ReturnsAllFiles()
        {
            string result = WindowsFilePicker.BuildFilterString(null);

            Assert.Equal("All files (*.*)|*.*", result);
        }

        /// <summary>
        /// Tests that build filter string with empty list returns all files
        /// </summary>
        [Fact]
        public void BuildFilterString_WithEmptyList_ReturnsAllFiles()
        {
            string result = WindowsFilePicker.BuildFilterString(new List<FilePickerFilter>());

            Assert.Equal("All files (*.*)|*.*", result);
        }

        /// <summary>
        /// Tests that build filter string with filters returns formatted
        /// </summary>
        [Fact]
        public void BuildFilterString_WithFilters_ReturnsFormatted()
        {
            var filters = new List<FilePickerFilter>
            {
                new("Text files", ".txt"),
                new("Images", ".png")
            };

            string result = WindowsFilePicker.BuildFilterString(filters);

            Assert.Contains("Text files|*.txt", result);
            Assert.Contains("Images|*.png", result);
            Assert.EndsWith("|All files (*.*)|*.*", result);
        }

        /// <summary>
        /// Tests that build open file script with all options contains correct parts
        /// </summary>
        [Fact]
        public void BuildOpenFileScript_WithAllOptions_ContainsCorrectParts()
        {
            var options = new FilePickerOptions("Open File")
            {
                DefaultPath = @"C:\Users\test",
                Filters = new List<FilePickerFilter> { new("Text files", ".txt") },
                AllowMultiple = true
            };

            string script = WindowsFilePicker.BuildOpenFileScript(options);

            Assert.Contains("OpenFileDialog", script);
            Assert.Contains("$dialog.Title = 'Open File'", script);
            Assert.Contains("$dialog.InitialDirectory", script);
            Assert.Contains("$dialog.Filter", script);
            Assert.Contains("$dialog.Multiselect = $true", script);
        }

        /// <summary>
        /// Tests that build open file script without default path omits initial directory
        /// </summary>
        [Fact]
        public void BuildOpenFileScript_WithoutDefaultPath_OmitsInitialDirectory()
        {
            var options = new FilePickerOptions("Open File");

            string script = WindowsFilePicker.BuildOpenFileScript(options);

            Assert.DoesNotContain("InitialDirectory", script);
        }

        /// <summary>
        /// Tests that build open file script without filters omits filter
        /// </summary>
        [Fact]
        public void BuildOpenFileScript_WithoutFilters_OmitsFilter()
        {
            var options = new FilePickerOptions("Open File")
            {
                DefaultPath = @"C:\test"
            };

            string script = WindowsFilePicker.BuildOpenFileScript(options);

            Assert.DoesNotContain("$dialog.Filter", script);
        }

        /// <summary>
        /// Tests that build open file script without multiple omits multiselect
        /// </summary>
        [Fact]
        public void BuildOpenFileScript_WithoutMultiple_OmitsMultiselect()
        {
            var options = new FilePickerOptions("Open File")
            {
                DefaultPath = @"C:\test"
            };

            string script = WindowsFilePicker.BuildOpenFileScript(options);

            Assert.DoesNotContain("Multiselect", script);
        }

        /// <summary>
        /// Tests that build folder select script with all options contains correct parts
        /// </summary>
        [Fact]
        public void BuildFolderSelectScript_WithAllOptions_ContainsCorrectParts()
        {
            var options = new FilePickerOptions("Select Folder")
            {
                DefaultPath = @"C:\Users"
            };

            string script = WindowsFilePicker.BuildFolderSelectScript(options);

            Assert.Contains("FolderBrowserDialog", script);
            Assert.Contains("$dialog.Description = 'Select Folder'", script);
            Assert.Contains("$dialog.SelectedPath", script);
        }

        /// <summary>
        /// Tests that build folder select script without default path omits selected path
        /// </summary>
        [Fact]
        public void BuildFolderSelectScript_WithoutDefaultPath_OmitsSelectedPathAssignment()
        {
            var options = new FilePickerOptions("Select Folder");

            string script = WindowsFilePicker.BuildFolderSelectScript(options);

            Assert.DoesNotContain("$dialog.SelectedPath = ", script);
        }

        /// <summary>
        /// Tests that parse result null returns cancelled
        /// </summary>
        [Fact]
        public void ParseResult_Null_ReturnsCancelled()
        {
            FilePickerResult result = WindowsFilePicker.ParseResult(null, false);

            Assert.True(result.IsCancelled);
        }

        /// <summary>
        /// Tests that parse result empty returns cancelled
        /// </summary>
        [Fact]
        public void ParseResult_Empty_ReturnsCancelled()
        {
            FilePickerResult result = WindowsFilePicker.ParseResult(string.Empty, false);

            Assert.True(result.IsCancelled);
        }

        /// <summary>
        /// Tests that parse result whitespace returns cancelled
        /// </summary>
        [Fact]
        public void ParseResult_Whitespace_ReturnsCancelled()
        {
            FilePickerResult result = WindowsFilePicker.ParseResult("   ", false);

            Assert.True(result.IsCancelled);
        }

        /// <summary>
        /// Tests that parse result single path returns success
        /// </summary>
        [Fact]
        public void ParseResult_SinglePath_ReturnsSuccess()
        {
            FilePickerResult result = WindowsFilePicker.ParseResult(@"C:\Users\file.txt", false);

            Assert.True(result.IsSuccess);
            Assert.Single(result.SelectedPaths);
        }

        /// <summary>
        /// Tests that parse result multiple paths with allow multiple returns multiple
        /// </summary>
        [Fact]
        public void ParseResult_MultiplePaths_WithAllowMultiple_ReturnsMultiple()
        {
            FilePickerResult result = WindowsFilePicker.ParseResult(@"C:\a.txt
C:\b.txt", true);

            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.SelectedPaths.Count);
        }

        /// <summary>
        /// Tests that parse result multiple paths without allow multiple returns single
        /// </summary>
        [Fact]
        public void ParseResult_MultiplePaths_WithoutAllowMultiple_ReturnsSingle()
        {
            FilePickerResult result = WindowsFilePicker.ParseResult(@"C:\a.txt
C:\b.txt", false);

            Assert.True(result.IsSuccess);
            Assert.Single(result.SelectedPaths);
        }

        /// <summary>
        /// Tests that parse result empty paths returns cancelled
        /// </summary>
        [Fact]
        public void ParseResult_EmptyPaths_ReturnsCancelled()
        {
            FilePickerResult result = WindowsFilePicker.ParseResult("\n", true);

            Assert.True(result.IsCancelled);
        }

        /// <summary>
        /// Tests that pick file with valid options returns error
        /// </summary>
        [Fact]
        public void PickFile_WithValidOptions_ReturnsError()
        {
            var picker = new WindowsFilePicker();
            var options = new FilePickerOptions("Test File");

            FilePickerResult result = picker.PickFile(options);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

        /// <summary>
        /// Tests that pick files with valid options returns error
        /// </summary>
        [Fact]
        public void PickFiles_WithValidOptions_ReturnsError()
        {
            var picker = new WindowsFilePicker();
            var options = new FilePickerOptions("Test Files");

            FilePickerResult result = picker.PickFiles(options);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

        /// <summary>
        /// Tests that pick folder with valid options returns error
        /// </summary>
        [Fact]
        public void PickFolder_WithValidOptions_ReturnsError()
        {
            var picker = new WindowsFilePicker();
            var options = new FilePickerOptions("Test Folder");

            FilePickerResult result = picker.PickFolder(options);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

        /// <summary>
        /// Tests that pick file with mocked execution returns success
        /// </summary>
        [Fact]
        public void PickFile_WithMockedExecution_ReturnsSuccess()
        {
            FilePickerExecutor.ExecuteCommandOverride = (file, args, timeout) => @"C:\mock\file.txt";

            var picker = new WindowsFilePicker();
            var options = new FilePickerOptions("Test File");

            FilePickerResult result = picker.PickFile(options);

            Assert.True(result.IsSuccess);
            Assert.Contains(@"C:\mock\file.txt", result.SelectedPaths);
        }

        /// <summary>
        /// Tests that pick files with mocked execution returns success
        /// </summary>
        [Fact]
        public void PickFiles_WithMockedExecution_ReturnsSuccess()
        {
            FilePickerExecutor.ExecuteCommandOverride = (file, args, timeout) => @"C:\mock\a.txt
C:\mock\b.txt";

            var picker = new WindowsFilePicker();
            var options = new FilePickerOptions("Test Files");

            FilePickerResult result = picker.PickFiles(options);

            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.SelectedPaths.Count);
        }

        /// <summary>
        /// Tests that pick folder with mocked execution returns success
        /// </summary>
        [Fact]
        public void PickFolder_WithMockedExecution_ReturnsSuccess()
        {
            FilePickerExecutor.ExecuteCommandOverride = (file, args, timeout) => @"C:\mock\folder";

            var picker = new WindowsFilePicker();
            var options = new FilePickerOptions("Test Folder");

            FilePickerResult result = picker.PickFolder(options);

            Assert.True(result.IsSuccess);
            Assert.Contains(@"C:\mock\folder", result.SelectedPaths);
        }

        /// <summary>
        /// Tests that pick file when execute script throws returns error
        /// </summary>
        /// <exception cref="InvalidOperationException">Simulated failure</exception>
        [Fact]
        public void PickFile_WhenExecuteScriptThrows_ReturnsError()
        {
            FilePickerExecutor.ExecuteCommandOverride = (file, args, timeout) => throw new InvalidOperationException("Simulated failure");

            var picker = new WindowsFilePicker();
            var options = new FilePickerOptions("Test File");

            FilePickerResult result = picker.PickFile(options);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

        /// <summary>
        /// Tests that pick files when execute script throws returns error
        /// </summary>
        /// <exception cref="InvalidOperationException">Simulated failure</exception>
        [Fact]
        public void PickFiles_WhenExecuteScriptThrows_ReturnsError()
        {
            FilePickerExecutor.ExecuteCommandOverride = (file, args, timeout) => throw new InvalidOperationException("Simulated failure");

            var picker = new WindowsFilePicker();
            var options = new FilePickerOptions("Test Files");

            FilePickerResult result = picker.PickFiles(options);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

        /// <summary>
        /// Tests that pick folder when execute script throws returns error
        /// </summary>
        /// <exception cref="InvalidOperationException">Simulated failure</exception>
        [Fact]
        public void PickFolder_WhenExecuteScriptThrows_ReturnsError()
        {
            FilePickerExecutor.ExecuteCommandOverride = (file, args, timeout) => throw new InvalidOperationException("Simulated failure");

            var picker = new WindowsFilePicker();
            var options = new FilePickerOptions("Test Folder");

            FilePickerResult result = picker.PickFolder(options);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

        /// <summary>
        /// Tests that pick file with null options returns error
        /// </summary>
        [Fact]
        public void PickFile_NullOptions_ReturnsError()
        {
            var picker = new WindowsFilePicker();

            FilePickerResult result = picker.PickFile(null);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
            Assert.Contains("Options cannot be null.", result.ErrorMessage);
        }

        /// <summary>
        /// Tests that pick files with null options returns error
        /// </summary>
        [Fact]
        public void PickFiles_NullOptions_ReturnsError()
        {
            var picker = new WindowsFilePicker();

            FilePickerResult result = picker.PickFiles(null);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
            Assert.Contains("Options cannot be null.", result.ErrorMessage);
        }

        /// <summary>
        /// Tests that pick folder with null options returns error
        /// </summary>
        [Fact]
        public void PickFolder_NullOptions_ReturnsError()
        {
            var picker = new WindowsFilePicker();

            FilePickerResult result = picker.PickFolder(null);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
            Assert.Contains("Options cannot be null.", result.ErrorMessage);
        }

    }
}
