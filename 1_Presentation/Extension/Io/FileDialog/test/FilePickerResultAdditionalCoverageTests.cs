// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FilePickerResultAdditionalCoverageTests.cs
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

using System.Reflection;
using Xunit;

namespace Alis.Extension.Io.FileDialog.Test
{
    /// <summary>
    ///     Additional unit tests for FilePickerResult class covering the SelectedPath null-guard branch.
    /// </summary>
    public class FilePickerResultAdditionalCoverageTests
    {
        /// <summary>
        ///     Tests that SelectedPath returns null when SelectedPaths is null.
        /// </summary>
        [Fact]
        public void SelectedPath_WhenSelectedPathsNull_ShouldReturnNull()
        {
            FilePickerResult result = FilePickerResult.CreateCancelled();
            PropertyInfo property = typeof(FilePickerResult).GetProperty(nameof(FilePickerResult.SelectedPaths));
            property.SetValue(result, null);

            Assert.Null(result.SelectedPath);
        }
    }
}
