// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotColormapScaleFlagsTest.cs
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
    ///     Provides unit coverage for <see cref="ImPlotColormapScaleFlags" /> values.
    /// </summary>
    public class ImPlotColormapScaleFlagsTest
    {
        /// <summary>
        ///     Verifies that None is zero.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImPlotColormapScaleFlags.None);
        }

        /// <summary>
        ///     Verifies that flags use distinct values.
        /// </summary>
        [Fact]
        public void Flags_ShouldBeDistinct()
        {
            Assert.NotEqual((int) ImPlotColormapScaleFlags.NoLabel, (int) ImPlotColormapScaleFlags.Opposite);
            Assert.NotEqual((int) ImPlotColormapScaleFlags.Opposite, (int) ImPlotColormapScaleFlags.Invert);
        }

        /// <summary>
        ///     Verifies that flags can be combined with bitwise OR.
        /// </summary>
        [Fact]
        public void Flags_ShouldCombineWithBitwiseOr()
        {
            ImPlotColormapScaleFlags combined = ImPlotColormapScaleFlags.NoLabel | ImPlotColormapScaleFlags.Invert;
            Assert.True(combined.HasFlag(ImPlotColormapScaleFlags.NoLabel));
            Assert.True(combined.HasFlag(ImPlotColormapScaleFlags.Invert));
        }
    }
}
