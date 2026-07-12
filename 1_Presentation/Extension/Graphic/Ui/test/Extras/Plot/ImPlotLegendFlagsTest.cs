// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotLegendFlagsTest.cs
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
    ///     Provides unit coverage for <see cref="ImPlotLegendFlags" /> values.
    /// </summary>
    public class ImPlotLegendFlagsTest
    {
        /// <summary>
        ///     Verifies that none is zero.
        /// </summary>
        [RequireCImguiSystemFact]
        public void None_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImPlotLegendFlags.None);
        }

        /// <summary>
        ///     Verifies that representative legend flags are distinct bit values.
        /// </summary>
        [RequireCImguiSystemFact]
        public void RepresentativeFlags_ShouldBeDistinct()
        {
            Assert.NotEqual((int) ImPlotLegendFlags.NoButtons, (int) ImPlotLegendFlags.Outside);
            Assert.NotEqual((int) ImPlotLegendFlags.NoMenus, (int) ImPlotLegendFlags.Horizontal);
            Assert.NotEqual((int) ImPlotLegendFlags.Sort, (int) ImPlotLegendFlags.NoHighlightAxis);
        }
    }
}