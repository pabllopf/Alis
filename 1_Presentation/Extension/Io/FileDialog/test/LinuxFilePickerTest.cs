using System;
using System.Collections.Generic;
using Xunit;

namespace Alis.Extension.Io.FileDialog.Test
{
    /// <summary>
    /// The linux file picker test class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class LinuxFilePickerTest : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinuxFilePickerTest"/> class
        /// </summary>
        public LinuxFilePickerTest()
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
        /// Tests that escape shell string null returns null
        /// </summary>
        [Fact]
        public void EscapeShellString_Null_ReturnsNull()
        {
            Assert.Null(LinuxFilePicker.EscapeShellString(null));
        }

        /// <summary>
        /// Tests that escape shell string empty returns empty
        /// </summary>
        [Fact]
        public void EscapeShellString_Empty_ReturnsEmpty()
        {
            Assert.Equal(string.Empty, LinuxFilePicker.EscapeShellString(string.Empty));
        }

        /// <summary>
        /// Tests that escape shell string with double quote returns escaped
        /// </summary>
        [Fact]
        public void EscapeShellString_WithDoubleQuote_ReturnsEscaped()
        {
            string result = LinuxFilePicker.EscapeShellString("hello\"world");
            Assert.Equal("hello\\\"world", result);
        }

        /// <summary>
        /// Tests that escape shell string with single quote returns escaped
        /// </summary>
        [Fact]
        public void EscapeShellString_WithSingleQuote_ReturnsEscaped()
        {
            string result = LinuxFilePicker.EscapeShellString("it's");
            Assert.Equal("it\\'s", result);
        }

        /// <summary>
        /// Tests that escape shell string with dollar sign returns escaped
        /// </summary>
        [Fact]
        public void EscapeShellString_WithDollarSign_ReturnsEscaped()
        {
            string result = LinuxFilePicker.EscapeShellString("$PATH");
            Assert.Equal("\\$PATH", result);
        }

        /// <summary>
        /// Tests that escape shell string without special chars returns same
        /// </summary>
        [Fact]
        public void EscapeShellString_WithoutSpecialChars_ReturnsSame()
        {
            string result = LinuxFilePicker.EscapeShellString("hello.txt");
            Assert.Equal("hello.txt", result);
        }

        /// <summary>
        /// Tests that build zenity file dialog arguments with all options adds correct args
        /// </summary>
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

        /// <summary>
        /// Tests that build zenity file dialog arguments without title skips title
        /// </summary>
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

        /// <summary>
        /// Tests that build zenity file dialog arguments without default path skips filename
        /// </summary>
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

        /// <summary>
        /// Tests that build zenity file dialog arguments without filters skips filters
        /// </summary>
        [Fact]
        public void BuildZenityFileDialogArguments_WithoutFilters_SkipsFilters()
        {
            var args = new List<string>();
            var options = new FilePickerOptions("Test");

            LinuxFilePicker.BuildZenityFileDialogArguments(args, options, false);

            Assert.DoesNotContain("--file-filter", args);
        }

        /// <summary>
        /// Tests that build zenity file dialog arguments with empty filters skips filters
        /// </summary>
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

        /// <summary>
        /// Tests that build kdialog file dialog arguments with multiple adds get open filenames
        /// </summary>
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

        /// <summary>
        /// Tests that build kdialog file dialog arguments without multiple adds get open filename
        /// </summary>
        [Fact]
        public void BuildKdialogFileDialogArguments_WithoutMultiple_AddsGetOpenFilename()
        {
            var args = new List<string>();
            var options = new FilePickerOptions("Open File") { DefaultPath = "/tmp" };

            LinuxFilePicker.BuildKdialogFileDialogArguments(args, options, false);

            Assert.Contains("--getopenfilename", args);
            Assert.DoesNotContain("--getopenfilenames", args);
        }

        /// <summary>
        /// Tests that build kdialog file dialog arguments without default path adds tilde
        /// </summary>
        [Fact]
        public void BuildKdialogFileDialogArguments_WithoutDefaultPath_AddsTilde()
        {
            var args = new List<string>();
            var options = new FilePickerOptions("Test");

            LinuxFilePicker.BuildKdialogFileDialogArguments(args, options, false);

            Assert.Contains("~/", args);
        }

