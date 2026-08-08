// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FilePickerExecutorCoverageTest.cs
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

using Xunit;

namespace Alis.Extension.Io.FileDialog.Test
{
    /// <summary>
    /// The file picker executor coverage test class
    /// </summary>
    public class FilePickerExecutorCoverageTest
    {
        /// <summary>
        /// Tests that execute command with null arguments should not throw
        /// </summary>
        [Fact]
        public void ExecuteCommand_WithNullArguments_ShouldNotThrow()
        {
            string result = FilePickerExecutor.ExecuteCommand("echo", null, 5000);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that command exists with non existent command returns false
        /// </summary>
        [Fact]
        public void CommandExists_WithNonExistentCommand_ReturnsFalse()
        {
            bool result = FilePickerExecutor.CommandExists("nonexistent_cmd_xyz_abc_123_test");

            Assert.False(result);
        }
    }
}
