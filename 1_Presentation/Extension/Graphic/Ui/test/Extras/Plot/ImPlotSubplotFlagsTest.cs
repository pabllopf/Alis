// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotSubplotFlagsTest.cs
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
    ///     Provides unit coverage for <see cref="ImPlotSubplotFlags" /> values.
    /// </summary>
    public class ImPlotSubplotFlagsTest
    {
        /// <summary>
        ///     Verifies that none is zero.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImPlotSubplotFlags.None);
        }

        /// <summary>
        ///     Verifies that link-all values are distinct and ordered.
        /// </summary>
        [Fact]
        public void LinkAllFlags_ShouldBeDistinct()
        {
            Assert.NotEqual((int) ImPlotSubplotFlags.LinkAllX, (int) ImPlotSubplotFlags.LinkAllY);
            Assert.True((int) ImPlotSubplotFlags.LinkAllY > (int) ImPlotSubplotFlags.LinkAllX);
        }

        /// <summary>
        ///     Verifies that representative subplot flags do not overlap in value.
        /// </summary>
        [Fact]
        public void RepresentativeFlags_ShouldBeDistinct()
        {
            Assert.NotEqual((int) ImPlotSubplotFlags.NoResize, (int) ImPlotSubplotFlags.NoAlign);
            Assert.NotEqual((int) ImPlotSubplotFlags.ShareItems, (int) ImPlotSubplotFlags.ColMajor);
        }
    }
}