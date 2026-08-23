// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FilePickerExecutorAdditionalCoverageTests.cs
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
using Xunit;

namespace Alis.Extension.Io.FileDialog.Test
{
    /// <summary>
    ///     The file picker executor additional coverage tests class
    /// </summary>
    public class FilePickerExecutorAdditionalCoverageTests
    {
        /// <summary>
        ///     Tests that command exists with override returns override result
        /// </summary>
        [Fact]
        public void CommandExists_WithOverride_ReturnsOverrideResult()
        {
            try
            {
                FilePickerExecutor.CommandExistsOverride = command => command == "echo";
                bool result = FilePickerExecutor.CommandExists("echo");

                Assert.True(result);
            }
            finally
            {
                FilePickerExecutor.CommandExistsOverride = null;
            }
        }

        /// <summary>
        ///     Tests that execute command with missing executable throws invalid operation
        /// </summary>
        [Fact]
        public void ExecuteCommand_WithMissingExecutable_ThrowsInvalidOperation()
        {
            Assert.Throws<InvalidOperationException>(() => FilePickerExecutor.ExecuteCommand("nonexistent-command-xyz", ""));
        }

        /// <summary>
        ///     Tests that execute command with null file name throws argument exception
        /// </summary>
        [Fact]
        public void ExecuteCommand_WithNullFileName_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => FilePickerExecutor.ExecuteCommand(null, ""));
        }
    }
}
