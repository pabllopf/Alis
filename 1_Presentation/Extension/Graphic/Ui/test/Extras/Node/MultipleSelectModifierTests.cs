// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MultipleSelectModifierTests.cs
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
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Node
{
    /// <summary>
    ///     Remaining coverage tests for the <see cref="MultipleSelectModifier" /> struct.
    /// </summary>
    public class MultipleSelectModifierTests
    {
        /// <summary>
        ///     Verifies that the Modifier property is null by default.
        /// </summary>
         [RequireCImguiSystemFact]
        public void DefaultModifier_IsNull()
        {
            MultipleSelectModifier m = new MultipleSelectModifier();
            Assert.Null(m.Modifier);
        }

        /// <summary>
        ///     Verifies that the Modifier property round-trips a byte array.
        /// </summary>
         [RequireCImguiSystemFact]
        public void Modifier_RoundTrip()
        {
            MultipleSelectModifier m = new MultipleSelectModifier();
            byte[] mod = { 1, 2, 3 };
            m.Modifier = mod;
            Assert.Same(mod, m.Modifier);
        }

        /// <summary>
        ///     Verifies that the Modifier property accepts an empty byte array.
        /// </summary>
         [RequireCImguiSystemFact]
        public void Modifier_SetToEmptyArray()
        {
            MultipleSelectModifier m = new MultipleSelectModifier();
            m.Modifier = new byte[0];
            Assert.NotNull(m.Modifier);
            Assert.Equal(0, m.Modifier.Length);
        }

        /// <summary>
        ///     Verifies that the Modifier property can be reassigned.
        /// </summary>
         [RequireCImguiSystemFact]
        public void Modifier_Reassignment()
        {
            MultipleSelectModifier m = new MultipleSelectModifier();
            m.Modifier = new byte[] { 1, 2 };
            m.Modifier = new byte[] { 3, 4, 5 };
            Assert.Equal(new byte[] { 3, 4, 5 }, m.Modifier);
        }

        /// <summary>
        ///     Verifies that the Modifier property handles a single-element array.
        /// </summary>
         [RequireCImguiSystemFact]
        public void Modifier_SingleElement()
        {
            MultipleSelectModifier m = new MultipleSelectModifier();
            m.Modifier = new byte[] { 42 };
            Assert.Equal(42, m.Modifier[0]);
            Assert.Single(m.Modifier);
        }

        /// <summary>
        ///     Verifies that the Modifier property handles a large byte array.
        /// </summary>
         [RequireCImguiSystemFact]
        public void Modifier_LargeArray()
        {
            MultipleSelectModifier m = new MultipleSelectModifier();
            byte[] big = new byte[1024];
            for (int i = 0; i < big.Length; i++)
            {
                big[i] = (byte)(i & 0xFF);
            }
            m.Modifier = big;
            Assert.Equal(1024, m.Modifier.Length);
            Assert.Equal(255, m.Modifier[255]);
        }
    }
}
