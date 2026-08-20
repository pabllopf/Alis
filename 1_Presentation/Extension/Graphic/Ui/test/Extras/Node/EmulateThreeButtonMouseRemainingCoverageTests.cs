// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EmulateThreeButtonMouseRemainingCoverageTests.cs
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
    ///     Remaining coverage tests for the <see cref="EmulateThreeButtonMouse" /> struct.
    /// </summary>
    public class EmulateThreeButtonMouseRemainingCoverageTests
    {
        /// <summary>
        ///     Verifies that the Modifier property round-trips a byte array.
        /// </summary>
         [RequireCImguiSystemFact]
        public void Modifier_RoundTrip()
        {
            EmulateThreeButtonMouse m = new EmulateThreeButtonMouse();
            byte[] mod = new byte[] { 1, 2, 3 };
            m.Modifier = mod;
            Assert.Same(mod, m.Modifier);
        }

        /// <summary>
        ///     Verifies that the Modifier property is null by default.
        /// </summary>
         [RequireCImguiSystemFact]
        public void DefaultModifier_IsNull()
        {
            EmulateThreeButtonMouse m = new EmulateThreeButtonMouse();
            Assert.Null(m.Modifier);
        }

        /// <summary>
        ///     Verifies that the Modifier property accepts an empty byte array.
        /// </summary>
         [RequireCImguiSystemFact]
        public void Modifier_SetToEmptyArray()
        {
            EmulateThreeButtonMouse m = new EmulateThreeButtonMouse();
            m.Modifier = new byte[0];
            Assert.NotNull(m.Modifier);
            Assert.Equal(0, m.Modifier.Length);
        }
    }
}