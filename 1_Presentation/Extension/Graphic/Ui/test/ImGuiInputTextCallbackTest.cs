// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiInputTextCallbackTest.cs
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

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Provides unit coverage for <see cref="ImGuiInputTextCallback" /> delegate behavior.
    /// </summary>
    public class ImGuiInputTextCallbackTest
    {
        /// <summary>
        ///     Verifies that the callback can be invoked with expected parameters.
        /// </summary>
        [Fact]
        public void Invoke_ShouldCallAssignedCallback()
        {
            bool called = false;
            Func<ImGuiInputTextCallbackData, int> callback = _ =>
            {
                called = true;
                return 0;
            };

            int result = callback(new ImGuiInputTextCallbackData());

            Assert.True(called);
            Assert.Equal(0, result);
        }

        /// <summary>
        ///     Verifies that the callback can return different result codes.
        /// </summary>
        [Fact]
        public void Invoke_ShouldReturnExpectedResultCode()
        {
            Func<ImGuiInputTextCallbackData, int> callback = _ => 42;

            int result = callback(new ImGuiInputTextCallbackData());

            Assert.Equal(42, result);
        }
    }
}