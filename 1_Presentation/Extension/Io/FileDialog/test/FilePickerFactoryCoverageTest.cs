using System;
using System.Runtime.InteropServices;
using Xunit;

namespace Alis.Extension.Io.FileDialog.Test
{
    public class FilePickerFactoryCoverageTest : IDisposable
    {
        public FilePickerFactoryCoverageTest()
        {
            PlatformHelper.IsOSPlatform = RuntimeInformation.IsOSPlatform;
        }

        public void Dispose()
        {
            PlatformHelper.IsOSPlatform = RuntimeInformation.IsOSPlatform;
        }

        [Fact]
        public void CreateFilePickerWithOptions_WithOpenFileDialogType_ShouldReturnValidInstance()
        {
            FilePickerOptions options = new FilePickerOptions("Open File", FileDialogType.OpenFile);

            IFilePicker picker = FilePickerFactory.CreateFilePickerWithOptions(options);

            Assert.NotNull(picker);
            Assert.IsAssignableFrom<IFilePicker>(picker);
        }

        [Fact]
        public void CreateFilePickerWithOptions_WithSaveFileDialogType_ShouldReturnValidInstance()
        {
            FilePickerOptions options = new FilePickerOptions("Save File", FileDialogType.SaveFile);

            IFilePicker picker = FilePickerFactory.CreateFilePickerWithOptions(options);

            Assert.NotNull(picker);
            Assert.IsAssignableFrom<IFilePicker>(picker);
        }

        [Fact]
        public void CreateFilePickerWithOptions_WithSelectFolderDialogType_ShouldReturnValidInstance()
        {
            FilePickerOptions options = new FilePickerOptions("Select Folder", FileDialogType.SelectFolder);

            IFilePicker picker = FilePickerFactory.CreateFilePickerWithOptions(options);

            Assert.NotNull(picker);
            Assert.IsAssignableFrom<IFilePicker>(picker);
        }

        [Fact]
        public void CreateFilePickerWithOptions_WithAllowMultiple_ShouldReturnValidInstance()
        {
            FilePickerOptions options = new FilePickerOptions("Open Files", FileDialogType.OpenFile)
            {
                AllowMultiple = true
            };

            IFilePicker picker = FilePickerFactory.CreateFilePickerWithOptions(options);

            Assert.NotNull(picker);
            Assert.IsAssignableFrom<IFilePicker>(picker);
        }

        [Fact]
        public void CreateFilePicker_BehavesAsWindows_OnMockedWindows()
        {
            PlatformHelper.IsOSPlatform = p => p == OSPlatform.Windows;

            IFilePicker picker = FilePickerFactory.CreateFilePicker();

            Assert.IsType<WindowsFilePicker>(picker);
        }

        [Fact]
        public void CreateFilePicker_BehavesAsMac_OnMockedMac()
        {
            PlatformHelper.IsOSPlatform = p => p == OSPlatform.OSX;

            IFilePicker picker = FilePickerFactory.CreateFilePicker();

            Assert.IsType<MacFilePicker>(picker);
        }

        [Fact]
        public void CreateFilePicker_BehavesAsLinux_OnMockedLinux()
        {
            PlatformHelper.IsOSPlatform = p => p == OSPlatform.Linux;

            IFilePicker picker = FilePickerFactory.CreateFilePicker();

            Assert.IsType<LinuxFilePicker>(picker);
        }

        [Fact]
        public void CreateFilePicker_OnUnsupportedPlatform_ThrowsNotSupportedException()
        {
            PlatformHelper.IsOSPlatform = p => false;

            Assert.Throws<NotSupportedException>(() => FilePickerFactory.CreateFilePicker());
        }

        [Fact]
        public void GetPlatformName_ReturnsWindows_OnMockedWindows()
        {
            PlatformHelper.IsOSPlatform = p => p == OSPlatform.Windows;

            string name = FilePickerFactory.GetPlatformName();

            Assert.Equal("Windows", name);
        }

        [Fact]
        public void GetPlatformName_ReturnsMacOS_OnMockedMac()
        {
            PlatformHelper.IsOSPlatform = p => p == OSPlatform.OSX;

            string name = FilePickerFactory.GetPlatformName();

            Assert.Equal("macOS", name);
        }

        [Fact]
        public void GetPlatformName_ReturnsLinux_OnMockedLinux()
        {
            PlatformHelper.IsOSPlatform = p => p == OSPlatform.Linux;

            string name = FilePickerFactory.GetPlatformName();

            Assert.Equal("Linux", name);
        }

        [Fact]
        public void GetPlatformName_ReturnsUnknown_OnUnsupportedPlatform()
        {
            PlatformHelper.IsOSPlatform = p => false;

            string name = FilePickerFactory.GetPlatformName();

            Assert.Equal("Unknown", name);
        }

        [Fact]
        public void IsPlatformSupported_ReturnsTrue_OnMockedWindows()
        {
            PlatformHelper.IsOSPlatform = p => p == OSPlatform.Windows;

            Assert.True(FilePickerFactory.IsPlatformSupported());
        }

        [Fact]
        public void IsPlatformSupported_ReturnsTrue_OnMockedMac()
        {
            PlatformHelper.IsOSPlatform = p => p == OSPlatform.OSX;

            Assert.True(FilePickerFactory.IsPlatformSupported());
        }

        [Fact]
        public void IsPlatformSupported_ReturnsTrue_OnMockedLinux()
        {
            PlatformHelper.IsOSPlatform = p => p == OSPlatform.Linux;

            Assert.True(FilePickerFactory.IsPlatformSupported());
        }

        [Fact]
        public void IsPlatformSupported_ReturnsFalse_OnUnsupportedPlatform()
        {
            PlatformHelper.IsOSPlatform = p => false;

            Assert.False(FilePickerFactory.IsPlatformSupported());
        }
    }
}
