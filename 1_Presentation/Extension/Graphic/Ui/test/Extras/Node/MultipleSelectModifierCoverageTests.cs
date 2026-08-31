// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MultipleSelectModifierCoverageTests.cs
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
    ///     The multiple select modifier coverage tests class
    /// </summary>
    public class MultipleSelectModifierCoverageTests
    {
        /// <summary>
        ///     Tests that the modifier property round-trips a byte array
        /// </summary>
        [Fact]
        public void MultipleSelectModifier_Modifier_RoundTripsArray()
        {
            MultipleSelectModifier modifier = default;
            byte[] expected = new byte[] { 1, 2, 3 };

            modifier.Modifier = expected;

            Assert.Same(expected, modifier.Modifier);
        }

        /// <summary>
        ///     Tests that the modifier property can be overwritten
        /// </summary>
        [Fact]
        public void MultipleSelectModifier_Modifier_OverwritesPreviousValue()
        {
            MultipleSelectModifier modifier = new MultipleSelectModifier { Modifier = new byte[] { 9 } };

            byte[] replacement = new byte[] { 4, 5 };
            modifier.Modifier = replacement;

            Assert.Same(replacement, modifier.Modifier);
        }

        /// <summary>
        ///     Tests that the modifier property defaults to null
        /// </summary>
        [Fact]
        public void MultipleSelectModifier_Default_ModifierIsNull()
        {
            MultipleSelectModifier modifier = default;

            Assert.Null(modifier.Modifier);
        }
    }
}
