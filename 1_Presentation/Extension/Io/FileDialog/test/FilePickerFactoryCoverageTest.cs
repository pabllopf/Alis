using System;
using System.Runtime.InteropServices;
using Xunit;

namespace Alis.Extension.Io.FileDialog.Test
{
    /// <summary>
    /// The file picker factory coverage test class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class FilePickerFactoryCoverageTest : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilePickerFactoryCoverageTest"/> class
        /// </summary>
        public FilePickerFactoryCoverageTest()
        {
            PlatformHelper.IsOSPlatform = RuntimeInformation.IsOSPlatform;
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            PlatformHelper.IsOSPlatform = RuntimeInformation.IsOSPlatform;
        }

        /// <summary>
        /// Tests that create file picker with options with open file dialog type should return valid instance
        /// </summary>
        [Fact]
        public void CreateFilePickerWithOptions_WithOpenFileDialogType_ShouldReturnValidInstance()
        {
            FilePickerOptions options = new FilePickerOptions("Open File", FileDialogType.OpenFile);

            IFilePicker picker = FilePickerFactory.CreateFilePickerWithOptions(options);

            Assert.NotNull(picker);
            Assert.IsAssignableFrom<IFilePicker>(picker);
        }

        /// <summary>
        /// Tests that create file picker with options with save file dialog type should return valid instance
        /// </summary>
        [Fact]
        public void CreateFilePickerWithOptions_WithSaveFileDialogType_ShouldReturnValidInstance()
        {
            FilePickerOptions options = new FilePickerOptions("Save File", FileDialogType.SaveFile);

            IFilePicker picker = FilePickerFactory.CreateFilePickerWithOptions(options);

            Assert.NotNull(picker);
            Assert.IsAssignableFrom<IFilePicker>(picker);
        }

        /// <summary>
        /// Tests that create file picker with options with select folder dialog type should return valid instance
        /// </summary>
        [Fact]
        public void CreateFilePickerWithOptions_WithSelectFolderDialogType_ShouldReturnValidInstance()
        {
            FilePickerOptions options = new FilePickerOptions("Select Folder", FileDialogType.SelectFolder);

            IFilePicker picker = FilePickerFactory.CreateFilePickerWithOptions(options);

            Assert.NotNull(picker);
            Assert.IsAssignableFrom<IFilePicker>(picker);
        }

        /// <summary>
        /// Tests that create file picker with options with allow multiple should return valid instance
        /// </summary>
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

        /// <summary>
        /// Tests that create file picker behaves as windows on mocked windows
        /// </summary>
        [Fact]
        public void CreateFilePicker_BehavesAsWindows_OnMockedWindows()
        {
            PlatformHelper.IsOSPlatform = p => p == OSPlatform.Windows;

            IFilePicker picker = FilePickerFactory.CreateFilePicker();

            Assert.IsType<WindowsFilePicker>(picker);
        }

        /// <summary>
        /// Tests that create file picker behaves as mac on mocked mac
        /// </summary>
        [Fact]
        public void CreateFilePicker_BehavesAsMac_OnMockedMac()
        {
            PlatformHelper.IsOSPlatform = p => p == OSPlatform.OSX;

            IFilePicker picker = FilePickerFactory.CreateFilePicker();

            Assert.IsType<MacFilePicker>(picker);
        }

        /// <summary>
        /// Tests that create file picker behaves as linux on mocked linux
        /// </summary>
        [Fact]
        public void CreateFilePicker_BehavesAsLinux_OnMockedLinux()
        {
            PlatformHelper.IsOSPlatform = p => p == OSPlatform.Linux;

            IFilePicker picker = FilePickerFactory.CreateFilePicker();

            Assert.IsType<LinuxFilePicker>(picker);
        }

        /// <summary>
        /// Tests that create file picker on unsupported platform throws not supported exception
        /// </summary>
        [Fact]
        public void CreateFilePicker_OnUnsupportedPlatform_ThrowsNotSupportedException()
        {
            PlatformHelper.IsOSPlatform = p => false;

            Assert.Throws<NotSupportedException>(() => FilePickerFactory.CreateFilePicker());
        }

        /// <summary>
        /// Tests that get platform name returns windows on mocked windows
        /// </summary>
        [Fact]
        public void GetPlatformName_ReturnsWindows_OnMockedWindows()
        {
            PlatformHelper.IsOSPlatform = p => p == OSPlatform.Windows;

            string name = FilePickerFactory.GetPlatformName();

            Assert.Equal("Windows", name);
        }

        /// <summary>
        /// Tests that get platform name returns mac os on mocked mac
        /// </summary>
        [Fact]
        public void GetPlatformName_ReturnsMacOS_OnMockedMac()
        {
            PlatformHelper.IsOSPlatform = p => p == OSPlatform.OSX;

            string name = FilePickerFactory.GetPlatformName();

            Assert.Equal("macOS", name);
        }

        /// <summary>
        /// Tests that get platform name returns linux on mocked linux
        /// </summary>
        [Fact]
        public void GetPlatformName_ReturnsLinux_OnMockedLinux()
        {
            PlatformHelper.IsOSPlatform = p => p == OSPlatform.Linux;

            string name = FilePickerFactory.GetPlatformName();

            Assert.Equal("Linux", name);
        }

        /// <summary>
        /// Tests that get platform name returns unknown on unsupported platform
        /// </summary>
        [Fact]
        public void GetPlatformName_ReturnsUnknown_OnUnsupportedPlatform()
        {
            PlatformHelper.IsOSPlatform = p => false;

            string name = FilePickerFactory.GetPlatformName();

            Assert.Equal("Unknown", name);
        }

        /// <summary>
        /// Tests that is platform supported returns true on mocked windows
        /// </summary>
        [Fact]
        public void IsPlatformSupported_ReturnsTrue_OnMockedWindows()
        {
            PlatformHelper.IsOSPlatform = p => p == OSPlatform.Windows;

            Assert.True(FilePickerFactory.IsPlatformSupported());
        }

        /// <summary>
        /// Tests that is platform supported returns true on mocked mac
        /// </summary>
        [Fact]
        public void IsPlatformSupported_ReturnsTrue_OnMockedMac()
        {
            PlatformHelper.IsOSPlatform = p => p == OSPlatform.OSX;

            Assert.True(FilePickerFactory.IsPlatformSupported());
        }

        /// <summary>
        /// Tests that is platform supported returns true on mocked linux
        /// </summary>
        [Fact]
        public void IsPlatformSupported_ReturnsTrue_OnMockedLinux()
        {
            PlatformHelper.IsOSPlatform = p => p == OSPlatform.Linux;

            Assert.True(FilePickerFactory.IsPlatformSupported());
        }

        /// <summary>
        /// Tests that is platform supported returns false on unsupported platform
        /// </summary>
        [Fact]
        public void IsPlatformSupported_ReturnsFalse_OnUnsupportedPlatform()
        {
            PlatformHelper.IsOSPlatform = p => false;

            Assert.False(FilePickerFactory.IsPlatformSupported());
        }
    }
}
