// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CanvasTest.cs
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

using Alis.Core.Ecs.Components.Ui;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Ui
{
    /// <summary>
    ///     Tests for the Canvas struct
    /// </summary>
    public class CanvasTest
    {
        /// <summary>
        ///     Tests that Canvas can be default-constructed
        /// </summary>
        [Fact]
        public void Canvas_DefaultConstructor_ShouldCreateInstance()
        {
            Canvas canvas = default;
            Assert.NotNull(canvas);
        }

        /// <summary>
        ///     Tests that Canvas is a struct (value type)
        /// </summary>
        [Fact]
        public void Canvas_ShouldBeValueType()
        {
            Canvas canvas = new Canvas();
            Assert.True(canvas.GetType().IsValueType);
        }
    }
}
