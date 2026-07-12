// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotAxisFlagsTest.cs
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
    ///     Provides unit coverage for <see cref="ImPlotAxisFlags" /> values and combinations.
    /// </summary>
    public class ImPlotAxisFlagsTest
    {
        /// <summary>
        ///     Verifies that none is zero.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImPlotAxisFlags.None);
        }

        /// <summary>
        ///     Verifies that lock and no-decorations aliases map to their documented compositions.
        /// </summary>
        [Fact]
        public void AliasCompositions_ShouldMatchExpectedValues()
        {
            ImPlotAxisFlags expectedLock = ImPlotAxisFlags.LockMin | ImPlotAxisFlags.LockMax;
            ImPlotAxisFlags expectedNoDecorations = ImPlotAxisFlags.NoLabel | ImPlotAxisFlags.NoGridLines | ImPlotAxisFlags.NoTickMarks | ImPlotAxisFlags.NoTickLabels;

            Assert.Equal(expectedLock, ImPlotAxisFlags.Lock);
            Assert.Equal(expectedNoDecorations, ImPlotAxisFlags.NoDecorations);
        }

        /// <summary>
        ///     Verifies that auxiliary defaults map to opposite plus no-grid-lines.
        /// </summary>
        [Fact]
        public void AuxDefault_ShouldMatchExpectedComposition()
        {
            ImPlotAxisFlags expected = ImPlotAxisFlags.Opposite | ImPlotAxisFlags.NoGridLines;

            Assert.Equal(expected, ImPlotAxisFlags.AuxDefault);
        }
    }
}