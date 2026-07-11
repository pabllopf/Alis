using System.Collections.Generic;
using Xunit;

namespace Alis.Extension.Io.FileDialog.Test
{
    public class LinuxFilePickerTest
    {
        [Fact]
        public void EscapeShellString_Null_ReturnsNull()
        {
            Assert.Null(LinuxFilePicker.EscapeShellString(null));
        }

        [Fact]
        public void EscapeShellString_Empty_ReturnsEmpty()
        {
            Assert.Equal(string.Empty, LinuxFilePicker.EscapeShellString(string.Empty));
        }

        [Fact]
        public void EscapeShellString_WithDoubleQuote_ReturnsEscaped()
        {
            string result = LinuxFilePicker.EscapeShellString("hello\"world");
            Assert.Equal("hello\\\"world", result);
        }

        [Fact]
        public void EscapeShellString_WithSingleQuote_ReturnsEscaped()
        {
            string result = LinuxFilePicker.EscapeShellString("it's");
            Assert.Equal("it\\'s", result);
        }

        [Fact]
        public void EscapeShellString_WithDollarSign_ReturnsEscaped()
        {
            string result = LinuxFilePicker.EscapeShellString("$PATH");
            Assert.Equal("\\$PATH", result);
        }

        [Fact]
        public void EscapeShellString_WithoutSpecialChars_ReturnsSame()
        {
            string result = LinuxFilePicker.EscapeShellString("hello.txt");
            Assert.Equal("hello.txt", result);
        }

        [Fact]
        public void BuildZenityFileDialogArguments_WithAllOptions_AddsCorrectArgs()
        {
            var args = new List<string>();
            var options = new FilePickerOptions("Open File")
            {
                DefaultPath = "/home/user",
                Filters = new List<FilePickerFilter> { new("Text files", ".txt") }
            };

            LinuxFilePicker.BuildZenityFileDialogArguments(args, options, true);

            Assert.Contains("--file-selection", args);
            Assert.Contains("--title=\"Open File\"", args);
            Assert.Contains("--filename=\"/home/user\"", args);
            Assert.Contains("--multiple", args);
            Assert.Contains("--separator=|", args);
            Assert.Contains("--file-filter=\"Text files | *.txt\"", args);
            Assert.Contains("--file-filter=\"All files | *\"", args);
        }

        [Fact]
        public void BuildZenityFileDialogArguments_WithoutTitle_SkipsTitle()
        {
            var args = new List<string>();
            var options = new FilePickerOptions { DefaultPath = "/tmp" };

            LinuxFilePicker.BuildZenityFileDialogArguments(args, options, false);

            Assert.Contains("--file-selection", args);
            Assert.Contains("--filename=\"/tmp\"", args);
            Assert.DoesNotContain("--title", args);
            Assert.DoesNotContain("--multiple", args);
        }

        [Fact]
        public void BuildZenityFileDialogArguments_WithoutDefaultPath_SkipsFilename()
        {
            var args = new List<string>();
            var options = new FilePickerOptions("Test");

            LinuxFilePicker.BuildZenityFileDialogArguments(args, options, false);

            Assert.Contains("--file-selection", args);
            Assert.Contains("--title=\"Test\"", args);
            Assert.DoesNotContain("--filename", args);
        }

        [Fact]
        public void BuildZenityFileDialogArguments_WithoutFilters_SkipsFilters()
        {
            var args = new List<string>();
            var options = new FilePickerOptions("Test");

            LinuxFilePicker.BuildZenityFileDialogArguments(args, options, false);

            Assert.DoesNotContain("--file-filter", args);
        }

        [Fact]
        public void BuildZenityFileDialogArguments_WithEmptyFilters_SkipsFilters()
        {
            var args = new List<string>();
            var options = new FilePickerOptions("Test")
            {
                Filters = new List<FilePickerFilter>()
            };

            LinuxFilePicker.BuildZenityFileDialogArguments(args, options, false);

            Assert.DoesNotContain("--file-filter", args);
        }