        /// <summary>
        /// Tests that build kdialog file dialog arguments without title skips title
        /// </summary>
        [Fact]
        public void BuildKdialogFileDialogArguments_WithoutTitle_SkipsTitle()
        {
            var args = new List<string>();
            var options = new FilePickerOptions { DefaultPath = "/tmp", Title = null };

            LinuxFilePicker.BuildKdialogFileDialogArguments(args, options, false);

            Assert.DoesNotContain("--title", args);
        }

        /// <summary>
        /// Tests that build kdialog file dialog arguments without filters skips filter arg
        /// </summary>
        [Fact]
        public void BuildKdialogFileDialogArguments_WithoutFilters_SkipsFilterArg()
        {
            var args = new List<string>();
            var options = new FilePickerOptions("Test") { DefaultPath = "/tmp" };

            LinuxFilePicker.BuildKdialogFileDialogArguments(args, options, false);

            Assert.Single(args, a => a.Contains("/tmp"));
        }

        /// <summary>
        /// Tests that build file dialog arguments with zenity returns zenity args
        /// </summary>
        [Fact]
        public void BuildFileDialogArguments_WithZenity_ReturnsZenityArgs()
        {
            var options = new FilePickerOptions("Test");

            string result = LinuxFilePicker.BuildFileDialogArguments("zenity", options, false);

            Assert.Contains("--file-selection", result);
            Assert.Contains("--title=\"Test\"", result);
        }

        /// <summary>
        /// Tests that build file dialog arguments with kdialog returns kdialog args
        /// </summary>
        [Fact]
        public void BuildFileDialogArguments_WithKdialog_ReturnsKdialogArgs()
        {
            var options = new FilePickerOptions("Test");

            string result = LinuxFilePicker.BuildFileDialogArguments("kdialog", options, false);

            Assert.Contains("--getopenfilename", result);
        }

        /// <summary>
        /// Tests that build folder dialog arguments zenity with all options returns correct args
        /// </summary>
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

        /// <summary>
        /// Tests that build folder dialog arguments zenity without title skips title
        /// </summary>
        [Fact]
        public void BuildFolderDialogArguments_Zenity_WithoutTitle_SkipsTitle()
        {
            var options = new FilePickerOptions { DefaultPath = "/tmp", Title = null };

            string result = LinuxFilePicker.BuildFolderDialogArguments("zenity", options);

            Assert.DoesNotContain("--title", result);
        }

        /// <summary>
        /// Tests that build folder dialog arguments zenity without default path skips filename
        /// </summary>
        [Fact]
        public void BuildFolderDialogArguments_Zenity_WithoutDefaultPath_SkipsFilename()
        {
            var options = new FilePickerOptions("Select");

            string result = LinuxFilePicker.BuildFolderDialogArguments("zenity", options);

            Assert.DoesNotContain("--filename", result);
        }

        /// <summary>
        /// Tests that build folder dialog arguments kdialog with all options returns correct args
        /// </summary>
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

        /// <summary>
        /// Tests that build folder dialog arguments kdialog without default path adds tilde
        /// </summary>
        [Fact]
        public void BuildFolderDialogArguments_Kdialog_WithoutDefaultPath_AddsTilde()
        {
            var options = new FilePickerOptions("Select Folder");

            string result = LinuxFilePicker.BuildFolderDialogArguments("kdialog", options);

            Assert.Contains("~/", result);
        }

        /// <summary>
        /// Tests that build folder dialog arguments kdialog without title skips title
        /// </summary>
        [Fact]
        public void BuildFolderDialogArguments_Kdialog_WithoutTitle_SkipsTitle()
        {
            var options = new FilePickerOptions { DefaultPath = "/tmp", Title = null };

            string result = LinuxFilePicker.BuildFolderDialogArguments("kdialog", options);

            Assert.DoesNotContain("--title", result);
        }

        /// <summary>
        /// Tests that parse result null returns cancelled
        /// </summary>
        [Fact]
        public void ParseResult_Null_ReturnsCancelled()
        {
            FilePickerResult result = LinuxFilePicker.ParseResult(null, false);

            Assert.True(result.IsCancelled);
            Assert.False(result.IsSuccess);
        }

        /// <summary>
        /// Tests that parse result empty returns cancelled
        /// </summary>
        [Fact]
        public void ParseResult_Empty_ReturnsCancelled()
        {
            FilePickerResult result = LinuxFilePicker.ParseResult(string.Empty, false);

            Assert.True(result.IsCancelled);
        }

