// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LinkDetachWithModifierClickCoverageTests.cs
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

using Alis.Extension.Graphic.Ui.Extras.Node;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Node
{
    /// <summary>
    ///     The link detach with modifier click coverage tests class
    /// </summary>
    public class LinkDetachWithModifierClickCoverageTests
    {
        /// <summary>
        ///     Tests that the modifier property round-trips a byte array
        /// </summary>
        [Fact]
        public void LinkDetachWithModifierClick_Modifier_RoundTripsArray()
        {
            LinkDetachWithModifierClick link = default;
            byte[] expected = new byte[] { 1, 2, 3 };

            link.Modifier = expected;

            Assert.Same(expected, link.Modifier);
        }

        /// <summary>
        ///     Tests that the modifier property can be overwritten
        /// </summary>
        [Fact]
        public void LinkDetachWithModifierClick_Modifier_OverwritesPreviousValue()
        {
            LinkDetachWithModifierClick link = new LinkDetachWithModifierClick { Modifier = new byte[] { 9 } };

            byte[] replacement = new byte[] { 4, 5 };
            link.Modifier = replacement;

            Assert.Same(replacement, link.Modifier);
        }

        /// <summary>
        ///     Tests that the modifier property defaults to null
        /// </summary>
        [Fact]
        public void LinkDetachWithModifierClick_Default_ModifierIsNull()
        {
            LinkDetachWithModifierClick link = default;

            Assert.Null(link.Modifier);
        }
    }
}
