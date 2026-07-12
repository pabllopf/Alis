// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotLineFlagsTest.cs
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
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     Provides unit coverage for <see cref="ImPlotLineFlags" /> values.
    /// </summary>
    public class ImPlotLineFlagsTest
    {
        /// <summary>
        ///     Verifies that none is zero.
        /// </summary>
        [RequireCImguiSystemFact]
        public void None_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImPlotLineFlags.None);
        }

        /// <summary>
        ///     Verifies selected flags remain distinct.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Flags_ShouldBeDistinct()
        {
            Assert.NotEqual((int) ImPlotLineFlags.Segments, (int) ImPlotLineFlags.Loop);
            Assert.NotEqual((int) ImPlotLineFlags.SkipNaN, (int) ImPlotLineFlags.NoClip);
            Assert.NotEqual((int) ImPlotLineFlags.Shaded, (int) ImPlotLineFlags.NoClip);
        }
    }
}