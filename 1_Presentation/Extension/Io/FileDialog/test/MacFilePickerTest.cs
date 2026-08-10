using System;
using Alis.Extension.Io.FileDialog.Test.Attributes;
using Xunit;

namespace Alis.Extension.Io.FileDialog.Test
{
    /// <summary>
    /// The mac file picker test class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class MacFilePickerTest : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MacFilePickerTest"/> class
        /// </summary>
        public MacFilePickerTest()
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
        /// Tests that escape apple script null returns null
        /// </summary>
        [Fact]
        public void EscapeAppleScript_Null_ReturnsNull()
        {
            Assert.Null(MacFilePicker.EscapeAppleScript(null));
        }

        /// <summary>
        /// Tests that escape apple script empty returns empty
        /// </summary>
        [Fact]
        public void EscapeAppleScript_Empty_ReturnsEmpty()
        {
            Assert.Equal(string.Empty, MacFilePicker.EscapeAppleScript(string.Empty));
        }

        /// <summary>
        /// Tests that escape apple script with backslash returns escaped
        /// </summary>
        [Fact]
        public void EscapeAppleScript_WithBackslash_ReturnsEscaped()
        {
            string result = MacFilePicker.EscapeAppleScript("path\\to");
            Assert.Equal("path\\\\to", result);
        }

        /// <summary>
        /// Tests that escape apple script with double quote returns escaped
        /// </summary>
        [Fact]
        public void EscapeAppleScript_WithDoubleQuote_ReturnsEscaped()
        {
            string result = MacFilePicker.EscapeAppleScript("say \"hello\"");
            Assert.Equal("say \\\"hello\\\"", result);
        }

        /// <summary>
        /// Tests that escape apple script without special chars returns same
        /// </summary>
        [Fact]
        public void EscapeAppleScript_WithoutSpecialChars_ReturnsSame()
        {
            string result = MacFilePicker.EscapeAppleScript("hello");
            Assert.Equal("hello", result);
        }

        /// <summary>
        /// Tests that build open file script without multiple contains correct parts
        /// </summary>
        [Fact]
        public void BuildOpenFileScript_WithoutMultiple_ContainsCorrectParts()
        {
            FilePickerOptions options = new FilePickerOptions("Open File")
            {
                DefaultPath = "/Users/test"
            };

            string script = MacFilePicker.BuildOpenFileScript(options, false);

            Assert.Contains("choose file", script);
            Assert.Contains("with prompt \"Open File\"", script);
            Assert.Contains("default location POSIX file \"/Users/test\"", script);
            Assert.DoesNotContain("multiple selections allowed true", script);
            Assert.Contains("POSIX path of selectedItem", script);
        }

        /// <summary>
        /// Tests that build open file script with multiple contains multiple allowed
        /// </summary>
        [Fact]
        public void BuildOpenFileScript_WithMultiple_ContainsMultipleAllowed()
        {
            FilePickerOptions options = new FilePickerOptions("Open Files");

            string script = MacFilePicker.BuildOpenFileScript(options, true);

            Assert.Contains("multiple selections allowed true", script);
            Assert.Contains("choose file", script);
        }

        /// <summary>
        /// Tests that build open file script without title omits prompt
        /// </summary>
        [Fact]
        public void BuildOpenFileScript_WithoutTitle_OmitsPrompt()
        {
            FilePickerOptions options = new FilePickerOptions { Title = null };

            string script = MacFilePicker.BuildOpenFileScript(options, false);

            Assert.DoesNotContain("with prompt", script);
            Assert.Contains("choose file", script);
        }

        /// <summary>
        /// Tests that build open file script without default path omits location
        /// </summary>
        [Fact]
        public void BuildOpenFileScript_WithoutDefaultPath_OmitsLocation()
        {
            FilePickerOptions options = new FilePickerOptions("Test");

            string script = MacFilePicker.BuildOpenFileScript(options, false);

            Assert.DoesNotContain("default location", script);
        }

        /// <summary>
        /// Tests that build folder select script with all options contains correct parts
        /// </summary>
        [Fact]
        public void BuildFolderSelectScript_WithAllOptions_ContainsCorrectParts()
        {
            FilePickerOptions options = new FilePickerOptions("Select Folder")
            {
                DefaultPath = "/Users/test"
            };

            string script = MacFilePicker.BuildFolderSelectScript(options);

            Assert.Contains("choose folder", script);
            Assert.Contains("with prompt \"Select Folder\"", script);
            Assert.Contains("default location POSIX file \"/Users/test\"", script);
            Assert.Contains("POSIX path of selectedFolder", script);
        }

        /// <summary>
        /// Tests that build folder select script without title omits prompt
        /// </summary>
        [Fact]
        public void BuildFolderSelectScript_WithoutTitle_OmitsPrompt()
        {
            FilePickerOptions options = new FilePickerOptions { Title = null };

            string script = MacFilePicker.BuildFolderSelectScript(options);

            Assert.DoesNotContain("with prompt", script);
            Assert.Contains("choose folder", script);
        }

        /// <summary>
        /// Tests that build folder select script without default path omits location
        /// </summary>
        [Fact]
        public void BuildFolderSelectScript_WithoutDefaultPath_OmitsLocation()
        {
            FilePickerOptions options = new FilePickerOptions("Select");

            string script = MacFilePicker.BuildFolderSelectScript(options);

            Assert.DoesNotContain("default location", script);
        }

        /// <summary>
        /// Tests that execute apple script with simple script returns output
        /// </summary>
        [OSXOnly]
        public void ExecuteAppleScript_WithSimpleScript_ReturnsOutput()
        {
            string script = "on run\n  return \"hello\"\nend run";

            string result = MacFilePicker.ExecuteAppleScript(script);

            Assert.NotNull(result);
            Assert.Contains("hello", result);
        }