        [Fact]
        public void BuildKdialogFileDialogArguments_WithMultiple_AddsGetOpenFilenames()
        {
            var args = new List<string>();
            var options = new FilePickerOptions("Open Files")
            {
                DefaultPath = "/home/user",
                Filters = new List<FilePickerFilter> { new("Text files", ".txt") }
            };

            LinuxFilePicker.BuildKdialogFileDialogArguments(args, options, true);

            Assert.Contains("--getopenfilenames", args);
            Assert.Contains("/home/user", args);
            Assert.Contains("--title \"Open Files\"", args);
        }

        [Fact]
        public void BuildKdialogFileDialogArguments_WithoutMultiple_AddsGetOpenFilename()
        {
            var args = new List<string>();
            var options = new FilePickerOptions("Open File") { DefaultPath = "/tmp" };

            LinuxFilePicker.BuildKdialogFileDialogArguments(args, options, false);

            Assert.Contains("--getopenfilename", args);
            Assert.DoesNotContain("--getopenfilenames", args);
        }

        [Fact]
        public void BuildKdialogFileDialogArguments_WithoutDefaultPath_AddsTilde()
        {
            var args = new List<string>();
            var options = new FilePickerOptions("Test");

            LinuxFilePicker.BuildKdialogFileDialogArguments(args, options, false);

            Assert.Contains("~/", args);
        }

        [Fact]
        public void BuildKdialogFileDialogArguments_WithoutTitle_SkipsTitle()
        {
            var args = new List<string>();
            var options = new FilePickerOptions { DefaultPath = "/tmp", Title = null };

            LinuxFilePicker.BuildKdialogFileDialogArguments(args, options, false);

            Assert.DoesNotContain("--title", args);
        }

        [Fact]
        public void BuildKdialogFileDialogArguments_WithoutFilters_SkipsFilterArg()
        {
            var args = new List<string>();
            var options = new FilePickerOptions("Test") { DefaultPath = "/tmp" };

            LinuxFilePicker.BuildKdialogFileDialogArguments(args, options, false);

            Assert.Single(args, a => a.Contains("/tmp"));
        }

        [Fact]
        public void BuildFileDialogArguments_WithZenity_ReturnsZenityArgs()
        {
            var options = new FilePickerOptions("Test");

            string result = LinuxFilePicker.BuildFileDialogArguments("zenity", options, false);

            Assert.Contains("--file-selection", result);
            Assert.Contains("--title=\"Test\"", result);
        }

        [Fact]
        public void BuildFileDialogArguments_WithKdialog_ReturnsKdialogArgs()
        {
            var options = new FilePickerOptions("Test");

            string result = LinuxFilePicker.BuildFileDialogArguments("kdialog", options, false);

            Assert.Contains("--getopenfilename", result);
        }

        [Fact]
        public void BuildFolderDialogArguments_Zenity_WithAllOptions_ReturnsCorrectArgs()
        {
            var options = new FilePickerOptions("Select Folder")
            {
                DefaultPath = "/home/user"
            };

            string result = LinuxFilePicker.BuildFolderDialogArguments("zenity", options);

            Assert.Contains("--file-selection", result);
            Assert.Contains("--directory", result);
            Assert.Contains("--title=\"Select Folder\"", result);
            Assert.Contains("--filename=\"/home/user\"", result);
        }

        [Fact]
        public void BuildFolderDialogArguments_Zenity_WithoutTitle_SkipsTitle()
        {
            var options = new FilePickerOptions { DefaultPath = "/tmp" };

            string result = LinuxFilePicker.BuildFolderDialogArguments("zenity", options);

            Assert.DoesNotContain("--title", result);
        }

        [Fact]
        public void BuildFolderDialogArguments_Zenity_WithoutDefaultPath_SkipsFilename()
        {
            var options = new FilePickerOptions("Select");

            string result = LinuxFilePicker.BuildFolderDialogArguments("zenity", options);

            Assert.DoesNotContain("--filename", result);
        }

