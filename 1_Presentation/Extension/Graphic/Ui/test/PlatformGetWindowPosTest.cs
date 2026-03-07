// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PlatformGetWindowPosTest.cs
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
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Provides unit coverage for <see cref="PlatformGetWindowPos" /> delegate behavior.
    /// </summary>
    public class PlatformGetWindowPosTest
    {
        /// <summary>
        ///     Verifies that the delegate can return a position through an out parameter.
        /// </summary>
        [Fact]
        public void Invoke_ShouldReturnExpectedOutPosition()
        {
            Vector2F expected = new Vector2F(10.0f, 20.0f);
            PlatformGetWindowPos callback = (ImGuiViewportPtr _, out Vector2F outPos) => outPos = expected;

            callback(new ImGuiViewportPtr(IntPtr.Zero), out Vector2F result);

            Assert.Equal(expected, result);
        }
    }
}