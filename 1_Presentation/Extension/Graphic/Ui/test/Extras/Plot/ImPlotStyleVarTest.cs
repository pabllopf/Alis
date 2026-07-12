// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotStyleVarTest.cs
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
    ///     Provides unit coverage for <see cref="ImPlotStyleVar" /> ordinal values.
    /// </summary>
    public class ImPlotStyleVarTest
    {
        /// <summary>
        ///     Verifies first and last sentinel values remain stable.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Boundaries_ShouldMatchExpectedOrdinals()
        {
            Assert.Equal(0, (int) ImPlotStyleVar.LineWeight);
            Assert.Equal(27, (int) ImPlotStyleVar.Count);
        }

        /// <summary>
        ///     Verifies selected style variables stay in ascending order.
        /// </summary>
        [RequireCImguiSystemFact]
        public void RepresentativeValues_ShouldBeAscending()
        {
            Assert.True((int) ImPlotStyleVar.Marker > (int) ImPlotStyleVar.LineWeight);
            Assert.True((int) ImPlotStyleVar.PlotPadding > (int) ImPlotStyleVar.MinorGridSize);
            Assert.True((int) ImPlotStyleVar.PlotMinSize > (int) ImPlotStyleVar.PlotDefaultSize);
        }
    }
}