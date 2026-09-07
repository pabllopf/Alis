// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FilePickerExecutorOverrideTest.cs
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
    ///     Tests targeting the ExecuteCommandOverride branch in FilePickerExecutor.
    /// </summary>
    public class FilePickerExecutorOverrideTest
    {
        /// <summary>
        ///     Ensures ExecuteCommand invokes the override and returns its result,
        ///     covering the ExecuteCommandOverride branch in ExecuteCommand.
        /// </summary>
        [Fact]
        public void ExecuteCommand_WithOverride_ReturnsOverrideResult()
        {
            try
            {
                FilePickerExecutor.ExecuteCommandOverride = (fileName, arguments, timeoutMs) =>
                    $"override:{fileName}:{arguments}:{timeoutMs}";

                string result = FilePickerExecutor.ExecuteCommand("echo", "hello", 5000);

                Assert.Equal("override:echo:hello:5000", result);
            }
            finally
            {
                FilePickerExecutor.ExecuteCommandOverride = null;
            }
        }
    }
}