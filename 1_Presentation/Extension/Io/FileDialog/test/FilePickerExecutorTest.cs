// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FilePickerExecutorTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Threading;
using Alis.Extension.Io.FileDialog.Test.Attributes;
using Xunit;

namespace Alis.Extension.Io.FileDialog.Test
{
    /// <summary>
    ///     Tests for the FilePickerExecutor static class.
    ///     Covers validation, execution, timeout, and command existence scenarios.
    /// </summary>
    
    public class FilePickerExecutorTest
    {
        #region ExecuteCommand - Validation Tests

        [Fact]
        public void ExecuteCommand_WithNullFileName_ThrowsArgumentException()
        {
            // Arrange & Act
            Action act = () => FilePickerExecutor.ExecuteCommand(null, string.Empty);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void ExecuteCommand_WithEmptyFileName_ThrowsArgumentException()
        {
            // Arrange & Act
            Action act = () => FilePickerExecutor.ExecuteCommand(string.Empty, string.Empty);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal("fileName", exception.ParamName);
        }

        [Fact]
        public void ExecuteCommand_WithWhitespaceFileName_ThrowsArgumentException()
        {
            // Arrange & Act
            Action act = () => FilePickerExecutor.ExecuteCommand("   ", string.Empty);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void ExecuteCommand_WithNullArguments_Succeeds()
        {
            // Arrange & Act (null arguments should be treated as empty string)
            string result = FilePickerExecutor.ExecuteCommand("echo", null);

            // Assert
            Assert.NotNull(result);
        }

        #endregion

        #region ExecuteCommand - Happy Path Tests

        [LinuxOnly]
        public void ExecuteCommand_WithLsCommand_ReturnsOutput()
        {
            // Arrange & Act
            string result = FilePickerExecutor.ExecuteCommand("ls", "--version", 5000);

            // Assert
            Assert.NotNull(result);
        }

        [OSXOnly]
        public void ExecuteCommand_WithLsCommandOnMac_ReturnsOutput()
        {
            // Arrange & Act
            string result = FilePickerExecutor.ExecuteCommand("ls", "--version", 5000);

            // Assert
            Assert.NotNull(result);
        }

        [WindowsOnly]
        public void ExecuteCommand_WithDirCommand_ReturnsOutput()
        {
            // Arrange & Act
            string result = FilePickerExecutor.ExecuteCommand("dir", "/?", 5000);

            // Assert
            Assert.NotNull(result);
        }

        [LinuxOnly]
        public void ExecuteCommand_WithEchoCommand_ReturnsExpectedOutput()
        {
            // Arrange & Act
            string result = FilePickerExecutor.ExecuteCommand("echo", "hello world", 5000);

            // Assert
            Assert.Contains("hello world", result);
        }

        [OSXOnly]
        public void ExecuteCommand_WithEchoCommandOnMac_ReturnsExpectedOutput()
        {
            // Arrange & Act
            string result = FilePickerExecutor.ExecuteCommand("echo", "hello world", 5000);

            // Assert
            Assert.Contains("hello world", result);
        }

        [WindowsOnly]
        public void ExecuteCommand_WithEchoCommandOnWindows_ReturnsExpectedOutput()
        {
            // Arrange & Act
            string result = FilePickerExecutor.ExecuteCommand("cmd", "/c echo hello world", 5000);

            // Assert
            Assert.Contains("hello world", result);
        }

        [LinuxOnly]
        public void ExecuteCommand_WithLongArguments_ReturnsOutput()
        {
            // Arrange & Act
            string longArg = new string('a', 1000);
            string result = FilePickerExecutor.ExecuteCommand("echo", longArg, 5000);

            // Assert
            Assert.NotNull(result);
        }

        [LinuxOnly]
        public void ExecuteCommand_WithArgumentsContainingSpaces_ReturnsOutput()
        {
            // Arrange & Act
            string result = FilePickerExecutor.ExecuteCommand("echo", "arg with spaces and more args", 5000);

            // Assert
            Assert.NotNull(result);
        }

        #endregion

        #region ExecuteCommand - Timeout Tests

        [LinuxOnly]
        public void ExecuteCommand_WithTimeout_KillsProcessAndReturnsNull()
        {
            // Arrange & Act
            string result = FilePickerExecutor.ExecuteCommand("sleep", "10", 100);

            // Assert
            Assert.Null(result);
        }

        [OSXOnly]
        public void ExecuteCommand_WithTimeoutOnMac_KillsProcessAndReturnsNull()
        {
            // Arrange & Act
            string result = FilePickerExecutor.ExecuteCommand("sleep", "10", 100);

            // Assert
            Assert.Null(result);
        }

        [WindowsOnly]
        public void ExecuteCommand_WithTimeoutOnWindows_KillsProcessAndReturnsNull()
        {
            // Arrange & Act
            string result = FilePickerExecutor.ExecuteCommand("ping", "-n 10 127.0.0.1", 100);

            // Assert
            Assert.Null(result);
        }

        #endregion

        #region ExecuteCommand - Error Handling Tests

        [Fact]
        public void ExecuteCommand_WithNonExistentCommand_ThrowsInvalidOperationException()
        {
            // Arrange & Act
            Action act = () => FilePickerExecutor.ExecuteCommand("this_command_does_not_exist_abc123", string.Empty, 5000);

            // Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(act);
            Assert.Contains("this_command_does_not_exist_abc123", exception.Message);
        }

        [Fact]
        public void ExecuteCommand_WithNonExistentCommand_HasInnerException()
        {
            // Arrange & Act
            Action act = () => FilePickerExecutor.ExecuteCommand("nonexistent_cmd_xyz789", string.Empty, 5000);

            // Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(act);
            Assert.NotNull(exception.InnerException);
        }

        [LinuxOnly]
        public void ExecuteCommand_WithValidCommandAndCustomTimeout_ReturnsOutput()
        {
            // Arrange & Act
            string result = FilePickerExecutor.ExecuteCommand("echo", "test", 1000);

            // Assert
            Assert.NotNull(result);
        }

        [OSXOnly]
        public void ExecuteCommand_WithValidCommandAndCustomTimeoutOnMac_ReturnsOutput()
        {
            // Arrange & Act
            string result = FilePickerExecutor.ExecuteCommand("echo", "test", 1000);

            // Assert
            Assert.NotNull(result);
        }

        [WindowsOnly]
        public void ExecuteCommand_WithValidCommandAndCustomTimeoutOnWindows_ReturnsOutput()
        {
            // Arrange & Act
            string result = FilePickerExecutor.ExecuteCommand("cmd", "/c echo test", 1000);

            // Assert
            Assert.NotNull(result);
        }

        #endregion

        #region CommandExists - Validation Tests

        [Fact]
        public void CommandExists_WithNullCommand_ReturnsFalse()
        {
            // Arrange & Act
            bool result = FilePickerExecutor.CommandExists(null);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CommandExists_WithEmptyCommand_ReturnsFalse()
        {
            // Arrange & Act
            bool result = FilePickerExecutor.CommandExists(string.Empty);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CommandExists_WithWhitespaceCommand_ReturnsFalse()
        {
            // Arrange & Act
            bool result = FilePickerExecutor.CommandExists("   ");

            // Assert
            Assert.False(result);
        }

        #endregion

        #region CommandExists - Happy Path Tests

        [LinuxOnly]
        public void CommandExists_WithLsCommand_ReturnsTrue()
        {
            // Arrange & Act
            bool result = FilePickerExecutor.CommandExists("ls");

            // Assert
            Assert.True(result);
        }

        [WindowsOnly]
        public void CommandExists_WithDirCommandOnWindows_ReturnsTrue()
        {
            // Arrange & Act
            bool result = FilePickerExecutor.CommandExists("dir");

            // Assert
            Assert.True(result);
        }


        #endregion

        #region CommandExists - Negative Tests

        [Fact]
        public void CommandExists_WithNonExistentCommand_ReturnsFalse()
        {
            // Arrange & Act
            bool result = FilePickerExecutor.CommandExists("this_command_does_not_exist_xyz123");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CommandExists_WithRandomString_ReturnsFalse()
        {
            // Arrange & Act
            bool result = FilePickerExecutor.CommandExists("abc123random_nonexistent_cmd");

            // Assert
            Assert.False(result);
        }

        #endregion

        #region CommandExists - Edge Cases

        [LinuxOnly]
        public void CommandExists_WithCommandContainingSpecialChars_ReturnsFalse()
        {
            // Arrange & Act
            bool result = FilePickerExecutor.CommandExists("cmd@#$%");

            // Assert
            Assert.False(result);
        }

        [OSXOnly]
        public void CommandExists_WithCommandContainingSpecialCharsOnMac_ReturnsFalse()
        {
            // Arrange & Act
            bool result = FilePickerExecutor.CommandExists("cmd@#$%");

            // Assert
            Assert.False(result);
        }

        [WindowsOnly]
        public void CommandExists_WithCommandContainingSpecialCharsOnWindows_ReturnsFalse()
        {
            // Arrange & Act
            bool result = FilePickerExecutor.CommandExists("cmd@#$%");

            // Assert
            Assert.False(result);
        }

        [LinuxOnly]
        public void CommandExists_WithUppercaseCommand_ReturnsTrue()
        {
            // Arrange & Act
            bool result = FilePickerExecutor.CommandExists("LS");

            // Assert
            Assert.True(result);
        }

        [WindowsOnly]
        public void CommandExists_WithUppercaseCommandOnWindows_ReturnsTrue()
        {
            // Arrange & Act
            bool result = FilePickerExecutor.CommandExists("DIR");

            // Assert
            Assert.True(result);
        }

        #endregion
    }
}
