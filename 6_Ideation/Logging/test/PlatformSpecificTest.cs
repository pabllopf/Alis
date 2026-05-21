

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Outputs;
using Alis.Core.Aspect.Logging.Test.Attributes;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Platform-specific behavior tests for the logging framework.
    ///     Tests different logging behavior across Windows, Linux, and macOS.
    /// </summary>
    public class PlatformSpecificTest
    {
        /// <summary>
        ///     Loggings the windows path with backslashes
        /// </summary>
        [WindowsOnly]
        public void Logging_Windows_PathWithBackslashes()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);
                ILogger logger = factory.CreateLogger("Logger");

                string windowsPath = "C:\\Users\\TestUser\\Documents\\file.txt";

                logger.LogInfo($"File path: {windowsPath}");

                ILogEntry entry = memoryOutput.GetEntries()[0];
                Assert.Contains("\\", entry.Message);
            }
        }

        /// <summary>
        ///     Loggings the linux path with forward slashes
        /// </summary>
        [LinuxOnly]
        public void Logging_Linux_PathWithForwardSlashes()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);
                ILogger logger = factory.CreateLogger("Logger");

                string linuxPath = "/home/user/documents/file.txt";

                logger.LogInfo($"File path: {linuxPath}");

                ILogEntry entry = memoryOutput.GetEntries()[0];
                Assert.Contains("/", entry.Message);
            }
        }

        /// <summary>
        ///     Tests that logging current platform should be detected
        /// </summary>
        [Fact]
        public void Logging_CurrentPlatform_ShouldBeDetected()
        {
            bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            bool isLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
            bool isOSX = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

            int count = (isWindows ? 1 : 0) + (isLinux ? 1 : 0) + (isOSX ? 1 : 0);
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Loggings the windows line endings
        /// </summary>
        [WindowsOnly]
        public void Logging_Windows_LineEndings()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);
                ILogger logger = factory.CreateLogger("Logger");

                logger.LogInfo("Line 1\nLine 2");

                ILogEntry entry = memoryOutput.GetEntries()[0];
                Assert.Contains("\n", entry.Message);
            }
        }

        /// <summary>
        ///     Loggings the linux environment
        /// </summary>
        [LinuxOnly]
        public void Logging_Linux_Environment()
        {
            string homeDir = Environment.GetEnvironmentVariable("HOME");

            Assert.NotNull(homeDir);
            Assert.True(homeDir.StartsWith("/"));
        }

        /// <summary>
        ///     Tests that logging all platforms date time
        /// </summary>
        [Fact]
        public void Logging_AllPlatforms_DateTime()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);
                ILogger logger = factory.CreateLogger("Logger");

                logger.LogInfo("Test");
                ILogEntry entry = memoryOutput.GetEntries()[0];

                Assert.True(entry.Timestamp.Year >= 2020);
                Assert.True(entry.Timestamp.Kind == DateTimeKind.Utc);
            }
        }

        /// <summary>
        ///     Loggings the windows temp path
        /// </summary>
        [WindowsOnly]
        public void Logging_Windows_TempPath()
        {
            string tempPath = Path.GetTempPath();

            Assert.NotEmpty(tempPath);
            Assert.True(Path.IsPathRooted(tempPath));
        }

        /// <summary>
        ///     Tests that logging thread info should be valid
        /// </summary>
        [Fact]
        public void Logging_ThreadInfo_ShouldBeValid()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);
                ILogger logger = factory.CreateLogger("Logger");

                logger.LogInfo("Test");
                ILogEntry entry = memoryOutput.GetEntries()[0];

                Assert.True(entry.ThreadId > 0);
            }
        }

        /// <summary>
        ///     Tests that logging unicode across all platforms
        /// </summary>
        [Fact]
        public void Logging_Unicode_AcrossAllPlatforms()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);
                ILogger logger = factory.CreateLogger("Logger");

                string unicodeMessage = "Unicode: 你好 مرحبا Привет 🎮";

                logger.LogInfo(unicodeMessage);

                ILogEntry entry = memoryOutput.GetEntries()[0];
                Assert.Equal(unicodeMessage, entry.Message);
            }
        }

        /// <summary>
        ///     Tests that logging process info should be available
        /// </summary>
        [Fact]
        public void Logging_ProcessInfo_ShouldBeAvailable()
        {
            int processId = Process.GetCurrentProcess().Id;

            Assert.True(processId > 0);
        }

        /// <summary>
        ///     Loggings the windows file system case
        /// </summary>
        [WindowsOnly]
        public void Logging_Windows_FileSystemCase()
        {
            // Note: Windows file system is case-insensitive

            string tempDir = Path.GetTempPath();
            string path1 = Path.Combine(tempDir, "TestFile.txt");
            string path2 = Path.Combine(tempDir, "testfile.txt");

            Assert.Equal(path1, path2, StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        ///     Loggings the linux file system case
        /// </summary>
        [LinuxOnly]
        public void Logging_Linux_FileSystemCase()
        {
            // Note: Linux file system is case-sensitive

            string tempDir = Path.GetTempPath();
            string path1 = Path.Combine(tempDir, "TestFile.txt");
            string path2 = Path.Combine(tempDir, "testfile.txt");

            Assert.NotEqual(path1, path2, StringComparer.Ordinal);
        }
    }
}