        [Fact]
        public void BuildFolderDialogArguments_Kdialog_WithAllOptions_ReturnsCorrectArgs()
        {
            var options = new FilePickerOptions("Select Folder")
            {
                DefaultPath = "/home/user"
            };

            string result = LinuxFilePicker.BuildFolderDialogArguments("kdialog", options);

            Assert.Contains("--getexistingdirectory", result);
            Assert.Contains("/home/user", result);
            Assert.Contains("--title", result);
        }

        [Fact]
        public void BuildFolderDialogArguments_Kdialog_WithoutDefaultPath_AddsTilde()
        {
            var options = new FilePickerOptions("Select Folder");

            string result = LinuxFilePicker.BuildFolderDialogArguments("kdialog", options);

            Assert.Contains("~/", result);
        }

        [Fact]
        public void BuildFolderDialogArguments_Kdialog_WithoutTitle_SkipsTitle()
        {
            var options = new FilePickerOptions { DefaultPath = "/tmp" };

            string result = LinuxFilePicker.BuildFolderDialogArguments("kdialog", options);

            Assert.DoesNotContain("--title", result);
        }

        [Fact]
        public void ParseResult_Null_ReturnsCancelled()
        {
            FilePickerResult result = LinuxFilePicker.ParseResult(null, false);

            Assert.True(result.IsCancelled);
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public void ParseResult_Empty_ReturnsCancelled()
        {
            FilePickerResult result = LinuxFilePicker.ParseResult(string.Empty, false);

            Assert.True(result.IsCancelled);
        }

        [Fact]
        public void ParseResult_Whitespace_ReturnsCancelled()
        {
            FilePickerResult result = LinuxFilePicker.ParseResult("   ", false);

            Assert.True(result.IsCancelled);
        }

        [Fact]
        public void ParseResult_SinglePath_ReturnsSuccess()
        {
            FilePickerResult result = LinuxFilePicker.ParseResult("/home/user/file.txt", false);

            Assert.True(result.IsSuccess);
            Assert.Single(result.SelectedPaths);
            Assert.Contains("/home/user/file.txt", result.SelectedPaths);
        }

        [Fact]
        public void ParseResult_MultiplePaths_WithAllowMultiple_ReturnsMultiple()
        {
            FilePickerResult result = LinuxFilePicker.ParseResult("/home/user/a.txt|/home/user/b.txt", true);

            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.SelectedPaths.Count);
        }

        [Fact]
        public void ParseResult_MultiplePaths_WithoutAllowMultiple_TreatsAsSingle()
        {
            FilePickerResult result = LinuxFilePicker.ParseResult("/home/user/a.txt|/home/user/b.txt", false);

            Assert.True(result.IsSuccess);
            Assert.Single(result.SelectedPaths);
        }

        [Fact]
        public void ParseResult_EmptyPaths_ReturnsCancelled()
        {
            FilePickerResult result = LinuxFilePicker.ParseResult("|", true);

            Assert.True(result.IsCancelled);
        }

        [Fact]
        public void GetAvailableDialogTool_OnNonLinux_ReturnsNull()
        {
            string tool = LinuxFilePicker.GetAvailableDialogTool();

            Assert.Null(tool);
        }

        [Fact]
        public void PickFile_OnNonLinux_ReturnsError()
        {
            var picker = new LinuxFilePicker();
            var options = new FilePickerOptions("Test File");

            FilePickerResult result = picker.PickFile(options);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

        [Fact]
        public void PickFiles_OnNonLinux_ReturnsError()
        {
            var picker = new LinuxFilePicker();
            var options = new FilePickerOptions("Test Files");

            FilePickerResult result = picker.PickFiles(options);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

        [Fact]
        public void PickFolder_OnNonLinux_ReturnsError()
        {
            var picker = new LinuxFilePicker();
            var options = new FilePickerOptions("Test Folder");

            FilePickerResult result = picker.PickFolder(options);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }
    }
}
