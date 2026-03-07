// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotCondTest.cs
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

using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     Provides unit coverage for <see cref="ImPlotCond" /> enum values.
    /// </summary>
    public class ImPlotCondTest
    {
        /// <summary>
        ///     Verifies that condition values are defined.
        /// </summary>
        [Fact]
        public void Always_ShouldBeDefined()
        {
            ImPlotCond cond = ImPlotCond.Always;
            Assert.NotEqual(0, (int) cond);
        }

        /// <summary>
        ///     Verifies that different conditions have distinct values.
        /// </summary>
        [Fact]
        public void EnumValues_ShouldBeDistinct()
        {
            ImPlotCond always = ImPlotCond.Always;
            ImPlotCond once = ImPlotCond.Once;

            Assert.NotEqual((int) always, (int) once);
        }
    }
}