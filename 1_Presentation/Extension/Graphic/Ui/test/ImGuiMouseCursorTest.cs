// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiMouseCursorTest.cs
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

using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Provides unit coverage for <see cref="ImGuiMouseCursor" /> values.
    /// </summary>
    public class ImGuiMouseCursorTest
    {
        /// <summary>
        ///     Verifies that none keeps the sentinel negative value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void None_ShouldBeNegativeOne()
        {
            Assert.Equal(-1, (int) ImGuiMouseCursor.None);
        }

        /// <summary>
        ///     Verifies that count is one step after the last defined cursor.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Count_ShouldFollowNotAllowed()
        {
            Assert.Equal((int) ImGuiMouseCursor.NotAllowed + 1, (int) ImGuiMouseCursor.Count);
        }
    }
}