using System.Collections.Generic;
using Xunit;

namespace Alis.Extension.Io.FileDialog.Test
{
    public class WindowsFilePickerTest
    {
        [Fact]
        public void EscapeScriptString_Null_ReturnsNull()
        {
            Assert.Null(WindowsFilePicker.EscapeScriptString(null));
        }

        [Fact]
        public void EscapeScriptString_Empty_ReturnsEmpty()
        {
            Assert.Equal(string.Empty, WindowsFilePicker.EscapeScriptString(string.Empty));
        }

        [Fact]
        public void EscapeScriptString_WithSingleQuote_ReturnsEscaped()
        {
            string result = WindowsFilePicker.EscapeScriptString("it's");
            Assert.Equal("it''s", result);
        }

        [Fact]
        public void EscapeScriptString_WithDoubleQuote_ReturnsEscaped()
        {
            string result = WindowsFilePicker.EscapeScriptString("say \"hi\"");
            Assert.Equal("say `\"hi`\"", result);
        }

        [Fact]
        public void EscapeScriptString_WithDollarSign_ReturnsEscaped()
        {
            string result = WindowsFilePicker.EscapeScriptString("$var");
            Assert.Equal("`$var", result);
        }

        [Fact]
        public void EscapeScriptString_WithoutSpecialChars_ReturnsSame()
        {
            string result = WindowsFilePicker.EscapeScriptString("hello.txt");
            Assert.Equal("hello.txt", result);
        }

        [Fact]
        public void BuildFilterString_WithNull_ReturnsAllFiles()
        {
            string result = WindowsFilePicker.BuildFilterString(null);

            Assert.Equal("All files (*.*)|*.*", result);
        }

        [Fact]
        public void BuildFilterString_WithEmptyList_ReturnsAllFiles()
        {
            string result = WindowsFilePicker.BuildFilterString(new List<FilePickerFilter>());

            Assert.Equal("All files (*.*)|*.*", result);
        }

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

        [Fact]
        public void BuildOpenFileScript_WithoutDefaultPath_OmitsInitialDirectory()
        {
            var options = new FilePickerOptions("Open File");

            string script = WindowsFilePicker.BuildOpenFileScript(options);

            Assert.DoesNotContain("InitialDirectory", script);
        }

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

        [Fact]
        public void BuildFolderSelectScript_WithoutDefaultPath_OmitsSelectedPath()
        {
            var options = new FilePickerOptions("Select Folder");

            string script = WindowsFilePicker.BuildFolderSelectScript(options);

            Assert.DoesNotContain("SelectedPath", script);
        }

        [Fact]
        public void ExecuteScript_ThrowsOnNonWindows()
        {
            Assert.Throws<System.InvalidOperationException>(() =>
                WindowsFilePicker.ExecuteScript("test script"));
        }

        [Fact]
        public void ParseResult_Null_ReturnsCancelled()
        {
            FilePickerResult result = WindowsFilePicker.ParseResult(null, false);

            Assert.True(result.IsCancelled);
        }

        [Fact]
        public void ParseResult_Empty_ReturnsCancelled()
        {
            FilePickerResult result = WindowsFilePicker.ParseResult(string.Empty, false);

            Assert.True(result.IsCancelled);
        }

        [Fact]
        public void ParseResult_Whitespace_ReturnsCancelled()
        {
            FilePickerResult result = WindowsFilePicker.ParseResult("   ", false);

            Assert.True(result.IsCancelled);
        }

        [Fact]
        public void ParseResult_SinglePath_ReturnsSuccess()
        {
            FilePickerResult result = WindowsFilePicker.ParseResult(@"C:\Users\file.txt", false);

            Assert.True(result.IsSuccess);
            Assert.Single(result.SelectedPaths);
        }

        [Fact]
        public void ParseResult_MultiplePaths_WithAllowMultiple_ReturnsMultiple()
        {
            FilePickerResult result = WindowsFilePicker.ParseResult(@"C:\a.txt
C:\b.txt", true);

            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.SelectedPaths.Count);
        }

        [Fact]
        public void ParseResult_MultiplePaths_WithoutAllowMultiple_ReturnsSingle()
        {
            FilePickerResult result = WindowsFilePicker.ParseResult(@"C:\a.txt
C:\b.txt", false);

            Assert.True(result.IsSuccess);
            Assert.Single(result.SelectedPaths);
        }

        [Fact]
        public void ParseResult_EmptyPaths_ReturnsCancelled()
        {
            FilePickerResult result = WindowsFilePicker.ParseResult("\n", true);

            Assert.True(result.IsCancelled);
        }

        [Fact]
        public void PickFile_WithValidOptions_ReturnsError()
        {
            var picker = new WindowsFilePicker();
            var options = new FilePickerOptions("Test File");

            FilePickerResult result = picker.PickFile(options);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

        [Fact]
        public void PickFiles_WithValidOptions_ReturnsError()
        {
            var picker = new WindowsFilePicker();
            var options = new FilePickerOptions("Test Files");

            FilePickerResult result = picker.PickFiles(options);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

        [Fact]
        public void PickFolder_WithValidOptions_ReturnsError()
        {
            var picker = new WindowsFilePicker();
            var options = new FilePickerOptions("Test Folder");

            FilePickerResult result = picker.PickFolder(options);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }
    }
}
