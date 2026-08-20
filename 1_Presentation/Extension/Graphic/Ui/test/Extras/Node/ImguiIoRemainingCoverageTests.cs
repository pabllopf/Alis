// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImguiIoRemainingCoverageTests.cs
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
    ///     Remaining coverage tests for the <see cref="ImguiIo" /> struct.
    /// </summary>
    public class ImguiIoRemainingCoverageTests
    {
        /// <summary>
        ///     Verifies that default values are null for struct properties.
        /// </summary>
         [RequireCImguiSystemFact]
        public void Default_ValuesAreNull()
        {
            ImguiIo io = default;
            Assert.Null(io.EmulateThreeButtonMouse.Modifier);
            Assert.Null(io.LinkDetachWithModifierClick.Modifier);
        }

        /// <summary>
        ///     Verifies that EmulateThreeButtonMouse round-trips.
        /// </summary>
         [RequireCImguiSystemFact]
        public void EmulateThreeButtonMouse_RoundTrip()
        {
            ImguiIo io = default;
            EmulateThreeButtonMouse m = new EmulateThreeButtonMouse();
            m.Modifier = new byte[] { 1, 2, 3 };
            io.EmulateThreeButtonMouse = m;
            Assert.Same(m.Modifier, io.EmulateThreeButtonMouse.Modifier);
        }

        /// <summary>
        ///     Verifies that LinkDetachWithModifierClick round-trips.
        /// </summary>
         [RequireCImguiSystemFact]
        public void LinkDetachWithModifierClick_RoundTrip()
        {
            ImguiIo io = default;
            LinkDetachWithModifierClick l = new LinkDetachWithModifierClick();
            l.Modifier = new byte[] { 4, 5, 6 };
            io.LinkDetachWithModifierClick = l;
            Assert.Same(l.Modifier, io.LinkDetachWithModifierClick.Modifier);
        }

        /// <summary>
        ///     Verifies that both properties can be set independently.
        /// </summary>
         [RequireCImguiSystemFact]
        public void BothProperties_Independently()
        {
            ImguiIo io = default;
            EmulateThreeButtonMouse m = new EmulateThreeButtonMouse();
            m.Modifier = new byte[] { 1 };
            io.EmulateThreeButtonMouse = m;
            LinkDetachWithModifierClick l = new LinkDetachWithModifierClick();
            l.Modifier = new byte[] { 2 };
            io.LinkDetachWithModifierClick = l;
            Assert.Single(io.EmulateThreeButtonMouse.Modifier);
            Assert.Single(io.LinkDetachWithModifierClick.Modifier);
            Assert.Equal(1, io.EmulateThreeButtonMouse.Modifier[0]);
            Assert.Equal(2, io.LinkDetachWithModifierClick.Modifier[0]);
        }
    }
}
