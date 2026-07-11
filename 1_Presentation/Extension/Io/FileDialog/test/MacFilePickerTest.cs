using Xunit;

namespace Alis.Extension.Io.FileDialog.Test
{
    public class MacFilePickerTest
    {
        [Fact]
        public void EscapeAppleScript_Null_ReturnsNull()
        {
            Assert.Null(MacFilePicker.EscapeAppleScript(null));
        }

        [Fact]
        public void EscapeAppleScript_Empty_ReturnsEmpty()
        {
            Assert.Equal(string.Empty, MacFilePicker.EscapeAppleScript(string.Empty));
        }

        [Fact]
        public void EscapeAppleScript_WithBackslash_ReturnsEscaped()
        {
            string result = MacFilePicker.EscapeAppleScript("path\\to");
            Assert.Equal("path\\\\to", result);
        }

        [Fact]
        public void EscapeAppleScript_WithDoubleQuote_ReturnsEscaped()
        {
            string result = MacFilePicker.EscapeAppleScript("say \"hello\"");
            Assert.Equal("say \\\"hello\\\"", result);
        }

        [Fact]
        public void EscapeAppleScript_WithoutSpecialChars_ReturnsSame()
        {
            string result = MacFilePicker.EscapeAppleScript("hello");
            Assert.Equal("hello", result);
        }

        [Fact]
        public void BuildOpenFileScript_WithoutMultiple_ContainsCorrectParts()
        {
            var options = new FilePickerOptions("Open File")
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

        [Fact]
        public void BuildOpenFileScript_WithMultiple_ContainsMultipleAllowed()
        {
            var options = new FilePickerOptions("Open Files");

            string script = MacFilePicker.BuildOpenFileScript(options, true);

            Assert.Contains("multiple selections allowed true", script);
            Assert.Contains("choose file", script);
        }

        [Fact]
        public void BuildOpenFileScript_WithoutTitle_OmitsPrompt()
        {
            var options = new FilePickerOptions();

            string script = MacFilePicker.BuildOpenFileScript(options, false);

            Assert.DoesNotContain("with prompt", script);
            Assert.Contains("choose file", script);
        }

        [Fact]
        public void BuildOpenFileScript_WithoutDefaultPath_OmitsLocation()
        {
            var options = new FilePickerOptions("Test");

            string script = MacFilePicker.BuildOpenFileScript(options, false);

            Assert.DoesNotContain("default location", script);
        }

        [Fact]
        public void BuildFolderSelectScript_WithAllOptions_ContainsCorrectParts()
        {
            var options = new FilePickerOptions("Select Folder")
            {
                DefaultPath = "/Users/test"
            };

            string script = MacFilePicker.BuildFolderSelectScript(options);

            Assert.Contains("choose folder", script);
            Assert.Contains("with prompt \"Select Folder\"", script);
            Assert.Contains("default location POSIX file \"/Users/test\"", script);
            Assert.Contains("POSIX path of selectedFolder", script);
        }

        [Fact]
        public void BuildFolderSelectScript_WithoutTitle_OmitsPrompt()
        {
            var options = new FilePickerOptions();

            string script = MacFilePicker.BuildFolderSelectScript(options);

            Assert.DoesNotContain("with prompt", script);
            Assert.Contains("choose folder", script);
        }

        [Fact]
        public void BuildFolderSelectScript_WithoutDefaultPath_OmitsLocation()
        {
            var options = new FilePickerOptions("Select");

            string script = MacFilePicker.BuildFolderSelectScript(options);

            Assert.DoesNotContain("default location", script);
        }

        [Fact]
        public void ExecuteAppleScript_WithSimpleScript_ReturnsOutput()
        {
            string script = "on run\n  return \"hello\"\nend run";

            string result = MacFilePicker.ExecuteAppleScript(script);

            Assert.NotNull(result);
            Assert.Contains("hello", result);
        }

        [Fact]
        public void ParseResult_Null_ReturnsCancelled()
        {
            FilePickerResult result = MacFilePicker.ParseResult(null);

            Assert.True(result.IsCancelled);
        }

        [Fact]
        public void ParseResult_Empty_ReturnsCancelled()
        {
            FilePickerResult result = MacFilePicker.ParseResult(string.Empty);

            Assert.True(result.IsCancelled);
        }

        [Fact]
        public void ParseResult_Whitespace_ReturnsCancelled()
        {
            FilePickerResult result = MacFilePicker.ParseResult("   ");

            Assert.True(result.IsCancelled);
        }

        [Fact]
        public void ParseResult_SinglePath_ReturnsSuccess()
        {
            FilePickerResult result = MacFilePicker.ParseResult("/Users/test/file.txt");

            Assert.True(result.IsSuccess);
            Assert.Single(result.SelectedPaths);
        }

        [Fact]
        public void ParseResult_MultiplePaths_ReturnsMultiple()
        {
            FilePickerResult result = MacFilePicker.ParseResult("/Users/test/a.txt\n/Users/test/b.txt");

            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.SelectedPaths.Count);
        }

        [Fact]
        public void ParseResult_EmptyLines_ReturnsCancelled()
        {
            FilePickerResult result = MacFilePicker.ParseResult("\n\n");

            Assert.True(result.IsCancelled);
        }

        [Fact]
        public void PickFile_WithValidOptions_ReturnsResult()
        {
            var picker = new MacFilePicker();
            var options = new FilePickerOptions("Test File");

            FilePickerResult result = picker.PickFile(options);

            Assert.NotNull(result);
        }

        [Fact]
        public void PickFiles_WithValidOptions_ReturnsResult()
        {
            var picker = new MacFilePicker();
            var options = new FilePickerOptions("Test Files");

            FilePickerResult result = picker.PickFiles(options);

            Assert.NotNull(result);
        }

        [Fact]
        public void PickFolder_WithValidOptions_ReturnsResult()
        {
            var picker = new MacFilePicker();
            var options = new FilePickerOptions("Test Folder");

            FilePickerResult result = picker.PickFolder(options);

            Assert.NotNull(result);
        }
    }
}