        /// <summary>
        /// Tests that parse result null returns cancelled
        /// </summary>
        [Fact]
        public void ParseResult_Null_ReturnsCancelled()
        {
            FilePickerResult result = MacFilePicker.ParseResult(null);

            Assert.True(result.IsCancelled);
        }

        /// <summary>
        /// Tests that parse result empty returns cancelled
        /// </summary>
        [Fact]
        public void ParseResult_Empty_ReturnsCancelled()
        {
            FilePickerResult result = MacFilePicker.ParseResult(string.Empty);

            Assert.True(result.IsCancelled);
        }

        /// <summary>
        /// Tests that parse result whitespace returns cancelled
        /// </summary>
        [Fact]
        public void ParseResult_Whitespace_ReturnsCancelled()
        {
            FilePickerResult result = MacFilePicker.ParseResult("   ");

            Assert.True(result.IsCancelled);
        }

        /// <summary>
        /// Tests that parse result single path returns success
        /// </summary>
        [Fact]
        public void ParseResult_SinglePath_ReturnsSuccess()
        {
            FilePickerResult result = MacFilePicker.ParseResult("/Users/test/file.txt");

            Assert.True(result.IsSuccess);
            Assert.Single(result.SelectedPaths);
        }

        /// <summary>
        /// Tests that parse result multiple paths returns multiple
        /// </summary>
        [Fact]
        public void ParseResult_MultiplePaths_ReturnsMultiple()
        {
            FilePickerResult result = MacFilePicker.ParseResult("/Users/test/a.txt\n/Users/test/b.txt");

            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.SelectedPaths.Count);
        }

        /// <summary>
        /// Tests that parse result empty lines returns cancelled
        /// </summary>
        [Fact]
        public void ParseResult_EmptyLines_ReturnsCancelled()
        {
            FilePickerResult result = MacFilePicker.ParseResult("\n\n");

            Assert.True(result.IsCancelled);
        }

        /// <summary>
        /// Tests that pick file with null options returns error
        /// </summary>
        [Fact]
        public void PickFile_NullOptions_ReturnsError()
        {
            MacFilePicker picker = new MacFilePicker();

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
            MacFilePicker picker = new MacFilePicker();

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
            MacFilePicker picker = new MacFilePicker();

            FilePickerResult result = picker.PickFolder(null);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
            Assert.Contains("Options cannot be null.", result.ErrorMessage);
        }

        /// <summary>
        /// Tests that pick file with mocked execution returns success
        /// </summary>
        [Fact]
        public void PickFile_WithMockedExecution_ReturnsSuccess()
        {
            FilePickerExecutor.ExecuteCommandOverride = (file, args, timeout) => "/Users/mock/file.txt";

            MacFilePicker picker = new MacFilePicker();
            FilePickerOptions options = new FilePickerOptions("Test File");

            FilePickerResult result = picker.PickFile(options);

            Assert.True(result.IsSuccess);
            Assert.Contains("/Users/mock/file.txt", result.SelectedPaths);
        }

        /// <summary>
        /// Tests that pick files with mocked execution returns success
        /// </summary>
        [Fact]
        public void PickFiles_WithMockedExecution_ReturnsSuccess()
        {
            FilePickerExecutor.ExecuteCommandOverride = (file, args, timeout) => "/Users/mock/a.txt\n/Users/mock/b.txt";

            MacFilePicker picker = new MacFilePicker();
            FilePickerOptions options = new FilePickerOptions("Test Files");

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
            FilePickerExecutor.ExecuteCommandOverride = (file, args, timeout) => "/Users/mock/folder";

            MacFilePicker picker = new MacFilePicker();
            FilePickerOptions options = new FilePickerOptions("Test Folder");

            FilePickerResult result = picker.PickFolder(options);

            Assert.True(result.IsSuccess);
            Assert.Contains("/Users/mock/folder", result.SelectedPaths);
        }

        /// <summary>
        /// Tests that pick file when execute apple script throws returns error
        /// </summary>
        /// <exception cref="InvalidOperationException">Simulated failure</exception>
        [Fact]
        public void PickFile_WhenExecuteAppleScriptThrows_ReturnsError()
        {
            FilePickerExecutor.ExecuteCommandOverride = (file, args, timeout) => throw new InvalidOperationException("Simulated failure");

            MacFilePicker picker = new MacFilePicker();
            FilePickerOptions options = new FilePickerOptions("Test File");

            FilePickerResult result = picker.PickFile(options);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

        /// <summary>
        /// Tests that pick files when execute apple script throws returns error
        /// </summary>
        /// <exception cref="InvalidOperationException">Simulated failure</exception>
        [Fact]
        public void PickFiles_WhenExecuteAppleScriptThrows_ReturnsError()
        {
            FilePickerExecutor.ExecuteCommandOverride = (file, args, timeout) => throw new InvalidOperationException("Simulated failure");

            MacFilePicker picker = new MacFilePicker();
            FilePickerOptions options = new FilePickerOptions("Test Files");

            FilePickerResult result = picker.PickFiles(options);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

        /// <summary>
        /// Tests that pick folder when execute apple script throws returns error
        /// </summary>
        /// <exception cref="InvalidOperationException">Simulated failure</exception>
        [Fact]
        public void PickFolder_WhenExecuteAppleScriptThrows_ReturnsError()
        {
            FilePickerExecutor.ExecuteCommandOverride = (file, args, timeout) => throw new InvalidOperationException("Simulated failure");

            MacFilePicker picker = new MacFilePicker();
            FilePickerOptions options = new FilePickerOptions("Test Folder");

            FilePickerResult result = picker.PickFolder(options);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

    }
}