        /// <summary>
        /// Tests that parse result whitespace returns cancelled
        /// </summary>
        [Fact]
        public void ParseResult_Whitespace_ReturnsCancelled()
        {
            FilePickerResult result = LinuxFilePicker.ParseResult("   ", false);

            Assert.True(result.IsCancelled);
        }

        /// <summary>
        /// Tests that parse result single path returns success
        /// </summary>
        [Fact]
        public void ParseResult_SinglePath_ReturnsSuccess()
        {
            FilePickerResult result = LinuxFilePicker.ParseResult("/home/user/file.txt", false);

            Assert.True(result.IsSuccess);
            Assert.Single(result.SelectedPaths);
            Assert.Contains("/home/user/file.txt", result.SelectedPaths);
        }

        /// <summary>
        /// Tests that parse result multiple paths with allow multiple returns multiple
        /// </summary>
        [Fact]
        public void ParseResult_MultiplePaths_WithAllowMultiple_ReturnsMultiple()
        {
            FilePickerResult result = LinuxFilePicker.ParseResult("/home/user/a.txt|/home/user/b.txt", true);

            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.SelectedPaths.Count);
        }

        /// <summary>
        /// Tests that parse result multiple paths without allow multiple treats as single
        /// </summary>
        [Fact]
        public void ParseResult_MultiplePaths_WithoutAllowMultiple_TreatsAsSingle()
        {
            FilePickerResult result = LinuxFilePicker.ParseResult("/home/user/a.txt|/home/user/b.txt", false);

            Assert.True(result.IsSuccess);
            Assert.Single(result.SelectedPaths);
        }

        /// <summary>
        /// Tests that parse result empty paths returns cancelled
        /// </summary>
        [Fact]
        public void ParseResult_EmptyPaths_ReturnsCancelled()
        {
            FilePickerResult result = LinuxFilePicker.ParseResult("|", true);

            Assert.True(result.IsCancelled);
        }

        /// <summary>
        /// Tests that get available dialog tool on non linux returns null
        /// </summary>
        [Fact]
        public void GetAvailableDialogTool_OnNonLinux_ReturnsNull()
        {
            string tool = LinuxFilePicker.GetAvailableDialogTool();

            Assert.Null(tool);
        }

        /// <summary>
        /// Tests that pick file on non linux returns error
        /// </summary>
        [Fact]
        public void PickFile_OnNonLinux_ReturnsError()
        {
            var picker = new LinuxFilePicker();
            var options = new FilePickerOptions("Test File");

            FilePickerResult result = picker.PickFile(options);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

        /// <summary>
        /// Tests that pick files on non linux returns error
        /// </summary>
        [Fact]
        public void PickFiles_OnNonLinux_ReturnsError()
        {
            var picker = new LinuxFilePicker();
            var options = new FilePickerOptions("Test Files");

            FilePickerResult result = picker.PickFiles(options);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

        /// <summary>
        /// Tests that pick folder on non linux returns error
        /// </summary>
        [Fact]
        public void PickFolder_OnNonLinux_ReturnsError()
        {
            var picker = new LinuxFilePicker();
            var options = new FilePickerOptions("Test Folder");

            FilePickerResult result = picker.PickFolder(options);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

        /// <summary>
        /// Tests that get available dialog tool with command exists override zenity found returns zenity
        /// </summary>
        [Fact]
        public void GetAvailableDialogTool_WithCommandExistsOverride_ZenityFound_ReturnsZenity()
        {
            FilePickerExecutor.CommandExistsOverride = cmd => cmd == "zenity";

            string tool = LinuxFilePicker.GetAvailableDialogTool();

            Assert.Equal("zenity", tool);
        }

        /// <summary>
        /// Tests that get available dialog tool with command exists override kdialog found returns kdialog
        /// </summary>
        [Fact]
        public void GetAvailableDialogTool_WithCommandExistsOverride_KdialogFound_ReturnsKdialog()
        {
            FilePickerExecutor.CommandExistsOverride = cmd => cmd == "kdialog";

            string tool = LinuxFilePicker.GetAvailableDialogTool();

            Assert.Equal("kdialog", tool);
        }

        /// <summary>
        /// Tests that execute file dialog with zenity found returns result
        /// </summary>
        [Fact]
        public void ExecuteFileDialog_WithZenityFound_ReturnsResult()
        {
            FilePickerExecutor.CommandExistsOverride = cmd => cmd == "zenity";
            FilePickerExecutor.ExecuteCommandOverride = (file, args, timeout) => "/test/output.txt";

            var options = new FilePickerOptions("Test");

            string result = LinuxFilePicker.ExecuteFileDialog(options, false);

            Assert.Equal("/test/output.txt", result);
        }

        /// <summary>
        /// Tests that execute folder dialog with zenity found returns result
        /// </summary>
        [Fact]
        public void ExecuteFolderDialog_WithZenityFound_ReturnsResult()
        {
            FilePickerExecutor.CommandExistsOverride = cmd => cmd == "zenity";
            FilePickerExecutor.ExecuteCommandOverride = (file, args, timeout) => "/test/folder";

            var options = new FilePickerOptions("Test");

            string result = LinuxFilePicker.ExecuteFolderDialog(options);

            Assert.Equal("/test/folder", result);
        }

        /// <summary>
        /// Tests that pick file with mocked execution returns success
        /// </summary>
        [Fact]
        public void PickFile_WithMockedExecution_ReturnsSuccess()
        {
            FilePickerExecutor.CommandExistsOverride = cmd => cmd == "zenity";
            FilePickerExecutor.ExecuteCommandOverride = (file, args, timeout) => "/mock/file.txt";

            var picker = new LinuxFilePicker();
            var options = new FilePickerOptions("Test File");

            FilePickerResult result = picker.PickFile(options);

            Assert.True(result.IsSuccess);
            Assert.Contains("/mock/file.txt", result.SelectedPaths);
        }

        /// <summary>
        /// Tests that pick files with mocked execution returns success
        /// </summary>
        [Fact]
        public void PickFiles_WithMockedExecution_ReturnsSuccess()
        {
            FilePickerExecutor.CommandExistsOverride = cmd => cmd == "zenity";
            FilePickerExecutor.ExecuteCommandOverride = (file, args, timeout) => "/mock/a.txt|/mock/b.txt";

            var picker = new LinuxFilePicker();
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
            FilePickerExecutor.CommandExistsOverride = cmd => cmd == "zenity";
            FilePickerExecutor.ExecuteCommandOverride = (file, args, timeout) => "/mock/folder";

            var picker = new LinuxFilePicker();
            var options = new FilePickerOptions("Test Folder");

            FilePickerResult result = picker.PickFolder(options);

            Assert.True(result.IsSuccess);
            Assert.Contains("/mock/folder", result.SelectedPaths);
        }

        /// <summary>
        /// Tests that pick file with null options returns error
        /// </summary>
        [Fact]
        public void PickFile_NullOptions_ReturnsError()
        {
            var picker = new LinuxFilePicker();
            FilePickerResult result = picker.PickFile(null);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

        /// <summary>
        /// Tests that pick files with null options returns error
        /// </summary>
        [Fact]
        public void PickFiles_NullOptions_ReturnsError()
        {
            var picker = new LinuxFilePicker();
            FilePickerResult result = picker.PickFiles(null);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

        /// <summary>
        /// Tests that pick folder with null options returns error
        /// </summary>
        [Fact]
        public void PickFolder_NullOptions_ReturnsError()
        {
            var picker = new LinuxFilePicker();
            FilePickerResult result = picker.PickFolder(null);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.ErrorMessage);
        }

        /// <summary>
        /// Tests that build zenity file dialog arguments with null filters skips filters
        /// </summary>
        [Fact]
        public void BuildZenityFileDialogArguments_WithNullFilters_SkipsFilters()
        {
            var args = new List<string>();
            var options = new FilePickerOptions("Test")
            {
                Filters = null
            };

            LinuxFilePicker.BuildZenityFileDialogArguments(args, options, false);

            Assert.DoesNotContain("--file-filter", args);
        }

        /// <summary>
        /// Tests that build kdialog file dialog arguments with null filters skips filter arg
        /// </summary>
        [Fact]
        public void BuildKdialogFileDialogArguments_WithNullFilters_SkipsFilters()
        {
            var args = new List<string>();
            var options = new FilePickerOptions("Test")
            {
                DefaultPath = "/tmp",
                Filters = null
            };

            LinuxFilePicker.BuildKdialogFileDialogArguments(args, options, false);

            Assert.Single(args, a => a.Contains("/tmp"));
        }

    }
}
